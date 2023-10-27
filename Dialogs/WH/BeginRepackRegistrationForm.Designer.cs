namespace WMSOffice.Dialogs.WH
{
    partial class BeginRepackRegistrationForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbScanner = new WMSOffice.Controls.TextBoxScaner();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(62, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация на столе перепаковки";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Для регистрации на столе перепаковки\r\nотсканируйте станцию";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbScanner
            // 
            this.tbScanner.AllowType = true;
            this.tbScanner.AutoConvert = true;
            this.tbScanner.Location = new System.Drawing.Point(12, 102);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.RaiseTextChangeWithoutEnter = false;
            this.tbScanner.ReadOnly = false;
            this.tbScanner.Size = new System.Drawing.Size(320, 25);
            this.tbScanner.TabIndex = 6;
            this.tbScanner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanner.UseParentFont = false;
            // 
            // BeginRepackRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 162);
            this.Controls.Add(this.tbScanner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeginRepackRegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "№ задания перепаковки";
            this.Load += new System.EventHandler(this.BeginRepackRegistrationForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BeginRepackRegistrationForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WMSOffice.Controls.TextBoxScaner tbScanner;
    }
}