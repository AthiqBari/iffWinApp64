<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.radTextPassword = New Telerik.WinControls.UI.RadTextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.radTextUser = New Telerik.WinControls.UI.RadTextBox()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radTextPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radTextUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.White
        Me.RadGroupBox1.Controls.Add(Me.Label2)
        Me.RadGroupBox1.Controls.Add(Me.PictureBox3)
        Me.RadGroupBox1.Controls.Add(Me.Label1)
        Me.RadGroupBox1.Controls.Add(Me.lblMsg)
        Me.RadGroupBox1.Controls.Add(Me.RadButton1)
        Me.RadGroupBox1.Controls.Add(Me.Label37)
        Me.RadGroupBox1.Controls.Add(Me.radTextPassword)
        Me.RadGroupBox1.Controls.Add(Me.Label38)
        Me.RadGroupBox1.Controls.Add(Me.radTextUser)
        Me.RadGroupBox1.HeaderText = " - User Access Credentials -"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(622, 259)
        Me.RadGroupBox1.TabIndex = 75
        Me.RadGroupBox1.Text = " - User Access Credentials -"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 237)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(228, 17)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "International Freight Forwarding System V 2.5"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(8, 26)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(144, 62)
        Me.PictureBox3.TabIndex = 78
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(522, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 19)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = ".Net Framework 4.5"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMsg.Location = New System.Drawing.Point(65, 181)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 15)
        Me.lblMsg.TabIndex = 74
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(232, 144)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(137, 30)
        Me.RadButton1.TabIndex = 72
        Me.RadButton1.Text = "Submit"
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(89, 87)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(136, 19)
        Me.Label37.TabIndex = 68
        Me.Label37.Text = "Username:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radTextPassword
        '
        Me.radTextPassword.Location = New System.Drawing.Point(232, 111)
        Me.radTextPassword.Name = "radTextPassword"
        Me.radTextPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.radTextPassword.Size = New System.Drawing.Size(214, 24)
        Me.radTextPassword.TabIndex = 71
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(89, 112)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(136, 19)
        Me.Label38.TabIndex = 69
        Me.Label38.Text = "Password:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radTextUser
        '
        Me.radTextUser.Location = New System.Drawing.Point(232, 87)
        Me.radTextUser.Name = "radTextUser"
        Me.radTextUser.Size = New System.Drawing.Size(214, 24)
        Me.radTextUser.TabIndex = 70
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(648, 292)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "IFF - Freight Forwarding System"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radTextPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radTextUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents radTextPassword As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents radTextUser As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
