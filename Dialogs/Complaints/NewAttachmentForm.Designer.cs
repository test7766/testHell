namespace WMSOffice.Dialogs.Complaints
{
    partial class NewAttachmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAttachmentForm));
            this.lblFilePath = new System.Windows.Forms.Label();
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            this.docAttachmentTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFileSizeCaption = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tltFilePaths = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAttachDocNumber = new System.Windows.Forms.TextBox();
            this.dtpAttachDocDate = new System.Windows.Forms.DateTimePicker();
            this.pnlAttachment = new System.Windows.Forms.Panel();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.pnlAttachmentRequisites = new System.Windows.Forms.Panel();
            this.cbAttachDocIsVendorPayer = new System.Windows.Forms.CheckBox();
            this.nudAttachDocAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAttachDocAmount = new System.Windows.Forms.Label();
            this.docAttachmentTypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.DocAttachmentTypesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.docAttachmentTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.pnlAttachment.SuspendLayout();
            this.pnlAttachmentRequisites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttachDocAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(10, 11);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(161, 13);
            this.lblFilePath.TabIndex = 101;
            this.lblFilePath.Text = "Шлях до прикріпленого файлу:";
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFilePath.Location = new System.Drawing.Point(10, 27);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.ReadOnly = true;
            this.tbxFilePath.Size = new System.Drawing.Size(392, 20);
            this.tbxFilePath.TabIndex = 10;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Усі файли|*.*";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Відкриття файла";
            // 
            // cmbDescription
            // 
            this.cmbDescription.DataSource = this.docAttachmentTypesBindingSource;
            this.cmbDescription.DisplayMember = "Attachment_Type_Name";
            this.cmbDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Location = new System.Drawing.Point(10, 66);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(210, 21);
            this.cmbDescription.TabIndex = 30;
            this.cmbDescription.ValueMember = "Attachment_Type_Code";
            this.cmbDescription.SelectedIndexChanged += new System.EventHandler(this.cmbDescription_SelectedIndexChanged);
            // 
            // docAttachmentTypesBindingSource
            // 
            this.docAttachmentTypesBindingSource.DataMember = "DocAttachmentTypes";
            this.docAttachmentTypesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.Location = new System.Drawing.Point(402, 25);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(87, 23);
            this.btnOpenFile.TabIndex = 20;
            this.btnOpenFile.Text = "Відкрити";
            this.btnOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(10, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(232, 13);
            this.lblDescription.TabIndex = 105;
            this.lblDescription.Text = "Опис (тип) файлів, оберіть варіант із списка:";
            // 
            // lblFileSizeCaption
            // 
            this.lblFileSizeCaption.AutoSize = true;
            this.lblFileSizeCaption.Location = new System.Drawing.Point(10, 96);
            this.lblFileSizeCaption.Name = "lblFileSizeCaption";
            this.lblFileSizeCaption.Size = new System.Drawing.Size(138, 13);
            this.lblFileSizeCaption.TabIndex = 106;
            this.lblFileSizeCaption.Text = "Загальний розмір файлів:";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileSize.Location = new System.Drawing.Point(137, 96);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(34, 13);
            this.lblFileSize.TabIndex = 107;
            this.lblFileSize.Text = "0 КБ";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(412, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(331, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "№ документа вкладення:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Дата документа вкладення:";
            // 
            // tbAttachDocNumber
            // 
            this.tbAttachDocNumber.Location = new System.Drawing.Point(10, 22);
            this.tbAttachDocNumber.Name = "tbAttachDocNumber";
            this.tbAttachDocNumber.Size = new System.Drawing.Size(120, 20);
            this.tbAttachDocNumber.TabIndex = 40;
            // 
            // dtpAttachDocDate
            // 
            this.dtpAttachDocDate.CustomFormat = "dd / MM / yyyy";
            this.dtpAttachDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAttachDocDate.Location = new System.Drawing.Point(174, 22);
            this.dtpAttachDocDate.Name = "dtpAttachDocDate";
            this.dtpAttachDocDate.Size = new System.Drawing.Size(120, 20);
            this.dtpAttachDocDate.TabIndex = 50;
            // 
            // pnlAttachment
            // 
            this.pnlAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAttachment.Controls.Add(this.tbDescription);
            this.pnlAttachment.Controls.Add(this.lblFilePath);
            this.pnlAttachment.Controls.Add(this.btnOpenFile);
            this.pnlAttachment.Controls.Add(this.tbxFilePath);
            this.pnlAttachment.Controls.Add(this.cmbDescription);
            this.pnlAttachment.Controls.Add(this.lblDescription);
            this.pnlAttachment.Controls.Add(this.lblFileSizeCaption);
            this.pnlAttachment.Controls.Add(this.lblFileSize);
            this.pnlAttachment.Location = new System.Drawing.Point(2, 4);
            this.pnlAttachment.Name = "pnlAttachment";
            this.pnlAttachment.Size = new System.Drawing.Size(493, 118);
            this.pnlAttachment.TabIndex = 110;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(226, 66);
            this.tbDescription.MaxLength = 255;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(259, 20);
            this.tbDescription.TabIndex = 35;
            this.tbDescription.Visible = false;
            // 
            // pnlAttachmentRequisites
            // 
            this.pnlAttachmentRequisites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAttachmentRequisites.Controls.Add(this.cbAttachDocIsVendorPayer);
            this.pnlAttachmentRequisites.Controls.Add(this.nudAttachDocAmount);
            this.pnlAttachmentRequisites.Controls.Add(this.lblAttachDocAmount);
            this.pnlAttachmentRequisites.Controls.Add(this.label1);
            this.pnlAttachmentRequisites.Controls.Add(this.label2);
            this.pnlAttachmentRequisites.Controls.Add(this.dtpAttachDocDate);
            this.pnlAttachmentRequisites.Controls.Add(this.tbAttachDocNumber);
            this.pnlAttachmentRequisites.Location = new System.Drawing.Point(2, 121);
            this.pnlAttachmentRequisites.Name = "pnlAttachmentRequisites";
            this.pnlAttachmentRequisites.Size = new System.Drawing.Size(493, 75);
            this.pnlAttachmentRequisites.TabIndex = 111;
            // 
            // cbAttachDocIsVendorPayer
            // 
            this.cbAttachDocIsVendorPayer.AutoSize = true;
            this.cbAttachDocIsVendorPayer.Location = new System.Drawing.Point(13, 50);
            this.cbAttachDocIsVendorPayer.Name = "cbAttachDocIsVendorPayer";
            this.cbAttachDocIsVendorPayer.Size = new System.Drawing.Size(185, 17);
            this.cbAttachDocIsVendorPayer.TabIndex = 70;
            this.cbAttachDocIsVendorPayer.Text = "Рахунок сплачує Постачальник";
            this.cbAttachDocIsVendorPayer.UseVisualStyleBackColor = true;
            // 
            // nudAttachDocAmount
            // 
            this.nudAttachDocAmount.DecimalPlaces = 2;
            this.nudAttachDocAmount.Location = new System.Drawing.Point(334, 22);
            this.nudAttachDocAmount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudAttachDocAmount.Name = "nudAttachDocAmount";
            this.nudAttachDocAmount.Size = new System.Drawing.Size(120, 20);
            this.nudAttachDocAmount.TabIndex = 60;
            this.nudAttachDocAmount.ThousandsSeparator = true;
            // 
            // lblAttachDocAmount
            // 
            this.lblAttachDocAmount.AutoSize = true;
            this.lblAttachDocAmount.Location = new System.Drawing.Point(336, 6);
            this.lblAttachDocAmount.Name = "lblAttachDocAmount";
            this.lblAttachDocAmount.Size = new System.Drawing.Size(152, 13);
            this.lblAttachDocAmount.TabIndex = 110;
            this.lblAttachDocAmount.Text = "Сума документа з ПДВ, грн.";
            // 
            // docAttachmentTypesTableAdapter
            // 
            this.docAttachmentTypesTableAdapter.ClearBeforeFill = true;
            // 
            // NewAttachmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(499, 245);
            this.Controls.Add(this.pnlAttachmentRequisites);
            this.Controls.Add(this.pnlAttachment);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewAttachmentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Додавання файлів до {0}";
            this.Load += new System.EventHandler(this.NewAttachmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.docAttachmentTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.pnlAttachment.ResumeLayout(false);
            this.pnlAttachment.PerformLayout();
            this.pnlAttachmentRequisites.ResumeLayout(false);
            this.pnlAttachmentRequisites.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttachDocAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox tbxFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox cmbDescription;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFileSizeCaption;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolTip tltFilePaths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAttachDocNumber;
        private System.Windows.Forms.DateTimePicker dtpAttachDocDate;
        private System.Windows.Forms.Panel pnlAttachment;
        private System.Windows.Forms.Panel pnlAttachmentRequisites;
        private System.Windows.Forms.BindingSource docAttachmentTypesBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.DocAttachmentTypesTableAdapter docAttachmentTypesTableAdapter;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.NumericUpDown nudAttachDocAmount;
        private System.Windows.Forms.Label lblAttachDocAmount;
        private System.Windows.Forms.CheckBox cbAttachDocIsVendorPayer;
    }
}