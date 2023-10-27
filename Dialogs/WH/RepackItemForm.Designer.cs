namespace WMSOffice.Dialogs.WH
{
    partial class RepackItemForm
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
            this.tbYLBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblScanBox = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPackInBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowBoxInfo = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.tbShelfLife = new System.Windows.Forms.TextBox();
            this.tbCurrentQuantityInYL = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbCanUseBox = new System.Windows.Forms.CheckBox();
            this.lblRecSOQS = new System.Windows.Forms.Label();
            this.lblBunchQuantity = new System.Windows.Forms.Label();
            this.tbBunchQuantity = new System.Windows.Forms.TextBox();
            this.tCanUseBox = new System.Windows.Forms.Timer(this.components);
            this.pbCanUseBoxExclamation = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbMaxPackInBox = new System.Windows.Forms.TextBox();
            this.btnAddPackToBox = new System.Windows.Forms.Button();
            this.pbAddPackToBoxExclamation = new System.Windows.Forms.PictureBox();
            this.tAddPackToBox = new System.Windows.Forms.Timer(this.components);
            this.lblBoxContentQuantity = new System.Windows.Forms.Label();
            this.tbScanTrolleyPlace = new WMSOffice.Controls.TextBoxScaner();
            this.tbScanSSCC = new WMSOffice.Controls.TextBoxScaner();
            this.tbScanBox = new WMSOffice.Controls.TextBoxScaner();
            this.tbScanItem = new WMSOffice.Controls.TextBoxScaner();
            this.tbManualItem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanUseBoxExclamation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddPackToBoxExclamation)).BeginInit();
            this.SuspendLayout();
            // 
            // tbYLBarcode
            // 
            this.tbYLBarcode.BackColor = System.Drawing.SystemColors.Window;
            this.tbYLBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbYLBarcode.Location = new System.Drawing.Point(213, 54);
            this.tbYLBarcode.Name = "tbYLBarcode";
            this.tbYLBarcode.ReadOnly = true;
            this.tbYLBarcode.Size = new System.Drawing.Size(350, 26);
            this.tbYLBarcode.TabIndex = 0;
            this.tbYLBarcode.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(54, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Взята в работу ЖЭ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(586, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название";
            // 
            // tbItemName
            // 
            this.tbItemName.BackColor = System.Drawing.SystemColors.Window;
            this.tbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbItemName.Location = new System.Drawing.Point(675, 54);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.ReadOnly = true;
            this.tbItemName.Size = new System.Drawing.Size(350, 26);
            this.tbItemName.TabIndex = 2;
            this.tbItemName.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(147, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тип ТЕ";
            // 
            // tbBoxName
            // 
            this.tbBoxName.BackColor = System.Drawing.SystemColors.Window;
            this.tbBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBoxName.Location = new System.Drawing.Point(213, 86);
            this.tbBoxName.Name = "tbBoxName";
            this.tbBoxName.ReadOnly = true;
            this.tbBoxName.Size = new System.Drawing.Size(350, 26);
            this.tbBoxName.TabIndex = 4;
            this.tbBoxName.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(626, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "КНН";
            // 
            // tbItemID
            // 
            this.tbItemID.BackColor = System.Drawing.SystemColors.Window;
            this.tbItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbItemID.Location = new System.Drawing.Point(675, 86);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.ReadOnly = true;
            this.tbItemID.Size = new System.Drawing.Size(350, 26);
            this.tbItemID.TabIndex = 6;
            this.tbItemID.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Отсканируйте товар из ЖЭ:";
            // 
            // lblScanBox
            // 
            this.lblScanBox.AutoSize = true;
            this.lblScanBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScanBox.Location = new System.Drawing.Point(9, 312);
            this.lblScanBox.Name = "lblScanBox";
            this.lblScanBox.Size = new System.Drawing.Size(144, 20);
            this.lblScanBox.TabIndex = 10;
            this.lblScanBox.Text = "Отсканируйте ТЕ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(276, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Перепакуйте в ТЕ, введите кол-во:";
            // 
            // tbPackInBox
            // 
            this.tbPackInBox.BackColor = System.Drawing.SystemColors.Window;
            this.tbPackInBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPackInBox.Location = new System.Drawing.Point(297, 353);
            this.tbPackInBox.Name = "tbPackInBox";
            this.tbPackInBox.Size = new System.Drawing.Size(100, 26);
            this.tbPackInBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(9, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Разместите ТЕ на тележке:";
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(13, 9);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(1012, 20);
            this.lblCaption.TabIndex = 16;
            this.lblCaption.Text = "Работа с товаром";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(11, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Можно использовать ЗУ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(613, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Серия";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(640, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 20);
            this.label12.TabIndex = 19;
            this.label12.Text = "СГ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShowBoxInfo);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 507);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 45);
            this.panel1.TabIndex = 5;
            // 
            // btnShowBoxInfo
            // 
            this.btnShowBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowBoxInfo.Location = new System.Drawing.Point(13, 5);
            this.btnShowBoxInfo.Name = "btnShowBoxInfo";
            this.btnShowBoxInfo.Size = new System.Drawing.Size(85, 35);
            this.btnShowBoxInfo.TabIndex = 2;
            this.btnShowBoxInfo.Text = "Информация по ТЕ";
            this.btnShowBoxInfo.UseVisualStyleBackColor = true;
            this.btnShowBoxInfo.Click += new System.EventHandler(this.btnShowBoxInfo_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(855, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 35);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnCancel.Location = new System.Drawing.Point(946, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Проблемный товар";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendorLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbVendorLot.Location = new System.Drawing.Point(675, 118);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.ReadOnly = true;
            this.tbVendorLot.Size = new System.Drawing.Size(350, 26);
            this.tbVendorLot.TabIndex = 22;
            this.tbVendorLot.TabStop = false;
            // 
            // tbShelfLife
            // 
            this.tbShelfLife.BackColor = System.Drawing.SystemColors.Window;
            this.tbShelfLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbShelfLife.Location = new System.Drawing.Point(675, 150);
            this.tbShelfLife.Name = "tbShelfLife";
            this.tbShelfLife.ReadOnly = true;
            this.tbShelfLife.Size = new System.Drawing.Size(350, 26);
            this.tbShelfLife.TabIndex = 23;
            this.tbShelfLife.TabStop = false;
            // 
            // tbCurrentQuantityInYL
            // 
            this.tbCurrentQuantityInYL.BackColor = System.Drawing.SystemColors.Window;
            this.tbCurrentQuantityInYL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCurrentQuantityInYL.Location = new System.Drawing.Point(213, 118);
            this.tbCurrentQuantityInYL.Name = "tbCurrentQuantityInYL";
            this.tbCurrentQuantityInYL.ReadOnly = true;
            this.tbCurrentQuantityInYL.Size = new System.Drawing.Size(350, 26);
            this.tbCurrentQuantityInYL.TabIndex = 25;
            this.tbCurrentQuantityInYL.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(38, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Текущее кол-во в ЖЭ";
            // 
            // cbCanUseBox
            // 
            this.cbCanUseBox.AutoSize = true;
            this.cbCanUseBox.Enabled = false;
            this.cbCanUseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCanUseBox.Location = new System.Drawing.Point(213, 157);
            this.cbCanUseBox.Name = "cbCanUseBox";
            this.cbCanUseBox.Size = new System.Drawing.Size(15, 14);
            this.cbCanUseBox.TabIndex = 26;
            this.cbCanUseBox.UseVisualStyleBackColor = true;
            // 
            // lblRecSOQS
            // 
            this.lblRecSOQS.AutoSize = true;
            this.lblRecSOQS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecSOQS.Location = new System.Drawing.Point(405, 354);
            this.lblRecSOQS.Name = "lblRecSOQS";
            this.lblRecSOQS.Size = new System.Drawing.Size(173, 20);
            this.lblRecSOQS.TabIndex = 27;
            this.lblRecSOQS.Text = "(Рек.: не определено)";
            // 
            // lblBunchQuantity
            // 
            this.lblBunchQuantity.AutoSize = true;
            this.lblBunchQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBunchQuantity.Location = new System.Drawing.Point(45, 185);
            this.lblBunchQuantity.Name = "lblBunchQuantity";
            this.lblBunchQuantity.Size = new System.Drawing.Size(163, 20);
            this.lblBunchQuantity.TabIndex = 28;
            this.lblBunchQuantity.Text = "Кол-во в связке, шт.";
            this.lblBunchQuantity.Visible = false;
            // 
            // tbBunchQuantity
            // 
            this.tbBunchQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.tbBunchQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBunchQuantity.Location = new System.Drawing.Point(213, 182);
            this.tbBunchQuantity.Name = "tbBunchQuantity";
            this.tbBunchQuantity.ReadOnly = true;
            this.tbBunchQuantity.Size = new System.Drawing.Size(100, 26);
            this.tbBunchQuantity.TabIndex = 29;
            this.tbBunchQuantity.TabStop = false;
            this.tbBunchQuantity.Visible = false;
            // 
            // tCanUseBox
            // 
            this.tCanUseBox.Interval = 500;
            this.tCanUseBox.Tick += new System.EventHandler(this.tCanUseBox_Tick);
            // 
            // pbCanUseBoxExclamation
            // 
            this.pbCanUseBoxExclamation.Image = global::WMSOffice.Properties.Resources.exclamation_blink;
            this.pbCanUseBoxExclamation.Location = new System.Drawing.Point(234, 152);
            this.pbCanUseBoxExclamation.Name = "pbCanUseBoxExclamation";
            this.pbCanUseBoxExclamation.Size = new System.Drawing.Size(25, 25);
            this.pbCanUseBoxExclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCanUseBoxExclamation.TabIndex = 30;
            this.pbCanUseBoxExclamation.TabStop = false;
            this.pbCanUseBoxExclamation.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(9, 446);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(239, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "Отсканируйте место тележки:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(726, 354);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 20);
            this.label15.TabIndex = 34;
            this.label15.Text = "Макс. кол-во, шт.:";
            // 
            // tbMaxPackInBox
            // 
            this.tbMaxPackInBox.BackColor = System.Drawing.SystemColors.Window;
            this.tbMaxPackInBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMaxPackInBox.Location = new System.Drawing.Point(875, 351);
            this.tbMaxPackInBox.Name = "tbMaxPackInBox";
            this.tbMaxPackInBox.Size = new System.Drawing.Size(100, 26);
            this.tbMaxPackInBox.TabIndex = 33;
            // 
            // btnAddPackToBox
            // 
            this.btnAddPackToBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddPackToBox.Location = new System.Drawing.Point(675, 184);
            this.btnAddPackToBox.Name = "btnAddPackToBox";
            this.btnAddPackToBox.Size = new System.Drawing.Size(100, 23);
            this.btnAddPackToBox.TabIndex = 35;
            this.btnAddPackToBox.Text = "Доложить в ТЕ";
            this.btnAddPackToBox.UseVisualStyleBackColor = true;
            this.btnAddPackToBox.Visible = false;
            this.btnAddPackToBox.Click += new System.EventHandler(this.btnAddPackToBox_Click);
            // 
            // pbAddPackToBoxExclamation
            // 
            this.pbAddPackToBoxExclamation.Image = global::WMSOffice.Properties.Resources.exclamation_blink;
            this.pbAddPackToBoxExclamation.Location = new System.Drawing.Point(781, 183);
            this.pbAddPackToBoxExclamation.Name = "pbAddPackToBoxExclamation";
            this.pbAddPackToBoxExclamation.Size = new System.Drawing.Size(25, 25);
            this.pbAddPackToBoxExclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddPackToBoxExclamation.TabIndex = 36;
            this.pbAddPackToBoxExclamation.TabStop = false;
            this.pbAddPackToBoxExclamation.Visible = false;
            // 
            // tAddPackToBox
            // 
            this.tAddPackToBox.Interval = 500;
            this.tAddPackToBox.Tick += new System.EventHandler(this.tAddPackToBox_Tick);
            // 
            // lblBoxContentQuantity
            // 
            this.lblBoxContentQuantity.AutoSize = true;
            this.lblBoxContentQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBoxContentQuantity.ForeColor = System.Drawing.Color.Red;
            this.lblBoxContentQuantity.Location = new System.Drawing.Point(825, 185);
            this.lblBoxContentQuantity.Name = "lblBoxContentQuantity";
            this.lblBoxContentQuantity.Size = new System.Drawing.Size(188, 20);
            this.lblBoxContentQuantity.TabIndex = 37;
            this.lblBoxContentQuantity.Text = "Содержимое ТЕ: {0} шт.";
            this.lblBoxContentQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblBoxContentQuantity.Visible = false;
            // 
            // tbScanTrolleyPlace
            // 
            this.tbScanTrolleyPlace.AllowType = true;
            this.tbScanTrolleyPlace.AutoConvert = true;
            this.tbScanTrolleyPlace.DelayThreshold = 50;
            this.tbScanTrolleyPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbScanTrolleyPlace.Location = new System.Drawing.Point(293, 441);
            this.tbScanTrolleyPlace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScanTrolleyPlace.Name = "tbScanTrolleyPlace";
            this.tbScanTrolleyPlace.RaiseTextChangeWithoutEnter = false;
            this.tbScanTrolleyPlace.ReadOnly = false;
            this.tbScanTrolleyPlace.Size = new System.Drawing.Size(747, 30);
            this.tbScanTrolleyPlace.TabIndex = 4;
            this.tbScanTrolleyPlace.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanTrolleyPlace.UseParentFont = true;
            this.tbScanTrolleyPlace.UseScanModeOnly = false;
            // 
            // tbScanSSCC
            // 
            this.tbScanSSCC.AllowType = true;
            this.tbScanSSCC.AutoConvert = true;
            this.tbScanSSCC.DelayThreshold = 50;
            this.tbScanSSCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbScanSSCC.Location = new System.Drawing.Point(293, 395);
            this.tbScanSSCC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScanSSCC.Name = "tbScanSSCC";
            this.tbScanSSCC.RaiseTextChangeWithoutEnter = false;
            this.tbScanSSCC.ReadOnly = false;
            this.tbScanSSCC.Size = new System.Drawing.Size(747, 30);
            this.tbScanSSCC.TabIndex = 3;
            this.tbScanSSCC.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanSSCC.UseParentFont = true;
            this.tbScanSSCC.UseScanModeOnly = false;
            // 
            // tbScanBox
            // 
            this.tbScanBox.AllowType = true;
            this.tbScanBox.AutoConvert = true;
            this.tbScanBox.DelayThreshold = 50;
            this.tbScanBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbScanBox.Location = new System.Drawing.Point(293, 307);
            this.tbScanBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScanBox.Name = "tbScanBox";
            this.tbScanBox.RaiseTextChangeWithoutEnter = false;
            this.tbScanBox.ReadOnly = false;
            this.tbScanBox.Size = new System.Drawing.Size(747, 30);
            this.tbScanBox.TabIndex = 1;
            this.tbScanBox.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanBox.UseParentFont = true;
            this.tbScanBox.UseScanModeOnly = false;
            // 
            // tbScanItem
            // 
            this.tbScanItem.AllowType = true;
            this.tbScanItem.AutoConvert = true;
            this.tbScanItem.DelayThreshold = 50;
            this.tbScanItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbScanItem.Location = new System.Drawing.Point(293, 266);
            this.tbScanItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScanItem.Name = "tbScanItem";
            this.tbScanItem.RaiseTextChangeWithoutEnter = false;
            this.tbScanItem.ReadOnly = false;
            this.tbScanItem.Size = new System.Drawing.Size(168, 30);
            this.tbScanItem.TabIndex = 0;
            this.tbScanItem.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanItem.UseParentFont = true;
            this.tbScanItem.UseScanModeOnly = true;
            // 
            // tbManualItem
            // 
            this.tbManualItem.BackColor = System.Drawing.SystemColors.Window;
            this.tbManualItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbManualItem.Location = new System.Drawing.Point(675, 268);
            this.tbManualItem.Name = "tbManualItem";
            this.tbManualItem.Size = new System.Drawing.Size(100, 26);
            this.tbManualItem.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(501, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Введите КНН из ЖЭ:";
            // 
            // RepackItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1043, 552);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbManualItem);
            this.Controls.Add(this.lblBoxContentQuantity);
            this.Controls.Add(this.pbAddPackToBoxExclamation);
            this.Controls.Add(this.btnAddPackToBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbMaxPackInBox);
            this.Controls.Add(this.tbScanTrolleyPlace);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pbCanUseBoxExclamation);
            this.Controls.Add(this.tbBunchQuantity);
            this.Controls.Add(this.lblBunchQuantity);
            this.Controls.Add(this.lblRecSOQS);
            this.Controls.Add(this.cbCanUseBox);
            this.Controls.Add(this.tbCurrentQuantityInYL);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbShelfLife);
            this.Controls.Add(this.tbVendorLot);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.tbScanSSCC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPackInBox);
            this.Controls.Add(this.tbScanBox);
            this.Controls.Add(this.lblScanBox);
            this.Controls.Add(this.tbScanItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbItemID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbYLBarcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RepackItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "№ задания перепаковки";
            this.Load += new System.EventHandler(this.RepackItemForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RepackItemForm_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanUseBoxExclamation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddPackToBoxExclamation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbYLBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBoxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.Label label5;
        private WMSOffice.Controls.TextBoxScaner tbScanItem;
        private WMSOffice.Controls.TextBoxScaner tbScanBox;
        private System.Windows.Forms.Label lblScanBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPackInBox;
        private WMSOffice.Controls.TextBoxScaner tbScanSSCC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbVendorLot;
        private System.Windows.Forms.TextBox tbShelfLife;
        private System.Windows.Forms.TextBox tbCurrentQuantityInYL;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbCanUseBox;
        private System.Windows.Forms.Label lblRecSOQS;
        private System.Windows.Forms.Label lblBunchQuantity;
        private System.Windows.Forms.TextBox tbBunchQuantity;
        private System.Windows.Forms.Timer tCanUseBox;
        private System.Windows.Forms.PictureBox pbCanUseBoxExclamation;
        private WMSOffice.Controls.TextBoxScaner tbScanTrolleyPlace;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbMaxPackInBox;
        private System.Windows.Forms.Button btnAddPackToBox;
        private System.Windows.Forms.PictureBox pbAddPackToBoxExclamation;
        private System.Windows.Forms.Timer tAddPackToBox;
        private System.Windows.Forms.Label lblBoxContentQuantity;
        private System.Windows.Forms.Button btnShowBoxInfo;
        private System.Windows.Forms.TextBox tbManualItem;
        private System.Windows.Forms.Label label6;
    }
}