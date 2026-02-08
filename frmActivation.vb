Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Public Class frmActivation

    Private Sub frmActivation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As System.Management.ManagementObject
            Dim searchInfo_Processor As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            For Each i In searchInfo_Processor.Get()
                txtHardwareID.Text = i("ProcessorID").ToString
            Next
            Dim searchInfo_Board As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            For Each i In searchInfo_Board.Get()
                txtSerialNo.Text = i("SerialNumber").ToString
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try

        ' تحديث حالة التفعيل في الواجهة
        UpdateActivationStatus()
    End Sub

    Private Sub UpdateActivationStatus()
        Try
            Dim act As Object = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\InventorySoft9", "Activated", Nothing)
            If act IsNot Nothing AndAlso act.ToString() = "1" Then
                ' عرض الحالة كمفعّل باللون الأخضر
                Label6.Text = "Active"
                Label6.BackColor = System.Drawing.Color.Green
                Label6.ForeColor = System.Drawing.Color.White
                Label6.Visible = True
                Label5.Visible = False
                Button1.Visible = False  ' Hide Activate button
                Button2.Visible = True   ' Show Close button
            Else
                ' عرض الحالة كغير مفعّل باللون الأحمر
                Label6.Text = "Not activated"
                Label6.BackColor = System.Drawing.Color.Crimson
                Label6.ForeColor = System.Drawing.Color.White
                Label6.Visible = True
                Label5.Visible = False
                Button1.Visible = True
                Button2.Visible = False
            End If
        Catch ex As Exception
            ' في حال خطأ، اترك الحالة الافتراضية
            Label6.Text = "Not activated"
            Label6.BackColor = System.Drawing.Color.Crimson
            Label6.ForeColor = System.Drawing.Color.White
            Label6.Visible = True
            Label5.Visible = False
            Button1.Visible = True
            Button2.Visible = False
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If txtActivationID.Text = "" Then
                MessageBox.Show("Please enter activation id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtActivationID.Focus()
                Exit Sub
            End If
            Dim st As String = (txtHardwareID.Text) + (txtSerialNo.Text) + "islem"
            TextBox1.Text = Encryption.MakePassword(st, 731)
            If txtActivationID.Text = TextBox1.Text Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into Activation(HardwareID,SerialNo,ActivationID) VALUES (@d1,@d2,@d3)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Encrypt(txtHardwareID.Text.Trim))
                cmd.Parameters.AddWithValue("@d2", Encrypt(txtSerialNo.Text.Trim))
                cmd.Parameters.AddWithValue("@d3", Encrypt(txtActivationID.Text.Trim()))
                cmd.ExecuteReader()
                con.Close()
                ' Write activation flag to current user registry so main app sees activation
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\InventorySoft9", "Activated", "1")
                Catch exReg As Exception
                    ' Ignore registry write failures (user might not have permission) but activation DB record exists
                End Try
                ' Also update TrialData to today so HandleRegistry treats as valid
                Try
                    Dim regPath As String = "HKEY_CURRENT_USER\SOFTWARE\InventorySoft9"
                    Dim valueName As String = "TrialData"
                    Dim password As String = Environment.MachineName & "|INV"
                    Dim plain As Byte() = Encoding.UTF8.GetBytes(Date.Today.ToString("yyyy-MM-dd"))
                    ' Use same encryption as frmMainMenu
                    Using aes As New RijndaelManaged()
                        Dim salt As Byte() = Encoding.UTF8.GetBytes("s@1tV@lue" & Environment.MachineName)
                        Dim pdb As New Rfc2898DeriveBytes(password, salt, 1000)
                        aes.Key = pdb.GetBytes(32)
                        aes.IV = pdb.GetBytes(16)
                        Using ms As New MemoryStream()
                            Using cs As New CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)
                                cs.Write(plain, 0, plain.Length)
                                cs.FlushFinalBlock()
                                Dim protectedBytes As Byte() = ms.ToArray()
                                My.Computer.Registry.SetValue(regPath, valueName, Convert.ToBase64String(protectedBytes))
                            End Using
                        End Using
                    End Using
                Catch ex2 As Exception
                    ' ignore
                End Try

                ' تحديث الواجهة لتعرض الحالة المفعلة
                UpdateActivationStatus()

                MessageBox.Show("Successfully activated. Please restart the application.", "Software", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' أغلق نافذة التفعيل؛ المستخدم سيعيد تشغيل البرنامج لاحقاً
                Me.Close()
            Else
                MessageBox.Show("Invalid activation id...Please contact software provider for buying full licence" & vbCrLf & "Contact us at :" & vbCrLf & "Triche islem" & vbCrLf & "Email-Tricheabdou@gmail.com" & vbCrLf & "Mobile No. +213699678060", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class
