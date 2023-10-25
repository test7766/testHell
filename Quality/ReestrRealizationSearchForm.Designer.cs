namespace WMSOffice.Dialogs.Quality
{
    partial class ReestrRealizationSearchForm
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
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.tbxInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblPickListNumber = new System.Windows.Forms.Label();
            this.tbxPickListNumber = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxDebitorID = new System.Windows.Forms.TextBox();
            this.lblDebitorID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(12, 9);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(101, 13);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "Номер накладной:";
            // 
            // tbxInvoiceNumber
            // 
            this.tbxInvoiceNumber.Location = new System.Drawing.Point(119, 6);
            this.tbxInvoiceNumber.Name = "tbxInvoiceNumber";
            this.tbxInvoiceNumber.Size = new System.Drawing.Size(145, 20);
            this.tbxInvoiceNumber.TabIndex = 10;
            // 
            // lblPickListNumber
            // 
            this.lblPickListNumber.AutoSize = true;
            this.lblPickListNumber.Location = new System.Drawing.Point(12, 44);
            this.lblPickListNumber.Name = "lblPickListNumber";
            this.lblPickListNumber.Size = new System.Drawing.Size(105, 13);
            this.lblPickListNumber.TabIndex = 2;
            this.lblPickListNumber.Text = "Номер сборочного:";
            // 
            // tbxPickListNumber
            // 
            this.tbxPickListNumber.Location = new System.Drawing.Point(119, 41);
            this.tbxPickListNumber.Name = "tbxPickListNumber";
            this.tbxPickListNumber.Size = new System.Drawing.Size(145, 20);
            this.tbxPickListNumber.TabIndex = 20;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(12, 127);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblDateFrom.TabIndex = 4;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(119, 120);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(145, 20);
            this.dtpDateFrom.TabIndex = 40;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(119, 155);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(145, 20);
            this.dtpDateTo.TabIndex = 50;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(12, 161);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "Дата по:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(189, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(108, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxDebitorID
            // 
            this.tbxDebitorID.Location = new System.Drawing.Point(119, 78);
            this.tbxDebitorID.Name = "tbxDebitorID";
            this.tbxDebitorID.Size = new System.Drawing.Size(145, 20);
            this.tbxDebitorID.TabIndex = 30;
            // 
            // lblDebitorID
            // 
            this.lblDebitorID.AutoSize = true;
            this.lblDebitorID.Location = new System.Drawing.Point(12, 81);
            this.lblDebitorID.Name = "lblDebitorID";
            this.lblDebitorID.Size = new System.Drawing.Size(79, 13);
            this.lblDebitorID.TabIndex = 10;
            this.lblDebitorID.Text = "Код дебитора:";
            // 
            // ReestrRealizationSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(276, 238);
            this.Controls.Add(this.tbxDebitorID);
            this.Controls.Add(this.lblDebitorID);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.tbxPickListNumber);
            this.Controls.Add(this.lblPickListNumber);
            this.Controls.Add(this.tbxInvoiceNumber);
            this.Controls.Add(this.lblInvoiceNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReestrRealizationSearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск реестров";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox tbxInvoiceNumber;
        private System.Windows.Forms.Label lblPickListNumber;
        private System.Windows.Forms.TextBox tbxPickListNumber;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxDebitorID;
        private System.Windows.Forms.Label lblDebitorID;
    }
}