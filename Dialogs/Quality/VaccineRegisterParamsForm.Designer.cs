namespace WMSOffice.Dialogs.Quality
{
    partial class VaccineRegisterParamsForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chbDates = new System.Windows.Forms.CheckBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblManufacturerName = new System.Windows.Forms.Label();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.stbVendor = new WMSOffice.Controls.SearchTextBox();
            this.stbManufacturer = new WMSOffice.Controls.SearchTextBox();
            this.stbItem = new WMSOffice.Controls.SearchTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(385, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 80;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(304, 242);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 70;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chbDates
            // 
            this.chbDates.AutoSize = true;
            this.chbDates.Location = new System.Drawing.Point(12, 12);
            this.chbDates.Name = "chbDates";
            this.chbDates.Size = new System.Drawing.Size(69, 17);
            this.chbDates.TabIndex = 10;
            this.chbDates.Text = "По дате:";
            this.chbDates.UseVisualStyleBackColor = true;
            this.chbDates.CheckedChanged += new System.EventHandler(this.chbDates_CheckedChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(123, 7);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(142, 20);
            this.dtpDateFrom.TabIndex = 20;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(104, 13);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(13, 13);
            this.lblDateFrom.TabIndex = 4;
            this.lblDateFrom.Text = "с";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(293, 13);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(19, 13);
            this.lblDateTo.TabIndex = 5;
            this.lblDateTo.Text = "по";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(318, 7);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(142, 20);
            this.dtpDateTo.TabIndex = 30;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(9, 57);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(61, 13);
            this.lblItem.TabIndex = 7;
            this.lblItem.Text = "По товару:";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(9, 115);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(106, 13);
            this.lblManufacturer.TabIndex = 9;
            this.lblManufacturer.Text = "По производителю:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(9, 181);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(88, 13);
            this.lblVendor.TabIndex = 11;
            this.lblVendor.Text = "По поставщику:";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(120, 78);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(89, 13);
            this.lblItemName.TabIndex = 13;
            this.lblItemName.Text = "Товар не выбран";
            // 
            // lblManufacturerName
            // 
            this.lblManufacturerName.AutoSize = true;
            this.lblManufacturerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManufacturerName.Location = new System.Drawing.Point(120, 139);
            this.lblManufacturerName.Name = "lblManufacturerName";
            this.lblManufacturerName.Size = new System.Drawing.Size(136, 13);
            this.lblManufacturerName.TabIndex = 14;
            this.lblManufacturerName.Text = "Производитель не выбран";
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVendorName.Location = new System.Drawing.Point(120, 202);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(114, 13);
            this.lblVendorName.TabIndex = 15;
            this.lblVendorName.Text = "Поставщик не выбран";
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(123, 176);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.Size = new System.Drawing.Size(142, 23);
            this.stbVendor.TabIndex = 60;
            this.stbVendor.UserID = ((long)(0));
            this.stbVendor.Value = null;
            this.stbVendor.ValueReferenceQuery = null;
            // 
            // stbManufacturer
            // 
            this.stbManufacturer.Location = new System.Drawing.Point(123, 113);
            this.stbManufacturer.Name = "stbManufacturer";
            this.stbManufacturer.Size = new System.Drawing.Size(142, 23);
            this.stbManufacturer.TabIndex = 50;
            this.stbManufacturer.UserID = ((long)(0));
            this.stbManufacturer.Value = null;
            this.stbManufacturer.ValueReferenceQuery = null;
            // 
            // stbItem
            // 
            this.stbItem.Location = new System.Drawing.Point(123, 52);
            this.stbItem.Name = "stbItem";
            this.stbItem.Size = new System.Drawing.Size(142, 23);
            this.stbItem.TabIndex = 40;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            // 
            // VaccineRegisterParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 277);
            this.Controls.Add(this.lblVendorName);
            this.Controls.Add(this.lblManufacturerName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.stbVendor);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.stbManufacturer);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.stbItem);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.chbDates);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "VaccineRegisterParamsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры загрузки реестра вакцин";
            this.Load += new System.EventHandler(this.VaccineRegisterParamsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chbDates;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblItem;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private System.Windows.Forms.Label lblManufacturer;
        private WMSOffice.Controls.SearchTextBox stbManufacturer;
        private System.Windows.Forms.Label lblVendor;
        private WMSOffice.Controls.SearchTextBox stbVendor;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblManufacturerName;
        private System.Windows.Forms.Label lblVendorName;
    }
}