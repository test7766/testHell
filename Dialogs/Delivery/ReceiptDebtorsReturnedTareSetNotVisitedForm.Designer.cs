namespace WMSOffice.Dialogs.Delivery
{
    partial class ReceiptDebtorsReturnedTareSetNotVisitedForm
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
            this.tbReasonNote = new System.Windows.Forms.TextBox();
            this.lblReasonDescription = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.cmbReasons = new System.Windows.Forms.ComboBox();
            this.checkTareInvoiceReturnNotVisitedReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.checkTareInvoiceReturnNotVisitedReasonsTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.CheckTareInvoiceReturnNotVisitedReasonsTableAdapter();
            this.lblDeliveryName = new System.Windows.Forms.Label();
            this.tbDeliveryName = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkTareInvoiceReturnNotVisitedReasonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 198);
            this.pnlButtons.TabIndex = 6;
            // 
            // tbReasonNote
            // 
            this.tbReasonNote.Location = new System.Drawing.Point(91, 122);
            this.tbReasonNote.Multiline = true;
            this.tbReasonNote.Name = "tbReasonNote";
            this.tbReasonNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReasonNote.Size = new System.Drawing.Size(247, 75);
            this.tbReasonNote.TabIndex = 5;
            // 
            // lblReasonDescription
            // 
            this.lblReasonDescription.AutoSize = true;
            this.lblReasonDescription.Location = new System.Drawing.Point(12, 122);
            this.lblReasonDescription.Name = "lblReasonDescription";
            this.lblReasonDescription.Size = new System.Drawing.Size(63, 13);
            this.lblReasonDescription.TabIndex = 4;
            this.lblReasonDescription.Text = "Описание :";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(12, 81);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(56, 13);
            this.lblReason.TabIndex = 2;
            this.lblReason.Text = "Причина :";
            // 
            // cmbReasons
            // 
            this.cmbReasons.DataSource = this.checkTareInvoiceReturnNotVisitedReasonsBindingSource;
            this.cmbReasons.DisplayMember = "Reason_Name";
            this.cmbReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasons.FormattingEnabled = true;
            this.cmbReasons.Location = new System.Drawing.Point(91, 77);
            this.cmbReasons.Name = "cmbReasons";
            this.cmbReasons.Size = new System.Drawing.Size(247, 21);
            this.cmbReasons.TabIndex = 3;
            this.cmbReasons.ValueMember = "Reason_ID";
            this.cmbReasons.SelectedValueChanged += new System.EventHandler(this.cmbReasons_SelectedValueChanged);
            // 
            // checkTareInvoiceReturnNotVisitedReasonsBindingSource
            // 
            this.checkTareInvoiceReturnNotVisitedReasonsBindingSource.DataMember = "CheckTareInvoiceReturnNotVisitedReasons";
            this.checkTareInvoiceReturnNotVisitedReasonsBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkTareInvoiceReturnNotVisitedReasonsTableAdapter
            // 
            this.checkTareInvoiceReturnNotVisitedReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // lblDeliveryName
            // 
            this.lblDeliveryName.AutoSize = true;
            this.lblDeliveryName.Location = new System.Drawing.Point(12, 12);
            this.lblDeliveryName.Name = "lblDeliveryName";
            this.lblDeliveryName.Size = new System.Drawing.Size(27, 13);
            this.lblDeliveryName.TabIndex = 0;
            this.lblDeliveryName.Text = "ТТ :";
            // 
            // tbDeliveryName
            // 
            this.tbDeliveryName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDeliveryName.Location = new System.Drawing.Point(91, 8);
            this.tbDeliveryName.Multiline = true;
            this.tbDeliveryName.Name = "tbDeliveryName";
            this.tbDeliveryName.ReadOnly = true;
            this.tbDeliveryName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDeliveryName.Size = new System.Drawing.Size(247, 45);
            this.tbDeliveryName.TabIndex = 1;
            // 
            // ReceiptDebtorsReturnedTareSetNotVisitedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 241);
            this.Controls.Add(this.tbDeliveryName);
            this.Controls.Add(this.lblDeliveryName);
            this.Controls.Add(this.cmbReasons);
            this.Controls.Add(this.lblReasonDescription);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.tbReasonNote);
            this.Name = "ReceiptDebtorsReturnedTareSetNotVisitedForm";
            this.Text = "Укажите причину непосещения ТТ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiptDebtorsReturnedTareSetNotVisitedForm_FormClosing);
            this.Controls.SetChildIndex(this.tbReasonNote, 0);
            this.Controls.SetChildIndex(this.lblReason, 0);
            this.Controls.SetChildIndex(this.lblReasonDescription, 0);
            this.Controls.SetChildIndex(this.cmbReasons, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDeliveryName, 0);
            this.Controls.SetChildIndex(this.tbDeliveryName, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkTareInvoiceReturnNotVisitedReasonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbReasonNote;
        private System.Windows.Forms.Label lblReasonDescription;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cmbReasons;
        private WMSOffice.Data.Delivery delivery;
        private System.Windows.Forms.BindingSource checkTareInvoiceReturnNotVisitedReasonsBindingSource;
        private WMSOffice.Data.DeliveryTableAdapters.CheckTareInvoiceReturnNotVisitedReasonsTableAdapter checkTareInvoiceReturnNotVisitedReasonsTableAdapter;
        private System.Windows.Forms.Label lblDeliveryName;
        private System.Windows.Forms.TextBox tbDeliveryName;
    }
}