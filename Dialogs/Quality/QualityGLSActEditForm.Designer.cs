namespace WMSOffice.Dialogs.Quality
{
    partial class QualityGLSActEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.spcTwoGrids = new System.Windows.Forms.SplitContainer();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expireDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currVendorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currVendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotVendorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotVendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gAItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.spcInternalGrid = new System.Windows.Forms.SplitContainer();
            this.spcVert1 = new System.Windows.Forms.SplitContainer();
            this.spcVert2 = new System.Windows.Forms.SplitContainer();
            this.btnCreateItemForAct = new System.Windows.Forms.Button();
            this.btnFindItemForAct = new System.Windows.Forms.Button();
            this.btnRemoveFromAct = new System.Windows.Forms.Button();
            this.btnAddToAct = new System.Windows.Forms.Button();
            this.dgvActDetails = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expireDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currVendorIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currVendorNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotVendorIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotVendorNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gADocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblItems = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.tbLotNumber = new System.Windows.Forms.TextBox();
            this.chbAllLotNumbers = new System.Windows.Forms.CheckBox();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.pnlDocHeader = new System.Windows.Forms.Panel();
            this.cmbInitiatorType = new System.Windows.Forms.ComboBox();
            this.gARecallInitiatorTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblInitiatorTypeID = new System.Windows.Forms.Label();
            this.tblProtocolStatus = new System.Windows.Forms.TextBox();
            this.lblProtocolStatus = new System.Windows.Forms.Label();
            this.tbProtocolID = new System.Windows.Forms.TextBox();
            this.lblProtocolID = new System.Windows.Forms.Label();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.cmbWorkType = new System.Windows.Forms.ComboBox();
            this.gAWorkTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblWorkTypeID = new System.Windows.Forms.Label();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.gADocTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbDocAttachment = new System.Windows.Forms.TextBox();
            this.lblDocAttachment = new System.Windows.Forms.Label();
            this.btnDocAttachment = new System.Windows.Forms.Button();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.dtpDocDate = new System.Windows.Forms.DateTimePicker();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.gA_ItemsTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_ItemsTableAdapter();
            this.gA_Doc_DetailsTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_Doc_DetailsTableAdapter();
            this.gA_Doc_TypesTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_Doc_TypesTableAdapter();
            this.gA_Work_TypesTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_Work_TypesTableAdapter();
            this.gA_Recall_Initiator_TypesTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_Recall_Initiator_TypesTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.spcTwoGrids.Panel1.SuspendLayout();
            this.spcTwoGrids.Panel2.SuspendLayout();
            this.spcTwoGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.spcInternalGrid.Panel1.SuspendLayout();
            this.spcInternalGrid.Panel2.SuspendLayout();
            this.spcInternalGrid.SuspendLayout();
            this.spcVert1.Panel2.SuspendLayout();
            this.spcVert1.SuspendLayout();
            this.spcVert2.Panel1.SuspendLayout();
            this.spcVert2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADocDetailsBindingSource)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnlDocHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gARecallInitiatorTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAWorkTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADocTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1127, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1217, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 528);
            this.pnlButtons.Size = new System.Drawing.Size(1304, 43);
            this.pnlButtons.TabIndex = 3;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.Controls.Add(this.pnlDetails);
            this.pnlHeader.Controls.Add(this.pnlFilter);
            this.pnlHeader.Controls.Add(this.pnlDocHeader);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1304, 522);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.spcTwoGrids);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 191);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1304, 331);
            this.pnlDetails.TabIndex = 3;
            // 
            // spcTwoGrids
            // 
            this.spcTwoGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcTwoGrids.Location = new System.Drawing.Point(0, 0);
            this.spcTwoGrids.Name = "spcTwoGrids";
            // 
            // spcTwoGrids.Panel1
            // 
            this.spcTwoGrids.Panel1.Controls.Add(this.dgvItems);
            // 
            // spcTwoGrids.Panel2
            // 
            this.spcTwoGrids.Panel2.Controls.Add(this.spcInternalGrid);
            this.spcTwoGrids.Size = new System.Drawing.Size(1304, 331);
            this.spcTwoGrids.SplitterDistance = 587;
            this.spcTwoGrids.TabIndex = 2;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToOrderColumns = true;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.expireDateDataGridViewTextBoxColumn,
            this.currVendorIDDataGridViewTextBoxColumn,
            this.currVendorNameDataGridViewTextBoxColumn,
            this.lotVendorIDDataGridViewTextBoxColumn,
            this.lotVendorNameDataGridViewTextBoxColumn,
            this.Manufacturer});
            this.dgvItems.DataSource = this.gAItemsBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(587, 331);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Назва товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 146;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серія";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 63;
            // 
            // expireDateDataGridViewTextBoxColumn
            // 
            this.expireDateDataGridViewTextBoxColumn.DataPropertyName = "ExpireDate";
            this.expireDateDataGridViewTextBoxColumn.HeaderText = "Термін придатності";
            this.expireDateDataGridViewTextBoxColumn.Name = "expireDateDataGridViewTextBoxColumn";
            this.expireDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expireDateDataGridViewTextBoxColumn.Width = 106;
            // 
            // currVendorIDDataGridViewTextBoxColumn
            // 
            this.currVendorIDDataGridViewTextBoxColumn.DataPropertyName = "CurrVendorID";
            this.currVendorIDDataGridViewTextBoxColumn.HeaderText = "Пост.";
            this.currVendorIDDataGridViewTextBoxColumn.Name = "currVendorIDDataGridViewTextBoxColumn";
            this.currVendorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.currVendorIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // currVendorNameDataGridViewTextBoxColumn
            // 
            this.currVendorNameDataGridViewTextBoxColumn.DataPropertyName = "CurrVendorName";
            this.currVendorNameDataGridViewTextBoxColumn.HeaderText = "Постачальник";
            this.currVendorNameDataGridViewTextBoxColumn.Name = "currVendorNameDataGridViewTextBoxColumn";
            this.currVendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.currVendorNameDataGridViewTextBoxColumn.Width = 90;
            // 
            // lotVendorIDDataGridViewTextBoxColumn
            // 
            this.lotVendorIDDataGridViewTextBoxColumn.DataPropertyName = "LotVendorID";
            this.lotVendorIDDataGridViewTextBoxColumn.HeaderText = "Іст. Пост.";
            this.lotVendorIDDataGridViewTextBoxColumn.Name = "lotVendorIDDataGridViewTextBoxColumn";
            this.lotVendorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotVendorIDDataGridViewTextBoxColumn.Width = 85;
            // 
            // lotVendorNameDataGridViewTextBoxColumn
            // 
            this.lotVendorNameDataGridViewTextBoxColumn.DataPropertyName = "LotVendorName";
            this.lotVendorNameDataGridViewTextBoxColumn.HeaderText = "Історичний постачальник";
            this.lotVendorNameDataGridViewTextBoxColumn.Name = "lotVendorNameDataGridViewTextBoxColumn";
            this.lotVendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotVendorNameDataGridViewTextBoxColumn.Width = 163;
            // 
            // Manufacturer
            // 
            this.Manufacturer.DataPropertyName = "Manufacturer";
            this.Manufacturer.HeaderText = "Виробник";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.Width = 111;
            // 
            // gAItemsBindingSource
            // 
            this.gAItemsBindingSource.DataMember = "GA_Items";
            this.gAItemsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.spcInternalGrid.Panel2.Controls.Add(this.dgvActDetails);
            this.spcInternalGrid.Size = new System.Drawing.Size(713, 331);
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
            this.spcVert1.Size = new System.Drawing.Size(73, 331);
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
            this.spcVert2.Panel1.Controls.Add(this.btnCreateItemForAct);
            this.spcVert2.Panel1.Controls.Add(this.btnFindItemForAct);
            this.spcVert2.Panel1.Controls.Add(this.btnRemoveFromAct);
            this.spcVert2.Panel1.Controls.Add(this.btnAddToAct);
            this.spcVert2.Size = new System.Drawing.Size(73, 276);
            this.spcVert2.SplitterDistance = 194;
            this.spcVert2.TabIndex = 0;
            // 
            // btnCreateItemForAct
            // 
            this.btnCreateItemForAct.Image = global::WMSOffice.Properties.Resources.add;
            this.btnCreateItemForAct.Location = new System.Drawing.Point(11, 146);
            this.btnCreateItemForAct.Name = "btnCreateItemForAct";
            this.btnCreateItemForAct.Size = new System.Drawing.Size(51, 38);
            this.btnCreateItemForAct.TabIndex = 3;
            this.btnCreateItemForAct.UseVisualStyleBackColor = true;
            this.btnCreateItemForAct.Click += new System.EventHandler(this.btnCreateItemForAct_Click);
            // 
            // btnFindItemForAct
            // 
            this.btnFindItemForAct.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnFindItemForAct.Location = new System.Drawing.Point(11, 8);
            this.btnFindItemForAct.Name = "btnFindItemForAct";
            this.btnFindItemForAct.Size = new System.Drawing.Size(51, 38);
            this.btnFindItemForAct.TabIndex = 2;
            this.btnFindItemForAct.UseVisualStyleBackColor = true;
            this.btnFindItemForAct.Click += new System.EventHandler(this.btnFindItemForAct_Click);
            // 
            // btnRemoveFromAct
            // 
            this.btnRemoveFromAct.Image = global::WMSOffice.Properties.Resources.arrow_left;
            this.btnRemoveFromAct.Location = new System.Drawing.Point(11, 100);
            this.btnRemoveFromAct.Name = "btnRemoveFromAct";
            this.btnRemoveFromAct.Size = new System.Drawing.Size(51, 38);
            this.btnRemoveFromAct.TabIndex = 1;
            this.btnRemoveFromAct.UseVisualStyleBackColor = true;
            this.btnRemoveFromAct.Click += new System.EventHandler(this.btnRemoveFromAct_Click);
            // 
            // btnAddToAct
            // 
            this.btnAddToAct.Image = global::WMSOffice.Properties.Resources.arrow_right;
            this.btnAddToAct.Location = new System.Drawing.Point(11, 54);
            this.btnAddToAct.Name = "btnAddToAct";
            this.btnAddToAct.Size = new System.Drawing.Size(51, 38);
            this.btnAddToAct.TabIndex = 0;
            this.btnAddToAct.UseVisualStyleBackColor = true;
            this.btnAddToAct.Click += new System.EventHandler(this.btnAddToAct_Click);
            // 
            // dgvActDetails
            // 
            this.dgvActDetails.AllowUserToAddRows = false;
            this.dgvActDetails.AllowUserToDeleteRows = false;
            this.dgvActDetails.AllowUserToOrderColumns = true;
            this.dgvActDetails.AllowUserToResizeRows = false;
            this.dgvActDetails.AutoGenerateColumns = false;
            this.dgvActDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvActDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvActDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn1,
            this.itemNameDataGridViewTextBoxColumn1,
            this.lotNumberDataGridViewTextBoxColumn1,
            this.expireDateDataGridViewTextBoxColumn1,
            this.currVendorIDDataGridViewTextBoxColumn1,
            this.currVendorNameDataGridViewTextBoxColumn1,
            this.lotVendorIDDataGridViewTextBoxColumn1,
            this.lotVendorNameDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1});
            this.dgvActDetails.DataSource = this.gADocDetailsBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActDetails.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvActDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvActDetails.Name = "dgvActDetails";
            this.dgvActDetails.ReadOnly = true;
            this.dgvActDetails.RowHeadersVisible = false;
            this.dgvActDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActDetails.Size = new System.Drawing.Size(636, 331);
            this.dgvActDetails.TabIndex = 0;
            this.dgvActDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActDetails_CellFormatting);
            this.dgvActDetails.SelectionChanged += new System.EventHandler(this.dgvActDetails_SelectionChanged);
            // 
            // itemIDDataGridViewTextBoxColumn1
            // 
            this.itemIDDataGridViewTextBoxColumn1.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn1.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn1.Name = "itemIDDataGridViewTextBoxColumn1";
            this.itemIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn1.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn1
            // 
            this.itemNameDataGridViewTextBoxColumn1.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn1.HeaderText = "Назва товара";
            this.itemNameDataGridViewTextBoxColumn1.Name = "itemNameDataGridViewTextBoxColumn1";
            this.itemNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn1.Width = 146;
            // 
            // lotNumberDataGridViewTextBoxColumn1
            // 
            this.lotNumberDataGridViewTextBoxColumn1.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn1.HeaderText = "Серія";
            this.lotNumberDataGridViewTextBoxColumn1.Name = "lotNumberDataGridViewTextBoxColumn1";
            this.lotNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn1.Width = 63;
            // 
            // expireDateDataGridViewTextBoxColumn1
            // 
            this.expireDateDataGridViewTextBoxColumn1.DataPropertyName = "ExpireDate";
            this.expireDateDataGridViewTextBoxColumn1.HeaderText = "Термін придатності";
            this.expireDateDataGridViewTextBoxColumn1.Name = "expireDateDataGridViewTextBoxColumn1";
            this.expireDateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.expireDateDataGridViewTextBoxColumn1.Width = 106;
            // 
            // currVendorIDDataGridViewTextBoxColumn1
            // 
            this.currVendorIDDataGridViewTextBoxColumn1.DataPropertyName = "CurrVendorID";
            this.currVendorIDDataGridViewTextBoxColumn1.HeaderText = "Пост.";
            this.currVendorIDDataGridViewTextBoxColumn1.Name = "currVendorIDDataGridViewTextBoxColumn1";
            this.currVendorIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.currVendorIDDataGridViewTextBoxColumn1.Width = 60;
            // 
            // currVendorNameDataGridViewTextBoxColumn1
            // 
            this.currVendorNameDataGridViewTextBoxColumn1.DataPropertyName = "CurrVendorName";
            this.currVendorNameDataGridViewTextBoxColumn1.HeaderText = "Постачальник";
            this.currVendorNameDataGridViewTextBoxColumn1.Name = "currVendorNameDataGridViewTextBoxColumn1";
            this.currVendorNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.currVendorNameDataGridViewTextBoxColumn1.Width = 90;
            // 
            // lotVendorIDDataGridViewTextBoxColumn1
            // 
            this.lotVendorIDDataGridViewTextBoxColumn1.DataPropertyName = "LotVendorID";
            this.lotVendorIDDataGridViewTextBoxColumn1.HeaderText = "Іст. Пост.";
            this.lotVendorIDDataGridViewTextBoxColumn1.Name = "lotVendorIDDataGridViewTextBoxColumn1";
            this.lotVendorIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.lotVendorIDDataGridViewTextBoxColumn1.Width = 85;
            // 
            // lotVendorNameDataGridViewTextBoxColumn1
            // 
            this.lotVendorNameDataGridViewTextBoxColumn1.DataPropertyName = "LotVendorName";
            this.lotVendorNameDataGridViewTextBoxColumn1.HeaderText = "Історичний постачальник";
            this.lotVendorNameDataGridViewTextBoxColumn1.Name = "lotVendorNameDataGridViewTextBoxColumn1";
            this.lotVendorNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.lotVendorNameDataGridViewTextBoxColumn1.Width = 163;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn1.HeaderText = "Виробник";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 111;
            // 
            // gADocDetailsBindingSource
            // 
            this.gADocDetailsBindingSource.DataMember = "GA_Doc_Details";
            this.gADocDetailsBindingSource.DataSource = this.quality;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.btnClearFilters);
            this.pnlFilter.Controls.Add(this.lblItems);
            this.pnlFilter.Controls.Add(this.tbFilter);
            this.pnlFilter.Controls.Add(this.tbLotNumber);
            this.pnlFilter.Controls.Add(this.chbAllLotNumbers);
            this.pnlFilter.Controls.Add(this.lblLotNumber);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 110);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1304, 81);
            this.pnlFilter.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(7, 28);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(115, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Фільтр для товарів:";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Image = global::WMSOffice.Properties.Resources.clear;
            this.btnClearFilters.Location = new System.Drawing.Point(782, 23);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 23);
            this.btnClearFilters.TabIndex = 5;
            this.btnClearFilters.Text = "Скинути";
            this.btnClearFilters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(7, 63);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(147, 13);
            this.lblItems.TabIndex = 6;
            this.lblItems.Text = "Оберіть товари для акта:";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(133, 24);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(207, 20);
            this.tbFilter.TabIndex = 1;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyDown);
            this.tbFilter.Enter += new System.EventHandler(this.tbxFilter_Enter);
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.Location = new System.Drawing.Point(641, 24);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.Size = new System.Drawing.Size(100, 20);
            this.tbLotNumber.TabIndex = 4;
            this.tbLotNumber.TextChanged += new System.EventHandler(this.tbLotNumber_TextChanged);
            // 
            // chbAllLotNumbers
            // 
            this.chbAllLotNumbers.AutoSize = true;
            this.chbAllLotNumbers.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbAllLotNumbers.Location = new System.Drawing.Point(407, 26);
            this.chbAllLotNumbers.Name = "chbAllLotNumbers";
            this.chbAllLotNumbers.Size = new System.Drawing.Size(78, 17);
            this.chbAllLotNumbers.TabIndex = 2;
            this.chbAllLotNumbers.Text = "Всі серії";
            this.chbAllLotNumbers.UseVisualStyleBackColor = true;
            this.chbAllLotNumbers.CheckedChanged += new System.EventHandler(this.chbAllLotNumbers_CheckedChanged);
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.AutoSize = true;
            this.lblLotNumber.Location = new System.Drawing.Point(594, 28);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(41, 13);
            this.lblLotNumber.TabIndex = 3;
            this.lblLotNumber.Text = "Серія:";
            // 
            // pnlDocHeader
            // 
            this.pnlDocHeader.BackColor = System.Drawing.SystemColors.Info;
            this.pnlDocHeader.Controls.Add(this.cmbInitiatorType);
            this.pnlDocHeader.Controls.Add(this.lblInitiatorTypeID);
            this.pnlDocHeader.Controls.Add(this.tblProtocolStatus);
            this.pnlDocHeader.Controls.Add(this.lblProtocolStatus);
            this.pnlDocHeader.Controls.Add(this.tbProtocolID);
            this.pnlDocHeader.Controls.Add(this.lblProtocolID);
            this.pnlDocHeader.Controls.Add(this.tbReason);
            this.pnlDocHeader.Controls.Add(this.lblReason);
            this.pnlDocHeader.Controls.Add(this.cmbWorkType);
            this.pnlDocHeader.Controls.Add(this.lblWorkTypeID);
            this.pnlDocHeader.Controls.Add(this.cmbDocType);
            this.pnlDocHeader.Controls.Add(this.tbDocAttachment);
            this.pnlDocHeader.Controls.Add(this.lblDocAttachment);
            this.pnlDocHeader.Controls.Add(this.btnDocAttachment);
            this.pnlDocHeader.Controls.Add(this.lblDocType);
            this.pnlDocHeader.Controls.Add(this.lblDocDate);
            this.pnlDocHeader.Controls.Add(this.dtpDocDate);
            this.pnlDocHeader.Controls.Add(this.tbDocNumber);
            this.pnlDocHeader.Controls.Add(this.lblDocNumber);
            this.pnlDocHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDocHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDocHeader.Name = "pnlDocHeader";
            this.pnlDocHeader.Size = new System.Drawing.Size(1304, 110);
            this.pnlDocHeader.TabIndex = 0;
            // 
            // cmbInitiatorType
            // 
            this.cmbInitiatorType.DataSource = this.gARecallInitiatorTypesBindingSource;
            this.cmbInitiatorType.DisplayMember = "InitiatorDescr";
            this.cmbInitiatorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInitiatorType.FormattingEnabled = true;
            this.cmbInitiatorType.Location = new System.Drawing.Point(1089, 82);
            this.cmbInitiatorType.Name = "cmbInitiatorType";
            this.cmbInitiatorType.Size = new System.Drawing.Size(207, 21);
            this.cmbInitiatorType.TabIndex = 14;
            this.cmbInitiatorType.ValueMember = "InitiatorID";
            // 
            // gARecallInitiatorTypesBindingSource
            // 
            this.gARecallInitiatorTypesBindingSource.DataMember = "GA_Recall_Initiator_Types";
            this.gARecallInitiatorTypesBindingSource.DataSource = this.quality;
            // 
            // lblInitiatorTypeID
            // 
            this.lblInitiatorTypeID.AutoSize = true;
            this.lblInitiatorTypeID.Location = new System.Drawing.Point(949, 86);
            this.lblInitiatorTypeID.Name = "lblInitiatorTypeID";
            this.lblInitiatorTypeID.Size = new System.Drawing.Size(105, 13);
            this.lblInitiatorTypeID.TabIndex = 13;
            this.lblInitiatorTypeID.Text = "Иніціатор відкликання:";
            // 
            // tblProtocolStatus
            // 
            this.tblProtocolStatus.Location = new System.Drawing.Point(1089, 45);
            this.tblProtocolStatus.Name = "tblProtocolStatus";
            this.tblProtocolStatus.Size = new System.Drawing.Size(207, 20);
            this.tblProtocolStatus.TabIndex = 18;
            // 
            // lblProtocolStatus
            // 
            this.lblProtocolStatus.AutoSize = true;
            this.lblProtocolStatus.Location = new System.Drawing.Point(949, 49);
            this.lblProtocolStatus.Name = "lblProtocolStatus";
            this.lblProtocolStatus.Size = new System.Drawing.Size(100, 13);
            this.lblProtocolStatus.TabIndex = 17;
            this.lblProtocolStatus.Text = "Статус протокола:";
            // 
            // tbProtocolID
            // 
            this.tbProtocolID.Location = new System.Drawing.Point(1089, 8);
            this.tbProtocolID.Name = "tbProtocolID";
            this.tbProtocolID.Size = new System.Drawing.Size(207, 20);
            this.tbProtocolID.TabIndex = 16;
            // 
            // lblProtocolID
            // 
            this.lblProtocolID.AutoSize = true;
            this.lblProtocolID.Location = new System.Drawing.Point(949, 12);
            this.lblProtocolID.Name = "lblProtocolID";
            this.lblProtocolID.Size = new System.Drawing.Size(77, 13);
            this.lblProtocolID.TabIndex = 15;
            this.lblProtocolID.Text = "№ протокола:";
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(535, 82);
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(347, 20);
            this.tbReason.TabIndex = 12;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(407, 86);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(93, 13);
            this.lblReason.TabIndex = 11;
            this.lblReason.Text = "Причина відкликання:";
            // 
            // cmbWorkType
            // 
            this.cmbWorkType.DataSource = this.gAWorkTypesBindingSource;
            this.cmbWorkType.DisplayMember = "WorkTypeDescr";
            this.cmbWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkType.FormattingEnabled = true;
            this.cmbWorkType.Location = new System.Drawing.Point(133, 82);
            this.cmbWorkType.Name = "cmbWorkType";
            this.cmbWorkType.Size = new System.Drawing.Size(207, 21);
            this.cmbWorkType.TabIndex = 10;
            this.cmbWorkType.ValueMember = "WorkTypeID";
            // 
            // gAWorkTypesBindingSource
            // 
            this.gAWorkTypesBindingSource.DataMember = "GA_Work_Types";
            this.gAWorkTypesBindingSource.DataSource = this.quality;
            // 
            // lblWorkTypeID
            // 
            this.lblWorkTypeID.AutoSize = true;
            this.lblWorkTypeID.Location = new System.Drawing.Point(7, 86);
            this.lblWorkTypeID.Name = "lblWorkTypeID";
            this.lblWorkTypeID.Size = new System.Drawing.Size(69, 13);
            this.lblWorkTypeID.TabIndex = 9;
            this.lblWorkTypeID.Text = "Вид відкликання:";
            // 
            // cmbDocType
            // 
            this.cmbDocType.DataSource = this.gADocTypesBindingSource;
            this.cmbDocType.DisplayMember = "DocTypeFormattedName";
            this.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Location = new System.Drawing.Point(133, 8);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(207, 21);
            this.cmbDocType.TabIndex = 1;
            this.cmbDocType.ValueMember = "DocType";
            // 
            // gADocTypesBindingSource
            // 
            this.gADocTypesBindingSource.DataMember = "GA_Doc_Types";
            this.gADocTypesBindingSource.DataSource = this.quality;
            // 
            // tbDocAttachment
            // 
            this.tbDocAttachment.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocAttachment.Location = new System.Drawing.Point(641, 45);
            this.tbDocAttachment.Name = "tbDocAttachment";
            this.tbDocAttachment.ReadOnly = true;
            this.tbDocAttachment.Size = new System.Drawing.Size(241, 20);
            this.tbDocAttachment.TabIndex = 8;
            // 
            // lblDocAttachment
            // 
            this.lblDocAttachment.AutoSize = true;
            this.lblDocAttachment.Location = new System.Drawing.Point(407, 49);
            this.lblDocAttachment.Name = "lblDocAttachment";
            this.lblDocAttachment.Size = new System.Drawing.Size(61, 13);
            this.lblDocAttachment.TabIndex = 6;
            this.lblDocAttachment.Text = "Вкладення:";
            // 
            // btnDocAttachment
            // 
            this.btnDocAttachment.Image = global::WMSOffice.Properties.Resources.open_folder_icon;
            this.btnDocAttachment.Location = new System.Drawing.Point(535, 44);
            this.btnDocAttachment.Name = "btnDocAttachment";
            this.btnDocAttachment.Size = new System.Drawing.Size(100, 23);
            this.btnDocAttachment.TabIndex = 7;
            this.btnDocAttachment.Text = "Файл";
            this.btnDocAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocAttachment.UseVisualStyleBackColor = true;
            this.btnDocAttachment.Click += new System.EventHandler(this.btnDocAttachment_Click);
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(7, 12);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(98, 13);
            this.lblDocType.TabIndex = 0;
            this.lblDocType.Text = "Тип припису:";
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Location = new System.Drawing.Point(407, 12);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(105, 13);
            this.lblDocDate.TabIndex = 2;
            this.lblDocDate.Text = "Дата припису:";
            // 
            // dtpDocDate
            // 
            this.dtpDocDate.CustomFormat = "dd.MM.yyyy";
            this.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocDate.Location = new System.Drawing.Point(535, 8);
            this.dtpDocDate.Name = "dtpDocDate";
            this.dtpDocDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDocDate.TabIndex = 3;
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.Location = new System.Drawing.Point(133, 45);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.Size = new System.Drawing.Size(207, 20);
            this.tbDocNumber.TabIndex = 5;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(7, 49);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(90, 13);
            this.lblDocNumber.TabIndex = 4;
            this.lblDocNumber.Text = "№ припису:";
            // 
            // gA_ItemsTableAdapter
            // 
            this.gA_ItemsTableAdapter.ClearBeforeFill = true;
            // 
            // gA_Doc_DetailsTableAdapter
            // 
            this.gA_Doc_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // gA_Doc_TypesTableAdapter
            // 
            this.gA_Doc_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // gA_Work_TypesTableAdapter
            // 
            this.gA_Work_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // gA_Recall_Initiator_TypesTableAdapter
            // 
            this.gA_Recall_Initiator_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // QualityGLSActEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 571);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "QualityGLSActEditForm";
            this.Text = "Акт розпоряджень";
            this.Load += new System.EventHandler(this.QualityGLSActEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityGLSActEditForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.spcTwoGrids.Panel1.ResumeLayout(false);
            this.spcTwoGrids.Panel2.ResumeLayout(false);
            this.spcTwoGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.spcInternalGrid.Panel1.ResumeLayout(false);
            this.spcInternalGrid.Panel2.ResumeLayout(false);
            this.spcInternalGrid.ResumeLayout(false);
            this.spcVert1.Panel2.ResumeLayout(false);
            this.spcVert1.ResumeLayout(false);
            this.spcVert2.Panel1.ResumeLayout(false);
            this.spcVert2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADocDetailsBindingSource)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlDocHeader.ResumeLayout(false);
            this.pnlDocHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gARecallInitiatorTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAWorkTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADocTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.SplitContainer spcTwoGrids;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource gAItemsBindingSource;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.SplitContainer spcInternalGrid;
        private System.Windows.Forms.SplitContainer spcVert1;
        private System.Windows.Forms.SplitContainer spcVert2;
        private System.Windows.Forms.Button btnRemoveFromAct;
        private System.Windows.Forms.Button btnAddToAct;
        private System.Windows.Forms.DataGridView dgvActDetails;
        private System.Windows.Forms.BindingSource gADocDetailsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.GA_ItemsTableAdapter gA_ItemsTableAdapter;
        private WMSOffice.Data.QualityTableAdapters.GA_Doc_DetailsTableAdapter gA_Doc_DetailsTableAdapter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.DateTimePicker dtpDocDate;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.BindingSource gADocTypesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.GA_Doc_TypesTableAdapter gA_Doc_TypesTableAdapter;
        private System.Windows.Forms.Label lblDocAttachment;
        private System.Windows.Forms.TextBox tbDocAttachment;
        private System.Windows.Forms.Button btnDocAttachment;
        private System.Windows.Forms.Panel pnlDocHeader;
        private System.Windows.Forms.CheckBox chbAllLotNumbers;
        private System.Windows.Forms.TextBox tbLotNumber;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Button btnFindItemForAct;
        private System.Windows.Forms.ComboBox cmbWorkType;
        private System.Windows.Forms.Label lblWorkTypeID;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox tblProtocolStatus;
        private System.Windows.Forms.Label lblProtocolStatus;
        private System.Windows.Forms.TextBox tbProtocolID;
        private System.Windows.Forms.Label lblProtocolID;
        private System.Windows.Forms.BindingSource gAWorkTypesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.GA_Work_TypesTableAdapter gA_Work_TypesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expireDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currVendorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currVendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotVendorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotVendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn expireDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn currVendorIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn currVendorNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotVendorIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotVendorNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnCreateItemForAct;
        private System.Windows.Forms.ComboBox cmbInitiatorType;
        private System.Windows.Forms.Label lblInitiatorTypeID;
        private System.Windows.Forms.BindingSource gARecallInitiatorTypesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.GA_Recall_Initiator_TypesTableAdapter gA_Recall_Initiator_TypesTableAdapter;
    }
}