namespace WMSOffice.Dialogs.ColdChain
{
    partial class ColdTransportationRegimeReportFilterForm
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
            this.rbDocumentNumber = new System.Windows.Forms.RadioButton();
            this.rbDateInvoiceItems = new System.Windows.Forms.RadioButton();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.cbDocumentType = new System.Windows.Forms.ComboBox();
            this.tbDocumentNumber = new System.Windows.Forms.TextBox();
            this.pnlDocumentNumber = new System.Windows.Forms.Panel();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDateInvoiceItems = new System.Windows.Forms.Panel();
            this.rbInvoiceItemName = new System.Windows.Forms.RadioButton();
            this.rbInvoiceItemID = new System.Windows.Forms.RadioButton();
            this.tbInvoiceItemName = new System.Windows.Forms.TextBox();
            this.tbInvoiceItemID = new System.Windows.Forms.TextBox();
            this.pnlDocumentNumber.SuspendLayout();
            this.pnlDateInvoiceItems.SuspendLayout();
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
            // rbDocumentNumber
            // 
            this.rbDocumentNumber.AutoSize = true;
            this.rbDocumentNumber.Location = new System.Drawing.Point(12, 18);
            this.rbDocumentNumber.Name = "rbDocumentNumber";
            this.rbDocumentNumber.Size = new System.Drawing.Size(134, 17);
            this.rbDocumentNumber.TabIndex = 101;
            this.rbDocumentNumber.TabStop = true;
            this.rbDocumentNumber.Text = "по номеру документа";
            this.rbDocumentNumber.UseVisualStyleBackColor = true;
            this.rbDocumentNumber.CheckedChanged += new System.EventHandler(this.rbSearchMainFilter_CheckedChanged);
            // 
            // rbDateInvoiceItems
            // 
            this.rbDateInvoiceItems.AutoSize = true;
            this.rbDateInvoiceItems.Location = new System.Drawing.Point(12, 92);
            this.rbDateInvoiceItems.Name = "rbDateInvoiceItems";
            this.rbDateInvoiceItems.Size = new System.Drawing.Size(109, 17);
            this.rbDateInvoiceItems.TabIndex = 102;
            this.rbDateInvoiceItems.TabStop = true;
            this.rbDateInvoiceItems.Text = "по дате и товару";
            this.rbDateInvoiceItems.UseVisualStyleBackColor = true;
            this.rbDateInvoiceItems.CheckedChanged += new System.EventHandler(this.rbSearchMainFilter_CheckedChanged);
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "dd / MM / yyyy";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(135, 13);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(167, 20);
            this.dtStartDate.TabIndex = 103;
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "dd / MM / yyyy";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(135, 37);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(167, 20);
            this.dtEndDate.TabIndex = 104;
            // 
            // cbDocumentType
            // 
            this.cbDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocumentType.FormattingEnabled = true;
            this.cbDocumentType.Items.AddRange(new object[] {
            "Заказ",
            "Накладная"});
            this.cbDocumentType.Location = new System.Drawing.Point(118, 9);
            this.cbDocumentType.Name = "cbDocumentType";
            this.cbDocumentType.Size = new System.Drawing.Size(137, 21);
            this.cbDocumentType.TabIndex = 105;
            this.cbDocumentType.SelectedIndexChanged += new System.EventHandler(this.cbDocumentType_SelectedIndexChanged);
            // 
            // tbDocumentNumber
            // 
            this.tbDocumentNumber.Location = new System.Drawing.Point(312, 10);
            this.tbDocumentNumber.Name = "tbDocumentNumber";
            this.tbDocumentNumber.Size = new System.Drawing.Size(119, 20);
            this.tbDocumentNumber.TabIndex = 106;
            this.tbDocumentNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterTextItem_KeyDown);
            this.tbDocumentNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // pnlDocumentNumber
            // 
            this.pnlDocumentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDocumentNumber.Controls.Add(this.lblDocumentNumber);
            this.pnlDocumentNumber.Controls.Add(this.lblDocumentType);
            this.pnlDocumentNumber.Controls.Add(this.cbDocumentType);
            this.pnlDocumentNumber.Controls.Add(this.tbDocumentNumber);
            this.pnlDocumentNumber.Location = new System.Drawing.Point(12, 41);
            this.pnlDocumentNumber.Name = "pnlDocumentNumber";
            this.pnlDocumentNumber.Size = new System.Drawing.Size(441, 39);
            this.pnlDocumentNumber.TabIndex = 107;
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.AutoSize = true;
            this.lblDocumentNumber.Location = new System.Drawing.Point(285, 12);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(21, 13);
            this.lblDocumentNumber.TabIndex = 110;
            this.lblDocumentNumber.Text = "№:";
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.AutoSize = true;
            this.lblDocumentType.Location = new System.Drawing.Point(26, 13);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(86, 13);
            this.lblDocumentType.TabIndex = 109;
            this.lblDocumentType.Text = "Тип документа:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Начальная дата:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Конечная дата:";
            // 
            // pnlDateInvoiceItems
            // 
            this.pnlDateInvoiceItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDateInvoiceItems.Controls.Add(this.rbInvoiceItemName);
            this.pnlDateInvoiceItems.Controls.Add(this.rbInvoiceItemID);
            this.pnlDateInvoiceItems.Controls.Add(this.tbInvoiceItemName);
            this.pnlDateInvoiceItems.Controls.Add(this.tbInvoiceItemID);
            this.pnlDateInvoiceItems.Controls.Add(this.dtStartDate);
            this.pnlDateInvoiceItems.Controls.Add(this.label2);
            this.pnlDateInvoiceItems.Controls.Add(this.dtEndDate);
            this.pnlDateInvoiceItems.Controls.Add(this.label1);
            this.pnlDateInvoiceItems.Location = new System.Drawing.Point(12, 115);
            this.pnlDateInvoiceItems.Name = "pnlDateInvoiceItems";
            this.pnlDateInvoiceItems.Size = new System.Drawing.Size(441, 121);
            this.pnlDateInvoiceItems.TabIndex = 110;
            // 
            // rbInvoiceItemName
            // 
            this.rbInvoiceItemName.AutoSize = true;
            this.rbInvoiceItemName.Location = new System.Drawing.Point(29, 93);
            this.rbInvoiceItemName.Name = "rbInvoiceItemName";
            this.rbInvoiceItemName.Size = new System.Drawing.Size(137, 17);
            this.rbInvoiceItemName.TabIndex = 115;
            this.rbInvoiceItemName.TabStop = true;
            this.rbInvoiceItemName.Text = "наименование товара";
            this.rbInvoiceItemName.UseVisualStyleBackColor = true;
            this.rbInvoiceItemName.CheckedChanged += new System.EventHandler(this.rbSearchDataInvoiceItemsFilter_CheckedChanged);
            // 
            // rbInvoiceItemID
            // 
            this.rbInvoiceItemID.AutoSize = true;
            this.rbInvoiceItemID.Location = new System.Drawing.Point(29, 70);
            this.rbInvoiceItemID.Name = "rbInvoiceItemID";
            this.rbInvoiceItemID.Size = new System.Drawing.Size(81, 17);
            this.rbInvoiceItemID.TabIndex = 114;
            this.rbInvoiceItemID.TabStop = true;
            this.rbInvoiceItemID.Text = "код товара";
            this.rbInvoiceItemID.UseVisualStyleBackColor = true;
            this.rbInvoiceItemID.CheckedChanged += new System.EventHandler(this.rbSearchDataInvoiceItemsFilter_CheckedChanged);
            // 
            // tbInvoiceItemName
            // 
            this.tbInvoiceItemName.Location = new System.Drawing.Point(183, 92);
            this.tbInvoiceItemName.Name = "tbInvoiceItemName";
            this.tbInvoiceItemName.Size = new System.Drawing.Size(220, 20);
            this.tbInvoiceItemName.TabIndex = 111;
            this.tbInvoiceItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterTextItem_KeyDown);
            // 
            // tbInvoiceItemID
            // 
            this.tbInvoiceItemID.Location = new System.Drawing.Point(183, 69);
            this.tbInvoiceItemID.Name = "tbInvoiceItemID";
            this.tbInvoiceItemID.Size = new System.Drawing.Size(119, 20);
            this.tbInvoiceItemID.TabIndex = 110;
            this.tbInvoiceItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterTextItem_KeyDown);
            this.tbInvoiceItemID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // ColdTransportationRegimeReportFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 288);
            this.Controls.Add(this.pnlDateInvoiceItems);
            this.Controls.Add(this.pnlDocumentNumber);
            this.Controls.Add(this.rbDateInvoiceItems);
            this.Controls.Add(this.rbDocumentNumber);
            this.Name = "ColdTransportationRegimeReportFilterForm";
            this.Text = "Фильтр для построения отчета о температурном режиме";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColdTransportationRegimeReportFilterForm_FormClosing);
            this.Controls.SetChildIndex(this.rbDocumentNumber, 0);
            this.Controls.SetChildIndex(this.rbDateInvoiceItems, 0);
            this.Controls.SetChildIndex(this.pnlDocumentNumber, 0);
            this.Controls.SetChildIndex(this.pnlDateInvoiceItems, 0);
            this.pnlDocumentNumber.ResumeLayout(false);
            this.pnlDocumentNumber.PerformLayout();
            this.pnlDateInvoiceItems.ResumeLayout(false);
            this.pnlDateInvoiceItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDocumentNumber;
        private System.Windows.Forms.RadioButton rbDateInvoiceItems;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.ComboBox cbDocumentType;
        private System.Windows.Forms.TextBox tbDocumentNumber;
        private System.Windows.Forms.Panel pnlDocumentNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDateInvoiceItems;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.RadioButton rbInvoiceItemName;
        private System.Windows.Forms.RadioButton rbInvoiceItemID;
        private System.Windows.Forms.TextBox tbInvoiceItemName;
        private System.Windows.Forms.TextBox tbInvoiceItemID;
    }
}