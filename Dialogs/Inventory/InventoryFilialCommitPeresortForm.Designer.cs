namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryFilialCommitPeresortForm
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
            this.btnCommit = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.dgvPeresorts = new System.Windows.Forms.DataGridView();
            this.checkedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.detailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.templateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFIGetCorrections = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.taFIGetCorrections = new WMSOffice.Data.InventoryTableAdapters.FI_Get_CorrectionsTableAdapter();
            this.lblCtrlF = new System.Windows.Forms.Label();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.btnChangePlace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeresorts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFIGetCorrections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.Location = new System.Drawing.Point(888, 393);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(160, 23);
            this.btnCommit.TabIndex = 300;
            this.btnCommit.Text = "Подтвердить пересорты";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(204, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Поиск (место, код и название товара):";
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(222, 6);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(239, 20);
            this.tbxFilter.TabIndex = 100;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // dgvPeresorts
            // 
            this.dgvPeresorts.AllowUserToAddRows = false;
            this.dgvPeresorts.AllowUserToDeleteRows = false;
            this.dgvPeresorts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPeresorts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeresorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeresorts.AutoGenerateColumns = false;
            this.dgvPeresorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeresorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedFlag,
            this.detailID,
            this.templateID,
            this.lineID,
            this.fT,
            this.transactionNumber,
            this.itemID,
            this.itemName,
            this.lotNumber,
            this.vendorLot,
            this.location,
            this.warehouseID,
            this.unitOfMeasure,
            this.quantity,
            this.costPrice,
            this.costAmount,
            this.reservedQuantity,
            this.statusID,
            this.statusName});
            this.dgvPeresorts.DataSource = this.bsFIGetCorrections;
            this.dgvPeresorts.Location = new System.Drawing.Point(12, 32);
            this.dgvPeresorts.MultiSelect = false;
            this.dgvPeresorts.Name = "dgvPeresorts";
            this.dgvPeresorts.RowHeadersVisible = false;
            this.dgvPeresorts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeresorts.Size = new System.Drawing.Size(1036, 355);
            this.dgvPeresorts.TabIndex = 200;
            this.dgvPeresorts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeresorts_CellContentClick);
            // 
            // checkedFlag
            // 
            this.checkedFlag.DataPropertyName = "CheckedFlag";
            this.checkedFlag.HeaderText = "";
            this.checkedFlag.Name = "checkedFlag";
            this.checkedFlag.Width = 20;
            // 
            // detailID
            // 
            this.detailID.DataPropertyName = "Detail_ID";
            this.detailID.HeaderText = "Detail_ID";
            this.detailID.Name = "detailID";
            this.detailID.ReadOnly = true;
            this.detailID.Visible = false;
            // 
            // templateID
            // 
            this.templateID.DataPropertyName = "Template_ID";
            this.templateID.HeaderText = "Template_ID";
            this.templateID.Name = "templateID";
            this.templateID.ReadOnly = true;
            this.templateID.Visible = false;
            // 
            // lineID
            // 
            this.lineID.DataPropertyName = "Line_ID";
            this.lineID.HeaderText = "Line_ID";
            this.lineID.Name = "lineID";
            this.lineID.ReadOnly = true;
            this.lineID.Visible = false;
            // 
            // fT
            // 
            this.fT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fT.DataPropertyName = "FT";
            this.fT.HeaderText = "FT";
            this.fT.Name = "fT";
            this.fT.ReadOnly = true;
            this.fT.Width = 45;
            // 
            // transactionNumber
            // 
            this.transactionNumber.DataPropertyName = "TransactionNumber";
            this.transactionNumber.HeaderText = "TransactionNumber";
            this.transactionNumber.Name = "transactionNumber";
            this.transactionNumber.ReadOnly = true;
            this.transactionNumber.Visible = false;
            // 
            // itemID
            // 
            this.itemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemID.DataPropertyName = "Item_ID";
            this.itemID.HeaderText = "ID товара";
            this.itemID.Name = "itemID";
            this.itemID.ReadOnly = true;
            this.itemID.Width = 75;
            // 
            // itemName
            // 
            this.itemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemName.DataPropertyName = "Item_Name";
            this.itemName.HeaderText = "Название товара";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 110;
            // 
            // lotNumber
            // 
            this.lotNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumber.DataPropertyName = "Lot_Number";
            this.lotNumber.HeaderText = "Партия";
            this.lotNumber.Name = "lotNumber";
            this.lotNumber.ReadOnly = true;
            this.lotNumber.Width = 69;
            // 
            // vendorLot
            // 
            this.vendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLot.DataPropertyName = "Vendor_Lot";
            this.vendorLot.HeaderText = "Серия";
            this.vendorLot.Name = "vendorLot";
            this.vendorLot.ReadOnly = true;
            this.vendorLot.Visible = false;
            // 
            // location
            // 
            this.location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.location.DataPropertyName = "Location";
            this.location.HeaderText = "Место";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            this.location.Width = 64;
            // 
            // warehouseID
            // 
            this.warehouseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseID.DataPropertyName = "Warehouse_ID";
            this.warehouseID.HeaderText = "Склад";
            this.warehouseID.Name = "warehouseID";
            this.warehouseID.ReadOnly = true;
            this.warehouseID.Width = 63;
            // 
            // unitOfMeasure
            // 
            this.unitOfMeasure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasure.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasure.HeaderText = "ЕИ";
            this.unitOfMeasure.Name = "unitOfMeasure";
            this.unitOfMeasure.ReadOnly = true;
            this.unitOfMeasure.Width = 47;
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantity.DataPropertyName = "Quantity";
            this.quantity.HeaderText = "Кол-во";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 66;
            // 
            // costPrice
            // 
            this.costPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.costPrice.DataPropertyName = "CostPrice";
            this.costPrice.HeaderText = "Цена за шт.";
            this.costPrice.Name = "costPrice";
            this.costPrice.ReadOnly = true;
            this.costPrice.Width = 70;
            // 
            // costAmount
            // 
            this.costAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.costAmount.DataPropertyName = "CostAmount";
            this.costAmount.HeaderText = "Общая ст.";
            this.costAmount.Name = "costAmount";
            this.costAmount.ReadOnly = true;
            this.costAmount.Width = 78;
            // 
            // reservedQuantity
            // 
            this.reservedQuantity.DataPropertyName = "ReservedQuantity";
            this.reservedQuantity.HeaderText = "ReservedQuantity";
            this.reservedQuantity.Name = "reservedQuantity";
            this.reservedQuantity.ReadOnly = true;
            this.reservedQuantity.Visible = false;
            // 
            // statusID
            // 
            this.statusID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusID.DataPropertyName = "Status_ID";
            this.statusID.HeaderText = "Ст.";
            this.statusID.Name = "statusID";
            this.statusID.ReadOnly = true;
            this.statusID.Width = 47;
            // 
            // statusName
            // 
            this.statusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusName.DataPropertyName = "Status_Name";
            this.statusName.HeaderText = "Статус";
            this.statusName.Name = "statusName";
            this.statusName.ReadOnly = true;
            this.statusName.Width = 66;
            // 
            // bsFIGetCorrections
            // 
            this.bsFIGetCorrections.DataMember = "FI_Get_Corrections";
            this.bsFIGetCorrections.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taFIGetCorrections
            // 
            this.taFIGetCorrections.ClearBeforeFill = true;
            // 
            // lblCtrlF
            // 
            this.lblCtrlF.AutoSize = true;
            this.lblCtrlF.Location = new System.Drawing.Point(467, 9);
            this.lblCtrlF.Name = "lblCtrlF";
            this.lblCtrlF.Size = new System.Drawing.Size(40, 13);
            this.lblCtrlF.TabIndex = 401;
            this.lblCtrlF.Text = "(Ctrl+F)";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "CheckedFlag";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Detail_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Detail_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Template_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Template_ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Line_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Line_ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FT";
            this.dataGridViewTextBoxColumn4.HeaderText = "FT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TransactionNumber";
            this.dataGridViewTextBoxColumn5.HeaderText = "TransactionNumber";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn6.HeaderText = "ID товара";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Item_Name";
            this.dataGridViewTextBoxColumn7.HeaderText = "Название товара";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Lot_Number";
            this.dataGridViewTextBoxColumn8.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Vendor_Lot";
            this.dataGridViewTextBoxColumn9.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn10.HeaderText = "Место";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Warehouse_ID";
            this.dataGridViewTextBoxColumn11.HeaderText = "Склад";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "UnitOfMeasure";
            this.dataGridViewTextBoxColumn12.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn13.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "CostPrice";
            this.dataGridViewTextBoxColumn14.HeaderText = "Цена за шт.";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "CostAmount";
            this.dataGridViewTextBoxColumn15.HeaderText = "Общая ст.";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "ReservedQuantity";
            this.dataGridViewTextBoxColumn16.HeaderText = "ReservedQuantity";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Status_ID";
            this.dataGridViewTextBoxColumn17.HeaderText = "Ст.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Status_Name";
            this.dataGridViewTextBoxColumn18.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // btnChangePlace
            // 
            this.btnChangePlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangePlace.Location = new System.Drawing.Point(12, 393);
            this.btnChangePlace.Name = "btnChangePlace";
            this.btnChangePlace.Size = new System.Drawing.Size(75, 23);
            this.btnChangePlace.TabIndex = 402;
            this.btnChangePlace.Text = "Место НА";
            this.btnChangePlace.UseVisualStyleBackColor = true;
            this.btnChangePlace.Click += new System.EventHandler(this.btnChangePlace_Click);
            // 
            // InventoryFilialCommitPeresortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 428);
            this.Controls.Add(this.btnChangePlace);
            this.Controls.Add(this.lblCtrlF);
            this.Controls.Add(this.dgvPeresorts);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnCommit);
            this.KeyPreview = true;
            this.Name = "InventoryFilialCommitPeresortForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подтверждение пересортов";
            this.Load += new System.EventHandler(this.InventoryFilialCommitPeresortForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InventoryFilialEditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeresorts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFIGetCorrections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.DataGridView dgvPeresorts;
        private System.Windows.Forms.BindingSource bsFIGetCorrections;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FI_Get_CorrectionsTableAdapter taFIGetCorrections;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn templateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fT;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn costAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn reservedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
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
        private System.Windows.Forms.Label lblCtrlF;
        private System.Windows.Forms.Button btnChangePlace;
    }
}