namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryMembersRegistrationForm
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
            this.tsMainToolBar = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbDates = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgvUnregisteredMembers = new System.Windows.Forms.DataGridView();
            this.rOWDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryNotRegisteredMembersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbScanEmployee = new WMSOffice.Controls.TextBoxScaner();
            this.inventoryNotRegisteredMembersTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoryNotRegisteredMembersTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.tsMainToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnregisteredMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryNotRegisteredMembersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(8465, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8555, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 480);
            this.pnlButtons.Size = new System.Drawing.Size(807, 43);
            // 
            // tsMainToolBar
            // 
            this.tsMainToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMainToolBar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.toolStripLabel2,
            this.cmbDates,
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.tsMainToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsMainToolBar.Name = "tsMainToolBar";
            this.tsMainToolBar.Size = new System.Drawing.Size(450, 55);
            this.tsMainToolBar.TabIndex = 101;
            this.tsMainToolBar.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(113, 52);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(44, 52);
            this.toolStripLabel2.Text = "за дату";
            // 
            // cmbDates
            // 
            this.cmbDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDates.Name = "cmbDates";
            this.cmbDates.Size = new System.Drawing.Size(85, 55);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(188, 52);
            this.toolStripLabel1.Text = "Отсканируйте бэйдж сотрудника\nили введите его код:";
            // 
            // dgvUnregisteredMembers
            // 
            this.dgvUnregisteredMembers.AllowUserToAddRows = false;
            this.dgvUnregisteredMembers.AllowUserToDeleteRows = false;
            this.dgvUnregisteredMembers.AllowUserToResizeRows = false;
            this.dgvUnregisteredMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnregisteredMembers.AutoGenerateColumns = false;
            this.dgvUnregisteredMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnregisteredMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rOWDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn,
            this.resourceTypeDataGridViewTextBoxColumn,
            this.teamIDDataGridViewTextBoxColumn});
            this.dgvUnregisteredMembers.DataSource = this.inventoryNotRegisteredMembersBindingSource;
            this.dgvUnregisteredMembers.Location = new System.Drawing.Point(4, 28);
            this.dgvUnregisteredMembers.MultiSelect = false;
            this.dgvUnregisteredMembers.Name = "dgvUnregisteredMembers";
            this.dgvUnregisteredMembers.ReadOnly = true;
            this.dgvUnregisteredMembers.RowHeadersVisible = false;
            this.dgvUnregisteredMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnregisteredMembers.Size = new System.Drawing.Size(800, 385);
            this.dgvUnregisteredMembers.TabIndex = 102;
            // 
            // rOWDataGridViewTextBoxColumn
            // 
            this.rOWDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rOWDataGridViewTextBoxColumn.DataPropertyName = "ROW";
            this.rOWDataGridViewTextBoxColumn.HeaderText = "№";
            this.rOWDataGridViewTextBoxColumn.Name = "rOWDataGridViewTextBoxColumn";
            this.rOWDataGridViewTextBoxColumn.ReadOnly = true;
            this.rOWDataGridViewTextBoxColumn.Width = 43;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Код сотр.";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Ф.И.О.";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Width = 68;
            // 
            // resourceTypeDataGridViewTextBoxColumn
            // 
            this.resourceTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.resourceTypeDataGridViewTextBoxColumn.DataPropertyName = "Resource_Type";
            this.resourceTypeDataGridViewTextBoxColumn.HeaderText = "Тип ресурса";
            this.resourceTypeDataGridViewTextBoxColumn.Name = "resourceTypeDataGridViewTextBoxColumn";
            this.resourceTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.resourceTypeDataGridViewTextBoxColumn.Width = 95;
            // 
            // teamIDDataGridViewTextBoxColumn
            // 
            this.teamIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.teamIDDataGridViewTextBoxColumn.DataPropertyName = "Team_ID";
            this.teamIDDataGridViewTextBoxColumn.HeaderText = "№ бригады";
            this.teamIDDataGridViewTextBoxColumn.Name = "teamIDDataGridViewTextBoxColumn";
            this.teamIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.teamIDDataGridViewTextBoxColumn.Width = 89;
            // 
            // inventoryNotRegisteredMembersBindingSource
            // 
            this.inventoryNotRegisteredMembersBindingSource.DataMember = "InventoryNotRegisteredMembers";
            this.inventoryNotRegisteredMembersBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvUnregisteredMembers);
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 416);
            this.panel1.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(276, 25);
            this.label1.TabIndex = 103;
            this.label1.Text = "Незарегистрированные участники";
            // 
            // tbScanEmployee
            // 
            this.tbScanEmployee.AllowType = true;
            this.tbScanEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScanEmployee.AutoConvert = true;
            this.tbScanEmployee.Location = new System.Drawing.Point(453, 14);
            this.tbScanEmployee.Name = "tbScanEmployee";
            this.tbScanEmployee.RaiseTextChangeWithoutEnter = false;
            this.tbScanEmployee.ReadOnly = false;
            this.tbScanEmployee.Size = new System.Drawing.Size(351, 25);
            this.tbScanEmployee.TabIndex = 104;
            this.tbScanEmployee.TextBoxBackColor = System.Drawing.SystemColors.Window;
            // 
            // inventoryNotRegisteredMembersTableAdapter
            // 
            this.inventoryNotRegisteredMembersTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryMembersRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 523);
            this.Controls.Add(this.tsMainToolBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbScanEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "InventoryMembersRegistrationForm";
            this.Text = "Регистрация участников инвентаризации";
            this.Load += new System.EventHandler(this.InventoryMembersRegistrationForm_Load);
            this.Controls.SetChildIndex(this.tbScanEmployee, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tsMainToolBar, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.tsMainToolBar.ResumeLayout(false);
            this.tsMainToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnregisteredMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryNotRegisteredMembersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainToolBar;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvUnregisteredMembers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WMSOffice.Controls.TextBoxScaner tbScanEmployee;
        private System.Windows.Forms.BindingSource inventoryNotRegisteredMembersBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.InventoryNotRegisteredMembersTableAdapter inventoryNotRegisteredMembersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOWDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cmbDates;
    }
}