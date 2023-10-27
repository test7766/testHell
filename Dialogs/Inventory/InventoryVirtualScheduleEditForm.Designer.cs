namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryVirtualScheduleEditForm
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
            this.cmbInventoryType = new System.Windows.Forms.ComboBox();
            this.inventoriesVirtualScheduleTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.inventoriesVirtualScheduleTypesTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoriesVirtualScheduleTypesTableAdapter();
            this.dgvWarehouses = new System.Windows.Forms.DataGridView();
            this.checkedflagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.warehouseidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehousenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoriesVirtualScheduleWarehousesElementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoriesVirtualScheduleWarehousesElementsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoriesVirtualScheduleWarehousesElementsTableAdapter();
            this.pnlWarehouses = new System.Windows.Forms.Panel();
            this.pnlWarehousesContent = new System.Windows.Forms.Panel();
            this.lblWarehouses = new System.Windows.Forms.Label();
            this.lblInventoryType = new System.Windows.Forms.Label();
            this.dtpInventoryPlanTime = new System.Windows.Forms.DateTimePicker();
            this.lblInventoryPlanTime = new System.Windows.Forms.Label();
            this.lblInventoryPlanDate = new System.Windows.Forms.Label();
            this.dtpInventoryPlanDate = new System.Windows.Forms.DateTimePicker();
            this.nudOutMove = new System.Windows.Forms.NumericUpDown();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.pnlParametersContent = new System.Windows.Forms.Panel();
            this.lblPriceTo = new System.Windows.Forms.Label();
            this.lblPriceFrom = new System.Windows.Forms.Label();
            this.cbOutInv = new System.Windows.Forms.CheckBox();
            this.cbOutMove = new System.Windows.Forms.CheckBox();
            this.cbCategory = new System.Windows.Forms.CheckBox();
            this.cbPricesRange = new System.Windows.Forms.CheckBox();
            this.cbQtyItems = new System.Windows.Forms.CheckBox();
            this.nudOutInv = new System.Windows.Forms.NumericUpDown();
            this.nudQtyItems = new System.Windows.Forms.NumericUpDown();
            this.nudPriceTo = new System.Windows.Forms.NumericUpDown();
            this.nudPriceFrom = new System.Windows.Forms.NumericUpDown();
            this.lblParameters = new System.Windows.Forms.Label();
            this.inventoriesVirtualScheduleCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.inventoriesVirtualScheduleCategoriesTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoriesVirtualScheduleCategoriesTableAdapter();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesVirtualScheduleTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesVirtualScheduleWarehousesElementsBindingSource)).BeginInit();
            this.pnlWarehouses.SuspendLayout();
            this.pnlWarehousesContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutMove)).BeginInit();
            this.pnlParameters.SuspendLayout();
            this.pnlParametersContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtyItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesVirtualScheduleCategoriesBindingSource)).BeginInit();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1055, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1145, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 532);
            this.pnlButtons.Size = new System.Drawing.Size(644, 43);
            this.pnlButtons.TabIndex = 9;
            // 
            // cmbInventoryType
            // 
            this.cmbInventoryType.DataSource = this.inventoriesVirtualScheduleTypesBindingSource;
            this.cmbInventoryType.DisplayMember = "fi_dsc";
            this.cmbInventoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventoryType.FormattingEnabled = true;
            this.cmbInventoryType.Location = new System.Drawing.Point(47, 6);
            this.cmbInventoryType.Name = "cmbInventoryType";
            this.cmbInventoryType.Size = new System.Drawing.Size(300, 21);
            this.cmbInventoryType.TabIndex = 1;
            this.cmbInventoryType.ValueMember = "fi_type";
            // 
            // inventoriesVirtualScheduleTypesBindingSource
            // 
            this.inventoriesVirtualScheduleTypesBindingSource.DataMember = "InventoriesVirtualScheduleTypes";
            this.inventoriesVirtualScheduleTypesBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoriesVirtualScheduleTypesTableAdapter
            // 
            this.inventoriesVirtualScheduleTypesTableAdapter.ClearBeforeFill = true;
            // 
            // dgvWarehouses
            // 
            this.dgvWarehouses.AllowUserToAddRows = false;
            this.dgvWarehouses.AllowUserToDeleteRows = false;
            this.dgvWarehouses.AllowUserToResizeRows = false;
            this.dgvWarehouses.AutoGenerateColumns = false;
            this.dgvWarehouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedflagDataGridViewCheckBoxColumn,
            this.warehouseidDataGridViewTextBoxColumn,
            this.warehousenameDataGridViewTextBoxColumn});
            this.dgvWarehouses.DataSource = this.inventoriesVirtualScheduleWarehousesElementsBindingSource;
            this.dgvWarehouses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarehouses.Location = new System.Drawing.Point(0, 0);
            this.dgvWarehouses.MultiSelect = false;
            this.dgvWarehouses.Name = "dgvWarehouses";
            this.dgvWarehouses.RowHeadersVisible = false;
            this.dgvWarehouses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouses.Size = new System.Drawing.Size(644, 226);
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
            // inventoriesVirtualScheduleWarehousesElementsBindingSource
            // 
            this.inventoriesVirtualScheduleWarehousesElementsBindingSource.DataMember = "InventoriesVirtualScheduleWarehousesElements";
            this.inventoriesVirtualScheduleWarehousesElementsBindingSource.DataSource = this.inventory;
            // 
            // inventoriesVirtualScheduleWarehousesElementsTableAdapter
            // 
            this.inventoriesVirtualScheduleWarehousesElementsTableAdapter.ClearBeforeFill = true;
            // 
            // pnlWarehouses
            // 
            this.pnlWarehouses.Controls.Add(this.pnlWarehousesContent);
            this.pnlWarehouses.Controls.Add(this.lblWarehouses);
            this.pnlWarehouses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarehouses.Location = new System.Drawing.Point(0, 0);
            this.pnlWarehouses.Name = "pnlWarehouses";
            this.pnlWarehouses.Size = new System.Drawing.Size(644, 246);
            this.pnlWarehouses.TabIndex = 1;
            // 
            // pnlWarehousesContent
            // 
            this.pnlWarehousesContent.Controls.Add(this.dgvWarehouses);
            this.pnlWarehousesContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarehousesContent.Location = new System.Drawing.Point(0, 20);
            this.pnlWarehousesContent.Name = "pnlWarehousesContent";
            this.pnlWarehousesContent.Size = new System.Drawing.Size(644, 226);
            this.pnlWarehousesContent.TabIndex = 1;
            // 
            // lblWarehouses
            // 
            this.lblWarehouses.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblWarehouses.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWarehouses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarehouses.Location = new System.Drawing.Point(0, 0);
            this.lblWarehouses.Name = "lblWarehouses";
            this.lblWarehouses.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblWarehouses.Size = new System.Drawing.Size(644, 20);
            this.lblWarehouses.TabIndex = 0;
            this.lblWarehouses.Text = "Склади";
            // 
            // lblInventoryType
            // 
            this.lblInventoryType.AutoSize = true;
            this.lblInventoryType.Location = new System.Drawing.Point(10, 10);
            this.lblInventoryType.Name = "lblInventoryType";
            this.lblInventoryType.Size = new System.Drawing.Size(29, 13);
            this.lblInventoryType.TabIndex = 0;
            this.lblInventoryType.Text = "Тип:";
            // 
            // dtpInventoryPlanTime
            // 
            this.dtpInventoryPlanTime.CustomFormat = "HH:mm";
            this.dtpInventoryPlanTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInventoryPlanTime.Location = new System.Drawing.Point(287, 35);
            this.dtpInventoryPlanTime.Name = "dtpInventoryPlanTime";
            this.dtpInventoryPlanTime.ShowUpDown = true;
            this.dtpInventoryPlanTime.Size = new System.Drawing.Size(60, 20);
            this.dtpInventoryPlanTime.TabIndex = 5;
            // 
            // lblInventoryPlanTime
            // 
            this.lblInventoryPlanTime.AutoSize = true;
            this.lblInventoryPlanTime.Location = new System.Drawing.Point(251, 39);
            this.lblInventoryPlanTime.Name = "lblInventoryPlanTime";
            this.lblInventoryPlanTime.Size = new System.Drawing.Size(30, 13);
            this.lblInventoryPlanTime.TabIndex = 4;
            this.lblInventoryPlanTime.Text = "Час:";
            // 
            // lblInventoryPlanDate
            // 
            this.lblInventoryPlanDate.AutoSize = true;
            this.lblInventoryPlanDate.Location = new System.Drawing.Point(10, 39);
            this.lblInventoryPlanDate.Name = "lblInventoryPlanDate";
            this.lblInventoryPlanDate.Size = new System.Drawing.Size(36, 13);
            this.lblInventoryPlanDate.TabIndex = 2;
            this.lblInventoryPlanDate.Text = "Дата:";
            // 
            // dtpInventoryPlanDate
            // 
            this.dtpInventoryPlanDate.CustomFormat = "dd.MM.yyyy";
            this.dtpInventoryPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInventoryPlanDate.Location = new System.Drawing.Point(47, 35);
            this.dtpInventoryPlanDate.Name = "dtpInventoryPlanDate";
            this.dtpInventoryPlanDate.Size = new System.Drawing.Size(100, 20);
            this.dtpInventoryPlanDate.TabIndex = 3;
            // 
            // nudOutMove
            // 
            this.nudOutMove.Enabled = false;
            this.nudOutMove.Location = new System.Drawing.Point(227, 110);
            this.nudOutMove.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudOutMove.Name = "nudOutMove";
            this.nudOutMove.Size = new System.Drawing.Size(120, 20);
            this.nudOutMove.TabIndex = 10;
            // 
            // pnlParameters
            // 
            this.pnlParameters.Controls.Add(this.pnlParametersContent);
            this.pnlParameters.Controls.Add(this.lblParameters);
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameters.Location = new System.Drawing.Point(0, 0);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(644, 206);
            this.pnlParameters.TabIndex = 0;
            // 
            // pnlParametersContent
            // 
            this.pnlParametersContent.Controls.Add(this.cmbCategory);
            this.pnlParametersContent.Controls.Add(this.lblPriceTo);
            this.pnlParametersContent.Controls.Add(this.lblPriceFrom);
            this.pnlParametersContent.Controls.Add(this.cbOutInv);
            this.pnlParametersContent.Controls.Add(this.cbOutMove);
            this.pnlParametersContent.Controls.Add(this.cbCategory);
            this.pnlParametersContent.Controls.Add(this.cbPricesRange);
            this.pnlParametersContent.Controls.Add(this.cbQtyItems);
            this.pnlParametersContent.Controls.Add(this.nudOutInv);
            this.pnlParametersContent.Controls.Add(this.nudQtyItems);
            this.pnlParametersContent.Controls.Add(this.nudPriceTo);
            this.pnlParametersContent.Controls.Add(this.nudPriceFrom);
            this.pnlParametersContent.Controls.Add(this.nudOutMove);
            this.pnlParametersContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParametersContent.Location = new System.Drawing.Point(0, 20);
            this.pnlParametersContent.Name = "pnlParametersContent";
            this.pnlParametersContent.Size = new System.Drawing.Size(644, 186);
            this.pnlParametersContent.TabIndex = 1;
            // 
            // lblPriceTo
            // 
            this.lblPriceTo.AutoSize = true;
            this.lblPriceTo.Location = new System.Drawing.Point(372, 48);
            this.lblPriceTo.Name = "lblPriceTo";
            this.lblPriceTo.Size = new System.Drawing.Size(19, 13);
            this.lblPriceTo.TabIndex = 5;
            this.lblPriceTo.Text = "до";
            // 
            // lblPriceFrom
            // 
            this.lblPriceFrom.AutoSize = true;
            this.lblPriceFrom.Location = new System.Drawing.Point(200, 48);
            this.lblPriceFrom.Name = "lblPriceFrom";
            this.lblPriceFrom.Size = new System.Drawing.Size(21, 13);
            this.lblPriceFrom.TabIndex = 3;
            this.lblPriceFrom.Text = "від";
            // 
            // cbOutInv
            // 
            this.cbOutInv.AutoSize = true;
            this.cbOutInv.Location = new System.Drawing.Point(13, 145);
            this.cbOutInv.Name = "cbOutInv";
            this.cbOutInv.Size = new System.Drawing.Size(141, 30);
            this.cbOutInv.TabIndex = 11;
            this.cbOutInv.Text = "Відсутній в попередніх \r\nінвентаризаціях, міс.:";
            this.cbOutInv.UseVisualStyleBackColor = true;
            this.cbOutInv.CheckedChanged += new System.EventHandler(this.cbOutInv_CheckedChanged);
            // 
            // cbOutMove
            // 
            this.cbOutMove.AutoSize = true;
            this.cbOutMove.Location = new System.Drawing.Point(13, 112);
            this.cbOutMove.Name = "cbOutMove";
            this.cbOutMove.Size = new System.Drawing.Size(119, 17);
            this.cbOutMove.TabIndex = 9;
            this.cbOutMove.Text = "Відсутній рух, днів:";
            this.cbOutMove.UseVisualStyleBackColor = true;
            this.cbOutMove.CheckedChanged += new System.EventHandler(this.cbOutMove_CheckedChanged);
            // 
            // cbCategory
            // 
            this.cbCategory.AutoSize = true;
            this.cbCategory.Checked = true;
            this.cbCategory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCategory.Location = new System.Drawing.Point(13, 79);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(78, 17);
            this.cbCategory.TabIndex = 7;
            this.cbCategory.Text = "Категорія:";
            this.cbCategory.UseVisualStyleBackColor = true;
            this.cbCategory.CheckedChanged += new System.EventHandler(this.cbCategory_CheckedChanged);
            // 
            // cbPricesRange
            // 
            this.cbPricesRange.AutoSize = true;
            this.cbPricesRange.Checked = true;
            this.cbPricesRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPricesRange.Location = new System.Drawing.Point(13, 46);
            this.cbPricesRange.Name = "cbPricesRange";
            this.cbPricesRange.Size = new System.Drawing.Size(119, 17);
            this.cbPricesRange.TabIndex = 2;
            this.cbPricesRange.Text = "Діапазон цін, грн.:";
            this.cbPricesRange.UseVisualStyleBackColor = true;
            this.cbPricesRange.CheckedChanged += new System.EventHandler(this.cbPricesRange_CheckedChanged);
            // 
            // cbQtyItems
            // 
            this.cbQtyItems.AutoSize = true;
            this.cbQtyItems.Checked = true;
            this.cbQtyItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbQtyItems.Location = new System.Drawing.Point(13, 13);
            this.cbQtyItems.Name = "cbQtyItems";
            this.cbQtyItems.Size = new System.Drawing.Size(138, 17);
            this.cbQtyItems.TabIndex = 0;
            this.cbQtyItems.Text = "Кількість позицій, шт.:";
            this.cbQtyItems.UseVisualStyleBackColor = true;
            this.cbQtyItems.CheckedChanged += new System.EventHandler(this.cbQtyItems_CheckedChanged);
            // 
            // nudOutInv
            // 
            this.nudOutInv.Enabled = false;
            this.nudOutInv.Location = new System.Drawing.Point(227, 145);
            this.nudOutInv.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudOutInv.Name = "nudOutInv";
            this.nudOutInv.Size = new System.Drawing.Size(120, 20);
            this.nudOutInv.TabIndex = 12;
            // 
            // nudQtyItems
            // 
            this.nudQtyItems.Location = new System.Drawing.Point(227, 11);
            this.nudQtyItems.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudQtyItems.Name = "nudQtyItems";
            this.nudQtyItems.Size = new System.Drawing.Size(120, 20);
            this.nudQtyItems.TabIndex = 1;
            // 
            // nudPriceTo
            // 
            this.nudPriceTo.DecimalPlaces = 2;
            this.nudPriceTo.Location = new System.Drawing.Point(397, 44);
            this.nudPriceTo.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPriceTo.Name = "nudPriceTo";
            this.nudPriceTo.Size = new System.Drawing.Size(120, 20);
            this.nudPriceTo.TabIndex = 6;
            this.nudPriceTo.ThousandsSeparator = true;
            // 
            // nudPriceFrom
            // 
            this.nudPriceFrom.DecimalPlaces = 2;
            this.nudPriceFrom.Location = new System.Drawing.Point(227, 44);
            this.nudPriceFrom.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPriceFrom.Name = "nudPriceFrom";
            this.nudPriceFrom.Size = new System.Drawing.Size(120, 20);
            this.nudPriceFrom.TabIndex = 4;
            this.nudPriceFrom.ThousandsSeparator = true;
            // 
            // lblParameters
            // 
            this.lblParameters.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblParameters.Location = new System.Drawing.Point(0, 0);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblParameters.Size = new System.Drawing.Size(644, 20);
            this.lblParameters.TabIndex = 0;
            this.lblParameters.Text = "Параметри";
            // 
            // inventoriesVirtualScheduleCategoriesBindingSource
            // 
            this.inventoriesVirtualScheduleCategoriesBindingSource.DataMember = "InventoriesVirtualScheduleCategories";
            this.inventoriesVirtualScheduleCategoriesBindingSource.DataSource = this.inventory;
            // 
            // scContent
            // 
            this.scContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scContent.IsSplitterFixed = true;
            this.scContent.Location = new System.Drawing.Point(0, 70);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.pnlParameters);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.pnlWarehouses);
            this.scContent.Size = new System.Drawing.Size(644, 456);
            this.scContent.SplitterDistance = 206;
            this.scContent.TabIndex = 8;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(397, 7);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(235, 48);
            this.tbDescription.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(355, 7);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(36, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Опис:";
            // 
            // inventoriesVirtualScheduleCategoriesTableAdapter
            // 
            this.inventoriesVirtualScheduleCategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DataSource = this.inventoriesVirtualScheduleCategoriesBindingSource;
            this.cmbCategory.DisplayMember = "CatName";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(227, 77);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(290, 21);
            this.cmbCategory.TabIndex = 8;
            this.cmbCategory.ValueMember = "CatCode";
            // 
            // InventoryVirtualScheduleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 575);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.scContent);
            this.Controls.Add(this.dtpInventoryPlanTime);
            this.Controls.Add(this.lblInventoryPlanTime);
            this.Controls.Add(this.lblInventoryPlanDate);
            this.Controls.Add(this.dtpInventoryPlanDate);
            this.Controls.Add(this.cmbInventoryType);
            this.Controls.Add(this.lblInventoryType);
            this.Name = "InventoryVirtualScheduleEditForm";
            this.Text = "Модуль I";
            this.Load += new System.EventHandler(this.InventoryVirtualScheduleEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryVirtualScheduleEditForm_FormClosing);
            this.Controls.SetChildIndex(this.lblInventoryType, 0);
            this.Controls.SetChildIndex(this.cmbInventoryType, 0);
            this.Controls.SetChildIndex(this.dtpInventoryPlanDate, 0);
            this.Controls.SetChildIndex(this.lblInventoryPlanDate, 0);
            this.Controls.SetChildIndex(this.lblInventoryPlanTime, 0);
            this.Controls.SetChildIndex(this.dtpInventoryPlanTime, 0);
            this.Controls.SetChildIndex(this.scContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesVirtualScheduleTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesVirtualScheduleWarehousesElementsBindingSource)).EndInit();
            this.pnlWarehouses.ResumeLayout(false);
            this.pnlWarehousesContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudOutMove)).EndInit();
            this.pnlParameters.ResumeLayout(false);
            this.pnlParametersContent.ResumeLayout(false);
            this.pnlParametersContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtyItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoriesVirtualScheduleCategoriesBindingSource)).EndInit();
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInventoryType;
        private System.Windows.Forms.BindingSource inventoriesVirtualScheduleTypesBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.InventoriesVirtualScheduleTypesTableAdapter inventoriesVirtualScheduleTypesTableAdapter;
        private System.Windows.Forms.DataGridView dgvWarehouses;
        private System.Windows.Forms.BindingSource inventoriesVirtualScheduleWarehousesElementsBindingSource;
        private WMSOffice.Data.InventoryTableAdapters.InventoriesVirtualScheduleWarehousesElementsTableAdapter inventoriesVirtualScheduleWarehousesElementsTableAdapter;
        private System.Windows.Forms.Panel pnlWarehouses;
        private System.Windows.Forms.Label lblWarehouses;
        private System.Windows.Forms.Label lblInventoryType;
        private System.Windows.Forms.DateTimePicker dtpInventoryPlanTime;
        private System.Windows.Forms.Label lblInventoryPlanTime;
        private System.Windows.Forms.Label lblInventoryPlanDate;
        private System.Windows.Forms.DateTimePicker dtpInventoryPlanDate;
        private System.Windows.Forms.NumericUpDown nudOutMove;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.Panel pnlParametersContent;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.Panel pnlWarehousesContent;
        private System.Windows.Forms.NumericUpDown nudOutInv;
        private System.Windows.Forms.NumericUpDown nudQtyItems;
        private System.Windows.Forms.NumericUpDown nudPriceTo;
        private System.Windows.Forms.NumericUpDown nudPriceFrom;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.CheckBox cbOutInv;
        private System.Windows.Forms.CheckBox cbOutMove;
        private System.Windows.Forms.CheckBox cbCategory;
        private System.Windows.Forms.CheckBox cbPricesRange;
        private System.Windows.Forms.CheckBox cbQtyItems;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPriceTo;
        private System.Windows.Forms.Label lblPriceFrom;
        private System.Windows.Forms.BindingSource inventoriesVirtualScheduleCategoriesBindingSource;
        private WMSOffice.Data.InventoryTableAdapters.InventoriesVirtualScheduleCategoriesTableAdapter inventoriesVirtualScheduleCategoriesTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedflagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehousenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbCategory;
    }
}