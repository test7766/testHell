namespace WMSOffice.Dialogs.Quality
{
    partial class StatementPrintCountForm
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
            this.rbPrintFullPackageMode = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbPrintGeneralDocsMode = new System.Windows.Forms.RadioButton();
            this.pnlGeneralDocs = new System.Windows.Forms.Panel();
            this.tbStatementListCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStatementCount = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlGeneralDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbStatementListCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStatementCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(19, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(109, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 114);
            this.pnlButtons.Size = new System.Drawing.Size(264, 43);
            // 
            // rbPrintFullPackageMode
            // 
            this.rbPrintFullPackageMode.AutoSize = true;
            this.rbPrintFullPackageMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPrintFullPackageMode.Location = new System.Drawing.Point(69, 8);
            this.rbPrintFullPackageMode.Name = "rbPrintFullPackageMode";
            this.rbPrintFullPackageMode.Size = new System.Drawing.Size(173, 20);
            this.rbPrintFullPackageMode.TabIndex = 112;
            this.rbPrintFullPackageMode.Text = "Повний друк пакету";
            this.rbPrintFullPackageMode.UseVisualStyleBackColor = true;
            this.rbPrintFullPackageMode.CheckedChanged += new System.EventHandler(this.PrintMode_Changed);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.document_print;
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.TabIndex = 109;
            this.pictureBox1.TabStop = false;
            // 
            // rbPrintGeneralDocsMode
            // 
            this.rbPrintGeneralDocsMode.AutoSize = true;
            this.rbPrintGeneralDocsMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPrintGeneralDocsMode.Location = new System.Drawing.Point(69, 30);
            this.rbPrintGeneralDocsMode.Name = "rbPrintGeneralDocsMode";
            this.rbPrintGeneralDocsMode.Size = new System.Drawing.Size(156, 20);
            this.rbPrintGeneralDocsMode.TabIndex = 111;
            this.rbPrintGeneralDocsMode.Text = "Вибірковий друк";
            this.rbPrintGeneralDocsMode.UseVisualStyleBackColor = true;
            this.rbPrintGeneralDocsMode.CheckedChanged += new System.EventHandler(this.PrintMode_Changed);
            // 
            // pnlGeneralDocs
            // 
            this.pnlGeneralDocs.Controls.Add(this.tbStatementListCount);
            this.pnlGeneralDocs.Controls.Add(this.label1);
            this.pnlGeneralDocs.Controls.Add(this.label2);
            this.pnlGeneralDocs.Controls.Add(this.tbStatementCount);
            this.pnlGeneralDocs.Location = new System.Drawing.Point(79, 58);
            this.pnlGeneralDocs.Name = "pnlGeneralDocs";
            this.pnlGeneralDocs.Size = new System.Drawing.Size(176, 49);
            this.pnlGeneralDocs.TabIndex = 110;
            // 
            // tbStatementListCount
            // 
            this.tbStatementListCount.Location = new System.Drawing.Point(125, 26);
            this.tbStatementListCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbStatementListCount.Name = "tbStatementListCount";
            this.tbStatementListCount.Size = new System.Drawing.Size(47, 20);
            this.tbStatementListCount.TabIndex = 4;
            this.tbStatementListCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Кількість актів:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Кількість переліків:";
            // 
            // tbStatementCount
            // 
            this.tbStatementCount.Location = new System.Drawing.Point(125, 3);
            this.tbStatementCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbStatementCount.Name = "tbStatementCount";
            this.tbStatementCount.Size = new System.Drawing.Size(47, 20);
            this.tbStatementCount.TabIndex = 2;
            this.tbStatementCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // StatementPrintCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 157);
            this.Controls.Add(this.rbPrintFullPackageMode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rbPrintGeneralDocsMode);
            this.Controls.Add(this.pnlGeneralDocs);
            this.Name = "StatementPrintCountForm";
            this.Text = "Режим друку";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlGeneralDocs, 0);
            this.Controls.SetChildIndex(this.rbPrintGeneralDocsMode, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.rbPrintFullPackageMode, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlGeneralDocs.ResumeLayout(false);
            this.pnlGeneralDocs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbStatementListCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStatementCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbPrintFullPackageMode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbPrintGeneralDocsMode;
        private System.Windows.Forms.Panel pnlGeneralDocs;
        private System.Windows.Forms.NumericUpDown tbStatementListCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown tbStatementCount;

    }
}