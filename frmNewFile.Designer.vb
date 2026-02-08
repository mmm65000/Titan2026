<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewFile))
        Me.TXT_LATIN = New System.Windows.Forms.TextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.TXT_LEVEL_CURRENCYE = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMB_CURRENCY = New System.Windows.Forms.ComboBox()
        Me.TXT_NAME = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_DATABASE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PL_4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PL_4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TXT_LATIN
        '
        Me.TXT_LATIN.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TXT_LATIN.Location = New System.Drawing.Point(38, 227)
        Me.TXT_LATIN.Name = "TXT_LATIN"
        Me.TXT_LATIN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TXT_LATIN.Size = New System.Drawing.Size(205, 24)
        Me.TXT_LATIN.TabIndex = 1064
        Me.TXT_LATIN.Text = "USD"
        Me.TXT_LATIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TXT_LATIN.Visible = False
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(249, 231)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(92, 14)
        Me.label7.TabIndex = 1065
        Me.label7.Text = "العملة انجليزي"
        Me.label7.Visible = False
        '
        'TXT_LEVEL_CURRENCYE
        '
        Me.TXT_LEVEL_CURRENCYE.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TXT_LEVEL_CURRENCYE.Location = New System.Drawing.Point(38, 255)
        Me.TXT_LEVEL_CURRENCYE.Name = "TXT_LEVEL_CURRENCYE"
        Me.TXT_LEVEL_CURRENCYE.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TXT_LEVEL_CURRENCYE.Size = New System.Drawing.Size(205, 24)
        Me.TXT_LEVEL_CURRENCYE.TabIndex = 1062
        Me.TXT_LEVEL_CURRENCYE.Text = "سنت"
        Me.TXT_LEVEL_CURRENCYE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TXT_LEVEL_CURRENCYE.Visible = False
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(249, 259)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(67, 14)
        Me.label5.TabIndex = 1063
        Me.label5.Text = "جزء العملة"
        Me.label5.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(249, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 14)
        Me.Label3.TabIndex = 1061
        Me.Label3.Text = "العملة"
        Me.Label3.Visible = False
        '
        'CMB_CURRENCY
        '
        Me.CMB_CURRENCY.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.CMB_CURRENCY.FormattingEnabled = True
        Me.CMB_CURRENCY.Items.AddRange(New Object() {"ليرة سورية", "دولار أمريكي", "درهم إماراتي", "دينار كويتي", "ريال سعودي", "دينار عراقي", "ليرة لبنانية", "دينار بحريني", "ريال قطري", "ريال يمني", "جنيه مصري", "يورو", "ريال عماني", "ليرة تركية"})
        Me.CMB_CURRENCY.Location = New System.Drawing.Point(38, 195)
        Me.CMB_CURRENCY.Name = "CMB_CURRENCY"
        Me.CMB_CURRENCY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CMB_CURRENCY.Size = New System.Drawing.Size(205, 24)
        Me.CMB_CURRENCY.TabIndex = 1060
        Me.CMB_CURRENCY.Text = "دولار أمريكي"
        Me.CMB_CURRENCY.Visible = False
        '
        'TXT_NAME
        '
        Me.TXT_NAME.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TXT_NAME.Location = New System.Drawing.Point(24, 34)
        Me.TXT_NAME.Name = "TXT_NAME"
        Me.TXT_NAME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TXT_NAME.Size = New System.Drawing.Size(317, 24)
        Me.TXT_NAME.TabIndex = 1058
        Me.TXT_NAME.Text = " "
        Me.TXT_NAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 1059
        Me.Label2.Text = "الاســــــــم"
        '
        'TXT_DATABASE
        '
        Me.TXT_DATABASE.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TXT_DATABASE.Location = New System.Drawing.Point(24, 88)
        Me.TXT_DATABASE.Name = "TXT_DATABASE"
        Me.TXT_DATABASE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TXT_DATABASE.Size = New System.Drawing.Size(317, 24)
        Me.TXT_DATABASE.TabIndex = 1056
        Me.TXT_DATABASE.Text = " "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(21, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 14)
        Me.Label1.TabIndex = 1057
        Me.Label1.Text = "اسم قاعدة البيانات"
        '
        'PL_4
        '
        Me.PL_4.BackColor = System.Drawing.Color.White
        Me.PL_4.Controls.Add(Me.Button1)
        Me.PL_4.Controls.Add(Me.Button2)
        Me.PL_4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PL_4.Location = New System.Drawing.Point(0, 155)
        Me.PL_4.Name = "PL_4"
        Me.PL_4.Size = New System.Drawing.Size(350, 40)
        Me.PL_4.TabIndex = 1055
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 32)
        Me.Button1.TabIndex = 1047
        Me.Button1.Text = "خروج"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(219, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 32)
        Me.Button2.TabIndex = 1046
        Me.Button2.Text = "انشاء ملف جديد"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(218, 13)
        Me.Label4.TabIndex = 1066
        Me.Label4.Text = " (يجب أن يكون باللغة الانجليزية وبدون مسافات)"
        '
        'frmNewFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(350, 195)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXT_LATIN)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.TXT_LEVEL_CURRENCYE)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CMB_CURRENCY)
        Me.Controls.Add(Me.TXT_NAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXT_DATABASE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PL_4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewFile"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "قاعدة بيانات جديدة"
        Me.PL_4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TXT_LATIN As TextBox
    Friend WithEvents label7 As Label
    Friend WithEvents TXT_LEVEL_CURRENCYE As TextBox
    Friend WithEvents label5 As Label
    Friend WithEvents Label3 As Label
    Private WithEvents CMB_CURRENCY As ComboBox
    Friend WithEvents TXT_NAME As TextBox
    Friend WithEvents Label2 As Label
    Private WithEvents Button2 As Button
    Friend WithEvents TXT_DATABASE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PL_4 As Panel
    Private WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
End Class
