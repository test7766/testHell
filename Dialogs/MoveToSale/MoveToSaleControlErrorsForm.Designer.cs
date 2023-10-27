namespace WMSOffice.Dialogs.MoveToSale
{
    partial class MoveToSaleControlErrorsForm
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
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.controlErrorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moveToSale = new WMSOffice.Data.MoveToSale();
            this.errorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlErrorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToSale)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(820, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(910, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 429);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
            // 
            // dgvErrors
            // 
            this.dgvErrors.AllowUserToAddRows = false;
            this.dgvErrors.AllowUserToDeleteRows = false;
            this.dgvErrors.AllowUserToResizeRows = false;
            this.dgvErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvErrors.AutoGenerateColumns = false;
            this.dgvErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.errorTypeDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.Lot_Number,
            this.diffDataGridViewTextBoxColumn});
            this.dgvErrors.DataSource = this.controlErrorsBindingSource;
            this.dgvErrors.Location = new System.Drawing.Point(0, 1);
            this.dgvErrors.MultiSelect = false;
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.ReadOnly = true;
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(994, 422);
            this.dgvErrors.TabIndex = 101;
            // 
            // controlErrorsBindingSource
            // 
            this.controlErrorsBindingSource.DataMember = "ControlErrors";
            this.controlErrorsBindingSource.DataSource = this.moveToSale;
            // 
            // moveToSale
            // 
            this.moveToSale.DataSetName = "MoveToSale";
            this.moveToSale.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorTypeDataGridViewTextBoxColumn
            // 
            this.errorTypeDataGridViewTextBoxColumn.DataPropertyName = "ErrorType";
            this.errorTypeDataGridViewTextBoxColumn.HeaderText = "Тип расхождения";
            this.errorTypeDataGridViewTextBoxColumn.Name = "errorTypeDataGridViewTextBoxColumn";
            this.errorTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.errorTypeDataGridViewTextBoxColumn.Width = 111;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 82;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 108;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 63;
            // 
            // Lot_Number
            // 
            this.Lot_Number.DataPropertyName = "Lot_Number";
            this.Lot_Number.HeaderText = "Партия";
            this.Lot_Number.Name = "Lot_Number";
            this.Lot_Number.ReadOnly = true;
            this.Lot_Number.Width = 69;
            // 
            // diffDataGridViewTextBoxColumn
            // 
            this.diffDataGridViewTextBoxColumn.DataPropertyName = "Diff";
            this.diffDataGridViewTextBoxColumn.HeaderText = "Количество (Разница)";
            this.diffDataGridViewTextBoxColumn.Name = "diffDataGridViewTextBoxColumn";
            this.diffDataGridViewTextBoxColumn.ReadOnly = true;
            this.diffDataGridViewTextBoxColumn.Width = 131;
            // 
            // MoveToSaleControlErrorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 472);
            this.Controls.Add(this.dgvErrors);
            this.Name = "MoveToSaleControlErrorsForm";
            this.Text = "Ошибки при контроле перемещения из ПО на ЦС";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MoveToSaleControlErrorsForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvErrors, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlErrorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToSale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.BindingSource controlErrorsBindingSource;
        private WMSOffice.Data.MoveToSale moveToSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn diffDataGridViewTextBoxColumn;
    }
}