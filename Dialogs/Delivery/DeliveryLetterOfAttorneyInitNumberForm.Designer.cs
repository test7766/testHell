namespace WMSOffice.Dialogs.Delivery
{
    partial class DeliveryLetterOfAttorneyInitNumberForm
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
            this.tbInitNumber = new System.Windows.Forms.TextBox();
            this.lblInitNumber = new System.Windows.Forms.Label();
            this.pbInitNumber = new System.Windows.Forms.PictureBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInitNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(95, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 79);
            this.pnlButtons.Size = new System.Drawing.Size(294, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // tbInitNumber
            // 
            this.tbInitNumber.Location = new System.Drawing.Point(85, 56);
            this.tbInitNumber.Name = "tbInitNumber";
            this.tbInitNumber.Size = new System.Drawing.Size(197, 20);
            this.tbInitNumber.TabIndex = 0;
            this.tbInitNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInitNumber_KeyDown);
            this.tbInitNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // lblInitNumber
            // 
            this.lblInitNumber.Location = new System.Drawing.Point(82, 12);
            this.lblInitNumber.Name = "lblInitNumber";
            this.lblInitNumber.Size = new System.Drawing.Size(200, 41);
            this.lblInitNumber.TabIndex = 102;
            this.lblInitNumber.Text = "Укажите номер доверенности, \r\nс которой начнется печать:";
            // 
            // pbInitNumber
            // 
            this.pbInitNumber.Image = global::WMSOffice.Properties.Resources.document_new;
            this.pbInitNumber.Location = new System.Drawing.Point(12, 12);
            this.pbInitNumber.Name = "pbInitNumber";
            this.pbInitNumber.Size = new System.Drawing.Size(64, 64);
            this.pbInitNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbInitNumber.TabIndex = 103;
            this.pbInitNumber.TabStop = false;
            // 
            // DeliveryLetterOfAttorneyInitNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 122);
            this.Controls.Add(this.lblInitNumber);
            this.Controls.Add(this.pbInitNumber);
            this.Controls.Add(this.tbInitNumber);
            this.Name = "DeliveryLetterOfAttorneyInitNumberForm";
            this.Text = "Инициализация номера доверенности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryLetterOfAttorneyInitNumberForm_FormClosing);
            this.Controls.SetChildIndex(this.tbInitNumber, 0);
            this.Controls.SetChildIndex(this.pbInitNumber, 0);
            this.Controls.SetChildIndex(this.lblInitNumber, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInitNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInitNumber;
        private System.Windows.Forms.Label lblInitNumber;
        private System.Windows.Forms.PictureBox pbInitNumber;
    }
}