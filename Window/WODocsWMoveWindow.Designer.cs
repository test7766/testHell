namespace WMSOffice.Window
{
    partial class WODocsWMoveWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.cbTerminalGroups = new System.Windows.Forms.ComboBox();
            this.terminalGroupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wMove = new WMSOffice.Data.WMove();
            this.cbZones = new System.Windows.Forms.ComboBox();
            this.zonesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbDocType = new System.Windows.Forms.ComboBox();
            this.docTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.docsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvTerminals = new System.Windows.Forms.DataGridView();
            this.terminalIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsWorkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWHDocID = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblWHDocType = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblWODocID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWODocType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gvDetails = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTinBXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bXQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wo_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmRows = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miChangeLocnByRow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miRefreshByRow = new System.Windows.Forms.ToolStripMenuItem();
            this.docDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.docsTableAdapter = new WMSOffice.Data.WMoveTableAdapters.DocsTableAdapter();
            this.docDetailsTableAdapter = new WMSOffice.Data.WMoveTableAdapters.DocDetailsTableAdapter();
            this.docTypesTableAdapter = new WMSOffice.Data.WMoveTableAdapters.DocTypesTableAdapter();
            this.zonesTableAdapter = new WMSOffice.Data.WMoveTableAdapters.ZonesTableAdapter();
            this.terminalGroupsTableAdapter = new WMSOffice.Data.WMoveTableAdapters.TerminalGroupsTableAdapter();
            this.terminalsTableAdapter = new WMSOffice.Data.WMoveTableAdapters.TerminalsTableAdapter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripDoc.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terminalGroupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zonesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTypesBindingSource)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.cmMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTerminals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).BeginInit();
            this.cmRows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docDetailsBindingSource)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStripDoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1262, 61);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 1;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(155, 55);
            this.toolStripDoc.TabIndex = 5;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(132, 52);
            this.btnRefresh.Text = "Обновить\n\r содержимое";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblWarehouseName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.stbWarehouse);
            this.groupBox1.Controls.Add(this.cbTerminalGroups);
            this.groupBox1.Controls.Add(this.cbZones);
            this.groupBox1.Controls.Add(this.cbDocType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1088, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр:";
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.AutoSize = true;
            this.lblWarehouseName.Location = new System.Drawing.Point(1043, 26);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(838, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Склад:";
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(887, 22);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(150, 20);
            this.stbWarehouse.TabIndex = 9;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // cbTerminalGroups
            // 
            this.cbTerminalGroups.DataSource = this.terminalGroupsBindingSource;
            this.cbTerminalGroups.DisplayMember = "Group_Name";
            this.cbTerminalGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTerminalGroups.FormattingEnabled = true;
            this.cbTerminalGroups.Location = new System.Drawing.Point(530, 22);
            this.cbTerminalGroups.Name = "cbTerminalGroups";
            this.cbTerminalGroups.Size = new System.Drawing.Size(300, 21);
            this.cbTerminalGroups.TabIndex = 8;
            this.cbTerminalGroups.ValueMember = "Group_ID";
            this.cbTerminalGroups.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // terminalGroupsBindingSource
            // 
            this.terminalGroupsBindingSource.DataMember = "TerminalGroups";
            this.terminalGroupsBindingSource.DataSource = this.wMove;
            // 
            // wMove
            // 
            this.wMove.DataSetName = "WMove";
            this.wMove.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbZones
            // 
            this.cbZones.DataSource = this.zonesBindingSource;
            this.cbZones.DisplayMember = "ZoneName";
            this.cbZones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZones.FormattingEnabled = true;
            this.cbZones.Location = new System.Drawing.Point(297, 23);
            this.cbZones.Name = "cbZones";
            this.cbZones.Size = new System.Drawing.Size(150, 21);
            this.cbZones.TabIndex = 7;
            this.cbZones.ValueMember = "ZoneCode";
            this.cbZones.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // zonesBindingSource
            // 
            this.zonesBindingSource.DataMember = "Zones";
            this.zonesBindingSource.DataSource = this.wMove;
            // 
            // cbDocType
            // 
            this.cbDocType.DataSource = this.docTypesBindingSource;
            this.cbDocType.DisplayMember = "Doc_Type_Name";
            this.cbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocType.FormattingEnabled = true;
            this.cbDocType.Location = new System.Drawing.Point(100, 22);
            this.cbDocType.Name = "cbDocType";
            this.cbDocType.Size = new System.Drawing.Size(150, 21);
            this.cbDocType.TabIndex = 6;
            this.cbDocType.ValueMember = "Doc_Type_ID";
            this.cbDocType.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // docTypesBindingSource
            // 
            this.docTypesBindingSource.DataMember = "DocTypes";
            this.docTypesBindingSource.DataSource = this.wMove;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Группа ТСД:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Зона:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип намерения:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 101);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gvDetails);
            this.splitContainer2.Size = new System.Drawing.Size(1262, 482);
            this.splitContainer2.SplitterDistance = 291;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.xdgvDocs);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gvTerminals);
            this.splitContainer3.Panel2.Controls.Add(this.panel1);
            this.splitContainer3.Size = new System.Drawing.Size(1262, 291);
            this.splitContainer3.SplitterDistance = 957;
            this.splitContainer3.TabIndex = 0;
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 0);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(957, 291);
            this.xdgvDocs.TabIndex = 1;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // cmMain
            // 
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh});
            this.cmMain.Name = "contextMenuStrip1";
            this.cmMain.Size = new System.Drawing.Size(221, 26);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(220, 22);
            this.miRefresh.Text = "Обновить содержимое";
            this.miRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // docsBindingSource
            // 
            this.docsBindingSource.DataMember = "Docs";
            this.docsBindingSource.DataSource = this.wMove;
            // 
            // gvTerminals
            // 
            this.gvTerminals.AllowDrop = true;
            this.gvTerminals.AllowUserToAddRows = false;
            this.gvTerminals.AllowUserToDeleteRows = false;
            this.gvTerminals.AllowUserToResizeRows = false;
            this.gvTerminals.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTerminals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTerminals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTerminals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.terminalIDDataGridViewTextBoxColumn,
            this.terminalNameDataGridViewTextBoxColumn,
            this.itemsTotalDataGridViewTextBoxColumn,
            this.itemsWorkDataGridViewTextBoxColumn});
            this.gvTerminals.ContextMenuStrip = this.cmMain;
            this.gvTerminals.DataSource = this.terminalsBindingSource;
            this.gvTerminals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTerminals.Location = new System.Drawing.Point(0, 0);
            this.gvTerminals.Name = "gvTerminals";
            this.gvTerminals.ReadOnly = true;
            this.gvTerminals.RowHeadersVisible = false;
            this.gvTerminals.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvTerminals.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.gvTerminals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTerminals.Size = new System.Drawing.Size(301, 235);
            this.gvTerminals.TabIndex = 3;
            this.gvTerminals.DragOver += new System.Windows.Forms.DragEventHandler(this.gvTerminals_DragOver);
            this.gvTerminals.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvTerminals_CellFormatting);
            this.gvTerminals.SelectionChanged += new System.EventHandler(this.gvTerminals_SelectionChanged);
            this.gvTerminals.DragDrop += new System.Windows.Forms.DragEventHandler(this.gvTerminals_DragDrop);
            // 
            // terminalIDDataGridViewTextBoxColumn
            // 
            this.terminalIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.terminalIDDataGridViewTextBoxColumn.DataPropertyName = "Terminal_ID";
            this.terminalIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.terminalIDDataGridViewTextBoxColumn.Name = "terminalIDDataGridViewTextBoxColumn";
            this.terminalIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.terminalIDDataGridViewTextBoxColumn.Width = 44;
            // 
            // terminalNameDataGridViewTextBoxColumn
            // 
            this.terminalNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.terminalNameDataGridViewTextBoxColumn.DataPropertyName = "Terminal_Name";
            this.terminalNameDataGridViewTextBoxColumn.HeaderText = "Назв. ТСД";
            this.terminalNameDataGridViewTextBoxColumn.Name = "terminalNameDataGridViewTextBoxColumn";
            this.terminalNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.terminalNameDataGridViewTextBoxColumn.Width = 91;
            // 
            // itemsTotalDataGridViewTextBoxColumn
            // 
            this.itemsTotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemsTotalDataGridViewTextBoxColumn.DataPropertyName = "Items_Total";
            this.itemsTotalDataGridViewTextBoxColumn.HeaderText = "Всего";
            this.itemsTotalDataGridViewTextBoxColumn.Name = "itemsTotalDataGridViewTextBoxColumn";
            this.itemsTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemsTotalDataGridViewTextBoxColumn.Width = 65;
            // 
            // itemsWorkDataGridViewTextBoxColumn
            // 
            this.itemsWorkDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemsWorkDataGridViewTextBoxColumn.DataPropertyName = "Items_Work";
            this.itemsWorkDataGridViewTextBoxColumn.HeaderText = "Готово";
            this.itemsWorkDataGridViewTextBoxColumn.Name = "itemsWorkDataGridViewTextBoxColumn";
            this.itemsWorkDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemsWorkDataGridViewTextBoxColumn.Width = 74;
            // 
            // terminalsBindingSource
            // 
            this.terminalsBindingSource.DataMember = "Terminals";
            this.terminalsBindingSource.DataSource = this.wMove;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblWHDocID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblWHDocType);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblWODocID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblWODocType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 56);
            this.panel1.TabIndex = 2;
            // 
            // lblWHDocID
            // 
            this.lblWHDocID.AutoSize = true;
            this.lblWHDocID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWHDocID.Location = new System.Drawing.Point(139, 32);
            this.lblWHDocID.Name = "lblWHDocID";
            this.lblWHDocID.Size = new System.Drawing.Size(63, 13);
            this.lblWHDocID.TabIndex = 8;
            this.lblWHDocID.TabStop = true;
            this.lblWHDocID.Text = "12345678";
            this.lblWHDocID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWHDocID_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "№ докум.:";
            // 
            // lblWHDocType
            // 
            this.lblWHDocType.AutoSize = true;
            this.lblWHDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWHDocType.Location = new System.Drawing.Point(38, 32);
            this.lblWHDocType.Name = "lblWHDocType";
            this.lblWHDocType.Size = new System.Drawing.Size(23, 13);
            this.lblWHDocType.TabIndex = 5;
            this.lblWHDocType.Text = "XX";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "WH:";
            // 
            // lblWODocID
            // 
            this.lblWODocID.AutoSize = true;
            this.lblWODocID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWODocID.Location = new System.Drawing.Point(139, 6);
            this.lblWODocID.Name = "lblWODocID";
            this.lblWODocID.Size = new System.Drawing.Size(63, 13);
            this.lblWODocID.TabIndex = 3;
            this.lblWODocID.Text = "12345678";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "№ задания:";
            // 
            // lblWODocType
            // 
            this.lblWODocType.AutoSize = true;
            this.lblWODocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWODocType.Location = new System.Drawing.Point(38, 6);
            this.lblWODocType.Name = "lblWODocType";
            this.lblWODocType.Size = new System.Drawing.Size(23, 13);
            this.lblWODocType.TabIndex = 1;
            this.lblWODocType.Text = "XX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Тип:";
            // 
            // gvDetails
            // 
            this.gvDetails.AllowUserToAddRows = false;
            this.gvDetails.AllowUserToDeleteRows = false;
            this.gvDetails.AllowUserToResizeRows = false;
            this.gvDetails.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.iTinBXDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.locationFromDataGridViewTextBoxColumn,
            this.locationToDataGridViewTextBoxColumn,
            this.bXQtyDataGridViewTextBoxColumn,
            this.iTQtyDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.Wo_Qty,
            this.barCodeDataGridViewTextBoxColumn});
            this.gvDetails.ContextMenuStrip = this.cmRows;
            this.gvDetails.DataSource = this.docDetailsBindingSource;
            this.gvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDetails.Location = new System.Drawing.Point(0, 0);
            this.gvDetails.Name = "gvDetails";
            this.gvDetails.ReadOnly = true;
            this.gvDetails.RowHeadersVisible = false;
            this.gvDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvDetails.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.gvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDetails.Size = new System.Drawing.Size(1262, 187);
            this.gvDetails.TabIndex = 2;
            this.gvDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvDetails_CellFormatting);
            this.gvDetails.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvDetails_CellMouseDoubleClick);
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 54;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 200;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 49;
            // 
            // iTinBXDataGridViewTextBoxColumn
            // 
            this.iTinBXDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTinBXDataGridViewTextBoxColumn.DataPropertyName = "ITinBX";
            this.iTinBXDataGridViewTextBoxColumn.HeaderText = "Шт. в ящ.";
            this.iTinBXDataGridViewTextBoxColumn.Name = "iTinBXDataGridViewTextBoxColumn";
            this.iTinBXDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTinBXDataGridViewTextBoxColumn.Width = 85;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 76;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "VendorLot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 68;
            // 
            // locationFromDataGridViewTextBoxColumn
            // 
            this.locationFromDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationFromDataGridViewTextBoxColumn.DataPropertyName = "LocationFrom";
            this.locationFromDataGridViewTextBoxColumn.HeaderText = "С места";
            this.locationFromDataGridViewTextBoxColumn.Name = "locationFromDataGridViewTextBoxColumn";
            this.locationFromDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationFromDataGridViewTextBoxColumn.Width = 79;
            // 
            // locationToDataGridViewTextBoxColumn
            // 
            this.locationToDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationToDataGridViewTextBoxColumn.DataPropertyName = "LocationTo";
            this.locationToDataGridViewTextBoxColumn.HeaderText = "На место";
            this.locationToDataGridViewTextBoxColumn.Name = "locationToDataGridViewTextBoxColumn";
            this.locationToDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationToDataGridViewTextBoxColumn.Width = 87;
            // 
            // bXQtyDataGridViewTextBoxColumn
            // 
            this.bXQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bXQtyDataGridViewTextBoxColumn.DataPropertyName = "BX_Qty";
            this.bXQtyDataGridViewTextBoxColumn.HeaderText = "Ящиков";
            this.bXQtyDataGridViewTextBoxColumn.Name = "bXQtyDataGridViewTextBoxColumn";
            this.bXQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.bXQtyDataGridViewTextBoxColumn.Width = 77;
            // 
            // iTQtyDataGridViewTextBoxColumn
            // 
            this.iTQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTQtyDataGridViewTextBoxColumn.DataPropertyName = "IT_Qty";
            this.iTQtyDataGridViewTextBoxColumn.HeaderText = "Упаковок";
            this.iTQtyDataGridViewTextBoxColumn.Name = "iTQtyDataGridViewTextBoxColumn";
            this.iTQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTQtyDataGridViewTextBoxColumn.Width = 87;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 72;
            // 
            // Wo_Qty
            // 
            this.Wo_Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Wo_Qty.DataPropertyName = "Wo_Qty";
            this.Wo_Qty.HeaderText = "Факт";
            this.Wo_Qty.Name = "Wo_Qty";
            this.Wo_Qty.ReadOnly = true;
            this.Wo_Qty.Width = 63;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Штрих-код";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 94;
            // 
            // cmRows
            // 
            this.cmRows.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChangeLocnByRow,
            this.toolStripMenuItem1,
            this.miRefreshByRow});
            this.cmRows.Name = "contextMenuStrip1";
            this.cmRows.Size = new System.Drawing.Size(251, 54);
            // 
            // miChangeLocnByRow
            // 
            this.miChangeLocnByRow.Name = "miChangeLocnByRow";
            this.miChangeLocnByRow.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miChangeLocnByRow.Size = new System.Drawing.Size(250, 22);
            this.miChangeLocnByRow.Text = "&Изменить место назначения";
            this.miChangeLocnByRow.Click += new System.EventHandler(this.miChangeLocnByRow_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(247, 6);
            // 
            // miRefreshByRow
            // 
            this.miRefreshByRow.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefreshByRow.Name = "miRefreshByRow";
            this.miRefreshByRow.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefreshByRow.Size = new System.Drawing.Size(250, 22);
            this.miRefreshByRow.Text = "Обновить содержимое";
            this.miRefreshByRow.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // docDetailsBindingSource
            // 
            this.docDetailsBindingSource.DataMember = "DocDetails";
            this.docDetailsBindingSource.DataSource = this.wMove;
            // 
            // docsTableAdapter
            // 
            this.docsTableAdapter.ClearBeforeFill = true;
            // 
            // docDetailsTableAdapter
            // 
            this.docDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // docTypesTableAdapter
            // 
            this.docTypesTableAdapter.ClearBeforeFill = true;
            // 
            // zonesTableAdapter
            // 
            this.zonesTableAdapter.ClearBeforeFill = true;
            // 
            // terminalGroupsTableAdapter
            // 
            this.terminalGroupsTableAdapter.ClearBeforeFill = true;
            // 
            // terminalsTableAdapter
            // 
            this.terminalsTableAdapter.ClearBeforeFill = true;
            // 
            // WODocsWMoveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 583);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WODocsWMoveWindow";
            this.Text = "Управление складскими перемещениями";
            this.Load += new System.EventHandler(this.WODocsWMoveWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WODocsWMoveWindow_FormClosing);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.splitContainer2, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terminalGroupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zonesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTypesBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.cmMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTerminals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).EndInit();
            this.cmRows.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource docsBindingSource;
        private WMSOffice.Data.WMove wMove;
        private WMSOffice.Data.WMoveTableAdapters.DocsTableAdapter docsTableAdapter;
        private System.Windows.Forms.BindingSource docDetailsBindingSource;
        private WMSOffice.Data.WMoveTableAdapters.DocDetailsTableAdapter docDetailsTableAdapter;
        private System.Windows.Forms.ComboBox cbDocType;
        private System.Windows.Forms.BindingSource docTypesBindingSource;
        private WMSOffice.Data.WMoveTableAdapters.DocTypesTableAdapter docTypesTableAdapter;
        private System.Windows.Forms.ComboBox cbZones;
        private System.Windows.Forms.BindingSource zonesBindingSource;
        private WMSOffice.Data.WMoveTableAdapters.ZonesTableAdapter zonesTableAdapter;
        private System.Windows.Forms.ComboBox cbTerminalGroups;
        private System.Windows.Forms.BindingSource terminalGroupsBindingSource;
        private WMSOffice.Data.WMoveTableAdapters.TerminalGroupsTableAdapter terminalGroupsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.BindingSource terminalsBindingSource;
        private WMSOffice.Data.WMoveTableAdapters.TerminalsTableAdapter terminalsTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lblWHDocID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblWHDocType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblWODocID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWODocType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTinBXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bXQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wo_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView gvTerminals;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsWorkDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip cmRows;
        private System.Windows.Forms.ToolStripMenuItem miRefreshByRow;
        private System.Windows.Forms.ToolStripMenuItem miChangeLocnByRow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label label6;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.Label lblWarehouseName;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;

    }
}