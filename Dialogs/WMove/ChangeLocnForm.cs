using System;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Data.WMoveTableAdapters;
using WMSOffice.Dialogs;

namespace WMSOffice.Dialogs.WMove
{
    public partial class ChangeLocnForm : DialogForm
    {
        #region АТРИБУТЫ

        /// <summary>
        /// Идентификатор документа WM (входное значение)
        /// </summary>
        public long DocID { get; set; }

        /// <summary>
        /// Идентификатор товара (входное значение)
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// Идентификатор сессии пользователей (входное значение)
        /// </summary>
        public long SessionID { get; set; }

        /// <summary>
        /// Общее количество шт. в текущей строке (входное значение)
        /// </summary>
        public double Qty { get; set; }

        /// <summary>
        /// Кол-во во второй строке, которая будет отделена от первой
        /// </summary>
        public double QtySplit { get; private set; }

        /// <summary>
        /// Место (полка) (входное значение)
        /// </summary>
        public string Locn { get; set; }

        /// <summary>
        /// Место (полка) для второй строки
        /// </summary>
        public string LocnSplit { get; set; }

        /// <summary>
        /// Код причины изменения места назначения строки
        /// </summary>
        public int ReasonCodeID { get { return (int)cbReasons.SelectedValue; } }

        /// <summary>
        /// Описание причины изменений
        /// </summary>
        public string ReasonDescription { get { return tbDescription.Text; } }

        #endregion

        #region КОНСТРУКТОР

        public ChangeLocnForm()
        {
            InitializeComponent();
        }

        #endregion

        #region МЕТОДЫ И ОБРАБОТЧИКИ, СВЯЗАННЫЕ СО СМЕНОЙ МЕСТА ХРАНЕНИЯ ТОВАРА

        /// <summary>
        /// Запуск формы поиска мест хранения
        /// </summary>
        private void btnLocn_Click(object sender, EventArgs e)
        {
            ChangeLocation(false);
        }

        /// <summary>
        /// Смена места хранения товара
        /// </summary>
        /// <param name="pForSplitRow">True, если метод вызывается для второй строки, False - в противном случае</param>
        protected virtual void ChangeLocation(bool pForSplitRow)
        {
            string locn = "";
            if (ChooseLocations(out locn))
            {
                if (pForSplitRow)
                    LocnSplit = locn;
                else
                    Locn = locn;

                RefreshFields();
            }
        }

        /// <summary>
        /// Обновляет текстовые поля формы на основании значений полей класса
        /// </summary>
        protected virtual void RefreshFields()
        {
            tbCount.Text = (Qty - QtySplit).ToString();
            tbLocn.Text = Locn;
            tbSplitCount.Text = QtySplit.ToString();
            tbSplitLocn.Text = LocnSplit;
        }

        /// <summary>
        /// Запуск формы выбора мест хранения
        /// </summary>
        /// <param name="pLastLocn">Выходной параметр, в который запишется выбранное место хранения</param>
        /// <returns>True, если место хранения было изменено, False, если нет (выход через Cancel)</returns>
        private bool ChooseLocations(out string pLastLocn)
        {
            pLastLocn = "";

            using (RichListForm formLocations = new RichListForm())
            {
                // Создаем колонку с местом хранения
                DataGridViewTextBoxColumn colLocn = new DataGridViewTextBoxColumn();
                colLocn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                colLocn.DataPropertyName = "LOCN";
                colLocn.HeaderText = "Полка";
                colLocn.Name = "colLocn";
                colLocn.ReadOnly = true;
                formLocations.Columns.Add(colLocn);

                // Инициализируем остальные элементы управления формы
                formLocations.Text = "Выбор мест хранения";
                Data.Inventory.LocationsToSetDataTable table = new Data.Inventory.LocationsToSetDataTable();
                formLocations.DataSource = table;
                formLocations.ColumnForFilters.Add("LOCN");
                formLocations.AllowSearchByEmptyFilter = true; // задействуем режим поиска по пустому фильтру
                formLocations.FilterChanged += new EventHandler(formLocations_FilterChanged);

                formLocations.Filter = Environment.NewLine; // выполняем фиктивное действие события активации фильтра
                formLocations.Filter = String.Empty;

                formLocations.RussianCulture = false;

                if (formLocations.ShowDialog() == DialogResult.OK)
                {
                    pLastLocn = (string)((Data.WMove.WM_FreeLocationsRow)formLocations.SelectedRow).locn;
                    return true;
                }

                return false;   // Изменение места хранение закончилось отменой
            }
        }

        /// <summary>
        /// Форма поиска мест хранения для второй строки (строки разбиения)
        /// </summary>
        private void btnSplitLocn_Click(object sender, EventArgs e)
        {
            ChangeLocation(true);
        }

        /// <summary>
        /// Обрабатывает изменение фильтра в диалоге выбора мест хранения с учетом фильтра
        /// </summary>
        private void formLocations_FilterChanged(object sender, EventArgs e)
        {
            RefreshGrid((RichListForm)sender);
        }

        /// <summary>
        /// Перезагружает данные в гриде в соответствии с значением в фильтре
        /// </summary>
        /// <param name="pForm">Форма выбора места хранения</param>
        protected virtual void RefreshGrid(RichListForm pForm)
        {
            using (WM_FreeLocationsTableAdapter adapter = new WM_FreeLocationsTableAdapter())
            {
                try
                {
                    Data.WMove.WM_FreeLocationsDataTable table = adapter.GetData(DocID, ItemID, pForm.Filter);
                    pForm.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region ОСТАЛЬНЫЕ ОБРАБОТЧИКИ СОБЫТИЙ

        /// <summary>
        /// Активация разделения одной строки на две
        /// </summary>
        private void chbSplit_CheckedChanged(object sender, EventArgs e)
        {
            groupSplit.Enabled = chbSplit.Checked;
            tbCount.Text = (chbSplit.Checked) ? (MaxSplitQty - QtySplit).ToString() : MaxSplitQty.ToString();
        }

        /// <summary>
        /// Загрузка элементов формы
        /// </summary>
        private void ChangeLocnForm_Load(object sender, EventArgs e)
        {
            wM_ChangeLocnReasonTableAdapter.Fill(wMove.WM_ChangeLocnReason, DocID, SessionID);
            RefreshFields();
            tbLocn.Focus();
        }

        /// <summary>
        /// Проверяет правильность введенных данных при закрытии формы
        /// </summary>
        private void ChangeLocnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                // Проверка правильности введенных данных
                e.Cancel = true;

                if (String.IsNullOrEmpty(tbLocn.Text.Trim()))
                    MessageBox.Show("Не указано значение МЕСТО!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (chbSplit.Checked && String.IsNullOrEmpty(tbSplitLocn.Text.Trim()))
                    MessageBox.Show("Не указано значение МЕСТО для второй строки при разделении!", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (chbSplit.Checked && (QtySplit <= 0 || QtySplit >= MaxSplitQty))
                    MessageBox.Show("Указано не допустимое значение поля КОЛИЧЕСТВО при разделении строк!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (String.IsNullOrEmpty(tbDescription.Text.Trim()))
                    MessageBox.Show("Не указано ОПИСАНИЕ причины вносимых изменений!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else 
                    e.Cancel = false;   // Все нормально, закрываем форму
            }
        }

        /// <summary>
        /// Обработка ввода кол-ва для новой строки. Контроль ввода
        /// </summary>
        protected void tbSplitCount_TextChanged(object sender, EventArgs e)
        {
            double val;
            bool hasError = false;

            // Пробуем распарсить введеное в строку разбиения количество
            if (Double.TryParse(tbSplitCount.Text, out val))
            {
                if (val <= 0 || val >= MaxSplitQty)
                    hasError = true;    // Количество товара в разбиении не может быть отрицательным либо большим, чем в первой строке
                
                    // В данном классе это не используется, добавлено для использования в EditPickListItemForm
                else if (Int32.Parse(tbCount.Text) < 0)
                    hasError = true;
                else
                {
                    QtySplit = val;
                    tbCount.Text = (MaxSplitQty - QtySplit).ToString();
                }
            }
            else
                hasError = true;    // А это означает, что было введено не число, а вообще левую фигню

            // Если введено правильное значени, то цвет ТекстБокса обычный, иначе подсвечиваем розовым,
            tbSplitCount.BackColor = (hasError) ? Color.Pink : SystemColors.Window;
            if (hasError)
                QtySplit = 0;
        }

        /// <summary>
        /// Максимальное количество товара в строке, которая сплитуется
        /// </summary>
        protected virtual double MaxSplitQty { get { return Qty; } }

        /// <summary>
        /// Обработка изменения места с помощью клавиатуры
        /// </summary>
        private void tbLocn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnLocn_Click(sender, e);
        }

        /// <summary>
        /// Обработка изменения места (для втрогой строки) с помощью клавиатуры
        /// </summary>
        private void tbSplitLocn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSplitLocn_Click(sender, e);
        }

        #endregion
    }
}
