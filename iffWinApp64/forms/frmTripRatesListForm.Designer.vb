<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTripRatesListForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTripRatesListForm))
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblx = New System.Windows.Forms.Label()
        Me.cmbListLocation = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lnkLoadRouteList = New System.Windows.Forms.LinkLabel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnSaveEntry = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DgridWaybillList = New Telerik.WinControls.UI.RadGridView()
        Me.panelHeader.SuspendLayout()
        CType(Me.cmbListLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbListLocation.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbListLocation.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DgridWaybillList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgridWaybillList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblx)
        Me.panelHeader.Controls.Add(Me.cmbListLocation)
        Me.panelHeader.Controls.Add(Me.btnOK)
        Me.panelHeader.Controls.Add(Me.lnkLoadRouteList)
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(652, 105)
        Me.panelHeader.TabIndex = 68
        '
        'lblx
        '
        Me.lblx.AutoSize = True
        Me.lblx.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblx.ForeColor = System.Drawing.Color.White
        Me.lblx.Location = New System.Drawing.Point(15, 52)
        Me.lblx.Name = "lblx"
        Me.lblx.Size = New System.Drawing.Size(163, 17)
        Me.lblx.TabIndex = 2359
        Me.lblx.Text = "Select Loading Location"
        '
        'cmbListLocation
        '
        Me.cmbListLocation.AutoSize = True
        Me.cmbListLocation.BackColor = System.Drawing.Color.GhostWhite
        '
        'cmbListLocation.NestedRadGridView
        '
        Me.cmbListLocation.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbListLocation.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListLocation.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbListLocation.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbListLocation.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbListLocation.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbListLocation.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbListLocation.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbListLocation.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbListLocation.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.cmbListLocation.EditorControl.Name = "NestedRadGridView"
        Me.cmbListLocation.EditorControl.ReadOnly = True
        Me.cmbListLocation.EditorControl.ShowGroupPanel = False
        Me.cmbListLocation.EditorControl.Size = New System.Drawing.Size(300, 187)
        Me.cmbListLocation.EditorControl.TabIndex = 0
        Me.cmbListLocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListLocation.Location = New System.Drawing.Point(15, 72)
        Me.cmbListLocation.Name = "cmbListLocation"
        Me.cmbListLocation.Size = New System.Drawing.Size(590, 23)
        Me.cmbListLocation.TabIndex = 45
        Me.cmbListLocation.TabStop = False
        Me.cmbListLocation.Visible = False
        '
        'btnOK
        '
        Me.btnOK.AutoSize = True
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOK.Location = New System.Drawing.Point(611, 63)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(38, 38)
        Me.btnOK.TabIndex = 2358
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lnkLoadRouteList
        '
        Me.lnkLoadRouteList.AutoSize = True
        Me.lnkLoadRouteList.Location = New System.Drawing.Point(12, 72)
        Me.lnkLoadRouteList.Name = "lnkLoadRouteList"
        Me.lnkLoadRouteList.Size = New System.Drawing.Size(189, 16)
        Me.lnkLoadRouteList.TabIndex = 2
        Me.lnkLoadRouteList.TabStop = True
        Me.lnkLoadRouteList.Text = "Change the Source Location"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(479, 53)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Listing Tariff of all Destination from [SAJED] for selected Equipment [6TON......" & _
    "...............................]"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.lblMessage)
        Me.Panel1.Controls.Add(Me.btnSaveEntry)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 565)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(652, 58)
        Me.Panel1.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(15, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 2360
        Me.Label1.Text = "unlocode:"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.ForeColor = System.Drawing.Color.Silver
        Me.TextBox1.Location = New System.Drawing.Point(85, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(420, 15)
        Me.TextBox1.TabIndex = 2359
        Me.TextBox1.Text = "https://service.unece.org/trade/locode/sa.htm"
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMessage.Location = New System.Drawing.Point(12, 9)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(143, 22)
        Me.lblMessage.TabIndex = 2358
        Me.lblMessage.Text = "Search Result"
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
        Me.btnSaveEntry.Location = New System.Drawing.Point(602, 7)
        Me.btnSaveEntry.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnSaveEntry.Name = "btnSaveEntry"
        Me.btnSaveEntry.Size = New System.Drawing.Size(38, 38)
        Me.btnSaveEntry.TabIndex = 2357
        Me.btnSaveEntry.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveEntry.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DgridWaybillList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 105)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(652, 460)
        Me.Panel2.TabIndex = 70
        '
        'DgridWaybillList
        '
        Me.DgridWaybillList.BackColor = System.Drawing.SystemColors.Control
        Me.DgridWaybillList.Cursor = System.Windows.Forms.Cursors.Default
        Me.DgridWaybillList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgridWaybillList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgridWaybillList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgridWaybillList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DgridWaybillList.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.DgridWaybillList.MasterTemplate.AllowAddNewRow = False
        Me.DgridWaybillList.MasterTemplate.EnableGrouping = False
        Me.DgridWaybillList.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgridWaybillList.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.DgridWaybillList.Name = "DgridWaybillList"
        Me.DgridWaybillList.ReadOnly = True
        Me.DgridWaybillList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgridWaybillList.Size = New System.Drawing.Size(652, 460)
        Me.DgridWaybillList.TabIndex = 2329
        '
        'frmTripRatesListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 623)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTripRatesListForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trip Rates"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.cmbListLocation.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbListLocation.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbListLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DgridWaybillList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgridWaybillList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DgridWaybillList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnSaveEntry As System.Windows.Forms.Button
    Friend WithEvents lnkLoadRouteList As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cmbListLocation As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblx As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
