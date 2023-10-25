namespace WMSOffice.Dialogs.Quality
{
    partial class FindPurchaseOrderForm
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
            this.gbPurchaseOrderSearchOptions = new System.Windows.Forms.GroupBox();
            this.cbDateTo = new System.Windows.Forms.CheckBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cbDateFrom = new System.Windows.Forms.CheckBox();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.stbSupplier = new WMSOffice.Controls.SearchTextBox();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.dgvPurchaseOrders = new System.Windows.Forms.DataGridView();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLSearchPurchaseOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sbFindPurchaseOrder = new System.Windows.Forms.ToolStripButton();
            this.bL_Search_Purchase_OrderTableAdapter = new WMSOffice.Data.QualityTableAdapters.BL_Search_Purchase_OrderTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.gbPurchaseOrderSearchOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bLSearchPurchaseOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2931, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3021, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 428);
            this.pnlButtons.Size = new System.Drawing.Size(744, 43);
            this.pnlButtons.TabIndex = 3;
            // 
            // gbPurchaseOrderSearchOptions
            // 
            this.gbPurchaseOrderSearchOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.cbDateTo);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.dtpDateTo);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.dtpDateFrom);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.cbDateFrom);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.tbInvoiceNumber);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.lblInvoiceNumber);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.lblSupplierName);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.lblSupplier);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.stbSupplier);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.tbOrderNumber);
            this.gbPurchaseOrderSearchOptions.Controls.Add(this.lblOrderNumber);
            this.gbPurchaseOrderSearchOptions.Location = new System.Drawing.Point(12, 42);
            this.gbPurchaseOrderSearchOptions.Name = "gbPurchaseOrderSearchOptions";
            this.gbPurchaseOrderSearchOptions.Size = new System.Drawing.Size(720, 160);
            this.gbPurchaseOrderSearchOptions.TabIndex = 1;
            this.gbPurchaseOrderSearchOptions.TabStop = false;
            this.gbPurchaseOrderSearchOptions.Text = "Критерии поиска";
            // 
            // cbDateTo
            // 
            this.cbDateTo.AutoSize = true;
            this.cbDateTo.Location = new System.Drawing.Point(13, 136);
            this.cbDateTo.Name = "cbDateTo";
            this.cbDateTo.Size = new System.Drawing.Size(67, 17);
            this.cbDateTo.TabIndex = 9;
            this.cbDateTo.Text = "Дата по";
            this.cbDateTo.UseVisualStyleBackColor = true;
            this.cbDateTo.CheckedChanged += new System.EventHandler(this.cbPeriod_CheckedChanged);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd.MM.yyyy";
            this.dtpDateTo.Enabled = false;
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(93, 134);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpDateTo.TabIndex = 10;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpDateFrom.Enabled = false;
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(93, 109);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpDateFrom.TabIndex = 8;
            // 
            // cbDateFrom
            // 
            this.cbDateFrom.AutoSize = true;
            this.cbDateFrom.Location = new System.Drawing.Point(13, 111);
            this.cbDateFrom.Name = "cbDateFrom";
            this.cbDateFrom.Size = new System.Drawing.Size(61, 17);
            this.cbDateFrom.TabIndex = 7;
            this.cbDateFrom.Text = "Дата с";
            this.cbDateFrom.UseVisualStyleBackColor = true;
            this.cbDateFrom.CheckedChanged += new System.EventHandler(this.cbPeriod_CheckedChanged);
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.Location = new System.Drawing.Point(93, 49);
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.Size = new System.Drawing.Size(100, 20);
            this.tbInvoiceNumber.TabIndex = 3;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(10, 53);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(63, 13);
            this.lblInvoiceNumber.TabIndex = 2;
            this.lblInvoiceNumber.Text = "№ инвойса";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.BackColor = System.Drawing.SystemColors.Window;
            this.lblSupplierName.Location = new System.Drawing.Point(199, 78);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.ReadOnly = true;
            this.lblSupplierName.Size = new System.Drawing.Size(500, 20);
            this.lblSupplierName.TabIndex = 6;
            this.lblSupplierName.TabStop = false;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(10, 82);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(65, 13);
            this.lblSupplier.TabIndex = 4;
            this.lblSupplier.Text = "Поставщик";
            // 
            // stbSupplier
            // 
            this.stbSupplier.Location = new System.Drawing.Point(93, 78);
            this.stbSupplier.Name = "stbSupplier";
            this.stbSupplier.ReadOnly = false;
            this.stbSupplier.Size = new System.Drawing.Size(100, 20);
            this.stbSupplier.TabIndex = 5;
            this.stbSupplier.UserID = ((long)(0));
            this.stbSupplier.Value = null;
            this.stbSupplier.ValueReferenceQuery = null;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(93, 20);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.tbOrderNumber.TabIndex = 1;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(10, 24);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(57, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "№ заказа";
            // 
            // dgvPurchaseOrders
            // 
            this.dgvPurchaseOrders.AllowUserToAddRows = false;
            this.dgvPurchaseOrders.AllowUserToDeleteRows = false;
            this.dgvPurchaseOrders.AllowUserToResizeRows = false;
            this.dgvPurchaseOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchaseOrders.AutoGenerateColumns = false;
            this.dgvPurchaseOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.warehouseIDDataGridViewTextBoxColumn,
            this.orderNumberDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.supplierIDDataGridViewTextBoxColumn,
            this.supplierNameDataGridViewTextBoxColumn,
            this.invoiceNumberDataGridViewTextBoxColumn});
            this.dgvPurchaseOrders.DataSource = this.bLSearchPurchaseOrderBindingSource;
            this.dgvPurchaseOrders.Location = new System.Drawing.Point(12, 208);
            this.dgvPurchaseOrders.MultiSelect = false;
            this.dgvPurchaseOrders.Name = "dgvPurchaseOrders";
            this.dgvPurchaseOrders.ReadOnly = true;
            this.dgvPurchaseOrders.RowHeadersVisible = false;
            this.dgvPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseOrders.Size = new System.Drawing.Size(720, 214);
            this.dgvPurchaseOrders.TabIndex = 2;
            this.dgvPurchaseOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseOrders_CellDoubleClick);
            // 
            // warehouseIDDataGridViewTextBoxColumn
            // 
            this.warehouseIDDataGridViewTextBoxColumn.DataPropertyName = "WarehouseID";
            this.warehouseIDDataGridViewTextBoxColumn.HeaderText = "Код склада";
            this.warehouseIDDataGridViewTextBoxColumn.Name = "warehouseIDDataGridViewTextBoxColumn";
            this.warehouseIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "OrderNumber";
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            this.orderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumberDataGridViewTextBoxColumn.Width = 60;
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "Дата заказа";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            this.orderDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderDateDataGridViewTextBoxColumn.Width = 70;
            // 
            // supplierIDDataGridViewTextBoxColumn
            // 
            this.supplierIDDataGridViewTextBoxColumn.DataPropertyName = "SupplierID";
            this.supplierIDDataGridViewTextBoxColumn.HeaderText = "Код поставщика";
            this.supplierIDDataGridViewTextBoxColumn.Name = "supplierIDDataGridViewTextBoxColumn";
            this.supplierIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "Наименование поставщика";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierNameDataGridViewTextBoxColumn.Width = 270;
            // 
            // invoiceNumberDataGridViewTextBoxColumn
            // 
            this.invoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber";
            this.invoiceNumberDataGridViewTextBoxColumn.HeaderText = "№ инвойса";
            this.invoiceNumberDataGridViewTextBoxColumn.Name = "invoiceNumberDataGridViewTextBoxColumn";
            this.invoiceNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // bLSearchPurchaseOrderBindingSource
            // 
            this.bLSearchPurchaseOrderBindingSource.DataMember = "BL_Search_Purchase_Order";
            this.bLSearchPurchaseOrderBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbFindPurchaseOrder});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(744, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // sbFindPurchaseOrder
            // 
            this.sbFindPurchaseOrder.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbFindPurchaseOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFindPurchaseOrder.Name = "sbFindPurchaseOrder";
            this.sbFindPurchaseOrder.Size = new System.Drawing.Size(97, 36);
            this.sbFindPurchaseOrder.Text = "Обновить";
            this.sbFindPurchaseOrder.Click += new System.EventHandler(this.sbFindPurchaseOrder_Click);
            // 
            // bL_Search_Purchase_OrderTableAdapter
            // 
            this.bL_Search_Purchase_OrderTableAdapter.ClearBeforeFill = true;
            // 
            // FindPurchaseOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 471);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvPurchaseOrders);
            this.Controls.Add(this.gbPurchaseOrderSearchOptions);
            this.Name = "FindPurchaseOrderForm";
            this.Text = "Поиск заказа на закупку";
            this.Load += new System.EventHandler(this.FindPurchaseOrderForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindPurchaseOrderForm_FormClosing);
            this.Controls.SetChildIndex(this.gbPurchaseOrderSearchOptions, 0);
            this.Controls.SetChildIndex(this.dgvPurchaseOrders, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbPurchaseOrderSearchOptions.ResumeLayout(false);
            this.gbPurchaseOrderSearchOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bLSearchPurchaseOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPurchaseOrderSearchOptions;
        private System.Windows.Forms.DataGridView dgvPurchaseOrders;
        private System.Windows.Forms.TextBox lblSupplierName;
        private System.Windows.Forms.Label lblSupplier;
        private WMSOffice.Controls.SearchTextBox stbSupplier;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.CheckBox cbDateFrom;
        private System.Windows.Forms.CheckBox cbDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton sbFindPurchaseOrder;
        private System.Windows.Forms.BindingSource bLSearchPurchaseOrderBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.BL_Search_Purchase_OrderTableAdapter bL_Search_Purchase_OrderTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNumberDataGridViewTextBoxColumn;
    }
}