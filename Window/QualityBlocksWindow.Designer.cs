namespace WMSOffice.Window
{
    partial class QualityBlocksWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualityBlocksWindow));
            this.tsDocs = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnCancelLoading = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.tssAfterExcel = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateBlockDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCreateBlockForRows = new System.Windows.Forms.ToolStripButton();
            this.btnCreateExceptionDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCreateExceptionForRows = new System.Windows.Forms.ToolStripButton();
            this.btnFinishBlockDoc = new System.Windows.Forms.ToolStripButton();
            this.btnFinishBlockForRows = new System.Windows.Forms.ToolStripButton();
            this.btnRecallNotification = new System.Windows.Forms.ToolStripButton();
            this.tssAfterSet = new System.Windows.Forms.ToolStripSeparator();
            this.btnApproveBlock = new System.Windows.Forms.ToolStripButton();
            this.btnItemOffers = new System.Windows.Forms.ToolStripButton();
            this.egvBlocks = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.bgwBlocksLoader = new System.ComponentModel.BackgroundWorker();
            this.pbSplashControl = new System.Windows.Forms.PictureBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.grbFilters = new System.Windows.Forms.GroupBox();
            this.tbxDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.lblExtendedFilterExists = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.ccbWarehouses = new WMSOffice.Controls.CheckedComboBox();
            this.lblWarehouses = new System.Windows.Forms.Label();
            this.ccbBlockTypes = new WMSOffice.Controls.CheckedComboBox();
            this.lblBlockTypes = new System.Windows.Forms.Label();
            this.rbtCommitNeeded = new System.Windows.Forms.RadioButton();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.rbtOnlyActive = new System.Windows.Forms.RadioButton();
            this.stbBatchId = new WMSOffice.Controls.SearchTextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.stbVendorLot = new WMSOffice.Controls.SearchTextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.chbDateFrom = new System.Windows.Forms.CheckBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.chbDateTo = new System.Windows.Forms.CheckBox();
            this.quality = new WMSOffice.Data.Quality();
            this.tsDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.grbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // tsDocs
            // 
            this.tsDocs.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnCancelLoading,
            this.tssAfterRefresh,
            this.btnFilter,
            this.btnExportToExcel,
            this.tssAfterExcel,
            this.btnCreateBlockDoc,
            this.btnCreateBlockForRows,
            this.btnCreateExceptionDoc,
            this.btnCreateExceptionForRows,
            this.btnFinishBlockDoc,
            this.btnFinishBlockForRows,
            this.btnRecallNotification,
            this.tssAfterSet,
            this.btnApproveBlock,
            this.btnItemOffers});
            this.tsDocs.Location = new System.Drawing.Point(0, 40);
            this.tsDocs.Name = "tsDocs";
            this.tsDocs.Size = new System.Drawing.Size(1398, 55);
            this.tsDocs.TabIndex = 1;
            this.tsDocs.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 52);
            this.btnRefresh.Text = "Обновить\n(F5)";
            this.btnRefresh.ToolTipText = "Обновить таблицу с блокировками, используя текущие значения фильтров";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancelLoading
            // 
            this.btnCancelLoading.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelLoading.Image")));
            this.btnCancelLoading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelLoading.Name = "btnCancelLoading";
            this.btnCancelLoading.Size = new System.Drawing.Size(113, 52);
            this.btnCancelLoading.Text = "Отменить\nзагрузку";
            this.btnCancelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelLoading.ToolTipText = "Отменить текущую загрузку";
            this.btnCancelLoading.Visible = false;
            this.btnCancelLoading.Click += new System.EventHandler(this.btnCancelLoading_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(117, 52);
            this.btnFilter.Text = "Фильтр по\nтоварам\n(Ctrl+F)";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(104, 52);
            this.btnExportToExcel.Text = "Экспорт\nв Excel\n(F3)";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // tssAfterExcel
            // 
            this.tssAfterExcel.Name = "tssAfterExcel";
            this.tssAfterExcel.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateBlockDoc
            // 
            this.btnCreateBlockDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCreateBlockDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateBlockDoc.Name = "btnCreateBlockDoc";
            this.btnCreateBlockDoc.Size = new System.Drawing.Size(125, 52);
            this.btnCreateBlockDoc.Text = "Блокировка\n(F4)";
            this.btnCreateBlockDoc.Click += new System.EventHandler(this.btnBlockAction_Click);
            // 
            // btnCreateBlockForRows
            // 
            this.btnCreateBlockForRows.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCreateBlockForRows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateBlockForRows.Name = "btnCreateBlockForRows";
            this.btnCreateBlockForRows.Size = new System.Drawing.Size(125, 52);
            this.btnCreateBlockForRows.Text = "Блокировка\nна строки\n(Shift+F4)";
            this.btnCreateBlockForRows.Click += new System.EventHandler(this.btnBlockAction_Click);
            // 
            // btnCreateExceptionDoc
            // 
            this.btnCreateExceptionDoc.Image = global::WMSOffice.Properties.Resources.Apply;
            this.btnCreateExceptionDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateExceptionDoc.Name = "btnCreateExceptionDoc";
            this.btnCreateExceptionDoc.Size = new System.Drawing.Size(130, 52);
            this.btnCreateExceptionDoc.Text = "Исключение\n(F6)";
            this.btnCreateExceptionDoc.Click += new System.EventHandler(this.btnBlockAction_Click);
            // 
            // btnCreateExceptionForRows
            // 
            this.btnCreateExceptionForRows.Image = global::WMSOffice.Properties.Resources.Apply;
            this.btnCreateExceptionForRows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateExceptionForRows.Name = "btnCreateExceptionForRows";
            this.btnCreateExceptionForRows.Size = new System.Drawing.Size(130, 52);
            this.btnCreateExceptionForRows.Text = "Исключение\nна строки\n(Shift+F6)";
            this.btnCreateExceptionForRows.Click += new System.EventHandler(this.btnBlockAction_Click);
            // 
            // btnFinishBlockDoc
            // 
            this.btnFinishBlockDoc.Image = global::WMSOffice.Properties.Resources.undo_action;
            this.btnFinishBlockDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinishBlockDoc.Name = "btnFinishBlockDoc";
            this.btnFinishBlockDoc.Size = new System.Drawing.Size(125, 52);
            this.btnFinishBlockDoc.Text = "Прекратить\nблокировку\n(F7)";
            this.btnFinishBlockDoc.Click += new System.EventHandler(this.btnBlockAction_Click);
            // 
            // btnFinishBlockForRows
            // 
            this.btnFinishBlockForRows.Image = global::WMSOffice.Properties.Resources.undo_action;
            this.btnFinishBlockForRows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinishBlockForRows.Name = "btnFinishBlockForRows";
            this.btnFinishBlockForRows.Size = new System.Drawing.Size(145, 52);
            this.btnFinishBlockForRows.Text = "Прекратить\nблокировку\nстрок (Shift+F7)";
            this.btnFinishBlockForRows.Click += new System.EventHandler(this.btnBlockAction_Click);
            // 
            // btnRecallNotification
            // 
            this.btnRecallNotification.Image = global::WMSOffice.Properties.Resources.checklist;
            this.btnRecallNotification.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecallNotification.Name = "btnRecallNotification";
            this.btnRecallNotification.Size = new System.Drawing.Size(133, 52);
            this.btnRecallNotification.Text = "Уведомление\nоб отзыве";
            this.btnRecallNotification.Click += new System.EventHandler(this.btnRecallNotification_Click);
            // 
            // tssAfterSet
            // 
            this.tssAfterSet.Name = "tssAfterSet";
            this.tssAfterSet.Size = new System.Drawing.Size(6, 55);
            // 
            // btnApproveBlock
            // 
            this.btnApproveBlock.Image = global::WMSOffice.Properties.Resources.icon_staff_pick;
            this.btnApproveBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproveBlock.Name = "btnApproveBlock";
            this.btnApproveBlock.Size = new System.Drawing.Size(131, 52);
            this.btnApproveBlock.Text = "Утверждение\nдокументов\n(F8)";
            this.btnApproveBlock.Click += new System.EventHandler(this.btnApproveBlock_Click);
            // 
            // btnItemOffers
            // 
            this.btnItemOffers.Image = global::WMSOffice.Properties.Resources.link;
            this.btnItemOffers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItemOffers.Name = "btnItemOffers";
            this.btnItemOffers.Size = new System.Drawing.Size(101, 52);
            this.btnItemOffers.Text = "Связать\nтовары\n(F9)";
            this.btnItemOffers.ToolTipText = "Предложения найти соответствия между несуществующими товарами и реальным товарами" +
                " в справочнике";
            this.btnItemOffers.Click += new System.EventHandler(this.btnItemOffers_Click);
            // 
            // egvBlocks
            // 
            this.egvBlocks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.egvBlocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.egvBlocks.LargeAmountOfData = false;
            this.egvBlocks.Location = new System.Drawing.Point(0, 0);
            this.egvBlocks.Name = "egvBlocks";
            this.egvBlocks.RowHeadersVisible = false;
            this.egvBlocks.Size = new System.Drawing.Size(1398, 360);
            this.egvBlocks.TabIndex = 2;
            this.egvBlocks.UserID = ((long)(0));
            this.egvBlocks.OnRowSelectionChanged += new System.EventHandler(this.egvBlocks_OnRowSelectionChanged);
            this.egvBlocks.OnRowDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.egvBlocks_OnRowDoubleClick);
            this.egvBlocks.OnDataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.egvBlocks_OnDataBindingComplete);
            // 
            // pbSplashControl
            // 
            this.pbSplashControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSplashControl.Image = ((System.Drawing.Image)(resources.GetObject("pbSplashControl.Image")));
            this.pbSplashControl.Location = new System.Drawing.Point(650, 127);
            this.pbSplashControl.Name = "pbSplashControl";
            this.pbSplashControl.Size = new System.Drawing.Size(104, 104);
            this.pbSplashControl.TabIndex = 3;
            this.pbSplashControl.TabStop = false;
            this.pbSplashControl.Visible = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Controls.Add(this.pbSplashControl);
            this.pnlGrid.Controls.Add(this.egvBlocks);
            this.pnlGrid.Location = new System.Drawing.Point(0, 234);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1398, 360);
            this.pnlGrid.TabIndex = 4;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.grbFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 95);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1398, 133);
            this.pnlFilters.TabIndex = 4;
            // 
            // grbFilters
            // 
            this.grbFilters.Controls.Add(this.tbxDocNumber);
            this.grbFilters.Controls.Add(this.lblDocNumber);
            this.grbFilters.Controls.Add(this.lblExtendedFilterExists);
            this.grbFilters.Controls.Add(this.lblItemName);
            this.grbFilters.Controls.Add(this.ccbWarehouses);
            this.grbFilters.Controls.Add(this.lblWarehouses);
            this.grbFilters.Controls.Add(this.ccbBlockTypes);
            this.grbFilters.Controls.Add(this.lblBlockTypes);
            this.grbFilters.Controls.Add(this.rbtCommitNeeded);
            this.grbFilters.Controls.Add(this.rbtAll);
            this.grbFilters.Controls.Add(this.rbtOnlyActive);
            this.grbFilters.Controls.Add(this.stbBatchId);
            this.grbFilters.Controls.Add(this.lblBatchID);
            this.grbFilters.Controls.Add(this.stbVendorLot);
            this.grbFilters.Controls.Add(this.lblVendorLot);
            this.grbFilters.Controls.Add(this.stbItemID);
            this.grbFilters.Controls.Add(this.lblItemID);
            this.grbFilters.Controls.Add(this.chbDateFrom);
            this.grbFilters.Controls.Add(this.dtpDateTo);
            this.grbFilters.Controls.Add(this.dtpDateFrom);
            this.grbFilters.Controls.Add(this.chbDateTo);
            this.grbFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbFilters.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grbFilters.Location = new System.Drawing.Point(0, 0);
            this.grbFilters.Name = "grbFilters";
            this.grbFilters.Size = new System.Drawing.Size(1398, 133);
            this.grbFilters.TabIndex = 14;
            this.grbFilters.TabStop = false;
            this.grbFilters.Text = "Простой поиск";
            // 
            // tbxDocNumber
            // 
            this.tbxDocNumber.Location = new System.Drawing.Point(761, 81);
            this.tbxDocNumber.Name = "tbxDocNumber";
            this.tbxDocNumber.Size = new System.Drawing.Size(133, 20);
            this.tbxDocNumber.TabIndex = 13;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDocNumber.Location = new System.Drawing.Point(705, 84);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(56, 13);
            this.lblDocNumber.TabIndex = 28;
            this.lblDocNumber.Text = "№ док-та:";
            // 
            // lblExtendedFilterExists
            // 
            this.lblExtendedFilterExists.AutoSize = true;
            this.lblExtendedFilterExists.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblExtendedFilterExists.Location = new System.Drawing.Point(13, 108);
            this.lblExtendedFilterExists.Name = "lblExtendedFilterExists";
            this.lblExtendedFilterExists.Size = new System.Drawing.Size(0, 13);
            this.lblExtendedFilterExists.TabIndex = 27;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemName.Location = new System.Drawing.Point(200, 24);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(101, 13);
            this.lblItemName.TabIndex = 26;
            this.lblItemName.Text = "(Название товара)";
            // 
            // ccbWarehouses
            // 
            this.ccbWarehouses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ccbWarehouses.CheckOnClick = true;
            this.ccbWarehouses.DisplayMember = "Name";
            this.ccbWarehouses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbWarehouses.DropDownHeight = 1;
            this.ccbWarehouses.FormattingEnabled = true;
            this.ccbWarehouses.IntegralHeight = false;
            this.ccbWarehouses.Location = new System.Drawing.Point(761, 52);
            this.ccbWarehouses.MaxDropDownItems = 20;
            this.ccbWarehouses.Name = "ccbWarehouses";
            this.ccbWarehouses.Size = new System.Drawing.Size(625, 21);
            this.ccbWarehouses.TabIndex = 12;
            this.ccbWarehouses.ValueSeparator = ", ";
            // 
            // lblWarehouses
            // 
            this.lblWarehouses.AutoSize = true;
            this.lblWarehouses.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouses.Location = new System.Drawing.Point(706, 55);
            this.lblWarehouses.Name = "lblWarehouses";
            this.lblWarehouses.Size = new System.Drawing.Size(49, 13);
            this.lblWarehouses.TabIndex = 25;
            this.lblWarehouses.Text = "Склады:";
            // 
            // ccbBlockTypes
            // 
            this.ccbBlockTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ccbBlockTypes.CheckOnClick = true;
            this.ccbBlockTypes.DisplayMember = "Name";
            this.ccbBlockTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbBlockTypes.DropDownHeight = 1;
            this.ccbBlockTypes.FormattingEnabled = true;
            this.ccbBlockTypes.IntegralHeight = false;
            this.ccbBlockTypes.Location = new System.Drawing.Point(761, 22);
            this.ccbBlockTypes.MaxDropDownItems = 20;
            this.ccbBlockTypes.Name = "ccbBlockTypes";
            this.ccbBlockTypes.Size = new System.Drawing.Size(625, 21);
            this.ccbBlockTypes.TabIndex = 11;
            this.ccbBlockTypes.ValueSeparator = ", ";
            // 
            // lblBlockTypes
            // 
            this.lblBlockTypes.AutoSize = true;
            this.lblBlockTypes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBlockTypes.Location = new System.Drawing.Point(706, 26);
            this.lblBlockTypes.Name = "lblBlockTypes";
            this.lblBlockTypes.Size = new System.Drawing.Size(37, 13);
            this.lblBlockTypes.TabIndex = 23;
            this.lblBlockTypes.Text = "Типы:";
            // 
            // rbtCommitNeeded
            // 
            this.rbtCommitNeeded.AutoSize = true;
            this.rbtCommitNeeded.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtCommitNeeded.Location = new System.Drawing.Point(487, 53);
            this.rbtCommitNeeded.Name = "rbtCommitNeeded";
            this.rbtCommitNeeded.Size = new System.Drawing.Size(166, 17);
            this.rbtCommitNeeded.TabIndex = 9;
            this.rbtCommitNeeded.Text = "Требующие подтверждения";
            this.rbtCommitNeeded.UseVisualStyleBackColor = true;
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Checked = true;
            this.rbtAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtAll.Location = new System.Drawing.Point(487, 82);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(183, 17);
            this.rbtAll.TabIndex = 10;
            this.rbtAll.TabStop = true;
            this.rbtAll.Text = "И актуальные, и неактуальные";
            this.rbtAll.UseVisualStyleBackColor = true;
            // 
            // rbtOnlyActive
            // 
            this.rbtOnlyActive.AutoSize = true;
            this.rbtOnlyActive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtOnlyActive.Location = new System.Drawing.Point(487, 24);
            this.rbtOnlyActive.Name = "rbtOnlyActive";
            this.rbtOnlyActive.Size = new System.Drawing.Size(188, 17);
            this.rbtOnlyActive.TabIndex = 8;
            this.rbtOnlyActive.Text = "Только актуальные блокировки";
            this.rbtOnlyActive.UseVisualStyleBackColor = true;
            // 
            // stbBatchId
            // 
            this.stbBatchId.Enabled = false;
            this.stbBatchId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbBatchId.Location = new System.Drawing.Point(85, 80);
            this.stbBatchId.Name = "stbBatchId";
            this.stbBatchId.Size = new System.Drawing.Size(114, 23);
            this.stbBatchId.TabIndex = 3;
            this.stbBatchId.UserID = ((long)(0));
            this.stbBatchId.Value = null;
            this.stbBatchId.ValueReferenceQuery = null;
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblBatchID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBatchID.Location = new System.Drawing.Point(12, 84);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(47, 13);
            this.lblBatchID.TabIndex = 18;
            this.lblBatchID.Text = "Партия:";
            // 
            // stbVendorLot
            // 
            this.stbVendorLot.Enabled = false;
            this.stbVendorLot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbVendorLot.Location = new System.Drawing.Point(85, 51);
            this.stbVendorLot.Name = "stbVendorLot";
            this.stbVendorLot.Size = new System.Drawing.Size(114, 23);
            this.stbVendorLot.TabIndex = 2;
            this.stbVendorLot.UserID = ((long)(0));
            this.stbVendorLot.Value = null;
            this.stbVendorLot.ValueReferenceQuery = null;
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVendorLot.Location = new System.Drawing.Point(12, 55);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLot.TabIndex = 16;
            this.lblVendorLot.Text = "Серия:";
            // 
            // stbItemID
            // 
            this.stbItemID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbItemID.Location = new System.Drawing.Point(85, 22);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.Size = new System.Drawing.Size(114, 23);
            this.stbItemID.TabIndex = 1;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemID.Location = new System.Drawing.Point(12, 26);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(67, 13);
            this.lblItemID.TabIndex = 14;
            this.lblItemID.Text = "Код товара:";
            // 
            // chbDateFrom
            // 
            this.chbDateFrom.AutoSize = true;
            this.chbDateFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chbDateFrom.Location = new System.Drawing.Point(242, 52);
            this.chbDateFrom.Name = "chbDateFrom";
            this.chbDateFrom.Size = new System.Drawing.Size(64, 17);
            this.chbDateFrom.TabIndex = 4;
            this.chbDateFrom.Text = "Дата с:";
            this.chbDateFrom.UseVisualStyleBackColor = true;
            this.chbDateFrom.CheckedChanged += new System.EventHandler(this.filter_Changed);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Enabled = false;
            this.dtpDateTo.Location = new System.Drawing.Point(312, 78);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(141, 20);
            this.dtpDateTo.TabIndex = 7;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Enabled = false;
            this.dtpDateFrom.Location = new System.Drawing.Point(312, 49);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(141, 20);
            this.dtpDateFrom.TabIndex = 5;
            // 
            // chbDateTo
            // 
            this.chbDateTo.AutoSize = true;
            this.chbDateTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chbDateTo.Location = new System.Drawing.Point(242, 81);
            this.chbDateTo.Name = "chbDateTo";
            this.chbDateTo.Size = new System.Drawing.Size(70, 17);
            this.chbDateTo.TabIndex = 6;
            this.chbDateTo.Text = "Дата по:";
            this.chbDateTo.UseVisualStyleBackColor = true;
            this.chbDateTo.CheckedChanged += new System.EventHandler(this.filter_Changed);
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // QualityBlocksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 594);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.tsDocs);
            this.KeyPreview = true;
            this.Name = "QualityBlocksWindow";
            this.Text = "Блокировки";
            this.Load += new System.EventHandler(this.QualityBlocksWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityBlocksWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QualityBlocksWindow_KeyDown);
            this.Controls.SetChildIndex(this.tsDocs, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.tsDocs.ResumeLayout(false);
            this.tsDocs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.grbFilters.ResumeLayout(false);
            this.grbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDocs;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView egvBlocks;
        private System.ComponentModel.BackgroundWorker bgwBlocksLoader;
        private System.Windows.Forms.PictureBox pbSplashControl;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ToolStripButton btnCancelLoading;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.CheckBox chbDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.CheckBox chbDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.GroupBox grbFilters;
        private System.Windows.Forms.Label lblItemID;
        private WMSOffice.Controls.SearchTextBox stbVendorLot;
        private System.Windows.Forms.Label lblVendorLot;
        private WMSOffice.Controls.SearchTextBox stbItemID;
        private WMSOffice.Controls.SearchTextBox stbBatchId;
        private System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.RadioButton rbtCommitNeeded;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.RadioButton rbtOnlyActive;
        private WMSOffice.Controls.CheckedComboBox ccbWarehouses;
        private System.Windows.Forms.Label lblWarehouses;
        private WMSOffice.Controls.CheckedComboBox ccbBlockTypes;
        private System.Windows.Forms.Label lblBlockTypes;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.ToolStripSeparator tssAfterExcel;
        private System.Windows.Forms.ToolStripButton btnCreateBlockForRows;
        private System.Windows.Forms.Label lblExtendedFilterExists;
        private System.Windows.Forms.ToolStripButton btnCreateExceptionForRows;
        private System.Windows.Forms.ToolStripButton btnApproveBlock;
        private System.Windows.Forms.ToolStripButton btnItemOffers;
        private System.Windows.Forms.ToolStripButton btnCreateExceptionDoc;
        private System.Windows.Forms.ToolStripButton btnCreateBlockDoc;
        private System.Windows.Forms.ToolStripButton btnFinishBlockDoc;
        private System.Windows.Forms.ToolStripButton btnFinishBlockForRows;
        private System.Windows.Forms.ToolStripSeparator tssAfterSet;
        private System.Windows.Forms.ToolStripButton btnRecallNotification;
        private System.Windows.Forms.TextBox tbxDocNumber;
        private System.Windows.Forms.Label lblDocNumber;
    }
}