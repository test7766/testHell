namespace WMSOffice.Window
{
    partial class WHOperationsWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefreshDocs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sbFindDocuments = new System.Windows.Forms.ToolStripButton();
            this.sbCreateOperation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sbDocActions = new System.Windows.Forms.ToolStripDropDownButton();
            this.sbMakeTSDTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbScanDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.sbGiveDocToApproving = new System.Windows.Forms.ToolStripMenuItem();
            this.sbApproveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbRejectDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintDoc = new System.Windows.Forms.ToolStripDropDownButton();
            this.sbMovementOrderReport = new System.Windows.Forms.ToolStripMenuItem();
            this.sbRegradingGoodsNoteReport = new System.Windows.Forms.ToolStripMenuItem();
            this.sbRegradingGoodsReceiptActReport = new System.Windows.Forms.ToolStripMenuItem();
            this.sbWriteOffReport = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMainDoc = new System.Windows.Forms.Panel();
            this.xdgvMainDocGrid = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.operationWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.operationsDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operationsDocsTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationsDocsTableAdapter();
            this.operationWarehousesTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMainMenu.SuspendLayout();
            this.pnlMainDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationWarehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationsDocsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshDocs,
            this.toolStripSeparator1,
            this.toolStripSeparator5,
            this.sbFindDocuments,
            this.sbCreateOperation,
            this.toolStripSeparator4,
            this.sbDocActions,
            this.cmbPrinters,
            this.lblPrinter,
            this.toolStripSeparator6,
            this.sbPrintDoc});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1135, 55);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbRefreshDocs
            // 
            this.sbRefreshDocs.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshDocs.Name = "sbRefreshDocs";
            this.sbRefreshDocs.Size = new System.Drawing.Size(113, 52);
            this.sbRefreshDocs.Text = "Обновить";
            this.sbRefreshDocs.Click += new System.EventHandler(this.sbRefreshDocs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // sbFindDocuments
            // 
            this.sbFindDocuments.Image = global::WMSOffice.Properties.Resources.find;
            this.sbFindDocuments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFindDocuments.Name = "sbFindDocuments";
            this.sbFindDocuments.Size = new System.Drawing.Size(124, 52);
            this.sbFindDocuments.Text = "Поиск\nдокументов";
            this.sbFindDocuments.Click += new System.EventHandler(this.sbFindDocuments_Click);
            // 
            // sbCreateOperation
            // 
            this.sbCreateOperation.Image = global::WMSOffice.Properties.Resources.add_document;
            this.sbCreateOperation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCreateOperation.Name = "sbCreateOperation";
            this.sbCreateOperation.Size = new System.Drawing.Size(141, 52);
            this.sbCreateOperation.Text = "Создать новую\nоперацию";
            this.sbCreateOperation.Click += new System.EventHandler(this.sbCreateOperation_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // sbDocActions
            // 
            this.sbDocActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbMakeTSDTask,
            this.toolStripSeparator2,
            this.sbScanDoc,
            this.sbGiveDocToApproving,
            this.sbApproveDoc,
            this.toolStripSeparator3,
            this.sbRejectDoc});
            this.sbDocActions.Image = global::WMSOffice.Properties.Resources.actions;
            this.sbDocActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbDocActions.Name = "sbDocActions";
            this.sbDocActions.Size = new System.Drawing.Size(119, 52);
            this.sbDocActions.Text = "Действия";
            // 
            // sbMakeTSDTask
            // 
            this.sbMakeTSDTask.Name = "sbMakeTSDTask";
            this.sbMakeTSDTask.Size = new System.Drawing.Size(215, 22);
            this.sbMakeTSDTask.Tag = "1";
            this.sbMakeTSDTask.Text = "Создать задание на ТСД";
            this.sbMakeTSDTask.Click += new System.EventHandler(this.sbExecuteAction_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // sbScanDoc
            // 
            this.sbScanDoc.Name = "sbScanDoc";
            this.sbScanDoc.Size = new System.Drawing.Size(215, 22);
            this.sbScanDoc.Tag = "2";
            this.sbScanDoc.Text = "Провести документ";
            this.sbScanDoc.Click += new System.EventHandler(this.sbExecuteAction_Click);
            // 
            // sbGiveDocToApproving
            // 
            this.sbGiveDocToApproving.Name = "sbGiveDocToApproving";
            this.sbGiveDocToApproving.Size = new System.Drawing.Size(215, 22);
            this.sbGiveDocToApproving.Tag = "3";
            this.sbGiveDocToApproving.Text = "Передать на утверждение";
            this.sbGiveDocToApproving.Click += new System.EventHandler(this.sbExecuteAction_Click);
            // 
            // sbApproveDoc
            // 
            this.sbApproveDoc.Name = "sbApproveDoc";
            this.sbApproveDoc.Size = new System.Drawing.Size(215, 22);
            this.sbApproveDoc.Tag = "5";
            this.sbApproveDoc.Text = "Утвердить документ";
            this.sbApproveDoc.Click += new System.EventHandler(this.sbExecuteAction_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(212, 6);
            // 
            // sbRejectDoc
            // 
            this.sbRejectDoc.Name = "sbRejectDoc";
            this.sbRejectDoc.Size = new System.Drawing.Size(215, 22);
            this.sbRejectDoc.Tag = "4";
            this.sbRejectDoc.Text = "Отклонить документ";
            this.sbRejectDoc.Click += new System.EventHandler(this.sbExecuteAction_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(58, 52);
            this.lblPrinter.Text = "Принтер:";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintDoc
            // 
            this.sbPrintDoc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbPrintDoc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbMovementOrderReport,
            this.sbRegradingGoodsNoteReport,
            this.sbRegradingGoodsReceiptActReport,
            this.sbWriteOffReport});
            this.sbPrintDoc.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintDoc.Name = "sbPrintDoc";
            this.sbPrintDoc.Size = new System.Drawing.Size(126, 52);
            this.sbPrintDoc.Text = "Печать\nдокумента";
            // 
            // sbMovementOrderReport
            // 
            this.sbMovementOrderReport.Name = "sbMovementOrderReport";
            this.sbMovementOrderReport.Size = new System.Drawing.Size(205, 22);
            this.sbMovementOrderReport.Text = "Наряд на перемещение";
            this.sbMovementOrderReport.Click += new System.EventHandler(this.sbMovementOrderReport_Click);
            // 
            // sbRegradingGoodsNoteReport
            // 
            this.sbRegradingGoodsNoteReport.Name = "sbRegradingGoodsNoteReport";
            this.sbRegradingGoodsNoteReport.Size = new System.Drawing.Size(205, 22);
            this.sbRegradingGoodsNoteReport.Text = "Служебная записка";
            this.sbRegradingGoodsNoteReport.Click += new System.EventHandler(this.sbRegradingGoodsNoteReport_Click);
            // 
            // sbRegradingGoodsReceiptActReport
            // 
            this.sbRegradingGoodsReceiptActReport.Name = "sbRegradingGoodsReceiptActReport";
            this.sbRegradingGoodsReceiptActReport.Size = new System.Drawing.Size(205, 22);
            this.sbRegradingGoodsReceiptActReport.Text = "Акт приема";
            this.sbRegradingGoodsReceiptActReport.Click += new System.EventHandler(this.sbRegradingGoodsReceiptActReport_Click);
            // 
            // sbWriteOffReport
            // 
            this.sbWriteOffReport.Name = "sbWriteOffReport";
            this.sbWriteOffReport.Size = new System.Drawing.Size(205, 22);
            this.sbWriteOffReport.Text = "Акт списания";
            this.sbWriteOffReport.Click += new System.EventHandler(this.sbWriteOffReport_Click);
            // 
            // pnlMainDoc
            // 
            this.pnlMainDoc.Controls.Add(this.xdgvMainDocGrid);
            this.pnlMainDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainDoc.Location = new System.Drawing.Point(0, 95);
            this.pnlMainDoc.Name = "pnlMainDoc";
            this.pnlMainDoc.Size = new System.Drawing.Size(1135, 467);
            this.pnlMainDoc.TabIndex = 2;
            // 
            // xdgvMainDocGrid
            // 
            this.xdgvMainDocGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvMainDocGrid.Location = new System.Drawing.Point(0, 0);
            this.xdgvMainDocGrid.Name = "xdgvMainDocGrid";
            this.xdgvMainDocGrid.Size = new System.Drawing.Size(1135, 467);
            this.xdgvMainDocGrid.TabIndex = 1;
            this.xdgvMainDocGrid.UserID = ((long)(0));
            // 
            // operationWarehousesBindingSource
            // 
            this.operationWarehousesBindingSource.DataMember = "OperationWarehouses";
            this.operationWarehousesBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operationsDocsBindingSource
            // 
            this.operationsDocsBindingSource.DataMember = "OperationsDocs";
            this.operationsDocsBindingSource.DataSource = this.wH;
            // 
            // operationsDocsTableAdapter
            // 
            this.operationsDocsTableAdapter.ClearBeforeFill = true;
            // 
            // operationWarehousesTableAdapter
            // 
            this.operationWarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Doc_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№ док-та";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SubDocTypeName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Тип док-та";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DocDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата док-та";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Status_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "Код статуса";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "StatusName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn6.HeaderText = "Описание операции";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "WarehouseID_From";
            this.dataGridViewComboBoxColumn1.DataSource = this.operationWarehousesBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "Warehouse";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn1.HeaderText = "Склад \"откуда\"";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "Warehouse_ID";
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "WarehouseID_To";
            this.dataGridViewComboBoxColumn2.DataSource = this.operationWarehousesBindingSource;
            this.dataGridViewComboBoxColumn2.DisplayMember = "Warehouse";
            this.dataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn2.HeaderText = "Склад \"куда\"";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.ReadOnly = true;
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn2.ValueMember = "Warehouse_ID";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "WarehouseID_From";
            this.dataGridViewTextBoxColumn7.HeaderText = "Склад \"откуда\"";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "WarehouseID_To";
            this.dataGridViewTextBoxColumn8.HeaderText = "Склад \"куда\"";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "JD_DocID";
            this.dataGridViewTextBoxColumn9.HeaderText = "№ док-та JD";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "JD_DocType";
            this.dataGridViewTextBoxColumn10.HeaderText = "Тип док-та JD";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "BatchNumber";
            this.dataGridViewTextBoxColumn11.HeaderText = "Номер пакета";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsVirtual";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Виртуальная операция";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "WO_Doc_ID";
            this.dataGridViewTextBoxColumn12.HeaderText = "№ задания ТСД";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "WO_Doc_Type";
            this.dataGridViewTextBoxColumn13.HeaderText = "Тип задания ТСД";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Employers";
            this.dataGridViewTextBoxColumn14.HeaderText = "Автор операции";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Amount_UAH";
            this.dataGridViewTextBoxColumn15.HeaderText = "Сумма док-та, грн";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // WHOperationsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 562);
            this.Controls.Add(this.pnlMainDoc);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "WHOperationsWindow";
            this.Text = "WHOperationsWindow";
            this.Load += new System.EventHandler(this.WHOperationsWindow_Load);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.pnlMainDoc, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.pnlMainDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.operationWarehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationsDocsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbRefreshDocs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbCreateOperation;
        private System.Windows.Forms.Panel pnlMainDoc;
        private System.Windows.Forms.BindingSource operationsDocsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.OperationsDocsTableAdapter operationsDocsTableAdapter;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.BindingSource operationWarehousesBindingSource;
        private WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter operationWarehousesTableAdapter;
        private System.Windows.Forms.ToolStripDropDownButton sbDocActions;
        private System.Windows.Forms.ToolStripMenuItem sbMakeTSDTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sbScanDoc;
        private System.Windows.Forms.ToolStripMenuItem sbGiveDocToApproving;
        private System.Windows.Forms.ToolStripMenuItem sbApproveDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem sbRejectDoc;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.ToolStripDropDownButton sbPrintDoc;
        private System.Windows.Forms.ToolStripMenuItem sbMovementOrderReport;
        private System.Windows.Forms.ToolStripMenuItem sbRegradingGoodsNoteReport;
        private System.Windows.Forms.ToolStripMenuItem sbRegradingGoodsReceiptActReport;
        private System.Windows.Forms.ToolStripMenuItem sbWriteOffReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton sbFindDocuments;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvMainDocGrid;
    }
}