namespace WMSOffice.Window
{
    partial class RegistrationStationWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sbShowEmployees = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbScanEmployee = new WMSOffice.Controls.TextBoxScaner();
            this.pnlMainLayout = new System.Windows.Forms.Panel();
            this.scDataLayout = new System.Windows.Forms.SplitContainer();
            this.xdgvStations = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRegisteredEmployees = new System.Windows.Forms.DataGridView();
            this.employeeidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datefromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationRegistrationsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.stationRegistrationsListTableAdapter = new WMSOffice.Data.PickControlTableAdapters.StationRegistrationsListTableAdapter();
            this.toolStrip1.SuspendLayout();
            this.pnlMainLayout.SuspendLayout();
            this.scDataLayout.Panel1.SuspendLayout();
            this.scDataLayout.Panel2.SuspendLayout();
            this.scDataLayout.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisteredEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationRegistrationsListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbShowEmployees,
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 43);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(319, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // sbShowEmployees
            // 
            this.sbShowEmployees.Image = global::WMSOffice.Properties.Resources.config_users;
            this.sbShowEmployees.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbShowEmployees.Name = "sbShowEmployees";
            this.sbShowEmployees.Size = new System.Drawing.Size(113, 36);
            this.sbShowEmployees.Text = "Список\nсотрудников";
            this.sbShowEmployees.Click += new System.EventHandler(this.sbShowEmployees_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(188, 36);
            this.toolStripLabel1.Text = "Отсканируйте бэйдж сотрудника\nили введите его код:";
            // 
            // tbScanEmployee
            // 
            this.tbScanEmployee.AllowType = true;
            this.tbScanEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScanEmployee.AutoConvert = true;
            this.tbScanEmployee.Location = new System.Drawing.Point(322, 50);
            this.tbScanEmployee.Name = "tbScanEmployee";
            this.tbScanEmployee.RaiseTextChangeWithoutEnter = false;
            this.tbScanEmployee.ReadOnly = false;
            this.tbScanEmployee.Size = new System.Drawing.Size(809, 25);
            this.tbScanEmployee.TabIndex = 105;
            this.tbScanEmployee.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScanEmployee.UseParentFont = false;
            // 
            // pnlMainLayout
            // 
            this.pnlMainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainLayout.Controls.Add(this.scDataLayout);
            this.pnlMainLayout.Location = new System.Drawing.Point(0, 85);
            this.pnlMainLayout.Name = "pnlMainLayout";
            this.pnlMainLayout.Size = new System.Drawing.Size(1317, 547);
            this.pnlMainLayout.TabIndex = 106;
            // 
            // scDataLayout
            // 
            this.scDataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDataLayout.Location = new System.Drawing.Point(0, 0);
            this.scDataLayout.Name = "scDataLayout";
            // 
            // scDataLayout.Panel1
            // 
            this.scDataLayout.Panel1.Controls.Add(this.xdgvStations);
            this.scDataLayout.Panel1.Controls.Add(this.panel2);
            // 
            // scDataLayout.Panel2
            // 
            this.scDataLayout.Panel2.Controls.Add(this.dgvRegisteredEmployees);
            this.scDataLayout.Panel2.Controls.Add(this.panel1);
            this.scDataLayout.Size = new System.Drawing.Size(1317, 547);
            this.scDataLayout.SplitterDistance = 439;
            this.scDataLayout.TabIndex = 1;
            // 
            // xdgvStations
            // 
            this.xdgvStations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvStations.LargeAmountOfData = false;
            this.xdgvStations.Location = new System.Drawing.Point(0, 44);
            this.xdgvStations.Name = "xdgvStations";
            this.xdgvStations.RowHeadersVisible = false;
            this.xdgvStations.Size = new System.Drawing.Size(439, 503);
            this.xdgvStations.TabIndex = 1;
            this.xdgvStations.UserID = ((long)(0));
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 44);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.label1.Size = new System.Drawing.Size(91, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Станции";
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
            this.employeeidDataGridViewTextBoxColumn,
            this.employeenameDataGridViewTextBoxColumn,
            this.datefromDataGridViewTextBoxColumn,
            this.datetoDataGridViewTextBoxColumn});
            this.dgvRegisteredEmployees.DataSource = this.stationRegistrationsListBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegisteredEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegisteredEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegisteredEmployees.Location = new System.Drawing.Point(0, 44);
            this.dgvRegisteredEmployees.MultiSelect = false;
            this.dgvRegisteredEmployees.Name = "dgvRegisteredEmployees";
            this.dgvRegisteredEmployees.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegisteredEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRegisteredEmployees.RowHeadersVisible = false;
            this.dgvRegisteredEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegisteredEmployees.Size = new System.Drawing.Size(874, 503);
            this.dgvRegisteredEmployees.TabIndex = 2;
            // 
            // employeeidDataGridViewTextBoxColumn
            // 
            this.employeeidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeidDataGridViewTextBoxColumn.DataPropertyName = "employee_id";
            this.employeeidDataGridViewTextBoxColumn.HeaderText = "Код";
            this.employeeidDataGridViewTextBoxColumn.Name = "employeeidDataGridViewTextBoxColumn";
            this.employeeidDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeidDataGridViewTextBoxColumn.Width = 64;
            // 
            // employeenameDataGridViewTextBoxColumn
            // 
            this.employeenameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeenameDataGridViewTextBoxColumn.DataPropertyName = "employee_name";
            this.employeenameDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.employeenameDataGridViewTextBoxColumn.Name = "employeenameDataGridViewTextBoxColumn";
            this.employeenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeenameDataGridViewTextBoxColumn.Width = 116;
            // 
            // datefromDataGridViewTextBoxColumn
            // 
            this.datefromDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datefromDataGridViewTextBoxColumn.DataPropertyName = "date_from";
            this.datefromDataGridViewTextBoxColumn.HeaderText = "Дата с";
            this.datefromDataGridViewTextBoxColumn.Name = "datefromDataGridViewTextBoxColumn";
            this.datefromDataGridViewTextBoxColumn.ReadOnly = true;
            this.datefromDataGridViewTextBoxColumn.Width = 85;
            // 
            // datetoDataGridViewTextBoxColumn
            // 
            this.datetoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datetoDataGridViewTextBoxColumn.DataPropertyName = "date_to";
            this.datetoDataGridViewTextBoxColumn.HeaderText = "Дата по";
            this.datetoDataGridViewTextBoxColumn.Name = "datetoDataGridViewTextBoxColumn";
            this.datetoDataGridViewTextBoxColumn.ReadOnly = true;
            this.datetoDataGridViewTextBoxColumn.Width = 95;
            // 
            // stationRegistrationsListBindingSource
            // 
            this.stationRegistrationsListBindingSource.DataMember = "StationRegistrationsList";
            this.stationRegistrationsListBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 44);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.label2.Size = new System.Drawing.Size(303, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "Зарегистрированные сотрудники";
            // 
            // stationRegistrationsListTableAdapter
            // 
            this.stationRegistrationsListTableAdapter.ClearBeforeFill = true;
            // 
            // RegistrationStationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 632);
            this.Controls.Add(this.pnlMainLayout);
            this.Controls.Add(this.tbScanEmployee);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RegistrationStationWindow";
            this.Text = "RegistrationStationWindow";
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.tbScanEmployee, 0);
            this.Controls.SetChildIndex(this.pnlMainLayout, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlMainLayout.ResumeLayout(false);
            this.scDataLayout.Panel1.ResumeLayout(false);
            this.scDataLayout.Panel2.ResumeLayout(false);
            this.scDataLayout.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisteredEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationRegistrationsListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WMSOffice.Controls.TextBoxScaner tbScanEmployee;
        private System.Windows.Forms.Panel pnlMainLayout;
        private WMSOffice.Data.PickControl pickControl;
        private System.Windows.Forms.SplitContainer scDataLayout;
        private System.Windows.Forms.DataGridView dgvRegisteredEmployees;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource stationRegistrationsListBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.StationRegistrationsListTableAdapter stationRegistrationsListTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datefromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetoDataGridViewTextBoxColumn;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvStations;
        private System.Windows.Forms.ToolStripButton sbShowEmployees;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}