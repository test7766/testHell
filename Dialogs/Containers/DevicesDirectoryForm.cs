using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Containers
{
    public partial class DevicesDirectoryForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public DevicesDirectoryForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка данных в таблицу типов документов
        /// </summary>
        private void DevicesDirectoryForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                taDevices.Fill(containers.Devices);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить список устройств: " + Environment.NewLine + exc.Message, "Загрузка справочника",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ СПРАВОЧНИКА

        /// <summary>
        /// Значения редактируемой колонки перед редактированием
        /// </summary>
        private string[] valuesBeforeEdit = new string[2];

        /// <summary>
        /// Редактирование устройства в БД
        /// </summary>
        /// <param name="pRowIndex">Индекс строки, которая редактировалась</param>
        private void EditDevice(int pRowIndex)
        {
            try
            {
                taDevices.UpdateDevice(Convert.ToInt32(dgvDevices.Rows[pRowIndex].Cells["id"].Value),
                    dgvDevices.Rows[pRowIndex].Cells["name"].Value.ToString(),
                    dgvDevices.Rows[pRowIndex].Cells["inventory_id"].Value.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при редактировании устройства в БД: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDevices.Rows[pRowIndex].Cells["name"].Value = valuesBeforeEdit[0];
                dgvDevices.Rows[pRowIndex].Cells["inventory_id"].Value = valuesBeforeEdit[1];
            }
        }

        /// <summary>
        /// "Запоминание полей до редактирования, чтобы можно было вернуться к этим полям, если редактирование не удалось"
        /// </summary>
        private void dgvDevices_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDevices.Rows[e.RowIndex].Cells["id"].Value == null ||
                dgvDevices.Rows[e.RowIndex].Cells["id"].Value == DBNull.Value)
                return;

            valuesBeforeEdit[0] = dgvDevices.Rows[e.RowIndex].Cells["name"].Value.ToString();
            valuesBeforeEdit[1] = dgvDevices.Rows[e.RowIndex].Cells["inventory_id"].Value.ToString();
        }

        /// <summary>
        /// Редактирование справочника
        /// </summary>
        private void dgvDevices_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvDevices.IsCurrentRowDirty)
                return;
            EditDevice(e.RowIndex);
        }

        #endregion        
    }
}
