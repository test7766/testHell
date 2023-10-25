namespace WMSOffice.Dialogs.Quality
{
    partial class ImportLicenseItemDocsForm
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
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docPageCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qKLILicItemDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefreshData = new System.Windows.Forms.ToolStripButton();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.qK_LI_LicItem_DocsTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_LI_LicItem_DocsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLILicItemDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1205, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1295, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 328);
            this.pnlButtons.Size = new System.Drawing.Size(694, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvDocs);
            this.pnlContent.Controls.Add(this.tsMain);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(694, 322);
            this.pnlContent.TabIndex = 101;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.docNumDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.dataIDDataGridViewTextBoxColumn,
            this.docPageCountDataGridViewTextBoxColumn,
            this.docSourceDataGridViewTextBoxColumn,
            this.docDescDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.qKLILicItemDocsBindingSource;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 39);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(694, 283);
            this.dgvDocs.TabIndex = 1;
            this.dgvDocs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDocs_MouseDoubleClick);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "DocID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "№ п/п";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 63;
            // 
            // docNumDataGridViewTextBoxColumn
            // 
            this.docNumDataGridViewTextBoxColumn.DataPropertyName = "DocNum";
            this.docNumDataGridViewTextBoxColumn.HeaderText = "Номер док.";
            this.docNumDataGridViewTextBoxColumn.Name = "docNumDataGridViewTextBoxColumn";
            this.docNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.docNumDataGridViewTextBoxColumn.Width = 90;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "DocDate";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата док.";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Width = 82;
            // 
            // dataIDDataGridViewTextBoxColumn
            // 
            this.dataIDDataGridViewTextBoxColumn.DataPropertyName = "DataID";
            this.dataIDDataGridViewTextBoxColumn.HeaderText = "DataID";
            this.dataIDDataGridViewTextBoxColumn.Name = "dataIDDataGridViewTextBoxColumn";
            this.dataIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataIDDataGridViewTextBoxColumn.Visible = false;
            this.dataIDDataGridViewTextBoxColumn.Width = 66;
            // 
            // docPageCountDataGridViewTextBoxColumn
            // 
            this.docPageCountDataGridViewTextBoxColumn.DataPropertyName = "DocPageCount";
            this.docPageCountDataGridViewTextBoxColumn.HeaderText = "DocPageCount";
            this.docPageCountDataGridViewTextBoxColumn.Name = "docPageCountDataGridViewTextBoxColumn";
            this.docPageCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.docPageCountDataGridViewTextBoxColumn.Visible = false;
            this.docPageCountDataGridViewTextBoxColumn.Width = 105;
            // 
            // docSourceDataGridViewTextBoxColumn
            // 
            this.docSourceDataGridViewTextBoxColumn.DataPropertyName = "DocSource";
            this.docSourceDataGridViewTextBoxColumn.HeaderText = "DocSource";
            this.docSourceDataGridViewTextBoxColumn.Name = "docSourceDataGridViewTextBoxColumn";
            this.docSourceDataGridViewTextBoxColumn.ReadOnly = true;
            this.docSourceDataGridViewTextBoxColumn.Visible = false;
            this.docSourceDataGridViewTextBoxColumn.Width = 86;
            // 
            // docDescDataGridViewTextBoxColumn
            // 
            this.docDescDataGridViewTextBoxColumn.DataPropertyName = "DocDesc";
            this.docDescDataGridViewTextBoxColumn.HeaderText = "Тип док.";
            this.docDescDataGridViewTextBoxColumn.Name = "docDescDataGridViewTextBoxColumn";
            this.docDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDescDataGridViewTextBoxColumn.Width = 75;
            // 
            // qKLILicItemDocsBindingSource
            // 
            this.qKLILicItemDocsBindingSource.DataMember = "QK_LI_LicItem_Docs";
            this.qKLILicItemDocsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshData,
            this.btnPreview});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(694, 39);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(97, 36);
            this.btnRefreshData.Text = "Обновить";
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::WMSOffice.Properties.Resources.preview;
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 36);
            this.btnPreview.Text = "Просмотр";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // qK_LI_LicItem_DocsTableAdapter
            // 
            this.qK_LI_LicItem_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // ImportLicenseItemDocsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 371);
            this.Controls.Add(this.pnlContent);
            this.Name = "ImportLicenseItemDocsForm";
            this.Text = "Регистрационные документы на товар";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKLILicItemDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docPageCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource qKLILicItemDocsBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_LI_LicItem_DocsTableAdapter qK_LI_LicItem_DocsTableAdapter;
        private System.Windows.Forms.ToolStripButton btnRefreshData;
    }
}