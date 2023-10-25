namespace WMSOffice.Window
{
    partial class CorrugatedTareBalanceWindow
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
            this.tsMainStrip = new System.Windows.Forms.ToolStrip();
            this.btnReloadData = new System.Windows.Forms.ToolStripButton();
            this.btnFindTare = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvTareBalance = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.tsMainStrip.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainStrip
            // 
            this.tsMainStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadData,
            this.btnFindTare,
            this.toolStripSeparator1,
            this.btnExport});
            this.tsMainStrip.Location = new System.Drawing.Point(0, 40);
            this.tsMainStrip.Name = "tsMainStrip";
            this.tsMainStrip.Size = new System.Drawing.Size(740, 55);
            this.tsMainStrip.TabIndex = 1;
            this.tsMainStrip.Text = "toolStrip1";
            // 
            // btnReloadData
            // 
            this.btnReloadData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnReloadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(113, 52);
            this.btnReloadData.Text = "Обновить";
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // btnFindTare
            // 
            this.btnFindTare.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFindTare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindTare.Name = "btnFindTare";
            this.btnFindTare.Size = new System.Drawing.Size(94, 52);
            this.btnFindTare.Text = "Поиск";
            this.btnFindTare.Click += new System.EventHandler(this.btnFindTare_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvTareBalance);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(740, 293);
            this.pnlContent.TabIndex = 2;
            // 
            // xdgvTareBalance
            // 
            this.xdgvTareBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvTareBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvTareBalance.LargeAmountOfData = false;
            this.xdgvTareBalance.Location = new System.Drawing.Point(0, 0);
            this.xdgvTareBalance.Name = "xdgvTareBalance";
            this.xdgvTareBalance.RowHeadersVisible = false;
            this.xdgvTareBalance.Size = new System.Drawing.Size(740, 293);
            this.xdgvTareBalance.TabIndex = 1;
            this.xdgvTareBalance.UserID = ((long)(0));
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(104, 52);
            this.btnExport.Text = "Экспорт";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // CorrugatedTareBalanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMainStrip);
            this.Name = "CorrugatedTareBalanceWindow";
            this.Text = "CorrugatedTareBalanceWindow";
            this.Controls.SetChildIndex(this.tsMainStrip, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMainStrip.ResumeLayout(false);
            this.tsMainStrip.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainStrip;
        private System.Windows.Forms.ToolStripButton btnReloadData;
        private System.Windows.Forms.ToolStripButton btnFindTare;
        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvTareBalance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExport;
    }
}