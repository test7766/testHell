using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Containers
{
    public partial class IpDirectoryForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public IpDirectoryForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка данных для таблицы IP-адресов, а также выпадающих списков площадок, типов документов и пользователей
        /// </summary>
        private void IpDirectoryForm_Load(object sender, EventArgs e)
        {
            LoadDocTypes();
            LoadPlacements();
            LoadUsers();
            LoadIps();
        }

        /// <summary>
        /// Загрузка типов печатаемых документов для справочника IP-адресов
        /// </summary>
        private void LoadDocTypes()
        {
            try
            {
                taDocTypesForIps.Fill(containers.DocTypesForIps);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить типы печатаемых документов для справочника IP-адресов: " +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Загрузка площадок для справочника IP-адресов
        /// </summary>
        private void LoadPlacements()
        {
            try
            {
                taPlacementsForIps.Fill(containers.PlacementsForIps);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить площадки для справочника IP-адресов: " +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Загрузка пользователей для справочника IP-адресов
        /// </summary>
        private void LoadUsers()
        {
            try
            {
                taUsersForIps.Fill(containers.WmsUsersForIps);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить пользователей для справочника IP-адресов: " +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Загрузка IP-адресов
        /// </summary>
        private void LoadIps()
        {
            try
            {
                taIps.Fill(containers.Ips, sessionID);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить IP-адреса: " +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ СПРАВОЧНИКА

        /// <summary>
        /// Значения редактируемой колонки перед редактированием
        /// </summary>
        private string[] valuesBeforeEdit = new string[4];

        /// <summary>
        /// Вставка нового IP-адреса в БД
        /// </summary>
        /// <param name="pRowIndex">Индекс добавленной строки в таблице типов документов</param>
        private void InsertNewIP(int pRowIndex)
        {
            try
            {
                dgvIps.Rows[pRowIndex].Cells["id"].Value = taIps.InsertIp(
                    dgvIps.Rows[pRowIndex].Cells["ip"].Value.ToString(),
                    Convert.ToInt32(dgvIps.Rows[pRowIndex].Cells["placement_id"].Value),
                    Convert.ToInt32(dgvIps.Rows[pRowIndex].Cells["doc_type_id"].Value),
                    Convert.ToInt32(dgvIps.Rows[pRowIndex].Cells["user_id"].Value));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при вставке нового IP-адреса в БД: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvIps.Rows.Remove(dgvIps.Rows[pRowIndex]);
            }
        }

        /// <summary>
        /// Редактирование IP-адреса в БД
        /// </summary>
        /// <param name="pRowIndex">Индекс строки, которая редактировалась</param>
        private void EditIP(int pRowIndex)
        {
            try
            {
                taIps.UpdateIp(Convert.ToInt32(dgvIps.Rows[pRowIndex].Cells["id"].Value),
                    dgvIps.Rows[pRowIndex].Cells["ip"].Value.ToString(),
                    Convert.ToInt32(dgvIps.Rows[pRowIndex].Cells["placement_id"].Value),
                    Convert.ToInt32(dgvIps.Rows[pRowIndex].Cells["doc_type_id"].Value),
                    Convert.ToInt32(dgvIps.Rows[pRowIndex].Cells["user_id"].Value));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при редактировании IP-адреса в БД: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvIps.Rows[pRowIndex].Cells["ip"].Value = valuesBeforeEdit[0];
                dgvIps.Rows[pRowIndex].Cells["desc"].Value = valuesBeforeEdit[1];
                dgvIps.Rows[pRowIndex].Cells["desc"].Value = valuesBeforeEdit[1];
                dgvIps.Rows[pRowIndex].Cells["desc"].Value = valuesBeforeEdit[1];
            }
        }

        /// <summary>
        /// "Запоминание полей до редактирования, чтобы можно было вернуться к этим полям, если редактирование не удалось"
        /// </summary>
        private void dgvIps_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIps.Rows[e.RowIndex].Cells["id"].Value == null ||
                dgvIps.Rows[e.RowIndex].Cells["id"].Value == DBNull.Value)
                return;

            valuesBeforeEdit[0] = dgvIps.Rows[e.RowIndex].Cells["ip"].Value.ToString();
            valuesBeforeEdit[1] = dgvIps.Rows[e.RowIndex].Cells["placement_id"].Value.ToString();
            valuesBeforeEdit[2] = dgvIps.Rows[e.RowIndex].Cells["doc_type_id"].Value.ToString();
            valuesBeforeEdit[3] = dgvIps.Rows[e.RowIndex].Cells["user_id"].Value.ToString();
        }

        /// <summary>
        /// Попытка удаления IP-адреса
        /// </summary>
        private void dgvIps_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить данный IP-адрес из БД?", "Редактирование справочника",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    taIps.DeleteIp(Convert.ToInt32(e.Row.Cells["id"].Value));
                else
                    e.Cancel = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при удалении IP-адреса: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Проверка правильности заполнения справочника
        /// </summary>
        private void dgvIps_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvIps.IsCurrentRowDirty)
                return;

            if (dgvIps.Rows[e.RowIndex].Cells["ip"].Value == null ||
                dgvIps.Rows[e.RowIndex].Cells["ip"].Value == DBNull.Value)
            {
                MessageBox.Show("Должен быть задан IP-адрес!", "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (Convert.ToInt32(dgvIps.Rows[e.RowIndex].Cells["placement_id"].Value) != -1 &&
                        Convert.ToInt32(dgvIps.Rows[e.RowIndex].Cells["doc_type_id"].Value) == -1)
            {
                MessageBox.Show("Если задана площадка, обязательно должен быть задан тип печатаемых документов!",
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (Convert.ToInt32(dgvIps.Rows[e.RowIndex].Cells["doc_type_id"].Value) != -1 &&
                        Convert.ToInt32(dgvIps.Rows[e.RowIndex].Cells["placement_id"].Value) == -1)
            {
                MessageBox.Show("Для того, чтобы задать тип печатаемых документов, нужно обязательно задать площадку!",
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToInt32(dgvIps.Rows[e.RowIndex].Cells["id"].Value) < 0)
                    InsertNewIP(e.RowIndex);
                else
                    EditIP(e.RowIndex);
            }
        }

        #endregion        
    }
}
