namespace WMSOffice.Dialogs.Quality
{
    partial class ManufacturerPlantEditorForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbManufacturerPlant = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(563, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(653, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 61);
            this.pnlButtons.Size = new System.Drawing.Size(480, 43);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.manufacturer;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // tbManufacturerPlant
            // 
            this.tbManufacturerPlant.Location = new System.Drawing.Point(68, 11);
            this.tbManufacturerPlant.Multiline = true;
            this.tbManufacturerPlant.Name = "tbManufacturerPlant";
            this.tbManufacturerPlant.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbManufacturerPlant.Size = new System.Drawing.Size(400, 50);
            this.tbManufacturerPlant.TabIndex = 0;
            // 
            // ManufacturerPlantEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 104);
            this.Controls.Add(this.tbManufacturerPlant);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ManufacturerPlantEditorForm";
            this.Text = "Коригування заводу виробника";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tbManufacturerPlant, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbManufacturerPlant;
    }
}