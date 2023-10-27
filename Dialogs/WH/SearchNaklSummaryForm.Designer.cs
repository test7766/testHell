namespace WMSOffice.Dialogs.WH
{
    partial class SearchNaklSummaryForm
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
            this.lblSNukl = new System.Windows.Forms.Label();
            this.tbxSNukl = new System.Windows.Forms.TextBox();
            this.lblNaklNumber = new System.Windows.Forms.Label();
            this.tbxNuklNumber = new System.Windows.Forms.TextBox();
            this.gbPrinted = new System.Windows.Forms.GroupBox();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.rbtPrinted = new System.Windows.Forms.RadioButton();
            this.rbtNotPrinted = new System.Windows.Forms.RadioButton();
            this.lblDebtorId = new System.Windows.Forms.Label();
            this.tbxDebtorId = new System.Windows.Forms.TextBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.chbDateFilter = new System.Windows.Forms.CheckBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.gbPrinted.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSNukl
            // 
            this.lblSNukl.AutoSize = true;
            this.lblSNukl.Location = new System.Drawing.Point(222, 9);
            this.lblSNukl.Name = "lblSNukl";
            this.lblSNukl.Size = new System.Drawing.Size(165, 13);
            this.lblSNukl.TabIndex = 2;
            this.lblSNukl.Text = "По номеру сводной налоговой:";
            // 
            // tbxSNukl
            // 
            this.tbxSNukl.Location = new System.Drawing.Point(225, 25);
            this.tbxSNukl.Name = "tbxSNukl";
            this.tbxSNukl.Size = new System.Drawing.Size(174, 20);
            this.tbxSNukl.TabIndex = 2;
            // 
            // lblNaklNumber
            // 
            this.lblNaklNumber.AutoSize = true;
            this.lblNaklNumber.Location = new System.Drawing.Point(12, 60);
            this.lblNaklNumber.Name = "lblNaklNumber";
            this.lblNaklNumber.Size = new System.Drawing.Size(121, 13);
            this.lblNaklNumber.TabIndex = 4;
            this.lblNaklNumber.Text = "По номеру накладной:";
            // 
            // tbxNuklNumber
            // 
            this.tbxNuklNumber.Location = new System.Drawing.Point(15, 76);
            this.tbxNuklNumber.Name = "tbxNuklNumber";
            this.tbxNuklNumber.Size = new System.Drawing.Size(168, 20);
            this.tbxNuklNumber.TabIndex = 3;
            // 
            // gbPrinted
            // 
            this.gbPrinted.Controls.Add(this.rbtAll);
            this.gbPrinted.Controls.Add(this.rbtPrinted);
            this.gbPrinted.Controls.Add(this.rbtNotPrinted);
            this.gbPrinted.Location = new System.Drawing.Point(225, 60);
            this.gbPrinted.Name = "gbPrinted";
            this.gbPrinted.Size = new System.Drawing.Size(174, 100);
            this.gbPrinted.TabIndex = 4;
            this.gbPrinted.TabStop = false;
            this.gbPrinted.Text = "По признаку \"Распечатан\"";
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Location = new System.Drawing.Point(15, 75);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(43, 17);
            this.rbtAll.TabIndex = 6;
            this.rbtAll.Text = "все";
            this.rbtAll.UseVisualStyleBackColor = true;
            // 
            // rbtPrinted
            // 
            this.rbtPrinted.AutoSize = true;
            this.rbtPrinted.Location = new System.Drawing.Point(15, 52);
            this.rbtPrinted.Name = "rbtPrinted";
            this.rbtPrinted.Size = new System.Drawing.Size(141, 17);
            this.rbtPrinted.TabIndex = 5;
            this.rbtPrinted.Text = "только распечатанные";
            this.rbtPrinted.UseVisualStyleBackColor = true;
            // 
            // rbtNotPrinted
            // 
            this.rbtNotPrinted.AutoSize = true;
            this.rbtNotPrinted.Checked = true;
            this.rbtNotPrinted.Location = new System.Drawing.Point(15, 29);
            this.rbtNotPrinted.Name = "rbtNotPrinted";
            this.rbtNotPrinted.Size = new System.Drawing.Size(153, 17);
            this.rbtNotPrinted.TabIndex = 4;
            this.rbtNotPrinted.TabStop = true;
            this.rbtNotPrinted.Text = "только нераспечатанные";
            this.rbtNotPrinted.UseVisualStyleBackColor = true;
            // 
            // lblDebtorId
            // 
            this.lblDebtorId.AutoSize = true;
            this.lblDebtorId.Location = new System.Drawing.Point(12, 9);
            this.lblDebtorId.Name = "lblDebtorId";
            this.lblDebtorId.Size = new System.Drawing.Size(100, 13);
            this.lblDebtorId.TabIndex = 9;
            this.lblDebtorId.Text = "По коду дебитора:";
            // 
            // tbxDebtorId
            // 
            this.tbxDebtorId.Location = new System.Drawing.Point(15, 25);
            this.tbxDebtorId.Name = "tbxDebtorId";
            this.tbxDebtorId.Size = new System.Drawing.Size(162, 20);
            this.tbxDebtorId.TabIndex = 1;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(217, 45);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(165, 20);
            this.dtpDateTo.TabIndex = 9;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(6, 45);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(162, 20);
            this.dtpDateFrom.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(324, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(225, 267);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Controls.Add(this.chbDateFilter);
            this.groupBox1.Controls.Add(this.lblDateFrom);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Location = new System.Drawing.Point(5, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 83);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(223, 29);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 14;
            this.lblDateTo.Text = "Дата по:";
            // 
            // chbDateFilter
            // 
            this.chbDateFilter.AutoSize = true;
            this.chbDateFilter.Location = new System.Drawing.Point(6, 0);
            this.chbDateFilter.Name = "chbDateFilter";
            this.chbDateFilter.Size = new System.Drawing.Size(115, 17);
            this.chbDateFilter.TabIndex = 7;
            this.chbDateFilter.Text = "Фильтр по датам";
            this.chbDateFilter.UseVisualStyleBackColor = true;
            this.chbDateFilter.CheckedChanged += new System.EventHandler(this.chbDateFilter_CheckedChanged);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(6, 29);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblDateFrom.TabIndex = 12;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // SearchNaklSummaryForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(413, 304);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxDebtorId);
            this.Controls.Add(this.lblDebtorId);
            this.Controls.Add(this.gbPrinted);
            this.Controls.Add(this.tbxNuklNumber);
            this.Controls.Add(this.lblNaklNumber);
            this.Controls.Add(this.tbxSNukl);
            this.Controls.Add(this.lblSNukl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchNaklSummaryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры поиска сводной";
            this.gbPrinted.ResumeLayout(false);
            this.gbPrinted.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSNukl;
        private System.Windows.Forms.TextBox tbxSNukl;
        private System.Windows.Forms.Label lblNaklNumber;
        private System.Windows.Forms.TextBox tbxNuklNumber;
        private System.Windows.Forms.GroupBox gbPrinted;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.RadioButton rbtPrinted;
        private System.Windows.Forms.RadioButton rbtNotPrinted;
        private System.Windows.Forms.Label lblDebtorId;
        private System.Windows.Forms.TextBox tbxDebtorId;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.CheckBox chbDateFilter;
        private System.Windows.Forms.Label lblDateFrom;
    }
}