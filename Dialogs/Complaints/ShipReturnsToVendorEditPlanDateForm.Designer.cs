namespace WMSOffice.Dialogs.Complaints
{
    partial class ShipReturnsToVendorEditPlanDateForm
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
            this.lblPlanDate = new System.Windows.Forms.Label();
            this.dtpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(67, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(157, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 78);
            this.pnlButtons.Size = new System.Drawing.Size(244, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // lblPlanDate
            // 
            this.lblPlanDate.AutoSize = true;
            this.lblPlanDate.Location = new System.Drawing.Point(12, 30);
            this.lblPlanDate.Name = "lblPlanDate";
            this.lblPlanDate.Size = new System.Drawing.Size(86, 13);
            this.lblPlanDate.TabIndex = 0;
            this.lblPlanDate.Text = "Дата возврата:";
            // 
            // dtpPlanDate
            // 
            this.dtpPlanDate.CustomFormat = "dd.MM.yyyy";
            this.dtpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanDate.Location = new System.Drawing.Point(114, 26);
            this.dtpPlanDate.Name = "dtpPlanDate";
            this.dtpPlanDate.Size = new System.Drawing.Size(100, 20);
            this.dtpPlanDate.TabIndex = 1;
            this.dtpPlanDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpPlanDate_KeyDown);
            // 
            // ShipReturnsToVendorEditPlanDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 121);
            this.Controls.Add(this.lblPlanDate);
            this.Controls.Add(this.dtpPlanDate);
            this.Name = "ShipReturnsToVendorEditPlanDateForm";
            this.Text = "Изменение даты возврата";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShipReturnsToVendorEditPlanDateForm_FormClosing);
            this.Controls.SetChildIndex(this.dtpPlanDate, 0);
            this.Controls.SetChildIndex(this.lblPlanDate, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlanDate;
        private System.Windows.Forms.DateTimePicker dtpPlanDate;
    }
}