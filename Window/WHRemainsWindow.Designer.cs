namespace WMSOffice.Window
{
    partial class WHRemainsWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintSSCCBarCode = new System.Windows.Forms.ToolStripButton();
            this.pnlSearchCriteria = new System.Windows.Forms.Panel();
            this.gbSearchCriteria = new System.Windows.Forms.GroupBox();
            this.cbWithSSCCRemains = new System.Windows.Forms.CheckBox();
            this.tbLots = new System.Windows.Forms.TextBox();
            this.lblLots = new System.Windows.Forms.Label();
            this.cbHideZeroQuantity = new System.Windows.Forms.CheckBox();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.tbLotNumber = new System.Windows.Forms.TextBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblCell = new System.Windows.Forms.Label();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.lblLot = new System.Windows.Forms.Label();
            this.tbSSCC = new System.Windows.Forms.TextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.lblSSCC = new System.Windows.Forms.Label();
            this.dgvResponse = new System.Windows.Forms.DataGridView();
            this.sSCCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itInBXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotsNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyOnHandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyAvailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyCommitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPrintSSCC = new System.Windows.Forms.ToolStripMenuItem();
            this.wHRemainsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.pL_RemainsTableAdapter = new WMSOffice.Data.WHTableAdapters.PL_RemainsTableAdapter();
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
            this.tsMainMenu.SuspendLayout();
            this.pnlSearchCriteria.SuspendLayout();
            this.gbSearchCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponse)).BeginInit();
            this.cmOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wHRemainsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.toolStripSeparator1,
            this.sbPrintSSCCBarCode});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1125, 55);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(113, 52);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintSSCCBarCode
            // 
            this.sbPrintSSCCBarCode.Image = global::WMSOffice.Properties.Resources.barcode;
            this.sbPrintSSCCBarCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintSSCCBarCode.Name = "sbPrintSSCCBarCode";
            this.sbPrintSSCCBarCode.Size = new System.Drawing.Size(133, 52);
            this.sbPrintSSCCBarCode.Text = "Создать SSCC";
            this.sbPrintSSCCBarCode.Click += new System.EventHandler(this.sbPrintSSCCBarCode_Click);
            // 
            // pnlSearchCriteria
            // 
            this.pnlSearchCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearchCriteria.Controls.Add(this.gbSearchCriteria);
            this.pnlSearchCriteria.Location = new System.Drawing.Point(0, 98);
            this.pnlSearchCriteria.Name = "pnlSearchCriteria";
            this.pnlSearchCriteria.Size = new System.Drawing.Size(1125, 89);
            this.pnlSearchCriteria.TabIndex = 2;
            // 
            // gbSearchCriteria
            // 
            this.gbSearchCriteria.Controls.Add(this.cbWithSSCCRemains);
            this.gbSearchCriteria.Controls.Add(this.tbLots);
            this.gbSearchCriteria.Controls.Add(this.lblLots);
            this.gbSearchCriteria.Controls.Add(this.cbHideZeroQuantity);
            this.gbSearchCriteria.Controls.Add(this.tbWarehouse);
            this.gbSearchCriteria.Controls.Add(this.tbLocation);
            this.gbSearchCriteria.Controls.Add(this.tbItemID);
            this.gbSearchCriteria.Controls.Add(this.lblWarehouse);
            this.gbSearchCriteria.Controls.Add(this.tbLotNumber);
            this.gbSearchCriteria.Controls.Add(this.lblItemID);
            this.gbSearchCriteria.Controls.Add(this.lblCell);
            this.gbSearchCriteria.Controls.Add(this.tbVendorLot);
            this.gbSearchCriteria.Controls.Add(this.lblLot);
            this.gbSearchCriteria.Controls.Add(this.tbSSCC);
            this.gbSearchCriteria.Controls.Add(this.lblVendorLot);
            this.gbSearchCriteria.Controls.Add(this.lblSSCC);
            this.gbSearchCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSearchCriteria.Location = new System.Drawing.Point(0, 0);
            this.gbSearchCriteria.Name = "gbSearchCriteria";
            this.gbSearchCriteria.Size = new System.Drawing.Size(1125, 89);
            this.gbSearchCriteria.TabIndex = 11;
            this.gbSearchCriteria.TabStop = false;
            this.gbSearchCriteria.Text = "Фильтр поиска:";
            // 
            // cbWithSSCCRemains
            // 
            this.cbWithSSCCRemains.AutoSize = true;
            this.cbWithSSCCRemains.Location = new System.Drawing.Point(868, 50);
            this.cbWithSSCCRemains.Name = "cbWithSSCCRemains";
            this.cbWithSSCCRemains.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbWithSSCCRemains.Size = new System.Drawing.Size(114, 17);
            this.cbWithSSCCRemains.TabIndex = 16;
            this.cbWithSSCCRemains.Text = "Остаток по SSCC";
            this.cbWithSSCCRemains.UseVisualStyleBackColor = true;
            // 
            // tbLots
            // 
            this.tbLots.Location = new System.Drawing.Point(756, 19);
            this.tbLots.MaxLength = 1;
            this.tbLots.Name = "tbLots";
            this.tbLots.Size = new System.Drawing.Size(20, 20);
            this.tbLots.TabIndex = 15;
            // 
            // lblLots
            // 
            this.lblLots.AutoSize = true;
            this.lblLots.Location = new System.Drawing.Point(658, 22);
            this.lblLots.Name = "lblLots";
            this.lblLots.Size = new System.Drawing.Size(92, 13);
            this.lblLots.TabIndex = 14;
            this.lblLots.Text = "Код блокировки:";
            // 
            // cbHideZeroQuantity
            // 
            this.cbHideZeroQuantity.AutoSize = true;
            this.cbHideZeroQuantity.Checked = true;
            this.cbHideZeroQuantity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideZeroQuantity.Location = new System.Drawing.Point(661, 50);
            this.cbHideZeroQuantity.Name = "cbHideZeroQuantity";
            this.cbHideZeroQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbHideZeroQuantity.Size = new System.Drawing.Size(183, 17);
            this.cbHideZeroQuantity.TabIndex = 13;
            this.cbHideZeroQuantity.Text = "Скрывать нулевые количества";
            this.cbHideZeroQuantity.UseVisualStyleBackColor = true;
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouse.Location = new System.Drawing.Point(57, 19);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.Size = new System.Drawing.Size(130, 20);
            this.tbWarehouse.TabIndex = 12;
            this.tbWarehouse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbWarehouse_MouseClick);
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(504, 19);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(130, 20);
            this.tbLocation.TabIndex = 8;
            // 
            // tbItemID
            // 
            this.tbItemID.Location = new System.Drawing.Point(291, 19);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.Size = new System.Drawing.Size(130, 20);
            this.tbItemID.TabIndex = 10;
            this.tbItemID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemID_KeyPress);
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(10, 22);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Склад:";
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.Location = new System.Drawing.Point(291, 51);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.Size = new System.Drawing.Size(130, 20);
            this.tbLotNumber.TabIndex = 9;
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(216, 22);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(67, 13);
            this.lblItemID.TabIndex = 1;
            this.lblItemID.Text = "Код товара:";
            // 
            // lblCell
            // 
            this.lblCell.AutoSize = true;
            this.lblCell.Location = new System.Drawing.Point(451, 22);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(47, 13);
            this.lblCell.TabIndex = 2;
            this.lblCell.Text = "Ячейка:";
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.Location = new System.Drawing.Point(57, 51);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.Size = new System.Drawing.Size(130, 20);
            this.tbVendorLot.TabIndex = 7;
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.Location = new System.Drawing.Point(236, 54);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(47, 13);
            this.lblLot.TabIndex = 3;
            this.lblLot.Text = "Партия:";
            // 
            // tbSSCC
            // 
            this.tbSSCC.Location = new System.Drawing.Point(504, 51);
            this.tbSSCC.Name = "tbSSCC";
            this.tbSSCC.Size = new System.Drawing.Size(130, 20);
            this.tbSSCC.TabIndex = 6;
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(10, 54);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLot.TabIndex = 4;
            this.lblVendorLot.Text = "Серия:";
            // 
            // lblSSCC
            // 
            this.lblSSCC.AutoSize = true;
            this.lblSSCC.Location = new System.Drawing.Point(460, 54);
            this.lblSSCC.Name = "lblSSCC";
            this.lblSSCC.Size = new System.Drawing.Size(38, 13);
            this.lblSSCC.TabIndex = 5;
            this.lblSSCC.Text = "SSCC:";
            // 
            // dgvResponse
            // 
            this.dgvResponse.AllowUserToAddRows = false;
            this.dgvResponse.AllowUserToDeleteRows = false;
            this.dgvResponse.AllowUserToResizeColumns = false;
            this.dgvResponse.AllowUserToResizeRows = false;
            this.dgvResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResponse.AutoGenerateColumns = false;
            this.dgvResponse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResponse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResponse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sSCCDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.itInBXDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.expDateDataGridViewTextBoxColumn,
            this.lotsDataGridViewTextBoxColumn,
            this.lotsNameDataGridViewTextBoxColumn,
            this.qtyOnHandDataGridViewTextBoxColumn,
            this.qtyAvailDataGridViewTextBoxColumn,
            this.qtyCommitDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn});
            this.dgvResponse.ContextMenuStrip = this.cmOperations;
            this.dgvResponse.DataSource = this.wHRemainsBindingSource;
            this.dgvResponse.Location = new System.Drawing.Point(0, 193);
            this.dgvResponse.MultiSelect = false;
            this.dgvResponse.Name = "dgvResponse";
            this.dgvResponse.ReadOnly = true;
            this.dgvResponse.RowHeadersVisible = false;
            this.dgvResponse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResponse.Size = new System.Drawing.Size(1125, 309);
            this.dgvResponse.TabIndex = 3;
            this.dgvResponse.SelectionChanged += new System.EventHandler(this.dgvResponse_SelectionChanged);
            // 
            // sSCCDataGridViewTextBoxColumn
            // 
            this.sSCCDataGridViewTextBoxColumn.DataPropertyName = "SSCC";
            this.sSCCDataGridViewTextBoxColumn.HeaderText = "SSCC";
            this.sSCCDataGridViewTextBoxColumn.Name = "sSCCDataGridViewTextBoxColumn";
            this.sSCCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sSCCDataGridViewTextBoxColumn.Width = 64;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 91;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Товар";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 67;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 124;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Ячейка";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationDataGridViewTextBoxColumn.Width = 74;
            // 
            // itInBXDataGridViewTextBoxColumn
            // 
            this.itInBXDataGridViewTextBoxColumn.DataPropertyName = "ItInBX";
            this.itInBXDataGridViewTextBoxColumn.HeaderText = "Штук в ящике";
            this.itInBXDataGridViewTextBoxColumn.Name = "itInBXDataGridViewTextBoxColumn";
            this.itInBXDataGridViewTextBoxColumn.ReadOnly = true;
            this.itInBXDataGridViewTextBoxColumn.Width = 101;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 76;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "VendorLot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 68;
            // 
            // expDateDataGridViewTextBoxColumn
            // 
            this.expDateDataGridViewTextBoxColumn.DataPropertyName = "ExpDate";
            this.expDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            this.expDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expDateDataGridViewTextBoxColumn.Width = 106;
            // 
            // lotsDataGridViewTextBoxColumn
            // 
            this.lotsDataGridViewTextBoxColumn.DataPropertyName = "Lots";
            this.lotsDataGridViewTextBoxColumn.HeaderText = "Код блокировки";
            this.lotsDataGridViewTextBoxColumn.Name = "lotsDataGridViewTextBoxColumn";
            this.lotsDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotsDataGridViewTextBoxColumn.Width = 115;
            // 
            // lotsNameDataGridViewTextBoxColumn
            // 
            this.lotsNameDataGridViewTextBoxColumn.DataPropertyName = "LotsName";
            this.lotsNameDataGridViewTextBoxColumn.HeaderText = "Описание блокировки";
            this.lotsNameDataGridViewTextBoxColumn.Name = "lotsNameDataGridViewTextBoxColumn";
            this.lotsNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotsNameDataGridViewTextBoxColumn.Width = 146;
            // 
            // qtyOnHandDataGridViewTextBoxColumn
            // 
            this.qtyOnHandDataGridViewTextBoxColumn.DataPropertyName = "QtyOnHand";
            this.qtyOnHandDataGridViewTextBoxColumn.HeaderText = "Кол-во на складе";
            this.qtyOnHandDataGridViewTextBoxColumn.Name = "qtyOnHandDataGridViewTextBoxColumn";
            this.qtyOnHandDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyOnHandDataGridViewTextBoxColumn.Width = 121;
            // 
            // qtyAvailDataGridViewTextBoxColumn
            // 
            this.qtyAvailDataGridViewTextBoxColumn.DataPropertyName = "QtyAvail";
            this.qtyAvailDataGridViewTextBoxColumn.HeaderText = "Кол-во доступное";
            this.qtyAvailDataGridViewTextBoxColumn.Name = "qtyAvailDataGridViewTextBoxColumn";
            this.qtyAvailDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyAvailDataGridViewTextBoxColumn.Width = 124;
            // 
            // qtyCommitDataGridViewTextBoxColumn
            // 
            this.qtyCommitDataGridViewTextBoxColumn.DataPropertyName = "QtyCommit";
            this.qtyCommitDataGridViewTextBoxColumn.HeaderText = "Кол-во зарезервированное";
            this.qtyCommitDataGridViewTextBoxColumn.Name = "qtyCommitDataGridViewTextBoxColumn";
            this.qtyCommitDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyCommitDataGridViewTextBoxColumn.Width = 175;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            this.weightDataGridViewTextBoxColumn.HeaderText = "Вес";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 53;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Объем";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 71;
            // 
            // cmOperations
            // 
            this.cmOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPrintSSCC});
            this.cmOperations.Name = "cmOperations";
            this.cmOperations.Size = new System.Drawing.Size(169, 26);
            // 
            // miPrintSSCC
            // 
            this.miPrintSSCC.Name = "miPrintSSCC";
            this.miPrintSSCC.Size = new System.Drawing.Size(168, 22);
            this.miPrintSSCC.Text = "Напечатать SSCC";
            this.miPrintSSCC.Click += new System.EventHandler(this.miPrintSSCC_Click);
            // 
            // wHRemainsBindingSource
            // 
            this.wHRemainsBindingSource.DataMember = "PL_Remains";
            this.wHRemainsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pL_RemainsTableAdapter
            // 
            this.pL_RemainsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SSCC";
            this.dataGridViewTextBoxColumn1.HeaderText = "SSCC";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 64;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Код товара";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 91;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Товар";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 67;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn4.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 124;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ячейка";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 74;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ItInBX";
            this.dataGridViewTextBoxColumn6.HeaderText = "Штук в ящике";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 101;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "LotNumber";
            this.dataGridViewTextBoxColumn7.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 76;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "VendorLot";
            this.dataGridViewTextBoxColumn8.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 68;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ExpDate";
            this.dataGridViewTextBoxColumn9.HeaderText = "Срок годности";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 106;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Lots";
            this.dataGridViewTextBoxColumn10.HeaderText = "Код блокировки";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 115;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "LotsName";
            this.dataGridViewTextBoxColumn11.HeaderText = "Описание блокировки";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 146;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "QtyOnHand";
            this.dataGridViewTextBoxColumn12.HeaderText = "Кол-во на складе";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 121;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "QtyAvail";
            this.dataGridViewTextBoxColumn13.HeaderText = "Кол-во доступное";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 124;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "QtyCommit";
            this.dataGridViewTextBoxColumn14.HeaderText = "Кол-во зарезервированное";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 175;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Weight";
            this.dataGridViewTextBoxColumn15.HeaderText = "Вес";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 53;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Volume";
            this.dataGridViewTextBoxColumn16.HeaderText = "Объем";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 71;
            // 
            // WHRemainsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 504);
            this.Controls.Add(this.dgvResponse);
            this.Controls.Add(this.pnlSearchCriteria);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "WHRemainsWindow";
            this.Text = "WHRemainsWindow";
            this.Load += new System.EventHandler(this.WHRemainsWindow_Load);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.pnlSearchCriteria, 0);
            this.Controls.SetChildIndex(this.dgvResponse, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.pnlSearchCriteria.ResumeLayout(false);
            this.gbSearchCriteria.ResumeLayout(false);
            this.gbSearchCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponse)).EndInit();
            this.cmOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wHRemainsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.Panel pnlSearchCriteria;
        private System.Windows.Forms.DataGridView dgvResponse;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblSSCC;
        private System.Windows.Forms.Label lblVendorLot;
        private System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.Label lblCell;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.TextBox tbSSCC;
        private System.Windows.Forms.TextBox tbVendorLot;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.TextBox tbLotNumber;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.GroupBox gbSearchCriteria;
        private System.Windows.Forms.TextBox tbWarehouse;
        private System.Windows.Forms.BindingSource wHRemainsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.PL_RemainsTableAdapter pL_RemainsTableAdapter;
        private System.Windows.Forms.TextBox tbLots;
        private System.Windows.Forms.Label lblLots;
        private System.Windows.Forms.CheckBox cbHideZeroQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSCCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itInBXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotsNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyOnHandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyAvailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyCommitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbPrintSSCCBarCode;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.ContextMenuStrip cmOperations;
        private System.Windows.Forms.ToolStripMenuItem miPrintSSCC;
        private System.Windows.Forms.CheckBox cbWithSSCCRemains;
    }
}