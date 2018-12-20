<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRentalChargesITR
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRentalChargesITR))
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtAdvancePayment = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCreditorNameCompany = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtITRNumber = New Telerik.WinControls.UI.RadTextBox()
        Me.txtITRDate = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lnkVATCalculation = New System.Windows.Forms.LinkLabel()
        Me.txtVATCost = New Telerik.WinControls.UI.RadTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblListTariffRates = New System.Windows.Forms.LinkLabel()
        Me.DGridView = New System.Windows.Forms.DataGridView()
        Me.btnSaveEntry = New System.Windows.Forms.Button()
        Me.btnAddEntry = New System.Windows.Forms.Button()
        Me.txtChargeCode = New Telerik.WinControls.UI.RadTextBox()
        Me.txtChargeDesc = New Telerik.WinControls.UI.RadTextBox()
        Me.txtServiceAmount = New Telerik.WinControls.UI.RadTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbChargeList = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.panelVendorBuyingRate = New System.Windows.Forms.Panel()
        Me.txtVendorLineNote = New Telerik.WinControls.UI.RadTextBox()
        Me.txtVendorTotalRate = New Telerik.WinControls.UI.RadTextBox()
        Me.txtVendorAdditionalRate = New Telerik.WinControls.UI.RadTextBox()
        Me.txtVendorBaseRate = New Telerik.WinControls.UI.RadTextBox()
        Me.lblTotalRate = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnOkVendor = New System.Windows.Forms.Button()
        Me.lblVendorBuyingRate = New System.Windows.Forms.Label()
        Me.lblVendorEqpType = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblVendorName = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCargoDesc = New Telerik.WinControls.UI.RadTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEqpType = New Telerik.WinControls.UI.RadTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPOLPOD = New Telerik.WinControls.UI.RadTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEqpNo = New Telerik.WinControls.UI.RadTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtRefNo = New Telerik.WinControls.UI.RadTextBox()
        Me.txtRemarks = New Telerik.WinControls.UI.RadTextBox()
        Me.txtAccountRefNo = New Telerik.WinControls.UI.RadTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAmountToPay = New Telerik.WinControls.UI.RadTextBox()
        Me.btnSaveAnPrint = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRecordID = New System.Windows.Forms.Label()
        Me.lblUpdatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.PanelMessage = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.picCrossed = New System.Windows.Forms.PictureBox()
        Me.picChecked = New System.Windows.Forms.PictureBox()
        Me.lblPOLPOD = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalCharges = New Telerik.WinControls.UI.RadTextBox()
        Me.lblOriginLocation = New System.Windows.Forms.Label()
        Me.lblDestinationLocation = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTotalvAT = New Telerik.WinControls.UI.RadTextBox()
        Me.panelHeader.SuspendLayout()
        CType(Me.txtAdvancePayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreditorNameCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtITRNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtITRDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtVATCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChargeCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChargeDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServiceAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbChargeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbChargeList.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbChargeList.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelVendorBuyingRate.SuspendLayout()
        CType(Me.txtVendorLineNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorTotalRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorAdditionalRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorBaseRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCargoDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEqpType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOLPOD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEqpNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRefNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountRefNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmountToPay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelMessage.SuspendLayout()
        CType(Me.picCrossed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChecked, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalvAT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblFormTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(516, 32)
        Me.panelHeader.TabIndex = 69
        '
        'lblFormTitle
        '
        Me.lblFormTitle.AutoSize = True
        Me.lblFormTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormTitle.ForeColor = System.Drawing.Color.White
        Me.lblFormTitle.Location = New System.Drawing.Point(3, 9)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Size = New System.Drawing.Size(344, 18)
        Me.lblFormTitle.TabIndex = 42
        Me.lblFormTitle.Text = "SJED2001 - WB0015 - Delivered On [12-12-2018]"
        Me.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(12, 567)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(64, 17)
        Me.Label54.TabIndex = 2347
        Me.Label54.Text = "Advance"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(0, 64)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(120, 17)
        Me.Label68.TabIndex = 2348
        Me.Label68.Text = "Transporter (Cr.):"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAdvancePayment
        '
        Me.txtAdvancePayment.BackColor = System.Drawing.Color.Azure
        Me.txtAdvancePayment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdvancePayment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdvancePayment.Location = New System.Drawing.Point(12, 588)
        Me.txtAdvancePayment.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAdvancePayment.MaxLength = 11
        Me.txtAdvancePayment.Name = "txtAdvancePayment"
        Me.txtAdvancePayment.ReadOnly = True
        Me.txtAdvancePayment.Size = New System.Drawing.Size(102, 23)
        Me.txtAdvancePayment.TabIndex = 2345
        Me.txtAdvancePayment.Text = "4108.00"
        Me.txtAdvancePayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCreditorNameCompany
        '
        Me.txtCreditorNameCompany.BackColor = System.Drawing.Color.Azure
        Me.txtCreditorNameCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditorNameCompany.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtCreditorNameCompany.Location = New System.Drawing.Point(123, 64)
        Me.txtCreditorNameCompany.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCreditorNameCompany.MaxLength = 11
        Me.txtCreditorNameCompany.Name = "txtCreditorNameCompany"
        Me.txtCreditorNameCompany.ReadOnly = True
        Me.txtCreditorNameCompany.Size = New System.Drawing.Size(380, 24)
        Me.txtCreditorNameCompany.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtCreditorNameCompany, "Transporter / Driver")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 17)
        Me.Label1.TabIndex = 2350
        Me.Label1.Text = "ITR Number:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtITRNumber
        '
        Me.txtITRNumber.BackColor = System.Drawing.Color.Azure
        Me.txtITRNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtITRNumber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtITRNumber.Location = New System.Drawing.Point(123, 41)
        Me.txtITRNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtITRNumber.MaxLength = 11
        Me.txtITRNumber.Name = "txtITRNumber"
        Me.txtITRNumber.ReadOnly = True
        Me.txtITRNumber.Size = New System.Drawing.Size(90, 23)
        Me.txtITRNumber.TabIndex = 1
        Me.txtITRNumber.Text = "1501"
        '
        'txtITRDate
        '
        Me.txtITRDate.BackColor = System.Drawing.Color.Azure
        Me.txtITRDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtITRDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtITRDate.Location = New System.Drawing.Point(386, 41)
        Me.txtITRDate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtITRDate.MaxLength = 11
        Me.txtITRDate.Name = "txtITRDate"
        Me.txtITRDate.ReadOnly = True
        Me.txtITRDate.Size = New System.Drawing.Size(117, 23)
        Me.txtITRDate.TabIndex = 2
        Me.txtITRDate.Text = "DD/MM/YYYY"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(310, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 2352
        Me.Label2.Text = "ITR Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 262)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 18)
        Me.Label3.TabIndex = 2354
        Me.Label3.Text = "Service Charges"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.lnkVATCalculation)
        Me.GroupBox1.Controls.Add(Me.txtVATCost)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lblListTariffRates)
        Me.GroupBox1.Controls.Add(Me.DGridView)
        Me.GroupBox1.Controls.Add(Me.btnSaveEntry)
        Me.GroupBox1.Controls.Add(Me.btnAddEntry)
        Me.GroupBox1.Controls.Add(Me.txtChargeCode)
        Me.GroupBox1.Controls.Add(Me.txtChargeDesc)
        Me.GroupBox1.Controls.Add(Me.txtServiceAmount)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbChargeList)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 283)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 281)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Service Charges"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(107, 97)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 17)
        Me.Label19.TabIndex = 2422
        Me.Label19.Text = "Note:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkVATCalculation
        '
        Me.lnkVATCalculation.AutoSize = True
        Me.lnkVATCalculation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkVATCalculation.Location = New System.Drawing.Point(251, 74)
        Me.lnkVATCalculation.Name = "lnkVATCalculation"
        Me.lnkVATCalculation.Size = New System.Drawing.Size(123, 17)
        Me.lnkVATCalculation.TabIndex = 2421
        Me.lnkVATCalculation.TabStop = True
        Me.lnkVATCalculation.Text = "Calculate VAT 5%"
        '
        'txtVATCost
        '
        Me.txtVATCost.BackColor = System.Drawing.Color.White
        Me.txtVATCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVATCost.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVATCost.Location = New System.Drawing.Point(155, 72)
        Me.txtVATCost.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVATCost.MaxLength = 11
        Me.txtVATCost.Name = "txtVATCost"
        Me.txtVATCost.Size = New System.Drawing.Size(90, 23)
        Me.txtVATCost.TabIndex = 13
        Me.txtVATCost.Text = "0"
        Me.txtVATCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(59, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 17)
        Me.Label18.TabIndex = 2387
        Me.Label18.Text = "VAT Amount:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblListTariffRates
        '
        Me.lblListTariffRates.AutoSize = True
        Me.lblListTariffRates.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListTariffRates.Location = New System.Drawing.Point(251, 51)
        Me.lblListTariffRates.Name = "lblListTariffRates"
        Me.lblListTariffRates.Size = New System.Drawing.Size(122, 17)
        Me.lblListTariffRates.TabIndex = 2385
        Me.lblListTariffRates.TabStop = True
        Me.lblListTariffRates.Text = "Get Buying Rates"
        Me.ToolTip1.SetToolTip(Me.lblListTariffRates, "Click here to get list")
        '
        'DGridView
        '
        Me.DGridView.AllowUserToAddRows = False
        Me.DGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridView.Location = New System.Drawing.Point(1, 125)
        Me.DGridView.Name = "DGridView"
        Me.DGridView.RowTemplate.Height = 24
        Me.DGridView.Size = New System.Drawing.Size(485, 151)
        Me.DGridView.TabIndex = 2359
        '
        'btnSaveEntry
        '
        Me.btnSaveEntry.AutoSize = True
        Me.btnSaveEntry.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveEntry.FlatAppearance.BorderSize = 0
        Me.btnSaveEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveEntry.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveEntry.ForeColor = System.Drawing.Color.Black
        Me.btnSaveEntry.Image = CType(resources.GetObject("btnSaveEntry.Image"), System.Drawing.Image)
        Me.btnSaveEntry.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveEntry.Location = New System.Drawing.Point(440, 80)
        Me.btnSaveEntry.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnSaveEntry.Name = "btnSaveEntry"
        Me.btnSaveEntry.Size = New System.Drawing.Size(38, 38)
        Me.btnSaveEntry.TabIndex = 15
        Me.btnSaveEntry.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.btnSaveEntry, "Add To List")
        Me.btnSaveEntry.UseVisualStyleBackColor = False
        '
        'btnAddEntry
        '
        Me.btnAddEntry.AutoSize = True
        Me.btnAddEntry.BackColor = System.Drawing.Color.Transparent
        Me.btnAddEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAddEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddEntry.FlatAppearance.BorderSize = 0
        Me.btnAddEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddEntry.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddEntry.ForeColor = System.Drawing.Color.Black
        Me.btnAddEntry.Image = CType(resources.GetObject("btnAddEntry.Image"), System.Drawing.Image)
        Me.btnAddEntry.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddEntry.Location = New System.Drawing.Point(402, 80)
        Me.btnAddEntry.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnAddEntry.Name = "btnAddEntry"
        Me.btnAddEntry.Size = New System.Drawing.Size(38, 38)
        Me.btnAddEntry.TabIndex = 2357
        Me.btnAddEntry.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.btnAddEntry, "Add To List")
        Me.btnAddEntry.UseVisualStyleBackColor = False
        '
        'txtChargeCode
        '
        Me.txtChargeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChargeCode.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtChargeCode.Location = New System.Drawing.Point(155, 25)
        Me.txtChargeCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtChargeCode.MaxLength = 5
        Me.txtChargeCode.Name = "txtChargeCode"
        Me.txtChargeCode.Size = New System.Drawing.Size(90, 24)
        Me.txtChargeCode.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.txtChargeCode, "Enter Charge Code")
        '
        'txtChargeDesc
        '
        Me.txtChargeDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChargeDesc.Location = New System.Drawing.Point(155, 95)
        Me.txtChargeDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtChargeDesc.MaxLength = 50
        Me.txtChargeDesc.Name = "txtChargeDesc"
        Me.txtChargeDesc.Size = New System.Drawing.Size(219, 23)
        Me.txtChargeDesc.TabIndex = 14
        Me.txtChargeDesc.Text = "Diesel+Waiting"
        '
        'txtServiceAmount
        '
        Me.txtServiceAmount.BackColor = System.Drawing.Color.White
        Me.txtServiceAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServiceAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceAmount.Location = New System.Drawing.Point(155, 49)
        Me.txtServiceAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtServiceAmount.MaxLength = 11
        Me.txtServiceAmount.Name = "txtServiceAmount"
        Me.txtServiceAmount.Size = New System.Drawing.Size(90, 23)
        Me.txtServiceAmount.TabIndex = 12
        Me.txtServiceAmount.Text = "0"
        Me.txtServiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-3, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 17)
        Me.Label5.TabIndex = 2350
        Me.Label5.Text = "Enter Charge Amount:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbChargeList
        '
        Me.cmbChargeList.AutoSize = True
        Me.cmbChargeList.BackColor = System.Drawing.Color.GhostWhite
        '
        'cmbChargeList.NestedRadGridView
        '
        Me.cmbChargeList.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbChargeList.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChargeList.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbChargeList.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbChargeList.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbChargeList.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbChargeList.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbChargeList.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbChargeList.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbChargeList.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.cmbChargeList.EditorControl.Name = "NestedRadGridView"
        Me.cmbChargeList.EditorControl.ReadOnly = True
        Me.cmbChargeList.EditorControl.ShowGroupPanel = False
        Me.cmbChargeList.EditorControl.Size = New System.Drawing.Size(300, 187)
        Me.cmbChargeList.EditorControl.TabIndex = 0
        Me.cmbChargeList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmbChargeList.Location = New System.Drawing.Point(245, 25)
        Me.cmbChargeList.Name = "cmbChargeList"
        Me.cmbChargeList.Size = New System.Drawing.Size(233, 24)
        Me.cmbChargeList.TabIndex = 11
        Me.cmbChargeList.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 17)
        Me.Label4.TabIndex = 2348
        Me.Label4.Text = "Select Charge Type:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelVendorBuyingRate
        '
        Me.panelVendorBuyingRate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.panelVendorBuyingRate.Controls.Add(Me.txtVendorLineNote)
        Me.panelVendorBuyingRate.Controls.Add(Me.txtVendorTotalRate)
        Me.panelVendorBuyingRate.Controls.Add(Me.txtVendorAdditionalRate)
        Me.panelVendorBuyingRate.Controls.Add(Me.txtVendorBaseRate)
        Me.panelVendorBuyingRate.Controls.Add(Me.lblTotalRate)
        Me.panelVendorBuyingRate.Controls.Add(Me.Label15)
        Me.panelVendorBuyingRate.Controls.Add(Me.btnOkVendor)
        Me.panelVendorBuyingRate.Controls.Add(Me.lblVendorBuyingRate)
        Me.panelVendorBuyingRate.Controls.Add(Me.lblVendorEqpType)
        Me.panelVendorBuyingRate.Controls.Add(Me.Panel3)
        Me.panelVendorBuyingRate.Controls.Add(Me.lblVendorName)
        Me.panelVendorBuyingRate.Location = New System.Drawing.Point(10, 352)
        Me.panelVendorBuyingRate.Name = "panelVendorBuyingRate"
        Me.panelVendorBuyingRate.Size = New System.Drawing.Size(481, 191)
        Me.panelVendorBuyingRate.TabIndex = 2380
        Me.panelVendorBuyingRate.Visible = False
        '
        'txtVendorLineNote
        '
        Me.txtVendorLineNote.BackColor = System.Drawing.Color.Azure
        Me.txtVendorLineNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorLineNote.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtVendorLineNote.Location = New System.Drawing.Point(38, 148)
        Me.txtVendorLineNote.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVendorLineNote.MaxLength = 20
        Me.txtVendorLineNote.Name = "txtVendorLineNote"
        Me.txtVendorLineNote.ReadOnly = True
        Me.txtVendorLineNote.Size = New System.Drawing.Size(295, 24)
        Me.txtVendorLineNote.TabIndex = 2384
        '
        'txtVendorTotalRate
        '
        Me.txtVendorTotalRate.BackColor = System.Drawing.Color.Azure
        Me.txtVendorTotalRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorTotalRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorTotalRate.Location = New System.Drawing.Point(243, 125)
        Me.txtVendorTotalRate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVendorTotalRate.MaxLength = 11
        Me.txtVendorTotalRate.Name = "txtVendorTotalRate"
        Me.txtVendorTotalRate.ReadOnly = True
        Me.txtVendorTotalRate.Size = New System.Drawing.Size(90, 23)
        Me.txtVendorTotalRate.TabIndex = 2383
        Me.txtVendorTotalRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorAdditionalRate
        '
        Me.txtVendorAdditionalRate.BackColor = System.Drawing.Color.Azure
        Me.txtVendorAdditionalRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorAdditionalRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorAdditionalRate.Location = New System.Drawing.Point(133, 125)
        Me.txtVendorAdditionalRate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVendorAdditionalRate.MaxLength = 11
        Me.txtVendorAdditionalRate.Name = "txtVendorAdditionalRate"
        Me.txtVendorAdditionalRate.ReadOnly = True
        Me.txtVendorAdditionalRate.Size = New System.Drawing.Size(90, 23)
        Me.txtVendorAdditionalRate.TabIndex = 2382
        Me.txtVendorAdditionalRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorBaseRate
        '
        Me.txtVendorBaseRate.BackColor = System.Drawing.Color.Azure
        Me.txtVendorBaseRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorBaseRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorBaseRate.Location = New System.Drawing.Point(38, 125)
        Me.txtVendorBaseRate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVendorBaseRate.MaxLength = 11
        Me.txtVendorBaseRate.Name = "txtVendorBaseRate"
        Me.txtVendorBaseRate.ReadOnly = True
        Me.txtVendorBaseRate.Size = New System.Drawing.Size(90, 23)
        Me.txtVendorBaseRate.TabIndex = 2381
        Me.txtVendorBaseRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalRate
        '
        Me.lblTotalRate.AutoSize = True
        Me.lblTotalRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRate.Location = New System.Drawing.Point(253, 104)
        Me.lblTotalRate.Name = "lblTotalRate"
        Me.lblTotalRate.Size = New System.Drawing.Size(73, 17)
        Me.lblTotalRate.TabIndex = 2380
        Me.lblTotalRate.Text = "Total Rate"
        Me.lblTotalRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(133, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 17)
        Me.Label15.TabIndex = 2379
        Me.Label15.Text = "Additional Rate"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnOkVendor.Location = New System.Drawing.Point(375, 124)
        Me.btnOkVendor.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnOkVendor.Name = "btnOkVendor"
        Me.btnOkVendor.Size = New System.Drawing.Size(38, 38)
        Me.btnOkVendor.TabIndex = 2378
        Me.btnOkVendor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.btnOkVendor, "Add To List")
        Me.btnOkVendor.UseVisualStyleBackColor = False
        '
        'lblVendorBuyingRate
        '
        Me.lblVendorBuyingRate.AutoSize = True
        Me.lblVendorBuyingRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorBuyingRate.Location = New System.Drawing.Point(38, 104)
        Me.lblVendorBuyingRate.Name = "lblVendorBuyingRate"
        Me.lblVendorBuyingRate.Size = New System.Drawing.Size(77, 17)
        Me.lblVendorBuyingRate.TabIndex = 2377
        Me.lblVendorBuyingRate.Text = "Base Rate"
        Me.lblVendorBuyingRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVendorEqpType
        '
        Me.lblVendorEqpType.AutoSize = True
        Me.lblVendorEqpType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorEqpType.Location = New System.Drawing.Point(31, 67)
        Me.lblVendorEqpType.Name = "lblVendorEqpType"
        Me.lblVendorEqpType.Size = New System.Drawing.Size(131, 17)
        Me.lblVendorEqpType.TabIndex = 2376
        Me.lblVendorEqpType.Text = "<Equipment Type>"
        Me.lblVendorEqpType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Bisque
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(481, 31)
        Me.Panel3.TabIndex = 2375
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(453, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2364
        Me.PictureBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 4)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 18)
        Me.Label16.TabIndex = 2363
        Me.Label16.Text = "Vendor Buying Rate"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVendorName
        '
        Me.lblVendorName.AutoSize = True
        Me.lblVendorName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorName.Location = New System.Drawing.Point(31, 42)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(114, 17)
        Me.lblVendorName.TabIndex = 2361
        Me.lblVendorName.Text = "<Vendor Name>"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 18)
        Me.Label6.TabIndex = 2357
        Me.Label6.Text = "Trip Details"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCargoDesc
        '
        Me.txtCargoDesc.BackColor = System.Drawing.Color.Azure
        Me.txtCargoDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCargoDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtCargoDesc.Location = New System.Drawing.Point(123, 149)
        Me.txtCargoDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCargoDesc.MaxLength = 11
        Me.txtCargoDesc.Name = "txtCargoDesc"
        Me.txtCargoDesc.ReadOnly = True
        Me.txtCargoDesc.Size = New System.Drawing.Size(380, 24)
        Me.txtCargoDesc.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(64, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 17)
        Me.Label7.TabIndex = 2358
        Me.Label7.Text = "Cargo :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEqpType
        '
        Me.txtEqpType.BackColor = System.Drawing.Color.Azure
        Me.txtEqpType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEqpType.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtEqpType.Location = New System.Drawing.Point(123, 173)
        Me.txtEqpType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEqpType.MaxLength = 11
        Me.txtEqpType.Name = "txtEqpType"
        Me.txtEqpType.ReadOnly = True
        Me.txtEqpType.Size = New System.Drawing.Size(192, 24)
        Me.txtEqpType.TabIndex = 7
        Me.txtEqpType.Text = "6TON DYNA (DRY)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 17)
        Me.Label8.TabIndex = 2360
        Me.Label8.Text = "Vehicle Type/No.:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPOLPOD
        '
        Me.txtPOLPOD.BackColor = System.Drawing.Color.Azure
        Me.txtPOLPOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOLPOD.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtPOLPOD.Location = New System.Drawing.Point(123, 197)
        Me.txtPOLPOD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPOLPOD.MaxLength = 11
        Me.txtPOLPOD.Name = "txtPOLPOD"
        Me.txtPOLPOD.ReadOnly = True
        Me.txtPOLPOD.Size = New System.Drawing.Size(380, 24)
        Me.txtPOLPOD.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(35, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 17)
        Me.Label9.TabIndex = 2362
        Me.Label9.Text = "Destination:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEqpNo
        '
        Me.txtEqpNo.BackColor = System.Drawing.Color.Azure
        Me.txtEqpNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEqpNo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtEqpNo.Location = New System.Drawing.Point(316, 173)
        Me.txtEqpNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEqpNo.MaxLength = 11
        Me.txtEqpNo.Name = "txtEqpNo"
        Me.txtEqpNo.ReadOnly = True
        Me.txtEqpNo.Size = New System.Drawing.Size(187, 24)
        Me.txtEqpNo.TabIndex = 8
        Me.txtEqpNo.Text = "TRK001"
        '
        'txtRefNo
        '
        Me.txtRefNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRefNo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtRefNo.Location = New System.Drawing.Point(413, 88)
        Me.txtRefNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRefNo.MaxLength = 20
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(90, 24)
        Me.txtRefNo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtRefNo, "Enter Charge Code")
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtRemarks.Location = New System.Drawing.Point(123, 88)
        Me.txtRemarks.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRemarks.MaxLength = 50
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(235, 24)
        Me.txtRemarks.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtRemarks, "Enter Charge Code")
        '
        'txtAccountRefNo
        '
        Me.txtAccountRefNo.BackColor = System.Drawing.Color.Azure
        Me.txtAccountRefNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountRefNo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtAccountRefNo.Location = New System.Drawing.Point(413, 112)
        Me.txtAccountRefNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAccountRefNo.MaxLength = 20
        Me.txtAccountRefNo.Name = "txtAccountRefNo"
        Me.txtAccountRefNo.ReadOnly = True
        Me.txtAccountRefNo.Size = New System.Drawing.Size(90, 24)
        Me.txtAccountRefNo.TabIndex = 2380
        Me.ToolTip1.SetToolTip(Me.txtAccountRefNo, "Enter Charge Code")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(920, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 17)
        Me.Label11.TabIndex = 2367
        Me.Label11.Text = "Amount To Pay:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Visible = False
        '
        'txtAmountToPay
        '
        Me.txtAmountToPay.BackColor = System.Drawing.Color.Azure
        Me.txtAmountToPay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAmountToPay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountToPay.Location = New System.Drawing.Point(826, 13)
        Me.txtAmountToPay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAmountToPay.MaxLength = 11
        Me.txtAmountToPay.Name = "txtAmountToPay"
        Me.txtAmountToPay.ReadOnly = True
        Me.txtAmountToPay.Size = New System.Drawing.Size(80, 23)
        Me.txtAmountToPay.TabIndex = 2366
        Me.txtAmountToPay.Text = "4108.00"
        Me.txtAmountToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmountToPay.Visible = False
        '
        'btnSaveAnPrint
        '
        Me.btnSaveAnPrint.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnSaveAnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveAnPrint.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnSaveAnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAnPrint.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveAnPrint.Location = New System.Drawing.Point(295, 618)
        Me.btnSaveAnPrint.Name = "btnSaveAnPrint"
        Me.btnSaveAnPrint.Size = New System.Drawing.Size(106, 35)
        Me.btnSaveAnPrint.TabIndex = 16
        Me.btnSaveAnPrint.Text = "Save"
        Me.btnSaveAnPrint.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.Location = New System.Drawing.Point(404, 618)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(106, 35)
        Me.btnPrint.TabIndex = 17
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(364, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 17)
        Me.Label13.TabIndex = 2370
        Me.Label13.Text = "Ref#:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(48, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 17)
        Me.Label14.TabIndex = 2372
        Me.Label14.Text = "Remarks:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Info
        Me.Panel1.Controls.Add(Me.lblRecordID)
        Me.Panel1.Controls.Add(Me.lblUpdatedBy)
        Me.Panel1.Controls.Add(Me.lblCreatedBy)
        Me.Panel1.Controls.Add(Me.txtAmountToPay)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 659)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(516, 33)
        Me.Panel1.TabIndex = 2373
        '
        'lblRecordID
        '
        Me.lblRecordID.AutoSize = True
        Me.lblRecordID.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordID.Location = New System.Drawing.Point(390, 1)
        Me.lblRecordID.Name = "lblRecordID"
        Me.lblRecordID.Size = New System.Drawing.Size(105, 15)
        Me.lblRecordID.TabIndex = 2351
        Me.lblRecordID.Tag = ""
        Me.lblRecordID.Text = "Record ID : [1258]"
        Me.lblRecordID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUpdatedBy
        '
        Me.lblUpdatedBy.AutoSize = True
        Me.lblUpdatedBy.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdatedBy.Location = New System.Drawing.Point(4, 16)
        Me.lblUpdatedBy.Name = "lblUpdatedBy"
        Me.lblUpdatedBy.Size = New System.Drawing.Size(229, 15)
        Me.lblUpdatedBy.TabIndex = 2350
        Me.lblUpdatedBy.Tag = ""
        Me.lblUpdatedBy.Text = "Last Updated By / On : [XX] - [dd/mm/yyyy]"
        Me.lblUpdatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.AutoSize = True
        Me.lblCreatedBy.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedBy.Location = New System.Drawing.Point(4, 0)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(199, 15)
        Me.lblCreatedBy.TabIndex = 2349
        Me.lblCreatedBy.Tag = ""
        Me.lblCreatedBy.Text = "Created By / On : [XX] - [dd/mm/yyyy]"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelMessage
        '
        Me.PanelMessage.BackColor = System.Drawing.Color.Bisque
        Me.PanelMessage.Controls.Add(Me.lblMessage)
        Me.PanelMessage.Controls.Add(Me.picCrossed)
        Me.PanelMessage.Controls.Add(Me.picChecked)
        Me.PanelMessage.Location = New System.Drawing.Point(7, 618)
        Me.PanelMessage.Name = "PanelMessage"
        Me.PanelMessage.Size = New System.Drawing.Size(272, 25)
        Me.PanelMessage.TabIndex = 2374
        Me.PanelMessage.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMessage.Location = New System.Drawing.Point(31, 1)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(143, 20)
        Me.lblMessage.TabIndex = 2344
        Me.lblMessage.Text = "Search Result"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picCrossed
        '
        Me.picCrossed.Image = CType(resources.GetObject("picCrossed.Image"), System.Drawing.Image)
        Me.picCrossed.Location = New System.Drawing.Point(1, 1)
        Me.picCrossed.Name = "picCrossed"
        Me.picCrossed.Size = New System.Drawing.Size(24, 24)
        Me.picCrossed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picCrossed.TabIndex = 2346
        Me.picCrossed.TabStop = False
        '
        'picChecked
        '
        Me.picChecked.Image = CType(resources.GetObject("picChecked.Image"), System.Drawing.Image)
        Me.picChecked.Location = New System.Drawing.Point(1, 1)
        Me.picChecked.Name = "picChecked"
        Me.picChecked.Size = New System.Drawing.Size(24, 24)
        Me.picChecked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picChecked.TabIndex = 2345
        Me.picChecked.TabStop = False
        Me.picChecked.Visible = False
        '
        'lblPOLPOD
        '
        Me.lblPOLPOD.AutoSize = True
        Me.lblPOLPOD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOLPOD.ForeColor = System.Drawing.Color.Black
        Me.lblPOLPOD.Location = New System.Drawing.Point(385, 263)
        Me.lblPOLPOD.Name = "lblPOLPOD"
        Me.lblPOLPOD.Size = New System.Drawing.Size(120, 17)
        Me.lblPOLPOD.TabIndex = 2375
        Me.lblPOLPOD.Text = "SAJED - SADMM"
        Me.lblPOLPOD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(299, 567)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 17)
        Me.Label10.TabIndex = 2377
        Me.Label10.Text = "Total VAT"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalCharges
        '
        Me.txtTotalCharges.BackColor = System.Drawing.Color.Azure
        Me.txtTotalCharges.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalCharges.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCharges.Location = New System.Drawing.Point(401, 588)
        Me.txtTotalCharges.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalCharges.MaxLength = 11
        Me.txtTotalCharges.Name = "txtTotalCharges"
        Me.txtTotalCharges.ReadOnly = True
        Me.txtTotalCharges.Size = New System.Drawing.Size(102, 23)
        Me.txtTotalCharges.TabIndex = 2376
        Me.txtTotalCharges.Text = "4108.00"
        Me.txtTotalCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOriginLocation
        '
        Me.lblOriginLocation.AutoSize = True
        Me.lblOriginLocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginLocation.Location = New System.Drawing.Point(120, 221)
        Me.lblOriginLocation.Name = "lblOriginLocation"
        Me.lblOriginLocation.Size = New System.Drawing.Size(126, 17)
        Me.lblOriginLocation.TabIndex = 2378
        Me.lblOriginLocation.Text = "Loading Location :"
        Me.lblOriginLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDestinationLocation
        '
        Me.lblDestinationLocation.AutoSize = True
        Me.lblDestinationLocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestinationLocation.Location = New System.Drawing.Point(120, 238)
        Me.lblDestinationLocation.Name = "lblDestinationLocation"
        Me.lblDestinationLocation.Size = New System.Drawing.Size(138, 17)
        Me.lblDestinationLocation.TabIndex = 2379
        Me.lblDestinationLocation.Text = "Discharge Location:"
        Me.lblDestinationLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(315, 112)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 17)
        Me.Label17.TabIndex = 2381
        Me.Label17.Text = "Account Ref:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(401, 567)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 17)
        Me.Label20.TabIndex = 2382
        Me.Label20.Text = "Total Charges"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalvAT
        '
        Me.txtTotalvAT.BackColor = System.Drawing.Color.Azure
        Me.txtTotalvAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalvAT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalvAT.Location = New System.Drawing.Point(299, 588)
        Me.txtTotalvAT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalvAT.MaxLength = 11
        Me.txtTotalvAT.Name = "txtTotalvAT"
        Me.txtTotalvAT.ReadOnly = True
        Me.txtTotalvAT.Size = New System.Drawing.Size(102, 23)
        Me.txtTotalvAT.TabIndex = 2377
        Me.txtTotalvAT.Text = "4108.00"
        Me.txtTotalvAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmRentalChargesITR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 692)
        Me.Controls.Add(Me.panelVendorBuyingRate)
        Me.Controls.Add(Me.txtTotalvAT)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtAccountRefNo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblDestinationLocation)
        Me.Controls.Add(Me.lblOriginLocation)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblPOLPOD)
        Me.Controls.Add(Me.PanelMessage)
        Me.Controls.Add(Me.txtTotalCharges)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSaveAnPrint)
        Me.Controls.Add(Me.txtEqpNo)
        Me.Controls.Add(Me.txtPOLPOD)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtEqpType)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCargoDesc)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtITRDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtITRNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCreditorNameCompany)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.txtAdvancePayment)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRentalChargesITR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rental Charges - ITR Form"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.txtAdvancePayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreditorNameCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtITRNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtITRDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtVATCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChargeCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChargeDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServiceAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbChargeList.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbChargeList.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbChargeList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelVendorBuyingRate.ResumeLayout(False)
        Me.panelVendorBuyingRate.PerformLayout()
        CType(Me.txtVendorLineNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorTotalRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorAdditionalRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorBaseRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCargoDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEqpType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOLPOD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEqpNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRefNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountRefNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmountToPay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelMessage.ResumeLayout(False)
        Me.PanelMessage.PerformLayout()
        CType(Me.picCrossed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChecked, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCharges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalvAT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelHeader As System.Windows.Forms.Panel
    Friend WithEvents lblFormTitle As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtAdvancePayment As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtCreditorNameCompany As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtITRNumber As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtITRDate As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCargoDesc As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbChargeList As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEqpType As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPOLPOD As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEqpNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChargeDesc As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtServiceAmount As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChargeCode As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSaveEntry As System.Windows.Forms.Button
    Friend WithEvents btnAddEntry As System.Windows.Forms.Button
    Friend WithEvents DGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAmountToPay As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnSaveAnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents txtRefNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRecordID As System.Windows.Forms.Label
    Friend WithEvents lblUpdatedBy As System.Windows.Forms.Label
    Friend WithEvents lblCreatedBy As System.Windows.Forms.Label
    Friend WithEvents PanelMessage As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents picCrossed As System.Windows.Forms.PictureBox
    Friend WithEvents picChecked As System.Windows.Forms.PictureBox
    Friend WithEvents lblPOLPOD As System.Windows.Forms.Label
    Friend WithEvents lblListTariffRates As System.Windows.Forms.LinkLabel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCharges As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblOriginLocation As System.Windows.Forms.Label
    Friend WithEvents lblDestinationLocation As System.Windows.Forms.Label
    Friend WithEvents panelVendorBuyingRate As System.Windows.Forms.Panel
    Friend WithEvents lblVendorBuyingRate As System.Windows.Forms.Label
    Friend WithEvents lblVendorEqpType As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents btnOkVendor As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtVendorTotalRate As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtVendorAdditionalRate As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtVendorBaseRate As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblTotalRate As System.Windows.Forms.Label
    Friend WithEvents txtVendorLineNote As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtAccountRefNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtVATCost As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lnkVATCalculation As System.Windows.Forms.LinkLabel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTotalvAT As Telerik.WinControls.UI.RadTextBox
End Class
