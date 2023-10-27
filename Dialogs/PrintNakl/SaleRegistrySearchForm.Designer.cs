namespace WMSOffice.Dialogs.PrintNakl
{
    partial class SaleRegistrySearchForm
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
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.gbDataInterval = new System.Windows.Forms.GroupBox();
            this.gbDataInterval.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStartDate.Location = new System.Drawing.Point(10, 25);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(45, 13);
            this.lblStartDate.TabIndex = 101;
            this.lblStartDate.Text = "Дата с:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEndDate.Location = new System.Drawing.Point(10, 52);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(51, 13);
            this.lblEndDate.TabIndex = 102;
            this.lblEndDate.Text = "Дата по:";
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "dd / MM / yyyy";
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(70, 25);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(147, 20);
            this.dtStartDate.TabIndex = 103;
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "dd / MM / yyyy";
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(70, 52);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(147, 20);
            this.dtEndDate.TabIndex = 104;
            // 
            // gbDataInterval
            // 
            this.gbDataInterval.Controls.Add(this.dtStartDate);
            this.gbDataInterval.Controls.Add(this.dtEndDate);
            this.gbDataInterval.Controls.Add(this.lblStartDate);
            this.gbDataInterval.Controls.Add(this.lblEndDate);
            this.gbDataInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDataInterval.Location = new System.Drawing.Point(12, 12);
            this.gbDataInterval.Name = "gbDataInterval";
            this.gbDataInterval.Size = new System.Drawing.Size(256, 87);
            this.gbDataInterval.TabIndex = 105;
            this.gbDataInterval.TabStop = false;
            this.gbDataInterval.Text = "по диапазону дат:";
            // 
            // SaleRegistrySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 143);
            this.Controls.Add(this.gbDataInterval);
            this.Name = "SaleRegistrySearchForm";
            this.Text = "Параметры поиска реестров реализации";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaleRegistrySearchForm_FormClosing);
            this.Controls.SetChildIndex(this.gbDataInterval, 0);
            this.gbDataInterval.ResumeLayout(false);
            this.gbDataInterval.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.GroupBox gbDataInterval;
    }
}