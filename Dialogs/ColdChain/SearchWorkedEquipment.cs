using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class SearchWorkedEquipment : DialogForm
    {
        public static SearchWorkedEquipmentParameters SearchParameters { get; private set; }

        public SearchWorkedEquipment()
        {
            InitializeComponent();
        }

        static SearchWorkedEquipment()
        {
            SearchParameters = new SearchWorkedEquipmentParameters();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(215, 8);
            btnCancel.Location = new Point(305, 8);

            Initialize();
        }

        private void Initialize()
        {
            // поиск в архиве
            cbSearchInArchive.Checked = Convert.ToBoolean(SearchParameters.SearchInArchive);

            // по маршрутному листу
            if (!string.IsNullOrEmpty(SearchParameters.RouteListNumber))
                tbRouteListNumber.Text = SearchParameters.RouteListNumber;

            if (SearchParameters.RouteListDate.HasValue)
                dtpRouteListDate.Value = SearchParameters.RouteListDate.Value.Date;

            if (SearchParameters.DriverCode.HasValue)
            {
                tbDriverCode.Text = SearchParameters.DriverCode.Value.ToString();
                //tbDriverCode_Leave(tbDriverCode, EventArgs.Empty);
            }

            // по оборудованию / датчикам / закреплению
            if (!string.IsNullOrEmpty(SearchParameters.EquipmentBarCode))
                tbEquipmentBarCode.Text = SearchParameters.EquipmentBarCode;

            if (!string.IsNullOrEmpty(SearchParameters.SensorBarCode))
                tbSensorBarCode.Text = SearchParameters.SensorBarCode;

            if (SearchParameters.DocID.HasValue)
                tbDocID.Text = SearchParameters.DocID.Value.ToString();

            // по сборочному / дебитору
            if (SearchParameters.PickSlipNumber.HasValue)
                tbPickSlipNumber.Text = SearchParameters.PickSlipNumber.Value.ToString();

            if (SearchParameters.DebtorCode.HasValue)
            {
                tbDebtorCode.Text = SearchParameters.DebtorCode.Value.ToString();
                //tbDebtorCode_Leave(tbDebtorCode, EventArgs.Empty);
            }
        }

        private void tbControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(sender as Control, true, true, true, false);
        }

        private void tbOnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void SearchWorkedEquipment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateData();
        }

        private bool ValidateData()
        {
            bool allowSave = false;
            Control needFocusAfterError = null;
            try
            {
                // поиск в архиве
                SearchParameters.SearchInArchive = Convert.ToInt32(cbSearchInArchive.Checked);

                // по маршрутному листу
                if (string.IsNullOrEmpty(tbRouteListNumber.Text))
                {
                    SearchParameters.RouteListNumber = (string)null;
                }
                else
                {
                    SearchParameters.RouteListNumber = tbRouteListNumber.Text;
                    allowSave = true;
                }

                if (!dtpRouteListDate.Checked)
                {
                    SearchParameters.RouteListDate = (DateTime?)null;
                }
                else
                {
                    SearchParameters.RouteListDate = dtpRouteListDate.Value.Date;
                    allowSave = true;
                }

                if (string.IsNullOrEmpty(tbDriverCode.Text))
                {
                    SearchParameters.DriverCode = (int?)null;
                }
                else
                {
                    int parsedDriverCode;
                    if (int.TryParse(tbDriverCode.Text, out parsedDriverCode))
                    {
                        SearchParameters.DriverCode = parsedDriverCode;
                        allowSave = true;
                    }
                    else
                    {
                        needFocusAfterError = tbDriverCode;
                        throw new Exception("Код водителя должен быть числом.");
                    }
                }

                // по оборудованию / датчикам / закреплению
                if (string.IsNullOrEmpty(tbEquipmentBarCode.Text))
                {
                    SearchParameters.EquipmentBarCode = (string)null;
                }
                else
                {
                    SearchParameters.EquipmentBarCode = tbEquipmentBarCode.Text;
                    allowSave = true;
                }

                if (string.IsNullOrEmpty(tbSensorBarCode.Text))
                {
                    SearchParameters.SensorBarCode = (string)null;
                }
                else
                {
                    SearchParameters.SensorBarCode = tbSensorBarCode.Text;
                    allowSave = true;
                }

                if (string.IsNullOrEmpty(tbDocID.Text))
                {
                    SearchParameters.DocID = (long?)null;
                }
                else
                {
                    long parsedDocID;
                    if (long.TryParse(tbDocID.Text, out parsedDocID))
                    {
                        SearchParameters.DocID = parsedDocID;
                        allowSave = true;
                    }
                    else
                    {
                        needFocusAfterError = tbDocID;
                        throw new Exception("Код документа должен быть числом.");
                    }
                }

                // по сборочному / дебитору
                if (string.IsNullOrEmpty(tbPickSlipNumber.Text))
                {
                    SearchParameters.PickSlipNumber = (int?)null;
                }
                else
                {
                    int parsedPickSlipNumber;
                    if (int.TryParse(tbPickSlipNumber.Text, out parsedPickSlipNumber))
                    {
                        SearchParameters.PickSlipNumber = parsedPickSlipNumber;
                        allowSave = true;
                    }
                    else
                    {
                        needFocusAfterError = tbPickSlipNumber;
                        throw new Exception("№ сборочного должен быть числом.");
                    }
                }

                if (string.IsNullOrEmpty(tbDebtorCode.Text))
                {
                    SearchParameters.DebtorCode = (int?)null;
                }
                else
                {
                    int parsedDebtorCode;
                    if (int.TryParse(tbDebtorCode.Text, out parsedDebtorCode))
                    {
                        SearchParameters.DebtorCode = parsedDebtorCode;
                        allowSave = true;
                    }
                    else
                    {
                        needFocusAfterError = tbDebtorCode;
                        throw new Exception("Код дебитора должен быть числом.");
                    }
                }

                if (!allowSave)
                    throw new Exception("Необходимо заполнить хотя бы одно поле.");

                SearchParameters.SessionID = this.UserID;

                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (needFocusAfterError != null)
                    needFocusAfterError.Focus();
                
                return false;
            }
        }

        #region МЕТОДЫ АДАПТАЦИИ ПОИСКА ПО СПРАВОЧНИКАМ

        private void tbDriverCode_Leave(object sender, EventArgs e)
        {
            var driverCode = (int?)null;
            if (!string.IsNullOrEmpty(tbDriverCode.Text))
            {
                int parsedDriverCode;
                if (int.TryParse(tbDriverCode.Text, out parsedDriverCode))
                    driverCode = parsedDriverCode;
            }

            var clearInfo = false;
            if (driverCode.HasValue)
            {
                var driverName = (string)null;

                var cancelFind = false;
                var driverInfo = FindDriverInfo(driverCode, driverName, ref cancelFind);
                if (driverInfo != null)
                {
                    tbDriverCode.Text = Convert.ToInt32(driverInfo.Employee_id).ToString();
                    tbDriverName.Text = driverInfo.Employee_Name;
                }
                else
                {
                    if (!cancelFind)
                        clearInfo = true;
                }
            }
            else
                clearInfo = true;

            if (clearInfo)
            {
                tbDriverCode.Clear();
                tbDriverName.Clear();
            }
        }

        private void tbDriverName_Leave(object sender, EventArgs e)
        {
            var driverName = (string)null;
            if (!string.IsNullOrEmpty(tbDriverName.Text))
                driverName = tbDriverName.Text;

            var clearInfo = false;
            if (!string.IsNullOrEmpty(driverName))
            {
                var driverCode = (int?)null;
                if (!string.IsNullOrEmpty(tbDriverCode.Text))
                {
                    int parsedDriverCode;
                    if (int.TryParse(tbDriverCode.Text, out parsedDriverCode))
                        driverCode = parsedDriverCode;
                }

                var cancelFind = false;
                var driverInfo = FindDriverInfo(driverCode, driverName, ref cancelFind);
                if (driverInfo != null)
                {
                    tbDriverCode.Text = Convert.ToInt32(driverInfo.Employee_id).ToString();
                    tbDriverName.Text = driverInfo.Employee_Name;
                }
                else
                {
                    if (!cancelFind)
                        clearInfo = true;
                }
            }
            else
                clearInfo = true;

            if (clearInfo)
            {
                tbDriverCode.Clear();
                tbDriverName.Clear();
            }
        }

        private Data.ColdChain.EmployeesRow FindDriverInfo(int? driverCode, string driverName, ref bool cancelFind)
        {
            Data.ColdChain.EmployeesRow findDriverInfo = null;

            var dtDrivers = new Data.ColdChain.EmployeesDataTable();
            using (var adapter = new Data.ColdChainTableAdapters.EmployeesTableAdapter())
                adapter.Fill(dtDrivers, this.UserID, driverCode, driverName);

            var cntDrivers = dtDrivers.Rows.Count;
            if (cntDrivers > 0)
            {
                if (cntDrivers == 1)
                    findDriverInfo = dtDrivers[0];
                else
                {
                    var dlgSelectDriver = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectDriver.Text = "Выберите водителя";
                    dlgSelectDriver.AddColumn("Employee_id", "Employee_id", "Код");
                    dlgSelectDriver.AddColumn("Employee_Name", "Employee_Name", "Ф.И.О. сотрудника");
                    dlgSelectDriver.ColumnForFilters = new List<string>(new string[] { "Employee_Name" });
                    dlgSelectDriver.FilterChangeLevel = 0;

                    dtDrivers.DefaultView.RowFilter = string.Empty;
                    dlgSelectDriver.DataSource = dtDrivers;

                    if (dlgSelectDriver.ShowDialog() == DialogResult.OK)
                        findDriverInfo = dlgSelectDriver.SelectedRow as Data.ColdChain.EmployeesRow;
                    else
                        cancelFind = true;
                }
            }

            return findDriverInfo;
        }

        private void tbDebtorCode_Leave(object sender, EventArgs e)
        {
            var debtorCode = (int?)null;
            if (!string.IsNullOrEmpty(tbDebtorCode.Text))
            {
                int parsedDebtorCode;
                if (int.TryParse(tbDebtorCode.Text, out parsedDebtorCode))
                    debtorCode = parsedDebtorCode;
            }

            var clearInfo = false;
            if (debtorCode.HasValue)
            {
                var debtorName = (string)null;

                var cancelFind = false;
                var debtorPointInfo = FindDebtorPointInfo(debtorCode, debtorName, ref cancelFind);
                if (debtorPointInfo != null)
                {
                    tbDebtorCode.Text = Convert.ToInt32(debtorPointInfo.Debtor_point_id).ToString();
                    tbDebtorName.Text = debtorPointInfo.Debtor_point_Name;
                }
                else
                {
                    if (!cancelFind)
                        clearInfo = true;
                }
            }
            else
                clearInfo = true;

            if (clearInfo)
            {
                tbDebtorCode.Clear();
                tbDebtorName.Clear();
            }
        }

        private void tbDebtorName_Leave(object sender, EventArgs e)
        {
            var debtorName = (string)null;
            if (!string.IsNullOrEmpty(tbDebtorName.Text))
                debtorName = tbDebtorName.Text;

            var clearInfo = false;
            if (!string.IsNullOrEmpty(debtorName))
            {
                var debtorCode = (int?)null;
                if (!string.IsNullOrEmpty(tbDebtorCode.Text))
                {
                    int parsedDebtorCode;
                    if (int.TryParse(tbDebtorCode.Text, out parsedDebtorCode))
                        debtorCode = parsedDebtorCode;
                }

                var cancelFind = false;
                var debtorPointInfo = FindDebtorPointInfo(debtorCode, debtorName, ref cancelFind);
                if (debtorPointInfo != null)
                {
                    tbDebtorCode.Text = Convert.ToInt32(debtorPointInfo.Debtor_point_id).ToString();
                    tbDebtorName.Text = debtorPointInfo.Debtor_point_Name;
                }
                else
                {
                    if (!cancelFind)
                        clearInfo = true;
                }
            }
            else
                clearInfo = true;

            if (clearInfo)
            {
                tbDebtorCode.Clear();
                tbDebtorName.Clear();
            }
        }

        private Data.ColdChain.DebtorPointsRow FindDebtorPointInfo(int? debtorCode, string debtorName, ref bool cancelFind)
        {
            Data.ColdChain.DebtorPointsRow findDebtorPointInfo = null;

            var dtDebtorPoints = new Data.ColdChain.DebtorPointsDataTable();
            using (var adapter = new Data.ColdChainTableAdapters.DebtorPointsTableAdapter())
                adapter.Fill(dtDebtorPoints, this.UserID, debtorCode, debtorName);

            var cntDebtorPoints = dtDebtorPoints.Rows.Count;
            if (cntDebtorPoints > 0)
            {
                if (cntDebtorPoints == 1)
                    findDebtorPointInfo = dtDebtorPoints[0];
                else
                {
                    var dlgSelectDebtorPoint = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectDebtorPoint.Text = "Выберите дебитора";
                    dlgSelectDebtorPoint.AddColumn("Debtor_point_id", "Debtor_point_id", "Код");
                    dlgSelectDebtorPoint.AddColumn("Debtor_point_Name", "Debtor_point_Name", "Наименование дебитора доставки");
                    dlgSelectDebtorPoint.ColumnForFilters = new List<string>(new string[] { "Debtor_point_Name" });
                    dlgSelectDebtorPoint.FilterChangeLevel = 0;

                    dtDebtorPoints.DefaultView.RowFilter = string.Empty;
                    dlgSelectDebtorPoint.DataSource = dtDebtorPoints;

                    if (dlgSelectDebtorPoint.ShowDialog() == DialogResult.OK)
                        findDebtorPointInfo = dlgSelectDebtorPoint.SelectedRow as Data.ColdChain.DebtorPointsRow;
                    else
                        cancelFind = true;
                }
            }

            return findDebtorPointInfo;
        }

        #endregion
    }

    /// <summary>
    /// Параметры поиска датчиков
    /// </summary>
    public class SearchWorkedEquipmentParameters : SessionIDSearchParameters
    {
        public int SearchInArchive { get; set; }
        public string EquipmentBarCode { get; set; }
        public string SensorBarCode { get; set; }
        public long? DocID { get; set; }
        public string RouteListNumber { get; set; }
        public DateTime? RouteListDate { get; set; }
        public int? DriverCode { get; set; }
        public int? PickSlipNumber { get; set; }
        public int? DebtorCode { get; set; }
    }
}
