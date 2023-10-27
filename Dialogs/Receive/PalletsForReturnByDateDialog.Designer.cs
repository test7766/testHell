namespace WMSOffice.Dialogs.Receive
{
    partial class PalletsForReturnByDateDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPalletsForReturn = new System.Windows.Forms.DataGridView();
            this.typeDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.palletsForReturnByDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.palletsForReturnByDateTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.PalletsForReturnByDateTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTotalPalletsForReturn = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbLoaders = new System.Windows.Forms.GroupBox();
            this.dgvLoaders = new System.Windows.Forms.DataGridView();
            this.optionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadersForPalletsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbsLoaders = new WMSOffice.Controls.TextBoxScaner();
            this.loadersForPalletsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.LoadersForPalletsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalletsForReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palletsForReturnByDateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.gbLoaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadersForPalletsBindingSource)).BeginInit();
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
            this.pnlButtons.Location = new System.Drawing.Point(0, 413);
            this.pnlButtons.Size = new System.Drawing.Size(417, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // dgvPalletsForReturn
            // 
            this.dgvPalletsForReturn.AllowUserToAddRows = false;
            this.dgvPalletsForReturn.AllowUserToDeleteRows = false;
            this.dgvPalletsForReturn.AllowUserToResizeColumns = false;
            this.dgvPalletsForReturn.AllowUserToResizeRows = false;
            this.dgvPalletsForReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPalletsForReturn.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPalletsForReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPalletsForReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalletsForReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeDescDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn});
            this.dgvPalletsForReturn.DataSource = this.palletsForReturnByDateBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPalletsForReturn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPalletsForReturn.Location = new System.Drawing.Point(16, 4);
            this.dgvPalletsForReturn.MultiSelect = false;
            this.dgvPalletsForReturn.Name = "dgvPalletsForReturn";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPalletsForReturn.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPalletsForReturn.RowHeadersVisible = false;
            this.dgvPalletsForReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPalletsForReturn.Size = new System.Drawing.Size(384, 158);
            this.dgvPalletsForReturn.TabIndex = 0;
            this.dgvPalletsForReturn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPalletsForReturn_CellValueChanged);
            this.dgvPalletsForReturn.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPalletsForReturn_CellFormatting);
            this.dgvPalletsForReturn.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPalletsForReturn_DataError);
            this.dgvPalletsForReturn.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPalletsForReturn_DataBindingComplete);
            // 
            // typeDescDataGridViewTextBoxColumn
            // 
            this.typeDescDataGridViewTextBoxColumn.DataPropertyName = "Type_Desc";
            this.typeDescDataGridViewTextBoxColumn.HeaderText = "Тип паллеты";
            this.typeDescDataGridViewTextBoxColumn.Name = "typeDescDataGridViewTextBoxColumn";
            this.typeDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDescDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.typeDescDataGridViewTextBoxColumn.Width = 150;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Возврат, шт.";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.qtyDataGridViewTextBoxColumn.Width = 115;
            // 
            // palletsForReturnByDateBindingSource
            // 
            this.palletsForReturnByDateBindingSource.DataMember = "PalletsForReturnByDate";
            this.palletsForReturnByDateBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // palletsForReturnByDateTableAdapter
            // 
            this.palletsForReturnByDateTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(227, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ИТОГО";
            // 
            // tbTotalPalletsForReturn
            // 
            this.tbTotalPalletsForReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalPalletsForReturn.BackColor = System.Drawing.SystemColors.Window;
            this.tbTotalPalletsForReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTotalPalletsForReturn.Location = new System.Drawing.Point(289, 168);
            this.tbTotalPalletsForReturn.Name = "tbTotalPalletsForReturn";
            this.tbTotalPalletsForReturn.ReadOnly = true;
            this.tbTotalPalletsForReturn.Size = new System.Drawing.Size(111, 22);
            this.tbTotalPalletsForReturn.TabIndex = 2;
            this.tbTotalPalletsForReturn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Type_Desc";
            this.dataGridViewTextBoxColumn1.HeaderText = "Тип паллеты";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Qty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Возврат, шт.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 115;
            // 
            // gbLoaders
            // 
            this.gbLoaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLoaders.Controls.Add(this.dgvLoaders);
            this.gbLoaders.Controls.Add(this.tbsLoaders);
            this.gbLoaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbLoaders.Location = new System.Drawing.Point(4, 199);
            this.gbLoaders.Name = "gbLoaders";
            this.gbLoaders.Size = new System.Drawing.Size(401, 212);
            this.gbLoaders.TabIndex = 3;
            this.gbLoaders.TabStop = false;
            this.gbLoaders.Text = "Грузчики";
            // 
            // dgvLoaders
            // 
            this.dgvLoaders.AllowUserToAddRows = false;
            this.dgvLoaders.AllowUserToDeleteRows = false;
            this.dgvLoaders.AllowUserToResizeRows = false;
            this.dgvLoaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoaders.AutoGenerateColumns = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoaders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLoaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionDataGridViewCheckBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.TotalQty});
            this.dgvLoaders.DataSource = this.loadersForPalletsBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoaders.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLoaders.Location = new System.Drawing.Point(12, 59);
            this.dgvLoaders.MultiSelect = false;
            this.dgvLoaders.Name = "dgvLoaders";
            this.dgvLoaders.RowHeadersVisible = false;
            this.dgvLoaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaders.Size = new System.Drawing.Size(384, 147);
            this.dgvLoaders.TabIndex = 1;
            this.dgvLoaders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLoaders_CellFormatting);
            this.dgvLoaders.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvLoaders_EditingControlShowing);
            this.dgvLoaders.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLoaders_CurrentCellDirtyStateChanged);
            this.dgvLoaders.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvLoaders_DataError);
            this.dgvLoaders.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaders_CellEnter);
            // 
            // optionDataGridViewCheckBoxColumn
            // 
            this.optionDataGridViewCheckBoxColumn.DataPropertyName = "Option";
            this.optionDataGridViewCheckBoxColumn.HeaderText = "Отм.";
            this.optionDataGridViewCheckBoxColumn.Name = "optionDataGridViewCheckBoxColumn";
            this.optionDataGridViewCheckBoxColumn.Width = 35;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.FillWeight = 73F;
            this.userNameDataGridViewTextBoxColumn.HeaderText = "Ф.И.О.";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 255;
            // 
            // TotalQty
            // 
            this.TotalQty.DataPropertyName = "TotalQty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N0";
            this.TotalQty.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalQty.HeaderText = "Σ к-во";
            this.TotalQty.Name = "TotalQty";
            this.TotalQty.Width = 65;
            // 
            // loadersForPalletsBindingSource
            // 
            this.loadersForPalletsBindingSource.DataMember = "LoadersForPallets";
            this.loadersForPalletsBindingSource.DataSource = this.receive;
            // 
            // tbsLoaders
            // 
            this.tbsLoaders.AllowType = true;
            this.tbsLoaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsLoaders.AutoConvert = true;
            this.tbsLoaders.DelayThreshold = 50;
            this.tbsLoaders.Location = new System.Drawing.Point(8, 22);
            this.tbsLoaders.Margin = new System.Windows.Forms.Padding(4);
            this.tbsLoaders.Name = "tbsLoaders";
            this.tbsLoaders.RaiseTextChangeWithoutEnter = false;
            this.tbsLoaders.ReadOnly = false;
            this.tbsLoaders.Size = new System.Drawing.Size(388, 30);
            this.tbsLoaders.TabIndex = 0;
            this.tbsLoaders.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsLoaders.UseParentFont = true;
            this.tbsLoaders.UseScanModeOnly = false;
            // 
            // loadersForPalletsTableAdapter
            // 
            this.loadersForPalletsTableAdapter.ClearBeforeFill = true;
            // 
            // PalletsForReturnByDateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 456);
            this.Controls.Add(this.gbLoaders);
            this.Controls.Add(this.dgvPalletsForReturn);
            this.Controls.Add(this.tbTotalPalletsForReturn);
            this.Controls.Add(this.label1);
            this.Name = "PalletsForReturnByDateDialog";
            this.Text = "Возврат паллет поставщику";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PalletsForReturnByDateDialog_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbTotalPalletsForReturn, 0);
            this.Controls.SetChildIndex(this.dgvPalletsForReturn, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.gbLoaders, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalletsForReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palletsForReturnByDateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.gbLoaders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadersForPalletsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPalletsForReturn;
        private System.Windows.Forms.BindingSource palletsForReturnByDateBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.PalletsForReturnByDateTableAdapter palletsForReturnByDateTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTotalPalletsForReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox gbLoaders;
        private System.Windows.Forms.DataGridView dgvLoaders;
        private System.Windows.Forms.DataGridViewCheckBoxColumn optionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalQty;
        private System.Windows.Forms.BindingSource loadersForPalletsBindingSource;
        private WMSOffice.Controls.TextBoxScaner tbsLoaders;
        private WMSOffice.Data.ReceiveTableAdapters.LoadersForPalletsTableAdapter loadersForPalletsTableAdapter;
    }
}