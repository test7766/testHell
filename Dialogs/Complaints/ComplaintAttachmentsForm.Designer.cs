namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintAttachmentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintAttachmentsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sbSaveAll = new System.Windows.Forms.ToolStripSplitButton();
            this.miSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.miClearSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditAttachmentRequisites = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.dgvcIsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.attachmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessionIDCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File_Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Document_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Document_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Document_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_Vendor_Payer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.docAttachmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.docAttachmentsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAttachmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(956, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1046, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 368);
            this.pnlButtons.Size = new System.Drawing.Size(1126, 43);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator3,
            this.btnView,
            this.toolStripSeparator4,
            this.btnSaveAs,
            this.toolStripSeparator5,
            this.sbSaveAll,
            this.toolStripSeparator1,
            this.btnEditAttachmentRequisites,
            this.toolStripSeparator2,
            this.btnDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1126, 25);
            this.toolStrip.TabIndex = 101;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 22);
            this.btnAdd.Text = "Додати";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnView
            // 
            this.btnView.Enabled = false;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(93, 22);
            this.btnView.Text = "Переглянути";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(112, 22);
            this.btnSaveAs.Text = "Зберегти у файл";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // sbSaveAll
            // 
            this.sbSaveAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSaveAll,
            this.toolStripSeparator6,
            this.miClearSettings});
            this.sbSaveAll.Enabled = false;
            this.sbSaveAll.Image = global::WMSOffice.Properties.Resources.save;
            this.sbSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbSaveAll.Name = "sbSaveAll";
            this.sbSaveAll.Size = new System.Drawing.Size(106, 22);
            this.sbSaveAll.Text = "Зберегти все";
            this.sbSaveAll.ButtonClick += new System.EventHandler(this.sbSaveAll_ButtonClick);
            // 
            // miSaveAll
            // 
            this.miSaveAll.Image = global::WMSOffice.Properties.Resources.open_folder_icon;
            this.miSaveAll.Name = "miSaveAll";
            this.miSaveAll.Size = new System.Drawing.Size(194, 22);
            this.miSaveAll.Text = "Обрати каталог";
            this.miSaveAll.Click += new System.EventHandler(this.miSaveAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(191, 6);
            // 
            // miClearSettings
            // 
            this.miClearSettings.Image = global::WMSOffice.Properties.Resources.clear;
            this.miClearSettings.Name = "miClearSettings";
            this.miClearSettings.Size = new System.Drawing.Size(194, 22);
            this.miClearSettings.Text = "Скинути налаштування";
            this.miClearSettings.Click += new System.EventHandler(this.miClearSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditAttachmentRequisites
            // 
            this.btnEditAttachmentRequisites.Enabled = false;
            this.btnEditAttachmentRequisites.Image = global::WMSOffice.Properties.Resources.Edit_10x10;
            this.btnEditAttachmentRequisites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAttachmentRequisites.Name = "btnEditAttachmentRequisites";
            this.btnEditAttachmentRequisites.Size = new System.Drawing.Size(117, 22);
            this.btnEditAttachmentRequisites.Text = "Змінити реквізити";
            this.btnEditAttachmentRequisites.Click += new System.EventHandler(this.btnEditAttachmentRequisites_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 22);
            this.btnDelete.Text = "Видалити";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToOrderColumns = true;
            this.dgvFiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFiles.AutoGenerateColumns = false;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcIsChecked,
            this.attachmentIDDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.sessionIDCreatedDataGridViewTextBoxColumn,
            this.File_Length,
            this.usersCreatedDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.Document_Number,
            this.Document_Date,
            this.Document_Amount,
            this.IS_Vendor_Payer});
            this.dgvFiles.DataSource = this.docAttachmentsBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiles.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.Location = new System.Drawing.Point(0, 25);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowTemplate.Height = 21;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.ShowEditingIcon = false;
            this.dgvFiles.Size = new System.Drawing.Size(1126, 343);
            this.dgvFiles.TabIndex = 102;
            this.dgvFiles.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFiles_CellFormatting);
            this.dgvFiles.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFiles_CellMouseDoubleClick);
            this.dgvFiles.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvFiles_CurrentCellDirtyStateChanged);
            this.dgvFiles.SelectionChanged += new System.EventHandler(this.dgvFiles_SelectionChanged);
            // 
            // dgvcIsChecked
            // 
            this.dgvcIsChecked.DataPropertyName = "IsChecked";
            this.dgvcIsChecked.HeaderText = "Відм.";
            this.dgvcIsChecked.Name = "dgvcIsChecked";
            this.dgvcIsChecked.Width = 37;
            // 
            // attachmentIDDataGridViewTextBoxColumn
            // 
            this.attachmentIDDataGridViewTextBoxColumn.DataPropertyName = "Attachment_ID";
            this.attachmentIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.attachmentIDDataGridViewTextBoxColumn.Name = "attachmentIDDataGridViewTextBoxColumn";
            this.attachmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.attachmentIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "File_Name";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "Им\'я файла";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Опис (тип)";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // sessionIDCreatedDataGridViewTextBoxColumn
            // 
            this.sessionIDCreatedDataGridViewTextBoxColumn.DataPropertyName = "Session_ID_Created";
            this.sessionIDCreatedDataGridViewTextBoxColumn.HeaderText = "Session_ID_Created";
            this.sessionIDCreatedDataGridViewTextBoxColumn.Name = "sessionIDCreatedDataGridViewTextBoxColumn";
            this.sessionIDCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.sessionIDCreatedDataGridViewTextBoxColumn.Visible = false;
            // 
            // File_Length
            // 
            this.File_Length.DataPropertyName = "File_Length";
            this.File_Length.HeaderText = "Розмір";
            this.File_Length.Name = "File_Length";
            this.File_Length.ReadOnly = true;
            this.File_Length.Width = 70;
            // 
            // usersCreatedDataGridViewTextBoxColumn
            // 
            this.usersCreatedDataGridViewTextBoxColumn.DataPropertyName = "Users_Created";
            this.usersCreatedDataGridViewTextBoxColumn.HeaderText = "Ким доданий";
            this.usersCreatedDataGridViewTextBoxColumn.Name = "usersCreatedDataGridViewTextBoxColumn";
            this.usersCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.usersCreatedDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Created";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Дата додавання";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreatedDataGridViewTextBoxColumn.Width = 160;
            // 
            // Document_Number
            // 
            this.Document_Number.DataPropertyName = "Document_Number";
            this.Document_Number.HeaderText = "№ док-та";
            this.Document_Number.Name = "Document_Number";
            this.Document_Number.ReadOnly = true;
            // 
            // Document_Date
            // 
            this.Document_Date.DataPropertyName = "Document_Date";
            this.Document_Date.HeaderText = "Дата док-та";
            this.Document_Date.Name = "Document_Date";
            this.Document_Date.ReadOnly = true;
            // 
            // Document_Amount
            // 
            this.Document_Amount.DataPropertyName = "Document_Amount";
            this.Document_Amount.HeaderText = "Сума док-та з ПДВ, грн.";
            this.Document_Amount.Name = "Document_Amount";
            this.Document_Amount.ReadOnly = true;
            this.Document_Amount.Width = 160;
            // 
            // IS_Vendor_Payer
            // 
            this.IS_Vendor_Payer.DataPropertyName = "IS_Vendor_Payer";
            this.IS_Vendor_Payer.HeaderText = "Рахунок сплачує Постачальник";
            this.IS_Vendor_Payer.Name = "IS_Vendor_Payer";
            this.IS_Vendor_Payer.ReadOnly = true;
            this.IS_Vendor_Payer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IS_Vendor_Payer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IS_Vendor_Payer.Width = 200;
            // 
            // docAttachmentsBindingSource
            // 
            this.docAttachmentsBindingSource.DataMember = "DocAttachments";
            this.docAttachmentsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Все файлы|*.*";
            this.saveFileDialog.Title = "Збереження прикріпленого файла";
            // 
            // docAttachmentsTableAdapter
            // 
            this.docAttachmentsTableAdapter.ClearBeforeFill = true;
            // 
            // ComplaintAttachmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 411);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "ComplaintAttachmentsForm";
            this.Text = "Прикріплені до {0} файли";
            this.Load += new System.EventHandler(this.ComplaintAttachmentsForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ComplaintAttachmentsForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintAttachmentsForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.dgvFiles, 0);
            this.pnlButtons.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAttachmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnView;
        private System.Windows.Forms.ToolStripButton btnSaveAs;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.BindingSource docAttachmentsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter docAttachmentsTableAdapter;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditAttachmentRequisites;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton sbSaveAll;
        private System.Windows.Forms.ToolStripMenuItem miClearSettings;
        private System.Windows.Forms.ToolStripMenuItem miSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcIsChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn attachmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessionIDCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Document_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Document_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Document_Amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IS_Vendor_Payer;

    }
}