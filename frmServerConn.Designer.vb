<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServerConn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServerConn))
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkBlankPassAllowed = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkUseWindowsSecurity = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFindServers = New System.Windows.Forms.Button()
        Me.cmbServers = New System.Windows.Forms.ComboBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.groupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.chkBlankPassAllowed)
        Me.groupBox2.Controls.Add(Me.Label2)
        Me.groupBox2.Controls.Add(Me.txtPassword)
        Me.groupBox2.Controls.Add(Me.txtUserName)
        Me.groupBox2.Controls.Add(Me.Label1)
        Me.groupBox2.Controls.Add(Me.chkUseWindowsSecurity)
        Me.groupBox2.Location = New System.Drawing.Point(16, 101)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(260, 140)
        Me.groupBox2.TabIndex = 1039
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Windows Security"
        '
        'chkBlankPassAllowed
        '
        Me.chkBlankPassAllowed.AutoSize = True
        Me.chkBlankPassAllowed.Location = New System.Drawing.Point(7, 68)
        Me.chkBlankPassAllowed.Name = "chkBlankPassAllowed"
        Me.chkBlankPassAllowed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBlankPassAllowed.Size = New System.Drawing.Size(140, 17)
        Me.chkBlankPassAllowed.TabIndex = 9
        Me.chkBlankPassAllowed.Text = "Blank Password Allowed"
        Me.chkBlankPassAllowed.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(72, 91)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(182, 20)
        Me.txtPassword.TabIndex = 10
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(72, 41)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(182, 20)
        Me.txtUserName.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "User Name"
        '
        'chkUseWindowsSecurity
        '
        Me.chkUseWindowsSecurity.AutoSize = True
        Me.chkUseWindowsSecurity.Checked = True
        Me.chkUseWindowsSecurity.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseWindowsSecurity.Location = New System.Drawing.Point(6, 19)
        Me.chkUseWindowsSecurity.Name = "chkUseWindowsSecurity"
        Me.chkUseWindowsSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkUseWindowsSecurity.Size = New System.Drawing.Size(132, 17)
        Me.chkUseWindowsSecurity.TabIndex = 6
        Me.chkUseWindowsSecurity.Text = "Use Windows Security"
        Me.chkUseWindowsSecurity.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 247)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(299, 50)
        Me.Panel2.TabIndex = 1037
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(7, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 32)
        Me.Button1.TabIndex = 1038
        Me.Button1.Text = "خروج"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(172, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 32)
        Me.Button2.TabIndex = 1037
        Me.Button2.Text = "اتصال"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnFindServers)
        Me.groupBox1.Controls.Add(Me.cmbServers)
        Me.groupBox1.Location = New System.Drawing.Point(16, 28)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.groupBox1.Size = New System.Drawing.Size(260, 49)
        Me.groupBox1.TabIndex = 1038
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "قم باختيار أو كتابة اسم السيكوال سيرفر"
        '
        'btnFindServers
        '
        Me.btnFindServers.Location = New System.Drawing.Point(7, 18)
        Me.btnFindServers.Name = "btnFindServers"
        Me.btnFindServers.Size = New System.Drawing.Size(35, 23)
        Me.btnFindServers.TabIndex = 1
        Me.btnFindServers.Text = "..."
        Me.btnFindServers.UseVisualStyleBackColor = True
        '
        'cmbServers
        '
        Me.cmbServers.FormattingEnabled = True
        Me.cmbServers.Location = New System.Drawing.Point(47, 19)
        Me.cmbServers.Name = "cmbServers"
        Me.cmbServers.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbServers.Size = New System.Drawing.Size(207, 21)
        Me.cmbServers.TabIndex = 0
        '
        'Timer2
        '
        '
        'frmServerConn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(299, 297)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServerConn"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الاتصال بملقم قواعد البيانات"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents Button2 As Button
    Private WithEvents groupBox2 As GroupBox
    Friend WithEvents chkBlankPassAllowed As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkUseWindowsSecurity As CheckBox
    Friend WithEvents Panel2 As Panel
    Private WithEvents Button1 As Button
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents btnFindServers As Button
    Private WithEvents cmbServers As ComboBox
    Friend WithEvents Timer2 As Timer
End Class
