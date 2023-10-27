namespace WMSOffice.Dialogs.Receive
{
    partial class ProblemItemEditorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProblemItem = new System.Windows.Forms.DataGridView();
            this.problemItemCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.problemItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proxyBusinessObjects = new WMSOffice.Data.ProxyBusinessObjects();
            this.problemItemCategoriesTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.ProblemItemCategoriesTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.problemQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProblemCategoryID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblemItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemItemCategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proxyBusinessObjects)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(265, 8);
            this.btnOK.Text = "Сохранить";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(365, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 92);
            this.pnlButtons.Size = new System.Drawing.Size(705, 43);
            // 
            // dgvProblemItem
            // 
            this.dgvProblemItem.AllowUserToAddRows = false;
            this.dgvProblemItem.AllowUserToDeleteRows = false;
            this.dgvProblemItem.AllowUserToOrderColumns = true;
            this.dgvProblemItem.AllowUserToResizeRows = false;
            this.dgvProblemItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProblemItem.AutoGenerateColumns = false;
            this.dgvProblemItem.ColumnHeadersHeight = 35;
            this.dgvProblemItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.totalQuantityDataGridViewTextBoxColumn,
            this.problemQuantityDataGridViewTextBoxColumn,
            this.ProblemCategoryID});
            this.dgvProblemItem.DataSource = this.problemItemBindingSource;
            this.dgvProblemItem.Location = new System.Drawing.Point(0, 0);
            this.dgvProblemItem.MultiSelect = false;
            this.dgvProblemItem.Name = "dgvProblemItem";
            this.dgvProblemItem.RowHeadersVisible = false;
            this.dgvProblemItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProblemItem.Size = new System.Drawing.Size(705, 90);
            this.dgvProblemItem.TabIndex = 101;
            this.dgvProblemItem.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProblemItem_DataError);
            this.dgvProblemItem.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProblemItem_CellEnter);
            // 
            // problemItemCategoriesBindingSource
            // 
            this.problemItemCategoriesBindingSource.DataMember = "ProblemItemCategories";
            this.problemItemCategoriesBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // problemItemBindingSource
            // 
            this.problemItemBindingSource.DataMember = "ProblemItem";
            this.problemItemBindingSource.DataSource = this.proxyBusinessObjects;
            // 
            // proxyBusinessObjects
            // 
            this.proxyBusinessObjects.DataSetName = "ProxyBusinessObjects";
            this.proxyBusinessObjects.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // problemItemCategoriesTableAdapter
            // 
            this.problemItemCategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ItemID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "VendorLot";
            this.dataGridViewTextBoxColumn3.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalQuantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "Кол-во всего, шт.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ProblemQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn5.HeaderText = "Проблемного товара, шт.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "ProblemCategoryID";
            this.dataGridViewComboBoxColumn1.DataSource = this.problemItemCategoriesBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "CategoryName";
            this.dataGridViewComboBoxColumn1.HeaderText = "Категория ПТ";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ValueMember = "ID";
            this.dataGridViewComboBoxColumn1.Width = 120;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 240;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "VendorLot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 63;
            // 
            // totalQuantityDataGridViewTextBoxColumn
            // 
            this.totalQuantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalQuantityDataGridViewTextBoxColumn.DataPropertyName = "TotalQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.totalQuantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.totalQuantityDataGridViewTextBoxColumn.HeaderText = "Кол-во всего, шт.";
            this.totalQuantityDataGridViewTextBoxColumn.Name = "totalQuantityDataGridViewTextBoxColumn";
            this.totalQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalQuantityDataGridViewTextBoxColumn.Width = 96;
            // 
            // problemQuantityDataGridViewTextBoxColumn
            // 
            this.problemQuantityDataGridViewTextBoxColumn.DataPropertyName = "ProblemQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.problemQuantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.problemQuantityDataGridViewTextBoxColumn.HeaderText = "Проблемного товара, шт.";
            this.problemQuantityDataGridViewTextBoxColumn.Name = "problemQuantityDataGridViewTextBoxColumn";
            // 
            // ProblemCategoryID
            // 
            this.ProblemCategoryID.DataPropertyName = "ProblemCategoryID";
            this.ProblemCategoryID.DataSource = this.problemItemCategoriesBindingSource;
            this.ProblemCategoryID.DisplayMember = "CategoryName";
            this.ProblemCategoryID.HeaderText = "Категория ПТ";
            this.ProblemCategoryID.Name = "ProblemCategoryID";
            this.ProblemCategoryID.ValueMember = "ID";
            this.ProblemCategoryID.Width = 120;
            // 
            // ProblemItemEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 135);
            this.Controls.Add(this.dgvProblemItem);
            this.Name = "ProblemItemEditorForm";
            this.Text = "Обнаружен проблемный товар при приемке";
            this.Load += new System.EventHandler(this.ProblemItemEditorForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProblemItemEditorForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvProblemItem, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblemItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemItemCategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proxyBusinessObjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProblemItem;
        private System.Windows.Forms.BindingSource problemItemBindingSource;
        private WMSOffice.Data.ProxyBusinessObjects proxyBusinessObjects;
        private System.Windows.Forms.BindingSource problemItemCategoriesBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.ProblemItemCategoriesTableAdapter problemItemCategoriesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn problemQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProblemCategoryID;
    }
}