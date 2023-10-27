namespace WMSOffice.Dialogs.Complaints
{
    partial class RemainsOfReturns
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
            this.dgvRemains = new System.Windows.Forms.DataGridView();
            this.returnsRemainsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.returnsRemainsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.ReturnsRemainsTableAdapter();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inBxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTemperature = new System.Windows.Forms.DataGridViewImageColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bringOnChargeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnsRemainsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3612, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3702, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 537);
            this.pnlButtons.Size = new System.Drawing.Size(985, 43);
            // 
            // dgvRemains
            // 
            this.dgvRemains.AllowUserToAddRows = false;
            this.dgvRemains.AllowUserToDeleteRows = false;
            this.dgvRemains.AllowUserToResizeRows = false;
            this.dgvRemains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemains.AutoGenerateColumns = false;
            this.dgvRemains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.warehouseIDDataGridViewTextBoxColumn,
            this.locnDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.barCodeDataGridViewTextBoxColumn,
            this.lotDataGridViewTextBoxColumn,
            this.lotnDataGridViewTextBoxColumn,
            this.expDateDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.lotsDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vendorDataGridViewTextBoxColumn,
            this.inBxDataGridViewTextBoxColumn,
            this.dgvcTemperature,
            this.departmentDataGridViewTextBoxColumn,
            this.bringOnChargeDateDataGridViewTextBoxColumn,
            this.expirationDataGridViewTextBoxColumn});
            this.dgvRemains.DataSource = this.returnsRemainsBindingSource;
            this.dgvRemains.Location = new System.Drawing.Point(0, 4);
            this.dgvRemains.MultiSelect = false;
            this.dgvRemains.Name = "dgvRemains";
            this.dgvRemains.ReadOnly = true;
            this.dgvRemains.RowHeadersVisible = false;
            this.dgvRemains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemains.Size = new System.Drawing.Size(985, 535);
            this.dgvRemains.TabIndex = 101;
            this.dgvRemains.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRemains_DataBindingComplete);
            // 
            // returnsRemainsBindingSource
            // 
            this.returnsRemainsBindingSource.DataMember = "ReturnsRemains";
            this.returnsRemainsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // returnsRemainsTableAdapter
            // 
            this.returnsRemainsTableAdapter.ClearBeforeFill = true;
            // 
            // warehouseIDDataGridViewTextBoxColumn
            // 
            this.warehouseIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseIDDataGridViewTextBoxColumn.DataPropertyName = "Warehouse_ID";
            this.warehouseIDDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseIDDataGridViewTextBoxColumn.Name = "warehouseIDDataGridViewTextBoxColumn";
            this.warehouseIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseIDDataGridViewTextBoxColumn.Width = 63;
            // 
            // locnDataGridViewTextBoxColumn
            // 
            this.locnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locnDataGridViewTextBoxColumn.DataPropertyName = "Locn";
            this.locnDataGridViewTextBoxColumn.HeaderText = "Полка";
            this.locnDataGridViewTextBoxColumn.Name = "locnDataGridViewTextBoxColumn";
            this.locnDataGridViewTextBoxColumn.ReadOnly = true;
            this.locnDataGridViewTextBoxColumn.Width = 64;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 89;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 108;
            // 
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            this.uOMDataGridViewTextBoxColumn.ReadOnly = true;
            this.uOMDataGridViewTextBoxColumn.Width = 47;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Штрих-код";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 84;
            // 
            // lotDataGridViewTextBoxColumn
            // 
            this.lotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotDataGridViewTextBoxColumn.DataPropertyName = "Lot";
            this.lotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.lotDataGridViewTextBoxColumn.Name = "lotDataGridViewTextBoxColumn";
            this.lotDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotDataGridViewTextBoxColumn.Width = 63;
            // 
            // lotnDataGridViewTextBoxColumn
            // 
            this.lotnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotnDataGridViewTextBoxColumn.DataPropertyName = "Lotn";
            this.lotnDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotnDataGridViewTextBoxColumn.Name = "lotnDataGridViewTextBoxColumn";
            this.lotnDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotnDataGridViewTextBoxColumn.Width = 69;
            // 
            // expDateDataGridViewTextBoxColumn
            // 
            this.expDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expDateDataGridViewTextBoxColumn.DataPropertyName = "ExpDate";
            this.expDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            this.expDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expDateDataGridViewTextBoxColumn.Width = 97;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 66;
            // 
            // lotsDataGridViewTextBoxColumn
            // 
            this.lotsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotsDataGridViewTextBoxColumn.DataPropertyName = "Lots";
            this.lotsDataGridViewTextBoxColumn.HeaderText = "Блокировка";
            this.lotsDataGridViewTextBoxColumn.Name = "lotsDataGridViewTextBoxColumn";
            this.lotsDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotsDataGridViewTextBoxColumn.Width = 93;
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
            // inBxDataGridViewTextBoxColumn
            // 
            this.inBxDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.inBxDataGridViewTextBoxColumn.DataPropertyName = "InBx";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.inBxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.inBxDataGridViewTextBoxColumn.HeaderText = "В ящике";
            this.inBxDataGridViewTextBoxColumn.Name = "inBxDataGridViewTextBoxColumn";
            this.inBxDataGridViewTextBoxColumn.ReadOnly = true;
            this.inBxDataGridViewTextBoxColumn.Width = 70;
            // 
            // dgvcTemperature
            // 
            this.dgvcTemperature.HeaderText = "Темп.";
            this.dgvcTemperature.Name = "dgvcTemperature";
            this.dgvcTemperature.ReadOnly = true;
            this.dgvcTemperature.Width = 50;
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Отдел";
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.ReadOnly = true;
            this.departmentDataGridViewTextBoxColumn.Width = 63;
            // 
            // bringOnChargeDateDataGridViewTextBoxColumn
            // 
            this.bringOnChargeDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bringOnChargeDateDataGridViewTextBoxColumn.DataPropertyName = "BringOnChargeDate";
            this.bringOnChargeDateDataGridViewTextBoxColumn.HeaderText = "Дата перемещения";
            this.bringOnChargeDateDataGridViewTextBoxColumn.Name = "bringOnChargeDateDataGridViewTextBoxColumn";
            this.bringOnChargeDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.bringOnChargeDateDataGridViewTextBoxColumn.Width = 121;
            // 
            // expirationDataGridViewTextBoxColumn
            // 
            this.expirationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expirationDataGridViewTextBoxColumn.DataPropertyName = "Expiration";
            this.expirationDataGridViewTextBoxColumn.HeaderText = "Просрочка";
            this.expirationDataGridViewTextBoxColumn.Name = "expirationDataGridViewTextBoxColumn";
            this.expirationDataGridViewTextBoxColumn.ReadOnly = true;
            this.expirationDataGridViewTextBoxColumn.Width = 87;
            // 
            // RemainsOfReturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 580);
            this.Controls.Add(this.dgvRemains);
            this.Name = "RemainsOfReturns";
            this.Text = "Остатки на полке";
            this.Controls.SetChildIndex(this.dgvRemains, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnsRemainsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRemains;
        private System.Windows.Forms.BindingSource returnsRemainsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.ReturnsRemainsTableAdapter returnsRemainsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inBxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dgvcTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bringOnChargeDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDataGridViewTextBoxColumn;
    }
}