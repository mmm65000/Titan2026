Imports System.Data.SqlClient
Imports System.IO

Imports Microsoft.SqlServer.Management.Smo
Imports System.Globalization
Public Class Frmhome
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Private Sub btnCompanyInfo_Click(sender As Object, e As EventArgs)

        'frmCompany.Reset()
        'frmCompany.ShowDialog()
    End Sub

    Private Sub btnCreditCustomer_Click(sender As Object, e As EventArgs) Handles btnCreditCustomer.Click

        frmCustomer.Reset()
        frmCustomer.ShowDialog()
    End Sub

    Private Sub btnRegistration_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub btnDatabase_Click(sender As Object, e As EventArgs)
        'Try
        '    With frmMainMenu.OpenFileDialog1
        '        .Filter = ("DB Backup File|*.bak;")
        '        .FilterIndex = 4
        '    End With
        '    'Clear the file name
        '    frmMainMenu.OpenFileDialog1.FileName = ""

        '    If frmMainMenu.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
        '        Cursor = Cursors.WaitCursor
        '        frmMainMenu.Timer2.Enabled = True
        '        SqlConnection.ClearAllPools()
        '        con = New SqlConnection(cs)
        '        con.Open()
        '        Dim cb As String = "USE Master ALTER DATABASE INV_DB SET Single_User WITH Rollback Immediate Restore database INV_DB FROM disk='" & frmMainMenu.OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE INV_DB SET Multi_User "
        '        cmd = New SqlCommand(cb)
        '        cmd.Connection = con
        '        cmd.ExecuteReader()
        '        con.Close()
        '        Dim st As String = "Sucessfully performed the restore"
        '        LogFunc(frmMainMenu.lblUser.Text, st)
        '        MessageBox.Show("تمت بنجاح ", "استعادة قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        'frmMainMenu.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
        'If screenWidth <= 1024 Then
        '    lblClock.Text = Now.ToString("dd/MM/yyyy ")
        '    Label1.text = Now.ToString(" hh:mm:ss tt")
        'Else
        '    lblClock.Text = Now.ToString("dddd, dd MMMM yyyy")
        '    Label1.Text = Now.ToString("hh:mm:ss tt")
        'End If
    End Sub
    Private Sub btnLogs_Click(sender As Object, e As EventArgs)
        'frmLogs.Reset()
        'frmLogs.lblUser.Text = frmMainMenu.lblUser.Text
        'frmLogs.ShowDialog()
    End Sub

    Private Sub btnLoyaltyCard_Click(sender As Object, e As EventArgs)
        'frmMainMenu.Backup()
    End Sub

    Private Sub btnBankReconciliation_Click(sender As Object, e As EventArgs) Handles btnBankReconciliation.Click
        frmPayment.lblUser.Text = frmMainMenu.lblUser.Text
        frmPayment.Reset()
        frmPayment.ShowDialog()
    End Sub

    Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
        frmPayment_2.lblUser.Text = frmMainMenu.lblUser.Text
        frmPayment_2.Reset()
        frmPayment_2.ShowDialog()
    End Sub

    Private Sub btnSalesmanMaster_Click(sender As Object, e As EventArgs) Handles btnSalesmanMaster.Click
        frmSalesman.Reset()
        frmSalesman.lblUser.Text = frmMainMenu.lblUser.Text
        frmSalesman.ShowDialog()
    End Sub

    Private Sub btnCategories_Click(sender As Object, e As EventArgs)
        'frmCategory.lblUser.Text = frmMainMenu.lblUser.Text
        'frmCategory.Reset()
        'frmCategory.ShowDialog()
    End Sub

    Private Sub btnProductMaster_Click(sender As Object, e As EventArgs) Handles btnProductMaster.Click
        frmProduct.lblUser.Text = frmMainMenu.lblUser.Text
        frmProduct.lblUserType.Text = frmMainMenu.lblUserType.Text
        frmProduct.Show(DockPanel)
        frmProduct.Reset()

        frmProduct.Focus()
    End Sub

    Private Sub btnQuotation_Click(sender As Object, e As EventArgs)
        'frmQuotation.lblUser.Text = frmMainMenu.lblUser.Text
        'frmQuotation.lblUserType.Text = frmMainMenu.lblUserType.Text
        'frmQuotation.Reset()
        'frmQuotation.ShowDialog()
    End Sub

    Private Sub btnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
        frmPurchaseEntry.lblUser.Text = frmMainMenu.lblUser.Text
        frmPurchaseEntry.lblUserType.Text = frmMainMenu.lblUserType.Text
        frmPurchaseEntry.Reset()
        frmPurchaseEntry.Show()
    End Sub

    Private Sub btnPurchaseReturn_Click(sender As Object, e As EventArgs) Handles btnPurchaseReturn.Click
        frmPurchaseReturn.lblUser.Text = frmMainMenu.lblUser.Text
        frmPurchaseReturn.lblUserType.Text = frmMainMenu.lblUserType.Text
        frmPurchaseReturn.Reset()
        frmPurchaseReturn.Show()
    End Sub

    Private Sub btnSalesReturn_Click(sender As Object, e As EventArgs) Handles btnSalesReturn.Click

        frmSalesReturn.lblUser.Text = frmMainMenu.lblUser.Text
        frmSalesReturn.lblUserType.Text = frmMainMenu.lblUserType.Text
        frmSalesReturn.Show(DockPanel)
        frmSalesReturn.Reset()

        frmSalesReturn.Focus()
    End Sub

    Private Sub btnStockAdjustment_Click(sender As Object, e As EventArgs) Handles btnStockAdjustment.Click
        frmStockBalance.Text = frmMainMenu.lblUser.Text
        frmStockBalance.Show(DockPanel)

        frmStockBalance.Focus()
    End Sub

    Private Sub btnBarcodeLabelPrinting_Click(sender As Object, e As EventArgs) Handles btnBarcodeLabelPrinting.Click
        frmBarcodeLabelPrinting.Reset()
        frmBarcodeLabelPrinting.ShowDialog()
    End Sub

    Private Sub btnAccountingReports_Click(sender As Object, e As EventArgs) Handles btnAccountingReports.Click
        frmGeneralLedger.Reset()
        frmGeneralLedger.ShowDialog()
    End Sub

    Private Sub btnPOSReport_Click(sender As Object, e As EventArgs) Handles btnPOSReport.Click
        frmSalesReport.Reset()
        frmSalesReport.ShowDialog()
    End Sub

    Private Sub btnPOSRecord_Click(sender As Object, e As EventArgs) Handles btnPOSRecord.Click
        frmDebtorsReport.ShowDialog()
    End Sub

    Private Sub btnWorkPeriod_Click(sender As Object, e As EventArgs) Handles btnWorkPeriod.Click
        frmProfitAndLossReport.Reset()
        frmProfitAndLossReport.ShowDialog()
    End Sub

    Private Sub BtnVoucher_Click(sender As Object, e As EventArgs) Handles BtnVoucher.Click
        frmVoucher.Reset()
        frmVoucher.lblUser.Text = frmMainMenu.lblUser.Text
        frmVoucher.ShowDialog()
    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        frmSalesmanLedger.Reset()
        frmSalesmanLedger.ShowDialog()
    End Sub

    Private Sub btnStockTransfer_Issue_Click(sender As Object, e As EventArgs) Handles btnStockTransfer_Issue.Click
        frmCurrentStock.Reset()
        frmCurrentStock.ShowDialog()
    End Sub

    Private Sub btnSupplier_Click(sender As Object, e As EventArgs) Handles btnSupplier.Click
        frmSupplier.lblUser.Text = frmMainMenu.lblUser.Text
        frmSupplier.Reset()
        frmSupplier.ShowDialog()
    End Sub

    Private Sub btnWallet_Click(sender As Object, e As EventArgs) Handles btnWallet.Click
        frmPOS.lblUser.Text = frmMainMenu.lblUser.Text
        frmPOS.lblUserType.Text = frmMainMenu.lblUserType.Text
        frmPOS.Show(DockPanel)
        frmPOS.Reset()

        frmPOS.Focus()
    End Sub

    Private Sub Frmhome_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub


    Private Sub btnSetting_Click(sender As Object, e As EventArgs)
        'frmSqlServerSetting.Reset()
        'frmSqlServerSetting.lblSet.Text = "Main Form"
        'frmSqlServerSetting.ShowDialog()
    End Sub

    Private Sub btnPurchaseOrder_Click(sender As Object, e As EventArgs) Handles btnPurchaseOrder.Click
        frmPurchaseReport.Reset()
        frmPurchaseReport.ShowDialog()
    End Sub


End Class