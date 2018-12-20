<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iffMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(iffMainMenu))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SetupMasterFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrganizationDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChargeCodesSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetupUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DriverMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EquipmentVehiclesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageEquipmentDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupCitiesAndLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupLocationAreaWithinCitiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.BillingDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TAXInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EDocsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuotationPrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LandTransportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShipmentAndWaybillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageRatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestReportToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.ITRPostToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 840)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1406, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(107, 17)
        Me.ToolStripStatusLabel1.Text = "Remote Server:"
        '
        'SetupMasterFilesToolStripMenuItem
        '
        Me.SetupMasterFilesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrganizationDataToolStripMenuItem, Me.ToolStripSeparator1, Me.ChargeCodesSetupToolStripMenuItem, Me.ToolStripMenuItem1, Me.SetupUsersToolStripMenuItem, Me.ToolStripMenuItem2, Me.DriverMasterToolStripMenuItem, Me.EquipmentVehiclesToolStripMenuItem, Me.SetupCitiesAndLocationToolStripMenuItem})
        Me.SetupMasterFilesToolStripMenuItem.Name = "SetupMasterFilesToolStripMenuItem"
        Me.SetupMasterFilesToolStripMenuItem.Size = New System.Drawing.Size(156, 23)
        Me.SetupMasterFilesToolStripMenuItem.Text = "Setup Master Files"
        '
        'OrganizationDataToolStripMenuItem
        '
        Me.OrganizationDataToolStripMenuItem.Name = "OrganizationDataToolStripMenuItem"
        Me.OrganizationDataToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.OrganizationDataToolStripMenuItem.Text = "Organization Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(269, 6)
        '
        'ChargeCodesSetupToolStripMenuItem
        '
        Me.ChargeCodesSetupToolStripMenuItem.Name = "ChargeCodesSetupToolStripMenuItem"
        Me.ChargeCodesSetupToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.ChargeCodesSetupToolStripMenuItem.Text = "Charge Codes Setup"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(269, 6)
        '
        'SetupUsersToolStripMenuItem
        '
        Me.SetupUsersToolStripMenuItem.Name = "SetupUsersToolStripMenuItem"
        Me.SetupUsersToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.SetupUsersToolStripMenuItem.Text = "Manage User Rights"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(269, 6)
        '
        'DriverMasterToolStripMenuItem
        '
        Me.DriverMasterToolStripMenuItem.Name = "DriverMasterToolStripMenuItem"
        Me.DriverMasterToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.DriverMasterToolStripMenuItem.Text = "Driver Master"
        '
        'EquipmentVehiclesToolStripMenuItem
        '
        Me.EquipmentVehiclesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetupGroupToolStripMenuItem, Me.ManageEquipmentDataToolStripMenuItem})
        Me.EquipmentVehiclesToolStripMenuItem.Name = "EquipmentVehiclesToolStripMenuItem"
        Me.EquipmentVehiclesToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.EquipmentVehiclesToolStripMenuItem.Text = "Equipment - Vehicles"
        '
        'SetupGroupToolStripMenuItem
        '
        Me.SetupGroupToolStripMenuItem.Name = "SetupGroupToolStripMenuItem"
        Me.SetupGroupToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.SetupGroupToolStripMenuItem.Text = "Setup Group"
        '
        'ManageEquipmentDataToolStripMenuItem
        '
        Me.ManageEquipmentDataToolStripMenuItem.Name = "ManageEquipmentDataToolStripMenuItem"
        Me.ManageEquipmentDataToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.ManageEquipmentDataToolStripMenuItem.Text = "Manage Equipment Data"
        '
        'SetupCitiesAndLocationToolStripMenuItem
        '
        Me.SetupCitiesAndLocationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageToolStripMenuItem, Me.SetupLocationAreaWithinCitiesToolStripMenuItem})
        Me.SetupCitiesAndLocationToolStripMenuItem.Name = "SetupCitiesAndLocationToolStripMenuItem"
        Me.SetupCitiesAndLocationToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.SetupCitiesAndLocationToolStripMenuItem.Text = "Setup Cities And Location"
        '
        'ManageToolStripMenuItem
        '
        Me.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem"
        Me.ManageToolStripMenuItem.Size = New System.Drawing.Size(331, 26)
        Me.ManageToolStripMenuItem.Text = "Manage Cities UN/LOCODE"
        '
        'SetupLocationAreaWithinCitiesToolStripMenuItem
        '
        Me.SetupLocationAreaWithinCitiesToolStripMenuItem.Name = "SetupLocationAreaWithinCitiesToolStripMenuItem"
        Me.SetupLocationAreaWithinCitiesToolStripMenuItem.Size = New System.Drawing.Size(331, 26)
        Me.SetupLocationAreaWithinCitiesToolStripMenuItem.Text = "Setup Location/Area Within Cities"
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetupMasterFilesToolStripMenuItem, Me.BillingDataToolStripMenuItem, Me.EDocsToolStripMenuItem, Me.LandTransportToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1406, 27)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'BillingDataToolStripMenuItem
        '
        Me.BillingDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TAXInvoiceToolStripMenuItem, Me.ReportsToolStripMenuItem})
        Me.BillingDataToolStripMenuItem.Name = "BillingDataToolStripMenuItem"
        Me.BillingDataToolStripMenuItem.Size = New System.Drawing.Size(64, 23)
        Me.BillingDataToolStripMenuItem.Text = "Billing"
        '
        'TAXInvoiceToolStripMenuItem
        '
        Me.TAXInvoiceToolStripMenuItem.Name = "TAXInvoiceToolStripMenuItem"
        Me.TAXInvoiceToolStripMenuItem.Size = New System.Drawing.Size(171, 26)
        Me.TAXInvoiceToolStripMenuItem.Text = "TAX Invoice"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(171, 26)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'EDocsToolStripMenuItem
        '
        Me.EDocsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuotationPrintToolStripMenuItem})
        Me.EDocsToolStripMenuItem.Name = "EDocsToolStripMenuItem"
        Me.EDocsToolStripMenuItem.Size = New System.Drawing.Size(68, 23)
        Me.EDocsToolStripMenuItem.Text = "eDocs"
        Me.EDocsToolStripMenuItem.Visible = False
        '
        'QuotationPrintToolStripMenuItem
        '
        Me.QuotationPrintToolStripMenuItem.Name = "QuotationPrintToolStripMenuItem"
        Me.QuotationPrintToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.QuotationPrintToolStripMenuItem.Text = "Quotation Print"
        '
        'LandTransportToolStripMenuItem
        '
        Me.LandTransportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShipmentAndWaybillToolStripMenuItem, Me.ManageRatesToolStripMenuItem, Me.TestReportToolStripMenuItem, Me.ITRPostToolStripMenuItem, Me.ReportsToolStripMenuItem1})
        Me.LandTransportToolStripMenuItem.Name = "LandTransportToolStripMenuItem"
        Me.LandTransportToolStripMenuItem.Size = New System.Drawing.Size(130, 23)
        Me.LandTransportToolStripMenuItem.Text = "Land Transport"
        '
        'ShipmentAndWaybillToolStripMenuItem
        '
        Me.ShipmentAndWaybillToolStripMenuItem.Name = "ShipmentAndWaybillToolStripMenuItem"
        Me.ShipmentAndWaybillToolStripMenuItem.Size = New System.Drawing.Size(243, 26)
        Me.ShipmentAndWaybillToolStripMenuItem.Text = "Shipment And Waybill"
        '
        'ManageRatesToolStripMenuItem
        '
        Me.ManageRatesToolStripMenuItem.Name = "ManageRatesToolStripMenuItem"
        Me.ManageRatesToolStripMenuItem.Size = New System.Drawing.Size(243, 26)
        Me.ManageRatesToolStripMenuItem.Text = "Manage Rates"
        '
        'TestReportToolStripMenuItem
        '
        Me.TestReportToolStripMenuItem.Name = "TestReportToolStripMenuItem"
        Me.TestReportToolStripMenuItem.Size = New System.Drawing.Size(240, 6)
        '
        'ITRPostToolStripMenuItem
        '
        Me.ITRPostToolStripMenuItem.Name = "ITRPostToolStripMenuItem"
        Me.ITRPostToolStripMenuItem.Size = New System.Drawing.Size(243, 26)
        Me.ITRPostToolStripMenuItem.Text = "ITR Post"
        '
        'ReportsToolStripMenuItem1
        '
        Me.ReportsToolStripMenuItem1.Name = "ReportsToolStripMenuItem1"
        Me.ReportsToolStripMenuItem1.Size = New System.Drawing.Size(243, 26)
        Me.ReportsToolStripMenuItem1.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem, Me.CloseApplicationToolStripMenuItem})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(47, 23)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'CloseApplicationToolStripMenuItem
        '
        Me.CloseApplicationToolStripMenuItem.Name = "CloseApplicationToolStripMenuItem"
        Me.CloseApplicationToolStripMenuItem.Size = New System.Drawing.Size(209, 26)
        Me.CloseApplicationToolStripMenuItem.Text = "Close Application"
        '
        'iffMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1406, 862)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "iffMainMenu"
        Me.Text = "IFF WinApp - ...."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents SetupMasterFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrganizationDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChargeCodesSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents BillingDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EDocsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseApplicationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TAXInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuotationPrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LandTransportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShipmentAndWaybillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageRatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestReportToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ITRPostToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SetupUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DriverMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ReportsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetupCitiesAndLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetupLocationAreaWithinCitiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EquipmentVehiclesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetupGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageEquipmentDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
