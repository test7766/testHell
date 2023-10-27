namespace WMSOffice.Dialogs.WH
{
    partial class PrintingDeviceEditorForm
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
            this.lblIP = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-29, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(61, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 57);
            this.pnlButtons.Size = new System.Drawing.Size(249, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(15, 20);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(59, 13);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP-адреса:";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(80, 16);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 1;
            this.tbIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbIP_KeyDown);
            // 
            // PrintingDeviceEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 100);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.tbIP);
            this.Name = "PrintingDeviceEditorForm";
            this.Text = "Налаштування пристрою";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintingDeviceEditorForm_FormClosing);
            this.Controls.SetChildIndex(this.tbIP, 0);
            this.Controls.SetChildIndex(this.lblIP, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox tbIP;
    }
}