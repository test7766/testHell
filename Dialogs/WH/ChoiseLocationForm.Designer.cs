namespace WMSOffice.Dialogs.WH
{
    partial class ChoiseLocationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLocations = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotStatusCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.locationsTableAdapter = new WMSOffice.Data.WHTableAdapters.LocationsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(673, 17);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(754, 17);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 345);
            this.pnlButtons.Size = new System.Drawing.Size(832, 43);
            // 
            // dgvLocations
            // 
            this.dgvLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLocations.LargeAmountOfData = false;
            this.dgvLocations.Location = new System.Drawing.Point(0, 0);
            this.dgvLocations.Name = "dgvLocations";
            this.dgvLocations.RowHeadersVisible = false;
            this.dgvLocations.Size = new System.Drawing.Size(832, 347);
            this.dgvLocations.TabIndex = 101;
            this.dgvLocations.UserID = ((long)(0));
            this.dgvLocations.OnRowDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocations_CellDoubleClick);
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
            // expDateDataGridViewTextBoxColumn
            // 
            this.expDateDataGridViewTextBoxColumn.DataPropertyName = "ExpDate";
            this.expDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            this.expDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lotStatusCodeDataGridViewTextBoxColumn
            // 
            this.lotStatusCodeDataGridViewTextBoxColumn.DataPropertyName = "LotStatusCode";
            this.lotStatusCodeDataGridViewTextBoxColumn.HeaderText = "Код блок. партии";
            this.lotStatusCodeDataGridViewTextBoxColumn.Name = "lotStatusCodeDataGridViewTextBoxColumn";
            this.lotStatusCodeDataGridViewTextBoxColumn.ReadOnly = true;
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
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Место";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iCLocationDataGridViewTextBoxColumn
            // 
            this.iCLocationDataGridViewTextBoxColumn.DataPropertyName = "IC_Location";
            this.iCLocationDataGridViewTextBoxColumn.HeaderText = "Ответств. лицо";
            this.iCLocationDataGridViewTextBoxColumn.Name = "iCLocationDataGridViewTextBoxColumn";
            this.iCLocationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "Ед. изм.";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 75;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 55;
            // 
            // costPriceDataGridViewTextBoxColumn
            // 
            this.costPriceDataGridViewTextBoxColumn.DataPropertyName = "CostPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.costPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.costPriceDataGridViewTextBoxColumn.HeaderText = "Себестоимость, грн.";
            this.costPriceDataGridViewTextBoxColumn.Name = "costPriceDataGridViewTextBoxColumn";
            this.costPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "BasePrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.HeaderText = "Базовая цена, грн.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // locationsBindingSource
            // 
            this.locationsBindingSource.DataMember = "Locations";
            this.locationsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // locationsTableAdapter
            // 
            this.locationsTableAdapter.ClearBeforeFill = true;
            // 
            // ChoiseLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 388);
            this.Controls.Add(this.dgvLocations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ChoiseLocationForm";
            this.Text = "Выбор партии и места";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiseLocationForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvLocations, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.locationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvLocations;
        private System.Windows.Forms.BindingSource locationsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.LocationsTableAdapter locationsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotStatusCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}