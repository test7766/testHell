using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml;

using WMSOffice.Classes;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно для печати стикеров, запрещающих отбор из заблокированных мест
    /// </summary>
    public partial class QualityPrintBlockListsForPlacesWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// True, если в таблице заблокированных мест выделена хотя бы одна строка а если несколько, то все они имеют одинаковый 
        /// признак распечатанности
        /// False, если таблица пуста либо в таблице не выделено ни одной строки, либо выделены и распечатанные, и нераспечатанные стикеры
        /// </summary>
        private bool IsPlaceSelected
        {
            get
            {
                if (egvBlockedLocations.SelectedItem == null)
                    return false;
                bool printed = SelectedPlace.IsPrinted;
                foreach (var doc in SelectedPlaces)
                    if (printed != doc.IsPrinted)
                        return false;
                return true;
            }
        }

        /// <summary>
        /// Первая выбранная строка в таблице заблокированных мест либо null, если таблица пустая или в ней не выбрано ни одной строки
        /// </summary>
        private Quality.BP_Get_ProblemLocationsRow SelectedPlace
        {
            get { return egvBlockedLocations.SelectedItem as Quality.BP_Get_ProblemLocationsRow; }
        }

        /// <summary>
        /// Коллекция заблокированных мест, выделенных в таблице. Если не выделена ни одна строка в таблице, то коллекция пуста
        /// </summary>
        private List<Quality.BP_Get_ProblemLocationsRow> SelectedPlaces
        {
            get
            {
                return
                    egvBlockedLocations.SelectedItems.ConvertAll(
                    new Converter<DataRow, Quality.BP_Get_ProblemLocationsRow>(x => x as Quality.BP_Get_ProblemLocationsRow));
            }
        }

        /// <summary>
        /// Название таблицы с заблокированными местами в конфигурационном файле с настройками
        /// </summary>
        private string ConfigTableName { get { return String.Format("{0}_Places", Name); } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public QualityPrintBlockListsForPlacesWindow()
        {
            InitializeComponent();
            InitWarehousesComboBox();
            InitLevelsComboBox();
            InitializeLocationsGrid();
            InitPrinters();
        }

        /// <summary>
        /// Создание и инициализация выпадающего списка со складами
        /// </summary>
        private void InitWarehousesComboBox()
        {
            cmbWarehouses.ComboBox.DataSource = bsWarehouses;
            cmbWarehouses.ComboBox.DisplayMember = "Warehouse_DSC";
            cmbWarehouses.ComboBox.ValueMember = "Warehouse_ID";
        }

        /// <summary>
        /// Создание и инициализация выпадающего списка с этажами
        /// </summary>
        private void InitLevelsComboBox()
        {
            cmbLevels.ComboBox.DataSource = bsLevels;
            cmbLevels.ComboBox.DisplayMember = "Level";
            cmbLevels.ComboBox.ValueMember = "ID";
        }

        /// <summary>
        /// Инициализация списка доступных принтеров
        /// </summary>
        private void InitPrinters()
        {
            try
            {
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                    cmbPrinters.Items.Add(printerName);

                var tmpSettings = new PrinterSettings();
                cmbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        /// <summary>
        /// Загрузка данных в выпадающие списки и таблицу мест при загрузке окна
        /// </summary>
        private void QualityPrintBlockListsForPlacesWindow_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
            StartLocationsLoading();
        }

        /// <summary>
        /// Загрузка элементов для выпадающего списка складов
        /// </summary>
        private void LoadWarehouses()
        {
            try
            {
                taGetWarehouseList.Fill(quality.BP_GetWarehouseList, UserID);
                LoadLevels();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки элементов для выпадающего списка складов: ", exc);
            }
        }

        /// <summary>
        /// Загрузка этажей по выбранному складу
        /// </summary>
        private void cmbWarehouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLevels();
        }

        /// <summary>
        /// Загрузка элементов для выпадающего списка этажей
        /// </summary>
        private void LoadLevels()
        {
            try
            {
                if (cmbWarehouses.ComboBox.SelectedValue != null)
                    taGetLevelsList.Fill(quality.BP_GetLevelsList, UserID, cmbWarehouses.ComboBox.SelectedValue.ToString());
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки элементов для выпадающего списка этажей: ", exc);
            }
        }

        /// <summary>
        /// Запоминаем настройки таблицы при выходе из окна
        /// </summary>
        private void QualityPrintBlockListsForPlacesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            egvBlockedLocations.SaveExtraDataGridViewSettings(ConfigTableName);
        }

        #endregion

        #region ТАБЛИЦА ЗАБЛОКИРОВАННЫХ МЕСТ

        /// <summary>
        /// Инициализация фильтруемого грида с заблокированными местами
        /// </summary>
        private void InitializeLocationsGrid()
        {
            egvBlockedLocations.Init(new PrintBlockListsForPlacesView(), true);
            egvBlockedLocations.UserID = UserID;
            egvBlockedLocations.AllowRangeColumns = true;
            egvBlockedLocations.UseMultiSelectMode = true;
            egvBlockedLocations.LoadExtraDataGridViewSettings(ConfigTableName);
        }

        /// <summary>
        /// Обновление данных в таблице заблокированных мест
        /// </summary>
        private void StartLocationsLoading()
        {
            egvBlockedLocations.SaveExtraDataGridViewSettings(ConfigTableName);
            PrepareControlsWhenLocationsLoading(true);
            bgwLocationsLoader = new BackgroundWorker();
            bgwLocationsLoader.DoWork += bgwLocationsLoader_DoWork;
            bgwLocationsLoader.RunWorkerCompleted += bgwLocationsLoader_RunWorkerCompleted;
            var searchParameters = new PrintBlockListsForPlacesSearchParameters
            {
                SessionID = UserID,
                WarehouseId = cmbWarehouses.ComboBox.SelectedValue.ToString(),
                Level = Convert.ToInt32(cmbLevels.ComboBox.SelectedValue)
            };
            bgwLocationsLoader.RunWorkerAsync(searchParameters);
        }

        /// <summary>
        /// Изменение доступности/видимости элементов управления при начале/окончании асинхронной загрузки заблокированных мест
        /// </summary>
        /// <param name="pStartLoading">True если начало загрузки блокировок, False если окончание загрузки заблокированных мест</param>
        private void PrepareControlsWhenLocationsLoading(bool pStartLoading)
        {
            egvBlockedLocations.Enabled = btnRefresh.Enabled = miRefresh.Enabled = !pStartLoading;
            pbSplashControl.Visible = btnCancelLoading.Visible = miCancelLoading.Enabled = pStartLoading;
        }

        /// <summary>
        /// Асинхронная загрузка заблокированных мест
        /// </summary>
        private void bgwLocationsLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var sc = e.Argument as PrintBlockListsForPlacesSearchParameters;
                using (var adapter = new BP_Get_ProblemLocationsTableAdapter())
                    e.Result = adapter.GetData(sc.SessionID, sc.WarehouseId, sc.Level);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание загрузки заблокированных мест
        /// </summary>
        private void bgwLocationsLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке заблокированных мест:", e.Result as Exception);
            else
                RefreshDataViewBinding(e.Result as Quality.BP_Get_ProblemLocationsDataTable);

            egvBlockedLocations.LoadExtraDataGridViewSettings(ConfigTableName);
            PrepareControlsWhenLocationsLoading(false);
        }

        /// <summary>
        /// Отображение загруженных заблокированных мест в фильтруемом гриде
        /// </summary>
        /// <param name="pData">Данные о заблокированных местах, которые нужно отобразить</param>
        private void RefreshDataViewBinding(Quality.BP_Get_ProblemLocationsDataTable pData)
        {
            try
            {
                (egvBlockedLocations.DataView as PrintBlockListsForPlacesView).FillData(pData);
                egvBlockedLocations.BindData(false);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время отображения заблокированных мест: ", exc);
            }
        }

        /// <summary>
        /// Отмена текущей загрузки
        /// </summary>
        private void btnCancelLoading_Click(object sender, EventArgs e)
        {
            PrepareControlsWhenLocationsLoading(false);
            bgwLocationsLoader.RunWorkerCompleted -= bgwLocationsLoader_RunWorkerCompleted;
            bgwLocationsLoader = null;
        }

        /// <summary>
        /// Раскраска напечатанных строк зеленым цветом
        /// </summary>
        private void egvBlockedLocations_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            var row = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Quality.BP_Get_ProblemLocationsRow;
            e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = row.IsPrinted ? Color.LightGreen : Color.White;
        }

        /// <summary>
        /// Обновление списка заблокированных мест
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            StartLocationsLoading();
        }

        /// <summary>
        /// Настройка доступности кнопок в зависимости от выбранных в таблице строк
        /// </summary>
        private void egvBlockedLocations_OnRowSelectionChanged(object sender, EventArgs e)
        {
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок в зависимости от выбранных в таблице строк
        /// </summary>
        private void CustomButtons()
        {
            btnPrintStickers.Enabled = miPrintStickers.Enabled = SelectedPlaces.Count > 0 && cmbPrinters.SelectedItem != null;
        }

        #endregion

        #region ПЕЧАТЬ СТИКЕРОВ

        /// <summary>
        /// Запуск фоновой печати выбранных в таблице стикеров
        /// </summary>
        private void btnPrintStickers_Click(object sender, EventArgs e)
        {
            var bgwPrintWorker = new BackgroundWorker();
            bgwPrintWorker.DoWork += bgwPrintWorker_DoWork;
            bgwPrintWorker.RunWorkerCompleted += bgwPrintWorker_RunWorkerCompleted;
            var pdParams = new PrintDocsParameters { PrinterName = cmbPrinters.SelectedItem.ToString(), Docs = SelectedPlaces.ToArray() };
            bgwPrintWorker.RunWorkerAsync(pdParams);
        }

        /// <summary>
        /// Асинхронная печать выбранных документов
        /// </summary>
        private void bgwPrintWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = e.Argument as PrintDocsParameters;
                var ds = new Quality();
                foreach (Quality.BP_Get_ProblemLocationsRow place in param.Docs)
                {
                    foreach (Quality.BP_GetLocationInfoRow item in GetItemsForLocation(place).Rows)
                        using (var report = new QualityBlockStickerReport())
                        {
                            FillDataForReport(ds, item);
                            report.SetDataSource(ds);
                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.PrintToPrinter(1, true, 1, 0);
                        }

                    using (var adapter = new BP_GetLocationInfoTableAdapter())
                        adapter.SetPrinted(UserID, CreateSelectedLocationsXml(new Quality.BP_Get_ProblemLocationsRow[1] { place }));
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание печати (вывод ошибки на экран, если такая была)
        /// </summary>
        private void bgwPrintWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка во время печати стикеров: ", e.Result as Exception);
            else
                MessageBox.Show("Стикеры по выделенным местам отправлены на печать!", 
                    "Печать стикеров", MessageBoxButtons.OK, MessageBoxIcon.Information);

            StartLocationsLoading();
        }

        /// <summary>
        /// Получение товаров, которые хранятся на заданном месте
        /// </summary>
        /// <param name="pPlace">Место, с которого нужно получить товары</param>
        /// <returns>Таблица товаров, которые хранятся на заданном месте</returns>
        private Quality.BP_GetLocationInfoDataTable GetItemsForLocation(Quality.BP_Get_ProblemLocationsRow pPlace)
        {
            try
            {
                using (var adapter = new BP_GetLocationInfoTableAdapter())
                {
                    var table = adapter.GetData(UserID, pPlace.Warehouse_ID, pPlace.Location);
                    if (table != null)
                        return table;
                    else
                        throw new ApplicationException("Процедура получения товаров на месте вернула NULL!");
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(String.Format("Возникла ошибка во время получения товаров с места {0}", pPlace.Location), exc);
                return new Quality.BP_GetLocationInfoDataTable();
            }
        }

        /// <summary>
        /// Заполнение информации для стикера
        /// </summary>
        /// <param name="pData">DataSet, который нужно наполнить</param>
        /// <param name="pItem">Товар, по которому нужно напечатать отчет</param>
        private void FillDataForReport(Quality pData, Quality.BP_GetLocationInfoRow pItem)
        {
            using (var adapter = new BP_Doc_GetHeaderTableAdapter())
                adapter.Fill(pData.BP_Doc_GetHeader, UserID, pItem.Warehouse_ID, pItem.Location_ID,
                    Convert.ToInt32(pItem.Item_ID), pItem.Hold_ID);
            using (var adapter = new BP_Doc_GetDetailTableAdapter())
                adapter.Fill(pData.BP_Doc_GetDetail, UserID, pItem.Warehouse_ID, pItem.Location_ID,
                    Convert.ToInt32(pItem.Item_ID), pItem.Hold_ID);
        }

        /// <summary>
        /// Формирование XML-строки для передачи в процедуру подтверждения печати
        /// </summary>
        private string CreateSelectedLocationsXml(IEnumerable<Quality.BP_Get_ProblemLocationsRow> pPlaces)
        {
            var doc = new XmlDocument();
            var root = (XmlElement)doc.AppendChild(doc.CreateElement("Root"));
            foreach (var place in pPlaces)
            {
                var row = (XmlElement)root.AppendChild(doc.CreateElement("Row"));
                row.SetAttribute("warehouse_id", place.Warehouse_ID);
                row.SetAttribute("location_id", place.Location);
            }

            return root.InnerXml;
        }

        #endregion
    }

    #region КЛАССЫ ДЛЯ ПОДДЕРЖКИ ФИЛЬТРУЕМОГО ГРИДА ЗАБЛОКИРОВАННЫХ МЕСТ

    /// <summary>
    /// Представление для грида с заблокированными местами
    /// </summary>
    public class PrintBlockListsForPlacesView : IDataView
    {
        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Таблица данных, содержащая места с заблокированным товаром
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Таблица данных, содержащая места с заблокированным товаром
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Заполнение таблицы заблокированных мест согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as PrintBlockListsForPlacesSearchParameters;
            using (var adapter = new BP_Get_ProblemLocationsTableAdapter())
                data = adapter.GetData(sc.SessionID, sc.WarehouseId, sc.Level);
        }

        /// <summary>
        /// Установка источника для грида мест з заблокированным товаром
        /// </summary>
        /// <param name="pDataTable">Таблица с местами с заблокированным товаром</param>
        public void FillData(Quality.BP_Get_ProblemLocationsDataTable pDataTable)
        {
            data = pDataTable;
        }

        public PrintBlockListsForPlacesView()
        {
            this.dataColumns.Add(new PatternColumn("Склад", "Warehouse", new FilterPatternExpressionRule("Warehouse"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Этаж", "Level", new FilterPatternExpressionRule("Level"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Место", "Location", new FilterPatternExpressionRule("Location"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("ID Товара", "Item_ID", new FilterPatternExpressionRule("Item_ID"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "Item", new FilterPatternExpressionRule("Item"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Распечатан", "IsPrintedDesc", new FilterPatternExpressionRule("IsPrintedDesc"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Блокировка", "Hold", new FilterPatternExpressionRule("Hold"), SummaryCalculationType.Count) { Width = 400 });
        }
    }

    /// <summary>
    /// Параметры получения списка заблокированных мест
    /// </summary>
    public class PrintBlockListsForPlacesSearchParameters : SessionIDSearchParameters
    {
        /// <summary>
        /// Склад, на котором ищем места
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// Этаж, на котором ищем места
        /// </summary>
        public int Level { get; set; }
    }

    #endregion
}
