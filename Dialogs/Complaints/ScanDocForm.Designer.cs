namespace WMSOffice.Dialogs.Complaints
{
    partial class ScanDocForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tbScanner = new WMSOffice.Controls.TextBoxScaner();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(200, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 90);
            this.pnlButtons.Size = new System.Drawing.Size(360, 43);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::WMSOffice.Properties.Resources.icon_staff_pick;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(64, 64);
            this.pictureBox.TabIndex = 101;
            this.pictureBox.TabStop = false;
            // 
            // tbScanner
            // 
            this.tbScanner.AllowType = true;
            this.tbScanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScanner.AutoConvert = true;
            this.tbScanner.Location = new System.Drawing.Point(82, 51);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.RaiseTextChangeWithoutEnter = false;
            this.tbScanner.ReadOnly = false;
            this.tbScanner.Size = new System.Drawing.Size(266, 25);
            this.tbScanner.TabIndex = 2;
            this.tbScanner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanner.TextChanged += new System.EventHandler(this.tbScanner_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(82, 12);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(266, 36);
            this.lblDescription.TabIndex = 103;
            this.lblDescription.Text = "Отсканируйте штрих-код документа:";
            // 
            // ScanDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 133);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbScanner);
            this.Name = "ScanDocForm";
            this.Text = "Закрытие претензии";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbScanner, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private WMSOffice.Controls.TextBoxScaner tbScanner;
        private System.Windows.Forms.Label lblDescription;
    }
}