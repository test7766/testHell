namespace WMSOffice.Window
{
    partial class ComplaintsIlliquidCommodityPlacementWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlGeneralLayout = new System.Windows.Forms.Panel();
            this.pnlClientLayout = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.dgvcIsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.discountTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaintsExt = new WMSOffice.Data.ComplaintsExt();
            this.DiscountAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iommejDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaultEmployees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remainsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvFooter = new System.Windows.Forms.DataGridView();
            this.gbFilterSettings = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stbLocation = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.tsOptions = new System.Windows.Forms.ToolStrip();
            this.sbLoadRemains = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintPlacementTasks = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sbMoveRemains = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbChangeFaultEmployee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sbCreateBranchMovementOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.sbSplit = new System.Windows.Forms.ToolStripButton();
            this.remainsTableAdapter = new WMSOffice.Data.ComplaintsExtTableAdapters.RemainsTableAdapter();
            this.discountTypesTableAdapter = new WMSOffice.Data.ComplaintsExtTableAdapters.DiscountTypesTableAdapter();
            this.pnlGeneralLayout.SuspendLayout();
            this.pnlClientLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintsExt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remainsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFooter)).BeginInit();
            this.gbFilterSettings.SuspendLayout();
            this.tsOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGeneralLayout
            // 
            this.pnlGeneralLayout.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGeneralLayout.Controls.Add(this.pnlClientLayout);
            this.pnlGeneralLayout.Controls.Add(this.tsOptions);
            this.pnlGeneralLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneralLayout.Location = new System.Drawing.Point(0, 40);
            this.pnlGeneralLayout.Name = "pnlGeneralLayout";
            this.pnlGeneralLayout.Size = new System.Drawing.Size(1305, 453);
            this.pnlGeneralLayout.TabIndex = 1;
            // 
            // pnlClientLayout
            // 
            this.pnlClientLayout.Controls.Add(this.panel1);
            this.pnlClientLayout.Controls.Add(this.gbFilterSettings);
            this.pnlClientLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClientLayout.Location = new System.Drawing.Point(0, 55);
            this.pnlClientLayout.Name = "pnlClientLayout";
            this.pnlClientLayout.Size = new System.Drawing.Size(1305, 398);
            this.pnlClientLayout.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetails);
            this.panel1.Controls.Add(this.dgvFooter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1305, 323);
            this.panel1.TabIndex = 1;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcIsChecked,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.docIDDataGridViewTextBoxColumn,
            this.doc_type,
            this.priceDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.DiscountID,
            this.DiscountAmount,
            this.iommejDataGridViewTextBoxColumn,
            this.FaultEmployees});
            this.dgvDetails.DataSource = this.remainsBindingSource;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1305, 298);
            this.dgvDetails.TabIndex = 1;
            this.dgvDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellValueChanged);
            this.dgvDetails.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvDetails_Scroll);
            this.dgvDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetails_CellFormatting);
            this.dgvDetails.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetails_CellMouseDoubleClick);
            this.dgvDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetails_EditingControlShowing);
            this.dgvDetails.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetails_CurrentCellDirtyStateChanged);
            this.dgvDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetails_DataError);
            this.dgvDetails.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDetails_ColumnWidthChanged);
            // 
            // dgvcIsChecked
            // 
            this.dgvcIsChecked.DataPropertyName = "IsChecked";
            this.dgvcIsChecked.HeaderText = "Отм.";
            this.dgvcIsChecked.Name = "dgvcIsChecked";
            this.dgvcIsChecked.Width = 37;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            dataGridViewCellStyle1.NullValue = null;
            this.itemIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "КНН";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 150;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 60;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            dataGridViewCellStyle3.NullValue = null;
            this.docIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.docIDDataGridViewTextBoxColumn.HeaderText = "№ претензии";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // doc_type
            // 
            this.doc_type.DataPropertyName = "doc_type";
            this.doc_type.HeaderText = "Тип";
            this.doc_type.Name = "doc_type";
            this.doc_type.ReadOnly = true;
            this.doc_type.ToolTipText = "Тип претензии";
            this.doc_type.Visible = false;
            this.doc_type.Width = 35;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена база";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 80;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сумма база";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 80;
            // 
            // DiscountID
            // 
            this.DiscountID.DataPropertyName = "DiscountID";
            this.DiscountID.DataSource = this.discountTypesBindingSource;
            this.DiscountID.DisplayMember = "DiscDesc";
            this.DiscountID.DisplayStyleForCurrentCellOnly = true;
            this.DiscountID.HeaderText = "Скидка";
            this.DiscountID.Name = "DiscountID";
            this.DiscountID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DiscountID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DiscountID.ValueMember = "DRKY";
            this.DiscountID.Width = 250;
            // 
            // discountTypesBindingSource
            // 
            this.discountTypesBindingSource.DataMember = "DiscountTypes";
            this.discountTypesBindingSource.DataSource = this.complaintsExt;
            // 
            // complaintsExt
            // 
            this.complaintsExt.DataSetName = "ComplaintsExt";
            this.complaintsExt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DiscountAmount
            // 
            this.DiscountAmount.DataPropertyName = "DiscountAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.DiscountAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.DiscountAmount.HeaderText = "Сумма со скидкой";
            this.DiscountAmount.Name = "DiscountAmount";
            this.DiscountAmount.ReadOnly = true;
            this.DiscountAmount.Width = 80;
            // 
            // iommejDataGridViewTextBoxColumn
            // 
            this.iommejDataGridViewTextBoxColumn.DataPropertyName = "iommej";
            this.iommejDataGridViewTextBoxColumn.HeaderText = "Срок";
            this.iommejDataGridViewTextBoxColumn.Name = "iommejDataGridViewTextBoxColumn";
            this.iommejDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FaultEmployees
            // 
            this.FaultEmployees.DataPropertyName = "FaultEmployees";
            this.FaultEmployees.HeaderText = "Виновные сотрудники";
            this.FaultEmployees.Name = "FaultEmployees";
            this.FaultEmployees.ReadOnly = true;
            this.FaultEmployees.Width = 250;
            // 
            // remainsBindingSource
            // 
            this.remainsBindingSource.DataMember = "Remains";
            this.remainsBindingSource.DataSource = this.complaintsExt;
            // 
            // dgvFooter
            // 
            this.dgvFooter.AllowUserToAddRows = false;
            this.dgvFooter.AllowUserToDeleteRows = false;
            this.dgvFooter.AllowUserToResizeColumns = false;
            this.dgvFooter.AllowUserToResizeRows = false;
            this.dgvFooter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFooter.ColumnHeadersVisible = false;
            this.dgvFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvFooter.Location = new System.Drawing.Point(0, 298);
            this.dgvFooter.MultiSelect = false;
            this.dgvFooter.Name = "dgvFooter";
            this.dgvFooter.ReadOnly = true;
            this.dgvFooter.RowHeadersVisible = false;
            this.dgvFooter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvFooter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFooter.Size = new System.Drawing.Size(1305, 25);
            this.dgvFooter.TabIndex = 0;
            this.dgvFooter.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvFooter_Scroll);
            // 
            // gbFilterSettings
            // 
            this.gbFilterSettings.Controls.Add(this.lblLocation);
            this.gbFilterSettings.Controls.Add(this.label2);
            this.gbFilterSettings.Controls.Add(this.stbLocation);
            this.gbFilterSettings.Controls.Add(this.lblWarehouse);
            this.gbFilterSettings.Controls.Add(this.label3);
            this.gbFilterSettings.Controls.Add(this.stbWarehouse);
            this.gbFilterSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFilterSettings.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbFilterSettings.Location = new System.Drawing.Point(0, 0);
            this.gbFilterSettings.Name = "gbFilterSettings";
            this.gbFilterSettings.Size = new System.Drawing.Size(1305, 75);
            this.gbFilterSettings.TabIndex = 0;
            this.gbFilterSettings.TabStop = false;
            this.gbFilterSettings.Text = "Критерии поиска:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation.Location = new System.Drawing.Point(347, 53);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 13);
            this.lblLocation.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(300, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Место:";
            // 
            // stbLocation
            // 
            this.stbLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbLocation.Location = new System.Drawing.Point(347, 27);
            this.stbLocation.Name = "stbLocation";
            this.stbLocation.ReadOnly = false;
            this.stbLocation.Size = new System.Drawing.Size(100, 23);
            this.stbLocation.TabIndex = 17;
            this.stbLocation.UserID = ((long)(0));
            this.stbLocation.Value = null;
            this.stbLocation.ValueReferenceQuery = null;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouse.Location = new System.Drawing.Point(67, 53);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouse.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(20, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Склад:";
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbWarehouse.Location = new System.Drawing.Point(67, 27);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(100, 23);
            this.stbWarehouse.TabIndex = 14;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // tsOptions
            // 
            this.tsOptions.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLoadRemains,
            this.toolStripSeparator1,
            this.sbPrintPlacementTasks,
            this.cmbPrinters,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripSeparator5,
            this.sbMoveRemains,
            this.toolStripSeparator3,
            this.sbChangeFaultEmployee,
            this.toolStripSeparator4,
            this.sbCreateBranchMovementOrder,
            this.toolStripSeparator6,
            this.sbSplit});
            this.tsOptions.Location = new System.Drawing.Point(0, 0);
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(1305, 55);
            this.tsOptions.TabIndex = 0;
            this.tsOptions.Text = "toolStrip1";
            // 
            // sbLoadRemains
            // 
            this.sbLoadRemains.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbLoadRemains.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbLoadRemains.Name = "sbLoadRemains";
            this.sbLoadRemains.Size = new System.Drawing.Size(113, 52);
            this.sbLoadRemains.Text = "Загрузить\nостаток";
            this.sbLoadRemains.Click += new System.EventHandler(this.sbLoadRemains_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintPlacementTasks
            // 
            this.sbPrintPlacementTasks.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintPlacementTasks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintPlacementTasks.Name = "sbPrintPlacementTasks";
            this.sbPrintPlacementTasks.Size = new System.Drawing.Size(145, 52);
            this.sbPrintPlacementTasks.Text = "Печать заданий\nна размещение";
            this.sbPrintPlacementTasks.Click += new System.EventHandler(this.sbPrintPlacementTasks_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 52);
            this.toolStripLabel1.Text = "Принтер:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // sbMoveRemains
            // 
            this.sbMoveRemains.Image = global::WMSOffice.Properties.Resources.cold_next;
            this.sbMoveRemains.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbMoveRemains.Name = "sbMoveRemains";
            this.sbMoveRemains.Size = new System.Drawing.Size(131, 52);
            this.sbMoveRemains.Text = "Переместить\nна полку";
            this.sbMoveRemains.Click += new System.EventHandler(this.sbMoveRemains_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbChangeFaultEmployee
            // 
            this.sbChangeFaultEmployee.Image = global::WMSOffice.Properties.Resources.config_users;
            this.sbChangeFaultEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbChangeFaultEmployee.Name = "sbChangeFaultEmployee";
            this.sbChangeFaultEmployee.Size = new System.Drawing.Size(169, 52);
            this.sbChangeFaultEmployee.Text = "Сменить виновного\nсотрудника";
            this.sbChangeFaultEmployee.Click += new System.EventHandler(this.sbChangeFaultEmployee_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator4.Visible = false;
            // 
            // sbCreateBranchMovementOrder
            // 
            this.sbCreateBranchMovementOrder.Image = global::WMSOffice.Properties.Resources.assign;
            this.sbCreateBranchMovementOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCreateBranchMovementOrder.Name = "sbCreateBranchMovementOrder";
            this.sbCreateBranchMovementOrder.Size = new System.Drawing.Size(176, 52);
            this.sbCreateBranchMovementOrder.Text = "Сформировать\nотложенное задание\nна м/с перемещение";
            this.sbCreateBranchMovementOrder.Visible = false;
            this.sbCreateBranchMovementOrder.Click += new System.EventHandler(this.sbCreateBranchMovementOrder_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // sbSplit
            // 
            this.sbSplit.Image = global::WMSOffice.Properties.Resources.split;
            this.sbSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbSplit.Name = "sbSplit";
            this.sbSplit.Size = new System.Drawing.Size(122, 52);
            this.sbSplit.Text = "Сплитовка\nколичества";
            this.sbSplit.Click += new System.EventHandler(this.sbSplit_Click);
            // 
            // remainsTableAdapter
            // 
            this.remainsTableAdapter.ClearBeforeFill = true;
            // 
            // discountTypesTableAdapter
            // 
            this.discountTypesTableAdapter.ClearBeforeFill = true;
            // 
            // ComplaintsIlliquidCommodityPlacementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 493);
            this.Controls.Add(this.pnlGeneralLayout);
            this.Name = "ComplaintsIlliquidCommodityPlacementWindow";
            this.Text = "IlliquidCommodityPlacementWindow";
            this.Load += new System.EventHandler(this.ComplaintsIlliquidCommodityPlacementWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintsIlliquidCommodityPlacementWindow_FormClosing);
            this.Controls.SetChildIndex(this.pnlGeneralLayout, 0);
            this.pnlGeneralLayout.ResumeLayout(false);
            this.pnlGeneralLayout.PerformLayout();
            this.pnlClientLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintsExt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remainsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFooter)).EndInit();
            this.gbFilterSettings.ResumeLayout(false);
            this.gbFilterSettings.PerformLayout();
            this.tsOptions.ResumeLayout(false);
            this.tsOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGeneralLayout;
        private System.Windows.Forms.ToolStrip tsOptions;
        private System.Windows.Forms.ToolStripButton sbLoadRemains;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbPrintPlacementTasks;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel pnlClientLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbFilterSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label2;
        private WMSOffice.Controls.SearchTextBox stbLocation;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label label3;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridView dgvFooter;
        private System.Windows.Forms.BindingSource remainsBindingSource;
        private WMSOffice.Data.ComplaintsExt complaintsExt;
        private WMSOffice.Data.ComplaintsExtTableAdapters.RemainsTableAdapter remainsTableAdapter;
        private System.Windows.Forms.BindingSource discountTypesBindingSource;
        private WMSOffice.Data.ComplaintsExtTableAdapters.DiscountTypesTableAdapter discountTypesTableAdapter;
        private System.Windows.Forms.ToolStripButton sbMoveRemains;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton sbChangeFaultEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton sbCreateBranchMovementOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton sbSplit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcIsChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DiscountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn iommejDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaultEmployees;

    }
}