namespace WMSOffice.Dialogs.Quality
{
    partial class QualityUtilizationReportsSearchForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSupplier = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBatchNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbAllowUtilizationVolumeMethodsReports = new System.Windows.Forms.CheckBox();
            this.cbAllowTransferToUtilizationReports = new System.Windows.Forms.CheckBox();
            this.cbAllowUsageProhibitionReports = new System.Windows.Forms.CheckBox();
            this.cbSearchLastActiveReports = new System.Windows.Forms.CheckBox();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(169, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(259, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 349);
            this.pnlButtons.Size = new System.Drawing.Size(349, 43);
            this.pnlButtons.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSupplier);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbBatchNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbVendorLot);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbItemID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 138);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Состав отчета";
            // 
            // tbSupplier
            // 
            this.tbSupplier.Location = new System.Drawing.Point(75, 100);
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.Size = new System.Drawing.Size(245, 20);
            this.tbSupplier.TabIndex = 7;
            this.tbSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Поставщик";
            // 
            // tbBatchNumber
            // 
            this.tbBatchNumber.Location = new System.Drawing.Point(75, 74);
            this.tbBatchNumber.Name = "tbBatchNumber";
            this.tbBatchNumber.Size = new System.Drawing.Size(245, 20);
            this.tbBatchNumber.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Партия";
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.Location = new System.Drawing.Point(75, 48);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.Size = new System.Drawing.Size(245, 20);
            this.tbVendorLot.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Серия";
            // 
            // tbItemID
            // 
            this.tbItemID.Location = new System.Drawing.Point(75, 22);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.Size = new System.Drawing.Size(245, 20);
            this.tbItemID.TabIndex = 1;
            this.tbItemID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код товара";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAllowUtilizationVolumeMethodsReports);
            this.groupBox2.Controls.Add(this.cbAllowTransferToUtilizationReports);
            this.groupBox2.Controls.Add(this.cbAllowUsageProhibitionReports);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(12, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип отчета";
            // 
            // cbAllowUtilizationVolumeMethodsReports
            // 
            this.cbAllowUtilizationVolumeMethodsReports.AutoSize = true;
            this.cbAllowUtilizationVolumeMethodsReports.Checked = true;
            this.cbAllowUtilizationVolumeMethodsReports.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllowUtilizationVolumeMethodsReports.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAllowUtilizationVolumeMethodsReports.Location = new System.Drawing.Point(9, 65);
            this.cbAllowUtilizationVolumeMethodsReports.Name = "cbAllowUtilizationVolumeMethodsReports";
            this.cbAllowUtilizationVolumeMethodsReports.Size = new System.Drawing.Size(180, 17);
            this.cbAllowUtilizationVolumeMethodsReports.TabIndex = 2;
            this.cbAllowUtilizationVolumeMethodsReports.Text = "Объем и методы уничтожения";
            this.cbAllowUtilizationVolumeMethodsReports.UseVisualStyleBackColor = true;
            // 
            // cbAllowTransferToUtilizationReports
            // 
            this.cbAllowTransferToUtilizationReports.AutoSize = true;
            this.cbAllowTransferToUtilizationReports.Checked = true;
            this.cbAllowTransferToUtilizationReports.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllowTransferToUtilizationReports.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAllowTransferToUtilizationReports.Location = new System.Drawing.Point(9, 42);
            this.cbAllowTransferToUtilizationReports.Name = "cbAllowTransferToUtilizationReports";
            this.cbAllowTransferToUtilizationReports.Size = new System.Drawing.Size(184, 17);
            this.cbAllowTransferToUtilizationReports.TabIndex = 1;
            this.cbAllowTransferToUtilizationReports.Text = "ЛС переданные на утилизацию";
            this.cbAllowTransferToUtilizationReports.UseVisualStyleBackColor = true;
            // 
            // cbAllowUsageProhibitionReports
            // 
            this.cbAllowUsageProhibitionReports.AutoSize = true;
            this.cbAllowUsageProhibitionReports.Checked = true;
            this.cbAllowUsageProhibitionReports.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllowUsageProhibitionReports.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAllowUsageProhibitionReports.Location = new System.Drawing.Point(9, 19);
            this.cbAllowUsageProhibitionReports.Name = "cbAllowUsageProhibitionReports";
            this.cbAllowUsageProhibitionReports.Size = new System.Drawing.Size(207, 17);
            this.cbAllowUsageProhibitionReports.TabIndex = 0;
            this.cbAllowUsageProhibitionReports.Text = "ЛС не подлежащие использованию";
            this.cbAllowUsageProhibitionReports.UseVisualStyleBackColor = true;
            // 
            // cbSearchLastActiveReports
            // 
            this.cbSearchLastActiveReports.AutoSize = true;
            this.cbSearchLastActiveReports.Checked = true;
            this.cbSearchLastActiveReports.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSearchLastActiveReports.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSearchLastActiveReports.Location = new System.Drawing.Point(21, 325);
            this.cbSearchLastActiveReports.Name = "cbSearchLastActiveReports";
            this.cbSearchLastActiveReports.Size = new System.Drawing.Size(255, 17);
            this.cbSearchLastActiveReports.TabIndex = 9;
            this.cbSearchLastActiveReports.Text = "Отображать последние действующие отчеты";
            this.cbSearchLastActiveReports.UseVisualStyleBackColor = true;
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.Location = new System.Drawing.Point(87, 11);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.Size = new System.Drawing.Size(245, 20);
            this.tbDocNumber.TabIndex = 1;
            this.tbDocNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(18, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "№ заявки";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(18, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Периоды";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.Checked = false;
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(101, 38);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.ShowCheckBox = true;
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 4;
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(232, 38);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.ShowCheckBox = true;
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(209, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "по";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(84, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "с";
            // 
            // QualityUtilizationReportsSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 392);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpPeriodTo);
            this.Controls.Add(this.dtpPeriodFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbDocNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbSearchLastActiveReports);
            this.Name = "QualityUtilizationReportsSearchForm";
            this.Text = "Критерии поиска отчетов утилизации ЛС";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityUtilizationReportsSearchForm_FormClosing);
            this.Controls.SetChildIndex(this.cbSearchLastActiveReports, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tbDocNumber, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dtpPeriodFrom, 0);
            this.Controls.SetChildIndex(this.dtpPeriodTo, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.pnlButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBatchNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbVendorLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbAllowUtilizationVolumeMethodsReports;
        private System.Windows.Forms.CheckBox cbAllowTransferToUtilizationReports;
        private System.Windows.Forms.CheckBox cbAllowUsageProhibitionReports;
        private System.Windows.Forms.CheckBox cbSearchLastActiveReports;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}