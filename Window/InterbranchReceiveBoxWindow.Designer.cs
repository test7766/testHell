namespace WMSOffice.Window
{
    partial class InterbranchReceiveBoxWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsLines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.miUndoDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.clSnowflake = new System.Windows.Forms.DataGridViewImageColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNoItem = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.clDocQtyNtv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocQtyBoy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocQtyDefect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsReceiveBoxRows = new System.Windows.Forms.BindingSource(this.components);
            this.interbranch = new WMSOffice.Data.Interbranch();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.rtlInstruction = new RichTextLabelDemoCS.RichTextLabel();
            this.spcHeader = new System.Windows.Forms.SplitContainer();
            this.lblItemBarcodeHeader = new System.Windows.Forms.Label();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.tsDoc = new System.Windows.Forms.ToolStrip();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.tssAfterUndo = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddItem = new System.Windows.Forms.ToolStripButton();
            this.tssAfterAddItem = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.btnUndoDoc = new System.Windows.Forms.ToolStripButton();
            this.pnlReceiveInfo = new System.Windows.Forms.Panel();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.lblItemsCountDescription = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblBarcodeDescription = new System.Windows.Forms.Label();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblDocNumberHeader = new System.Windows.Forms.Label();
            this.lblDocTypeHeader = new System.Windows.Forms.Label();
            this.lblDeliveryDescription = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.taReceiveBoxRows = new WMSOffice.Data.InterbranchTableAdapters.ReceiveBoxRowsTableAdapter();
            this.cmsLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsReceiveBoxRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).BeginInit();
            this.pnlDescription.SuspendLayout();
            this.spcHeader.Panel1.SuspendLayout();
            this.spcHeader.Panel2.SuspendLayout();
            this.spcHeader.SuspendLayout();
            this.tsDoc.SuspendLayout();
            this.pnlReceiveInfo.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsLines
            // 
            this.cmsLines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddItem,
            this.miUndo,
            this.miCloseDoc,
            this.miUndoDoc});
            this.cmsLines.Name = "contextMenuStrip1";
            this.cmsLines.Size = new System.Drawing.Size(283, 92);
            // 
            // miAddItem
            // 
            this.miAddItem.Name = "miAddItem";
            this.miAddItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miAddItem.Size = new System.Drawing.Size(282, 22);
            this.miAddItem.Text = "Добавить товар без штрих кода";
            this.miAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // miUndo
            // 
            this.miUndo.Name = "miUndo";
            this.miUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miUndo.Size = new System.Drawing.Size(282, 22);
            this.miUndo.Text = "Отменить последнее действие";
            this.miUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // miCloseDoc
            // 
            this.miCloseDoc.Name = "miCloseDoc";
            this.miCloseDoc.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.miCloseDoc.Size = new System.Drawing.Size(282, 22);
            this.miCloseDoc.Text = "Завершить контроль ящика";
            this.miCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // miUndoDoc
            // 
            this.miUndoDoc.Name = "miUndoDoc";
            this.miUndoDoc.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.miUndoDoc.Size = new System.Drawing.Size(282, 22);
            this.miUndoDoc.Text = "Отменить контроль ящика";
            this.miUndoDoc.Click += new System.EventHandler(this.btnUndoDoc_Click);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSnowflake,
            this.clItemID,
            this.clItemName,
            this.clVendorLot,
            this.clUnitOfMeasure,
            this.clDocQty,
            this.clLocation,
            this.clManufacturer,
            this.clNoItem,
            this.clDocQtyNtv,
            this.clDocQtyBoy,
            this.clDocQtyDefect});
            this.dgvLines.ContextMenuStrip = this.cmsLines;
            this.dgvLines.DataSource = this.bsReceiveBoxRows;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLines.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLines.Location = new System.Drawing.Point(0, 242);
            this.dgvLines.MultiSelect = false;
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(938, 146);
            this.dgvLines.TabIndex = 2;
            this.dgvLines.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvLines_DataError);
            this.dgvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvLines_DataBindingComplete);
            this.dgvLines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLines_CellContentClick);
            // 
            // clSnowflake
            // 
            this.clSnowflake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clSnowflake.HeaderText = "T";
            this.clSnowflake.Name = "clSnowflake";
            this.clSnowflake.ReadOnly = true;
            this.clSnowflake.Width = 24;
            // 
            // clItemID
            // 
            this.clItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItemID.DataPropertyName = "Item_ID";
            this.clItemID.HeaderText = "Код";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 58;
            // 
            // clItemName
            // 
            this.clItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItemName.DataPropertyName = "Item_Name";
            this.clItemName.HeaderText = "Наименование";
            this.clItemName.Name = "clItemName";
            this.clItemName.ReadOnly = true;
            this.clItemName.Width = 131;
            // 
            // clVendorLot
            // 
            this.clVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clVendorLot.DataPropertyName = "Vendor_Lot";
            this.clVendorLot.HeaderText = "Серия";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            this.clVendorLot.Width = 74;
            // 
            // clUnitOfMeasure
            // 
            this.clUnitOfMeasure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clUnitOfMeasure.DataPropertyName = "UnitOfMeasure";
            this.clUnitOfMeasure.HeaderText = "ЕИ";
            this.clUnitOfMeasure.Name = "clUnitOfMeasure";
            this.clUnitOfMeasure.ReadOnly = true;
            this.clUnitOfMeasure.Width = 52;
            // 
            // clDocQty
            // 
            this.clDocQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDocQty.DataPropertyName = "Doc_Qty";
            dataGridViewCellStyle2.Format = "#,##0";
            this.clDocQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.clDocQty.HeaderText = "Кол-во";
            this.clDocQty.Name = "clDocQty";
            this.clDocQty.ReadOnly = true;
            this.clDocQty.Width = 78;
            // 
            // clLocation
            // 
            this.clLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLocation.DataPropertyName = "Location";
            this.clLocation.HeaderText = "Полка";
            this.clLocation.Name = "clLocation";
            this.clLocation.ReadOnly = true;
            this.clLocation.Width = 74;
            // 
            // clManufacturer
            // 
            this.clManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clManufacturer.DataPropertyName = "Manufacturer";
            this.clManufacturer.HeaderText = "Производитель";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.ReadOnly = true;
            this.clManufacturer.Width = 135;
            // 
            // clNoItem
            // 
            this.clNoItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clNoItem.HeaderText = "";
            this.clNoItem.Name = "clNoItem";
            this.clNoItem.ReadOnly = true;
            this.clNoItem.Text = "нет товара";
            this.clNoItem.UseColumnTextForButtonValue = true;
            this.clNoItem.Width = 5;
            // 
            // clDocQtyNtv
            // 
            this.clDocQtyNtv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDocQtyNtv.DataPropertyName = "Doc_Qty_NTV";
            this.clDocQtyNtv.HeaderText = "Кол-во НТВ";
            this.clDocQtyNtv.Name = "clDocQtyNtv";
            this.clDocQtyNtv.ReadOnly = true;
            this.clDocQtyNtv.Width = 101;
            // 
            // clDocQtyBoy
            // 
            this.clDocQtyBoy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDocQtyBoy.DataPropertyName = "Doc_Qty_BOY";
            this.clDocQtyBoy.HeaderText = "Кол-во бой";
            this.clDocQtyBoy.Name = "clDocQtyBoy";
            this.clDocQtyBoy.ReadOnly = true;
            this.clDocQtyBoy.Width = 97;
            // 
            // clDocQtyDefect
            // 
            this.clDocQtyDefect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDocQtyDefect.DataPropertyName = "Doc_Qty_Defect";
            this.clDocQtyDefect.HeaderText = "Кол-во заводского брака";
            this.clDocQtyDefect.Name = "clDocQtyDefect";
            this.clDocQtyDefect.ReadOnly = true;
            this.clDocQtyDefect.Width = 180;
            // 
            // bsReceiveBoxRows
            // 
            this.bsReceiveBoxRows.DataMember = "ReceiveBoxRows";
            this.bsReceiveBoxRows.DataSource = this.interbranch;
            // 
            // interbranch
            // 
            this.interbranch.DataSetName = "Interbranch";
            this.interbranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlDescription
            // 
            this.pnlDescription.Controls.Add(this.rtlInstruction);
            this.pnlDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescription.Location = new System.Drawing.Point(0, 123);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(938, 87);
            this.pnlDescription.TabIndex = 4;
            this.pnlDescription.Visible = false;
            // 
            // rtlInstruction
            // 
            this.rtlInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtlInstruction.Location = new System.Drawing.Point(0, 0);
            this.rtlInstruction.Name = "rtlInstruction";
            this.rtlInstruction.RtfResourceName = "WMSOffice.Dialogs.PickControl.PCInstruction.rtf";
            this.rtlInstruction.Size = new System.Drawing.Size(938, 87);
            this.rtlInstruction.TabIndex = 1;
            // 
            // spcHeader
            // 
            this.spcHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.spcHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcHeader.Location = new System.Drawing.Point(0, 40);
            this.spcHeader.Name = "spcHeader";
            // 
            // spcHeader.Panel1
            // 
            this.spcHeader.Panel1.Controls.Add(this.lblItemBarcodeHeader);
            this.spcHeader.Panel1.Controls.Add(this.tbBarcode);
            this.spcHeader.Panel1.Controls.Add(this.tsDoc);
            // 
            // spcHeader.Panel2
            // 
            this.spcHeader.Panel2.Controls.Add(this.pnlReceiveInfo);
            this.spcHeader.Size = new System.Drawing.Size(938, 83);
            this.spcHeader.SplitterDistance = 562;
            this.spcHeader.TabIndex = 0;
            // 
            // lblItemBarcodeHeader
            // 
            this.lblItemBarcodeHeader.AutoSize = true;
            this.lblItemBarcodeHeader.Location = new System.Drawing.Point(12, 61);
            this.lblItemBarcodeHeader.Name = "lblItemBarcodeHeader";
            this.lblItemBarcodeHeader.Size = new System.Drawing.Size(62, 13);
            this.lblItemBarcodeHeader.TabIndex = 23;
            this.lblItemBarcodeHeader.Text = "Штрих-код:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.ContextMenuStrip = this.cmsLines;
            this.tbBarcode.DelayThreshold = 50;
            this.tbBarcode.Location = new System.Drawing.Point(80, 55);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.Size = new System.Drawing.Size(438, 25);
            this.tbBarcode.TabIndex = 2;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.UseParentFont = false;
            this.tbBarcode.UseScanModeOnly = false;
            this.tbBarcode.TextChanged += new System.EventHandler(this.tbBarcode_TextChanged);
            // 
            // tsDoc
            // 
            this.tsDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.tssAfterUndo,
            this.btnAddItem,
            this.tssAfterAddItem,
            this.btnCloseDoc,
            this.btnUndoDoc});
            this.tsDoc.Location = new System.Drawing.Point(0, 0);
            this.tsDoc.Name = "tsDoc";
            this.tsDoc.Size = new System.Drawing.Size(562, 55);
            this.tsDoc.TabIndex = 4;
            this.tsDoc.Text = "Панель инструментов документа";
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(52, 52);
            this.btnUndo.Text = "Отменить последнее действие";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // tssAfterUndo
            // 
            this.tssAfterUndo.Name = "tssAfterUndo";
            this.tssAfterUndo.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = global::WMSOffice.Properties.Resources.F2;
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(122, 52);
            this.btnAddItem.Text = "Добавить\n\rтовар без\n\rштрих кода";
            this.btnAddItem.ToolTipText = "Добавить товар без штрих кода";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // tssAfterAddItem
            // 
            this.tssAfterAddItem.Name = "tssAfterAddItem";
            this.tssAfterAddItem.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.F4;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(120, 52);
            this.btnCloseDoc.Text = "Завершить\n\r контроль\n\r ящика";
            this.btnCloseDoc.ToolTipText = "Завершить контроль сборочного";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // btnUndoDoc
            // 
            this.btnUndoDoc.Image = global::WMSOffice.Properties.Resources.F8;
            this.btnUndoDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoDoc.Name = "btnUndoDoc";
            this.btnUndoDoc.Size = new System.Drawing.Size(114, 52);
            this.btnUndoDoc.Text = "Отменить\n\r контроль\n\r ящика";
            this.btnUndoDoc.ToolTipText = "Отменить контроль сборочного";
            this.btnUndoDoc.Click += new System.EventHandler(this.btnUndoDoc_Click);
            // 
            // pnlReceiveInfo
            // 
            this.pnlReceiveInfo.Controls.Add(this.lblItemsCount);
            this.pnlReceiveInfo.Controls.Add(this.lblItemsCountDescription);
            this.pnlReceiveInfo.Controls.Add(this.lblBarcode);
            this.pnlReceiveInfo.Controls.Add(this.lblBarcodeDescription);
            this.pnlReceiveInfo.Controls.Add(this.lblDocNumber);
            this.pnlReceiveInfo.Controls.Add(this.lblDocType);
            this.pnlReceiveInfo.Controls.Add(this.lblDelivery);
            this.pnlReceiveInfo.Controls.Add(this.lblDocNumberHeader);
            this.pnlReceiveInfo.Controls.Add(this.lblDocTypeHeader);
            this.pnlReceiveInfo.Controls.Add(this.lblDeliveryDescription);
            this.pnlReceiveInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReceiveInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlReceiveInfo.Name = "pnlReceiveInfo";
            this.pnlReceiveInfo.Size = new System.Drawing.Size(372, 82);
            this.pnlReceiveInfo.TabIndex = 2;
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemsCount.Location = new System.Drawing.Point(268, 15);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(70, 13);
            this.lblItemsCount.TabIndex = 18;
            this.lblItemsCount.Text = "123456789";
            // 
            // lblItemsCountDescription
            // 
            this.lblItemsCountDescription.AutoSize = true;
            this.lblItemsCountDescription.Location = new System.Drawing.Point(180, 15);
            this.lblItemsCountDescription.Name = "lblItemsCountDescription";
            this.lblItemsCountDescription.Size = new System.Drawing.Size(82, 13);
            this.lblItemsCountDescription.TabIndex = 17;
            this.lblItemsCountDescription.Text = "Кол-во товара:";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBarcode.Location = new System.Drawing.Point(86, 15);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(70, 13);
            this.lblBarcode.TabIndex = 16;
            this.lblBarcode.Text = "123456789";
            // 
            // lblBarcodeDescription
            // 
            this.lblBarcodeDescription.AutoSize = true;
            this.lblBarcodeDescription.Location = new System.Drawing.Point(13, 15);
            this.lblBarcodeDescription.Name = "lblBarcodeDescription";
            this.lblBarcodeDescription.Size = new System.Drawing.Size(39, 13);
            this.lblBarcodeDescription.TabIndex = 15;
            this.lblBarcodeDescription.Text = "Ящик:";
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocNumber.Location = new System.Drawing.Point(86, 37);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(70, 13);
            this.lblDocNumber.TabIndex = 14;
            this.lblDocNumber.Text = "123456789";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocType.Location = new System.Drawing.Point(268, 37);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(21, 13);
            this.lblDocType.TabIndex = 13;
            this.lblDocType.Text = "01";
            // 
            // lblDelivery
            // 
            this.lblDelivery.AutoSize = true;
            this.lblDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDelivery.Location = new System.Drawing.Point(88, 60);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(262, 13);
            this.lblDelivery.TabIndex = 12;
            this.lblDelivery.Text = "(12345) НАИМЕНОВАНИЕ КЛИЕНТА, КИЕВ";
            // 
            // lblDocNumberHeader
            // 
            this.lblDocNumberHeader.AutoSize = true;
            this.lblDocNumberHeader.Location = new System.Drawing.Point(13, 37);
            this.lblDocNumberHeader.Name = "lblDocNumberHeader";
            this.lblDocNumberHeader.Size = new System.Drawing.Size(60, 13);
            this.lblDocNumberHeader.TabIndex = 7;
            this.lblDocNumberHeader.Text = "№ заказа:";
            // 
            // lblDocTypeHeader
            // 
            this.lblDocTypeHeader.AutoSize = true;
            this.lblDocTypeHeader.Location = new System.Drawing.Point(180, 37);
            this.lblDocTypeHeader.Name = "lblDocTypeHeader";
            this.lblDocTypeHeader.Size = new System.Drawing.Size(68, 13);
            this.lblDocTypeHeader.TabIndex = 6;
            this.lblDocTypeHeader.Text = "Тип заказа:";
            // 
            // lblDeliveryDescription
            // 
            this.lblDeliveryDescription.AutoSize = true;
            this.lblDeliveryDescription.Location = new System.Drawing.Point(13, 60);
            this.lblDeliveryDescription.Name = "lblDeliveryDescription";
            this.lblDeliveryDescription.Size = new System.Drawing.Size(69, 13);
            this.lblDeliveryDescription.TabIndex = 4;
            this.lblDeliveryDescription.Text = "Получатель:";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.Info;
            this.pnlInfo.Controls.Add(this.lblInfo);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 210);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(938, 32);
            this.pnlInfo.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInfo.Location = new System.Drawing.Point(12, 3);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(462, 24);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Отсканируйте все места транспортной паллеты...";
            // 
            // taReceiveBoxRows
            // 
            this.taReceiveBoxRows.ClearBeforeFill = true;
            // 
            // InterbranchReceiveBoxWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 388);
            this.Controls.Add(this.dgvLines);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlDescription);
            this.Controls.Add(this.spcHeader);
            this.Name = "InterbranchReceiveBoxWindow";
            this.Text = "* Контроль содержимого ящика";
            this.Load += new System.EventHandler(this.PickControlWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PickControlWindow_FormClosing);
            this.Controls.SetChildIndex(this.spcHeader, 0);
            this.Controls.SetChildIndex(this.pnlDescription, 0);
            this.Controls.SetChildIndex(this.pnlInfo, 0);
            this.Controls.SetChildIndex(this.dgvLines, 0);
            this.cmsLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsReceiveBoxRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).EndInit();
            this.pnlDescription.ResumeLayout(false);
            this.spcHeader.Panel1.ResumeLayout(false);
            this.spcHeader.Panel1.PerformLayout();
            this.spcHeader.Panel2.ResumeLayout(false);
            this.spcHeader.ResumeLayout(false);
            this.tsDoc.ResumeLayout(false);
            this.tsDoc.PerformLayout();
            this.pnlReceiveInfo.ResumeLayout(false);
            this.pnlReceiveInfo.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.ContextMenuStrip cmsLines;
        private System.Windows.Forms.ToolStripMenuItem miUndo;
        private System.Windows.Forms.ToolStripMenuItem miCloseDoc;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.ToolStripMenuItem miUndoDoc;
        private RichTextLabelDemoCS.RichTextLabel rtlInstruction;
        private System.Windows.Forms.SplitContainer spcHeader;
        private System.Windows.Forms.ToolStrip tsDoc;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator tssAfterUndo;
        private System.Windows.Forms.ToolStripButton btnAddItem;
        private System.Windows.Forms.ToolStripSeparator tssAfterAddItem;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.ToolStripButton btnUndoDoc;
        private System.Windows.Forms.Label lblItemBarcodeHeader;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.Panel pnlReceiveInfo;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label lblDocNumberHeader;
        private System.Windows.Forms.Label lblDocTypeHeader;
        private System.Windows.Forms.Label lblDeliveryDescription;
        private System.Windows.Forms.ToolStripMenuItem miAddItem;
        private System.Windows.Forms.Label lblBarcodeDescription;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Label lblItemsCountDescription;
        private System.Windows.Forms.BindingSource bsReceiveBoxRows;
        private WMSOffice.Data.Interbranch interbranch;
        private WMSOffice.Data.InterbranchTableAdapters.ReceiveBoxRowsTableAdapter taReceiveBoxRows;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridViewImageColumn clSnowflake;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private DataGridViewDisableButtonColumn clNoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocQtyNtv;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocQtyBoy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocQtyDefect;
    }
}