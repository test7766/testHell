namespace WMSOffice.Window
{
    partial class ComplaintActsWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowAttachments = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowExternalDocs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSendVendorAct = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseAct = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetNoResponseReceived = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseExchange = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSendDocsToLawDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSplitAct = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scDocs = new System.Windows.Forms.SplitContainer();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.scDocDetails = new System.Windows.Forms.SplitContainer();
            this.dgvDocStages = new System.Windows.Forms.DataGridView();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessionIdUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOVendorActStagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.dgvDocDetails = new System.Windows.Forms.DataGridView();
            this.dgvcColdType = new System.Windows.Forms.DataGridViewImageColumn();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOVendorActDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFilter = new System.Windows.Forms.Panel();
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
            this.cO_Vendor_Act_DetailsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_Vendor_Act_DetailsTableAdapter();
            this.cO_Vendor_Act_StagesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_Vendor_Act_StagesTableAdapter();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateMemoForLead = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scDocs.Panel1.SuspendLayout();
            this.scDocs.Panel2.SuspendLayout();
            this.scDocs.SuspendLayout();
            this.scDocDetails.Panel1.SuspendLayout();
            this.scDocDetails.Panel2.SuspendLayout();
            this.scDocDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocStages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOVendorActStagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOVendorActDetailsBindingSource)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnShowAttachments,
            this.toolStripSeparator5,
            this.btnShowExternalDocs,
            this.toolStripSeparator2,
            this.btnSendVendorAct,
            this.toolStripSeparator3,
            this.btnCreateMemoForLead,
            this.toolStripSeparator10,
            this.btnCloseAct,
            this.toolStripSeparator6,
            this.btnSetNoResponseReceived,
            this.toolStripSeparator9,
            this.btnCloseExchange,
            this.toolStripSeparator4,
            this.btnSendDocsToLawDepartment,
            this.toolStripSeparator8,
            this.btnSplitAct,
            this.toolStripSeparator7,
            this.btnExport});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1429, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowAttachments
            // 
            this.btnShowAttachments.Image = global::WMSOffice.Properties.Resources.paperclip;
            this.btnShowAttachments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAttachments.Name = "btnShowAttachments";
            this.btnShowAttachments.Size = new System.Drawing.Size(94, 52);
            this.btnShowAttachments.Text = "Прикр.\nфайлы";
            this.btnShowAttachments.Click += new System.EventHandler(this.btnShowAttachments_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowExternalDocs
            // 
            this.btnShowExternalDocs.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.btnShowExternalDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowExternalDocs.Name = "btnShowExternalDocs";
            this.btnShowExternalDocs.Size = new System.Drawing.Size(117, 52);
            this.btnShowExternalDocs.Text = "Документы";
            this.btnShowExternalDocs.Click += new System.EventHandler(this.btnShowExternalDocs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSendVendorAct
            // 
            this.btnSendVendorAct.Image = global::WMSOffice.Properties.Resources.mail_ok;
            this.btnSendVendorAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendVendorAct.Name = "btnSendVendorAct";
            this.btnSendVendorAct.Size = new System.Drawing.Size(136, 52);
            this.btnSendVendorAct.Text = "Отправить акт\nпоставщику";
            this.btnSendVendorAct.Click += new System.EventHandler(this.btnSendVendorAct_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseAct
            // 
            this.btnCloseAct.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnCloseAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseAct.Name = "btnCloseAct";
            this.btnCloseAct.Size = new System.Drawing.Size(124, 52);
            this.btnCloseAct.Text = "Закрыть акт";
            this.btnCloseAct.Click += new System.EventHandler(this.btnCloseAct_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSetNoResponseReceived
            // 
            this.btnSetNoResponseReceived.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnSetNoResponseReceived.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetNoResponseReceived.Name = "btnSetNoResponseReceived";
            this.btnSetNoResponseReceived.Size = new System.Drawing.Size(116, 52);
            this.btnSetNoResponseReceived.Text = "Ответ\nне получен";
            this.btnSetNoResponseReceived.Click += new System.EventHandler(this.btnSetNoResponseReceived_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseExchange
            // 
            this.btnCloseExchange.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnCloseExchange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseExchange.Name = "btnCloseExchange";
            this.btnCloseExchange.Size = new System.Drawing.Size(131, 52);
            this.btnCloseExchange.Text = "Обмен / довоз\nпроведен";
            this.btnCloseExchange.Click += new System.EventHandler(this.btnCloseExchange_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSendDocsToLawDepartment
            // 
            this.btnSendDocsToLawDepartment.Image = global::WMSOffice.Properties.Resources.document_certificate;
            this.btnSendDocsToLawDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendDocsToLawDepartment.Name = "btnSendDocsToLawDepartment";
            this.btnSendDocsToLawDepartment.Size = new System.Drawing.Size(116, 52);
            this.btnSendDocsToLawDepartment.Text = "Подать\nдокументы\nв ЮД";
            this.btnSendDocsToLawDepartment.Click += new System.EventHandler(this.btnSendDocsToLawDepartment_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSplitAct
            // 
            this.btnSplitAct.Image = global::WMSOffice.Properties.Resources.split;
            this.btnSplitAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplitAct.Name = "btnSplitAct";
            this.btnSplitAct.Size = new System.Drawing.Size(138, 52);
            this.btnSplitAct.Text = "Решения по\nтоварам в Акте\nотличаются";
            this.btnSplitAct.Click += new System.EventHandler(this.btnSplitAct_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(101, 52);
            this.btnExport.Text = "Экспорт\nв Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 95);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1429, 473);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.scDocs);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1429, 378);
            this.pnlContent.TabIndex = 2;
            // 
            // scDocs
            // 
            this.scDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDocs.Location = new System.Drawing.Point(0, 0);
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
            this.scDocs.Size = new System.Drawing.Size(1429, 378);
            this.scDocs.SplitterDistance = 225;
            this.scDocs.TabIndex = 0;
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
            this.xdgvDocs.Size = new System.Drawing.Size(1429, 225);
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
            this.scDocDetails.Panel1.Controls.Add(this.dgvDocStages);
            // 
            // scDocDetails.Panel2
            // 
            this.scDocDetails.Panel2.Controls.Add(this.dgvDocDetails);
            this.scDocDetails.Size = new System.Drawing.Size(1429, 149);
            this.scDocDetails.SplitterDistance = 717;
            this.scDocDetails.TabIndex = 1;
            // 
            // dgvDocStages
            // 
            this.dgvDocStages.AllowUserToAddRows = false;
            this.dgvDocStages.AllowUserToDeleteRows = false;
            this.dgvDocStages.AllowUserToResizeRows = false;
            this.dgvDocStages.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocStages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocStages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocStages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusNameDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.sessionIdUpdatedDataGridViewTextBoxColumn,
            this.dateUpdatedDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn});
            this.dgvDocStages.DataSource = this.cOVendorActStagesBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocStages.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocStages.Location = new System.Drawing.Point(0, 0);
            this.dgvDocStages.MultiSelect = false;
            this.dgvDocStages.Name = "dgvDocStages";
            this.dgvDocStages.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocStages.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocStages.RowHeadersVisible = false;
            this.dgvDocStages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocStages.Size = new System.Drawing.Size(717, 149);
            this.dgvDocStages.TabIndex = 0;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус акта";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 92;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Комментарий";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentDataGridViewTextBoxColumn.Width = 102;
            // 
            // sessionIdUpdatedDataGridViewTextBoxColumn
            // 
            this.sessionIdUpdatedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sessionIdUpdatedDataGridViewTextBoxColumn.DataPropertyName = "SessionIdUpdated";
            this.sessionIdUpdatedDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.sessionIdUpdatedDataGridViewTextBoxColumn.Name = "sessionIdUpdatedDataGridViewTextBoxColumn";
            this.sessionIdUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.sessionIdUpdatedDataGridViewTextBoxColumn.Width = 105;
            // 
            // dateUpdatedDataGridViewTextBoxColumn
            // 
            this.dateUpdatedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateUpdatedDataGridViewTextBoxColumn.DataPropertyName = "DateUpdated";
            this.dateUpdatedDataGridViewTextBoxColumn.HeaderText = "Дата изм.";
            this.dateUpdatedDataGridViewTextBoxColumn.Name = "dateUpdatedDataGridViewTextBoxColumn";
            this.dateUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateUpdatedDataGridViewTextBoxColumn.Width = 84;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "Дата просрочки";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expirationDateDataGridViewTextBoxColumn.Width = 114;
            // 
            // cOVendorActStagesBindingSource
            // 
            this.cOVendorActStagesBindingSource.DataMember = "CO_Vendor_Act_Stages";
            this.cOVendorActStagesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvDocDetails
            // 
            this.dgvDocDetails.AllowUserToAddRows = false;
            this.dgvDocDetails.AllowUserToDeleteRows = false;
            this.dgvDocDetails.AllowUserToResizeRows = false;
            this.dgvDocDetails.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcColdType,
            this.warehouseIDDataGridViewTextBoxColumn,
            this.locationIDDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.batchIDDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.currencyIDDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.vatRateDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn});
            this.dgvDocDetails.DataSource = this.cOVendorActDetailsBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocDetails.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDocDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDocDetails.MultiSelect = false;
            this.dgvDocDetails.Name = "dgvDocDetails";
            this.dgvDocDetails.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDocDetails.RowHeadersVisible = false;
            this.dgvDocDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocDetails.Size = new System.Drawing.Size(708, 149);
            this.dgvDocDetails.TabIndex = 0;
            this.dgvDocDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocDetails_DataBindingComplete);
            // 
            // dgvcColdType
            // 
            this.dgvcColdType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvcColdType.HeaderText = "";
            this.dgvcColdType.Name = "dgvcColdType";
            this.dgvcColdType.ReadOnly = true;
            this.dgvcColdType.Width = 5;
            // 
            // warehouseIDDataGridViewTextBoxColumn
            // 
            this.warehouseIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseIDDataGridViewTextBoxColumn.DataPropertyName = "Warehouse_ID";
            this.warehouseIDDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseIDDataGridViewTextBoxColumn.Name = "warehouseIDDataGridViewTextBoxColumn";
            this.warehouseIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseIDDataGridViewTextBoxColumn.Width = 63;
            // 
            // locationIDDataGridViewTextBoxColumn
            // 
            this.locationIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationIDDataGridViewTextBoxColumn.DataPropertyName = "LocationID";
            this.locationIDDataGridViewTextBoxColumn.HeaderText = "Место";
            this.locationIDDataGridViewTextBoxColumn.Name = "locationIDDataGridViewTextBoxColumn";
            this.locationIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationIDDataGridViewTextBoxColumn.Width = 64;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 89;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Товар";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 63;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 69;
            // 
            // batchIDDataGridViewTextBoxColumn
            // 
            this.batchIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.batchIDDataGridViewTextBoxColumn.DataPropertyName = "BatchID";
            this.batchIDDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.batchIDDataGridViewTextBoxColumn.Name = "batchIDDataGridViewTextBoxColumn";
            this.batchIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchIDDataGridViewTextBoxColumn.Width = 63;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 66;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 47;
            // 
            // currencyIDDataGridViewTextBoxColumn
            // 
            this.currencyIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.currencyIDDataGridViewTextBoxColumn.DataPropertyName = "CurrencyID";
            this.currencyIDDataGridViewTextBoxColumn.HeaderText = "Валюта";
            this.currencyIDDataGridViewTextBoxColumn.Name = "currencyIDDataGridViewTextBoxColumn";
            this.currencyIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.currencyIDDataGridViewTextBoxColumn.Width = 70;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 58;
            // 
            // vatRateDataGridViewTextBoxColumn
            // 
            this.vatRateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vatRateDataGridViewTextBoxColumn.DataPropertyName = "VatRate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.vatRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.vatRateDataGridViewTextBoxColumn.HeaderText = "НДС";
            this.vatRateDataGridViewTextBoxColumn.Name = "vatRateDataGridViewTextBoxColumn";
            this.vatRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.vatRateDataGridViewTextBoxColumn.Width = 56;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 66;
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
            // cOVendorActDetailsBindingSource
            // 
            this.cOVendorActDetailsBindingSource.DataMember = "CO_Vendor_Act_Details";
            this.cOVendorActDetailsBindingSource.DataSource = this.complaints;
            // 
            // pnlFilter
            // 
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
            this.pnlFilter.Size = new System.Drawing.Size(1429, 95);
            this.pnlFilter.TabIndex = 1;
            // 
            // tbItem
            // 
            this.tbItem.BackColor = System.Drawing.SystemColors.Window;
            this.tbItem.Location = new System.Drawing.Point(193, 67);
            this.tbItem.Name = "tbItem";
            this.tbItem.ReadOnly = true;
            this.tbItem.Size = new System.Drawing.Size(816, 20);
            this.tbItem.TabIndex = 11;
            // 
            // stbItem
            // 
            this.stbItem.Location = new System.Drawing.Point(87, 67);
            this.stbItem.Name = "stbItem";
            this.stbItem.NavigateByValue = false;
            this.stbItem.ReadOnly = false;
            this.stbItem.Size = new System.Drawing.Size(100, 20);
            this.stbItem.TabIndex = 10;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(13, 71);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(41, 13);
            this.lblItem.TabIndex = 9;
            this.lblItem.Text = "Товар:";
            // 
            // tbVendor
            // 
            this.tbVendor.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendor.Location = new System.Drawing.Point(193, 9);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.ReadOnly = true;
            this.tbVendor.Size = new System.Drawing.Size(816, 20);
            this.tbVendor.TabIndex = 2;
            // 
            // tbStatusTo
            // 
            this.tbStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusTo.Location = new System.Drawing.Point(709, 38);
            this.tbStatusTo.Name = "tbStatusTo";
            this.tbStatusTo.ReadOnly = true;
            this.tbStatusTo.Size = new System.Drawing.Size(300, 20);
            this.tbStatusTo.TabIndex = 8;
            // 
            // tbStatusFrom
            // 
            this.tbStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusFrom.Location = new System.Drawing.Point(193, 38);
            this.tbStatusFrom.Name = "tbStatusFrom";
            this.tbStatusFrom.ReadOnly = true;
            this.tbStatusFrom.Size = new System.Drawing.Size(300, 20);
            this.tbStatusFrom.TabIndex = 5;
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(87, 9);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.NavigateByValue = false;
            this.stbVendor.ReadOnly = false;
            this.stbVendor.Size = new System.Drawing.Size(100, 20);
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
            this.stbStatusTo.Location = new System.Drawing.Point(603, 38);
            this.stbStatusTo.Name = "stbStatusTo";
            this.stbStatusTo.NavigateByValue = false;
            this.stbStatusTo.ReadOnly = false;
            this.stbStatusTo.Size = new System.Drawing.Size(100, 20);
            this.stbStatusTo.TabIndex = 7;
            this.stbStatusTo.UserID = ((long)(0));
            this.stbStatusTo.Value = null;
            this.stbStatusTo.ValueReferenceQuery = null;
            // 
            // lblStatusTo
            // 
            this.lblStatusTo.AutoSize = true;
            this.lblStatusTo.Location = new System.Drawing.Point(529, 42);
            this.lblStatusTo.Name = "lblStatusTo";
            this.lblStatusTo.Size = new System.Drawing.Size(59, 13);
            this.lblStatusTo.TabIndex = 6;
            this.lblStatusTo.Text = "Статус по:";
            // 
            // lblStatusFrom
            // 
            this.lblStatusFrom.AutoSize = true;
            this.lblStatusFrom.Location = new System.Drawing.Point(13, 42);
            this.lblStatusFrom.Name = "lblStatusFrom";
            this.lblStatusFrom.Size = new System.Drawing.Size(53, 13);
            this.lblStatusFrom.TabIndex = 3;
            this.lblStatusFrom.Text = "Статус с:";
            // 
            // stbStatusFrom
            // 
            this.stbStatusFrom.Location = new System.Drawing.Point(87, 38);
            this.stbStatusFrom.Name = "stbStatusFrom";
            this.stbStatusFrom.NavigateByValue = false;
            this.stbStatusFrom.ReadOnly = false;
            this.stbStatusFrom.Size = new System.Drawing.Size(100, 20);
            this.stbStatusFrom.TabIndex = 4;
            this.stbStatusFrom.UserID = ((long)(0));
            this.stbStatusFrom.Value = null;
            this.stbStatusFrom.ValueReferenceQuery = null;
            // 
            // cO_Vendor_Act_DetailsTableAdapter
            // 
            this.cO_Vendor_Act_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // cO_Vendor_Act_StagesTableAdapter
            // 
            this.cO_Vendor_Act_StagesTableAdapter.ClearBeforeFill = true;
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateMemoForLead
            // 
            this.btnCreateMemoForLead.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.btnCreateMemoForLead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateMemoForLead.Name = "btnCreateMemoForLead";
            this.btnCreateMemoForLead.Size = new System.Drawing.Size(241, 52);
            this.btnCreateMemoForLead.Text = "Сформировать СЗ\nдля Руководства";
            this.btnCreateMemoForLead.Click += new System.EventHandler(this.btnCreateMemoForLead_Click);
            // 
            // ComplaintActsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 568);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.Name = "ComplaintActsWindow";
            this.Text = "ComplaintActsWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintActsWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.scDocs.Panel1.ResumeLayout(false);
            this.scDocs.Panel2.ResumeLayout(false);
            this.scDocs.ResumeLayout(false);
            this.scDocDetails.Panel1.ResumeLayout(false);
            this.scDocDetails.Panel2.ResumeLayout(false);
            this.scDocDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocStages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOVendorActStagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOVendorActDetailsBindingSource)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnShowAttachments;
        private System.Windows.Forms.ToolStripButton btnSendVendorAct;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer scDocs;
        private System.Windows.Forms.ToolStripButton btnShowExternalDocs;
        private System.Windows.Forms.ToolStripButton btnCloseAct;
        private System.Windows.Forms.ToolStripButton btnCloseExchange;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.DataGridView dgvDocDetails;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFilter;
        private WMSOffice.Controls.SearchTextBox stbVendor;
        private System.Windows.Forms.Label lblVendor;
        private WMSOffice.Controls.SearchTextBox stbStatusTo;
        private System.Windows.Forms.Label lblStatusTo;
        private System.Windows.Forms.Label lblStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusFrom;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.TextBox tbStatusTo;
        private System.Windows.Forms.TextBox tbStatusFrom;
        private System.Windows.Forms.BindingSource cOVendorActDetailsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Vendor_Act_DetailsTableAdapter cO_Vendor_Act_DetailsTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn dgvcColdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnSendDocsToLawDepartment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.TextBox tbItem;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.SplitContainer scDocDetails;
        private System.Windows.Forms.DataGridView dgvDocStages;
        private System.Windows.Forms.BindingSource cOVendorActStagesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Vendor_Act_StagesTableAdapter cO_Vendor_Act_StagesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessionIdUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnSplitAct;
        private System.Windows.Forms.ToolStripButton btnSetNoResponseReceived;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnCreateMemoForLead;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    }
}