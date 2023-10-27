namespace WMSOffice.Dialogs.Receive
{
    partial class PalletsChangeVendorReturnFlagForm
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
            this.cmbVendors = new System.Windows.Forms.ComboBox();
            this.vendorsForChangeReturnFlagBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.tbAgreeNum = new System.Windows.Forms.TextBox();
            this.tbAgreeSubNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vendorsForChangeReturnFlagTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.VendorsForChangeReturnFlagTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.cbWriteOff = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorsForChangeReturnFlagBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2744, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2834, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 199);
            this.pnlButtons.Size = new System.Drawing.Size(497, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // cmbVendors
            // 
            this.cmbVendors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVendors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVendors.DataSource = this.vendorsForChangeReturnFlagBindingSource;
            this.cmbVendors.DisplayMember = "VendorName";
            this.cmbVendors.FormattingEnabled = true;
            this.cmbVendors.Location = new System.Drawing.Point(83, 10);
            this.cmbVendors.Name = "cmbVendors";
            this.cmbVendors.Size = new System.Drawing.Size(403, 21);
            this.cmbVendors.TabIndex = 0;
            this.cmbVendors.ValueMember = "Vendor_ID";
            // 
            // vendorsForChangeReturnFlagBindingSource
            // 
            this.vendorsForChangeReturnFlagBindingSource.DataMember = "VendorsForChangeReturnFlag";
            this.vendorsForChangeReturnFlagBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd / MM / yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(83, 44);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(124, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd / MM / yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(361, 44);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(124, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // tbAgreeNum
            // 
            this.tbAgreeNum.Location = new System.Drawing.Point(114, 93);
            this.tbAgreeNum.MaxLength = 50;
            this.tbAgreeNum.Name = "tbAgreeNum";
            this.tbAgreeNum.Size = new System.Drawing.Size(371, 20);
            this.tbAgreeNum.TabIndex = 1;
            // 
            // tbAgreeSubNum
            // 
            this.tbAgreeSubNum.Location = new System.Drawing.Point(114, 131);
            this.tbAgreeSubNum.MaxLength = 50;
            this.tbAgreeSubNum.Name = "tbAgreeSubNum";
            this.tbAgreeSubNum.Size = new System.Drawing.Size(371, 20);
            this.tbAgreeSubNum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Поставщик:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 107;
            this.label2.Text = "Дата \"с\":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(277, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Дата \"по\":";
            // 
            // vendorsForChangeReturnFlagTableAdapter
            // 
            this.vendorsForChangeReturnFlagTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 26);
            this.label4.TabIndex = 109;
            this.label4.Text = "№ договора /\r\nдопсоглашения:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 26);
            this.label5.TabIndex = 110;
            this.label5.Text = "Пункт договора /\r\nдопсоглашения:";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.cbWriteOff);
            this.pnlHeader.Controls.Add(this.cmbVendors);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.tbAgreeNum);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.dtpFrom);
            this.pnlHeader.Controls.Add(this.tbAgreeSubNum);
            this.pnlHeader.Controls.Add(this.dtpTo);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(497, 199);
            this.pnlHeader.TabIndex = 0;
            // 
            // cbWriteOff
            // 
            this.cbWriteOff.AutoSize = true;
            this.cbWriteOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbWriteOff.ForeColor = System.Drawing.Color.Blue;
            this.cbWriteOff.Location = new System.Drawing.Point(9, 170);
            this.cbWriteOff.Name = "cbWriteOff";
            this.cbWriteOff.Size = new System.Drawing.Size(75, 17);
            this.cbWriteOff.TabIndex = 111;
            this.cbWriteOff.Text = "Списание";
            this.cbWriteOff.UseVisualStyleBackColor = true;
            // 
            // PalletsChangeVendorReturnFlagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 242);
            this.Controls.Add(this.pnlHeader);
            this.Name = "PalletsChangeVendorReturnFlagForm";
            this.Text = "Редактор признака возвратности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PalletsChangeVendorReturnFlagForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vendorsForChangeReturnFlagBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVendors;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.TextBox tbAgreeNum;
        private System.Windows.Forms.TextBox tbAgreeSubNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource vendorsForChangeReturnFlagBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.VendorsForChangeReturnFlagTableAdapter vendorsForChangeReturnFlagTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.CheckBox cbWriteOff;
    }
}