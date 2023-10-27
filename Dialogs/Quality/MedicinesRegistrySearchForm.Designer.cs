namespace WMSOffice.Dialogs.Quality
{
    partial class MedicinesRegistrySearchForm
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
            this.rbOrderNumber = new System.Windows.Forms.RadioButton();
            this.rbSupplierCode = new System.Windows.Forms.RadioButton();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSupplier = new System.Windows.Forms.Panel();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.tbSupplierCode = new System.Windows.Forms.TextBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDrugs = new System.Windows.Forms.Panel();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDrugsCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbDrugsCode = new System.Windows.Forms.RadioButton();
            this.pnlInternalDate = new System.Windows.Forms.Panel();
            this.dtInternalEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtInternalStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rbInternalDate = new System.Windows.Forms.RadioButton();
            this.rbQualityInfo = new System.Windows.Forms.RadioButton();
            this.pnlQualityInfo = new System.Windows.Forms.Panel();
            this.tbLotNumber = new System.Windows.Forms.TextBox();
            this.tbVendorInvoice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chbQualityDateFilter = new System.Windows.Forms.CheckBox();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.rbtNotPermitted = new System.Windows.Forms.RadioButton();
            this.rbtPermitted = new System.Windows.Forms.RadioButton();
            this.dtpQualityDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpQualityDateFrom = new System.Windows.Forms.DateTimePicker();
            this.tbxQualityVendorID = new System.Windows.Forms.TextBox();
            this.lblQualityDateTo = new System.Windows.Forms.Label();
            this.lblQualityVendorID = new System.Windows.Forms.Label();
            this.lblQualityDateFrom = new System.Windows.Forms.Label();
            this.tbxQualityVendorLot = new System.Windows.Forms.TextBox();
            this.lblQualityVendorLot = new System.Windows.Forms.Label();
            this.tbxQualityItemID = new System.Windows.Forms.TextBox();
            this.lblQualityItemID = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.pnlSupplier.SuspendLayout();
            this.pnlDrugs.SuspendLayout();
            this.pnlInternalDate.SuspendLayout();
            this.pnlQualityInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1137, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1227, 8);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 588);
            this.pnlButtons.Size = new System.Drawing.Size(450, 43);
            // 
            // rbOrderNumber
            // 
            this.rbOrderNumber.AutoSize = true;
            this.rbOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbOrderNumber.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbOrderNumber.Location = new System.Drawing.Point(9, 5);
            this.rbOrderNumber.Name = "rbOrderNumber";
            this.rbOrderNumber.Size = new System.Drawing.Size(160, 20);
            this.rbOrderNumber.TabIndex = 10;
            this.rbOrderNumber.TabStop = true;
            this.rbOrderNumber.Text = "по номеру заказа";
            this.rbOrderNumber.UseVisualStyleBackColor = true;
            this.rbOrderNumber.CheckedChanged += new System.EventHandler(this.rbMainFilterItem_CheckedChanged);
            // 
            // rbSupplierCode
            // 
            this.rbSupplierCode.AutoSize = true;
            this.rbSupplierCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbSupplierCode.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbSupplierCode.Location = new System.Drawing.Point(9, 62);
            this.rbSupplierCode.Name = "rbSupplierCode";
            this.rbSupplierCode.Size = new System.Drawing.Size(175, 20);
            this.rbSupplierCode.TabIndex = 30;
            this.rbSupplierCode.TabStop = true;
            this.rbSupplierCode.Text = "по коду поставщика";
            this.rbSupplierCode.UseVisualStyleBackColor = true;
            this.rbSupplierCode.CheckedChanged += new System.EventHandler(this.rbMainFilterItem_CheckedChanged);
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.tbOrderNumber);
            this.pnlOrder.Controls.Add(this.label1);
            this.pnlOrder.Location = new System.Drawing.Point(9, 27);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(433, 29);
            this.pnlOrder.TabIndex = 11;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(99, 3);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(116, 20);
            this.tbOrderNumber.TabIndex = 20;
            this.tbOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterTextItem_KeyDown);
            this.tbOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ заказа :";
            // 
            // pnlSupplier
            // 
            this.pnlSupplier.Controls.Add(this.dtEndDate);
            this.pnlSupplier.Controls.Add(this.tbSupplierCode);
            this.pnlSupplier.Controls.Add(this.dtStartDate);
            this.pnlSupplier.Controls.Add(this.label4);
            this.pnlSupplier.Controls.Add(this.label2);
            this.pnlSupplier.Controls.Add(this.label3);
            this.pnlSupplier.Location = new System.Drawing.Point(9, 84);
            this.pnlSupplier.Name = "pnlSupplier";
            this.pnlSupplier.Size = new System.Drawing.Size(433, 61);
            this.pnlSupplier.TabIndex = 31;
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "dd / MM / yyyy";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(302, 36);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(116, 20);
            this.dtEndDate.TabIndex = 60;
            // 
            // tbSupplierCode
            // 
            this.tbSupplierCode.Location = new System.Drawing.Point(99, 9);
            this.tbSupplierCode.Name = "tbSupplierCode";
            this.tbSupplierCode.Size = new System.Drawing.Size(116, 20);
            this.tbSupplierCode.TabIndex = 40;
            this.tbSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterTextItem_KeyDown);
            this.tbSupplierCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "dd / MM / yyyy";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(99, 36);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(116, 20);
            this.dtStartDate.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Дата \"по\" :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Код поставщика :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Дата \"с\" :";
            // 
            // pnlDrugs
            // 
            this.pnlDrugs.Controls.Add(this.tbVendorLot);
            this.pnlDrugs.Controls.Add(this.label6);
            this.pnlDrugs.Controls.Add(this.tbDrugsCode);
            this.pnlDrugs.Controls.Add(this.label5);
            this.pnlDrugs.Location = new System.Drawing.Point(9, 235);
            this.pnlDrugs.Name = "pnlDrugs";
            this.pnlDrugs.Size = new System.Drawing.Size(433, 60);
            this.pnlDrugs.TabIndex = 101;
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.Location = new System.Drawing.Point(99, 34);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.Size = new System.Drawing.Size(111, 20);
            this.tbVendorLot.TabIndex = 120;
            this.tbVendorLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterTextItem_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Серия :";
            // 
            // tbDrugsCode
            // 
            this.tbDrugsCode.Location = new System.Drawing.Point(99, 7);
            this.tbDrugsCode.Name = "tbDrugsCode";
            this.tbDrugsCode.Size = new System.Drawing.Size(111, 20);
            this.tbDrugsCode.TabIndex = 110;
            this.tbDrugsCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDrugsCode_KeyDown);
            this.tbDrugsCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Код товара :";
            // 
            // rbDrugsCode
            // 
            this.rbDrugsCode.AutoSize = true;
            this.rbDrugsCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbDrugsCode.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbDrugsCode.Location = new System.Drawing.Point(9, 213);
            this.rbDrugsCode.Name = "rbDrugsCode";
            this.rbDrugsCode.Size = new System.Drawing.Size(101, 20);
            this.rbDrugsCode.TabIndex = 100;
            this.rbDrugsCode.TabStop = true;
            this.rbDrugsCode.Text = "по товару";
            this.rbDrugsCode.UseVisualStyleBackColor = true;
            this.rbDrugsCode.CheckedChanged += new System.EventHandler(this.rbMainFilterItem_CheckedChanged);
            // 
            // pnlInternalDate
            // 
            this.pnlInternalDate.Controls.Add(this.dtInternalEndDate);
            this.pnlInternalDate.Controls.Add(this.dtInternalStartDate);
            this.pnlInternalDate.Controls.Add(this.label7);
            this.pnlInternalDate.Controls.Add(this.label8);
            this.pnlInternalDate.Location = new System.Drawing.Point(9, 174);
            this.pnlInternalDate.Name = "pnlInternalDate";
            this.pnlInternalDate.Size = new System.Drawing.Size(433, 28);
            this.pnlInternalDate.TabIndex = 71;
            // 
            // dtInternalEndDate
            // 
            this.dtInternalEndDate.CustomFormat = "dd / MM / yyyy";
            this.dtInternalEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInternalEndDate.Location = new System.Drawing.Point(307, 4);
            this.dtInternalEndDate.Name = "dtInternalEndDate";
            this.dtInternalEndDate.Size = new System.Drawing.Size(110, 20);
            this.dtInternalEndDate.TabIndex = 90;
            // 
            // dtInternalStartDate
            // 
            this.dtInternalStartDate.CustomFormat = "dd / MM / yyyy";
            this.dtInternalStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInternalStartDate.Location = new System.Drawing.Point(99, 4);
            this.dtInternalStartDate.Name = "dtInternalStartDate";
            this.dtInternalStartDate.Size = new System.Drawing.Size(111, 20);
            this.dtInternalStartDate.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Дата \"по\" :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Дата \"с\" :";
            // 
            // rbInternalDate
            // 
            this.rbInternalDate.AutoSize = true;
            this.rbInternalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbInternalDate.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbInternalDate.Location = new System.Drawing.Point(9, 152);
            this.rbInternalDate.Name = "rbInternalDate";
            this.rbInternalDate.Size = new System.Drawing.Size(93, 20);
            this.rbInternalDate.TabIndex = 70;
            this.rbInternalDate.TabStop = true;
            this.rbInternalDate.Text = "по датам";
            this.rbInternalDate.UseVisualStyleBackColor = true;
            this.rbInternalDate.CheckedChanged += new System.EventHandler(this.rbMainFilterItem_CheckedChanged);
            // 
            // rbQualityInfo
            // 
            this.rbQualityInfo.AutoSize = true;
            this.rbQualityInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbQualityInfo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbQualityInfo.Location = new System.Drawing.Point(9, 313);
            this.rbQualityInfo.Name = "rbQualityInfo";
            this.rbQualityInfo.Size = new System.Drawing.Size(266, 20);
            this.rbQualityInfo.TabIndex = 130;
            this.rbQualityInfo.TabStop = true;
            this.rbQualityInfo.Text = "по разрешениям на реализацию";
            this.rbQualityInfo.UseVisualStyleBackColor = true;
            this.rbQualityInfo.CheckedChanged += new System.EventHandler(this.rbMainFilterItem_CheckedChanged);
            // 
            // pnlQualityInfo
            // 
            this.pnlQualityInfo.Controls.Add(this.tbLotNumber);
            this.pnlQualityInfo.Controls.Add(this.tbVendorInvoice);
            this.pnlQualityInfo.Controls.Add(this.label10);
            this.pnlQualityInfo.Controls.Add(this.label9);
            this.pnlQualityInfo.Controls.Add(this.chbQualityDateFilter);
            this.pnlQualityInfo.Controls.Add(this.rbtAll);
            this.pnlQualityInfo.Controls.Add(this.rbtNotPermitted);
            this.pnlQualityInfo.Controls.Add(this.rbtPermitted);
            this.pnlQualityInfo.Controls.Add(this.dtpQualityDateTo);
            this.pnlQualityInfo.Controls.Add(this.dtpQualityDateFrom);
            this.pnlQualityInfo.Controls.Add(this.tbxQualityVendorID);
            this.pnlQualityInfo.Controls.Add(this.lblQualityDateTo);
            this.pnlQualityInfo.Controls.Add(this.lblQualityVendorID);
            this.pnlQualityInfo.Controls.Add(this.lblQualityDateFrom);
            this.pnlQualityInfo.Controls.Add(this.tbxQualityVendorLot);
            this.pnlQualityInfo.Controls.Add(this.lblQualityVendorLot);
            this.pnlQualityInfo.Controls.Add(this.tbxQualityItemID);
            this.pnlQualityInfo.Controls.Add(this.lblQualityItemID);
            this.pnlQualityInfo.Location = new System.Drawing.Point(9, 339);
            this.pnlQualityInfo.Name = "pnlQualityInfo";
            this.pnlQualityInfo.Size = new System.Drawing.Size(433, 243);
            this.pnlQualityInfo.TabIndex = 131;
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.Location = new System.Drawing.Point(282, 35);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.Size = new System.Drawing.Size(111, 20);
            this.tbLotNumber.TabIndex = 214;
            // 
            // tbVendorInvoice
            // 
            this.tbVendorInvoice.Location = new System.Drawing.Point(109, 74);
            this.tbVendorInvoice.Name = "tbVendorInvoice";
            this.tbVendorInvoice.Size = new System.Drawing.Size(111, 20);
            this.tbVendorInvoice.TabIndex = 213;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 212;
            this.label10.Text = "№ накл. поставки:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 211;
            this.label9.Text = "Партия:";
            // 
            // chbQualityDateFilter
            // 
            this.chbQualityDateFilter.AutoSize = true;
            this.chbQualityDateFilter.Location = new System.Drawing.Point(21, 100);
            this.chbQualityDateFilter.Name = "chbQualityDateFilter";
            this.chbQualityDateFilter.Size = new System.Drawing.Size(144, 17);
            this.chbQualityDateFilter.TabIndex = 165;
            this.chbQualityDateFilter.Text = "Фильтровать по датам";
            this.chbQualityDateFilter.UseVisualStyleBackColor = true;
            this.chbQualityDateFilter.CheckedChanged += new System.EventHandler(this.chbQualityDateFilter_CheckedChanged);
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Checked = true;
            this.rbtAll.Location = new System.Drawing.Point(21, 201);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(44, 17);
            this.rbtAll.TabIndex = 210;
            this.rbtAll.TabStop = true;
            this.rbtAll.Text = "Все";
            this.rbtAll.UseVisualStyleBackColor = true;
            // 
            // rbtNotPermitted
            // 
            this.rbtNotPermitted.AutoSize = true;
            this.rbtNotPermitted.Location = new System.Drawing.Point(21, 180);
            this.rbtNotPermitted.Name = "rbtNotPermitted";
            this.rbtNotPermitted.Size = new System.Drawing.Size(161, 17);
            this.rbtNotPermitted.TabIndex = 200;
            this.rbtNotPermitted.Text = "Не разрешена реализация";
            this.rbtNotPermitted.UseVisualStyleBackColor = true;
            // 
            // rbtPermitted
            // 
            this.rbtPermitted.AutoSize = true;
            this.rbtPermitted.Location = new System.Drawing.Point(21, 159);
            this.rbtPermitted.Name = "rbtPermitted";
            this.rbtPermitted.Size = new System.Drawing.Size(145, 17);
            this.rbtPermitted.TabIndex = 190;
            this.rbtPermitted.Text = "Разрешена реализация";
            this.rbtPermitted.UseVisualStyleBackColor = true;
            // 
            // dtpQualityDateTo
            // 
            this.dtpQualityDateTo.CustomFormat = "dd / MM / yyyy";
            this.dtpQualityDateTo.Enabled = false;
            this.dtpQualityDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpQualityDateTo.Location = new System.Drawing.Point(308, 127);
            this.dtpQualityDateTo.Name = "dtpQualityDateTo";
            this.dtpQualityDateTo.Size = new System.Drawing.Size(110, 20);
            this.dtpQualityDateTo.TabIndex = 180;
            // 
            // dtpQualityDateFrom
            // 
            this.dtpQualityDateFrom.CustomFormat = "dd / MM / yyyy";
            this.dtpQualityDateFrom.Enabled = false;
            this.dtpQualityDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpQualityDateFrom.Location = new System.Drawing.Point(100, 127);
            this.dtpQualityDateFrom.Name = "dtpQualityDateFrom";
            this.dtpQualityDateFrom.Size = new System.Drawing.Size(111, 20);
            this.dtpQualityDateFrom.TabIndex = 170;
            // 
            // tbxQualityVendorID
            // 
            this.tbxQualityVendorID.Location = new System.Drawing.Point(109, 43);
            this.tbxQualityVendorID.Name = "tbxQualityVendorID";
            this.tbxQualityVendorID.Size = new System.Drawing.Size(111, 20);
            this.tbxQualityVendorID.TabIndex = 160;
            // 
            // lblQualityDateTo
            // 
            this.lblQualityDateTo.AutoSize = true;
            this.lblQualityDateTo.Enabled = false;
            this.lblQualityDateTo.Location = new System.Drawing.Point(233, 131);
            this.lblQualityDateTo.Name = "lblQualityDateTo";
            this.lblQualityDateTo.Size = new System.Drawing.Size(64, 13);
            this.lblQualityDateTo.TabIndex = 7;
            this.lblQualityDateTo.Text = "Дата \"по\" :";
            // 
            // lblQualityVendorID
            // 
            this.lblQualityVendorID.Location = new System.Drawing.Point(11, 33);
            this.lblQualityVendorID.Name = "lblQualityVendorID";
            this.lblQualityVendorID.Size = new System.Drawing.Size(76, 30);
            this.lblQualityVendorID.TabIndex = 4;
            this.lblQualityVendorID.Text = "Код поставщика :";
            // 
            // lblQualityDateFrom
            // 
            this.lblQualityDateFrom.AutoSize = true;
            this.lblQualityDateFrom.Enabled = false;
            this.lblQualityDateFrom.Location = new System.Drawing.Point(19, 131);
            this.lblQualityDateFrom.Name = "lblQualityDateFrom";
            this.lblQualityDateFrom.Size = new System.Drawing.Size(58, 13);
            this.lblQualityDateFrom.TabIndex = 6;
            this.lblQualityDateFrom.Text = "Дата \"с\" :";
            // 
            // tbxQualityVendorLot
            // 
            this.tbxQualityVendorLot.Location = new System.Drawing.Point(282, 7);
            this.tbxQualityVendorLot.Name = "tbxQualityVendorLot";
            this.tbxQualityVendorLot.Size = new System.Drawing.Size(111, 20);
            this.tbxQualityVendorLot.TabIndex = 150;
            // 
            // lblQualityVendorLot
            // 
            this.lblQualityVendorLot.AutoSize = true;
            this.lblQualityVendorLot.Location = new System.Drawing.Point(235, 10);
            this.lblQualityVendorLot.Name = "lblQualityVendorLot";
            this.lblQualityVendorLot.Size = new System.Drawing.Size(44, 13);
            this.lblQualityVendorLot.TabIndex = 2;
            this.lblQualityVendorLot.Text = "Серия :";
            // 
            // tbxQualityItemID
            // 
            this.tbxQualityItemID.Location = new System.Drawing.Point(109, 7);
            this.tbxQualityItemID.Name = "tbxQualityItemID";
            this.tbxQualityItemID.Size = new System.Drawing.Size(111, 20);
            this.tbxQualityItemID.TabIndex = 140;
            // 
            // lblQualityItemID
            // 
            this.lblQualityItemID.AutoSize = true;
            this.lblQualityItemID.Location = new System.Drawing.Point(11, 9);
            this.lblQualityItemID.Name = "lblQualityItemID";
            this.lblQualityItemID.Size = new System.Drawing.Size(70, 13);
            this.lblQualityItemID.TabIndex = 0;
            this.lblQualityItemID.Text = "Код товара :";
            // 
            // MedicinesRegistrySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 631);
            this.Controls.Add(this.pnlQualityInfo);
            this.Controls.Add(this.rbQualityInfo);
            this.Controls.Add(this.pnlInternalDate);
            this.Controls.Add(this.rbInternalDate);
            this.Controls.Add(this.pnlDrugs);
            this.Controls.Add(this.rbDrugsCode);
            this.Controls.Add(this.pnlSupplier);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.rbSupplierCode);
            this.Controls.Add(this.rbOrderNumber);
            this.Name = "MedicinesRegistrySearchForm";
            this.Text = "Параметры поиска реестра ЛС";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MedicinesRegistrySearchForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.rbOrderNumber, 0);
            this.Controls.SetChildIndex(this.rbSupplierCode, 0);
            this.Controls.SetChildIndex(this.pnlOrder, 0);
            this.Controls.SetChildIndex(this.pnlSupplier, 0);
            this.Controls.SetChildIndex(this.rbDrugsCode, 0);
            this.Controls.SetChildIndex(this.pnlDrugs, 0);
            this.Controls.SetChildIndex(this.rbInternalDate, 0);
            this.Controls.SetChildIndex(this.pnlInternalDate, 0);
            this.Controls.SetChildIndex(this.rbQualityInfo, 0);
            this.Controls.SetChildIndex(this.pnlQualityInfo, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlSupplier.ResumeLayout(false);
            this.pnlSupplier.PerformLayout();
            this.pnlDrugs.ResumeLayout(false);
            this.pnlDrugs.PerformLayout();
            this.pnlInternalDate.ResumeLayout(false);
            this.pnlInternalDate.PerformLayout();
            this.pnlQualityInfo.ResumeLayout(false);
            this.pnlQualityInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbOrderNumber;
        private System.Windows.Forms.RadioButton rbSupplierCode;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSupplier;
        private System.Windows.Forms.TextBox tbSupplierCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Panel pnlDrugs;
        private System.Windows.Forms.TextBox tbVendorLot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDrugsCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbDrugsCode;
        private System.Windows.Forms.Panel pnlInternalDate;
        private System.Windows.Forms.DateTimePicker dtInternalEndDate;
        private System.Windows.Forms.DateTimePicker dtInternalStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbInternalDate;
        private System.Windows.Forms.RadioButton rbQualityInfo;
        private System.Windows.Forms.Panel pnlQualityInfo;
        private System.Windows.Forms.TextBox tbxQualityVendorLot;
        private System.Windows.Forms.Label lblQualityVendorLot;
        private System.Windows.Forms.TextBox tbxQualityItemID;
        private System.Windows.Forms.Label lblQualityItemID;
        private System.Windows.Forms.RadioButton rbtPermitted;
        private System.Windows.Forms.DateTimePicker dtpQualityDateTo;
        private System.Windows.Forms.DateTimePicker dtpQualityDateFrom;
        private System.Windows.Forms.TextBox tbxQualityVendorID;
        private System.Windows.Forms.Label lblQualityDateTo;
        private System.Windows.Forms.Label lblQualityVendorID;
        private System.Windows.Forms.Label lblQualityDateFrom;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.RadioButton rbtNotPermitted;
        private System.Windows.Forms.CheckBox chbQualityDateFilter;
        private System.Windows.Forms.TextBox tbLotNumber;
        private System.Windows.Forms.TextBox tbVendorInvoice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}