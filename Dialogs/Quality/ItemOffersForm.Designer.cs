namespace WMSOffice.Dialogs.Quality
{
    partial class ItemOffersForm
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
            this.dgvOffers = new System.Windows.Forms.DataGridView();
            this.bsBlGetBindingOffers = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.btnClose = new System.Windows.Forms.Button();
            this.taBlGetBindingOffers = new WMSOffice.Data.QualityTableAdapters.BL_Get_BindingOffersTableAdapter();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.clApprove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clHoldID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNonManufacturerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNonManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNonItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNonItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNonVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetBindingOffers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOffers
            // 
            this.dgvOffers.AllowUserToAddRows = false;
            this.dgvOffers.AllowUserToDeleteRows = false;
            this.dgvOffers.AllowUserToResizeRows = false;
            this.dgvOffers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOffers.AutoGenerateColumns = false;
            this.dgvOffers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOffers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clApprove,
            this.clHoldID,
            this.clItemID,
            this.clItem,
            this.clManufacturerID,
            this.clManufacturer,
            this.clVendorLot,
            this.clNonManufacturerId,
            this.clNonManufacturer,
            this.clNonItemID,
            this.clNonItemName,
            this.clNonVendorLot});
            this.dgvOffers.DataSource = this.bsBlGetBindingOffers;
            this.dgvOffers.Location = new System.Drawing.Point(3, 2);
            this.dgvOffers.Name = "dgvOffers";
            this.dgvOffers.RowHeadersVisible = false;
            this.dgvOffers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOffers.Size = new System.Drawing.Size(1221, 389);
            this.dgvOffers.TabIndex = 0;
            this.dgvOffers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOffers_DataBindingComplete);
            this.dgvOffers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOffers_CellContentClick);
            // 
            // bsBlGetBindingOffers
            // 
            this.bsBlGetBindingOffers.DataMember = "BL_Get_BindingOffers";
            this.bsBlGetBindingOffers.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1135, 397);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // taBlGetBindingOffers
            // 
            this.taBlGetBindingOffers.ClearBeforeFill = true;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Text = "Подтвердить";
            this.dataGridViewButtonColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Hold_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Hold_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ID товара";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item";
            this.dataGridViewTextBoxColumn3.HeaderText = "Товар в справочнике";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 128;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Manufacturer_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "ID произв.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 79;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn5.HeaderText = "Производитель в справочнике";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 113;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Vendor_Lot";
            this.dataGridViewTextBoxColumn6.HeaderText = "Серия в справочнике";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 128;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NonManufacturer_ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "ID предл. производителя";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 145;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NonManufacturer";
            this.dataGridViewTextBoxColumn8.HeaderText = "Предл. производитель";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 134;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NonItem_ID";
            this.dataGridViewTextBoxColumn9.HeaderText = "ID предл. товара";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 107;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "NonItem_Name";
            this.dataGridViewTextBoxColumn10.HeaderText = "Прел. товар";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 86;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "NonVendor_Lot";
            this.dataGridViewTextBoxColumn11.HeaderText = "Предл. серия";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 92;
            // 
            // clApprove
            // 
            this.clApprove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clApprove.HeaderText = "";
            this.clApprove.Name = "clApprove";
            this.clApprove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clApprove.Text = "Подтвердить";
            this.clApprove.Width = 80;
            // 
            // clHoldID
            // 
            this.clHoldID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clHoldID.DataPropertyName = "Hold_ID";
            this.clHoldID.HeaderText = "Hold_ID";
            this.clHoldID.Name = "clHoldID";
            this.clHoldID.ReadOnly = true;
            this.clHoldID.Visible = false;
            this.clHoldID.Width = 52;
            // 
            // clItemID
            // 
            this.clItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItemID.DataPropertyName = "Item_ID";
            this.clItemID.HeaderText = "ID товара";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 81;
            // 
            // clItem
            // 
            this.clItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItem.DataPropertyName = "Item";
            this.clItem.HeaderText = "Товар в справочнике";
            this.clItem.Name = "clItem";
            this.clItem.ReadOnly = true;
            this.clItem.Width = 128;
            // 
            // clManufacturerID
            // 
            this.clManufacturerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clManufacturerID.DataPropertyName = "Manufacturer_ID";
            this.clManufacturerID.HeaderText = "ID произв.";
            this.clManufacturerID.Name = "clManufacturerID";
            this.clManufacturerID.ReadOnly = true;
            this.clManufacturerID.Width = 79;
            // 
            // clManufacturer
            // 
            this.clManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clManufacturer.DataPropertyName = "Manufacturer";
            this.clManufacturer.HeaderText = "Производитель в справочнике";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.Width = 113;
            // 
            // clVendorLot
            // 
            this.clVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clVendorLot.DataPropertyName = "Vendor_Lot";
            this.clVendorLot.HeaderText = "Серия в справочнике";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            this.clVendorLot.Width = 128;
            // 
            // clNonManufacturerId
            // 
            this.clNonManufacturerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clNonManufacturerId.DataPropertyName = "NonManufacturer_ID";
            this.clNonManufacturerId.HeaderText = "ID предл. производителя";
            this.clNonManufacturerId.Name = "clNonManufacturerId";
            this.clNonManufacturerId.ReadOnly = true;
            this.clNonManufacturerId.Width = 145;
            // 
            // clNonManufacturer
            // 
            this.clNonManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clNonManufacturer.DataPropertyName = "NonManufacturer";
            this.clNonManufacturer.HeaderText = "Предл. производитель";
            this.clNonManufacturer.Name = "clNonManufacturer";
            this.clNonManufacturer.ReadOnly = true;
            this.clNonManufacturer.Width = 134;
            // 
            // clNonItemID
            // 
            this.clNonItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clNonItemID.DataPropertyName = "NonItem_ID";
            this.clNonItemID.HeaderText = "ID предл. товара";
            this.clNonItemID.Name = "clNonItemID";
            this.clNonItemID.ReadOnly = true;
            this.clNonItemID.Width = 107;
            // 
            // clNonItemName
            // 
            this.clNonItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clNonItemName.DataPropertyName = "NonItem_Name";
            this.clNonItemName.HeaderText = "Прел. товар";
            this.clNonItemName.Name = "clNonItemName";
            this.clNonItemName.ReadOnly = true;
            this.clNonItemName.Width = 86;
            // 
            // clNonVendorLot
            // 
            this.clNonVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clNonVendorLot.DataPropertyName = "NonVendor_Lot";
            this.clNonVendorLot.HeaderText = "Предл. серия";
            this.clNonVendorLot.Name = "clNonVendorLot";
            this.clNonVendorLot.ReadOnly = true;
            this.clNonVendorLot.Width = 92;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "Отклонить";
            // 
            // ItemOffersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1226, 442);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvOffers);
            this.Name = "ItemOffersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Предложения по товарам";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetBindingOffers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOffers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bsBlGetBindingOffers;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.BL_Get_BindingOffersTableAdapter taBlGetBindingOffers;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
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
        private System.Windows.Forms.DataGridViewButtonColumn clApprove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHoldID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNonManufacturerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNonManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNonItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNonItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNonVendorLot;
    }
}