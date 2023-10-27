namespace WMSOffice.Dialogs.PickControl
{
    partial class RepairForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbOperator = new System.Windows.Forms.CheckBox();
            this.chbPick = new System.Windows.Forms.CheckBox();
            this.chbControl = new System.Windows.Forms.CheckBox();
            this.tbInstruction = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Рекомендация:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chbOperator);
            this.groupBox1.Controls.Add(this.chbPick);
            this.groupBox1.Controls.Add(this.chbControl);
            this.groupBox1.Location = new System.Drawing.Point(12, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 48);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Зафиксировать ошибку:";
            // 
            // chbOperator
            // 
            this.chbOperator.AutoSize = true;
            this.chbOperator.Location = new System.Drawing.Point(345, 19);
            this.chbOperator.Name = "chbOperator";
            this.chbOperator.Size = new System.Drawing.Size(94, 17);
            this.chbOperator.TabIndex = 4;
            this.chbOperator.Text = "оператора (3)";
            this.chbOperator.UseVisualStyleBackColor = true;
            // 
            // chbPick
            // 
            this.chbPick.AutoSize = true;
            this.chbPick.Location = new System.Drawing.Point(202, 21);
            this.chbPick.Name = "chbPick";
            this.chbPick.Size = new System.Drawing.Size(92, 17);
            this.chbPick.TabIndex = 3;
            this.chbPick.Text = "сборщика (2)";
            this.chbPick.UseVisualStyleBackColor = true;
            // 
            // chbControl
            // 
            this.chbControl.AutoSize = true;
            this.chbControl.Location = new System.Drawing.Point(51, 21);
            this.chbControl.Name = "chbControl";
            this.chbControl.Size = new System.Drawing.Size(100, 17);
            this.chbControl.TabIndex = 0;
            this.chbControl.Text = "контролера (1)";
            this.chbControl.UseVisualStyleBackColor = true;
            // 
            // tbInstruction
            // 
            this.tbInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInstruction.Location = new System.Drawing.Point(12, 25);
            this.tbInstruction.Multiline = true;
            this.tbInstruction.Name = "tbInstruction";
            this.tbInstruction.ReadOnly = true;
            this.tbInstruction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInstruction.Size = new System.Drawing.Size(490, 328);
            this.tbInstruction.TabIndex = 1;
            this.tbInstruction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInstruction_KeyDown);
            // 
            // RepairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 456);
            this.Controls.Add(this.tbInstruction);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "RepairForm";
            this.Text = "Исправление ошибки контроля/сборки";
            this.Load += new System.EventHandler(this.RepairForm_Load);
            this.Shown += new System.EventHandler(this.RepairForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RepairForm_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tbInstruction, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbControl;
        private System.Windows.Forms.CheckBox chbPick;
        private System.Windows.Forms.TextBox tbInstruction;
        private System.Windows.Forms.CheckBox chbOperator;
    }
}