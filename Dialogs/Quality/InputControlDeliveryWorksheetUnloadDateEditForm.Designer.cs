namespace WMSOffice.Dialogs.Quality
{
    partial class InputControlDeliveryWorksheetUnloadDateEditForm 
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
            this.dtShipmentUnloadingDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbShipmentNotYetUnloaded = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-91, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-1, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 68);
            this.pnlButtons.Size = new System.Drawing.Size(284, 43);
            // 
            // dtShipmentUnloadingDate
            // 
            this.dtShipmentUnloadingDate.CustomFormat = "dd.MM.yyyy HH:mm ";
            this.dtShipmentUnloadingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShipmentUnloadingDate.Location = new System.Drawing.Point(70, 10);
            this.dtShipmentUnloadingDate.Name = "dtShipmentUnloadingDate";
            this.dtShipmentUnloadingDate.Size = new System.Drawing.Size(177, 20);
            this.dtShipmentUnloadingDate.TabIndex = 101;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.lifetime;
            this.pictureBox1.Location = new System.Drawing.Point(4, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            // 
            // cbShipmentNotYetUnloaded
            // 
            this.cbShipmentNotYetUnloaded.AutoSize = true;
            this.cbShipmentNotYetUnloaded.Location = new System.Drawing.Point(70, 41);
            this.cbShipmentNotYetUnloaded.Name = "cbShipmentNotYetUnloaded";
            this.cbShipmentNotYetUnloaded.Size = new System.Drawing.Size(177, 17);
            this.cbShipmentNotYetUnloaded.TabIndex = 103;
            this.cbShipmentNotYetUnloaded.Text = "Поставка еще не разгружена";
            this.cbShipmentNotYetUnloaded.UseVisualStyleBackColor = true;
            this.cbShipmentNotYetUnloaded.CheckedChanged += new System.EventHandler(this.cbShipmentNotYetUnloaded_CheckedChanged);
            // 
            // InputControlDeliveryWorksheetUnloadDateEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.cbShipmentNotYetUnloaded);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtShipmentUnloadingDate);
            this.Name = "InputControlDeliveryWorksheetUnloadDateEditForm";
            this.Text = "Укажите дату и время разгрузки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputControlDeliveryWorksheetUnloadDateEditForm_FormClosing);
            this.Controls.SetChildIndex(this.dtShipmentUnloadingDate, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cbShipmentNotYetUnloaded, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtShipmentUnloadingDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbShipmentNotYetUnloaded;
    }
}