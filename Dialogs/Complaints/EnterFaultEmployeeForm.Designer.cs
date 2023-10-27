namespace WMSOffice.Dialogs.Complaints
{
    partial class EnterFaultEmployeeForm
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
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availableEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.availableEmployeesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableEmployeesTableAdapter();
            this.lblRequestCaption = new System.Windows.Forms.Label();
            this.tbFaultEmployeeID = new System.Windows.Forms.TextBox();
            this.tbNameFilter = new System.Windows.Forms.TextBox();
            this.lblNameFilterCaption = new System.Windows.Forms.Label();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.chbDepartment = new System.Windows.Forms.CheckBox();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.bsCoDepartments = new System.Windows.Forms.BindingSource(this.components);
            this.taCoDepartment = new WMSOffice.Data.ComplaintsTableAdapters.CO_Get_Available_departmentTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(345, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(435, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 387);
            this.pnlButtons.Size = new System.Drawing.Size(436, 43);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToOrderColumns = true;
            this.dgvEmployees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployees.AutoGenerateColumns = false;
            this.dgvEmployees.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeNameDataGridViewTextBoxColumn});
            this.dgvEmployees.DataSource = this.availableEmployeesBindingSource;
            this.dgvEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 83);
            this.dgvEmployees.Name = "dgvEmployees";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployees.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.RowTemplate.Height = 21;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.ShowCellErrors = false;
            this.dgvEmployees.ShowEditingIcon = false;
            this.dgvEmployees.ShowRowErrors = false;
            this.dgvEmployees.Size = new System.Drawing.Size(412, 199);
            this.dgvEmployees.TabIndex = 101;
            this.dgvEmployees.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellDoubleClick);
            this.dgvEmployees.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmployees_CellFormatting);
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 65;
            // 
            // employeeNameDataGridViewTextBoxColumn
            // 
            this.employeeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.employeeNameDataGridViewTextBoxColumn.DataPropertyName = "Employee_Name";
            this.employeeNameDataGridViewTextBoxColumn.HeaderText = "ФИО";
            this.employeeNameDataGridViewTextBoxColumn.Name = "employeeNameDataGridViewTextBoxColumn";
            this.employeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // availableEmployeesBindingSource
            // 
            this.availableEmployeesBindingSource.DataMember = "AvailableEmployees";
            this.availableEmployeesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // availableEmployeesTableAdapter
            // 
            this.availableEmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // lblRequestCaption
            // 
            this.lblRequestCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRequestCaption.Location = new System.Drawing.Point(9, 7);
            this.lblRequestCaption.Name = "lblRequestCaption";
            this.lblRequestCaption.Size = new System.Drawing.Size(355, 33);
            this.lblRequestCaption.TabIndex = 102;
            this.lblRequestCaption.Text = "Введите код (адр. книги JD) виновного сотрудника или выберите его из списка двойн" +
                "ым кликом:";
            // 
            // tbFaultEmployeeID
            // 
            this.tbFaultEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFaultEmployeeID.Location = new System.Drawing.Point(367, 12);
            this.tbFaultEmployeeID.MaxLength = 10;
            this.tbFaultEmployeeID.Name = "tbFaultEmployeeID";
            this.tbFaultEmployeeID.Size = new System.Drawing.Size(57, 22);
            this.tbFaultEmployeeID.TabIndex = 103;
            this.tbFaultEmployeeID.Text = "0";
            // 
            // tbNameFilter
            // 
            this.tbNameFilter.Location = new System.Drawing.Point(183, 61);
            this.tbNameFilter.MaxLength = 50;
            this.tbNameFilter.Name = "tbNameFilter";
            this.tbNameFilter.Size = new System.Drawing.Size(241, 20);
            this.tbNameFilter.TabIndex = 104;
            this.tbNameFilter.TextChanged += new System.EventHandler(this.tbNameFilter_TextChanged);
            // 
            // lblNameFilterCaption
            // 
            this.lblNameFilterCaption.AutoSize = true;
            this.lblNameFilterCaption.Location = new System.Drawing.Point(12, 64);
            this.lblNameFilterCaption.Name = "lblNameFilterCaption";
            this.lblNameFilterCaption.Size = new System.Drawing.Size(165, 13);
            this.lblNameFilterCaption.TabIndex = 105;
            this.lblNameFilterCaption.Text = "Быстрый поиск по части ФИО:";
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 1000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // chbDepartment
            // 
            this.chbDepartment.AutoSize = true;
            this.chbDepartment.Location = new System.Drawing.Point(12, 306);
            this.chbDepartment.Name = "chbDepartment";
            this.chbDepartment.Size = new System.Drawing.Size(104, 17);
            this.chbDepartment.TabIndex = 106;
            this.chbDepartment.Text = "Виновен отдел:";
            this.chbDepartment.UseVisualStyleBackColor = true;
            this.chbDepartment.CheckedChanged += new System.EventHandler(this.chbDepartment_CheckedChanged);
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.DataSource = this.bsCoDepartments;
            this.cmbDepartments.DisplayMember = "department";
            this.cmbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(12, 329);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(311, 21);
            this.cmbDepartments.TabIndex = 107;
            this.cmbDepartments.ValueMember = "department_id";
            // 
            // bsCoDepartments
            // 
            this.bsCoDepartments.DataMember = "CO_Get_Available_department";
            this.bsCoDepartments.DataSource = this.complaints;
            // 
            // taCoDepartment
            // 
            this.taCoDepartment.ClearBeforeFill = true;
            // 
            // EnterFaultEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 430);
            this.Controls.Add(this.cmbDepartments);
            this.Controls.Add(this.chbDepartment);
            this.Controls.Add(this.lblNameFilterCaption);
            this.Controls.Add(this.tbNameFilter);
            this.Controls.Add(this.tbFaultEmployeeID);
            this.Controls.Add(this.lblRequestCaption);
            this.Controls.Add(this.dgvEmployees);
            this.Name = "EnterFaultEmployeeForm";
            this.Text = "Выбор виновного сотрудника/отдела";
            this.Load += new System.EventHandler(this.EnterFaultEmployeeForm_Load);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvEmployees, 0);
            this.Controls.SetChildIndex(this.lblRequestCaption, 0);
            this.Controls.SetChildIndex(this.tbFaultEmployeeID, 0);
            this.Controls.SetChildIndex(this.tbNameFilter, 0);
            this.Controls.SetChildIndex(this.lblNameFilterCaption, 0);
            this.Controls.SetChildIndex(this.chbDepartment, 0);
            this.Controls.SetChildIndex(this.cmbDepartments, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoDepartments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource availableEmployeesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableEmployeesTableAdapter availableEmployeesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRequestCaption;
        private System.Windows.Forms.TextBox tbFaultEmployeeID;
        private System.Windows.Forms.TextBox tbNameFilter;
        private System.Windows.Forms.Label lblNameFilterCaption;
        private System.Windows.Forms.Timer delayTimer;
        private System.Windows.Forms.CheckBox chbDepartment;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.BindingSource bsCoDepartments;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Get_Available_departmentTableAdapter taCoDepartment;
    }
}