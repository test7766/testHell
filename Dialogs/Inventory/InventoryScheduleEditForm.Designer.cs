namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryScheduleEditForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.dtpInventoryPlanTime = new System.Windows.Forms.DateTimePicker();
            this.lblInventoryPlanTime = new System.Windows.Forms.Label();
            this.lblInventoryPlanDate = new System.Windows.Forms.Label();
            this.dtpInventoryPlanDate = new System.Windows.Forms.DateTimePicker();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbInventoryType = new System.Windows.Forms.ComboBox();
            this.inventoriesScheduleTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.lblInventoryType = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.inventoriesScheduleWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.inventoriesScheduleWarehousesTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoriesScheduleWarehousesTableAdapter();
            this.inventoriesScheduleTypesTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoriesScheduleTypesTableAdapter();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.scWarehousesStations = new System.Windows.Forms.SplitContainer();
            this.lblWarehouses = new System.Windows.Forms.Label();
            this.dgvWarehouses = new System.Windows.Forms.DataGridView();
            this.checkedflagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.warehouseidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehousenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoriesScheduleWarehousesElementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scStationsLocations = new System.Windows.Forms.SplitContainer();
            this.lblStations = new System.Windows.Forms.Label();
            this.dgvStations = new System.Windows.Forms.DataGridView();
            this.checkedflagDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stationcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationdescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stagenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placestartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placefinishDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoriesScheduleStationsElementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblLocations = new System.Windows.Forms.Label();
            this.dgvLocations = new System.Windows.Forms.DataGridView();
            this.checkedflagDataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.placecodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.station_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseidDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lmaislDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lmbinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lmla03DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lmla04DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lmla05DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoriesScheduleLocationsElementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoriesScheduleWarehousesElementsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoriesScheduleWarehousesElementsTableAdapter();
            this.inventoriesScheduleLocationsElementsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoriesScheduleLocationsElementsTableAdapter();
            this.inventoriesScheduleStationsElementsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoriesScheduleStationsElementsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleWarehousesBindingSource)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.scWarehousesStations.Panel1.SuspendLayout();
            this.scWarehousesStations.Panel2.SuspendLayout();
            this.scWarehousesStations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleWarehousesElementsBindingSource)).BeginInit();
            this.scStationsLocations.Panel1.SuspendLayout();
            this.scStationsLocations.Panel2.SuspendLayout();
            this.scStationsLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleStationsElementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleLocationsElementsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(11145, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(11235, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 628);
            this.pnlButtons.Size = new System.Drawing.Size(1194, 43);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.dtpInventoryPlanTime);
            this.pnlHeader.Controls.Add(this.lblInventoryPlanTime);
            this.pnlHeader.Controls.Add(this.lblInventoryPlanDate);
            this.pnlHeader.Controls.Add(this.dtpInventoryPlanDate);
            this.pnlHeader.Controls.Add(this.tbDescription);
            this.pnlHeader.Controls.Add(this.lblDescription);
            this.pnlHeader.Controls.Add(this.cmbInventoryType);
            this.pnlHeader.Controls.Add(this.lblInventoryType);
            this.pnlHeader.Controls.Add(this.cmbWarehouse);
            this.pnlHeader.Controls.Add(this.lblWarehouse);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1194, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // dtpInventoryPlanTime
            // 
            this.dtpInventoryPlanTime.CustomFormat = "HH:mm";
            this.dtpInventoryPlanTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInventoryPlanTime.Location = new System.Drawing.Point(309, 64);
            this.dtpInventoryPlanTime.Name = "dtpInventoryPlanTime";
            this.dtpInventoryPlanTime.ShowUpDown = true;
            this.dtpInventoryPlanTime.Size = new System.Drawing.Size(60, 20);
            this.dtpInventoryPlanTime.TabIndex = 9;
            // 
            // lblInventoryPlanTime
            // 
            this.lblInventoryPlanTime.AutoSize = true;
            this.lblInventoryPlanTime.Location = new System.Drawing.Point(260, 68);
            this.lblInventoryPlanTime.Name = "lblInventoryPlanTime";
            this.lblInventoryPlanTime.Size = new System.Drawing.Size(43, 13);
            this.lblInventoryPlanTime.TabIndex = 8;
            this.lblInventoryPlanTime.Text = "Время:";
            // 
            // lblInventoryPlanDate
            // 
            this.lblInventoryPlanDate.AutoSize = true;
            this.lblInventoryPlanDate.Location = new System.Drawing.Point(27, 68);
            this.lblInventoryPlanDate.Name = "lblInventoryPlanDate";
            this.lblInventoryPlanDate.Size = new System.Drawing.Size(36, 13);
            this.lblInventoryPlanDate.TabIndex = 6;
            this.lblInventoryPlanDate.Text = "Дата:";
            // 
            // dtpInventoryPlanDate
            // 
            this.dtpInventoryPlanDate.CustomFormat = "dd.MM.yyyy";
            this.dtpInventoryPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInventoryPlanDate.Location = new System.Drawing.Point(69, 64);
            this.dtpInventoryPlanDate.Name = "dtpInventoryPlanDate";
            this.dtpInventoryPlanDate.Size = new System.Drawing.Size(100, 20);
            this.dtpInventoryPlanDate.TabIndex = 7;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(449, 9);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(733, 47);
            this.tbDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(383, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Описание:";
            // 
            // cmbInventoryType
            // 
            this.cmbInventoryType.DataSource = this.inventoriesScheduleTypesBindingSource;
            this.cmbInventoryType.DisplayMember = "fi_dsc";
            this.cmbInventoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventoryType.FormattingEnabled = true;
            this.cmbInventoryType.Location = new System.Drawing.Point(69, 35);
            this.cmbInventoryType.Name = "cmbInventoryType";
            this.cmbInventoryType.Size = new System.Drawing.Size(300, 21);
            this.cmbInventoryType.TabIndex = 5;
            this.cmbInventoryType.ValueMember = "fi_type";
            // 
            // inventoriesScheduleTypesBindingSource
            // 
            this.inventoriesScheduleTypesBindingSource.DataMember = "InventoriesScheduleTypes";
            this.inventoriesScheduleTypesBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblInventoryType
            // 
            this.lblInventoryType.AutoSize = true;
            this.lblInventoryType.Location = new System.Drawing.Point(34, 39);
            this.lblInventoryType.Name = "lblInventoryType";
            this.lblInventoryType.Size = new System.Drawing.Size(29, 13);
            this.lblInventoryType.TabIndex = 4;
            this.lblInventoryType.Text = "Тип:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DataSource = this.inventoriesScheduleWarehousesBindingSource;
            this.cmbWarehouse.DisplayMember = "Filial_Name";
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(69, 5);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(300, 21);
            this.cmbWarehouse.TabIndex = 1;
            this.cmbWarehouse.ValueMember = "Filial_ID";
            // 
            // inventoriesScheduleWarehousesBindingSource
            // 
            this.inventoriesScheduleWarehousesBindingSource.DataMember = "InventoriesScheduleWarehouses";
            this.inventoriesScheduleWarehousesBindingSource.DataSource = this.inventory;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 9);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(51, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Филиал:";
            // 
            // inventoriesScheduleWarehousesTableAdapter
            // 
            this.inventoriesScheduleWarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // inventoriesScheduleTypesTableAdapter
            // 
            this.inventoriesScheduleTypesTableAdapter.ClearBeforeFill = true;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.tsMain);
            this.pnlContent.Controls.Add(this.scWarehousesStations);
            this.pnlContent.Location = new System.Drawing.Point(0, 96);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1194, 526);
            this.pnlContent.TabIndex = 1;
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1194, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 22);
            this.btnExport.Text = "Экспорт";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // scWarehousesStations
            // 
            this.scWarehousesStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scWarehousesStations.Location = new System.Drawing.Point(0, 28);
            this.scWarehousesStations.Name = "scWarehousesStations";
            // 
            // scWarehousesStations.Panel1
            // 
            this.scWarehousesStations.Panel1.Controls.Add(this.lblWarehouses);
            this.scWarehousesStations.Panel1.Controls.Add(this.dgvWarehouses);
            // 
            // scWarehousesStations.Panel2
            // 
            this.scWarehousesStations.Panel2.Controls.Add(this.scStationsLocations);
            this.scWarehousesStations.Size = new System.Drawing.Size(1194, 498);
            this.scWarehousesStations.SplitterDistance = 222;
            this.scWarehousesStations.TabIndex = 0;
            // 
            // lblWarehouses
            // 
            this.lblWarehouses.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblWarehouses.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWarehouses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarehouses.Location = new System.Drawing.Point(0, 0);
            this.lblWarehouses.Name = "lblWarehouses";
            this.lblWarehouses.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblWarehouses.Size = new System.Drawing.Size(222, 20);
            this.lblWarehouses.TabIndex = 1;
            this.lblWarehouses.Text = "Склады";
            // 
            // dgvWarehouses
            // 
            this.dgvWarehouses.AllowUserToAddRows = false;
            this.dgvWarehouses.AllowUserToDeleteRows = false;
            this.dgvWarehouses.AllowUserToResizeColumns = false;
            this.dgvWarehouses.AllowUserToResizeRows = false;
            this.dgvWarehouses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWarehouses.AutoGenerateColumns = false;
            this.dgvWarehouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedflagDataGridViewCheckBoxColumn,
            this.warehouseidDataGridViewTextBoxColumn,
            this.warehousenameDataGridViewTextBoxColumn});
            this.dgvWarehouses.DataSource = this.inventoriesScheduleWarehousesElementsBindingSource;
            this.dgvWarehouses.Location = new System.Drawing.Point(0, 23);
            this.dgvWarehouses.MultiSelect = false;
            this.dgvWarehouses.Name = "dgvWarehouses";
            this.dgvWarehouses.RowHeadersVisible = false;
            this.dgvWarehouses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouses.Size = new System.Drawing.Size(222, 475);
            this.dgvWarehouses.TabIndex = 0;
            this.dgvWarehouses.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvWarehouses_CellFormatting);
            this.dgvWarehouses.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvWarehouses_CurrentCellDirtyStateChanged);
            this.dgvWarehouses.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvWarehouses_DataError);
            // 
            // checkedflagDataGridViewCheckBoxColumn
            // 
            this.checkedflagDataGridViewCheckBoxColumn.DataPropertyName = "checked_flag";
            this.checkedflagDataGridViewCheckBoxColumn.HeaderText = "";
            this.checkedflagDataGridViewCheckBoxColumn.Name = "checkedflagDataGridViewCheckBoxColumn";
            this.checkedflagDataGridViewCheckBoxColumn.Width = 20;
            // 
            // warehouseidDataGridViewTextBoxColumn
            // 
            this.warehouseidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseidDataGridViewTextBoxColumn.DataPropertyName = "warehouse_id";
            this.warehouseidDataGridViewTextBoxColumn.HeaderText = "Код склада";
            this.warehouseidDataGridViewTextBoxColumn.Name = "warehouseidDataGridViewTextBoxColumn";
            this.warehouseidDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseidDataGridViewTextBoxColumn.Width = 90;
            // 
            // warehousenameDataGridViewTextBoxColumn
            // 
            this.warehousenameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehousenameDataGridViewTextBoxColumn.DataPropertyName = "warehouse_name";
            this.warehousenameDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehousenameDataGridViewTextBoxColumn.Name = "warehousenameDataGridViewTextBoxColumn";
            this.warehousenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehousenameDataGridViewTextBoxColumn.Width = 63;
            // 
            // inventoriesScheduleWarehousesElementsBindingSource
            // 
            this.inventoriesScheduleWarehousesElementsBindingSource.DataMember = "InventoriesScheduleWarehousesElements";
            this.inventoriesScheduleWarehousesElementsBindingSource.DataSource = this.inventory;
            // 
            // scStationsLocations
            // 
            this.scStationsLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scStationsLocations.Location = new System.Drawing.Point(0, 0);
            this.scStationsLocations.Name = "scStationsLocations";
            // 
            // scStationsLocations.Panel1
            // 
            this.scStationsLocations.Panel1.Controls.Add(this.lblStations);
            this.scStationsLocations.Panel1.Controls.Add(this.dgvStations);
            // 
            // scStationsLocations.Panel2
            // 
            this.scStationsLocations.Panel2.Controls.Add(this.lblLocations);
            this.scStationsLocations.Panel2.Controls.Add(this.dgvLocations);
            this.scStationsLocations.Size = new System.Drawing.Size(968, 498);
            this.scStationsLocations.SplitterDistance = 565;
            this.scStationsLocations.TabIndex = 0;
            // 
            // lblStations
            // 
            this.lblStations.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblStations.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStations.Location = new System.Drawing.Point(0, 0);
            this.lblStations.Name = "lblStations";
            this.lblStations.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblStations.Size = new System.Drawing.Size(565, 20);
            this.lblStations.TabIndex = 2;
            this.lblStations.Text = "Станции";
            // 
            // dgvStations
            // 
            this.dgvStations.AllowUserToAddRows = false;
            this.dgvStations.AllowUserToDeleteRows = false;
            this.dgvStations.AllowUserToResizeColumns = false;
            this.dgvStations.AllowUserToResizeRows = false;
            this.dgvStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStations.AutoGenerateColumns = false;
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedflagDataGridViewCheckBoxColumn1,
            this.stationcodeDataGridViewTextBoxColumn,
            this.stationdescriptionDataGridViewTextBoxColumn,
            this.warehouseidDataGridViewTextBoxColumn1,
            this.stagenameDataGridViewTextBoxColumn,
            this.placestartDataGridViewTextBoxColumn,
            this.placefinishDataGridViewTextBoxColumn});
            this.dgvStations.DataSource = this.inventoriesScheduleStationsElementsBindingSource;
            this.dgvStations.Location = new System.Drawing.Point(0, 23);
            this.dgvStations.MultiSelect = false;
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.RowHeadersVisible = false;
            this.dgvStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStations.Size = new System.Drawing.Size(565, 475);
            this.dgvStations.TabIndex = 1;
            this.dgvStations.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStations_CellFormatting);
            this.dgvStations.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvStations_CurrentCellDirtyStateChanged);
            this.dgvStations.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStations_DataError);
            // 
            // checkedflagDataGridViewCheckBoxColumn1
            // 
            this.checkedflagDataGridViewCheckBoxColumn1.DataPropertyName = "checked_flag";
            this.checkedflagDataGridViewCheckBoxColumn1.HeaderText = "";
            this.checkedflagDataGridViewCheckBoxColumn1.Name = "checkedflagDataGridViewCheckBoxColumn1";
            this.checkedflagDataGridViewCheckBoxColumn1.Width = 20;
            // 
            // stationcodeDataGridViewTextBoxColumn
            // 
            this.stationcodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stationcodeDataGridViewTextBoxColumn.DataPropertyName = "station_code";
            this.stationcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К станции";
            this.stationcodeDataGridViewTextBoxColumn.Name = "stationcodeDataGridViewTextBoxColumn";
            this.stationcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.stationcodeDataGridViewTextBoxColumn.Width = 97;
            // 
            // stationdescriptionDataGridViewTextBoxColumn
            // 
            this.stationdescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stationdescriptionDataGridViewTextBoxColumn.DataPropertyName = "station_description";
            this.stationdescriptionDataGridViewTextBoxColumn.HeaderText = "Станция";
            this.stationdescriptionDataGridViewTextBoxColumn.Name = "stationdescriptionDataGridViewTextBoxColumn";
            this.stationdescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.stationdescriptionDataGridViewTextBoxColumn.Width = 74;
            // 
            // warehouseidDataGridViewTextBoxColumn1
            // 
            this.warehouseidDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseidDataGridViewTextBoxColumn1.DataPropertyName = "warehouse_id";
            this.warehouseidDataGridViewTextBoxColumn1.HeaderText = "Код склада";
            this.warehouseidDataGridViewTextBoxColumn1.Name = "warehouseidDataGridViewTextBoxColumn1";
            this.warehouseidDataGridViewTextBoxColumn1.ReadOnly = true;
            this.warehouseidDataGridViewTextBoxColumn1.Width = 90;
            // 
            // stagenameDataGridViewTextBoxColumn
            // 
            this.stagenameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stagenameDataGridViewTextBoxColumn.DataPropertyName = "stage_name";
            this.stagenameDataGridViewTextBoxColumn.HeaderText = "Этаж";
            this.stagenameDataGridViewTextBoxColumn.Name = "stagenameDataGridViewTextBoxColumn";
            this.stagenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.stagenameDataGridViewTextBoxColumn.Width = 58;
            // 
            // placestartDataGridViewTextBoxColumn
            // 
            this.placestartDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placestartDataGridViewTextBoxColumn.DataPropertyName = "place_start";
            this.placestartDataGridViewTextBoxColumn.HeaderText = "Место \"с\"";
            this.placestartDataGridViewTextBoxColumn.Name = "placestartDataGridViewTextBoxColumn";
            this.placestartDataGridViewTextBoxColumn.ReadOnly = true;
            this.placestartDataGridViewTextBoxColumn.Width = 83;
            // 
            // placefinishDataGridViewTextBoxColumn
            // 
            this.placefinishDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placefinishDataGridViewTextBoxColumn.DataPropertyName = "place_finish";
            this.placefinishDataGridViewTextBoxColumn.HeaderText = "Место \"по\"";
            this.placefinishDataGridViewTextBoxColumn.Name = "placefinishDataGridViewTextBoxColumn";
            this.placefinishDataGridViewTextBoxColumn.ReadOnly = true;
            this.placefinishDataGridViewTextBoxColumn.Width = 89;
            // 
            // inventoriesScheduleStationsElementsBindingSource
            // 
            this.inventoriesScheduleStationsElementsBindingSource.DataMember = "InventoriesScheduleStationsElements";
            this.inventoriesScheduleStationsElementsBindingSource.DataSource = this.inventory;
            // 
            // lblLocations
            // 
            this.lblLocations.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblLocations.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLocations.Location = new System.Drawing.Point(0, 0);
            this.lblLocations.Name = "lblLocations";
            this.lblLocations.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblLocations.Size = new System.Drawing.Size(399, 20);
            this.lblLocations.TabIndex = 2;
            this.lblLocations.Text = "Места";
            // 
            // dgvLocations
            // 
            this.dgvLocations.AllowUserToAddRows = false;
            this.dgvLocations.AllowUserToDeleteRows = false;
            this.dgvLocations.AllowUserToResizeColumns = false;
            this.dgvLocations.AllowUserToResizeRows = false;
            this.dgvLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocations.AutoGenerateColumns = false;
            this.dgvLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedflagDataGridViewCheckBoxColumn2,
            this.placecodeDataGridViewTextBoxColumn,
            this.station_code,
            this.warehouseidDataGridViewTextBoxColumn2,
            this.lmaislDataGridViewTextBoxColumn,
            this.lmbinDataGridViewTextBoxColumn,
            this.lmla03DataGridViewTextBoxColumn,
            this.lmla04DataGridViewTextBoxColumn,
            this.lmla05DataGridViewTextBoxColumn,
            this.routeidDataGridViewTextBoxColumn});
            this.dgvLocations.DataSource = this.inventoriesScheduleLocationsElementsBindingSource;
            this.dgvLocations.Location = new System.Drawing.Point(0, 23);
            this.dgvLocations.MultiSelect = false;
            this.dgvLocations.Name = "dgvLocations";
            this.dgvLocations.RowHeadersVisible = false;
            this.dgvLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocations.Size = new System.Drawing.Size(399, 475);
            this.dgvLocations.TabIndex = 1;
            this.dgvLocations.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLocations_CellFormatting);
            this.dgvLocations.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLocations_CurrentCellDirtyStateChanged);
            this.dgvLocations.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvLocations_DataError);
            // 
            // checkedflagDataGridViewCheckBoxColumn2
            // 
            this.checkedflagDataGridViewCheckBoxColumn2.DataPropertyName = "checked_flag";
            this.checkedflagDataGridViewCheckBoxColumn2.HeaderText = "";
            this.checkedflagDataGridViewCheckBoxColumn2.Name = "checkedflagDataGridViewCheckBoxColumn2";
            this.checkedflagDataGridViewCheckBoxColumn2.Width = 20;
            // 
            // placecodeDataGridViewTextBoxColumn
            // 
            this.placecodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placecodeDataGridViewTextBoxColumn.DataPropertyName = "place_code";
            this.placecodeDataGridViewTextBoxColumn.HeaderText = "Место";
            this.placecodeDataGridViewTextBoxColumn.Name = "placecodeDataGridViewTextBoxColumn";
            this.placecodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.placecodeDataGridViewTextBoxColumn.Width = 64;
            // 
            // station_code
            // 
            this.station_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.station_code.DataPropertyName = "station_code";
            this.station_code.HeaderText = "Ш/К станции";
            this.station_code.Name = "station_code";
            this.station_code.ReadOnly = true;
            this.station_code.Width = 97;
            // 
            // warehouseidDataGridViewTextBoxColumn2
            // 
            this.warehouseidDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseidDataGridViewTextBoxColumn2.DataPropertyName = "warehouse_id";
            this.warehouseidDataGridViewTextBoxColumn2.HeaderText = "Код склада";
            this.warehouseidDataGridViewTextBoxColumn2.Name = "warehouseidDataGridViewTextBoxColumn2";
            this.warehouseidDataGridViewTextBoxColumn2.ReadOnly = true;
            this.warehouseidDataGridViewTextBoxColumn2.Width = 90;
            // 
            // lmaislDataGridViewTextBoxColumn
            // 
            this.lmaislDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lmaislDataGridViewTextBoxColumn.DataPropertyName = "lmaisl";
            this.lmaislDataGridViewTextBoxColumn.HeaderText = "lmaisl";
            this.lmaislDataGridViewTextBoxColumn.Name = "lmaislDataGridViewTextBoxColumn";
            this.lmaislDataGridViewTextBoxColumn.ReadOnly = true;
            this.lmaislDataGridViewTextBoxColumn.Width = 57;
            // 
            // lmbinDataGridViewTextBoxColumn
            // 
            this.lmbinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lmbinDataGridViewTextBoxColumn.DataPropertyName = "lmbin";
            this.lmbinDataGridViewTextBoxColumn.HeaderText = "lmbin";
            this.lmbinDataGridViewTextBoxColumn.Name = "lmbinDataGridViewTextBoxColumn";
            this.lmbinDataGridViewTextBoxColumn.ReadOnly = true;
            this.lmbinDataGridViewTextBoxColumn.Width = 56;
            // 
            // lmla03DataGridViewTextBoxColumn
            // 
            this.lmla03DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lmla03DataGridViewTextBoxColumn.DataPropertyName = "lmla03";
            this.lmla03DataGridViewTextBoxColumn.HeaderText = "lmla03";
            this.lmla03DataGridViewTextBoxColumn.Name = "lmla03DataGridViewTextBoxColumn";
            this.lmla03DataGridViewTextBoxColumn.ReadOnly = true;
            this.lmla03DataGridViewTextBoxColumn.Width = 62;
            // 
            // lmla04DataGridViewTextBoxColumn
            // 
            this.lmla04DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lmla04DataGridViewTextBoxColumn.DataPropertyName = "lmla04";
            this.lmla04DataGridViewTextBoxColumn.HeaderText = "lmla04";
            this.lmla04DataGridViewTextBoxColumn.Name = "lmla04DataGridViewTextBoxColumn";
            this.lmla04DataGridViewTextBoxColumn.ReadOnly = true;
            this.lmla04DataGridViewTextBoxColumn.Width = 62;
            // 
            // lmla05DataGridViewTextBoxColumn
            // 
            this.lmla05DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lmla05DataGridViewTextBoxColumn.DataPropertyName = "lmla05";
            this.lmla05DataGridViewTextBoxColumn.HeaderText = "lmla05";
            this.lmla05DataGridViewTextBoxColumn.Name = "lmla05DataGridViewTextBoxColumn";
            this.lmla05DataGridViewTextBoxColumn.ReadOnly = true;
            this.lmla05DataGridViewTextBoxColumn.Width = 62;
            // 
            // routeidDataGridViewTextBoxColumn
            // 
            this.routeidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.routeidDataGridViewTextBoxColumn.DataPropertyName = "route_id";
            this.routeidDataGridViewTextBoxColumn.HeaderText = "Маршрут";
            this.routeidDataGridViewTextBoxColumn.Name = "routeidDataGridViewTextBoxColumn";
            this.routeidDataGridViewTextBoxColumn.ReadOnly = true;
            this.routeidDataGridViewTextBoxColumn.Width = 77;
            // 
            // inventoriesScheduleLocationsElementsBindingSource
            // 
            this.inventoriesScheduleLocationsElementsBindingSource.DataMember = "InventoriesScheduleLocationsElements";
            this.inventoriesScheduleLocationsElementsBindingSource.DataSource = this.inventory;
            // 
            // inventoriesScheduleWarehousesElementsTableAdapter
            // 
            this.inventoriesScheduleWarehousesElementsTableAdapter.ClearBeforeFill = true;
            // 
            // inventoriesScheduleLocationsElementsTableAdapter
            // 
            this.inventoriesScheduleLocationsElementsTableAdapter.ClearBeforeFill = true;
            // 
            // inventoriesScheduleStationsElementsTableAdapter
            // 
            this.inventoriesScheduleStationsElementsTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryScheduleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 671);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "InventoryScheduleEditForm";
            this.Text = "Планирование инвентаризации";
            this.Load += new System.EventHandler(this.InventoryScheduleEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryScheduleEditForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleWarehousesBindingSource)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.scWarehousesStations.Panel1.ResumeLayout(false);
            this.scWarehousesStations.Panel2.ResumeLayout(false);
            this.scWarehousesStations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleWarehousesElementsBindingSource)).EndInit();
            this.scStationsLocations.Panel1.ResumeLayout(false);
            this.scStationsLocations.Panel2.ResumeLayout(false);
            this.scStationsLocations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleStationsElementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesScheduleLocationsElementsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbInventoryType;
        private System.Windows.Forms.Label lblInventoryType;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblInventoryPlanTime;
        private System.Windows.Forms.Label lblInventoryPlanDate;
        private System.Windows.Forms.DateTimePicker dtpInventoryPlanDate;
        private System.Windows.Forms.DateTimePicker dtpInventoryPlanTime;
        private System.Windows.Forms.BindingSource inventoriesScheduleWarehousesBindingSource;
        private Data.Inventory inventory;
        private Data.InventoryTableAdapters.InventoriesScheduleWarehousesTableAdapter inventoriesScheduleWarehousesTableAdapter;
        private System.Windows.Forms.BindingSource inventoriesScheduleTypesBindingSource;
        private Data.InventoryTableAdapters.InventoriesScheduleTypesTableAdapter inventoriesScheduleTypesTableAdapter;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvWarehouses;
        private System.Windows.Forms.SplitContainer scWarehousesStations;
        private System.Windows.Forms.SplitContainer scStationsLocations;
        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.DataGridView dgvLocations;
        private System.Windows.Forms.Label lblWarehouses;
        private System.Windows.Forms.Label lblStations;
        private System.Windows.Forms.Label lblLocations;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.BindingSource inventoriesScheduleWarehousesElementsBindingSource;
        private System.Windows.Forms.BindingSource inventoriesScheduleStationsElementsBindingSource;
        private System.Windows.Forms.BindingSource inventoriesScheduleLocationsElementsBindingSource;
        private Data.InventoryTableAdapters.InventoriesScheduleWarehousesElementsTableAdapter inventoriesScheduleWarehousesElementsTableAdapter;
        private Data.InventoryTableAdapters.InventoriesScheduleStationsElementsTableAdapter inventoriesScheduleStationsElementsTableAdapter;
        private Data.InventoryTableAdapters.InventoriesScheduleLocationsElementsTableAdapter inventoriesScheduleLocationsElementsTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedflagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehousenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedflagDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationdescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseidDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stagenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placestartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placefinishDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedflagDataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn placecodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn station_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseidDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn lmaislDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lmbinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lmla03DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lmla04DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lmla05DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routeidDataGridViewTextBoxColumn;
    }
}