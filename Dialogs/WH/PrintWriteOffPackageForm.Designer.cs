namespace WMSOffice.Dialogs.WH
{
    partial class PrintWriteOffPackageForm
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
            this.tbActNumbers = new System.Windows.Forms.TextBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Закрыть";
            // 
            // tbActNumbers
            // 
            this.tbActNumbers.BackColor = System.Drawing.SystemColors.Window;
            this.tbActNumbers.Location = new System.Drawing.Point(12, 36);
            this.tbActNumbers.Multiline = true;
            this.tbActNumbers.Name = "tbActNumbers";
            this.tbActNumbers.ReadOnly = true;
            this.tbActNumbers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbActNumbers.Size = new System.Drawing.Size(326, 177);
            this.tbActNumbers.TabIndex = 101;
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(13, 13);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(56, 13);
            this.lblPrinter.TabIndex = 102;
            this.lblPrinter.Text = "Принтер: ";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(75, 9);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(263, 21);
            this.cmbPrinters.TabIndex = 103;
            // 
            // PrintWriteOffPackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 262);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.cmbPrinters);
            this.Controls.Add(this.tbActNumbers);
            this.Name = "PrintWriteOffPackageForm";
            this.Text = "Пакетная печать актов списания";
            this.Load += new System.EventHandler(this.PrintWriteOffPackageForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintWriteOffPackageForm_FormClosing);
            this.Controls.SetChildIndex(this.tbActNumbers, 0);
            this.Controls.SetChildIndex(this.cmbPrinters, 0);
            this.Controls.SetChildIndex(this.lblPrinter, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbActNumbers;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.ComboBox cmbPrinters;
    }
}