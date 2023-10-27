namespace WMSOffice.Dialogs.PickControl
{
    partial class PickControlPreviewForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlRecommendedTare = new System.Windows.Forms.Panel();
            this.lblRecommendedTare = new System.Windows.Forms.Label();
            this.lblRecommendedTareCaption = new System.Windows.Forms.Label();
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colSnowFlake = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doc_Qty_Ntv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCollectors = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.autoControlItemsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.tsFilter = new System.Windows.Forms.ToolStrip();
            this.lblFilter = new System.Windows.Forms.ToolStripLabel();
            this.tbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnSetManualControl = new System.Windows.Forms.ToolStripButton();
            this.btnSwitchNTVRegistrationMode = new System.Windows.Forms.ToolStripButton();
            this.autoControlItemsInfoTableAdapter = new WMSOffice.Data.PickControlTableAdapters.AutoControlItemsInfoTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlRecommendedTare.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoControlItemsInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.tsFilter.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3349, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3439, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 482);
            this.pnlButtons.Size = new System.Drawing.Size(1144, 43);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.pnlRecommendedTare);
            this.pnlHeader.Controls.Add(this.lblPriorityInstructionHeader);
            this.pnlHeader.Controls.Add(this.lblPriorityInstruction);
            this.pnlHeader.Controls.Add(this.lblContainer);
            this.pnlHeader.Controls.Add(this.lblDepartment);
            this.pnlHeader.Controls.Add(this.lblRegim);
            this.pnlHeader.Controls.Add(this.lblDeliveryDate);
            this.pnlHeader.Controls.Add(this.lblDocDate);
            this.pnlHeader.Controls.Add(this.lblDocNumber);
            this.pnlHeader.Controls.Add(this.lblDocType);
            this.pnlHeader.Controls.Add(this.lblDelivery);
            this.pnlHeader.Controls.Add(this.label9);
            this.pnlHeader.Controls.Add(this.label8);
            this.pnlHeader.Controls.Add(this.label7);
            this.pnlHeader.Controls.Add(this.label6);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.lblNumber);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1144, 125);
            this.pnlHeader.TabIndex = 101;
            // 
            // pnlRecommendedTare
            // 
            this.pnlRecommendedTare.BackColor = System.Drawing.SystemColors.Info;
            this.pnlRecommendedTare.Controls.Add(this.lblRecommendedTare);
            this.pnlRecommendedTare.Controls.Add(this.lblRecommendedTareCaption);
            this.pnlRecommendedTare.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRecommendedTare.Location = new System.Drawing.Point(0, 95);
            this.pnlRecommendedTare.Name = "pnlRecommendedTare";
            this.pnlRecommendedTare.Size = new System.Drawing.Size(1144, 30);
            this.pnlRecommendedTare.TabIndex = 22;
            // 
            // lblRecommendedTare
            // 
            this.lblRecommendedTare.AutoSize = true;
            this.lblRecommendedTare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecommendedTare.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRecommendedTare.Location = new System.Drawing.Point(139, 9);
            this.lblRecommendedTare.Name = "lblRecommendedTare";
            this.lblRecommendedTare.Size = new System.Drawing.Size(84, 13);
            this.lblRecommendedTare.TabIndex = 1;
            this.lblRecommendedTare.Text = "(не выбрана)";
            // 
            // lblRecommendedTareCaption
            // 
            this.lblRecommendedTareCaption.AutoSize = true;
            this.lblRecommendedTareCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecommendedTareCaption.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRecommendedTareCaption.Location = new System.Drawing.Point(13, 9);
            this.lblRecommendedTareCaption.Name = "lblRecommendedTareCaption";
            this.lblRecommendedTareCaption.Size = new System.Drawing.Size(118, 13);
            this.lblRecommendedTareCaption.TabIndex = 0;
            this.lblRecommendedTareCaption.Text = "Рекомендуемая тара:";
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
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlItems);
            this.pnlContent.Controls.Add(this.tsFilter);
            this.pnlContent.Controls.Add(this.tsMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 125);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1144, 357);
            this.pnlContent.TabIndex = 102;
            // 
            // pnlItems
            // 
            this.pnlItems.Controls.Add(this.dgvItems);
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 64);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(1144, 293);
            this.pnlItems.TabIndex = 3;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSnowFlake,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.docQtyDataGridViewTextBoxColumn,
            this.Doc_Qty_Ntv,
            this.colCollectors});
            this.dgvItems.DataSource = this.autoControlItemsInfoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1144, 293);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellDoubleClick);
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            this.dgvItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItems_DataError);
            this.dgvItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvItems_DataBindingComplete);
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            // 
            // colSnowFlake
            // 
            this.colSnowFlake.HeaderText = "Т";
            this.colSnowFlake.Name = "colSnowFlake";
            this.colSnowFlake.ReadOnly = true;
            this.colSnowFlake.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSnowFlake.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSnowFlake.Width = 24;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 70;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 200;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 120;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 40;
            // 
            // docQtyDataGridViewTextBoxColumn
            // 
            this.docQtyDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty";
            this.docQtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.docQtyDataGridViewTextBoxColumn.Name = "docQtyDataGridViewTextBoxColumn";
            this.docQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyDataGridViewTextBoxColumn.Width = 115;
            // 
            // Doc_Qty_Ntv
            // 
            this.Doc_Qty_Ntv.DataPropertyName = "Doc_Qty_Ntv";
            this.Doc_Qty_Ntv.HeaderText = "Кол-во НТВ";
            this.Doc_Qty_Ntv.Name = "Doc_Qty_Ntv";
            this.Doc_Qty_Ntv.ReadOnly = true;
            this.Doc_Qty_Ntv.Width = 115;
            // 
            // colCollectors
            // 
            this.colCollectors.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCollectors.HeaderText = "";
            this.colCollectors.Name = "colCollectors";
            this.colCollectors.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCollectors.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCollectors.Text = "Сборщики";
            this.colCollectors.UseColumnTextForButtonValue = true;
            this.colCollectors.Width = 19;
            // 
            // autoControlItemsInfoBindingSource
            // 
            this.autoControlItemsInfoBindingSource.DataMember = "AutoControlItemsInfo";
            this.autoControlItemsInfoBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsFilter
            // 
            this.tsFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFilter,
            this.tbFilter});
            this.tsFilter.Location = new System.Drawing.Point(0, 39);
            this.tsFilter.Name = "tsFilter";
            this.tsFilter.Size = new System.Drawing.Size(1144, 25);
            this.tsFilter.TabIndex = 2;
            this.tsFilter.Text = "toolStrip1";
            // 
            // lblFilter
            // 
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(123, 22);
            this.lblFilter.Text = "Введите товар/серию:";
            // 
            // tbFilter
            // 
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(105, 25);
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetManualControl,
            this.btnSwitchNTVRegistrationMode});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1144, 39);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnSetManualControl
            // 
            this.btnSetManualControl.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetManualControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSetManualControl.ForeColor = System.Drawing.Color.Red;
            this.btnSetManualControl.Image = global::WMSOffice.Properties.Resources.icon_staff_pick;
            this.btnSetManualControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetManualControl.Name = "btnSetManualControl";
            this.btnSetManualControl.Size = new System.Drawing.Size(139, 36);
            this.btnSetManualControl.Text = "Ручной контроль";
            this.btnSetManualControl.Click += new System.EventHandler(this.btnSetManualControl_Click);
            // 
            // btnSwitchNTVRegistrationMode
            // 
            this.btnSwitchNTVRegistrationMode.CheckOnClick = true;
            this.btnSwitchNTVRegistrationMode.Image = global::WMSOffice.Properties.Resources.hand_yellow_card;
            this.btnSwitchNTVRegistrationMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSwitchNTVRegistrationMode.Name = "btnSwitchNTVRegistrationMode";
            this.btnSwitchNTVRegistrationMode.Size = new System.Drawing.Size(90, 36);
            this.btnSwitchNTVRegistrationMode.Text = "Ввод НТВ";
            this.btnSwitchNTVRegistrationMode.CheckedChanged += new System.EventHandler(this.btnSwitchNTVRegistrationMode_CheckedChanged);
            // 
            // autoControlItemsInfoTableAdapter
            // 
            this.autoControlItemsInfoTableAdapter.ClearBeforeFill = true;
            // 
            // PickControlPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 525);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "PickControlPreviewForm";
            this.Text = "Список товара по сборочному";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PickControlPreviewForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlRecommendedTare.ResumeLayout(false);
            this.pnlRecommendedTare.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoControlItemsInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.tsFilter.ResumeLayout(false);
            this.tsFilter.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPriorityInstructionHeader;
        private System.Windows.Forms.Label lblPriorityInstruction;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblRegim;
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
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnSetManualControl;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource autoControlItemsInfoBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.AutoControlItemsInfoTableAdapter autoControlItemsInfoTableAdapter;
        private System.Windows.Forms.Panel pnlRecommendedTare;
        private System.Windows.Forms.Label lblRecommendedTareCaption;
        private System.Windows.Forms.Label lblRecommendedTare;
        private System.Windows.Forms.DataGridViewImageColumn colSnowFlake;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doc_Qty_Ntv;
        private WMSOffice.Window.DataGridViewDisableButtonColumn colCollectors;
        private System.Windows.Forms.ToolStrip tsFilter;
        private System.Windows.Forms.ToolStripButton btnSwitchNTVRegistrationMode;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.ToolStripLabel lblFilter;
        private System.Windows.Forms.ToolStripTextBox tbFilter;
    }
}