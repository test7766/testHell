namespace WMSOffice.Dialogs.Quality
{
    partial class GTDEditorForm
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
            this.dtpDateGTD = new System.Windows.Forms.DateTimePicker();
            this.tbNumberGTD = new System.Windows.Forms.TextBox();
            this.lblNumberGTD = new System.Windows.Forms.Label();
            this.lDateGTD = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-334, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-244, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 62);
            this.pnlButtons.Size = new System.Drawing.Size(222, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // dtpDateGTD
            // 
            this.dtpDateGTD.CustomFormat = "dd.MM.yyyy";
            this.dtpDateGTD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateGTD.Location = new System.Drawing.Point(70, 36);
            this.dtpDateGTD.Name = "dtpDateGTD";
            this.dtpDateGTD.Size = new System.Drawing.Size(146, 20);
            this.dtpDateGTD.TabIndex = 3;
            // 
            // tbNumberGTD
            // 
            this.tbNumberGTD.BackColor = System.Drawing.SystemColors.Window;
            this.tbNumberGTD.Location = new System.Drawing.Point(70, 7);
            this.tbNumberGTD.Name = "tbNumberGTD";
            this.tbNumberGTD.ReadOnly = true;
            this.tbNumberGTD.Size = new System.Drawing.Size(146, 20);
            this.tbNumberGTD.TabIndex = 1;
            // 
            // lblNumberGTD
            // 
            this.lblNumberGTD.AutoSize = true;
            this.lblNumberGTD.Location = new System.Drawing.Point(12, 11);
            this.lblNumberGTD.Name = "lblNumberGTD";
            this.lblNumberGTD.Size = new System.Drawing.Size(44, 13);
            this.lblNumberGTD.TabIndex = 0;
            this.lblNumberGTD.Text = "Номер:";
            // 
            // lDateGTD
            // 
            this.lDateGTD.AutoSize = true;
            this.lDateGTD.Location = new System.Drawing.Point(12, 40);
            this.lDateGTD.Name = "lDateGTD";
            this.lDateGTD.Size = new System.Drawing.Size(36, 13);
            this.lDateGTD.TabIndex = 2;
            this.lDateGTD.Text = "Дата:";
            // 
            // GTDEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 105);
            this.Controls.Add(this.lDateGTD);
            this.Controls.Add(this.lblNumberGTD);
            this.Controls.Add(this.dtpDateGTD);
            this.Controls.Add(this.tbNumberGTD);
            this.Name = "GTDEditorForm";
            this.Text = "Корректировка ГТД";
            this.Controls.SetChildIndex(this.tbNumberGTD, 0);
            this.Controls.SetChildIndex(this.dtpDateGTD, 0);
            this.Controls.SetChildIndex(this.lblNumberGTD, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lDateGTD, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateGTD;
        private System.Windows.Forms.TextBox tbNumberGTD;
        private System.Windows.Forms.Label lblNumberGTD;
        private System.Windows.Forms.Label lDateGTD;
    }
}