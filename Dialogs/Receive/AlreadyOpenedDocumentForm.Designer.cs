namespace WMSOffice.Dialogs.Receive
{
    partial class AlreadyOpenedDocumentForm
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
            this.lblUnclosedDoc = new System.Windows.Forms.Label();
            this.btnContinueUnclosed = new System.Windows.Forms.Button();
            this.btnNewTask = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUnclosedDoc
            // 
            this.lblUnclosedDoc.AutoSize = true;
            this.lblUnclosedDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUnclosedDoc.Location = new System.Drawing.Point(12, 9);
            this.lblUnclosedDoc.Name = "lblUnclosedDoc";
            this.lblUnclosedDoc.Size = new System.Drawing.Size(373, 16);
            this.lblUnclosedDoc.TabIndex = 0;
            this.lblUnclosedDoc.Text = "Не закрыт пак-лист № 1363333. Закончите работу с ним!";
            // 
            // btnContinueUnclosed
            // 
            this.btnContinueUnclosed.Location = new System.Drawing.Point(154, 44);
            this.btnContinueUnclosed.Name = "btnContinueUnclosed";
            this.btnContinueUnclosed.Size = new System.Drawing.Size(143, 23);
            this.btnContinueUnclosed.TabIndex = 1;
            this.btnContinueUnclosed.Text = "Продолжить незакрытое";
            this.btnContinueUnclosed.UseVisualStyleBackColor = true;
            this.btnContinueUnclosed.Visible = false;
            this.btnContinueUnclosed.Click += new System.EventHandler(this.btnContinueUnclosed_Click);
            // 
            // btnNewTask
            // 
            this.btnNewTask.Location = new System.Drawing.Point(15, 44);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(133, 23);
            this.btnNewTask.TabIndex = 2;
            this.btnNewTask.Text = "Начать новое задание";
            this.btnNewTask.UseVisualStyleBackColor = true;
            this.btnNewTask.Visible = false;
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnOK.Location = new System.Drawing.Point(303, 44);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // AlreadyOpenedDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 77);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNewTask);
            this.Controls.Add(this.btnContinueUnclosed);
            this.Controls.Add(this.lblUnclosedDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlreadyOpenedDocumentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Незакрытые задания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlreadyOpenedDocumentForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnclosedDoc;
        private System.Windows.Forms.Button btnContinueUnclosed;
        private System.Windows.Forms.Button btnNewTask;
        private System.Windows.Forms.Button btnOK;
    }
}