namespace WMSOffice.Window
{
    partial class FixedLocationsWindow
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
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tbUnitOfMeasure = new System.Windows.Forms.TextBox();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.tbWarehouseName = new System.Windows.Forms.TextBox();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.stbWarehouseID = new WMSOffice.Controls.SearchTextBox();
            this.lblUnitOfMeasure = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblWarehouseID = new System.Windows.Forms.Label();
            this.stbUnitOfMeasure = new WMSOffice.Controls.SearchTextBox();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnAdd,
            this.btnEdit,
            this.btnDelete});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(740, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 52);
            this.btnAdd.Text = "Создать";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 52);
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvItems);
            this.pnlContent.Controls.Add(this.pnlFilter);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(740, 293);
            this.pnlContent.TabIndex = 2;
            // 
            // xdgvItems
            // 
            this.xdgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvItems.LargeAmountOfData = false;
            this.xdgvItems.Location = new System.Drawing.Point(0, 100);
            this.xdgvItems.Name = "xdgvItems";
            this.xdgvItems.RowHeadersVisible = false;
            this.xdgvItems.Size = new System.Drawing.Size(740, 193);
            this.xdgvItems.TabIndex = 1;
            this.xdgvItems.UserID = ((long)(0));
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.tbUnitOfMeasure);
            this.pnlFilter.Controls.Add(this.tbItemName);
            this.pnlFilter.Controls.Add(this.tbWarehouseName);
            this.pnlFilter.Controls.Add(this.stbItemID);
            this.pnlFilter.Controls.Add(this.stbWarehouseID);
            this.pnlFilter.Controls.Add(this.lblUnitOfMeasure);
            this.pnlFilter.Controls.Add(this.lblItemID);
            this.pnlFilter.Controls.Add(this.lblWarehouseID);
            this.pnlFilter.Controls.Add(this.stbUnitOfMeasure);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(740, 100);
            this.pnlFilter.TabIndex = 0;
            // 
            // tbUnitOfMeasure
            // 
            this.tbUnitOfMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUnitOfMeasure.BackColor = System.Drawing.SystemColors.Window;
            this.tbUnitOfMeasure.Location = new System.Drawing.Point(254, 67);
            this.tbUnitOfMeasure.Name = "tbUnitOfMeasure";
            this.tbUnitOfMeasure.ReadOnly = true;
            this.tbUnitOfMeasure.Size = new System.Drawing.Size(474, 20);
            this.tbUnitOfMeasure.TabIndex = 8;
            this.tbUnitOfMeasure.TabStop = false;
            // 
            // tbItemName
            // 
            this.tbItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbItemName.BackColor = System.Drawing.SystemColors.Window;
            this.tbItemName.Location = new System.Drawing.Point(254, 38);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.ReadOnly = true;
            this.tbItemName.Size = new System.Drawing.Size(474, 20);
            this.tbItemName.TabIndex = 5;
            this.tbItemName.TabStop = false;
            // 
            // tbWarehouseName
            // 
            this.tbWarehouseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarehouseName.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouseName.Location = new System.Drawing.Point(254, 9);
            this.tbWarehouseName.Name = "tbWarehouseName";
            this.tbWarehouseName.ReadOnly = true;
            this.tbWarehouseName.Size = new System.Drawing.Size(474, 20);
            this.tbWarehouseName.TabIndex = 2;
            this.tbWarehouseName.TabStop = false;
            // 
            // stbItemID
            // 
            this.stbItemID.Location = new System.Drawing.Point(128, 38);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.ReadOnly = false;
            this.stbItemID.Size = new System.Drawing.Size(120, 20);
            this.stbItemID.TabIndex = 4;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // stbWarehouseID
            // 
            this.stbWarehouseID.Location = new System.Drawing.Point(128, 9);
            this.stbWarehouseID.Name = "stbWarehouseID";
            this.stbWarehouseID.ReadOnly = false;
            this.stbWarehouseID.Size = new System.Drawing.Size(120, 20);
            this.stbWarehouseID.TabIndex = 1;
            this.stbWarehouseID.UserID = ((long)(0));
            this.stbWarehouseID.Value = null;
            this.stbWarehouseID.ValueReferenceQuery = null;
            // 
            // lblUnitOfMeasure
            // 
            this.lblUnitOfMeasure.AutoSize = true;
            this.lblUnitOfMeasure.Location = new System.Drawing.Point(13, 71);
            this.lblUnitOfMeasure.Name = "lblUnitOfMeasure";
            this.lblUnitOfMeasure.Size = new System.Drawing.Size(109, 13);
            this.lblUnitOfMeasure.TabIndex = 6;
            this.lblUnitOfMeasure.Text = "Единица измерения";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(13, 42);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(64, 13);
            this.lblItemID.TabIndex = 3;
            this.lblItemID.Text = "Код товара";
            // 
            // lblWarehouseID
            // 
            this.lblWarehouseID.AutoSize = true;
            this.lblWarehouseID.Location = new System.Drawing.Point(13, 13);
            this.lblWarehouseID.Name = "lblWarehouseID";
            this.lblWarehouseID.Size = new System.Drawing.Size(48, 13);
            this.lblWarehouseID.TabIndex = 0;
            this.lblWarehouseID.Text = "Филиал";
            // 
            // stbUnitOfMeasure
            // 
            this.stbUnitOfMeasure.Location = new System.Drawing.Point(128, 67);
            this.stbUnitOfMeasure.Name = "stbUnitOfMeasure";
            this.stbUnitOfMeasure.ReadOnly = false;
            this.stbUnitOfMeasure.Size = new System.Drawing.Size(120, 20);
            this.stbUnitOfMeasure.TabIndex = 7;
            this.stbUnitOfMeasure.UserID = ((long)(0));
            this.stbUnitOfMeasure.Value = null;
            this.stbUnitOfMeasure.ValueReferenceQuery = null;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 52);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FixedLocationsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "FixedLocationsWindow";
            this.Text = "FixedLocationsWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvItems;
        private System.Windows.Forms.Panel pnlFilter;
        private WMSOffice.Controls.SearchTextBox stbUnitOfMeasure;
        private WMSOffice.Controls.SearchTextBox stbItemID;
        private WMSOffice.Controls.SearchTextBox stbWarehouseID;
        private System.Windows.Forms.Label lblUnitOfMeasure;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblWarehouseID;
        private System.Windows.Forms.TextBox tbWarehouseName;
        private System.Windows.Forms.TextBox tbUnitOfMeasure;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.ToolStripButton btnDelete;
    }
}