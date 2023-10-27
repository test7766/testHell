namespace WMSOffice.Dialogs.Containers
{
    partial class ZonesDirectoryForm
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
            this.dgvPlacements = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zone = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPlacements = new System.Windows.Forms.BindingSource(this.components);
            this.containers = new WMSOffice.Data.Containers();
            this.btnClose = new System.Windows.Forms.Button();
            this.taPlacements = new WMSOffice.Data.ContainersTableAdapters.PlacementsTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlacements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlacements
            // 
            this.dgvPlacements.AllowUserToResizeRows = false;
            this.dgvPlacements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlacements.AutoGenerateColumns = false;
            this.dgvPlacements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlacements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.region,
            this.zone,
            this.floor,
            this.dept,
            this.cab});
            this.dgvPlacements.DataSource = this.bsPlacements;
            this.dgvPlacements.Location = new System.Drawing.Point(12, 12);
            this.dgvPlacements.MultiSelect = false;
            this.dgvPlacements.Name = "dgvPlacements";
            this.dgvPlacements.Size = new System.Drawing.Size(694, 301);
            this.dgvPlacements.TabIndex = 0;
            this.dgvPlacements.VirtualMode = true;
            this.dgvPlacements.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPlacements_UserDeletingRow);
            this.dgvPlacements.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlacements_RowEnter);
            this.dgvPlacements.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPlacements_RowValidating);
            // 
            // id
            // 
            this.id.DataPropertyName = "placement_id";
            this.id.HeaderText = "placement_id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // region
            // 
            this.region.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.region.DataPropertyName = "region";
            this.region.HeaderText = "Филиал";
            this.region.Name = "region";
            this.region.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.region.Width = 150;
            // 
            // zone
            // 
            this.zone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.zone.DataPropertyName = "zone";
            this.zone.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.zone.HeaderText = "Зона";
            this.zone.Items.AddRange(new object[] {
            "Офис",
            "Склад"});
            this.zone.Name = "zone";
            this.zone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.zone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.zone.Width = 70;
            // 
            // floor
            // 
            this.floor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.floor.DataPropertyName = "floor";
            this.floor.HeaderText = "Этаж";
            this.floor.Name = "floor";
            this.floor.Width = 60;
            // 
            // dept
            // 
            this.dept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dept.DataPropertyName = "department";
            this.dept.HeaderText = "Отдел";
            this.dept.Name = "dept";
            this.dept.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dept.Width = 200;
            // 
            // cab
            // 
            this.cab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cab.DataPropertyName = "cabinet";
            this.cab.HeaderText = "Кабинет";
            this.cab.Name = "cab";
            this.cab.Width = 70;
            // 
            // bsPlacements
            // 
            this.bsPlacements.DataMember = "Placements";
            this.bsPlacements.DataSource = this.containers;
            // 
            // containers
            // 
            this.containers.DataSetName = "Containers";
            this.containers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(631, 329);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // taPlacements
            // 
            this.taPlacements.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "placement_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "placement_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "floor";
            this.dataGridViewTextBoxColumn2.HeaderText = "Этаж";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn1.DataPropertyName = "region";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dataGridViewComboBoxColumn1.HeaderText = "Филиал";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cabinet";
            this.dataGridViewTextBoxColumn3.HeaderText = "Кабинет";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "department";
            this.dataGridViewTextBoxColumn4.HeaderText = "Отдел";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "cabinet";
            this.dataGridViewTextBoxColumn5.HeaderText = "Кабинет";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn2.DataPropertyName = "zone";
            this.dataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn2.HeaderText = "Зона";
            this.dataGridViewComboBoxColumn2.Items.AddRange(new object[] {
            "Офис",
            "Склад"});
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn3.DataPropertyName = "department";
            this.dataGridViewComboBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn3.HeaderText = "Отдел";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ZonesDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(718, 364);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPlacements);
            this.Name = "ZonesDirectoryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник площадок печати";
            this.Load += new System.EventHandler(this.ZonesDirectoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlacements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlacements;
        private System.Windows.Forms.Button btnClose;
        private WMSOffice.Data.Containers containers;
        private System.Windows.Forms.BindingSource bsPlacements;
        private WMSOffice.Data.ContainersTableAdapters.PlacementsTableAdapter taPlacements;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn region;
        private System.Windows.Forms.DataGridViewComboBoxColumn zone;
        private System.Windows.Forms.DataGridViewTextBoxColumn floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn cab;
    }
}