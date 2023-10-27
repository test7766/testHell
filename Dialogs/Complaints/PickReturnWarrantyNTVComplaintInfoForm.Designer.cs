namespace WMSOffice.Dialogs.Complaints
{
    partial class PickReturnWarrantyNTVComplaintInfoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.pnlItemsContent = new System.Windows.Forms.Panel();
            this.dgvItemsInfo = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOGRItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.tsItems = new System.Windows.Forms.ToolStrip();
            this.btnAcceptNTV = new System.Windows.Forms.ToolStripButton();
            this.tssDeclineNTV = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeclineNTV = new System.Windows.Forms.ToolStripButton();
            this.scAttachments = new System.Windows.Forms.SplitContainer();
            this.pnlAttachmentsContent = new System.Windows.Forms.Panel();
            this.dgvAttachments = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Users_Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docAttachmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsAttachments = new System.Windows.Forms.ToolStrip();
            this.btnOpenAttachment = new System.Windows.Forms.ToolStripButton();
            this.ivcAttachments = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.docAttachmentsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter();
            this.cO_GR_ItemsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_GR_ItemsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlItemsContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOGRItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.tsItems.SuspendLayout();
            this.scAttachments.Panel1.SuspendLayout();
            this.scAttachments.Panel2.SuspendLayout();
            this.scAttachments.SuspendLayout();
            this.pnlAttachmentsContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAttachmentsBindingSource)).BeginInit();
            this.tsAttachments.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3109, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3199, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 658);
            this.pnlButtons.Size = new System.Drawing.Size(1084, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.scMain);
            this.pnlContent.Location = new System.Drawing.Point(0, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1084, 650);
            this.pnlContent.TabIndex = 101;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.pnlItemsContent);
            this.scMain.Panel1.Controls.Add(this.tsItems);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scAttachments);
            this.scMain.Size = new System.Drawing.Size(1084, 650);
            this.scMain.SplitterDistance = 127;
            this.scMain.TabIndex = 0;
            // 
            // pnlItemsContent
            // 
            this.pnlItemsContent.Controls.Add(this.dgvItemsInfo);
            this.pnlItemsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemsContent.Location = new System.Drawing.Point(0, 39);
            this.pnlItemsContent.Name = "pnlItemsContent";
            this.pnlItemsContent.Size = new System.Drawing.Size(1084, 88);
            this.pnlItemsContent.TabIndex = 1;
            // 
            // dgvItemsInfo
            // 
            this.dgvItemsInfo.AllowUserToAddRows = false;
            this.dgvItemsInfo.AllowUserToDeleteRows = false;
            this.dgvItemsInfo.AllowUserToResizeRows = false;
            this.dgvItemsInfo.AutoGenerateColumns = false;
            this.dgvItemsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItemsInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.resultQuantityDataGridViewTextBoxColumn,
            this.ConfirmQuantity,
            this.expirationdateDataGridViewTextBoxColumn});
            this.dgvItemsInfo.DataSource = this.cOGRItemsBindingSource;
            this.dgvItemsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemsInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvItemsInfo.MultiSelect = false;
            this.dgvItemsInfo.Name = "dgvItemsInfo";
            this.dgvItemsInfo.RowHeadersVisible = false;
            this.dgvItemsInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemsInfo.Size = new System.Drawing.Size(1084, 88);
            this.dgvItemsInfo.TabIndex = 0;
            this.dgvItemsInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItemsInfo_CellFormatting);
            this.dgvItemsInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItemsInfo_DataError);
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наменование товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 150;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 150;
            // 
            // resultQuantityDataGridViewTextBoxColumn
            // 
            this.resultQuantityDataGridViewTextBoxColumn.DataPropertyName = "ResultQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.resultQuantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.resultQuantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.resultQuantityDataGridViewTextBoxColumn.Name = "resultQuantityDataGridViewTextBoxColumn";
            this.resultQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ConfirmQuantity
            // 
            this.ConfirmQuantity.DataPropertyName = "ConfirmQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.ConfirmQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.ConfirmQuantity.HeaderText = "Кол-во подтвер.";
            this.ConfirmQuantity.Name = "ConfirmQuantity";
            // 
            // expirationdateDataGridViewTextBoxColumn
            // 
            this.expirationdateDataGridViewTextBoxColumn.DataPropertyName = "Expiration_date";
            this.expirationdateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expirationdateDataGridViewTextBoxColumn.Name = "expirationdateDataGridViewTextBoxColumn";
            this.expirationdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOGRItemsBindingSource
            // 
            this.cOGRItemsBindingSource.DataMember = "CO_GR_Items";
            this.cOGRItemsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsItems
            // 
            this.tsItems.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAcceptNTV,
            this.tssDeclineNTV,
            this.btnDeclineNTV});
            this.tsItems.Location = new System.Drawing.Point(0, 0);
            this.tsItems.Name = "tsItems";
            this.tsItems.Size = new System.Drawing.Size(1084, 39);
            this.tsItems.TabIndex = 0;
            this.tsItems.Text = "toolStrip1";
            // 
            // btnAcceptNTV
            // 
            this.btnAcceptNTV.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.btnAcceptNTV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptNTV.Name = "btnAcceptNTV";
            this.btnAcceptNTV.Size = new System.Drawing.Size(140, 36);
            this.btnAcceptNTV.Text = "Подтвердить\nсоответствие НТВ";
            this.btnAcceptNTV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcceptNTV.Click += new System.EventHandler(this.btnAcceptNTV_Click);
            // 
            // tssDeclineNTV
            // 
            this.tssDeclineNTV.Name = "tssDeclineNTV";
            this.tssDeclineNTV.Size = new System.Drawing.Size(6, 39);
            // 
            // btnDeclineNTV
            // 
            this.btnDeclineNTV.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnDeclineNTV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeclineNTV.Name = "btnDeclineNTV";
            this.btnDeclineNTV.Size = new System.Drawing.Size(166, 36);
            this.btnDeclineNTV.Text = "Фото не соответствует\nНТВ на упаковке";
            this.btnDeclineNTV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeclineNTV.Click += new System.EventHandler(this.btnDeclineNTV_Click);
            // 
            // scAttachments
            // 
            this.scAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scAttachments.Location = new System.Drawing.Point(0, 0);
            this.scAttachments.Name = "scAttachments";
            // 
            // scAttachments.Panel1
            // 
            this.scAttachments.Panel1.Controls.Add(this.pnlAttachmentsContent);
            this.scAttachments.Panel1.Controls.Add(this.tsAttachments);
            // 
            // scAttachments.Panel2
            // 
            this.scAttachments.Panel2.Controls.Add(this.ivcAttachments);
            this.scAttachments.Size = new System.Drawing.Size(1084, 519);
            this.scAttachments.SplitterDistance = 486;
            this.scAttachments.TabIndex = 0;
            // 
            // pnlAttachmentsContent
            // 
            this.pnlAttachmentsContent.Controls.Add(this.dgvAttachments);
            this.pnlAttachmentsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttachmentsContent.Location = new System.Drawing.Point(0, 25);
            this.pnlAttachmentsContent.Name = "pnlAttachmentsContent";
            this.pnlAttachmentsContent.Size = new System.Drawing.Size(486, 494);
            this.pnlAttachmentsContent.TabIndex = 1;
            // 
            // dgvAttachments
            // 
            this.dgvAttachments.AllowUserToAddRows = false;
            this.dgvAttachments.AllowUserToDeleteRows = false;
            this.dgvAttachments.AllowUserToResizeRows = false;
            this.dgvAttachments.AutoGenerateColumns = false;
            this.dgvAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAttachments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.fileLengthDataGridViewTextBoxColumn,
            this.Users_Created,
            this.dateCreatedDataGridViewTextBoxColumn});
            this.dgvAttachments.DataSource = this.docAttachmentsBindingSource;
            this.dgvAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachments.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachments.MultiSelect = false;
            this.dgvAttachments.Name = "dgvAttachments";
            this.dgvAttachments.ReadOnly = true;
            this.dgvAttachments.RowHeadersVisible = false;
            this.dgvAttachments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachments.Size = new System.Drawing.Size(486, 494);
            this.dgvAttachments.TabIndex = 1;
            this.dgvAttachments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttachments_CellDoubleClick);
            this.dgvAttachments.SelectionChanged += new System.EventHandler(this.dgvAttachments_SelectionChanged);
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "File_Name";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "Имя файла";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Описание (тип)";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // fileLengthDataGridViewTextBoxColumn
            // 
            this.fileLengthDataGridViewTextBoxColumn.DataPropertyName = "File_Length";
            this.fileLengthDataGridViewTextBoxColumn.HeaderText = "Размер";
            this.fileLengthDataGridViewTextBoxColumn.Name = "fileLengthDataGridViewTextBoxColumn";
            this.fileLengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileLengthDataGridViewTextBoxColumn.Width = 80;
            // 
            // Users_Created
            // 
            this.Users_Created.DataPropertyName = "Users_Created";
            this.Users_Created.HeaderText = "Кем добавлен";
            this.Users_Created.Name = "Users_Created";
            this.Users_Created.ReadOnly = true;
            this.Users_Created.Width = 200;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Created";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Дата добавления";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreatedDataGridViewTextBoxColumn.Width = 150;
            // 
            // docAttachmentsBindingSource
            // 
            this.docAttachmentsBindingSource.DataMember = "DocAttachments";
            this.docAttachmentsBindingSource.DataSource = this.complaints;
            // 
            // tsAttachments
            // 
            this.tsAttachments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenAttachment});
            this.tsAttachments.Location = new System.Drawing.Point(0, 0);
            this.tsAttachments.Name = "tsAttachments";
            this.tsAttachments.Size = new System.Drawing.Size(486, 25);
            this.tsAttachments.TabIndex = 0;
            this.tsAttachments.Text = "toolStrip2";
            // 
            // btnOpenAttachment
            // 
            this.btnOpenAttachment.Image = global::WMSOffice.Properties.Resources.open_folder_icon;
            this.btnOpenAttachment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenAttachment.Name = "btnOpenAttachment";
            this.btnOpenAttachment.Size = new System.Drawing.Size(74, 22);
            this.btnOpenAttachment.Text = "Открыть";
            this.btnOpenAttachment.Click += new System.EventHandler(this.btnOpenAttachment_Click);
            // 
            // ivcAttachments
            // 
            this.ivcAttachments.AutoZoomActivated = true;
            this.ivcAttachments.CurrentItem = null;
            this.ivcAttachments.CurrentZoomFactor = 1;
            this.ivcAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivcAttachments.Location = new System.Drawing.Point(0, 0);
            this.ivcAttachments.Name = "ivcAttachments";
            this.ivcAttachments.Size = new System.Drawing.Size(594, 519);
            this.ivcAttachments.TabIndex = 0;
            // 
            // docAttachmentsTableAdapter
            // 
            this.docAttachmentsTableAdapter.ClearBeforeFill = true;
            // 
            // cO_GR_ItemsTableAdapter
            // 
            this.cO_GR_ItemsTableAdapter.ClearBeforeFill = true;
            // 
            // PickReturnWarrantyNTVComplaintInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 701);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "PickReturnWarrantyNTVComplaintInfoForm";
            this.Text = "Проверьте НТВ с прикрепленных файлов, подтвердите соответствие НТВ с фото";
            this.SizeChanged += new System.EventHandler(this.PickReturnWarrantyNTVComplaintInfoForm_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PickReturnWarrantyNTVComplaintInfoForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.pnlItemsContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOGRItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.tsItems.ResumeLayout(false);
            this.tsItems.PerformLayout();
            this.scAttachments.Panel1.ResumeLayout(false);
            this.scAttachments.Panel1.PerformLayout();
            this.scAttachments.Panel2.ResumeLayout(false);
            this.scAttachments.ResumeLayout(false);
            this.pnlAttachmentsContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAttachmentsBindingSource)).EndInit();
            this.tsAttachments.ResumeLayout(false);
            this.tsAttachments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scAttachments;
        private System.Windows.Forms.Panel pnlAttachmentsContent;
        private System.Windows.Forms.DataGridView dgvAttachments;
        private System.Windows.Forms.ToolStrip tsAttachments;
        private System.Windows.Forms.Panel pnlItemsContent;
        private System.Windows.Forms.DataGridView dgvItemsInfo;
        private System.Windows.Forms.ToolStrip tsItems;
        private System.Windows.Forms.ToolStripButton btnOpenAttachment;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcAttachments;
        private System.Windows.Forms.ToolStripButton btnAcceptNTV;
        private System.Windows.Forms.BindingSource docAttachmentsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter docAttachmentsTableAdapter;
        private System.Windows.Forms.BindingSource cOGRItemsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_GR_ItemsTableAdapter cO_GR_ItemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Users_Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton btnDeclineNTV;
        private System.Windows.Forms.ToolStripSeparator tssDeclineNTV;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationdateDataGridViewTextBoxColumn;
    }
}