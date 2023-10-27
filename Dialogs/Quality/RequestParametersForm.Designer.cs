namespace WMSOffice.Dialogs.Quality
{
    partial class RequestParametersForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblInspection = new System.Windows.Forms.Label();
            this.cmbInspection = new System.Windows.Forms.ComboBox();
            this.bsQkLocations = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.taQkLocations = new WMSOffice.Data.QualityTableAdapters.QK_LocationsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(468, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(387, 40);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblInspection
            // 
            this.lblInspection.AutoSize = true;
            this.lblInspection.Location = new System.Drawing.Point(12, 9);
            this.lblInspection.Name = "lblInspection";
            this.lblInspection.Size = new System.Drawing.Size(126, 13);
            this.lblInspection.TabIndex = 2;
            this.lblInspection.Text = "Інспекція-отримувач:";
            // 
            // cmbInspection
            // 
            this.cmbInspection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInspection.DataSource = this.bsQkLocations;
            this.cmbInspection.DisplayMember = "Location_Name";
            this.cmbInspection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInspection.FormattingEnabled = true;
            this.cmbInspection.Location = new System.Drawing.Point(144, 6);
            this.cmbInspection.Name = "cmbInspection";
            this.cmbInspection.Size = new System.Drawing.Size(399, 21);
            this.cmbInspection.TabIndex = 10;
            this.cmbInspection.ValueMember = "Location_ID";
            // 
            // bsQkLocations
            // 
            this.bsQkLocations.DataMember = "QK_Locations";
            this.bsQkLocations.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taQkLocations
            // 
            this.taQkLocations.ClearBeforeFill = true;
            // 
            // RequestParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(555, 75);
            this.Controls.Add(this.cmbInspection);
            this.Controls.Add(this.lblInspection);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RequestParametersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Вибір інспекції";
            this.Load += new System.EventHandler(this.RequestParametersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsQkLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblInspection;
        private System.Windows.Forms.ComboBox cmbInspection;
        private System.Windows.Forms.BindingSource bsQkLocations;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_LocationsTableAdapter taQkLocations;
    }
}