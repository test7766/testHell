namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    partial class ChooseReasonControl : BaseControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbReasons = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Причина корректировки:";
            // 
            // cbReasons
            // 
            this.cbReasons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReasons.DisplayMember = "Name";
            this.cbReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReasons.FormattingEnabled = true;
            this.cbReasons.Location = new System.Drawing.Point(142, 6);
            this.cbReasons.Name = "cbReasons";
            this.cbReasons.Size = new System.Drawing.Size(455, 21);
            this.cbReasons.TabIndex = 1;
            this.cbReasons.ValueMember = "Id";
            this.cbReasons.SelectedIndexChanged += new System.EventHandler(this.cbReasons_SelectedIndexChanged);
            // 
            // ChoseReasonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbReasons);
            this.Controls.Add(this.label1);
            this.Name = "ChoseReasonControl";
            this.Size = new System.Drawing.Size(600, 37);
            this.Load += new System.EventHandler(this.ChoseReasonControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbReasons;
    }
}
