Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient

Public Class frmITRPost
    Dim wbid As Integer = 0
    Dim itrno As Integer = 0

    Public Sub New(mitrno As Integer)
        itrno = mitrno
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub frmITRPost_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call initForm()
        If itrno > 0 Then
            Call QueryData(itrno)
            txtAccountTrn.Focus()
        End If
    End Sub
    Private Sub initForm()
        txtITRNo.Clear()
        lblITRDate.Text = ""
        lblJobno.Text = ""
        lblWbNo.Text = ""
        lblITRRem.Text = ""
        txtTotalAdvance.Text = 0
        txtTotalChg.Text = 0
        txtTotalVAT.Text = 0
        txtTotalDue.Text = 0
        chkPosted.Checked = True
        wbid = 0
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Call QueryData(txtITRNo.Text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtITRNo.Tag = 0 Then lblMsg.Text = "Nothing to save, Invalid ITR" : Exit Sub
        If txtAccountTrn.Tag = 0 Then lblMsg.Text = "Account Trn Ref# is required" : Exit Sub
        Try
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            sql_String = "update dbo.waybills set accountref='" & txtAccountTrn.Text & "',itrvendorinv='" & (txtVendorInv.Text) & "',"
            sql_String += " itrAccountNote='" & Replace(txtPaymentNote.Text, "'", "") & "',itrpost=" & CBool(chkPosted.Checked)
            sql_String += " where WBID=" & wbid & " and itrno=" & txtITRNo.Text
            Dim commandx As New SqlCommand(sql_String, sql_CNN)
            commandx.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub QueryData(yitrno As Integer)
        If Not IsNumeric(txtITRNo.Text) Then Exit Sub
        If yitrno < 1 Then Exit Sub
        Dim rtnval As Integer = 0
        lblMsg.Text = ""
        txtITRNo.Tag = 0
        Dim dblchg As Double = 0
        Dim dbladv As Double = 0
        Dim dblvat As Double = 0
        Dim dbldue As Double = 0
        wbid = 0
        sql_String = "select v.*,isnull(w.cost,0) [itrCost] from viewQueryWaybillRecord2018 v "
        sql_String += " left outer join (select wbid, sum(cost) cost from WaybillCosting where cost>0 group by wbID) w"
        sql_String += " on v.WBID=w.wbID where v.itrno=" & yitrno & " and v.branchID=" & appUserInfo.BranchId
        Try
            Dim ds As New DataSet
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                rtnval = ds.Tables(0).Rows(0).Item("itrno")

                lblITRDate.Text = "ITR Date : " & ds.Tables(0).Rows(0).Item("itrdate")
                lblJobno.Text = "Job Number : " & ds.Tables(0).Rows(0).Item("job no")
                lblWbNo.Text = "Waybill No. : " & ds.Tables(0).Rows(0).Item("wbno")
                wbid = ds.Tables(0).Rows(0).Item("wbid")
                lblITRRem.Text = "Remarks :" & ds.Tables(0).Rows(0).Item("itrnote")

                dblchg = ds.Tables(0).Rows(0).Item("itrcost")
                dbladv = ds.Tables(0).Rows(0).Item("AdvanceCost")
                dblvat = ds.Tables(0).Rows(0).Item("itrvatamt")
                dbldue = ((dblchg + dblvat) - dbladv)
                txtTotalChg.Text = dblchg.ToString("N")
                txtTotalAdvance.Text = dbladv.ToString("N")
                txtTotalVAT.Text = dblvat.ToString("N")
                txtTotalDue.Text = dbldue.ToString("N")

                txtAccountTrn.Text = ds.Tables(0).Rows(0).Item("accountrefno")
                txtVendorInv.Text = ds.Tables(0).Rows(0).Item("itrvendorinv")
                txtPaymentNote.Text = ds.Tables(0).Rows(0).Item("itrAccountNote")
                chkPosted.Checked = CBool(ds.Tables(0).Rows(0).Item("wbpost"))
                txtITRNo.Tag = 1
                txtAccountTrn.Focus()
                txtAccountTrn.SelectAll()
            Else
                lblMsg.Text = "ITR Number Not Found"
                txtITRNo.Focus()
                txtITRNo.SelectAll()
                txtITRNo.Tag = 0
            End If
        Catch ex As Exception
            rtnval = 0
        End Try
    End Sub

End Class