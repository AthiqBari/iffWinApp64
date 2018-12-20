<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddAddress
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
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddAddress))
        Dim TableViewDefinition4 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.lblOrganziationName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTitle = New Telerik.WinControls.UI.RadTextBox()
        Me.txtContactPerson1 = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAddress1 = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.radCountry = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.radCity = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.radLocation = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.txtTelephone = New Telerik.WinControls.UI.RadTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New Telerik.WinControls.UI.RadTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RadGridAddress = New Telerik.WinControls.UI.RadGridView()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.lblCountryCity = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactPerson1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radCountry.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radCountry.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radCity.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radCity.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radLocation.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radLocation.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelephone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridAddress.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblOrganziationName
        '
        Me.lblOrganziationName.AutoSize = True
        Me.lblOrganziationName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrganziationName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOrganziationName.Location = New System.Drawing.Point(12, 9)
        Me.lblOrganziationName.Name = "lblOrganziationName"
        Me.lblOrganziationName.Size = New System.Drawing.Size(143, 18)
        Me.lblOrganziationName.TabIndex = 2328
        Me.lblOrganziationName.Text = "Organization Name"
        Me.lblOrganziationName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 17)
        Me.Label1.TabIndex = 2329
        Me.Label1.Text = "Enter Complete Address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(36, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 2330
        Me.Label2.Text = "Address Title:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(138, 87)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTitle.MaxLength = 50
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(297, 23)
        Me.txtTitle.TabIndex = 1
        '
        'txtContactPerson1
        '
        Me.txtContactPerson1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPerson1.Location = New System.Drawing.Point(138, 111)
        Me.txtContactPerson1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtContactPerson1.MaxLength = 100
        Me.txtContactPerson1.Name = "txtContactPerson1"
        Me.txtContactPerson1.Size = New System.Drawing.Size(297, 23)
        Me.txtContactPerson1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 17)
        Me.Label3.TabIndex = 2332
        Me.Label3.Text = "Contact Person:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress1
        '
        Me.txtAddress1.AutoSize = False
        Me.txtAddress1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress1.Location = New System.Drawing.Point(138, 135)
        Me.txtAddress1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddress1.MaxLength = 178
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(297, 75)
        Me.txtAddress1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(66, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 17)
        Me.Label4.TabIndex = 2334
        Me.Label4.Text = "Address:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(69, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 17)
        Me.Label5.TabIndex = 2336
        Me.Label5.Text = "Country:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radCountry
        '
        Me.radCountry.AutoSize = True
        Me.radCountry.BackColor = System.Drawing.Color.GhostWhite
        '
        'radCountry.NestedRadGridView
        '
        Me.radCountry.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.radCountry.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCountry.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radCountry.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.radCountry.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.radCountry.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.radCountry.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.radCountry.EditorControl.MasterTemplate.EnableGrouping = False
        Me.radCountry.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.radCountry.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.radCountry.EditorControl.Name = "NestedRadGridView"
        Me.radCountry.EditorControl.ReadOnly = True
        Me.radCountry.EditorControl.ShowGroupPanel = False
        Me.radCountry.EditorControl.Size = New System.Drawing.Size(300, 187)
        Me.radCountry.EditorControl.TabIndex = 0
        Me.radCountry.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCountry.Location = New System.Drawing.Point(138, 210)
        Me.radCountry.Name = "radCountry"
        Me.radCountry.Size = New System.Drawing.Size(70, 23)
        Me.radCountry.TabIndex = 4
        Me.radCountry.TabStop = False
        Me.radCountry.Tag = "0"
        '
        'radCity
        '
        Me.radCity.AutoSize = True
        Me.radCity.BackColor = System.Drawing.Color.GhostWhite
        '
        'radCity.NestedRadGridView
        '
        Me.radCity.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.radCity.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCity.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radCity.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.radCity.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.radCity.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.radCity.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.radCity.EditorControl.MasterTemplate.EnableGrouping = False
        Me.radCity.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.radCity.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.radCity.EditorControl.Name = "NestedRadGridView"
        Me.radCity.EditorControl.ReadOnly = True
        Me.radCity.EditorControl.ShowGroupPanel = False
        Me.radCity.EditorControl.Size = New System.Drawing.Size(300, 187)
        Me.radCity.EditorControl.TabIndex = 0
        Me.radCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCity.Location = New System.Drawing.Point(257, 210)
        Me.radCity.Name = "radCity"
        Me.radCity.Size = New System.Drawing.Size(178, 23)
        Me.radCity.TabIndex = 5
        Me.radCity.TabStop = False
        Me.radCity.Tag = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(214, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 17)
        Me.Label6.TabIndex = 2339
        Me.Label6.Text = "City:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(65, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 17)
        Me.Label7.TabIndex = 2341
        Me.Label7.Text = "Location:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radLocation
        '
        Me.radLocation.AutoSize = True
        Me.radLocation.BackColor = System.Drawing.Color.GhostWhite
        '
        'radLocation.NestedRadGridView
        '
        Me.radLocation.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.radLocation.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLocation.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLocation.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.radLocation.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.radLocation.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.radLocation.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.radLocation.EditorControl.MasterTemplate.EnableGrouping = False
        Me.radLocation.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.radLocation.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.radLocation.EditorControl.Name = "NestedRadGridView"
        Me.radLocation.EditorControl.ReadOnly = True
        Me.radLocation.EditorControl.ShowGroupPanel = False
        Me.radLocation.EditorControl.Size = New System.Drawing.Size(300, 187)
        Me.radLocation.EditorControl.TabIndex = 0
        Me.radLocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLocation.Location = New System.Drawing.Point(138, 256)
        Me.radLocation.Name = "radLocation"
        Me.radLocation.Size = New System.Drawing.Size(297, 23)
        Me.radLocation.TabIndex = 6
        Me.radLocation.TabStop = False
        Me.radLocation.Tag = "0"
        '
        'txtTelephone
        '
        Me.txtTelephone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelephone.Location = New System.Drawing.Point(138, 280)
        Me.txtTelephone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTelephone.MaxLength = 100
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(297, 23)
        Me.txtTelephone.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(13, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 17)
        Me.Label8.TabIndex = 2342
        Me.Label8.Text = "Contact Number:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(138, 304)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEmail.MaxLength = 70
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(297, 23)
        Me.txtEmail.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(83, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 17)
        Me.Label9.TabIndex = 2344
        Me.Label9.Text = "Email:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(396, 333)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(39, 38)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(-1, 378)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 17)
        Me.Label10.TabIndex = 2347
        Me.Label10.Text = "Other Address"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadGridAddress
        '
        Me.RadGridAddress.AutoSizeRows = True
        Me.RadGridAddress.BackColor = System.Drawing.SystemColors.Control
        Me.RadGridAddress.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadGridAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridAddress.Location = New System.Drawing.Point(2, 398)
        '
        '
        '
        Me.RadGridAddress.MasterTemplate.AllowAddNewRow = False
        Me.RadGridAddress.MasterTemplate.EnableGrouping = False
        Me.RadGridAddress.MasterTemplate.ShowRowHeaderColumn = False
        Me.RadGridAddress.MasterTemplate.ViewDefinition = TableViewDefinition4
        Me.RadGridAddress.Name = "RadGridAddress"
        Me.RadGridAddress.ReadOnly = True
        Me.RadGridAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridAddress.Size = New System.Drawing.Size(442, 212)
        Me.RadGridAddress.TabIndex = 2348
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.ForeColor = System.Drawing.Color.Black
        Me.chkIsActive.Location = New System.Drawing.Point(137, 327)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(83, 21)
        Me.chkIsActive.TabIndex = 2349
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'lblCountryCity
        '
        Me.lblCountryCity.AutoSize = True
        Me.lblCountryCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountryCity.ForeColor = System.Drawing.Color.DimGray
        Me.lblCountryCity.Location = New System.Drawing.Point(138, 236)
        Me.lblCountryCity.Name = "lblCountryCity"
        Me.lblCountryCity.Size = New System.Drawing.Size(91, 17)
        Me.lblCountryCity.TabIndex = 2350
        Me.lblCountryCity.Text = "Country, City"
        Me.lblCountryCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMessage.Location = New System.Drawing.Point(189, 351)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(201, 22)
        Me.lblMessage.TabIndex = 2351
        Me.lblMessage.Text = "Message..."
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblMessage.Visible = False
        '
        'frmAddAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(447, 662)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblCountryCity)
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.RadGridAddress)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTelephone)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.radLocation)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.radCity)
        Me.Controls.Add(Me.radCountry)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAddress1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtContactPerson1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblOrganziationName)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAddAddress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add / Edit Organization Address"
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactPerson1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddress1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radCountry.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radCountry.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radCity.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radCity.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radLocation.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radLocation.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelephone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridAddress.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOrganziationName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtContactPerson1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents radCountry As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents radCity As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents radLocation As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents txtTelephone As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RadGridAddress As Telerik.WinControls.UI.RadGridView
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblCountryCity As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
End Class
