namespace WMSOffice.Dialogs.Admin
{
    partial class UpgradeControlAdminForm
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
            this.pnlOperations = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.upgradeVersionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.admin = new WMSOffice.Data.Admin();
            this.upgradeVersionsTableAdapter = new WMSOffice.Data.AdminTableAdapters.UpgradeVersionsTableAdapter();
            this.dgvVersions = new System.Windows.Forms.DataGridView();
            this.versionNumberDataGridViewTextBoxColumn = new WMSOffice.Controls.DataGridButtonEditorColumn();
            this.versionDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upgradeVersionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersions)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOperations
            // 
            this.pnlOperations.Controls.Add(this.btnCancel);
            this.pnlOperations.Controls.Add(this.btnSave);
            this.pnlOperations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOperations.Location = new System.Drawing.Point(0, 572);
            this.pnlOperations.Name = "pnlOperations";
            this.pnlOperations.Size = new System.Drawing.Size(984, 40);
            this.pnlOperations.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(897, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(816, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // upgradeVersionsBindingSource
            // 
            this.upgradeVersionsBindingSource.DataMember = "UpgradeVersions";
            this.upgradeVersionsBindingSource.DataSource = this.admin;
            // 
            // admin
            // 
            this.admin.DataSetName = "Admin";
            this.admin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // upgradeVersionsTableAdapter
            // 
            this.upgradeVersionsTableAdapter.ClearBeforeFill = true;
            // 
            // dgvVersions
            // 
            this.dgvVersions.AllowUserToDeleteRows = false;
            this.dgvVersions.AllowUserToResizeRows = false;
            this.dgvVersions.AutoGenerateColumns = false;
            this.dgvVersions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVersions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.versionNumberDataGridViewTextBoxColumn,
            this.versionDescriptionDataGridViewTextBoxColumn,
            this.dateUpdatedDataGridViewTextBoxColumn,
            this.userUpdatedDataGridViewTextBoxColumn});
            this.dgvVersions.DataSource = this.upgradeVersionsBindingSource;
            this.dgvVersions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVersions.Location = new System.Drawing.Point(0, 0);
            this.dgvVersions.MultiSelect = false;
            this.dgvVersions.Name = "dgvVersions";
            this.dgvVersions.RowHeadersWidth = 25;
            this.dgvVersions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVersions.Size = new System.Drawing.Size(984, 572);
            this.dgvVersions.TabIndex = 1;
            this.dgvVersions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVersions_CellFormatting);
            this.dgvVersions.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvVersions_EditingControlShowing);
            this.dgvVersions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVersions_DataError);
            // 
            // versionNumberDataGridViewTextBoxColumn
            // 
            this.versionNumberDataGridViewTextBoxColumn.DataPropertyName = "Version_Number";
            this.versionNumberDataGridViewTextBoxColumn.HeaderText = "Версия";
            this.versionNumberDataGridViewTextBoxColumn.Name = "versionNumberDataGridViewTextBoxColumn";
            this.versionNumberDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.versionNumberDataGridViewTextBoxColumn.Width = 120;
            // 
            // versionDescriptionDataGridViewTextBoxColumn
            // 
            this.versionDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Version_Description";
            this.versionDescriptionDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.versionDescriptionDataGridViewTextBoxColumn.Name = "versionDescriptionDataGridViewTextBoxColumn";
            this.versionDescriptionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.versionDescriptionDataGridViewTextBoxColumn.Width = 500;
            // 
            // dateUpdatedDataGridViewTextBoxColumn
            // 
            this.dateUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Updated";
            this.dateUpdatedDataGridViewTextBoxColumn.HeaderText = "Изменено когда";
            this.dateUpdatedDataGridViewTextBoxColumn.Name = "dateUpdatedDataGridViewTextBoxColumn";
            this.dateUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateUpdatedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dateUpdatedDataGridViewTextBoxColumn.Width = 120;
            // 
            // userUpdatedDataGridViewTextBoxColumn
            // 
            this.userUpdatedDataGridViewTextBoxColumn.DataPropertyName = "User_Updated";
            this.userUpdatedDataGridViewTextBoxColumn.HeaderText = "Изменено кем";
            this.userUpdatedDataGridViewTextBoxColumn.Name = "userUpdatedDataGridViewTextBoxColumn";
            this.userUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.userUpdatedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.userUpdatedDataGridViewTextBoxColumn.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Version_Number";
            this.dataGridViewTextBoxColumn1.HeaderText = "Версия";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Version_Description";
            this.dataGridViewTextBoxColumn2.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 500;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Date_Updated";
            this.dataGridViewTextBoxColumn3.HeaderText = "Изменено когда";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "User_Updated";
            this.dataGridViewTextBoxColumn4.HeaderText = "Изменено кем";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // UpgradeControlAdminForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(984, 612);
            this.Controls.Add(this.dgvVersions);
            this.Controls.Add(this.pnlOperations);
            this.Name = "UpgradeControlAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование контроля версий";
            this.Load += new System.EventHandler(this.UpgradeControlAdminForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpgradeControlAdminForm_FormClosing);
            this.pnlOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.upgradeVersionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOperations;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvVersions;
        private WMSOffice.Data.Admin admin;
        private System.Windows.Forms.BindingSource upgradeVersionsBindingSource;
        private WMSOffice.Data.AdminTableAdapters.UpgradeVersionsTableAdapter upgradeVersionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private WMSOffice.Controls.DataGridButtonEditorColumn versionNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userUpdatedDataGridViewTextBoxColumn;
    }
}