namespace WMSOffice.Dialogs.Inventory
{
    partial class PostInventoryFilialItemPeresortForm
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
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.clResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clWhID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcVatRateDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFpGetItemsForReparation = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnRemoveItems = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.dgvDocItems = new System.Windows.Forms.DataGridView();
            this.clDeTemplateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeFt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeIdProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeWhId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeUm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeBasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeBaseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeDateUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeCheckedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsFpGetCorrectionDetails = new System.Windows.Forms.BindingSource(this.components);
            this.lblDocItems = new System.Windows.Forms.Label();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.taFpGetItemsForReparation = new WMSOffice.Data.InventoryTableAdapters.FP_Get_Items_For_ReparationTableAdapter();
            this.taFpGetCorrectionDetails = new WMSOffice.Data.InventoryTableAdapters.FP_Get_Correction_DetailsTableAdapter();
            this.btnExportExcel = new System.Windows.Forms.Button();
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
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetItemsForReparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetCorrectionDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1019, 543);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 27);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.Location = new System.Drawing.Point(8, 1);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.tbxFilter);
            this.spcMain.Panel1.Controls.Add(this.label1);
            this.spcMain.Panel1.Controls.Add(this.dgvItems);
            this.spcMain.Panel1.Controls.Add(this.lblItems);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.btnRemoveItems);
            this.spcMain.Panel2.Controls.Add(this.btnAddItems);
            this.spcMain.Panel2.Controls.Add(this.dgvDocItems);
            this.spcMain.Panel2.Controls.Add(this.lblDocItems);
            this.spcMain.Size = new System.Drawing.Size(1110, 536);
            this.spcMain.SplitterDistance = 548;
            this.spcMain.TabIndex = 2;
            // 
            // tbxFilter
            // 
            this.tbxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbxFilter.Location = new System.Drawing.Point(75, 32);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(371, 24);
            this.tbxFilter.TabIndex = 4;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фильтр:";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToOrderColumns = true;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clResult,
            this.clItemID,
            this.clItem,
            this.clQuantity,
            this.clWhID,
            this.clLocation,
            this.clVAT,
            this.dgvcVatRateDescription,
            this.clSS,
            this.clPrice,
            this.clBase,
            this.clBasePrice,
            this.clUoM,
            this.clBatchID,
            this.clLotNumber,
            this.clManufacturer});
            this.dgvItems.DataSource = this.bsFpGetItemsForReparation;
            this.dgvItems.Location = new System.Drawing.Point(0, 65);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(545, 471);
            this.dgvItems.TabIndex = 2;
            this.dgvItems.Sorted += new System.EventHandler(this.dgvItems_Sorted);
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // clResult
            // 
            this.clResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clResult.DataPropertyName = "Результат";
            this.clResult.HeaderText = "Результат";
            this.clResult.Name = "clResult";
            this.clResult.ReadOnly = true;
            this.clResult.Width = 84;
            // 
            // clItemID
            // 
            this.clItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItemID.DataPropertyName = "Код товара";
            this.clItemID.HeaderText = "Код товара";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 82;
            // 
            // clItem
            // 
            this.clItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItem.DataPropertyName = "Наименование";
            this.clItem.HeaderText = "Наименование";
            this.clItem.Name = "clItem";
            this.clItem.ReadOnly = true;
            this.clItem.Width = 108;
            // 
            // clQuantity
            // 
            this.clQuantity.DataPropertyName = "Кол-во";
            this.clQuantity.HeaderText = "Кол-во";
            this.clQuantity.Name = "clQuantity";
            this.clQuantity.ReadOnly = true;
            // 
            // clWhID
            // 
            this.clWhID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clWhID.DataPropertyName = "Код склада";
            this.clWhID.HeaderText = "Код склада";
            this.clWhID.Name = "clWhID";
            this.clWhID.ReadOnly = true;
            this.clWhID.Width = 83;
            // 
            // clLocation
            // 
            this.clLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLocation.DataPropertyName = "Полка";
            this.clLocation.HeaderText = "Полка";
            this.clLocation.Name = "clLocation";
            this.clLocation.ReadOnly = true;
            this.clLocation.Width = 64;
            // 
            // clVAT
            // 
            this.clVAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clVAT.DataPropertyName = "Признак НДС";
            this.clVAT.HeaderText = "НДС";
            this.clVAT.Name = "clVAT";
            this.clVAT.ReadOnly = true;
            this.clVAT.Width = 56;
            // 
            // dgvcVatRateDescription
            // 
            this.dgvcVatRateDescription.DataPropertyName = "ставка/зона Описание";
            this.dgvcVatRateDescription.HeaderText = "Ставка/Зона закупки";
            this.dgvcVatRateDescription.Name = "dgvcVatRateDescription";
            this.dgvcVatRateDescription.ReadOnly = true;
            this.dgvcVatRateDescription.Width = 80;
            // 
            // clSS
            // 
            this.clSS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clSS.DataPropertyName = "Себестоимость";
            this.clSS.HeaderText = "Цена в с/с";
            this.clSS.Name = "clSS";
            this.clSS.ReadOnly = true;
            this.clSS.Width = 65;
            // 
            // clPrice
            // 
            this.clPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clPrice.DataPropertyName = "сумма в себестоимости";
            this.clPrice.HeaderText = "Сумма в с/с";
            this.clPrice.Name = "clPrice";
            this.clPrice.ReadOnly = true;
            this.clPrice.Width = 72;
            // 
            // clBase
            // 
            this.clBase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clBase.DataPropertyName = "Базовая цена";
            this.clBase.HeaderText = "Цена в базовых";
            this.clBase.Name = "clBase";
            this.clBase.ReadOnly = true;
            this.clBase.Width = 104;
            // 
            // clBasePrice
            // 
            this.clBasePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clBasePrice.DataPropertyName = "сумма в базовых ценах";
            this.clBasePrice.HeaderText = "Сумма в базовых";
            this.clBasePrice.Name = "clBasePrice";
            this.clBasePrice.ReadOnly = true;
            this.clBasePrice.Width = 111;
            // 
            // clUoM
            // 
            this.clUoM.DataPropertyName = "Ед_изм_";
            this.clUoM.HeaderText = "ЕИ";
            this.clUoM.Name = "clUoM";
            this.clUoM.ReadOnly = true;
            // 
            // clBatchID
            // 
            this.clBatchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clBatchID.DataPropertyName = "Партия";
            this.clBatchID.HeaderText = "Партия";
            this.clBatchID.Name = "clBatchID";
            this.clBatchID.ReadOnly = true;
            this.clBatchID.Width = 69;
            // 
            // clLotNumber
            // 
            this.clLotNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLotNumber.DataPropertyName = "Серия";
            this.clLotNumber.HeaderText = "Серия";
            this.clLotNumber.Name = "clLotNumber";
            this.clLotNumber.ReadOnly = true;
            this.clLotNumber.Visible = false;
            // 
            // clManufacturer
            // 
            this.clManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clManufacturer.DataPropertyName = "Производитель";
            this.clManufacturer.HeaderText = "Производитель";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.ReadOnly = true;
            this.clManufacturer.Width = 111;
            // 
            // bsFpGetItemsForReparation
            // 
            this.bsFpGetItemsForReparation.DataMember = "FP_Get_Items_For_Reparation";
            this.bsFpGetItemsForReparation.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItems.Location = new System.Drawing.Point(3, 8);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(247, 18);
            this.lblItems.TabIndex = 1;
            this.lblItems.Text = "Доступные для пересорта товары";
            // 
            // btnRemoveItems
            // 
            this.btnRemoveItems.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemoveItems.Enabled = false;
            this.btnRemoveItems.Image = global::WMSOffice.Properties.Resources.arrow_left;
            this.btnRemoveItems.Location = new System.Drawing.Point(3, 259);
            this.btnRemoveItems.Name = "btnRemoveItems";
            this.btnRemoveItems.Size = new System.Drawing.Size(45, 46);
            this.btnRemoveItems.TabIndex = 3;
            this.btnRemoveItems.UseVisualStyleBackColor = true;
            this.btnRemoveItems.Click += new System.EventHandler(this.btnRemoveItems_Click);
            // 
            // btnAddItems
            // 
            this.btnAddItems.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddItems.Enabled = false;
            this.btnAddItems.Image = global::WMSOffice.Properties.Resources.arrow_right;
            this.btnAddItems.Location = new System.Drawing.Point(3, 207);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(45, 46);
            this.btnAddItems.TabIndex = 2;
            this.btnAddItems.UseVisualStyleBackColor = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // dgvDocItems
            // 
            this.dgvDocItems.AllowUserToAddRows = false;
            this.dgvDocItems.AllowUserToDeleteRows = false;
            this.dgvDocItems.AllowUserToOrderColumns = true;
            this.dgvDocItems.AllowUserToResizeRows = false;
            this.dgvDocItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocItems.AutoGenerateColumns = false;
            this.dgvDocItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDeTemplateId,
            this.clDeLineId,
            this.clDeFt,
            this.clDeIdProv,
            this.clDeItemId,
            this.Item_Name,
            this.clDeBatchID,
            this.clDeWhId,
            this.clDeLocation,
            this.clDeUm,
            this.clDeQuantity,
            this.clDePrice,
            this.clDeSum,
            this.clDeBasePrice,
            this.clDeBaseAmount,
            this.clDeDateUpdated,
            this.clDeCheckedFlag});
            this.dgvDocItems.DataSource = this.bsFpGetCorrectionDetails;
            this.dgvDocItems.Location = new System.Drawing.Point(54, 29);
            this.dgvDocItems.Name = "dgvDocItems";
            this.dgvDocItems.RowHeadersVisible = false;
            this.dgvDocItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocItems.Size = new System.Drawing.Size(501, 504);
            this.dgvDocItems.TabIndex = 1;
            this.dgvDocItems.Sorted += new System.EventHandler(this.dgvDocItems_Sorted);
            this.dgvDocItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocItems_CellFormatting);
            this.dgvDocItems.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDocItems_CellValidating);
            this.dgvDocItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocItems_CellEndEdit);
            this.dgvDocItems.SelectionChanged += new System.EventHandler(this.dgvDocItems_SelectionChanged);
            // 
            // clDeTemplateId
            // 
            this.clDeTemplateId.DataPropertyName = "Template_ID";
            this.clDeTemplateId.HeaderText = "Template_ID";
            this.clDeTemplateId.Name = "clDeTemplateId";
            this.clDeTemplateId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeTemplateId.Visible = false;
            // 
            // clDeLineId
            // 
            this.clDeLineId.DataPropertyName = "№ строки";
            this.clDeLineId.HeaderText = "№ строки";
            this.clDeLineId.Name = "clDeLineId";
            this.clDeLineId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeLineId.Visible = false;
            // 
            // clDeFt
            // 
            this.clDeFt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeFt.DataPropertyName = "FT";
            this.clDeFt.HeaderText = "FT";
            this.clDeFt.Name = "clDeFt";
            this.clDeFt.ReadOnly = true;
            this.clDeFt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeFt.Width = 26;
            // 
            // clDeIdProv
            // 
            this.clDeIdProv.DataPropertyName = "ID проводки";
            this.clDeIdProv.HeaderText = "ID проводки";
            this.clDeIdProv.Name = "clDeIdProv";
            this.clDeIdProv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeIdProv.Visible = false;
            // 
            // clDeItemId
            // 
            this.clDeItemId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeItemId.DataPropertyName = "Код товара";
            this.clDeItemId.HeaderText = "Код товара";
            this.clDeItemId.Name = "clDeItemId";
            this.clDeItemId.ReadOnly = true;
            this.clDeItemId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeItemId.Width = 63;
            // 
            // Item_Name
            // 
            this.Item_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Item_Name.DataPropertyName = "Item_Name";
            this.Item_Name.HeaderText = "Наименование";
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.ReadOnly = true;
            this.Item_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Item_Name.Width = 89;
            // 
            // clDeBatchID
            // 
            this.clDeBatchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeBatchID.DataPropertyName = "Номер партии";
            this.clDeBatchID.HeaderText = "Номер партии";
            this.clDeBatchID.Name = "clDeBatchID";
            this.clDeBatchID.ReadOnly = true;
            this.clDeBatchID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeBatchID.Width = 77;
            // 
            // clDeWhId
            // 
            this.clDeWhId.DataPropertyName = "Код склада";
            this.clDeWhId.HeaderText = "Код склада";
            this.clDeWhId.Name = "clDeWhId";
            this.clDeWhId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clDeLocation
            // 
            this.clDeLocation.DataPropertyName = "Location";
            this.clDeLocation.HeaderText = "Полка";
            this.clDeLocation.Name = "clDeLocation";
            this.clDeLocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clDeUm
            // 
            this.clDeUm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeUm.DataPropertyName = "ед_ изм_";
            this.clDeUm.HeaderText = "ЕИ";
            this.clDeUm.Name = "clDeUm";
            this.clDeUm.ReadOnly = true;
            this.clDeUm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeUm.Width = 28;
            // 
            // clDeQuantity
            // 
            this.clDeQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeQuantity.DataPropertyName = "Кол-во";
            this.clDeQuantity.HeaderText = "Кол-во";
            this.clDeQuantity.Name = "clDeQuantity";
            this.clDeQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeQuantity.Width = 47;
            // 
            // clDePrice
            // 
            this.clDePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDePrice.DataPropertyName = "Цена";
            this.clDePrice.HeaderText = "Цена в с/с";
            this.clDePrice.Name = "clDePrice";
            this.clDePrice.ReadOnly = true;
            this.clDePrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDePrice.Width = 46;
            // 
            // clDeSum
            // 
            this.clDeSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeSum.DataPropertyName = "Сумма";
            this.clDeSum.HeaderText = "Сумма в с/с";
            this.clDeSum.Name = "clDeSum";
            this.clDeSum.ReadOnly = true;
            this.clDeSum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeSum.Width = 53;
            // 
            // clDeBasePrice
            // 
            this.clDeBasePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeBasePrice.DataPropertyName = "BasePrice";
            this.clDeBasePrice.HeaderText = "Цена в базовых";
            this.clDeBasePrice.Name = "clDeBasePrice";
            this.clDeBasePrice.ReadOnly = true;
            this.clDeBasePrice.Width = 104;
            // 
            // clDeBaseAmount
            // 
            this.clDeBaseAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeBaseAmount.DataPropertyName = "BaseAmount";
            this.clDeBaseAmount.HeaderText = "Сумма в базовых";
            this.clDeBaseAmount.Name = "clDeBaseAmount";
            this.clDeBaseAmount.ReadOnly = true;
            this.clDeBaseAmount.Width = 111;
            // 
            // clDeDateUpdated
            // 
            this.clDeDateUpdated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeDateUpdated.DataPropertyName = "DateUpdated";
            this.clDeDateUpdated.HeaderText = "DateUpdated";
            this.clDeDateUpdated.Name = "clDeDateUpdated";
            this.clDeDateUpdated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeDateUpdated.Visible = false;
            // 
            // clDeCheckedFlag
            // 
            this.clDeCheckedFlag.DataPropertyName = "CheckedFlag";
            this.clDeCheckedFlag.HeaderText = "CheckedFlag";
            this.clDeCheckedFlag.Name = "clDeCheckedFlag";
            this.clDeCheckedFlag.Visible = false;
            // 
            // bsFpGetCorrectionDetails
            // 
            this.bsFpGetCorrectionDetails.DataMember = "FP_Get_Correction_Details";
            this.bsFpGetCorrectionDetails.DataSource = this.inventory;
            // 
            // lblDocItems
            // 
            this.lblDocItems.AutoSize = true;
            this.lblDocItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblDocItems.Location = new System.Drawing.Point(51, 8);
            this.lblDocItems.Name = "lblDocItems";
            this.lblDocItems.Size = new System.Drawing.Size(174, 18);
            this.lblDocItems.TabIndex = 0;
            this.lblDocItems.Text = "Потоварные пересорты";
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 1000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // taFpGetItemsForReparation
            // 
            this.taFpGetItemsForReparation.ClearBeforeFill = true;
            // 
            // taFpGetCorrectionDetails
            // 
            this.taFpGetCorrectionDetails.ClearBeforeFill = true;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(917, 543);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(96, 27);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Экспорт в Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Код склада";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код склада";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Результат";
            this.dataGridViewTextBoxColumn2.HeaderText = "Результат";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Код товара";
            this.dataGridViewTextBoxColumn3.HeaderText = "Код товара";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Наименование";
            this.dataGridViewTextBoxColumn4.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Ед_изм_";
            this.dataGridViewTextBoxColumn5.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Кол-во";
            this.dataGridViewTextBoxColumn6.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Полка";
            this.dataGridViewTextBoxColumn7.HeaderText = "Полка";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Признак НДС";
            this.dataGridViewTextBoxColumn8.HeaderText = "Признак НДС";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Код строки";
            this.dataGridViewTextBoxColumn9.HeaderText = "Код строки";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "сумма в базовых ценах";
            this.dataGridViewTextBoxColumn10.HeaderText = "Сумма в базовых";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "сумма в себестоимости";
            this.dataGridViewTextBoxColumn11.HeaderText = "Сумма в с/с";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Партия";
            this.dataGridViewTextBoxColumn12.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Серия";
            this.dataGridViewTextBoxColumn13.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Себестоимость";
            this.dataGridViewTextBoxColumn14.HeaderText = "С/с";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Базовая цена";
            this.dataGridViewTextBoxColumn15.HeaderText = "Базовая цена";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Производитель";
            this.dataGridViewTextBoxColumn16.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Template_ID";
            this.dataGridViewTextBoxColumn17.HeaderText = "Template_ID";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "№ строки";
            this.dataGridViewTextBoxColumn18.HeaderText = "№ строки";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn18.Visible = false;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "FT";
            this.dataGridViewTextBoxColumn19.HeaderText = "FT";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "ID проводки";
            this.dataGridViewTextBoxColumn20.HeaderText = "ID проводки";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn20.Visible = false;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Код товара";
            this.dataGridViewTextBoxColumn21.HeaderText = "Код товара";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn21.Visible = false;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Item_Name";
            this.dataGridViewTextBoxColumn22.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Номер партии";
            this.dataGridViewTextBoxColumn23.HeaderText = "Номер партии";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn24.HeaderText = "Location";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn24.Visible = false;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Код склада";
            this.dataGridViewTextBoxColumn25.HeaderText = "Код склада";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn25.Visible = false;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn26.DataPropertyName = "ед_ изм_";
            this.dataGridViewTextBoxColumn26.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn26.Visible = false;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn27.DataPropertyName = "Кол-во";
            this.dataGridViewTextBoxColumn27.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Цена";
            this.dataGridViewTextBoxColumn28.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn29.DataPropertyName = "Сумма";
            this.dataGridViewTextBoxColumn29.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn30.DataPropertyName = "DateUpdated";
            this.dataGridViewTextBoxColumn30.HeaderText = "DateUpdated";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn30.Visible = false;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn31.DataPropertyName = "BaseAmount";
            this.dataGridViewTextBoxColumn31.HeaderText = "Сумма в базовых";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn32.DataPropertyName = "DateUpdated";
            this.dataGridViewTextBoxColumn32.HeaderText = "DateUpdated";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn32.Visible = false;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn33.DataPropertyName = "DateUpdated";
            this.dataGridViewTextBoxColumn33.HeaderText = "DateUpdated";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn33.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "CheckedFlag";
            this.dataGridViewCheckBoxColumn1.HeaderText = "CheckedFlag";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // PostInventoryFilialItemPeresortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 582);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.btnCancel);
            this.KeyPreview = true;
            this.Name = "PostInventoryFilialItemPeresortForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Потоварный пересорт";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PostInventoryFilialItemPeresortForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PostInventoryFilialItemPeresortForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostInventoryFilialItemPeresortForm_KeyDown);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.Panel2.PerformLayout();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetItemsForReparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetCorrectionDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.DataGridView dgvDocItems;
        private System.Windows.Forms.Label lblDocItems;
        private System.Windows.Forms.Button btnRemoveItems;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.BindingSource bsFpGetItemsForReparation;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FP_Get_Items_For_ReparationTableAdapter taFpGetItemsForReparation;
        private System.Windows.Forms.Timer delayTimer;
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
        private System.Windows.Forms.BindingSource bsFpGetCorrectionDetails;
        private WMSOffice.Data.InventoryTableAdapters.FP_Get_Correction_DetailsTableAdapter taFpGetCorrectionDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clWhID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcVatRateDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSS;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUoM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeTemplateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeFt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeIdProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeWhId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeUm;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeBasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeBaseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeDateUpdated;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clDeCheckedFlag;
    }
}