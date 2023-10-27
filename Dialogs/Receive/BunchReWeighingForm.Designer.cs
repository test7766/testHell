namespace WMSOffice.Dialogs.Receive
{
    partial class BunchReWeighingForm
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
            this.gbBunchMadeType = new System.Windows.Forms.GroupBox();
            this.rbHandMade = new System.Windows.Forms.RadioButton();
            this.rbManufacturerMade = new System.Windows.Forms.RadioButton();
            this.lblItemQuantityInBunch = new System.Windows.Forms.Label();
            this.lblItemQuantityInBunchValue = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.gbBunchMadeType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-307, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-217, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 128);
            this.pnlButtons.Size = new System.Drawing.Size(254, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // gbBunchMadeType
            // 
            this.gbBunchMadeType.Controls.Add(this.rbHandMade);
            this.gbBunchMadeType.Controls.Add(this.rbManufacturerMade);
            this.gbBunchMadeType.Location = new System.Drawing.Point(12, 55);
            this.gbBunchMadeType.Name = "gbBunchMadeType";
            this.gbBunchMadeType.Size = new System.Drawing.Size(230, 70);
            this.gbBunchMadeType.TabIndex = 0;
            this.gbBunchMadeType.TabStop = false;
            this.gbBunchMadeType.Text = "Тип склейки";
            // 
            // rbHandMade
            // 
            this.rbHandMade.AutoSize = true;
            this.rbHandMade.Location = new System.Drawing.Point(12, 43);
            this.rbHandMade.Name = "rbHandMade";
            this.rbHandMade.Size = new System.Drawing.Size(94, 17);
            this.rbHandMade.TabIndex = 1;
            this.rbHandMade.Tag = "4";
            this.rbHandMade.Text = "Самодельная";
            this.rbHandMade.UseVisualStyleBackColor = true;
            this.rbHandMade.CheckedChanged += new System.EventHandler(this.rbBunchMadeType_CheckedChanged);
            // 
            // rbManufacturerMade
            // 
            this.rbManufacturerMade.AutoSize = true;
            this.rbManufacturerMade.Location = new System.Drawing.Point(12, 20);
            this.rbManufacturerMade.Name = "rbManufacturerMade";
            this.rbManufacturerMade.Size = new System.Drawing.Size(80, 17);
            this.rbManufacturerMade.TabIndex = 0;
            this.rbManufacturerMade.Tag = "3";
            this.rbManufacturerMade.Text = "Заводская";
            this.rbManufacturerMade.UseVisualStyleBackColor = true;
            this.rbManufacturerMade.CheckedChanged += new System.EventHandler(this.rbBunchMadeType_CheckedChanged);
            // 
            // lblItemQuantityInBunch
            // 
            this.lblItemQuantityInBunch.AutoSize = true;
            this.lblItemQuantityInBunch.Location = new System.Drawing.Point(12, 13);
            this.lblItemQuantityInBunch.Name = "lblItemQuantityInBunch";
            this.lblItemQuantityInBunch.Size = new System.Drawing.Size(91, 26);
            this.lblItemQuantityInBunch.TabIndex = 2;
            this.lblItemQuantityInBunch.Text = "Кол-во упаковок\r\nв склейке (шт.):";
            // 
            // lblItemQuantityInBunchValue
            // 
            this.lblItemQuantityInBunchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemQuantityInBunchValue.Location = new System.Drawing.Point(132, 13);
            this.lblItemQuantityInBunchValue.Name = "lblItemQuantityInBunchValue";
            this.lblItemQuantityInBunchValue.Size = new System.Drawing.Size(110, 23);
            this.lblItemQuantityInBunchValue.TabIndex = 3;
            this.lblItemQuantityInBunchValue.Text = "-";
            this.lblItemQuantityInBunchValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BunchReWeighingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 171);
            this.Controls.Add(this.lblItemQuantityInBunchValue);
            this.Controls.Add(this.lblItemQuantityInBunch);
            this.Controls.Add(this.gbBunchMadeType);
            this.Name = "BunchReWeighingForm";
            this.Text = "Форма актуализации веса склейки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BunchReWeighingForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.gbBunchMadeType, 0);
            this.Controls.SetChildIndex(this.lblItemQuantityInBunch, 0);
            this.Controls.SetChildIndex(this.lblItemQuantityInBunchValue, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbBunchMadeType.ResumeLayout(false);
            this.gbBunchMadeType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBunchMadeType;
        private System.Windows.Forms.RadioButton rbHandMade;
        private System.Windows.Forms.RadioButton rbManufacturerMade;
        private System.Windows.Forms.Label lblItemQuantityInBunch;
        private System.Windows.Forms.Label lblItemQuantityInBunchValue;
    }
}