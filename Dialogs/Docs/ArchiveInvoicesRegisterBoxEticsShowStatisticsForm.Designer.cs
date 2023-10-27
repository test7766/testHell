namespace WMSOffice.Dialogs.Docs
{
    partial class ArchiveInvoicesRegisterBoxEticsShowStatisticsForm
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
            this.pnlFullContent = new System.Windows.Forms.Panel();
            this.tbAcceptBox = new WMSOffice.Controls.TextBoxScaner();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblAcceptBox = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvBoxEticsStatistics = new System.Windows.Forms.DataGridView();
            this.wH = new WMSOffice.Data.WH();
            this.rGBoxEticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rG_BoxEticsTableAdapter = new WMSOffice.Data.WHTableAdapters.RG_BoxEticsTableAdapter();
            this.warehouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityBoxesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityBoxesReturnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlFullContent.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoxEticsStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGBoxEticsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(217, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(307, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 232);
            this.pnlButtons.Size = new System.Drawing.Size(394, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // pnlFullContent
            // 
            this.pnlFullContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFullContent.Controls.Add(this.pnlContent);
            this.pnlFullContent.Controls.Add(this.pnlOptions);
            this.pnlFullContent.Location = new System.Drawing.Point(0, 0);
            this.pnlFullContent.Name = "pnlFullContent";
            this.pnlFullContent.Size = new System.Drawing.Size(394, 226);
            this.pnlFullContent.TabIndex = 0;
            // 
            // tbAcceptBox
            // 
            this.tbAcceptBox.AllowType = true;
            this.tbAcceptBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAcceptBox.AutoConvert = true;
            this.tbAcceptBox.DelayThreshold = 50;
            this.tbAcceptBox.Location = new System.Drawing.Point(67, 5);
            this.tbAcceptBox.Name = "tbAcceptBox";
            this.tbAcceptBox.RaiseTextChangeWithoutEnter = false;
            this.tbAcceptBox.ReadOnly = false;
            this.tbAcceptBox.ScannerListener = null;
            this.tbAcceptBox.Size = new System.Drawing.Size(315, 25);
            this.tbAcceptBox.TabIndex = 1;
            this.tbAcceptBox.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbAcceptBox.UseParentFont = false;
            this.tbAcceptBox.UseScanModeOnly = false;
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.SystemColors.Info;
            this.pnlOptions.Controls.Add(this.lblAcceptBox);
            this.pnlOptions.Controls.Add(this.tbAcceptBox);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(394, 36);
            this.pnlOptions.TabIndex = 0;
            // 
            // lblAcceptBox
            // 
            this.lblAcceptBox.AutoSize = true;
            this.lblAcceptBox.Location = new System.Drawing.Point(5, 5);
            this.lblAcceptBox.Name = "lblAcceptBox";
            this.lblAcceptBox.Size = new System.Drawing.Size(56, 26);
            this.lblAcceptBox.TabIndex = 0;
            this.lblAcceptBox.Text = "Прийняти\r\nкоробку:";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvBoxEticsStatistics);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 36);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(394, 190);
            this.pnlContent.TabIndex = 1;
            // 
            // dgvBoxEticsStatistics
            // 
            this.dgvBoxEticsStatistics.AllowUserToAddRows = false;
            this.dgvBoxEticsStatistics.AllowUserToDeleteRows = false;
            this.dgvBoxEticsStatistics.AllowUserToResizeRows = false;
            this.dgvBoxEticsStatistics.AutoGenerateColumns = false;
            this.dgvBoxEticsStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoxEticsStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.warehouseDataGridViewTextBoxColumn,
            this.quantityBoxesDataGridViewTextBoxColumn,
            this.quantityBoxesReturnDataGridViewTextBoxColumn});
            this.dgvBoxEticsStatistics.DataSource = this.rGBoxEticsBindingSource;
            this.dgvBoxEticsStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoxEticsStatistics.Location = new System.Drawing.Point(0, 0);
            this.dgvBoxEticsStatistics.MultiSelect = false;
            this.dgvBoxEticsStatistics.Name = "dgvBoxEticsStatistics";
            this.dgvBoxEticsStatistics.ReadOnly = true;
            this.dgvBoxEticsStatistics.RowHeadersVisible = false;
            this.dgvBoxEticsStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBoxEticsStatistics.Size = new System.Drawing.Size(394, 190);
            this.dgvBoxEticsStatistics.TabIndex = 0;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rGBoxEticsBindingSource
            // 
            this.rGBoxEticsBindingSource.DataMember = "RG_BoxEtics";
            this.rGBoxEticsBindingSource.DataSource = this.wH;
            // 
            // rG_BoxEticsTableAdapter
            // 
            this.rG_BoxEticsTableAdapter.ClearBeforeFill = true;
            // 
            // warehouseDataGridViewTextBoxColumn
            // 
            this.warehouseDataGridViewTextBoxColumn.DataPropertyName = "Warehouse";
            this.warehouseDataGridViewTextBoxColumn.HeaderText = "Філіал";
            this.warehouseDataGridViewTextBoxColumn.Name = "warehouseDataGridViewTextBoxColumn";
            this.warehouseDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseDataGridViewTextBoxColumn.Width = 220;
            // 
            // quantityBoxesDataGridViewTextBoxColumn
            // 
            this.quantityBoxesDataGridViewTextBoxColumn.DataPropertyName = "QuantityBoxes";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.quantityBoxesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.quantityBoxesDataGridViewTextBoxColumn.HeaderText = "Всього коробок";
            this.quantityBoxesDataGridViewTextBoxColumn.Name = "quantityBoxesDataGridViewTextBoxColumn";
            this.quantityBoxesDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityBoxesDataGridViewTextBoxColumn.Width = 75;
            // 
            // quantityBoxesReturnDataGridViewTextBoxColumn
            // 
            this.quantityBoxesReturnDataGridViewTextBoxColumn.DataPropertyName = "QuantityBoxesReturn";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.quantityBoxesReturnDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.quantityBoxesReturnDataGridViewTextBoxColumn.HeaderText = "Прийнятих коробок";
            this.quantityBoxesReturnDataGridViewTextBoxColumn.Name = "quantityBoxesReturnDataGridViewTextBoxColumn";
            this.quantityBoxesReturnDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityBoxesReturnDataGridViewTextBoxColumn.Width = 75;
            // 
            // ArchiveInvoicesRegisterBoxEticsShowStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 275);
            this.Controls.Add(this.pnlFullContent);
            this.Name = "ArchiveInvoicesRegisterBoxEticsShowStatisticsForm";
            this.Text = "Реєстр коробок";
            this.Controls.SetChildIndex(this.pnlFullContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlFullContent.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoxEticsStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGBoxEticsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFullContent;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblAcceptBox;
        private WMSOffice.Controls.TextBoxScaner tbAcceptBox;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvBoxEticsStatistics;
        private System.Windows.Forms.BindingSource rGBoxEticsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.RG_BoxEticsTableAdapter rG_BoxEticsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityBoxesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityBoxesReturnDataGridViewTextBoxColumn;
    }
}