namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintProcessingDataErrorsForm
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
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ошибкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complaintProcessingDataErrorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.complaintProcessingDataErrorsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.ComplaintProcessingDataErrorsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintProcessingDataErrorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(681, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(771, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(571, 43);
            // 
            // dgvErrors
            // 
            this.dgvErrors.AllowUserToAddRows = false;
            this.dgvErrors.AllowUserToDeleteRows = false;
            this.dgvErrors.AllowUserToOrderColumns = true;
            this.dgvErrors.AllowUserToResizeColumns = false;
            this.dgvErrors.AllowUserToResizeRows = false;
            this.dgvErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvErrors.AutoGenerateColumns = false;
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ошибкаDataGridViewTextBoxColumn});
            this.dgvErrors.DataSource = this.complaintProcessingDataErrorsBindingSource;
            this.dgvErrors.Location = new System.Drawing.Point(0, 2);
            this.dgvErrors.MultiSelect = false;
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.ReadOnly = true;
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(571, 211);
            this.dgvErrors.TabIndex = 101;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "№";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 43;
            // 
            // ошибкаDataGridViewTextBoxColumn
            // 
            this.ошибкаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ошибкаDataGridViewTextBoxColumn.DataPropertyName = "Ошибка";
            this.ошибкаDataGridViewTextBoxColumn.HeaderText = "Ошибка";
            this.ошибкаDataGridViewTextBoxColumn.Name = "ошибкаDataGridViewTextBoxColumn";
            this.ошибкаDataGridViewTextBoxColumn.ReadOnly = true;
            this.ошибкаDataGridViewTextBoxColumn.Width = 72;
            // 
            // complaintProcessingDataErrorsBindingSource
            // 
            this.complaintProcessingDataErrorsBindingSource.DataMember = "ComplaintProcessingDataErrors";
            this.complaintProcessingDataErrorsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // complaintProcessingDataErrorsTableAdapter
            // 
            this.complaintProcessingDataErrorsTableAdapter.ClearBeforeFill = true;
            // 
            // ComplaintProcessingDataErrorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 262);
            this.Controls.Add(this.dgvErrors);
            this.Name = "ComplaintProcessingDataErrorsForm";
            this.Text = "Список ошибок при обработке претензии";
            this.Controls.SetChildIndex(this.dgvErrors, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintProcessingDataErrorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.BindingSource complaintProcessingDataErrorsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.ComplaintProcessingDataErrorsTableAdapter complaintProcessingDataErrorsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ошибкаDataGridViewTextBoxColumn;
    }
}