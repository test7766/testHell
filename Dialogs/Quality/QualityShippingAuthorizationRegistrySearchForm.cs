using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityShippingAuthorizationRegistrySearchForm : DialogForm
    {
        public long? RouteListNumber { get; private set; }
        public DateTime? PeriodFrom { get; private set; }
        public DateTime? PeriodTo { get; private set; }
        public long? ProvisorID { get; private set; }
        public int? BranchID { get; private set; }

        public QualityShippingAuthorizationRegistrySearchForm()
        {
            InitializeComponent();
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
            this.InitializeProvisors();
            this.InitializeWarehouses();
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

        private void InitializeWarehouses()
        {
            try
            {
                qK_SA_BranchesTableAdapter.Fill(quality.QK_SA_Branches, this.UserID);
                cmbBranch.SelectedItem = null;
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
            else if (cbParameterSelector.Equals(cbWorksheetDateCreate))
                parameterEditor = dtpWorksheetDateCreateFrom;
            else if (cbParameterSelector.Equals(cbProvisor))
                parameterEditor = cmbProvisor;
            else if (cbParameterSelector.Equals(cbBranch))
                parameterEditor = cmbBranch;

            if (parameterEditor != null)
            {
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

        private void QualityShippingAuthorizationRegistrySearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (!cbRouteListNumber.Checked && !cbWorksheetDateCreate.Checked && !cbProvisor.Checked && !cbBranch.Checked)
                    throw new Exception("Не выбраны критерии поиска.");

                if (cbRouteListNumber.Checked)
                {
                    long routeListNumber;
                    if (!long.TryParse(tbRouteListNumber.Text, out routeListNumber))
                        throw new Exception("Номер МЛ должен быть числом.");

                    this.RouteListNumber = routeListNumber;
                }

                if (cbWorksheetDateCreate.Checked)
                {
                    var worksheetDateCreateFrom = dtpWorksheetDateCreateFrom.Checked ? dtpWorksheetDateCreateFrom.Value.Date : (DateTime?)null;
                    var worksheetDateCreateTo = dtpWorksheetDateCreateTo.Checked ? dtpWorksheetDateCreateTo.Value.Date : (DateTime?)null;

                    if (worksheetDateCreateFrom.HasValue && worksheetDateCreateTo.HasValue && worksheetDateCreateFrom > worksheetDateCreateTo)
                        throw new Exception("Начальный период не должен превышать конечный.");

                    this.PeriodFrom = worksheetDateCreateFrom;
                    this.PeriodTo = worksheetDateCreateTo;
                }

                if (cbProvisor.Checked)
                {
                    if (cmbProvisor.SelectedValue == null)
                        throw new Exception("Фармацевт не выбран.");

                    var provisorID = Convert.ToInt64(cmbProvisor.SelectedValue);
                    this.ProvisorID = provisorID;
                }

                if (cbBranch.Checked)
                {
                    if (cmbBranch.SelectedValue == null)
                        throw new Exception("Филиал не выбран.");

                    var branchID = Convert.ToInt32(cmbBranch.SelectedValue);
                    this.BranchID = branchID;
                }

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
