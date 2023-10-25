namespace WMSOffice.Window
{
    partial class QualityProblemWindow
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
            this.edgDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // edgDocs
            // 
            this.edgDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.edgDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edgDocs.Location = new System.Drawing.Point(0, 95);
            this.edgDocs.Name = "edgDocs";
            this.edgDocs.Size = new System.Drawing.Size(740, 293);
            this.edgDocs.TabIndex = 2;
            this.edgDocs.UserID = ((long)(0));
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(740, 55);
            this.toolStripDoc.TabIndex = 6;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список нераспечатанных накладных";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // QualityProblemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.edgDocs);
            this.Controls.Add(this.toolStripDoc);
            this.Name = "QualityProblemWindow";
            this.Text = "QualityProblemWindow";
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.edgDocs, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView edgDocs;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
    }
}