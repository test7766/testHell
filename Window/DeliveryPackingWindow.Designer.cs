namespace WMSOffice.Window
{
    partial class DeliveryPackingWindow
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
            this.cmsOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.delivery = new WMSOffice.Data.Delivery();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTermobox = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblPerron = new System.Windows.Forms.Label();
            this.barcodeInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblPSNWork = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPlaceTotal = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPlaceWork = new System.Windows.Forms.Label();
            this.lblPSNTotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRouteList = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblRegim = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.barcodeInfoTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.BarcodeInfoTableAdapter();
            this.xdgvLines = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmsOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripDoc.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsOperations
            // 
            this.cmsOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUndo,
            this.miRefresh});
            this.cmsOperations.Name = "contextMenuStrip1";
            this.cmsOperations.Size = new System.Drawing.Size(381, 48);
            // 
            // miUndo
            // 
            this.miUndo.Name = "miUndo";
            this.miUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miUndo.Size = new System.Drawing.Size(380, 22);
            this.miUndo.Text = "Отменить комплектацию текущего сборочного";
            this.miUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // miRefresh
            // 
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(380, 22);
            this.miRefresh.Text = "&Обновить";
            this.miRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.tbBarcode);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripDoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1218, 122);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Штрих-код:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.ContextMenuStrip = this.cmsOperations;
            this.tbBarcode.DelayThreshold = 50;
            this.tbBarcode.Location = new System.Drawing.Point(12, 77);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.Size = new System.Drawing.Size(265, 25);
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
            this.btnRefresh});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(280, 55);
            this.toolStripDoc.TabIndex = 4;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(199, 52);
            this.btnUndo.Text = "Отменить комплектацию\n\r текущего сборочного";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить\n\r содержимое";
            this.btnRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTermobox);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblPerron);
            this.panel1.Controls.Add(this.lblPSNWork);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblPlaceTotal);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblPlaceWork);
            this.panel1.Controls.Add(this.lblPSNTotal);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblCar);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblRouteList);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblDepartment);
            this.panel1.Controls.Add(this.lblRegim);
            this.panel1.Controls.Add(this.lblDeliveryDate);
            this.panel1.Controls.Add(this.lblDocNumber);
            this.panel1.Controls.Add(this.lblDocType);
            this.panel1.Controls.Add(this.lblDelivery);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblNumber);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 122);
            this.panel1.TabIndex = 2;
            // 
            // lblTermobox
            // 
            this.lblTermobox.AutoSize = true;
            this.lblTermobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTermobox.ForeColor = System.Drawing.Color.Blue;
            this.lblTermobox.Location = new System.Drawing.Point(545, 52);
            this.lblTermobox.Name = "lblTermobox";
            this.lblTermobox.Size = new System.Drawing.Size(375, 25);
            this.lblTermobox.TabIndex = 37;
            this.lblTermobox.Text = "Положите товар в термоконтейнер №";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(419, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Перрон:";
            // 
            // lblPerron
            // 
            this.lblPerron.AutoSize = true;
            this.lblPerron.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.barcodeInfoBindingSource, "Peron_ID", true));
            this.lblPerron.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPerron.ForeColor = System.Drawing.Color.Blue;
            this.lblPerron.Location = new System.Drawing.Point(473, 45);
            this.lblPerron.Name = "lblPerron";
            this.lblPerron.Size = new System.Drawing.Size(66, 46);
            this.lblPerron.TabIndex = 36;
            this.lblPerron.Text = "17";
            // 
            // barcodeInfoBindingSource
            // 
            this.barcodeInfoBindingSource.DataMember = "BarcodeInfo";
            this.barcodeInfoBindingSource.DataSource = this.delivery;
            // 
            // lblPSNWork
            // 
            this.lblPSNWork.AutoSize = true;
            this.lblPSNWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPSNWork.Location = new System.Drawing.Point(463, 29);
            this.lblPSNWork.Name = "lblPSNWork";
            this.lblPSNWork.Size = new System.Drawing.Size(28, 13);
            this.lblPSNWork.TabIndex = 34;
            this.lblPSNWork.Text = "210";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(497, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "из";
            // 
            // lblPlaceTotal
            // 
            this.lblPlaceTotal.AutoSize = true;
            this.lblPlaceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlaceTotal.Location = new System.Drawing.Point(522, 13);
            this.lblPlaceTotal.Name = "lblPlaceTotal";
            this.lblPlaceTotal.Size = new System.Drawing.Size(28, 13);
            this.lblPlaceTotal.TabIndex = 32;
            this.lblPlaceTotal.Text = "120";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(497, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "из";
            // 
            // lblPlaceWork
            // 
            this.lblPlaceWork.AutoSize = true;
            this.lblPlaceWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlaceWork.Location = new System.Drawing.Point(463, 13);
            this.lblPlaceWork.Name = "lblPlaceWork";
            this.lblPlaceWork.Size = new System.Drawing.Size(28, 13);
            this.lblPlaceWork.TabIndex = 30;
            this.lblPlaceWork.Text = "100";
            // 
            // lblPSNTotal
            // 
            this.lblPSNTotal.AutoSize = true;
            this.lblPSNTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPSNTotal.Location = new System.Drawing.Point(522, 29);
            this.lblPSNTotal.Name = "lblPSNTotal";
            this.lblPSNTotal.Size = new System.Drawing.Size(28, 13);
            this.lblPSNTotal.TabIndex = 29;
            this.lblPSNTotal.Text = "321";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(419, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Сбор.:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(419, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Мест:";
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCar.Location = new System.Drawing.Point(271, 61);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(79, 13);
            this.lblCar.TabIndex = 26;
            this.lblCar.Text = "AA 12-34 AA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Авто:";
            // 
            // lblRouteList
            // 
            this.lblRouteList.AutoSize = true;
            this.lblRouteList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRouteList.Location = new System.Drawing.Point(122, 61);
            this.lblRouteList.Name = "lblRouteList";
            this.lblRouteList.Size = new System.Drawing.Size(70, 13);
            this.lblRouteList.TabIndex = 24;
            this.lblRouteList.Text = "123456789";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Маршрутный лист:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAddress.Location = new System.Drawing.Point(122, 101);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(219, 13);
            this.lblAddress.TabIndex = 22;
            this.lblAddress.Text = "КИЕВ, проспект ПОБЕДЫ 36, оф. 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Адрес:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDepartment.Location = new System.Drawing.Point(271, 13);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(142, 13);
            this.lblDepartment.TabIndex = 19;
            this.lblDepartment.Text = "Сектор 001-019";
            // 
            // lblRegim
            // 
            this.lblRegim.AutoSize = true;
            this.lblRegim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRegim.Location = new System.Drawing.Point(271, 45);
            this.lblRegim.Name = "lblRegim";
            this.lblRegim.Size = new System.Drawing.Size(97, 13);
            this.lblRegim.TabIndex = 18;
            this.lblRegim.Text = "Доставка день";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDeliveryDate.Location = new System.Drawing.Point(122, 45);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(71, 13);
            this.lblDeliveryDate.TabIndex = 16;
            this.lblDeliveryDate.Text = "21.04.2010";
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocNumber.Location = new System.Drawing.Point(122, 29);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(70, 13);
            this.lblDocNumber.TabIndex = 14;
            this.lblDocNumber.Text = "123456789";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocType.Location = new System.Drawing.Point(271, 29);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(21, 13);
            this.lblDocType.TabIndex = 13;
            this.lblDocType.Text = "01";
            // 
            // lblDelivery
            // 
            this.lblDelivery.AutoSize = true;
            this.lblDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDelivery.Location = new System.Drawing.Point(122, 85);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(262, 13);
            this.lblDelivery.TabIndex = 12;
            this.lblDelivery.Text = "(12345) НАИМЕНОВАНИЕ КЛИЕНТА, КИЕВ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(199, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Режим:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Дата доставки:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "№ заказа:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Тип заказа:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отдел:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Получатель:";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumber.Location = new System.Drawing.Point(122, 13);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(70, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "123456789";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Сборочный лист №";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblP.Location = new System.Drawing.Point(463, 41);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(48, 13);
            this.lblP.TabIndex = 29;
            this.lblP.Text = "label14";
            // 
            // barcodeInfoTableAdapter
            // 
            this.barcodeInfoTableAdapter.ClearBeforeFill = true;
            // 
            // xdgvLines
            // 
            this.xdgvLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvLines.LargeAmountOfData = false;
            this.xdgvLines.Location = new System.Drawing.Point(0, 162);
            this.xdgvLines.Name = "xdgvLines";
            this.xdgvLines.RowHeadersVisible = false;
            this.xdgvLines.Size = new System.Drawing.Size(1218, 433);
            this.xdgvLines.TabIndex = 6;
            this.xdgvLines.UserID = ((long)(0));
            // 
            // DeliveryPackingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 595);
            this.Controls.Add(this.xdgvLines);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DeliveryPackingWindow";
            this.Text = "Комплектация товара в Экспедиции";
            this.Load += new System.EventHandler(this.DeliveryPackingWindow_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeliveryPackingWindow_FormClosed);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.xdgvLines, 0);
            this.cmsOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WMSOffice.Data.Delivery delivery;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label10;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblRegim;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.BindingSource barcodeInfoBindingSource;
        private WMSOffice.Data.DeliveryTableAdapters.BarcodeInfoTableAdapter barcodeInfoTableAdapter;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRouteList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblPSNTotal;
        private System.Windows.Forms.Label lblPlaceTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblPlaceWork;
        private System.Windows.Forms.Label lblPSNWork;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblPerron;
        private System.Windows.Forms.ContextMenuStrip cmsOperations;
        private System.Windows.Forms.ToolStripMenuItem miUndo;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Label lblTermobox;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvLines;
    }
}