namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryFilialHandControlFrom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.miCancelLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnAddItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCancelLine = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCountSheetDate = new System.Windows.Forms.Label();
            this.lblCountSheetID = new System.Windows.Forms.Label();
            this.lblRecalcID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInventoryID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gvLines = new System.Windows.Forms.DataGridView();
            this.FiCSRowsbyHandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fI_CS_Get_RowsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.FI_CS_Get_RowsTableAdapter();
            this.lineIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityNTVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cstg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStripDoc.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiCSRowsbyHandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblBarcode);
            this.splitContainer1.Panel1.Controls.Add(this.tbBarcode);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripDoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 83);
            this.splitContainer1.SplitterDistance = 464;
            this.splitContainer1.TabIndex = 4;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(12, 61);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(62, 13);
            this.lblBarcode.TabIndex = 23;
            this.lblBarcode.Text = "Штрих-код:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.ContextMenuStrip = this.contextMenuStrip1;
            this.tbBarcode.DelayThreshold = 50;
            this.tbBarcode.Location = new System.Drawing.Point(80, 55);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.ScannerListener = null;
            this.tbBarcode.Size = new System.Drawing.Size(341, 25);
            this.tbBarcode.TabIndex = 2;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.UseParentFont = false;
            this.tbBarcode.UseScanModeOnly = false;
            this.tbBarcode.TextChanged += new System.EventHandler(this.tbBarcode_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddItem,
            this.miAddItem2,
            this.miCloseDoc,
            this.miCancelLine});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(289, 92);
            // 
            // miAddItem
            // 
            this.miAddItem.Name = "miAddItem";
            this.miAddItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miAddItem.Size = new System.Drawing.Size(288, 22);
            this.miAddItem.Text = "Добавить товар без штрих кода";
            this.miAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // miAddItem2
            // 
            this.miAddItem2.Name = "miAddItem2";
            this.miAddItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.miAddItem2.Size = new System.Drawing.Size(288, 22);
            this.miAddItem2.Text = "Добавить товар без штрих кода";
            this.miAddItem2.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // miCloseDoc
            // 
            this.miCloseDoc.Name = "miCloseDoc";
            this.miCloseDoc.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.miCloseDoc.Size = new System.Drawing.Size(288, 22);
            this.miCloseDoc.Text = "Завершить ввод препаратов";
            this.miCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // miCancelLine
            // 
            this.miCancelLine.Enabled = false;
            this.miCancelLine.Name = "miCancelLine";
            this.miCancelLine.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.miCancelLine.Size = new System.Drawing.Size(288, 22);
            this.miCancelLine.Text = "Отменить строку ";
            this.miCancelLine.Visible = false;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddItem,
            this.toolStripSeparator1,
            this.btnCloseDoc,
            this.btnCancelLine});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(464, 55);
            this.toolStripDoc.TabIndex = 4;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = global::WMSOffice.Properties.Resources.F2;
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(125, 52);
            this.btnAddItem.Text = "Добавить\n\rтовар без\n\rштрих-кода";
            this.btnAddItem.ToolTipText = "Добавить товар без штрих-кода";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.F4;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(120, 52);
            this.btnCloseDoc.Text = "Завершить\n\r ввод\n\r товаров";
            this.btnCloseDoc.ToolTipText = "Завершить контроль сборочного";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // btnCancelLine
            // 
            this.btnCancelLine.Enabled = false;
            this.btnCancelLine.Image = global::WMSOffice.Properties.Resources.F8;
            this.btnCancelLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelLine.Name = "btnCancelLine";
            this.btnCancelLine.Size = new System.Drawing.Size(113, 52);
            this.btnCancelLine.Text = "Отменить\n\r строку\n\r ";
            this.btnCancelLine.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCountSheetDate);
            this.panel1.Controls.Add(this.lblCountSheetID);
            this.panel1.Controls.Add(this.lblRecalcID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblInventoryID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 82);
            this.panel1.TabIndex = 2;
            // 
            // lblCountSheetDate
            // 
            this.lblCountSheetDate.AutoSize = true;
            this.lblCountSheetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountSheetDate.Location = new System.Drawing.Point(122, 43);
            this.lblCountSheetDate.Name = "lblCountSheetDate";
            this.lblCountSheetDate.Size = new System.Drawing.Size(71, 13);
            this.lblCountSheetDate.TabIndex = 16;
            this.lblCountSheetDate.Text = "21.08.2010";
            // 
            // lblCountSheetID
            // 
            this.lblCountSheetID.AutoSize = true;
            this.lblCountSheetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountSheetID.Location = new System.Drawing.Point(122, 26);
            this.lblCountSheetID.Name = "lblCountSheetID";
            this.lblCountSheetID.Size = new System.Drawing.Size(63, 13);
            this.lblCountSheetID.TabIndex = 15;
            this.lblCountSheetID.Text = "12345678";
            // 
            // lblRecalcID
            // 
            this.lblRecalcID.AutoSize = true;
            this.lblRecalcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecalcID.Location = new System.Drawing.Point(122, 60);
            this.lblRecalcID.Name = "lblRecalcID";
            this.lblRecalcID.Size = new System.Drawing.Size(14, 13);
            this.lblRecalcID.TabIndex = 12;
            this.lblRecalcID.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Дата счетн. листа:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Счетный лист №:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пересчет №:";
            // 
            // lblInventoryID
            // 
            this.lblInventoryID.AutoSize = true;
            this.lblInventoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInventoryID.Location = new System.Drawing.Point(122, 9);
            this.lblInventoryID.Name = "lblInventoryID";
            this.lblInventoryID.Size = new System.Drawing.Size(28, 13);
            this.lblInventoryID.TabIndex = 3;
            this.lblInventoryID.Text = "123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Инвентаризация №:";
            // 
            // gvLines
            // 
            this.gvLines.AllowUserToAddRows = false;
            this.gvLines.AllowUserToDeleteRows = false;
            this.gvLines.AllowUserToResizeRows = false;
            this.gvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvLines.AutoGenerateColumns = false;
            this.gvLines.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineIDDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.quantityNTVDataGridViewTextBoxColumn,
            this.cstg});
            this.gvLines.ContextMenuStrip = this.contextMenuStrip1;
            this.gvLines.DataSource = this.FiCSRowsbyHandBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLines.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvLines.Location = new System.Drawing.Point(0, 129);
            this.gvLines.MultiSelect = false;
            this.gvLines.Name = "gvLines";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvLines.RowHeadersVisible = false;
            this.gvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvLines.Size = new System.Drawing.Size(1020, 259);
            this.gvLines.TabIndex = 6;
            this.gvLines.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLines_CellEndEdit);
            // 
            // FiCSRowsbyHandBindingSource
            // 
            this.FiCSRowsbyHandBindingSource.DataMember = "FI_CS_Get_Rows";
            this.FiCSRowsbyHandBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Line_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn2.HeaderText = "Полка";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Код";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item_Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn5.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "VendorLot";
            this.dataGridViewTextBoxColumn6.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "UnitOfMeasure";
            this.dataGridViewTextBoxColumn7.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 40;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Quantity";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn8.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.ToolTipText = "Количество без НТВ";
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Quantity_NTV";
            this.dataGridViewTextBoxColumn9.HeaderText = "НТВ";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.ToolTipText = "Количество НТВ";
            this.dataGridViewTextBoxColumn9.Width = 50;
            // 
            // fI_CS_Get_RowsTableAdapter
            // 
            this.fI_CS_Get_RowsTableAdapter.ClearBeforeFill = true;
            // 
            // lineIDDataGridViewTextBoxColumn
            // 
            this.lineIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lineIDDataGridViewTextBoxColumn.DataPropertyName = "Line_ID";
            this.lineIDDataGridViewTextBoxColumn.HeaderText = "#";
            this.lineIDDataGridViewTextBoxColumn.Name = "lineIDDataGridViewTextBoxColumn";
            this.lineIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.lineIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lineIDDataGridViewTextBoxColumn.Width = 22;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Полка";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.locationDataGridViewTextBoxColumn.Width = 55;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.itemIDDataGridViewTextBoxColumn.Width = 39;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.itemNameDataGridViewTextBoxColumn.Width = 112;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.manufacturerDataGridViewTextBoxColumn.Width = 116;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "VendorLot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vendorLotDataGridViewTextBoxColumn.Width = 55;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 33;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityDataGridViewTextBoxColumn.ToolTipText = "Количество без НТВ";
            this.quantityDataGridViewTextBoxColumn.Width = 59;
            // 
            // quantityNTVDataGridViewTextBoxColumn
            // 
            this.quantityNTVDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityNTVDataGridViewTextBoxColumn.DataPropertyName = "Quantity_NTV";
            this.quantityNTVDataGridViewTextBoxColumn.HeaderText = "НТВ";
            this.quantityNTVDataGridViewTextBoxColumn.Name = "quantityNTVDataGridViewTextBoxColumn";
            this.quantityNTVDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityNTVDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityNTVDataGridViewTextBoxColumn.ToolTipText = "Количество НТВ";
            this.quantityNTVDataGridViewTextBoxColumn.Width = 42;
            // 
            // cstg
            // 
            this.cstg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cstg.DataPropertyName = "cstg";
            this.cstg.HeaderText = "ШК ЖЭ";
            this.cstg.Name = "cstg";
            this.cstg.ReadOnly = true;
            this.cstg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cstg.Width = 60;
            // 
            // InventoryFilialHandControlFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 388);
            this.Controls.Add(this.gvLines);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InventoryFilialHandControlFrom";
            this.Text = "InventoryHandControlWindow";
            this.Load += new System.EventHandler(this.InventoryHandControlWindow_Load);
            this.Shown += new System.EventHandler(this.InventoryHandControlWindow_Shown);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.gvLines, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiCSRowsbyHandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblBarcode;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnAddItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.ToolStripButton btnCancelLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCountSheetDate;
        private System.Windows.Forms.Label lblCountSheetID;
        private System.Windows.Forms.Label lblRecalcID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInventoryID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miAddItem;
        private System.Windows.Forms.ToolStripMenuItem miAddItem2;
        private System.Windows.Forms.ToolStripMenuItem miCloseDoc;
        private System.Windows.Forms.ToolStripMenuItem miCancelLine;
        private System.Windows.Forms.DataGridView gvLines;
        private System.Windows.Forms.BindingSource FiCSRowsbyHandBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private WMSOffice.Data.InventoryTableAdapters.FI_CS_Get_RowsTableAdapter fI_CS_Get_RowsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityNTVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cstg;
    }
}