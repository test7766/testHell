namespace WMSOffice.Window
{
    partial class DebitOrdersWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDebitOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChangeOrderCurrency = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReprintAcceptanceCertificate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreviewAcceptanceCertificate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApproveShipment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReverseOrder = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvOrders = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlExtraSearch = new System.Windows.Forms.Panel();
            this.stbBatch = new WMSOffice.Controls.SearchTextBox();
            this.tbBatch = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.stbItem = new WMSOffice.Controls.SearchTextBox();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.stbOrderType = new WMSOffice.Controls.SearchTextBox();
            this.tbOrderType = new System.Windows.Forms.TextBox();
            this.lblUseExtraSearch = new System.Windows.Forms.Label();
            this.cbUseExtraSearch = new System.Windows.Forms.CheckBox();
            this.tbStatusTo = new System.Windows.Forms.TextBox();
            this.tbStatusFrom = new System.Windows.Forms.TextBox();
            this.stbStatusTo = new WMSOffice.Controls.SearchTextBox();
            this.lblStatusTo = new System.Windows.Forms.Label();
            this.lblStatusFrom = new System.Windows.Forms.Label();
            this.stbStatusFrom = new WMSOffice.Controls.SearchTextBox();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.stbVendor = new WMSOffice.Controls.SearchTextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.toolStripPrinters = new System.Windows.Forms.ToolStrip();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.lblQFilterItem = new System.Windows.Forms.Label();
            this.tbQFilterItem = new System.Windows.Forms.TextBox();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlExtraSearch.SuspendLayout();
            this.toolStripPrinters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnDebitOrder,
            this.toolStripSeparator2,
            this.btnChangeOrderCurrency,
            this.toolStripSeparator3,
            this.btnReprintAcceptanceCertificate,
            this.toolStripSeparator4,
            this.btnPreviewAcceptanceCertificate,
            this.toolStripSeparator6,
            this.btnApproveShipment,
            this.toolStripSeparator5,
            this.btnReverseOrder});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1282, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnDebitOrder
            // 
            this.btnDebitOrder.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnDebitOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDebitOrder.Name = "btnDebitOrder";
            this.btnDebitOrder.Size = new System.Drawing.Size(127, 52);
            this.btnDebitOrder.Text = "Приходовать";
            this.btnDebitOrder.Click += new System.EventHandler(this.btnDebitOrder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnChangeOrderCurrency
            // 
            this.btnChangeOrderCurrency.Image = global::WMSOffice.Properties.Resources.currency_usd;
            this.btnChangeOrderCurrency.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeOrderCurrency.Name = "btnChangeOrderCurrency";
            this.btnChangeOrderCurrency.Size = new System.Drawing.Size(127, 52);
            this.btnChangeOrderCurrency.Text = "Указать курс";
            this.btnChangeOrderCurrency.Click += new System.EventHandler(this.btnChangeOrderCurrency_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnReprintAcceptanceCertificate
            // 
            this.btnReprintAcceptanceCertificate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnReprintAcceptanceCertificate.Image = global::WMSOffice.Properties.Resources.document_certificate;
            this.btnReprintAcceptanceCertificate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReprintAcceptanceCertificate.Name = "btnReprintAcceptanceCertificate";
            this.btnReprintAcceptanceCertificate.Size = new System.Drawing.Size(122, 52);
            this.btnReprintAcceptanceCertificate.Text = "Повторная\nпечать акта";
            this.btnReprintAcceptanceCertificate.Click += new System.EventHandler(this.btnReprintAcceptanceCertificate_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPreviewAcceptanceCertificate
            // 
            this.btnPreviewAcceptanceCertificate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPreviewAcceptanceCertificate.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPreviewAcceptanceCertificate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviewAcceptanceCertificate.Name = "btnPreviewAcceptanceCertificate";
            this.btnPreviewAcceptanceCertificate.Size = new System.Drawing.Size(134, 52);
            this.btnPreviewAcceptanceCertificate.Text = "Просмотр акта";
            this.btnPreviewAcceptanceCertificate.Click += new System.EventHandler(this.btnPreviewAcceptanceCertificate_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // btnApproveShipment
            // 
            this.btnApproveShipment.Image = global::WMSOffice.Properties.Resources.delivery;
            this.btnApproveShipment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproveShipment.Name = "btnApproveShipment";
            this.btnApproveShipment.Size = new System.Drawing.Size(178, 52);
            this.btnApproveShipment.Text = "Подтвердить поставку";
            this.btnApproveShipment.Click += new System.EventHandler(this.btnApproveShipment_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnReverseOrder
            // 
            this.btnReverseOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReverseOrder.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnReverseOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReverseOrder.Name = "btnReverseOrder";
            this.btnReverseOrder.Size = new System.Drawing.Size(132, 52);
            this.btnReverseOrder.Text = "Сторнировать";
            this.btnReverseOrder.Click += new System.EventHandler(this.btnReverseOrder_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.scMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 95);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1282, 293);
            this.pnlMain.TabIndex = 2;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.pnlContent);
            this.scMain.Panel1.Controls.Add(this.pnlSearch);
            this.scMain.Panel1.Controls.Add(this.toolStripPrinters);
            this.scMain.Panel2Collapsed = true;
            this.scMain.Size = new System.Drawing.Size(1282, 293);
            this.scMain.SplitterDistance = 255;
            this.scMain.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvOrders);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 190);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1282, 103);
            this.pnlContent.TabIndex = 3;
            // 
            // xdgvOrders
            // 
            this.xdgvOrders.AllowSort = true;
            this.xdgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvOrders.LargeAmountOfData = false;
            this.xdgvOrders.Location = new System.Drawing.Point(0, 0);
            this.xdgvOrders.Name = "xdgvOrders";
            this.xdgvOrders.RowHeadersVisible = false;
            this.xdgvOrders.Size = new System.Drawing.Size(1282, 103);
            this.xdgvOrders.TabIndex = 0;
            this.xdgvOrders.UserID = ((long)(0));
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.pnlExtraSearch);
            this.pnlSearch.Controls.Add(this.lblUseExtraSearch);
            this.pnlSearch.Controls.Add(this.cbUseExtraSearch);
            this.pnlSearch.Controls.Add(this.tbStatusTo);
            this.pnlSearch.Controls.Add(this.tbStatusFrom);
            this.pnlSearch.Controls.Add(this.stbStatusTo);
            this.pnlSearch.Controls.Add(this.lblStatusTo);
            this.pnlSearch.Controls.Add(this.lblStatusFrom);
            this.pnlSearch.Controls.Add(this.stbStatusFrom);
            this.pnlSearch.Controls.Add(this.tbVendor);
            this.pnlSearch.Controls.Add(this.stbVendor);
            this.pnlSearch.Controls.Add(this.lblVendor);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 25);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1282, 165);
            this.pnlSearch.TabIndex = 0;
            // 
            // pnlExtraSearch
            // 
            this.pnlExtraSearch.Controls.Add(this.lblQFilterItem);
            this.pnlExtraSearch.Controls.Add(this.tbQFilterItem);
            this.pnlExtraSearch.Controls.Add(this.stbBatch);
            this.pnlExtraSearch.Controls.Add(this.tbBatch);
            this.pnlExtraSearch.Controls.Add(this.lblBatch);
            this.pnlExtraSearch.Controls.Add(this.stbItem);
            this.pnlExtraSearch.Controls.Add(this.tbItem);
            this.pnlExtraSearch.Controls.Add(this.lblItem);
            this.pnlExtraSearch.Controls.Add(this.dtpOrderDate);
            this.pnlExtraSearch.Controls.Add(this.lblOrderDate);
            this.pnlExtraSearch.Controls.Add(this.lblOrderType);
            this.pnlExtraSearch.Controls.Add(this.lblOrderNumber);
            this.pnlExtraSearch.Controls.Add(this.tbOrderNumber);
            this.pnlExtraSearch.Controls.Add(this.stbOrderType);
            this.pnlExtraSearch.Controls.Add(this.tbOrderType);
            this.pnlExtraSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlExtraSearch.Location = new System.Drawing.Point(0, 100);
            this.pnlExtraSearch.Name = "pnlExtraSearch";
            this.pnlExtraSearch.Size = new System.Drawing.Size(1282, 65);
            this.pnlExtraSearch.TabIndex = 11;
            // 
            // stbBatch
            // 
            this.stbBatch.Location = new System.Drawing.Point(749, 36);
            this.stbBatch.Name = "stbBatch";
            this.stbBatch.NavigateByValue = false;
            this.stbBatch.ReadOnly = false;
            this.stbBatch.Size = new System.Drawing.Size(100, 20);
            this.stbBatch.TabIndex = 13;
            this.stbBatch.UserID = ((long)(0));
            this.stbBatch.Value = null;
            this.stbBatch.ValueReferenceQuery = null;
            // 
            // tbBatch
            // 
            this.tbBatch.BackColor = System.Drawing.SystemColors.Window;
            this.tbBatch.Location = new System.Drawing.Point(855, 36);
            this.tbBatch.Name = "tbBatch";
            this.tbBatch.ReadOnly = true;
            this.tbBatch.Size = new System.Drawing.Size(412, 20);
            this.tbBatch.TabIndex = 14;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(667, 40);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(47, 13);
            this.lblBatch.TabIndex = 12;
            this.lblBatch.Text = "Партия:";
            // 
            // stbItem
            // 
            this.stbItem.Location = new System.Drawing.Point(114, 36);
            this.stbItem.Name = "stbItem";
            this.stbItem.NavigateByValue = false;
            this.stbItem.ReadOnly = false;
            this.stbItem.Size = new System.Drawing.Size(100, 20);
            this.stbItem.TabIndex = 8;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            // 
            // tbItem
            // 
            this.tbItem.BackColor = System.Drawing.SystemColors.Window;
            this.tbItem.Location = new System.Drawing.Point(383, 36);
            this.tbItem.Name = "tbItem";
            this.tbItem.ReadOnly = true;
            this.tbItem.Size = new System.Drawing.Size(250, 20);
            this.tbItem.TabIndex = 11;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(12, 40);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(67, 13);
            this.lblItem.TabIndex = 7;
            this.lblItem.Text = "Код товара:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Checked = false;
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDate.Location = new System.Drawing.Point(1167, 7);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.ShowCheckBox = true;
            this.dtpOrderDate.Size = new System.Drawing.Size(100, 20);
            this.dtpOrderDate.TabIndex = 6;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(1065, 11);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(75, 13);
            this.lblOrderDate.TabIndex = 5;
            this.lblOrderDate.Text = "Дата заказа:";
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Location = new System.Drawing.Point(12, 11);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(68, 13);
            this.lblOrderType.TabIndex = 0;
            this.lblOrderType.Text = "Тип заказа:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(667, 11);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(60, 13);
            this.lblOrderNumber.TabIndex = 3;
            this.lblOrderNumber.Text = "№ заказа:";
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(749, 7);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.tbOrderNumber.TabIndex = 4;
            // 
            // stbOrderType
            // 
            this.stbOrderType.Location = new System.Drawing.Point(114, 7);
            this.stbOrderType.Name = "stbOrderType";
            this.stbOrderType.NavigateByValue = false;
            this.stbOrderType.ReadOnly = false;
            this.stbOrderType.Size = new System.Drawing.Size(100, 20);
            this.stbOrderType.TabIndex = 1;
            this.stbOrderType.UserID = ((long)(0));
            this.stbOrderType.Value = null;
            this.stbOrderType.ValueReferenceQuery = null;
            // 
            // tbOrderType
            // 
            this.tbOrderType.BackColor = System.Drawing.SystemColors.Window;
            this.tbOrderType.Location = new System.Drawing.Point(221, 7);
            this.tbOrderType.Name = "tbOrderType";
            this.tbOrderType.ReadOnly = true;
            this.tbOrderType.Size = new System.Drawing.Size(412, 20);
            this.tbOrderType.TabIndex = 2;
            // 
            // lblUseExtraSearch
            // 
            this.lblUseExtraSearch.AutoSize = true;
            this.lblUseExtraSearch.Location = new System.Drawing.Point(12, 74);
            this.lblUseExtraSearch.Name = "lblUseExtraSearch";
            this.lblUseExtraSearch.Size = new System.Drawing.Size(90, 13);
            this.lblUseExtraSearch.TabIndex = 9;
            this.lblUseExtraSearch.Text = "Дополнительно:";
            this.lblUseExtraSearch.Click += new System.EventHandler(this.lblUseExtraSearch_Click);
            // 
            // cbUseExtraSearch
            // 
            this.cbUseExtraSearch.AutoSize = true;
            this.cbUseExtraSearch.Location = new System.Drawing.Point(115, 73);
            this.cbUseExtraSearch.Name = "cbUseExtraSearch";
            this.cbUseExtraSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbUseExtraSearch.Size = new System.Drawing.Size(15, 14);
            this.cbUseExtraSearch.TabIndex = 10;
            this.cbUseExtraSearch.UseVisualStyleBackColor = true;
            this.cbUseExtraSearch.CheckedChanged += new System.EventHandler(this.cbUseExtraSearch_CheckedChanged);
            // 
            // tbStatusTo
            // 
            this.tbStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusTo.Location = new System.Drawing.Point(855, 38);
            this.tbStatusTo.Name = "tbStatusTo";
            this.tbStatusTo.ReadOnly = true;
            this.tbStatusTo.Size = new System.Drawing.Size(412, 20);
            this.tbStatusTo.TabIndex = 8;
            // 
            // tbStatusFrom
            // 
            this.tbStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusFrom.Location = new System.Drawing.Point(221, 38);
            this.tbStatusFrom.Name = "tbStatusFrom";
            this.tbStatusFrom.ReadOnly = true;
            this.tbStatusFrom.Size = new System.Drawing.Size(412, 20);
            this.tbStatusFrom.TabIndex = 5;
            // 
            // stbStatusTo
            // 
            this.stbStatusTo.Location = new System.Drawing.Point(749, 38);
            this.stbStatusTo.Name = "stbStatusTo";
            this.stbStatusTo.NavigateByValue = false;
            this.stbStatusTo.ReadOnly = false;
            this.stbStatusTo.Size = new System.Drawing.Size(100, 20);
            this.stbStatusTo.TabIndex = 7;
            this.stbStatusTo.UserID = ((long)(0));
            this.stbStatusTo.Value = null;
            this.stbStatusTo.ValueReferenceQuery = null;
            // 
            // lblStatusTo
            // 
            this.lblStatusTo.AutoSize = true;
            this.lblStatusTo.Location = new System.Drawing.Point(667, 42);
            this.lblStatusTo.Name = "lblStatusTo";
            this.lblStatusTo.Size = new System.Drawing.Size(59, 13);
            this.lblStatusTo.TabIndex = 6;
            this.lblStatusTo.Text = "Статус по:";
            // 
            // lblStatusFrom
            // 
            this.lblStatusFrom.AutoSize = true;
            this.lblStatusFrom.Location = new System.Drawing.Point(13, 42);
            this.lblStatusFrom.Name = "lblStatusFrom";
            this.lblStatusFrom.Size = new System.Drawing.Size(53, 13);
            this.lblStatusFrom.TabIndex = 3;
            this.lblStatusFrom.Text = "Статус с:";
            // 
            // stbStatusFrom
            // 
            this.stbStatusFrom.Location = new System.Drawing.Point(115, 38);
            this.stbStatusFrom.Name = "stbStatusFrom";
            this.stbStatusFrom.NavigateByValue = false;
            this.stbStatusFrom.ReadOnly = false;
            this.stbStatusFrom.Size = new System.Drawing.Size(100, 20);
            this.stbStatusFrom.TabIndex = 4;
            this.stbStatusFrom.UserID = ((long)(0));
            this.stbStatusFrom.Value = null;
            this.stbStatusFrom.ValueReferenceQuery = null;
            // 
            // tbVendor
            // 
            this.tbVendor.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendor.Location = new System.Drawing.Point(221, 9);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.ReadOnly = true;
            this.tbVendor.Size = new System.Drawing.Size(1046, 20);
            this.tbVendor.TabIndex = 2;
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(115, 9);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.NavigateByValue = false;
            this.stbVendor.ReadOnly = false;
            this.stbVendor.Size = new System.Drawing.Size(100, 20);
            this.stbVendor.TabIndex = 1;
            this.stbVendor.UserID = ((long)(0));
            this.stbVendor.Value = null;
            this.stbVendor.ValueReferenceQuery = null;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(13, 13);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "Поставщик:";
            // 
            // toolStripPrinters
            // 
            this.toolStripPrinters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbPrinters,
            this.lblPrinters});
            this.toolStripPrinters.Location = new System.Drawing.Point(0, 0);
            this.toolStripPrinters.Name = "toolStripPrinters";
            this.toolStripPrinters.Size = new System.Drawing.Size(1282, 25);
            this.toolStripPrinters.TabIndex = 2;
            this.toolStripPrinters.Text = "toolStrip1";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(216, 25);
            // 
            // lblPrinters
            // 
            this.lblPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinters.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(54, 22);
            this.lblPrinters.Text = "Принтер:";
            // 
            // lblQFilterItem
            // 
            this.lblQFilterItem.AutoSize = true;
            this.lblQFilterItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblQFilterItem.Location = new System.Drawing.Point(218, 40);
            this.lblQFilterItem.Name = "lblQFilterItem";
            this.lblQFilterItem.Size = new System.Drawing.Size(99, 13);
            this.lblQFilterItem.TabIndex = 9;
            this.lblQFilterItem.Text = "Быстрый фильтр :";
            // 
            // tbQFilterItem
            // 
            this.tbQFilterItem.BackColor = System.Drawing.SystemColors.Info;
            this.tbQFilterItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbQFilterItem.Location = new System.Drawing.Point(327, 36);
            this.tbQFilterItem.Name = "tbQFilterItem";
            this.tbQFilterItem.Size = new System.Drawing.Size(50, 20);
            this.tbQFilterItem.TabIndex = 10;
            this.tbQFilterItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQFilterItem_KeyDown);
            this.tbQFilterItem.Leave += new System.EventHandler(this.tbQFilterItem_Leave);
            // 
            // DebitOrdersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 388);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.Name = "DebitOrdersWindow";
            this.Text = "DebitOrdersWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebitOrdersWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlExtraSearch.ResumeLayout(false);
            this.pnlExtraSearch.PerformLayout();
            this.toolStripPrinters.ResumeLayout(false);
            this.toolStripPrinters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox tbVendor;
        private WMSOffice.Controls.SearchTextBox stbVendor;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvOrders;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.TextBox tbOrderType;
        private WMSOffice.Controls.SearchTextBox stbOrderType;
        private System.Windows.Forms.TextBox tbStatusTo;
        private System.Windows.Forms.TextBox tbStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusTo;
        private System.Windows.Forms.Label lblStatusTo;
        private System.Windows.Forms.Label lblStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusFrom;
        private System.Windows.Forms.Label lblUseExtraSearch;
        private System.Windows.Forms.CheckBox cbUseExtraSearch;
        private System.Windows.Forms.Panel pnlExtraSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDebitOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnChangeOrderCurrency;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnReprintAcceptanceCertificate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnPreviewAcceptanceCertificate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnReverseOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnApproveShipment;
        private System.Windows.Forms.ToolStrip toolStripPrinters;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblItem;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private System.Windows.Forms.TextBox tbItem;
        private WMSOffice.Controls.SearchTextBox stbBatch;
        private System.Windows.Forms.TextBox tbBatch;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.Label lblQFilterItem;
        private System.Windows.Forms.TextBox tbQFilterItem;
    }
}