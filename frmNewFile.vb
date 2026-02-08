Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmNewFile
    Public str_connection_config As String
    Public str_connection_newdatabase As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Try
                If TXT_DATABASE.Text = Nothing Then
                    MessageBox.Show(" يجب كتابة اسم قاعدة البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If TXT_NAME.Text = Nothing Then
                    MessageBox.Show(" يجب كتابة اسم الملف  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                '--------------------------------------------------------------------

                connectiondatatbase()

                Dim Con_1 As New SqlConnection(My.Settings.ServerCn)

                If (Con_1.State = ConnectionState.Open) Then
                    Con_1.Close()
                End If
                Con_1.Open()
                Dim dt_ As New DataTable
                dt_.Clear()
                Dim sqlAdp As SqlDataAdapter
                Dim STR_S As String = "USE MASTER select suser_sname(owner_sid) from sys.databases where name = 'masterDB'"
                sqlAdp = New SqlDataAdapter(STR_S, Con_1)
                sqlAdp.Fill(dt_)
                If dt_.Rows.Count > 0 Then
                    Dim STR_DBS As String = "USE masterDB; SELECT [databasename] from COMPANY where [databasename] = '" & TXT_DATABASE.Text & "'"
                    Dim sqlAdp_DBS As New SqlDataAdapter(STR_DBS, Con_1)
                    Dim dt_Dbs As New DataTable
                    sqlAdp_DBS.Fill(dt_Dbs)
                    If dt_Dbs.Rows.Count > 0 Then
                        MsgBox("اسم قاعدة البيانات موجود من قبل")
                        Exit Sub
                    End If

                Else
                    createconfig()
                End If






                If (Con_1.State = ConnectionState.Open) Then
                    Con_1.Close()
                End If
                Con_1.Open()
                Dim CMD As New SqlCommand("CREATE DATABASE " & Trim(TXT_DATABASE.Text) & "  COLLATE  Arabic_CI_AS  ", Con_1)
                CMD.ExecuteNonQuery()
                Con_1.Close()


                'If (Con_1.State = ConnectionState.Open) Then
                '    Con_1.Close()
                'End If


                create_tb()
                insert_config()

                MessageBox.Show("تم انشاء الملف بنجاح", "ملف جديد", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub connectiondatatbase()
        If My.Settings.Name_SA <> "" Then
            str_connection_config = "Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=masterDB;User ID=" + (My.Settings.Name_SA) + ";password=" + (My.Settings.Pas_SA) + ";Integrated Security=false"
            str_connection_newdatabase = "Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=" & Trim(TXT_DATABASE.Text) & ";User ID=" + (My.Settings.Name_SA) + ";password=" + (My.Settings.Pas_SA) + ";Integrated Security=false"

        Else
            str_connection_config = " Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=masterDB;Integrated Security=True"
            str_connection_newdatabase = " Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=" & Trim(TXT_DATABASE.Text) & ";Integrated Security=True"

        End If
    End Sub

    Sub insert_config()

        Dim cn_cngig As New SqlConnection(str_connection_config)
        If (cn_cngig.State = ConnectionState.Open) Then
            cn_cngig.Close()
        End If
        cn_cngig.Open()
        Dim CMD As New SqlCommand("insert into COMPANY(COMPANY,databasename)values( '" & Trim(TXT_NAME.Text) & "','" & Trim(TXT_DATABASE.Text) & "' )", cn_cngig)
        CMD.ExecuteNonQuery()
        cn_cngig.Close()

    End Sub
    Sub create_tb()

        Dim cn_new As New SqlConnection(str_connection_newdatabase)
        If (cn_new.State = ConnectionState.Open) Then
            cn_new.Close()
        End If
        cn_new.Open()
        Dim script As String = File.ReadAllText(Application.StartupPath + "\db_script.sql")
        Dim commandStrings As IEnumerable(Of String) = Regex.Split(script, "^\s*GO\s*$", (RegexOptions.Multiline Or RegexOptions.IgnoreCase))
        For Each commandString As String In commandStrings
            If (commandString.Trim <> "") Then
                Dim command = New SqlCommand(commandString, cn_new)
                command.ExecuteNonQuery()
            End If
        Next
        cn_new.Close()




        'If (cn_new.State = ConnectionState.Open) Then
        '    cn_new.Close()
        'End If
        'cn_new.Open()
        'Dim CMD As New SqlCommand("update TB_CURR set nameA='" & CMB_CURRENCY.Text & "', nameL='" & TXT_LATIN.Text & "', nameA_Parent='" & TXT_LEVEL_CURRENCYE.Text & "', nameL_parent='" & TXT_LEVEL_CURRENCYE.Text & "'  where id=1 ", cn_new)
        'CMD.ExecuteNonQuery()
        'cn_new.Close()
    End Sub
    Sub createconfig()
        Dim Con_1 As New SqlConnection(My.Settings.ServerCn)

        If (Con_1.State = ConnectionState.Open) Then
            Con_1.Close()
        End If
        Con_1.Open()

        If (Con_1.State = ConnectionState.Open) Then
            Con_1.Close()
        End If
        Con_1.Open()
        Dim CMD As New SqlCommand("CREATE DATABASE [masterDB]  COLLATE  Arabic_CI_AS  ", Con_1)
        CMD.ExecuteNonQuery()
        Con_1.Close()






        Dim cn_cngig As New SqlConnection(str_connection_config)

        If (cn_cngig.State = ConnectionState.Open) Then
            cn_cngig.Close()
        End If
        cn_cngig.Open()
        Dim script As String = File.ReadAllText(Application.StartupPath + "\master_script.sql")
        Dim commandStrings As IEnumerable(Of String) = Regex.Split(script, "^\s*GO\s*$", (RegexOptions.Multiline Or RegexOptions.IgnoreCase))
        For Each commandString As String In commandStrings
            If (commandString.Trim <> "") Then
                Dim command = New SqlCommand(commandString, cn_cngig)
                command.ExecuteNonQuery()
            End If
        Next
        cn_cngig.Close()

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub frmNewFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CMB_CURRENCY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_CURRENCY.SelectedIndexChanged
        Try





            If (CMB_CURRENCY.Text = "دولار أمريكي") Then

                TXT_LATIN.Text = "USD"
                TXT_LEVEL_CURRENCYE.Text = "سنت"
            End If


            If (CMB_CURRENCY.Text = "جنيه مصري") Then
                TXT_LATIN.Text = "Egypt Pound"
                TXT_LEVEL_CURRENCYE.Text = "قرش"
            End If



            If (CMB_CURRENCY.Text = "درهم إماراتي") Then
                TXT_LATIN.Text = "UAE Dirham"
                TXT_LEVEL_CURRENCYE.Text = "فلس"
            End If




            If (CMB_CURRENCY.Text = "دينار كويتي") Then
                TXT_LATIN.Text = "Kuwait Dinar"
                TXT_LEVEL_CURRENCYE.Text = "فلس"
            End If




            If (CMB_CURRENCY.Text = "ريال سعودي") Then
                TXT_LATIN.Text = "Saudi Riyal"
                TXT_LEVEL_CURRENCYE.Text = "هللة"
            End If




            If (CMB_CURRENCY.Text = "دينار عراقي") Then
                TXT_LATIN.Text = "Iraq Dinar"
                TXT_LEVEL_CURRENCYE.Text = "فلس"
            End If




            If (CMB_CURRENCY.Text = "ليرة لبنانية") Then
                TXT_LATIN.Text = "Lebanon Pound"
                TXT_LEVEL_CURRENCYE.Text = "قرش"
            End If


            If (CMB_CURRENCY.Text = "ليرة سورية") Then
                TXT_LATIN.Text = "Syrian Pound"
                TXT_LEVEL_CURRENCYE.Text = "قرش"
            End If



            If (CMB_CURRENCY.Text = "دينار بحريني") Then
                TXT_LATIN.Text = "Bahrain Dinar"
                TXT_LEVEL_CURRENCYE.Text = "فلس"
            End If





            If (CMB_CURRENCY.Text = "ريال قطري") Then
                TXT_LATIN.Text = "Qatar Riyal"
                TXT_LEVEL_CURRENCYE.Text = "هللة"
            End If





            If (CMB_CURRENCY.Text = "ريال يمني") Then
                TXT_LATIN.Text = "Yemen Riyal"
                TXT_LEVEL_CURRENCYE.Text = "هللة"
            End If





            If (CMB_CURRENCY.Text = "يورو") Then
                TXT_LATIN.Text = "Euro"
                TXT_LEVEL_CURRENCYE.Text = "سنت"
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub CMB_CURRENCY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CMB_CURRENCY.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class