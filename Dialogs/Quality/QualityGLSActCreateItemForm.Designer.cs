namespace WMSOffice.Dialogs.Quality
{
    partial class QualityGLSActCreateItemForm
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.lblManufacturerName = new System.Windows.Forms.Label();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.tbLotNumber = new System.Windows.Forms.TextBox();
            this.tbVendorName = new System.Windows.Forms.TextBox();
            this.tbManufacturerName = new System.Windows.Forms.TextBox();
            this.quality = new WMSOffice.Data.Quality();
            this.gAItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gA_ItemsTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_ItemsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(317, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 128);
            this.pnlButtons.Size = new System.Drawing.Size(494, 43);
            this.pnlButtons.TabIndex = 8;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.ForeColor = System.Drawing.Color.Brown;
            this.lblItemName.Location = new System.Drawing.Point(12, 12);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(121, 13);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Назва товара";
            // 
            // tbItemName
            // 
            this.tbItemName.BackColor = System.Drawing.SystemColors.Info;
            this.tbItemName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gAItemsBindingSource, "ItemName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbItemName.Location = new System.Drawing.Point(149, 8);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(333, 20);
            this.tbItemName.TabIndex = 1;
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.AutoSize = true;
            this.lblLotNumber.Location = new System.Drawing.Point(12, 41);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(38, 13);
            this.lblLotNumber.TabIndex = 2;
            this.lblLotNumber.Text = "Серія";
            // 
            // lblManufacturerName
            // 
            this.lblManufacturerName.AutoSize = true;
            this.lblManufacturerName.ForeColor = System.Drawing.Color.Brown;
            this.lblManufacturerName.Location = new System.Drawing.Point(12, 70);
            this.lblManufacturerName.Name = "lblManufacturerName";
            this.lblManufacturerName.Size = new System.Drawing.Size(86, 13);
            this.lblManufacturerName.TabIndex = 4;
            this.lblManufacturerName.Text = "Виробник";
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.ForeColor = System.Drawing.Color.Brown;
            this.lblVendorName.Location = new System.Drawing.Point(12, 99);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(65, 13);
            this.lblVendorName.TabIndex = 6;
            this.lblVendorName.Text = "Постачальник";
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gAItemsBindingSource, "LotNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbLotNumber.Location = new System.Drawing.Point(149, 37);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.Size = new System.Drawing.Size(333, 20);
            this.tbLotNumber.TabIndex = 3;
            // 
            // tbVendorName
            // 
            this.tbVendorName.BackColor = System.Drawing.SystemColors.Info;
            this.tbVendorName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gAItemsBindingSource, "CurrVendorName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbVendorName.Location = new System.Drawing.Point(149, 95);
            this.tbVendorName.Name = "tbVendorName";
            this.tbVendorName.Size = new System.Drawing.Size(333, 20);
            this.tbVendorName.TabIndex = 7;
            // 
            // tbManufacturerName
            // 
            this.tbManufacturerName.BackColor = System.Drawing.SystemColors.Info;
            this.tbManufacturerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gAItemsBindingSource, "Manufacturer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbManufacturerName.Location = new System.Drawing.Point(149, 66);
            this.tbManufacturerName.Name = "tbManufacturerName";
            this.tbManufacturerName.Size = new System.Drawing.Size(333, 20);
            this.tbManufacturerName.TabIndex = 5;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gAItemsBindingSource
            // 
            this.gAItemsBindingSource.DataMember = "GA_Items";
            this.gAItemsBindingSource.DataSource = this.quality;
            // 
            // gA_ItemsTableAdapter
            // 
            this.gA_ItemsTableAdapter.ClearBeforeFill = true;
            // 
            // QualityGLSActCreateItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 171);
            this.Controls.Add(this.tbManufacturerName);
            this.Controls.Add(this.tbVendorName);
            this.Controls.Add(this.tbLotNumber);
            this.Controls.Add(this.lblVendorName);
            this.Controls.Add(this.lblManufacturerName);
            this.Controls.Add(this.lblLotNumber);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.lblItemName);
            this.Name = "QualityGLSActCreateItemForm";
            this.Text = "Створення товара та серії для акта розпоряджень";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityGLSActCreateItemForm_FormClosing);
            this.Controls.SetChildIndex(this.lblItemName, 0);
            this.Controls.SetChildIndex(this.tbItemName, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblLotNumber, 0);
            this.Controls.SetChildIndex(this.lblManufacturerName, 0);
            this.Controls.SetChildIndex(this.lblVendorName, 0);
            this.Controls.SetChildIndex(this.tbLotNumber, 0);
            this.Controls.SetChildIndex(this.tbVendorName, 0);
            this.Controls.SetChildIndex(this.tbManufacturerName, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAItemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.Label lblManufacturerName;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.TextBox tbLotNumber;
        private System.Windows.Forms.TextBox tbVendorName;
        private System.Windows.Forms.TextBox tbManufacturerName;
        private System.Windows.Forms.BindingSource gAItemsBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.GA_ItemsTableAdapter gA_ItemsTableAdapter;
    }
}