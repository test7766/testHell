namespace WMSOffice.Dialogs.WO
{
    partial class AddAssingmentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxTSD = new System.Windows.Forms.GroupBox();
            this.gvTSD = new System.Windows.Forms.DataGridView();
            this.chbShowOnlyFree = new System.Windows.Forms.CheckBox();
            this.wO = new WMSOffice.Data.WO();
            this.terminalsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.terminalsTableAdapter = new WMSOffice.Data.WOTableAdapters.TerminalsTableAdapter();
            this.colChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.terminalIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUserCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUserNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countActiveAssigDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxTSD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTSD
            // 
            this.groupBoxTSD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTSD.Controls.Add(this.gvTSD);
            this.groupBoxTSD.Controls.Add(this.chbShowOnlyFree);
            this.groupBoxTSD.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTSD.Name = "groupBoxTSD";
            this.groupBoxTSD.Size = new System.Drawing.Size(530, 201);
            this.groupBoxTSD.TabIndex = 1;
            this.groupBoxTSD.TabStop = false;
            this.groupBoxTSD.Text = "Терминалы сбора данных:";
            // 
            // gvTSD
            // 
            this.gvTSD.AllowUserToAddRows = false;
            this.gvTSD.AllowUserToDeleteRows = false;
            this.gvTSD.AllowUserToResizeRows = false;
            this.gvTSD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvTSD.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTSD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvTSD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTSD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChecked,
            this.terminalIDDataGridViewTextBoxColumn,
            this.terminalNameDataGridViewTextBoxColumn,
            this.terminalGroupDataGridViewTextBoxColumn,
            this.lastUserCodeDataGridViewTextBoxColumn,
            this.lastUserNameDataGridViewTextBoxColumn,
            this.countActiveAssigDataGridViewTextBoxColumn});
            this.gvTSD.DataSource = this.terminalsBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTSD.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvTSD.Location = new System.Drawing.Point(6, 19);
            this.gvTSD.Name = "gvTSD";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTSD.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvTSD.RowHeadersVisible = false;
            this.gvTSD.Size = new System.Drawing.Size(518, 153);
            this.gvTSD.TabIndex = 0;
            // 
            // chbShowOnlyFree
            // 
            this.chbShowOnlyFree.AutoSize = true;
            this.chbShowOnlyFree.Checked = true;
            this.chbShowOnlyFree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowOnlyFree.Location = new System.Drawing.Point(6, 178);
            this.chbShowOnlyFree.Name = "chbShowOnlyFree";
            this.chbShowOnlyFree.Size = new System.Drawing.Size(198, 17);
            this.chbShowOnlyFree.TabIndex = 1;
            this.chbShowOnlyFree.Text = "Показать только свободные ТСД";
            // 
            // wO
            // 
            this.wO.DataSetName = "WO";
            this.wO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // terminalsBindingSource
            // 
            this.terminalsBindingSource.DataMember = "Terminals";
            this.terminalsBindingSource.DataSource = this.wO;
            // 
            // terminalsTableAdapter
            // 
            this.terminalsTableAdapter.ClearBeforeFill = true;
            // 
            // colChecked
            // 
            this.colChecked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colChecked.HeaderText = "Выб.";
            this.colChecked.Name = "colChecked";
            this.colChecked.Width = 37;
            // 
            // terminalIDDataGridViewTextBoxColumn
            // 
            this.terminalIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.terminalIDDataGridViewTextBoxColumn.DataPropertyName = "Terminal_ID";
            this.terminalIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.terminalIDDataGridViewTextBoxColumn.Name = "terminalIDDataGridViewTextBoxColumn";
            this.terminalIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.terminalIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // terminalNameDataGridViewTextBoxColumn
            // 
            this.terminalNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.terminalNameDataGridViewTextBoxColumn.DataPropertyName = "Terminal_Name";
            this.terminalNameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.terminalNameDataGridViewTextBoxColumn.Name = "terminalNameDataGridViewTextBoxColumn";
            this.terminalNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.terminalNameDataGridViewTextBoxColumn.Width = 82;
            // 
            // terminalGroupDataGridViewTextBoxColumn
            // 
            this.terminalGroupDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.terminalGroupDataGridViewTextBoxColumn.DataPropertyName = "Terminal_Group";
            this.terminalGroupDataGridViewTextBoxColumn.HeaderText = "Группа";
            this.terminalGroupDataGridViewTextBoxColumn.Name = "terminalGroupDataGridViewTextBoxColumn";
            this.terminalGroupDataGridViewTextBoxColumn.ReadOnly = true;
            this.terminalGroupDataGridViewTextBoxColumn.Width = 67;
            // 
            // lastUserCodeDataGridViewTextBoxColumn
            // 
            this.lastUserCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lastUserCodeDataGridViewTextBoxColumn.DataPropertyName = "LastUserCode";
            this.lastUserCodeDataGridViewTextBoxColumn.HeaderText = "Код";
            this.lastUserCodeDataGridViewTextBoxColumn.Name = "lastUserCodeDataGridViewTextBoxColumn";
            this.lastUserCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUserCodeDataGridViewTextBoxColumn.Width = 51;
            // 
            // lastUserNameDataGridViewTextBoxColumn
            // 
            this.lastUserNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lastUserNameDataGridViewTextBoxColumn.DataPropertyName = "LastUserName";
            this.lastUserNameDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.lastUserNameDataGridViewTextBoxColumn.Name = "lastUserNameDataGridViewTextBoxColumn";
            this.lastUserNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUserNameDataGridViewTextBoxColumn.Width = 85;
            // 
            // countActiveAssigDataGridViewTextBoxColumn
            // 
            this.countActiveAssigDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.countActiveAssigDataGridViewTextBoxColumn.DataPropertyName = "CountActiveAssig";
            this.countActiveAssigDataGridViewTextBoxColumn.HeaderText = "Заданий";
            this.countActiveAssigDataGridViewTextBoxColumn.Name = "countActiveAssigDataGridViewTextBoxColumn";
            this.countActiveAssigDataGridViewTextBoxColumn.ReadOnly = true;
            this.countActiveAssigDataGridViewTextBoxColumn.Width = 75;
            // 
            // AddAssingmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 262);
            this.Controls.Add(this.groupBoxTSD);
            this.Name = "AddAssingmentForm";
            this.Text = "Новое  назначение";
            this.Load += new System.EventHandler(this.AddAssingmentForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddAssingmentForm_FormClosing);
            this.Controls.SetChildIndex(this.groupBoxTSD, 0);
            this.groupBoxTSD.ResumeLayout(false);
            this.groupBoxTSD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTSD;
        private System.Windows.Forms.CheckBox chbShowOnlyFree;
        private System.Windows.Forms.DataGridView gvTSD;
        private System.Windows.Forms.BindingSource terminalsBindingSource;
        private WMSOffice.Data.WO wO;
        private WMSOffice.Data.WOTableAdapters.TerminalsTableAdapter terminalsTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUserCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUserNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countActiveAssigDataGridViewTextBoxColumn;
    }
}