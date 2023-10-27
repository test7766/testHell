namespace WMSOffice.Dialogs.Quality
{
    partial class QualitySpecificMedicinesListItemsEditorForm
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
            this.lblOrderDescription = new System.Windows.Forms.Label();
            this.lblOrderDateFrom = new System.Windows.Forms.Label();
            this.dtpOrderDateFrom = new System.Windows.Forms.DateTimePicker();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.tbOrderDescription = new System.Windows.Forms.TextBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.existsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.atcCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aTCNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEndReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nLListDetailItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.nL_ListDetailItemsTableAdapter = new WMSOffice.Data.QualityTableAdapters.NL_ListDetailItemsTableAdapter();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tbItemsFilter = new System.Windows.Forms.TextBox();
            this.lblItemsFilter = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLListDetailItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2091, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2181, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 728);
            this.pnlButtons.Size = new System.Drawing.Size(1309, 43);
            this.pnlButtons.TabIndex = 3;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlHeader.Controls.Add(this.lblOrderDescription);
            this.pnlHeader.Controls.Add(this.lblOrderDateFrom);
            this.pnlHeader.Controls.Add(this.dtpOrderDateFrom);
            this.pnlHeader.Controls.Add(this.tbOrderNumber);
            this.pnlHeader.Controls.Add(this.tbOrderDescription);
            this.pnlHeader.Controls.Add(this.lblOrderNumber);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1309, 65);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblOrderDescription
            // 
            this.lblOrderDescription.AutoSize = true;
            this.lblOrderDescription.Location = new System.Drawing.Point(209, 12);
            this.lblOrderDescription.Name = "lblOrderDescription";
            this.lblOrderDescription.Size = new System.Drawing.Size(60, 13);
            this.lblOrderDescription.TabIndex = 4;
            this.lblOrderDescription.Text = "Описание:";
            // 
            // lblOrderDateFrom
            // 
            this.lblOrderDateFrom.AutoSize = true;
            this.lblOrderDateFrom.Location = new System.Drawing.Point(33, 41);
            this.lblOrderDateFrom.Name = "lblOrderDateFrom";
            this.lblOrderDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblOrderDateFrom.TabIndex = 2;
            this.lblOrderDateFrom.Text = "Дата с:";
            // 
            // dtpOrderDateFrom
            // 
            this.dtpOrderDateFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpOrderDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDateFrom.Location = new System.Drawing.Point(84, 37);
            this.dtpOrderDateFrom.Name = "dtpOrderDateFrom";
            this.dtpOrderDateFrom.Size = new System.Drawing.Size(95, 20);
            this.dtpOrderDateFrom.TabIndex = 3;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(84, 8);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(95, 20);
            this.tbOrderNumber.TabIndex = 1;
            // 
            // tbOrderDescription
            // 
            this.tbOrderDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOrderDescription.Location = new System.Drawing.Point(275, 8);
            this.tbOrderDescription.Multiline = true;
            this.tbOrderDescription.Name = "tbOrderDescription";
            this.tbOrderDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOrderDescription.Size = new System.Drawing.Size(1022, 49);
            this.tbOrderDescription.TabIndex = 5;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 12);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(66, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "№ приказа:";
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
            this.existsDataGridViewCheckBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.ReleaseForm,
            this.Dosage,
            this.atcCodeDataGridViewTextBoxColumn,
            this.aTCNameDataGridViewTextBoxColumn,
            this.manufacturerIDDataGridViewTextBoxColumn,
            this.manufacturerNameDataGridViewTextBoxColumn,
            this.NoReg,
            this.DateEndReg});
            this.dgvItems.DataSource = this.nLListDetailItemsBindingSource;
            this.dgvItems.Location = new System.Drawing.Point(0, 99);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1309, 623);
            this.dgvItems.TabIndex = 2;
            this.dgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValueChanged);
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            this.dgvItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvItems_CurrentCellDirtyStateChanged);
            // 
            // existsDataGridViewCheckBoxColumn
            // 
            this.existsDataGridViewCheckBoxColumn.DataPropertyName = "Exists";
            this.existsDataGridViewCheckBoxColumn.HeaderText = "Отм.";
            this.existsDataGridViewCheckBoxColumn.Name = "existsDataGridViewCheckBoxColumn";
            this.existsDataGridViewCheckBoxColumn.Width = 35;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.ToolTipText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Торговое название";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // ReleaseForm
            // 
            this.ReleaseForm.DataPropertyName = "ReleaseForm";
            this.ReleaseForm.HeaderText = "Форма выпуска";
            this.ReleaseForm.Name = "ReleaseForm";
            this.ReleaseForm.ReadOnly = true;
            this.ReleaseForm.Width = 120;
            // 
            // Dosage
            // 
            this.Dosage.DataPropertyName = "Dosage";
            this.Dosage.HeaderText = "Дозировка";
            this.Dosage.Name = "Dosage";
            this.Dosage.ReadOnly = true;
            this.Dosage.Width = 80;
            // 
            // atcCodeDataGridViewTextBoxColumn
            // 
            this.atcCodeDataGridViewTextBoxColumn.DataPropertyName = "AtcCode";
            this.atcCodeDataGridViewTextBoxColumn.HeaderText = "Код АТX";
            this.atcCodeDataGridViewTextBoxColumn.Name = "atcCodeDataGridViewTextBoxColumn";
            this.atcCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.atcCodeDataGridViewTextBoxColumn.ToolTipText = "Код АТX";
            // 
            // aTCNameDataGridViewTextBoxColumn
            // 
            this.aTCNameDataGridViewTextBoxColumn.DataPropertyName = "ATCName";
            this.aTCNameDataGridViewTextBoxColumn.HeaderText = "Международное название";
            this.aTCNameDataGridViewTextBoxColumn.Name = "aTCNameDataGridViewTextBoxColumn";
            this.aTCNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.aTCNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // manufacturerIDDataGridViewTextBoxColumn
            // 
            this.manufacturerIDDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerID";
            this.manufacturerIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.manufacturerIDDataGridViewTextBoxColumn.Name = "manufacturerIDDataGridViewTextBoxColumn";
            this.manufacturerIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerIDDataGridViewTextBoxColumn.ToolTipText = "Код производителя";
            this.manufacturerIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // manufacturerNameDataGridViewTextBoxColumn
            // 
            this.manufacturerNameDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerName";
            this.manufacturerNameDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerNameDataGridViewTextBoxColumn.Name = "manufacturerNameDataGridViewTextBoxColumn";
            this.manufacturerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // NoReg
            // 
            this.NoReg.DataPropertyName = "NoReg";
            this.NoReg.HeaderText = "Номер рег. удостоверения (РУ)";
            this.NoReg.Name = "NoReg";
            this.NoReg.ReadOnly = true;
            this.NoReg.ToolTipText = "Номер регистрационного удостоверения (РУ)";
            this.NoReg.Width = 130;
            // 
            // DateEndReg
            // 
            this.DateEndReg.DataPropertyName = "DateEndReg";
            this.DateEndReg.HeaderText = "Дата окончания срока РУ";
            this.DateEndReg.Name = "DateEndReg";
            this.DateEndReg.ReadOnly = true;
            this.DateEndReg.Width = 115;
            // 
            // nLListDetailItemsBindingSource
            // 
            this.nLListDetailItemsBindingSource.DataMember = "NL_ListDetailItems";
            this.nLListDetailItemsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nL_ListDetailItemsTableAdapter
            // 
            this.nL_ListDetailItemsTableAdapter.ClearBeforeFill = true;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlFilter.Controls.Add(this.tbItemsFilter);
            this.pnlFilter.Controls.Add(this.lblItemsFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 65);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1309, 35);
            this.pnlFilter.TabIndex = 1;
            // 
            // tbItemsFilter
            // 
            this.tbItemsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbItemsFilter.Location = new System.Drawing.Point(84, 8);
            this.tbItemsFilter.Name = "tbItemsFilter";
            this.tbItemsFilter.Size = new System.Drawing.Size(1213, 20);
            this.tbItemsFilter.TabIndex = 1;
            this.tbItemsFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemsFilter_KeyDown);
            // 
            // lblItemsFilter
            // 
            this.lblItemsFilter.AutoSize = true;
            this.lblItemsFilter.Location = new System.Drawing.Point(12, 11);
            this.lblItemsFilter.Name = "lblItemsFilter";
            this.lblItemsFilter.Size = new System.Drawing.Size(41, 13);
            this.lblItemsFilter.TabIndex = 0;
            this.lblItemsFilter.Text = "Товар:";
            // 
            // QualitySpecificMedicinesListItemsEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 771);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.pnlHeader);
            this.Name = "QualitySpecificMedicinesListItemsEditorForm";
            this.Text = "Редактор приказа";
            this.Load += new System.EventHandler(this.QualitySpecificMedicinesListItemsEditorForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualitySpecificMedicinesListItemsEditorForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.dgvItems, 0);
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLListDetailItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource nLListDetailItemsBindingSource;
        private Data.Quality quality;
        private Data.QualityTableAdapters.NL_ListDetailItemsTableAdapter nL_ListDetailItemsTableAdapter;
        private System.Windows.Forms.TextBox tbOrderDescription;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.DateTimePicker dtpOrderDateFrom;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox tbItemsFilter;
        private System.Windows.Forms.Label lblItemsFilter;
        private System.Windows.Forms.Label lblOrderDateFrom;
        private System.Windows.Forms.Label lblOrderDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn existsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn atcCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aTCNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateEndReg;
    }
}