namespace WMSOffice.Dialogs.WH
{
    partial class PrintNaklSummaryReestrForm
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
            this.components = new System.ComponentModel.Container();
            this.bsDebitors = new System.Windows.Forms.BindingSource(this.components);
            this.printNaklSummary = new WMSOffice.Data.PrintNaklSummary();
            this.rbtFewNakls = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.taDebitors = new WMSOffice.Data.PrintNaklSummaryTableAdapters.DebitorsTableAdapter();
            this.rbtNaklNumber = new System.Windows.Forms.RadioButton();
            this.pnlLoadType = new System.Windows.Forms.Panel();
            this.rbtAllExtended = new System.Windows.Forms.RadioButton();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.rbtOnlySummary = new System.Windows.Forms.RadioButton();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.lblDebitor = new System.Windows.Forms.Label();
            this.cmbDebtorId = new System.Windows.Forms.ComboBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.grbFewNakl = new System.Windows.Forms.GroupBox();
            this.lblNaklNumber = new System.Windows.Forms.Label();
            this.tbxNaklNumber = new System.Windows.Forms.TextBox();
            this.grbNaklNumber = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsDebitors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNaklSummary)).BeginInit();
            this.pnlLoadType.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.grbFewNakl.SuspendLayout();
            this.grbNaklNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsDebitors
            // 
            this.bsDebitors.DataMember = "Debitors";
            this.bsDebitors.DataSource = this.printNaklSummary;
            // 
            // printNaklSummary
            // 
            this.printNaklSummary.DataSetName = "PrintNaklSummary";
            this.printNaklSummary.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rbtFewNakls
            // 
            this.rbtFewNakls.AutoSize = true;
            this.rbtFewNakls.Location = new System.Drawing.Point(18, 93);
            this.rbtFewNakls.Name = "rbtFewNakls";
            this.rbtFewNakls.Size = new System.Drawing.Size(251, 17);
            this.rbtFewNakls.TabIndex = 0;
            this.rbtFewNakls.TabStop = true;
            this.rbtFewNakls.Text = "Реестр по нескольким сводным накладным";
            this.rbtFewNakls.UseVisualStyleBackColor = true;
            this.rbtFewNakls.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(369, 326);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(288, 326);
            this.btnOk.Margin = new System.Windows.Forms.Padding(10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // taDebitors
            // 
            this.taDebitors.ClearBeforeFill = true;
            // 
            // rbtNaklNumber
            // 
            this.rbtNaklNumber.AutoSize = true;
            this.rbtNaklNumber.Checked = true;
            this.rbtNaklNumber.Location = new System.Drawing.Point(18, 10);
            this.rbtNaklNumber.Name = "rbtNaklNumber";
            this.rbtNaklNumber.Size = new System.Drawing.Size(224, 17);
            this.rbtNaklNumber.TabIndex = 0;
            this.rbtNaklNumber.TabStop = true;
            this.rbtNaklNumber.Text = "Реестр по текущей сводной накладной";
            this.rbtNaklNumber.UseVisualStyleBackColor = true;
            this.rbtNaklNumber.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // pnlLoadType
            // 
            this.pnlLoadType.Controls.Add(this.rbtAllExtended);
            this.pnlLoadType.Controls.Add(this.rbtAll);
            this.pnlLoadType.Controls.Add(this.rbtOnlySummary);
            this.pnlLoadType.Location = new System.Drawing.Point(6, 23);
            this.pnlLoadType.Name = "pnlLoadType";
            this.pnlLoadType.Size = new System.Drawing.Size(194, 75);
            this.pnlLoadType.TabIndex = 7;
            this.pnlLoadType.Visible = false;
            // 
            // rbtAllExtended
            // 
            this.rbtAllExtended.AutoSize = true;
            this.rbtAllExtended.Location = new System.Drawing.Point(6, 49);
            this.rbtAllExtended.Name = "rbtAllExtended";
            this.rbtAllExtended.Size = new System.Drawing.Size(182, 17);
            this.rbtAllExtended.TabIndex = 2;
            this.rbtAllExtended.Text = "Все накладные (расширенный)";
            this.rbtAllExtended.UseVisualStyleBackColor = true;
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Location = new System.Drawing.Point(6, 26);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(103, 17);
            this.rbtAll.TabIndex = 1;
            this.rbtAll.Text = "Все накладные";
            this.rbtAll.UseVisualStyleBackColor = true;
            // 
            // rbtOnlySummary
            // 
            this.rbtOnlySummary.AutoSize = true;
            this.rbtOnlySummary.Checked = true;
            this.rbtOnlySummary.Location = new System.Drawing.Point(6, 3);
            this.rbtOnlySummary.Name = "rbtOnlySummary";
            this.rbtOnlySummary.Size = new System.Drawing.Size(168, 17);
            this.rbtOnlySummary.TabIndex = 0;
            this.rbtOnlySummary.TabStop = true;
            this.rbtOnlySummary.Text = "Только сводные накладные";
            this.rbtOnlySummary.UseVisualStyleBackColor = true;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.lblDebitor);
            this.pnlSettings.Controls.Add(this.cmbDebtorId);
            this.pnlSettings.Controls.Add(this.dtpDateTo);
            this.pnlSettings.Controls.Add(this.lblDateTo);
            this.pnlSettings.Controls.Add(this.lblDateFrom);
            this.pnlSettings.Controls.Add(this.dtpDateFrom);
            this.pnlSettings.Location = new System.Drawing.Point(6, 104);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(419, 85);
            this.pnlSettings.TabIndex = 8;
            // 
            // lblDebitor
            // 
            this.lblDebitor.AutoSize = true;
            this.lblDebitor.Location = new System.Drawing.Point(3, 10);
            this.lblDebitor.Name = "lblDebitor";
            this.lblDebitor.Size = new System.Drawing.Size(54, 13);
            this.lblDebitor.TabIndex = 1;
            this.lblDebitor.Text = "Дебитор:";
            // 
            // cmbDebtorId
            // 
            this.cmbDebtorId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDebtorId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDebtorId.DataSource = this.bsDebitors;
            this.cmbDebtorId.DisplayMember = "Debtor";
            this.cmbDebtorId.FormattingEnabled = true;
            this.cmbDebtorId.Location = new System.Drawing.Point(63, 7);
            this.cmbDebtorId.Name = "cmbDebtorId";
            this.cmbDebtorId.Size = new System.Drawing.Size(353, 21);
            this.cmbDebtorId.TabIndex = 2;
            this.cmbDebtorId.ValueMember = "Debtor_ID";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(222, 58);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(147, 20);
            this.dtpDateTo.TabIndex = 6;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(219, 42);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(48, 13);
            this.lblDateTo.TabIndex = 5;
            this.lblDateTo.Text = "Дата по";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(3, 42);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(42, 13);
            this.lblDateFrom.TabIndex = 3;
            this.lblDateFrom.Text = "Дата с";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(6, 58);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(147, 20);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // grbFewNakl
            // 
            this.grbFewNakl.AutoSize = true;
            this.grbFewNakl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbFewNakl.Controls.Add(this.pnlSettings);
            this.grbFewNakl.Controls.Add(this.pnlLoadType);
            this.grbFewNakl.Location = new System.Drawing.Point(12, 97);
            this.grbFewNakl.Name = "grbFewNakl";
            this.grbFewNakl.Size = new System.Drawing.Size(431, 208);
            this.grbFewNakl.TabIndex = 1;
            this.grbFewNakl.TabStop = false;
            this.grbFewNakl.Text = "Реестр по нескольким сводным накладным";
            // 
            // lblNaklNumber
            // 
            this.lblNaklNumber.AutoSize = true;
            this.lblNaklNumber.Location = new System.Drawing.Point(6, 33);
            this.lblNaklNumber.Name = "lblNaklNumber";
            this.lblNaklNumber.Size = new System.Drawing.Size(111, 13);
            this.lblNaklNumber.TabIndex = 1;
            this.lblNaklNumber.Text = "Номер сводной НН: ";
            // 
            // tbxNaklNumber
            // 
            this.tbxNaklNumber.Enabled = false;
            this.tbxNaklNumber.Location = new System.Drawing.Point(123, 30);
            this.tbxNaklNumber.Name = "tbxNaklNumber";
            this.tbxNaklNumber.Size = new System.Drawing.Size(77, 20);
            this.tbxNaklNumber.TabIndex = 2;
            // 
            // grbNaklNumber
            // 
            this.grbNaklNumber.Controls.Add(this.tbxNaklNumber);
            this.grbNaklNumber.Controls.Add(this.lblNaklNumber);
            this.grbNaklNumber.Location = new System.Drawing.Point(12, 12);
            this.grbNaklNumber.Name = "grbNaklNumber";
            this.grbNaklNumber.Size = new System.Drawing.Size(431, 67);
            this.grbNaklNumber.TabIndex = 0;
            this.grbNaklNumber.TabStop = false;
            this.grbNaklNumber.Text = "groupBox1";
            // 
            // PrintNaklSummaryReestrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(456, 362);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rbtFewNakls);
            this.Controls.Add(this.grbFewNakl);
            this.Controls.Add(this.rbtNaklNumber);
            this.Controls.Add(this.grbNaklNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PrintNaklSummaryReestrForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Печать реестра";
            this.Load += new System.EventHandler(this.PrintNaklSummaryReestrForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDebitors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNaklSummary)).EndInit();
            this.pnlLoadType.ResumeLayout(false);
            this.pnlLoadType.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.grbFewNakl.ResumeLayout(false);
            this.grbNaklNumber.ResumeLayout(false);
            this.grbNaklNumber.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtFewNakls;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.BindingSource bsDebitors;
        private WMSOffice.Data.PrintNaklSummary printNaklSummary;
        private WMSOffice.Data.PrintNaklSummaryTableAdapters.DebitorsTableAdapter taDebitors;
        private System.Windows.Forms.RadioButton rbtNaklNumber;
        private System.Windows.Forms.Panel pnlLoadType;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.RadioButton rbtOnlySummary;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblDebitor;
        private System.Windows.Forms.ComboBox cmbDebtorId;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.GroupBox grbFewNakl;
        private System.Windows.Forms.Label lblNaklNumber;
        private System.Windows.Forms.TextBox tbxNaklNumber;
        private System.Windows.Forms.GroupBox grbNaklNumber;
        private System.Windows.Forms.RadioButton rbtAllExtended;
    }
}