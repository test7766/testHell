namespace WMSOffice.Window
{
    partial class AFrameDispatcherWindow
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
            this.tssAlignRemains = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlignRemains = new System.Windows.Forms.ToolStripButton();
            this.tssExport = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.tcViews = new System.Windows.Forms.TabControl();
            this.tpRemains = new System.Windows.Forms.TabPage();
            this.pnlRemains = new System.Windows.Forms.Panel();
            this.scRemains = new System.Windows.Forms.SplitContainer();
            this.pnlRemainsContent = new System.Windows.Forms.Panel();
            this.xdgvRemains = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlRemainsHeader = new System.Windows.Forms.Panel();
            this.lblRemainsHeader = new System.Windows.Forms.Label();
            this.pnlFixPlacesContent = new System.Windows.Forms.Panel();
            this.xdgvFixPlaces = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlFixPlacesHeader = new System.Windows.Forms.Panel();
            this.lblpnlFixPlacesHeader = new System.Windows.Forms.Label();
            this.tpOrders = new System.Windows.Forms.TabPage();
            this.pnlOrders = new System.Windows.Forms.Panel();
            this.scOrders = new System.Windows.Forms.SplitContainer();
            this.pnlOrdersContent = new System.Windows.Forms.Panel();
            this.xdgvOrders = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlOrdersHeader = new System.Windows.Forms.Panel();
            this.lblOrdersHeader = new System.Windows.Forms.Label();
            this.pnlOrderLinesContent = new System.Windows.Forms.Panel();
            this.xdgvOrderLines = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlOrderLinesHeader = new System.Windows.Forms.Panel();
            this.lblOrderLinesHeader = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlViews = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlOrdersFilter = new System.Windows.Forms.Panel();
            this.cbOnlyNotPickedOrders = new System.Windows.Forms.CheckBox();
            this.pnlRemainsFilter = new System.Windows.Forms.Panel();
            this.cbOnlyPositiveRemains = new System.Windows.Forms.CheckBox();
            this.cbOnlyRemainsWithDivergences = new System.Windows.Forms.CheckBox();
            this.pnlWarehouseFilter = new System.Windows.Forms.Panel();
            this.lblWarehouseDesc = new System.Windows.Forms.Label();
            this.stbWarehouseID = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouseID = new System.Windows.Forms.Label();
            this.pnlOrderDateFilter = new System.Windows.Forms.Panel();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.tcViews.SuspendLayout();
            this.tpRemains.SuspendLayout();
            this.pnlRemains.SuspendLayout();
            this.scRemains.Panel1.SuspendLayout();
            this.scRemains.Panel2.SuspendLayout();
            this.scRemains.SuspendLayout();
            this.pnlRemainsContent.SuspendLayout();
            this.pnlRemainsHeader.SuspendLayout();
            this.pnlFixPlacesContent.SuspendLayout();
            this.pnlFixPlacesHeader.SuspendLayout();
            this.tpOrders.SuspendLayout();
            this.pnlOrders.SuspendLayout();
            this.scOrders.Panel1.SuspendLayout();
            this.scOrders.Panel2.SuspendLayout();
            this.scOrders.SuspendLayout();
            this.pnlOrdersContent.SuspendLayout();
            this.pnlOrdersHeader.SuspendLayout();
            this.pnlOrderLinesContent.SuspendLayout();
            this.pnlOrderLinesHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlViews.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlOrdersFilter.SuspendLayout();
            this.pnlRemainsFilter.SuspendLayout();
            this.pnlWarehouseFilter.SuspendLayout();
            this.pnlOrderDateFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssAlignRemains,
            this.btnAlignRemains,
            this.tssExport,
            this.btnExport});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(979, 50);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 47);
            this.btnRefresh.Text = "Обновить...";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tssAlignRemains
            // 
            this.tssAlignRemains.Name = "tssAlignRemains";
            this.tssAlignRemains.Size = new System.Drawing.Size(6, 50);
            // 
            // btnAlignRemains
            // 
            this.btnAlignRemains.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnAlignRemains.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignRemains.Name = "btnAlignRemains";
            this.btnAlignRemains.Size = new System.Drawing.Size(80, 47);
            this.btnAlignRemains.Text = "Выровнять...";
            this.btnAlignRemains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAlignRemains.Click += new System.EventHandler(this.btnAlignRemains_Click);
            // 
            // tssExport
            // 
            this.tssExport.Name = "tssExport";
            this.tssExport.Size = new System.Drawing.Size(6, 50);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 47);
            this.btnExport.Text = "Экспорт...";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tcViews
            // 
            this.tcViews.Controls.Add(this.tpRemains);
            this.tcViews.Controls.Add(this.tpOrders);
            this.tcViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcViews.Location = new System.Drawing.Point(0, 0);
            this.tcViews.Name = "tcViews";
            this.tcViews.SelectedIndex = 0;
            this.tcViews.Size = new System.Drawing.Size(979, 418);
            this.tcViews.TabIndex = 2;
            this.tcViews.SelectedIndexChanged += new System.EventHandler(this.tcViews_SelectedIndexChanged);
            // 
            // tpRemains
            // 
            this.tpRemains.Controls.Add(this.pnlRemains);
            this.tpRemains.Location = new System.Drawing.Point(4, 22);
            this.tpRemains.Name = "tpRemains";
            this.tpRemains.Padding = new System.Windows.Forms.Padding(3);
            this.tpRemains.Size = new System.Drawing.Size(971, 392);
            this.tpRemains.TabIndex = 0;
            this.tpRemains.Text = "Остатки";
            this.tpRemains.UseVisualStyleBackColor = true;
            // 
            // pnlRemains
            // 
            this.pnlRemains.Controls.Add(this.scRemains);
            this.pnlRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRemains.Location = new System.Drawing.Point(3, 3);
            this.pnlRemains.Name = "pnlRemains";
            this.pnlRemains.Size = new System.Drawing.Size(965, 386);
            this.pnlRemains.TabIndex = 0;
            // 
            // scRemains
            // 
            this.scRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scRemains.Location = new System.Drawing.Point(0, 0);
            this.scRemains.Name = "scRemains";
            this.scRemains.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scRemains.Panel1
            // 
            this.scRemains.Panel1.Controls.Add(this.pnlRemainsContent);
            this.scRemains.Panel1.Controls.Add(this.pnlRemainsHeader);
            // 
            // scRemains.Panel2
            // 
            this.scRemains.Panel2.Controls.Add(this.pnlFixPlacesContent);
            this.scRemains.Panel2.Controls.Add(this.pnlFixPlacesHeader);
            this.scRemains.Size = new System.Drawing.Size(965, 386);
            this.scRemains.SplitterDistance = 193;
            this.scRemains.TabIndex = 1;
            // 
            // pnlRemainsContent
            // 
            this.pnlRemainsContent.Controls.Add(this.xdgvRemains);
            this.pnlRemainsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRemainsContent.Location = new System.Drawing.Point(0, 24);
            this.pnlRemainsContent.Name = "pnlRemainsContent";
            this.pnlRemainsContent.Size = new System.Drawing.Size(965, 169);
            this.pnlRemainsContent.TabIndex = 5;
            // 
            // xdgvRemains
            // 
            this.xdgvRemains.AllowSort = true;
            this.xdgvRemains.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvRemains.LargeAmountOfData = false;
            this.xdgvRemains.Location = new System.Drawing.Point(0, 0);
            this.xdgvRemains.Name = "xdgvRemains";
            this.xdgvRemains.RowHeadersVisible = false;
            this.xdgvRemains.Size = new System.Drawing.Size(965, 169);
            this.xdgvRemains.TabIndex = 0;
            this.xdgvRemains.UserID = ((long)(0));
            // 
            // pnlRemainsHeader
            // 
            this.pnlRemainsHeader.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlRemainsHeader.Controls.Add(this.lblRemainsHeader);
            this.pnlRemainsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRemainsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlRemainsHeader.Name = "pnlRemainsHeader";
            this.pnlRemainsHeader.Size = new System.Drawing.Size(965, 24);
            this.pnlRemainsHeader.TabIndex = 4;
            // 
            // lblRemainsHeader
            // 
            this.lblRemainsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRemainsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRemainsHeader.Location = new System.Drawing.Point(0, 0);
            this.lblRemainsHeader.Name = "lblRemainsHeader";
            this.lblRemainsHeader.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblRemainsHeader.Size = new System.Drawing.Size(965, 24);
            this.lblRemainsHeader.TabIndex = 1;
            this.lblRemainsHeader.Text = "Остатки";
            // 
            // pnlFixPlacesContent
            // 
            this.pnlFixPlacesContent.Controls.Add(this.xdgvFixPlaces);
            this.pnlFixPlacesContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFixPlacesContent.Location = new System.Drawing.Point(0, 24);
            this.pnlFixPlacesContent.Name = "pnlFixPlacesContent";
            this.pnlFixPlacesContent.Size = new System.Drawing.Size(965, 165);
            this.pnlFixPlacesContent.TabIndex = 4;
            // 
            // xdgvFixPlaces
            // 
            this.xdgvFixPlaces.AllowSort = true;
            this.xdgvFixPlaces.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvFixPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvFixPlaces.LargeAmountOfData = false;
            this.xdgvFixPlaces.Location = new System.Drawing.Point(0, 0);
            this.xdgvFixPlaces.Name = "xdgvFixPlaces";
            this.xdgvFixPlaces.RowHeadersVisible = false;
            this.xdgvFixPlaces.Size = new System.Drawing.Size(965, 165);
            this.xdgvFixPlaces.TabIndex = 1;
            this.xdgvFixPlaces.UserID = ((long)(0));
            // 
            // pnlFixPlacesHeader
            // 
            this.pnlFixPlacesHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlFixPlacesHeader.Controls.Add(this.lblpnlFixPlacesHeader);
            this.pnlFixPlacesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFixPlacesHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlFixPlacesHeader.Name = "pnlFixPlacesHeader";
            this.pnlFixPlacesHeader.Size = new System.Drawing.Size(965, 24);
            this.pnlFixPlacesHeader.TabIndex = 3;
            // 
            // lblpnlFixPlacesHeader
            // 
            this.lblpnlFixPlacesHeader.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblpnlFixPlacesHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblpnlFixPlacesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblpnlFixPlacesHeader.Location = new System.Drawing.Point(0, 0);
            this.lblpnlFixPlacesHeader.Name = "lblpnlFixPlacesHeader";
            this.lblpnlFixPlacesHeader.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblpnlFixPlacesHeader.Size = new System.Drawing.Size(965, 24);
            this.lblpnlFixPlacesHeader.TabIndex = 1;
            this.lblpnlFixPlacesHeader.Text = "Фикс. места";
            // 
            // tpOrders
            // 
            this.tpOrders.Controls.Add(this.pnlOrders);
            this.tpOrders.Location = new System.Drawing.Point(4, 22);
            this.tpOrders.Name = "tpOrders";
            this.tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrders.Size = new System.Drawing.Size(971, 432);
            this.tpOrders.TabIndex = 1;
            this.tpOrders.Text = "Заказы";
            this.tpOrders.UseVisualStyleBackColor = true;
            // 
            // pnlOrders
            // 
            this.pnlOrders.Controls.Add(this.scOrders);
            this.pnlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrders.Location = new System.Drawing.Point(3, 3);
            this.pnlOrders.Name = "pnlOrders";
            this.pnlOrders.Size = new System.Drawing.Size(965, 426);
            this.pnlOrders.TabIndex = 0;
            // 
            // scOrders
            // 
            this.scOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOrders.Location = new System.Drawing.Point(0, 0);
            this.scOrders.Name = "scOrders";
            this.scOrders.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scOrders.Panel1
            // 
            this.scOrders.Panel1.Controls.Add(this.pnlOrdersContent);
            this.scOrders.Panel1.Controls.Add(this.pnlOrdersHeader);
            // 
            // scOrders.Panel2
            // 
            this.scOrders.Panel2.Controls.Add(this.pnlOrderLinesContent);
            this.scOrders.Panel2.Controls.Add(this.pnlOrderLinesHeader);
            this.scOrders.Size = new System.Drawing.Size(965, 426);
            this.scOrders.SplitterDistance = 213;
            this.scOrders.TabIndex = 2;
            // 
            // pnlOrdersContent
            // 
            this.pnlOrdersContent.Controls.Add(this.xdgvOrders);
            this.pnlOrdersContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrdersContent.Location = new System.Drawing.Point(0, 24);
            this.pnlOrdersContent.Name = "pnlOrdersContent";
            this.pnlOrdersContent.Size = new System.Drawing.Size(965, 189);
            this.pnlOrdersContent.TabIndex = 6;
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
            this.xdgvOrders.Size = new System.Drawing.Size(965, 189);
            this.xdgvOrders.TabIndex = 3;
            this.xdgvOrders.UserID = ((long)(0));
            // 
            // pnlOrdersHeader
            // 
            this.pnlOrdersHeader.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlOrdersHeader.Controls.Add(this.lblOrdersHeader);
            this.pnlOrdersHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrdersHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlOrdersHeader.Name = "pnlOrdersHeader";
            this.pnlOrdersHeader.Size = new System.Drawing.Size(965, 24);
            this.pnlOrdersHeader.TabIndex = 5;
            // 
            // lblOrdersHeader
            // 
            this.lblOrdersHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrdersHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrdersHeader.Location = new System.Drawing.Point(0, 0);
            this.lblOrdersHeader.Name = "lblOrdersHeader";
            this.lblOrdersHeader.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblOrdersHeader.Size = new System.Drawing.Size(965, 24);
            this.lblOrdersHeader.TabIndex = 1;
            this.lblOrdersHeader.Text = "Заказы";
            // 
            // pnlOrderLinesContent
            // 
            this.pnlOrderLinesContent.Controls.Add(this.xdgvOrderLines);
            this.pnlOrderLinesContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderLinesContent.Location = new System.Drawing.Point(0, 24);
            this.pnlOrderLinesContent.Name = "pnlOrderLinesContent";
            this.pnlOrderLinesContent.Size = new System.Drawing.Size(965, 185);
            this.pnlOrderLinesContent.TabIndex = 7;
            // 
            // xdgvOrderLines
            // 
            this.xdgvOrderLines.AllowSort = true;
            this.xdgvOrderLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvOrderLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvOrderLines.LargeAmountOfData = false;
            this.xdgvOrderLines.Location = new System.Drawing.Point(0, 0);
            this.xdgvOrderLines.Name = "xdgvOrderLines";
            this.xdgvOrderLines.RowHeadersVisible = false;
            this.xdgvOrderLines.Size = new System.Drawing.Size(965, 185);
            this.xdgvOrderLines.TabIndex = 1;
            this.xdgvOrderLines.UserID = ((long)(0));
            // 
            // pnlOrderLinesHeader
            // 
            this.pnlOrderLinesHeader.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlOrderLinesHeader.Controls.Add(this.lblOrderLinesHeader);
            this.pnlOrderLinesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderLinesHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderLinesHeader.Name = "pnlOrderLinesHeader";
            this.pnlOrderLinesHeader.Size = new System.Drawing.Size(965, 24);
            this.pnlOrderLinesHeader.TabIndex = 6;
            // 
            // lblOrderLinesHeader
            // 
            this.lblOrderLinesHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderLinesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrderLinesHeader.Location = new System.Drawing.Point(0, 0);
            this.lblOrderLinesHeader.Name = "lblOrderLinesHeader";
            this.lblOrderLinesHeader.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblOrderLinesHeader.Size = new System.Drawing.Size(965, 24);
            this.lblOrderLinesHeader.TabIndex = 1;
            this.lblOrderLinesHeader.Text = "Состав заказа";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlViews);
            this.pnlContent.Controls.Add(this.pnlFilter);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 90);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(979, 498);
            this.pnlContent.TabIndex = 3;
            // 
            // pnlViews
            // 
            this.pnlViews.Controls.Add(this.tcViews);
            this.pnlViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViews.Location = new System.Drawing.Point(0, 80);
            this.pnlViews.Name = "pnlViews";
            this.pnlViews.Size = new System.Drawing.Size(979, 418);
            this.pnlViews.TabIndex = 4;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.pnlOrdersFilter);
            this.pnlFilter.Controls.Add(this.pnlRemainsFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(979, 80);
            this.pnlFilter.TabIndex = 3;
            // 
            // pnlOrdersFilter
            // 
            this.pnlOrdersFilter.BackColor = System.Drawing.Color.Honeydew;
            this.pnlOrdersFilter.Controls.Add(this.cbOnlyNotPickedOrders);
            this.pnlOrdersFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrdersFilter.Location = new System.Drawing.Point(0, 40);
            this.pnlOrdersFilter.Name = "pnlOrdersFilter";
            this.pnlOrdersFilter.Size = new System.Drawing.Size(979, 40);
            this.pnlOrdersFilter.TabIndex = 8;
            // 
            // cbOnlyNotPickedOrders
            // 
            this.cbOnlyNotPickedOrders.AutoSize = true;
            this.cbOnlyNotPickedOrders.Location = new System.Drawing.Point(16, 12);
            this.cbOnlyNotPickedOrders.Name = "cbOnlyNotPickedOrders";
            this.cbOnlyNotPickedOrders.Size = new System.Drawing.Size(175, 17);
            this.cbOnlyNotPickedOrders.TabIndex = 6;
            this.cbOnlyNotPickedOrders.Text = "Только несобранные заказы";
            this.cbOnlyNotPickedOrders.UseVisualStyleBackColor = true;
            this.cbOnlyNotPickedOrders.CheckedChanged += new System.EventHandler(this.cbOnlyNotPickedOrders_CheckedChanged);
            // 
            // pnlRemainsFilter
            // 
            this.pnlRemainsFilter.BackColor = System.Drawing.Color.Honeydew;
            this.pnlRemainsFilter.Controls.Add(this.cbOnlyPositiveRemains);
            this.pnlRemainsFilter.Controls.Add(this.cbOnlyRemainsWithDivergences);
            this.pnlRemainsFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRemainsFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlRemainsFilter.Name = "pnlRemainsFilter";
            this.pnlRemainsFilter.Size = new System.Drawing.Size(979, 40);
            this.pnlRemainsFilter.TabIndex = 7;
            // 
            // cbOnlyPositiveRemains
            // 
            this.cbOnlyPositiveRemains.AutoSize = true;
            this.cbOnlyPositiveRemains.Location = new System.Drawing.Point(16, 12);
            this.cbOnlyPositiveRemains.Name = "cbOnlyPositiveRemains";
            this.cbOnlyPositiveRemains.Size = new System.Drawing.Size(190, 17);
            this.cbOnlyPositiveRemains.TabIndex = 2;
            this.cbOnlyPositiveRemains.Text = "Только положительные остатки";
            this.cbOnlyPositiveRemains.UseVisualStyleBackColor = true;
            this.cbOnlyPositiveRemains.CheckedChanged += new System.EventHandler(this.cbOnlyPositiveRemains_CheckedChanged);
            // 
            // cbOnlyRemainsWithDivergences
            // 
            this.cbOnlyRemainsWithDivergences.AutoSize = true;
            this.cbOnlyRemainsWithDivergences.Location = new System.Drawing.Point(212, 12);
            this.cbOnlyRemainsWithDivergences.Name = "cbOnlyRemainsWithDivergences";
            this.cbOnlyRemainsWithDivergences.Size = new System.Drawing.Size(199, 17);
            this.cbOnlyRemainsWithDivergences.TabIndex = 4;
            this.cbOnlyRemainsWithDivergences.Text = "Только остатки с расхождениями";
            this.cbOnlyRemainsWithDivergences.UseVisualStyleBackColor = true;
            this.cbOnlyRemainsWithDivergences.CheckedChanged += new System.EventHandler(this.cbOnlyRemainsWithDivergences_CheckedChanged);
            // 
            // pnlWarehouseFilter
            // 
            this.pnlWarehouseFilter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlWarehouseFilter.Controls.Add(this.lblWarehouseDesc);
            this.pnlWarehouseFilter.Controls.Add(this.stbWarehouseID);
            this.pnlWarehouseFilter.Controls.Add(this.lblWarehouseID);
            this.pnlWarehouseFilter.Location = new System.Drawing.Point(258, 40);
            this.pnlWarehouseFilter.Name = "pnlWarehouseFilter";
            this.pnlWarehouseFilter.Size = new System.Drawing.Size(180, 48);
            this.pnlWarehouseFilter.TabIndex = 6;
            // 
            // lblWarehouseDesc
            // 
            this.lblWarehouseDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarehouseDesc.AutoSize = true;
            this.lblWarehouseDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseDesc.Location = new System.Drawing.Point(59, 29);
            this.lblWarehouseDesc.Name = "lblWarehouseDesc";
            this.lblWarehouseDesc.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseDesc.TabIndex = 2;
            // 
            // stbWarehouseID
            // 
            this.stbWarehouseID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stbWarehouseID.Location = new System.Drawing.Point(62, 5);
            this.stbWarehouseID.Name = "stbWarehouseID";
            this.stbWarehouseID.NavigateByValue = false;
            this.stbWarehouseID.ReadOnly = false;
            this.stbWarehouseID.Size = new System.Drawing.Size(110, 20);
            this.stbWarehouseID.TabIndex = 1;
            this.stbWarehouseID.UserID = ((long)(0));
            this.stbWarehouseID.Value = null;
            this.stbWarehouseID.ValueReferenceQuery = null;
            // 
            // lblWarehouseID
            // 
            this.lblWarehouseID.AutoSize = true;
            this.lblWarehouseID.Location = new System.Drawing.Point(3, 5);
            this.lblWarehouseID.Name = "lblWarehouseID";
            this.lblWarehouseID.Size = new System.Drawing.Size(45, 26);
            this.lblWarehouseID.TabIndex = 0;
            this.lblWarehouseID.Text = "Склад \r\nотбора:";
            // 
            // pnlOrderDateFilter
            // 
            this.pnlOrderDateFilter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlOrderDateFilter.Controls.Add(this.dtpOrderDate);
            this.pnlOrderDateFilter.Controls.Add(this.lblOrderDate);
            this.pnlOrderDateFilter.Location = new System.Drawing.Point(444, 40);
            this.pnlOrderDateFilter.Name = "pnlOrderDateFilter";
            this.pnlOrderDateFilter.Size = new System.Drawing.Size(180, 48);
            this.pnlOrderDateFilter.TabIndex = 7;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.CustomFormat = "dd.MM.yyyy";
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDate.Location = new System.Drawing.Point(62, 5);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(110, 20);
            this.dtpOrderDate.TabIndex = 1;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(3, 5);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(45, 26);
            this.lblOrderDate.TabIndex = 0;
            this.lblOrderDate.Text = "Дата \r\nотбора:";
            // 
            // AFrameDispatcherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 588);
            this.Controls.Add(this.pnlOrderDateFilter);
            this.Controls.Add(this.pnlWarehouseFilter);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "AFrameDispatcherWindow";
            this.Text = "AFrameDispatcherWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlWarehouseFilter, 0);
            this.Controls.SetChildIndex(this.pnlOrderDateFilter, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tcViews.ResumeLayout(false);
            this.tpRemains.ResumeLayout(false);
            this.pnlRemains.ResumeLayout(false);
            this.scRemains.Panel1.ResumeLayout(false);
            this.scRemains.Panel2.ResumeLayout(false);
            this.scRemains.ResumeLayout(false);
            this.pnlRemainsContent.ResumeLayout(false);
            this.pnlRemainsHeader.ResumeLayout(false);
            this.pnlFixPlacesContent.ResumeLayout(false);
            this.pnlFixPlacesHeader.ResumeLayout(false);
            this.tpOrders.ResumeLayout(false);
            this.pnlOrders.ResumeLayout(false);
            this.scOrders.Panel1.ResumeLayout(false);
            this.scOrders.Panel2.ResumeLayout(false);
            this.scOrders.ResumeLayout(false);
            this.pnlOrdersContent.ResumeLayout(false);
            this.pnlOrdersHeader.ResumeLayout(false);
            this.pnlOrderLinesContent.ResumeLayout(false);
            this.pnlOrderLinesHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlViews.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlOrdersFilter.ResumeLayout(false);
            this.pnlOrdersFilter.PerformLayout();
            this.pnlRemainsFilter.ResumeLayout(false);
            this.pnlRemainsFilter.PerformLayout();
            this.pnlWarehouseFilter.ResumeLayout(false);
            this.pnlWarehouseFilter.PerformLayout();
            this.pnlOrderDateFilter.ResumeLayout(false);
            this.pnlOrderDateFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.TabControl tcViews;
        private System.Windows.Forms.TabPage tpRemains;
        private System.Windows.Forms.TabPage tpOrders;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlRemains;
        private System.Windows.Forms.Panel pnlOrders;
        private System.Windows.Forms.Panel pnlViews;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.CheckBox cbOnlyPositiveRemains;
        private System.Windows.Forms.CheckBox cbOnlyNotPickedOrders;
        private System.Windows.Forms.CheckBox cbOnlyRemainsWithDivergences;
        private System.Windows.Forms.Panel pnlWarehouseFilter;
        private System.Windows.Forms.Label lblWarehouseDesc;
        private WMSOffice.Controls.SearchTextBox stbWarehouseID;
        private System.Windows.Forms.Label lblWarehouseID;
        private System.Windows.Forms.Panel pnlOrderDateFilter;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Panel pnlOrdersFilter;
        private System.Windows.Forms.Panel pnlRemainsFilter;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvRemains;
        private System.Windows.Forms.SplitContainer scOrders;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvOrderLines;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvOrders;
        private System.Windows.Forms.ToolStripSeparator tssExport;
        private System.Windows.Forms.SplitContainer scRemains;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvFixPlaces;
        private System.Windows.Forms.ToolStripSeparator tssAlignRemains;
        private System.Windows.Forms.ToolStripButton btnAlignRemains;
        private System.Windows.Forms.Panel pnlFixPlacesContent;
        private System.Windows.Forms.Panel pnlFixPlacesHeader;
        private System.Windows.Forms.Label lblpnlFixPlacesHeader;
        private System.Windows.Forms.Panel pnlRemainsContent;
        private System.Windows.Forms.Panel pnlRemainsHeader;
        private System.Windows.Forms.Label lblRemainsHeader;
        private System.Windows.Forms.Panel pnlOrdersContent;
        private System.Windows.Forms.Panel pnlOrdersHeader;
        private System.Windows.Forms.Label lblOrdersHeader;
        private System.Windows.Forms.Panel pnlOrderLinesContent;
        private System.Windows.Forms.Panel pnlOrderLinesHeader;
        private System.Windows.Forms.Label lblOrderLinesHeader;
    }
}