namespace WMSOffice.Dialogs.Docs
{
    partial class ArchivedInvoicesRegisterCreateForm
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
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.tbDebtorTo = new System.Windows.Forms.TextBox();
            this.lbllDebtorTo = new System.Windows.Forms.Label();
            this.stbDebtorTo = new WMSOffice.Controls.SearchTextBox();
            this.tbDebtorFrom = new System.Windows.Forms.TextBox();
            this.lblDebtorFrom = new System.Windows.Forms.Label();
            this.stbDebtorFrom = new WMSOffice.Controls.SearchTextBox();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.stbDocType = new WMSOffice.Controls.SearchTextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1261, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1351, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 92);
            this.pnlButtons.Size = new System.Drawing.Size(894, 43);
            this.pnlButtons.TabIndex = 13;
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(540, 63);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 12;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(449, 67);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(59, 13);
            this.lblPeriodTo.TabIndex = 11;
            this.lblPeriodTo.Text = "Період по:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(103, 63);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 10;
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(12, 67);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(53, 13);
            this.lblPeriodFrom.TabIndex = 9;
            this.lblPeriodFrom.Text = "Період з:";
            // 
            // tbDebtorTo
            // 
            this.tbDebtorTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtorTo.Location = new System.Drawing.Point(648, 34);
            this.tbDebtorTo.Name = "tbDebtorTo";
            this.tbDebtorTo.ReadOnly = true;
            this.tbDebtorTo.Size = new System.Drawing.Size(200, 20);
            this.tbDebtorTo.TabIndex = 8;
            // 
            // lbllDebtorTo
            // 
            this.lbllDebtorTo.AutoSize = true;
            this.lbllDebtorTo.Location = new System.Drawing.Point(449, 38);
            this.lbllDebtorTo.Name = "lbllDebtorTo";
            this.lbllDebtorTo.Size = new System.Drawing.Size(65, 13);
            this.lbllDebtorTo.TabIndex = 6;
            this.lbllDebtorTo.Text = "Дебітор по:";
            // 
            // stbDebtorTo
            // 
            this.stbDebtorTo.Location = new System.Drawing.Point(540, 34);
            this.stbDebtorTo.Name = "stbDebtorTo";
            this.stbDebtorTo.NavigateByValue = false;
            this.stbDebtorTo.ReadOnly = false;
            this.stbDebtorTo.Size = new System.Drawing.Size(100, 20);
            this.stbDebtorTo.TabIndex = 7;
            this.stbDebtorTo.UserID = ((long)(0));
            this.stbDebtorTo.Value = null;
            this.stbDebtorTo.ValueReferenceQuery = null;
            // 
            // tbDebtorFrom
            // 
            this.tbDebtorFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtorFrom.Location = new System.Drawing.Point(209, 34);
            this.tbDebtorFrom.Name = "tbDebtorFrom";
            this.tbDebtorFrom.ReadOnly = true;
            this.tbDebtorFrom.Size = new System.Drawing.Size(200, 20);
            this.tbDebtorFrom.TabIndex = 5;
            // 
            // lblDebtorFrom
            // 
            this.lblDebtorFrom.AutoSize = true;
            this.lblDebtorFrom.Location = new System.Drawing.Point(12, 38);
            this.lblDebtorFrom.Name = "lblDebtorFrom";
            this.lblDebtorFrom.Size = new System.Drawing.Size(59, 13);
            this.lblDebtorFrom.TabIndex = 3;
            this.lblDebtorFrom.Text = "Дебітор з:";
            // 
            // stbDebtorFrom
            // 
            this.stbDebtorFrom.Location = new System.Drawing.Point(103, 34);
            this.stbDebtorFrom.Name = "stbDebtorFrom";
            this.stbDebtorFrom.NavigateByValue = false;
            this.stbDebtorFrom.ReadOnly = false;
            this.stbDebtorFrom.Size = new System.Drawing.Size(100, 20);
            this.stbDebtorFrom.TabIndex = 4;
            this.stbDebtorFrom.UserID = ((long)(0));
            this.stbDebtorFrom.Value = null;
            this.stbDebtorFrom.ValueReferenceQuery = null;
            // 
            // tbDocType
            // 
            this.tbDocType.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocType.Location = new System.Drawing.Point(209, 8);
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.ReadOnly = true;
            this.tbDocType.Size = new System.Drawing.Size(200, 20);
            this.tbDocType.TabIndex = 2;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(12, 12);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(86, 13);
            this.lblDocType.TabIndex = 0;
            this.lblDocType.Text = "Тип документа:";
            // 
            // stbDocType
            // 
            this.stbDocType.Location = new System.Drawing.Point(103, 8);
            this.stbDocType.Name = "stbDocType";
            this.stbDocType.NavigateByValue = false;
            this.stbDocType.ReadOnly = false;
            this.stbDocType.Size = new System.Drawing.Size(100, 20);
            this.stbDocType.TabIndex = 1;
            this.stbDocType.UserID = ((long)(0));
            this.stbDocType.Value = null;
            this.stbDocType.ValueReferenceQuery = null;
            // 
            // ArchivedInvoicesRegisterCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 135);
            this.Controls.Add(this.dtpPeriodTo);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.dtpPeriodFrom);
            this.Controls.Add(this.lblPeriodFrom);
            this.Controls.Add(this.tbDebtorTo);
            this.Controls.Add(this.lbllDebtorTo);
            this.Controls.Add(this.stbDebtorTo);
            this.Controls.Add(this.tbDebtorFrom);
            this.Controls.Add(this.lblDebtorFrom);
            this.Controls.Add(this.stbDebtorFrom);
            this.Controls.Add(this.tbDocType);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.stbDocType);
            this.Name = "ArchivedInvoicesRegisterCreateForm";
            this.Text = "Вкажіть параметри створення реєстра архіву";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchivedInvoicesRegisterCreateForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.stbDocType, 0);
            this.Controls.SetChildIndex(this.lblDocType, 0);
            this.Controls.SetChildIndex(this.tbDocType, 0);
            this.Controls.SetChildIndex(this.stbDebtorFrom, 0);
            this.Controls.SetChildIndex(this.lblDebtorFrom, 0);
            this.Controls.SetChildIndex(this.tbDebtorFrom, 0);
            this.Controls.SetChildIndex(this.stbDebtorTo, 0);
            this.Controls.SetChildIndex(this.lbllDebtorTo, 0);
            this.Controls.SetChildIndex(this.tbDebtorTo, 0);
            this.Controls.SetChildIndex(this.lblPeriodFrom, 0);
            this.Controls.SetChildIndex(this.dtpPeriodFrom, 0);
            this.Controls.SetChildIndex(this.lblPeriodTo, 0);
            this.Controls.SetChildIndex(this.dtpPeriodTo, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.TextBox tbDebtorTo;
        private System.Windows.Forms.Label lbllDebtorTo;
        private WMSOffice.Controls.SearchTextBox stbDebtorTo;
        private System.Windows.Forms.TextBox tbDebtorFrom;
        private System.Windows.Forms.Label lblDebtorFrom;
        private WMSOffice.Controls.SearchTextBox stbDebtorFrom;
        private System.Windows.Forms.TextBox tbDocType;
        private System.Windows.Forms.Label lblDocType;
        private WMSOffice.Controls.SearchTextBox stbDocType;
    }
}