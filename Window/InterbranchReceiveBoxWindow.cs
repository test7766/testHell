using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Classes.ReportProviders;
using WMSOffice.Data;
using WMSOffice.Data.InterbranchTableAdapters;
using WMSOffice.Data.PickControlTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Dialogs.InterBranch;
using WMSOffice.Reports;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно поштучного контроля ящика
    /// </summary>
    public partial class InterbranchReceiveBoxWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// True если была успешно загружена информация о документе, False если нет
        /// </summary>
        private bool wasDocInfoLoaded;

        /// <summary>
        /// True если проводится повторный контроль ящика, False если первичный контроль ящика
        /// </summary>
        private bool isRepeatControl;

        /// <summary>
        /// True если проводится повторный контроль ящика, False если первичный контроль ящика
        /// </summary>
        public bool IsRepeatControl
        {
            get { return isRepeatControl; }
            set
            {
                isRepeatControl = value;
                pnlDescription.Visible = value;
            }
        }

        /// <summary>
        /// True если доступна кнопка "Отменить последнее действие", False если отменять нечего и кнопка недоступна
        /// </summary>
        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = miUndo.Enabled = value; }
        }

        /// <summary>
        /// Последняя добавленная строка (она всегда находится первой в таблице)
        /// </summary>
        private Interbranch.ReceiveBoxRowsRow LastAddedItem
        {
            get
            {
                if (dgvLines.Rows.Count == 0)
                    return null;
                else
                    return (dgvLines.Rows[0].DataBoundItem as DataRowView).Row as Interbranch.ReceiveBoxRowsRow;
            }
        }

        /// <summary>
        /// Наличие бонусного товара в контейнере
        /// </summary>
        private bool IsBonus
        {
            set
            {
                lblInfo.ForeColor = SystemColors.ControlText;

                if (value)
                {
                    lblInfo.Text = "В контейнере находится бонусный товар...";
                    lblInfo.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Признак заводского недовложения
        /// </summary>
        public bool ZU_ND_Enabled { get; set; }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public InterbranchReceiveBoxWindow()
        {
            InitializeComponent();
            IsRepeatControl = UndoEnabled = false;
            lblBarcode.Text = lblItemsCount.Text = lblDocType.Text = lblDocNumber.Text = lblDelivery.Text = String.Empty;
        }

        /// <summary>
        /// Загрузка строк документа контроля при загрузке окна
        /// </summary>
        private void PickControlWindow_Load(object sender, EventArgs e)
        {
            GetDocInfo();
            clNoItem.Visible = IsRepeatControl;
            RefreshLines();
        }

        /// <summary>
        /// Получение информации о документе
        /// </summary>
        private void GetDocInfo()
        {
            try
            {
                using (var adapter = new ReceiveBoxInfoTableAdapter())
                {
                    var infoTable = adapter.GetData(DocID);
                    if (infoTable == null || infoTable.Count == 0)
                        throw new ApplicationException("Не удалось получить данные о документе");
                    else
                    {
                        var row = infoTable[0];
                        lblBarcode.Text = row.Bar_Code;
                        lblItemsCount.Text = row.CountItems.ToString();
                        lblDocType.Text = row.NaklType;
                        lblDocNumber.Text = row.NaklNumber.ToString();
                        lblDelivery.Text = row.ShipTo_Name;
                        IsRepeatControl = !row.IsRelated_Doc_IDNull();

                        IsBonus = row.IsIsBonusNull() ? false : Convert.ToBoolean(row.IsBonus);

                        wasDocInfoLoaded = true;
                        tbBarcode.Focus();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения данных о документе возникла ошибка!", exc);
            }
        }

        /// <summary>
        /// Обновление строк в таблице проконтролированных данных
        /// </summary>
        private void RefreshLines()
        {
            try
            {
                taReceiveBoxRows.Fill(interbranch.ReceiveBoxRows, DocID);
                if (dgvLines.Rows.Count > 0)
                    dgvLines.Rows[0].Selected = true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("При загрузке проконтролированных товаров возникла ошибка:", exc);
            }
        }

        #endregion

        #region ДОБАВЛЕНИЕ СТРОК И ВВОД КОЛИЧЕСТВА

        /// <summary>
        /// Код последнего добавленного товара
        /// </summary>
        private int lastItemID;

        /// <summary>
        /// Название последнего добавленного товара
        /// </summary>
        private string lastItemName = String.Empty;

        /// <summary>
        /// Единица измерения для последнего добавленного товара
        /// </summary>
        private string lastUoM = String.Empty;

        /// <summary>
        /// Количество последнего добавленного товара
        /// </summary>
        private int count;

        /// <summary>
        /// Серия последнего добавленного товара
        /// </summary>
        private string lastVendorLot = String.Empty;

        /// <summary>
        /// Тип последнего добавления товара: "В" - сканирование штрих-кода, "М" - ручное добавление товара без штрих-кода
        /// </summary>
        private string lastScanType = "X";

        /// <summary>
        /// Количество штук НТВ последнего добавленного товара
        /// </summary>
        private int countNTV;

        /// <summary>
        /// Количество штук боя последнего добавленного товара
        /// </summary>
        private int countBoy;

        /// <summary>
        /// Количество штук заводского брака последнего добавленного товара
        /// </summary>
        private int countDefect;

        private bool? last_zu_nd_checked; 

        /// <summary>
        /// Строка, которую содержит SQL-сообщение об ошибке при контроле товара, который не должен находиться в ящике
        /// </summary>
        private const string REDFORM = "REDFORM";

        /// <summary>
        /// Строка, которую содержит SQL-сообщение об ошибке при выборе серии, которая не находится в сборочном листе
        /// </summary>
        private const string YELLOWFORM = "YELLOWFORM";

        /// <summary>
        /// Строка, которая обозначает отсутствие серии на товаре
        /// </summary>
        private const string NOSER = "NOSER";

        /// <summary>
        /// Окно для выбора серии товара
        /// </summary>
        private RichListForm formSeries;

        /// <summary>
        /// Отсканирован товар
        /// </summary>
        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbBarcode.Text))
                EnterQuantity();
            else
                EnterNewItemRow();

            tbBarcode.Text = String.Empty;
        }

        /// <summary>
        /// Ввод количества по строке (если был нажат Enter в пустой строке поиска)
        /// </summary>
        private void EnterQuantity()
        {
            // разрешен ввод количества для товара, который был введен без штрих кода. Тогда по ENTER-у показываем это окно
            if (wasDocInfoLoaded && UndoEnabled)
            {
                var form = new SetCountWithNtvForm(lastItemID, lastItemName, lastVendorLot,
                    Convert.ToInt32(LastAddedItem.Doc_Qty) - count,
                    Convert.ToInt32(LastAddedItem.Doc_Qty_NTV) - countNTV,
                    Convert.ToInt32(LastAddedItem.Doc_Qty_BOY) - countBoy,
                    Convert.ToInt32(LastAddedItem.Doc_Qty_Defect) - countDefect,
                    count, countNTV, countBoy, countDefect, this.ZU_ND_Enabled, LastAddedItem.ND_ZU);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int cnt = form.Count;
                    int cntNTV = form.CountNtv;
                    int cntBoy = form.CountBoy;
                    int cntDefect = form.CountDefect;
                    if (cnt != count || cntBoy != countBoy || cntNTV != countNTV || cntDefect != countDefect)
                    {
                        count = cnt - count;
                        countBoy = cntBoy - countBoy;
                        countNTV = cntNTV - countNTV;
                        countDefect = cntDefect - countDefect;
                        last_zu_nd_checked = form.ND_ZU_Checked;
                        AddRow();
                    }
                    count = cnt;
                    countNTV = cntNTV;
                    countBoy = cntBoy;
                    countDefect = cntDefect;
                }
            }
        }

        /// <summary>
        /// Добавление проконтролированного количества по товару в БД
        /// </summary>
        private void AddRow()
        {
            try
            {
                UndoEnabled = false;
                taReceiveBoxRows.AddRow(DocID, lastItemID, lastVendorLot, lastUoM, count, lastScanType, countNTV, countBoy, countDefect, last_zu_nd_checked);
                UndoEnabled = true;
                RefreshLines();
                tbBarcode.Focus();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при редактировании количества по строке:", exc);
            }
        }

        /// <summary>
        /// Добавление строки товара
        /// </summary>
        private void EnterNewItemRow()
        {
            try
            {
                using (var adapter = new ReceiveItemsTableAdapter())
                {
                    var itemTable = adapter.GetData(DocID, UserID, tbBarcode.Text);
                    if (itemTable == null || itemTable.Count == 0)
                        Logger.ShowErrorMessageBox("Товар не найден! Воспользуйтесь F2 чтобы добавить товар без штрих-кода!");
                    else if (itemTable.Count == 1) // Нашли только один товар, можно выбирать серию
                    {
                        var itemsRow = itemTable[0];
                        lastItemID = (int)itemsRow.Item_ID;
                        lastItemName = itemsRow.Item;
                        lastUoM = itemsRow.UnitOfMeasure;
                        count = (int)itemsRow.Qty;
                        countBoy = countNTV = countDefect = 0;
                        lastScanType = "B";
                        if (!itemsRow.IsVendor_LotNull() && !String.IsNullOrEmpty(itemsRow.Vendor_Lot))
                        {   // Отсканировали уникальный штрих код ящика! Знаем даже серию!
                            lastVendorLot = itemsRow.Vendor_Lot;
                            AddRow();
                        }
                        else // Отсканировали простой товар, идентифицировали, выбираем серию
                            ChooseVendorLot();
                    }
                    else    // Нашли несколько товаров, нужно выбрать нужный
                        ChooseItems(itemTable);
                }
            }
            catch (Exception exc)
            {
                NewItemError(exc);
            }
        }

        /// <summary>
        /// Метод выбора серии (если серий больше 1)
        /// </summary>
        private void ChooseVendorLot()
        {
            try
            {
                using (var adapter = new Data.InterbranchTableAdapters.VendorLotsTableAdapter())
                {
                    var seriesTable = adapter.GetData(DocID, lastItemID);
                    if (seriesTable == null || seriesTable.Count == 0)
                    {
                        Logger.ShowErrorMessageBox("Не найдены серии! Это исключительная ситуация, обратитесь в ГСПО!");
                        return;
                    }
                    else if (seriesTable.Count == 1)
                    {
                        if (seriesTable[0].Vendor_Lot == NOSER) // Контроль серий отключен
                        {
                            lastVendorLot = NOSER;
                            AddRow();
                        }
                        else    // Нужно ввести серию вручную
                            TypeVendorLot();
                    }
                    else // Есть несколько серий, предлагаем выбрать серию
                        ChooseSeries(seriesTable);
                }
            }
            catch (Exception exc)
            {
                ChooseSeriesError(exc);
            }
        }

        /// <summary>
        /// Установка серии вручную
        /// </summary>
        private void TypeVendorLot()
        {
            var form = new SetVendorLotnForm();
            form.Text = "Присвоение серии " + lastItemName;
            if (form.ShowDialog() == DialogResult.OK)
            {
                lastVendorLot = form.Lotn;
                AddRow();
            }
            else
                UndoEnabled = false;
        }

        /// <summary>
        /// Выбор товара (если количество позиций с одним штрих кодом более 1)
        /// </summary>
        private void ChooseItems(Interbranch.ReceiveItemsDataTable pItemsTable)
        {
            // Создаем форму для выбора товара
            var formItm = new RichListForm { Text = "Выбор товара" };
            formItm.AddColumn("colItem", "Item", "Наименование");
            formItm.AddColumn("colManuf", "Manufacturer", "Производитель");
            formItm.DataSource = new Interbranch.ReceiveItemsDataTable();
            formItm.ColumnForFilters.Add("Item");
            formItm.ColumnForFilters.Add("Manufacturer");
            formItm.FilterVisible = false;
            formItm.DataSource = pItemsTable;

            // Выбор товара
            if (formItm.ShowDialog() == DialogResult.OK && formItm.SelectedRow != null)
            {
                var row = formItm.SelectedRow as Interbranch.ReceiveItemsRow;
                lastItemID = (int)row.Item_ID;
                lastItemName = row.Item;
                lastUoM = row.UnitOfMeasure;
                count = (int)row.Qty;
                lastScanType = "B";
                ChooseVendorLot();
            }
            else
                UndoEnabled = false;
        }

        /// <summary>
        /// Выбор серии (если доступно несколько серий одного товара)
        /// </summary>
        /// <param name="pSeriesTable">Таблица с доступными сериями</param>
        private void ChooseSeries(Interbranch.VendorLotsDataTable pSeriesTable)
        {
            // Создание либо настройка окна для выбора серии
            if (formSeries == null)
            {
                formSeries = new RichListForm();
                formSeries.AddColumn("colLot", "Vendor_Lot", "Серия");
                formSeries.AddColumn("colDate", "Exp_Date", "Срок годн.");
                formSeries.FilterVisible = false;
            }

            formSeries.Text = string.Format("Выбор серии {0}", lastItemName);
            formSeries.DataSource = pSeriesTable;

            // Выбор серии из нескольких серий
            if (formSeries.ShowDialog() == DialogResult.OK && formSeries.SelectedRow != null)
            {
                var row = formSeries.SelectedRow as Interbranch.VendorLotsRow;
                if (row.Vendor_Lot == "Ввести серию вручную...")
                    TypeVendorLot();
                else
                {
                    lastVendorLot = row.Vendor_Lot;
                    AddRow();
                }
            }
            else
                UndoEnabled = false;
        }

        /// <summary>
        /// Обработка ошибки при выборе серии
        /// </summary>
        /// <param name="pExc">Ошибка, которую нужно обработать</param>
        private void ChooseSeriesError(Exception pExc)
        {
            if (pExc.Message.Contains(YELLOWFORM))
            {
                var errorForm = new FullScreenErrorForm(String.Format("Товар {0}\n\rНЕ содержится в сборочном листе.\n\r" +
                    "Товар был выбран из списка.\n\rИсправьте свой выбор (если ошиблись),\n\rиначе\n\rОтложите товар в прозрачный ящик!",
                    pExc.Message.Replace(YELLOWFORM, String.Empty)), "ПРОДОЛЖИТЬ (Enter)", Color.Yellow);
                errorForm.ShowDialog();
                UndoEnabled = false;
            }
            else
                Logger.ShowErrorMessageBox("Возникла ошибка во время выбора серии товара!", pExc);
        }

        /// <summary>
        /// Обработка ошибки при сканировании товара (добавлении новой строки)
        /// </summary>
        /// <param name="pExc">Ошибка, которую нужно обработать</param>
        private void NewItemError(Exception pExc)
        {
            if (pExc.Message.Contains(REDFORM))
            {
                var errorForm = new FullScreenErrorForm(String.Format("Товар {0}\n\rНЕ содержится\n\rв ящике.\n\r" +
                    "Отложите товар в прозрачный ящик!\n\r(ведется видеонаблюдение)", pExc.Message.Replace(REDFORM, String.Empty)),
                    "Товар возвращен в отдел.\n\rПРОДОЛЖИТЬ (Enter)", Color.Red);
                errorForm.TimeOut = 2000;
                errorForm.ShowDialog();
                UndoEnabled = false;
            }
            else
                Logger.ShowErrorMessageBox("Во время обработки отсканированного товара возникла ошибка: ", pExc);
        }

        #endregion

        #region ДОБАВЛЕНИЕ ТОВАРА БЕЗ ШТРИХ-КОДА

        /// <summary>
        /// Окно для выбора товара без штрих-кода
        /// </summary>
        private RichListForm formItems;

        /// <summary>
        /// Добавление товара без штрих-кода
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Создание формы, если нужно
            if (formItems == null)
            {
                formItems = new RichListForm { Text = "Выбор товара" };
                formItems.AddColumn("colItem", "Item", "Наименование");
                formItems.AddColumn("colManuf", "Manufacturer", "Производитель");
                formItems.DataSource = new PickControl.ItemsDataTable();
                formItems.ColumnForFilters.Add("Item");
                formItems.ColumnForFilters.Add("Manufacturer");
                formItems.FilterChanged += formItems_FilterChanged;
            }

            // Отображение формы и выбор товара без штрих-кода
            if (formItems.ShowDialog() == DialogResult.OK)
            {
                lastItemID = (int)(formItems.SelectedRow as PickControl.ItemsRow).Item_ID;
                lastItemName = (formItems.SelectedRow as PickControl.ItemsRow).Item;
                lastUoM = (formItems.SelectedRow as PickControl.ItemsRow).UnitOfMeasure;
                count = 1;
                countBoy = countNTV = countDefect = 0;
                lastScanType = "M";
                ChooseVendorLot();
            }
            else
                UndoEnabled = false;
        }

        /// <summary>
        /// В зависимости от того, какой фильтр задан в форме выбора товара без штрих-кода, загружаем соответствующие товары в форму выбора
        /// </summary>
        private void formItems_FilterChanged(object sender, EventArgs e)
        {
            try
            {
                using (var adapter = new ItemsTableAdapter())
                    formItems.DataSource = adapter.GetDataAll(formItems.Filter);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке товаров по фильтру (выбор товара без штрих-кода)", exc);
            }
        }

        #endregion

        #region ОТМЕНА ПОСЛЕДНЕГО ДЕЙСТВИЯ

        /// <summary>
        /// Отмена последнего действия (по сути, удаление введенной строки)
        /// </summary>
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (UndoEnabled)
            {
                count *= -1;
                countBoy *= -1;
                countNTV *= -1;
                countDefect *= -1;
                AddRow();
                UndoEnabled = false;
            }
        }

        #endregion

        #region ЗАКРЫТИЕ КОНТРОЛЯ ЯЩИКА

        /// <summary>
        /// True если разрешаем закрывать окно, False если перед закрытием окна нужно выполнить действие, например закрыть контроль
        /// </summary>
        private bool allowCloseWindow;

        /// <summary>
        /// Закрытие контроля ящика
        /// </summary>
        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Control | Keys.Alt))
                btnUndoDoc_Click(sender, e);
            else if (HasRedRows())
                return; // Нельзя закрывать контроль ящика, если есть красные строки
            else if (dgvLines.Rows.Count == 0 && !IsRepeatControl)  // Нельзя закрывать пустой документ контроля
                Logger.ShowErrorMessageBox("Документ контроля сборки не содержит строк.\n\rТакой документ нельзя закрыть! Продолжайте работу.");
            else
                try
                {
                    TryCloseDoc();
                    Close();
                }
                catch (Exception exc)
                {
                    if (CloseDocError(exc))
                    {
                        PrintActs();    // Печать всех актов по результатам контроля (НТВ, боя, недостачи, излишков и др.)
                        allowCloseWindow = true;
                        Close();
                    }
                }
        }

        /// <summary>
        /// Проверка, содержит ли таблица красные строки (перед закрытием документа их нужно исправить)
        /// </summary>
        /// <returns>True если таблица содержит красные строки, False если не содержит</returns>
        private bool HasRedRows()
        {
            foreach (DataGridViewRow row in dgvLines.Rows)
            {
                var diffRow = (row.DataBoundItem as DataRowView).Row as Interbranch.ReceiveBoxRowsRow;
                if (String.IsNullOrEmpty(diffRow.Vendor_Lot) && AllQuantitiesZero(diffRow))
                {
                    Logger.ShowErrorMessageBox("Необходимо исправить все строки, подсвеченные красным!\n\r" +
                        "При полном отсутствии строки нажмите кнопку \"нет товара\".");
                    return true;
                }
            }

            return false;   // Красных строк нет
        }

        /// <summary>
        /// Попытка закрыть контроль ящика
        /// </summary>
        private void TryCloseDoc()
        {
            long? wm_doc_id = null;

            try
            {

                // Закрываем документ по базе, если есть ошибки -получим исключение, которое показываем пользователю
                taReceiveBoxRows.CloseDoc(DocID, UserID, null, ref wm_doc_id);

                if (wm_doc_id.HasValue)
                    PrintMoveTaskList(wm_doc_id);

                allowCloseWindow = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("SHOWDIFF#"))
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^.*SHOWDIFF#(?<WM_Doc_ID>\d+)#.*", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                    {
                        var sWM_Doc_ID = regex.Match(ex.Message).Groups["WM_Doc_ID"].Value;
                        long parsedWM_Doc_ID;

                        if (long.TryParse(sWM_Doc_ID, out parsedWM_Doc_ID))
                        {
                            wm_doc_id = parsedWM_Doc_ID;
                            PrintMoveTaskList(wm_doc_id);

                            throw ex;
                        }
                        else
                        {
                            throw new Exception("№ листа размещения неопределен.");
                        }
                    }
                    else
                    {
                        throw new Exception("№ листа размещения неопределен.");
                    }
                }
                else
                    throw ex;
            }
        }

        /// <summary>
        /// Метод печати листа размещения по его идентификатору
        /// </summary>
        /// <param name="moveTaskID"></param>
        private void PrintMoveTaskList(long? moveTaskID)
        {
            try
            {
                if (moveTaskID.HasValue && moveTaskID.Value > 0)
                {
                    // создадим таблицу для данных отчета
                    WMove.WM_PutListDataTable putList = new WMove.WM_PutListDataTable();

                    // получим данные отчета, штрих-код создан
                    MovePutListPrepare(putList, moveTaskID);

                    // напечатаем лист размещения
                    WMovePutListReport report = new WMovePutListReport();
                    report.SetDataSource((DataTable)putList);

                    ReportForm form = new ReportForm();
                    form.ReportDocument = report;
                    form.Print();
                    //form.ShowDialog();

                    if (form.IsPrinted)
                    {
                        MessageBox.Show("Лист размещения был успешно отправлен на печать.", "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "IB", 1, Convert.ToInt64(moveTaskID), (string)null, Convert.ToInt16(putList.Count), form.PrinterName, Convert.ToByte(form.Copies));
                    }
                }
                else
                {
                    MessageBox.Show("По данному документу созданы акты\r\nдля рассмотрения претензионным отделом.", "Печать актов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #region print move task

        /// <summary>
        /// Статический метод получает данные, необходимые для печати листа размещения по идентификатору
        /// </summary>
        /// <param name="putList"></param>
        /// <param name="putListID"></param>
        public static void MovePutListPrepare(WMSOffice.Data.WMove.WM_PutListDataTable putList, long? putListID)
        {
            putList.Clear();

            using (Data.WMoveTableAdapters.WM_PutListTableAdapter adapter = new WMSOffice.Data.WMoveTableAdapters.WM_PutListTableAdapter())
            {
                adapter.Fill(putList, putListID);

                if (putList != null && putList.Count > 0)
                    MovePutListBarcodePrepare(putList);
            }
        }

        /// <summary>
        /// Статический метод добавляет штрих-код по тексту
        /// </summary>
        /// <param name="putList"></param>
        private static void MovePutListBarcodePrepare(WMSOffice.Data.WMove.WM_PutListDataTable putList)
        {
            if (putList.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(1000, 200); // 720
                barCodeCtrl.BarCodeHeight = 140;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 24, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10;
                barCodeCtrl.ShowFooter = true;
                barCodeCtrl.TopMargin = 20;
                barCodeCtrl.BarCode = putList[0].Bar_Code;
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                putList[0].Bar_Code_IMG = barCode;
            }
        }

        #endregion

        /// <summary>
        /// Печать актов 
        /// </summary>
        private void PrintActs()
        {
            var acts = GetActs();
            if (acts.Count == 0)
                return;
            var prd = new PrintDocsThread();
            prd.ReportProvider = new ComplaintsActReportProvider(UserID, ComplaintActsReportProviderMode.ByAct);
            var parameters = new PrintDocsParameters
            {
                PrinterName = (new PrinterSettings()).PrinterName,
                Docs = acts.ToArray()
            };
            prd.PrintDocumentsAsynch(parameters);
        }

        /// <summary>
        /// Получение актов НТВ/Боя по текущему документу
        /// </summary>
        /// <returns>Акты Боя/НТВ, которые нужно распечатать</returns>
        private List<Interbranch.IB_IB_ActsRow> GetActs()
        {
            var ids = new List<Interbranch.IB_IB_ActsRow>();

            try
            {
                using (var adapter = new IB_IB_ActsTableAdapter())
                {
                    var tbl = adapter.GetData(DocID);
                    if (tbl == null || tbl.Count == 0)
                        return ids;
                    foreach (Interbranch.IB_IB_ActsRow row in tbl)
                        ids.Add(row);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при загрузке актов:", exc);
            }

            return ids;
        }

        /// <summary>
        /// Обработка ошибки, возникшей при закрытии товара
        /// </summary>
        /// <param name="pExc">Возникшая ошибка</param>
        /// <returns>True, если при обработке ошибки нужно будет закрыть текущее окно</returns>
        private bool CloseDocError(Exception pExc)
        {
            if (pExc.Message.Contains("SHOWDIFF"))
            {
                if (!IsRepeatControl && CreateRepeatControl())
                    return true;
                else if (IsRepeatControl)
                    return true;
            }
            else
                Logger.ShowErrorMessageBox("Возникла ошибка при закрытии документа:", pExc);

            return false;
        }

        /// <summary>
        /// Постановка на повторный контроль (если не сходится количество)
        /// </summary>
        /// <returns>True если постановка на повторный контроль прошла успешно, False в противном случае</returns>
        private bool CreateRepeatControl()
        {
            try
            {
                using (var adapter = new Data.InterbranchTableAdapters.CreatedDocsTableAdapter())
                {
                    var docRepeatTable = adapter.GetDataIBRepeat(UserID, DocID);
                    if (docRepeatTable.Count != 1)
                    {
                        Logger.ShowErrorMessageBox("Документ повторного контроля (исправлений) не был создан!");
                        return false;
                    }

                    var row = docRepeatTable[0];
                    var wnd = new InterbranchReceiveBoxWindow { UserID = UserID, WindowState = FormWindowState.Maximized, ZU_ND_Enabled = row.ZU_ND_flag};
                    wnd.InitDocument(row.Doc_Type_Name, row.Doc_ID, row.Doc_Type, row.Doc_Date, row.Status_ID, row.Status_Name);
                    wnd.ShowDialog();
                }

                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при попытке постановки на повторный контроль: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Запрещаем закрывать окно, если не закрыт документ
        /// </summary>
        private void PickControlWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения процедуры контроля." +
                    "Пожалуйста, продолжайте работу.\n\rДля закрытия документа контроля воспользуйтесь командой" +
                    "\"Завершить контроль сборочного\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        #endregion

        #region ОТМЕНА КОНТРОЛЯ ЯЩИКА

        /// <summary>
        /// Отмена контроля ящика
        /// </summary>
        private void btnUndoDoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть документ контроля с ошибкой?",
                "Отмена контроля", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    long? doc_id = null;
                    taReceiveBoxRows.CloseDoc(DocID, UserID, 1, ref doc_id);    // Закріваем документ с ошибкой
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Возникла ошибка во время закрытия контроля ящика с ошибкой:", exc);
                }

                allowCloseWindow = true;
                Close();
            }
        }


        #endregion

        #region РАЗРИСОВКА СТРОК И УДАЛЕНИЕ ПУСТЫХ СТРОК

        /// <summary>
        /// Разрисовка строк
        /// </summary>
        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            // разрисовка строк в таблице, если не указана серия
            foreach (DataGridViewRow row in dgvLines.Rows)
            {
                Data.Interbranch.ReceiveBoxRowsRow diffRow = (Data.Interbranch.ReceiveBoxRowsRow)((DataRowView)row.DataBoundItem).Row;
                if (String.IsNullOrEmpty(diffRow.Vendor_Lot))
                {
                    Color backColor = AllQuantitiesZero(diffRow) ? Color.Red : Color.Yellow;
                    Color foreColor = AllQuantitiesZero(diffRow) ? Color.Yellow : Color.Red;
                    // строка отличается - подсвечиваем красным
                    for (int c = 0; c < row.Cells.Count; c++)
                        if (row.Cells[c] is DataGridViewDisableButtonCell) { }
                        else
                        {
                            row.Cells[c].Style.BackColor = backColor;
                            row.Cells[c].Style.ForeColor = foreColor;
                            row.Cells[c].Style.SelectionForeColor = backColor;
                        }
                    // прячем вывод кол-ва в информационной строке
                    row.Cells[clDocQty.Name].Style.ForeColor = backColor;
                    row.Cells[clDocQty.Name].Style.SelectionForeColor = SystemColors.Highlight;
                }
                else
                {
                    // простая разрисовка строк (уже не слепой контроль с 12.08.2010)
                    Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white") ? Color.White : Color.FromName(diffRow.Color);
                    for (int c = 0; c < row.Cells.Count; c++)
                        if (row.Cells[c] is DataGridViewDisableButtonCell) { }
                        else
                        {
                            row.Cells[c].Style.BackColor = backColor;
                            row.Cells[c].Style.SelectionForeColor = backColor;
                        }
                }
                if (clNoItem.Visible)
                    ((DataGridViewDisableButtonCell)row.Cells[clNoItem.Name]).ButtonVisible = (String.IsNullOrEmpty(diffRow.Vendor_Lot) && diffRow.Doc_Qty == 0);

                // отображение иконок термо-режима
                if (diffRow.IsSnowFlakeNull()) row.Cells[clSnowflake.DisplayIndex].Value = emptyBitmap;
                else row.Cells[clSnowflake.DisplayIndex].Value = (diffRow.SnowFlake == "R")
                    ? Properties.Resources.snowflakeR
                    : (diffRow.SnowFlake == "B")
                        ? Properties.Resources.snowflakeB
                        : emptyBitmap;
            }
        }

        /// <summary>
        /// Проверка, задан ли в строке вообще товар 
        /// </summary>
        /// <param name="pRow">Строка</param>
        /// <returns>True если по нулям кол-во товара, боя, НТВ и брака сразу</returns>
        private bool AllQuantitiesZero(Data.Interbranch.ReceiveBoxRowsRow pRow)
        {
            return pRow.Doc_Qty == 0 && pRow.Doc_Qty_NTV == 0 && pRow.Doc_Qty_BOY == 0 && pRow.Doc_Qty_Defect == 0;
        }

        /// <summary>
        /// Удаляем пустую строку при щелчке по ней
        /// </summary>
        private void gvLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLines.Columns[e.ColumnIndex].Name == clNoItem.Name)
                    if (((DataGridViewDisableButtonCell)dgvLines[e.ColumnIndex, e.RowIndex]).ButtonVisible)
                    {
                        int id = ((Data.Interbranch.ReceiveBoxRowsRow)((DataRowView)dgvLines.Rows[e.RowIndex].DataBoundItem).Row).Item_ID;
                        taReceiveBoxRows.DeleteBlankRows(DocID, id);
                        RefreshLines();
                    }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время удаления пустой строки:", exc);
            }
        }

        /// <summary>
        /// Ничего не делаем при ошибке редактирования
        /// </summary>
        private void gvLines_DataError(object sender, DataGridViewDataErrorEventArgs e) { }

        #endregion
    }
}
