namespace WMSOffice.Dialogs.WH
{
    partial class ActDiscountEditForm
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
            this.lblDebitor = new System.Windows.Forms.Label();
            this.cmbDebitors = new System.Windows.Forms.ComboBox();
            this.bsAsGetDebtorList = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.lblFilial = new System.Windows.Forms.Label();
            this.tbxFilial = new System.Windows.Forms.TextBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.tbxSum = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.taAsGetDebtorList = new WMSOffice.Data.WHTableAdapters.AS_Get_DebtorListTableAdapter();
            this.lblDocType = new System.Windows.Forms.Label();
            this.cmbDocTypes = new System.Windows.Forms.ComboBox();
            this.bsAsDocTypes = new System.Windows.Forms.BindingSource(this.components);
            this.taAsDocTypes = new WMSOffice.Data.WHTableAdapters.AS_Doc_TypesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bsAsGetDebtorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAsDocTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDebitor
            // 
            this.lblDebitor.AutoSize = true;
            this.lblDebitor.Location = new System.Drawing.Point(12, 18);
            this.lblDebitor.Name = "lblDebitor";
            this.lblDebitor.Size = new System.Drawing.Size(54, 13);
            this.lblDebitor.TabIndex = 0;
            this.lblDebitor.Text = "Дебитор:";
            // 
            // cmbDebitors
            // 
            this.cmbDebitors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDebitors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDebitors.DataSource = this.bsAsGetDebtorList;
            this.cmbDebitors.DisplayMember = "Debtor";
            this.cmbDebitors.FormattingEnabled = true;
            this.cmbDebitors.Location = new System.Drawing.Point(72, 15);
            this.cmbDebitors.Name = "cmbDebitors";
            this.cmbDebitors.Size = new System.Drawing.Size(348, 21);
            this.cmbDebitors.TabIndex = 100;
            this.cmbDebitors.ValueMember = "Debtor_ID";
            this.cmbDebitors.SelectedIndexChanged += new System.EventHandler(this.cmbDebitors_SelectedIndexChanged);
            // 
            // bsAsGetDebtorList
            // 
            this.bsAsGetDebtorList.DataMember = "AS_Get_DebtorList";
            this.bsAsGetDebtorList.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblFilial
            // 
            this.lblFilial.AutoSize = true;
            this.lblFilial.Location = new System.Drawing.Point(12, 55);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(24, 13);
            this.lblFilial.TabIndex = 2;
            this.lblFilial.Text = "БЕ:";
            // 
            // tbxFilial
            // 
            this.tbxFilial.Enabled = false;
            this.tbxFilial.Location = new System.Drawing.Point(72, 52);
            this.tbxFilial.Name = "tbxFilial";
            this.tbxFilial.Size = new System.Drawing.Size(348, 20);
            this.tbxFilial.TabIndex = 200;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(12, 216);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(44, 13);
            this.lblSum.TabIndex = 4;
            this.lblSum.Text = "Сумма:";
            // 
            // tbxSum
            // 
            this.tbxSum.Location = new System.Drawing.Point(72, 213);
            this.tbxSum.Name = "tbxSum";
            this.tbxSum.Size = new System.Drawing.Size(133, 20);
            this.tbxSum.TabIndex = 400;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(236, 216);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblDateFrom.TabIndex = 6;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(287, 213);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(133, 20);
            this.dtpDateFrom.TabIndex = 500;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 700;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(255, 264);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 600;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 132);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Описание:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.AcceptsReturn = true;
            this.tbxDescription.Location = new System.Drawing.Point(72, 129);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(348, 66);
            this.tbxDescription.TabIndex = 300;
            // 
            // taAsGetDebtorList
            // 
            this.taAsGetDebtorList.ClearBeforeFill = true;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(12, 89);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(55, 13);
            this.lblDocType.TabIndex = 701;
            this.lblDocType.Text = "Тип акта:";
            // 
            // cmbDocTypes
            // 
            this.cmbDocTypes.DataSource = this.bsAsDocTypes;
            this.cmbDocTypes.DisplayMember = "Description";
            this.cmbDocTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocTypes.FormattingEnabled = true;
            this.cmbDocTypes.Location = new System.Drawing.Point(73, 86);
            this.cmbDocTypes.Name = "cmbDocTypes";
            this.cmbDocTypes.Size = new System.Drawing.Size(347, 21);
            this.cmbDocTypes.TabIndex = 250;
            this.cmbDocTypes.ValueMember = "Doc_Type";
            // 
            // bsAsDocTypes
            // 
            this.bsAsDocTypes.DataMember = "AS_Doc_Types";
            this.bsAsDocTypes.DataSource = this.wH;
            // 
            // taAsDocTypes
            // 
            this.taAsDocTypes.ClearBeforeFill = true;
            // 
            // ActDiscountEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(437, 298);
            this.Controls.Add(this.cmbDocTypes);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.tbxSum);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.tbxFilial);
            this.Controls.Add(this.lblFilial);
            this.Controls.Add(this.cmbDebitors);
            this.Controls.Add(this.lblDebitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ActDiscountEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление акта скидки";
            this.Load += new System.EventHandler(this.ActDiscountEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAsGetDebtorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAsDocTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDebitor;
        private System.Windows.Forms.ComboBox cmbDebitors;
        private System.Windows.Forms.Label lblFilial;
        private System.Windows.Forms.TextBox tbxFilial;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.TextBox tbxSum;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxDescription;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource bsAsGetDebtorList;
        private WMSOffice.Data.WHTableAdapters.AS_Get_DebtorListTableAdapter taAsGetDebtorList;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.ComboBox cmbDocTypes;
        private System.Windows.Forms.BindingSource bsAsDocTypes;
        private WMSOffice.Data.WHTableAdapters.AS_Doc_TypesTableAdapter taAsDocTypes;
    }
}