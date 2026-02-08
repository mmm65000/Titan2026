Imports System.Data.SqlClient
Public Class FormStat
    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub Reset()

        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        dgw.Rows.Clear()
        txtcost.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox5.Text = ""


        Getdata()
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Invoice_Product.InvoiceID ,Invoice_Product.ProductID,Product.ProductName, Invoice_Product.Barcode,Invoice_Product.Qty,Invoice_Product.CostPrice,Invoice_Product.TotalAmount,Invoice_Payment.PaymentDate   from Invoice_Product,Invoice_Payment,Product where Invoice_Product.InvoiceID=Invoice_Payment.InvoiceID and Invoice_Product.ProductID=Product.PID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5) * rdr(4), rdr(6), rdr(7))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub




    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub


    Private Sub txtProductName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then


            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub btnSalesLedger_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesLedger.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Invoice_Product.InvoiceID ,Invoice_Product.ProductID,Product.ProductName, Invoice_Product.Barcode,Invoice_Product.Qty,Invoice_Product.CostPrice,Invoice_Product.TotalAmount,Invoice_Payment.PaymentDate   from Invoice_Product,Invoice_Payment,Product where Invoice_Product.InvoiceID=Invoice_Payment.InvoiceID and Invoice_Product.ProductID=Product.PID and Invoice_Payment.PaymentDate >=@d1 and Invoice_Payment.PaymentDate < @d2", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5) * rdr(4), rdr(6), rdr(7))
            End While
            con.Close()
            Dim total1 As Double
            Dim total2 As Double
            Dim total3 As Double
            Dim Row As DataGridViewRow
            For Each Row In dgw.Rows
                Dim celv As DataGridViewTextBoxCell = Row.Cells(4)
                Dim celv0 As DataGridViewTextBoxCell = Row.Cells(5)
                Dim celv1 As DataGridViewTextBoxCell = Row.Cells(6)
                If IsNumeric(celv.Value) = True Then
                    total1 += celv.Value
                    total2 += celv1.Value
                    total3 += celv0.Value
                End If

            Next
            TextBox1.Text = total1
            TextBox2.Text = total2
            txtcost.Text = total3
            TextBox5.Text = total2 - total3


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub frmProductsLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub btnProductsLedger_Click(sender As Object, e As EventArgs)

    End Sub





End Class