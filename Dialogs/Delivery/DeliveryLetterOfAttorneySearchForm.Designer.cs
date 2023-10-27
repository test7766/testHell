namespace WMSOffice.Dialogs.Delivery
{
    partial class DeliveryLetterOfAttorneySearchForm
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbComplaintNumber = new System.Windows.Forms.TextBox();
            this.rbComplaintNumber = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-251, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-161, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 79);
            this.pnlButtons.Size = new System.Drawing.Size(244, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(132, 47);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchComponent_KeyDown);
            // 
            // tbComplaintNumber
            // 
            this.tbComplaintNumber.Location = new System.Drawing.Point(132, 18);
            this.tbComplaintNumber.Name = "tbComplaintNumber";
            this.tbComplaintNumber.Size = new System.Drawing.Size(100, 20);
            this.tbComplaintNumber.TabIndex = 1;
            this.tbComplaintNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchComponent_KeyDown);
            this.tbComplaintNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbComplaint_KeyPress);
            // 
            // rbComplaintNumber
            // 
            this.rbComplaintNumber.AutoSize = true;
            this.rbComplaintNumber.Location = new System.Drawing.Point(5, 20);
            this.rbComplaintNumber.Name = "rbComplaintNumber";
            this.rbComplaintNumber.Size = new System.Drawing.Size(92, 17);
            this.rbComplaintNumber.TabIndex = 0;
            this.rbComplaintNumber.TabStop = true;
            this.rbComplaintNumber.Text = "№ претензии";
            this.rbComplaintNumber.UseVisualStyleBackColor = true;
            this.rbComplaintNumber.CheckedChanged += new System.EventHandler(this.rbSearchComponent_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(5, 49);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(125, 17);
            this.rbDate.TabIndex = 2;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "Дата доверенности";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.CheckedChanged += new System.EventHandler(this.rbSearchComponent_CheckedChanged);
            // 
            // DeliveryLetterOfAttorneySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 122);
            this.Controls.Add(this.tbComplaintNumber);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.rbDate);
            this.Controls.Add(this.rbComplaintNumber);
            this.Name = "DeliveryLetterOfAttorneySearchForm";
            this.Text = "Поиск доверенностей";
            this.Load += new System.EventHandler(this.DeliveryLetterOfAttorneySearchForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryLetterOfAttorneySearchForm_FormClosing);
            this.Controls.SetChildIndex(this.rbComplaintNumber, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.rbDate, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.tbComplaintNumber, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox tbComplaintNumber;
        private System.Windows.Forms.RadioButton rbComplaintNumber;
        private System.Windows.Forms.RadioButton rbDate;
    }
}