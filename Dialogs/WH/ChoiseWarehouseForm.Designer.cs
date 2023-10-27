namespace WMSOffice.Dialogs.WH
{
    partial class ChoiseWarehouseForm
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
            this.pnlSearchWarehouse = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWarehouseName = new System.Windows.Forms.TextBox();
            this.dgvWarehouses = new System.Windows.Forms.DataGridView();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.operationWarehousesTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlSearchWarehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationWarehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(202, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(283, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 195);
            this.pnlButtons.Size = new System.Drawing.Size(370, 43);
            // 
            // pnlSearchWarehouse
            // 
            this.pnlSearchWarehouse.Controls.Add(this.label1);
            this.pnlSearchWarehouse.Controls.Add(this.tbWarehouseName);
            this.pnlSearchWarehouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchWarehouse.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchWarehouse.Name = "pnlSearchWarehouse";
            this.pnlSearchWarehouse.Size = new System.Drawing.Size(370, 27);
            this.pnlSearchWarehouse.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование:";
            // 
            // tbWarehouseName
            // 
            this.tbWarehouseName.Location = new System.Drawing.Point(91, 3);
            this.tbWarehouseName.Name = "tbWarehouseName";
            this.tbWarehouseName.Size = new System.Drawing.Size(276, 20);
            this.tbWarehouseName.TabIndex = 0;
            this.tbWarehouseName.TextChanged += new System.EventHandler(this.tbWarehouseName_TextChanged);
            // 
            // dgvWarehouses
            // 
            this.dgvWarehouses.AllowUserToAddRows = false;
            this.dgvWarehouses.AllowUserToDeleteRows = false;
            this.dgvWarehouses.AllowUserToResizeRows = false;
            this.dgvWarehouses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWarehouses.AutoGenerateColumns = false;
            this.dgvWarehouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.warehouseIDDataGridViewTextBoxColumn,
            this.warehouseDataGridViewTextBoxColumn});
            this.dgvWarehouses.DataSource = this.operationWarehousesBindingSource;
            this.dgvWarehouses.Location = new System.Drawing.Point(0, 29);
            this.dgvWarehouses.MultiSelect = false;
            this.dgvWarehouses.Name = "dgvWarehouses";
            this.dgvWarehouses.ReadOnly = true;
            this.dgvWarehouses.RowHeadersVisible = false;
            this.dgvWarehouses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouses.Size = new System.Drawing.Size(370, 160);
            this.dgvWarehouses.TabIndex = 102;
            this.dgvWarehouses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouses_CellDoubleClick);
            // 
            // warehouseIDDataGridViewTextBoxColumn
            // 
            this.warehouseIDDataGridViewTextBoxColumn.DataPropertyName = "Warehouse_ID";
            this.warehouseIDDataGridViewTextBoxColumn.HeaderText = "ID склада";
            this.warehouseIDDataGridViewTextBoxColumn.Name = "warehouseIDDataGridViewTextBoxColumn";
            this.warehouseIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // warehouseDataGridViewTextBoxColumn
            // 
            this.warehouseDataGridViewTextBoxColumn.DataPropertyName = "Warehouse";
            this.warehouseDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.warehouseDataGridViewTextBoxColumn.Name = "warehouseDataGridViewTextBoxColumn";
            this.warehouseDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseDataGridViewTextBoxColumn.Width = 268;
            // 
            // operationWarehousesBindingSource
            // 
            this.operationWarehousesBindingSource.DataMember = "OperationWarehouses";
            this.operationWarehousesBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operationWarehousesTableAdapter
            // 
            this.operationWarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // ChoiseWarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 238);
            this.Controls.Add(this.pnlSearchWarehouse);
            this.Controls.Add(this.dgvWarehouses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ChoiseWarehouseForm";
            this.Text = "Выбор склада";
            this.Load += new System.EventHandler(this.ChoiseWarehouseForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiseWarehouseForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvWarehouses, 0);
            this.Controls.SetChildIndex(this.pnlSearchWarehouse, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlSearchWarehouse.ResumeLayout(false);
            this.pnlSearchWarehouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationWarehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWarehouseName;
        private System.Windows.Forms.DataGridView dgvWarehouses;
        private System.Windows.Forms.BindingSource operationWarehousesBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter operationWarehousesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseDataGridViewTextBoxColumn;
    }
}