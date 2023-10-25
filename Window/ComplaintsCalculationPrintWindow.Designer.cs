namespace WMSOffice.Window
{
    partial class ComplaintsCalculationPrintWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintsCalculationPrintWindow));
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnApproveSign = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnApproveCheck = new System.Windows.Forms.ToolStripButton();
            this.btnChangeDate = new System.Windows.Forms.ToolStripButton();
            this.cmsCalculationsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShowOptimaInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowClientInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.currentCalculationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlCalculations = new System.Windows.Forms.Panel();
            this.xdgvCalculations = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExportItems = new System.Windows.Forms.ToolStripButton();
            this.dgvCalculationInfo = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendor_Lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumVatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoByCalculationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.infoByCalculationTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.InfoByCalculationTableAdapter();
            this.currentCalculationsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CurrentCalculationsTableAdapter();
            this.toolStripDoc.SuspendLayout();
            this.cmsCalculationsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentCalculationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlCalculations.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoByCalculationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnPrint,
            this.btnApproveSign,
            this.toolStripSeparator2,
            this.btnFind,
            this.toolStripSeparator3,
            this.lblPrinter,
            this.cbPrinters,
            this.toolStripSeparator4,
            this.btnExportToExcel,
            this.btnApproveCheck,
            this.btnChangeDate});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1336, 55);
            this.toolStripDoc.TabIndex = 6;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список нераспечатанных документов";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 52);
            this.btnPrint.Text = "Напечатать\rвыбранные\rрасч. корр-ки";
            this.btnPrint.ToolTipText = "Напечатать выбранные расчет-корректировки";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnApproveSign
            // 
            this.btnApproveSign.Image = global::WMSOffice.Properties.Resources.ok;
            this.btnApproveSign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproveSign.Name = "btnApproveSign";
            this.btnApproveSign.Size = new System.Drawing.Size(129, 52);
            this.btnApproveSign.Text = "Подтвердить\rподписание\rклиентом";
            this.btnApproveSign.ToolTipText = "Подтвердить подписание клиентом";
            this.btnApproveSign.Click += new System.EventHandler(this.btnApproveSign_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(113, 52);
            this.btnFind.Text = "Поиск\r  расчет-  \rкорр-к";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(58, 52);
            this.lblPrinter.Text = "Принтер:";
            // 
            // cbPrinters
            // 
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(260, 55);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(104, 52);
            this.btnExportToExcel.Text = "Экспорт\rв Excel";
            this.btnExportToExcel.ToolTipText = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnApproveCheck
            // 
            this.btnApproveCheck.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnApproveCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproveCheck.Name = "btnApproveCheck";
            this.btnApproveCheck.Size = new System.Drawing.Size(111, 52);
            this.btnApproveCheck.Text = "Подтв.\rпроверку\rкорр-ки";
            this.btnApproveCheck.ToolTipText = "Подтв. проверку корр-ки";
            this.btnApproveCheck.Click += new System.EventHandler(this.btnApproveCheck_Click);
            // 
            // btnChangeDate
            // 
            this.btnChangeDate.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.btnChangeDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeDate.Name = "btnChangeDate";
            this.btnChangeDate.Size = new System.Drawing.Size(127, 52);
            this.btnChangeDate.Text = "Изменить\nдату расчет-\nкорр-ки";
            this.btnChangeDate.Click += new System.EventHandler(this.btnChangeDate_Click);
            // 
            // cmsCalculationsTable
            // 
            this.cmsCalculationsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowOptimaInvoice,
            this.miShowClientInvoice});
            this.cmsCalculationsTable.Name = "cmsCalculationsTable";
            this.cmsCalculationsTable.Size = new System.Drawing.Size(220, 48);
            // 
            // miShowOptimaInvoice
            // 
            this.miShowOptimaInvoice.Name = "miShowOptimaInvoice";
            this.miShowOptimaInvoice.Size = new System.Drawing.Size(219, 22);
            this.miShowOptimaInvoice.Text = "Просмотр РК для Оптимы";
            this.miShowOptimaInvoice.Click += new System.EventHandler(this.miShowInvoice_Click);
            // 
            // miShowClientInvoice
            // 
            this.miShowClientInvoice.Name = "miShowClientInvoice";
            this.miShowClientInvoice.Size = new System.Drawing.Size(219, 22);
            this.miShowClientInvoice.Text = "Просмотр РК для клиента";
            this.miShowClientInvoice.Click += new System.EventHandler(this.miShowInvoice_Click);
            // 
            // currentCalculationsBindingSource
            // 
            this.currentCalculationsBindingSource.DataMember = "CurrentCalculations";
            this.currentCalculationsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 95);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnlCalculations);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlItems);
            this.splitContainer.Size = new System.Drawing.Size(1336, 544);
            this.splitContainer.SplitterDistance = 364;
            this.splitContainer.TabIndex = 8;
            // 
            // pnlCalculations
            // 
            this.pnlCalculations.Controls.Add(this.xdgvCalculations);
            this.pnlCalculations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalculations.Location = new System.Drawing.Point(0, 0);
            this.pnlCalculations.Name = "pnlCalculations";
            this.pnlCalculations.Size = new System.Drawing.Size(1336, 364);
            this.pnlCalculations.TabIndex = 8;
            // 
            // xdgvCalculations
            // 
            this.xdgvCalculations.AllowSort = true;
            this.xdgvCalculations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvCalculations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvCalculations.LargeAmountOfData = false;
            this.xdgvCalculations.Location = new System.Drawing.Point(0, 0);
            this.xdgvCalculations.Name = "xdgvCalculations";
            this.xdgvCalculations.RowHeadersVisible = false;
            this.xdgvCalculations.Size = new System.Drawing.Size(1336, 364);
            this.xdgvCalculations.TabIndex = 0;
            this.xdgvCalculations.UserID = ((long)(0));
            // 
            // pnlItems
            // 
            this.pnlItems.Controls.Add(this.toolStrip1);
            this.pnlItems.Controls.Add(this.dgvCalculationInfo);
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 0);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(1336, 176);
            this.pnlItems.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportItems});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1336, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExportItems
            // 
            this.btnExportItems.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportItems.Name = "btnExportItems";
            this.btnExportItems.Size = new System.Drawing.Size(72, 22);
            this.btnExportItems.Text = "Экспорт";
            this.btnExportItems.ToolTipText = "Экспорт позиций в Excel";
            this.btnExportItems.Click += new System.EventHandler(this.btnExportItems_Click);
            // 
            // dgvCalculationInfo
            // 
            this.dgvCalculationInfo.AllowUserToAddRows = false;
            this.dgvCalculationInfo.AllowUserToDeleteRows = false;
            this.dgvCalculationInfo.AllowUserToOrderColumns = true;
            this.dgvCalculationInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvCalculationInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCalculationInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCalculationInfo.AutoGenerateColumns = false;
            this.dgvCalculationInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCalculationInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCalculationInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalculationInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.Vendor_Lot,
            this.LotNumber,
            this.costDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn,
            this.VAT,
            this.sumVatDataGridViewTextBoxColumn});
            this.dgvCalculationInfo.DataSource = this.infoByCalculationBindingSource;
            this.dgvCalculationInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCalculationInfo.Location = new System.Drawing.Point(0, 28);
            this.dgvCalculationInfo.Name = "dgvCalculationInfo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCalculationInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCalculationInfo.RowHeadersVisible = false;
            this.dgvCalculationInfo.RowTemplate.Height = 21;
            this.dgvCalculationInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalculationInfo.ShowCellErrors = false;
            this.dgvCalculationInfo.ShowEditingIcon = false;
            this.dgvCalculationInfo.ShowRowErrors = false;
            this.dgvCalculationInfo.Size = new System.Drawing.Size(1336, 148);
            this.dgvCalculationInfo.TabIndex = 8;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 200;
            // 
            // Vendor_Lot
            // 
            this.Vendor_Lot.DataPropertyName = "Vendor_Lot";
            this.Vendor_Lot.HeaderText = "Серия";
            this.Vendor_Lot.Name = "Vendor_Lot";
            this.Vendor_Lot.ReadOnly = true;
            this.Vendor_Lot.Width = 90;
            // 
            // LotNumber
            // 
            this.LotNumber.DataPropertyName = "LotNumber";
            this.LotNumber.HeaderText = "Партия";
            this.LotNumber.Name = "LotNumber";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.costDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.costDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Width = 70;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "К-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 60;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.sumDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.sumDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            this.sumDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumDataGridViewTextBoxColumn.Width = 75;
            // 
            // VAT
            // 
            this.VAT.DataPropertyName = "VAT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.VAT.DefaultCellStyle = dataGridViewCellStyle6;
            this.VAT.HeaderText = "Сумма НДС";
            this.VAT.Name = "VAT";
            this.VAT.ReadOnly = true;
            // 
            // sumVatDataGridViewTextBoxColumn
            // 
            this.sumVatDataGridViewTextBoxColumn.DataPropertyName = "SumVat";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.sumVatDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.sumVatDataGridViewTextBoxColumn.HeaderText = "Сумма с НДС";
            this.sumVatDataGridViewTextBoxColumn.Name = "sumVatDataGridViewTextBoxColumn";
            this.sumVatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // infoByCalculationBindingSource
            // 
            this.infoByCalculationBindingSource.DataMember = "InfoByCalculation";
            this.infoByCalculationBindingSource.DataSource = this.complaints;
            // 
            // infoByCalculationTableAdapter
            // 
            this.infoByCalculationTableAdapter.ClearBeforeFill = true;
            // 
            // currentCalculationsTableAdapter
            // 
            this.currentCalculationsTableAdapter.ClearBeforeFill = true;
            // 
            // ComplaintsCalculationPrintWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 639);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStripDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComplaintsCalculationPrintWindow";
            this.Text = "Печать расчет корректировок по претензиям";
            this.Shown += new System.EventHandler(this.ComplaintsCalculationPrintWindow_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintsCalculationPrintWindow_FormClosing);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.cmsCalculationsTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentCalculationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.pnlCalculations.ResumeLayout(false);
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoByCalculationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvCalculationInfo;
        private System.Windows.Forms.BindingSource infoByCalculationBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.InfoByCalculationTableAdapter infoByCalculationTableAdapter;
        private System.Windows.Forms.ToolStripButton btnApproveSign;
        private System.Windows.Forms.BindingSource currentCalculationsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CurrentCalculationsTableAdapter currentCalculationsTableAdapter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnApproveCheck;
        private System.Windows.Forms.ContextMenuStrip cmsCalculationsTable;
        private System.Windows.Forms.ToolStripMenuItem miShowOptimaInvoice;
        private System.Windows.Forms.ToolStripMenuItem miShowClientInvoice;
        private System.Windows.Forms.Panel pnlCalculations;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvCalculations;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExportItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor_Lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumVatDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton btnChangeDate;
    }
}