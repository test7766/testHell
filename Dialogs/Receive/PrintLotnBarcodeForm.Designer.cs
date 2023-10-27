namespace WMSOffice.Dialogs.Receive
{
    partial class PrintLotnBarcodeForm
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
            this.lotnForPrintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStripSearch = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.sbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintBoxBarCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sbIsProblemItemDetected = new System.Windows.Forms.ToolStripButton();
            this.tsShowPrintedYellowLabels = new System.Windows.Forms.ToolStripSeparator();
            this.sbShowPrintedYellowLabels = new System.Windows.Forms.ToolStripButton();
            this.lotn_For_PrintTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.Lotn_For_PrintTableAdapter();
            this.xdgvResult = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.dgvTotals = new System.Windows.Forms.DataGridView();
            this.itemcategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorlotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxcountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotnBoxesInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lotnBoxesInfoTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.LotnBoxesInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lotnForPrintBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStripSearch.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotnBoxesInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lotnForPrintBindingSource
            // 
            this.lotnForPrintBindingSource.DataMember = "Lotn_For_Print";
            this.lotnForPrintBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.groupBox1);
            this.pnlButton.Controls.Add(this.btnClose);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 534);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1350, 42);
            this.pnlButton.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 33);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Горячие клавиши";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Обновить - F5";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1263, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // toolStripSearch
            // 
            this.toolStripSearch.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.cmbPrinters,
            this.sbPrint,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.sbPrintBoxBarCode,
            this.toolStripSeparator4,
            this.sbIsProblemItemDetected,
            this.tsShowPrintedYellowLabels,
            this.sbShowPrintedYellowLabels});
            this.toolStripSearch.Location = new System.Drawing.Point(0, 0);
            this.toolStripSearch.Name = "toolStripSearch";
            this.toolStripSearch.Size = new System.Drawing.Size(1350, 55);
            this.toolStripSearch.TabIndex = 2;
            this.toolStripSearch.TabStop = true;
            this.toolStripSearch.Text = "toolStrip1";
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
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(180, 55);
            // 
            // sbPrint
            // 
            this.sbPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrint.Name = "sbPrint";
            this.sbPrint.Size = new System.Drawing.Size(139, 52);
            this.sbPrint.Text = "Печать списка\nзаказов";
            this.sbPrint.Click += new System.EventHandler(this.sbPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintBoxBarCode
            // 
            this.sbPrintBoxBarCode.Image = global::WMSOffice.Properties.Resources.barcode;
            this.sbPrintBoxBarCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintBoxBarCode.Name = "sbPrintBoxBarCode";
            this.sbPrintBoxBarCode.Size = new System.Drawing.Size(164, 52);
            this.sbPrintBoxBarCode.Text = "Печать ш/к\nна заводской ящик";
            this.sbPrintBoxBarCode.Click += new System.EventHandler(this.sbPrintBoxBarCode_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // sbIsProblemItemDetected
            // 
            this.sbIsProblemItemDetected.Image = global::WMSOffice.Properties.Resources.Achtung;
            this.sbIsProblemItemDetected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbIsProblemItemDetected.Name = "sbIsProblemItemDetected";
            this.sbIsProblemItemDetected.Size = new System.Drawing.Size(166, 52);
            this.sbIsProblemItemDetected.Text = "Обнаружен\nпроблемный товар";
            this.sbIsProblemItemDetected.Click += new System.EventHandler(this.sbIsProblemItemDetected_Click);
            // 
            // tsShowPrintedYellowLabels
            // 
            this.tsShowPrintedYellowLabels.Name = "tsShowPrintedYellowLabels";
            this.tsShowPrintedYellowLabels.Size = new System.Drawing.Size(6, 55);
            // 
            // sbShowPrintedYellowLabels
            // 
            this.sbShowPrintedYellowLabels.Image = global::WMSOffice.Properties.Resources.preview;
            this.sbShowPrintedYellowLabels.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbShowPrintedYellowLabels.Name = "sbShowPrintedYellowLabels";
            this.sbShowPrintedYellowLabels.Size = new System.Drawing.Size(160, 52);
            this.sbShowPrintedYellowLabels.Text = "Просмотр\r\nнапечатанных ж/э";
            this.sbShowPrintedYellowLabels.Click += new System.EventHandler(this.sbShowPrintedYellowLabels_Click);
            // 
            // lotn_For_PrintTableAdapter
            // 
            this.lotn_For_PrintTableAdapter.ClearBeforeFill = true;
            // 
            // xdgvResult
            // 
            this.xdgvResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvResult.LargeAmountOfData = false;
            this.xdgvResult.Location = new System.Drawing.Point(0, 0);
            this.xdgvResult.Name = "xdgvResult";
            this.xdgvResult.RowHeadersVisible = false;
            this.xdgvResult.Size = new System.Drawing.Size(1350, 400);
            this.xdgvResult.TabIndex = 3;
            this.xdgvResult.UserID = ((long)(0));
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DOCK_Qty_IT";
            this.dataGridViewTextBoxColumn1.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DOCK_Qty_BX";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ящиков";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ITinBX";
            this.dataGridViewTextBoxColumn3.HeaderText = "В ящике";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "Код";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Item";
            this.dataGridViewTextBoxColumn5.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn6.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Vendor_Lot";
            this.dataGridViewTextBoxColumn7.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Lot_Number";
            this.dataGridViewTextBoxColumn8.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Exp_Date";
            this.dataGridViewTextBoxColumn9.HeaderText = "Срок годности";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Doco";
            this.dataGridViewTextBoxColumn10.HeaderText = "№ документа";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Dcto";
            this.dataGridViewTextBoxColumn11.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 55);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.xdgvResult);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.dgvTotals);
            this.scMain.Size = new System.Drawing.Size(1350, 479);
            this.scMain.SplitterDistance = 400;
            this.scMain.TabIndex = 4;
            // 
            // dgvTotals
            // 
            this.dgvTotals.AllowUserToAddRows = false;
            this.dgvTotals.AllowUserToDeleteRows = false;
            this.dgvTotals.AllowUserToResizeColumns = false;
            this.dgvTotals.AllowUserToResizeRows = false;
            this.dgvTotals.AutoGenerateColumns = false;
            this.dgvTotals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemcategoryDataGridViewTextBoxColumn,
            this.itemidDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.lotnumberDataGridViewTextBoxColumn,
            this.vendorlotDataGridViewTextBoxColumn,
            this.boxcountDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn});
            this.dgvTotals.DataSource = this.lotnBoxesInfoBindingSource;
            this.dgvTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotals.Location = new System.Drawing.Point(0, 0);
            this.dgvTotals.MultiSelect = false;
            this.dgvTotals.Name = "dgvTotals";
            this.dgvTotals.ReadOnly = true;
            this.dgvTotals.RowHeadersVisible = false;
            this.dgvTotals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotals.Size = new System.Drawing.Size(1350, 75);
            this.dgvTotals.TabIndex = 0;
            // 
            // itemcategoryDataGridViewTextBoxColumn
            // 
            this.itemcategoryDataGridViewTextBoxColumn.DataPropertyName = "item_category";
            this.itemcategoryDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.itemcategoryDataGridViewTextBoxColumn.Name = "itemcategoryDataGridViewTextBoxColumn";
            this.itemcategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcategoryDataGridViewTextBoxColumn.Width = 85;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 108;
            // 
            // lotnumberDataGridViewTextBoxColumn
            // 
            this.lotnumberDataGridViewTextBoxColumn.DataPropertyName = "lot_number";
            this.lotnumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotnumberDataGridViewTextBoxColumn.Name = "lotnumberDataGridViewTextBoxColumn";
            this.lotnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotnumberDataGridViewTextBoxColumn.Width = 69;
            // 
            // vendorlotDataGridViewTextBoxColumn
            // 
            this.vendorlotDataGridViewTextBoxColumn.DataPropertyName = "vendor_lot";
            this.vendorlotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorlotDataGridViewTextBoxColumn.Name = "vendorlotDataGridViewTextBoxColumn";
            this.vendorlotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorlotDataGridViewTextBoxColumn.Width = 63;
            // 
            // boxcountDataGridViewTextBoxColumn
            // 
            this.boxcountDataGridViewTextBoxColumn.DataPropertyName = "box_count";
            this.boxcountDataGridViewTextBoxColumn.HeaderText = "Кол-во ящиков, шт.";
            this.boxcountDataGridViewTextBoxColumn.Name = "boxcountDataGridViewTextBoxColumn";
            this.boxcountDataGridViewTextBoxColumn.ReadOnly = true;
            this.boxcountDataGridViewTextBoxColumn.ToolTipText = "Кол-во ящиков по текущей ящичной норме";
            this.boxcountDataGridViewTextBoxColumn.Width = 105;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Объем, м³";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 78;
            // 
            // lotnBoxesInfoBindingSource
            // 
            this.lotnBoxesInfoBindingSource.DataMember = "LotnBoxesInfo";
            this.lotnBoxesInfoBindingSource.DataSource = this.receive;
            // 
            // lotnBoxesInfoTableAdapter
            // 
            this.lotnBoxesInfoTableAdapter.ClearBeforeFill = true;
            // 
            // PrintLotnBarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1350, 576);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.toolStripSearch);
            this.MinimizeBox = false;
            this.Name = "PrintLotnBarcodeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Печать штрих кода на заводской ящик";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrintLotnBarcodeForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintLotnBarcodeForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.lotnForPrintBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStripSearch.ResumeLayout(false);
            this.toolStripSearch.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotnBoxesInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Data.Receive receive;
        private System.Windows.Forms.BindingSource lotnForPrintBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.Lotn_For_PrintTableAdapter lotn_For_PrintTableAdapter;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStrip toolStripSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton sbPrint;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
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
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvResult;
        private System.Windows.Forms.ToolStripButton sbIsProblemItemDetected;
        private System.Windows.Forms.ToolStripSeparator tsShowPrintedYellowLabels;
        private System.Windows.Forms.ToolStripButton sbPrintBoxBarCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton sbShowPrintedYellowLabels;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.DataGridView dgvTotals;
        private System.Windows.Forms.BindingSource lotnBoxesInfoBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.LotnBoxesInfoTableAdapter lotnBoxesInfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorlotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxcountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
    }
}