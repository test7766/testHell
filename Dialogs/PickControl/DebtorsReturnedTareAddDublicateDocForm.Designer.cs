namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareAddDublicateDocForm
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
            this.cbWithoutBarCode = new System.Windows.Forms.CheckBox();
            this.gbWithoutBarCode = new System.Windows.Forms.GroupBox();
            this.cmbTareType = new System.Windows.Forms.ComboBox();
            this.clientTareTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.lblTareType = new System.Windows.Forms.Label();
            this.tbTareBarCode = new System.Windows.Forms.TextBox();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.clientTareTypesTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.ClientTareTypesTableAdapter();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.gbWithoutBarCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientTareTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(97, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(187, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 158);
            this.pnlButtons.Size = new System.Drawing.Size(274, 43);
            this.pnlButtons.TabIndex = 7;
            // 
            // cbWithoutBarCode
            // 
            this.cbWithoutBarCode.AutoSize = true;
            this.cbWithoutBarCode.Location = new System.Drawing.Point(12, 36);
            this.cbWithoutBarCode.Name = "cbWithoutBarCode";
            this.cbWithoutBarCode.Size = new System.Drawing.Size(69, 17);
            this.cbWithoutBarCode.TabIndex = 2;
            this.cbWithoutBarCode.Text = "Без Ш/К";
            this.cbWithoutBarCode.UseVisualStyleBackColor = true;
            this.cbWithoutBarCode.CheckedChanged += new System.EventHandler(this.cbWithoutBarCode_CheckedChanged);
            // 
            // gbWithoutBarCode
            // 
            this.gbWithoutBarCode.Controls.Add(this.cmbTareType);
            this.gbWithoutBarCode.Controls.Add(this.lblTareType);
            this.gbWithoutBarCode.Location = new System.Drawing.Point(6, 37);
            this.gbWithoutBarCode.Name = "gbWithoutBarCode";
            this.gbWithoutBarCode.Size = new System.Drawing.Size(260, 60);
            this.gbWithoutBarCode.TabIndex = 3;
            this.gbWithoutBarCode.TabStop = false;
            // 
            // cmbTareType
            // 
            this.cmbTareType.DataSource = this.clientTareTypesBindingSource;
            this.cmbTareType.DisplayMember = "Tare_Type_Description";
            this.cmbTareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTareType.FormattingEnabled = true;
            this.cmbTareType.Location = new System.Drawing.Point(79, 28);
            this.cmbTareType.Name = "cmbTareType";
            this.cmbTareType.Size = new System.Drawing.Size(175, 21);
            this.cmbTareType.TabIndex = 1;
            this.cmbTareType.ValueMember = "Tare_Type";
            // 
            // clientTareTypesBindingSource
            // 
            this.clientTareTypesBindingSource.DataMember = "ClientTareTypes";
            this.clientTareTypesBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblTareType
            // 
            this.lblTareType.AutoSize = true;
            this.lblTareType.Location = new System.Drawing.Point(21, 32);
            this.lblTareType.Name = "lblTareType";
            this.lblTareType.Size = new System.Drawing.Size(54, 13);
            this.lblTareType.TabIndex = 0;
            this.lblTareType.Text = "Тип тары";
            // 
            // tbTareBarCode
            // 
            this.tbTareBarCode.Location = new System.Drawing.Point(84, 5);
            this.tbTareBarCode.Name = "tbTareBarCode";
            this.tbTareBarCode.Size = new System.Drawing.Size(182, 20);
            this.tbTareBarCode.TabIndex = 1;
            this.tbTareBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTareBarCode_KeyDown);
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Location = new System.Drawing.Point(5, 9);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(73, 13);
            this.lblBarCode.TabIndex = 0;
            this.lblBarCode.Text = "Введите Ш/К";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(40, 112);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(38, 13);
            this.lblWarehouse.TabIndex = 4;
            this.lblWarehouse.Text = "Склад";
            // 
            // clientTareTypesTableAdapter
            // 
            this.clientTareTypesTableAdapter.ClearBeforeFill = true;
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(85, 108);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(181, 20);
            this.stbWarehouse.TabIndex = 5;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.AutoSize = true;
            this.lblWarehouseName.Location = new System.Drawing.Point(89, 136);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseName.TabIndex = 6;
            // 
            // DebtorsReturnedTareAddDublicateDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 201);
            this.Controls.Add(this.lblWarehouseName);
            this.Controls.Add(this.stbWarehouse);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.cbWithoutBarCode);
            this.Controls.Add(this.gbWithoutBarCode);
            this.Controls.Add(this.tbTareBarCode);
            this.Controls.Add(this.lblBarCode);
            this.Name = "DebtorsReturnedTareAddDublicateDocForm";
            this.Text = "Регистрация проблемной тары";
            this.Load += new System.EventHandler(this.DebtorsReturnedTareAddDublicateDocForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebtorsReturnedTareAddDublicateDocForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblBarCode, 0);
            this.Controls.SetChildIndex(this.tbTareBarCode, 0);
            this.Controls.SetChildIndex(this.gbWithoutBarCode, 0);
            this.Controls.SetChildIndex(this.cbWithoutBarCode, 0);
            this.Controls.SetChildIndex(this.lblWarehouse, 0);
            this.Controls.SetChildIndex(this.stbWarehouse, 0);
            this.Controls.SetChildIndex(this.lblWarehouseName, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbWithoutBarCode.ResumeLayout(false);
            this.gbWithoutBarCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientTareTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbWithoutBarCode;
        private System.Windows.Forms.GroupBox gbWithoutBarCode;
        private System.Windows.Forms.ComboBox cmbTareType;
        private System.Windows.Forms.Label lblTareType;
        private System.Windows.Forms.TextBox tbTareBarCode;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.BindingSource clientTareTypesBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.ClientTareTypesTableAdapter clientTareTypesTableAdapter;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.Label lblWarehouseName;
    }
}