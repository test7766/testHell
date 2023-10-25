using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Data;
using WMSOffice.Dialogs.Containers;
using WMSOffice.Dialogs.Quality;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.ComponentModel;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно для работы с направлениями в лабораторию (отдел качества)
    /// </summary>
    public partial class QualityDirectionWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Название таблицы с направлениями в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDirectionsTableName { get { return String.Format("{0}_Directions", Name); } }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Направление, выделенное в таблице
        /// </summary>
        public Quality.DRDocsRow SelectedDoc
        {
            get
            {
                if (xdgvDocs.SelectedItems.Count != 1)
                    return null;
                else
                    return xdgvDocs.SelectedItems[0] as Quality.DRDocsRow;
            }
        }

        /// <summary>
        /// Строки направления, выделенные в таблице
        /// </summary>
        public Quality.DRDocRowsRow[] SelectedLines
        {
            get
            {
                var list = new List<Quality.DRDocRowsRow>();
                foreach (DataGridViewRow row in dgvLines.SelectedRows)
                    list.Add((row.DataBoundItem as DataRowView).Row as Quality.DRDocRowsRow);
                return list.ToArray();
            }
        }

        #endregion

        #region КОНСТРУКТОР, ИНИЦИАЛИЗАЦИЯ И ЗАГРУЗКА НАПРАВЛЕНИЙ

        /// <summary>
        /// Идентификатор направления, выбранного в таблице или null, если в таблице не выбрано ни одно направление
        /// </summary>
        private long? selectedDocID;

        public QualityDirectionWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка направлений при загрузке окна
        /// </summary>
        private void QualityRequestWindow_Load(object sender, EventArgs e)
        {
            Initialize();
            RefreshDocs();
        }

        private void Initialize()
        {
            xdgvDocs.UserID = this.UserID;

            //this.xdgvDocs.AllowFilter = false;
            this.xdgvDocs.AllowSummary = false;
            this.xdgvDocs.AllowRangeColumns = true;

            this.xdgvDocs.SetSameStyleForAlternativeRows();
            this.xdgvDocs.SetCellStyles(dgvLines.RowTemplate.DefaultCellStyle, dgvLines.ColumnHeadersDefaultCellStyle);
            this.xdgvDocs.FilterGrid.DefaultCellStyle = dgvLines.DefaultCellStyle;
            this.xdgvDocs.SummaryGrid.DefaultCellStyle = dgvLines.DefaultCellStyle;

            this.xdgvDocs.DataGrid.ContextMenuStrip = cmsDocs;

            this.xdgvDocs.Init(new QualityDirectionsDocsView(), true);
            this.xdgvDocs.LoadExtraDataGridViewSettings(this.ConfigDirectionsTableName);

            xdgvDocs.OnRowSelectionChanged += new EventHandler(dgvDocs_SelectionChanged);
            xdgvDocs.OnRowDoubleClick += new DataGridViewCellEventHandler(dgvDocs_CellDoubleClick);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();
        }

        /// <summary>
        /// Загрузка направлений в таблицу
        /// </summary>
        private void RefreshDocs()
        {
            try
            {
                var searchCriteria = new QualityDirectionsDocsSearchParameters() { SessionID = UserID };
                searchCriteria.SearchText = tbxSearch.Text;
                searchCriteria.ShowArchived = chbShowArchived.Checked;

                xdgvDocs.SaveExtraDataGridViewSettings(this.ConfigDirectionsTableName);
                SaveSelection();                

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) => 
                {
                    xdgvDocs.DataView.FillData(e.Argument as QualityDirectionsDocsSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) => 
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        xdgvDocs.BindData(false);
                        xdgvDocs.AllowSummary = true;

                        xdgvDocs.LoadExtraDataGridViewSettings(this.ConfigDirectionsTableName);
                        RestoreSelection();
                    }

                    waitProgressForm.CloseForce();
                };
                bw.RunWorkerAsync(searchCriteria);

                waitProgressForm.ActionText = "Выполняется загрузка данных..";
                waitProgressForm.ShowDialog();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки направлений:", exc);
            }
        }

        /// <summary>
        /// Сохранение текущего положения скроллинга и выделенного направления в таблице
        /// </summary>
        private void SaveSelection()
        {
            selectedDocID = SelectedDoc == null ? null : (long?)SelectedDoc.Doc_ID;
        }

        /// <summary>
        /// Выделение строки и отображение строки, которая была выделена и отображена до обновления талицы
        /// </summary>
        private void RestoreSelection()
        {
           
            xdgvDocs.UnselectAllRows();

            bool isSelected = false;
            xdgvDocs.SelectRow("Doc_ID", selectedDocID.ToString());
            isSelected = true;

            if (!isSelected)
                xdgvDocs.SelectRow(0);
            
            xdgvDocs.ScrollToSelectedRow();
        }

        /// <summary>
        /// Обновление таблицы направлений по нажатию на кнопку либо с помощью пункта контекстного меню
        /// </summary>
        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        /// <summary>
        /// Обновление строк направления и обновление панели инструментов при изменении выделенного направления в таблице
        /// </summary>
        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            RefreshLines();
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели инструментов в зависимости от выбранного направления в таблице
        /// </summary>
        private void CustomButtons()
        {
            btnCollect.Visible = btnCollect.Enabled = xdgvDocs.SelectedItems.Count == 1 && SelectedDoc.Status_ID == Constants.QK_STATUS_DD_210;
            foreach (DataGridViewRow dgvrow in dgvLines.Rows)
            {
                var dbrow = (dgvrow.DataBoundItem as DataRowView).Row as Quality.DRDocRowsRow;
                if (!dbrow.Has_Docs_Ready || !dbrow.Has_Items_Table)
                {
                    btnCollect.Visible = btnCollect.Enabled = false;
                    break;
                }
            }

            btnMoveItems.Visible = btnMoveItems.Enabled = xdgvDocs.SelectedItems.Count == 1 && SelectedDoc.Status_ID == Constants.QK_STATUS_DD_219;
            btnToPannedCar.Visible = btnToPannedCar.Enabled = xdgvDocs.SelectedItems.Count == 1 && 
                SelectedDoc.Status_ID == Constants.QK_STATUS_DD_215 && !SelectedDoc.is_kiev;
            btnReceiveItems.Visible = btnReceiveItems.Enabled = xdgvDocs.SelectedItems.Count == 1 &&
                SelectedDoc.Status_ID == Constants.QK_STATUS_DD_218;
            btnCancelDirection.Visible = btnCancelDirection.Enabled = xdgvDocs.SelectedItems.Count == 1 &&
                Convert.ToInt32(SelectedDoc.Status_ID) == Convert.ToInt32(Constants.QK_STATUS_DD_210);
        }

        /// <summary>
        /// Обновление строк по выделенному в таблице направлению
        /// </summary>
        private void RefreshLines()
        {
            quality.DRDocRows.Clear();
            if (xdgvDocs.SelectedItems.Count > 0)
                taDrDocRows.Fill(quality.DRDocRows, SelectedDoc.Doc_ID);
            CustomLinesButton();
        }
        /// <summary>
        /// По нажатию на Enter в строке фильтра перезагружаем список направлений с учетом фильтра
        /// </summary>
        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                tbxSearch.BackColor = (String.IsNullOrEmpty(tbxSearch.Text)) ? SystemColors.Window : SystemColors.Info;
                RefreshDocs();
            }
        }

        /// <summary>
        /// Закрашивание ячеек "Таблица образцов" и "Готовы документы" в красный цвет, если стоит значение "нет"
        /// </summary>
        private void dgvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var diffRow = (row.DataBoundItem as DataRowView).Row as Quality.DRDocRowsRow;
                if (!diffRow.Has_Items_Table)
                    row.Cells[clHasItemsTableStr.Name].Style.BackColor = row.Cells[clHasItemsTableStr.Name].Style.SelectionForeColor = 
                        Color.FromArgb(255, 153, 153);
                if (!diffRow.Has_Docs_Ready)
                    row.Cells[clHasDocsReadyStr.Name].Style.BackColor = row.Cells[clHasDocsReadyStr.Name].Style.SelectionForeColor =
                             Color.FromArgb(255, 153, 153);
            }
        }

        /// <summary>
        /// Сохранение настроек при закрытии окна
        /// </summary>
        private void QualityDirectionWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            xdgvDocs.SaveExtraDataGridViewSettings(this.ConfigDirectionsTableName);
        }

        #endregion    

        #region СОЗДАНИЕ И РЕДАКТИРОВАНИЕ НАПРАВЛЕНИЯ

        /// <summary>
        /// Создание нового направления
        /// </summary>
        private void CreateDirection_Click(object sender, EventArgs e)
        {
            var newDirectionForm = new DirectionForm(UserID) { Owner = this };
            if (newDirectionForm.ShowDialog() == DialogResult.OK)
                RefreshDocs();
        }

        #endregion

        #region ПЕРЕХОД НАПРАВЛЕНИЯ ПО СТАТУСАМ

        /// <summary>
        /// Перевод направления на статус "Сформировано задание на отбор образцов"
        /// </summary>
        private void btnCollect_Click(object sender, EventArgs e)
        {
            ChangeStatusTo(Constants.QK_STATUS_DD_215, null);
        }

        /// <summary>
        /// Перевод выбранного в таблице направления на новый статус
        /// </summary>
        /// <param name="pNewStatus">Статус, на который нужно перевести направление</param>
        /// <param name="pStatusDate">Дата перевода статуса</param>
        private void ChangeStatusTo(string pNewStatus, DateTime? pStatusDate)
        {
            ChangeStatusTo(pNewStatus, pStatusDate, (int?)null, (string)null);
        }
        
        private void ChangeStatusTo(string pNewStatus, DateTime? pStatusDate, int? cancelReasonID, string cancelDescription)
        {
            try
            {
                taDrDocs.StatusUpdate(SelectedDoc.Doc_ID, UserID, pNewStatus, pStatusDate, cancelReasonID, cancelDescription);
                RefreshDocs();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при переводе направления на новый статус:", exc);
            }
        }

        /// <summary>
        /// Внесение в систему факта передачи образцов в лабораторию
        /// </summary>
        private void MoveItems_Click(object sender, EventArgs e)
        {
            var dateForm = new SetDateForm();
            dateForm.DateTypeString = sender == btnMoveItems ? "Передано:" : "Отправлено:";
            if (dateForm.ShowDialog() == DialogResult.OK)
                ChangeStatusTo(sender == btnMoveItems ? Constants.QK_STATUS_DD_220 : Constants.QK_STATUS_DD_218, dateForm.SelectedDate);
        }

        /// <summary>
        /// Сканирование товара из направления, чтобы перевести его на статус 219
        /// </summary>
        private void btnReceiveItems_Click(object sender, EventArgs e)
        {
            var scanForm = new ScanContainerForm
            {
                Label = "Відскануйте штрих-код ящика з товаром для лабораторії: ",
                Text = "Сканування товару"
            };
            if (scanForm.ShowDialog(this) == DialogResult.OK)
                if (CheckBarcode(scanForm.Barcode))
                    ChangeStatusTo(Constants.QK_STATUS_DD_219, DateTime.Now);
        }

        /// <summary>
        /// Проверка, является ли заданный штрих-код штрих-кодом ящика с товарами для направления
        /// </summary>
        /// <param name="pBarcode">Штрих-код ящика</param>
        /// <returns>True если заданный штрих-код является штрих-кодом ящика с товарами для направления, 
        /// False в противном случае</returns>
        private bool CheckBarcode(string pBarcode)
        {
            try
            {
                if (!Convert.ToBoolean(taDrDocs.CheckBarcode(UserID, SelectedDoc.Doc_ID, pBarcode)))
                {
                    Logger.ShowErrorMessageBox("Отсканированный штрих-код не является штрих-кодом ящика с товаром в направлении!");
                    return false;
                }
                else
                    return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время проверки штрих-кода: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Аннулирование направления
        /// </summary>
        private void btnCancelDirection_Click(object sender, EventArgs e)
        {
            string msg = "Ви дійсно бажаєте анулювати направлення?";
            if (MessageBox.Show(msg, "Підтвердження дії", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var dlgDirectionCancellationReason = new DirectionCancellationReasonForm() { UserID = this.UserID };
                if (dlgDirectionCancellationReason.ShowDialog() == DialogResult.OK)
                    ChangeStatusTo(Constants.QK_STATUS_DD_999, DateTime.Now, dlgDirectionCancellationReason.CancelReasonID, dlgDirectionCancellationReason.CancelDescription);
            }
        }

        #endregion        

        #region ОБРАЗЦЫ И ГОТОВНОСТЬ ДОКУМЕНТОВ

        /// <summary>
        /// Настройка доступности кнопок на панели инструментов строк направления при изменении выделенных в таблице строк направления
        /// </summary>
        private void dgvLines_SelectionChanged(object sender, EventArgs e)
        {
            CustomLinesButton();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели инструментов строк направления в зависимости от строк, выбранных в направлении
        /// </summary>
        private void CustomLinesButton()
        {
            // Настройка доступности кнопок подготовки направления
            if (SelectedDoc == null || SelectedDoc.Status_ID != Constants.QK_STATUS_DD_210 || dgvLines.SelectedRows.Count == 0)
                btnItemsTable.Enabled = btnReadyDocs.Enabled = false;
            else
            {
                btnItemsTable.Enabled = btnReadyDocs.Enabled = true;
                foreach (var line in SelectedLines)
                {
                    if (line.Has_Items_Table)
                        btnItemsTable.Enabled = false;
                    // -> [GSPO-3822]
                    //if (!line.Has_Items_Table || line.Has_Docs_Ready)
                    //    btnReadyDocs.Enabled = false;
                }
            }

            // Настройка доступности кнопок промежуточных этапов анализа
            if (SelectedDoc == null || SelectedDoc.Status_ID != Constants.QK_STATUS_DD_220 || dgvLines.SelectedRows.Count == 0)
                miDateSamplesRequest.Enabled = miSamplesPurchase.Enabled = miSamplesComplete.Enabled = false;
            else
            {
                miDateSamplesRequest.Enabled = miSamplesPurchase.Enabled = miSamplesComplete.Enabled = true;
                foreach (var line in SelectedLines)
                {
                    if (!line.IsDate_Samples_RequestNull() || !line.IsDate_Samples_PurchaseNull() || !line.IsDate_Samples_CompleteNull())
                        miDateSamplesRequest.Enabled = false;
                    if (!line.IsDate_Samples_PurchaseNull() || !line.IsDate_Samples_CompleteNull())
                        miSamplesPurchase.Enabled = false;
                    if (!line.IsDate_Samples_CompleteNull())
                        miSamplesComplete.Enabled = false;
                }
            }
            spbIntermediateStages.Enabled = miDateSamplesRequest.Enabled || miSamplesPurchase.Enabled || miSamplesComplete.Enabled;
        }

        /// <summary>
        /// Внесение в систему факта заполнения таблицы образцов поставщиком или факта наличия готовых документов
        /// </summary>
        private void DocsDetailAction_Click(object sender, EventArgs e)
        {
            string msg = GetMsgBySender(sender);
            if (MessageBox.Show(msg, "Підтвердження дії", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    foreach (var line in SelectedLines)
                        taDrDocRows.UpdateDocsDetail(UserID, line.Doc_ID, line.Line_ID, 
                            Convert.ToInt32(GetDetailActionBySender(sender)));
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Возникла ошибка во время внесения изменений в БД:", exc);
                }
                finally
                {
                    RefreshLines();
                    CustomButtons();
                }
        }

        /// <summary>
        /// Получение сообщения подтверждения действия в зависимости от того, какая кнопка была нажата
        /// </summary>
        /// <param name="pSender">Кнопка, которая была нажата</param>
        /// <returns>Сообщение подтверждения</returns>
        private string GetMsgBySender(object pSender)
        {
            if (pSender == btnItemsTable)
                return "Ви впевнені, що хочете зазначити в системі факт отримання таблиці зразків від Постачальника по обраним рядкам направлення?";
            else if (pSender == btnReadyDocs)
                return "Ви впевнені, що хочете зазначити в системі факт готовності документів за обраними рядками направлення?";
            else if (pSender == miDateSamplesRequest)
                return "Ви впевнені, що хочете зазначити в системі факт запиту лабораторією зразків у постачальника?";
            else if (pSender == miSamplesPurchase)
                return "Ви впевнені, що хочете зазначити в системі факт початку закупівлі зразків лабораторією?";
            else if (pSender == miSamplesComplete)
                return "Ви впевнені, що хочете зазначити в системі факт закінчення закупівлі зразків лабораторією?";
            else
                return String.Empty;
        }

        /// <summary>
        /// Получение действия со строкой заявки в зависимости от того, какая кнопка была нажата
        /// </summary>
        /// <param name="pSender">Кнопка, которая была нажата</param>
        /// <returns>Действие, которое нужно выполнить со строкой заявки</returns>
        private UpdateDetailActions GetDetailActionBySender(object pSender)
        {
            if (pSender == btnItemsTable)
                return UpdateDetailActions.ItemsTable;
            else if (pSender == btnReadyDocs)
                return UpdateDetailActions.DocsReady;
            else if (pSender == miDateSamplesRequest)
                return UpdateDetailActions.SamplesRequested;
            else if (pSender == miSamplesPurchase)
                return UpdateDetailActions.SamplesPurchaseStarted;
            else if (pSender == miSamplesComplete)
                return UpdateDetailActions.SamplesComplete;
            else
                throw new ArgumentException("Не предусмотрено действие!");
        }

        #endregion

        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (!SelectedDoc.IsPrinted_DSCNull() && !string.IsNullOrEmpty(SelectedDoc.Printed_DSC))
                MessageBox.Show(SelectedDoc.Printed_DSC, "Сборочный не может быть напечатан по причине:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    #region ВОЗМОЖНЫЕ ДЕЙСТВИЯ СО СТРОКОЙ НАПРАВЛЕНИЯ

    /// <summary>
    /// Идентификаторы действий со строкой направления
    /// </summary>
    public enum UpdateDetailActions
    {
        /// <summary>
        /// Внесение факта заполнения поставщиком таблицы образцов
        /// </summary>
        ItemsTable = 1,

        /// <summary>
        /// Внесение факта подготовки документов по строке направления
        /// </summary>
        DocsReady = 2,

        /// <summary>
        /// Лабораторией запрошены образцы у поставщика
        /// </summary>
        SamplesRequested = 3,

        /// <summary>
        /// Начата закупка образцов лабораторией
        /// </summary>
        SamplesPurchaseStarted = 4,

        /// <summary>
        /// Образцы закуплены - можно проводить анализ
        /// </summary>
        SamplesComplete = 5
    }

    #endregion

    /// <summary>
    /// Представление для грида с документами направлений
    /// </summary>
    public class QualityDirectionsDocsView : IDataView
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #endregion

        #region РЕАЛИЗАЦИЯ ИНТЕРФЕЙСА IDataView

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as QualityDirectionsDocsSearchParameters;

            using (var adapter = new Data.QualityTableAdapters.DRDocsTableAdapter())
                data = adapter.GetData(String.Format("%{0}%", sc.SearchText), sc.ShowArchived);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public QualityDirectionsDocsView()
        {
            this.dataColumns.Add(new PatternColumn("Номер", "Doc_Number", new FilterPatternExpressionRule("Doc_Number")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Дата направлення", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count) { Width = 30 });
            this.dataColumns.Add(new PatternColumn("Статус", "StatusName", new FilterPatternExpressionRule("StatusName")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("На статусі з", "status_from", new FilterDateCompareExpressionRule("status_from")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Місто", "city", new FilterPatternExpressionRule("city"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Лабораторія", "Location_Name", new FilterPatternExpressionRule("Location_Name"), SummaryCalculationType.Count) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Дата отримання", "ReceiptDate", new FilterDateCompareExpressionRule("ReceiptDate")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Змінив", "Users", new FilterPatternExpressionRule("Users")) { Width = 230 });
            this.dataColumns.Add(new PatternColumn("Створив", "User_Created", new FilterPatternExpressionRule("User_Created")) { Width = 230 });
            this.dataColumns.Add(new PatternColumn("ID", "Doc_ID", new FilterCompareExpressionRule<Int32>("Doc_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Причина анулювання", "Cancel_Reason_Name", new FilterPatternExpressionRule("Cancel_Reason_Name")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("Опис причини", "Cancel_Description", new FilterPatternExpressionRule("Cancel_Description")) { Width = 250 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка накладных
    /// </summary>
    public class QualityDirectionsDocsSearchParameters : SessionIDSearchParameters
    {
        public string SearchText { get; set; }
        public bool ShowArchived { get; set; }

        public QualityDirectionsDocsSearchParameters()
        {
            
        }
    }
}
