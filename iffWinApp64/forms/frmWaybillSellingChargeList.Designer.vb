<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWaybillSellingChargeList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWaybillSellingChargeList))
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblPostStatus = New System.Windows.Forms.Label()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtServiceCharge = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServiceAmount = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTotalVAT = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotal = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAdditionalRoute = New Telerik.WinControls.UI.RadTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnOkVendor = New System.Windows.Forms.Button()
        Me.lnkSellingRate = New System.Windows.Forms.LinkLabel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lnkVATCalculation = New System.Windows.Forms.LinkLabel()
        Me.panelHeader.SuspendLayout()
        CType(Me.txtServiceCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServiceAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalVAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdditionalRoute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblPostStatus)
        Me.panelHeader.Controls.Add(Me.lblFormTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(477, 32)
        Me.panelHeader.TabIndex = 69
        '
        'lblPostStatus
        '
        Me.lblPostStatus.AutoSize = True
        Me.lblPostStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPostStatus.ForeColor = System.Drawing.Color.White
        Me.lblPostStatus.Location = New System.Drawing.Point(911, 9)
        Me.lblPostStatus.Name = "lblPostStatus"
        Me.lblPostStatus.Size = New System.Drawing.Size(0, 20)
        Me.lblPostStatus.TabIndex = 43
        Me.lblPostStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFormTitle
        '
        Me.lblFormTitle.AutoSize = True
        Me.lblFormTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormTitle.ForeColor = System.Drawing.Color.White
        Me.lblFormTitle.Location = New System.Drawing.Point(3, 9)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Size = New System.Drawing.Size(119, 20)
        Me.lblFormTitle.TabIndex = 42
        Me.lblFormTitle.Text = "<Billing Client>"
        Me.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 17)
        Me.Label14.TabIndex = 2373
        Me.Label14.Text = "Service Charge:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtServiceCharge
        '
        Me.txtServiceCharge.BackColor = System.Drawing.Color.Azure
        Me.txtServiceCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServiceCharge.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtServiceCharge.Location = New System.Drawing.Point(141, 51)
        Me.txtServiceCharge.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtServiceCharge.MaxLength = 11
        Me.txtServiceCharge.Name = "txtServiceCharge"
        Me.txtServiceCharge.ReadOnly = True
        Me.txtServiceCharge.Size = New System.Drawing.Size(304, 24)
        Me.txtServiceCharge.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 18)
        Me.Label1.TabIndex = 2375
        Me.Label1.Text = "Selling Rates"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 2376
        Me.Label2.Text = "Amount:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtServiceAmount
        '
        Me.txtServiceAmount.BackColor = System.Drawing.Color.White
        Me.txtServiceAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServiceAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceAmount.Location = New System.Drawing.Point(141, 129)
        Me.txtServiceAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtServiceAmount.MaxLength = 11
        Me.txtServiceAmount.Name = "txtServiceAmount"
        Me.txtServiceAmount.Size = New System.Drawing.Size(119, 23)
        Me.txtServiceAmount.TabIndex = 1
        Me.txtServiceAmount.Text = "0"
        Me.txtServiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalVAT
        '
        Me.txtTotalVAT.BackColor = System.Drawing.Color.White
        Me.txtTotalVAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalVAT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVAT.Location = New System.Drawing.Point(141, 152)
        Me.txtTotalVAT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalVAT.MaxLength = 11
        Me.txtTotalVAT.Name = "txtTotalVAT"
        Me.txtTotalVAT.Size = New System.Drawing.Size(119, 23)
        Me.txtTotalVAT.TabIndex = 2
        Me.txtTotalVAT.Text = "0"
        Me.txtTotalVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 2378
        Me.Label3.Text = "VAT Charges:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Azure
        Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(141, 175)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotal.MaxLength = 11
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(119, 23)
        Me.txtTotal.TabIndex = 2384
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 17)
        Me.Label4.TabIndex = 2385
        Me.Label4.Text = "Total Charges:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAdditionalRoute
        '
        Me.txtAdditionalRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdditionalRoute.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtAdditionalRoute.Location = New System.Drawing.Point(141, 206)
        Me.txtAdditionalRoute.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAdditionalRoute.MaxLength = 50
        Me.txtAdditionalRoute.Name = "txtAdditionalRoute"
        Me.txtAdditionalRoute.Size = New System.Drawing.Size(304, 24)
        Me.txtAdditionalRoute.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(98, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 17)
        Me.Label5.TabIndex = 2416
        Me.Label5.Text = "Note:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnOkVendor.Location = New System.Drawing.Point(407, 235)
        Me.btnOkVendor.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnOkVendor.Name = "btnOkVendor"
        Me.btnOkVendor.Size = New System.Drawing.Size(38, 38)
        Me.btnOkVendor.TabIndex = 4
        Me.btnOkVendor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOkVendor.UseVisualStyleBackColor = False
        '
        'lnkSellingRate
        '
        Me.lnkSellingRate.AutoSize = True
        Me.lnkSellingRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkSellingRate.Location = New System.Drawing.Point(286, 129)
        Me.lnkSellingRate.Name = "lnkSellingRate"
        Me.lnkSellingRate.Size = New System.Drawing.Size(179, 17)
        Me.lnkSellingRate.TabIndex = 2418
        Me.lnkSellingRate.TabStop = True
        Me.lnkSellingRate.Text = "Get Transport Selling Rate"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMessage.Location = New System.Drawing.Point(22, 257)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(87, 16)
        Me.lblMessage.TabIndex = 2419
        Me.lblMessage.Text = "Rate Update"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkVATCalculation
        '
        Me.lnkVATCalculation.AutoSize = True
        Me.lnkVATCalculation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkVATCalculation.Location = New System.Drawing.Point(286, 154)
        Me.lnkVATCalculation.Name = "lnkVATCalculation"
        Me.lnkVATCalculation.Size = New System.Drawing.Size(123, 17)
        Me.lnkVATCalculation.TabIndex = 2420
        Me.lnkVATCalculation.TabStop = True
        Me.lnkVATCalculation.Text = "Calculate VAT 5%"
        '
        'frmWaybillSellingChargeList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 283)
        Me.Controls.Add(Me.txtServiceAmount)
        Me.Controls.Add(Me.lnkVATCalculation)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lnkSellingRate)
        Me.Controls.Add(Me.btnOkVendor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAdditionalRoute)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtTotalVAT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtServiceCharge)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmWaybillSellingChargeList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transport Selling Charge List"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.txtServiceCharge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServiceAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalVAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdditionalRoute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelHeader As System.Windows.Forms.Panel
    Friend WithEvents lblPostStatus As System.Windows.Forms.Label
    Friend WithEvents lblFormTitle As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtServiceCharge As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServiceAmount As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalVAT As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAdditionalRoute As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnOkVendor As System.Windows.Forms.Button
    Friend WithEvents lnkSellingRate As System.Windows.Forms.LinkLabel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lnkVATCalculation As System.Windows.Forms.LinkLabel
End Class
