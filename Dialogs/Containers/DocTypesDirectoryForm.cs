using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Containers
{
    /// <summary>
    /// Справочник площадок печати
    /// </summary>
    public partial class DocTypesDirectoryForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public DocTypesDirectoryForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка данных в таблицу типов документов
        /// </summary>
        private void DocTypesDirectoryForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                taPrDocTypes.Fill(containers.PrDocTypes, sessionID);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить типы печатаемых документов: " + Environment.NewLine + exc.Message, "Ошибка",
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
        /// Вставка нового типа документа в БД
        /// </summary>
        /// <param name="pRowIndex">Индекс добавленной строки в таблице типов документов</param>
        private void InsertNewDocType(int pRowIndex)
        {
            try
            {
                dgvDocTypes.Rows[pRowIndex].Cells["id"].Value = taPrDocTypes.InsertDocType(
                    dgvDocTypes.Rows[pRowIndex].Cells["name"].Value.ToString(),
                    dgvDocTypes.Rows[pRowIndex].Cells["desc"].Value.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при вставке нового типа документа в БД: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDocTypes.Rows.Remove(dgvDocTypes.Rows[pRowIndex]);
            }
        }

        /// <summary>
        /// Редактирование типа документа в БД
        /// </summary>
        /// <param name="pRowIndex">Индекс строки, которая редактировалась</param>
        private void EditDocType(int pRowIndex)
        {
            try
            {
                taPrDocTypes.UpdateDocType(Convert.ToInt32(dgvDocTypes.Rows[pRowIndex].Cells["id"].Value),
                    dgvDocTypes.Rows[pRowIndex].Cells["name"].Value.ToString(),
                    dgvDocTypes.Rows[pRowIndex].Cells["desc"].Value.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при редактировании печатаемого типа документа в БД: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDocTypes.Rows[pRowIndex].Cells["name"].Value = valuesBeforeEdit[0];
                dgvDocTypes.Rows[pRowIndex].Cells["desc"].Value = valuesBeforeEdit[1];
            }
        }

        /// <summary>
        /// "Запоминание полей до редактирования, чтобы можно было вернуться к этим полям, если редактирование не удалось"
        /// </summary>
        private void dgvDocTypes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocTypes.Rows[e.RowIndex].Cells["id"].Value == null ||
                dgvDocTypes.Rows[e.RowIndex].Cells["id"].Value == DBNull.Value)
                return;

            valuesBeforeEdit[0] = dgvDocTypes.Rows[e.RowIndex].Cells["name"].Value.ToString();
            valuesBeforeEdit[1] = dgvDocTypes.Rows[e.RowIndex].Cells["desc"].Value.ToString();
        }

        /// <summary>
        /// Попытка удаления типа документа
        /// </summary>
        private void dgvDocTypes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                taPrDocTypes.DeleteDocType(Convert.ToInt32(e.Row.Cells["id"].Value));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при удалении типа документа: " + Environment.NewLine + exc.Message,
                    "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Проверка правильности заполнения справочника
        /// </summary>
        private void dgvDocTypes_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvDocTypes.IsCurrentRowDirty)
                return;

            if (dgvDocTypes.Rows[e.RowIndex].Cells["name"].Value == null ||
                dgvDocTypes.Rows[e.RowIndex].Cells["name"].Value == DBNull.Value)
            {
                MessageBox.Show("Должно быть задано название типа документа!", "Редактирование справочника", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToInt32(dgvDocTypes.Rows[e.RowIndex].Cells["id"].Value) < 0)
                    InsertNewDocType(e.RowIndex);
                else
                    EditDocType(e.RowIndex);
            }
        }

        #endregion        
    }
}
