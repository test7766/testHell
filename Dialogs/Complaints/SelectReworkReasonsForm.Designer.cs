namespace WMSOffice.Dialogs.Complaints
{
    partial class SelectReworkReasonsForm
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
            this.lblReasonType = new System.Windows.Forms.Label();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.cmbReasonType = new System.Windows.Forms.ComboBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.complaints = new WMSOffice.Data.Complaints();
            this.reworkReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reworkReasonsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.ReworkReasonsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reworkReasonsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 124);
            this.pnlButtons.TabIndex = 0;
            // 
            // lblReasonType
            // 
            this.lblReasonType.AutoSize = true;
            this.lblReasonType.Location = new System.Drawing.Point(13, 12);
            this.lblReasonType.Name = "lblReasonType";
            this.lblReasonType.Size = new System.Drawing.Size(53, 13);
            this.lblReasonType.TabIndex = 0;
            this.lblReasonType.Text = "Причина:";
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(80, 45);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReason.Size = new System.Drawing.Size(258, 70);
            this.tbReason.TabIndex = 4;
            // 
            // cmbReasonType
            // 
            this.cmbReasonType.DataSource = this.reworkReasonsBindingSource;
            this.cmbReasonType.DisplayMember = "ReasonDescription";
            this.cmbReasonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasonType.FormattingEnabled = true;
            this.cmbReasonType.Location = new System.Drawing.Point(80, 8);
            this.cmbReasonType.Name = "cmbReasonType";
            this.cmbReasonType.Size = new System.Drawing.Size(258, 21);
            this.cmbReasonType.TabIndex = 1;
            this.cmbReasonType.ValueMember = "ReasonID";
            this.cmbReasonType.SelectedValueChanged += new System.EventHandler(this.cmbReasonType_SelectedValueChanged);
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(13, 45);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(60, 13);
            this.lblReason.TabIndex = 3;
            this.lblReason.Text = "Описание:";
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reworkReasonsBindingSource
            // 
            this.reworkReasonsBindingSource.DataMember = "ReworkReasons";
            this.reworkReasonsBindingSource.DataSource = this.complaints;
            // 
            // reworkReasonsTableAdapter
            // 
            this.reworkReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // SelectReworkReasonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 167);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.cmbReasonType);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.lblReasonType);
            this.Name = "SelectReworkReasonsForm";
            this.Text = "Укажите причину отклонения претензии";
            this.Load += new System.EventHandler(this.SelectReworkReasonsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectReworkReasonsForm_FormClosing);
            this.Controls.SetChildIndex(this.lblReasonType, 0);
            this.Controls.SetChildIndex(this.tbReason, 0);
            this.Controls.SetChildIndex(this.cmbReasonType, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblReason, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reworkReasonsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReasonType;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.ComboBox cmbReasonType;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.BindingSource reworkReasonsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.ReworkReasonsTableAdapter reworkReasonsTableAdapter;
    }
}