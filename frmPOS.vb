
Imports System.Data.SqlClient
Imports System.IO

Imports System.Globalization
Imports WeifenLuo.WinFormsUI.Docking

Public Class frmPOS
    Dim st2 As String
    Private TextBoxOrder As New Dictionary(Of TextBox, TextBox)()
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Public Sub Getdata1()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),(CostPrice),(SellingPrice),(Discount),(VAT),Qty, RTRIM(Product.SellingPrice2) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Qty > 0  order by ProductCode", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        '' txtCID.Text = ""
        'txtDiscountPer.Text = ""
        ComboBox1.SelectedIndex = 0
        txtRemarks.Text = ""
        TextBox1.Text = ""
        ''txtCustomerName.Text = ""
        txtAmount.Text = ""
        txtCostPrice.Text = ""
        '' txtCustomerID.Text = ""
        txtDiscountAmount.Text = ""
        txtDiscountPer.Text = ""
        txtMargin.Text = ""
        txtInvoiceNo.Text = ""
        txtProductCode.Text = ""
        txtProductName.Text = ""
        txtQty.Text = ""
        txtSellingPrice.Text = ""
        txtTotalAmount.Text = ""
        txtTotalQty.Text = ""
        txtVAT.Text = ""
        txtVATAmount.Text = ""
        txtGrandTotal.Text = ""
        txtTotalPayment.Text = ""
        txtPaymentDue.Text = ""
        dtpInvoiceDate.Value = Today
        dgw.Visible = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSave.Enabled = True
        btnRemove.Enabled = False
        btnAdd.Enabled = True
        btnRemove1.Enabled = False
        btnAdd1.Enabled = True
        btnPrint.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = False
        ''  txtContactNo.ReadOnly = True
        '' txtCustomerName.ReadOnly = True
        '' txtContactNo.Text = ""
        Button1.Enabled = True
        'txtCustomerType.Text = ""
        'txtSalesmanID.Text = ""
        'txtSalesman.Text = ""
        'txtSM_ID.Text = ""
        auto()
        lblSet.Text = "Allowed"
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        Clear()
        Clear1()
        cmbPaymentMode.SelectedIndex = 0

        frmCustomerRecord2.Getdata()
        If frmCustomerRecord2.dgw.Rows.Count > 0 Then
            txtCustomerName.Text = frmCustomerRecord2.dgw.Rows(0).Cells(2).Value.ToString
            txtCustomerID.Text = frmCustomerRecord2.dgw.Rows(0).Cells(1).Value.ToString
            txtCID.Text = frmCustomerRecord2.dgw.Rows(0).Cells(0).Value.ToString
            txtContactNo.Text = frmCustomerRecord2.dgw.Rows(0).Cells(8).Value.ToString
        End If

        If txtCustomerID.Text = "C-0001" Then
            cmbPaymentMode.SelectedIndex = 0
            txtPayment.ReadOnly = True
            txtPayment.Text = Val(txtGrandTotal.Text)
        Else
            txtPayment.ReadOnly = False
        End If

        If lblUser1.Text = "1" Then
            frmSalesmanRecord.Getdata()
            If frmSalesmanRecord.dgw.Rows.Count > 0 Then
                txtSalesman.Text = frmSalesmanRecord.dgw.Rows(0).Cells(2).Value.ToString
                txtSalesmanID.Text = frmSalesmanRecord.dgw.Rows(0).Cells(1).Value.ToString
                txtSM_ID.Text = frmSalesmanRecord.dgw.Rows(0).Cells(0).Value.ToString
                txtCommissionPer.Text = frmSalesmanRecord.dgw.Rows(0).Cells(9).Value.ToString
                txtRemarks.Text = " "
            Else
                txtSalesman.Text = ""
                txtSalesmanID.Text = ""
                txtSM_ID.Text = ""
                txtCommissionPer.Text = ""
                txtRemarks.Text = " "
            End If
        Else
            txtSalesman.Text = ""
            txtSalesmanID.Text = ""
            txtSM_ID.Text = ""
            txtCommissionPer.Text = ""
            txtRemarks.Text = " "
        End If





    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("Select TOP 1 Inv_ID FROM InvoiceInfo ORDER BY Inv_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("Inv_ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function

    Sub auto()
        Try
            txtID.Text = GenerateID()
            txtInvoiceNo.Text = "Inv-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click

        frmCustomerRecord2.lblSet.Text = "Billing"
        frmCustomerRecord2.lblUser.Text = lblUser.Text
        frmCustomerRecord2.Reset()
        frmCustomerRecord2.ShowDialog()
        txtBarcode.Focus()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectionInv.Click
        frmCurrentStock.lblSet.Text = "Billing"
        frmCurrentStock.Reset()
        frmCurrentStock.ShowDialog()
    End Sub
    Sub Compute()
        Dim num1, num2, num3, num4, num5 As Double
        txtMargin.Text = (Val(txtSellingPrice.Text) - Val(txtCostPrice.Text)) * Val(txtQty.Text)
        num1 = (Val(txtQty.Text) * Val(txtSellingPrice.Text))
        num1 = Math.Round(num1, 2)
        txtAmount.Text = num1
        num2 = CDbl((Val(txtAmount.Text) * Val(txtDiscountPer.Text)) / 100)
        num2 = Math.Round(num2, 2)
        txtDiscountAmount.Text = num2
        num3 = Val(txtAmount.Text) - Val(txtDiscountAmount.Text)
        num4 = ((Val(txtVAT.Text) * Val(num3)) / 100)
        num4 = Math.Round(num4, 2)
        txtVATAmount.Text = num4
        num5 = (Val(txtAmount.Text) + Val(txtVATAmount.Text) - Val(txtDiscountAmount.Text))
        num5 = Math.Round(num5, 2)
        txtTotalAmount.Text = num5
    End Sub

    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Compute()
    End Sub

    'Private Sub txtQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
    '    If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
    '        e.Handled = True
    '    End If
    'End Sub
    Public Function GrandTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(12).Value
                'txtPayment.Text = sum
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalPayment() As Double
        Dim sum As Double = 0
        Try
            If DataGridView1.Rows.Count = 0 Then

                sum = Val(txtGrandTotal.Text)

            End If

            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(1).Value

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Print()
        Try
            If txtCustomerType.Text <> "Non Regular" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim rpt As New rptInvoice 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand.CommandText = "Select Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, InvoiceInfo.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Invoice_Product.Barcode, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo On Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product On InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product On Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
                MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                MyCommand1.CommandText = "Select * from Company"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA.Fill(myDS, "InvoiceInfo")
                myDA.Fill(myDS, "Invoice_Product")
                myDA.Fill(myDS, "Customer")
                myDA.Fill(myDS, "Product")
                myDA1.Fill(myDS, "Company")
                rpt.SetDataSource(myDS)
                rpt.SetParameterValue("p1", txtCustomerID.Text)
                rpt.SetParameterValue("p2", Today)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
            End If
            If txtCustomerType.Text = "Non Regular" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim rpt As New rptInvoice2 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand.CommandText = "Select Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, InvoiceInfo.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Invoice_Product.Barcode, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo On Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product On InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product On Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
                MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                MyCommand1.CommandText = "Select * from Company"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA.Fill(myDS, "InvoiceInfo")
                myDA.Fill(myDS, "Invoice_Product")
                myDA.Fill(myDS, "Customer")
                myDA.Fill(myDS, "Product")
                myDA1.Fill(myDS, "Company")
                rpt.SetDataSource(myDS)
                rpt.SetParameterValue("p1", txtCustomerID.Text)
                rpt.SetParameterValue("p2", Today)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub Print1()
        Try
            If txtCustomerType.Text <> "Non Regular" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim rpt As New rptInvoice56 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand.CommandText = "Select Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, InvoiceInfo.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Invoice_Product.Barcode, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo On Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product On InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product On Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
                MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                MyCommand1.CommandText = "Select * from Company"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA.Fill(myDS, "InvoiceInfo")
                myDA.Fill(myDS, "Invoice_Product")
                myDA.Fill(myDS, "Customer")
                myDA.Fill(myDS, "Product")
                myDA1.Fill(myDS, "Company")
                rpt.SetDataSource(myDS)
                rpt.SetParameterValue("p1", txtCustomerID.Text)
                rpt.SetParameterValue("p2", Today)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.Show()
            End If
            If txtCustomerType.Text = "Non Regular" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim rpt As New rptInvoice2 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand.CommandText = "Select Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, InvoiceInfo.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Invoice_Product.Barcode, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo On Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product On InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product On Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
                MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                MyCommand1.CommandText = "Select * from Company"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA.Fill(myDS, "InvoiceInfo")
                myDA.Fill(myDS, "Invoice_Product")
                myDA.Fill(myDS, "Customer")
                myDA.Fill(myDS, "Product")
                myDA1.Fill(myDS, "Company")
                rpt.SetDataSource(myDS)
                rpt.SetParameterValue("p1", txtCustomerID.Text)
                rpt.SetParameterValue("p2", Today)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If txtQty.Text = "" Then
            txtQty.Text = 1
        End If
        If txtDiscountPer.Text = "" Then
            txtDiscountPer.Text = 0
        End If
        If txtVAT.Text = "" Then
            txtVAT.Text = 0
        End If
        Try
            If txtProductCode.Text = "" Then
                MessageBox.Show("الرجاء إدراج رقم الصنف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Exit Sub
            End If
            If txtBarcode.Text = "" Then
                MessageBox.Show("الرجاء إدراج الباركود للصنف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If
            If Len(Trim(txtSellingPrice.Text)) = 0 Then
                MessageBox.Show("الرجاء كتلبة السعر", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSellingPrice.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد الخصم %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtVAT.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد الضريبة %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtVAT.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("الرجاء تحديد الكمية ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtQty.Text = 0 Then
                MessageBox.Show("الكمية يجب ان تكون اكبر من الصفر", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtCostPrice.Text), Val(txtSellingPrice.Text), Val(txtMargin.Text), Val(txtQty.Text), Val(txtAmount.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), Val(txtTotalAmount.Text), Val(txtProductID.Text))
                Dim k As Double = 0
                k = GrandTotal()
                k = Math.Round(k, 2)
                txtGrandTotal.Text = k
                txtTotalPayment.Text = k
                ' txtTotalPayment.Text = k '*******************
                Compute1()
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In DataGridView1.Rows
                If r.Cells(0).Value = txtProductCode.Text And r.Cells(2).Value = txtBarcode.Text Then
                    r.Cells(0).Value = txtProductCode.Text
                    r.Cells(1).Value = txtProductName.Text
                    r.Cells(2).Value = txtBarcode.Text
                    r.Cells(3).Value = Val(txtCostPrice.Text)
                    r.Cells(4).Value = Val(txtSellingPrice.Text)
                    r.Cells(5).Value = Val(txtMargin.Text)
                    r.Cells(6).Value = Val(r.Cells(6).Value) + Val(txtQty.Text)
                    r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtAmount.Text)
                    r.Cells(8).Value = Val(txtDiscountPer.Text)
                    r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtDiscountAmount.Text)
                    r.Cells(10).Value = Val(txtVAT.Text)
                    r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtVATAmount.Text)
                    r.Cells(12).Value = Val(r.Cells(12).Value) + Val(txtTotalAmount.Text)
                    r.Cells(13).Value = Val(txtProductID.Text)
                    Dim i As Double = 0
                    i = GrandTotal()
                    i = Math.Round(i, 2)
                    txtGrandTotal.Text = i
                    ' txtTotalPayment.Text = i '*****************************************************************************
                    'txtTotalPayment.Text = i '*************
                    Compute1()
                    Clear()
                    txtDiscountPer.Text = ""
                    txtAmount.Text = ""
                    txtDiscountAmount.Text = ""
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtCostPrice.Text), Val(txtSellingPrice.Text), Val(txtMargin.Text), Val(txtQty.Text), Val(txtAmount.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), Val(txtTotalAmount.Text), Val(txtProductID.Text))
            Dim j As Double = 0
            j = GrandTotal()
            j = Math.Round(j, 2)
            txtGrandTotal.Text = j
            Compute1()
            Clear()
            txtPayment.Text = Val(txtGrandTotal.Text)
            ' txtTotalPayment.Text = Val(txtGrandTotal.Text) '*****************

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Clear()

        'txtDiscountPer.Text = ""
        txtBarcode.Text = ""
        txtProductCode.Text = ""
        txtProductName.Text = ""
        txtCostPrice.Text = ""
        txtSellingPrice.Text = ""
        txtMargin.Text = ""
        txtQty.Text = ""
        txtAmount.Text = ""
        txtDiscountPer.Text = ""
        txtDiscountAmount.Text = ""
        txtVAT.Text = ""
        txtVATAmount.Text = ""
        txtTotalAmount.Text = ""
        btnAdd.Enabled = True
        btnRemove.Enabled = False
        btnListUpdate.Enabled = False
        dgw.Visible = False
        txtBarcode.Focus()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Compute()
            Compute1()
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.Window '.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + DataGridView1.Width - 25, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("هل أنت متأكد من أنك تريد حذف سجل الفاتورة؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select Inv_ID from Invoiceinfo,SalesReturn where SalesReturn.SalesID=InvoiceInfo.Inv_ID and Inv_ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("غير قادر على الحذف .. مستخدمة مسبقًا في إرجاع المبيعات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from InvoiceInfo where Inv_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb4 As String = "update Temp_stock set qty = qty + (" & row.Cells(6).Value & ") where ProductID=@d1 and Barcode=@d2"
                        cmd = New SqlCommand(cb4)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next
                LedgerDelete(txtInvoiceNo.Text, "فاتورة مبيعات")
                LedgerDelete(txtInvoiceNo.Text, "دفعة فورية")
                Dim st As String = "deleted the bill (Products) having invoice no. '" & txtInvoiceNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("تم الحذف بنجاح", "سجل", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                ' RefreshRecords()
            Else
                MessageBox.Show("لايوجد سجل", "عذرا", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Compute1()
        Dim i As Double = 0
        i = Val(txtGrandTotal.Text) - Val(txtTotalPayment.Text)
        i = Math.Round(i, 2)
        txtPaymentDue.Text = i
    End Sub
    Private Function GenerateID1() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ID FROM Customer ORDER BY ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Sub auto1()
        Try
            txtCID.Text = GenerateID1()
            txtCustomerID.Text = "C-" + GenerateID1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtSalesmanID.Text)) = 0 Then
            MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Button1.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCustomerName.Text)) = 0 Then
            MessageBox.Show("الرجاء تحديد العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Exit Sub
        End If
        'If Len(Trim(txtRemarks.Text)) = 0 Then
        '    MessageBox.Show("الرجاء كتابة رقم Facture اليدوية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtRemarks.Focus()
        '    Exit Sub
        'End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("الرجاء اضافة اصناف للشبكة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If DataGridView2.Rows.Count = 0 Then
            'MessageBox.Show("لا يوجد دفعات في شبكة المدفوعات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Exit Sub
            DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPayment.Text = j
            Compute1()
        End If
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("المبلغ المدفوع لا يكون اكبر من قيمة الفاتورة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn1 As String = "select * from Company"
            cmd = New SqlCommand(ctn1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If Not rdr.Read() Then
                MessageBox.Show("الرجاء اضافة ملف تعريفي للشركة في القائمة الرئيسية ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim con As New SqlConnection(cs)
                con.Open()
                Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock where ProductID=@d1 and Barcode=@d2", con)
                cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txtTotalQty.Text = ds.Tables(0).Rows(0)("Qty")
                    If CInt(Val(row.Cells(6).Value)) > Val(txtTotalQty.Text) Then
                        MessageBox.Show("الكمية المضافة. إلى سلة البيع أكثر من" & vbCrLf & "الكمية المتوفرة. من كود المنتج '" & row.Cells(0).Value.ToString() & "' واسم المنتج ='" & row.Cells(1).Value & "' وجود الباركود  ='" & row.Cells(2).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                con.Close()
            Next
            If txtCustomerName.ReadOnly = False Then
                auto1()
                con = New SqlConnection(cs)
                con.Open()
                Dim cbn As String = "insert into Customer(ID, CustomerID, [Name], Gender, Address, City, ContactNo, EmailID,Remarks,State,ZipCode,Photo,CustomerType) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Non Regular')"
                cmd = New SqlCommand(cbn)
                cmd.Parameters.AddWithValue("@d1", Val(txtCID.Text))
                cmd.Parameters.AddWithValue("@d2", txtCustomerID.Text)
                cmd.Parameters.AddWithValue("@d3", txtCustomerName.Text)
                cmd.Parameters.AddWithValue("@d4", "")
                cmd.Parameters.AddWithValue("@d5", "")
                cmd.Parameters.AddWithValue("@d6", "")
                cmd.Parameters.AddWithValue("@d7", txtContactNo.Text)
                cmd.Parameters.AddWithValue("@d8", "")
                cmd.Parameters.AddWithValue("@d9", "")
                cmd.Parameters.AddWithValue("@d10", "")
                cmd.Parameters.AddWithValue("@d11", "")
                cmd.Connection = con
                Dim ms As New MemoryStream()
                Dim bmpImage As New Bitmap(My.Resources.photo)
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@d12", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                con.Close()
                txtCustomerType.Text = "Non Regular"
            End If

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into InvoiceInfo(Inv_ID, InvoiceNo, InvoiceDate, CustomerID, GrandTotal, TotalPaid, Balance, Remarks, SalesmanID) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8," & txtSM_ID.Text & ")"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpInvoiceDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", Val(txtCID.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtTotalPayment.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtPaymentDue.Text))
            cmd.Parameters.AddWithValue("@d8", txtRemarks.Text)
            'cmd.Parameters.AddWithValue("@d9", TextBox1.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Dim sum As Decimal = 0
            Dim commission As Decimal
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(12).Value
            Next
            commission = Val((sum * Val(txtCommissionPer.Text)) / 100)
            con = New SqlConnection(cs)
            con.Open()
            'Dim sql As String = "insert into Salesman_Commission(InvoiceID, CommissionPer, Commission) Values (" & txtID.Text & ", " & txtCommissionPer.Text & ", " & commission & ")"
            Dim sql As String = "insert into Salesman_Commission(InvoiceID,CommissionPer,Commission) VALUES (@T1,@T2,@T3)"
            cmd = New SqlCommand(sql)
            cmd.Parameters.AddWithValue("@T1", txtID.Text)
            cmd.Parameters.AddWithValue("@T2", Val(txtCommissionPer.Text))
            cmd.Parameters.AddWithValue("@T3", Val(commission))
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Invoice_Product(InvoiceID, Barcode, CostPrice, SellingPrice, Margin, Qty, Amount, DiscountPer, Discount, VATPer, VAT, TotalAmount, ProductID) VALUES (" & txtID.Text & " ,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d14", Val(row.Cells(12).Value))
                    cmd.Parameters.AddWithValue("@d15", Val(row.Cells(13).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into Invoice_Payment(InvoiceID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtID.Text & " ,@d4,@d5,@d6)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            LedgerSave(dtpInvoiceDate.Value.Date, txtCustomerName.Text, txtInvoiceNo.Text, "فاتورة مبيعات", Val(txtGrandTotal.Text), Val(txtTotalPayment.Text), txtCustomerID.Text, txtRemarks.Text)
            'For Each row As DataGridViewRow In DataGridView2.Rows
            '    If Not row.IsNewRow Then
            '        If row.Cells(0).Value = "نقدا" Then
            '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtCustomerName.Text, txtInvoiceNo.Text, "دفع نقدا", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
            '        End If
            '        If row.Cells(0).Value = "شيك" Or row.Cells(0).Value = "بطاقة إئتمان" Or row.Cells(0).Value = "فيزا كارت" Then
            '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "تحويل بنكي", txtInvoiceNo.Text, "دفعة فورية", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
            '        End If
            '    End If
            'Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb4 As String = "update Temp_stock set qty = qty - (" & row.Cells(6).Value & ") where ProductID=@d1 and Barcode=@d2"
                    cmd = New SqlCommand(cb4)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            con.Close()
            Dim st As String = "added the new bill (Products) having invoice no. '" & txtInvoiceNo.Text & "'"
            LogFunc(lblUser.Text, st)
            'If CheckForInternetConnection() = True Then
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
            '    cmd = New SqlCommand(ctn)
            '    cmd.Connection = con
            '    rdr = cmd.ExecuteReader()
            '    If rdr.Read() Then
            '        st2 = rdr.GetValue(0)
            '        Dim st3 As String = "Hello, " & txtCustomerName.Text & " you have successfully purchased the products having invoice no. " & txtInvoiceNo.Text & ""
            '        SMSFunc(txtContactNo.Text, st3, st2)
            '        SMS(st3)
            '        If (rdr IsNot Nothing) Then
            '            rdr.Close()
            '        End If
            '    End If
            'End If
            con.Close()
            btnSave.Enabled = False
            'RefreshRecords()
            MessageBox.Show("تم الحفظ بنجاح", "فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Print()
            Reset()
            cmbPaymentMode.SelectedIndex = 0
            If txtCustomerID.Text = "C-0001" Then
                cmbPaymentMode.SelectedIndex = 0
                txtPayment.Text = Val(txtGrandTotal.Text)
                txtPayment.ReadOnly = True
            Else
                txtPayment.Text = Val(txtGrandTotal.Text)
                txtPayment.ReadOnly = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtSalesmanID.Text)) = 0 Then
            MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Button1.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCustomerName.Text)) = 0 Then
            MessageBox.Show("الرجاء تحديد العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'If Len(Trim(txtRemarks.Text)) = 0 Then
        '    MessageBox.Show("الرجاء كتابة رقم Facture اليدوية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtRemarks.Focus()
        '    Exit Sub
        'End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("الرجاء اضافة اصناف للشبكة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If DataGridView2.Rows.Count = 0 Then
            'MessageBox.Show("عذراَ لا يوجد دفعات في شبكة المدفوعات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Exit Sub
            DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPayment.Text = j
            Compute1()
        End If
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("المبلغ المدفوع لا يكون اكبر من قيمة الفاتورة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update InvoiceInfo set InvoiceNo=@d2, CustomerID=@d4, GrandTotal=@d5, TotalPaid=@d6, Balance=@d7, Remarks=@d8, SalesmanID=" & txtSM_ID.Text & " where INV_ID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d4", Val(txtCID.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtTotalPayment.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtPaymentDue.Text))
            cmd.Parameters.AddWithValue("@d8", txtRemarks.Text)
            'cmd.Parameters.AddWithValue("@d9", TextBox1.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cqq As String = "delete from Invoice_Product where InvoiceID=@d1"
            cmd = New SqlCommand(cqq)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Invoice_Product(InvoiceID, Barcode, CostPrice, SellingPrice, Margin, Qty, Amount, DiscountPer, Discount, VATPer, VAT, TotalAmount, ProductID) VALUES (" & txtID.Text & " ,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d14", Val(row.Cells(12).Value))
                    cmd.Parameters.AddWithValue("@d15", Val(row.Cells(13).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()



            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Invoice_Payment where InvoiceID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into Invoice_Payment(InvoiceID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtID.Text & " ,@d4,@d5,@d6)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            LedgerDelete(txtInvoiceNo.Text, "فاتورة مبيعات")
            LedgerDelete(txtInvoiceNo.Text, "دفعة فورية")
            LedgerSave(dtpInvoiceDate.Value.Date, txtCustomerName.Text, txtInvoiceNo.Text, "فاتورة مبيعات", Val(txtGrandTotal.Text), Val(txtTotalPayment.Text), txtCustomerID.Text, txtRemarks.Text)
            'For Each row As DataGridViewRow In DataGridView2.Rows
            '    If Not row.IsNewRow Then
            '        If row.Cells(0).Value = "نقدا" Then
            '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtCustomerName.Text, txtInvoiceNo.Text, "دفع نقدا", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
            '        End If
            '        If row.Cells(0).Value = "شيك" Or row.Cells(0).Value = "بطاقة إئتمان" Or row.Cells(0).Value = "فيزا كارت" Then
            '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "تحويل بنكي", txtInvoiceNo.Text, "دفعة فورية", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
            '        End If
            '    End If
            'Next
            Dim st As String = "updated the bill (Products) having invoice no. '" & txtInvoiceNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnUpdate.Enabled = False
            MessageBox.Show("تم التعديل بنجاح", "السجلات", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmSalesInvoiceRecord.Close()
        frmSalesInvoiceRecord.lblSet.Text = "Sales Invoice"
        frmSalesInvoiceRecord.Reset()
        frmSalesInvoiceRecord.ShowDialog()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
        cmbPaymentMode.SelectedIndex = 0
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub

    Private Sub btnAdd1_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd1.Click
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("الرجاء اضافة اصناف للشبكة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If cmbPaymentMode.Text = "" Then
                MessageBox.Show("الرجاء اختيار طريقة دفع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
            If txtPayment.Text = "" Then
                MessageBox.Show("الرجاء كتابة المبلغ المدفوع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayment.Focus()
                Exit Sub
            End If

            DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPayment.Text = j
            Compute1()
            Clear1()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Clear1()
        cmbPaymentMode.SelectedIndex = -1
        txtPayment.Text = ""
        dtpPaymentDate.Text = Today
        btnAdd1.Enabled = True
        btnRemove1.Enabled = False
        btnListUpdate1.Enabled = False
    End Sub
    Private Sub btnRemove1_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove1.Click
        Try
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = TotalPayment()
            k = Math.Round(k, 2)
            txtTotalPayment.Text = k
            Compute1()
            Compute()
            Clear1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPayment_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPayment.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPayment.Text
            Dim selectionStart = Me.txtPayment.SelectionStart
            Dim selectionLength = Me.txtPayment.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView2_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        btnRemove1.Enabled = True
        If (Me.DataGridView2.Rows.Count > 0) Then
            Me.btnRemove1.Enabled = True
            Me.btnListUpdate1.Enabled = True
            Me.btnAdd1.Enabled = False
            Dim row As DataGridViewRow = Me.DataGridView2.SelectedRows.Item(0)
            Me.cmbPaymentMode.Text = (row.Cells.Item(0).Value)
            Me.txtPayment.Text = (row.Cells.Item(1).Value)
            Me.dtpPaymentDate.Text = (row.Cells.Item(2).Value)
        End If
    End Sub

    Private Sub btnListReset1_Click(sender As System.Object, e As System.EventArgs) Handles btnListReset1.Click
        Clear1()
    End Sub

    Private Sub btnListReset_Click(sender As System.Object, e As System.EventArgs) Handles btnListReset.Click
        Clear()
    End Sub

    Private Sub DataGridView2_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView2.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.Window '.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + DataGridView2.Width - 25, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub btnListUpdate1_Click(sender As System.Object, e As System.EventArgs) Handles btnListUpdate1.Click
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("الرجاء اضافة اصناف ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If cmbPaymentMode.Text = "" Then
                MessageBox.Show("الرجاء اختيار طريقة دفع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
            If txtPayment.Text = "" Then
                MessageBox.Show("الرجاء كتابة المبلغ المدفوع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayment.Focus()
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            DataGridView2.Rows.Add(cmbPaymentMode.Text, Val(txtPayment.Text), dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPayment.Text = j
            Compute1()
            Clear1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnListUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnListUpdate.Click
        Try
            If txtProductCode.Text = "" Then
                MessageBox.Show("الرجاء ادخال المنتج", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Exit Sub
            End If
            If txtBarcode.Text = "" Then
                MessageBox.Show("الرجاء إدراج الباركود للصنف de l'article", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If
            If Len(Trim(txtSellingPrice.Text)) = 0 Then
                MessageBox.Show("الرجاء كتابة السعر", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSellingPrice.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد الخصم %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtVAT.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد الضريبة %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtVAT.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("الرجاء تحديد الكمية ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtQty.Text = 0 Then
                MessageBox.Show("الكمية يجب ان تكون اكبر من الصفر", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If

            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtCostPrice.Text), Val(txtSellingPrice.Text), Val(txtMargin.Text), Val(txtQty.Text), Val(txtAmount.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), Val(txtTotalAmount.Text), Val(txtProductID.Text))
            Dim k As Double = 0
            k = GrandTotal()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Compute1()
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtSellingPrice_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSellingPrice.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSellingPrice.Text
            Dim selectionStart = Me.txtSellingPrice.SelectionStart
            Dim selectionLength = Me.txtSellingPrice.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiscountPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscountPer.Text
            Dim selectionStart = Me.txtDiscountPer.SelectionStart
            Dim selectionLength = Me.txtDiscountPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtVAT_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVAT.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtVAT.Text
            Dim selectionStart = Me.txtVAT.SelectionStart
            Dim selectionLength = Me.txtVAT.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiscountPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscountPer.TextChanged
        'txtDiscountAmount.ReadOnly = True
        Compute()
        'txtDiscountPer.Text = ""
        ' txtDiscountAmount.Text = ((Val(txtAmount.Text) * Val(txtDiscountPer.Text)) / 100)
        'num2 = Math.Round(num2, 2)


    End Sub

    Private Sub txtVAT_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVAT.TextChanged
        Compute()
    End Sub

    Private Sub txtSellingPrice_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSellingPrice.TextChanged
        Compute()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmSalesmanRecord.lblSet.Text = "Billing"
        frmSalesmanRecord.Reset()
        frmSalesmanRecord.ShowDialog()
    End Sub

    Private Sub cmbPaymentMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPaymentMode.SelectedIndexChanged

        If cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 3 Or cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 4 Or cmbPaymentMode.SelectedIndex = 5 Or cmbPaymentMode.SelectedIndex = 6 Or cmbPaymentMode.SelectedIndex = 7 Or cmbPaymentMode.SelectedIndex = 8 Or cmbPaymentMode.SelectedIndex = 9 Then
            txtPayment.Text = "0"
            txtPayment.ReadOnly = True
            If txtCustomerID.Text = "C-0001" Then
                cmbPaymentMode.SelectedIndex = 0
                txtPayment.Text = Val(txtGrandTotal.Text)
                txtPayment.ReadOnly = True
            End If
        Else
            txtPayment.ReadOnly = False
            txtPayment.Text = Val(txtGrandTotal.Text)
        End If

    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnMinimize_Click(sender As System.Object, e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMaximise_Click(sender As System.Object, e As System.EventArgs) Handles btnMaximise.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.StartPosition = FormStartPosition.CenterScreen
            btnMaximise.Image = My.Resources.Maximise_32X32
        Else
            Me.WindowState = FormWindowState.Maximized
            btnMaximise.Image = My.Resources.User_Interface_Restore_Window_icon__1_
        End If
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        'OSKeyboard()
    End Sub
    Sub OSKeyboard()
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start("osk.exe")
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start("osk.exe")
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),(CostPrice),(SellingPrice),(Discount),(VAT) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Barcode=@d1 "
                cmd.Parameters.AddWithValue("@d1", txtBarcode.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtProductID.Text = rdr.GetValue(0)
                    txtProductCode.Text = rdr.GetValue(1)
                    TextBox2.Text = rdr.GetValue(2)
                    txtCostPrice.Text = rdr.GetValue(3)
                    txtSellingPrice.Text = rdr.GetValue(4)
                    txtDiscountPer.Text = rdr.GetValue(5)
                    txtVAT.Text = rdr.GetValue(6)
                    txtQty.Text = 1
                    If DataGridView1.Rows.Count = 0 Then
                        DataGridView1.Rows.Add(txtProductCode.Text, TextBox2.Text, txtBarcode.Text, Val(txtCostPrice.Text), Val(txtSellingPrice.Text), Val(txtMargin.Text), Val(txtQty.Text), Val(txtAmount.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), Val(txtTotalAmount.Text), Val(txtProductID.Text))
                        Dim k As Double = 0
                        k = GrandTotal()
                        k = Math.Round(k, 2)
                        txtGrandTotal.Text = k
                        Compute1()
                        Clear()
                        Exit Sub
                    End If
                    For Each r As DataGridViewRow In DataGridView1.Rows
                        If r.Cells(0).Value = txtProductCode.Text And r.Cells(2).Value = txtBarcode.Text Then
                            r.Cells(0).Value = txtProductCode.Text
                            r.Cells(1).Value = TextBox2.Text
                            r.Cells(2).Value = txtBarcode.Text
                            r.Cells(3).Value = Val(txtCostPrice.Text)
                            r.Cells(4).Value = Val(txtSellingPrice.Text)
                            r.Cells(5).Value = Val(txtMargin.Text)
                            r.Cells(6).Value = Val(r.Cells(6).Value) + Val(txtQty.Text)
                            r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtAmount.Text)
                            r.Cells(8).Value = Val(txtDiscountPer.Text)
                            r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtDiscountAmount.Text)
                            r.Cells(10).Value = Val(txtVAT.Text)
                            r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtVATAmount.Text)
                            r.Cells(12).Value = Val(r.Cells(12).Value) + Val(txtTotalAmount.Text)
                            r.Cells(13).Value = Val(txtProductID.Text)
                            Dim i As Double = 0
                            i = GrandTotal()
                            i = Math.Round(i, 2)
                            txtGrandTotal.Text = i
                            txtPayment.Text = i

                            Compute1()
                            Clear()
                            Exit Sub
                        End If
                    Next
                    DataGridView1.Rows.Add(txtProductCode.Text, TextBox2.Text, txtBarcode.Text, Val(txtCostPrice.Text), Val(txtSellingPrice.Text), Val(txtMargin.Text), Val(txtQty.Text), Val(txtAmount.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), Val(txtTotalAmount.Text), Val(txtProductID.Text))
                    Dim j As Double = 0
                    j = GrandTotal()
                    j = Math.Round(j, 2)
                    txtGrandTotal.Text = j
                    Compute1()
                    Clear()
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnScanItems_Click(sender As System.Object, e As System.EventArgs) Handles btnScanItems.Click
        txtBarcode.Focus()
    End Sub

    Private Sub txtBarcode_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        'If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
        '    e.Handled = True
        'End If
    End Sub


    Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDoubleClick

        If (Me.DataGridView1.Rows.Count > 0) Then
            If lblSet.Text = "Not Allowed" Then
                btnRemove.Enabled = True
                btnListUpdate.Enabled = True
            Else
                btnRemove.Enabled = True
                btnListUpdate.Enabled = True
            End If
            Me.btnAdd.Enabled = False
            Dim row As DataGridViewRow = Me.DataGridView1.SelectedRows.Item(0)
            Me.txtProductCode.Text = (row.Cells.Item(0).Value)
            Me.txtProductName.Text = (row.Cells.Item(1).Value)
            Me.txtBarcode.Text = (row.Cells.Item(2).Value)
            Me.txtCostPrice.Text = (row.Cells.Item(3).Value)
            Me.txtSellingPrice.Text = (row.Cells.Item(4).Value)
            Me.txtMargin.Text = (row.Cells.Item(5).Value)
            Me.txtQty.Text = (row.Cells.Item(6).Value)
            Me.txtAmount.Text = (row.Cells.Item(7).Value)
            Me.txtDiscountPer.Text = (row.Cells.Item(8).Value)
            Me.txtDiscountAmount.Text = (row.Cells.Item(9).Value)
            Me.txtVAT.Text = (row.Cells.Item(10).Value)
            Me.txtVATAmount.Text = (row.Cells.Item(11).Value)
            Me.txtTotalAmount.Text = (row.Cells.Item(12).Value)
            Me.txtProductID.Text = (row.Cells.Item(13).Value)
            txtQty.Focus()
            dgw.Visible = False
        End If

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If Len(Trim(txtSalesmanID.Text)) = 0 Then
            MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '  Button1.Focus()
            ' Exit Sub
        End If
        If Len(Trim(txtCustomerName.Text)) = 0 Then
            MessageBox.Show("الرجاء تحديد العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Exit Sub
        End If
        'If Len(Trim(txtContactNo.Text)) = 0 Then
        '    MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtContactNo.Focus()
        '    '  Exit Sub
        'End If
        'If Len(Trim(txtRemarks.Text)) = 0 Then
        '    MessageBox.Show("الرجاء كتابة رقم Facture اليدوية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtRemarks.Focus()
        '    Exit Sub
        'End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("الرجاء اضافة اصناف للشبكة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If DataGridView2.Rows.Count = 0 Then
            '    MessageBox.Show("لا يوجد دفعات في شبكة المدفوعات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub

            DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPayment.Text = j
            Compute1()
            'Clear1()


        End If
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("المبلغ المدفوع لا يكون اكبر من قيمة الفاتورة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn1 As String = "select * from Company"
            cmd = New SqlCommand(ctn1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If Not rdr.Read() Then
                MessageBox.Show("الرجاء اضافة ملف تعريفي للشركة في القائمة الرئيسية ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim con As New SqlConnection(cs)
                con.Open()
                Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock where ProductID=@d1 and Barcode=@d2", con)
                cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txtTotalQty.Text = ds.Tables(0).Rows(0)("Qty")
                    If CInt(Val(row.Cells(6).Value)) > Val(txtTotalQty.Text) Then
                        MessageBox.Show("الكمية المضافة. إلى سلة البيع أكثر من" & vbCrLf & "الكمية المتوفرة. من المنتج '" & row.Cells(0).Value.ToString() & "'  واسم المنتج ='" & row.Cells(1).Value & "' وجود الباركود ='" & row.Cells(2).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                con.Close()
            Next
            If txtCustomerName.ReadOnly = False Then
                auto1()
                con = New SqlConnection(cs)
                con.Open()
                Dim cbn As String = "insert into Customer(ID, CustomerID, [Name], Gender, Address, City, ContactNo, EmailID,Remarks,State,ZipCode,Photo,CustomerType) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Non Regular')"
                cmd = New SqlCommand(cbn)
                cmd.Parameters.AddWithValue("@d1", Val(txtCID.Text))
                cmd.Parameters.AddWithValue("@d2", txtCustomerID.Text)
                cmd.Parameters.AddWithValue("@d3", txtCustomerName.Text)
                cmd.Parameters.AddWithValue("@d4", "")
                cmd.Parameters.AddWithValue("@d5", "")
                cmd.Parameters.AddWithValue("@d6", "")
                cmd.Parameters.AddWithValue("@d7", txtContactNo.Text)
                cmd.Parameters.AddWithValue("@d8", "")
                cmd.Parameters.AddWithValue("@d9", "")
                cmd.Parameters.AddWithValue("@d10", "")
                cmd.Parameters.AddWithValue("@d11", "")
                cmd.Connection = con
                Dim ms As New MemoryStream()
                Dim bmpImage As New Bitmap(My.Resources.photo)
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@d12", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                con.Close()
                txtCustomerType.Text = "Non Regular"
            End If

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into InvoiceInfo(Inv_ID, InvoiceNo, InvoiceDate, CustomerID, GrandTotal, TotalPaid, Balance, Remarks, SalesmanID) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8," & txtSM_ID.Text & ")"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpInvoiceDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", Val(txtCID.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtTotalPayment.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtPaymentDue.Text))
            cmd.Parameters.AddWithValue("@d8", txtRemarks.Text)
            'cmd.Parameters.AddWithValue("@d9", TextBox1.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Dim sum As Decimal = 0
            Dim commission As Decimal
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(12).Value
            Next
            commission = Val((sum * Val(txtCommissionPer.Text)) / 100)
            con = New SqlConnection(cs)
            con.Open()
            'Dim sql As String = "insert into Salesman_Commission(InvoiceID, CommissionPer, Commission) Values (" & txtID.Text & ", " & txtCommissionPer.Text & ", " & commission & ")"
            Dim sql As String = "insert into Salesman_Commission(InvoiceID,CommissionPer,Commission) VALUES (@T1,@T2,@T3)"
            cmd = New SqlCommand(sql)
            cmd.Parameters.AddWithValue("@T1", txtID.Text)
            cmd.Parameters.AddWithValue("@T2", Val(txtCommissionPer.Text))
            cmd.Parameters.AddWithValue("@T3", Val(commission))
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Invoice_Product(InvoiceID, Barcode, CostPrice, SellingPrice, Margin, Qty, Amount, DiscountPer, Discount, VATPer, VAT, TotalAmount, ProductID) VALUES (" & txtID.Text & " ,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d14", Val(row.Cells(12).Value))
                    cmd.Parameters.AddWithValue("@d15", Val(row.Cells(13).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into Invoice_Payment(InvoiceID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtID.Text & " ,@d4,@d5,@d6)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            LedgerSave(dtpInvoiceDate.Value.Date, txtCustomerName.Text, txtInvoiceNo.Text, "فاتورة مبيعات", Val(txtGrandTotal.Text), Val(txtTotalPayment.Text), txtCustomerID.Text, txtRemarks.Text)
            'For Each row As DataGridViewRow In DataGridView2.Rows
            '    If Not row.IsNewRow Then
            '        If row.Cells(0).Value = "نقدا" Then
            '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtCustomerName.Text, txtInvoiceNo.Text, "دفع نقدا", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
            '        End If
            '        If row.Cells(0).Value = "شيك" Or row.Cells(0).Value = "بطاقة إئتمان" Or row.Cells(0).Value = "فيزا كارت" Then
            '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "تحويل بنكي", txtInvoiceNo.Text, "دفعة فورية", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
            '        End If
            '    End If
            'Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb4 As String = "update Temp_stock set qty = qty - (" & row.Cells(6).Value & ") where ProductID=@d1 and Barcode=@d2"
                    cmd = New SqlCommand(cb4)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            con.Close()
            Dim st As String = "added the new bill (Products) having invoice no. '" & txtInvoiceNo.Text & "'"
            LogFunc(lblUser.Text, st)
            'If CheckForInternetConnection() = True Then
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
            '    cmd = New SqlCommand(ctn)
            '    cmd.Connection = con
            '    rdr = cmd.ExecuteReader()
            '    If rdr.Read() Then
            '        st2 = rdr.GetValue(0)
            '        Dim st3 As String = "Hello, " & txtCustomerName.Text & " you have successfully purchased the products having invoice no. " & txtInvoiceNo.Text & ""
            '        SMSFunc(txtContactNo.Text, st3, st2)
            '        SMS(st3)
            '        If (rdr IsNot Nothing) Then
            '            rdr.Close()
            '        End If
            '    End If
            'End If
            con.Close()
            btnSave.Enabled = False
            ' RefreshRecords()
            MessageBox.Show("تم الحفظ بنجاح", "فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
            cmbPaymentMode.SelectedIndex = 0
            If txtCustomerID.Text = "C-0001" Then
                cmbPaymentMode.SelectedIndex = 0
                txtPayment.Text = Val(txtGrandTotal.Text)
                txtPayment.ReadOnly = True
            Else
                txtPayment.Text = Val(txtGrandTotal.Text)
                txtPayment.ReadOnly = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    '
    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPaymentMode.SelectedIndex = 0
        txtCustomerID.Text = "C-0001"
        txtCustomerName.Text = "Client standard"
        txtCID.Text = "1"
        txtContactNo.Text = "00000000"

        If txtCustomerID.Text = "C-0001" Then
            cmbPaymentMode.SelectedIndex = 0
            txtPayment.ReadOnly = True
            txtPayment.Text = Val(txtGrandTotal.Text)
        Else
            txtPayment.ReadOnly = False
        End If
        'txtSalesman.Text = "مندوب عام"
        'txtSalesmanID.Text = "SM-0001"
        'txtSM_ID.Text = "1"
        'txtCommissionPer.Text = "0"
        'txtRemarks.Text = "0"

        Getdata1()

    End Sub

    Private Sub DataGridView1_ControlAdded(sender As Object, e As ControlEventArgs) Handles DataGridView1.ControlAdded
        txtPayment.Text = Val(txtGrandTotal.Text)
        If cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 3 Or cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 4 Or cmbPaymentMode.SelectedIndex = 5 Or cmbPaymentMode.SelectedIndex = 6 Or cmbPaymentMode.SelectedIndex = 7 Or cmbPaymentMode.SelectedIndex = 8 Or cmbPaymentMode.SelectedIndex = 9 Then
            txtPayment.Text = "0"

            txtPayment.ReadOnly = True
        Else
            txtPayment.ReadOnly = False
            txtPayment.Text = Val(txtGrandTotal.Text)
        End If
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged

        'dgw.Visible = True
        'Try

        '    con = New SqlConnection(cs)
        '    con.Open()
        '    cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),(CostPrice),(SellingPrice),(Discount),(VAT),Qty from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Qty > 0 and Temp_Stock.Barcode like '%" & txtBarcode.Text & "%' order by ProductCode", con)
        '    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '    dgw.Rows.Clear()
        '    While (rdr.Read() = True)
        '        dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
        '    End While
        '    con.Close()


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        'txtPayment.Text = Val(txtGrandTotal.Text)
        If cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 3 Or cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 4 Or cmbPaymentMode.SelectedIndex = 5 Or cmbPaymentMode.SelectedIndex = 6 Or cmbPaymentMode.SelectedIndex = 7 Or cmbPaymentMode.SelectedIndex = 8 Or cmbPaymentMode.SelectedIndex = 9 Then
            '  txtPayment.Text = "0"

            ' txtPayment.ReadOnly = True
            'txtQty.Focus()
        Else
            txtPayment.ReadOnly = False
            txtPayment.Text = Val(txtGrandTotal.Text)
        End If
    End Sub

    Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerID.TextChanged

        If txtCustomerID.Text = "C-0001" Then
            cmbPaymentMode.SelectedIndex = 0
            txtPayment.Text = Val(txtGrandTotal.Text)
            txtPayment.ReadOnly = True
        Else
            txtPayment.Text = Val(txtGrandTotal.Text)
            txtPayment.ReadOnly = False

        End If
    End Sub

    Private Sub txtPayment_TextChanged(sender As Object, e As EventArgs) Handles txtPayment.TextChanged
        If txtCustomerID.Text = "C-0001" Then
            cmbPaymentMode.SelectedIndex = 0
            txtPayment.ReadOnly = True
            txtPayment.Text = Val(txtGrandTotal.Text)
            txtTotalPayment.Text = Val(txtGrandTotal.Text)
            Compute1()
        Else
            txtPayment.ReadOnly = False

        End If

        'If cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 3 Or cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 4 Or cmbPaymentMode.SelectedIndex = 5 Or cmbPaymentMode.SelectedIndex = 6 Or cmbPaymentMode.SelectedIndex = 7 Or cmbPaymentMode.SelectedIndex = 8 Or cmbPaymentMode.SelectedIndex = 9 Then
        '    txtPayment.Text = "0"

        '    txtPayment.ReadOnly = True
        'Else
        '    txtPayment.ReadOnly = False
        '    txtPayment.Text = Val(txtGrandTotal.Text)
        'End If
    End Sub

    Private Sub frmPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F1 Then
            'حفظ           
            If Len(Trim(txtSalesmanID.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Button1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtCustomerName.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Len(Trim(txtContactNo.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtContactNo.Focus()
                Exit Sub
            End If
            'If Len(Trim(txtRemarks.Text)) = 0 Then
            '    MessageBox.Show("الرجاء كتابة رقم Facture اليدوية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtRemarks.Focus()
            '    Exit Sub
            'End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("الرجاء اضافة اصناف للشبكة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If DataGridView2.Rows.Count = 0 Then
                '    MessageBox.Show("لا يوجد دفعات في شبكة المدفوعات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub

                DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Value.Date)
                Dim j As Double = 0
                j = TotalPayment()
                j = Math.Round(j, 2)
                txtTotalPayment.Text = j
                Compute1()
                'Clear1()


            End If
            If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("المبلغ المدفوع لا يكون اكبر من قيمة الفاتورة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn1 As String = "select * from Company"
                cmd = New SqlCommand(ctn1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()

                If Not rdr.Read() Then
                    MessageBox.Show("الرجاء اضافة ملف تعريفي للشركة في القائمة الرئيسية ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock where ProductID=@d1 and Barcode=@d2", con)
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then
                        txtTotalQty.Text = ds.Tables(0).Rows(0)("Qty")
                        If CInt(Val(row.Cells(6).Value)) > Val(txtTotalQty.Text) Then
                            MessageBox.Show("الكمية المضافة. إلى سلة البيع أكثر من" & vbCrLf & "الكمية المتوفرة. من كود المنتج '" & row.Cells(0).Value.ToString() & "' واسم المنتج ='" & row.Cells(1).Value & "' وجود الباركود ='" & row.Cells(2).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
                If txtCustomerName.ReadOnly = False Then
                    auto1()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbn As String = "insert into Customer(ID, CustomerID, [Name], Gender, Address, City, ContactNo, EmailID,Remarks,State,ZipCode,Photo,CustomerType) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Non Regular')"
                    cmd = New SqlCommand(cbn)
                    cmd.Parameters.AddWithValue("@d1", Val(txtCID.Text))
                    cmd.Parameters.AddWithValue("@d2", txtCustomerID.Text)
                    cmd.Parameters.AddWithValue("@d3", txtCustomerName.Text)
                    cmd.Parameters.AddWithValue("@d4", "")
                    cmd.Parameters.AddWithValue("@d5", "")
                    cmd.Parameters.AddWithValue("@d6", "")
                    cmd.Parameters.AddWithValue("@d7", txtContactNo.Text)
                    cmd.Parameters.AddWithValue("@d8", "")
                    cmd.Parameters.AddWithValue("@d9", "")
                    cmd.Parameters.AddWithValue("@d10", "")
                    cmd.Parameters.AddWithValue("@d11", "")
                    cmd.Connection = con
                    Dim ms As New MemoryStream()
                    Dim bmpImage As New Bitmap(My.Resources.photo)
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim p As New SqlParameter("@d12", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    txtCustomerType.Text = "Non Regular"
                End If

                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "insert into InvoiceInfo(Inv_ID, InvoiceNo, InvoiceDate, CustomerID, GrandTotal, TotalPaid, Balance, Remarks, SalesmanID) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8," & txtSM_ID.Text & ")"
                cmd = New SqlCommand(cb)
                cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
                cmd.Parameters.AddWithValue("@d3", dtpInvoiceDate.Value.Date)
                cmd.Parameters.AddWithValue("@d4", Val(txtCID.Text))
                cmd.Parameters.AddWithValue("@d5", Val(txtGrandTotal.Text))
                cmd.Parameters.AddWithValue("@d6", Val(txtTotalPayment.Text))
                cmd.Parameters.AddWithValue("@d7", Val(txtPaymentDue.Text))
                cmd.Parameters.AddWithValue("@d8", txtRemarks.Text)
                'cmd.Parameters.AddWithValue("@d9", TextBox1.Text)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim sum As Decimal = 0
                Dim commission As Decimal
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(12).Value
                Next
                commission = Val((sum * Val(txtCommissionPer.Text)) / 100)
                con = New SqlConnection(cs)
                con.Open()
                'Dim sql As String = "insert into Salesman_Commission(InvoiceID, CommissionPer, Commission) Values (" & txtID.Text & ", " & txtCommissionPer.Text & ", " & commission & ")"
                Dim sql As String = "insert into Salesman_Commission(InvoiceID,CommissionPer,Commission) VALUES (@T1,@T2,@T3)"
                cmd = New SqlCommand(sql)
                cmd.Parameters.AddWithValue("@T1", txtID.Text)
                cmd.Parameters.AddWithValue("@T2", Val(txtCommissionPer.Text))
                cmd.Parameters.AddWithValue("@T3", Val(commission))
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into Invoice_Product(InvoiceID, Barcode, CostPrice, SellingPrice, Margin, Qty, Amount, DiscountPer, Discount, VATPer, VAT, TotalAmount, ProductID) VALUES (" & txtID.Text & " ,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d4", row.Cells(2).Value)
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d14", Val(row.Cells(12).Value))
                        cmd.Parameters.AddWithValue("@d15", Val(row.Cells(13).Value))
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "insert into Invoice_Payment(InvoiceID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtID.Text & " ,@d4,@d5,@d6)"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                LedgerSave(dtpInvoiceDate.Value.Date, txtCustomerName.Text, txtInvoiceNo.Text, "فاتورة مبيعات", Val(txtGrandTotal.Text), Val(txtTotalPayment.Text), txtCustomerID.Text, txtRemarks.Text)
                'For Each row As DataGridViewRow In DataGridView2.Rows
                '    If Not row.IsNewRow Then
                '        If row.Cells(0).Value = "نقدا" Then
                '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtCustomerName.Text, txtInvoiceNo.Text, "دفع نقدا", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
                '        End If
                '        If row.Cells(0).Value = "شيك" Or row.Cells(0).Value = "بطاقة إئتمان" Or row.Cells(0).Value = "فيزا كارت" Then
                '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "تحويل بنكي", txtInvoiceNo.Text, "دفعة فورية", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
                '        End If
                '    End If
                'Next
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb4 As String = "update Temp_stock set qty = qty - (" & row.Cells(6).Value & ") where ProductID=@d1 and Barcode=@d2"
                        cmd = New SqlCommand(cb4)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next
                con.Close()
                Dim st As String = "added the new bill (Products) having invoice no. '" & txtInvoiceNo.Text & "'"
                LogFunc(lblUser.Text, st)
                'If CheckForInternetConnection() = True Then
                '    con = New SqlConnection(cs)
                '    con.Open()
                '    Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                '    cmd = New SqlCommand(ctn)
                '    cmd.Connection = con
                '    rdr = cmd.ExecuteReader()
                '    If rdr.Read() Then
                '        st2 = rdr.GetValue(0)
                '        Dim st3 As String = "Hello, " & txtCustomerName.Text & " you have successfully purchased the products having invoice no. " & txtInvoiceNo.Text & ""
                '        SMSFunc(txtContactNo.Text, st3, st2)
                '        SMS(st3)
                '        If (rdr IsNot Nothing) Then
                '            rdr.Close()
                '        End If
                '    End If
                'End If
                con.Close()
                btnSave.Enabled = False
                ' RefreshRecords()
                MessageBox.Show("تم الحفظ بنجاح", "فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                cmbPaymentMode.SelectedIndex = 0
                If txtCustomerID.Text = "C-0001" Then
                    cmbPaymentMode.SelectedIndex = 0
                    txtPayment.Text = Val(txtGrandTotal.Text)
                    txtPayment.ReadOnly = True
                Else
                    txtPayment.Text = Val(txtGrandTotal.Text)
                    txtPayment.ReadOnly = False

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If




        If e.KeyCode = Keys.P Then
            ' حفظ وطباعة
            If Len(Trim(txtSalesmanID.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Button1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtCustomerName.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Len(Trim(txtContactNo.Text)) = 0 Then
                MessageBox.Show("الرجاء تحديد رقم البائع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtContactNo.Focus()
                Exit Sub
            End If
            'If Len(Trim(txtRemarks.Text)) = 0 Then
            '    MessageBox.Show("الرجاء كتابة رقم Facture اليدوية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtRemarks.Focus()
            '    Exit Sub
            'End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("الرجاء اضافة اصناف للشبكة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If DataGridView2.Rows.Count = 0 Then
                'MessageBox.Show("لا يوجد دفعات في شبكة المدفوعات", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Exit Sub
                DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Value.Date)
                Dim j As Double = 0
                j = TotalPayment()
                j = Math.Round(j, 2)
                txtTotalPayment.Text = j
                Compute1()
            End If
            If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("المبلغ المدفوع لا يكون اكبر من قيمة الفاتورة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn1 As String = "select * from Company"
                cmd = New SqlCommand(ctn1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()

                If Not rdr.Read() Then
                    MessageBox.Show("الرجاء اضافة ملف تعريفي للشركة في القائمة الرئيسية ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock where ProductID=@d1 and Barcode=@d2", con)
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then
                        txtTotalQty.Text = ds.Tables(0).Rows(0)("Qty")
                        If CInt(Val(row.Cells(6).Value)) > Val(txtTotalQty.Text) Then
                            MessageBox.Show("الكمية المضافة. إلى سلة البيع أكثر من" & vbCrLf & "الكمية المتوفرة. من كود المنتج '" & row.Cells(0).Value.ToString() & "' واسم المنتج ='" & row.Cells(1).Value & "' وجود الباركود ='" & row.Cells(2).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
                If txtCustomerName.ReadOnly = False Then
                    auto1()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbn As String = "insert into Customer(ID, CustomerID, [Name], Gender, Address, City, ContactNo, EmailID,Remarks,State,ZipCode,Photo,CustomerType) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,'Non Regular')"
                    cmd = New SqlCommand(cbn)
                    cmd.Parameters.AddWithValue("@d1", Val(txtCID.Text))
                    cmd.Parameters.AddWithValue("@d2", txtCustomerID.Text)
                    cmd.Parameters.AddWithValue("@d3", txtCustomerName.Text)
                    cmd.Parameters.AddWithValue("@d4", "")
                    cmd.Parameters.AddWithValue("@d5", "")
                    cmd.Parameters.AddWithValue("@d6", "")
                    cmd.Parameters.AddWithValue("@d7", txtContactNo.Text)
                    cmd.Parameters.AddWithValue("@d8", "")
                    cmd.Parameters.AddWithValue("@d9", "")
                    cmd.Parameters.AddWithValue("@d10", "")
                    cmd.Parameters.AddWithValue("@d11", "")
                    cmd.Connection = con
                    Dim ms As New MemoryStream()
                    Dim bmpImage As New Bitmap(My.Resources.photo)
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim p As New SqlParameter("@d12", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    txtCustomerType.Text = "Non Regular"
                End If

                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "insert into InvoiceInfo(Inv_ID, InvoiceNo, InvoiceDate, CustomerID, GrandTotal, TotalPaid, Balance, Remarks, SalesmanID) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8," & txtSM_ID.Text & ")"
                cmd = New SqlCommand(cb)
                cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
                cmd.Parameters.AddWithValue("@d3", dtpInvoiceDate.Value.Date)
                cmd.Parameters.AddWithValue("@d4", Val(txtCID.Text))
                cmd.Parameters.AddWithValue("@d5", Val(txtGrandTotal.Text))
                cmd.Parameters.AddWithValue("@d6", Val(txtTotalPayment.Text))
                cmd.Parameters.AddWithValue("@d7", Val(txtPaymentDue.Text))
                cmd.Parameters.AddWithValue("@d8", txtRemarks.Text)
                'cmd.Parameters.AddWithValue("@d9", TextBox1.Text)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim sum As Decimal = 0
                Dim commission As Decimal
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(12).Value
                Next
                commission = Val((sum * Val(txtCommissionPer.Text)) / 100)
                con = New SqlConnection(cs)
                con.Open()
                'Dim sql As String = "insert into Salesman_Commission(InvoiceID, CommissionPer, Commission) Values (" & txtID.Text & ", " & txtCommissionPer.Text & ", " & commission & ")"
                Dim sql As String = "insert into Salesman_Commission(InvoiceID,CommissionPer,Commission) VALUES (@T1,@T2,@T3)"
                cmd = New SqlCommand(sql)
                cmd.Parameters.AddWithValue("@T1", txtID.Text)
                cmd.Parameters.AddWithValue("@T2", Val(txtCommissionPer.Text))
                cmd.Parameters.AddWithValue("@T3", Val(commission))
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into Invoice_Product(InvoiceID, Barcode, CostPrice, SellingPrice, Margin, Qty, Amount, DiscountPer, Discount, VATPer, VAT, TotalAmount, ProductID) VALUES (" & txtID.Text & " ,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d4", row.Cells(2).Value)
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d14", Val(row.Cells(12).Value))
                        cmd.Parameters.AddWithValue("@d15", Val(row.Cells(13).Value))
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "insert into Invoice_Payment(InvoiceID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtID.Text & " ,@d4,@d5,@d6)"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                LedgerSave(dtpInvoiceDate.Value.Date, txtCustomerName.Text, txtInvoiceNo.Text, "فاتورة مبيعات", Val(txtGrandTotal.Text), Val(txtTotalPayment.Text), txtCustomerID.Text, txtRemarks.Text)
                'For Each row As DataGridViewRow In DataGridView2.Rows
                '    If Not row.IsNewRow Then
                '        If row.Cells(0).Value = "نقدا" Then
                '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtCustomerName.Text, txtInvoiceNo.Text, "دفع نقدا", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
                '        End If
                '        If row.Cells(0).Value = "شيك" Or row.Cells(0).Value = "بطاقة إئتمان" Or row.Cells(0).Value = "فيزا كارت" Then
                '            LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "تحويل بنكي", txtInvoiceNo.Text, "دفعة فورية", 0, Val(row.Cells(1).Value), txtCustomerID.Text, txtRemarks.Text)
                '        End If
                '    End If
                'Next
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb4 As String = "update Temp_stock set qty = qty - (" & row.Cells(6).Value & ") where ProductID=@d1 and Barcode=@d2"
                        cmd = New SqlCommand(cb4)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(13).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next
                con.Close()
                Dim st As String = "added the new bill (Products) having invoice no. '" & txtInvoiceNo.Text & "'"
                LogFunc(lblUser.Text, st)
                'If CheckForInternetConnection() = True Then
                '    con = New SqlConnection(cs)
                '    con.Open()
                '    Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                '    cmd = New SqlCommand(ctn)
                '    cmd.Connection = con
                '    rdr = cmd.ExecuteReader()
                '    If rdr.Read() Then
                '        st2 = rdr.GetValue(0)
                '        Dim st3 As String = "Hello, " & txtCustomerName.Text & " you have successfully purchased the products having invoice no. " & txtInvoiceNo.Text & ""
                '        SMSFunc(txtContactNo.Text, st3, st2)
                '        SMS(st3)
                '        If (rdr IsNot Nothing) Then
                '            rdr.Close()
                '        End If
                '    End If
                'End If
                con.Close()
                btnSave.Enabled = False
                'RefreshRecords()
                MessageBox.Show("تم الحفظ بنجاح", "فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Print()
                Reset()
                cmbPaymentMode.SelectedIndex = 0
                If txtCustomerID.Text = "C-0001" Then
                    cmbPaymentMode.SelectedIndex = 0
                    txtPayment.Text = Val(txtGrandTotal.Text)
                    txtPayment.ReadOnly = True
                Else
                    txtPayment.Text = Val(txtGrandTotal.Text)
                    txtPayment.ReadOnly = False

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
        'If e.KeyCode = Keys.Enter Then
        '    dgw.Visible = False
        '    If txtQty.Text = "" Then
        '        txtQty.Text = 1
        '    End If
        '    Try
        '        If txtProductCode.Text = "" Then
        '            MessageBox.Show("الرجاء إدراج رقم الصنف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtProductCode.Focus()
        '            Exit Sub
        '        End If
        '        If txtBarcode.Text = "" Then
        '            MessageBox.Show("الرجاء إدراج الباركود للصنف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtBarcode.Focus()
        '            Exit Sub
        '        End If
        '        If Len(Trim(txtSellingPrice.Text)) = 0 Then
        '            MessageBox.Show("الرجاء كتلبة السعر", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtSellingPrice.Focus()
        '            Exit Sub
        '        End If
        '        If Len(Trim(txtDiscountPer.Text)) = 0 Then
        '            MessageBox.Show("الرجاء تحديد الخصم %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtDiscountPer.Focus()
        '            Exit Sub
        '        End If
        '        If Len(Trim(txtVAT.Text)) = 0 Then
        '            MessageBox.Show("الرجاء تحديد الضريبة %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtVAT.Focus()
        '            Exit Sub
        '        End If
        '        If txtQty.Text = "" Then
        '            MessageBox.Show("الرجاء تحديد الكمية ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtQty.Focus()
        '            Exit Sub
        '        End If
        '        If txtQty.Text = 0 Then
        '            MessageBox.Show("الكمية يجب ان تكون اكبر من الصفر", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtQty.Focus()
        '            Exit Sub
        '        End If
        '        If DataGridView1.Rows.Count = 0 Then
        '            DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtCostPrice.Text), Val(txtSellingPrice.Text), Val(txtMargin.Text), Val(txtQty.Text), Val(txtAmount.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), Val(txtTotalAmount.Text), Val(txtProductID.Text))
        '            Dim k As Double = 0
        '            k = GrandTotal()
        '            k = Math.Round(k, 2)
        '            txtGrandTotal.Text = k
        '            txtTotalPayment.Text = k
        '            Compute1()
        '            Clear()
        '            Exit Sub
        '        End If
        '        For Each r As DataGridViewRow In DataGridView1.Rows
        '            If r.Cells(0).Value = txtProductCode.Text And r.Cells(2).Value = txtBarcode.Text Then
        '                r.Cells(0).Value = txtProductCode.Text
        '                r.Cells(1).Value = txtProductName.Text
        '                r.Cells(2).Value = txtBarcode.Text
        '                r.Cells(3).Value = Val(txtCostPrice.Text)
        '                r.Cells(4).Value = Val(txtSellingPrice.Text)
        '                r.Cells(5).Value = Val(txtMargin.Text)
        '                r.Cells(6).Value = Val(r.Cells(6).Value) + Val(txtQty.Text)
        '                r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtAmount.Text)
        '                r.Cells(8).Value = Val(txtDiscountPer.Text)
        '                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtDiscountAmount.Text)
        '                r.Cells(10).Value = Val(txtVAT.Text)
        '                r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtVATAmount.Text)
        '                r.Cells(12).Value = Val(r.Cells(12).Value) + Val(txtTotalAmount.Text)
        '                r.Cells(13).Value = Val(txtProductID.Text)
        '                Dim i As Double = 0
        '                i = GrandTotal()
        '                i = Math.Round(i, 2)
        '                txtGrandTotal.Text = i
        '                Compute1()
        '                Clear()
        '                txtDiscountPer.Text = ""
        '                txtAmount.Text = ""
        '                txtDiscountAmount.Text = ""
        '                Exit Sub
        '            End If
        '        Next
        '        DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtCostPrice.Text), Val(txtSellingPrice.Text), Val(txtMargin.Text), Val(txtQty.Text), Val(txtAmount.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), Val(txtTotalAmount.Text), Val(txtProductID.Text))
        '        Dim j As Double = 0
        '        j = GrandTotal()
        '        j = Math.Round(j, 2)
        '        txtGrandTotal.Text = j
        '        Compute1()
        '        Clear()
        '        txtPayment.Text = Val(txtGrandTotal.Text)
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End If

        If e.KeyCode = Keys.Delete Then

            Dim k As Double = 0
            k = GrandTotal()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Compute1()
            Clear()

        End If
        'If e.KeyCode = Keys.D Then
        '    'جديد
        '    Reset()
        '    cmbPaymentMode.SelectedIndex = 0
        'End If

        'If e.KeyCode = Keys.A Then
        '    ' اختيار العميل

        '    frmCustomerRecord2.lblSet.Text = "Billing"
        '    frmCustomerRecord2.lblUser.Text = lblUser.Text
        '    frmCustomerRecord2.Reset()
        '    frmCustomerRecord2.ShowDialog()
        '    txtBarcode.Focus()
        'End If
        'If e.KeyCode = Keys.Z Then
        '    ' اضافة للشبكة
        '    Try
        '        If DataGridView1.Rows.Count = 0 Then
        '            MessageBox.Show("عذرا, il faut ajouter des Produit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Exit Sub
        '        End If
        '        If cmbPaymentMode.Text = "" Then
        '            MessageBox.Show("Veuillez choisir un mode de paiement", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            cmbPaymentMode.Focus()
        '            Exit Sub
        '        End If
        '        If txtPayment.Text = "" Then
        '            MessageBox.Show("الرجاء كتابة المبلغ المدفوع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtPayment.Focus()
        '            Exit Sub
        '        End If

        '        DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Value.Date)
        '        Dim j As Double = 0
        '        j = TotalPayment()
        '        j = Math.Round(j, 2)
        '        txtTotalPayment.Text = j
        '        Compute1()
        '        Clear1()


        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End If

        'If e.KeyCode = Keys.R Then
        '    'الاصناف
        '    frmCurrentStock.lblSet.Text = "Billing"
        '    frmCurrentStock.Reset()
        '    frmCurrentStock.ShowDialog()
        'End If

        'If e.KeyCode = Keys.E Then
        '    Try
        '        If txtProductCode.Text = "" Then
        '            MessageBox.Show("الرجاء ادخال المنتج", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtProductCode.Focus()
        '            Exit Sub
        '        End If
        '        If txtBarcode.Text = "" Then
        '            MessageBox.Show("الرجاء إدراج الباركود للصنف de l'article", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtBarcode.Focus()
        '            Exit Sub
        '        End If
        '        If Len(Trim(txtSellingPrice.Text)) = 0 Then
        '            MessageBox.Show("الرجاء كتابة السعر", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtSellingPrice.Focus()
        '            Exit Sub
        '        End If
        '        If Len(Trim(txtDiscountPer.Text)) = 0 Then
        '            MessageBox.Show("الرجاء تحديد الخصم %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtDiscountPer.Focus()
        '            Exit Sub
        '        End If
        '        If Len(Trim(txtVAT.Text)) = 0 Then
        '            MessageBox.Show("الرجاء تحديد الضريبة %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtVAT.Focus()
        '            Exit Sub
        '        End If
        '        If txtQty.Text = "" Then
        '            MessageBox.Show("الرجاء تحديد الكمية ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtQty.Focus()
        '            Exit Sub
        '        End If
        '        If txtQty.Text = 0 Then
        '            MessageBox.Show("الكمية يجب ان تكون اكبر من الصفر", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            txtQty.Focus()
        '            Exit Sub
        '        End If

        '        For Each row As DataGridViewRow In DataGridView1.SelectedRows
        '            DataGridView1.Rows.Remove(row)
        '        Next
        '        DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtCostPrice.Text), Val(txtSellingPrice.Text), Val(txtMargin.Text), Val(txtQty.Text), Val(txtAmount.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), Val(txtTotalAmount.Text), Val(txtProductID.Text))
        '        Dim k As Double = 0
        '        k = GrandTotal()
        '        k = Math.Round(k, 2)
        '        txtGrandTotal.Text = k
        '        Compute1()
        '        Clear()
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        'End If

        'If e.KeyCode = Keys.W Then
        '    If (Me.DataGridView1.Rows.Count > 0) Then
        '        If lblSet.Text = "Not Allowed" Then
        '            btnRemove.Enabled = True
        '            btnListUpdate.Enabled = True
        '        Else
        '            btnRemove.Enabled = True
        '            btnListUpdate.Enabled = True
        '        End If
        '        Me.btnAdd.Enabled = False
        '        DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column3")
        '        Dim row As DataGridViewRow = Me.DataGridView1.SelectedRows.Item(0)
        '        Me.txtProductCode.Text = (row.Cells.Item(0).Value)
        '        Me.txtProductName.Text = (row.Cells.Item(1).Value)
        '        Me.txtBarcode.Text = (row.Cells.Item(2).Value)
        '        Me.txtCostPrice.Text = (row.Cells.Item(3).Value)
        '        Me.txtSellingPrice.Text = (row.Cells.Item(4).Value)
        '        Me.txtMargin.Text = (row.Cells.Item(5).Value)
        '        Me.txtQty.Text = (row.Cells.Item(6).Value)
        '        Me.txtAmount.Text = (row.Cells.Item(7).Value)
        '        Me.txtDiscountPer.Text = (row.Cells.Item(8).Value)
        '        Me.txtDiscountAmount.Text = (row.Cells.Item(9).Value)
        '        Me.txtVAT.Text = (row.Cells.Item(10).Value)
        '        Me.txtVATAmount.Text = (row.Cells.Item(11).Value)
        '        Me.txtTotalAmount.Text = (row.Cells.Item(12).Value)
        '        Me.txtProductID.Text = (row.Cells.Item(13).Value)

        '        txtQty.Focus()
        '    End If
        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If txtCustomerType.Text <> "Non Regular" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim rpt As New rptInvoice56 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand.CommandText = "SELECT Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, InvoiceInfo.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Invoice_Product.Barcode, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo ON Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
                MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                MyCommand1.CommandText = "SELECT * from Company"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA.Fill(myDS, "InvoiceInfo")
                myDA.Fill(myDS, "Invoice_Product")
                myDA.Fill(myDS, "Customer")
                myDA.Fill(myDS, "Product")
                myDA1.Fill(myDS, "Company")
                rpt.SetDataSource(myDS)
                rpt.SetParameterValue("p1", txtCustomerID.Text)
                rpt.SetParameterValue("p2", Today)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.Show()
            End If
            If txtCustomerType.Text = "Non Regular" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim rpt As New rptInvoice2 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand.CommandText = "SELECT Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, InvoiceInfo.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Invoice_Product.Barcode, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo ON Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
                MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                MyCommand1.CommandText = "SELECT * from Company"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA.Fill(myDS, "InvoiceInfo")
                myDA.Fill(myDS, "Invoice_Product")
                myDA.Fill(myDS, "Customer")
                myDA.Fill(myDS, "Product")
                myDA1.Fill(myDS, "Company")
                rpt.SetDataSource(myDS)
                rpt.SetParameterValue("p1", txtCustomerID.Text)
                rpt.SetParameterValue("p2", Today)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtProductName_TextChanged(sender As Object, e As EventArgs) Handles txtProductName.TextChanged
        Try

            If txtProductName.Text <> "" Then
                dgw.Visible = True
                ' txtDiscountPer.Enabled = True
                'txtDiscountAmount.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),(CostPrice),(SellingPrice),(Discount),(VAT),Qty, RTRIM(Product.SellingPrice2) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Qty > 0  order by ProductCode", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
                End While
                con.Close()
            Else
                dgw.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged
        'txtTotalPayment.Text = Val(txtGrandTotal.Text)
    End Sub

    Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgw.MouseDoubleClick
    End Sub

    Private Sub txtDiscountAmount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscountAmount.TextChanged
        '  txtDiscountPer.Text = "0"
        txtTotalAmount.Text = Val(txtAmount.Text) + Val(txtVATAmount.Text) - Val(txtDiscountAmount.Text)
        '  txtDiscountPer.Text = Val(txtDiscountAmount.Text) * 100 / Val(txtTotalAmount.Text)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Me.WindowState = FormWindowState.Normal Then
            ' تكبير الفورم ليشغل الشاشة كاملة
            Dim parentForm As Form = Me.ParentForm
            Me.Parent = Nothing
            parentForm.Controls.Add(Me)
            Me.Dock = DockStyle.Fill
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.Hide()
            Me.WindowState = FormWindowState.Normal
            Me.Show(frmMainMenu.DockPanel1)

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub txtProductName_LostFocus(sender As Object, e As EventArgs) Handles txtProductName.LostFocus
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
    End Sub

    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtProductID.Text = dr.Cells(0).Value.ToString()
                txtProductCode.Text = dr.Cells(1).Value.ToString()
                txtProductName.Text = dr.Cells(2).Value.ToString()
                txtBarcode.Text = dr.Cells(3).Value.ToString()
                txtCostPrice.Text = dr.Cells(4).Value.ToString()
                If ComboBox1.SelectedIndex = 0 Then
                    txtSellingPrice.Text = dr.Cells(5).Value.ToString()
                Else
                    txtSellingPrice.Text = dr.Cells(9).Value.ToString()
                End If

                txtVAT.Text = dr.Cells(7).Value.ToString()

                Dim num As Double
                num = Val(dr.Cells(5).Value) - Val(dr.Cells(4).Value)
                num = Math.Round(num, 2)
                txtMargin.Text = num
                txtDiscountPer.Text = dr.Cells(6).Value.ToString()
                txtVAT.Text = dr.Cells(7).Value.ToString()
                txtQty.Focus()

                lblSet.Text = ""
                dgw.Visible = False


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class

