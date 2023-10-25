namespace WMSOffice.Window
{
    partial class InterbranchListWindow
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
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.pnlWarehouseFilter = new System.Windows.Forms.Panel();
            this.lblWarehouseDesc = new System.Windows.Forms.Label();
            this.stbWarehouseID = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouseID = new System.Windows.Forms.Label();
            this.xdgvBranches = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gvPicks = new System.Windows.Forms.DataGridView();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickSlipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mestWorkDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warehouse_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportByOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.interbranch = new WMSOffice.Data.Interbranch();
            this.gvLines = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportByItmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportByFilialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportByOrderTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.ReportByOrderTableAdapter();
            this.reportByItmTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.ReportByItmTableAdapter();
            this.reportByFilialTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.ReportByFilialTableAdapter();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.pnlWarehouseFilter.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPicks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportByOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportByItmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportByFilialBindingSource)).BeginInit();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.pnlWarehouseFilter);
            this.scContent.Panel1.Controls.Add(this.xdgvBranches);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.splitContainer2);
            this.scContent.Size = new System.Drawing.Size(1284, 392);
            this.scContent.SplitterDistance = 135;
            this.scContent.TabIndex = 1;
            // 
            // pnlWarehouseFilter
            // 
            this.pnlWarehouseFilter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlWarehouseFilter.Controls.Add(this.lblWarehouseDesc);
            this.pnlWarehouseFilter.Controls.Add(this.stbWarehouseID);
            this.pnlWarehouseFilter.Controls.Add(this.lblWarehouseID);
            this.pnlWarehouseFilter.Location = new System.Drawing.Point(16, 41);
            this.pnlWarehouseFilter.Name = "pnlWarehouseFilter";
            this.pnlWarehouseFilter.Size = new System.Drawing.Size(180, 48);
            this.pnlWarehouseFilter.TabIndex = 4;
            // 
            // lblWarehouseDesc
            // 
            this.lblWarehouseDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarehouseDesc.AutoSize = true;
            this.lblWarehouseDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseDesc.Location = new System.Drawing.Point(59, 29);
            this.lblWarehouseDesc.Name = "lblWarehouseDesc";
            this.lblWarehouseDesc.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseDesc.TabIndex = 2;
            // 
            // stbWarehouseID
            // 
            this.stbWarehouseID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stbWarehouseID.Location = new System.Drawing.Point(62, 5);
            this.stbWarehouseID.Name = "stbWarehouseID";
            this.stbWarehouseID.ReadOnly = false;
            this.stbWarehouseID.Size = new System.Drawing.Size(110, 20);
            this.stbWarehouseID.TabIndex = 1;
            this.stbWarehouseID.UserID = ((long)(0));
            this.stbWarehouseID.Value = null;
            this.stbWarehouseID.ValueReferenceQuery = null;
            // 
            // lblWarehouseID
            // 
            this.lblWarehouseID.AutoSize = true;
            this.lblWarehouseID.Location = new System.Drawing.Point(3, 5);
            this.lblWarehouseID.Name = "lblWarehouseID";
            this.lblWarehouseID.Size = new System.Drawing.Size(55, 26);
            this.lblWarehouseID.TabIndex = 0;
            this.lblWarehouseID.Text = "Склад \r\nотгрузки:";
            // 
            // xdgvBranches
            // 
            this.xdgvBranches.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvBranches.ContextMenuStrip = this.contextMenuStrip;
            this.xdgvBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvBranches.LargeAmountOfData = false;
            this.xdgvBranches.Location = new System.Drawing.Point(0, 0);
            this.xdgvBranches.Name = "xdgvBranches";
            this.xdgvBranches.RowHeadersVisible = false;
            this.xdgvBranches.Size = new System.Drawing.Size(1284, 135);
            this.xdgvBranches.TabIndex = 5;
            this.xdgvBranches.UserID = ((long)(0));
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.экспортВExcelToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(148, 48);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(147, 22);
            this.miRefresh.Text = "Обновить";
            this.miRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // экспортВExcelToolStripMenuItem
            // 
            this.экспортВExcelToolStripMenuItem.Image = global::WMSOffice.Properties.Resources.Excel;
            this.экспортВExcelToolStripMenuItem.Name = "экспортВExcelToolStripMenuItem";
            this.экспортВExcelToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.экспортВExcelToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.экспортВExcelToolStripMenuItem.Text = "Экспорт";
            this.экспортВExcelToolStripMenuItem.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gvPicks);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gvLines);
            this.splitContainer2.Size = new System.Drawing.Size(1284, 253);
            this.splitContainer2.SplitterDistance = 144;
            this.splitContainer2.TabIndex = 0;
            // 
            // gvPicks
            // 
            this.gvPicks.AllowUserToAddRows = false;
            this.gvPicks.AllowUserToDeleteRows = false;
            this.gvPicks.AllowUserToResizeRows = false;
            this.gvPicks.AutoGenerateColumns = false;
            this.gvPicks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPicks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.pickSlipDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.sectorDataGridViewTextBoxColumn,
            this.mestDataGridViewTextBoxColumn,
            this.mestWorkDataGridViewTextBoxColumn1,
            this.percDataGridViewTextBoxColumn1,
            this.Warehouse_from});
            this.gvPicks.DataSource = this.reportByOrderBindingSource;
            this.gvPicks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPicks.Location = new System.Drawing.Point(0, 0);
            this.gvPicks.Name = "gvPicks";
            this.gvPicks.ReadOnly = true;
            this.gvPicks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPicks.Size = new System.Drawing.Size(1284, 144);
            this.gvPicks.TabIndex = 1;
            this.gvPicks.SelectionChanged += new System.EventHandler(this.gvPicks_SelectionChanged);
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIDDataGridViewTextBoxColumn.Width = 76;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTypeDataGridViewTextBoxColumn.Width = 51;
            // 
            // pickSlipDataGridViewTextBoxColumn
            // 
            this.pickSlipDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pickSlipDataGridViewTextBoxColumn.DataPropertyName = "PickSlip";
            this.pickSlipDataGridViewTextBoxColumn.HeaderText = "№ сборочного";
            this.pickSlipDataGridViewTextBoxColumn.Name = "pickSlipDataGridViewTextBoxColumn";
            this.pickSlipDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickSlipDataGridViewTextBoxColumn.Width = 96;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 66;
            // 
            // sectorDataGridViewTextBoxColumn
            // 
            this.sectorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sectorDataGridViewTextBoxColumn.DataPropertyName = "sector";
            this.sectorDataGridViewTextBoxColumn.HeaderText = "Сектор";
            this.sectorDataGridViewTextBoxColumn.Name = "sectorDataGridViewTextBoxColumn";
            this.sectorDataGridViewTextBoxColumn.ReadOnly = true;
            this.sectorDataGridViewTextBoxColumn.Width = 68;
            // 
            // mestDataGridViewTextBoxColumn
            // 
            this.mestDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mestDataGridViewTextBoxColumn.DataPropertyName = "Mest";
            this.mestDataGridViewTextBoxColumn.HeaderText = "В отделах";
            this.mestDataGridViewTextBoxColumn.Name = "mestDataGridViewTextBoxColumn";
            this.mestDataGridViewTextBoxColumn.ReadOnly = true;
            this.mestDataGridViewTextBoxColumn.Width = 76;
            // 
            // mestWorkDataGridViewTextBoxColumn1
            // 
            this.mestWorkDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mestWorkDataGridViewTextBoxColumn1.DataPropertyName = "MestWork";
            this.mestWorkDataGridViewTextBoxColumn1.HeaderText = "Укомплект.";
            this.mestWorkDataGridViewTextBoxColumn1.Name = "mestWorkDataGridViewTextBoxColumn1";
            this.mestWorkDataGridViewTextBoxColumn1.ReadOnly = true;
            this.mestWorkDataGridViewTextBoxColumn1.Width = 92;
            // 
            // percDataGridViewTextBoxColumn1
            // 
            this.percDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.percDataGridViewTextBoxColumn1.DataPropertyName = "Perc";
            dataGridViewCellStyle1.Format = "##0%";
            this.percDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.percDataGridViewTextBoxColumn1.HeaderText = "% компл.";
            this.percDataGridViewTextBoxColumn1.Name = "percDataGridViewTextBoxColumn1";
            this.percDataGridViewTextBoxColumn1.ReadOnly = true;
            this.percDataGridViewTextBoxColumn1.Width = 72;
            // 
            // Warehouse_from
            // 
            this.Warehouse_from.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Warehouse_from.DataPropertyName = "Warehouse_from";
            this.Warehouse_from.HeaderText = "Склад - отправитель";
            this.Warehouse_from.Name = "Warehouse_from";
            this.Warehouse_from.ReadOnly = true;
            this.Warehouse_from.Width = 124;
            // 
            // reportByOrderBindingSource
            // 
            this.reportByOrderBindingSource.DataMember = "ReportByOrder";
            this.reportByOrderBindingSource.DataSource = this.interbranch;
            // 
            // interbranch
            // 
            this.interbranch.DataSetName = "Interbranch";
            this.interbranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gvLines
            // 
            this.gvLines.AllowUserToAddRows = false;
            this.gvLines.AllowUserToDeleteRows = false;
            this.gvLines.AllowUserToResizeRows = false;
            this.gvLines.AutoGenerateColumns = false;
            this.gvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.docQtyDataGridViewTextBoxColumn,
            this.WorkQty,
            this.manufacturerDataGridViewTextBoxColumn});
            this.gvLines.DataSource = this.reportByItmBindingSource;
            this.gvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLines.Location = new System.Drawing.Point(0, 0);
            this.gvLines.Name = "gvLines";
            this.gvLines.ReadOnly = true;
            this.gvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLines.Size = new System.Drawing.Size(1284, 105);
            this.gvLines.TabIndex = 1;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 108;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 63;
            // 
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            this.uOMDataGridViewTextBoxColumn.ReadOnly = true;
            this.uOMDataGridViewTextBoxColumn.Width = 47;
            // 
            // docQtyDataGridViewTextBoxColumn
            // 
            this.docQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docQtyDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty";
            this.docQtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.docQtyDataGridViewTextBoxColumn.Name = "docQtyDataGridViewTextBoxColumn";
            this.docQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyDataGridViewTextBoxColumn.Width = 66;
            // 
            // WorkQty
            // 
            this.WorkQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WorkQty.DataPropertyName = "WorkQty";
            this.WorkQty.HeaderText = "Укомпл.";
            this.WorkQty.Name = "WorkQty";
            this.WorkQty.ReadOnly = true;
            this.WorkQty.Width = 75;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 111;
            // 
            // reportByItmBindingSource
            // 
            this.reportByItmBindingSource.DataMember = "ReportByItm";
            this.reportByItmBindingSource.DataSource = this.interbranch;
            // 
            // reportByFilialBindingSource
            // 
            this.reportByFilialBindingSource.DataMember = "ReportByFilial";
            this.reportByFilialBindingSource.DataSource = this.interbranch;
            // 
            // reportByOrderTableAdapter
            // 
            this.reportByOrderTableAdapter.ClearBeforeFill = true;
            // 
            // reportByItmTableAdapter
            // 
            this.reportByItmTableAdapter.ClearBeforeFill = true;
            // 
            // reportByFilialTableAdapter
            // 
            this.reportByFilialTableAdapter.ClearBeforeFill = true;
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnExportToExcel});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1284, 50);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 47);
            this.btnRefresh.Text = "Обновить...";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.ToolTipText = "Обновить...";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(65, 47);
            this.btnExportToExcel.Text = "Экспорт...";
            this.btnExportToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportToExcel.ToolTipText = "Экспорт...";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.scContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 90);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1284, 392);
            this.pnlContent.TabIndex = 3;
            // 
            // InterbranchListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 482);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "InterbranchListWindow";
            this.Text = "InterbranchListWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InterbranchListWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.pnlWarehouseFilter.ResumeLayout(false);
            this.pnlWarehouseFilter.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPicks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportByOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportByItmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportByFilialBindingSource)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView gvPicks;
        private System.Windows.Forms.DataGridView gvLines;
        private WMSOffice.Data.Interbranch interbranch;
        private System.Windows.Forms.BindingSource reportByOrderBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.ReportByOrderTableAdapter reportByOrderTableAdapter;
        private System.Windows.Forms.BindingSource reportByItmBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.ReportByItmTableAdapter reportByItmTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.BindingSource reportByFilialBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.ReportByFilialTableAdapter reportByFilialTableAdapter;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.Panel pnlWarehouseFilter;
        private System.Windows.Forms.Label lblWarehouseDesc;
        private WMSOffice.Controls.SearchTextBox stbWarehouseID;
        private System.Windows.Forms.Label lblWarehouseID;
        private System.Windows.Forms.ToolStripMenuItem экспортВExcelToolStripMenuItem;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvBranches;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickSlipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mestWorkDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn percDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warehouse_from;
    }
}