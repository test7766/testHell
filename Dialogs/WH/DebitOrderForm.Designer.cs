namespace WMSOffice.Dialogs.WH
{
    partial class DebitOrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tbTotalAmountWithDiscount = new System.Windows.Forms.TextBox();
            this.lblTotalAmountWithDiscount = new System.Windows.Forms.Label();
            this.btnSelectInvoice = new System.Windows.Forms.Button();
            this.tbCurrencyRate = new System.Windows.Forms.TextBox();
            this.lblCurrencyRate = new System.Windows.Forms.Label();
            this.tbTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.stbSupplier = new WMSOffice.Controls.SearchTextBox();
            this.tbSupplier = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.stbOrderType = new WMSOffice.Controls.SearchTextBox();
            this.tbOrderType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesVendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateVendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gTDNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gTDDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new WMSOffice.Controls.DataGridSearchTextBoxColumn();
            this.supplierLotDataGridViewTextBoxColumn = new WMSOffice.Controls.DataGridSearchTextBoxColumn();
            this.lotExpirationDataGridViewTextBoxColumn = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uKTVEDDataGridViewTextBoxColumn = new WMSOffice.Controls.DataGridSearchTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountNDSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountWithNDSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Certificate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualityReview = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderDetailsForDebitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.tsOperations = new System.Windows.Forms.ToolStrip();
            this.btnValidateOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGenerateBatches = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSplitOrderItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteOrderLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditCostPrice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.purchaseOrderDetailsForDebitTableAdapter = new WMSOffice.Data.WHTableAdapters.PurchaseOrderDetailsForDebitTableAdapter();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditGTD = new System.Windows.Forms.ToolStripButton();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderDetailsForDebitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.tsOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(32767, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(32767, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 658);
            this.pnlButtons.Size = new System.Drawing.Size(1284, 43);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.tbTotalAmountWithDiscount);
            this.pnlHeader.Controls.Add(this.lblTotalAmountWithDiscount);
            this.pnlHeader.Controls.Add(this.btnSelectInvoice);
            this.pnlHeader.Controls.Add(this.tbCurrencyRate);
            this.pnlHeader.Controls.Add(this.lblCurrencyRate);
            this.pnlHeader.Controls.Add(this.tbTotalAmount);
            this.pnlHeader.Controls.Add(this.lblTotalAmount);
            this.pnlHeader.Controls.Add(this.stbSupplier);
            this.pnlHeader.Controls.Add(this.tbSupplier);
            this.pnlHeader.Controls.Add(this.lblSupplier);
            this.pnlHeader.Controls.Add(this.dtpInvoiceDate);
            this.pnlHeader.Controls.Add(this.lblInvoiceDate);
            this.pnlHeader.Controls.Add(this.lblInvoiceNumber);
            this.pnlHeader.Controls.Add(this.tbInvoiceNumber);
            this.pnlHeader.Controls.Add(this.lblOrderType);
            this.pnlHeader.Controls.Add(this.lblOrderNumber);
            this.pnlHeader.Controls.Add(this.tbOrderNumber);
            this.pnlHeader.Controls.Add(this.stbOrderType);
            this.pnlHeader.Controls.Add(this.tbOrderType);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1284, 152);
            this.pnlHeader.TabIndex = 101;
            // 
            // tbTotalAmountWithDiscount
            // 
            this.tbTotalAmountWithDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.tbTotalAmountWithDiscount.Location = new System.Drawing.Point(947, 78);
            this.tbTotalAmountWithDiscount.Name = "tbTotalAmountWithDiscount";
            this.tbTotalAmountWithDiscount.ReadOnly = true;
            this.tbTotalAmountWithDiscount.Size = new System.Drawing.Size(110, 20);
            this.tbTotalAmountWithDiscount.TabIndex = 19;
            this.tbTotalAmountWithDiscount.TabStop = false;
            this.tbTotalAmountWithDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmountWithDiscount
            // 
            this.lblTotalAmountWithDiscount.AutoSize = true;
            this.lblTotalAmountWithDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalAmountWithDiscount.ForeColor = System.Drawing.Color.Brown;
            this.lblTotalAmountWithDiscount.Location = new System.Drawing.Point(798, 82);
            this.lblTotalAmountWithDiscount.Name = "lblTotalAmountWithDiscount";
            this.lblTotalAmountWithDiscount.Size = new System.Drawing.Size(143, 13);
            this.lblTotalAmountWithDiscount.TabIndex = 18;
            this.lblTotalAmountWithDiscount.Text = "Сумма заказа со скидкой:";
            // 
            // btnSelectInvoice
            // 
            this.btnSelectInvoice.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnSelectInvoice.Location = new System.Drawing.Point(760, 41);
            this.btnSelectInvoice.Name = "btnSelectInvoice";
            this.btnSelectInvoice.Size = new System.Drawing.Size(20, 20);
            this.btnSelectInvoice.TabIndex = 13;
            this.btnSelectInvoice.UseVisualStyleBackColor = true;
            this.btnSelectInvoice.Click += new System.EventHandler(this.btnSelectInvoice_Click);
            // 
            // tbCurrencyRate
            // 
            this.tbCurrencyRate.BackColor = System.Drawing.SystemColors.Window;
            this.tbCurrencyRate.Location = new System.Drawing.Point(384, 41);
            this.tbCurrencyRate.Name = "tbCurrencyRate";
            this.tbCurrencyRate.ReadOnly = true;
            this.tbCurrencyRate.Size = new System.Drawing.Size(110, 20);
            this.tbCurrencyRate.TabIndex = 10;
            this.tbCurrencyRate.TabStop = false;
            this.tbCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCurrencyRate
            // 
            this.lblCurrencyRate.AutoSize = true;
            this.lblCurrencyRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrencyRate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCurrencyRate.Location = new System.Drawing.Point(295, 45);
            this.lblCurrencyRate.Name = "lblCurrencyRate";
            this.lblCurrencyRate.Size = new System.Drawing.Size(76, 13);
            this.lblCurrencyRate.TabIndex = 9;
            this.lblCurrencyRate.Text = "Курс валюты:";
            // 
            // tbTotalAmount
            // 
            this.tbTotalAmount.BackColor = System.Drawing.SystemColors.Window;
            this.tbTotalAmount.Location = new System.Drawing.Point(947, 41);
            this.tbTotalAmount.Name = "tbTotalAmount";
            this.tbTotalAmount.ReadOnly = true;
            this.tbTotalAmount.Size = new System.Drawing.Size(110, 20);
            this.tbTotalAmount.TabIndex = 17;
            this.tbTotalAmount.TabStop = false;
            this.tbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Brown;
            this.lblTotalAmount.Location = new System.Drawing.Point(858, 45);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(83, 13);
            this.lblTotalAmount.TabIndex = 16;
            this.lblTotalAmount.Text = "Сумма заказа:";
            // 
            // stbSupplier
            // 
            this.stbSupplier.BackColor = System.Drawing.SystemColors.Window;
            this.stbSupplier.Location = new System.Drawing.Point(88, 115);
            this.stbSupplier.Name = "stbSupplier";
            this.stbSupplier.NavigateByValue = false;
            this.stbSupplier.ReadOnly = true;
            this.stbSupplier.Size = new System.Drawing.Size(100, 20);
            this.stbSupplier.TabIndex = 7;
            this.stbSupplier.UserID = ((long)(0));
            this.stbSupplier.Value = null;
            this.stbSupplier.ValueReferenceQuery = null;
            // 
            // tbSupplier
            // 
            this.tbSupplier.BackColor = System.Drawing.SystemColors.Window;
            this.tbSupplier.Location = new System.Drawing.Point(194, 115);
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.ReadOnly = true;
            this.tbSupplier.Size = new System.Drawing.Size(300, 20);
            this.tbSupplier.TabIndex = 8;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(14, 119);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(68, 13);
            this.lblSupplier.TabIndex = 6;
            this.lblSupplier.Text = "Поставщик:";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CustomFormat = "dd.MM.yyyy";
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(650, 78);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.ShowCheckBox = true;
            this.dtpInvoiceDate.Size = new System.Drawing.Size(110, 20);
            this.dtpInvoiceDate.TabIndex = 15;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInvoiceDate.ForeColor = System.Drawing.Color.Blue;
            this.lblInvoiceDate.Location = new System.Drawing.Point(533, 82);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(108, 13);
            this.lblInvoiceDate.TabIndex = 14;
            this.lblInvoiceDate.Text = "Дата счет-фактуры:";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInvoiceNumber.ForeColor = System.Drawing.Color.Blue;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(533, 45);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(93, 13);
            this.lblInvoiceNumber.TabIndex = 11;
            this.lblInvoiceNumber.Text = "№ счет-фактуры:";
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.Location = new System.Drawing.Point(650, 41);
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.Size = new System.Drawing.Size(110, 20);
            this.tbInvoiceNumber.TabIndex = 12;
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Location = new System.Drawing.Point(14, 82);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(68, 13);
            this.lblOrderType.TabIndex = 3;
            this.lblOrderType.Text = "Тип заказа:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(14, 45);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(60, 13);
            this.lblOrderNumber.TabIndex = 1;
            this.lblOrderNumber.Text = "№ заказа:";
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbOrderNumber.Location = new System.Drawing.Point(88, 41);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.ReadOnly = true;
            this.tbOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.tbOrderNumber.TabIndex = 2;
            // 
            // stbOrderType
            // 
            this.stbOrderType.BackColor = System.Drawing.SystemColors.Window;
            this.stbOrderType.Location = new System.Drawing.Point(88, 78);
            this.stbOrderType.Name = "stbOrderType";
            this.stbOrderType.NavigateByValue = false;
            this.stbOrderType.ReadOnly = true;
            this.stbOrderType.Size = new System.Drawing.Size(100, 20);
            this.stbOrderType.TabIndex = 4;
            this.stbOrderType.UserID = ((long)(0));
            this.stbOrderType.Value = null;
            this.stbOrderType.ValueReferenceQuery = null;
            // 
            // tbOrderType
            // 
            this.tbOrderType.BackColor = System.Drawing.SystemColors.Window;
            this.tbOrderType.Location = new System.Drawing.Point(194, 78);
            this.tbOrderType.Name = "tbOrderType";
            this.tbOrderType.ReadOnly = true;
            this.tbOrderType.Size = new System.Drawing.Size(300, 20);
            this.tbOrderType.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(1284, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заголовок";
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvDetails);
            this.pnlContent.Controls.Add(this.tsOperations);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Location = new System.Drawing.Point(0, 152);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1284, 500);
            this.pnlContent.TabIndex = 102;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToOrderColumns = true;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.ItemFullName,
            this.manufacturerDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.lastStatusDataGridViewTextBoxColumn,
            this.currencyCodeDataGridViewTextBoxColumn,
            this.seriesVendorDataGridViewTextBoxColumn,
            this.expDateVendorDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.gTDNumberDataGridViewTextBoxColumn,
            this.gTDDateDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.recipientDataGridViewTextBoxColumn,
            this.branchDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.supplierLotDataGridViewTextBoxColumn,
            this.lotExpirationDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.uKTVEDDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.taxDataGridViewTextBoxColumn,
            this.vatDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.amountNDSDataGridViewTextBoxColumn,
            this.amountWithNDSDataGridViewTextBoxColumn,
            this.Discount,
            this.Certificate,
            this.QualityReview,
            this.Control,
            this.CostPrice});
            this.dgvDetails.DataSource = this.purchaseOrderDetailsForDebitBindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 50);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 25;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1284, 450);
            this.dgvDetails.TabIndex = 3;
            this.dgvDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellValueChanged);
            this.dgvDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetails_CellFormatting);
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetails_EditingControlShowing);
            this.dgvDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetails_DataError);
            this.dgvDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellEnter);
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            this.dgvDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellContentClick);
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.Frozen = true;
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.Frozen = true;
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // ItemFullName
            // 
            this.ItemFullName.DataPropertyName = "ItemFullName";
            this.ItemFullName.HeaderText = "Полное наименование товара";
            this.ItemFullName.Name = "ItemFullName";
            this.ItemFullName.ReadOnly = true;
            this.ItemFullName.Width = 250;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Прозводитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 150;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 50;
            // 
            // lastStatusDataGridViewTextBoxColumn
            // 
            this.lastStatusDataGridViewTextBoxColumn.DataPropertyName = "LastStatus";
            this.lastStatusDataGridViewTextBoxColumn.HeaderText = "Статус пред.";
            this.lastStatusDataGridViewTextBoxColumn.Name = "lastStatusDataGridViewTextBoxColumn";
            this.lastStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastStatusDataGridViewTextBoxColumn.Width = 50;
            // 
            // currencyCodeDataGridViewTextBoxColumn
            // 
            this.currencyCodeDataGridViewTextBoxColumn.DataPropertyName = "CurrencyCode";
            this.currencyCodeDataGridViewTextBoxColumn.HeaderText = "Валюта";
            this.currencyCodeDataGridViewTextBoxColumn.Name = "currencyCodeDataGridViewTextBoxColumn";
            this.currencyCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.currencyCodeDataGridViewTextBoxColumn.Width = 50;
            // 
            // seriesVendorDataGridViewTextBoxColumn
            // 
            this.seriesVendorDataGridViewTextBoxColumn.DataPropertyName = "SeriesVendor";
            this.seriesVendorDataGridViewTextBoxColumn.HeaderText = "Серия поставщика";
            this.seriesVendorDataGridViewTextBoxColumn.Name = "seriesVendorDataGridViewTextBoxColumn";
            this.seriesVendorDataGridViewTextBoxColumn.ReadOnly = true;
            this.seriesVendorDataGridViewTextBoxColumn.Width = 120;
            // 
            // expDateVendorDataGridViewTextBoxColumn
            // 
            this.expDateVendorDataGridViewTextBoxColumn.DataPropertyName = "ExpDateVendor";
            this.expDateVendorDataGridViewTextBoxColumn.HeaderText = "СГ поставщика";
            this.expDateVendorDataGridViewTextBoxColumn.Name = "expDateVendorDataGridViewTextBoxColumn";
            this.expDateVendorDataGridViewTextBoxColumn.ReadOnly = true;
            this.expDateVendorDataGridViewTextBoxColumn.Width = 80;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 70;
            // 
            // gTDNumberDataGridViewTextBoxColumn
            // 
            this.gTDNumberDataGridViewTextBoxColumn.DataPropertyName = "GTDNumber";
            this.gTDNumberDataGridViewTextBoxColumn.HeaderText = "Номер ГТД";
            this.gTDNumberDataGridViewTextBoxColumn.Name = "gTDNumberDataGridViewTextBoxColumn";
            this.gTDNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.gTDNumberDataGridViewTextBoxColumn.Width = 140;
            // 
            // gTDDateDataGridViewTextBoxColumn
            // 
            this.gTDDateDataGridViewTextBoxColumn.DataPropertyName = "GTDDate";
            this.gTDDateDataGridViewTextBoxColumn.HeaderText = "Дата ГТД";
            this.gTDDateDataGridViewTextBoxColumn.Name = "gTDDateDataGridViewTextBoxColumn";
            this.gTDDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.gTDDateDataGridViewTextBoxColumn.Width = 80;
            // 
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            this.uOMDataGridViewTextBoxColumn.ReadOnly = true;
            this.uOMDataGridViewTextBoxColumn.Width = 30;
            // 
            // recipientDataGridViewTextBoxColumn
            // 
            this.recipientDataGridViewTextBoxColumn.DataPropertyName = "Recipient";
            this.recipientDataGridViewTextBoxColumn.HeaderText = "Получатель";
            this.recipientDataGridViewTextBoxColumn.Name = "recipientDataGridViewTextBoxColumn";
            this.recipientDataGridViewTextBoxColumn.ReadOnly = true;
            this.recipientDataGridViewTextBoxColumn.Width = 70;
            // 
            // branchDataGridViewTextBoxColumn
            // 
            this.branchDataGridViewTextBoxColumn.DataPropertyName = "Branch";
            this.branchDataGridViewTextBoxColumn.HeaderText = "Филиал";
            this.branchDataGridViewTextBoxColumn.Name = "branchDataGridViewTextBoxColumn";
            this.branchDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchDataGridViewTextBoxColumn.Width = 50;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Место хранения";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.locationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // supplierLotDataGridViewTextBoxColumn
            // 
            this.supplierLotDataGridViewTextBoxColumn.DataPropertyName = "SupplierLot";
            this.supplierLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.supplierLotDataGridViewTextBoxColumn.Name = "supplierLotDataGridViewTextBoxColumn";
            this.supplierLotDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.supplierLotDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.supplierLotDataGridViewTextBoxColumn.Width = 120;
            // 
            // lotExpirationDataGridViewTextBoxColumn
            // 
            this.lotExpirationDataGridViewTextBoxColumn.DataPropertyName = "LotExpiration";
            this.lotExpirationDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.lotExpirationDataGridViewTextBoxColumn.Name = "lotExpirationDataGridViewTextBoxColumn";
            this.lotExpirationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lotExpirationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // batchDataGridViewTextBoxColumn
            // 
            this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
            this.batchDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uKTVEDDataGridViewTextBoxColumn
            // 
            this.uKTVEDDataGridViewTextBoxColumn.DataPropertyName = "UKTVED";
            this.uKTVEDDataGridViewTextBoxColumn.HeaderText = "УКТВЭД";
            this.uKTVEDDataGridViewTextBoxColumn.Name = "uKTVEDDataGridViewTextBoxColumn";
            this.uKTVEDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.uKTVEDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            this.costDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.costDataGridViewTextBoxColumn.HeaderText = "Цена за шт.";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // taxDataGridViewTextBoxColumn
            // 
            this.taxDataGridViewTextBoxColumn.DataPropertyName = "Tax";
            this.taxDataGridViewTextBoxColumn.HeaderText = "Плательщик";
            this.taxDataGridViewTextBoxColumn.Name = "taxDataGridViewTextBoxColumn";
            this.taxDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxDataGridViewTextBoxColumn.Width = 80;
            // 
            // vatDataGridViewTextBoxColumn
            // 
            this.vatDataGridViewTextBoxColumn.DataPropertyName = "Vat";
            this.vatDataGridViewTextBoxColumn.HeaderText = "НДС";
            this.vatDataGridViewTextBoxColumn.Name = "vatDataGridViewTextBoxColumn";
            this.vatDataGridViewTextBoxColumn.ReadOnly = true;
            this.vatDataGridViewTextBoxColumn.Width = 50;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // amountNDSDataGridViewTextBoxColumn
            // 
            this.amountNDSDataGridViewTextBoxColumn.DataPropertyName = "AmountNDS";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            this.amountNDSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.amountNDSDataGridViewTextBoxColumn.HeaderText = "Сумма НДС";
            this.amountNDSDataGridViewTextBoxColumn.Name = "amountNDSDataGridViewTextBoxColumn";
            this.amountNDSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountWithNDSDataGridViewTextBoxColumn
            // 
            this.amountWithNDSDataGridViewTextBoxColumn.DataPropertyName = "AmountWithNDS";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            this.amountWithNDSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.amountWithNDSDataGridViewTextBoxColumn.HeaderText = "Сумма с НДС";
            this.amountWithNDSDataGridViewTextBoxColumn.Name = "amountWithNDSDataGridViewTextBoxColumn";
            this.amountWithNDSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N4";
            this.Discount.DefaultCellStyle = dataGridViewCellStyle7;
            this.Discount.HeaderText = "Сумма скидки";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // Certificate
            // 
            this.Certificate.DataPropertyName = "Certificate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Certificate.DefaultCellStyle = dataGridViewCellStyle8;
            this.Certificate.HeaderText = "Сертификат";
            this.Certificate.Name = "Certificate";
            this.Certificate.ReadOnly = true;
            this.Certificate.Width = 90;
            // 
            // QualityReview
            // 
            this.QualityReview.DataPropertyName = "QualityReview";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.QualityReview.DefaultCellStyle = dataGridViewCellStyle9;
            this.QualityReview.HeaderText = "Анализ качества";
            this.QualityReview.Name = "QualityReview";
            this.QualityReview.ReadOnly = true;
            this.QualityReview.Width = 90;
            // 
            // Control
            // 
            this.Control.DataPropertyName = "Control";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Control.DefaultCellStyle = dataGridViewCellStyle10;
            this.Control.HeaderText = "Контроль";
            this.Control.Name = "Control";
            this.Control.ReadOnly = true;
            this.Control.Width = 90;
            // 
            // CostPrice
            // 
            this.CostPrice.DataPropertyName = "CostPrice";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CostPrice.DefaultCellStyle = dataGridViewCellStyle11;
            this.CostPrice.HeaderText = "Себестоимость";
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.ReadOnly = true;
            this.CostPrice.Width = 90;
            // 
            // purchaseOrderDetailsForDebitBindingSource
            // 
            this.purchaseOrderDetailsForDebitBindingSource.DataMember = "PurchaseOrderDetailsForDebit";
            this.purchaseOrderDetailsForDebitBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsOperations
            // 
            this.tsOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnValidateOrder,
            this.toolStripSeparator1,
            this.btnGenerateBatches,
            this.toolStripSeparator2,
            this.btnSplitOrderItem,
            this.toolStripSeparator3,
            this.btnDeleteOrderLine,
            this.toolStripSeparator4,
            this.btnEditCostPrice,
            this.toolStripSeparator5,
            this.btnEditGTD,
            this.toolStripSeparator6,
            this.btnExportToExcel});
            this.tsOperations.Location = new System.Drawing.Point(0, 25);
            this.tsOperations.Name = "tsOperations";
            this.tsOperations.Size = new System.Drawing.Size(1284, 25);
            this.tsOperations.TabIndex = 2;
            this.tsOperations.Text = "toolStrip1";
            // 
            // btnValidateOrder
            // 
            this.btnValidateOrder.Image = global::WMSOffice.Properties.Resources.Apply;
            this.btnValidateOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidateOrder.Name = "btnValidateOrder";
            this.btnValidateOrder.Size = new System.Drawing.Size(110, 22);
            this.btnValidateOrder.Text = "Проверить ввод";
            this.btnValidateOrder.Click += new System.EventHandler(this.btnValidateOrder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGenerateBatches
            // 
            this.btnGenerateBatches.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnGenerateBatches.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateBatches.Name = "btnGenerateBatches";
            this.btnGenerateBatches.Size = new System.Drawing.Size(122, 22);
            this.btnGenerateBatches.Text = "Подобрать партии";
            this.btnGenerateBatches.Visible = false;
            this.btnGenerateBatches.Click += new System.EventHandler(this.btnGenerateBatches_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // btnSplitOrderItem
            // 
            this.btnSplitOrderItem.Image = global::WMSOffice.Properties.Resources.split_16;
            this.btnSplitOrderItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplitOrderItem.Name = "btnSplitOrderItem";
            this.btnSplitOrderItem.Size = new System.Drawing.Size(144, 22);
            this.btnSplitOrderItem.Text = "Сплитовка количества";
            this.btnSplitOrderItem.Click += new System.EventHandler(this.btnSplitOrderItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteOrderLine
            // 
            this.btnDeleteOrderLine.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeleteOrderLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteOrderLine.Name = "btnDeleteOrderLine";
            this.btnDeleteOrderLine.Size = new System.Drawing.Size(118, 22);
            this.btnDeleteOrderLine.Text = "Удалить позицию";
            this.btnDeleteOrderLine.Click += new System.EventHandler(this.btnDeleteOrderLine_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditCostPrice
            // 
            this.btnEditCostPrice.Image = global::WMSOffice.Properties.Resources.test;
            this.btnEditCostPrice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditCostPrice.Name = "btnEditCostPrice";
            this.btnEditCostPrice.Size = new System.Drawing.Size(190, 22);
            this.btnEditCostPrice.Text = "Корректировать себестоимость";
            this.btnEditCostPrice.Click += new System.EventHandler(this.btnEditCostPrice_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(106, 22);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(1284, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Детали";
            // 
            // purchaseOrderDetailsForDebitTableAdapter
            // 
            this.purchaseOrderDetailsForDebitTableAdapter.ClearBeforeFill = true;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditGTD
            // 
            this.btnEditGTD.Image = global::WMSOffice.Properties.Resources.Edit_10x10;
            this.btnEditGTD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditGTD.Name = "btnEditGTD";
            this.btnEditGTD.Size = new System.Drawing.Size(135, 22);
            this.btnEditGTD.Text = "Корректировать ГТД";
            this.btnEditGTD.Click += new System.EventHandler(this.btnEditGTD_Click);
            // 
            // DebitOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "DebitOrderForm";
            this.Text = "Приходование заказа";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DebitOrderForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebitOrderForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderDetailsForDebitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.tsOperations.ResumeLayout(false);
            this.tsOperations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip tsOperations;
        private System.Windows.Forms.ToolStripButton btnGenerateBatches;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private WMSOffice.Controls.SearchTextBox stbOrderType;
        private System.Windows.Forms.TextBox tbOrderType;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private WMSOffice.Controls.SearchTextBox stbSupplier;
        private System.Windows.Forms.TextBox tbSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.BindingSource purchaseOrderDetailsForDebitBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.PurchaseOrderDetailsForDebitTableAdapter purchaseOrderDetailsForDebitTableAdapter;
        private System.Windows.Forms.ToolStripButton btnValidateOrder;
        private System.Windows.Forms.ToolStripButton btnSplitOrderItem;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox tbTotalAmount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.TextBox tbCurrencyRate;
        private System.Windows.Forms.Label lblCurrencyRate;
        private System.Windows.Forms.Button btnSelectInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDeleteOrderLine;
        private System.Windows.Forms.ToolStripButton btnEditCostPrice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TextBox tbTotalAmountWithDiscount;
        private System.Windows.Forms.Label lblTotalAmountWithDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriesVendorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateVendorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gTDNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gTDDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private WMSOffice.Controls.DataGridSearchTextBoxColumn locationDataGridViewTextBoxColumn;
        private WMSOffice.Controls.DataGridSearchTextBoxColumn supplierLotDataGridViewTextBoxColumn;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn lotExpirationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private WMSOffice.Controls.DataGridSearchTextBoxColumn uKTVEDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountNDSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountWithNDSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Certificate;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityReview;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostPrice;
        private System.Windows.Forms.ToolStripButton btnEditGTD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}