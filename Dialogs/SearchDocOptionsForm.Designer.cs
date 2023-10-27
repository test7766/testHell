namespace WMSOffice.Dialogs
{
    partial class SearchDocOptionsForm
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
            this.gbSearchByOrderNumber = new System.Windows.Forms.GroupBox();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.rbSearchByOrderNumber = new System.Windows.Forms.RadioButton();
            this.gbSearchByInvoiceNumber = new System.Windows.Forms.GroupBox();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.rbSearchByInvoiceNumber = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSearchByDebtor = new System.Windows.Forms.GroupBox();
            this.tbAddressCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.tbDebtorID = new System.Windows.Forms.TextBox();
            this.lblDebtorID = new System.Windows.Forms.Label();
            this.rbSearchByDebtor = new System.Windows.Forms.RadioButton();
            this.rbSearchByRoute = new System.Windows.Forms.RadioButton();
            this.gbSearchByRoute = new System.Windows.Forms.GroupBox();
            this.tbDeliveryCode = new System.Windows.Forms.TextBox();
            this.lblDeliveryCode = new System.Windows.Forms.Label();
            this.tbRouteNumber = new System.Windows.Forms.TextBox();
            this.lblRouteNumber = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.dtpWaybillDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpWaybillDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblWaybillDateTo = new System.Windows.Forms.Label();
            this.lblWaybillDateFrom = new System.Windows.Forms.Label();
            this.gbSearchByOrderNumber.SuspendLayout();
            this.gbSearchByInvoiceNumber.SuspendLayout();
            this.gbSearchByDebtor.SuspendLayout();
            this.gbSearchByRoute.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearchByOrderNumber
            // 
            this.gbSearchByOrderNumber.Controls.Add(this.tbOrderNumber);
            this.gbSearchByOrderNumber.Controls.Add(this.lblOrderNumber);
            this.gbSearchByOrderNumber.Location = new System.Drawing.Point(12, 12);
            this.gbSearchByOrderNumber.Name = "gbSearchByOrderNumber";
            this.gbSearchByOrderNumber.Size = new System.Drawing.Size(242, 49);
            this.gbSearchByOrderNumber.TabIndex = 1;
            this.gbSearchByOrderNumber.TabStop = false;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(98, 19);
            this.tbOrderNumber.MaxLength = 12;
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(134, 20);
            this.tbOrderNumber.TabIndex = 1;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(6, 22);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(60, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "№ заказа:";
            // 
            // rbSearchByOrderNumber
            // 
            this.rbSearchByOrderNumber.AutoSize = true;
            this.rbSearchByOrderNumber.Location = new System.Drawing.Point(19, 9);
            this.rbSearchByOrderNumber.Name = "rbSearchByOrderNumber";
            this.rbSearchByOrderNumber.Size = new System.Drawing.Size(121, 17);
            this.rbSearchByOrderNumber.TabIndex = 0;
            this.rbSearchByOrderNumber.TabStop = true;
            this.rbSearchByOrderNumber.Text = "По номеру заказа:";
            this.rbSearchByOrderNumber.UseVisualStyleBackColor = true;
            this.rbSearchByOrderNumber.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // gbSearchByInvoiceNumber
            // 
            this.gbSearchByInvoiceNumber.Controls.Add(this.tbInvoiceNumber);
            this.gbSearchByInvoiceNumber.Controls.Add(this.lblInvoiceNumber);
            this.gbSearchByInvoiceNumber.Location = new System.Drawing.Point(12, 67);
            this.gbSearchByInvoiceNumber.Name = "gbSearchByInvoiceNumber";
            this.gbSearchByInvoiceNumber.Size = new System.Drawing.Size(242, 49);
            this.gbSearchByInvoiceNumber.TabIndex = 3;
            this.gbSearchByInvoiceNumber.TabStop = false;
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.Location = new System.Drawing.Point(98, 19);
            this.tbInvoiceNumber.MaxLength = 12;
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.Size = new System.Drawing.Size(134, 20);
            this.tbInvoiceNumber.TabIndex = 1;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(6, 22);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(78, 13);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "№ накладной:";
            // 
            // rbSearchByInvoiceNumber
            // 
            this.rbSearchByInvoiceNumber.AutoSize = true;
            this.rbSearchByInvoiceNumber.Location = new System.Drawing.Point(19, 65);
            this.rbSearchByInvoiceNumber.Name = "rbSearchByInvoiceNumber";
            this.rbSearchByInvoiceNumber.Size = new System.Drawing.Size(139, 17);
            this.rbSearchByInvoiceNumber.TabIndex = 2;
            this.rbSearchByInvoiceNumber.TabStop = true;
            this.rbSearchByInvoiceNumber.Text = "По номеру накладной:";
            this.rbSearchByInvoiceNumber.UseVisualStyleBackColor = true;
            this.rbSearchByInvoiceNumber.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(98, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(179, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbSearchByDebtor
            // 
            this.gbSearchByDebtor.Controls.Add(this.tbAddressCode);
            this.gbSearchByDebtor.Controls.Add(this.label1);
            this.gbSearchByDebtor.Controls.Add(this.dtpDateTo);
            this.gbSearchByDebtor.Controls.Add(this.dtpDateFrom);
            this.gbSearchByDebtor.Controls.Add(this.lblDateTo);
            this.gbSearchByDebtor.Controls.Add(this.lblDateFrom);
            this.gbSearchByDebtor.Controls.Add(this.tbDebtorID);
            this.gbSearchByDebtor.Controls.Add(this.lblDebtorID);
            this.gbSearchByDebtor.Location = new System.Drawing.Point(12, 122);
            this.gbSearchByDebtor.Name = "gbSearchByDebtor";
            this.gbSearchByDebtor.Size = new System.Drawing.Size(242, 134);
            this.gbSearchByDebtor.TabIndex = 5;
            this.gbSearchByDebtor.TabStop = false;
            // 
            // tbAddressCode
            // 
            this.tbAddressCode.Location = new System.Drawing.Point(98, 45);
            this.tbAddressCode.MaxLength = 12;
            this.tbAddressCode.Name = "tbAddressCode";
            this.tbAddressCode.Size = new System.Drawing.Size(134, 20);
            this.tbAddressCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Код доставки:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(98, 100);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(134, 20);
            this.dtpDateTo.TabIndex = 7;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(98, 74);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(134, 20);
            this.dtpDateFrom.TabIndex = 5;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(6, 104);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(61, 13);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "Дата \"по\":";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(6, 78);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(55, 13);
            this.lblDateFrom.TabIndex = 4;
            this.lblDateFrom.Text = "Дата \"с\":";
            // 
            // tbDebtorID
            // 
            this.tbDebtorID.Location = new System.Drawing.Point(98, 19);
            this.tbDebtorID.MaxLength = 12;
            this.tbDebtorID.Name = "tbDebtorID";
            this.tbDebtorID.Size = new System.Drawing.Size(134, 20);
            this.tbDebtorID.TabIndex = 1;
            // 
            // lblDebtorID
            // 
            this.lblDebtorID.AutoSize = true;
            this.lblDebtorID.Location = new System.Drawing.Point(6, 22);
            this.lblDebtorID.Name = "lblDebtorID";
            this.lblDebtorID.Size = new System.Drawing.Size(79, 13);
            this.lblDebtorID.TabIndex = 0;
            this.lblDebtorID.Text = "Код дебитора:";
            // 
            // rbSearchByDebtor
            // 
            this.rbSearchByDebtor.AutoSize = true;
            this.rbSearchByDebtor.Location = new System.Drawing.Point(19, 122);
            this.rbSearchByDebtor.Name = "rbSearchByDebtor";
            this.rbSearchByDebtor.Size = new System.Drawing.Size(213, 17);
            this.rbSearchByDebtor.TabIndex = 4;
            this.rbSearchByDebtor.TabStop = true;
            this.rbSearchByDebtor.Text = "По коду дебитора/доставки и датам:";
            this.rbSearchByDebtor.UseVisualStyleBackColor = true;
            this.rbSearchByDebtor.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbSearchByRoute
            // 
            this.rbSearchByRoute.AutoSize = true;
            this.rbSearchByRoute.Location = new System.Drawing.Point(19, 260);
            this.rbSearchByRoute.Name = "rbSearchByRoute";
            this.rbSearchByRoute.Size = new System.Drawing.Size(148, 17);
            this.rbSearchByRoute.TabIndex = 6;
            this.rbSearchByRoute.TabStop = true;
            this.rbSearchByRoute.Text = "По номеру марш. листа:";
            this.rbSearchByRoute.UseVisualStyleBackColor = true;
            this.rbSearchByRoute.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // gbSearchByRoute
            // 
            this.gbSearchByRoute.Controls.Add(this.dtpWaybillDateTo);
            this.gbSearchByRoute.Controls.Add(this.dtpWaybillDateFrom);
            this.gbSearchByRoute.Controls.Add(this.lblWaybillDateTo);
            this.gbSearchByRoute.Controls.Add(this.lblWaybillDateFrom);
            this.gbSearchByRoute.Controls.Add(this.tbDeliveryCode);
            this.gbSearchByRoute.Controls.Add(this.lblDeliveryCode);
            this.gbSearchByRoute.Controls.Add(this.tbRouteNumber);
            this.gbSearchByRoute.Controls.Add(this.lblRouteNumber);
            this.gbSearchByRoute.Location = new System.Drawing.Point(12, 262);
            this.gbSearchByRoute.Name = "gbSearchByRoute";
            this.gbSearchByRoute.Size = new System.Drawing.Size(242, 134);
            this.gbSearchByRoute.TabIndex = 7;
            this.gbSearchByRoute.TabStop = false;
            this.gbSearchByRoute.Text = "263";
            // 
            // tbDeliveryCode
            // 
            this.tbDeliveryCode.Location = new System.Drawing.Point(98, 45);
            this.tbDeliveryCode.MaxLength = 12;
            this.tbDeliveryCode.Name = "tbDeliveryCode";
            this.tbDeliveryCode.Size = new System.Drawing.Size(134, 20);
            this.tbDeliveryCode.TabIndex = 3;
            // 
            // lblDeliveryCode
            // 
            this.lblDeliveryCode.AutoSize = true;
            this.lblDeliveryCode.Location = new System.Drawing.Point(6, 49);
            this.lblDeliveryCode.Name = "lblDeliveryCode";
            this.lblDeliveryCode.Size = new System.Drawing.Size(79, 13);
            this.lblDeliveryCode.TabIndex = 2;
            this.lblDeliveryCode.Text = "Код доставки:";
            // 
            // tbRouteNumber
            // 
            this.tbRouteNumber.Location = new System.Drawing.Point(98, 18);
            this.tbRouteNumber.MaxLength = 12;
            this.tbRouteNumber.Name = "tbRouteNumber";
            this.tbRouteNumber.Size = new System.Drawing.Size(134, 20);
            this.tbRouteNumber.TabIndex = 1;
            // 
            // lblRouteNumber
            // 
            this.lblRouteNumber.AutoSize = true;
            this.lblRouteNumber.Location = new System.Drawing.Point(6, 22);
            this.lblRouteNumber.Name = "lblRouteNumber";
            this.lblRouteNumber.Size = new System.Drawing.Size(87, 13);
            this.lblRouteNumber.TabIndex = 0;
            this.lblRouteNumber.Text = "№ марш. листа:";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnOK);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 406);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(266, 45);
            this.pnlFooter.TabIndex = 10;
            // 
            // dtpWaybillDateTo
            // 
            this.dtpWaybillDateTo.Location = new System.Drawing.Point(98, 100);
            this.dtpWaybillDateTo.Name = "dtpWaybillDateTo";
            this.dtpWaybillDateTo.Size = new System.Drawing.Size(134, 20);
            this.dtpWaybillDateTo.TabIndex = 7;
            // 
            // dtpWaybillDateFrom
            // 
            this.dtpWaybillDateFrom.Location = new System.Drawing.Point(98, 74);
            this.dtpWaybillDateFrom.Name = "dtpWaybillDateFrom";
            this.dtpWaybillDateFrom.Size = new System.Drawing.Size(134, 20);
            this.dtpWaybillDateFrom.TabIndex = 5;
            // 
            // lblWaybillDateTo
            // 
            this.lblWaybillDateTo.AutoSize = true;
            this.lblWaybillDateTo.Location = new System.Drawing.Point(6, 104);
            this.lblWaybillDateTo.Name = "lblWaybillDateTo";
            this.lblWaybillDateTo.Size = new System.Drawing.Size(61, 13);
            this.lblWaybillDateTo.TabIndex = 6;
            this.lblWaybillDateTo.Text = "Дата \"по\":";
            // 
            // lblWaybillDateFrom
            // 
            this.lblWaybillDateFrom.AutoSize = true;
            this.lblWaybillDateFrom.Location = new System.Drawing.Point(6, 78);
            this.lblWaybillDateFrom.Name = "lblWaybillDateFrom";
            this.lblWaybillDateFrom.Size = new System.Drawing.Size(55, 13);
            this.lblWaybillDateFrom.TabIndex = 4;
            this.lblWaybillDateFrom.Text = "Дата \"с\":";
            // 
            // SearchDocOptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(266, 451);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.rbSearchByRoute);
            this.Controls.Add(this.rbSearchByDebtor);
            this.Controls.Add(this.gbSearchByRoute);
            this.Controls.Add(this.gbSearchByDebtor);
            this.Controls.Add(this.rbSearchByOrderNumber);
            this.Controls.Add(this.rbSearchByInvoiceNumber);
            this.Controls.Add(this.gbSearchByInvoiceNumber);
            this.Controls.Add(this.gbSearchByOrderNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchDocOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры поиска документа";
            this.gbSearchByOrderNumber.ResumeLayout(false);
            this.gbSearchByOrderNumber.PerformLayout();
            this.gbSearchByInvoiceNumber.ResumeLayout(false);
            this.gbSearchByInvoiceNumber.PerformLayout();
            this.gbSearchByDebtor.ResumeLayout(false);
            this.gbSearchByDebtor.PerformLayout();
            this.gbSearchByRoute.ResumeLayout(false);
            this.gbSearchByRoute.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchByOrderNumber;
        private System.Windows.Forms.RadioButton rbSearchByOrderNumber;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.GroupBox gbSearchByInvoiceNumber;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.RadioButton rbSearchByInvoiceNumber;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbSearchByDebtor;
        private System.Windows.Forms.TextBox tbDebtorID;
        private System.Windows.Forms.Label lblDebtorID;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.RadioButton rbSearchByDebtor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAddressCode;
        private System.Windows.Forms.RadioButton rbSearchByRoute;
        private System.Windows.Forms.GroupBox gbSearchByRoute;
        private System.Windows.Forms.TextBox tbDeliveryCode;
        private System.Windows.Forms.Label lblDeliveryCode;
        private System.Windows.Forms.TextBox tbRouteNumber;
        private System.Windows.Forms.Label lblRouteNumber;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.DateTimePicker dtpWaybillDateTo;
        private System.Windows.Forms.DateTimePicker dtpWaybillDateFrom;
        private System.Windows.Forms.Label lblWaybillDateTo;
        private System.Windows.Forms.Label lblWaybillDateFrom;
    }
}