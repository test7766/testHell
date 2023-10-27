namespace WMSOffice.Dialogs.Complaints
{
    partial class VendorReturnsSearchDocsForm
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
            this.lblDocID = new System.Windows.Forms.Label();
            this.tbDocID = new System.Windows.Forms.TextBox();
            this.stbVendorID = new WMSOffice.Controls.SearchTextBox();
            this.lblVendorID = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblStatusID = new System.Windows.Forms.Label();
            this.stbStatusID = new WMSOffice.Controls.SearchTextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.stbUserID = new WMSOffice.Controls.SearchTextBox();
            this.tbVendorName = new System.Windows.Forms.TextBox();
            this.tbStatusName = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(317, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 158);
            this.pnlButtons.Size = new System.Drawing.Size(494, 43);
            this.pnlButtons.TabIndex = 15;
            // 
            // lblDocID
            // 
            this.lblDocID.AutoSize = true;
            this.lblDocID.Location = new System.Drawing.Point(17, 15);
            this.lblDocID.Name = "lblDocID";
            this.lblDocID.Size = new System.Drawing.Size(75, 13);
            this.lblDocID.TabIndex = 0;
            this.lblDocID.Text = "№ документа";
            // 
            // tbDocID
            // 
            this.tbDocID.Location = new System.Drawing.Point(98, 11);
            this.tbDocID.Name = "tbDocID";
            this.tbDocID.Size = new System.Drawing.Size(100, 20);
            this.tbDocID.TabIndex = 1;
            // 
            // stbVendorID
            // 
            this.stbVendorID.Location = new System.Drawing.Point(98, 40);
            this.stbVendorID.Name = "stbVendorID";
            this.stbVendorID.ReadOnly = false;
            this.stbVendorID.Size = new System.Drawing.Size(100, 20);
            this.stbVendorID.TabIndex = 3;
            this.stbVendorID.UserID = ((long)(0));
            this.stbVendorID.Value = null;
            this.stbVendorID.ValueReferenceQuery = null;
            // 
            // lblVendorID
            // 
            this.lblVendorID.AutoSize = true;
            this.lblVendorID.Location = new System.Drawing.Point(27, 44);
            this.lblVendorID.Name = "lblVendorID";
            this.lblVendorID.Size = new System.Drawing.Size(65, 13);
            this.lblVendorID.TabIndex = 2;
            this.lblVendorID.Text = "Поставщик";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(98, 69);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 6;
            this.dtpPeriodFrom.ValueChanged += new System.EventHandler(this.dtpPeriodFrom_ValueChanged);
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(28, 73);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(64, 13);
            this.lblPeriodFrom.TabIndex = 5;
            this.lblPeriodFrom.Text = "Период \"с\"";
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(207, 73);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(70, 13);
            this.lblPeriodTo.TabIndex = 7;
            this.lblPeriodTo.Text = "Период \"по\"";
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(283, 69);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 8;
            // 
            // lblStatusID
            // 
            this.lblStatusID.AutoSize = true;
            this.lblStatusID.Location = new System.Drawing.Point(51, 102);
            this.lblStatusID.Name = "lblStatusID";
            this.lblStatusID.Size = new System.Drawing.Size(41, 13);
            this.lblStatusID.TabIndex = 9;
            this.lblStatusID.Text = "Статус";
            // 
            // stbStatusID
            // 
            this.stbStatusID.Location = new System.Drawing.Point(98, 98);
            this.stbStatusID.Name = "stbStatusID";
            this.stbStatusID.ReadOnly = false;
            this.stbStatusID.Size = new System.Drawing.Size(100, 20);
            this.stbStatusID.TabIndex = 10;
            this.stbStatusID.UserID = ((long)(0));
            this.stbStatusID.Value = null;
            this.stbStatusID.ValueReferenceQuery = null;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(12, 131);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(80, 13);
            this.lblUserID.TabIndex = 12;
            this.lblUserID.Text = "Пользователь";
            // 
            // stbUserID
            // 
            this.stbUserID.Location = new System.Drawing.Point(98, 127);
            this.stbUserID.Name = "stbUserID";
            this.stbUserID.ReadOnly = false;
            this.stbUserID.Size = new System.Drawing.Size(100, 20);
            this.stbUserID.TabIndex = 13;
            this.stbUserID.UserID = ((long)(0));
            this.stbUserID.Value = null;
            this.stbUserID.ValueReferenceQuery = null;
            // 
            // tbVendorName
            // 
            this.tbVendorName.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendorName.Location = new System.Drawing.Point(210, 41);
            this.tbVendorName.Name = "tbVendorName";
            this.tbVendorName.ReadOnly = true;
            this.tbVendorName.Size = new System.Drawing.Size(272, 20);
            this.tbVendorName.TabIndex = 4;
            // 
            // tbStatusName
            // 
            this.tbStatusName.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusName.Location = new System.Drawing.Point(210, 99);
            this.tbStatusName.Name = "tbStatusName";
            this.tbStatusName.ReadOnly = true;
            this.tbStatusName.Size = new System.Drawing.Size(272, 20);
            this.tbStatusName.TabIndex = 11;
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.SystemColors.Window;
            this.tbUserName.Location = new System.Drawing.Point(210, 128);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.ReadOnly = true;
            this.tbUserName.Size = new System.Drawing.Size(272, 20);
            this.tbUserName.TabIndex = 14;
            // 
            // VendorReturnsSearchDocsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 201);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.tbStatusName);
            this.Controls.Add(this.tbVendorName);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.stbUserID);
            this.Controls.Add(this.lblStatusID);
            this.Controls.Add(this.stbStatusID);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.dtpPeriodTo);
            this.Controls.Add(this.lblPeriodFrom);
            this.Controls.Add(this.dtpPeriodFrom);
            this.Controls.Add(this.lblVendorID);
            this.Controls.Add(this.stbVendorID);
            this.Controls.Add(this.tbDocID);
            this.Controls.Add(this.lblDocID);
            this.Name = "VendorReturnsSearchDocsForm";
            this.Text = "Параметры поиска по архиву";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VendorReturnsSearchDocsForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDocID, 0);
            this.Controls.SetChildIndex(this.tbDocID, 0);
            this.Controls.SetChildIndex(this.stbVendorID, 0);
            this.Controls.SetChildIndex(this.lblVendorID, 0);
            this.Controls.SetChildIndex(this.dtpPeriodFrom, 0);
            this.Controls.SetChildIndex(this.lblPeriodFrom, 0);
            this.Controls.SetChildIndex(this.dtpPeriodTo, 0);
            this.Controls.SetChildIndex(this.lblPeriodTo, 0);
            this.Controls.SetChildIndex(this.stbStatusID, 0);
            this.Controls.SetChildIndex(this.lblStatusID, 0);
            this.Controls.SetChildIndex(this.stbUserID, 0);
            this.Controls.SetChildIndex(this.lblUserID, 0);
            this.Controls.SetChildIndex(this.tbVendorName, 0);
            this.Controls.SetChildIndex(this.tbStatusName, 0);
            this.Controls.SetChildIndex(this.tbUserName, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.TextBox tbDocID;
        private Controls.SearchTextBox stbVendorID;
        private System.Windows.Forms.Label lblVendorID;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblStatusID;
        private Controls.SearchTextBox stbStatusID;
        private System.Windows.Forms.Label lblUserID;
        private Controls.SearchTextBox stbUserID;
        private System.Windows.Forms.TextBox tbVendorName;
        private System.Windows.Forms.TextBox tbStatusName;
        private System.Windows.Forms.TextBox tbUserName;
    }
}