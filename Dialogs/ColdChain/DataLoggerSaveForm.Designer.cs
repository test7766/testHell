namespace WMSOffice.Dialogs.ColdChain
{
    partial class DataLoggerSaveForm
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
            this.lblDataLoggerPath = new System.Windows.Forms.Label();
            this.tbDataLoggerPath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dtEndTimeStamp = new System.Windows.Forms.DateTimePicker();
            this.dtStartTimeStamp = new System.Windows.Forms.DateTimePicker();
            this.gbTimeStampInfo = new System.Windows.Forms.GroupBox();
            this.lblEndTimeStamp = new System.Windows.Forms.Label();
            this.lblStartTimeStamp = new System.Windows.Forms.Label();
            this.pbSensor = new System.Windows.Forms.PictureBox();
            this.gbSensorMode = new System.Windows.Forms.GroupBox();
            this.tbSensorModeName = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.gbTimeStampInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSensor)).BeginInit();
            this.gbSensorMode.SuspendLayout();
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
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 188);
            this.pnlButtons.Size = new System.Drawing.Size(609, 43);
            // 
            // lblDataLoggerPath
            // 
            this.lblDataLoggerPath.AutoSize = true;
            this.lblDataLoggerPath.Location = new System.Drawing.Point(12, 9);
            this.lblDataLoggerPath.Name = "lblDataLoggerPath";
            this.lblDataLoggerPath.Size = new System.Drawing.Size(77, 13);
            this.lblDataLoggerPath.TabIndex = 101;
            this.lblDataLoggerPath.Text = "Путь к файлу:";
            // 
            // tbDataLoggerPath
            // 
            this.tbDataLoggerPath.Location = new System.Drawing.Point(12, 26);
            this.tbDataLoggerPath.Name = "tbDataLoggerPath";
            this.tbDataLoggerPath.Size = new System.Drawing.Size(496, 20);
            this.tbDataLoggerPath.TabIndex = 102;
            this.tbDataLoggerPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDataLoggerPath_KeyDown);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Image = global::WMSOffice.Properties.Resources.open_folder_icon;
            this.btnSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFile.Location = new System.Drawing.Point(514, 25);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(83, 23);
            this.btnSelectFile.TabIndex = 103;
            this.btnSelectFile.Text = "Выбрать";
            this.btnSelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Допустимые форматы (OPH, CSV, XLS, XLSX)|*.OPH;*.CSV;*.XLS;*.XLSX|Старый формат д" +
                "ата-логгера (OPH)|*.OPH|Новый формат дата-логгера (CSV, XLS, XLSX)|*.CSV;*.XLS;*" +
                ".XLSX";
            this.openFileDialog.Title = "Выбор файла";
            // 
            // dtEndTimeStamp
            // 
            this.dtEndTimeStamp.CustomFormat = "dd / MM / yyyy  HH:mm:ss";
            this.dtEndTimeStamp.Enabled = false;
            this.dtEndTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtEndTimeStamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTimeStamp.Location = new System.Drawing.Point(147, 44);
            this.dtEndTimeStamp.Name = "dtEndTimeStamp";
            this.dtEndTimeStamp.Size = new System.Drawing.Size(246, 20);
            this.dtEndTimeStamp.TabIndex = 104;
            // 
            // dtStartTimeStamp
            // 
            this.dtStartTimeStamp.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtStartTimeStamp.CustomFormat = "dd / MM / yyyy  HH:mm:ss";
            this.dtStartTimeStamp.Enabled = false;
            this.dtStartTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtStartTimeStamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTimeStamp.Location = new System.Drawing.Point(147, 18);
            this.dtStartTimeStamp.Name = "dtStartTimeStamp";
            this.dtStartTimeStamp.Size = new System.Drawing.Size(246, 20);
            this.dtStartTimeStamp.TabIndex = 105;
            // 
            // gbTimeStampInfo
            // 
            this.gbTimeStampInfo.Controls.Add(this.lblEndTimeStamp);
            this.gbTimeStampInfo.Controls.Add(this.dtEndTimeStamp);
            this.gbTimeStampInfo.Controls.Add(this.dtStartTimeStamp);
            this.gbTimeStampInfo.Controls.Add(this.lblStartTimeStamp);
            this.gbTimeStampInfo.Location = new System.Drawing.Point(12, 107);
            this.gbTimeStampInfo.Name = "gbTimeStampInfo";
            this.gbTimeStampInfo.Size = new System.Drawing.Size(496, 74);
            this.gbTimeStampInfo.TabIndex = 106;
            this.gbTimeStampInfo.TabStop = false;
            this.gbTimeStampInfo.Text = "Временной диапазон";
            // 
            // lblEndTimeStamp
            // 
            this.lblEndTimeStamp.AutoSize = true;
            this.lblEndTimeStamp.Location = new System.Drawing.Point(19, 48);
            this.lblEndTimeStamp.Name = "lblEndTimeStamp";
            this.lblEndTimeStamp.Size = new System.Drawing.Size(95, 13);
            this.lblEndTimeStamp.TabIndex = 1;
            this.lblEndTimeStamp.Text = "Дата и время по:";
            // 
            // lblStartTimeStamp
            // 
            this.lblStartTimeStamp.AutoSize = true;
            this.lblStartTimeStamp.Location = new System.Drawing.Point(19, 22);
            this.lblStartTimeStamp.Name = "lblStartTimeStamp";
            this.lblStartTimeStamp.Size = new System.Drawing.Size(89, 13);
            this.lblStartTimeStamp.TabIndex = 0;
            this.lblStartTimeStamp.Text = "Дата и время с:";
            // 
            // pbSensor
            // 
            this.pbSensor.Image = global::WMSOffice.Properties.Resources.Sensor;
            this.pbSensor.Location = new System.Drawing.Point(514, 101);
            this.pbSensor.Name = "pbSensor";
            this.pbSensor.Size = new System.Drawing.Size(80, 80);
            this.pbSensor.TabIndex = 107;
            this.pbSensor.TabStop = false;
            // 
            // gbSensorMode
            // 
            this.gbSensorMode.Controls.Add(this.tbSensorModeName);
            this.gbSensorMode.Location = new System.Drawing.Point(12, 54);
            this.gbSensorMode.Name = "gbSensorMode";
            this.gbSensorMode.Size = new System.Drawing.Size(496, 45);
            this.gbSensorMode.TabIndex = 108;
            this.gbSensorMode.TabStop = false;
            this.gbSensorMode.Text = "Режим t°";
            // 
            // tbSensorModeName
            // 
            this.tbSensorModeName.BackColor = System.Drawing.SystemColors.Window;
            this.tbSensorModeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSensorModeName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbSensorModeName.Location = new System.Drawing.Point(22, 16);
            this.tbSensorModeName.Name = "tbSensorModeName";
            this.tbSensorModeName.ReadOnly = true;
            this.tbSensorModeName.Size = new System.Drawing.Size(120, 20);
            this.tbSensorModeName.TabIndex = 107;
            this.tbSensorModeName.TabStop = false;
            // 
            // DataLoggerSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 231);
            this.Controls.Add(this.gbSensorMode);
            this.Controls.Add(this.pbSensor);
            this.Controls.Add(this.gbTimeStampInfo);
            this.Controls.Add(this.tbDataLoggerPath);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblDataLoggerPath);
            this.Name = "DataLoggerSaveForm";
            this.Text = "Укажите путь к файлу с данными дата-логгера";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataLoggerSaveForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataLoggerSaveForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDataLoggerPath, 0);
            this.Controls.SetChildIndex(this.btnSelectFile, 0);
            this.Controls.SetChildIndex(this.tbDataLoggerPath, 0);
            this.Controls.SetChildIndex(this.gbTimeStampInfo, 0);
            this.Controls.SetChildIndex(this.pbSensor, 0);
            this.Controls.SetChildIndex(this.gbSensorMode, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbTimeStampInfo.ResumeLayout(false);
            this.gbTimeStampInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSensor)).EndInit();
            this.gbSensorMode.ResumeLayout(false);
            this.gbSensorMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataLoggerPath;
        private System.Windows.Forms.TextBox tbDataLoggerPath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DateTimePicker dtEndTimeStamp;
        private System.Windows.Forms.DateTimePicker dtStartTimeStamp;
        private System.Windows.Forms.GroupBox gbTimeStampInfo;
        private System.Windows.Forms.Label lblEndTimeStamp;
        private System.Windows.Forms.Label lblStartTimeStamp;
        private System.Windows.Forms.PictureBox pbSensor;
        private System.Windows.Forms.GroupBox gbSensorMode;
        private System.Windows.Forms.TextBox tbSensorModeName;
    }
}