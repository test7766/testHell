namespace WMSOffice.Dialogs.Quality
{
    partial class QualityInputControlsFindShipmentsForm
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
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.stbVendor = new WMSOffice.Controls.SearchTextBox();
            this.stbStatusFrom = new WMSOffice.Controls.SearchTextBox();
            this.lblStatusFrom = new System.Windows.Forms.Label();
            this.stbStatusTo = new WMSOffice.Controls.SearchTextBox();
            this.lblStatusTo = new System.Windows.Forms.Label();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.tbStatusFrom = new System.Windows.Forms.TextBox();
            this.tbStatusTo = new System.Windows.Forms.TextBox();
            this.lblShipmentID = new System.Windows.Forms.Label();
            this.tbShipmentID = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(749, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(839, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 288);
            this.pnlButtons.Size = new System.Drawing.Size(494, 43);
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(34, 25);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(46, 13);
            this.lblPeriodFrom.TabIndex = 0;
            this.lblPeriodFrom.Text = "Дата С:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(83, 21);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.ShowCheckBox = true;
            this.dtpPeriodFrom.Size = new System.Drawing.Size(153, 20);
            this.dtpPeriodFrom.TabIndex = 1;
            this.dtpPeriodFrom.ValueChanged += new System.EventHandler(this.dtpPeriodFrom_ValueChanged);
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(332, 21);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.ShowCheckBox = true;
            this.dtpPeriodTo.Size = new System.Drawing.Size(150, 20);
            this.dtpPeriodTo.TabIndex = 3;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(271, 25);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(55, 13);
            this.lblPeriodTo.TabIndex = 2;
            this.lblPeriodTo.Text = "Дата ПО:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(12, 94);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 4;
            this.lblVendor.Text = "Поставщик:";
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(83, 90);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.ReadOnly = false;
            this.stbVendor.Size = new System.Drawing.Size(153, 20);
            this.stbVendor.TabIndex = 5;
            this.stbVendor.UserID = ((long)(0));
            this.stbVendor.Value = null;
            this.stbVendor.ValueReferenceQuery = null;
            // 
            // stbStatusFrom
            // 
            this.stbStatusFrom.Location = new System.Drawing.Point(86, 228);
            this.stbStatusFrom.Name = "stbStatusFrom";
            this.stbStatusFrom.ReadOnly = false;
            this.stbStatusFrom.Size = new System.Drawing.Size(150, 20);
            this.stbStatusFrom.TabIndex = 10;
            this.stbStatusFrom.UserID = ((long)(0));
            this.stbStatusFrom.Value = null;
            this.stbStatusFrom.ValueReferenceQuery = null;
            // 
            // lblStatusFrom
            // 
            this.lblStatusFrom.AutoSize = true;
            this.lblStatusFrom.Location = new System.Drawing.Point(26, 232);
            this.lblStatusFrom.Name = "lblStatusFrom";
            this.lblStatusFrom.Size = new System.Drawing.Size(54, 13);
            this.lblStatusFrom.TabIndex = 9;
            this.lblStatusFrom.Text = "Статус С:";
            // 
            // stbStatusTo
            // 
            this.stbStatusTo.Location = new System.Drawing.Point(332, 228);
            this.stbStatusTo.Name = "stbStatusTo";
            this.stbStatusTo.ReadOnly = false;
            this.stbStatusTo.Size = new System.Drawing.Size(150, 20);
            this.stbStatusTo.TabIndex = 13;
            this.stbStatusTo.UserID = ((long)(0));
            this.stbStatusTo.Value = null;
            this.stbStatusTo.ValueReferenceQuery = null;
            // 
            // lblStatusTo
            // 
            this.lblStatusTo.AutoSize = true;
            this.lblStatusTo.Location = new System.Drawing.Point(263, 232);
            this.lblStatusTo.Name = "lblStatusTo";
            this.lblStatusTo.Size = new System.Drawing.Size(63, 13);
            this.lblStatusTo.TabIndex = 12;
            this.lblStatusTo.Text = "Статус ПО:";
            // 
            // tbVendor
            // 
            this.tbVendor.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendor.Location = new System.Drawing.Point(242, 90);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.ReadOnly = true;
            this.tbVendor.Size = new System.Drawing.Size(240, 20);
            this.tbVendor.TabIndex = 6;
            // 
            // tbStatusFrom
            // 
            this.tbStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusFrom.Location = new System.Drawing.Point(86, 256);
            this.tbStatusFrom.Name = "tbStatusFrom";
            this.tbStatusFrom.ReadOnly = true;
            this.tbStatusFrom.Size = new System.Drawing.Size(150, 20);
            this.tbStatusFrom.TabIndex = 11;
            // 
            // tbStatusTo
            // 
            this.tbStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusTo.Location = new System.Drawing.Point(332, 256);
            this.tbStatusTo.Name = "tbStatusTo";
            this.tbStatusTo.ReadOnly = true;
            this.tbStatusTo.Size = new System.Drawing.Size(150, 20);
            this.tbStatusTo.TabIndex = 14;
            // 
            // lblShipmentID
            // 
            this.lblShipmentID.AutoSize = true;
            this.lblShipmentID.Location = new System.Drawing.Point(12, 163);
            this.lblShipmentID.Name = "lblShipmentID";
            this.lblShipmentID.Size = new System.Drawing.Size(71, 13);
            this.lblShipmentID.TabIndex = 7;
            this.lblShipmentID.Text = "№ поставки:";
            // 
            // tbShipmentID
            // 
            this.tbShipmentID.BackColor = System.Drawing.SystemColors.Window;
            this.tbShipmentID.Location = new System.Drawing.Point(83, 159);
            this.tbShipmentID.Name = "tbShipmentID";
            this.tbShipmentID.Size = new System.Drawing.Size(153, 20);
            this.tbShipmentID.TabIndex = 8;
            // 
            // QualityInputControlsFindShipmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 331);
            this.Controls.Add(this.tbShipmentID);
            this.Controls.Add(this.lblShipmentID);
            this.Controls.Add(this.tbStatusTo);
            this.Controls.Add(this.tbStatusFrom);
            this.Controls.Add(this.tbVendor);
            this.Controls.Add(this.stbStatusTo);
            this.Controls.Add(this.lblStatusTo);
            this.Controls.Add(this.stbStatusFrom);
            this.Controls.Add(this.lblStatusFrom);
            this.Controls.Add(this.stbVendor);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.dtpPeriodTo);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.dtpPeriodFrom);
            this.Controls.Add(this.lblPeriodFrom);
            this.Name = "QualityInputControlsFindShipmentsForm";
            this.Text = "Параметры поиска реестра поставок";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityInputControlsFindShipmentsForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblPeriodFrom, 0);
            this.Controls.SetChildIndex(this.dtpPeriodFrom, 0);
            this.Controls.SetChildIndex(this.lblPeriodTo, 0);
            this.Controls.SetChildIndex(this.dtpPeriodTo, 0);
            this.Controls.SetChildIndex(this.lblVendor, 0);
            this.Controls.SetChildIndex(this.stbVendor, 0);
            this.Controls.SetChildIndex(this.lblStatusFrom, 0);
            this.Controls.SetChildIndex(this.stbStatusFrom, 0);
            this.Controls.SetChildIndex(this.lblStatusTo, 0);
            this.Controls.SetChildIndex(this.stbStatusTo, 0);
            this.Controls.SetChildIndex(this.tbVendor, 0);
            this.Controls.SetChildIndex(this.tbStatusFrom, 0);
            this.Controls.SetChildIndex(this.tbStatusTo, 0);
            this.Controls.SetChildIndex(this.lblShipmentID, 0);
            this.Controls.SetChildIndex(this.tbShipmentID, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblVendor;
        private Controls.SearchTextBox stbVendor;
        private Controls.SearchTextBox stbStatusFrom;
        private System.Windows.Forms.Label lblStatusFrom;
        private Controls.SearchTextBox stbStatusTo;
        private System.Windows.Forms.Label lblStatusTo;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.TextBox tbStatusFrom;
        private System.Windows.Forms.TextBox tbStatusTo;
        private System.Windows.Forms.Label lblShipmentID;
        private System.Windows.Forms.TextBox tbShipmentID;
    }
}