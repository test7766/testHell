namespace WMSOffice.Dialogs.Inventory
{
    partial class CreateCountSheetsForm
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
            this.gbVariants = new System.Windows.Forms.GroupBox();
            this.tbWOCount = new System.Windows.Forms.TextBox();
            this.lblWOCount = new System.Windows.Forms.Label();
            this.rbWO = new System.Windows.Forms.RadioButton();
            this.tbEmptyCount = new System.Windows.Forms.TextBox();
            this.lblEmptyCount = new System.Windows.Forms.Label();
            this.rbEmpty = new System.Windows.Forms.RadioButton();
            this.rbUsual = new System.Windows.Forms.RadioButton();
            this.gbVariants.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Location = new System.Drawing.Point(119, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 8);
            // 
            // gbVariants
            // 
            this.gbVariants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVariants.Controls.Add(this.tbWOCount);
            this.gbVariants.Controls.Add(this.lblWOCount);
            this.gbVariants.Controls.Add(this.rbWO);
            this.gbVariants.Controls.Add(this.tbEmptyCount);
            this.gbVariants.Controls.Add(this.lblEmptyCount);
            this.gbVariants.Controls.Add(this.rbEmpty);
            this.gbVariants.Controls.Add(this.rbUsual);
            this.gbVariants.Location = new System.Drawing.Point(12, 12);
            this.gbVariants.Name = "gbVariants";
            this.gbVariants.Size = new System.Drawing.Size(261, 174);
            this.gbVariants.TabIndex = 101;
            this.gbVariants.TabStop = false;
            this.gbVariants.Text = "Выберите тип создаваемых листов:";
            // 
            // tbWOCount
            // 
            this.tbWOCount.Enabled = false;
            this.tbWOCount.Location = new System.Drawing.Point(27, 140);
            this.tbWOCount.MaxLength = 7;
            this.tbWOCount.Name = "tbWOCount";
            this.tbWOCount.Size = new System.Drawing.Size(100, 20);
            this.tbWOCount.TabIndex = 6;
            // 
            // lblWOCount
            // 
            this.lblWOCount.AutoSize = true;
            this.lblWOCount.Enabled = false;
            this.lblWOCount.Location = new System.Drawing.Point(24, 124);
            this.lblWOCount.Name = "lblWOCount";
            this.lblWOCount.Size = new System.Drawing.Size(230, 13);
            this.lblWOCount.TabIndex = 5;
            this.lblWOCount.Text = "Количество создаваемых счетных заданий:";
            // 
            // rbWO
            // 
            this.rbWO.AutoSize = true;
            this.rbWO.Location = new System.Drawing.Point(6, 104);
            this.rbWO.Name = "rbWO";
            this.rbWO.Size = new System.Drawing.Size(229, 17);
            this.rbWO.TabIndex = 4;
            this.rbWO.Text = "Счетные задания для ТСД (для ящиков)";
            this.rbWO.UseVisualStyleBackColor = true;
            this.rbWO.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // tbEmptyCount
            // 
            this.tbEmptyCount.Enabled = false;
            this.tbEmptyCount.Location = new System.Drawing.Point(27, 78);
            this.tbEmptyCount.MaxLength = 7;
            this.tbEmptyCount.Name = "tbEmptyCount";
            this.tbEmptyCount.Size = new System.Drawing.Size(100, 20);
            this.tbEmptyCount.TabIndex = 3;
            // 
            // lblEmptyCount
            // 
            this.lblEmptyCount.AutoSize = true;
            this.lblEmptyCount.Enabled = false;
            this.lblEmptyCount.Location = new System.Drawing.Point(24, 62);
            this.lblEmptyCount.Name = "lblEmptyCount";
            this.lblEmptyCount.Size = new System.Drawing.Size(217, 13);
            this.lblEmptyCount.TabIndex = 2;
            this.lblEmptyCount.Text = "Количество создаваемых пустых листов:";
            // 
            // rbEmpty
            // 
            this.rbEmpty.AutoSize = true;
            this.rbEmpty.Location = new System.Drawing.Point(6, 42);
            this.rbEmpty.Name = "rbEmpty";
            this.rbEmpty.Size = new System.Drawing.Size(222, 17);
            this.rbEmpty.TabIndex = 1;
            this.rbEmpty.Text = "Пустые счетные листы (для излишков)";
            this.rbEmpty.UseVisualStyleBackColor = true;
            this.rbEmpty.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbUsual
            // 
            this.rbUsual.AutoSize = true;
            this.rbUsual.Checked = true;
            this.rbUsual.Location = new System.Drawing.Point(6, 19);
            this.rbUsual.Name = "rbUsual";
            this.rbUsual.Size = new System.Drawing.Size(211, 17);
            this.rbUsual.TabIndex = 0;
            this.rbUsual.TabStop = true;
            this.rbUsual.Text = "Обычные счетные листы (для дроби)";
            this.rbUsual.UseVisualStyleBackColor = true;
            this.rbUsual.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // CreateCountSheetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 235);
            this.Controls.Add(this.gbVariants);
            this.Name = "CreateCountSheetsForm";
            this.Text = "Создание счетных листов (заданий)";
            this.Controls.SetChildIndex(this.gbVariants, 0);
            this.gbVariants.ResumeLayout(false);
            this.gbVariants.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVariants;
        private System.Windows.Forms.TextBox tbEmptyCount;
        private System.Windows.Forms.Label lblEmptyCount;
        private System.Windows.Forms.RadioButton rbEmpty;
        private System.Windows.Forms.RadioButton rbUsual;
        private System.Windows.Forms.TextBox tbWOCount;
        private System.Windows.Forms.Label lblWOCount;
        private System.Windows.Forms.RadioButton rbWO;
    }
}