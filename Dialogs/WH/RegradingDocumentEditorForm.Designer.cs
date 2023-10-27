namespace WMSOffice.Dialogs.WH
{
    partial class RegradingDocumentEditorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tbBranch = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.stbBranch = new WMSOffice.Controls.SearchTextBox();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.tbBatchNumber = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.tbTransExplanation = new System.Windows.Forms.TextBox();
            this.lblTransExplanation = new System.Windows.Forms.Label();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.lblTransDate = new System.Windows.Forms.Label();
            this.dtpDateGL = new System.Windows.Forms.DateTimePicker();
            this.lblDateGL = new System.Windows.Forms.Label();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.stbDocType = new WMSOffice.Controls.SearchTextBox();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDocDetails = new System.Windows.Forms.DataGridView();
            this.fromToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alphaNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotSerialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extendedAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchPlantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gLDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotGradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotPotencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoLot1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoLot2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotExpirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierLotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSurplusSumValue = new System.Windows.Forms.Label();
            this.lblSurplusSum = new System.Windows.Forms.Label();
            this.lblShortageSumValue = new System.Windows.Forms.Label();
            this.lblShortageSum = new System.Windows.Forms.Label();
            this.hD_DocDetailsTableAdapter = new WMSOffice.Data.WHTableAdapters.HD_DocDetailsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hDDocDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1799, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1889, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 530);
            this.pnlButtons.Size = new System.Drawing.Size(892, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tbBranch);
            this.scMain.Panel1.Controls.Add(this.lblBranch);
            this.scMain.Panel1.Controls.Add(this.stbBranch);
            this.scMain.Panel1.Controls.Add(this.tbCompany);
            this.scMain.Panel1.Controls.Add(this.lblCompany);
            this.scMain.Panel1.Controls.Add(this.tbBatchNumber);
            this.scMain.Panel1.Controls.Add(this.lblBatchNumber);
            this.scMain.Panel1.Controls.Add(this.tbTransExplanation);
            this.scMain.Panel1.Controls.Add(this.lblTransExplanation);
            this.scMain.Panel1.Controls.Add(this.dtpTransDate);
            this.scMain.Panel1.Controls.Add(this.lblTransDate);
            this.scMain.Panel1.Controls.Add(this.dtpDateGL);
            this.scMain.Panel1.Controls.Add(this.lblDateGL);
            this.scMain.Panel1.Controls.Add(this.tbDocType);
            this.scMain.Panel1.Controls.Add(this.lblDocType);
            this.scMain.Panel1.Controls.Add(this.stbDocType);
            this.scMain.Panel1.Controls.Add(this.tbDocNumber);
            this.scMain.Panel1.Controls.Add(this.lblDocNumber);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.panel2);
            this.scMain.Panel2.Controls.Add(this.panel1);
            this.scMain.Size = new System.Drawing.Size(892, 524);
            this.scMain.SplitterDistance = 135;
            this.scMain.TabIndex = 0;
            // 
            // tbBranch
            // 
            this.tbBranch.BackColor = System.Drawing.SystemColors.Window;
            this.tbBranch.Location = new System.Drawing.Point(234, 103);
            this.tbBranch.Name = "tbBranch";
            this.tbBranch.ReadOnly = true;
            this.tbBranch.Size = new System.Drawing.Size(200, 20);
            this.tbBranch.TabIndex = 11;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(20, 107);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(44, 13);
            this.lblBranch.TabIndex = 9;
            this.lblBranch.Text = "Склад::";
            // 
            // stbBranch
            // 
            this.stbBranch.Location = new System.Drawing.Point(128, 103);
            this.stbBranch.Name = "stbBranch";
            this.stbBranch.NavigateByValue = false;
            this.stbBranch.ReadOnly = false;
            this.stbBranch.Size = new System.Drawing.Size(100, 20);
            this.stbBranch.TabIndex = 10;
            this.stbBranch.UserID = ((long)(0));
            this.stbBranch.Value = null;
            this.stbBranch.ValueReferenceQuery = null;
            // 
            // tbCompany
            // 
            this.tbCompany.BackColor = System.Drawing.SystemColors.Window;
            this.tbCompany.Location = new System.Drawing.Point(334, 16);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.ReadOnly = true;
            this.tbCompany.Size = new System.Drawing.Size(100, 20);
            this.tbCompany.TabIndex = 3;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(271, 20);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(57, 13);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "Компанія:";
            // 
            // tbBatchNumber
            // 
            this.tbBatchNumber.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbBatchNumber.Location = new System.Drawing.Point(553, 16);
            this.tbBatchNumber.Name = "tbBatchNumber";
            this.tbBatchNumber.ReadOnly = true;
            this.tbBatchNumber.Size = new System.Drawing.Size(100, 20);
            this.tbBatchNumber.TabIndex = 13;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(467, 20);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(59, 13);
            this.lblBatchNumber.TabIndex = 12;
            this.lblBatchNumber.Text = "№ пакета:";
            // 
            // tbTransExplanation
            // 
            this.tbTransExplanation.Location = new System.Drawing.Point(553, 103);
            this.tbTransExplanation.Name = "tbTransExplanation";
            this.tbTransExplanation.Size = new System.Drawing.Size(306, 20);
            this.tbTransExplanation.TabIndex = 17;
            // 
            // lblTransExplanation
            // 
            this.lblTransExplanation.AutoSize = true;
            this.lblTransExplanation.Location = new System.Drawing.Point(467, 107);
            this.lblTransExplanation.Name = "lblTransExplanation";
            this.lblTransExplanation.Size = new System.Drawing.Size(80, 13);
            this.lblTransExplanation.TabIndex = 16;
            this.lblTransExplanation.Text = "Опис операції:";
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransDate.Location = new System.Drawing.Point(553, 74);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.Size = new System.Drawing.Size(110, 20);
            this.dtpTransDate.TabIndex = 15;
            // 
            // lblTransDate
            // 
            this.lblTransDate.AutoSize = true;
            this.lblTransDate.Location = new System.Drawing.Point(467, 78);
            this.lblTransDate.Name = "lblTransDate";
            this.lblTransDate.Size = new System.Drawing.Size(80, 13);
            this.lblTransDate.TabIndex = 14;
            this.lblTransDate.Text = "Дата операції:";
            // 
            // dtpDateGL
            // 
            this.dtpDateGL.CustomFormat = "dd.MM.yyyy";
            this.dtpDateGL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateGL.Location = new System.Drawing.Point(128, 74);
            this.dtpDateGL.Name = "dtpDateGL";
            this.dtpDateGL.Size = new System.Drawing.Size(100, 20);
            this.dtpDateGL.TabIndex = 8;
            // 
            // lblDateGL
            // 
            this.lblDateGL.AutoSize = true;
            this.lblDateGL.Location = new System.Drawing.Point(20, 78);
            this.lblDateGL.Name = "lblDateGL";
            this.lblDateGL.Size = new System.Drawing.Size(52, 13);
            this.lblDateGL.TabIndex = 7;
            this.lblDateGL.Text = "Дата ГК:";
            // 
            // tbDocType
            // 
            this.tbDocType.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocType.Location = new System.Drawing.Point(234, 45);
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.ReadOnly = true;
            this.tbDocType.Size = new System.Drawing.Size(200, 20);
            this.tbDocType.TabIndex = 6;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(20, 49);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(86, 13);
            this.lblDocType.TabIndex = 4;
            this.lblDocType.Text = "Тип документа:";
            // 
            // stbDocType
            // 
            this.stbDocType.Location = new System.Drawing.Point(128, 45);
            this.stbDocType.Name = "stbDocType";
            this.stbDocType.NavigateByValue = false;
            this.stbDocType.ReadOnly = false;
            this.stbDocType.Size = new System.Drawing.Size(100, 20);
            this.stbDocType.TabIndex = 5;
            this.stbDocType.UserID = ((long)(0));
            this.stbDocType.Value = null;
            this.stbDocType.ValueReferenceQuery = null;
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.BackColor = System.Drawing.SystemColors.Info;
            this.tbDocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDocNumber.Location = new System.Drawing.Point(128, 16);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.ReadOnly = true;
            this.tbDocNumber.Size = new System.Drawing.Size(100, 20);
            this.tbDocNumber.TabIndex = 1;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(20, 20);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(78, 13);
            this.lblDocNumber.TabIndex = 0;
            this.lblDocNumber.Text = "№ документа:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDocDetails);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(892, 320);
            this.panel2.TabIndex = 1;
            // 
            // dgvDocDetails
            // 
            this.dgvDocDetails.AllowUserToAddRows = false;
            this.dgvDocDetails.AllowUserToDeleteRows = false;
            this.dgvDocDetails.AllowUserToResizeRows = false;
            this.dgvDocDetails.AutoGenerateColumns = false;
            this.dgvDocDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fromToDataGridViewTextBoxColumn,
            this.transGroupDataGridViewTextBoxColumn,
            this.itemNumberDataGridViewTextBoxColumn,
            this.itemDescriptionDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.uMDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.alphaNameDataGridViewTextBoxColumn,
            this.lotSerialDataGridViewTextBoxColumn,
            this.unitCostDataGridViewTextBoxColumn,
            this.extendedAmountDataGridViewTextBoxColumn,
            this.branchPlantDataGridViewTextBoxColumn,
            this.gLDateDataGridViewTextBoxColumn,
            this.reasonCodeDataGridViewTextBoxColumn,
            this.lotGradeDataGridViewTextBoxColumn,
            this.lotPotencyDataGridViewTextBoxColumn,
            this.memoLot1DataGridViewTextBoxColumn,
            this.memoLot2DataGridViewTextBoxColumn,
            this.lotStatusDataGridViewTextBoxColumn,
            this.lotExpirationDateDataGridViewTextBoxColumn,
            this.lotDescriptionDataGridViewTextBoxColumn,
            this.supplierLotNumberDataGridViewTextBoxColumn,
            this.outAmountDataGridViewTextBoxColumn,
            this.inAmountDataGridViewTextBoxColumn});
            this.dgvDocDetails.DataSource = this.hDDocDetailsBindingSource;
            this.dgvDocDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDocDetails.MultiSelect = false;
            this.dgvDocDetails.Name = "dgvDocDetails";
            this.dgvDocDetails.RowHeadersVisible = false;
            this.dgvDocDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDocDetails.Size = new System.Drawing.Size(892, 320);
            this.dgvDocDetails.TabIndex = 0;
            // 
            // fromToDataGridViewTextBoxColumn
            // 
            this.fromToDataGridViewTextBoxColumn.DataPropertyName = "From_To";
            this.fromToDataGridViewTextBoxColumn.Frozen = true;
            this.fromToDataGridViewTextBoxColumn.HeaderText = "Звідки /Куди";
            this.fromToDataGridViewTextBoxColumn.Name = "fromToDataGridViewTextBoxColumn";
            this.fromToDataGridViewTextBoxColumn.ReadOnly = true;
            this.fromToDataGridViewTextBoxColumn.Width = 50;
            // 
            // transGroupDataGridViewTextBoxColumn
            // 
            this.transGroupDataGridViewTextBoxColumn.DataPropertyName = "Trans_Group";
            this.transGroupDataGridViewTextBoxColumn.Frozen = true;
            this.transGroupDataGridViewTextBoxColumn.HeaderText = "Номер рядка транзакції";
            this.transGroupDataGridViewTextBoxColumn.Name = "transGroupDataGridViewTextBoxColumn";
            this.transGroupDataGridViewTextBoxColumn.ReadOnly = true;
            this.transGroupDataGridViewTextBoxColumn.Width = 80;
            // 
            // itemNumberDataGridViewTextBoxColumn
            // 
            this.itemNumberDataGridViewTextBoxColumn.DataPropertyName = "Item_Number";
            this.itemNumberDataGridViewTextBoxColumn.Frozen = true;
            this.itemNumberDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemNumberDataGridViewTextBoxColumn.Name = "itemNumberDataGridViewTextBoxColumn";
            this.itemNumberDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemDescriptionDataGridViewTextBoxColumn
            // 
            this.itemDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Item_Description";
            this.itemDescriptionDataGridViewTextBoxColumn.Frozen = true;
            this.itemDescriptionDataGridViewTextBoxColumn.HeaderText = "Найменування товара";
            this.itemDescriptionDataGridViewTextBoxColumn.Name = "itemDescriptionDataGridViewTextBoxColumn";
            this.itemDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDescriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кіль- кість";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 50;
            // 
            // uMDataGridViewTextBoxColumn
            // 
            this.uMDataGridViewTextBoxColumn.DataPropertyName = "UM";
            this.uMDataGridViewTextBoxColumn.HeaderText = "Од. виміру";
            this.uMDataGridViewTextBoxColumn.Name = "uMDataGridViewTextBoxColumn";
            this.uMDataGridViewTextBoxColumn.Width = 50;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Місце";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // alphaNameDataGridViewTextBoxColumn
            // 
            this.alphaNameDataGridViewTextBoxColumn.DataPropertyName = "Alpha_Name";
            this.alphaNameDataGridViewTextBoxColumn.HeaderText = "ПІБ відповідального";
            this.alphaNameDataGridViewTextBoxColumn.Name = "alphaNameDataGridViewTextBoxColumn";
            this.alphaNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // lotSerialDataGridViewTextBoxColumn
            // 
            this.lotSerialDataGridViewTextBoxColumn.DataPropertyName = "Lot_Serial";
            this.lotSerialDataGridViewTextBoxColumn.HeaderText = "Партія";
            this.lotSerialDataGridViewTextBoxColumn.Name = "lotSerialDataGridViewTextBoxColumn";
            this.lotSerialDataGridViewTextBoxColumn.Width = 110;
            // 
            // unitCostDataGridViewTextBoxColumn
            // 
            this.unitCostDataGridViewTextBoxColumn.DataPropertyName = "Unit_Cost";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.unitCostDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.unitCostDataGridViewTextBoxColumn.HeaderText = "Вартість, грн.";
            this.unitCostDataGridViewTextBoxColumn.Name = "unitCostDataGridViewTextBoxColumn";
            this.unitCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitCostDataGridViewTextBoxColumn.Width = 80;
            // 
            // extendedAmountDataGridViewTextBoxColumn
            // 
            this.extendedAmountDataGridViewTextBoxColumn.DataPropertyName = "Extended_Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.extendedAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.extendedAmountDataGridViewTextBoxColumn.HeaderText = "Сума, грн.";
            this.extendedAmountDataGridViewTextBoxColumn.Name = "extendedAmountDataGridViewTextBoxColumn";
            this.extendedAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.extendedAmountDataGridViewTextBoxColumn.Width = 80;
            // 
            // branchPlantDataGridViewTextBoxColumn
            // 
            this.branchPlantDataGridViewTextBoxColumn.DataPropertyName = "Branch_Plant";
            this.branchPlantDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.branchPlantDataGridViewTextBoxColumn.Name = "branchPlantDataGridViewTextBoxColumn";
            this.branchPlantDataGridViewTextBoxColumn.Width = 70;
            // 
            // gLDateDataGridViewTextBoxColumn
            // 
            this.gLDateDataGridViewTextBoxColumn.DataPropertyName = "GL_Date";
            this.gLDateDataGridViewTextBoxColumn.HeaderText = "Дата ГК";
            this.gLDateDataGridViewTextBoxColumn.Name = "gLDateDataGridViewTextBoxColumn";
            this.gLDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.gLDateDataGridViewTextBoxColumn.Width = 80;
            // 
            // reasonCodeDataGridViewTextBoxColumn
            // 
            this.reasonCodeDataGridViewTextBoxColumn.DataPropertyName = "Reason_Code";
            this.reasonCodeDataGridViewTextBoxColumn.HeaderText = "Код причини";
            this.reasonCodeDataGridViewTextBoxColumn.Name = "reasonCodeDataGridViewTextBoxColumn";
            this.reasonCodeDataGridViewTextBoxColumn.Width = 60;
            // 
            // lotGradeDataGridViewTextBoxColumn
            // 
            this.lotGradeDataGridViewTextBoxColumn.DataPropertyName = "Lot_Grade";
            this.lotGradeDataGridViewTextBoxColumn.HeaderText = "Сорт партії";
            this.lotGradeDataGridViewTextBoxColumn.Name = "lotGradeDataGridViewTextBoxColumn";
            this.lotGradeDataGridViewTextBoxColumn.Width = 50;
            // 
            // lotPotencyDataGridViewTextBoxColumn
            // 
            this.lotPotencyDataGridViewTextBoxColumn.DataPropertyName = "Lot_Potency";
            this.lotPotencyDataGridViewTextBoxColumn.HeaderText = "Ефективність партії";
            this.lotPotencyDataGridViewTextBoxColumn.Name = "lotPotencyDataGridViewTextBoxColumn";
            this.lotPotencyDataGridViewTextBoxColumn.Width = 80;
            // 
            // memoLot1DataGridViewTextBoxColumn
            // 
            this.memoLot1DataGridViewTextBoxColumn.DataPropertyName = "Memo_Lot_1";
            this.memoLot1DataGridViewTextBoxColumn.HeaderText = "Примітка партії 1";
            this.memoLot1DataGridViewTextBoxColumn.Name = "memoLot1DataGridViewTextBoxColumn";
            // 
            // memoLot2DataGridViewTextBoxColumn
            // 
            this.memoLot2DataGridViewTextBoxColumn.DataPropertyName = "Memo_Lot_2";
            this.memoLot2DataGridViewTextBoxColumn.HeaderText = "Примітка партії 2";
            this.memoLot2DataGridViewTextBoxColumn.Name = "memoLot2DataGridViewTextBoxColumn";
            // 
            // lotStatusDataGridViewTextBoxColumn
            // 
            this.lotStatusDataGridViewTextBoxColumn.DataPropertyName = "Lot_Status";
            this.lotStatusDataGridViewTextBoxColumn.HeaderText = "Код блоку- вання партії";
            this.lotStatusDataGridViewTextBoxColumn.Name = "lotStatusDataGridViewTextBoxColumn";
            // 
            // lotExpirationDateDataGridViewTextBoxColumn
            // 
            this.lotExpirationDateDataGridViewTextBoxColumn.DataPropertyName = "Lot_Expiration_Date";
            this.lotExpirationDateDataGridViewTextBoxColumn.HeaderText = "Термін придатності";
            this.lotExpirationDateDataGridViewTextBoxColumn.Name = "lotExpirationDateDataGridViewTextBoxColumn";
            this.lotExpirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotExpirationDateDataGridViewTextBoxColumn.Width = 90;
            // 
            // lotDescriptionDataGridViewTextBoxColumn
            // 
            this.lotDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Lot_Description";
            this.lotDescriptionDataGridViewTextBoxColumn.HeaderText = "Опис партії";
            this.lotDescriptionDataGridViewTextBoxColumn.Name = "lotDescriptionDataGridViewTextBoxColumn";
            this.lotDescriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // supplierLotNumberDataGridViewTextBoxColumn
            // 
            this.supplierLotNumberDataGridViewTextBoxColumn.DataPropertyName = "Supplier_Lot_Number";
            this.supplierLotNumberDataGridViewTextBoxColumn.HeaderText = "Серія";
            this.supplierLotNumberDataGridViewTextBoxColumn.Name = "supplierLotNumberDataGridViewTextBoxColumn";
            // 
            // outAmountDataGridViewTextBoxColumn
            // 
            this.outAmountDataGridViewTextBoxColumn.DataPropertyName = "OutAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.outAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.outAmountDataGridViewTextBoxColumn.HeaderText = "Списання, грн.";
            this.outAmountDataGridViewTextBoxColumn.Name = "outAmountDataGridViewTextBoxColumn";
            this.outAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.outAmountDataGridViewTextBoxColumn.Width = 110;
            // 
            // inAmountDataGridViewTextBoxColumn
            // 
            this.inAmountDataGridViewTextBoxColumn.DataPropertyName = "InAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.inAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.inAmountDataGridViewTextBoxColumn.HeaderText = "Прихід, грн.";
            this.inAmountDataGridViewTextBoxColumn.Name = "inAmountDataGridViewTextBoxColumn";
            this.inAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.inAmountDataGridViewTextBoxColumn.Width = 110;
            // 
            // hDDocDetailsBindingSource
            // 
            this.hDDocDetailsBindingSource.DataMember = "HD_DocDetails";
            this.hDDocDetailsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblSurplusSumValue);
            this.panel1.Controls.Add(this.lblSurplusSum);
            this.panel1.Controls.Add(this.lblShortageSumValue);
            this.panel1.Controls.Add(this.lblShortageSum);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 65);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(550, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(467, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Різниця, грн:";
            // 
            // lblSurplusSumValue
            // 
            this.lblSurplusSumValue.AutoSize = true;
            this.lblSurplusSumValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSurplusSumValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSurplusSumValue.Location = new System.Drawing.Point(128, 40);
            this.lblSurplusSumValue.Name = "lblSurplusSumValue";
            this.lblSurplusSumValue.Size = new System.Drawing.Size(14, 13);
            this.lblSurplusSumValue.TabIndex = 3;
            this.lblSurplusSumValue.Text = "0";
            // 
            // lblSurplusSum
            // 
            this.lblSurplusSum.AutoSize = true;
            this.lblSurplusSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSurplusSum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSurplusSum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSurplusSum.Location = new System.Drawing.Point(20, 40);
            this.lblSurplusSum.Name = "lblSurplusSum";
            this.lblSurplusSum.Size = new System.Drawing.Size(102, 13);
            this.lblSurplusSum.TabIndex = 2;
            this.lblSurplusSum.Text = "Надходження, грн:";
            // 
            // lblShortageSumValue
            // 
            this.lblShortageSumValue.AutoSize = true;
            this.lblShortageSumValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShortageSumValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblShortageSumValue.Location = new System.Drawing.Point(128, 11);
            this.lblShortageSumValue.Name = "lblShortageSumValue";
            this.lblShortageSumValue.Size = new System.Drawing.Size(14, 13);
            this.lblShortageSumValue.TabIndex = 1;
            this.lblShortageSumValue.Text = "0";
            // 
            // lblShortageSum
            // 
            this.lblShortageSum.AutoSize = true;
            this.lblShortageSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShortageSum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblShortageSum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblShortageSum.Location = new System.Drawing.Point(20, 11);
            this.lblShortageSum.Name = "lblShortageSum";
            this.lblShortageSum.Size = new System.Drawing.Size(82, 13);
            this.lblShortageSum.TabIndex = 0;
            this.lblShortageSum.Text = "Списання, грн:";
            // 
            // hD_DocDetailsTableAdapter
            // 
            this.hD_DocDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // RegradingDocumentEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 573);
            this.Controls.Add(this.scMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "RegradingDocumentEditorForm";
            this.Text = "Редактор пересорта";
            this.Controls.SetChildIndex(this.scMain, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hDDocDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.DateTimePicker dtpDateGL;
        private System.Windows.Forms.Label lblDateGL;
        private System.Windows.Forms.TextBox tbDocType;
        private System.Windows.Forms.Label lblDocType;
        private WMSOffice.Controls.SearchTextBox stbDocType;
        private System.Windows.Forms.DateTimePicker dtpTransDate;
        private System.Windows.Forms.Label lblTransDate;
        private System.Windows.Forms.TextBox tbTransExplanation;
        private System.Windows.Forms.Label lblTransExplanation;
        private System.Windows.Forms.TextBox tbBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.TextBox tbBranch;
        private System.Windows.Forms.Label lblBranch;
        private WMSOffice.Controls.SearchTextBox stbBranch;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDocDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource hDDocDetailsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.HD_DocDetailsTableAdapter hD_DocDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alphaNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotSerialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extendedAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchPlantDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gLDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotGradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotPotencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoLot1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoLot2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotExpirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierLotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblSurplusSumValue;
        private System.Windows.Forms.Label lblSurplusSum;
        private System.Windows.Forms.Label lblShortageSumValue;
        private System.Windows.Forms.Label lblShortageSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}