<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserRights
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserRights))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUser = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCode = New Telerik.WinControls.UI.RadTextBox()
        Me.txtname = New Telerik.WinControls.UI.RadTextBox()
        Me.txtstat = New Telerik.WinControls.UI.RadTextBox()
        Me.txtbranch = New Telerik.WinControls.UI.RadTextBox()
        Me.txtcreated = New Telerik.WinControls.UI.RadTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkBill = New System.Windows.Forms.CheckBox()
        Me.chkSetupForm = New System.Windows.Forms.CheckBox()
        Me.chkLandTransport = New System.Windows.Forms.CheckBox()
        Me.chkManageRates = New System.Windows.Forms.CheckBox()
        Me.chkITRPost = New System.Windows.Forms.CheckBox()
        Me.chkShipment = New System.Windows.Forms.CheckBox()
        Me.chkGenerateWaybills = New System.Windows.Forms.CheckBox()
        Me.chkUpdateWaybill = New System.Windows.Forms.CheckBox()
        Me.chkTransportBillingITR = New System.Windows.Forms.CheckBox()
        Me.chkAllowToChangeITRRate = New System.Windows.Forms.CheckBox()
        Me.btnOkVendor = New System.Windows.Forms.Button()
        Me.chkBillingSummary = New System.Windows.Forms.CheckBox()
        Me.chkReportTab = New System.Windows.Forms.CheckBox()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.lblIsAdmin = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblBlocked = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.cmbUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUser.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUser.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtstat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtbranch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcreated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Beige
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(566, 39)
        Me.Panel1.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(127, 17)
        Me.Label15.TabIndex = 2351
        Me.Label15.Text = "Setup User Rights"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 17)
        Me.Label1.TabIndex = 2352
        Me.Label1.Text = "Select User From List:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbUser
        '
        Me.cmbUser.AutoSize = True
        Me.cmbUser.BackColor = System.Drawing.Color.GhostWhite
        '
        'cmbUser.NestedRadGridView
        '
        Me.cmbUser.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUser.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUser.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbUser.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbUser.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbUser.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbUser.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbUser.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbUser.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbUser.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.cmbUser.EditorControl.Name = "NestedRadGridView"
        Me.cmbUser.EditorControl.ReadOnly = True
        Me.cmbUser.EditorControl.ShowGroupPanel = False
        Me.cmbUser.EditorControl.Size = New System.Drawing.Size(300, 187)
        Me.cmbUser.EditorControl.TabIndex = 0
        Me.cmbUser.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUser.Location = New System.Drawing.Point(201, 69)
        Me.cmbUser.Name = "cmbUser"
        Me.cmbUser.Size = New System.Drawing.Size(195, 23)
        Me.cmbUser.TabIndex = 2353
        Me.cmbUser.TabStop = False
        Me.cmbUser.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 18)
        Me.Label2.TabIndex = 2354
        Me.Label2.Text = "User Information"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(61, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 17)
        Me.Label3.TabIndex = 2355
        Me.Label3.Text = "Code:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 2356
        Me.Label4.Text = "Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(54, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 2357
        Me.Label5.Text = "Status:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(321, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 17)
        Me.Label6.TabIndex = 2358
        Me.Label6.Text = "Branch:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(292, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 17)
        Me.Label7.TabIndex = 2359
        Me.Label7.Text = "Created On:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.Azure
        Me.txtCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(119, 153)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(169, 23)
        Me.txtCode.TabIndex = 2
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.Azure
        Me.txtname.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(119, 177)
        Me.txtname.Name = "txtname"
        Me.txtname.ReadOnly = True
        Me.txtname.Size = New System.Drawing.Size(169, 23)
        Me.txtname.TabIndex = 3
        '
        'txtstat
        '
        Me.txtstat.BackColor = System.Drawing.Color.Azure
        Me.txtstat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstat.Location = New System.Drawing.Point(119, 201)
        Me.txtstat.Name = "txtstat"
        Me.txtstat.ReadOnly = True
        Me.txtstat.Size = New System.Drawing.Size(169, 23)
        Me.txtstat.TabIndex = 4
        '
        'txtbranch
        '
        Me.txtbranch.BackColor = System.Drawing.Color.Azure
        Me.txtbranch.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbranch.Location = New System.Drawing.Point(386, 153)
        Me.txtbranch.Name = "txtbranch"
        Me.txtbranch.ReadOnly = True
        Me.txtbranch.Size = New System.Drawing.Size(168, 23)
        Me.txtbranch.TabIndex = 5
        '
        'txtcreated
        '
        Me.txtcreated.BackColor = System.Drawing.Color.Azure
        Me.txtcreated.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcreated.Location = New System.Drawing.Point(386, 177)
        Me.txtcreated.Name = "txtcreated"
        Me.txtcreated.ReadOnly = True
        Me.txtcreated.Size = New System.Drawing.Size(168, 23)
        Me.txtcreated.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(39, 275)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 18)
        Me.Label8.TabIndex = 2365
        Me.Label8.Text = "Setup Access Rights"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkBill
        '
        Me.chkBill.AutoSize = True
        Me.chkBill.Location = New System.Drawing.Point(64, 296)
        Me.chkBill.Name = "chkBill"
        Me.chkBill.Size = New System.Drawing.Size(68, 21)
        Me.chkBill.TabIndex = 7
        Me.chkBill.Text = "Billing"
        Me.chkBill.UseVisualStyleBackColor = True
        '
        'chkSetupForm
        '
        Me.chkSetupForm.AutoSize = True
        Me.chkSetupForm.Location = New System.Drawing.Point(64, 317)
        Me.chkSetupForm.Name = "chkSetupForm"
        Me.chkSetupForm.Size = New System.Drawing.Size(116, 21)
        Me.chkSetupForm.TabIndex = 8
        Me.chkSetupForm.Text = "Setup Master"
        Me.chkSetupForm.UseVisualStyleBackColor = True
        '
        'chkLandTransport
        '
        Me.chkLandTransport.AutoSize = True
        Me.chkLandTransport.Location = New System.Drawing.Point(64, 338)
        Me.chkLandTransport.Name = "chkLandTransport"
        Me.chkLandTransport.Size = New System.Drawing.Size(128, 21)
        Me.chkLandTransport.TabIndex = 9
        Me.chkLandTransport.Text = "Land Transport"
        Me.chkLandTransport.UseVisualStyleBackColor = True
        '
        'chkManageRates
        '
        Me.chkManageRates.AutoSize = True
        Me.chkManageRates.Location = New System.Drawing.Point(64, 516)
        Me.chkManageRates.Name = "chkManageRates"
        Me.chkManageRates.Size = New System.Drawing.Size(124, 21)
        Me.chkManageRates.TabIndex = 15
        Me.chkManageRates.Text = "Manage Rates"
        Me.chkManageRates.UseVisualStyleBackColor = True
        '
        'chkITRPost
        '
        Me.chkITRPost.AutoSize = True
        Me.chkITRPost.Location = New System.Drawing.Point(64, 537)
        Me.chkITRPost.Name = "chkITRPost"
        Me.chkITRPost.Size = New System.Drawing.Size(87, 21)
        Me.chkITRPost.TabIndex = 16
        Me.chkITRPost.Text = "ITR Post"
        Me.chkITRPost.UseVisualStyleBackColor = True
        '
        'chkShipment
        '
        Me.chkShipment.AutoSize = True
        Me.chkShipment.Location = New System.Drawing.Point(85, 359)
        Me.chkShipment.Name = "chkShipment"
        Me.chkShipment.Size = New System.Drawing.Size(170, 21)
        Me.chkShipment.TabIndex = 10
        Me.chkShipment.Text = "Shipment And Waybill"
        Me.chkShipment.UseVisualStyleBackColor = True
        '
        'chkGenerateWaybills
        '
        Me.chkGenerateWaybills.AutoSize = True
        Me.chkGenerateWaybills.Location = New System.Drawing.Point(100, 380)
        Me.chkGenerateWaybills.Name = "chkGenerateWaybills"
        Me.chkGenerateWaybills.Size = New System.Drawing.Size(148, 21)
        Me.chkGenerateWaybills.TabIndex = 11
        Me.chkGenerateWaybills.Text = "Generate Waybills"
        Me.chkGenerateWaybills.UseVisualStyleBackColor = True
        '
        'chkUpdateWaybill
        '
        Me.chkUpdateWaybill.AutoSize = True
        Me.chkUpdateWaybill.Location = New System.Drawing.Point(100, 401)
        Me.chkUpdateWaybill.Name = "chkUpdateWaybill"
        Me.chkUpdateWaybill.Size = New System.Drawing.Size(126, 21)
        Me.chkUpdateWaybill.TabIndex = 12
        Me.chkUpdateWaybill.Text = "Update Waybill"
        Me.chkUpdateWaybill.UseVisualStyleBackColor = True
        '
        'chkTransportBillingITR
        '
        Me.chkTransportBillingITR.AutoSize = True
        Me.chkTransportBillingITR.Location = New System.Drawing.Point(100, 422)
        Me.chkTransportBillingITR.Name = "chkTransportBillingITR"
        Me.chkTransportBillingITR.Size = New System.Drawing.Size(231, 21)
        Me.chkTransportBillingITR.TabIndex = 13
        Me.chkTransportBillingITR.Text = "Transport Billing Payments ITR"
        Me.chkTransportBillingITR.UseVisualStyleBackColor = True
        '
        'chkAllowToChangeITRRate
        '
        Me.chkAllowToChangeITRRate.AutoSize = True
        Me.chkAllowToChangeITRRate.Location = New System.Drawing.Point(100, 443)
        Me.chkAllowToChangeITRRate.Name = "chkAllowToChangeITRRate"
        Me.chkAllowToChangeITRRate.Size = New System.Drawing.Size(194, 21)
        Me.chkAllowToChangeITRRate.TabIndex = 14
        Me.chkAllowToChangeITRRate.Text = "Allow to change ITR Rate"
        Me.chkAllowToChangeITRRate.UseVisualStyleBackColor = True
        '
        'btnOkVendor
        '
        Me.btnOkVendor.AutoSize = True
        Me.btnOkVendor.BackColor = System.Drawing.Color.Transparent
        Me.btnOkVendor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOkVendor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOkVendor.FlatAppearance.BorderSize = 0
        Me.btnOkVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOkVendor.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkVendor.ForeColor = System.Drawing.Color.Black
        Me.btnOkVendor.Image = CType(resources.GetObject("btnOkVendor.Image"), System.Drawing.Image)
        Me.btnOkVendor.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOkVendor.Location = New System.Drawing.Point(505, 474)
        Me.btnOkVendor.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnOkVendor.Name = "btnOkVendor"
        Me.btnOkVendor.Size = New System.Drawing.Size(38, 38)
        Me.btnOkVendor.TabIndex = 17
        Me.btnOkVendor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOkVendor.UseVisualStyleBackColor = False
        '
        'chkBillingSummary
        '
        Me.chkBillingSummary.AutoSize = True
        Me.chkBillingSummary.Location = New System.Drawing.Point(85, 470)
        Me.chkBillingSummary.Name = "chkBillingSummary"
        Me.chkBillingSummary.Size = New System.Drawing.Size(163, 21)
        Me.chkBillingSummary.TabIndex = 2366
        Me.chkBillingSummary.Text = "Billing Summary Tab"
        Me.chkBillingSummary.UseVisualStyleBackColor = True
        '
        'chkReportTab
        '
        Me.chkReportTab.AutoSize = True
        Me.chkReportTab.Location = New System.Drawing.Point(85, 491)
        Me.chkReportTab.Name = "chkReportTab"
        Me.chkReportTab.Size = New System.Drawing.Size(109, 21)
        Me.chkReportTab.TabIndex = 2367
        Me.chkReportTab.Text = "Reports Tab"
        Me.chkReportTab.UseVisualStyleBackColor = True
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Location = New System.Drawing.Point(386, 220)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(133, 21)
        Me.chkIsActive.TabIndex = 2368
        Me.chkIsActive.Text = "Block This User"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'lblIsAdmin
        '
        Me.lblIsAdmin.AutoSize = True
        Me.lblIsAdmin.BackColor = System.Drawing.Color.Red
        Me.lblIsAdmin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIsAdmin.ForeColor = System.Drawing.Color.White
        Me.lblIsAdmin.Location = New System.Drawing.Point(218, 275)
        Me.lblIsAdmin.Name = "lblIsAdmin"
        Me.lblIsAdmin.Size = New System.Drawing.Size(51, 18)
        Me.lblIsAdmin.TabIndex = 2369
        Me.lblIsAdmin.Text = "Admin"
        Me.lblIsAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIsAdmin.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.LightYellow
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMessage.Location = New System.Drawing.Point(0, 611)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(97, 16)
        Me.lblMessage.TabIndex = 2370
        Me.lblMessage.Text = "Save Request"
        '
        'lblBlocked
        '
        Me.lblBlocked.AutoSize = True
        Me.lblBlocked.BackColor = System.Drawing.Color.Red
        Me.lblBlocked.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlocked.ForeColor = System.Drawing.Color.White
        Me.lblBlocked.Location = New System.Drawing.Point(425, 68)
        Me.lblBlocked.Name = "lblBlocked"
        Me.lblBlocked.Size = New System.Drawing.Size(104, 18)
        Me.lblBlocked.TabIndex = 2371
        Me.lblBlocked.Text = "Blocked User"
        Me.lblBlocked.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBlocked.Visible = False
        '
        'frmUserRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 627)
        Me.Controls.Add(Me.lblBlocked)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblIsAdmin)
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.chkReportTab)
        Me.Controls.Add(Me.chkBillingSummary)
        Me.Controls.Add(Me.btnOkVendor)
        Me.Controls.Add(Me.chkAllowToChangeITRRate)
        Me.Controls.Add(Me.chkTransportBillingITR)
        Me.Controls.Add(Me.chkUpdateWaybill)
        Me.Controls.Add(Me.chkGenerateWaybills)
        Me.Controls.Add(Me.chkShipment)
        Me.Controls.Add(Me.chkITRPost)
        Me.Controls.Add(Me.chkManageRates)
        Me.Controls.Add(Me.chkLandTransport)
        Me.Controls.Add(Me.chkSetupForm)
        Me.Controls.Add(Me.chkBill)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtcreated)
        Me.Controls.Add(Me.txtbranch)
        Me.Controls.Add(Me.txtstat)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbUser)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmUserRights"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Manage User Rights Form"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmbUser.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUser.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtstat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtbranch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcreated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbUser As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtname As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtstat As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtbranch As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtcreated As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkBill As System.Windows.Forms.CheckBox
    Friend WithEvents chkSetupForm As System.Windows.Forms.CheckBox
    Friend WithEvents chkLandTransport As System.Windows.Forms.CheckBox
    Friend WithEvents chkManageRates As System.Windows.Forms.CheckBox
    Friend WithEvents chkITRPost As System.Windows.Forms.CheckBox
    Friend WithEvents chkShipment As System.Windows.Forms.CheckBox
    Friend WithEvents chkGenerateWaybills As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpdateWaybill As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransportBillingITR As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllowToChangeITRRate As System.Windows.Forms.CheckBox
    Friend WithEvents btnOkVendor As System.Windows.Forms.Button
    Friend WithEvents chkBillingSummary As System.Windows.Forms.CheckBox
    Friend WithEvents chkReportTab As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblIsAdmin As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblBlocked As System.Windows.Forms.Label
End Class
