namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryClosureActionsForm
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
            this.dgvClosureActions = new System.Windows.Forms.DataGridView();
            this.dgvicAccess = new System.Windows.Forms.DataGridViewImageColumn();
            this.dESCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryClosureActionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.inventoryClosureActionsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoryClosureActionsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosureActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryClosureActionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(824, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(914, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 164);
            this.pnlButtons.Size = new System.Drawing.Size(526, 43);
            // 
            // dgvClosureActions
            // 
            this.dgvClosureActions.AllowUserToAddRows = false;
            this.dgvClosureActions.AllowUserToDeleteRows = false;
            this.dgvClosureActions.AllowUserToResizeRows = false;
            this.dgvClosureActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClosureActions.AutoGenerateColumns = false;
            this.dgvClosureActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClosureActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvicAccess,
            this.dESCDataGridViewTextBoxColumn});
            this.dgvClosureActions.DataSource = this.inventoryClosureActionsBindingSource;
            this.dgvClosureActions.Location = new System.Drawing.Point(0, 3);
            this.dgvClosureActions.MultiSelect = false;
            this.dgvClosureActions.Name = "dgvClosureActions";
            this.dgvClosureActions.RowHeadersVisible = false;
            this.dgvClosureActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClosureActions.Size = new System.Drawing.Size(526, 155);
            this.dgvClosureActions.TabIndex = 101;
            this.dgvClosureActions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvClosureActions_CellFormatting);
            this.dgvClosureActions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClosureActions_CellMouseDoubleClick);
            this.dgvClosureActions.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvClosureActions_DataBindingComplete);
            this.dgvClosureActions.SelectionChanged += new System.EventHandler(this.dgvClosureActions_SelectionChanged);
            // 
            // dgvicAccess
            // 
            this.dgvicAccess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvicAccess.HeaderText = "Доступ";
            this.dgvicAccess.Name = "dgvicAccess";
            this.dgvicAccess.ReadOnly = true;
            this.dgvicAccess.Width = 50;
            // 
            // dESCDataGridViewTextBoxColumn
            // 
            this.dESCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dESCDataGridViewTextBoxColumn.DataPropertyName = "DESC";
            this.dESCDataGridViewTextBoxColumn.HeaderText = "Описание режима работы";
            this.dESCDataGridViewTextBoxColumn.Name = "dESCDataGridViewTextBoxColumn";
            this.dESCDataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dESCDataGridViewTextBoxColumn.Width = 98;
            // 
            // inventoryClosureActionsBindingSource
            // 
            this.inventoryClosureActionsBindingSource.DataMember = "InventoryClosureActions";
            this.inventoryClosureActionsBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryClosureActionsTableAdapter
            // 
            this.inventoryClosureActionsTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryClosureActionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 207);
            this.Controls.Add(this.dgvClosureActions);
            this.Name = "InventoryClosureActionsForm";
            this.Text = "Выберите режим работы при закрытии инвентаризации";
            this.Controls.SetChildIndex(this.dgvClosureActions, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosureActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryClosureActionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClosureActions;
        private System.Windows.Forms.BindingSource inventoryClosureActionsBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.InventoryClosureActionsTableAdapter inventoryClosureActionsTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn dgvicAccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCDataGridViewTextBoxColumn;
    }
}