namespace WMSOffice.Dialogs.Docs
{
    partial class ArchiveInvoicesRegisterCloseForm
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
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cmbClosePeriodMonth = new System.Windows.Forms.ComboBox();
            this.nudClosePeriod = new System.Windows.Forms.NumericUpDown();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouseKey = new System.Windows.Forms.Label();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClosePeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(95, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 82);
            this.pnlButtons.Size = new System.Drawing.Size(294, 43);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(12, 9);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(45, 13);
            this.lblPeriod.TabIndex = 101;
            this.lblPeriod.Text = "Місяць:";
            // 
            // cmbClosePeriodMonth
            // 
            this.cmbClosePeriodMonth.BackColor = System.Drawing.SystemColors.Window;
            this.cmbClosePeriodMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClosePeriodMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbClosePeriodMonth.FormattingEnabled = true;
            this.cmbClosePeriodMonth.Items.AddRange(new object[] {
            "січень",
            "лютий",
            "березень",
            "квітень",
            "травень",
            "червень",
            "липень",
            "серпень",
            "вересень",
            "жовтень",
            "листопад",
            "грудень"});
            this.cmbClosePeriodMonth.Location = new System.Drawing.Point(63, 5);
            this.cmbClosePeriodMonth.Name = "cmbClosePeriodMonth";
            this.cmbClosePeriodMonth.Size = new System.Drawing.Size(95, 21);
            this.cmbClosePeriodMonth.TabIndex = 105;
            // 
            // nudClosePeriod
            // 
            this.nudClosePeriod.BackColor = System.Drawing.SystemColors.Window;
            this.nudClosePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudClosePeriod.Location = new System.Drawing.Point(161, 5);
            this.nudClosePeriod.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudClosePeriod.Minimum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.nudClosePeriod.Name = "nudClosePeriod";
            this.nudClosePeriod.Size = new System.Drawing.Size(60, 20);
            this.nudClosePeriod.TabIndex = 104;
            this.nudClosePeriod.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(63, 34);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.NavigateByValue = false;
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(95, 20);
            this.stbWarehouse.TabIndex = 106;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // lblWarehouseKey
            // 
            this.lblWarehouseKey.AutoSize = true;
            this.lblWarehouseKey.Location = new System.Drawing.Point(12, 38);
            this.lblWarehouseKey.Name = "lblWarehouseKey";
            this.lblWarehouseKey.Size = new System.Drawing.Size(43, 13);
            this.lblWarehouseKey.TabIndex = 107;
            this.lblWarehouseKey.Text = "Філіал:";
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.AutoSize = true;
            this.lblWarehouseName.Location = new System.Drawing.Point(60, 57);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseName.TabIndex = 108;
            // 
            // ArchiveInvoicesRegisterCloseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 125);
            this.Controls.Add(this.lblWarehouseName);
            this.Controls.Add(this.lblWarehouseKey);
            this.Controls.Add(this.stbWarehouse);
            this.Controls.Add(this.cmbClosePeriodMonth);
            this.Controls.Add(this.nudClosePeriod);
            this.Controls.Add(this.lblPeriod);
            this.Name = "ArchiveInvoicesRegisterCloseForm";
            this.Text = "Закрити період";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiveInvoicesRegisterCloseForm_FormClosing);
            this.Controls.SetChildIndex(this.lblPeriod, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.nudClosePeriod, 0);
            this.Controls.SetChildIndex(this.cmbClosePeriodMonth, 0);
            this.Controls.SetChildIndex(this.stbWarehouse, 0);
            this.Controls.SetChildIndex(this.lblWarehouseKey, 0);
            this.Controls.SetChildIndex(this.lblWarehouseName, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudClosePeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.ComboBox cmbClosePeriodMonth;
        private System.Windows.Forms.NumericUpDown nudClosePeriod;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.Label lblWarehouseKey;
        private System.Windows.Forms.Label lblWarehouseName;
    }
}