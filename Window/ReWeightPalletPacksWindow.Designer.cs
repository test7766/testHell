namespace WMSOffice.Window
{
    partial class ReWeightPalletPacksWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblItemNameValue = new System.Windows.Forms.Label();
            this.tbsItemBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.lblItemBarcode = new System.Windows.Forms.Label();
            this.lblItemID_ = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlDoc = new System.Windows.Forms.Panel();
            this.scDocItems = new System.Windows.Forms.SplitContainer();
            this.dgvDocItems = new System.Windows.Forms.DataGridView();
            this.itmIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itmNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.System_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fact_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reWeighingDocItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.dgvDocItemsWeighingLog = new System.Windows.Forms.DataGridView();
            this.stagenumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yLBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reWeighingDocItemStepsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDocHeader = new System.Windows.Forms.Panel();
            this.dgvDocHeader = new System.Windows.Forms.DataGridView();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paletweightemptynewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paletweightfullplanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paletweightfullfactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paletweightemptyoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pWCCheckRoomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.pWC_CheckRoomTableAdapter = new WMSOffice.Data.WHTableAdapters.PWC_CheckRoomTableAdapter();
            this.reWeighingDocItemsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.ReWeighingDocItemsTableAdapter();
            this.reWeighingDocItemStepsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.ReWeighingDocItemStepsTableAdapter();
            this.tsMain.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDoc.SuspendLayout();
            this.scDocItems.Panel1.SuspendLayout();
            this.scDocItems.Panel2.SuspendLayout();
            this.scDocItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reWeighingDocItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocItemsWeighingLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reWeighingDocItemStepsBindingSource)).BeginInit();
            this.pnlDocHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWCCheckRoomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnCloseDoc});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1367, 39);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 36);
            this.btnRefresh.Text = "Обновить\nдокумент";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(95, 36);
            this.btnCloseDoc.Text = "Закрыть\nдокумент";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblItemNameValue);
            this.pnlSearch.Controls.Add(this.tbsItemBarcode);
            this.pnlSearch.Controls.Add(this.stbItemID);
            this.pnlSearch.Controls.Add(this.lblItemBarcode);
            this.pnlSearch.Controls.Add(this.lblItemID_);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1367, 35);
            this.pnlSearch.TabIndex = 3;
            // 
            // lblItemNameValue
            // 
            this.lblItemNameValue.AutoSize = true;
            this.lblItemNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemNameValue.Location = new System.Drawing.Point(382, 11);
            this.lblItemNameValue.Name = "lblItemNameValue";
            this.lblItemNameValue.Size = new System.Drawing.Size(0, 13);
            this.lblItemNameValue.TabIndex = 4;
            // 
            // tbsItemBarcode
            // 
            this.tbsItemBarcode.AllowType = true;
            this.tbsItemBarcode.AutoConvert = true;
            this.tbsItemBarcode.DelayThreshold = 50;
            this.tbsItemBarcode.Location = new System.Drawing.Point(52, 5);
            this.tbsItemBarcode.Name = "tbsItemBarcode";
            this.tbsItemBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbsItemBarcode.ReadOnly = false;
            this.tbsItemBarcode.Size = new System.Drawing.Size(180, 25);
            this.tbsItemBarcode.TabIndex = 1;
            this.tbsItemBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsItemBarcode.UseParentFont = false;
            this.tbsItemBarcode.UseScanModeOnly = false;
            // 
            // stbItemID
            // 
            this.stbItemID.Location = new System.Drawing.Point(276, 7);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.ReadOnly = false;
            this.stbItemID.Size = new System.Drawing.Size(100, 20);
            this.stbItemID.TabIndex = 3;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.Location = new System.Drawing.Point(12, 11);
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.Size = new System.Drawing.Size(34, 13);
            this.lblItemBarcode.TabIndex = 0;
            this.lblItemBarcode.Text = "Ш/К :";
            // 
            // lblItemID_
            // 
            this.lblItemID_.AutoSize = true;
            this.lblItemID_.Location = new System.Drawing.Point(238, 11);
            this.lblItemID_.Name = "lblItemID_";
            this.lblItemID_.Size = new System.Drawing.Size(32, 13);
            this.lblItemID_.TabIndex = 2;
            this.lblItemID_.Text = "Код :";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlDoc);
            this.pnlContent.Controls.Add(this.pnlSearch);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 79);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1367, 450);
            this.pnlContent.TabIndex = 4;
            // 
            // pnlDoc
            // 
            this.pnlDoc.Controls.Add(this.scDocItems);
            this.pnlDoc.Controls.Add(this.pnlDocHeader);
            this.pnlDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDoc.Location = new System.Drawing.Point(0, 35);
            this.pnlDoc.Name = "pnlDoc";
            this.pnlDoc.Size = new System.Drawing.Size(1367, 415);
            this.pnlDoc.TabIndex = 4;
            // 
            // scDocItems
            // 
            this.scDocItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDocItems.Location = new System.Drawing.Point(0, 60);
            this.scDocItems.Name = "scDocItems";
            // 
            // scDocItems.Panel1
            // 
            this.scDocItems.Panel1.Controls.Add(this.dgvDocItems);
            // 
            // scDocItems.Panel2
            // 
            this.scDocItems.Panel2.Controls.Add(this.dgvDocItemsWeighingLog);
            this.scDocItems.Size = new System.Drawing.Size(1367, 355);
            this.scDocItems.SplitterDistance = 1049;
            this.scDocItems.TabIndex = 4;
            // 
            // dgvDocItems
            // 
            this.dgvDocItems.AllowUserToAddRows = false;
            this.dgvDocItems.AllowUserToDeleteRows = false;
            this.dgvDocItems.AllowUserToResizeRows = false;
            this.dgvDocItems.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itmIdDataGridViewTextBoxColumn,
            this.itmNameDataGridViewTextBoxColumn,
            this.manufDataGridViewTextBoxColumn,
            this.vendorDataGridViewTextBoxColumn,
            this.System_Weight,
            this.min_Weight,
            this.max_Weight,
            this.Fact_Weight});
            this.dgvDocItems.DataSource = this.reWeighingDocItemsBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocItems.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocItems.Location = new System.Drawing.Point(0, 0);
            this.dgvDocItems.MultiSelect = false;
            this.dgvDocItems.Name = "dgvDocItems";
            this.dgvDocItems.ReadOnly = true;
            this.dgvDocItems.RowHeadersVisible = false;
            this.dgvDocItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocItems.Size = new System.Drawing.Size(1049, 355);
            this.dgvDocItems.TabIndex = 0;
            this.dgvDocItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocItems_CellFormatting);
            this.dgvDocItems.SelectionChanged += new System.EventHandler(this.dgvDocItems_SelectionChanged);
            // 
            // itmIdDataGridViewTextBoxColumn
            // 
            this.itmIdDataGridViewTextBoxColumn.DataPropertyName = "Itm_Id";
            this.itmIdDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itmIdDataGridViewTextBoxColumn.Name = "itmIdDataGridViewTextBoxColumn";
            this.itmIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmIdDataGridViewTextBoxColumn.Width = 70;
            // 
            // itmNameDataGridViewTextBoxColumn
            // 
            this.itmNameDataGridViewTextBoxColumn.DataPropertyName = "Itm_Name";
            this.itmNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itmNameDataGridViewTextBoxColumn.Name = "itmNameDataGridViewTextBoxColumn";
            this.itmNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // manufDataGridViewTextBoxColumn
            // 
            this.manufDataGridViewTextBoxColumn.DataPropertyName = "Manuf";
            this.manufDataGridViewTextBoxColumn.HeaderText = "Прозводитель";
            this.manufDataGridViewTextBoxColumn.Name = "manufDataGridViewTextBoxColumn";
            this.manufDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufDataGridViewTextBoxColumn.Width = 200;
            // 
            // vendorDataGridViewTextBoxColumn
            // 
            this.vendorDataGridViewTextBoxColumn.DataPropertyName = "Vendor";
            this.vendorDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.vendorDataGridViewTextBoxColumn.Name = "vendorDataGridViewTextBoxColumn";
            this.vendorDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorDataGridViewTextBoxColumn.Width = 200;
            // 
            // System_Weight
            // 
            this.System_Weight.DataPropertyName = "System_Weight";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            this.System_Weight.DefaultCellStyle = dataGridViewCellStyle2;
            this.System_Weight.HeaderText = "Вес сист., кг";
            this.System_Weight.Name = "System_Weight";
            this.System_Weight.ReadOnly = true;
            this.System_Weight.Width = 115;
            // 
            // min_Weight
            // 
            this.min_Weight.DataPropertyName = "min_Weight";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            this.min_Weight.DefaultCellStyle = dataGridViewCellStyle3;
            this.min_Weight.HeaderText = "Вес min, кг";
            this.min_Weight.Name = "min_Weight";
            this.min_Weight.ReadOnly = true;
            this.min_Weight.Width = 115;
            // 
            // max_Weight
            // 
            this.max_Weight.DataPropertyName = "max_Weight";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            this.max_Weight.DefaultCellStyle = dataGridViewCellStyle4;
            this.max_Weight.HeaderText = "Вес max, кг";
            this.max_Weight.Name = "max_Weight";
            this.max_Weight.ReadOnly = true;
            this.max_Weight.Width = 115;
            // 
            // Fact_Weight
            // 
            this.Fact_Weight.DataPropertyName = "Fact_Weight";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            this.Fact_Weight.DefaultCellStyle = dataGridViewCellStyle5;
            this.Fact_Weight.HeaderText = "Вес факт, кг";
            this.Fact_Weight.Name = "Fact_Weight";
            this.Fact_Weight.ReadOnly = true;
            this.Fact_Weight.Width = 115;
            // 
            // reWeighingDocItemsBindingSource
            // 
            this.reWeighingDocItemsBindingSource.DataMember = "ReWeighingDocItems";
            this.reWeighingDocItemsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvDocItemsWeighingLog
            // 
            this.dgvDocItemsWeighingLog.AllowUserToAddRows = false;
            this.dgvDocItemsWeighingLog.AllowUserToDeleteRows = false;
            this.dgvDocItemsWeighingLog.AllowUserToResizeRows = false;
            this.dgvDocItemsWeighingLog.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocItemsWeighingLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDocItemsWeighingLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocItemsWeighingLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stagenumberDataGridViewTextBoxColumn,
            this.yLBarcodeDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn});
            this.dgvDocItemsWeighingLog.DataSource = this.reWeighingDocItemStepsBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocItemsWeighingLog.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDocItemsWeighingLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocItemsWeighingLog.Location = new System.Drawing.Point(0, 0);
            this.dgvDocItemsWeighingLog.MultiSelect = false;
            this.dgvDocItemsWeighingLog.Name = "dgvDocItemsWeighingLog";
            this.dgvDocItemsWeighingLog.ReadOnly = true;
            this.dgvDocItemsWeighingLog.RowHeadersVisible = false;
            this.dgvDocItemsWeighingLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocItemsWeighingLog.Size = new System.Drawing.Size(314, 355);
            this.dgvDocItemsWeighingLog.TabIndex = 1;
            // 
            // stagenumberDataGridViewTextBoxColumn
            // 
            this.stagenumberDataGridViewTextBoxColumn.DataPropertyName = "stage_number";
            this.stagenumberDataGridViewTextBoxColumn.HeaderText = "№";
            this.stagenumberDataGridViewTextBoxColumn.Name = "stagenumberDataGridViewTextBoxColumn";
            this.stagenumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.stagenumberDataGridViewTextBoxColumn.Width = 30;
            // 
            // yLBarcodeDataGridViewTextBoxColumn
            // 
            this.yLBarcodeDataGridViewTextBoxColumn.DataPropertyName = "YL_Bar_code";
            this.yLBarcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К ЖЭ";
            this.yLBarcodeDataGridViewTextBoxColumn.Name = "yLBarcodeDataGridViewTextBoxColumn";
            this.yLBarcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.yLBarcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "weight";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N3";
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.weightDataGridViewTextBoxColumn.HeaderText = "Вес, кг";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 110;
            // 
            // reWeighingDocItemStepsBindingSource
            // 
            this.reWeighingDocItemStepsBindingSource.DataMember = "ReWeighingDocItemSteps";
            this.reWeighingDocItemStepsBindingSource.DataSource = this.pickControl;
            // 
            // pnlDocHeader
            // 
            this.pnlDocHeader.Controls.Add(this.dgvDocHeader);
            this.pnlDocHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDocHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDocHeader.Name = "pnlDocHeader";
            this.pnlDocHeader.Size = new System.Drawing.Size(1367, 60);
            this.pnlDocHeader.TabIndex = 0;
            // 
            // dgvDocHeader
            // 
            this.dgvDocHeader.AllowUserToAddRows = false;
            this.dgvDocHeader.AllowUserToDeleteRows = false;
            this.dgvDocHeader.AllowUserToResizeRows = false;
            this.dgvDocHeader.AutoGenerateColumns = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocHeader.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDocHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barCodeDataGridViewTextBoxColumn,
            this.paletweightemptynewDataGridViewTextBoxColumn,
            this.paletweightfullplanDataGridViewTextBoxColumn,
            this.paletweightfullfactDataGridViewTextBoxColumn,
            this.paletweightemptyoldDataGridViewTextBoxColumn});
            this.dgvDocHeader.DataSource = this.pWCCheckRoomBindingSource;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocHeader.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvDocHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocHeader.Location = new System.Drawing.Point(0, 0);
            this.dgvDocHeader.MultiSelect = false;
            this.dgvDocHeader.Name = "dgvDocHeader";
            this.dgvDocHeader.ReadOnly = true;
            this.dgvDocHeader.RowHeadersVisible = false;
            this.dgvDocHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDocHeader.Size = new System.Drawing.Size(1367, 60);
            this.dgvDocHeader.TabIndex = 0;
            this.dgvDocHeader.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocHeader_CellFormatting);
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К пак-листа";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 140;
            // 
            // paletweightemptynewDataGridViewTextBoxColumn
            // 
            this.paletweightemptynewDataGridViewTextBoxColumn.DataPropertyName = "Palet_weight_empty_new";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N3";
            this.paletweightemptynewDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.paletweightemptynewDataGridViewTextBoxColumn.HeaderText = "Вес пустой паллеты новый, кг";
            this.paletweightemptynewDataGridViewTextBoxColumn.Name = "paletweightemptynewDataGridViewTextBoxColumn";
            this.paletweightemptynewDataGridViewTextBoxColumn.ReadOnly = true;
            this.paletweightemptynewDataGridViewTextBoxColumn.Width = 240;
            // 
            // paletweightfullplanDataGridViewTextBoxColumn
            // 
            this.paletweightfullplanDataGridViewTextBoxColumn.DataPropertyName = "Palet_weight_full_plan";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N3";
            this.paletweightfullplanDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.paletweightfullplanDataGridViewTextBoxColumn.HeaderText = "Вес планируемый, кг";
            this.paletweightfullplanDataGridViewTextBoxColumn.Name = "paletweightfullplanDataGridViewTextBoxColumn";
            this.paletweightfullplanDataGridViewTextBoxColumn.ReadOnly = true;
            this.paletweightfullplanDataGridViewTextBoxColumn.Width = 170;
            // 
            // paletweightfullfactDataGridViewTextBoxColumn
            // 
            this.paletweightfullfactDataGridViewTextBoxColumn.DataPropertyName = "Palet_weight_full_fact";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N3";
            dataGridViewCellStyle13.NullValue = null;
            this.paletweightfullfactDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.paletweightfullfactDataGridViewTextBoxColumn.HeaderText = "Вес фактический, кг";
            this.paletweightfullfactDataGridViewTextBoxColumn.Name = "paletweightfullfactDataGridViewTextBoxColumn";
            this.paletweightfullfactDataGridViewTextBoxColumn.ReadOnly = true;
            this.paletweightfullfactDataGridViewTextBoxColumn.Width = 170;
            // 
            // paletweightemptyoldDataGridViewTextBoxColumn
            // 
            this.paletweightemptyoldDataGridViewTextBoxColumn.DataPropertyName = "Palet_weight_empty_old";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N3";
            this.paletweightemptyoldDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.paletweightemptyoldDataGridViewTextBoxColumn.HeaderText = "Вес пустой паллеты старый, кг";
            this.paletweightemptyoldDataGridViewTextBoxColumn.Name = "paletweightemptyoldDataGridViewTextBoxColumn";
            this.paletweightemptyoldDataGridViewTextBoxColumn.ReadOnly = true;
            this.paletweightemptyoldDataGridViewTextBoxColumn.Width = 240;
            // 
            // pWCCheckRoomBindingSource
            // 
            this.pWCCheckRoomBindingSource.DataMember = "PWC_CheckRoom";
            this.pWCCheckRoomBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pWC_CheckRoomTableAdapter
            // 
            this.pWC_CheckRoomTableAdapter.ClearBeforeFill = true;
            // 
            // reWeighingDocItemsTableAdapter
            // 
            this.reWeighingDocItemsTableAdapter.ClearBeforeFill = true;
            // 
            // reWeighingDocItemStepsTableAdapter
            // 
            this.reWeighingDocItemStepsTableAdapter.ClearBeforeFill = true;
            // 
            // ReWeightPalletPacksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 529);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "ReWeightPalletPacksWindow";
            this.Text = "ReWeightPalletPacksWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReWeightPalletPacksWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlDoc.ResumeLayout(false);
            this.scDocItems.Panel1.ResumeLayout(false);
            this.scDocItems.Panel2.ResumeLayout(false);
            this.scDocItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reWeighingDocItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocItemsWeighingLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reWeighingDocItemStepsBindingSource)).EndInit();
            this.pnlDocHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWCCheckRoomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblItemNameValue;
        private WMSOffice.Controls.TextBoxScaner tbsItemBarcode;
        private WMSOffice.Controls.SearchTextBox stbItemID;
        private System.Windows.Forms.Label lblItemBarcode;
        private System.Windows.Forms.Label lblItemID_;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlDocHeader;
        private System.Windows.Forms.SplitContainer scDocItems;
        private System.Windows.Forms.DataGridView dgvDocHeader;
        private System.Windows.Forms.BindingSource pWCCheckRoomBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.PWC_CheckRoomTableAdapter pWC_CheckRoomTableAdapter;
        private System.Windows.Forms.DataGridView dgvDocItems;
        private System.Windows.Forms.DataGridView dgvDocItemsWeighingLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paletweightemptynewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paletweightfullplanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paletweightfullfactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paletweightemptyoldDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlDoc;
        private System.Windows.Forms.BindingSource reWeighingDocItemsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.ReWeighingDocItemsTableAdapter reWeighingDocItemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn System_Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn min_Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn max_Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fact_Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn stagenumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yLBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource reWeighingDocItemStepsBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.ReWeighingDocItemStepsTableAdapter reWeighingDocItemStepsTableAdapter;
    }
}