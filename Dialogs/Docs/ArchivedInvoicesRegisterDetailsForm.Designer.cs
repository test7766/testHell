namespace WMSOffice.Dialogs.Docs
{
    partial class ArchivedInvoicesRegisterDetailsForm
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
            this.xdgvRegistryDetails = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4587, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4677, 8);
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
            this.pnlContent.Controls.Add(this.xdgvRegistryDetails);
            this.pnlContent.Location = new System.Drawing.Point(0, 1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1144, 425);
            this.pnlContent.TabIndex = 101;
            // 
            // xdgvRegistryDetails
            // 
            this.xdgvRegistryDetails.AllowSort = true;
            this.xdgvRegistryDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvRegistryDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvRegistryDetails.LargeAmountOfData = false;
            this.xdgvRegistryDetails.Location = new System.Drawing.Point(0, 0);
            this.xdgvRegistryDetails.Name = "xdgvRegistryDetails";
            this.xdgvRegistryDetails.RowHeadersVisible = false;
            this.xdgvRegistryDetails.Size = new System.Drawing.Size(1144, 425);
            this.xdgvRegistryDetails.TabIndex = 0;
            this.xdgvRegistryDetails.UserID = ((long)(0));
            // 
            // ArchivedInvoicesRegisterDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 475);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "ArchivedInvoicesRegisterDetailsForm";
            this.Text = "Склад реєстру";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvRegistryDetails;
    }
}