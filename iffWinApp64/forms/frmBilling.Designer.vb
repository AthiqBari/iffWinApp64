<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBilling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBilling))
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblItemCodeName = New System.Windows.Forms.Label()
        Me.txtSearchBy = New Telerik.WinControls.UI.RadTextBox()
        Me.lblText = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.chkPDF = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSearchBy = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelDate = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.radDateTo = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.radDateFrom = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.panelText = New System.Windows.Forms.Panel()
        Me.rbJobCost = New System.Windows.Forms.RadioButton()
        Me.rbFinalInvoice = New System.Windows.Forms.RadioButton()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadGridView2 = New Telerik.WinControls.UI.RadGridView()
        Me.panelHeader.SuspendLayout()
        CType(Me.txtSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelDate.SuspendLayout()
        CType(Me.radDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radDateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelText.SuspendLayout()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btnPrint)
        Me.panelHeader.Controls.Add(Me.lblItemCodeName)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1245, 55)
        Me.panelHeader.TabIndex = 66
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
        Me.btnPrint.Location = New System.Drawing.Point(1173, 9)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(48, 43)
        Me.btnPrint.TabIndex = 1459
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = False
        Me.btnPrint.Visible = False
        '
        'lblItemCodeName
        '
        Me.lblItemCodeName.AutoSize = True
        Me.lblItemCodeName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCodeName.ForeColor = System.Drawing.Color.White
        Me.lblItemCodeName.Location = New System.Drawing.Point(23, 9)
        Me.lblItemCodeName.Name = "lblItemCodeName"
        Me.lblItemCodeName.Size = New System.Drawing.Size(134, 20)
        Me.lblItemCodeName.TabIndex = 42
        Me.lblItemCodeName.Text = "Print Final Invoice"
        Me.lblItemCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearchBy
        '
        Me.txtSearchBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchBy.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchBy.Location = New System.Drawing.Point(153, 5)
        Me.txtSearchBy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearchBy.MaxLength = 20
        Me.txtSearchBy.Name = "txtSearchBy"
        Me.txtSearchBy.Size = New System.Drawing.Size(305, 23)
        Me.txtSearchBy.TabIndex = 67
        '
        'lblText
        '
        Me.lblText.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblText.Location = New System.Drawing.Point(11, 5)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(136, 23)
        Me.lblText.TabIndex = 68
        Me.lblText.Text = "Enter Search Text:"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSubmit
        '
        Me.btnSubmit.AutoSize = True
        Me.btnSubmit.BackColor = System.Drawing.Color.Transparent
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Tahoma", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSubmit.Location = New System.Drawing.Point(997, 62)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(102, 57)
        Me.btnSubmit.TabIndex = 69
        Me.btnSubmit.Text = "&Submit"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'chkPDF
        '
        Me.chkPDF.AutoSize = True
        Me.chkPDF.Checked = True
        Me.chkPDF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPDF.Enabled = False
        Me.chkPDF.Location = New System.Drawing.Point(1105, 82)
        Me.chkPDF.Name = "chkPDF"
        Me.chkPDF.Size = New System.Drawing.Size(116, 23)
        Me.chkPDF.TabIndex = 1462
        Me.chkPDF.Text = "Export to PDF"
        Me.chkPDF.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(12, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 23)
        Me.Label1.TabIndex = 1463
        Me.Label1.Text = "Choose Document :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchBy.FormattingEnabled = True
        Me.cmbSearchBy.Items.AddRange(New Object() {"Client Invoice (AR Bill)"})
        Me.cmbSearchBy.Location = New System.Drawing.Point(193, 62)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(209, 28)
        Me.cmbSearchBy.TabIndex = 1464
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Shipment#", "Invoice Number", "Invoice Date"})
        Me.ComboBox1.Location = New System.Drawing.Point(193, 90)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(209, 28)
        Me.ComboBox1.TabIndex = 1466
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(71, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 23)
        Me.Label2.TabIndex = 1465
        Me.Label2.Text = "Search By:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelDate
        '
        Me.panelDate.Controls.Add(Me.Label4)
        Me.panelDate.Controls.Add(Me.radDateTo)
        Me.panelDate.Controls.Add(Me.Label3)
        Me.panelDate.Controls.Add(Me.radDateFrom)
        Me.panelDate.Location = New System.Drawing.Point(405, 59)
        Me.panelDate.Name = "panelDate"
        Me.panelDate.Size = New System.Drawing.Size(583, 56)
        Me.panelDate.TabIndex = 1467
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(286, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 23)
        Me.Label4.TabIndex = 1468
        Me.Label4.Text = "Ending Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radDateTo
        '
        Me.radDateTo.CustomFormat = "dd-MMM-yyyy"
        Me.radDateTo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.radDateTo.Location = New System.Drawing.Point(408, 19)
        Me.radDateTo.Name = "radDateTo"
        Me.radDateTo.Size = New System.Drawing.Size(141, 25)
        Me.radDateTo.TabIndex = 1467
        Me.radDateTo.TabStop = False
        Me.radDateTo.Value = New Date(CType(0, Long))
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(17, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 23)
        Me.Label3.TabIndex = 1466
        Me.Label3.Text = "Starting Date:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radDateFrom
        '
        Me.radDateFrom.CustomFormat = "dd-MMM-yyyy"
        Me.radDateFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.radDateFrom.Location = New System.Drawing.Point(139, 19)
        Me.radDateFrom.Name = "radDateFrom"
        Me.radDateFrom.Size = New System.Drawing.Size(141, 25)
        Me.radDateFrom.TabIndex = 9
        Me.radDateFrom.TabStop = False
        Me.radDateFrom.Value = New Date(CType(0, Long))
        '
        'panelText
        '
        Me.panelText.Controls.Add(Me.rbJobCost)
        Me.panelText.Controls.Add(Me.rbFinalInvoice)
        Me.panelText.Controls.Add(Me.lblText)
        Me.panelText.Controls.Add(Me.txtSearchBy)
        Me.panelText.Location = New System.Drawing.Point(408, 62)
        Me.panelText.Name = "panelText"
        Me.panelText.Size = New System.Drawing.Size(583, 56)
        Me.panelText.TabIndex = 1468
        '
        'rbJobCost
        '
        Me.rbJobCost.AutoSize = True
        Me.rbJobCost.Location = New System.Drawing.Point(274, 28)
        Me.rbJobCost.Name = "rbJobCost"
        Me.rbJobCost.Size = New System.Drawing.Size(145, 23)
        Me.rbJobCost.TabIndex = 70
        Me.rbJobCost.TabStop = True
        Me.rbJobCost.Text = "Shipment Job Cost"
        Me.rbJobCost.UseVisualStyleBackColor = True
        '
        'rbFinalInvoice
        '
        Me.rbFinalInvoice.AutoSize = True
        Me.rbFinalInvoice.Location = New System.Drawing.Point(153, 28)
        Me.rbFinalInvoice.Name = "rbFinalInvoice"
        Me.rbFinalInvoice.Size = New System.Drawing.Size(105, 23)
        Me.rbFinalInvoice.TabIndex = 69
        Me.rbFinalInvoice.TabStop = True
        Me.rbFinalInvoice.Text = "Final Invoice"
        Me.rbFinalInvoice.UseVisualStyleBackColor = True
        '
        'RadGridView1
        '
        Me.RadGridView1.BackColor = System.Drawing.SystemColors.Control
        Me.RadGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadGridView1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView1.Location = New System.Drawing.Point(8, 125)
        '
        '
        '
        Me.RadGridView1.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView1.MasterTemplate.EnableGrouping = False
        Me.RadGridView1.MasterTemplate.ShowRowHeaderColumn = False
        Me.RadGridView1.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.ReadOnly = True
        Me.RadGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView1.Size = New System.Drawing.Size(1235, 230)
        Me.RadGridView1.TabIndex = 1469
        Me.RadGridView1.Text = "RadGridView1"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(8, 369)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 23)
        Me.Label5.TabIndex = 1470
        Me.Label5.Text = "Recent Print (15)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadGridView2
        '
        Me.RadGridView2.BackColor = System.Drawing.SystemColors.Control
        Me.RadGridView2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadGridView2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView2.Location = New System.Drawing.Point(8, 395)
        '
        '
        '
        Me.RadGridView2.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView2.MasterTemplate.EnableGrouping = False
        Me.RadGridView2.MasterTemplate.ShowRowHeaderColumn = False
        Me.RadGridView2.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.RadGridView2.Name = "RadGridView2"
        Me.RadGridView2.ReadOnly = True
        Me.RadGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView2.Size = New System.Drawing.Size(1235, 248)
        Me.RadGridView2.TabIndex = 1471
        Me.RadGridView2.Text = "RadGridView2"
        Me.RadGridView2.ThemeName = "ControlDefault"
        '
        'frmBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 645)
        Me.Controls.Add(Me.RadGridView2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.RadGridView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbSearchBy)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkPDF)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.panelHeader)
        Me.Controls.Add(Me.panelText)
        Me.Controls.Add(Me.panelDate)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmBilling"
        Me.ShowIcon = False
        Me.Text = "Billing Form"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.txtSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelDate.ResumeLayout(False)
        Me.panelDate.PerformLayout()
        CType(Me.radDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radDateFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelText.ResumeLayout(False)
        Me.panelText.PerformLayout()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelHeader As System.Windows.Forms.Panel
    Friend WithEvents lblItemCodeName As System.Windows.Forms.Label
    Friend WithEvents txtSearchBy As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents chkPDF As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents panelDate As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents radDateTo As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents radDateFrom As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents panelText As System.Windows.Forms.Panel
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadGridView2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rbJobCost As System.Windows.Forms.RadioButton
    Friend WithEvents rbFinalInvoice As System.Windows.Forms.RadioButton
End Class
