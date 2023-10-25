namespace WMSOffice.Dialogs.Quality
{
    partial class QualitySpecificMedicinesListDetailsEditorForm
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
            this.cbGosReg = new System.Windows.Forms.CheckBox();
            this.nLListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.nLListDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nL_ListDetailsTableAdapter = new WMSOffice.Data.QualityTableAdapters.NL_ListDetailsTableAdapter();
            this.nL_ListTableAdapter = new WMSOffice.Data.QualityTableAdapters.NL_ListTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPerelikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSelector = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLListDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4763, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4853, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 553);
            this.pnlButtons.Size = new System.Drawing.Size(819, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.cbGosReg);
            this.pnlHeader.Controls.Add(this.lblPeriodTo);
            this.pnlHeader.Controls.Add(this.dtpPeriodTo);
            this.pnlHeader.Controls.Add(this.lblPeriodFrom);
            this.pnlHeader.Controls.Add(this.dtpPeriodFrom);
            this.pnlHeader.Controls.Add(this.lblName);
            this.pnlHeader.Controls.Add(this.tbName);
            this.pnlHeader.Controls.Add(this.lblCode);
            this.pnlHeader.Controls.Add(this.tbCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(819, 95);
            this.pnlHeader.TabIndex = 0;
            // 
            // cbGosReg
            // 
            this.cbGosReg.AutoSize = true;
            this.cbGosReg.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.nLListBindingSource, "GosRegFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbGosReg.Location = new System.Drawing.Point(219, 38);
            this.cbGosReg.Name = "cbGosReg";
            this.cbGosReg.Size = new System.Drawing.Size(70, 17);
            this.cbGosReg.TabIndex = 8;
            this.cbGosReg.Text = "Гос. рег.";
            this.cbGosReg.UseVisualStyleBackColor = true;
            // 
            // nLListBindingSource
            // 
            this.nLListBindingSource.DataMember = "NL_List";
            this.nLListBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(35, 69);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(51, 13);
            this.lblPeriodTo.TabIndex = 6;
            this.lblPeriodTo.Text = "Дата по:";
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.nLListBindingSource, "DateTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "d"));
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(92, 65);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 7;
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(41, 40);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(45, 13);
            this.lblPeriodFrom.TabIndex = 4;
            this.lblPeriodFrom.Text = "Дата с:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.nLListBindingSource, "DateFrom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "d"));
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(92, 36);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(216, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Наименование перечня:";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nLListBindingSource, "PerelikName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbName.Location = new System.Drawing.Point(352, 7);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(455, 20);
            this.tbName.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(13, 11);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(73, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Код перечня:";
            // 
            // tbCode
            // 
            this.tbCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nLListBindingSource, "PerelikID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbCode.Location = new System.Drawing.Point(92, 7);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(100, 20);
            this.tbCode.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.pnlDetails);
            this.pnlContent.Controls.Add(this.pnlHeader);
            this.pnlContent.Location = new System.Drawing.Point(0, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(819, 545);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.dgvDetails);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 95);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(819, 450);
            this.pnlDetails.TabIndex = 1;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToResizeColumns = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clPerelikID,
            this.clDetailID,
            this.clDescription,
            this.clSelector,
            this.clUserName,
            this.clDateUpdated});
            this.dgvDetails.DataSource = this.nLListDetailsBindingSource;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(819, 450);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellContentClick);
            this.dgvDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellEnter);
            this.dgvDetails.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellLeave);
            this.dgvDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetails_DataBindingComplete);
            this.dgvDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetails_DataError);
            this.dgvDetails.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDetails_DefaultValuesNeeded);
            this.dgvDetails.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDetails_UserDeletingRow);
            // 
            // nLListDetailsBindingSource
            // 
            this.nLListDetailsBindingSource.DataMember = "NL_ListDetails";
            this.nLListDetailsBindingSource.DataSource = this.quality;
            // 
            // nL_ListDetailsTableAdapter
            // 
            this.nL_ListDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // nL_ListTableAdapter
            // 
            this.nL_ListTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PerelikID";
            this.dataGridViewTextBoxColumn1.HeaderText = "PerelikID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DetailID";
            this.dataGridViewTextBoxColumn2.HeaderText = "DetailID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 320;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn1.ToolTipText = "Поиск и привязка медикаментов из справочника";
            this.dataGridViewButtonColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UserName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Изменено кем";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateUpdated";
            this.dataGridViewTextBoxColumn5.HeaderText = "Изменено когда";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // clPerelikID
            // 
            this.clPerelikID.DataPropertyName = "PerelikID";
            this.clPerelikID.HeaderText = "PerelikID";
            this.clPerelikID.Name = "clPerelikID";
            this.clPerelikID.Visible = false;
            // 
            // clDetailID
            // 
            this.clDetailID.DataPropertyName = "DetailID";
            this.clDetailID.HeaderText = "DetailID";
            this.clDetailID.Name = "clDetailID";
            this.clDetailID.Visible = false;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Описание";
            this.clDescription.Name = "clDescription";
            this.clDescription.Width = 320;
            // 
            // clSelector
            // 
            this.clSelector.HeaderText = "";
            this.clSelector.Name = "clSelector";
            this.clSelector.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clSelector.ToolTipText = "Поиск и привязка медикаментов из справочника";
            this.clSelector.Width = 25;
            // 
            // clUserName
            // 
            this.clUserName.DataPropertyName = "UserName";
            this.clUserName.HeaderText = "Изменено кем";
            this.clUserName.Name = "clUserName";
            this.clUserName.ReadOnly = true;
            this.clUserName.Width = 250;
            // 
            // clDateUpdated
            // 
            this.clDateUpdated.DataPropertyName = "DateUpdated";
            this.clDateUpdated.HeaderText = "Изменено когда";
            this.clDateUpdated.Name = "clDateUpdated";
            this.clDateUpdated.ReadOnly = true;
            this.clDateUpdated.Width = 150;
            // 
            // QualitySpecificMedicinesListDetailsEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 596);
            this.Controls.Add(this.pnlContent);
            this.Name = "QualitySpecificMedicinesListDetailsEditorForm";
            this.Text = "Редактор нац. перечня";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualitySpecificMedicinesListDetailsEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.QualitySpecificMedicinesListDetailsEditorForm_Load);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLListDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.CheckBox cbGosReg;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.BindingSource nLListDetailsBindingSource;
        private Data.Quality quality;
        private Data.QualityTableAdapters.NL_ListDetailsTableAdapter nL_ListDetailsTableAdapter;
        private System.Windows.Forms.BindingSource nLListBindingSource;
        private Data.QualityTableAdapters.NL_ListTableAdapter nL_ListTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn clItemsSelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPerelikID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewButtonColumn clSelector;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateUpdated;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}