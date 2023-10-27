namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintsExternalDocsShowForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prevStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOGetExternalDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.cO_Get_External_DocsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_Get_External_DocsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOGetExternalDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1461, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1551, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 528);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvDocs);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(994, 522);
            this.pnlContent.TabIndex = 101;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToResizeColumns = false;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docTypeNameDataGridViewTextBoxColumn,
            this.docIDDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.currStatusDataGridViewTextBoxColumn,
            this.prevStatusDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.cOGetExternalDocsBindingSource;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(994, 522);
            this.dgvDocs.TabIndex = 0;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "DocTypeName";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Документ";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeNameDataGridViewTextBoxColumn.Width = 83;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "DocID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "№ документа";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "DocType";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип документа";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeDataGridViewTextBoxColumn.Width = 108;
            // 
            // currStatusDataGridViewTextBoxColumn
            // 
            this.currStatusDataGridViewTextBoxColumn.DataPropertyName = "CurrStatus";
            this.currStatusDataGridViewTextBoxColumn.HeaderText = "Текущий статус";
            this.currStatusDataGridViewTextBoxColumn.Name = "currStatusDataGridViewTextBoxColumn";
            this.currStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.currStatusDataGridViewTextBoxColumn.Width = 113;
            // 
            // prevStatusDataGridViewTextBoxColumn
            // 
            this.prevStatusDataGridViewTextBoxColumn.DataPropertyName = "PrevStatus";
            this.prevStatusDataGridViewTextBoxColumn.HeaderText = "Предыдущий статус";
            this.prevStatusDataGridViewTextBoxColumn.Name = "prevStatusDataGridViewTextBoxColumn";
            this.prevStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.prevStatusDataGridViewTextBoxColumn.Width = 134;
            // 
            // cOGetExternalDocsBindingSource
            // 
            this.cOGetExternalDocsBindingSource.DataMember = "CO_Get_External_Docs";
            this.cOGetExternalDocsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cO_Get_External_DocsTableAdapter
            // 
            this.cO_Get_External_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // ComplaintsExternalDocsShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 571);
            this.Controls.Add(this.pnlContent);
            this.Name = "ComplaintsExternalDocsShowForm";
            this.Text = "Документы по претензии";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOGetExternalDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.BindingSource cOGetExternalDocsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Get_External_DocsTableAdapter cO_Get_External_DocsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prevStatusDataGridViewTextBoxColumn;
    }
}