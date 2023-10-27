namespace WMSOffice.Dialogs.Receive
{
    partial class PalletsAccountingForm
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
            this.palletsAccountingSummaryControl = new WMSOffice.Controls.Receive.Pallets.PalletsAccountingSummaryControl();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(695, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(785, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(524, 43);
            // 
            // palletsAccountingSummaryControl
            // 
            this.palletsAccountingSummaryControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.palletsAccountingSummaryControl.Location = new System.Drawing.Point(0, 1);
            this.palletsAccountingSummaryControl.Name = "palletsAccountingSummaryControl";
            this.palletsAccountingSummaryControl.Size = new System.Drawing.Size(524, 212);
            this.palletsAccountingSummaryControl.TabIndex = 101;
            // 
            // PalletsAccountingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 262);
            this.Controls.Add(this.palletsAccountingSummaryControl);
            this.Name = "PalletsAccountingForm";
            this.Text = "Возврат паллет поставщику";
            this.Load += new System.EventHandler(this.PalletsAccountingForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PalletsAccountingForm_FormClosing);
            this.Controls.SetChildIndex(this.palletsAccountingSummaryControl, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WMSOffice.Controls.Receive.Pallets.PalletsAccountingSummaryControl palletsAccountingSummaryControl;
    }
}