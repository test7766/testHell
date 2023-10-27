namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    partial class QuantityChangeControl
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
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCanceledQuantity = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.chbMoveAllRemains = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(135, 9);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(76, 20);
            this.tbQuantity.TabIndex = 5;
            this.tbQuantity.TextChanged += new System.EventHandler(this.tbQuantity_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Конечное количество:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Отмененное количество:";
            // 
            // tbCanceledQuantity
            // 
            this.tbCanceledQuantity.Location = new System.Drawing.Point(479, 9);
            this.tbCanceledQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.tbCanceledQuantity.Name = "tbCanceledQuantity";
            this.tbCanceledQuantity.ReadOnly = true;
            this.tbCanceledQuantity.Size = new System.Drawing.Size(76, 20);
            this.tbCanceledQuantity.TabIndex = 7;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(132, 31);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(11, 13);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "*";
            // 
            // chbMoveAllRemains
            // 
            this.chbMoveAllRemains.AutoSize = true;
            this.chbMoveAllRemains.Location = new System.Drawing.Point(15, 47);
            this.chbMoveAllRemains.Name = "chbMoveAllRemains";
            this.chbMoveAllRemains.Size = new System.Drawing.Size(361, 17);
            this.chbMoveAllRemains.TabIndex = 9;
            this.chbMoveAllRemains.Text = "Переместить на полку \"недостач\" также весь доступный остаток";
            this.chbMoveAllRemains.UseVisualStyleBackColor = true;
            this.chbMoveAllRemains.CheckedChanged += new System.EventHandler(this.chbMoveAllRemains_CheckedChanged);
            // 
            // QuantityChangeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbMoveAllRemains);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.tbCanceledQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label2);
            this.Name = "QuantityChangeControl";
            this.Size = new System.Drawing.Size(600, 67);
            this.Load += new System.EventHandler(this.QuantityChangeControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCanceledQuantity;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox chbMoveAllRemains;
    }
}
