namespace WMSOffice.Dialogs.WH
{
    partial class SubscribersForm
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
            this.cmbSign1 = new System.Windows.Forms.ComboBox();
            this.sign1_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.employeesTableAdapter = new WMSOffice.Data.WHTableAdapters.EmployeesTableAdapter();
            this.cmbSign2 = new System.Windows.Forms.ComboBox();
            this.sign2_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSign3 = new System.Windows.Forms.ComboBox();
            this.sign3_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSign4 = new System.Windows.Forms.ComboBox();
            this.sign4_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSign5 = new System.Windows.Forms.ComboBox();
            this.sign5_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSign6 = new System.Windows.Forms.ComboBox();
            this.sign6_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSign7 = new System.Windows.Forms.ComboBox();
            this.sign7_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblSign1 = new System.Windows.Forms.Label();
            this.lblSign2 = new System.Windows.Forms.Label();
            this.lblSign3 = new System.Windows.Forms.Label();
            this.lblSign4 = new System.Windows.Forms.Label();
            this.lblSign5 = new System.Windows.Forms.Label();
            this.lblSign6 = new System.Windows.Forms.Label();
            this.lblSign7 = new System.Windows.Forms.Label();
            this.lblMembers = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sign1_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign2_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign3_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign4_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign5_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign6_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign7_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(688, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(778, 8);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 259);
            this.pnlButtons.Size = new System.Drawing.Size(486, 43);
            // 
            // cmbSign1
            // 
            this.cmbSign1.DataSource = this.sign1_BindingSource;
            this.cmbSign1.DisplayMember = "Employee";
            this.cmbSign1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSign1.FormattingEnabled = true;
            this.cmbSign1.Location = new System.Drawing.Point(176, 16);
            this.cmbSign1.Name = "cmbSign1";
            this.cmbSign1.Size = new System.Drawing.Size(293, 21);
            this.cmbSign1.TabIndex = 101;
            this.cmbSign1.ValueMember = "Employee_ID";
            // 
            // sign1_BindingSource
            // 
            this.sign1_BindingSource.DataMember = "Employees";
            this.sign1_BindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
            // 
            // cmbSign2
            // 
            this.cmbSign2.DataSource = this.sign2_BindingSource;
            this.cmbSign2.DisplayMember = "Employee";
            this.cmbSign2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSign2.FormattingEnabled = true;
            this.cmbSign2.Location = new System.Drawing.Point(176, 92);
            this.cmbSign2.Name = "cmbSign2";
            this.cmbSign2.Size = new System.Drawing.Size(293, 21);
            this.cmbSign2.TabIndex = 102;
            this.cmbSign2.ValueMember = "Employee_ID";
            // 
            // sign2_BindingSource
            // 
            this.sign2_BindingSource.DataMember = "Employees";
            this.sign2_BindingSource.DataSource = this.wH;
            // 
            // cmbSign3
            // 
            this.cmbSign3.DataSource = this.sign3_BindingSource;
            this.cmbSign3.DisplayMember = "Employee";
            this.cmbSign3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSign3.FormattingEnabled = true;
            this.cmbSign3.Location = new System.Drawing.Point(176, 120);
            this.cmbSign3.Name = "cmbSign3";
            this.cmbSign3.Size = new System.Drawing.Size(293, 21);
            this.cmbSign3.TabIndex = 103;
            this.cmbSign3.ValueMember = "Employee_ID";
            // 
            // sign3_BindingSource
            // 
            this.sign3_BindingSource.DataMember = "Employees";
            this.sign3_BindingSource.DataSource = this.wH;
            // 
            // cmbSign4
            // 
            this.cmbSign4.DataSource = this.sign4_BindingSource;
            this.cmbSign4.DisplayMember = "Employee";
            this.cmbSign4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSign4.FormattingEnabled = true;
            this.cmbSign4.Location = new System.Drawing.Point(176, 148);
            this.cmbSign4.Name = "cmbSign4";
            this.cmbSign4.Size = new System.Drawing.Size(293, 21);
            this.cmbSign4.TabIndex = 104;
            this.cmbSign4.ValueMember = "Employee_ID";
            // 
            // sign4_BindingSource
            // 
            this.sign4_BindingSource.DataMember = "Employees";
            this.sign4_BindingSource.DataSource = this.wH;
            // 
            // cmbSign5
            // 
            this.cmbSign5.DataSource = this.sign5_BindingSource;
            this.cmbSign5.DisplayMember = "Employee";
            this.cmbSign5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSign5.FormattingEnabled = true;
            this.cmbSign5.Location = new System.Drawing.Point(176, 176);
            this.cmbSign5.Name = "cmbSign5";
            this.cmbSign5.Size = new System.Drawing.Size(293, 21);
            this.cmbSign5.TabIndex = 105;
            this.cmbSign5.ValueMember = "Employee_ID";
            // 
            // sign5_BindingSource
            // 
            this.sign5_BindingSource.DataMember = "Employees";
            this.sign5_BindingSource.DataSource = this.wH;
            // 
            // cmbSign6
            // 
            this.cmbSign6.DataSource = this.sign6_BindingSource;
            this.cmbSign6.DisplayMember = "Employee";
            this.cmbSign6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSign6.FormattingEnabled = true;
            this.cmbSign6.Location = new System.Drawing.Point(176, 204);
            this.cmbSign6.Name = "cmbSign6";
            this.cmbSign6.Size = new System.Drawing.Size(293, 21);
            this.cmbSign6.TabIndex = 106;
            this.cmbSign6.ValueMember = "Employee_ID";
            // 
            // sign6_BindingSource
            // 
            this.sign6_BindingSource.DataMember = "Employees";
            this.sign6_BindingSource.DataSource = this.wH;
            // 
            // cmbSign7
            // 
            this.cmbSign7.DataSource = this.sign7_BindingSource;
            this.cmbSign7.DisplayMember = "Employee";
            this.cmbSign7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSign7.FormattingEnabled = true;
            this.cmbSign7.Location = new System.Drawing.Point(176, 232);
            this.cmbSign7.Name = "cmbSign7";
            this.cmbSign7.Size = new System.Drawing.Size(293, 21);
            this.cmbSign7.TabIndex = 107;
            this.cmbSign7.ValueMember = "Employee_ID";
            // 
            // sign7_BindingSource
            // 
            this.sign7_BindingSource.DataMember = "Employees";
            this.sign7_BindingSource.DataSource = this.wH;
            // 
            // lblSign1
            // 
            this.lblSign1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSign1.Location = new System.Drawing.Point(12, 5);
            this.lblSign1.Name = "lblSign1";
            this.lblSign1.Size = new System.Drawing.Size(106, 43);
            this.lblSign1.TabIndex = 108;
            this.lblSign1.Text = "Председатель комиссии:";
            // 
            // lblSign2
            // 
            this.lblSign2.AutoSize = true;
            this.lblSign2.Location = new System.Drawing.Point(12, 96);
            this.lblSign2.Name = "lblSign2";
            this.lblSign2.Size = new System.Drawing.Size(57, 13);
            this.lblSign2.TabIndex = 109;
            this.lblSign2.Text = "директор:";
            // 
            // lblSign3
            // 
            this.lblSign3.AutoSize = true;
            this.lblSign3.Location = new System.Drawing.Point(12, 124);
            this.lblSign3.Name = "lblSign3";
            this.lblSign3.Size = new System.Drawing.Size(92, 13);
            this.lblSign3.TabIndex = 110;
            this.lblSign3.Text = "заведующая ЦС:";
            // 
            // lblSign4
            // 
            this.lblSign4.AutoSize = true;
            this.lblSign4.Location = new System.Drawing.Point(12, 152);
            this.lblSign4.Name = "lblSign4";
            this.lblSign4.Size = new System.Drawing.Size(77, 13);
            this.lblSign4.TabIndex = 111;
            this.lblSign4.Text = "ст. бухгалтер:";
            // 
            // lblSign5
            // 
            this.lblSign5.AutoSize = true;
            this.lblSign5.Location = new System.Drawing.Point(12, 180);
            this.lblSign5.Name = "lblSign5";
            this.lblSign5.Size = new System.Drawing.Size(93, 13);
            this.lblSign5.TabIndex = 112;
            this.lblSign5.Text = "и. о. нач. склада:";
            // 
            // lblSign6
            // 
            this.lblSign6.AutoSize = true;
            this.lblSign6.Location = new System.Drawing.Point(12, 208);
            this.lblSign6.Name = "lblSign6";
            this.lblSign6.Size = new System.Drawing.Size(75, 13);
            this.lblSign6.TabIndex = 113;
            this.lblSign6.Text = "ст. провизор:";
            // 
            // lblSign7
            // 
            this.lblSign7.AutoSize = true;
            this.lblSign7.Location = new System.Drawing.Point(12, 236);
            this.lblSign7.Name = "lblSign7";
            this.lblSign7.Size = new System.Drawing.Size(144, 13);
            this.lblSign7.TabIndex = 114;
            this.lblSign7.Text = "нач. приемного отдела ЦС:";
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMembers.Location = new System.Drawing.Point(12, 58);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(118, 16);
            this.lblMembers.TabIndex = 115;
            this.lblMembers.Text = "Члены комиссии:";
            // 
            // SubscribersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 302);
            this.Controls.Add(this.lblMembers);
            this.Controls.Add(this.lblSign7);
            this.Controls.Add(this.lblSign6);
            this.Controls.Add(this.lblSign5);
            this.Controls.Add(this.lblSign4);
            this.Controls.Add(this.lblSign3);
            this.Controls.Add(this.lblSign2);
            this.Controls.Add(this.lblSign1);
            this.Controls.Add(this.cmbSign7);
            this.Controls.Add(this.cmbSign6);
            this.Controls.Add(this.cmbSign5);
            this.Controls.Add(this.cmbSign4);
            this.Controls.Add(this.cmbSign3);
            this.Controls.Add(this.cmbSign2);
            this.Controls.Add(this.cmbSign1);
            this.Name = "SubscribersForm";
            this.Text = "Выберите сотрудников ответственных за подпись документа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubscribersForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbSign1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cmbSign2, 0);
            this.Controls.SetChildIndex(this.cmbSign3, 0);
            this.Controls.SetChildIndex(this.cmbSign4, 0);
            this.Controls.SetChildIndex(this.cmbSign5, 0);
            this.Controls.SetChildIndex(this.cmbSign6, 0);
            this.Controls.SetChildIndex(this.cmbSign7, 0);
            this.Controls.SetChildIndex(this.lblSign1, 0);
            this.Controls.SetChildIndex(this.lblSign2, 0);
            this.Controls.SetChildIndex(this.lblSign3, 0);
            this.Controls.SetChildIndex(this.lblSign4, 0);
            this.Controls.SetChildIndex(this.lblSign5, 0);
            this.Controls.SetChildIndex(this.lblSign6, 0);
            this.Controls.SetChildIndex(this.lblSign7, 0);
            this.Controls.SetChildIndex(this.lblMembers, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sign1_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign2_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign3_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign4_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign5_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign6_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sign7_BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSign1;
        private System.Windows.Forms.BindingSource sign1_BindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.EmployeesTableAdapter employeesTableAdapter;
        private System.Windows.Forms.ComboBox cmbSign2;
        private System.Windows.Forms.BindingSource sign2_BindingSource;
        private System.Windows.Forms.ComboBox cmbSign3;
        private System.Windows.Forms.BindingSource sign3_BindingSource;
        private System.Windows.Forms.ComboBox cmbSign4;
        private System.Windows.Forms.BindingSource sign4_BindingSource;
        private System.Windows.Forms.ComboBox cmbSign5;
        private System.Windows.Forms.BindingSource sign5_BindingSource;
        private System.Windows.Forms.ComboBox cmbSign6;
        private System.Windows.Forms.BindingSource sign6_BindingSource;
        private System.Windows.Forms.ComboBox cmbSign7;
        private System.Windows.Forms.BindingSource sign7_BindingSource;
        private System.Windows.Forms.Label lblSign1;
        private System.Windows.Forms.Label lblSign2;
        private System.Windows.Forms.Label lblSign3;
        private System.Windows.Forms.Label lblSign4;
        private System.Windows.Forms.Label lblSign5;
        private System.Windows.Forms.Label lblSign6;
        private System.Windows.Forms.Label lblSign7;
        private System.Windows.Forms.Label lblMembers;
    }
}