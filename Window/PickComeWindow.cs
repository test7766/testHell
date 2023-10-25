using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Dialogs.Inventory;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class PickComeWindow : GeneralWindow
    {
        private int? EmployeeId { get; set; }

        /// <summary>
        /// Признак тестовой версии
        /// </summary>
        private static bool IsTestVersion { get { return MainForm.IsTestVersion; } }

        public PickComeWindow()
        {
            InitializeComponent();
        }

        private void PickComeWindow_Load(object sender, EventArgs e)
        {
            try
            {
                var hasAccess = (int?)null;
                using (var adapter = new Data.PickControlTableAdapters.MultiPickSlipDetailsTableAdapter())
                    adapter.CheckAccess(this.UserID, ref hasAccess);

                sbRegisterMultiPick.Enabled = hasAccess.HasValue && Convert.ToBoolean(hasAccess.Value) == true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tbBarcode.TextChanged += tbBarcode_TextChanged;
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
                try
                {
                    var success = false;

                    if (IsTestVersion)
                    {
                        var result = (int?)null;
                        using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                            adapter.CheckNeedConfirmTermoAct(UserID, tbBarcode.Text, ref result);

                        // Необходимость сканирования акта
                        if (result.HasValue && result.Value == 1)
                        {
                            var dlgActScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                            {
                                Label = "Отсканируйте термоакт,\r\nкоторый связан со сборочным:",
                                Text = "Сканирование термоакта",
                                Image = Properties.Resources.cold_chain_icon_75
                            };

                            if (dlgActScanner.ShowDialog() == DialogResult.OK)
                            {
                                var termoActBarCode = dlgActScanner.Barcode;

                                result = (int?)null;
                                using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                                    adapter.CheckTermoAct(UserID, tbBarcode.Text, termoActBarCode, DocType, ref result);

                                // Акт подтвержден
                                if (result.HasValue && result.Value == 1)
                                    success = true;
                            }
                        }
                        else
                            success = true;
                    }
                    else
                        success = true;

                    if (success)
                    {
                        AddRow(tbBarcode.Text);
                    }
                    else
                    {
                        throw new Exception("Акт не был подтвержден.\r\nСборочный не был выдан.\r\nДальнейшая обработка прекращена!");
                    }
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
                getPSSToStatusBindingSource.Filter = string.Empty;
                getPSSToStatusBindingSource.Sort = string.Empty;
                getPSSToStatusTableAdapter.Fill550(pickControl.GetPSSToStatus, barcode, UserID, EmployeeId);
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
                else if (ex.Message.Contains("#MULTIPSN9"))
                {
                    using (var adapter = new Data.PickControlTableAdapters.MultiPickSlipErrorsTableAdapter())
                        adapter.Fill550(pickControl.MultiPickSlipErrors, this.UserID, (long?)null, barcode);

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

                        //ScanPickListForm frm = new ScanPickListForm() { IsEmployee = true };
                        //if (frm.ShowDialog() == DialogResult.OK)
                        //{
                        //    int ei = int.MinValue;
                        //    if (int.TryParse(frm.PickSlipBarcode, out ei))
                        //    {
                        //        EmployeeId = ei;
                        //        AddRow(barcode);
                        //        EmployeeId = null;
                        //    }
                        //}
                    }
                    else
                    {
                        var dlgErrors = new WMSOffice.Dialogs.PickControl.MultiPickSlipErrorsForm();
                        dlgErrors.PopulateErrors(pickControl.MultiPickSlipErrors, 550);
                        dlgErrors.ShowDialog();
                    }
                }
                else if (ex.Message.Contains("NOEMPLOYEE"))
                {
                    ScanEmployeeForm form = new ScanEmployeeForm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        EmployeeId = form.EmployeeID;
                        AddRow(barcode);
                        EmployeeId = null;
                    }

                    //ScanPickListForm frm = new ScanPickListForm() { IsEmployee = true };
                    //if (frm.ShowDialog() == DialogResult.OK)
                    //{
                    //    int ei = int.MinValue;
                    //    if (int.TryParse(frm.PickSlipBarcode, out ei))
                    //    {
                    //        EmployeeId = ei;
                    //        AddRow(barcode);
                    //        EmployeeId = null;
                    //    }
                    //}
                }
                else
                    ShowError(ex);
            }
        }

        private void sbRegisterMultiPick_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ScanEmployeeForm();
                //form.UseScanModeOnly = true;

                if (form.ShowDialog() != DialogResult.OK)
                    throw new Exception("Вы отменили последнее действие.");

                var employeeID = form.EmployeeID;
                var employeeName = form.EmployeeName;

                var dlgMultiPickRegistration = new MultiPickRegistrationForm() { UserID = this.UserID, EmployeeID = employeeID, EmployeeName = employeeName };
                dlgMultiPickRegistration.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }
}
