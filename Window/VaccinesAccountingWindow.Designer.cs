namespace WMSOffice.Window
{
    partial class VaccinesAccountingWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.jVVaccineJournalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.dgvDocsHeaders = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tbResponsible = new System.Windows.Forms.TextBox();
            this.stbResponsible = new WMSOffice.Controls.SearchTextBox();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.tbVaccine = new System.Windows.Forms.TextBox();
            this.stbVaccine = new WMSOffice.Controls.SearchTextBox();
            this.lblVaccine = new System.Windows.Forms.Label();
            this.tbStatusTo = new System.Windows.Forms.TextBox();
            this.tbStatusFrom = new System.Windows.Forms.TextBox();
            this.stbStatusTo = new WMSOffice.Controls.SearchTextBox();
            this.lblStatusTo = new System.Windows.Forms.Label();
            this.lblStatusFrom = new System.Windows.Forms.Label();
            this.stbStatusFrom = new WMSOffice.Controls.SearchTextBox();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.jV_VaccineJournalTableAdapter = new WMSOffice.Data.WHTableAdapters.JV_VaccineJournalTableAdapter();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNVendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNInvoiceNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IN_Act_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNItemSerNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNDateExpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNVaccineStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUTClientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUTDocNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUTQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUTItemSerNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUTDateExpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcRestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jVVaccineJournalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocsHeaders)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnApprove,
            this.toolStripSeparator2,
            this.btnPrint});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1284, 55);
            this.tsMain.TabIndex = 1;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnApprove
            // 
            this.btnApprove.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(114, 52);
            this.btnApprove.Text = "Утвердить";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(98, 52);
            this.btnPrint.Text = "Печать";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 95);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1284, 421);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvDocs);
            this.pnlContent.Controls.Add(this.dgvDocsHeaders);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 125);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1284, 296);
            this.pnlContent.TabIndex = 1;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToResizeColumns = false;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.iNVendorNameDataGridViewTextBoxColumn,
            this.iNInvoiceNoDataGridViewTextBoxColumn,
            this.IN_Act_No,
            this.iNQtyDataGridViewTextBoxColumn,
            this.iNItemSerNoDataGridViewTextBoxColumn,
            this.iNDateExpDataGridViewTextBoxColumn,
            this.iNVaccineStateDataGridViewTextBoxColumn,
            this.oUTClientNameDataGridViewTextBoxColumn,
            this.oUTDocNoDataGridViewTextBoxColumn,
            this.oUTQtyDataGridViewTextBoxColumn,
            this.oUTItemSerNoDataGridViewTextBoxColumn,
            this.oUTDateExpDataGridViewTextBoxColumn,
            this.calcRestDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.jVVaccineJournalBindingSource;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 28);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(1284, 268);
            this.dgvDocs.TabIndex = 1;
            this.dgvDocs.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvDocs_Scroll);
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // jVVaccineJournalBindingSource
            // 
            this.jVVaccineJournalBindingSource.DataMember = "JV_VaccineJournal";
            this.jVVaccineJournalBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvDocsHeaders
            // 
            this.dgvDocsHeaders.AllowUserToAddRows = false;
            this.dgvDocsHeaders.AllowUserToDeleteRows = false;
            this.dgvDocsHeaders.AllowUserToResizeColumns = false;
            this.dgvDocsHeaders.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocsHeaders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocsHeaders.ColumnHeadersHeight = 25;
            this.dgvDocsHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocsHeaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDocsHeaders.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDocsHeaders.Location = new System.Drawing.Point(0, 0);
            this.dgvDocsHeaders.MultiSelect = false;
            this.dgvDocsHeaders.Name = "dgvDocsHeaders";
            this.dgvDocsHeaders.ReadOnly = true;
            this.dgvDocsHeaders.RowHeadersVisible = false;
            this.dgvDocsHeaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocsHeaders.Size = new System.Drawing.Size(1284, 28);
            this.dgvDocsHeaders.TabIndex = 0;
            this.dgvDocsHeaders.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvDocsHeaders_Scroll);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Запись в журнале";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Получено";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 815;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Выдано";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 650;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "На конец периода";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 160;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tbResponsible);
            this.pnlSearch.Controls.Add(this.stbResponsible);
            this.pnlSearch.Controls.Add(this.lblResponsible);
            this.pnlSearch.Controls.Add(this.dtpPeriodTo);
            this.pnlSearch.Controls.Add(this.dtpPeriodFrom);
            this.pnlSearch.Controls.Add(this.lblPeriodTo);
            this.pnlSearch.Controls.Add(this.lblPeriodFrom);
            this.pnlSearch.Controls.Add(this.tbVaccine);
            this.pnlSearch.Controls.Add(this.stbVaccine);
            this.pnlSearch.Controls.Add(this.lblVaccine);
            this.pnlSearch.Controls.Add(this.tbStatusTo);
            this.pnlSearch.Controls.Add(this.tbStatusFrom);
            this.pnlSearch.Controls.Add(this.stbStatusTo);
            this.pnlSearch.Controls.Add(this.lblStatusTo);
            this.pnlSearch.Controls.Add(this.lblStatusFrom);
            this.pnlSearch.Controls.Add(this.stbStatusFrom);
            this.pnlSearch.Controls.Add(this.tbWarehouse);
            this.pnlSearch.Controls.Add(this.stbWarehouse);
            this.pnlSearch.Controls.Add(this.lblWarehouse);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1284, 125);
            this.pnlSearch.TabIndex = 0;
            // 
            // tbResponsible
            // 
            this.tbResponsible.BackColor = System.Drawing.SystemColors.Window;
            this.tbResponsible.Location = new System.Drawing.Point(1204, 10);
            this.tbResponsible.Name = "tbResponsible";
            this.tbResponsible.ReadOnly = true;
            this.tbResponsible.Size = new System.Drawing.Size(450, 20);
            this.tbResponsible.TabIndex = 18;
            // 
            // stbResponsible
            // 
            this.stbResponsible.BackColor = System.Drawing.SystemColors.Window;
            this.stbResponsible.Location = new System.Drawing.Point(1096, 10);
            this.stbResponsible.Name = "stbResponsible";
            this.stbResponsible.NavigateByValue = false;
            this.stbResponsible.ReadOnly = true;
            this.stbResponsible.Size = new System.Drawing.Size(100, 20);
            this.stbResponsible.TabIndex = 17;
            this.stbResponsible.UserID = ((long)(0));
            this.stbResponsible.Value = null;
            this.stbResponsible.ValueReferenceQuery = null;
            // 
            // lblResponsible
            // 
            this.lblResponsible.AutoSize = true;
            this.lblResponsible.Location = new System.Drawing.Point(999, 14);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(89, 13);
            this.lblResponsible.TabIndex = 16;
            this.lblResponsible.Text = "Ответственный:";
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(362, 93);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 15;
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(111, 93);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 13;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(260, 97);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(63, 13);
            this.lblPeriodTo.TabIndex = 14;
            this.lblPeriodTo.Text = "Период по:";
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(13, 97);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(57, 13);
            this.lblPeriodFrom.TabIndex = 12;
            this.lblPeriodFrom.Text = "Период с:";
            // 
            // tbVaccine
            // 
            this.tbVaccine.BackColor = System.Drawing.SystemColors.Window;
            this.tbVaccine.Location = new System.Drawing.Point(217, 37);
            this.tbVaccine.Name = "tbVaccine";
            this.tbVaccine.ReadOnly = true;
            this.tbVaccine.Size = new System.Drawing.Size(750, 20);
            this.tbVaccine.TabIndex = 5;
            // 
            // stbVaccine
            // 
            this.stbVaccine.Location = new System.Drawing.Point(111, 37);
            this.stbVaccine.Name = "stbVaccine";
            this.stbVaccine.NavigateByValue = false;
            this.stbVaccine.ReadOnly = false;
            this.stbVaccine.Size = new System.Drawing.Size(100, 20);
            this.stbVaccine.TabIndex = 4;
            this.stbVaccine.UserID = ((long)(0));
            this.stbVaccine.Value = null;
            this.stbVaccine.ValueReferenceQuery = null;
            // 
            // lblVaccine
            // 
            this.lblVaccine.AutoSize = true;
            this.lblVaccine.Location = new System.Drawing.Point(13, 41);
            this.lblVaccine.Name = "lblVaccine";
            this.lblVaccine.Size = new System.Drawing.Size(53, 13);
            this.lblVaccine.TabIndex = 3;
            this.lblVaccine.Text = "Вакцина:";
            // 
            // tbStatusTo
            // 
            this.tbStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusTo.Location = new System.Drawing.Point(722, 65);
            this.tbStatusTo.Name = "tbStatusTo";
            this.tbStatusTo.ReadOnly = true;
            this.tbStatusTo.Size = new System.Drawing.Size(245, 20);
            this.tbStatusTo.TabIndex = 11;
            // 
            // tbStatusFrom
            // 
            this.tbStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusFrom.Location = new System.Drawing.Point(217, 65);
            this.tbStatusFrom.Name = "tbStatusFrom";
            this.tbStatusFrom.ReadOnly = true;
            this.tbStatusFrom.Size = new System.Drawing.Size(245, 20);
            this.tbStatusFrom.TabIndex = 8;
            // 
            // stbStatusTo
            // 
            this.stbStatusTo.Location = new System.Drawing.Point(616, 65);
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
            this.lblStatusTo.Location = new System.Drawing.Point(512, 69);
            this.lblStatusTo.Name = "lblStatusTo";
            this.lblStatusTo.Size = new System.Drawing.Size(59, 13);
            this.lblStatusTo.TabIndex = 9;
            this.lblStatusTo.Text = "Статус по:";
            // 
            // lblStatusFrom
            // 
            this.lblStatusFrom.AutoSize = true;
            this.lblStatusFrom.Location = new System.Drawing.Point(13, 69);
            this.lblStatusFrom.Name = "lblStatusFrom";
            this.lblStatusFrom.Size = new System.Drawing.Size(53, 13);
            this.lblStatusFrom.TabIndex = 6;
            this.lblStatusFrom.Text = "Статус с:";
            // 
            // stbStatusFrom
            // 
            this.stbStatusFrom.Location = new System.Drawing.Point(111, 65);
            this.stbStatusFrom.Name = "stbStatusFrom";
            this.stbStatusFrom.NavigateByValue = false;
            this.stbStatusFrom.ReadOnly = false;
            this.stbStatusFrom.Size = new System.Drawing.Size(100, 20);
            this.stbStatusFrom.TabIndex = 7;
            this.stbStatusFrom.UserID = ((long)(0));
            this.stbStatusFrom.Value = null;
            this.stbStatusFrom.ValueReferenceQuery = null;
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouse.Location = new System.Drawing.Point(217, 9);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.ReadOnly = true;
            this.tbWarehouse.Size = new System.Drawing.Size(750, 20);
            this.tbWarehouse.TabIndex = 2;
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(111, 9);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.NavigateByValue = false;
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouse.TabIndex = 1;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(13, 13);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(90, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Подразделение:";
            // 
            // jV_VaccineJournalTableAdapter
            // 
            this.jV_VaccineJournalTableAdapter.ClearBeforeFill = true;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.docIDDataGridViewTextBoxColumn.ToolTipText = "Код записи в журнале вакцин";
            this.docIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.docDateDataGridViewTextBoxColumn.ToolTipText = "Дата записи в журнале вакцин";
            this.docDateDataGridViewTextBoxColumn.Width = 80;
            // 
            // iNVendorNameDataGridViewTextBoxColumn
            // 
            this.iNVendorNameDataGridViewTextBoxColumn.DataPropertyName = "IN_Vendor_Name";
            this.iNVendorNameDataGridViewTextBoxColumn.HeaderText = "От кого";
            this.iNVendorNameDataGridViewTextBoxColumn.Name = "iNVendorNameDataGridViewTextBoxColumn";
            this.iNVendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNVendorNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iNVendorNameDataGridViewTextBoxColumn.ToolTipText = "Наименование поставщика";
            this.iNVendorNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // iNInvoiceNoDataGridViewTextBoxColumn
            // 
            this.iNInvoiceNoDataGridViewTextBoxColumn.DataPropertyName = "IN_Invoice_No";
            this.iNInvoiceNoDataGridViewTextBoxColumn.HeaderText = "№ накладной";
            this.iNInvoiceNoDataGridViewTextBoxColumn.Name = "iNInvoiceNoDataGridViewTextBoxColumn";
            this.iNInvoiceNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNInvoiceNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iNInvoiceNoDataGridViewTextBoxColumn.ToolTipText = "№ накладной прихода поставщика";
            this.iNInvoiceNoDataGridViewTextBoxColumn.Width = 85;
            // 
            // IN_Act_No
            // 
            this.IN_Act_No.DataPropertyName = "IN_Act_No";
            this.IN_Act_No.HeaderText = "№ акта";
            this.IN_Act_No.Name = "IN_Act_No";
            this.IN_Act_No.ReadOnly = true;
            this.IN_Act_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IN_Act_No.ToolTipText = "№ акта приемки";
            this.IN_Act_No.Width = 85;
            // 
            // iNQtyDataGridViewTextBoxColumn
            // 
            this.iNQtyDataGridViewTextBoxColumn.DataPropertyName = "IN_Qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.iNQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.iNQtyDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.iNQtyDataGridViewTextBoxColumn.Name = "iNQtyDataGridViewTextBoxColumn";
            this.iNQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNQtyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iNQtyDataGridViewTextBoxColumn.ToolTipText = "Количество доз";
            this.iNQtyDataGridViewTextBoxColumn.Width = 80;
            // 
            // iNItemSerNoDataGridViewTextBoxColumn
            // 
            this.iNItemSerNoDataGridViewTextBoxColumn.DataPropertyName = "IN_Item_SerNo";
            this.iNItemSerNoDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.iNItemSerNoDataGridViewTextBoxColumn.Name = "iNItemSerNoDataGridViewTextBoxColumn";
            this.iNItemSerNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNItemSerNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iNItemSerNoDataGridViewTextBoxColumn.Width = 85;
            // 
            // iNDateExpDataGridViewTextBoxColumn
            // 
            this.iNDateExpDataGridViewTextBoxColumn.DataPropertyName = "IN_Date_Exp";
            this.iNDateExpDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.iNDateExpDataGridViewTextBoxColumn.Name = "iNDateExpDataGridViewTextBoxColumn";
            this.iNDateExpDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNDateExpDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // iNVaccineStateDataGridViewTextBoxColumn
            // 
            this.iNVaccineStateDataGridViewTextBoxColumn.DataPropertyName = "IN_Vaccine_State";
            this.iNVaccineStateDataGridViewTextBoxColumn.HeaderText = "Состояние";
            this.iNVaccineStateDataGridViewTextBoxColumn.Name = "iNVaccineStateDataGridViewTextBoxColumn";
            this.iNVaccineStateDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNVaccineStateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iNVaccineStateDataGridViewTextBoxColumn.ToolTipText = "Показания температуры";
            this.iNVaccineStateDataGridViewTextBoxColumn.Width = 80;
            // 
            // oUTClientNameDataGridViewTextBoxColumn
            // 
            this.oUTClientNameDataGridViewTextBoxColumn.DataPropertyName = "OUT_Client_Name";
            this.oUTClientNameDataGridViewTextBoxColumn.HeaderText = "Кому";
            this.oUTClientNameDataGridViewTextBoxColumn.Name = "oUTClientNameDataGridViewTextBoxColumn";
            this.oUTClientNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.oUTClientNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.oUTClientNameDataGridViewTextBoxColumn.ToolTipText = "Наименование клиента";
            this.oUTClientNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // oUTDocNoDataGridViewTextBoxColumn
            // 
            this.oUTDocNoDataGridViewTextBoxColumn.DataPropertyName = "OUT_Doc_No";
            this.oUTDocNoDataGridViewTextBoxColumn.HeaderText = "№ накладной";
            this.oUTDocNoDataGridViewTextBoxColumn.Name = "oUTDocNoDataGridViewTextBoxColumn";
            this.oUTDocNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.oUTDocNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.oUTDocNoDataGridViewTextBoxColumn.ToolTipText = "№ накладной отгрузки клиенту";
            this.oUTDocNoDataGridViewTextBoxColumn.Width = 85;
            // 
            // oUTQtyDataGridViewTextBoxColumn
            // 
            this.oUTQtyDataGridViewTextBoxColumn.DataPropertyName = "OUT_Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.oUTQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.oUTQtyDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.oUTQtyDataGridViewTextBoxColumn.Name = "oUTQtyDataGridViewTextBoxColumn";
            this.oUTQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.oUTQtyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.oUTQtyDataGridViewTextBoxColumn.ToolTipText = "Количество доз";
            this.oUTQtyDataGridViewTextBoxColumn.Width = 80;
            // 
            // oUTItemSerNoDataGridViewTextBoxColumn
            // 
            this.oUTItemSerNoDataGridViewTextBoxColumn.DataPropertyName = "OUT_Item_SerNo";
            this.oUTItemSerNoDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.oUTItemSerNoDataGridViewTextBoxColumn.Name = "oUTItemSerNoDataGridViewTextBoxColumn";
            this.oUTItemSerNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.oUTItemSerNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.oUTItemSerNoDataGridViewTextBoxColumn.Width = 85;
            // 
            // oUTDateExpDataGridViewTextBoxColumn
            // 
            this.oUTDateExpDataGridViewTextBoxColumn.DataPropertyName = "OUT_Date_Exp";
            this.oUTDateExpDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.oUTDateExpDataGridViewTextBoxColumn.Name = "oUTDateExpDataGridViewTextBoxColumn";
            this.oUTDateExpDataGridViewTextBoxColumn.ReadOnly = true;
            this.oUTDateExpDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // calcRestDataGridViewTextBoxColumn
            // 
            this.calcRestDataGridViewTextBoxColumn.DataPropertyName = "Calc_Rest";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.calcRestDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.calcRestDataGridViewTextBoxColumn.HeaderText = "Остаток";
            this.calcRestDataGridViewTextBoxColumn.Name = "calcRestDataGridViewTextBoxColumn";
            this.calcRestDataGridViewTextBoxColumn.ReadOnly = true;
            this.calcRestDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.calcRestDataGridViewTextBoxColumn.ToolTipText = "Количество доз";
            this.calcRestDataGridViewTextBoxColumn.Width = 80;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.statusNameDataGridViewTextBoxColumn.ToolTipText = "Статус записи в журнале вакцин";
            this.statusNameDataGridViewTextBoxColumn.Width = 80;
            // 
            // VaccinesAccountingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 516);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.Name = "VaccinesAccountingWindow";
            this.Text = "VaccinesAccountingWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jVVaccineJournalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocsHeaders)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox tbStatusTo;
        private System.Windows.Forms.TextBox tbStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusTo;
        private System.Windows.Forms.Label lblStatusTo;
        private System.Windows.Forms.Label lblStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusFrom;
        private System.Windows.Forms.TextBox tbWarehouse;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.TextBox tbVaccine;
        private WMSOffice.Controls.SearchTextBox stbVaccine;
        private System.Windows.Forms.Label lblVaccine;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.DataGridView dgvDocsHeaders;
        private System.Windows.Forms.BindingSource jVVaccineJournalBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.JV_VaccineJournalTableAdapter jV_VaccineJournalTableAdapter;
        private System.Windows.Forms.TextBox tbResponsible;
        private WMSOffice.Controls.SearchTextBox stbResponsible;
        private System.Windows.Forms.Label lblResponsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNVendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNInvoiceNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IN_Act_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNItemSerNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNDateExpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNVaccineStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oUTClientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oUTDocNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oUTQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oUTItemSerNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oUTDateExpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcRestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
    }
}