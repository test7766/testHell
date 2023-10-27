using System;
using System.Windows.Forms;
namespace WMSOffice.Dialogs.Quality
{
    partial class QualityLotsEditorForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVendor_Lot = new System.Windows.Forms.TextBox();
            this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(158, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(248, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 72);
            this.pnlButtons.Size = new System.Drawing.Size(334, 43);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Термін придатності:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Серія постачальника:";
            // 
            // tbVendor_Lot
            // 
            this.tbVendor_Lot.Location = new System.Drawing.Point(136, 8);
            this.tbVendor_Lot.Name = "tbVendor_Lot";
            this.tbVendor_Lot.Size = new System.Drawing.Size(187, 20);
            this.tbVendor_Lot.TabIndex = 107;
            // 
            // dtpExpDate
            // 
            this.dtpExpDate.Checked = false;
            this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpDate.Location = new System.Drawing.Point(136, 39);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.ShowCheckBox = true;
            this.dtpExpDate.Size = new System.Drawing.Size(187, 20);
            this.dtpExpDate.TabIndex = 110;
            this.dtpExpDate.Value = new System.DateTime(2023, 10, 19, 11, 27, 55, 768);
            // 
            // QualityLotsEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 115);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVendor_Lot);
            this.Controls.Add(this.dtpExpDate);
            this.Name = "QualityLotsEditorForm";
            this.Text = "Редактор партії";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityLotsEditorForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dtpExpDate, 0);
            this.Controls.SetChildIndex(this.tbVendor_Lot, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbVendor_Lot;
        public System.Windows.Forms.DateTimePicker dtpExpDate;
    }
}