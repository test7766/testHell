using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityShippingAuthorizationWorksheetSearchForm : DialogForm
    {
        public static WMSOffice.Window.QualityShippingAuthorizationParameters SearchParameter { get; private set; }
        public static bool UseCarNumberFormat { get; private set; }

        public QualityShippingAuthorizationWorksheetSearchForm()
        {
            InitializeComponent();
        }

        static QualityShippingAuthorizationWorksheetSearchForm()
        {
            QualityShippingAuthorizationWorksheetSearchForm.SearchParameter = new QualityShippingAuthorizationParameters
            {
                StatusNew = true,
                StatusInWork = true
            };

            UseCarNumberFormat = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(166, 8);
            this.btnCancel.Location = new Point(247, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            var qsap = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter;

            this.InitializeDebtors();
            this.InitializeProvisors();

            tip.SetToolTip(cbUseCarNumberFormat, "Использовать формат номера авто (AA 19-64 XB)");

            if (qsap.RouteListNumber.HasValue)
            {
                cbRouteListNumber.Checked = true;
                tbRouteListNumber.Text = qsap.RouteListNumber.Value.ToString();
            }

            if (qsap.WorksheetNumber.HasValue)
            {
                cbWorksheetNumber.Checked = true;
                tbWorksheetNumber.Text = qsap.WorksheetNumber.Value.ToString();
            }
           
            if (!string.IsNullOrEmpty(qsap.CarNumber))
            {
                cbCarNumber.Checked = true;
                cbUseCarNumberFormat.Checked = QualityShippingAuthorizationWorksheetSearchForm.UseCarNumberFormat;
                mtbCarNumber.Text = qsap.CarNumber;
            }

            if (qsap.DebtorID.HasValue)
            {
                cbDebtorID.Checked = true;
                stbDebtorID.SetValueByDefault(qsap.DebtorID.Value.ToString());
            }

            if (!string.IsNullOrEmpty(qsap.DriverName))
            {
                cbDriverName.Checked = true;
                tbDriverName.Text = qsap.DriverName;
            }

            if (qsap.PeriodFrom.HasValue || qsap.PeriodTo.HasValue)
            {
                cbWorksheetDateCreate.Checked = true;

                if (qsap.PeriodFrom.HasValue)
                    dtpWorksheetDateCreateFrom.Value = qsap.PeriodFrom.Value;
                else
                    dtpWorksheetDateCreateFrom.Checked = false;

                if (qsap.PeriodTo.HasValue)
                    dtpWorksheetDateCreateTo.Value = qsap.PeriodTo.Value;
                else
                    dtpWorksheetDateCreateTo.Checked = false;
            }

            if (qsap.ProvisorID.HasValue)
            {
                cbProvisor.Checked = true;
                cmbProvisor.SelectedValue = qsap.ProvisorID.Value;
            }
            
            // статусы анкет
            cbStatusNew.Checked = qsap.StatusNew;
            cbStatusInWork.Checked = qsap.StatusInWork;
            cbStatusAccepted.Checked = qsap.StatusAccepted;
            cbStatusNotAccepted.Checked = qsap.StatusNotAccepted;

            cbDesinfectionCert.CheckState = qsap.HasDesinfectionCert.HasValue ? (qsap.HasDesinfectionCert.Value ? CheckState.Checked : CheckState.Unchecked) : CheckState.Indeterminate;
            cbShippingToWarehouse.CheckState = qsap.IsShippingToWarehouse.HasValue ? (qsap.IsShippingToWarehouse.Value ? CheckState.Checked : CheckState.Unchecked) : CheckState.Indeterminate;
        }

        private void InitializeDebtors()
        {
            try
            {
                stbDebtorID.ValueReferenceQuery = "[dbo].[pr_QK_SA_Get_Debtors]";
                stbDebtorID.UserID = this.UserID;
                stbDebtorID.OnVerifyValue += (s, e) => 
                {
                    var control = s as SearchTextBox;
                    Label lblDescription = null;

                    if (control == stbDebtorID)
                        lblDescription = lblDebtorName;

                    if (lblDescription != null)
                    {
                        lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                        lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                        if (e.Success)
                            control.Value = e.Value;
                        //else
                        //    control.Value = string.Empty;
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeProvisors()
        {
            try
            {
                aP_Get_ProvisorsTableAdapter.FillSA(quality.AP_Get_Provisors, this.UserID);
                cmbProvisor.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbParameter_CheckedChanged(object sender, EventArgs e)
        {
            var cbParameterSelector = sender as CheckBox;

            var parameterEditor = this.ActiveControl;

            if (cbParameterSelector.Equals(cbRouteListNumber))
                parameterEditor = tbRouteListNumber;
            else if (cbParameterSelector.Equals(cbWorksheetNumber))
                parameterEditor = tbWorksheetNumber;
            else if (cbParameterSelector.Equals(cbCarNumber))
                parameterEditor = mtbCarNumber;
            else if (cbParameterSelector.Equals(cbDebtorID))
                parameterEditor = stbDebtorID;
            else if (cbParameterSelector.Equals(cbDriverName))
                parameterEditor = tbDriverName;
            else if (cbParameterSelector.Equals(cbWorksheetDateCreate))
                parameterEditor = dtpWorksheetDateCreateFrom;
            else if (cbParameterSelector.Equals(cbProvisor))
                parameterEditor = cmbProvisor;

            if (parameterEditor != null)
            {
                if (parameterEditor is SearchTextBox)
                {
                    if (cbParameterSelector.Checked)
                    {
                        parameterEditor.Enabled = true;
                        parameterEditor.Focus();
                    }
                    else
                    {
                        (parameterEditor as SearchTextBox).SetValueByDefault(string.Empty);
                        parameterEditor.Enabled = false;
                    }
                    return;
                }

                if (parameterEditor is DateTimePicker) // период создания анкеты
                {
                    dtpWorksheetDateCreateFrom.Value = DateTime.Today;
                    dtpWorksheetDateCreateTo.Value = DateTime.Today;

                    if (cbParameterSelector.Checked)
                    {
                        dtpWorksheetDateCreateFrom.Enabled = true;
                        dtpWorksheetDateCreateFrom.Checked = true;

                        dtpWorksheetDateCreateTo.Enabled = true;
                        dtpWorksheetDateCreateTo.Checked = true;

                        dtpWorksheetDateCreateFrom.Focus();
                    }
                    else
                    {
                        dtpWorksheetDateCreateFrom.Checked = false;
                        dtpWorksheetDateCreateFrom.Enabled = false;

                        dtpWorksheetDateCreateTo.Checked = false;
                        dtpWorksheetDateCreateTo.Enabled = false;
                    }
                    return;
                }

                if (parameterEditor is ComboBox)
                {
                    if (cbParameterSelector.Checked)
                    {
                        parameterEditor.Enabled = true;
                        parameterEditor.Focus();
                    }
                    else
                    {
                        (parameterEditor as ComboBox).SelectedItem = null;
                        parameterEditor.Enabled = false;
                    }
                    return;
                }

                if (parameterEditor is TextBox)
                {
                    if (cbParameterSelector.Checked)
                    {
                        parameterEditor.Enabled = true;
                        parameterEditor.Focus();
                    }
                    else
                    {
                        (parameterEditor as TextBox).Clear();
                        parameterEditor.Enabled = false;
                    }
                    return;
                }

                if (parameterEditor is MaskedTextBox)
                {
                    if (cbParameterSelector.Checked)
                    {
                        cbUseCarNumberFormat.Enabled = true;
                        cbUseCarNumberFormat.Checked = true;

                        parameterEditor.Enabled = true;
                        parameterEditor.Focus();
                    }
                    else
                    {
                        cbUseCarNumberFormat.Enabled = false;
                        cbUseCarNumberFormat.Checked = false;

                        (parameterEditor as MaskedTextBox).Clear();
                        parameterEditor.Enabled = false;
                    }
                    return;
                }
            }
        }

        private void QualityShippingAuthorizationWorksheetSearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var qsap = new QualityShippingAuthorizationParameters { SessionID = this.UserID };

                if (cbRouteListNumber.Checked)
                {
                    long routeListNumber;
                    if (!long.TryParse(tbRouteListNumber.Text, out routeListNumber))
                        throw new Exception("Номер МЛ должен быть числом.");

                    qsap.RouteListNumber = routeListNumber;
                }

                if (cbWorksheetNumber.Checked)
                {
                    long worksheetNumber;
                    if (!long.TryParse(tbWorksheetNumber.Text, out worksheetNumber))
                        throw new Exception("Номер анкеты должен быть числом.");

                    qsap.WorksheetNumber = worksheetNumber;
                }

                if (cbCarNumber.Checked)
                {
                    string carNumber = mtbCarNumber.Text.Trim();
                    if (string.IsNullOrEmpty(carNumber.Trim('-')))
                        throw new Exception("Номер авто не заполнен.");

                    if (carNumber.Trim('-').Length < 3)
                        throw new Exception("Длина номера авто должна быть не менее 3-х символов.");

                    qsap.CarNumber = carNumber;
                }

                if (cbDebtorID.Checked)
                {
                    if (string.IsNullOrEmpty(stbDebtorID.Value))
                        throw new Exception("Клиент не выбран.");

                    var debtorID = Convert.ToInt64(stbDebtorID.Value);
                    qsap.DebtorID = debtorID;
                }

                if (cbDriverName.Checked)
                {
                    string driverName = tbDriverName.Text.Trim();
                    if (string.IsNullOrEmpty(driverName))
                        throw new Exception("ФИО водителя не заполнено.");

                    if (driverName.Length < 3)
                        throw new Exception("Длина ФИО водителя должна быть не менее 3-х символов.");

                    qsap.DriverName = driverName;
                }

                if (cbWorksheetDateCreate.Checked)
                {
                    var worksheetDateCreateFrom = dtpWorksheetDateCreateFrom.Checked ? dtpWorksheetDateCreateFrom.Value.Date : (DateTime?)null;
                    var worksheetDateCreateTo = dtpWorksheetDateCreateTo.Checked ? dtpWorksheetDateCreateTo.Value.Date : (DateTime?)null;

                    if (worksheetDateCreateFrom.HasValue && worksheetDateCreateTo.HasValue && worksheetDateCreateFrom > worksheetDateCreateTo)
                        throw new Exception("Начальный период не должен превышать конечный.");

                    qsap.PeriodFrom = worksheetDateCreateFrom;
                    qsap.PeriodTo = worksheetDateCreateTo;
                }

                if (cbProvisor.Checked)
                {
                    if (cmbProvisor.SelectedValue == null)
                        throw new Exception("Фармацевт не выбран.");

                    var provisorID = Convert.ToInt64(cmbProvisor.SelectedValue);
                    qsap.ProvisorID = provisorID;
                }

                // статусы анкет
                qsap.StatusNew = cbStatusNew.Checked;
                qsap.StatusInWork = cbStatusInWork.Checked;
                qsap.StatusAccepted = cbStatusAccepted.Checked;
                qsap.StatusNotAccepted = cbStatusNotAccepted.Checked;

                qsap.HasDesinfectionCert = cbDesinfectionCert.CheckState == CheckState.Checked ? true : cbDesinfectionCert.CheckState == CheckState.Unchecked ? false : (bool?)null;
                qsap.IsShippingToWarehouse = cbShippingToWarehouse.CheckState == CheckState.Checked ? true : cbShippingToWarehouse.CheckState == CheckState.Unchecked ? false : (bool?)null;   

                QualityShippingAuthorizationWorksheetSearchForm.SearchParameter = qsap;

                UseCarNumberFormat = cbUseCarNumberFormat.Checked;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void cbUseCarNumberFormat_CheckedChanged(object sender, EventArgs e)
        {
            mtbCarNumber.Mask = cbUseCarNumberFormat.Checked ? ">?? 00-00 ??" : "&&&CCCCCCC";
        }
    }
}
