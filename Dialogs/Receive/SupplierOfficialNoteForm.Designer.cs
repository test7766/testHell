namespace WMSOffice.Dialogs.Receive
{
    partial class SupplierOfficialNoteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbOfficialNoteNumber = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 88);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 46);
            this.label1.TabIndex = 101;
            this.label1.Text = "Введите № запроса на возврат оборотной тары:";
            // 
            // tbOfficialNoteNumber
            // 
            this.tbOfficialNoteNumber.Location = new System.Drawing.Point(4, 58);
            this.tbOfficialNoteNumber.MaxLength = 50;
            this.tbOfficialNoteNumber.Name = "tbOfficialNoteNumber";
            this.tbOfficialNoteNumber.Size = new System.Drawing.Size(178, 20);
            this.tbOfficialNoteNumber.TabIndex = 102;
            // 
            // SupplierOfficialNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOfficialNoteNumber);
            this.Name = "SupplierOfficialNoteForm";
            this.Text = "Служебная записка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SupplierOfficialNoteForm_FormClosing);
            this.Controls.SetChildIndex(this.tbOfficialNoteNumber, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOfficialNoteNumber;
    }
}