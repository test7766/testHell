namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryFilialEditForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFilial = new System.Windows.Forms.Label();
            this.cbFilials = new System.Windows.Forms.ComboBox();
            this.bsFilials = new System.Windows.Forms.BindingSource(this.components);
            this.inventory1 = new WMSOffice.Data.Inventory();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbcTabs = new System.Windows.Forms.TabControl();
            this.tbpPlaces = new System.Windows.Forms.TabPage();
            this.grbFilters = new System.Windows.Forms.GroupBox();
            this.tbxLocationsFilter = new System.Windows.Forms.TextBox();
            this.tbxStagesFilter = new System.Windows.Forms.TextBox();
            this.tbxZonesFilter = new System.Windows.Forms.TextBox();
            this.lblFilterLocations = new System.Windows.Forms.Label();
            this.lblFilterStages = new System.Windows.Forms.Label();
            this.lblFilterZones = new System.Windows.Forms.Label();
            this.spcZones = new System.Windows.Forms.SplitContainer();
            this.lblZones = new System.Windows.Forms.Label();
            this.dgvZones = new System.Windows.Forms.DataGridView();
            this.colCheckedZone = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.zoneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warehouse_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiZones = new System.Windows.Forms.BindingSource(this.components);
            this.spcStagesPlaces = new System.Windows.Forms.SplitContainer();
            this.lblStages = new System.Windows.Forms.Label();
            this.dgvStages = new System.Windows.Forms.DataGridView();
            this.colCheckedStage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stillageIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiStillages = new System.Windows.Forms.BindingSource(this.components);
            this.lblPlaces = new System.Windows.Forms.Label();
            this.dgvPlaces = new System.Windows.Forms.DataGridView();
            this.colCheckedLocations = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.locationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stillage_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiLocations = new System.Windows.Forms.BindingSource(this.components);
            this.lblWarehouses = new System.Windows.Forms.Label();
            this.dgvWarehouses = new System.Windows.Forms.DataGridView();
            this.colCheckedWH = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.warehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiWarehouses = new System.Windows.Forms.BindingSource(this.components);
            this.tbpGoods = new System.Windows.Forms.TabPage();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.Checked_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSPKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storageForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiItems = new System.Windows.Forms.BindingSource(this.components);
            this.grbGoodsFilters = new System.Windows.Forms.GroupBox();
            this.btnExportCachedItems = new System.Windows.Forms.Button();
            this.btnShowCachedItems = new System.Windows.Forms.Button();
            this.tbxItemID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grbPkuFilter = new System.Windows.Forms.GroupBox();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.rbtNotPku = new System.Windows.Forms.RadioButton();
            this.rbtPKU = new System.Windows.Forms.RadioButton();
            this.tbxBasePriceTo = new System.Windows.Forms.TextBox();
            this.lblBasePriceFor = new System.Windows.Forms.Label();
            this.tbxBasePriceFrom = new System.Windows.Forms.TextBox();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.ccbStorageForms = new WMSOffice.Controls.CheckedComboBox();
            this.lblStorageForms = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.ccbCategories = new WMSOffice.Controls.CheckedComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stillageIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zone_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stillageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taFilials = new WMSOffice.Data.InventoryTableAdapters.FilialsTableAdapter();
            this.taFiWarehouses = new WMSOffice.Data.InventoryTableAdapters.FI_WarehousesTableAdapter();
            this.taFiZones = new WMSOffice.Data.InventoryTableAdapters.FI_ZonesTableAdapter();
            this.taFiStillages = new WMSOffice.Data.InventoryTableAdapters.FI_StillagesTableAdapter();
            this.taFiLocations = new WMSOffice.Data.InventoryTableAdapters.FI_LocationsTableAdapter();
            this.taFiItems = new WMSOffice.Data.InventoryTableAdapters.FI_ItemsTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.cbInventoryTypes = new System.Windows.Forms.ComboBox();
            this.fITypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tafITypes = new WMSOffice.Data.InventoryTableAdapters.FI_TypesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory1)).BeginInit();
            this.tbcTabs.SuspendLayout();
            this.tbpPlaces.SuspendLayout();
            this.grbFilters.SuspendLayout();
            this.spcZones.Panel1.SuspendLayout();
            this.spcZones.Panel2.SuspendLayout();
            this.spcZones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiZones)).BeginInit();
            this.spcStagesPlaces.Panel1.SuspendLayout();
            this.spcStagesPlaces.Panel2.SuspendLayout();
            this.spcStagesPlaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiStillages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiWarehouses)).BeginInit();
            this.tbpGoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiItems)).BeginInit();
            this.grbGoodsFilters.SuspendLayout();
            this.grbPkuFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fITypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(997, 707);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblFilial
            // 
            this.lblFilial.AutoSize = true;
            this.lblFilial.Location = new System.Drawing.Point(12, 9);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(51, 13);
            this.lblFilial.TabIndex = 1;
            this.lblFilial.Text = "Филиал:";
            // 
            // cbFilials
            // 
            this.cbFilials.DataSource = this.bsFilials;
            this.cbFilials.DisplayMember = "Filial_Name";
            this.cbFilials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilials.FormattingEnabled = true;
            this.cbFilials.Location = new System.Drawing.Point(88, 6);
            this.cbFilials.Name = "cbFilials";
            this.cbFilials.Size = new System.Drawing.Size(254, 21);
            this.cbFilials.TabIndex = 2;
            this.cbFilials.ValueMember = "Filial_ID";
            // 
            // bsFilials
            // 
            this.bsFilials.DataMember = "Filials";
            this.bsFilials.DataSource = this.inventory1;
            // 
            // inventory1
            // 
            this.inventory1.DataSetName = "Inventory";
            this.inventory1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(392, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Описание:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(468, 6);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(298, 57);
            this.tbxDescription.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 50);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Дата:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(88, 44);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(254, 20);
            this.dtpDate.TabIndex = 8;
            // 
            // tbcTabs
            // 
            this.tbcTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcTabs.Controls.Add(this.tbpPlaces);
            this.tbcTabs.Controls.Add(this.tbpGoods);
            this.tbcTabs.Location = new System.Drawing.Point(24, 87);
            this.tbcTabs.Name = "tbcTabs";
            this.tbcTabs.SelectedIndex = 0;
            this.tbcTabs.Size = new System.Drawing.Size(1057, 614);
            this.tbcTabs.TabIndex = 9;
            this.tbcTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcTabs_Selected);
            // 
            // tbpPlaces
            // 
            this.tbpPlaces.Controls.Add(this.grbFilters);
            this.tbpPlaces.Controls.Add(this.spcZones);
            this.tbpPlaces.Controls.Add(this.lblWarehouses);
            this.tbpPlaces.Controls.Add(this.dgvWarehouses);
            this.tbpPlaces.Location = new System.Drawing.Point(4, 22);
            this.tbpPlaces.Name = "tbpPlaces";
            this.tbpPlaces.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPlaces.Size = new System.Drawing.Size(1049, 588);
            this.tbpPlaces.TabIndex = 0;
            this.tbpPlaces.Text = "Место проведения";
            this.tbpPlaces.UseVisualStyleBackColor = true;
            // 
            // grbFilters
            // 
            this.grbFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFilters.Controls.Add(this.tbxLocationsFilter);
            this.grbFilters.Controls.Add(this.tbxStagesFilter);
            this.grbFilters.Controls.Add(this.tbxZonesFilter);
            this.grbFilters.Controls.Add(this.lblFilterLocations);
            this.grbFilters.Controls.Add(this.lblFilterStages);
            this.grbFilters.Controls.Add(this.lblFilterZones);
            this.grbFilters.Location = new System.Drawing.Point(274, 9);
            this.grbFilters.Name = "grbFilters";
            this.grbFilters.Size = new System.Drawing.Size(769, 166);
            this.grbFilters.TabIndex = 4;
            this.grbFilters.TabStop = false;
            this.grbFilters.Text = "Фильтры";
            // 
            // tbxLocationsFilter
            // 
            this.tbxLocationsFilter.Location = new System.Drawing.Point(105, 111);
            this.tbxLocationsFilter.Name = "tbxLocationsFilter";
            this.tbxLocationsFilter.Size = new System.Drawing.Size(292, 20);
            this.tbxLocationsFilter.TabIndex = 7;
            this.tbxLocationsFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxLocationsFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // tbxStagesFilter
            // 
            this.tbxStagesFilter.Location = new System.Drawing.Point(105, 69);
            this.tbxStagesFilter.Name = "tbxStagesFilter";
            this.tbxStagesFilter.Size = new System.Drawing.Size(292, 20);
            this.tbxStagesFilter.TabIndex = 6;
            this.tbxStagesFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxStagesFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // tbxZonesFilter
            // 
            this.tbxZonesFilter.Location = new System.Drawing.Point(105, 26);
            this.tbxZonesFilter.Name = "tbxZonesFilter";
            this.tbxZonesFilter.Size = new System.Drawing.Size(292, 20);
            this.tbxZonesFilter.TabIndex = 5;
            this.tbxZonesFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxZonesFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // lblFilterLocations
            // 
            this.lblFilterLocations.AutoSize = true;
            this.lblFilterLocations.Location = new System.Drawing.Point(6, 114);
            this.lblFilterLocations.Name = "lblFilterLocations";
            this.lblFilterLocations.Size = new System.Drawing.Size(75, 13);
            this.lblFilterLocations.TabIndex = 4;
            this.lblFilterLocations.Text = "Места (Alt+L):";
            // 
            // lblFilterStages
            // 
            this.lblFilterStages.AutoSize = true;
            this.lblFilterStages.Location = new System.Drawing.Point(6, 72);
            this.lblFilterStages.Name = "lblFilterStages";
            this.lblFilterStages.Size = new System.Drawing.Size(88, 13);
            this.lblFilterStages.TabIndex = 2;
            this.lblFilterStages.Text = "Стелажи (Alt+S):";
            // 
            // lblFilterZones
            // 
            this.lblFilterZones.AutoSize = true;
            this.lblFilterZones.Location = new System.Drawing.Point(6, 29);
            this.lblFilterZones.Name = "lblFilterZones";
            this.lblFilterZones.Size = new System.Drawing.Size(71, 13);
            this.lblFilterZones.TabIndex = 0;
            this.lblFilterZones.Text = "Зоны (Alt+Z):";
            // 
            // spcZones
            // 
            this.spcZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcZones.Location = new System.Drawing.Point(6, 180);
            this.spcZones.Name = "spcZones";
            // 
            // spcZones.Panel1
            // 
            this.spcZones.Panel1.Controls.Add(this.lblZones);
            this.spcZones.Panel1.Controls.Add(this.dgvZones);
            // 
            // spcZones.Panel2
            // 
            this.spcZones.Panel2.Controls.Add(this.spcStagesPlaces);
            this.spcZones.Size = new System.Drawing.Size(1037, 405);
            this.spcZones.SplitterDistance = 382;
            this.spcZones.TabIndex = 3;
            // 
            // lblZones
            // 
            this.lblZones.AutoSize = true;
            this.lblZones.Location = new System.Drawing.Point(3, 9);
            this.lblZones.Name = "lblZones";
            this.lblZones.Size = new System.Drawing.Size(37, 13);
            this.lblZones.TabIndex = 1;
            this.lblZones.Text = "Зоны:";
            // 
            // dgvZones
            // 
            this.dgvZones.AllowUserToAddRows = false;
            this.dgvZones.AllowUserToDeleteRows = false;
            this.dgvZones.AllowUserToResizeRows = false;
            this.dgvZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvZones.AutoGenerateColumns = false;
            this.dgvZones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckedZone,
            this.zoneID,
            this.zoneName,
            this.Warehouse_ID});
            this.dgvZones.DataSource = this.bsFiZones;
            this.dgvZones.Location = new System.Drawing.Point(0, 25);
            this.dgvZones.MultiSelect = false;
            this.dgvZones.Name = "dgvZones";
            this.dgvZones.RowHeadersVisible = false;
            this.dgvZones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZones.Size = new System.Drawing.Size(379, 377);
            this.dgvZones.TabIndex = 0;
            this.dgvZones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvZones_CellPainting);
            this.dgvZones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZones_CellContentClick);
            // 
            // colCheckedZone
            // 
            this.colCheckedZone.DataPropertyName = "Checked";
            this.colCheckedZone.HeaderText = "";
            this.colCheckedZone.Name = "colCheckedZone";
            this.colCheckedZone.Width = 20;
            // 
            // zoneID
            // 
            this.zoneID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.zoneID.DataPropertyName = "Zone_ID";
            this.zoneID.HeaderText = "ID Зоны";
            this.zoneID.Name = "zoneID";
            this.zoneID.ReadOnly = true;
            this.zoneID.Width = 73;
            // 
            // zoneName
            // 
            this.zoneName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.zoneName.DataPropertyName = "Zone_Name";
            this.zoneName.HeaderText = "Зона";
            this.zoneName.Name = "zoneName";
            this.zoneName.ReadOnly = true;
            this.zoneName.Width = 57;
            // 
            // Warehouse_ID
            // 
            this.Warehouse_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Warehouse_ID.DataPropertyName = "Warehouse_ID";
            this.Warehouse_ID.HeaderText = "Склад";
            this.Warehouse_ID.Name = "Warehouse_ID";
            this.Warehouse_ID.ReadOnly = true;
            this.Warehouse_ID.Width = 63;
            // 
            // bsFiZones
            // 
            this.bsFiZones.DataMember = "FI_Zones";
            this.bsFiZones.DataSource = this.inventory1;
            // 
            // spcStagesPlaces
            // 
            this.spcStagesPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcStagesPlaces.Location = new System.Drawing.Point(0, 0);
            this.spcStagesPlaces.Name = "spcStagesPlaces";
            // 
            // spcStagesPlaces.Panel1
            // 
            this.spcStagesPlaces.Panel1.Controls.Add(this.lblStages);
            this.spcStagesPlaces.Panel1.Controls.Add(this.dgvStages);
            // 
            // spcStagesPlaces.Panel2
            // 
            this.spcStagesPlaces.Panel2.Controls.Add(this.lblPlaces);
            this.spcStagesPlaces.Panel2.Controls.Add(this.dgvPlaces);
            this.spcStagesPlaces.Size = new System.Drawing.Size(651, 405);
            this.spcStagesPlaces.SplitterDistance = 316;
            this.spcStagesPlaces.TabIndex = 0;
            // 
            // lblStages
            // 
            this.lblStages.AutoSize = true;
            this.lblStages.Location = new System.Drawing.Point(3, 9);
            this.lblStages.Name = "lblStages";
            this.lblStages.Size = new System.Drawing.Size(54, 13);
            this.lblStages.TabIndex = 1;
            this.lblStages.Text = "Стелажи:";
            // 
            // dgvStages
            // 
            this.dgvStages.AllowUserToAddRows = false;
            this.dgvStages.AllowUserToDeleteRows = false;
            this.dgvStages.AllowUserToResizeRows = false;
            this.dgvStages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStages.AutoGenerateColumns = false;
            this.dgvStages.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckedStage,
            this.stillageIDDataGridViewTextBoxColumn1,
            this.zoneIDDataGridViewTextBoxColumn,
            this.warehouseIDDataGridViewTextBoxColumn});
            this.dgvStages.DataSource = this.bsFiStillages;
            this.dgvStages.Location = new System.Drawing.Point(3, 25);
            this.dgvStages.MultiSelect = false;
            this.dgvStages.Name = "dgvStages";
            this.dgvStages.RowHeadersVisible = false;
            this.dgvStages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStages.Size = new System.Drawing.Size(310, 377);
            this.dgvStages.TabIndex = 0;
            this.dgvStages.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvStages_CellPainting);
            this.dgvStages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStages_CellContentClick);
            // 
            // colCheckedStage
            // 
            this.colCheckedStage.DataPropertyName = "Checked";
            this.colCheckedStage.HeaderText = "";
            this.colCheckedStage.Name = "colCheckedStage";
            this.colCheckedStage.Width = 20;
            // 
            // stillageIDDataGridViewTextBoxColumn1
            // 
            this.stillageIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stillageIDDataGridViewTextBoxColumn1.DataPropertyName = "Stillage_ID";
            this.stillageIDDataGridViewTextBoxColumn1.HeaderText = "Стелаж";
            this.stillageIDDataGridViewTextBoxColumn1.Name = "stillageIDDataGridViewTextBoxColumn1";
            this.stillageIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.stillageIDDataGridViewTextBoxColumn1.Width = 70;
            // 
            // zoneIDDataGridViewTextBoxColumn
            // 
            this.zoneIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.zoneIDDataGridViewTextBoxColumn.DataPropertyName = "Zone_ID";
            this.zoneIDDataGridViewTextBoxColumn.HeaderText = "Зона";
            this.zoneIDDataGridViewTextBoxColumn.Name = "zoneIDDataGridViewTextBoxColumn";
            this.zoneIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.zoneIDDataGridViewTextBoxColumn.Width = 57;
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
            // bsFiStillages
            // 
            this.bsFiStillages.DataMember = "FI_Stillages";
            this.bsFiStillages.DataSource = this.inventory1;
            // 
            // lblPlaces
            // 
            this.lblPlaces.AutoSize = true;
            this.lblPlaces.Location = new System.Drawing.Point(3, 9);
            this.lblPlaces.Name = "lblPlaces";
            this.lblPlaces.Size = new System.Drawing.Size(42, 13);
            this.lblPlaces.TabIndex = 1;
            this.lblPlaces.Text = "Места:";
            // 
            // dgvPlaces
            // 
            this.dgvPlaces.AllowUserToAddRows = false;
            this.dgvPlaces.AllowUserToDeleteRows = false;
            this.dgvPlaces.AllowUserToResizeRows = false;
            this.dgvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlaces.AutoGenerateColumns = false;
            this.dgvPlaces.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPlaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckedLocations,
            this.locationID,
            this.Stillage_ID,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvPlaces.DataSource = this.bsFiLocations;
            this.dgvPlaces.Location = new System.Drawing.Point(4, 25);
            this.dgvPlaces.MultiSelect = false;
            this.dgvPlaces.Name = "dgvPlaces";
            this.dgvPlaces.RowHeadersVisible = false;
            this.dgvPlaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlaces.Size = new System.Drawing.Size(327, 377);
            this.dgvPlaces.TabIndex = 0;
            this.dgvPlaces.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPlaces_CellPainting);
            // 
            // colCheckedLocations
            // 
            this.colCheckedLocations.DataPropertyName = "Checked";
            this.colCheckedLocations.HeaderText = "";
            this.colCheckedLocations.Name = "colCheckedLocations";
            this.colCheckedLocations.Width = 20;
            // 
            // locationID
            // 
            this.locationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationID.DataPropertyName = "Location_ID";
            this.locationID.HeaderText = "Место";
            this.locationID.Name = "locationID";
            this.locationID.ReadOnly = true;
            this.locationID.Width = 64;
            // 
            // Stillage_ID
            // 
            this.Stillage_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Stillage_ID.DataPropertyName = "Stillage_ID";
            this.Stillage_ID.HeaderText = "Стелаж";
            this.Stillage_ID.Name = "Stillage_ID";
            this.Stillage_ID.ReadOnly = true;
            this.Stillage_ID.Width = 70;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Zone_ID";
            this.dataGridViewTextBoxColumn8.HeaderText = "Зона";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 57;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Warehouse_ID";
            this.dataGridViewTextBoxColumn9.HeaderText = "Склад";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 63;
            // 
            // bsFiLocations
            // 
            this.bsFiLocations.DataMember = "FI_Locations";
            this.bsFiLocations.DataSource = this.inventory1;
            // 
            // lblWarehouses
            // 
            this.lblWarehouses.AutoSize = true;
            this.lblWarehouses.Location = new System.Drawing.Point(3, 8);
            this.lblWarehouses.Name = "lblWarehouses";
            this.lblWarehouses.Size = new System.Drawing.Size(49, 13);
            this.lblWarehouses.TabIndex = 2;
            this.lblWarehouses.Text = "Склады:";
            // 
            // dgvWarehouses
            // 
            this.dgvWarehouses.AllowUserToAddRows = false;
            this.dgvWarehouses.AllowUserToDeleteRows = false;
            this.dgvWarehouses.AllowUserToResizeRows = false;
            this.dgvWarehouses.AutoGenerateColumns = false;
            this.dgvWarehouses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvWarehouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckedWH,
            this.warehouseID,
            this.warehouseName});
            this.dgvWarehouses.DataSource = this.bsFiWarehouses;
            this.dgvWarehouses.Location = new System.Drawing.Point(6, 24);
            this.dgvWarehouses.MultiSelect = false;
            this.dgvWarehouses.Name = "dgvWarehouses";
            this.dgvWarehouses.RowHeadersVisible = false;
            this.dgvWarehouses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouses.Size = new System.Drawing.Size(262, 150);
            this.dgvWarehouses.TabIndex = 1;
            this.dgvWarehouses.VirtualMode = true;
            this.dgvWarehouses.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvWarehouses_CellPainting);
            this.dgvWarehouses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouses_CellContentClick);
            // 
            // colCheckedWH
            // 
            this.colCheckedWH.DataPropertyName = "Checked";
            this.colCheckedWH.HeaderText = "";
            this.colCheckedWH.Name = "colCheckedWH";
            this.colCheckedWH.Width = 20;
            // 
            // warehouseID
            // 
            this.warehouseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseID.DataPropertyName = "Warehouse_ID";
            this.warehouseID.HeaderText = "ID склада";
            this.warehouseID.Name = "warehouseID";
            this.warehouseID.ReadOnly = true;
            this.warehouseID.Width = 76;
            // 
            // warehouseName
            // 
            this.warehouseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseName.DataPropertyName = "Warehouse_Name";
            this.warehouseName.HeaderText = "Название склада";
            this.warehouseName.Name = "warehouseName";
            this.warehouseName.ReadOnly = true;
            this.warehouseName.Width = 111;
            // 
            // bsFiWarehouses
            // 
            this.bsFiWarehouses.DataMember = "FI_Warehouses";
            this.bsFiWarehouses.DataSource = this.inventory1;
            // 
            // tbpGoods
            // 
            this.tbpGoods.Controls.Add(this.dgvItems);
            this.tbpGoods.Controls.Add(this.grbGoodsFilters);
            this.tbpGoods.Location = new System.Drawing.Point(4, 22);
            this.tbpGoods.Name = "tbpGoods";
            this.tbpGoods.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGoods.Size = new System.Drawing.Size(1049, 588);
            this.tbpGoods.TabIndex = 1;
            this.tbpGoods.Text = "Товары";
            this.tbpGoods.UseVisualStyleBackColor = true;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked_Flag,
            this.itemID,
            this.itemName,
            this.iSPKU,
            this.salesCategory,
            this.storageForm,
            this.makerID,
            this.makerName,
            this.vendorID,
            this.vendorName,
            this.basePrice});
            this.dgvItems.DataSource = this.bsFiItems;
            this.dgvItems.Location = new System.Drawing.Point(6, 165);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(909, 417);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvItems_DataBindingComplete);
            // 
            // Checked_Flag
            // 
            this.Checked_Flag.DataPropertyName = "Checked";
            this.Checked_Flag.HeaderText = "";
            this.Checked_Flag.Name = "Checked_Flag";
            this.Checked_Flag.Width = 20;
            // 
            // itemID
            // 
            this.itemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemID.DataPropertyName = "Item_ID";
            this.itemID.HeaderText = "ID товара";
            this.itemID.Name = "itemID";
            this.itemID.ReadOnly = true;
            this.itemID.Width = 75;
            // 
            // itemName
            // 
            this.itemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemName.DataPropertyName = "Item_Name";
            this.itemName.HeaderText = "Название товара";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 110;
            // 
            // iSPKU
            // 
            this.iSPKU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iSPKU.DataPropertyName = "IS_PKU";
            this.iSPKU.HeaderText = "ПКУ";
            this.iSPKU.Name = "iSPKU";
            this.iSPKU.ReadOnly = true;
            this.iSPKU.Width = 55;
            // 
            // salesCategory
            // 
            this.salesCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.salesCategory.DataPropertyName = "Sales_Category";
            this.salesCategory.HeaderText = "Категория";
            this.salesCategory.Name = "salesCategory";
            this.salesCategory.ReadOnly = true;
            this.salesCategory.Width = 85;
            // 
            // storageForm
            // 
            this.storageForm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.storageForm.DataPropertyName = "Storage_Form";
            this.storageForm.HeaderText = "Форма хранения";
            this.storageForm.Name = "storageForm";
            this.storageForm.ReadOnly = true;
            this.storageForm.Width = 109;
            // 
            // makerID
            // 
            this.makerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.makerID.DataPropertyName = "Maker_ID";
            this.makerID.HeaderText = "ID производителя";
            this.makerID.Name = "makerID";
            this.makerID.ReadOnly = true;
            this.makerID.Width = 113;
            // 
            // makerName
            // 
            this.makerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.makerName.DataPropertyName = "Maker_Name";
            this.makerName.HeaderText = "Производитель";
            this.makerName.Name = "makerName";
            this.makerName.ReadOnly = true;
            this.makerName.Width = 111;
            // 
            // vendorID
            // 
            this.vendorID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorID.DataPropertyName = "Vendor_ID";
            this.vendorID.HeaderText = "ID поставщика";
            this.vendorID.Name = "vendorID";
            this.vendorID.ReadOnly = true;
            this.vendorID.Width = 99;
            // 
            // vendorName
            // 
            this.vendorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorName.DataPropertyName = "Vendor_Name";
            this.vendorName.HeaderText = "Поставщик";
            this.vendorName.Name = "vendorName";
            this.vendorName.ReadOnly = true;
            this.vendorName.Width = 90;
            // 
            // basePrice
            // 
            this.basePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.basePrice.DataPropertyName = "Base_Price";
            this.basePrice.HeaderText = "Базовая цена";
            this.basePrice.Name = "basePrice";
            this.basePrice.ReadOnly = true;
            this.basePrice.Width = 94;
            // 
            // bsFiItems
            // 
            this.bsFiItems.DataMember = "FI_Items";
            this.bsFiItems.DataSource = this.inventory1;
            // 
            // grbGoodsFilters
            // 
            this.grbGoodsFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbGoodsFilters.Controls.Add(this.btnExportCachedItems);
            this.grbGoodsFilters.Controls.Add(this.btnShowCachedItems);
            this.grbGoodsFilters.Controls.Add(this.tbxItemID);
            this.grbGoodsFilters.Controls.Add(this.label1);
            this.grbGoodsFilters.Controls.Add(this.btnRefresh);
            this.grbGoodsFilters.Controls.Add(this.grbPkuFilter);
            this.grbGoodsFilters.Controls.Add(this.tbxBasePriceTo);
            this.grbGoodsFilters.Controls.Add(this.lblBasePriceFor);
            this.grbGoodsFilters.Controls.Add(this.tbxBasePriceFrom);
            this.grbGoodsFilters.Controls.Add(this.lblBasePrice);
            this.grbGoodsFilters.Controls.Add(this.ccbStorageForms);
            this.grbGoodsFilters.Controls.Add(this.lblStorageForms);
            this.grbGoodsFilters.Controls.Add(this.lblCategory);
            this.grbGoodsFilters.Controls.Add(this.ccbCategories);
            this.grbGoodsFilters.Location = new System.Drawing.Point(6, 6);
            this.grbGoodsFilters.Name = "grbGoodsFilters";
            this.grbGoodsFilters.Size = new System.Drawing.Size(909, 153);
            this.grbGoodsFilters.TabIndex = 0;
            this.grbGoodsFilters.TabStop = false;
            this.grbGoodsFilters.Text = "Фильтры";
            // 
            // btnExportCachedItems
            // 
            this.btnExportCachedItems.Enabled = false;
            this.btnExportCachedItems.Image = global::WMSOffice.Properties.Resources.accept_16;
            this.btnExportCachedItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportCachedItems.Location = new System.Drawing.Point(434, 115);
            this.btnExportCachedItems.Name = "btnExportCachedItems";
            this.btnExportCachedItems.Size = new System.Drawing.Size(75, 23);
            this.btnExportCachedItems.TabIndex = 13;
            this.btnExportCachedItems.Text = "Экспорт";
            this.btnExportCachedItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportCachedItems.UseVisualStyleBackColor = true;
            this.btnExportCachedItems.Click += new System.EventHandler(this.btnExportCachedItems_Click);
            // 
            // btnShowCachedItems
            // 
            this.btnShowCachedItems.Enabled = false;
            this.btnShowCachedItems.Location = new System.Drawing.Point(268, 115);
            this.btnShowCachedItems.Name = "btnShowCachedItems";
            this.btnShowCachedItems.Size = new System.Drawing.Size(150, 23);
            this.btnShowCachedItems.TabIndex = 12;
            this.btnShowCachedItems.Text = "Показать выбранные";
            this.btnShowCachedItems.UseVisualStyleBackColor = true;
            this.btnShowCachedItems.Click += new System.EventHandler(this.btnShowCachedItems_Click);
            // 
            // tbxItemID
            // 
            this.tbxItemID.Location = new System.Drawing.Point(348, 85);
            this.tbxItemID.Name = "tbxItemID";
            this.tbxItemID.Size = new System.Drawing.Size(70, 20);
            this.tbxItemID.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Код товара";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(9, 115);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grbPkuFilter
            // 
            this.grbPkuFilter.Controls.Add(this.rbtAll);
            this.grbPkuFilter.Controls.Add(this.rbtNotPku);
            this.grbPkuFilter.Controls.Add(this.rbtPKU);
            this.grbPkuFilter.Location = new System.Drawing.Point(434, 19);
            this.grbPkuFilter.Name = "grbPkuFilter";
            this.grbPkuFilter.Size = new System.Drawing.Size(214, 83);
            this.grbPkuFilter.TabIndex = 10;
            this.grbPkuFilter.TabStop = false;
            this.grbPkuFilter.Text = "Фильтр по ПКУ";
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Checked = true;
            this.rbtAll.Location = new System.Drawing.Point(5, 61);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(43, 17);
            this.rbtAll.TabIndex = 2;
            this.rbtAll.TabStop = true;
            this.rbtAll.Text = "все";
            this.rbtAll.UseVisualStyleBackColor = true;
            // 
            // rbtNotPku
            // 
            this.rbtNotPku.AutoSize = true;
            this.rbtNotPku.Location = new System.Drawing.Point(5, 40);
            this.rbtNotPku.Name = "rbtNotPku";
            this.rbtNotPku.Size = new System.Drawing.Size(101, 17);
            this.rbtNotPku.TabIndex = 1;
            this.rbtNotPku.Text = "только не ПКУ";
            this.rbtNotPku.UseVisualStyleBackColor = true;
            // 
            // rbtPKU
            // 
            this.rbtPKU.AutoSize = true;
            this.rbtPKU.Location = new System.Drawing.Point(5, 19);
            this.rbtPKU.Name = "rbtPKU";
            this.rbtPKU.Size = new System.Drawing.Size(86, 17);
            this.rbtPKU.TabIndex = 0;
            this.rbtPKU.Text = "только ПКУ";
            this.rbtPKU.UseVisualStyleBackColor = true;
            // 
            // tbxBasePriceTo
            // 
            this.tbxBasePriceTo.Location = new System.Drawing.Point(199, 85);
            this.tbxBasePriceTo.Name = "tbxBasePriceTo";
            this.tbxBasePriceTo.Size = new System.Drawing.Size(70, 20);
            this.tbxBasePriceTo.TabIndex = 7;
            // 
            // lblBasePriceFor
            // 
            this.lblBasePriceFor.AutoSize = true;
            this.lblBasePriceFor.Location = new System.Drawing.Point(174, 89);
            this.lblBasePriceFor.Name = "lblBasePriceFor";
            this.lblBasePriceFor.Size = new System.Drawing.Size(19, 13);
            this.lblBasePriceFor.TabIndex = 6;
            this.lblBasePriceFor.Text = "по";
            // 
            // tbxBasePriceFrom
            // 
            this.tbxBasePriceFrom.Location = new System.Drawing.Point(98, 85);
            this.tbxBasePriceFrom.Name = "tbxBasePriceFrom";
            this.tbxBasePriceFrom.Size = new System.Drawing.Size(70, 20);
            this.tbxBasePriceFrom.TabIndex = 5;
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Location = new System.Drawing.Point(6, 89);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(86, 13);
            this.lblBasePrice.TabIndex = 4;
            this.lblBasePrice.Text = "Базовая цена с";
            // 
            // ccbStorageForms
            // 
            this.ccbStorageForms.CheckOnClick = true;
            this.ccbStorageForms.DisplayMember = "Name";
            this.ccbStorageForms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbStorageForms.DropDownHeight = 1;
            this.ccbStorageForms.FormattingEnabled = true;
            this.ccbStorageForms.IntegralHeight = false;
            this.ccbStorageForms.Location = new System.Drawing.Point(121, 53);
            this.ccbStorageForms.MaxDropDownItems = 30;
            this.ccbStorageForms.Name = "ccbStorageForms";
            this.ccbStorageForms.Size = new System.Drawing.Size(297, 21);
            this.ccbStorageForms.TabIndex = 3;
            this.ccbStorageForms.ValueSeparator = ", ";
            // 
            // lblStorageForms
            // 
            this.lblStorageForms.AutoSize = true;
            this.lblStorageForms.Location = new System.Drawing.Point(6, 56);
            this.lblStorageForms.Name = "lblStorageForms";
            this.lblStorageForms.Size = new System.Drawing.Size(99, 13);
            this.lblStorageForms.TabIndex = 2;
            this.lblStorageForms.Text = "Формы хранения:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(6, 25);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Категории:";
            // 
            // ccbCategories
            // 
            this.ccbCategories.CheckOnClick = true;
            this.ccbCategories.DisplayMember = "Name";
            this.ccbCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbCategories.DropDownHeight = 1;
            this.ccbCategories.FormattingEnabled = true;
            this.ccbCategories.IntegralHeight = false;
            this.ccbCategories.Location = new System.Drawing.Point(121, 22);
            this.ccbCategories.MaxDropDownItems = 30;
            this.ccbCategories.Name = "ccbCategories";
            this.ccbCategories.Size = new System.Drawing.Size(297, 21);
            this.ccbCategories.TabIndex = 0;
            this.ccbCategories.ValueSeparator = ", ";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(901, 707);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Zone_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID Зоны";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Zone_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Зона";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Stillage_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Стелаж";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Location_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "Место";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Warehouse_ID";
            this.dataGridViewTextBoxColumn5.HeaderText = "ID склада";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Warehouse_Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "Название склада";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "Checked";
            this.dataGridViewCheckBoxColumn3.HeaderText = "Checked";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Width = 20;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Warehouse_ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "Склад";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Warehouse_ID";
            this.dataGridViewTextBoxColumn10.HeaderText = "Склад";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "Checked";
            this.dataGridViewCheckBoxColumn4.HeaderText = "Checked";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.ThreeState = true;
            this.dataGridViewCheckBoxColumn4.Width = 20;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Warehouse_ID";
            this.dataGridViewTextBoxColumn11.HeaderText = "ID склада";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Warehouse_Name";
            this.dataGridViewTextBoxColumn12.HeaderText = "Название склада";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn13.HeaderText = "ID товара";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Item_Name";
            this.dataGridViewTextBoxColumn14.HeaderText = "Название товара";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "IS_PKU";
            this.dataGridViewTextBoxColumn15.HeaderText = "ПКУ";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Sales_Category";
            this.dataGridViewTextBoxColumn16.HeaderText = "Категория";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Storage_Form";
            this.dataGridViewTextBoxColumn17.HeaderText = "Форма хранения";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Maker_ID";
            this.dataGridViewTextBoxColumn18.HeaderText = "ID производителя";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Maker_Name";
            this.dataGridViewTextBoxColumn19.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Vendor_ID";
            this.dataGridViewTextBoxColumn20.HeaderText = "ID поставщика";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Vendor_Name";
            this.dataGridViewTextBoxColumn21.HeaderText = "Поставщик";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Base_Price";
            this.dataGridViewTextBoxColumn22.HeaderText = "Базовая цена";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // checkedDataGridViewCheckBoxColumn
            // 
            this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewCheckBoxColumn.HeaderText = "";
            this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
            this.checkedDataGridViewCheckBoxColumn.Width = 20;
            // 
            // stillageIDDataGridViewTextBoxColumn
            // 
            this.stillageIDDataGridViewTextBoxColumn.DataPropertyName = "Stillage_ID";
            this.stillageIDDataGridViewTextBoxColumn.HeaderText = "Стелаж";
            this.stillageIDDataGridViewTextBoxColumn.Name = "stillageIDDataGridViewTextBoxColumn";
            this.stillageIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Zone_ID
            // 
            this.Zone_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Zone_ID.DataPropertyName = "Zone_ID";
            this.Zone_ID.HeaderText = "Зона";
            this.Zone_ID.Name = "Zone_ID";
            this.Zone_ID.ReadOnly = true;
            // 
            // stillageID
            // 
            this.stillageID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stillageID.DataPropertyName = "Stillage_ID";
            this.stillageID.HeaderText = "Стелаж";
            this.stillageID.Name = "stillageID";
            this.stillageID.ReadOnly = true;
            // 
            // taFilials
            // 
            this.taFilials.ClearBeforeFill = true;
            // 
            // taFiWarehouses
            // 
            this.taFiWarehouses.ClearBeforeFill = true;
            // 
            // taFiZones
            // 
            this.taFiZones.ClearBeforeFill = true;
            // 
            // taFiStillages
            // 
            this.taFiStillages.ClearBeforeFill = true;
            // 
            // taFiLocations
            // 
            this.taFiLocations.ClearBeforeFill = true;
            // 
            // taFiItems
            // 
            this.taFiItems.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(817, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Тип:";
            // 
            // cbInventoryTypes
            // 
            this.cbInventoryTypes.DataSource = this.fITypesBindingSource;
            this.cbInventoryTypes.DisplayMember = "entity_value";
            this.cbInventoryTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInventoryTypes.FormattingEnabled = true;
            this.cbInventoryTypes.Location = new System.Drawing.Point(855, 5);
            this.cbInventoryTypes.Name = "cbInventoryTypes";
            this.cbInventoryTypes.Size = new System.Drawing.Size(200, 21);
            this.cbInventoryTypes.TabIndex = 6;
            this.cbInventoryTypes.ValueMember = "entity_key";
            this.cbInventoryTypes.SelectedValueChanged += new System.EventHandler(this.cbInventoryTypes_SelectedValueChanged);
            // 
            // fITypesBindingSource
            // 
            this.fITypesBindingSource.DataMember = "FI_Types";
            this.fITypesBindingSource.DataSource = this.inventory1;
            // 
            // tafITypes
            // 
            this.tafITypes.ClearBeforeFill = true;
            // 
            // InventoryFilialEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1084, 742);
            this.Controls.Add(this.cbInventoryTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbcTabs);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cbFilials);
            this.Controls.Add(this.lblFilial);
            this.Controls.Add(this.btnCancel);
            this.KeyPreview = true;
            this.Name = "InventoryFilialEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Инвентаризация №1111";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InventoryFilialEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryFilialEditForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InventoryFilialEditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsFilials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory1)).EndInit();
            this.tbcTabs.ResumeLayout(false);
            this.tbpPlaces.ResumeLayout(false);
            this.tbpPlaces.PerformLayout();
            this.grbFilters.ResumeLayout(false);
            this.grbFilters.PerformLayout();
            this.spcZones.Panel1.ResumeLayout(false);
            this.spcZones.Panel1.PerformLayout();
            this.spcZones.Panel2.ResumeLayout(false);
            this.spcZones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiZones)).EndInit();
            this.spcStagesPlaces.Panel1.ResumeLayout(false);
            this.spcStagesPlaces.Panel1.PerformLayout();
            this.spcStagesPlaces.Panel2.ResumeLayout(false);
            this.spcStagesPlaces.Panel2.PerformLayout();
            this.spcStagesPlaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiStillages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiWarehouses)).EndInit();
            this.tbpGoods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiItems)).EndInit();
            this.grbGoodsFilters.ResumeLayout(false);
            this.grbGoodsFilters.PerformLayout();
            this.grbPkuFilter.ResumeLayout(false);
            this.grbPkuFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fITypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFilial;
        private System.Windows.Forms.ComboBox cbFilials;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.BindingSource bsFilials;
        private WMSOffice.Data.Inventory inventory1;
        private WMSOffice.Data.InventoryTableAdapters.FilialsTableAdapter taFilials;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TabControl tbcTabs;
        private System.Windows.Forms.TabPage tbpPlaces;
        private System.Windows.Forms.TabPage tbpGoods;
        private System.Windows.Forms.Label lblWarehouses;
        private System.Windows.Forms.DataGridView dgvWarehouses;
        private System.Windows.Forms.BindingSource bsFiWarehouses;
        private WMSOffice.Data.InventoryTableAdapters.FI_WarehousesTableAdapter taFiWarehouses;
        private System.Windows.Forms.SplitContainer spcZones;
        private System.Windows.Forms.DataGridView dgvZones;
        private System.Windows.Forms.Label lblZones;
        private System.Windows.Forms.BindingSource bsFiZones;
        private WMSOffice.Data.InventoryTableAdapters.FI_ZonesTableAdapter taFiZones;
        private System.Windows.Forms.SplitContainer spcStagesPlaces;
        private System.Windows.Forms.Label lblStages;
        private System.Windows.Forms.DataGridView dgvStages;
        private System.Windows.Forms.DataGridView dgvPlaces;
        private System.Windows.Forms.Label lblPlaces;
        private System.Windows.Forms.BindingSource bsFiStillages;
        private WMSOffice.Data.InventoryTableAdapters.FI_StillagesTableAdapter taFiStillages;
        private System.Windows.Forms.BindingSource bsFiLocations;
        private WMSOffice.Data.InventoryTableAdapters.FI_LocationsTableAdapter taFiLocations;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn stillageID;
        private System.Windows.Forms.GroupBox grbFilters;
        private System.Windows.Forms.Label lblFilterZones;
        private System.Windows.Forms.Label lblFilterLocations;
        private System.Windows.Forms.Label lblFilterStages;
        private System.Windows.Forms.GroupBox grbGoodsFilters;
        private System.Windows.Forms.TextBox tbxLocationsFilter;
        private System.Windows.Forms.TextBox tbxStagesFilter;
        private System.Windows.Forms.TextBox tbxZonesFilter;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stillageIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zone_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource bsFiItems;
        private WMSOffice.Data.InventoryTableAdapters.FI_ItemsTableAdapter taFiItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.Label lblStorageForms;
        private System.Windows.Forms.Label lblCategory;
        private WMSOffice.Controls.CheckedComboBox ccbCategories;
        private WMSOffice.Controls.CheckedComboBox ccbStorageForms;
        private System.Windows.Forms.TextBox tbxBasePriceTo;
        private System.Windows.Forms.Label lblBasePriceFor;
        private System.Windows.Forms.TextBox tbxBasePriceFrom;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.GroupBox grbPkuFilter;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.RadioButton rbtNotPku;
        private System.Windows.Forms.RadioButton rbtPKU;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSPKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn storageForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn makerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn makerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn basePrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckedZone;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneID;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warehouse_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckedWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckedStage;
        private System.Windows.Forms.DataGridViewTextBoxColumn stillageIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckedLocations;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stillage_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.TextBox tbxItemID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbInventoryTypes;
        private System.Windows.Forms.BindingSource fITypesBindingSource;
        private WMSOffice.Data.InventoryTableAdapters.FI_TypesTableAdapter tafITypes;
        private System.Windows.Forms.Button btnShowCachedItems;
        private System.Windows.Forms.Button btnExportCachedItems;
    }
}