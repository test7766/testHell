namespace WMSOffice.Dialogs.Complaints
{
    partial class ShipReturnsToVendorFindForm
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
            this.lblDocNumberJDE = new System.Windows.Forms.Label();
            this.tbDocNumberJDE = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
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
            // lblDocNumberJDE
            // 
            this.lblDocNumberJDE.AutoSize = true;
            this.lblDocNumberJDE.Location = new System.Drawing.Point(12, 30);
            this.lblDocNumberJDE.Name = "lblDocNumberJDE";
            this.lblDocNumberJDE.Size = new System.Drawing.Size(111, 13);
            this.lblDocNumberJDE.TabIndex = 0;
            this.lblDocNumberJDE.Text = "Номер док-та в JDE:";
            // 
            // tbDocNumberJDE
            // 
            this.tbDocNumberJDE.Location = new System.Drawing.Point(132, 26);
            this.tbDocNumberJDE.Name = "tbDocNumberJDE";
            this.tbDocNumberJDE.Size = new System.Drawing.Size(100, 20);
            this.tbDocNumberJDE.TabIndex = 1;
            this.tbDocNumberJDE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDocNumberJDE_KeyDown);
            // 
            // ShipReturnsToVendorFindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 121);
            this.Controls.Add(this.lblDocNumberJDE);
            this.Controls.Add(this.tbDocNumberJDE);
            this.Name = "ShipReturnsToVendorFindForm";
            this.Text = "Поиск возврата";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShipReturnsToVendorFindForm_FormClosing);
            this.Controls.SetChildIndex(this.tbDocNumberJDE, 0);
            this.Controls.SetChildIndex(this.lblDocNumberJDE, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDocNumberJDE;
        private System.Windows.Forms.TextBox tbDocNumberJDE;
    }
}