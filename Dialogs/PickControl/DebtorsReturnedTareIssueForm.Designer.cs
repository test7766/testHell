namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareIssueForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.tbsTareBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.tarenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.cT_DocDetailsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.CT_DocDetailsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTDocDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1341, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1431, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 468);
            this.pnlButtons.Size = new System.Drawing.Size(934, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblBarCode);
            this.pnlHeader.Controls.Add(this.tbsTareBarCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(934, 30);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Location = new System.Drawing.Point(12, 9);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(59, 13);
            this.lblBarCode.TabIndex = 0;
            this.lblBarCode.Text = "Ш/К тары:";
            // 
            // tbsTareBarCode
            // 
            this.tbsTareBarCode.AllowType = true;
            this.tbsTareBarCode.AutoConvert = true;
            this.tbsTareBarCode.DelayThreshold = 50;
            this.tbsTareBarCode.Location = new System.Drawing.Point(77, 3);
            this.tbsTareBarCode.Name = "tbsTareBarCode";
            this.tbsTareBarCode.RaiseTextChangeWithoutEnter = false;
            this.tbsTareBarCode.ReadOnly = false;
            this.tbsTareBarCode.Size = new System.Drawing.Size(261, 25);
            this.tbsTareBarCode.TabIndex = 1;
            this.tbsTareBarCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsTareBarCode.UseParentFont = false;
            this.tbsTareBarCode.UseScanModeOnly = false;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tarenameDataGridViewTextBoxColumn,
            this.barCodeDataGridViewTextBoxColumn,
            this.itemidDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.dateUpdatedDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.cTDocDetailsBindingSource;
            this.dgvItems.Location = new System.Drawing.Point(0, 34);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(934, 428);
            this.dgvItems.TabIndex = 1;
            // 
            // tarenameDataGridViewTextBoxColumn
            // 
            this.tarenameDataGridViewTextBoxColumn.DataPropertyName = "Tare_name";
            this.tarenameDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.tarenameDataGridViewTextBoxColumn.Name = "tarenameDataGridViewTextBoxColumn";
            this.tarenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tarenameDataGridViewTextBoxColumn.Width = 300;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 200;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "Item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // dateUpdatedDataGridViewTextBoxColumn
            // 
            this.dateUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Updated";
            this.dateUpdatedDataGridViewTextBoxColumn.HeaderText = "Дата обновления";
            this.dateUpdatedDataGridViewTextBoxColumn.Name = "dateUpdatedDataGridViewTextBoxColumn";
            this.dateUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateUpdatedDataGridViewTextBoxColumn.Width = 150;
            // 
            // cTDocDetailsBindingSource
            // 
            this.cTDocDetailsBindingSource.DataMember = "CT_DocDetails";
            this.cTDocDetailsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cT_DocDetailsTableAdapter
            // 
            this.cT_DocDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // DebtorsReturnedTareIssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvItems);
            this.Name = "DebtorsReturnedTareIssueForm";
            this.Text = "Выдача оборотной тары";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebtorsReturnedTareIssueForm_FormClosing);
            this.Controls.SetChildIndex(this.dgvItems, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTDocDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBarCode;
        private WMSOffice.Controls.TextBoxScaner tbsTareBarCode;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource cTDocDetailsBindingSource;
        private Data.PickControl pickControl;
        private Data.PickControlTableAdapters.CT_DocDetailsTableAdapter cT_DocDetailsTableAdapter;
    }
}