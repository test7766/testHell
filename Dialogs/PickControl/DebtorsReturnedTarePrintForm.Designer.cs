namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTarePrintForm
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
            this.components = new System.ComponentModel.Container();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.cTPrintersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.lblTareType = new System.Windows.Forms.Label();
            this.cmbTareType = new System.Windows.Forms.ComboBox();
            this.cTTareTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblAvailableQuantity = new System.Windows.Forms.Label();
            this.tbAvailableQuantity = new System.Windows.Forms.TextBox();
            this.gbEticTypeInfo = new System.Windows.Forms.GroupBox();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.cT_PrintersTableAdapter = new WMSOffice.Data.PickControlTableAdapters.CT_PrintersTableAdapter();
            this.cT_TareTypesTableAdapter = new WMSOffice.Data.PickControlTableAdapters.CT_TareTypesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cTPrintersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTTareTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.gbEticTypeInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 203);
            this.pnlButtons.TabIndex = 7;
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DataSource = this.cTPrintersBindingSource;
            this.cmbPrinters.DisplayMember = "Print_id";
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(71, 5);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(267, 21);
            this.cmbPrinters.TabIndex = 1;
            this.cmbPrinters.ValueMember = "Print_id";
            // 
            // cTPrintersBindingSource
            // 
            this.cTPrintersBindingSource.DataMember = "CT_Printers";
            this.cTPrintersBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.AutoSize = true;
            this.lblPrinterName.Location = new System.Drawing.Point(12, 9);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(53, 13);
            this.lblPrinterName.TabIndex = 0;
            this.lblPrinterName.Text = "Принтер:";
            // 
            // lblTareType
            // 
            this.lblTareType.AutoSize = true;
            this.lblTareType.Location = new System.Drawing.Point(12, 38);
            this.lblTareType.Name = "lblTareType";
            this.lblTareType.Size = new System.Drawing.Size(57, 13);
            this.lblTareType.TabIndex = 2;
            this.lblTareType.Text = "Тип тары:";
            // 
            // cmbTareType
            // 
            this.cmbTareType.DataSource = this.cTTareTypesBindingSource;
            this.cmbTareType.DisplayMember = "Formatted_Tare_Name";
            this.cmbTareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTareType.FormattingEnabled = true;
            this.cmbTareType.Location = new System.Drawing.Point(71, 34);
            this.cmbTareType.Name = "cmbTareType";
            this.cmbTareType.Size = new System.Drawing.Size(267, 21);
            this.cmbTareType.TabIndex = 3;
            this.cmbTareType.ValueMember = "Tare_Name";
            this.cmbTareType.SelectedValueChanged += new System.EventHandler(this.cmbTareType_SelectedValueChanged);
            // 
            // cTTareTypesBindingSource
            // 
            this.cTTareTypesBindingSource.DataMember = "CT_TareTypes";
            this.cTTareTypesBindingSource.DataSource = this.pickControl;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(232, 170);
            this.nudQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(106, 20);
            this.nudQuantity.TabIndex = 6;
            this.nudQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(25, 170);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(44, 26);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Кол-во \r\nкопий:";
            // 
            // lblAvailableQuantity
            // 
            this.lblAvailableQuantity.AutoSize = true;
            this.lblAvailableQuantity.Location = new System.Drawing.Point(96, 73);
            this.lblAvailableQuantity.Name = "lblAvailableQuantity";
            this.lblAvailableQuantity.Size = new System.Drawing.Size(59, 13);
            this.lblAvailableQuantity.TabIndex = 4;
            this.lblAvailableQuantity.Text = "Доступно:";
            // 
            // tbAvailableQuantity
            // 
            this.tbAvailableQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.tbAvailableQuantity.Location = new System.Drawing.Point(161, 69);
            this.tbAvailableQuantity.Name = "tbAvailableQuantity";
            this.tbAvailableQuantity.ReadOnly = true;
            this.tbAvailableQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbAvailableQuantity.TabIndex = 5;
            // 
            // gbEticTypeInfo
            // 
            this.gbEticTypeInfo.Controls.Add(this.tbItemID);
            this.gbEticTypeInfo.Controls.Add(this.lblItemID);
            this.gbEticTypeInfo.Controls.Add(this.tbSize);
            this.gbEticTypeInfo.Controls.Add(this.lblSize);
            this.gbEticTypeInfo.Controls.Add(this.tbAvailableQuantity);
            this.gbEticTypeInfo.Controls.Add(this.lblAvailableQuantity);
            this.gbEticTypeInfo.Location = new System.Drawing.Point(71, 62);
            this.gbEticTypeInfo.Name = "gbEticTypeInfo";
            this.gbEticTypeInfo.Size = new System.Drawing.Size(267, 100);
            this.gbEticTypeInfo.TabIndex = 4;
            this.gbEticTypeInfo.TabStop = false;
            this.gbEticTypeInfo.Text = "Параметры";
            // 
            // tbItemID
            // 
            this.tbItemID.BackColor = System.Drawing.SystemColors.Window;
            this.tbItemID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cTTareTypesBindingSource, "Item_id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbItemID.Location = new System.Drawing.Point(161, 41);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.ReadOnly = true;
            this.tbItemID.Size = new System.Drawing.Size(100, 20);
            this.tbItemID.TabIndex = 3;
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(126, 45);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(29, 13);
            this.lblItemID.TabIndex = 2;
            this.lblItemID.Text = "Код:";
            // 
            // tbSize
            // 
            this.tbSize.BackColor = System.Drawing.SystemColors.Window;
            this.tbSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cTTareTypesBindingSource, "Measurement", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbSize.Location = new System.Drawing.Point(161, 13);
            this.tbSize.Name = "tbSize";
            this.tbSize.ReadOnly = true;
            this.tbSize.Size = new System.Drawing.Size(100, 20);
            this.tbSize.TabIndex = 1;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(106, 17);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(49, 13);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Размер:";
            // 
            // cT_PrintersTableAdapter
            // 
            this.cT_PrintersTableAdapter.ClearBeforeFill = true;
            // 
            // cT_TareTypesTableAdapter
            // 
            this.cT_TareTypesTableAdapter.ClearBeforeFill = true;
            // 
            // DebtorsReturnedTarePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 246);
            this.Controls.Add(this.gbEticTypeInfo);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblTareType);
            this.Controls.Add(this.cmbTareType);
            this.Controls.Add(this.lblPrinterName);
            this.Controls.Add(this.cmbPrinters);
            this.Name = "DebtorsReturnedTarePrintForm";
            this.Text = "Печать этикеток";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebtorsReturnedTarePrintForm_FormClosing);
            this.Load += new System.EventHandler(this.DebtorsReturnedTarePrintForm_Load);
            this.Controls.SetChildIndex(this.cmbPrinters, 0);
            this.Controls.SetChildIndex(this.lblPrinterName, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cmbTareType, 0);
            this.Controls.SetChildIndex(this.lblTareType, 0);
            this.Controls.SetChildIndex(this.nudQuantity, 0);
            this.Controls.SetChildIndex(this.lblQuantity, 0);
            this.Controls.SetChildIndex(this.gbEticTypeInfo, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cTPrintersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTTareTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.gbEticTypeInfo.ResumeLayout(false);
            this.gbEticTypeInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.Label lblPrinterName;
        private System.Windows.Forms.Label lblTareType;
        private System.Windows.Forms.ComboBox cmbTareType;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblAvailableQuantity;
        private System.Windows.Forms.TextBox tbAvailableQuantity;
        private System.Windows.Forms.GroupBox gbEticTypeInfo;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label lblSize;
        private Data.PickControl pickControl;
        private System.Windows.Forms.BindingSource cTPrintersBindingSource;
        private Data.PickControlTableAdapters.CT_PrintersTableAdapter cT_PrintersTableAdapter;
        private System.Windows.Forms.BindingSource cTTareTypesBindingSource;
        private Data.PickControlTableAdapters.CT_TareTypesTableAdapter cT_TareTypesTableAdapter;
    }
}