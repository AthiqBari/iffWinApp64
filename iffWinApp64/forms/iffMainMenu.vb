Imports System.Windows.Forms
Public Class iffMainMenu

    Private Sub iffMainMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Call checkRights()
        Me.Text = "IFF Billing  - " & appCompanyInfo.companyName & " " & appCompanyInfo.branchName & " - " & appUserInfo.Name
    End Sub

    'Public clsCompany As New clsCompanyAndBranch()

    Private Sub iffMainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If MsgBox("Close Application?", vbExclamation + vbYesNo, "Close App") = MsgBoxResult.No Then
            e.Cancel = True
        Else
            End
        End If ' Call method to save file...
    End Sub


    Private Sub iffMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctl As Control
        Dim ctlMDI As MdiClient

        ' Loop through all of the form's controls looking
        ' for the control of type MdiClient.
        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)
                ' Set the BackColor of the MdiClient control.
                ctlMDI.BackColor = Me.BackColor

                ToolStripStatusLabel1.Text = "Remote Server:[" & RemoteServerAddress & "]"

                'ToolStripStatusLabel3.Text = "Local Server:[" & appLocalServer & "]"

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next
    End Sub
    Private Sub OrganizationDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrganizationDataToolStripMenuItem.Click
        Dim frm As New frmOrganizationData()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ChargeCodesSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChargeCodesSetupToolStripMenuItem.Click
        Dim frm As New frmChargeCodeMaster()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If MsgBox("Are you sure you want to log out?", vbInformation + MsgBoxStyle.YesNo, "Log Off Request") = MsgBoxResult.Yes Then
            Me.Hide()
            'Me.Close()
            frmLogin.Show()
            frmLogin.Focus()
        End If
    End Sub

    Private Sub CloseApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseApplicationToolStripMenuItem.Click
        If MsgBox("Are you sure you want to quit?", vbInformation + MsgBoxStyle.YesNo, "Quit Request") = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub ClientInvoiceARBillToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frm As New frmBilling()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub EDocsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EDocsToolStripMenuItem.Click
        'MsgBox("Form Not Linked", vbExclamation, EDocsToolStripMenuItem.Text)

        'Dim clog As New clsLogFile
        'Call clog.logMessage("C:\atq.projects\iffWinApp64\iffWinApp64\bin\Debug\recentinvoices.txt", "SJED7SI005232")


    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click
        Dim frm As New frmReports()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub TAXInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TAXInvoiceToolStripMenuItem.Click
        Dim frm As New frmBilling()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuotationPrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuotationPrintToolStripMenuItem.Click
        Dim frm As New frmQuotationPrint()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ShipmentAndWaybillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShipmentAndWaybillToolStripMenuItem.Click
        Dim frm As New frmJobAndWaybill()
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub ManageRatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageRatesToolStripMenuItem.Click
        Dim frm As New frmRates()
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub ITRPostToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITRPostToolStripMenuItem.Click
        Dim frm As New frmITRPost(0)
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub checkRights()
        If Not appUserInfo.isAdmin Then 'skip for admin

            SetupUsersToolStripMenuItem.Enabled = appUserInfo.isAdmin
            LandTransportToolStripMenuItem.Enabled = appUserRights.landModule64
            ManageRatesToolStripMenuItem.Enabled = appUserRights.landRatesForm
            ITRPostToolStripMenuItem.Enabled = appUserRights.landITRPost
            SetupMasterFilesToolStripMenuItem.Enabled = appUserRights.landSetupMasterFiles
            BillingDataToolStripMenuItem.Enabled = appUserRights.iffVATBilling
        Else
            SetupUsersToolStripMenuItem.Enabled = appUserInfo.isAdmin
            LandTransportToolStripMenuItem.Enabled = appUserInfo.isAdmin
            ManageRatesToolStripMenuItem.Enabled = appUserInfo.isAdmin
            ITRPostToolStripMenuItem.Enabled = appUserInfo.isAdmin
            SetupMasterFilesToolStripMenuItem.Enabled = appUserInfo.isAdmin
            BillingDataToolStripMenuItem.Enabled = appUserInfo.isAdmin
        End If
    End Sub

    Private Sub SetupUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetupUsersToolStripMenuItem.Click
        Dim frm As New frmUserRights
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub EquipmentGroupToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EquipmentDetailToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DriverMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DriverMasterToolStripMenuItem.Click
        Dim frm As New frmDrivers
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    

    Private Sub ReportsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem1.Click
        Dim frm As New frmTransportReports
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub SetupLocationAreaWithinCitiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetupLocationAreaWithinCitiesToolStripMenuItem.Click
        Dim frm As New frmlocationmaster
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub ManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem.Click
        Dim frm As New frmUnlocoForm
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub SetupGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetupGroupToolStripMenuItem.Click
        Dim frm As New frmEqpGroup
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub ManageEquipmentDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageEquipmentDataToolStripMenuItem.Click
        Dim frm As New frmequipment
        frm.MdiParent = Me
        frm.Show()
        frm.Focus()
    End Sub

End Class
