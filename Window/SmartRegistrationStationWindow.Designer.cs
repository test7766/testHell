namespace WMSOffice.Window
{
    partial class SmartRegistrationStationWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMainOptions = new System.Windows.Forms.ToolStrip();
            this.slRegisterEmployee = new System.Windows.Forms.ToolStripLabel();
            this.pnlMainLayout = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.xdgvStations = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmStations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miUnregisterAllEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRegisteredEmployees = new System.Windows.Forms.DataGridView();
            this.aBAN8DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBALPHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateLinked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miUnregisterEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.prsestationemployeeonstationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.label2 = new System.Windows.Forms.Label();
            this.pr_se_station_employee_on_stationTableAdapter = new WMSOffice.Data.PickControlTableAdapters.pr_se_station_employee_on_stationTableAdapter();
            this.tsMainOptions.SuspendLayout();
            this.pnlMainLayout.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmStations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisteredEmployees)).BeginInit();
            this.cmEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prsestationemployeeonstationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainOptions
            // 
            this.tsMainOptions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMainOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slRegisterEmployee});
            this.tsMainOptions.Location = new System.Drawing.Point(0, 40);
            this.tsMainOptions.Name = "tsMainOptions";
            this.tsMainOptions.Size = new System.Drawing.Size(981, 35);
            this.tsMainOptions.TabIndex = 1;
            this.tsMainOptions.Text = "toolStrip1";
            // 
            // slRegisterEmployee
            // 
            this.slRegisterEmployee.Image = global::WMSOffice.Properties.Resources.config_users;
            this.slRegisterEmployee.Name = "slRegisterEmployee";
            this.slRegisterEmployee.Size = new System.Drawing.Size(139, 32);
            this.slRegisterEmployee.Text = "Зарегистрировать";
            // 
            // pnlMainLayout
            // 
            this.pnlMainLayout.Controls.Add(this.splitContainer1);
            this.pnlMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainLayout.Location = new System.Drawing.Point(0, 75);
            this.pnlMainLayout.Name = "pnlMainLayout";
            this.pnlMainLayout.Size = new System.Drawing.Size(981, 466);
            this.pnlMainLayout.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.xdgvStations);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvRegisteredEmployees);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(981, 466);
            this.splitContainer1.SplitterDistance = 429;
            this.splitContainer1.TabIndex = 0;
            // 
            // xdgvStations
            // 
            this.xdgvStations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvStations.ContextMenuStrip = this.cmStations;
            this.xdgvStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvStations.LargeAmountOfData = false;
            this.xdgvStations.Location = new System.Drawing.Point(0, 45);
            this.xdgvStations.Name = "xdgvStations";
            this.xdgvStations.RowHeadersVisible = false;
            this.xdgvStations.Size = new System.Drawing.Size(429, 421);
            this.xdgvStations.TabIndex = 1;
            this.xdgvStations.UserID = ((long)(0));
            // 
            // cmStations
            // 
            this.cmStations.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmStations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUnregisterAllEmployees});
            this.cmStations.Name = "cmStations";
            this.cmStations.Size = new System.Drawing.Size(167, 34);
            // 
            // miUnregisterAllEmployees
            // 
            this.miUnregisterAllEmployees.Image = global::WMSOffice.Properties.Resources.repeat;
            this.miUnregisterAllEmployees.Name = "miUnregisterAllEmployees";
            this.miUnregisterAllEmployees.Size = new System.Drawing.Size(166, 30);
            this.miUnregisterAllEmployees.Text = "Открепить всех";
            this.miUnregisterAllEmployees.Click += new System.EventHandler(this.miUnregisterAllEmployees_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 12, 0, 0);
            this.label1.Size = new System.Drawing.Size(429, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список станций";
            // 
            // dgvRegisteredEmployees
            // 
            this.dgvRegisteredEmployees.AllowUserToAddRows = false;
            this.dgvRegisteredEmployees.AllowUserToDeleteRows = false;
            this.dgvRegisteredEmployees.AllowUserToResizeColumns = false;
            this.dgvRegisteredEmployees.AllowUserToResizeRows = false;
            this.dgvRegisteredEmployees.AutoGenerateColumns = false;
            this.dgvRegisteredEmployees.BackgroundColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegisteredEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegisteredEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisteredEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aBAN8DataGridViewTextBoxColumn,
            this.aBALPHDataGridViewTextBoxColumn,
            this.DateLinked});
            this.dgvRegisteredEmployees.ContextMenuStrip = this.cmEmployees;
            this.dgvRegisteredEmployees.DataSource = this.prsestationemployeeonstationBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegisteredEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegisteredEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegisteredEmployees.Location = new System.Drawing.Point(0, 45);
            this.dgvRegisteredEmployees.MultiSelect = false;
            this.dgvRegisteredEmployees.Name = "dgvRegisteredEmployees";
            this.dgvRegisteredEmployees.ReadOnly = true;
            this.dgvRegisteredEmployees.RowHeadersVisible = false;
            this.dgvRegisteredEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegisteredEmployees.Size = new System.Drawing.Size(548, 421);
            this.dgvRegisteredEmployees.TabIndex = 1;
            this.dgvRegisteredEmployees.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvRegisteredEmployees_MouseDown);
            this.dgvRegisteredEmployees.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRegisteredEmployees_CellFormatting);
            this.dgvRegisteredEmployees.SelectionChanged += new System.EventHandler(this.dgvRegisteredEmployees_SelectionChanged);
            // 
            // aBAN8DataGridViewTextBoxColumn
            // 
            this.aBAN8DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.aBAN8DataGridViewTextBoxColumn.DataPropertyName = "ABAN8";
            this.aBAN8DataGridViewTextBoxColumn.HeaderText = "Код";
            this.aBAN8DataGridViewTextBoxColumn.Name = "aBAN8DataGridViewTextBoxColumn";
            this.aBAN8DataGridViewTextBoxColumn.ReadOnly = true;
            this.aBAN8DataGridViewTextBoxColumn.Width = 64;
            // 
            // aBALPHDataGridViewTextBoxColumn
            // 
            this.aBALPHDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.aBALPHDataGridViewTextBoxColumn.DataPropertyName = "ABALPH";
            this.aBALPHDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.aBALPHDataGridViewTextBoxColumn.Name = "aBALPHDataGridViewTextBoxColumn";
            this.aBALPHDataGridViewTextBoxColumn.ReadOnly = true;
            this.aBALPHDataGridViewTextBoxColumn.Width = 116;
            // 
            // DateLinked
            // 
            this.DateLinked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateLinked.DataPropertyName = "DateLinked";
            this.DateLinked.HeaderText = "Дата с";
            this.DateLinked.Name = "DateLinked";
            this.DateLinked.ReadOnly = true;
            this.DateLinked.Width = 85;
            // 
            // cmEmployees
            // 
            this.cmEmployees.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmEmployees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUnregisterEmployee});
            this.cmEmployees.Name = "cmEmployees";
            this.cmEmployees.Size = new System.Drawing.Size(141, 34);
            // 
            // miUnregisterEmployee
            // 
            this.miUnregisterEmployee.Image = global::WMSOffice.Properties.Resources.repeat;
            this.miUnregisterEmployee.Name = "miUnregisterEmployee";
            this.miUnregisterEmployee.Size = new System.Drawing.Size(140, 30);
            this.miUnregisterEmployee.Text = "Открепить";
            this.miUnregisterEmployee.Click += new System.EventHandler(this.miUnregisterEmployee_Click);
            // 
            // prsestationemployeeonstationBindingSource
            // 
            this.prsestationemployeeonstationBindingSource.DataMember = "pr_se_station_employee_on_station";
            this.prsestationemployeeonstationBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 12, 0, 0);
            this.label2.Size = new System.Drawing.Size(548, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "Сотрудники";
            // 
            // pr_se_station_employee_on_stationTableAdapter
            // 
            this.pr_se_station_employee_on_stationTableAdapter.ClearBeforeFill = true;
            // 
            // SmartRegistrationStationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 541);
            this.Controls.Add(this.pnlMainLayout);
            this.Controls.Add(this.tsMainOptions);
            this.Name = "SmartRegistrationStationWindow";
            this.Text = "SmartRegistrationStationWindow";
            this.Controls.SetChildIndex(this.tsMainOptions, 0);
            this.Controls.SetChildIndex(this.pnlMainLayout, 0);
            this.tsMainOptions.ResumeLayout(false);
            this.tsMainOptions.PerformLayout();
            this.pnlMainLayout.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.cmStations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisteredEmployees)).EndInit();
            this.cmEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prsestationemployeeonstationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainOptions;
        private System.Windows.Forms.Panel pnlMainLayout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvStations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvRegisteredEmployees;
        private System.Windows.Forms.BindingSource prsestationemployeeonstationBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.pr_se_station_employee_on_stationTableAdapter pr_se_station_employee_on_stationTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBAN8DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBALPHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateLinked;
        private System.Windows.Forms.ToolStripLabel slRegisterEmployee;
        private System.Windows.Forms.ContextMenuStrip cmStations;
        private System.Windows.Forms.ToolStripMenuItem miUnregisterAllEmployees;
        private System.Windows.Forms.ContextMenuStrip cmEmployees;
        private System.Windows.Forms.ToolStripMenuItem miUnregisterEmployee;
    }
}