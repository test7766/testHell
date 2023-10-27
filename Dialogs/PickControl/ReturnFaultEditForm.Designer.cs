namespace WMSOffice.Dialogs.PickControl
{
    partial class ReturnFaultEditForm
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
            this.cbFaultType = new System.Windows.Forms.ComboBox();
            this.returnFaultTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.lblFaultType = new System.Windows.Forms.Label();
            this.lblFaultEmployee = new System.Windows.Forms.Label();
            this.cbFaultEmployee = new System.Windows.Forms.ComboBox();
            this.docStatusEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.returnFaultTypesTableAdapter = new WMSOffice.Data.PickControlTableAdapters.ReturnFaultTypesTableAdapter();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.returnFaultTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docStatusEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(151, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(241, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 145);
            this.pnlButtons.Size = new System.Drawing.Size(328, 43);
            // 
            // cbFaultType
            // 
            this.cbFaultType.DataSource = this.returnFaultTypesBindingSource;
            this.cbFaultType.DisplayMember = "Description";
            this.cbFaultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaultType.FormattingEnabled = true;
            this.cbFaultType.Location = new System.Drawing.Point(12, 25);
            this.cbFaultType.Name = "cbFaultType";
            this.cbFaultType.Size = new System.Drawing.Size(216, 21);
            this.cbFaultType.TabIndex = 101;
            this.cbFaultType.ValueMember = "Type_ID";
            // 
            // returnFaultTypesBindingSource
            // 
            this.returnFaultTypesBindingSource.DataMember = "ReturnFaultTypes";
            this.returnFaultTypesBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblFaultType
            // 
            this.lblFaultType.AutoSize = true;
            this.lblFaultType.Location = new System.Drawing.Point(12, 9);
            this.lblFaultType.Name = "lblFaultType";
            this.lblFaultType.Size = new System.Drawing.Size(109, 13);
            this.lblFaultType.TabIndex = 102;
            this.lblFaultType.Text = "Тип корректировки:";
            // 
            // lblFaultEmployee
            // 
            this.lblFaultEmployee.AutoSize = true;
            this.lblFaultEmployee.Location = new System.Drawing.Point(12, 49);
            this.lblFaultEmployee.Name = "lblFaultEmployee";
            this.lblFaultEmployee.Size = new System.Drawing.Size(144, 13);
            this.lblFaultEmployee.TabIndex = 104;
            this.lblFaultEmployee.Text = "Ответственный сотрудник:";
            // 
            // cbFaultEmployee
            // 
            this.cbFaultEmployee.DataSource = this.docStatusEmployeesBindingSource;
            this.cbFaultEmployee.DisplayMember = "Employee_Name";
            this.cbFaultEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaultEmployee.FormattingEnabled = true;
            this.cbFaultEmployee.Location = new System.Drawing.Point(12, 65);
            this.cbFaultEmployee.Name = "cbFaultEmployee";
            this.cbFaultEmployee.Size = new System.Drawing.Size(304, 21);
            this.cbFaultEmployee.TabIndex = 103;
            this.cbFaultEmployee.ValueMember = "Employee_ID";
            // 
            // docStatusEmployeesBindingSource
            // 
            this.docStatusEmployeesBindingSource.DataMember = "DocStatusEmployees";
            this.docStatusEmployeesBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // returnFaultTypesTableAdapter
            // 
            this.returnFaultTypesTableAdapter.ClearBeforeFill = true;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 89);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(107, 13);
            this.lblQuantity.TabIndex = 105;
            this.lblQuantity.Text = "Количество товара:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbQuantity.Location = new System.Drawing.Point(12, 105);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(100, 26);
            this.tbQuantity.TabIndex = 106;
            this.tbQuantity.Text = "0";
            this.tbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ReturnFaultEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 188);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblFaultEmployee);
            this.Controls.Add(this.cbFaultEmployee);
            this.Controls.Add(this.lblFaultType);
            this.Controls.Add(this.cbFaultType);
            this.Name = "ReturnFaultEditForm";
            this.Text = "Выберите причину корректировки";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cbFaultType, 0);
            this.Controls.SetChildIndex(this.lblFaultType, 0);
            this.Controls.SetChildIndex(this.cbFaultEmployee, 0);
            this.Controls.SetChildIndex(this.lblFaultEmployee, 0);
            this.Controls.SetChildIndex(this.lblQuantity, 0);
            this.Controls.SetChildIndex(this.tbQuantity, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.returnFaultTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docStatusEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFaultType;
        private System.Windows.Forms.Label lblFaultType;
        private System.Windows.Forms.Label lblFaultEmployee;
        private System.Windows.Forms.ComboBox cbFaultEmployee;
        private WMSOffice.Data.PickControl pickControl;
        private System.Windows.Forms.BindingSource returnFaultTypesBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.ReturnFaultTypesTableAdapter returnFaultTypesTableAdapter;
        private System.Windows.Forms.BindingSource docStatusEmployeesBindingSource;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbQuantity;
    }
}