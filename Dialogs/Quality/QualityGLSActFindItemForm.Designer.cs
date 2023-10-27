namespace WMSOffice.Dialogs.Quality
{
    partial class QualityGLSActFindItemForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.itemMeasurementHeaderControl = new WMSOffice.Controls.Receive.Measurement.ItemMeasurementHeaderControl();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblItemBarcode = new System.Windows.Forms.Label();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.tbsItemBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpireDate = new System.Windows.Forms.Label();
            this.tbLotNumber = new System.Windows.Forms.TextBox();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1397, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1487, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 188);
            this.pnlButtons.Size = new System.Drawing.Size(554, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.itemMeasurementHeaderControl);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(554, 105);
            this.pnlHeader.TabIndex = 0;
            // 
            // itemMeasurementHeaderControl
            // 
            this.itemMeasurementHeaderControl.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.itemMeasurementHeaderControl.DataContext = null;
            this.itemMeasurementHeaderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemMeasurementHeaderControl.Location = new System.Drawing.Point(0, 0);
            this.itemMeasurementHeaderControl.Name = "itemMeasurementHeaderControl";
            this.itemMeasurementHeaderControl.Size = new System.Drawing.Size(554, 105);
            this.itemMeasurementHeaderControl.TabIndex = 0;
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(328, 15);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(32, 13);
            this.lblItemID.TabIndex = 2;
            this.lblItemID.Text = "Код :";
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.Location = new System.Drawing.Point(4, 15);
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.Size = new System.Drawing.Size(34, 13);
            this.lblItemBarcode.TabIndex = 0;
            this.lblItemBarcode.Text = "Ш/К :";
            // 
            // stbItemID
            // 
            this.stbItemID.Location = new System.Drawing.Point(366, 11);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.NavigateByValue = false;
            this.stbItemID.ReadOnly = false;
            this.stbItemID.Size = new System.Drawing.Size(150, 20);
            this.stbItemID.TabIndex = 3;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // tbsItemBarcode
            // 
            this.tbsItemBarcode.AllowType = true;
            this.tbsItemBarcode.AutoConvert = true;
            this.tbsItemBarcode.DelayThreshold = 50;
            this.tbsItemBarcode.Location = new System.Drawing.Point(51, 9);
            this.tbsItemBarcode.Name = "tbsItemBarcode";
            this.tbsItemBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbsItemBarcode.ReadOnly = false;
            this.tbsItemBarcode.ScannerListener = null;
            this.tbsItemBarcode.Size = new System.Drawing.Size(271, 25);
            this.tbsItemBarcode.TabIndex = 1;
            this.tbsItemBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsItemBarcode.UseParentFont = false;
            this.tbsItemBarcode.UseScanModeOnly = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dtpExpireDate);
            this.pnlContent.Controls.Add(this.lblExpireDate);
            this.pnlContent.Controls.Add(this.tbLotNumber);
            this.pnlContent.Controls.Add(this.lblLotNumber);
            this.pnlContent.Controls.Add(this.lblItemBarcode);
            this.pnlContent.Controls.Add(this.stbItemID);
            this.pnlContent.Controls.Add(this.lblItemID);
            this.pnlContent.Controls.Add(this.tbsItemBarcode);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 105);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(554, 83);
            this.pnlContent.TabIndex = 1;
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.Checked = false;
            this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpireDate.Location = new System.Drawing.Point(366, 48);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.ShowCheckBox = true;
            this.dtpExpireDate.Size = new System.Drawing.Size(150, 20);
            this.dtpExpireDate.TabIndex = 7;
            // 
            // lblExpireDate
            // 
            this.lblExpireDate.AutoSize = true;
            this.lblExpireDate.Location = new System.Drawing.Point(328, 52);
            this.lblExpireDate.Name = "lblExpireDate";
            this.lblExpireDate.Size = new System.Drawing.Size(26, 13);
            this.lblExpireDate.TabIndex = 6;
            this.lblExpireDate.Text = "ТП :";
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.Location = new System.Drawing.Point(54, 48);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.Size = new System.Drawing.Size(227, 20);
            this.tbLotNumber.TabIndex = 5;
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.AutoSize = true;
            this.lblLotNumber.Location = new System.Drawing.Point(4, 52);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(44, 13);
            this.lblLotNumber.TabIndex = 4;
            this.lblLotNumber.Text = "Серия :";
            // 
            // QualityGLSActFindItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 231);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "QualityGLSActFindItemForm";
            this.Text = "Выбір товара та серії для акта розпоряджень";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityGLSFindItemForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private WMSOffice.Controls.Receive.Measurement.ItemMeasurementHeaderControl itemMeasurementHeaderControl;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblItemBarcode;
        private WMSOffice.Controls.SearchTextBox stbItemID;
        private WMSOffice.Controls.TextBoxScaner tbsItemBarcode;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.TextBox tbLotNumber;
        private System.Windows.Forms.DateTimePicker dtpExpireDate;
        private System.Windows.Forms.Label lblExpireDate;

    }
}