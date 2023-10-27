using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Containers
{
    /// <summary>
    /// Справочник площадок печати
    /// </summary>
    public partial class ZonesDirectoryForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public ZonesDirectoryForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка данных в таблицу площадок
        /// </summary>
        private void ZonesDirectoryForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                taPlacements.Fill(containers.Placements, sessionID);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить площадки: " + Environment.NewLine + exc.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ СПРАВОЧНИКА

        /// <summary>
        /// Значения редактируемой колонки перед редактированием
        /// </summary>
        private string[] valuesBeforeEdit = new string[5];

        /// <summary>
        /// Вставка новой площадки в БД
        /// </summary>
        /// <param name="pRowIndex">Индекс добавленной строки в таблице площадок</param>
        private void InsertNewPlacement(int pRowIndex)
        {
            try
            {
                dgvPlacements.Rows[pRowIndex].Cells["id"].Value = taPlacements.InsertPlacement(
                    dgvPlacements.Rows[pRowIndex].Cells["region"].Value.ToString(),
                    dgvPlacements.Rows[pRowIndex].Cells["zone"].Value.ToString(),
                    Convert.ToInt32(dgvPlacements.Rows[pRowIndex].Cells["floor"].Value),
                    dgvPlacements.Rows[pRowIndex].Cells["dept"].Value.ToString(),
                    dgvPlacements.Rows[pRowIndex].Cells["cab"].Value.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при вставке новой площадки в БД: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPlacements.Rows.Remove(dgvPlacements.Rows[pRowIndex]);
            }
        }

        /// <summary>
        /// Редактирование площадки в БД
        /// </summary>
        /// <param name="pRowIndex">Индекс строки, которая редактировалась</param>
        private void EditPlacement(int pRowIndex)
        {
            try
            {
                taPlacements.UpdatePlacement(Convert.ToInt32(dgvPlacements.Rows[pRowIndex].Cells["id"].Value),
                    dgvPlacements.Rows[pRowIndex].Cells["region"].Value.ToString(),
                    dgvPlacements.Rows[pRowIndex].Cells["zone"].Value.ToString(),
                    Convert.ToInt32(dgvPlacements.Rows[pRowIndex].Cells["floor"].Value),
                    dgvPlacements.Rows[pRowIndex].Cells["dept"].Value.ToString(),
                    dgvPlacements.Rows[pRowIndex].Cells["cab"].Value.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при редактировании площадки в БД: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPlacements.Rows[pRowIndex].Cells["region"].Value = valuesBeforeEdit[0];
                dgvPlacements.Rows[pRowIndex].Cells["zone"].Value = valuesBeforeEdit[1];
                dgvPlacements.Rows[pRowIndex].Cells["floor"].Value = valuesBeforeEdit[2];
                dgvPlacements.Rows[pRowIndex].Cells["dept"].Value = valuesBeforeEdit[3];
                dgvPlacements.Rows[pRowIndex].Cells["cab"].Value = valuesBeforeEdit[4];
            }
        }

        /// <summary>
        /// "Запоминание полей до редактирования, чтобы можно было вернуться к этим полям, если редактирование не удалось"
        /// </summary>
        private void dgvPlacements_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlacements.Rows[e.RowIndex].Cells["id"].Value == null ||
                dgvPlacements.Rows[e.RowIndex].Cells["id"].Value == DBNull.Value)
                return;

            valuesBeforeEdit[0] = dgvPlacements.Rows[e.RowIndex].Cells["region"].Value.ToString();
            valuesBeforeEdit[1] = dgvPlacements.Rows[e.RowIndex].Cells["zone"].Value.ToString();
            valuesBeforeEdit[2] = dgvPlacements.Rows[e.RowIndex].Cells["floor"].Value.ToString();
            valuesBeforeEdit[3] = dgvPlacements.Rows[e.RowIndex].Cells["dept"].Value.ToString();
            valuesBeforeEdit[4] = dgvPlacements.Rows[e.RowIndex].Cells["cab"].Value.ToString();
        }

        /// <summary>
        /// Попытка удаления площадки
        /// </summary>
        private void dgvPlacements_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                taPlacements.DeletePlacement(Convert.ToInt32(e.Row.Cells["id"].Value));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при удалении площадки: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Проверка правильности заполнения справочника
        /// </summary>
        private void dgvPlacements_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvPlacements.IsCurrentRowDirty)
                return;

            if (dgvPlacements.Rows[e.RowIndex].Cells["region"].Value == null ||
                dgvPlacements.Rows[e.RowIndex].Cells["region"].Value == DBNull.Value)
            {
                MessageBox.Show("Филиал должен быть задан!", "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (dgvPlacements.Rows[e.RowIndex].Cells["zone"].Value == null ||
                dgvPlacements.Rows[e.RowIndex].Cells["zone"].Value == DBNull.Value)
            {
                MessageBox.Show("Зона должна быть задана!", "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (dgvPlacements.Rows[e.RowIndex].Cells["floor"].Value == null ||
                dgvPlacements.Rows[e.RowIndex].Cells["floor"].Value == DBNull.Value)
            {
                MessageBox.Show("Этаж должен быть задан!", "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (dgvPlacements.Rows[e.RowIndex].Cells["dept"].Value == null ||
                dgvPlacements.Rows[e.RowIndex].Cells["dept"].Value == DBNull.Value)
            {
                MessageBox.Show("Отдел должен быть задан!", "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            // [WMS-4424]
            //else if (dgvPlacements.Rows[e.RowIndex].Cells["cab"].Value == null ||
            //    dgvPlacements.Rows[e.RowIndex].Cells["cab"].Value == DBNull.Value)
            //{
            //    MessageBox.Show("Кабинет должен быть задан!", "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    e.Cancel = true;
            //}
            else
            {
                if (Convert.ToInt32(dgvPlacements.Rows[e.RowIndex].Cells["id"].Value) < 0)
                    InsertNewPlacement(e.RowIndex);
                else
                    EditPlacement(e.RowIndex);
            }
        }

        #endregion        
    }
}
