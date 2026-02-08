<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frmhome
    ' Inherits System.Windows.Forms.Form
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmhome))
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.lblClock = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPurchaseOrder = New System.Windows.Forms.Button()
        Me.btnWorkPeriod = New System.Windows.Forms.Button()
        Me.btnPOSReport = New System.Windows.Forms.Button()
        Me.btnPOSRecord = New System.Windows.Forms.Button()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.btnStockTransfer_Issue = New System.Windows.Forms.Button()
        Me.btnStockAdjustment = New System.Windows.Forms.Button()
        Me.btnAccountingReports = New System.Windows.Forms.Button()
        Me.btnPayroll = New System.Windows.Forms.Button()
        Me.btnBankReconciliation = New System.Windows.Forms.Button()
        Me.BtnVoucher = New System.Windows.Forms.Button()
        Me.btnBarcodeLabelPrinting = New System.Windows.Forms.Button()
        Me.btnPurchase = New System.Windows.Forms.Button()
        Me.btnSalesReturn = New System.Windows.Forms.Button()
        Me.btnWallet = New System.Windows.Forms.Button()
        Me.btnPurchaseReturn = New System.Windows.Forms.Button()
        Me.btnCreditCustomer = New System.Windows.Forms.Button()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.btnProductMaster = New System.Windows.Forms.Button()
        Me.btnSalesmanMaster = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer4
        '
        Me.Timer4.Enabled = True
        '
        'lblClock
        '
        Me.lblClock.AutoSize = True
        Me.lblClock.BackColor = System.Drawing.Color.Transparent
        Me.lblClock.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.ForeColor = System.Drawing.Color.Black
        Me.lblClock.Location = New System.Drawing.Point(29, 380)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(138, 45)
        Me.lblClock.TabIndex = 63
        Me.lblClock.Text = "Label1"
        Me.lblClock.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 416)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 45)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'btnPurchaseOrder
        '
        Me.btnPurchaseOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPurchaseOrder.AutoSize = True
        Me.btnPurchaseOrder.BackColor = System.Drawing.Color.Indigo
        Me.btnPurchaseOrder.BackgroundImage = CType(resources.GetObject("btnPurchaseOrder.BackgroundImage"), System.Drawing.Image)
        Me.btnPurchaseOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPurchaseOrder.FlatAppearance.BorderSize = 0
        Me.btnPurchaseOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchaseOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnPurchaseOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPurchaseOrder.Image = CType(resources.GetObject("btnPurchaseOrder.Image"), System.Drawing.Image)
        Me.btnPurchaseOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPurchaseOrder.Location = New System.Drawing.Point(352, 351)
        Me.btnPurchaseOrder.Name = "btnPurchaseOrder"
        Me.btnPurchaseOrder.Size = New System.Drawing.Size(167, 82)
        Me.btnPurchaseOrder.TabIndex = 50
        Me.btnPurchaseOrder.Text = "تقرير المشتريات"
        Me.btnPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPurchaseOrder.UseVisualStyleBackColor = False
        '
        'btnWorkPeriod
        '
        Me.btnWorkPeriod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWorkPeriod.AutoSize = True
        Me.btnWorkPeriod.BackColor = System.Drawing.Color.Orange
        Me.btnWorkPeriod.BackgroundImage = CType(resources.GetObject("btnWorkPeriod.BackgroundImage"), System.Drawing.Image)
        Me.btnWorkPeriod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWorkPeriod.FlatAppearance.BorderSize = 0
        Me.btnWorkPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnWorkPeriod.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnWorkPeriod.Image = CType(resources.GetObject("btnWorkPeriod.Image"), System.Drawing.Image)
        Me.btnWorkPeriod.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWorkPeriod.Location = New System.Drawing.Point(179, 351)
        Me.btnWorkPeriod.Name = "btnWorkPeriod"
        Me.btnWorkPeriod.Size = New System.Drawing.Size(167, 82)
        Me.btnWorkPeriod.TabIndex = 38
        Me.btnWorkPeriod.Text = "الارباح والخسائر"
        Me.btnWorkPeriod.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWorkPeriod.UseVisualStyleBackColor = False
        '
        'btnPOSReport
        '
        Me.btnPOSReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOSReport.AutoSize = True
        Me.btnPOSReport.BackColor = System.Drawing.Color.SandyBrown
        Me.btnPOSReport.BackgroundImage = CType(resources.GetObject("btnPOSReport.BackgroundImage"), System.Drawing.Image)
        Me.btnPOSReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPOSReport.FlatAppearance.BorderSize = 0
        Me.btnPOSReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOSReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnPOSReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPOSReport.Image = CType(resources.GetObject("btnPOSReport.Image"), System.Drawing.Image)
        Me.btnPOSReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPOSReport.Location = New System.Drawing.Point(525, 351)
        Me.btnPOSReport.Name = "btnPOSReport"
        Me.btnPOSReport.Size = New System.Drawing.Size(167, 82)
        Me.btnPOSReport.TabIndex = 33
        Me.btnPOSReport.Text = "تقرير مبيعات"
        Me.btnPOSReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOSReport.UseVisualStyleBackColor = False
        '
        'btnPOSRecord
        '
        Me.btnPOSRecord.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOSRecord.BackColor = System.Drawing.Color.Crimson
        Me.btnPOSRecord.BackgroundImage = CType(resources.GetObject("btnPOSRecord.BackgroundImage"), System.Drawing.Image)
        Me.btnPOSRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPOSRecord.FlatAppearance.BorderSize = 0
        Me.btnPOSRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOSRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnPOSRecord.ForeColor = System.Drawing.Color.White
        Me.btnPOSRecord.Image = CType(resources.GetObject("btnPOSRecord.Image"), System.Drawing.Image)
        Me.btnPOSRecord.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPOSRecord.Location = New System.Drawing.Point(3, 351)
        Me.btnPOSRecord.Name = "btnPOSRecord"
        Me.btnPOSRecord.Size = New System.Drawing.Size(170, 82)
        Me.btnPOSRecord.TabIndex = 57
        Me.btnPOSRecord.Text = "ارصدة الجميع"
        Me.btnPOSRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOSRecord.UseVisualStyleBackColor = False
        '
        'btnPayment
        '
        Me.btnPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPayment.AutoSize = True
        Me.btnPayment.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.btnPayment.BackgroundImage = CType(resources.GetObject("btnPayment.BackgroundImage"), System.Drawing.Image)
        Me.btnPayment.FlatAppearance.BorderSize = 0
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPayment.Image = CType(resources.GetObject("btnPayment.Image"), System.Drawing.Image)
        Me.btnPayment.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPayment.Location = New System.Drawing.Point(352, 264)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(167, 81)
        Me.btnPayment.TabIndex = 42
        Me.btnPayment.Text = "عمولة المناديب"
        Me.btnPayment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'btnStockTransfer_Issue
        '
        Me.btnStockTransfer_Issue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStockTransfer_Issue.AutoSize = True
        Me.btnStockTransfer_Issue.BackColor = System.Drawing.Color.Tomato
        Me.btnStockTransfer_Issue.BackgroundImage = CType(resources.GetObject("btnStockTransfer_Issue.BackgroundImage"), System.Drawing.Image)
        Me.btnStockTransfer_Issue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStockTransfer_Issue.FlatAppearance.BorderSize = 0
        Me.btnStockTransfer_Issue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStockTransfer_Issue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnStockTransfer_Issue.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnStockTransfer_Issue.Image = CType(resources.GetObject("btnStockTransfer_Issue.Image"), System.Drawing.Image)
        Me.btnStockTransfer_Issue.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStockTransfer_Issue.Location = New System.Drawing.Point(179, 264)
        Me.btnStockTransfer_Issue.Name = "btnStockTransfer_Issue"
        Me.btnStockTransfer_Issue.Size = New System.Drawing.Size(167, 81)
        Me.btnStockTransfer_Issue.TabIndex = 55
        Me.btnStockTransfer_Issue.Text = "جرد المخزون"
        Me.btnStockTransfer_Issue.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStockTransfer_Issue.UseVisualStyleBackColor = False
        '
        'btnStockAdjustment
        '
        Me.btnStockAdjustment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStockAdjustment.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnStockAdjustment.BackgroundImage = CType(resources.GetObject("btnStockAdjustment.BackgroundImage"), System.Drawing.Image)
        Me.btnStockAdjustment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStockAdjustment.FlatAppearance.BorderSize = 0
        Me.btnStockAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStockAdjustment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnStockAdjustment.ForeColor = System.Drawing.Color.White
        Me.btnStockAdjustment.Image = CType(resources.GetObject("btnStockAdjustment.Image"), System.Drawing.Image)
        Me.btnStockAdjustment.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStockAdjustment.Location = New System.Drawing.Point(525, 264)
        Me.btnStockAdjustment.Name = "btnStockAdjustment"
        Me.btnStockAdjustment.Size = New System.Drawing.Size(167, 81)
        Me.btnStockAdjustment.TabIndex = 67
        Me.btnStockAdjustment.Text = "حالة المخزون"
        Me.btnStockAdjustment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStockAdjustment.UseVisualStyleBackColor = False
        '
        'btnAccountingReports
        '
        Me.btnAccountingReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAccountingReports.AutoSize = True
        Me.btnAccountingReports.BackColor = System.Drawing.Color.Crimson
        Me.btnAccountingReports.BackgroundImage = CType(resources.GetObject("btnAccountingReports.BackgroundImage"), System.Drawing.Image)
        Me.btnAccountingReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAccountingReports.FlatAppearance.BorderSize = 0
        Me.btnAccountingReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccountingReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnAccountingReports.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAccountingReports.Image = CType(resources.GetObject("btnAccountingReports.Image"), System.Drawing.Image)
        Me.btnAccountingReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAccountingReports.Location = New System.Drawing.Point(3, 264)
        Me.btnAccountingReports.Name = "btnAccountingReports"
        Me.btnAccountingReports.Size = New System.Drawing.Size(170, 81)
        Me.btnAccountingReports.TabIndex = 43
        Me.btnAccountingReports.Text = "دفتر الأستاذ العام"
        Me.btnAccountingReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAccountingReports.UseVisualStyleBackColor = False
        '
        'btnPayroll
        '
        Me.btnPayroll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPayroll.AutoSize = True
        Me.btnPayroll.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btnPayroll.BackgroundImage = CType(resources.GetObject("btnPayroll.BackgroundImage"), System.Drawing.Image)
        Me.btnPayroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPayroll.FlatAppearance.BorderSize = 0
        Me.btnPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayroll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnPayroll.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPayroll.Image = CType(resources.GetObject("btnPayroll.Image"), System.Drawing.Image)
        Me.btnPayroll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPayroll.Location = New System.Drawing.Point(352, 177)
        Me.btnPayroll.Name = "btnPayroll"
        Me.btnPayroll.Size = New System.Drawing.Size(167, 81)
        Me.btnPayroll.TabIndex = 53
        Me.btnPayroll.Text = "دفعات العملاء"
        Me.btnPayroll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPayroll.UseVisualStyleBackColor = False
        '
        'btnBankReconciliation
        '
        Me.btnBankReconciliation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBankReconciliation.AutoSize = True
        Me.btnBankReconciliation.BackColor = System.Drawing.Color.Teal
        Me.btnBankReconciliation.BackgroundImage = CType(resources.GetObject("btnBankReconciliation.BackgroundImage"), System.Drawing.Image)
        Me.btnBankReconciliation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBankReconciliation.FlatAppearance.BorderSize = 0
        Me.btnBankReconciliation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBankReconciliation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnBankReconciliation.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBankReconciliation.Image = CType(resources.GetObject("btnBankReconciliation.Image"), System.Drawing.Image)
        Me.btnBankReconciliation.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBankReconciliation.Location = New System.Drawing.Point(179, 177)
        Me.btnBankReconciliation.Name = "btnBankReconciliation"
        Me.btnBankReconciliation.Size = New System.Drawing.Size(167, 81)
        Me.btnBankReconciliation.TabIndex = 65
        Me.btnBankReconciliation.Text = "دفعات الموردين"
        Me.btnBankReconciliation.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBankReconciliation.UseVisualStyleBackColor = False
        '
        'BtnVoucher
        '
        Me.BtnVoucher.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnVoucher.AutoSize = True
        Me.BtnVoucher.BackColor = System.Drawing.Color.DarkTurquoise
        Me.BtnVoucher.BackgroundImage = CType(resources.GetObject("BtnVoucher.BackgroundImage"), System.Drawing.Image)
        Me.BtnVoucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnVoucher.FlatAppearance.BorderSize = 0
        Me.BtnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtnVoucher.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnVoucher.Image = CType(resources.GetObject("BtnVoucher.Image"), System.Drawing.Image)
        Me.BtnVoucher.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnVoucher.Location = New System.Drawing.Point(525, 177)
        Me.BtnVoucher.Name = "BtnVoucher"
        Me.BtnVoucher.Size = New System.Drawing.Size(167, 81)
        Me.BtnVoucher.TabIndex = 46
        Me.BtnVoucher.Text = "سند صرف"
        Me.BtnVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnVoucher.UseVisualStyleBackColor = False
        '
        'btnBarcodeLabelPrinting
        '
        Me.btnBarcodeLabelPrinting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBarcodeLabelPrinting.AutoSize = True
        Me.btnBarcodeLabelPrinting.BackColor = System.Drawing.Color.Gold
        Me.btnBarcodeLabelPrinting.BackgroundImage = CType(resources.GetObject("btnBarcodeLabelPrinting.BackgroundImage"), System.Drawing.Image)
        Me.btnBarcodeLabelPrinting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBarcodeLabelPrinting.FlatAppearance.BorderSize = 0
        Me.btnBarcodeLabelPrinting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarcodeLabelPrinting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnBarcodeLabelPrinting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBarcodeLabelPrinting.Image = CType(resources.GetObject("btnBarcodeLabelPrinting.Image"), System.Drawing.Image)
        Me.btnBarcodeLabelPrinting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBarcodeLabelPrinting.Location = New System.Drawing.Point(3, 177)
        Me.btnBarcodeLabelPrinting.Name = "btnBarcodeLabelPrinting"
        Me.btnBarcodeLabelPrinting.Size = New System.Drawing.Size(170, 81)
        Me.btnBarcodeLabelPrinting.TabIndex = 59
        Me.btnBarcodeLabelPrinting.Text = "طباعة الباركود"
        Me.btnBarcodeLabelPrinting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBarcodeLabelPrinting.UseVisualStyleBackColor = False
        '
        'btnPurchase
        '
        Me.btnPurchase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPurchase.AutoSize = True
        Me.btnPurchase.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btnPurchase.BackgroundImage = CType(resources.GetObject("btnPurchase.BackgroundImage"), System.Drawing.Image)
        Me.btnPurchase.FlatAppearance.BorderSize = 0
        Me.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnPurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPurchase.Image = CType(resources.GetObject("btnPurchase.Image"), System.Drawing.Image)
        Me.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPurchase.Location = New System.Drawing.Point(352, 90)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(167, 81)
        Me.btnPurchase.TabIndex = 41
        Me.btnPurchase.Text = "فاتورة مشتريات"
        Me.btnPurchase.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPurchase.UseVisualStyleBackColor = False
        '
        'btnSalesReturn
        '
        Me.btnSalesReturn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalesReturn.BackColor = System.Drawing.Color.SaddleBrown
        Me.btnSalesReturn.BackgroundImage = CType(resources.GetObject("btnSalesReturn.BackgroundImage"), System.Drawing.Image)
        Me.btnSalesReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalesReturn.FlatAppearance.BorderSize = 0
        Me.btnSalesReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnSalesReturn.ForeColor = System.Drawing.Color.White
        Me.btnSalesReturn.Image = CType(resources.GetObject("btnSalesReturn.Image"), System.Drawing.Image)
        Me.btnSalesReturn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalesReturn.Location = New System.Drawing.Point(179, 90)
        Me.btnSalesReturn.Name = "btnSalesReturn"
        Me.btnSalesReturn.Size = New System.Drawing.Size(167, 81)
        Me.btnSalesReturn.TabIndex = 61
        Me.btnSalesReturn.Text = "مرتجع المبيعات"
        Me.btnSalesReturn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalesReturn.UseVisualStyleBackColor = False
        '
        'btnWallet
        '
        Me.btnWallet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWallet.AutoSize = True
        Me.btnWallet.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnWallet.BackgroundImage = CType(resources.GetObject("btnWallet.BackgroundImage"), System.Drawing.Image)
        Me.btnWallet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWallet.FlatAppearance.BorderSize = 0
        Me.btnWallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnWallet.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnWallet.Image = Global.Sales_and_Inventory_System.My.Resources.Resources.money_icon
        Me.btnWallet.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWallet.Location = New System.Drawing.Point(525, 90)
        Me.btnWallet.Name = "btnWallet"
        Me.btnWallet.Size = New System.Drawing.Size(167, 81)
        Me.btnWallet.TabIndex = 66
        Me.btnWallet.Text = "فاتورة مبيعات"
        Me.btnWallet.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWallet.UseVisualStyleBackColor = False
        '
        'btnPurchaseReturn
        '
        Me.btnPurchaseReturn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPurchaseReturn.AutoSize = True
        Me.btnPurchaseReturn.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnPurchaseReturn.BackgroundImage = CType(resources.GetObject("btnPurchaseReturn.BackgroundImage"), System.Drawing.Image)
        Me.btnPurchaseReturn.FlatAppearance.BorderSize = 0
        Me.btnPurchaseReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchaseReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnPurchaseReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPurchaseReturn.Image = CType(resources.GetObject("btnPurchaseReturn.Image"), System.Drawing.Image)
        Me.btnPurchaseReturn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPurchaseReturn.Location = New System.Drawing.Point(3, 90)
        Me.btnPurchaseReturn.Name = "btnPurchaseReturn"
        Me.btnPurchaseReturn.Size = New System.Drawing.Size(170, 81)
        Me.btnPurchaseReturn.TabIndex = 36
        Me.btnPurchaseReturn.Text = "مترجع المشتريات"
        Me.btnPurchaseReturn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPurchaseReturn.UseVisualStyleBackColor = False
        '
        'btnCreditCustomer
        '
        Me.btnCreditCustomer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreditCustomer.AutoSize = True
        Me.btnCreditCustomer.BackColor = System.Drawing.Color.DeepPink
        Me.btnCreditCustomer.BackgroundImage = CType(resources.GetObject("btnCreditCustomer.BackgroundImage"), System.Drawing.Image)
        Me.btnCreditCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCreditCustomer.FlatAppearance.BorderSize = 0
        Me.btnCreditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreditCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnCreditCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCreditCustomer.Image = CType(resources.GetObject("btnCreditCustomer.Image"), System.Drawing.Image)
        Me.btnCreditCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCreditCustomer.Location = New System.Drawing.Point(352, 3)
        Me.btnCreditCustomer.Name = "btnCreditCustomer"
        Me.btnCreditCustomer.Size = New System.Drawing.Size(167, 81)
        Me.btnCreditCustomer.TabIndex = 60
        Me.btnCreditCustomer.Text = "العملاء"
        Me.btnCreditCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCreditCustomer.UseVisualStyleBackColor = False
        '
        'btnSupplier
        '
        Me.btnSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSupplier.AutoSize = True
        Me.btnSupplier.BackColor = System.Drawing.Color.DarkViolet
        Me.btnSupplier.BackgroundImage = CType(resources.GetObject("btnSupplier.BackgroundImage"), System.Drawing.Image)
        Me.btnSupplier.FlatAppearance.BorderSize = 0
        Me.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnSupplier.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSupplier.Image = CType(resources.GetObject("btnSupplier.Image"), System.Drawing.Image)
        Me.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSupplier.Location = New System.Drawing.Point(179, 3)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(167, 81)
        Me.btnSupplier.TabIndex = 40
        Me.btnSupplier.Text = "الموردين"
        Me.btnSupplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSupplier.UseVisualStyleBackColor = False
        '
        'btnProductMaster
        '
        Me.btnProductMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProductMaster.AutoSize = True
        Me.btnProductMaster.BackColor = System.Drawing.Color.Crimson
        Me.btnProductMaster.BackgroundImage = CType(resources.GetObject("btnProductMaster.BackgroundImage"), System.Drawing.Image)
        Me.btnProductMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProductMaster.FlatAppearance.BorderSize = 0
        Me.btnProductMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnProductMaster.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnProductMaster.Image = CType(resources.GetObject("btnProductMaster.Image"), System.Drawing.Image)
        Me.btnProductMaster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProductMaster.Location = New System.Drawing.Point(525, 3)
        Me.btnProductMaster.Name = "btnProductMaster"
        Me.btnProductMaster.Size = New System.Drawing.Size(167, 81)
        Me.btnProductMaster.TabIndex = 34
        Me.btnProductMaster.Text = "الأصناف"
        Me.btnProductMaster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProductMaster.UseVisualStyleBackColor = False
        '
        'btnSalesmanMaster
        '
        Me.btnSalesmanMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalesmanMaster.AutoSize = True
        Me.btnSalesmanMaster.BackColor = System.Drawing.Color.Goldenrod
        Me.btnSalesmanMaster.BackgroundImage = CType(resources.GetObject("btnSalesmanMaster.BackgroundImage"), System.Drawing.Image)
        Me.btnSalesmanMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalesmanMaster.FlatAppearance.BorderSize = 0
        Me.btnSalesmanMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesmanMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnSalesmanMaster.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalesmanMaster.Image = CType(resources.GetObject("btnSalesmanMaster.Image"), System.Drawing.Image)
        Me.btnSalesmanMaster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalesmanMaster.Location = New System.Drawing.Point(3, 3)
        Me.btnSalesmanMaster.Name = "btnSalesmanMaster"
        Me.btnSalesmanMaster.Size = New System.Drawing.Size(170, 81)
        Me.btnSalesmanMaster.TabIndex = 48
        Me.btnSalesmanMaster.Text = "مناديب المبيعات"
        Me.btnSalesmanMaster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalesmanMaster.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnSalesmanMaster, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnProductMaster, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSupplier, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCreditCustomer, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPurchaseReturn, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnWallet, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSalesReturn, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPurchase, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBarcodeLabelPrinting, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnVoucher, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBankReconciliation, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPayroll, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAccountingReports, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.btnStockAdjustment, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.btnStockTransfer_Issue, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPayment, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPOSRecord, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPOSReport, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btnWorkPeriod, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPurchaseOrder, 1, 4)
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(471, 104)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(695, 436)
        Me.TableLayoutPanel2.TabIndex = 62
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoPictureBox.BackgroundImage = CType(resources.GetObject("LogoPictureBox.BackgroundImage"), System.Drawing.Image)
        Me.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LogoPictureBox.Location = New System.Drawing.Point(74, 6)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(393, 617)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 65
        Me.LogoPictureBox.TabStop = False
        '
        'Frmhome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1178, 624)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblClock)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frmhome"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "الرئيسية"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer4 As Timer
    Friend WithEvents lblClock As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPurchaseOrder As Button
    Friend WithEvents btnWorkPeriod As Button
    Friend WithEvents btnPOSReport As Button
    Friend WithEvents btnPOSRecord As Button
    Friend WithEvents btnPayment As Button
    Friend WithEvents btnStockTransfer_Issue As Button
    Friend WithEvents btnStockAdjustment As Button
    Friend WithEvents btnAccountingReports As Button
    Friend WithEvents btnPayroll As Button
    Friend WithEvents btnBankReconciliation As Button
    Friend WithEvents BtnVoucher As Button
    Friend WithEvents btnBarcodeLabelPrinting As Button
    Friend WithEvents btnPurchase As Button
    Friend WithEvents btnSalesReturn As Button
    Friend WithEvents btnWallet As Button
    Friend WithEvents btnPurchaseReturn As Button
    Friend WithEvents btnCreditCustomer As Button
    Friend WithEvents btnSupplier As Button
    Friend WithEvents btnProductMaster As Button
    Friend WithEvents btnSalesmanMaster As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LogoPictureBox As PictureBox
End Class
