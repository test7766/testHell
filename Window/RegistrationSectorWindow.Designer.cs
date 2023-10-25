namespace WMSOffice.Window
{
    partial class RegistrationSectorWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbSectors = new System.Windows.Forms.ListBox();
            this.sectorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.pnlBarcode = new System.Windows.Forms.Panel();
            this.textBoxScaner = new WMSOffice.Controls.TextBoxScaner();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dateTimeFilter = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlRegisteredEmployees = new System.Windows.Forms.Panel();
            this.gbEmployeeCategory = new System.Windows.Forms.GroupBox();
            this.rbStowers = new System.Windows.Forms.RadioButton();
            this.rbPickers = new System.Windows.Forms.RadioButton();
            this.gvRegistrations = new System.Windows.Forms.DataGridView();
            this.sectorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sectorsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.SectorsTableAdapter();
            this.registrationsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.RegistrationsTableAdapter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sectorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.pnlBarcode.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlRegisteredEmployees.SuspendLayout();
            this.gbEmployeeCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegistrations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.pnlBarcode);
            this.splitContainer1.Panel1.Controls.Add(this.pnlFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlRegisteredEmployees);
            this.splitContainer1.Size = new System.Drawing.Size(740, 348);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSectors);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 262);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сектора:";
            // 
            // lbSectors
            // 
            this.lbSectors.DataSource = this.sectorsBindingSource;
            this.lbSectors.DisplayMember = "Sector_Name";
            this.lbSectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSectors.FormattingEnabled = true;
            this.lbSectors.ItemHeight = 25;
            this.lbSectors.Location = new System.Drawing.Point(3, 16);
            this.lbSectors.Name = "lbSectors";
            this.lbSectors.Size = new System.Drawing.Size(240, 229);
            this.lbSectors.TabIndex = 0;
            this.lbSectors.ValueMember = "Sector_ID";
            this.lbSectors.SelectedIndexChanged += new System.EventHandler(this.lbSectors_SelectedIndexChanged);
            this.lbSectors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSectors_KeyDown);
            // 
            // sectorsBindingSource
            // 
            this.sectorsBindingSource.DataMember = "Sectors";
            this.sectorsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlBarcode
            // 
            this.pnlBarcode.Controls.Add(this.textBoxScaner);
            this.pnlBarcode.Controls.Add(this.label1);
            this.pnlBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarcode.Location = new System.Drawing.Point(0, 0);
            this.pnlBarcode.Name = "pnlBarcode";
            this.pnlBarcode.Size = new System.Drawing.Size(246, 50);
            this.pnlBarcode.TabIndex = 0;
            // 
            // textBoxScaner
            // 
            this.textBoxScaner.AllowType = true;
            this.textBoxScaner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScaner.AutoConvert = true;
            this.textBoxScaner.Location = new System.Drawing.Point(3, 19);
            this.textBoxScaner.Name = "textBoxScaner";
            this.textBoxScaner.ReadOnly = false;
            this.textBoxScaner.Size = new System.Drawing.Size(240, 25);
            this.textBoxScaner.TabIndex = 1;
            this.textBoxScaner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.textBoxScaner.TextChanged += new System.EventHandler(this.textBoxScaner_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Штрих код сотрудника:";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.dateTimeFilter);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFilter.Location = new System.Drawing.Point(0, 312);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(246, 36);
            this.pnlFilter.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(167, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dateTimeFilter
            // 
            this.dateTimeFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFilter.Location = new System.Drawing.Point(68, 8);
            this.dateTimeFilter.Name = "dateTimeFilter";
            this.dateTimeFilter.Size = new System.Drawing.Size(93, 20);
            this.dateTimeFilter.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Фильтр:";
            // 
            // pnlRegisteredEmployees
            // 
            this.pnlRegisteredEmployees.Controls.Add(this.gbEmployeeCategory);
            this.pnlRegisteredEmployees.Controls.Add(this.gvRegistrations);
            this.pnlRegisteredEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRegisteredEmployees.Location = new System.Drawing.Point(0, 0);
            this.pnlRegisteredEmployees.Name = "pnlRegisteredEmployees";
            this.pnlRegisteredEmployees.Size = new System.Drawing.Size(490, 348);
            this.pnlRegisteredEmployees.TabIndex = 1;
            // 
            // gbEmployeeCategory
            // 
            this.gbEmployeeCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEmployeeCategory.Controls.Add(this.rbStowers);
            this.gbEmployeeCategory.Controls.Add(this.rbPickers);
            this.gbEmployeeCategory.Location = new System.Drawing.Point(3, 3);
            this.gbEmployeeCategory.Name = "gbEmployeeCategory";
            this.gbEmployeeCategory.Size = new System.Drawing.Size(484, 59);
            this.gbEmployeeCategory.TabIndex = 1;
            this.gbEmployeeCategory.TabStop = false;
            this.gbEmployeeCategory.Text = "Выберите категорию:";
            // 
            // rbStowers
            // 
            this.rbStowers.AutoSize = true;
            this.rbStowers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbStowers.Location = new System.Drawing.Point(135, 24);
            this.rbStowers.Name = "rbStowers";
            this.rbStowers.Size = new System.Drawing.Size(105, 20);
            this.rbStowers.TabIndex = 1;
            this.rbStowers.TabStop = true;
            this.rbStowers.Text = "Закладчики";
            this.rbStowers.UseVisualStyleBackColor = true;
            this.rbStowers.CheckedChanged += new System.EventHandler(this.rbEmployeeCategory_CheckedChanged);
            // 
            // rbPickers
            // 
            this.rbPickers.AutoSize = true;
            this.rbPickers.Checked = true;
            this.rbPickers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPickers.Location = new System.Drawing.Point(19, 24);
            this.rbPickers.Name = "rbPickers";
            this.rbPickers.Size = new System.Drawing.Size(91, 20);
            this.rbPickers.TabIndex = 0;
            this.rbPickers.TabStop = true;
            this.rbPickers.Text = "Сборщики";
            this.rbPickers.UseVisualStyleBackColor = true;
            this.rbPickers.CheckedChanged += new System.EventHandler(this.rbEmployeeCategory_CheckedChanged);
            // 
            // gvRegistrations
            // 
            this.gvRegistrations.AllowUserToAddRows = false;
            this.gvRegistrations.AllowUserToDeleteRows = false;
            this.gvRegistrations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRegistrations.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvRegistrations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvRegistrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRegistrations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sectorNameDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn,
            this.dateInDataGridViewTextBoxColumn,
            this.dateOutDataGridViewTextBoxColumn});
            this.gvRegistrations.DataSource = this.registrationsBindingSource;
            this.gvRegistrations.Location = new System.Drawing.Point(3, 68);
            this.gvRegistrations.MultiSelect = false;
            this.gvRegistrations.Name = "gvRegistrations";
            this.gvRegistrations.ReadOnly = true;
            this.gvRegistrations.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvRegistrations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRegistrations.Size = new System.Drawing.Size(484, 277);
            this.gvRegistrations.TabIndex = 0;
            // 
            // sectorNameDataGridViewTextBoxColumn
            // 
            this.sectorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sectorNameDataGridViewTextBoxColumn.DataPropertyName = "Sector_Name";
            this.sectorNameDataGridViewTextBoxColumn.HeaderText = "Сектор";
            this.sectorNameDataGridViewTextBoxColumn.Name = "sectorNameDataGridViewTextBoxColumn";
            this.sectorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.sectorNameDataGridViewTextBoxColumn.Width = 80;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 58;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Width = 103;
            // 
            // dateInDataGridViewTextBoxColumn
            // 
            this.dateInDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateInDataGridViewTextBoxColumn.DataPropertyName = "Date_In";
            this.dateInDataGridViewTextBoxColumn.HeaderText = "Дата с";
            this.dateInDataGridViewTextBoxColumn.Name = "dateInDataGridViewTextBoxColumn";
            this.dateInDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateInDataGridViewTextBoxColumn.Width = 78;
            // 
            // dateOutDataGridViewTextBoxColumn
            // 
            this.dateOutDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateOutDataGridViewTextBoxColumn.DataPropertyName = "Date_Out";
            this.dateOutDataGridViewTextBoxColumn.HeaderText = "Дата по";
            this.dateOutDataGridViewTextBoxColumn.Name = "dateOutDataGridViewTextBoxColumn";
            this.dateOutDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateOutDataGridViewTextBoxColumn.Width = 87;
            // 
            // registrationsBindingSource
            // 
            this.registrationsBindingSource.DataMember = "Registrations";
            this.registrationsBindingSource.DataSource = this.pickControl;
            // 
            // sectorsTableAdapter
            // 
            this.sectorsTableAdapter.ClearBeforeFill = true;
            // 
            // registrationsTableAdapter
            // 
            this.registrationsTableAdapter.ClearBeforeFill = true;
            // 
            // RegistrationSectorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RegistrationSectorWindow";
            this.Text = "RegistrationSectorWindow";
            this.Load += new System.EventHandler(this.RegistrationSectorWindow_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sectorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.pnlBarcode.ResumeLayout(false);
            this.pnlBarcode.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlRegisteredEmployees.ResumeLayout(false);
            this.gbEmployeeCategory.ResumeLayout(false);
            this.gbEmployeeCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegistrations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlBarcode;
        private System.Windows.Forms.Label label1;
        private WMSOffice.Controls.TextBoxScaner textBoxScaner;
        private System.Windows.Forms.DataGridView gvRegistrations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbSectors;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dateTimeFilter;
        private System.Windows.Forms.Label label2;
        private WMSOffice.Data.PickControl pickControl;
        private System.Windows.Forms.BindingSource sectorsBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.SectorsTableAdapter sectorsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource registrationsBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.RegistrationsTableAdapter registrationsTableAdapter;
        private System.Windows.Forms.Panel pnlRegisteredEmployees;
        private System.Windows.Forms.GroupBox gbEmployeeCategory;
        private System.Windows.Forms.RadioButton rbStowers;
        private System.Windows.Forms.RadioButton rbPickers;
    }
}