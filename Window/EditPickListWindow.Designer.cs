namespace WMSOffice.Window
{
    partial class EditPickListWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spcToolBoxAndInfo = new System.Windows.Forms.SplitContainer();
            this.tsDoc = new System.Windows.Forms.ToolStrip();
            this.btnEditCurrentItem = new System.Windows.Forms.ToolStripButton();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.pnlPickListInfo = new System.Windows.Forms.Panel();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblRegim = new System.Windows.Forms.Label();
            this.lblContainer = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblRegimHeader = new System.Windows.Forms.Label();
            this.lblDeliveryDateHeader = new System.Windows.Forms.Label();
            this.lblContainerHeader = new System.Windows.Forms.Label();
            this.lblDocDateHeader = new System.Windows.Forms.Label();
            this.lblDocNumberHeader = new System.Windows.Forms.Label();
            this.lblDocTypeHeader = new System.Windows.Forms.Label();
            this.lblDepartmentHeader = new System.Windows.Forms.Label();
            this.lblDeliveryHeader = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblNumberHeader = new System.Windows.Forms.Label();
            this.dgwLines = new System.Windows.Forms.DataGridView();
            this.dgwtbcLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsEditingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditPickList = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnDelCurrentItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelPickList = new System.Windows.Forms.ToolStripMenuItem();
            this.dgwtbcItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtbcItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtbcVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtbcLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtbcUnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtbcManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtbcLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtbcQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtbcQuantityInBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCpPickSlipRow = new System.Windows.Forms.BindingSource(this.components);
            this.dsPickControl = new WMSOffice.Data.PickControl();
            this.taCpPickSlipRow = new WMSOffice.Data.PickControlTableAdapters.CpPickSlipRowTableAdapter();
            this.spcToolBoxAndInfo.Panel1.SuspendLayout();
            this.spcToolBoxAndInfo.Panel2.SuspendLayout();
            this.spcToolBoxAndInfo.SuspendLayout();
            this.tsDoc.SuspendLayout();
            this.pnlPickListInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLines)).BeginInit();
            this.cmsEditingMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCpPickSlipRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // spcToolBoxAndInfo
            // 
            this.spcToolBoxAndInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.spcToolBoxAndInfo.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcToolBoxAndInfo.IsSplitterFixed = true;
            this.spcToolBoxAndInfo.Location = new System.Drawing.Point(0, 0);
            this.spcToolBoxAndInfo.Name = "spcToolBoxAndInfo";
            // 
            // spcToolBoxAndInfo.Panel1
            // 
            this.spcToolBoxAndInfo.Panel1.Controls.Add(this.tsDoc);
            // 
            // spcToolBoxAndInfo.Panel2
            // 
            this.spcToolBoxAndInfo.Panel2.Controls.Add(this.pnlPickListInfo);
            this.spcToolBoxAndInfo.Size = new System.Drawing.Size(986, 83);
            this.spcToolBoxAndInfo.SplitterDistance = 460;
            this.spcToolBoxAndInfo.TabIndex = 2;
            this.spcToolBoxAndInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tsDoc
            // 
            this.tsDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditCurrentItem,
            this.btnDelCurrentItem,
            this.toolStripSeparator1,
            this.btnCloseDoc});
            this.tsDoc.Location = new System.Drawing.Point(0, 0);
            this.tsDoc.Name = "tsDoc";
            this.tsDoc.Size = new System.Drawing.Size(460, 83);
            this.tsDoc.TabIndex = 4;
            this.tsDoc.Text = "Панель инструментов документа";
            // 
            // btnEditCurrentItem
            // 
            this.btnEditCurrentItem.Image = global::WMSOffice.Properties.Resources.F2;
            this.btnEditCurrentItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditCurrentItem.Name = "btnEditCurrentItem";
            this.btnEditCurrentItem.Size = new System.Drawing.Size(148, 80);
            this.btnEditCurrentItem.Text = "Корректировать\n строку";
            this.btnEditCurrentItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCurrentItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnEditCurrentItem.ToolTipText = "Завершить корректировку сборочного";
            this.btnEditCurrentItem.Click += new System.EventHandler(this.BtnEditCurrentItem_Click);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.F4;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(145, 80);
            this.btnCloseDoc.Text = "Завершить\n\r корректировку\n\r сборочного";
            this.btnCloseDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseDoc.ToolTipText = "Завершить корректировку сборочного";
            this.btnCloseDoc.Click += new System.EventHandler(this.BtnCloseDoc_Click);
            // 
            // pnlPickListInfo
            // 
            this.pnlPickListInfo.Controls.Add(this.lblDepartment);
            this.pnlPickListInfo.Controls.Add(this.lblRegim);
            this.pnlPickListInfo.Controls.Add(this.lblContainer);
            this.pnlPickListInfo.Controls.Add(this.lblDeliveryDate);
            this.pnlPickListInfo.Controls.Add(this.lblDocDate);
            this.pnlPickListInfo.Controls.Add(this.lblDocNumber);
            this.pnlPickListInfo.Controls.Add(this.lblDocType);
            this.pnlPickListInfo.Controls.Add(this.lblDelivery);
            this.pnlPickListInfo.Controls.Add(this.lblRegimHeader);
            this.pnlPickListInfo.Controls.Add(this.lblDeliveryDateHeader);
            this.pnlPickListInfo.Controls.Add(this.lblContainerHeader);
            this.pnlPickListInfo.Controls.Add(this.lblDocDateHeader);
            this.pnlPickListInfo.Controls.Add(this.lblDocNumberHeader);
            this.pnlPickListInfo.Controls.Add(this.lblDocTypeHeader);
            this.pnlPickListInfo.Controls.Add(this.lblDepartmentHeader);
            this.pnlPickListInfo.Controls.Add(this.lblDeliveryHeader);
            this.pnlPickListInfo.Controls.Add(this.lblNumber);
            this.pnlPickListInfo.Controls.Add(this.lblNumberHeader);
            this.pnlPickListInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPickListInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlPickListInfo.Name = "pnlPickListInfo";
            this.pnlPickListInfo.Size = new System.Drawing.Size(522, 82);
            this.pnlPickListInfo.TabIndex = 2;
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDepartment.Location = new System.Drawing.Point(346, 9);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(269, 13);
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
            // lblRegimHeader
            // 
            this.lblRegimHeader.AutoSize = true;
            this.lblRegimHeader.Location = new System.Drawing.Point(299, 42);
            this.lblRegimHeader.Name = "lblRegimHeader";
            this.lblRegimHeader.Size = new System.Drawing.Size(45, 13);
            this.lblRegimHeader.TabIndex = 11;
            this.lblRegimHeader.Text = "Режим:";
            // 
            // lblDeliveryDateHeader
            // 
            this.lblDeliveryDateHeader.AutoSize = true;
            this.lblDeliveryDateHeader.Location = new System.Drawing.Point(13, 43);
            this.lblDeliveryDateHeader.Name = "lblDeliveryDateHeader";
            this.lblDeliveryDateHeader.Size = new System.Drawing.Size(86, 13);
            this.lblDeliveryDateHeader.TabIndex = 10;
            this.lblDeliveryDateHeader.Text = "Дата доставки:";
            // 
            // lblContainerHeader
            // 
            this.lblContainerHeader.AutoSize = true;
            this.lblContainerHeader.Location = new System.Drawing.Point(199, 9);
            this.lblContainerHeader.Name = "lblContainerHeader";
            this.lblContainerHeader.Size = new System.Drawing.Size(64, 13);
            this.lblContainerHeader.TabIndex = 9;
            this.lblContainerHeader.Text = "Контейнер:";
            // 
            // lblDocDateHeader
            // 
            this.lblDocDateHeader.AutoSize = true;
            this.lblDocDateHeader.Location = new System.Drawing.Point(13, 26);
            this.lblDocDateHeader.Name = "lblDocDateHeader";
            this.lblDocDateHeader.Size = new System.Drawing.Size(75, 13);
            this.lblDocDateHeader.TabIndex = 8;
            this.lblDocDateHeader.Text = "Дата заказа:";
            // 
            // lblDocNumberHeader
            // 
            this.lblDocNumberHeader.AutoSize = true;
            this.lblDocNumberHeader.Location = new System.Drawing.Point(299, 26);
            this.lblDocNumberHeader.Name = "lblDocNumberHeader";
            this.lblDocNumberHeader.Size = new System.Drawing.Size(60, 13);
            this.lblDocNumberHeader.TabIndex = 7;
            this.lblDocNumberHeader.Text = "№ заказа:";
            // 
            // lblDocTypeHeader
            // 
            this.lblDocTypeHeader.AutoSize = true;
            this.lblDocTypeHeader.Location = new System.Drawing.Point(199, 26);
            this.lblDocTypeHeader.Name = "lblDocTypeHeader";
            this.lblDocTypeHeader.Size = new System.Drawing.Size(68, 13);
            this.lblDocTypeHeader.TabIndex = 6;
            this.lblDocTypeHeader.Text = "Тип заказа:";
            // 
            // lblDepartmentHeader
            // 
            this.lblDepartmentHeader.AutoSize = true;
            this.lblDepartmentHeader.Location = new System.Drawing.Point(299, 9);
            this.lblDepartmentHeader.Name = "lblDepartmentHeader";
            this.lblDepartmentHeader.Size = new System.Drawing.Size(41, 13);
            this.lblDepartmentHeader.TabIndex = 5;
            this.lblDepartmentHeader.Text = "Отдел:";
            // 
            // lblDeliveryHeader
            // 
            this.lblDeliveryHeader.AutoSize = true;
            this.lblDeliveryHeader.Location = new System.Drawing.Point(13, 60);
            this.lblDeliveryHeader.Name = "lblDeliveryHeader";
            this.lblDeliveryHeader.Size = new System.Drawing.Size(69, 13);
            this.lblDeliveryHeader.TabIndex = 4;
            this.lblDeliveryHeader.Text = "Получатель:";
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
            // lblNumberHeader
            // 
            this.lblNumberHeader.AutoSize = true;
            this.lblNumberHeader.Location = new System.Drawing.Point(13, 9);
            this.lblNumberHeader.Name = "lblNumberHeader";
            this.lblNumberHeader.Size = new System.Drawing.Size(103, 13);
            this.lblNumberHeader.TabIndex = 0;
            this.lblNumberHeader.Text = "Сборочный лист №";
            // 
            // dgwLines
            // 
            this.dgwLines.AllowUserToAddRows = false;
            this.dgwLines.AllowUserToDeleteRows = false;
            this.dgwLines.AllowUserToResizeRows = false;
            this.dgwLines.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgwtbcLineId,
            this.dgwtbcItemId,
            this.dgwtbcItemName,
            this.dgwtbcVendorLot,
            this.dgwtbcLotNumber,
            this.dgwtbcUnitOfMeasure,
            this.dgwtbcManufacturer,
            this.dgwtbcLocation,
            this.dgwtbcQuantity,
            this.dgwtbcQuantityInBox});
            this.dgwLines.DataSource = this.bsCpPickSlipRow;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwLines.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgwLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwLines.Location = new System.Drawing.Point(0, 83);
            this.dgwLines.MultiSelect = false;
            this.dgwLines.Name = "dgwLines";
            this.dgwLines.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgwLines.RowTemplate.ContextMenuStrip = this.cmsEditingMenu;
            this.dgwLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgwLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwLines.Size = new System.Drawing.Size(986, 305);
            this.dgwLines.TabIndex = 1;
            this.dgwLines.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.DgvLines_RowContextMenuStripNeeded);
            this.dgwLines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.dgwLines.SelectionChanged += new System.EventHandler(this.dgwLines_SelectionChanged);
            // 
            // dgwtbcLineId
            // 
            this.dgwtbcLineId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcLineId.DataPropertyName = "Line_ID";
            this.dgwtbcLineId.HeaderText = "Номер строки";
            this.dgwtbcLineId.Name = "dgwtbcLineId";
            this.dgwtbcLineId.ReadOnly = true;
            this.dgwtbcLineId.Width = 115;
            // 
            // cmsEditingMenu
            // 
            this.cmsEditingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditPickList,
            this.tsmiDelPickList});
            this.cmsEditingMenu.Name = "cmsEditingMenu";
            this.cmsEditingMenu.Size = new System.Drawing.Size(216, 48);
            // 
            // tsmiEditPickList
            // 
            this.tsmiEditPickList.Name = "tsmiEditPickList";
            this.tsmiEditPickList.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmiEditPickList.Size = new System.Drawing.Size(215, 22);
            this.tsmiEditPickList.Text = "Корректиовать строку";
            this.tsmiEditPickList.Click += new System.EventHandler(this.TsmiEditPickList_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Line_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер строки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Код";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "VendorLot";
            this.dataGridViewTextBoxColumn4.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "LotNumber";
            this.dataGridViewTextBoxColumn5.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UnitOfMeasure";
            this.dataGridViewTextBoxColumn6.HeaderText = "ЕИ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Manufacturer";
            this.dataGridViewTextBoxColumn7.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn8.HeaderText = "Размещение";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn9.HeaderText = "Количество";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "QuantityInBX";
            this.dataGridViewTextBoxColumn10.HeaderText = "Кол-во в ящике";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // btnDelCurrentItem
            // 
            this.btnDelCurrentItem.Image = global::WMSOffice.Properties.Resources.F8;
            this.btnDelCurrentItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelCurrentItem.Name = "btnDelCurrentItem";
            this.btnDelCurrentItem.Size = new System.Drawing.Size(138, 80);
            this.btnDelCurrentItem.Text = "Аннулировать\n строку";
            this.btnDelCurrentItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelCurrentItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnDelCurrentItem.ToolTipText = "Завершить корректировку сборочного";
            this.btnDelCurrentItem.Click += new System.EventHandler(this.btnDelCurrentItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 83);
            // 
            // tsmiDelPickList
            // 
            this.tsmiDelPickList.Name = "tsmiDelPickList";
            this.tsmiDelPickList.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tsmiDelPickList.Size = new System.Drawing.Size(215, 22);
            this.tsmiDelPickList.Text = "Аннулировать строку";
            this.tsmiDelPickList.Click += new System.EventHandler(this.tsmiDelPickList_Click);
            // 
            // dgwtbcItemId
            // 
            this.dgwtbcItemId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcItemId.DataPropertyName = "Item_ID";
            this.dgwtbcItemId.HeaderText = "Код";
            this.dgwtbcItemId.Name = "dgwtbcItemId";
            this.dgwtbcItemId.ReadOnly = true;
            this.dgwtbcItemId.Width = 58;
            // 
            // dgwtbcItemName
            // 
            this.dgwtbcItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcItemName.DataPropertyName = "ItemName";
            this.dgwtbcItemName.HeaderText = "Наименование";
            this.dgwtbcItemName.Name = "dgwtbcItemName";
            this.dgwtbcItemName.ReadOnly = true;
            this.dgwtbcItemName.Width = 131;
            // 
            // dgwtbcVendorLot
            // 
            this.dgwtbcVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcVendorLot.DataPropertyName = "VendorLot";
            this.dgwtbcVendorLot.HeaderText = "Серия";
            this.dgwtbcVendorLot.Name = "dgwtbcVendorLot";
            this.dgwtbcVendorLot.ReadOnly = true;
            this.dgwtbcVendorLot.Width = 74;
            // 
            // dgwtbcLotNumber
            // 
            this.dgwtbcLotNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcLotNumber.DataPropertyName = "LotNumber";
            this.dgwtbcLotNumber.HeaderText = "Партия";
            this.dgwtbcLotNumber.Name = "dgwtbcLotNumber";
            this.dgwtbcLotNumber.ReadOnly = true;
            this.dgwtbcLotNumber.Width = 82;
            // 
            // dgwtbcUnitOfMeasure
            // 
            this.dgwtbcUnitOfMeasure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcUnitOfMeasure.DataPropertyName = "UnitOfMeasure";
            this.dgwtbcUnitOfMeasure.HeaderText = "ЕИ";
            this.dgwtbcUnitOfMeasure.Name = "dgwtbcUnitOfMeasure";
            this.dgwtbcUnitOfMeasure.ReadOnly = true;
            this.dgwtbcUnitOfMeasure.Width = 52;
            // 
            // dgwtbcManufacturer
            // 
            this.dgwtbcManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcManufacturer.DataPropertyName = "Manufacturer";
            this.dgwtbcManufacturer.HeaderText = "Производитель";
            this.dgwtbcManufacturer.Name = "dgwtbcManufacturer";
            this.dgwtbcManufacturer.ReadOnly = true;
            this.dgwtbcManufacturer.Width = 135;
            // 
            // dgwtbcLocation
            // 
            this.dgwtbcLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcLocation.DataPropertyName = "Location";
            this.dgwtbcLocation.HeaderText = "Размещение";
            this.dgwtbcLocation.Name = "dgwtbcLocation";
            this.dgwtbcLocation.ReadOnly = true;
            this.dgwtbcLocation.Width = 117;
            // 
            // dgwtbcQuantity
            // 
            this.dgwtbcQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcQuantity.DataPropertyName = "Quantity";
            this.dgwtbcQuantity.HeaderText = "Кол-во";
            this.dgwtbcQuantity.Name = "dgwtbcQuantity";
            this.dgwtbcQuantity.ReadOnly = true;
            this.dgwtbcQuantity.Width = 78;
            // 
            // dgwtbcQuantityInBox
            // 
            this.dgwtbcQuantityInBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgwtbcQuantityInBox.DataPropertyName = "QuantityInBX";
            this.dgwtbcQuantityInBox.HeaderText = "Кол-во в ящике";
            this.dgwtbcQuantityInBox.Name = "dgwtbcQuantityInBox";
            this.dgwtbcQuantityInBox.ReadOnly = true;
            this.dgwtbcQuantityInBox.Width = 86;
            // 
            // bsCpPickSlipRow
            // 
            this.bsCpPickSlipRow.DataMember = "CpPickSlipRow";
            this.bsCpPickSlipRow.DataSource = this.dsPickControl;
            // 
            // dsPickControl
            // 
            this.dsPickControl.DataSetName = "PickControl";
            this.dsPickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taCpPickSlipRow
            // 
            this.taCpPickSlipRow.ClearBeforeFill = true;
            // 
            // EditPickListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 388);
            this.Controls.Add(this.dgwLines);
            this.Controls.Add(this.spcToolBoxAndInfo);
            this.Name = "EditPickListWindow";
            this.ShowIcon = false;
            this.Text = "Корректировка сборочного листа";
            this.Load += new System.EventHandler(this.EditPickListWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditPickListWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.spcToolBoxAndInfo.Panel1.ResumeLayout(false);
            this.spcToolBoxAndInfo.Panel1.PerformLayout();
            this.spcToolBoxAndInfo.Panel2.ResumeLayout(false);
            this.spcToolBoxAndInfo.ResumeLayout(false);
            this.tsDoc.ResumeLayout(false);
            this.tsDoc.PerformLayout();
            this.pnlPickListInfo.ResumeLayout(false);
            this.pnlPickListInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLines)).EndInit();
            this.cmsEditingMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCpPickSlipRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPickControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDoc;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.Panel pnlPickListInfo;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblRegim;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label lblRegimHeader;
        private System.Windows.Forms.Label lblDeliveryDateHeader;
        private System.Windows.Forms.Label lblContainerHeader;
        private System.Windows.Forms.Label lblDocDateHeader;
        private System.Windows.Forms.Label lblDocNumberHeader;
        private System.Windows.Forms.Label lblDocTypeHeader;
        private System.Windows.Forms.Label lblDepartmentHeader;
        private System.Windows.Forms.Label lblDeliveryHeader;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblNumberHeader;
        private System.Windows.Forms.DataGridView dgwLines;
        private System.Windows.Forms.BindingSource bsCpPickSlipRow;
        private WMSOffice.Data.PickControl dsPickControl;
        private WMSOffice.Data.PickControlTableAdapters.CpPickSlipRowTableAdapter taCpPickSlipRow;
        private System.Windows.Forms.ContextMenuStrip cmsEditingMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditPickList;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcUnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwtbcQuantityInBox;
        private System.Windows.Forms.ToolStripButton btnEditCurrentItem;
        private System.Windows.Forms.SplitContainer spcToolBoxAndInfo;
        private System.Windows.Forms.ToolStripButton btnDelCurrentItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelPickList;

    }
}