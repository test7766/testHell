namespace WMSOffice.Window
{
    partial class RemainsWithMovementsDispatcherWindow
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
            this.btnLoadData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpRemains = new System.Windows.Forms.TabPage();
            this.xdgvRemains = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tpMovements = new System.Windows.Forms.TabPage();
            this.xdgvMovements = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cbVendorLotUseAllRemains = new System.Windows.Forms.CheckBox();
            this.cbBatchUseAllRemains = new System.Windows.Forms.CheckBox();
            this.cbLocationUseAllRemains = new System.Windows.Forms.CheckBox();
            this.lblQFilterItem = new System.Windows.Forms.Label();
            this.tbQFilterItem = new System.Windows.Forms.TextBox();
            this.tbBatchNumber = new System.Windows.Forms.TextBox();
            this.stbBatchNumber = new WMSOffice.Controls.SearchTextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.stbVendorLot = new WMSOffice.Controls.SearchTextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.stbLocation = new WMSOffice.Controls.SearchTextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.stbItem = new WMSOffice.Controls.SearchTextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.tbBusinessUnitTo = new System.Windows.Forms.TextBox();
            this.stbBusinessUnitTo = new WMSOffice.Controls.SearchTextBox();
            this.lblBusinessUnitTo = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.tbBusinessUnitFrom = new System.Windows.Forms.TextBox();
            this.stbBusinessUnitFrom = new WMSOffice.Controls.SearchTextBox();
            this.lblBusinessUnitFrom = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpRemains.SuspendLayout();
            this.tpMovements.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadData,
            this.toolStripSeparator1,
            this.btnExportToExcel});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1202, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnLoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(109, 52);
            this.btnLoadData.Text = "Обновить";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(138, 52);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.pnlFilter);
            this.pnlMainContent.Controls.Add(this.pnlContent);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 95);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1202, 293);
            this.pnlMainContent.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tcMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1202, 293);
            this.pnlContent.TabIndex = 1;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpRemains);
            this.tcMain.Controls.Add(this.tpMovements);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1202, 293);
            this.tcMain.TabIndex = 0;
            this.tcMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcMain_DrawItem);
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tpRemains
            // 
            this.tpRemains.Controls.Add(this.xdgvRemains);
            this.tpRemains.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tpRemains.Location = new System.Drawing.Point(4, 22);
            this.tpRemains.Name = "tpRemains";
            this.tpRemains.Padding = new System.Windows.Forms.Padding(3);
            this.tpRemains.Size = new System.Drawing.Size(1194, 267);
            this.tpRemains.TabIndex = 0;
            this.tpRemains.Text = "Остатки";
            this.tpRemains.UseVisualStyleBackColor = true;
            // 
            // xdgvRemains
            // 
            this.xdgvRemains.AllowSort = true;
            this.xdgvRemains.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvRemains.LargeAmountOfData = false;
            this.xdgvRemains.Location = new System.Drawing.Point(3, 3);
            this.xdgvRemains.Name = "xdgvRemains";
            this.xdgvRemains.RowHeadersVisible = false;
            this.xdgvRemains.Size = new System.Drawing.Size(1188, 261);
            this.xdgvRemains.TabIndex = 0;
            this.xdgvRemains.UserID = ((long)(0));
            // 
            // tpMovements
            // 
            this.tpMovements.Controls.Add(this.xdgvMovements);
            this.tpMovements.Location = new System.Drawing.Point(4, 22);
            this.tpMovements.Name = "tpMovements";
            this.tpMovements.Padding = new System.Windows.Forms.Padding(3);
            this.tpMovements.Size = new System.Drawing.Size(1194, 142);
            this.tpMovements.TabIndex = 1;
            this.tpMovements.Text = "Движение";
            this.tpMovements.UseVisualStyleBackColor = true;
            // 
            // xdgvMovements
            // 
            this.xdgvMovements.AllowSort = true;
            this.xdgvMovements.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvMovements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvMovements.LargeAmountOfData = false;
            this.xdgvMovements.Location = new System.Drawing.Point(3, 3);
            this.xdgvMovements.Name = "xdgvMovements";
            this.xdgvMovements.RowHeadersVisible = false;
            this.xdgvMovements.Size = new System.Drawing.Size(1188, 136);
            this.xdgvMovements.TabIndex = 1;
            this.xdgvMovements.UserID = ((long)(0));
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.cbVendorLotUseAllRemains);
            this.pnlFilter.Controls.Add(this.cbBatchUseAllRemains);
            this.pnlFilter.Controls.Add(this.cbLocationUseAllRemains);
            this.pnlFilter.Controls.Add(this.lblQFilterItem);
            this.pnlFilter.Controls.Add(this.tbQFilterItem);
            this.pnlFilter.Controls.Add(this.tbBatchNumber);
            this.pnlFilter.Controls.Add(this.stbBatchNumber);
            this.pnlFilter.Controls.Add(this.lblBatchNumber);
            this.pnlFilter.Controls.Add(this.tbVendorLot);
            this.pnlFilter.Controls.Add(this.stbVendorLot);
            this.pnlFilter.Controls.Add(this.lblVendorLot);
            this.pnlFilter.Controls.Add(this.tbLocation);
            this.pnlFilter.Controls.Add(this.stbLocation);
            this.pnlFilter.Controls.Add(this.lblLocation);
            this.pnlFilter.Controls.Add(this.lblDateTo);
            this.pnlFilter.Controls.Add(this.dtpDateTo);
            this.pnlFilter.Controls.Add(this.lblDateFrom);
            this.pnlFilter.Controls.Add(this.tbItem);
            this.pnlFilter.Controls.Add(this.stbItem);
            this.pnlFilter.Controls.Add(this.lblItem);
            this.pnlFilter.Controls.Add(this.tbBusinessUnitTo);
            this.pnlFilter.Controls.Add(this.stbBusinessUnitTo);
            this.pnlFilter.Controls.Add(this.lblBusinessUnitTo);
            this.pnlFilter.Controls.Add(this.dtpDateFrom);
            this.pnlFilter.Controls.Add(this.tbBusinessUnitFrom);
            this.pnlFilter.Controls.Add(this.stbBusinessUnitFrom);
            this.pnlFilter.Controls.Add(this.lblBusinessUnitFrom);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1202, 125);
            this.pnlFilter.TabIndex = 0;
            // 
            // cbVendorLotUseAllRemains
            // 
            this.cbVendorLotUseAllRemains.AutoSize = true;
            this.cbVendorLotUseAllRemains.Location = new System.Drawing.Point(794, 37);
            this.cbVendorLotUseAllRemains.Name = "cbVendorLotUseAllRemains";
            this.cbVendorLotUseAllRemains.Size = new System.Drawing.Size(162, 17);
            this.cbVendorLotUseAllRemains.TabIndex = 13;
            this.cbVendorLotUseAllRemains.Text = "Показать нулевой остаток";
            this.cbVendorLotUseAllRemains.UseVisualStyleBackColor = true;
            this.cbVendorLotUseAllRemains.CheckedChanged += new System.EventHandler(this.cbVendorLotUseAllRemains_CheckedChanged);
            // 
            // cbBatchUseAllRemains
            // 
            this.cbBatchUseAllRemains.AutoSize = true;
            this.cbBatchUseAllRemains.Location = new System.Drawing.Point(794, 66);
            this.cbBatchUseAllRemains.Name = "cbBatchUseAllRemains";
            this.cbBatchUseAllRemains.Size = new System.Drawing.Size(162, 17);
            this.cbBatchUseAllRemains.TabIndex = 21;
            this.cbBatchUseAllRemains.Text = "Показать нулевой остаток";
            this.cbBatchUseAllRemains.UseVisualStyleBackColor = true;
            this.cbBatchUseAllRemains.CheckedChanged += new System.EventHandler(this.cbBatchUseAllRemains_CheckedChanged);
            // 
            // cbLocationUseAllRemains
            // 
            this.cbLocationUseAllRemains.AutoSize = true;
            this.cbLocationUseAllRemains.Location = new System.Drawing.Point(200, 66);
            this.cbLocationUseAllRemains.Name = "cbLocationUseAllRemains";
            this.cbLocationUseAllRemains.Size = new System.Drawing.Size(162, 17);
            this.cbLocationUseAllRemains.TabIndex = 17;
            this.cbLocationUseAllRemains.Text = "Показать нулевой остаток";
            this.cbLocationUseAllRemains.UseVisualStyleBackColor = true;
            this.cbLocationUseAllRemains.CheckedChanged += new System.EventHandler(this.cbLocationUseAllRemains_CheckedChanged);
            // 
            // lblQFilterItem
            // 
            this.lblQFilterItem.AutoSize = true;
            this.lblQFilterItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblQFilterItem.Location = new System.Drawing.Point(197, 39);
            this.lblQFilterItem.Name = "lblQFilterItem";
            this.lblQFilterItem.Size = new System.Drawing.Size(99, 13);
            this.lblQFilterItem.TabIndex = 8;
            this.lblQFilterItem.Text = "Быстрый фильтр :";
            // 
            // tbQFilterItem
            // 
            this.tbQFilterItem.BackColor = System.Drawing.SystemColors.Info;
            this.tbQFilterItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbQFilterItem.Location = new System.Drawing.Point(306, 35);
            this.tbQFilterItem.Name = "tbQFilterItem";
            this.tbQFilterItem.Size = new System.Drawing.Size(50, 20);
            this.tbQFilterItem.TabIndex = 9;
            this.tbQFilterItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQFilterItem_KeyDown);
            this.tbQFilterItem.Leave += new System.EventHandler(this.tbQFilterItem_Leave);
            // 
            // tbBatchNumber
            // 
            this.tbBatchNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbBatchNumber.Location = new System.Drawing.Point(959, 64);
            this.tbBatchNumber.Name = "tbBatchNumber";
            this.tbBatchNumber.ReadOnly = true;
            this.tbBatchNumber.Size = new System.Drawing.Size(235, 20);
            this.tbBatchNumber.TabIndex = 22;
            // 
            // stbBatchNumber
            // 
            this.stbBatchNumber.Location = new System.Drawing.Point(686, 64);
            this.stbBatchNumber.Name = "stbBatchNumber";
            this.stbBatchNumber.NavigateByValue = false;
            this.stbBatchNumber.ReadOnly = false;
            this.stbBatchNumber.Size = new System.Drawing.Size(100, 20);
            this.stbBatchNumber.TabIndex = 20;
            this.stbBatchNumber.UserID = ((long)(0));
            this.stbBatchNumber.Value = null;
            this.stbBatchNumber.ValueReferenceQuery = null;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(631, 68);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(47, 13);
            this.lblBatchNumber.TabIndex = 19;
            this.lblBatchNumber.Text = "Партия:";
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendorLot.Location = new System.Drawing.Point(959, 35);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.ReadOnly = true;
            this.tbVendorLot.Size = new System.Drawing.Size(235, 20);
            this.tbVendorLot.TabIndex = 14;
            // 
            // stbVendorLot
            // 
            this.stbVendorLot.Location = new System.Drawing.Point(686, 35);
            this.stbVendorLot.Name = "stbVendorLot";
            this.stbVendorLot.NavigateByValue = false;
            this.stbVendorLot.ReadOnly = false;
            this.stbVendorLot.Size = new System.Drawing.Size(100, 20);
            this.stbVendorLot.TabIndex = 12;
            this.stbVendorLot.UserID = ((long)(0));
            this.stbVendorLot.Value = null;
            this.stbVendorLot.ValueReferenceQuery = null;
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(637, 39);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLot.TabIndex = 11;
            this.lblVendorLot.Text = "Серия:";
            // 
            // tbLocation
            // 
            this.tbLocation.BackColor = System.Drawing.SystemColors.Window;
            this.tbLocation.Location = new System.Drawing.Point(362, 64);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ReadOnly = true;
            this.tbLocation.Size = new System.Drawing.Size(235, 20);
            this.tbLocation.TabIndex = 18;
            // 
            // stbLocation
            // 
            this.stbLocation.Location = new System.Drawing.Point(89, 64);
            this.stbLocation.Name = "stbLocation";
            this.stbLocation.NavigateByValue = false;
            this.stbLocation.ReadOnly = false;
            this.stbLocation.Size = new System.Drawing.Size(100, 20);
            this.stbLocation.TabIndex = 16;
            this.stbLocation.UserID = ((long)(0));
            this.stbLocation.Value = null;
            this.stbLocation.ValueReferenceQuery = null;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(10, 68);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(71, 13);
            this.lblLocation.TabIndex = 15;
            this.lblLocation.Text = "Место хран.:";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(197, 97);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 25;
            this.lblDateTo.Text = "Дата по:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(256, 93);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpDateTo.TabIndex = 26;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(36, 97);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblDateFrom.TabIndex = 23;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // tbItem
            // 
            this.tbItem.BackColor = System.Drawing.SystemColors.Window;
            this.tbItem.Location = new System.Drawing.Point(362, 35);
            this.tbItem.Name = "tbItem";
            this.tbItem.ReadOnly = true;
            this.tbItem.Size = new System.Drawing.Size(235, 20);
            this.tbItem.TabIndex = 10;
            // 
            // stbItem
            // 
            this.stbItem.Location = new System.Drawing.Point(89, 35);
            this.stbItem.Name = "stbItem";
            this.stbItem.NavigateByValue = false;
            this.stbItem.ReadOnly = false;
            this.stbItem.Size = new System.Drawing.Size(100, 20);
            this.stbItem.TabIndex = 7;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(40, 39);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(41, 13);
            this.lblItem.TabIndex = 6;
            this.lblItem.Text = "Товар:";
            // 
            // tbBusinessUnitTo
            // 
            this.tbBusinessUnitTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbBusinessUnitTo.Location = new System.Drawing.Point(794, 6);
            this.tbBusinessUnitTo.Name = "tbBusinessUnitTo";
            this.tbBusinessUnitTo.ReadOnly = true;
            this.tbBusinessUnitTo.Size = new System.Drawing.Size(400, 20);
            this.tbBusinessUnitTo.TabIndex = 5;
            // 
            // stbBusinessUnitTo
            // 
            this.stbBusinessUnitTo.Location = new System.Drawing.Point(686, 6);
            this.stbBusinessUnitTo.Name = "stbBusinessUnitTo";
            this.stbBusinessUnitTo.NavigateByValue = false;
            this.stbBusinessUnitTo.ReadOnly = false;
            this.stbBusinessUnitTo.Size = new System.Drawing.Size(100, 20);
            this.stbBusinessUnitTo.TabIndex = 4;
            this.stbBusinessUnitTo.UserID = ((long)(0));
            this.stbBusinessUnitTo.Value = null;
            this.stbBusinessUnitTo.ValueReferenceQuery = null;
            // 
            // lblBusinessUnitTo
            // 
            this.lblBusinessUnitTo.AutoSize = true;
            this.lblBusinessUnitTo.Location = new System.Drawing.Point(613, 10);
            this.lblBusinessUnitTo.Name = "lblBusinessUnitTo";
            this.lblBusinessUnitTo.Size = new System.Drawing.Size(65, 13);
            this.lblBusinessUnitTo.TabIndex = 3;
            this.lblBusinessUnitTo.Text = "Биз. ед. по:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(89, 93);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpDateFrom.TabIndex = 24;
            // 
            // tbBusinessUnitFrom
            // 
            this.tbBusinessUnitFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbBusinessUnitFrom.Location = new System.Drawing.Point(197, 6);
            this.tbBusinessUnitFrom.Name = "tbBusinessUnitFrom";
            this.tbBusinessUnitFrom.ReadOnly = true;
            this.tbBusinessUnitFrom.Size = new System.Drawing.Size(400, 20);
            this.tbBusinessUnitFrom.TabIndex = 2;
            // 
            // stbBusinessUnitFrom
            // 
            this.stbBusinessUnitFrom.Location = new System.Drawing.Point(89, 6);
            this.stbBusinessUnitFrom.Name = "stbBusinessUnitFrom";
            this.stbBusinessUnitFrom.NavigateByValue = false;
            this.stbBusinessUnitFrom.ReadOnly = false;
            this.stbBusinessUnitFrom.Size = new System.Drawing.Size(100, 20);
            this.stbBusinessUnitFrom.TabIndex = 1;
            this.stbBusinessUnitFrom.UserID = ((long)(0));
            this.stbBusinessUnitFrom.Value = null;
            this.stbBusinessUnitFrom.ValueReferenceQuery = null;
            // 
            // lblBusinessUnitFrom
            // 
            this.lblBusinessUnitFrom.AutoSize = true;
            this.lblBusinessUnitFrom.Location = new System.Drawing.Point(22, 10);
            this.lblBusinessUnitFrom.Name = "lblBusinessUnitFrom";
            this.lblBusinessUnitFrom.Size = new System.Drawing.Size(59, 13);
            this.lblBusinessUnitFrom.TabIndex = 0;
            this.lblBusinessUnitFrom.Text = "Биз. ед. с:";
            // 
            // RemainsWithMovementsDispatcherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 388);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.tsMain);
            this.Name = "RemainsWithMovementsDispatcherWindow";
            this.Text = "RemainsWithMovementsDispatcherWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemainsWithMovementsDispatcherWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMainContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tpRemains.ResumeLayout(false);
            this.tpMovements.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnLoadData;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpRemains;
        private System.Windows.Forms.TabPage tpMovements;
        private WMSOffice.Controls.SearchTextBox stbBusinessUnitFrom;
        private System.Windows.Forms.Label lblBusinessUnitFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.TextBox tbBusinessUnitFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.TextBox tbItem;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox tbBusinessUnitTo;
        private WMSOffice.Controls.SearchTextBox stbBusinessUnitTo;
        private System.Windows.Forms.Label lblBusinessUnitTo;
        private System.Windows.Forms.TextBox tbLocation;
        private WMSOffice.Controls.SearchTextBox stbLocation;
        private System.Windows.Forms.Label lblLocation;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvRemains;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvMovements;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.TextBox tbBatchNumber;
        private WMSOffice.Controls.SearchTextBox stbBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.TextBox tbVendorLot;
        private WMSOffice.Controls.SearchTextBox stbVendorLot;
        private System.Windows.Forms.Label lblVendorLot;
        private System.Windows.Forms.TextBox tbQFilterItem;
        private System.Windows.Forms.Label lblQFilterItem;
        private System.Windows.Forms.CheckBox cbLocationUseAllRemains;
        private System.Windows.Forms.CheckBox cbBatchUseAllRemains;
        private System.Windows.Forms.CheckBox cbVendorLotUseAllRemains;
    }
}