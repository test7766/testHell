namespace WMSOffice.Dialogs.Docs
{
    partial class ArchiveInvoiceSetReceiptDateForm
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
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.aIDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.aI_DocsTableAdapter = new WMSOffice.Data.WHTableAdapters.AI_DocsTableAdapter();
            this.dtpReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.lblReceiptDate = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.dgvcbcSelectDoc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adressnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alphanameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datefromclientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datefromfilialDataGridViewTextBoxColumn = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.readyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summfactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(7969, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8059, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 728);
            this.pnlButtons.Size = new System.Drawing.Size(1394, 43);
            this.pnlButtons.TabIndex = 5;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcbcSelectDoc,
            this.companyDataGridViewTextBoxColumn,
            this.docDataGridViewTextBoxColumn,
            this.doctypeDataGridViewTextBoxColumn,
            this.docoDataGridViewTextBoxColumn,
            this.adressnumberDataGridViewTextBoxColumn,
            this.alphanameDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.invoicedateDataGridViewTextBoxColumn,
            this.datefromclientDataGridViewTextBoxColumn,
            this.datefromfilialDataGridViewTextBoxColumn,
            this.readyDataGridViewTextBoxColumn,
            this.summfactDataGridViewTextBoxColumn,
            this.managerDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.aIDocsBindingSource;
            this.dgvDocs.Location = new System.Drawing.Point(15, 50);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(1367, 565);
            this.dgvDocs.TabIndex = 2;
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDocs_CurrentCellDirtyStateChanged);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // aIDocsBindingSource
            // 
            this.aIDocsBindingSource.DataMember = "AI_Docs";
            this.aIDocsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aI_DocsTableAdapter
            // 
            this.aI_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // dtpReceiptDate
            // 
            this.dtpReceiptDate.CustomFormat = "dd.MM.yyyy";
            this.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiptDate.Location = new System.Drawing.Point(123, 14);
            this.dtpReceiptDate.Name = "dtpReceiptDate";
            this.dtpReceiptDate.Size = new System.Drawing.Size(100, 20);
            this.dtpReceiptDate.TabIndex = 1;
            // 
            // lblReceiptDate
            // 
            this.lblReceiptDate.AutoSize = true;
            this.lblReceiptDate.Location = new System.Drawing.Point(12, 18);
            this.lblReceiptDate.Name = "lblReceiptDate";
            this.lblReceiptDate.Size = new System.Drawing.Size(103, 13);
            this.lblReceiptDate.TabIndex = 0;
            this.lblReceiptDate.Text = "Дата поступления:";
            // 
            // tbNote
            // 
            this.tbNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNote.BackColor = System.Drawing.SystemColors.Window;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNote.Location = new System.Drawing.Point(15, 647);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ReadOnly = true;
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(1367, 75);
            this.tbNote.TabIndex = 4;
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 626);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(73, 13);
            this.lblNote.TabIndex = 3;
            this.lblNote.Text = "Примечание:";
            // 
            // dgvcbcSelectDoc
            // 
            this.dgvcbcSelectDoc.HeaderText = "Отм.";
            this.dgvcbcSelectDoc.Name = "dgvcbcSelectDoc";
            this.dgvcbcSelectDoc.Width = 37;
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "company";
            this.companyDataGridViewTextBoxColumn.HeaderText = "Компания";
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            this.companyDataGridViewTextBoxColumn.ReadOnly = true;
            this.companyDataGridViewTextBoxColumn.Width = 83;
            // 
            // docDataGridViewTextBoxColumn
            // 
            this.docDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docDataGridViewTextBoxColumn.DataPropertyName = "doc";
            this.docDataGridViewTextBoxColumn.HeaderText = "№ накладной";
            this.docDataGridViewTextBoxColumn.Name = "docDataGridViewTextBoxColumn";
            this.docDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doctypeDataGridViewTextBoxColumn
            // 
            this.doctypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.doctypeDataGridViewTextBoxColumn.DataPropertyName = "doc_type";
            this.doctypeDataGridViewTextBoxColumn.HeaderText = "Тип накладной";
            this.doctypeDataGridViewTextBoxColumn.Name = "doctypeDataGridViewTextBoxColumn";
            this.doctypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.doctypeDataGridViewTextBoxColumn.Width = 99;
            // 
            // docoDataGridViewTextBoxColumn
            // 
            this.docoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docoDataGridViewTextBoxColumn.DataPropertyName = "doco";
            this.docoDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.docoDataGridViewTextBoxColumn.Name = "docoDataGridViewTextBoxColumn";
            this.docoDataGridViewTextBoxColumn.ReadOnly = true;
            this.docoDataGridViewTextBoxColumn.Width = 76;
            // 
            // adressnumberDataGridViewTextBoxColumn
            // 
            this.adressnumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.adressnumberDataGridViewTextBoxColumn.DataPropertyName = "adress_number";
            this.adressnumberDataGridViewTextBoxColumn.HeaderText = "Код";
            this.adressnumberDataGridViewTextBoxColumn.Name = "adressnumberDataGridViewTextBoxColumn";
            this.adressnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.adressnumberDataGridViewTextBoxColumn.Width = 51;
            // 
            // alphanameDataGridViewTextBoxColumn
            // 
            this.alphanameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.alphanameDataGridViewTextBoxColumn.DataPropertyName = "alpha_name";
            this.alphanameDataGridViewTextBoxColumn.HeaderText = "Наименование дебитора";
            this.alphanameDataGridViewTextBoxColumn.Name = "alphanameDataGridViewTextBoxColumn";
            this.alphanameDataGridViewTextBoxColumn.ReadOnly = true;
            this.alphanameDataGridViewTextBoxColumn.Width = 144;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "city";
            this.cityDataGridViewTextBoxColumn.HeaderText = "Город";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityDataGridViewTextBoxColumn.Width = 62;
            // 
            // invoicedateDataGridViewTextBoxColumn
            // 
            this.invoicedateDataGridViewTextBoxColumn.DataPropertyName = "invoice_date";
            this.invoicedateDataGridViewTextBoxColumn.HeaderText = "Дата накладной";
            this.invoicedateDataGridViewTextBoxColumn.Name = "invoicedateDataGridViewTextBoxColumn";
            this.invoicedateDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoicedateDataGridViewTextBoxColumn.Width = 90;
            // 
            // datefromclientDataGridViewTextBoxColumn
            // 
            this.datefromclientDataGridViewTextBoxColumn.DataPropertyName = "date_from_client";
            this.datefromclientDataGridViewTextBoxColumn.HeaderText = "Дата приемки клиентом";
            this.datefromclientDataGridViewTextBoxColumn.Name = "datefromclientDataGridViewTextBoxColumn";
            this.datefromclientDataGridViewTextBoxColumn.ReadOnly = true;
            this.datefromclientDataGridViewTextBoxColumn.Width = 90;
            // 
            // datefromfilialDataGridViewTextBoxColumn
            // 
            this.datefromfilialDataGridViewTextBoxColumn.DataPropertyName = "date_from_filial";
            this.datefromfilialDataGridViewTextBoxColumn.HeaderText = "Дата поступления из филиала";
            this.datefromfilialDataGridViewTextBoxColumn.Name = "datefromfilialDataGridViewTextBoxColumn";
            this.datefromfilialDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.datefromfilialDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.datefromfilialDataGridViewTextBoxColumn.Width = 90;
            // 
            // readyDataGridViewTextBoxColumn
            // 
            this.readyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.readyDataGridViewTextBoxColumn.DataPropertyName = "ready";
            this.readyDataGridViewTextBoxColumn.HeaderText = "Готов к разноске";
            this.readyDataGridViewTextBoxColumn.Name = "readyDataGridViewTextBoxColumn";
            this.readyDataGridViewTextBoxColumn.ReadOnly = true;
            this.readyDataGridViewTextBoxColumn.Width = 111;
            // 
            // summfactDataGridViewTextBoxColumn
            // 
            this.summfactDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.summfactDataGridViewTextBoxColumn.DataPropertyName = "summ_fact";
            this.summfactDataGridViewTextBoxColumn.HeaderText = "Сумма по накладной";
            this.summfactDataGridViewTextBoxColumn.Name = "summfactDataGridViewTextBoxColumn";
            this.summfactDataGridViewTextBoxColumn.ReadOnly = true;
            this.summfactDataGridViewTextBoxColumn.Width = 126;
            // 
            // managerDataGridViewTextBoxColumn
            // 
            this.managerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.managerDataGridViewTextBoxColumn.DataPropertyName = "manager";
            this.managerDataGridViewTextBoxColumn.HeaderText = "Менеджер";
            this.managerDataGridViewTextBoxColumn.Name = "managerDataGridViewTextBoxColumn";
            this.managerDataGridViewTextBoxColumn.ReadOnly = true;
            this.managerDataGridViewTextBoxColumn.Width = 85;
            // 
            // ArchiveInvoiceSetReceiptDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 771);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.dtpReceiptDate);
            this.Controls.Add(this.lblReceiptDate);
            this.Controls.Add(this.dgvDocs);
            this.Name = "ArchiveInvoiceSetReceiptDateForm";
            this.Text = "Укажите дату поступления из филиала";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiveInvoiceSetReceiptDateForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvDocs, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblReceiptDate, 0);
            this.Controls.SetChildIndex(this.dtpReceiptDate, 0);
            this.Controls.SetChildIndex(this.lblNote, 0);
            this.Controls.SetChildIndex(this.tbNote, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.BindingSource aIDocsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.AI_DocsTableAdapter aI_DocsTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpReceiptDate;
        private System.Windows.Forms.Label lblReceiptDate;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcbcSelectDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alphanameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicedateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datefromclientDataGridViewTextBoxColumn;
        private Controls.Custom.DataGridViewDatePickerColumn datefromfilialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn readyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summfactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerDataGridViewTextBoxColumn;
    }
}