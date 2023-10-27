using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для ввода кода виновного сотрудника.
    /// </summary>
    public partial class EnterFaultEmployeeForm : DialogForm
    {
        /// <summary>
        /// Киевский филиал
        /// </summary>
        private const string KIEV_WAREHOUSE = "       01LA1";

        /// <summary>
        /// Возвращает / устанавливает идентификатор пользовательской сессии.
        /// </summary>
        private long SessionID { get; set; }

        private string warehouseID = null;

        /// <summary>
        /// True, если доступен выбор виновного отдела, False если недоступен
        /// </summary>
        public bool IsDepartmentChoiceEnabled
        {
            get { return chbDepartment.Enabled; }
            set
            {
                chbDepartment.Enabled = value;
                if (!value)
                {
                    //EnableEmployeeChoice();
                    SetAccessEmployee(true);
                    SetAccessDepartment(false);

                    chbDepartment.Checked = false;
                }
            }
        }

        /// <summary>
        /// True, если виновным является сотрудник, False если отдел
        /// </summary>
        public bool FaultIsEmployee { get { return !chbDepartment.Checked; } }

        /// <summary>
        /// Номер претензии, для которой выбираются сотрудники
        /// </summary>
        private long? docID = null;

        /// <summary>
        /// Тип претензии, для которой выбираются сотрудники
        /// </summary>
        private string docType = null;

        /// <summary>
        /// Подтип претензии, для которой выбираются сотрудники
        /// </summary>
        private string docSubType = null;

        public EnterFaultEmployeeForm(long sessionID, int faultEmployeeID, string pDocType, string pDocSubtype, string pWarehouseID, long? pDocID)
            : this(sessionID, faultEmployeeID, pDocType, pDocSubtype, pWarehouseID)
        {
            docID = pDocID;
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="sessionID">Идентификатор пользовательской сессии.</param>
        /// <param name="faultEmployeeID">Код виновного сотрудника.</param>
        public EnterFaultEmployeeForm(long sessionID, int faultEmployeeID, string pDocType, string pDocSubtype, string pWarehouseID)
        {
            InitializeComponent();
            IsDepartmentChoiceEnabled = true;

            btnOK.DialogResult = DialogResult.None;
            tbFaultEmployeeID.Text = faultEmployeeID.ToString();

            this.SessionID = sessionID;
            docType = pDocType;
            docSubType = pDocSubtype;
            warehouseID = pWarehouseID;
            availableEmployeesTableAdapter.Fill(complaints.AvailableEmployees, SessionID, null, docType, docSubType, null);
        }

        /// <summary>
        /// Введенный пользователем код виновного сотрудника.
        /// </summary>
        public int? FaultEmployeeID { get; private set; }

        /// <summary>
        /// Выбранный пользователем виновный сотрудник
        /// </summary>
        public string FaultEmployee { get; private set; }

        /// <summary>
        /// Введенный пользователем код виновного отдела
        /// </summary>
        public int? FaultDepartmentID { get; private set; }

        /// <summary>
        /// Выбранный виновный сотрудник
        /// </summary>
        public Data.Complaints.AvailableEmployeesRow SelectedFaultEmployee { get { return dgvEmployees.SelectedRows.Count > 0 ? (dgvEmployees.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.AvailableEmployeesRow : null; } }

        /// <summary>
        /// Необходимость выбора виновного отдела вместе в виновным сотрудником
        /// </summary>
        private bool NeedFaultEmployeeWithDepartment
        {
            get
            {
               return this.CheckNeedFaultEmployeeWithDepartmentByEmployeeType() || this.CheckNeedFaultEmployeeWithDepartmentByComplaintType();
            }
        }

        /// <summary>
        /// Анализ выбора виновного отдела вместе в виновным сотрудником по типу сотрудника
        /// </summary>
        public bool CheckNeedFaultEmployeeWithDepartmentByEmployeeType()
        {
            return this.SelectedFaultEmployee != null ? (this.SelectedFaultEmployee.IsFault_Department_RequiredNull() ? false : this.SelectedFaultEmployee.Fault_Department_Required) : false;
        }

        /// <summary>
        /// Анализ выбора виновного отдела вместе в виновным сотрудником по типу претензии
        /// </summary>
        private bool CheckNeedFaultEmployeeWithDepartmentByComplaintType()
        {
            return //false;
                   docType != null && (
                //((docType.Equals(Constants.CO_DT_ND) && warehouseID != null && warehouseID.Trim().Equals(KIEV_WAREHOUSE.Trim())) ||
                   docType.Equals(Constants.CO_DTFL_ITND) ||
                   docType.Equals(Constants.CO_DTFL_BOXND) ||
                   docType.Equals(Constants.CO_DT_ND) ||
                   docType.Equals(Constants.CO_DT_W_ND));
                   
            //docType.Equals(Constants.CO_DT_BOY));
            //docType.Equals(Constants.CO_DT_OVERAGE));
            //docType.Equals(Constants.CO_DT_NTV)); отключено по требованию
        }

        /// <summary>
        /// Обрабатывает изменение текстового поля быстрого поиска сотрудника по части ФИО.
        /// </summary>
        private void tbNameFilter_TextChanged(object sender, EventArgs e)
        {
            delayTimer.Enabled = false;
            delayTimer.Enabled = true;
        }

        /// <summary>
        /// Обрабатывает отложенную операцию обновления списка сотрудников после ввода текста в поле быстрого поиска.
        /// </summary>
        private void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Enabled = false;
            availableEmployeesTableAdapter.Fill(complaints.AvailableEmployees, SessionID, tbNameFilter.Text, docType, docSubType, null);
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            int parsedEmployeeID = 0;

            if (!string.IsNullOrEmpty(tbFaultEmployeeID.Text))
                int.TryParse(tbFaultEmployeeID.Text, out parsedEmployeeID);

            FaultEmployeeID = (int?)null;
            if (FaultIsEmployee || NeedFaultEmployeeWithDepartment)
            {
                if (parsedEmployeeID == 0)
                {
                    MessageBox.Show("Код виновного сотрудника не введен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbFaultEmployeeID.BackColor = Color.Pink;
                    tbFaultEmployeeID.Focus();
                    return;
                }
                else
                { 
                    FaultEmployeeID = parsedEmployeeID;
                    if (!CheckEmployee(parsedEmployeeID))
                        return;
                }
            }

            FaultDepartmentID = (int?)null;
            if (!FaultIsEmployee || NeedFaultEmployeeWithDepartment)
            {
                if (cmbDepartments.SelectedItem != null)
                {
                    FaultDepartmentID = Convert.ToInt32(cmbDepartments.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Нужно выбрать виновный отдел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                var faultEmployeeID = FaultEmployeeID;
                var faultDepartmentID = FaultDepartmentID;

                var needCheck = (bool?)null;
                availableEmployeesTableAdapter.CheckEmployeeWarehouse(docID, faultEmployeeID, faultDepartmentID, ref needCheck);
                if ((needCheck ?? false) == true && MessageBox.Show("Выбранный сотрудник с другого отдела/склада.\r\nВы уверены?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();

            #region OBSOLETE

            //if (FaultIsEmployee)
            //{
            //    if (!string.IsNullOrEmpty(tbFaultEmployeeID.Text) && int.TryParse(tbFaultEmployeeID.Text, out parsedEmployeeID) && parsedEmployeeID != 0)
            //    {
            //        FaultEmployeeID = parsedEmployeeID;
            //        if (CheckEmployee(parsedEmployeeID))
            //        {
            //            DialogResult = DialogResult.OK;
            //            Close();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Код виновного сотрудника не введен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        tbFaultEmployeeID.BackColor = Color.Pink;
            //        tbFaultEmployeeID.Focus();
            //    }
            //}
            //else
            //{
            //    if (cmbDepartments.SelectedItem != null)
            //    {
            //        FaultDepartmentID = Convert.ToInt32(cmbDepartments.SelectedValue);
            //        DialogResult = DialogResult.OK;
            //        Close();
            //    }
            //    else
            //        MessageBox.Show("Нужно выбрать виновный отдел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            #endregion
        }

        /// <summary>
        /// Проверка, можно ли выбрать в качестве виновного сотрудника с данным идентификатором
        /// </summary>
        /// <param name="pID">Введенный пользователем идентификатор сотрудника (он может быть как правильным, так и нет)</param>
        /// <returns>True если идентификатор сотрудника правильный, False в противном случае</returns>
        private bool CheckEmployee(int pID)
        {
            try
            {
                var table = availableEmployeesTableAdapter.GetData(SessionID, null, docType, docSubType, pID);
                if (table == null || table.Rows.Count == 0)
                {
                    Logger.ShowErrorMessageBox("Сотрудника с таким идентификатором нет или он недоступен для выбора в качестве виновного!");
                    return false;
                }

                FaultEmployee = table[0].Employee_Name;
                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время проверки правильности выбора виновного сотрудника: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Обрабатывает двойной клик по ячейке, меняя код виновного сотрудника на выбранный.
        /// </summary>
        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbFaultEmployeeID.Text = complaints.AvailableEmployees[e.RowIndex].Employee_ID.ToString();

            //if (NeedFaultEmployeeWithDepartment)
            //    LoadDepartments();

            if (NeedFaultEmployeeWithDepartment)
            {
                LoadDepartments();

                SetAccessEmployee(true);
                SetAccessDepartment(true);

                IsDepartmentChoiceEnabled = true;
                chbDepartment.Checked = true;
                chbDepartment.Enabled = false;
            }
            else
            {
                SetAccessEmployee(true);
                SetAccessDepartment(false);

                chbDepartment.Checked = false;
                chbDepartment.Enabled = true;
            }
        }

        /// <summary>
        /// Загрузка отделов при загрузке формы выбора виновного сотрудника
        /// </summary>
        private void EnterFaultEmployeeForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();

            //EnableEmployeeChoice();

            if (NeedFaultEmployeeWithDepartment)
            {
                SetAccessEmployee(true);
                SetAccessDepartment(true);

                IsDepartmentChoiceEnabled = true;
                chbDepartment.Checked = true;
                chbDepartment.Enabled = false;
            }
            else
            {
                SetAccessEmployee(true);
                SetAccessDepartment(false);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(259, 8);
            this.btnCancel.Location = new Point(349, 8);
        }

        /// <summary>
        /// Загрузка отделов для выбора виновного сотрудника
        /// </summary>
        private void LoadDepartments()
        {
            try
            {
                var faultEmployeeID = (int?)null;
                if (NeedFaultEmployeeWithDepartment)
                {
                    int parsedEmployeeID;
                    if (!string.IsNullOrEmpty(tbFaultEmployeeID.Text))
                        if (int.TryParse(tbFaultEmployeeID.Text, out parsedEmployeeID))
                            faultEmployeeID = parsedEmployeeID;
                }

                taCoDepartment.Fill(complaints.CO_Get_Available_department, SessionID, null, docType, faultEmployeeID, docID);

                if (complaints.CO_Get_Available_department.Rows.Count == 0)
                {
                    if (IsDepartmentChoiceEnabled || NeedFaultEmployeeWithDepartment)
                        MessageBox.Show("Не загружен ни один отдел! Выбор виновного отдела будет недоступен!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //EnableEmployeeChoice();
                    SetAccessEmployee(true);
                    SetAccessDepartment(false);
                }
                else
                    cmbDepartments.SelectedItem = null;
            }
            catch (Exception exc)
            {
                if (IsDepartmentChoiceEnabled)
                    Logger.ShowErrorMessageBox("Произошла ошибка при загрузке списка отделов! Выбор виновного отдела будет недоступен!");

                IsDepartmentChoiceEnabled = false;
            }
        }

        /// <summary>
        /// Делаем доступным выбор виновного сотрудника, а выбор виновного отдела - недоступным
        /// </summary>
        [Obsolete]
        private void EnableEmployeeChoice()
        {
            cmbDepartments.Enabled = false;
            lblRequestCaption.Enabled = true;
            tbFaultEmployeeID.Enabled = true;
            lblNameFilterCaption.Enabled = true;
            tbNameFilter.Enabled = true;
            dgvEmployees.Enabled = true;
        }

        private void SetAccessEmployee(bool isEnabled)
        {
            dgvEmployees.Enabled = isEnabled;
            lblRequestCaption.Enabled = isEnabled;
            tbFaultEmployeeID.Enabled = isEnabled;
            lblNameFilterCaption.Enabled = isEnabled;
            tbNameFilter.Enabled = isEnabled;
        }

        private void SetAccessDepartment(bool isEnabled)
        {
            cmbDepartments.Enabled = isEnabled;

            if (!isEnabled)
                cmbDepartments.SelectedItem = null;
        }

        /// <summary>
        /// Делаем доступным выбор виновного отдела, а выбор виновного сотрудника - недоступным
        /// </summary>
        [Obsolete]
        private void EnableDepartmentChoice()
        {
            cmbDepartments.Enabled = true;
            lblRequestCaption.Enabled = false;
            tbFaultEmployeeID.Enabled = false;
            lblNameFilterCaption.Enabled = false;
            tbNameFilter.Enabled = false;
            dgvEmployees.Enabled = false;
        }

        /// <summary>
        /// Переключение между выбором виновного сотрудника и выбором виновного отдела
        /// </summary>
        private void chbDepartment_CheckedChanged(object sender, EventArgs e)
        {
            var chb = sender as CheckBox;
            if (chb.Checked)
            {
                //EnableDepartmentChoice();
                if (NeedFaultEmployeeWithDepartment)
                {
                    SetAccessEmployee(true);
                    SetAccessDepartment(true);
                }
                else
                {
                    SetAccessEmployee(false);
                    SetAccessDepartment(true);
                }
            }
            else
            {
                //EnableEmployeeChoice();
                SetAccessEmployee(true);
                SetAccessDepartment(false);
            }
        }

        private void dgvEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var boundRow = (dgvEmployees.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.AvailableEmployeesRow;
            var faultDepartmentRequired = boundRow.IsFault_Department_RequiredNull() ? false : boundRow.Fault_Department_Required;

            if (faultDepartmentRequired)
            {
                e.CellStyle.ForeColor = e.CellStyle.SelectionForeColor = Color.Brown;
            }
        }
    }
}
