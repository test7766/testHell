namespace WMSOffice.Dialogs.InterBranch
{
    partial class SearchOptionsForm
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
            this.gbSenderShipTo = new System.Windows.Forms.GroupBox();
            this.lblShipToID = new System.Windows.Forms.Label();
            this.tbShipToID = new System.Windows.Forms.TextBox();
            this.lblSenderID = new System.Windows.Forms.Label();
            this.tbSenderID = new System.Windows.Forms.TextBox();
            this.gbDateFromTo = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkbOrderType = new System.Windows.Forms.CheckBox();
            this.chkbSenderShipTo = new System.Windows.Forms.CheckBox();
            this.chkbDateFromTo = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.tbOrderType = new System.Windows.Forms.TextBox();
            this.chkbOrderID = new System.Windows.Forms.CheckBox();
            this.gbSenderShipTo.SuspendLayout();
            this.gbDateFromTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSenderShipTo
            // 
            this.gbSenderShipTo.Controls.Add(this.lblShipToID);
            this.gbSenderShipTo.Controls.Add(this.tbShipToID);
            this.gbSenderShipTo.Controls.Add(this.lblSenderID);
            this.gbSenderShipTo.Controls.Add(this.tbSenderID);
            this.gbSenderShipTo.Enabled = false;
            this.gbSenderShipTo.Location = new System.Drawing.Point(12, 67);
            this.gbSenderShipTo.Name = "gbSenderShipTo";
            this.gbSenderShipTo.Size = new System.Drawing.Size(259, 75);
            this.gbSenderShipTo.TabIndex = 5;
            this.gbSenderShipTo.TabStop = false;
            // 
            // lblShipToID
            // 
            this.lblShipToID.AutoSize = true;
            this.lblShipToID.Location = new System.Drawing.Point(6, 48);
            this.lblShipToID.Name = "lblShipToID";
            this.lblShipToID.Size = new System.Drawing.Size(89, 13);
            this.lblShipToID.TabIndex = 2;
            this.lblShipToID.Text = "Код получателя:";
            // 
            // tbShipToID
            // 
            this.tbShipToID.Location = new System.Drawing.Point(142, 45);
            this.tbShipToID.MaxLength = 6;
            this.tbShipToID.Name = "tbShipToID";
            this.tbShipToID.Size = new System.Drawing.Size(50, 20);
            this.tbShipToID.TabIndex = 3;
            this.tbShipToID.Text = "17002";
            // 
            // lblSenderID
            // 
            this.lblSenderID.AutoSize = true;
            this.lblSenderID.Location = new System.Drawing.Point(6, 22);
            this.lblSenderID.Name = "lblSenderID";
            this.lblSenderID.Size = new System.Drawing.Size(96, 13);
            this.lblSenderID.TabIndex = 0;
            this.lblSenderID.Text = "Код отправителя:";
            // 
            // tbSenderID
            // 
            this.tbSenderID.Location = new System.Drawing.Point(142, 19);
            this.tbSenderID.MaxLength = 6;
            this.tbSenderID.Name = "tbSenderID";
            this.tbSenderID.Size = new System.Drawing.Size(50, 20);
            this.tbSenderID.TabIndex = 1;
            this.tbSenderID.Text = "17001";
            // 
            // gbDateFromTo
            // 
            this.gbDateFromTo.Controls.Add(this.dtpDateTo);
            this.gbDateFromTo.Controls.Add(this.dtpDateFrom);
            this.gbDateFromTo.Controls.Add(this.lblDateTo);
            this.gbDateFromTo.Controls.Add(this.lblDateFrom);
            this.gbDateFromTo.Enabled = false;
            this.gbDateFromTo.Location = new System.Drawing.Point(12, 148);
            this.gbDateFromTo.Name = "gbDateFromTo";
            this.gbDateFromTo.Size = new System.Drawing.Size(259, 75);
            this.gbDateFromTo.TabIndex = 7;
            this.gbDateFromTo.TabStop = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(120, 45);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(103, 20);
            this.dtpDateTo.TabIndex = 7;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(120, 19);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(103, 20);
            this.dtpDateFrom.TabIndex = 5;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(6, 48);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(96, 13);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "Дата заказа (по):";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(6, 22);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(90, 13);
            this.lblDateFrom.TabIndex = 4;
            this.lblDateFrom.Text = "Дата заказа (с):";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(115, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(196, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkbOrderType
            // 
            this.chkbOrderType.AutoSize = true;
            this.chkbOrderType.Checked = true;
            this.chkbOrderType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbOrderType.Location = new System.Drawing.Point(21, 15);
            this.chkbOrderType.Name = "chkbOrderType";
            this.chkbOrderType.Size = new System.Drawing.Size(102, 17);
            this.chkbOrderType.TabIndex = 0;
            this.chkbOrderType.Text = "Тип документа";
            this.chkbOrderType.UseVisualStyleBackColor = true;
            this.chkbOrderType.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chkbSenderShipTo
            // 
            this.chkbSenderShipTo.AutoSize = true;
            this.chkbSenderShipTo.Location = new System.Drawing.Point(21, 67);
            this.chkbSenderShipTo.Name = "chkbSenderShipTo";
            this.chkbSenderShipTo.Size = new System.Drawing.Size(237, 17);
            this.chkbSenderShipTo.TabIndex = 4;
            this.chkbSenderShipTo.Text = "Отправитель / получатель (по адр. книге)";
            this.chkbSenderShipTo.UseVisualStyleBackColor = true;
            this.chkbSenderShipTo.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chkbDateFromTo
            // 
            this.chkbDateFromTo.AutoSize = true;
            this.chkbDateFromTo.Location = new System.Drawing.Point(21, 147);
            this.chkbDateFromTo.Name = "chkbDateFromTo";
            this.chkbDateFromTo.Size = new System.Drawing.Size(84, 17);
            this.chkbDateFromTo.TabIndex = 6;
            this.chkbDateFromTo.Text = "Период дат";
            this.chkbDateFromTo.UseVisualStyleBackColor = true;
            this.chkbDateFromTo.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tbOrderID
            // 
            this.tbOrderID.Enabled = false;
            this.tbOrderID.Location = new System.Drawing.Point(154, 39);
            this.tbOrderID.MaxLength = 12;
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.Size = new System.Drawing.Size(91, 20);
            this.tbOrderID.TabIndex = 3;
            // 
            // tbOrderType
            // 
            this.tbOrderType.Location = new System.Drawing.Point(154, 13);
            this.tbOrderType.MaxLength = 2;
            this.tbOrderType.Name = "tbOrderType";
            this.tbOrderType.Size = new System.Drawing.Size(40, 20);
            this.tbOrderType.TabIndex = 1;
            this.tbOrderType.Text = "40";
            // 
            // chkbOrderID
            // 
            this.chkbOrderID.AutoSize = true;
            this.chkbOrderID.Location = new System.Drawing.Point(21, 41);
            this.chkbOrderID.Name = "chkbOrderID";
            this.chkbOrderID.Size = new System.Drawing.Size(127, 17);
            this.chkbOrderID.TabIndex = 2;
            this.chkbOrderID.Text = "№ зак. (накладной):";
            this.chkbOrderID.UseVisualStyleBackColor = true;
            this.chkbOrderID.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // SearchOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(283, 264);
            this.ControlBox = false;
            this.Controls.Add(this.chkbOrderID);
            this.Controls.Add(this.tbOrderID);
            this.Controls.Add(this.tbOrderType);
            this.Controls.Add(this.chkbDateFromTo);
            this.Controls.Add(this.chkbSenderShipTo);
            this.Controls.Add(this.chkbOrderType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbDateFromTo);
            this.Controls.Add(this.gbSenderShipTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры поиска накладных";
            this.gbSenderShipTo.ResumeLayout(false);
            this.gbSenderShipTo.PerformLayout();
            this.gbDateFromTo.ResumeLayout(false);
            this.gbDateFromTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSenderShipTo;
        private System.Windows.Forms.Label lblShipToID;
        private System.Windows.Forms.TextBox tbShipToID;
        private System.Windows.Forms.Label lblSenderID;
        private System.Windows.Forms.TextBox tbSenderID;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.GroupBox gbDateFromTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkbOrderType;
        private System.Windows.Forms.CheckBox chkbSenderShipTo;
        private System.Windows.Forms.CheckBox chkbDateFromTo;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.TextBox tbOrderType;
        private System.Windows.Forms.CheckBox chkbOrderID;
    }
}