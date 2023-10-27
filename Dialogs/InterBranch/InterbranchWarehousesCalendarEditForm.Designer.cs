namespace WMSOffice.Dialogs.InterBranch
{
    partial class InterbranchWarehousesCalendarEditForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tbPeriodTo = new System.Windows.Forms.TextBox();
            this.tbMcuToName = new System.Windows.Forms.TextBox();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblMcuTo = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblRD = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.cbNF = new System.Windows.Forms.CheckBox();
            this.cbNCD = new System.Windows.Forms.CheckBox();
            this.dtpRD = new System.Windows.Forms.DateTimePicker();
            this.nudV = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudV)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 145);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.tbPeriodTo);
            this.pnlHeader.Controls.Add(this.tbMcuToName);
            this.pnlHeader.Controls.Add(this.lblPeriodTo);
            this.pnlHeader.Controls.Add(this.lblMcuTo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(350, 67);
            this.pnlHeader.TabIndex = 0;
            // 
            // tbPeriodTo
            // 
            this.tbPeriodTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbPeriodTo.Location = new System.Drawing.Point(117, 38);
            this.tbPeriodTo.Name = "tbPeriodTo";
            this.tbPeriodTo.ReadOnly = true;
            this.tbPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.tbPeriodTo.TabIndex = 3;
            // 
            // tbMcuTo
            // 
            this.tbMcuToName.BackColor = System.Drawing.SystemColors.Window;
            this.tbMcuToName.Location = new System.Drawing.Point(117, 9);
            this.tbMcuToName.Name = "tbMcuTo";
            this.tbMcuToName.ReadOnly = true;
            this.tbMcuToName.Size = new System.Drawing.Size(221, 20);
            this.tbMcuToName.TabIndex = 1;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(13, 42);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(98, 13);
            this.lblPeriodTo.TabIndex = 2;
            this.lblPeriodTo.Text = "Период доставки:";
            // 
            // lblMcuTo
            // 
            this.lblMcuTo.AutoSize = true;
            this.lblMcuTo.Location = new System.Drawing.Point(13, 13);
            this.lblMcuTo.Name = "lblMcuTo";
            this.lblMcuTo.Size = new System.Drawing.Size(91, 13);
            this.lblMcuTo.TabIndex = 0;
            this.lblMcuTo.Text = "Склад доставки:";
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.nudV);
            this.pnlContent.Controls.Add(this.dtpRD);
            this.pnlContent.Controls.Add(this.cbNCD);
            this.pnlContent.Controls.Add(this.cbNF);
            this.pnlContent.Controls.Add(this.lblRD);
            this.pnlContent.Controls.Add(this.lblV);
            this.pnlContent.Location = new System.Drawing.Point(0, 73);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(350, 66);
            this.pnlContent.TabIndex = 1;
            // 
            // lblRD
            // 
            this.lblRD.AutoSize = true;
            this.lblRD.Location = new System.Drawing.Point(13, 42);
            this.lblRD.Name = "lblRD";
            this.lblRD.Size = new System.Drawing.Size(71, 13);
            this.lblRD.TabIndex = 2;
            this.lblRD.Text = "Доступен с :";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Location = new System.Drawing.Point(13, 13);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(63, 13);
            this.lblV.TabIndex = 0;
            this.lblV.Text = "Лимит, м³ :";
            // 
            // cbNF
            // 
            this.cbNF.BackColor = System.Drawing.Color.LightGreen;
            this.cbNF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbNF.Location = new System.Drawing.Point(231, 10);
            this.cbNF.Name = "cbNF";
            this.cbNF.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbNF.Size = new System.Drawing.Size(107, 18);
            this.cbNF.TabIndex = 4;
            this.cbNF.Text = "Без дроби";
            this.cbNF.UseVisualStyleBackColor = false;
            // 
            // cbNCD
            // 
            this.cbNCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbNCD.Location = new System.Drawing.Point(231, 39);
            this.cbNCD.Name = "cbNCD";
            this.cbNCD.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbNCD.Size = new System.Drawing.Size(107, 18);
            this.cbNCD.TabIndex = 5;
            this.cbNCD.Text = "Без КД с ПО";
            this.cbNCD.UseVisualStyleBackColor = true;
            // 
            // dtpRD
            // 
            this.dtpRD.CustomFormat = "dd.MM.yyyy";
            this.dtpRD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRD.Location = new System.Drawing.Point(117, 36);
            this.dtpRD.Name = "dtpRD";
            this.dtpRD.Size = new System.Drawing.Size(100, 20);
            this.dtpRD.TabIndex = 3;
            // 
            // nudV
            // 
            this.nudV.Location = new System.Drawing.Point(117, 9);
            this.nudV.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.nudV.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudV.Name = "nudV";
            this.nudV.Size = new System.Drawing.Size(100, 20);
            this.nudV.TabIndex = 1;
            this.nudV.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // InterbranchWarehousesCalendarEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 188);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "InterbranchWarehousesCalendarEditForm";
            this.Text = "Редактор точки межсклада";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InterbranchWarehousesCalendarEditForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TextBox tbPeriodTo;
        private System.Windows.Forms.TextBox tbMcuToName;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblMcuTo;
        private System.Windows.Forms.Label lblRD;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.NumericUpDown nudV;
        private System.Windows.Forms.DateTimePicker dtpRD;
        private System.Windows.Forms.CheckBox cbNCD;
        private System.Windows.Forms.CheckBox cbNF;
    }
}