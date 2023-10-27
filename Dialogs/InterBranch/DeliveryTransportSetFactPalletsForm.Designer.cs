namespace WMSOffice.Dialogs.InterBranch
{
    partial class DeliveryTransportSetFactPalletsForm
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
            this.lblFactPallets = new System.Windows.Forms.Label();
            this.nudFactPallets = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFactPallets)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-145, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-55, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 78);
            this.pnlButtons.Size = new System.Drawing.Size(244, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // lblFactPallets
            // 
            this.lblFactPallets.AutoSize = true;
            this.lblFactPallets.Location = new System.Drawing.Point(12, 34);
            this.lblFactPallets.Name = "lblFactPallets";
            this.lblFactPallets.Size = new System.Drawing.Size(76, 13);
            this.lblFactPallets.TabIndex = 0;
            this.lblFactPallets.Text = "Факт паллет:";
            // 
            // nudFactPallets
            // 
            this.nudFactPallets.Location = new System.Drawing.Point(94, 30);
            this.nudFactPallets.Name = "nudFactPallets";
            this.nudFactPallets.Size = new System.Drawing.Size(138, 20);
            this.nudFactPallets.TabIndex = 1;
            this.nudFactPallets.ThousandsSeparator = true;
            this.nudFactPallets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudFactPallets_KeyDown);
            // 
            // DeliveryTransportSetFactPalletsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 121);
            this.Controls.Add(this.nudFactPallets);
            this.Controls.Add(this.lblFactPallets);
            this.Name = "DeliveryTransportSetFactPalletsForm";
            this.Text = "Укажите факт паллет в авто";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryTransportSetFactPalletsForm_FormClosing);
            this.Controls.SetChildIndex(this.lblFactPallets, 0);
            this.Controls.SetChildIndex(this.nudFactPallets, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFactPallets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFactPallets;
        private System.Windows.Forms.NumericUpDown nudFactPallets;
    }
}