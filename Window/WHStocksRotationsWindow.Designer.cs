namespace WMSOffice.Window
{
    partial class WHStocksRotationsWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.lblWarehouse = new System.Windows.Forms.ToolStripLabel();
            this.cmbWarehouses = new System.Windows.Forms.ToolStripComboBox();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateTask = new System.Windows.Forms.ToolStripButton();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.warehouseidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typerotatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zone1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zone2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyitmfactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyitmconfirmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lFDocsRotationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.zonenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgrowsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iteminDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lFDocDetailsRotationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lF_DocsRotationsTableAdapter = new WMSOffice.Data.WHTableAdapters.LF_DocsRotationsTableAdapter();
            this.lF_DocDetailsRotationsTableAdapter = new WMSOffice.Data.WHTableAdapters.LF_DocDetailsRotationsTableAdapter();
            this.lFWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lF_WarehousesTableAdapter = new WMSOffice.Data.WHTableAdapters.LF_WarehousesTableAdapter();
            this.tsMain.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFDocsRotationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFDocDetailsRotationsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lFWarehousesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWarehouse,
            this.cmbWarehouses,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnCreateTask});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1161, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(40, 52);
            this.lblWarehouse.Text = "Склад";
            // 
            // cmbWarehouses
            // 
            this.cmbWarehouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouses.Name = "cmbWarehouses";
            this.cmbWarehouses.Size = new System.Drawing.Size(200, 55);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnCreateTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(148, 52);
            this.btnCreateTask.Text = "Создать задание";
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.Location = new System.Drawing.Point(0, 95);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.panel6);
            this.scContent.Panel1.Controls.Add(this.panel5);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.panel2);
            this.scContent.Panel2.Controls.Add(this.panel1);
            this.scContent.Size = new System.Drawing.Size(1161, 479);
            this.scContent.SplitterDistance = 325;
            this.scContent.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvDocs);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1161, 301);
            this.panel6.TabIndex = 3;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelected,
            this.warehouseidDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.docIDDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.typerotatDataGridViewTextBoxColumn,
            this.zone1DataGridViewTextBoxColumn,
            this.zone2DataGridViewTextBoxColumn,
            this.qtyitmfactDataGridViewTextBoxColumn,
            this.qtyitmconfirmDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.lFDocsRotationsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(1161, 301);
            this.dgvDocs.TabIndex = 0;
            this.dgvDocs.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellValueChanged);
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDocs_CurrentCellDirtyStateChanged);
            this.dgvDocs.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDocs_DataError);
            this.dgvDocs.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellEnter);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // IsSelected
            // 
            this.IsSelected.DataPropertyName = "IsSelected";
            this.IsSelected.HeaderText = "Отм.";
            this.IsSelected.Name = "IsSelected";
            this.IsSelected.Width = 35;
            // 
            // warehouseidDataGridViewTextBoxColumn
            // 
            this.warehouseidDataGridViewTextBoxColumn.DataPropertyName = "Warehouse_id";
            this.warehouseidDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseidDataGridViewTextBoxColumn.Name = "warehouseidDataGridViewTextBoxColumn";
            this.warehouseidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата Док";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Номер Док";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип Док";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typerotatDataGridViewTextBoxColumn
            // 
            this.typerotatDataGridViewTextBoxColumn.DataPropertyName = "type_rotat";
            this.typerotatDataGridViewTextBoxColumn.HeaderText = "Тип ротаций";
            this.typerotatDataGridViewTextBoxColumn.Name = "typerotatDataGridViewTextBoxColumn";
            this.typerotatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zone1DataGridViewTextBoxColumn
            // 
            this.zone1DataGridViewTextBoxColumn.DataPropertyName = "zone1";
            this.zone1DataGridViewTextBoxColumn.HeaderText = "Зона 1";
            this.zone1DataGridViewTextBoxColumn.Name = "zone1DataGridViewTextBoxColumn";
            this.zone1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zone2DataGridViewTextBoxColumn
            // 
            this.zone2DataGridViewTextBoxColumn.DataPropertyName = "zone2";
            this.zone2DataGridViewTextBoxColumn.HeaderText = "Зона 2";
            this.zone2DataGridViewTextBoxColumn.Name = "zone2DataGridViewTextBoxColumn";
            this.zone2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyitmfactDataGridViewTextBoxColumn
            // 
            this.qtyitmfactDataGridViewTextBoxColumn.DataPropertyName = "qty_itm_fact";
            this.qtyitmfactDataGridViewTextBoxColumn.HeaderText = "Кол-во номенк.";
            this.qtyitmfactDataGridViewTextBoxColumn.Name = "qtyitmfactDataGridViewTextBoxColumn";
            this.qtyitmfactDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyitmconfirmDataGridViewTextBoxColumn
            // 
            this.qtyitmconfirmDataGridViewTextBoxColumn.DataPropertyName = "qty_itm_confirm";
            this.qtyitmconfirmDataGridViewTextBoxColumn.HeaderText = "Кол-во номенк. утв.";
            this.qtyitmconfirmDataGridViewTextBoxColumn.Name = "qtyitmconfirmDataGridViewTextBoxColumn";
            // 
            // lFDocsRotationsBindingSource
            // 
            this.lFDocsRotationsBindingSource.DataMember = "LF_DocsRotations";
            this.lFDocsRotationsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1161, 24);
            this.panel5.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(1161, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Документы";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDetails);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 126);
            this.panel2.TabIndex = 3;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zonenameDataGridViewTextBoxColumn,
            this.avgrowsDataGridViewTextBoxColumn,
            this.itemoutDataGridViewTextBoxColumn,
            this.iteminDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.lFDocDetailsRotationsBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1161, 126);
            this.dgvDetails.TabIndex = 0;
            // 
            // zonenameDataGridViewTextBoxColumn
            // 
            this.zonenameDataGridViewTextBoxColumn.DataPropertyName = "zone_name";
            this.zonenameDataGridViewTextBoxColumn.HeaderText = "Зона";
            this.zonenameDataGridViewTextBoxColumn.Name = "zonenameDataGridViewTextBoxColumn";
            this.zonenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // avgrowsDataGridViewTextBoxColumn
            // 
            this.avgrowsDataGridViewTextBoxColumn.DataPropertyName = "avg_rows";
            this.avgrowsDataGridViewTextBoxColumn.HeaderText = "Дельта СДП строк дроби";
            this.avgrowsDataGridViewTextBoxColumn.Name = "avgrowsDataGridViewTextBoxColumn";
            this.avgrowsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemoutDataGridViewTextBoxColumn
            // 
            this.itemoutDataGridViewTextBoxColumn.DataPropertyName = "item_out";
            this.itemoutDataGridViewTextBoxColumn.HeaderText = "Кол-во номенк. \"из\"";
            this.itemoutDataGridViewTextBoxColumn.Name = "itemoutDataGridViewTextBoxColumn";
            this.itemoutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iteminDataGridViewTextBoxColumn
            // 
            this.iteminDataGridViewTextBoxColumn.DataPropertyName = "item_in";
            this.iteminDataGridViewTextBoxColumn.HeaderText = "Кол-во номенк. \"в\"";
            this.iteminDataGridViewTextBoxColumn.Name = "iteminDataGridViewTextBoxColumn";
            this.iteminDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lFDocDetailsRotationsBindingSource
            // 
            this.lFDocDetailsRotationsBindingSource.DataMember = "LF_DocDetailsRotations";
            this.lFDocDetailsRotationsBindingSource.DataSource = this.wH;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 24);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(1161, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Детали";
            // 
            // lF_DocsRotationsTableAdapter
            // 
            this.lF_DocsRotationsTableAdapter.ClearBeforeFill = true;
            // 
            // lF_DocDetailsRotationsTableAdapter
            // 
            this.lF_DocDetailsRotationsTableAdapter.ClearBeforeFill = true;
            // 
            // lFWarehousesBindingSource
            // 
            this.lFWarehousesBindingSource.DataMember = "LF_Warehouses";
            this.lFWarehousesBindingSource.DataSource = this.wH;
            // 
            // lF_WarehousesTableAdapter
            // 
            this.lF_WarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // WHStocksRotationsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 574);
            this.Controls.Add(this.scContent);
            this.Controls.Add(this.tsMain);
            this.Name = "WHStocksRotationsWindow";
            this.Text = "WarehouseStocksRotationsWindow";
            this.Load += new System.EventHandler(this.WHStocksRotationsWindow_Load);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.scContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFDocsRotationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFDocDetailsRotationsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lFWarehousesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripLabel lblWarehouse;
        private System.Windows.Forms.ToolStripComboBox cmbWarehouses;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCreateTask;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource lFDocsRotationsBindingSource;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource lFDocDetailsRotationsBindingSource;
        private WMSOffice.Data.WHTableAdapters.LF_DocsRotationsTableAdapter lF_DocsRotationsTableAdapter;
        private WMSOffice.Data.WHTableAdapters.LF_DocDetailsRotationsTableAdapter lF_DocDetailsRotationsTableAdapter;
        private System.Windows.Forms.BindingSource lFWarehousesBindingSource;
        private WMSOffice.Data.WHTableAdapters.LF_WarehousesTableAdapter lF_WarehousesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn zonenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgrowsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iteminDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typerotatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zone1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zone2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyitmfactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyitmconfirmDataGridViewTextBoxColumn;
    }
}