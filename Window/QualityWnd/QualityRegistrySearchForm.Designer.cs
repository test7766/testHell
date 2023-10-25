namespace WMSOffice.Window.QualityWnd
{
    partial class QualityRegistrySearchForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelManufacturer = new System.Windows.Forms.Panel();
            this.tbManufacturer = new System.Windows.Forms.TextBox();
            this.cbManufacturer = new System.Windows.Forms.CheckBox();
            this.panelVendor = new System.Windows.Forms.Panel();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.panelBlock = new System.Windows.Forms.Panel();
            this.tbBlock = new System.Windows.Forms.TextBox();
            this.panelItem = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.panelPeriod = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbVendor = new System.Windows.Forms.CheckBox();
            this.cbBlock = new System.Windows.Forms.CheckBox();
            this.cbItem = new System.Windows.Forms.CheckBox();
            this.cbPeriod = new System.Windows.Forms.CheckBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbFind = new System.Windows.Forms.RadioButton();
            this.stbManuf = new WMSOffice.Controls.SearchTextBox();
            this.stbBlock = new WMSOffice.Controls.SearchTextBox();
            this.stbLot = new WMSOffice.Controls.SearchTextBox();
            this.stbItem = new WMSOffice.Controls.SearchTextBox();
            this.panel1.SuspendLayout();
            this.panelManufacturer.SuspendLayout();
            this.panelVendor.SuspendLayout();
            this.panelBlock.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.panelPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(333, 375);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Поиск";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(414, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelManufacturer);
            this.panel1.Controls.Add(this.cbManufacturer);
            this.panel1.Controls.Add(this.panelVendor);
            this.panel1.Controls.Add(this.panelBlock);
            this.panel1.Controls.Add(this.panelItem);
            this.panel1.Controls.Add(this.panelPeriod);
            this.panel1.Controls.Add(this.cbVendor);
            this.panel1.Controls.Add(this.cbBlock);
            this.panel1.Controls.Add(this.cbItem);
            this.panel1.Controls.Add(this.cbPeriod);
            this.panel1.Location = new System.Drawing.Point(8, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 317);
            this.panel1.TabIndex = 11;
            // 
            // panelManufacturer
            // 
            this.panelManufacturer.Controls.Add(this.stbManuf);
            this.panelManufacturer.Controls.Add(this.tbManufacturer);
            this.panelManufacturer.Location = new System.Drawing.Point(6, 282);
            this.panelManufacturer.Name = "panelManufacturer";
            this.panelManufacturer.Size = new System.Drawing.Size(468, 27);
            this.panelManufacturer.TabIndex = 18;
            // 
            // tbManufacturer
            // 
            this.tbManufacturer.Location = new System.Drawing.Point(163, 3);
            this.tbManufacturer.Name = "tbManufacturer";
            this.tbManufacturer.Size = new System.Drawing.Size(302, 20);
            this.tbManufacturer.TabIndex = 0;
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.AutoSize = true;
            this.cbManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbManufacturer.Location = new System.Drawing.Point(6, 265);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(118, 17);
            this.cbManufacturer.TabIndex = 17;
            this.cbManufacturer.Text = "производителю";
            this.cbManufacturer.UseVisualStyleBackColor = true;
            // 
            // panelVendor
            // 
            this.panelVendor.Controls.Add(this.tbVendor);
            this.panelVendor.Location = new System.Drawing.Point(6, 228);
            this.panelVendor.Name = "panelVendor";
            this.panelVendor.Size = new System.Drawing.Size(468, 25);
            this.panelVendor.TabIndex = 16;
            // 
            // tbVendor
            // 
            this.tbVendor.Location = new System.Drawing.Point(60, 2);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.Size = new System.Drawing.Size(103, 20);
            this.tbVendor.TabIndex = 0;
            // 
            // panelBlock
            // 
            this.panelBlock.Controls.Add(this.stbBlock);
            this.panelBlock.Controls.Add(this.tbBlock);
            this.panelBlock.Location = new System.Drawing.Point(6, 174);
            this.panelBlock.Name = "panelBlock";
            this.panelBlock.Size = new System.Drawing.Size(468, 26);
            this.panelBlock.TabIndex = 14;
            // 
            // tbBlock
            // 
            this.tbBlock.Location = new System.Drawing.Point(163, 3);
            this.tbBlock.Name = "tbBlock";
            this.tbBlock.Size = new System.Drawing.Size(302, 20);
            this.tbBlock.TabIndex = 0;
            // 
            // panelItem
            // 
            this.panelItem.Controls.Add(this.stbLot);
            this.panelItem.Controls.Add(this.stbItem);
            this.panelItem.Controls.Add(this.label2);
            this.panelItem.Controls.Add(this.label1);
            this.panelItem.Controls.Add(this.tbItem);
            this.panelItem.Location = new System.Drawing.Point(6, 99);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(468, 50);
            this.panelItem.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Серия:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Код:";
            // 
            // tbItem
            // 
            this.tbItem.Location = new System.Drawing.Point(163, 6);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(302, 20);
            this.tbItem.TabIndex = 0;
            // 
            // panelPeriod
            // 
            this.panelPeriod.Controls.Add(this.label4);
            this.panelPeriod.Controls.Add(this.label3);
            this.panelPeriod.Controls.Add(this.dtpEnd);
            this.panelPeriod.Controls.Add(this.dtpStart);
            this.panelPeriod.Location = new System.Drawing.Point(6, 23);
            this.panelPeriod.Name = "panelPeriod";
            this.panelPeriod.Size = new System.Drawing.Size(235, 51);
            this.panelPeriod.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "по";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "с";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "MMMM yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(60, 29);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(91, 20);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "MMMM yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(60, 6);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(91, 20);
            this.dtpStart.TabIndex = 0;
            // 
            // cbVendor
            // 
            this.cbVendor.AutoSize = true;
            this.cbVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVendor.Location = new System.Drawing.Point(6, 211);
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(97, 17);
            this.cbVendor.TabIndex = 12;
            this.cbVendor.Text = "поставщику";
            this.cbVendor.UseVisualStyleBackColor = true;
            // 
            // cbBlock
            // 
            this.cbBlock.AutoSize = true;
            this.cbBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbBlock.Location = new System.Drawing.Point(5, 157);
            this.cbBlock.Name = "cbBlock";
            this.cbBlock.Size = new System.Drawing.Size(126, 17);
            this.cbBlock.TabIndex = 11;
            this.cbBlock.Text = "типу блокировки";
            this.cbBlock.UseVisualStyleBackColor = true;
            // 
            // cbItem
            // 
            this.cbItem.AutoSize = true;
            this.cbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbItem.Location = new System.Drawing.Point(5, 82);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(66, 17);
            this.cbItem.TabIndex = 10;
            this.cbItem.Text = "товару";
            this.cbItem.UseVisualStyleBackColor = true;
            // 
            // cbPeriod
            // 
            this.cbPeriod.AutoSize = true;
            this.cbPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPeriod.Location = new System.Drawing.Point(6, 6);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(74, 17);
            this.cbPeriod.TabIndex = 9;
            this.cbPeriod.Text = "периоду";
            this.cbPeriod.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbAll.Location = new System.Drawing.Point(7, 5);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(107, 17);
            this.rbAll.TabIndex = 12;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Показать все";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbFind
            // 
            this.rbFind.AutoSize = true;
            this.rbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFind.Location = new System.Drawing.Point(7, 28);
            this.rbFind.Name = "rbFind";
            this.rbFind.Size = new System.Drawing.Size(92, 17);
            this.rbFind.TabIndex = 13;
            this.rbFind.Text = "Поиск по...";
            this.rbFind.UseVisualStyleBackColor = true;
            // 
            // stbManuf
            // 
            this.stbManuf.Location = new System.Drawing.Point(60, 3);
            this.stbManuf.Name = "stbManuf";
            this.stbManuf.Size = new System.Drawing.Size(103, 20);
            this.stbManuf.TabIndex = 6;
            this.stbManuf.UserID = ((long)(0));
            this.stbManuf.Value = null;
            this.stbManuf.ValueReferenceQuery = null;
            this.stbManuf.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(this.stbManuf_OnVerifyValue);
            // 
            // stbBlock
            // 
            this.stbBlock.Location = new System.Drawing.Point(60, 3);
            this.stbBlock.Name = "stbBlock";
            this.stbBlock.Size = new System.Drawing.Size(103, 20);
            this.stbBlock.TabIndex = 19;
            this.stbBlock.UserID = ((long)(0));
            this.stbBlock.Value = null;
            this.stbBlock.ValueReferenceQuery = null;
            this.stbBlock.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(this.stbBlock_OnVerifyValue);
            // 
            // stbLot
            // 
            this.stbLot.Location = new System.Drawing.Point(60, 27);
            this.stbLot.Name = "stbLot";
            this.stbLot.Size = new System.Drawing.Size(103, 20);
            this.stbLot.TabIndex = 5;
            this.stbLot.UserID = ((long)(0));
            this.stbLot.Value = null;
            this.stbLot.ValueReferenceQuery = null;
            this.stbLot.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(this.stbLot_OnVerifyValue);
            // 
            // stbItem
            // 
            this.stbItem.Location = new System.Drawing.Point(60, 6);
            this.stbItem.Name = "stbItem";
            this.stbItem.Size = new System.Drawing.Size(103, 20);
            this.stbItem.TabIndex = 4;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            this.stbItem.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(this.stbItem_OnVerifyValue);
            // 
            // QualityRegistrySearchForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(494, 401);
            this.Controls.Add(this.rbFind);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QualityRegistrySearchForm";
            this.Text = "Поиск";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelManufacturer.ResumeLayout(false);
            this.panelManufacturer.PerformLayout();
            this.panelVendor.ResumeLayout(false);
            this.panelVendor.PerformLayout();
            this.panelBlock.ResumeLayout(false);
            this.panelBlock.PerformLayout();
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            this.panelPeriod.ResumeLayout(false);
            this.panelPeriod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelManufacturer;
        private System.Windows.Forms.TextBox tbManufacturer;
        private System.Windows.Forms.CheckBox cbManufacturer;
        private System.Windows.Forms.Panel panelVendor;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.Panel panelBlock;
        private System.Windows.Forms.TextBox tbBlock;
        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.Panel panelPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox cbVendor;
        private System.Windows.Forms.CheckBox cbBlock;
        private System.Windows.Forms.CheckBox cbItem;
        private System.Windows.Forms.CheckBox cbPeriod;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbFind;
        private WMSOffice.Controls.SearchTextBox stbLot;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private WMSOffice.Controls.SearchTextBox stbManuf;
        private WMSOffice.Controls.SearchTextBox stbBlock;
    }
}