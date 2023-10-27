namespace WMSOffice.Dialogs.Receive
{
    partial class ImposeAdditionalExpensesEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.pnlTotalMargin = new System.Windows.Forms.Panel();
            this.dgvTotal = new System.Windows.Forms.DataGridView();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSumUAHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSumCURDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prAEGetDetailsTotalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.pnlTotalHeader = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tbOrderSumCUR = new System.Windows.Forms.TextBox();
            this.prAEGetDetailsHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblOrderSumCUR = new System.Windows.Forms.Label();
            this.tbOrderSumUAH = new System.Windows.Forms.TextBox();
            this.lblOrderSumUAH = new System.Windows.Forms.Label();
            this.dtpDateGK = new System.Windows.Forms.DateTimePicker();
            this.lblDateGK = new System.Windows.Forms.Label();
            this.tbCurrencyRate = new System.Windows.Forms.TextBox();
            this.lblCurrencyRate = new System.Windows.Forms.Label();
            this.tbCurrency = new System.Windows.Forms.TextBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.tbSupplierName = new System.Windows.Forms.TextBox();
            this.tbSupplierID = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.tbOrderType = new System.Windows.Forms.TextBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.ndsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum_cur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensetypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplieridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prAEGetDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsOperations = new System.Windows.Forms.ToolStrip();
            this.sbAdd = new System.Windows.Forms.ToolStripButton();
            this.sbDelete = new System.Windows.Forms.ToolStripButton();
            this.sbEdit = new System.Windows.Forms.ToolStripButton();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.pr_AE_Get_Details_HeaderTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Details_HeaderTableAdapter();
            this.pr_AE_Get_DetailsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_DetailsTableAdapter();
            this.pr_AE_Get_Details_TotalTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Details_TotalTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetDetailsTotalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.pnlTotalHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetDetailsHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetDetailsBindingSource)).BeginInit();
            this.tsOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(32767, 8);
            this.btnOK.Text = "Применить";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(32767, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 729);
            this.pnlButtons.Size = new System.Drawing.Size(1344, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.pnlTotal);
            this.pnlHeader.Controls.Add(this.tbOrderSumCUR);
            this.pnlHeader.Controls.Add(this.lblOrderSumCUR);
            this.pnlHeader.Controls.Add(this.tbOrderSumUAH);
            this.pnlHeader.Controls.Add(this.lblOrderSumUAH);
            this.pnlHeader.Controls.Add(this.dtpDateGK);
            this.pnlHeader.Controls.Add(this.lblDateGK);
            this.pnlHeader.Controls.Add(this.tbCurrencyRate);
            this.pnlHeader.Controls.Add(this.lblCurrencyRate);
            this.pnlHeader.Controls.Add(this.tbCurrency);
            this.pnlHeader.Controls.Add(this.lblCurrency);
            this.pnlHeader.Controls.Add(this.tbSupplierName);
            this.pnlHeader.Controls.Add(this.tbSupplierID);
            this.pnlHeader.Controls.Add(this.lblSupplier);
            this.pnlHeader.Controls.Add(this.tbWarehouse);
            this.pnlHeader.Controls.Add(this.lblWarehouse);
            this.pnlHeader.Controls.Add(this.tbCompany);
            this.pnlHeader.Controls.Add(this.lblCompany);
            this.pnlHeader.Controls.Add(this.tbOrderType);
            this.pnlHeader.Controls.Add(this.lblOrderType);
            this.pnlHeader.Controls.Add(this.tbOrderNumber);
            this.pnlHeader.Controls.Add(this.lblOrderNumber);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1344, 170);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.pnlTotalMargin);
            this.pnlTotal.Controls.Add(this.dgvTotal);
            this.pnlTotal.Controls.Add(this.pnlTotalHeader);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTotal.Location = new System.Drawing.Point(694, 0);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(650, 170);
            this.pnlTotal.TabIndex = 21;
            // 
            // pnlTotalMargin
            // 
            this.pnlTotalMargin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTotalMargin.Location = new System.Drawing.Point(46, 0);
            this.pnlTotalMargin.Name = "pnlTotalMargin";
            this.pnlTotalMargin.Size = new System.Drawing.Size(604, 9);
            this.pnlTotalMargin.TabIndex = 2;
            // 
            // dgvTotal
            // 
            this.dgvTotal.AllowUserToAddRows = false;
            this.dgvTotal.AllowUserToDeleteRows = false;
            this.dgvTotal.AllowUserToResizeColumns = false;
            this.dgvTotal.AllowUserToResizeRows = false;
            this.dgvTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTotal.AutoGenerateColumns = false;
            this.dgvTotal.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTotal.ColumnHeadersHeight = 20;
            this.dgvTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.totalSumUAHDataGridViewTextBoxColumn,
            this.totalSumCURDataGridViewTextBoxColumn});
            this.dgvTotal.DataSource = this.prAEGetDetailsTotalBindingSource;
            this.dgvTotal.Location = new System.Drawing.Point(46, 9);
            this.dgvTotal.MultiSelect = false;
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.ReadOnly = true;
            this.dgvTotal.RowHeadersVisible = false;
            this.dgvTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotal.Size = new System.Drawing.Size(604, 161);
            this.dgvTotal.TabIndex = 1;
            this.dgvTotal.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTotal_CellFormatting);
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.descriptionDataGridViewTextBoxColumn.Width = 265;
            // 
            // totalSumUAHDataGridViewTextBoxColumn
            // 
            this.totalSumUAHDataGridViewTextBoxColumn.DataPropertyName = "TotalSumUAH";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.totalSumUAHDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.totalSumUAHDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.totalSumUAHDataGridViewTextBoxColumn.Name = "totalSumUAHDataGridViewTextBoxColumn";
            this.totalSumUAHDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalSumUAHDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.totalSumUAHDataGridViewTextBoxColumn.Width = 130;
            // 
            // totalSumCURDataGridViewTextBoxColumn
            // 
            this.totalSumCURDataGridViewTextBoxColumn.DataPropertyName = "TotalSumCUR";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.totalSumCURDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.totalSumCURDataGridViewTextBoxColumn.HeaderText = "Сумма в валюте";
            this.totalSumCURDataGridViewTextBoxColumn.Name = "totalSumCURDataGridViewTextBoxColumn";
            this.totalSumCURDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalSumCURDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.totalSumCURDataGridViewTextBoxColumn.Width = 130;
            // 
            // prAEGetDetailsTotalBindingSource
            // 
            this.prAEGetDetailsTotalBindingSource.DataMember = "pr_AE_Get_Details_Total";
            this.prAEGetDetailsTotalBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlTotalHeader
            // 
            this.pnlTotalHeader.Controls.Add(this.lblTotal);
            this.pnlTotalHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTotalHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTotalHeader.Name = "pnlTotalHeader";
            this.pnlTotalHeader.Size = new System.Drawing.Size(46, 170);
            this.pnlTotalHeader.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(3, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(42, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Итого";
            // 
            // tbOrderSumCUR
            // 
            this.tbOrderSumCUR.BackColor = System.Drawing.SystemColors.Window;
            this.tbOrderSumCUR.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "order_sum_CUR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N4"));
            this.tbOrderSumCUR.Location = new System.Drawing.Point(389, 141);
            this.tbOrderSumCUR.Name = "tbOrderSumCUR";
            this.tbOrderSumCUR.ReadOnly = true;
            this.tbOrderSumCUR.Size = new System.Drawing.Size(100, 20);
            this.tbOrderSumCUR.TabIndex = 20;
            this.tbOrderSumCUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // prAEGetDetailsHeaderBindingSource
            // 
            this.prAEGetDetailsHeaderBindingSource.DataMember = "pr_AE_Get_Details_Header";
            this.prAEGetDetailsHeaderBindingSource.DataSource = this.receive;
            // 
            // lblOrderSumCUR
            // 
            this.lblOrderSumCUR.AutoSize = true;
            this.lblOrderSumCUR.Location = new System.Drawing.Point(254, 145);
            this.lblOrderSumCUR.Name = "lblOrderSumCUR";
            this.lblOrderSumCUR.Size = new System.Drawing.Size(129, 13);
            this.lblOrderSumCUR.TabIndex = 19;
            this.lblOrderSumCUR.Text = "Сумма заказа в валюте";
            // 
            // tbOrderSumUAH
            // 
            this.tbOrderSumUAH.BackColor = System.Drawing.SystemColors.Window;
            this.tbOrderSumUAH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "order_sum_UAH", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N4"));
            this.tbOrderSumUAH.Location = new System.Drawing.Point(389, 115);
            this.tbOrderSumUAH.Name = "tbOrderSumUAH";
            this.tbOrderSumUAH.ReadOnly = true;
            this.tbOrderSumUAH.Size = new System.Drawing.Size(100, 20);
            this.tbOrderSumUAH.TabIndex = 18;
            this.tbOrderSumUAH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOrderSumUAH
            // 
            this.lblOrderSumUAH.AutoSize = true;
            this.lblOrderSumUAH.Location = new System.Drawing.Point(303, 119);
            this.lblOrderSumUAH.Name = "lblOrderSumUAH";
            this.lblOrderSumUAH.Size = new System.Drawing.Size(80, 13);
            this.lblOrderSumUAH.TabIndex = 17;
            this.lblOrderSumUAH.Text = "Сумма заказа";
            // 
            // dtpDateGK
            // 
            this.dtpDateGK.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.prAEGetDetailsHeaderBindingSource, "date_GK", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "d"));
            this.dtpDateGK.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateGK.Location = new System.Drawing.Point(83, 89);
            this.dtpDateGK.Name = "dtpDateGK";
            this.dtpDateGK.Size = new System.Drawing.Size(100, 20);
            this.dtpDateGK.TabIndex = 12;
            this.dtpDateGK.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDateGK_Validating);
            this.dtpDateGK.Enter += new System.EventHandler(this.dtpDateGK_Enter);
            // 
            // lblDateGK
            // 
            this.lblDateGK.AutoSize = true;
            this.lblDateGK.ForeColor = System.Drawing.Color.Green;
            this.lblDateGK.Location = new System.Drawing.Point(28, 93);
            this.lblDateGK.Name = "lblDateGK";
            this.lblDateGK.Size = new System.Drawing.Size(49, 13);
            this.lblDateGK.TabIndex = 11;
            this.lblDateGK.Text = "Дата ГК";
            // 
            // tbCurrencyRate
            // 
            this.tbCurrencyRate.BackColor = System.Drawing.SystemColors.Window;
            this.tbCurrencyRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "currency_rate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N7"));
            this.tbCurrencyRate.Location = new System.Drawing.Point(83, 141);
            this.tbCurrencyRate.Name = "tbCurrencyRate";
            this.tbCurrencyRate.Size = new System.Drawing.Size(100, 20);
            this.tbCurrencyRate.TabIndex = 16;
            this.tbCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCurrencyRate.Enter += new System.EventHandler(this.tbCurrencyRate_Enter);
            this.tbCurrencyRate.Validating += new System.ComponentModel.CancelEventHandler(this.tbCurrencyRate_Validating);
            // 
            // lblCurrencyRate
            // 
            this.lblCurrencyRate.AutoSize = true;
            this.lblCurrencyRate.ForeColor = System.Drawing.Color.Green;
            this.lblCurrencyRate.Location = new System.Drawing.Point(12, 145);
            this.lblCurrencyRate.Name = "lblCurrencyRate";
            this.lblCurrencyRate.Size = new System.Drawing.Size(65, 13);
            this.lblCurrencyRate.TabIndex = 15;
            this.lblCurrencyRate.Text = "Курс валют";
            // 
            // tbCurrency
            // 
            this.tbCurrency.BackColor = System.Drawing.SystemColors.Window;
            this.tbCurrency.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "currency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbCurrency.Location = new System.Drawing.Point(83, 115);
            this.tbCurrency.Name = "tbCurrency";
            this.tbCurrency.ReadOnly = true;
            this.tbCurrency.Size = new System.Drawing.Size(100, 20);
            this.tbCurrency.TabIndex = 14;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(32, 119);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(45, 13);
            this.lblCurrency.TabIndex = 13;
            this.lblCurrency.Text = "Валюта";
            // 
            // tbSupplierName
            // 
            this.tbSupplierName.BackColor = System.Drawing.SystemColors.Window;
            this.tbSupplierName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "supplier_name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbSupplierName.Location = new System.Drawing.Point(189, 62);
            this.tbSupplierName.Name = "tbSupplierName";
            this.tbSupplierName.ReadOnly = true;
            this.tbSupplierName.Size = new System.Drawing.Size(300, 20);
            this.tbSupplierName.TabIndex = 10;
            // 
            // tbSupplierID
            // 
            this.tbSupplierID.BackColor = System.Drawing.SystemColors.Window;
            this.tbSupplierID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "supplier_id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbSupplierID.Location = new System.Drawing.Point(83, 62);
            this.tbSupplierID.Name = "tbSupplierID";
            this.tbSupplierID.ReadOnly = true;
            this.tbSupplierID.Size = new System.Drawing.Size(100, 20);
            this.tbSupplierID.TabIndex = 9;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(12, 66);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(65, 13);
            this.lblSupplier.TabIndex = 8;
            this.lblSupplier.Text = "Поставщик";
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouse.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "warehouse", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.tbWarehouse.Location = new System.Drawing.Point(389, 35);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.ReadOnly = true;
            this.tbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.tbWarehouse.TabIndex = 7;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(345, 39);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(38, 13);
            this.lblWarehouse.TabIndex = 6;
            this.lblWarehouse.Text = "Склад";
            // 
            // tbCompany
            // 
            this.tbCompany.BackColor = System.Drawing.SystemColors.Window;
            this.tbCompany.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "company", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbCompany.Location = new System.Drawing.Point(389, 9);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.ReadOnly = true;
            this.tbCompany.Size = new System.Drawing.Size(100, 20);
            this.tbCompany.TabIndex = 5;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(325, 13);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(58, 13);
            this.lblCompany.TabIndex = 4;
            this.lblCompany.Text = "Компания";
            // 
            // tbOrderType
            // 
            this.tbOrderType.BackColor = System.Drawing.SystemColors.Window;
            this.tbOrderType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "order_type", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbOrderType.Location = new System.Drawing.Point(83, 35);
            this.tbOrderType.Name = "tbOrderType";
            this.tbOrderType.ReadOnly = true;
            this.tbOrderType.Size = new System.Drawing.Size(100, 20);
            this.tbOrderType.TabIndex = 3;
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrderType.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderType.Location = new System.Drawing.Point(12, 39);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(65, 13);
            this.lblOrderType.TabIndex = 2;
            this.lblOrderType.Text = "Тип заказа";
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbOrderNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prAEGetDetailsHeaderBindingSource, "order_number", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbOrderNumber.Location = new System.Drawing.Point(83, 9);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.ReadOnly = true;
            this.tbOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.tbOrderNumber.TabIndex = 1;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrderNumber.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderNumber.Location = new System.Drawing.Point(20, 13);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(57, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "№ заказа";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.Controls.Add(this.dgvDetails);
            this.pnlDetails.Controls.Add(this.tsOperations);
            this.pnlDetails.Location = new System.Drawing.Point(0, 176);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1344, 547);
            this.pnlDetails.TabIndex = 1;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ndsDataGridViewTextBoxColumn,
            this.itemidDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.batchnumberDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.packtypeDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn,
            this.sum_cur,
            this.expensetypeDataGridViewTextBoxColumn,
            this.percent,
            this.priorityDataGridViewTextBoxColumn,
            this.supplieridDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.prAEGetDetailsBindingSource;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 25);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1344, 522);
            this.dgvDetails.TabIndex = 1;
            this.dgvDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellValueChanged);
            this.dgvDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetails_CellFormatting);
            this.dgvDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetails_EditingControlShowing);
            this.dgvDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetails_DataError);
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // ndsDataGridViewTextBoxColumn
            // 
            this.ndsDataGridViewTextBoxColumn.DataPropertyName = "nds";
            this.ndsDataGridViewTextBoxColumn.HeaderText = "НДС";
            this.ndsDataGridViewTextBoxColumn.Name = "ndsDataGridViewTextBoxColumn";
            this.ndsDataGridViewTextBoxColumn.ReadOnly = true;
            this.ndsDataGridViewTextBoxColumn.Width = 45;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Width = 60;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // batchnumberDataGridViewTextBoxColumn
            // 
            this.batchnumberDataGridViewTextBoxColumn.DataPropertyName = "batch_number";
            this.batchnumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.batchnumberDataGridViewTextBoxColumn.Name = "batchnumberDataGridViewTextBoxColumn";
            this.batchnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchnumberDataGridViewTextBoxColumn.Width = 90;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 70;
            // 
            // packtypeDataGridViewTextBoxColumn
            // 
            this.packtypeDataGridViewTextBoxColumn.DataPropertyName = "pack_type";
            this.packtypeDataGridViewTextBoxColumn.HeaderText = "Тип упаковки";
            this.packtypeDataGridViewTextBoxColumn.Name = "packtypeDataGridViewTextBoxColumn";
            this.packtypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.packtypeDataGridViewTextBoxColumn.Width = 60;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена за шт.";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "sum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.sumDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.sumDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            // 
            // sum_cur
            // 
            this.sum_cur.DataPropertyName = "sum_cur";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.sum_cur.DefaultCellStyle = dataGridViewCellStyle5;
            this.sum_cur.HeaderText = "Сумма в валюте";
            this.sum_cur.Name = "sum_cur";
            this.sum_cur.ReadOnly = true;
            // 
            // expensetypeDataGridViewTextBoxColumn
            // 
            this.expensetypeDataGridViewTextBoxColumn.DataPropertyName = "expense_type";
            this.expensetypeDataGridViewTextBoxColumn.HeaderText = "Тип начисления";
            this.expensetypeDataGridViewTextBoxColumn.Name = "expensetypeDataGridViewTextBoxColumn";
            this.expensetypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.expensetypeDataGridViewTextBoxColumn.Width = 200;
            // 
            // percent
            // 
            this.percent.DataPropertyName = "percent";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N7";
            dataGridViewCellStyle6.NullValue = null;
            this.percent.DefaultCellStyle = dataGridViewCellStyle6;
            this.percent.HeaderText = "Процент начисления";
            this.percent.Name = "percent";
            this.percent.ReadOnly = true;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            this.priorityDataGridViewTextBoxColumn.DataPropertyName = "priority";
            this.priorityDataGridViewTextBoxColumn.HeaderText = "Приоритет";
            this.priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            this.priorityDataGridViewTextBoxColumn.ReadOnly = true;
            this.priorityDataGridViewTextBoxColumn.Width = 65;
            // 
            // supplieridDataGridViewTextBoxColumn
            // 
            this.supplieridDataGridViewTextBoxColumn.DataPropertyName = "supplier_id";
            this.supplieridDataGridViewTextBoxColumn.HeaderText = "Код поставщика";
            this.supplieridDataGridViewTextBoxColumn.Name = "supplieridDataGridViewTextBoxColumn";
            this.supplieridDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplieridDataGridViewTextBoxColumn.Width = 75;
            // 
            // prAEGetDetailsBindingSource
            // 
            this.prAEGetDetailsBindingSource.DataMember = "pr_AE_Get_Details";
            this.prAEGetDetailsBindingSource.DataSource = this.receive;
            // 
            // tsOperations
            // 
            this.tsOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAdd,
            this.sbDelete,
            this.sbEdit,
            this.sbRefresh});
            this.tsOperations.Location = new System.Drawing.Point(0, 0);
            this.tsOperations.Name = "tsOperations";
            this.tsOperations.Size = new System.Drawing.Size(1344, 25);
            this.tsOperations.TabIndex = 0;
            this.tsOperations.Text = "toolStrip1";
            // 
            // sbAdd
            // 
            this.sbAdd.Enabled = false;
            this.sbAdd.Image = global::WMSOffice.Properties.Resources.add;
            this.sbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAdd.Name = "sbAdd";
            this.sbAdd.Size = new System.Drawing.Size(79, 22);
            this.sbAdd.Text = "Добавить";
            this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
            // 
            // sbDelete
            // 
            this.sbDelete.Enabled = false;
            this.sbDelete.Image = global::WMSOffice.Properties.Resources.close;
            this.sbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbDelete.Name = "sbDelete";
            this.sbDelete.Size = new System.Drawing.Size(71, 22);
            this.sbDelete.Text = "Удалить";
            this.sbDelete.Click += new System.EventHandler(this.sbDelete_Click);
            // 
            // sbEdit
            // 
            this.sbEdit.Enabled = false;
            this.sbEdit.Image = global::WMSOffice.Properties.Resources.Edit_10x10;
            this.sbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbEdit.Name = "sbEdit";
            this.sbEdit.Size = new System.Drawing.Size(81, 22);
            this.sbEdit.Text = "Изменить";
            this.sbEdit.Click += new System.EventHandler(this.sbEdit_Click);
            // 
            // sbRefresh
            // 
            this.sbRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(81, 22);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // pr_AE_Get_Details_HeaderTableAdapter
            // 
            this.pr_AE_Get_Details_HeaderTableAdapter.ClearBeforeFill = true;
            // 
            // pr_AE_Get_DetailsTableAdapter
            // 
            this.pr_AE_Get_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // pr_AE_Get_Details_TotalTableAdapter
            // 
            this.pr_AE_Get_Details_TotalTableAdapter.ClearBeforeFill = true;
            // 
            // ImposeAdditionalExpensesEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 772);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ImposeAdditionalExpensesEditForm";
            this.Text = "Начисление дополнительных расходов по заказу";
            this.Load += new System.EventHandler(this.ImposeAdditionalExpensesEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImposeAdditionalExpensesEditForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlDetails, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetDetailsTotalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.pnlTotalHeader.ResumeLayout(false);
            this.pnlTotalHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetDetailsHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetDetailsBindingSource)).EndInit();
            this.tsOperations.ResumeLayout(false);
            this.tsOperations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox tbCurrencyRate;
        private System.Windows.Forms.Label lblCurrencyRate;
        private System.Windows.Forms.TextBox tbCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.TextBox tbSupplierName;
        private System.Windows.Forms.TextBox tbSupplierID;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox tbWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox tbOrderType;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.DateTimePicker dtpDateGK;
        private System.Windows.Forms.Label lblDateGK;
        private WMSOffice.Data.Receive receive;
        private System.Windows.Forms.BindingSource prAEGetDetailsHeaderBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Details_HeaderTableAdapter pr_AE_Get_Details_HeaderTableAdapter;
        private System.Windows.Forms.TextBox tbOrderSumUAH;
        private System.Windows.Forms.Label lblOrderSumUAH;
        private System.Windows.Forms.TextBox tbOrderSumCUR;
        private System.Windows.Forms.Label lblOrderSumCUR;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.ToolStrip tsOperations;
        private System.Windows.Forms.ToolStripButton sbAdd;
        private System.Windows.Forms.ToolStripButton sbDelete;
        private System.Windows.Forms.ToolStripButton sbEdit;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource prAEGetDetailsBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_DetailsTableAdapter pr_AE_Get_DetailsTableAdapter;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.DataGridView dgvTotal;
        private System.Windows.Forms.Panel pnlTotalHeader;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.BindingSource prAEGetDetailsTotalBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Details_TotalTableAdapter pr_AE_Get_Details_TotalTableAdapter;
        private System.Windows.Forms.Panel pnlTotalMargin;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSumUAHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSumCURDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum_cur;
        private System.Windows.Forms.DataGridViewTextBoxColumn expensetypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplieridDataGridViewTextBoxColumn;
    }
}