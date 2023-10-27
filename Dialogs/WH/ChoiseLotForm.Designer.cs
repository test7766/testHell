namespace WMSOffice.Dialogs.WH
{
    partial class ChoiseLotForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLots = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotStatusCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityCommit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wH = new WMSOffice.Data.WH();
            this.lotsTableAdapter = new WMSOffice.Data.WHTableAdapters.LotsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(681, 17);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(762, 17);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 351);
            this.pnlButtons.Size = new System.Drawing.Size(843, 43);
            // 
            // dgvLots
            // 
            this.dgvLots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLots.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLots.LargeAmountOfData = false;
            this.dgvLots.Location = new System.Drawing.Point(0, 0);
            this.dgvLots.Name = "dgvLots";
            this.dgvLots.RowHeadersVisible = false;
            this.dgvLots.Size = new System.Drawing.Size(843, 353);
            this.dgvLots.TabIndex = 101;
            this.dgvLots.UserID = ((long)(0));
            this.dgvLots.OnRowDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLots_CellDoubleClick);
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Место";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "VendorLot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Кол-во";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "Ед. изм.";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 75;
            // 
            // lotStatusCodeDataGridViewTextBoxColumn
            // 
            this.lotStatusCodeDataGridViewTextBoxColumn.DataPropertyName = "LotStatusCode";
            this.lotStatusCodeDataGridViewTextBoxColumn.HeaderText = "Код блок. партии";
            this.lotStatusCodeDataGridViewTextBoxColumn.Name = "lotStatusCodeDataGridViewTextBoxColumn";
            this.lotStatusCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expDateDataGridViewTextBoxColumn
            // 
            this.expDateDataGridViewTextBoxColumn.DataPropertyName = "ExpDate";
            this.expDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            this.expDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SSCC
            // 
            this.SSCC.DataPropertyName = "SSCC";
            this.SSCC.HeaderText = "SSCC";
            this.SSCC.Name = "SSCC";
            this.SSCC.ReadOnly = true;
            // 
            // lotStatusDataGridViewTextBoxColumn
            // 
            this.lotStatusDataGridViewTextBoxColumn.DataPropertyName = "LotStatus";
            this.lotStatusDataGridViewTextBoxColumn.HeaderText = "Блокировка партии";
            this.lotStatusDataGridViewTextBoxColumn.Name = "lotStatusDataGridViewTextBoxColumn";
            this.lotStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GLCategory
            // 
            this.GLCategory.DataPropertyName = "GLCategory";
            this.GLCategory.HeaderText = "Класс ГК";
            this.GLCategory.Name = "GLCategory";
            this.GLCategory.ReadOnly = true;
            // 
            // costPriceDataGridViewTextBoxColumn
            // 
            this.costPriceDataGridViewTextBoxColumn.DataPropertyName = "CostPrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.costPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.costPriceDataGridViewTextBoxColumn.HeaderText = "Себестоимость, грн.";
            this.costPriceDataGridViewTextBoxColumn.Name = "costPriceDataGridViewTextBoxColumn";
            this.costPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BasePrice
            // 
            this.BasePrice.DataPropertyName = "BasePrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.BasePrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.BasePrice.HeaderText = "Базовая цена, грн.";
            this.BasePrice.Name = "BasePrice";
            this.BasePrice.ReadOnly = true;
            // 
            // QuantityCommit
            // 
            this.QuantityCommit.DataPropertyName = "QuantityCommit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.QuantityCommit.DefaultCellStyle = dataGridViewCellStyle3;
            this.QuantityCommit.HeaderText = "Кол-во зарезервировано";
            this.QuantityCommit.Name = "QuantityCommit";
            this.QuantityCommit.ReadOnly = true;
            // 
            // QuantityFree
            // 
            this.QuantityFree.DataPropertyName = "QuantityFree";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.QuantityFree.DefaultCellStyle = dataGridViewCellStyle4;
            this.QuantityFree.HeaderText = "Кол-во доступно";
            this.QuantityFree.Name = "QuantityFree";
            this.QuantityFree.ReadOnly = true;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lotsTableAdapter
            // 
            this.lotsTableAdapter.ClearBeforeFill = true;
            // 
            // ChoiseLotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 394);
            this.Controls.Add(this.dgvLots);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ChoiseLotForm";
            this.Text = "Выбор партии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiseLotForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvLots, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvLots;
        private System.Windows.Forms.BindingSource lotsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.LotsTableAdapter lotsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotStatusCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityCommit;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityFree;
    }
}