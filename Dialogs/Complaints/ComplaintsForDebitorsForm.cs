using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Форма для ввода данных для экспорта претензий по дебитору
    /// </summary>
    public partial class ComplaintsForDebitorsForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Дата начала промежутка, за который нужно загрузить претензии
        /// </summary>
        public DateTime DateFrom { get { return dtpDateFrom.Value; } }

        /// <summary>
        /// Дата конца промежутка, за который нужно загрузить претензии
        /// </summary>
        public DateTime DateTo { get { return dtpDateTo.Value; } }

        /// <summary>
        /// Идентификатор дебитора, для которого нужно загрузить претензии
        /// </summary>
        public int DebtorID { get { return Convert.ToInt32(cmbDebtors.SelectedValue); } }

        /// <summary>
        /// True, если нужно загрузить только открытые претензии, False если надо загрузить все претензии по дебитору за период
        /// </summary>
        public bool OnlyOpened { get { return chbOnlyOpened.Checked; } }

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private int sessionID;

        /// <summary>
        /// Название выбранного в выпадающем списке дебитора
        /// </summary>
        public string DebtorName
        {
            get
            {
                foreach (WMSOffice.Data.Complaints.DebitorListRow row in complaints.DebitorList.Rows)
                    if (row.Debitor_ID == DebtorID)
                        return row.Debitor;
                return null;
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public ComplaintsForDebitorsForm(int pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Получение из БД списка всех дебиторов при загрузке окна
        /// </summary>
        private void ComplaintsForDebitorsForm_Load(object sender, EventArgs e)
        {
            try
            {
                taDebitorList.Fill(complaints.DebitorList, sessionID);
                cmbDebtors.SelectedIndex = 0;
                if (complaints.DebitorList.Rows.Count == 0)
                {
                    MessageBox.Show("Не удалось загрузить ни одного дебитора!", "Ошибка при загрузке данных",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить ни одного дебитора: " + exc.Message, "Ошибка при загрузке данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ

        /// <summary>
        /// Сохранение введенных данных и закрытие окна с "положительным ответом"
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
