namespace WMSOffice.Window
{
    partial class DeliveryTransportOrderingWindow
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
            this.pnlWorkArea = new System.Windows.Forms.Panel();
            this.pnlMainLayoutPanel = new System.Windows.Forms.Panel();
            this.rvlcHost = new WMSOffice.Controls.Custom.ReversedVisibilityLayoutControlsHost();
            this.tsMainToolbar = new System.Windows.Forms.ToolStrip();
            this.btnRefreshData = new System.Windows.Forms.ToolStripButton();
            this.pnlWorkArea.SuspendLayout();
            this.pnlMainLayoutPanel.SuspendLayout();
            this.tsMainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWorkArea
            // 
            this.pnlWorkArea.Controls.Add(this.pnlMainLayoutPanel);
            this.pnlWorkArea.Controls.Add(this.tsMainToolbar);
            this.pnlWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkArea.Location = new System.Drawing.Point(0, 40);
            this.pnlWorkArea.Name = "pnlWorkArea";
            this.pnlWorkArea.Size = new System.Drawing.Size(740, 348);
            this.pnlWorkArea.TabIndex = 1;
            // 
            // pnlMainLayoutPanel
            // 
            this.pnlMainLayoutPanel.Controls.Add(this.rvlcHost);
            this.pnlMainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainLayoutPanel.Location = new System.Drawing.Point(0, 39);
            this.pnlMainLayoutPanel.Name = "pnlMainLayoutPanel";
            this.pnlMainLayoutPanel.Size = new System.Drawing.Size(740, 309);
            this.pnlMainLayoutPanel.TabIndex = 1;
            // 
            // rvlcHost
            // 
            this.rvlcHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvlcHost.Location = new System.Drawing.Point(0, 0);
            this.rvlcHost.Name = "rvlcHost";
            this.rvlcHost.Size = new System.Drawing.Size(740, 309);
            this.rvlcHost.TabIndex = 0;
            // 
            // tsMainToolbar
            // 
            this.tsMainToolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshData});
            this.tsMainToolbar.Location = new System.Drawing.Point(0, 0);
            this.tsMainToolbar.Name = "tsMainToolbar";
            this.tsMainToolbar.Size = new System.Drawing.Size(740, 39);
            this.tsMainToolbar.TabIndex = 0;
            this.tsMainToolbar.Text = "toolStrip1";
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(97, 36);
            this.btnRefreshData.Text = "Обновить";
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // DeliveryTransportOrderingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.pnlWorkArea);
            this.Name = "DeliveryTransportOrderingWindow";
            this.Text = "DeliveryTransportOrderingWindow";
            this.Load += new System.EventHandler(this.DeliveryTransportOrderingWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryTransportOrderingWindow_FormClosing);
            this.Controls.SetChildIndex(this.pnlWorkArea, 0);
            this.pnlWorkArea.ResumeLayout(false);
            this.pnlWorkArea.PerformLayout();
            this.pnlMainLayoutPanel.ResumeLayout(false);
            this.tsMainToolbar.ResumeLayout(false);
            this.tsMainToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWorkArea;
        private System.Windows.Forms.ToolStrip tsMainToolbar;
        private System.Windows.Forms.Panel pnlMainLayoutPanel;
        private System.Windows.Forms.ToolStripButton btnRefreshData;
        private WMSOffice.Controls.Custom.ReversedVisibilityLayoutControlsHost rvlcHost;
    }
}