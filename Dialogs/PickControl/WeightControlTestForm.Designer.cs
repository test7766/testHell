namespace WMSOffice.Dialogs.PickControl
{
    partial class WeightControlTestForm
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
            this.btnObtainWeight = new System.Windows.Forms.Button();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(107, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 218);
            this.pnlButtons.Size = new System.Drawing.Size(284, 43);
            // 
            // btnObtainWeight
            // 
            this.btnObtainWeight.Location = new System.Drawing.Point(12, 12);
            this.btnObtainWeight.Name = "btnObtainWeight";
            this.btnObtainWeight.Size = new System.Drawing.Size(100, 23);
            this.btnObtainWeight.TabIndex = 101;
            this.btnObtainWeight.Text = "Получить вес";
            this.btnObtainWeight.UseVisualStyleBackColor = true;
            this.btnObtainWeight.Click += new System.EventHandler(this.btnObtainWeight_Click);
            // 
            // tbWeight
            // 
            this.tbWeight.BackColor = System.Drawing.SystemColors.Window;
            this.tbWeight.Location = new System.Drawing.Point(119, 13);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.ReadOnly = true;
            this.tbWeight.Size = new System.Drawing.Size(153, 20);
            this.tbWeight.TabIndex = 102;
            // 
            // WeightControlTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbWeight);
            this.Controls.Add(this.btnObtainWeight);
            this.Name = "WeightControlTestForm";
            this.Text = "Весовой контроль";
            this.Controls.SetChildIndex(this.btnObtainWeight, 0);
            this.Controls.SetChildIndex(this.tbWeight, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnObtainWeight;
        private System.Windows.Forms.TextBox tbWeight;
    }
}