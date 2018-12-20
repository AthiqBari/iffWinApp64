<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuotationPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuotationPrint))
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblItemCodeName = New System.Windows.Forms.Label()
        Me.txtQuotationNumber = New Telerik.WinControls.UI.RadTextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.RadGridView2 = New Telerik.WinControls.UI.RadGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelHeader.SuspendLayout()
        CType(Me.txtQuotationNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblItemCodeName)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(676, 55)
        Me.panelHeader.TabIndex = 67
        '
        'lblItemCodeName
        '
        Me.lblItemCodeName.AutoSize = True
        Me.lblItemCodeName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCodeName.ForeColor = System.Drawing.Color.White
        Me.lblItemCodeName.Location = New System.Drawing.Point(12, 9)
        Me.lblItemCodeName.Name = "lblItemCodeName"
        Me.lblItemCodeName.Size = New System.Drawing.Size(126, 20)
        Me.lblItemCodeName.TabIndex = 42
        Me.lblItemCodeName.Text = "Freight Quotation"
        Me.lblItemCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQuotationNumber
        '
        Me.txtQuotationNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuotationNumber.Font = New System.Drawing.Font("Segoe UI", 11.8!)
        Me.txtQuotationNumber.Location = New System.Drawing.Point(190, 117)
        Me.txtQuotationNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtQuotationNumber.MaxLength = 79
        Me.txtQuotationNumber.Name = "txtQuotationNumber"
        Me.txtQuotationNumber.Size = New System.Drawing.Size(227, 32)
        Me.txtQuotationNumber.TabIndex = 68
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
        Me.btnSubmit.Location = New System.Drawing.Point(476, 92)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(102, 57)
        Me.btnSubmit.TabIndex = 70
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(187, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 17)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Enter Last Numeric Number of Quote Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMsg.Location = New System.Drawing.Point(187, 153)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 17)
        Me.lblMsg.TabIndex = 72
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadGridView2
        '
        Me.RadGridView2.BackColor = System.Drawing.SystemColors.Control
        Me.RadGridView2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadGridView2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadGridView2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView2.Location = New System.Drawing.Point(0, 265)
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
        Me.RadGridView2.Size = New System.Drawing.Size(676, 248)
        Me.RadGridView2.TabIndex = 1473
        Me.RadGridView2.Text = "RadGridView2"
        Me.RadGridView2.ThemeName = "ControlDefault"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(-279, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 23)
        Me.Label5.TabIndex = 1472
        Me.Label5.Text = "Recent Print (15)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 17)
        Me.Label2.TabIndex = 1474
        Me.Label2.Text = "Recent Printed Quotes (Recent 100)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmQuotationPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 513)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadGridView2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtQuotationNumber)
        Me.Controls.Add(Me.panelHeader)
        Me.Name = "frmQuotationPrint"
        Me.Text = "Quotation Print"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.txtQuotationNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelHeader As System.Windows.Forms.Panel
    Friend WithEvents lblItemCodeName As System.Windows.Forms.Label
    Friend WithEvents txtQuotationNumber As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents RadGridView2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
