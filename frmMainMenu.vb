Imports System.Data.SqlClient
Imports System.IO

Imports Microsoft.SqlServer.Management.Smo
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text

Public Class frmMainMenu
    Dim Filename As String
    Dim i1, i2 As Integer

    ' Helper: encrypt bytes using AES with password-derived key
    Private Function EncryptBytes(plainBytes As Byte(), password As String) As Byte()
        Using aes As New RijndaelManaged()
            Dim salt As Byte() = Encoding.UTF8.GetBytes("s@1tV@lue" & Environment.MachineName)
            Dim pdb As New Rfc2898DeriveBytes(password, salt, 1000)
            aes.Key = pdb.GetBytes(32)
            aes.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(plainBytes, 0, plainBytes.Length)
                    cs.FlushFinalBlock()
                    Return ms.ToArray()
                End Using
            End Using
        End Using
    End Function

    ' Helper: decrypt bytes using AES with password-derived key
    Private Function DecryptBytes(cipherBytes As Byte(), password As String) As Byte()
        Using aes As New RijndaelManaged()
            Dim salt As Byte() = Encoding.UTF8.GetBytes("s@1tV@lue" & Environment.MachineName)
            Dim pdb As New Rfc2898DeriveBytes(password, salt, 1000)
            aes.Key = pdb.GetBytes(32)
            aes.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.FlushFinalBlock()
                    Return ms.ToArray()
                End Using
            End Using
        End Using
    End Function

    ' جديد: الحصول على عدد الأيام المتبقية من فترة التجربة
    Private Function GetTrialDaysLeft() As Integer
        Try
            Dim regPath As String = "HKEY_CURRENT_USER\SOFTWARE\InventorySoft9"
            Dim valueName As String = "TrialData"
            Dim stored As Object = My.Computer.Registry.GetValue(regPath, valueName, Nothing)
            If stored Is Nothing Then
                Return -1
            End If
            Dim password As String = Environment.MachineName & "|INV"
            Dim protectedBytes As Byte() = Convert.FromBase64String(stored.ToString())
            Dim plainBytes As Byte() = DecryptBytes(protectedBytes, password)
            Dim storedDateStr As String = Encoding.UTF8.GetString(plainBytes)
            Dim firstRunDate As Date
            If Date.TryParseExact(storedDateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, firstRunDate) Then
                Dim usedDays As Integer = (Date.Now.Date - firstRunDate.Date).Days
                Dim trialDays As Integer = 7 ' تغيير هذه القيمة لتغيير مدة التجربة
                Dim daysLeft As Integer = trialDays - usedDays
                If daysLeft < 0 Then daysLeft = 0
                Return daysLeft
            End If
            Return -1
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
        ' frmSalesLocations.ShowDialog()

    End Sub
    Sub Backup()
        Try
            Dim dt As DateTime = Today
            Dim destdir As String = "INV_DB " & System.DateTime.Now.ToString("dd-MM-yyyy_h-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database INV_DB to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub


    Private Sub LogsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogsToolStripMenuItem.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim dt As DateTime = Today
        lblDateTime.Text = dt.ToString("dd/MM/yyyy")
        lblTime.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NotepadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NotepadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub WordpadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WordpadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("wordpad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSWordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MSWordToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("winword.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TaskManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("TaskMgr.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SystemInfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SystemInfoToolStripMenuItem.Click
        frmSystemInfo.ShowDialog()
    End Sub
    Sub LogOut()
        frmPurchaseEntry.Hide()
        frmProduct.Hide()
        Dim st As String = "Successfully logged out"
        LogFunc(lblUser.Text, st)
        Me.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserID.Focus()
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Try
            If MessageBox.Show("هل تريد تبديل المستخدم الحالي?", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("هل تريد عمل نسخة احتياطية من البرنامج قبل الخروج?", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Backup()
                    LogOut()
                    Reset()
                Else
                    LogOut()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMainMenu_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'e.Cancel = True
        Application.Exit()
        End

    End Sub

    Private Sub CompanyInfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompanyInfoToolStripMenuItem.Click
        frmCompany.lblUser.Text = lblUser.Text
        frmCompany.Reset()
        frmCompany.ShowDialog()
    End Sub



    Private Sub SupplierToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        frmSupplier.lblUser.Text = lblUser.Text
        frmSupplier.Reset()
        frmSupplier.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CustomerToolStripMenuItem1.Click

        frmCustomerRecord1.Show(DockPanel1)
        frmCustomerRecord1.Reset()
        frmCustomerRecord1.MdiParent = Me


    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SupplierToolStripMenuItem1.Click
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Function HandleRegistry() As Boolean
        ' أولاً: تحقق إن كانت النسخة مفعلّة
        Try
            Dim act As Object = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\InventorySoft9", "Activated", Nothing)
            If act IsNot Nothing AndAlso act.ToString() = "1" Then
                Return True
            End If
        Catch exAct As Exception
            ' تجاهل أخطاء القراءة
        End Try

        'تخزين وتحقق من تاريخ أول تشغيل بطريقة آمنة في HKEY_CURRENT_USER\SOFTWARE\InventorySoft9\TrialData
        'يتم تشفير التاريخ بواسطة AES مع مفتاح مشتق من اسم الجهاز
        Try
            Dim regPath As String = "HKEY_CURRENT_USER\SOFTWARE\InventorySoft9"
            Dim valueName As String = "TrialData"
            Dim stored As Object = My.Computer.Registry.GetValue(regPath, valueName, Nothing)
            Dim password As String = Environment.MachineName & "|INV" 'قيمة إضافية لتحسين الأمان
            Dim firstRunDate As Date

            If stored Is Nothing Then
                'أول تشغيل: سجل التاريخ المشفّر
                firstRunDate = Date.Today
                Dim plain As Byte() = Encoding.UTF8.GetBytes(firstRunDate.ToString("yyyy-MM-dd"))
                Dim protectedBytes As Byte() = EncryptBytes(plain, password)
                My.Computer.Registry.SetValue(regPath, valueName, Convert.ToBase64String(protectedBytes))
                Return True
            Else
                Try
                    Dim protectedBytes As Byte() = Convert.FromBase64String(stored.ToString())
                    Dim plainBytes As Byte() = DecryptBytes(protectedBytes, password)
                    Dim storedDateStr As String = Encoding.UTF8.GetString(plainBytes)

                    If Date.TryParseExact(storedDateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, firstRunDate) Then
                        If (Date.Now - firstRunDate).Days > 7 Then
                            Return False 'انتهت فترة التجربة
                        End If
                        Return True
                    Else
                        'تنسيق غير متوقع: أعد تهيئة إلى اليوم
                        firstRunDate = Date.Today
                        Dim newProtected As Byte() = EncryptBytes(Encoding.UTF8.GetBytes(firstRunDate.ToString("yyyy-MM-dd")), password)
                        My.Computer.Registry.SetValue(regPath, valueName, Convert.ToBase64String(newProtected))
                        Return True
                    End If
                Catch exInner As Exception
                    'فشل فك التشفير أو تحويل القيمة => اعتبر التجربة منتهية لتجنب التلاعب
                    Return False
                End Try
            End If
        Catch ex As Exception
            'فشل عام أثناء التحقق -> امنع التشغيل لتكون الحالة آمنة
            Return False
        End Try
    End Function

    Private Sub frmMainMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim result As Boolean = HandleRegistry()
        If result = False Then
            'انتهت فترة التجربة أو فشل التحقق: عرض نافذة التفعيل أو إغلاق البرنامج
            If MessageBox.Show("انتهت مدة النسخة التجريبية. هل تريد إدخال رمز التفعيل الآن؟", "انتهاء النسخة التجريبية", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                frmActivation.ShowDialog()
                'يفترض أن frmActivation عند النجاح يكتب القيمة "Activated" = "1" في نفس مسار الريجستري
                Dim act As Object = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InventorySoft9", "Activated", Nothing)
                If act IsNot Nothing AndAlso act.ToString() = "1" Then
                    'تم التفعيل - تابع التشغيل الطبيعي
                Else
                    MessageBox.Show("لم يتم التفعيل. سيتم إغلاق البرنامج.", "مغلق", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Application.Exit()
                    End
                End If
            Else
                MessageBox.Show("البرنامج سيغلق لأنّه غير مفعل.", "مغلق", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.Exit()
                End
            End If
        End If

        ' عرض عدد أيام النسخة التجريبية المتبقية إن وُجدت
        Try
            Dim actFlag As Object = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InventorySoft9", "Activated", Nothing)
            If actFlag Is Nothing OrElse actFlag.ToString() <> "1" Then
                Dim daysLeft As Integer = GetTrialDaysLeft()
                If daysLeft >= 0 Then
                    If daysLeft = 0 Then
                        Me.Text = Me.Text & " - (النسخة التجريبية تنتهي اليوم)"
                    Else
                        Me.Text = Me.Text & " - (أيام النسخة التجريبية المتبقية: " & daysLeft.ToString() & ")"
                    End If
                End If
            End If
        Catch ex As Exception
            ' تجاهل أخطاء العرض
        End Try

        If lblUserType.Text = "Admin" Then
            frmPOS.lblUser1.Text = "1"
            MasterEntryToolStripMenuItem.Enabled = True
            المستخدمينToolStripMenuItem.Enabled = True
            LogsToolStripMenuItem.Enabled = True
            استرجاعنسخةاحتياطيةToolStripMenuItem.Enabled = True
            CustomerToolStripMenuItem.Enabled = True
            SupplierToolStripMenuItem.Enabled = True
            ProductToolStripMenuItem.Enabled = True
            StockToolStripMenuItem.Enabled = True
            ServiceToolStripMenuItem.Enabled = True
            جردالمخزونToolStripMenuItem.Enabled = True
            BillingToolStripMenuItem.Enabled = True
            QuotationToolStripMenuItem.Enabled = True
            RecordToolStripMenuItem.Enabled = True
            ReportsToolStripMenuItem.Enabled = True
            VoucherToolStripMenuItem.Enabled = True
            SalesmanToolStripMenuItem.Enabled = True
            SendSMSToolStripMenuItem.Enabled = True
            SalesReturnToolStripMenuItem.Enabled = True
            PaymentToolStripMenuItem.Enabled = True
            ToolStripMenuItemSetting.Enabled = True
            ToolStripMenuItem2.Enabled = True
        End If
        If lblUserType.Text = "Sales Person" Then
            MasterEntryToolStripMenuItem.Enabled = False
            المستخدمينToolStripMenuItem.Enabled = False
            LogsToolStripMenuItem.Enabled = False
            استرجاعنسخةاحتياطيةToolStripMenuItem.Enabled = False
            CustomerToolStripMenuItem.Enabled = True
            SupplierToolStripMenuItem.Enabled = False
            ProductToolStripMenuItem.Enabled = False
            StockToolStripMenuItem.Enabled = False
            ServiceToolStripMenuItem.Enabled = True
            جردالمخزونToolStripMenuItem.Enabled = True
            BillingToolStripMenuItem.Enabled = True
            QuotationToolStripMenuItem.Enabled = True
            RecordToolStripMenuItem.Enabled = False
            ReportsToolStripMenuItem.Enabled = False
            VoucherToolStripMenuItem.Enabled = False
            SalesmanToolStripMenuItem.Enabled = False
            SendSMSToolStripMenuItem.Enabled = False
            SalesReturnToolStripMenuItem.Enabled = True
            PaymentToolStripMenuItem.Enabled = False
            ToolStripMenuItemSetting.Enabled = False
            Frmhome.btnProductMaster.Enabled = False
            Frmhome.btnStockAdjustment.Enabled = False

            Frmhome.btnSalesmanMaster.Enabled = False
            Frmhome.btnPurchaseOrder.Enabled = False
            Frmhome.btnPayment.Enabled = False
            Frmhome.btnWorkPeriod.Enabled = False
            Frmhome.btnPOSReport.Enabled = False
            Frmhome.btnAccountingReports.Enabled = False
            frmStockBalance.SlideButton1.Enabled = False

        End If
        If lblUserType.Text = "Inventory Manager" Then
            MasterEntryToolStripMenuItem.Enabled = False
            المستخدمينToolStripMenuItem.Enabled = False
            LogsToolStripMenuItem.Enabled = False
            استرجاعنسخةاحتياطيةToolStripMenuItem.Enabled = False
            CustomerToolStripMenuItem.Enabled = False
            SupplierToolStripMenuItem.Enabled = False
            ProductToolStripMenuItem.Enabled = True
            StockToolStripMenuItem.Enabled = True
            ServiceToolStripMenuItem.Enabled = False
            جردالمخزونToolStripMenuItem.Enabled = True
            BillingToolStripMenuItem.Enabled = False
            QuotationToolStripMenuItem.Enabled = False
            RecordToolStripMenuItem.Enabled = False
            ReportsToolStripMenuItem.Enabled = False
            VoucherToolStripMenuItem.Enabled = False
            SalesmanToolStripMenuItem.Enabled = False
            SendSMSToolStripMenuItem.Enabled = False
            PaymentToolStripMenuItem.Enabled = False
            ToolStripMenuItemSetting.Enabled = False
            Frmhome.btnProductMaster.Enabled = False
            Frmhome.btnStockAdjustment.Enabled = False
            Frmhome.btnSalesmanMaster.Enabled = False
            Frmhome.btnPurchaseOrder.Enabled = False
            Frmhome.btnPayment.Enabled = False
            Frmhome.btnWorkPeriod.Enabled = False
            Frmhome.btnPOSReport.Enabled = False
            Frmhome.btnAccountingReports.Enabled = False

            frmStockBalance.SlideButton1.Enabled = False

        End If
        '###############33
        If lblUserType.Text = "accountant" Then
            MasterEntryToolStripMenuItem.Enabled = False
            المستخدمينToolStripMenuItem.Enabled = False
            LogsToolStripMenuItem.Enabled = False
            استرجاعنسخةاحتياطيةToolStripMenuItem.Enabled = False
            CustomerToolStripMenuItem.Enabled = False
            SupplierToolStripMenuItem.Enabled = False
            ProductToolStripMenuItem.Enabled = False
            StockToolStripMenuItem.Enabled = False
            ServiceToolStripMenuItem.Enabled = True
            جردالمخزونToolStripMenuItem.Enabled = True
            BillingToolStripMenuItem.Enabled = False
            QuotationToolStripMenuItem.Enabled = True
            RecordToolStripMenuItem.Enabled = True
            ReportsToolStripMenuItem.Enabled = True
            VoucherToolStripMenuItem.Enabled = False
            SalesmanToolStripMenuItem.Enabled = False
            SendSMSToolStripMenuItem.Enabled = False
            PaymentToolStripMenuItem.Enabled = True
            ToolStripMenuItemSetting.Enabled = False

            Frmhome.btnSalesmanMaster.Enabled = False
            Frmhome.btnPurchaseOrder.Enabled = False
            Frmhome.btnPayment.Enabled = False
            Frmhome.btnWorkPeriod.Enabled = False
            Frmhome.btnPOSReport.Enabled = False
            Frmhome.btnAccountingReports.Enabled = False
            frmStockBalance.SlideButton1.Enabled = False



        End If

        Me.DockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingMdi   '--->Requires:  "Me.IsMdiContainer = True"
        Me.IsMdiContainer = True    'Must be defined at design-time or at run-time.

        Frmhome.Show(DockPanel1)
        Frmhome.MdiParent = Me
        Frmhome.Focus()


        'frmStockBalance.Show(DockPanel1)
        'frmStockBalance.MdiParent = Me
        'frmStockBalance.Focus()


    End Sub

    Private Sub StockToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles StockToolStripMenuItem1.Click
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub




    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs)
        Reset()
    End Sub

    Private Sub ContactsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactsToolStripMenuItem.Click
        frmContacts.lblUser.Text = lblUser.Text
        frmContacts.Reset()
        frmContacts.ShowDialog()
    End Sub

    Private Sub IndividualToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs)
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub

    Private Sub ProductToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductToolStripMenuItem.Click
    End Sub

    Private Sub ProductToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ProductToolStripMenuItem2.Click
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub

    Private Sub ServiceToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ServiceToolStripMenuItem1.Click
        frmServicesRecord.Reset()
        frmServicesRecord.ShowDialog()
    End Sub

    Private Sub QuotationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QuotationToolStripMenuItem.Click
        frmQuotation.lblUser.Text = lblUser.Text
        frmQuotation.lblUserType.Text = lblUserType.Text
        frmQuotation.Reset()
        frmQuotation.ShowDialog()
    End Sub

    Private Sub QuotationToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles QuotationToolStripMenuItem1.Click
        frmQuotationRecord1.Reset()
        frmQuotationRecord1.ShowDialog()
    End Sub

    Public Sub ProductsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles POSToolStripMenuItem.Click



        frmPOS.lblUser.Text = lblUser.Text
        frmPOS.lblUserType.Text = lblUserType.Text
        frmPOS.Show(DockPanel1)
        frmPOS.Reset()
        frmPOS.MdiParent = Me
        frmPOS.Focus()

    End Sub

    Private Sub BillingProductsServiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BillingProductsServiceToolStripMenuItem.Click
        frmServiceBillingRecord.Reset()
        frmServiceBillingRecord.ShowDialog()
    End Sub

    Private Sub SMSSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SMSSettingToolStripMenuItem.Click
        frmSMSSetting.Reset()
        frmSMSSetting.ShowDialog()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        frmSalesReport.Reset()
        frmSalesReport.ShowDialog()
    End Sub

    Private Sub ServiceBillingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ServiceBillingToolStripMenuItem.Click
        frmServiceDoneReport.Reset()
        frmServiceDoneReport.ShowDialog()
    End Sub

    Private Sub StockInAndStockOutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StockInAndStockOutToolStripMenuItem.Click
        frmStockInAndOutReport.ShowDialog()
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click
        frmPurchaseReport.Reset()
        frmPurchaseReport.ShowDialog()
    End Sub

    Private Sub ProfitAndLossToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProfitAndLossToolStripMenuItem.Click
        frmProfitAndLossReport.Reset()
        frmProfitAndLossReport.ShowDialog()
    End Sub

    Private Sub VoucherToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VoucherToolStripMenuItem.Click
        frmVoucher.Reset()
        frmVoucher.lblUser.Text = lblUser.Text
        frmVoucher.ShowDialog()
    End Sub

    Private Sub ExpenditureToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpenditureToolStripMenuItem.Click
        frmVoucherReport.Reset()
        frmVoucherReport.ShowDialog()
    End Sub

    Private Sub CreditorsAndDebtorsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CreditorsAndDebtorsToolStripMenuItem.Click
        frmDebtorsReport.ShowDialog()
    End Sub

    Private Sub SQLServerSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SQLServerSettingToolStripMenuItem.Click
        frmSqlServerSetting.Reset()
        frmSqlServerSetting.lblSet.Text = "Main Form"
        frmSqlServerSetting.ShowDialog()
    End Sub

    Private Sub PurchaseDaybookToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PurchaseDaybookToolStripMenuItem.Click
        frmPurchaseDaybook.Reset()
        frmPurchaseDaybook.ShowDialog()
    End Sub

    Private Sub GeneralLedgerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GeneralLedgerToolStripMenuItem.Click
        frmGeneralLedger.Reset()
        frmGeneralLedger.ShowDialog()
    End Sub

    Private Sub GeneralDaybookToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GeneralDaybookToolStripMenuItem.Click
        frmGeneralDayBook.Reset()
        frmGeneralDayBook.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        frmPayment.lblUser.Text = lblUser.Text
        frmPayment.Reset()
        frmPayment.ShowDialog()
    End Sub

    Private Sub PaymentsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaymentsToolStripMenuItem.Click
        frmPaymentRecord.Reset()
        frmPaymentRecord.ShowDialog()
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
        frmTrialBalance.Reset()
        frmTrialBalance.ShowDialog()
    End Sub

    Private Sub SupplierLedgerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupplierLedgerToolStripMenuItem.Click
        frmSupplierLedger.Reset()
        frmSupplierLedger.ShowDialog()
    End Sub

    Private Sub CustomerLedgerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CustomerLedgerToolStripMenuItem.Click
        frmCustomerLedger.Reset()
        frmCustomerLedger.ShowDialog()
    End Sub

    Private Sub SMSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SMSToolStripMenuItem.Click
        frmSMS.Reset()
        frmSMS.lblUser.Text = lblUser.Text
        frmSMS.ShowDialog()
    End Sub


    Private Sub SalesmanToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs)
        frmSalesman.Reset()
        frmSalesman.lblUser.Text = lblUser.Text
        frmSalesman.ShowDialog()
    End Sub

    Private Sub SalesmanLedgerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalesmanLedgerToolStripMenuItem.Click
        frmSalesmanLedger.Reset()
        frmSalesmanLedger.ShowDialog()
    End Sub

    Private Sub SalesmanCommissionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalesmanCommissionToolStripMenuItem.Click
        frmSalesmanCommmissionReport.Reset()
        frmSalesmanCommmissionReport.ShowDialog()
    End Sub

    Private Sub TaxToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaxToolStripMenuItem.Click
        frmTaxReport.Reset()
        frmTaxReport.ShowDialog()
    End Sub

    Private Sub SendSMSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SendSMSToolStripMenuItem.Click
        frmSendSMS.lblUser.Text = lblUser.Text
        frmSendSMS.Reset()
        frmSendSMS.ShowDialog()
    End Sub

    Private Sub CreditTermsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CreditTermsToolStripMenuItem.Click
        frmCreditTermsReport.Reset()
        frmCreditTermsReport.ShowDialog()
    End Sub

    Private Sub CreditTermsStatementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditTermsStatementsToolStripMenuItem.Click
        frmCreditTermsStatementsReport.Reset()
        frmCreditTermsStatementsReport.ShowDialog()
    End Sub

    Private Sub SalesmanToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalesmanToolStripMenuItem.Click
        frmSalesman.Reset()
        frmSalesman.lblUser.Text = lblUser.Text
        frmSalesman.ShowDialog()
    End Sub

    Private Sub SalesmanToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SalesmanToolStripMenuItem1.Click
        frmSalesmanRecord.Reset()
        frmSalesmanRecord.lblSet.Text = ""
        frmSalesmanRecord.ShowDialog()
    End Sub

    Private Sub BarcodeLabelPrintingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BarcodeLabelPrintingToolStripMenuItem.Click
        frmBarcodeLabelPrinting.Reset()
        frmBarcodeLabelPrinting.ShowDialog()
    End Sub

    Private Sub PurchaseEntryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PurchaseEntryToolStripMenuItem.Click
        frmPurchaseEntry.lblUser.Text = lblUser.Text
        frmPurchaseEntry.lblUserType.Text = lblUserType.Text
        frmPurchaseEntry.Reset()
        frmPurchaseEntry.Show()
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PurchaseReturnToolStripMenuItem.Click
        frmPurchaseReturn.lblUser.Text = lblUser.Text
        frmPurchaseReturn.lblUserType.Text = lblUserType.Text
        frmPurchaseReturn.Reset()
        frmPurchaseReturn.Show()
    End Sub

    Private Sub EmailSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmailSettingToolStripMenuItem.Click
        frmEmailSetting.Reset()
        frmEmailSetting.ShowDialog()
    End Sub

    Private Sub ServiceCreationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ServiceCreationToolStripMenuItem.Click
        frmServices.lblUser.Text = lblUser.Text
        frmServices.lblUserType.Text = lblUserType.Text
        frmServices.Reset()
        frmServices.ShowDialog()
    End Sub

    Private Sub ServiceBillingToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ServiceBillingToolStripMenuItem1.Click
        frmServiceBilling.lblUser.Text = lblUser.Text
        frmServiceBilling.lblUserType.Text = lblUserType.Text
        frmServiceBilling.Reset()
        frmServiceBilling.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If MessageBox.Show("هل أنت متأكد أنك تريد إغلاق البرنامج?", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Application.Exit()
                End
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        frmPayment_2.lblUser.Text = lblUser.Text
        frmPayment_2.Reset()
        frmPayment_2.ShowDialog()
    End Sub

    Private Sub اشعــــارخصــمدائـــنToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اشعــــارخصــمدائـــنToolStripMenuItem.Click
        frmPayment_3.lblUser.Text = lblUser.Text
        frmPayment_3.Reset()
        frmPayment_3.ShowDialog()

    End Sub



    Private Sub المساعدةToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub ToolStripMenuItemSetting_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSetting.Click
        frmSetting.Show()
    End Sub



    Private Sub الارباحToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الارباحToolStripMenuItem.Click
        frmOverallReport.Reset()
        frmOverallReport.ShowDialog()
    End Sub






    Private Sub SalesReturnToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalesReturnToolStripMenuItem.Click


        frmSalesReturn.lblUser.Text = lblUser.Text
        frmSalesReturn.lblUserType.Text = lblUserType.Text
        frmSalesReturn.Show(DockPanel1)
        frmSalesReturn.Reset()
        frmSalesReturn.MdiParent = Me
        frmSalesReturn.Focus()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ترميزالفئاتالرئيسيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ترميزالفئاتالرئيسيةToolStripMenuItem.Click
        frmCategory.lblUser.Text = lblUser.Text
        frmCategory.Reset()
        frmCategory.ShowDialog()

    End Sub

    Private Sub ترميزالفئاتالفرعيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ترميزالفئاتالفرعيةToolStripMenuItem.Click
        frmSubCategory.lblUser.Text = lblUser.Text
        frmSubCategory.Reset()
        frmSubCategory.ShowDialog()

    End Sub

    Private Sub ترميزمراكزالبيعToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ترميزمراكزالبيعToolStripMenuItem1.Click
        frmContacts_2.lblUser.Text = lblUser.Text
        frmContacts_2.Reset()
        frmContacts_2.ShowDialog()

    End Sub

    Private Sub نسخاحتياطيToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نسخاحتياطيToolStripMenuItem.Click
        Backup()

    End Sub

    Private Sub استرجاعنسخةاحتياطيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles استرجاعنسخةاحتياطيةToolStripMenuItem.Click
        Try
            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "USE Master ALTER DATABASE INV_DB SET Single_User WITH Rollback Immediate Restore database INV_DB FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE INV_DB SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("تمت بنجاح ", "استعادة قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub المستخدمينToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles المستخدمينToolStripMenuItem.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()

    End Sub



    Private Sub جردالمخزونToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جردالمخزونToolStripMenuItem.Click
        frmCurrentStock.Reset()
        frmCurrentStock.ShowDialog()

    End Sub

    Private Sub شاشةالأصنافToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles شاشةالأصنافToolStripMenuItem.Click
        'frmProduct.lblUser.Text = lblUser.Text
        'frmProduct.lblUserType.Text = lblUserType.Text
        'frmProduct.Reset()
        'frmProduct.ShowDialog()

        frmProduct.lblUser.Text = lblUser.Text
        frmProduct.lblUserType.Text = lblUserType.Text
        frmProduct.Show(DockPanel1)
        frmProduct.Reset()
        frmProduct.MdiParent = Me
        frmProduct.Focus()

    End Sub

    Private Sub استيرادتصديرالأصناففيالأكسلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles استيرادتصديرالأصناففيالأكسلToolStripMenuItem.Click
        'frmExportImportExcel_ProductsRecord.Reset()
        'frmExportImportExcel_ProductsRecord.ShowDialog()

        frmExportImportExcel_ProductsRecord.Show(DockPanel1)
        frmExportImportExcel_ProductsRecord.Reset()
        frmExportImportExcel_ProductsRecord.MdiParent = Me
        frmExportImportExcel_ProductsRecord.Focus()

    End Sub

    Private Sub المخزونToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles المخزونToolStripMenuItem.Click
        frmStockBalance.Text = lblUser.Text
        frmStockBalance.Show(DockPanel1)
        frmStockBalance.MdiParent = Me
        frmStockBalance.Focus()
    End Sub

    Private Sub الرئيسيةToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub





    Private Sub قائمةفواتيرالبيعToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles قائمةفواتيرالبيعToolStripMenuItem.Click
        frmSalesInvoiceRecord.Close()
        frmSalesInvoiceRecord.lblSet.Text = "1"
        frmSalesInvoiceRecord.Show(DockPanel1)
        frmSalesInvoiceRecord.Reset()
        frmSalesInvoiceRecord.MdiParent = Me
        frmSalesInvoiceRecord.Focus()
    End Sub

    Private Sub ExelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExelToolStripMenuItemعملاء.Click
        frmExportImportExcel_ClientRecord.Show(DockPanel1)
        frmExportImportExcel_ClientRecord.Reset()
        frmExportImportExcel_ClientRecord.MdiParent = Me
        frmExportImportExcel_ClientRecord.Focus()
    End Sub

    Private Sub قائمةالعملاءToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles قائمةالعملاءToolStripMenuItem.Click
        frmCustomerRecord1.Show(DockPanel1)
        frmCustomerRecord1.Reset()
        frmCustomerRecord1.MdiParent = Me
    End Sub

    Private Sub اضافةعملاءToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اضافةعملاءToolStripMenuItem.Click
        frmCustomer.lblUser.Text = lblUser.Text
        ' frmCustomer.lblUserType.Text = lblUserType.Text
        ' frmCustomer.Show(DockPanel1)
        frmCustomer.Reset()
        'frmCustomer.MdiParent = Me
        frmCustomer.ShowDialog()
    End Sub

    Private Sub AaaaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'frmvendeur.Reset()
        ' frmVendeur.ShowDialog()
    End Sub

    Private Sub MmmmmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MmmmmToolStripMenuItem.Click
        frmVenduer.ShowDialog()
    End Sub

    Private Sub التفعيلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles التفعيلToolStripMenuItem.Click
        frmActivation.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Frmhome.Show(DockPanel1)
        'Frmhome.Reset()
        Frmhome.MdiParent = Me
        Frmhome.Focus()
    End Sub



    Private Sub كشفصنفToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        frmproductstatrecord.ShowDialog()
    End Sub

    Private Sub ToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem.Click

    End Sub

    Private Sub مبيعاتكلصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles مبيعاتكلصنفToolStripMenuItem.Click
        frmProductsLedger.Show()
    End Sub

    Private Sub AaaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AaaToolStripMenuItem.Click
        FormStat.Show()
    End Sub

    Private Sub frmMainMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            'شاشة المبيعات
            frmPOS.lblUser.Text = lblUser.Text
            frmPOS.lblUserType.Text = lblUserType.Text
            frmPOS.Show(DockPanel1)
            frmPOS.Reset()
            frmPOS.MdiParent = Me
            frmPOS.Focus()
        End If
        If e.KeyCode = Keys.F2 Then
            'شاشة المبيعات
            frmSalesReturn.lblUser.Text = lblUser.Text
            frmSalesReturn.lblUserType.Text = lblUserType.Text
            frmSalesReturn.Show(DockPanel1)
            frmSalesReturn.Reset()
            frmSalesReturn.MdiParent = Me
            frmSalesReturn.Focus()
        End If
        If e.KeyCode = Keys.F3 Then
            'شاشة المبيعات
            frmSalesReturn.lblUser.Text = lblUser.Text
            frmStockBalance.Show(DockPanel1)
            frmStockBalance.MdiParent = Me
            frmStockBalance.Focus()
        End If
    End Sub
End Class