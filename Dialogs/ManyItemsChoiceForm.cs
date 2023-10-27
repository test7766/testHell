using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs
{
    /// <summary>
    /// Форма для выбора элементов, которая допускает также одиночный выбор
    /// </summary>
    public partial class ManyItemsChoiceForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Режим запуска окна выбора элементов
        /// </summary>
        private readonly ItemsChoiceMode mode;

        /// <summary>
        /// Таблица с данными, отображаемая в окне
        /// </summary>
        private readonly DataTable itemsTable;

        /// <summary>
        /// Название свойства таблицы с булевским значением выбора (к которому биндится CHECKBOX-колонка)
        /// </summary>
        private string CHECKED_COL_NAME = "CheckedColumn";

        /// <summary>
        /// Словарь, который содержит ключами - названия DataTable-полей, которые нужно отобразить в таблице,
        /// а значениями - названия соответствующих колонок. Если не задавать этот словарь, то будут отображаться все колонки таблицы
        /// с заголовками, которые соответствуют названиям DataTable-полей
        /// </summary>
        private readonly Dictionary<string, string> columnTitles;

        /// <summary>
        /// Название таблицы в конфиг-файле для сохранения/загрузки параметров колонок
        /// </summary>
        public string ConfigName { get; set; }

        /// <summary>
        /// Коллекция с выбранными в таблице строками (для режима множественного выбора)
        /// </summary>
        public List<DataRow> CheckedRows
        {
            get
            {
                if (mode == ItemsChoiceMode.Single)
                    throw new InvalidOperationException("Использование этого свойства возможно только в режиме множественного выбора!");

                var result = new List<DataRow>();
                foreach (DataRow row in itemsTable.Rows)
                    if (Convert.ToBoolean(row[CHECKED_COL_NAME]))
                        result.Add(row);
                return result;
            }
        }

        /// <summary>
        /// Выбранная строка в таблице (для режима одиночного выбора)
        /// </summary>
        public DataRow SelectedRow
        {
            get
            {
                if (mode == ItemsChoiceMode.Multiple)
                    throw new InvalidOperationException("Использование этого свойства возможно только в режиме одиночного выбора!");

                if (dgvItems.SelectedRows.Count == 0)
                    return null;
                else
                    return (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row;
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ManyItemsChoiceForm(DataTable pItems, Dictionary<string, string> pColumnTitles, ItemsChoiceMode pMode)
        {
            if (pItems == null)
                throw new ArgumentNullException("Таблица с данными не может быть равна NULL!");

            InitializeComponent();
            itemsTable = pItems;
            columnTitles = pColumnTitles;
            mode = pMode;
        }

        public ManyItemsChoiceForm(DataTable pItems, ItemsChoiceMode pMode) 
            : this(pItems, (Dictionary<string, string>)null, pMode) { }

        public ManyItemsChoiceForm(DataTable pItems, string[] pColumnTitles, ItemsChoiceMode pMode)
        {
            if (pItems == null)
                throw new ArgumentNullException("Таблица с данными не может быть равна NULL!");
            else if (pColumnTitles == null)
                throw new ArgumentNullException("Массив заголовков не может быть равен NULL!");
            else if (pItems.Columns.Count != pColumnTitles.Length)
                throw new ArgumentException("Количество элементов в массиве заголовков не равно количеству колонок в таблице!");
            InitializeComponent();
            itemsTable = pItems;
            mode = pMode;

            columnTitles = new Dictionary<string, string>();
            for (int i = 0; i < pItems.Columns.Count; i++)
                columnTitles.Add(pItems.Columns[i].ColumnName, pColumnTitles[i]);
        }

        /// <summary>
        /// Инициализация таблицы с элементами, отображаемая в окне
        /// </summary>
        private void ManyItemsChoiceForm_Load(object sender, EventArgs e)
        {
            if (mode == ItemsChoiceMode.Multiple)
                CustomCheckedColumn();
            else
                dgvItems.Columns.Remove(clChecked);

            AddColumnsForDataTable();
            bsItems.DataSource = itemsTable;
            DataGridViewHelper.AutoSetColumnWidths(dgvItems);
            tbxFilter.Focus();
        }

        /// <summary>
        /// Настройка колонки с чекбоксом для множественного выбора товаров
        /// </summary>
        private void CustomCheckedColumn()
        {
            // Настройка колонки в DataTable
            var column = new DataColumn(CHECKED_COL_NAME, typeof(Boolean))
            {
                DefaultValue = false,
                AllowDBNull = false
            };
            itemsTable.Columns.Add(column);

            // Настройка колонки в DataGridView
            clChecked.DataPropertyName = CHECKED_COL_NAME;
            clChecked.SortMode = DataGridViewColumnSortMode.NotSortable;
            CustomCheckHeader();
        }

        /// <summary>
        /// Настройка заголовка для CheckBox-колонки тоже в виде CheckBox-а
        /// </summary>
        private void CustomCheckHeader()
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += checkHeaderCell_OnCheckBoxClicked;
            checkHeaderCell.Value = String.Empty;
            clChecked.HeaderCell = checkHeaderCell;
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void checkHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
                (row.DataBoundItem as DataRowView).Row[CHECKED_COL_NAME] = pState;

            dgvItems.RefreshEdit();
            bsItems.ResetBindings(false);

            foreach (DataGridViewRow row in dgvItems.Rows)
                PaintRow(row);
        }

        /// <summary>
        /// Добавление колонок для заданной таблицы
        /// </summary>
        private void AddColumnsForDataTable()
        {
            foreach (DataColumn column in itemsTable.Columns)
            {
                string cName = column.ColumnName;   // Название текущей DataTable-колонки
                if (cName != CHECKED_COL_NAME)  // Колонка Checked уже добавлена
                {
                    if (columnTitles == null || columnTitles.ContainsKey(cName))
                    {
                        var dgvCol = new DataGridViewTextBoxColumn();
                        dgvCol.ReadOnly = true;
                        dgvCol.DataPropertyName = dgvCol.Name = cName;
                        dgvCol.HeaderText = columnTitles == null ? cName : columnTitles[cName];
                        dgvItems.Columns.Add(dgvCol);
                    }
                }
            }

            SetColumnsInitialOrder();
        }

        /// <summary>
        /// Установка начального порядка колонок
        /// </summary>
        private void SetColumnsInitialOrder()
        {
            if (columnTitles != null)
                for (int i = 0; i < columnTitles.Count; i++)
                    foreach (DataGridViewColumn col in dgvItems.Columns)
                        col.DisplayIndex = i + (mode == ItemsChoiceMode.Single ? 0 : 1);
        }

        /// <summary>
        /// Установка ширин колонок автоопределяемыми значениями
        /// </summary>
        private void SetColumnSizes()
        {
            // Автоопределение ширины колонок
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewColumn col in dgvItems.Columns)
                if (col != clChecked)
                    col.Tag = col.Width;

            // Установка определенных значений ширинам, и разрешение редактировать ширину колонок
            foreach (DataGridViewColumn col in dgvItems.Columns)
                if (col != clChecked)
                    col.Width = Convert.ToInt32(col.Tag);
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        /// <summary>
        /// Загрузка из конфига сохраненных параметров колонок
        /// </summary>
        private void ManyItemsChoiceForm_Shown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConfigName))
                Config.LoadDataGridViewSettings(ConfigName, dgvItems);
        }

        /// <summary>
        /// Горячие клавиши на таблице
        /// </summary>
        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (mode == ItemsChoiceMode.Multiple && dgvItems.SelectedRows.Count > 0)
                if ((int)e.KeyCode == 107)  // Знак "+"
                {
                    (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row[CHECKED_COL_NAME] = true;
                    PaintRow(dgvItems.SelectedRows[0]);
                }
                else if ((int)e.KeyCode == 109) // Знак "-"
                {
                    (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row[CHECKED_COL_NAME] = false;
                    PaintRow(dgvItems.SelectedRows[0]);
                }
        }

        #endregion

        #region ОКРАШИВАНИЕ ВЫБРАННЫХ СТРОК ТАБЛИЦЫ

        /// <summary>
        /// Окрашивание строки, если поставили/убрали флажок
        /// </summary>
        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clChecked.Index && mode == ItemsChoiceMode.Multiple)
                PaintRow(dgvItems.Rows[e.RowIndex]);
        }

        /// <summary>
        /// Окрашивание строки таблицы в зависимости от того, отмечена она флажком или нет
        /// </summary>
        /// <param name="pRow">Строка, которую нужно раскрасить</param>
        private void PaintRow(DataGridViewRow pRow)
        {
            bool ch = Convert.ToBoolean(pRow.Cells[clChecked.Index].EditedFormattedValue);
            foreach (DataGridViewCell cell in pRow.Cells)
                cell.Style.BackColor = cell.Style.SelectionForeColor = ch ? Color.LightGreen : Color.White;
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ЭЛЕМЕНТОВ

        /// <summary>
        /// Строка фильтра
        /// </summary>
        private string filter;

        /// <summary>
        /// Шаблон, по которому применяется фильтр
        /// </summary>
        public string FilterPattern { get; set; }

        /// <summary>
        /// Применение фильтра при окончании работы таймера
        /// </summary>
        private void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            RefreshFilter();
        }

        /// <summary>
        /// Обновление фильтров на таблице
        /// </summary>
        private void RefreshFilter()
        {
            try
            {
                if (String.IsNullOrEmpty(filter) || String.IsNullOrEmpty(FilterPattern))
                    bsItems.Filter = String.Empty;
                else
                    bsItems.Filter = String.Format(FilterPattern, filter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
        }

        /// <summary>
        /// Изменение фильтра
        /// </summary>
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            filter = tbxFilter.Text;
            delayTimer.Stop();
            delayTimer.Start();
        }

        /// <summary>
        /// Запуск фильтрации по нажатию на кнопку Enter
        /// </summary>
        private void tbxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshFilter();
        }

        /// <summary>
        /// Добавление горячих клавиш
        /// </summary>
        private void ManyItemsChoiceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
                tbxFilter.Focus();
            else if (e.KeyCode == Keys.Enter && e.Control)
                btnOK_Click(btnOK, EventArgs.Empty);
            else if ((int)e.KeyCode == 107 && e.Control && mode == ItemsChoiceMode.Multiple)    // Знак "+"
                checkHeaderCell_OnCheckBoxClicked(true);
            else if ((int)e.KeyCode == 109 && e.Control && mode == ItemsChoiceMode.Multiple)    // Знак "-"
                checkHeaderCell_OnCheckBoxClicked(false);
        }

        #endregion

        #region СОХРАНЕНИЕ РЕЗУЛЬТАТОВ И ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// Закрытие окна с положительным результатом
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка, выбран ли хоть один элемент в таблице
        /// </summary>
        /// <returns>True если выбран, False если не выбран</returns>
        private bool ValidateData()
        {
            if (mode == ItemsChoiceMode.Single && SelectedRow == null)
            {
                MessageBox.Show("Нужно выбрать строку!", "Выбор данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// По двойному щелчку выбираем строку и закрываем окно
        /// </summary>
        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mode == ItemsChoiceMode.Multiple)
                (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row[CHECKED_COL_NAME] = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Сохранение параметров колонок в конфиг-файле
        /// </summary>
        private void ManyItemsChoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(ConfigName))
                Config.SaveDataGridViewSettings(ConfigName, dgvItems);
        }

        #endregion
    }

    /// <summary>
    /// Режим запуска окна выбора элементов
    /// </summary>
    public enum ItemsChoiceMode
    {
        /// <summary>
        /// Одиночный выбор
        /// </summary>
        Single,

        /// <summary>
        /// Множественный выбор
        /// </summary>
        Multiple
    }
}
