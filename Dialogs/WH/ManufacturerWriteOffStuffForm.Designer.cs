namespace WMSOffice.Dialogs.WH
{
    partial class ManufacturerWriteOffStuffForm
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
            this.panelInfo = new System.Windows.Forms.Panel();
            this.dtpDocDate = new System.Windows.Forms.DateTimePicker();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.cmbInventory = new System.Windows.Forms.ComboBox();
            this.bsWfGetInventarizationList = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.lblInventory = new System.Windows.Forms.Label();
            this.cmbJDE = new System.Windows.Forms.ComboBox();
            this.bsWfGetJDEDocTypes = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbApprover = new System.Windows.Forms.ComboBox();
            this.bsWfGetApproverList = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.bsWfGetDocTypes = new System.Windows.Forms.BindingSource(this.components);
            this.lblDocType = new System.Windows.Forms.Label();
            this.cmbWarehouses = new System.Windows.Forms.ComboBox();
            this.bsWfGetWarehouseList = new System.Windows.Forms.BindingSource(this.components);
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.tbxID = new System.Windows.Forms.TextBox();
            this.lblDocId = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBoxLines = new System.Windows.Forms.GroupBox();
            this.dgvDocLines = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnRemoveFromDoc = new System.Windows.Forms.Button();
            this.btnAddToDoc = new System.Windows.Forms.Button();
            this.groupBoxRemains = new System.Windows.Forms.GroupBox();
            this.dgvRemains = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.bsWfGetDocsDetail = new System.Windows.Forms.BindingSource(this.components);
            this.taWfGetDocsDetail = new WMSOffice.Data.WHTableAdapters.WF_GetDocs_DetailTableAdapter();
            this.taWfGetWarehouseList = new WMSOffice.Data.WHTableAdapters.WF_GetWarehouseListTableAdapter();
            this.taWfGetDocTypes = new WMSOffice.Data.WHTableAdapters.WF_GetDocTypesTableAdapter();
            this.taWfGetApproverList = new WMSOffice.Data.WHTableAdapters.WF_GetApproverListTableAdapter();
            this.taWfGetJDEDocTypes = new WMSOffice.Data.WHTableAdapters.WF_GetJDEDocTypesTableAdapter();
            this.taWfGetInventarizationList = new WMSOffice.Data.WHTableAdapters.WF_GetInventarizationListTableAdapter();
            this.pbWait = new System.Windows.Forms.PictureBox();
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
            this.cbForeignCurrency = new System.Windows.Forms.CheckBox();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetInventarizationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetJDEDocTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetApproverList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetWarehouseList)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBoxLines.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.groupBoxRemains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocsDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.cbForeignCurrency);
            this.panelInfo.Controls.Add(this.dtpDocDate);
            this.panelInfo.Controls.Add(this.lblDocDate);
            this.panelInfo.Controls.Add(this.cmbInventory);
            this.panelInfo.Controls.Add(this.lblInventory);
            this.panelInfo.Controls.Add(this.cmbJDE);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.cmbApprover);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Controls.Add(this.tbxDescription);
            this.panelInfo.Controls.Add(this.lblDescription);
            this.panelInfo.Controls.Add(this.cmbDocType);
            this.panelInfo.Controls.Add(this.lblDocType);
            this.panelInfo.Controls.Add(this.cmbWarehouses);
            this.panelInfo.Controls.Add(this.lblWarehouse);
            this.panelInfo.Controls.Add(this.tbxID);
            this.panelInfo.Controls.Add(this.lblDocId);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(1008, 104);
            this.panelInfo.TabIndex = 0;
            // 
            // dtpDocDate
            // 
            this.dtpDocDate.Enabled = false;
            this.dtpDocDate.Location = new System.Drawing.Point(80, 77);
            this.dtpDocDate.Name = "dtpDocDate";
            this.dtpDocDate.Size = new System.Drawing.Size(139, 20);
            this.dtpDocDate.TabIndex = 57;
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Location = new System.Drawing.Point(12, 81);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(36, 13);
            this.lblDocDate.TabIndex = 56;
            this.lblDocDate.Text = "Дата:";
            // 
            // cmbInventory
            // 
            this.cmbInventory.DataSource = this.bsWfGetInventarizationList;
            this.cmbInventory.DisplayMember = "Description";
            this.cmbInventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventory.DropDownWidth = 350;
            this.cmbInventory.Enabled = false;
            this.cmbInventory.FormattingEnabled = true;
            this.cmbInventory.Location = new System.Drawing.Point(505, 77);
            this.cmbInventory.Name = "cmbInventory";
            this.cmbInventory.Size = new System.Drawing.Size(292, 21);
            this.cmbInventory.TabIndex = 55;
            this.cmbInventory.ValueMember = "Inventory_ID";
            // 
            // bsWfGetInventarizationList
            // 
            this.bsWfGetInventarizationList.DataMember = "WF_GetInventarizationList";
            this.bsWfGetInventarizationList.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Location = new System.Drawing.Point(392, 81);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(95, 13);
            this.lblInventory.TabIndex = 54;
            this.lblInventory.Text = "Инвентаризация:";
            // 
            // cmbJDE
            // 
            this.cmbJDE.DataSource = this.bsWfGetJDEDocTypes;
            this.cmbJDE.DisplayMember = "Desc";
            this.cmbJDE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJDE.Enabled = false;
            this.cmbJDE.FormattingEnabled = true;
            this.cmbJDE.Location = new System.Drawing.Point(505, 52);
            this.cmbJDE.Name = "cmbJDE";
            this.cmbJDE.Size = new System.Drawing.Size(292, 21);
            this.cmbJDE.TabIndex = 53;
            this.cmbJDE.ValueMember = "DocType";
            // 
            // bsWfGetJDEDocTypes
            // 
            this.bsWfGetJDEDocTypes.DataMember = "WF_GetJDEDocTypes";
            this.bsWfGetJDEDocTypes.DataSource = this.wH;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Тип документа JDE:";
            // 
            // cmbApprover
            // 
            this.cmbApprover.DataSource = this.bsWfGetApproverList;
            this.cmbApprover.DisplayMember = "Approver";
            this.cmbApprover.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApprover.Enabled = false;
            this.cmbApprover.FormattingEnabled = true;
            this.cmbApprover.Location = new System.Drawing.Point(80, 52);
            this.cmbApprover.Name = "cmbApprover";
            this.cmbApprover.Size = new System.Drawing.Size(272, 21);
            this.cmbApprover.TabIndex = 51;
            this.cmbApprover.ValueMember = "Approver_ID";
            // 
            // bsWfGetApproverList
            // 
            this.bsWfGetApproverList.DataMember = "WF_GetApproverList";
            this.bsWfGetApproverList.DataSource = this.wH;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Сотрудник:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Enabled = false;
            this.tbxDescription.Location = new System.Drawing.Point(505, 5);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(292, 20);
            this.tbxDescription.TabIndex = 49;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(392, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 48;
            this.lblDescription.Text = "Описание:";
            // 
            // cmbDocType
            // 
            this.cmbDocType.DataSource = this.bsWfGetDocTypes;
            this.cmbDocType.DisplayMember = "Desc";
            this.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocType.Enabled = false;
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Location = new System.Drawing.Point(505, 28);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(292, 21);
            this.cmbDocType.TabIndex = 47;
            this.cmbDocType.ValueMember = "DocType";
            // 
            // bsWfGetDocTypes
            // 
            this.bsWfGetDocTypes.DataMember = "WF_GetDocTypes";
            this.bsWfGetDocTypes.DataSource = this.wH;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(392, 32);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(80, 13);
            this.lblDocType.TabIndex = 46;
            this.lblDocType.Text = "Вид списания:";
            // 
            // cmbWarehouses
            // 
            this.cmbWarehouses.DataSource = this.bsWfGetWarehouseList;
            this.cmbWarehouses.DisplayMember = "Warehouse_DSC";
            this.cmbWarehouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouses.Enabled = false;
            this.cmbWarehouses.FormattingEnabled = true;
            this.cmbWarehouses.Location = new System.Drawing.Point(80, 28);
            this.cmbWarehouses.Name = "cmbWarehouses";
            this.cmbWarehouses.Size = new System.Drawing.Size(272, 21);
            this.cmbWarehouses.TabIndex = 45;
            this.cmbWarehouses.ValueMember = "Warehouse_ID";
            // 
            // bsWfGetWarehouseList
            // 
            this.bsWfGetWarehouseList.DataMember = "WF_GetWarehouseList";
            this.bsWfGetWarehouseList.DataSource = this.wH;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 32);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse.TabIndex = 44;
            this.lblWarehouse.Text = "Склад:";
            // 
            // tbxID
            // 
            this.tbxID.Enabled = false;
            this.tbxID.Location = new System.Drawing.Point(80, 5);
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(108, 20);
            this.tbxID.TabIndex = 43;
            // 
            // lblDocId
            // 
            this.lblDocId.AutoSize = true;
            this.lblDocId.Location = new System.Drawing.Point(12, 9);
            this.lblDocId.Name = "lblDocId";
            this.lblDocId.Size = new System.Drawing.Size(56, 13);
            this.lblDocId.TabIndex = 42;
            this.lblDocId.Text = "ID док-та:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 614);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1008, 32);
            this.panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(849, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(930, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Отмена";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 104);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBoxLines);
            this.splitContainer.Panel1.Controls.Add(this.panelCommands);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBoxRemains);
            this.splitContainer.Size = new System.Drawing.Size(1008, 510);
            this.splitContainer.SplitterDistance = 323;
            this.splitContainer.TabIndex = 2;
            // 
            // groupBoxLines
            // 
            this.groupBoxLines.Controls.Add(this.dgvDocLines);
            this.groupBoxLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLines.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLines.Name = "groupBoxLines";
            this.groupBoxLines.Size = new System.Drawing.Size(1008, 287);
            this.groupBoxLines.TabIndex = 2;
            this.groupBoxLines.TabStop = false;
            this.groupBoxLines.Text = "Товары для списания";
            // 
            // dgvDocLines
            // 
            this.dgvDocLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvDocLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocLines.LargeAmountOfData = true;
            this.dgvDocLines.Location = new System.Drawing.Point(3, 16);
            this.dgvDocLines.Name = "dgvDocLines";
            this.dgvDocLines.RowHeadersVisible = false;
            this.dgvDocLines.Size = new System.Drawing.Size(1002, 268);
            this.dgvDocLines.TabIndex = 1;
            this.dgvDocLines.UserID = ((long)(0));
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnRemoveFromDoc);
            this.panelCommands.Controls.Add(this.btnAddToDoc);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 287);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(1008, 36);
            this.panelCommands.TabIndex = 0;
            // 
            // btnRemoveFromDoc
            // 
            this.btnRemoveFromDoc.Enabled = false;
            this.btnRemoveFromDoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveFromDoc.Image = global::WMSOffice.Properties.Resources.up;
            this.btnRemoveFromDoc.Location = new System.Drawing.Point(40, 2);
            this.btnRemoveFromDoc.Name = "btnRemoveFromDoc";
            this.btnRemoveFromDoc.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnRemoveFromDoc.Size = new System.Drawing.Size(32, 32);
            this.btnRemoveFromDoc.TabIndex = 4;
            this.btnRemoveFromDoc.UseVisualStyleBackColor = true;
            this.btnRemoveFromDoc.Click += new System.EventHandler(this.btnRemoveFromDoc_Click);
            // 
            // btnAddToDoc
            // 
            this.btnAddToDoc.Enabled = false;
            this.btnAddToDoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddToDoc.Image = global::WMSOffice.Properties.Resources.down;
            this.btnAddToDoc.Location = new System.Drawing.Point(3, 2);
            this.btnAddToDoc.Name = "btnAddToDoc";
            this.btnAddToDoc.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnAddToDoc.Size = new System.Drawing.Size(32, 32);
            this.btnAddToDoc.TabIndex = 3;
            this.btnAddToDoc.UseVisualStyleBackColor = true;
            this.btnAddToDoc.Click += new System.EventHandler(this.btnAddToDoc_Click);
            // 
            // groupBoxRemains
            // 
            this.groupBoxRemains.Controls.Add(this.dgvRemains);
            this.groupBoxRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRemains.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRemains.Name = "groupBoxRemains";
            this.groupBoxRemains.Size = new System.Drawing.Size(1008, 183);
            this.groupBoxRemains.TabIndex = 2;
            this.groupBoxRemains.TabStop = false;
            this.groupBoxRemains.Text = "Списание поставщиком";
            // 
            // dgvRemains
            // 
            this.dgvRemains.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRemains.LargeAmountOfData = true;
            this.dgvRemains.Location = new System.Drawing.Point(3, 16);
            this.dgvRemains.Name = "dgvRemains";
            this.dgvRemains.RowHeadersVisible = false;
            this.dgvRemains.Size = new System.Drawing.Size(1002, 164);
            this.dgvRemains.TabIndex = 1;
            this.dgvRemains.UserID = ((long)(0));
            // 
            // bsWfGetDocsDetail
            // 
            this.bsWfGetDocsDetail.DataMember = "WF_GetDocs_Detail";
            this.bsWfGetDocsDetail.DataSource = this.wH;
            // 
            // taWfGetDocsDetail
            // 
            this.taWfGetDocsDetail.ClearBeforeFill = true;
            // 
            // taWfGetWarehouseList
            // 
            this.taWfGetWarehouseList.ClearBeforeFill = true;
            // 
            // taWfGetDocTypes
            // 
            this.taWfGetDocTypes.ClearBeforeFill = true;
            // 
            // taWfGetApproverList
            // 
            this.taWfGetApproverList.ClearBeforeFill = true;
            // 
            // taWfGetJDEDocTypes
            // 
            this.taWfGetJDEDocTypes.ClearBeforeFill = true;
            // 
            // taWfGetInventarizationList
            // 
            this.taWfGetInventarizationList.ClearBeforeFill = true;
            // 
            // pbWait
            // 
            this.pbWait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbWait.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbWait.Location = new System.Drawing.Point(454, 272);
            this.pbWait.Name = "pbWait";
            this.pbWait.Size = new System.Drawing.Size(100, 102);
            this.pbWait.TabIndex = 3;
            this.pbWait.TabStop = false;
            this.pbWait.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Line_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Location_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Место";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ID товара";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item";
            this.dataGridViewTextBoxColumn4.HeaderText = "Наименование товара";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn5.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "VAT";
            this.dataGridViewTextBoxColumn6.HeaderText = "НДС";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Lot_Number";
            this.dataGridViewTextBoxColumn7.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Batch_ID";
            this.dataGridViewTextBoxColumn8.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ExpirationDate";
            this.dataGridViewTextBoxColumn9.HeaderText = "Срок годности";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn10.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "UOM";
            this.dataGridViewTextBoxColumn11.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Amount_UAH";
            this.dataGridViewTextBoxColumn12.HeaderText = "Цена всего";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn13.HeaderText = "Цена за шт.";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "LotStatus";
            this.dataGridViewTextBoxColumn14.HeaderText = "Код задержки";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "MOZ";
            this.dataGridViewTextBoxColumn15.HeaderText = "МОЗ";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Vendor";
            this.dataGridViewTextBoxColumn16.HeaderText = "Поставщик";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // cbForeignCurrency
            // 
            this.cbForeignCurrency.AutoSize = true;
            this.cbForeignCurrency.Location = new System.Drawing.Point(837, 7);
            this.cbForeignCurrency.Name = "cbForeignCurrency";
            this.cbForeignCurrency.Size = new System.Drawing.Size(141, 17);
            this.cbForeignCurrency.TabIndex = 58;
            this.cbForeignCurrency.Text = "В иностранной валюте";
            this.cbForeignCurrency.UseVisualStyleBackColor = true;
            // 
            // ManufacturerWriteOffStuffForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1008, 646);
            this.Controls.Add(this.pbWait);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ManufacturerWriteOffStuffForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Списание производителя";
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetInventarizationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetJDEDocTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetApproverList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetWarehouseList)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.groupBoxLines.ResumeLayout(false);
            this.panelCommands.ResumeLayout(false);
            this.groupBoxRemains.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocsDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.DateTimePicker dtpDocDate;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.ComboBox cmbInventory;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.ComboBox cmbJDE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbApprover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.ComboBox cmbWarehouses;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.Label lblDocId;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
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
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvDocLines;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvRemains;
        private System.Windows.Forms.BindingSource bsWfGetDocsDetail;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.WF_GetDocs_DetailTableAdapter taWfGetDocsDetail;
        private System.Windows.Forms.BindingSource bsWfGetWarehouseList;
        private WMSOffice.Data.WHTableAdapters.WF_GetWarehouseListTableAdapter taWfGetWarehouseList;
        private System.Windows.Forms.BindingSource bsWfGetDocTypes;
        private WMSOffice.Data.WHTableAdapters.WF_GetDocTypesTableAdapter taWfGetDocTypes;
        private System.Windows.Forms.BindingSource bsWfGetApproverList;
        private WMSOffice.Data.WHTableAdapters.WF_GetApproverListTableAdapter taWfGetApproverList;
        private System.Windows.Forms.BindingSource bsWfGetJDEDocTypes;
        private WMSOffice.Data.WHTableAdapters.WF_GetJDEDocTypesTableAdapter taWfGetJDEDocTypes;
        private System.Windows.Forms.BindingSource bsWfGetInventarizationList;
        private WMSOffice.Data.WHTableAdapters.WF_GetInventarizationListTableAdapter taWfGetInventarizationList;
        private System.Windows.Forms.PictureBox pbWait;
        private System.Windows.Forms.GroupBox groupBoxLines;
        private System.Windows.Forms.GroupBox groupBoxRemains;
        private System.Windows.Forms.Button btnRemoveFromDoc;
        private System.Windows.Forms.Button btnAddToDoc;
        private System.Windows.Forms.CheckBox cbForeignCurrency;

    }
}