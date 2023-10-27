namespace WMSOffice.Dialogs.Complaints
{
    partial class ReRegistrationComplaintEditForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblWarehouses = new System.Windows.Forms.Label();
            this.lblExpiredReturnDate = new System.Windows.Forms.Label();
            this.dtpExpiredReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblItemState = new System.Windows.Forms.Label();
            this.cmbItemState = new System.Windows.Forms.ComboBox();
            this.bsCoAutoGetTypeItemReason = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.lastWorker = new System.ComponentModel.BackgroundWorker();
            this.pbWait = new System.Windows.Forms.PictureBox();
            this.dgvRemains = new System.Windows.Forms.DataGridView();
            this.clChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clWarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLocn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCoSearchItems = new System.Windows.Forms.BindingSource(this.components);
            this.lblItemsFilter = new System.Windows.Forms.Label();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
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
            this.ccbWarehouses = new WMSOffice.Controls.CheckedComboBox();
            this.taCoAutoGetTypeItemReason = new WMSOffice.Data.ComplaintsTableAdapters.CO_Auto_Get_Type_Item_ReasonTableAdapter();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbxComment = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.cmbReasonID = new System.Windows.Forms.ComboBox();
            this.bsCoGetIBReturnReasons = new System.Windows.Forms.BindingSource(this.components);
            this.taCoGetIBReturnReasons = new WMSOffice.Data.ComplaintsTableAdapters.CO_Get_IBReturn_ReasonsTableAdapter();
            this.taCoSearchItems = new WMSOffice.Data.ComplaintsTableAdapters.CO_Search_ItemsTableAdapter();
            this.gbxFilters = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chbExpirationDate = new System.Windows.Forms.CheckBox();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.lblItemName = new System.Windows.Forms.Label();
            this.stbItemName = new WMSOffice.Controls.SearchTextBox();
            this.lblFilterItem = new System.Windows.Forms.Label();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.stbFilterVendor = new WMSOffice.Controls.SearchTextBox();
            this.lblFilterVendor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeliveryWarehouse = new System.Windows.Forms.ComboBox();
            this.prCOGetAvailableDestDebtorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pr_CO_Get_Available_DestDebtorsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.pr_CO_Get_Available_DestDebtorsTableAdapter();
            this.btnFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoAutoGetTypeItemReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoSearchItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoGetIBReturnReasons)).BeginInit();
            this.gbxFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prCOGetAvailableDestDebtorsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(770, 579);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(687, 579);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblWarehouses
            // 
            this.lblWarehouses.AutoSize = true;
            this.lblWarehouses.Location = new System.Drawing.Point(11, 45);
            this.lblWarehouses.Name = "lblWarehouses";
            this.lblWarehouses.Size = new System.Drawing.Size(49, 13);
            this.lblWarehouses.TabIndex = 12;
            this.lblWarehouses.Text = "Склады:";
            // 
            // lblExpiredReturnDate
            // 
            this.lblExpiredReturnDate.AutoSize = true;
            this.lblExpiredReturnDate.Location = new System.Drawing.Point(11, 15);
            this.lblExpiredReturnDate.Name = "lblExpiredReturnDate";
            this.lblExpiredReturnDate.Size = new System.Drawing.Size(179, 13);
            this.lblExpiredReturnDate.TabIndex = 14;
            this.lblExpiredReturnDate.Text = "Срок возвращения товара на ЦО:";
            // 
            // dtpExpiredReturnDate
            // 
            this.dtpExpiredReturnDate.Location = new System.Drawing.Point(196, 11);
            this.dtpExpiredReturnDate.Name = "dtpExpiredReturnDate";
            this.dtpExpiredReturnDate.Size = new System.Drawing.Size(137, 20);
            this.dtpExpiredReturnDate.TabIndex = 10;
            // 
            // lblItemState
            // 
            this.lblItemState.AutoSize = true;
            this.lblItemState.Location = new System.Drawing.Point(404, 15);
            this.lblItemState.Name = "lblItemState";
            this.lblItemState.Size = new System.Drawing.Size(67, 13);
            this.lblItemState.TabIndex = 16;
            this.lblItemState.Text = "Вид товара:";
            // 
            // cmbItemState
            // 
            this.cmbItemState.DataSource = this.bsCoAutoGetTypeItemReason;
            this.cmbItemState.DisplayMember = "Reason_Description";
            this.cmbItemState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemState.FormattingEnabled = true;
            this.cmbItemState.Location = new System.Drawing.Point(476, 11);
            this.cmbItemState.Name = "cmbItemState";
            this.cmbItemState.Size = new System.Drawing.Size(367, 21);
            this.cmbItemState.TabIndex = 20;
            this.cmbItemState.ValueMember = "Reason_ID";
            // 
            // bsCoAutoGetTypeItemReason
            // 
            this.bsCoAutoGetTypeItemReason.DataMember = "CO_Auto_Get_Type_Item_Reason";
            this.bsCoAutoGetTypeItemReason.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pbWait
            // 
            this.pbWait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbWait.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbWait.Location = new System.Drawing.Point(380, 340);
            this.pbWait.Name = "pbWait";
            this.pbWait.Size = new System.Drawing.Size(100, 102);
            this.pbWait.TabIndex = 1;
            this.pbWait.TabStop = false;
            this.pbWait.Visible = false;
            // 
            // dgvRemains
            // 
            this.dgvRemains.AllowUserToAddRows = false;
            this.dgvRemains.AllowUserToDeleteRows = false;
            this.dgvRemains.AllowUserToOrderColumns = true;
            this.dgvRemains.AllowUserToResizeRows = false;
            this.dgvRemains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemains.AutoGenerateColumns = false;
            this.dgvRemains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clChecked,
            this.clWarehouseID,
            this.clLocn,
            this.clItemId,
            this.clItem,
            this.clUOM,
            this.clVendorLot,
            this.clLotNumber,
            this.clExpDate,
            this.clQuantity,
            this.clLots,
            this.clManufacturer});
            this.dgvRemains.DataSource = this.bsCoSearchItems;
            this.dgvRemains.Location = new System.Drawing.Point(12, 241);
            this.dgvRemains.Name = "dgvRemains";
            this.dgvRemains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemains.Size = new System.Drawing.Size(833, 332);
            this.dgvRemains.TabIndex = 50;
            this.dgvRemains.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRemains_RowValidating);
            this.dgvRemains.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRemains_CellFormatting);
            this.dgvRemains.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRemains_CurrentCellDirtyStateChanged);
            this.dgvRemains.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRemains_DataError);
            this.dgvRemains.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRemains_KeyDown);
            this.dgvRemains.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemains_CellContentClick);
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
            this.clWarehouseID.HeaderText = "Склад";
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
            this.clItemId.HeaderText = "ID товара";
            this.clItemId.Name = "clItemId";
            this.clItemId.ReadOnly = true;
            this.clItemId.Width = 75;
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
            // clLotNumber
            // 
            this.clLotNumber.DataPropertyName = "Lot_Number";
            this.clLotNumber.HeaderText = "Партия";
            this.clLotNumber.Name = "clLotNumber";
            this.clLotNumber.ReadOnly = true;
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
            // clManufacturer
            // 
            this.clManufacturer.DataPropertyName = "Manufacturer";
            this.clManufacturer.HeaderText = "Производитель";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.ReadOnly = true;
            // 
            // bsCoSearchItems
            // 
            this.bsCoSearchItems.DataMember = "CO_Search_Items";
            this.bsCoSearchItems.DataSource = this.complaints;
            // 
            // lblItemsFilter
            // 
            this.lblItemsFilter.AutoSize = true;
            this.lblItemsFilter.Location = new System.Drawing.Point(11, 74);
            this.lblItemsFilter.Name = "lblItemsFilter";
            this.lblItemsFilter.Size = new System.Drawing.Size(96, 13);
            this.lblItemsFilter.TabIndex = 9;
            this.lblItemsFilter.Text = "Быстрый фильтр:";
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(113, 71);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(239, 20);
            this.tbxFilter.TabIndex = 46;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 1000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
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
            // ccbWarehouses
            // 
            this.ccbWarehouses.CheckOnClick = true;
            this.ccbWarehouses.DisplayMember = "Name";
            this.ccbWarehouses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbWarehouses.DropDownHeight = 1;
            this.ccbWarehouses.FormattingEnabled = true;
            this.ccbWarehouses.IntegralHeight = false;
            this.ccbWarehouses.Location = new System.Drawing.Point(111, 41);
            this.ccbWarehouses.MaxDropDownItems = 20;
            this.ccbWarehouses.Name = "ccbWarehouses";
            this.ccbWarehouses.Size = new System.Drawing.Size(732, 21);
            this.ccbWarehouses.TabIndex = 30;
            this.ccbWarehouses.ValueSeparator = ", ";
            this.ccbWarehouses.TextChanged += new System.EventHandler(this.ccbWarehouses_TextChanged);
            // 
            // taCoAutoGetTypeItemReason
            // 
            this.taCoAutoGetTypeItemReason.ClearBeforeFill = true;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(11, 107);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(80, 13);
            this.lblComment.TabIndex = 71;
            this.lblComment.Text = "Комментарий:";
            // 
            // tbxComment
            // 
            this.tbxComment.AcceptsReturn = true;
            this.tbxComment.Location = new System.Drawing.Point(111, 103);
            this.tbxComment.Multiline = true;
            this.tbxComment.Name = "tbxComment";
            this.tbxComment.Size = new System.Drawing.Size(206, 21);
            this.tbxComment.TabIndex = 35;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(418, 107);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(53, 13);
            this.lblReason.TabIndex = 72;
            this.lblReason.Text = "Причина:";
            // 
            // cmbReasonID
            // 
            this.cmbReasonID.DataSource = this.bsCoGetIBReturnReasons;
            this.cmbReasonID.DisplayMember = "Reason_Description";
            this.cmbReasonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasonID.FormattingEnabled = true;
            this.cmbReasonID.Location = new System.Drawing.Point(476, 103);
            this.cmbReasonID.Name = "cmbReasonID";
            this.cmbReasonID.Size = new System.Drawing.Size(367, 21);
            this.cmbReasonID.TabIndex = 37;
            this.cmbReasonID.ValueMember = "Reason_ID";
            // 
            // bsCoGetIBReturnReasons
            // 
            this.bsCoGetIBReturnReasons.DataMember = "CO_Get_IBReturn_Reasons";
            this.bsCoGetIBReturnReasons.DataSource = this.complaints;
            // 
            // taCoGetIBReturnReasons
            // 
            this.taCoGetIBReturnReasons.ClearBeforeFill = true;
            // 
            // taCoSearchItems
            // 
            this.taCoSearchItems.ClearBeforeFill = true;
            // 
            // gbxFilters
            // 
            this.gbxFilters.Controls.Add(this.btnRefresh);
            this.gbxFilters.Controls.Add(this.chbExpirationDate);
            this.gbxFilters.Controls.Add(this.dtpExpirationDate);
            this.gbxFilters.Controls.Add(this.tbxFilter);
            this.gbxFilters.Controls.Add(this.lblItemName);
            this.gbxFilters.Controls.Add(this.stbItemName);
            this.gbxFilters.Controls.Add(this.lblFilterItem);
            this.gbxFilters.Controls.Add(this.lblVendorName);
            this.gbxFilters.Controls.Add(this.stbFilterVendor);
            this.gbxFilters.Controls.Add(this.lblFilterVendor);
            this.gbxFilters.Controls.Add(this.lblItemsFilter);
            this.gbxFilters.Location = new System.Drawing.Point(14, 134);
            this.gbxFilters.Name = "gbxFilters";
            this.gbxFilters.Size = new System.Drawing.Size(829, 103);
            this.gbxFilters.TabIndex = 40;
            this.gbxFilters.TabStop = false;
            this.gbxFilters.Text = "Фильтры";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(673, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 23);
            this.btnRefresh.TabIndex = 45;
            this.btnRefresh.Text = "Обновить (F5)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chbExpirationDate
            // 
            this.chbExpirationDate.AutoSize = true;
            this.chbExpirationDate.Location = new System.Drawing.Point(391, 24);
            this.chbExpirationDate.Name = "chbExpirationDate";
            this.chbExpirationDate.Size = new System.Drawing.Size(118, 17);
            this.chbExpirationDate.TabIndex = 43;
            this.chbExpirationDate.Text = "Срок годности до:";
            this.chbExpirationDate.UseVisualStyleBackColor = true;
            this.chbExpirationDate.CheckedChanged += new System.EventHandler(this.chbExpirationDate_CheckedChanged);
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Enabled = false;
            this.dtpExpirationDate.Location = new System.Drawing.Point(515, 23);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(122, 20);
            this.dtpExpirationDate.TabIndex = 44;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(284, 45);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(41, 13);
            this.lblItemName.TabIndex = 5;
            this.lblItemName.Text = "Товар:";
            // 
            // stbItemName
            // 
            this.stbItemName.Location = new System.Drawing.Point(277, 19);
            this.stbItemName.Name = "stbItemName";
            this.stbItemName.ReadOnly = false;
            this.stbItemName.Size = new System.Drawing.Size(75, 23);
            this.stbItemName.TabIndex = 42;
            this.stbItemName.UserID = ((long)(0));
            this.stbItemName.Value = null;
            this.stbItemName.ValueReferenceQuery = null;
            this.stbItemName.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(this.stbItemName_OnVerifyValue);
            // 
            // lblFilterItem
            // 
            this.lblFilterItem.AutoSize = true;
            this.lblFilterItem.Location = new System.Drawing.Point(230, 25);
            this.lblFilterItem.Name = "lblFilterItem";
            this.lblFilterItem.Size = new System.Drawing.Size(41, 13);
            this.lblFilterItem.TabIndex = 3;
            this.lblFilterItem.Text = "Товар:";
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Location = new System.Drawing.Point(11, 45);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(68, 13);
            this.lblVendorName.TabIndex = 2;
            this.lblVendorName.Text = "Поставщик:";
            // 
            // stbFilterVendor
            // 
            this.stbFilterVendor.Location = new System.Drawing.Point(97, 19);
            this.stbFilterVendor.Name = "stbFilterVendor";
            this.stbFilterVendor.ReadOnly = false;
            this.stbFilterVendor.Size = new System.Drawing.Size(75, 23);
            this.stbFilterVendor.TabIndex = 41;
            this.stbFilterVendor.UserID = ((long)(0));
            this.stbFilterVendor.Value = null;
            this.stbFilterVendor.ValueReferenceQuery = null;
            this.stbFilterVendor.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(this.stbFilterVendor_OnVerifyValue);
            // 
            // lblFilterVendor
            // 
            this.lblFilterVendor.AutoSize = true;
            this.lblFilterVendor.Location = new System.Drawing.Point(11, 25);
            this.lblFilterVendor.Name = "lblFilterVendor";
            this.lblFilterVendor.Size = new System.Drawing.Size(68, 13);
            this.lblFilterVendor.TabIndex = 0;
            this.lblFilterVendor.Text = "Поставщик:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Склад-получатель:";
            // 
            // cmbDeliveryWarehouse
            // 
            this.cmbDeliveryWarehouse.DataSource = this.prCOGetAvailableDestDebtorsBindingSource;
            this.cmbDeliveryWarehouse.DisplayMember = "Debtor_Name";
            this.cmbDeliveryWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryWarehouse.FormattingEnabled = true;
            this.cmbDeliveryWarehouse.Location = new System.Drawing.Point(111, 72);
            this.cmbDeliveryWarehouse.Name = "cmbDeliveryWarehouse";
            this.cmbDeliveryWarehouse.Size = new System.Drawing.Size(732, 21);
            this.cmbDeliveryWarehouse.TabIndex = 74;
            this.cmbDeliveryWarehouse.ValueMember = "Debtor_ID";
            // 
            // prCOGetAvailableDestDebtorsBindingSource
            // 
            this.prCOGetAvailableDestDebtorsBindingSource.DataMember = "pr_CO_Get_Available_DestDebtors";
            this.prCOGetAvailableDestDebtorsBindingSource.DataSource = this.complaints;
            // 
            // pr_CO_Get_Available_DestDebtorsTableAdapter
            // 
            this.pr_CO_Get_Available_DestDebtorsTableAdapter.ClearBeforeFill = true;
            // 
            // btnFiles
            // 
            this.btnFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiles.Location = new System.Drawing.Point(323, 102);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(75, 23);
            this.btnFiles.TabIndex = 36;
            this.btnFiles.Text = "Файлы";
            this.btnFiles.UseVisualStyleBackColor = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // ReRegistrationComplaintEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(851, 614);
            this.Controls.Add(this.btnFiles);
            this.Controls.Add(this.cmbDeliveryWarehouse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxFilters);
            this.Controls.Add(this.cmbReasonID);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.tbxComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.pbWait);
            this.Controls.Add(this.cmbItemState);
            this.Controls.Add(this.lblItemState);
            this.Controls.Add(this.dtpExpiredReturnDate);
            this.Controls.Add(this.lblExpiredReturnDate);
            this.Controls.Add(this.ccbWarehouses);
            this.Controls.Add(this.lblWarehouses);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvRemains);
            this.KeyPreview = true;
            this.Name = "ReRegistrationComplaintEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание претензии по перерегистрации";
            this.Load += new System.EventHandler(this.ReRegistrationComplaintEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReRegistrationComplaintEditForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReRegistrationComplaintEditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsCoAutoGetTypeItemReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoSearchItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoGetIBReturnReasons)).EndInit();
            this.gbxFilters.ResumeLayout(false);
            this.gbxFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prCOGetAvailableDestDebtorsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblWarehouses;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private WMSOffice.Controls.CheckedComboBox ccbWarehouses;
        private System.Windows.Forms.Label lblExpiredReturnDate;
        private System.Windows.Forms.DateTimePicker dtpExpiredReturnDate;
        private System.Windows.Forms.Label lblItemState;
        private System.Windows.Forms.ComboBox cmbItemState;
        private System.ComponentModel.BackgroundWorker lastWorker;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.PictureBox pbWait;
        private System.Windows.Forms.DataGridView dgvRemains;
        private System.Windows.Forms.Label lblItemsFilter;
        private System.Windows.Forms.TextBox tbxFilter;
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
        private System.Windows.Forms.BindingSource bsCoAutoGetTypeItemReason;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Auto_Get_Type_Item_ReasonTableAdapter taCoAutoGetTypeItemReason;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox tbxComment;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cmbReasonID;
        private System.Windows.Forms.BindingSource bsCoGetIBReturnReasons;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Get_IBReturn_ReasonsTableAdapter taCoGetIBReturnReasons;
        private System.Windows.Forms.BindingSource bsCoSearchItems;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Search_ItemsTableAdapter taCoSearchItems;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn clWarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLocn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clExpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private System.Windows.Forms.GroupBox gbxFilters;
        private System.Windows.Forms.Label lblVendorName;
        private WMSOffice.Controls.SearchTextBox stbFilterVendor;
        private System.Windows.Forms.Label lblFilterVendor;
        private System.Windows.Forms.Label lblItemName;
        private WMSOffice.Controls.SearchTextBox stbItemName;
        private System.Windows.Forms.Label lblFilterItem;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.CheckBox chbExpirationDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeliveryWarehouse;
        private System.Windows.Forms.BindingSource prCOGetAvailableDestDebtorsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.pr_CO_Get_Available_DestDebtorsTableAdapter pr_CO_Get_Available_DestDebtorsTableAdapter;
        private System.Windows.Forms.Button btnFiles;

    }
}