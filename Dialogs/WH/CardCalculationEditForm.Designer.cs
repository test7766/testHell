namespace WMSOffice.Dialogs.WH
{
    partial class CardCalculationEditForm
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
            this.lblComment = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.cbDiscount = new System.Windows.Forms.CheckBox();
            this.cbCalcDate = new System.Windows.Forms.CheckBox();
            this.cbMarkdown = new System.Windows.Forms.CheckBox();
            this.lblEditDataChecked = new System.Windows.Forms.Label();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lblLoadFile = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(244, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(334, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 313);
            this.pnlButtons.Size = new System.Drawing.Size(422, 43);
            this.pnlButtons.TabIndex = 9;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblComment.Location = new System.Drawing.Point(12, 21);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(397, 16);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Укажите комментарий касательно корректировки расчета:";
            // 
            // tbComment
            // 
            this.tbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbComment.Location = new System.Drawing.Point(15, 45);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComment.Size = new System.Drawing.Size(394, 55);
            this.tbComment.TabIndex = 1;
            // 
            // cbDiscount
            // 
            this.cbDiscount.AutoSize = true;
            this.cbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDiscount.Location = new System.Drawing.Point(15, 156);
            this.cbDiscount.Name = "cbDiscount";
            this.cbDiscount.Size = new System.Drawing.Size(92, 20);
            this.cbDiscount.TabIndex = 3;
            this.cbDiscount.Text = "Скидка, %";
            this.cbDiscount.UseVisualStyleBackColor = true;
            // 
            // cbCalcDate
            // 
            this.cbCalcDate.AutoSize = true;
            this.cbCalcDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCalcDate.Location = new System.Drawing.Point(15, 212);
            this.cbCalcDate.Name = "cbCalcDate";
            this.cbCalcDate.Size = new System.Drawing.Size(279, 20);
            this.cbCalcDate.TabIndex = 5;
            this.cbCalcDate.Text = "Дата расчета компенсации (Курс НБУ)";
            this.cbCalcDate.UseVisualStyleBackColor = true;
            // 
            // cbMarkdown
            // 
            this.cbMarkdown.AutoSize = true;
            this.cbMarkdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMarkdown.Location = new System.Drawing.Point(15, 184);
            this.cbMarkdown.Name = "cbMarkdown";
            this.cbMarkdown.Size = new System.Drawing.Size(93, 20);
            this.cbMarkdown.TabIndex = 4;
            this.cbMarkdown.Text = "Уценка, %";
            this.cbMarkdown.UseVisualStyleBackColor = true;
            // 
            // lblEditDataChecked
            // 
            this.lblEditDataChecked.AutoSize = true;
            this.lblEditDataChecked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEditDataChecked.Location = new System.Drawing.Point(12, 124);
            this.lblEditDataChecked.Name = "lblEditDataChecked";
            this.lblEditDataChecked.Size = new System.Drawing.Size(261, 16);
            this.lblEditDataChecked.TabIndex = 2;
            this.lblEditDataChecked.Text = "Откорректировать данные в колонках:";
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Image = global::WMSOffice.Properties.Resources.open_folder_icon;
            this.btnLoadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadFile.Location = new System.Drawing.Point(120, 253);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 7;
            this.btnLoadFile.Text = "Выбрать";
            this.btnLoadFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // lblLoadFile
            // 
            this.lblLoadFile.AutoSize = true;
            this.lblLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLoadFile.Location = new System.Drawing.Point(12, 256);
            this.lblLoadFile.Name = "lblLoadFile";
            this.lblLoadFile.Size = new System.Drawing.Size(102, 16);
            this.lblLoadFile.TabIndex = 6;
            this.lblLoadFile.Text = "Вложить файл";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilePath.ForeColor = System.Drawing.Color.Gray;
            this.lblFilePath.Location = new System.Drawing.Point(12, 288);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 13);
            this.lblFilePath.TabIndex = 8;
            // 
            // CardCalculationEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 356);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblLoadFile);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.lblEditDataChecked);
            this.Controls.Add(this.cbMarkdown);
            this.Controls.Add(this.cbCalcDate);
            this.Controls.Add(this.cbDiscount);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.lblComment);
            this.Name = "CardCalculationEditForm";
            this.Text = "Заполните данные";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CardCalculationEditForm_FormClosing);
            this.Controls.SetChildIndex(this.lblComment, 0);
            this.Controls.SetChildIndex(this.tbComment, 0);
            this.Controls.SetChildIndex(this.cbDiscount, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cbCalcDate, 0);
            this.Controls.SetChildIndex(this.cbMarkdown, 0);
            this.Controls.SetChildIndex(this.lblEditDataChecked, 0);
            this.Controls.SetChildIndex(this.btnLoadFile, 0);
            this.Controls.SetChildIndex(this.lblLoadFile, 0);
            this.Controls.SetChildIndex(this.lblFilePath, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.CheckBox cbDiscount;
        private System.Windows.Forms.CheckBox cbCalcDate;
        private System.Windows.Forms.CheckBox cbMarkdown;
        private System.Windows.Forms.Label lblEditDataChecked;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label lblLoadFile;
        private System.Windows.Forms.Label lblFilePath;
    }
}