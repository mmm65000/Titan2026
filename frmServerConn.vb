Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class frmServerConn

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim STR_Con_SERVER As String
            If chkUseWindowsSecurity.Checked = False Then
                STR_Con_SERVER = "Data Source=" & Trim(cmbServers.Text) & ";User ID=" & Trim(txtUserName.Text) & ";password=" & Trim(txtPassword.Text) & ";Integrated Security=false"
                My.Settings.Name_SA = txtUserName.Text
                My.Settings.Pas_SA = txtPassword.Text
                My.Settings.Server_Name = cmbServers.Text
                My.Settings.Save()


            Else
                STR_Con_SERVER = " Data Source=" & Trim(cmbServers.Text) & ";Integrated Security=True"
                My.Settings.Name_SA = ""
                My.Settings.Pas_SA = ""
                My.Settings.Server_Name = cmbServers.Text
                My.Settings.Save()
            End If



            Dim Con_1 As New SqlConnection(STR_Con_SERVER)
            Con_1.Open()
            Con_1.Close()
            My.Settings.ServerCn = STR_Con_SERVER
            My.Settings.Save()
            MessageBox.Show("تم الاتصال بنجاح ")
            frmshow_database.Show()
            Close()

        Catch ex As Exception
            MsgBox("لا يمكن الاتصال بخادم قواعد البيانات")

        End Try
    End Sub

    Private Sub chkUseWindowsSecurity_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseWindowsSecurity.CheckedChanged
        If chkUseWindowsSecurity.Checked = True Then
            txtUserName.Text = ""
            txtUserName.Enabled = False
            txtPassword.Text = ""
            txtPassword.Enabled = False
        Else
            txtUserName.Enabled = True
            txtPassword.Enabled = True
        End If
    End Sub
    Private Function GetSQLServerList() As String()
        Dim dse As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        Dim dt As DataTable = dse.GetDataSources()
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim SQLServers As String() = New String(dt.Rows.Count - 1) {}
        Dim f As Integer = -1
        For Each r As DataRow In dt.Rows
            Dim SQLServer As String = r("ServerName").ToString()
            Dim Instance As String = r("InstanceName").ToString()
            If Instance IsNot Nothing AndAlso Instance <> "" Then
                SQLServer += "\" + Instance
            End If
            SQLServers(System.Math.Max(System.Threading.Interlocked.Increment(f), f - 1)) = SQLServer
        Next
        Array.Sort(SQLServers)
        Return SQLServers
    End Function
    Private Sub btnFindServers_Click(sender As Object, e As EventArgs) Handles btnFindServers.Click
        Try
            Try
                'ProgressBar1.Visible = True

                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True

                cmbServers.Items.AddRange(GetSQLServerList())

                'ProgressBar1.Visible = False

                cmbServers.DroppedDown = True


            Catch ex As Exception
                Dim mymsg As String = "حدثت مشكلة في استرداد معلومات حول خوادم السيكوال على جهاز الكمبيوتر أو الشبكة" & vbCrLf &
                "قد تحتاج إلى إدخال هذه المعلومات في حقل الاسم يدويًا"
                MessageBox.Show(mymsg, "خطأ في استرداد خوادم SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Catch ex As Exception

        End Try

        'LoadSQLServers(cmbServers)
    End Sub



    Private Sub FRM_CON_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub groupBox2_Enter(sender As Object, e As EventArgs) Handles groupBox2.Enter

    End Sub

    Private Sub groupBox1_Enter(sender As Object, e As EventArgs) Handles groupBox1.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        frmshow_database.Show()

    End Sub

    Private Sub chkBlankPassAllowed_CheckedChanged(sender As Object, e As EventArgs) Handles chkBlankPassAllowed.CheckedChanged
        If chkBlankPassAllowed.Checked = True Then
            txtPassword.Text = ""
            txtPassword.Enabled = False
        Else
            txtPassword.Text = ""
            txtPassword.Enabled = True
        End If
    End Sub

    Private Sub cmbServers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbServers.SelectedIndexChanged

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False

    End Sub
End Class