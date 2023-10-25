namespace WMSOffice.Window
{
    partial class ColdChainEquipmentsWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefreshEquipment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbAddEquipment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFullEquipmentStates = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintEquipmentSticker = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tssAfterPrintLabel = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.dgvColdEquipment = new System.Windows.Forms.DataGridView();
            this.branchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.coldEquipmentAbilityStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentTransportationsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentForwardersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldEquipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldEquipmentTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.ColdEquipmentTableAdapter();
            this.equipmentTransportationsTypesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentTransportationsTypesTableAdapter();
            this.branchesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter();
            this.equipmentForwardersTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentForwardersTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ability = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TransportationType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Forwarder_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isUseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColdEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldEquipmentAbilityStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTransportationsTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentForwardersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldEquipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshEquipment,
            this.toolStripSeparator2,
            this.sbAddEquipment,
            this.toolStripSeparator1,
            this.btnFullEquipmentStates,
            this.toolStripSeparator4,
            this.sbPrintEquipmentSticker,
            this.cmbPrinters,
            this.lblPrinter,
            this.toolStripSeparator3,
            this.tssAfterPrintLabel,
            this.btnExportToExcel});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1151, 55);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbRefreshEquipment
            // 
            this.sbRefreshEquipment.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshEquipment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshEquipment.Name = "sbRefreshEquipment";
            this.sbRefreshEquipment.Size = new System.Drawing.Size(113, 52);
            this.sbRefreshEquipment.Text = "Обновить";
            this.sbRefreshEquipment.Click += new System.EventHandler(this.sbRefreshEquipment_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // sbAddEquipment
            // 
            this.sbAddEquipment.Image = global::WMSOffice.Properties.Resources.add_equipment;
            this.sbAddEquipment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddEquipment.Name = "sbAddEquipment";
            this.sbAddEquipment.Size = new System.Drawing.Size(176, 52);
            this.sbAddEquipment.Text = "Новое оборудование";
            this.sbAddEquipment.Click += new System.EventHandler(this.sbAddEquipment_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnFullEquipmentStates
            // 
            this.btnFullEquipmentStates.Image = global::WMSOffice.Properties.Resources.history_review;
            this.btnFullEquipmentStates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullEquipmentStates.Name = "btnFullEquipmentStates";
            this.btnFullEquipmentStates.Size = new System.Drawing.Size(186, 52);
            this.btnFullEquipmentStates.Text = "Статусы оборудования";
            this.btnFullEquipmentStates.Click += new System.EventHandler(this.btnFullEquipmentStates_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintEquipmentSticker
            // 
            this.sbPrintEquipmentSticker.Image = global::WMSOffice.Properties.Resources.barcode;
            this.sbPrintEquipmentSticker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintEquipmentSticker.Name = "sbPrintEquipmentSticker";
            this.sbPrintEquipmentSticker.Size = new System.Drawing.Size(149, 52);
            this.sbPrintEquipmentSticker.Text = "Печать этикетки";
            this.sbPrintEquipmentSticker.Click += new System.EventHandler(this.sbPrintEquipmentSticker_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(58, 52);
            this.lblPrinter.Text = "Принтер:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // tssAfterPrintLabel
            // 
            this.tssAfterPrintLabel.Name = "tssAfterPrintLabel";
            this.tssAfterPrintLabel.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(143, 52);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // dgvColdEquipment
            // 
            this.dgvColdEquipment.AllowUserToAddRows = false;
            this.dgvColdEquipment.AllowUserToDeleteRows = false;
            this.dgvColdEquipment.AllowUserToResizeRows = false;
            this.dgvColdEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColdEquipment.AutoGenerateColumns = false;
            this.dgvColdEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColdEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipmentIDDataGridViewTextBoxColumn,
            this.equipmentNameDataGridViewTextBoxColumn,
            this.equipmentTypeNameDataGridViewTextBoxColumn,
            this.Branch,
            this.Department,
            this.Serial_Number,
            this.measurementsDataGridViewTextBoxColumn,
            this.Ability,
            this.TransportationType,
            this.Forwarder_ID,
            this.isUseDataGridViewTextBoxColumn});
            this.dgvColdEquipment.DataSource = this.coldEquipmentBindingSource;
            this.dgvColdEquipment.Location = new System.Drawing.Point(0, 98);
            this.dgvColdEquipment.MultiSelect = false;
            this.dgvColdEquipment.Name = "dgvColdEquipment";
            this.dgvColdEquipment.RowHeadersVisible = false;
            this.dgvColdEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColdEquipment.ShowEditingIcon = false;
            this.dgvColdEquipment.Size = new System.Drawing.Size(1151, 431);
            this.dgvColdEquipment.TabIndex = 2;
            this.dgvColdEquipment.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColdEquipment_CellValueChanged);
            this.dgvColdEquipment.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvColdEquipment_CellBeginEdit);
            this.dgvColdEquipment.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvColdEquipment_CellValidating);
            this.dgvColdEquipment.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvColdEquipment_EditingControlShowing);
            this.dgvColdEquipment.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvColdEquipment_DataError);
            this.dgvColdEquipment.SelectionChanged += new System.EventHandler(this.dgvColdEquipment_SelectionChanged);
            // 
            // branchesBindingSource
            // 
            this.branchesBindingSource.DataMember = "Branches";
            this.branchesBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // coldEquipmentAbilityStateBindingSource
            // 
            this.coldEquipmentAbilityStateBindingSource.DataMember = "ColdEquipmentAbilityState";
            this.coldEquipmentAbilityStateBindingSource.DataSource = this.coldChain;
            // 
            // equipmentTransportationsTypesBindingSource
            // 
            this.equipmentTransportationsTypesBindingSource.DataMember = "EquipmentTransportationsTypes";
            this.equipmentTransportationsTypesBindingSource.DataSource = this.coldChain;
            // 
            // equipmentForwardersBindingSource
            // 
            this.equipmentForwardersBindingSource.DataMember = "EquipmentForwarders";
            this.equipmentForwardersBindingSource.DataSource = this.coldChain;
            // 
            // coldEquipmentBindingSource
            // 
            this.coldEquipmentBindingSource.DataMember = "ColdEquipment";
            this.coldEquipmentBindingSource.DataSource = this.coldChain;
            // 
            // coldEquipmentTableAdapter
            // 
            this.coldEquipmentTableAdapter.ClearBeforeFill = true;
            // 
            // equipmentTransportationsTypesTableAdapter
            // 
            this.equipmentTransportationsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // branchesTableAdapter
            // 
            this.branchesTableAdapter.ClearBeforeFill = true;
            // 
            // equipmentForwardersTableAdapter
            // 
            this.equipmentForwardersTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Equipment_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Equipment_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Equipment_Type_Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "IsWork";
            this.dataGridViewComboBoxColumn1.DataSource = this.coldEquipmentAbilityStateBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "Name";
            this.dataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn1.HeaderText = "Исправность";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "ID";
            this.dataGridViewComboBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Measurements";
            this.dataGridViewTextBoxColumn4.HeaderText = "Внутренние размеры";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Transportation_ID";
            this.dataGridViewTextBoxColumn5.HeaderText = "Transportation_ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 250;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "Transportation_Name";
            this.dataGridViewComboBoxColumn2.DataSource = this.equipmentTransportationsTypesBindingSource;
            this.dataGridViewComboBoxColumn2.DisplayMember = "Transportation_Name";
            this.dataGridViewComboBoxColumn2.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn2.HeaderText = "Тип транспортировки";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.ReadOnly = true;
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn2.ValueMember = "Transportation_ID";
            this.dataGridViewComboBoxColumn2.Visible = false;
            this.dataGridViewComboBoxColumn2.Width = 200;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.DataPropertyName = "Transportation_ID";
            this.dataGridViewComboBoxColumn3.DataSource = this.equipmentTransportationsTypesBindingSource;
            this.dataGridViewComboBoxColumn3.DisplayMember = "Transportation_Name";
            this.dataGridViewComboBoxColumn3.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn3.HeaderText = "Тип транспортировки";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn3.ValueMember = "Transportation_ID";
            this.dataGridViewComboBoxColumn3.Width = 200;
            // 
            // dataGridViewComboBoxColumn4
            // 
            this.dataGridViewComboBoxColumn4.DataPropertyName = "Forwarder_ID";
            this.dataGridViewComboBoxColumn4.DataSource = this.equipmentForwardersBindingSource;
            this.dataGridViewComboBoxColumn4.DisplayMember = "Forwarder";
            this.dataGridViewComboBoxColumn4.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn4.HeaderText = "Экспедитор";
            this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
            this.dataGridViewComboBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn4.ValueMember = "Forwarder_ID";
            this.dataGridViewComboBoxColumn4.Width = 300;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "IsUse";
            this.dataGridViewTextBoxColumn6.HeaderText = "Используемость";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // equipmentIDDataGridViewTextBoxColumn
            // 
            this.equipmentIDDataGridViewTextBoxColumn.DataPropertyName = "Equipment_ID";
            this.equipmentIDDataGridViewTextBoxColumn.HeaderText = "№";
            this.equipmentIDDataGridViewTextBoxColumn.Name = "equipmentIDDataGridViewTextBoxColumn";
            this.equipmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.equipmentIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // equipmentNameDataGridViewTextBoxColumn
            // 
            this.equipmentNameDataGridViewTextBoxColumn.DataPropertyName = "Equipment_Name";
            this.equipmentNameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.equipmentNameDataGridViewTextBoxColumn.Name = "equipmentNameDataGridViewTextBoxColumn";
            this.equipmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.equipmentNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // equipmentTypeNameDataGridViewTextBoxColumn
            // 
            this.equipmentTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Equipment_Type_Name";
            this.equipmentTypeNameDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.equipmentTypeNameDataGridViewTextBoxColumn.Name = "equipmentTypeNameDataGridViewTextBoxColumn";
            this.equipmentTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.equipmentTypeNameDataGridViewTextBoxColumn.Width = 170;
            // 
            // Branch
            // 
            this.Branch.DataPropertyName = "Branch";
            this.Branch.DataSource = this.branchesBindingSource;
            this.Branch.DisplayMember = "Branch_Name";
            this.Branch.DisplayStyleForCurrentCellOnly = true;
            this.Branch.HeaderText = "Филиал";
            this.Branch.Name = "Branch";
            this.Branch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Branch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Branch.ValueMember = "Warehouse_ID";
            this.Branch.Width = 160;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Отдел (примечание)";
            this.Department.Name = "Department";
            this.Department.Width = 150;
            // 
            // Serial_Number
            // 
            this.Serial_Number.DataPropertyName = "Serial_Number";
            this.Serial_Number.HeaderText = "S/N";
            this.Serial_Number.Name = "Serial_Number";
            this.Serial_Number.ReadOnly = true;
            this.Serial_Number.Width = 70;
            // 
            // measurementsDataGridViewTextBoxColumn
            // 
            this.measurementsDataGridViewTextBoxColumn.DataPropertyName = "Measurements";
            this.measurementsDataGridViewTextBoxColumn.HeaderText = "Внутренние размеры";
            this.measurementsDataGridViewTextBoxColumn.Name = "measurementsDataGridViewTextBoxColumn";
            this.measurementsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Ability
            // 
            this.Ability.DataPropertyName = "IsWork";
            this.Ability.DataSource = this.coldEquipmentAbilityStateBindingSource;
            this.Ability.DisplayMember = "Name";
            this.Ability.DisplayStyleForCurrentCellOnly = true;
            this.Ability.HeaderText = "Активность";
            this.Ability.Name = "Ability";
            this.Ability.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ability.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ability.ValueMember = "ID";
            this.Ability.Width = 120;
            // 
            // TransportationType
            // 
            this.TransportationType.DataPropertyName = "Transportation_ID";
            this.TransportationType.DataSource = this.equipmentTransportationsTypesBindingSource;
            this.TransportationType.DisplayMember = "Transportation_Name";
            this.TransportationType.DisplayStyleForCurrentCellOnly = true;
            this.TransportationType.HeaderText = "Тип транспортировки";
            this.TransportationType.Name = "TransportationType";
            this.TransportationType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TransportationType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TransportationType.ValueMember = "Transportation_ID";
            this.TransportationType.Width = 200;
            // 
            // Forwarder_ID
            // 
            this.Forwarder_ID.DataPropertyName = "Forwarder_ID";
            this.Forwarder_ID.DataSource = this.equipmentForwardersBindingSource;
            this.Forwarder_ID.DisplayMember = "Forwarder";
            this.Forwarder_ID.DisplayStyleForCurrentCellOnly = true;
            this.Forwarder_ID.HeaderText = "Экспедитор";
            this.Forwarder_ID.Name = "Forwarder_ID";
            this.Forwarder_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Forwarder_ID.ValueMember = "Forwarder_ID";
            this.Forwarder_ID.Width = 250;
            // 
            // isUseDataGridViewTextBoxColumn
            // 
            this.isUseDataGridViewTextBoxColumn.DataPropertyName = "IsUse";
            this.isUseDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.isUseDataGridViewTextBoxColumn.Name = "isUseDataGridViewTextBoxColumn";
            this.isUseDataGridViewTextBoxColumn.ReadOnly = true;
            this.isUseDataGridViewTextBoxColumn.Width = 150;
            // 
            // ColdChainEquipmentsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 529);
            this.Controls.Add(this.dgvColdEquipment);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "ColdChainEquipmentsWindow";
            this.Text = "ColdChainEquipmentsWindow";
            this.Load += new System.EventHandler(this.ColdChainEquipmentsWindow_Load);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.dgvColdEquipment, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColdEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldEquipmentAbilityStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTransportationsTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentForwardersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldEquipmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.DataGridView dgvColdEquipment;
        private System.Windows.Forms.ToolStripButton sbRefreshEquipment;
        private System.Windows.Forms.ToolStripButton sbAddEquipment;
        private System.Windows.Forms.ToolStripButton sbPrintEquipmentSticker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private WMSOffice.Data.ColdChain coldChain;
        private System.Windows.Forms.BindingSource coldEquipmentBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.ColdEquipmentTableAdapter coldEquipmentTableAdapter;
        private System.Windows.Forms.BindingSource coldEquipmentAbilityStateBindingSource;
        private System.Windows.Forms.BindingSource equipmentTransportationsTypesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.EquipmentTransportationsTypesTableAdapter equipmentTransportationsTypesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource branchesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter branchesTableAdapter;
        private System.Windows.Forms.BindingSource equipmentForwardersBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.EquipmentForwardersTableAdapter equipmentForwardersTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
        private System.Windows.Forms.ToolStripSeparator tssAfterPrintLabel;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnFullEquipmentStates;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn measurementsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ability;
        private System.Windows.Forms.DataGridViewComboBoxColumn TransportationType;
        private System.Windows.Forms.DataGridViewComboBoxColumn Forwarder_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn isUseDataGridViewTextBoxColumn;
    }
}