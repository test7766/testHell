﻿namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintSupplierDefectAnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintSupplierDefectAnalysisForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDocIDCaption = new System.Windows.Forms.Label();
            this.grbCommonInfo = new System.Windows.Forms.GroupBox();
            this.lblLinkedComplaintInfo = new System.Windows.Forms.Label();
            this.lblDest = new System.Windows.Forms.Label();
            this.lblDestCaption = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblSourceCaption = new System.Windows.Forms.Label();
            this.tbxComment = new System.Windows.Forms.TextBox();
            this.lblCommentCaption = new System.Windows.Forms.Label();
            this.lblContactName = new System.Windows.Forms.Label();
            this.lblContactNameCaption = new System.Windows.Forms.Label();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.lblDocStatusCaption = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDocTypeCaption = new System.Windows.Forms.Label();
            this.lblDocID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.spcTwoTables = new System.Windows.Forms.SplitContainer();
            this.grbComplaintDetails = new System.Windows.Forms.GroupBox();
            this.gbSupplierDefectOptions = new System.Windows.Forms.GroupBox();
            this.btnCreateSupplierDefectAct = new System.Windows.Forms.Button();
            this.lblCompensationTypes = new System.Windows.Forms.Label();
            this.cmbCompensationTypes = new System.Windows.Forms.ComboBox();
            this.cOGetAvailableDocsSubtypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.cmbComplaintTypes = new System.Windows.Forms.ComboBox();
            this.avaibleComplaintTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaintsExt = new WMSOffice.Data.ComplaintsExt();
            this.cbChangeComplaintType = new System.Windows.Forms.CheckBox();
            this.btnVideoControl = new System.Windows.Forms.Button();
            this.btnAttachmentRequest = new System.Windows.Forms.Button();
            this.imgImages = new System.Windows.Forms.ImageList(this.components);
            this.pbWait = new System.Windows.Forms.PictureBox();
            this.btnAddTakingRemainsRequest = new System.Windows.Forms.Button();
            this.chbShowAll = new System.Windows.Forms.CheckBox();
            this.dgvComplaintDetails = new System.Windows.Forms.DataGridView();
            this.complaintInfoI2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grbTakingRemains = new System.Windows.Forms.GroupBox();
            this.dgvTakingRemainsResults = new System.Windows.Forms.DataGridView();
            this.takingIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityByTakingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityByJDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateRemainsByJDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTakingRemains = new System.Windows.Forms.BindingSource(this.components);
            this.lastWorker = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taTakingRemains = new WMSOffice.Data.ComplaintsTableAdapters.TakingRemainsTableAdapter();
            this.avaibleComplaintTypesTableAdapter = new WMSOffice.Data.ComplaintsExtTableAdapters.AvaibleComplaintTypesTableAdapter();
            this.cO_Get_Available_Docs_SubtypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_Get_Available_Docs_SubtypesTableAdapter();
            this.btnSave = new System.Windows.Forms.Button();
            this.complaintInfoI2TableAdapter = new WMSOffice.Data.ComplaintsExtTableAdapters.ComplaintInfoI2TableAdapter();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.invoiceTypeAndNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Transfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorlotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termExpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorIDAndName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorManagerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbCommonInfo.SuspendLayout();
            this.spcTwoTables.Panel1.SuspendLayout();
            this.spcTwoTables.Panel2.SuspendLayout();
            this.spcTwoTables.SuspendLayout();
            this.grbComplaintDetails.SuspendLayout();
            this.gbSupplierDefectOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cOGetAvailableDocsSubtypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avaibleComplaintTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintsExt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaintDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintInfoI2BindingSource)).BeginInit();
            this.grbTakingRemains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakingRemainsResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTakingRemains)).BeginInit();
            this.SuspendLayout();
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
            // grbCommonInfo
            // 
            this.grbCommonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCommonInfo.Controls.Add(this.lblLinkedComplaintInfo);
            this.grbCommonInfo.Controls.Add(this.lblDest);
            this.grbCommonInfo.Controls.Add(this.lblDestCaption);
            this.grbCommonInfo.Controls.Add(this.lblSource);
            this.grbCommonInfo.Controls.Add(this.lblSourceCaption);
            this.grbCommonInfo.Controls.Add(this.tbxComment);
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
            this.grbCommonInfo.Size = new System.Drawing.Size(1095, 143);
            this.grbCommonInfo.TabIndex = 0;
            this.grbCommonInfo.TabStop = false;
            this.grbCommonInfo.Text = "Общая информация претензии";
            // 
            // lblLinkedComplaintInfo
            // 
            this.lblLinkedComplaintInfo.AutoSize = true;
            this.lblLinkedComplaintInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLinkedComplaintInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLinkedComplaintInfo.Location = new System.Drawing.Point(171, 16);
            this.lblLinkedComplaintInfo.Name = "lblLinkedComplaintInfo";
            this.lblLinkedComplaintInfo.Size = new System.Drawing.Size(138, 13);
            this.lblLinkedComplaintInfo.TabIndex = 16;
            this.lblLinkedComplaintInfo.Text = "* СВЯЗЬ С № 1234567";
            this.lblLinkedComplaintInfo.Visible = false;
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDest.Location = new System.Drawing.Point(123, 65);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(297, 13);
            this.lblDest.TabIndex = 13;
            this.lblDest.Text = "ДП \"Дочка\" ООО \"Очень щепетильная контора\"";
            this.lblDest.Visible = false;
            // 
            // lblDestCaption
            // 
            this.lblDestCaption.AutoSize = true;
            this.lblDestCaption.Location = new System.Drawing.Point(6, 65);
            this.lblDestCaption.Name = "lblDestCaption";
            this.lblDestCaption.Size = new System.Drawing.Size(114, 13);
            this.lblDestCaption.TabIndex = 12;
            this.lblDestCaption.Text = "Получатель нов.зак.:";
            this.lblDestCaption.Visible = false;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSource.Location = new System.Drawing.Point(123, 49);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(221, 13);
            this.lblSource.TabIndex = 11;
            this.lblSource.Text = "ООО \"Очень щепетильная контора\"";
            // 
            // lblSourceCaption
            // 
            this.lblSourceCaption.AutoSize = true;
            this.lblSourceCaption.Location = new System.Drawing.Point(6, 49);
            this.lblSourceCaption.Name = "lblSourceCaption";
            this.lblSourceCaption.Size = new System.Drawing.Size(114, 13);
            this.lblSourceCaption.TabIndex = 10;
            this.lblSourceCaption.Text = "Источник претензии:";
            // 
            // tbxComment
            // 
            this.tbxComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxComment.Location = new System.Drawing.Point(128, 98);
            this.tbxComment.Multiline = true;
            this.tbxComment.Name = "tbxComment";
            this.tbxComment.ReadOnly = true;
            this.tbxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxComment.Size = new System.Drawing.Size(961, 39);
            this.tbxComment.TabIndex = 9;
            this.tbxComment.TabStop = false;
            // 
            // lblCommentCaption
            // 
            this.lblCommentCaption.AutoSize = true;
            this.lblCommentCaption.Location = new System.Drawing.Point(6, 97);
            this.lblCommentCaption.Name = "lblCommentCaption";
            this.lblCommentCaption.Size = new System.Drawing.Size(116, 13);
            this.lblCommentCaption.TabIndex = 8;
            this.lblCommentCaption.Text = "Описание претензии:";
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblContactName.Location = new System.Drawing.Point(123, 81);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(238, 13);
            this.lblContactName.TabIndex = 7;
            this.lblContactName.Text = "Иванов Иван Иванович, тел. 45454545";
            // 
            // lblContactNameCaption
            // 
            this.lblContactNameCaption.AutoSize = true;
            this.lblContactNameCaption.Location = new System.Drawing.Point(6, 81);
            this.lblContactNameCaption.Name = "lblContactNameCaption";
            this.lblContactNameCaption.Size = new System.Drawing.Size(115, 13);
            this.lblContactNameCaption.TabIndex = 6;
            this.lblContactNameCaption.Text = "Контактная информ.:";
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocStatus.Location = new System.Drawing.Point(418, 16);
            this.lblDocStatus.Name = "lblDocStatus";
            this.lblDocStatus.Size = new System.Drawing.Size(671, 26);
            this.lblDocStatus.TabIndex = 3;
            this.lblDocStatus.Text = "(666) Пошла по второму кругу";
            // 
            // lblDocStatusCaption
            // 
            this.lblDocStatusCaption.AutoSize = true;
            this.lblDocStatusCaption.Location = new System.Drawing.Point(312, 16);
            this.lblDocStatusCaption.Name = "lblDocStatusCaption";
            this.lblDocStatusCaption.Size = new System.Drawing.Size(100, 13);
            this.lblDocStatusCaption.TabIndex = 2;
            this.lblDocStatusCaption.Text = "Статус претензии:";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocType.Location = new System.Drawing.Point(123, 33);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(199, 13);
            this.lblDocType.TabIndex = 5;
            this.lblDocType.Text = "Недостача с нетоварным видом";
            // 
            // lblDocTypeCaption
            // 
            this.lblDocTypeCaption.AutoSize = true;
            this.lblDocTypeCaption.Location = new System.Drawing.Point(6, 33);
            this.lblDocTypeCaption.Name = "lblDocTypeCaption";
            this.lblDocTypeCaption.Size = new System.Drawing.Size(85, 13);
            this.lblDocTypeCaption.TabIndex = 4;
            this.lblDocTypeCaption.Text = "Тип претензии:";
            // 
            // lblDocID
            // 
            this.lblDocID.AutoSize = true;
            this.lblDocID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocID.Location = new System.Drawing.Point(123, 16);
            this.lblDocID.Name = "lblDocID";
            this.lblDocID.Size = new System.Drawing.Size(42, 13);
            this.lblDocID.TabIndex = 1;
            this.lblDocID.Text = "12345";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1032, 554);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // spcTwoTables
            // 
            this.spcTwoTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcTwoTables.Location = new System.Drawing.Point(12, 161);
            this.spcTwoTables.Name = "spcTwoTables";
            this.spcTwoTables.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcTwoTables.Panel1
            // 
            this.spcTwoTables.Panel1.Controls.Add(this.grbComplaintDetails);
            // 
            // spcTwoTables.Panel2
            // 
            this.spcTwoTables.Panel2.Controls.Add(this.grbTakingRemains);
            this.spcTwoTables.Size = new System.Drawing.Size(1095, 387);
            this.spcTwoTables.SplitterDistance = 298;
            this.spcTwoTables.SplitterWidth = 6;
            this.spcTwoTables.TabIndex = 4;
            // 
            // grbComplaintDetails
            // 
            this.grbComplaintDetails.Controls.Add(this.gbSupplierDefectOptions);
            this.grbComplaintDetails.Controls.Add(this.btnVideoControl);
            this.grbComplaintDetails.Controls.Add(this.btnAttachmentRequest);
            this.grbComplaintDetails.Controls.Add(this.pbWait);
            this.grbComplaintDetails.Controls.Add(this.btnAddTakingRemainsRequest);
            this.grbComplaintDetails.Controls.Add(this.chbShowAll);
            this.grbComplaintDetails.Controls.Add(this.dgvComplaintDetails);
            this.grbComplaintDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbComplaintDetails.Location = new System.Drawing.Point(0, 0);
            this.grbComplaintDetails.Name = "grbComplaintDetails";
            this.grbComplaintDetails.Size = new System.Drawing.Size(1095, 298);
            this.grbComplaintDetails.TabIndex = 0;
            this.grbComplaintDetails.TabStop = false;
            this.grbComplaintDetails.Text = "Состав претензии";
            // 
            // gbSupplierDefectOptions
            // 
            this.gbSupplierDefectOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSupplierDefectOptions.Controls.Add(this.btnCreateSupplierDefectAct);
            this.gbSupplierDefectOptions.Controls.Add(this.lblCompensationTypes);
            this.gbSupplierDefectOptions.Controls.Add(this.cmbCompensationTypes);
            this.gbSupplierDefectOptions.Controls.Add(this.cmbComplaintTypes);
            this.gbSupplierDefectOptions.Controls.Add(this.cbChangeComplaintType);
            this.gbSupplierDefectOptions.Location = new System.Drawing.Point(9, 42);
            this.gbSupplierDefectOptions.Name = "gbSupplierDefectOptions";
            this.gbSupplierDefectOptions.Size = new System.Drawing.Size(1080, 40);
            this.gbSupplierDefectOptions.TabIndex = 35;
            this.gbSupplierDefectOptions.TabStop = false;
            // 
            // btnCreateSupplierDefectAct
            // 
            this.btnCreateSupplierDefectAct.Image = global::WMSOffice.Properties.Resources.doc_pdf_16;
            this.btnCreateSupplierDefectAct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateSupplierDefectAct.Location = new System.Drawing.Point(739, 13);
            this.btnCreateSupplierDefectAct.Name = "btnCreateSupplierDefectAct";
            this.btnCreateSupplierDefectAct.Size = new System.Drawing.Size(175, 23);
            this.btnCreateSupplierDefectAct.TabIndex = 37;
            this.btnCreateSupplierDefectAct.Text = "Печать акта поставщику";
            this.btnCreateSupplierDefectAct.UseVisualStyleBackColor = true;
            this.btnCreateSupplierDefectAct.Click += new System.EventHandler(this.btnCreateSupplierDefectAct_Click);
            // 
            // lblCompensationTypes
            // 
            this.lblCompensationTypes.AutoSize = true;
            this.lblCompensationTypes.Location = new System.Drawing.Point(480, 18);
            this.lblCompensationTypes.Name = "lblCompensationTypes";
            this.lblCompensationTypes.Size = new System.Drawing.Size(97, 13);
            this.lblCompensationTypes.TabIndex = 36;
            this.lblCompensationTypes.Text = "Тип компенсации";
            // 
            // cmbCompensationTypes
            // 
            this.cmbCompensationTypes.DataSource = this.cOGetAvailableDocsSubtypesBindingSource;
            this.cmbCompensationTypes.DisplayMember = "Doc_Subtype_Name";
            this.cmbCompensationTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompensationTypes.FormattingEnabled = true;
            this.cmbCompensationTypes.Location = new System.Drawing.Point(583, 14);
            this.cmbCompensationTypes.Name = "cmbCompensationTypes";
            this.cmbCompensationTypes.Size = new System.Drawing.Size(150, 21);
            this.cmbCompensationTypes.TabIndex = 35;
            this.cmbCompensationTypes.ValueMember = "Doc_Subtype";
            // 
            // cOGetAvailableDocsSubtypesBindingSource
            // 
            this.cOGetAvailableDocsSubtypesBindingSource.DataMember = "CO_Get_Available_Docs_Subtypes";
            this.cOGetAvailableDocsSubtypesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbComplaintTypes
            // 
            this.cmbComplaintTypes.DataSource = this.avaibleComplaintTypesBindingSource;
            this.cmbComplaintTypes.DisplayMember = "Doc_Type_Name";
            this.cmbComplaintTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplaintTypes.FormattingEnabled = true;
            this.cmbComplaintTypes.Location = new System.Drawing.Point(152, 14);
            this.cmbComplaintTypes.Name = "cmbComplaintTypes";
            this.cmbComplaintTypes.Size = new System.Drawing.Size(250, 21);
            this.cmbComplaintTypes.TabIndex = 33;
            this.cmbComplaintTypes.ValueMember = "Doc_Type";
            // 
            // avaibleComplaintTypesBindingSource
            // 
            this.avaibleComplaintTypesBindingSource.DataMember = "AvaibleComplaintTypes";
            this.avaibleComplaintTypesBindingSource.DataSource = this.complaintsExt;
            // 
            // complaintsExt
            // 
            this.complaintsExt.DataSetName = "ComplaintsExt";
            this.complaintsExt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbChangeComplaintType
            // 
            this.cbChangeComplaintType.AutoSize = true;
            this.cbChangeComplaintType.Location = new System.Drawing.Point(6, 16);
            this.cbChangeComplaintType.Name = "cbChangeComplaintType";
            this.cbChangeComplaintType.Size = new System.Drawing.Size(146, 17);
            this.cbChangeComplaintType.TabIndex = 34;
            this.cbChangeComplaintType.Text = "Сменить тип претензии";
            this.cbChangeComplaintType.UseVisualStyleBackColor = true;
            this.cbChangeComplaintType.CheckedChanged += new System.EventHandler(this.cbChangeComplaintType_CheckedChanged);
            // 
            // btnVideoControl
            // 
            this.btnVideoControl.Image = global::WMSOffice.Properties.Resources.video;
            this.btnVideoControl.Location = new System.Drawing.Point(492, 16);
            this.btnVideoControl.Name = "btnVideoControl";
            this.btnVideoControl.Size = new System.Drawing.Size(120, 23);
            this.btnVideoControl.TabIndex = 32;
            this.btnVideoControl.Text = "Видеоконтроль";
            this.btnVideoControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVideoControl.UseVisualStyleBackColor = true;
            this.btnVideoControl.Click += new System.EventHandler(this.btnVideoControl_Click);
            // 
            // btnAttachmentRequest
            // 
            this.btnAttachmentRequest.ImageIndex = 0;
            this.btnAttachmentRequest.ImageList = this.imgImages;
            this.btnAttachmentRequest.Location = new System.Drawing.Point(257, 16);
            this.btnAttachmentRequest.Name = "btnAttachmentRequest";
            this.btnAttachmentRequest.Size = new System.Drawing.Size(229, 23);
            this.btnAttachmentRequest.TabIndex = 12;
            this.btnAttachmentRequest.Text = "Запрос повторного фотоотчета";
            this.btnAttachmentRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAttachmentRequest.UseVisualStyleBackColor = true;
            this.btnAttachmentRequest.Click += new System.EventHandler(this.btnAttachmentRequest_Click);
            // 
            // imgImages
            // 
            this.imgImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgImages.ImageStream")));
            this.imgImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imgImages.Images.SetKeyName(0, "paperclip.png");
            // 
            // pbWait
            // 
            this.pbWait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbWait.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbWait.Location = new System.Drawing.Point(488, 122);
            this.pbWait.Name = "pbWait";
            this.pbWait.Size = new System.Drawing.Size(100, 100);
            this.pbWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWait.TabIndex = 3;
            this.pbWait.TabStop = false;
            // 
            // btnAddTakingRemainsRequest
            // 
            this.btnAddTakingRemainsRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTakingRemainsRequest.Image")));
            this.btnAddTakingRemainsRequest.Location = new System.Drawing.Point(6, 15);
            this.btnAddTakingRemainsRequest.Name = "btnAddTakingRemainsRequest";
            this.btnAddTakingRemainsRequest.Size = new System.Drawing.Size(245, 25);
            this.btnAddTakingRemainsRequest.TabIndex = 10;
            this.btnAddTakingRemainsRequest.Text = "Снять остатки по отмеченным строкам";
            this.btnAddTakingRemainsRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTakingRemainsRequest.UseVisualStyleBackColor = true;
            this.btnAddTakingRemainsRequest.Click += new System.EventHandler(this.btnAddTakingRemainsRequest_Click);
            // 
            // chbShowAll
            // 
            this.chbShowAll.AutoSize = true;
            this.chbShowAll.Location = new System.Drawing.Point(633, 19);
            this.chbShowAll.Name = "chbShowAll";
            this.chbShowAll.Size = new System.Drawing.Size(206, 17);
            this.chbShowAll.TabIndex = 20;
            this.chbShowAll.Text = "Показывать все строки накладных";
            this.chbShowAll.UseVisualStyleBackColor = true;
            this.chbShowAll.CheckedChanged += new System.EventHandler(this.chkbShowAll_CheckedChanged);
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
            this.colCheckBox,
            this.invoiceTypeAndNumberDataGridViewTextBoxColumn,
            this.Date_Transfer,
            this.itemidDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.vendorlotDataGridViewTextBoxColumn,
            this.unitPriceDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.termExpDataGridViewTextBoxColumn,
            this.VendorIDAndName,
            this.quantityDataGridViewTextBoxColumn,
            this.invoicenameDataGridViewTextBoxColumn,
            this.invoiceDateDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.vendorManagerDataGridViewTextBoxColumn});
            this.dgvComplaintDetails.DataSource = this.complaintInfoI2BindingSource;
            this.dgvComplaintDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvComplaintDetails.Location = new System.Drawing.Point(3, 88);
            this.dgvComplaintDetails.MultiSelect = false;
            this.dgvComplaintDetails.Name = "dgvComplaintDetails";
            this.dgvComplaintDetails.RowHeadersVisible = false;
            this.dgvComplaintDetails.RowTemplate.Height = 21;
            this.dgvComplaintDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComplaintDetails.ShowEditingIcon = false;
            this.dgvComplaintDetails.Size = new System.Drawing.Size(1089, 204);
            this.dgvComplaintDetails.TabIndex = 30;
            this.dgvComplaintDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvComplaintDetails_KeyDown);
            this.dgvComplaintDetails.SelectionChanged += new System.EventHandler(this.dgvComplaintDetails_SelectionChanged);
            // 
            // complaintInfoI2BindingSource
            // 
            this.complaintInfoI2BindingSource.DataMember = "ComplaintInfoI2";
            this.complaintInfoI2BindingSource.DataSource = this.complaintsExt;
            // 
            // grbTakingRemains
            // 
            this.grbTakingRemains.Controls.Add(this.dgvTakingRemainsResults);
            this.grbTakingRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTakingRemains.Location = new System.Drawing.Point(0, 0);
            this.grbTakingRemains.Name = "grbTakingRemains";
            this.grbTakingRemains.Size = new System.Drawing.Size(1095, 83);
            this.grbTakingRemains.TabIndex = 0;
            this.grbTakingRemains.TabStop = false;
            this.grbTakingRemains.Text = "Результаты снятия остатков";
            // 
            // dgvTakingRemainsResults
            // 
            this.dgvTakingRemainsResults.AllowUserToAddRows = false;
            this.dgvTakingRemainsResults.AllowUserToDeleteRows = false;
            this.dgvTakingRemainsResults.AllowUserToOrderColumns = true;
            this.dgvTakingRemainsResults.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvTakingRemainsResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTakingRemainsResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTakingRemainsResults.AutoGenerateColumns = false;
            this.dgvTakingRemainsResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTakingRemainsResults.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTakingRemainsResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTakingRemainsResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTakingRemainsResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.takingIDDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn1,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.quantityByTakingDataGridViewTextBoxColumn,
            this.quantityByJDDataGridViewTextBoxColumn,
            this.usersUpdatedDataGridViewTextBoxColumn,
            this.dateUpdatedDataGridViewTextBoxColumn,
            this.dateRemainsByJDDataGridViewTextBoxColumn});
            this.dgvTakingRemainsResults.DataSource = this.bsTakingRemains;
            this.dgvTakingRemainsResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTakingRemainsResults.Location = new System.Drawing.Point(3, 19);
            this.dgvTakingRemainsResults.Name = "dgvTakingRemainsResults";
            this.dgvTakingRemainsResults.ReadOnly = true;
            this.dgvTakingRemainsResults.RowHeadersVisible = false;
            this.dgvTakingRemainsResults.RowTemplate.Height = 21;
            this.dgvTakingRemainsResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTakingRemainsResults.ShowEditingIcon = false;
            this.dgvTakingRemainsResults.Size = new System.Drawing.Size(1089, 60);
            this.dgvTakingRemainsResults.TabIndex = 0;
            this.dgvTakingRemainsResults.TabStop = false;
            // 
            // takingIDDataGridViewTextBoxColumn
            // 
            this.takingIDDataGridViewTextBoxColumn.DataPropertyName = "Taking_ID";
            this.takingIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.takingIDDataGridViewTextBoxColumn.Name = "takingIDDataGridViewTextBoxColumn";
            this.takingIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.takingIDDataGridViewTextBoxColumn.Width = 40;
            // 
            // vendorLotDataGridViewTextBoxColumn1
            // 
            this.vendorLotDataGridViewTextBoxColumn1.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn1.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn1.Name = "vendorLotDataGridViewTextBoxColumn1";
            this.vendorLotDataGridViewTextBoxColumn1.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn1.Width = 80;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Created";
            dataGridViewCellStyle5.Format = "g";
            dataGridViewCellStyle5.NullValue = null;
            this.dateCreatedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Время запроса";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreatedDataGridViewTextBoxColumn.Width = 110;
            // 
            // quantityByTakingDataGridViewTextBoxColumn
            // 
            this.quantityByTakingDataGridViewTextBoxColumn.DataPropertyName = "Quantity_By_Taking";
            this.quantityByTakingDataGridViewTextBoxColumn.HeaderText = "К-во рез.";
            this.quantityByTakingDataGridViewTextBoxColumn.Name = "quantityByTakingDataGridViewTextBoxColumn";
            this.quantityByTakingDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityByTakingDataGridViewTextBoxColumn.Width = 80;
            // 
            // quantityByJDDataGridViewTextBoxColumn
            // 
            this.quantityByJDDataGridViewTextBoxColumn.DataPropertyName = "Quantity_By_JD";
            this.quantityByJDDataGridViewTextBoxColumn.HeaderText = "К-во по JD";
            this.quantityByJDDataGridViewTextBoxColumn.Name = "quantityByJDDataGridViewTextBoxColumn";
            this.quantityByJDDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityByJDDataGridViewTextBoxColumn.Width = 85;
            // 
            // usersUpdatedDataGridViewTextBoxColumn
            // 
            this.usersUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Users_Updated";
            this.usersUpdatedDataGridViewTextBoxColumn.HeaderText = "Ввел результат";
            this.usersUpdatedDataGridViewTextBoxColumn.Name = "usersUpdatedDataGridViewTextBoxColumn";
            this.usersUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.usersUpdatedDataGridViewTextBoxColumn.Width = 160;
            // 
            // dateUpdatedDataGridViewTextBoxColumn
            // 
            this.dateUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Updated";
            dataGridViewCellStyle6.Format = "g";
            this.dateUpdatedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.dateUpdatedDataGridViewTextBoxColumn.HeaderText = "Время рез.";
            this.dateUpdatedDataGridViewTextBoxColumn.Name = "dateUpdatedDataGridViewTextBoxColumn";
            this.dateUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateUpdatedDataGridViewTextBoxColumn.Width = 110;
            // 
            // dateRemainsByJDDataGridViewTextBoxColumn
            // 
            this.dateRemainsByJDDataGridViewTextBoxColumn.DataPropertyName = "Date_Remains_By_JD";
            dataGridViewCellStyle7.Format = "g";
            this.dateRemainsByJDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.dateRemainsByJDDataGridViewTextBoxColumn.HeaderText = "Время по JD";
            this.dateRemainsByJDDataGridViewTextBoxColumn.Name = "dateRemainsByJDDataGridViewTextBoxColumn";
            this.dateRemainsByJDDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateRemainsByJDDataGridViewTextBoxColumn.Width = 110;
            // 
            // bsTakingRemains
            // 
            this.bsTakingRemains.DataMember = "TakingRemains";
            this.bsTakingRemains.DataSource = this.complaints;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsChecked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Отм.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ToolTipText = "Отм.";
            this.dataGridViewCheckBoxColumn1.Width = 38;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ItemID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название товара";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Vendor_Lot";
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BatchNumber";
            this.dataGridViewTextBoxColumn4.HeaderText = "Длинная серия";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn5.HeaderText = "К-во";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UnitOfMeasure";
            this.dataGridViewTextBoxColumn6.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "AdressPickList";
            this.dataGridViewTextBoxColumn7.HeaderText = "Адр. сборки";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Cost";
            this.dataGridViewTextBoxColumn8.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Sum";
            this.dataGridViewTextBoxColumn9.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PickListNumber";
            this.dataGridViewTextBoxColumn10.HeaderText = "№ сборочн.";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "AmoutPlaceByPickList";
            this.dataGridViewTextBoxColumn11.HeaderText = "К-во мест сб.";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 75;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ControllerName";
            this.dataGridViewTextBoxColumn12.HeaderText = "Контролер";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ControlBeginDate";
            this.dataGridViewTextBoxColumn13.HeaderText = "Начало контроля";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 75;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ControlEndDate";
            this.dataGridViewTextBoxColumn14.HeaderText = "Окончание контроля";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "ControlLogin";
            this.dataGridViewTextBoxColumn15.HeaderText = "Логин";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 120;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Rout";
            this.dataGridViewTextBoxColumn16.HeaderText = "Маршрут";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 50;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Route_List_Number";
            this.dataGridViewTextBoxColumn17.HeaderText = "№ м.л.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 60;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Route_List_Time_Start";
            this.dataGridViewTextBoxColumn18.HeaderText = "Выезд м.л.";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 50;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Route_List_Drivers";
            this.dataGridViewTextBoxColumn19.HeaderText = "Водители м.л.";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 200;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "ZoneDelivery";
            this.dataGridViewTextBoxColumn20.HeaderText = "Зона дост.";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 60;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "DebtorID";
            this.dataGridViewTextBoxColumn21.HeaderText = "Код деб.";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 60;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "DebtorName";
            this.dataGridViewTextBoxColumn22.HeaderText = "Название дебитора";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 160;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "DeliveryID";
            this.dataGridViewTextBoxColumn23.HeaderText = "Код дост.";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 60;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "DeliveryAddress";
            this.dataGridViewTextBoxColumn24.HeaderText = "Адрес доставки";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 200;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Date_Created";
            this.dataGridViewTextBoxColumn25.HeaderText = "Сохранено";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 60;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Taking_Result";
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn26.HeaderText = "Результат снятия остатков";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "Date_Created";
            this.dataGridViewTextBoxColumn27.HeaderText = "Сохранено";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Width = 200;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Taking_Result";
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn28.HeaderText = "Результат снятия остатков";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn29.DataPropertyName = "Taking_Result";
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn29.HeaderText = "Результат снятия остатков";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "Taking_Result";
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn30.HeaderText = "Результат снятия остатков";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Width = 115;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "DeliveryID";
            this.dataGridViewTextBoxColumn31.HeaderText = "Остаток по JD (на 9 утра)";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Width = 60;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "DeliveryAddress";
            this.dataGridViewTextBoxColumn32.HeaderText = "Адрес доставки";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Width = 200;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Taking_ID";
            this.dataGridViewTextBoxColumn33.HeaderText = "Код";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            this.dataGridViewTextBoxColumn33.Width = 40;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "Vendor_Lot";
            this.dataGridViewTextBoxColumn34.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Width = 80;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "Date_Created";
            dataGridViewCellStyle13.Format = "g";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn35.HeaderText = "Время запроса";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.Width = 110;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "Quantity_By_Taking";
            this.dataGridViewTextBoxColumn36.HeaderText = "К-во рез.";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 80;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn37.DataPropertyName = "Quantity_By_JD";
            this.dataGridViewTextBoxColumn37.HeaderText = "К-во по JD";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn38.DataPropertyName = "Users_Updated";
            this.dataGridViewTextBoxColumn38.HeaderText = "Ввел результат";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "Date_Updated";
            dataGridViewCellStyle14.Format = "g";
            this.dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn39.HeaderText = "Время рез.";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 110;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "Date_Remains_By_JD";
            dataGridViewCellStyle15.Format = "g";
            this.dataGridViewTextBoxColumn40.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn40.HeaderText = "Время по JD";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Width = 110;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "Date_Created";
            dataGridViewCellStyle16.Format = "g";
            dataGridViewCellStyle16.NullValue = null;
            this.dataGridViewTextBoxColumn41.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn41.HeaderText = "Время запроса";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            this.dataGridViewTextBoxColumn41.Width = 110;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "Quantity_By_Taking";
            this.dataGridViewTextBoxColumn42.HeaderText = "К-во рез.";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Width = 80;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "Quantity_By_JD";
            this.dataGridViewTextBoxColumn43.HeaderText = "К-во по JD";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            this.dataGridViewTextBoxColumn43.Width = 85;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "Users_Updated";
            this.dataGridViewTextBoxColumn44.HeaderText = "Ввел результат";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Width = 160;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Date_Updated";
            dataGridViewCellStyle17.Format = "g";
            this.dataGridViewTextBoxColumn45.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn45.HeaderText = "Время рез.";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Width = 110;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.DataPropertyName = "Date_Remains_By_JD";
            dataGridViewCellStyle18.Format = "g";
            this.dataGridViewTextBoxColumn46.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn46.HeaderText = "Время по JD";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            this.dataGridViewTextBoxColumn46.Width = 110;
            // 
            // taTakingRemains
            // 
            this.taTakingRemains.ClearBeforeFill = true;
            // 
            // avaibleComplaintTypesTableAdapter
            // 
            this.avaibleComplaintTypesTableAdapter.ClearBeforeFill = true;
            // 
            // cO_Get_Available_Docs_SubtypesTableAdapter
            // 
            this.cO_Get_Available_Docs_SubtypesTableAdapter.ClearBeforeFill = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(951, 554);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // complaintInfoI2TableAdapter
            // 
            this.complaintInfoI2TableAdapter.ClearBeforeFill = true;
            // 
            // colCheckBox
            // 
            this.colCheckBox.DataPropertyName = "IsChecked";
            this.colCheckBox.HeaderText = "Отм.";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.ToolTipText = "Отм.";
            this.colCheckBox.Width = 38;
            // 
            // invoiceTypeAndNumberDataGridViewTextBoxColumn
            // 
            this.invoiceTypeAndNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceTypeAndNumber";
            this.invoiceTypeAndNumberDataGridViewTextBoxColumn.HeaderText = "Тип, № накладной";
            this.invoiceTypeAndNumberDataGridViewTextBoxColumn.Name = "invoiceTypeAndNumberDataGridViewTextBoxColumn";
            this.invoiceTypeAndNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceTypeAndNumberDataGridViewTextBoxColumn.Width = 90;
            // 
            // Date_Transfer
            // 
            this.Date_Transfer.DataPropertyName = "Date_Transfer";
            this.Date_Transfer.HeaderText = "Дата задания";
            this.Date_Transfer.Name = "Date_Transfer";
            this.Date_Transfer.ReadOnly = true;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Width = 60;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "Item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // vendorlotDataGridViewTextBoxColumn
            // 
            this.vendorlotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_lot";
            this.vendorlotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorlotDataGridViewTextBoxColumn.Name = "vendorlotDataGridViewTextBoxColumn";
            this.vendorlotDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            this.unitPriceDataGridViewTextBoxColumn.DataPropertyName = "Unit_Price";
            this.unitPriceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            this.unitPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitPriceDataGridViewTextBoxColumn.ToolTipText = "Базовая цена";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.ToolTipText = "Базовая цена * кол-во в претензии";
            // 
            // termExpDataGridViewTextBoxColumn
            // 
            this.termExpDataGridViewTextBoxColumn.DataPropertyName = "Term_Exp";
            this.termExpDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.termExpDataGridViewTextBoxColumn.Name = "termExpDataGridViewTextBoxColumn";
            this.termExpDataGridViewTextBoxColumn.ReadOnly = true;
            this.termExpDataGridViewTextBoxColumn.Width = 75;
            // 
            // VendorIDAndName
            // 
            this.VendorIDAndName.DataPropertyName = "VendorIDAndName";
            this.VendorIDAndName.HeaderText = "Поставщик";
            this.VendorIDAndName.Name = "VendorIDAndName";
            this.VendorIDAndName.ReadOnly = true;
            this.VendorIDAndName.Width = 250;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // invoicenameDataGridViewTextBoxColumn
            // 
            this.invoicenameDataGridViewTextBoxColumn.DataPropertyName = "Invoice_name";
            this.invoicenameDataGridViewTextBoxColumn.HeaderText = "Документ поставки";
            this.invoicenameDataGridViewTextBoxColumn.Name = "invoicenameDataGridViewTextBoxColumn";
            this.invoicenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoicenameDataGridViewTextBoxColumn.ToolTipText = "№ внешнего документа поставки";
            this.invoicenameDataGridViewTextBoxColumn.Width = 120;
            // 
            // invoiceDateDataGridViewTextBoxColumn
            // 
            this.invoiceDateDataGridViewTextBoxColumn.DataPropertyName = "Invoice_Date";
            this.invoiceDateDataGridViewTextBoxColumn.HeaderText = "Дата поставки";
            this.invoiceDateDataGridViewTextBoxColumn.Name = "invoiceDateDataGridViewTextBoxColumn";
            this.invoiceDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceDateDataGridViewTextBoxColumn.ToolTipText = "Дата поставки товара";
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorManagerDataGridViewTextBoxColumn
            // 
            this.vendorManagerDataGridViewTextBoxColumn.DataPropertyName = "VendorManager";
            this.vendorManagerDataGridViewTextBoxColumn.HeaderText = "Менеджер ";
            this.vendorManagerDataGridViewTextBoxColumn.Name = "vendorManagerDataGridViewTextBoxColumn";
            this.vendorManagerDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorManagerDataGridViewTextBoxColumn.ToolTipText = "Менеджер отдела закупок";
            this.vendorManagerDataGridViewTextBoxColumn.Width = 200;
            // 
            // ComplaintSupplierDefectAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1119, 589);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.spcTwoTables);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbCommonInfo);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 550);
            this.Name = "ComplaintSupplierDefectAnalysisForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Анализ претензии";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ComplaintAnalysisForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintAnalysisForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComplaintAnalysisForm_KeyDown);
            this.grbCommonInfo.ResumeLayout(false);
            this.grbCommonInfo.PerformLayout();
            this.spcTwoTables.Panel1.ResumeLayout(false);
            this.spcTwoTables.Panel2.ResumeLayout(false);
            this.spcTwoTables.ResumeLayout(false);
            this.grbComplaintDetails.ResumeLayout(false);
            this.grbComplaintDetails.PerformLayout();
            this.gbSupplierDefectOptions.ResumeLayout(false);
            this.gbSupplierDefectOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cOGetAvailableDocsSubtypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avaibleComplaintTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintsExt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaintDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintInfoI2BindingSource)).EndInit();
            this.grbTakingRemains.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakingRemainsResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTakingRemains)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDocIDCaption;
        private System.Windows.Forms.GroupBox grbCommonInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDocTypeCaption;
        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.Label lblCommentCaption;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.Label lblContactNameCaption;
        private System.Windows.Forms.Label lblDocStatus;
        private System.Windows.Forms.Label lblDocStatusCaption;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource bsTakingRemains;
        private WMSOffice.Data.ComplaintsTableAdapters.TakingRemainsTableAdapter taTakingRemains;
        private System.Windows.Forms.SplitContainer spcTwoTables;
        private System.Windows.Forms.GroupBox grbComplaintDetails;
        private System.Windows.Forms.DataGridView dgvComplaintDetails;
        private System.Windows.Forms.GroupBox grbTakingRemains;
        private System.Windows.Forms.DataGridView dgvTakingRemainsResults;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.CheckBox chbShowAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.Button btnAddTakingRemainsRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn takingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityByTakingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityByJDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateRemainsByJDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.TextBox tbxComment;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.Label lblDestCaption;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSourceCaption;
        private System.Windows.Forms.Label lblLinkedComplaintInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.PictureBox pbWait;
        private System.ComponentModel.BackgroundWorker lastWorker;
        private System.Windows.Forms.Button btnAttachmentRequest;
        private System.Windows.Forms.ImageList imgImages;
        private System.Windows.Forms.Button btnVideoControl;
        private System.Windows.Forms.CheckBox cbChangeComplaintType;
        private System.Windows.Forms.ComboBox cmbComplaintTypes;
        private System.Windows.Forms.GroupBox gbSupplierDefectOptions;
        private System.Windows.Forms.Label lblCompensationTypes;
        private System.Windows.Forms.ComboBox cmbCompensationTypes;
        private System.Windows.Forms.Button btnCreateSupplierDefectAct;
        private System.Windows.Forms.BindingSource avaibleComplaintTypesBindingSource;
        private WMSOffice.Data.ComplaintsExt complaintsExt;
        private WMSOffice.Data.ComplaintsExtTableAdapters.AvaibleComplaintTypesTableAdapter avaibleComplaintTypesTableAdapter;
        private System.Windows.Forms.BindingSource cOGetAvailableDocsSubtypesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Get_Available_Docs_SubtypesTableAdapter cO_Get_Available_Docs_SubtypesTableAdapter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource complaintInfoI2BindingSource;
        private WMSOffice.Data.ComplaintsExtTableAdapters.ComplaintInfoI2TableAdapter complaintInfoI2TableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceTypeAndNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Transfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorlotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn termExpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorIDAndName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorManagerDataGridViewTextBoxColumn;
    }
}