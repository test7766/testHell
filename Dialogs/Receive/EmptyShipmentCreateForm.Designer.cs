namespace WMSOffice.Dialogs.Receive
{
    partial class EmptyShipmentCreateForm
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
            this.cmbVendors = new System.Windows.Forms.ComboBox();
            this.vendorsForReturnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.label1 = new System.Windows.Forms.Label();
            this.vendorsForReturnTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.VendorsForReturnTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorsForReturnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1079, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1169, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 58);
            this.pnlButtons.Size = new System.Drawing.Size(494, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // cmbVendors
            // 
            this.cmbVendors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVendors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVendors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVendors.DataSource = this.vendorsForReturnBindingSource;
            this.cmbVendors.DisplayMember = "Vendor";
            this.cmbVendors.FormattingEnabled = true;
            this.cmbVendors.Location = new System.Drawing.Point(79, 16);
            this.cmbVendors.Name = "cmbVendors";
            this.cmbVendors.Size = new System.Drawing.Size(403, 21);
            this.cmbVendors.TabIndex = 0;
            this.cmbVendors.ValueMember = "Vendor_ID";
            // 
            // vendorsForReturnBindingSource
            // 
            this.vendorsForReturnBindingSource.DataMember = "VendorsForReturn";
            this.vendorsForReturnBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Поставщик:";
            // 
            // vendorsForReturnTableAdapter
            // 
            this.vendorsForReturnTableAdapter.ClearBeforeFill = true;
            // 
            // EmptyShipmentCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 101);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVendors);
            this.Name = "EmptyShipmentCreateForm";
            this.Text = "Поставка для возврата паллет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmptyShipmentCreateForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbVendors, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vendorsForReturnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVendors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource vendorsForReturnBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.VendorsForReturnTableAdapter vendorsForReturnTableAdapter;
    }
}