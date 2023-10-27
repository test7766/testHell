using System;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Data.PickControlTableAdapters;
using WMSOffice.Dialogs.WMove;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class EditPickListItemForm : ChangeLocnForm
    {
        #region АТРИБУТЫ

        /// <summary>
        /// Серия (входной параметр)
        /// </summary>
        public string VendorLot { get; set; }

        /// <summary>
        /// Серия для второй строки
        /// </summary>
        public string VendorLotSplit { get; private set; }

        /// <summary>
        /// Номер партии (входной параметр)
        /// </summary>
        public string LotNumber { get; set; }

        /// <summary>
        /// Номер партии для второй строки
        /// </summary>
        public string LotNumberSplit { get; private set; }

        /// <summary>
        /// Единица измерения (входной параметр)
        /// </summary>
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// Единица измерения для второй строки
        /// </summary>
        public string UnitOfMeasureSplit { get; set; }

        /// <summary>
        /// Код склада (входной параметр)
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// Текущее количество товара в первой строке сплитовки
        /// </summary>
        public double CurrentQty { get; set; } 

        #endregion

        #region КОНСТРУКТОР

        public EditPickListItemForm()
        {
            InitializeComponent();

            // Явно прописываем координаты кнопок, потому что если выставить в Дизайнере, то они почему-то сьезжают вправо за окно
            btnOK.Location = new Point(400, 8);
            btnCancel.Location = new Point(500, 8);

            RefreshFields();
        }

        /// <summary>
        /// Обновляет информацию в текстбоксах окна по значениям атрибутов класса
        /// </summary>
        protected override void RefreshFields()
        {
            base.RefreshFields();
            tbCount.Text = CurrentQty.ToString();
            tbVendorLot.Text = VendorLot;
            tbSpLnVendorLot.Text = VendorLotSplit;
            tbLotNumber.Text = LotNumber;
            tbSpLnLotNumber.Text = LotNumberSplit;
            tbUnitOfMeasure.Text = UnitOfMeasure;
            tbSpLnUnitOfMeasure.Text = UnitOfMeasureSplit;
        }

        #endregion

        #region ОБРАБОТЧИКИ СОБЫТИЙ

        /// <summary>
        /// Загрузка возможных причин изменения товара
        /// </summary>
        private void EditPickListItemForm_Load(object sender, EventArgs e)
        {
            taCpEditPickListReasons.Fill(dsPickControl.CpEditPickListReasons);
            tbLocn.Focus();
        }

        #endregion

        #region МЕТОДЫ, СВЯЗАННЫЕ С ИЗМЕНЕНИЕМ МЕСТА ХРАНЕНИЯ

        /// <summary>
        /// Смена места хранения товара
        /// </summary>
        /// <param name="pForSplitRow">True, если метод вызывается для второй строки, False - в противном случае</param>
        protected override void ChangeLocation(bool pForSplitRow)
        {
            string locn = "", vendotLot = "", lotNumber = "", unitOfMeasure = "";
            if (ChooseLocations(out locn, out vendotLot, out lotNumber, out unitOfMeasure))
            {
                if (pForSplitRow)
                {
                    LocnSplit = locn;
                    VendorLotSplit = vendotLot;
                    LotNumberSplit = lotNumber;
                    UnitOfMeasureSplit = unitOfMeasure;
                }
                else
                {
                    Locn = locn;
                    VendorLot = vendotLot;
                    LotNumber = lotNumber;
                    UnitOfMeasure = unitOfMeasure;
                }

                RefreshFields();
            }
        }

        /// <summary>
        /// Запуск формы выбора мест хранения
        /// </summary>
        /// <param name="pLastLocn">Выходной параметр, в который запишется выбранное место хранения</param>
        /// <param name="pLotNumber">Выходной параметр, в который запишется серия для выбранного места хранения</param>
        /// <param name="pVendorLot">Выходной параметр, в который запишется партия для выбранного места хранения</param>
        /// <param name="pUnitOfMeasure">Выходной параметр, в который запишется ЕИ для выбранного места хранения</param>
        /// <returns>True, если место хранения было изменено, False, если нет (выход через Cancel)</returns>
        private bool ChooseLocations(out string pLastLocn, out string pVendorLot, out string pLotNumber,
            out string pUnitOfMeasure)
        {
            pLastLocn = pVendorLot = pLotNumber = pUnitOfMeasure = "";

            using (RichListForm formLocations = new RichListForm())
            {
                // Явно прописываем координаты кнопок, потому что если выставить в Дизайнере, то они почему-то сьезжают вправо за окно
                formLocations.btnOK.Location = new Point(100, 8);
                formLocations.btnCancel.Location = new Point(200, 8);

                #region Создание колонок, задающих таблицу доступных мест хранения

                // Создаем колонку с местом хранения
                DataGridViewTextBoxColumn colLocation = new DataGridViewTextBoxColumn();
                colLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                colLocation.DataPropertyName = "Location";
                colLocation.HeaderText = "Полка";
                colLocation.Name = "dgwtbcLocation";
                colLocation.ReadOnly = true;
                formLocations.Columns.Add(colLocation);

                // Создаем колонку с серией
                DataGridViewTextBoxColumn colVendorLot = new DataGridViewTextBoxColumn();
                colVendorLot.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                colVendorLot.DataPropertyName = "VendorLot";
                colVendorLot.HeaderText = "Серия";
                colVendorLot.Name = "dgwtbcVendorLot";
                colVendorLot.ReadOnly = true;
                formLocations.Columns.Add(colVendorLot);

                // Созадем колонку с партией
                DataGridViewTextBoxColumn colLotNumber = new DataGridViewTextBoxColumn();
                colLotNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                colLotNumber.DataPropertyName = "LotNumber";
                colLotNumber.HeaderText = "Партия";
                colLotNumber.Name = "dgwtbcLotNumber";
                colLotNumber.ReadOnly = true;
                formLocations.Columns.Add(colLotNumber);

                // Созадем колонку с единицей измерения
                DataGridViewTextBoxColumn colUnitOfMeasure = new DataGridViewTextBoxColumn();
                colUnitOfMeasure.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                colUnitOfMeasure.DataPropertyName = "UnitOfMeasure";
                colUnitOfMeasure.HeaderText = "ЕИ";
                colUnitOfMeasure.Name = "dgwtbcUnitOfMeasure";
                colUnitOfMeasure.ReadOnly = true;
                formLocations.Columns.Add(colUnitOfMeasure);

                // Создаем  колонку с количеством
                DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn();
                colQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                colQuantity.DataPropertyName = "Quantity";
                colQuantity.HeaderText = "Количество";
                colQuantity.Name = "dgwtbcQuantity";
                colQuantity.ReadOnly = true;
                formLocations.Columns.Add(colQuantity);

                #endregion

                using (CpFreeLocationsTableAdapter adapter = new CpFreeLocationsTableAdapter())
                {
                    Data.PickControl.CpFreeLocationsDataTable locationTable = adapter.GetData(WarehouseId, ItemID);
                    formLocations.DataSource = locationTable;
                }

                // Инициализируем остальные элементы управления формы
                formLocations.Text = "Выбор мест хранения";
                formLocations.pnlFilter.Visible = false;    // Здесь нам не нужен фильтр
                formLocations.RussianCulture = false;
                formLocations.ColumnForFilters.Add("Location");

                if (formLocations.ShowDialog() == DialogResult.OK)
                {
                    pLastLocn = ((Data.PickControl.CpFreeLocationsRow)formLocations.SelectedRow).Location.Trim();
                    pVendorLot = ((Data.PickControl.CpFreeLocationsRow)formLocations.SelectedRow).VendorLot.Trim();
                    pLotNumber = ((Data.PickControl.CpFreeLocationsRow)formLocations.SelectedRow).LotNumber.Trim();
                    pUnitOfMeasure = ((Data.PickControl.CpFreeLocationsRow)formLocations.SelectedRow).UnitOfMeasure.Trim();
                    return true;
                }

                return false;   // Изменение места хранение закончилось отменой
            }
        }

        #endregion

        #region ДРУГИЕ ОБРАБОТЧИКИ

        /// <summary>
        /// Проверяем значение в поле "Количество", и если оно неправильное, то отменяем изменение поля "Количество"
        /// </summary>
        private void tbCount_Leave(object sender, EventArgs e)
        {
            double newCount;

            // Сначала проверим, а число ли это вообще
            try
            {
                newCount = Int32.Parse(tbCount.Text);
            }
            catch   // Значит введено вообще не число, не даем изменить количество
            {
                MessageBox.Show("Введите число, а не произвольную строку!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCount.Text = CurrentQty.ToString();
                return;
            }

            // Теперь проверим, не больше ли оно за количество, заданное сначала
            if ((chbSplit.Checked ? newCount + QtySplit : newCount) > Qty || newCount < 0)
            {
                MessageBox.Show("Максимальное количество товара = " + Qty.ToString() + " и не может быть отрицательным!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCount.Text = CurrentQty.ToString();
                return;
            }

            // Все нормально, можем произвести корректировку количества
            CurrentQty = newCount;
            RefreshFields();
        }

        /// <summary>
        /// Корректировать количество товара можно только при выключеной сплитовке
        /// </summary>
        private void chbSplit_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSplit.Checked == true)
                tbCount.Enabled = false;
            else
                tbCount.Enabled = true;

            
            //base.tbSplitCount_TextChanged(tbSplitCount, new EventArgs());
        }

        /// <summary>
        /// Максимальное количество товара в строке, которая сплитуется
        /// </summary>
        protected override double MaxSplitQty { get { return CurrentQty; } }

        #endregion
    }
}
