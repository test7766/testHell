namespace WMSOffice.Dialogs.PickControl
{
    partial class MultiPickSlipErrorsForm
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
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.multiPickSlipErrorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.multiPickSlipErrorsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.MultiPickSlipErrorsTableAdapter();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pbError = new System.Windows.Forms.PictureBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.psnidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errormsgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiPickSlipErrorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(861, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(951, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 329);
            this.pnlButtons.Size = new System.Drawing.Size(694, 43);
            // 
            // dgvErrors
            // 
            this.dgvErrors.AllowUserToAddRows = false;
            this.dgvErrors.AllowUserToDeleteRows = false;
            this.dgvErrors.AllowUserToResizeColumns = false;
            this.dgvErrors.AllowUserToResizeRows = false;
            this.dgvErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvErrors.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.psnidDataGridViewTextBoxColumn,
            this.errormsgDataGridViewTextBoxColumn});
            this.dgvErrors.DataSource = this.multiPickSlipErrorsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrors.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvErrors.Location = new System.Drawing.Point(0, 60);
            this.dgvErrors.MultiSelect = false;
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.ReadOnly = true;
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(694, 263);
            this.dgvErrors.TabIndex = 101;
            // 
            // multiPickSlipErrorsBindingSource
            // 
            this.multiPickSlipErrorsBindingSource.DataMember = "MultiPickSlipErrors";
            this.multiPickSlipErrorsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // multiPickSlipErrorsTableAdapter
            // 
            this.multiPickSlipErrorsTableAdapter.ClearBeforeFill = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblErrorMessage);
            this.pnlHeader.Controls.Add(this.pbError);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(694, 60);
            this.pnlHeader.TabIndex = 102;
            // 
            // pbError
            // 
            this.pbError.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.pbError.Location = new System.Drawing.Point(3, 6);
            this.pbError.Name = "pbError";
            this.pbError.Size = new System.Drawing.Size(48, 48);
            this.pbError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbError.TabIndex = 0;
            this.pbError.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrorMessage.Location = new System.Drawing.Point(57, 20);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 20);
            this.lblErrorMessage.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "psn_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер сборочного";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 170;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "error_msg";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ошибка";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 450;
            // 
            // psnidDataGridViewTextBoxColumn
            // 
            this.psnidDataGridViewTextBoxColumn.DataPropertyName = "psn_id";
            this.psnidDataGridViewTextBoxColumn.HeaderText = "Номер сборочного";
            this.psnidDataGridViewTextBoxColumn.Name = "psnidDataGridViewTextBoxColumn";
            this.psnidDataGridViewTextBoxColumn.ReadOnly = true;
            this.psnidDataGridViewTextBoxColumn.Width = 170;
            // 
            // errormsgDataGridViewTextBoxColumn
            // 
            this.errormsgDataGridViewTextBoxColumn.DataPropertyName = "error_msg";
            this.errormsgDataGridViewTextBoxColumn.HeaderText = "Ошибка";
            this.errormsgDataGridViewTextBoxColumn.Name = "errormsgDataGridViewTextBoxColumn";
            this.errormsgDataGridViewTextBoxColumn.ReadOnly = true;
            this.errormsgDataGridViewTextBoxColumn.Width = 450;
            // 
            // MultiPickSlipErrorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 372);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvErrors);
            this.Name = "MultiPickSlipErrorsForm";
            this.Text = "Ошибки работы с документом мультисборки";
            this.Controls.SetChildIndex(this.dgvErrors, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiPickSlipErrorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.BindingSource multiPickSlipErrorsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.MultiPickSlipErrorsTableAdapter multiPickSlipErrorsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn psnidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errormsgDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.PictureBox pbError;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}