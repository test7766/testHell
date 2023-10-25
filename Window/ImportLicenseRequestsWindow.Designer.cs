namespace WMSOffice.Window
{
    partial class ImportLicenseRequestsWindow
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
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateRequest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditRequest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportRequestStatement = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetConclusion = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scRequests = new System.Windows.Forms.SplitContainer();
            this.xdgvRequests = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.dgvRequestDetails = new System.Windows.Forms.DataGridView();
            this.cmsRequestDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCreateItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qKLILicRequestDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.stbItem = new WMSOffice.Controls.SearchTextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.tbStatusTo = new System.Windows.Forms.TextBox();
            this.tbStatusFrom = new System.Windows.Forms.TextBox();
            this.stbVendor = new WMSOffice.Controls.SearchTextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.stbStatusTo = new WMSOffice.Controls.SearchTextBox();
            this.lblStatusTo = new System.Windows.Forms.Label();
            this.lblStatusFrom = new System.Windows.Forms.Label();
            this.stbStatusFrom = new WMSOffice.Controls.SearchTextBox();
            this.qK_LI_LicRequest_DetailsTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_LI_LicRequest_DetailsTableAdapter();
            this.dgvcColdType = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MNN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AtcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturerCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEndReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GMPDateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scRequests.Panel1.SuspendLayout();
            this.scRequests.Panel2.SuspendLayout();
            this.scRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestDetails)).BeginInit();
            this.cmsRequestDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qKLILicRequestDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator5,
            this.btnCreateRequest,
            this.toolStripSeparator6,
            this.btnEditRequest,
            this.toolStripSeparator3,
            this.btnExportRequestStatement,
            this.toolStripSeparator2,
            this.btnSetConclusion});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1044, 55);
            this.tsMain.TabIndex = 103;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateRequest
            // 
            this.btnCreateRequest.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnCreateRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateRequest.Name = "btnCreateRequest";
            this.btnCreateRequest.Size = new System.Drawing.Size(132, 52);
            this.btnCreateRequest.Text = "Создать\nуведомление";
            this.btnCreateRequest.Click += new System.EventHandler(this.btnCreateRequest_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // btnEditRequest
            // 
            this.btnEditRequest.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditRequest.Name = "btnEditRequest";
            this.btnEditRequest.Size = new System.Drawing.Size(132, 52);
            this.btnEditRequest.Text = "Изменить\nуведомление";
            this.btnEditRequest.Click += new System.EventHandler(this.btnEditRequest_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportRequestStatement
            // 
            this.btnExportRequestStatement.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportRequestStatement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportRequestStatement.Name = "btnExportRequestStatement";
            this.btnExportRequestStatement.Size = new System.Drawing.Size(132, 52);
            this.btnExportRequestStatement.Text = "Экспорт\nуведомления";
            this.btnExportRequestStatement.Click += new System.EventHandler(this.btnExportRequestStatement_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSetConclusion
            // 
            this.btnSetConclusion.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnSetConclusion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetConclusion.Name = "btnSetConclusion";
            this.btnSetConclusion.Size = new System.Drawing.Size(109, 52);
            this.btnSetConclusion.Text = "Внести\nрешение";
            this.btnSetConclusion.Click += new System.EventHandler(this.btnSetConclusion_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 95);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1044, 347);
            this.pnlMain.TabIndex = 104;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.scRequests);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 125);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1044, 222);
            this.pnlContent.TabIndex = 3;
            // 
            // scRequests
            // 
            this.scRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scRequests.Location = new System.Drawing.Point(0, 0);
            this.scRequests.Name = "scRequests";
            this.scRequests.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scRequests.Panel1
            // 
            this.scRequests.Panel1.Controls.Add(this.xdgvRequests);
            // 
            // scRequests.Panel2
            // 
            this.scRequests.Panel2.Controls.Add(this.dgvRequestDetails);
            this.scRequests.Size = new System.Drawing.Size(1044, 222);
            this.scRequests.SplitterDistance = 132;
            this.scRequests.TabIndex = 2;
            // 
            // xdgvRequests
            // 
            this.xdgvRequests.AllowSort = true;
            this.xdgvRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvRequests.LargeAmountOfData = false;
            this.xdgvRequests.Location = new System.Drawing.Point(0, 0);
            this.xdgvRequests.Name = "xdgvRequests";
            this.xdgvRequests.RowHeadersVisible = false;
            this.xdgvRequests.Size = new System.Drawing.Size(1044, 132);
            this.xdgvRequests.TabIndex = 1;
            this.xdgvRequests.UserID = ((long)(0));
            // 
            // dgvRequestDetails
            // 
            this.dgvRequestDetails.AllowUserToAddRows = false;
            this.dgvRequestDetails.AllowUserToDeleteRows = false;
            this.dgvRequestDetails.AllowUserToResizeRows = false;
            this.dgvRequestDetails.AutoGenerateColumns = false;
            this.dgvRequestDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRequestDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcColdType,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.ReleaseForm,
            this.Dosage,
            this.QtyPack,
            this.MNN,
            this.NoReg,
            this.AtcCode,
            this.manufacturerDataGridViewTextBoxColumn,
            this.ManufacturerCountry,
            this.vendorDataGridViewTextBoxColumn,
            this.VendorCountry,
            this.VendorAddress,
            this.DateEndReg,
            this.GMP,
            this.GMPDateTo});
            this.dgvRequestDetails.ContextMenuStrip = this.cmsRequestDetails;
            this.dgvRequestDetails.DataSource = this.qKLILicRequestDetailsBindingSource;
            this.dgvRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequestDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvRequestDetails.MultiSelect = false;
            this.dgvRequestDetails.Name = "dgvRequestDetails";
            this.dgvRequestDetails.ReadOnly = true;
            this.dgvRequestDetails.RowHeadersVisible = false;
            this.dgvRequestDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequestDetails.Size = new System.Drawing.Size(1044, 86);
            this.dgvRequestDetails.TabIndex = 1;
            this.dgvRequestDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequestDetails_CellDoubleClick);
            this.dgvRequestDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRequestDetails_CellFormatting);
            this.dgvRequestDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRequestDetails_DataBindingComplete);
            this.dgvRequestDetails.SelectionChanged += new System.EventHandler(this.dgvRequestDetails_SelectionChanged);
            // 
            // cmsRequestDetails
            // 
            this.cmsRequestDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateItemCopy,
            this.miDeleteItem});
            this.cmsRequestDetails.Name = "cmsRequestDetails";
            this.cmsRequestDetails.Size = new System.Drawing.Size(284, 48);
            // 
            // miCreateItemCopy
            // 
            this.miCreateItemCopy.Image = global::WMSOffice.Properties.Resources.Apply;
            this.miCreateItemCopy.Name = "miCreateItemCopy";
            this.miCreateItemCopy.Size = new System.Drawing.Size(283, 22);
            this.miCreateItemCopy.Text = "Создать копию товара в уведомлении";
            this.miCreateItemCopy.Click += new System.EventHandler(this.miCreateItemCopy_Click);
            // 
            // miDeleteItem
            // 
            this.miDeleteItem.Image = global::WMSOffice.Properties.Resources.Delete;
            this.miDeleteItem.Name = "miDeleteItem";
            this.miDeleteItem.Size = new System.Drawing.Size(283, 22);
            this.miDeleteItem.Text = "Удалить товар из уведомления";
            this.miDeleteItem.Click += new System.EventHandler(this.miDeleteItem_Click);
            // 
            // qKLILicRequestDetailsBindingSource
            // 
            this.qKLILicRequestDetailsBindingSource.DataMember = "QK_LI_LicRequest_Details";
            this.qKLILicRequestDetailsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.dtpPeriodTo);
            this.pnlFilter.Controls.Add(this.dtpPeriodFrom);
            this.pnlFilter.Controls.Add(this.lblPeriodTo);
            this.pnlFilter.Controls.Add(this.lblPeriodFrom);
            this.pnlFilter.Controls.Add(this.tbItem);
            this.pnlFilter.Controls.Add(this.stbItem);
            this.pnlFilter.Controls.Add(this.lblItem);
            this.pnlFilter.Controls.Add(this.tbVendor);
            this.pnlFilter.Controls.Add(this.tbStatusTo);
            this.pnlFilter.Controls.Add(this.tbStatusFrom);
            this.pnlFilter.Controls.Add(this.stbVendor);
            this.pnlFilter.Controls.Add(this.lblVendor);
            this.pnlFilter.Controls.Add(this.stbStatusTo);
            this.pnlFilter.Controls.Add(this.lblStatusTo);
            this.pnlFilter.Controls.Add(this.lblStatusFrom);
            this.pnlFilter.Controls.Add(this.stbStatusFrom);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1044, 125);
            this.pnlFilter.TabIndex = 2;
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(392, 96);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 15;
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(86, 96);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 13;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(313, 100);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(63, 13);
            this.lblPeriodTo.TabIndex = 14;
            this.lblPeriodTo.Text = "Период по:";
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(13, 100);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(57, 13);
            this.lblPeriodFrom.TabIndex = 12;
            this.lblPeriodFrom.Text = "Период с:";
            // 
            // tbItem
            // 
            this.tbItem.BackColor = System.Drawing.SystemColors.Window;
            this.tbItem.Location = new System.Drawing.Point(192, 38);
            this.tbItem.Name = "tbItem";
            this.tbItem.ReadOnly = true;
            this.tbItem.Size = new System.Drawing.Size(817, 20);
            this.tbItem.TabIndex = 5;
            // 
            // stbItem
            // 
            this.stbItem.Location = new System.Drawing.Point(87, 38);
            this.stbItem.Name = "stbItem";
            this.stbItem.NavigateByValue = false;
            this.stbItem.ReadOnly = false;
            this.stbItem.Size = new System.Drawing.Size(99, 20);
            this.stbItem.TabIndex = 4;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(13, 42);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(41, 13);
            this.lblItem.TabIndex = 3;
            this.lblItem.Text = "Товар:";
            // 
            // tbVendor
            // 
            this.tbVendor.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendor.Location = new System.Drawing.Point(192, 9);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.ReadOnly = true;
            this.tbVendor.Size = new System.Drawing.Size(817, 20);
            this.tbVendor.TabIndex = 2;
            // 
            // tbStatusTo
            // 
            this.tbStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusTo.Location = new System.Drawing.Point(708, 67);
            this.tbStatusTo.Name = "tbStatusTo";
            this.tbStatusTo.ReadOnly = true;
            this.tbStatusTo.Size = new System.Drawing.Size(300, 20);
            this.tbStatusTo.TabIndex = 11;
            // 
            // tbStatusFrom
            // 
            this.tbStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusFrom.Location = new System.Drawing.Point(192, 67);
            this.tbStatusFrom.Name = "tbStatusFrom";
            this.tbStatusFrom.ReadOnly = true;
            this.tbStatusFrom.Size = new System.Drawing.Size(300, 20);
            this.tbStatusFrom.TabIndex = 8;
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(87, 9);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.NavigateByValue = false;
            this.stbVendor.ReadOnly = false;
            this.stbVendor.Size = new System.Drawing.Size(99, 20);
            this.stbVendor.TabIndex = 1;
            this.stbVendor.UserID = ((long)(0));
            this.stbVendor.Value = null;
            this.stbVendor.ValueReferenceQuery = null;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(13, 13);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "Поставщик:";
            // 
            // stbStatusTo
            // 
            this.stbStatusTo.Location = new System.Drawing.Point(602, 67);
            this.stbStatusTo.Name = "stbStatusTo";
            this.stbStatusTo.NavigateByValue = false;
            this.stbStatusTo.ReadOnly = false;
            this.stbStatusTo.Size = new System.Drawing.Size(100, 20);
            this.stbStatusTo.TabIndex = 10;
            this.stbStatusTo.UserID = ((long)(0));
            this.stbStatusTo.Value = null;
            this.stbStatusTo.ValueReferenceQuery = null;
            // 
            // lblStatusTo
            // 
            this.lblStatusTo.AutoSize = true;
            this.lblStatusTo.Location = new System.Drawing.Point(528, 71);
            this.lblStatusTo.Name = "lblStatusTo";
            this.lblStatusTo.Size = new System.Drawing.Size(59, 13);
            this.lblStatusTo.TabIndex = 9;
            this.lblStatusTo.Text = "Статус по:";
            // 
            // lblStatusFrom
            // 
            this.lblStatusFrom.AutoSize = true;
            this.lblStatusFrom.Location = new System.Drawing.Point(13, 71);
            this.lblStatusFrom.Name = "lblStatusFrom";
            this.lblStatusFrom.Size = new System.Drawing.Size(53, 13);
            this.lblStatusFrom.TabIndex = 6;
            this.lblStatusFrom.Text = "Статус с:";
            // 
            // stbStatusFrom
            // 
            this.stbStatusFrom.Location = new System.Drawing.Point(86, 67);
            this.stbStatusFrom.Name = "stbStatusFrom";
            this.stbStatusFrom.NavigateByValue = false;
            this.stbStatusFrom.ReadOnly = false;
            this.stbStatusFrom.Size = new System.Drawing.Size(100, 20);
            this.stbStatusFrom.TabIndex = 7;
            this.stbStatusFrom.UserID = ((long)(0));
            this.stbStatusFrom.Value = null;
            this.stbStatusFrom.ValueReferenceQuery = null;
            // 
            // qK_LI_LicRequest_DetailsTableAdapter
            // 
            this.qK_LI_LicRequest_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // dgvcColdType
            // 
            this.dgvcColdType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvcColdType.HeaderText = "";
            this.dgvcColdType.Name = "dgvcColdType";
            this.dgvcColdType.ReadOnly = true;
            this.dgvcColdType.Width = 5;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 146;
            // 
            // ReleaseForm
            // 
            this.ReleaseForm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ReleaseForm.DataPropertyName = "ReleaseForm";
            this.ReleaseForm.HeaderText = "Форма выпуска";
            this.ReleaseForm.Name = "ReleaseForm";
            this.ReleaseForm.ReadOnly = true;
            this.ReleaseForm.Width = 115;
            // 
            // Dosage
            // 
            this.Dosage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Dosage.DataPropertyName = "Dosage";
            this.Dosage.HeaderText = "Дозировка";
            this.Dosage.Name = "Dosage";
            this.Dosage.ReadOnly = true;
            this.Dosage.Width = 89;
            // 
            // QtyPack
            // 
            this.QtyPack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QtyPack.DataPropertyName = "QtyPack";
            this.QtyPack.HeaderText = "Количество в упаковке";
            this.QtyPack.Name = "QtyPack";
            this.QtyPack.ReadOnly = true;
            this.QtyPack.Width = 150;
            // 
            // MNN
            // 
            this.MNN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MNN.DataPropertyName = "MNN";
            this.MNN.HeaderText = "МНН";
            this.MNN.Name = "MNN";
            this.MNN.ReadOnly = true;
            this.MNN.Width = 57;
            // 
            // NoReg
            // 
            this.NoReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoReg.DataPropertyName = "NoReg";
            this.NoReg.HeaderText = "Номер РС в Украине";
            this.NoReg.Name = "NoReg";
            this.NoReg.ReadOnly = true;
            this.NoReg.Width = 139;
            // 
            // AtcCode
            // 
            this.AtcCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AtcCode.DataPropertyName = "AtcCode";
            this.AtcCode.HeaderText = "Код АТС";
            this.AtcCode.Name = "AtcCode";
            this.AtcCode.ReadOnly = true;
            this.AtcCode.Width = 75;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Прозводитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 105;
            // 
            // ManufacturerCountry
            // 
            this.ManufacturerCountry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ManufacturerCountry.DataPropertyName = "ManufacturerCountry";
            this.ManufacturerCountry.HeaderText = "Страна производителя";
            this.ManufacturerCountry.Name = "ManufacturerCountry";
            this.ManufacturerCountry.ReadOnly = true;
            this.ManufacturerCountry.Width = 148;
            // 
            // vendorDataGridViewTextBoxColumn
            // 
            this.vendorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorDataGridViewTextBoxColumn.DataPropertyName = "Vendor";
            this.vendorDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.vendorDataGridViewTextBoxColumn.Name = "vendorDataGridViewTextBoxColumn";
            this.vendorDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorDataGridViewTextBoxColumn.Width = 90;
            // 
            // VendorCountry
            // 
            this.VendorCountry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VendorCountry.DataPropertyName = "VendorCountry";
            this.VendorCountry.HeaderText = "Страна поставщика";
            this.VendorCountry.Name = "VendorCountry";
            this.VendorCountry.ReadOnly = true;
            this.VendorCountry.Width = 133;
            // 
            // VendorAddress
            // 
            this.VendorAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VendorAddress.DataPropertyName = "VendorAddress";
            this.VendorAddress.HeaderText = "Адрес поставщика";
            this.VendorAddress.Name = "VendorAddress";
            this.VendorAddress.ReadOnly = true;
            this.VendorAddress.Width = 128;
            // 
            // DateEndReg
            // 
            this.DateEndReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateEndReg.DataPropertyName = "DateEndReg";
            this.DateEndReg.HeaderText = "Срок действия РС в Украине";
            this.DateEndReg.Name = "DateEndReg";
            this.DateEndReg.ReadOnly = true;
            this.DateEndReg.Width = 180;
            // 
            // GMP
            // 
            this.GMP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GMP.DataPropertyName = "GMP";
            this.GMP.HeaderText = "GMP";
            this.GMP.Name = "GMP";
            this.GMP.ReadOnly = true;
            this.GMP.Width = 56;
            // 
            // GMPDateTo
            // 
            this.GMPDateTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GMPDateTo.DataPropertyName = "GMPDateTo";
            this.GMPDateTo.HeaderText = "Срок действия GMP";
            this.GMPDateTo.Name = "GMPDateTo";
            this.GMPDateTo.ReadOnly = true;
            this.GMPDateTo.Width = 134;
            // 
            // ImportLicenseRequestsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 442);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.Name = "ImportLicenseRequestsWindow";
            this.Text = "Уведомления на обновление лицензий на импорт";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.scRequests.Panel1.ResumeLayout(false);
            this.scRequests.Panel2.ResumeLayout(false);
            this.scRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestDetails)).EndInit();
            this.cmsRequestDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qKLILicRequestDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnEditRequest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExportRequestStatement;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCreateRequest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSetConclusion;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvRequests;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox tbItem;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.TextBox tbStatusTo;
        private System.Windows.Forms.TextBox tbStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbVendor;
        private System.Windows.Forms.Label lblVendor;
        private WMSOffice.Controls.SearchTextBox stbStatusTo;
        private System.Windows.Forms.Label lblStatusTo;
        private System.Windows.Forms.Label lblStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusFrom;
        private System.Windows.Forms.SplitContainer scRequests;
        private System.Windows.Forms.DataGridView dgvRequestDetails;
        private System.Windows.Forms.BindingSource qKLILicRequestDetailsBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_LI_LicRequest_DetailsTableAdapter qK_LI_LicRequest_DetailsTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.ContextMenuStrip cmsRequestDetails;
        private System.Windows.Forms.ToolStripMenuItem miCreateItemCopy;
        private System.Windows.Forms.ToolStripMenuItem miDeleteItem;
        private System.Windows.Forms.DataGridViewImageColumn dgvcColdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn MNN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn AtcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateEndReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn GMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GMPDateTo;

    }
}