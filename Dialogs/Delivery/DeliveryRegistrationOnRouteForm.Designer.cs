namespace WMSOffice.Dialogs.Delivery
{
    partial class DeliveryRegistrationOnRouteForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.gbLinks = new System.Windows.Forms.GroupBox();
            this.scLinks = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPlacesCount28 = new System.Windows.Forms.TextBox();
            this.driverRouteNumbersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.stbLogger28 = new WMSOffice.Controls.TextBoxScaner();
            this.stbTermoBox28 = new WMSOffice.Controls.TextBoxScaner();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPlacesCount815 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.stbLogger815 = new WMSOffice.Controls.TextBoxScaner();
            this.stbTermoBox815 = new WMSOffice.Controls.TextBoxScaner();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.cmbActiveRoutes = new System.Windows.Forms.ComboBox();
            this.tbActiveRouteDescription = new System.Windows.Forms.TextBox();
            this.driverRouteNumbersTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.DriverRouteNumbersTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.gbLinks.SuspendLayout();
            this.scLinks.Panel1.SuspendLayout();
            this.scLinks.Panel2.SuspendLayout();
            this.scLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverRouteNumbersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3863, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3953, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 188);
            this.pnlButtons.Size = new System.Drawing.Size(634, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Активные маршруты :";
            // 
            // gbLinks
            // 
            this.gbLinks.Controls.Add(this.scLinks);
            this.gbLinks.Location = new System.Drawing.Point(12, 43);
            this.gbLinks.Name = "gbLinks";
            this.gbLinks.Size = new System.Drawing.Size(610, 140);
            this.gbLinks.TabIndex = 3;
            this.gbLinks.TabStop = false;
            this.gbLinks.Text = "Закрепления";
            // 
            // scLinks
            // 
            this.scLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scLinks.IsSplitterFixed = true;
            this.scLinks.Location = new System.Drawing.Point(3, 16);
            this.scLinks.Name = "scLinks";
            // 
            // scLinks.Panel1
            // 
            this.scLinks.Panel1.Controls.Add(this.label1);
            this.scLinks.Panel1.Controls.Add(this.tbPlacesCount28);
            this.scLinks.Panel1.Controls.Add(this.stbLogger28);
            this.scLinks.Panel1.Controls.Add(this.stbTermoBox28);
            this.scLinks.Panel1.Controls.Add(this.label6);
            this.scLinks.Panel1.Controls.Add(this.label5);
            this.scLinks.Panel1.Controls.Add(this.label3);
            // 
            // scLinks.Panel2
            // 
            this.scLinks.Panel2.Controls.Add(this.tbPlacesCount815);
            this.scLinks.Panel2.Controls.Add(this.label9);
            this.scLinks.Panel2.Controls.Add(this.stbLogger815);
            this.scLinks.Panel2.Controls.Add(this.stbTermoBox815);
            this.scLinks.Panel2.Controls.Add(this.label4);
            this.scLinks.Panel2.Controls.Add(this.label7);
            this.scLinks.Panel2.Controls.Add(this.label8);
            this.scLinks.Size = new System.Drawing.Size(604, 121);
            this.scLinks.SplitterDistance = 300;
            this.scLinks.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(39, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Мест :";
            // 
            // tbPlacesCount28
            // 
            this.tbPlacesCount28.BackColor = System.Drawing.SystemColors.Window;
            this.tbPlacesCount28.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.driverRouteNumbersBindingSource, "r2_doc_count", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPlacesCount28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPlacesCount28.ForeColor = System.Drawing.Color.Red;
            this.tbPlacesCount28.Location = new System.Drawing.Point(86, 93);
            this.tbPlacesCount28.Name = "tbPlacesCount28";
            this.tbPlacesCount28.ReadOnly = true;
            this.tbPlacesCount28.Size = new System.Drawing.Size(80, 22);
            this.tbPlacesCount28.TabIndex = 6;
            this.tbPlacesCount28.TabStop = false;
            this.tbPlacesCount28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // driverRouteNumbersBindingSource
            // 
            this.driverRouteNumbersBindingSource.DataMember = "DriverRouteNumbers";
            this.driverRouteNumbersBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stbLogger28
            // 
            this.stbLogger28.AllowType = true;
            this.stbLogger28.AutoConvert = true;
            this.stbLogger28.DelayThreshold = 50;
            this.stbLogger28.Location = new System.Drawing.Point(86, 27);
            this.stbLogger28.Name = "stbLogger28";
            this.stbLogger28.RaiseTextChangeWithoutEnter = false;
            this.stbLogger28.ReadOnly = false;
            this.stbLogger28.Size = new System.Drawing.Size(200, 25);
            this.stbLogger28.TabIndex = 1;
            this.stbLogger28.Tag = "R2";
            this.stbLogger28.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.stbLogger28.UseParentFont = false;
            this.stbLogger28.UseScanModeOnly = false;
            // 
            // stbTermoBox28
            // 
            this.stbTermoBox28.AllowType = true;
            this.stbTermoBox28.AutoConvert = true;
            this.stbTermoBox28.DelayThreshold = 50;
            this.stbTermoBox28.Location = new System.Drawing.Point(86, 54);
            this.stbTermoBox28.Name = "stbTermoBox28";
            this.stbTermoBox28.RaiseTextChangeWithoutEnter = false;
            this.stbTermoBox28.ReadOnly = false;
            this.stbTermoBox28.Size = new System.Drawing.Size(200, 25);
            this.stbTermoBox28.TabIndex = 4;
            this.stbTermoBox28.Tag = "R2";
            this.stbTermoBox28.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.stbTermoBox28.UseParentFont = false;
            this.stbTermoBox28.UseScanModeOnly = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Термобокс :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Логгер :";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(300, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "+2 - +8 °С";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPlacesCount815
            // 
            this.tbPlacesCount815.BackColor = System.Drawing.SystemColors.Window;
            this.tbPlacesCount815.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.driverRouteNumbersBindingSource, "r8_doc_count", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPlacesCount815.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPlacesCount815.ForeColor = System.Drawing.Color.Red;
            this.tbPlacesCount815.Location = new System.Drawing.Point(88, 93);
            this.tbPlacesCount815.Name = "tbPlacesCount815";
            this.tbPlacesCount815.ReadOnly = true;
            this.tbPlacesCount815.Size = new System.Drawing.Size(80, 22);
            this.tbPlacesCount815.TabIndex = 5;
            this.tbPlacesCount815.TabStop = false;
            this.tbPlacesCount815.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(37, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Мест :";
            // 
            // stbLogger815
            // 
            this.stbLogger815.AllowType = true;
            this.stbLogger815.AutoConvert = true;
            this.stbLogger815.DelayThreshold = 50;
            this.stbLogger815.Location = new System.Drawing.Point(88, 27);
            this.stbLogger815.Name = "stbLogger815";
            this.stbLogger815.RaiseTextChangeWithoutEnter = false;
            this.stbLogger815.ReadOnly = false;
            this.stbLogger815.Size = new System.Drawing.Size(200, 25);
            this.stbLogger815.TabIndex = 1;
            this.stbLogger815.Tag = "R8";
            this.stbLogger815.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.stbLogger815.UseParentFont = false;
            this.stbLogger815.UseScanModeOnly = false;
            // 
            // stbTermoBox815
            // 
            this.stbTermoBox815.AllowType = true;
            this.stbTermoBox815.AutoConvert = true;
            this.stbTermoBox815.DelayThreshold = 50;
            this.stbTermoBox815.Location = new System.Drawing.Point(88, 54);
            this.stbTermoBox815.Name = "stbTermoBox815";
            this.stbTermoBox815.RaiseTextChangeWithoutEnter = false;
            this.stbTermoBox815.ReadOnly = false;
            this.stbTermoBox815.Size = new System.Drawing.Size(200, 25);
            this.stbTermoBox815.TabIndex = 3;
            this.stbTermoBox815.Tag = "R8";
            this.stbTermoBox815.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.stbTermoBox815.UseParentFont = false;
            this.stbTermoBox815.UseScanModeOnly = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(300, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "+8 - +15 °С";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Термобокс :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Логгер :";
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbActiveRoutes
            // 
            this.cmbActiveRoutes.DataSource = this.driverRouteNumbersBindingSource;
            this.cmbActiveRoutes.DisplayMember = "route_number";
            this.cmbActiveRoutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActiveRoutes.FormattingEnabled = true;
            this.cmbActiveRoutes.Location = new System.Drawing.Point(133, 10);
            this.cmbActiveRoutes.Name = "cmbActiveRoutes";
            this.cmbActiveRoutes.Size = new System.Drawing.Size(100, 21);
            this.cmbActiveRoutes.TabIndex = 1;
            this.cmbActiveRoutes.ValueMember = "route_number";
            // 
            // tbActiveRouteDescription
            // 
            this.tbActiveRouteDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbActiveRouteDescription.BackColor = System.Drawing.SystemColors.Window;
            this.tbActiveRouteDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.driverRouteNumbersBindingSource, "route_description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbActiveRouteDescription.Location = new System.Drawing.Point(239, 10);
            this.tbActiveRouteDescription.Name = "tbActiveRouteDescription";
            this.tbActiveRouteDescription.ReadOnly = true;
            this.tbActiveRouteDescription.Size = new System.Drawing.Size(383, 20);
            this.tbActiveRouteDescription.TabIndex = 2;
            this.tbActiveRouteDescription.TabStop = false;
            // 
            // driverRouteNumbersTableAdapter
            // 
            this.driverRouteNumbersTableAdapter.ClearBeforeFill = true;
            // 
            // DeliveryRegistrationOnRouteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 231);
            this.Controls.Add(this.tbActiveRouteDescription);
            this.Controls.Add(this.cmbActiveRoutes);
            this.Controls.Add(this.gbLinks);
            this.Controls.Add(this.label2);
            this.Name = "DeliveryRegistrationOnRouteForm";
            this.Text = "Регистрация на маршруте";
            this.Load += new System.EventHandler(this.DeliveryRegistrationOnRouteForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryRegistrationOnRouteForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.gbLinks, 0);
            this.Controls.SetChildIndex(this.cmbActiveRoutes, 0);
            this.Controls.SetChildIndex(this.tbActiveRouteDescription, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbLinks.ResumeLayout(false);
            this.scLinks.Panel1.ResumeLayout(false);
            this.scLinks.Panel1.PerformLayout();
            this.scLinks.Panel2.ResumeLayout(false);
            this.scLinks.Panel2.PerformLayout();
            this.scLinks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.driverRouteNumbersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbLinks;
        private System.Windows.Forms.ComboBox cmbActiveRoutes;
        private System.Windows.Forms.SplitContainer scLinks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbActiveRouteDescription;
        private System.Windows.Forms.BindingSource driverRouteNumbersBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.DriverRouteNumbersTableAdapter driverRouteNumbersTableAdapter;
        private WMSOffice.Data.ColdChain coldChain;
        private System.Windows.Forms.TextBox tbPlacesCount28;
        private System.Windows.Forms.TextBox tbPlacesCount815;
        private WMSOffice.Controls.TextBoxScaner stbTermoBox28;
        private WMSOffice.Controls.TextBoxScaner stbLogger28;
        private WMSOffice.Controls.TextBoxScaner stbLogger815;
        private WMSOffice.Controls.TextBoxScaner stbTermoBox815;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
    }
}