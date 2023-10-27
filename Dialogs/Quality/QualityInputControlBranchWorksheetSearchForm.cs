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
    public partial class QualityInputControlBranchWorksheetSearchForm : DialogForm
    {
        public static WMSOffice.Window.QualityInputControlBranchParameters SearchParameter { get; private set; }

        public QualityInputControlBranchWorksheetSearchForm()
        {
            InitializeComponent();
        }

        static QualityInputControlBranchWorksheetSearchForm()
        {
            QualityInputControlBranchWorksheetSearchForm.SearchParameter = new QualityInputControlBranchParameters
            {
                StatusNew = true,
                StatusInWork = true
            };
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
            var qcbp = QualityInputControlBranchWorksheetSearchForm.SearchParameter;

            this.InitializeWarehouses();
            this.InitializeProvisors();

            if (qcbp.RouteListNumber.HasValue)
            {
                cbRouteListNumber.Checked = true;
                tbRouteListNumber.Text = qcbp.RouteListNumber.Value.ToString();
            }

            if (qcbp.WorksheetNumber.HasValue)
            {
                cbWorksheetNumber.Checked = true;
                tbWorksheetNumber.Text = qcbp.WorksheetNumber.Value.ToString();
            }

            if (qcbp.FilialFromID.HasValue)
            {
                cbFilialFrom.Checked = true;
                stbFilialFromID.SetValueByDefault(qcbp.FilialFromID.Value.ToString());
            }

            if (qcbp.FilialToID.HasValue)
            {
                cbFilialTo.Checked = true;
                stbFilialToID.SetValueByDefault(qcbp.FilialToID.Value.ToString());
            }

            if (!string.IsNullOrEmpty(qcbp.DriverName))
            {
                cbDriverName.Checked = true;
                tbDriverName.Text = qcbp.DriverName;
            }

            if (qcbp.PeriodFrom.HasValue || qcbp.PeriodTo.HasValue)
            {
                cbWorksheetDateCreate.Checked = true;

                if (qcbp.PeriodFrom.HasValue)
                    dtpWorksheetDateCreateFrom.Value = qcbp.PeriodFrom.Value;
                else
                    dtpWorksheetDateCreateFrom.Checked = false;

                if (qcbp.PeriodTo.HasValue)
                    dtpWorksheetDateCreateTo.Value = qcbp.PeriodTo.Value;
                else
                    dtpWorksheetDateCreateTo.Checked = false;
            }

            if (qcbp.ProvisorID.HasValue)
            {
                cbProvisor.Checked = true;
                cmbProvisor.SelectedValue = qcbp.ProvisorID.Value;
            }
            
            // статусы анкет
            cbStatusNew.Checked = qcbp.StatusNew;
            cbStatusInWork.Checked = qcbp.StatusInWork;
            cbStatusAccepted.Checked = qcbp.StatusAccepted;
            cbStatusNotAccepted.Checked = qcbp.StatusNotAccepted;
        }

        private void InitializeWarehouses()
        {
            try
            {
                stbFilialFromID.ValueReferenceQuery = "[dbo].[pr_QK_CB_Get_Filials]";
                stbFilialFromID.ApplyAdditionalParameter("Is_Sender", true);
                stbFilialFromID.UserID = this.UserID;
                stbFilialFromID.OnVerifyValue += (s, e) => 
                {
                    var control = s as SearchTextBox;
                    Label lblDescription = null;

                    if (control == stbFilialFromID)
                        lblDescription = lblFilialFromName;

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

                stbFilialToID.ValueReferenceQuery = "[dbo].[pr_QK_CB_Get_Filials]";
                stbFilialToID.ApplyAdditionalParameter("Is_Sender", false);
                stbFilialToID.UserID = this.UserID;
                stbFilialToID.OnVerifyValue += (s, e) =>
                {
                    var control = s as SearchTextBox;
                    Label lblDescription = null;

                    if (control == stbFilialToID)
                        lblDescription = lblFilialToName;

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
                aP_Get_ProvisorsTableAdapter.FillCB(quality.AP_Get_Provisors, this.UserID);
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
            else if (cbParameterSelector.Equals(cbFilialFrom))
                parameterEditor = stbFilialFromID;
            else if (cbParameterSelector.Equals(cbFilialTo))
                parameterEditor = stbFilialToID;
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
                var qcbp = new QualityInputControlBranchParameters { SessionID = this.UserID };

                if (cbRouteListNumber.Checked)
                {
                    long routeListNumber;
                    if (!long.TryParse(tbRouteListNumber.Text, out routeListNumber))
                        throw new Exception("Номер МЛ (межсклад) должен быть числом.");

                    qcbp.RouteListNumber = routeListNumber;
                }

                if (cbWorksheetNumber.Checked)
                {
                    long worksheetNumber;
                    if (!long.TryParse(tbWorksheetNumber.Text, out worksheetNumber))
                        throw new Exception("Номер анкеты должен быть числом.");

                    qcbp.WorksheetNumber = worksheetNumber;
                }

                if (cbFilialFrom.Checked)
                {
                    if (string.IsNullOrEmpty(stbFilialFromID.Value))
                        throw new Exception("Филиал (отправитель) не выбран.");

                    var filialFromID = Convert.ToInt64(stbFilialFromID.Value);
                    qcbp.FilialFromID = filialFromID;
                }

                if (cbFilialTo.Checked)
                {
                    if (string.IsNullOrEmpty(stbFilialToID.Value))
                        throw new Exception("Филиал (получатель) не выбран.");

                    var filialToID = Convert.ToInt64(stbFilialToID.Value);
                    qcbp.FilialToID = filialToID;
                }

                if (cbDriverName.Checked)
                {
                    string driverName = tbDriverName.Text.Trim();
                    if (string.IsNullOrEmpty(driverName))
                        throw new Exception("ФИО водителя не заполнено.");

                    if (driverName.Length < 3)
                        throw new Exception("Длина ФИО водителя должна быть не менее 3-х символов.");

                    qcbp.DriverName = driverName;
                }

                if (cbWorksheetDateCreate.Checked)
                {
                    var worksheetDateCreateFrom = dtpWorksheetDateCreateFrom.Checked ? dtpWorksheetDateCreateFrom.Value.Date : (DateTime?)null;
                    var worksheetDateCreateTo = dtpWorksheetDateCreateTo.Checked ? dtpWorksheetDateCreateTo.Value.Date : (DateTime?)null;

                    if (worksheetDateCreateFrom.HasValue && worksheetDateCreateTo.HasValue && worksheetDateCreateFrom > worksheetDateCreateTo)
                        throw new Exception("Начальный период не должен превышать конечный.");

                    qcbp.PeriodFrom = worksheetDateCreateFrom;
                    qcbp.PeriodTo = worksheetDateCreateTo;
                }

                if (cbProvisor.Checked)
                {
                    if (cmbProvisor.SelectedValue == null)
                        throw new Exception("Фармацевт не выбран.");

                    var provisorID = Convert.ToInt64(cmbProvisor.SelectedValue);
                    qcbp.ProvisorID = provisorID;
                }

                // статусы анкет
                qcbp.StatusNew = cbStatusNew.Checked;
                qcbp.StatusInWork = cbStatusInWork.Checked;
                qcbp.StatusAccepted = cbStatusAccepted.Checked;
                qcbp.StatusNotAccepted = cbStatusNotAccepted.Checked;

                QualityInputControlBranchWorksheetSearchForm.SearchParameter = qcbp;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
