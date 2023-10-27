namespace WMSOffice.Dialogs.WH
{
    partial class ChoiseItemForm
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
            this.pnlSearchItem = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.itemsTableAdapter = new WMSOffice.Data.WHTableAdapters.ItemsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlSearchItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(511, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(592, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 195);
            this.pnlButtons.Size = new System.Drawing.Size(679, 43);
            // 
            // pnlSearchItem
            // 
            this.pnlSearchItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchItem.Controls.Add(this.btnSearch);
            this.pnlSearchItem.Controls.Add(this.tbItemName);
            this.pnlSearchItem.Controls.Add(this.tbItemID);
            this.pnlSearchItem.Controls.Add(this.lblItemName);
            this.pnlSearchItem.Controls.Add(this.lblItemID);
            this.pnlSearchItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchItem.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchItem.Name = "pnlSearchItem";
            this.pnlSearchItem.Size = new System.Drawing.Size(679, 30);
            this.pnlSearchItem.TabIndex = 101;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(452, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(303, 5);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(142, 20);
            this.tbItemName.TabIndex = 3;
            this.tbItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemName_KeyDown);
            // 
            // tbItemID
            // 
            this.tbItemID.Location = new System.Drawing.Point(76, 5);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.Size = new System.Drawing.Size(91, 20);
            this.tbItemID.TabIndex = 2;
            this.tbItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemID_KeyDown);
            this.tbItemID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemID_KeyPress);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(173, 8);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(124, 13);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "Наименование товара:";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(3, 8);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(67, 13);
            this.lblItemID.TabIndex = 0;
            this.lblItemID.Text = "Код товара:";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToOrderColumns = true;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.itemsBindingSource;
            this.dgvItems.Location = new System.Drawing.Point(0, 32);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(679, 161);
            this.dgvItems.TabIndex = 102;
            this.dgvItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellDoubleClick);
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 250;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 200;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "Ед. изм.";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 75;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Допуст. кол-во";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 55;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // ChoiseItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 238);
            this.Controls.Add(this.pnlSearchItem);
            this.Controls.Add(this.dgvItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ChoiseItemForm";
            this.Text = "Выбор товара";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiseItemForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvItems, 0);
            this.Controls.SetChildIndex(this.pnlSearchItem, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlSearchItem.ResumeLayout(false);
            this.pnlSearchItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchItem;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.ItemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
    }
}