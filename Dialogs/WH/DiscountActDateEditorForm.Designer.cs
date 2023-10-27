namespace WMSOffice.Dialogs.WH
{
    partial class DiscountActDateEditorForm
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
            this.dtActDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-78, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 62);
            this.pnlButtons.Size = new System.Drawing.Size(222, 43);
            // 
            // dtExpDate
            // 
            this.dtActDate.CustomFormat = "dd / MM / yyyy";
            this.dtActDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtActDate.Location = new System.Drawing.Point(70, 21);
            this.dtActDate.Name = "dtExpDate";
            this.dtActDate.Size = new System.Drawing.Size(146, 20);
            this.dtActDate.TabIndex = 101;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.pictureBox1.Location = new System.Drawing.Point(4, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            // 
            // DiscountActDateEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 105);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtActDate);
            this.Name = "DiscountActDateEditorForm";
            this.Text = "Укажите дату акта";
            this.Controls.SetChildIndex(this.dtActDate, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtActDate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}