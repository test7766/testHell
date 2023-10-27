using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Receive.Pallets;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsAccountingForm : DialogForm
    {
        public new long UserID { get; set; }

        public PalletsAccountingModeBase PalletsAccountingMode { get; private set; }

        public PalletsAccountingForm()
        {
            InitializeComponent();
        }

        public PalletsAccountingForm(PalletsAccountingModeBase pPalletsAccountingMode)
            : this()
        {
            this.PalletsAccountingMode = pPalletsAccountingMode;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(347, 8);
            this.btnCancel.Location = new Point(437, 8);

            if (this.PalletsAccountingMode.CanCommitData)
            {
                this.btnOK.Width = 85;
                this.btnOK.Text = "Подтвердить";
            }
            else
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";
            }

            this.Text = string.Format("{0} по поставке № {1}", this.Text, this.PalletsAccountingMode.ShipmentID);
        }

        private void PalletsAccountingForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                palletsAccountingSummaryControl.DataSource = this.PalletsAccountingMode.GetAccountingData();

                foreach (var scTarget in palletsAccountingSummaryControl.AccountingScenarioSettingsCollection)
                {
                    var scSource = AccountingScenarioSettings.FindByName(this.PalletsAccountingMode.AccountingScenarioSettingsList, scTarget.AccountingScenarioName);
                    if (scSource != null)
                    {
                        scTarget.AccountingScenarioCaption = scSource.AccountingScenarioCaption;
                        scTarget.AllowEdit = scSource.AllowEdit;
                        scTarget.AllowEditSummary = scSource.AllowEditSummary;
                        scTarget.AllowInputNegateQuantity = scSource.AllowInputNegateQuantity;
                        scTarget.Enable = scSource.Enable;
                        scTarget.BaseScenario = scSource.BaseScenario;
                    }
                    else
                    {
                        scTarget.AllowEdit = false;
                        scTarget.Enable = false;
                    }
                }

                palletsAccountingSummaryControl.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PalletsAccountingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApplyChanges();
        }

        private bool ApplyChanges()
        {
            try
            {
                return !this.PalletsAccountingMode.CanCommitData || this.PalletsAccountingMode.SaveAccountingData(palletsAccountingSummaryControl.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
