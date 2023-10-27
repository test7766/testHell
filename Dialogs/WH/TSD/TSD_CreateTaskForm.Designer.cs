namespace WMSOffice.Dialogs.WH.TSD
{
    partial class TSD_CreateTaskForm
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
            this.stbDocType = new WMSOffice.Controls.SearchTextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblWarehouseFromID = new System.Windows.Forms.Label();
            this.lblLocnFrom = new System.Windows.Forms.Label();
            this.lblLocnTo = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.tbWarehouseFromID = new System.Windows.Forms.TextBox();
            this.tbLocnFrom = new System.Windows.Forms.TextBox();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.tbLocnTo = new System.Windows.Forms.TextBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.stbWarehouseFromID = new WMSOffice.Controls.SearchTextBox();
            this.stbLocnFrom = new WMSOffice.Controls.SearchTextBox();
            this.stbLocnTo = new WMSOffice.Controls.SearchTextBox();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.tbQFilterLocnFrom = new System.Windows.Forms.TextBox();
            this.lblQFilterLocnTo = new System.Windows.Forms.Label();
            this.tbQFilterLocnTo = new System.Windows.Forms.TextBox();
            this.lblQFilterLocnFrom = new System.Windows.Forms.Label();
            this.lblUom = new System.Windows.Forms.Label();
            this.tbUom = new System.Windows.Forms.TextBox();
            this.lblAvailableQuantity = new System.Windows.Forms.Label();
            this.tbAvailableQuantity = new System.Windows.Forms.TextBox();
            this.cbUseAllAvaliableRemains = new System.Windows.Forms.CheckBox();
            this.lblPickMode = new System.Windows.Forms.Label();
            this.cbFraqPickMode = new System.Windows.Forms.CheckBox();
            this.cbBoxPickMode = new System.Windows.Forms.CheckBox();
            this.stbWarehouseToID = new WMSOffice.Controls.SearchTextBox();
            this.tbWarehouseToID = new System.Windows.Forms.TextBox();
            this.lblWarehouseToID = new System.Windows.Forms.Label();
            this.stbVendorLot = new WMSOffice.Controls.SearchTextBox();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.cbWithoutLift = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(532, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(622, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 243);
            this.pnlButtons.Size = new System.Drawing.Size(709, 43);
            this.pnlButtons.TabIndex = 36;
            // 
            // stbDocType
            // 
            this.stbDocType.Location = new System.Drawing.Point(107, 8);
            this.stbDocType.Name = "stbDocType";
            this.stbDocType.ReadOnly = false;
            this.stbDocType.Size = new System.Drawing.Size(100, 20);
            this.stbDocType.TabIndex = 1;
            this.stbDocType.UserID = ((long)(0));
            this.stbDocType.Value = null;
            this.stbDocType.ValueReferenceQuery = null;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(12, 12);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(89, 13);
            this.lblDocType.TabIndex = 0;
            this.lblDocType.Text = "Тип документа :";
            // 
            // lblWarehouseFromID
            // 
            this.lblWarehouseFromID.AutoSize = true;
            this.lblWarehouseFromID.Location = new System.Drawing.Point(12, 41);
            this.lblWarehouseFromID.Name = "lblWarehouseFromID";
            this.lblWarehouseFromID.Size = new System.Drawing.Size(71, 13);
            this.lblWarehouseFromID.TabIndex = 6;
            this.lblWarehouseFromID.Text = "Склад \"Из\" :";
            // 
            // lblLocnFrom
            // 
            this.lblLocnFrom.AutoSize = true;
            this.lblLocnFrom.Location = new System.Drawing.Point(12, 99);
            this.lblLocnFrom.Name = "lblLocnFrom";
            this.lblLocnFrom.Size = new System.Drawing.Size(72, 13);
            this.lblLocnFrom.TabIndex = 12;
            this.lblLocnFrom.Text = "Место \"Из\" :";
            // 
            // lblLocnTo
            // 
            this.lblLocnTo.AutoSize = true;
            this.lblLocnTo.Location = new System.Drawing.Point(12, 217);
            this.lblLocnTo.Name = "lblLocnTo";
            this.lblLocnTo.Size = new System.Drawing.Size(65, 13);
            this.lblLocnTo.TabIndex = 30;
            this.lblLocnTo.Text = "Место \"В\" :";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(12, 128);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(70, 13);
            this.lblItemID.TabIndex = 17;
            this.lblItemID.Text = "Код товара :";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 187);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(72, 13);
            this.lblQuantity.TabIndex = 23;
            this.lblQuantity.Text = "Количество :";
            // 
            // tbDocType
            // 
            this.tbDocType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocType.BackColor = System.Drawing.SystemColors.Control;
            this.tbDocType.Location = new System.Drawing.Point(213, 8);
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.ReadOnly = true;
            this.tbDocType.Size = new System.Drawing.Size(268, 20);
            this.tbDocType.TabIndex = 2;
            this.tbDocType.TabStop = false;
            // 
            // tbWarehouseFromID
            // 
            this.tbWarehouseFromID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarehouseFromID.BackColor = System.Drawing.SystemColors.Control;
            this.tbWarehouseFromID.Location = new System.Drawing.Point(213, 37);
            this.tbWarehouseFromID.Name = "tbWarehouseFromID";
            this.tbWarehouseFromID.ReadOnly = true;
            this.tbWarehouseFromID.Size = new System.Drawing.Size(484, 20);
            this.tbWarehouseFromID.TabIndex = 8;
            this.tbWarehouseFromID.TabStop = false;
            // 
            // tbLocnFrom
            // 
            this.tbLocnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLocnFrom.BackColor = System.Drawing.SystemColors.Control;
            this.tbLocnFrom.Location = new System.Drawing.Point(487, 95);
            this.tbLocnFrom.Name = "tbLocnFrom";
            this.tbLocnFrom.ReadOnly = true;
            this.tbLocnFrom.Size = new System.Drawing.Size(210, 20);
            this.tbLocnFrom.TabIndex = 16;
            this.tbLocnFrom.TabStop = false;
            // 
            // tbItemID
            // 
            this.tbItemID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbItemID.BackColor = System.Drawing.SystemColors.Control;
            this.tbItemID.Location = new System.Drawing.Point(213, 124);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.ReadOnly = true;
            this.tbItemID.Size = new System.Drawing.Size(484, 20);
            this.tbItemID.TabIndex = 19;
            this.tbItemID.TabStop = false;
            // 
            // tbLocnTo
            // 
            this.tbLocnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLocnTo.BackColor = System.Drawing.SystemColors.Control;
            this.tbLocnTo.Location = new System.Drawing.Point(487, 213);
            this.tbLocnTo.Name = "tbLocnTo";
            this.tbLocnTo.ReadOnly = true;
            this.tbLocnTo.Size = new System.Drawing.Size(210, 20);
            this.tbLocnTo.TabIndex = 35;
            this.tbLocnTo.TabStop = false;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(107, 183);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(100, 20);
            this.nudQuantity.TabIndex = 24;
            // 
            // stbWarehouseFromID
            // 
            this.stbWarehouseFromID.Location = new System.Drawing.Point(107, 37);
            this.stbWarehouseFromID.Name = "stbWarehouseFromID";
            this.stbWarehouseFromID.ReadOnly = false;
            this.stbWarehouseFromID.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouseFromID.TabIndex = 7;
            this.stbWarehouseFromID.UserID = ((long)(0));
            this.stbWarehouseFromID.Value = null;
            this.stbWarehouseFromID.ValueReferenceQuery = null;
            // 
            // stbLocnFrom
            // 
            this.stbLocnFrom.Location = new System.Drawing.Point(107, 95);
            this.stbLocnFrom.Name = "stbLocnFrom";
            this.stbLocnFrom.ReadOnly = false;
            this.stbLocnFrom.Size = new System.Drawing.Size(100, 20);
            this.stbLocnFrom.TabIndex = 13;
            this.stbLocnFrom.UserID = ((long)(0));
            this.stbLocnFrom.Value = null;
            this.stbLocnFrom.ValueReferenceQuery = null;
            // 
            // stbLocnTo
            // 
            this.stbLocnTo.Location = new System.Drawing.Point(107, 213);
            this.stbLocnTo.Name = "stbLocnTo";
            this.stbLocnTo.ReadOnly = false;
            this.stbLocnTo.Size = new System.Drawing.Size(100, 20);
            this.stbLocnTo.TabIndex = 31;
            this.stbLocnTo.UserID = ((long)(0));
            this.stbLocnTo.Value = null;
            this.stbLocnTo.ValueReferenceQuery = null;
            // 
            // stbItemID
            // 
            this.stbItemID.Location = new System.Drawing.Point(107, 124);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.ReadOnly = false;
            this.stbItemID.Size = new System.Drawing.Size(100, 20);
            this.stbItemID.TabIndex = 18;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // tbQFilterLocnFrom
            // 
            this.tbQFilterLocnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQFilterLocnFrom.Location = new System.Drawing.Point(431, 95);
            this.tbQFilterLocnFrom.Name = "tbQFilterLocnFrom";
            this.tbQFilterLocnFrom.Size = new System.Drawing.Size(50, 20);
            this.tbQFilterLocnFrom.TabIndex = 15;
            this.tbQFilterLocnFrom.TabStop = false;
            this.tbQFilterLocnFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQFilterLocnFrom_KeyDown);
            this.tbQFilterLocnFrom.Leave += new System.EventHandler(this.tbQFilterLocnFrom_Leave);
            // 
            // lblQFilterLocnTo
            // 
            this.lblQFilterLocnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQFilterLocnTo.AutoSize = true;
            this.lblQFilterLocnTo.Location = new System.Drawing.Point(326, 217);
            this.lblQFilterLocnTo.Name = "lblQFilterLocnTo";
            this.lblQFilterLocnTo.Size = new System.Drawing.Size(99, 13);
            this.lblQFilterLocnTo.TabIndex = 33;
            this.lblQFilterLocnTo.Text = "Быстрый фильтр :";
            // 
            // tbQFilterLocnTo
            // 
            this.tbQFilterLocnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQFilterLocnTo.Location = new System.Drawing.Point(431, 213);
            this.tbQFilterLocnTo.Name = "tbQFilterLocnTo";
            this.tbQFilterLocnTo.Size = new System.Drawing.Size(50, 20);
            this.tbQFilterLocnTo.TabIndex = 34;
            this.tbQFilterLocnTo.TabStop = false;
            this.tbQFilterLocnTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQFilterLocnTo_KeyDown);
            this.tbQFilterLocnTo.Leave += new System.EventHandler(this.tbQFilterLocnTo_Leave);
            // 
            // lblQFilterLocnFrom
            // 
            this.lblQFilterLocnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQFilterLocnFrom.AutoSize = true;
            this.lblQFilterLocnFrom.Location = new System.Drawing.Point(326, 99);
            this.lblQFilterLocnFrom.Name = "lblQFilterLocnFrom";
            this.lblQFilterLocnFrom.Size = new System.Drawing.Size(99, 13);
            this.lblQFilterLocnFrom.TabIndex = 14;
            this.lblQFilterLocnFrom.Text = "Быстрый фильтр :";
            // 
            // lblUom
            // 
            this.lblUom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUom.AutoSize = true;
            this.lblUom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUom.Location = new System.Drawing.Point(397, 187);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(28, 13);
            this.lblUom.TabIndex = 26;
            this.lblUom.Text = "ЕИ :";
            // 
            // tbUom
            // 
            this.tbUom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUom.BackColor = System.Drawing.SystemColors.Control;
            this.tbUom.Location = new System.Drawing.Point(431, 183);
            this.tbUom.Name = "tbUom";
            this.tbUom.ReadOnly = true;
            this.tbUom.Size = new System.Drawing.Size(50, 20);
            this.tbUom.TabIndex = 27;
            this.tbUom.TabStop = false;
            // 
            // lblAvailableQuantity
            // 
            this.lblAvailableQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableQuantity.AutoSize = true;
            this.lblAvailableQuantity.Location = new System.Drawing.Point(586, 187);
            this.lblAvailableQuantity.Name = "lblAvailableQuantity";
            this.lblAvailableQuantity.Size = new System.Drawing.Size(55, 13);
            this.lblAvailableQuantity.TabIndex = 28;
            this.lblAvailableQuantity.Text = "Остаток :";
            // 
            // tbAvailableQuantity
            // 
            this.tbAvailableQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAvailableQuantity.BackColor = System.Drawing.SystemColors.Control;
            this.tbAvailableQuantity.Location = new System.Drawing.Point(647, 183);
            this.tbAvailableQuantity.Name = "tbAvailableQuantity";
            this.tbAvailableQuantity.ReadOnly = true;
            this.tbAvailableQuantity.Size = new System.Drawing.Size(50, 20);
            this.tbAvailableQuantity.TabIndex = 29;
            this.tbAvailableQuantity.TabStop = false;
            // 
            // cbUseAllAvaliableRemains
            // 
            this.cbUseAllAvaliableRemains.AutoSize = true;
            this.cbUseAllAvaliableRemains.Location = new System.Drawing.Point(213, 185);
            this.cbUseAllAvaliableRemains.Name = "cbUseAllAvaliableRemains";
            this.cbUseAllAvaliableRemains.Size = new System.Drawing.Size(151, 17);
            this.cbUseAllAvaliableRemains.TabIndex = 25;
            this.cbUseAllAvaliableRemains.Text = "Весь доступный остаток";
            this.cbUseAllAvaliableRemains.UseVisualStyleBackColor = true;
            this.cbUseAllAvaliableRemains.CheckedChanged += new System.EventHandler(this.cbUseAllAvaliableRemains_CheckedChanged);
            // 
            // lblPickMode
            // 
            this.lblPickMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPickMode.AutoSize = true;
            this.lblPickMode.Location = new System.Drawing.Point(484, 12);
            this.lblPickMode.Name = "lblPickMode";
            this.lblPickMode.Size = new System.Drawing.Size(86, 13);
            this.lblPickMode.TabIndex = 3;
            this.lblPickMode.Text = "Режим отбора :";
            // 
            // cbFraqPickMode
            // 
            this.cbFraqPickMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFraqPickMode.AutoSize = true;
            this.cbFraqPickMode.Location = new System.Drawing.Point(638, 10);
            this.cbFraqPickMode.Name = "cbFraqPickMode";
            this.cbFraqPickMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFraqPickMode.Size = new System.Drawing.Size(59, 17);
            this.cbFraqPickMode.TabIndex = 5;
            this.cbFraqPickMode.Text = "Дробь";
            this.cbFraqPickMode.UseVisualStyleBackColor = true;
            this.cbFraqPickMode.CheckedChanged += new System.EventHandler(this.cbFraqPickMode_CheckedChanged);
            // 
            // cbBoxPickMode
            // 
            this.cbBoxPickMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBoxPickMode.AutoSize = true;
            this.cbBoxPickMode.Location = new System.Drawing.Point(577, 10);
            this.cbBoxPickMode.Name = "cbBoxPickMode";
            this.cbBoxPickMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbBoxPickMode.Size = new System.Drawing.Size(55, 17);
            this.cbBoxPickMode.TabIndex = 4;
            this.cbBoxPickMode.Text = "Ящик";
            this.cbBoxPickMode.UseVisualStyleBackColor = true;
            this.cbBoxPickMode.CheckedChanged += new System.EventHandler(this.cbBoxPickMode_CheckedChanged);
            // 
            // stbWarehouseToID
            // 
            this.stbWarehouseToID.Location = new System.Drawing.Point(107, 66);
            this.stbWarehouseToID.Name = "stbWarehouseToID";
            this.stbWarehouseToID.ReadOnly = false;
            this.stbWarehouseToID.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouseToID.TabIndex = 10;
            this.stbWarehouseToID.UserID = ((long)(0));
            this.stbWarehouseToID.Value = null;
            this.stbWarehouseToID.ValueReferenceQuery = null;
            // 
            // tbWarehouseToID
            // 
            this.tbWarehouseToID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarehouseToID.BackColor = System.Drawing.SystemColors.Control;
            this.tbWarehouseToID.Location = new System.Drawing.Point(213, 66);
            this.tbWarehouseToID.Name = "tbWarehouseToID";
            this.tbWarehouseToID.ReadOnly = true;
            this.tbWarehouseToID.Size = new System.Drawing.Size(484, 20);
            this.tbWarehouseToID.TabIndex = 11;
            this.tbWarehouseToID.TabStop = false;
            // 
            // lblWarehouseToID
            // 
            this.lblWarehouseToID.AutoSize = true;
            this.lblWarehouseToID.Location = new System.Drawing.Point(12, 70);
            this.lblWarehouseToID.Name = "lblWarehouseToID";
            this.lblWarehouseToID.Size = new System.Drawing.Size(64, 13);
            this.lblWarehouseToID.TabIndex = 9;
            this.lblWarehouseToID.Text = "Склад \"В\" :";
            // 
            // stbVendorLot
            // 
            this.stbVendorLot.Location = new System.Drawing.Point(107, 153);
            this.stbVendorLot.Name = "stbVendorLot";
            this.stbVendorLot.ReadOnly = false;
            this.stbVendorLot.Size = new System.Drawing.Size(100, 20);
            this.stbVendorLot.TabIndex = 21;
            this.stbVendorLot.UserID = ((long)(0));
            this.stbVendorLot.Value = null;
            this.stbVendorLot.ValueReferenceQuery = null;
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVendorLot.BackColor = System.Drawing.SystemColors.Control;
            this.tbVendorLot.Location = new System.Drawing.Point(213, 153);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.ReadOnly = true;
            this.tbVendorLot.Size = new System.Drawing.Size(484, 20);
            this.tbVendorLot.TabIndex = 22;
            this.tbVendorLot.TabStop = false;
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(12, 157);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(44, 13);
            this.lblVendorLot.TabIndex = 20;
            this.lblVendorLot.Text = "Серия :";
            // 
            // cbWithoutLift
            // 
            this.cbWithoutLift.AutoSize = true;
            this.cbWithoutLift.Location = new System.Drawing.Point(213, 215);
            this.cbWithoutLift.Name = "cbWithoutLift";
            this.cbWithoutLift.Size = new System.Drawing.Size(79, 17);
            this.cbWithoutLift.TabIndex = 32;
            this.cbWithoutLift.Text = "Без лифта";
            this.cbWithoutLift.UseVisualStyleBackColor = true;
            this.cbWithoutLift.CheckedChanged += new System.EventHandler(this.cbWithoutLift_CheckedChanged);
            // 
            // TSD_CreateTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 286);
            this.Controls.Add(this.cbWithoutLift);
            this.Controls.Add(this.stbVendorLot);
            this.Controls.Add(this.tbVendorLot);
            this.Controls.Add(this.lblVendorLot);
            this.Controls.Add(this.stbWarehouseToID);
            this.Controls.Add(this.tbWarehouseToID);
            this.Controls.Add(this.lblWarehouseToID);
            this.Controls.Add(this.cbBoxPickMode);
            this.Controls.Add(this.cbFraqPickMode);
            this.Controls.Add(this.lblPickMode);
            this.Controls.Add(this.tbAvailableQuantity);
            this.Controls.Add(this.lblAvailableQuantity);
            this.Controls.Add(this.cbUseAllAvaliableRemains);
            this.Controls.Add(this.tbUom);
            this.Controls.Add(this.lblUom);
            this.Controls.Add(this.lblQFilterLocnFrom);
            this.Controls.Add(this.tbQFilterLocnTo);
            this.Controls.Add(this.lblQFilterLocnTo);
            this.Controls.Add(this.tbQFilterLocnFrom);
            this.Controls.Add(this.stbItemID);
            this.Controls.Add(this.stbLocnTo);
            this.Controls.Add(this.stbLocnFrom);
            this.Controls.Add(this.stbWarehouseFromID);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.tbLocnTo);
            this.Controls.Add(this.tbItemID);
            this.Controls.Add(this.tbLocnFrom);
            this.Controls.Add(this.tbWarehouseFromID);
            this.Controls.Add(this.tbDocType);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblItemID);
            this.Controls.Add(this.lblLocnTo);
            this.Controls.Add(this.lblLocnFrom);
            this.Controls.Add(this.lblWarehouseFromID);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.stbDocType);
            this.Name = "TSD_CreateTaskForm";
            this.Text = "Параметры задания ТСД";
            this.Load += new System.EventHandler(this.TSD_CreateTaskForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TSD_CreateTaskForm_FormClosing);
            this.Controls.SetChildIndex(this.stbDocType, 0);
            this.Controls.SetChildIndex(this.lblDocType, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblWarehouseFromID, 0);
            this.Controls.SetChildIndex(this.lblLocnFrom, 0);
            this.Controls.SetChildIndex(this.lblLocnTo, 0);
            this.Controls.SetChildIndex(this.lblItemID, 0);
            this.Controls.SetChildIndex(this.lblQuantity, 0);
            this.Controls.SetChildIndex(this.tbDocType, 0);
            this.Controls.SetChildIndex(this.tbWarehouseFromID, 0);
            this.Controls.SetChildIndex(this.tbLocnFrom, 0);
            this.Controls.SetChildIndex(this.tbItemID, 0);
            this.Controls.SetChildIndex(this.tbLocnTo, 0);
            this.Controls.SetChildIndex(this.nudQuantity, 0);
            this.Controls.SetChildIndex(this.stbWarehouseFromID, 0);
            this.Controls.SetChildIndex(this.stbLocnFrom, 0);
            this.Controls.SetChildIndex(this.stbLocnTo, 0);
            this.Controls.SetChildIndex(this.stbItemID, 0);
            this.Controls.SetChildIndex(this.tbQFilterLocnFrom, 0);
            this.Controls.SetChildIndex(this.lblQFilterLocnTo, 0);
            this.Controls.SetChildIndex(this.tbQFilterLocnTo, 0);
            this.Controls.SetChildIndex(this.lblQFilterLocnFrom, 0);
            this.Controls.SetChildIndex(this.lblUom, 0);
            this.Controls.SetChildIndex(this.tbUom, 0);
            this.Controls.SetChildIndex(this.cbUseAllAvaliableRemains, 0);
            this.Controls.SetChildIndex(this.lblAvailableQuantity, 0);
            this.Controls.SetChildIndex(this.tbAvailableQuantity, 0);
            this.Controls.SetChildIndex(this.lblPickMode, 0);
            this.Controls.SetChildIndex(this.cbFraqPickMode, 0);
            this.Controls.SetChildIndex(this.cbBoxPickMode, 0);
            this.Controls.SetChildIndex(this.lblWarehouseToID, 0);
            this.Controls.SetChildIndex(this.tbWarehouseToID, 0);
            this.Controls.SetChildIndex(this.stbWarehouseToID, 0);
            this.Controls.SetChildIndex(this.lblVendorLot, 0);
            this.Controls.SetChildIndex(this.tbVendorLot, 0);
            this.Controls.SetChildIndex(this.stbVendorLot, 0);
            this.Controls.SetChildIndex(this.cbWithoutLift, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.SearchTextBox stbDocType;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblWarehouseFromID;
        private System.Windows.Forms.Label lblLocnFrom;
        private System.Windows.Forms.Label lblLocnTo;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbDocType;
        private System.Windows.Forms.TextBox tbWarehouseFromID;
        private System.Windows.Forms.TextBox tbLocnFrom;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.TextBox tbLocnTo;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private WMSOffice.Controls.SearchTextBox stbWarehouseFromID;
        private WMSOffice.Controls.SearchTextBox stbLocnFrom;
        private WMSOffice.Controls.SearchTextBox stbLocnTo;
        private WMSOffice.Controls.SearchTextBox stbItemID;
        private System.Windows.Forms.TextBox tbQFilterLocnFrom;
        private System.Windows.Forms.Label lblQFilterLocnTo;
        private System.Windows.Forms.TextBox tbQFilterLocnTo;
        private System.Windows.Forms.Label lblQFilterLocnFrom;
        private System.Windows.Forms.Label lblUom;
        private System.Windows.Forms.TextBox tbUom;
        private System.Windows.Forms.Label lblAvailableQuantity;
        private System.Windows.Forms.TextBox tbAvailableQuantity;
        private System.Windows.Forms.CheckBox cbUseAllAvaliableRemains;
        private System.Windows.Forms.Label lblPickMode;
        private System.Windows.Forms.CheckBox cbFraqPickMode;
        private System.Windows.Forms.CheckBox cbBoxPickMode;
        private WMSOffice.Controls.SearchTextBox stbWarehouseToID;
        private System.Windows.Forms.TextBox tbWarehouseToID;
        private System.Windows.Forms.Label lblWarehouseToID;
        private WMSOffice.Controls.SearchTextBox stbVendorLot;
        private System.Windows.Forms.TextBox tbVendorLot;
        private System.Windows.Forms.Label lblVendorLot;
        private System.Windows.Forms.CheckBox cbWithoutLift;
    }
}