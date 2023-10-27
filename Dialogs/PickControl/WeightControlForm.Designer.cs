namespace WMSOffice.Dialogs.PickControl
{
    partial class WeightControlForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblMarker = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblBoxBarCode = new System.Windows.Forms.Label();
            this.lblPickSlipNumber = new System.Windows.Forms.Label();
            this.tbPickSlipNumber = new System.Windows.Forms.TextBox();
            this.lblStation = new System.Windows.Forms.Label();
            this.tbStationDescription = new System.Windows.Forms.TextBox();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.lblWeightControl = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnObtainWeight = new System.Windows.Forms.Button();
            this.lblPreviousBoxBarCode = new System.Windows.Forms.Label();
            this.tbPreviousBoxBarCode = new System.Windows.Forms.TextBox();
            this.btnFetchPickSlip = new System.Windows.Forms.Button();
            this.lblBoxName = new System.Windows.Forms.Label();
            this.btnReleasePickSlip = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tbsBoxBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlFooter.Controls.Add(this.lblMarker);
            this.pnlFooter.Controls.Add(this.lblMode);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 331);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(844, 40);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblMarker
            // 
            this.lblMarker.Location = new System.Drawing.Point(670, 9);
            this.lblMarker.Name = "lblMarker";
            this.lblMarker.Size = new System.Drawing.Size(75, 23);
            this.lblMarker.TabIndex = 2;
            this.lblMarker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMode.ForeColor = System.Drawing.Color.Blue;
            this.lblMode.Location = new System.Drawing.Point(12, 8);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(0, 25);
            this.lblMode.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(757, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblBoxBarCode
            // 
            this.lblBoxBarCode.AutoSize = true;
            this.lblBoxBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBoxBarCode.Location = new System.Drawing.Point(12, 88);
            this.lblBoxBarCode.Name = "lblBoxBarCode";
            this.lblBoxBarCode.Size = new System.Drawing.Size(71, 25);
            this.lblBoxBarCode.TabIndex = 2;
            this.lblBoxBarCode.Text = "Ящик";
            // 
            // lblPickSlipNumber
            // 
            this.lblPickSlipNumber.AutoSize = true;
            this.lblPickSlipNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPickSlipNumber.Location = new System.Drawing.Point(12, 137);
            this.lblPickSlipNumber.Name = "lblPickSlipNumber";
            this.lblPickSlipNumber.Size = new System.Drawing.Size(134, 25);
            this.lblPickSlipNumber.TabIndex = 4;
            this.lblPickSlipNumber.Text = "Сборочный";
            // 
            // tbPickSlipNumber
            // 
            this.tbPickSlipNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPickSlipNumber.Location = new System.Drawing.Point(170, 134);
            this.tbPickSlipNumber.Name = "tbPickSlipNumber";
            this.tbPickSlipNumber.ReadOnly = true;
            this.tbPickSlipNumber.Size = new System.Drawing.Size(587, 31);
            this.tbPickSlipNumber.TabIndex = 5;
            this.tbPickSlipNumber.Text = "-";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStation.Location = new System.Drawing.Point(12, 13);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(103, 25);
            this.lblStation.TabIndex = 0;
            this.lblStation.Text = "Станция";
            // 
            // tbStationDescription
            // 
            this.tbStationDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbStationDescription.Location = new System.Drawing.Point(170, 10);
            this.tbStationDescription.Name = "tbStationDescription";
            this.tbStationDescription.ReadOnly = true;
            this.tbStationDescription.Size = new System.Drawing.Size(662, 31);
            this.tbStationDescription.TabIndex = 1;
            // 
            // tbWeight
            // 
            this.tbWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWeight.Location = new System.Drawing.Point(170, 183);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.ReadOnly = true;
            this.tbWeight.Size = new System.Drawing.Size(587, 31);
            this.tbWeight.TabIndex = 8;
            this.tbWeight.Text = "-";
            // 
            // lblWeightControl
            // 
            this.lblWeightControl.AutoSize = true;
            this.lblWeightControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWeightControl.Location = new System.Drawing.Point(12, 186);
            this.lblWeightControl.Name = "lblWeightControl";
            this.lblWeightControl.Size = new System.Drawing.Size(52, 25);
            this.lblWeightControl.TabIndex = 7;
            this.lblWeightControl.Text = "Вес";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlHeader.Controls.Add(this.tbStationDescription);
            this.pnlHeader.Controls.Add(this.lblStation);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(844, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnObtainWeight
            // 
            this.btnObtainWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnObtainWeight.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnObtainWeight.Location = new System.Drawing.Point(763, 183);
            this.btnObtainWeight.Name = "btnObtainWeight";
            this.btnObtainWeight.Size = new System.Drawing.Size(31, 31);
            this.btnObtainWeight.TabIndex = 9;
            this.btnObtainWeight.UseVisualStyleBackColor = true;
            this.btnObtainWeight.Click += new System.EventHandler(this.btnObtainWeight_Click);
            // 
            // lblPreviousBoxBarCode
            // 
            this.lblPreviousBoxBarCode.AutoSize = true;
            this.lblPreviousBoxBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPreviousBoxBarCode.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPreviousBoxBarCode.Location = new System.Drawing.Point(12, 267);
            this.lblPreviousBoxBarCode.Name = "lblPreviousBoxBarCode";
            this.lblPreviousBoxBarCode.Size = new System.Drawing.Size(152, 50);
            this.lblPreviousBoxBarCode.TabIndex = 10;
            this.lblPreviousBoxBarCode.Text = "Предыдущий\r\nящик";
            // 
            // tbPreviousBoxBarCode
            // 
            this.tbPreviousBoxBarCode.BackColor = System.Drawing.SystemColors.Control;
            this.tbPreviousBoxBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPreviousBoxBarCode.ForeColor = System.Drawing.Color.Gray;
            this.tbPreviousBoxBarCode.Location = new System.Drawing.Point(170, 286);
            this.tbPreviousBoxBarCode.Name = "tbPreviousBoxBarCode";
            this.tbPreviousBoxBarCode.ReadOnly = true;
            this.tbPreviousBoxBarCode.Size = new System.Drawing.Size(587, 31);
            this.tbPreviousBoxBarCode.TabIndex = 11;
            this.tbPreviousBoxBarCode.Text = "-";
            // 
            // btnFetchPickSlip
            // 
            this.btnFetchPickSlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFetchPickSlip.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnFetchPickSlip.Location = new System.Drawing.Point(763, 134);
            this.btnFetchPickSlip.Name = "btnFetchPickSlip";
            this.btnFetchPickSlip.Size = new System.Drawing.Size(31, 31);
            this.btnFetchPickSlip.TabIndex = 6;
            this.btnFetchPickSlip.UseVisualStyleBackColor = true;
            this.btnFetchPickSlip.Click += new System.EventHandler(this.btnFetchPickSlip_Click);
            // 
            // lblBoxName
            // 
            this.lblBoxName.BackColor = System.Drawing.SystemColors.Info;
            this.lblBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBoxName.ForeColor = System.Drawing.Color.Blue;
            this.lblBoxName.Location = new System.Drawing.Point(170, 56);
            this.lblBoxName.Name = "lblBoxName";
            this.lblBoxName.Size = new System.Drawing.Size(587, 25);
            this.lblBoxName.TabIndex = 12;
            // 
            // btnReleasePickSlip
            // 
            this.btnReleasePickSlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReleasePickSlip.Image = global::WMSOffice.Properties.Resources.Delete_10x10;
            this.btnReleasePickSlip.Location = new System.Drawing.Point(800, 134);
            this.btnReleasePickSlip.Name = "btnReleasePickSlip";
            this.btnReleasePickSlip.Size = new System.Drawing.Size(31, 31);
            this.btnReleasePickSlip.TabIndex = 13;
            this.btnReleasePickSlip.UseVisualStyleBackColor = true;
            this.btnReleasePickSlip.Click += new System.EventHandler(this.btnReleasePickSlip_Click);
            // 
            // tbsBoxBarCode
            // 
            this.tbsBoxBarCode.AllowType = true;
            this.tbsBoxBarCode.AutoConvert = true;
            this.tbsBoxBarCode.DelayThreshold = 50;
            this.tbsBoxBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbsBoxBarCode.Location = new System.Drawing.Point(163, 79);
            this.tbsBoxBarCode.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tbsBoxBarCode.Name = "tbsBoxBarCode";
            this.tbsBoxBarCode.RaiseTextChangeWithoutEnter = false;
            this.tbsBoxBarCode.ReadOnly = false;
            this.tbsBoxBarCode.Size = new System.Drawing.Size(687, 43);
            this.tbsBoxBarCode.TabIndex = 3;
            this.tbsBoxBarCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsBoxBarCode.UseParentFont = true;
            this.tbsBoxBarCode.UseScanModeOnly = false;
            // 
            // WeightControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(844, 371);
            this.Controls.Add(this.btnReleasePickSlip);
            this.Controls.Add(this.lblBoxName);
            this.Controls.Add(this.btnFetchPickSlip);
            this.Controls.Add(this.tbPreviousBoxBarCode);
            this.Controls.Add(this.lblPreviousBoxBarCode);
            this.Controls.Add(this.btnObtainWeight);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tbWeight);
            this.Controls.Add(this.lblWeightControl);
            this.Controls.Add(this.tbPickSlipNumber);
            this.Controls.Add(this.lblPickSlipNumber);
            this.Controls.Add(this.lblBoxBarCode);
            this.Controls.Add(this.tbsBoxBarCode);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WeightControlForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Весовой контроль сборки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WeightControlForm_FormClosed);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClose;
        private WMSOffice.Controls.TextBoxScaner tbsBoxBarCode;
        private System.Windows.Forms.Label lblBoxBarCode;
        private System.Windows.Forms.Label lblPickSlipNumber;
        private System.Windows.Forms.TextBox tbPickSlipNumber;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.TextBox tbStationDescription;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.Label lblWeightControl;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnObtainWeight;
        private System.Windows.Forms.Label lblPreviousBoxBarCode;
        private System.Windows.Forms.TextBox tbPreviousBoxBarCode;
        private System.Windows.Forms.Button btnFetchPickSlip;
        private System.Windows.Forms.Label lblBoxName;
        private System.Windows.Forms.Button btnReleasePickSlip;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblMarker;
        private System.Windows.Forms.ToolTip toolTip;
    }
}