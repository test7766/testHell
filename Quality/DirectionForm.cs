using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

using WMSOffice.Properties;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для создания направления
    /// </summary>
    public partial class DirectionForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ ОКНА

        public DirectionForm(long pSessionID)
        {
            InitializeComponent();
            clReIsRepeatedLot.DefaultCellStyle.NullValue = null;
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка необходимых данных во время загрузки окна
        /// </summary>
        private void DirectionForm_Load(object sender, EventArgs e)
        {
            LoadLocations();
            SetOperationsAccess();
        }

        /// <summary>
        /// Загрузка доступных лабораторий, в которые можно создать направление
        /// </summary>
        private void LoadLocations()
        {
            try
            {
                taLocations.Fill(quality.Locations);
                if (cmbLocations.Items.Count > 0)
                    cmbLocations.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время получения списка доступных лабораторий:", exc);
            }
        }

        #endregion

        #region ЗАГРУЗКА СТРОК ЗАЯВКИ (ПО ВВЕДЕННОМУ НОМЕРУ ЗАЯВКИ)

        /// <summary>
        /// True если после последней загрузки строк заявки были введены изменения в текстовое поле номера заявки
        /// </summary>
        private bool wasChangesMade;

        /// <summary>
        /// Как только вводится значение в текстовое поле номера заявки - запускаем таймер и через 800мс обновляем строки заявки
        /// </summary>
        private void tbxRequestNumber_TextChanged(object sender, EventArgs e)
        {
            wasChangesMade = true;
            tmrRequestNumber.Stop();
            tmrRequestNumber.Start();
        }

        /// <summary>
        /// По нажатию на кнопку "Enter" на клавиатуре обновляем таблицу строк заявки сразу
        /// </summary>
        private void tbxRequestNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && wasChangesMade)
            {
                tmrRequestNumber.Stop();
                LoadRequestDetails();
            }
        }

        /// <summary>
        /// Попытка загрузить строки по введенному номеру заявки
        /// </summary>
        private void LoadRequestDetails()
        {
            try
            {
                wasChangesMade = false;
                long rn;
                quality.DRDocRows.Clear();
                if (String.IsNullOrEmpty(tbxRequestNumber.Text))
                    quality.DocDetails.Clear();
                else if (Int64.TryParse(tbxRequestNumber.Text, out rn))
                    taQkDocsDetailForDirection.Fill(quality.QK_Docs_Detail_For_Direction, sessionID, rn);
                else
                    MessageBox.Show("Номер заяви повинен бути цілим числом!", "Завантаження рядків заяви", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetRepeatedLotIcon();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки строк заявки:", exc);
            }
        }

        /// <summary>
        /// Установка иконок для строк, которые являются "Повторными сериями"
        /// </summary>
        private void SetRepeatedLotIcon()
        {
            foreach (DataGridViewRow itemRow in dgvRequestDetails.Rows)
            {
                var dbrow = (itemRow.DataBoundItem as DataRowView).Row as Data.Quality.QK_Docs_Detail_For_DirectionRow;
                if (!dbrow.IsControl_ReadyNull() && dbrow.Control_Ready)
                    itemRow.Cells[clReIsRepeatedLot.Index].Value = Resources.repeat;
            }
        }

        /// <summary>
        /// Через 800мс после окончания редактирования номера заявки, загружаем строки заявки
        /// </summary>
        private void tmrRequestNumber_Tick(object sender, EventArgs e)
        {
            tmrRequestNumber.Stop();
            LoadRequestDetails();
        }

        /// <summary>
        /// Обновление фильтра в зависимости от флажка "Отображать повторные серии"
        /// </summary>
        private void chbShowRepeatedLots_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowRepeatedLots.Checked)
            {
                bsDocDetailForDirection.Filter = "[Is_Hidden] = False";
                SetRepeatedLotIcon();
            }
            else
                bsDocDetailForDirection.Filter = "[Is_Hidden] = False AND [Control_Ready] = False";
        }

        #endregion

        #region НАПОЛНЕНИЕ ТАБЛИЦЫ СТРОК НАПРАВЛЕНИЯ

        /// <summary>
        /// Настройка доступности кнопок для "перекидывания" строк в зависимости от выбранных строк в таблицах
        /// </summary>
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            SetOperationsAccess();
        }

        private void SetOperationsAccess()
        {
            btnAddItems.Enabled = dgvRequestDetails.SelectedRows.Count > 0;
            btnRemoveItems.Enabled = miSetQuantity.Enabled = dgvDirectionDetails.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Закидывание выделенных строк заявки в направление
        /// </summary>
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvrow in dgvRequestDetails.SelectedRows)
            {
                var dbrow = (dgvrow.DataBoundItem as DataRowView).Row as Data.Quality.QK_Docs_Detail_For_DirectionRow;
                var newrow = quality.DRDocRows.NewDRDocRowsRow();
                newrow.Doc_ID = -1;
                newrow.Doc_Date = DateTime.Now;
                newrow.Item_ID = dbrow.Item_ID;
                newrow.ItemName = dbrow.Item_Name;
                newrow.Line_ID = dbrow.Line_ID;
                newrow.Manufacturer = dbrow.Manufacturer;
                newrow.Mode = dbrow.Mode;
                newrow.Quantity = 1;
                newrow.VendorLot = dbrow.Vendor_Lot;
                newrow.Has_Items_Table = newrow.Has_Docs_Ready = false;
                quality.DRDocRows.AddDRDocRowsRow(newrow);
                dbrow.Is_Hidden = true;
            }
            dgvRequestDetails.Refresh();
        }

        /// <summary>
        /// Удаление выделенных строк направления из направления
        /// </summary>
        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvrow in dgvDirectionDetails.SelectedRows)
            {
                var dbrow = (dgvrow.DataBoundItem as DataRowView).Row as Data.Quality.DRDocRowsRow;
                foreach (Data.Quality.QK_Docs_Detail_For_DirectionRow row in quality.QK_Docs_Detail_For_Direction)
                    if (row.Line_ID == dbrow.Line_ID)
                    {
                        row.Is_Hidden = false;
                        break;
                    }
                dbrow.Delete();
            }
            dgvRequestDetails.Refresh();
        }

        /// <summary>
        /// Изменение количества товара в выделенной строке по двойному щелчку на строке
        /// </summary>
        private void dgvDirectionDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangeQuantity();
        }

        /// <summary>
        /// Изменение количества товара в направлении в выделенных строках
        /// </summary>
        private void ChangeQuantity()
        {
            int? quantity = GetCommonQuantityForSelectedRows();
            var quantityForm = new SetQuantityForm(1, 1000) { Owner = this };
            if (quantity.HasValue)
                quantityForm.Quantity = quantity.Value;
            if (quantityForm.ShowDialog() == DialogResult.OK)
                foreach (DataGridViewRow dgvrow in dgvDirectionDetails.SelectedRows)
                {
                    var dbRow = (dgvrow.DataBoundItem as DataRowView).Row as Data.Quality.DRDocRowsRow;
                    dbRow.Quantity = quantityForm.Quantity;
                }
        }

        /// <summary>
        /// Получение количества по выделенным строкам направления 
        /// </summary>
        /// <returns>Количество товара, если выделена одна строка либо для всех выделенных строк количество одинаковое.
        /// Null если выделено несколько строк с разным количеством</returns>
        private int? GetCommonQuantityForSelectedRows()
        {
            int? quantity = (int)((dgvDirectionDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.DRDocRowsRow).Quantity;
            for (int i = 1; i < dgvDirectionDetails.SelectedRows.Count; i++)
            {
                var dbrow = (dgvDirectionDetails.SelectedRows[i].DataBoundItem as DataRowView).Row as Data.Quality.DRDocRowsRow;
                if ((int)dbrow.Quantity != quantity)
                    return null;
            }

            return quantity;
        }

        /// <summary>
        /// Изменение количества товара в выделенных строках по нажатию на кнопку
        /// </summary>
        private void miSetQuantity_Click(object sender, EventArgs e)
        {
            ChangeQuantity();
        }

        #endregion

        #region ПРОВЕРКА ДАННЫХ НА КОРРЕКТНОСТЬ И ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// Проверка данных на корректность и закрытие окна по нажатию на кнопку ОК
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                SaveDirection();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True если данные введены правильно, False в противном случае</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;
            if (String.IsNullOrEmpty(tbxNumber.Text))
                msg = "Необхідно ввести номер направлення!";
            else if (dgvDirectionDetails.RowCount == 0)
                msg = "Необхідно додати хоча б один рядок у направлення!";
            else if (cmbLocations.SelectedItem == null)
                msg = "Необхідно обрати лабораторію, в якій буде проведено аналіз!";
            else if (!chbLabAnalysis.Checked && !chbAuthImplement.Checked)
                msg = "Необхідно обрати тип направлення";
            else if (chbChangeScan.Checked && String.IsNullOrEmpty(tbxFilePath.Text))
                msg = "Необхідно вкласти скан-копію направлення";
            else if (chbChangeScan.Checked && (new FileInfo(tbxFilePath.Text)).Length / 1024 > ERROR_FILE_SIZE)
                msg = String.Format("Файл занадто великий! Максимальный розмір файла - {0} Мб", ERROR_FILE_SIZE / 1024 / 1024);

            if (String.IsNullOrEmpty(msg))
                return true;
            else
            {
                Logger.ShowErrorMessageBox(msg);
                return false;
            }
        }

        /// <summary>
        /// Сохранение направления
        /// </summary>
        private void SaveDirection()
        {
            try
            {
                int id = Convert.ToInt32(taDrDocs.CreateDRDoc(sessionID, dtpDateFrom.Value, tbxNumber.Text,
                    Convert.ToInt32(cmbLocations.SelectedValue), dtpDateReceipt.Value, ScanData, ScanName, chbLabAnalysis.Checked, chbAuthImplement.Checked));
                foreach (DataGridViewRow dgvrow in dgvDirectionDetails.Rows)
                {
                    var dbrow = (dgvrow.DataBoundItem as DataRowView).Row as Data.Quality.DRDocRowsRow;
                    taDrDocRows.AddRow(id, Convert.ToInt32(tbxRequestNumber.Text), dbrow.Line_ID, dbrow.Quantity, sessionID);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время сохранения направления в БД:", exc);
            }
        }

        #endregion

        #region РАБОТА СО СКАНОМ НАПРАВЛЕНИЯ

        /// <summary>
        /// Критичный размер прикрепленного файла, при котором пользователю будет отображена ошибка (10 МБ).
        /// </summary>
        private const long ERROR_FILE_SIZE = 10485760;

        /// <summary>
        /// Скан направления, который нужно сохранить в БД
        /// </summary>
        private byte[] ScanData
        {
            get
            {
                if (chbChangeScan.Checked)
                    return File.ReadAllBytes(tbxFilePath.Text);
                else
                    return null;
            }
        }

        /// <summary>
        /// Название файла со сканом направления, который нужно сохранить в БД
        /// </summary>
        private string ScanName { get { return chbChangeScan.Checked ? tbxFilePath.Text : null; } }

        /// <summary>
        /// Выбор нового файла для вложения
        /// </summary>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbxFilePath.Text))
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(tbxFilePath.Text);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    tbxFilePath.Text = openFileDialog.FileName;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(String.Format("Во время открытия файла {0} произошла ошибка: ",
                    tbxFilePath.Text), exc);
            }
        }

        /// <summary>
        /// Настройка доступности контролов изменения скана направления в зависимости от отмеченности соответствующего флажка
        /// </summary>
        private void chbChangeScan_CheckedChanged(object sender, EventArgs e)
        {
            tbxFilePath.Enabled = btnOpenFile.Enabled = chbChangeScan.Checked;
        }

        #endregion

        private void chbLabAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLabAnalysis.Checked)
                chbAuthImplement.Checked = false;
        }

        private void chbAuthImplement_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAuthImplement.Checked)
                chbLabAnalysis.Checked = false;
        }
    }
}
