namespace WMSOffice.Window
{
    partial class PalletSecureAccountingWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.pnlMainLayout = new System.Windows.Forms.Panel();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(936, 39);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbRefreshData
            // 
            this.sbRefreshData.BackColor = System.Drawing.SystemColors.Control;
            this.sbRefreshData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sbRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshData.Name = "sbRefreshData";
            this.sbRefreshData.Size = new System.Drawing.Size(97, 36);
            this.sbRefreshData.Text = "Обновить";
            this.sbRefreshData.Click += new System.EventHandler(this.sbRefreshData_Click);
            // 
            // pnlMainLayout
            // 
            this.pnlMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainLayout.Location = new System.Drawing.Point(0, 79);
            this.pnlMainLayout.Name = "pnlMainLayout";
            this.pnlMainLayout.Size = new System.Drawing.Size(936, 340);
            this.pnlMainLayout.TabIndex = 3;
            // 
            // PalletSecureAccountingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 419);
            this.Controls.Add(this.pnlMainLayout);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "PalletSecureAccountingWindow";
            this.Text = "PalletSecureAccountingWindow";
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.pnlMainLayout, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.DataGridViewTextBoxColumn isOutgoingAllowedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Panel pnlMainLayout;
    }
}