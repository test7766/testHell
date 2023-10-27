namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    partial class ChangeSeriesControl
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
            this.lblQuantity = new System.Windows.Forms.Label();
            this.chbSplit = new System.Windows.Forms.CheckBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbSeries = new System.Windows.Forms.TextBox();
            this.lblSeries = new System.Windows.Forms.Label();
            this.btnSeries = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantity.Location = new System.Drawing.Point(92, 7);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(116, 13);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Количество:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chbSplit
            // 
            this.chbSplit.AutoSize = true;
            this.chbSplit.Location = new System.Drawing.Point(6, 6);
            this.chbSplit.Name = "chbSplit";
            this.chbSplit.Size = new System.Drawing.Size(80, 17);
            this.chbSplit.TabIndex = 1;
            this.chbSplit.Text = "Разделить";
            this.chbSplit.UseVisualStyleBackColor = true;
            this.chbSplit.CheckedChanged += new System.EventHandler(this.chbSplit_CheckedChanged);
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(214, 4);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.ReadOnly = true;
            this.tbQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbQuantity.TabIndex = 2;
            this.tbQuantity.TextChanged += new System.EventHandler(this.tbQuantity_TextChanged);
            // 
            // tbSeries
            // 
            this.tbSeries.Location = new System.Drawing.Point(421, 4);
            this.tbSeries.Name = "tbSeries";
            this.tbSeries.ReadOnly = true;
            this.tbSeries.Size = new System.Drawing.Size(100, 20);
            this.tbSeries.TabIndex = 4;
            // 
            // lblSeries
            // 
            this.lblSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeries.Location = new System.Drawing.Point(320, 7);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Size = new System.Drawing.Size(95, 13);
            this.lblSeries.TabIndex = 3;
            this.lblSeries.Text = "Серия:";
            this.lblSeries.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSeries
            // 
            this.btnSeries.Location = new System.Drawing.Point(516, 2);
            this.btnSeries.Name = "btnSeries";
            this.btnSeries.Size = new System.Drawing.Size(37, 23);
            this.btnSeries.TabIndex = 5;
            this.btnSeries.Text = "...";
            this.btnSeries.UseVisualStyleBackColor = true;
            this.btnSeries.Click += new System.EventHandler(this.btnSeries_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(25, 26);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(11, 13);
            this.lblError.TabIndex = 9;
            this.lblError.Text = "*";
            // 
            // ChangeSeriesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSeries);
            this.Controls.Add(this.tbSeries);
            this.Controls.Add(this.lblSeries);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.chbSplit);
            this.Controls.Add(this.lblQuantity);
            this.Name = "ChangeSeriesControl";
            this.Size = new System.Drawing.Size(600, 40);
            this.Load += new System.EventHandler(this.ChangeSeriesControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.CheckBox chbSplit;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbSeries;
        private System.Windows.Forms.Label lblSeries;
        private System.Windows.Forms.Button btnSeries;
        private System.Windows.Forms.Label lblError;
    }
}
