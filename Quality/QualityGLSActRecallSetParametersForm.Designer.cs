namespace WMSOffice.Dialogs.Quality
{
    partial class QualityGLSActRecallSetParametersForm
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
            this.cmbReturnTypes = new System.Windows.Forms.ComboBox();
            this.gAReturnTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.cmbProductConditions = new System.Windows.Forms.ComboBox();
            this.gAProductConditionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbCompensationTypes = new System.Windows.Forms.ComboBox();
            this.gACompensationTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gA_ReturnTypesTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_ReturnTypesTableAdapter();
            this.lblReturnTypes = new System.Windows.Forms.Label();
            this.lblProductConditions = new System.Windows.Forms.Label();
            this.gA_ProductConditionsTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_ProductConditionsTableAdapter();
            this.lblCompensationTypes = new System.Windows.Forms.Label();
            this.gA_CompensationTypesTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_CompensationTypesTableAdapter();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblClientLetterSend = new System.Windows.Forms.Label();
            this.dtpClientLetterSend = new System.Windows.Forms.DateTimePicker();
            this.lblCoDateFrom = new System.Windows.Forms.Label();
            this.dtpCoDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblCoDateTo = new System.Windows.Forms.Label();
            this.dtpCoDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblCoClientClose = new System.Windows.Forms.Label();
            this.dtpCoClientClose = new System.Windows.Forms.DateTimePicker();
            this.lblCoWhReturn = new System.Windows.Forms.Label();
            this.dtpCoWhReturn = new System.Windows.Forms.DateTimePicker();
            this.lblDopClientLetterSend = new System.Windows.Forms.Label();
            this.dtpDopClientLetterSend = new System.Windows.Forms.DateTimePicker();
            this.lblCoPCReClose = new System.Windows.Forms.Label();
            this.dtpCoPCReClose = new System.Windows.Forms.DateTimePicker();
            this.lblCoOmuClose = new System.Windows.Forms.Label();
            this.dtpCoOmuClose = new System.Windows.Forms.DateTimePicker();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAReturnTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAProductConditionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gACompensationTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(684, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(774, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 398);
            this.pnlButtons.Size = new System.Drawing.Size(414, 43);
            this.pnlButtons.TabIndex = 24;
            // 
            // cmbReturnTypes
            // 
            this.cmbReturnTypes.DataSource = this.gAReturnTypesBindingSource;
            this.cmbReturnTypes.DisplayMember = "ReturnTypeName";
            this.cmbReturnTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReturnTypes.FormattingEnabled = true;
            this.cmbReturnTypes.Location = new System.Drawing.Point(173, 8);
            this.cmbReturnTypes.Name = "cmbReturnTypes";
            this.cmbReturnTypes.Size = new System.Drawing.Size(228, 21);
            this.cmbReturnTypes.TabIndex = 1;
            this.cmbReturnTypes.ValueMember = "ReturnTypeID";
            this.cmbReturnTypes.SelectedValueChanged += new System.EventHandler(this.cmbReturnTypes_SelectedValueChanged);
            // 
            // gAReturnTypesBindingSource
            // 
            this.gAReturnTypesBindingSource.DataMember = "GA_ReturnTypes";
            this.gAReturnTypesBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbProductConditions
            // 
            this.cmbProductConditions.DataSource = this.gAProductConditionsBindingSource;
            this.cmbProductConditions.DisplayMember = "ProductConditionName";
            this.cmbProductConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductConditions.FormattingEnabled = true;
            this.cmbProductConditions.Location = new System.Drawing.Point(173, 37);
            this.cmbProductConditions.Name = "cmbProductConditions";
            this.cmbProductConditions.Size = new System.Drawing.Size(228, 21);
            this.cmbProductConditions.TabIndex = 3;
            this.cmbProductConditions.ValueMember = "ProductConditionID";
            // 
            // gAProductConditionsBindingSource
            // 
            this.gAProductConditionsBindingSource.DataMember = "GA_ProductConditions";
            this.gAProductConditionsBindingSource.DataSource = this.quality;
            // 
            // cmbCompensationTypes
            // 
            this.cmbCompensationTypes.DataSource = this.gACompensationTypesBindingSource;
            this.cmbCompensationTypes.DisplayMember = "CompensationTypeName";
            this.cmbCompensationTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompensationTypes.FormattingEnabled = true;
            this.cmbCompensationTypes.Location = new System.Drawing.Point(173, 66);
            this.cmbCompensationTypes.Name = "cmbCompensationTypes";
            this.cmbCompensationTypes.Size = new System.Drawing.Size(228, 21);
            this.cmbCompensationTypes.TabIndex = 5;
            this.cmbCompensationTypes.ValueMember = "CompensationTypeID";
            // 
            // gACompensationTypesBindingSource
            // 
            this.gACompensationTypesBindingSource.DataMember = "GA_CompensationTypes";
            this.gACompensationTypesBindingSource.DataSource = this.quality;
            // 
            // gA_ReturnTypesTableAdapter
            // 
            this.gA_ReturnTypesTableAdapter.ClearBeforeFill = true;
            // 
            // lblReturnTypes
            // 
            this.lblReturnTypes.AutoSize = true;
            this.lblReturnTypes.Location = new System.Drawing.Point(12, 12);
            this.lblReturnTypes.Name = "lblReturnTypes";
            this.lblReturnTypes.Size = new System.Drawing.Size(107, 13);
            this.lblReturnTypes.TabIndex = 0;
            this.lblReturnTypes.Text = "Повернення товара";
            // 
            // lblProductConditions
            // 
            this.lblProductConditions.AutoSize = true;
            this.lblProductConditions.Location = new System.Drawing.Point(12, 41);
            this.lblProductConditions.Name = "lblProductConditions";
            this.lblProductConditions.Size = new System.Drawing.Size(94, 13);
            this.lblProductConditions.TabIndex = 2;
            this.lblProductConditions.Text = "Товарний вигляд";
            // 
            // gA_ProductConditionsTableAdapter
            // 
            this.gA_ProductConditionsTableAdapter.ClearBeforeFill = true;
            // 
            // lblCompensationTypes
            // 
            this.lblCompensationTypes.AutoSize = true;
            this.lblCompensationTypes.Location = new System.Drawing.Point(12, 70);
            this.lblCompensationTypes.Name = "lblCompensationTypes";
            this.lblCompensationTypes.Size = new System.Drawing.Size(119, 13);
            this.lblCompensationTypes.TabIndex = 4;
            this.lblCompensationTypes.Text = "Тип роботи з товаром";
            // 
            // gA_CompensationTypesTableAdapter
            // 
            this.gA_CompensationTypesTableAdapter.ClearBeforeFill = true;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CustomFormat = "dd.MM.yyyy";
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(280, 103);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(121, 20);
            this.dtpReturnDate.TabIndex = 7;
            this.dtpReturnDate.ValueChanged += new System.EventHandler(this.dtpReturnDate_ValueChanged);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(14, 107);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(159, 13);
            this.lblReturnDate.TabIndex = 6;
            this.lblReturnDate.Text = "Дата проведення повернення";
            // 
            // lblClientLetterSend
            // 
            this.lblClientLetterSend.AutoSize = true;
            this.lblClientLetterSend.Location = new System.Drawing.Point(14, 136);
            this.lblClientLetterSend.Name = "lblClientLetterSend";
            this.lblClientLetterSend.Size = new System.Drawing.Size(199, 13);
            this.lblClientLetterSend.TabIndex = 8;
            this.lblClientLetterSend.Text = "Дата відправки повідомлення Клієнту";
            // 
            // dtpClientLetterSend
            // 
            this.dtpClientLetterSend.CustomFormat = "dd.MM.yyyy";
            this.dtpClientLetterSend.Enabled = false;
            this.dtpClientLetterSend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpClientLetterSend.Location = new System.Drawing.Point(280, 132);
            this.dtpClientLetterSend.Name = "dtpClientLetterSend";
            this.dtpClientLetterSend.Size = new System.Drawing.Size(121, 20);
            this.dtpClientLetterSend.TabIndex = 9;
            // 
            // lblCoDateFrom
            // 
            this.lblCoDateFrom.AutoSize = true;
            this.lblCoDateFrom.Location = new System.Drawing.Point(14, 173);
            this.lblCoDateFrom.Name = "lblCoDateFrom";
            this.lblCoDateFrom.Size = new System.Drawing.Size(183, 13);
            this.lblCoDateFrom.TabIndex = 10;
            this.lblCoDateFrom.Text = "Дата початку створення претензій";
            // 
            // dtpCoDateFrom
            // 
            this.dtpCoDateFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpCoDateFrom.Enabled = false;
            this.dtpCoDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCoDateFrom.Location = new System.Drawing.Point(280, 169);
            this.dtpCoDateFrom.Name = "dtpCoDateFrom";
            this.dtpCoDateFrom.Size = new System.Drawing.Size(121, 20);
            this.dtpCoDateFrom.TabIndex = 11;
            // 
            // lblCoDateTo
            // 
            this.lblCoDateTo.AutoSize = true;
            this.lblCoDateTo.Location = new System.Drawing.Point(14, 202);
            this.lblCoDateTo.Name = "lblCoDateTo";
            this.lblCoDateTo.Size = new System.Drawing.Size(257, 13);
            this.lblCoDateTo.TabIndex = 12;
            this.lblCoDateTo.Text = "Дата закінчення створення претензій від Клієнта";
            // 
            // dtpCoDateTo
            // 
            this.dtpCoDateTo.CustomFormat = "dd.MM.yyyy";
            this.dtpCoDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCoDateTo.Location = new System.Drawing.Point(280, 198);
            this.dtpCoDateTo.Name = "dtpCoDateTo";
            this.dtpCoDateTo.Size = new System.Drawing.Size(121, 20);
            this.dtpCoDateTo.TabIndex = 13;
            // 
            // lblCoClientClose
            // 
            this.lblCoClientClose.AutoSize = true;
            this.lblCoClientClose.Location = new System.Drawing.Point(14, 239);
            this.lblCoClientClose.Name = "lblCoClientClose";
            this.lblCoClientClose.Size = new System.Drawing.Size(201, 13);
            this.lblCoClientClose.TabIndex = 14;
            this.lblCoClientClose.Text = "Термін закриття претензій від Клієнта";
            // 
            // dtpCoClientClose
            // 
            this.dtpCoClientClose.CustomFormat = "dd.MM.yyyy";
            this.dtpCoClientClose.Enabled = false;
            this.dtpCoClientClose.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCoClientClose.Location = new System.Drawing.Point(280, 235);
            this.dtpCoClientClose.Name = "dtpCoClientClose";
            this.dtpCoClientClose.Size = new System.Drawing.Size(121, 20);
            this.dtpCoClientClose.TabIndex = 15;
            // 
            // lblCoWhReturn
            // 
            this.lblCoWhReturn.AutoSize = true;
            this.lblCoWhReturn.Location = new System.Drawing.Point(14, 268);
            this.lblCoWhReturn.Name = "lblCoWhReturn";
            this.lblCoWhReturn.Size = new System.Drawing.Size(138, 13);
            this.lblCoWhReturn.TabIndex = 16;
            this.lblCoWhReturn.Text = "Термін повернення на ЦС";
            // 
            // dtpCoWhReturn
            // 
            this.dtpCoWhReturn.CustomFormat = "dd.MM.yyyy";
            this.dtpCoWhReturn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCoWhReturn.Location = new System.Drawing.Point(280, 264);
            this.dtpCoWhReturn.Name = "dtpCoWhReturn";
            this.dtpCoWhReturn.Size = new System.Drawing.Size(121, 20);
            this.dtpCoWhReturn.TabIndex = 17;
            // 
            // lblDopClientLetterSend
            // 
            this.lblDopClientLetterSend.AutoSize = true;
            this.lblDopClientLetterSend.Location = new System.Drawing.Point(15, 305);
            this.lblDopClientLetterSend.Name = "lblDopClientLetterSend";
            this.lblDopClientLetterSend.Size = new System.Drawing.Size(197, 13);
            this.lblDopClientLetterSend.TabIndex = 18;
            this.lblDopClientLetterSend.Text = "Дод. відправка повідомлення Клієнту";
            // 
            // dtpDopClientLetterSend
            // 
            this.dtpDopClientLetterSend.CustomFormat = "dd.MM.yyyy";
            this.dtpDopClientLetterSend.Enabled = false;
            this.dtpDopClientLetterSend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDopClientLetterSend.Location = new System.Drawing.Point(281, 301);
            this.dtpDopClientLetterSend.Name = "dtpDopClientLetterSend";
            this.dtpDopClientLetterSend.Size = new System.Drawing.Size(121, 20);
            this.dtpDopClientLetterSend.TabIndex = 19;
            // 
            // lblCoPCReClose
            // 
            this.lblCoPCReClose.AutoSize = true;
            this.lblCoPCReClose.Location = new System.Drawing.Point(14, 342);
            this.lblCoPCReClose.Name = "lblCoPCReClose";
            this.lblCoPCReClose.Size = new System.Drawing.Size(129, 13);
            this.lblCoPCReClose.TabIndex = 20;
            this.lblCoPCReClose.Text = "Термін закриття 230 ст.";
            // 
            // dtpCoPCReClose
            // 
            this.dtpCoPCReClose.CustomFormat = "dd.MM.yyyy";
            this.dtpCoPCReClose.Enabled = false;
            this.dtpCoPCReClose.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCoPCReClose.Location = new System.Drawing.Point(280, 338);
            this.dtpCoPCReClose.Name = "dtpCoPCReClose";
            this.dtpCoPCReClose.Size = new System.Drawing.Size(121, 20);
            this.dtpCoPCReClose.TabIndex = 21;
            // 
            // lblCoOmuClose
            // 
            this.lblCoOmuClose.AutoSize = true;
            this.lblCoOmuClose.Location = new System.Drawing.Point(14, 371);
            this.lblCoOmuClose.Name = "lblCoOmuClose";
            this.lblCoOmuClose.Size = new System.Drawing.Size(117, 13);
            this.lblCoOmuClose.TabIndex = 22;
            this.lblCoOmuClose.Text = "Статуси 257-260 ОМУ";
            // 
            // dtpCoOmuClose
            // 
            this.dtpCoOmuClose.CustomFormat = "dd.MM.yyyy";
            this.dtpCoOmuClose.Enabled = false;
            this.dtpCoOmuClose.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCoOmuClose.Location = new System.Drawing.Point(280, 367);
            this.dtpCoOmuClose.Name = "dtpCoOmuClose";
            this.dtpCoOmuClose.Size = new System.Drawing.Size(121, 20);
            this.dtpCoOmuClose.TabIndex = 23;
            // 
            // QualityGLSActRecallSetParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 441);
            this.Controls.Add(this.lblCoOmuClose);
            this.Controls.Add(this.dtpCoOmuClose);
            this.Controls.Add(this.lblCoPCReClose);
            this.Controls.Add(this.dtpCoPCReClose);
            this.Controls.Add(this.lblDopClientLetterSend);
            this.Controls.Add(this.dtpDopClientLetterSend);
            this.Controls.Add(this.lblCoWhReturn);
            this.Controls.Add(this.dtpCoWhReturn);
            this.Controls.Add(this.lblCoClientClose);
            this.Controls.Add(this.dtpCoClientClose);
            this.Controls.Add(this.lblCoDateTo);
            this.Controls.Add(this.dtpCoDateTo);
            this.Controls.Add(this.lblCoDateFrom);
            this.Controls.Add(this.dtpCoDateFrom);
            this.Controls.Add(this.lblClientLetterSend);
            this.Controls.Add(this.dtpClientLetterSend);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.lblCompensationTypes);
            this.Controls.Add(this.lblProductConditions);
            this.Controls.Add(this.lblReturnTypes);
            this.Controls.Add(this.cmbCompensationTypes);
            this.Controls.Add(this.cmbProductConditions);
            this.Controls.Add(this.cmbReturnTypes);
            this.Name = "QualityGLSActRecallSetParametersForm";
            this.Text = "Параметри повідомлення за відкликанням";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityGLSActRecallSetParametersForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbReturnTypes, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cmbProductConditions, 0);
            this.Controls.SetChildIndex(this.cmbCompensationTypes, 0);
            this.Controls.SetChildIndex(this.lblReturnTypes, 0);
            this.Controls.SetChildIndex(this.lblProductConditions, 0);
            this.Controls.SetChildIndex(this.lblCompensationTypes, 0);
            this.Controls.SetChildIndex(this.dtpReturnDate, 0);
            this.Controls.SetChildIndex(this.lblReturnDate, 0);
            this.Controls.SetChildIndex(this.dtpClientLetterSend, 0);
            this.Controls.SetChildIndex(this.lblClientLetterSend, 0);
            this.Controls.SetChildIndex(this.dtpCoDateFrom, 0);
            this.Controls.SetChildIndex(this.lblCoDateFrom, 0);
            this.Controls.SetChildIndex(this.dtpCoDateTo, 0);
            this.Controls.SetChildIndex(this.lblCoDateTo, 0);
            this.Controls.SetChildIndex(this.dtpCoClientClose, 0);
            this.Controls.SetChildIndex(this.lblCoClientClose, 0);
            this.Controls.SetChildIndex(this.dtpCoWhReturn, 0);
            this.Controls.SetChildIndex(this.lblCoWhReturn, 0);
            this.Controls.SetChildIndex(this.dtpDopClientLetterSend, 0);
            this.Controls.SetChildIndex(this.lblDopClientLetterSend, 0);
            this.Controls.SetChildIndex(this.dtpCoPCReClose, 0);
            this.Controls.SetChildIndex(this.lblCoPCReClose, 0);
            this.Controls.SetChildIndex(this.dtpCoOmuClose, 0);
            this.Controls.SetChildIndex(this.lblCoOmuClose, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gAReturnTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAProductConditionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gACompensationTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReturnTypes;
        private System.Windows.Forms.ComboBox cmbProductConditions;
        private System.Windows.Forms.ComboBox cmbCompensationTypes;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource gAReturnTypesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.GA_ReturnTypesTableAdapter gA_ReturnTypesTableAdapter;
        private System.Windows.Forms.Label lblReturnTypes;
        private System.Windows.Forms.Label lblProductConditions;
        private System.Windows.Forms.BindingSource gAProductConditionsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.GA_ProductConditionsTableAdapter gA_ProductConditionsTableAdapter;
        private System.Windows.Forms.Label lblCompensationTypes;
        private System.Windows.Forms.BindingSource gACompensationTypesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.GA_CompensationTypesTableAdapter gA_CompensationTypesTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Label lblClientLetterSend;
        private System.Windows.Forms.DateTimePicker dtpClientLetterSend;
        private System.Windows.Forms.Label lblCoDateFrom;
        private System.Windows.Forms.DateTimePicker dtpCoDateFrom;
        private System.Windows.Forms.Label lblCoDateTo;
        private System.Windows.Forms.DateTimePicker dtpCoDateTo;
        private System.Windows.Forms.Label lblCoClientClose;
        private System.Windows.Forms.DateTimePicker dtpCoClientClose;
        private System.Windows.Forms.Label lblCoWhReturn;
        private System.Windows.Forms.DateTimePicker dtpCoWhReturn;
        private System.Windows.Forms.Label lblDopClientLetterSend;
        private System.Windows.Forms.DateTimePicker dtpDopClientLetterSend;
        private System.Windows.Forms.Label lblCoPCReClose;
        private System.Windows.Forms.DateTimePicker dtpCoPCReClose;
        private System.Windows.Forms.Label lblCoOmuClose;
        private System.Windows.Forms.DateTimePicker dtpCoOmuClose;
    }
}