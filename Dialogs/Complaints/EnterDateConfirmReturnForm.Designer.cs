namespace WMSOffice.Dialogs.Complaints
{
    partial class EnterDateConfirmReturnForm
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
            this.dtpValue = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblPromt
            // 
            this.lblPromt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPromt.Location = new System.Drawing.Point(12, 9);
            this.lblPromt.Name = "lblPromt";
            this.lblPromt.Size = new System.Drawing.Size(297, 92);
            this.lblPromt.TabIndex = 105;
            this.lblPromt.Text = "Введите дату расчет-корректировки\r\n(она же - дата дата получения товара складом):" +
                "";
            this.lblPromt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpValue
            // 
            this.dtpValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpValue.Location = new System.Drawing.Point(65, 105);
            this.dtpValue.Name = "dtpValue";
            this.dtpValue.Size = new System.Drawing.Size(200, 24);
            this.dtpValue.TabIndex = 106;
            this.dtpValue.Value = new System.DateTime(2010, 9, 15, 16, 52, 0, 0);
            // 
            // EnterDateConfirmReturnForm
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 187);
            this.Controls.Add(this.dtpValue);
            this.Controls.Add(this.lblPromt);
            this.Name = "EnterDateConfirmReturnForm";
            this.Text = "Дата расчет-корректировки";
            this.Shown += new System.EventHandler(this.EnterDateConfirmReturnForm_Shown);
            this.Controls.SetChildIndex(this.lblPromt, 0);
            this.Controls.SetChildIndex(this.dtpValue, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPromt;
        private System.Windows.Forms.DateTimePicker dtpValue;

    }
}