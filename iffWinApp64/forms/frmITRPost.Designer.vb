<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmITRPost
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmITRPost))
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtITRNo = New Telerik.WinControls.UI.RadTextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblITRDate = New System.Windows.Forms.Label()
        Me.lblWbNo = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblJobno = New System.Windows.Forms.Label()
        Me.txtAccountTrn = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblITRRem = New System.Windows.Forms.Label()
        Me.txtVendorInv = New Telerik.WinControls.UI.RadTextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkPosted = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPaymentNote = New Telerik.WinControls.UI.RadTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalChg = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTotalAdvance = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTotalVAT = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTotalDue = New Telerik.WinControls.UI.RadTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        CType(Me.txtITRNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountTrn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaymentNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalChg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalVAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(12, 9)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(393, 18)
        Me.Label36.TabIndex = 2426
        Me.Label36.Text = "Mark ITR Receipt with Posted Account Transaction No."
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 17)
        Me.Label1.TabIndex = 2427
        Me.Label1.Text = "Enter ITR Number:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtITRNo
        '
        Me.txtITRNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtITRNo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtITRNo.Location = New System.Drawing.Point(175, 46)
        Me.txtITRNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtITRNo.MaxLength = 10
        Me.txtITRNo.Name = "txtITRNo"
        Me.txtITRNo.Size = New System.Drawing.Size(105, 24)
        Me.txtITRNo.TabIndex = 2428
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
        Me.btnSubmit.Location = New System.Drawing.Point(286, 37)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(38, 38)
        Me.btnSubmit.TabIndex = 2429
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'lblITRDate
        '
        Me.lblITRDate.AutoSize = True
        Me.lblITRDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblITRDate.Location = New System.Drawing.Point(50, 129)
        Me.lblITRDate.Name = "lblITRDate"
        Me.lblITRDate.Size = New System.Drawing.Size(154, 17)
        Me.lblITRDate.TabIndex = 2430
        Me.lblITRDate.Text = "ITR Date: [01/01/2018]"
        Me.lblITRDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWbNo
        '
        Me.lblWbNo.AutoSize = True
        Me.lblWbNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWbNo.Location = New System.Drawing.Point(50, 157)
        Me.lblWbNo.Name = "lblWbNo"
        Me.lblWbNo.Size = New System.Drawing.Size(128, 17)
        Me.lblWbNo.TabIndex = 2431
        Me.lblWbNo.Text = "Waybill No.: [9999]"
        Me.lblWbNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(119, 16)
        Me.Label15.TabIndex = 2432
        Me.Label15.Text = "Transport Detail"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblJobno
        '
        Me.lblJobno.AutoSize = True
        Me.lblJobno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobno.Location = New System.Drawing.Point(327, 129)
        Me.lblJobno.Name = "lblJobno"
        Me.lblJobno.Size = New System.Drawing.Size(111, 17)
        Me.lblJobno.TabIndex = 2433
        Me.lblJobno.Text = "Job Number: [n]"
        Me.lblJobno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAccountTrn
        '
        Me.txtAccountTrn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountTrn.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtAccountTrn.Location = New System.Drawing.Point(158, 348)
        Me.txtAccountTrn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAccountTrn.MaxLength = 20
        Me.txtAccountTrn.Name = "txtAccountTrn"
        Me.txtAccountTrn.Size = New System.Drawing.Size(166, 24)
        Me.txtAccountTrn.TabIndex = 2435
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-2, 351)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 17)
        Me.Label2.TabIndex = 2434
        Me.Label2.Text = "Enter Account Trn No.:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 17)
        Me.Label3.TabIndex = 2436
        Me.Label3.Text = "Vendor Invoice No.:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblITRRem
        '
        Me.lblITRRem.AutoSize = True
        Me.lblITRRem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblITRRem.Location = New System.Drawing.Point(50, 185)
        Me.lblITRRem.Name = "lblITRRem"
        Me.lblITRRem.Size = New System.Drawing.Size(94, 17)
        Me.lblITRRem.TabIndex = 2437
        Me.lblITRRem.Text = "Remark : [xx]"
        Me.lblITRRem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVendorInv
        '
        Me.txtVendorInv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorInv.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtVendorInv.Location = New System.Drawing.Point(158, 372)
        Me.txtVendorInv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVendorInv.MaxLength = 20
        Me.txtVendorInv.Name = "txtVendorInv"
        Me.txtVendorInv.Size = New System.Drawing.Size(166, 24)
        Me.txtVendorInv.TabIndex = 2436
        '
        'btnSave
        '
        Me.btnSave.AutoSize = True
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.Location = New System.Drawing.Point(482, 427)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 1, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(38, 38)
        Me.btnSave.TabIndex = 2438
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'chkPosted
        '
        Me.chkPosted.AutoSize = True
        Me.chkPosted.Checked = True
        Me.chkPosted.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPosted.Location = New System.Drawing.Point(157, 427)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.Size = New System.Drawing.Size(167, 22)
        Me.chkPosted.TabIndex = 2439
        Me.chkPosted.Text = "Post ITR Document"
        Me.chkPosted.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(50, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 17)
        Me.Label5.TabIndex = 2440
        Me.Label5.Text = "Total Charges:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPaymentNote
        '
        Me.txtPaymentNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentNote.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtPaymentNote.Location = New System.Drawing.Point(158, 396)
        Me.txtPaymentNote.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPaymentNote.MaxLength = 20
        Me.txtPaymentNote.Name = "txtPaymentNote"
        Me.txtPaymentNote.Size = New System.Drawing.Size(362, 24)
        Me.txtPaymentNote.TabIndex = 2441
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(44, 396)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 17)
        Me.Label6.TabIndex = 2442
        Me.Label6.Text = "Payment Note :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 223)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 16)
        Me.Label7.TabIndex = 2443
        Me.Label7.Text = "Payment Detail"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 274)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 17)
        Me.Label8.TabIndex = 2445
        Me.Label8.Text = "Advance Payment:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(83, 297)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 17)
        Me.Label11.TabIndex = 2447
        Me.Label11.Text = "Total VAT:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalChg
        '
        Me.txtTotalChg.BackColor = System.Drawing.Color.Azure
        Me.txtTotalChg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalChg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalChg.Location = New System.Drawing.Point(158, 251)
        Me.txtTotalChg.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalChg.MaxLength = 11
        Me.txtTotalChg.Name = "txtTotalChg"
        Me.txtTotalChg.ReadOnly = True
        Me.txtTotalChg.Size = New System.Drawing.Size(90, 23)
        Me.txtTotalChg.TabIndex = 2450
        Me.txtTotalChg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalAdvance
        '
        Me.txtTotalAdvance.BackColor = System.Drawing.Color.Azure
        Me.txtTotalAdvance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalAdvance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAdvance.Location = New System.Drawing.Point(158, 274)
        Me.txtTotalAdvance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalAdvance.MaxLength = 11
        Me.txtTotalAdvance.Name = "txtTotalAdvance"
        Me.txtTotalAdvance.ReadOnly = True
        Me.txtTotalAdvance.Size = New System.Drawing.Size(90, 23)
        Me.txtTotalAdvance.TabIndex = 2451
        Me.txtTotalAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalVAT
        '
        Me.txtTotalVAT.BackColor = System.Drawing.Color.Azure
        Me.txtTotalVAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalVAT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVAT.Location = New System.Drawing.Point(158, 297)
        Me.txtTotalVAT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalVAT.MaxLength = 11
        Me.txtTotalVAT.Name = "txtTotalVAT"
        Me.txtTotalVAT.ReadOnly = True
        Me.txtTotalVAT.Size = New System.Drawing.Size(90, 23)
        Me.txtTotalVAT.TabIndex = 2452
        Me.txtTotalVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDue
        '
        Me.txtTotalDue.BackColor = System.Drawing.Color.Azure
        Me.txtTotalDue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalDue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDue.Location = New System.Drawing.Point(408, 297)
        Me.txtTotalDue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalDue.MaxLength = 11
        Me.txtTotalDue.Name = "txtTotalDue"
        Me.txtTotalDue.ReadOnly = True
        Me.txtTotalDue.Size = New System.Drawing.Size(90, 23)
        Me.txtTotalDue.TabIndex = 2454
        Me.txtTotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(261, 297)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 17)
        Me.Label9.TabIndex = 2453
        Me.Label9.Text = "Total Amount To Pay:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMsg.Location = New System.Drawing.Point(342, 46)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 17)
        Me.lblMsg.TabIndex = 2455
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmITRPost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(569, 480)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.txtTotalDue)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalVAT)
        Me.Controls.Add(Me.txtTotalAdvance)
        Me.Controls.Add(Me.txtTotalChg)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPaymentNote)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkPosted)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtVendorInv)
        Me.Controls.Add(Me.lblITRRem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAccountTrn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblJobno)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblWbNo)
        Me.Controls.Add(Me.lblITRDate)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtITRNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label36)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmITRPost"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transport Payment Receipt [ITR] Acknowledgement"
        CType(Me.txtITRNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountTrn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaymentNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalChg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalVAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtITRNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblITRDate As System.Windows.Forms.Label
    Friend WithEvents lblWbNo As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblJobno As System.Windows.Forms.Label
    Friend WithEvents txtAccountTrn As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblITRRem As System.Windows.Forms.Label
    Friend WithEvents txtVendorInv As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkPosted As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentNote As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalChg As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalAdvance As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalVAT As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalDue As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
End Class
