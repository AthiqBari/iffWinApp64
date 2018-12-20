<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChargeCodeMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChargeCodeMaster))
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnAddNewRequest = New System.Windows.Forms.Button()
        Me.lblItemCodeName = New System.Windows.Forms.Label()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkVAT = New System.Windows.Forms.CheckBox()
        Me.txtBranch = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNameAR = New Telerik.WinControls.UI.RadTextBox()
        Me.txtBranchID = New System.Windows.Forms.TextBox()
        Me.txtType = New Telerik.WinControls.UI.RadTextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVATRegNo = New Telerik.WinControls.UI.RadTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNameEN = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RadGridView2 = New Telerik.WinControls.UI.RadGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkPDF = New System.Windows.Forms.CheckBox()
        Me.BtnExportToExcel = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblToolTip = New System.Windows.Forms.Label()
        Me.cmbSearchBy = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtShipmentNumberFind = New System.Windows.Forms.TextBox()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.radSBar1 = New Telerik.WinControls.UI.RadLabelElement()
        Me.CommandBarSeparator1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.radSBar2 = New Telerik.WinControls.UI.RadLabelElement()
        Me.CommandBarSeparator2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.radSBar3 = New Telerik.WinControls.UI.RadLabelElement()
        Me.Panel2.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNameAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVATRegNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNameEN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.btnAddNewRequest)
        Me.Panel2.Controls.Add(Me.lblItemCodeName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(960, 55)
        Me.Panel2.TabIndex = 65
        '
        'btnPrint
        '
        Me.btnPrint.AutoSize = True
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(884, 5)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(48, 43)
        Me.btnPrint.TabIndex = 1459
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = False
        Me.btnPrint.Visible = False
        '
        'btnAddNewRequest
        '
        Me.btnAddNewRequest.AutoSize = True
        Me.btnAddNewRequest.BackColor = System.Drawing.Color.Transparent
        Me.btnAddNewRequest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAddNewRequest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNewRequest.FlatAppearance.BorderSize = 0
        Me.btnAddNewRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddNewRequest.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewRequest.ForeColor = System.Drawing.Color.White
        Me.btnAddNewRequest.Image = CType(resources.GetObject("btnAddNewRequest.Image"), System.Drawing.Image)
        Me.btnAddNewRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddNewRequest.Location = New System.Drawing.Point(840, 6)
        Me.btnAddNewRequest.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnAddNewRequest.Name = "btnAddNewRequest"
        Me.btnAddNewRequest.Size = New System.Drawing.Size(38, 40)
        Me.btnAddNewRequest.TabIndex = 1458
        Me.btnAddNewRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddNewRequest.UseVisualStyleBackColor = False
        Me.btnAddNewRequest.Visible = False
        '
        'lblItemCodeName
        '
        Me.lblItemCodeName.AutoSize = True
        Me.lblItemCodeName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCodeName.ForeColor = System.Drawing.Color.White
        Me.lblItemCodeName.Location = New System.Drawing.Point(67, 22)
        Me.lblItemCodeName.Name = "lblItemCodeName"
        Me.lblItemCodeName.Size = New System.Drawing.Size(137, 20)
        Me.lblItemCodeName.TabIndex = 42
        Me.lblItemCodeName.Text = "Charge Code Setup"
        Me.lblItemCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPage1)
        Me.TabControlMain.Controls.Add(Me.TabPage2)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControlMain.Location = New System.Drawing.Point(0, 55)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(960, 614)
        Me.TabControlMain.TabIndex = 66
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(952, 585)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Form View"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkVAT)
        Me.Panel1.Controls.Add(Me.txtBranch)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtNameAR)
        Me.Panel1.Controls.Add(Me.txtBranchID)
        Me.Panel1.Controls.Add(Me.txtType)
        Me.Panel1.Controls.Add(Me.lblMessage)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtVATRegNo)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtNameEN)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(946, 222)
        Me.Panel1.TabIndex = 1
        '
        'chkVAT
        '
        Me.chkVAT.AutoSize = True
        Me.chkVAT.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkVAT.Location = New System.Drawing.Point(712, 76)
        Me.chkVAT.Name = "chkVAT"
        Me.chkVAT.Size = New System.Drawing.Size(126, 21)
        Me.chkVAT.TabIndex = 7102
        Me.chkVAT.Text = "VAT Applicable"
        Me.chkVAT.UseVisualStyleBackColor = False
        '
        'txtBranch
        '
        Me.txtBranch.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBranch.Font = New System.Drawing.Font("Segoe UI", 11.8!)
        Me.txtBranch.Location = New System.Drawing.Point(712, 33)
        Me.txtBranch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBranch.MaxLength = 19
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.ReadOnly = True
        Me.txtBranch.Size = New System.Drawing.Size(165, 32)
        Me.txtBranch.TabIndex = 1482
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(615, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 23)
        Me.Label1.TabIndex = 1481
        Me.Label1.Text = "Status:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNameAR
        '
        Me.txtNameAR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNameAR.Font = New System.Drawing.Font("Segoe UI", 11.8!)
        Me.txtNameAR.Location = New System.Drawing.Point(181, 65)
        Me.txtNameAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNameAR.MaxLength = 180
        Me.txtNameAR.Name = "txtNameAR"
        Me.txtNameAR.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNameAR.Size = New System.Drawing.Size(407, 32)
        Me.txtNameAR.TabIndex = 2
        '
        'txtBranchID
        '
        Me.txtBranchID.AcceptsReturn = True
        Me.txtBranchID.Location = New System.Drawing.Point(1065, 40)
        Me.txtBranchID.Name = "txtBranchID"
        Me.txtBranchID.ReadOnly = True
        Me.txtBranchID.Size = New System.Drawing.Size(39, 22)
        Me.txtBranchID.TabIndex = 1479
        Me.txtBranchID.Visible = False
        '
        'txtType
        '
        Me.txtType.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtType.Font = New System.Drawing.Font("Segoe UI", 11.8!)
        Me.txtType.Location = New System.Drawing.Point(181, 97)
        Me.txtType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtType.MaxLength = 19
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(165, 32)
        Me.txtType.TabIndex = 3
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMessage.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMessage.Location = New System.Drawing.Point(628, 183)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(175, 19)
        Me.lblMessage.TabIndex = 1457
        Me.lblMessage.Text = "Cannot Save.. Missing Item"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(823, 148)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 57)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblID.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblID.Location = New System.Drawing.Point(5, 200)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(65, 19)
        Me.lblID.TabIndex = 84
        Me.lblID.Text = "1200943"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblID.Visible = False
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(5, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(175, 23)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Code:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVATRegNo
        '
        Me.txtVATRegNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVATRegNo.Font = New System.Drawing.Font("Segoe UI", 11.8!)
        Me.txtVATRegNo.Location = New System.Drawing.Point(181, 148)
        Me.txtVATRegNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVATRegNo.MaxLength = 20
        Me.txtVATRegNo.Name = "txtVATRegNo"
        Me.txtVATRegNo.Size = New System.Drawing.Size(305, 32)
        Me.txtVATRegNo.TabIndex = 4
        Me.txtVATRegNo.Visible = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(5, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(175, 23)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "VAT Registration No.:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(5, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 23)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Name (Arabic):"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNameEN
        '
        Me.txtNameEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNameEN.Font = New System.Drawing.Font("Segoe UI", 11.8!)
        Me.txtNameEN.Location = New System.Drawing.Point(181, 33)
        Me.txtNameEN.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNameEN.MaxLength = 79
        Me.txtNameEN.Name = "txtNameEN"
        Me.txtNameEN.Size = New System.Drawing.Size(407, 32)
        Me.txtNameEN.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(5, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Name (English):"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RadGridView2)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(952, 585)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "List View"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RadGridView2
        '
        Me.RadGridView2.BackColor = System.Drawing.SystemColors.Control
        Me.RadGridView2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGridView2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadGridView2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView2.Location = New System.Drawing.Point(3, 115)
        '
        '
        '
        Me.RadGridView2.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView2.MasterTemplate.EnableGrouping = False
        Me.RadGridView2.MasterTemplate.ShowRowHeaderColumn = False
        Me.RadGridView2.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.RadGridView2.Name = "RadGridView2"
        Me.RadGridView2.ReadOnly = True
        Me.RadGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView2.Size = New System.Drawing.Size(946, 467)
        Me.RadGridView2.TabIndex = 3
        Me.RadGridView2.Text = "RadGridView2"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chkPDF)
        Me.Panel3.Controls.Add(Me.BtnExportToExcel)
        Me.Panel3.Controls.Add(Me.btnSubmit)
        Me.Panel3.Controls.Add(Me.lblToolTip)
        Me.Panel3.Controls.Add(Me.cmbSearchBy)
        Me.Panel3.Controls.Add(Me.Label41)
        Me.Panel3.Controls.Add(Me.txtShipmentNumberFind)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(946, 112)
        Me.Panel3.TabIndex = 1
        '
        'chkPDF
        '
        Me.chkPDF.AutoSize = True
        Me.chkPDF.Location = New System.Drawing.Point(755, 34)
        Me.chkPDF.Name = "chkPDF"
        Me.chkPDF.Size = New System.Drawing.Size(117, 21)
        Me.chkPDF.TabIndex = 1461
        Me.chkPDF.Text = "Export to PDF"
        Me.chkPDF.UseVisualStyleBackColor = True
        '
        'BtnExportToExcel
        '
        Me.BtnExportToExcel.AutoSize = True
        Me.BtnExportToExcel.BackColor = System.Drawing.Color.Transparent
        Me.BtnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnExportToExcel.FlatAppearance.BorderSize = 0
        Me.BtnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExportToExcel.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportToExcel.ForeColor = System.Drawing.Color.White
        Me.BtnExportToExcel.Image = CType(resources.GetObject("BtnExportToExcel.Image"), System.Drawing.Image)
        Me.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExportToExcel.Location = New System.Drawing.Point(681, 26)
        Me.BtnExportToExcel.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.BtnExportToExcel.Name = "BtnExportToExcel"
        Me.BtnExportToExcel.Size = New System.Drawing.Size(48, 43)
        Me.BtnExportToExcel.TabIndex = 1460
        Me.BtnExportToExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExportToExcel.UseVisualStyleBackColor = False
        '
        'btnSubmit
        '
        Me.btnSubmit.AutoSize = True
        Me.btnSubmit.BackColor = System.Drawing.Color.Transparent
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSubmit.Location = New System.Drawing.Point(636, 26)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(39, 38)
        Me.btnSubmit.TabIndex = 19
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'lblToolTip
        '
        Me.lblToolTip.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToolTip.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblToolTip.Location = New System.Drawing.Point(21, 65)
        Me.lblToolTip.Name = "lblToolTip"
        Me.lblToolTip.Size = New System.Drawing.Size(487, 24)
        Me.lblToolTip.TabIndex = 17
        Me.lblToolTip.Text = ".."
        Me.lblToolTip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchBy.FormattingEnabled = True
        Me.cmbSearchBy.Items.AddRange(New Object() {"Name"})
        Me.cmbSearchBy.Location = New System.Drawing.Point(25, 34)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(349, 28)
        Me.cmbSearchBy.TabIndex = 13
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(21, 14)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(136, 19)
        Me.Label41.TabIndex = 12
        Me.Label41.Text = "Search By"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipmentNumberFind
        '
        Me.txtShipmentNumberFind.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtShipmentNumberFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumberFind.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipmentNumberFind.Location = New System.Drawing.Point(380, 34)
        Me.txtShipmentNumberFind.Name = "txtShipmentNumberFind"
        Me.txtShipmentNumberFind.Size = New System.Drawing.Size(250, 27)
        Me.txtShipmentNumberFind.TabIndex = 14
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.radSBar1, Me.CommandBarSeparator1, Me.radSBar2, Me.CommandBarSeparator2, Me.radSBar3})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 665)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(960, 30)
        Me.RadStatusStrip1.TabIndex = 67
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        '
        'radSBar1
        '
        Me.radSBar1.Name = "radSBar1"
        Me.RadStatusStrip1.SetSpring(Me.radSBar1, False)
        Me.radSBar1.Text = "Created By"
        Me.radSBar1.TextWrap = True
        '
        'CommandBarSeparator1
        '
        Me.CommandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarSeparator1.Name = "CommandBarSeparator1"
        Me.RadStatusStrip1.SetSpring(Me.CommandBarSeparator1, False)
        Me.CommandBarSeparator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarSeparator1.VisibleInOverflowMenu = False
        '
        'radSBar2
        '
        Me.radSBar2.Name = "radSBar2"
        Me.RadStatusStrip1.SetSpring(Me.radSBar2, False)
        Me.radSBar2.Text = "Updated By"
        Me.radSBar2.TextWrap = True
        '
        'CommandBarSeparator2
        '
        Me.CommandBarSeparator2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarSeparator2.Name = "CommandBarSeparator2"
        Me.RadStatusStrip1.SetSpring(Me.CommandBarSeparator2, False)
        Me.CommandBarSeparator2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarSeparator2.VisibleInOverflowMenu = False
        '
        'radSBar3
        '
        Me.radSBar3.Name = "radSBar3"
        Me.RadStatusStrip1.SetSpring(Me.radSBar3, False)
        Me.radSBar3.Text = ""
        Me.radSBar3.TextWrap = True
        '
        'frmChargeCodeMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 695)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.Controls.Add(Me.TabControlMain)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmChargeCodeMaster"
        Me.ShowIcon = False
        Me.Text = "Charge Code Setup"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtBranch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNameAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVATRegNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNameEN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnAddNewRequest As System.Windows.Forms.Button
    Friend WithEvents lblItemCodeName As System.Windows.Forms.Label
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtBranchID As System.Windows.Forms.TextBox
    Friend WithEvents txtType As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVATRegNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNameEN As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents RadGridView2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnExportToExcel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblToolTip As System.Windows.Forms.Label
    Friend WithEvents cmbSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtShipmentNumberFind As System.Windows.Forms.TextBox
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents radSBar1 As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents CommandBarSeparator1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents radSBar2 As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents CommandBarSeparator2 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents radSBar3 As Telerik.WinControls.UI.RadLabelElement
    Friend WithEvents txtNameAR As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtBranch As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkPDF As System.Windows.Forms.CheckBox
    Friend WithEvents chkVAT As System.Windows.Forms.CheckBox
End Class
