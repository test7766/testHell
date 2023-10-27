namespace WMSOffice.Dialogs.Quality
{
    partial class QualityInputControlsFindApprovedShipmentsForm
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
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(353, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(443, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 148);
            this.pnlButtons.Size = new System.Drawing.Size(414, 43);
            this.pnlButtons.TabIndex = 7;
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(295, 21);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.ShowCheckBox = true;
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 3;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(234, 25);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(55, 13);
            this.lblPeriodTo.TabIndex = 2;
            this.lblPeriodTo.Text = "Дата ПО:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(59, 21);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.ShowCheckBox = true;
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 1;
            this.dtpPeriodFrom.ValueChanged += new System.EventHandler(this.dtpPeriodFrom_ValueChanged);
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(7, 25);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(46, 13);
            this.lblPeriodFrom.TabIndex = 0;
            this.lblPeriodFrom.Text = "Дата С:";
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouse.Location = new System.Drawing.Point(165, 76);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.ReadOnly = true;
            this.tbWarehouse.Size = new System.Drawing.Size(230, 20);
            this.tbWarehouse.TabIndex = 6;
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(59, 76);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.NavigateByValue = false;
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouse.TabIndex = 5;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 80);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse.TabIndex = 4;
            this.lblWarehouse.Text = "Склад:";
            // 
            // QualityInputControlsFindApprovedShipmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 191);
            this.Controls.Add(this.tbWarehouse);
            this.Controls.Add(this.stbWarehouse);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.dtpPeriodTo);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.dtpPeriodFrom);
            this.Controls.Add(this.lblPeriodFrom);
            this.Name = "QualityInputControlsFindApprovedShipmentsForm";
            this.Text = "Параметры поиска протокола контроля условий транспортировки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityInputControlsFindApprovedShipmentsForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblPeriodFrom, 0);
            this.Controls.SetChildIndex(this.dtpPeriodFrom, 0);
            this.Controls.SetChildIndex(this.lblPeriodTo, 0);
            this.Controls.SetChildIndex(this.dtpPeriodTo, 0);
            this.Controls.SetChildIndex(this.lblWarehouse, 0);
            this.Controls.SetChildIndex(this.stbWarehouse, 0);
            this.Controls.SetChildIndex(this.tbWarehouse, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.TextBox tbWarehouse;
        private Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
    }
}