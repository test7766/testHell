namespace WMSOffice.Dialogs.Sert
{
    partial class SertPrintSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SertPrintSettingsForm));
            this.gbSertDB = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tbSertDBPassword = new System.Windows.Forms.TextBox();
            this.lblSertDBPassword = new System.Windows.Forms.Label();
            this.tbSertDBUserID = new System.Windows.Forms.TextBox();
            this.lblSertDBUserID = new System.Windows.Forms.Label();
            this.tbSertDBInitialCatalog = new System.Windows.Forms.TextBox();
            this.lblSertDBInitialCatalog = new System.Windows.Forms.Label();
            this.tbSertDBDataSource = new System.Windows.Forms.TextBox();
            this.lblSertDBDataSource = new System.Windows.Forms.Label();
            this.btnGetDefaultSettingsFromDB = new System.Windows.Forms.Button();
            this.gbPrinter = new System.Windows.Forms.GroupBox();
            this.cbCustomPagesInBatch = new System.Windows.Forms.ComboBox();
            this.lblCustomPagesInBatch = new System.Windows.Forms.Label();
            this.chkbUseLimitOfPages = new System.Windows.Forms.CheckBox();
            this.cbCustomScale = new System.Windows.Forms.ComboBox();
            this.cbCustomPrintMode = new System.Windows.Forms.ComboBox();
            this.lblCustomScale = new System.Windows.Forms.Label();
            this.cbCustomPrinterName = new System.Windows.Forms.ComboBox();
            this.chkbIgnoreScale = new System.Windows.Forms.CheckBox();
            this.chkbIgnorePrintMode = new System.Windows.Forms.CheckBox();
            this.lblCustomPrintMode = new System.Windows.Forms.Label();
            this.chkbUseDefaultPrinter = new System.Windows.Forms.CheckBox();
            this.lblCustomPrinterName = new System.Windows.Forms.Label();
            this.gbCheckHistory = new System.Windows.Forms.GroupBox();
            this.nudCustomNoPrintDaysCount = new System.Windows.Forms.NumericUpDown();
            this.chkbIgnoreCheckHistory = new System.Windows.Forms.CheckBox();
            this.lblCustomNoPrintDaysCount = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSertDB.SuspendLayout();
            this.gbPrinter.SuspendLayout();
            this.gbCheckHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustomNoPrintDaysCount)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSertDB
            // 
            this.gbSertDB.Controls.Add(this.btnTestConnection);
            this.gbSertDB.Controls.Add(this.tbSertDBPassword);
            this.gbSertDB.Controls.Add(this.lblSertDBPassword);
            this.gbSertDB.Controls.Add(this.tbSertDBUserID);
            this.gbSertDB.Controls.Add(this.lblSertDBUserID);
            this.gbSertDB.Controls.Add(this.tbSertDBInitialCatalog);
            this.gbSertDB.Controls.Add(this.lblSertDBInitialCatalog);
            this.gbSertDB.Controls.Add(this.tbSertDBDataSource);
            this.gbSertDB.Controls.Add(this.lblSertDBDataSource);
            this.gbSertDB.Enabled = false;
            this.gbSertDB.Location = new System.Drawing.Point(12, 44);
            this.gbSertDB.Name = "gbSertDB";
            this.gbSertDB.Size = new System.Drawing.Size(460, 146);
            this.gbSertDB.TabIndex = 1;
            this.gbSertDB.TabStop = false;
            this.gbSertDB.Text = "Підключення до бази сертифікатів";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Image = ((System.Drawing.Image)(resources.GetObject("btnTestConnection.Image")));
            this.btnTestConnection.Location = new System.Drawing.Point(321, 114);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(133, 26);
            this.btnTestConnection.TabIndex = 9;
            this.btnTestConnection.Text = "Тест підключення";
            this.btnTestConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // tbSertDBPassword
            // 
            this.tbSertDBPassword.Location = new System.Drawing.Point(205, 89);
            this.tbSertDBPassword.MaxLength = 30;
            this.tbSertDBPassword.Name = "tbSertDBPassword";
            this.tbSertDBPassword.PasswordChar = '*';
            this.tbSertDBPassword.Size = new System.Drawing.Size(249, 20);
            this.tbSertDBPassword.TabIndex = 8;
            // 
            // lblSertDBPassword
            // 
            this.lblSertDBPassword.AutoSize = true;
            this.lblSertDBPassword.Location = new System.Drawing.Point(6, 92);
            this.lblSertDBPassword.Name = "lblSertDBPassword";
            this.lblSertDBPassword.Size = new System.Drawing.Size(188, 13);
            this.lblSertDBPassword.TabIndex = 7;
            this.lblSertDBPassword.Text = "Пароль користувача SQL-сервера";
            // 
            // tbSertDBUserID
            // 
            this.tbSertDBUserID.Location = new System.Drawing.Point(205, 65);
            this.tbSertDBUserID.MaxLength = 30;
            this.tbSertDBUserID.Name = "tbSertDBUserID";
            this.tbSertDBUserID.Size = new System.Drawing.Size(249, 20);
            this.tbSertDBUserID.TabIndex = 6;
            // 
            // lblSertDBUserID
            // 
            this.lblSertDBUserID.AutoSize = true;
            this.lblSertDBUserID.Location = new System.Drawing.Point(6, 68);
            this.lblSertDBUserID.Name = "lblSertDBUserID";
            this.lblSertDBUserID.Size = new System.Drawing.Size(181, 13);
            this.lblSertDBUserID.TabIndex = 5;
            this.lblSertDBUserID.Text = "Логін користувача SQL-сервера";
            // 
            // tbSertDBInitialCatalog
            // 
            this.tbSertDBInitialCatalog.Location = new System.Drawing.Point(205, 41);
            this.tbSertDBInitialCatalog.MaxLength = 30;
            this.tbSertDBInitialCatalog.Name = "tbSertDBInitialCatalog";
            this.tbSertDBInitialCatalog.Size = new System.Drawing.Size(249, 20);
            this.tbSertDBInitialCatalog.TabIndex = 4;
            // 
            // lblSertDBInitialCatalog
            // 
            this.lblSertDBInitialCatalog.AutoSize = true;
            this.lblSertDBInitialCatalog.Location = new System.Drawing.Point(6, 44);
            this.lblSertDBInitialCatalog.Name = "lblSertDBInitialCatalog";
            this.lblSertDBInitialCatalog.Size = new System.Drawing.Size(180, 13);
            this.lblSertDBInitialCatalog.TabIndex = 3;
            this.lblSertDBInitialCatalog.Text = "Назва бази (зазвичай SertClient)";
            // 
            // tbSertDBDataSource
            // 
            this.tbSertDBDataSource.Location = new System.Drawing.Point(205, 17);
            this.tbSertDBDataSource.MaxLength = 30;
            this.tbSertDBDataSource.Name = "tbSertDBDataSource";
            this.tbSertDBDataSource.Size = new System.Drawing.Size(249, 20);
            this.tbSertDBDataSource.TabIndex = 2;
            // 
            // lblSertDBDataSource
            // 
            this.lblSertDBDataSource.AutoSize = true;
            this.lblSertDBDataSource.Location = new System.Drawing.Point(6, 20);
            this.lblSertDBDataSource.Name = "lblSertDBDataSource";
            this.lblSertDBDataSource.Size = new System.Drawing.Size(126, 13);
            this.lblSertDBDataSource.TabIndex = 1;
            this.lblSertDBDataSource.Text = "Назва SQL-сервера";
            // 
            // btnGetDefaultSettingsFromDB
            // 
            this.btnGetDefaultSettingsFromDB.Image = ((System.Drawing.Image)(resources.GetObject("btnGetDefaultSettingsFromDB.Image")));
            this.btnGetDefaultSettingsFromDB.Location = new System.Drawing.Point(12, 12);
            this.btnGetDefaultSettingsFromDB.Name = "btnGetDefaultSettingsFromDB";
            this.btnGetDefaultSettingsFromDB.Size = new System.Drawing.Size(275, 26);
            this.btnGetDefaultSettingsFromDB.TabIndex = 0;
            this.btnGetDefaultSettingsFromDB.Text = "Завантажити шаблон налаштувань із бази даних";
            this.btnGetDefaultSettingsFromDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGetDefaultSettingsFromDB.UseVisualStyleBackColor = true;
            this.btnGetDefaultSettingsFromDB.Click += new System.EventHandler(this.btnGetDefaultSettingsFromDB_Click);
            // 
            // gbPrinter
            // 
            this.gbPrinter.Controls.Add(this.cbCustomPagesInBatch);
            this.gbPrinter.Controls.Add(this.lblCustomPagesInBatch);
            this.gbPrinter.Controls.Add(this.chkbUseLimitOfPages);
            this.gbPrinter.Controls.Add(this.cbCustomScale);
            this.gbPrinter.Controls.Add(this.cbCustomPrintMode);
            this.gbPrinter.Controls.Add(this.lblCustomScale);
            this.gbPrinter.Controls.Add(this.cbCustomPrinterName);
            this.gbPrinter.Controls.Add(this.chkbIgnoreScale);
            this.gbPrinter.Controls.Add(this.chkbIgnorePrintMode);
            this.gbPrinter.Controls.Add(this.lblCustomPrintMode);
            this.gbPrinter.Controls.Add(this.chkbUseDefaultPrinter);
            this.gbPrinter.Controls.Add(this.lblCustomPrinterName);
            this.gbPrinter.Location = new System.Drawing.Point(12, 196);
            this.gbPrinter.Name = "gbPrinter";
            this.gbPrinter.Size = new System.Drawing.Size(460, 222);
            this.gbPrinter.TabIndex = 2;
            this.gbPrinter.TabStop = false;
            this.gbPrinter.Text = "Налаштування друку";
            // 
            // cbCustomPagesInBatch
            // 
            this.cbCustomPagesInBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomPagesInBatch.Enabled = false;
            this.cbCustomPagesInBatch.FormattingEnabled = true;
            this.cbCustomPagesInBatch.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
            this.cbCustomPagesInBatch.Location = new System.Drawing.Point(371, 184);
            this.cbCustomPagesInBatch.Name = "cbCustomPagesInBatch";
            this.cbCustomPagesInBatch.Size = new System.Drawing.Size(83, 21);
            this.cbCustomPagesInBatch.TabIndex = 5;
            // 
            // lblCustomPagesInBatch
            // 
            this.lblCustomPagesInBatch.AutoSize = true;
            this.lblCustomPagesInBatch.Enabled = false;
            this.lblCustomPagesInBatch.Location = new System.Drawing.Point(6, 187);
            this.lblCustomPagesInBatch.Name = "lblCustomPagesInBatch";
            this.lblCustomPagesInBatch.Size = new System.Drawing.Size(243, 13);
            this.lblCustomPagesInBatch.TabIndex = 4;
            this.lblCustomPagesInBatch.Text = "Макс. кількість сторінок в одному документі";
            // 
            // chkbUseLimitOfPages
            // 
            this.chkbUseLimitOfPages.AutoSize = true;
            this.chkbUseLimitOfPages.Location = new System.Drawing.Point(9, 163);
            this.chkbUseLimitOfPages.Name = "chkbUseLimitOfPages";
            this.chkbUseLimitOfPages.Size = new System.Drawing.Size(291, 17);
            this.chkbUseLimitOfPages.TabIndex = 3;
            this.chkbUseLimitOfPages.Text = "Обмежити кількість сторінок в одному документі";
            this.chkbUseLimitOfPages.UseVisualStyleBackColor = true;
            this.chkbUseLimitOfPages.CheckedChanged += new System.EventHandler(this.chkbUseLimitOfPages_CheckedChanged);
            // 
            // cbCustomScale
            // 
            this.cbCustomScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomScale.Enabled = false;
            this.cbCustomScale.FormattingEnabled = true;
            this.cbCustomScale.Items.AddRange(new object[] {
            "1 х 1",
            "1 х 2",
            "1 х 4"});
            this.cbCustomScale.Location = new System.Drawing.Point(371, 136);
            this.cbCustomScale.Name = "cbCustomScale";
            this.cbCustomScale.Size = new System.Drawing.Size(83, 21);
            this.cbCustomScale.TabIndex = 2;
            // 
            // cbCustomPrintMode
            // 
            this.cbCustomPrintMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomPrintMode.Enabled = false;
            this.cbCustomPrintMode.FormattingEnabled = true;
            this.cbCustomPrintMode.Items.AddRange(new object[] {
            "Односторонній",
            "Двохсторонній: нова серія - новий аркуш",
            "Двохсторонній: новий товар - новий аркуш",
            "Двохсторонній: суцільний потік"});
            this.cbCustomPrintMode.Location = new System.Drawing.Point(161, 88);
            this.cbCustomPrintMode.Name = "cbCustomPrintMode";
            this.cbCustomPrintMode.Size = new System.Drawing.Size(293, 21);
            this.cbCustomPrintMode.TabIndex = 2;
            // 
            // lblCustomScale
            // 
            this.lblCustomScale.AutoSize = true;
            this.lblCustomScale.Enabled = false;
            this.lblCustomScale.Location = new System.Drawing.Point(6, 139);
            this.lblCustomScale.Name = "lblCustomScale";
            this.lblCustomScale.Size = new System.Drawing.Size(133, 13);
            this.lblCustomScale.TabIndex = 1;
            this.lblCustomScale.Text = "Інший масштаб виводу";
            // 
            // cbCustomPrinterName
            // 
            this.cbCustomPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomPrinterName.FormattingEnabled = true;
            this.cbCustomPrinterName.Location = new System.Drawing.Point(161, 40);
            this.cbCustomPrinterName.Name = "cbCustomPrinterName";
            this.cbCustomPrinterName.Size = new System.Drawing.Size(293, 21);
            this.cbCustomPrinterName.TabIndex = 2;
            // 
            // chkbIgnoreScale
            // 
            this.chkbIgnoreScale.AutoSize = true;
            this.chkbIgnoreScale.Location = new System.Drawing.Point(9, 115);
            this.chkbIgnoreScale.Name = "chkbIgnoreScale";
            this.chkbIgnoreScale.Size = new System.Drawing.Size(266, 17);
            this.chkbIgnoreScale.TabIndex = 0;
            this.chkbIgnoreScale.Text = "Ігнорувати масштаб, що вказано в завданнях";
            this.chkbIgnoreScale.UseVisualStyleBackColor = true;
            this.chkbIgnoreScale.CheckedChanged += new System.EventHandler(this.chkbIgnoreScale_CheckedChanged);
            // 
            // chkbIgnorePrintMode
            // 
            this.chkbIgnorePrintMode.AutoSize = true;
            this.chkbIgnorePrintMode.Location = new System.Drawing.Point(9, 67);
            this.chkbIgnorePrintMode.Name = "chkbIgnorePrintMode";
            this.chkbIgnorePrintMode.Size = new System.Drawing.Size(231, 17);
            this.chkbIgnorePrintMode.TabIndex = 0;
            this.chkbIgnorePrintMode.Text = "Ігнорувати режим друку в завданнях";
            this.chkbIgnorePrintMode.UseVisualStyleBackColor = true;
            this.chkbIgnorePrintMode.CheckedChanged += new System.EventHandler(this.chkbIgnorePrintMode_CheckedChanged);
            // 
            // lblCustomPrintMode
            // 
            this.lblCustomPrintMode.AutoSize = true;
            this.lblCustomPrintMode.Enabled = false;
            this.lblCustomPrintMode.Location = new System.Drawing.Point(6, 91);
            this.lblCustomPrintMode.Name = "lblCustomPrintMode";
            this.lblCustomPrintMode.Size = new System.Drawing.Size(81, 13);
            this.lblCustomPrintMode.TabIndex = 1;
            this.lblCustomPrintMode.Text = "Інший режим";
            // 
            // chkbUseDefaultPrinter
            // 
            this.chkbUseDefaultPrinter.AutoSize = true;
            this.chkbUseDefaultPrinter.Location = new System.Drawing.Point(9, 19);
            this.chkbUseDefaultPrinter.Name = "chkbUseDefaultPrinter";
            this.chkbUseDefaultPrinter.Size = new System.Drawing.Size(217, 17);
            this.chkbUseDefaultPrinter.TabIndex = 0;
            this.chkbUseDefaultPrinter.Text = "Використати принтер за замовчуванням";
            this.chkbUseDefaultPrinter.UseVisualStyleBackColor = true;
            this.chkbUseDefaultPrinter.CheckedChanged += new System.EventHandler(this.chkbUseDefaultPrinter_CheckedChanged);
            // 
            // lblCustomPrinterName
            // 
            this.lblCustomPrinterName.AutoSize = true;
            this.lblCustomPrinterName.Location = new System.Drawing.Point(6, 43);
            this.lblCustomPrinterName.Name = "lblCustomPrinterName";
            this.lblCustomPrinterName.Size = new System.Drawing.Size(149, 13);
            this.lblCustomPrinterName.TabIndex = 1;
            this.lblCustomPrinterName.Text = "Назва іншого принтера";
            // 
            // gbCheckHistory
            // 
            this.gbCheckHistory.Controls.Add(this.nudCustomNoPrintDaysCount);
            this.gbCheckHistory.Controls.Add(this.chkbIgnoreCheckHistory);
            this.gbCheckHistory.Controls.Add(this.lblCustomNoPrintDaysCount);
            this.gbCheckHistory.Location = new System.Drawing.Point(12, 424);
            this.gbCheckHistory.Name = "gbCheckHistory";
            this.gbCheckHistory.Size = new System.Drawing.Size(460, 72);
            this.gbCheckHistory.TabIndex = 4;
            this.gbCheckHistory.TabStop = false;
            this.gbCheckHistory.Text = "Перевірка історії";
            // 
            // nudCustomNoPrintDaysCount
            // 
            this.nudCustomNoPrintDaysCount.Enabled = false;
            this.nudCustomNoPrintDaysCount.Location = new System.Drawing.Point(371, 42);
            this.nudCustomNoPrintDaysCount.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudCustomNoPrintDaysCount.Name = "nudCustomNoPrintDaysCount";
            this.nudCustomNoPrintDaysCount.Size = new System.Drawing.Size(83, 20);
            this.nudCustomNoPrintDaysCount.TabIndex = 2;
            this.nudCustomNoPrintDaysCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkbIgnoreCheckHistory
            // 
            this.chkbIgnoreCheckHistory.AutoSize = true;
            this.chkbIgnoreCheckHistory.Location = new System.Drawing.Point(9, 19);
            this.chkbIgnoreCheckHistory.Name = "chkbIgnoreCheckHistory";
            this.chkbIgnoreCheckHistory.Size = new System.Drawing.Size(323, 17);
            this.chkbIgnoreCheckHistory.TabIndex = 0;
            this.chkbIgnoreCheckHistory.Text = "Ігнорувати значення для перевірки історії у завданнях";
            this.chkbIgnoreCheckHistory.UseVisualStyleBackColor = true;
            this.chkbIgnoreCheckHistory.CheckedChanged += new System.EventHandler(this.chkbIgnoreCheckHistory_CheckedChanged);
            // 
            // lblCustomNoPrintDaysCount
            // 
            this.lblCustomNoPrintDaysCount.AutoSize = true;
            this.lblCustomNoPrintDaysCount.Enabled = false;
            this.lblCustomNoPrintDaysCount.Location = new System.Drawing.Point(6, 45);
            this.lblCustomNoPrintDaysCount.Name = "lblCustomNoPrintDaysCount";
            this.lblCustomNoPrintDaysCount.Size = new System.Drawing.Size(196, 13);
            this.lblCustomNoPrintDaysCount.TabIndex = 1;
            this.lblCustomNoPrintDaysCount.Text = "Кількість днів від останнього друку";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(316, 502);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(397, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SertPrintSettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 535);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbCheckHistory);
            this.Controls.Add(this.gbPrinter);
            this.Controls.Add(this.btnGetDefaultSettingsFromDB);
            this.Controls.Add(this.gbSertDB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SertPrintSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Налаштування друку сертифікатів";
            this.gbSertDB.ResumeLayout(false);
            this.gbSertDB.PerformLayout();
            this.gbPrinter.ResumeLayout(false);
            this.gbPrinter.PerformLayout();
            this.gbCheckHistory.ResumeLayout(false);
            this.gbCheckHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustomNoPrintDaysCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSertDB;
        private System.Windows.Forms.TextBox tbSertDBDataSource;
        private System.Windows.Forms.Label lblSertDBDataSource;
        private System.Windows.Forms.TextBox tbSertDBPassword;
        private System.Windows.Forms.Label lblSertDBPassword;
        private System.Windows.Forms.TextBox tbSertDBUserID;
        private System.Windows.Forms.Label lblSertDBUserID;
        private System.Windows.Forms.TextBox tbSertDBInitialCatalog;
        private System.Windows.Forms.Label lblSertDBInitialCatalog;
        private System.Windows.Forms.Button btnGetDefaultSettingsFromDB;
        private System.Windows.Forms.GroupBox gbPrinter;
        private System.Windows.Forms.Label lblCustomPrinterName;
        private System.Windows.Forms.CheckBox chkbUseDefaultPrinter;
        private System.Windows.Forms.ComboBox cbCustomPrinterName;
        private System.Windows.Forms.ComboBox cbCustomPrintMode;
        private System.Windows.Forms.CheckBox chkbIgnorePrintMode;
        private System.Windows.Forms.Label lblCustomPrintMode;
        private System.Windows.Forms.GroupBox gbCheckHistory;
        private System.Windows.Forms.CheckBox chkbIgnoreCheckHistory;
        private System.Windows.Forms.Label lblCustomNoPrintDaysCount;
        private System.Windows.Forms.NumericUpDown nudCustomNoPrintDaysCount;
        private System.Windows.Forms.CheckBox chkbIgnoreScale;
        private System.Windows.Forms.ComboBox cbCustomScale;
        private System.Windows.Forms.Label lblCustomScale;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.ComboBox cbCustomPagesInBatch;
        private System.Windows.Forms.Label lblCustomPagesInBatch;
        private System.Windows.Forms.CheckBox chkbUseLimitOfPages;
    }
}