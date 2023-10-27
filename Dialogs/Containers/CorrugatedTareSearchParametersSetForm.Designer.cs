namespace WMSOffice.Dialogs.Containers
{
    partial class CorrugatedTareSearchParametersSetForm
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
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(561, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(651, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 128);
            this.pnlButtons.Size = new System.Drawing.Size(544, 43);
            this.pnlButtons.TabIndex = 7;
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(12, 55);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(67, 13);
            this.lblPeriodFrom.TabIndex = 3;
            this.lblPeriodFrom.Text = "Период \"с\":";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(85, 51);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 4;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(12, 84);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(73, 13);
            this.lblPeriodTo.TabIndex = 5;
            this.lblPeriodTo.Text = "Период \"по\":";
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(85, 80);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 6;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 18);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Склад:";
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(85, 14);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouse.TabIndex = 1;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarehouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouse.Location = new System.Drawing.Point(191, 14);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.ReadOnly = true;
            this.tbWarehouse.Size = new System.Drawing.Size(341, 20);
            this.tbWarehouse.TabIndex = 2;
            // 
            // CorrugatedTareSearchParametersSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(544, 171);
            this.Controls.Add(this.tbWarehouse);
            this.Controls.Add(this.stbWarehouse);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.dtpPeriodTo);
            this.Controls.Add(this.lblPeriodFrom);
            this.Controls.Add(this.dtpPeriodFrom);
            this.Name = "CorrugatedTareSearchParametersSetForm";
            this.Text = "Параметры поиска гофротары";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CorrugatedTareSearchParametersSetForm_FormClosing);
            this.Controls.SetChildIndex(this.dtpPeriodFrom, 0);
            this.Controls.SetChildIndex(this.lblPeriodFrom, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dtpPeriodTo, 0);
            this.Controls.SetChildIndex(this.lblPeriodTo, 0);
            this.Controls.SetChildIndex(this.lblWarehouse, 0);
            this.Controls.SetChildIndex(this.stbWarehouse, 0);
            this.Controls.SetChildIndex(this.tbWarehouse, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		
		#endregion

         private System.Windows.Forms.Label lblPeriodFrom;
         private System.Windows.Forms.Label lblPeriodTo;
         private System.Windows.Forms.DateTimePicker dtpPeriodTo;
         private System.Windows.Forms.Label lblWarehouse;
         private WMSOffice.Controls.SearchTextBox stbWarehouse;
         private System.Windows.Forms.TextBox tbWarehouse;
         private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
	}
}