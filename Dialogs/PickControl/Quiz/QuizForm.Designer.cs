namespace WMSOffice.Dialogs.PickControl.Quiz
{
    partial class QuizForm
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
            this.scContainer = new System.Windows.Forms.SplitContainer();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.tlpAnswers = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHelpText = new System.Windows.Forms.Panel();
            this.lblHelpText = new System.Windows.Forms.Label();
            this.scContainer.Panel1.SuspendLayout();
            this.scContainer.Panel2.SuspendLayout();
            this.scContainer.SuspendLayout();
            this.pnlHelpText.SuspendLayout();
            this.SuspendLayout();
            // 
            // scContainer
            // 
            this.scContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scContainer.Location = new System.Drawing.Point(0, 0);
            this.scContainer.Name = "scContainer";
            this.scContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContainer.Panel1
            // 
            this.scContainer.Panel1.Controls.Add(this.lblQuestion);
            this.scContainer.Panel1MinSize = 100;
            // 
            // scContainer.Panel2
            // 
            this.scContainer.Panel2.Controls.Add(this.tlpAnswers);
            this.scContainer.Panel2MinSize = 100;
            this.scContainer.Size = new System.Drawing.Size(1140, 634);
            this.scContainer.SplitterDistance = 260;
            this.scContainer.TabIndex = 0;
            // 
            // lblQuestion
            // 
            this.lblQuestion.BackColor = System.Drawing.Color.Honeydew;
            this.lblQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuestion.Location = new System.Drawing.Point(0, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(1140, 260);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Вопрос...";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpAnswers
            // 
            this.tlpAnswers.AutoScroll = true;
            this.tlpAnswers.BackColor = System.Drawing.Color.White;
            this.tlpAnswers.ColumnCount = 1;
            this.tlpAnswers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlpAnswers.Location = new System.Drawing.Point(0, 0);
            this.tlpAnswers.Name = "tlpAnswers";
            this.tlpAnswers.RowCount = 1;
            this.tlpAnswers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAnswers.Size = new System.Drawing.Size(1140, 370);
            this.tlpAnswers.TabIndex = 0;
            // 
            // pnlHelpText
            // 
            this.pnlHelpText.Controls.Add(this.lblHelpText);
            this.pnlHelpText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHelpText.Location = new System.Drawing.Point(0, 634);
            this.pnlHelpText.Name = "pnlHelpText";
            this.pnlHelpText.Size = new System.Drawing.Size(1140, 100);
            this.pnlHelpText.TabIndex = 1;
            // 
            // lblHelpText
            // 
            this.lblHelpText.BackColor = System.Drawing.Color.Honeydew;
            this.lblHelpText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHelpText.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHelpText.ForeColor = System.Drawing.Color.Black;
            this.lblHelpText.Location = new System.Drawing.Point(0, 0);
            this.lblHelpText.Name = "lblHelpText";
            this.lblHelpText.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.lblHelpText.Size = new System.Drawing.Size(1140, 100);
            this.lblHelpText.TabIndex = 0;
            this.lblHelpText.Text = "Подтвердите свой выбор нажатием клавиши Enter\r\nлибо двойным щелчком мыши.";
            this.lblHelpText.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 734);
            this.Controls.Add(this.pnlHelpText);
            this.Controls.Add(this.scContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Опрос";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizForm_FormClosing);
            this.scContainer.Panel1.ResumeLayout(false);
            this.scContainer.Panel2.ResumeLayout(false);
            this.scContainer.ResumeLayout(false);
            this.pnlHelpText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scContainer;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TableLayoutPanel tlpAnswers;
        private System.Windows.Forms.Panel pnlHelpText;
        private System.Windows.Forms.Label lblHelpText;
    }
}