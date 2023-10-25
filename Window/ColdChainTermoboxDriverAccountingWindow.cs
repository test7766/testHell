using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.ColdChainTableAdapters;
using WMSOffice.Dialogs.ColdChain;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно для выдачи теромобоксов водителям
    /// </summary>
    public partial class ColdChainTermoboxDriverAccountingWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Название таблицы с историей выдачи термобоксов в конфигурационном файле
        /// </summary>
        private string ConfigTableName { get { return String.Format("{0}_History", Name); } }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ColdChainTermoboxDriverAccountingWindow()
        {
            InitializeComponent();
            InitializeHistoryGrid();
        }

        /// <summary>
        /// Загрузка истории при загрузке окна
        /// </summary>
        private void TermoboxDriverAccountingWindow_Load(object sender, EventArgs e)
        {
            StartHistoryLoading();
        }

        /// <summary>
        /// Загрузка истории при нажатии на кнопку "Обновить"
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            StartHistoryLoading();
        }

        /// <summary>
        /// Сохранение порядка, ширины и сортировки колонок при закрытии окна
        /// </summary>
        private void TermoboxDriverAccountingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            egvHistory.SaveExtraDataGridViewSettings(ConfigTableName);
        }

        #endregion

        #region ТАБЛИЦА ИСТОРИИ ВЫДАЧИ ТЕРМОБОКСОВ ВОДИТЕЛЯМ

        /// <summary>
        /// Начальная инициализация фильтруемого грида с историей
        /// </summary>
        private void InitializeHistoryGrid()
        {
            egvHistory.Init(new TermoboxDriverAccountingView(), true);
            egvHistory.UserID = UserID;
            egvHistory.AllowRangeColumns = true;
            egvHistory.LoadExtraDataGridViewSettings(ConfigTableName);
        }

        /// <summary>
        /// Обновление данных в таблице истории
        /// </summary>
        private void StartHistoryLoading()
        {
            egvHistory.SaveExtraDataGridViewSettings(ConfigTableName);
            PrepareControlsWhenHistoryLoading(true);
            bgwHistoryLoader = new BackgroundWorker();
            bgwHistoryLoader.DoWork += bgwHistoryLoader_DoWork;
            bgwHistoryLoader.RunWorkerCompleted += bgwHistoryLoader_RunWorkerCompleted;
            bgwHistoryLoader.RunWorkerAsync(new TermoboxDriverAccountingSearchParameters { SessionID = UserID });
        }

        /// <summary>
        /// Изменение доступности/видимости элементов управления при начале/окончании асинхронной загрузки истории
        /// </summary>
        /// <param name="pStartLoading">True если начало загрузки, False если окончание загрузки</param>
        private void PrepareControlsWhenHistoryLoading(bool pStartLoading)
        {
            egvHistory.Enabled = btnRefresh.Enabled = !pStartLoading;
            pbSplashControl.Visible = btnCancelLoading.Visible = pStartLoading;
        }

        /// <summary>
        /// Асинхронная загрузка истории
        /// </summary>
        private void bgwHistoryLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var sc = e.Argument as TermoboxDriverAccountingSearchParameters;
                using (var adapter = new TD_get_termobox_drivers_historyTableAdapter())
                    e.Result = adapter.GetData(sc.SessionID);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание загрузки истории и отображение истории в гриде
        /// </summary>
        private void bgwHistoryLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке истории:", e.Result as Exception);
            else
                RefreshDataViewBinding(e.Result as ColdChain.TD_get_termobox_drivers_historyDataTable);

            egvHistory.LoadExtraDataGridViewSettings(ConfigTableName);
            PrepareControlsWhenHistoryLoading(false);
        }

        /// <summary>
        /// Отображение загруженной истории в фильтруемом гриде
        /// </summary>
        /// <param name="pData">Данные истории, которые нужно отобразить</param>
        private void RefreshDataViewBinding(ColdChain.TD_get_termobox_drivers_historyDataTable pData)
        {
            try
            {
                (egvHistory.DataView as TermoboxDriverAccountingView).FillData(pData);
                egvHistory.BindData(false);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время отображения истории: ", exc);
            }
        }

        /// <summary>
        /// Отмена текущей загрузки
        /// </summary>
        private void btnCancelLoading_Click(object sender, EventArgs e)
        {
            PrepareControlsWhenHistoryLoading(false);
            bgwHistoryLoader.RunWorkerCompleted -= bgwHistoryLoader_RunWorkerCompleted;
            bgwHistoryLoader = null;
        }

        /// <summary>
        /// Пересчет итоговых значений при изменении фильтра
        /// </summary>
        private void egvHistory_OnFilterChanged(object sender, EventArgs e)
        {
            var grid = sender as ExtraDataGridView;
            grid.RecalculateSummary();
        }

        #endregion

        #region ЭКСПОРТ В EXCEL

        /// <summary>
        /// Экспорт таблицы истории в CSV-файл
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                egvHistory.ExportToExcel("Экспорт истории выдачи термобоксов", "история выдачи термобоксов", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время экспорта таблицы истории в CSV-файл возникла ошибка:", exc);
            }
        }

        #endregion

        #region ВЫДАЧА И ВОЗВРАЩЕНИЕ ТЕРМОБОКСОВ

        /// <summary>
        /// Реализация действий по горячим клавишам
        /// </summary>
        private void ColdChainTermoboxDriverAccountingWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                btnRefresh_Click(btnRefresh, EventArgs.Empty);
            else if (e.KeyCode == Keys.F3)
                btnExportToExcel_Click(btnExportToExcel, EventArgs.Empty);
            else if (e.KeyCode == Keys.F4)
                btnLink_Click(btnLink, EventArgs.Empty);
            else if (e.KeyCode == Keys.F5)
                btnUnlink_Click(btnUnlink, EventArgs.Empty);
            else if (e.KeyCode == Keys.F6)
                btnMassLink_Click(btnMassLink, EventArgs.Empty);
        }

        /// <summary>
        /// Выдать термобокс водителю
        /// </summary>
        private void btnLink_Click(object sender, EventArgs e)
        {
            var window = new TermoboxDriverBarCodeEnteringForm(UserID, true);
            if (window.ShowDialog() == DialogResult.OK)
                StartHistoryLoading();
        }

        /// <summary>
        /// Вернуть термобокс
        /// </summary>
        private void btnUnlink_Click(object sender, EventArgs e)
        {
            var window = new TermoboxDriverBarCodeEnteringForm(UserID, false);
            if (window.ShowDialog() == DialogResult.OK)
                StartHistoryLoading();
        }

        /// <summary>
        /// Массовая выдача термобоксов
        /// </summary>
        private void btnMassLink_Click(object sender, EventArgs e)
        {
            Form window = null;
            bool needRefresh = false;

            do
            {
                window = new TermoboxDriverBarCodeEnteringForm(UserID, true);
                if (window.ShowDialog() == DialogResult.OK)
                    needRefresh = true;
            }
            while (window.DialogResult == DialogResult.OK);

            if (needRefresh)
                StartHistoryLoading();
        }

        #endregion
    }

    #region КЛАССЫ ДЛЯ ПОДДЕРЖКИ ФИЛЬТРУЕМОГО ГРИДА ВЫДАЧИ ТЕРМОБОКСОВ ВОДИТЕЛЯМ

    /// <summary>
    /// Представление для грида с историей выдачи термобоксов водителям
    /// </summary>
    public class TermoboxDriverAccountingView : IDataView
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
        /// Таблица данных, содержащая историю
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Таблица данных, содержащая историю
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Заполнение таблицы истории выдачи термобоксов водителям согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as TermoboxDriverAccountingSearchParameters;
            using (var adapter = new TD_get_termobox_drivers_historyTableAdapter())
                data = adapter.GetData(sc.SessionID);
        }

        /// <summary>
        /// Установка источника для грида истории выдачи термобоксов водителям
        /// </summary>
        /// <param name="pDataTable">Таблица с историей</param>
        public void FillData(ColdChain.TD_get_termobox_drivers_historyDataTable pDataTable)
        {
            data = pDataTable;
        }

        public TermoboxDriverAccountingView()
        {
            this.dataColumns.Add(new PatternColumn("ID термобокса", "termobox_number", new FilterCompareExpressionRule<Int32>("termobox_number"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Модель термобокса", "termobox_name", new FilterPatternExpressionRule("termobox_name"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("ФИО ответственного", "related_user", new FilterPatternExpressionRule("related_user"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("ID сенсора", "sensor_id", new FilterCompareExpressionRule<Int32>("sensor_id"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Сер. номер сенсора", "sn", new FilterPatternExpressionRule("sn"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("ID водителя", "issued_user_id", new FilterCompareExpressionRule<Int32>("issued_user_id"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("ФИО водителя", "issued_user", new FilterPatternExpressionRule("issued_user"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Дата/время с", "date_from", new FilterDateCompareExpressionRule("date_from"), SummaryCalculationType.Count) { Width = 115 });
            this.dataColumns.Add(new PatternColumn("Дата/время по", "date_to", new FilterDateCompareExpressionRule("date_to"), SummaryCalculationType.Count) { Width = 115 });
        }
    }

    /// <summary>
    /// Параметры получения истории выдачи термобоксов сотрудника
    /// </summary>
    public class TermoboxDriverAccountingSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }
    }

    #endregion
}
