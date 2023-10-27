namespace WMSOffice.Dialogs.WH
{
    partial class NaklSummaryDetailsForm
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
            this.dgDetails = new System.Windows.Forms.DataGridView();
            this.rowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountWithoutVATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountVATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountWithVATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSpIGetNaclSummaryDetail = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.btnClose = new System.Windows.Forms.Button();
            this.tApI_GetNaclSummary_Detail = new WMSOffice.Data.WHTableAdapters.PI_GetNaclSummary_DetailTableAdapter();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblWithoutPDV = new System.Windows.Forms.Label();
            this.tbxSumWithoutPDV = new System.Windows.Forms.TextBox();
            this.tbxPdvSum = new System.Windows.Forms.TextBox();
            this.lblPdvSum = new System.Windows.Forms.Label();
            this.tbxSumWithPDV = new System.Windows.Forms.TextBox();
            this.lblSumWithPDV = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSpIGetNaclSummaryDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDetails
            // 
            this.dgDetails.AllowUserToAddRows = false;
            this.dgDetails.AllowUserToDeleteRows = false;
            this.dgDetails.AllowUserToResizeRows = false;
            this.dgDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetails.AutoGenerateColumns = false;
            this.dgDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowDataGridViewTextBoxColumn,
            this.docNumberDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.deliveryPointDataGridViewTextBoxColumn,
            this.amountWithoutVATDataGridViewTextBoxColumn,
            this.amountVATDataGridViewTextBoxColumn,
            this.amountWithVATDataGridViewTextBoxColumn});
            this.dgDetails.DataSource = this.bSpIGetNaclSummaryDetail;
            this.dgDetails.Location = new System.Drawing.Point(12, 12);
            this.dgDetails.Name = "dgDetails";
            this.dgDetails.ReadOnly = true;
            this.dgDetails.RowHeadersVisible = false;
            this.dgDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetails.ShowCellErrors = false;
            this.dgDetails.ShowEditingIcon = false;
            this.dgDetails.ShowRowErrors = false;
            this.dgDetails.Size = new System.Drawing.Size(950, 294);
            this.dgDetails.TabIndex = 0;
            // 
            // rowDataGridViewTextBoxColumn
            // 
            this.rowDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rowDataGridViewTextBoxColumn.DataPropertyName = "Row";
            this.rowDataGridViewTextBoxColumn.HeaderText = "№";
            this.rowDataGridViewTextBoxColumn.Name = "rowDataGridViewTextBoxColumn";
            this.rowDataGridViewTextBoxColumn.ReadOnly = true;
            this.rowDataGridViewTextBoxColumn.Width = 43;
            // 
            // docNumberDataGridViewTextBoxColumn
            // 
            this.docNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docNumberDataGridViewTextBoxColumn.DataPropertyName = "DocNumber";
            this.docNumberDataGridViewTextBoxColumn.HeaderText = "Номер расходной";
            this.docNumberDataGridViewTextBoxColumn.Name = "docNumberDataGridViewTextBoxColumn";
            this.docNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.docNumberDataGridViewTextBoxColumn.Width = 112;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "DocType";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип расходной";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeDataGridViewTextBoxColumn.Width = 98;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Дата расходной";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 105;
            // 
            // deliveryPointDataGridViewTextBoxColumn
            // 
            this.deliveryPointDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deliveryPointDataGridViewTextBoxColumn.DataPropertyName = "DeliveryPoint";
            this.deliveryPointDataGridViewTextBoxColumn.HeaderText = "Адрес доставки";
            this.deliveryPointDataGridViewTextBoxColumn.Name = "deliveryPointDataGridViewTextBoxColumn";
            this.deliveryPointDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryPointDataGridViewTextBoxColumn.Width = 104;
            // 
            // amountWithoutVATDataGridViewTextBoxColumn
            // 
            this.amountWithoutVATDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountWithoutVATDataGridViewTextBoxColumn.DataPropertyName = "AmountWithoutVAT";
            this.amountWithoutVATDataGridViewTextBoxColumn.HeaderText = "Сумма без ПДВ";
            this.amountWithoutVATDataGridViewTextBoxColumn.Name = "amountWithoutVATDataGridViewTextBoxColumn";
            this.amountWithoutVATDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountWithoutVATDataGridViewTextBoxColumn.Width = 83;
            // 
            // amountVATDataGridViewTextBoxColumn
            // 
            this.amountVATDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountVATDataGridViewTextBoxColumn.DataPropertyName = "AmountVAT";
            this.amountVATDataGridViewTextBoxColumn.HeaderText = "Сумма ПДВ";
            this.amountVATDataGridViewTextBoxColumn.Name = "amountVATDataGridViewTextBoxColumn";
            this.amountVATDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountVATDataGridViewTextBoxColumn.Width = 86;
            // 
            // amountWithVATDataGridViewTextBoxColumn
            // 
            this.amountWithVATDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountWithVATDataGridViewTextBoxColumn.DataPropertyName = "AmountWithVAT";
            this.amountWithVATDataGridViewTextBoxColumn.HeaderText = "Сумма с ПДВ";
            this.amountWithVATDataGridViewTextBoxColumn.Name = "amountWithVATDataGridViewTextBoxColumn";
            this.amountWithVATDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountWithVATDataGridViewTextBoxColumn.Width = 72;
            // 
            // bSpIGetNaclSummaryDetail
            // 
            this.bSpIGetNaclSummaryDetail.DataMember = "PI_GetNaclSummary_Detail";
            this.bSpIGetNaclSummaryDetail.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(865, 369);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 39);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tApI_GetNaclSummary_Detail
            // 
            this.tApI_GetNaclSummary_Detail.ClearBeforeFill = true;
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblSummary.Location = new System.Drawing.Point(8, 311);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(69, 24);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "Итоги:";
            // 
            // lblWithoutPDV
            // 
            this.lblWithoutPDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWithoutPDV.AutoSize = true;
            this.lblWithoutPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblWithoutPDV.Location = new System.Drawing.Point(123, 311);
            this.lblWithoutPDV.Name = "lblWithoutPDV";
            this.lblWithoutPDV.Size = new System.Drawing.Size(154, 24);
            this.lblWithoutPDV.TabIndex = 3;
            this.lblWithoutPDV.Text = "Сумма без ПДВ:";
            // 
            // tbxSumWithoutPDV
            // 
            this.tbxSumWithoutPDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxSumWithoutPDV.Enabled = false;
            this.tbxSumWithoutPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbxSumWithoutPDV.Location = new System.Drawing.Point(283, 311);
            this.tbxSumWithoutPDV.Name = "tbxSumWithoutPDV";
            this.tbxSumWithoutPDV.Size = new System.Drawing.Size(115, 26);
            this.tbxSumWithoutPDV.TabIndex = 4;
            // 
            // tbxPdvSum
            // 
            this.tbxPdvSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxPdvSum.Enabled = false;
            this.tbxPdvSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbxPdvSum.Location = new System.Drawing.Point(549, 311);
            this.tbxPdvSum.Name = "tbxPdvSum";
            this.tbxPdvSum.Size = new System.Drawing.Size(119, 26);
            this.tbxPdvSum.TabIndex = 6;
            // 
            // lblPdvSum
            // 
            this.lblPdvSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPdvSum.AutoSize = true;
            this.lblPdvSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblPdvSum.Location = new System.Drawing.Point(426, 311);
            this.lblPdvSum.Name = "lblPdvSum";
            this.lblPdvSum.Size = new System.Drawing.Size(117, 24);
            this.lblPdvSum.TabIndex = 5;
            this.lblPdvSum.Text = "Сумма ПДВ:";
            // 
            // tbxSumWithPDV
            // 
            this.tbxSumWithPDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxSumWithPDV.Enabled = false;
            this.tbxSumWithPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbxSumWithPDV.Location = new System.Drawing.Point(824, 311);
            this.tbxSumWithPDV.Name = "tbxSumWithPDV";
            this.tbxSumWithPDV.Size = new System.Drawing.Size(111, 26);
            this.tbxSumWithPDV.TabIndex = 8;
            // 
            // lblSumWithPDV
            // 
            this.lblSumWithPDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSumWithPDV.AutoSize = true;
            this.lblSumWithPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblSumWithPDV.Location = new System.Drawing.Point(686, 311);
            this.lblSumWithPDV.Name = "lblSumWithPDV";
            this.lblSumWithPDV.Size = new System.Drawing.Size(132, 24);
            this.lblSumWithPDV.TabIndex = 7;
            this.lblSumWithPDV.Text = "Сумма c ПДВ:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Row";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DocNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "Номер расходной";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DocType";
            this.dataGridViewTextBoxColumn3.HeaderText = "Тип расходной";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn4.HeaderText = "Дата расходной";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DeliveryPoint";
            this.dataGridViewTextBoxColumn5.HeaderText = "Адрес доставки";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "AmountWithoutVAT";
            this.dataGridViewTextBoxColumn6.HeaderText = "Сумма без ПДВ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "AmountVAT";
            this.dataGridViewTextBoxColumn7.HeaderText = "Сумма ПДВ";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "AmountWithVAT";
            this.dataGridViewTextBoxColumn8.HeaderText = "Сумма с ПДВ";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // NaklSummaryDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(974, 420);
            this.Controls.Add(this.tbxSumWithPDV);
            this.Controls.Add(this.lblSumWithPDV);
            this.Controls.Add(this.tbxPdvSum);
            this.Controls.Add(this.lblPdvSum);
            this.Controls.Add(this.tbxSumWithoutPDV);
            this.Controls.Add(this.lblWithoutPDV);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgDetails);
            this.Name = "NaklSummaryDetailsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Список расходных по накладной";
            this.Load += new System.EventHandler(this.NaklSummaryDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSpIGetNaclSummaryDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bSpIGetNaclSummaryDetail;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.PI_GetNaclSummary_DetailTableAdapter tApI_GetNaclSummary_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryPointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountWithoutVATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountVATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountWithVATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblWithoutPDV;
        private System.Windows.Forms.TextBox tbxSumWithoutPDV;
        private System.Windows.Forms.TextBox tbxPdvSum;
        private System.Windows.Forms.Label lblPdvSum;
        private System.Windows.Forms.TextBox tbxSumWithPDV;
        private System.Windows.Forms.Label lblSumWithPDV;
    }
}