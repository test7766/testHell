namespace WMSOffice.Window
{
    partial class ApplyingOfReturnsWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbApply = new System.Windows.Forms.ToolStripButton();
            this.sbUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbAddItemWithoutBarCode = new System.Windows.Forms.ToolStripButton();
            this.sbCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbUndoDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sbShowRemains = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSelectLocation = new System.Windows.Forms.ToolStripLabel();
            this.pnlWork = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblItemEI = new System.Windows.Forms.Label();
            this.lblItemsInBox = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.lblCountTotal = new System.Windows.Forms.Label();
            this.lblCountItems = new System.Windows.Forms.Label();
            this.lblCountBox = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblItemSeria = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWL = new System.Windows.Forms.RadioButton();
            this.rbIT = new System.Windows.Forms.RadioButton();
            this.rbBX = new System.Windows.Forms.RadioButton();
            this.textBoxScaner = new WMSOffice.Controls.TextBoxScaner();
            this.fillingRate = new WMSOffice.Controls.FillingRate();
            this.gvDocLines = new System.Windows.Forms.DataGridView();
            this.colSnowflake = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTinBXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snowFlakeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bXQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnsDocLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.returnsDocLinesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.ReturnsDocLinesTableAdapter();
            this.tsMainMenu.SuspendLayout();
            this.pnlWork.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnsDocLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbApply,
            this.sbUndo,
            this.toolStripSeparator2,
            this.sbAddItemWithoutBarCode,
            this.sbCloseDoc,
            this.toolStripSeparator1,
            this.sbUndoDoc,
            this.toolStripSeparator4,
            this.sbShowRemains,
            this.toolStripSeparator3,
            this.lblSelectLocation});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1109, 55);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbApply
            // 
            this.sbApply.Image = global::WMSOffice.Properties.Resources.save;
            this.sbApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbApply.Name = "sbApply";
            this.sbApply.Size = new System.Drawing.Size(52, 52);
            this.sbApply.ToolTipText = "Применить изменения";
            this.sbApply.Click += new System.EventHandler(this.sbApply_Click);
            // 
            // sbUndo
            // 
            this.sbUndo.Image = global::WMSOffice.Properties.Resources.undo43;
            this.sbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbUndo.Name = "sbUndo";
            this.sbUndo.Size = new System.Drawing.Size(52, 52);
            this.sbUndo.ToolTipText = "Отменить последнее действие";
            this.sbUndo.Click += new System.EventHandler(this.sbUndo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // sbAddItemWithoutBarCode
            // 
            this.sbAddItemWithoutBarCode.Image = global::WMSOffice.Properties.Resources.drug_basket;
            this.sbAddItemWithoutBarCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddItemWithoutBarCode.Name = "sbAddItemWithoutBarCode";
            this.sbAddItemWithoutBarCode.Size = new System.Drawing.Size(166, 52);
            this.sbAddItemWithoutBarCode.Text = "Добавить товар\nбез штрих кода (F5)";
            this.sbAddItemWithoutBarCode.Click += new System.EventHandler(this.sbAddItemWithoutBarCode_Click);
            // 
            // sbCloseDoc
            // 
            this.sbCloseDoc.Image = global::WMSOffice.Properties.Resources.checkered_flag;
            this.sbCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCloseDoc.Name = "sbCloseDoc";
            this.sbCloseDoc.Size = new System.Drawing.Size(211, 52);
            this.sbCloseDoc.Text = "Закрыть документ\nо перемещении товара (F6)";
            this.sbCloseDoc.Click += new System.EventHandler(this.sbCloseDoc_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbUndoDoc
            // 
            this.sbUndoDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.sbUndoDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbUndoDoc.Name = "sbUndoDoc";
            this.sbUndoDoc.Size = new System.Drawing.Size(211, 52);
            this.sbUndoDoc.Text = "Отменить документ\nо перемещении товара (F8)";
            this.sbUndoDoc.Click += new System.EventHandler(this.sbUndoDoc_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // sbShowRemains
            // 
            this.sbShowRemains.Image = global::WMSOffice.Properties.Resources.inventory;
            this.sbShowRemains.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbShowRemains.Name = "sbShowRemains";
            this.sbShowRemains.Size = new System.Drawing.Size(131, 52);
            this.sbShowRemains.Text = "Остатки\nна полке (F7)";
            this.sbShowRemains.Click += new System.EventHandler(this.sbShowRemains_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // lblSelectLocation
            // 
            this.lblSelectLocation.BackColor = System.Drawing.SystemColors.Control;
            this.lblSelectLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectLocation.Name = "lblSelectLocation";
            this.lblSelectLocation.Size = new System.Drawing.Size(118, 52);
            this.lblSelectLocation.Text = "Выбранная полка : ";
            // 
            // pnlWork
            // 
            this.pnlWork.Controls.Add(this.lblInfo);
            this.pnlWork.Controls.Add(this.splitContainer1);
            this.pnlWork.Controls.Add(this.lblManufacturer);
            this.pnlWork.Controls.Add(this.label4);
            this.pnlWork.Controls.Add(this.lblItemSeria);
            this.pnlWork.Controls.Add(this.label2);
            this.pnlWork.Controls.Add(this.lblItemName);
            this.pnlWork.Controls.Add(this.label3);
            this.pnlWork.Controls.Add(this.lblItemCode);
            this.pnlWork.Controls.Add(this.label1);
            this.pnlWork.Controls.Add(this.groupBox1);
            this.pnlWork.Controls.Add(this.textBoxScaner);
            this.pnlWork.Controls.Add(this.fillingRate);
            this.pnlWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWork.Location = new System.Drawing.Point(0, 95);
            this.pnlWork.Name = "pnlWork";
            this.pnlWork.Size = new System.Drawing.Size(1109, 204);
            this.pnlWork.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.SystemColors.Info;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point(100, 3);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(911, 36);
            this.lblInfo.TabIndex = 15;
            this.lblInfo.Text = "Отсканируйте следующую единицу товара.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(103, 124);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblItemEI);
            this.splitContainer1.Panel1.Controls.Add(this.lblItemsInBox);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.tbCount);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblCountTotal);
            this.splitContainer1.Panel2.Controls.Add(this.lblCountItems);
            this.splitContainer1.Panel2.Controls.Add(this.lblCountBox);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Size = new System.Drawing.Size(908, 74);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 14;
            // 
            // lblItemEI
            // 
            this.lblItemEI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemEI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemEI.Location = new System.Drawing.Point(86, 31);
            this.lblItemEI.Name = "lblItemEI";
            this.lblItemEI.Size = new System.Drawing.Size(348, 13);
            this.lblItemEI.TabIndex = 17;
            this.lblItemEI.Text = "EI";
            // 
            // lblItemsInBox
            // 
            this.lblItemsInBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemsInBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemsInBox.Location = new System.Drawing.Point(86, 50);
            this.lblItemsInBox.Name = "lblItemsInBox";
            this.lblItemsInBox.Size = new System.Drawing.Size(348, 13);
            this.lblItemsInBox.TabIndex = 16;
            this.lblItemsInBox.Text = "500";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Шт. в ед.:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Ед. изм.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Количество:";
            // 
            // tbCount
            // 
            this.tbCount.Enabled = false;
            this.tbCount.Location = new System.Drawing.Point(86, 9);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(113, 20);
            this.tbCount.TabIndex = 9;
            this.tbCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCount_KeyDown);
            this.tbCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCount_KeyPress);
            // 
            // lblCountTotal
            // 
            this.lblCountTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountTotal.Location = new System.Drawing.Point(69, 50);
            this.lblCountTotal.Name = "lblCountTotal";
            this.lblCountTotal.Size = new System.Drawing.Size(377, 13);
            this.lblCountTotal.TabIndex = 13;
            this.lblCountTotal.Text = "1510";
            // 
            // lblCountItems
            // 
            this.lblCountItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountItems.Location = new System.Drawing.Point(69, 31);
            this.lblCountItems.Name = "lblCountItems";
            this.lblCountItems.Size = new System.Drawing.Size(377, 13);
            this.lblCountItems.TabIndex = 12;
            this.lblCountItems.Text = "10";
            // 
            // lblCountBox
            // 
            this.lblCountBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountBox.Location = new System.Drawing.Point(69, 12);
            this.lblCountBox.Name = "lblCountBox";
            this.lblCountBox.Size = new System.Drawing.Size(377, 13);
            this.lblCountBox.TabIndex = 11;
            this.lblCountBox.Text = "3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Всего:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Упаковок:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ящиков:";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManufacturer.Location = new System.Drawing.Point(192, 108);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(819, 13);
            this.lblManufacturer.TabIndex = 12;
            this.lblManufacturer.Text = "Производитель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Производитель:";
            // 
            // lblItemSeria
            // 
            this.lblItemSeria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemSeria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemSeria.Location = new System.Drawing.Point(192, 89);
            this.lblItemSeria.Name = "lblItemSeria";
            this.lblItemSeria.Size = new System.Drawing.Size(819, 13);
            this.lblItemSeria.TabIndex = 10;
            this.lblItemSeria.TabStop = true;
            this.lblItemSeria.Text = "20100319-2";
            this.lblItemSeria.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblItemSeria_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Серия/Партия:";
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(192, 70);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(819, 13);
            this.lblItemName.TabIndex = 7;
            this.lblItemName.Text = "Наименование товара";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Наименование:";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemCode.Location = new System.Drawing.Point(38, 101);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(56, 13);
            this.lblItemCode.TabIndex = 5;
            this.lblItemCode.Text = "1234567";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Код:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbWL);
            this.groupBox1.Controls.Add(this.rbIT);
            this.groupBox1.Controls.Add(this.rbBX);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 90);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим:";
            // 
            // rbWL
            // 
            this.rbWL.AutoSize = true;
            this.rbWL.Location = new System.Drawing.Point(9, 69);
            this.rbWL.Name = "rbWL";
            this.rbWL.Size = new System.Drawing.Size(39, 17);
            this.rbWL.TabIndex = 2;
            this.rbWL.Text = "БЭ";
            this.rbWL.UseVisualStyleBackColor = true;
            this.rbWL.CheckedChanged += new System.EventHandler(this.rbWL_CheckedChanged);
            // 
            // rbIT
            // 
            this.rbIT.AutoSize = true;
            this.rbIT.Location = new System.Drawing.Point(9, 44);
            this.rbIT.Name = "rbIT";
            this.rbIT.Size = new System.Drawing.Size(75, 17);
            this.rbIT.TabIndex = 1;
            this.rbIT.Text = "Упаковки";
            this.rbIT.UseVisualStyleBackColor = true;
            // 
            // rbBX
            // 
            this.rbBX.AutoSize = true;
            this.rbBX.Checked = true;
            this.rbBX.Location = new System.Drawing.Point(9, 19);
            this.rbBX.Name = "rbBX";
            this.rbBX.Size = new System.Drawing.Size(60, 17);
            this.rbBX.TabIndex = 0;
            this.rbBX.TabStop = true;
            this.rbBX.Text = "Ящики";
            this.rbBX.UseVisualStyleBackColor = true;
            this.rbBX.CheckedChanged += new System.EventHandler(this.rbBX_CheckedChanged);
            // 
            // textBoxScaner
            // 
            this.textBoxScaner.AllowType = true;
            this.textBoxScaner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScaner.AutoConvert = true;
            this.textBoxScaner.DelayThreshold = 50;
            this.textBoxScaner.Location = new System.Drawing.Point(100, 38);
            this.textBoxScaner.Name = "textBoxScaner";
            this.textBoxScaner.RaiseTextChangeWithoutEnter = false;
            this.textBoxScaner.ReadOnly = false;
            this.textBoxScaner.Size = new System.Drawing.Size(911, 25);
            this.textBoxScaner.TabIndex = 0;
            this.textBoxScaner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.textBoxScaner.UseParentFont = false;
            this.textBoxScaner.UseScanModeOnly = false;
            // 
            // fillingRate
            // 
            this.fillingRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fillingRate.Location = new System.Drawing.Point(1017, 3);
            this.fillingRate.Name = "fillingRate";
            this.fillingRate.RedLine = 100;
            this.fillingRate.Size = new System.Drawing.Size(80, 198);
            this.fillingRate.TabIndex = 2;
            this.fillingRate.Value = 0;
            this.fillingRate.YellowLine = 90;
            // 
            // gvDocLines
            // 
            this.gvDocLines.AllowUserToAddRows = false;
            this.gvDocLines.AllowUserToDeleteRows = false;
            this.gvDocLines.AllowUserToResizeRows = false;
            this.gvDocLines.AutoGenerateColumns = false;
            this.gvDocLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDocLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSnowflake,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.iTinBXDataGridViewTextBoxColumn,
            this.lotCodeDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.locationFromDataGridViewTextBoxColumn,
            this.snowFlakeDataGridViewTextBoxColumn,
            this.bXQtyDataGridViewTextBoxColumn,
            this.iTQtyDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn});
            this.gvDocLines.DataSource = this.returnsDocLinesBindingSource;
            this.gvDocLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDocLines.Location = new System.Drawing.Point(0, 299);
            this.gvDocLines.Name = "gvDocLines";
            this.gvDocLines.ReadOnly = true;
            this.gvDocLines.RowHeadersVisible = false;
            this.gvDocLines.Size = new System.Drawing.Size(1109, 221);
            this.gvDocLines.TabIndex = 4;
            this.gvDocLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvDocLines_DataBindingComplete);
            // 
            // colSnowflake
            // 
            this.colSnowflake.HeaderText = "";
            this.colSnowflake.Name = "colSnowflake";
            this.colSnowflake.ReadOnly = true;
            this.colSnowflake.Width = 24;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 108;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 111;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 47;
            // 
            // iTinBXDataGridViewTextBoxColumn
            // 
            this.iTinBXDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTinBXDataGridViewTextBoxColumn.DataPropertyName = "ITinBX";
            this.iTinBXDataGridViewTextBoxColumn.HeaderText = "шт.";
            this.iTinBXDataGridViewTextBoxColumn.Name = "iTinBXDataGridViewTextBoxColumn";
            this.iTinBXDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTinBXDataGridViewTextBoxColumn.Width = 48;
            // 
            // lotCodeDataGridViewTextBoxColumn
            // 
            this.lotCodeDataGridViewTextBoxColumn.DataPropertyName = "Lot_Code";
            this.lotCodeDataGridViewTextBoxColumn.HeaderText = "Lot_Code";
            this.lotCodeDataGridViewTextBoxColumn.Name = "lotCodeDataGridViewTextBoxColumn";
            this.lotCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серия/Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 105;
            // 
            // locationFromDataGridViewTextBoxColumn
            // 
            this.locationFromDataGridViewTextBoxColumn.DataPropertyName = "LocationFrom";
            this.locationFromDataGridViewTextBoxColumn.HeaderText = "LocationFrom";
            this.locationFromDataGridViewTextBoxColumn.Name = "locationFromDataGridViewTextBoxColumn";
            this.locationFromDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationFromDataGridViewTextBoxColumn.Visible = false;
            // 
            // snowFlakeDataGridViewTextBoxColumn
            // 
            this.snowFlakeDataGridViewTextBoxColumn.DataPropertyName = "SnowFlake";
            this.snowFlakeDataGridViewTextBoxColumn.HeaderText = "SnowFlake";
            this.snowFlakeDataGridViewTextBoxColumn.Name = "snowFlakeDataGridViewTextBoxColumn";
            this.snowFlakeDataGridViewTextBoxColumn.ReadOnly = true;
            this.snowFlakeDataGridViewTextBoxColumn.Visible = false;
            // 
            // bXQtyDataGridViewTextBoxColumn
            // 
            this.bXQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bXQtyDataGridViewTextBoxColumn.DataPropertyName = "BX_Qty";
            this.bXQtyDataGridViewTextBoxColumn.HeaderText = "Ящиков";
            this.bXQtyDataGridViewTextBoxColumn.Name = "bXQtyDataGridViewTextBoxColumn";
            this.bXQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.bXQtyDataGridViewTextBoxColumn.Width = 73;
            // 
            // iTQtyDataGridViewTextBoxColumn
            // 
            this.iTQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTQtyDataGridViewTextBoxColumn.DataPropertyName = "IT_Qty";
            this.iTQtyDataGridViewTextBoxColumn.HeaderText = "Упаковок";
            this.iTQtyDataGridViewTextBoxColumn.Name = "iTQtyDataGridViewTextBoxColumn";
            this.iTQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTQtyDataGridViewTextBoxColumn.Width = 82;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 91;
            // 
            // returnsDocLinesBindingSource
            // 
            this.returnsDocLinesBindingSource.DataMember = "ReturnsDocLines";
            this.returnsDocLinesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // returnsDocLinesTableAdapter
            // 
            this.returnsDocLinesTableAdapter.ClearBeforeFill = true;
            // 
            // ApplyingOfReturnsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 520);
            this.Controls.Add(this.gvDocLines);
            this.Controls.Add(this.pnlWork);
            this.Controls.Add(this.tsMainMenu);
            this.KeyPreview = true;
            this.Name = "ApplyingOfReturnsWindow";
            this.Text = "Приемка возвратов";
            this.Load += new System.EventHandler(this.ApplyingOfReturnsWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplyingOfReturnsWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApplyingOfReturnsWindow_KeyDown);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.pnlWork, 0);
            this.Controls.SetChildIndex(this.gvDocLines, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.pnlWork.ResumeLayout(false);
            this.pnlWork.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnsDocLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbApply;
        private System.Windows.Forms.ToolStripButton sbUndo;
        private System.Windows.Forms.ToolStripButton sbAddItemWithoutBarCode;
        private System.Windows.Forms.ToolStripButton sbCloseDoc;
        private System.Windows.Forms.ToolStripButton sbShowRemains;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlWork;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblItemEI;
        private System.Windows.Forms.Label lblItemsInBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label lblCountTotal;
        private System.Windows.Forms.Label lblCountItems;
        private System.Windows.Forms.Label lblCountBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lblItemSeria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbIT;
        private System.Windows.Forms.RadioButton rbBX;
        private WMSOffice.Controls.TextBoxScaner textBoxScaner;
        private WMSOffice.Controls.FillingRate fillingRate;
        private System.Windows.Forms.DataGridView gvDocLines;
        private System.Windows.Forms.BindingSource returnsDocLinesBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.ReturnsDocLinesTableAdapter returnsDocLinesTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn colSnowflake;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTinBXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snowFlakeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bXQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripLabel lblSelectLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.RadioButton rbWL;
        private System.Windows.Forms.ToolStripButton sbUndoDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}