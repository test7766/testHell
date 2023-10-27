namespace WMSOffice.Dialogs.WH
{
    partial class MovementsAdditionalFilterSelectionForm
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
            this.cbWarehouse = new System.Windows.Forms.CheckBox();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.cbLocation = new System.Windows.Forms.CheckBox();
            this.tbBatch = new System.Windows.Forms.TextBox();
            this.cbBatch = new System.Windows.Forms.CheckBox();
            this.cbPeriod = new System.Windows.Forms.CheckBox();
            this.tbPeriod = new System.Windows.Forms.TextBox();
            this.cbItem = new System.Windows.Forms.CheckBox();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblBatch = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(168, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(258, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 173);
            this.pnlButtons.Size = new System.Drawing.Size(349, 43);
            this.pnlButtons.TabIndex = 15;
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.AutoSize = true;
            this.cbWarehouse.Location = new System.Drawing.Point(12, 78);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(15, 14);
            this.cbWarehouse.TabIndex = 6;
            this.cbWarehouse.UseVisualStyleBackColor = true;
            this.cbWarehouse.CheckedChanged += new System.EventHandler(this.cbWarehouse_CheckedChanged);
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouse.Location = new System.Drawing.Point(82, 75);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.ReadOnly = true;
            this.tbWarehouse.Size = new System.Drawing.Size(256, 20);
            this.tbWarehouse.TabIndex = 8;
            // 
            // tbLocation
            // 
            this.tbLocation.BackColor = System.Drawing.SystemColors.Window;
            this.tbLocation.Location = new System.Drawing.Point(82, 108);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ReadOnly = true;
            this.tbLocation.Size = new System.Drawing.Size(256, 20);
            this.tbLocation.TabIndex = 11;
            // 
            // cbLocation
            // 
            this.cbLocation.AutoSize = true;
            this.cbLocation.Location = new System.Drawing.Point(12, 111);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(15, 14);
            this.cbLocation.TabIndex = 9;
            this.cbLocation.UseVisualStyleBackColor = true;
            this.cbLocation.CheckedChanged += new System.EventHandler(this.cbLocation_CheckedChanged);
            // 
            // tbBatch
            // 
            this.tbBatch.BackColor = System.Drawing.SystemColors.Window;
            this.tbBatch.Location = new System.Drawing.Point(82, 141);
            this.tbBatch.Name = "tbBatch";
            this.tbBatch.ReadOnly = true;
            this.tbBatch.Size = new System.Drawing.Size(256, 20);
            this.tbBatch.TabIndex = 14;
            // 
            // cbBatch
            // 
            this.cbBatch.AutoSize = true;
            this.cbBatch.Location = new System.Drawing.Point(12, 144);
            this.cbBatch.Name = "cbBatch";
            this.cbBatch.Size = new System.Drawing.Size(15, 14);
            this.cbBatch.TabIndex = 12;
            this.cbBatch.UseVisualStyleBackColor = true;
            this.cbBatch.CheckedChanged += new System.EventHandler(this.cbBatch_CheckedChanged);
            // 
            // cbPeriod
            // 
            this.cbPeriod.AutoSize = true;
            this.cbPeriod.Location = new System.Drawing.Point(12, 45);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(15, 14);
            this.cbPeriod.TabIndex = 3;
            this.cbPeriod.UseVisualStyleBackColor = true;
            this.cbPeriod.CheckedChanged += new System.EventHandler(this.cbPeriod_CheckedChanged);
            // 
            // tbPeriod
            // 
            this.tbPeriod.BackColor = System.Drawing.SystemColors.Window;
            this.tbPeriod.Location = new System.Drawing.Point(82, 42);
            this.tbPeriod.Name = "tbPeriod";
            this.tbPeriod.ReadOnly = true;
            this.tbPeriod.Size = new System.Drawing.Size(256, 20);
            this.tbPeriod.TabIndex = 5;
            // 
            // cbItem
            // 
            this.cbItem.AutoSize = true;
            this.cbItem.Location = new System.Drawing.Point(12, 12);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(15, 14);
            this.cbItem.TabIndex = 0;
            this.cbItem.UseVisualStyleBackColor = true;
            this.cbItem.CheckedChanged += new System.EventHandler(this.cbItem_CheckedChanged);
            // 
            // tbItem
            // 
            this.tbItem.BackColor = System.Drawing.SystemColors.Window;
            this.tbItem.Location = new System.Drawing.Point(81, 9);
            this.tbItem.Name = "tbItem";
            this.tbItem.ReadOnly = true;
            this.tbItem.Size = new System.Drawing.Size(256, 20);
            this.tbItem.TabIndex = 2;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(31, 13);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(38, 13);
            this.lblItem.TabIndex = 1;
            this.lblItem.Text = "Товар";
            this.lblItem.Click += new System.EventHandler(this.lblItem_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(31, 46);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(45, 13);
            this.lblPeriod.TabIndex = 4;
            this.lblPeriod.Text = "Период";
            this.lblPeriod.Click += new System.EventHandler(this.lblPeriod_Click);
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(31, 79);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(38, 13);
            this.lblWarehouse.TabIndex = 7;
            this.lblWarehouse.Text = "Склад";
            this.lblWarehouse.Click += new System.EventHandler(this.lblWarehouse_Click);
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(31, 145);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(44, 13);
            this.lblBatch.TabIndex = 13;
            this.lblBatch.Text = "Партия";
            this.lblBatch.Click += new System.EventHandler(this.lblBatch_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(31, 112);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(39, 13);
            this.lblLocation.TabIndex = 10;
            this.lblLocation.Text = "Место";
            this.lblLocation.Click += new System.EventHandler(this.lblLocation_Click);
            // 
            // MovementsAdditionalFilterSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 216);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblBatch);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.tbItem);
            this.Controls.Add(this.cbItem);
            this.Controls.Add(this.tbPeriod);
            this.Controls.Add(this.cbPeriod);
            this.Controls.Add(this.tbBatch);
            this.Controls.Add(this.cbBatch);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.tbWarehouse);
            this.Controls.Add(this.cbWarehouse);
            this.Name = "MovementsAdditionalFilterSelectionForm";
            this.Text = "Основные параметры поиска движения товара";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovementsAdditionalFilterSelectionForm_FormClosing);
            this.Controls.SetChildIndex(this.cbWarehouse, 0);
            this.Controls.SetChildIndex(this.tbWarehouse, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cbLocation, 0);
            this.Controls.SetChildIndex(this.tbLocation, 0);
            this.Controls.SetChildIndex(this.cbBatch, 0);
            this.Controls.SetChildIndex(this.tbBatch, 0);
            this.Controls.SetChildIndex(this.cbPeriod, 0);
            this.Controls.SetChildIndex(this.tbPeriod, 0);
            this.Controls.SetChildIndex(this.cbItem, 0);
            this.Controls.SetChildIndex(this.tbItem, 0);
            this.Controls.SetChildIndex(this.lblItem, 0);
            this.Controls.SetChildIndex(this.lblPeriod, 0);
            this.Controls.SetChildIndex(this.lblWarehouse, 0);
            this.Controls.SetChildIndex(this.lblBatch, 0);
            this.Controls.SetChildIndex(this.lblLocation, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbWarehouse;
        private System.Windows.Forms.TextBox tbWarehouse;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.CheckBox cbLocation;
        private System.Windows.Forms.TextBox tbBatch;
        private System.Windows.Forms.CheckBox cbBatch;
        private System.Windows.Forms.CheckBox cbPeriod;
        private System.Windows.Forms.TextBox tbPeriod;
        private System.Windows.Forms.CheckBox cbItem;
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.Label lblLocation;
    }
}