namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    partial class BoxMeasurementControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbBox = new System.Windows.Forms.TextBox();
            this.lblBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(214, 3);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.ReadOnly = true;
            this.tbQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbQuantity.TabIndex = 0;
            this.tbQuantity.TextChanged += new System.EventHandler(this.tbQuantity_TextChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(3, 6);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(205, 17);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "Количество:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbBox
            // 
            this.tbBox.Location = new System.Drawing.Point(421, 3);
            this.tbBox.Name = "tbBox";
            this.tbBox.ReadOnly = true;
            this.tbBox.Size = new System.Drawing.Size(100, 20);
            this.tbBox.TabIndex = 2;
            // 
            // lblBox
            // 
            this.lblBox.Location = new System.Drawing.Point(320, 6);
            this.lblBox.Name = "lblBox";
            this.lblBox.Size = new System.Drawing.Size(95, 17);
            this.lblBox.TabIndex = 3;
            this.lblBox.Text = "Ящиков:";
            this.lblBox.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BoxMeasurementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBox);
            this.Controls.Add(this.tbBox);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.tbQuantity);
            this.Name = "BoxMeasurementControl";
            this.Size = new System.Drawing.Size(600, 24);
            this.Load += new System.EventHandler(this.BoxMeasurementControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbBox;
        private System.Windows.Forms.Label lblBox;
    }
}
