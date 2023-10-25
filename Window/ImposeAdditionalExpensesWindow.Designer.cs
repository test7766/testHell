namespace WMSOffice.Window
{
    partial class ImposeAdditionalExpensesWindow
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.sbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbProcessOrder = new System.Windows.Forms.ToolStripButton();
            this.lblOrderTypeName = new System.Windows.Forms.TextBox();
            this.stbOrderType = new WMSOffice.Controls.SearchTextBox();
            this.lblSupplierName = new System.Windows.Forms.TextBox();
            this.lblWarehouseName = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.stbSupplier = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.ordernumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordertypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplieridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppliernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prAEGetMainHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.pr_AE_Get_Main_HeaderTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Main_HeaderTableAdapter();
            this.pnlSearch.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetMainHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tsMain);
            this.pnlSearch.Controls.Add(this.lblOrderTypeName);
            this.pnlSearch.Controls.Add(this.stbOrderType);
            this.pnlSearch.Controls.Add(this.lblSupplierName);
            this.pnlSearch.Controls.Add(this.lblWarehouseName);
            this.pnlSearch.Controls.Add(this.lblSupplier);
            this.pnlSearch.Controls.Add(this.stbSupplier);
            this.pnlSearch.Controls.Add(this.lblWarehouse);
            this.pnlSearch.Controls.Add(this.stbWarehouse);
            this.pnlSearch.Controls.Add(this.lblOrderType);
            this.pnlSearch.Controls.Add(this.tbOrderNumber);
            this.pnlSearch.Controls.Add(this.lblOrderNumber);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 40);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1089, 160);
            this.pnlSearch.TabIndex = 1;
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData,
            this.toolStripSeparator1,
            this.sbProcessOrder});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1089, 55);
            this.tsMain.TabIndex = 11;
            this.tsMain.Text = "toolStrip1";
            // 
            // sbRefreshData
            // 
            this.sbRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshData.Name = "sbRefreshData";
            this.sbRefreshData.Size = new System.Drawing.Size(113, 52);
            this.sbRefreshData.Text = "Обновить";
            this.sbRefreshData.Click += new System.EventHandler(this.sbRefreshData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbProcessOrder
            // 
            this.sbProcessOrder.Enabled = false;
            this.sbProcessOrder.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.sbProcessOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbProcessOrder.Name = "sbProcessOrder";
            this.sbProcessOrder.Size = new System.Drawing.Size(119, 52);
            this.sbProcessOrder.Text = "Обработка\nзаказа";
            this.sbProcessOrder.Click += new System.EventHandler(this.sbProcessOrder_Click);
            // 
            // lblOrderTypeName
            // 
            this.lblOrderTypeName.BackColor = System.Drawing.SystemColors.Window;
            this.lblOrderTypeName.Location = new System.Drawing.Point(202, 84);
            this.lblOrderTypeName.Name = "lblOrderTypeName";
            this.lblOrderTypeName.ReadOnly = true;
            this.lblOrderTypeName.Size = new System.Drawing.Size(500, 20);
            this.lblOrderTypeName.TabIndex = 4;
            this.lblOrderTypeName.TabStop = false;
            // 
            // stbOrderType
            // 
            this.stbOrderType.Location = new System.Drawing.Point(96, 84);
            this.stbOrderType.Name = "stbOrderType";
            this.stbOrderType.Size = new System.Drawing.Size(100, 20);
            this.stbOrderType.TabIndex = 3;
            this.stbOrderType.UserID = ((long)(0));
            this.stbOrderType.Value = null;
            this.stbOrderType.ValueReferenceQuery = null;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.BackColor = System.Drawing.SystemColors.Window;
            this.lblSupplierName.Location = new System.Drawing.Point(202, 132);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.ReadOnly = true;
            this.lblSupplierName.Size = new System.Drawing.Size(500, 20);
            this.lblSupplierName.TabIndex = 10;
            this.lblSupplierName.TabStop = false;
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.BackColor = System.Drawing.SystemColors.Window;
            this.lblWarehouseName.Location = new System.Drawing.Point(202, 108);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.ReadOnly = true;
            this.lblWarehouseName.Size = new System.Drawing.Size(500, 20);
            this.lblWarehouseName.TabIndex = 7;
            this.lblWarehouseName.TabStop = false;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(13, 136);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(65, 13);
            this.lblSupplier.TabIndex = 8;
            this.lblSupplier.Text = "Поставщик";
            // 
            // stbSupplier
            // 
            this.stbSupplier.Location = new System.Drawing.Point(96, 132);
            this.stbSupplier.Name = "stbSupplier";
            this.stbSupplier.Size = new System.Drawing.Size(100, 20);
            this.stbSupplier.TabIndex = 9;
            this.stbSupplier.UserID = ((long)(0));
            this.stbSupplier.Value = null;
            this.stbSupplier.ValueReferenceQuery = null;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(13, 112);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(38, 13);
            this.lblWarehouse.TabIndex = 5;
            this.lblWarehouse.Text = "Склад";
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(96, 108);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouse.TabIndex = 6;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Location = new System.Drawing.Point(13, 88);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(65, 13);
            this.lblOrderType.TabIndex = 2;
            this.lblOrderType.Text = "Тип заказа";
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(96, 60);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.tbOrderNumber.TabIndex = 1;
            this.tbOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(13, 64);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(57, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "№ заказа";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeColumns = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordernumberDataGridViewTextBoxColumn,
            this.ordertypeDataGridViewTextBoxColumn,
            this.warehouseidDataGridViewTextBoxColumn,
            this.supplieridDataGridViewTextBoxColumn,
            this.suppliernameDataGridViewTextBoxColumn,
            this.orderdateDataGridViewTextBoxColumn});
            this.dgvOrders.DataSource = this.prAEGetMainHeaderBindingSource;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 200);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1089, 316);
            this.dgvOrders.TabIndex = 2;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            this.dgvOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrders_CellFormatting);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // ordernumberDataGridViewTextBoxColumn
            // 
            this.ordernumberDataGridViewTextBoxColumn.DataPropertyName = "order_number";
            this.ordernumberDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.ordernumberDataGridViewTextBoxColumn.Name = "ordernumberDataGridViewTextBoxColumn";
            this.ordernumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordernumberDataGridViewTextBoxColumn.Width = 82;
            // 
            // ordertypeDataGridViewTextBoxColumn
            // 
            this.ordertypeDataGridViewTextBoxColumn.DataPropertyName = "order_type";
            this.ordertypeDataGridViewTextBoxColumn.HeaderText = "Тип заказа";
            this.ordertypeDataGridViewTextBoxColumn.Name = "ordertypeDataGridViewTextBoxColumn";
            this.ordertypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordertypeDataGridViewTextBoxColumn.Width = 90;
            // 
            // warehouseidDataGridViewTextBoxColumn
            // 
            this.warehouseidDataGridViewTextBoxColumn.DataPropertyName = "warehouse_id";
            this.warehouseidDataGridViewTextBoxColumn.HeaderText = "Код склада";
            this.warehouseidDataGridViewTextBoxColumn.Name = "warehouseidDataGridViewTextBoxColumn";
            this.warehouseidDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseidDataGridViewTextBoxColumn.Width = 90;
            // 
            // supplieridDataGridViewTextBoxColumn
            // 
            this.supplieridDataGridViewTextBoxColumn.DataPropertyName = "supplier_id";
            this.supplieridDataGridViewTextBoxColumn.HeaderText = "Код поставщика";
            this.supplieridDataGridViewTextBoxColumn.Name = "supplieridDataGridViewTextBoxColumn";
            this.supplieridDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplieridDataGridViewTextBoxColumn.Width = 106;
            // 
            // suppliernameDataGridViewTextBoxColumn
            // 
            this.suppliernameDataGridViewTextBoxColumn.DataPropertyName = "supplier_name";
            this.suppliernameDataGridViewTextBoxColumn.HeaderText = "Наименование поставщика";
            this.suppliernameDataGridViewTextBoxColumn.Name = "suppliernameDataGridViewTextBoxColumn";
            this.suppliernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.suppliernameDataGridViewTextBoxColumn.Width = 158;
            // 
            // orderdateDataGridViewTextBoxColumn
            // 
            this.orderdateDataGridViewTextBoxColumn.DataPropertyName = "order_date";
            this.orderdateDataGridViewTextBoxColumn.HeaderText = "Дата заказа";
            this.orderdateDataGridViewTextBoxColumn.Name = "orderdateDataGridViewTextBoxColumn";
            this.orderdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderdateDataGridViewTextBoxColumn.Width = 89;
            // 
            // prAEGetMainHeaderBindingSource
            // 
            this.prAEGetMainHeaderBindingSource.DataMember = "pr_AE_Get_Main_Header";
            this.prAEGetMainHeaderBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pr_AE_Get_Main_HeaderTableAdapter
            // 
            this.pr_AE_Get_Main_HeaderTableAdapter.ClearBeforeFill = true;
            // 
            // ImposeAdditionalExpensesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 516);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pnlSearch);
            this.Name = "ImposeAdditionalExpensesWindow";
            this.Text = "ImposeAdditionalExpensesWindow";
            this.Load += new System.EventHandler(this.ImposeAdditionalExpensesWindow_Load);
            this.Controls.SetChildIndex(this.pnlSearch, 0);
            this.Controls.SetChildIndex(this.dgvOrders, 0);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetMainHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox lblSupplierName;
        private System.Windows.Forms.TextBox lblWarehouseName;
        private System.Windows.Forms.Label lblSupplier;
        private WMSOffice.Controls.SearchTextBox stbSupplier;
        private System.Windows.Forms.Label lblWarehouse;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.TextBox lblOrderTypeName;
        private WMSOffice.Controls.SearchTextBox stbOrderType;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.BindingSource prAEGetMainHeaderBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Main_HeaderTableAdapter pr_AE_Get_Main_HeaderTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordertypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplieridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbProcessOrder;
    }
}