namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    partial class SelectSubreasonControl
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
            this.chbSelect = new System.Windows.Forms.CheckBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chbSelect
            // 
            this.chbSelect.AutoSize = true;
            this.chbSelect.Location = new System.Drawing.Point(4, 4);
            this.chbSelect.Name = "chbSelect";
            this.chbSelect.Size = new System.Drawing.Size(69, 17);
            this.chbSelect.TabIndex = 0;
            this.chbSelect.Text = "Причина";
            this.chbSelect.UseVisualStyleBackColor = true;
            this.chbSelect.CheckedChanged += new System.EventHandler(this.chbSelect_CheckedChanged);
            // 
            // tbQuantity
            // 
            this.tbQuantity.Enabled = false;
            this.tbQuantity.Location = new System.Drawing.Point(214, 4);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbQuantity.TabIndex = 1;
            this.tbQuantity.TextChanged += new System.EventHandler(this.tbQuantity_TextChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Enabled = false;
            this.lblQuantity.Location = new System.Drawing.Point(92, 7);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(116, 14);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Количество:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(319, 5);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(11, 13);
            this.lblError.TabIndex = 10;
            this.lblError.Text = "*";
            this.lblError.Visible = false;
            // 
            // SelectSubreasonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.chbSelect);
            this.Name = "SelectSubreasonControl";
            this.Size = new System.Drawing.Size(600, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbSelect;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblError;
    }
}
