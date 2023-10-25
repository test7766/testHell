namespace WMSOffice.Window
{
    partial class ShipReturnsToVendorWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFindVendorReturn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowAttachments = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChangeVendorReturnDate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddShipmentMethod = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintWaybillReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintDocsPackage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShipVendorReturn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportVendorReturnItems = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scVendorReturns = new System.Windows.Forms.SplitContainer();
            this.xdgvVendorReturnsGroups = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.scVendorReturnsItems = new System.Windows.Forms.SplitContainer();
            this.dgvVendorReturns = new System.Windows.Forms.DataGridView();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expectedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcHasAttachedFiles = new System.Windows.Forms.DataGridViewImageColumn();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSVATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jDEDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountUAHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doc_Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mOZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plannerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planReturnDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First_PlanReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnFlialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sVVRDocsByVendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.dgvVendorReturnItems = new System.Windows.Forms.DataGridView();
            this.sVVRDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripPrinters = new System.Windows.Forms.ToolStrip();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.sV_VR_Docs_By_VendorTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.SV_VR_Docs_By_VendorTableAdapter();
            this.sV_VR_Doc_DetailsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.SV_VR_Doc_DetailsTableAdapter();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxBarWEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.scVendorReturns.Panel1.SuspendLayout();
            this.scVendorReturns.Panel2.SuspendLayout();
            this.scVendorReturns.SuspendLayout();
            this.scVendorReturnsItems.Panel1.SuspendLayout();
            this.scVendorReturnsItems.Panel2.SuspendLayout();
            this.scVendorReturnsItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorReturns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVVRDocsByVendorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorReturnItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVVRDocDetailsBindingSource)).BeginInit();
            this.toolStripPrinters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnFindVendorReturn,
            this.toolStripSeparator2,
            this.btnShowAttachments,
            this.toolStripSeparator3,
            this.btnChangeVendorReturnDate,
            this.toolStripSeparator4,
            this.btnAddShipmentMethod,
            this.toolStripSeparator5,
            this.btnPrintWaybillReport,
            this.toolStripSeparator7,
            this.btnPrintDocsPackage,
            this.toolStripSeparator8,
            this.btnShipVendorReturn,
            this.toolStripSeparator6,
            this.btnExportVendorReturnItems});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1204, 55);
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
            // btnFindVendorReturn
            // 
            this.btnFindVendorReturn.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFindVendorReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindVendorReturn.Name = "btnFindVendorReturn";
            this.btnFindVendorReturn.Size = new System.Drawing.Size(94, 52);
            this.btnFindVendorReturn.Text = "Поиск";
            this.btnFindVendorReturn.Click += new System.EventHandler(this.btnFindVendorReturn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowAttachments
            // 
            this.btnShowAttachments.Image = global::WMSOffice.Properties.Resources.paperclip;
            this.btnShowAttachments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAttachments.Name = "btnShowAttachments";
            this.btnShowAttachments.Size = new System.Drawing.Size(98, 52);
            this.btnShowAttachments.Text = "Прикр.\nфайлы";
            this.btnShowAttachments.Click += new System.EventHandler(this.btnShowAttachments_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnChangeVendorReturnDate
            // 
            this.btnChangeVendorReturnDate.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.btnChangeVendorReturnDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeVendorReturnDate.Name = "btnChangeVendorReturnDate";
            this.btnChangeVendorReturnDate.Size = new System.Drawing.Size(139, 52);
            this.btnChangeVendorReturnDate.Text = "Изменить дату\nвозврата";
            this.btnChangeVendorReturnDate.Click += new System.EventHandler(this.btnChangeVendorReturnDate_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAddShipmentMethod
            // 
            this.btnAddShipmentMethod.Image = global::WMSOffice.Properties.Resources.delivery;
            this.btnAddShipmentMethod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddShipmentMethod.Name = "btnAddShipmentMethod";
            this.btnAddShipmentMethod.Size = new System.Drawing.Size(149, 52);
            this.btnAddShipmentMethod.Text = "Изменить метод\nотгрузки";
            this.btnAddShipmentMethod.Click += new System.EventHandler(this.btnAddShipmentMethod_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintWaybillReport
            // 
            this.btnPrintWaybillReport.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintWaybillReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintWaybillReport.Name = "btnPrintWaybillReport";
            this.btnPrintWaybillReport.Size = new System.Drawing.Size(122, 52);
            this.btnPrintWaybillReport.Text = "Печать ТТН";
            this.btnPrintWaybillReport.Click += new System.EventHandler(this.btnPrintWaybillReport_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintDocsPackage
            // 
            this.btnPrintDocsPackage.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintDocsPackage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintDocsPackage.Name = "btnPrintDocsPackage";
            this.btnPrintDocsPackage.Size = new System.Drawing.Size(137, 52);
            this.btnPrintDocsPackage.Text = "Печать пакета\nдокументов";
            this.btnPrintDocsPackage.Click += new System.EventHandler(this.btnPrintDocsPackage_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShipVendorReturn
            // 
            this.btnShipVendorReturn.Image = global::WMSOffice.Properties.Resources.baggage;
            this.btnShipVendorReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShipVendorReturn.Name = "btnShipVendorReturn";
            this.btnShipVendorReturn.Size = new System.Drawing.Size(114, 52);
            this.btnShipVendorReturn.Text = "Отгрузить\nвозврат";
            this.btnShipVendorReturn.Click += new System.EventHandler(this.btnShipVendorReturn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportVendorReturnItems
            // 
            this.btnExportVendorReturnItems.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportVendorReturnItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportVendorReturnItems.Name = "btnExportVendorReturnItems";
            this.btnExportVendorReturnItems.Size = new System.Drawing.Size(151, 52);
            this.btnExportVendorReturnItems.Text = "Экспорт товаров\nв накладной";
            this.btnExportVendorReturnItems.Click += new System.EventHandler(this.btnExportVendorReturnItems_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Controls.Add(this.toolStripPrinters);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1204, 386);
            this.pnlContent.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.scVendorReturns);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 361);
            this.panel1.TabIndex = 2;
            // 
            // scVendorReturns
            // 
            this.scVendorReturns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scVendorReturns.Location = new System.Drawing.Point(0, 0);
            this.scVendorReturns.Name = "scVendorReturns";
            this.scVendorReturns.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scVendorReturns.Panel1
            // 
            this.scVendorReturns.Panel1.Controls.Add(this.xdgvVendorReturnsGroups);
            // 
            // scVendorReturns.Panel2
            // 
            this.scVendorReturns.Panel2.Controls.Add(this.scVendorReturnsItems);
            this.scVendorReturns.Size = new System.Drawing.Size(1204, 361);
            this.scVendorReturns.SplitterDistance = 153;
            this.scVendorReturns.TabIndex = 0;
            // 
            // xdgvVendorReturnsGroups
            // 
            this.xdgvVendorReturnsGroups.AllowSort = true;
            this.xdgvVendorReturnsGroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvVendorReturnsGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvVendorReturnsGroups.LargeAmountOfData = false;
            this.xdgvVendorReturnsGroups.Location = new System.Drawing.Point(0, 0);
            this.xdgvVendorReturnsGroups.Name = "xdgvVendorReturnsGroups";
            this.xdgvVendorReturnsGroups.RowHeadersVisible = false;
            this.xdgvVendorReturnsGroups.Size = new System.Drawing.Size(1204, 153);
            this.xdgvVendorReturnsGroups.TabIndex = 0;
            this.xdgvVendorReturnsGroups.UserID = ((long)(0));
            // 
            // scVendorReturnsItems
            // 
            this.scVendorReturnsItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scVendorReturnsItems.Location = new System.Drawing.Point(0, 0);
            this.scVendorReturnsItems.Name = "scVendorReturnsItems";
            this.scVendorReturnsItems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scVendorReturnsItems.Panel1
            // 
            this.scVendorReturnsItems.Panel1.Controls.Add(this.dgvVendorReturns);
            // 
            // scVendorReturnsItems.Panel2
            // 
            this.scVendorReturnsItems.Panel2.Controls.Add(this.dgvVendorReturnItems);
            this.scVendorReturnsItems.Size = new System.Drawing.Size(1204, 204);
            this.scVendorReturnsItems.SplitterDistance = 102;
            this.scVendorReturnsItems.TabIndex = 0;
            // 
            // dgvVendorReturns
            // 
            this.dgvVendorReturns.AllowUserToAddRows = false;
            this.dgvVendorReturns.AllowUserToDeleteRows = false;
            this.dgvVendorReturns.AllowUserToResizeColumns = false;
            this.dgvVendorReturns.AllowUserToResizeRows = false;
            this.dgvVendorReturns.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendorReturns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendorReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorReturns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.expectedDateDataGridViewTextBoxColumn,
            this.dgvcHasAttachedFiles,
            this.userDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.iSVATDataGridViewTextBoxColumn,
            this.vendorDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.jDEDocDataGridViewTextBoxColumn,
            this.amountUAHDataGridViewTextBoxColumn,
            this.Doc_Volume,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.mOZDataGridViewTextBoxColumn,
            this.plannerDataGridViewTextBoxColumn,
            this.planReturnDateDataGridViewTextBoxColumn,
            this.First_PlanReturnDate,
            this.returnFlialDataGridViewTextBoxColumn,
            this.returnMethodDataGridViewTextBoxColumn});
            this.dgvVendorReturns.DataSource = this.sVVRDocsByVendorBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendorReturns.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVendorReturns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendorReturns.Location = new System.Drawing.Point(0, 0);
            this.dgvVendorReturns.MultiSelect = false;
            this.dgvVendorReturns.Name = "dgvVendorReturns";
            this.dgvVendorReturns.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendorReturns.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVendorReturns.RowHeadersVisible = false;
            this.dgvVendorReturns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendorReturns.Size = new System.Drawing.Size(1204, 102);
            this.dgvVendorReturns.TabIndex = 0;
            this.dgvVendorReturns.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVendorReturns_CellFormatting);
            this.dgvVendorReturns.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVendorReturns_DataError);
            this.dgvVendorReturns.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvVendorReturns_DataBindingComplete);
            this.dgvVendorReturns.SelectionChanged += new System.EventHandler(this.dgvVendorReturns_SelectionChanged);
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "№ накладной";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 92;
            // 
            // expectedDateDataGridViewTextBoxColumn
            // 
            this.expectedDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expectedDateDataGridViewTextBoxColumn.DataPropertyName = "ExpectedDate";
            this.expectedDateDataGridViewTextBoxColumn.HeaderText = "Дата накладной";
            this.expectedDateDataGridViewTextBoxColumn.Name = "expectedDateDataGridViewTextBoxColumn";
            this.expectedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expectedDateDataGridViewTextBoxColumn.Width = 106;
            // 
            // dgvcHasAttachedFiles
            // 
            this.dgvcHasAttachedFiles.HeaderText = "П. ф.";
            this.dgvcHasAttachedFiles.Name = "dgvcHasAttachedFiles";
            this.dgvcHasAttachedFiles.ReadOnly = true;
            this.dgvcHasAttachedFiles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcHasAttachedFiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcHasAttachedFiles.Width = 22;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userDataGridViewTextBoxColumn.DataPropertyName = "User";
            this.userDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.ReadOnly = true;
            this.userDataGridViewTextBoxColumn.Width = 105;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата создания";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iSVATDataGridViewTextBoxColumn
            // 
            this.iSVATDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iSVATDataGridViewTextBoxColumn.DataPropertyName = "IS_VAT";
            this.iSVATDataGridViewTextBoxColumn.HeaderText = "НДС/не НДС накладная";
            this.iSVATDataGridViewTextBoxColumn.Name = "iSVATDataGridViewTextBoxColumn";
            this.iSVATDataGridViewTextBoxColumn.ReadOnly = true;
            this.iSVATDataGridViewTextBoxColumn.Width = 143;
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
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Ст.";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 47;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 66;
            // 
            // jDEDocDataGridViewTextBoxColumn
            // 
            this.jDEDocDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.jDEDocDataGridViewTextBoxColumn.DataPropertyName = "JDE_Doc";
            this.jDEDocDataGridViewTextBoxColumn.HeaderText = "Номер в JDE";
            this.jDEDocDataGridViewTextBoxColumn.Name = "jDEDocDataGridViewTextBoxColumn";
            this.jDEDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.jDEDocDataGridViewTextBoxColumn.Width = 72;
            // 
            // amountUAHDataGridViewTextBoxColumn
            // 
            this.amountUAHDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountUAHDataGridViewTextBoxColumn.DataPropertyName = "Amount_UAH";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.amountUAHDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amountUAHDataGridViewTextBoxColumn.HeaderText = "Итог. сумма";
            this.amountUAHDataGridViewTextBoxColumn.Name = "amountUAHDataGridViewTextBoxColumn";
            this.amountUAHDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountUAHDataGridViewTextBoxColumn.Width = 88;
            // 
            // Doc_Volume
            // 
            this.Doc_Volume.DataPropertyName = "Doc_Volume";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N6";
            this.Doc_Volume.DefaultCellStyle = dataGridViewCellStyle3;
            this.Doc_Volume.HeaderText = "Объем, м³";
            this.Doc_Volume.Name = "Doc_Volume";
            this.Doc_Volume.ReadOnly = true;
            this.Doc_Volume.Width = 78;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_Name";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Тип возврата";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeNameDataGridViewTextBoxColumn.Width = 93;
            // 
            // mOZDataGridViewTextBoxColumn
            // 
            this.mOZDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mOZDataGridViewTextBoxColumn.DataPropertyName = "MOZ";
            this.mOZDataGridViewTextBoxColumn.HeaderText = "МОЗ";
            this.mOZDataGridViewTextBoxColumn.Name = "mOZDataGridViewTextBoxColumn";
            this.mOZDataGridViewTextBoxColumn.ReadOnly = true;
            this.mOZDataGridViewTextBoxColumn.Width = 56;
            // 
            // plannerDataGridViewTextBoxColumn
            // 
            this.plannerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.plannerDataGridViewTextBoxColumn.DataPropertyName = "Planner";
            this.plannerDataGridViewTextBoxColumn.HeaderText = "Планировщик";
            this.plannerDataGridViewTextBoxColumn.Name = "plannerDataGridViewTextBoxColumn";
            this.plannerDataGridViewTextBoxColumn.ReadOnly = true;
            this.plannerDataGridViewTextBoxColumn.Width = 103;
            // 
            // planReturnDateDataGridViewTextBoxColumn
            // 
            this.planReturnDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.planReturnDateDataGridViewTextBoxColumn.DataPropertyName = "PlanReturnDate";
            this.planReturnDateDataGridViewTextBoxColumn.HeaderText = "Дата возврата";
            this.planReturnDateDataGridViewTextBoxColumn.Name = "planReturnDateDataGridViewTextBoxColumn";
            this.planReturnDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.planReturnDateDataGridViewTextBoxColumn.Width = 99;
            // 
            // First_PlanReturnDate
            // 
            this.First_PlanReturnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.First_PlanReturnDate.DataPropertyName = "First_PlanReturnDate";
            this.First_PlanReturnDate.HeaderText = "Дата возврата оригинал";
            this.First_PlanReturnDate.Name = "First_PlanReturnDate";
            this.First_PlanReturnDate.ReadOnly = true;
            this.First_PlanReturnDate.Width = 144;
            // 
            // returnFlialDataGridViewTextBoxColumn
            // 
            this.returnFlialDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.returnFlialDataGridViewTextBoxColumn.DataPropertyName = "ReturnFlial";
            this.returnFlialDataGridViewTextBoxColumn.HeaderText = "Филиал возврата";
            this.returnFlialDataGridViewTextBoxColumn.Name = "returnFlialDataGridViewTextBoxColumn";
            this.returnFlialDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnFlialDataGridViewTextBoxColumn.Width = 113;
            // 
            // returnMethodDataGridViewTextBoxColumn
            // 
            this.returnMethodDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.returnMethodDataGridViewTextBoxColumn.DataPropertyName = "ReturnMethod";
            this.returnMethodDataGridViewTextBoxColumn.HeaderText = "Тип доставки";
            this.returnMethodDataGridViewTextBoxColumn.Name = "returnMethodDataGridViewTextBoxColumn";
            this.returnMethodDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnMethodDataGridViewTextBoxColumn.Width = 93;
            // 
            // sVVRDocsByVendorBindingSource
            // 
            this.sVVRDocsByVendorBindingSource.DataMember = "SV_VR_Docs_By_Vendor";
            this.sVVRDocsByVendorBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvVendorReturnItems
            // 
            this.dgvVendorReturnItems.AllowUserToAddRows = false;
            this.dgvVendorReturnItems.AllowUserToDeleteRows = false;
            this.dgvVendorReturnItems.AllowUserToResizeColumns = false;
            this.dgvVendorReturnItems.AllowUserToResizeRows = false;
            this.dgvVendorReturnItems.AutoGenerateColumns = false;
            this.dgvVendorReturnItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendorReturnItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVendorReturnItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorReturnItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.boxBarWEDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.Location_ID,
            this.Batch_ID,
            this.ExpirationDate,
            this.Dimension});
            this.dgvVendorReturnItems.DataSource = this.sVVRDocDetailsBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendorReturnItems.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvVendorReturnItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendorReturnItems.Location = new System.Drawing.Point(0, 0);
            this.dgvVendorReturnItems.MultiSelect = false;
            this.dgvVendorReturnItems.Name = "dgvVendorReturnItems";
            this.dgvVendorReturnItems.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendorReturnItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvVendorReturnItems.RowHeadersVisible = false;
            this.dgvVendorReturnItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendorReturnItems.Size = new System.Drawing.Size(1204, 98);
            this.dgvVendorReturnItems.TabIndex = 1;
            this.dgvVendorReturnItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVendorReturnItems_DataError);
            // 
            // sVVRDocDetailsBindingSource
            // 
            this.sVVRDocDetailsBindingSource.DataMember = "SV_VR_Doc_Details";
            this.sVVRDocDetailsBindingSource.DataSource = this.complaints;
            // 
            // toolStripPrinters
            // 
            this.toolStripPrinters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPrinters,
            this.cmbPrinters});
            this.toolStripPrinters.Location = new System.Drawing.Point(0, 0);
            this.toolStripPrinters.Name = "toolStripPrinters";
            this.toolStripPrinters.Size = new System.Drawing.Size(1204, 25);
            this.toolStripPrinters.TabIndex = 1;
            this.toolStripPrinters.Text = "toolStrip1";
            // 
            // lblPrinters
            // 
            this.lblPrinters.ForeColor = System.Drawing.Color.Blue;
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(58, 22);
            this.lblPrinters.Text = "Принтер:";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(200, 25);
            // 
            // sV_VR_Docs_By_VendorTableAdapter
            // 
            this.sV_VR_Docs_By_VendorTableAdapter.ClearBeforeFill = true;
            // 
            // sV_VR_Doc_DetailsTableAdapter
            // 
            this.sV_VR_Doc_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 133;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 63;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N6";
            this.volumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Объем, м³";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 78;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 91;
            // 
            // boxBarWEDataGridViewTextBoxColumn
            // 
            this.boxBarWEDataGridViewTextBoxColumn.DataPropertyName = "Box_Bar_WE";
            this.boxBarWEDataGridViewTextBoxColumn.HeaderText = "Ш/К БЭ";
            this.boxBarWEDataGridViewTextBoxColumn.Name = "boxBarWEDataGridViewTextBoxColumn";
            this.boxBarWEDataGridViewTextBoxColumn.ReadOnly = true;
            this.boxBarWEDataGridViewTextBoxColumn.Width = 65;
            // 
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            this.uOMDataGridViewTextBoxColumn.ReadOnly = true;
            this.uOMDataGridViewTextBoxColumn.Width = 47;
            // 
            // Location_ID
            // 
            this.Location_ID.DataPropertyName = "Location_ID";
            this.Location_ID.HeaderText = "Место";
            this.Location_ID.Name = "Location_ID";
            this.Location_ID.ReadOnly = true;
            this.Location_ID.Width = 64;
            // 
            // Batch_ID
            // 
            this.Batch_ID.DataPropertyName = "Batch_ID";
            this.Batch_ID.HeaderText = "Партия";
            this.Batch_ID.Name = "Batch_ID";
            this.Batch_ID.ReadOnly = true;
            this.Batch_ID.Width = 69;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.DataPropertyName = "ExpirationDate";
            this.ExpirationDate.HeaderText = "СГ";
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.ReadOnly = true;
            this.ExpirationDate.Width = 45;
            // 
            // Dimension
            // 
            this.Dimension.DataPropertyName = "Dimension";
            this.Dimension.HeaderText = "Габариты,\nсм х см х см";
            this.Dimension.Name = "Dimension";
            this.Dimension.ReadOnly = true;
            this.Dimension.Width = 103;
            // 
            // ShipReturnsToVendorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 481);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "ShipReturnsToVendorWindow";
            this.Text = "ShipReturnsToVendorWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShipReturnsToVendorWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.scVendorReturns.Panel1.ResumeLayout(false);
            this.scVendorReturns.Panel2.ResumeLayout(false);
            this.scVendorReturns.ResumeLayout(false);
            this.scVendorReturnsItems.Panel1.ResumeLayout(false);
            this.scVendorReturnsItems.Panel2.ResumeLayout(false);
            this.scVendorReturnsItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorReturns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVVRDocsByVendorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorReturnItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVVRDocDetailsBindingSource)).EndInit();
            this.toolStripPrinters.ResumeLayout(false);
            this.toolStripPrinters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer scVendorReturns;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvVendorReturnsGroups;
        private System.Windows.Forms.SplitContainer scVendorReturnsItems;
        private System.Windows.Forms.DataGridView dgvVendorReturns;
        private System.Windows.Forms.DataGridView dgvVendorReturnItems;
        private System.Windows.Forms.BindingSource sVVRDocsByVendorBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.SV_VR_Docs_By_VendorTableAdapter sV_VR_Docs_By_VendorTableAdapter;
        private System.Windows.Forms.BindingSource sVVRDocDetailsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.SV_VR_Doc_DetailsTableAdapter sV_VR_Doc_DetailsTableAdapter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowAttachments;
        private System.Windows.Forms.ToolStripButton btnFindVendorReturn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnChangeVendorReturnDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnAddShipmentMethod;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnExportVendorReturnItems;
        private System.Windows.Forms.ToolStripButton btnPrintWaybillReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStrip toolStripPrinters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnPrintDocsPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expectedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dgvcHasAttachedFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSVATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jDEDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountUAHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doc_Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plannerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planReturnDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_PlanReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnFlialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton btnShipVendorReturn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxBarWEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimension;
    }
}