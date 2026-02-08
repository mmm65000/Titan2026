Imports System.Data.SqlClient
Public Class frmSplash

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            ''If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
            If My.Settings.ServerCn = String.Empty Then
                Timer1.Enabled = False
                frmServerConn.ShowDialog()
                Application.Exit()
                End
                Exit Sub
            End If

            Dim Con_status As New SqlConnection(My.Settings.ServerCn)
            Con_status.Open()
                If (Con_status.State = ConnectionState.Open) Then



                    'If System.IO.File.Exists(My.Settings.ServerCn) Then
                    'If txtActivationID.Text = TextBox1.Text Then
                    '    ProgressBar1.Visible = True
                    ProgressBar1.Value = ProgressBar1.Value + 2
                    If (ProgressBar1.Value = 10) Then
                        lblSet.Text = "Reading modules.."
                    ElseIf (ProgressBar1.Value = 20) Then
                        lblSet.Text = "Turning on modules."
                    ElseIf (ProgressBar1.Value = 40) Then
                        lblSet.Text = "Starting modules.."
                    ElseIf (ProgressBar1.Value = 60) Then
                        lblSet.Text = "Loading modules.."
                    ElseIf (ProgressBar1.Value = 80) Then
                        lblSet.Text = "Done Loading modules.."
                    ElseIf (ProgressBar1.Value = 100) Then
                        Con_status.Close()
                        frmshow_database.Show()
                        Timer1.Enabled = False
                        Me.Hide()
                        'frmActivation.Label6.Visible = False
                        'frmActivation.Label5.Visible = True
                        'frmActivation.Button1.Enabled = False
                        'frmActivation.txtActivationID.Text = "***************************"
                        'frmActivation.txtHardwareID.Enabled = False
                        'frmActivation.txtSerialNo.Enabled = False
                        'frmActivation.txtActivationID.Enabled = False
                        'frmActivation.Button2.Visible = True
                        'frmActivation.Button3.Visible = False
                    End If
                    'End If
                Else
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ProgressBar1.Value + 2
                    If (ProgressBar1.Value = 10) Then
                        lblSet.Text = "Reading modules.."
                    ElseIf (ProgressBar1.Value = 20) Then
                        lblSet.Text = "Turning on modules."
                    ElseIf (ProgressBar1.Value = 40) Then
                        lblSet.Text = "Starting modules.."
                    ElseIf (ProgressBar1.Value = 60) Then
                        lblSet.Text = "Loading modules.."
                    ElseIf (ProgressBar1.Value = 80) Then
                        lblSet.Text = "Done Loading modules.."
                    ElseIf (ProgressBar1.Value = 100) Then
                        frmServerConn.Show()
                        'frmSqlServerSetting.Reset()
                        'frmSqlServerSetting.Show()
                        Timer1.Enabled = False
                        Me.Hide()
                    End If
                End If

            'If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
            '    If txtActivationID.Text <> TextBox1.Text Then
            '        ProgressBar1.Visible = True
            '        ProgressBar1.Value = ProgressBar1.Value + 2
            '        If (ProgressBar1.Value = 10) Then
            '            lblSet.Text = "Reading modules.."
            '        ElseIf (ProgressBar1.Value = 20) Then
            '            lblSet.Text = "Turning on modules."
            '        ElseIf (ProgressBar1.Value = 40) Then
            '            lblSet.Text = "Starting modules.."
            '        ElseIf (ProgressBar1.Value = 60) Then
            '            lblSet.Text = "Loading modules.."
            '        ElseIf (ProgressBar1.Value = 80) Then
            '            lblSet.Text = "Done Loading modules.."
            '        ElseIf (ProgressBar1.Value = 100) Then
            '            '' frmActivation.Show()
            '            Dim sdate As Date = My.Settings.sdate
            '            Dim ndate As Date = Now.Date
            '            Dim diff As Integer = DateDiff(DateInterval.Day, sdate, ndate)
            '            If diff > 7 Then

            '                frmActivation.Show()
            '                Timer1.Enabled = False
            '                Me.Hide()

            '            Else
            '                frmLogin.Show()
            '                Timer1.Enabled = False
            '                frmActivation.Button2.Visible = True
            '                frmActivation.Button3.Visible = False
            '                Me.Hide()

            '            End If

            '        End If
            '    End If
            'Else
            '    ProgressBar1.Visible = True
            '    ProgressBar1.Value = ProgressBar1.Value + 2
            '    If (ProgressBar1.Value = 10) Then
            '        lblSet.Text = "Reading modules.."
            '    ElseIf (ProgressBar1.Value = 20) Then
            '        lblSet.Text = "Turning on modules."
            '    ElseIf (ProgressBar1.Value = 40) Then
            '        lblSet.Text = "Starting modules.."
            '    ElseIf (ProgressBar1.Value = 60) Then
            '        lblSet.Text = "Loading modules.."
            '    ElseIf (ProgressBar1.Value = 80) Then
            '        lblSet.Text = "Done Loading modules.."
            '    ElseIf (ProgressBar1.Value = 100) Then
            '        frmSqlServerSetting.Reset()
            '        frmSqlServerSetting.Show()
            '        Timer1.Enabled = False
            '        Me.Hide()
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try

    End Sub

    Friend Shared Sub Restart()
        Throw New NotImplementedException()
    End Sub

    Private Sub frmSplash1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            'If My.Settings.sdate = Nothing Then
            '    My.Settings.sdate = Now.Date
            '    My.Settings.Save()
            'End If

            'If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
            '    Dim i As System.Management.ManagementObject
            '    Dim searchInfo_Processor As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            '    For Each i In searchInfo_Processor.Get()
            '        txtHardwareID.Text = i("ProcessorID").ToString
            '    Next
            '    Dim searchInfo_Board As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            '    For Each i In searchInfo_Board.Get()
            '        txtSerialNo.Text = i("SerialNumber").ToString
            '    Next

            '    Dim st As String = (txtHardwareID.Text) + (txtSerialNo.Text) + "islem"
            '    TextBox1.Text = Encryption.MakePassword(st, 731)
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim ct As String = "select RTRIM(ActivationID) from Activation where HardwareID=@d1 and SerialNo=@d2 "
            '    cmd = New SqlCommand(ct)
            '    cmd.Connection = con
            '    cmd.Parameters.AddWithValue("@d1", Encrypt(txtHardwareID.Text.Trim))
            '    cmd.Parameters.AddWithValue("@d2", Encrypt(txtSerialNo.Text.Trim))
            '    ' cmd.Parameters.AddWithValue("@d3", Encrypt(txtActivationID.Text.Trim()))

            '    rdr = cmd.ExecuteReader()
            '    If rdr.Read() Then
            '        txtActivationID.Text = Decrypt(rdr.GetValue(0))
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class