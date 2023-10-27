namespace ErrorHandlerDialog
{
    partial class ComplexRowErrorsDialog
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
            this.lbErrors = new System.Windows.Forms.ListBox();
            this.lbErrorsDesriptions = new System.Windows.Forms.ListBox();
            this.lblErrorWindowDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlErrorWindowDescription = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlErrorWindowDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbErrors
            // 
            this.lbErrors.BackColor = System.Drawing.SystemColors.Window;
            this.lbErrors.DisplayMember = "Number";
            this.lbErrors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbErrors.FormattingEnabled = true;
            this.lbErrors.ItemHeight = 20;
            this.lbErrors.Location = new System.Drawing.Point(14, 125);
            this.lbErrors.Name = "lbErrors";
            this.lbErrors.Size = new System.Drawing.Size(203, 184);
            this.lbErrors.TabIndex = 0;
            this.lbErrors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbErrors_DrawItem);
            this.lbErrors.SelectedValueChanged += new System.EventHandler(this.lbErrors_SelectedValueChanged);
            // 
            // lbErrorsDesriptions
            // 
            this.lbErrorsDesriptions.DisplayMember = "Description";
            this.lbErrorsDesriptions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbErrorsDesriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbErrorsDesriptions.ForeColor = System.Drawing.Color.Red;
            this.lbErrorsDesriptions.FormattingEnabled = true;
            this.lbErrorsDesriptions.ItemHeight = 20;
            this.lbErrorsDesriptions.Location = new System.Drawing.Point(223, 125);
            this.lbErrorsDesriptions.Name = "lbErrorsDesriptions";
            this.lbErrorsDesriptions.Size = new System.Drawing.Size(769, 184);
            this.lbErrorsDesriptions.TabIndex = 1;
            this.lbErrorsDesriptions.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbErrorsDesriptions_DrawItem);
            // 
            // lblErrorWindowDescription
            // 
            this.lblErrorWindowDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorWindowDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrorWindowDescription.ForeColor = System.Drawing.Color.Red;
            this.lblErrorWindowDescription.Location = new System.Drawing.Point(75, 2);
            this.lblErrorWindowDescription.Name = "lblErrorWindowDescription";
            this.lblErrorWindowDescription.Size = new System.Drawing.Size(642, 87);
            this.lblErrorWindowDescription.TabIndex = 2;
            this.lblErrorWindowDescription.Text = "< Заголовок общей ошибки >";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Позиция:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(220, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Перечень ошибок в позиции:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.pictureBox1.Location = new System.Drawing.Point(15, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 51);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pnlErrorWindowDescription
            // 
            this.pnlErrorWindowDescription.BackColor = System.Drawing.SystemColors.Info;
            this.pnlErrorWindowDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlErrorWindowDescription.Controls.Add(this.pictureBox1);
            this.pnlErrorWindowDescription.Controls.Add(this.lblErrorWindowDescription);
            this.pnlErrorWindowDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlErrorWindowDescription.Location = new System.Drawing.Point(0, 0);
            this.pnlErrorWindowDescription.Name = "pnlErrorWindowDescription";
            this.pnlErrorWindowDescription.Size = new System.Drawing.Size(1004, 91);
            this.pnlErrorWindowDescription.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(16, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(16, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(491, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "- запись содержит критические ошибки и требует корректировки до появления на инте" +
                "рфейсе";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(487, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "- запись содержит незначительные ошибки и требует частичной корректировки в интер" +
                "фейсе";
            // 
            // ComplexRowErrorsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 364);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlErrorWindowDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbErrorsDesriptions);
            this.Controls.Add(this.lbErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ComplexRowErrorsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "< Событие >";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlErrorWindowDescription.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbErrors;
        private System.Windows.Forms.ListBox lbErrorsDesriptions;
        private System.Windows.Forms.Label lblErrorWindowDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlErrorWindowDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

