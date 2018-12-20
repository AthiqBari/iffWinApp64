<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.lblItemCodeName = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbReportType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDateTo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBranchName = New System.Windows.Forms.TextBox()
        Me.PanelVAT = New System.Windows.Forms.Panel()
        Me.lblPanelVAT = New System.Windows.Forms.Label()
        Me.cmbTAXType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbInputOutput = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDateFrom = New System.Windows.Forms.Button()
        Me.btnDateTo = New System.Windows.Forms.Button()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFound = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanelVAT.SuspendLayout()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblItemCodeName
        '
        Me.lblItemCodeName.AutoSize = True
        Me.lblItemCodeName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCodeName.ForeColor = System.Drawing.Color.White
        Me.lblItemCodeName.Location = New System.Drawing.Point(67, 27)
        Me.lblItemCodeName.Name = "lblItemCodeName"
        Me.lblItemCodeName.Size = New System.Drawing.Size(152, 20)
        Me.lblItemCodeName.TabIndex = 42
        Me.lblItemCodeName.Text = "Management Reports"
        Me.lblItemCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblItemCodeName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(935, 59)
        Me.Panel2.TabIndex = 66
        '
        'cmbReportType
        '
        Me.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReportType.FormattingEnabled = True
        Me.cmbReportType.Items.AddRange(New Object() {"<Select Report>", "VAT Analysis by Transaction Line", "VAT Summary by TAX ID"})
        Me.cmbReportType.Location = New System.Drawing.Point(129, 77)
        Me.cmbReportType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbReportType.Name = "cmbReportType"
        Me.cmbReportType.Size = New System.Drawing.Size(355, 28)
        Me.cmbReportType.TabIndex = 1466
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(24, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 28)
        Me.Label1.TabIndex = 1465
        Me.Label1.Text = "Report Type:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(129, 61)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.ReadOnly = True
        Me.txtDateFrom.Size = New System.Drawing.Size(108, 27)
        Me.txtDateFrom.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(7, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 19)
        Me.Label2.TabIndex = 1469
        Me.Label2.Text = "Date Range From"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(287, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 19)
        Me.Label3.TabIndex = 1470
        Me.Label3.Text = "To"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(316, 61)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.ReadOnly = True
        Me.txtDateTo.Size = New System.Drawing.Size(108, 27)
        Me.txtDateTo.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSubmit)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtBranchName)
        Me.GroupBox1.Controls.Add(Me.PanelVAT)
        Me.GroupBox1.Controls.Add(Me.btnDateFrom)
        Me.GroupBox1.Controls.Add(Me.btnDateTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(935, 239)
        Me.GroupBox1.TabIndex = 1471
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Report Filter"
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
        Me.btnSubmit.Location = New System.Drawing.Point(552, 159)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(102, 57)
        Me.btnSubmit.TabIndex = 1476
        Me.btnSubmit.Text = "&Submit"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(72, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 19)
        Me.Label6.TabIndex = 1475
        Me.Label6.Text = "Branch"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBranchName
        '
        Me.txtBranchName.Location = New System.Drawing.Point(129, 34)
        Me.txtBranchName.Name = "txtBranchName"
        Me.txtBranchName.ReadOnly = True
        Me.txtBranchName.Size = New System.Drawing.Size(295, 27)
        Me.txtBranchName.TabIndex = 1474
        '
        'PanelVAT
        '
        Me.PanelVAT.Controls.Add(Me.lblPanelVAT)
        Me.PanelVAT.Controls.Add(Me.cmbTAXType)
        Me.PanelVAT.Controls.Add(Me.Label5)
        Me.PanelVAT.Controls.Add(Me.cmbInputOutput)
        Me.PanelVAT.Controls.Add(Me.Label4)
        Me.PanelVAT.Location = New System.Drawing.Point(11, 99)
        Me.PanelVAT.Name = "PanelVAT"
        Me.PanelVAT.Size = New System.Drawing.Size(535, 120)
        Me.PanelVAT.TabIndex = 1473
        '
        'lblPanelVAT
        '
        Me.lblPanelVAT.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPanelVAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPanelVAT.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPanelVAT.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblPanelVAT.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblPanelVAT.Location = New System.Drawing.Point(0, 0)
        Me.lblPanelVAT.Name = "lblPanelVAT"
        Me.lblPanelVAT.Size = New System.Drawing.Size(535, 19)
        Me.lblPanelVAT.TabIndex = 1475
        Me.lblPanelVAT.Text = "VAT Analysis Report"
        Me.lblPanelVAT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbTAXType
        '
        Me.cmbTAXType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTAXType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTAXType.FormattingEnabled = True
        Me.cmbTAXType.Items.AddRange(New Object() {"<...> - (All/Blank)", "VAT - (Standard Rate)", "Zero-VAT - (Zero Rated)", "EXEMPT - (Exempt Rated)"})
        Me.cmbTAXType.Location = New System.Drawing.Point(113, 60)
        Me.cmbTAXType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTAXType.Name = "cmbTAXType"
        Me.cmbTAXType.Size = New System.Drawing.Size(186, 28)
        Me.cmbTAXType.TabIndex = 1474
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(61, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 19)
        Me.Label5.TabIndex = 1473
        Me.Label5.Text = "Tax ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbInputOutput
        '
        Me.cmbInputOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInputOutput.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInputOutput.FormattingEnabled = True
        Me.cmbInputOutput.Items.AddRange(New Object() {"Input - Payables", "Output - Receivables"})
        Me.cmbInputOutput.Location = New System.Drawing.Point(113, 32)
        Me.cmbInputOutput.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbInputOutput.Name = "cmbInputOutput"
        Me.cmbInputOutput.Size = New System.Drawing.Size(186, 28)
        Me.cmbInputOutput.TabIndex = 1472
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(14, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 19)
        Me.Label4.TabIndex = 1471
        Me.Label4.Text = "Input/Output"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDateFrom
        '
        Me.btnDateFrom.BackColor = System.Drawing.Color.Transparent
        Me.btnDateFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDateFrom.FlatAppearance.BorderSize = 0
        Me.btnDateFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDateFrom.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDateFrom.ForeColor = System.Drawing.Color.White
        Me.btnDateFrom.Image = CType(resources.GetObject("btnDateFrom.Image"), System.Drawing.Image)
        Me.btnDateFrom.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDateFrom.Location = New System.Drawing.Point(237, 61)
        Me.btnDateFrom.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnDateFrom.Name = "btnDateFrom"
        Me.btnDateFrom.Size = New System.Drawing.Size(25, 27)
        Me.btnDateFrom.TabIndex = 3
        Me.btnDateFrom.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDateFrom.UseVisualStyleBackColor = False
        '
        'btnDateTo
        '
        Me.btnDateTo.BackColor = System.Drawing.Color.Transparent
        Me.btnDateTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDateTo.FlatAppearance.BorderSize = 0
        Me.btnDateTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDateTo.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDateTo.ForeColor = System.Drawing.Color.White
        Me.btnDateTo.Image = CType(resources.GetObject("btnDateTo.Image"), System.Drawing.Image)
        Me.btnDateTo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDateTo.Location = New System.Drawing.Point(424, 61)
        Me.btnDateTo.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnDateTo.Name = "btnDateTo"
        Me.btnDateTo.Size = New System.Drawing.Size(25, 27)
        Me.btnDateTo.TabIndex = 5
        Me.btnDateTo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDateTo.UseVisualStyleBackColor = False
        '
        'RadGridView1
        '
        Me.RadGridView1.BackColor = System.Drawing.SystemColors.Control
        Me.RadGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadGridView1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView1.Location = New System.Drawing.Point(3, 51)
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
        Me.RadGridView1.Size = New System.Drawing.Size(931, 274)
        Me.RadGridView1.TabIndex = 1472
        Me.RadGridView1.Text = "RadGridView2"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Controls.Add(Me.lblFound)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.RadGridView1)
        Me.Panel1.Controls.Add(Me.btnExcel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 344)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(935, 352)
        Me.Panel1.TabIndex = 1474
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 328)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(935, 24)
        Me.StatusStrip1.TabIndex = 1479
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(47, 19)
        Me.ToolStripStatusLabel1.Text = "Status"
        '
        'lblFound
        '
        Me.lblFound.AutoSize = True
        Me.lblFound.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblFound.Location = New System.Drawing.Point(12, 27)
        Me.lblFound.Name = "lblFound"
        Me.lblFound.Size = New System.Drawing.Size(0, 19)
        Me.lblFound.TabIndex = 1478
        Me.lblFound.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(572, 23)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(190, 23)
        Me.ProgressBar1.TabIndex = 1477
        Me.ProgressBar1.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(768, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 19)
        Me.Label8.TabIndex = 1476
        Me.Label8.Text = "Export to Excel >"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(935, 19)
        Me.Label7.TabIndex = 1475
        Me.Label7.Text = "Preview Data"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnExcel
        '
        Me.btnExcel.AutoSize = True
        Me.btnExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.Color.White
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcel.Location = New System.Drawing.Point(895, 20)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(30, 30)
        Me.btnExcel.TabIndex = 1459
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(935, 696)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbReportType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmReports"
        Me.Text = "Reports"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelVAT.ResumeLayout(False)
        Me.PanelVAT.PerformLayout()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblItemCodeName As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents cmbReportType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDateFrom As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnDateTo As System.Windows.Forms.Button
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PanelVAT As System.Windows.Forms.Panel
    Friend WithEvents lblPanelVAT As System.Windows.Forms.Label
    Friend WithEvents cmbTAXType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbInputOutput As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBranchName As System.Windows.Forms.TextBox
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFound As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
