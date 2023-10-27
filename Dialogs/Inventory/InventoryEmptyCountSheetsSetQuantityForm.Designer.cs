namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryEmptyCountSheetsSetQuantityForm
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
            this.nudEmptyCountSheetsQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblEmptyCountSheetsQuantity = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmptyCountSheetsQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(117, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(207, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 78);
            this.pnlButtons.Size = new System.Drawing.Size(294, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // nudEmptyCountSheetsQuantity
            // 
            this.nudEmptyCountSheetsQuantity.Location = new System.Drawing.Point(140, 29);
            this.nudEmptyCountSheetsQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEmptyCountSheetsQuantity.Name = "nudEmptyCountSheetsQuantity";
            this.nudEmptyCountSheetsQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudEmptyCountSheetsQuantity.TabIndex = 1;
            this.nudEmptyCountSheetsQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEmptyCountSheetsQuantity
            // 
            this.lblEmptyCountSheetsQuantity.AutoSize = true;
            this.lblEmptyCountSheetsQuantity.Location = new System.Drawing.Point(12, 33);
            this.lblEmptyCountSheetsQuantity.Name = "lblEmptyCountSheetsQuantity";
            this.lblEmptyCountSheetsQuantity.Size = new System.Drawing.Size(122, 13);
            this.lblEmptyCountSheetsQuantity.TabIndex = 0;
            this.lblEmptyCountSheetsQuantity.Text = "Кол-во \"пустографок\":";
            // 
            // InventoryEmptyCountSheetsSetQuantityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 121);
            this.Controls.Add(this.lblEmptyCountSheetsQuantity);
            this.Controls.Add(this.nudEmptyCountSheetsQuantity);
            this.Name = "InventoryEmptyCountSheetsSetQuantityForm";
            this.Text = "Укажите количество \"пустографок\"";
            this.Controls.SetChildIndex(this.nudEmptyCountSheetsQuantity, 0);
            this.Controls.SetChildIndex(this.lblEmptyCountSheetsQuantity, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudEmptyCountSheetsQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudEmptyCountSheetsQuantity;
        private System.Windows.Forms.Label lblEmptyCountSheetsQuantity;
    }
}