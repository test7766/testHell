namespace WMSOffice.Dialogs.WH
{
    partial class ExecuteActionForm
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
            this.tbBarCodeScaner = new WMSOffice.Controls.TextBoxScaner();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(158, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(248, 8);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 41);
            this.pnlButtons.Size = new System.Drawing.Size(335, 43);
            // 
            // tbBarCodeScaner
            // 
            this.tbBarCodeScaner.AllowType = true;
            this.tbBarCodeScaner.AutoConvert = true;
            this.tbBarCodeScaner.Location = new System.Drawing.Point(12, 14);
            this.tbBarCodeScaner.Name = "tbBarCodeScaner";
            this.tbBarCodeScaner.ReadOnly = false;
            this.tbBarCodeScaner.Size = new System.Drawing.Size(311, 25);
            this.tbBarCodeScaner.TabIndex = 101;
            this.tbBarCodeScaner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            // 
            // ExecuteActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 84);
            this.Controls.Add(this.tbBarCodeScaner);
            this.Name = "ExecuteActionForm";
            this.Text = "Отсканируйте ш/к документа текущей операции";
            this.Load += new System.EventHandler(this.ExecuteActionForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExecuteActionForm_FormClosing);
            this.Controls.SetChildIndex(this.tbBarCodeScaner, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WMSOffice.Controls.TextBoxScaner tbBarCodeScaner;
    }
}