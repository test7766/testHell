namespace WMSOffice.Dialogs.Delivery
{
    partial class ReceiptDebtorsReturnedTareForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tbsTare = new WMSOffice.Controls.TextBoxScaner();
            this.lblScanTare = new System.Windows.Forms.Label();
            this.dgvTare = new System.Windows.Forms.DataGridView();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareReturnByRouteListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.tareReturnByRouteListTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.TareReturnByRouteListTableAdapter();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblScannedReturnedTareQtty = new System.Windows.Forms.Label();
            this.lblScannedItems = new System.Windows.Forms.Label();
            this.scWorkSpace = new System.Windows.Forms.SplitContainer();
            this.scFoolTareByRouteListDetails = new System.Windows.Forms.SplitContainer();
            this.tsTareDetailsMenu = new System.Windows.Forms.ToolStrip();
            this.btnRefreshTareDetails = new System.Windows.Forms.ToolStripButton();
            this.btnShowClientRemains = new System.Windows.Forms.ToolStripButton();
            this.dgvTareDetails = new System.Windows.Forms.DataGridView();
            this.isSelectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cTDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tARENameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntReturnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntremDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullTareByRouteListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvClientRemains = new System.Windows.Forms.DataGridView();
            this.tareTypeDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientTareRemainsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullTareByRouteListTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.FullTareByRouteListTableAdapter();
            this.clientTareRemainsTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.ClientTareRemainsTableAdapter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnManualTareInput = new System.Windows.Forms.ToolStripButton();
            this.pnlManualInput = new System.Windows.Forms.Panel();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareReturnByRouteListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.scWorkSpace.Panel1.SuspendLayout();
            this.scWorkSpace.Panel2.SuspendLayout();
            this.scWorkSpace.SuspendLayout();
            this.scFoolTareByRouteListDetails.Panel1.SuspendLayout();
            this.scFoolTareByRouteListDetails.Panel2.SuspendLayout();
            this.scFoolTareByRouteListDetails.SuspendLayout();
            this.tsTareDetailsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullTareByRouteListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientRemains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientTareRemainsBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlManualInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2111, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2201, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 628);
            this.pnlButtons.Size = new System.Drawing.Size(1319, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.pnlManualInput);
            this.pnlHeader.Controls.Add(this.tbsTare);
            this.pnlHeader.Controls.Add(this.lblScanTare);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(581, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // tbsTare
            // 
            this.tbsTare.AllowType = true;
            this.tbsTare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsTare.AutoConvert = true;
            this.tbsTare.DelayThreshold = 50;
            this.tbsTare.Location = new System.Drawing.Point(205, 7);
            this.tbsTare.Name = "tbsTare";
            this.tbsTare.RaiseTextChangeWithoutEnter = false;
            this.tbsTare.ReadOnly = false;
            this.tbsTare.Size = new System.Drawing.Size(220, 25);
            this.tbsTare.TabIndex = 1;
            this.tbsTare.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsTare.UseParentFont = false;
            this.tbsTare.UseScanModeOnly = false;
            // 
            // lblScanTare
            // 
            this.lblScanTare.AutoSize = true;
            this.lblScanTare.Location = new System.Drawing.Point(12, 13);
            this.lblScanTare.Name = "lblScanTare";
            this.lblScanTare.Size = new System.Drawing.Size(187, 13);
            this.lblScanTare.TabIndex = 0;
            this.lblScanTare.Text = "Отсканируйте ш/к оборотной тары:";
            // 
            // dgvTare
            // 
            this.dgvTare.AllowUserToAddRows = false;
            this.dgvTare.AllowUserToDeleteRows = false;
            this.dgvTare.AllowUserToResizeColumns = false;
            this.dgvTare.AllowUserToResizeRows = false;
            this.dgvTare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTare.AutoGenerateColumns = false;
            this.dgvTare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeDataGridViewTextBoxColumn,
            this.typeDescriptionDataGridViewTextBoxColumn,
            this.itemidDataGridViewTextBoxColumn,
            this.lotnumberDataGridViewTextBoxColumn});
            this.dgvTare.DataSource = this.tareReturnByRouteListBindingSource;
            this.dgvTare.Location = new System.Drawing.Point(3, 56);
            this.dgvTare.MultiSelect = false;
            this.dgvTare.Name = "dgvTare";
            this.dgvTare.ReadOnly = true;
            this.dgvTare.RowHeadersVisible = false;
            this.dgvTare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTare.Size = new System.Drawing.Size(576, 533);
            this.dgvTare.TabIndex = 1;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_code";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // typeDescriptionDataGridViewTextBoxColumn
            // 
            this.typeDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Type_Description";
            this.typeDescriptionDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.typeDescriptionDataGridViewTextBoxColumn.Name = "typeDescriptionDataGridViewTextBoxColumn";
            this.typeDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDescriptionDataGridViewTextBoxColumn.Width = 150;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "Item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lotnumberDataGridViewTextBoxColumn
            // 
            this.lotnumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_number";
            this.lotnumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotnumberDataGridViewTextBoxColumn.Name = "lotnumberDataGridViewTextBoxColumn";
            this.lotnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotnumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // tareReturnByRouteListBindingSource
            // 
            this.tareReturnByRouteListBindingSource.DataMember = "TareReturnByRouteList";
            this.tareReturnByRouteListBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tareReturnByRouteListTableAdapter
            // 
            this.tareReturnByRouteListTableAdapter.ClearBeforeFill = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlFooter.Controls.Add(this.lblScannedReturnedTareQtty);
            this.pnlFooter.Controls.Add(this.lblScannedItems);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 595);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(581, 25);
            this.pnlFooter.TabIndex = 4;
            // 
            // lblScannedReturnedTareQtty
            // 
            this.lblScannedReturnedTareQtty.AutoSize = true;
            this.lblScannedReturnedTareQtty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScannedReturnedTareQtty.ForeColor = System.Drawing.Color.Blue;
            this.lblScannedReturnedTareQtty.Location = new System.Drawing.Point(220, 4);
            this.lblScannedReturnedTareQtty.Name = "lblScannedReturnedTareQtty";
            this.lblScannedReturnedTareQtty.Size = new System.Drawing.Size(16, 16);
            this.lblScannedReturnedTareQtty.TabIndex = 1;
            this.lblScannedReturnedTareQtty.Text = "0";
            // 
            // lblScannedItems
            // 
            this.lblScannedItems.AutoSize = true;
            this.lblScannedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScannedItems.Location = new System.Drawing.Point(12, 6);
            this.lblScannedItems.Name = "lblScannedItems";
            this.lblScannedItems.Size = new System.Drawing.Size(202, 13);
            this.lblScannedItems.TabIndex = 0;
            this.lblScannedItems.Text = "Отсканировано оборотной тары:";
            // 
            // scWorkSpace
            // 
            this.scWorkSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scWorkSpace.Location = new System.Drawing.Point(0, 2);
            this.scWorkSpace.Name = "scWorkSpace";
            // 
            // scWorkSpace.Panel1
            // 
            this.scWorkSpace.Panel1.Controls.Add(this.pnlFooter);
            this.scWorkSpace.Panel1.Controls.Add(this.dgvTare);
            this.scWorkSpace.Panel1.Controls.Add(this.pnlHeader);
            // 
            // scWorkSpace.Panel2
            // 
            this.scWorkSpace.Panel2.Controls.Add(this.scFoolTareByRouteListDetails);
            this.scWorkSpace.Size = new System.Drawing.Size(1319, 620);
            this.scWorkSpace.SplitterDistance = 581;
            this.scWorkSpace.TabIndex = 2;
            // 
            // scFoolTareByRouteListDetails
            // 
            this.scFoolTareByRouteListDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scFoolTareByRouteListDetails.Location = new System.Drawing.Point(0, 0);
            this.scFoolTareByRouteListDetails.Name = "scFoolTareByRouteListDetails";
            this.scFoolTareByRouteListDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scFoolTareByRouteListDetails.Panel1
            // 
            this.scFoolTareByRouteListDetails.Panel1.Controls.Add(this.tsTareDetailsMenu);
            this.scFoolTareByRouteListDetails.Panel1.Controls.Add(this.dgvTareDetails);
            // 
            // scFoolTareByRouteListDetails.Panel2
            // 
            this.scFoolTareByRouteListDetails.Panel2.Controls.Add(this.dgvClientRemains);
            this.scFoolTareByRouteListDetails.Size = new System.Drawing.Size(734, 620);
            this.scFoolTareByRouteListDetails.SplitterDistance = 335;
            this.scFoolTareByRouteListDetails.TabIndex = 0;
            // 
            // tsTareDetailsMenu
            // 
            this.tsTareDetailsMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsTareDetailsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshTareDetails,
            this.btnShowClientRemains});
            this.tsTareDetailsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsTareDetailsMenu.Name = "tsTareDetailsMenu";
            this.tsTareDetailsMenu.Size = new System.Drawing.Size(734, 39);
            this.tsTareDetailsMenu.TabIndex = 1;
            this.tsTareDetailsMenu.Text = "toolStrip1";
            // 
            // btnRefreshTareDetails
            // 
            this.btnRefreshTareDetails.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshTareDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshTareDetails.Name = "btnRefreshTareDetails";
            this.btnRefreshTareDetails.Size = new System.Drawing.Size(97, 36);
            this.btnRefreshTareDetails.Text = "Обновить";
            this.btnRefreshTareDetails.Click += new System.EventHandler(this.btnRefreshDetails_Click);
            // 
            // btnShowClientRemains
            // 
            this.btnShowClientRemains.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowClientRemains.Image = global::WMSOffice.Properties.Resources.paper_box;
            this.btnShowClientRemains.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowClientRemains.Name = "btnShowClientRemains";
            this.btnShowClientRemains.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnShowClientRemains.Size = new System.Drawing.Size(150, 36);
            this.btnShowClientRemains.Text = "Остаток на клиенте";
            this.btnShowClientRemains.Click += new System.EventHandler(this.btnShowClientRemains_Click);
            // 
            // dgvTareDetails
            // 
            this.dgvTareDetails.AllowUserToAddRows = false;
            this.dgvTareDetails.AllowUserToDeleteRows = false;
            this.dgvTareDetails.AllowUserToResizeRows = false;
            this.dgvTareDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTareDetails.AutoGenerateColumns = false;
            this.dgvTareDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTareDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isSelectedDataGridViewCheckBoxColumn,
            this.cTDocDataGridViewTextBoxColumn,
            this.tARENameDataGridViewTextBoxColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.cntReturnDataGridViewTextBoxColumn,
            this.cntremDataGridViewTextBoxColumn,
            this.diffDataGridViewTextBoxColumn});
            this.dgvTareDetails.DataSource = this.fullTareByRouteListBindingSource;
            this.dgvTareDetails.Location = new System.Drawing.Point(3, 56);
            this.dgvTareDetails.MultiSelect = false;
            this.dgvTareDetails.Name = "dgvTareDetails";
            this.dgvTareDetails.RowHeadersVisible = false;
            this.dgvTareDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTareDetails.Size = new System.Drawing.Size(728, 276);
            this.dgvTareDetails.TabIndex = 0;
            this.dgvTareDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTareDetails_CellFormatting);
            this.dgvTareDetails.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTareDetails_CurrentCellDirtyStateChanged);
            this.dgvTareDetails.SelectionChanged += new System.EventHandler(this.dgvTareDetails_SelectionChanged);
            // 
            // isSelectedDataGridViewCheckBoxColumn
            // 
            this.isSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn.HeaderText = "Отм.";
            this.isSelectedDataGridViewCheckBoxColumn.Name = "isSelectedDataGridViewCheckBoxColumn";
            this.isSelectedDataGridViewCheckBoxColumn.Width = 35;
            // 
            // cTDocDataGridViewTextBoxColumn
            // 
            this.cTDocDataGridViewTextBoxColumn.DataPropertyName = "CT_Doc";
            this.cTDocDataGridViewTextBoxColumn.HeaderText = "№ док-та";
            this.cTDocDataGridViewTextBoxColumn.Name = "cTDocDataGridViewTextBoxColumn";
            this.cTDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.cTDocDataGridViewTextBoxColumn.Width = 80;
            // 
            // tARENameDataGridViewTextBoxColumn
            // 
            this.tARENameDataGridViewTextBoxColumn.DataPropertyName = "TARE_Name";
            this.tARENameDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.tARENameDataGridViewTextBoxColumn.Name = "tARENameDataGridViewTextBoxColumn";
            this.tARENameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tARENameDataGridViewTextBoxColumn.Width = 150;
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "Client_Name";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "Наименование ТТ";
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            this.clientNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // cntReturnDataGridViewTextBoxColumn
            // 
            this.cntReturnDataGridViewTextBoxColumn.DataPropertyName = "Cnt_Return";
            this.cntReturnDataGridViewTextBoxColumn.HeaderText = "Возврат, шт.";
            this.cntReturnDataGridViewTextBoxColumn.Name = "cntReturnDataGridViewTextBoxColumn";
            this.cntReturnDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntReturnDataGridViewTextBoxColumn.ToolTipText = "Возврат, шт.";
            this.cntReturnDataGridViewTextBoxColumn.Width = 95;
            // 
            // cntremDataGridViewTextBoxColumn
            // 
            this.cntremDataGridViewTextBoxColumn.DataPropertyName = "Cnt_rem";
            this.cntremDataGridViewTextBoxColumn.HeaderText = "Задолж., шт.";
            this.cntremDataGridViewTextBoxColumn.Name = "cntremDataGridViewTextBoxColumn";
            this.cntremDataGridViewTextBoxColumn.ReadOnly = true;
            this.cntremDataGridViewTextBoxColumn.ToolTipText = "Задолженность, шт.";
            this.cntremDataGridViewTextBoxColumn.Width = 95;
            // 
            // diffDataGridViewTextBoxColumn
            // 
            this.diffDataGridViewTextBoxColumn.DataPropertyName = "Diff";
            this.diffDataGridViewTextBoxColumn.HeaderText = "Разница, шт.";
            this.diffDataGridViewTextBoxColumn.Name = "diffDataGridViewTextBoxColumn";
            this.diffDataGridViewTextBoxColumn.ReadOnly = true;
            this.diffDataGridViewTextBoxColumn.ToolTipText = "Разница, шт.";
            this.diffDataGridViewTextBoxColumn.Width = 95;
            // 
            // fullTareByRouteListBindingSource
            // 
            this.fullTareByRouteListBindingSource.DataMember = "FullTareByRouteList";
            this.fullTareByRouteListBindingSource.DataSource = this.delivery;
            // 
            // dgvClientRemains
            // 
            this.dgvClientRemains.AllowUserToAddRows = false;
            this.dgvClientRemains.AllowUserToDeleteRows = false;
            this.dgvClientRemains.AllowUserToResizeRows = false;
            this.dgvClientRemains.AutoGenerateColumns = false;
            this.dgvClientRemains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientRemains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tareTypeDescriptionDataGridViewTextBoxColumn,
            this.tareBarcodeDataGridViewTextBoxColumn});
            this.dgvClientRemains.DataSource = this.clientTareRemainsBindingSource;
            this.dgvClientRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientRemains.Location = new System.Drawing.Point(0, 0);
            this.dgvClientRemains.MultiSelect = false;
            this.dgvClientRemains.Name = "dgvClientRemains";
            this.dgvClientRemains.ReadOnly = true;
            this.dgvClientRemains.RowHeadersVisible = false;
            this.dgvClientRemains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientRemains.Size = new System.Drawing.Size(734, 281);
            this.dgvClientRemains.TabIndex = 1;
            // 
            // tareTypeDescriptionDataGridViewTextBoxColumn
            // 
            this.tareTypeDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Tare_Type_Description";
            this.tareTypeDescriptionDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.tareTypeDescriptionDataGridViewTextBoxColumn.Name = "tareTypeDescriptionDataGridViewTextBoxColumn";
            this.tareTypeDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareTypeDescriptionDataGridViewTextBoxColumn.Width = 300;
            // 
            // tareBarcodeDataGridViewTextBoxColumn
            // 
            this.tareBarcodeDataGridViewTextBoxColumn.DataPropertyName = "Tare_Bar_code";
            this.tareBarcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.tareBarcodeDataGridViewTextBoxColumn.Name = "tareBarcodeDataGridViewTextBoxColumn";
            this.tareBarcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareBarcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // clientTareRemainsBindingSource
            // 
            this.clientTareRemainsBindingSource.DataMember = "ClientTareRemains";
            this.clientTareRemainsBindingSource.DataSource = this.delivery;
            // 
            // fullTareByRouteListTableAdapter
            // 
            this.fullTareByRouteListTableAdapter.ClearBeforeFill = true;
            // 
            // clientTareRemainsTableAdapter
            // 
            this.clientTareRemainsTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManualTareInput});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(150, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnManualTareInput
            // 
            this.btnManualTareInput.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnManualTareInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManualTareInput.Name = "btnManualTareInput";
            this.btnManualTareInput.Size = new System.Drawing.Size(112, 36);
            this.btnManualTareInput.Text = "Ручной ввод";
            this.btnManualTareInput.Click += new System.EventHandler(this.btnManualTareInput_Click);
            // 
            // pnlManualInput
            // 
            this.pnlManualInput.Controls.Add(this.toolStrip1);
            this.pnlManualInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlManualInput.Location = new System.Drawing.Point(431, 0);
            this.pnlManualInput.Name = "pnlManualInput";
            this.pnlManualInput.Size = new System.Drawing.Size(150, 50);
            this.pnlManualInput.TabIndex = 3;
            // 
            // ReceiptDebtorsReturnedTareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 671);
            this.Controls.Add(this.scWorkSpace);
            this.Name = "ReceiptDebtorsReturnedTareForm";
            this.Text = "Сдача клиентской оборотной тары";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiptDebtorsReturnedTareForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.scWorkSpace, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareReturnByRouteListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.scWorkSpace.Panel1.ResumeLayout(false);
            this.scWorkSpace.Panel2.ResumeLayout(false);
            this.scWorkSpace.ResumeLayout(false);
            this.scFoolTareByRouteListDetails.Panel1.ResumeLayout(false);
            this.scFoolTareByRouteListDetails.Panel1.PerformLayout();
            this.scFoolTareByRouteListDetails.Panel2.ResumeLayout(false);
            this.scFoolTareByRouteListDetails.ResumeLayout(false);
            this.tsTareDetailsMenu.ResumeLayout(false);
            this.tsTareDetailsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullTareByRouteListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientRemains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientTareRemainsBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlManualInput.ResumeLayout(false);
            this.pnlManualInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private WMSOffice.Controls.TextBoxScaner tbsTare;
        private System.Windows.Forms.Label lblScanTare;
        private System.Windows.Forms.DataGridView dgvTare;
        private System.Windows.Forms.BindingSource tareReturnByRouteListBindingSource;
        private Data.Delivery delivery;
        private Data.DeliveryTableAdapters.TareReturnByRouteListTableAdapter tareReturnByRouteListTableAdapter;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblScannedReturnedTareQtty;
        private System.Windows.Forms.Label lblScannedItems;
        private System.Windows.Forms.SplitContainer scWorkSpace;
        private System.Windows.Forms.SplitContainer scFoolTareByRouteListDetails;
        private System.Windows.Forms.ToolStrip tsTareDetailsMenu;
        private System.Windows.Forms.ToolStripButton btnRefreshTareDetails;
        private System.Windows.Forms.DataGridView dgvTareDetails;
        private System.Windows.Forms.ToolStripButton btnShowClientRemains;
        private System.Windows.Forms.DataGridView dgvClientRemains;
        private System.Windows.Forms.BindingSource fullTareByRouteListBindingSource;
        private WMSOffice.Data.DeliveryTableAdapters.FullTareByRouteListTableAdapter fullTareByRouteListTableAdapter;
        private System.Windows.Forms.BindingSource clientTareRemainsBindingSource;
        private WMSOffice.Data.DeliveryTableAdapters.ClientTareRemainsTableAdapter clientTareRemainsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareTypeDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tARENameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntReturnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cntremDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnManualTareInput;
        private System.Windows.Forms.Panel pnlManualInput;
    }
}