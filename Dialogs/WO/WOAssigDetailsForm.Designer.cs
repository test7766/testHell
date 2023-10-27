namespace WMSOffice.Dialogs.WO
{
    partial class WOAssigDetailsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFact = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvItem = new System.Windows.Forms.DataGridView();
            this.gvAssig = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDeleteAssigResults = new System.Windows.Forms.ToolStripButton();
            this.vendorLotDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locn1DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.woAssigDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wMove = new WMSOffice.Data.WMove();
            this.woAssigDetailsTableAdapter = new WMSOffice.Data.WMoveTableAdapters.WoAssigDetailsTableAdapter();
            this.assigIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locn1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locn2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manuFacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssig)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.woAssigDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMove)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFact);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblItemName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblItemCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 54);
            this.panel1.TabIndex = 101;
            // 
            // lblFact
            // 
            this.lblFact.AutoSize = true;
            this.lblFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFact.ForeColor = System.Drawing.Color.Maroon;
            this.lblFact.Location = new System.Drawing.Point(187, 31);
            this.lblFact.Name = "lblFact";
            this.lblFact.Size = new System.Drawing.Size(49, 13);
            this.lblFact.TabIndex = 7;
            this.lblFact.Text = "100000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Факт:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuantity.Location = new System.Drawing.Point(62, 31);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "100000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Кол-во:";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(187, 9);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(41, 13);
            this.lblItemName.TabIndex = 3;
            this.lblItemName.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Наименование:";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemCode.Location = new System.Drawing.Point(47, 9);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(42, 13);
            this.lblItemCode.TabIndex = 1;
            this.lblItemCode.Text = "99999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvItem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvAssig);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(719, 372);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 102;
            // 
            // gvItem
            // 
            this.gvItem.AllowUserToAddRows = false;
            this.gvItem.AllowUserToDeleteRows = false;
            this.gvItem.AllowUserToResizeRows = false;
            this.gvItem.AutoGenerateColumns = false;
            this.gvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendorLotDataGridViewTextBoxColumn1,
            this.locn1DataGridViewTextBoxColumn1,
            this.docQtyDataGridViewTextBoxColumn1,
            this.assigIDDataGridViewTextBoxColumn1});
            this.gvItem.DataSource = this.woAssigDetailsBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvItem.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvItem.Location = new System.Drawing.Point(0, 0);
            this.gvItem.MultiSelect = false;
            this.gvItem.Name = "gvItem";
            this.gvItem.ReadOnly = true;
            this.gvItem.RowHeadersVisible = false;
            this.gvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvItem.Size = new System.Drawing.Size(719, 145);
            this.gvItem.TabIndex = 6;
            this.gvItem.SelectionChanged += new System.EventHandler(this.gvDocTypes_SelectionChanged);
            // 
            // gvAssig
            // 
            this.gvAssig.AllowUserToAddRows = false;
            this.gvAssig.AllowUserToDeleteRows = false;
            this.gvAssig.AllowUserToResizeRows = false;
            this.gvAssig.AutoGenerateColumns = false;
            this.gvAssig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAssig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assigIDDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.docQtyDataGridViewTextBoxColumn,
            this.locn1DataGridViewTextBoxColumn,
            this.locn2DataGridViewTextBoxColumn,
            this.manuFacturerDataGridViewTextBoxColumn});
            this.gvAssig.DataSource = this.woAssigDetailsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAssig.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvAssig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAssig.Location = new System.Drawing.Point(0, 25);
            this.gvAssig.MultiSelect = false;
            this.gvAssig.Name = "gvAssig";
            this.gvAssig.ReadOnly = true;
            this.gvAssig.RowHeadersVisible = false;
            this.gvAssig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAssig.Size = new System.Drawing.Size(719, 198);
            this.gvAssig.TabIndex = 6;
            this.gvAssig.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvAssig_DataBindingComplete);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 38);
            this.panel2.TabIndex = 103;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(632, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeleteAssigResults});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(719, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDeleteAssigResults
            // 
            this.btnDeleteAssigResults.Enabled = false;
            this.btnDeleteAssigResults.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeleteAssigResults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteAssigResults.Name = "btnDeleteAssigResults";
            this.btnDeleteAssigResults.Size = new System.Drawing.Size(203, 22);
            this.btnDeleteAssigResults.Text = "Удалить результаты назначения";
            this.btnDeleteAssigResults.Click += new System.EventHandler(this.btnDeleteAssigResults_Click);
            // 
            // vendorLotDataGridViewTextBoxColumn1
            // 
            this.vendorLotDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn1.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn1.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn1.Name = "vendorLotDataGridViewTextBoxColumn1";
            this.vendorLotDataGridViewTextBoxColumn1.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn1.Width = 63;
            // 
            // locn1DataGridViewTextBoxColumn1
            // 
            this.locn1DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locn1DataGridViewTextBoxColumn1.DataPropertyName = "Locn_1";
            this.locn1DataGridViewTextBoxColumn1.HeaderText = "Полка";
            this.locn1DataGridViewTextBoxColumn1.Name = "locn1DataGridViewTextBoxColumn1";
            this.locn1DataGridViewTextBoxColumn1.ReadOnly = true;
            this.locn1DataGridViewTextBoxColumn1.Width = 64;
            // 
            // docQtyDataGridViewTextBoxColumn1
            // 
            this.docQtyDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docQtyDataGridViewTextBoxColumn1.DataPropertyName = "Doc_Qty";
            this.docQtyDataGridViewTextBoxColumn1.HeaderText = "Кол-во";
            this.docQtyDataGridViewTextBoxColumn1.Name = "docQtyDataGridViewTextBoxColumn1";
            this.docQtyDataGridViewTextBoxColumn1.ReadOnly = true;
            this.docQtyDataGridViewTextBoxColumn1.Width = 66;
            // 
            // assigIDDataGridViewTextBoxColumn1
            // 
            this.assigIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.assigIDDataGridViewTextBoxColumn1.DataPropertyName = "Assig_ID";
            this.assigIDDataGridViewTextBoxColumn1.HeaderText = "ID назначения";
            this.assigIDDataGridViewTextBoxColumn1.Name = "assigIDDataGridViewTextBoxColumn1";
            this.assigIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.assigIDDataGridViewTextBoxColumn1.Width = 97;
            // 
            // woAssigDetailsBindingSource
            // 
            this.woAssigDetailsBindingSource.DataMember = "WoAssigDetails";
            this.woAssigDetailsBindingSource.DataSource = this.wMove;
            // 
            // wMove
            // 
            this.wMove.DataSetName = "WMove";
            this.wMove.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // woAssigDetailsTableAdapter
            // 
            this.woAssigDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // assigIDDataGridViewTextBoxColumn
            // 
            this.assigIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.assigIDDataGridViewTextBoxColumn.DataPropertyName = "Assig_ID";
            this.assigIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.assigIDDataGridViewTextBoxColumn.Name = "assigIDDataGridViewTextBoxColumn";
            this.assigIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.assigIDDataGridViewTextBoxColumn.Width = 43;
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
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 63;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 69;
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
            // docQtyDataGridViewTextBoxColumn
            // 
            this.docQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docQtyDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty";
            this.docQtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.docQtyDataGridViewTextBoxColumn.Name = "docQtyDataGridViewTextBoxColumn";
            this.docQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyDataGridViewTextBoxColumn.Width = 66;
            // 
            // locn1DataGridViewTextBoxColumn
            // 
            this.locn1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locn1DataGridViewTextBoxColumn.DataPropertyName = "Locn_1";
            this.locn1DataGridViewTextBoxColumn.HeaderText = "С полки";
            this.locn1DataGridViewTextBoxColumn.Name = "locn1DataGridViewTextBoxColumn";
            this.locn1DataGridViewTextBoxColumn.ReadOnly = true;
            this.locn1DataGridViewTextBoxColumn.Width = 72;
            // 
            // locn2DataGridViewTextBoxColumn
            // 
            this.locn2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locn2DataGridViewTextBoxColumn.DataPropertyName = "Locn_2";
            this.locn2DataGridViewTextBoxColumn.HeaderText = "На полку";
            this.locn2DataGridViewTextBoxColumn.Name = "locn2DataGridViewTextBoxColumn";
            this.locn2DataGridViewTextBoxColumn.ReadOnly = true;
            this.locn2DataGridViewTextBoxColumn.Width = 78;
            // 
            // manuFacturerDataGridViewTextBoxColumn
            // 
            this.manuFacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manuFacturerDataGridViewTextBoxColumn.DataPropertyName = "ManuFacturer";
            this.manuFacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manuFacturerDataGridViewTextBoxColumn.Name = "manuFacturerDataGridViewTextBoxColumn";
            this.manuFacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manuFacturerDataGridViewTextBoxColumn.Width = 111;
            // 
            // WOAssigDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(719, 464);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MinimizeBox = false;
            this.Name = "WOAssigDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результат выполнения задания на ТСД";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WOAssigDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssig)).EndInit();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.woAssigDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvItem;
        private System.Windows.Forms.DataGridView gvAssig;
        private System.Windows.Forms.BindingSource woAssigDetailsBindingSource;
        private WMSOffice.Data.WMove wMove;
        private WMSOffice.Data.WMoveTableAdapters.WoAssigDetailsTableAdapter woAssigDetailsTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDeleteAssigResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn locn1DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locn1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locn2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manuFacturerDataGridViewTextBoxColumn;
    }
}