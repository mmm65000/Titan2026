<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents Password As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.Password = New System.Windows.Forms.TextBox()
        Me.UserType = New System.Windows.Forms.TextBox()
        Me.btnRecoveryPassword = New System.Windows.Forms.Button()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.btnKeyboard = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pictureBoxClose = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button_Login = New System.Windows.Forms.Button()
        Me.pictureBox_Password = New System.Windows.Forms.PictureBox()
        Me.pictureBox_UserName = New System.Windows.Forms.PictureBox()
        Me.UserID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.pictureBoxClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox_Password, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox_UserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Password
        '
        Me.Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Password.Location = New System.Drawing.Point(57, 422)
        Me.Password.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Password.Name = "Password"
        Me.Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.Password.Size = New System.Drawing.Size(349, 26)
        Me.Password.TabIndex = 1
        '
        'UserType
        '
        Me.UserType.Location = New System.Drawing.Point(87, 87)
        Me.UserType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.UserType.Name = "UserType"
        Me.UserType.Size = New System.Drawing.Size(72, 22)
        Me.UserType.TabIndex = 10
        Me.UserType.Visible = False
        '
        'btnRecoveryPassword
        '
        Me.btnRecoveryPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecoveryPassword.BackColor = System.Drawing.Color.White
        Me.btnRecoveryPassword.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRecoveryPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnRecoveryPassword.FlatAppearance.BorderSize = 0
        Me.btnRecoveryPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRecoveryPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecoveryPassword.Image = CType(resources.GetObject("btnRecoveryPassword.Image"), System.Drawing.Image)
        Me.btnRecoveryPassword.Location = New System.Drawing.Point(96, 497)
        Me.btnRecoveryPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRecoveryPassword.Name = "btnRecoveryPassword"
        Me.btnRecoveryPassword.Size = New System.Drawing.Size(69, 60)
        Me.btnRecoveryPassword.TabIndex = 61
        Me.btnRecoveryPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRecoveryPassword.UseVisualStyleBackColor = False
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangePassword.BackColor = System.Drawing.Color.White
        Me.btnChangePassword.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnChangePassword.FlatAppearance.BorderSize = 0
        Me.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChangePassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePassword.Image = CType(resources.GetObject("btnChangePassword.Image"), System.Drawing.Image)
        Me.btnChangePassword.Location = New System.Drawing.Point(281, 497)
        Me.btnChangePassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(69, 60)
        Me.btnChangePassword.TabIndex = 60
        Me.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChangePassword.UseVisualStyleBackColor = False
        '
        'btnKeyboard
        '
        Me.btnKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKeyboard.BackColor = System.Drawing.Color.White
        Me.btnKeyboard.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnKeyboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnKeyboard.FlatAppearance.BorderSize = 0
        Me.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnKeyboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeyboard.Image = Global.Sales_and_Inventory_System.My.Resources.Resources.ModernXP_09_Keyboard_icon__1_1
        Me.btnKeyboard.Location = New System.Drawing.Point(185, 497)
        Me.btnKeyboard.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnKeyboard.Name = "btnKeyboard"
        Me.btnKeyboard.Size = New System.Drawing.Size(69, 60)
        Me.btnKeyboard.TabIndex = 59
        Me.btnKeyboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeyboard.UseVisualStyleBackColor = False
        '
        'pictureBoxClose
        '
        Me.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictureBoxClose.Image = CType(resources.GetObject("pictureBoxClose.Image"), System.Drawing.Image)
        Me.pictureBoxClose.Location = New System.Drawing.Point(365, -12)
        Me.pictureBoxClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBoxClose.Name = "pictureBoxClose"
        Me.pictureBoxClose.Size = New System.Drawing.Size(50, 50)
        Me.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBoxClose.TabIndex = 63
        Me.pictureBoxClose.TabStop = False
        Me.pictureBoxClose.Tag = ""
        Me.ToolTip1.SetToolTip(Me.pictureBoxClose, "Close !")
        '
        'Button_Login
        '
        Me.Button_Login.BackColor = System.Drawing.Color.Transparent
        Me.Button_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Login.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Login.FlatAppearance.BorderSize = 0
        Me.Button_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Button_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Login.ForeColor = System.Drawing.Color.White
        Me.Button_Login.Image = CType(resources.GetObject("Button_Login.Image"), System.Drawing.Image)
        Me.Button_Login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Login.Location = New System.Drawing.Point(12, 566)
        Me.Button_Login.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_Login.Name = "Button_Login"
        Me.Button_Login.Size = New System.Drawing.Size(407, 54)
        Me.Button_Login.TabIndex = 64
        Me.Button_Login.Text = "LOGIN"
        Me.Button_Login.UseVisualStyleBackColor = False
        '
        'pictureBox_Password
        '
        Me.pictureBox_Password.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pictureBox_Password.Image = CType(resources.GetObject("pictureBox_Password.Image"), System.Drawing.Image)
        Me.pictureBox_Password.Location = New System.Drawing.Point(5, 417)
        Me.pictureBox_Password.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox_Password.Name = "pictureBox_Password"
        Me.pictureBox_Password.Size = New System.Drawing.Size(32, 32)
        Me.pictureBox_Password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox_Password.TabIndex = 67
        Me.pictureBox_Password.TabStop = False
        Me.pictureBox_Password.Tag = ""
        '
        'pictureBox_UserName
        '
        Me.pictureBox_UserName.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pictureBox_UserName.Image = CType(resources.GetObject("pictureBox_UserName.Image"), System.Drawing.Image)
        Me.pictureBox_UserName.Location = New System.Drawing.Point(7, 348)
        Me.pictureBox_UserName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox_UserName.Name = "pictureBox_UserName"
        Me.pictureBox_UserName.Size = New System.Drawing.Size(32, 32)
        Me.pictureBox_UserName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox_UserName.TabIndex = 66
        Me.pictureBox_UserName.TabStop = False
        Me.pictureBox_UserName.Tag = ""
        '
        'UserID
        '
        Me.UserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UserID.FormattingEnabled = True
        Me.UserID.Location = New System.Drawing.Point(57, 350)
        Me.UserID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.UserID.Name = "UserID"
        Me.UserID.Size = New System.Drawing.Size(349, 28)
        Me.UserID.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Brush Script MT", 26.25!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(88, 263)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 54)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Welcome Back !"
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(-4, 57)
        Me.pictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(423, 231)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 65
        Me.pictureBox1.TabStop = False
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(424, 635)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pictureBox_Password)
        Me.Controls.Add(Me.pictureBox_UserName)
        Me.Controls.Add(Me.Button_Login)
        Me.Controls.Add(Me.pictureBoxClose)
        Me.Controls.Add(Me.UserType)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnRecoveryPassword)
        Me.Controls.Add(Me.UserID)
        Me.Controls.Add(Me.btnKeyboard)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.pictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pictureBoxClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox_Password, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox_UserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserType As System.Windows.Forms.TextBox
    Friend WithEvents btnRecoveryPassword As System.Windows.Forms.Button
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
    Friend WithEvents btnKeyboard As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As Timer
    Private WithEvents pictureBoxClose As PictureBox
    Private WithEvents Button_Login As Button
    Private WithEvents pictureBox_Password As PictureBox
    Private WithEvents pictureBox_UserName As PictureBox
    Friend WithEvents UserID As ComboBox
    Friend WithEvents Label1 As Label
    Private WithEvents pictureBox1 As PictureBox
End Class
