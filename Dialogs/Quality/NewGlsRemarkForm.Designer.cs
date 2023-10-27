namespace WMSOffice.Dialogs.Quality
{
    partial class NewGlsRemarkForm
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
            this.lblRemarkType = new System.Windows.Forms.Label();
            this.cmbRemarkType = new System.Windows.Forms.ComboBox();
            this.bsQkGLSRemarkTypes = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.taQkGLSRemarkTypes = new WMSOffice.Data.QualityTableAdapters.QK_GLS_Remark_TypesTableAdapter();
            this.lblCritical = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.clChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsQkDocsDetailForRemark = new System.Windows.Forms.BindingSource(this.components);
            this.taQkDocsDetailForRemark = new WMSOffice.Data.QualityTableAdapters.QK_Docs_Detail_For_RemarkTableAdapter();
            this.lblGlsExpert = new System.Windows.Forms.Label();
            this.cmbGlsExpert = new System.Windows.Forms.ComboBox();
            this.bsQkGetExperts = new System.Windows.Forms.BindingSource(this.components);
            this.taQkGetExperts = new WMSOffice.Data.QualityTableAdapters.QK_Get_ExpertsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGLSRemarkTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkDocsDetailForRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGetExperts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRemarkType
            // 
            this.lblRemarkType.AutoSize = true;
            this.lblRemarkType.Location = new System.Drawing.Point(12, 9);
            this.lblRemarkType.Name = "lblRemarkType";
            this.lblRemarkType.Size = new System.Drawing.Size(87, 13);
            this.lblRemarkType.TabIndex = 0;
            this.lblRemarkType.Text = "Тип зауваження:";
            // 
            // cmbRemarkType
            // 
            this.cmbRemarkType.DataSource = this.bsQkGLSRemarkTypes;
            this.cmbRemarkType.DisplayMember = "remark_type_name";
            this.cmbRemarkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemarkType.FormattingEnabled = true;
            this.cmbRemarkType.Location = new System.Drawing.Point(105, 6);
            this.cmbRemarkType.Name = "cmbRemarkType";
            this.cmbRemarkType.Size = new System.Drawing.Size(432, 21);
            this.cmbRemarkType.TabIndex = 10;
            this.cmbRemarkType.ValueMember = "remark_type_id";
            this.cmbRemarkType.SelectedValueChanged += new System.EventHandler(this.cmbRemarkType_SelectedValueChanged);
            // 
            // bsQkGLSRemarkTypes
            // 
            this.bsQkGLSRemarkTypes.DataMember = "QK_GLS_Remark_Types";
            this.bsQkGLSRemarkTypes.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taQkGLSRemarkTypes
            // 
            this.taQkGLSRemarkTypes.ClearBeforeFill = true;
            // 
            // lblCritical
            // 
            this.lblCritical.AutoSize = true;
            this.lblCritical.Location = new System.Drawing.Point(554, 9);
            this.lblCritical.Name = "lblCritical";
            this.lblCritical.Size = new System.Drawing.Size(85, 13);
            this.lblCritical.TabIndex = 2;
            this.lblCritical.Text = "Некритичне";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 82);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Опис:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(105, 82);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(534, 104);
            this.tbxDescription.TabIndex = 20;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(12, 206);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(269, 13);
            this.lblDetails.TabIndex = 5;
            this.lblDetails.Text = "Оберіть рядки, по яким отримано зауваження:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(564, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(483, 409);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 40;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clChecked,
            this.clLineID,
            this.clItemID,
            this.clItem,
            this.clVendorLot});
            this.dgvDetails.DataSource = this.bsQkDocsDetailForRemark;
            this.dgvDetails.Location = new System.Drawing.Point(15, 222);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(624, 181);
            this.dgvDetails.TabIndex = 30;
            // 
            // clChecked
            // 
            this.clChecked.DataPropertyName = "checked";
            this.clChecked.HeaderText = "";
            this.clChecked.Name = "clChecked";
            this.clChecked.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clChecked.Width = 20;
            // 
            // clLineID
            // 
            this.clLineID.DataPropertyName = "line_id";
            this.clLineID.HeaderText = "№ рядка";
            this.clLineID.Name = "clLineID";
            this.clLineID.ReadOnly = true;
            this.clLineID.Width = 40;
            // 
            // clItemID
            // 
            this.clItemID.DataPropertyName = "item_id";
            this.clItemID.HeaderText = "Код товару";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 70;
            // 
            // clItem
            // 
            this.clItem.DataPropertyName = "item";
            this.clItem.HeaderText = "Назва товару";
            this.clItem.Name = "clItem";
            this.clItem.ReadOnly = true;
            this.clItem.Width = 250;
            // 
            // clVendorLot
            // 
            this.clVendorLot.DataPropertyName = "vendor_lot";
            this.clVendorLot.HeaderText = "Серія";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            // 
            // bsQkDocsDetailForRemark
            // 
            this.bsQkDocsDetailForRemark.DataMember = "QK_Docs_Detail_For_Remark";
            this.bsQkDocsDetailForRemark.DataSource = this.quality;
            // 
            // taQkDocsDetailForRemark
            // 
            this.taQkDocsDetailForRemark.ClearBeforeFill = true;
            // 
            // lblGlsExpert
            // 
            this.lblGlsExpert.AutoSize = true;
            this.lblGlsExpert.Location = new System.Drawing.Point(12, 46);
            this.lblGlsExpert.Name = "lblGlsExpert";
            this.lblGlsExpert.Size = new System.Drawing.Size(76, 13);
            this.lblGlsExpert.TabIndex = 51;
            this.lblGlsExpert.Text = "Експерт ДЛС:";
            // 
            // cmbGlsExpert
            // 
            this.cmbGlsExpert.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGlsExpert.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGlsExpert.DataSource = this.bsQkGetExperts;
            this.cmbGlsExpert.DisplayMember = "gls_expert";
            this.cmbGlsExpert.FormattingEnabled = true;
            this.cmbGlsExpert.Location = new System.Drawing.Point(105, 43);
            this.cmbGlsExpert.Name = "cmbGlsExpert";
            this.cmbGlsExpert.Size = new System.Drawing.Size(432, 21);
            this.cmbGlsExpert.TabIndex = 15;
            this.cmbGlsExpert.ValueMember = "gls_expert";
            // 
            // bsQkGetExperts
            // 
            this.bsQkGetExperts.DataMember = "QK_Get_Experts";
            this.bsQkGetExperts.DataSource = this.quality;
            // 
            // taQkGetExperts
            // 
            this.taQkGetExperts.ClearBeforeFill = true;
            // 
            // NewGlsRemarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(646, 444);
            this.Controls.Add(this.cmbGlsExpert);
            this.Controls.Add(this.lblGlsExpert);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCritical);
            this.Controls.Add(this.cmbRemarkType);
            this.Controls.Add(this.lblRemarkType);
            this.Name = "NewGlsRemarkForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Додати зауваження ДЛС";
            this.Load += new System.EventHandler(this.NewGlsRemarkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGLSRemarkTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkDocsDetailForRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGetExperts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemarkType;
        private System.Windows.Forms.ComboBox cmbRemarkType;
        private System.Windows.Forms.BindingSource bsQkGLSRemarkTypes;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_GLS_Remark_TypesTableAdapter taQkGLSRemarkTypes;
        private System.Windows.Forms.Label lblCritical;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource bsQkDocsDetailForRemark;
        private WMSOffice.Data.QualityTableAdapters.QK_Docs_Detail_For_RemarkTableAdapter taQkDocsDetailForRemark;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.Label lblGlsExpert;
        private System.Windows.Forms.ComboBox cmbGlsExpert;
        private System.Windows.Forms.BindingSource bsQkGetExperts;
        private WMSOffice.Data.QualityTableAdapters.QK_Get_ExpertsTableAdapter taQkGetExperts;
    }
}