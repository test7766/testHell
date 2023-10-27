namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryFilialEnteredDataForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvEnteredData = new System.Windows.Forms.DataGridView();
            this.lineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiCSTypedData = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.taFiCSTypedData = new WMSOffice.Data.InventoryTableAdapters.FI_CS_Typed_DataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnteredData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiCSTypedData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1012, 231);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvEnteredData
            // 
            this.dgvEnteredData.AllowUserToAddRows = false;
            this.dgvEnteredData.AllowUserToDeleteRows = false;
            this.dgvEnteredData.AllowUserToResizeRows = false;
            this.dgvEnteredData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEnteredData.AutoGenerateColumns = false;
            this.dgvEnteredData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnteredData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineID,
            this.locationID,
            this.itemID,
            this.itemName,
            this.manufacturer,
            this.lotNumber,
            this.amount,
            this.uoM,
            this.sum});
            this.dgvEnteredData.DataSource = this.bsFiCSTypedData;
            this.dgvEnteredData.Location = new System.Drawing.Point(0, 0);
            this.dgvEnteredData.Name = "dgvEnteredData";
            this.dgvEnteredData.ReadOnly = true;
            this.dgvEnteredData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnteredData.Size = new System.Drawing.Size(1099, 221);
            this.dgvEnteredData.TabIndex = 1;
            // 
            // lineID
            // 
            this.lineID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lineID.DataPropertyName = "Line_ID";
            this.lineID.HeaderText = "№ строки";
            this.lineID.Name = "lineID";
            this.lineID.ReadOnly = true;
            this.lineID.Width = 75;
            // 
            // locationID
            // 
            this.locationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationID.DataPropertyName = "Location_ID";
            this.locationID.HeaderText = "Место хранения";
            this.locationID.Name = "locationID";
            this.locationID.ReadOnly = true;
            this.locationID.Width = 105;
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
            this.itemName.HeaderText = "Наименование товара";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 133;
            // 
            // manufacturer
            // 
            this.manufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturer.DataPropertyName = "Manufacturer";
            this.manufacturer.HeaderText = "Производитель";
            this.manufacturer.Name = "manufacturer";
            this.manufacturer.ReadOnly = true;
            this.manufacturer.Width = 111;
            // 
            // lotNumber
            // 
            this.lotNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumber.DataPropertyName = "LotNumber";
            this.lotNumber.HeaderText = "Серия";
            this.lotNumber.Name = "lotNumber";
            this.lotNumber.ReadOnly = true;
            this.lotNumber.Width = 63;
            // 
            // amount
            // 
            this.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amount.DataPropertyName = "Amount";
            this.amount.HeaderText = "Кол-во";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 66;
            // 
            // uoM
            // 
            this.uoM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uoM.DataPropertyName = "UoM";
            this.uoM.HeaderText = "ЕИ";
            this.uoM.Name = "uoM";
            this.uoM.ReadOnly = true;
            this.uoM.Width = 47;
            // 
            // sum
            // 
            this.sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sum.DataPropertyName = "Sum";
            this.sum.HeaderText = "Сумма";
            this.sum.Name = "sum";
            this.sum.ReadOnly = true;
            this.sum.Width = 66;
            // 
            // bsFiCSTypedData
            // 
            this.bsFiCSTypedData.DataMember = "FI_CS_Typed_Data";
            this.bsFiCSTypedData.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taFiCSTypedData
            // 
            this.taFiCSTypedData.ClearBeforeFill = true;
            // 
            // InventoryFilialEnteredDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1099, 262);
            this.Controls.Add(this.dgvEnteredData);
            this.Controls.Add(this.btnClose);
            this.Name = "InventoryFilialEnteredDataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр введенных данных по счетному листу";
            this.Load += new System.EventHandler(this.InventoryFilialEnteredDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnteredData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiCSTypedData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvEnteredData;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn uoM;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.BindingSource bsFiCSTypedData;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FI_CS_Typed_DataTableAdapter taFiCSTypedData;
    }
}