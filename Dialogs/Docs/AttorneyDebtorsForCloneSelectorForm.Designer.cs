namespace WMSOffice.Dialogs.Docs
{
    partial class AttorneyDebtorsForCloneSelectorForm
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
            this.dgvSelector = new System.Windows.Forms.DataGridView();
            this.isSelectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.shanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abalphDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active_Attorney_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCDebtorsForCloneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC_Debtors_For_CloneTableAdapter = new WMSOffice.Data.WHTableAdapters.AC_Debtors_For_CloneTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCDebtorsForCloneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2008, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2098, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 728);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
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
            this.isSelectedDataGridViewCheckBoxColumn,
            this.shanDataGridViewTextBoxColumn,
            this.abalphDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.Active_Attorney_Period});
            this.dgvSelector.DataSource = this.aCDebtorsForCloneBindingSource;
            this.dgvSelector.Location = new System.Drawing.Point(0, 1);
            this.dgvSelector.MultiSelect = false;
            this.dgvSelector.Name = "dgvSelector";
            this.dgvSelector.RowHeadersVisible = false;
            this.dgvSelector.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelector.Size = new System.Drawing.Size(994, 724);
            this.dgvSelector.TabIndex = 101;
            this.dgvSelector.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSelector_CellFormatting);
            this.dgvSelector.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSelector_CurrentCellDirtyStateChanged);
            // 
            // isSelectedDataGridViewCheckBoxColumn
            // 
            this.isSelectedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.isSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn.HeaderText = "Отм.";
            this.isSelectedDataGridViewCheckBoxColumn.Name = "isSelectedDataGridViewCheckBoxColumn";
            this.isSelectedDataGridViewCheckBoxColumn.Width = 37;
            // 
            // shanDataGridViewTextBoxColumn
            // 
            this.shanDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.shanDataGridViewTextBoxColumn.DataPropertyName = "Shan";
            this.shanDataGridViewTextBoxColumn.HeaderText = "Код";
            this.shanDataGridViewTextBoxColumn.Name = "shanDataGridViewTextBoxColumn";
            this.shanDataGridViewTextBoxColumn.ReadOnly = true;
            this.shanDataGridViewTextBoxColumn.Width = 51;
            // 
            // abalphDataGridViewTextBoxColumn
            // 
            this.abalphDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.abalphDataGridViewTextBoxColumn.DataPropertyName = "Abalph";
            this.abalphDataGridViewTextBoxColumn.HeaderText = "Наименование дебитора";
            this.abalphDataGridViewTextBoxColumn.Name = "abalphDataGridViewTextBoxColumn";
            this.abalphDataGridViewTextBoxColumn.ReadOnly = true;
            this.abalphDataGridViewTextBoxColumn.Width = 144;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Адрес доставки";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 104;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "Город";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityDataGridViewTextBoxColumn.Width = 62;
            // 
            // Active_Attorney_Period
            // 
            this.Active_Attorney_Period.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Active_Attorney_Period.DataPropertyName = "Active_Attorney_Period";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Active_Attorney_Period.DefaultCellStyle = dataGridViewCellStyle1;
            this.Active_Attorney_Period.HeaderText = "Период действия активной доверенности";
            this.Active_Attorney_Period.Name = "Active_Attorney_Period";
            this.Active_Attorney_Period.ReadOnly = true;
            this.Active_Attorney_Period.Width = 158;
            // 
            // aCDebtorsForCloneBindingSource
            // 
            this.aCDebtorsForCloneBindingSource.DataMember = "AC_Debtors_For_Clone";
            this.aCDebtorsForCloneBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Option";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Отм.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Lot";
            this.dataGridViewTextBoxColumn2.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Desc";
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // aC_Debtors_For_CloneTableAdapter
            // 
            this.aC_Debtors_For_CloneTableAdapter.ClearBeforeFill = true;
            // 
            // AttorneyDebtorsForCloneSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 771);
            this.Controls.Add(this.dgvSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "AttorneyDebtorsForCloneSelectorForm";
            this.Text = "Отметьте необходимые позиции для выбора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintDocItemsSelector_FormClosing);
            this.Controls.SetChildIndex(this.dgvSelector, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCDebtorsForCloneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelector;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource aCDebtorsForCloneBindingSource;
        private Data.WH wH;
        private Data.WHTableAdapters.AC_Debtors_For_CloneTableAdapter aC_Debtors_For_CloneTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn abalphDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active_Attorney_Period;
    }
}