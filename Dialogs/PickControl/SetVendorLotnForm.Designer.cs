namespace WMSOffice.Dialogs.PickControl
{
    partial class SetVendorLotnForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbLotn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Введите название серии, которое видите на упаковке:";
            // 
            // tbLotn
            // 
            this.tbLotn.Location = new System.Drawing.Point(12, 29);
            this.tbLotn.Name = "tbLotn";
            this.tbLotn.Size = new System.Drawing.Size(291, 20);
            this.tbLotn.TabIndex = 2;
            this.tbLotn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLotn_KeyDown);
            // 
            // SetVendorLotnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 100);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLotn);
            this.Name = "SetVendorLotnForm";
            this.Text = "Присвоение серии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetVendorLotnForm_FormClosing);
            this.Controls.SetChildIndex(this.tbLotn, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLotn;
    }
}