namespace WMSOffice.Dialogs
{
    partial class ChangeUserForm
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
            this.tbEmployeeCode = new WMSOffice.Controls.TextBoxScaner();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.gvUsers = new System.Windows.Forms.DataGridView();
            this.sessionUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.access = new WMSOffice.Data.Access();
            this.sessionUsersTableAdapter = new WMSOffice.Data.AccessTableAdapters.SessionUsersTableAdapter();
            this.Employee_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warning_Message = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionUsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.access)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            //this.btnOK.Location = new System.Drawing.Point(215, 8);
            // 
            // btnCancel
            // 
            //this.btnCancel.Location = new System.Drawing.Point(296, 8);
            // 
            // tbEmployeeCode
            // 
            this.tbEmployeeCode.AllowType = true;
            this.tbEmployeeCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEmployeeCode.AutoConvert = true;
            this.tbEmployeeCode.Location = new System.Drawing.Point(108, 45);
            this.tbEmployeeCode.Name = "tbEmployeeCode";
            this.tbEmployeeCode.Size = new System.Drawing.Size(263, 25);
            this.tbEmployeeCode.TabIndex = 0;
            this.tbEmployeeCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbEmployeeCode.TextChanged += new System.EventHandler(this.tbEmployeeCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Код сотрудника:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Для начала работы необходимо отсканировать штрих-коды удостоверений сотрудников, " +
                "проводящих контроль приемки товара.\r\n";
            // 
            // groupInfo
            // 
            this.groupInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInfo.Controls.Add(this.gvUsers);
            this.groupInfo.Location = new System.Drawing.Point(12, 76);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(359, 108);
            this.groupInfo.TabIndex = 3;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "Текущая сессия:";
            // 
            // gvUsers
            // 
            this.gvUsers.AllowUserToAddRows = false;
            this.gvUsers.AllowUserToDeleteRows = false;
            this.gvUsers.AllowUserToResizeRows = false;
            this.gvUsers.AutoGenerateColumns = false;
            this.gvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Employee_ID,
            this.Employee,
            this.Login_Type,
            this.Warning_Message});
            this.gvUsers.DataSource = this.sessionUsersBindingSource;
            this.gvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvUsers.Location = new System.Drawing.Point(3, 16);
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.ReadOnly = true;
            this.gvUsers.RowHeadersVisible = false;
            this.gvUsers.Size = new System.Drawing.Size(353, 89);
            this.gvUsers.TabIndex = 0;
            this.gvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvUsers_CellContentClick);
            // 
            // sessionUsersBindingSource
            // 
            this.sessionUsersBindingSource.DataMember = "SessionUsers";
            this.sessionUsersBindingSource.DataSource = this.access;
            // 
            // access
            // 
            this.access.DataSetName = "Access";
            this.access.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sessionUsersTableAdapter
            // 
            this.sessionUsersTableAdapter.ClearBeforeFill = true;
            // 
            // Employee_ID
            // 
            this.Employee_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Employee_ID.DataPropertyName = "Employee_ID";
            this.Employee_ID.HeaderText = "Код";
            this.Employee_ID.Name = "Employee_ID";
            this.Employee_ID.ReadOnly = true;
            this.Employee_ID.Width = 51;
            // 
            // Employee
            // 
            this.Employee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Employee.DataPropertyName = "Employee";
            this.Employee.HeaderText = "Сотрудник";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            this.Employee.Width = 85;
            // 
            // Login_Type
            // 
            this.Login_Type.DataPropertyName = "Login_Type";
            this.Login_Type.HeaderText = "Тип входа";
            this.Login_Type.Name = "Login_Type";
            this.Login_Type.ReadOnly = true;
            this.Login_Type.Visible = false;
            // 
            // Warning_Message
            // 
            this.Warning_Message.DataPropertyName = "Warning_Message";
            this.Warning_Message.HeaderText = "Сообщение";
            this.Warning_Message.Name = "Warning_Message";
            this.Warning_Message.ReadOnly = true;
            this.Warning_Message.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Warning_Message.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ChangeUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 229);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEmployeeCode);
            this.Name = "ChangeUserForm";
            this.Text = "Выбор пользователя";
            this.Load += new System.EventHandler(this.ChangeUserForm_Load);
            this.Shown += new System.EventHandler(this.ChangeUserForm_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChangeUserForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeUserForm_FormClosing);
            this.Controls.SetChildIndex(this.tbEmployeeCode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupInfo, 0);
            this.groupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionUsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.access)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.TextBoxScaner tbEmployeeCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.DataGridView gvUsers;
        private System.Windows.Forms.BindingSource sessionUsersBindingSource;
        private WMSOffice.Data.Access access;
        private WMSOffice.Data.AccessTableAdapters.SessionUsersTableAdapter sessionUsersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login_Type;
        private System.Windows.Forms.DataGridViewLinkColumn Warning_Message;
    }
}