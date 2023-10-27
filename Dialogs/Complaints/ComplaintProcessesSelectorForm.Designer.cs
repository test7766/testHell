namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintProcessesSelectorForm
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
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnVideoControl = new System.Windows.Forms.Button();
            this.ctrlTwoListSelector = new WMSOffice.Controls.TwoListSelectorControl();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.btnVideoControl);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOptions.Location = new System.Drawing.Point(0, 328);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(694, 44);
            this.pnlOptions.TabIndex = 0;
            // 
            // btnVideoControl
            // 
            this.btnVideoControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVideoControl.Location = new System.Drawing.Point(297, 11);
            this.btnVideoControl.Name = "btnVideoControl";
            this.btnVideoControl.Size = new System.Drawing.Size(100, 23);
            this.btnVideoControl.TabIndex = 0;
            this.btnVideoControl.Text = "Запуск WVM";
            this.btnVideoControl.UseVisualStyleBackColor = true;
            this.btnVideoControl.Click += new System.EventHandler(this.btnVideoControl_Click);
            // 
            // ctrlTwoListSelector
            // 
            this.ctrlTwoListSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTwoListSelector.Location = new System.Drawing.Point(0, 0);
            this.ctrlTwoListSelector.Name = "ctrlTwoListSelector";
            this.ctrlTwoListSelector.Padding = new System.Windows.Forms.Padding(3);
            this.ctrlTwoListSelector.Size = new System.Drawing.Size(694, 328);
            this.ctrlTwoListSelector.TabIndex = 1;
            // 
            // ComplaintProcessesSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 372);
            this.Controls.Add(this.ctrlTwoListSelector);
            this.Controls.Add(this.pnlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComplaintProcessesSelectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор процесса";
            this.Load += new System.EventHandler(this.ComplaintProcessesSelectorForm_Load);
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnVideoControl;
        private WMSOffice.Controls.TwoListSelectorControl ctrlTwoListSelector;
    }
}