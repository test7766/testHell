namespace WMSOffice.Dialogs.PickControl
{
    partial class PresentEmployeesViewForm
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
            this.xdgvEmployees = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1293, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1383, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 409);
            this.pnlButtons.Size = new System.Drawing.Size(877, 43);
            // 
            // xdgvEmployees
            // 
            this.xdgvEmployees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvEmployees.LargeAmountOfData = false;
            this.xdgvEmployees.Location = new System.Drawing.Point(0, 4);
            this.xdgvEmployees.Name = "xdgvEmployees";
            this.xdgvEmployees.RowHeadersVisible = false;
            this.xdgvEmployees.Size = new System.Drawing.Size(877, 399);
            this.xdgvEmployees.TabIndex = 101;
            this.xdgvEmployees.UserID = ((long)(0));
            // 
            // PresentEmployeesViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 452);
            this.Controls.Add(this.xdgvEmployees);
            this.Name = "PresentEmployeesViewForm";
            this.Text = "Присутствующие сотрудники";
            this.Controls.SetChildIndex(this.xdgvEmployees, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvEmployees;
    }
}