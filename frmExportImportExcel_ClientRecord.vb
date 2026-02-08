Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.ComponentModel


Public Class frmExportImportExcel_ClientRecord
    Public Sub Getdata()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select ID,CustomerID,Name,Address,City,State,ZipCode,ContactNo,EmailID,Remarks,CustomerType,OpeningBalance,OpeningBalanceType,Gender from Customer where Name like '%" & txtProductName.Text & "%' order by ID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try






    End Sub
    Sub Reset()
        txtProductName.Text = ""
        txtCategory.Text = ""
        dgw.Rows.Clear()
        DataGridView1.DataSource = Nothing
        DataGridView1.Visible = False
    End Sub
    Private Sub dgw_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgw.CellPainting
        If ((e.ColumnIndex = 3) _
           AndAlso (e.RowIndex >= 0)) Then
            e.PaintBackground(e.CellBounds, True)
            TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString, e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, (TextFormatFlags.RightToLeft Or TextFormatFlags.Right))
            e.Handled = True
        End If
    End Sub
    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub
    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub



    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnImportExcel_Click(sender As Object, e As EventArgs) Handles btnImportExcel.Click
        Try
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
            If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso OpenFileDialog.FileName <> "" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim Pathname As String = OpenFileDialog.FileName
                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Pathname + ";Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
                MyConnection.Open()
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                DataGridView1.Visible = True
                DataGridView1.DataSource = DtSet.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If DataGridView1.RowCount = Nothing Then
                MessageBox.Show("عفوا ،،، لا يوجد شيء للحفظ.." & vbCrLf & "الرجاء استيراد العملاء من الاكسل داخل الشبكة أولا", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                For j As Integer = i + 1 To Me.DataGridView1.RowCount - 1
                    If DataGridView1.Rows(i).Cells("اسم العميل").Value.ToString() = DataGridView1.Rows(j).Cells("اسم العميل").Value.ToString() Then
                        MessageBox.Show("يوجد اسم العميل مكرر " & DataGridView1.Rows(i).Cells(1).Value & "  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        Return
                    End If
                Next
            Next

            For Each row As DataGridViewRow In DataGridView1.Rows
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Name from Customer Where Name=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", row.Cells("اسم العميل").Value.ToString())
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    MessageBox.Show("العميل '" & row.Cells(9).Value & "' موجود مسبقا", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    con.Close()
                    Return
                End If
            Next


            For Each row As DataGridViewRow In DataGridView1.Rows
                'If Not row.IsNewRow Then
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select ID from Customer Where ID=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value.ToString()))
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() = True Then
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb As String = "Update Customer set CustomerID=@d2, Name=@d3, Address=@d4, City=@d5, State=@d6, ZipCode=@d7, ContactNo=@d8, EmailID=@d9,Remarks=@d10,photo=@d11,CustomerType=@d12,OpeningBalance=@d13,OpeningBalanceType=@d14,Gender=@d15 where ID=" & Val(row.Cells(0).Value.ToString()) & ""
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value.ToString()))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value.ToString())
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value.ToString())
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value.ToString())
                    cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value.ToString())
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value.ToString())
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value.ToString())
                    cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value.ToString())
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value.ToString())

                    'cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value.ToString())
                    'cmd.Connection = con
                    Dim ms As New MemoryStream()
                    Dim bmpImage As New Bitmap(Picture.Image)
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim p As New SqlParameter("@d11", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)
                    'cmd.ExecuteNonQuery()

                    cmd.Parameters.AddWithValue("@d12", row.Cells(10).Value.ToString())
                    cmd.Parameters.AddWithValue("@d13", row.Cells(11).Value.ToString())
                    cmd.Parameters.AddWithValue("@d14", row.Cells(12).Value.ToString())
                    cmd.Parameters.AddWithValue("@d15", row.Cells(13).Value.ToString())
                    cmd.ExecuteReader()
                    con.Close()

                    'Dim ms As New MemoryStream()
                    'Dim bmpImage As New Bitmap(Val(row.Cells(10)))
                    'bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    'Dim data As Byte() = ms.GetBuffer()
                    'Dim p As New SqlParameter("@d11", SqlDbType.Image)
                    'p.Value = data
                    'cmd.Parameters.Add(p)
                    'cmd.ExecuteNonQuery()
                    'con.Close()


                Else

                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb As String = "Insert Into Customer(ID,CustomerID,Name,Address,City,State,ZipCode,ContactNo,EmailID,Remarks,photo,CustomerType,OpeningBalance,OpeningBalanceType,Gender) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value.ToString()))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value.ToString())
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value.ToString())
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value.ToString())
                    cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value.ToString())
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value.ToString())
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value.ToString())
                    cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value.ToString())
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value.ToString())


                    '   cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value.ToString())
                    Dim ms As New MemoryStream()
                    Dim bmpImage As New Bitmap(Picture.Image)
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim p As New SqlParameter("@d11", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)


                    cmd.Parameters.AddWithValue("@d12", row.Cells(10).Value.ToString())
                    cmd.Parameters.AddWithValue("@d13", row.Cells(11).Value.ToString())
                    cmd.Parameters.AddWithValue("@d14", row.Cells(12).Value.ToString())
                    cmd.Parameters.AddWithValue("@d15", row.Cells(13).Value.ToString())

                    cmd.ExecuteReader()
                    con.Close()

                    'Try
                    'cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value.ToString())
                    'Dim ms As New MemoryStream()
                    'Dim bmpImage As New Bitmap(row.Cells(10).Value.ToString)
                    'bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    'Dim data As Byte() = ms.GetBuffer()
                    'Dim p As New SqlParameter("@d11", SqlDbType.Image)
                    'p.Value = data
                    'cmd.Parameters.Add(p)
                    ' cmd.ExecuteNonQuery()
                    'con.Close()

                    'Dim a As String = row.Cells(10).Value.ToString
                    'Dim vOut() As Byte = System.Text.Encoding.UTF8.GetBytes(a)
                    'cmd.Parameters.AddWithValue("@d11", vOut)
                    'cmd.ExecuteReader()
                    'con.Close()

                    'Catch ex As Exception
                    '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End Try





                End If
            Next
            MessageBox.Show("تم الحفظ بنجاح", "السجلات", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.DataSource = Nothing
            Reset()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        If MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Getdata()
        End If
    End Sub

    Private Sub txtProductName_TextChanged(sender As Object, e As EventArgs) Handles txtProductName.TextChanged
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select ID,CustomerID,Name,Address,City,State,ZipCode,ContactNo,EmailID,Remarks,photo,CustomerType,OpeningBalance,OpeningBalanceType,Gender from Customer where Name like '%" & txtProductName.Text & "%' order by ID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class