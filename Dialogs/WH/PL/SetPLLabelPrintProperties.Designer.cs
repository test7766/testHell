namespace WMSOffice.Dialogs.WH.PL
{
    partial class SetPLLabelPrintProperties
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
            this.nudLabelsCount = new System.Windows.Forms.NumericUpDown();
            this.lblLabelsCount = new System.Windows.Forms.Label();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.pLSSCCPrinterListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.pL_SSCC_PrinterListTableAdapter = new WMSOffice.Data.WHTableAdapters.PL_SSCC_PrinterListTableAdapter();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.lblSSCCType = new System.Windows.Forms.Label();
            this.cmbSSCCTypes = new System.Windows.Forms.ComboBox();
            this.sSCCTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sSCCTypesTableAdapter = new WMSOffice.Data.WHTableAdapters.SSCCTypesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLabelsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLSSCCPrinterListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSCCTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(61, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 129);
            this.pnlButtons.Size = new System.Drawing.Size(294, 43);
            // 
            // nudLabelsCount
            // 
            this.nudLabelsCount.Location = new System.Drawing.Point(82, 88);
            this.nudLabelsCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudLabelsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLabelsCount.Name = "nudLabelsCount";
            this.nudLabelsCount.Size = new System.Drawing.Size(75, 20);
            this.nudLabelsCount.TabIndex = 101;
            this.nudLabelsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblLabelsCount
            // 
            this.lblLabelsCount.Location = new System.Drawing.Point(13, 88);
            this.lblLabelsCount.Name = "lblLabelsCount";
            this.lblLabelsCount.Size = new System.Drawing.Size(57, 34);
            this.lblLabelsCount.TabIndex = 102;
            this.lblLabelsCount.Text = "Кол-во этикеток:";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DataSource = this.pLSSCCPrinterListBindingSource;
            this.cmbPrinters.DisplayMember = "PrinterName";
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(82, 19);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(200, 21);
            this.cmbPrinters.TabIndex = 103;
            this.cmbPrinters.ValueMember = "Printer_ID";
            // 
            // pLSSCCPrinterListBindingSource
            // 
            this.pLSSCCPrinterListBindingSource.DataMember = "PL_SSCC_PrinterList";
            this.pLSSCCPrinterListBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pL_SSCC_PrinterListTableAdapter
            // 
            this.pL_SSCC_PrinterListTableAdapter.ClearBeforeFill = true;
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(13, 23);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(53, 13);
            this.lblPrinter.TabIndex = 104;
            this.lblPrinter.Text = "Принтер:";
            // 
            // lblSSCCType
            // 
            this.lblSSCCType.AutoSize = true;
            this.lblSSCCType.Location = new System.Drawing.Point(13, 58);
            this.lblSSCCType.Name = "lblSSCCType";
            this.lblSSCCType.Size = new System.Drawing.Size(60, 13);
            this.lblSSCCType.TabIndex = 105;
            this.lblSSCCType.Text = "Тип SSCC:";
            // 
            // cmbSSCCTypes
            // 
            this.cmbSSCCTypes.DataSource = this.sSCCTypesBindingSource;
            this.cmbSSCCTypes.DisplayMember = "pl_type_dsc";
            this.cmbSSCCTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSSCCTypes.FormattingEnabled = true;
            this.cmbSSCCTypes.Location = new System.Drawing.Point(82, 54);
            this.cmbSSCCTypes.Name = "cmbSSCCTypes";
            this.cmbSSCCTypes.Size = new System.Drawing.Size(200, 21);
            this.cmbSSCCTypes.TabIndex = 106;
            this.cmbSSCCTypes.ValueMember = "pl_type_id";
            // 
            // sSCCTypesBindingSource
            // 
            this.sSCCTypesBindingSource.DataMember = "SSCCTypes";
            this.sSCCTypesBindingSource.DataSource = this.wH;
            // 
            // sSCCTypesTableAdapter
            // 
            this.sSCCTypesTableAdapter.ClearBeforeFill = true;
            // 
            // SetPLLabelPrintProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 172);
            this.Controls.Add(this.cmbSSCCTypes);
            this.Controls.Add(this.lblSSCCType);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.cmbPrinters);
            this.Controls.Add(this.lblLabelsCount);
            this.Controls.Add(this.nudLabelsCount);
            this.Name = "SetPLLabelPrintProperties";
            this.Text = "Параметры печати этикеток для ПЛ";
            this.Controls.SetChildIndex(this.nudLabelsCount, 0);
            this.Controls.SetChildIndex(this.lblLabelsCount, 0);
            this.Controls.SetChildIndex(this.cmbPrinters, 0);
            this.Controls.SetChildIndex(this.lblPrinter, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblSSCCType, 0);
            this.Controls.SetChildIndex(this.cmbSSCCTypes, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLabelsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLSSCCPrinterListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSCCTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudLabelsCount;
        private System.Windows.Forms.Label lblLabelsCount;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.BindingSource pLSSCCPrinterListBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.PL_SSCC_PrinterListTableAdapter pL_SSCC_PrinterListTableAdapter;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.Label lblSSCCType;
        private System.Windows.Forms.ComboBox cmbSSCCTypes;
        private System.Windows.Forms.BindingSource sSCCTypesBindingSource;
        private WMSOffice.Data.WHTableAdapters.SSCCTypesTableAdapter sSCCTypesTableAdapter;
    }
}