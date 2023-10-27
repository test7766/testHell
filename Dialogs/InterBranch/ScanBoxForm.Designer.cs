namespace WMSOffice.Dialogs.Containers
{
    partial class ScanBoxForm
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
            this.tbScanner = new WMSOffice.Controls.TextBoxScaner();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.box;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // tbScanner
            // 
            this.tbScanner.AllowType = true;
            this.tbScanner.AutoConvert = true;
            this.tbScanner.Location = new System.Drawing.Point(114, 52);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.Size = new System.Drawing.Size(238, 25);
            this.tbScanner.TabIndex = 5;
            this.tbScanner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanner.TextChanged += new System.EventHandler(this.tbScanner_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(115, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 16);
            this.label1.TabIndex = 103;
            this.label1.Text = "Отсканируйте штрих код ящика:";
            // 
            // ScanBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 152);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbScanner);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ScanBoxForm";
            this.Text = "Сканирование ящика";
            this.Shown += new System.EventHandler(this.ScanContainerForm_Shown);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tbScanner, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private WMSOffice.Controls.TextBoxScaner tbScanner;
        private System.Windows.Forms.Label label1;
    }
}