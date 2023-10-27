namespace WMSOffice.Dialogs.Delivery
{
    partial class ReturnsDeliverySetMemoResultForm
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
            this.lblReason = new System.Windows.Forms.Label();
            this.cmbReasons = new System.Windows.Forms.ComboBox();
            this.cOMemoFailedReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.lblReasonDesc = new System.Windows.Forms.Label();
            this.tbReasonDesc = new System.Windows.Forms.TextBox();
            this.cO_Memo_FailedReasonsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_Memo_FailedReasonsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cOMemoFailedReasonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(169, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(259, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 108);
            this.pnlButtons.Size = new System.Drawing.Size(349, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(9, 14);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(66, 26);
            this.lblReason.TabIndex = 0;
            this.lblReason.Text = "Причина\r\nотклонения";
            // 
            // cmbReasons
            // 
            this.cmbReasons.DataSource = this.cOMemoFailedReasonsBindingSource;
            this.cmbReasons.DisplayMember = "Reason";
            this.cmbReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasons.FormattingEnabled = true;
            this.cmbReasons.Location = new System.Drawing.Point(91, 19);
            this.cmbReasons.Name = "cmbReasons";
            this.cmbReasons.Size = new System.Drawing.Size(247, 21);
            this.cmbReasons.TabIndex = 1;
            this.cmbReasons.ValueMember = "ReasonID";
            this.cmbReasons.SelectedValueChanged += new System.EventHandler(this.cmbReasons_SelectedValueChanged);
            this.cmbReasons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cOMemoFailedReasonsBindingSource
            // 
            this.cOMemoFailedReasonsBindingSource.DataMember = "CO_Memo_FailedReasons";
            this.cOMemoFailedReasonsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblReasonDesc
            // 
            this.lblReasonDesc.AutoSize = true;
            this.lblReasonDesc.Location = new System.Drawing.Point(9, 56);
            this.lblReasonDesc.Name = "lblReasonDesc";
            this.lblReasonDesc.Size = new System.Drawing.Size(57, 26);
            this.lblReasonDesc.TabIndex = 2;
            this.lblReasonDesc.Text = "Описание\r\nпричины\r\n";
            // 
            // tbReasonDesc
            // 
            this.tbReasonDesc.Location = new System.Drawing.Point(91, 56);
            this.tbReasonDesc.Multiline = true;
            this.tbReasonDesc.Name = "tbReasonDesc";
            this.tbReasonDesc.Size = new System.Drawing.Size(247, 45);
            this.tbReasonDesc.TabIndex = 3;
            this.tbReasonDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cO_Memo_FailedReasonsTableAdapter
            // 
            this.cO_Memo_FailedReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // ReturnsDeliverySetMemoResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 151);
            this.Controls.Add(this.tbReasonDesc);
            this.Controls.Add(this.lblReasonDesc);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.cmbReasons);
            this.Name = "ReturnsDeliverySetMemoResultForm";
            this.Text = "Результат сканирования служебной записки";
            this.Load += new System.EventHandler(this.ReturnsDeliverySetMemoRejectReasonForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReturnsDeliverySetMemoRejectReasonForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbReasons, 0);
            this.Controls.SetChildIndex(this.lblReason, 0);
            this.Controls.SetChildIndex(this.lblReasonDesc, 0);
            this.Controls.SetChildIndex(this.tbReasonDesc, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cOMemoFailedReasonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cmbReasons;
        private System.Windows.Forms.Label lblReasonDesc;
        private System.Windows.Forms.TextBox tbReasonDesc;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource cOMemoFailedReasonsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Memo_FailedReasonsTableAdapter cO_Memo_FailedReasonsTableAdapter;
    }
}