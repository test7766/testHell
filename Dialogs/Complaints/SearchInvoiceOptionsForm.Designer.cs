namespace WMSOffice.Dialogs.Complaints
{
    partial class SearchInvoiceOptionsForm
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
            this.gbSearchByOrderNumber = new System.Windows.Forms.GroupBox();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.tbOrderType = new System.Windows.Forms.TextBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.rbSearchByOrderNumber = new System.Windows.Forms.RadioButton();
            this.gbSearchByInvoiceNumber = new System.Windows.Forms.GroupBox();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.tbInvoiceType = new System.Windows.Forms.TextBox();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.rbSearchByInvoiceNumber = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.gbSearchByInnerDocNumber = new System.Windows.Forms.GroupBox();
            this.rbSearchByInnerDocNumber = new System.Windows.Forms.RadioButton();
            this.tbInnerDocNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInnerDocType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbSearchByPeriod = new System.Windows.Forms.RadioButton();
            this.gbSearchByPeriod = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.gbSearchByOrderNumber.SuspendLayout();
            this.gbSearchByInvoiceNumber.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.gbSearchByInnerDocNumber.SuspendLayout();
            this.gbSearchByPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearchByOrderNumber
            // 
            this.gbSearchByOrderNumber.Controls.Add(this.tbOrderNumber);
            this.gbSearchByOrderNumber.Controls.Add(this.lblOrderNumber);
            this.gbSearchByOrderNumber.Controls.Add(this.tbOrderType);
            this.gbSearchByOrderNumber.Controls.Add(this.lblOrderType);
            this.gbSearchByOrderNumber.Location = new System.Drawing.Point(12, 12);
            this.gbSearchByOrderNumber.Name = "gbSearchByOrderNumber";
            this.gbSearchByOrderNumber.Size = new System.Drawing.Size(242, 76);
            this.gbSearchByOrderNumber.TabIndex = 1;
            this.gbSearchByOrderNumber.TabStop = false;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(98, 48);
            this.tbOrderNumber.MaxLength = 12;
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(134, 20);
            this.tbOrderNumber.TabIndex = 3;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(6, 51);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(60, 13);
            this.lblOrderNumber.TabIndex = 2;
            this.lblOrderNumber.Text = "№ заказа:";
            // 
            // tbOrderType
            // 
            this.tbOrderType.Location = new System.Drawing.Point(98, 22);
            this.tbOrderType.MaxLength = 2;
            this.tbOrderType.Name = "tbOrderType";
            this.tbOrderType.Size = new System.Drawing.Size(42, 20);
            this.tbOrderType.TabIndex = 1;
            this.tbOrderType.Text = "01";
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Location = new System.Drawing.Point(6, 25);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(68, 13);
            this.lblOrderType.TabIndex = 0;
            this.lblOrderType.Text = "Тип заказа:";
            // 
            // rbSearchByOrderNumber
            // 
            this.rbSearchByOrderNumber.AutoSize = true;
            this.rbSearchByOrderNumber.Location = new System.Drawing.Point(19, 9);
            this.rbSearchByOrderNumber.Name = "rbSearchByOrderNumber";
            this.rbSearchByOrderNumber.Size = new System.Drawing.Size(155, 17);
            this.rbSearchByOrderNumber.TabIndex = 0;
            this.rbSearchByOrderNumber.TabStop = true;
            this.rbSearchByOrderNumber.Text = "По типу и номеру заказа:";
            this.rbSearchByOrderNumber.UseVisualStyleBackColor = true;
            this.rbSearchByOrderNumber.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // gbSearchByInvoiceNumber
            // 
            this.gbSearchByInvoiceNumber.Controls.Add(this.tbInvoiceNumber);
            this.gbSearchByInvoiceNumber.Controls.Add(this.lblInvoiceNumber);
            this.gbSearchByInvoiceNumber.Controls.Add(this.tbInvoiceType);
            this.gbSearchByInvoiceNumber.Controls.Add(this.lblInvoiceType);
            this.gbSearchByInvoiceNumber.Location = new System.Drawing.Point(12, 94);
            this.gbSearchByInvoiceNumber.Name = "gbSearchByInvoiceNumber";
            this.gbSearchByInvoiceNumber.Size = new System.Drawing.Size(242, 76);
            this.gbSearchByInvoiceNumber.TabIndex = 3;
            this.gbSearchByInvoiceNumber.TabStop = false;
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.Location = new System.Drawing.Point(98, 47);
            this.tbInvoiceNumber.MaxLength = 12;
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.Size = new System.Drawing.Size(134, 20);
            this.tbInvoiceNumber.TabIndex = 3;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(6, 50);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(78, 13);
            this.lblInvoiceNumber.TabIndex = 2;
            this.lblInvoiceNumber.Text = "№ накладной:";
            // 
            // tbInvoiceType
            // 
            this.tbInvoiceType.Location = new System.Drawing.Point(98, 21);
            this.tbInvoiceType.MaxLength = 2;
            this.tbInvoiceType.Name = "tbInvoiceType";
            this.tbInvoiceType.Size = new System.Drawing.Size(42, 20);
            this.tbInvoiceType.TabIndex = 1;
            this.tbInvoiceType.Text = "V1";
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Location = new System.Drawing.Point(6, 24);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(86, 13);
            this.lblInvoiceType.TabIndex = 0;
            this.lblInvoiceType.Text = "Тип накладной:";
            // 
            // rbSearchByInvoiceNumber
            // 
            this.rbSearchByInvoiceNumber.AutoSize = true;
            this.rbSearchByInvoiceNumber.Location = new System.Drawing.Point(19, 92);
            this.rbSearchByInvoiceNumber.Name = "rbSearchByInvoiceNumber";
            this.rbSearchByInvoiceNumber.Size = new System.Drawing.Size(173, 17);
            this.rbSearchByInvoiceNumber.TabIndex = 2;
            this.rbSearchByInvoiceNumber.TabStop = true;
            this.rbSearchByInvoiceNumber.Text = "По типу и номеру накладной:";
            this.rbSearchByInvoiceNumber.UseVisualStyleBackColor = true;
            this.rbSearchByInvoiceNumber.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(98, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(179, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnOK);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 341);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(266, 40);
            this.pnlFooter.TabIndex = 8;
            // 
            // gbSearchByInnerDocNumber
            // 
            this.gbSearchByInnerDocNumber.Controls.Add(this.rbSearchByInnerDocNumber);
            this.gbSearchByInnerDocNumber.Controls.Add(this.tbInnerDocNumber);
            this.gbSearchByInnerDocNumber.Controls.Add(this.label1);
            this.gbSearchByInnerDocNumber.Controls.Add(this.tbInnerDocType);
            this.gbSearchByInnerDocNumber.Controls.Add(this.label2);
            this.gbSearchByInnerDocNumber.Location = new System.Drawing.Point(12, 176);
            this.gbSearchByInnerDocNumber.Name = "gbSearchByInnerDocNumber";
            this.gbSearchByInnerDocNumber.Size = new System.Drawing.Size(242, 76);
            this.gbSearchByInnerDocNumber.TabIndex = 5;
            this.gbSearchByInnerDocNumber.TabStop = false;
            // 
            // rbSearchByInnerDocNumber
            // 
            this.rbSearchByInnerDocNumber.AutoSize = true;
            this.rbSearchByInnerDocNumber.Location = new System.Drawing.Point(9, -2);
            this.rbSearchByInnerDocNumber.Name = "rbSearchByInnerDocNumber";
            this.rbSearchByInnerDocNumber.Size = new System.Drawing.Size(191, 17);
            this.rbSearchByInnerDocNumber.TabIndex = 4;
            this.rbSearchByInnerDocNumber.TabStop = true;
            this.rbSearchByInnerDocNumber.Text = "По типу и номеру вн. документа:";
            this.rbSearchByInnerDocNumber.UseVisualStyleBackColor = true;
            this.rbSearchByInnerDocNumber.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // tbInnerDocNumber
            // 
            this.tbInnerDocNumber.Location = new System.Drawing.Point(98, 47);
            this.tbInnerDocNumber.MaxLength = 12;
            this.tbInnerDocNumber.Name = "tbInnerDocNumber";
            this.tbInnerDocNumber.Size = new System.Drawing.Size(134, 20);
            this.tbInnerDocNumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "№ вн. док-та:";
            // 
            // tbInnerDocType
            // 
            this.tbInnerDocType.Location = new System.Drawing.Point(98, 21);
            this.tbInnerDocType.MaxLength = 2;
            this.tbInnerDocType.Name = "tbInnerDocType";
            this.tbInnerDocType.Size = new System.Drawing.Size(42, 20);
            this.tbInnerDocType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Тип вн. док-та:";
            // 
            // rbSearchByPeriod
            // 
            this.rbSearchByPeriod.AutoSize = true;
            this.rbSearchByPeriod.Location = new System.Drawing.Point(19, 256);
            this.rbSearchByPeriod.Name = "rbSearchByPeriod";
            this.rbSearchByPeriod.Size = new System.Drawing.Size(86, 17);
            this.rbSearchByPeriod.TabIndex = 6;
            this.rbSearchByPeriod.TabStop = true;
            this.rbSearchByPeriod.Text = "По периоду:";
            this.rbSearchByPeriod.UseVisualStyleBackColor = true;
            this.rbSearchByPeriod.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // gbSearchByPeriod
            // 
            this.gbSearchByPeriod.Controls.Add(this.dtpPeriodTo);
            this.gbSearchByPeriod.Controls.Add(this.dtpPeriodFrom);
            this.gbSearchByPeriod.Controls.Add(this.label3);
            this.gbSearchByPeriod.Controls.Add(this.label4);
            this.gbSearchByPeriod.Location = new System.Drawing.Point(12, 258);
            this.gbSearchByPeriod.Name = "gbSearchByPeriod";
            this.gbSearchByPeriod.Size = new System.Drawing.Size(242, 76);
            this.gbSearchByPeriod.TabIndex = 7;
            this.gbSearchByPeriod.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата по:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Дата с:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(98, 20);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.ShowCheckBox = true;
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 1;
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(98, 46);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.ShowCheckBox = true;
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 3;
            // 
            // SearchInvoiceOptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(266, 381);
            this.Controls.Add(this.rbSearchByPeriod);
            this.Controls.Add(this.gbSearchByPeriod);
            this.Controls.Add(this.gbSearchByInnerDocNumber);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.rbSearchByOrderNumber);
            this.Controls.Add(this.rbSearchByInvoiceNumber);
            this.Controls.Add(this.gbSearchByInvoiceNumber);
            this.Controls.Add(this.gbSearchByOrderNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchInvoiceOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры поиска заказа (накладной)";
            this.Shown += new System.EventHandler(this.SearchInvoiceOptionsForm_Shown);
            this.gbSearchByOrderNumber.ResumeLayout(false);
            this.gbSearchByOrderNumber.PerformLayout();
            this.gbSearchByInvoiceNumber.ResumeLayout(false);
            this.gbSearchByInvoiceNumber.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.gbSearchByInnerDocNumber.ResumeLayout(false);
            this.gbSearchByInnerDocNumber.PerformLayout();
            this.gbSearchByPeriod.ResumeLayout(false);
            this.gbSearchByPeriod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchByOrderNumber;
        private System.Windows.Forms.RadioButton rbSearchByOrderNumber;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox tbOrderType;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.GroupBox gbSearchByInvoiceNumber;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox tbInvoiceType;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.RadioButton rbSearchByInvoiceNumber;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.GroupBox gbSearchByInnerDocNumber;
        private System.Windows.Forms.RadioButton rbSearchByInnerDocNumber;
        private System.Windows.Forms.TextBox tbInnerDocNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInnerDocType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbSearchByPeriod;
        private System.Windows.Forms.GroupBox gbSearchByPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
    }
}