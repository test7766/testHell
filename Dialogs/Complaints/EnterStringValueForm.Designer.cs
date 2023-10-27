namespace WMSOffice.Dialogs.Complaints
{
    partial class EnterStringValueForm
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
            this.lblPromt = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(86, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 129);
            this.pnlButtons.Size = new System.Drawing.Size(263, 43);
            // 
            // lblPromt
            // 
            this.lblPromt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPromt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPromt.Location = new System.Drawing.Point(12, 9);
            this.lblPromt.Name = "lblPromt";
            this.lblPromt.Size = new System.Drawing.Size(239, 60);
            this.lblPromt.TabIndex = 101;
            this.lblPromt.Text = "Promt\r\na\r\nb";
            this.lblPromt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbValue
            // 
            this.tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbValue.Location = new System.Drawing.Point(16, 72);
            this.tbValue.MaxLength = 500;
            this.tbValue.Multiline = true;
            this.tbValue.Name = "tbValue";
            this.tbValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbValue.Size = new System.Drawing.Size(235, 51);
            this.tbValue.TabIndex = 102;
            this.tbValue.Text = "Value";
            // 
            // EnterStringValueForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 172);
            this.Controls.Add(this.lblPromt);
            this.Controls.Add(this.tbValue);
            this.Name = "EnterStringValueForm";
            this.Text = "Caption";
            this.Shown += new System.EventHandler(this.EnterStringValueForm_Shown);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbValue, 0);
            this.Controls.SetChildIndex(this.lblPromt, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lblPromt;
    }
}