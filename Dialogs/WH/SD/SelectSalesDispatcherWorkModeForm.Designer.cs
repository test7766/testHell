namespace WMSOffice.Dialogs.WH.SD
{
    partial class SelectSalesDispatcherWorkModeForm
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
            this.lblWorkModes = new System.Windows.Forms.ListBox();
            this.salesDispatcherModesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.salesDispatcherModesTableAdapter = new WMSOffice.Data.WHTableAdapters.SalesDispatcherModesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesDispatcherModesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(259, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(349, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(324, 43);
            // 
            // lblWorkModes
            // 
            this.lblWorkModes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkModes.DataSource = this.salesDispatcherModesBindingSource;
            this.lblWorkModes.DisplayMember = "Mode";
            this.lblWorkModes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWorkModes.FormattingEnabled = true;
            this.lblWorkModes.ItemHeight = 20;
            this.lblWorkModes.Location = new System.Drawing.Point(0, 2);
            this.lblWorkModes.Name = "lblWorkModes";
            this.lblWorkModes.Size = new System.Drawing.Size(324, 204);
            this.lblWorkModes.TabIndex = 101;
            this.lblWorkModes.ValueMember = "Mode_ID";
            // 
            // salesDispatcherModesBindingSource
            // 
            this.salesDispatcherModesBindingSource.DataMember = "SalesDispatcherModes";
            this.salesDispatcherModesBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesDispatcherModesTableAdapter
            // 
            this.salesDispatcherModesTableAdapter.ClearBeforeFill = true;
            // 
            // SelectSalesDispatcherWorkModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 262);
            this.Controls.Add(this.lblWorkModes);
            this.Name = "SelectSalesDispatcherWorkModeForm";
            this.Text = "Выберите режим работы с диспетчером продаж";
            this.Load += new System.EventHandler(this.SelectSalesDispatcherWorkModeForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectSalesDispatcherWorkModeForm_FormClosing);
            this.Controls.SetChildIndex(this.lblWorkModes, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.salesDispatcherModesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lblWorkModes;
        private System.Windows.Forms.BindingSource salesDispatcherModesBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.SalesDispatcherModesTableAdapter salesDispatcherModesTableAdapter;
    }
}