namespace WMSOffice.Dialogs.InterBranch
{
    partial class DeliveryTransportSetVolumeForm
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
            this.lblVolume = new System.Windows.Forms.Label();
            this.nudVolume = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-251, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-161, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 78);
            this.pnlButtons.Size = new System.Drawing.Size(244, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(12, 34);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(65, 13);
            this.lblVolume.TabIndex = 0;
            this.lblVolume.Text = "Объем, м³ :";
            // 
            // nudVolume
            // 
            this.nudVolume.DecimalPlaces = 4;
            this.nudVolume.Location = new System.Drawing.Point(94, 30);
            this.nudVolume.Name = "nudVolume";
            this.nudVolume.Size = new System.Drawing.Size(138, 20);
            this.nudVolume.TabIndex = 1;
            this.nudVolume.ThousandsSeparator = true;
            this.nudVolume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudFactPallets_KeyDown);
            // 
            // DeliveryTransportSetFactPalletsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 121);
            this.Controls.Add(this.nudVolume);
            this.Controls.Add(this.lblVolume);
            this.Name = "DeliveryTransportSetFactPalletsForm";
            this.Text = "Укажите объем";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryTransportSetVolumeForm_FormClosing);
            this.Controls.SetChildIndex(this.lblVolume, 0);
            this.Controls.SetChildIndex(this.nudVolume, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.NumericUpDown nudVolume;
    }
}