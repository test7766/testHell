namespace WMSOffice.Dialogs.Complaints
{
    partial class EditComplaintForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbCommonInfo = new System.Windows.Forms.GroupBox();
            this.txbComment = new System.Windows.Forms.TextBox();
            this.lblCommentCaption = new System.Windows.Forms.Label();
            this.lblContactName = new System.Windows.Forms.Label();
            this.lblContactNameCaption = new System.Windows.Forms.Label();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.lblDocStatusCaption = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDocTypeCaption = new System.Windows.Forms.Label();
            this.lblDocID = new System.Windows.Forms.Label();
            this.lblDocIDCaption = new System.Windows.Forms.Label();
            this.dgvComplaintDetails = new System.Windows.Forms.DataGridView();
            this.clRelatedOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRelatedOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRelatedInvoiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRelatedInvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDocRequestDetails = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.grbComplaintDetails = new System.Windows.Forms.GroupBox();
            this.btnChangeLocation = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taDocRequestDetails = new WMSOffice.Data.ComplaintsTableAdapters.DocRequestDetailsTableAdapter();
            this.grbCommonInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaintDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocRequestDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.grbComplaintDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCommonInfo
            // 
            this.grbCommonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCommonInfo.Controls.Add(this.txbComment);
            this.grbCommonInfo.Controls.Add(this.lblCommentCaption);
            this.grbCommonInfo.Controls.Add(this.lblContactName);
            this.grbCommonInfo.Controls.Add(this.lblContactNameCaption);
            this.grbCommonInfo.Controls.Add(this.lblDocStatus);
            this.grbCommonInfo.Controls.Add(this.lblDocStatusCaption);
            this.grbCommonInfo.Controls.Add(this.lblDocType);
            this.grbCommonInfo.Controls.Add(this.lblDocTypeCaption);
            this.grbCommonInfo.Controls.Add(this.lblDocID);
            this.grbCommonInfo.Controls.Add(this.lblDocIDCaption);
            this.grbCommonInfo.Location = new System.Drawing.Point(12, 12);
            this.grbCommonInfo.Name = "grbCommonInfo";
            this.grbCommonInfo.Size = new System.Drawing.Size(760, 101);
            this.grbCommonInfo.TabIndex = 7;
            this.grbCommonInfo.TabStop = false;
            this.grbCommonInfo.Text = "Общая информация претензии";
            // 
            // txbComment
            // 
            this.txbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbComment.Location = new System.Drawing.Point(122, 62);
            this.txbComment.Multiline = true;
            this.txbComment.Name = "txbComment";
            this.txbComment.ReadOnly = true;
            this.txbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbComment.Size = new System.Drawing.Size(632, 33);
            this.txbComment.TabIndex = 10;
            // 
            // lblCommentCaption
            // 
            this.lblCommentCaption.AutoSize = true;
            this.lblCommentCaption.Location = new System.Drawing.Point(6, 62);
            this.lblCommentCaption.Name = "lblCommentCaption";
            this.lblCommentCaption.Size = new System.Drawing.Size(116, 13);
            this.lblCommentCaption.TabIndex = 16;
            this.lblCommentCaption.Text = "Описание претензии:";
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblContactName.Location = new System.Drawing.Point(119, 46);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(238, 13);
            this.lblContactName.TabIndex = 15;
            this.lblContactName.Text = "Иванов Иван Иванович, тел. 45454545";
            // 
            // lblContactNameCaption
            // 
            this.lblContactNameCaption.AutoSize = true;
            this.lblContactNameCaption.Location = new System.Drawing.Point(6, 46);
            this.lblContactNameCaption.Name = "lblContactNameCaption";
            this.lblContactNameCaption.Size = new System.Drawing.Size(95, 13);
            this.lblContactNameCaption.TabIndex = 14;
            this.lblContactNameCaption.Text = "Контактная инф.:";
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocStatus.Location = new System.Drawing.Point(443, 16);
            this.lblDocStatus.Name = "lblDocStatus";
            this.lblDocStatus.Size = new System.Drawing.Size(311, 26);
            this.lblDocStatus.TabIndex = 5;
            this.lblDocStatus.Text = "(666) Пошла по второму кругу";
            // 
            // lblDocStatusCaption
            // 
            this.lblDocStatusCaption.AutoSize = true;
            this.lblDocStatusCaption.Location = new System.Drawing.Point(337, 16);
            this.lblDocStatusCaption.Name = "lblDocStatusCaption";
            this.lblDocStatusCaption.Size = new System.Drawing.Size(100, 13);
            this.lblDocStatusCaption.TabIndex = 4;
            this.lblDocStatusCaption.Text = "Статус претензии:";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocType.Location = new System.Drawing.Point(119, 31);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(199, 13);
            this.lblDocType.TabIndex = 3;
            this.lblDocType.Text = "Недостача с нетоварным видом";
            // 
            // lblDocTypeCaption
            // 
            this.lblDocTypeCaption.AutoSize = true;
            this.lblDocTypeCaption.Location = new System.Drawing.Point(6, 31);
            this.lblDocTypeCaption.Name = "lblDocTypeCaption";
            this.lblDocTypeCaption.Size = new System.Drawing.Size(85, 13);
            this.lblDocTypeCaption.TabIndex = 2;
            this.lblDocTypeCaption.Text = "Тип претензии:";
            // 
            // lblDocID
            // 
            this.lblDocID.AutoSize = true;
            this.lblDocID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocID.Location = new System.Drawing.Point(119, 16);
            this.lblDocID.Name = "lblDocID";
            this.lblDocID.Size = new System.Drawing.Size(42, 13);
            this.lblDocID.TabIndex = 1;
            this.lblDocID.Text = "12345";
            // 
            // lblDocIDCaption
            // 
            this.lblDocIDCaption.AutoSize = true;
            this.lblDocIDCaption.Location = new System.Drawing.Point(6, 16);
            this.lblDocIDCaption.Name = "lblDocIDCaption";
            this.lblDocIDCaption.Size = new System.Drawing.Size(85, 13);
            this.lblDocIDCaption.TabIndex = 0;
            this.lblDocIDCaption.Text = "Код претензии:";
            // 
            // dgvComplaintDetails
            // 
            this.dgvComplaintDetails.AllowUserToAddRows = false;
            this.dgvComplaintDetails.AllowUserToDeleteRows = false;
            this.dgvComplaintDetails.AllowUserToOrderColumns = true;
            this.dgvComplaintDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvComplaintDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComplaintDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComplaintDetails.AutoGenerateColumns = false;
            this.dgvComplaintDetails.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaintDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvComplaintDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComplaintDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clRelatedOrderType,
            this.clRelatedOrderNumber,
            this.clRelatedInvoiceType,
            this.clRelatedInvoiceNumber,
            this.clItemID,
            this.clItemName,
            this.clManufacturer,
            this.clVendorLot,
            this.clLocation,
            this.clQuantity,
            this.clUnitOfMeasure});
            this.dgvComplaintDetails.DataSource = this.bsDocRequestDetails;
            this.dgvComplaintDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvComplaintDetails.Location = new System.Drawing.Point(9, 47);
            this.dgvComplaintDetails.MultiSelect = false;
            this.dgvComplaintDetails.Name = "dgvComplaintDetails";
            this.dgvComplaintDetails.RowHeadersVisible = false;
            this.dgvComplaintDetails.RowTemplate.Height = 21;
            this.dgvComplaintDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComplaintDetails.ShowEditingIcon = false;
            this.dgvComplaintDetails.Size = new System.Drawing.Size(745, 299);
            this.dgvComplaintDetails.TabIndex = 40;
            this.dgvComplaintDetails.SelectionChanged += new System.EventHandler(this.dgvComplaintDetails_SelectionChanged);
            // 
            // clRelatedOrderType
            // 
            this.clRelatedOrderType.DataPropertyName = "Related_Order_Type";
            this.clRelatedOrderType.HeaderText = "Тип зак.";
            this.clRelatedOrderType.Name = "clRelatedOrderType";
            this.clRelatedOrderType.ReadOnly = true;
            this.clRelatedOrderType.Width = 35;
            // 
            // clRelatedOrderNumber
            // 
            this.clRelatedOrderNumber.DataPropertyName = "Related_Order_Number";
            this.clRelatedOrderNumber.HeaderText = "№ заказа";
            this.clRelatedOrderNumber.Name = "clRelatedOrderNumber";
            this.clRelatedOrderNumber.ReadOnly = true;
            this.clRelatedOrderNumber.Width = 90;
            // 
            // clRelatedInvoiceType
            // 
            this.clRelatedInvoiceType.DataPropertyName = "Related_Invoice_Type";
            this.clRelatedInvoiceType.HeaderText = "Тип нак.";
            this.clRelatedInvoiceType.Name = "clRelatedInvoiceType";
            this.clRelatedInvoiceType.ReadOnly = true;
            this.clRelatedInvoiceType.Width = 35;
            // 
            // clRelatedInvoiceNumber
            // 
            this.clRelatedInvoiceNumber.DataPropertyName = "Related_Invoice_Number";
            this.clRelatedInvoiceNumber.HeaderText = "№ накладной";
            this.clRelatedInvoiceNumber.Name = "clRelatedInvoiceNumber";
            this.clRelatedInvoiceNumber.ReadOnly = true;
            this.clRelatedInvoiceNumber.Width = 90;
            // 
            // clItemID
            // 
            this.clItemID.DataPropertyName = "Item_ID";
            this.clItemID.HeaderText = "Код товара";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 60;
            // 
            // clItemName
            // 
            this.clItemName.DataPropertyName = "Item_Name";
            this.clItemName.HeaderText = "Наименование товара";
            this.clItemName.Name = "clItemName";
            this.clItemName.ReadOnly = true;
            this.clItemName.Width = 160;
            // 
            // clManufacturer
            // 
            this.clManufacturer.DataPropertyName = "Manufacturer";
            this.clManufacturer.HeaderText = "Производитель";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.ReadOnly = true;
            // 
            // clVendorLot
            // 
            this.clVendorLot.DataPropertyName = "Vendor_Lot_Fact";
            this.clVendorLot.HeaderText = "Серия факт.";
            this.clVendorLot.MaxInputLength = 50;
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            this.clVendorLot.Width = 90;
            // 
            // clLocation
            // 
            this.clLocation.DataPropertyName = "Location";
            this.clLocation.HeaderText = "Целевая полка";
            this.clLocation.Name = "clLocation";
            this.clLocation.ReadOnly = true;
            // 
            // clQuantity
            // 
            this.clQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.clQuantity.HeaderText = "К-во";
            this.clQuantity.Name = "clQuantity";
            this.clQuantity.Width = 60;
            // 
            // clUnitOfMeasure
            // 
            this.clUnitOfMeasure.DataPropertyName = "UnitOfMeasure";
            this.clUnitOfMeasure.HeaderText = "ЕИ";
            this.clUnitOfMeasure.MaxInputLength = 2;
            this.clUnitOfMeasure.Name = "clUnitOfMeasure";
            this.clUnitOfMeasure.ReadOnly = true;
            this.clUnitOfMeasure.Width = 40;
            // 
            // bsDocRequestDetails
            // 
            this.bsDocRequestDetails.DataMember = "DocRequestDetails";
            this.bsDocRequestDetails.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grbComplaintDetails
            // 
            this.grbComplaintDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbComplaintDetails.Controls.Add(this.btnChangeLocation);
            this.grbComplaintDetails.Controls.Add(this.dgvComplaintDetails);
            this.grbComplaintDetails.Location = new System.Drawing.Point(12, 119);
            this.grbComplaintDetails.Name = "grbComplaintDetails";
            this.grbComplaintDetails.Size = new System.Drawing.Size(760, 352);
            this.grbComplaintDetails.TabIndex = 20;
            this.grbComplaintDetails.TabStop = false;
            this.grbComplaintDetails.Text = "Строки претензии для корректировки";
            // 
            // btnChangeLocation
            // 
            this.btnChangeLocation.Enabled = false;
            this.btnChangeLocation.Location = new System.Drawing.Point(9, 19);
            this.btnChangeLocation.Name = "btnChangeLocation";
            this.btnChangeLocation.Size = new System.Drawing.Size(113, 23);
            this.btnChangeLocation.TabIndex = 30;
            this.btnChangeLocation.Text = "Изменить полку";
            this.btnChangeLocation.UseVisualStyleBackColor = true;
            this.btnChangeLocation.Click += new System.EventHandler(this.btnChangeLocation_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(616, 477);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 50;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(697, 477);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Line_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код строки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Код товара";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item_Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Наименование товара";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn4.HeaderText = "Наименование производителя";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Vendor_Lot_Fact";
            this.dataGridViewTextBoxColumn5.HeaderText = "Серия факт.";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 50;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UnitOfMeasure";
            this.dataGridViewTextBoxColumn6.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn7.HeaderText = "К-во";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "RelatedLineID";
            this.dataGridViewTextBoxColumn8.HeaderText = "RelatedLineID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // taDocRequestDetails
            // 
            this.taDocRequestDetails.ClearBeforeFill = true;
            // 
            // EditComplaintForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grbComplaintDetails);
            this.Controls.Add(this.grbCommonInfo);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "EditComplaintForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Корректировка состава претензии";
            this.Load += new System.EventHandler(this.EditComplaintForm_Load);
            this.grbCommonInfo.ResumeLayout(false);
            this.grbCommonInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaintDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocRequestDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.grbComplaintDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCommonInfo;
        private System.Windows.Forms.Label lblCommentCaption;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.Label lblContactNameCaption;
        private System.Windows.Forms.Label lblDocStatus;
        private System.Windows.Forms.Label lblDocStatusCaption;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDocTypeCaption;
        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.Label lblDocIDCaption;
        private System.Windows.Forms.DataGridView dgvComplaintDetails;
        private System.Windows.Forms.GroupBox grbComplaintDetails;
        private System.Windows.Forms.BindingSource bsDocRequestDetails;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.DocRequestDetailsTableAdapter taDocRequestDetails;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TextBox txbComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRelatedOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRelatedOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRelatedInvoiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRelatedInvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnitOfMeasure;
        private System.Windows.Forms.Button btnChangeLocation;
    }
}