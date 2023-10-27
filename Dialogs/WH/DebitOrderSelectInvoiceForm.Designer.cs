namespace WMSOffice.Dialogs.WH
{
    partial class DebitOrderSelectInvoiceForm
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
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.btnExportToPDF = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlButtons.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(567, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(657, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 382);
            this.pnlButtons.Size = new System.Drawing.Size(744, 43);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPreview,
            this.btnExportToPDF});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(744, 39);
            this.tsMain.TabIndex = 101;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::WMSOffice.Properties.Resources.preview;
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(98, 36);
            this.btnPreview.Text = "Просмотр\nдокумента";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.btnExportToPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(129, 36);
            this.btnExportToPDF.Text = "Экспорт\nдокумента в PDF";
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.xdgvDocs);
            this.pnlContent.Location = new System.Drawing.Point(0, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(744, 334);
            this.pnlContent.TabIndex = 102;
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.AllowSort = true;
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 0);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(744, 334);
            this.xdgvDocs.TabIndex = 0;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // DebitOrderSelectInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 425);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "DebitOrderSelectInvoiceForm";
            this.Text = "Выбрать накладную";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebitOrderSelectInvoiceForm_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripButton btnExportToPDF;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
    }
}