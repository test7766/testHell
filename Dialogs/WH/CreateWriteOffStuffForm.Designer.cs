namespace WMSOffice.Dialogs.WH
{
    partial class CreateWriteOffStuffForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.spcTwoGrids = new System.Windows.Forms.SplitContainer();
            this.pbWait = new System.Windows.Forms.PictureBox();
            this.dgvRemains = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.spcInternalGrid = new System.Windows.Forms.SplitContainer();
            this.btnExcelImport = new System.Windows.Forms.Button();
            this.btnRemoveFromDoc = new System.Windows.Forms.Button();
            this.btnAddToDoc = new System.Windows.Forms.Button();
            this.dgvDocLines = new System.Windows.Forms.DataGridView();
            this.clLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLocationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAmountUAH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLotStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMoz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsWfGetDocsDetail = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.lblItems = new System.Windows.Forms.Label();
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
            this.lblDocId = new System.Windows.Forms.Label();
            this.tbxID = new System.Windows.Forms.TextBox();
            this.tbxActComment = new System.Windows.Forms.TextBox();
            this.lblActComment = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.taWfGetDocsDetail = new WMSOffice.Data.WHTableAdapters.WF_GetDocs_DetailTableAdapter();
            this.cmbWarehouses = new System.Windows.Forms.ComboBox();
            this.bsWfGetWarehouseList = new System.Windows.Forms.BindingSource(this.components);
            this.taWfGetWarehouseList = new WMSOffice.Data.WHTableAdapters.WF_GetWarehouseListTableAdapter();
            this.lblDocType = new System.Windows.Forms.Label();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.bsWfGetDocTypes = new System.Windows.Forms.BindingSource(this.components);
            this.taWfGetDocTypes = new WMSOffice.Data.WHTableAdapters.WF_GetDocTypesTableAdapter();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbApprover = new System.Windows.Forms.ComboBox();
            this.bsWfGetApproverList = new System.Windows.Forms.BindingSource(this.components);
            this.taWfGetApproverList = new WMSOffice.Data.WHTableAdapters.WF_GetApproverListTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbJDE = new System.Windows.Forms.ComboBox();
            this.bsWfGetJDEDocTypes = new System.Windows.Forms.BindingSource(this.components);
            this.taWfGetJDEDocTypes = new WMSOffice.Data.WHTableAdapters.WF_GetJDEDocTypesTableAdapter();
            this.lblInventory = new System.Windows.Forms.Label();
            this.cmbInventory = new System.Windows.Forms.ComboBox();
            this.bsWfGetInventarizationList = new System.Windows.Forms.BindingSource(this.components);
            this.taWfGetInventarizationList = new WMSOffice.Data.WHTableAdapters.WF_GetInventarizationListTableAdapter();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.dtpDocDate = new System.Windows.Forms.DateTimePicker();
            this.cbSimpleAct = new System.Windows.Forms.CheckBox();
            this.cbForeignCurrency = new System.Windows.Forms.CheckBox();
            this.ecbSuppliers = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.suppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbSelectSupplier = new System.Windows.Forms.CheckBox();
            this.suppliersTableAdapter = new WMSOffice.Data.WHTableAdapters.SuppliersTableAdapter();
            this.cbIsNotBalance = new System.Windows.Forms.CheckBox();
            this.tsMainTool = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.spcTwoGrids.Panel1.SuspendLayout();
            this.spcTwoGrids.Panel2.SuspendLayout();
            this.spcTwoGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).BeginInit();
            this.spcInternalGrid.Panel1.SuspendLayout();
            this.spcInternalGrid.Panel2.SuspendLayout();
            this.spcInternalGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocsDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetWarehouseList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetApproverList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetJDEDocTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetInventarizationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).BeginInit();
            this.tsMainTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(793, 707);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Отмена";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(712, 707);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // spcTwoGrids
            // 
            this.spcTwoGrids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcTwoGrids.Location = new System.Drawing.Point(15, 222);
            this.spcTwoGrids.Name = "spcTwoGrids";
            this.spcTwoGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcTwoGrids.Panel1
            // 
            this.spcTwoGrids.Panel1.Controls.Add(this.pbWait);
            this.spcTwoGrids.Panel1.Controls.Add(this.dgvRemains);
            // 
            // spcTwoGrids.Panel2
            // 
            this.spcTwoGrids.Panel2.Controls.Add(this.spcInternalGrid);
            this.spcTwoGrids.Size = new System.Drawing.Size(853, 479);
            this.spcTwoGrids.SplitterDistance = 226;
            this.spcTwoGrids.TabIndex = 6;
            // 
            // pbWait
            // 
            this.pbWait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbWait.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbWait.Location = new System.Drawing.Point(378, 59);
            this.pbWait.Name = "pbWait";
            this.pbWait.Size = new System.Drawing.Size(100, 102);
            this.pbWait.TabIndex = 1;
            this.pbWait.TabStop = false;
            this.pbWait.Visible = false;
            // 
            // dgvRemains
            // 
            this.dgvRemains.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRemains.LargeAmountOfData = true;
            this.dgvRemains.Location = new System.Drawing.Point(0, 0);
            this.dgvRemains.Name = "dgvRemains";
            this.dgvRemains.RowHeadersVisible = false;
            this.dgvRemains.Size = new System.Drawing.Size(853, 226);
            this.dgvRemains.TabIndex = 0;
            this.dgvRemains.UserID = ((long)(0));
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
            this.spcInternalGrid.Panel1.Controls.Add(this.btnExcelImport);
            this.spcInternalGrid.Panel1.Controls.Add(this.btnRemoveFromDoc);
            this.spcInternalGrid.Panel1.Controls.Add(this.btnAddToDoc);
            this.spcInternalGrid.Panel1MinSize = 50;
            // 
            // spcInternalGrid.Panel2
            // 
            this.spcInternalGrid.Panel2.Controls.Add(this.dgvDocLines);
            this.spcInternalGrid.Size = new System.Drawing.Size(853, 249);
            this.spcInternalGrid.TabIndex = 0;
            // 
            // btnExcelImport
            // 
            this.btnExcelImport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExcelImport.Location = new System.Drawing.Point(125, 3);
            this.btnExcelImport.Name = "btnExcelImport";
            this.btnExcelImport.Size = new System.Drawing.Size(55, 44);
            this.btnExcelImport.TabIndex = 2;
            this.btnExcelImport.UseVisualStyleBackColor = true;
            this.btnExcelImport.Click += new System.EventHandler(this.btnExcelImport_Click);
            // 
            // btnRemoveFromDoc
            // 
            this.btnRemoveFromDoc.Enabled = false;
            this.btnRemoveFromDoc.Image = global::WMSOffice.Properties.Resources.up;
            this.btnRemoveFromDoc.Location = new System.Drawing.Point(64, 3);
            this.btnRemoveFromDoc.Name = "btnRemoveFromDoc";
            this.btnRemoveFromDoc.Size = new System.Drawing.Size(55, 44);
            this.btnRemoveFromDoc.TabIndex = 1;
            this.btnRemoveFromDoc.UseVisualStyleBackColor = true;
            this.btnRemoveFromDoc.Click += new System.EventHandler(this.btnRemoveFromDoc_Click);
            // 
            // btnAddToDoc
            // 
            this.btnAddToDoc.Enabled = false;
            this.btnAddToDoc.Image = global::WMSOffice.Properties.Resources.down;
            this.btnAddToDoc.Location = new System.Drawing.Point(3, 3);
            this.btnAddToDoc.Name = "btnAddToDoc";
            this.btnAddToDoc.Size = new System.Drawing.Size(55, 44);
            this.btnAddToDoc.TabIndex = 0;
            this.btnAddToDoc.UseVisualStyleBackColor = true;
            this.btnAddToDoc.Click += new System.EventHandler(this.btnAddToDoc_Click);
            // 
            // dgvDocLines
            // 
            this.dgvDocLines.AllowUserToAddRows = false;
            this.dgvDocLines.AllowUserToDeleteRows = false;
            this.dgvDocLines.AllowUserToOrderColumns = true;
            this.dgvDocLines.AllowUserToResizeRows = false;
            this.dgvDocLines.AutoGenerateColumns = false;
            this.dgvDocLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clLineID,
            this.clLocationID,
            this.clItemID,
            this.clItem,
            this.clManufacturer,
            this.clVat,
            this.clLotNumber,
            this.clBatchID,
            this.clExpirationDate,
            this.clQuantity,
            this.clUOM,
            this.clAmountUAH,
            this.clPrice,
            this.clLotStatus,
            this.clMoz,
            this.clVendor});
            this.dgvDocLines.DataSource = this.bsWfGetDocsDetail;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocLines.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocLines.Location = new System.Drawing.Point(0, 0);
            this.dgvDocLines.Name = "dgvDocLines";
            this.dgvDocLines.RowHeadersVisible = false;
            this.dgvDocLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocLines.Size = new System.Drawing.Size(853, 195);
            this.dgvDocLines.TabIndex = 0;
            this.dgvDocLines.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDocLines_CellValidating);
            this.dgvDocLines.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocLines_CellEndEdit);
            this.dgvDocLines.SelectionChanged += new System.EventHandler(this.dgvDocLines_SelectionChanged);
            // 
            // clLineID
            // 
            this.clLineID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLineID.DataPropertyName = "Line_ID";
            this.clLineID.HeaderText = "№";
            this.clLineID.Name = "clLineID";
            this.clLineID.ReadOnly = true;
            this.clLineID.Width = 43;
            // 
            // clLocationID
            // 
            this.clLocationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLocationID.DataPropertyName = "Location_ID";
            this.clLocationID.HeaderText = "Место";
            this.clLocationID.Name = "clLocationID";
            this.clLocationID.ReadOnly = true;
            this.clLocationID.Width = 64;
            // 
            // clItemID
            // 
            this.clItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItemID.DataPropertyName = "Item_ID";
            this.clItemID.HeaderText = "ID товара";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 75;
            // 
            // clItem
            // 
            this.clItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItem.DataPropertyName = "Item";
            this.clItem.HeaderText = "Наименование товара";
            this.clItem.Name = "clItem";
            this.clItem.ReadOnly = true;
            this.clItem.Width = 133;
            // 
            // clManufacturer
            // 
            this.clManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clManufacturer.DataPropertyName = "Manufacturer";
            this.clManufacturer.HeaderText = "Производитель";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.ReadOnly = true;
            this.clManufacturer.Width = 111;
            // 
            // clVat
            // 
            this.clVat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clVat.DataPropertyName = "VAT";
            this.clVat.HeaderText = "НДС";
            this.clVat.Name = "clVat";
            this.clVat.ReadOnly = true;
            this.clVat.Width = 56;
            // 
            // clLotNumber
            // 
            this.clLotNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLotNumber.DataPropertyName = "Lot_Number";
            this.clLotNumber.HeaderText = "Серия";
            this.clLotNumber.Name = "clLotNumber";
            this.clLotNumber.ReadOnly = true;
            this.clLotNumber.Width = 63;
            // 
            // clBatchID
            // 
            this.clBatchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clBatchID.DataPropertyName = "Batch_ID";
            this.clBatchID.HeaderText = "Партия";
            this.clBatchID.Name = "clBatchID";
            this.clBatchID.ReadOnly = true;
            this.clBatchID.Width = 69;
            // 
            // clExpirationDate
            // 
            this.clExpirationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clExpirationDate.DataPropertyName = "ExpirationDate";
            this.clExpirationDate.HeaderText = "Срок годности";
            this.clExpirationDate.Name = "clExpirationDate";
            this.clExpirationDate.ReadOnly = true;
            this.clExpirationDate.Width = 97;
            // 
            // clQuantity
            // 
            this.clQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clQuantity.DataPropertyName = "Quantity";
            this.clQuantity.HeaderText = "Кол-во";
            this.clQuantity.Name = "clQuantity";
            this.clQuantity.Width = 66;
            // 
            // clUOM
            // 
            this.clUOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clUOM.DataPropertyName = "UOM";
            this.clUOM.HeaderText = "ЕИ";
            this.clUOM.Name = "clUOM";
            this.clUOM.ReadOnly = true;
            this.clUOM.Width = 47;
            // 
            // clAmountUAH
            // 
            this.clAmountUAH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clAmountUAH.DataPropertyName = "Amount_UAH";
            this.clAmountUAH.HeaderText = "Цена всего";
            this.clAmountUAH.Name = "clAmountUAH";
            this.clAmountUAH.ReadOnly = true;
            this.clAmountUAH.Width = 83;
            // 
            // clPrice
            // 
            this.clPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clPrice.DataPropertyName = "Price";
            this.clPrice.HeaderText = "Цена за шт.";
            this.clPrice.Name = "clPrice";
            this.clPrice.ReadOnly = true;
            this.clPrice.Width = 70;
            // 
            // clLotStatus
            // 
            this.clLotStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLotStatus.DataPropertyName = "LotStatus";
            this.clLotStatus.HeaderText = "Код задержки";
            this.clLotStatus.Name = "clLotStatus";
            this.clLotStatus.ReadOnly = true;
            this.clLotStatus.Width = 96;
            // 
            // clMoz
            // 
            this.clMoz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clMoz.DataPropertyName = "MOZ";
            this.clMoz.HeaderText = "МОЗ";
            this.clMoz.Name = "clMoz";
            this.clMoz.ReadOnly = true;
            this.clMoz.Width = 56;
            // 
            // clVendor
            // 
            this.clVendor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clVendor.DataPropertyName = "Vendor";
            this.clVendor.HeaderText = "Поставщик";
            this.clVendor.Name = "clVendor";
            this.clVendor.ReadOnly = true;
            this.clVendor.Width = 90;
            // 
            // bsWfGetDocsDetail
            // 
            this.bsWfGetDocsDetail.DataMember = "WF_GetDocs_Detail";
            this.bsWfGetDocsDetail.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(15, 202);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(172, 13);
            this.lblItems.TabIndex = 7;
            this.lblItems.Text = "Выберите товары для списания:";
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
            // lblDocId
            // 
            this.lblDocId.AutoSize = true;
            this.lblDocId.Location = new System.Drawing.Point(10, 9);
            this.lblDocId.Name = "lblDocId";
            this.lblDocId.Size = new System.Drawing.Size(56, 13);
            this.lblDocId.TabIndex = 8;
            this.lblDocId.Text = "ID док-та:";
            // 
            // tbxID
            // 
            this.tbxID.Enabled = false;
            this.tbxID.Location = new System.Drawing.Point(79, 5);
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(108, 20);
            this.tbxID.TabIndex = 9;
            // 
            // tbxActComment
            // 
            this.tbxActComment.Location = new System.Drawing.Point(251, 5);
            this.tbxActComment.Name = "tbxActComment";
            this.tbxActComment.Size = new System.Drawing.Size(100, 20);
            this.tbxActComment.TabIndex = 29;
            // 
            // lblActComment
            // 
            this.lblActComment.AutoSize = true;
            this.lblActComment.Location = new System.Drawing.Point(198, 2);
            this.lblActComment.Name = "lblActComment";
            this.lblActComment.Size = new System.Drawing.Size(47, 26);
            this.lblActComment.TabIndex = 30;
            this.lblActComment.Text = "№ акта \r\nбрака:";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 39);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse.TabIndex = 10;
            this.lblWarehouse.Text = "Склад:";
            // 
            // taWfGetDocsDetail
            // 
            this.taWfGetDocsDetail.ClearBeforeFill = true;
            // 
            // cmbWarehouses
            // 
            this.cmbWarehouses.DataSource = this.bsWfGetWarehouseList;
            this.cmbWarehouses.DisplayMember = "Warehouse_DSC";
            this.cmbWarehouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouses.FormattingEnabled = true;
            this.cmbWarehouses.Location = new System.Drawing.Point(79, 35);
            this.cmbWarehouses.Name = "cmbWarehouses";
            this.cmbWarehouses.Size = new System.Drawing.Size(272, 21);
            this.cmbWarehouses.TabIndex = 11;
            this.cmbWarehouses.ValueMember = "Warehouse_ID";
            // 
            // bsWfGetWarehouseList
            // 
            this.bsWfGetWarehouseList.DataMember = "WF_GetWarehouseList";
            this.bsWfGetWarehouseList.DataSource = this.wH;
            // 
            // taWfGetWarehouseList
            // 
            this.taWfGetWarehouseList.ClearBeforeFill = true;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(388, 39);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(80, 13);
            this.lblDocType.TabIndex = 12;
            this.lblDocType.Text = "Вид списания:";
            // 
            // cmbDocType
            // 
            this.cmbDocType.DataSource = this.bsWfGetDocTypes;
            this.cmbDocType.DisplayMember = "Desc";
            this.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Location = new System.Drawing.Point(503, 35);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(292, 21);
            this.cmbDocType.TabIndex = 13;
            this.cmbDocType.ValueMember = "DocType";
            this.cmbDocType.SelectedIndexChanged += new System.EventHandler(this.cmbDocType_SelectedIndexChanged);
            // 
            // bsWfGetDocTypes
            // 
            this.bsWfGetDocTypes.DataMember = "WF_GetDocTypes";
            this.bsWfGetDocTypes.DataSource = this.wH;
            // 
            // taWfGetDocTypes
            // 
            this.taWfGetDocTypes.ClearBeforeFill = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(390, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Описание:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(503, 5);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(292, 20);
            this.tbxDescription.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Сотрудник:";
            // 
            // cmbApprover
            // 
            this.cmbApprover.DataSource = this.bsWfGetApproverList;
            this.cmbApprover.DisplayMember = "Approver";
            this.cmbApprover.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApprover.FormattingEnabled = true;
            this.cmbApprover.Location = new System.Drawing.Point(79, 68);
            this.cmbApprover.Name = "cmbApprover";
            this.cmbApprover.Size = new System.Drawing.Size(272, 21);
            this.cmbApprover.TabIndex = 17;
            this.cmbApprover.ValueMember = "Approver_ID";
            // 
            // bsWfGetApproverList
            // 
            this.bsWfGetApproverList.DataMember = "WF_GetApproverList";
            this.bsWfGetApproverList.DataSource = this.wH;
            // 
            // taWfGetApproverList
            // 
            this.taWfGetApproverList.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Тип документа JDE:";
            // 
            // cmbJDE
            // 
            this.cmbJDE.DataSource = this.bsWfGetJDEDocTypes;
            this.cmbJDE.DisplayMember = "Desc";
            this.cmbJDE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJDE.FormattingEnabled = true;
            this.cmbJDE.Location = new System.Drawing.Point(503, 68);
            this.cmbJDE.Name = "cmbJDE";
            this.cmbJDE.Size = new System.Drawing.Size(292, 21);
            this.cmbJDE.TabIndex = 19;
            this.cmbJDE.ValueMember = "DocType";
            this.cmbJDE.SelectedValueChanged += new System.EventHandler(this.cmbJDE_SelectedValueChanged);
            // 
            // bsWfGetJDEDocTypes
            // 
            this.bsWfGetJDEDocTypes.DataMember = "WF_GetJDEDocTypes";
            this.bsWfGetJDEDocTypes.DataSource = this.wH;
            // 
            // taWfGetJDEDocTypes
            // 
            this.taWfGetJDEDocTypes.ClearBeforeFill = true;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Location = new System.Drawing.Point(390, 138);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(95, 13);
            this.lblInventory.TabIndex = 20;
            this.lblInventory.Text = "Инвентаризация:";
            // 
            // cmbInventory
            // 
            this.cmbInventory.DataSource = this.bsWfGetInventarizationList;
            this.cmbInventory.DisplayMember = "Description";
            this.cmbInventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventory.DropDownWidth = 350;
            this.cmbInventory.FormattingEnabled = true;
            this.cmbInventory.Location = new System.Drawing.Point(503, 134);
            this.cmbInventory.Name = "cmbInventory";
            this.cmbInventory.Size = new System.Drawing.Size(292, 21);
            this.cmbInventory.TabIndex = 21;
            this.cmbInventory.ValueMember = "Inventory_ID";
            // 
            // bsWfGetInventarizationList
            // 
            this.bsWfGetInventarizationList.DataMember = "WF_GetInventarizationList";
            this.bsWfGetInventarizationList.DataSource = this.wH;
            // 
            // taWfGetInventarizationList
            // 
            this.taWfGetInventarizationList.ClearBeforeFill = true;
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Location = new System.Drawing.Point(10, 105);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(36, 13);
            this.lblDocDate.TabIndex = 22;
            this.lblDocDate.Text = "Дата:";
            // 
            // dtpDocDate
            // 
            this.dtpDocDate.Location = new System.Drawing.Point(79, 101);
            this.dtpDocDate.Name = "dtpDocDate";
            this.dtpDocDate.Size = new System.Drawing.Size(139, 20);
            this.dtpDocDate.TabIndex = 23;
            // 
            // cbSimpleAct
            // 
            this.cbSimpleAct.AutoSize = true;
            this.cbSimpleAct.Location = new System.Drawing.Point(79, 171);
            this.cbSimpleAct.Name = "cbSimpleAct";
            this.cbSimpleAct.Size = new System.Drawing.Size(256, 17);
            this.cbSimpleAct.TabIndex = 24;
            this.cbSimpleAct.Text = "Формирования акта отдельным документом";
            this.cbSimpleAct.UseVisualStyleBackColor = true;
            // 
            // cbForeignCurrency
            // 
            this.cbForeignCurrency.AutoSize = true;
            this.cbForeignCurrency.Location = new System.Drawing.Point(503, 171);
            this.cbForeignCurrency.Name = "cbForeignCurrency";
            this.cbForeignCurrency.Size = new System.Drawing.Size(141, 17);
            this.cbForeignCurrency.TabIndex = 25;
            this.cbForeignCurrency.Text = "В иностранной валюте";
            this.cbForeignCurrency.UseVisualStyleBackColor = true;
            // 
            // ecbSuppliers
            // 
            this.ecbSuppliers.DataSource = this.suppliersBindingSource;
            this.ecbSuppliers.DisplayMember = "Vendor_Name";
            this.ecbSuppliers.FormattingEnabled = true;
            this.ecbSuppliers.Location = new System.Drawing.Point(503, 101);
            this.ecbSuppliers.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.ecbSuppliers.Name = "ecbSuppliers";
            this.ecbSuppliers.Size = new System.Drawing.Size(292, 21);
            this.ecbSuppliers.TabIndex = 26;
            this.ecbSuppliers.ValueMember = "Vendor_ID";
            // 
            // suppliersBindingSource
            // 
            this.suppliersBindingSource.DataMember = "Suppliers";
            this.suppliersBindingSource.DataSource = this.wH;
            // 
            // cbSelectSupplier
            // 
            this.cbSelectSupplier.AutoSize = true;
            this.cbSelectSupplier.Location = new System.Drawing.Point(391, 103);
            this.cbSelectSupplier.Name = "cbSelectSupplier";
            this.cbSelectSupplier.Size = new System.Drawing.Size(84, 17);
            this.cbSelectSupplier.TabIndex = 27;
            this.cbSelectSupplier.Text = "Поставщик";
            this.cbSelectSupplier.UseVisualStyleBackColor = true;
            this.cbSelectSupplier.CheckedChanged += new System.EventHandler(this.cbSelectSupplier_CheckedChanged);
            // 
            // suppliersTableAdapter
            // 
            this.suppliersTableAdapter.ClearBeforeFill = true;
            // 
            // cbIsNotBalance
            // 
            this.cbIsNotBalance.AutoSize = true;
            this.cbIsNotBalance.Location = new System.Drawing.Point(79, 136);
            this.cbIsNotBalance.Name = "cbIsNotBalance";
            this.cbIsNotBalance.Size = new System.Drawing.Size(141, 17);
            this.cbIsNotBalance.TabIndex = 28;
            this.cbIsNotBalance.Text = "Списание на забаланс";
            this.cbIsNotBalance.UseVisualStyleBackColor = true;
            // 
            // tsMainTool
            // 
            this.tsMainTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsMainTool.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMainTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.tsMainTool.Location = new System.Drawing.Point(775, 196);
            this.tsMainTool.Name = "tsMainTool";
            this.tsMainTool.Size = new System.Drawing.Size(93, 25);
            this.tsMainTool.TabIndex = 31;
            this.tsMainTool.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 22);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // CreateWriteOffStuffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(884, 742);
            this.Controls.Add(this.tsMainTool);
            this.Controls.Add(this.cbIsNotBalance);
            this.Controls.Add(this.cbSelectSupplier);
            this.Controls.Add(this.ecbSuppliers);
            this.Controls.Add(this.cbForeignCurrency);
            this.Controls.Add(this.cbSimpleAct);
            this.Controls.Add(this.dtpDocDate);
            this.Controls.Add(this.lblDocDate);
            this.Controls.Add(this.cmbInventory);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.cmbJDE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbApprover);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbDocType);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.cmbWarehouses);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.tbxID);
            this.Controls.Add(this.lblDocId);
            this.Controls.Add(this.lblActComment);
            this.Controls.Add(this.tbxActComment);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.spcTwoGrids);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.KeyPreview = true;
            this.Name = "CreateWriteOffStuffForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание макета списания";
            this.Load += new System.EventHandler(this.CreateWriteOffStuffForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateWriteOffStuffForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateWriteOffStuffForm_KeyDown);
            this.spcTwoGrids.Panel1.ResumeLayout(false);
            this.spcTwoGrids.Panel2.ResumeLayout(false);
            this.spcTwoGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).EndInit();
            this.spcInternalGrid.Panel1.ResumeLayout(false);
            this.spcInternalGrid.Panel2.ResumeLayout(false);
            this.spcInternalGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocsDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetWarehouseList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetApproverList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetJDEDocTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetInventarizationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).EndInit();
            this.tsMainTool.ResumeLayout(false);
            this.tsMainTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer spcTwoGrids;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.SplitContainer spcInternalGrid;
        private System.Windows.Forms.DataGridView dgvDocLines;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.Label lblDocId;
        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.TextBox tbxActComment;
        private System.Windows.Forms.Label lblActComment;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.BindingSource bsWfGetDocsDetail;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.WF_GetDocs_DetailTableAdapter taWfGetDocsDetail;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvRemains;
        private System.Windows.Forms.Button btnRemoveFromDoc;
        private System.Windows.Forms.Button btnAddToDoc;
        private System.Windows.Forms.ComboBox cmbWarehouses;
        private System.Windows.Forms.BindingSource bsWfGetWarehouseList;
        private WMSOffice.Data.WHTableAdapters.WF_GetWarehouseListTableAdapter taWfGetWarehouseList;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.BindingSource bsWfGetDocTypes;
        private WMSOffice.Data.WHTableAdapters.WF_GetDocTypesTableAdapter taWfGetDocTypes;
        private System.Windows.Forms.PictureBox pbWait;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbApprover;
        private System.Windows.Forms.BindingSource bsWfGetApproverList;
        private WMSOffice.Data.WHTableAdapters.WF_GetApproverListTableAdapter taWfGetApproverList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbJDE;
        private System.Windows.Forms.BindingSource bsWfGetJDEDocTypes;
        private WMSOffice.Data.WHTableAdapters.WF_GetJDEDocTypesTableAdapter taWfGetJDEDocTypes;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.ComboBox cmbInventory;
        private System.Windows.Forms.BindingSource bsWfGetInventarizationList;
        private WMSOffice.Data.WHTableAdapters.WF_GetInventarizationListTableAdapter taWfGetInventarizationList;
        private System.Windows.Forms.Button btnExcelImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLocationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAmountUAH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLotStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMoz;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendor;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.DateTimePicker dtpDocDate;
        private System.Windows.Forms.CheckBox cbSimpleAct;
        private System.Windows.Forms.CheckBox cbForeignCurrency;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox ecbSuppliers;
        private System.Windows.Forms.CheckBox cbSelectSupplier;
        private System.Windows.Forms.BindingSource suppliersBindingSource;
        private WMSOffice.Data.WHTableAdapters.SuppliersTableAdapter suppliersTableAdapter;
        private System.Windows.Forms.CheckBox cbIsNotBalance;
        private System.Windows.Forms.ToolStrip tsMainTool;
        private System.Windows.Forms.ToolStripButton btnRefresh;
    }
}