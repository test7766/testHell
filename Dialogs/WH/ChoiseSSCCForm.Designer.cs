namespace WMSOffice.Dialogs.WH
{
    partial class ChoiseSSCCForm
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
            this.dgvSSCC = new System.Windows.Forms.DataGridView();
            this.sSCCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSCCByLocationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.sSCCByLocationTableAdapter = new WMSOffice.Data.WHTableAdapters.SSCCByLocationTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSSCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSCCByLocationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 195);
            // 
            // dgvSSCC
            // 
            this.dgvSSCC.AllowUserToAddRows = false;
            this.dgvSSCC.AllowUserToDeleteRows = false;
            this.dgvSSCC.AllowUserToResizeRows = false;
            this.dgvSSCC.AutoGenerateColumns = false;
            this.dgvSSCC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSSCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSSCC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sSCCDataGridViewTextBoxColumn});
            this.dgvSSCC.DataSource = this.sSCCByLocationBindingSource;
            this.dgvSSCC.Location = new System.Drawing.Point(0, 2);
            this.dgvSSCC.MultiSelect = false;
            this.dgvSSCC.Name = "dgvSSCC";
            this.dgvSSCC.ReadOnly = true;
            this.dgvSSCC.RowHeadersVisible = false;
            this.dgvSSCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSSCC.Size = new System.Drawing.Size(284, 187);
            this.dgvSSCC.TabIndex = 101;
            this.dgvSSCC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSSCC_CellDoubleClick);
            // 
            // sSCCDataGridViewTextBoxColumn
            // 
            this.sSCCDataGridViewTextBoxColumn.DataPropertyName = "SSCC";
            this.sSCCDataGridViewTextBoxColumn.HeaderText = "SSCC";
            this.sSCCDataGridViewTextBoxColumn.Name = "sSCCDataGridViewTextBoxColumn";
            this.sSCCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sSCCDataGridViewTextBoxColumn.Width = 60;
            // 
            // sSCCByLocationBindingSource
            // 
            this.sSCCByLocationBindingSource.DataMember = "SSCCByLocation";
            this.sSCCByLocationBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sSCCByLocationTableAdapter
            // 
            this.sSCCByLocationTableAdapter.ClearBeforeFill = true;
            // 
            // ChoiseSSCCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 238);
            this.Controls.Add(this.dgvSSCC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "ChoiseSSCCForm";
            this.Text = "Выбор SSCC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiseSSCCForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvSSCC, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSSCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSCCByLocationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSSCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSCCDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sSCCByLocationBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.SSCCByLocationTableAdapter sSCCByLocationTableAdapter;
    }
}