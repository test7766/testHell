namespace WMSOffice.Dialogs.InterBranch
{
    partial class ReceiptImagesForm
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
            this.scMainLayout = new System.Windows.Forms.SplitContainer();
            this.pnlDriverInfo = new System.Windows.Forms.Panel();
            this.gbNumbers = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTrailerNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCarNumber = new System.Windows.Forms.TextBox();
            this.cbIsHiredCar = new System.Windows.Forms.CheckBox();
            this.tbDriverName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCarName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageViewerControl = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.pnlButtons.SuspendLayout();
            this.scMainLayout.Panel1.SuspendLayout();
            this.scMainLayout.Panel2.SuspendLayout();
            this.scMainLayout.SuspendLayout();
            this.pnlDriverInfo.SuspendLayout();
            this.gbNumbers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2921, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3011, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 479);
            this.pnlButtons.Size = new System.Drawing.Size(744, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // scMainLayout
            // 
            this.scMainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scMainLayout.Location = new System.Drawing.Point(0, 0);
            this.scMainLayout.Name = "scMainLayout";
            this.scMainLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainLayout.Panel1
            // 
            this.scMainLayout.Panel1.Controls.Add(this.pnlDriverInfo);
            // 
            // scMainLayout.Panel2
            // 
            this.scMainLayout.Panel2.Controls.Add(this.imageViewerControl);
            this.scMainLayout.Size = new System.Drawing.Size(744, 473);
            this.scMainLayout.SplitterDistance = 85;
            this.scMainLayout.TabIndex = 0;
            // 
            // pnlDriverInfo
            // 
            this.pnlDriverInfo.Controls.Add(this.gbNumbers);
            this.pnlDriverInfo.Controls.Add(this.cbIsHiredCar);
            this.pnlDriverInfo.Controls.Add(this.tbDriverName);
            this.pnlDriverInfo.Controls.Add(this.label3);
            this.pnlDriverInfo.Controls.Add(this.tbCarName);
            this.pnlDriverInfo.Controls.Add(this.label1);
            this.pnlDriverInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriverInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlDriverInfo.Name = "pnlDriverInfo";
            this.pnlDriverInfo.Size = new System.Drawing.Size(744, 85);
            this.pnlDriverInfo.TabIndex = 0;
            this.pnlDriverInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDriverInfo_Paint);
            // 
            // gbNumbers
            // 
            this.gbNumbers.Controls.Add(this.label5);
            this.gbNumbers.Controls.Add(this.tbTrailerNumber);
            this.gbNumbers.Controls.Add(this.label4);
            this.gbNumbers.Controls.Add(this.tbCarNumber);
            this.gbNumbers.Location = new System.Drawing.Point(6, 30);
            this.gbNumbers.Name = "gbNumbers";
            this.gbNumbers.Size = new System.Drawing.Size(735, 50);
            this.gbNumbers.TabIndex = 5;
            this.gbNumbers.TabStop = false;
            this.gbNumbers.Text = "Номера";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Прицеп";
            // 
            // tbTrailerNumber
            // 
            this.tbTrailerNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbTrailerNumber.Location = new System.Drawing.Point(429, 18);
            this.tbTrailerNumber.Name = "tbTrailerNumber";
            this.tbTrailerNumber.ReadOnly = true;
            this.tbTrailerNumber.Size = new System.Drawing.Size(291, 20);
            this.tbTrailerNumber.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Автомобиль";
            // 
            // tbCarNumber
            // 
            this.tbCarNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbCarNumber.Location = new System.Drawing.Point(81, 18);
            this.tbCarNumber.Name = "tbCarNumber";
            this.tbCarNumber.ReadOnly = true;
            this.tbCarNumber.Size = new System.Drawing.Size(291, 20);
            this.tbCarNumber.TabIndex = 1;
            // 
            // cbIsHiredCar
            // 
            this.cbIsHiredCar.AutoSize = true;
            this.cbIsHiredCar.Enabled = false;
            this.cbIsHiredCar.Location = new System.Drawing.Point(249, 7);
            this.cbIsHiredCar.Name = "cbIsHiredCar";
            this.cbIsHiredCar.Size = new System.Drawing.Size(129, 17);
            this.cbIsHiredCar.TabIndex = 2;
            this.cbIsHiredCar.Text = "Наемный транспорт";
            this.cbIsHiredCar.UseVisualStyleBackColor = true;
            // 
            // tbDriverName
            // 
            this.tbDriverName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDriverName.Location = new System.Drawing.Point(441, 5);
            this.tbDriverName.Name = "tbDriverName";
            this.tbDriverName.ReadOnly = true;
            this.tbDriverName.Size = new System.Drawing.Size(300, 20);
            this.tbDriverName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Водитель";
            // 
            // tbCarName
            // 
            this.tbCarName.BackColor = System.Drawing.SystemColors.Window;
            this.tbCarName.Location = new System.Drawing.Point(78, 5);
            this.tbCarName.Name = "tbCarName";
            this.tbCarName.ReadOnly = true;
            this.tbCarName.Size = new System.Drawing.Size(165, 20);
            this.tbCarName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Автомобиль";
            // 
            // imageViewerControl
            // 
            this.imageViewerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerControl.CurrentItem = null;
            this.imageViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewerControl.Location = new System.Drawing.Point(0, 0);
            this.imageViewerControl.Name = "imageViewerControl";
            this.imageViewerControl.Size = new System.Drawing.Size(744, 384);
            this.imageViewerControl.TabIndex = 0;
            this.imageViewerControl.PreviewCurrentItem += new System.EventHandler(this.imageViewerControl_PreviewCurrentItem);
            // 
            // ReceiptImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 522);
            this.Controls.Add(this.scMainLayout);
            this.Name = "ReceiptImagesForm";
            this.Text = "Подтверждение документа фотоотчета";
            this.Load += new System.EventHandler(this.ReceiptImagesForm_Load);
            this.Controls.SetChildIndex(this.scMainLayout, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.scMainLayout.Panel1.ResumeLayout(false);
            this.scMainLayout.Panel2.ResumeLayout(false);
            this.scMainLayout.ResumeLayout(false);
            this.pnlDriverInfo.ResumeLayout(false);
            this.pnlDriverInfo.PerformLayout();
            this.gbNumbers.ResumeLayout(false);
            this.gbNumbers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMainLayout;
        private WMSOffice.Controls.Custom.ImageViewerControl imageViewerControl;
        private System.Windows.Forms.Panel pnlDriverInfo;
        private System.Windows.Forms.TextBox tbDriverName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCarName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbIsHiredCar;
        private System.Windows.Forms.GroupBox gbNumbers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTrailerNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCarNumber;
    }
}