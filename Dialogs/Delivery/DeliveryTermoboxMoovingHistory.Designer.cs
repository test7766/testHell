namespace WMSOffice.Dialogs.Delivery
{
    partial class DeliveryTermoboxMoovingHistory
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
            this.dgvTermoboxMoovingHistory = new System.Windows.Forms.DataGridView();
            this.termoboxMoovingHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.termoboxMoovingHistoryTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.TermoboxMoovingHistoryTableAdapter();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMDocsIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBALPHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermoboxMoovingHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.termoboxMoovingHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3393, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3483, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 429);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
            // 
            // dgvTermoboxMoovingHistory
            // 
            this.dgvTermoboxMoovingHistory.AllowUserToAddRows = false;
            this.dgvTermoboxMoovingHistory.AllowUserToDeleteRows = false;
            this.dgvTermoboxMoovingHistory.AllowUserToResizeRows = false;
            this.dgvTermoboxMoovingHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTermoboxMoovingHistory.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTermoboxMoovingHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTermoboxMoovingHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTermoboxMoovingHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeDataGridViewTextBoxColumn,
            this.aMDocsIDDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.dateOutDataGridViewTextBoxColumn,
            this.dateINDataGridViewTextBoxColumn,
            this.driverIDDataGridViewTextBoxColumn,
            this.aBALPHDataGridViewTextBoxColumn});
            this.dgvTermoboxMoovingHistory.DataSource = this.termoboxMoovingHistoryBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTermoboxMoovingHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTermoboxMoovingHistory.Location = new System.Drawing.Point(0, 2);
            this.dgvTermoboxMoovingHistory.MultiSelect = false;
            this.dgvTermoboxMoovingHistory.Name = "dgvTermoboxMoovingHistory";
            this.dgvTermoboxMoovingHistory.ReadOnly = true;
            this.dgvTermoboxMoovingHistory.RowHeadersVisible = false;
            this.dgvTermoboxMoovingHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTermoboxMoovingHistory.Size = new System.Drawing.Size(994, 421);
            this.dgvTermoboxMoovingHistory.TabIndex = 101;
            // 
            // termoboxMoovingHistoryBindingSource
            // 
            this.termoboxMoovingHistoryBindingSource.DataMember = "TermoboxMoovingHistory";
            this.termoboxMoovingHistoryBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // termoboxMoovingHistoryTableAdapter
            // 
            this.termoboxMoovingHistoryTableAdapter.ClearBeforeFill = true;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_code";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К термобокса";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // aMDocsIDDataGridViewTextBoxColumn
            // 
            this.aMDocsIDDataGridViewTextBoxColumn.DataPropertyName = "AM_Docs_ID";
            this.aMDocsIDDataGridViewTextBoxColumn.HeaderText = "№ акта вакцины";
            this.aMDocsIDDataGridViewTextBoxColumn.Name = "aMDocsIDDataGridViewTextBoxColumn";
            this.aMDocsIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "StatusID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Ст.";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateOutDataGridViewTextBoxColumn
            // 
            this.dateOutDataGridViewTextBoxColumn.DataPropertyName = "Date_Out";
            this.dateOutDataGridViewTextBoxColumn.HeaderText = "Дата выезда";
            this.dateOutDataGridViewTextBoxColumn.Name = "dateOutDataGridViewTextBoxColumn";
            this.dateOutDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateOutDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateINDataGridViewTextBoxColumn
            // 
            this.dateINDataGridViewTextBoxColumn.DataPropertyName = "Date_IN";
            this.dateINDataGridViewTextBoxColumn.HeaderText = "Дата заезда";
            this.dateINDataGridViewTextBoxColumn.Name = "dateINDataGridViewTextBoxColumn";
            this.dateINDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateINDataGridViewTextBoxColumn.Width = 200;
            // 
            // driverIDDataGridViewTextBoxColumn
            // 
            this.driverIDDataGridViewTextBoxColumn.DataPropertyName = "Driver_ID";
            this.driverIDDataGridViewTextBoxColumn.HeaderText = "Код водителя";
            this.driverIDDataGridViewTextBoxColumn.Name = "driverIDDataGridViewTextBoxColumn";
            this.driverIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.driverIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // aBALPHDataGridViewTextBoxColumn
            // 
            this.aBALPHDataGridViewTextBoxColumn.DataPropertyName = "ABALPH";
            this.aBALPHDataGridViewTextBoxColumn.HeaderText = "Водитель";
            this.aBALPHDataGridViewTextBoxColumn.Name = "aBALPHDataGridViewTextBoxColumn";
            this.aBALPHDataGridViewTextBoxColumn.ReadOnly = true;
            this.aBALPHDataGridViewTextBoxColumn.Width = 300;
            // 
            // DeliveryTermoboxMoovingHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 472);
            this.Controls.Add(this.dgvTermoboxMoovingHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DeliveryTermoboxMoovingHistory";
            this.Text = "История движения термобокса";
            this.Controls.SetChildIndex(this.dgvTermoboxMoovingHistory, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermoboxMoovingHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.termoboxMoovingHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTermoboxMoovingHistory;
        private System.Windows.Forms.BindingSource termoboxMoovingHistoryBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.TermoboxMoovingHistoryTableAdapter termoboxMoovingHistoryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMDocsIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateINDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBALPHDataGridViewTextBoxColumn;
    }
}