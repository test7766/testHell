namespace WMSOffice.Dialogs.WH
{
    partial class PrePaymentDocsFilterForm
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
            this.stbDebtorCode = new WMSOffice.Controls.SearchTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbDebtorPeriod = new System.Windows.Forms.GroupBox();
            this.lblDebtorCode = new System.Windows.Forms.Label();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.gbDocument = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbActivateSearchByDocNumber = new System.Windows.Forms.CheckBox();
            this.cbActivateSearchByDebtorPeriod = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            this.gbDebtorPeriod.SuspendLayout();
            this.gbDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2347, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2437, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 229);
            this.pnlButtons.Size = new System.Drawing.Size(444, 43);
            this.pnlButtons.TabIndex = 5;
            // 
            // stbDebtorCode
            // 
            this.stbDebtorCode.Location = new System.Drawing.Point(70, 27);
            this.stbDebtorCode.Name = "stbDebtorCode";
            this.stbDebtorCode.Size = new System.Drawing.Size(100, 23);
            this.stbDebtorCode.TabIndex = 0;
            this.stbDebtorCode.UserID = ((long)(0));
            this.stbDebtorCode.Value = null;
            this.stbDebtorCode.ValueReferenceQuery = null;
            this.stbDebtorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Код:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(70, 80);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTo.CustomFormat = "dd.MM.yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(285, 80);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 2;
            this.dtpTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Дата \"по\":";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Дата \"с\":";
            // 
            // gbDebtorPeriod
            // 
            this.gbDebtorPeriod.Controls.Add(this.lblDebtorCode);
            this.gbDebtorPeriod.Controls.Add(this.dtpFrom);
            this.gbDebtorPeriod.Controls.Add(this.label2);
            this.gbDebtorPeriod.Controls.Add(this.dtpTo);
            this.gbDebtorPeriod.Controls.Add(this.label3);
            this.gbDebtorPeriod.Controls.Add(this.stbDebtorCode);
            this.gbDebtorPeriod.Controls.Add(this.label1);
            this.gbDebtorPeriod.Location = new System.Drawing.Point(15, 122);
            this.gbDebtorPeriod.Name = "gbDebtorPeriod";
            this.gbDebtorPeriod.Size = new System.Drawing.Size(407, 107);
            this.gbDebtorPeriod.TabIndex = 4;
            this.gbDebtorPeriod.TabStop = false;
            // 
            // lblDebtorCode
            // 
            this.lblDebtorCode.AutoSize = true;
            this.lblDebtorCode.Location = new System.Drawing.Point(67, 49);
            this.lblDebtorCode.Name = "lblDebtorCode";
            this.lblDebtorCode.Size = new System.Drawing.Size(0, 13);
            this.lblDebtorCode.TabIndex = 112;
            // 
            // cmbDocType
            // 
            this.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Items.AddRange(new object[] {
            "Предоплатная НН",
            "Предоплатная РК"});
            this.cmbDocType.Location = new System.Drawing.Point(104, 11);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(130, 21);
            this.cmbDocType.TabIndex = 0;
            this.cmbDocType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.Location = new System.Drawing.Point(70, 24);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.Size = new System.Drawing.Size(100, 20);
            this.tbDocNumber.TabIndex = 0;
            this.tbDocNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.tbDocNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // gbDocument
            // 
            this.gbDocument.Controls.Add(this.label5);
            this.gbDocument.Controls.Add(this.tbDocNumber);
            this.gbDocument.Location = new System.Drawing.Point(15, 57);
            this.gbDocument.Name = "gbDocument";
            this.gbDocument.Size = new System.Drawing.Size(407, 50);
            this.gbDocument.TabIndex = 2;
            this.gbDocument.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "№:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Тип документа:";
            // 
            // cbActivateSearchByDocNumber
            // 
            this.cbActivateSearchByDocNumber.AutoSize = true;
            this.cbActivateSearchByDocNumber.Location = new System.Drawing.Point(19, 55);
            this.cbActivateSearchByDocNumber.Name = "cbActivateSearchByDocNumber";
            this.cbActivateSearchByDocNumber.Size = new System.Drawing.Size(111, 17);
            this.cbActivateSearchByDocNumber.TabIndex = 1;
            this.cbActivateSearchByDocNumber.Text = "По № документа";
            this.cbActivateSearchByDocNumber.UseVisualStyleBackColor = true;
            this.cbActivateSearchByDocNumber.CheckedChanged += new System.EventHandler(this.cbActivateSearchByDocNumber_CheckedChanged);
            this.cbActivateSearchByDocNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cbActivateSearchByDebtorPeriod
            // 
            this.cbActivateSearchByDebtorPeriod.AutoSize = true;
            this.cbActivateSearchByDebtorPeriod.Location = new System.Drawing.Point(19, 119);
            this.cbActivateSearchByDebtorPeriod.Name = "cbActivateSearchByDebtorPeriod";
            this.cbActivateSearchByDebtorPeriod.Size = new System.Drawing.Size(189, 17);
            this.cbActivateSearchByDebtorPeriod.TabIndex = 3;
            this.cbActivateSearchByDebtorPeriod.Text = "По дебитору и датам документа";
            this.cbActivateSearchByDebtorPeriod.UseVisualStyleBackColor = true;
            this.cbActivateSearchByDebtorPeriod.CheckedChanged += new System.EventHandler(this.cbActivateSearchByDebtorPeriod_CheckedChanged);
            this.cbActivateSearchByDebtorPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // PrePaymentDocsFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 272);
            this.Controls.Add(this.cbActivateSearchByDebtorPeriod);
            this.Controls.Add(this.cbActivateSearchByDocNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDocType);
            this.Controls.Add(this.gbDocument);
            this.Controls.Add(this.gbDebtorPeriod);
            this.Name = "PrePaymentDocsFilterForm";
            this.Text = "Укажите параметры поиска предоплатных НН и РК";
            this.Load += new System.EventHandler(this.PrePaymentDocsFilterForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrePaymentDocsFilterForm_FormClosing);
            this.Controls.SetChildIndex(this.gbDebtorPeriod, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.gbDocument, 0);
            this.Controls.SetChildIndex(this.cmbDocType, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cbActivateSearchByDocNumber, 0);
            this.Controls.SetChildIndex(this.cbActivateSearchByDebtorPeriod, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbDebtorPeriod.ResumeLayout(false);
            this.gbDebtorPeriod.PerformLayout();
            this.gbDocument.ResumeLayout(false);
            this.gbDocument.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.SearchTextBox stbDebtorCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbDebtorPeriod;
        private System.Windows.Forms.Label lblDebtorCode;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.GroupBox gbDocument;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbActivateSearchByDebtorPeriod;
        private System.Windows.Forms.CheckBox cbActivateSearchByDocNumber;
    }
}