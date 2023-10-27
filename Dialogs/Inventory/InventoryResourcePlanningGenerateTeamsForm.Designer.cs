namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryResourcePlanningGenerateTeamsForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudInventoryPlanDurationHours = new System.Windows.Forms.NumericUpDown();
            this.dtpInventoryPlanDurationMinutes = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudProbablePercentOfSecondRecount = new System.Windows.Forms.NumericUpDown();
            this.nudProbablePercentOfThirdRecount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventoryPlanDurationHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProbablePercentOfSecondRecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProbablePercentOfThirdRecount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(156, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(246, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 128);
            this.pnlButtons.Size = new System.Drawing.Size(333, 43);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "минут";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 104;
            this.label4.Text = "часов";
            // 
            // nudInventoryPlanDurationHours
            // 
            this.nudInventoryPlanDurationHours.Location = new System.Drawing.Point(150, 16);
            this.nudInventoryPlanDurationHours.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudInventoryPlanDurationHours.Name = "nudInventoryPlanDurationHours";
            this.nudInventoryPlanDurationHours.Size = new System.Drawing.Size(40, 20);
            this.nudInventoryPlanDurationHours.TabIndex = 103;
            // 
            // dtpInventoryPlanDurationMinutes
            // 
            this.dtpInventoryPlanDurationMinutes.CustomFormat = "mm";
            this.dtpInventoryPlanDurationMinutes.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpInventoryPlanDurationMinutes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInventoryPlanDurationMinutes.Location = new System.Drawing.Point(238, 16);
            this.dtpInventoryPlanDurationMinutes.Name = "dtpInventoryPlanDurationMinutes";
            this.dtpInventoryPlanDurationMinutes.ShowUpDown = true;
            this.dtpInventoryPlanDurationMinutes.Size = new System.Drawing.Size(40, 20);
            this.dtpInventoryPlanDurationMinutes.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 101;
            this.label3.Text = "План. длительность инвентаризации:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 28);
            this.label1.TabIndex = 106;
            this.label1.Text = "Вероятный процент 2-го пересчета:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 28);
            this.label2.TabIndex = 107;
            this.label2.Text = "Вероятный процент 3-го пересчета:";
            // 
            // nudProbablePercentOfSecondRecount
            // 
            this.nudProbablePercentOfSecondRecount.Location = new System.Drawing.Point(150, 56);
            this.nudProbablePercentOfSecondRecount.Name = "nudProbablePercentOfSecondRecount";
            this.nudProbablePercentOfSecondRecount.Size = new System.Drawing.Size(40, 20);
            this.nudProbablePercentOfSecondRecount.TabIndex = 108;
            // 
            // nudProbablePercentOfThirdRecount
            // 
            this.nudProbablePercentOfThirdRecount.Location = new System.Drawing.Point(150, 93);
            this.nudProbablePercentOfThirdRecount.Name = "nudProbablePercentOfThirdRecount";
            this.nudProbablePercentOfThirdRecount.Size = new System.Drawing.Size(40, 20);
            this.nudProbablePercentOfThirdRecount.TabIndex = 109;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(196, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 110;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(196, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 111;
            this.label7.Text = "%";
            // 
            // InventoryResourcePlanningGenerateTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 171);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudProbablePercentOfThirdRecount);
            this.Controls.Add(this.nudProbablePercentOfSecondRecount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudInventoryPlanDurationHours);
            this.Controls.Add(this.dtpInventoryPlanDurationMinutes);
            this.Controls.Add(this.label3);
            this.Name = "InventoryResourcePlanningGenerateTeams";
            this.Text = "Формирование бригад";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryResourcePlanningGenerateTeams_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpInventoryPlanDurationMinutes, 0);
            this.Controls.SetChildIndex(this.nudInventoryPlanDurationHours, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.nudProbablePercentOfSecondRecount, 0);
            this.Controls.SetChildIndex(this.nudProbablePercentOfThirdRecount, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudInventoryPlanDurationHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProbablePercentOfSecondRecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProbablePercentOfThirdRecount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudInventoryPlanDurationHours;
        private System.Windows.Forms.DateTimePicker dtpInventoryPlanDurationMinutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudProbablePercentOfSecondRecount;
        private System.Windows.Forms.NumericUpDown nudProbablePercentOfThirdRecount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}