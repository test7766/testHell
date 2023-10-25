namespace WMSOffice.Window
{
    partial class ComplaintsVideoMonitoringWindow
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
            this.ctrlVideoMonitoring = new WMSOffice.Controls.VideoMonitoringControl();
            this.tsOptions = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbComplaints = new System.Windows.Forms.ToolStripComboBox();
            this.tsOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlVideoMonitoring
            // 
            this.ctrlVideoMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlVideoMonitoring.Location = new System.Drawing.Point(0, 68);
            this.ctrlVideoMonitoring.Name = "ctrlVideoMonitoring";
            this.ctrlVideoMonitoring.Size = new System.Drawing.Size(821, 413);
            this.ctrlVideoMonitoring.TabIndex = 1;
            // 
            // tsOptions
            // 
            this.tsOptions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbComplaints});
            this.tsOptions.Location = new System.Drawing.Point(0, 40);
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(821, 25);
            this.tsOptions.TabIndex = 2;
            this.tsOptions.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel1.Text = "Претензия №";
            // 
            // cmbComplaints
            // 
            this.cmbComplaints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplaints.Name = "cmbComplaints";
            this.cmbComplaints.Size = new System.Drawing.Size(150, 25);
            // 
            // ComplaintsVideoMonitoringWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 481);
            this.Controls.Add(this.tsOptions);
            this.Controls.Add(this.ctrlVideoMonitoring);
            this.Name = "ComplaintsVideoMonitoringWindow";
            this.Text = "ComplaintsVideoMonitoringWindow";
            this.Load += new System.EventHandler(this.ComplaintsVideoMonitoringWindow_Load);
            this.Controls.SetChildIndex(this.ctrlVideoMonitoring, 0);
            this.Controls.SetChildIndex(this.tsOptions, 0);
            this.tsOptions.ResumeLayout(false);
            this.tsOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.VideoMonitoringControl ctrlVideoMonitoring;
        private System.Windows.Forms.ToolStrip tsOptions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbComplaints;
    }
}