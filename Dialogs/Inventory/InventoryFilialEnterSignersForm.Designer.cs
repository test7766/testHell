namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryFilialEnterSignersForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblOrserNumber = new System.Windows.Forms.Label();
            this.tbxOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.clEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiGetElementsForSigners = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.lblNameFilterCaption = new System.Windows.Forms.Label();
            this.tbNameFilter = new System.Windows.Forms.TextBox();
            this.dgvInvEmployee = new System.Windows.Forms.DataGridView();
            this.clIsHead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clExEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clExEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiGetElementsForSigners1 = new System.Windows.Forms.BindingSource(this.components);
            this.inventory1 = new WMSOffice.Data.Inventory();
            this.btnRemoveEmployee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taFiGetElementsForSigners = new WMSOffice.Data.InventoryTableAdapters.FI_Get_Elements_For_SignersTableAdapter();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiGetElementsForSigners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiGetElementsForSigners1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(974, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(893, 410);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblOrserNumber
            // 
            this.lblOrserNumber.AutoSize = true;
            this.lblOrserNumber.Location = new System.Drawing.Point(12, 9);
            this.lblOrserNumber.Name = "lblOrserNumber";
            this.lblOrserNumber.Size = new System.Drawing.Size(89, 13);
            this.lblOrserNumber.TabIndex = 2;
            this.lblOrserNumber.Text = "Номер приказа:";
            // 
            // tbxOrderNumber
            // 
            this.tbxOrderNumber.Location = new System.Drawing.Point(107, 6);
            this.tbxOrderNumber.Name = "tbxOrderNumber";
            this.tbxOrderNumber.Size = new System.Drawing.Size(118, 20);
            this.tbxOrderNumber.TabIndex = 3;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(330, 9);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(81, 13);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "Дата приказа:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(417, 6);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(118, 20);
            this.dtpOrderDate.TabIndex = 5;
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.Location = new System.Drawing.Point(12, 46);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.dgvEmployees);
            this.spcMain.Panel1.Controls.Add(this.lblNameFilterCaption);
            this.spcMain.Panel1.Controls.Add(this.tbNameFilter);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgvInvEmployee);
            this.spcMain.Panel2.Controls.Add(this.btnRemoveEmployee);
            this.spcMain.Panel2.Controls.Add(this.btnAddEmployee);
            this.spcMain.Size = new System.Drawing.Size(1037, 358);
            this.spcMain.SplitterDistance = 533;
            this.spcMain.TabIndex = 6;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToResizeRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoGenerateColumns = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clEmployeeID,
            this.clEmployee});
            this.dgvEmployees.DataSource = this.bsFiGetElementsForSigners;
            this.dgvEmployees.Location = new System.Drawing.Point(6, 35);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(524, 320);
            this.dgvEmployees.TabIndex = 108;
            // 
            // clEmployeeID
            // 
            this.clEmployeeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clEmployeeID.DataPropertyName = "Employee_ID";
            this.clEmployeeID.HeaderText = "ID сотрудника";
            this.clEmployeeID.Name = "clEmployeeID";
            this.clEmployeeID.ReadOnly = true;
            this.clEmployeeID.Width = 96;
            // 
            // clEmployee
            // 
            this.clEmployee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clEmployee.DataPropertyName = "Employee_Name";
            this.clEmployee.HeaderText = "ФИО сотрудника";
            this.clEmployee.Name = "clEmployee";
            this.clEmployee.ReadOnly = true;
            this.clEmployee.Width = 110;
            // 
            // bsFiGetElementsForSigners
            // 
            this.bsFiGetElementsForSigners.DataMember = "FI_Get_Elements_For_Signers";
            this.bsFiGetElementsForSigners.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblNameFilterCaption
            // 
            this.lblNameFilterCaption.AutoSize = true;
            this.lblNameFilterCaption.Location = new System.Drawing.Point(3, 12);
            this.lblNameFilterCaption.Name = "lblNameFilterCaption";
            this.lblNameFilterCaption.Size = new System.Drawing.Size(165, 13);
            this.lblNameFilterCaption.TabIndex = 107;
            this.lblNameFilterCaption.Text = "Быстрый поиск по части ФИО:";
            // 
            // tbNameFilter
            // 
            this.tbNameFilter.Location = new System.Drawing.Point(174, 9);
            this.tbNameFilter.MaxLength = 50;
            this.tbNameFilter.Name = "tbNameFilter";
            this.tbNameFilter.Size = new System.Drawing.Size(241, 20);
            this.tbNameFilter.TabIndex = 106;
            this.tbNameFilter.TextChanged += new System.EventHandler(this.tbNameFilter_TextChanged);
            this.tbNameFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNameFilter_KeyDown);
            // 
            // dgvInvEmployee
            // 
            this.dgvInvEmployee.AllowUserToAddRows = false;
            this.dgvInvEmployee.AllowUserToDeleteRows = false;
            this.dgvInvEmployee.AllowUserToResizeRows = false;
            this.dgvInvEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvEmployee.AutoGenerateColumns = false;
            this.dgvInvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clIsHead,
            this.clExEmployeeID,
            this.clExEmployeeName});
            this.dgvInvEmployee.DataSource = this.bsFiGetElementsForSigners1;
            this.dgvInvEmployee.Location = new System.Drawing.Point(57, 35);
            this.dgvInvEmployee.Name = "dgvInvEmployee";
            this.dgvInvEmployee.RowHeadersVisible = false;
            this.dgvInvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvEmployee.Size = new System.Drawing.Size(440, 320);
            this.dgvInvEmployee.TabIndex = 2;
            this.dgvInvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvEmployee_CellContentClick);
            // 
            // clIsHead
            // 
            this.clIsHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clIsHead.DataPropertyName = "Checked";
            this.clIsHead.HeaderText = "Председатель";
            this.clIsHead.Name = "clIsHead";
            this.clIsHead.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clIsHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clIsHead.Width = 105;
            // 
            // clExEmployeeID
            // 
            this.clExEmployeeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clExEmployeeID.DataPropertyName = "Employee_ID";
            this.clExEmployeeID.HeaderText = "ID сотрудника";
            this.clExEmployeeID.Name = "clExEmployeeID";
            this.clExEmployeeID.ReadOnly = true;
            this.clExEmployeeID.Width = 96;
            // 
            // clExEmployeeName
            // 
            this.clExEmployeeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clExEmployeeName.DataPropertyName = "Employee_Name";
            this.clExEmployeeName.HeaderText = "ФИО сотрудника";
            this.clExEmployeeName.Name = "clExEmployeeName";
            this.clExEmployeeName.ReadOnly = true;
            this.clExEmployeeName.Width = 110;
            // 
            // bsFiGetElementsForSigners1
            // 
            this.bsFiGetElementsForSigners1.DataMember = "FI_Get_Elements_For_Signers";
            this.bsFiGetElementsForSigners1.DataSource = this.inventory1;
            // 
            // inventory1
            // 
            this.inventory1.DataSetName = "Inventory";
            this.inventory1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRemoveEmployee
            // 
            this.btnRemoveEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemoveEmployee.Image = global::WMSOffice.Properties.Resources.arrow_left;
            this.btnRemoveEmployee.Location = new System.Drawing.Point(3, 176);
            this.btnRemoveEmployee.Name = "btnRemoveEmployee";
            this.btnRemoveEmployee.Size = new System.Drawing.Size(48, 46);
            this.btnRemoveEmployee.TabIndex = 1;
            this.btnRemoveEmployee.UseVisualStyleBackColor = true;
            this.btnRemoveEmployee.Click += new System.EventHandler(this.btnRemoveEmployee_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddEmployee.Image = global::WMSOffice.Properties.Resources.arrow_right;
            this.btnAddEmployee.Location = new System.Drawing.Point(3, 124);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(48, 46);
            this.btnAddEmployee.TabIndex = 0;
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 1000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Employee_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID сотрудника";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Employee_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "ФИО сотрудника";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Председатель";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Employee_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ID сотрудника";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Employee_Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "ФИО сотрудника";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // taFiGetElementsForSigners
            // 
            this.taFiGetElementsForSigners.ClearBeforeFill = true;
            // 
            // InventoryFilialEnterSignersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1061, 445);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.tbxOrderNumber);
            this.Controls.Add(this.lblOrserNumber);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "InventoryFilialEnterSignersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Внесение данных о членах комиссии";
            this.Load += new System.EventHandler(this.InventoryFilialEnterSignersForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryFilialEnterSignersForm_FormClosing);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiGetElementsForSigners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiGetElementsForSigners1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblOrserNumber;
        private System.Windows.Forms.TextBox tbxOrderNumber;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label lblNameFilterCaption;
        private System.Windows.Forms.TextBox tbNameFilter;
        private System.Windows.Forms.Timer delayTimer;
        private System.Windows.Forms.BindingSource bsFiGetElementsForSigners;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FI_Get_Elements_For_SignersTableAdapter taFiGetElementsForSigners;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmployee;
        private System.Windows.Forms.Button btnRemoveEmployee;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.DataGridView dgvInvEmployee;
        private WMSOffice.Data.Inventory inventory1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource bsFiGetElementsForSigners1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn clExEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clExEmployeeName;
    }
}