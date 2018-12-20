Imports System.Data.SqlClient
'rate input 
Public Class frmWaybillSellingChargeList
    Dim recid As Integer = 0
    Dim OrgRecID As Integer = 0
    Dim Loc1RecID As Integer = 0
    Dim Loc2RecID As Integer = 0
    Dim WBRecid As Integer = 0
    Public Sub New(mRecID As Integer, mOrgRecid As Integer, mLoc1RecID As Integer, mLoc2RecID As Integer, mwbrecid As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        recid = mRecID
        OrgRecID = mOrgRecid
        Loc1RecID = mLoc1RecID
        Loc2RecID = mLoc2RecID
        WBRecid = mwbrecid
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmWaybillSellingChargeList_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call init()
        Call GetData()
        txtServiceAmount.Focus()
        lnkVATCalculation.Text = "Calculate VAT By " & appCompanyInfo.VATPercentage & "%"

    End Sub

    Private Sub init()
        txtServiceAmount.Text = 0
        txtTotal.Text = 0
        txtTotalVAT.Text = 0
        txtAdditionalRoute.Clear()
        txtServiceCharge.Clear()
        lblMessage.Text = ""
    End Sub

    Private Sub GetData()
        Me.Cursor = Cursors.WaitCursor
        Try
            If recid < 1 Then Exit Sub
            Dim dstmp As New DataSet
            sql_String = "select c.name [Charge], w.revenue [Amount], w.VAT [TaxAmount], w.revenue+w.vat [Total], w.linenoterevenue [Note], w.recid "
            sql_String += " from waybillcosting w inner join chargeElements c on w.chargeid=c.recid"
            sql_String += " where w.recid=" & recid
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                With dstmp.Tables(0).Rows(0)
                    txtServiceCharge.Text = .Item("Charge")
                    txtServiceAmount.Text = .Item("amount")
                    txtTotalVAT.Text = .Item("TaxAmount")
                    txtTotal.Text = .Item("Total")
                    txtAdditionalRoute.Text = .Item("Note")
                End With
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "control focus"

    Private Sub txtAdditionalRoute_GotFocus(sender As Object, e As EventArgs) Handles txtAdditionalRoute.GotFocus
        txtAdditionalRoute.SelectAll()
    End Sub

    Private Sub txtServiceAmount_GotFocus(sender As Object, e As EventArgs) Handles txtServiceAmount.GotFocus
        txtServiceAmount.SelectAll()
    End Sub

    Private Sub txtServiceCharge_GotFocus(sender As Object, e As EventArgs) Handles txtServiceCharge.GotFocus
        txtServiceCharge.SelectAll()
    End Sub

    Private Sub txtTotalVAT_GotFocus(sender As Object, e As EventArgs) Handles txtTotalVAT.GotFocus
        txtTotalVAT.SelectAll()
    End Sub

    Private Sub txtTotal_GotFocus(sender As Object, e As EventArgs) Handles txtTotal.GotFocus
        txtTotal.SelectAll()
    End Sub
    Private Sub txtServiceAmount_LostFocus(sender As Object, e As EventArgs) Handles txtServiceAmount.LostFocus
        Call calc()
    End Sub

    Private Sub txtTotalVAT_LostFocus(sender As Object, e As EventArgs) Handles txtTotalVAT.LostFocus
        Call calc()
    End Sub
#End Region

    Private Sub btnOkVendor_Click(sender As Object, e As EventArgs) Handles btnOkVendor.Click
        Try
            Me.Cursor = Cursors.Default
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            Dim sqlcmd As SqlCommand = sql_CNN.CreateCommand()

            sql_String = "update [waybillcosting] set "
            sql_String += " revenue=" & txtServiceAmount.Text
            sql_String += " ,vat=" & txtTotalVAT.Text
            If txtTotalVAT.Text > 0 Then sql_String += ",vatpercent=" & appCompanyInfo.VATPercentage
            sql_String += " ,linenoterevenue=N'" & Replace(txtAdditionalRoute.Text, "'", "") & "'"
            sql_String += " where recid=" & recid
            sqlcmd.CommandText = sql_String
            sqlcmd.ExecuteNonQuery()

            If Val(txtServiceAmount.Text) > 0 Then
                sqlcmd.CommandText = "update [waybills] set wbstatus='BILLED' where recid=" & WBRecid
                sqlcmd.ExecuteNonQuery()
            End If

            Me.Close()
            Me.Cursor = Cursors.Default



        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub calc()
        Dim val1 As Double
        Dim val2 As Double
        Dim val3 As Double
        If Not IsNumeric(txtTotalVAT.Text) Then txtTotalVAT.Text = 0
        If Not IsNumeric(txtServiceAmount.Text) Then txtServiceAmount.Text = 0
        val1 = txtServiceAmount.Text
        val2 = txtTotalVAT.Text
        val3 = (val1 + val2)
        txtTotal.Text = val3.ToString("N")
    End Sub


    Private Sub lnkSellingRate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSellingRate.LinkClicked
        lblMessage.Text = ""
        If OrgRecID > 0 Then
            sql_String = "select  isnull(SellingRate,0) [amt], isnull(lineNote,'') note from dbo.vieworganizationrates where orgrecid=" & OrgRecID
            sql_String += " and loc1recid=" & Loc1RecID & " and loc2recid=" & Loc2RecID
            Me.Cursor = Cursors.WaitCursor
            Try
                Dim dstmp As New DataSet
                dstmp = setDataList(sql_String)
                If dstmp.Tables(0).Rows.Count > 0 Then
                    txtServiceAmount.Text = dstmp.Tables(0).Rows(0).Item("amt")
                    txtAdditionalRoute.Text = dstmp.Tables(0).Rows(0).Item("note")
                    Call calc()
                    txtServiceAmount.Focus()
                End If
            Catch ex As Exception
                lblMessage.Text = ex.Message
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub lnkVATCalculation_Click(sender As Object, e As EventArgs) Handles lnkVATCalculation.Click
        Dim val1 As Double
        If Not IsNumeric(txtServiceAmount.Text) Then txtServiceAmount.Text = 0
        val1 = txtServiceAmount.Text
        If appCompanyInfo.VATPercentage > 0 Then txtTotalVAT.Text = ((txtServiceAmount.Text * appCompanyInfo.VATPercentage) / 100)
    End Sub

    Private Sub lnkVATCalculation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkVATCalculation.LinkClicked
        '   lnkVATCalculation_Click(sender, e)
    End Sub
End Class