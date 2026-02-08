Imports System.Data.SqlClient

Public Class frmStockBalance
    Dim Filename As String
    Dim i1, i2 As Double

    Private Sub frmStockBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Getdata()
        DataGridView1.ClearSelection()
        DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


        Dim total1 As Double
        Dim total2 As Double

        Dim Row As DataGridViewRow
        ' Dim Row1 As DataGridViewRow
        For Each Row In DataGridView1.Rows
            Dim celv As DataGridViewTextBoxCell = Row.Cells(3)
            Dim celv1 As DataGridViewTextBoxCell = Row.Cells(4)
            Dim celv2 As DataGridViewTextBoxCell = Row.Cells(9)


            If IsNumeric(celv.Value) = True Then
                total1 += celv2.Value * celv.Value
                total2 += celv1.Value * celv2.Value
            End If


        Next
        TextBox2.Text = total1
        TextBox3.Text = total2
        TextBox4.Text = total2 - total1

    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),CostPrice,SellingPrice,Discount,VAT,ManufacturingDate,ExpiryDate,Qty from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Qty > 0 order by ProductCode", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()

            'Dim diff As Integer
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))


                For Each k As DataGridViewRow In Me.DataGridView1.Rows
                    If k.Cells(8).Value Is DBNull.Value Then
                        k.DefaultCellStyle.BackColor = Color.White
                    Else
                        Dim ndate As Date = Now.Date
                        Dim sdate As Date = k.Cells(8).Value
                        Dim diff As Integer = DateDiff(DateInterval.Day, sdate, ndate)
                        If diff > 0 Then

                            k.DefaultCellStyle.BackColor = Color.Red

                        ElseIf diff < 30 Then
                            'k.DefaultCellStyle.BackColor = Color.Blue

                        End If

                    End If
                    'If k.Cells(8).Value Is DBNull.Value Then

                    '    k.DefaultCellStyle.BackColor = Color.White

                    'ElseIf DateTime.Now > k.Cells(8).Value Then

                    '    k.DefaultCellStyle.BackColor = Color.Red

                    'ElseIf Val(DateTime.Now).ToString - k.Cells(8).Value.ToString < 10 Then
                    '    k.DefaultCellStyle.BackColor = Color.Blue
                    'End If
                Next
            End While
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select ReorderPoint from Product where ProductCode=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", r.Cells(0).Value.ToString())
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then

                    i1 = rdr.GetValue(0)
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct1 As String = "select sum(Qty) from Product,Temp_Stock where Product.PID=Temp_Stock.ProductID and ProductCode=@d1"
                cmd = New SqlCommand(ct1)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", r.Cells(0).Value.ToString())
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    i2 = rdr.GetValue(0)
                End If
                con.Close()
                If i2 < i1 Then
                    r.DefaultCellStyle.BackColor = Color.Cyan
                End If
            Next
            con.Close()
            DataGridView1.ClearSelection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        ExportExcel(DataGridView1)

    End Sub

    Private Sub txtProductName_TextChanged(sender As Object, e As EventArgs) Handles txtProductName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),CostPrice,SellingPrice,Discount,VAT,Qty from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and qty > 0 and ProductName like '%" & txtProductName.Text & "%' order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select ReorderPoint from Product where ProductCode=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", r.Cells(0).Value.ToString())
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then

                    i1 = rdr.GetValue(0)
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct1 As String = "select sum(Qty) from Product,Temp_Stock where Product.PID=Temp_Stock.ProductID and ProductCode=@d1"
                cmd = New SqlCommand(ct1)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", r.Cells(0).Value.ToString())
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    i2 = rdr.GetValue(0)
                End If
                con.Close()
                If i2 < i1 Then
                    r.DefaultCellStyle.BackColor = Color.Cyan
                End If
            Next
            con.Close()
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Reset()
        Dim total1 As Double
        Dim total2 As Double
        Dim Row As DataGridViewRow
        ' Dim Row1 As DataGridViewRow
        For Each Row In DataGridView1.Rows
            Dim celv As DataGridViewTextBoxCell = Row.Cells(3)
            Dim celv1 As DataGridViewTextBoxCell = Row.Cells(4)
            Dim celv2 As DataGridViewTextBoxCell = Row.Cells(9)


            If IsNumeric(celv.Value) = True Then
                total1 += celv2.Value * celv.Value
                total2 += celv1.Value * celv2.Value
            End If


        Next
        TextBox2.Text = total1
        TextBox3.Text = total2
        TextBox4.Text = total2 - total1

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        frmProduct.Show()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),(CostPrice),(SellingPrice),(Discount),(VAT),Qty from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Barcode like '%" & txtBarcode.Text & "%' order by ProductCode", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub



    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub SlideButton1_Click(sender As Object, e As EventArgs) Handles SlideButton1.Click
        If SlideButton1.IsOn = True Then
            TextBox2.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label5.Visible = True
            TextBox3.Visible = True
            TextBox4.Visible = True
        Else
            TextBox2.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label5.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
        End If
    End Sub

    Sub Reset()
        txtProductName.Text = ""
        Getdata()
    End Sub
    ' Private Sub vb(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
    '    Dim rand As New Random
    '    For i As Integer = 0 To 11 Step +1
    '        DataGridView1.Rows.Add()
    '    Next
    'End Sub






End Class