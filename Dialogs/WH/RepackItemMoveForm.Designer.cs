namespace WMSOffice.Dialogs.WH
{
    partial class RepackItemMoveForm
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.tbScanner = new WMSOffice.Controls.TextBoxScaner();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WMSOffice.Properties.Resources.Achtung;
            this.pictureBox2.Location = new System.Drawing.Point(12, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDescription.Location = new System.Drawing.Point(78, 10);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(304, 85);
            this.lblDescription.TabIndex = 2;
            // 
            // lblAction
            // 
            this.lblAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAction.Location = new System.Drawing.Point(9, 115);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(165, 28);
            this.lblAction.TabIndex = 3;
            // 
            // tbScanner
            // 
            this.tbScanner.AllowType = true;
            this.tbScanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbScanner.AutoConvert = true;
            this.tbScanner.Location = new System.Drawing.Point(180, 118);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.RaiseTextChangeWithoutEnter = false;
            this.tbScanner.ReadOnly = false;
            this.tbScanner.Size = new System.Drawing.Size(202, 25);
            this.tbScanner.TabIndex = 7;
            this.tbScanner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            // 
            // RepackItemMoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 152);
            this.Controls.Add(this.tbScanner);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepackItemMoveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "№ задания перепаковки";
            this.Load += new System.EventHandler(this.RepackItemMoveForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RepackItemMoveForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAction;
        private WMSOffice.Controls.TextBoxScaner tbScanner;

    }
}