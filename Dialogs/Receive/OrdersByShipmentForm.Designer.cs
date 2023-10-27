namespace WMSOffice.Dialogs.Receive
{
    partial class OrdersByShipmentForm
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
            this.dgvShipmentOrders = new System.Windows.Forms.DataGridView();
            this.ordersByShipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.ordersByShipmentTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.OrdersByShipmentTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipmentOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersByShipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(517, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(607, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 278);
            this.pnlButtons.Size = new System.Drawing.Size(694, 43);
            // 
            // dgvShipmentOrders
            // 
            this.dgvShipmentOrders.AllowUserToAddRows = false;
            this.dgvShipmentOrders.AllowUserToDeleteRows = false;
            this.dgvShipmentOrders.AllowUserToResizeRows = false;
            this.dgvShipmentOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShipmentOrders.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShipmentOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShipmentOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipmentOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderTypeDataGridViewTextBoxColumn,
            this.ordeNumberDataGridViewTextBoxColumn,
            this.orderStatusDataGridViewTextBoxColumn,
            this.ordByDataGridViewTextBoxColumn,
            this.PackCode,
            this.SuppStatusID});
            this.dgvShipmentOrders.DataSource = this.ordersByShipmentBindingSource;
            this.dgvShipmentOrders.Location = new System.Drawing.Point(0, 2);
            this.dgvShipmentOrders.MultiSelect = false;
            this.dgvShipmentOrders.Name = "dgvShipmentOrders";
            this.dgvShipmentOrders.ReadOnly = true;
            this.dgvShipmentOrders.RowHeadersVisible = false;
            this.dgvShipmentOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShipmentOrders.Size = new System.Drawing.Size(694, 278);
            this.dgvShipmentOrders.TabIndex = 101;
            this.dgvShipmentOrders.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvShipmentOrders_DataBindingComplete);
            // 
            // ordersByShipmentBindingSource
            // 
            this.ordersByShipmentBindingSource.DataMember = "OrdersByShipment";
            this.ordersByShipmentBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordersByShipmentTableAdapter
            // 
            this.ordersByShipmentTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderType";
            this.dataGridViewTextBoxColumn1.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrdeNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "Заказ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OrderStatus";
            this.dataGridViewTextBoxColumn3.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrdBy";
            this.dataGridViewTextBoxColumn4.HeaderText = "OrdBy";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Тип заказа";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orderTypeDataGridViewTextBoxColumn.Width = 50;
            // 
            // ordeNumberDataGridViewTextBoxColumn
            // 
            this.ordeNumberDataGridViewTextBoxColumn.DataPropertyName = "OrdeNumber";
            this.ordeNumberDataGridViewTextBoxColumn.HeaderText = "Заказ";
            this.ordeNumberDataGridViewTextBoxColumn.Name = "ordeNumberDataGridViewTextBoxColumn";
            this.ordeNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordeNumberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ordeNumberDataGridViewTextBoxColumn.Width = 70;
            // 
            // orderStatusDataGridViewTextBoxColumn
            // 
            this.orderStatusDataGridViewTextBoxColumn.DataPropertyName = "OrderStatus";
            this.orderStatusDataGridViewTextBoxColumn.HeaderText = "Статус заказа";
            this.orderStatusDataGridViewTextBoxColumn.Name = "orderStatusDataGridViewTextBoxColumn";
            this.orderStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderStatusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orderStatusDataGridViewTextBoxColumn.Width = 50;
            // 
            // ordByDataGridViewTextBoxColumn
            // 
            this.ordByDataGridViewTextBoxColumn.DataPropertyName = "OrdBy";
            this.ordByDataGridViewTextBoxColumn.HeaderText = "МОЗ";
            this.ordByDataGridViewTextBoxColumn.Name = "ordByDataGridViewTextBoxColumn";
            this.ordByDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordByDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ordByDataGridViewTextBoxColumn.Width = 250;
            // 
            // PackCode
            // 
            this.PackCode.DataPropertyName = "PackCode";
            this.PackCode.HeaderText = "УП";
            this.PackCode.Name = "PackCode";
            this.PackCode.ReadOnly = true;
            this.PackCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PackCode.Width = 150;
            // 
            // SuppStatusID
            // 
            this.SuppStatusID.DataPropertyName = "SuppStatusID";
            this.SuppStatusID.HeaderText = "Статус УП";
            this.SuppStatusID.Name = "SuppStatusID";
            this.SuppStatusID.ReadOnly = true;
            this.SuppStatusID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OrdersByShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 321);
            this.Controls.Add(this.dgvShipmentOrders);
            this.Name = "OrdersByShipmentForm";
            this.Text = "Заказы по поставке";
            this.Controls.SetChildIndex(this.dgvShipmentOrders, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipmentOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersByShipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShipmentOrders;
        private System.Windows.Forms.BindingSource ordersByShipmentBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.OrdersByShipmentTableAdapter ordersByShipmentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppStatusID;
    }
}