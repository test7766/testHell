namespace WMSOffice.Dialogs.Receive
{
    partial class SetPalletHeightForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbPalletHeight = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(11, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(101, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 97);
            this.pnlButtons.Size = new System.Drawing.Size(271, 43);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.paper_box;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // tbPalletHeight
            // 
            this.tbPalletHeight.Location = new System.Drawing.Point(115, 62);
            this.tbPalletHeight.Name = "tbPalletHeight";
            this.tbPalletHeight.Size = new System.Drawing.Size(100, 20);
            this.tbPalletHeight.TabIndex = 0;
            this.tbPalletHeight.TextChanged += new System.EventHandler(this.tbPalletHeight_TextChanged);
            this.tbPalletHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPalletHeight_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(102, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(117, 13);
            this.lblDescription.TabIndex = 103;
            this.lblDescription.Text = "Высота паллеты (см):";
            // 
            // SetPalletHeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 140);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbPalletHeight);
            this.Name = "SetPalletHeightForm";
            this.Text = "Укажите высоту создаваемой паллеты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetPalletHeightForm_FormClosing);
            this.Controls.SetChildIndex(this.tbPalletHeight, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbPalletHeight;
        private System.Windows.Forms.Label lblDescription;
    }
}