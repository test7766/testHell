namespace WMSOffice.Dialogs.WH
{
    partial class ElectronicInvoiceSearchDialog
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
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTaxInvoiceID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInvoiceID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUseDates = new System.Windows.Forms.CheckBox();
            this.lblDebtorID = new System.Windows.Forms.Label();
            this.stbDebtorID = new WMSOffice.Controls.SearchTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDeliveryID = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3649, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3739, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 214);
            this.pnlButtons.Size = new System.Drawing.Size(472, 43);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "";
            this.dtpDateFrom.Enabled = false;
            this.dtpDateFrom.Location = new System.Drawing.Point(9, 45);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(169, 20);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Enabled = false;
            this.dtpDateTo.Location = new System.Drawing.Point(262, 45);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(169, 20);
            this.dtpDateTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Код дебитора:";
            // 
            // tbTaxInvoiceID
            // 
            this.tbTaxInvoiceID.Location = new System.Drawing.Point(118, 63);
            this.tbTaxInvoiceID.Name = "tbTaxInvoiceID";
            this.tbTaxInvoiceID.Size = new System.Drawing.Size(100, 20);
            this.tbTaxInvoiceID.TabIndex = 2;
            this.tbTaxInvoiceID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl_KeyDown);
            this.tbTaxInvoiceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Номер налоговой:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Номер расходной:";
            // 
            // tbInvoiceID
            // 
            this.tbInvoiceID.Location = new System.Drawing.Point(118, 92);
            this.tbInvoiceID.Name = "tbInvoiceID";
            this.tbInvoiceID.Size = new System.Drawing.Size(100, 20);
            this.tbInvoiceID.TabIndex = 3;
            this.tbInvoiceID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl_KeyDown);
            this.tbInvoiceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 109;
            this.label4.Text = "Дата \"с\":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 110;
            this.label5.Text = "Дата \"по\":";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUseDates);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 73);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cbUseDates
            // 
            this.cbUseDates.AutoSize = true;
            this.cbUseDates.Location = new System.Drawing.Point(9, 0);
            this.cbUseDates.Name = "cbUseDates";
            this.cbUseDates.Size = new System.Drawing.Size(101, 17);
            this.cbUseDates.TabIndex = 1;
            this.cbUseDates.Text = "Установка дат";
            this.cbUseDates.UseVisualStyleBackColor = true;
            this.cbUseDates.CheckedChanged += new System.EventHandler(this.cbUseDates_CheckedChanged);
            // 
            // lblDebtorID
            // 
            this.lblDebtorID.AutoSize = true;
            this.lblDebtorID.Location = new System.Drawing.Point(94, 32);
            this.lblDebtorID.Name = "lblDebtorID";
            this.lblDebtorID.Size = new System.Drawing.Size(0, 13);
            this.lblDebtorID.TabIndex = 112;
            // 
            // stbDebtorID
            // 
            this.stbDebtorID.Location = new System.Drawing.Point(97, 9);
            this.stbDebtorID.Name = "stbDebtorID";
            this.stbDebtorID.Size = new System.Drawing.Size(100, 23);
            this.stbDebtorID.TabIndex = 1;
            this.stbDebtorID.UserID = ((long)(0));
            this.stbDebtorID.Value = null;
            this.stbDebtorID.ValueReferenceQuery = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "Номер заказа:";
            // 
            // tbOrderID
            // 
            this.tbOrderID.Location = new System.Drawing.Point(360, 63);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.Size = new System.Drawing.Size(100, 20);
            this.tbOrderID.TabIndex = 4;
            this.tbOrderID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl_KeyDown);
            this.tbOrderID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 116;
            this.label7.Text = "Код доставки:";
            // 
            // tbDeliveryID
            // 
            this.tbDeliveryID.Location = new System.Drawing.Point(360, 92);
            this.tbDeliveryID.Name = "tbDeliveryID";
            this.tbDeliveryID.Size = new System.Drawing.Size(100, 20);
            this.tbDeliveryID.TabIndex = 5;
            this.tbDeliveryID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl_KeyDown);
            this.tbDeliveryID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // ElectronicInvoiceSearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 257);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbDeliveryID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbOrderID);
            this.Controls.Add(this.lblDebtorID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbInvoiceID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTaxInvoiceID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stbDebtorID);
            this.Name = "ElectronicInvoiceSearchDialog";
            this.Text = "Параметры поиска электронных накладных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElectronicInvoiceSearchDialog_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.stbDebtorID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbTaxInvoiceID, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbInvoiceID, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblDebtorID, 0);
            this.Controls.SetChildIndex(this.tbOrderID, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tbDeliveryID, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.pnlButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private WMSOffice.Controls.SearchTextBox stbDebtorID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTaxInvoiceID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInvoiceID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDebtorID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.CheckBox cbUseDates;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDeliveryID;
    }
}