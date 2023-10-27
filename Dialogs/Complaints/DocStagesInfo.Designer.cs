namespace WMSOffice.Dialogs.Complaints
{
    partial class DocStagesInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocStagesInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.gbEmployees = new System.Windows.Forms.GroupBox();
            this.dgvStages = new System.Windows.Forms.DataGridView();
            this.docStagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.btnMoveToPreviousLevelStages = new System.Windows.Forms.Button();
            this.docStagesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.DocStagesTableAdapter();
            this.cmsStages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAcceptComplaintFromStage = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStageResultID = new System.Windows.Forms.DataGridViewImageColumn();
            this.stageTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stageResultNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docStagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.cmsStages.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "delete2.png");
            this.imageList.Images.SetKeyName(1, "ok.png");
            this.imageList.Images.SetKeyName(2, "unknown.png");
            this.imageList.Images.SetKeyName(3, "yellow_triangle.png");
            // 
            // gbEmployees
            // 
            this.gbEmployees.Controls.Add(this.dgvStages);
            this.gbEmployees.Controls.Add(this.btnMoveToPreviousLevelStages);
            this.gbEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEmployees.Location = new System.Drawing.Point(0, 0);
            this.gbEmployees.Name = "gbEmployees";
            this.gbEmployees.Size = new System.Drawing.Size(784, 142);
            this.gbEmployees.TabIndex = 4;
            this.gbEmployees.TabStop = false;
            this.gbEmployees.Text = "Этапы обработки претензии";
            // 
            // dgvStages
            // 
            this.dgvStages.AllowUserToAddRows = false;
            this.dgvStages.AllowUserToDeleteRows = false;
            this.dgvStages.AllowUserToResizeRows = false;
            this.dgvStages.AutoGenerateColumns = false;
            this.dgvStages.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvStages.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvStages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStages.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvStages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcStageResultID,
            this.stageTypeNameDataGridViewTextBoxColumn,
            this.groupNameDataGridViewTextBoxColumn,
            this.stageResultNameDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.usersUpdatedDataGridViewTextBoxColumn,
            this.dateUpdatedDataGridViewTextBoxColumn});
            this.dgvStages.ContextMenuStrip = this.cmsStages;
            this.dgvStages.DataSource = this.docStagesBindingSource;
            this.dgvStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStages.Location = new System.Drawing.Point(3, 16);
            this.dgvStages.MultiSelect = false;
            this.dgvStages.Name = "dgvStages";
            this.dgvStages.ReadOnly = true;
            this.dgvStages.RowHeadersVisible = false;
            this.dgvStages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStages.Size = new System.Drawing.Size(778, 123);
            this.dgvStages.TabIndex = 4;
            this.dgvStages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvStages_MouseDoubleClick);
            this.dgvStages.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStages_CellFormatting);
            this.dgvStages.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStages_DataBindingComplete);
            // 
            // docStagesBindingSource
            // 
            this.docStagesBindingSource.DataMember = "DocStages";
            this.docStagesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnMoveToPreviousLevelStages
            // 
            this.btnMoveToPreviousLevelStages.Image = global::WMSOffice.Properties.Resources.chevron_left;
            this.btnMoveToPreviousLevelStages.Location = new System.Drawing.Point(156, -1);
            this.btnMoveToPreviousLevelStages.Name = "btnMoveToPreviousLevelStages";
            this.btnMoveToPreviousLevelStages.Size = new System.Drawing.Size(18, 18);
            this.btnMoveToPreviousLevelStages.TabIndex = 3;
            this.btnMoveToPreviousLevelStages.UseVisualStyleBackColor = true;
            this.btnMoveToPreviousLevelStages.Click += new System.EventHandler(this.btnMoveToPreviousLevelStages_Click);
            // 
            // docStagesTableAdapter
            // 
            this.docStagesTableAdapter.ClearBeforeFill = true;
            // 
            // cmsStages
            // 
            this.cmsStages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAcceptComplaintFromStage});
            this.cmsStages.Name = "cmsStages";
            this.cmsStages.Size = new System.Drawing.Size(122, 26);
            this.cmsStages.Opening += new System.ComponentModel.CancelEventHandler(this.cmsStages_Opening);
            // 
            // cmsiAcceptComplaintFromStage
            // 
            this.cmsiAcceptComplaintFromStage.Image = global::WMSOffice.Properties.Resources.accept_16;
            this.cmsiAcceptComplaintFromStage.Name = "cmsiAcceptComplaintFromStage";
            this.cmsiAcceptComplaintFromStage.Size = new System.Drawing.Size(121, 22);
            this.cmsiAcceptComplaintFromStage.Text = "Принять";
            this.cmsiAcceptComplaintFromStage.Click += new System.EventHandler(this.cmsiAcceptComplaintFromStage_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Stage_Type_Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Этап";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Group_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Группа пользователей";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Stage_Result_Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Результат";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Comment";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Комментарий";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 222;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Expiration_Date";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата просрочки";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Users_Updated";
            this.dataGridViewTextBoxColumn6.HeaderText = "Сотрудники";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 250;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Date_Updated";
            this.dataGridViewTextBoxColumn7.HeaderText = "Дата изм.";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dgvcStageResultID
            // 
            this.dgvcStageResultID.HeaderText = "";
            this.dgvcStageResultID.Name = "dgvcStageResultID";
            this.dgvcStageResultID.ReadOnly = true;
            this.dgvcStageResultID.Width = 25;
            // 
            // stageTypeNameDataGridViewTextBoxColumn
            // 
            this.stageTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Stage_Type_Name";
            this.stageTypeNameDataGridViewTextBoxColumn.HeaderText = "Этап";
            this.stageTypeNameDataGridViewTextBoxColumn.Name = "stageTypeNameDataGridViewTextBoxColumn";
            this.stageTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.stageTypeNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stageTypeNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "Group_Name";
            this.groupNameDataGridViewTextBoxColumn.HeaderText = "Группа пользователей";
            this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
            this.groupNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.groupNameDataGridViewTextBoxColumn.Width = 170;
            // 
            // stageResultNameDataGridViewTextBoxColumn
            // 
            this.stageResultNameDataGridViewTextBoxColumn.DataPropertyName = "Stage_Result_Name";
            this.stageResultNameDataGridViewTextBoxColumn.HeaderText = "Результат";
            this.stageResultNameDataGridViewTextBoxColumn.Name = "stageResultNameDataGridViewTextBoxColumn";
            this.stageResultNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.stageResultNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stageResultNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.commentDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.commentDataGridViewTextBoxColumn.HeaderText = "Комментарий";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.commentDataGridViewTextBoxColumn.Width = 222;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "Expiration_Date";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "Дата просрочки";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expirationDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.expirationDateDataGridViewTextBoxColumn.Width = 120;
            // 
            // usersUpdatedDataGridViewTextBoxColumn
            // 
            this.usersUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Users_Updated";
            this.usersUpdatedDataGridViewTextBoxColumn.HeaderText = "Сотрудники";
            this.usersUpdatedDataGridViewTextBoxColumn.Name = "usersUpdatedDataGridViewTextBoxColumn";
            this.usersUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.usersUpdatedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usersUpdatedDataGridViewTextBoxColumn.Width = 250;
            // 
            // dateUpdatedDataGridViewTextBoxColumn
            // 
            this.dateUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Updated";
            this.dateUpdatedDataGridViewTextBoxColumn.HeaderText = "Дата изм.";
            this.dateUpdatedDataGridViewTextBoxColumn.Name = "dateUpdatedDataGridViewTextBoxColumn";
            this.dateUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateUpdatedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dateUpdatedDataGridViewTextBoxColumn.Width = 120;
            // 
            // DocStagesInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbEmployees);
            this.Name = "DocStagesInfo";
            this.Size = new System.Drawing.Size(784, 142);
            this.gbEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docStagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.cmsStages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox gbEmployees;
        private System.Windows.Forms.Button btnMoveToPreviousLevelStages;
        private System.Windows.Forms.DataGridView dgvStages;
        private System.Windows.Forms.BindingSource docStagesBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.DocStagesTableAdapter docStagesTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn dgvcStageResultID;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageResultNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ContextMenuStrip cmsStages;
        private System.Windows.Forms.ToolStripMenuItem cmsiAcceptComplaintFromStage;
    }
}
