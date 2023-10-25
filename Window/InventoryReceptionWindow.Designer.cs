namespace WMSOffice.Window
{
    partial class InventoryReceptionWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlWork = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvCalcs = new System.Windows.Forms.DataGridView();
            this.filialIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jDDocIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryAutoCalcsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.gvCountSheets = new System.Windows.Forms.DataGridView();
            this.cSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmCS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintCS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miRefreshCS = new System.Windows.Forms.ToolStripMenuItem();
            this.iVCountSheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalProgress = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalWMS = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalJDE = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inventoryAutoCalcsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoryAutoCalcsTableAdapter();
            this.iV_CountSheetsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.IV_CountSheetsTableAdapter();
            this.pnlWork.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCalcs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryAutoCalcsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCountSheets)).BeginInit();
            this.cmCS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iVCountSheetsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWork
            // 
            this.pnlWork.Controls.Add(this.label4);
            this.pnlWork.Controls.Add(this.tbBarcode);
            this.pnlWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWork.Location = new System.Drawing.Point(0, 40);
            this.pnlWork.Name = "pnlWork";
            this.pnlWork.Size = new System.Drawing.Size(740, 37);
            this.pnlWork.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Штрих-код счетного листа:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.ContextMenuStrip = this.contextMenuStrip1;
            this.tbBarcode.Location = new System.Drawing.Point(162, 6);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.Size = new System.Drawing.Size(566, 25);
            this.tbBarcode.TabIndex = 2;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.TextChanged += new System.EventHandler(this.tbBarcode_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 26);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(147, 22);
            this.miRefresh.Text = "&Обновить";
            this.miRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 77);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvCalcs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvCountSheets);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(740, 311);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.TabIndex = 5;
            // 
            // gvCalcs
            // 
            this.gvCalcs.AllowUserToAddRows = false;
            this.gvCalcs.AllowUserToDeleteRows = false;
            this.gvCalcs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gvCalcs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCalcs.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCalcs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvCalcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCalcs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filialIDDataGridViewTextBoxColumn,
            this.filialDataGridViewTextBoxColumn,
            this.jDDocIDDataGridViewTextBoxColumn,
            this.docIDDataGridViewTextBoxColumn,
            this.calcIDDataGridViewTextBoxColumn});
            this.gvCalcs.ContextMenuStrip = this.contextMenuStrip1;
            this.gvCalcs.DataSource = this.inventoryAutoCalcsBindingSource;
            this.gvCalcs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCalcs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvCalcs.Location = new System.Drawing.Point(0, 0);
            this.gvCalcs.Name = "gvCalcs";
            this.gvCalcs.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCalcs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvCalcs.RowHeadersVisible = false;
            this.gvCalcs.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvCalcs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCalcs.ShowEditingIcon = false;
            this.gvCalcs.Size = new System.Drawing.Size(740, 119);
            this.gvCalcs.TabIndex = 5;
            this.gvCalcs.SelectionChanged += new System.EventHandler(this.gvCalcs_SelectionChanged);
            // 
            // filialIDDataGridViewTextBoxColumn
            // 
            this.filialIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.filialIDDataGridViewTextBoxColumn.DataPropertyName = "Filial_ID";
            this.filialIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.filialIDDataGridViewTextBoxColumn.Name = "filialIDDataGridViewTextBoxColumn";
            this.filialIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.filialIDDataGridViewTextBoxColumn.Width = 58;
            // 
            // filialDataGridViewTextBoxColumn
            // 
            this.filialDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.filialDataGridViewTextBoxColumn.DataPropertyName = "Filial";
            this.filialDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.filialDataGridViewTextBoxColumn.Name = "filialDataGridViewTextBoxColumn";
            this.filialDataGridViewTextBoxColumn.ReadOnly = true;
            this.filialDataGridViewTextBoxColumn.Width = 73;
            // 
            // jDDocIDDataGridViewTextBoxColumn
            // 
            this.jDDocIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.jDDocIDDataGridViewTextBoxColumn.DataPropertyName = "JD_Doc_ID";
            this.jDDocIDDataGridViewTextBoxColumn.HeaderText = "Инв. JDE";
            this.jDDocIDDataGridViewTextBoxColumn.Name = "jDDocIDDataGridViewTextBoxColumn";
            this.jDDocIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.jDDocIDDataGridViewTextBoxColumn.Width = 92;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Инв.";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 62;
            // 
            // calcIDDataGridViewTextBoxColumn
            // 
            this.calcIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.calcIDDataGridViewTextBoxColumn.DataPropertyName = "Calc_ID";
            this.calcIDDataGridViewTextBoxColumn.HeaderText = "Пересчет";
            this.calcIDDataGridViewTextBoxColumn.Name = "calcIDDataGridViewTextBoxColumn";
            this.calcIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.calcIDDataGridViewTextBoxColumn.Width = 97;
            // 
            // inventoryAutoCalcsBindingSource
            // 
            this.inventoryAutoCalcsBindingSource.DataMember = "InventoryAutoCalcs";
            this.inventoryAutoCalcsBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gvCountSheets
            // 
            this.gvCountSheets.AllowUserToAddRows = false;
            this.gvCountSheets.AllowUserToDeleteRows = false;
            this.gvCountSheets.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gvCountSheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvCountSheets.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCountSheets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvCountSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCountSheets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSIDDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.dATEDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.Employees});
            this.gvCountSheets.ContextMenuStrip = this.cmCS;
            this.gvCountSheets.DataSource = this.iVCountSheetsBindingSource;
            this.gvCountSheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCountSheets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvCountSheets.Location = new System.Drawing.Point(0, 40);
            this.gvCountSheets.Name = "gvCountSheets";
            this.gvCountSheets.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCountSheets.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gvCountSheets.RowHeadersVisible = false;
            this.gvCountSheets.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvCountSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCountSheets.ShowEditingIcon = false;
            this.gvCountSheets.Size = new System.Drawing.Size(740, 148);
            this.gvCountSheets.TabIndex = 6;
            this.gvCountSheets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCountSheets_CellDoubleClick);
            // 
            // cSIDDataGridViewTextBoxColumn
            // 
            this.cSIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cSIDDataGridViewTextBoxColumn.DataPropertyName = "CS_ID";
            this.cSIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.cSIDDataGridViewTextBoxColumn.Name = "cSIDDataGridViewTextBoxColumn";
            this.cSIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cSIDDataGridViewTextBoxColumn.Width = 46;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип документа";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeDataGridViewTextBoxColumn.Width = 121;
            // 
            // dATEDataGridViewTextBoxColumn
            // 
            this.dATEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dATEDataGridViewTextBoxColumn.DataPropertyName = "DATE";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.dATEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.dATEDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dATEDataGridViewTextBoxColumn.Name = "dATEDataGridViewTextBoxColumn";
            this.dATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dATEDataGridViewTextBoxColumn.Width = 67;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 78;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Название статуса";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 139;
            // 
            // Employees
            // 
            this.Employees.DataPropertyName = "Employees";
            this.Employees.HeaderText = "Сотрудники";
            this.Employees.Name = "Employees";
            this.Employees.ReadOnly = true;
            // 
            // cmCS
            // 
            this.cmCS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewLog,
            this.miPrintCS,
            this.toolStripSeparator1,
            this.miRefreshCS});
            this.cmCS.Name = "contextMenuStrip1";
            this.cmCS.Size = new System.Drawing.Size(305, 98);
            // 
            // miViewLog
            // 
            this.miViewLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.miViewLog.Name = "miViewLog";
            this.miViewLog.Size = new System.Drawing.Size(304, 22);
            this.miViewLog.Text = "Посмотреть &лог статусов";
            this.miViewLog.Click += new System.EventHandler(this.miViewLog_Click);
            // 
            // miPrintCS
            // 
            this.miPrintCS.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miPrintCS.Name = "miPrintCS";
            this.miPrintCS.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.miPrintCS.Size = new System.Drawing.Size(304, 22);
            this.miPrintCS.Text = "Повторная &печать Счетного листа";
            this.miPrintCS.Click += new System.EventHandler(this.miPrintCS_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(301, 6);
            // 
            // miRefreshCS
            // 
            this.miRefreshCS.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefreshCS.Name = "miRefreshCS";
            this.miRefreshCS.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefreshCS.Size = new System.Drawing.Size(304, 22);
            this.miRefreshCS.Text = "&Обновить";
            this.miRefreshCS.Click += new System.EventHandler(this.miRefreshCS_Click);
            // 
            // iVCountSheetsBindingSource
            // 
            this.iVCountSheetsBindingSource.DataMember = "IV_CountSheets";
            this.iVCountSheetsBindingSource.DataSource = this.inventory;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalProgress);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblTotalWMS);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblTotalJDE);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 40);
            this.panel1.TabIndex = 7;
            // 
            // lblTotalProgress
            // 
            this.lblTotalProgress.AutoSize = true;
            this.lblTotalProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalProgress.Location = new System.Drawing.Point(654, 14);
            this.lblTotalProgress.Name = "lblTotalProgress";
            this.lblTotalProgress.Size = new System.Drawing.Size(55, 13);
            this.lblTotalProgress.TabIndex = 8;
            this.lblTotalProgress.Text = "000,00%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(623, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Итог:";
            // 
            // lblTotalWMS
            // 
            this.lblTotalWMS.AutoSize = true;
            this.lblTotalWMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalWMS.Location = new System.Drawing.Point(539, 14);
            this.lblTotalWMS.Name = "lblTotalWMS";
            this.lblTotalWMS.Size = new System.Drawing.Size(78, 13);
            this.lblTotalWMS.TabIndex = 6;
            this.lblTotalWMS.Text = "000 000 000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "WMS =";
            // 
            // lblTotalJDE
            // 
            this.lblTotalJDE.AutoSize = true;
            this.lblTotalJDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalJDE.Location = new System.Drawing.Point(415, 14);
            this.lblTotalJDE.Name = "lblTotalJDE";
            this.lblTotalJDE.Size = new System.Drawing.Size(78, 13);
            this.lblTotalJDE.TabIndex = 4;
            this.lblTotalJDE.Text = "000 000 000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "JDE =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ход инв.:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(62, 11);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(255, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поиск:";
            // 
            // inventoryAutoCalcsTableAdapter
            // 
            this.inventoryAutoCalcsTableAdapter.ClearBeforeFill = true;
            // 
            // iV_CountSheetsTableAdapter
            // 
            this.iV_CountSheetsTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryReceptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlWork);
            this.Name = "InventoryReceptionWindow";
            this.Text = "InventoryReceptionWindow";
            this.Load += new System.EventHandler(this.InventoryReceptionWindow_Load);
            this.Controls.SetChildIndex(this.pnlWork, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.pnlWork.ResumeLayout(false);
            this.pnlWork.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCalcs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryAutoCalcsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCountSheets)).EndInit();
            this.cmCS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iVCountSheetsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWork;
        private System.Windows.Forms.Label label4;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvCalcs;
        private System.Windows.Forms.DataGridView gvCountSheets;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn filialIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jDDocIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource inventoryAutoCalcsBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.InventoryAutoCalcsTableAdapter inventoryAutoCalcsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip cmCS;
        private System.Windows.Forms.ToolStripMenuItem miRefreshCS;
        private System.Windows.Forms.ToolStripMenuItem miPrintCS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource iVCountSheetsBindingSource;
        private WMSOffice.Data.InventoryTableAdapters.IV_CountSheetsTableAdapter iV_CountSheetsTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblTotalJDE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalProgress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalWMS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem miViewLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employees;
    }
}