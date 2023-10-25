namespace WMSOffice.Window
{
    partial class InterbranchReceiveViewWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scOrdersLayout = new System.Windows.Forms.SplitContainer();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.gvLines = new System.Windows.Forms.DataGridView();
            this.colSnowflake = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptsAllDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.interbranch = new WMSOffice.Data.Interbranch();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsRouteListOperationsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnReceiptRouteDoc = new System.Windows.Forms.ToolStripButton();
            this.btnShowRouteDocPhotos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReceipt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.receiptsAllDetailsTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.ReceiptsAllDetailsTableAdapter();
            this.scMainLayout = new System.Windows.Forms.SplitContainer();
            this.xdgvRouteLists = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.iBIRAllReceiptsCarsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receiptsAllTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.ReceiptsAllTableAdapter();
            this.receiptsAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iB_IR_AllReceipts_CarsTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.IB_IR_AllReceipts_CarsTableAdapter();
            this.scOrdersLayout.Panel1.SuspendLayout();
            this.scOrdersLayout.Panel2.SuspendLayout();
            this.scOrdersLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            this.cmDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsAllDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).BeginInit();
            this.toolStripDoc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.scMainLayout.Panel1.SuspendLayout();
            this.scMainLayout.Panel2.SuspendLayout();
            this.scMainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iBIRAllReceiptsCarsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsAllBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // scOrdersLayout
            // 
            this.scOrdersLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOrdersLayout.Location = new System.Drawing.Point(0, 0);
            this.scOrdersLayout.Name = "scOrdersLayout";
            this.scOrdersLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scOrdersLayout.Panel1
            // 
            this.scOrdersLayout.Panel1.Controls.Add(this.xdgvDocs);
            // 
            // scOrdersLayout.Panel2
            // 
            this.scOrdersLayout.Panel2.Controls.Add(this.gvLines);
            this.scOrdersLayout.Size = new System.Drawing.Size(1246, 363);
            this.scOrdersLayout.SplitterDistance = 189;
            this.scOrdersLayout.TabIndex = 1;
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
            this.xdgvDocs.Size = new System.Drawing.Size(1246, 189);
            this.xdgvDocs.TabIndex = 6;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // gvLines
            // 
            this.gvLines.AllowUserToAddRows = false;
            this.gvLines.AllowUserToDeleteRows = false;
            this.gvLines.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gvLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLines.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSnowflake,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.barCodeDataGridViewTextBoxColumn,
            this.actIDDataGridViewTextBoxColumn,
            this.actTypeDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn});
            this.gvLines.ContextMenuStrip = this.cmDocs;
            this.gvLines.DataSource = this.receiptsAllDetailsBindingSource;
            this.gvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvLines.Location = new System.Drawing.Point(0, 0);
            this.gvLines.Name = "gvLines";
            this.gvLines.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvLines.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            this.gvLines.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvLines.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.gvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLines.ShowEditingIcon = false;
            this.gvLines.Size = new System.Drawing.Size(1246, 170);
            this.gvLines.TabIndex = 5;
            this.gvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvLines_DataBindingComplete);
            // 
            // colSnowflake
            // 
            this.colSnowflake.HeaderText = "T";
            this.colSnowflake.Name = "colSnowflake";
            this.colSnowflake.ReadOnly = true;
            this.colSnowflake.Width = 24;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 58;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 131;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 150;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.unitOfMeasureDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 52;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 74;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Штрих-код";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 101;
            // 
            // actIDDataGridViewTextBoxColumn
            // 
            this.actIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.actIDDataGridViewTextBoxColumn.DataPropertyName = "Act_ID";
            this.actIDDataGridViewTextBoxColumn.HeaderText = "Акт";
            this.actIDDataGridViewTextBoxColumn.Name = "actIDDataGridViewTextBoxColumn";
            this.actIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.actIDDataGridViewTextBoxColumn.Width = 56;
            // 
            // actTypeDataGridViewTextBoxColumn
            // 
            this.actTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.actTypeDataGridViewTextBoxColumn.DataPropertyName = "Act_Type";
            this.actTypeDataGridViewTextBoxColumn.HeaderText = "Тип акта";
            this.actTypeDataGridViewTextBoxColumn.Name = "actTypeDataGridViewTextBoxColumn";
            this.actTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.actTypeDataGridViewTextBoxColumn.Width = 92;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 78;
            // 
            // cmDocs
            // 
            this.cmDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh});
            this.cmDocs.Name = "cmDocs";
            this.cmDocs.Size = new System.Drawing.Size(148, 26);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(147, 22);
            this.miRefresh.Text = "&Обновить";
            this.miRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // receiptsAllDetailsBindingSource
            // 
            this.receiptsAllDetailsBindingSource.DataMember = "ReceiptsAllDetails";
            this.receiptsAllDetailsBindingSource.DataSource = this.interbranch;
            // 
            // interbranch
            // 
            this.interbranch.DataSetName = "Interbranch";
            this.interbranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tsRouteListOperationsSeparator,
            this.btnReceiptRouteDoc,
            this.btnShowRouteDocPhotos,
            this.toolStripSeparator2,
            this.btnReceipt,
            this.toolStripSeparator1,
            this.btnExportToExcel});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1246, 55);
            this.toolStripDoc.TabIndex = 4;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список нераспечатанных накладных";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tsRouteListOperationsSeparator
            // 
            this.tsRouteListOperationsSeparator.Name = "tsRouteListOperationsSeparator";
            this.tsRouteListOperationsSeparator.Size = new System.Drawing.Size(6, 55);
            // 
            // btnReceiptRouteDoc
            // 
            this.btnReceiptRouteDoc.Image = global::WMSOffice.Properties.Resources.delivery;
            this.btnReceiptRouteDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReceiptRouteDoc.Name = "btnReceiptRouteDoc";
            this.btnReceiptRouteDoc.Size = new System.Drawing.Size(149, 52);
            this.btnReceiptRouteDoc.Text = "Подтвердить\nприезд машины";
            this.btnReceiptRouteDoc.Click += new System.EventHandler(this.btnReceiptRouteDoc_Click);
            // 
            // btnShowRouteDocPhotos
            // 
            this.btnShowRouteDocPhotos.Image = global::WMSOffice.Properties.Resources.paperclip;
            this.btnShowRouteDocPhotos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowRouteDocPhotos.Name = "btnShowRouteDocPhotos";
            this.btnShowRouteDocPhotos.Size = new System.Drawing.Size(123, 52);
            this.btnShowRouteDocPhotos.Text = "Просмотр\nфотоотчета";
            this.btnShowRouteDocPhotos.Click += new System.EventHandler(this.btnShowRouteDocPhotos_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnReceipt
            // 
            this.btnReceipt.Image = global::WMSOffice.Properties.Resources.in_box;
            this.btnReceipt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(138, 52);
            this.btnReceipt.Text = "Оприходовать\nнакладную";
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(104, 52);
            this.btnExportToExcel.Text = "Экспорт\r\nв Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Location = new System.Drawing.Point(1079, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 42);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(6, 19);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(158, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(9, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(128, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск по № накладной:";
            // 
            // receiptsAllDetailsTableAdapter
            // 
            this.receiptsAllDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // scMainLayout
            // 
            this.scMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainLayout.Location = new System.Drawing.Point(0, 95);
            this.scMainLayout.Name = "scMainLayout";
            this.scMainLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainLayout.Panel1
            // 
            this.scMainLayout.Panel1.Controls.Add(this.xdgvRouteLists);
            // 
            // scMainLayout.Panel2
            // 
            this.scMainLayout.Panel2.Controls.Add(this.scOrdersLayout);
            this.scMainLayout.Size = new System.Drawing.Size(1246, 560);
            this.scMainLayout.SplitterDistance = 193;
            this.scMainLayout.TabIndex = 6;
            // 
            // xdgvRouteLists
            // 
            this.xdgvRouteLists.AllowSort = true;
            this.xdgvRouteLists.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvRouteLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvRouteLists.LargeAmountOfData = false;
            this.xdgvRouteLists.Location = new System.Drawing.Point(0, 0);
            this.xdgvRouteLists.Name = "xdgvRouteLists";
            this.xdgvRouteLists.RowHeadersVisible = false;
            this.xdgvRouteLists.Size = new System.Drawing.Size(1246, 193);
            this.xdgvRouteLists.TabIndex = 7;
            this.xdgvRouteLists.UserID = ((long)(0));
            // 
            // iBIRAllReceiptsCarsBindingSource
            // 
            this.iBIRAllReceiptsCarsBindingSource.DataMember = "IB_IR_AllReceipts_Cars";
            this.iBIRAllReceiptsCarsBindingSource.DataSource = this.interbranch;
            // 
            // receiptsAllTableAdapter
            // 
            this.receiptsAllTableAdapter.ClearBeforeFill = true;
            // 
            // receiptsAllBindingSource
            // 
            this.receiptsAllBindingSource.DataMember = "ReceiptsAll";
            this.receiptsAllBindingSource.DataSource = this.interbranch;
            // 
            // iB_IR_AllReceipts_CarsTableAdapter
            // 
            this.iB_IR_AllReceipts_CarsTableAdapter.ClearBeforeFill = true;
            // 
            // InterbranchReceiveViewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 655);
            this.Controls.Add(this.scMainLayout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripDoc);
            this.Name = "InterbranchReceiveViewWindow";
            this.Text = "* Контроль приемки товара на филиале";
            this.Load += new System.EventHandler(this.InterbranchReceiveViewWindow_Load);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.scMainLayout, 0);
            this.scOrdersLayout.Panel1.ResumeLayout(false);
            this.scOrdersLayout.Panel2.ResumeLayout(false);
            this.scOrdersLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            this.cmDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.receiptsAllDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).EndInit();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.scMainLayout.Panel1.ResumeLayout(false);
            this.scMainLayout.Panel2.ResumeLayout(false);
            this.scMainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iBIRAllReceiptsCarsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsAllBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer scOrdersLayout;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator tsRouteListOperationsSeparator;
        private WMSOffice.Data.Interbranch interbranch;
        private System.Windows.Forms.DataGridView gvLines;
        private System.Windows.Forms.BindingSource receiptsAllDetailsBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.ReceiptsAllDetailsTableAdapter receiptsAllDetailsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip cmDocs;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripButton btnReceipt;
        private System.Windows.Forms.DataGridViewImageColumn colSnowflake;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private System.Windows.Forms.SplitContainer scMainLayout;
        private System.Windows.Forms.ToolStripButton btnReceiptRouteDoc;
        private System.Windows.Forms.ToolStripButton btnShowRouteDocPhotos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private WMSOffice.Data.InterbranchTableAdapters.ReceiptsAllTableAdapter receiptsAllTableAdapter;
        private System.Windows.Forms.BindingSource receiptsAllBindingSource;
        private System.Windows.Forms.BindingSource iBIRAllReceiptsCarsBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.IB_IR_AllReceipts_CarsTableAdapter iB_IR_AllReceipts_CarsTableAdapter;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvRouteLists;
    }
}