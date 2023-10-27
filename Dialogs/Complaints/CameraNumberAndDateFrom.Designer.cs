namespace WMSOffice.Dialogs.Complaints
{
    partial class CameraNumberAndDateFrom
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblCameraNumber = new System.Windows.Forms.Label();
            this.tbxCameraNumber = new System.Windows.Forms.TextBox();
            this.lblProblemDate = new System.Windows.Forms.Label();
            this.dtpProblemAndDateTime = new System.Windows.Forms.DateTimePicker();
            this.chbNoDate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCancel.Location = new System.Drawing.Point(442, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnOK.Location = new System.Drawing.Point(345, 195);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCameraNumber
            // 
            this.lblCameraNumber.AutoSize = true;
            this.lblCameraNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCameraNumber.Location = new System.Drawing.Point(12, 23);
            this.lblCameraNumber.Name = "lblCameraNumber";
            this.lblCameraNumber.Size = new System.Drawing.Size(452, 18);
            this.lblCameraNumber.TabIndex = 2;
            this.lblCameraNumber.Text = "Номер камеры, под которой проводился поштучный контроль:";
            // 
            // tbxCameraNumber
            // 
            this.tbxCameraNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbxCameraNumber.Location = new System.Drawing.Point(15, 44);
            this.tbxCameraNumber.Name = "tbxCameraNumber";
            this.tbxCameraNumber.Size = new System.Drawing.Size(265, 24);
            this.tbxCameraNumber.TabIndex = 3;
            // 
            // lblProblemDate
            // 
            this.lblProblemDate.AutoSize = true;
            this.lblProblemDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblProblemDate.Location = new System.Drawing.Point(12, 110);
            this.lblProblemDate.Name = "lblProblemDate";
            this.lblProblemDate.Size = new System.Drawing.Size(362, 18);
            this.lblProblemDate.TabIndex = 4;
            this.lblProblemDate.Text = "Дата и время, когда была обнаружена проблема (";
            // 
            // dtpProblemAndDateTime
            // 
            this.dtpProblemAndDateTime.CustomFormat = "dd MMMM yyyy г.   HH:mm";
            this.dtpProblemAndDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpProblemAndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProblemAndDateTime.Location = new System.Drawing.Point(15, 131);
            this.dtpProblemAndDateTime.Name = "dtpProblemAndDateTime";
            this.dtpProblemAndDateTime.Size = new System.Drawing.Size(265, 24);
            this.dtpProblemAndDateTime.TabIndex = 5;
            // 
            // chbNoDate
            // 
            this.chbNoDate.AutoSize = true;
            this.chbNoDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chbNoDate.Location = new System.Drawing.Point(370, 109);
            this.chbNoDate.Name = "chbNoDate";
            this.chbNoDate.Size = new System.Drawing.Size(171, 22);
            this.chbNoDate.TabIndex = 6;
            this.chbNoDate.Text = "дата не определена)";
            this.chbNoDate.UseVisualStyleBackColor = true;
            this.chbNoDate.CheckedChanged += new System.EventHandler(this.chbNoDate_CheckedChanged);
            // 
            // CameraNumberAndDateFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(545, 238);
            this.Controls.Add(this.chbNoDate);
            this.Controls.Add(this.dtpProblemAndDateTime);
            this.Controls.Add(this.lblProblemDate);
            this.Controls.Add(this.tbxCameraNumber);
            this.Controls.Add(this.lblCameraNumber);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CameraNumberAndDateFrom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Номер камеры и дата обнаружения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblCameraNumber;
        private System.Windows.Forms.TextBox tbxCameraNumber;
        private System.Windows.Forms.Label lblProblemDate;
        private System.Windows.Forms.DateTimePicker dtpProblemAndDateTime;
        private System.Windows.Forms.CheckBox chbNoDate;
    }
}