namespace WMSOffice.Dialogs.Receive
{
    partial class LimesLoadingWorkModeForm
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
            this.lbWorkModes = new System.Windows.Forms.ListBox();
            this.receive = new WMSOffice.Data.Receive();
            this.limesLoadingModesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.limesLoadingModesTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.LimesLoadingModesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.limesLoadingModesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWorkModes
            // 
            this.lbWorkModes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWorkModes.DataSource = this.limesLoadingModesBindingSource;
            this.lbWorkModes.DisplayMember = "modeName";
            this.lbWorkModes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWorkModes.FormattingEnabled = true;
            this.lbWorkModes.ItemHeight = 20;
            this.lbWorkModes.Location = new System.Drawing.Point(0, 2);
            this.lbWorkModes.Name = "lbWorkModes";
            this.lbWorkModes.Size = new System.Drawing.Size(284, 204);
            this.lbWorkModes.TabIndex = 101;
            this.lbWorkModes.ValueMember = "mode_id";
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // limesLoadingModesBindingSource
            // 
            this.limesLoadingModesBindingSource.DataMember = "LimesLoadingModes";
            this.limesLoadingModesBindingSource.DataSource = this.receive;
            // 
            // limesLoadingModesTableAdapter
            // 
            this.limesLoadingModesTableAdapter.ClearBeforeFill = true;
            // 
            // LimesLoadingWorkModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbWorkModes);
            this.Name = "LimesLoadingWorkModeForm";
            this.Text = "Выберите режим работы";
            this.Load += new System.EventHandler(this.LimesLoadingWorkModeForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LimesLoadingWorkModeForm_FormClosing);
            this.Controls.SetChildIndex(this.lbWorkModes, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.limesLoadingModesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbWorkModes;
        private System.Windows.Forms.BindingSource limesLoadingModesBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.LimesLoadingModesTableAdapter limesLoadingModesTableAdapter;
    }
}