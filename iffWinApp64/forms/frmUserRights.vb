
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient

Public Class frmUserRights
    Dim recID As Integer = 0

    Private Sub frmUserRights_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call init()
        Call refresh_eqpGroup(cmbUser, "")
    End Sub

    Private Sub refresh_eqpGroup(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select u.userid code, u.name [Name], b.brcode, b.name Branch, u.createdOn,case u.status when 1 then 'Active' else 'Blocked' end [status], u.isadmin,u.recid [recidx] from users u inner join branch b on u.branchID=b.recID order by b.brcode"
        Call fillCombo(cmbUser, sql_String, 500, 0, 100, 200)
        cmbObj.Columns("recidx").VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbUser_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call cmbUser_LostFocus(sender, e)
        End If
    End Sub

    Private Sub cmbUser_LostFocus(sender As Object, e As EventArgs) Handles cmbUser.LostFocus
        Call init()
        If String.IsNullOrEmpty(cmbUser.Text) Then Exit Sub
        If cmbUser.SelectedValue <> "" Then
            cmbUser.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbUser.SelectedItem, GridViewDataRowInfo)
            recID = (selectedRow.Cells("recidx").Value)
            lblIsAdmin.Visible = (selectedRow.Cells("isadmin").Value)
            cmbUser.Tag = recID
            txtCode.Text = (selectedRow.Cells("code").Value.ToString())
            txtname.Text = (selectedRow.Cells("name").Value.ToString())
            txtbranch.Text = (selectedRow.Cells("branch").Value.ToString())
            txtcreated.Text = (selectedRow.Cells("createdon").Value.ToString())
            txtstat.Text = (selectedRow.Cells("status").Value.ToString())
            chkIsActive.Checked = IIf(selectedRow.Cells("status").Value = "Active", True, False)
            lblBlocked.Visible = chkIsActive.Checked
            Call getRights()
        End If
    End Sub

    Private Sub init()
        lblMessage.Text = "Save Request"
        lblIsAdmin.Visible = False
        lblBlocked.Visible = False
        recID = 0
        cmbUser.Tag = 0
        txtbranch.Clear()
        txtCode.Clear()
        txtname.Clear()
        txtcreated.Clear()
        txtstat.Clear()
        chkIsActive.Checked = False

        chkBill.Checked = False
        chkSetupForm.Checked = False
        chkLandTransport.Checked = False
        chkShipment.Checked = False
        chkGenerateWaybills.Checked = False
        chkUpdateWaybill.Checked = False
        chkTransportBillingITR.Checked = False
        chkAllowToChangeITRRate.Checked = False
        chkBillingSummary.Checked = False
        chkReportTab.Checked = False
        chkManageRates.Checked = False
        chkITRPost.Checked = False

    End Sub
    Private Sub saverights()
        Me.Cursor = Cursors.WaitCursor

        Try
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()

            sql_String = "update usersAccess set "
            sql_String += " billingform=" & IIf(chkBill.Checked, 1, 0) & ","
            sql_String += " landSetupMasterFiles=" & IIf(chkSetupForm.Checked, 1, 0) & ","
            sql_String += " landModule64=" & IIf(chkLandTransport.Checked, 1, 0) & ","
            sql_String += " landGenerateWaybill=" & IIf(chkGenerateWaybills.Checked, 1, 0) & ","
            sql_String += " landUpdateWaybill=" & IIf(chkUpdateWaybill.Checked, 1, 0) & ","
            sql_String += " landbillAccess=" & IIf(chkTransportBillingITR.Checked, 1, 0) & ","
            sql_String += " landAllowToChangeITRRate=" & IIf(chkAllowToChangeITRRate.Checked, 1, 0) & ","
            sql_String += " landBillingTabAccess=" & IIf(chkBillingSummary.Checked, 1, 0) & ","
            sql_String += " landReportTab=" & IIf(chkReportTab.Checked, 1, 0) & ","
            sql_String += " landRatesForm=" & IIf(chkManageRates.Checked, 1, 0) & ","
            sql_String += " landITRPost=" & IIf(chkITRPost.Checked, 1, 0)
            sql_String += " where userid='" & txtCode.Text & "';"
            Dim commandy As New SqlCommand(sql_String, sql_CNN)
            commandy.ExecuteNonQuery()

            sql_String = "update users set status=" & IIf(chkIsActive.Checked, 0, 1) & " where recid=" & recID
            Dim commandz As New SqlCommand(sql_String, sql_CNN)
            commandz.ExecuteNonQuery()

            lblMessage.Text = "User Data Saved"

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Text = ex.Message
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub getRights()
        If String.IsNullOrEmpty(txtCode.Text) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim dstmp As New DataSet
            sql_String = " select * from usersAccess where userid='" & txtCode.Text & "';"
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                With dstmp.Tables(0).Rows(0)
                    chkBill.Checked = dstmp.Tables(0).Rows(0).Item("billingform")
                    chkSetupForm.Checked = dstmp.Tables(0).Rows(0).Item("landSetupMasterFiles")
                    chkLandTransport.Checked = dstmp.Tables(0).Rows(0).Item("landModule64")
                    '                    chkShipment.Checked = dstmp.Tables(0).Rows(0).Item("")
                    chkGenerateWaybills.Checked = dstmp.Tables(0).Rows(0).Item("landGenerateWaybill")
                    chkUpdateWaybill.Checked = dstmp.Tables(0).Rows(0).Item("landUpdateWaybill")
                    chkTransportBillingITR.Checked = dstmp.Tables(0).Rows(0).Item("landbillAccess")
                    chkAllowToChangeITRRate.Checked = dstmp.Tables(0).Rows(0).Item("landAllowToChangeITRRate")
                    chkBillingSummary.Checked = dstmp.Tables(0).Rows(0).Item("landBillingTabAccess")
                    chkReportTab.Checked = dstmp.Tables(0).Rows(0).Item("landReportTab")
                    chkManageRates.Checked = dstmp.Tables(0).Rows(0).Item("landRatesForm")
                    chkITRPost.Checked = dstmp.Tables(0).Rows(0).Item("landITRPost")
                End With
            End If

            sql_String = "select status from users where recid=" & recID
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                chkIsActive.Checked = Not dstmp.Tables(0).Rows(0).Item("status")
                lblBlocked.Visible = chkIsActive.Checked
            End If


        Catch ex As Exception
            lblMessage.Text = ex.Message
            Me.Cursor = Cursors.Default

        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cmbUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUser.SelectedIndexChanged
        '   Call cmbUser_LostFocus(sender, e)
    End Sub

    Private Sub btnOkVendor_Click(sender As Object, e As EventArgs) Handles btnOkVendor.Click
        Call saverights()
    End Sub

    Private Sub chkIsActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsActive.CheckedChanged
        lblBlocked.Visible = chkIsActive.Checked
    End Sub

    Private Sub chkIsActive_Click(sender As Object, e As EventArgs) Handles chkIsActive.Click
        lblBlocked.Visible = chkIsActive.Checked
    End Sub
End Class