namespace WMSOffice.Window
{
partial class TareMoveCrossDockWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnLoadRemains = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApproveDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCancelDoc = new System.Windows.Forms.ToolStripButton();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.dgvRemains = new System.Windows.Forms.DataGridView();
            this.warehouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remainsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareMoveCrossDockRemainsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.containers = new WMSOffice.Data.Containers();
            this.dgvDocLines = new System.Windows.Forms.DataGridView();
            this.RowN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateupdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareMoveCrossDockDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tareMoveCrossDockRemainsTableAdapter = new WMSOffice.Data.ContainersTableAdapters.TareMoveCrossDockRemainsTableAdapter();
            this.tareMoveCrossDockDocDetailsTableAdapter = new WMSOffice.Data.ContainersTableAdapters.TareMoveCrossDockDocDetailsTableAdapter();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.gbRemCurCD = new System.Windows.Forms.GroupBox();
            this.lblRemCurCDBox = new System.Windows.Forms.Label();
            this.lblRemCurCDCap = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbRemCD = new System.Windows.Forms.GroupBox();
            this.lblRemCDBox = new System.Windows.Forms.Label();
            this.lblRemCDCap = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tsMain.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareMoveCrossDockRemainsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareMoveCrossDockDocDetailsBindingSource)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.gbRemCurCD.SuspendLayout();
            this.gbRemCD.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadRemains,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.btnApproveDoc,
            this.btnCancelDoc});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(503, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnLoadRemains
            // 
            this.btnLoadRemains.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnLoadRemains.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadRemains.Name = "btnLoadRemains";
            this.btnLoadRemains.Size = new System.Drawing.Size(113, 52);
            this.btnLoadRemains.Text = "Загрузить\nостаток";
            this.btnLoadRemains.Click += new System.EventHandler(this.btnLoadRemains_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(142, 52);
            this.toolStripLabel1.Text = "Отсканируйте ш/к тары:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnApproveDoc
            // 
            this.btnApproveDoc.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnApproveDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproveDoc.Name = "btnApproveDoc";
            this.btnApproveDoc.Size = new System.Drawing.Size(111, 52);
            this.btnApproveDoc.Text = "Принять\nдокумент";
            this.btnApproveDoc.Click += new System.EventHandler(this.btnApproveDoc_Click);
            // 
            // btnCancelDoc
            // 
            this.btnCancelDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCancelDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelDoc.Name = "btnCancelDoc";
            this.btnCancelDoc.Size = new System.Drawing.Size(113, 52);
            this.btnCancelDoc.Text = "Отменить\nдокумент";
            this.btnCancelDoc.Click += new System.EventHandler(this.btnCancelDoc_Click);
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.dgvRemains);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.dgvDocLines);
            this.scContent.Size = new System.Drawing.Size(1081, 430);
            this.scContent.SplitterDistance = 150;
            this.scContent.TabIndex = 2;
            // 
            // dgvRemains
            // 
            this.dgvRemains.AllowUserToAddRows = false;
            this.dgvRemains.AllowUserToDeleteRows = false;
            this.dgvRemains.AllowUserToResizeColumns = false;
            this.dgvRemains.AllowUserToResizeRows = false;
            this.dgvRemains.AutoGenerateColumns = false;
            this.dgvRemains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRemains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.warehouseDataGridViewTextBoxColumn,
            this.tareNameDataGridViewTextBoxColumn,
            this.remainsDataGridViewTextBoxColumn});
            this.dgvRemains.DataSource = this.tareMoveCrossDockRemainsBindingSource;
            this.dgvRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRemains.Location = new System.Drawing.Point(0, 0);
            this.dgvRemains.MultiSelect = false;
            this.dgvRemains.Name = "dgvRemains";
            this.dgvRemains.ReadOnly = true;
            this.dgvRemains.RowHeadersVisible = false;
            this.dgvRemains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemains.Size = new System.Drawing.Size(1081, 150);
            this.dgvRemains.TabIndex = 0;
            // 
            // warehouseDataGridViewTextBoxColumn
            // 
            this.warehouseDataGridViewTextBoxColumn.DataPropertyName = "Warehouse";
            this.warehouseDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseDataGridViewTextBoxColumn.Name = "warehouseDataGridViewTextBoxColumn";
            this.warehouseDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseDataGridViewTextBoxColumn.Width = 63;
            // 
            // tareNameDataGridViewTextBoxColumn
            // 
            this.tareNameDataGridViewTextBoxColumn.DataPropertyName = "TareName";
            this.tareNameDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.tareNameDataGridViewTextBoxColumn.Name = "tareNameDataGridViewTextBoxColumn";
            this.tareNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareNameDataGridViewTextBoxColumn.Width = 79;
            // 
            // remainsDataGridViewTextBoxColumn
            // 
            this.remainsDataGridViewTextBoxColumn.DataPropertyName = "Remains";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.remainsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.remainsDataGridViewTextBoxColumn.HeaderText = "Остаток";
            this.remainsDataGridViewTextBoxColumn.Name = "remainsDataGridViewTextBoxColumn";
            this.remainsDataGridViewTextBoxColumn.ReadOnly = true;
            this.remainsDataGridViewTextBoxColumn.Width = 74;
            // 
            // tareMoveCrossDockRemainsBindingSource
            // 
            this.tareMoveCrossDockRemainsBindingSource.DataMember = "TareMoveCrossDockRemains";
            this.tareMoveCrossDockRemainsBindingSource.DataSource = this.containers;
            // 
            // containers
            // 
            this.containers.DataSetName = "Containers";
            this.containers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvDocLines
            // 
            this.dgvDocLines.AllowUserToAddRows = false;
            this.dgvDocLines.AllowUserToDeleteRows = false;
            this.dgvDocLines.AllowUserToResizeColumns = false;
            this.dgvDocLines.AllowUserToResizeRows = false;
            this.dgvDocLines.AutoGenerateColumns = false;
            this.dgvDocLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowN,
            this.barcodeDataGridViewTextBoxColumn,
            this.typeDescriptionDataGridViewTextBoxColumn,
            this.itemidDataGridViewTextBoxColumn,
            this.lotnumberDataGridViewTextBoxColumn,
            this.dateupdatedDataGridViewTextBoxColumn});
            this.dgvDocLines.DataSource = this.tareMoveCrossDockDocDetailsBindingSource;
            this.dgvDocLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocLines.Location = new System.Drawing.Point(0, 0);
            this.dgvDocLines.MultiSelect = false;
            this.dgvDocLines.Name = "dgvDocLines";
            this.dgvDocLines.ReadOnly = true;
            this.dgvDocLines.RowHeadersVisible = false;
            this.dgvDocLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocLines.Size = new System.Drawing.Size(1081, 276);
            this.dgvDocLines.TabIndex = 1;
            // 
            // RowN
            // 
            this.RowN.DataPropertyName = "RowN";
            this.RowN.HeaderText = "№";
            this.RowN.Name = "RowN";
            this.RowN.ReadOnly = true;
            this.RowN.Width = 43;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_code";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К тары";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Width = 81;
            // 
            // typeDescriptionDataGridViewTextBoxColumn
            // 
            this.typeDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Type_Description";
            this.typeDescriptionDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.typeDescriptionDataGridViewTextBoxColumn.Name = "typeDescriptionDataGridViewTextBoxColumn";
            this.typeDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDescriptionDataGridViewTextBoxColumn.Width = 79;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "Item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Width = 89;
            // 
            // lotnumberDataGridViewTextBoxColumn
            // 
            this.lotnumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_number";
            this.lotnumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotnumberDataGridViewTextBoxColumn.Name = "lotnumberDataGridViewTextBoxColumn";
            this.lotnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotnumberDataGridViewTextBoxColumn.Width = 69;
            // 
            // dateupdatedDataGridViewTextBoxColumn
            // 
            this.dateupdatedDataGridViewTextBoxColumn.DataPropertyName = "Date_updated";
            this.dateupdatedDataGridViewTextBoxColumn.HeaderText = "Дата учета";
            this.dateupdatedDataGridViewTextBoxColumn.Name = "dateupdatedDataGridViewTextBoxColumn";
            this.dateupdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateupdatedDataGridViewTextBoxColumn.Width = 88;
            // 
            // tareMoveCrossDockDocDetailsBindingSource
            // 
            this.tareMoveCrossDockDocDetailsBindingSource.DataMember = "TareMoveCrossDockDocDetails";
            this.tareMoveCrossDockDocDetailsBindingSource.DataSource = this.containers;
            // 
            // tareMoveCrossDockRemainsTableAdapter
            // 
            this.tareMoveCrossDockRemainsTableAdapter.ClearBeforeFill = true;
            // 
            // tareMoveCrossDockDocDetailsTableAdapter
            // 
            this.tareMoveCrossDockDocDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.gbRemCurCD);
            this.pnlOptions.Controls.Add(this.gbRemCD);
            this.pnlOptions.Controls.Add(this.tsMain);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(0, 40);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(1081, 55);
            this.pnlOptions.TabIndex = 3;
            // 
            // gbRemCurCD
            // 
            this.gbRemCurCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRemCurCD.BackColor = System.Drawing.SystemColors.Info;
            this.gbRemCurCD.Controls.Add(this.lblRemCurCDBox);
            this.gbRemCurCD.Controls.Add(this.lblRemCurCDCap);
            this.gbRemCurCD.Controls.Add(this.label4);
            this.gbRemCurCD.Controls.Add(this.label3);
            this.gbRemCurCD.ForeColor = System.Drawing.Color.Blue;
            this.gbRemCurCD.Location = new System.Drawing.Point(918, 0);
            this.gbRemCurCD.Name = "gbRemCurCD";
            this.gbRemCurCD.Size = new System.Drawing.Size(160, 52);
            this.gbRemCurCD.TabIndex = 3;
            this.gbRemCurCD.TabStop = false;
            this.gbRemCurCD.Text = "Отсканировано в тек. ПАК";
            // 
            // lblRemCurCDBox
            // 
            this.lblRemCurCDBox.AutoSize = true;
            this.lblRemCurCDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRemCurCDBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRemCurCDBox.Location = new System.Drawing.Point(75, 34);
            this.lblRemCurCDBox.Name = "lblRemCurCDBox";
            this.lblRemCurCDBox.Size = new System.Drawing.Size(14, 13);
            this.lblRemCurCDBox.TabIndex = 3;
            this.lblRemCurCDBox.Text = "0";
            // 
            // lblRemCurCDCap
            // 
            this.lblRemCurCDCap.AutoSize = true;
            this.lblRemCurCDCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRemCurCDCap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRemCurCDCap.Location = new System.Drawing.Point(75, 16);
            this.lblRemCurCDCap.Name = "lblRemCurCDCap";
            this.lblRemCurCDCap.Size = new System.Drawing.Size(14, 13);
            this.lblRemCurCDCap.TabIndex = 1;
            this.lblRemCurCDCap.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(16, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ящики:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Крышки:";
            // 
            // gbRemCD
            // 
            this.gbRemCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRemCD.BackColor = System.Drawing.SystemColors.Info;
            this.gbRemCD.Controls.Add(this.lblRemCDBox);
            this.gbRemCD.Controls.Add(this.lblRemCDCap);
            this.gbRemCD.Controls.Add(this.label2);
            this.gbRemCD.Controls.Add(this.label1);
            this.gbRemCD.ForeColor = System.Drawing.Color.Blue;
            this.gbRemCD.Location = new System.Drawing.Point(752, 0);
            this.gbRemCD.Name = "gbRemCD";
            this.gbRemCD.Size = new System.Drawing.Size(160, 52);
            this.gbRemCD.TabIndex = 2;
            this.gbRemCD.TabStop = false;
            this.gbRemCD.Text = "Остаток на КД";
            // 
            // lblRemCDBox
            // 
            this.lblRemCDBox.AutoSize = true;
            this.lblRemCDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRemCDBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRemCDBox.Location = new System.Drawing.Point(75, 34);
            this.lblRemCDBox.Name = "lblRemCDBox";
            this.lblRemCDBox.Size = new System.Drawing.Size(14, 13);
            this.lblRemCDBox.TabIndex = 3;
            this.lblRemCDBox.Text = "0";
            // 
            // lblRemCDCap
            // 
            this.lblRemCDCap.AutoSize = true;
            this.lblRemCDCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRemCDCap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRemCDCap.Location = new System.Drawing.Point(75, 16);
            this.lblRemCDCap.Name = "lblRemCDCap";
            this.lblRemCDCap.Size = new System.Drawing.Size(14, 13);
            this.lblRemCDCap.TabIndex = 1;
            this.lblRemCDCap.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(16, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ящики:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Крышки:";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.scContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1081, 430);
            this.pnlContent.TabIndex = 4;
            // 
            // TareMoveCrossDockWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1081, 525);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlOptions);
            this.Name = "TareMoveCrossDockWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TareMoveCrossDockWindow_FormClosing);
            this.Controls.SetChildIndex(this.pnlOptions, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareMoveCrossDockRemainsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareMoveCrossDockDocDetailsBindingSource)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.gbRemCurCD.ResumeLayout(false);
            this.gbRemCurCD.PerformLayout();
            this.gbRemCD.ResumeLayout(false);
            this.gbRemCD.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		
		#endregion
		
		private System.Windows.Forms.ToolStripButton btnApproveDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.ToolStripButton btnCancelDoc;
        private System.Windows.Forms.ToolStripButton btnLoadRemains;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView dgvRemains;
        private System.Windows.Forms.DataGridView dgvDocLines;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.BindingSource tareMoveCrossDockRemainsBindingSource;
        private WMSOffice.Data.Containers containers;
        private WMSOffice.Data.ContainersTableAdapters.TareMoveCrossDockRemainsTableAdapter tareMoveCrossDockRemainsTableAdapter;
        private System.Windows.Forms.BindingSource tareMoveCrossDockDocDetailsBindingSource;
        private WMSOffice.Data.ContainersTableAdapters.TareMoveCrossDockDocDetailsTableAdapter tareMoveCrossDockDocDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remainsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowN;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateupdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox gbRemCurCD;
        private System.Windows.Forms.GroupBox gbRemCD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRemCDCap;
        private System.Windows.Forms.Label lblRemCurCDBox;
        private System.Windows.Forms.Label lblRemCurCDCap;
        private System.Windows.Forms.Label lblRemCDBox;	
}
}