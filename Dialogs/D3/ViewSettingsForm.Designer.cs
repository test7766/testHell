namespace WMSOffice.Dialogs.D3
{
    partial class ViewSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.maxBitmapSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maxBitmapSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 26);
            this.label1.TabIndex = 101;
            this.label1.Text = "Максимальный размер буфера \r\nдля построения изображения (байты):";
            // 
            // maxBitmapSize
            // 
            this.maxBitmapSize.Location = new System.Drawing.Point(216, 15);
            this.maxBitmapSize.Maximum = new decimal(new int[] {
            67108864,
            0,
            0,
            0});
            this.maxBitmapSize.Minimum = new decimal(new int[] {
            102400,
            0,
            0,
            0});
            this.maxBitmapSize.Name = "maxBitmapSize";
            this.maxBitmapSize.Size = new System.Drawing.Size(156, 20);
            this.maxBitmapSize.TabIndex = 102;
            this.maxBitmapSize.Value = new decimal(new int[] {
            16777216,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(213, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 26);
            this.label2.TabIndex = 103;
            this.label2.Text = "(от 102 400 до 67 108 864, \r\nрекомендовано 16 777 216)";
            // 
            // ViewSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 118);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxBitmapSize);
            this.Name = "ViewSettingsForm";
            this.Text = "Настройки";
            this.Controls.SetChildIndex(this.maxBitmapSize, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.maxBitmapSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maxBitmapSize;
        private System.Windows.Forms.Label label2;
    }
}