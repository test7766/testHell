namespace WMSOffice.Dialogs.Containers
{
    partial class IpDirectoryForm
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
            this.dgvIps = new System.Windows.Forms.DataGridView();
            this.bsPlacementsForIps = new System.Windows.Forms.BindingSource(this.components);
            this.containers = new WMSOffice.Data.Containers();
            this.bsDocTypesForIps = new System.Windows.Forms.BindingSource(this.components);
            this.bsUsersForIps = new System.Windows.Forms.BindingSource(this.components);
            this.bsIps = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.taIps = new WMSOffice.Data.ContainersTableAdapters.IpsTableAdapter();
            this.taPlacementsForIps = new WMSOffice.Data.ContainersTableAdapters.PlacementsForIpsTableAdapter();
            this.taUsersForIps = new WMSOffice.Data.ContainersTableAdapters.WmsUsersForIpsTableAdapter();
            this.taDocTypesForIps = new WMSOffice.Data.ContainersTableAdapters.DocTypesForIpsTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placement_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.doc_type_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.user_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlacementsForIps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTypesForIps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsersForIps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIps)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIps
            // 
            this.dgvIps.AllowUserToResizeRows = false;
            this.dgvIps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIps.AutoGenerateColumns = false;
            this.dgvIps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ip,
            this.placement_id,
            this.doc_type_id,
            this.user_id});
            this.dgvIps.DataSource = this.bsIps;
            this.dgvIps.Location = new System.Drawing.Point(12, 12);
            this.dgvIps.MultiSelect = false;
            this.dgvIps.Name = "dgvIps";
            this.dgvIps.Size = new System.Drawing.Size(908, 287);
            this.dgvIps.TabIndex = 0;
            this.dgvIps.VirtualMode = true;
            this.dgvIps.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvIps_UserDeletingRow);
            this.dgvIps.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIps_RowEnter);
            this.dgvIps.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvIps_RowValidating);
            // 
            // bsPlacementsForIps
            // 
            this.bsPlacementsForIps.DataMember = "PlacementsForIps";
            this.bsPlacementsForIps.DataSource = this.containers;
            // 
            // containers
            // 
            this.containers.DataSetName = "Containers";
            this.containers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsDocTypesForIps
            // 
            this.bsDocTypesForIps.DataMember = "DocTypesForIps";
            this.bsDocTypesForIps.DataSource = this.containers;
            // 
            // bsUsersForIps
            // 
            this.bsUsersForIps.DataMember = "WmsUsersForIps";
            this.bsUsersForIps.DataSource = this.containers;
            // 
            // bsIps
            // 
            this.bsIps.DataMember = "Ips";
            this.bsIps.DataSource = this.containers;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(845, 305);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // taIps
            // 
            this.taIps.ClearBeforeFill = true;
            // 
            // taPlacementsForIps
            // 
            this.taPlacementsForIps.ClearBeforeFill = true;
            // 
            // taUsersForIps
            // 
            this.taUsersForIps.ClearBeforeFill = true;
            // 
            // taDocTypesForIps
            // 
            this.taDocTypesForIps.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ip_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "ip_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ip";
            this.dataGridViewTextBoxColumn2.HeaderText = "ip";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "placement_id";
            this.dataGridViewComboBoxColumn1.DataSource = this.bsPlacementsForIps;
            this.dataGridViewComboBoxColumn1.DisplayMember = "placement";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn1.HeaderText = "Площадка";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "placement_id";
            this.dataGridViewComboBoxColumn1.Width = 200;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn2.DataPropertyName = "doc_type_id";
            this.dataGridViewComboBoxColumn2.DataSource = this.bsDocTypesForIps;
            this.dataGridViewComboBoxColumn2.DisplayMember = "name";
            this.dataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn2.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn2.HeaderText = "Тип печатаемого документа";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.ReadOnly = true;
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn2.ValueMember = "doc_type_id";
            this.dataGridViewComboBoxColumn2.Width = 160;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.DataPropertyName = "user_id";
            this.dataGridViewComboBoxColumn3.DataSource = this.bsUsersForIps;
            this.dataGridViewComboBoxColumn3.DisplayMember = "User_FIO";
            this.dataGridViewComboBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dataGridViewComboBoxColumn3.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn3.HeaderText = "Ответственный пользователь";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn3.ValueMember = "User_ID";
            this.dataGridViewComboBoxColumn3.Width = 250;
            // 
            // id
            // 
            this.id.DataPropertyName = "ip_id";
            this.id.HeaderText = "ip_id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // ip
            // 
            this.ip.DataPropertyName = "ip";
            this.ip.HeaderText = "IP-адрес";
            this.ip.Name = "ip";
            this.ip.Width = 150;
            // 
            // placement_id
            // 
            this.placement_id.DataPropertyName = "placement_id";
            this.placement_id.DataSource = this.bsPlacementsForIps;
            this.placement_id.DisplayMember = "placement";
            this.placement_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.placement_id.DisplayStyleForCurrentCellOnly = true;
            this.placement_id.HeaderText = "Площадка";
            this.placement_id.Name = "placement_id";
            this.placement_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.placement_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.placement_id.ValueMember = "placement_id";
            this.placement_id.Width = 200;
            // 
            // doc_type_id
            // 
            this.doc_type_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.doc_type_id.DataPropertyName = "doc_type_id";
            this.doc_type_id.DataSource = this.bsDocTypesForIps;
            this.doc_type_id.DisplayMember = "name";
            this.doc_type_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.doc_type_id.DisplayStyleForCurrentCellOnly = true;
            this.doc_type_id.HeaderText = "Тип печатаемого документа";
            this.doc_type_id.Name = "doc_type_id";
            this.doc_type_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.doc_type_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.doc_type_id.ValueMember = "doc_type_id";
            this.doc_type_id.Width = 160;
            // 
            // user_id
            // 
            this.user_id.DataPropertyName = "user_id";
            this.user_id.DataSource = this.bsUsersForIps;
            this.user_id.DisplayMember = "User_FIO";
            this.user_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.user_id.DisplayStyleForCurrentCellOnly = true;
            this.user_id.HeaderText = "Ответственный пользователь";
            this.user_id.Name = "user_id";
            this.user_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.user_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.user_id.ValueMember = "User_ID";
            this.user_id.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "placement_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "placement_id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "doc_type_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "doc_type_id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "user_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "user_id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // IpDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(932, 338);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvIps);
            this.Name = "IpDirectoryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник IP-адресов";
            this.Load += new System.EventHandler(this.IpDirectoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlacementsForIps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTypesForIps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsersForIps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIps;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bsIps;
        private WMSOffice.Data.Containers containers;
        private WMSOffice.Data.ContainersTableAdapters.IpsTableAdapter taIps;
        private System.Windows.Forms.BindingSource bsPlacementsForIps;
        private WMSOffice.Data.ContainersTableAdapters.PlacementsForIpsTableAdapter taPlacementsForIps;
        private System.Windows.Forms.BindingSource bsUsersForIps;
        private WMSOffice.Data.ContainersTableAdapters.WmsUsersForIpsTableAdapter taUsersForIps;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.BindingSource bsDocTypesForIps;
        private WMSOffice.Data.ContainersTableAdapters.DocTypesForIpsTableAdapter taDocTypesForIps;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewComboBoxColumn placement_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn doc_type_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn user_id;
    }
}