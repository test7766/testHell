using System;
using System.Windows.Forms;

using WMSOffice.Data.AccessTableAdapters;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Форма для считывания штрих-кода сотрудника при распределении счетных листов
    /// </summary>
    public partial class InventoryFilialScanEmployeeForm : Form
    {
        #region СВОЙСТВА

        /// <summary>
        /// Идентификатор пользователя, штрих-код которого был отсканирован
        /// </summary>
        public int EmployeeID { get; private set; }

        /// <summary>
        /// Признак того, доступна ли кнопка "Пропустить"
        /// </summary>
        public bool IsSkipEnabled
        {
            get { return btnSkip.Enabled; }
            set { btnSkip.Enabled = value; }
        }

        #endregion

        #region КОНСТРУКТОР

        public InventoryFilialScanEmployeeForm()
        {
            InitializeComponent();
            IsSkipEnabled = false;
            tbScanner.Focus();
        }

        #endregion

        #region СКАНИРОВАНИЕ ШТРИХ-КОДА СОТРУДНИКА

        /// <summary>
        /// Отсканирован штрих-код сотрудника: пытаемся найти такого сотрудника в БД
        /// </summary>
        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            using (var adapter = new UserInfoTableAdapter())
            {
                try
                {
                    int code = 0;
                    if (!Int32.TryParse(tbScanner.Text, out code))
                        throw new ApplicationException("Неправильный формат штрих-кода!");

                    var tblInfo = adapter.GetData(code);
                    if (tblInfo != null && tblInfo.Count > 0)
                    {
                        EmployeeID = code;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else 
                        throw new ApplicationException("Сотрудник не найден!");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbScanner.Focus();
                    tbScanner.SelectAll();
                }
            }
        }

        /// <summary>
        /// Пропускаем этот счетный лист и переходим к следующему
        /// </summary>
        private void btnSkip_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
        }

        #endregion
    }
}
