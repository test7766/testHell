namespace WMSOffice.Dialogs.WH.SD
{
    partial class SalesDispatcherSetDeliveryInfoForm
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
            this.lblAddress = new System.Windows.Forms.Label();
            this.cmbRoutePoints = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.dPVRDeliveryInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.tbArea = new System.Windows.Forms.TextBox();
            this.tbDistrict = new System.Windows.Forms.TextBox();
            this.tbStreet = new System.Windows.Forms.TextBox();
            this.tbBuilding = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.dP_VR_DeliveryInfoTableAdapter = new WMSOffice.Data.WHTableAdapters.DP_VR_DeliveryInfoTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dPVRDeliveryInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.pnlAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2417, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2507, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 218);
            this.pnlButtons.Size = new System.Drawing.Size(724, 43);
            this.pnlButtons.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(13, 13);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(94, 13);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Адрес доставки :";
            // 
            // cmbRoutePoints
            // 
            this.cmbRoutePoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRoutePoints.DataSource = this.dPVRDeliveryInfoBindingSource;
            this.cmbRoutePoints.DisplayMember = "combined_name";
            this.cmbRoutePoints.FormattingEnabled = true;
            this.cmbRoutePoints.Location = new System.Drawing.Point(113, 9);
            this.cmbRoutePoints.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseRegexs;
            this.cmbRoutePoints.Name = "cmbRoutePoints";
            this.cmbRoutePoints.Size = new System.Drawing.Size(599, 21);
            this.cmbRoutePoints.TabIndex = 3;
            this.cmbRoutePoints.UseCalcAdaptiveDropDownSize = true;
            this.cmbRoutePoints.ValueMember = "route_point_id";
            this.cmbRoutePoints.DropDown += new System.EventHandler(this.cmbRoutePoints_DropDown);
            // 
            // dPVRDeliveryInfoBindingSource
            // 
            this.dPVRDeliveryInfoBindingSource.DataMember = "DP_VR_DeliveryInfo";
            this.dPVRDeliveryInfoBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlAddress
            // 
            this.pnlAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddress.Controls.Add(this.tbArea);
            this.pnlAddress.Controls.Add(this.tbDistrict);
            this.pnlAddress.Controls.Add(this.tbStreet);
            this.pnlAddress.Controls.Add(this.tbBuilding);
            this.pnlAddress.Controls.Add(this.tbCity);
            this.pnlAddress.Controls.Add(this.lblBuilding);
            this.pnlAddress.Controls.Add(this.lblCity);
            this.pnlAddress.Controls.Add(this.lblStreet);
            this.pnlAddress.Controls.Add(this.lblDistrict);
            this.pnlAddress.Controls.Add(this.lblArea);
            this.pnlAddress.Location = new System.Drawing.Point(113, 46);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(599, 160);
            this.pnlAddress.TabIndex = 4;
            // 
            // tbArea
            // 
            this.tbArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbArea.BackColor = System.Drawing.SystemColors.Window;
            this.tbArea.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dPVRDeliveryInfoBindingSource, "area", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbArea.Location = new System.Drawing.Point(129, 9);
            this.tbArea.Name = "tbArea";
            this.tbArea.ReadOnly = true;
            this.tbArea.Size = new System.Drawing.Size(455, 20);
            this.tbArea.TabIndex = 1;
            // 
            // tbDistrict
            // 
            this.tbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDistrict.BackColor = System.Drawing.SystemColors.Window;
            this.tbDistrict.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dPVRDeliveryInfoBindingSource, "district", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDistrict.Location = new System.Drawing.Point(129, 38);
            this.tbDistrict.Name = "tbDistrict";
            this.tbDistrict.ReadOnly = true;
            this.tbDistrict.Size = new System.Drawing.Size(455, 20);
            this.tbDistrict.TabIndex = 3;
            // 
            // tbStreet
            // 
            this.tbStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStreet.BackColor = System.Drawing.SystemColors.Window;
            this.tbStreet.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dPVRDeliveryInfoBindingSource, "street", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbStreet.Location = new System.Drawing.Point(129, 96);
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.ReadOnly = true;
            this.tbStreet.Size = new System.Drawing.Size(455, 20);
            this.tbStreet.TabIndex = 7;
            // 
            // tbBuilding
            // 
            this.tbBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBuilding.BackColor = System.Drawing.SystemColors.Window;
            this.tbBuilding.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dPVRDeliveryInfoBindingSource, "building", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbBuilding.Location = new System.Drawing.Point(129, 125);
            this.tbBuilding.Name = "tbBuilding";
            this.tbBuilding.ReadOnly = true;
            this.tbBuilding.Size = new System.Drawing.Size(455, 20);
            this.tbBuilding.TabIndex = 9;
            // 
            // tbCity
            // 
            this.tbCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCity.BackColor = System.Drawing.SystemColors.Window;
            this.tbCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dPVRDeliveryInfoBindingSource, "city", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbCity.Location = new System.Drawing.Point(129, 67);
            this.tbCity.Name = "tbCity";
            this.tbCity.ReadOnly = true;
            this.tbCity.Size = new System.Drawing.Size(455, 20);
            this.tbCity.TabIndex = 5;
            // 
            // lblBuilding
            // 
            this.lblBuilding.AutoSize = true;
            this.lblBuilding.Location = new System.Drawing.Point(13, 129);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(76, 13);
            this.lblBuilding.TabIndex = 8;
            this.lblBuilding.Text = "Номер дома :";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(13, 71);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(108, 13);
            this.lblCity.TabIndex = 4;
            this.lblCity.Text = "Населенный пункт :";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(13, 100);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(45, 13);
            this.lblStreet.TabIndex = 6;
            this.lblStreet.Text = "Улица :";
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(13, 42);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(44, 13);
            this.lblDistrict.TabIndex = 2;
            this.lblDistrict.Text = "Район :";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(13, 13);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(56, 13);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Область :";
            // 
            // dP_VR_DeliveryInfoTableAdapter
            // 
            this.dP_VR_DeliveryInfoTableAdapter.ClearBeforeFill = true;
            // 
            // SalesDispatcherSetDeliveryInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 261);
            this.Controls.Add(this.pnlAddress);
            this.Controls.Add(this.cmbRoutePoints);
            this.Controls.Add(this.lblAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "SalesDispatcherSetDeliveryInfoForm";
            this.Text = "Детали доставки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalesDispatcherSetDeliverySettingsForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.cmbRoutePoints, 0);
            this.Controls.SetChildIndex(this.pnlAddress, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dPVRDeliveryInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddress;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox cmbRoutePoints;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox tbArea;
        private System.Windows.Forms.TextBox tbDistrict;
        private System.Windows.Forms.TextBox tbStreet;
        private System.Windows.Forms.TextBox tbBuilding;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.BindingSource dPVRDeliveryInfoBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.DP_VR_DeliveryInfoTableAdapter dP_VR_DeliveryInfoTableAdapter;
    }
}