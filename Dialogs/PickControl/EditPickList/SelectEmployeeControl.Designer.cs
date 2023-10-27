namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    partial class SelectEmployeeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.lblEmployeeResult = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEmployee
            // 
            this.tbEmployee.Location = new System.Drawing.Point(214, 4);
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.Size = new System.Drawing.Size(100, 20);
            this.tbEmployee.TabIndex = 0;
            this.tbEmployee.TextChanged += new System.EventHandler(this.tbEmployee_TextChanged);
            this.tbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmployee_KeyDown);
            // 
            // lblEmployeeResult
            // 
            this.lblEmployeeResult.AutoSize = true;
            this.lblEmployeeResult.Location = new System.Drawing.Point(320, 7);
            this.lblEmployeeResult.Name = "lblEmployeeResult";
            this.lblEmployeeResult.Size = new System.Drawing.Size(30, 13);
            this.lblEmployeeResult.TabIndex = 1;
            this.lblEmployeeResult.Text = "(нет)";
            // 
            // lblEmployee
            // 
            this.lblEmployee.Location = new System.Drawing.Point(3, 7);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(205, 17);
            this.lblEmployee.TabIndex = 2;
            this.lblEmployee.Text = "Сотрудник:";
            this.lblEmployee.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SelectEmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblEmployeeResult);
            this.Controls.Add(this.tbEmployee);
            this.Name = "SelectEmployeeControl";
            this.Size = new System.Drawing.Size(600, 26);
            this.Load += new System.EventHandler(this.SelectEmployeeControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.Label lblEmployeeResult;
        private System.Windows.Forms.Label lblEmployee;
    }
}
