namespace WMSOffice.Dialogs.Receive
{
    partial class PalletsChangeVendorReturnFlagWindow
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbAdd = new System.Windows.Forms.ToolStripButton();
            this.xdgvData = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.sbAddToArchive = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData,
            this.toolStripSeparator1,
            this.sbAdd,
            this.sbAddToArchive});
            this.toolStrip1.Location = new System.Drawing.Point(0, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1176, 55);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // sbRefreshData
            // 
            this.sbRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshData.Name = "sbRefreshData";
            this.sbRefreshData.Size = new System.Drawing.Size(113, 52);
            this.sbRefreshData.Text = "Обновить";
            this.sbRefreshData.Click += new System.EventHandler(this.sbRefreshData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbAdd
            // 
            this.sbAdd.Image = global::WMSOffice.Properties.Resources.add_document;
            this.sbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAdd.Name = "sbAdd";
            this.sbAdd.Size = new System.Drawing.Size(159, 52);
            this.sbAdd.Text = "Добавить признак\nвозвратности";
            this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
            // 
            // xdgvData
            // 
            this.xdgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.xdgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvData.Location = new System.Drawing.Point(0, 95);
            this.xdgvData.Name = "xdgvData";
            this.xdgvData.Size = new System.Drawing.Size(1176, 603);
            this.xdgvData.TabIndex = 2;
            this.xdgvData.UserID = ((long)(0));
            // 
            // sbAddToArchive
            // 
            this.sbAddToArchive.Image = global::WMSOffice.Properties.Resources.Delete;
            this.sbAddToArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddToArchive.Name = "sbAddToArchive";
            this.sbAddToArchive.Size = new System.Drawing.Size(143, 52);
            this.sbAddToArchive.Text = "Удалить\nзапись";
            this.sbAddToArchive.Click += new System.EventHandler(this.sbAddToArchive_Click);
            // 
            // PalletsChangeVendorReturnFlagWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 698);
            this.Controls.Add(this.xdgvData);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PalletsChangeVendorReturnFlagWindow";
            this.Text = "PalletsChangeVendorReturnFlag";
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.xdgvData, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbAdd;
        private System.Windows.Forms.ToolStripButton sbAddToArchive;
    }
}