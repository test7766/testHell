namespace WMSOffice.Dialogs.PickControl
{
    partial class IBPSDifferenceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCaption = new System.Windows.Forms.Label();
            this.dgvDifferences = new System.Windows.Forms.DataGridView();
            this.shipToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickSlipNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pSNQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iBPSDifferenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.interbranch = new WMSOffice.Data.Interbranch();
            this.pSDifferenceTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.PSDifferenceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDifferences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iBPSDifferenceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(12, 9);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(981, 33);
            this.lblCaption.TabIndex = 101;
            this.lblCaption.Text = "Следующие строки сборочного № {0} не были просканированы при формировании паллеты" +
                ":";
            // 
            // dgvDifferences
            // 
            this.dgvDifferences.AllowUserToAddRows = false;
            this.dgvDifferences.AllowUserToDeleteRows = false;
            this.dgvDifferences.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvDifferences.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDifferences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDifferences.AutoGenerateColumns = false;
            this.dgvDifferences.BackgroundColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDifferences.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDifferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDifferences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shipToDataGridViewTextBoxColumn,
            this.orderNumDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.pickSlipNumberDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.VendorLot,
            this.manufacturerDataGridViewTextBoxColumn,
            this.pSNQtyDataGridViewTextBoxColumn,
            this.docQtyDataGridViewTextBoxColumn});
            this.dgvDifferences.DataSource = this.iBPSDifferenceBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDifferences.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDifferences.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDifferences.Location = new System.Drawing.Point(12, 42);
            this.dgvDifferences.Name = "dgvDifferences";
            this.dgvDifferences.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDifferences.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDifferences.RowHeadersVisible = false;
            this.dgvDifferences.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvDifferences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDifferences.ShowEditingIcon = false;
            this.dgvDifferences.Size = new System.Drawing.Size(981, 356);
            this.dgvDifferences.TabIndex = 102;
            // 
            // shipToDataGridViewTextBoxColumn
            // 
            this.shipToDataGridViewTextBoxColumn.DataPropertyName = "ShipTo";
            this.shipToDataGridViewTextBoxColumn.HeaderText = "Получатель";
            this.shipToDataGridViewTextBoxColumn.Name = "shipToDataGridViewTextBoxColumn";
            this.shipToDataGridViewTextBoxColumn.ReadOnly = true;
            this.shipToDataGridViewTextBoxColumn.Width = 180;
            // 
            // orderNumDataGridViewTextBoxColumn
            // 
            this.orderNumDataGridViewTextBoxColumn.DataPropertyName = "OrderNum";
            this.orderNumDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.orderNumDataGridViewTextBoxColumn.Name = "orderNumDataGridViewTextBoxColumn";
            this.orderNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumDataGridViewTextBoxColumn.Width = 85;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Тип заказа";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTypeDataGridViewTextBoxColumn.Width = 42;
            // 
            // pickSlipNumberDataGridViewTextBoxColumn
            // 
            this.pickSlipNumberDataGridViewTextBoxColumn.DataPropertyName = "PickSlipNumber";
            this.pickSlipNumberDataGridViewTextBoxColumn.HeaderText = "№ сборочного";
            this.pickSlipNumberDataGridViewTextBoxColumn.Name = "pickSlipNumberDataGridViewTextBoxColumn";
            this.pickSlipNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickSlipNumberDataGridViewTextBoxColumn.Width = 85;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 55;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Название товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // VendorLot
            // 
            this.VendorLot.DataPropertyName = "VendorLot";
            this.VendorLot.HeaderText = "Серия";
            this.VendorLot.Name = "VendorLot";
            this.VendorLot.ReadOnly = true;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pSNQtyDataGridViewTextBoxColumn
            // 
            this.pSNQtyDataGridViewTextBoxColumn.DataPropertyName = "PSN_Qty";
            this.pSNQtyDataGridViewTextBoxColumn.HeaderText = "К-во в сборочном";
            this.pSNQtyDataGridViewTextBoxColumn.Name = "pSNQtyDataGridViewTextBoxColumn";
            this.pSNQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.pSNQtyDataGridViewTextBoxColumn.Width = 65;
            // 
            // docQtyDataGridViewTextBoxColumn
            // 
            this.docQtyDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty";
            this.docQtyDataGridViewTextBoxColumn.HeaderText = "К-во отсканировано";
            this.docQtyDataGridViewTextBoxColumn.Name = "docQtyDataGridViewTextBoxColumn";
            this.docQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyDataGridViewTextBoxColumn.Width = 85;
            // 
            // iBPSDifferenceBindingSource
            // 
            this.iBPSDifferenceBindingSource.DataMember = "PSDifference";
            this.iBPSDifferenceBindingSource.DataSource = this.interbranch;
            // 
            // interbranch
            // 
            this.interbranch.DataSetName = "Interbranch";
            this.interbranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pSDifferenceTableAdapter
            // 
            this.pSDifferenceTableAdapter.ClearBeforeFill = true;
            // 
            // IBPSDifferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 447);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.dgvDifferences);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "IBPSDifferenceForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Недостающие строки из сборочного";
            this.Controls.SetChildIndex(this.dgvDifferences, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDifferences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iBPSDifferenceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.DataGridView dgvDifferences;
        private System.Windows.Forms.BindingSource iBPSDifferenceBindingSource;
        private WMSOffice.Data.Interbranch interbranch;
        private WMSOffice.Data.InterbranchTableAdapters.PSDifferenceTableAdapter pSDifferenceTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickSlipNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSNQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyDataGridViewTextBoxColumn;

    }
}