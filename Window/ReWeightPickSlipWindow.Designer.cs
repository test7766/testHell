namespace WMSOffice.Window
{
    partial class ReWeightPickSlipWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.dgvDocItems = new System.Windows.Forms.DataGridView();
            this.reWeightPickControlDocItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.pnlFooterContent = new System.Windows.Forms.Panel();
            this.lblEmptyContainerFactWeightValue = new System.Windows.Forms.Label();
            this.lblFullContainerFactWeightValue = new System.Windows.Forms.Label();
            this.lblEmptyContainerPlanWeightValue = new System.Windows.Forms.Label();
            this.lblFullContainerPlanWeightValue = new System.Windows.Forms.Label();
            this.lblFullContainerFactWeight = new System.Windows.Forms.Label();
            this.lblFullContainerPlanWeight = new System.Windows.Forms.Label();
            this.lblEmptyContainerFactWeight = new System.Windows.Forms.Label();
            this.lblEmptyContainerPlanWeight = new System.Windows.Forms.Label();
            this.reWeightPickControlDocItemsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter();
            this.Flag_Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itmIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itmNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyFactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doc_Weight_One_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doc_Weight_Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doc_Weight_OBVH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reWeightPickControlDocItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.pnlFooterContent.SuspendLayout();
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
            this.tsMain.Size = new System.Drawing.Size(1401, 39);
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
            this.pnlSearch.Location = new System.Drawing.Point(0, 79);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1401, 35);
            this.pnlSearch.TabIndex = 2;
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
            this.tbsItemBarcode.DelayThreshold = 50D;
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
            this.pnlContent.Controls.Add(this.pnlMainContent);
            this.pnlContent.Controls.Add(this.pnlFooterContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 114);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1401, 550);
            this.pnlContent.TabIndex = 3;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.dgvDocItems);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1401, 485);
            this.pnlMainContent.TabIndex = 0;
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
            this.Flag_Color,
            this.itmIdDataGridViewTextBoxColumn,
            this.itmNameDataGridViewTextBoxColumn,
            this.docQtyDataGridViewTextBoxColumn,
            this.docQtyFactDataGridViewTextBoxColumn,
            this.Doc_Weight_One_Item,
            this.Doc_Weight_Line,
            this.Doc_Weight_OBVH,
            this.manufDataGridViewTextBoxColumn,
            this.vendorDataGridViewTextBoxColumn});
            this.dgvDocItems.DataSource = this.reWeightPickControlDocItemsBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocItems.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDocItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocItems.Location = new System.Drawing.Point(0, 0);
            this.dgvDocItems.MultiSelect = false;
            this.dgvDocItems.Name = "dgvDocItems";
            this.dgvDocItems.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDocItems.RowHeadersVisible = false;
            this.dgvDocItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocItems.Size = new System.Drawing.Size(1401, 485);
            this.dgvDocItems.TabIndex = 0;
            this.dgvDocItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocItems_CellFormatting);
            // 
            // reWeightPickControlDocItemsBindingSource
            // 
            this.reWeightPickControlDocItemsBindingSource.DataMember = "ReWeightPickControlDocItems";
            this.reWeightPickControlDocItemsBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlFooterContent
            // 
            this.pnlFooterContent.Controls.Add(this.lblEmptyContainerFactWeightValue);
            this.pnlFooterContent.Controls.Add(this.lblFullContainerFactWeightValue);
            this.pnlFooterContent.Controls.Add(this.lblEmptyContainerPlanWeightValue);
            this.pnlFooterContent.Controls.Add(this.lblFullContainerPlanWeightValue);
            this.pnlFooterContent.Controls.Add(this.lblFullContainerFactWeight);
            this.pnlFooterContent.Controls.Add(this.lblFullContainerPlanWeight);
            this.pnlFooterContent.Controls.Add(this.lblEmptyContainerFactWeight);
            this.pnlFooterContent.Controls.Add(this.lblEmptyContainerPlanWeight);
            this.pnlFooterContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterContent.Location = new System.Drawing.Point(0, 485);
            this.pnlFooterContent.Name = "pnlFooterContent";
            this.pnlFooterContent.Size = new System.Drawing.Size(1401, 65);
            this.pnlFooterContent.TabIndex = 1;
            // 
            // lblEmptyContainerFactWeightValue
            // 
            this.lblEmptyContainerFactWeightValue.AutoSize = true;
            this.lblEmptyContainerFactWeightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmptyContainerFactWeightValue.Location = new System.Drawing.Point(572, 36);
            this.lblEmptyContainerFactWeightValue.Name = "lblEmptyContainerFactWeightValue";
            this.lblEmptyContainerFactWeightValue.Size = new System.Drawing.Size(13, 16);
            this.lblEmptyContainerFactWeightValue.TabIndex = 7;
            this.lblEmptyContainerFactWeightValue.Text = "-";
            // 
            // lblFullContainerFactWeightValue
            // 
            this.lblFullContainerFactWeightValue.AutoSize = true;
            this.lblFullContainerFactWeightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFullContainerFactWeightValue.Location = new System.Drawing.Point(204, 36);
            this.lblFullContainerFactWeightValue.Name = "lblFullContainerFactWeightValue";
            this.lblFullContainerFactWeightValue.Size = new System.Drawing.Size(13, 16);
            this.lblFullContainerFactWeightValue.TabIndex = 5;
            this.lblFullContainerFactWeightValue.Text = "-";
            // 
            // lblEmptyContainerPlanWeightValue
            // 
            this.lblEmptyContainerPlanWeightValue.AutoSize = true;
            this.lblEmptyContainerPlanWeightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmptyContainerPlanWeightValue.Location = new System.Drawing.Point(572, 12);
            this.lblEmptyContainerPlanWeightValue.Name = "lblEmptyContainerPlanWeightValue";
            this.lblEmptyContainerPlanWeightValue.Size = new System.Drawing.Size(13, 16);
            this.lblEmptyContainerPlanWeightValue.TabIndex = 3;
            this.lblEmptyContainerPlanWeightValue.Text = "-";
            // 
            // lblFullContainerPlanWeightValue
            // 
            this.lblFullContainerPlanWeightValue.AutoSize = true;
            this.lblFullContainerPlanWeightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFullContainerPlanWeightValue.Location = new System.Drawing.Point(204, 12);
            this.lblFullContainerPlanWeightValue.Name = "lblFullContainerPlanWeightValue";
            this.lblFullContainerPlanWeightValue.Size = new System.Drawing.Size(13, 16);
            this.lblFullContainerPlanWeightValue.TabIndex = 1;
            this.lblFullContainerPlanWeightValue.Text = "-";
            // 
            // lblFullContainerFactWeight
            // 
            this.lblFullContainerFactWeight.AutoSize = true;
            this.lblFullContainerFactWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFullContainerFactWeight.Location = new System.Drawing.Point(12, 36);
            this.lblFullContainerFactWeight.Name = "lblFullContainerFactWeight";
            this.lblFullContainerFactWeight.Size = new System.Drawing.Size(185, 16);
            this.lblFullContainerFactWeight.TabIndex = 4;
            this.lblFullContainerFactWeight.Text = "Вес полного ящика (ФАКТ) :";
            // 
            // lblFullContainerPlanWeight
            // 
            this.lblFullContainerPlanWeight.AutoSize = true;
            this.lblFullContainerPlanWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFullContainerPlanWeight.Location = new System.Drawing.Point(12, 12);
            this.lblFullContainerPlanWeight.Name = "lblFullContainerPlanWeight";
            this.lblFullContainerPlanWeight.Size = new System.Drawing.Size(186, 16);
            this.lblFullContainerPlanWeight.TabIndex = 0;
            this.lblFullContainerPlanWeight.Text = "Вес полного ящика (ПЛАН) :";
            // 
            // lblEmptyContainerFactWeight
            // 
            this.lblEmptyContainerFactWeight.AutoSize = true;
            this.lblEmptyContainerFactWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmptyContainerFactWeight.Location = new System.Drawing.Point(383, 36);
            this.lblEmptyContainerFactWeight.Name = "lblEmptyContainerFactWeight";
            this.lblEmptyContainerFactWeight.Size = new System.Drawing.Size(183, 16);
            this.lblEmptyContainerFactWeight.TabIndex = 6;
            this.lblEmptyContainerFactWeight.Text = "Вес пустого ящика (ФАКТ) :";
            // 
            // lblEmptyContainerPlanWeight
            // 
            this.lblEmptyContainerPlanWeight.AutoSize = true;
            this.lblEmptyContainerPlanWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmptyContainerPlanWeight.Location = new System.Drawing.Point(382, 12);
            this.lblEmptyContainerPlanWeight.Name = "lblEmptyContainerPlanWeight";
            this.lblEmptyContainerPlanWeight.Size = new System.Drawing.Size(184, 16);
            this.lblEmptyContainerPlanWeight.TabIndex = 2;
            this.lblEmptyContainerPlanWeight.Text = "Вес пустого ящика (ПЛАН) :";
            // 
            // reWeightPickControlDocItemsTableAdapter
            // 
            this.reWeightPickControlDocItemsTableAdapter.ClearBeforeFill = true;
            // 
            // Flag_Color
            // 
            this.Flag_Color.DataPropertyName = "Flag_Color";
            this.Flag_Color.HeaderText = "Обработано";
            this.Flag_Color.Name = "Flag_Color";
            this.Flag_Color.ReadOnly = true;
            this.Flag_Color.Visible = false;
            // 
            // itmIdDataGridViewTextBoxColumn
            // 
            this.itmIdDataGridViewTextBoxColumn.DataPropertyName = "Itm_Id";
            this.itmIdDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itmIdDataGridViewTextBoxColumn.Name = "itmIdDataGridViewTextBoxColumn";
            this.itmIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmIdDataGridViewTextBoxColumn.Width = 55;
            // 
            // itmNameDataGridViewTextBoxColumn
            // 
            this.itmNameDataGridViewTextBoxColumn.DataPropertyName = "Itm_Name";
            this.itmNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itmNameDataGridViewTextBoxColumn.Name = "itmNameDataGridViewTextBoxColumn";
            this.itmNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // docQtyDataGridViewTextBoxColumn
            // 
            this.docQtyDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.docQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.docQtyDataGridViewTextBoxColumn.HeaderText = "Сборочный, шт.";
            this.docQtyDataGridViewTextBoxColumn.Name = "docQtyDataGridViewTextBoxColumn";
            this.docQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyDataGridViewTextBoxColumn.Width = 130;
            // 
            // docQtyFactDataGridViewTextBoxColumn
            // 
            this.docQtyFactDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty_Fact";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.docQtyFactDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.docQtyFactDataGridViewTextBoxColumn.HeaderText = "Ящик, шт.";
            this.docQtyFactDataGridViewTextBoxColumn.Name = "docQtyFactDataGridViewTextBoxColumn";
            this.docQtyFactDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyFactDataGridViewTextBoxColumn.Width = 130;
            // 
            // Doc_Weight_One_Item
            // 
            this.Doc_Weight_One_Item.DataPropertyName = "Doc_Weight_One_Item";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Doc_Weight_One_Item.DefaultCellStyle = dataGridViewCellStyle4;
            this.Doc_Weight_One_Item.HeaderText = "Вес упаковки";
            this.Doc_Weight_One_Item.Name = "Doc_Weight_One_Item";
            this.Doc_Weight_One_Item.ReadOnly = true;
            this.Doc_Weight_One_Item.Width = 120;
            // 
            // Doc_Weight_Line
            // 
            this.Doc_Weight_Line.DataPropertyName = "Doc_Weight_Line";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.Doc_Weight_Line.DefaultCellStyle = dataGridViewCellStyle5;
            this.Doc_Weight_Line.HeaderText = "Вес строки";
            this.Doc_Weight_Line.Name = "Doc_Weight_Line";
            this.Doc_Weight_Line.ReadOnly = true;
            this.Doc_Weight_Line.Width = 120;
            // 
            // Doc_Weight_OBVH
            // 
            this.Doc_Weight_OBVH.DataPropertyName = "Doc_Weight_OBVH";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.Doc_Weight_OBVH.DefaultCellStyle = dataGridViewCellStyle6;
            this.Doc_Weight_OBVH.HeaderText = "Вес ОБВХ";
            this.Doc_Weight_OBVH.Name = "Doc_Weight_OBVH";
            this.Doc_Weight_OBVH.ReadOnly = true;
            this.Doc_Weight_OBVH.Width = 120;
            // 
            // manufDataGridViewTextBoxColumn
            // 
            this.manufDataGridViewTextBoxColumn.DataPropertyName = "Manuf";
            this.manufDataGridViewTextBoxColumn.HeaderText = "Производитель";
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
            // ReWeightPickSlipWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 664);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.tsMain);
            this.Name = "ReWeightPickSlipWindow";
            this.Text = "ReWeightPickSlipWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReWeightPickSlipWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlSearch, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reWeightPickControlDocItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.pnlFooterContent.ResumeLayout(false);
            this.pnlFooterContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvDocItems;
        private System.Windows.Forms.BindingSource reWeightPickControlDocItemsBindingSource;
        private Data.Receive receive;
        private Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter reWeightPickControlDocItemsTableAdapter;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private Controls.TextBoxScaner tbsItemBarcode;
        private Controls.SearchTextBox stbItemID;
        private System.Windows.Forms.Label lblItemBarcode;
        private System.Windows.Forms.Label lblItemID_;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblItemNameValue;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlFooterContent;
        private System.Windows.Forms.Label lblEmptyContainerFactWeightValue;
        private System.Windows.Forms.Label lblFullContainerFactWeightValue;
        private System.Windows.Forms.Label lblEmptyContainerPlanWeightValue;
        private System.Windows.Forms.Label lblFullContainerPlanWeightValue;
        private System.Windows.Forms.Label lblFullContainerFactWeight;
        private System.Windows.Forms.Label lblFullContainerPlanWeight;
        private System.Windows.Forms.Label lblEmptyContainerFactWeight;
        private System.Windows.Forms.Label lblEmptyContainerPlanWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flag_Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyFactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doc_Weight_One_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doc_Weight_Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doc_Weight_OBVH;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDataGridViewTextBoxColumn;
    }
}