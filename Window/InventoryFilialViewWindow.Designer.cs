namespace WMSOffice.Window
{
    partial class InventoryFilialViewWindow
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
            this.toolStripDocs = new System.Windows.Forms.ToolStrip();
            this.btnRefreshInventories = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.btnAddInventory = new System.Windows.Forms.ToolStripButton();
            this.btnEditInventory = new System.Windows.Forms.ToolStripButton();
            this.btnSigners = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteInventory = new System.Windows.Forms.ToolStripButton();
            this.tssAfterEdit = new System.Windows.Forms.ToolStripSeparator();
            this.sbPlanResources = new System.Windows.Forms.ToolStripButton();
            this.sbInventoryMonitoring = new System.Windows.Forms.ToolStripButton();
            this.btnRunChecks = new System.Windows.Forms.ToolStripButton();
            this.btnRunAutoChecks = new System.Windows.Forms.ToolStripButton();
            this.btnToWork = new System.Windows.Forms.ToolStripButton();
            this.btnCreateCalc = new System.Windows.Forms.ToolStripButton();
            this.btnCloseInventory = new System.Windows.Forms.ToolStripButton();
            this.btnPeresorts = new System.Windows.Forms.ToolStripButton();
            this.btnReplacings = new System.Windows.Forms.ToolStripButton();
            this.cmsInventoriesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefreshInventories = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAddInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.miSigners = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miRunChecks = new System.Windows.Forms.ToolStripMenuItem();
            this.miToWork = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.miPeresorts = new System.Windows.Forms.ToolStripMenuItem();
            this.miReplacings = new System.Windows.Forms.ToolStripMenuItem();
            this.tssCmmAfterInventoryStatuses = new System.Windows.Forms.ToolStripSeparator();
            this.miInventoryListPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportInvenrotyResults = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportInventorySheetToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportPeresort = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportMoving = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportSurpluses = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportDifferences = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportBonuses = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportCalcListsData = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvInventories = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.spcHContainer = new System.Windows.Forms.SplitContainer();
            this.spcVContainer = new System.Windows.Forms.SplitContainer();
            this.dgvCalcs = new System.Windows.Forms.DataGridView();
            this.calcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsCalcsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCreateEmptyCountSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseRecalc = new System.Windows.Forms.ToolStripMenuItem();
            this.tssCcmAfterCloseRecalc = new System.Windows.Forms.ToolStripSeparator();
            this.miCalcDiff = new System.Windows.Forms.ToolStripMenuItem();
            this.bsFiRecalculations = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.dgvCalcLists = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmsCalcSheetsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCalcSheetPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintCalcSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.tssCMMAfterCalcListsPrint = new System.Windows.Forms.ToolStripSeparator();
            this.miEnteredDataWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.miCsEditAfterClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miBindCsToUser = new System.Windows.Forms.ToolStripMenuItem();
            this.miBindManyCsToEmp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCalcLists = new System.Windows.Forms.ToolStrip();
            this.btnCalcSheetPreview = new System.Windows.Forms.ToolStripButton();
            this.btnPrintCalcSheet = new System.Windows.Forms.ToolStripButton();
            this.tssAfterCalcSheetPrint = new System.Windows.Forms.ToolStripSeparator();
            this.btnEnteredDataWindow = new System.Windows.Forms.ToolStripButton();
            this.btnEditCsAfterClose = new System.Windows.Forms.ToolStripButton();
            this.taFiRecalculations = new WMSOffice.Data.InventoryTableAdapters.FI_RecalculationsTableAdapter();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.spcHContainerHost = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tbInventoryType = new System.Windows.Forms.TextBox();
            this.stbInventoryType = new WMSOffice.Controls.SearchTextBox();
            this.stbFilial = new WMSOffice.Controls.SearchTextBox();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.lblInventoryType = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.tbFilial = new System.Windows.Forms.TextBox();
            this.lblFilial = new System.Windows.Forms.Label();
            this.pnlMainContentHost = new System.Windows.Forms.Panel();
            this.toolStripDocs.SuspendLayout();
            this.cmsInventoriesMenu.SuspendLayout();
            this.spcHContainer.Panel1.SuspendLayout();
            this.spcHContainer.Panel2.SuspendLayout();
            this.spcHContainer.SuspendLayout();
            this.spcVContainer.Panel1.SuspendLayout();
            this.spcVContainer.Panel2.SuspendLayout();
            this.spcVContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalcs)).BeginInit();
            this.cmsCalcsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiRecalculations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.cmsCalcSheetsMenu.SuspendLayout();
            this.tsCalcLists.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.spcHContainerHost.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlMainContentHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripDocs
            // 
            this.toolStripDocs.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshInventories,
            this.tssAfterRefresh,
            this.cbPrinters,
            this.lblPrinters,
            this.btnAddInventory,
            this.btnEditInventory,
            this.btnSigners,
            this.btnDeleteInventory,
            this.tssAfterEdit,
            this.sbPlanResources,
            this.sbInventoryMonitoring,
            this.btnRunChecks,
            this.btnRunAutoChecks,
            this.btnToWork,
            this.btnCreateCalc,
            this.btnCloseInventory,
            this.btnPeresorts,
            this.btnReplacings});
            this.toolStripDocs.Location = new System.Drawing.Point(0, 40);
            this.toolStripDocs.Name = "toolStripDocs";
            this.toolStripDocs.Size = new System.Drawing.Size(1284, 55);
            this.toolStripDocs.TabIndex = 1;
            this.toolStripDocs.Text = "Панель инструментов документа";
            // 
            // btnRefreshInventories
            // 
            this.btnRefreshInventories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshInventories.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshInventories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshInventories.Name = "btnRefreshInventories";
            this.btnRefreshInventories.Size = new System.Drawing.Size(52, 52);
            this.btnRefreshInventories.ToolTipText = "Обновить список инвентаризаций";
            this.btnRefreshInventories.Click += new System.EventHandler(this.btnRefreshInventories_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // cbPrinters
            // 
            this.cbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // lblPrinters
            // 
            this.lblPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(58, 52);
            this.lblPrinters.Text = "Принтер:";
            // 
            // btnAddInventory
            // 
            this.btnAddInventory.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnAddInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddInventory.Name = "btnAddInventory";
            this.btnAddInventory.Size = new System.Drawing.Size(152, 52);
            this.btnAddInventory.Text = "Создать\nинвентаризацию";
            this.btnAddInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddInventory.Click += new System.EventHandler(this.btnAddInventory_Click);
            // 
            // btnEditInventory
            // 
            this.btnEditInventory.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditInventory.Name = "btnEditInventory";
            this.btnEditInventory.Size = new System.Drawing.Size(152, 52);
            this.btnEditInventory.Text = "Редактировать\nинвентаризацию";
            this.btnEditInventory.Click += new System.EventHandler(this.btnEditInventory_Click);
            // 
            // btnSigners
            // 
            this.btnSigners.Image = global::WMSOffice.Properties.Resources.config_users;
            this.btnSigners.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSigners.Name = "btnSigners";
            this.btnSigners.Size = new System.Drawing.Size(114, 52);
            this.btnSigners.Text = "Члены\nкомиссии";
            this.btnSigners.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSigners.Click += new System.EventHandler(this.btnSigners_Click);
            // 
            // btnDeleteInventory
            // 
            this.btnDeleteInventory.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDeleteInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteInventory.Name = "btnDeleteInventory";
            this.btnDeleteInventory.Size = new System.Drawing.Size(152, 52);
            this.btnDeleteInventory.Text = "Удалить\nинвентаризацию";
            this.btnDeleteInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteInventory.Click += new System.EventHandler(this.btnDeleteInventory_Click);
            // 
            // tssAfterEdit
            // 
            this.tssAfterEdit.Name = "tssAfterEdit";
            this.tssAfterEdit.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPlanResources
            // 
            this.sbPlanResources.Image = global::WMSOffice.Properties.Resources.user;
            this.sbPlanResources.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPlanResources.Name = "sbPlanResources";
            this.sbPlanResources.Size = new System.Drawing.Size(143, 52);
            this.sbPlanResources.Text = "Запланировать\nресурсы";
            this.sbPlanResources.Click += new System.EventHandler(this.sbPlanResources_Click);
            // 
            // sbInventoryMonitoring
            // 
            this.sbInventoryMonitoring.Image = global::WMSOffice.Properties.Resources.monitoring;
            this.sbInventoryMonitoring.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbInventoryMonitoring.Name = "sbInventoryMonitoring";
            this.sbInventoryMonitoring.Size = new System.Drawing.Size(149, 52);
            this.sbInventoryMonitoring.Text = "Мониторинг\nинвентаризации";
            this.sbInventoryMonitoring.Click += new System.EventHandler(this.sbInventoryMonitoring_Click);
            // 
            // btnRunChecks
            // 
            this.btnRunChecks.Image = global::WMSOffice.Properties.Resources.checklist;
            this.btnRunChecks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunChecks.Name = "btnRunChecks";
            this.btnRunChecks.Size = new System.Drawing.Size(121, 52);
            this.btnRunChecks.Text = "Выполнить\nпроверки";
            this.btnRunChecks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunChecks.Click += new System.EventHandler(this.btnRunChecks_Click);
            // 
            // btnRunAutoChecks
            // 
            this.btnRunAutoChecks.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnRunAutoChecks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunAutoChecks.Name = "btnRunAutoChecks";
            this.btnRunAutoChecks.Size = new System.Drawing.Size(151, 52);
            this.btnRunAutoChecks.Text = "Автоматический\nзапуск проверок";
            this.btnRunAutoChecks.Click += new System.EventHandler(this.btnRunAutoChecks_Click);
            // 
            // btnToWork
            // 
            this.btnToWork.Image = global::WMSOffice.Properties.Resources.pallet;
            this.btnToWork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToWork.Name = "btnToWork";
            this.btnToWork.Size = new System.Drawing.Size(117, 52);
            this.btnToWork.Text = "Отправить\nв работу";
            this.btnToWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToWork.Click += new System.EventHandler(this.btnToWork_Click);
            // 
            // btnCreateCalc
            // 
            this.btnCreateCalc.Image = global::WMSOffice.Properties.Resources.line_sight;
            this.btnCreateCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateCalc.Name = "btnCreateCalc";
            this.btnCreateCalc.Size = new System.Drawing.Size(109, 52);
            this.btnCreateCalc.Text = "Создать\nпересчет";
            this.btnCreateCalc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateCalc.Click += new System.EventHandler(this.btnCreateCalc_Click);
            // 
            // btnCloseInventory
            // 
            this.btnCloseInventory.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.btnCloseInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseInventory.Name = "btnCloseInventory";
            this.btnCloseInventory.Size = new System.Drawing.Size(152, 52);
            this.btnCloseInventory.Text = "Закрыть\nинвентаризацию";
            this.btnCloseInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseInventory.Click += new System.EventHandler(this.btnCloseInventory_Click);
            // 
            // btnPeresorts
            // 
            this.btnPeresorts.Image = global::WMSOffice.Properties.Resources.link;
            this.btnPeresorts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeresorts.Name = "btnPeresorts";
            this.btnPeresorts.Size = new System.Drawing.Size(121, 52);
            this.btnPeresorts.Text = "Выполнить\nпересорты";
            this.btnPeresorts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPeresorts.Click += new System.EventHandler(this.btnPeresorts_Click);
            // 
            // btnReplacings
            // 
            this.btnReplacings.Image = global::WMSOffice.Properties.Resources.in_box;
            this.btnReplacings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplacings.Name = "btnReplacings";
            this.btnReplacings.Size = new System.Drawing.Size(137, 52);
            this.btnReplacings.Text = "Выполнить\nперемещения";
            this.btnReplacings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplacings.Click += new System.EventHandler(this.btnReplacings_Click);
            // 
            // cmsInventoriesMenu
            // 
            this.cmsInventoriesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefreshInventories,
            this.toolStripSeparator1,
            this.miAddInventory,
            this.miEditInventory,
            this.miSigners,
            this.miDeleteInventory,
            this.toolStripSeparator2,
            this.miRunChecks,
            this.miToWork,
            this.miCreateCalc,
            this.miCloseInventory,
            this.miPeresorts,
            this.miReplacings,
            this.tssCmmAfterInventoryStatuses,
            this.miInventoryListPrint,
            this.miExportInvenrotyResults,
            this.miExportInventorySheetToExcel,
            this.miExportPeresort,
            this.miExportMoving,
            this.miExportSurpluses,
            this.miExportDifferences,
            this.miExportBonuses,
            this.miExportCalcListsData});
            this.cmsInventoriesMenu.Name = "cmsInventoriesMenu";
            this.cmsInventoriesMenu.Size = new System.Drawing.Size(303, 462);
            // 
            // miRefreshInventories
            // 
            this.miRefreshInventories.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefreshInventories.Name = "miRefreshInventories";
            this.miRefreshInventories.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefreshInventories.Size = new System.Drawing.Size(302, 22);
            this.miRefreshInventories.Text = "Обновить";
            this.miRefreshInventories.Click += new System.EventHandler(this.btnRefreshInventories_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(299, 6);
            // 
            // miAddInventory
            // 
            this.miAddInventory.Image = global::WMSOffice.Properties.Resources.add_document;
            this.miAddInventory.Name = "miAddInventory";
            this.miAddInventory.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miAddInventory.Size = new System.Drawing.Size(302, 22);
            this.miAddInventory.Text = "Создать инвентаризацию";
            this.miAddInventory.Click += new System.EventHandler(this.btnAddInventory_Click);
            // 
            // miEditInventory
            // 
            this.miEditInventory.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.miEditInventory.Name = "miEditInventory";
            this.miEditInventory.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miEditInventory.Size = new System.Drawing.Size(302, 22);
            this.miEditInventory.Text = "Редактировать инвентаризацию";
            this.miEditInventory.Click += new System.EventHandler(this.btnEditInventory_Click);
            // 
            // miSigners
            // 
            this.miSigners.Image = global::WMSOffice.Properties.Resources.config_users;
            this.miSigners.Name = "miSigners";
            this.miSigners.Size = new System.Drawing.Size(302, 22);
            this.miSigners.Text = "Члены комиссии";
            this.miSigners.Click += new System.EventHandler(this.btnSigners_Click);
            // 
            // miDeleteInventory
            // 
            this.miDeleteInventory.Image = global::WMSOffice.Properties.Resources.Delete;
            this.miDeleteInventory.Name = "miDeleteInventory";
            this.miDeleteInventory.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.miDeleteInventory.Size = new System.Drawing.Size(302, 22);
            this.miDeleteInventory.Text = "Удалить инвентаризацию";
            this.miDeleteInventory.Click += new System.EventHandler(this.btnDeleteInventory_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(299, 6);
            // 
            // miRunChecks
            // 
            this.miRunChecks.Image = global::WMSOffice.Properties.Resources.checklist;
            this.miRunChecks.Name = "miRunChecks";
            this.miRunChecks.Size = new System.Drawing.Size(302, 22);
            this.miRunChecks.Text = "Выполнить проверки";
            this.miRunChecks.Click += new System.EventHandler(this.btnRunChecks_Click);
            // 
            // miToWork
            // 
            this.miToWork.Image = global::WMSOffice.Properties.Resources.pallet;
            this.miToWork.Name = "miToWork";
            this.miToWork.Size = new System.Drawing.Size(302, 22);
            this.miToWork.Text = "Отправить в работу";
            this.miToWork.Click += new System.EventHandler(this.btnToWork_Click);
            // 
            // miCreateCalc
            // 
            this.miCreateCalc.Image = global::WMSOffice.Properties.Resources.line_sight;
            this.miCreateCalc.Name = "miCreateCalc";
            this.miCreateCalc.Size = new System.Drawing.Size(302, 22);
            this.miCreateCalc.Text = "Создать пересчет";
            this.miCreateCalc.Click += new System.EventHandler(this.btnCreateCalc_Click);
            // 
            // miCloseInventory
            // 
            this.miCloseInventory.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.miCloseInventory.Name = "miCloseInventory";
            this.miCloseInventory.Size = new System.Drawing.Size(302, 22);
            this.miCloseInventory.Text = "Закрыть инвентаризацию";
            this.miCloseInventory.Click += new System.EventHandler(this.btnCloseInventory_Click);
            // 
            // miPeresorts
            // 
            this.miPeresorts.Image = global::WMSOffice.Properties.Resources.link;
            this.miPeresorts.Name = "miPeresorts";
            this.miPeresorts.Size = new System.Drawing.Size(302, 22);
            this.miPeresorts.Text = "Выполнить пересорты";
            this.miPeresorts.Click += new System.EventHandler(this.btnPeresorts_Click);
            // 
            // miReplacings
            // 
            this.miReplacings.Image = global::WMSOffice.Properties.Resources.in_box;
            this.miReplacings.Name = "miReplacings";
            this.miReplacings.Size = new System.Drawing.Size(302, 22);
            this.miReplacings.Text = "Выполнить перемещения";
            this.miReplacings.Click += new System.EventHandler(this.btnReplacings_Click);
            // 
            // tssCmmAfterInventoryStatuses
            // 
            this.tssCmmAfterInventoryStatuses.Name = "tssCmmAfterInventoryStatuses";
            this.tssCmmAfterInventoryStatuses.Size = new System.Drawing.Size(299, 6);
            // 
            // miInventoryListPrint
            // 
            this.miInventoryListPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miInventoryListPrint.Name = "miInventoryListPrint";
            this.miInventoryListPrint.Size = new System.Drawing.Size(302, 22);
            this.miInventoryListPrint.Text = "Печать инвентаризационной описи";
            this.miInventoryListPrint.Click += new System.EventHandler(this.btnInventoryListPrint_Click);
            // 
            // miExportInvenrotyResults
            // 
            this.miExportInvenrotyResults.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miExportInvenrotyResults.Name = "miExportInvenrotyResults";
            this.miExportInvenrotyResults.Size = new System.Drawing.Size(302, 22);
            this.miExportInvenrotyResults.Text = "Экспорт результатов в Excel";
            this.miExportInvenrotyResults.Click += new System.EventHandler(this.miExportInvenrotyResults_Click);
            // 
            // miExportInventorySheetToExcel
            // 
            this.miExportInventorySheetToExcel.Image = global::WMSOffice.Properties.Resources.Excel2;
            this.miExportInventorySheetToExcel.Name = "miExportInventorySheetToExcel";
            this.miExportInventorySheetToExcel.Size = new System.Drawing.Size(302, 22);
            this.miExportInventorySheetToExcel.Text = "Экспорт инвентаризационной ведомости";
            this.miExportInventorySheetToExcel.Click += new System.EventHandler(this.miExportInventorySheetToExcel_Click);
            // 
            // miExportPeresort
            // 
            this.miExportPeresort.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miExportPeresort.Name = "miExportPeresort";
            this.miExportPeresort.Size = new System.Drawing.Size(302, 22);
            this.miExportPeresort.Text = "Экспорт пересортов в Excel";
            this.miExportPeresort.Click += new System.EventHandler(this.miExportPeresort_Click);
            // 
            // miExportMoving
            // 
            this.miExportMoving.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miExportMoving.Name = "miExportMoving";
            this.miExportMoving.Size = new System.Drawing.Size(302, 22);
            this.miExportMoving.Text = "Экспорт списания в Excel";
            this.miExportMoving.Click += new System.EventHandler(this.miMoving_Click);
            // 
            // miExportSurpluses
            // 
            this.miExportSurpluses.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miExportSurpluses.Name = "miExportSurpluses";
            this.miExportSurpluses.Size = new System.Drawing.Size(302, 22);
            this.miExportSurpluses.Text = "Экспорт излишков в Excel";
            this.miExportSurpluses.Click += new System.EventHandler(this.miExportSurpluses_Click);
            // 
            // miExportDifferences
            // 
            this.miExportDifferences.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miExportDifferences.Name = "miExportDifferences";
            this.miExportDifferences.Size = new System.Drawing.Size(302, 22);
            this.miExportDifferences.Text = "Экспорт расхождений в Excel";
            this.miExportDifferences.Click += new System.EventHandler(this.miExportDifferences_Click);
            // 
            // miExportBonuses
            // 
            this.miExportBonuses.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miExportBonuses.Name = "miExportBonuses";
            this.miExportBonuses.Size = new System.Drawing.Size(302, 22);
            this.miExportBonuses.Text = "Экспорт распределения бонусов в Excel";
            this.miExportBonuses.Click += new System.EventHandler(this.miExportBonuses_Click);
            // 
            // miExportCalcListsData
            // 
            this.miExportCalcListsData.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miExportCalcListsData.Name = "miExportCalcListsData";
            this.miExportCalcListsData.Size = new System.Drawing.Size(302, 22);
            this.miExportCalcListsData.Text = "Экспорт данных по счетным листам";
            this.miExportCalcListsData.Click += new System.EventHandler(this.miExportCalcListsData_Click);
            // 
            // dgvInventories
            // 
            this.dgvInventories.AllowSort = true;
            this.dgvInventories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvInventories.ContextMenuStrip = this.cmsInventoriesMenu;
            this.dgvInventories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventories.LargeAmountOfData = false;
            this.dgvInventories.Location = new System.Drawing.Point(0, 0);
            this.dgvInventories.Name = "dgvInventories";
            this.dgvInventories.RowHeadersVisible = false;
            this.dgvInventories.Size = new System.Drawing.Size(1284, 146);
            this.dgvInventories.TabIndex = 0;
            this.dgvInventories.UserID = ((long)(0));
            // 
            // spcHContainer
            // 
            this.spcHContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHContainer.Location = new System.Drawing.Point(0, 0);
            this.spcHContainer.Name = "spcHContainer";
            this.spcHContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcHContainer.Panel1
            // 
            this.spcHContainer.Panel1.Controls.Add(this.dgvInventories);
            // 
            // spcHContainer.Panel2
            // 
            this.spcHContainer.Panel2.Controls.Add(this.spcVContainer);
            this.spcHContainer.Size = new System.Drawing.Size(1284, 257);
            this.spcHContainer.SplitterDistance = 146;
            this.spcHContainer.TabIndex = 4;
            // 
            // spcVContainer
            // 
            this.spcVContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcVContainer.Location = new System.Drawing.Point(0, 0);
            this.spcVContainer.Name = "spcVContainer";
            // 
            // spcVContainer.Panel1
            // 
            this.spcVContainer.Panel1.Controls.Add(this.dgvCalcs);
            // 
            // spcVContainer.Panel2
            // 
            this.spcVContainer.Panel2.Controls.Add(this.dgvCalcLists);
            this.spcVContainer.Panel2.Controls.Add(this.tsCalcLists);
            this.spcVContainer.Size = new System.Drawing.Size(1284, 107);
            this.spcVContainer.SplitterDistance = 505;
            this.spcVContainer.TabIndex = 0;
            // 
            // dgvCalcs
            // 
            this.dgvCalcs.AllowUserToAddRows = false;
            this.dgvCalcs.AllowUserToDeleteRows = false;
            this.dgvCalcs.AllowUserToResizeRows = false;
            this.dgvCalcs.AutoGenerateColumns = false;
            this.dgvCalcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalcs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.calcID,
            this.calcType,
            this.statusID,
            this.statusName,
            this.colorDataGridViewTextBoxColumn});
            this.dgvCalcs.ContextMenuStrip = this.cmsCalcsMenu;
            this.dgvCalcs.DataSource = this.bsFiRecalculations;
            this.dgvCalcs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalcs.Location = new System.Drawing.Point(0, 0);
            this.dgvCalcs.MultiSelect = false;
            this.dgvCalcs.Name = "dgvCalcs";
            this.dgvCalcs.ReadOnly = true;
            this.dgvCalcs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalcs.Size = new System.Drawing.Size(505, 107);
            this.dgvCalcs.TabIndex = 0;
            this.dgvCalcs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCalcs_DataBindingComplete);
            this.dgvCalcs.SelectionChanged += new System.EventHandler(this.dgvCalcs_SelectionChanged);
            // 
            // calcID
            // 
            this.calcID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.calcID.DataPropertyName = "Calc_ID";
            this.calcID.HeaderText = "№ пересчета";
            this.calcID.Name = "calcID";
            this.calcID.ReadOnly = true;
            this.calcID.Width = 98;
            // 
            // calcType
            // 
            this.calcType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.calcType.DataPropertyName = "Calc_Type";
            this.calcType.HeaderText = "Тип";
            this.calcType.Name = "calcType";
            this.calcType.ReadOnly = true;
            this.calcType.Width = 51;
            // 
            // statusID
            // 
            this.statusID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusID.DataPropertyName = "Status_ID";
            this.statusID.HeaderText = "Ст.";
            this.statusID.Name = "statusID";
            this.statusID.ReadOnly = true;
            this.statusID.Width = 47;
            // 
            // statusName
            // 
            this.statusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusName.DataPropertyName = "Status_Name";
            this.statusName.HeaderText = "Статус";
            this.statusName.Name = "statusName";
            this.statusName.ReadOnly = true;
            this.statusName.Width = 66;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "Color";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            this.colorDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorDataGridViewTextBoxColumn.Visible = false;
            // 
            // cmsCalcsMenu
            // 
            this.cmsCalcsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateEmptyCountSheet,
            this.miCloseRecalc,
            this.tssCcmAfterCloseRecalc,
            this.miCalcDiff});
            this.cmsCalcsMenu.Name = "cmsCalcsMenu";
            this.cmsCalcsMenu.Size = new System.Drawing.Size(256, 98);
            // 
            // miCreateEmptyCountSheet
            // 
            this.miCreateEmptyCountSheet.Image = global::WMSOffice.Properties.Resources.add;
            this.miCreateEmptyCountSheet.Name = "miCreateEmptyCountSheet";
            this.miCreateEmptyCountSheet.Size = new System.Drawing.Size(255, 22);
            this.miCreateEmptyCountSheet.Text = "Создать \"Пустографку\"";
            this.miCreateEmptyCountSheet.Click += new System.EventHandler(this.miCreateEmptyCountSheet_Click);
            // 
            // miCloseRecalc
            // 
            this.miCloseRecalc.Image = global::WMSOffice.Properties.Resources.checkered_flag;
            this.miCloseRecalc.Name = "miCloseRecalc";
            this.miCloseRecalc.Size = new System.Drawing.Size(255, 22);
            this.miCloseRecalc.Text = "Закрыть пересчет";
            this.miCloseRecalc.Click += new System.EventHandler(this.miCloseRecalc_Click);
            // 
            // tssCcmAfterCloseRecalc
            // 
            this.tssCcmAfterCloseRecalc.Name = "tssCcmAfterCloseRecalc";
            this.tssCcmAfterCloseRecalc.Size = new System.Drawing.Size(252, 6);
            // 
            // miCalcDiff
            // 
            this.miCalcDiff.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miCalcDiff.Name = "miCalcDiff";
            this.miCalcDiff.Size = new System.Drawing.Size(255, 22);
            this.miCalcDiff.Text = "Отчет \"Ведомость расхождений\"";
            this.miCalcDiff.Click += new System.EventHandler(this.miCalcDiff_Click);
            // 
            // bsFiRecalculations
            // 
            this.bsFiRecalculations.DataMember = "FI_Recalculations";
            this.bsFiRecalculations.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvCalcLists
            // 
            this.dgvCalcLists.AllowSort = true;
            this.dgvCalcLists.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCalcLists.ContextMenuStrip = this.cmsCalcSheetsMenu;
            this.dgvCalcLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalcLists.LargeAmountOfData = false;
            this.dgvCalcLists.Location = new System.Drawing.Point(0, 39);
            this.dgvCalcLists.Name = "dgvCalcLists";
            this.dgvCalcLists.RowHeadersVisible = false;
            this.dgvCalcLists.Size = new System.Drawing.Size(775, 68);
            this.dgvCalcLists.TabIndex = 1;
            this.dgvCalcLists.UserID = ((long)(0));
            // 
            // cmsCalcSheetsMenu
            // 
            this.cmsCalcSheetsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCalcSheetPreview,
            this.miPrintCalcSheet,
            this.tssCMMAfterCalcListsPrint,
            this.miEnteredDataWindow,
            this.miCsEditAfterClose,
            this.toolStripSeparator3,
            this.miBindCsToUser,
            this.miBindManyCsToEmp});
            this.cmsCalcSheetsMenu.Name = "cmsCalcSheetsMenu";
            this.cmsCalcSheetsMenu.Size = new System.Drawing.Size(274, 148);
            // 
            // miCalcSheetPreview
            // 
            this.miCalcSheetPreview.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miCalcSheetPreview.Name = "miCalcSheetPreview";
            this.miCalcSheetPreview.Size = new System.Drawing.Size(273, 22);
            this.miCalcSheetPreview.Text = "Просмотр счетного листа";
            this.miCalcSheetPreview.Click += new System.EventHandler(this.btnCalcSheetPreview_Click);
            // 
            // miPrintCalcSheet
            // 
            this.miPrintCalcSheet.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miPrintCalcSheet.Name = "miPrintCalcSheet";
            this.miPrintCalcSheet.Size = new System.Drawing.Size(273, 22);
            this.miPrintCalcSheet.Text = "Печать счетного листа";
            this.miPrintCalcSheet.Click += new System.EventHandler(this.btnPrintCalcSheet_Click);
            // 
            // tssCMMAfterCalcListsPrint
            // 
            this.tssCMMAfterCalcListsPrint.Name = "tssCMMAfterCalcListsPrint";
            this.tssCMMAfterCalcListsPrint.Size = new System.Drawing.Size(270, 6);
            // 
            // miEnteredDataWindow
            // 
            this.miEnteredDataWindow.Image = global::WMSOffice.Properties.Resources.history_review;
            this.miEnteredDataWindow.Name = "miEnteredDataWindow";
            this.miEnteredDataWindow.Size = new System.Drawing.Size(273, 22);
            this.miEnteredDataWindow.Text = "Окно просмотра введенных данных";
            this.miEnteredDataWindow.Click += new System.EventHandler(this.btnEnteredDataWindow_Click);
            // 
            // miCsEditAfterClose
            // 
            this.miCsEditAfterClose.Image = global::WMSOffice.Properties.Resources.repeat;
            this.miCsEditAfterClose.Name = "miCsEditAfterClose";
            this.miCsEditAfterClose.Size = new System.Drawing.Size(273, 22);
            this.miCsEditAfterClose.Text = "Вернуть для редактирования";
            this.miCsEditAfterClose.Click += new System.EventHandler(this.btnEditCsAfterClose_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(270, 6);
            // 
            // miBindCsToUser
            // 
            this.miBindCsToUser.Name = "miBindCsToUser";
            this.miBindCsToUser.Size = new System.Drawing.Size(273, 22);
            this.miBindCsToUser.Text = "Отдать счетный лист пользователю";
            this.miBindCsToUser.Click += new System.EventHandler(this.miBindCsToUser_Click);
            // 
            // miBindManyCsToEmp
            // 
            this.miBindManyCsToEmp.Name = "miBindManyCsToEmp";
            this.miBindManyCsToEmp.Size = new System.Drawing.Size(273, 22);
            this.miBindManyCsToEmp.Text = "Назначить счетные листы";
            this.miBindManyCsToEmp.Click += new System.EventHandler(this.miBindManyCsToEmp_Click);
            // 
            // tsCalcLists
            // 
            this.tsCalcLists.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsCalcLists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCalcSheetPreview,
            this.btnPrintCalcSheet,
            this.tssAfterCalcSheetPrint,
            this.btnEnteredDataWindow,
            this.btnEditCsAfterClose});
            this.tsCalcLists.Location = new System.Drawing.Point(0, 0);
            this.tsCalcLists.Name = "tsCalcLists";
            this.tsCalcLists.Size = new System.Drawing.Size(775, 39);
            this.tsCalcLists.TabIndex = 0;
            this.tsCalcLists.Text = "Панель инструментов счетных листов";
            // 
            // btnCalcSheetPreview
            // 
            this.btnCalcSheetPreview.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnCalcSheetPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCalcSheetPreview.Name = "btnCalcSheetPreview";
            this.btnCalcSheetPreview.Size = new System.Drawing.Size(127, 36);
            this.btnCalcSheetPreview.Text = "Просмотр\nсчетного листа";
            this.btnCalcSheetPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalcSheetPreview.Click += new System.EventHandler(this.btnCalcSheetPreview_Click);
            // 
            // btnPrintCalcSheet
            // 
            this.btnPrintCalcSheet.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintCalcSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintCalcSheet.Name = "btnPrintCalcSheet";
            this.btnPrintCalcSheet.Size = new System.Drawing.Size(127, 36);
            this.btnPrintCalcSheet.Text = "Печать\nсчетного листа";
            this.btnPrintCalcSheet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintCalcSheet.Click += new System.EventHandler(this.btnPrintCalcSheet_Click);
            // 
            // tssAfterCalcSheetPrint
            // 
            this.tssAfterCalcSheetPrint.Name = "tssAfterCalcSheetPrint";
            this.tssAfterCalcSheetPrint.Size = new System.Drawing.Size(6, 39);
            // 
            // btnEnteredDataWindow
            // 
            this.btnEnteredDataWindow.Image = global::WMSOffice.Properties.Resources.history_review;
            this.btnEnteredDataWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnteredDataWindow.Name = "btnEnteredDataWindow";
            this.btnEnteredDataWindow.Size = new System.Drawing.Size(146, 36);
            this.btnEnteredDataWindow.Text = "Окно просмотра\nвведенных данных";
            this.btnEnteredDataWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnteredDataWindow.Click += new System.EventHandler(this.btnEnteredDataWindow_Click);
            // 
            // btnEditCsAfterClose
            // 
            this.btnEditCsAfterClose.Image = global::WMSOffice.Properties.Resources.repeat;
            this.btnEditCsAfterClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCsAfterClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditCsAfterClose.Name = "btnEditCsAfterClose";
            this.btnEditCsAfterClose.Size = new System.Drawing.Size(132, 36);
            this.btnEditCsAfterClose.Text = "Вернуть для\nредактирования";
            this.btnEditCsAfterClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCsAfterClose.Click += new System.EventHandler(this.btnEditCsAfterClose_Click);
            // 
            // taFiRecalculations
            // 
            this.taFiRecalculations.ClearBeforeFill = true;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.spcHContainerHost);
            this.pnlMainContent.Controls.Add(this.pnlFilter);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1284, 352);
            this.pnlMainContent.TabIndex = 5;
            // 
            // spcHContainerHost
            // 
            this.spcHContainerHost.Controls.Add(this.spcHContainer);
            this.spcHContainerHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHContainerHost.Location = new System.Drawing.Point(0, 95);
            this.spcHContainerHost.Name = "spcHContainerHost";
            this.spcHContainerHost.Size = new System.Drawing.Size(1284, 257);
            this.spcHContainerHost.TabIndex = 1;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.tbInventoryType);
            this.pnlFilter.Controls.Add(this.stbInventoryType);
            this.pnlFilter.Controls.Add(this.stbFilial);
            this.pnlFilter.Controls.Add(this.dtpPeriodTo);
            this.pnlFilter.Controls.Add(this.lblPeriodTo);
            this.pnlFilter.Controls.Add(this.lblPeriodFrom);
            this.pnlFilter.Controls.Add(this.lblInventoryType);
            this.pnlFilter.Controls.Add(this.dtpPeriodFrom);
            this.pnlFilter.Controls.Add(this.tbFilial);
            this.pnlFilter.Controls.Add(this.lblFilial);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1284, 95);
            this.pnlFilter.TabIndex = 0;
            // 
            // tbInventoryType
            // 
            this.tbInventoryType.BackColor = System.Drawing.SystemColors.Window;
            this.tbInventoryType.Location = new System.Drawing.Point(184, 38);
            this.tbInventoryType.Name = "tbInventoryType";
            this.tbInventoryType.ReadOnly = true;
            this.tbInventoryType.Size = new System.Drawing.Size(300, 20);
            this.tbInventoryType.TabIndex = 5;
            // 
            // stbInventoryType
            // 
            this.stbInventoryType.Location = new System.Drawing.Point(76, 38);
            this.stbInventoryType.Name = "stbInventoryType";
            this.stbInventoryType.NavigateByValue = false;
            this.stbInventoryType.ReadOnly = false;
            this.stbInventoryType.Size = new System.Drawing.Size(100, 20);
            this.stbInventoryType.TabIndex = 4;
            this.stbInventoryType.UserID = ((long)(0));
            this.stbInventoryType.Value = null;
            this.stbInventoryType.ValueReferenceQuery = null;
            // 
            // stbFilial
            // 
            this.stbFilial.Location = new System.Drawing.Point(76, 9);
            this.stbFilial.Name = "stbFilial";
            this.stbFilial.NavigateByValue = false;
            this.stbFilial.ReadOnly = false;
            this.stbFilial.Size = new System.Drawing.Size(100, 20);
            this.stbFilial.TabIndex = 1;
            this.stbFilial.UserID = ((long)(0));
            this.stbFilial.Value = null;
            this.stbFilial.ValueReferenceQuery = null;
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(384, 67);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 9;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(315, 71);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(63, 13);
            this.lblPeriodTo.TabIndex = 8;
            this.lblPeriodTo.Text = "Период по:";
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(13, 71);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(57, 13);
            this.lblPeriodFrom.TabIndex = 6;
            this.lblPeriodFrom.Text = "Период с:";
            // 
            // lblInventoryType
            // 
            this.lblInventoryType.AutoSize = true;
            this.lblInventoryType.Location = new System.Drawing.Point(13, 42);
            this.lblInventoryType.Name = "lblInventoryType";
            this.lblInventoryType.Size = new System.Drawing.Size(53, 13);
            this.lblInventoryType.TabIndex = 3;
            this.lblInventoryType.Text = "Тип инв.:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(76, 67);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 7;
            // 
            // tbFilial
            // 
            this.tbFilial.BackColor = System.Drawing.SystemColors.Window;
            this.tbFilial.Location = new System.Drawing.Point(184, 9);
            this.tbFilial.Name = "tbFilial";
            this.tbFilial.ReadOnly = true;
            this.tbFilial.Size = new System.Drawing.Size(300, 20);
            this.tbFilial.TabIndex = 2;
            // 
            // lblFilial
            // 
            this.lblFilial.AutoSize = true;
            this.lblFilial.Location = new System.Drawing.Point(13, 13);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(51, 13);
            this.lblFilial.TabIndex = 0;
            this.lblFilial.Text = "Филиал:";
            // 
            // pnlMainContentHost
            // 
            this.pnlMainContentHost.Controls.Add(this.pnlMainContent);
            this.pnlMainContentHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContentHost.Location = new System.Drawing.Point(0, 95);
            this.pnlMainContentHost.Name = "pnlMainContentHost";
            this.pnlMainContentHost.Size = new System.Drawing.Size(1284, 352);
            this.pnlMainContentHost.TabIndex = 6;
            // 
            // InventoryFilialViewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 447);
            this.Controls.Add(this.pnlMainContentHost);
            this.Controls.Add(this.toolStripDocs);
            this.Name = "InventoryFilialViewWindow";
            this.Text = "InventoryFilialViewWindow";
            this.Load += new System.EventHandler(this.InventoryFilialViewWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryFilialViewWindow_FormClosing);
            this.Controls.SetChildIndex(this.toolStripDocs, 0);
            this.Controls.SetChildIndex(this.pnlMainContentHost, 0);
            this.toolStripDocs.ResumeLayout(false);
            this.toolStripDocs.PerformLayout();
            this.cmsInventoriesMenu.ResumeLayout(false);
            this.spcHContainer.Panel1.ResumeLayout(false);
            this.spcHContainer.Panel2.ResumeLayout(false);
            this.spcHContainer.ResumeLayout(false);
            this.spcVContainer.Panel1.ResumeLayout(false);
            this.spcVContainer.Panel2.ResumeLayout(false);
            this.spcVContainer.Panel2.PerformLayout();
            this.spcVContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalcs)).EndInit();
            this.cmsCalcsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsFiRecalculations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.cmsCalcSheetsMenu.ResumeLayout(false);
            this.tsCalcLists.ResumeLayout(false);
            this.tsCalcLists.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.spcHContainerHost.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlMainContentHost.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDocs;
        private System.Windows.Forms.ContextMenuStrip cmsInventoriesMenu;
        private System.Windows.Forms.ToolStripMenuItem miRefreshInventories;
        private System.Windows.Forms.ToolStripButton btnRefreshInventories;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvInventories;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripButton btnDeleteInventory;
        private System.Windows.Forms.ToolStripSeparator tssAfterEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miDeleteInventory;
        private System.Windows.Forms.ToolStripButton btnToWork;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miToWork;
        private System.Windows.Forms.ToolStripButton btnCloseInventory;
        private System.Windows.Forms.ToolStripMenuItem miCloseInventory;
        private System.Windows.Forms.ToolStripButton btnAddInventory;
        private System.Windows.Forms.ToolStripMenuItem miAddInventory;
        private System.Windows.Forms.ToolStripButton btnEditInventory;
        private System.Windows.Forms.ToolStripMenuItem miEditInventory;
        private System.Windows.Forms.SplitContainer spcHContainer;
        private System.Windows.Forms.SplitContainer spcVContainer;
        private System.Windows.Forms.DataGridView dgvCalcs;
        private System.Windows.Forms.BindingSource bsFiRecalculations;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FI_RecalculationsTableAdapter taFiRecalculations;
        private System.Windows.Forms.ToolStrip tsCalcLists;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvCalcLists;
        private System.Windows.Forms.ToolStripButton btnRunChecks;
        private System.Windows.Forms.ToolStripMenuItem miRunChecks;
        private System.Windows.Forms.ToolStripButton btnCreateCalc;
        private System.Windows.Forms.ToolStripMenuItem miCreateCalc;
        private System.Windows.Forms.ContextMenuStrip cmsCalcsMenu;
        private System.Windows.Forms.ToolStripMenuItem miCreateEmptyCountSheet;
        private System.Windows.Forms.ToolStripMenuItem miCloseRecalc;
        private System.Windows.Forms.ToolStripSeparator tssCcmAfterCloseRecalc;
        private System.Windows.Forms.ToolStripMenuItem miCalcDiff;
        private System.Windows.Forms.ToolStripButton btnCalcSheetPreview;
        private System.Windows.Forms.ContextMenuStrip cmsCalcSheetsMenu;
        private System.Windows.Forms.ToolStripMenuItem miCalcSheetPreview;
        private System.Windows.Forms.ToolStripButton btnPrintCalcSheet;
        private System.Windows.Forms.ToolStripMenuItem miPrintCalcSheet;
        private System.Windows.Forms.ToolStripButton btnEnteredDataWindow;
        private System.Windows.Forms.ToolStripSeparator tssAfterCalcSheetPrint;
        private System.Windows.Forms.ToolStripSeparator tssCMMAfterCalcListsPrint;
        private System.Windows.Forms.ToolStripMenuItem miEnteredDataWindow;
        private System.Windows.Forms.ToolStripSeparator tssCmmAfterInventoryStatuses;
        private System.Windows.Forms.ToolStripMenuItem miInventoryListPrint;
        private System.Windows.Forms.ToolStripMenuItem miExportInvenrotyResults;
        private System.Windows.Forms.ToolStripMenuItem miExportInventorySheetToExcel;
        private System.Windows.Forms.ToolStripButton btnEditCsAfterClose;
        private System.Windows.Forms.ToolStripMenuItem miCsEditAfterClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcType;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton btnPeresorts;
        private System.Windows.Forms.ToolStripMenuItem miPeresorts;
        private System.Windows.Forms.ToolStripButton btnReplacings;
        private System.Windows.Forms.ToolStripMenuItem miReplacings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miBindCsToUser;
        private System.Windows.Forms.ToolStripMenuItem miBindManyCsToEmp;
        private System.Windows.Forms.ToolStripMenuItem miExportPeresort;
        private System.Windows.Forms.ToolStripMenuItem miExportMoving;
        private System.Windows.Forms.ToolStripMenuItem miExportSurpluses;
        private System.Windows.Forms.ToolStripMenuItem miExportDifferences;
        private System.Windows.Forms.ToolStripMenuItem miExportCalcListsData;
        private System.Windows.Forms.ToolStripButton btnSigners;
        private System.Windows.Forms.ToolStripMenuItem miSigners;
        private System.Windows.Forms.ToolStripButton sbPlanResources;
        private System.Windows.Forms.ToolStripButton sbInventoryMonitoring;
        private System.Windows.Forms.ToolStripButton btnRunAutoChecks;
        private System.Windows.Forms.ToolStripMenuItem miExportBonuses;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel spcHContainerHost;
        private System.Windows.Forms.Panel pnlMainContentHost;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.Label lblInventoryType;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.TextBox tbFilial;
        private System.Windows.Forms.Label lblFilial;
        private WMSOffice.Controls.SearchTextBox stbInventoryType;
        private WMSOffice.Controls.SearchTextBox stbFilial;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.TextBox tbInventoryType;
    }
}