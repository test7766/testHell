namespace WMSOffice.Window
{
    partial class TSDChargeWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDepot = new System.Windows.Forms.ToolStripButton();
            this.btnOpenDepot = new System.Windows.Forms.ToolStripButton();
            this.tssOpenCloseDepot = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditTSDSettings = new System.Windows.Forms.ToolStripButton();
            this.tssEditTSDSettings = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDepots = new System.Windows.Forms.DataGridView();
            this.warehouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depotCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depotNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.respEmployeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSDcntDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSDOUTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSDINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TSD_OnCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSDAccountingDepotsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tSD = new WMSOffice.Data.TSD();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.xdgvUsageItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.xdgvChargeItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.xdgvCheckItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tSDAccountingDepotsTableAdapter = new WMSOffice.Data.TSDTableAdapters.TSDAccountingDepotsTableAdapter();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDAccountingDepotsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSD)).BeginInit();
            this.panel5.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssRefresh,
            this.btnCloseDepot,
            this.btnOpenDepot,
            this.tssOpenCloseDepot,
            this.btnEditTSDSettings,
            this.tssEditTSDSettings,
            this.btnExportToExcel});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1509, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
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
            // tssRefresh
            // 
            this.tssRefresh.Name = "tssRefresh";
            this.tssRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseDepot
            // 
            this.btnCloseDepot.Image = global::WMSOffice.Properties.Resources.stock_lock;
            this.btnCloseDepot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDepot.Name = "btnCloseDepot";
            this.btnCloseDepot.Size = new System.Drawing.Size(105, 52);
            this.btnCloseDepot.Text = "Закрыть";
            this.btnCloseDepot.Click += new System.EventHandler(this.btnCloseDepot_Click);
            // 
            // btnOpenDepot
            // 
            this.btnOpenDepot.Image = global::WMSOffice.Properties.Resources.stock_unlock;
            this.btnOpenDepot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDepot.Name = "btnOpenDepot";
            this.btnOpenDepot.Size = new System.Drawing.Size(106, 52);
            this.btnOpenDepot.Text = "Открыть";
            this.btnOpenDepot.Click += new System.EventHandler(this.btnOpenDepot_Click);
            // 
            // tssOpenCloseDepot
            // 
            this.tssOpenCloseDepot.Name = "tssOpenCloseDepot";
            this.tssOpenCloseDepot.Size = new System.Drawing.Size(6, 55);
            // 
            // btnEditTSDSettings
            // 
            this.btnEditTSDSettings.Image = global::WMSOffice.Properties.Resources.settings;
            this.btnEditTSDSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditTSDSettings.Name = "btnEditTSDSettings";
            this.btnEditTSDSettings.Size = new System.Drawing.Size(203, 52);
            this.btnEditTSDSettings.Text = "Изменить параметры ТСД";
            this.btnEditTSDSettings.Click += new System.EventHandler(this.btnEditTSDSettings_Click);
            // 
            // tssEditTSDSettings
            // 
            this.tssEditTSDSettings.Name = "tssEditTSDSettings";
            this.tssEditTSDSettings.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(143, 52);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.splitContainer1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1509, 518);
            this.pnlContent.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(1509, 518);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDepots);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1509, 154);
            this.panel1.TabIndex = 3;
            // 
            // dgvDepots
            // 
            this.dgvDepots.AllowDrop = true;
            this.dgvDepots.AllowUserToAddRows = false;
            this.dgvDepots.AllowUserToDeleteRows = false;
            this.dgvDepots.AllowUserToResizeRows = false;
            this.dgvDepots.AutoGenerateColumns = false;
            this.dgvDepots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.warehouseDataGridViewTextBoxColumn,
            this.Status,
            this.depotCodeDataGridViewTextBoxColumn,
            this.depotNameDataGridViewTextBoxColumn,
            this.respEmployeeNameDataGridViewTextBoxColumn,
            this.tSDcntDataGridViewTextBoxColumn,
            this.tSDOUTDataGridViewTextBoxColumn,
            this.tSDINDataGridViewTextBoxColumn,
            this.TSD_OnCheck});
            this.dgvDepots.DataSource = this.tSDAccountingDepotsBindingSource;
            this.dgvDepots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepots.Location = new System.Drawing.Point(0, 0);
            this.dgvDepots.MultiSelect = false;
            this.dgvDepots.Name = "dgvDepots";
            this.dgvDepots.ReadOnly = true;
            this.dgvDepots.RowHeadersVisible = false;
            this.dgvDepots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepots.Size = new System.Drawing.Size(1509, 154);
            this.dgvDepots.TabIndex = 0;
            this.dgvDepots.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepots_CellMouseLeave);
            this.dgvDepots.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvDepots_DragOver);
            this.dgvDepots.SelectionChanged += new System.EventHandler(this.dgvDepots_SelectionChanged);
            this.dgvDepots.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDepots_DragDrop);
            this.dgvDepots.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepots_CellContentClick);
            // 
            // warehouseDataGridViewTextBoxColumn
            // 
            this.warehouseDataGridViewTextBoxColumn.DataPropertyName = "Warehouse";
            this.warehouseDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseDataGridViewTextBoxColumn.Name = "warehouseDataGridViewTextBoxColumn";
            this.warehouseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Статус";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // depotCodeDataGridViewTextBoxColumn
            // 
            this.depotCodeDataGridViewTextBoxColumn.DataPropertyName = "Depot_Code";
            this.depotCodeDataGridViewTextBoxColumn.HeaderText = "Место хранения";
            this.depotCodeDataGridViewTextBoxColumn.Name = "depotCodeDataGridViewTextBoxColumn";
            this.depotCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.depotCodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // depotNameDataGridViewTextBoxColumn
            // 
            this.depotNameDataGridViewTextBoxColumn.DataPropertyName = "Depot_Name";
            this.depotNameDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.depotNameDataGridViewTextBoxColumn.Name = "depotNameDataGridViewTextBoxColumn";
            this.depotNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.depotNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // respEmployeeNameDataGridViewTextBoxColumn
            // 
            this.respEmployeeNameDataGridViewTextBoxColumn.DataPropertyName = "Resp_Employee_Name";
            this.respEmployeeNameDataGridViewTextBoxColumn.HeaderText = "Ответственный за хранение";
            this.respEmployeeNameDataGridViewTextBoxColumn.Name = "respEmployeeNameDataGridViewTextBoxColumn";
            this.respEmployeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.respEmployeeNameDataGridViewTextBoxColumn.Width = 350;
            // 
            // tSDcntDataGridViewTextBoxColumn
            // 
            this.tSDcntDataGridViewTextBoxColumn.DataPropertyName = "TSD_cnt";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.tSDcntDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tSDcntDataGridViewTextBoxColumn.HeaderText = "К-во закрепленных ТСД";
            this.tSDcntDataGridViewTextBoxColumn.Name = "tSDcntDataGridViewTextBoxColumn";
            this.tSDcntDataGridViewTextBoxColumn.ReadOnly = true;
            this.tSDcntDataGridViewTextBoxColumn.Width = 170;
            // 
            // tSDOUTDataGridViewTextBoxColumn
            // 
            this.tSDOUTDataGridViewTextBoxColumn.DataPropertyName = "TSD_OUT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.tSDOUTDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.tSDOUTDataGridViewTextBoxColumn.HeaderText = "К-во ТСД в использовании";
            this.tSDOUTDataGridViewTextBoxColumn.Name = "tSDOUTDataGridViewTextBoxColumn";
            this.tSDOUTDataGridViewTextBoxColumn.ReadOnly = true;
            this.tSDOUTDataGridViewTextBoxColumn.Width = 170;
            // 
            // tSDINDataGridViewTextBoxColumn
            // 
            this.tSDINDataGridViewTextBoxColumn.DataPropertyName = "TSD_IN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.tSDINDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tSDINDataGridViewTextBoxColumn.HeaderText = "К-во ТСД на хранении";
            this.tSDINDataGridViewTextBoxColumn.Name = "tSDINDataGridViewTextBoxColumn";
            this.tSDINDataGridViewTextBoxColumn.ReadOnly = true;
            this.tSDINDataGridViewTextBoxColumn.Width = 170;
            // 
            // TSD_OnCheck
            // 
            this.TSD_OnCheck.DataPropertyName = "TSD_OnCheck";
            this.TSD_OnCheck.HeaderText = "К-во ТСД на проверке";
            this.TSD_OnCheck.Name = "TSD_OnCheck";
            this.TSD_OnCheck.ReadOnly = true;
            this.TSD_OnCheck.Width = 170;
            // 
            // tSDAccountingDepotsBindingSource
            // 
            this.tSDAccountingDepotsBindingSource.DataMember = "TSDAccountingDepots";
            this.tSDAccountingDepotsBindingSource.DataSource = this.tSD;
            // 
            // tSD
            // 
            this.tSD.DataSetName = "TSD";
            this.tSD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1509, 24);
            this.panel5.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(1509, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Шкафы";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(1509, 336);
            this.splitContainer2.SplitterDistance = 758;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.xdgvUsageItems);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(758, 312);
            this.panel4.TabIndex = 4;
            // 
            // xdgvUsageItems
            // 
            this.xdgvUsageItems.AllowSort = true;
            this.xdgvUsageItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvUsageItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvUsageItems.LargeAmountOfData = false;
            this.xdgvUsageItems.Location = new System.Drawing.Point(0, 0);
            this.xdgvUsageItems.Name = "xdgvUsageItems";
            this.xdgvUsageItems.RowHeadersVisible = false;
            this.xdgvUsageItems.Size = new System.Drawing.Size(758, 312);
            this.xdgvUsageItems.TabIndex = 0;
            this.xdgvUsageItems.UserID = ((long)(0));
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 24);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(758, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "ТСД в использовании";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.xdgvChargeItems);
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.xdgvCheckItems);
            this.splitContainer3.Panel2.Controls.Add(this.panel8);
            this.splitContainer3.Panel2.Controls.Add(this.panel9);
            this.splitContainer3.Size = new System.Drawing.Size(747, 336);
            this.splitContainer3.SplitterDistance = 524;
            this.splitContainer3.TabIndex = 6;
            // 
            // xdgvChargeItems
            // 
            this.xdgvChargeItems.AllowSort = true;
            this.xdgvChargeItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvChargeItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvChargeItems.LargeAmountOfData = false;
            this.xdgvChargeItems.Location = new System.Drawing.Point(0, 24);
            this.xdgvChargeItems.Name = "xdgvChargeItems";
            this.xdgvChargeItems.RowHeadersVisible = false;
            this.xdgvChargeItems.Size = new System.Drawing.Size(524, 312);
            this.xdgvChargeItems.TabIndex = 0;
            this.xdgvChargeItems.UserID = ((long)(0));
            this.xdgvChargeItems.Load += new System.EventHandler(this.xdgvChargeItems_Load);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 24);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(524, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ТСД на хранении";
            // 
            // xdgvCheckItems
            // 
            this.xdgvCheckItems.AllowSort = true;
            this.xdgvCheckItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvCheckItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvCheckItems.LargeAmountOfData = false;
            this.xdgvCheckItems.Location = new System.Drawing.Point(0, 24);
            this.xdgvCheckItems.Name = "xdgvCheckItems";
            this.xdgvCheckItems.RowHeadersVisible = false;
            this.xdgvCheckItems.Size = new System.Drawing.Size(219, 312);
            this.xdgvCheckItems.TabIndex = 0;
            this.xdgvCheckItems.UserID = ((long)(0));
            this.xdgvCheckItems.Load += new System.EventHandler(this.extraDataGridView1_Load);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel8.Controls.Add(this.label4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(219, 24);
            this.panel8.TabIndex = 2;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(219, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "ТСД на проверке";
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(219, 336);
            this.panel9.TabIndex = 5;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1509, 336);
            this.panel6.TabIndex = 4;
            // 
            // tSDAccountingDepotsTableAdapter
            // 
            this.tSDAccountingDepotsTableAdapter.ClearBeforeFill = true;
            // 
            // TSDChargeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 613);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "TSDChargeWindow";
            this.Text = "TSDChargeWindow";
            this.Load += new System.EventHandler(this.TSDChargeWindow_Load);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDAccountingDepotsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSD)).EndInit();
            this.panel5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDepots;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvUsageItems;
        private System.Windows.Forms.BindingSource tSDAccountingDepotsBindingSource;
        private WMSOffice.Data.TSD tSD;
        private WMSOffice.Data.TSDTableAdapters.TSDAccountingDepotsTableAdapter tSDAccountingDepotsTableAdapter;
        private System.Windows.Forms.ToolStripSeparator tssRefresh;
        private System.Windows.Forms.ToolStripButton btnCloseDepot;
        private System.Windows.Forms.ToolStripButton btnOpenDepot;
        private System.Windows.Forms.ToolStripSeparator tssOpenCloseDepot;
        private System.Windows.Forms.ToolStripButton btnEditTSDSettings;
        private System.Windows.Forms.ToolStripSeparator tssEditTSDSettings;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn depotCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depotNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn respEmployeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSDcntDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSDOUTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tSDINDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TSD_OnCheck;
        private System.Windows.Forms.Panel panel9;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvCheckItems;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvChargeItems;
    }
}