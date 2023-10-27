namespace WMSOffice.Dialogs.Complaints
{
    partial class ManufacturerBoxNDComplaintEditForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lastWorker = new System.ComponentModel.BackgroundWorker();
            this.pbWait = new System.Windows.Forms.PictureBox();
            this.dgvInvoiceItems = new System.Windows.Forms.DataGridView();
            this.clChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clWarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLocn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsСoSearchItems = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.lblItemsFilter = new System.Windows.Forms.Label();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.grbInvoice = new System.Windows.Forms.GroupBox();
            this.lblNeedRefresh = new System.Windows.Forms.Label();
            this.btnSearchInvoice = new System.Windows.Forms.Button();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblInvoiceReceiver = new System.Windows.Forms.Label();
            this.tbxInvoiceType = new System.Windows.Forms.TextBox();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.tbxInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.taCoSearchItems = new WMSOffice.Data.ComplaintsTableAdapters.CO_Search_ItemsTableAdapter();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsСoSearchItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.grbInvoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(840, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(759, 516);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 40;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pbWait
            // 
            this.pbWait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbWait.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbWait.Location = new System.Drawing.Point(414, 271);
            this.pbWait.Name = "pbWait";
            this.pbWait.Size = new System.Drawing.Size(100, 102);
            this.pbWait.TabIndex = 1;
            this.pbWait.TabStop = false;
            this.pbWait.Visible = false;
            // 
            // dgvInvoiceItems
            // 
            this.dgvInvoiceItems.AllowUserToAddRows = false;
            this.dgvInvoiceItems.AllowUserToDeleteRows = false;
            this.dgvInvoiceItems.AllowUserToOrderColumns = true;
            this.dgvInvoiceItems.AllowUserToResizeRows = false;
            this.dgvInvoiceItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoiceItems.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clChecked,
            this.clWarehouseID,
            this.clLocn,
            this.clItemId,
            this.clItem,
            this.clUOM,
            this.clVendorLot,
            this.clBatchID,
            this.clExpDate,
            this.clQuantity,
            this.clLots});
            this.dgvInvoiceItems.DataSource = this.bsСoSearchItems;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoiceItems.Location = new System.Drawing.Point(10, 147);
            this.dgvInvoiceItems.Name = "dgvInvoiceItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInvoiceItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceItems.Size = new System.Drawing.Size(907, 363);
            this.dgvInvoiceItems.TabIndex = 30;
            this.dgvInvoiceItems.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRemains_RowValidating);
            this.dgvInvoiceItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInvoiceItems_CellFormatting);
            this.dgvInvoiceItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvInvoiceItems_CurrentCellDirtyStateChanged);
            this.dgvInvoiceItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRemains_DataError);
            this.dgvInvoiceItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvInvoiceItems_KeyDown);
            this.dgvInvoiceItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceItems_CellContentClick);
            // 
            // clChecked
            // 
            this.clChecked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clChecked.DataPropertyName = "Checked";
            this.clChecked.HeaderText = "";
            this.clChecked.Name = "clChecked";
            this.clChecked.Width = 20;
            // 
            // clWarehouseID
            // 
            this.clWarehouseID.DataPropertyName = "Warehouse_ID";
            this.clWarehouseID.HeaderText = "Код склада";
            this.clWarehouseID.Name = "clWarehouseID";
            this.clWarehouseID.ReadOnly = true;
            // 
            // clLocn
            // 
            this.clLocn.DataPropertyName = "Locn";
            this.clLocn.HeaderText = "Место";
            this.clLocn.Name = "clLocn";
            this.clLocn.ReadOnly = true;
            // 
            // clItemId
            // 
            this.clItemId.DataPropertyName = "Item_ID";
            this.clItemId.HeaderText = "Код товара";
            this.clItemId.Name = "clItemId";
            this.clItemId.ReadOnly = true;
            this.clItemId.Width = 81;
            // 
            // clItem
            // 
            this.clItem.DataPropertyName = "Item";
            this.clItem.HeaderText = "Наименование товара";
            this.clItem.Name = "clItem";
            this.clItem.ReadOnly = true;
            // 
            // clUOM
            // 
            this.clUOM.DataPropertyName = "UOM";
            this.clUOM.HeaderText = "ЕИ";
            this.clUOM.Name = "clUOM";
            this.clUOM.ReadOnly = true;
            this.clUOM.Width = 47;
            // 
            // clVendorLot
            // 
            this.clVendorLot.DataPropertyName = "Vendor_Lot";
            this.clVendorLot.HeaderText = "Серия";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            // 
            // clBatchID
            // 
            this.clBatchID.DataPropertyName = "Lot_Number";
            this.clBatchID.HeaderText = "Партия";
            this.clBatchID.Name = "clBatchID";
            this.clBatchID.ReadOnly = true;
            this.clBatchID.Width = 69;
            // 
            // clExpDate
            // 
            this.clExpDate.DataPropertyName = "ExpDate";
            this.clExpDate.HeaderText = "Срок годности";
            this.clExpDate.Name = "clExpDate";
            this.clExpDate.ReadOnly = true;
            // 
            // clQuantity
            // 
            this.clQuantity.DataPropertyName = "Quantity";
            this.clQuantity.HeaderText = "Кол-во";
            this.clQuantity.Name = "clQuantity";
            // 
            // clLots
            // 
            this.clLots.DataPropertyName = "Lots";
            this.clLots.HeaderText = "Бл.";
            this.clLots.Name = "clLots";
            this.clLots.ReadOnly = true;
            // 
            // bsСoSearchItems
            // 
            this.bsСoSearchItems.DataMember = "CO_Search_Items";
            this.bsСoSearchItems.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblItemsFilter
            // 
            this.lblItemsFilter.AutoSize = true;
            this.lblItemsFilter.Location = new System.Drawing.Point(7, 116);
            this.lblItemsFilter.Name = "lblItemsFilter";
            this.lblItemsFilter.Size = new System.Drawing.Size(50, 13);
            this.lblItemsFilter.TabIndex = 9;
            this.lblItemsFilter.Text = "Фильтр:";
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(63, 113);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(253, 20);
            this.tbxFilter.TabIndex = 20;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 1000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // grbInvoice
            // 
            this.grbInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbInvoice.Controls.Add(this.lblNeedRefresh);
            this.grbInvoice.Controls.Add(this.btnSearchInvoice);
            this.grbInvoice.Controls.Add(this.lblInvoiceDate);
            this.grbInvoice.Controls.Add(this.lblInvoiceReceiver);
            this.grbInvoice.Controls.Add(this.tbxInvoiceType);
            this.grbInvoice.Controls.Add(this.lblInvoiceType);
            this.grbInvoice.Controls.Add(this.tbxInvoiceNumber);
            this.grbInvoice.Controls.Add(this.lblInvoiceNumber);
            this.grbInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbInvoice.Location = new System.Drawing.Point(12, 3);
            this.grbInvoice.Name = "grbInvoice";
            this.grbInvoice.Size = new System.Drawing.Size(905, 93);
            this.grbInvoice.TabIndex = 1;
            this.grbInvoice.TabStop = false;
            this.grbInvoice.Text = "Поиск накладной";
            // 
            // lblNeedRefresh
            // 
            this.lblNeedRefresh.AutoSize = true;
            this.lblNeedRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNeedRefresh.ForeColor = System.Drawing.Color.Red;
            this.lblNeedRefresh.Location = new System.Drawing.Point(621, 31);
            this.lblNeedRefresh.Name = "lblNeedRefresh";
            this.lblNeedRefresh.Size = new System.Drawing.Size(116, 13);
            this.lblNeedRefresh.TabIndex = 16;
            this.lblNeedRefresh.Text = "(данные изменились)";
            this.lblNeedRefresh.Visible = false;
            // 
            // btnSearchInvoice
            // 
            this.btnSearchInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearchInvoice.Location = new System.Drawing.Point(528, 26);
            this.btnSearchInvoice.Name = "btnSearchInvoice";
            this.btnSearchInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnSearchInvoice.TabIndex = 15;
            this.btnSearchInvoice.Text = "Найти";
            this.btnSearchInvoice.UseVisualStyleBackColor = true;
            this.btnSearchInvoice.Click += new System.EventHandler(this.btnSearchInvoice_Click);
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblInvoiceDate.Location = new System.Drawing.Point(280, 62);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(93, 13);
            this.lblInvoiceDate.TabIndex = 5;
            this.lblInvoiceDate.Text = "Дата накладной:";
            // 
            // lblInvoiceReceiver
            // 
            this.lblInvoiceReceiver.AutoSize = true;
            this.lblInvoiceReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblInvoiceReceiver.Location = new System.Drawing.Point(10, 62);
            this.lblInvoiceReceiver.Name = "lblInvoiceReceiver";
            this.lblInvoiceReceiver.Size = new System.Drawing.Size(69, 13);
            this.lblInvoiceReceiver.TabIndex = 4;
            this.lblInvoiceReceiver.Text = "Получатель:";
            // 
            // tbxInvoiceType
            // 
            this.tbxInvoiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxInvoiceType.Location = new System.Drawing.Point(381, 28);
            this.tbxInvoiceType.Name = "tbxInvoiceType";
            this.tbxInvoiceType.Size = new System.Drawing.Size(106, 20);
            this.tbxInvoiceType.TabIndex = 10;
            this.tbxInvoiceType.TextChanged += new System.EventHandler(this.tbxInvoice_TextChanged);
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblInvoiceType.Location = new System.Drawing.Point(280, 31);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(86, 13);
            this.lblInvoiceType.TabIndex = 2;
            this.lblInvoiceType.Text = "Тип накладной:";
            // 
            // tbxInvoiceNumber
            // 
            this.tbxInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxInvoiceNumber.Location = new System.Drawing.Point(117, 28);
            this.tbxInvoiceNumber.Name = "tbxInvoiceNumber";
            this.tbxInvoiceNumber.Size = new System.Drawing.Size(106, 20);
            this.tbxInvoiceNumber.TabIndex = 5;
            this.tbxInvoiceNumber.TextChanged += new System.EventHandler(this.tbxInvoice_TextChanged);
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblInvoiceNumber.Location = new System.Drawing.Point(10, 31);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(101, 13);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "Номер накладной:";
            // 
            // taCoSearchItems
            // 
            this.taCoSearchItems.ClearBeforeFill = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Checked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "UOM";
            this.dataGridViewTextBoxColumn1.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MOZ";
            this.dataGridViewTextBoxColumn2.HeaderText = "МОЗ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Vendor";
            this.dataGridViewTextBoxColumn3.HeaderText = "Поставщик";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item_description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Наименование товара";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Vendor_description";
            this.dataGridViewTextBoxColumn5.HeaderText = "Поставщик";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MOZ_description";
            this.dataGridViewTextBoxColumn6.HeaderText = "МОЗ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Seria_ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Life_time";
            this.dataGridViewTextBoxColumn8.HeaderText = "Срок годности";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Type_Block_ID";
            this.dataGridViewTextBoxColumn9.HeaderText = "Бл.";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Type_Block_description";
            this.dataGridViewTextBoxColumn10.HeaderText = "Блокировка";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "QTY";
            this.dataGridViewTextBoxColumn11.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // ManufacturerBoxNDComplaintEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(927, 551);
            this.Controls.Add(this.grbInvoice);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.pbWait);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblItemsFilter);
            this.Controls.Add(this.dgvInvoiceItems);
            this.KeyPreview = true;
            this.Name = "ManufacturerBoxNDComplaintEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание претензии недостачи в заводском ящике";
            this.Load += new System.EventHandler(this.ManufacturerBoxNDComplaintEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManufacturerBoxNDComplaintEditForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManufacturerBoxNDComplaintEditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsСoSearchItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.grbInvoice.ResumeLayout(false);
            this.grbInvoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.ComponentModel.BackgroundWorker lastWorker;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.PictureBox pbWait;
        private System.Windows.Forms.DataGridView dgvInvoiceItems;
        private System.Windows.Forms.Label lblItemsFilter;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.BindingSource bsСoSearchItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Timer delayTimer;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Search_ItemsTableAdapter taCoSearchItems;
        private System.Windows.Forms.GroupBox grbInvoice;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox tbxInvoiceNumber;
        private System.Windows.Forms.TextBox tbxInvoiceType;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.Button btnSearchInvoice;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceReceiver;
        private System.Windows.Forms.Label lblNeedRefresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn clWarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLocn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clExpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLots;

    }
}