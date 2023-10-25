namespace WMSOffice.Window
{
    partial class QualityRequestWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualityRequestWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.pbSplashControl = new System.Windows.Forms.PictureBox();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssExportToExcel = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnCancelLoading = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintDoc = new System.Windows.Forms.ToolStripButton();
            this.btnReprintDoc = new System.Windows.Forms.ToolStripButton();
            this.btnPrintSelectedDocs = new System.Windows.Forms.ToolStripButton();
            this.btnSertPrintSettings = new System.Windows.Forms.ToolStripButton();
            this.ddbPrintAcceptanceAct = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnPrintActForOptima = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintActForGls = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewActForOptima = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewActForGls = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelayReasons = new System.Windows.Forms.ToolStripButton();
            this.btnGlsRemarks = new System.Windows.Forms.ToolStripButton();
            this.btnRequestParameters = new System.Windows.Forms.ToolStripButton();
            this.btnSendToInspection = new System.Windows.Forms.ToolStripButton();
            this.btnCompleteDocPreparing = new System.Windows.Forms.ToolStripButton();
            this.sbDocComment = new System.Windows.Forms.ToolStripButton();
            this.sbMoveToNewDoc = new System.Windows.Forms.ToolStripButton();
            this.ddbMoveItemsToSelectedLocation = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnMoveItemsToQuarantine = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMoveItemsFromQuarantine = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowAttachments = new System.Windows.Forms.ToolStripButton();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.pbDocsWebSyncState = new System.Windows.Forms.PictureBox();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.cbExpired = new System.Windows.Forms.CheckBox();
            this.cmbDocCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbIncludeArchived = new System.Windows.Forms.CheckBox();
            this.tbxBatchID = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.tbxVendorLot = new System.Windows.Forms.TextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.tbxItemID = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.tbxDocID = new System.Windows.Forms.TextBox();
            this.lblDocID = new System.Windows.Forms.Label();
            this.edgDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.climgIsRepeatedLot = new System.Windows.Forms.DataGridViewImageColumn();
            this.clchbIsRepeatedLot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clIsProblemIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.clIsProblemItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturerPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturerCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exp_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLotQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clADocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAConclDocnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAOutConclDocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDirectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDirectionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStatusDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRegNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRegEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLastUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clConclType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manuf_Date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufSectorDsc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGMPSert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSellPermissionStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSellPermissionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCertRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.bsDocDetails = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.toolStripLine = new System.Windows.Forms.ToolStrip();
            this.cmbLotFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tssAfterLotFilter = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetMode = new System.Windows.Forms.ToolStripButton();
            this.tssAfterSetMode = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetConclusion = new System.Windows.Forms.ToolStripButton();
            this.btnPreviewSellPermission = new System.Windows.Forms.ToolStripButton();
            this.btnPrintSellPermission = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.btnEditArchiveConclusion = new System.Windows.Forms.ToolStripButton();
            this.btnCloseForReason = new System.Windows.Forms.ToolStripButton();
            this.tssAfterSetPrescription = new System.Windows.Forms.ToolStripSeparator();
            this.btnVendorSellPermission = new System.Windows.Forms.ToolStripButton();
            this.btnSetAnaliz = new System.Windows.Forms.ToolStripButton();
            this.btnSetAnalizSent = new System.Windows.Forms.ToolStripButton();
            this.btnSetCertRemark = new System.Windows.Forms.ToolStripButton();
            this.btnCertRemarkEliminated = new System.Windows.Forms.ToolStripButton();
            this.btnEditAnalysisData = new System.Windows.Forms.ToolStripButton();
            this.btnGlsRemarksForLine = new System.Windows.Forms.ToolStripButton();
            this.tssAfterWatchProblems = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditRegistrationLifetime = new System.Windows.Forms.ToolStripButton();
            this.btnChoiceExpert = new System.Windows.Forms.ToolStripButton();
            this.btnEditManufacturer = new System.Windows.Forms.ToolStripButton();
            this.btnEditManufacturerCountry = new System.Windows.Forms.ToolStripButton();
            this.btnEditExpDate = new System.Windows.Forms.ToolStripButton();
            this.btnEditGMP = new System.Windows.Forms.ToolStripButton();
            this.bgwRequestsLoader = new System.ComponentModel.BackgroundWorker();
            this.taDocs = new WMSOffice.Data.QualityTableAdapters.DocsTableAdapter();
            this.taDocDetails = new WMSOffice.Data.QualityTableAdapters.DocDetailsTableAdapter();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).BeginInit();
            this.toolStripDoc.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocsWebSyncState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.cmsDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.toolStripLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 40);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.pbSplashControl);
            this.spcMain.Panel1.Controls.Add(this.toolStripDoc);
            this.spcMain.Panel1.Controls.Add(this.pnlFilters);
            this.spcMain.Panel1.Controls.Add(this.edgDocs);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgvLines);
            this.spcMain.Panel2.Controls.Add(this.toolStripLine);
            this.spcMain.Size = new System.Drawing.Size(1538, 629);
            this.spcMain.SplitterDistance = 330;
            this.spcMain.TabIndex = 70;
            // 
            // pbSplashControl
            // 
            this.pbSplashControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSplashControl.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbSplashControl.InitialImage = null;
            this.pbSplashControl.Location = new System.Drawing.Point(716, 163);
            this.pbSplashControl.Name = "pbSplashControl";
            this.pbSplashControl.Size = new System.Drawing.Size(104, 104);
            this.pbSplashControl.TabIndex = 72;
            this.pbSplashControl.TabStop = false;
            this.pbSplashControl.Visible = false;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssExportToExcel,
            this.btnExportToExcel,
            this.btnCancelLoading,
            this.tssAfterRefresh,
            this.btnPrintDoc,
            this.btnReprintDoc,
            this.btnPrintSelectedDocs,
            this.btnSertPrintSettings,
            this.ddbPrintAcceptanceAct,
            this.btnDelayReasons,
            this.btnGlsRemarks,
            this.btnRequestParameters,
            this.btnSendToInspection,
            this.btnCompleteDocPreparing,
            this.sbDocComment,
            this.sbMoveToNewDoc,
            this.ddbMoveItemsToSelectedLocation,
            this.btnShowAttachments});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1538, 55);
            this.toolStripDoc.TabIndex = 10;
            this.toolStripDoc.Text = "Панель інструментів документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Оновити список нероздрукованих накладних";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tssExportToExcel
            // 
            this.tssExportToExcel.Name = "tssExportToExcel";
            this.tssExportToExcel.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(52, 52);
            this.btnExportToExcel.Text = "Експорт заяв у Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnCancelLoading
            // 
            this.btnCancelLoading.Image = global::WMSOffice.Properties.Resources.cancel;
            this.btnCancelLoading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelLoading.Name = "btnCancelLoading";
            this.btnCancelLoading.Size = new System.Drawing.Size(132, 52);
            this.btnCancelLoading.Text = "Відмінити\nзавантаження";
            this.btnCancelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelLoading.ToolTipText = "Відмінити поточне завантаження";
            this.btnCancelLoading.Visible = false;
            this.btnCancelLoading.Click += new System.EventHandler(this.btnCancelLoading_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintDoc
            // 
            this.btnPrintDoc.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintDoc.Name = "btnPrintDoc";
            this.btnPrintDoc.Size = new System.Drawing.Size(127, 52);
            this.btnPrintDoc.Text = "Надрукувати\rпакет\nдокументів";
            this.btnPrintDoc.ToolTipText = "Надрукувати \rвибрані \rнакладні";
            this.btnPrintDoc.Visible = false;
            this.btnPrintDoc.Click += new System.EventHandler(this.btnPrintDoc_Click);
            // 
            // btnReprintDoc
            // 
            this.btnReprintDoc.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnReprintDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReprintDoc.Name = "btnReprintDoc";
            this.btnReprintDoc.Size = new System.Drawing.Size(149, 52);
            this.btnReprintDoc.Text = "Надрукувати\rпакет документів\r(повторно)";
            this.btnReprintDoc.Visible = false;
            this.btnReprintDoc.Click += new System.EventHandler(this.btnReprintDoc_Click);
            // 
            // btnPrintSelectedDocs
            // 
            this.btnPrintSelectedDocs.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintSelectedDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintSelectedDocs.Name = "btnPrintSelectedDocs";
            this.btnPrintSelectedDocs.Size = new System.Drawing.Size(116, 52);
            this.btnPrintSelectedDocs.Text = "Вибірковий\nдрук\nдокументів";
            this.btnPrintSelectedDocs.ToolTipText = "Вибір коду/серій товарів для друку";
            this.btnPrintSelectedDocs.Click += new System.EventHandler(this.btnPrintSelectedDocs_Click);
            // 
            // btnSertPrintSettings
            // 
            this.btnSertPrintSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSertPrintSettings.Image = global::WMSOffice.Properties.Resources.settings;
            this.btnSertPrintSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSertPrintSettings.Name = "btnSertPrintSettings";
            this.btnSertPrintSettings.Size = new System.Drawing.Size(134, 52);
            this.btnSertPrintSettings.Text = "Налаштування\nдруку\nсертификатів";
            this.btnSertPrintSettings.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnSertPrintSettings.ToolTipText = "Налаштування друку сертификатів";
            this.btnSertPrintSettings.Click += new System.EventHandler(this.btnSertPrintSettings_Click);
            // 
            // ddbPrintAcceptanceAct
            // 
            this.ddbPrintAcceptanceAct.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintActForOptima,
            this.btnPrintActForGls,
            this.btnViewActForOptima,
            this.btnViewActForGls});
            this.ddbPrintAcceptanceAct.Image = global::WMSOffice.Properties.Resources.document_print;
            this.ddbPrintAcceptanceAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbPrintAcceptanceAct.Name = "ddbPrintAcceptanceAct";
            this.ddbPrintAcceptanceAct.Size = new System.Drawing.Size(171, 52);
            this.ddbPrintAcceptanceAct.Text = "Акт\nприймання-передачі";
            // 
            // btnPrintActForOptima
            // 
            this.btnPrintActForOptima.Name = "btnPrintActForOptima";
            this.btnPrintActForOptima.Size = new System.Drawing.Size(227, 22);
            this.btnPrintActForOptima.Text = "Друк для Оптіма-Фарм";
            this.btnPrintActForOptima.Click += new System.EventHandler(this.btnPrintAct_Click);
            // 
            // btnPrintActForGls
            // 
            this.btnPrintActForGls.Name = "btnPrintActForGls";
            this.btnPrintActForGls.Size = new System.Drawing.Size(227, 22);
            this.btnPrintActForGls.Text = "Друк для Держлікслужби";
            this.btnPrintActForGls.Click += new System.EventHandler(this.btnPrintAct_Click);
            // 
            // btnViewActForOptima
            // 
            this.btnViewActForOptima.Name = "btnViewActForOptima";
            this.btnViewActForOptima.Size = new System.Drawing.Size(227, 22);
            this.btnViewActForOptima.Text = "Перегляд для Оптіма-Фарм";
            this.btnViewActForOptima.Click += new System.EventHandler(this.btnViewAct_Click);
            // 
            // btnViewActForGls
            // 
            this.btnViewActForGls.Name = "btnViewActForGls";
            this.btnViewActForGls.Size = new System.Drawing.Size(227, 22);
            this.btnViewActForGls.Text = "Перегляд для Держлікслужби";
            this.btnViewActForGls.Click += new System.EventHandler(this.btnViewAct_Click);
            // 
            // btnDelayReasons
            // 
            this.btnDelayReasons.Image = global::WMSOffice.Properties.Resources.Achtung;
            this.btnDelayReasons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelayReasons.Name = "btnDelayReasons";
            this.btnDelayReasons.Size = new System.Drawing.Size(106, 52);
            this.btnDelayReasons.Text = "Причини\nзатримки";
            this.btnDelayReasons.ToolTipText = "Відкрити вікно для перегляду і доповнення причин затримки";
            this.btnDelayReasons.Click += new System.EventHandler(this.btnDelayReasons_Click);
            // 
            // btnGlsRemarks
            // 
            this.btnGlsRemarks.Image = ((System.Drawing.Image)(resources.GetObject("btnGlsRemarks.Image")));
            this.btnGlsRemarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGlsRemarks.Name = "btnGlsRemarks";
            this.btnGlsRemarks.Size = new System.Drawing.Size(121, 52);
            this.btnGlsRemarks.Text = "Зауваження\nвід ДЛС";
            this.btnGlsRemarks.Click += new System.EventHandler(this.SetGlsRemarks_Click);
            // 
            // btnRequestParameters
            // 
            this.btnRequestParameters.Image = global::WMSOffice.Properties.Resources.document_certificate;
            this.btnRequestParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRequestParameters.Name = "btnRequestParameters";
            this.btnRequestParameters.Size = new System.Drawing.Size(100, 52);
            this.btnRequestParameters.Text = "Вибір\nінспекції";
            this.btnRequestParameters.Click += new System.EventHandler(this.btnRequestParameters_Click);
            // 
            // btnSendToInspection
            // 
            this.btnSendToInspection.Image = global::WMSOffice.Properties.Resources.mail_ok;
            this.btnSendToInspection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendToInspection.Name = "btnSendToInspection";
            this.btnSendToInspection.Size = new System.Drawing.Size(125, 52);
            this.btnSendToInspection.Text = "Передати до\nінспекції";
            this.btnSendToInspection.Click += new System.EventHandler(this.btnSendToInspection_Click);
            // 
            // btnCompleteDocPreparing
            // 
            this.btnCompleteDocPreparing.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnCompleteDocPreparing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompleteDocPreparing.Name = "btnCompleteDocPreparing";
            this.btnCompleteDocPreparing.Size = new System.Drawing.Size(115, 52);
            this.btnCompleteDocPreparing.Text = "Завершити\nпідготовку\nзаяви";
            this.btnCompleteDocPreparing.Click += new System.EventHandler(this.btnCompleteDocPreparing_Click);
            // 
            // sbDocComment
            // 
            this.sbDocComment.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.sbDocComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbDocComment.Name = "sbDocComment";
            this.sbDocComment.Size = new System.Drawing.Size(108, 52);
            this.sbDocComment.Text = "Коментар\r\nдо заяви";
            this.sbDocComment.Click += new System.EventHandler(this.sbDocComment_Click);
            // 
            // sbMoveToNewDoc
            // 
            this.sbMoveToNewDoc.Image = global::WMSOffice.Properties.Resources.tables_edit;
            this.sbMoveToNewDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbMoveToNewDoc.Name = "sbMoveToNewDoc";
            this.sbMoveToNewDoc.Size = new System.Drawing.Size(137, 52);
            this.sbMoveToNewDoc.Text = "Перемістити до\nнової заяви";
            this.sbMoveToNewDoc.Click += new System.EventHandler(this.sbMoveToNewDoc_Click);
            // 
            // ddbMoveItemsToSelectedLocation
            // 
            this.ddbMoveItemsToSelectedLocation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMoveItemsToQuarantine,
            this.btnMoveItemsFromQuarantine});
            this.ddbMoveItemsToSelectedLocation.Image = global::WMSOffice.Properties.Resources.box3;
            this.ddbMoveItemsToSelectedLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbMoveItemsToSelectedLocation.Name = "ddbMoveItemsToSelectedLocation";
            this.ddbMoveItemsToSelectedLocation.Size = new System.Drawing.Size(130, 52);
            this.ddbMoveItemsToSelectedLocation.Text = "Перемістити";
            // 
            // btnMoveItemsToQuarantine
            // 
            this.btnMoveItemsToQuarantine.Name = "btnMoveItemsToQuarantine";
            this.btnMoveItemsToQuarantine.Size = new System.Drawing.Size(207, 22);
            this.btnMoveItemsToQuarantine.Text = "В зону карантину імпорту";
            this.btnMoveItemsToQuarantine.Click += new System.EventHandler(this.btnMoveItemsToQuarantine_Click);
            // 
            // btnMoveItemsFromQuarantine
            // 
            this.btnMoveItemsFromQuarantine.Name = "btnMoveItemsFromQuarantine";
            this.btnMoveItemsFromQuarantine.Size = new System.Drawing.Size(207, 22);
            this.btnMoveItemsFromQuarantine.Text = "Із зони карантину імпорту";
            this.btnMoveItemsFromQuarantine.Click += new System.EventHandler(this.btnMoveItemsFromQuarantine_Click);
            // 
            // btnShowAttachments
            // 
            this.btnShowAttachments.Image = global::WMSOffice.Properties.Resources.paperclip;
            this.btnShowAttachments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAttachments.Name = "btnShowAttachments";
            this.btnShowAttachments.Size = new System.Drawing.Size(113, 52);
            this.btnShowAttachments.Text = "Вклад.\nпротоколи";
            this.btnShowAttachments.Click += new System.EventHandler(this.btnShowAttachments_Click);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilters.AutoScroll = true;
            this.pnlFilters.Controls.Add(this.pbDocsWebSyncState);
            this.pnlFilters.Controls.Add(this.dtpPeriodTo);
            this.pnlFilters.Controls.Add(this.lblPeriodTo);
            this.pnlFilters.Controls.Add(this.lblPeriodFrom);
            this.pnlFilters.Controls.Add(this.dtpPeriodFrom);
            this.pnlFilters.Controls.Add(this.cbExpired);
            this.pnlFilters.Controls.Add(this.cmbDocCode);
            this.pnlFilters.Controls.Add(this.label1);
            this.pnlFilters.Controls.Add(this.chbIncludeArchived);
            this.pnlFilters.Controls.Add(this.tbxBatchID);
            this.pnlFilters.Controls.Add(this.lblBatchID);
            this.pnlFilters.Controls.Add(this.tbxVendorLot);
            this.pnlFilters.Controls.Add(this.lblVendorLot);
            this.pnlFilters.Controls.Add(this.tbxItemID);
            this.pnlFilters.Controls.Add(this.lblItem);
            this.pnlFilters.Controls.Add(this.tbxDocID);
            this.pnlFilters.Controls.Add(this.lblDocID);
            this.pnlFilters.Location = new System.Drawing.Point(0, 58);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1538, 55);
            this.pnlFilters.TabIndex = 20;
            // 
            // pbDocsWebSyncState
            // 
            this.pbDocsWebSyncState.Image = global::WMSOffice.Properties.Resources.circle_green;
            this.pbDocsWebSyncState.Location = new System.Drawing.Point(1321, 4);
            this.pbDocsWebSyncState.Name = "pbDocsWebSyncState";
            this.pbDocsWebSyncState.Size = new System.Drawing.Size(32, 32);
            this.pbDocsWebSyncState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDocsWebSyncState.TabIndex = 68;
            this.pbDocsWebSyncState.TabStop = false;
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.Checked = false;
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(1075, 10);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.ShowCheckBox = true;
            this.dtpPeriodTo.Size = new System.Drawing.Size(110, 20);
            this.dtpPeriodTo.TabIndex = 67;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(1007, 14);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(59, 13);
            this.lblPeriodTo.TabIndex = 66;
            this.lblPeriodTo.Text = "Період по:";
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(831, 14);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(53, 13);
            this.lblPeriodFrom.TabIndex = 65;
            this.lblPeriodFrom.Text = "Період з:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.Checked = false;
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(892, 10);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.ShowCheckBox = true;
            this.dtpPeriodFrom.Size = new System.Drawing.Size(110, 20);
            this.dtpPeriodFrom.TabIndex = 64;
            // 
            // cbExpired
            // 
            this.cbExpired.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbExpired.AutoSize = true;
            this.cbExpired.Location = new System.Drawing.Point(1361, 9);
            this.cbExpired.Name = "cbExpired";
            this.cbExpired.Size = new System.Drawing.Size(158, 23);
            this.cbExpired.TabIndex = 63;
            this.cbExpired.Text = "Протермінованих висновків";
            this.cbExpired.UseVisualStyleBackColor = true;
            this.cbExpired.CheckedChanged += new System.EventHandler(this.cbExpired_CheckedChanged);
            // 
            // cmbDocCode
            // 
            this.cmbDocCode.DisplayMember = "Name";
            this.cmbDocCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocCode.FormattingEnabled = true;
            this.cmbDocCode.Location = new System.Drawing.Point(67, 10);
            this.cmbDocCode.Name = "cmbDocCode";
            this.cmbDocCode.Size = new System.Drawing.Size(120, 21);
            this.cmbDocCode.TabIndex = 62;
            this.cmbDocCode.ValueMember = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Категорія:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chbIncludeArchived
            // 
            this.chbIncludeArchived.AutoSize = true;
            this.chbIncludeArchived.Location = new System.Drawing.Point(1195, 12);
            this.chbIncludeArchived.Name = "chbIncludeArchived";
            this.chbIncludeArchived.Size = new System.Drawing.Size(116, 17);
            this.chbIncludeArchived.TabIndex = 60;
            this.chbIncludeArchived.Text = "В т.ч. архів. заяви";
            this.chbIncludeArchived.UseVisualStyleBackColor = true;
            // 
            // tbxBatchID
            // 
            this.tbxBatchID.Location = new System.Drawing.Point(726, 10);
            this.tbxBatchID.Name = "tbxBatchID";
            this.tbxBatchID.Size = new System.Drawing.Size(100, 20);
            this.tbxBatchID.TabIndex = 50;
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.Location = new System.Drawing.Point(673, 14);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(43, 13);
            this.lblBatchID.TabIndex = 6;
            this.lblBatchID.Text = "Партія:";
            // 
            // tbxVendorLot
            // 
            this.tbxVendorLot.Location = new System.Drawing.Point(569, 10);
            this.tbxVendorLot.Name = "tbxVendorLot";
            this.tbxVendorLot.Size = new System.Drawing.Size(100, 20);
            this.tbxVendorLot.TabIndex = 40;
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(522, 14);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(37, 13);
            this.lblVendorLot.TabIndex = 4;
            this.lblVendorLot.Text = "Серія:";
            // 
            // tbxItemID
            // 
            this.tbxItemID.Location = new System.Drawing.Point(408, 10);
            this.tbxItemID.Name = "tbxItemID";
            this.tbxItemID.Size = new System.Drawing.Size(110, 20);
            this.tbxItemID.TabIndex = 30;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(361, 14);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(41, 13);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "Товар:";
            // 
            // tbxDocID
            // 
            this.tbxDocID.Location = new System.Drawing.Point(257, 10);
            this.tbxDocID.Name = "tbxDocID";
            this.tbxDocID.Size = new System.Drawing.Size(100, 20);
            this.tbxDocID.TabIndex = 21;
            // 
            // lblDocID
            // 
            this.lblDocID.AutoSize = true;
            this.lblDocID.Location = new System.Drawing.Point(191, 14);
            this.lblDocID.Name = "lblDocID";
            this.lblDocID.Size = new System.Drawing.Size(54, 13);
            this.lblDocID.TabIndex = 0;
            this.lblDocID.Text = "ID заяви:";
            // 
            // edgDocs
            // 
            this.edgDocs.AllowSort = true;
            this.edgDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edgDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.edgDocs.LargeAmountOfData = false;
            this.edgDocs.Location = new System.Drawing.Point(0, 119);
            this.edgDocs.Name = "edgDocs";
            this.edgDocs.RowHeadersVisible = false;
            this.edgDocs.Size = new System.Drawing.Size(1538, 190);
            this.edgDocs.TabIndex = 71;
            this.edgDocs.UserID = ((long)(0));
            this.edgDocs.OnRowSelectionChanged += new System.EventHandler(this.egvDocs_SelectionChanged);
            this.edgDocs.OnFormattingCell += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.egvDocs_CellFormatting);
            this.edgDocs.OnFilterChanged += new System.EventHandler(this.edgDocs_OnFilterChanged);
            this.edgDocs.OnRowDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.edgDocs_OnRowDoubleClick);
            this.edgDocs.OnDataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.egvDocs_DataBindingComplete);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToOrderColumns = true;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.climgIsRepeatedLot,
            this.clchbIsRepeatedLot,
            this.clIsProblemIcon,
            this.clIsProblemItem,
            this.clLineID,
            this.clItemID,
            this.clItemName,
            this.clManufacturer,
            this.clManufacturerPlant,
            this.ManufacturerCountry,
            this.Exp_Date,
            this.clVendorLot,
            this.clLotNumber,
            this.clLotQty,
            this.Warehouse,
            this.Location,
            this.clMode,
            this.clADocId,
            this.clAConclDocnumber,
            this.clAOutConclDocDate,
            this.clStatusID,
            this.clStatusName,
            this.clDirectionID,
            this.clDirectionNumber,
            this.clStatusDate,
            this.clVendorInvoice,
            this.clVendorInvoiceDate,
            this.clRegNum,
            this.clRegDate,
            this.clRegEndDate,
            this.clLastUsers,
            this.clConclType_Name,
            this.Manuf_Date2,
            this.clManufDate,
            this.clManufSectorDsc,
            this.clGMPSert,
            this.clSellPermissionStatus,
            this.clSellPermissionNumber,
            this.clCertRemark,
            this.clDock});
            this.dgvLines.ContextMenuStrip = this.cmsDocs;
            this.dgvLines.DataSource = this.bsDocDetails;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLines.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLines.Location = new System.Drawing.Point(0, 39);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvLines.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(1538, 256);
            this.dgvLines.TabIndex = 90;
            this.dgvLines.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLines_CellDoubleClick);
            this.dgvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvLines_DataBindingComplete);
            this.dgvLines.SelectionChanged += new System.EventHandler(this.gvLines_SelectionChanged);
            // 
            // climgIsRepeatedLot
            // 
            this.climgIsRepeatedLot.HeaderText = "";
            this.climgIsRepeatedLot.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.climgIsRepeatedLot.Name = "climgIsRepeatedLot";
            this.climgIsRepeatedLot.ReadOnly = true;
            this.climgIsRepeatedLot.Width = 5;
            // 
            // clchbIsRepeatedLot
            // 
            this.clchbIsRepeatedLot.DataPropertyName = "Control_Ready";
            this.clchbIsRepeatedLot.HeaderText = "Control_Ready";
            this.clchbIsRepeatedLot.Name = "clchbIsRepeatedLot";
            this.clchbIsRepeatedLot.ReadOnly = true;
            this.clchbIsRepeatedLot.Visible = false;
            // 
            // clIsProblemIcon
            // 
            this.clIsProblemIcon.HeaderText = "";
            this.clIsProblemIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.clIsProblemIcon.Name = "clIsProblemIcon";
            this.clIsProblemIcon.ReadOnly = true;
            this.clIsProblemIcon.Width = 5;
            // 
            // clIsProblemItem
            // 
            this.clIsProblemItem.DataPropertyName = "Has_Gls_Remarks";
            this.clIsProblemItem.HeaderText = "IsProblemItem";
            this.clIsProblemItem.Name = "clIsProblemItem";
            this.clIsProblemItem.ReadOnly = true;
            this.clIsProblemItem.Visible = false;
            // 
            // clLineID
            // 
            this.clLineID.DataPropertyName = "Line_ID";
            this.clLineID.HeaderText = "№";
            this.clLineID.Name = "clLineID";
            this.clLineID.ReadOnly = true;
            this.clLineID.Width = 30;
            // 
            // clItemID
            // 
            this.clItemID.DataPropertyName = "Item_ID";
            this.clItemID.HeaderText = "Код";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 58;
            // 
            // clItemName
            // 
            this.clItemName.DataPropertyName = "ItemName";
            this.clItemName.HeaderText = "Назва";
            this.clItemName.Name = "clItemName";
            this.clItemName.ReadOnly = true;
            this.clItemName.Width = 131;
            // 
            // clManufacturer
            // 
            this.clManufacturer.DataPropertyName = "Manufacturer";
            this.clManufacturer.HeaderText = "Виробник";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.ReadOnly = true;
            this.clManufacturer.Width = 135;
            // 
            // clManufacturerPlant
            // 
            this.clManufacturerPlant.DataPropertyName = "ManufacturerPlant";
            this.clManufacturerPlant.HeaderText = "Завод";
            this.clManufacturerPlant.Name = "clManufacturerPlant";
            this.clManufacturerPlant.ReadOnly = true;
            this.clManufacturerPlant.Width = 73;
            // 
            // ManufacturerCountry
            // 
            this.ManufacturerCountry.DataPropertyName = "ManufacturerCountry";
            this.ManufacturerCountry.HeaderText = "Країна заводу";
            this.ManufacturerCountry.Name = "ManufacturerCountry";
            this.ManufacturerCountry.ReadOnly = true;
            // 
            // Exp_Date
            // 
            this.Exp_Date.DataPropertyName = "Exp_Date";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Exp_Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Exp_Date.HeaderText = "Термін придатності";
            this.Exp_Date.Name = "Exp_Date";
            this.Exp_Date.ReadOnly = true;
            this.Exp_Date.Width = 130;
            // 
            // clVendorLot
            // 
            this.clVendorLot.DataPropertyName = "VendorLot";
            this.clVendorLot.HeaderText = "Серія";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            this.clVendorLot.Width = 74;
            // 
            // clLotNumber
            // 
            this.clLotNumber.DataPropertyName = "Lot_Number";
            this.clLotNumber.HeaderText = "Партія";
            this.clLotNumber.Name = "clLotNumber";
            this.clLotNumber.ReadOnly = true;
            // 
            // clLotQty
            // 
            this.clLotQty.DataPropertyName = "LotQty";
            this.clLotQty.HeaderText = "Розмір серії";
            this.clLotQty.Name = "clLotQty";
            this.clLotQty.ReadOnly = true;
            this.clLotQty.Width = 125;
            // 
            // Warehouse
            // 
            this.Warehouse.DataPropertyName = "Warehouse";
            this.Warehouse.HeaderText = "Склад";
            this.Warehouse.Name = "Warehouse";
            this.Warehouse.ReadOnly = true;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Місце";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // clMode
            // 
            this.clMode.DataPropertyName = "Mode";
            this.clMode.HeaderText = "Тип";
            this.clMode.Name = "clMode";
            this.clMode.ReadOnly = true;
            this.clMode.Width = 58;
            // 
            // clADocId
            // 
            this.clADocId.DataPropertyName = "A_Doc_ID";
            this.clADocId.HeaderText = "№ архівної заяви";
            this.clADocId.Name = "clADocId";
            this.clADocId.ReadOnly = true;
            this.clADocId.Width = 161;
            // 
            // clAConclDocnumber
            // 
            this.clAConclDocnumber.DataPropertyName = "A_Concl_Doc_Number";
            this.clAConclDocnumber.HeaderText = "№ архівного висновку";
            this.clAConclDocnumber.Name = "clAConclDocnumber";
            this.clAConclDocnumber.ReadOnly = true;
            this.clAConclDocnumber.Width = 201;
            // 
            // clAOutConclDocDate
            // 
            this.clAOutConclDocDate.DataPropertyName = "A_OutConcl_Doc_Date";
            this.clAOutConclDocDate.HeaderText = "Дата архівного висновку";
            this.clAOutConclDocDate.Name = "clAOutConclDocDate";
            this.clAOutConclDocDate.ReadOnly = true;
            this.clAOutConclDocDate.Width = 221;
            // 
            // clStatusID
            // 
            this.clStatusID.DataPropertyName = "Status_ID";
            this.clStatusID.HeaderText = "Ст.";
            this.clStatusID.Name = "clStatusID";
            this.clStatusID.ReadOnly = true;
            this.clStatusID.Width = 53;
            // 
            // clStatusName
            // 
            this.clStatusName.DataPropertyName = "StatusName";
            this.clStatusName.HeaderText = "Статус";
            this.clStatusName.Name = "clStatusName";
            this.clStatusName.ReadOnly = true;
            this.clStatusName.Width = 78;
            // 
            // clDirectionID
            // 
            this.clDirectionID.DataPropertyName = "Direction_ID";
            this.clDirectionID.HeaderText = "№нп";
            this.clDirectionID.Name = "clDirectionID";
            this.clDirectionID.ReadOnly = true;
            this.clDirectionID.Width = 63;
            // 
            // clDirectionNumber
            // 
            this.clDirectionNumber.DataPropertyName = "Direction_Number";
            this.clDirectionNumber.HeaderText = "Направлення";
            this.clDirectionNumber.Name = "clDirectionNumber";
            this.clDirectionNumber.ReadOnly = true;
            this.clDirectionNumber.Width = 122;
            // 
            // clStatusDate
            // 
            this.clStatusDate.DataPropertyName = "StatusDate";
            this.clStatusDate.HeaderText = "На статусі з";
            this.clStatusDate.Name = "clStatusDate";
            this.clStatusDate.ReadOnly = true;
            this.clStatusDate.Width = 117;
            // 
            // clVendorInvoice
            // 
            this.clVendorInvoice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clVendorInvoice.DataPropertyName = "VendorInvoice";
            this.clVendorInvoice.HeaderText = "№ інвойсу";
            this.clVendorInvoice.Name = "clVendorInvoice";
            this.clVendorInvoice.ReadOnly = true;
            this.clVendorInvoice.Width = 105;
            // 
            // clVendorInvoiceDate
            // 
            this.clVendorInvoiceDate.DataPropertyName = "VendorInvoiceDate";
            this.clVendorInvoiceDate.HeaderText = "Дата інвойсу";
            this.clVendorInvoiceDate.Name = "clVendorInvoiceDate";
            this.clVendorInvoiceDate.ReadOnly = true;
            this.clVendorInvoiceDate.Width = 125;
            // 
            // clRegNum
            // 
            this.clRegNum.DataPropertyName = "RegNum";
            this.clRegNum.HeaderText = "№ реєстр. посвідчення";
            this.clRegNum.Name = "clRegNum";
            this.clRegNum.ReadOnly = true;
            this.clRegNum.Width = 114;
            // 
            // clRegDate
            // 
            this.clRegDate.DataPropertyName = "RegDate";
            dataGridViewCellStyle3.Format = "d";
            this.clRegDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.clRegDate.HeaderText = "Дата реєстр.";
            this.clRegDate.Name = "clRegDate";
            this.clRegDate.ReadOnly = true;
            this.clRegDate.Width = 96;
            // 
            // clRegEndDate
            // 
            this.clRegEndDate.DataPropertyName = "RegEndDate";
            dataGridViewCellStyle4.Format = "d";
            this.clRegEndDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.clRegEndDate.HeaderText = "Дата заверш. реєстр.";
            this.clRegEndDate.Name = "clRegEndDate";
            this.clRegEndDate.ReadOnly = true;
            this.clRegEndDate.Width = 153;
            // 
            // clLastUsers
            // 
            this.clLastUsers.DataPropertyName = "LastUsers";
            this.clLastUsers.HeaderText = "Користувач";
            this.clLastUsers.Name = "clLastUsers";
            this.clLastUsers.ReadOnly = true;
            this.clLastUsers.Width = 126;
            // 
            // clConclType_Name
            // 
            this.clConclType_Name.DataPropertyName = "Concl_Type_Name";
            this.clConclType_Name.HeaderText = "Висновок";
            this.clConclType_Name.Name = "clConclType_Name";
            this.clConclType_Name.ReadOnly = true;
            // 
            // Manuf_Date2
            // 
            this.Manuf_Date2.DataPropertyName = "Manuf_Date2";
            this.Manuf_Date2.HeaderText = "Дата виробництва";
            this.Manuf_Date2.Name = "Manuf_Date2";
            this.Manuf_Date2.ReadOnly = true;
            this.Manuf_Date2.Width = 130;
            // 
            // clManufDate
            // 
            this.clManufDate.DataPropertyName = "Manuf_Date";
            this.clManufDate.HeaderText = "Дата випуску серії";
            this.clManufDate.Name = "clManufDate";
            this.clManufDate.ReadOnly = true;
            this.clManufDate.Width = 130;
            // 
            // clManufSectorDsc
            // 
            this.clManufSectorDsc.DataPropertyName = "Manuf_Sector_Dsc";
            this.clManufSectorDsc.HeaderText = "Опис вироб. ділянки";
            this.clManufSectorDsc.Name = "clManufSectorDsc";
            this.clManufSectorDsc.ReadOnly = true;
            this.clManufSectorDsc.Width = 200;
            // 
            // clGMPSert
            // 
            this.clGMPSert.DataPropertyName = "GMP_Sert";
            this.clGMPSert.HeaderText = "GMP-реквізити";
            this.clGMPSert.Name = "clGMPSert";
            this.clGMPSert.ReadOnly = true;
            this.clGMPSert.Width = 120;
            // 
            // clSellPermissionStatus
            // 
            this.clSellPermissionStatus.DataPropertyName = "Sell_Permission_Status";
            this.clSellPermissionStatus.HeaderText = "Статус Дозволу";
            this.clSellPermissionStatus.Name = "clSellPermissionStatus";
            this.clSellPermissionStatus.ReadOnly = true;
            this.clSellPermissionStatus.Width = 180;
            // 
            // clSellPermissionNumber
            // 
            this.clSellPermissionNumber.DataPropertyName = "Sell_Permission_Number";
            this.clSellPermissionNumber.HeaderText = "№ Дозволу";
            this.clSellPermissionNumber.Name = "clSellPermissionNumber";
            this.clSellPermissionNumber.ReadOnly = true;
            // 
            // clCertRemark
            // 
            this.clCertRemark.DataPropertyName = "Cert_Remark";
            this.clCertRemark.HeaderText = "Зауваження до сертифікату";
            this.clCertRemark.Name = "clCertRemark";
            this.clCertRemark.ReadOnly = true;
            this.clCertRemark.Width = 150;
            // 
            // clDock
            // 
            this.clDock.DataPropertyName = "Dock";
            this.clDock.HeaderText = "Оприбуткування";
            this.clDock.Name = "clDock";
            this.clDock.ReadOnly = true;
            // 
            // cmsDocs
            // 
            this.cmsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh});
            this.cmsDocs.Name = "contextMenuStrip1";
            this.cmsDocs.Size = new System.Drawing.Size(138, 26);
            // 
            // miRefresh
            // 
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(137, 22);
            this.miRefresh.Text = "Оновити";
            this.miRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // bsDocDetails
            // 
            this.bsDocDetails.DataMember = "DocDetails";
            this.bsDocDetails.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripLine
            // 
            this.toolStripLine.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbLotFilter,
            this.tssAfterLotFilter,
            this.btnSetMode,
            this.tssAfterSetMode,
            this.btnSetConclusion,
            this.btnPreviewSellPermission,
            this.btnPrintSellPermission,
            this.cmbPrinters,
            this.btnEditArchiveConclusion,
            this.btnCloseForReason,
            this.tssAfterSetPrescription,
            this.btnVendorSellPermission,
            this.btnSetAnaliz,
            this.btnSetAnalizSent,
            this.btnSetCertRemark,
            this.btnCertRemarkEliminated,
            this.btnEditAnalysisData,
            this.btnGlsRemarksForLine,
            this.tssAfterWatchProblems,
            this.btnEditRegistrationLifetime,
            this.btnChoiceExpert,
            this.btnEditManufacturer,
            this.btnEditManufacturerCountry,
            this.btnEditExpDate,
            this.btnEditGMP});
            this.toolStripLine.Location = new System.Drawing.Point(0, 0);
            this.toolStripLine.Name = "toolStripLine";
            this.toolStripLine.Size = new System.Drawing.Size(1538, 39);
            this.toolStripLine.TabIndex = 80;
            this.toolStripLine.Text = "toolStrip1";
            // 
            // cmbLotFilter
            // 
            this.cmbLotFilter.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLotFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLotFilter.DropDownWidth = 121;
            this.cmbLotFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbLotFilter.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbLotFilter.Items.AddRange(new object[] {
            "Нові серії",
            "Всі серії",
            "Нероздруковані серії"});
            this.cmbLotFilter.Name = "cmbLotFilter";
            this.cmbLotFilter.Size = new System.Drawing.Size(170, 39);
            this.cmbLotFilter.ToolTipText = "Фільтр відображення позицій заяви";
            // 
            // tssAfterLotFilter
            // 
            this.tssAfterLotFilter.Name = "tssAfterLotFilter";
            this.tssAfterLotFilter.Size = new System.Drawing.Size(6, 39);
            // 
            // btnSetMode
            // 
            this.btnSetMode.Enabled = false;
            this.btnSetMode.Image = global::WMSOffice.Properties.Resources.drug_basket;
            this.btnSetMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetMode.Name = "btnSetMode";
            this.btnSetMode.Size = new System.Drawing.Size(102, 36);
            this.btnSetMode.Text = "Встановити\nрежим";
            this.btnSetMode.Click += new System.EventHandler(this.btnSetMode_Click);
            // 
            // tssAfterSetMode
            // 
            this.tssAfterSetMode.Name = "tssAfterSetMode";
            this.tssAfterSetMode.Size = new System.Drawing.Size(6, 39);
            // 
            // btnSetConclusion
            // 
            this.btnSetConclusion.Enabled = false;
            this.btnSetConclusion.Image = global::WMSOffice.Properties.Resources.document_certificate;
            this.btnSetConclusion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetConclusion.Name = "btnSetConclusion";
            this.btnSetConclusion.Size = new System.Drawing.Size(93, 36);
            this.btnSetConclusion.Text = "Отримано\nвисновок";
            this.btnSetConclusion.Click += new System.EventHandler(this.btnSetConclusion_Click);
            // 
            // btnPreviewSellPermission
            // 
            this.btnPreviewSellPermission.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreviewSellPermission.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPreviewSellPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviewSellPermission.Name = "btnPreviewSellPermission";
            this.btnPreviewSellPermission.Size = new System.Drawing.Size(36, 36);
            this.btnPreviewSellPermission.ToolTipText = "Перегляд/підтвердження документа - дозвіл на реалізацію серії";
            this.btnPreviewSellPermission.Click += new System.EventHandler(this.btnPreviewSellPermission_Click);
            // 
            // btnPrintSellPermission
            // 
            this.btnPrintSellPermission.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintSellPermission.Enabled = false;
            this.btnPrintSellPermission.Image = global::WMSOffice.Properties.Resources.print;
            this.btnPrintSellPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintSellPermission.Name = "btnPrintSellPermission";
            this.btnPrintSellPermission.Size = new System.Drawing.Size(36, 36);
            this.btnPrintSellPermission.ToolTipText = "Друк дозвільних документів реалізації серії на обраному принтері для обранихрядкі" +
                "в";
            this.btnPrintSellPermission.Click += new System.EventHandler(this.btnPrintSellPermission_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownWidth = 250;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(200, 39);
            // 
            // btnEditArchiveConclusion
            // 
            this.btnEditArchiveConclusion.Enabled = false;
            this.btnEditArchiveConclusion.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditArchiveConclusion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditArchiveConclusion.Name = "btnEditArchiveConclusion";
            this.btnEditArchiveConclusion.Size = new System.Drawing.Size(115, 36);
            this.btnEditArchiveConclusion.Text = "Коригування\nарх. висновку";
            this.btnEditArchiveConclusion.Click += new System.EventHandler(this.btnEditArchiveConclusion_Click);
            // 
            // btnCloseForReason
            // 
            this.btnCloseForReason.Enabled = false;
            this.btnCloseForReason.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCloseForReason.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseForReason.Name = "btnCloseForReason";
            this.btnCloseForReason.Size = new System.Drawing.Size(93, 36);
            this.btnCloseForReason.Text = "Закрити\nз причини";
            this.btnCloseForReason.Click += new System.EventHandler(this.btnCloseForReason_Click);
            // 
            // tssAfterSetPrescription
            // 
            this.tssAfterSetPrescription.Name = "tssAfterSetPrescription";
            this.tssAfterSetPrescription.Size = new System.Drawing.Size(6, 39);
            // 
            // btnVendorSellPermission
            // 
            this.btnVendorSellPermission.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnVendorSellPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVendorSellPermission.Name = "btnVendorSellPermission";
            this.btnVendorSellPermission.Size = new System.Drawing.Size(120, 36);
            this.btnVendorSellPermission.Text = "Дозвіл\nпостачальника";
            this.btnVendorSellPermission.Click += new System.EventHandler(this.btnVendorSellPermission_Click);
            // 
            // btnSetAnaliz
            // 
            this.btnSetAnaliz.Enabled = false;
            this.btnSetAnaliz.Image = global::WMSOffice.Properties.Resources.message_information;
            this.btnSetAnaliz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetAnaliz.Name = "btnSetAnaliz";
            this.btnSetAnaliz.Size = new System.Drawing.Size(93, 36);
            this.btnSetAnaliz.Text = "Отримано\nаналіз";
            this.btnSetAnaliz.Click += new System.EventHandler(this.btnAnaliz_Click);
            // 
            // btnSetAnalizSent
            // 
            this.btnSetAnalizSent.Enabled = false;
            this.btnSetAnalizSent.Image = global::WMSOffice.Properties.Resources.mail_ok;
            this.btnSetAnalizSent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetAnalizSent.Name = "btnSetAnalizSent";
            this.btnSetAnalizSent.Size = new System.Drawing.Size(92, 36);
            this.btnSetAnalizSent.Text = "Аналіз\nпередано";
            this.btnSetAnalizSent.Click += new System.EventHandler(this.btnAnaliz_Click);
            // 
            // btnSetCertRemark
            // 
            this.btnSetCertRemark.Image = global::WMSOffice.Properties.Resources.dialog_question;
            this.btnSetCertRemark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetCertRemark.Name = "btnSetCertRemark";
            this.btnSetCertRemark.Size = new System.Drawing.Size(121, 36);
            this.btnSetCertRemark.Text = "Зауваження до\nсертифікату";
            this.btnSetCertRemark.ToolTipText = "Додати зауваження до сертифікату, виданому з лабораторії";
            this.btnSetCertRemark.Click += new System.EventHandler(this.btnSetCertRemark_Click);
            // 
            // btnCertRemarkEliminated
            // 
            this.btnCertRemarkEliminated.Image = global::WMSOffice.Properties.Resources.message_information;
            this.btnCertRemarkEliminated.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCertRemarkEliminated.Name = "btnCertRemarkEliminated";
            this.btnCertRemarkEliminated.Size = new System.Drawing.Size(103, 36);
            this.btnCertRemarkEliminated.Text = "Сертифікат\nвиправлено";
            this.btnCertRemarkEliminated.ToolTipText = "Внести до системи факт отримання виправленого сертифіката з лабораторії";
            this.btnCertRemarkEliminated.Click += new System.EventHandler(this.btnCertRemarkEliminated_Click);
            // 
            // btnEditAnalysisData
            // 
            this.btnEditAnalysisData.Enabled = false;
            this.btnEditAnalysisData.Image = global::WMSOffice.Properties.Resources.line_sight;
            this.btnEditAnalysisData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAnalysisData.Name = "btnEditAnalysisData";
            this.btnEditAnalysisData.Size = new System.Drawing.Size(119, 36);
            this.btnEditAnalysisData.Text = "Редагувати\nдані про аналіз";
            this.btnEditAnalysisData.Click += new System.EventHandler(this.btnAnaliz_Click);
            // 
            // btnGlsRemarksForLine
            // 
            this.btnGlsRemarksForLine.Enabled = false;
            this.btnGlsRemarksForLine.Image = ((System.Drawing.Image)(resources.GetObject("btnGlsRemarksForLine.Image")));
            this.btnGlsRemarksForLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGlsRemarksForLine.Name = "btnGlsRemarksForLine";
            this.btnGlsRemarksForLine.Size = new System.Drawing.Size(105, 36);
            this.btnGlsRemarksForLine.Text = "Зауваження\nвід ДЛС";
            this.btnGlsRemarksForLine.Click += new System.EventHandler(this.SetGlsRemarks_Click);
            // 
            // tssAfterWatchProblems
            // 
            this.tssAfterWatchProblems.Name = "tssAfterWatchProblems";
            this.tssAfterWatchProblems.Size = new System.Drawing.Size(6, 39);
            // 
            // btnEditRegistrationLifetime
            // 
            this.btnEditRegistrationLifetime.Enabled = false;
            this.btnEditRegistrationLifetime.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.btnEditRegistrationLifetime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditRegistrationLifetime.Name = "btnEditRegistrationLifetime";
            this.btnEditRegistrationLifetime.Size = new System.Drawing.Size(146, 36);
            this.btnEditRegistrationLifetime.Text = "Змінити термін дії\nреєстр. посвідчення";
            this.btnEditRegistrationLifetime.Click += new System.EventHandler(this.btnEditRegistrationLifetime_Click);
            // 
            // btnChoiceExpert
            // 
            this.btnChoiceExpert.Image = global::WMSOffice.Properties.Resources.merging;
            this.btnChoiceExpert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChoiceExpert.Name = "btnChoiceExpert";
            this.btnChoiceExpert.Size = new System.Drawing.Size(161, 36);
            this.btnChoiceExpert.Text = "Введення направлення";
            this.btnChoiceExpert.Click += new System.EventHandler(this.btnChoiceExpert_Click);
            // 
            // btnEditManufacturer
            // 
            this.btnEditManufacturer.Image = global::WMSOffice.Properties.Resources.manufacturer;
            this.btnEditManufacturer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditManufacturer.Name = "btnEditManufacturer";
            this.btnEditManufacturer.Size = new System.Drawing.Size(148, 36);
            this.btnEditManufacturer.Text = "Коригування заводу\nвиробника";
            this.btnEditManufacturer.Click += new System.EventHandler(this.btnEditManufacturer_Click);
            // 
            // btnEditManufacturerCountry
            // 
            this.btnEditManufacturerCountry.Image = global::WMSOffice.Properties.Resources.manufacturer;
            this.btnEditManufacturerCountry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditManufacturerCountry.Name = "btnEditManufacturerCountry";
            this.btnEditManufacturerCountry.Size = new System.Drawing.Size(144, 36);
            this.btnEditManufacturerCountry.Text = "Коригування країни\nзаводу виробника";
            this.btnEditManufacturerCountry.Click += new System.EventHandler(this.btnEditManufacturerCountry_Click);
            // 
            // btnEditExpDate
            // 
            this.btnEditExpDate.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.btnEditExpDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditExpDate.Name = "btnEditExpDate";
            this.btnEditExpDate.Size = new System.Drawing.Size(146, 36);
            this.btnEditExpDate.Text = "Коригування\nтерміну придатності";
            this.btnEditExpDate.Click += new System.EventHandler(this.btnEditExpDate_Click);
            // 
            // btnEditGMP
            // 
            this.btnEditGMP.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.btnEditGMP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditGMP.Name = "btnEditGMP";
            this.btnEditGMP.Size = new System.Drawing.Size(133, 36);
            this.btnEditGMP.Text = "Коригування GMP";
            this.btnEditGMP.Click += new System.EventHandler(this.btnEditGMP_Click);
            // 
            // taDocs
            // 
            this.taDocs.ClearBeforeFill = true;
            // 
            // taDocDetails
            // 
            this.taDocDetails.ClearBeforeFill = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 900000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // QualityRequestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 669);
            this.Controls.Add(this.spcMain);
            this.KeyPreview = true;
            this.Name = "QualityRequestWindow";
            this.Text = "Робота із заявками";
            this.Load += new System.EventHandler(this.QualityRequestWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityRequestWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QualityRequestWindow_KeyDown);
            this.Controls.SetChildIndex(this.spcMain, 0);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.Panel2.PerformLayout();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).EndInit();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocsWebSyncState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.cmsDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsDocDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.toolStripLine.ResumeLayout(false);
            this.toolStripLine.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.DocsTableAdapter taDocs;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.BindingSource bsDocDetails;
        private WMSOffice.Data.QualityTableAdapters.DocDetailsTableAdapter taDocDetails;
        private System.Windows.Forms.ContextMenuStrip cmsDocs;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStrip toolStripLine;
        private System.Windows.Forms.ToolStripButton btnSetMode;
        private System.Windows.Forms.ToolStripSeparator tssAfterSetMode;
        private System.Windows.Forms.ToolStripButton btnSetConclusion;
        private System.Windows.Forms.ToolStripButton btnCloseForReason;
        private System.Windows.Forms.ToolStripSeparator tssAfterSetPrescription;
        private System.Windows.Forms.ToolStripButton btnSetAnaliz;
        private System.Windows.Forms.ToolStripButton btnSetAnalizSent;
        private System.Windows.Forms.ToolStripButton btnGlsRemarksForLine;
        private System.Windows.Forms.ToolStripComboBox cmbLotFilter;
        private System.Windows.Forms.ToolStripSeparator tssAfterWatchProblems;
        private System.Windows.Forms.ToolStripSeparator tssAfterLotFilter;
        private System.Windows.Forms.ToolStripButton btnEditArchiveConclusion;
        private System.Windows.Forms.ToolStripButton btnEditRegistrationLifetime;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView edgDocs;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripButton btnPreviewSellPermission;
        private System.Windows.Forms.ToolStripButton btnPrintSellPermission;
        private System.Windows.Forms.ToolStripButton btnEditAnalysisData;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.TextBox tbxVendorLot;
        private System.Windows.Forms.Label lblVendorLot;
        private System.Windows.Forms.TextBox tbxItemID;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox tbxDocID;
        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.CheckBox chbIncludeArchived;
        private System.Windows.Forms.TextBox tbxBatchID;
        private System.ComponentModel.BackgroundWorker bgwRequestsLoader;
        private System.Windows.Forms.PictureBox pbSplashControl;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnCancelLoading;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.ToolStripButton btnPrintDoc;
        private System.Windows.Forms.ToolStripButton btnReprintDoc;
        private System.Windows.Forms.ToolStripButton btnPrintSelectedDocs;
        private System.Windows.Forms.ToolStripButton btnSertPrintSettings;
        private System.Windows.Forms.ToolStripButton btnCompleteDocPreparing;
        private System.Windows.Forms.ToolStripButton btnGlsRemarks;
        private System.Windows.Forms.ToolStripButton btnDelayReasons;
        private System.Windows.Forms.ToolStripButton btnRequestParameters;
        private System.Windows.Forms.ToolStripButton btnSetCertRemark;
        private System.Windows.Forms.ToolStripButton btnCertRemarkEliminated;
        private System.Windows.Forms.ToolStripDropDownButton ddbPrintAcceptanceAct;
        private System.Windows.Forms.ToolStripMenuItem btnPrintActForOptima;
        private System.Windows.Forms.ToolStripMenuItem btnPrintActForGls;
        private System.Windows.Forms.ToolStripMenuItem btnViewActForOptima;
        private System.Windows.Forms.ToolStripMenuItem btnViewActForGls;
        private System.Windows.Forms.ToolStripButton btnVendorSellPermission;
        private System.Windows.Forms.ToolStripButton sbDocComment;
        private System.Windows.Forms.ToolStripButton btnChoiceExpert;
        private System.Windows.Forms.ComboBox cmbDocCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbExpired;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripButton btnEditManufacturer;
        private System.Windows.Forms.ToolStripButton btnEditGMP;
        private System.Windows.Forms.ToolStripButton btnEditExpDate;
        private System.Windows.Forms.ToolStripButton btnEditManufacturerCountry;
        private System.Windows.Forms.ToolStripButton btnSendToInspection;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripSeparator tssExportToExcel;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.PictureBox pbDocsWebSyncState;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.ToolStripButton sbMoveToNewDoc;
        private System.Windows.Forms.ToolStripDropDownButton ddbMoveItemsToSelectedLocation;
        private System.Windows.Forms.ToolStripMenuItem btnMoveItemsToQuarantine;
        private System.Windows.Forms.ToolStripMenuItem btnMoveItemsFromQuarantine;
        private System.Windows.Forms.DataGridViewImageColumn climgIsRepeatedLot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clchbIsRepeatedLot;
        private System.Windows.Forms.DataGridViewImageColumn clIsProblemIcon;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsProblemItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturerPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exp_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLotQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clADocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAConclDocnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAOutConclDocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDirectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDirectionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatusDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRegNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRegEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLastUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn clConclType_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manuf_Date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufSectorDsc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGMPSert;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSellPermissionStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSellPermissionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCertRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDock;
        private System.Windows.Forms.ToolStripButton btnShowAttachments;
    }
}