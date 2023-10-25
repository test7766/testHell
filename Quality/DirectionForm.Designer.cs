namespace WMSOffice.Dialogs.Quality
{
    partial class DirectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectionForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.chbAuthImplement = new System.Windows.Forms.CheckBox();
            this.chbLabAnalysis = new System.Windows.Forms.CheckBox();
            this.lblType = new System.Windows.Forms.Label();
            this.tbxRequestNumber = new System.Windows.Forms.TextBox();
            this.lblRequestNumber = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.chbChangeScan = new System.Windows.Forms.CheckBox();
            this.dtpDateReceipt = new System.Windows.Forms.DateTimePicker();
            this.lblDateReceipt = new System.Windows.Forms.Label();
            this.cmbLocations = new System.Windows.Forms.ComboBox();
            this.bsLocations = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.lblLocations = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblNumber = new System.Windows.Forms.Label();
            this.tbxNumber = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.taLocations = new WMSOffice.Data.QualityTableAdapters.LocationsTableAdapter();
            this.taQkDrDocsScan = new WMSOffice.Data.QualityTableAdapters.QK_DR_Docs_ScanTableAdapter();
            this.spcTwoGrids = new System.Windows.Forms.SplitContainer();
            this.pnlRequest = new System.Windows.Forms.Panel();
            this.chbShowRepeatedLots = new System.Windows.Forms.CheckBox();
            this.lblRequestDetails = new System.Windows.Forms.Label();
            this.dgvRequestDetails = new System.Windows.Forms.DataGridView();
            this.clReIsRepeatedLot = new System.Windows.Forms.DataGridViewImageColumn();
            this.clReLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clReItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clReManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clReMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDocDetailForDirection = new System.Windows.Forms.BindingSource(this.components);
            this.spcInternalGrid = new System.Windows.Forms.SplitContainer();
            this.btnRemoveItems = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.dgvDirectionDetails = new System.Windows.Forms.DataGridView();
            this.clDiLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDirectionDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miSetQuantity = new System.Windows.Forms.ToolStripMenuItem();
            this.bsDrDocRows = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDirection = new System.Windows.Forms.Panel();
            this.lblDirectionDetails = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tmrRequestNumber = new System.Windows.Forms.Timer(this.components);
            this.taDrDocRows = new WMSOffice.Data.QualityTableAdapters.DRDocRowsTableAdapter();
            this.taDrDocs = new WMSOffice.Data.QualityTableAdapters.DRDocsTableAdapter();
            this.taQkDocsDetailForDirection = new WMSOffice.Data.QualityTableAdapters.QK_Docs_Detail_For_DirectionTableAdapter();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.spcTwoGrids.Panel1.SuspendLayout();
            this.spcTwoGrids.Panel2.SuspendLayout();
            this.spcTwoGrids.SuspendLayout();
            this.pnlRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocDetailForDirection)).BeginInit();
            this.spcInternalGrid.Panel1.SuspendLayout();
            this.spcInternalGrid.Panel2.SuspendLayout();
            this.spcInternalGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectionDetails)).BeginInit();
            this.cmsDirectionDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDrDocRows)).BeginInit();
            this.pnlDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.chbAuthImplement);
            this.pnlHeader.Controls.Add(this.chbLabAnalysis);
            this.pnlHeader.Controls.Add(this.lblType);
            this.pnlHeader.Controls.Add(this.tbxRequestNumber);
            this.pnlHeader.Controls.Add(this.lblRequestNumber);
            this.pnlHeader.Controls.Add(this.btnOpenFile);
            this.pnlHeader.Controls.Add(this.tbxFilePath);
            this.pnlHeader.Controls.Add(this.chbChangeScan);
            this.pnlHeader.Controls.Add(this.dtpDateReceipt);
            this.pnlHeader.Controls.Add(this.lblDateReceipt);
            this.pnlHeader.Controls.Add(this.cmbLocations);
            this.pnlHeader.Controls.Add(this.lblLocations);
            this.pnlHeader.Controls.Add(this.lblDateFrom);
            this.pnlHeader.Controls.Add(this.dtpDateFrom);
            this.pnlHeader.Controls.Add(this.lblNumber);
            this.pnlHeader.Controls.Add(this.tbxNumber);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(957, 150);
            this.pnlHeader.TabIndex = 1;
            // 
            // chbAuthImplement
            // 
            this.chbAuthImplement.AutoSize = true;
            this.chbAuthImplement.Location = new System.Drawing.Point(116, 125);
            this.chbAuthImplement.Name = "chbAuthImplement";
            this.chbAuthImplement.Size = new System.Drawing.Size(133, 17);
            this.chbAuthImplement.TabIndex = 113;
            this.chbAuthImplement.Text = "Дозвіл на реалізацію";
            this.chbAuthImplement.UseVisualStyleBackColor = true;
            this.chbAuthImplement.CheckedChanged += new System.EventHandler(this.chbAuthImplement_CheckedChanged);
            // 
            // chbLabAnalysis
            // 
            this.chbLabAnalysis.AutoSize = true;
            this.chbLabAnalysis.Location = new System.Drawing.Point(116, 100);
            this.chbLabAnalysis.Name = "chbLabAnalysis";
            this.chbLabAnalysis.Size = new System.Drawing.Size(134, 17);
            this.chbLabAnalysis.TabIndex = 112;
            this.chbLabAnalysis.Text = "Лабораторний аналіз";
            this.chbLabAnalysis.UseVisualStyleBackColor = true;
            this.chbLabAnalysis.CheckedChanged += new System.EventHandler(this.chbLabAnalysis_CheckedChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 102);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(98, 13);
            this.lblType.TabIndex = 111;
            this.lblType.Text = "Тип направлення:";
            // 
            // tbxRequestNumber
            // 
            this.tbxRequestNumber.Location = new System.Drawing.Point(116, 70);
            this.tbxRequestNumber.Name = "tbxRequestNumber";
            this.tbxRequestNumber.Size = new System.Drawing.Size(93, 20);
            this.tbxRequestNumber.TabIndex = 50;
            this.tbxRequestNumber.TextChanged += new System.EventHandler(this.tbxRequestNumber_TextChanged);
            this.tbxRequestNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxRequestNumber_KeyDown);
            // 
            // lblRequestNumber
            // 
            this.lblRequestNumber.AutoSize = true;
            this.lblRequestNumber.Location = new System.Drawing.Point(12, 73);
            this.lblRequestNumber.Name = "lblRequestNumber";
            this.lblRequestNumber.Size = new System.Drawing.Size(54, 13);
            this.lblRequestNumber.TabIndex = 110;
            this.lblRequestNumber.Text = "№ заяви:";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.Location = new System.Drawing.Point(850, 69);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(92, 23);
            this.btnOpenFile.TabIndex = 90;
            this.btnOpenFile.Text = "Відкрити";
            this.btnOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.Location = new System.Drawing.Point(365, 71);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.ReadOnly = true;
            this.tbxFilePath.Size = new System.Drawing.Size(479, 20);
            this.tbxFilePath.TabIndex = 80;
            // 
            // chbChangeScan
            // 
            this.chbChangeScan.AutoSize = true;
            this.chbChangeScan.Checked = true;
            this.chbChangeScan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbChangeScan.Enabled = false;
            this.chbChangeScan.Location = new System.Drawing.Point(254, 73);
            this.chbChangeScan.Name = "chbChangeScan";
            this.chbChangeScan.Size = new System.Drawing.Size(93, 17);
            this.chbChangeScan.TabIndex = 70;
            this.chbChangeScan.Text = "Додати файл";
            this.chbChangeScan.UseVisualStyleBackColor = true;
            this.chbChangeScan.CheckedChanged += new System.EventHandler(this.chbChangeScan_CheckedChanged);
            // 
            // dtpDateReceipt
            // 
            this.dtpDateReceipt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateReceipt.Location = new System.Drawing.Point(624, 15);
            this.dtpDateReceipt.Name = "dtpDateReceipt";
            this.dtpDateReceipt.Size = new System.Drawing.Size(92, 20);
            this.dtpDateReceipt.TabIndex = 30;
            // 
            // lblDateReceipt
            // 
            this.lblDateReceipt.AutoSize = true;
            this.lblDateReceipt.Location = new System.Drawing.Point(456, 18);
            this.lblDateReceipt.Name = "lblDateReceipt";
            this.lblDateReceipt.Size = new System.Drawing.Size(163, 13);
            this.lblDateReceipt.TabIndex = 107;
            this.lblDateReceipt.Text = "Дата отримання направлення:";
            // 
            // cmbLocations
            // 
            this.cmbLocations.DataSource = this.bsLocations;
            this.cmbLocations.DisplayMember = "Location_Name";
            this.cmbLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocations.FormattingEnabled = true;
            this.cmbLocations.Location = new System.Drawing.Point(116, 40);
            this.cmbLocations.Name = "cmbLocations";
            this.cmbLocations.Size = new System.Drawing.Size(826, 21);
            this.cmbLocations.TabIndex = 40;
            this.cmbLocations.ValueMember = "Location_ID";
            // 
            // bsLocations
            // 
            this.bsLocations.DataMember = "Locations";
            this.bsLocations.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblLocations
            // 
            this.lblLocations.AutoSize = true;
            this.lblLocations.Location = new System.Drawing.Point(12, 43);
            this.lblLocations.Name = "lblLocations";
            this.lblLocations.Size = new System.Drawing.Size(73, 13);
            this.lblLocations.TabIndex = 105;
            this.lblLocations.Text = "Лабораторія:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(251, 15);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(36, 13);
            this.lblDateFrom.TabIndex = 104;
            this.lblDateFrom.Text = "Дата:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(298, 12);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(99, 20);
            this.dtpDateFrom.TabIndex = 20;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(12, 15);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(90, 13);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "№ направлення:";
            // 
            // tbxNumber
            // 
            this.tbxNumber.Location = new System.Drawing.Point(116, 12);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.Size = new System.Drawing.Size(93, 20);
            this.tbxNumber.TabIndex = 10;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Всі файли|*.*";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Відкрити файл";
            // 
            // taLocations
            // 
            this.taLocations.ClearBeforeFill = true;
            // 
            // taQkDrDocsScan
            // 
            this.taQkDrDocsScan.ClearBeforeFill = true;
            // 
            // spcTwoGrids
            // 
            this.spcTwoGrids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcTwoGrids.Location = new System.Drawing.Point(15, 156);
            this.spcTwoGrids.Name = "spcTwoGrids";
            this.spcTwoGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcTwoGrids.Panel1
            // 
            this.spcTwoGrids.Panel1.Controls.Add(this.pnlRequest);
            this.spcTwoGrids.Panel1.Controls.Add(this.dgvRequestDetails);
            // 
            // spcTwoGrids.Panel2
            // 
            this.spcTwoGrids.Panel2.Controls.Add(this.spcInternalGrid);
            this.spcTwoGrids.Size = new System.Drawing.Size(930, 481);
            this.spcTwoGrids.SplitterDistance = 224;
            this.spcTwoGrids.TabIndex = 101;
            // 
            // pnlRequest
            // 
            this.pnlRequest.Controls.Add(this.chbShowRepeatedLots);
            this.pnlRequest.Controls.Add(this.lblRequestDetails);
            this.pnlRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRequest.Location = new System.Drawing.Point(0, 0);
            this.pnlRequest.Name = "pnlRequest";
            this.pnlRequest.Size = new System.Drawing.Size(930, 25);
            this.pnlRequest.TabIndex = 121;
            // 
            // chbShowRepeatedLots
            // 
            this.chbShowRepeatedLots.AutoSize = true;
            this.chbShowRepeatedLots.Location = new System.Drawing.Point(101, 1);
            this.chbShowRepeatedLots.Name = "chbShowRepeatedLots";
            this.chbShowRepeatedLots.Size = new System.Drawing.Size(147, 17);
            this.chbShowRepeatedLots.TabIndex = 110;
            this.chbShowRepeatedLots.Text = "Показати повторні серії";
            this.chbShowRepeatedLots.UseVisualStyleBackColor = true;
            this.chbShowRepeatedLots.CheckedChanged += new System.EventHandler(this.chbShowRepeatedLots_CheckedChanged);
            // 
            // lblRequestDetails
            // 
            this.lblRequestDetails.AutoSize = true;
            this.lblRequestDetails.Location = new System.Drawing.Point(3, 3);
            this.lblRequestDetails.Name = "lblRequestDetails";
            this.lblRequestDetails.Size = new System.Drawing.Size(74, 13);
            this.lblRequestDetails.TabIndex = 0;
            this.lblRequestDetails.Text = "Рядки заяви:";
            // 
            // dgvRequestDetails
            // 
            this.dgvRequestDetails.AllowUserToAddRows = false;
            this.dgvRequestDetails.AllowUserToDeleteRows = false;
            this.dgvRequestDetails.AllowUserToOrderColumns = true;
            this.dgvRequestDetails.AllowUserToResizeRows = false;
            this.dgvRequestDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequestDetails.AutoGenerateColumns = false;
            this.dgvRequestDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequestDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clReIsRepeatedLot,
            this.clReLineID,
            this.clReItemID,
            this.clItemName,
            this.clVendorLot,
            this.clReManufacturer,
            this.clReMode});
            this.dgvRequestDetails.DataSource = this.bsDocDetailForDirection;
            this.dgvRequestDetails.Location = new System.Drawing.Point(3, 24);
            this.dgvRequestDetails.Name = "dgvRequestDetails";
            this.dgvRequestDetails.ReadOnly = true;
            this.dgvRequestDetails.RowHeadersVisible = false;
            this.dgvRequestDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequestDetails.Size = new System.Drawing.Size(924, 219);
            this.dgvRequestDetails.TabIndex = 120;
            this.dgvRequestDetails.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // clReIsRepeatedLot
            // 
            this.clReIsRepeatedLot.HeaderText = "";
            this.clReIsRepeatedLot.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.clReIsRepeatedLot.Name = "clReIsRepeatedLot";
            this.clReIsRepeatedLot.ReadOnly = true;
            this.clReIsRepeatedLot.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clReIsRepeatedLot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clReIsRepeatedLot.Width = 20;
            // 
            // clReLineID
            // 
            this.clReLineID.DataPropertyName = "Line_ID";
            this.clReLineID.HeaderText = "№ рядка";
            this.clReLineID.Name = "clReLineID";
            this.clReLineID.ReadOnly = true;
            this.clReLineID.Width = 70;
            // 
            // clReItemID
            // 
            this.clReItemID.DataPropertyName = "Item_ID";
            this.clReItemID.HeaderText = "Код товару";
            this.clReItemID.Name = "clReItemID";
            this.clReItemID.ReadOnly = true;
            this.clReItemID.Width = 80;
            // 
            // clItemName
            // 
            this.clItemName.DataPropertyName = "Item_Name";
            this.clItemName.HeaderText = "Назва";
            this.clItemName.Name = "clItemName";
            this.clItemName.ReadOnly = true;
            this.clItemName.Width = 250;
            // 
            // clVendorLot
            // 
            this.clVendorLot.DataPropertyName = "Vendor_Lot";
            this.clVendorLot.HeaderText = "Серія";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            // 
            // clReManufacturer
            // 
            this.clReManufacturer.DataPropertyName = "Manufacturer";
            this.clReManufacturer.HeaderText = "Виробник";
            this.clReManufacturer.Name = "clReManufacturer";
            this.clReManufacturer.ReadOnly = true;
            this.clReManufacturer.Width = 200;
            // 
            // clReMode
            // 
            this.clReMode.DataPropertyName = "Mode";
            this.clReMode.HeaderText = "Режим";
            this.clReMode.Name = "clReMode";
            this.clReMode.ReadOnly = true;
            this.clReMode.Width = 80;
            // 
            // bsDocDetailForDirection
            // 
            this.bsDocDetailForDirection.DataMember = "QK_Docs_Detail_For_Direction";
            this.bsDocDetailForDirection.DataSource = this.quality;
            this.bsDocDetailForDirection.Filter = "[Is_Hidden] = False AND [Control_Ready] = False";
            // 
            // spcInternalGrid
            // 
            this.spcInternalGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcInternalGrid.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcInternalGrid.IsSplitterFixed = true;
            this.spcInternalGrid.Location = new System.Drawing.Point(0, 0);
            this.spcInternalGrid.Name = "spcInternalGrid";
            this.spcInternalGrid.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcInternalGrid.Panel1
            // 
            this.spcInternalGrid.Panel1.Controls.Add(this.btnRemoveItems);
            this.spcInternalGrid.Panel1.Controls.Add(this.btnAddItems);
            this.spcInternalGrid.Panel1MinSize = 50;
            // 
            // spcInternalGrid.Panel2
            // 
            this.spcInternalGrid.Panel2.Controls.Add(this.dgvDirectionDetails);
            this.spcInternalGrid.Panel2.Controls.Add(this.pnlDirection);
            this.spcInternalGrid.Size = new System.Drawing.Size(930, 253);
            this.spcInternalGrid.TabIndex = 0;
            // 
            // btnRemoveItems
            // 
            this.btnRemoveItems.Enabled = false;
            this.btnRemoveItems.Image = global::WMSOffice.Properties.Resources.up;
            this.btnRemoveItems.Location = new System.Drawing.Point(64, 3);
            this.btnRemoveItems.Name = "btnRemoveItems";
            this.btnRemoveItems.Size = new System.Drawing.Size(55, 44);
            this.btnRemoveItems.TabIndex = 140;
            this.btnRemoveItems.UseVisualStyleBackColor = true;
            this.btnRemoveItems.Click += new System.EventHandler(this.btnRemoveItems_Click);
            // 
            // btnAddItems
            // 
            this.btnAddItems.Enabled = false;
            this.btnAddItems.Image = global::WMSOffice.Properties.Resources.down;
            this.btnAddItems.Location = new System.Drawing.Point(3, 3);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(55, 44);
            this.btnAddItems.TabIndex = 130;
            this.btnAddItems.UseVisualStyleBackColor = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // dgvDirectionDetails
            // 
            this.dgvDirectionDetails.AllowUserToAddRows = false;
            this.dgvDirectionDetails.AllowUserToDeleteRows = false;
            this.dgvDirectionDetails.AllowUserToOrderColumns = true;
            this.dgvDirectionDetails.AllowUserToResizeRows = false;
            this.dgvDirectionDetails.AutoGenerateColumns = false;
            this.dgvDirectionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirectionDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDiLineId,
            this.clDiItemId,
            this.clDiItemName,
            this.clDiVendorLot,
            this.clDiManufacturer,
            this.clDiMode,
            this.clDiQuantity});
            this.dgvDirectionDetails.ContextMenuStrip = this.cmsDirectionDetails;
            this.dgvDirectionDetails.DataSource = this.bsDrDocRows;
            this.dgvDirectionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDirectionDetails.Location = new System.Drawing.Point(0, 25);
            this.dgvDirectionDetails.Name = "dgvDirectionDetails";
            this.dgvDirectionDetails.ReadOnly = true;
            this.dgvDirectionDetails.RowHeadersVisible = false;
            this.dgvDirectionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirectionDetails.Size = new System.Drawing.Size(930, 174);
            this.dgvDirectionDetails.TabIndex = 150;
            this.dgvDirectionDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDirectionDetails_CellDoubleClick);
            // 
            // clDiLineId
            // 
            this.clDiLineId.DataPropertyName = "Line_ID";
            this.clDiLineId.HeaderText = "№ рядка";
            this.clDiLineId.Name = "clDiLineId";
            this.clDiLineId.ReadOnly = true;
            this.clDiLineId.Width = 80;
            // 
            // clDiItemId
            // 
            this.clDiItemId.DataPropertyName = "Item_ID";
            this.clDiItemId.HeaderText = "Код товару";
            this.clDiItemId.Name = "clDiItemId";
            this.clDiItemId.ReadOnly = true;
            // 
            // clDiItemName
            // 
            this.clDiItemName.DataPropertyName = "ItemName";
            this.clDiItemName.HeaderText = "Назва";
            this.clDiItemName.Name = "clDiItemName";
            this.clDiItemName.ReadOnly = true;
            this.clDiItemName.Width = 250;
            // 
            // clDiVendorLot
            // 
            this.clDiVendorLot.DataPropertyName = "VendorLot";
            this.clDiVendorLot.HeaderText = "Серія";
            this.clDiVendorLot.Name = "clDiVendorLot";
            this.clDiVendorLot.ReadOnly = true;
            // 
            // clDiManufacturer
            // 
            this.clDiManufacturer.DataPropertyName = "Manufacturer";
            this.clDiManufacturer.HeaderText = "Виробник";
            this.clDiManufacturer.Name = "clDiManufacturer";
            this.clDiManufacturer.ReadOnly = true;
            this.clDiManufacturer.Width = 200;
            // 
            // clDiMode
            // 
            this.clDiMode.DataPropertyName = "Mode";
            this.clDiMode.HeaderText = "Режим";
            this.clDiMode.Name = "clDiMode";
            this.clDiMode.ReadOnly = true;
            // 
            // clDiQuantity
            // 
            this.clDiQuantity.DataPropertyName = "Quantity";
            this.clDiQuantity.HeaderText = "Кіл-ть";
            this.clDiQuantity.Name = "clDiQuantity";
            this.clDiQuantity.ReadOnly = true;
            this.clDiQuantity.Width = 80;
            // 
            // cmsDirectionDetails
            // 
            this.cmsDirectionDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSetQuantity});
            this.cmsDirectionDetails.Name = "cmsDirectionDetails";
            this.cmsDirectionDetails.Size = new System.Drawing.Size(161, 26);
            // 
            // miSetQuantity
            // 
            this.miSetQuantity.Image = global::WMSOffice.Properties.Resources.drug_basket;
            this.miSetQuantity.Name = "miSetQuantity";
            this.miSetQuantity.Size = new System.Drawing.Size(160, 22);
            this.miSetQuantity.Text = "Змінити кількість";
            this.miSetQuantity.Click += new System.EventHandler(this.miSetQuantity_Click);
            // 
            // bsDrDocRows
            // 
            this.bsDrDocRows.DataMember = "DRDocRows";
            this.bsDrDocRows.DataSource = this.quality;
            // 
            // pnlDirection
            // 
            this.pnlDirection.Controls.Add(this.lblDirectionDetails);
            this.pnlDirection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDirection.Location = new System.Drawing.Point(0, 0);
            this.pnlDirection.Name = "pnlDirection";
            this.pnlDirection.Size = new System.Drawing.Size(930, 25);
            this.pnlDirection.TabIndex = 151;
            // 
            // lblDirectionDetails
            // 
            this.lblDirectionDetails.AutoSize = true;
            this.lblDirectionDetails.Location = new System.Drawing.Point(3, 3);
            this.lblDirectionDetails.Name = "lblDirectionDetails";
            this.lblDirectionDetails.Size = new System.Drawing.Size(121, 13);
            this.lblDirectionDetails.TabIndex = 3;
            this.lblDirectionDetails.Text = "Зразки в направленні:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(870, 651);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 170;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(789, 651);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 160;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tmrRequestNumber
            // 
            this.tmrRequestNumber.Interval = 800;
            this.tmrRequestNumber.Tick += new System.EventHandler(this.tmrRequestNumber_Tick);
            // 
            // taDrDocRows
            // 
            this.taDrDocRows.ClearBeforeFill = true;
            // 
            // taDrDocs
            // 
            this.taDrDocs.ClearBeforeFill = true;
            // 
            // taQkDocsDetailForDirection
            // 
            this.taQkDocsDetailForDirection.ClearBeforeFill = true;
            // 
            // DirectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(957, 686);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.spcTwoGrids);
            this.Controls.Add(this.pnlHeader);
            this.Name = "DirectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Направлення";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DirectionForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.spcTwoGrids.Panel1.ResumeLayout(false);
            this.spcTwoGrids.Panel2.ResumeLayout(false);
            this.spcTwoGrids.ResumeLayout(false);
            this.pnlRequest.ResumeLayout(false);
            this.pnlRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocDetailForDirection)).EndInit();
            this.spcInternalGrid.Panel1.ResumeLayout(false);
            this.spcInternalGrid.Panel2.ResumeLayout(false);
            this.spcInternalGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectionDetails)).EndInit();
            this.cmsDirectionDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsDrDocRows)).EndInit();
            this.pnlDirection.ResumeLayout(false);
            this.pnlDirection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox tbxNumber;
        private System.Windows.Forms.ComboBox cmbLocations;
        private System.Windows.Forms.Label lblLocations;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource bsLocations;
        private WMSOffice.Data.QualityTableAdapters.LocationsTableAdapter taLocations;
        private System.Windows.Forms.DateTimePicker dtpDateReceipt;
        private System.Windows.Forms.Label lblDateReceipt;
        private System.Windows.Forms.CheckBox chbChangeScan;
        private System.Windows.Forms.TextBox tbxFilePath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private WMSOffice.Data.QualityTableAdapters.QK_DR_Docs_ScanTableAdapter taQkDrDocsScan;
        private System.Windows.Forms.Label lblRequestNumber;
        private System.Windows.Forms.TextBox tbxRequestNumber;
        private System.Windows.Forms.SplitContainer spcTwoGrids;
        private System.Windows.Forms.SplitContainer spcInternalGrid;
        private System.Windows.Forms.Button btnRemoveItems;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView dgvRequestDetails;
        private System.Windows.Forms.CheckBox chbShowRepeatedLots;
        private System.Windows.Forms.Label lblRequestDetails;
        private System.Windows.Forms.DataGridView dgvDirectionDetails;
        private System.Windows.Forms.Label lblDirectionDetails;
        private System.Windows.Forms.BindingSource bsDocDetailForDirection;
        private System.Windows.Forms.Timer tmrRequestNumber;
        private System.Windows.Forms.BindingSource bsDrDocRows;
        private WMSOffice.Data.QualityTableAdapters.DRDocRowsTableAdapter taDrDocRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiQuantity;
        private System.Windows.Forms.ContextMenuStrip cmsDirectionDetails;
        private System.Windows.Forms.ToolStripMenuItem miSetQuantity;
        private WMSOffice.Data.QualityTableAdapters.DRDocsTableAdapter taDrDocs;
        private WMSOffice.Data.QualityTableAdapters.QK_Docs_Detail_For_DirectionTableAdapter taQkDocsDetailForDirection;
        private System.Windows.Forms.DataGridViewImageColumn clReIsRepeatedLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReMode;
        private System.Windows.Forms.Panel pnlRequest;
        private System.Windows.Forms.Panel pnlDirection;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.CheckBox chbAuthImplement;
        private System.Windows.Forms.CheckBox chbLabAnalysis;
    }
}