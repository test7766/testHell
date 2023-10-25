namespace WMSOffice.Window
{
    partial class TareOverflowWindow
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
            this.btnRefreshData = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.xdgvItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshData});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(740, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(103, 52);
            this.btnRefreshData.Text = "Оновити";
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tsSearch);
            this.pnlContent.Controls.Add(this.xdgvItems);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(740, 293);
            this.pnlContent.TabIndex = 4;
            // 
            // tsSearch
            // 
            this.tsSearch.Location = new System.Drawing.Point(0, 0);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.Size = new System.Drawing.Size(740, 25);
            this.tsSearch.TabIndex = 3;
            this.tsSearch.Text = "toolStrip1";
            // 
            // xdgvItems
            // 
            this.xdgvItems.AllowSort = true;
            this.xdgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvItems.LargeAmountOfData = false;
            this.xdgvItems.Location = new System.Drawing.Point(0, 28);
            this.xdgvItems.Name = "xdgvItems";
            this.xdgvItems.RowHeadersVisible = false;
            this.xdgvItems.Size = new System.Drawing.Size(740, 265);
            this.xdgvItems.TabIndex = 2;
            this.xdgvItems.UserID = ((long)(0));
            // 
            // TareOverflowWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "TareOverflowWindow";
            this.Text = "OverflowTareWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefreshData;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip tsSearch;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvItems;
    }
}