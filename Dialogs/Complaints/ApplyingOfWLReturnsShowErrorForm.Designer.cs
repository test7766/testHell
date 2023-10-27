namespace WMSOffice.Dialogs.Complaints
{
    partial class ApplyingOfWLReturnsShowErrorForm
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
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pSNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDscDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitofMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyonPSNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessQtyonPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mCUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODocErrorItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.cO_DocError_ItemsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_DocError_ItemsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODocErrorItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1461, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1551, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 628);
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
            this.docIDDataGridViewTextBoxColumn,
            this.pSNDataGridViewTextBoxColumn,
            this.barCodeDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDscDataGridViewTextBoxColumn,
            this.unitofMeasureDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.qtyonPSNDataGridViewTextBoxColumn,
            this.accessQtyonPlaceDataGridViewTextBoxColumn,
            this.locationIdDataGridViewTextBoxColumn,
            this.mCUDataGridViewTextBoxColumn});
            this.dgvErrors.DataSource = this.cODocErrorItemsBindingSource;
            this.dgvErrors.Location = new System.Drawing.Point(0, 1);
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.ReadOnly = true;
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(994, 629);
            this.dgvErrors.TabIndex = 101;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "№ документа";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 92;
            // 
            // pSNDataGridViewTextBoxColumn
            // 
            this.pSNDataGridViewTextBoxColumn.DataPropertyName = "PSN";
            this.pSNDataGridViewTextBoxColumn.HeaderText = "Сборочный";
            this.pSNDataGridViewTextBoxColumn.Name = "pSNDataGridViewTextBoxColumn";
            this.pSNDataGridViewTextBoxColumn.ReadOnly = true;
            this.pSNDataGridViewTextBoxColumn.Width = 88;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 53;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemDscDataGridViewTextBoxColumn
            // 
            this.itemDscDataGridViewTextBoxColumn.DataPropertyName = "Item_Dsc";
            this.itemDscDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemDscDataGridViewTextBoxColumn.Name = "itemDscDataGridViewTextBoxColumn";
            this.itemDscDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDscDataGridViewTextBoxColumn.Width = 108;
            // 
            // unitofMeasureDataGridViewTextBoxColumn
            // 
            this.unitofMeasureDataGridViewTextBoxColumn.DataPropertyName = "unitofMeasure";
            this.unitofMeasureDataGridViewTextBoxColumn.HeaderText = "Ед. изм.";
            this.unitofMeasureDataGridViewTextBoxColumn.Name = "unitofMeasureDataGridViewTextBoxColumn";
            this.unitofMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitofMeasureDataGridViewTextBoxColumn.Width = 69;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 69;
            // 
            // qtyonPSNDataGridViewTextBoxColumn
            // 
            this.qtyonPSNDataGridViewTextBoxColumn.DataPropertyName = "Qty_on_PSN";
            this.qtyonPSNDataGridViewTextBoxColumn.HeaderText = "Кол-во в сборочном";
            this.qtyonPSNDataGridViewTextBoxColumn.Name = "qtyonPSNDataGridViewTextBoxColumn";
            this.qtyonPSNDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyonPSNDataGridViewTextBoxColumn.Width = 122;
            // 
            // accessQtyonPlaceDataGridViewTextBoxColumn
            // 
            this.accessQtyonPlaceDataGridViewTextBoxColumn.DataPropertyName = "Access_Qty_on_Place";
            this.accessQtyonPlaceDataGridViewTextBoxColumn.HeaderText = "Доступное кол-во на месте";
            this.accessQtyonPlaceDataGridViewTextBoxColumn.Name = "accessQtyonPlaceDataGridViewTextBoxColumn";
            this.accessQtyonPlaceDataGridViewTextBoxColumn.ReadOnly = true;
            this.accessQtyonPlaceDataGridViewTextBoxColumn.Width = 115;
            // 
            // locationIdDataGridViewTextBoxColumn
            // 
            this.locationIdDataGridViewTextBoxColumn.DataPropertyName = "Location_Id";
            this.locationIdDataGridViewTextBoxColumn.HeaderText = "Место";
            this.locationIdDataGridViewTextBoxColumn.Name = "locationIdDataGridViewTextBoxColumn";
            this.locationIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationIdDataGridViewTextBoxColumn.Width = 64;
            // 
            // mCUDataGridViewTextBoxColumn
            // 
            this.mCUDataGridViewTextBoxColumn.DataPropertyName = "MCU";
            this.mCUDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.mCUDataGridViewTextBoxColumn.Name = "mCUDataGridViewTextBoxColumn";
            this.mCUDataGridViewTextBoxColumn.ReadOnly = true;
            this.mCUDataGridViewTextBoxColumn.Width = 63;
            // 
            // cODocErrorItemsBindingSource
            // 
            this.cODocErrorItemsBindingSource.DataMember = "CO_DocError_Items";
            this.cODocErrorItemsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cO_DocError_ItemsTableAdapter
            // 
            this.cO_DocError_ItemsTableAdapter.ClearBeforeFill = true;
            // 
            // ApplyingOfWLReturnsShowErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 671);
            this.Controls.Add(this.dgvErrors);
            this.Name = "ApplyingOfWLReturnsShowErrorForm";
            this.Text = "Ошибки сканирования БЭ";
            this.Load += new System.EventHandler(this.ApplyingOfWLReturnsShowErrorForm_Load);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvErrors, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODocErrorItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.BindingSource cODocErrorItemsBindingSource;
        private Data.Complaints complaints;
        private Data.ComplaintsTableAdapters.CO_DocError_ItemsTableAdapter cO_DocError_ItemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDscDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitofMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyonPSNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessQtyonPlaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mCUDataGridViewTextBoxColumn;
    }
}