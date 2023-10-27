namespace WMSOffice.Dialogs.WH
{
    partial class VaccinesSetPrintParametersForm
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
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.tbVaccine = new System.Windows.Forms.TextBox();
            this.stbVaccine = new WMSOffice.Controls.SearchTextBox();
            this.lblVaccine = new System.Windows.Forms.Label();
            this.tbStatusTo = new System.Windows.Forms.TextBox();
            this.tbStatusFrom = new System.Windows.Forms.TextBox();
            this.stbStatusTo = new WMSOffice.Controls.SearchTextBox();
            this.lblStatusTo = new System.Windows.Forms.Label();
            this.lblStatusFrom = new System.Windows.Forms.Label();
            this.stbStatusFrom = new WMSOffice.Controls.SearchTextBox();
            this.tbWarehouse = new System.Windows.Forms.TextBox();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.stbVendorLot = new WMSOffice.Controls.SearchTextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.wH = new WMSOffice.Data.WH();
            this.jVVaccineJournalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jV_VaccineJournalTableAdapter = new WMSOffice.Data.WHTableAdapters.JV_VaccineJournalTableAdapter();
            this.tbResponsible = new System.Windows.Forms.TextBox();
            this.stbResponsible = new WMSOffice.Controls.SearchTextBox();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jVVaccineJournalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3317, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3407, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 208);
            this.pnlButtons.Size = new System.Drawing.Size(979, 43);
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(361, 95);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 18;
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(110, 95);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 16;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(259, 99);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(63, 13);
            this.lblPeriodTo.TabIndex = 17;
            this.lblPeriodTo.Text = "Период по:";
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(12, 99);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(57, 13);
            this.lblPeriodFrom.TabIndex = 15;
            this.lblPeriodFrom.Text = "Период с:";
            // 
            // tbVaccine
            // 
            this.tbVaccine.BackColor = System.Drawing.SystemColors.Window;
            this.tbVaccine.Location = new System.Drawing.Point(216, 37);
            this.tbVaccine.Name = "tbVaccine";
            this.tbVaccine.ReadOnly = true;
            this.tbVaccine.Size = new System.Drawing.Size(245, 20);
            this.tbVaccine.TabIndex = 5;
            // 
            // stbVaccine
            // 
            this.stbVaccine.Location = new System.Drawing.Point(110, 37);
            this.stbVaccine.Name = "stbVaccine";
            this.stbVaccine.NavigateByValue = false;
            this.stbVaccine.ReadOnly = false;
            this.stbVaccine.Size = new System.Drawing.Size(100, 20);
            this.stbVaccine.TabIndex = 4;
            this.stbVaccine.UserID = ((long)(0));
            this.stbVaccine.Value = null;
            this.stbVaccine.ValueReferenceQuery = null;
            // 
            // lblVaccine
            // 
            this.lblVaccine.AutoSize = true;
            this.lblVaccine.Location = new System.Drawing.Point(12, 41);
            this.lblVaccine.Name = "lblVaccine";
            this.lblVaccine.Size = new System.Drawing.Size(53, 13);
            this.lblVaccine.TabIndex = 3;
            this.lblVaccine.Text = "Вакцина:";
            // 
            // tbStatusTo
            // 
            this.tbStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusTo.Location = new System.Drawing.Point(721, 66);
            this.tbStatusTo.Name = "tbStatusTo";
            this.tbStatusTo.ReadOnly = true;
            this.tbStatusTo.Size = new System.Drawing.Size(245, 20);
            this.tbStatusTo.TabIndex = 14;
            // 
            // tbStatusFrom
            // 
            this.tbStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusFrom.Location = new System.Drawing.Point(216, 66);
            this.tbStatusFrom.Name = "tbStatusFrom";
            this.tbStatusFrom.ReadOnly = true;
            this.tbStatusFrom.Size = new System.Drawing.Size(245, 20);
            this.tbStatusFrom.TabIndex = 11;
            // 
            // stbStatusTo
            // 
            this.stbStatusTo.Location = new System.Drawing.Point(615, 66);
            this.stbStatusTo.Name = "stbStatusTo";
            this.stbStatusTo.NavigateByValue = false;
            this.stbStatusTo.ReadOnly = false;
            this.stbStatusTo.Size = new System.Drawing.Size(100, 20);
            this.stbStatusTo.TabIndex = 13;
            this.stbStatusTo.UserID = ((long)(0));
            this.stbStatusTo.Value = null;
            this.stbStatusTo.ValueReferenceQuery = null;
            // 
            // lblStatusTo
            // 
            this.lblStatusTo.AutoSize = true;
            this.lblStatusTo.Location = new System.Drawing.Point(511, 70);
            this.lblStatusTo.Name = "lblStatusTo";
            this.lblStatusTo.Size = new System.Drawing.Size(59, 13);
            this.lblStatusTo.TabIndex = 12;
            this.lblStatusTo.Text = "Статус по:";
            // 
            // lblStatusFrom
            // 
            this.lblStatusFrom.AutoSize = true;
            this.lblStatusFrom.Location = new System.Drawing.Point(12, 70);
            this.lblStatusFrom.Name = "lblStatusFrom";
            this.lblStatusFrom.Size = new System.Drawing.Size(53, 13);
            this.lblStatusFrom.TabIndex = 9;
            this.lblStatusFrom.Text = "Статус с:";
            // 
            // stbStatusFrom
            // 
            this.stbStatusFrom.Location = new System.Drawing.Point(110, 66);
            this.stbStatusFrom.Name = "stbStatusFrom";
            this.stbStatusFrom.NavigateByValue = false;
            this.stbStatusFrom.ReadOnly = false;
            this.stbStatusFrom.Size = new System.Drawing.Size(100, 20);
            this.stbStatusFrom.TabIndex = 10;
            this.stbStatusFrom.UserID = ((long)(0));
            this.stbStatusFrom.Value = null;
            this.stbStatusFrom.ValueReferenceQuery = null;
            // 
            // tbWarehouse
            // 
            this.tbWarehouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouse.Location = new System.Drawing.Point(216, 8);
            this.tbWarehouse.Name = "tbWarehouse";
            this.tbWarehouse.ReadOnly = true;
            this.tbWarehouse.Size = new System.Drawing.Size(750, 20);
            this.tbWarehouse.TabIndex = 2;
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(110, 8);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.NavigateByValue = false;
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouse.TabIndex = 1;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 12);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(90, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Подразделение:";
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendorLot.Location = new System.Drawing.Point(721, 37);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.ReadOnly = true;
            this.tbVendorLot.Size = new System.Drawing.Size(245, 20);
            this.tbVendorLot.TabIndex = 8;
            // 
            // stbVendorLot
            // 
            this.stbVendorLot.Location = new System.Drawing.Point(615, 37);
            this.stbVendorLot.Name = "stbVendorLot";
            this.stbVendorLot.NavigateByValue = false;
            this.stbVendorLot.ReadOnly = false;
            this.stbVendorLot.Size = new System.Drawing.Size(100, 20);
            this.stbVendorLot.TabIndex = 7;
            this.stbVendorLot.UserID = ((long)(0));
            this.stbVendorLot.Value = null;
            this.stbVendorLot.ValueReferenceQuery = null;
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(511, 41);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLot.TabIndex = 6;
            this.lblVendorLot.Text = "Серия:";
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jVVaccineJournalBindingSource
            // 
            this.jVVaccineJournalBindingSource.DataMember = "JV_VaccineJournal";
            this.jVVaccineJournalBindingSource.DataSource = this.wH;
            // 
            // jV_VaccineJournalTableAdapter
            // 
            this.jV_VaccineJournalTableAdapter.ClearBeforeFill = true;
            // 
            // tbResponsible
            // 
            this.tbResponsible.BackColor = System.Drawing.SystemColors.Window;
            this.tbResponsible.Location = new System.Drawing.Point(216, 148);
            this.tbResponsible.Name = "tbResponsible";
            this.tbResponsible.ReadOnly = true;
            this.tbResponsible.Size = new System.Drawing.Size(245, 20);
            this.tbResponsible.TabIndex = 21;
            // 
            // stbResponsible
            // 
            this.stbResponsible.BackColor = System.Drawing.SystemColors.Window;
            this.stbResponsible.Location = new System.Drawing.Point(110, 148);
            this.stbResponsible.Name = "stbResponsible";
            this.stbResponsible.NavigateByValue = false;
            this.stbResponsible.ReadOnly = true;
            this.stbResponsible.Size = new System.Drawing.Size(100, 20);
            this.stbResponsible.TabIndex = 20;
            this.stbResponsible.UserID = ((long)(0));
            this.stbResponsible.Value = null;
            this.stbResponsible.ValueReferenceQuery = null;
            // 
            // lblResponsible
            // 
            this.lblResponsible.AutoSize = true;
            this.lblResponsible.Location = new System.Drawing.Point(12, 152);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(89, 13);
            this.lblResponsible.TabIndex = 19;
            this.lblResponsible.Text = "Ответственный:";
            // 
            // VaccinesSetPrintParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 251);
            this.Controls.Add(this.tbResponsible);
            this.Controls.Add(this.stbResponsible);
            this.Controls.Add(this.lblResponsible);
            this.Controls.Add(this.tbVendorLot);
            this.Controls.Add(this.stbVendorLot);
            this.Controls.Add(this.lblVendorLot);
            this.Controls.Add(this.dtpPeriodTo);
            this.Controls.Add(this.dtpPeriodFrom);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.lblPeriodFrom);
            this.Controls.Add(this.tbVaccine);
            this.Controls.Add(this.stbVaccine);
            this.Controls.Add(this.lblVaccine);
            this.Controls.Add(this.tbStatusTo);
            this.Controls.Add(this.tbStatusFrom);
            this.Controls.Add(this.stbStatusTo);
            this.Controls.Add(this.lblStatusTo);
            this.Controls.Add(this.lblStatusFrom);
            this.Controls.Add(this.stbStatusFrom);
            this.Controls.Add(this.tbWarehouse);
            this.Controls.Add(this.stbWarehouse);
            this.Controls.Add(this.lblWarehouse);
            this.Name = "VaccinesSetPrintParametersForm";
            this.Text = "Параметры формирования отчета для журнала вакцин";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VaccinesSetPrintParametersForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblWarehouse, 0);
            this.Controls.SetChildIndex(this.stbWarehouse, 0);
            this.Controls.SetChildIndex(this.tbWarehouse, 0);
            this.Controls.SetChildIndex(this.stbStatusFrom, 0);
            this.Controls.SetChildIndex(this.lblStatusFrom, 0);
            this.Controls.SetChildIndex(this.lblStatusTo, 0);
            this.Controls.SetChildIndex(this.stbStatusTo, 0);
            this.Controls.SetChildIndex(this.tbStatusFrom, 0);
            this.Controls.SetChildIndex(this.tbStatusTo, 0);
            this.Controls.SetChildIndex(this.lblVaccine, 0);
            this.Controls.SetChildIndex(this.stbVaccine, 0);
            this.Controls.SetChildIndex(this.tbVaccine, 0);
            this.Controls.SetChildIndex(this.lblPeriodFrom, 0);
            this.Controls.SetChildIndex(this.lblPeriodTo, 0);
            this.Controls.SetChildIndex(this.dtpPeriodFrom, 0);
            this.Controls.SetChildIndex(this.dtpPeriodTo, 0);
            this.Controls.SetChildIndex(this.lblVendorLot, 0);
            this.Controls.SetChildIndex(this.stbVendorLot, 0);
            this.Controls.SetChildIndex(this.tbVendorLot, 0);
            this.Controls.SetChildIndex(this.lblResponsible, 0);
            this.Controls.SetChildIndex(this.stbResponsible, 0);
            this.Controls.SetChildIndex(this.tbResponsible, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jVVaccineJournalBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.TextBox tbVaccine;
        private WMSOffice.Controls.SearchTextBox stbVaccine;
        private System.Windows.Forms.Label lblVaccine;
        private System.Windows.Forms.TextBox tbStatusTo;
        private System.Windows.Forms.TextBox tbStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusTo;
        private System.Windows.Forms.Label lblStatusTo;
        private System.Windows.Forms.Label lblStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusFrom;
        private System.Windows.Forms.TextBox tbWarehouse;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.TextBox tbVendorLot;
        private WMSOffice.Controls.SearchTextBox stbVendorLot;
        private System.Windows.Forms.Label lblVendorLot;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource jVVaccineJournalBindingSource;
        private WMSOffice.Data.WHTableAdapters.JV_VaccineJournalTableAdapter jV_VaccineJournalTableAdapter;
        private System.Windows.Forms.TextBox tbResponsible;
        private WMSOffice.Controls.SearchTextBox stbResponsible;
        private System.Windows.Forms.Label lblResponsible;
    }
}