namespace WMSOffice.Dialogs.Complaints
{
    partial class PickReturnCloseDocForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvDocPackItems = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lifeTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docReturnClosePackItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.tbBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.docReturnClosePackItemsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.DocReturnClosePackItemsTableAdapter();
            this.lblProgress = new System.Windows.Forms.LinkLabel();
            this.docReturnCloseDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.docReturnCloseDocsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.DocReturnCloseDocsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocPackItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docReturnClosePackItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docReturnCloseDocsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(705, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(795, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 316);
            this.pnlButtons.Size = new System.Drawing.Size(882, 43);
            this.pnlButtons.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvDocPackItems);
            this.pnlContent.Controls.Add(this.pnlHeader);
            this.pnlContent.Location = new System.Drawing.Point(0, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(882, 306);
            this.pnlContent.TabIndex = 101;
            // 
            // dgvDocPackItems
            // 
            this.dgvDocPackItems.AllowUserToAddRows = false;
            this.dgvDocPackItems.AllowUserToDeleteRows = false;
            this.dgvDocPackItems.AllowUserToResizeRows = false;
            this.dgvDocPackItems.AutoGenerateColumns = false;
            this.dgvDocPackItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocPackItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.batchIDDataGridViewTextBoxColumn,
            this.lifeTimeDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn});
            this.dgvDocPackItems.DataSource = this.docReturnClosePackItemsBindingSource;
            this.dgvDocPackItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocPackItems.Location = new System.Drawing.Point(0, 40);
            this.dgvDocPackItems.MultiSelect = false;
            this.dgvDocPackItems.Name = "dgvDocPackItems";
            this.dgvDocPackItems.ReadOnly = true;
            this.dgvDocPackItems.RowHeadersVisible = false;
            this.dgvDocPackItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocPackItems.Size = new System.Drawing.Size(882, 266);
            this.dgvDocPackItems.TabIndex = 1;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // batchIDDataGridViewTextBoxColumn
            // 
            this.batchIDDataGridViewTextBoxColumn.DataPropertyName = "Batch_ID";
            this.batchIDDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.batchIDDataGridViewTextBoxColumn.Name = "batchIDDataGridViewTextBoxColumn";
            this.batchIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lifeTimeDataGridViewTextBoxColumn
            // 
            this.lifeTimeDataGridViewTextBoxColumn.DataPropertyName = "Life_Time";
            this.lifeTimeDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.lifeTimeDataGridViewTextBoxColumn.Name = "lifeTimeDataGridViewTextBoxColumn";
            this.lifeTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            this.uOMDataGridViewTextBoxColumn.ReadOnly = true;
            this.uOMDataGridViewTextBoxColumn.Width = 50;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "К-во";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 50;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 200;
            // 
            // docReturnClosePackItemsBindingSource
            // 
            this.docReturnClosePackItemsBindingSource.DataMember = "DocReturnClosePackItems";
            this.docReturnClosePackItemsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblProgress);
            this.pnlHeader.Controls.Add(this.lblInstruction);
            this.pnlHeader.Controls.Add(this.lblBarCode);
            this.pnlHeader.Controls.Add(this.tbBarCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(882, 40);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblInstruction
            // 
            this.lblInstruction.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInstruction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInstruction.Location = new System.Drawing.Point(286, 9);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(463, 23);
            this.lblInstruction.TabIndex = 2;
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Location = new System.Drawing.Point(12, 14);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(62, 13);
            this.lblBarCode.TabIndex = 0;
            this.lblBarCode.Text = "Ш/К SSCC:";
            // 
            // tbBarCode
            // 
            this.tbBarCode.AllowType = true;
            this.tbBarCode.AutoConvert = true;
            this.tbBarCode.DelayThreshold = 50;
            this.tbBarCode.Location = new System.Drawing.Point(80, 8);
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.RaiseTextChangeWithoutEnter = false;
            this.tbBarCode.ReadOnly = false;
            this.tbBarCode.ScannerListener = null;
            this.tbBarCode.Size = new System.Drawing.Size(200, 25);
            this.tbBarCode.TabIndex = 1;
            this.tbBarCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarCode.UseParentFont = false;
            this.tbBarCode.UseScanModeOnly = false;
            // 
            // docReturnClosePackItemsTableAdapter
            // 
            this.docReturnClosePackItemsTableAdapter.ClearBeforeFill = true;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(755, 9);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(115, 23);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.TabStop = true;
            this.lblProgress.Text = "Обработано 0 из 0";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // docReturnCloseDocsBindingSource
            // 
            this.docReturnCloseDocsBindingSource.DataMember = "DocReturnCloseDocs";
            this.docReturnCloseDocsBindingSource.DataSource = this.pickControl;
            // 
            // docReturnCloseDocsTableAdapter
            // 
            this.docReturnCloseDocsTableAdapter.ClearBeforeFill = true;
            // 
            // PickReturnCloseDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 359);
            this.Controls.Add(this.pnlContent);
            this.Name = "PickReturnCloseDocForm";
            this.Text = "Форма подтверждения возврата излишков при поштучном контроле товара";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocPackItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docReturnClosePackItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docReturnCloseDocsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBarCode;
        private WMSOffice.Controls.TextBoxScaner tbBarCode;
        private System.Windows.Forms.DataGridView dgvDocPackItems;
        private System.Windows.Forms.BindingSource docReturnClosePackItemsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.DocReturnClosePackItemsTableAdapter docReturnClosePackItemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lifeTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.LinkLabel lblProgress;
        private System.Windows.Forms.BindingSource docReturnCloseDocsBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.DocReturnCloseDocsTableAdapter docReturnCloseDocsTableAdapter;
    }
}