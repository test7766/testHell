namespace WMSOffice.Dialogs.Docs
{
    partial class ArchiveInvoicesRegisterSearchForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvRegistry = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2999, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3089, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 432);
            this.pnlButtons.Size = new System.Drawing.Size(1144, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.xdgvRegistry);
            this.pnlContent.Location = new System.Drawing.Point(0, 1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1144, 425);
            this.pnlContent.TabIndex = 101;
            // 
            // xdgvRegistry
            // 
            this.xdgvRegistry.AllowSort = true;
            this.xdgvRegistry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvRegistry.LargeAmountOfData = false;
            this.xdgvRegistry.Location = new System.Drawing.Point(0, 0);
            this.xdgvRegistry.Name = "xdgvRegistry";
            this.xdgvRegistry.RowHeadersVisible = false;
            this.xdgvRegistry.Size = new System.Drawing.Size(1144, 425);
            this.xdgvRegistry.TabIndex = 0;
            this.xdgvRegistry.UserID = ((long)(0));
            // 
            // ArchiveInvoicesRegisterSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 475);
            this.Controls.Add(this.pnlContent);
            this.Name = "ArchiveInvoicesRegisterSearchForm";
            this.Text = "Оберіть реєстр";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiveInvoicesRegisterSearchForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvRegistry;
    }
}