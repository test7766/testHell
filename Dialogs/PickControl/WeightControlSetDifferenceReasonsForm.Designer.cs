namespace WMSOffice.Dialogs.PickControl
{
    partial class WeightControlSetDifferenceReasonsForm
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
            this.pCWeightControlFalseReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.lblNote = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.pC_WeightControl_False_ReasonsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.PC_WeightControl_False_ReasonsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pCWeightControlFalseReasonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 114);
            this.pnlButtons.TabIndex = 4;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(13, 26);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(56, 13);
            this.lblReason.TabIndex = 0;
            this.lblReason.Text = "Причина :";
            // 
            // cmbReasons
            // 
            this.cmbReasons.DataSource = this.pCWeightControlFalseReasonsBindingSource;
            this.cmbReasons.DisplayMember = "DSCR";
            this.cmbReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasons.FormattingEnabled = true;
            this.cmbReasons.Location = new System.Drawing.Point(97, 23);
            this.cmbReasons.Name = "cmbReasons";
            this.cmbReasons.Size = new System.Drawing.Size(241, 21);
            this.cmbReasons.TabIndex = 1;
            this.cmbReasons.ValueMember = "False_Reason_id";
            // 
            // pCWeightControlFalseReasonsBindingSource
            // 
            this.pCWeightControlFalseReasonsBindingSource.DataMember = "PC_WeightControl_False_Reasons";
            this.pCWeightControlFalseReasonsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(13, 55);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(76, 13);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "Примечание :";
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(97, 55);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(241, 50);
            this.tbNote.TabIndex = 3;
            // 
            // pC_WeightControl_False_ReasonsTableAdapter
            // 
            this.pC_WeightControl_False_ReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // WeightControlSetDifferenceReasonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 157);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.cmbReasons);
            this.Name = "WeightControlSetDifferenceReasonsForm";
            this.Text = "Укажите причину расхождения весового контроля";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WeightControlSetDifferenceReasonsForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbReasons, 0);
            this.Controls.SetChildIndex(this.lblReason, 0);
            this.Controls.SetChildIndex(this.lblNote, 0);
            this.Controls.SetChildIndex(this.tbNote, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pCWeightControlFalseReasonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cmbReasons;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.BindingSource pCWeightControlFalseReasonsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.PC_WeightControl_False_ReasonsTableAdapter pC_WeightControl_False_ReasonsTableAdapter;
    }
}