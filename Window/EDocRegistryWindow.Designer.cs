namespace WMSOffice.Window
{
    partial class EDocRegistryWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnReloadData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportRegistryToExcel = new System.Windows.Forms.ToolStripButton();
            this.tssExportArchive = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportArchive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.btnExportToPDF = new System.Windows.Forms.ToolStripButton();
            this.btnExportToDisk = new System.Windows.Forms.ToolStripButton();
            this.tssOutgoingDocumentActions = new System.Windows.Forms.ToolStripSeparator();
            this.btnCheckState = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnResend = new System.Windows.Forms.ToolStripButton();
            this.tssIncomeDocumentActions = new System.Windows.Forms.ToolStripSeparator();
            this.btnAccept = new System.Windows.Forms.ToolStripButton();
            this.btnDecline = new System.Windows.Forms.ToolStripButton();
            this.btnChangeView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tssWaybillActions = new System.Windows.Forms.ToolStripSeparator();
            this.btnSignWaybill = new System.Windows.Forms.ToolStripButton();
            this.btnCreateWaybillAct = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scDocs = new System.Windows.Forms.SplitContainer();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.scDocDetails = new System.Windows.Forms.SplitContainer();
            this.dgvDocDetail = new System.Windows.Forms.DataGridView();
            this.haveReceiptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDescrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insDTTMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eNDocStatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.printNakl = new WMSOffice.Data.PrintNakl();
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tbEDocStateTo = new System.Windows.Forms.TextBox();
            this.stbEDocStateTo = new WMSOffice.Controls.SearchTextBox();
            this.lblEDocStateTo = new System.Windows.Forms.Label();
            this.lblUseExtraSearch = new System.Windows.Forms.Label();
            this.pnlExtraSearch = new System.Windows.Forms.Panel();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.stbDocType = new WMSOffice.Controls.SearchTextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.cbUseExtraSearch = new System.Windows.Forms.CheckBox();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.tbEDocStateFrom = new System.Windows.Forms.TextBox();
            this.stbEDocStateFrom = new WMSOffice.Controls.SearchTextBox();
            this.lblEDocStateFrom = new System.Windows.Forms.Label();
            this.tbDebtor = new System.Windows.Forms.TextBox();
            this.tbEDocType = new System.Windows.Forms.TextBox();
            this.stbDebtor = new WMSOffice.Controls.SearchTextBox();
            this.lblDebtor = new System.Windows.Forms.Label();
            this.lblEDocType = new System.Windows.Forms.Label();
            this.stbEDocType = new WMSOffice.Controls.SearchTextBox();
            this.eN_DocStatesTableAdapter = new WMSOffice.Data.PrintNaklTableAdapters.EN_DocStatesTableAdapter();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scDocs.Panel1.SuspendLayout();
            this.scDocs.Panel2.SuspendLayout();
            this.scDocs.SuspendLayout();
            this.scDocDetails.Panel1.SuspendLayout();
            this.scDocDetails.Panel2.SuspendLayout();
            this.scDocDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNDocStatesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNakl)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlExtraSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadData,
            this.toolStripSeparator3,
            this.btnExportRegistryToExcel,
            this.tssExportArchive,
            this.btnExportArchive,
            this.toolStripSeparator1,
            this.btnPreview,
            this.btnExportToPDF,
            this.btnExportToDisk,
            this.tssOutgoingDocumentActions,
            this.btnCheckState,
            this.btnCancel,
            this.btnResend,
            this.tssIncomeDocumentActions,
            this.btnAccept,
            this.btnDecline,
            this.btnChangeView,
            this.toolStripSeparator2,
            this.tssWaybillActions,
            this.btnSignWaybill,
            this.btnCreateWaybillAct});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1627, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnReloadData
            // 
            this.btnReloadData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnReloadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(109, 52);
            this.btnReloadData.Text = "Обновить";
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportRegistryToExcel
            // 
            this.btnExportRegistryToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportRegistryToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportRegistryToExcel.Name = "btnExportRegistryToExcel";
            this.btnExportRegistryToExcel.Size = new System.Drawing.Size(101, 52);
            this.btnExportRegistryToExcel.Text = "Экспорт\n в Excel";
            this.btnExportRegistryToExcel.Click += new System.EventHandler(this.btnExportRegistryToExcel_Click);
            // 
            // tssExportArchive
            // 
            this.tssExportArchive.Name = "tssExportArchive";
            this.tssExportArchive.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportArchive
            // 
            this.btnExportArchive.Image = global::WMSOffice.Properties.Resources.books;
            this.btnExportArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportArchive.Name = "btnExportArchive";
            this.btnExportArchive.Size = new System.Drawing.Size(140, 52);
            this.btnExportArchive.Text = "Экспорт архива\nдокументов";
            this.btnExportArchive.Click += new System.EventHandler(this.btnExportArchive_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::WMSOffice.Properties.Resources.preview;
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(114, 52);
            this.btnPreview.Text = "Просмотр\nдокумента";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.btnExportToPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(145, 52);
            this.btnExportToPDF.Text = "Экспорт\nдокумента в PDF";
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // btnExportToDisk
            // 
            this.btnExportToDisk.Image = global::WMSOffice.Properties.Resources.document_certificate;
            this.btnExportToDisk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToDisk.Name = "btnExportToDisk";
            this.btnExportToDisk.Size = new System.Drawing.Size(153, 52);
            this.btnExportToDisk.Text = "Экспорт пакета\nдокументов с ЭЦП";
            this.btnExportToDisk.Click += new System.EventHandler(this.btnExportToDisk_Click);
            // 
            // tssOutgoingDocumentActions
            // 
            this.tssOutgoingDocumentActions.Name = "tssOutgoingDocumentActions";
            this.tssOutgoingDocumentActions.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCheckState
            // 
            this.btnCheckState.Image = global::WMSOffice.Properties.Resources.checklist;
            this.btnCheckState.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheckState.Name = "btnCheckState";
            this.btnCheckState.Size = new System.Drawing.Size(114, 52);
            this.btnCheckState.Text = "Проверить\nстатус\nдокумента";
            this.btnCheckState.Click += new System.EventHandler(this.btnCheckState_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 52);
            this.btnCancel.Text = "Аннулировать\nдокумент";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResend
            // 
            this.btnResend.Image = global::WMSOffice.Properties.Resources.upgrade;
            this.btnResend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(115, 52);
            this.btnResend.Text = "Отправить\nповторно";
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // tssIncomeDocumentActions
            // 
            this.tssIncomeDocumentActions.Name = "tssIncomeDocumentActions";
            this.tssIncomeDocumentActions.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAccept
            // 
            this.btnAccept.Image = global::WMSOffice.Properties.Resources.ok;
            this.btnAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(114, 52);
            this.btnAccept.Text = "Направить\nв работу";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnDecline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(115, 52);
            this.btnDecline.Text = "Отклонить\nдокумент";
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnChangeView
            // 
            this.btnChangeView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnChangeView.Image = global::WMSOffice.Properties.Resources.settings;
            this.btnChangeView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(107, 52);
            this.btnChangeView.Text = "Изменить\nрежим\nработы";
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // tssWaybillActions
            // 
            this.tssWaybillActions.Name = "tssWaybillActions";
            this.tssWaybillActions.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSignWaybill
            // 
            this.btnSignWaybill.Image = global::WMSOffice.Properties.Resources.ok;
            this.btnSignWaybill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSignWaybill.Name = "btnSignWaybill";
            this.btnSignWaybill.Size = new System.Drawing.Size(114, 52);
            this.btnSignWaybill.Text = "Подписать\ne-ТТН";
            this.btnSignWaybill.Click += new System.EventHandler(this.btnSignWaybill_Click);
            // 
            // btnCreateWaybillAct
            // 
            this.btnCreateWaybillAct.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCreateWaybillAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateWaybillAct.Name = "btnCreateWaybillAct";
            this.btnCreateWaybillAct.Size = new System.Drawing.Size(134, 52);
            this.btnCreateWaybillAct.Text = "Сформировать\nАкт";
            this.btnCreateWaybillAct.Click += new System.EventHandler(this.btnCreateWaybillAct_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.scDocs);
            this.pnlContent.Controls.Add(this.pnlSearch);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1627, 466);
            this.pnlContent.TabIndex = 2;
            // 
            // scDocs
            // 
            this.scDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDocs.Location = new System.Drawing.Point(0, 180);
            this.scDocs.Name = "scDocs";
            this.scDocs.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scDocs.Panel1
            // 
            this.scDocs.Panel1.Controls.Add(this.xdgvDocs);
            // 
            // scDocs.Panel2
            // 
            this.scDocs.Panel2.Controls.Add(this.scDocDetails);
            this.scDocs.Size = new System.Drawing.Size(1627, 286);
            this.scDocs.SplitterDistance = 168;
            this.scDocs.TabIndex = 1;
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.AllowSort = true;
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 0);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(1627, 168);
            this.xdgvDocs.TabIndex = 0;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // scDocDetails
            // 
            this.scDocDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDocDetails.Location = new System.Drawing.Point(0, 0);
            this.scDocDetails.Name = "scDocDetails";
            // 
            // scDocDetails.Panel1
            // 
            this.scDocDetails.Panel1.Controls.Add(this.dgvDocDetail);
            // 
            // scDocDetails.Panel2
            // 
            this.scDocDetails.Panel2.Controls.Add(this.rtbReceipt);
            this.scDocDetails.Size = new System.Drawing.Size(1627, 114);
            this.scDocDetails.SplitterDistance = 578;
            this.scDocDetails.TabIndex = 0;
            // 
            // dgvDocDetail
            // 
            this.dgvDocDetail.AllowUserToAddRows = false;
            this.dgvDocDetail.AllowUserToDeleteRows = false;
            this.dgvDocDetail.AllowUserToResizeRows = false;
            this.dgvDocDetail.AutoGenerateColumns = false;
            this.dgvDocDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.haveReceiptDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.stateDescrDataGridViewTextBoxColumn,
            this.insDTTMDataGridViewTextBoxColumn});
            this.dgvDocDetail.DataSource = this.eNDocStatesBindingSource;
            this.dgvDocDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDocDetail.MultiSelect = false;
            this.dgvDocDetail.Name = "dgvDocDetail";
            this.dgvDocDetail.ReadOnly = true;
            this.dgvDocDetail.RowHeadersVisible = false;
            this.dgvDocDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocDetail.Size = new System.Drawing.Size(578, 114);
            this.dgvDocDetail.TabIndex = 0;
            this.dgvDocDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocDetail_DataBindingComplete);
            this.dgvDocDetail.SelectionChanged += new System.EventHandler(this.dgvDocDetail_SelectionChanged);
            // 
            // haveReceiptDataGridViewTextBoxColumn
            // 
            this.haveReceiptDataGridViewTextBoxColumn.HeaderText = "";
            this.haveReceiptDataGridViewTextBoxColumn.Name = "haveReceiptDataGridViewTextBoxColumn";
            this.haveReceiptDataGridViewTextBoxColumn.ReadOnly = true;
            this.haveReceiptDataGridViewTextBoxColumn.Width = 40;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State_ID";
            this.stateDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stateDataGridViewTextBoxColumn.Width = 80;
            // 
            // stateDescrDataGridViewTextBoxColumn
            // 
            this.stateDescrDataGridViewTextBoxColumn.DataPropertyName = "State_Descr";
            this.stateDescrDataGridViewTextBoxColumn.HeaderText = "Описание статуса";
            this.stateDescrDataGridViewTextBoxColumn.Name = "stateDescrDataGridViewTextBoxColumn";
            this.stateDescrDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateDescrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stateDescrDataGridViewTextBoxColumn.Width = 250;
            // 
            // insDTTMDataGridViewTextBoxColumn
            // 
            this.insDTTMDataGridViewTextBoxColumn.DataPropertyName = "Ins_DTTM";
            this.insDTTMDataGridViewTextBoxColumn.HeaderText = "Время перехода";
            this.insDTTMDataGridViewTextBoxColumn.Name = "insDTTMDataGridViewTextBoxColumn";
            this.insDTTMDataGridViewTextBoxColumn.ReadOnly = true;
            this.insDTTMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.insDTTMDataGridViewTextBoxColumn.Width = 120;
            // 
            // eNDocStatesBindingSource
            // 
            this.eNDocStatesBindingSource.DataMember = "EN_DocStates";
            this.eNDocStatesBindingSource.DataSource = this.printNakl;
            // 
            // printNakl
            // 
            this.printNakl.DataSetName = "PrintNakl";
            this.printNakl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rtbReceipt
            // 
            this.rtbReceipt.BackColor = System.Drawing.SystemColors.Control;
            this.rtbReceipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbReceipt.Location = new System.Drawing.Point(0, 0);
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.ReadOnly = true;
            this.rtbReceipt.Size = new System.Drawing.Size(1045, 114);
            this.rtbReceipt.TabIndex = 0;
            this.rtbReceipt.Text = "";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tbEDocStateTo);
            this.pnlSearch.Controls.Add(this.stbEDocStateTo);
            this.pnlSearch.Controls.Add(this.lblEDocStateTo);
            this.pnlSearch.Controls.Add(this.lblUseExtraSearch);
            this.pnlSearch.Controls.Add(this.pnlExtraSearch);
            this.pnlSearch.Controls.Add(this.cbUseExtraSearch);
            this.pnlSearch.Controls.Add(this.dtpPeriodTo);
            this.pnlSearch.Controls.Add(this.dtpPeriodFrom);
            this.pnlSearch.Controls.Add(this.lblPeriodTo);
            this.pnlSearch.Controls.Add(this.lblPeriodFrom);
            this.pnlSearch.Controls.Add(this.tbEDocStateFrom);
            this.pnlSearch.Controls.Add(this.stbEDocStateFrom);
            this.pnlSearch.Controls.Add(this.lblEDocStateFrom);
            this.pnlSearch.Controls.Add(this.tbDebtor);
            this.pnlSearch.Controls.Add(this.tbEDocType);
            this.pnlSearch.Controls.Add(this.stbDebtor);
            this.pnlSearch.Controls.Add(this.lblDebtor);
            this.pnlSearch.Controls.Add(this.lblEDocType);
            this.pnlSearch.Controls.Add(this.stbEDocType);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1627, 180);
            this.pnlSearch.TabIndex = 0;
            // 
            // tbEDocStateTo
            // 
            this.tbEDocStateTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbEDocStateTo.Location = new System.Drawing.Point(728, 66);
            this.tbEDocStateTo.Name = "tbEDocStateTo";
            this.tbEDocStateTo.ReadOnly = true;
            this.tbEDocStateTo.Size = new System.Drawing.Size(245, 20);
            this.tbEDocStateTo.TabIndex = 11;
            this.tbEDocStateTo.TabStop = false;
            // 
            // stbEDocStateTo
            // 
            this.stbEDocStateTo.Location = new System.Drawing.Point(620, 66);
            this.stbEDocStateTo.Name = "stbEDocStateTo";
            this.stbEDocStateTo.NavigateByValue = false;
            this.stbEDocStateTo.ReadOnly = false;
            this.stbEDocStateTo.Size = new System.Drawing.Size(100, 20);
            this.stbEDocStateTo.TabIndex = 10;
            this.stbEDocStateTo.UserID = ((long)(0));
            this.stbEDocStateTo.Value = null;
            this.stbEDocStateTo.ValueReferenceQuery = null;
            // 
            // lblEDocStateTo
            // 
            this.lblEDocStateTo.AutoSize = true;
            this.lblEDocStateTo.Location = new System.Drawing.Point(517, 70);
            this.lblEDocStateTo.Name = "lblEDocStateTo";
            this.lblEDocStateTo.Size = new System.Drawing.Size(59, 13);
            this.lblEDocStateTo.TabIndex = 9;
            this.lblEDocStateTo.Text = "Статус по:";
            // 
            // lblUseExtraSearch
            // 
            this.lblUseExtraSearch.AutoSize = true;
            this.lblUseExtraSearch.Location = new System.Drawing.Point(12, 127);
            this.lblUseExtraSearch.Name = "lblUseExtraSearch";
            this.lblUseExtraSearch.Size = new System.Drawing.Size(90, 13);
            this.lblUseExtraSearch.TabIndex = 16;
            this.lblUseExtraSearch.Text = "Дополнительно:";
            this.lblUseExtraSearch.Click += new System.EventHandler(this.lblUseExtraSearch_Click);
            // 
            // pnlExtraSearch
            // 
            this.pnlExtraSearch.Controls.Add(this.tbDocType);
            this.pnlExtraSearch.Controls.Add(this.stbDocType);
            this.pnlExtraSearch.Controls.Add(this.lblDocType);
            this.pnlExtraSearch.Controls.Add(this.tbDocNumber);
            this.pnlExtraSearch.Controls.Add(this.lblDocNumber);
            this.pnlExtraSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlExtraSearch.Location = new System.Drawing.Point(0, 145);
            this.pnlExtraSearch.Name = "pnlExtraSearch";
            this.pnlExtraSearch.Size = new System.Drawing.Size(1627, 35);
            this.pnlExtraSearch.TabIndex = 18;
            // 
            // tbDocType
            // 
            this.tbDocType.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocType.Location = new System.Drawing.Point(223, 8);
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.ReadOnly = true;
            this.tbDocType.Size = new System.Drawing.Size(245, 20);
            this.tbDocType.TabIndex = 2;
            this.tbDocType.TabStop = false;
            // 
            // stbDocType
            // 
            this.stbDocType.Location = new System.Drawing.Point(115, 8);
            this.stbDocType.Name = "stbDocType";
            this.stbDocType.NavigateByValue = false;
            this.stbDocType.ReadOnly = false;
            this.stbDocType.Size = new System.Drawing.Size(100, 20);
            this.stbDocType.TabIndex = 1;
            this.stbDocType.UserID = ((long)(0));
            this.stbDocType.Value = null;
            this.stbDocType.ValueReferenceQuery = null;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(12, 12);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(86, 13);
            this.lblDocType.TabIndex = 0;
            this.lblDocType.Text = "Тип документа:";
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.Location = new System.Drawing.Point(620, 8);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.Size = new System.Drawing.Size(100, 20);
            this.tbDocNumber.TabIndex = 4;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(517, 12);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(78, 13);
            this.lblDocNumber.TabIndex = 3;
            this.lblDocNumber.Text = "№ документа:";
            // 
            // cbUseExtraSearch
            // 
            this.cbUseExtraSearch.AutoSize = true;
            this.cbUseExtraSearch.Location = new System.Drawing.Point(115, 126);
            this.cbUseExtraSearch.Name = "cbUseExtraSearch";
            this.cbUseExtraSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbUseExtraSearch.Size = new System.Drawing.Size(15, 14);
            this.cbUseExtraSearch.TabIndex = 17;
            this.cbUseExtraSearch.UseVisualStyleBackColor = true;
            this.cbUseExtraSearch.CheckedChanged += new System.EventHandler(this.cbUseExtraSearch_CheckedChanged);
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(368, 95);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 15;
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(115, 95);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 13;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(265, 99);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(63, 13);
            this.lblPeriodTo.TabIndex = 14;
            this.lblPeriodTo.Text = "Период по:";
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(12, 99);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(57, 13);
            this.lblPeriodFrom.TabIndex = 12;
            this.lblPeriodFrom.Text = "Период с:";
            // 
            // tbEDocStateFrom
            // 
            this.tbEDocStateFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbEDocStateFrom.Location = new System.Drawing.Point(223, 66);
            this.tbEDocStateFrom.Name = "tbEDocStateFrom";
            this.tbEDocStateFrom.ReadOnly = true;
            this.tbEDocStateFrom.Size = new System.Drawing.Size(245, 20);
            this.tbEDocStateFrom.TabIndex = 8;
            this.tbEDocStateFrom.TabStop = false;
            // 
            // stbEDocStateFrom
            // 
            this.stbEDocStateFrom.Location = new System.Drawing.Point(115, 66);
            this.stbEDocStateFrom.Name = "stbEDocStateFrom";
            this.stbEDocStateFrom.NavigateByValue = false;
            this.stbEDocStateFrom.ReadOnly = false;
            this.stbEDocStateFrom.Size = new System.Drawing.Size(100, 20);
            this.stbEDocStateFrom.TabIndex = 7;
            this.stbEDocStateFrom.UserID = ((long)(0));
            this.stbEDocStateFrom.Value = null;
            this.stbEDocStateFrom.ValueReferenceQuery = null;
            // 
            // lblEDocStateFrom
            // 
            this.lblEDocStateFrom.AutoSize = true;
            this.lblEDocStateFrom.Location = new System.Drawing.Point(12, 70);
            this.lblEDocStateFrom.Name = "lblEDocStateFrom";
            this.lblEDocStateFrom.Size = new System.Drawing.Size(53, 13);
            this.lblEDocStateFrom.TabIndex = 6;
            this.lblEDocStateFrom.Text = "Статус с:";
            // 
            // tbDebtor
            // 
            this.tbDebtor.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtor.Location = new System.Drawing.Point(223, 37);
            this.tbDebtor.Name = "tbDebtor";
            this.tbDebtor.ReadOnly = true;
            this.tbDebtor.Size = new System.Drawing.Size(750, 20);
            this.tbDebtor.TabIndex = 5;
            this.tbDebtor.TabStop = false;
            // 
            // tbEDocType
            // 
            this.tbEDocType.BackColor = System.Drawing.SystemColors.Window;
            this.tbEDocType.Location = new System.Drawing.Point(223, 8);
            this.tbEDocType.Name = "tbEDocType";
            this.tbEDocType.ReadOnly = true;
            this.tbEDocType.Size = new System.Drawing.Size(750, 20);
            this.tbEDocType.TabIndex = 2;
            this.tbEDocType.TabStop = false;
            // 
            // stbDebtor
            // 
            this.stbDebtor.Location = new System.Drawing.Point(115, 37);
            this.stbDebtor.Name = "stbDebtor";
            this.stbDebtor.NavigateByValue = false;
            this.stbDebtor.ReadOnly = false;
            this.stbDebtor.Size = new System.Drawing.Size(100, 20);
            this.stbDebtor.TabIndex = 4;
            this.stbDebtor.UserID = ((long)(0));
            this.stbDebtor.Value = null;
            this.stbDebtor.ValueReferenceQuery = null;
            // 
            // lblDebtor
            // 
            this.lblDebtor.AutoSize = true;
            this.lblDebtor.Location = new System.Drawing.Point(12, 41);
            this.lblDebtor.Name = "lblDebtor";
            this.lblDebtor.Size = new System.Drawing.Size(54, 13);
            this.lblDebtor.TabIndex = 3;
            this.lblDebtor.Text = "Дебитор:";
            // 
            // lblEDocType
            // 
            this.lblEDocType.AutoSize = true;
            this.lblEDocType.Location = new System.Drawing.Point(12, 12);
            this.lblEDocType.Name = "lblEDocType";
            this.lblEDocType.Size = new System.Drawing.Size(95, 13);
            this.lblEDocType.TabIndex = 0;
            this.lblEDocType.Text = "Тип e-документа:";
            // 
            // stbEDocType
            // 
            this.stbEDocType.Location = new System.Drawing.Point(115, 8);
            this.stbEDocType.Name = "stbEDocType";
            this.stbEDocType.NavigateByValue = false;
            this.stbEDocType.ReadOnly = false;
            this.stbEDocType.Size = new System.Drawing.Size(100, 20);
            this.stbEDocType.TabIndex = 1;
            this.stbEDocType.UserID = ((long)(0));
            this.stbEDocType.Value = null;
            this.stbEDocType.ValueReferenceQuery = null;
            // 
            // eN_DocStatesTableAdapter
            // 
            this.eN_DocStatesTableAdapter.ClearBeforeFill = true;
            // 
            // EDocRegistryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 561);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "EDocRegistryWindow";
            this.Text = "EDocRegistryWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EDocRegistryWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.scDocs.Panel1.ResumeLayout(false);
            this.scDocs.Panel2.ResumeLayout(false);
            this.scDocs.ResumeLayout(false);
            this.scDocDetails.Panel1.ResumeLayout(false);
            this.scDocDetails.Panel2.ResumeLayout(false);
            this.scDocDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNDocStatesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNakl)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlExtraSearch.ResumeLayout(false);
            this.pnlExtraSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnReloadData;
        private System.Windows.Forms.ToolStripButton btnExportToPDF;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer scDocs;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.SplitContainer scDocDetails;
        private System.Windows.Forms.ToolStripButton btnExportToDisk;
        private System.Windows.Forms.DataGridView dgvDocDetail;
        private System.Windows.Forms.BindingSource eNDocStatesBindingSource;
        private Data.PrintNakl printNakl;
        private Data.PrintNaklTableAdapters.EN_DocStatesTableAdapter eN_DocStatesTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn haveReceiptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDescrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insDTTMDataGridViewTextBoxColumn;
        private System.Windows.Forms.RichTextBox rtbReceipt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox tbEDocStateFrom;
        private WMSOffice.Controls.SearchTextBox stbEDocStateFrom;
        private System.Windows.Forms.Label lblEDocStateFrom;
        private System.Windows.Forms.TextBox tbDebtor;
        private System.Windows.Forms.TextBox tbEDocType;
        private WMSOffice.Controls.SearchTextBox stbDebtor;
        private System.Windows.Forms.Label lblDebtor;
        private System.Windows.Forms.Label lblEDocType;
        private WMSOffice.Controls.SearchTextBox stbEDocType;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Panel pnlExtraSearch;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.CheckBox cbUseExtraSearch;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblUseExtraSearch;
        private System.Windows.Forms.TextBox tbEDocStateTo;
        private WMSOffice.Controls.SearchTextBox stbEDocStateTo;
        private System.Windows.Forms.Label lblEDocStateTo;
        private System.Windows.Forms.TextBox tbDocType;
        private WMSOffice.Controls.SearchTextBox stbDocType;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripSeparator tssOutgoingDocumentActions;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnExportRegistryToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnResend;
        private System.Windows.Forms.ToolStripButton btnExportArchive;
        private System.Windows.Forms.ToolStripSeparator tssExportArchive;
        private System.Windows.Forms.ToolStripSeparator tssIncomeDocumentActions;
        private System.Windows.Forms.ToolStripButton btnAccept;
        private System.Windows.Forms.ToolStripButton btnDecline;
        private System.Windows.Forms.ToolStripButton btnChangeView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCheckState;
        private System.Windows.Forms.ToolStripSeparator tssWaybillActions;
        private System.Windows.Forms.ToolStripButton btnSignWaybill;
        private System.Windows.Forms.ToolStripButton btnCreateWaybillAct;
    }
}