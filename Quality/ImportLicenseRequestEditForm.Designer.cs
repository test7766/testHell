namespace WMSOffice.Dialogs.Quality
{
    partial class ImportLicenseRequestEditForm
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
            this.lblReasons = new System.Windows.Forms.Label();
            this.lblProdTypes = new System.Windows.Forms.Label();
            this.lblAddedItems = new System.Windows.Forms.Label();
            this.lblRemovedItems = new System.Windows.Forms.Label();
            this.lblResponsiblePerson = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.qKLIRequestReceiveAdditionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.qKLIRequestReceiveDecisionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbProdTypes = new System.Windows.Forms.ComboBox();
            this.qKLIRequestProdTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbReasons = new System.Windows.Forms.ComboBox();
            this.qKLIRequestReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbAddedItems = new System.Windows.Forms.TextBox();
            this.btnShowAddedItemsSelector = new System.Windows.Forms.Button();
            this.btnShowRemovedItemsSelector = new System.Windows.Forms.Button();
            this.tbRemovedItems = new System.Windows.Forms.TextBox();
            this.btnShowResponsiblePersonsSelector = new System.Windows.Forms.Button();
            this.tbResponsiblePerson = new System.Windows.Forms.TextBox();
            this.btnShowVendorsSelector = new System.Windows.Forms.Button();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.qK_LI_Request_ReasonsTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_LI_Request_ReasonsTableAdapter();
            this.qK_LI_Request_ProdTypesTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_LI_Request_ProdTypesTableAdapter();
            this.qK_LI_Request_ReceiveAdditionsTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_LI_Request_ReceiveAdditionsTableAdapter();
            this.qK_LI_Request_ReceiveDecisionsTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_LI_Request_ReceiveDecisionsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qKLIRequestReceiveAdditionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLIRequestReceiveDecisionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLIRequestProdTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLIRequestReasonsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2045, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2135, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 258);
            this.pnlButtons.Size = new System.Drawing.Size(494, 43);
            this.pnlButtons.TabIndex = 20;
            // 
            // lblReasons
            // 
            this.lblReasons.AutoSize = true;
            this.lblReasons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblReasons.ForeColor = System.Drawing.Color.Brown;
            this.lblReasons.Location = new System.Drawing.Point(12, 25);
            this.lblReasons.Name = "lblReasons";
            this.lblReasons.Size = new System.Drawing.Size(53, 13);
            this.lblReasons.TabIndex = 0;
            this.lblReasons.Text = "Причина:";
            // 
            // lblProdTypes
            // 
            this.lblProdTypes.AutoSize = true;
            this.lblProdTypes.Location = new System.Drawing.Point(12, 62);
            this.lblProdTypes.Name = "lblProdTypes";
            this.lblProdTypes.Size = new System.Drawing.Size(85, 13);
            this.lblProdTypes.TabIndex = 2;
            this.lblProdTypes.Text = "Тип продукции:";
            // 
            // lblAddedItems
            // 
            this.lblAddedItems.AutoSize = true;
            this.lblAddedItems.Location = new System.Drawing.Point(12, 99);
            this.lblAddedItems.Name = "lblAddedItems";
            this.lblAddedItems.Size = new System.Drawing.Size(118, 13);
            this.lblAddedItems.TabIndex = 8;
            this.lblAddedItems.Text = "Товары (обновление):";
            // 
            // lblRemovedItems
            // 
            this.lblRemovedItems.AutoSize = true;
            this.lblRemovedItems.Location = new System.Drawing.Point(12, 136);
            this.lblRemovedItems.Name = "lblRemovedItems";
            this.lblRemovedItems.Size = new System.Drawing.Size(100, 13);
            this.lblRemovedItems.TabIndex = 11;
            this.lblRemovedItems.Text = "Товары (изъятие):";
            // 
            // lblResponsiblePerson
            // 
            this.lblResponsiblePerson.AutoSize = true;
            this.lblResponsiblePerson.Location = new System.Drawing.Point(12, 173);
            this.lblResponsiblePerson.Name = "lblResponsiblePerson";
            this.lblResponsiblePerson.Size = new System.Drawing.Size(124, 13);
            this.lblResponsiblePerson.TabIndex = 14;
            this.lblResponsiblePerson.Text = "Уполномоченное лицо:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(12, 210);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 17;
            this.lblVendor.Text = "Поставщик:";
            // 
            // qKLIRequestReceiveAdditionsBindingSource
            // 
            this.qKLIRequestReceiveAdditionsBindingSource.DataMember = "QK_LI_Request_ReceiveAdditions";
            this.qKLIRequestReceiveAdditionsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qKLIRequestReceiveDecisionsBindingSource
            // 
            this.qKLIRequestReceiveDecisionsBindingSource.DataMember = "QK_LI_Request_ReceiveDecisions";
            this.qKLIRequestReceiveDecisionsBindingSource.DataSource = this.quality;
            // 
            // cmbProdTypes
            // 
            this.cmbProdTypes.DataSource = this.qKLIRequestProdTypesBindingSource;
            this.cmbProdTypes.DisplayMember = "ProdTypeName";
            this.cmbProdTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdTypes.FormattingEnabled = true;
            this.cmbProdTypes.Location = new System.Drawing.Point(155, 58);
            this.cmbProdTypes.Name = "cmbProdTypes";
            this.cmbProdTypes.Size = new System.Drawing.Size(327, 21);
            this.cmbProdTypes.TabIndex = 3;
            this.cmbProdTypes.ValueMember = "ProdTypeID";
            // 
            // qKLIRequestProdTypesBindingSource
            // 
            this.qKLIRequestProdTypesBindingSource.DataMember = "QK_LI_Request_ProdTypes";
            this.qKLIRequestProdTypesBindingSource.DataSource = this.quality;
            // 
            // cmbReasons
            // 
            this.cmbReasons.DataSource = this.qKLIRequestReasonsBindingSource;
            this.cmbReasons.DisplayMember = "ReasonName";
            this.cmbReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasons.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbReasons.FormattingEnabled = true;
            this.cmbReasons.Location = new System.Drawing.Point(155, 21);
            this.cmbReasons.Name = "cmbReasons";
            this.cmbReasons.Size = new System.Drawing.Size(327, 21);
            this.cmbReasons.TabIndex = 1;
            this.cmbReasons.ValueMember = "ReasonID";
            this.cmbReasons.SelectedValueChanged += new System.EventHandler(this.cmbReasons_SelectedValueChanged);
            // 
            // qKLIRequestReasonsBindingSource
            // 
            this.qKLIRequestReasonsBindingSource.DataMember = "QK_LI_Request_Reasons";
            this.qKLIRequestReasonsBindingSource.DataSource = this.quality;
            // 
            // tbAddedItems
            // 
            this.tbAddedItems.BackColor = System.Drawing.SystemColors.Window;
            this.tbAddedItems.Location = new System.Drawing.Point(155, 95);
            this.tbAddedItems.Name = "tbAddedItems";
            this.tbAddedItems.ReadOnly = true;
            this.tbAddedItems.Size = new System.Drawing.Size(304, 20);
            this.tbAddedItems.TabIndex = 9;
            // 
            // btnShowAddedItemsSelector
            // 
            this.btnShowAddedItemsSelector.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnShowAddedItemsSelector.Location = new System.Drawing.Point(459, 94);
            this.btnShowAddedItemsSelector.Name = "btnShowAddedItemsSelector";
            this.btnShowAddedItemsSelector.Size = new System.Drawing.Size(23, 23);
            this.btnShowAddedItemsSelector.TabIndex = 10;
            this.btnShowAddedItemsSelector.TabStop = false;
            this.btnShowAddedItemsSelector.UseVisualStyleBackColor = true;
            this.btnShowAddedItemsSelector.Click += new System.EventHandler(this.btnShowAddedItemsSelector_Click);
            // 
            // btnShowRemovedItemsSelector
            // 
            this.btnShowRemovedItemsSelector.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnShowRemovedItemsSelector.Location = new System.Drawing.Point(459, 131);
            this.btnShowRemovedItemsSelector.Name = "btnShowRemovedItemsSelector";
            this.btnShowRemovedItemsSelector.Size = new System.Drawing.Size(23, 23);
            this.btnShowRemovedItemsSelector.TabIndex = 13;
            this.btnShowRemovedItemsSelector.TabStop = false;
            this.btnShowRemovedItemsSelector.UseVisualStyleBackColor = true;
            this.btnShowRemovedItemsSelector.Click += new System.EventHandler(this.btnShowRemovedItemsSelector_Click);
            // 
            // tbRemovedItems
            // 
            this.tbRemovedItems.BackColor = System.Drawing.SystemColors.Window;
            this.tbRemovedItems.Location = new System.Drawing.Point(155, 132);
            this.tbRemovedItems.Name = "tbRemovedItems";
            this.tbRemovedItems.ReadOnly = true;
            this.tbRemovedItems.Size = new System.Drawing.Size(304, 20);
            this.tbRemovedItems.TabIndex = 12;
            // 
            // btnShowResponsiblePersonsSelector
            // 
            this.btnShowResponsiblePersonsSelector.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnShowResponsiblePersonsSelector.Location = new System.Drawing.Point(459, 168);
            this.btnShowResponsiblePersonsSelector.Name = "btnShowResponsiblePersonsSelector";
            this.btnShowResponsiblePersonsSelector.Size = new System.Drawing.Size(23, 23);
            this.btnShowResponsiblePersonsSelector.TabIndex = 16;
            this.btnShowResponsiblePersonsSelector.TabStop = false;
            this.btnShowResponsiblePersonsSelector.UseVisualStyleBackColor = true;
            this.btnShowResponsiblePersonsSelector.Click += new System.EventHandler(this.btnShowResponsiblePersonsSelector_Click);
            // 
            // tbResponsiblePerson
            // 
            this.tbResponsiblePerson.BackColor = System.Drawing.SystemColors.Window;
            this.tbResponsiblePerson.Location = new System.Drawing.Point(155, 169);
            this.tbResponsiblePerson.Name = "tbResponsiblePerson";
            this.tbResponsiblePerson.ReadOnly = true;
            this.tbResponsiblePerson.Size = new System.Drawing.Size(304, 20);
            this.tbResponsiblePerson.TabIndex = 15;
            // 
            // btnShowVendorsSelector
            // 
            this.btnShowVendorsSelector.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnShowVendorsSelector.Location = new System.Drawing.Point(459, 205);
            this.btnShowVendorsSelector.Name = "btnShowVendorsSelector";
            this.btnShowVendorsSelector.Size = new System.Drawing.Size(23, 23);
            this.btnShowVendorsSelector.TabIndex = 19;
            this.btnShowVendorsSelector.TabStop = false;
            this.btnShowVendorsSelector.UseVisualStyleBackColor = true;
            this.btnShowVendorsSelector.Click += new System.EventHandler(this.btnShowVendorsSelector_Click);
            // 
            // tbVendor
            // 
            this.tbVendor.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendor.Location = new System.Drawing.Point(155, 206);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.ReadOnly = true;
            this.tbVendor.Size = new System.Drawing.Size(304, 20);
            this.tbVendor.TabIndex = 18;
            // 
            // qK_LI_Request_ReasonsTableAdapter
            // 
            this.qK_LI_Request_ReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // qK_LI_Request_ProdTypesTableAdapter
            // 
            this.qK_LI_Request_ProdTypesTableAdapter.ClearBeforeFill = true;
            // 
            // qK_LI_Request_ReceiveAdditionsTableAdapter
            // 
            this.qK_LI_Request_ReceiveAdditionsTableAdapter.ClearBeforeFill = true;
            // 
            // qK_LI_Request_ReceiveDecisionsTableAdapter
            // 
            this.qK_LI_Request_ReceiveDecisionsTableAdapter.ClearBeforeFill = true;
            // 
            // ImportLicenseRequestEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 301);
            this.Controls.Add(this.btnShowVendorsSelector);
            this.Controls.Add(this.tbVendor);
            this.Controls.Add(this.btnShowResponsiblePersonsSelector);
            this.Controls.Add(this.tbResponsiblePerson);
            this.Controls.Add(this.btnShowRemovedItemsSelector);
            this.Controls.Add(this.tbRemovedItems);
            this.Controls.Add(this.btnShowAddedItemsSelector);
            this.Controls.Add(this.tbAddedItems);
            this.Controls.Add(this.cmbReasons);
            this.Controls.Add(this.cmbProdTypes);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.lblResponsiblePerson);
            this.Controls.Add(this.lblRemovedItems);
            this.Controls.Add(this.lblAddedItems);
            this.Controls.Add(this.lblProdTypes);
            this.Controls.Add(this.lblReasons);
            this.Name = "ImportLicenseRequestEditForm";
            this.Text = "Создание уведомления на обновление лицензии на импорт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportLicenseRequestEditForm_FormClosing);
            this.Controls.SetChildIndex(this.lblReasons, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblProdTypes, 0);
            this.Controls.SetChildIndex(this.lblAddedItems, 0);
            this.Controls.SetChildIndex(this.lblRemovedItems, 0);
            this.Controls.SetChildIndex(this.lblResponsiblePerson, 0);
            this.Controls.SetChildIndex(this.lblVendor, 0);
            this.Controls.SetChildIndex(this.cmbProdTypes, 0);
            this.Controls.SetChildIndex(this.cmbReasons, 0);
            this.Controls.SetChildIndex(this.tbAddedItems, 0);
            this.Controls.SetChildIndex(this.btnShowAddedItemsSelector, 0);
            this.Controls.SetChildIndex(this.tbRemovedItems, 0);
            this.Controls.SetChildIndex(this.btnShowRemovedItemsSelector, 0);
            this.Controls.SetChildIndex(this.tbResponsiblePerson, 0);
            this.Controls.SetChildIndex(this.btnShowResponsiblePersonsSelector, 0);
            this.Controls.SetChildIndex(this.tbVendor, 0);
            this.Controls.SetChildIndex(this.btnShowVendorsSelector, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qKLIRequestReceiveAdditionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLIRequestReceiveDecisionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLIRequestProdTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLIRequestReasonsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReasons;
        private System.Windows.Forms.Label lblProdTypes;
        private System.Windows.Forms.Label lblAddedItems;
        private System.Windows.Forms.Label lblRemovedItems;
        private System.Windows.Forms.Label lblResponsiblePerson;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.ComboBox cmbProdTypes;
        private System.Windows.Forms.ComboBox cmbReasons;
        private System.Windows.Forms.TextBox tbAddedItems;
        private System.Windows.Forms.Button btnShowAddedItemsSelector;
        private System.Windows.Forms.Button btnShowRemovedItemsSelector;
        private System.Windows.Forms.TextBox tbRemovedItems;
        private System.Windows.Forms.Button btnShowResponsiblePersonsSelector;
        private System.Windows.Forms.TextBox tbResponsiblePerson;
        private System.Windows.Forms.Button btnShowVendorsSelector;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.BindingSource qKLIRequestReasonsBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_LI_Request_ReasonsTableAdapter qK_LI_Request_ReasonsTableAdapter;
        private System.Windows.Forms.BindingSource qKLIRequestProdTypesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.QK_LI_Request_ProdTypesTableAdapter qK_LI_Request_ProdTypesTableAdapter;
        private System.Windows.Forms.BindingSource qKLIRequestReceiveAdditionsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.QK_LI_Request_ReceiveAdditionsTableAdapter qK_LI_Request_ReceiveAdditionsTableAdapter;
        private System.Windows.Forms.BindingSource qKLIRequestReceiveDecisionsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.QK_LI_Request_ReceiveDecisionsTableAdapter qK_LI_Request_ReceiveDecisionsTableAdapter;
    }
}