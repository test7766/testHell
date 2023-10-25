namespace WMSOffice.Window
{
    partial class PickControlWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickControlWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.miUndoDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintYellowEtic = new System.Windows.Forms.ToolStripMenuItem();
            this.miSelectNextBox = new System.Windows.Forms.ToolStripMenuItem();
            this.gvLines = new System.Windows.Forms.DataGridView();
            this.docRowsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.richTextLabel1 = new RichTextLabelDemoCS.RichTextLabel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tsBarCodeAcquireSelector = new System.Windows.Forms.ToolStrip();
            this.btnEnableAcquireBarCodeFromTerminal = new System.Windows.Forms.ToolStripButton();
            this.btnEnableNTVRegisterMode = new System.Windows.Forms.ToolStripButton();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.btnUndoDoc = new System.Windows.Forms.ToolStripButton();
            this.btnSelectNextBox = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPriorityInstructionHeader = new System.Windows.Forms.Label();
            this.lblPriorityInstruction = new System.Windows.Forms.Label();
            this.lblContainer = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblRegim = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.docRowsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.DocRowsTableAdapter();
            this.lblSpecInstruction = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblQuantityChange = new System.Windows.Forms.Label();
            this.lblVendorLotChange = new System.Windows.Forms.Label();
            this.tsContainers = new System.Windows.Forms.ToolStrip();
            this.lblContainers = new System.Windows.Forms.ToolStripLabel();
            this.btnSurplusContainerActions = new System.Windows.Forms.ToolStripSplitButton();
            this.miOpenSurplusContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseSurplusContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSurplusContainerNumber = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNTVContainerActions = new System.Windows.Forms.ToolStripSplitButton();
            this.miOpenNTVContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseNTVContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNTVContainerNumber = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPickControlVariances = new System.Windows.Forms.ToolStripLabel();
            this.sbPreviewPickControlSurplus = new System.Windows.Forms.ToolStripButton();
            this.sbPreviewPickControlNTV = new System.Windows.Forms.ToolStripButton();
            this.colSnowflake = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty_Scanned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty_Need = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EticCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line_Type_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line_Type_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoItem = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.colCollectors = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.colProperVendorLots = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.colDocRowDetails = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.WeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docRowsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.pnlDescription.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tsBarCodeAcquireSelector.SuspendLayout();
            this.toolStripDoc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.tsContainers.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddItem,
            this.miAddItem2,
            this.miUndo,
            this.miCloseDoc,
            this.miUndoDoc,
            this.miPrintYellowEtic,
            this.miSelectNextBox});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(326, 158);
            // 
            // miAddItem
            // 
            this.miAddItem.Name = "miAddItem";
            this.miAddItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.miAddItem.Size = new System.Drawing.Size(325, 22);
            this.miAddItem.Text = "Добавить товар без штрих кода";
            this.miAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // miAddItem2
            // 
            this.miAddItem2.Name = "miAddItem2";
            this.miAddItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miAddItem2.Size = new System.Drawing.Size(325, 22);
            this.miAddItem2.Text = "Добавить товар без штрих кода";
            this.miAddItem2.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // miUndo
            // 
            this.miUndo.Name = "miUndo";
            this.miUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miUndo.Size = new System.Drawing.Size(325, 22);
            this.miUndo.Text = "Отменить последнее действие";
            this.miUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // miCloseDoc
            // 
            this.miCloseDoc.Name = "miCloseDoc";
            this.miCloseDoc.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.miCloseDoc.Size = new System.Drawing.Size(325, 22);
            this.miCloseDoc.Text = "Завершить контроль сборочного";
            this.miCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // miUndoDoc
            // 
            this.miUndoDoc.Name = "miUndoDoc";
            this.miUndoDoc.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.miUndoDoc.Size = new System.Drawing.Size(325, 22);
            this.miUndoDoc.Text = "Отменить контроль сборочного";
            this.miUndoDoc.Click += new System.EventHandler(this.btnUndoDoc_Click);
            // 
            // miPrintYellowEtic
            // 
            this.miPrintYellowEtic.Name = "miPrintYellowEtic";
            this.miPrintYellowEtic.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.miPrintYellowEtic.Size = new System.Drawing.Size(325, 22);
            this.miPrintYellowEtic.Text = "Напечатать штрих код на заводской ящик";
            this.miPrintYellowEtic.Click += new System.EventHandler(this.miPrintYellowEtic_Click);
            // 
            // miSelectNextBox
            // 
            this.miSelectNextBox.Name = "miSelectNextBox";
            this.miSelectNextBox.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.miSelectNextBox.Size = new System.Drawing.Size(325, 22);
            this.miSelectNextBox.Text = "Следующий ящик";
            this.miSelectNextBox.Click += new System.EventHandler(this.btnSelectNextBox_Click);
            // 
            // gvLines
            // 
            this.gvLines.AllowUserToAddRows = false;
            this.gvLines.AllowUserToResizeRows = false;
            this.gvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvLines.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSnowflake,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.Qty_Scanned,
            this.Qty_Need,
            this.docQtyDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.OrdCode,
            this.EticCode,
            this.Line_Type_id,
            this.Line_Type_Desc,
            this.colNoItem,
            this.colCollectors,
            this.colProperVendorLots,
            this.colDocRowDetails,
            this.WeightColumn});
            this.gvLines.ContextMenuStrip = this.contextMenuStrip1;
            this.gvLines.DataSource = this.docRowsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLines.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvLines.Location = new System.Drawing.Point(0, 277);
            this.gvLines.MultiSelect = false;
            this.gvLines.Name = "gvLines";
            this.gvLines.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvLines.RowHeadersVisible = false;
            this.gvLines.RowHeadersWidth = 5;
            this.gvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLines.Size = new System.Drawing.Size(1184, 326);
            this.gvLines.TabIndex = 2;
            this.gvLines.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvLines_UserDeletingRow);
            this.gvLines.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gvLines_UserDeletedRow);
            this.gvLines.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvLines_CellMouseDoubleClick);
            this.gvLines.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvLines_DataError);
            this.gvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvLines_DataBindingComplete);
            this.gvLines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLines_CellContentClick);
            // 
            // docRowsBindingSource
            // 
            this.docRowsBindingSource.DataMember = "DocRows";
            this.docRowsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlDescription
            // 
            this.pnlDescription.Controls.Add(this.richTextLabel1);
            this.pnlDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescription.Location = new System.Drawing.Point(0, 40);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(1184, 81);
            this.pnlDescription.TabIndex = 4;
            this.pnlDescription.Visible = false;
            // 
            // richTextLabel1
            // 
            this.richTextLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextLabel1.Location = new System.Drawing.Point(0, 0);
            this.richTextLabel1.Name = "richTextLabel1";
            this.richTextLabel1.RtfResourceName = "WMSOffice.Dialogs.PickControl.PCInstruction.rtf";
            this.richTextLabel1.Size = new System.Drawing.Size(1184, 81);
            this.richTextLabel1.TabIndex = 1;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 143);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tsBarCodeAcquireSelector);
            this.scMain.Panel1.Controls.Add(this.label10);
            this.scMain.Panel1.Controls.Add(this.tbBarcode);
            this.scMain.Panel1.Controls.Add(this.toolStripDoc);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.panel1);
            this.scMain.Size = new System.Drawing.Size(1184, 100);
            this.scMain.SplitterDistance = 600;
            this.scMain.TabIndex = 0;
            // 
            // tsBarCodeAcquireSelector
            // 
            this.tsBarCodeAcquireSelector.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBarCodeAcquireSelector.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsBarCodeAcquireSelector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnableAcquireBarCodeFromTerminal,
            this.btnEnableNTVRegisterMode});
            this.tsBarCodeAcquireSelector.Location = new System.Drawing.Point(261, 55);
            this.tsBarCodeAcquireSelector.Name = "tsBarCodeAcquireSelector";
            this.tsBarCodeAcquireSelector.Size = new System.Drawing.Size(193, 39);
            this.tsBarCodeAcquireSelector.TabIndex = 24;
            this.tsBarCodeAcquireSelector.Text = "toolStrip1";
            // 
            // btnEnableAcquireBarCodeFromTerminal
            // 
            this.btnEnableAcquireBarCodeFromTerminal.Image = global::WMSOffice.Properties.Resources.qrcode;
            this.btnEnableAcquireBarCodeFromTerminal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnableAcquireBarCodeFromTerminal.Name = "btnEnableAcquireBarCodeFromTerminal";
            this.btnEnableAcquireBarCodeFromTerminal.Size = new System.Drawing.Size(100, 36);
            this.btnEnableAcquireBarCodeFromTerminal.Text = "Получить\nШ/К с ТСД";
            this.btnEnableAcquireBarCodeFromTerminal.Click += new System.EventHandler(this.btnEnableAcquireBarCodeFromTerminal_Click);
            // 
            // btnEnableNTVRegisterMode
            // 
            this.btnEnableNTVRegisterMode.Image = global::WMSOffice.Properties.Resources.hand_yellow_card;
            this.btnEnableNTVRegisterMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnableNTVRegisterMode.Name = "btnEnableNTVRegisterMode";
            this.btnEnableNTVRegisterMode.Size = new System.Drawing.Size(81, 36);
            this.btnEnableNTVRegisterMode.Text = "Режим\nНТВ";
            this.btnEnableNTVRegisterMode.Click += new System.EventHandler(this.btnEnableNTVRegisterMode_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Штрих-код:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.ContextMenuStrip = this.contextMenuStrip1;
            this.tbBarcode.DelayThreshold = 50;
            this.tbBarcode.Location = new System.Drawing.Point(66, 62);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.ScannerListener = null;
            this.tbBarcode.Size = new System.Drawing.Size(200, 25);
            this.tbBarcode.TabIndex = 2;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.UseParentFont = false;
            this.tbBarcode.UseScanModeOnly = false;
            this.tbBarcode.TextChanged += new System.EventHandler(this.tbBarcode_TextChanged);
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.toolStripSeparator2,
            this.btnAddItem,
            this.toolStripSeparator1,
            this.btnCloseDoc,
            this.btnUndoDoc,
            this.btnSelectNextBox});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(600, 55);
            this.toolStripDoc.TabIndex = 4;
            this.toolStripDoc.Text = "Панель инструментов документа";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = global::WMSOffice.Properties.Resources.F2;
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(123, 52);
            this.btnAddItem.Text = "Добавить\n\rтовар без\n\rштрих кода";
            this.btnAddItem.ToolTipText = "Добавить товар без штрих кода";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.F4;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(129, 52);
            this.btnCloseDoc.Text = "Завершить\n\r контроль\n\r сборочного";
            this.btnCloseDoc.ToolTipText = "Завершить контроль сборочного";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // btnUndoDoc
            // 
            this.btnUndoDoc.Image = global::WMSOffice.Properties.Resources.F8;
            this.btnUndoDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoDoc.Name = "btnUndoDoc";
            this.btnUndoDoc.Size = new System.Drawing.Size(129, 52);
            this.btnUndoDoc.Text = "Отменить\n\r контроль\n\r сборочного";
            this.btnUndoDoc.ToolTipText = "Отменить контроль сборочного";
            this.btnUndoDoc.Click += new System.EventHandler(this.btnUndoDoc_Click);
            // 
            // btnSelectNextBox
            // 
            this.btnSelectNextBox.Image = global::WMSOffice.Properties.Resources.F9;
            this.btnSelectNextBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectNextBox.Name = "btnSelectNextBox";
            this.btnSelectNextBox.Size = new System.Drawing.Size(125, 52);
            this.btnSelectNextBox.Text = "Выбрать\nследующий\nящик";
            this.btnSelectNextBox.Click += new System.EventHandler(this.btnSelectNextBox_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPriorityInstructionHeader);
            this.panel1.Controls.Add(this.lblPriorityInstruction);
            this.panel1.Controls.Add(this.lblContainer);
            this.panel1.Controls.Add(this.lblDepartment);
            this.panel1.Controls.Add(this.lblRegim);
            this.panel1.Controls.Add(this.lblDeliveryDate);
            this.panel1.Controls.Add(this.lblDocDate);
            this.panel1.Controls.Add(this.lblDocNumber);
            this.panel1.Controls.Add(this.lblDocType);
            this.panel1.Controls.Add(this.lblDelivery);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 100);
            this.panel1.TabIndex = 2;
            // 
            // lblPriorityInstructionHeader
            // 
            this.lblPriorityInstructionHeader.AutoSize = true;
            this.lblPriorityInstructionHeader.Location = new System.Drawing.Point(13, 77);
            this.lblPriorityInstructionHeader.Name = "lblPriorityInstructionHeader";
            this.lblPriorityInstructionHeader.Size = new System.Drawing.Size(85, 13);
            this.lblPriorityInstructionHeader.TabIndex = 21;
            this.lblPriorityInstructionHeader.Text = "Рекомендации:";
            // 
            // lblPriorityInstruction
            // 
            this.lblPriorityInstruction.AutoSize = true;
            this.lblPriorityInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPriorityInstruction.Location = new System.Drawing.Point(122, 77);
            this.lblPriorityInstruction.Name = "lblPriorityInstruction";
            this.lblPriorityInstruction.Size = new System.Drawing.Size(262, 13);
            this.lblPriorityInstruction.TabIndex = 20;
            this.lblPriorityInstruction.Text = "(12345) НАИМЕНОВАНИЕ КЛИЕНТА, КИЕВ";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblContainer.Location = new System.Drawing.Point(271, 9);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(22, 13);
            this.lblContainer.TabIndex = 17;
            this.lblContainer.Text = "A1";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDepartment.Location = new System.Drawing.Point(346, 9);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(247, 13);
            this.lblDepartment.TabIndex = 19;
            this.lblDepartment.Text = "Сектор 001-019";
            // 
            // lblRegim
            // 
            this.lblRegim.AutoSize = true;
            this.lblRegim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRegim.Location = new System.Drawing.Point(350, 43);
            this.lblRegim.Name = "lblRegim";
            this.lblRegim.Size = new System.Drawing.Size(97, 13);
            this.lblRegim.TabIndex = 18;
            this.lblRegim.Text = "Доставка день";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDeliveryDate.Location = new System.Drawing.Point(122, 43);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(71, 13);
            this.lblDeliveryDate.TabIndex = 16;
            this.lblDeliveryDate.Text = "21.04.2010";
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocDate.Location = new System.Drawing.Point(122, 26);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(71, 13);
            this.lblDocDate.TabIndex = 15;
            this.lblDocDate.Text = "21.04.2010";
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocNumber.Location = new System.Drawing.Point(365, 26);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(70, 13);
            this.lblDocNumber.TabIndex = 14;
            this.lblDocNumber.Text = "123456789";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocType.Location = new System.Drawing.Point(271, 26);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(21, 13);
            this.lblDocType.TabIndex = 13;
            this.lblDocType.Text = "01";
            // 
            // lblDelivery
            // 
            this.lblDelivery.AutoSize = true;
            this.lblDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDelivery.Location = new System.Drawing.Point(122, 60);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(262, 13);
            this.lblDelivery.TabIndex = 12;
            this.lblDelivery.Text = "(12345) НАИМЕНОВАНИЕ КЛИЕНТА, КИЕВ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Режим:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Дата доставки:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Контейнер:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Дата заказа:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "№ заказа:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Тип заказа:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отдел:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Получатель:";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumber.Location = new System.Drawing.Point(122, 9);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(70, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "123456789";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сборочный лист №";
            // 
            // docRowsTableAdapter
            // 
            this.docRowsTableAdapter.ClearBeforeFill = true;
            // 
            // lblSpecInstruction
            // 
            this.lblSpecInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSpecInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSpecInstruction.Location = new System.Drawing.Point(0, 121);
            this.lblSpecInstruction.Name = "lblSpecInstruction";
            this.lblSpecInstruction.Size = new System.Drawing.Size(1184, 22);
            this.lblSpecInstruction.TabIndex = 2;
            this.lblSpecInstruction.Text = "Обмотайте зеленым скотчем";
            this.lblSpecInstruction.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblDelete);
            this.pnlFooter.Controls.Add(this.lblQuantityChange);
            this.pnlFooter.Controls.Add(this.lblVendorLotChange);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 606);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1184, 35);
            this.pnlFooter.TabIndex = 7;
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDelete.ForeColor = System.Drawing.Color.Gray;
            this.lblDelete.Location = new System.Drawing.Point(569, 7);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(215, 20);
            this.lblDelete.TabIndex = 2;
            this.lblDelete.Text = "DEL - удаление позиции";
            this.lblDelete.Visible = false;
            // 
            // lblQuantityChange
            // 
            this.lblQuantityChange.AutoSize = true;
            this.lblQuantityChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuantityChange.Location = new System.Drawing.Point(265, 7);
            this.lblQuantityChange.Name = "lblQuantityChange";
            this.lblQuantityChange.Size = new System.Drawing.Size(258, 20);
            this.lblQuantityChange.TabIndex = 1;
            this.lblQuantityChange.Text = "CTRL+Q - замена количества";
            // 
            // lblVendorLotChange
            // 
            this.lblVendorLotChange.AutoSize = true;
            this.lblVendorLotChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVendorLotChange.Location = new System.Drawing.Point(12, 7);
            this.lblVendorLotChange.Name = "lblVendorLotChange";
            this.lblVendorLotChange.Size = new System.Drawing.Size(207, 20);
            this.lblVendorLotChange.TabIndex = 0;
            this.lblVendorLotChange.Text = "CTRL+S - замена серии";
            // 
            // tsContainers
            // 
            this.tsContainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsContainers.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsContainers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblContainers,
            this.btnSurplusContainerActions,
            this.lblSurplusContainerNumber,
            this.toolStripSeparator3,
            this.btnNTVContainerActions,
            this.lblNTVContainerNumber,
            this.toolStripSeparator4,
            this.lblPickControlVariances,
            this.sbPreviewPickControlSurplus,
            this.sbPreviewPickControlNTV});
            this.tsContainers.Location = new System.Drawing.Point(0, 243);
            this.tsContainers.Name = "tsContainers";
            this.tsContainers.Size = new System.Drawing.Size(1184, 31);
            this.tsContainers.TabIndex = 0;
            this.tsContainers.Text = "toolStrip1";
            // 
            // lblContainers
            // 
            this.lblContainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblContainers.Name = "lblContainers";
            this.lblContainers.Size = new System.Drawing.Size(117, 28);
            this.lblContainers.Text = "Контейнеры:";
            // 
            // btnSurplusContainerActions
            // 
            this.btnSurplusContainerActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSurplusContainerActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenSurplusContainer,
            this.miCloseSurplusContainer});
            this.btnSurplusContainerActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSurplusContainerActions.Image = ((System.Drawing.Image)(resources.GetObject("btnSurplusContainerActions.Image")));
            this.btnSurplusContainerActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSurplusContainerActions.Name = "btnSurplusContainerActions";
            this.btnSurplusContainerActions.Size = new System.Drawing.Size(102, 28);
            this.btnSurplusContainerActions.Text = "Излишков";
            this.btnSurplusContainerActions.ButtonClick += new System.EventHandler(this.btnSurplusContainerActions_ButtonClick);
            // 
            // miOpenSurplusContainer
            // 
            this.miOpenSurplusContainer.Name = "miOpenSurplusContainer";
            this.miOpenSurplusContainer.Size = new System.Drawing.Size(145, 24);
            this.miOpenSurplusContainer.Text = "Открыть";
            this.miOpenSurplusContainer.Click += new System.EventHandler(this.miOpenSurplusContainer_Click);
            // 
            // miCloseSurplusContainer
            // 
            this.miCloseSurplusContainer.Name = "miCloseSurplusContainer";
            this.miCloseSurplusContainer.Size = new System.Drawing.Size(145, 24);
            this.miCloseSurplusContainer.Text = "Закрыть";
            this.miCloseSurplusContainer.Click += new System.EventHandler(this.miCloseSurplusContainer_Click);
            // 
            // lblSurplusContainerNumber
            // 
            this.lblSurplusContainerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSurplusContainerNumber.ForeColor = System.Drawing.Color.Blue;
            this.lblSurplusContainerNumber.Name = "lblSurplusContainerNumber";
            this.lblSurplusContainerNumber.Size = new System.Drawing.Size(206, 28);
            this.lblSurplusContainerNumber.Text = "{№ контейнера излишков}";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // btnNTVContainerActions
            // 
            this.btnNTVContainerActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNTVContainerActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenNTVContainer,
            this.miCloseNTVContainer});
            this.btnNTVContainerActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNTVContainerActions.Image = ((System.Drawing.Image)(resources.GetObject("btnNTVContainerActions.Image")));
            this.btnNTVContainerActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNTVContainerActions.Name = "btnNTVContainerActions";
            this.btnNTVContainerActions.Size = new System.Drawing.Size(57, 28);
            this.btnNTVContainerActions.Text = "НТВ";
            this.btnNTVContainerActions.ButtonClick += new System.EventHandler(this.btnNTVContainerActions_ButtonClick);
            // 
            // miOpenNTVContainer
            // 
            this.miOpenNTVContainer.Name = "miOpenNTVContainer";
            this.miOpenNTVContainer.Size = new System.Drawing.Size(145, 24);
            this.miOpenNTVContainer.Text = "Открыть";
            this.miOpenNTVContainer.Click += new System.EventHandler(this.miOpenNTVContainer_Click);
            // 
            // miCloseNTVContainer
            // 
            this.miCloseNTVContainer.Name = "miCloseNTVContainer";
            this.miCloseNTVContainer.Size = new System.Drawing.Size(145, 24);
            this.miCloseNTVContainer.Text = "Закрыть";
            this.miCloseNTVContainer.Click += new System.EventHandler(this.miCloseNTVContainer_Click);
            // 
            // lblNTVContainerNumber
            // 
            this.lblNTVContainerNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNTVContainerNumber.ForeColor = System.Drawing.Color.Blue;
            this.lblNTVContainerNumber.Name = "lblNTVContainerNumber";
            this.lblNTVContainerNumber.Size = new System.Drawing.Size(163, 28);
            this.lblNTVContainerNumber.Text = "{№ контейнера НТВ}";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // lblPickControlVariances
            // 
            this.lblPickControlVariances.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPickControlVariances.Name = "lblPickControlVariances";
            this.lblPickControlVariances.Size = new System.Drawing.Size(236, 28);
            this.lblPickControlVariances.Text = "Расхождения на контроле:";
            // 
            // sbPreviewPickControlSurplus
            // 
            this.sbPreviewPickControlSurplus.Image = global::WMSOffice.Properties.Resources.view;
            this.sbPreviewPickControlSurplus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPreviewPickControlSurplus.Name = "sbPreviewPickControlSurplus";
            this.sbPreviewPickControlSurplus.Size = new System.Drawing.Size(105, 28);
            this.sbPreviewPickControlSurplus.Text = "Излишки";
            this.sbPreviewPickControlSurplus.Click += new System.EventHandler(this.sbPreviewPickControlSurplus_Click);
            // 
            // sbPreviewPickControlNTV
            // 
            this.sbPreviewPickControlNTV.Image = global::WMSOffice.Properties.Resources.view;
            this.sbPreviewPickControlNTV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPreviewPickControlNTV.Name = "sbPreviewPickControlNTV";
            this.sbPreviewPickControlNTV.Size = new System.Drawing.Size(69, 28);
            this.sbPreviewPickControlNTV.Text = "НТВ";
            this.sbPreviewPickControlNTV.Click += new System.EventHandler(this.sbPreviewPickControlNTV_Click);
            // 
            // colSnowflake
            // 
            this.colSnowflake.HeaderText = "T";
            this.colSnowflake.Name = "colSnowflake";
            this.colSnowflake.ReadOnly = true;
            this.colSnowflake.Width = 24;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 58;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 131;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 74;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 40;
            // 
            // Qty_Scanned
            // 
            this.Qty_Scanned.DataPropertyName = "Qty_Scanned";
            this.Qty_Scanned.HeaderText = "Отсканировано ранее, шт.";
            this.Qty_Scanned.Name = "Qty_Scanned";
            this.Qty_Scanned.ReadOnly = true;
            this.Qty_Scanned.ToolTipText = "Сколько было отсканировано при первом контроле";
            this.Qty_Scanned.Width = 115;
            // 
            // Qty_Need
            // 
            this.Qty_Need.DataPropertyName = "Qty_Need";
            this.Qty_Need.HeaderText = "Заявлено в сборочном, шт.";
            this.Qty_Need.Name = "Qty_Need";
            this.Qty_Need.ReadOnly = true;
            this.Qty_Need.ToolTipText = "Сколько должно быть, т.е. сколько в сборочном";
            this.Qty_Need.Width = 90;
            // 
            // docQtyDataGridViewTextBoxColumn
            // 
            this.docQtyDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty";
            dataGridViewCellStyle2.Format = "#,##0";
            this.docQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.docQtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.docQtyDataGridViewTextBoxColumn.Name = "docQtyDataGridViewTextBoxColumn";
            this.docQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyDataGridViewTextBoxColumn.Width = 60;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 185;
            // 
            // OrdCode
            // 
            this.OrdCode.DataPropertyName = "OrdCode";
            this.OrdCode.HeaderText = "№ заказа";
            this.OrdCode.Name = "OrdCode";
            this.OrdCode.ReadOnly = true;
            this.OrdCode.Width = 95;
            // 
            // EticCode
            // 
            this.EticCode.DataPropertyName = "EticCode";
            this.EticCode.HeaderText = "Код этикетки";
            this.EticCode.Name = "EticCode";
            this.EticCode.ReadOnly = true;
            this.EticCode.Width = 95;
            // 
            // Line_Type_id
            // 
            this.Line_Type_id.DataPropertyName = "Line_Type_id";
            this.Line_Type_id.HeaderText = "Код типа расхождения";
            this.Line_Type_id.Name = "Line_Type_id";
            this.Line_Type_id.ReadOnly = true;
            this.Line_Type_id.Visible = false;
            // 
            // Line_Type_Desc
            // 
            this.Line_Type_Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Line_Type_Desc.DataPropertyName = "Line_Type_Desc";
            this.Line_Type_Desc.HeaderText = "Тип расхождения";
            this.Line_Type_Desc.Name = "Line_Type_Desc";
            this.Line_Type_Desc.ReadOnly = true;
            this.Line_Type_Desc.Visible = false;
            this.Line_Type_Desc.Width = 135;
            // 
            // colNoItem
            // 
            this.colNoItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNoItem.HeaderText = "";
            this.colNoItem.Name = "colNoItem";
            this.colNoItem.ReadOnly = true;
            this.colNoItem.Text = "Нет товара / Подтвердить";
            this.colNoItem.Width = 5;
            // 
            // colCollectors
            // 
            this.colCollectors.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCollectors.HeaderText = "";
            this.colCollectors.Name = "colCollectors";
            this.colCollectors.ReadOnly = true;
            this.colCollectors.Text = "Сборщики";
            this.colCollectors.UseColumnTextForButtonValue = true;
            this.colCollectors.Width = 5;
            // 
            // colProperVendorLots
            // 
            this.colProperVendorLots.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProperVendorLots.HeaderText = "";
            this.colProperVendorLots.Name = "colProperVendorLots";
            this.colProperVendorLots.ReadOnly = true;
            this.colProperVendorLots.Text = "Серии";
            this.colProperVendorLots.UseColumnTextForButtonValue = true;
            this.colProperVendorLots.Width = 5;
            // 
            // colDocRowDetails
            // 
            this.colDocRowDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDocRowDetails.HeaderText = "";
            this.colDocRowDetails.Name = "colDocRowDetails";
            this.colDocRowDetails.ReadOnly = true;
            this.colDocRowDetails.Text = "Детали";
            this.colDocRowDetails.UseColumnTextForButtonValue = true;
            this.colDocRowDetails.Width = 5;
            // 
            // WeightColumn
            // 
            this.WeightColumn.DataPropertyName = "weight";
            this.WeightColumn.HeaderText = "Вес, г";
            this.WeightColumn.Name = "WeightColumn";
            this.WeightColumn.ReadOnly = true;
            this.WeightColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WeightColumn.Visible = false;
            this.WeightColumn.Width = 120;
            // 
            // PickControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.tsContainers);
            this.Controls.Add(this.gvLines);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.lblSpecInstruction);
            this.Controls.Add(this.pnlDescription);
            this.Name = "PickControlWindow";
            this.Text = "* Контроль сборки";
            this.Load += new System.EventHandler(this.PickControlWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PickControlWindow_FormClosing);
            this.Controls.SetChildIndex(this.pnlDescription, 0);
            this.Controls.SetChildIndex(this.lblSpecInstruction, 0);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.Controls.SetChildIndex(this.scMain, 0);
            this.Controls.SetChildIndex(this.gvLines, 0);
            this.Controls.SetChildIndex(this.tsContainers, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docRowsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.pnlDescription.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.tsBarCodeAcquireSelector.ResumeLayout(false);
            this.tsBarCodeAcquireSelector.PerformLayout();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.tsContainers.ResumeLayout(false);
            this.tsContainers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvLines;
        private System.Windows.Forms.BindingSource docRowsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.DocRowsTableAdapter docRowsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miAddItem;
        private System.Windows.Forms.ToolStripMenuItem miUndo;
        private System.Windows.Forms.ToolStripMenuItem miCloseDoc;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.ToolStripMenuItem miUndoDoc;
        private RichTextLabelDemoCS.RichTextLabel richTextLabel1;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAddItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.ToolStripButton btnUndoDoc;
        private System.Windows.Forms.Label label10;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblRegim;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem miAddItem2;
        private System.Windows.Forms.ToolStripMenuItem miPrintYellowEtic;
        private System.Windows.Forms.Label lblSpecInstruction;
        private System.Windows.Forms.Label lblPriorityInstruction;
        private System.Windows.Forms.Label lblPriorityInstructionHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblQuantityChange;
        private System.Windows.Forms.Label lblVendorLotChange;
        private System.Windows.Forms.ToolStrip tsContainers;
        private System.Windows.Forms.ToolStripLabel lblContainers;
        private System.Windows.Forms.ToolStripSplitButton btnSurplusContainerActions;
        private System.Windows.Forms.ToolStripSplitButton btnNTVContainerActions;
        private System.Windows.Forms.ToolStripLabel lblSurplusContainerNumber;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblNTVContainerNumber;
        private System.Windows.Forms.ToolStripMenuItem miOpenSurplusContainer;
        private System.Windows.Forms.ToolStripMenuItem miCloseSurplusContainer;
        private System.Windows.Forms.ToolStripMenuItem miOpenNTVContainer;
        private System.Windows.Forms.ToolStripMenuItem miCloseNTVContainer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton sbPreviewPickControlSurplus;
        private System.Windows.Forms.ToolStripButton sbPreviewPickControlNTV;
        private System.Windows.Forms.ToolStripLabel lblPickControlVariances;
        private System.Windows.Forms.ToolStripButton btnSelectNextBox;
        private System.Windows.Forms.ToolStripMenuItem miSelectNextBox;
        private System.Windows.Forms.ToolStrip tsBarCodeAcquireSelector;
        private System.Windows.Forms.ToolStripButton btnEnableAcquireBarCodeFromTerminal;
        private System.Windows.Forms.ToolStripButton btnEnableNTVRegisterMode;
        private System.Windows.Forms.DataGridViewImageColumn colSnowflake;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty_Scanned;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty_Need;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn EticCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line_Type_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line_Type_Desc;
        private DataGridViewDisableButtonColumn colNoItem;
        private DataGridViewDisableButtonColumn colCollectors;
        private DataGridViewDisableButtonColumn colProperVendorLots;
        private DataGridViewDisableButtonColumn colDocRowDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightColumn;
    }
}