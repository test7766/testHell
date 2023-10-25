namespace WMSOffice.Window
{
    partial class LimesLoadingWindow
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
            this.tsMainToolbar = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.slFilter = new System.Windows.Forms.ToolStripLabel();
            this.pnlMainLayoutPanel = new System.Windows.Forms.Panel();
            this.rvlcHost = new WMSOffice.Controls.Custom.ReversedVisibilityLayoutControlsHost();
            this.pnlWorkArea = new System.Windows.Forms.Panel();
            this.tsMainToolbar.SuspendLayout();
            this.pnlMainLayoutPanel.SuspendLayout();
            this.pnlWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainToolbar
            // 
            this.tsMainToolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.slFilter});
            this.tsMainToolbar.Location = new System.Drawing.Point(0, 0);
            this.tsMainToolbar.Name = "tsMainToolbar";
            this.tsMainToolbar.Size = new System.Drawing.Size(1035, 39);
            this.tsMainToolbar.TabIndex = 1;
            this.tsMainToolbar.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(97, 36);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // slFilter
            // 
            this.slFilter.ForeColor = System.Drawing.Color.Black;
            this.slFilter.Name = "slFilter";
            this.slFilter.Size = new System.Drawing.Size(76, 36);
            this.slFilter.Text = "за   период   ";
            // 
            // pnlMainLayoutPanel
            // 
            this.pnlMainLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainLayoutPanel.Controls.Add(this.rvlcHost);
            this.pnlMainLayoutPanel.Location = new System.Drawing.Point(3, 42);
            this.pnlMainLayoutPanel.Name = "pnlMainLayoutPanel";
            this.pnlMainLayoutPanel.Size = new System.Drawing.Size(1029, 410);
            this.pnlMainLayoutPanel.TabIndex = 2;
            // 
            // rvlcHost
            // 
            this.rvlcHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvlcHost.Location = new System.Drawing.Point(0, 0);
            this.rvlcHost.Name = "rvlcHost";
            this.rvlcHost.Size = new System.Drawing.Size(1029, 410);
            this.rvlcHost.TabIndex = 0;
            // 
            // pnlWorkArea
            // 
            this.pnlWorkArea.Controls.Add(this.pnlMainLayoutPanel);
            this.pnlWorkArea.Controls.Add(this.tsMainToolbar);
            this.pnlWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkArea.Location = new System.Drawing.Point(0, 40);
            this.pnlWorkArea.Name = "pnlWorkArea";
            this.pnlWorkArea.Size = new System.Drawing.Size(1035, 455);
            this.pnlWorkArea.TabIndex = 3;
            // 
            // LimesLoadingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 495);
            this.Controls.Add(this.pnlWorkArea);
            this.Name = "LimesLoadingWindow";
            this.Text = "Загрузка рамп";
            this.Load += new System.EventHandler(this.LimesLoadingWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LimesLoadingWindow_FormClosing);
            this.Controls.SetChildIndex(this.pnlWorkArea, 0);
            this.tsMainToolbar.ResumeLayout(false);
            this.tsMainToolbar.PerformLayout();
            this.pnlMainLayoutPanel.ResumeLayout(false);
            this.pnlWorkArea.ResumeLayout(false);
            this.pnlWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainToolbar;
        private System.Windows.Forms.ToolStripLabel slFilter;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.Panel pnlMainLayoutPanel;
        private WMSOffice.Controls.Custom.ReversedVisibilityLayoutControlsHost rvlcHost;
        private System.Windows.Forms.Panel pnlWorkArea;
    }
}