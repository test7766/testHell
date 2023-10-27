namespace WMSOffice.Dialogs.ColdChain
{
    partial class ScanBarCodeForm
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbScanner = new WMSOffice.Controls.TextBoxScaner();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAbort);
            this.pnlButtons.Location = new System.Drawing.Point(0, 89);
            this.pnlButtons.Size = new System.Drawing.Size(368, 43);
            this.pnlButtons.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnOK, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnAbort, 0);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(97, 11);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(202, 39);
            this.lblDescription.TabIndex = 102;
            this.lblDescription.Text = "Отсканируйте штрих-код термоконтейнера, в который будет положен проконтролированы" +
                "й товар.";
            // 
            // tbScanner
            // 
            this.tbScanner.AllowType = true;
            this.tbScanner.AutoConvert = true;
            this.tbScanner.Location = new System.Drawing.Point(96, 56);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.ReadOnly = false;
            this.tbScanner.Size = new System.Drawing.Size(265, 25);
            this.tbScanner.TabIndex = 103;
            this.tbScanner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.cold_chain_icon_75;
            this.pictureBox1.Location = new System.Drawing.Point(10, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAbort.ForeColor = System.Drawing.Color.Red;
            this.btnAbort.Location = new System.Drawing.Point(12, 8);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 2;
            this.btnAbort.Text = "Завершить";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // ScanBarCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 132);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbScanner);
            this.Controls.Add(this.lblDescription);
            this.Name = "ScanBarCodeForm";
            this.Text = "Погрузка товара в термоконтейнер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanTermoBoxForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.tbScanner, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label lblDescription;
        private WMSOffice.Controls.TextBoxScaner tbScanner;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAbort;
    }
}