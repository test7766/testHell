namespace WMSOffice.Dialogs.WH.SD
{
    partial class SalesDispatcherBringOnChargeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.tbDeliveryPerson = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtRecieveDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.stbLocation = new WMSOffice.Controls.SearchTextBox();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.pnlEditData = new System.Windows.Forms.Panel();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlEditData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(558, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(648, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 198);
            this.pnlButtons.Size = new System.Drawing.Size(434, 43);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Тип заказа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Получатель:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "№ заказа:";
            // 
            // tbDocType
            // 
            this.tbDocType.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocType.Location = new System.Drawing.Point(83, 6);
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.ReadOnly = true;
            this.tbDocType.Size = new System.Drawing.Size(40, 20);
            this.tbDocType.TabIndex = 104;
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocNumber.Location = new System.Drawing.Point(228, 6);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.ReadOnly = true;
            this.tbDocNumber.Size = new System.Drawing.Size(100, 20);
            this.tbDocNumber.TabIndex = 105;
            // 
            // tbDeliveryPerson
            // 
            this.tbDeliveryPerson.BackColor = System.Drawing.SystemColors.Window;
            this.tbDeliveryPerson.Location = new System.Drawing.Point(82, 38);
            this.tbDeliveryPerson.Name = "tbDeliveryPerson";
            this.tbDeliveryPerson.ReadOnly = true;
            this.tbDeliveryPerson.Size = new System.Drawing.Size(341, 20);
            this.tbDeliveryPerson.TabIndex = 106;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Дата получения:";
            // 
            // dtRecieveDate
            // 
            this.dtRecieveDate.CustomFormat = "dd / MM / yyyy";
            this.dtRecieveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRecieveDate.Location = new System.Drawing.Point(103, 6);
            this.dtRecieveDate.Name = "dtRecieveDate";
            this.dtRecieveDate.Size = new System.Drawing.Size(121, 20);
            this.dtRecieveDate.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 109;
            this.label5.Text = "Склад:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 110;
            this.label6.Text = "Место:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 111;
            this.label7.Text = "Примечание:";
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(55, 39);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.Size = new System.Drawing.Size(169, 23);
            this.stbWarehouse.TabIndex = 112;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // stbLocation
            // 
            this.stbLocation.Location = new System.Drawing.Point(54, 72);
            this.stbLocation.Name = "stbLocation";
            this.stbLocation.Size = new System.Drawing.Size(170, 23);
            this.stbLocation.TabIndex = 113;
            this.stbLocation.UserID = ((long)(0));
            this.stbLocation.Value = null;
            this.stbLocation.ValueReferenceQuery = null;
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(88, 105);
            this.tbComments.MaxLength = 8;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(136, 20);
            this.tbComments.TabIndex = 114;
            // 
            // pnlEditData
            // 
            this.pnlEditData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditData.Controls.Add(this.lblLocation);
            this.pnlEditData.Controls.Add(this.lblWarehouse);
            this.pnlEditData.Controls.Add(this.label4);
            this.pnlEditData.Controls.Add(this.dtRecieveDate);
            this.pnlEditData.Controls.Add(this.tbComments);
            this.pnlEditData.Controls.Add(this.label5);
            this.pnlEditData.Controls.Add(this.stbLocation);
            this.pnlEditData.Controls.Add(this.label6);
            this.pnlEditData.Controls.Add(this.stbWarehouse);
            this.pnlEditData.Controls.Add(this.label7);
            this.pnlEditData.Location = new System.Drawing.Point(0, 64);
            this.pnlEditData.Name = "pnlEditData";
            this.pnlEditData.Size = new System.Drawing.Size(434, 132);
            this.pnlEditData.TabIndex = 116;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(227, 72);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(202, 30);
            this.lblLocation.TabIndex = 116;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Location = new System.Drawing.Point(227, 39);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(202, 30);
            this.lblWarehouse.TabIndex = 115;
            // 
            // SalesDispatcherBringOnChargeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 241);
            this.Controls.Add(this.pnlEditData);
            this.Controls.Add(this.tbDeliveryPerson);
            this.Controls.Add(this.tbDocNumber);
            this.Controls.Add(this.tbDocType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SalesDispatcherBringOnChargeForm";
            this.Text = "Подтверждение даты получения";
            this.Load += new System.EventHandler(this.SalesDispatcherBringOnChargeForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalesDispatcherBringOnChargeForm_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbDocType, 0);
            this.Controls.SetChildIndex(this.tbDocNumber, 0);
            this.Controls.SetChildIndex(this.tbDeliveryPerson, 0);
            this.Controls.SetChildIndex(this.pnlEditData, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlEditData.ResumeLayout(false);
            this.pnlEditData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDocType;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.TextBox tbDeliveryPerson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtRecieveDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private WMSOffice.Controls.SearchTextBox stbLocation;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Panel pnlEditData;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblLocation;
    }
}