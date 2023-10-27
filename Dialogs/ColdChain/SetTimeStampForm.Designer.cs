namespace WMSOffice.Dialogs.ColdChain
{
    partial class SetTimeStampForm
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
            this.dtpTimeStamp = new System.Windows.Forms.DateTimePicker();
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
            // dtpTimeStamp
            // 
            this.dtpTimeStamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTimeStamp.CustomFormat = "dd / MM / yyyy HH:mm";
            this.dtpTimeStamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeStamp.Location = new System.Drawing.Point(11, 18);
            this.dtpTimeStamp.Name = "dtpTimeStamp";
            this.dtpTimeStamp.Size = new System.Drawing.Size(200, 20);
            this.dtpTimeStamp.TabIndex = 101;
            this.dtpTimeStamp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpTimeStamp_KeyDown);
            // 
            // SetTimeStampForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 98);
            this.Controls.Add(this.dtpTimeStamp);
            this.Name = "SetTimeStampForm";
            this.Text = "Ввод даты и время акта";
            this.Controls.SetChildIndex(this.dtpTimeStamp, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTimeStamp;
    }
}