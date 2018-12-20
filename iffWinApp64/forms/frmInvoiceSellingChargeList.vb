Imports System.Data.SqlClient
Imports Telerik.WinControls.UI

'rate input 
Public Class frmInvoiceSellingChargeList
    Dim recid As Integer = 0
    Dim shortcode As String = ""
    Dim InvNo As Integer
    Dim ActNo As String
    Dim ActRecID As Integer
    Dim OrgRecID As Integer
    Dim ActNoStr As String
    Public Sub New(mRecID As Integer, mInvNo As Integer, mActNo As String, mOrgRecID As Integer, mActRecID As Integer, mActNoStr As String)
        ' This call is required by the designer.
        InitializeComponent()
        recid = mRecID
        InvNo = mInvNo
        ActNo = mActNo
        ActRecID = mActRecID
        OrgRecID = mOrgRecID
        ActNoStr = mActNoStr
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmInvoiceSellingChargeList_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call init()
        Call GetData()
        txtServiceAmount.Focus()
        lnkVATCalculation.Text = "Calculate VAT By " & appCompanyInfo.VATPercentage & "%"
        cmbChargeList.Visible = IIf(recid < 1, True, False)
        If recid < 1 Then Call refresh_chargecodes(cmbChargeList)

        lblFormTitle.Text = ActNoStr & " - " & InvNo
    End Sub

    Private Sub init()
        txtServiceAmount.Text = 0
        txtTotal.Text = 0
        txtTotalVAT.Text = 0
        txtAdditionalRoute.Clear()
        txtServiceCharge.Clear()
        lblMessage.Text = ""
        lnkLinked.Tag = 0
        shortcode = ""
    End Sub

    Private Sub GetData()
        Me.Cursor = Cursors.WaitCursor
        Try
            If recid < 1 Then Exit Sub
            Dim dstmp As New DataSet
            sql_String = "select c.name, c.shortname,  b.elementid, sellamtlocal, sellvatamount, (sellamtlocal+sellvatamount) [total], sellrefno,b.linkedtowaybills [linked] from billing b inner join chargeElements c on b.elementid=c.recid"
            sql_String += " where b.recid=" & recid

            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                With dstmp.Tables(0).Rows(0)
                    cmbChargeList.Text = .Item("name")
                    shortcode = .Item("shortname")
                    cmbChargeList.Tag = .Item("elementid")
                    txtServiceCharge.Text = .Item("name")
                    txtServiceAmount.Text = .Item("sellamtlocal")
                    txtTotalVAT.Text = .Item("sellvatamount")
                    txtTotal.Text = .Item("Total")
                    txtAdditionalRoute.Text = .Item("sellrefno")
                    cmbChargeList.Visible = False

                    If .Item("linked") Then
                        lnkLinked.Visible = True
                        lnkLinked.Tag = 1
                        txtServiceAmount.ReadOnly = True
                        txtTotalVAT.ReadOnly = True
                        txtTotalVAT.BackColor = Color.Azure
                        txtServiceAmount.BackColor = Color.Azure
                    End If

                    txtServiceAmount.Focus()
                    txtServiceAmount.SelectAll()
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


            If recid = 0 Then
                sql_String = " Insert into [billing] (actRecID,actNo,branchID,slno,elementID,elementSName,elementName,sellCurr,orgIsReceivableAccountRecID,createdBy,"
                sql_String += " sellInvoiceNo,sellInvoiceNoForCost,sellamtlocal,sellvatamount,sellrefno)"
                sql_String += " Values(" & ActRecID & ",'" & ActNo & "'," & appCompanyInfo.branchID & ",0," & cmbChargeList.Tag & ",'" & shortcode & "',"
                sql_String += " '" & Replace(cmbChargeList.Text, "'", "") & "','SAR'," & OrgRecID & ",'" & appUserInfo.Name & "'," & InvNo & "," & InvNo & ","
                sql_String += txtServiceAmount.Text & "," & txtTotalVAT.Text & ",'" & txtAdditionalRoute.Text & "');"
                ' MsgBox(sql_String)
                sqlcmd.CommandText = sql_String
                sqlcmd.ExecuteNonQuery()
            Else
                sql_String = "update [billing] set "
                If lnkLinked.Tag = 0 Then
                    sql_String += "sellamtlocal=" & txtServiceAmount.Text
                    sql_String += ",sellvatamount=" & txtTotalVAT.Text
                    If txtTotalVAT.Text > 0 Then sql_String += ",sellVATPercentage=" & appCompanyInfo.VATPercentage & ","
                End If
                sql_String += "sellrefno=N'" & Replace(txtAdditionalRoute.Text, "'", "") & "'"
                sql_String += " where recid=" & recid
                sqlcmd.CommandText = sql_String
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


    Private Sub refresh_chargecodes(cmbName As Object)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name,  shortname [Code], recid from [chargeElements] where block=0 order by shortname;"
        Call fillCombo(cmbName, sql_String, 0, 0, 100, 50)
        cmbChargeList.Columns(2).IsVisible = False
        cmbName.Tag = 0 : cmbName.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lnkVATCalculation_Click(sender As Object, e As EventArgs) Handles lnkVATCalculation.Click
        Dim val1 As Double
        If Not IsNumeric(txtServiceAmount.Text) Then txtServiceAmount.Text = 0
        val1 = txtServiceAmount.Text
        If appCompanyInfo.VATPercentage > 0 Then txtTotalVAT.Text = ((txtServiceAmount.Text * appCompanyInfo.VATPercentage) / 100)
    End Sub

    Private Sub lnkSellingRate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSellingRate.LinkClicked
        '        If shortcode = "TRK" Then lblMessage.Text = "Default Charge Code cannot be removed" : Return
        'atleast one item is required
        If recid = 0 Then Return
        Dim dstmp As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            sql_String = "select count(recid) ctr from billing where actrecid=" & ActRecID & " and sellinvoiceno=" & InvNo
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                If dstmp.Tables(0).Rows(0).Item("ctr") > 1 Then
                    If MsgBox("Selected Service Charge will be Removed from Invoice. Proceed ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Remove Charge Code") = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Return

                    If lnkLinked.Tag = 1 Then
                        If MsgBox("Alert! Some Transport Bills has posted to this Charge Item" & vbCrLf & "Removing Item will DeLink Transport Bills. Continue with this Operation ?", vbExclamation + MsgBoxStyle.YesNo, "Remove Charge Item") = MsgBoxResult.No Then Return
                    End If

                    sql_String = "delete from [billing] where recid=" & recid
                    Dim commandy As New SqlCommand(sql_String, sql_CNN)
                    commandy.ExecuteNonQuery()
                    sql_String = "update [waybills] set wbpost=0,wbstatus='NOT-BILLED',invno=0,billingRecID=0 where billingRecID=" & recid
                    Dim commandz As New SqlCommand(sql_String, sql_CNN)
                    commandz.ExecuteNonQuery()
                    Me.Close()

                Else
                    lblMessage.Text = "Cannot Remove, Atleast One Item is required in Invoice"
                End If
            Else
                lblMessage.Text = "Cannot Remove, Atleast One Item is required in Invoice"
            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cmbChargeList_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbChargeList.KeyDown
        If e.KeyCode = Keys.Tab Then txtServiceAmount.Focus()
    End Sub
    Private Sub cmbChargeList_LostFocus(sender As Object, e As EventArgs) Handles cmbChargeList.LostFocus
        If cmbChargeList.SelectedValue <> "" Then
            cmbChargeList.Tag = 0 : shortcode = ""
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbChargeList.SelectedItem, GridViewDataRowInfo)
            cmbChargeList.Tag = (selectedRow.Cells("recid").Value.ToString())
            shortcode = (selectedRow.Cells("code").Value.ToString())
        End If
    End Sub
End Class