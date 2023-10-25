namespace WMSOffice.Window.QualityLotsWindow
{
    partial class QualityLotsWindow
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
            this.btnLoadDataQualityLots = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditLot = new System.Windows.Forms.ToolStripButton();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cbAllRemainsBatch = new System.Windows.Forms.CheckBox();
            this.stbVendor_Lot = new WMSOffice.Controls.SearchTextBox();
            this.stbLot_Number = new WMSOffice.Controls.SearchTextBox();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.tbQFilterItem = new System.Windows.Forms.TextBox();
            this.tbVendor_Lot = new System.Windows.Forms.TextBox();
            this.tbLot_Number = new System.Windows.Forms.TextBox();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.stbWarehouse_ID = new WMSOffice.Controls.SearchTextBox();
            this.tbWarehouse_ID = new System.Windows.Forms.TextBox();
            this.cbAllRemainsLotNumber = new System.Windows.Forms.CheckBox();
            this.lblQFilterItem = new System.Windows.Forms.Label();
            this.lblWarehouse_ID = new System.Windows.Forms.Label();
            this.lblVendor_Lot = new System.Windows.Forms.Label();
            this.lblLot_Number = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.xdgvQualityLots = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadDataQualityLots,
            this.toolStripSeparator1,
            this.btnExportToExcel,
            this.toolStripSeparator2,
            this.btnEditLot});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1221, 55);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnLoadDataQualityLots
            // 
            this.btnLoadDataQualityLots.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnLoadDataQualityLots.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadDataQualityLots.Name = "btnLoadDataQualityLots";
            this.btnLoadDataQualityLots.Size = new System.Drawing.Size(109, 52);
            this.btnLoadDataQualityLots.Text = "Обновить";
            this.btnLoadDataQualityLots.Click += new System.EventHandler(this.btnLoadDataQualityLots_Click);
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
            this.btnExportToExcel.Size = new System.Drawing.Size(100, 52);
            this.btnExportToExcel.Text = "Експорт\nв Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnEditLot
            // 
            this.btnEditLot.Image = global::WMSOffice.Properties.Resources.history_review;
            this.btnEditLot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditLot.Name = "btnEditLot";
            this.btnEditLot.Size = new System.Drawing.Size(87, 52);
            this.btnEditLot.Text = "Зміна\nпартії";
            this.btnEditLot.Click += new System.EventHandler(this.btnEditLot_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.cbAllRemainsBatch);
            this.pnlFilter.Controls.Add(this.stbVendor_Lot);
            this.pnlFilter.Controls.Add(this.stbLot_Number);
            this.pnlFilter.Controls.Add(this.tbItemID);
            this.pnlFilter.Controls.Add(this.tbQFilterItem);
            this.pnlFilter.Controls.Add(this.tbVendor_Lot);
            this.pnlFilter.Controls.Add(this.tbLot_Number);
            this.pnlFilter.Controls.Add(this.stbItemID);
            this.pnlFilter.Controls.Add(this.stbWarehouse_ID);
            this.pnlFilter.Controls.Add(this.tbWarehouse_ID);
            this.pnlFilter.Controls.Add(this.cbAllRemainsLotNumber);
            this.pnlFilter.Controls.Add(this.lblQFilterItem);
            this.pnlFilter.Controls.Add(this.lblWarehouse_ID);
            this.pnlFilter.Controls.Add(this.lblVendor_Lot);
            this.pnlFilter.Controls.Add(this.lblLot_Number);
            this.pnlFilter.Controls.Add(this.lblItemID);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 95);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1221, 86);
            this.pnlFilter.TabIndex = 3;
            // 
            // cbAllRemainsBatch
            // 
            this.cbAllRemainsBatch.AutoSize = true;
            this.cbAllRemainsBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAllRemainsBatch.Location = new System.Drawing.Point(846, 49);
            this.cbAllRemainsBatch.Name = "cbAllRemainsBatch";
            this.cbAllRemainsBatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbAllRemainsBatch.Size = new System.Drawing.Size(112, 17);
            this.cbAllRemainsBatch.TabIndex = 38;
            this.cbAllRemainsBatch.Text = "Нульові залишки";
            this.cbAllRemainsBatch.UseVisualStyleBackColor = true;
            this.cbAllRemainsBatch.CheckedChanged += new System.EventHandler(this.cbAllRemainsVendorLot_CheckedChanged);
            // 
            // stbVendor_Lot
            // 
            this.stbVendor_Lot.Location = new System.Drawing.Point(706, 46);
            this.stbVendor_Lot.Name = "stbVendor_Lot";
            this.stbVendor_Lot.NavigateByValue = false;
            this.stbVendor_Lot.ReadOnly = false;
            this.stbVendor_Lot.Size = new System.Drawing.Size(125, 20);
            this.stbVendor_Lot.TabIndex = 37;
            this.stbVendor_Lot.UserID = ((long)(0));
            this.stbVendor_Lot.Value = null;
            this.stbVendor_Lot.ValueReferenceQuery = null;
            // 
            // stbLot_Number
            // 
            this.stbLot_Number.Location = new System.Drawing.Point(706, 10);
            this.stbLot_Number.Name = "stbLot_Number";
            this.stbLot_Number.NavigateByValue = false;
            this.stbLot_Number.ReadOnly = false;
            this.stbLot_Number.Size = new System.Drawing.Size(125, 20);
            this.stbLot_Number.TabIndex = 36;
            this.stbLot_Number.UserID = ((long)(0));
            this.stbLot_Number.Value = null;
            this.stbLot_Number.ValueReferenceQuery = null;
            this.stbLot_Number.Leave += new System.EventHandler(this.stbLot_Number_Leave);
            // 
            // tbItemID
            // 
            this.tbItemID.BackColor = System.Drawing.SystemColors.Window;
            this.tbItemID.Location = new System.Drawing.Point(390, 9);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.ReadOnly = true;
            this.tbItemID.Size = new System.Drawing.Size(245, 20);
            this.tbItemID.TabIndex = 34;
            // 
            // tbQFilterItem
            // 
            this.tbQFilterItem.BackColor = System.Drawing.Color.White;
            this.tbQFilterItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbQFilterItem.Location = new System.Drawing.Point(303, 9);
            this.tbQFilterItem.Name = "tbQFilterItem";
            this.tbQFilterItem.Size = new System.Drawing.Size(81, 20);
            this.tbQFilterItem.TabIndex = 33;
            this.tbQFilterItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQFilterItem_KeyDown_1);
            this.tbQFilterItem.Leave += new System.EventHandler(this.tbQFilterItem_Leave);
            // 
            // tbVendor_Lot
            // 
            this.tbVendor_Lot.BackColor = System.Drawing.Color.White;
            this.tbVendor_Lot.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbVendor_Lot.Location = new System.Drawing.Point(964, 46);
            this.tbVendor_Lot.Name = "tbVendor_Lot";
            this.tbVendor_Lot.Size = new System.Drawing.Size(245, 20);
            this.tbVendor_Lot.TabIndex = 32;
            // 
            // tbLot_Number
            // 
            this.tbLot_Number.BackColor = System.Drawing.Color.White;
            this.tbLot_Number.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbLot_Number.Location = new System.Drawing.Point(964, 10);
            this.tbLot_Number.Name = "tbLot_Number";
            this.tbLot_Number.Size = new System.Drawing.Size(245, 20);
            this.tbLot_Number.TabIndex = 31;
            this.tbLot_Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCheckIsDigit_KeyPress);
            // 
            // stbItemID
            // 
            this.stbItemID.Location = new System.Drawing.Point(85, 9);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.NavigateByValue = false;
            this.stbItemID.ReadOnly = false;
            this.stbItemID.Size = new System.Drawing.Size(120, 20);
            this.stbItemID.TabIndex = 30;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // stbWarehouse_ID
            // 
            this.stbWarehouse_ID.Location = new System.Drawing.Point(85, 46);
            this.stbWarehouse_ID.Name = "stbWarehouse_ID";
            this.stbWarehouse_ID.NavigateByValue = false;
            this.stbWarehouse_ID.ReadOnly = false;
            this.stbWarehouse_ID.Size = new System.Drawing.Size(120, 20);
            this.stbWarehouse_ID.TabIndex = 29;
            this.stbWarehouse_ID.UserID = ((long)(0));
            this.stbWarehouse_ID.Value = null;
            this.stbWarehouse_ID.ValueReferenceQuery = null;
            // 
            // tbWarehouse_ID
            // 
            this.tbWarehouse_ID.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouse_ID.Location = new System.Drawing.Point(303, 46);
            this.tbWarehouse_ID.Name = "tbWarehouse_ID";
            this.tbWarehouse_ID.ReadOnly = true;
            this.tbWarehouse_ID.Size = new System.Drawing.Size(332, 20);
            this.tbWarehouse_ID.TabIndex = 27;
            // 
            // cbAllRemainsLotNumber
            // 
            this.cbAllRemainsLotNumber.AutoSize = true;
            this.cbAllRemainsLotNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAllRemainsLotNumber.Location = new System.Drawing.Point(846, 9);
            this.cbAllRemainsLotNumber.Name = "cbAllRemainsLotNumber";
            this.cbAllRemainsLotNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbAllRemainsLotNumber.Size = new System.Drawing.Size(112, 17);
            this.cbAllRemainsLotNumber.TabIndex = 17;
            this.cbAllRemainsLotNumber.Text = "Нульові залишки";
            this.cbAllRemainsLotNumber.UseVisualStyleBackColor = true;
            this.cbAllRemainsLotNumber.CheckedChanged += new System.EventHandler(this.cbAllRemainsLotNumber_CheckedChanged);
            // 
            // lblQFilterItem
            // 
            this.lblQFilterItem.AutoSize = true;
            this.lblQFilterItem.ForeColor = System.Drawing.Color.Black;
            this.lblQFilterItem.Location = new System.Drawing.Point(211, 13);
            this.lblQFilterItem.Name = "lblQFilterItem";
            this.lblQFilterItem.Size = new System.Drawing.Size(84, 13);
            this.lblQFilterItem.TabIndex = 8;
            this.lblQFilterItem.Text = "Пошук по назві";
            // 
            // lblWarehouse_ID
            // 
            this.lblWarehouse_ID.AutoSize = true;
            this.lblWarehouse_ID.Location = new System.Drawing.Point(13, 50);
            this.lblWarehouse_ID.Name = "lblWarehouse_ID";
            this.lblWarehouse_ID.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse_ID.TabIndex = 19;
            this.lblWarehouse_ID.Text = "Склад:";
            // 
            // lblVendor_Lot
            // 
            this.lblVendor_Lot.AutoSize = true;
            this.lblVendor_Lot.Location = new System.Drawing.Point(651, 49);
            this.lblVendor_Lot.Name = "lblVendor_Lot";
            this.lblVendor_Lot.Size = new System.Drawing.Size(37, 13);
            this.lblVendor_Lot.TabIndex = 11;
            this.lblVendor_Lot.Text = "Серія:";
            // 
            // lblLot_Number
            // 
            this.lblLot_Number.AutoSize = true;
            this.lblLot_Number.Location = new System.Drawing.Point(651, 17);
            this.lblLot_Number.Name = "lblLot_Number";
            this.lblLot_Number.Size = new System.Drawing.Size(43, 13);
            this.lblLot_Number.TabIndex = 6;
            this.lblLot_Number.Text = "Партія:";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(13, 13);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(66, 13);
            this.lblItemID.TabIndex = 0;
            this.lblItemID.Text = "Код товару:";
            // 
            // xdgvQualityLots
            // 
            this.xdgvQualityLots.AllowSort = true;
            this.xdgvQualityLots.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvQualityLots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvQualityLots.LargeAmountOfData = false;
            this.xdgvQualityLots.Location = new System.Drawing.Point(0, 181);
            this.xdgvQualityLots.Name = "xdgvQualityLots";
            this.xdgvQualityLots.RowHeadersVisible = false;
            this.xdgvQualityLots.Size = new System.Drawing.Size(1221, 285);
            this.xdgvQualityLots.TabIndex = 4;
            this.xdgvQualityLots.UserID = ((long)(0));
            // 
            // QualityLotsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 466);
            this.Controls.Add(this.xdgvQualityLots);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.tsMain);
            this.Name = "QualityLotsWindow";
            this.Text = "Довідник партій товару";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityLotsWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.xdgvQualityLots, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnLoadDataQualityLots;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.CheckBox cbAllRemainsLotNumber;
        private System.Windows.Forms.Label lblQFilterItem;
        private System.Windows.Forms.Label lblWarehouse_ID;
        private System.Windows.Forms.Label lblVendor_Lot;
        private System.Windows.Forms.Label lblLot_Number;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox tbWarehouse_ID;
        public WMSOffice.Controls.SearchTextBox stbWarehouse_ID;
        public WMSOffice.Controls.SearchTextBox stbItemID;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvQualityLots;
        public System.Windows.Forms.TextBox tbLot_Number;
        public System.Windows.Forms.TextBox tbVendor_Lot;
        public System.Windows.Forms.TextBox tbQFilterItem;
        private System.Windows.Forms.TextBox tbItemID;
        public WMSOffice.Controls.SearchTextBox stbVendor_Lot;
        public WMSOffice.Controls.SearchTextBox stbLot_Number;
        public System.Windows.Forms.ToolStripButton btnExportToExcel;
        public System.Windows.Forms.ToolStripButton btnEditLot;
        private System.Windows.Forms.CheckBox cbAllRemainsBatch;
    }
}