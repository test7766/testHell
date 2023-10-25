namespace WMSOffice.Dialogs.Quality
{
    partial class NumberGMPSertEditorForm
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
            this.dgvGMP = new System.Windows.Forms.DataGridView();
            this.gMPSertBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gMP_SertTableAdapter = new WMSOffice.Data.QualityTableAdapters.GMP_SertTableAdapter();
            this.colItemChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.conclusionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerPlantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conclusionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conclusionDateStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conclusionDateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMPSertBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5969, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(6059, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 329);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
            // 
            // dgvGMP
            // 
            this.dgvGMP.AllowUserToAddRows = false;
            this.dgvGMP.AllowUserToDeleteRows = false;
            this.dgvGMP.AllowUserToResizeColumns = false;
            this.dgvGMP.AllowUserToResizeRows = false;
            this.dgvGMP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGMP.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGMP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGMP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemChecked,
            this.conclusionNameDataGridViewTextBoxColumn,
            this.manufacturerPlantDataGridViewTextBoxColumn,
            this.conclusionDateDataGridViewTextBoxColumn,
            this.conclusionDateStartDataGridViewTextBoxColumn,
            this.conclusionDateEndDataGridViewTextBoxColumn});
            this.dgvGMP.DataSource = this.gMPSertBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGMP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGMP.Location = new System.Drawing.Point(0, 1);
            this.dgvGMP.MultiSelect = false;
            this.dgvGMP.Name = "dgvGMP";
            this.dgvGMP.RowHeadersVisible = false;
            this.dgvGMP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGMP.Size = new System.Drawing.Size(994, 322);
            this.dgvGMP.TabIndex = 101;
            this.dgvGMP.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGMP_CellFormatting);
            this.dgvGMP.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGMP_CurrentCellDirtyStateChanged);
            // 
            // gMPSertBindingSource
            // 
            this.gMPSertBindingSource.DataMember = "GMP_Sert";
            this.gMPSertBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsChecked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Відм.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Conclusion_Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "№ висновку";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ManufacturerPlant";
            this.dataGridViewTextBoxColumn2.HeaderText = "Назва заводу";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ConclusionDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата висновку";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ConclusionDateStart";
            this.dataGridViewTextBoxColumn4.HeaderText = "Дата початку";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ConclusionDateEnd";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата закінчення";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // gMP_SertTableAdapter
            // 
            this.gMP_SertTableAdapter.ClearBeforeFill = true;
            // 
            // colItemChecked
            // 
            this.colItemChecked.DataPropertyName = "IsChecked";
            this.colItemChecked.HeaderText = "Відм.";
            this.colItemChecked.Name = "colItemChecked";
            this.colItemChecked.Width = 40;
            // 
            // conclusionNameDataGridViewTextBoxColumn
            // 
            this.conclusionNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.conclusionNameDataGridViewTextBoxColumn.DataPropertyName = "Conclusion_Name";
            this.conclusionNameDataGridViewTextBoxColumn.HeaderText = "№ висновку";
            this.conclusionNameDataGridViewTextBoxColumn.Name = "conclusionNameDataGridViewTextBoxColumn";
            this.conclusionNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.conclusionNameDataGridViewTextBoxColumn.Width = 119;
            // 
            // manufacturerPlantDataGridViewTextBoxColumn
            // 
            this.manufacturerPlantDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerPlantDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerPlant";
            this.manufacturerPlantDataGridViewTextBoxColumn.HeaderText = "Назва заводу";
            this.manufacturerPlantDataGridViewTextBoxColumn.Name = "manufacturerPlantDataGridViewTextBoxColumn";
            this.manufacturerPlantDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerPlantDataGridViewTextBoxColumn.Width = 137;
            // 
            // conclusionDateDataGridViewTextBoxColumn
            // 
            this.conclusionDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.conclusionDateDataGridViewTextBoxColumn.DataPropertyName = "ConclusionDate";
            this.conclusionDateDataGridViewTextBoxColumn.HeaderText = "Дата висновку";
            this.conclusionDateDataGridViewTextBoxColumn.Name = "conclusionDateDataGridViewTextBoxColumn";
            this.conclusionDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.conclusionDateDataGridViewTextBoxColumn.Width = 135;
            // 
            // conclusionDateStartDataGridViewTextBoxColumn
            // 
            this.conclusionDateStartDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.conclusionDateStartDataGridViewTextBoxColumn.DataPropertyName = "ConclusionDateStart";
            this.conclusionDateStartDataGridViewTextBoxColumn.HeaderText = "Дата початку";
            this.conclusionDateStartDataGridViewTextBoxColumn.Name = "conclusionDateStartDataGridViewTextBoxColumn";
            this.conclusionDateStartDataGridViewTextBoxColumn.ReadOnly = true;
            this.conclusionDateStartDataGridViewTextBoxColumn.Width = 106;
            // 
            // conclusionDateEndDataGridViewTextBoxColumn
            // 
            this.conclusionDateEndDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.conclusionDateEndDataGridViewTextBoxColumn.DataPropertyName = "ConclusionDateEnd";
            this.conclusionDateEndDataGridViewTextBoxColumn.HeaderText = "Дата закінчення";
            this.conclusionDateEndDataGridViewTextBoxColumn.Name = "conclusionDateEndDataGridViewTextBoxColumn";
            this.conclusionDateEndDataGridViewTextBoxColumn.ReadOnly = true;
            this.conclusionDateEndDataGridViewTextBoxColumn.Width = 126;
            // 
            // NumberGMPSertEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 372);
            this.Controls.Add(this.dgvGMP);
            this.Name = "NumberGMPSertEditorForm";
            this.Text = "Коригування GMP";
            this.Load += new System.EventHandler(this.NumberGMPSertEditorForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NumberGMPSertEditorForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvGMP, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMPSertBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGMP;
        private System.Windows.Forms.BindingSource gMPSertBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.GMP_SertTableAdapter gMP_SertTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colItemChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn conclusionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerPlantDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conclusionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conclusionDateStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conclusionDateEndDataGridViewTextBoxColumn;
    }
}