using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareSetIlliquidForm : DialogForm
    {
        public string TareBarCode { get; private set; }
        public string ReasonDescription { get; private set; }

        public DebtorsReturnedTareSetIlliquidForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Enabled = false;

            this.btnOK.Location = new Point(1202, 8);
            this.btnCancel.Location = new Point(1292, 8);

            if (!SelectTare())
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
        }

        private bool SelectTare()
        {
            var success = false;
            var lastBarcode = (string)null;

            while (true)
            {
                try
                {
                    var dlgChoiseTare = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте тару, по которой\r\nнеобходимо зарегистрировать бой",
                        Text = "Регистрация боя",
                        Image = Properties.Resources.paper_box,
                        Barcode = lastBarcode
                    };

                    if (dlgChoiseTare.ShowDialog() == DialogResult.OK)
                    {
                        var barcode = lastBarcode = dlgChoiseTare.Barcode;
                        if (this.ScanTare(barcode))
                        {
                            lastBarcode = (string)null;
                            success = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        success = false;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return success;
        }

        private bool ScanTare(string barcode)
        {
            try
            {
                this.btnOK.Enabled = false;

                cT_Tare_InfoTableAdapter.FillCheckedIlliquidTareData(pickControl.CT_Tare_Info, barcode, this.UserID);

                if (pickControl.CT_Tare_Info.Count == 0)
                    throw new Exception("По данному Ш/К оборотная тара не найдена.");

                this.TareBarCode = pickControl.CT_Tare_Info[0].Bar_Code.Trim();

                this.btnOK.Enabled = true;
                this.btnOK.Focus();
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DebtorsReturnedTareIssueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                e.Cancel = !this.SetlliquidTare();
            }
        }

        private bool SetlliquidTare()
        {
            try
            {
                var dlgDebtorsReturnedTareSetGuiltyEmployee = new DebtorsReturnedTareSetGuiltyEmployeeForm() { UserID = this.UserID, TareBarCode = this.TareBarCode };
                if (dlgDebtorsReturnedTareSetGuiltyEmployee.ShowDialog() == DialogResult.OK)
                    return true;

                #region OBSOLETE
                //if (this.GetReason())
                //{
                //    var guiltyID = (int?)null;
                //    var coDocID = (long?)null;
                //    using (var adapter = new Data.PickControlTableAdapters.CT_Tare_InfoTableAdapter())
                //        adapter.SetIlliquidTare(this.TareBarCode, this.ReasonDescription, this.UserID, guiltyID, ref coDocID);

                //    return true;
                //}
                #endregion

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        [Obsolete]
        private bool GetReason()
        {
            try
            {
                var dlgEnterStringValue = new EnterStringValueForm("Регистрация боя", "Укажите описание\r\nпричины боя", string.Empty) { AllowEmptyValue = true };
                if (dlgEnterStringValue.ShowDialog() == DialogResult.OK)
                {
                    var reasonDescription = dlgEnterStringValue.Value;

                    if (string.IsNullOrEmpty(reasonDescription))
                        throw new Exception("Описание причины боя должно быть указано.");

                    this.ReasonDescription = reasonDescription;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
