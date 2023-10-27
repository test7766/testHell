using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для ввода параметров поиска документа претензии.
    /// </summary>
    public partial class SearchComplaintOptionsForm : Form
    {
        public long SessionID { get; private set; }

        private string[] docTypesFilter = null;
        public string[] DocTypesFilter
        {
            get { return docTypesFilter; }
            private set
            {
                if ((docTypesFilter = value) != null)
                {
                    chkbType.Checked = true;
                    chkbType.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="sessionID">Идентификатор сессии пользователя.</param>
        /// <param name="docTypesFilter">Фильтр типов документов: если он не пуст или не равен null,
        /// тип документа должен быть всегда задан пользователем, причем, только один из этого фильтра.</param>
        public SearchComplaintOptionsForm(long sessionID, string[] docTypesFilter)
        {
            InitializeComponent();           

            // инициализация списка типов претензий
            complaints.AvailableDocsTypes.LoadDataRow(new object[] { string.Empty, string.Empty }, true);

            // инициализация списка менеджеров, за которыми закреплены источники претензий
            complaints.AvailableManagers.LoadDataRow(new object[] { -1, string.Empty }, true);

            // инициализация списка дебиторов - источников
            complaints.AvailableSourceDebtors.LoadDataRow(new object[] { -1, string.Empty }, true);

            // инициализация списка пользователей-создателей претензий
            complaints.AvailableEmployeesCreated.LoadDataRow(new object[] { -1, string.Empty }, true);

            // инициализация списка пользователей-виновных сотрудников
            complaints.AvailableFaultEmployees.LoadDataRow(new object[] { -1, string.Empty }, true);

            this.SessionID = sessionID;
            this.DocTypesFilter = docTypesFilter;

            dtpDateFrom.Value = DateTime.Today.AddDays(-3);
            dtpDateTo.Value = DateTime.Today.AddDays(1);
        }

        /// <summary>
        /// Выбранный пользователем тип претензии.
        /// </summary>
        public string DocType { get; private set; }

        /// <summary>
        /// Введенный пользователем номер претензии.
        /// </summary>
        public long? DocID { get; private set; }

        /// <summary>
        /// Выбранный пользователем код менеджера, за которым закреплен адрес доставки источника претензии.
        /// </summary>
        public int? ManagerID { get; private set; }

        /// <summary>
        /// Выбранный пользователем код основного дебитора по адресу доставки источника претензии.
        /// </summary>
        public int? DebtorID { get; private set; }

        /// <summary>
        /// Выбранный пользователем код сотрудника, создавшего претензию.
        /// </summary>
        public int? CreatorID { get; private set; }

        /// <summary>
        /// Выбранный пользователем код виновного сотрудника.
        /// </summary>
        public int? FaultEmployeeID { get; private set; }

        /// <summary>
        /// Дата претензии "с".
        /// </summary>
        public DateTime? DateFrom { get; private set; }

        /// <summary>
        /// Дата претензии "по".
        /// </summary>
        public DateTime? DateTo { get; private set; }

        /// <summary>
        /// Введенная пользователем часть названия товара в составе претензии.
        /// </summary>
        public string ItemName { get; private set; }

        /// <summary>
        /// Заказ, по которому была создана претензия
        /// </summary>
        public long? LinkedOrderID { get; private set; }

        /// <summary>
        /// Накладная, по которой была создана претензия
        /// </summary>
        public long? LinkedInvoiceID { get; private set; }

        /// <summary>
        /// Код товара в составе претензии
        /// </summary>
        public int? ItemId { get; private set; }

        /// <summary>
        /// Меняет доступность элементов управления при изменении состояния флажков.
        /// </summary>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gbType.Enabled = chkbType.Checked)
            {
                if (complaints.AvailableDocsTypes.Count > 0 && complaints.AvailableDocsTypes[0].Doc_Type.Equals(string.Empty))
                {
                    #region ПОДГОТОВКА ФИЛЬТРА ТИПОВ ДОКУМЕНТА

                    var doc = new XmlDocument();
                    var root = (XmlElement)doc.AppendChild(doc.CreateElement("Root"));

                    if (DocTypesFilter != null)
                    {
                        foreach (var docType in DocTypesFilter)
                        {
                            var node = (XmlElement)root.AppendChild(doc.CreateElement("DocType"));
                            node.SetAttribute("ID", docType);
                        }
                    }

                    #endregion

                   availableDocsTypesTableAdapter.Fill(complaints.AvailableDocsTypes, this.SessionID, false, doc.InnerXml);
                }
            }

            gbID.Enabled = chkbID.Checked;
            gbLinkedOrderID.Enabled = chkbLinkedOrderID.Checked;
            gbLinkedInvoiceID.Enabled = chkbLinkedInvoiceID.Checked;

            if (gbManager.Enabled = chkbManager.Checked)
            {
                if (complaints.AvailableManagers.Count > 0 && complaints.AvailableManagers[0].Manager_ID.Equals(-1))
                availableManagersTableAdapter.Fill(complaints.AvailableManagers, this.SessionID);
            }

            if (gbDebtor.Enabled = chkbDebtor.Checked)
            {
                if (complaints.AvailableSourceDebtors.Count > 0 && complaints.AvailableSourceDebtors[0].Debtor_ID.Equals(-1))
                    availableSourceDebtorsTableAdapter.Fill(complaints.AvailableSourceDebtors, this.SessionID);
            }

            if (gbCreator.Enabled = chkbCreator.Checked)
            {
                if (complaints.AvailableEmployeesCreated.Count > 0 && complaints.AvailableEmployeesCreated[0].Employee_ID.Equals(-1))
                    availableEmployeesCreatedTableAdapter.Fill(complaints.AvailableEmployeesCreated, this.SessionID);
            }

            if (gbFaultEmployee.Enabled = chkbFaultEmployee.Checked)
            {
                if (complaints.AvailableFaultEmployees.Count > 0 && complaints.AvailableFaultEmployees[0].Employee_ID.Equals(-1))
                    availableFaultEmployeesTableAdapter.Fill(complaints.AvailableFaultEmployees, this.SessionID);
            }
            
            gbDate.Enabled = chkbDate.Checked;
            gbItemName.Enabled = chkbItemName.Checked;
            gbItemId.Enabled = chbItemId.Checked;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!chkbID.Checked && !chkbLinkedOrderID.Checked && !chkbLinkedInvoiceID.Checked && !chkbManager.Checked && !chkbDebtor.Checked && !chkbCreator.Checked && !chkbFaultEmployee.Checked && !chkbDate.Checked && !chkbItemName.Checked && !chbItemId.Checked)
            {
                MessageBox.Show("Для начала поиска нужно выбрать и ввести минимум 1 параметр, помимо типа претензии!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkbType.Checked)
            {
                DocType = (string)cbTypes.SelectedValue;
            }
            else
            {
                DocType = null;
            }

            if (chkbID.Checked)
            {
                long tmp = 0;
                if (!long.TryParse(tbID.Text, out tmp) || tmp <= 0)
                {
                    MessageBox.Show("Номер (код) претензии введен некорректно!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DocID = tmp;
                }
            }
            else
            {
                DocID = null;
            }

            if (chkbLinkedOrderID.Checked)
            {
                long tmp = 0;
                if (!long.TryParse(tbLinkedOrderID.Text, out tmp) || tmp <= 0)
                {
                    MessageBox.Show("Номер (код) заказа, по кот. создана претензия введен некорректно!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LinkedOrderID = tmp;
                }
            }
            else
            {
                LinkedOrderID = null;
            }

            if (chkbLinkedInvoiceID.Checked)
            {
                long tmp = 0;
                if (!long.TryParse(tbLinkedInvoiceID.Text, out tmp) || tmp <= 0)
                {
                    MessageBox.Show("Номер (код) накладной введен некорректно!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LinkedInvoiceID = tmp;
                }
            }
            else
            {
                LinkedInvoiceID = null;
            }

            if (chkbManager.Checked)
            {
                if (cbManager.SelectedValue == null || cbManager.SelectedIndex == -1)
                {
                    MessageBox.Show("Менеджер, закрепленный за клиентом, не выбран из списка!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    ManagerID = Convert.ToInt32(cbManager.SelectedValue);
                }
            }
            else
            {
                ManagerID = null;
            }

            if (chkbDebtor.Checked)
            {
                if (cbDebtor.SelectedValue == null || cbDebtor.SelectedIndex == -1)
                {
                    MessageBox.Show("Основной дебитор не выбран из списка!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DebtorID = Convert.ToInt32(cbDebtor.SelectedValue);
                }
            }
            else
            {
                DebtorID = null;
            }

            if (chkbCreator.Checked)
            {
                if (cbCreator.SelectedValue == null || cbCreator.SelectedIndex == -1)
                {
                    MessageBox.Show("Сотрудник, создавший претензию, не выбран из списка!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    CreatorID = Convert.ToInt32(cbCreator.SelectedValue);
                }
            }
            else
            {
                CreatorID = null;
            }

            if (chkbFaultEmployee.Checked)
            {
                if (cbFaultEmployee.SelectedValue == null || cbFaultEmployee.SelectedIndex == -1)
                {
                    MessageBox.Show("Виновный сотрудник не выбран из списка!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    FaultEmployeeID = Convert.ToInt32(cbFaultEmployee.SelectedValue);
                }
            }
            else
            {
                FaultEmployeeID = null;
            }

            if (chkbDate.Checked)
            {
                if (dtpDateFrom.Value > dtpDateTo.Value)
                {
                    MessageBox.Show("Дата периода \"с\" не может быть больше даты периода \"по\"!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if ((dtpDateFrom.Value - dtpDateTo.Value).TotalDays > 30)
                {
                    MessageBox.Show("Выбран слишком большой период! Разница между датами периода\"с\" и \"по\" не должна превышать 30 дней.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DateFrom = dtpDateFrom.Value;
                    DateTo = dtpDateTo.Value;
                }
            }
            else
            {
                DateFrom = null;
                DateTo = null;
            }

            if (chkbItemName.Checked)
            {
                if (string.IsNullOrEmpty(tbItemName.Text) || tbItemName.Text.Length < 4)
                {
                    MessageBox.Show("Введите не менее 4 символов из названия товара!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    ItemName = tbItemName.Text;
                }
            }
            else
            {
                ItemName = null;
            }

            if (chbItemId.Checked)
            {
                int tmp = 0;
                if (!Int32.TryParse(tbxItemId.Text, out tmp) || tmp <= 0)
                {
                    MessageBox.Show("Номер (код) товара введен некорректно!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    ItemId = tmp;
                }
            }
            else
            {
                ItemId = null;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
