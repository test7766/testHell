namespace WMSOffice.Dialogs.Inventory
{
    partial class PostInventoryFilialOverageForm
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
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.dgvOverages = new System.Windows.Forms.DataGridView();
            this.clChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clWhId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIsVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSsSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBaseSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_in_ND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFpGetItemsForOverageReceipt = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.taFpGetItemsForOverageReceipt = new WMSOffice.Data.InventoryTableAdapters.FP_Get_Items_For_Overage_ReceiptTableAdapter();
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
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChangePlace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetItemsForOverageReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxFilter
            // 
            this.tbxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbxFilter.Location = new System.Drawing.Point(78, 12);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(371, 24);
            this.tbxFilter.TabIndex = 6;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Фильтр:";
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 1000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(837, 477);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(750, 477);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dgvOverages
            // 
            this.dgvOverages.AllowUserToAddRows = false;
            this.dgvOverages.AllowUserToDeleteRows = false;
            this.dgvOverages.AllowUserToOrderColumns = true;
            this.dgvOverages.AllowUserToResizeRows = false;
            this.dgvOverages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOverages.AutoGenerateColumns = false;
            this.dgvOverages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clChecked,
            this.clResult,
            this.clItemId,
            this.clItem,
            this.clUoM,
            this.clQuantity,
            this.clWhId,
            this.clLocation,
            this.clIsVat,
            this.clLineID,
            this.clSs,
            this.clSsSum,
            this.clBasePrice,
            this.clBaseSum,
            this.clBatchID,
            this.clLotNumber,
            this.clManufacturer,
            this.date_in_ND});
            this.dgvOverages.DataSource = this.bsFpGetItemsForOverageReceipt;
            this.dgvOverages.Location = new System.Drawing.Point(10, 42);
            this.dgvOverages.Name = "dgvOverages";
            this.dgvOverages.RowHeadersVisible = false;
            this.dgvOverages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverages.Size = new System.Drawing.Size(908, 429);
            this.dgvOverages.TabIndex = 9;
            this.dgvOverages.Sorted += new System.EventHandler(this.dgvOverages_Sorted);
            this.dgvOverages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOverages_CellContentClick);
            // 
            // clChecked
            // 
            this.clChecked.DataPropertyName = "CheckedFlag";
            this.clChecked.HeaderText = "";
            this.clChecked.Name = "clChecked";
            this.clChecked.Width = 20;
            // 
            // clResult
            // 
            this.clResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clResult.DataPropertyName = "Результат";
            this.clResult.HeaderText = "Результат";
            this.clResult.Name = "clResult";
            this.clResult.ReadOnly = true;
            this.clResult.Visible = false;
            // 
            // clItemId
            // 
            this.clItemId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItemId.DataPropertyName = "Код товара";
            this.clItemId.HeaderText = "Код товара";
            this.clItemId.Name = "clItemId";
            this.clItemId.ReadOnly = true;
            this.clItemId.Width = 82;
            // 
            // clItem
            // 
            this.clItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItem.DataPropertyName = "Наименование";
            this.clItem.HeaderText = "Наименование";
            this.clItem.Name = "clItem";
            this.clItem.ReadOnly = true;
            this.clItem.Width = 108;
            // 
            // clUoM
            // 
            this.clUoM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clUoM.DataPropertyName = "Ед_изм_";
            this.clUoM.HeaderText = "ЕИ";
            this.clUoM.Name = "clUoM";
            this.clUoM.ReadOnly = true;
            this.clUoM.Width = 47;
            // 
            // clQuantity
            // 
            this.clQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clQuantity.DataPropertyName = "Кол-во";
            this.clQuantity.HeaderText = "Кол-во";
            this.clQuantity.Name = "clQuantity";
            this.clQuantity.ReadOnly = true;
            this.clQuantity.Width = 66;
            // 
            // clWhId
            // 
            this.clWhId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clWhId.DataPropertyName = "Код склада";
            this.clWhId.HeaderText = "Код склада";
            this.clWhId.Name = "clWhId";
            this.clWhId.ReadOnly = true;
            this.clWhId.Width = 83;
            // 
            // clLocation
            // 
            this.clLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLocation.DataPropertyName = "Полка";
            this.clLocation.HeaderText = "Полка";
            this.clLocation.Name = "clLocation";
            this.clLocation.ReadOnly = true;
            this.clLocation.Width = 64;
            // 
            // clIsVat
            // 
            this.clIsVat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clIsVat.DataPropertyName = "Признак НДС";
            this.clIsVat.HeaderText = "Признак НДС";
            this.clIsVat.Name = "clIsVat";
            this.clIsVat.ReadOnly = true;
            this.clIsVat.Visible = false;
            // 
            // clLineID
            // 
            this.clLineID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLineID.DataPropertyName = "Код строки";
            this.clLineID.HeaderText = "Код строки";
            this.clLineID.Name = "clLineID";
            this.clLineID.ReadOnly = true;
            this.clLineID.Visible = false;
            // 
            // clSs
            // 
            this.clSs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clSs.DataPropertyName = "Себестоимость";
            this.clSs.HeaderText = "Цена в с/с";
            this.clSs.Name = "clSs";
            this.clSs.ReadOnly = true;
            this.clSs.Width = 65;
            // 
            // clSsSum
            // 
            this.clSsSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clSsSum.DataPropertyName = "сумма в себестоимости";
            this.clSsSum.HeaderText = "Сумма в с/с";
            this.clSsSum.Name = "clSsSum";
            this.clSsSum.ReadOnly = true;
            this.clSsSum.Width = 72;
            // 
            // clBasePrice
            // 
            this.clBasePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clBasePrice.DataPropertyName = "Базовая цена";
            this.clBasePrice.HeaderText = "Цена в базовых";
            this.clBasePrice.Name = "clBasePrice";
            this.clBasePrice.ReadOnly = true;
            this.clBasePrice.Width = 104;
            // 
            // clBaseSum
            // 
            this.clBaseSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clBaseSum.DataPropertyName = "сумма в базовых ценах";
            this.clBaseSum.HeaderText = "Сумма в базовых";
            this.clBaseSum.Name = "clBaseSum";
            this.clBaseSum.ReadOnly = true;
            this.clBaseSum.Width = 111;
            // 
            // clBatchID
            // 
            this.clBatchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clBatchID.DataPropertyName = "Партия";
            this.clBatchID.HeaderText = "Партия";
            this.clBatchID.Name = "clBatchID";
            this.clBatchID.ReadOnly = true;
            this.clBatchID.Width = 69;
            // 
            // clLotNumber
            // 
            this.clLotNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLotNumber.DataPropertyName = "Серия";
            this.clLotNumber.HeaderText = "Серия";
            this.clLotNumber.Name = "clLotNumber";
            this.clLotNumber.ReadOnly = true;
            this.clLotNumber.Visible = false;
            // 
            // clManufacturer
            // 
            this.clManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clManufacturer.DataPropertyName = "Производитель";
            this.clManufacturer.HeaderText = "Производитель";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.ReadOnly = true;
            this.clManufacturer.Width = 111;
            // 
            // date_in_ND
            // 
            this.date_in_ND.DataPropertyName = "date_in_ND";
            this.date_in_ND.HeaderText = "Дата поступления на полку";
            this.date_in_ND.Name = "date_in_ND";
            this.date_in_ND.ReadOnly = true;
            // 
            // bsFpGetItemsForOverageReceipt
            // 
            this.bsFpGetItemsForOverageReceipt.DataMember = "FP_Get_Items_For_Overage_Receipt";
            this.bsFpGetItemsForOverageReceipt.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taFpGetItemsForOverageReceipt
            // 
            this.taFpGetItemsForOverageReceipt.ClearBeforeFill = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "CheckedFlag";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Код склада";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код склада";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Результат";
            this.dataGridViewTextBoxColumn2.HeaderText = "Результат";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Код товара";
            this.dataGridViewTextBoxColumn3.HeaderText = "Код товара";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Наименование";
            this.dataGridViewTextBoxColumn4.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Ед_изм_";
            this.dataGridViewTextBoxColumn5.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Кол-во";
            this.dataGridViewTextBoxColumn6.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Полка";
            this.dataGridViewTextBoxColumn7.HeaderText = "Полка";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Признак НДС";
            this.dataGridViewTextBoxColumn8.HeaderText = "Признак НДС";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Код строки";
            this.dataGridViewTextBoxColumn9.HeaderText = "Код строки";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "сумма в базовых ценах";
            this.dataGridViewTextBoxColumn10.HeaderText = "Сумма в базовых";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "сумма в себестоимости";
            this.dataGridViewTextBoxColumn11.HeaderText = "Сумма с/с";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Партия";
            this.dataGridViewTextBoxColumn12.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Серия";
            this.dataGridViewTextBoxColumn13.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Себестоимость";
            this.dataGridViewTextBoxColumn14.HeaderText = "С/с";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Базовая цена";
            this.dataGridViewTextBoxColumn15.HeaderText = "Базовая цена";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Производитель";
            this.dataGridViewTextBoxColumn16.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "date_in_ND";
            this.dataGridViewTextBoxColumn17.HeaderText = "Дата поступления на ND";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // btnChangePlace
            // 
            this.btnChangePlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangePlace.Location = new System.Drawing.Point(10, 477);
            this.btnChangePlace.Name = "btnChangePlace";
            this.btnChangePlace.Size = new System.Drawing.Size(75, 23);
            this.btnChangePlace.TabIndex = 403;
            this.btnChangePlace.Text = "Полка С";
            this.btnChangePlace.UseVisualStyleBackColor = true;
            this.btnChangePlace.Click += new System.EventHandler(this.btnChangePlace_Click);
            // 
            // PostInventoryFilialOverageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(930, 512);
            this.Controls.Add(this.btnChangePlace);
            this.Controls.Add(this.dgvOverages);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "PostInventoryFilialOverageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Приходование излишков";
            this.Load += new System.EventHandler(this.PostInventoryFilialOverageForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PostInventoryFilialOverageForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostInventoryFilialOverageForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetItemsForOverageReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer delayTimer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView dgvOverages;
        private System.Windows.Forms.BindingSource bsFpGetItemsForOverageReceipt;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FP_Get_Items_For_Overage_ReceiptTableAdapter taFpGetItemsForOverageReceipt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUoM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clWhId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIsVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSsSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBaseSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_in_ND;
        private System.Windows.Forms.Button btnChangePlace;
    }
}