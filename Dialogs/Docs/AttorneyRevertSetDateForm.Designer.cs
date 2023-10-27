namespace WMSOffice.Dialogs.Docs
{
    partial class AttorneyRevertSetDateForm
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
            this.dtpRevertDate = new System.Windows.Forms.DateTimePicker();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(67, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(157, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 78);
            this.pnlButtons.Size = new System.Drawing.Size(244, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // dtpRevertDate
            // 
            this.dtpRevertDate.CustomFormat = "dd.MM.yyyy";
            this.dtpRevertDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRevertDate.Location = new System.Drawing.Point(128, 40);
            this.dtpRevertDate.Name = "dtpRevertDate";
            this.dtpRevertDate.Size = new System.Drawing.Size(100, 20);
            this.dtpRevertDate.TabIndex = 1;
            // 
            // pbImage
            // 
            this.pbImage.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.pbImage.Location = new System.Drawing.Point(12, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(48, 48);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImage.TabIndex = 2;
            this.pbImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата \r\nотзыва:";
            // 
            // AttorneyRevertSetDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 121);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpRevertDate);
            this.Name = "AttorneyRevertSetDateForm";
            this.Text = "Отзыв доверенности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttorneyRevertSetDateForm_FormClosing);
            this.Controls.SetChildIndex(this.dtpRevertDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pbImage, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpRevertDate;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label label1;
    }
}