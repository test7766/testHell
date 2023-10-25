namespace WMSOffice.Dialogs.Quality
{
    partial class ImportLicenseRequestItemsSelectorForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.spcTwoGrids = new System.Windows.Forms.SplitContainer();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.qKLISearchItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.spcInternalGrid = new System.Windows.Forms.SplitContainer();
            this.spcVert1 = new System.Windows.Forms.SplitContainer();
            this.spcVert2 = new System.Windows.Forms.SplitContainer();
            this.btnFindItemForRequest = new System.Windows.Forms.Button();
            this.btnRemoveFromRequest = new System.Windows.Forms.Button();
            this.btnAddToRequest = new System.Windows.Forms.Button();
            this.dgvRequestItems = new System.Windows.Forms.DataGridView();
            this.qKLISearchItemsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.qualityRequests = new WMSOffice.Data.Quality();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.stbVendor = new WMSOffice.Controls.SearchTextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblItems = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.chbOnlyNeedProcessLicense = new System.Windows.Forms.CheckBox();
            this.qK_LI_Search_ItemsTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_LI_Search_ItemsTableAdapter();
            this.dgvcColdType = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MNN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEndReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GMPDateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcColdTypeRequests = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.spcTwoGrids.Panel1.SuspendLayout();
            this.spcTwoGrids.Panel2.SuspendLayout();
            this.spcTwoGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLISearchItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.spcInternalGrid.Panel1.SuspendLayout();
            this.spcInternalGrid.Panel2.SuspendLayout();
            this.spcInternalGrid.SuspendLayout();
            this.spcVert1.Panel2.SuspendLayout();
            this.spcVert1.SuspendLayout();
            this.spcVert2.Panel1.SuspendLayout();
            this.spcVert2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLISearchItemsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityRequests)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3437, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3527, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 430);
            this.pnlButtons.Size = new System.Drawing.Size(894, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.pnlDetails);
            this.pnlContent.Controls.Add(this.pnlFilter);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(894, 424);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.spcTwoGrids);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 90);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(894, 334);
            this.pnlDetails.TabIndex = 1;
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
            this.spcTwoGrids.Size = new System.Drawing.Size(894, 334);
            this.spcTwoGrids.SplitterDistance = 402;
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
            this.dgvcColdType,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.MNN,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vendorDataGridViewTextBoxColumn,
            this.NoReg,
            this.DateEndReg,
            this.GMP,
            this.GMPDateTo,
            this.Memo});
            this.dgvItems.DataSource = this.qKLISearchItemsBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(402, 334);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            this.dgvItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // qKLISearchItemsBindingSource
            // 
            this.qKLISearchItemsBindingSource.DataMember = "QK_LI_Search_Items";
            this.qKLISearchItemsBindingSource.DataSource = this.quality;
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
            this.spcInternalGrid.Panel2.Controls.Add(this.dgvRequestItems);
            this.spcInternalGrid.Size = new System.Drawing.Size(488, 334);
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
            this.spcVert1.Size = new System.Drawing.Size(73, 334);
            this.spcVert1.SplitterDistance = 68;
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
            this.spcVert2.Panel1.Controls.Add(this.btnFindItemForRequest);
            this.spcVert2.Panel1.Controls.Add(this.btnRemoveFromRequest);
            this.spcVert2.Panel1.Controls.Add(this.btnAddToRequest);
            this.spcVert2.Size = new System.Drawing.Size(73, 262);
            this.spcVert2.SplitterDistance = 145;
            this.spcVert2.TabIndex = 0;
            // 
            // btnFindItemForRequest
            // 
            this.btnFindItemForRequest.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnFindItemForRequest.Location = new System.Drawing.Point(11, 8);
            this.btnFindItemForRequest.Name = "btnFindItemForRequest";
            this.btnFindItemForRequest.Size = new System.Drawing.Size(51, 38);
            this.btnFindItemForRequest.TabIndex = 2;
            this.btnFindItemForRequest.UseVisualStyleBackColor = true;
            this.btnFindItemForRequest.Click += new System.EventHandler(this.btnFindItemForRequest_Click);
            // 
            // btnRemoveFromRequest
            // 
            this.btnRemoveFromRequest.Image = global::WMSOffice.Properties.Resources.arrow_left;
            this.btnRemoveFromRequest.Location = new System.Drawing.Point(11, 100);
            this.btnRemoveFromRequest.Name = "btnRemoveFromRequest";
            this.btnRemoveFromRequest.Size = new System.Drawing.Size(51, 38);
            this.btnRemoveFromRequest.TabIndex = 1;
            this.btnRemoveFromRequest.UseVisualStyleBackColor = true;
            this.btnRemoveFromRequest.Click += new System.EventHandler(this.btnRemoveFromRequest_Click);
            // 
            // btnAddToRequest
            // 
            this.btnAddToRequest.Image = global::WMSOffice.Properties.Resources.arrow_right;
            this.btnAddToRequest.Location = new System.Drawing.Point(11, 54);
            this.btnAddToRequest.Name = "btnAddToRequest";
            this.btnAddToRequest.Size = new System.Drawing.Size(51, 38);
            this.btnAddToRequest.TabIndex = 0;
            this.btnAddToRequest.UseVisualStyleBackColor = true;
            this.btnAddToRequest.Click += new System.EventHandler(this.btnAddToRequest_Click);
            // 
            // dgvRequestItems
            // 
            this.dgvRequestItems.AllowUserToAddRows = false;
            this.dgvRequestItems.AllowUserToDeleteRows = false;
            this.dgvRequestItems.AllowUserToOrderColumns = true;
            this.dgvRequestItems.AllowUserToResizeRows = false;
            this.dgvRequestItems.AutoGenerateColumns = false;
            this.dgvRequestItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRequestItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRequestItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcColdTypeRequests,
            this.itemIDDataGridViewTextBoxColumn1,
            this.itemNameDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.manufacturerDataGridViewTextBoxColumn1,
            this.vendorDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvRequestItems.DataSource = this.qKLISearchItemsBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequestItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRequestItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequestItems.Location = new System.Drawing.Point(0, 0);
            this.dgvRequestItems.Name = "dgvRequestItems";
            this.dgvRequestItems.ReadOnly = true;
            this.dgvRequestItems.RowHeadersVisible = false;
            this.dgvRequestItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequestItems.Size = new System.Drawing.Size(411, 334);
            this.dgvRequestItems.TabIndex = 0;
            this.dgvRequestItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            this.dgvRequestItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgvRequestItems.SelectionChanged += new System.EventHandler(this.dgvRequestItems_SelectionChanged);
            // 
            // qKLISearchItemsBindingSource1
            // 
            this.qKLISearchItemsBindingSource1.DataMember = "QK_LI_Search_Items";
            this.qKLISearchItemsBindingSource1.DataSource = this.qualityRequests;
            // 
            // qualityRequests
            // 
            this.qualityRequests.DataSetName = "Quality";
            this.qualityRequests.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlFilter.Controls.Add(this.tbVendor);
            this.pnlFilter.Controls.Add(this.stbVendor);
            this.pnlFilter.Controls.Add(this.lblVendor);
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.btnClearFilters);
            this.pnlFilter.Controls.Add(this.lblItems);
            this.pnlFilter.Controls.Add(this.tbFilter);
            this.pnlFilter.Controls.Add(this.chbOnlyNeedProcessLicense);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(894, 90);
            this.pnlFilter.TabIndex = 0;
            // 
            // tbVendor
            // 
            this.tbVendor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVendor.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendor.Location = new System.Drawing.Point(254, 6);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.ReadOnly = true;
            this.tbVendor.Size = new System.Drawing.Size(628, 20);
            this.tbVendor.TabIndex = 2;
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(128, 6);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.NavigateByValue = false;
            this.stbVendor.ReadOnly = false;
            this.stbVendor.Size = new System.Drawing.Size(120, 20);
            this.stbVendor.TabIndex = 1;
            this.stbVendor.UserID = ((long)(0));
            this.stbVendor.Value = null;
            this.stbVendor.ValueReferenceQuery = null;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(7, 10);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "Поставщик:";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(7, 39);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(115, 13);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Фильтр для товаров:";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilters.Image = global::WMSOffice.Properties.Resources.clear;
            this.btnClearFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearFilters.Location = new System.Drawing.Point(822, 34);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(60, 23);
            this.btnClearFilters.TabIndex = 6;
            this.btnClearFilters.Text = "Сброс";
            this.btnClearFilters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(7, 72);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(160, 13);
            this.lblItems.TabIndex = 7;
            this.lblItems.Text = "Выберите товары для уведомления:";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(128, 35);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(120, 20);
            this.tbFilter.TabIndex = 4;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyDown);
            this.tbFilter.Enter += new System.EventHandler(this.tbFilter_Enter);
            // 
            // chbOnlyNeedProcessLicense
            // 
            this.chbOnlyNeedProcessLicense.AutoSize = true;
            this.chbOnlyNeedProcessLicense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbOnlyNeedProcessLicense.ForeColor = System.Drawing.Color.Blue;
            this.chbOnlyNeedProcessLicense.Location = new System.Drawing.Point(254, 37);
            this.chbOnlyNeedProcessLicense.Name = "chbOnlyNeedProcessLicense";
            this.chbOnlyNeedProcessLicense.Size = new System.Drawing.Size(216, 17);
            this.chbOnlyNeedProcessLicense.TabIndex = 5;
            this.chbOnlyNeedProcessLicense.Text = "Только товары требующие лицензию";
            this.chbOnlyNeedProcessLicense.UseVisualStyleBackColor = true;
            this.chbOnlyNeedProcessLicense.CheckedChanged += new System.EventHandler(this.chbOnlyNeedLicense_CheckedChanged);
            // 
            // qK_LI_Search_ItemsTableAdapter
            // 
            this.qK_LI_Search_ItemsTableAdapter.ClearBeforeFill = true;
            // 
            // dgvcColdType
            // 
            this.dgvcColdType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvcColdType.HeaderText = "";
            this.dgvcColdType.Name = "dgvcColdType";
            this.dgvcColdType.ReadOnly = true;
            this.dgvcColdType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcColdType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcColdType.Width = 19;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 146;
            // 
            // MNN
            // 
            this.MNN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MNN.DataPropertyName = "MNN";
            this.MNN.HeaderText = "МНН";
            this.MNN.Name = "MNN";
            this.MNN.ReadOnly = true;
            this.MNN.Width = 57;
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
            // vendorDataGridViewTextBoxColumn
            // 
            this.vendorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorDataGridViewTextBoxColumn.DataPropertyName = "Vendor";
            this.vendorDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.vendorDataGridViewTextBoxColumn.Name = "vendorDataGridViewTextBoxColumn";
            this.vendorDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorDataGridViewTextBoxColumn.Width = 90;
            // 
            // NoReg
            // 
            this.NoReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoReg.DataPropertyName = "NoReg";
            this.NoReg.HeaderText = "Номер РС в Украине";
            this.NoReg.Name = "NoReg";
            this.NoReg.ReadOnly = true;
            this.NoReg.Width = 139;
            // 
            // DateEndReg
            // 
            this.DateEndReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateEndReg.DataPropertyName = "DateEndReg";
            this.DateEndReg.HeaderText = "Срок действия РС в Украине";
            this.DateEndReg.Name = "DateEndReg";
            this.DateEndReg.ReadOnly = true;
            this.DateEndReg.Width = 180;
            // 
            // GMP
            // 
            this.GMP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GMP.DataPropertyName = "GMP";
            this.GMP.HeaderText = "GMP";
            this.GMP.Name = "GMP";
            this.GMP.ReadOnly = true;
            this.GMP.Width = 56;
            // 
            // GMPDateTo
            // 
            this.GMPDateTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GMPDateTo.DataPropertyName = "GMPDateTo";
            this.GMPDateTo.HeaderText = "Срок действия GMP";
            this.GMPDateTo.Name = "GMPDateTo";
            this.GMPDateTo.ReadOnly = true;
            this.GMPDateTo.Width = 134;
            // 
            // Memo
            // 
            this.Memo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "Примечание";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            this.Memo.Width = 95;
            // 
            // dgvcColdTypeRequests
            // 
            this.dgvcColdTypeRequests.HeaderText = "";
            this.dgvcColdTypeRequests.Name = "dgvcColdTypeRequests";
            this.dgvcColdTypeRequests.ReadOnly = true;
            this.dgvcColdTypeRequests.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcColdTypeRequests.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcColdTypeRequests.Width = 19;
            // 
            // itemIDDataGridViewTextBoxColumn1
            // 
            this.itemIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn1.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn1.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn1.Name = "itemIDDataGridViewTextBoxColumn1";
            this.itemIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn1.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn1
            // 
            this.itemNameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn1.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn1.HeaderText = "Наименование товара";
            this.itemNameDataGridViewTextBoxColumn1.Name = "itemNameDataGridViewTextBoxColumn1";
            this.itemNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn1.Width = 146;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MNN";
            this.dataGridViewTextBoxColumn1.HeaderText = "МНН";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 57;
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
            // vendorDataGridViewTextBoxColumn1
            // 
            this.vendorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorDataGridViewTextBoxColumn1.DataPropertyName = "Vendor";
            this.vendorDataGridViewTextBoxColumn1.HeaderText = "Поставщик";
            this.vendorDataGridViewTextBoxColumn1.Name = "vendorDataGridViewTextBoxColumn1";
            this.vendorDataGridViewTextBoxColumn1.ReadOnly = true;
            this.vendorDataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NoReg";
            this.dataGridViewTextBoxColumn2.HeaderText = "Номер РС в Украине";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 139;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DateEndReg";
            this.dataGridViewTextBoxColumn3.HeaderText = "Срок действия РС в Украине";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "GMP";
            this.dataGridViewTextBoxColumn4.HeaderText = "GMP";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 56;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "GMPDateTo";
            this.dataGridViewTextBoxColumn5.HeaderText = "Срок действия GMP";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 134;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn6.HeaderText = "Примечание";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 95;
            // 
            // ImportLicenseRequestItemsSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 473);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "ImportLicenseRequestItemsSelectorForm";
            this.Text = "Выбор товара для уведомления на обновление лицензии на импорт";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.spcTwoGrids.Panel1.ResumeLayout(false);
            this.spcTwoGrids.Panel2.ResumeLayout(false);
            this.spcTwoGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLISearchItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.spcInternalGrid.Panel1.ResumeLayout(false);
            this.spcInternalGrid.Panel2.ResumeLayout(false);
            this.spcInternalGrid.ResumeLayout(false);
            this.spcVert1.Panel2.ResumeLayout(false);
            this.spcVert1.ResumeLayout(false);
            this.spcVert2.Panel1.ResumeLayout(false);
            this.spcVert2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLISearchItemsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityRequests)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.CheckBox chbOnlyNeedProcessLicense;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.SplitContainer spcTwoGrids;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.SplitContainer spcInternalGrid;
        private System.Windows.Forms.SplitContainer spcVert1;
        private System.Windows.Forms.SplitContainer spcVert2;
        private System.Windows.Forms.Button btnFindItemForRequest;
        private System.Windows.Forms.Button btnRemoveFromRequest;
        private System.Windows.Forms.Button btnAddToRequest;
        private System.Windows.Forms.DataGridView dgvRequestItems;
        private System.Windows.Forms.TextBox tbVendor;
        private WMSOffice.Controls.SearchTextBox stbVendor;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.BindingSource qKLISearchItemsBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_LI_Search_ItemsTableAdapter qK_LI_Search_ItemsTableAdapter;
        private System.Windows.Forms.BindingSource qKLISearchItemsBindingSource1;
        private WMSOffice.Data.Quality qualityRequests;
        private System.Windows.Forms.DataGridViewImageColumn dgvcColdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MNN;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateEndReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn GMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GMPDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewImageColumn dgvcColdTypeRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}