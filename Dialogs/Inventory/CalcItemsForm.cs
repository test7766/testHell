using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.InventoryTableAdapters;
using System.Windows.Forms.VisualStyles;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class CalcItemsForm : Form
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="sessionID">Сессия пользователя системы ВМС</param>
        /// <param name="docID">Идентификатор инвентаризации ВМС</param>
        /// <param name="jdeDocID">Идентификатор инвентаризации JDE (просто для информации)</param>
        /// <param name="calcID">Номер пересчета</param>
        public CalcItemsForm(int sessionID, int docID, int jdeDocID, int calcID, bool csAutoCreateFlag)
        {
            InitializeComponent();
            SessionID = sessionID;
            DocID = docID;
            CalcID = calcID;
            JDEDocID = jdeDocID;
            CSAutoCreateFlag = csAutoCreateFlag;

            lblDocID.Text = DocID.ToString();
            lblJDEDocID.Text = JDEDocID.ToString();
            lblCalcID.Text = CalcID.ToString();
        }

        /// <summary>
        /// Сессия пользователя системы ВМС
        /// </summary>
        public int SessionID { get; set; }

        /// <summary>
        /// Идентификатор инвентаризации ВМС
        /// </summary>
        public int DocID { get; set; }

        /// <summary>
        /// Идентификатор инвентаризации JDE (просто для информации)
        /// </summary>
        public int JDEDocID { get; set; }

        /// <summary>
        /// Номер пересчета
        /// </summary>
        public int CalcID { get; set; }

        /// <summary>
        /// Флаг: создавать счетные листы автоматически!
        /// </summary>
        public bool CSAutoCreateFlag { get; set; }

        /// <summary>
        /// Событие - загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcItemsForm_Load(object sender, EventArgs e)
        {
            // видимость колонок с отметками товара на следующий пересчет
            colQuantityCalc1.Visible = (CalcID == 1 || IsFinalChoise);
            colQuantityCalc2.Visible = (CalcID == 2 || IsFinalChoise);
            colQuantityCalc3.Visible = (CalcID == 3 || IsFinalChoise);

            btnCreateCalc.Visible = !IsFinalChoise; // создаем следующий пересчет
            btnCloseInventory.Visible = IsFinalChoise; // либо закрываем инвентаризацию
            rbViewRecomend.Visible = !IsFinalChoise;
            if (IsFinalChoise) lblCalcID.Text = "-";

            RefreshItems();
        }

        /// <summary>
        /// Признак режима "закрытие инвентаризации"
        /// </summary>
        private bool IsFinalChoise
        {
            get { return (CalcID == 4); }
        }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Таблица с данными поиска
        /// </summary>
        private Data.Inventory.IM_DiffDataTable diffDataTable = new WMSOffice.Data.Inventory.IM_DiffDataTable();

        #region refresh items

        private int _selectedItemsCount = 0;

        /// <summary>
        /// Обновление списка товаров для пересчета
        /// </summary>
        private void RefreshItems()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(RefreshWorker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RefreshWorker_RunWorkerCompleted);

            splashForm.ActionText = "Получение списка товара...";
            worker.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Фоновое обновление списка товаров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RefreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                iM_DiffTableAdapter.Fill(diffDataTable, SessionID, DocID, CalcID);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обработка окончания фонового обновления данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RefreshWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).Message, "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                diffDataTable.Clear();
            }
            iMDiffBindingSource.DataSource = diffDataTable;

            if (IsFinalChoise) rbViewAll.Checked = true;
            rbViewRecomend.Checked = !IsFinalChoise;
            rbViewAll.Text = String.Format("все ({0})", diffDataTable.Count);
            rbViewRecomend.Text = String.Format("рекомендованные ({0})", iMDiffBindingSource.Count);
            _selectedItemsCount = iMDiffBindingSource.Count;

            splashForm.CloseForce();
        }

        #endregion


        private void gvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (IsFinalChoise)
                foreach (DataGridViewRow gridRow in gvItems.Rows)
                {
                    Data.Inventory.IM_DiffRow diffRow = (Data.Inventory.IM_DiffRow)((DataRowView)gridRow.DataBoundItem).Row;
                    ((CustomCheckBoxCell)gridRow.Cells[colQuantityCalc3.Name]).IsVisible = (!diffRow.IsQuantityFact3Null());
                    ((CustomCheckBoxCell)gridRow.Cells[colQuantityCalc2.Name]).IsVisible = (!diffRow.IsQuantityFact2Null());
                    ((CustomCheckBoxCell)gridRow.Cells[colQuantityCalc1.Name]).IsVisible = (!diffRow.IsQuantityFact1Null());
                }
        }

        #region filter

        /// <summary>
        /// Метод установки фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbViewRecomend_CheckedChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        /// <summary>
        /// Устанавливает фильтр для таблицы
        /// основываясь на переключателе и строке поиска
        /// </summary>
        private void SetFilter()
        {
            string filter = (rbViewRecomend.Checked) ? String.Format("QuantityCalc{0} = 1", (CalcID < 4) ? CalcID : 1) : "";
            filter += (String.IsNullOrEmpty(tbSearch.Text)) ? ""
                : String.Format("{0}(Item like '%{1}%' or Manufacturer like '%{1}%')", (String.IsNullOrEmpty(filter)) ? "" : " and ", tbSearch.Text);
            iMDiffBindingSource.Filter = filter;
        }

        /// <summary>
        /// Обработчик события изменения строки поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            tbSearch.BackColor = (String.IsNullOrEmpty(tbSearch.Text)) ? SystemColors.Window : SystemColors.Info;
            SetFilter();

        }

        #endregion

        /// <summary>
        /// Метод создания следующего пересчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCalc_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedItemsCount < 1)
                    MessageBox.Show("Вы не выбрали ни одного товара для следующего пересчета.\n\nВыберите товар для создания нового пересчета,\nлибо воспользуйтесь функцией \"Закрыть инвентаризацию\".");
                else
                {
                    if (iMDiffBindingSource.DataSource is Data.Inventory.IM_DiffDataTable)
                    {
                        // собираем список выбранных строк и создаем пересчет
                        var table = iMDiffBindingSource.DataSource as Data.Inventory.IM_DiffDataTable;
                        var view = new DataView(table, String.Format("QuantityCalc{0} = 1", CalcID), "", DataViewRowState.CurrentRows);
                        List<int> lines = new List<int>();
                        foreach (DataRowView row in view)
                            lines.Add(((Data.Inventory.IM_DiffRow)row.Row).Line_ID);

                        BackgroundWorker worker = new BackgroundWorker();
                        worker.DoWork += new DoWorkEventHandler(CreateWorker_DoWork);
                        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CreateWorker_RunWorkerCompleted);

                        splashForm.ActionText = "Создание нового пересчета...";
                        worker.RunWorkerAsync(lines);
                        splashForm.ShowDialog();

                    } else throw new ArgumentException("Не правильный источник данных, ожидался IM_DiffDataTable.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CreateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<int> lines = (List<int>)e.Argument;
                IM_CalcsTableAdapter.CreateCalc(SessionID, DocID, "IC", CSAutoCreateFlag, lines);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обработка окончания фонового обновления данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CreateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).Message, "Ошибка обновления данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            splashForm.CloseForce();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /// <summary>
        /// Метод закрытия инвентаризации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseInventory_Click(object sender, EventArgs e)
        {
            try
            {
                if (iMDiffBindingSource.DataSource is Data.Inventory.IM_DiffDataTable)
                {
                    // собираем список выбранных строк и создаем пересчет
                    var table = iMDiffBindingSource.DataSource as Data.Inventory.IM_DiffDataTable;
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(CloseInvWorker_DoWork);
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CloseInvWorker_RunWorkerCompleted);

                    splashForm.ActionText = "Сохранение результатов инвентаризации...";
                    worker.RunWorkerAsync(table);
                    splashForm.ShowDialog();
                }
                else throw new ArgumentException("Не правильный источник данных, ожидался IM_DiffDataTable.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CloseInvWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Data.Inventory.IM_DiffDataTable lines = (Data.Inventory.IM_DiffDataTable)e.Argument;
                IM_CalcsTableAdapter.CloseInventory(SessionID, DocID, "IC", lines);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void CloseInvWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).Message, "Ошибка обновления данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            splashForm.CloseForce();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void gvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // только для строк со значениями...
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string colName = gvItems.Columns[e.ColumnIndex].Name;
                int calcID = (colName == colQuantityCalc1.Name) ? 1 
                    : (colName == colQuantityCalc2.Name) ? 2 
                    : (colName == colQuantityCalc3.Name) ? 3 : 0;

                // только колонки выбора товара к пересчету
                if (calcID > 0)
                {
                    // только в том случае, если ячейка видима
                    CustomCheckBoxCell cell = (CustomCheckBoxCell)gvItems[e.ColumnIndex, e.RowIndex];
                    if (cell.IsVisible)
                    {
                        // определение текущено значения
                        Data.Inventory.IM_DiffRow diffRow = (Data.Inventory.IM_DiffRow)((DataRowView)gvItems.Rows[e.RowIndex].DataBoundItem).Row;
                        bool check = ((calcID == 1) ? diffRow.QuantityCalc1 : (calcID == 2) ? diffRow.QuantityCalc2 : diffRow.QuantityCalc3) == 1;

                        if (!IsFinalChoise)
                        {
                            // выбор товара для пересчета
                            if (gvItems.SelectedRows.Count == 1
                                || (gvItems.SelectedRows.Count > 1
                                    && (MessageBox.Show(String.Format("Вы действительно хотите {0} {1} строк?", (check) ? "удалить из пересчета" : "добавить к пересчету", gvItems.SelectedRows.Count),
                                    "Выбор товара для пересчета", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                   )
                               )
                            {
                                foreach (DataGridViewRow row in gvItems.SelectedRows)
                                {
                                    CheckRow((Data.Inventory.IM_DiffRow)((DataRowView)row.DataBoundItem).Row, !check, calcID);
                                }
                            }

                            rbViewRecomend.Text = String.Format("рекомендованные ({0})", _selectedItemsCount);
                        }
                        else
                            if (!check)
                            {
                                // выбор результата инвентаризации
                                foreach (DataGridViewRow row in gvItems.SelectedRows)
                                {
                                    SelectFinRow((Data.Inventory.IM_DiffRow)((DataRowView)row.DataBoundItem).Row, calcID);
                                }
                            }
                    }
                }
            }
        }

        private void CheckRow(Data.Inventory.IM_DiffRow row, bool check, int calcID)
        {
            // текущее не измененное значение
            int oldResult = (calcID == 1) 
                ? row.QuantityCalc1 
                : (calcID == 2) 
                    ? row.QuantityCalc2 
                    : row.QuantityCalc3;
            // корректировка выбранного количества
            _selectedItemsCount = _selectedItemsCount + (
                    (oldResult == 1 && !check) 
                        ? -1 
                        : (oldResult == 0 && check) 
                            ? 1 
                            : 0
                );
            // изменение значения
            switch (calcID)
            {
                case 1: row.QuantityCalc1 = (check) ? 1 : 0; break;
                case 2: row.QuantityCalc2 = (check) ? 1 : 0; break;
                case 3: row.QuantityCalc3 = (check) ? 1 : 0; break;
            }
        }

        private void SelectFinRow(Data.Inventory.IM_DiffRow row, int calcID)
        {
            // изменение значения
            switch (calcID)
            {
                case 1:
                    if (row.IsQuantityFact1Null()) return;
                    row.QuantityCalc2 = row.QuantityCalc3 = 0;
                    row.QuantityCalc1 = 1; 
                    break;
                case 2:
                    if (row.IsQuantityFact2Null()) return;
                    row.QuantityCalc1 = row.QuantityCalc3 = 0;
                    row.QuantityCalc2 = 1;
                    break;
                case 3:
                    if (row.IsQuantityFact3Null()) return;
                    row.QuantityCalc1 = row.QuantityCalc2 = 0;
                    row.QuantityCalc3 = 1;
                    break;
            }
        }

    }

    public class CustomDataGridViewCheckBoxColumn : DataGridViewCheckBoxColumn//DataGridViewColumn
    {
        public CustomDataGridViewCheckBoxColumn()
            : base()
        {
            base.CellTemplate = new CustomCheckBoxCell();
        }
    }

    public class CustomCheckBoxCell : DataGridViewCheckBoxCell
    {
        public CustomCheckBoxCell()
            : base()
        {
            IsVisible = true;
        }

        public bool IsVisible { get; set; }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (IsVisible)
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            else
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }
            }
        }
    }
}
