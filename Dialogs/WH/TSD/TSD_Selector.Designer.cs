namespace WMSOffice.Dialogs.WH.TSD
{
    partial class TSD_Selector
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
            this.dgvSelector = new System.Windows.Forms.DataGridView();
            this.tSD = new WMSOffice.Data.TSD();
            this.selectedTerminalsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectedTerminalsTableAdapter = new WMSOffice.Data.TSDTableAdapters.SelectedTerminalsTableAdapter();
            this.terminalidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedTerminalsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(307, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(397, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(484, 43);
            // 
            // dgvSelector
            // 
            this.dgvSelector.AllowUserToAddRows = false;
            this.dgvSelector.AllowUserToDeleteRows = false;
            this.dgvSelector.AllowUserToResizeRows = false;
            this.dgvSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelector.AutoGenerateColumns = false;
            this.dgvSelector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.terminalidDataGridViewTextBoxColumn,
            this.terminalnameDataGridViewTextBoxColumn,
            this.employeeidDataGridViewTextBoxColumn,
            this.employeenameDataGridViewTextBoxColumn});
            this.dgvSelector.DataSource = this.selectedTerminalsBindingSource;
            this.dgvSelector.Location = new System.Drawing.Point(0, 2);
            this.dgvSelector.MultiSelect = false;
            this.dgvSelector.Name = "dgvSelector";
            this.dgvSelector.ReadOnly = true;
            this.dgvSelector.RowHeadersVisible = false;
            this.dgvSelector.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelector.Size = new System.Drawing.Size(484, 215);
            this.dgvSelector.TabIndex = 101;
            this.dgvSelector.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelector_CellDoubleClick);
            // 
            // tSD
            // 
            this.tSD.DataSetName = "TSD";
            this.tSD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // selectedTerminalsBindingSource
            // 
            this.selectedTerminalsBindingSource.DataMember = "SelectedTerminals";
            this.selectedTerminalsBindingSource.DataSource = this.tSD;
            // 
            // selectedTerminalsTableAdapter
            // 
            this.selectedTerminalsTableAdapter.ClearBeforeFill = true;
            // 
            // terminalidDataGridViewTextBoxColumn
            // 
            this.terminalidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.terminalidDataGridViewTextBoxColumn.DataPropertyName = "terminal_id";
            this.terminalidDataGridViewTextBoxColumn.HeaderText = "№ ТСД";
            this.terminalidDataGridViewTextBoxColumn.Name = "terminalidDataGridViewTextBoxColumn";
            this.terminalidDataGridViewTextBoxColumn.ReadOnly = true;
            this.terminalidDataGridViewTextBoxColumn.Width = 69;
            // 
            // terminalnameDataGridViewTextBoxColumn
            // 
            this.terminalnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.terminalnameDataGridViewTextBoxColumn.DataPropertyName = "terminal_name";
            this.terminalnameDataGridViewTextBoxColumn.HeaderText = "Описание ТСД";
            this.terminalnameDataGridViewTextBoxColumn.Name = "terminalnameDataGridViewTextBoxColumn";
            this.terminalnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.terminalnameDataGridViewTextBoxColumn.Width = 99;
            // 
            // employeeidDataGridViewTextBoxColumn
            // 
            this.employeeidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeidDataGridViewTextBoxColumn.DataPropertyName = "employee_id";
            this.employeeidDataGridViewTextBoxColumn.HeaderText = "Код сотрудника";
            this.employeeidDataGridViewTextBoxColumn.Name = "employeeidDataGridViewTextBoxColumn";
            this.employeeidDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeidDataGridViewTextBoxColumn.Width = 103;
            // 
            // employeenameDataGridViewTextBoxColumn
            // 
            this.employeenameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeenameDataGridViewTextBoxColumn.DataPropertyName = "employee_name";
            this.employeenameDataGridViewTextBoxColumn.HeaderText = "ФИО сотрудника";
            this.employeenameDataGridViewTextBoxColumn.Name = "employeenameDataGridViewTextBoxColumn";
            this.employeenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeenameDataGridViewTextBoxColumn.Width = 110;
            // 
            // TSD_Selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.dgvSelector);
            this.Name = "TSD_Selector";
            this.Text = "Выберите ТСД для назначения задания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TSD_Selector_FormClosing);
            this.Controls.SetChildIndex(this.dgvSelector, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedTerminalsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelector;
        private System.Windows.Forms.BindingSource selectedTerminalsBindingSource;
        private WMSOffice.Data.TSD tSD;
        private WMSOffice.Data.TSDTableAdapters.SelectedTerminalsTableAdapter selectedTerminalsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeenameDataGridViewTextBoxColumn;

    }
}