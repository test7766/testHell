namespace WMSOffice.Dialogs.Containers
{
    partial class DevicesDirectoryForm
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
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventory_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDevices = new System.Windows.Forms.BindingSource(this.components);
            this.containers = new WMSOffice.Data.Containers();
            this.btnClose = new System.Windows.Forms.Button();
            this.taDevices = new WMSOffice.Data.ContainersTableAdapters.DevicesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDevices
            // 
            this.dgvDevices.AllowUserToAddRows = false;
            this.dgvDevices.AllowUserToDeleteRows = false;
            this.dgvDevices.AllowUserToResizeRows = false;
            this.dgvDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDevices.AutoGenerateColumns = false;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.mac,
            this.name,
            this.inventory_id,
            this.placement,
            this.ip,
            this.user});
            this.dgvDevices.DataSource = this.bsDevices;
            this.dgvDevices.Location = new System.Drawing.Point(12, 12);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(805, 276);
            this.dgvDevices.TabIndex = 0;
            this.dgvDevices.VirtualMode = true;
            this.dgvDevices.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevices_RowEnter);
            this.dgvDevices.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDevices_RowValidating);
            // 
            // id
            // 
            this.id.DataPropertyName = "device_id";
            this.id.HeaderText = "device_id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // mac
            // 
            this.mac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mac.DataPropertyName = "mac";
            this.mac.HeaderText = "MAC-адрес";
            this.mac.Name = "mac";
            this.mac.ReadOnly = true;
            this.mac.Width = 88;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Модель";
            this.name.Name = "name";
            this.name.Width = 150;
            // 
            // inventory_id
            // 
            this.inventory_id.DataPropertyName = "inventory_id";
            this.inventory_id.HeaderText = "Инвентарный номер";
            this.inventory_id.Name = "inventory_id";
            // 
            // placement
            // 
            this.placement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placement.DataPropertyName = "placement";
            this.placement.HeaderText = "Площадка";
            this.placement.Name = "placement";
            this.placement.ReadOnly = true;
            this.placement.Width = 85;
            // 
            // ip
            // 
            this.ip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ip.DataPropertyName = "ip";
            this.ip.HeaderText = "IP-адрес";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Width = 75;
            // 
            // user
            // 
            this.user.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.user.DataPropertyName = "user";
            this.user.HeaderText = "Ответственный";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            this.user.Width = 111;
            // 
            // bsDevices
            // 
            this.bsDevices.DataMember = "Devices";
            this.bsDevices.DataSource = this.containers;
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
            this.btnClose.Location = new System.Drawing.Point(742, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // taDevices
            // 
            this.taDevices.ClearBeforeFill = true;
            // 
            // DevicesDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(829, 342);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDevices);
            this.Name = "DevicesDirectoryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник устройств";
            this.Load += new System.EventHandler(this.DevicesDirectoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Button btnClose;
        private WMSOffice.Data.Containers containers;
        private System.Windows.Forms.BindingSource bsDevices;
        private WMSOffice.Data.ContainersTableAdapters.DevicesTableAdapter taDevices;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mac;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventory_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn placement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
    }
}