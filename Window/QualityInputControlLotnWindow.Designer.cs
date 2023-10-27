namespace WMSOffice.Window
{
    partial class QualityInputControlLotnWindow
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
            this.spcTables = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbOrderCertDataInput = new System.Windows.Forms.CheckBox();
            this.chbOrderNotAccepted = new System.Windows.Forms.CheckBox();
            this.chbOrderInWork = new System.Windows.Forms.CheckBox();
            this.chbOrderAccepted = new System.Windows.Forms.CheckBox();
            this.chbOrderNew = new System.Windows.Forms.CheckBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefreshhOrder = new System.Windows.Forms.ToolStripButton();
            this.btnOrderSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.edgOrders = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.edgWorksheets = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlStatusFilters = new System.Windows.Forms.Panel();
            this.chbSheetCertDataInput = new System.Windows.Forms.CheckBox();
            this.chbSheetNotAccepted = new System.Windows.Forms.CheckBox();
            this.chbSheetAccepted = new System.Windows.Forms.CheckBox();
            this.chbSheetInWork = new System.Windows.Forms.CheckBox();
            this.chbSheetNew = new System.Windows.Forms.CheckBox();
            this.tsDocVersions = new System.Windows.Forms.ToolStrip();
            this.btnRefreshDetails = new System.Windows.Forms.ToolStripButton();
            this.btnSearchWorksheet = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditWorksheet = new System.Windows.Forms.ToolStripButton();
            this.tssAfterEdit = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewWorksheet = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.btnPrintWorksheet = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.cmsOrders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.miCancelLoading = new System.Windows.Forms.ToolStripMenuItem();
            this.bsAtDocVersions = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.bgwLoader = new System.ComponentModel.BackgroundWorker();
            this.taAtDocVersions = new WMSOffice.Data.QualityTableAdapters.AT_Doc_VersionsTableAdapter();
            this.bgwWsLoader = new System.ComponentModel.BackgroundWorker();
            this.wF_GetItem_RemainsTableAdapter1 = new WMSOffice.Data.WHTableAdapters.WF_GetItem_RemainsTableAdapter();
            this.spcTables.Panel1.SuspendLayout();
            this.spcTables.Panel2.SuspendLayout();
            this.spcTables.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.pnlStatusFilters.SuspendLayout();
            this.tsDocVersions.SuspendLayout();
            this.cmsOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtDocVersions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // spcTables
            // 
            this.spcTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcTables.Location = new System.Drawing.Point(0, 46);
            this.spcTables.Name = "spcTables";
            this.spcTables.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcTables.Panel1
            // 
            this.spcTables.Panel1.Controls.Add(this.panel1);
            this.spcTables.Panel1.Controls.Add(this.tsMain);
            this.spcTables.Panel1.Controls.Add(this.edgOrders);
            // 
            // spcTables.Panel2
            // 
            this.spcTables.Panel2.Controls.Add(this.edgWorksheets);
            this.spcTables.Panel2.Controls.Add(this.pnlStatusFilters);
            this.spcTables.Panel2.Controls.Add(this.tsDocVersions);
            this.spcTables.Size = new System.Drawing.Size(1126, 639);
            this.spcTables.SplitterDistance = 341;
            this.spcTables.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbOrderCertDataInput);
            this.panel1.Controls.Add(this.chbOrderNotAccepted);
            this.panel1.Controls.Add(this.chbOrderInWork);
            this.panel1.Controls.Add(this.chbOrderAccepted);
            this.panel1.Controls.Add(this.chbOrderNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 35);
            this.panel1.TabIndex = 41;
            // 
            // chbOrderCertDataInput
            // 
            this.chbOrderCertDataInput.AutoSize = true;
            this.chbOrderCertDataInput.Location = new System.Drawing.Point(467, 13);
            this.chbOrderCertDataInput.Name = "chbOrderCertDataInput";
            this.chbOrderCertDataInput.Size = new System.Drawing.Size(160, 17);
            this.chbOrderCertDataInput.TabIndex = 15;
            this.chbOrderCertDataInput.Text = "Ввод данных сертификата";
            this.chbOrderCertDataInput.UseVisualStyleBackColor = true;
            this.chbOrderCertDataInput.CheckedChanged += new System.EventHandler(this.chbOrderStatus_CheckedChanged);
            // 
            // chbOrderNotAccepted
            // 
            this.chbOrderNotAccepted.AutoSize = true;
            this.chbOrderNotAccepted.Location = new System.Drawing.Point(322, 13);
            this.chbOrderNotAccepted.Name = "chbOrderNotAccepted";
            this.chbOrderNotAccepted.Size = new System.Drawing.Size(139, 17);
            this.chbOrderNotAccepted.TabIndex = 14;
            this.chbOrderNotAccepted.Text = "Обработан неуспешно";
            this.chbOrderNotAccepted.UseVisualStyleBackColor = true;
            this.chbOrderNotAccepted.CheckedChanged += new System.EventHandler(this.chbOrderStatus_CheckedChanged);
            // 
            // chbOrderInWork
            // 
            this.chbOrderInWork.AutoSize = true;
            this.chbOrderInWork.Checked = true;
            this.chbOrderInWork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOrderInWork.Location = new System.Drawing.Point(94, 13);
            this.chbOrderInWork.Name = "chbOrderInWork";
            this.chbOrderInWork.Size = new System.Drawing.Size(71, 17);
            this.chbOrderInWork.TabIndex = 12;
            this.chbOrderInWork.Text = "В работе";
            this.chbOrderInWork.UseVisualStyleBackColor = true;
            this.chbOrderInWork.CheckedChanged += new System.EventHandler(this.chbOrderStatus_CheckedChanged);
            // 
            // chbOrderAccepted
            // 
            this.chbOrderAccepted.AutoSize = true;
            this.chbOrderAccepted.Location = new System.Drawing.Point(189, 13);
            this.chbOrderAccepted.Name = "chbOrderAccepted";
            this.chbOrderAccepted.Size = new System.Drawing.Size(127, 17);
            this.chbOrderAccepted.TabIndex = 13;
            this.chbOrderAccepted.Text = "Обработан успешно";
            this.chbOrderAccepted.UseVisualStyleBackColor = true;
            this.chbOrderAccepted.CheckedChanged += new System.EventHandler(this.chbOrderStatus_CheckedChanged);
            // 
            // chbOrderNew
            // 
            this.chbOrderNew.AutoSize = true;
            this.chbOrderNew.Checked = true;
            this.chbOrderNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOrderNew.Location = new System.Drawing.Point(12, 13);
            this.chbOrderNew.Name = "chbOrderNew";
            this.chbOrderNew.Size = new System.Drawing.Size(60, 17);
            this.chbOrderNew.TabIndex = 11;
            this.chbOrderNew.Text = "Новый";
            this.chbOrderNew.UseVisualStyleBackColor = true;
            this.chbOrderNew.CheckedChanged += new System.EventHandler(this.chbOrderStatus_CheckedChanged);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshhOrder,
            this.btnOrderSearch,
            this.toolStripSeparator1,
            this.toolStripButton3});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1126, 55);
            this.tsMain.TabIndex = 21;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefreshhOrder
            // 
            this.btnRefreshhOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshhOrder.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshhOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshhOrder.Name = "btnRefreshhOrder";
            this.btnRefreshhOrder.Size = new System.Drawing.Size(52, 52);
            this.btnRefreshhOrder.Text = "toolStripButton1";
            this.btnRefreshhOrder.Click += new System.EventHandler(this.btnRefreshhOrder_Click);
            // 
            // btnOrderSearch
            // 
            this.btnOrderSearch.Image = global::WMSOffice.Properties.Resources.find;
            this.btnOrderSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderSearch.Name = "btnOrderSearch";
            this.btnOrderSearch.Size = new System.Drawing.Size(89, 52);
            this.btnOrderSearch.Text = "Поиск";
            this.btnOrderSearch.Click += new System.EventHandler(this.btnOrderSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::WMSOffice.Properties.Resources.Excel;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(101, 52);
            this.toolStripButton3.Text = "Экспорт\nв Excel";
            // 
            // edgOrders
            // 
            this.edgOrders.AllowSort = true;
            this.edgOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.edgOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edgOrders.LargeAmountOfData = true;
            this.edgOrders.Location = new System.Drawing.Point(0, 0);
            this.edgOrders.Name = "edgOrders";
            this.edgOrders.RowHeadersVisible = false;
            this.edgOrders.Size = new System.Drawing.Size(1126, 341);
            this.edgOrders.TabIndex = 20;
            this.edgOrders.UserID = ((long)(0));
            this.edgOrders.OnRowSelectionChanged += new System.EventHandler(this.edgOrders_SelectionChanged);
            this.edgOrders.OnFilterChanged += new System.EventHandler(this.edgOrders_OnFilterChanged);
            this.edgOrders.OnDataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.edgOrders_OnDataBindingComplete);
            // 
            // edgWorksheets
            // 
            this.edgWorksheets.AllowSort = true;
            this.edgWorksheets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.edgWorksheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edgWorksheets.LargeAmountOfData = false;
            this.edgWorksheets.Location = new System.Drawing.Point(0, 72);
            this.edgWorksheets.Name = "edgWorksheets";
            this.edgWorksheets.RowHeadersVisible = false;
            this.edgWorksheets.Size = new System.Drawing.Size(1126, 222);
            this.edgWorksheets.TabIndex = 41;
            this.edgWorksheets.UserID = ((long)(0));
            this.edgWorksheets.OnRowSelectionChanged += new System.EventHandler(this.edgWorksheets_SelectionChanged);
            this.edgWorksheets.OnFormattingCell += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.edgWorksheets_OnFormattingCell);
            this.edgWorksheets.OnFilterChanged += new System.EventHandler(this.edgWorksheets_OnFilterChanged);
            this.edgWorksheets.OnRowDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.edgWorksheets_OnRowDoubleClick);
            this.edgWorksheets.OnDataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.edgWorksheets_OnDataBindingComplete);
            // 
            // pnlStatusFilters
            // 
            this.pnlStatusFilters.Controls.Add(this.chbSheetCertDataInput);
            this.pnlStatusFilters.Controls.Add(this.chbSheetNotAccepted);
            this.pnlStatusFilters.Controls.Add(this.chbSheetAccepted);
            this.pnlStatusFilters.Controls.Add(this.chbSheetInWork);
            this.pnlStatusFilters.Controls.Add(this.chbSheetNew);
            this.pnlStatusFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusFilters.Location = new System.Drawing.Point(0, 39);
            this.pnlStatusFilters.Name = "pnlStatusFilters";
            this.pnlStatusFilters.Size = new System.Drawing.Size(1126, 33);
            this.pnlStatusFilters.TabIndex = 40;
            this.pnlStatusFilters.Visible = false;
            // 
            // chbSheetCertDataInput
            // 
            this.chbSheetCertDataInput.AutoSize = true;
            this.chbSheetCertDataInput.Location = new System.Drawing.Point(515, 9);
            this.chbSheetCertDataInput.Name = "chbSheetCertDataInput";
            this.chbSheetCertDataInput.Size = new System.Drawing.Size(160, 17);
            this.chbSheetCertDataInput.TabIndex = 47;
            this.chbSheetCertDataInput.Text = "Ввод данных сертификата";
            this.chbSheetCertDataInput.UseVisualStyleBackColor = true;
            this.chbSheetCertDataInput.CheckedChanged += new System.EventHandler(this.chbSheetStatus_CheckedChanged);
            // 
            // chbSheetNotAccepted
            // 
            this.chbSheetNotAccepted.AutoSize = true;
            this.chbSheetNotAccepted.Location = new System.Drawing.Point(346, 9);
            this.chbSheetNotAccepted.Name = "chbSheetNotAccepted";
            this.chbSheetNotAccepted.Size = new System.Drawing.Size(145, 17);
            this.chbSheetNotAccepted.TabIndex = 44;
            this.chbSheetNotAccepted.Text = "Обработана неуспешно";
            this.chbSheetNotAccepted.UseVisualStyleBackColor = true;
            this.chbSheetNotAccepted.CheckedChanged += new System.EventHandler(this.chbSheetStatus_CheckedChanged);
            // 
            // chbSheetAccepted
            // 
            this.chbSheetAccepted.AutoSize = true;
            this.chbSheetAccepted.Location = new System.Drawing.Point(189, 9);
            this.chbSheetAccepted.Name = "chbSheetAccepted";
            this.chbSheetAccepted.Size = new System.Drawing.Size(133, 17);
            this.chbSheetAccepted.TabIndex = 43;
            this.chbSheetAccepted.Text = "Обработана успешно";
            this.chbSheetAccepted.UseVisualStyleBackColor = true;
            this.chbSheetAccepted.CheckedChanged += new System.EventHandler(this.chbSheetStatus_CheckedChanged);
            // 
            // chbSheetInWork
            // 
            this.chbSheetInWork.AutoSize = true;
            this.chbSheetInWork.Checked = true;
            this.chbSheetInWork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSheetInWork.Location = new System.Drawing.Point(94, 9);
            this.chbSheetInWork.Name = "chbSheetInWork";
            this.chbSheetInWork.Size = new System.Drawing.Size(71, 17);
            this.chbSheetInWork.TabIndex = 42;
            this.chbSheetInWork.Text = "В работе";
            this.chbSheetInWork.UseVisualStyleBackColor = true;
            this.chbSheetInWork.CheckedChanged += new System.EventHandler(this.chbSheetStatus_CheckedChanged);
            // 
            // chbSheetNew
            // 
            this.chbSheetNew.AutoSize = true;
            this.chbSheetNew.Checked = true;
            this.chbSheetNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSheetNew.Location = new System.Drawing.Point(12, 9);
            this.chbSheetNew.Name = "chbSheetNew";
            this.chbSheetNew.Size = new System.Drawing.Size(58, 17);
            this.chbSheetNew.TabIndex = 41;
            this.chbSheetNew.Text = "Новая";
            this.chbSheetNew.UseVisualStyleBackColor = true;
            this.chbSheetNew.CheckedChanged += new System.EventHandler(this.chbSheetStatus_CheckedChanged);
            // 
            // tsDocVersions
            // 
            this.tsDocVersions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsDocVersions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshDetails,
            this.btnSearchWorksheet,
            this.tssAfterRefresh,
            this.btnEditWorksheet,
            this.tssAfterEdit,
            this.btnViewWorksheet,
            this.cmbPrinters,
            this.btnPrintWorksheet,
            this.btnExportToExcel});
            this.tsDocVersions.Location = new System.Drawing.Point(0, 0);
            this.tsDocVersions.Name = "tsDocVersions";
            this.tsDocVersions.Size = new System.Drawing.Size(1126, 39);
            this.tsDocVersions.TabIndex = 30;
            this.tsDocVersions.Text = "Панель инструментов анкет входного контроля партии";
            // 
            // btnRefreshDetails
            // 
            this.btnRefreshDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshDetails.Image = global::WMSOffice.Properties.Resources.Refresh2;
            this.btnRefreshDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshDetails.Name = "btnRefreshDetails";
            this.btnRefreshDetails.Size = new System.Drawing.Size(36, 36);
            this.btnRefreshDetails.ToolTipText = "Обновить анкеты входного контроля по выбранному заказу на закупку";
            this.btnRefreshDetails.Click += new System.EventHandler(this.btnRefreshDetails_Click);
            // 
            // btnSearchWorksheet
            // 
            this.btnSearchWorksheet.Image = global::WMSOffice.Properties.Resources.find;
            this.btnSearchWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchWorksheet.Name = "btnSearchWorksheet";
            this.btnSearchWorksheet.Size = new System.Drawing.Size(106, 36);
            this.btnSearchWorksheet.Text = "Поиск анкет";
            this.btnSearchWorksheet.Click += new System.EventHandler(this.btnSearchWorksheet_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 39);
            // 
            // btnEditWorksheet
            // 
            this.btnEditWorksheet.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditWorksheet.Name = "btnEditWorksheet";
            this.btnEditWorksheet.Size = new System.Drawing.Size(120, 36);
            this.btnEditWorksheet.Text = "Внести данные";
            this.btnEditWorksheet.ToolTipText = "Запуск окна редактирования выбранной анкеты входного контроля партии";
            this.btnEditWorksheet.Click += new System.EventHandler(this.btnEditWorksheet_Click);
            // 
            // tssAfterEdit
            // 
            this.tssAfterEdit.Name = "tssAfterEdit";
            this.tssAfterEdit.Size = new System.Drawing.Size(6, 39);
            // 
            // btnViewWorksheet
            // 
            this.btnViewWorksheet.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnViewWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewWorksheet.Name = "btnViewWorksheet";
            this.btnViewWorksheet.Size = new System.Drawing.Size(132, 36);
            this.btnViewWorksheet.Text = "Просмотр анкеты";
            this.btnViewWorksheet.ToolTipText = "Просмотреть анкету входного контроля партии, выбранную в таблице";
            this.btnViewWorksheet.Click += new System.EventHandler(this.btnViewWorksheet_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 39);
            // 
            // btnPrintWorksheet
            // 
            this.btnPrintWorksheet.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintWorksheet.Name = "btnPrintWorksheet";
            this.btnPrintWorksheet.Size = new System.Drawing.Size(121, 36);
            this.btnPrintWorksheet.Text = "Печать анкеты";
            this.btnPrintWorksheet.Click += new System.EventHandler(this.btnPrintWorksheet_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(122, 36);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Visible = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // cmsOrders
            // 
            this.cmsOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.miCancelLoading});
            this.cmsOrders.Name = "cmsOrders";
            this.cmsOrders.Size = new System.Drawing.Size(216, 48);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(215, 22);
            this.miRefresh.Text = "Обновить заказы";
            this.miRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // miCancelLoading
            // 
            this.miCancelLoading.Enabled = false;
            this.miCancelLoading.Image = global::WMSOffice.Properties.Resources.cancel;
            this.miCancelLoading.Name = "miCancelLoading";
            this.miCancelLoading.Size = new System.Drawing.Size(215, 22);
            this.miCancelLoading.Text = "Отменить загрузку заказов";
            this.miCancelLoading.Click += new System.EventHandler(this.CancelLoading_Click);
            // 
            // bsAtDocVersions
            // 
            this.bsAtDocVersions.DataMember = "AT_Doc_Versions";
            this.bsAtDocVersions.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taAtDocVersions
            // 
            this.taAtDocVersions.ClearBeforeFill = true;
            // 
            // wF_GetItem_RemainsTableAdapter1
            // 
            this.wF_GetItem_RemainsTableAdapter1.ClearBeforeFill = true;
            // 
            // QualityInputControlLotnWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 685);
            this.ContextMenuStrip = this.cmsOrders;
            this.Controls.Add(this.spcTables);
            this.Name = "QualityInputControlLotnWindow";
            this.Text = "Входной контроль партии";
            this.Load += new System.EventHandler(this.QualityInputControlLotnWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityInputControlLotnWindow_FormClosing);
            this.Controls.SetChildIndex(this.spcTables, 0);
            this.spcTables.Panel1.ResumeLayout(false);
            this.spcTables.Panel1.PerformLayout();
            this.spcTables.Panel2.ResumeLayout(false);
            this.spcTables.Panel2.PerformLayout();
            this.spcTables.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlStatusFilters.ResumeLayout(false);
            this.pnlStatusFilters.PerformLayout();
            this.tsDocVersions.ResumeLayout(false);
            this.tsDocVersions.PerformLayout();
            this.cmsOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAtDocVersions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcTables;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView edgOrders;
        private System.Windows.Forms.ContextMenuStrip cmsOrders;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripMenuItem miCancelLoading;
        private System.ComponentModel.BackgroundWorker bgwLoader;
        private System.Windows.Forms.ToolStrip tsDocVersions;
        private System.Windows.Forms.ToolStripButton btnRefreshDetails;
        private System.Windows.Forms.BindingSource bsAtDocVersions;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.AT_Doc_VersionsTableAdapter taAtDocVersions;
        private System.Windows.Forms.Panel pnlStatusFilters;
        private System.Windows.Forms.CheckBox chbSheetNew;
        private System.Windows.Forms.CheckBox chbSheetInWork;
        private System.Windows.Forms.CheckBox chbSheetNotAccepted;
        private System.Windows.Forms.CheckBox chbSheetAccepted;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.ToolStripButton btnViewWorksheet;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripButton btnPrintWorksheet;
        private System.Windows.Forms.ToolStripButton btnEditWorksheet;
        private System.Windows.Forms.ToolStripSeparator tssAfterEdit;
        private System.Windows.Forms.ToolStripButton btnSearchWorksheet;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView edgWorksheets;
        private System.ComponentModel.BackgroundWorker bgwWsLoader;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.CheckBox chbSheetCertDataInput;
        private WMSOffice.Data.WHTableAdapters.WF_GetItem_RemainsTableAdapter wF_GetItem_RemainsTableAdapter1;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefreshhOrder;
        private System.Windows.Forms.ToolStripButton btnOrderSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbOrderNotAccepted;
        private System.Windows.Forms.CheckBox chbOrderInWork;
        private System.Windows.Forms.CheckBox chbOrderAccepted;
        private System.Windows.Forms.CheckBox chbOrderNew;
        public System.Windows.Forms.CheckBox chbOrderCertDataInput;

    }
}