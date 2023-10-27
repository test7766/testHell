namespace WMSOffice.Dialogs.WH
{
    partial class EmloyeesForMotivationForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvEmployees = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1241, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1331, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 518);
            this.pnlButtons.Size = new System.Drawing.Size(884, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvEmployees);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(884, 518);
            this.pnlContent.TabIndex = 101;
            // 
            // xdgvEmployees
            // 
            this.xdgvEmployees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvEmployees.LargeAmountOfData = false;
            this.xdgvEmployees.Location = new System.Drawing.Point(0, 0);
            this.xdgvEmployees.Name = "xdgvEmployees";
            this.xdgvEmployees.RowHeadersVisible = false;
            this.xdgvEmployees.Size = new System.Drawing.Size(884, 518);
            this.xdgvEmployees.TabIndex = 0;
            this.xdgvEmployees.UserID = ((long)(0));
            // 
            // EmloyeesForMotivationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.pnlContent);
            this.Name = "EmloyeesForMotivationForm";
            this.Text = "Выбор сотрудника для просмотра мотивации";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmloyeesForMotivationForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvEmployees;
    }
}