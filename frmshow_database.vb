Imports System.Data.SqlClient

Public Class frmshow_database
    Private Sub frmshow_database_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            show_company()
        Catch ex As Exception

        End Try

    End Sub
    Sub show_company()
        Dim count__ As Integer = 0
        Dim str_connection_config As String
        If My.Settings.Name_SA <> "" Then
            str_connection_config = "Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=masterDB;User ID=" + (My.Settings.Name_SA) + ";password=" + (My.Settings.Pas_SA) + ";Integrated Security=false"

        Else
            str_connection_config = " Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=masterDB;Integrated Security=True"

        End If

        Dim Con_1 As New SqlConnection(str_connection_config)

        If (Con_1.State = ConnectionState.Open) Then
            Con_1.Close()
        End If
        Con_1.Open()
        Dim dt_ As New DataTable
        dt_.Clear()
        Dim sqlAdp As SqlDataAdapter
        Dim STR_S As String = "select COMPANY,databasename  from COMPANY "
        sqlAdp = New SqlDataAdapter(STR_S, Con_1)
        sqlAdp.Fill(dt_)
        If dt_.Rows.Count > 0 Then
            DGV.RowCount = dt_.Rows.Count
            For i As Integer = 0 To dt_.Rows.Count - 1
                DGV.Rows(count__).Cells("companyname").Value = dt_.Rows(i)("COMPANY").ToString()
                DGV.Rows(count__).Cells("dataname").Value = dt_.Rows(i)("databasename").ToString()
                count__ = count__ + 1
            Next
        End If

        Con_1.Close()
    End Sub

    Private Sub DGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellContentClick
        Try
            If e.ColumnIndex = -1 Or DGV.Rows.Count = 0 Then Exit Sub
            Dim colName = CType(sender, DataGridView).Columns(e.ColumnIndex).Name
            If colName = "Column1" Then
                Dim i As Integer = DGV.CurrentRow.Index
                If My.Settings.Name_SA <> "" Then
                    cn_data = "Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=" + DGV.Rows(i).Cells("dataname").Value.ToString() + ";User ID=" + (My.Settings.Name_SA) + ";password=" + (My.Settings.Pas_SA) + ";Integrated Security=false"

                Else
                    cn_data = " Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=" + DGV.Rows(i).Cells("dataname").Value.ToString() + ";Integrated Security=True"

                End If
                cs = cn_data.ToString()
                My.Settings.Item("SIS_DBConnectionString1") = cn_data.ToString()
                My.Settings.DATABASE = DGV.Rows(i).Cells("dataname").Value.ToString()
                My.Settings.Save()

                'print_com()
                Close()
                frmLogin.ShowDialog()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellDoubleClick
        Try
            Dim i As Integer = DGV.CurrentRow.Index
            If My.Settings.Name_SA <> "" Then
                cn_data = "Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=" + DGV.Rows(i).Cells("dataname").Value.ToString() + ";User ID=" + (My.Settings.Name_SA) + ";password=" + (My.Settings.Pas_SA) + ";Integrated Security=false"

            Else
                cn_data = " Data Source=" + (My.Settings.Server_Name) + ";Initial Catalog=" + DGV.Rows(i).Cells("dataname").Value.ToString() + ";Integrated Security=True"

            End If
            cs = cn_data.ToString()
            My.Settings.Item("SIS_DBConnectionString1") = cn_data.ToString()
            My.Settings.DATABASE = DGV.Rows(i).Cells("dataname").Value.ToString()
            My.Settings.Save()

            'print_com()
            Close()
            frmLogin.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim F As New frmNewFile
            F.Owner = Me
            F.ShowDialog()
            show_company()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        frmMainMenu.Close()
        Close()
        Application.Exit()
        End

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim F As New frmServerConn
        F.Owner = Me
        F.ShowDialog()

    End Sub
End Class