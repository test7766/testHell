namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintActCloseForm
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
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            this.cOVendorAgreementResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.cO_Vendor_Agreement_ResultsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_Vendor_Agreement_ResultsTableAdapter();
            this.lblNote = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cOVendorAgreementResultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(161, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 118);
            this.pnlButtons.Size = new System.Drawing.Size(344, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(15, 25);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(62, 13);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Результат:";
            // 
            // cmbResult
            // 
            this.cmbResult.DataSource = this.cOVendorAgreementResultsBindingSource;
            this.cmbResult.DisplayMember = "ResultName";
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Location = new System.Drawing.Point(94, 22);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(238, 21);
            this.cmbResult.TabIndex = 1;
            this.cmbResult.ValueMember = "ResultID";
            // 
            // cOVendorAgreementResultsBindingSource
            // 
            this.cOVendorAgreementResultsBindingSource.DataMember = "CO_Vendor_Agreement_Results";
            this.cOVendorAgreementResultsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cO_Vendor_Agreement_ResultsTableAdapter
            // 
            this.cO_Vendor_Agreement_ResultsTableAdapter.ClearBeforeFill = true;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(15, 62);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(73, 13);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "Примечание:";
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(94, 62);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(238, 45);
            this.tbNote.TabIndex = 3;
            // 
            // ComplaintActCloseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 161);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cmbResult);
            this.Name = "ComplaintActCloseForm";
            this.Text = "Закрытие акта";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintActCloseForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbResult, 0);
            this.Controls.SetChildIndex(this.lblResult, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblNote, 0);
            this.Controls.SetChildIndex(this.tbNote, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cOVendorAgreementResultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.BindingSource cOVendorAgreementResultsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Vendor_Agreement_ResultsTableAdapter cO_Vendor_Agreement_ResultsTableAdapter;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox tbNote;
    }
}