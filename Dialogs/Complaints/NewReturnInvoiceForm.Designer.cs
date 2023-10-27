namespace WMSOffice.Dialogs.Complaints
{
    partial class NewReturnInvoiceForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.dtpDocDate = new System.Windows.Forms.DateTimePicker();
            this.lblVendor = new System.Windows.Forms.Label();
            this.cmbVendors = new System.Windows.Forms.ComboBox();
            this.bsVendors = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.spcTwoGrids = new System.Windows.Forms.SplitContainer();
            this.dgvFreeProducts = new System.Windows.Forms.DataGridView();
            this.rowIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountUAHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warehouse_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSVrLCRemains = new System.Windows.Forms.BindingSource(this.components);
            this.spcInternalGrid = new System.Windows.Forms.SplitContainer();
            this.spcVert1 = new System.Windows.Forms.SplitContainer();
            this.spcVert2 = new System.Windows.Forms.SplitContainer();
            this.btnRemoveFromInvoice = new System.Windows.Forms.Button();
            this.btnAddToInvoice = new System.Windows.Forms.Button();
            this.dgvInvoiceProducts = new System.Windows.Forms.DataGridView();
            this.lineIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountUAHDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsVrDocDetails = new System.Windows.Forms.BindingSource(this.components);
            this.lblProducts = new System.Windows.Forms.Label();
            this.taVendors = new WMSOffice.Data.ComplaintsTableAdapters.VendorsTableAdapter();
            this.taVrLcRemains = new WMSOffice.Data.ComplaintsTableAdapters.VR_LC_RemainsTableAdapter();
            this.taVrDocDetails = new WMSOffice.Data.ComplaintsTableAdapters.VR_DocDetailsTableAdapter();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.bsVrGetShippingList = new System.Windows.Forms.BindingSource(this.components);
            this.taVr_GetShippingList = new WMSOffice.Data.ComplaintsTableAdapters.VR_GetShippingListTableAdapter();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblRounding = new System.Windows.Forms.Label();
            this.nudRounding = new System.Windows.Forms.NumericUpDown();
            this.lblSigns = new System.Windows.Forms.Label();
            this.cmbDocsTypes = new System.Windows.Forms.ComboBox();
            this.vRDocsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.vR_Docs_TypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.VR_Docs_TypesTableAdapter();
            this.cbNoVAT = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.spcTwoGrids.Panel1.SuspendLayout();
            this.spcTwoGrids.Panel2.SuspendLayout();
            this.spcTwoGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFreeProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSVrLCRemains)).BeginInit();
            this.spcInternalGrid.Panel1.SuspendLayout();
            this.spcInternalGrid.Panel2.SuspendLayout();
            this.spcInternalGrid.SuspendLayout();
            this.spcVert1.Panel2.SuspendLayout();
            this.spcVert1.SuspendLayout();
            this.spcVert2.Panel1.SuspendLayout();
            this.spcVert2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVrDocDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVrGetShippingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRounding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRDocsTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(674, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(582, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(12, 16);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(180, 13);
            this.lblExpirationDate.TabIndex = 2;
            this.lblExpirationDate.Text = "Предполагаемая дата документа:";
            // 
            // dtpDocDate
            // 
            this.dtpDocDate.Location = new System.Drawing.Point(198, 12);
            this.dtpDocDate.Name = "dtpDocDate";
            this.dtpDocDate.Size = new System.Drawing.Size(148, 20);
            this.dtpDocDate.TabIndex = 1;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(407, 16);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 4;
            this.lblVendor.Text = "Поставщик:";
            // 
            // cmbVendors
            // 
            this.cmbVendors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVendors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVendors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVendors.DataSource = this.bsVendors;
            this.cmbVendors.DisplayMember = "Vendor_Name";
            this.cmbVendors.FormattingEnabled = true;
            this.cmbVendors.Location = new System.Drawing.Point(481, 12);
            this.cmbVendors.Name = "cmbVendors";
            this.cmbVendors.Size = new System.Drawing.Size(266, 21);
            this.cmbVendors.TabIndex = 2;
            this.cmbVendors.ValueMember = "Vendor_ID";
            this.cmbVendors.SelectedValueChanged += new System.EventHandler(this.cmbVendors_SelectedValueChanged);
            // 
            // bsVendors
            // 
            this.bsVendors.DataMember = "Vendors";
            this.bsVendors.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spcTwoGrids
            // 
            this.spcTwoGrids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcTwoGrids.Location = new System.Drawing.Point(15, 168);
            this.spcTwoGrids.Name = "spcTwoGrids";
            // 
            // spcTwoGrids.Panel1
            // 
            this.spcTwoGrids.Panel1.Controls.Add(this.dgvFreeProducts);
            // 
            // spcTwoGrids.Panel2
            // 
            this.spcTwoGrids.Panel2.Controls.Add(this.spcInternalGrid);
            this.spcTwoGrids.Size = new System.Drawing.Size(732, 291);
            this.spcTwoGrids.SplitterDistance = 331;
            this.spcTwoGrids.TabIndex = 7;
            // 
            // dgvFreeProducts
            // 
            this.dgvFreeProducts.AllowUserToAddRows = false;
            this.dgvFreeProducts.AllowUserToDeleteRows = false;
            this.dgvFreeProducts.AllowUserToOrderColumns = true;
            this.dgvFreeProducts.AllowUserToResizeRows = false;
            this.dgvFreeProducts.AutoGenerateColumns = false;
            this.dgvFreeProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFreeProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowIDDataGridViewTextBoxColumn,
            this.locationIDDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.AllowQty,
            this.lotNumberDataGridViewTextBoxColumn,
            this.batchIDDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn24,
            this.amountUAHDataGridViewTextBoxColumn,
            this.VAT,
            this.LotStatus,
            this.Warehouse_ID});
            this.dgvFreeProducts.DataSource = this.bSVrLCRemains;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFreeProducts.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFreeProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFreeProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvFreeProducts.Name = "dgvFreeProducts";
            this.dgvFreeProducts.ReadOnly = true;
            this.dgvFreeProducts.RowHeadersVisible = false;
            this.dgvFreeProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFreeProducts.Size = new System.Drawing.Size(331, 291);
            this.dgvFreeProducts.TabIndex = 0;
            this.dgvFreeProducts.SelectionChanged += new System.EventHandler(this.dgvFreeProducts_SelectionChanged);
            // 
            // rowIDDataGridViewTextBoxColumn
            // 
            this.rowIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rowIDDataGridViewTextBoxColumn.DataPropertyName = "Row_ID";
            this.rowIDDataGridViewTextBoxColumn.HeaderText = "№ строки";
            this.rowIDDataGridViewTextBoxColumn.Name = "rowIDDataGridViewTextBoxColumn";
            this.rowIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.rowIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // locationIDDataGridViewTextBoxColumn
            // 
            this.locationIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationIDDataGridViewTextBoxColumn.DataPropertyName = "Location_ID";
            this.locationIDDataGridViewTextBoxColumn.HeaderText = "Место";
            this.locationIDDataGridViewTextBoxColumn.Name = "locationIDDataGridViewTextBoxColumn";
            this.locationIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationIDDataGridViewTextBoxColumn.Width = 64;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "ID товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 75;
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
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 66;
            // 
            // AllowQty
            // 
            this.AllowQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AllowQty.DataPropertyName = "AllowQty";
            this.AllowQty.HeaderText = "Разрешено";
            this.AllowQty.Name = "AllowQty";
            this.AllowQty.ReadOnly = true;
            this.AllowQty.Width = 89;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 63;
            // 
            // batchIDDataGridViewTextBoxColumn
            // 
            this.batchIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.batchIDDataGridViewTextBoxColumn.DataPropertyName = "Batch_ID";
            this.batchIDDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.batchIDDataGridViewTextBoxColumn.Name = "batchIDDataGridViewTextBoxColumn";
            this.batchIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchIDDataGridViewTextBoxColumn.Width = 69;
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
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "Е.И.";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            this.uOMDataGridViewTextBoxColumn.ReadOnly = true;
            this.uOMDataGridViewTextBoxColumn.Width = 53;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn24.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 58;
            // 
            // amountUAHDataGridViewTextBoxColumn
            // 
            this.amountUAHDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountUAHDataGridViewTextBoxColumn.DataPropertyName = "Amount_UAH";
            this.amountUAHDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.amountUAHDataGridViewTextBoxColumn.Name = "amountUAHDataGridViewTextBoxColumn";
            this.amountUAHDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountUAHDataGridViewTextBoxColumn.Width = 66;
            // 
            // VAT
            // 
            this.VAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VAT.DataPropertyName = "VAT";
            this.VAT.HeaderText = "НДС";
            this.VAT.Name = "VAT";
            this.VAT.ReadOnly = true;
            this.VAT.Width = 56;
            // 
            // LotStatus
            // 
            this.LotStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LotStatus.DataPropertyName = "LotStatus";
            this.LotStatus.HeaderText = "Код задержки";
            this.LotStatus.Name = "LotStatus";
            this.LotStatus.ReadOnly = true;
            this.LotStatus.Width = 96;
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
            // bSVrLCRemains
            // 
            this.bSVrLCRemains.DataMember = "VR_LC_Remains";
            this.bSVrLCRemains.DataSource = this.complaints;
            // 
            // spcInternalGrid
            // 
            this.spcInternalGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcInternalGrid.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcInternalGrid.IsSplitterFixed = true;
            this.spcInternalGrid.Location = new System.Drawing.Point(0, 0);
            this.spcInternalGrid.Name = "spcInternalGrid";
            // 
            // spcInternalGrid.Panel1
            // 
            this.spcInternalGrid.Panel1.Controls.Add(this.spcVert1);
            // 
            // spcInternalGrid.Panel2
            // 
            this.spcInternalGrid.Panel2.Controls.Add(this.dgvInvoiceProducts);
            this.spcInternalGrid.Size = new System.Drawing.Size(397, 291);
            this.spcInternalGrid.SplitterDistance = 73;
            this.spcInternalGrid.TabIndex = 0;
            // 
            // spcVert1
            // 
            this.spcVert1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcVert1.Location = new System.Drawing.Point(0, 0);
            this.spcVert1.Name = "spcVert1";
            this.spcVert1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcVert1.Panel2
            // 
            this.spcVert1.Panel2.Controls.Add(this.spcVert2);
            this.spcVert1.Size = new System.Drawing.Size(73, 291);
            this.spcVert1.SplitterDistance = 51;
            this.spcVert1.TabIndex = 0;
            // 
            // spcVert2
            // 
            this.spcVert2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcVert2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcVert2.Location = new System.Drawing.Point(0, 0);
            this.spcVert2.Name = "spcVert2";
            this.spcVert2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcVert2.Panel1
            // 
            this.spcVert2.Panel1.Controls.Add(this.btnRemoveFromInvoice);
            this.spcVert2.Panel1.Controls.Add(this.btnAddToInvoice);
            this.spcVert2.Size = new System.Drawing.Size(73, 236);
            this.spcVert2.SplitterDistance = 145;
            this.spcVert2.TabIndex = 0;
            // 
            // btnRemoveFromInvoice
            // 
            this.btnRemoveFromInvoice.Image = global::WMSOffice.Properties.Resources.arrow_left;
            this.btnRemoveFromInvoice.Location = new System.Drawing.Point(11, 87);
            this.btnRemoveFromInvoice.Name = "btnRemoveFromInvoice";
            this.btnRemoveFromInvoice.Size = new System.Drawing.Size(51, 38);
            this.btnRemoveFromInvoice.TabIndex = 1;
            this.btnRemoveFromInvoice.UseVisualStyleBackColor = true;
            this.btnRemoveFromInvoice.Click += new System.EventHandler(this.btnRemoveFromInvoice_Click);
            // 
            // btnAddToInvoice
            // 
            this.btnAddToInvoice.Image = global::WMSOffice.Properties.Resources.arrow_right;
            this.btnAddToInvoice.Location = new System.Drawing.Point(11, 43);
            this.btnAddToInvoice.Name = "btnAddToInvoice";
            this.btnAddToInvoice.Size = new System.Drawing.Size(51, 38);
            this.btnAddToInvoice.TabIndex = 0;
            this.btnAddToInvoice.UseVisualStyleBackColor = true;
            this.btnAddToInvoice.Click += new System.EventHandler(this.btnAddToInvoice_Click);
            // 
            // dgvInvoiceProducts
            // 
            this.dgvInvoiceProducts.AllowUserToAddRows = false;
            this.dgvInvoiceProducts.AllowUserToDeleteRows = false;
            this.dgvInvoiceProducts.AllowUserToOrderColumns = true;
            this.dgvInvoiceProducts.AllowUserToResizeRows = false;
            this.dgvInvoiceProducts.AutoGenerateColumns = false;
            this.dgvInvoiceProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineIDDataGridViewTextBoxColumn,
            this.locationIDDataGridViewTextBoxColumn1,
            this.itemIDDataGridViewTextBoxColumn1,
            this.itemDataGridViewTextBoxColumn1,
            this.clDUom,
            this.quantityDataGridViewTextBoxColumn1,
            this.lotNumberDataGridViewTextBoxColumn1,
            this.batchIDDataGridViewTextBoxColumn1,
            this.manufacturerDataGridViewTextBoxColumn1,
            this.expirationDateDataGridViewTextBoxColumn,
            this.Price,
            this.amountUAHDataGridViewTextBoxColumn1,
            this.vATDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn25});
            this.dgvInvoiceProducts.DataSource = this.bsVrDocDetails;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoiceProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceProducts.Name = "dgvInvoiceProducts";
            this.dgvInvoiceProducts.RowHeadersVisible = false;
            this.dgvInvoiceProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceProducts.Size = new System.Drawing.Size(320, 291);
            this.dgvInvoiceProducts.TabIndex = 0;
            this.dgvInvoiceProducts.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvInvoiceProducts_CellValidating);
            this.dgvInvoiceProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceProducts_CellEndEdit);
            // 
            // lineIDDataGridViewTextBoxColumn
            // 
            this.lineIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lineIDDataGridViewTextBoxColumn.DataPropertyName = "Line_ID";
            this.lineIDDataGridViewTextBoxColumn.HeaderText = "№ строки";
            this.lineIDDataGridViewTextBoxColumn.Name = "lineIDDataGridViewTextBoxColumn";
            this.lineIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.lineIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // locationIDDataGridViewTextBoxColumn1
            // 
            this.locationIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationIDDataGridViewTextBoxColumn1.DataPropertyName = "Location_ID";
            this.locationIDDataGridViewTextBoxColumn1.HeaderText = "Место";
            this.locationIDDataGridViewTextBoxColumn1.Name = "locationIDDataGridViewTextBoxColumn1";
            this.locationIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.locationIDDataGridViewTextBoxColumn1.Width = 64;
            // 
            // itemIDDataGridViewTextBoxColumn1
            // 
            this.itemIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn1.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn1.HeaderText = "ID товара";
            this.itemIDDataGridViewTextBoxColumn1.Name = "itemIDDataGridViewTextBoxColumn1";
            this.itemIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn1.Width = 75;
            // 
            // itemDataGridViewTextBoxColumn1
            // 
            this.itemDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemDataGridViewTextBoxColumn1.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.itemDataGridViewTextBoxColumn1.Name = "itemDataGridViewTextBoxColumn1";
            this.itemDataGridViewTextBoxColumn1.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn1.Width = 108;
            // 
            // clDUom
            // 
            this.clDUom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDUom.DataPropertyName = "UOM";
            this.clDUom.HeaderText = "Е.И.";
            this.clDUom.Name = "clDUom";
            this.clDUom.ReadOnly = true;
            this.clDUom.Width = 53;
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            this.quantityDataGridViewTextBoxColumn1.Width = 66;
            // 
            // lotNumberDataGridViewTextBoxColumn1
            // 
            this.lotNumberDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn1.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn1.HeaderText = "Серия";
            this.lotNumberDataGridViewTextBoxColumn1.Name = "lotNumberDataGridViewTextBoxColumn1";
            this.lotNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn1.Width = 63;
            // 
            // batchIDDataGridViewTextBoxColumn1
            // 
            this.batchIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.batchIDDataGridViewTextBoxColumn1.DataPropertyName = "Batch_ID";
            this.batchIDDataGridViewTextBoxColumn1.HeaderText = "Партия";
            this.batchIDDataGridViewTextBoxColumn1.Name = "batchIDDataGridViewTextBoxColumn1";
            this.batchIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.batchIDDataGridViewTextBoxColumn1.Width = 69;
            // 
            // manufacturerDataGridViewTextBoxColumn1
            // 
            this.manufacturerDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn1.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn1.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn1.Name = "manufacturerDataGridViewTextBoxColumn1";
            this.manufacturerDataGridViewTextBoxColumn1.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn1.Width = 111;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expirationDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 58;
            // 
            // amountUAHDataGridViewTextBoxColumn1
            // 
            this.amountUAHDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountUAHDataGridViewTextBoxColumn1.DataPropertyName = "Amount_UAH";
            this.amountUAHDataGridViewTextBoxColumn1.HeaderText = "Сумма";
            this.amountUAHDataGridViewTextBoxColumn1.Name = "amountUAHDataGridViewTextBoxColumn1";
            this.amountUAHDataGridViewTextBoxColumn1.ReadOnly = true;
            this.amountUAHDataGridViewTextBoxColumn1.Width = 66;
            // 
            // vATDataGridViewTextBoxColumn
            // 
            this.vATDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vATDataGridViewTextBoxColumn.DataPropertyName = "VAT";
            this.vATDataGridViewTextBoxColumn.HeaderText = "НДС";
            this.vATDataGridViewTextBoxColumn.Name = "vATDataGridViewTextBoxColumn";
            this.vATDataGridViewTextBoxColumn.ReadOnly = true;
            this.vATDataGridViewTextBoxColumn.Width = 56;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn23.DataPropertyName = "LotStatus";
            this.dataGridViewTextBoxColumn23.HeaderText = "Код задержки";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 96;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Warehouse_ID";
            this.dataGridViewTextBoxColumn25.HeaderText = "Склад";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 63;
            // 
            // bsVrDocDetails
            // 
            this.bsVrDocDetails.DataMember = "VR_DocDetails";
            this.bsVrDocDetails.DataSource = this.complaints;
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(12, 152);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(178, 13);
            this.lblProducts.TabIndex = 7;
            this.lblProducts.Text = "Выберите товары для накладной:";
            // 
            // taVendors
            // 
            this.taVendors.ClearBeforeFill = true;
            // 
            // taVrLcRemains
            // 
            this.taVrLcRemains.ClearBeforeFill = true;
            // 
            // taVrDocDetails
            // 
            this.taVrDocDetails.ClearBeforeFill = true;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 46);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(121, 13);
            this.lblWarehouse.TabIndex = 8;
            this.lblWarehouse.Text = "Откуда будет возврат:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWarehouse.DataSource = this.bsVrGetShippingList;
            this.cmbWarehouse.DisplayMember = "Warehouse_DSC";
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(139, 42);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(610, 21);
            this.cmbWarehouse.TabIndex = 3;
            this.cmbWarehouse.ValueMember = "Warehouse_ID";
            // 
            // bsVrGetShippingList
            // 
            this.bsVrGetShippingList.DataMember = "VR_GetShippingList";
            this.bsVrGetShippingList.DataSource = this.complaints;
            // 
            // taVr_GetShippingList
            // 
            this.taVr_GetShippingList.ClearBeforeFill = true;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(13, 129);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(120, 13);
            this.lblFilter.TabIndex = 11;
            this.lblFilter.Text = "Фильтр для остатков:";
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(139, 125);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(207, 20);
            this.tbxFilter.TabIndex = 6;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Row_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№ строки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Location_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Место";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ID товара";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item";
            this.dataGridViewTextBoxColumn4.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn5.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "LotNumber";
            this.dataGridViewTextBoxColumn6.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Batch_ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn8.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "UOM";
            this.dataGridViewTextBoxColumn9.HeaderText = "Е.И.";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Amount_UAH";
            this.dataGridViewTextBoxColumn10.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Line_ID";
            this.dataGridViewTextBoxColumn11.HeaderText = "№ строки";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Location_ID";
            this.dataGridViewTextBoxColumn12.HeaderText = "Место";
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
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Item";
            this.dataGridViewTextBoxColumn14.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn15.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Lot_Number";
            this.dataGridViewTextBoxColumn16.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Batch_ID";
            this.dataGridViewTextBoxColumn17.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn18.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "ExpirationDate";
            this.dataGridViewTextBoxColumn19.HeaderText = "Срок годности";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Amount_UAH";
            this.dataGridViewTextBoxColumn20.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Visible = false;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn21.DataPropertyName = "VAT";
            this.dataGridViewTextBoxColumn21.HeaderText = "НДС";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Visible = false;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn22.DataPropertyName = "VAT";
            this.dataGridViewTextBoxColumn22.HeaderText = "НДС";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // lblRounding
            // 
            this.lblRounding.AutoSize = true;
            this.lblRounding.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRounding.Location = new System.Drawing.Point(407, 76);
            this.lblRounding.Name = "lblRounding";
            this.lblRounding.Size = new System.Drawing.Size(70, 13);
            this.lblRounding.TabIndex = 13;
            this.lblRounding.Text = "Округление:";
            // 
            // nudRounding
            // 
            this.nudRounding.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRounding.Location = new System.Drawing.Point(481, 72);
            this.nudRounding.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudRounding.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRounding.Name = "nudRounding";
            this.nudRounding.Size = new System.Drawing.Size(34, 20);
            this.nudRounding.TabIndex = 5;
            this.nudRounding.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRounding.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRounding.ValueChanged += new System.EventHandler(this.nudRounding_ValueChanged);
            // 
            // lblSigns
            // 
            this.lblSigns.AutoSize = true;
            this.lblSigns.Location = new System.Drawing.Point(521, 76);
            this.lblSigns.Name = "lblSigns";
            this.lblSigns.Size = new System.Drawing.Size(120, 13);
            this.lblSigns.TabIndex = 15;
            this.lblSigns.Text = "знаков после запятой";
            // 
            // cmbDocsTypes
            // 
            this.cmbDocsTypes.DataSource = this.vRDocsTypesBindingSource;
            this.cmbDocsTypes.DisplayMember = "Description";
            this.cmbDocsTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocsTypes.FormattingEnabled = true;
            this.cmbDocsTypes.Location = new System.Drawing.Point(139, 72);
            this.cmbDocsTypes.Name = "cmbDocsTypes";
            this.cmbDocsTypes.Size = new System.Drawing.Size(207, 21);
            this.cmbDocsTypes.TabIndex = 4;
            this.cmbDocsTypes.ValueMember = "Doc_Type";
            this.cmbDocsTypes.SelectedValueChanged += new System.EventHandler(this.cmbDocsTypes_SelectedValueChanged);
            // 
            // vRDocsTypesBindingSource
            // 
            this.vRDocsTypesBindingSource.DataMember = "VR_Docs_Types";
            this.vRDocsTypesBindingSource.DataSource = this.complaints;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Тип возврата:";
            // 
            // vR_Docs_TypesTableAdapter
            // 
            this.vR_Docs_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // cbNoVAT
            // 
            this.cbNoVAT.AutoSize = true;
            this.cbNoVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbNoVAT.ForeColor = System.Drawing.Color.Red;
            this.cbNoVAT.Location = new System.Drawing.Point(677, 74);
            this.cbNoVAT.Name = "cbNoVAT";
            this.cbNoVAT.Size = new System.Drawing.Size(72, 17);
            this.cbNoVAT.TabIndex = 18;
            this.cbNoVAT.Text = "Без НДС";
            this.cbNoVAT.UseVisualStyleBackColor = true;
            // 
            // NewReturnInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(763, 500);
            this.Controls.Add(this.cbNoVAT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDocsTypes);
            this.Controls.Add(this.lblSigns);
            this.Controls.Add(this.nudRounding);
            this.Controls.Add(this.lblRounding);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.spcTwoGrids);
            this.Controls.Add(this.cmbVendors);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.dtpDocDate);
            this.Controls.Add(this.lblExpirationDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Name = "NewReturnInvoiceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание накладной";
            this.Load += new System.EventHandler(this.NewReturnInvoiceForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewReturnInvoiceForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bsVendors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.spcTwoGrids.Panel1.ResumeLayout(false);
            this.spcTwoGrids.Panel2.ResumeLayout(false);
            this.spcTwoGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFreeProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSVrLCRemains)).EndInit();
            this.spcInternalGrid.Panel1.ResumeLayout(false);
            this.spcInternalGrid.Panel2.ResumeLayout(false);
            this.spcInternalGrid.ResumeLayout(false);
            this.spcVert1.Panel2.ResumeLayout(false);
            this.spcVert1.ResumeLayout(false);
            this.spcVert2.Panel1.ResumeLayout(false);
            this.spcVert2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVrDocDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVrGetShippingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRounding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRDocsTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.DateTimePicker dtpDocDate;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.ComboBox cmbVendors;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource bsVendors;
        private WMSOffice.Data.ComplaintsTableAdapters.VendorsTableAdapter taVendors;
        private System.Windows.Forms.SplitContainer spcTwoGrids;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.SplitContainer spcInternalGrid;
        private System.Windows.Forms.Button btnAddToInvoice;
        private System.Windows.Forms.Button btnRemoveFromInvoice;
        private System.Windows.Forms.SplitContainer spcVert1;
        private System.Windows.Forms.SplitContainer spcVert2;
        private System.Windows.Forms.DataGridView dgvFreeProducts;
        private System.Windows.Forms.DataGridView dgvInvoiceProducts;
        private System.Windows.Forms.BindingSource bSVrLCRemains;
        private WMSOffice.Data.ComplaintsTableAdapters.VR_LC_RemainsTableAdapter taVrLcRemains;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.BindingSource bsVrDocDetails;
        private WMSOffice.Data.ComplaintsTableAdapters.VR_DocDetailsTableAdapter taVrDocDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.BindingSource bsVrGetShippingList;
        private WMSOffice.Data.ComplaintsTableAdapters.VR_GetShippingListTableAdapter taVr_GetShippingList;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.Label lblRounding;
        private System.Windows.Forms.NumericUpDown nudRounding;
        private System.Windows.Forms.Label lblSigns;
        private System.Windows.Forms.ComboBox cmbDocsTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource vRDocsTypesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.VR_Docs_TypesTableAdapter vR_Docs_TypesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountUAHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warehouse_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDUom;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountUAHDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.CheckBox cbNoVAT;
    }
}