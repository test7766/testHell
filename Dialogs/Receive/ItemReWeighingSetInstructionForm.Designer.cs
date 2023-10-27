namespace WMSOffice.Dialogs.Receive
{
    partial class ItemReWeighingSetInstructionForm
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
            this.cbHasInstruction = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-19, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(71, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 88);
            this.pnlButtons.Size = new System.Drawing.Size(254, 43);
            // 
            // cbHasInstruction
            // 
            this.cbHasInstruction.AutoSize = true;
            this.cbHasInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbHasInstruction.Location = new System.Drawing.Point(10, 14);
            this.cbHasInstruction.Name = "cbHasInstruction";
            this.cbHasInstruction.Size = new System.Drawing.Size(238, 29);
            this.cbHasInstruction.TabIndex = 101;
            this.cbHasInstruction.Text = "Наличие инструкции";
            this.cbHasInstruction.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 102;
            this.label1.Text = "(отдельно от упаковки)";
            // 
            // ItemReWeighingSetInstructionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 131);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHasInstruction);
            this.Name = "ItemReWeighingSetInstructionForm";
            this.Text = "Форма выбора инструкции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemReWeighingSetInstructionForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cbHasInstruction, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbHasInstruction;
        private System.Windows.Forms.Label label1;
    }
}