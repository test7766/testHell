namespace WMSOffice.Dialogs.Containers
{
    partial class ScanContainerForm
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tbScanner = new WMSOffice.Controls.TextBoxScaner();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(211, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(301, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 139);
            this.pnlButtons.Size = new System.Drawing.Size(388, 43);
            // 
            // pbImage
            // 
            this.pbImage.Image = global::WMSOffice.Properties.Resources.paper_box;
            this.pbImage.Location = new System.Drawing.Point(12, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(128, 128);
            this.pbImage.TabIndex = 101;
            this.pbImage.TabStop = false;
            // 
            // tbScanner
            // 
            this.tbScanner.AllowType = true;
            this.tbScanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScanner.AutoConvert = true;
            this.tbScanner.DelayThreshold = 50;
            this.tbScanner.Location = new System.Drawing.Point(147, 100);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.RaiseTextChangeWithoutEnter = false;
            this.tbScanner.ReadOnly = false;
            this.tbScanner.ScannerListener = null;
            this.tbScanner.Size = new System.Drawing.Size(229, 25);
            this.tbScanner.TabIndex = 5;
            this.tbScanner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanner.UseParentFont = false;
            this.tbScanner.UseScanModeOnly = false;
            this.tbScanner.TextChanged += new System.EventHandler(this.tbScanner_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(147, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 58);
            this.label1.TabIndex = 103;
            this.label1.Text = "Отсканируйте штрих код пластикового контейнера, в который был собран проконтролир" +
                "ованный товар:";
            // 
            // ScanContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 182);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbScanner);
            this.Controls.Add(this.pbImage);
            this.Name = "ScanContainerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сканирование контейнера";
            this.Shown += new System.EventHandler(this.ScanContainerForm_Shown);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pbImage, 0);
            this.Controls.SetChildIndex(this.tbScanner, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private WMSOffice.Controls.TextBoxScaner tbScanner;
        private System.Windows.Forms.Label label1;
    }
}