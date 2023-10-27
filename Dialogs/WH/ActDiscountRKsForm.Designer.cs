namespace WMSOffice.Dialogs.WH
{
    partial class ActDiscountRKsForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvActDetails = new System.Windows.Forms.DataGridView();
            this.cmsRKs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.bsAsGetCalculations = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.taAsGetCalculations = new WMSOffice.Data.WHTableAdapters.AS_Get_CalculationsTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculationNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculationTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculationSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountprcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActDetails)).BeginInit();
            this.cmsRKs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAsGetCalculations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(997, 426);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvActDetails
            // 
            this.dgvActDetails.AllowUserToAddRows = false;
            this.dgvActDetails.AllowUserToDeleteRows = false;
            this.dgvActDetails.AllowUserToResizeRows = false;
            this.dgvActDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActDetails.AutoGenerateColumns = false;
            this.dgvActDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Memo_Number,
            this.calculationNumberDataGridViewTextBoxColumn,
            this.calculationTypeDataGridViewTextBoxColumn,
            this.calculationDateDataGridViewTextBoxColumn,
            this.calculationSumDataGridViewTextBoxColumn,
            this.discountprcDataGridViewTextBoxColumn,
            this.docNumberDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.docSumDataGridViewTextBoxColumn,
            this.Status_ID,
            this.Status});
            this.dgvActDetails.ContextMenuStrip = this.cmsRKs;
            this.dgvActDetails.DataSource = this.bsAsGetCalculations;
            this.dgvActDetails.Location = new System.Drawing.Point(12, 12);
            this.dgvActDetails.Name = "dgvActDetails";
            this.dgvActDetails.ReadOnly = true;
            this.dgvActDetails.RowHeadersVisible = false;
            this.dgvActDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActDetails.Size = new System.Drawing.Size(1060, 408);
            this.dgvActDetails.TabIndex = 1;
            // 
            // cmsRKs
            // 
            this.cmsRKs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPrint});
            this.cmsRKs.Name = "cmsRKs";
            this.cmsRKs.Size = new System.Drawing.Size(284, 26);
            // 
            // miPrint
            // 
            this.miPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miPrint.Name = "miPrint";
            this.miPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.miPrint.Size = new System.Drawing.Size(283, 22);
            this.miPrint.Text = "Печать расчет-корректировки";
            this.miPrint.Click += new System.EventHandler(this.miPrint_Click);
            // 
            // bsAsGetCalculations
            // 
            this.bsAsGetCalculations.DataMember = "AS_Get_Calculations";
            this.bsAsGetCalculations.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taAsGetCalculations
            // 
            this.taAsGetCalculations.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Calculation_Number";
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер РК";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Calculation_Type";
            this.dataGridViewTextBoxColumn2.HeaderText = "Тип РК";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Calculation_Date";
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата РК";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Calculation_Sum";
            this.dataGridViewTextBoxColumn4.HeaderText = "Сума РК";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Discount_prc";
            this.dataGridViewTextBoxColumn5.HeaderText = "Процент скидки";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Doc_Number";
            this.dataGridViewTextBoxColumn6.HeaderText = "№ накладной";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Doc_Type";
            this.dataGridViewTextBoxColumn7.HeaderText = "Тип накладной";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Doc_Date";
            this.dataGridViewTextBoxColumn8.HeaderText = "Дата накладной";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Doc_Sum";
            this.dataGridViewTextBoxColumn9.HeaderText = "Сума накладной";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // Memo_Number
            // 
            this.Memo_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Memo_Number.DataPropertyName = "Memo_Number";
            this.Memo_Number.HeaderText = "Номер РК";
            this.Memo_Number.Name = "Memo_Number";
            this.Memo_Number.ReadOnly = true;
            this.Memo_Number.Width = 83;
            // 
            // calculationNumberDataGridViewTextBoxColumn
            // 
            this.calculationNumberDataGridViewTextBoxColumn.DataPropertyName = "Calculation_Number";
            this.calculationNumberDataGridViewTextBoxColumn.HeaderText = "№ служеб. записки";
            this.calculationNumberDataGridViewTextBoxColumn.Name = "calculationNumberDataGridViewTextBoxColumn";
            this.calculationNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.calculationNumberDataGridViewTextBoxColumn.Width = 70;
            // 
            // calculationTypeDataGridViewTextBoxColumn
            // 
            this.calculationTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.calculationTypeDataGridViewTextBoxColumn.DataPropertyName = "Calculation_Type";
            this.calculationTypeDataGridViewTextBoxColumn.HeaderText = "Тип РК";
            this.calculationTypeDataGridViewTextBoxColumn.Name = "calculationTypeDataGridViewTextBoxColumn";
            this.calculationTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.calculationTypeDataGridViewTextBoxColumn.Width = 51;
            // 
            // calculationDateDataGridViewTextBoxColumn
            // 
            this.calculationDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.calculationDateDataGridViewTextBoxColumn.DataPropertyName = "Calculation_Date";
            this.calculationDateDataGridViewTextBoxColumn.HeaderText = "Дата РК";
            this.calculationDateDataGridViewTextBoxColumn.Name = "calculationDateDataGridViewTextBoxColumn";
            this.calculationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.calculationDateDataGridViewTextBoxColumn.Width = 70;
            // 
            // calculationSumDataGridViewTextBoxColumn
            // 
            this.calculationSumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.calculationSumDataGridViewTextBoxColumn.DataPropertyName = "Calculation_Sum";
            this.calculationSumDataGridViewTextBoxColumn.HeaderText = "Сума РК";
            this.calculationSumDataGridViewTextBoxColumn.Name = "calculationSumDataGridViewTextBoxColumn";
            this.calculationSumDataGridViewTextBoxColumn.ReadOnly = true;
            this.calculationSumDataGridViewTextBoxColumn.Width = 70;
            // 
            // discountprcDataGridViewTextBoxColumn
            // 
            this.discountprcDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.discountprcDataGridViewTextBoxColumn.DataPropertyName = "Discount_prc";
            this.discountprcDataGridViewTextBoxColumn.HeaderText = "Процент скидки";
            this.discountprcDataGridViewTextBoxColumn.Name = "discountprcDataGridViewTextBoxColumn";
            this.discountprcDataGridViewTextBoxColumn.ReadOnly = true;
            this.discountprcDataGridViewTextBoxColumn.Width = 105;
            // 
            // docNumberDataGridViewTextBoxColumn
            // 
            this.docNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docNumberDataGridViewTextBoxColumn.DataPropertyName = "Doc_Number";
            this.docNumberDataGridViewTextBoxColumn.HeaderText = "№ накладной";
            this.docNumberDataGridViewTextBoxColumn.Name = "docNumberDataGridViewTextBoxColumn";
            this.docNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.docNumberDataGridViewTextBoxColumn.Width = 92;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип накладной";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeDataGridViewTextBoxColumn.Width = 99;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата накладной";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Width = 106;
            // 
            // docSumDataGridViewTextBoxColumn
            // 
            this.docSumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docSumDataGridViewTextBoxColumn.DataPropertyName = "Doc_Sum";
            this.docSumDataGridViewTextBoxColumn.HeaderText = "Сума накладной";
            this.docSumDataGridViewTextBoxColumn.Name = "docSumDataGridViewTextBoxColumn";
            this.docSumDataGridViewTextBoxColumn.ReadOnly = true;
            this.docSumDataGridViewTextBoxColumn.Width = 106;
            // 
            // Status_ID
            // 
            this.Status_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status_ID.DataPropertyName = "Status_ID";
            this.Status_ID.HeaderText = "Ст.";
            this.Status_ID.Name = "Status_ID";
            this.Status_ID.ReadOnly = true;
            this.Status_ID.Width = 47;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Статус";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 66;
            // 
            // ActDiscountRKsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1084, 461);
            this.Controls.Add(this.dgvActDetails);
            this.Controls.Add(this.btnClose);
            this.Name = "ActDiscountRKsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Расчет-корректировки для акта скидки";
            this.Load += new System.EventHandler(this.ActDiscountRKsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActDetails)).EndInit();
            this.cmsRKs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAsGetCalculations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvActDetails;
        private System.Windows.Forms.BindingSource bsAsGetCalculations;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.AS_Get_CalculationsTableAdapter taAsGetCalculations;
        private System.Windows.Forms.ContextMenuStrip cmsRKs;
        private System.Windows.Forms.ToolStripMenuItem miPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculationNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculationTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculationSumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountprcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docSumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}