namespace WMSOffice.Dialogs.Complaints
{
    partial class DocsFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.cbWarehouses = new System.Windows.Forms.ComboBox();
            this.availableWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.chkbWarehouse = new System.Windows.Forms.CheckBox();
            this.chkbOnlyRequiringVisa = new System.Windows.Forms.CheckBox();
            this.cbStatusesTo = new System.Windows.Forms.ComboBox();
            this.availableStatusesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbDocTypes = new System.Windows.Forms.ComboBox();
            this.availableDocsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbStatusesFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkbStatuses = new System.Windows.Forms.CheckBox();
            this.chkbDocType = new System.Windows.Forms.CheckBox();
            this.availableDocsTypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter();
            this.availableStatusesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableStatusesTableAdapter();
            this.availableWarehousesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableWarehousesTableAdapter();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableWarehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableStatusesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.cbWarehouses);
            this.gbFilter.Controls.Add(this.chkbWarehouse);
            this.gbFilter.Controls.Add(this.chkbOnlyRequiringVisa);
            this.gbFilter.Controls.Add(this.cbStatusesTo);
            this.gbFilter.Controls.Add(this.cbDocTypes);
            this.gbFilter.Controls.Add(this.cbStatusesFrom);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.chkbStatuses);
            this.gbFilter.Controls.Add(this.chkbDocType);
            this.gbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFilter.Location = new System.Drawing.Point(0, 0);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1100, 44);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Фильтр претензий";
            // 
            // cbWarehouses
            // 
            this.cbWarehouses.DataSource = this.availableWarehousesBindingSource;
            this.cbWarehouses.DisplayMember = "Name";
            this.cbWarehouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWarehouses.DropDownWidth = 200;
            this.cbWarehouses.Enabled = false;
            this.cbWarehouses.FormattingEnabled = true;
            this.cbWarehouses.Location = new System.Drawing.Point(878, 15);
            this.cbWarehouses.MaxDropDownItems = 20;
            this.cbWarehouses.Name = "cbWarehouses";
            this.cbWarehouses.Size = new System.Drawing.Size(189, 21);
            this.cbWarehouses.TabIndex = 8;
            this.cbWarehouses.ValueMember = "Code";
            this.cbWarehouses.SelectedIndexChanged += new System.EventHandler(this.FilterValueChanged);
            // 
            // availableWarehousesBindingSource
            // 
            this.availableWarehousesBindingSource.DataMember = "AvailableWarehouses";
            this.availableWarehousesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chkbWarehouse
            // 
            this.chkbWarehouse.AutoSize = true;
            this.chkbWarehouse.Checked = true;
            this.chkbWarehouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbWarehouse.Location = new System.Drawing.Point(808, 17);
            this.chkbWarehouse.Name = "chkbWarehouse";
            this.chkbWarehouse.Size = new System.Drawing.Size(70, 17);
            this.chkbWarehouse.TabIndex = 7;
            this.chkbWarehouse.Text = "Филиал:";
            this.chkbWarehouse.UseVisualStyleBackColor = true;
            this.chkbWarehouse.CheckedChanged += new System.EventHandler(this.FilterValueChanged);
            // 
            // chkbOnlyRequiringVisa
            // 
            this.chkbOnlyRequiringVisa.Location = new System.Drawing.Point(690, 10);
            this.chkbOnlyRequiringVisa.Name = "chkbOnlyRequiringVisa";
            this.chkbOnlyRequiringVisa.Size = new System.Drawing.Size(106, 30);
            this.chkbOnlyRequiringVisa.TabIndex = 6;
            this.chkbOnlyRequiringVisa.Text = "Только требу- ющие визу";
            this.chkbOnlyRequiringVisa.UseVisualStyleBackColor = true;
            this.chkbOnlyRequiringVisa.CheckedChanged += new System.EventHandler(this.FilterValueChanged);
            // 
            // cbStatusesTo
            // 
            this.cbStatusesTo.DataSource = this.availableStatusesBindingSource;
            this.cbStatusesTo.DisplayMember = "Status_Name";
            this.cbStatusesTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusesTo.DropDownWidth = 200;
            this.cbStatusesTo.Enabled = false;
            this.cbStatusesTo.FormattingEnabled = true;
            this.cbStatusesTo.Location = new System.Drawing.Point(489, 15);
            this.cbStatusesTo.MaxDropDownItems = 24;
            this.cbStatusesTo.Name = "cbStatusesTo";
            this.cbStatusesTo.Size = new System.Drawing.Size(190, 21);
            this.cbStatusesTo.TabIndex = 5;
            this.cbStatusesTo.ValueMember = "Status_ID";
            this.cbStatusesTo.SelectedIndexChanged += new System.EventHandler(this.FilterValueChanged);
            // 
            // availableStatusesBindingSource
            // 
            this.availableStatusesBindingSource.DataMember = "AvailableStatuses";
            this.availableStatusesBindingSource.DataSource = this.complaints;
            // 
            // cbDocTypes
            // 
            this.cbDocTypes.DataSource = this.availableDocsTypesBindingSource;
            this.cbDocTypes.DisplayMember = "Doc_Type_Name";
            this.cbDocTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocTypes.DropDownWidth = 200;
            this.cbDocTypes.Enabled = false;
            this.cbDocTypes.FormattingEnabled = true;
            this.cbDocTypes.Location = new System.Drawing.Point(51, 15);
            this.cbDocTypes.MaxDropDownItems = 20;
            this.cbDocTypes.Name = "cbDocTypes";
            this.cbDocTypes.Size = new System.Drawing.Size(135, 21);
            this.cbDocTypes.TabIndex = 1;
            this.cbDocTypes.ValueMember = "Doc_Type";
            this.cbDocTypes.SelectedIndexChanged += new System.EventHandler(this.FilterValueChanged);
            // 
            // availableDocsTypesBindingSource
            // 
            this.availableDocsTypesBindingSource.DataMember = "AvailableDocsTypes";
            this.availableDocsTypesBindingSource.DataSource = this.complaints;
            // 
            // cbStatusesFrom
            // 
            this.cbStatusesFrom.DataSource = this.availableStatusesBindingSource;
            this.cbStatusesFrom.DisplayMember = "Status_Name";
            this.cbStatusesFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusesFrom.DropDownWidth = 200;
            this.cbStatusesFrom.Enabled = false;
            this.cbStatusesFrom.FormattingEnabled = true;
            this.cbStatusesFrom.Location = new System.Drawing.Point(274, 15);
            this.cbStatusesFrom.MaxDropDownItems = 24;
            this.cbStatusesFrom.Name = "cbStatusesFrom";
            this.cbStatusesFrom.Size = new System.Drawing.Size(190, 21);
            this.cbStatusesFrom.TabIndex = 3;
            this.cbStatusesFrom.ValueMember = "Status_ID";
            this.cbStatusesFrom.SelectedIndexChanged += new System.EventHandler(this.FilterValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "по:";
            // 
            // chkbStatuses
            // 
            this.chkbStatuses.AutoSize = true;
            this.chkbStatuses.Location = new System.Drawing.Point(195, 17);
            this.chkbStatuses.Name = "chkbStatuses";
            this.chkbStatuses.Size = new System.Drawing.Size(83, 17);
            this.chkbStatuses.TabIndex = 2;
            this.chkbStatuses.Text = "Статусы:  с";
            this.chkbStatuses.UseVisualStyleBackColor = true;
            this.chkbStatuses.CheckedChanged += new System.EventHandler(this.FilterValueChanged);
            // 
            // chkbDocType
            // 
            this.chkbDocType.AutoSize = true;
            this.chkbDocType.Location = new System.Drawing.Point(7, 17);
            this.chkbDocType.Name = "chkbDocType";
            this.chkbDocType.Size = new System.Drawing.Size(48, 17);
            this.chkbDocType.TabIndex = 0;
            this.chkbDocType.Text = "Тип:";
            this.chkbDocType.UseVisualStyleBackColor = true;
            this.chkbDocType.CheckedChanged += new System.EventHandler(this.FilterValueChanged);
            // 
            // availableDocsTypesTableAdapter
            // 
            this.availableDocsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // availableStatusesTableAdapter
            // 
            this.availableStatusesTableAdapter.ClearBeforeFill = true;
            // 
            // availableWarehousesTableAdapter
            // 
            this.availableWarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // DocsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Name = "DocsFilter";
            this.Size = new System.Drawing.Size(1100, 44);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableWarehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableStatusesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.ComboBox cbStatusesTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatusesFrom;
        private System.Windows.Forms.CheckBox chkbStatuses;
        private System.Windows.Forms.CheckBox chkbDocType;
        private System.Windows.Forms.ComboBox cbDocTypes;
        private System.Windows.Forms.BindingSource availableStatusesBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource availableDocsTypesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter availableDocsTypesTableAdapter;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableStatusesTableAdapter availableStatusesTableAdapter;
        private System.Windows.Forms.CheckBox chkbOnlyRequiringVisa;
        private System.Windows.Forms.ComboBox cbWarehouses;
        private System.Windows.Forms.BindingSource availableWarehousesBindingSource;
        private System.Windows.Forms.CheckBox chkbWarehouse;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableWarehousesTableAdapter availableWarehousesTableAdapter;
    }
}
