namespace WMSOffice.Dialogs.Quality
{
    partial class InputControlDeliveryWorksheetCarNumberEditForm 
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCarNumber = new System.Windows.Forms.Label();
            this.lblTrailerNumber = new System.Windows.Forms.Label();
            this.tbCarNumber = new System.Windows.Forms.TextBox();
            this.tbTrailerNumber = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(107, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 68);
            this.pnlButtons.Size = new System.Drawing.Size(284, 43);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.delivery;
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            // 
            // lblCarNumber
            // 
            this.lblCarNumber.AutoSize = true;
            this.lblCarNumber.Location = new System.Drawing.Point(119, 14);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new System.Drawing.Size(47, 13);
            this.lblCarNumber.TabIndex = 0;
            this.lblCarNumber.Text = "№ авто:";
            // 
            // lblTrailerNumber
            // 
            this.lblTrailerNumber.AutoSize = true;
            this.lblTrailerNumber.Location = new System.Drawing.Point(89, 42);
            this.lblTrailerNumber.Name = "lblTrailerNumber";
            this.lblTrailerNumber.Size = new System.Drawing.Size(77, 13);
            this.lblTrailerNumber.TabIndex = 2;
            this.lblTrailerNumber.Text = "№ п/прицепа:";
            // 
            // tbCarNumber
            // 
            this.tbCarNumber.Location = new System.Drawing.Point(172, 10);
            this.tbCarNumber.Name = "tbCarNumber";
            this.tbCarNumber.Size = new System.Drawing.Size(100, 20);
            this.tbCarNumber.TabIndex = 1;
            // 
            // tbTrailerNumber
            // 
            this.tbTrailerNumber.Location = new System.Drawing.Point(172, 38);
            this.tbTrailerNumber.Name = "tbTrailerNumber";
            this.tbTrailerNumber.Size = new System.Drawing.Size(100, 20);
            this.tbTrailerNumber.TabIndex = 3;
            // 
            // InputControlDeliveryWorksheetCarNumberEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.tbTrailerNumber);
            this.Controls.Add(this.tbCarNumber);
            this.Controls.Add(this.lblTrailerNumber);
            this.Controls.Add(this.lblCarNumber);
            this.Controls.Add(this.pictureBox1);
            this.Name = "InputControlDeliveryWorksheetCarNumberEditForm";
            this.Text = "Укажите номер авто / полуприцепа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputControlDeliveryWorksheetUnloadDateEditForm_FormClosing);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.lblCarNumber, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblTrailerNumber, 0);
            this.Controls.SetChildIndex(this.tbCarNumber, 0);
            this.Controls.SetChildIndex(this.tbTrailerNumber, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCarNumber;
        private System.Windows.Forms.Label lblTrailerNumber;
        private System.Windows.Forms.TextBox tbCarNumber;
        private System.Windows.Forms.TextBox tbTrailerNumber;
    }
}