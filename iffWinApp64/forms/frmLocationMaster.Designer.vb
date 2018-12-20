<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmlocationmaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmlocationmaster))
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnAddNewRequest = New System.Windows.Forms.Button()
        Me.lblItemCodeName = New System.Windows.Forms.Label()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUnLoco = New System.Windows.Forms.Label()
        Me.cmbCity = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbGroup = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.txtBranchID = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtName = New Telerik.WinControls.UI.RadTextBox()
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.radSBar1 = New Telerik.WinControls.UI.RadLabelElement()
        Me.CommandBarSeparator1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.radSBar2 = New Telerik.WinControls.UI.RadLabelElement()
        Me.CommandBarSeparator2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.radSBar3 = New Telerik.WinControls.UI.RadLabelElement()
        Me.Panel2.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmbCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCity.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCity.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGroup.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGroup.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadStatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.btnAddNewRequest)
        Me.Panel2.Controls.Add(Me.lblItemCodeName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(807, 58)
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
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(752, 6)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(48, 46)
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
        Me.btnAddNewRequest.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewRequest.ForeColor = System.Drawing.Color.White
        Me.btnAddNewRequest.Image = CType(resources.GetObject("btnAddNewRequest.Image"), System.Drawing.Image)
        Me.btnAddNewRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddNewRequest.Location = New System.Drawing.Point(708, 10)
        Me.btnAddNewRequest.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnAddNewRequest.Name = "btnAddNewRequest"
        Me.btnAddNewRequest.Size = New System.Drawing.Size(38, 42)
        Me.btnAddNewRequest.TabIndex = 1458
        Me.btnAddNewRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddNewRequest.UseVisualStyleBackColor = False
        '
        'lblItemCodeName
        '
        Me.lblItemCodeName.AutoSize = True
        Me.lblItemCodeName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCodeName.ForeColor = System.Drawing.Color.White
        Me.lblItemCodeName.Location = New System.Drawing.Point(12, 13)
        Me.lblItemCodeName.Name = "lblItemCodeName"
        Me.lblItemCodeName.Size = New System.Drawing.Size(162, 17)
        Me.lblItemCodeName.TabIndex = 42
        Me.lblItemCodeName.Text = "Setup Address Location"
        Me.lblItemCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPage1)
        Me.TabControlMain.Controls.Add(Me.TabPage2)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControlMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.Location = New System.Drawing.Point(0, 58)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(807, 463)
        Me.TabControlMain.TabIndex = 66
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(799, 433)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Form View"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblUnLoco)
        Me.Panel1.Controls.Add(Me.cmbCity)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cmbGroup)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.chkIsActive)
        Me.Panel1.Controls.Add(Me.txtBranchID)
        Me.Panel1.Controls.Add(Me.lblMessage)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 425)
        Me.Panel1.TabIndex = 1
        '
        'lblUnLoco
        '
        Me.lblUnLoco.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnLoco.Location = New System.Drawing.Point(482, 80)
        Me.lblUnLoco.Name = "lblUnLoco"
        Me.lblUnLoco.Size = New System.Drawing.Size(176, 24)
        Me.lblUnLoco.TabIndex = 7121
        Me.lblUnLoco.Text = "<unloco>"
        Me.lblUnLoco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCity
        '
        Me.cmbCity.AutoSize = True
        Me.cmbCity.BackColor = System.Drawing.Color.GhostWhite
        '
        'cmbCity.NestedRadGridView
        '
        Me.cmbCity.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCity.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCity.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbCity.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbCity.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbCity.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbCity.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbCity.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbCity.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbCity.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.cmbCity.EditorControl.Name = "NestedRadGridView"
        Me.cmbCity.EditorControl.ReadOnly = True
        Me.cmbCity.EditorControl.ShowGroupPanel = False
        Me.cmbCity.EditorControl.Size = New System.Drawing.Size(300, 187)
        Me.cmbCity.EditorControl.TabIndex = 0
        Me.cmbCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCity.Location = New System.Drawing.Point(237, 81)
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Size = New System.Drawing.Size(239, 23)
        Me.cmbCity.TabIndex = 2
        Me.cmbCity.TabStop = False
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(55, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(176, 24)
        Me.Label10.TabIndex = 7120
        Me.Label10.Text = "City:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbGroup
        '
        Me.cmbGroup.AutoSize = True
        Me.cmbGroup.BackColor = System.Drawing.Color.GhostWhite
        '
        'cmbGroup.NestedRadGridView
        '
        Me.cmbGroup.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGroup.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGroup.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbGroup.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbGroup.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbGroup.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbGroup.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbGroup.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbGroup.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbGroup.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.cmbGroup.EditorControl.Name = "NestedRadGridView"
        Me.cmbGroup.EditorControl.ReadOnly = True
        Me.cmbGroup.EditorControl.ShowGroupPanel = False
        Me.cmbGroup.EditorControl.Size = New System.Drawing.Size(300, 187)
        Me.cmbGroup.EditorControl.TabIndex = 0
        Me.cmbGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGroup.Location = New System.Drawing.Point(237, 58)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.Size = New System.Drawing.Size(239, 23)
        Me.cmbGroup.TabIndex = 1
        Me.cmbGroup.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(108, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 17)
        Me.Label3.TabIndex = 7103
        Me.Label3.Text = "Enter Area Name:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkIsActive.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(237, 134)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(80, 21)
        Me.chkIsActive.TabIndex = 4
        Me.chkIsActive.Text = "IsActive"
        Me.chkIsActive.UseVisualStyleBackColor = False
        '
        'txtBranchID
        '
        Me.txtBranchID.AcceptsReturn = True
        Me.txtBranchID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchID.Location = New System.Drawing.Point(1065, 42)
        Me.txtBranchID.Name = "txtBranchID"
        Me.txtBranchID.ReadOnly = True
        Me.txtBranchID.Size = New System.Drawing.Size(39, 25)
        Me.txtBranchID.TabIndex = 1479
        Me.txtBranchID.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMessage.Location = New System.Drawing.Point(214, 396)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(185, 17)
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
        Me.btnSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(659, 332)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 61)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblID.Location = New System.Drawing.Point(5, 396)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(64, 17)
        Me.lblID.TabIndex = 84
        Me.lblID.Text = "1200943"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblID.Visible = False
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(237, 104)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(376, 23)
        Me.txtName.TabIndex = 3
        Me.txtName.Text = "3"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Select Country:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RadGridView2)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(799, 433)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "List View"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RadGridView2
        '
        Me.RadGridView2.BackColor = System.Drawing.SystemColors.Control
        Me.RadGridView2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadGridView2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView2.Location = New System.Drawing.Point(3, 103)
        '
        '
        '
        Me.RadGridView2.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView2.MasterTemplate.EnableGrouping = False
        Me.RadGridView2.MasterTemplate.ShowRowHeaderColumn = False
        Me.RadGridView2.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.RadGridView2.Name = "RadGridView2"
        Me.RadGridView2.ReadOnly = True
        Me.RadGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView2.Size = New System.Drawing.Size(790, 325)
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
        Me.Panel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(793, 101)
        Me.Panel3.TabIndex = 1
        '
        'chkPDF
        '
        Me.chkPDF.AutoSize = True
        Me.chkPDF.Enabled = False
        Me.chkPDF.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPDF.Location = New System.Drawing.Point(625, 73)
        Me.chkPDF.Name = "chkPDF"
        Me.chkPDF.Size = New System.Drawing.Size(122, 21)
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
        Me.BtnExportToExcel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportToExcel.ForeColor = System.Drawing.Color.White
        Me.BtnExportToExcel.Image = CType(resources.GetObject("BtnExportToExcel.Image"), System.Drawing.Image)
        Me.BtnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExportToExcel.Location = New System.Drawing.Point(681, 28)
        Me.BtnExportToExcel.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.BtnExportToExcel.Name = "BtnExportToExcel"
        Me.BtnExportToExcel.Size = New System.Drawing.Size(48, 46)
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
        Me.btnSubmit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSubmit.Location = New System.Drawing.Point(636, 28)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(39, 40)
        Me.btnSubmit.TabIndex = 19
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'lblToolTip
        '
        Me.lblToolTip.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToolTip.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblToolTip.Location = New System.Drawing.Point(21, 69)
        Me.lblToolTip.Name = "lblToolTip"
        Me.lblToolTip.Size = New System.Drawing.Size(487, 26)
        Me.lblToolTip.TabIndex = 17
        Me.lblToolTip.Text = ".."
        Me.lblToolTip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchBy.FormattingEnabled = True
        Me.cmbSearchBy.Items.AddRange(New Object() {"City", "UNLoco"})
        Me.cmbSearchBy.Location = New System.Drawing.Point(25, 36)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(349, 25)
        Me.cmbSearchBy.TabIndex = 13
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(21, 15)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(136, 20)
        Me.Label41.TabIndex = 12
        Me.Label41.Text = "Search By"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipmentNumberFind
        '
        Me.txtShipmentNumberFind.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtShipmentNumberFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumberFind.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipmentNumberFind.Location = New System.Drawing.Point(380, 36)
        Me.txtShipmentNumberFind.Name = "txtShipmentNumberFind"
        Me.txtShipmentNumberFind.Size = New System.Drawing.Size(250, 25)
        Me.txtShipmentNumberFind.TabIndex = 14
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.Controls.Add(Me.ProgressBar1)
        Me.RadStatusStrip1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadStatusStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.radSBar1, Me.CommandBarSeparator1, Me.radSBar2, Me.CommandBarSeparator2, Me.radSBar3})
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 518)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(807, 29)
        Me.RadStatusStrip1.TabIndex = 67
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(585, 5)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(195, 19)
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Visible = False
        '
        'radSBar1
        '
        Me.radSBar1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSBar1.Name = "radSBar1"
        Me.RadStatusStrip1.SetSpring(Me.radSBar1, False)
        Me.radSBar1.Text = "Created By"
        Me.radSBar1.TextWrap = True
        '
        'CommandBarSeparator1
        '
        Me.CommandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarSeparator1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommandBarSeparator1.Name = "CommandBarSeparator1"
        Me.RadStatusStrip1.SetSpring(Me.CommandBarSeparator1, False)
        Me.CommandBarSeparator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarSeparator1.VisibleInOverflowMenu = False
        '
        'radSBar2
        '
        Me.radSBar2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSBar2.Name = "radSBar2"
        Me.RadStatusStrip1.SetSpring(Me.radSBar2, False)
        Me.radSBar2.Text = "Updated By"
        Me.radSBar2.TextWrap = True
        '
        'CommandBarSeparator2
        '
        Me.CommandBarSeparator2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarSeparator2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommandBarSeparator2.Name = "CommandBarSeparator2"
        Me.RadStatusStrip1.SetSpring(Me.CommandBarSeparator2, False)
        Me.CommandBarSeparator2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarSeparator2.VisibleInOverflowMenu = False
        '
        'radSBar3
        '
        Me.radSBar3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSBar3.Name = "radSBar3"
        Me.RadStatusStrip1.SetSpring(Me.radSBar3, False)
        Me.radSBar3.Text = ""
        Me.radSBar3.TextWrap = True
        '
        'frmlocationmaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 547)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.Controls.Add(Me.TabControlMain)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmlocationmaster"
        Me.ShowIcon = False
        Me.Text = "Setup Address Location"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmbCity.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCity.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGroup.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGroup.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadStatusStrip1.ResumeLayout(False)
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
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtName As Telerik.WinControls.UI.RadTextBox
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
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkPDF As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents cmbGroup As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cmbCity As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblUnLoco As System.Windows.Forms.Label
End Class
