namespace WMSOffice.Dialogs.Complaints
{
    partial class ImportComplaintForm
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
            this.lblComplaintType = new System.Windows.Forms.Label();
            this.cmbComplaintType = new System.Windows.Forms.ComboBox();
            this.availableDocsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.dgvImportedData = new System.Windows.Forms.DataGridView();
            this.invoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickSlipNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiPasteFromClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.cOProcessedImportedDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.availableDocsTypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter();
            this.cO_Processed_Imported_DocsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_Processed_Imported_DocsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedData)).BeginInit();
            this.cmsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cOProcessedImportedDocsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(717, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(807, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 428);
            this.pnlButtons.Size = new System.Drawing.Size(894, 43);
            this.pnlButtons.TabIndex = 3;
            // 
            // lblComplaintType
            // 
            this.lblComplaintType.AutoSize = true;
            this.lblComplaintType.Location = new System.Drawing.Point(12, 12);
            this.lblComplaintType.Name = "lblComplaintType";
            this.lblComplaintType.Size = new System.Drawing.Size(85, 13);
            this.lblComplaintType.TabIndex = 0;
            this.lblComplaintType.Text = "Тип претензии:";
            // 
            // cmbComplaintType
            // 
            this.cmbComplaintType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbComplaintType.DataSource = this.availableDocsTypesBindingSource;
            this.cmbComplaintType.DisplayMember = "Doc_Type_Name";
            this.cmbComplaintType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplaintType.FormattingEnabled = true;
            this.cmbComplaintType.Location = new System.Drawing.Point(103, 8);
            this.cmbComplaintType.Name = "cmbComplaintType";
            this.cmbComplaintType.Size = new System.Drawing.Size(779, 21);
            this.cmbComplaintType.TabIndex = 1;
            this.cmbComplaintType.ValueMember = "Doc_Type";
            // 
            // availableDocsTypesBindingSource
            // 
            this.availableDocsTypesBindingSource.DataMember = "AvailableDocsTypes";
            this.availableDocsTypesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvImportedData
            // 
            this.dgvImportedData.AllowUserToAddRows = false;
            this.dgvImportedData.AllowUserToDeleteRows = false;
            this.dgvImportedData.AllowUserToResizeRows = false;
            this.dgvImportedData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImportedData.AutoGenerateColumns = false;
            this.dgvImportedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportedData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceNumberDataGridViewTextBoxColumn,
            this.pickSlipNumberDataGridViewTextBoxColumn,
            this.deliveryIDDataGridViewTextBoxColumn,
            this.debtorNameDataGridViewTextBoxColumn,
            this.errorsDataGridViewTextBoxColumn,
            this.docIDDataGridViewTextBoxColumn});
            this.dgvImportedData.ContextMenuStrip = this.cmsMain;
            this.dgvImportedData.DataSource = this.cOProcessedImportedDocsBindingSource;
            this.dgvImportedData.Location = new System.Drawing.Point(15, 35);
            this.dgvImportedData.MultiSelect = false;
            this.dgvImportedData.Name = "dgvImportedData";
            this.dgvImportedData.ReadOnly = true;
            this.dgvImportedData.RowHeadersVisible = false;
            this.dgvImportedData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImportedData.Size = new System.Drawing.Size(867, 387);
            this.dgvImportedData.TabIndex = 2;
            this.dgvImportedData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvImportedData_CellFormatting);
            // 
            // invoiceNumberDataGridViewTextBoxColumn
            // 
            this.invoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber";
            this.invoiceNumberDataGridViewTextBoxColumn.HeaderText = "Номер накладной";
            this.invoiceNumberDataGridViewTextBoxColumn.Name = "invoiceNumberDataGridViewTextBoxColumn";
            this.invoiceNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceNumberDataGridViewTextBoxColumn.Width = 70;
            // 
            // pickSlipNumberDataGridViewTextBoxColumn
            // 
            this.pickSlipNumberDataGridViewTextBoxColumn.DataPropertyName = "PickSlipNumber";
            this.pickSlipNumberDataGridViewTextBoxColumn.HeaderText = "Номер сборочного";
            this.pickSlipNumberDataGridViewTextBoxColumn.Name = "pickSlipNumberDataGridViewTextBoxColumn";
            this.pickSlipNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickSlipNumberDataGridViewTextBoxColumn.Width = 70;
            // 
            // deliveryIDDataGridViewTextBoxColumn
            // 
            this.deliveryIDDataGridViewTextBoxColumn.DataPropertyName = "DeliveryID";
            this.deliveryIDDataGridViewTextBoxColumn.HeaderText = "Код доставки";
            this.deliveryIDDataGridViewTextBoxColumn.Name = "deliveryIDDataGridViewTextBoxColumn";
            this.deliveryIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // debtorNameDataGridViewTextBoxColumn
            // 
            this.debtorNameDataGridViewTextBoxColumn.DataPropertyName = "DebtorName";
            this.debtorNameDataGridViewTextBoxColumn.HeaderText = "Наименование\nклиента";
            this.debtorNameDataGridViewTextBoxColumn.Name = "debtorNameDataGridViewTextBoxColumn";
            this.debtorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.debtorNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // errorsDataGridViewTextBoxColumn
            // 
            this.errorsDataGridViewTextBoxColumn.DataPropertyName = "Errors";
            this.errorsDataGridViewTextBoxColumn.HeaderText = "Результат\nимпорта";
            this.errorsDataGridViewTextBoxColumn.Name = "errorsDataGridViewTextBoxColumn";
            this.errorsDataGridViewTextBoxColumn.ReadOnly = true;
            this.errorsDataGridViewTextBoxColumn.Width = 270;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "DocID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Код претензии";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 70;
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiPasteFromClipboard});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(268, 26);
            // 
            // cmsiPasteFromClipboard
            // 
            this.cmsiPasteFromClipboard.Image = global::WMSOffice.Properties.Resources.accept_16;
            this.cmsiPasteFromClipboard.Name = "cmsiPasteFromClipboard";
            this.cmsiPasteFromClipboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.cmsiPasteFromClipboard.Size = new System.Drawing.Size(267, 22);
            this.cmsiPasteFromClipboard.Text = "Вставить из буфера обмена";
            this.cmsiPasteFromClipboard.Click += new System.EventHandler(this.cmsiPasteFromClipboard_Click);
            // 
            // cOProcessedImportedDocsBindingSource
            // 
            this.cOProcessedImportedDocsBindingSource.DataMember = "CO_Processed_Imported_Docs";
            this.cOProcessedImportedDocsBindingSource.DataSource = this.complaints;
            // 
            // availableDocsTypesTableAdapter
            // 
            this.availableDocsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // cO_Processed_Imported_DocsTableAdapter
            // 
            this.cO_Processed_Imported_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // ImportComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 471);
            this.Controls.Add(this.lblComplaintType);
            this.Controls.Add(this.dgvImportedData);
            this.Controls.Add(this.cmbComplaintType);
            this.Name = "ImportComplaintForm";
            this.Text = "Импорт претензии по шаблону";
            this.Controls.SetChildIndex(this.cmbComplaintType, 0);
            this.Controls.SetChildIndex(this.dgvImportedData, 0);
            this.Controls.SetChildIndex(this.lblComplaintType, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedData)).EndInit();
            this.cmsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cOProcessedImportedDocsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComplaintType;
        private System.Windows.Forms.ComboBox cmbComplaintType;
        private System.Windows.Forms.DataGridView dgvImportedData;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem cmsiPasteFromClipboard;
        private System.Windows.Forms.BindingSource availableDocsTypesBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter availableDocsTypesTableAdapter;
        private System.Windows.Forms.BindingSource cOProcessedImportedDocsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Processed_Imported_DocsTableAdapter cO_Processed_Imported_DocsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickSlipNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
    }
}