using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Dialogs.Inventory;

namespace WMSOffice.Window
{
    public partial class PickConfirmationWindow : GeneralWindow
    {
        private int? EmployeeId { get; set; }

        public PickConfirmationWindow()
        {
            InitializeComponent();
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
                try
                {
                    AddRow(tbBarcode.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            tbBarcode.Text = "";
        }

        private void AddRow(string barcode)
        {
            try
            {
                try
                {
                    getPSSToStatusBindingSource.Filter = string.Empty;
                    getPSSToStatusBindingSource.Sort = string.Empty;
                    getPSSToStatusTableAdapter.Fill555(pickControl.GetPSSToStatus, barcode, UserID, EmployeeId);
                }                
                catch (Exception ex)
                {
                    if (ex.Message.Contains("#MULTIPSN9"))
                    {
                        using (var adapter = new Data.PickControlTableAdapters.MultiPickSlipErrorsTableAdapter())
                            adapter.Fill555(pickControl.MultiPickSlipErrors, this.UserID, (long?)null, barcode);

                        bool needRegisterEmployee = false;
                        foreach (Data.PickControl.MultiPickSlipErrorsRow er in pickControl.MultiPickSlipErrors.Rows)
                            if (er.error_msg.Contains("NOEMPLOYEE"))
                            {
                                needRegisterEmployee = true;
                                break;
                            }

                        if (needRegisterEmployee)
                        {
                            ScanEmployeeForm form = new ScanEmployeeForm();
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                EmployeeId = form.EmployeeID;
                                AddRow(barcode);
                                EmployeeId = null;
                            }
                        }
                        else
                        {
                            var dlgErrors = new WMSOffice.Dialogs.PickControl.MultiPickSlipErrorsForm();
                            dlgErrors.PopulateErrors(pickControl.MultiPickSlipErrors, 555);
                            dlgErrors.ShowDialog();
                        }
                    }
                    else if (ex.Message == "NOEMPLOYEE")
                    {
                        ScanEmployeeForm form = new ScanEmployeeForm();
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            EmployeeId = form.EmployeeID;
                            AddRow(barcode);
                            EmployeeId = null;
                        }
                        //getPSSToStatusTableAdapter.Fill555(pickControl.GetPSSToStatus, barcode, UserID, form.EmployeeID);
                    }
                    else throw;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REDFORM"))
                {
                    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                        "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                    errorForm.TimeOut = 2000;
                    errorForm.ShowDialog();
                }
                else
                    ShowError(ex);
            }
        }

    }
}
