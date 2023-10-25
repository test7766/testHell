namespace WMSOffice.Window
{
    partial class ExtendedReceiveWindow
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
            this.pnlDocHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderContent = new System.Windows.Forms.Panel();
            this.pnlBarcode = new System.Windows.Forms.Panel();
            this.textBoxScaner = new WMSOffice.Controls.TextBoxScaner();
            this.lblScanerAction = new System.Windows.Forms.Label();
            this.scHeaderMainLayout = new System.Windows.Forms.SplitContainer();
            this.lblManufacturerNameValue = new System.Windows.Forms.Label();
            this.lblBatchIDValue = new System.Windows.Forms.Label();
            this.lblVendorLotValue = new System.Windows.Forms.Label();
            this.lblItemIDValue = new System.Windows.Forms.Label();
            this.lblItemNameValue = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblManufacturerName = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.lblTotalCountValue = new System.Windows.Forms.Label();
            this.lblBoxesCountValue = new System.Windows.Forms.Label();
            this.lblItemsCountValue = new System.Windows.Forms.Label();
            this.lblItemsInBoxValue = new System.Windows.Forms.Label();
            this.lblUnitOfMeasureValue = new System.Windows.Forms.Label();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.lblBoxesCount = new System.Windows.Forms.Label();
            this.lblItemsInBox = new System.Windows.Forms.Label();
            this.lblUnitOfMeasure = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.btnApply = new System.Windows.Forms.ToolStripButton();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnUndoLotReceipt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetBoxBarcode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colSnowflake = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTinBXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bXQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.dgvBarcodes = new System.Windows.Forms.DataGridView();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scannedBarcodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.docLinesTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.DocLinesTableAdapter();
            this.scannedBarcodesTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.ScannedBarcodesTableAdapter();
            this.pnlDocHeader.SuspendLayout();
            this.pnlHeaderContent.SuspendLayout();
            this.pnlBarcode.SuspendLayout();
            this.scHeaderMainLayout.Panel1.SuspendLayout();
            this.scHeaderMainLayout.Panel2.SuspendLayout();
            this.scHeaderMainLayout.SuspendLayout();
            this.tsToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scannedBarcodesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDocHeader
            // 
            this.pnlDocHeader.Controls.Add(this.pnlHeaderContent);
            this.pnlDocHeader.Controls.Add(this.tsToolbar);
            this.pnlDocHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDocHeader.Location = new System.Drawing.Point(0, 40);
            this.pnlDocHeader.Name = "pnlDocHeader";
            this.pnlDocHeader.Size = new System.Drawing.Size(1034, 205);
            this.pnlDocHeader.TabIndex = 1;
            // 
            // pnlHeaderContent
            // 
            this.pnlHeaderContent.Controls.Add(this.pnlBarcode);
            this.pnlHeaderContent.Controls.Add(this.scHeaderMainLayout);
            this.pnlHeaderContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderContent.Location = new System.Drawing.Point(0, 55);
            this.pnlHeaderContent.Name = "pnlHeaderContent";
            this.pnlHeaderContent.Size = new System.Drawing.Size(1034, 150);
            this.pnlHeaderContent.TabIndex = 1;
            // 
            // pnlBarcode
            // 
            this.pnlBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.pnlBarcode.Controls.Add(this.textBoxScaner);
            this.pnlBarcode.Controls.Add(this.lblScanerAction);
            this.pnlBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarcode.Location = new System.Drawing.Point(0, 0);
            this.pnlBarcode.Name = "pnlBarcode";
            this.pnlBarcode.Size = new System.Drawing.Size(1034, 31);
            this.pnlBarcode.TabIndex = 1;
            // 
            // textBoxScaner
            // 
            this.textBoxScaner.AllowType = true;
            this.textBoxScaner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScaner.AutoConvert = true;
            this.textBoxScaner.DelayThreshold = 50;
            this.textBoxScaner.Location = new System.Drawing.Point(272, 3);
            this.textBoxScaner.Name = "textBoxScaner";
            this.textBoxScaner.RaiseTextChangeWithoutEnter = false;
            this.textBoxScaner.ReadOnly = false;
            this.textBoxScaner.Size = new System.Drawing.Size(759, 25);
            this.textBoxScaner.TabIndex = 1;
            this.textBoxScaner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.textBoxScaner.UseParentFont = false;
            this.textBoxScaner.UseScanModeOnly = false;
            // 
            // lblScanerAction
            // 
            this.lblScanerAction.AutoSize = true;
            this.lblScanerAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScanerAction.Location = new System.Drawing.Point(3, 9);
            this.lblScanerAction.Name = "lblScanerAction";
            this.lblScanerAction.Size = new System.Drawing.Size(263, 13);
            this.lblScanerAction.TabIndex = 0;
            this.lblScanerAction.Text = "Отсканируйте следующую единицу товара:";
            // 
            // scHeaderMainLayout
            // 
            this.scHeaderMainLayout.Location = new System.Drawing.Point(0, 35);
            this.scHeaderMainLayout.Name = "scHeaderMainLayout";
            // 
            // scHeaderMainLayout.Panel1
            // 
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblManufacturerNameValue);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblBatchIDValue);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblVendorLotValue);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblItemIDValue);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblItemNameValue);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblItemID);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblManufacturerName);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblItemName);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblBatchID);
            this.scHeaderMainLayout.Panel1.Controls.Add(this.lblVendorLot);
            // 
            // scHeaderMainLayout.Panel2
            // 
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblTotalCountValue);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblBoxesCountValue);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblItemsCountValue);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblItemsInBoxValue);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblUnitOfMeasureValue);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblCountValue);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblTotalCount);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblItemsCount);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblBoxesCount);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblItemsInBox);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblUnitOfMeasure);
            this.scHeaderMainLayout.Panel2.Controls.Add(this.lblCount);
            this.scHeaderMainLayout.Size = new System.Drawing.Size(1034, 110);
            this.scHeaderMainLayout.SplitterDistance = 550;
            this.scHeaderMainLayout.TabIndex = 0;
            // 
            // lblManufacturerNameValue
            // 
            this.lblManufacturerNameValue.AutoSize = true;
            this.lblManufacturerNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManufacturerNameValue.Location = new System.Drawing.Point(95, 89);
            this.lblManufacturerNameValue.Name = "lblManufacturerNameValue";
            this.lblManufacturerNameValue.Size = new System.Drawing.Size(0, 13);
            this.lblManufacturerNameValue.TabIndex = 9;
            // 
            // lblBatchIDValue
            // 
            this.lblBatchIDValue.AutoSize = true;
            this.lblBatchIDValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBatchIDValue.Location = new System.Drawing.Point(95, 68);
            this.lblBatchIDValue.Name = "lblBatchIDValue";
            this.lblBatchIDValue.Size = new System.Drawing.Size(0, 13);
            this.lblBatchIDValue.TabIndex = 7;
            // 
            // lblVendorLotValue
            // 
            this.lblVendorLotValue.AutoSize = true;
            this.lblVendorLotValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVendorLotValue.Location = new System.Drawing.Point(95, 47);
            this.lblVendorLotValue.Name = "lblVendorLotValue";
            this.lblVendorLotValue.Size = new System.Drawing.Size(0, 13);
            this.lblVendorLotValue.TabIndex = 5;
            // 
            // lblItemIDValue
            // 
            this.lblItemIDValue.AutoSize = true;
            this.lblItemIDValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemIDValue.Location = new System.Drawing.Point(95, 5);
            this.lblItemIDValue.Name = "lblItemIDValue";
            this.lblItemIDValue.Size = new System.Drawing.Size(0, 13);
            this.lblItemIDValue.TabIndex = 1;
            // 
            // lblItemNameValue
            // 
            this.lblItemNameValue.AutoSize = true;
            this.lblItemNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemNameValue.Location = new System.Drawing.Point(95, 26);
            this.lblItemNameValue.Name = "lblItemNameValue";
            this.lblItemNameValue.Size = new System.Drawing.Size(0, 13);
            this.lblItemNameValue.TabIndex = 3;
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(3, 5);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(29, 13);
            this.lblItemID.TabIndex = 0;
            this.lblItemID.Text = "Код:";
            // 
            // lblManufacturerName
            // 
            this.lblManufacturerName.AutoSize = true;
            this.lblManufacturerName.Location = new System.Drawing.Point(3, 89);
            this.lblManufacturerName.Name = "lblManufacturerName";
            this.lblManufacturerName.Size = new System.Drawing.Size(89, 13);
            this.lblManufacturerName.TabIndex = 8;
            this.lblManufacturerName.Text = "Производитель:";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(3, 26);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(86, 13);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Наименование:";
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.Location = new System.Drawing.Point(3, 68);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(47, 13);
            this.lblBatchID.TabIndex = 6;
            this.lblBatchID.Text = "Партия:";
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(3, 47);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLot.TabIndex = 4;
            this.lblVendorLot.Text = "Серия:";
            // 
            // lblTotalCountValue
            // 
            this.lblTotalCountValue.AutoSize = true;
            this.lblTotalCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalCountValue.Location = new System.Drawing.Point(329, 68);
            this.lblTotalCountValue.Name = "lblTotalCountValue";
            this.lblTotalCountValue.Size = new System.Drawing.Size(0, 13);
            this.lblTotalCountValue.TabIndex = 11;
            // 
            // lblBoxesCountValue
            // 
            this.lblBoxesCountValue.AutoSize = true;
            this.lblBoxesCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBoxesCountValue.Location = new System.Drawing.Point(329, 26);
            this.lblBoxesCountValue.Name = "lblBoxesCountValue";
            this.lblBoxesCountValue.Size = new System.Drawing.Size(0, 13);
            this.lblBoxesCountValue.TabIndex = 7;
            // 
            // lblItemsCountValue
            // 
            this.lblItemsCountValue.AutoSize = true;
            this.lblItemsCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemsCountValue.Location = new System.Drawing.Point(329, 47);
            this.lblItemsCountValue.Name = "lblItemsCountValue";
            this.lblItemsCountValue.Size = new System.Drawing.Size(0, 13);
            this.lblItemsCountValue.TabIndex = 9;
            // 
            // lblItemsInBoxValue
            // 
            this.lblItemsInBoxValue.AutoSize = true;
            this.lblItemsInBoxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemsInBoxValue.Location = new System.Drawing.Point(78, 68);
            this.lblItemsInBoxValue.Name = "lblItemsInBoxValue";
            this.lblItemsInBoxValue.Size = new System.Drawing.Size(0, 13);
            this.lblItemsInBoxValue.TabIndex = 5;
            // 
            // lblUnitOfMeasureValue
            // 
            this.lblUnitOfMeasureValue.AutoSize = true;
            this.lblUnitOfMeasureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUnitOfMeasureValue.Location = new System.Drawing.Point(78, 47);
            this.lblUnitOfMeasureValue.Name = "lblUnitOfMeasureValue";
            this.lblUnitOfMeasureValue.Size = new System.Drawing.Size(0, 13);
            this.lblUnitOfMeasureValue.TabIndex = 3;
            // 
            // lblCountValue
            // 
            this.lblCountValue.AutoSize = true;
            this.lblCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountValue.Location = new System.Drawing.Point(78, 26);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(0, 13);
            this.lblCountValue.TabIndex = 1;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(263, 68);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(40, 13);
            this.lblTotalCount.TabIndex = 10;
            this.lblTotalCount.Text = "Всего:";
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Location = new System.Drawing.Point(263, 47);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(60, 13);
            this.lblItemsCount.TabIndex = 8;
            this.lblItemsCount.Text = "Упаковок:";
            // 
            // lblBoxesCount
            // 
            this.lblBoxesCount.AutoSize = true;
            this.lblBoxesCount.Location = new System.Drawing.Point(263, 26);
            this.lblBoxesCount.Name = "lblBoxesCount";
            this.lblBoxesCount.Size = new System.Drawing.Size(51, 13);
            this.lblBoxesCount.TabIndex = 6;
            this.lblBoxesCount.Text = "Ящиков:";
            // 
            // lblItemsInBox
            // 
            this.lblItemsInBox.AutoSize = true;
            this.lblItemsInBox.Location = new System.Drawing.Point(3, 68);
            this.lblItemsInBox.Name = "lblItemsInBox";
            this.lblItemsInBox.Size = new System.Drawing.Size(54, 13);
            this.lblItemsInBox.TabIndex = 4;
            this.lblItemsInBox.Text = "Шт. в ед.:";
            // 
            // lblUnitOfMeasure
            // 
            this.lblUnitOfMeasure.AutoSize = true;
            this.lblUnitOfMeasure.Location = new System.Drawing.Point(3, 47);
            this.lblUnitOfMeasure.Name = "lblUnitOfMeasure";
            this.lblUnitOfMeasure.Size = new System.Drawing.Size(52, 13);
            this.lblUnitOfMeasure.TabIndex = 2;
            this.lblUnitOfMeasure.Text = "Ед. изм.:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(3, 26);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(69, 13);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Количество:";
            // 
            // tsToolbar
            // 
            this.tsToolbar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnApply,
            this.btnUndo,
            this.btnUndoLotReceipt,
            this.toolStripSeparator1,
            this.btnSetBoxBarcode,
            this.toolStripSeparator2,
            this.btnCloseDoc});
            this.tsToolbar.Location = new System.Drawing.Point(0, 0);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Size = new System.Drawing.Size(1034, 55);
            this.tsToolbar.TabIndex = 0;
            this.tsToolbar.Text = "toolStrip1";
            // 
            // btnApply
            // 
            this.btnApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApply.Image = global::WMSOffice.Properties.Resources.save;
            this.btnApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(52, 52);
            this.btnApply.Text = "Применить изменения";
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(52, 52);
            this.btnUndo.Text = "Отменить последнее действие";
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnUndoLotReceipt
            // 
            this.btnUndoLotReceipt.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnUndoLotReceipt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoLotReceipt.Name = "btnUndoLotReceipt";
            this.btnUndoLotReceipt.Size = new System.Drawing.Size(164, 52);
            this.btnUndoLotReceipt.Text = "Отменить приемку\nпартии товара";
            this.btnUndoLotReceipt.Click += new System.EventHandler(this.btnUndoLotReceipt_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSetBoxBarcode
            // 
            this.btnSetBoxBarcode.Image = global::WMSOffice.Properties.Resources.barcode;
            this.btnSetBoxBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetBoxBarcode.Name = "btnSetBoxBarcode";
            this.btnSetBoxBarcode.Size = new System.Drawing.Size(178, 52);
            this.btnSetBoxBarcode.Text = "Зарезервировать ш/к\nна заводской ящик";
            this.btnSetBoxBarcode.Click += new System.EventHandler(this.btnSetBoxBarcode_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.checkered_flag;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(188, 52);
            this.btnCloseDoc.Text = "Закрыть документ\nо перемещении товара";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSnowflake,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.iTinBXDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.bXQtyDataGridViewTextBoxColumn,
            this.iTQtyDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.docLinesBindingSource;
            this.dgvDetails.Location = new System.Drawing.Point(0, 245);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(905, 290);
            this.dgvDetails.TabIndex = 2;
            this.dgvDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetails_DataBindingComplete);
            // 
            // colSnowflake
            // 
            this.colSnowflake.HeaderText = "T";
            this.colSnowflake.Name = "colSnowflake";
            this.colSnowflake.ReadOnly = true;
            this.colSnowflake.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSnowflake.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSnowflake.Width = 25;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 108;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 111;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 47;
            // 
            // iTinBXDataGridViewTextBoxColumn
            // 
            this.iTinBXDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTinBXDataGridViewTextBoxColumn.DataPropertyName = "ITinBX";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0";
            dataGridViewCellStyle1.NullValue = null;
            this.iTinBXDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.iTinBXDataGridViewTextBoxColumn.HeaderText = "шт.";
            this.iTinBXDataGridViewTextBoxColumn.Name = "iTinBXDataGridViewTextBoxColumn";
            this.iTinBXDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTinBXDataGridViewTextBoxColumn.Width = 48;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серия/Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 105;
            // 
            // bXQtyDataGridViewTextBoxColumn
            // 
            this.bXQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bXQtyDataGridViewTextBoxColumn.DataPropertyName = "BX_Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.bXQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.bXQtyDataGridViewTextBoxColumn.HeaderText = "Ящиков";
            this.bXQtyDataGridViewTextBoxColumn.Name = "bXQtyDataGridViewTextBoxColumn";
            this.bXQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.bXQtyDataGridViewTextBoxColumn.Width = 73;
            // 
            // iTQtyDataGridViewTextBoxColumn
            // 
            this.iTQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTQtyDataGridViewTextBoxColumn.DataPropertyName = "IT_Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.iTQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.iTQtyDataGridViewTextBoxColumn.HeaderText = "Упаковок";
            this.iTQtyDataGridViewTextBoxColumn.Name = "iTQtyDataGridViewTextBoxColumn";
            this.iTQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTQtyDataGridViewTextBoxColumn.Width = 82;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 91;
            // 
            // docLinesBindingSource
            // 
            this.docLinesBindingSource.DataMember = "DocLines";
            this.docLinesBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvBarcodes
            // 
            this.dgvBarcodes.AllowUserToAddRows = false;
            this.dgvBarcodes.AllowUserToDeleteRows = false;
            this.dgvBarcodes.AllowUserToResizeColumns = false;
            this.dgvBarcodes.AllowUserToResizeRows = false;
            this.dgvBarcodes.AutoGenerateColumns = false;
            this.dgvBarcodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barCodeDataGridViewTextBoxColumn});
            this.dgvBarcodes.DataSource = this.scannedBarcodesBindingSource;
            this.dgvBarcodes.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvBarcodes.Location = new System.Drawing.Point(909, 245);
            this.dgvBarcodes.MultiSelect = false;
            this.dgvBarcodes.Name = "dgvBarcodes";
            this.dgvBarcodes.ReadOnly = true;
            this.dgvBarcodes.RowHeadersVisible = false;
            this.dgvBarcodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarcodes.Size = new System.Drawing.Size(125, 290);
            this.dgvBarcodes.TabIndex = 3;
            this.dgvBarcodes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBarcodes_CellFormatting);
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // scannedBarcodesBindingSource
            // 
            this.scannedBarcodesBindingSource.DataMember = "ScannedBarcodes";
            this.scannedBarcodesBindingSource.DataSource = this.receive;
            // 
            // docLinesTableAdapter
            // 
            this.docLinesTableAdapter.ClearBeforeFill = true;
            // 
            // scannedBarcodesTableAdapter
            // 
            this.scannedBarcodesTableAdapter.ClearBeforeFill = true;
            // 
            // ExtendedReceiveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 535);
            this.Controls.Add(this.dgvBarcodes);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.pnlDocHeader);
            this.Name = "ExtendedReceiveWindow";
            this.Text = "ReceiveExtendedWindow";
            this.Controls.SetChildIndex(this.pnlDocHeader, 0);
            this.Controls.SetChildIndex(this.dgvDetails, 0);
            this.Controls.SetChildIndex(this.dgvBarcodes, 0);
            this.pnlDocHeader.ResumeLayout(false);
            this.pnlDocHeader.PerformLayout();
            this.pnlHeaderContent.ResumeLayout(false);
            this.pnlBarcode.ResumeLayout(false);
            this.pnlBarcode.PerformLayout();
            this.scHeaderMainLayout.Panel1.ResumeLayout(false);
            this.scHeaderMainLayout.Panel1.PerformLayout();
            this.scHeaderMainLayout.Panel2.ResumeLayout(false);
            this.scHeaderMainLayout.Panel2.PerformLayout();
            this.scHeaderMainLayout.ResumeLayout(false);
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scannedBarcodesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDocHeader;
        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton btnSetBoxBarcode;
        private System.Windows.Forms.Panel pnlHeaderContent;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.Label lblVendorLot;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblManufacturerName;
        private System.Windows.Forms.SplitContainer scHeaderMainLayout;
        private System.Windows.Forms.Label lblManufacturerNameValue;
        private System.Windows.Forms.Label lblBatchIDValue;
        private System.Windows.Forms.Label lblVendorLotValue;
        private System.Windows.Forms.Label lblItemIDValue;
        private System.Windows.Forms.Label lblItemNameValue;
        private System.Windows.Forms.Label lblItemsInBox;
        private System.Windows.Forms.Label lblUnitOfMeasure;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Label lblBoxesCount;
        private System.Windows.Forms.Label lblTotalCountValue;
        private System.Windows.Forms.Label lblBoxesCountValue;
        private System.Windows.Forms.Label lblItemsCountValue;
        private System.Windows.Forms.Label lblItemsInBoxValue;
        private System.Windows.Forms.Label lblUnitOfMeasureValue;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.BindingSource docLinesBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.DocLinesTableAdapter docLinesTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn colSnowflake;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTinBXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bXQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton btnApply;
        private System.Windows.Forms.Panel pnlBarcode;
        private System.Windows.Forms.Label lblScanerAction;
        private WMSOffice.Controls.TextBoxScaner textBoxScaner;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUndoLotReceipt;
        private System.Windows.Forms.DataGridView dgvBarcodes;
        private System.Windows.Forms.BindingSource scannedBarcodesBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.ScannedBarcodesTableAdapter scannedBarcodesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
    }
}