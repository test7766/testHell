using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Classes.ReportProviders;
using WMSOffice.Classes.SearchParameters;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Dialogs.Quality;
using WMSOffice.Dialogs.Sert;
using WMSOffice.Properties;
using WMSOffice.Reports;
using WMSOffice.Data.SertTableAdapters;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class QualityRequestWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Окно ожидания, которое отображается при длительных операциях
        /// </summary>
        private SplashForm waitProcessForm = new SplashForm();

        private string FilterDoc = String.Empty;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public QualityRequestWindow()
        {
            InitializeComponent();

            InitializeQualityRequestGrid();
            clIsProblemIcon.DefaultCellStyle.NullValue = null;
            climgIsRepeatedLot.DefaultCellStyle.NullValue = null;
        }

        /// <summary>
        /// Инициализация окна
        /// </summary>
        private void QualityRequestWindow_Load(object sender, EventArgs e)
        {
            LoadUserAccesses();
            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);
            spReportProvider = new QualitySellPermissionReportProvider(UserID);
            tbxDocID.Focus();

            cmbDocCode.DataSource = new DocCode[] { 
                new DocCode { Code = null, Name = "(Всі)" }, 
                new DocCode { Code = "LEK", Name = "Лік. засоби" }, 
                new DocCode { Code = "IMN", Name = "Імунобіологія" } };

            cmbDocCode.SelectedValueChanged += new EventHandler(cmbDocCode_SelectedValueChanged);
            cmbDocCode.SelectedValue = "LEK";

            ExecuteCheckTasks();
        }

        void cmbDocCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDocCode.SelectedValue == null)
                FilterDoc = String.Empty;
            else
            {
                var selectedValue = cmbDocCode.SelectedValue.ToString();
                if (String.IsNullOrEmpty(selectedValue))
                    FilterDoc = String.Empty;
                else
                    FilterDoc = selectedValue;
            }

            RefreshDocs();
        }


        /// <summary>
        /// Загрузка прав пользователя на кнопки
        /// </summary>
        private void LoadUserAccesses()
        {
            try
            {
                using (var adapter = new QK_Get_Sell_Permission_Printing_AccessTableAdapter())
                {
                    var tbl = adapter.GetData(UserID);
                    if (tbl == null || tbl.Count == 0)
                        throw new ApplicationException("Процедура получения прав доступа не вернула данные!");
                    canPrintPermission = tbl[0].can_print_permission;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки прав доступа пользователя: ", exc);
                canPrintPermission = false;
            }
        }

        /// <summary>
        /// При отображении окна сразу же загружаем режим отображения строк, по которым были заключения, но
        /// которые не были распечатаны
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            VerifyPrintSertSettings();
            cmbLotFilter.SelectedIndexChanged += cmbLotFilter_SelectedIndexChanged;
            cmbLotFilter.SelectedIndex = UNPRINTED_LINES_INDEX;
        }

        #endregion

        #region ПЕЧАТЬ СЕРТИФИКАТОВ

        /// <summary>
        /// Проверка, были ли заданы настройки печати сертификатов на данном компьютере
        /// </summary>
        private void VerifyPrintSertSettings()
        {
            try
            {
                using (var adapter = new Data.SertTableAdapters.QueriesTableAdapter())
                {
                    var settings = adapter.GetSettings(Environment.MachineName);
                    if (settings != null)
                        SertPrintSettings.ParseXML(settings.ToString());
                    else
                        MessageBox.Show("Печать сертификатов не настраивалась ранее на текущем компьютере." +
                            " Откройте диалог настроек и введите нужные параметры.",
                            "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("При загрузке настроек возникла следующая ошибка: ", exc);
            }
        }

        /// <summary>
        /// Настройка печати сертификатов на компьютере
        /// </summary>
        private void btnSertPrintSettings_Click(object sender, EventArgs e)
        {
            var form = new SertPrintSettingsForm(UserID) { DisableHistory = true };
            form.ShowDialog(this);
        }

        #endregion

        #region ТАБЛИЦА ЗАЯВОК

        /// <summary>
        /// Идентификатор заявки в таблице, которая была выделена перед моментом последнего обновления таблицы заявок
        /// </summary>
        private long? selectedDocID;

        /// <summary>
        /// True если в данный момент загружаются заявки, False в противном случае
        /// </summary>
        private bool isDocLoading;

        /// <summary>
        /// True если нужно будет обновлять строки после изменения выделенной заявки, False если нет
        /// </summary>
        private bool needRefreshLines;

        /// <summary>
        /// True если информация о выделенных строках была сохранена перед загрузкой заявок
        /// False если эту информацию нужно сохранить перед загрузкой строк заявки
        /// </summary>
        private bool wasLinesSelectionSaved;

        /// <summary>
        /// Идентификатор текущей выбранной заявки в списке заявок. 
        /// Если в таблице заявок не выбрана ни одна строка, будет выдано исключение
        /// </summary>
        private int CurrentDocId { get { return Convert.ToInt32(edgDocs.SelectedItem[QualityRequestView.ID_PROPERTY_NAME]); } }

        /// <summary>
        /// True если в таблице заявок выделена хотя бы одна строка, False в противном случае
        /// </summary>
        private bool IsDocSelected { get { return edgDocs.SelectedItem != null; } }

        /// <summary>
        /// Заявка, выделенная в таблице либо null, если не выделена ни одна заявка
        /// </summary>
        public Quality.DocsRow SelectedDoc { get { return edgDocs.SelectedItem as Quality.DocsRow; } }

        /// <summary>
        /// Возможность печати пакета документов для иммуно
        /// </summary>
        //private bool IsImnPrintDoc { get { return SelectedDoc != null && SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN && SelectedDoc.Status_ID == Constants.QK_STATUS_D_110; } }

        /// <summary>
        /// Инициализация фильтруемого грида с заявками
        /// </summary>
        private void InitializeQualityRequestGrid()
        {
            edgDocs.Init(new QualityRequestView(), true);
            edgDocs.LoadExtraDataGridViewSettings(Name);
            edgDocs.UserID = UserID;
            edgDocs.SetCellStyles(dgvLines.RowTemplate.DefaultCellStyle, dgvLines.ColumnHeadersDefaultCellStyle);
            edgDocs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            edgDocs.AllowRangeColumns = true;

            // активация постраничного просмотра
            edgDocs.CreatePageNavigator();
        }

        /// <summary>
        /// Обновление записей в таблице заявок по нажатию на кнопку "Обновить"
        /// (если режим "Нераспечатанные строки", то обновляется таблица строк)
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (IsUnprintedMode)
                RefreshLines();
            else
                RefreshDocs();
        }

        /// <summary>
        /// Изменение выделенной в таблице заявки - обновление деталей и обновление доступности кнопок
        /// </summary>
        private void egvDocs_SelectionChanged(object sender, EventArgs e)
        {
            if (needRefreshLines)
            {
                RefreshLines();
                CustomDocsControls();
            }
        }

        /// <summary>
        /// Настройка доступности котролов, относящихся к таблице заявок
        /// </summary>
        private void CustomDocsControls()
        {
            edgDocs.Enabled = !isDocLoading && !IsUnprintedMode;
            pnlFilters.Enabled = !IsUnprintedMode;

            toolStripLine.Enabled = dgvLines.Enabled = !isDocLoading;
            pbSplashControl.Visible = isDocLoading;

            btnRefresh.Visible = !isDocLoading;
            btnRefresh.Enabled = btnRefresh.Visible;

            btnExportToExcel.Visible = !isDocLoading && edgDocs.HasRows;
            btnExportToExcel.Enabled = btnExportToExcel.Visible;
            tssExportToExcel.Visible = btnExportToExcel.Visible;

            btnCancelLoading.Visible = isDocLoading;
            btnCancelLoading.Enabled = btnCancelLoading.Visible;

            btnDelayReasons.Visible = SelectedDoc != null &&
                (SelectedDoc.Status_ID == Constants.QK_STATUS_D_100 || SelectedDoc.Has_Problems);
            btnDelayReasons.Enabled = btnDelayReasons.Visible && !IsUnprintedMode && !isDocLoading;

            btnRequestParameters.Visible = SelectedDoc != null && SelectedDoc.Status_ID == Constants.QK_STATUS_D_100;
            btnRequestParameters.Enabled = btnRequestParameters.Visible && !IsUnprintedMode && !isDocLoading;

            btnSendToInspection.Visible = selectedDocID != null;
            btnSendToInspection.Enabled = btnSendToInspection.Visible && !IsUnprintedMode && !isDocLoading;

            btnPrintDoc.Visible = SelectedDoc != null;// && SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN ? IsImnPrintDoc : SelectedDoc != null;
            btnPrintDoc.Enabled = btnPrintDoc.Visible && !IsUnprintedMode && !isDocLoading;

            sbDocComment.Visible = SelectedDoc != null;
            sbDocComment.Enabled = sbDocComment.Visible && !IsUnprintedMode && !isDocLoading;

            btnReprintDoc.Visible = SelectedDoc != null && //SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN ? IsImnPrintDoc : SelectedDoc != null &&
                (SelectedDoc.Status_ID == Constants.QK_STATUS_D_110 || SelectedDoc.Status_ID == Constants.QK_STATUS_D_120);
            btnReprintDoc.Enabled = btnReprintDoc.Visible && !IsUnprintedMode && !isDocLoading;

            btnCompleteDocPreparing.Visible = SelectedDoc != null && SelectedDoc.Status_ID == Constants.QK_STATUS_D_100;
            btnCompleteDocPreparing.Enabled = btnCompleteDocPreparing.Visible && !IsUnprintedMode && !isDocLoading;

            btnPrintSelectedDocs.Visible = SelectedDoc != null //&& SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN ? IsImnPrintDoc : SelectedDoc != null 
                && SelectedDoc.Status_ID == Constants.QK_STATUS_D_140;
            btnPrintSelectedDocs.Enabled = btnPrintSelectedDocs.Visible && !IsUnprintedMode && !isDocLoading;

            btnGlsRemarks.Visible = SelectedDoc != null && (SelectedDoc.Status_ID == Constants.QK_STATUS_D_140 ||
                Convert.ToInt32(SelectedDoc.Status_ID) > Convert.ToInt32(Constants.QK_STATUS_D_140) && SelectedDoc.Has_Gls_Remarks);
            btnGlsRemarks.Enabled = btnGlsRemarks.Visible && !IsUnprintedMode && !isDocLoading;

            ddbPrintAcceptanceAct.Visible = SelectedDoc != null //&& SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN ? false : SelectedDoc != null 
                && Convert.ToInt32(SelectedDoc.Status_ID) >= Convert.ToInt32(Constants.QK_STATUS_D_140);
            ddbPrintAcceptanceAct.Enabled = ddbPrintAcceptanceAct.Visible && !IsUnprintedMode && !isDocLoading;

            sbMoveToNewDoc.Visible = SelectedDoc != null && SelectedDoc.Status_ID == Constants.QK_STATUS_D_100 && SelectedDoc.IsRelated_Doc_IDNull();
            sbMoveToNewDoc.Enabled = sbMoveToNewDoc.Visible && !IsUnprintedMode && !isDocLoading;

            var isMoveItemsToQuarantineEnabled = SelectedDoc != null && SelectedDoc.Status_ID == Constants.QK_STATUS_D_140;
            btnMoveItemsToQuarantine.Enabled = isMoveItemsToQuarantineEnabled && !IsUnprintedMode && !isDocLoading;

            var isMoveItemsFromQuarantineEnabled = SelectedDoc != null && Convert.ToInt32(SelectedDoc.Status_ID) >= Convert.ToInt32(Constants.QK_STATUS_D_140) && Convert.ToInt32(SelectedDoc.Status_ID) <=  Convert.ToInt32(Constants.QK_STATUS_D_180);
            btnMoveItemsFromQuarantine.Enabled = isMoveItemsFromQuarantineEnabled && !IsUnprintedMode && !isDocLoading;

            ddbMoveItemsToSelectedLocation.Enabled = ddbMoveItemsToSelectedLocation.Visible = (isMoveItemsFromQuarantineEnabled || isMoveItemsToQuarantineEnabled) && !IsUnprintedMode && !isDocLoading;

            btnShowAttachments.Enabled = SelectedDoc != null;
            btnShowAttachments.Visible = btnShowAttachments.Enabled && !IsUnprintedMode && !isDocLoading;
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void edgDocs_OnFilterChanged(object pSender, EventArgs pE)
        {
            edgDocs.RecalculateSummary();
            //this.CustomDocsControls();
        }

        private void RefreshDocs()
        {
            RefreshDocs((long?)null);
        }

        /// <summary>
        /// Запуск асинхронной загрузки заявок
        /// </summary>
        private void RefreshDocs(long? docID)
        {
            var param = CreateRequestSearchParameters();
            if (param != null)
            {
                needRefreshLines = false;
                SaveRequestDetailSelection();
                selectedDocID = docID.HasValue ? docID : (IsDocSelected ? (long?)SelectedDoc.Doc_ID : null);
                isDocLoading = true;
                CustomDocsControls();
                bgwRequestsLoader = new BackgroundWorker();
                bgwRequestsLoader.DoWork += bgwRequestsLoader_DoWork;
                bgwRequestsLoader.RunWorkerCompleted += bgwRequestsLoader_RunWorkerCompleted;
                bgwRequestsLoader.RunWorkerAsync(param);
            }
        }

        /// <summary>
        /// Формирование параметров загрузки заявок
        /// </summary>
        /// <returns>Структура с параметрами загрузки заявок</returns>
        private QualityRequestSearchParameters CreateRequestSearchParameters()
        {
            var param = new QualityRequestSearchParameters();
            string msg = String.Empty;
            int id;

            if (String.IsNullOrEmpty(tbxDocID.Text))
                param.DocID = null;
            else if (Int32.TryParse(tbxDocID.Text, out id) && id > 0)
                param.DocID = id;
            else
                msg = "Код заявки должен быть положительным целым числом!";

            if (!String.IsNullOrEmpty(tbxItemID.Text))
            {
                param.ItemID = Int32.TryParse(tbxItemID.Text, out id) ? (int?)id : null;
                param.ItemNamePart = param.ItemID.HasValue ? null : tbxItemID.Text;
            }

            param.VendorLot = String.IsNullOrEmpty(tbxVendorLot.Text) ? null : tbxVendorLot.Text;
            param.BatchID = String.IsNullOrEmpty(tbxBatchID.Text) ? null : tbxBatchID.Text;
            param.IncludeArchivedDocs = chbIncludeArchived.Checked;
            if (String.IsNullOrEmpty(msg))
                msg = param.CheckParametersCorrectness();

            if (String.IsNullOrEmpty(FilterDoc))
                param.DocCode = null;
            else
                param.DocCode = FilterDoc;

            if (dtpPeriodFrom.Checked)
                param.PeriodFrom = dtpPeriodFrom.Value.Date;
            if (dtpPeriodTo.Checked)
                param.PeriodTo = dtpPeriodTo.Value.Date;

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Проверка фильтров", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
                return param;
        }

        /// <summary>
        /// Асинхронная загрузка заявок
        /// </summary>
        private void bgwRequestsLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var sp = e.Argument as QualityRequestSearchParameters;
                using (var adapter = new DocsTableAdapter())
                {
                    adapter.SetTimeout(300);
                    e.Result = adapter.GetData(sp.DocID, sp.ItemID, sp.ItemNamePart,
                        sp.VendorLot, sp.BatchID, sp.IncludeArchivedDocs, sp.DocCode, sp.PeriodFrom, sp.PeriodTo);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание загрузки заявок и их отображение в таблице
        /// </summary>
        private void bgwRequestsLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке заявок:", e.Result as Exception);
                needRefreshLines = true;
            }
            else
                RefreshDataViewBinding(e.Result as Quality.DocsDataTable);

            isDocLoading = false;
            CustomDocsControls();
        }

        /// <summary>
        /// Отображение загруженных заявок в фильтруемом гриде
        /// </summary>
        /// <param name="pData">Таблица с заявками, которые нужно отобразить в гриде</param>
        private void RefreshDataViewBinding(Quality.DocsDataTable pData)
        {
            try
            {
                long selDocID = -1;
                int rowIndex = edgDocs.FirstDisplayedScrollingRowIndex;

                selDocID = selectedDocID.HasValue ? selectedDocID.Value : (IsDocSelected ? CurrentDocId : -1);

                // Если это первая загрузка либо не было выбрано ни одного элемента, нужно включить режим обновления
                // (чтобы когда автоматом выберется первая заявка в таблице, обновились строки заявки)
                bool willSelect = HasRequestWithId(selDocID, pData);
                needRefreshLines = !willSelect;
                (edgDocs.DataView as QualityRequestView).FillData(pData);
                edgDocs.BindData(false);

                needRefreshLines = true;
                if (willSelect)
                    edgDocs.SelectRow("Doc_ID", selDocID.ToString());

                edgDocs.ScrollToRow(rowIndex);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время отображения заявок: ", exc);
            }
        }

        /// <summary>
        /// Проверка, есть ли в таблице заявка с заданным идентификатором
        /// </summary>
        /// <param name="pId">Идентификатор, который нужно найти</param>
        /// <param name="pData">Таблица заявок, в которой производится поиск</param>
        /// <returns>True если в таблице заявок есть заявка с заданным идентификатором, False если нет</returns>
        private bool HasRequestWithId(long pId, Quality.DocsDataTable pData)
        {
            if (pId == -1)
                return false;

            foreach (Quality.DocsRow row in pData)
                if (row.Doc_ID == pId)
                    return true;

            return false;
        }

        /// <summary>
        /// Отмена текущей асинхронной загрузки заявок
        /// </summary>
        private void btnCancelLoading_Click(object sender, EventArgs e)
        {
            isDocLoading = false;
            bgwRequestsLoader.RunWorkerCompleted -= bgwRequestsLoader_RunWorkerCompleted;
            bgwRequestsLoader = null;
            CustomDocsControls();
        }

        /// <summary>
        /// Разрисовка строк в таблице заявок
        /// </summary>
        private void egvDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var diffRow = (row.DataBoundItem as DataRowView).Row as Quality.DocsRow;
                var backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                    ? Color.White : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                    row.Cells[c].Style.BackColor = row.Cells[c].Style.SelectionForeColor = backColor;
            }
        }

        /// <summary>
        /// Если двойной щелчок был произведен на строчке со статусом 110 и есть причина нераспечатки сборочного,
        /// то показываем эту причину в отдельном окне
        /// </summary>
        private void edgDocs_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string propertyName = (sender as DataGridView).Columns[e.ColumnIndex].DataPropertyName;
            if (SelectedDoc != null &&
                ((!SelectedDoc.IsPrinted_DSCNull() && !String.IsNullOrEmpty(SelectedDoc.Printed_DSC)) ||
                 (!SelectedDoc.IsCommentNull() && !string.IsNullOrEmpty(SelectedDoc.Comment))) &&
                (propertyName == QualityRequestView.STATUS_ID_PROPERTY_NAME || propertyName == QualityRequestView.STATUS_NAME_PROPERTY_NAME || propertyName == QualityRequestView.ID_PROPERTY_NAME))
            {
                var sbComment = new StringBuilder();

                if (SelectedDoc.Status_ID == Constants.QK_STATUS_D_110 && !SelectedDoc.IsPrinted_DSCNull() && !String.IsNullOrEmpty(SelectedDoc.Printed_DSC))
                    sbComment.AppendFormat("\r\n\r\n{0}: {1}", "Причина не распечатанного сборочного", SelectedDoc.Printed_DSC);

                if (!SelectedDoc.IsCommentNull() && !string.IsNullOrEmpty(SelectedDoc.Comment))
                    sbComment.AppendFormat("\r\n\r\n{0}: {1}", "Комментарий к заявке", SelectedDoc.Comment);

                var commentForm = new CommentForm(true)
                {
                    CommentLabel = "Причина:",
                    Comment = sbComment.ToString().Trim(),
                    Font = new Font(new FontFamily("Arial"), 14),
                    FormBorderStyle = FormBorderStyle.SizableToolWindow,
                    MaximizeBox = false,
                    Text = "Заметки"
                };

                commentForm.Size = new Size(800, 300);
                commentForm.ShowDialog(this);
            }
        }

        #endregion

        private void sbDocComment_Click(object sender, EventArgs e)
        {
            try
            {
                var commentForm = new CommentForm(false)
                {
                    CommentLabel = "Коментар: ",
                    Text = "Коментар до заяви",
                    Comment = SelectedDoc.IsCommentNull() ? string.Empty : SelectedDoc.Comment
                };

                if (commentForm.ShowDialog(this) == DialogResult.OK)
                {
                    using (var adapter = new Data.QualityTableAdapters.DocsTableAdapter())
                        adapter.UpdateDocComment(SelectedDoc.Doc_ID, commentForm.Comment);

                    RefreshDocs();
                }
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время добавления комментария к заявке: ", ex);
                RefreshDocs();
            }
        }

        #region УПРАВЛЕНИЕ ОКНОМ С ПОМОЩЬЮ ГОРЯЧИХ КЛАВИШ

        /// <summary>
        /// Управление окном с помощью горячих клавиш
        /// </summary>
        private void QualityRequestWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                RefreshDocs();
            else if (e.KeyCode == Keys.F && e.Control)
                tbxDocID.Focus();
        }

        #endregion

        #region ТАБЛИЦА СТРОК ЗАЯВОК

        /// <summary>
        /// Индекс записи в выпадающем списке cmbLotFilter, которая отвечает за загрузку всех строк, по которым
        /// внесено заключение, но по которым не распечатано  разрешение на реализацию серии
        /// </summary>
        private const int UNPRINTED_LINES_INDEX = 2;

        /// <summary>
        /// Идентификаторы выделенных строк в таблице строк заявки
        /// </summary>
        private List<int> selectedLineIds = new List<int>();

        /// <summary>
        /// Индекс текущей прокрутки в таблице строк заявки
        /// </summary>
        private int lineScrollIndex;

        /// <summary>
        /// Идентификатор товара для выбранной строки заявки.
        /// Если в таблице строк заявок не выбрана ни одна строка, будет выдано исключение
        /// </summary>
        private int CurrentItemId { get { return Convert.ToInt32(dgvLines.SelectedRows[0].Cells[clItemID.Index].Value); } }

        /// <summary>
        /// True если сейчас окно находится в режиме отображения заявок, на которые есть заключения но не 
        /// распечатаны разрешения, False если обычный режим отображения заявок (по выделенному документу)
        /// </summary>
        private bool IsUnprintedMode { get { return cmbLotFilter.SelectedIndex == UNPRINTED_LINES_INDEX; } }

        /// <summary>
        /// Выделенная в таблице строк заявки запись, либо null если ни одной записи не выделено либо выделено больше чем одна
        /// </summary>
        public Quality.DocDetailsRow SelectedLine
        {
            get
            {
                if (dgvLines.SelectedRows.Count != 1)
                    return null;
                else
                    return (dgvLines.SelectedRows[0].DataBoundItem as DataRowView).Row as Quality.DocDetailsRow;
            }
        }

        /// <summary>
        /// Коллекция всех выделенных в таблице строк заявки строк
        /// </summary>
        private List<Quality.DocDetailsRow> SelectedLines
        {
            get
            {
                var result = new List<Quality.DocDetailsRow>();
                foreach (DataGridViewRow dgvRow in dgvLines.SelectedRows)
                    result.Add((dgvRow.DataBoundItem as DataRowView).Row as Quality.DocDetailsRow);
                return result;
            }
        }

        /// <summary>
        /// Обновление данных в таблице позиций заявки
        /// </summary>
        private void RefreshLines()
        {
            if (dgvLines.Rows.Count > 0)
                Config.SaveDataGridViewSettings(Name, dgvLines);

            SaveRequestDetailSelection();
            quality.DocDetails.Clear();

            if (IsUnprintedMode)
                taDocDetails.FillBySessionID(quality.DocDetails, UserID);
            else if (IsDocSelected)
                taDocDetails.Fill(quality.DocDetails, CurrentDocId, cmbLotFilter.SelectedIndex, UserID);

            try { Config.LoadDataGridViewSettings(Name, dgvLines); }
            catch { };
            RestoreRequestDetailsSelection();
            SetIcons();

            if (IsUnprintedMode)
                SetWorkEnability();
        }

        /// <summary>
        /// Сохранение выделения таблицы строк заявок перед обновлением таблицы
        /// </summary>
        private void SaveRequestDetailSelection()
        {
            if (wasLinesSelectionSaved)
                return;

            selectedLineIds.Clear();
            foreach (var line in SelectedLines)
                selectedLineIds.Add(line.Line_ID);
            lineScrollIndex = dgvLines.FirstDisplayedScrollingRowIndex;
        }

        /// <summary>
        /// Установка иконок на позициях заявки
        /// </summary>
        private void SetIcons()
        {
            foreach (DataGridViewRow itemRow in dgvLines.Rows)
            {
                // Расставление иконок "круговая стрелка" для повторных серий
                if (IsRepeatedLot(itemRow.Index))
                    itemRow.Cells[climgIsRepeatedLot.Index].Value = Resources.repeat;

                // Расставление иконок с восклицательным знаком для товаров, у которых когда-то были проблемы с прохождением инспекции
                if (IsProblemItem(itemRow.Index))
                    itemRow.Cells[clIsProblemIcon.Index].Value = Resources.Achtung;
            }
        }

        /// <summary>
        /// Восстановление тех выделенных строк заявки, что были до обновления таблицы
        /// </summary>
        private void RestoreRequestDetailsSelection()
        {
            var isSelected = false;

            if (selectedDocID.HasValue && SelectedDoc != null && selectedDocID == SelectedDoc.Doc_ID)
            {
                dgvLines.ClearSelection();
                foreach (DataGridViewRow dgvRow in dgvLines.Rows)
                {
                    var dbRow = (dgvRow.DataBoundItem as DataRowView).Row as Quality.DocDetailsRow;
                    if (selectedLineIds.Contains(dbRow.Line_ID))
                    {
                        dgvRow.Selected = true;
                        isSelected = true;
                    }
                }

                if (lineScrollIndex != -1 && lineScrollIndex < dgvLines.RowCount)
                    dgvLines.FirstDisplayedScrollingRowIndex = lineScrollIndex;
            }

            if (!isSelected && dgvLines.RowCount > 0)
                dgvLines.Rows[0].Selected = true;

            selectedDocID = IsDocSelected ? (long?)SelectedDoc.Doc_ID : null;
            wasLinesSelectionSaved = false;
        }

        /// <summary>
        /// Проверка, распечатаны ли разрешения на все строки заявок (проверка используется только в режиме 
        /// отображения строк заявок, на которые есть заключения, но не распечатаны разрешения на реализацию серии).
        /// Если все разрешения напечатаны - можно разрешить дальнейшую работу с заявками
        /// </summary>
        private void SetWorkEnability()
        {
            if (dgvLines.Rows.Count == 0)
            {
                cmbLotFilter.SelectedIndex = 0;
                RefreshDocs();
            }
        }

        /// <summary>
        /// Выбор другого режима отображения строк заявок
        /// </summary>
        private void cmbLotFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomDocsControls();
            RefreshLines();
            dgvLines.Focus();
        }

        /// <summary>
        /// Проверка, является ли серия в строке с заданным индексом повторной
        /// </summary>
        /// <param name="pRowIndex">Индекс проверяемой строки</param>
        /// <returns>True если серия повторная, False в противном случае</returns>
        private bool IsRepeatedLot(int pRowIndex)
        {
            return dgvLines.Rows[pRowIndex].Cells[clchbIsRepeatedLot.Index].Value != DBNull.Value &&
                   Convert.ToBoolean(dgvLines.Rows[pRowIndex].Cells[clchbIsRepeatedLot.Index].Value) == true;
        }

        /// <summary>
        /// Проверяет, является ли товар проблемным
        /// </summary>
        /// <param name="pRowIndex">Индекс строки с товаром</param>
        /// <returns>True, если у товара были проблемы с инспекцией, False, если не было</returns>
        private bool IsProblemItem(int pRowIndex)
        {
            if (pRowIndex < 0)
                return false;
            else
                return dgvLines.Rows[pRowIndex].Cells[clIsProblemItem.Index].Value != DBNull.Value &&
                    Convert.ToBoolean(dgvLines.Rows[pRowIndex].Cells[clIsProblemItem.Index].Value) == true;
        }

        /// <summary>
        /// Разрисовка строк в таблице строк заявок
        /// </summary>
        private void dgvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvLines.Rows)
            {
                var diffRow = (row.DataBoundItem as DataRowView).Row as Quality.DocDetailsRow;
                Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                    ? Color.White : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

        #endregion

        #region ПРОСМОТР И ПЕЧАТЬ РАЗРЕШЕНИЯ НА РЕАЛИЗАЦИЮ СЕРИИ

        /// <summary>
        /// Признак, может ли пользователь печатать разрешения на реализацию серии
        /// </summary>
        private bool canPrintPermission;

        /// <summary>
        /// Класс-поставщик отчетов разрешения на реализацию серии
        /// </summary>
        private QualitySellPermissionReportProvider spReportProvider;

        /// <summary>
        /// Настройка доступности кнопок просмотра/печати разрешений на реализацию
        /// </summary>
        private void SetPrintSellPermissionButtonsVisibility()
        {
            btnPreviewSellPermission.Enabled = btnPreviewSellPermission.Visible = SelectedLine != null &&
                cmbPrinters.SelectedItem != null && !SelectedLine.IsSell_Permission_Status_IDNull() && SelectedLine.Sell_Permission_Status_ID == Constants.QK_STATUS_SP_IS_PRINTED;

            bool allLines299 = true;
            foreach (DataGridViewRow dgvRow in dgvLines.SelectedRows)
            {
                var dbRow = (dgvRow.DataBoundItem as DataRowView).Row as Data.Quality.DocDetailsRow;
                if (dbRow.IsSell_Permission_Status_IDNull() ||
                    dbRow.Sell_Permission_Status_ID < Constants.QK_STATUS_SP_IS_COMMITED ||
                    dbRow.IsA_Concl_Doc_NumberNull() || (!dbRow.IsConcl_Type_IDNull() && dbRow.Concl_Type_ID != 1))
                {
                    allLines299 = false;
                    break;
                }
            }
            btnPrintSellPermission.Enabled = btnPrintSellPermission.Visible = canPrintPermission && allLines299 &&
                dgvLines.SelectedRows.Count > 0 && cmbPrinters.SelectedItem != null;
            cmbPrinters.Visible = btnPrintSellPermission.Visible || btnPreviewSellPermission.Visible;
        }

        /// <summary>
        /// Просмотр либо подтверждение (в зависимости от статуса) разрешения на реализацию серии
        /// </summary>
        private void btnPreviewSellPermission_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Печать разрешений запрещена!", "Печать разрешений", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //return;

            try
            {
                //if (SelectedLine.IsSell_Permission_Status_IDNull() ||
                //    SelectedLine.Sell_Permission_Status_ID < Constants.QK_STATUS_SP_IS_COMMITED)
                //    CommitSellPermissionDocument();
                //else
                {
                    var form = new ReportForm();
                    form.ReportDocument = spReportProvider.GetReport(SelectedLine);
                    form.ShowDialog(this);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время просмотра разрешения на реализацию серии: ", exc);
            }
        }

        /// <summary>
        /// Просмотр-подтверждение правильности формы разрешения на реализацию серии
        /// </summary>
        private void CommitSellPermissionDocument()
        {
            try
            {
                var doc = spReportProvider.GetReport(SelectedLine);
                var form = new ReportCommitForm(doc, !SelectedLine.IsA_Concl_Doc_NumberNull() &&
                    (SelectedLine.IsConcl_Type_IDNull() || SelectedLine.Concl_Type_ID == 1));
                if (form.ShowDialog(this) == DialogResult.OK)
                {

                    taDocDetails.UpdateSellPermissionStatus(UserID, SelectedLine.Doc_ID,
                        SelectedLine.Line_ID, Constants.QK_STATUS_SP_IS_COMMITED);
                    if (form.NeedToPrint)
                        btnPrintSellPermission_Click(btnPrintSellPermission, EventArgs.Empty);
                    else
                    {
                        MessageBox.Show("Документ РАЗРЕШЕНИЕ НА РЕАЛИЗАЦИЮ СЕРИИ подтвержден!", "Разрешение на реализацю",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshLines();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время подтверждения разрешения на реализацию!", exc);
            }
        }

        /// <summary>
        /// Печать разрешений на реализацию серии для всех выбранных в таблице строк заявки
        /// </summary>
        private void btnPrintSellPermission_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Печать разрешений запрещена!", "Печать разрешений", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
            try
            {
                var printThread = new PrintDocsThread();
                printThread.ReportProvider = spReportProvider;
                var tbl = new Data.Quality.DocDetailsDataTable();
                foreach (var line in SelectedLines)
                {
                    taDocDetails.UpdateSellPermissionStatus(UserID, line.Doc_ID, line.Line_ID, Constants.QK_STATUS_SP_IS_PRINTED);
                    tbl.Clear();
                    tbl.ImportRow(line);
                    var printParams = new PrintDocsParameters
                    {
                        PrinterName = cmbPrinters.SelectedItem.ToString(),
                        Docs = new DataRow[] { tbl[0] }
                    };
                    printThread.PrintDocumentsAsynch(printParams);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время обновления статуса разрешения на реализацию серии: ", exc);
            }
            finally
            {
                RefreshLines();
            }
        }

        #endregion

        #region РАБОТА С ЗАЯВКОЙ НА 100-М СТАТУСЕ

        /// <summary>
        /// Запуск окна с причинами задержки заявки
        /// </summary>
        private void btnDelayReasons_Click(object sender, EventArgs e)
        {
            var delayReasonsForm = new DelayReasonsForm(UserID, SelectedDoc, SelectedDoc.Status_ID != Constants.QK_STATUS_D_100);
            delayReasonsForm.ShowDialog(this);
            if (SelectedDoc.Status_ID == Constants.QK_STATUS_D_100) // Меняться признак проблем может только на 100-м статусе
            {
                SelectedDoc.Has_Problems = delayReasonsForm.HasReasons;
                SelectedDoc.Has_Problems_Str = SelectedDoc.Has_Problems ? "Да" : "Нет";
            }
        }

        /// <summary>
        /// Редактирование параметров заявки
        /// </summary>
        private void btnRequestParameters_Click(object sender, EventArgs e)
        {
            try
            {
                var parametersForm = new RequestParametersForm(UserID, SelectedDoc.Location_ID) { Owner = this };
                if (parametersForm.ShowDialog() == DialogResult.OK)
                {
                    taDocs.UpdateRequestParams(UserID, SelectedDoc.Doc_ID, parametersForm.InspectionID);
                    MessageBox.Show("Изменения были успешно внесены в БД!", "Параметры заявки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SelectedDoc.Location_ID = parametersForm.InspectionID;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время редактирования параметров заявки:", exc);
            }
        }

        /// <summary>
        /// Установка дополнительных параметров строки
        /// </summary>
        private void btnSetMode_Click(object sender, EventArgs e)
        {
            bool lockLotVolume = dgvLines.SelectedRows.Count != 1;
            var selectedDetail = (dgvLines.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.DocDetailsRow;
            var dataForItemID = lockLotVolume ? null : GetManufAndGmpDescForItemID(selectedDetail.Item_ID);
            SetModeForm form = new SetModeForm(
                (lockLotVolume || selectedDetail.IsModeNull()) ? String.Empty : selectedDetail.Mode,
                (lockLotVolume || selectedDetail.IsLotQtyNull()) ? null : (int?)Convert.ToInt32(selectedDetail.LotQty),
                (lockLotVolume || selectedDetail.IsManuf_DateNull() ? null : (DateTime?)selectedDetail.Manuf_Date),
                (lockLotVolume ? String.Empty :
                    (selectedDetail.IsManuf_Sector_DscNull() || String.IsNullOrEmpty(selectedDetail.Manuf_Sector_Dsc) ? dataForItemID[0] : selectedDetail.Manuf_Sector_Dsc)),
                (lockLotVolume ? String.Empty :
                    (selectedDetail.IsGMP_SertNull() || String.IsNullOrEmpty(selectedDetail.GMP_Sert) ? dataForItemID[1] : selectedDetail.GMP_Sert)),
                SelectedDoc == null ? DateTime.Now : (SelectedDoc as Data.Quality.DocsRow).Doc_Date,
                lockLotVolume,
                (lockLotVolume || selectedDetail.IsManuf_Date2Null() ? null : (DateTime?)selectedDetail.Manuf_Date2));

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvLines.SelectedRows)
                    {
                        Data.Quality.DocDetailsRow curRow = (Data.Quality.DocDetailsRow)((DataRowView)row.DataBoundItem).Row;

                        // Сохранение режима
                        taDocDetails.SetMode(curRow.Doc_ID, curRow.Line_ID, form.SelectedMode,
                            UserID, form.ManufDate, form.LicenseRequisites, form.GMPSert, !((lockLotVolume && form.CanEditOtherProperties) || !lockLotVolume), form.ManufItemDate);

                        // Сохранение размера серии (только для одиночного выделения строки)
                        if (!lockLotVolume)
                            taDocDetails.SetLotVolume(UserID, curRow.Doc_ID, curRow.Line_ID, form.SelectedLotVolume);
                    }
                    RefreshLines();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Получение данных о производственном участке и данных о GMP-сертификате по коду товара
        /// (если есть хоть одна строка заявки качества по этому товару, по которому эта инфа задавалась, то будут возвращены данных)
        /// </summary>
        /// <param name="pItemID">Код товара</param>
        /// <returns>Данные о производственном участке и GMP-сертификате по коду товара (эти данные нужны, чтобы отображать их 
        /// по умолчанию в случае, если для серии не задавалась эта информация)</returns>
        private string[] GetManufAndGmpDescForItemID(long pItemID)
        {
            var arr = new string[2] { String.Empty, String.Empty };
            try
            {
                using (var adapter = new QK_Get_Manuf_And_GMP_For_ItemIDTableAdapter())
                {
                    var tbl = adapter.GetData(UserID, pItemID);
                    var row = tbl[0];
                    if (!row.IsManuf_Sector_DscNull())
                        arr[0] = row.Manuf_Sector_Dsc;
                    if (!row.IsGMP_SertNull())
                        arr[1] = row.GMP_Sert;
                }
            }
            catch { }

            return arr;
        }

        #endregion

        #region ЗАВЕРШЕНИЕ ПОДГОТОВКИ ЗАЯВКИ (ПЕРЕВОД НА 110 СТАТУС)

        /// <summary>
        /// Завершение подготовки заявки - "Взяти заявки в работу".
        /// Заявки, в которых есть только повторные серии, сразу переводятся с 100-го на 140-й статус
        /// </summary>
        private void btnCompleteDocPreparing_Click(object sender, EventArgs e)
        {
            string error = CheckCompleteDocPreparingAvailable();
            if (String.IsNullOrEmpty(error))
                ChangeStatusTo(Constants.QK_STATUS_D_110);
            else
                Logger.ShowErrorMessageBox(error);
        }

        /// <summary>
        /// Проверка, можно ли перевести заявку на 110й статус
        /// </summary>
        /// <returns>Сообщение о причине невозможности перевода заявки на 110й статус 
        /// или пустая строка, если заявку можно переводить на 110й статус</returns>
        private string CheckCompleteDocPreparingAvailable()
        {
            //var error = CheckForUnprintedRepeatVendorLots();
            //if (!String.IsNullOrEmpty(error))
            //    return error;
            //else
                return CheckExistedDelayReasons(SelectedDoc.Doc_ID);
        }

        /// <summary>
        /// Проверка, есть ли по заявке не решенные причины задержки
        /// </summary>
        /// <param name="pDocID">Идентификатор заявки, которая проверяется</param>
        /// <returns>Сообщение о не решенной причине задержки либо пустая строка, если
        /// нерешенных причин задержки нет и заявку можно переводить на 110-й статус</returns>
        private string CheckExistedDelayReasons(long pDocID)
        {
            try
            {
                using (var adapter = new QK_Delay_ReasonsTableAdapter())
                {
                    var reasonsTbl = adapter.GetData(UserID, pDocID, true);
                    if (reasonsTbl.Count == 0)
                        return String.Empty;
                    else
                        return "По заявке есть не решенные причины задержки." +
                            " Чтобы завершить подготовку заявки, нужно решить все причины задержки!";
                }
            }
            catch (Exception exc)
            {
                return "Возникла ошибка при проверке на не решенные причины задержки. " + exc.Message;
            }
        }

        /// <summary>
        /// Проверка, есть ли в заявке повторные серии, для которых еще не распечатано разрешение на реализацию серии
        /// </summary>
        /// <returns>Сообщение о невозможности перевода заявки на 110-й статус в связи с нераспечатанными разрешениями на
        /// повторные серии либо пустая строка если все разрешения на повторные серии по заявке распечатаны</returns>
        private string CheckForUnprintedRepeatVendorLots()
        {
            var str = new StringBuilder();
            foreach (DataGridViewRow row in dgvLines.Rows)
            {
                var dbRow = (row.DataBoundItem as DataRowView).Row as Quality.DocDetailsRow;
                if (!dbRow.IsControl_ReadyNull() && dbRow.Control_Ready && !dbRow.IsA_Concl_Doc_NumberNull() &&
                    (dbRow.IsSell_Permission_Status_IDNull() || dbRow.Sell_Permission_Status_ID != Constants.QK_STATUS_SP_IS_PRINTED))
                    str.AppendFormat("{0}{1}", str.Length > 0 ? ", " : String.Empty, dbRow.VendorLot);
            }

            if (str.Length != 0)
                return "В заявке есть повторные серии, по которым не распечатано разрешение на реализацию серии: " +
                    str.ToString() + ". Нельзя продолжить работу с заявкой, пока не будут распечатаны разрешения для этих серий.";
            else
                return String.Empty;
        }

        /// <summary>
        /// Перевод заявки на указанный статус
        /// </summary>
        /// <param name="pNewStatus">Статус, на который нужно перевести заявку</param>
        private void ChangeStatusTo(string pNewStatus)
        {
            try
            {
                taDocs.StatusUpdate(SelectedDoc.Doc_ID, UserID, pNewStatus, null);
                RefreshDocs();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время завершения подготовки заявки: ", exc);
            }
        }

        /// <summary>
        /// Перевод образца заявки на указанный статус
        /// </summary>
        /// <param name="docID">Код заявки</param>
        /// <param name="pNewStatus">Статус, на который нужно перевести образец заявки</param>
        private void ChangeSampleStatusTo(int docID, string pNewStatus)
        {
            try
            {
                taDocs.SampleStatusUpdate(docID, pNewStatus, UserID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время подготовки образца заявки: ", exc);
            }
        }


        #endregion

        #region РАБОТА С ЗАМЕЧАНИЯМИ ОТ ГЛС

        /// <summary>
        /// Запуск окна "Замечания от ГЛС" по нажатию на кнопку
        /// </summary>
        private void SetGlsRemarks_Click(object sender, EventArgs e)
        {
            ShowProblemsWindow(sender == btnGlsRemarks ? SelectedDoc : null,
                sender == btnGlsRemarks ? null : SelectedLine);
        }

        /// <summary>
        /// Запуск окна "Замечания от ГЛС" для заявки или строки заявки
        /// </summary>
        /// <param name="pSelectedDoc">Заявка, выделенная в таблице если нужно отобразить окно замечаний по целой заявке.
        /// Null если окно замечаний нужно отобразить по строке заявки</param>
        /// <param name="pSelectedDetail">Строка заявки, выделенная в таблице если нужно отобразить окно замечаний по строке заявки.
        /// Null если окно замечаний нужно отобразить по целой заявке</param>
        private void ShowProblemsWindow(Quality.DocsRow pSelectedDoc, Quality.DocDetailsRow pSelectedDetail)
        {
            bool canEdit;
            if (pSelectedDoc == null)
                canEdit = Convert.ToInt32(SelectedLine.Status_ID) >= Convert.ToInt32(Constants.QK_STATUS_DD_205) &&
                    Convert.ToInt32(SelectedLine.Status_ID) < Convert.ToInt32(Constants.QK_STATUS_DD_298);
            else
                canEdit = pSelectedDoc.Status_ID == Constants.QK_STATUS_D_140;

            var window = new GlsRemarksForm(UserID, pSelectedDoc == null ? pSelectedDetail.Doc_ID : pSelectedDoc.Doc_ID,
                pSelectedDetail == null ? null : (int?)pSelectedDetail.Line_ID, !canEdit);
            window.ShowDialog(this);
            RefreshLines();
        }

        /// <summary>
        /// По двойному клику на таблицу строк 
        /// </summary>
        private void dgvLines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnGlsRemarksForLine.Visible)
                ShowProblemsWindow(null, SelectedLine);
        }

        #endregion

        #region РАБОТА С ЛАБОРАТОРИЕЙ (СЕРТИФИКАТЫ, АНАЛИЗ)

        /// <summary>
        /// Внесение в систему разрешения от поставщика на продажу товара
        /// </summary>
        private void btnVendorSellPermission_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Додати до системи факт отримання Дозволу на продаж від Постачальника?", "Підтвердження дії",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    taDocDetails.SetVendorSellPermission(UserID, SelectedLine.Doc_ID, SelectedLine.Line_ID, DateTime.Now);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время внесения данных в БД: ", exc);
            }
        }

        /// <summary>
        /// Добавление замечания к сертификату
        /// </summary>
        private void btnSetCertRemark_Click(object sender, EventArgs e)
        {
            try
            {
                var commentForm = new CommentForm(false) { CommentLabel = "Замечание: ", Text = "Добавление замечания к сертификату" };
                if (commentForm.ShowDialog(this) == DialogResult.OK)
                {
                    using (var adapter = new WMSOffice.Data.QualityTableAdapters.QueriesTableAdapter())
                        foreach (var line in SelectedLines)
                            adapter.InsertCertRemark(UserID, line.Doc_ID, line.Line_ID, commentForm.Comment);
                    RefreshLines();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время добавления замечания к сертификату: ", exc);
                RefreshLines();
            }
        }

        /// <summary>
        /// Внесение в систему факта получения исправленного сертификата от лаборатории
        /// </summary>
        private void btnCertRemarkEliminated_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Внести в систему факт получения исправленного сертификата от лаборатории?";
                if (MessageBox.Show(msg, "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var adapter = new WMSOffice.Data.QualityTableAdapters.QueriesTableAdapter())
                        foreach (var line in SelectedLines)
                            adapter.InsertCertRemark(UserID, line.Doc_ID, line.Line_ID, null);
                    RefreshLines();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при внесении в БД факта получения исправленного сертификата от лаборатории: ", exc);
                RefreshLines();
            }
        }

        /// <summary>
        /// Окно редактирования данных по анализу
        /// </summary>
        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            try
            {
                SetAnalizFormMode mode;
                if (sender.Equals(btnSetAnaliz))
                    mode = SetAnalizFormMode.Receipt;
                else if (sender.Equals(btnSetAnalizSent))
                    mode = SetAnalizFormMode.Delivery;
                else
                    mode = SetAnalizFormMode.EditData;

                var window = new SetAnalizForm(UserID, SelectedLine, mode);
                if (window.ShowDialog() == DialogResult.OK)
                {
                    var statusID = Convert.ToInt32(SelectedLine.Status_ID);
                    var saveDataFlag = mode == SetAnalizFormMode.Receipt || mode == SetAnalizFormMode.Delivery;

                    if (saveDataFlag)
                    {
                        taDocDetails.SetAnaliz(
                            SelectedLine.Doc_ID, 
                            SelectedLine.Line_ID, 
                            UserID,
                            window.Number, 
                            window.SelectedDate, 
                            window.ReceiptDate, 
                            window.DeliveryDate, 
                            window.IsNegativeAnaliz, 
                            window.CompanyID,
                            (int)mode);

                        RefreshLines();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время редактировании данных об анализе: ", exc);
            }
        }

        #endregion

        #region ЗАКРЫТИЕ СТРОК ЗАЯВКИ

        /// <summary>
        /// Закрытие строки заявки по причине
        /// </summary>
        private void btnCloseForReason_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new CloseGlsRequestForReasonForm(UserID) { Owner = this };
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (var line in SelectedLines)
                        taDocDetails.CloseForReason(UserID, line.Doc_ID, line.Line_ID, form.ReasonID, form.DocNumber, form.DocDate);
                    RefreshLines();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время закрытия строки заявки: ", exc);
                RefreshLines();
            }
        }

        /// <summary>
        /// Внесение заключения ГЛС
        /// </summary>
        private void btnSetConclusion_Click(object sender, EventArgs e)
        {
            if (SelectedDoc != null && SelectedLine != null)
            {
                Data.Quality.DocsRow doc = ((Data.Quality.DocsRow)SelectedDoc);
                Data.Quality.DocDetailsRow detail = ((Data.Quality.DocDetailsRow)SelectedLine);

                SetConclusionForm form = new SetConclusionForm(UserID);
                if (form.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(form.Number))
                    try
                    {
                        taDocDetails.SetConclusion(doc.Doc_ID, detail.Line_ID, UserID, form.Number, form.SelectedDate,
                            form.ConclusionType.type_id);
                        RefreshDocs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }

        /// <summary>
        /// Корректировка архивного заключения
        /// </summary>
        private void btnEditArchiveConclusion_Click(object sender, EventArgs e)
        {
            if (SelectedDoc != null && SelectedLine != null)
            {
                Data.Quality.DocDetailsRow detail = ((Data.Quality.DocDetailsRow)SelectedLine);

                SetConclusionForm form = new SetConclusionForm(UserID) { ConclTypeEnable = false };
                form.Number = detail.IsA_Concl_Doc_NumberNull() ? string.Empty : detail.A_Concl_Doc_Number;
                form.SelectedDate = detail.IsA_OutConcl_Doc_DateNull() ? DateTime.Now : detail.A_OutConcl_Doc_Date;
                form.Text = "Коригування архівного висновку";
                if (form.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(form.Number))
                    try
                    {
                        taDocDetails.UpdateConclusion(this.UserID, SelectedDoc.Doc_ID, detail.Line_ID,
                            form.Number, form.SelectedDate);
                        RefreshDocs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }

        #endregion

        #region ПРОСМОТР И ПЕЧАТЬ АКТА ПРИЕМА-ПЕРЕДАЧИ

        /// <summary>
        /// Печать акта приема передачи
        /// </summary>
        private void btnPrintAct_Click(object sender, EventArgs e)
        {
            try
            {
                var printThread = new PrintDocsThread();
                printThread.ReportProvider = new QualityAcceptanceActReportProvider(UserID, sender == btnPrintActForOptima);
                var row = SelectedDoc;
                var printParams = new PrintDocsParameters
                {
                    PrinterName = cmbPrinters.SelectedItem.ToString(),
                    Docs = new DataRow[] { row }
                };
                printThread.PrintDocumentsAsynch(printParams);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время печати акта приема-передачи образцов: ", exc);
            }
        }

        /// <summary>
        /// Просмотр акта приема-передачи
        /// </summary>
        private void btnViewAct_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ReportForm();
                var provider = new QualityAcceptanceActReportProvider(UserID, sender == btnViewActForOptima);
                form.ReportDocument = provider.GetReport(SelectedDoc);
                form.ShowDialog(this);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время просмотра акта приема-передачи образцов по заявке: ", exc);
            }
        }

        #endregion

        private void gvLines_SelectionChanged(object sender, EventArgs e)
        {
            cmbLotFilter.Enabled = !IsUnprintedMode;
            if (SelectedDoc != null || IsUnprintedMode)
            {
                // by Doc
                Data.Quality.DocsRow doc = ((Data.Quality.DocsRow)SelectedDoc);

                // Редактирование режима и размера серии доступно из следующих статусов документа
                btnSetMode.Enabled = btnSetMode.Visible = (dgvLines.SelectedRows.Count > 0);

                if (SelectedLine != null)
                {
                    // by Line
                    Data.Quality.DocDetailsRow detail = ((Data.Quality.DocDetailsRow)SelectedLine);
                    btnSetAnaliz.Enabled = btnSetAnaliz.Visible = Convert.ToInt32(detail.Status_ID) >= Convert.ToInt32(Constants.QK_STATUS_DD_205) && 
                        Convert.ToInt32(detail.Status_ID) <= Convert.ToInt32(Constants.QK_STATUS_DD_299);
                    btnSetAnalizSent.Enabled = btnSetAnalizSent.Visible = (detail.Status_ID == "230");

                    btnEditRegistrationLifetime.Enabled = btnEditRegistrationLifetime.Visible = doc != null;
                    btnEditArchiveConclusion.Enabled = btnEditArchiveConclusion.Visible = doc != null &&
                        !SelectedLine.IsA_Concl_Doc_NumberNull() && !String.IsNullOrEmpty(SelectedLine.A_Concl_Doc_Number) &&
                        (doc.Status_ID == "100" || doc.Status_ID == "110" || doc.Status_ID == "120" || doc.Status_ID == "140");
                    btnEditAnalysisData.Enabled = btnEditAnalysisData.Visible = Convert.ToInt32(detail.Status_ID) >
                        Convert.ToInt32(Constants.QK_STATUS_DD_230) && !detail.IsAnalizDateNull();
                }
                else btnSetConclusion.Enabled = btnSetConclusion.Visible =
                    btnCloseForReason.Enabled = btnCloseForReason.Visible = btnSetAnaliz.Enabled = btnSetAnaliz.Visible =
                    btnSetAnalizSent.Enabled = btnSetAnalizSent.Visible =
                    btnEditArchiveConclusion.Enabled = btnEditArchiveConclusion.Visible = btnEditRegistrationLifetime.Enabled =
                    btnEditRegistrationLifetime.Visible = false;
            }
            else btnSetMode.Enabled = btnSetMode.Visible =
                btnSetConclusion.Enabled = btnSetConclusion.Visible = btnCloseForReason.Enabled = btnCloseForReason.Visible =
                    btnSetAnaliz.Enabled = btnSetAnaliz.Visible = btnSetAnalizSent.Enabled = btnSetAnalizSent.Visible =
                    btnEditArchiveConclusion.Enabled = btnEditArchiveConclusion.Visible = btnEditRegistrationLifetime.Enabled =
                    btnEditRegistrationLifetime.Visible = btnEditAnalysisData.Enabled = btnEditAnalysisData.Visible = false;


            SetWatchProblemsButtonEnability();
            SetPrintSellPermissionButtonsVisibility();

            tssAfterSetMode.Visible = btnSetMode.Visible;
            tssAfterSetPrescription.Visible = btnCloseForReason.Visible ||
                btnEditArchiveConclusion.Visible || btnSetConclusion.Visible || cmbPrinters.Visible;
            tssAfterWatchProblems.Visible = btnSetAnaliz.Visible || btnSetAnalizSent.Visible ||
                btnEditAnalysisData.Visible || btnGlsRemarksForLine.Visible;
            CustomDetailsButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели инструментов для строк заявок
        /// </summary>
        private void CustomDetailsButtons()
        {
            btnGlsRemarksForLine.Visible = btnGlsRemarksForLine.Enabled =
                SelectedDoc != null &&
                dgvLines.SelectedRows.Count == 1 &&
                ((Convert.ToInt32(SelectedLine.Status_ID) >= Convert.ToInt32(Constants.QK_STATUS_DD_205) && Convert.ToInt32(SelectedLine.Status_ID) < Convert.ToInt32(Constants.QK_STATUS_DD_220)) ||
                (Convert.ToInt32(SelectedLine.Status_ID) >= Convert.ToInt32(Constants.QK_STATUS_DD_220) && SelectedLine.Has_Gls_Remarks));

            btnSetConclusion.Enabled = btnSetConclusion.Visible = btnCloseForReason.Enabled = btnCloseForReason.Visible =
                dgvLines.SelectedRows.Count == 1 && (SelectedLine.Status_ID == Constants.QK_STATUS_DD_205 ||
                SelectedLine.Status_ID == Constants.QK_STATUS_DD_206 || SelectedLine.Status_ID == Constants.QK_STATUS_DD_220 ||
                SelectedLine.Status_ID == "225" || SelectedLine.Status_ID == "235" || SelectedLine.Status_ID == "297");

            btnVendorSellPermission.Enabled = btnVendorSellPermission.Visible = dgvLines.SelectedRows.Count == 1 &&
                Convert.ToInt32(SelectedLine.Status_ID) >= Convert.ToInt32(Constants.QK_STATUS_DD_208) &&
                Convert.ToInt32(SelectedLine.Status_ID) < Convert.ToInt32(Constants.QK_STATUS_DD_298);

            CustomCertRemarksButtonVisibility();
            CustomCertRemarksEliminatedButtonVisibility();
            CustomCloseForReasonButtonVisibility();

            btnChoiceExpert.Visible = false; // SelectedDoc != null && Convert.ToInt32(SelectedDoc.Status_ID) == Convert.ToInt32(Constants.QK_STATUS_D_115)
            //&& SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN && SelectedLine != null && SelectedLine.Status_ID == Constants.QK_STATUS_DD_200;

            if (SelectedDoc != null && SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN && SelectedLine != null && SelectedLine.Control_Ready)
                btnSetConclusion.Enabled = btnSetConclusion.Visible = SelectedDoc != null
                     && SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN && SelectedLine != null && SelectedLine.Control_Ready;

            btnEditManufacturer.Visible = btnEditManufacturer.Enabled = SelectedDoc != null && SelectedLine != null; // && SelectedDoc.Status_ID != Constants.QK_STATUS_D_199;
            btnEditGMP.Visible = btnEditGMP.Enabled = SelectedDoc != null && SelectedLine != null; // && SelectedDoc.Status_ID != Constants.QK_STATUS_D_199;
            btnEditExpDate.Visible = btnEditExpDate.Enabled = SelectedDoc != null && SelectedLine != null; // && SelectedDoc.Status_ID != Constants.QK_STATUS_D_199;
            btnEditManufacturerCountry.Visible = btnEditManufacturerCountry.Enabled = SelectedDoc != null && SelectedLine != null; // && SelectedDoc.Status_ID != Constants.QK_STATUS_D_199;
        }

        /// <summary>
        /// Настройка видимости кнопки добавления замечания к сертификату качества
        /// </summary>
        private void CustomCertRemarksButtonVisibility()
        {
            if (dgvLines.SelectedRows.Count == 0 || IsUnprintedMode)
                btnSetCertRemark.Enabled = btnSetCertRemark.Visible = false;
            else
            {
                btnSetCertRemark.Enabled = btnSetCertRemark.Visible = true;
                foreach (var line in SelectedLines)
                    if (line.Status_ID != Constants.QK_STATUS_DD_235 || line.Control_Ready)
                    {
                        btnSetCertRemark.Enabled = btnSetCertRemark.Visible = false;
                        return;
                    }
            }
        }

        /// <summary>
        /// Настройка видимости кнопки устранения замечания к сертификату качества
        /// </summary>
        private void CustomCertRemarksEliminatedButtonVisibility()
        {
            if (dgvLines.SelectedRows.Count == 0 || IsUnprintedMode)
                btnCertRemarkEliminated.Enabled = btnCertRemarkEliminated.Visible = false;
            else
            {
                btnCertRemarkEliminated.Enabled = btnCertRemarkEliminated.Visible = true;
                foreach (var line in SelectedLines)
                    if (line.Status_ID != Constants.QK_STATUS_DD_236 || line.Control_Ready)
                    {
                        btnCertRemarkEliminated.Enabled = btnCertRemarkEliminated.Visible = false;
                        return;
                    }
            }
        }

        /// <summary>
        /// Настройка видимости кнопки закрытия строки заявки по причине
        /// </summary>
        private void CustomCloseForReasonButtonVisibility()
        {
            if (dgvLines.SelectedRows.Count == 0 || IsUnprintedMode)
                btnCloseForReason.Enabled = btnCloseForReason.Visible = false;
            else
            {
                btnCloseForReason.Enabled = btnCloseForReason.Visible = true;
                foreach (var line in SelectedLines)
                    if (line.Status_ID != Constants.QK_STATUS_DD_205 &&
                        line.Status_ID != Constants.QK_STATUS_DD_206 &&
                        line.Status_ID != Constants.QK_STATUS_DD_220 &&
                        line.Status_ID != Constants.QK_STATUS_DD_235 &&
                        line.Status_ID != Constants.QK_STATUS_DD_297)
                    {
                        btnCloseForReason.Enabled = btnCloseForReason.Visible = false;
                        return;
                    }
            }
        }

        /// <summary>
        /// В зависимости от того, были ли у товара проблемы с прохождением инспеции, делаем кнопку Список проблем доступной или недоступной
        /// </summary>
        private void SetWatchProblemsButtonEnability()
        {
            if (dgvLines.SelectedRows.Count == 0 || IsUnprintedMode)
                return;

            if (IsProblemItem(dgvLines.SelectedRows[0].Index))
                btnGlsRemarksForLine.Enabled = btnGlsRemarksForLine.Visible = true;
            else
                btnGlsRemarksForLine.Enabled = btnGlsRemarksForLine.Visible = false;
        }

        private void btnPrintDoc_Click(object sender, EventArgs e)
        {
            bool isPrinted = PrintDoc(false, false);
        }

        private void btnReprintDoc_Click(object sender, EventArgs e)
        {
            PrintDoc(Control.ModifierKeys == Keys.Control, true);
        }

        private bool PrintDoc(bool viewOnly, bool isRepeatPrint)
        {
            if (SelectedDoc == null)
                return false;

            try
            {
                // Печать пакета документов для имунобиологии
                //if (SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN)
                //{
                //    foreach (DataGridViewRow dgvRow in dgvLines.Rows)
                //    {
                //        var dbRow = (dgvRow.DataBoundItem as DataRowView).Row as Data.Quality.DocDetailsRow;
                //        if (dbRow == null || !dbRow.IsLotQtyNull())
                //            continue;

                //        ShowError("Укажите размер серии для всех продуктов!");
                //        return false;
                //    }

                //    var frm = new WMSOffice.Dialogs.Quality.DocPrintChoiceFrm() { Owner = this };
                //    if (frm.ShowDialog() == DialogResult.OK)
                //    {
                //        var printParameters = new GeneralIMNDocsCopiesCount()
                //        {
                //            RequestCopiesCount = frm.RequestCount,
                //            SertCopiesCount = frm.SertCount,
                //            StatementCopiesCount = frm.StatementCount
                //        };
                //        PrintDocPackages(printParameters);

                //        ChangeStatusTo(Constants.QK_STATUS_D_115);
                //        return true;
                //    }
                //    else
                //        return false;
                //}


                StatementPrintCountForm prForm = new StatementPrintCountForm();

                // TODO [GSPO-3612] : печатать можно пакет документов с любого статуса 
                //if (((Data.Quality.DocsRow)SelectedDoc).Status_ID != "100" && !isRepeatPrint)
                //    prForm.IsFullPrintEnabled = false;  // На любом статусе, кроме 100 возможна лишь печать актов и перечней

                if (prForm.ShowDialog() == DialogResult.OK)
                {
                    #region Режим печати пакета документов
                    if (prForm.IsFullPackagePrintModeSelected)
                    {

                        var printParameters = new GeneralDocsCopiesCount()
                        {
                            StatementCopiesCount = prForm.StatementCount,
                            StatementListCopiesCount = prForm.StatementListCount,
                            SearchParameter = null
                        };

                        this.PrintDocPackages(printParameters);
                    }
                    #endregion

                    #region Режим печати главных документов
                    else
                    {
                        // Не выбран ни один из документов
                        if (prForm.StatementCount == 0 && prForm.StatementListCount == 0)
                            return false;

                        BackgroundWorker printWorker = new BackgroundWorker();
                        printWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                            {
                                try
                                {
                                    CrystalDecisions.CrystalReports.Engine.ReportClass report = null;
                                    this.StatementPrepare(quality, this.CurrentDocId);

                                    if (waitProcessForm.InvokeRequired)
                                        waitProcessForm.Invoke((MethodInvoker)delegate() { waitProcessForm.ActionText = "Печать основных документов..."; });
                                    else
                                        waitProcessForm.ActionText = "Печать основных документов...";

                                    // Печать заявки
                                    if (prForm.StatementCount > 0)
                                    {
                                        report = SelectedDoc != null && SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN ? (ReportClass)new QualityStatementIMNReport() : new QualityStatementReportUpdated();
                                        report.SetDataSource(quality);
                                        report.PrintOptions.PrinterName = WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPrinterName;

                                        if (string.IsNullOrEmpty(report.PrintOptions.PrinterName))
                                            report.PrintOptions.PrinterName = new PrinterSettings().PrinterName;

                                        for (int i = 0; i < prForm.StatementCount; i++)
                                        {
                                            report.PrintToPrinter(1, true, 1, 0);
                                            Thread.Sleep(100);

                                            // логирование факта печати
                                            if (i == prForm.StatementCount - 1)
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "QK", 22, Convert.ToInt64(this.CurrentDocId), "0A", 0, report.PrintOptions.PrinterName, Convert.ToByte(prForm.StatementCount));
                                        }
                                    }

                                    // Печать перечня
                                    if (prForm.StatementListCount > 0)
                                    {
                                        report = SelectedDoc != null && SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN ? (ReportClass)new QualityStatementListIMNReportUpdated() : new QualityStatementListReportUpdated();
                                        report.SetDataSource(quality);
                                        report.PrintOptions.PrinterName = WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPrinterName;

                                        if (string.IsNullOrEmpty(report.PrintOptions.PrinterName))
                                            report.PrintOptions.PrinterName = new PrinterSettings().PrinterName;

                                        for (int i = 0; i < prForm.StatementListCount; i++)
                                        {
                                            report.PrintToPrinter(1, true, 1, 0);
                                            Thread.Sleep(100);

                                            // логирование факта печати
                                            if (i == prForm.StatementListCount - 1)
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "QK", 22, Convert.ToInt64(this.CurrentDocId), "0C", 0, report.PrintOptions.PrinterName, Convert.ToByte(prForm.StatementListCount));
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    e.Result = ex;
                                }
                            };

                        printWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                        {
                            if (e.Result is Exception)
                                this.ShowError(e.Result as Exception);

                            waitProcessForm.CloseForce();
                        };

                        waitProcessForm.ActionText = "Подготовка печати основных документов...";
                        printWorker.RunWorkerAsync();
                        waitProcessForm.ShowDialog();
                    }
                    #endregion

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REDFORM"))
                {
                    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                        "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                    errorForm.TimeOut = 2000;
                    errorForm.ShowDialog();
                }
                else
                    ShowError(ex);

                return false;
            }
        }

        /// <summary>
        /// Кол-во экземпляров основных документов выводимых на печать
        /// </summary>
        public class GeneralDocsCopiesCount
        {
            /// <summary>
            /// Кол-во копий заявок
            /// </summary>
            public int StatementCopiesCount { get; set; }

            /// <summary>
            /// Кол-во копий перечней
            /// </summary>
            public int StatementListCopiesCount { get; set; }

            /// <summary>
            /// Параметр для режима печати
            /// </summary>
            public string SearchParameter { get; set; }
        }

        /// <summary>
        /// Кол-во экземпляров основных документов выводимых на печать для иммунобиологии 
        /// </summary>
        public class GeneralIMNDocsCopiesCount
        {
            /// <summary>
            /// Кол-во копий заявок
            /// </summary>
            public int? RequestCopiesCount { get; set; }

            /// <summary>
            /// Кол-во копий ведомостей
            /// </summary>
            public int? StatementCopiesCount { get; set; }

            /// <summary>
            /// Кол-во копий сертификата
            /// </summary>
            public int? SertCopiesCount { get; set; }

        }



        #region ПЕЧАТЬ ПАКЕТА ДОКУМЕНТОВ В ФОНОВОМ ПОТОКЕ

        /// <summary>
        /// Печать пакета доументов
        /// </summary>
        private void PrintDocPackages(GeneralIMNDocsCopiesCount printParameters)
        {
            BackgroundWorker printPackageWorker = new BackgroundWorker();
            printPackageWorker.DoWork += new DoWorkEventHandler(printPackageIMN_DoWork);
            printPackageWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printPackageWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Подготовка печати пакета документов...";

            printPackageWorker.RunWorkerAsync(printParameters);
            waitProcessForm.ShowDialog();
        }


        /// <summary>
        /// Печать пакета доументов
        /// </summary>
        private void PrintDocPackages(GeneralDocsCopiesCount printParameters)
        {
            BackgroundWorker printPackageWorker = new BackgroundWorker();
            printPackageWorker.DoWork += new DoWorkEventHandler(printPackageWorker_DoWork);
            printPackageWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printPackageWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Подготовка печати пакета документов...";

            printPackageWorker.RunWorkerAsync(printParameters);
            waitProcessForm.ShowDialog();
        }

        void printPackageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (waitProcessForm.InvokeRequired)
                    waitProcessForm.Invoke((MethodInvoker)delegate() { waitProcessForm.ActionText = "Получение реестра печатаемых документов..."; });
                else
                    waitProcessForm.ActionText = "Получение реестра печатаемых документов...";

                var dsSertImages = this.AdaptOrderImagesSource((e.Argument as GeneralDocsCopiesCount).SearchParameter);
                if (dsSertImages.QualityDocumentsList.Count == 0)
                    throw new Exception("Реестр печатаемых документов пустой!");

                this.PrepareOrderImagesForPrinting(dsSertImages, e.Argument as GeneralDocsCopiesCount);

                // Печать реестра печатаемых изображений документов
                using (QualityDocumentsListReport registryReport = new QualityDocumentsListReport())
                {
                    registryReport.SetDataSource(dsSertImages);
                    registryReport.SetParameterValue(registryReport.Parameter_DocID.ParameterFieldName, this.CurrentDocId);
                    using (ReportForm form = new ReportForm())
                    {
                        form.ReportDocument = registryReport;
                        form.Print();

                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "QK", 22, Convert.ToInt64(this.CurrentDocId), "00", Convert.ToInt16(dsSertImages.QualityDocumentsList.Count), form.PrinterName, 1);
                    }
                }

                if (waitProcessForm.InvokeRequired)
                    waitProcessForm.Invoke((MethodInvoker)delegate() { waitProcessForm.ActionText = "Печать пакета документов..."; });
                else
                    waitProcessForm.ActionText = "Печать пакета документов...";

                if (this.DocumentsQueue.Count > 0)
                {
                    this.PrintImagesList();

                    if (string.IsNullOrEmpty((e.Argument as GeneralDocsCopiesCount).SearchParameter))
                        ChangeSampleStatusTo(this.CurrentDocId, "110");
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void printPackageIMN_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (waitProcessForm.InvokeRequired)
                    waitProcessForm.Invoke((MethodInvoker)delegate() { waitProcessForm.ActionText = "Получение реестра печатаемых документов..."; });
                else
                    waitProcessForm.ActionText = "Получение реестра печатаемых документов...";

                var args = e.Argument as GeneralIMNDocsCopiesCount;
                if (args == null)
                    return;

                // Печать заявки
                if (args.RequestCopiesCount.HasValue)
                {
                    using (var header = new QK_RequestAnalysisTableAdapter())
                    {
                        var dsRequest = header.GetData(CurrentDocId);

                        if (dsRequest != null)
                        {
                            var repRquest = new QKRequestAnalysis();
                            repRquest.SetDataSource((DataTable)dsRequest);
                            repRquest.PrintToPrinter(args.RequestCopiesCount.Value, false, 1, 0);
                            //using (var reportForm = new ReportForm() { ShowInTaskbar = false })
                            //{
                            //    reportForm.ReportDocument = repRquest;
                            //    reportForm.ShowDialog();
                            //}
                        }
                    }
                }

                // Печать ведомости
                if (args.StatementCopiesCount.HasValue)
                {
                    var repStatement = new QKStatement();
                    using (var adapter = new QK_StatementTableAdapter())
                        foreach (DataGridViewRow dgvRow in dgvLines.Rows)
                        {
                            var dbRow = (dgvRow.DataBoundItem as DataRowView).Row as Data.Quality.DocDetailsRow;
                            if (dbRow == null)
                                continue;

                            var dsStatement = adapter.GetData(CurrentDocId, dbRow.Item_ID, dbRow.VendorLot);
                            if (dsStatement == null)
                                continue;

                            repStatement.SetDataSource((DataTable)dsStatement);
                            repStatement.PrintToPrinter(args.StatementCopiesCount.Value, false, 1, 0);
                        }
                }

                if (args.SertCopiesCount.HasValue)
                {
                    using (var adapter = new SertImagesTableAdapter())
                        foreach (DataGridViewRow dgvRow in dgvLines.Rows)
                        {
                            var dbRow = (dgvRow.DataBoundItem as DataRowView).Row as Data.Quality.DocDetailsRow;
                            if (dbRow == null)
                                continue;

                            var dsSert = adapter.GetData(dbRow.Item_ID, dbRow.VendorLot);
                            if (dsSert == null)
                                continue;
                            foreach (DataRow item in dsSert.Rows)
                            {
                                var iData = item as Sert.SertImagesRow;
                                if (iData == null)
                                    continue;
                                var _images = ImageUtils.ExtractImageLayersFromDataBuffer(iData.ImageBody, iData.ImageExt);
                                if (_images == null || _images.Count == 0)
                                    continue;

                                SertImageList = _images;

                                PrintSert((short)args.SertCopiesCount.Value);
                            }
                        }
                }

                if (waitProcessForm.InvokeRequired)
                    waitProcessForm.Invoke((MethodInvoker)delegate() { waitProcessForm.ActionText = "Печать пакета документов..."; });
                else
                    waitProcessForm.ActionText = "Печать пакета документов...";

                if (this.DocumentsQueue.Count > 0)
                    this.PrintImagesList();
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void printPackageWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);

            waitProcessForm.CloseForce();
        }


        /// <summary>
        /// Список изображений для печати
        /// </summary>
        List<ImageToPrint> printedImages = new List<ImageToPrint>();

        /// <summary>
        /// Тэг для определения наличия документа
        /// </summary>
        private const string STR_DOC_EXISTS = "Есть";

        /// <summary>
        /// Тэг для документа "Заявка"
        /// </summary>
        private const string STR_STATEMENT = "Заявка";

        /// <summary>
        /// Тэг для документа "Перечень"
        /// </summary>
        private const string STR_STATEMENT_LIST = "Перечень";

        /// <summary>
        /// Тэг для сертификата качества
        /// </summary>
        private const string STR_CERTIFICATE = "Сертификат качества на серию";

        /// <summary>
        /// Подготовка списка изображений к печати
        /// </summary>
        /// <param name="dsImages"></param>
        private void PrepareOrderImagesForPrinting(Data.Sert dsImages, GeneralDocsCopiesCount printParametersForGeneralDocs)
        {
            this.printedImages.Clear();
            this.totalPagesCount = 0;

            #region Старая реализация
            //foreach (Data.Sert.QualityDocumentsPicturesRow rowImage in dsImages.QualityDocumentsPictures)
            //{
            //    var registryItem = dsImages.QualityDocumentsList.
            //        Select(string.Format("{0} = {1}", dsImages.QualityDocumentsList.IDColumn.Caption, rowImage.ID), string.Empty)[0];

            //    string header = registryItem[dsImages.QualityDocumentsList.DocDescColumn].ToString();
            //    int cntCopies = Convert.ToInt32(registryItem[dsImages.QualityDocumentsList.cntCopyColumn].ToString());

            //    foreach (ImageToPrint image in ImageToPrint.GetCreatedImages(rowImage.Img_ID, header, rowImage.BinaryData, cntCopies))
            //    {
            //        // Цикл по кол-ву копий изображений
            //        for (int idxCopy = 0; idxCopy < image.CopiesNumber; idxCopy++)
            //        {
            //            var imageToAdd = idxCopy == 0 ? image : (ImageToPrint)image.Clone();
            //            printedImages.Add(imageToAdd);

            //            // TODO временно добавляем под общую ветку печати
            //            this.images.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer(WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.BillOfExchange,
            //                0, "", "", "", imageToAdd.ID, imageToAdd.Image)
            //                {
            //                    Header = string.Format("{0} (стр. {1} из {2})", imageToAdd.Header, imageToAdd.Page, imageToAdd.TotalPages)
            //                });
            //        }
            //    }
            //}
            #endregion

            #region Реализация с подсчетом к-ва страниц (малоэффективно -> закомментировано)
            //foreach (Data.Sert.QualityDocumentsListRow row in dsImages.QualityDocumentsList)
            //{
            //    if (row.IsDataIDNull() || row.DataID == Guid.Empty)
            //        continue;

            //    foreach (ImageToPrint image in ImageToPrint.GetCreatedImages(
            //        row.ID,
            //        string.Format("{0} - {1}", row.DocDesc, row.DocValue),
            //        row.DataID,
            //        row.cntCopy))
            //    {
            //        // Цикл по кол-ву копий изображений
            //        for (int idxCopy = 0; idxCopy < image.CopiesNumber; idxCopy++)
            //        {
            //            printedImages.Add(image);

            //            // TODO временно добавляем под общую ветку печати
            //            this.images.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer(WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.BillOfExchange,
            //                0, "", "", "", image.ID, image.Image)
            //                {
            //                    Header = string.Format("{0} (стр. {1} из {2})", image.Header, image.Page, image.TotalPages),
            //                    PageIndex = image.Page - 1,
            //                    ImageDataID = image.ImageDataID
            //                });
            //        }
            //    }
            //}
            #endregion

            #region Реализация з отсутствием подсчета страниц (легковесный обьект)
            foreach (Data.Sert.QualityDocumentsListRow row in dsImages.QualityDocumentsList)
            {
                var docType = row.IsDocTypeNull() ? (string)null : row.DocType;

                string typeName = row.iSource;
                var dataSourceType = DocImageProxy.GetDataSourceType(typeName);


                if (row.IsPersNull() || row.Pers != STR_DOC_EXISTS)
                    continue;

                if (dataSourceType == QualityDocumentDataSource.Accantum)
                {
                    if (row.IsDataIDNull() || row.DataID <= 0)
                        continue;
                }

                int? item_id = row.IsItem_IDNull() ? (int?)null : row.Item_ID;
                string docCaption = string.Format("{0} - {1}", row.DocDesc, row.DocValue);
                int docPageCount = row.IsDocPageCountNull() ? 0 : row.DocPageCount;
                int? imageDataID = row.IsDataIDNull() ? (int?)null : row.DataID;

                int docCopiesNumber = row.cntCopy;
                //#region Анализ кол-ва копий 
                //switch (row.DocDesc)
                //{ 
                //    case STR_STATEMENT :
                //        row.cntCopy = docCopiesNumber = printParametersForGeneralDocs.StatementCopiesCount;
                //        break;
                //    case STR_STATEMENT_LIST:
                //        row.cntCopy = docCopiesNumber = printParametersForGeneralDocs.StatementListCopiesCount;
                //        break;
                //    default:
                //        break;
                //}
                //#endregion

                bool isImn = SelectedDoc != null && SelectedDoc.Doc_Code == Constants.QK_DocCode_IMN;

                this.DocumentsQueue.Enqueue(new DocImageProxy(this.CurrentDocId, docType, row.DocDesc, row.DocValue, docCaption, row.iSource, item_id, imageDataID, docCopiesNumber, docPageCount, isImn) { UserID = this.UserID });
                this.totalPagesCount += docPageCount;

            }
            #endregion
        }

        /// <summary>
        /// Очередь документов
        /// </summary>
        Queue<DocImageProxy> DocumentsQueue = new Queue<DocImageProxy>();

        /// <summary>
        /// Класс изображений копий документов для печати
        /// </summary>
        [Obsolete]
        private class ImageToPrint //: ICloneable
        {
            /// <summary>
            /// Страница изображения (многослойного)
            /// </summary>
            public int Page { get; private set; }

            /// <summary>
            /// Кол-во страниц изображения (многослойного)
            /// </summary>
            public int TotalPages { get; private set; }

            /// <summary>
            /// Кол-во копий
            /// </summary>
            public int CopiesNumber { get; private set; }

            /// <summary>
            /// Ид-р записи изображения
            /// </summary>
            public int ID { get; private set; }

            /// <summary>
            /// Ид-р нахождения изображения в БД Аккантум
            /// </summary>
            public int ImageDataID { get; private set; }

            /// <summary>
            /// Копия документа (изображение)
            /// </summary>
            public Image Image { get; private set; }

            /// <summary>
            /// Колонтитул 
            /// </summary>
            public string Header { get; private set; }

            private ImageToPrint(int id, string header, /*Image image*/ int imageDataID, int page, int totalPages, int cntCopies)
            {
                this.ID = id;
                this.Header = header;
                //this.Image = image;
                this.ImageDataID = imageDataID;
                this.Page = page;
                this.TotalPages = totalPages;
                this.CopiesNumber = cntCopies;

                this.Image = new Bitmap(1, 1);
            }

            /// <summary>
            /// Создание списка изображений для печати с учетом многослойности
            /// </summary>
            /// <param name="id"></param>
            /// <param name="header"></param>
            /// <param name="bufferImage"></param>
            /// <param name="cntCopies"></param>
            /// <returns></returns>
            public static List<ImageToPrint> GetCreatedImages(int id, string header, int imageDataID, int cntCopies)
            {
                List<ImageToPrint> imagesList = new List<ImageToPrint>();

                using (Data.SertTableAdapters.AccantumImagesTableAdapter adapter = new WMSOffice.Data.SertTableAdapters.AccantumImagesTableAdapter())
                    foreach (Data.Sert.AccantumImagesRow imageData in adapter.GetData(imageDataID))
                    {

                        using (MemoryStream ms = new MemoryStream(imageData.BinaryData))
                        {
                            Image rootImage = Image.FromStream(ms);

                            FrameDimension frameDimension = new FrameDimension(rootImage.FrameDimensionsList[0]);
                            int cntFrames = rootImage.GetFrameCount(frameDimension);

                            for (int idxFrame = 0; idxFrame < cntFrames; idxFrame++)
                            {
                                rootImage.SelectActiveFrame(frameDimension, idxFrame);
                                imagesList.Add(new ImageToPrint(id, header, imageDataID /*(Image)rootImage.Clone()*/, idxFrame + 1, cntFrames, cntCopies));
                            }

                            rootImage.Dispose();
                        }

                        break;
                    }

                return imagesList;
            }

            #region ICloneable Members

            ///// <summary>
            ///// Клонирование экземпляра
            ///// </summary>
            ///// <returns></returns>
            //public object Clone()
            //{
            //    return new ImageToPrint(this.ID, this.Header, (Image)this.Image.Clone(), this.Page, this.TotalPages, this.CopiesNumber);
            //}

            #endregion
        }

        /// <summary>
        /// Тип источника данных для документа
        /// </summary>

        public enum QualityDocumentDataSource
        {
            WMS,
            Accantum,
            Kadex,
            Sert,

            Unknown
        }

        /// <summary>
        /// Документ-изображение
        /// </summary>
        private class DocImageProxy : IDisposable
        {
            /// <summary>
            /// Автор печати
            /// </summary>
            public long UserID { get; set; }

            /// <summary>
            /// Номер документа 
            /// </summary>
            public long DocID { get; set; }

            /// <summary>
            /// Тип документа
            /// </summary>
            public string DocType { get; set; }

            /// <summary>
            /// Заголовок документа
            /// </summary>
            public string DocCaption { get; private set; }

            /// <summary>
            /// Название документа
            /// </summary>
            public string DocName { get; private set; }

            /// <summary>
            /// Номер документа
            /// </summary>
            public string DocNumber { get; private set; }

            /// <summary>
            /// Тип источника данных для документа
            /// </summary>
            public QualityDocumentDataSource DataSourceType { get; private set; }

            /// <summary>
            /// Количество копий документа
            /// </summary>
            public int CopiesNumber { get; private set; }

            /// <summary>
            /// Ид-р изображения в БД Аккантум
            /// </summary>
            public int? ImageDataID { get; private set; }

            /// <summary>
            /// Количество слоев в изображении
            /// </summary>
            public int LayersCount { get; private set; }

            /// <summary>
            /// Код товара
            /// </summary>
            public int? Item_ID { get; private set; }

            /// <summary>
            /// Признак иммуобиологии
            /// </summary>
            public bool IsImn { get; set; }

            /// <summary>
            /// Список слоев изображения
            /// </summary>
            public List<DocImageLayer> DocImageLayers = new List<DocImageLayer>();

            /// <summary>
            /// Отчет (альтернатива изображенеиям)
            /// </summary>
            public CrystalDecisions.CrystalReports.Engine.ReportClass Report { get; set; }

            public Data.Quality ReportDataSource { get; set; }

            public DocImageProxy(long docID, string docType, string docName, string docNumber, string docCaption, string sourceType, int? item_id, int? imageDataID, int copiesNumber, int layersCount, bool isImn)
            {
                this.DocID = docID;
                this.DocType = docType;
                this.DocName = docName;
                this.DocNumber = docNumber;
                this.DocCaption = docCaption;
                this.Item_ID = item_id;
                this.ImageDataID = imageDataID;
                this.CopiesNumber = copiesNumber;
                this.LayersCount = layersCount;

                this.DataSourceType = DocImageProxy.GetDataSourceType(sourceType);

                this.IsImn = isImn;
            }

            /// <summary>
            /// Определение типа документа
            /// </summary>
            /// <param name="dataSourceTypeName"></param>
            /// <returns></returns>
            public static QualityDocumentDataSource GetDataSourceType(string dataSourceTypeName)
            {
                try
                {
                    return (QualityDocumentDataSource)Enum.Parse(typeof(QualityDocumentDataSource), dataSourceTypeName);
                }
                catch
                {
                    return QualityDocumentDataSource.Unknown;
                }
            }

            /// <summary>
            /// Загрузка главного изображения
            /// </summary>
            public void LoadImageLayers()
            {
                try
                {
                    #region Если изображения получены из БД Аккантум

                    if (this.DataSourceType == QualityDocumentDataSource.Accantum)
                    {
                        Data.Sert.AccantumImagesDataTable table = null;
                        using (Data.SertTableAdapters.AccantumImagesTableAdapter adapter = new WMSOffice.Data.SertTableAdapters.AccantumImagesTableAdapter())
                            table = adapter.GetData(this.ImageDataID);

                        var imageLayers = new List<Image>();
                        foreach (Data.Sert.AccantumImagesRow row in table.Rows)
                            foreach (var image in ImageUtils.ExtractImageLayersFromDataBuffer(row.BinaryData, row.IsImageExtNull() ? string.Empty : row.ImageExt))
                                if (image != null)
                                    imageLayers.Add(image);

                        int idxImage = 0;
                        foreach (var image in imageLayers)
                            this.DocImageLayers.Add(new DocImageLayer(this.DocCaption, image, idxImage++, imageLayers.Count));
                    }

                    #endregion

                    #region Если изображения получены из БД Серт

                    if (this.DataSourceType == QualityDocumentDataSource.Sert)
                    {
                        Data.Sert.SertImagesDataTable table = null;
                        using (Data.SertTableAdapters.SertImagesTableAdapter adapter = new WMSOffice.Data.SertTableAdapters.SertImagesTableAdapter())
                            table = adapter.GetData(this.Item_ID, this.DocNumber);

                        var imageLayers = new List<Image>();
                        foreach (Data.Sert.SertImagesRow row in table.Rows)
                            foreach (var image in ImageUtils.ExtractImageLayersFromDataBuffer(row.ImageBody, row.IsImageExtNull() ? string.Empty : row.ImageExt))
                                if (image != null)
                                    imageLayers.Add(image);

                        int idxImage = 0;
                        foreach (var image in imageLayers)
                            this.DocImageLayers.Add(new DocImageLayer(this.DocCaption, image, idxImage++, imageLayers.Count));
                    }

                    #endregion

                    #region Если изображения получены из БД Кадекс

                    if (this.DataSourceType == QualityDocumentDataSource.Kadex)
                    {
                        Data.Sert.ItemRegCertImagesDataTable table = null;
                        using (Data.SertTableAdapters.ItemRegCertImagesTableAdapter adapter = new Data.SertTableAdapters.ItemRegCertImagesTableAdapter())
                            table = adapter.GetData(this.Item_ID, null);

                        var imageLayers = new List<Image>();
                        foreach (Data.Sert.ItemRegCertImagesRow row in table.Rows)
                            foreach (var image in ImageUtils.ExtractImageLayersFromDataBuffer(row.ImageBody, row.IsImageExtNull() ? string.Empty : row.ImageExt))
                                if (image != null)
                                    imageLayers.Add(image);

                        int idxImage = 0;
                        foreach (var image in imageLayers)
                            this.DocImageLayers.Add(new DocImageLayer(this.DocCaption, image, idxImage++, imageLayers.Count));
                    }

                    #endregion

                    #region Если изображения получены из базы ВМС

                    if (this.DataSourceType == QualityDocumentDataSource.WMS)
                    {
                        this.PrepareReportSource();

                        if (this.DocName == STR_STATEMENT)
                            this.Report = IsImn ? (ReportClass)new QualityStatementIMNReport() : (ReportClass)new QualityStatementReportUpdated();

                        if (this.DocName == STR_STATEMENT_LIST)
                            this.Report = IsImn ? (ReportClass)new QualityStatementListIMNReportUpdated() : (ReportClass)new QualityStatementListReportUpdated();

                        this.DocImageLayers.Add(EmptyImageLayer.Create());
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// Подготовка данных для отчета 
            /// </summary>
            public void PrepareReportSource()
            {
                this.ReportDataSource = new WMSOffice.Data.Quality();

                using (Data.QualityTableAdapters.StatementReportHeaderTableAdapter qualityAdapter = new Data.QualityTableAdapters.StatementReportHeaderTableAdapter())
                {
                    try
                    {
                        qualityAdapter.Fill(this.ReportDataSource.StatementReportHeader, this.DocID);
                    }
                    catch { }
                }

                using (Data.QualityTableAdapters.StatementReportDetailTableAdapter qualityAdapter = new Data.QualityTableAdapters.StatementReportDetailTableAdapter())
                {
                    try
                    {
                        qualityAdapter.Fill(this.ReportDataSource.StatementReportDetail, this.DocID);
                    }
                    catch { }
                }
            }

            /// <summary>
            /// Печать отчета
            /// </summary>
            public void PrintReport()
            {
                this.Report.SetDataSource(this.ReportDataSource);
                this.Report.PrintOptions.PrinterName = WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPrinterName;

                if (string.IsNullOrEmpty(this.Report.PrintOptions.PrinterName))
                    this.Report.PrintOptions.PrinterName = new PrinterSettings().PrinterName;

                for (int idxCopy = 0; idxCopy < this.CopiesNumber; idxCopy++)
                {
                    this.Report.PrintToPrinter(1, true, 1, 0);
                    //Thread.Sleep(100);

                    // логирование факта печати
                    if (idxCopy == this.CopiesNumber - 1)
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "QK", 22, Convert.ToInt64(this.DocID), this.DocType, 0, this.Report.PrintOptions.PrinterName, Convert.ToByte(this.CopiesNumber));
                }
            }

            #region IDisposable Members

            public void Dispose()
            {
                foreach (var layer in this.DocImageLayers)
                    layer.Dispose();

                if (this.Report != null)
                    this.Report.Dispose();

                if (this.ReportDataSource != null)
                    this.ReportDataSource.Dispose();
            }

            #endregion
        }

        /// <summary>
        /// Пустой слой
        /// </summary>
        private class EmptyImageLayer : DocImageLayer
        {
            private EmptyImageLayer()
            {

            }

            /// <summary>
            /// Создание пустого слоя
            /// </summary>
            /// <returns></returns>
            public static EmptyImageLayer Create()
            {
                return new EmptyImageLayer();
            }
        }

        /// <summary>
        /// Слой документа-изображения
        /// </summary>
        private class DocImageLayer : IDisposable
        {
            public string Header { get; private set; }

            public Image Image { get; private set; }

            public int LayerIndex { get; private set; }

            public int TotalLayers { get; private set; }

            public DocImageLayer()
            {

            }

            public DocImageLayer(string header, Image image, int layerIndex, int totalLayers)
            {
                this.Image = image;
                this.LayerIndex = layerIndex;
                this.TotalLayers = totalLayers;
                this.Header = string.Format("{0} (стр. {1} из {2})", header, layerIndex + 1, totalLayers);
            }

            #region IDisposable Members

            public void Dispose()
            {
                if (this.Image != null)
                {
                    this.Image.Dispose();
                    this.Image = null;
                }
            }

            #endregion
        }

        private List<Image> SertImageList { get; set; }

        private Image SertImage { get; set; }

        private void PrintSert(short copies)
        {
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = "Пакет сертификата по заявке " + this.CurrentDocId;
            pd.PrintController = new StandardPrintController();
            pd.PrintPage += new PrintPageEventHandler(PrintSertPage);
            //pd.EndPrint += new PrintEventHandler(pd_EndPrint);

            if (!WMSOffice.Dialogs.Sert.SertPrintSettings.UseDefaultPrinter)
                pd.PrinterSettings.PrinterName = WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPrinterName;

            pd.PrinterSettings.Copies = copies;

            foreach (var item in SertImageList)
            {
                SertImage = item;
                pd.Print();
            }
        }

        private void PrintImagesList()
        {
            this.CurrentHeaderFont = new Font("Courier New", 9);
            this.CurrentFooterFont = new Font("Courier New", 12);

            currentPageNumber = 1;

            Thread loadThread = new Thread(this.PreparePrintedDocImagesQueue);
            loadThread.Start();

            Thread printThread = null;

            PrintedDocumentsQueue.Clear();
            currentPrintedDocImage = null;

            do
            {
                for (; ; )
                {
                    #region Анализ и печать документов по шаблону
                    if (currentPrintedDocImage == null)
                    {
                        if (PrintedDocumentsQueue.Count == 0)
                        {
                            lock (PrintedDocumentsQueue)
                            {
                                Monitor.Wait(PrintedDocumentsQueue);
                            }
                        }
                    }

                    lock (PrintedDocumentsQueue)
                    {
                        if (PrintedDocumentsQueue.Count > 0 && PrintedDocumentsQueue.Peek() != null && PrintedDocumentsQueue.Peek().DataSourceType == QualityDocumentDataSource.WMS)
                            currentPrintedDocImage = PrintedDocumentsQueue.Dequeue();
                    }

                    lock (this.DocumentsQueue)
                    {
                        Monitor.Pulse(this.DocumentsQueue);
                    }

                    if (currentPrintedDocImage != null)
                    {
                        if (currentPrintedDocImage.DocImageLayers.Count == 0)
                            break;

                        currentPrintedDocImageLayer = currentPrintedDocImage.DocImageLayers[0];
                        if (currentPrintedDocImageLayer.GetType() == typeof(EmptyImageLayer))
                        {
                            Thread printCrystalReportThread = new Thread(currentPrintedDocImage.PrintReport);
                            printCrystalReportThread.Start();
                            printCrystalReportThread.Join();

                            Thread.Sleep(1000);

                            //// Задержим текущий поток дав время на завершения печати документа по шаблону
                            //if (currentPrintedDocImage.DocName == STR_STATEMENT)
                            //    Thread.Sleep(3000);
                            //if (currentPrintedDocImage.DocName == STR_STATEMENT_LIST)
                            //    Thread.Sleep(4500);
                            currentPrintedDocImage = null;
                        }
                    }
                    else
                        break;
                    #endregion
                }

                // Остановка печати в случае достижения конца очереди (случай с отстутствием документов - изображений после печати документа по шаблону)
                if (PrintedDocumentsQueue.Count > 0 && PrintedDocumentsQueue.Peek() == null)
                    return;

                #region Печать документов-изображений
                continueIterate = false;
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = "Пакет документов по заявке " + this.CurrentDocId;
                pd.PrintController = new StandardPrintController();
                pd.PrintPage += new PrintPageEventHandler(PrintPage);
                pd.EndPrint += new PrintEventHandler(pd_EndPrint);

                if (!WMSOffice.Dialogs.Sert.SertPrintSettings.UseDefaultPrinter)
                    pd.PrinterSettings.PrinterName = WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPrinterName;

                printThread = new Thread(pd.Print);
                printThread.Start();
                printThread.Join();

                while (!continueIterate)
                {
                    Thread.Sleep(100);
                }

                if (this.DocumentsQueue.Count == 0 && this.PrintedDocumentsQueue.Count > 0 && this.PrintedDocumentsQueue.Peek() == null)
                    break;
                #endregion
            }
            while (!(this.DocumentsQueue.Count == 0 && this.PrintedDocumentsQueue.Count == 0 && currentPrintedDocImage == null));

            loadThread.Join();
        }

        bool continueIterate = false; // Признак условия перехода к следующей итерации печати WMS-документа - изображений
        void pd_EndPrint(object sender, PrintEventArgs e)
        {
            continueIterate = true;
        }

        private Queue<DocImageProxy> PrintedDocumentsQueue = new Queue<DocImageProxy>(); // очередь документов поданых на печать
        private int Capacity = 2; // Размерность буфера для размещения документов

        /// <summary>
        /// Подготовка загрузка изображений документа - подготовка к печати
        /// </summary>
        private void PreparePrintedDocImagesQueue()
        {
            while (this.DocumentsQueue.Count > 0)
            {
                if (PrintedDocumentsQueue.Count < Capacity)
                {
                    DocImageProxy item = null;
                    lock (DocumentsQueue)
                    {
                        item = DocumentsQueue.Dequeue();
                        item.LoadImageLayers();
                    }
                    lock (PrintedDocumentsQueue)
                    {
                        PrintedDocumentsQueue.Enqueue(item);
                        Monitor.Pulse(PrintedDocumentsQueue);
                    }
                }
                else
                {
                    lock (DocumentsQueue)
                    {
                        Monitor.Wait(DocumentsQueue);
                    }
                }

                #region Obsolete
                //lock (locker)
                //{
                //    var doc = this.DocumentsQueue.Dequeue();

                //    doc.LoadImageLayers();
                //    this.PrintedDocumentsQueue.Enqueue(doc);

                //    // Возобновим печать
                //    Monitor.Pulse(locker);

                //    // Приостановим загрузку изображений следующего документа
                //    Monitor.Wait(locker);
                //}
                #endregion
            }

            PrintedDocumentsQueue.Enqueue(null);
        }

        DocImageProxy currentPrintedDocImage = null; // текущий печатаемый документ
        DocImageLayer currentPrintedDocImageLayer = null; // текущий печатаемый слой документа
        int totalPagesCount = 0; // общее кол-во страниц
        int currentPageNumber = 1; // номер-текущей печатаемой страницы

        int currentDocImageCopiesNumber = 0; // кол-во копий текущего документа


        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Начало обработки текущего документа
            if (currentPrintedDocImage == null)
            {
                if (PrintedDocumentsQueue.Count == 0)
                {
                    lock (PrintedDocumentsQueue)
                    {
                        Monitor.Wait(PrintedDocumentsQueue);
                    }
                }

                lock (PrintedDocumentsQueue)
                {
                    currentPrintedDocImage = PrintedDocumentsQueue.Dequeue();

                }

                if (currentPrintedDocImage == null || currentPrintedDocImage.DocImageLayers.Count == 0)
                {
                    currentPrintedDocImage = null;
                    return;
                }

                currentDocImageCopiesNumber = currentPrintedDocImage.CopiesNumber;
                currentPrintedDocImageLayer = currentPrintedDocImage.DocImageLayers[0];

                lock (this.DocumentsQueue)
                {
                    Monitor.Pulse(this.DocumentsQueue);
                }

                if (currentPrintedDocImage == null)
                {
                    e.HasMorePages = false;
                    return;
                }
            }

            //System.Diagnostics.Debug.WriteLine(string.Format("Печать: {0} -- копия {1}", currentPrintedDocImageLayer.Header, currentPrintedDocImage.CopiesNumber - currentDocImageCopiesNumber + 1));

            e.Graphics.FillRectangle(Brushes.White, e.PageBounds);
            e.Graphics.DrawString(currentPrintedDocImageLayer.Header, CurrentHeaderFont, Brushes.Black, 20, 15);
            e.Graphics.DrawImage(currentPrintedDocImageLayer.Image, new Rectangle(e.PageBounds.X + 20, e.PageBounds.Y + 60, e.PageBounds.Width - 40, e.PageBounds.Height - 130));

            string footer = string.Format("стр. {0} из {1} (заявка № {2})", currentPageNumber, totalPagesCount, currentPrintedDocImage.DocID);
            e.Graphics.DrawString(footer, CurrentFooterFont, Brushes.Black, (e.PageBounds.Width - Convert.ToInt32(e.Graphics.MeasureString(footer, CurrentFooterFont).Width)) / 2, e.PageBounds.Height - 70);

            try
            {
                // логирование факта печати
                if (currentPrintedDocImageLayer.LayerIndex + 1 == currentPrintedDocImageLayer.TotalLayers)
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "QK", 22, Convert.ToInt64(currentPrintedDocImage.DocID), currentPrintedDocImage.DocType, 0, e.PageSettings.PrinterSettings.PrinterName, Convert.ToByte(currentPrintedDocImageLayer.TotalLayers));
            }
            catch (Exception ex)
            {

            }

            // Условие окончания печати текущего документа
            if (currentPrintedDocImageLayer.LayerIndex == currentPrintedDocImage.DocImageLayers.Count - 1)
            {

                // Если все копии документа напечатаны, то переходим к печати следующего
                if (--currentDocImageCopiesNumber == 0)
                {
                    currentPrintedDocImage.Dispose();
                    currentPrintedDocImage = null;
                    currentPageNumber++;

                    #region Анализ следующего документа на наличие шаблона печати
                    if (PrintedDocumentsQueue.Count == 0)
                    {
                        lock (PrintedDocumentsQueue)
                        {
                            Monitor.Wait(PrintedDocumentsQueue);
                        }
                    }

                    lock (this.DocumentsQueue)
                    {
                        Monitor.Pulse(this.DocumentsQueue);
                    }

                    lock (PrintedDocumentsQueue)
                    {
                        // Если следующий документ печатается из Crystal Report, то прервем очередь печати до следующего момента
                        if (PrintedDocumentsQueue.Count > 0 && (PrintedDocumentsQueue.Peek() == null || PrintedDocumentsQueue.Peek().DataSourceType == QualityDocumentDataSource.WMS))
                        {
                            e.HasMorePages = false;
                            return;
                        }
                    }
                    #endregion
                }
                // Иначе запускаем повторную печать текущего документа
                else
                {
                    if (currentPrintedDocImage == null || currentPrintedDocImage.DocImageLayers.Count == 0)
                        return;

                    currentPrintedDocImageLayer = currentPrintedDocImage.DocImageLayers[0];
                    currentPageNumber -= currentPrintedDocImage.DocImageLayers.Count;
                    currentPageNumber++;
                }
            }
            // Переход к следущему слою текущего документа
            else
            {
                currentPrintedDocImageLayer = currentPrintedDocImage.DocImageLayers[currentPrintedDocImageLayer.LayerIndex + 1];
                currentPageNumber++;
            }

            // Условие завершения печати пакета документов
            if (this.DocumentsQueue.Count == 0 && this.PrintedDocumentsQueue.Count == 0 && currentPrintedDocImage == null)
                e.HasMorePages = false;
            else
                e.HasMorePages = true;
        }

        private void PrintSertPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.PageBounds);
            //e.Graphics.DrawString(currentPrintedDocImageLayer.Header, CurrentHeaderFont, Brushes.Black, 20, 15);
            e.Graphics.DrawImage(SertImage, new Rectangle(e.PageBounds.X + 20, e.PageBounds.Y + 60, e.PageBounds.Width - 40, e.PageBounds.Height - 130));

            //string footer = string.Format("стр. {0} из {1} (заявка № {2})", currentPageNumber, totalPagesCount, currentPrintedDocImage.DocID);
            //e.Graphics.DrawString(footer, CurrentFooterFont, Brushes.Black, (e.PageBounds.Width - Convert.ToInt32(e.Graphics.MeasureString(footer, CurrentFooterFont).Width)) / 2, e.PageBounds.Height - 70);
        }


        /// <summary>
        /// Подготовка списка изображений для ГТД (таможенная декларация)
        /// </summary>
        [Obsolete]
        private void PrepareBillOfExchange()
        {
            #region not used
            //using (Data.SertTableAdapters.OrderReports_GTDTableAdapter adapter = new WMSOffice.Data.SertTableAdapters.OrderReports_GTDTableAdapter())
            //{
            //    Data.Sert.OrderReports_GTDDataTable table = adapter.GetData(this.CurrentDocId);
            //    if (table != null && table.Rows.Count > 0)
            //    {
            //        foreach (Data.Sert.OrderReports_GTDRow row in table.Rows)
            //        {
            //            using (Data.SertTableAdapters.Images_GTDTableAdapter adapter_pict = new WMSOffice.Data.SertTableAdapters.Images_GTDTableAdapter())
            //            {
            //                Data.Sert.Images_GTDDataTable table_img = adapter_pict.GetData(row.GTD);
            //                if (table_img != null && table_img.Rows.Count > 0)
            //                {
            //                    foreach (Data.Sert.Images_GTDRow row_img in table_img.Rows)
            //                    {
            //                        // добавить добавление изображений в список для печати
            //                        Image img = null;
            //                        try
            //                        {
            //                            //this.SaveImg_tmp(row_img.BinaryData);
            //                            img = row_img.IsNull(table_img.BinaryDataColumn) ? null : /*this.UnpackImage(row_img.BinaryData)*/WMSOffice.Dialogs.Sert.SertImageUtils.UnpackImageByTCompress(row_img.BinaryData);
            //                        }
            //                        catch (Exception)
            //                        {
            //                            // UNDONE: записать в лог ошибку преобразования изображения
            //                        }

            //                        //if (img != null)
            //                        //{
            //                        //    img.Dispose();
            //                        //    img = ImageBodyReplacer; // для уменьшения объема требуемой памяти
            //                        //}

            //                        images.Add(
            //                            new WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer(
            //                                Dialogs.Sert.SertPrintingThread.CertType.BillOfExchange,
            //                                0, // item_id
            //                                string.Empty,
            //                                string.Empty, // name
            //                                string.Empty, // manufacturer
            //                                0, // image_id
            //                                img
            //                                ));
            //                    }
            //                }
            //                else
            //                {
            //                    // TODO Последний параметр подогнать под правильный тип
            //                    errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.ItemNotFound, null));
            //                }
            //            }
            //        }

            //        // TODO Последний параметр подогнать под правильный тип
            //        //if (images[images.Count - 1].Image == null)
            //        //    errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.ImageIsEmpty, null));
            //    }
            //    else
            //    {
            //        // TODO Последний параметр подогнать под правильный тип
            //        errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.ItemNotFound, null));
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// Подготовка данных изображений для печати
        /// </summary>
        private Data.Sert AdaptOrderImagesSource(string searchParameter)
        {
            Data.Sert sertDB = new WMSOffice.Data.Sert();
            var documentsList = sertDB.QualityDocumentsList;
            var documentsPictures = sertDB.QualityDocumentsPictures;
            documentsList.Clear();
            //documentsPictures.Clear();

            using (SqlConnection connection = new SqlConnection(Settings.Default.JDE_PROCConnectionString))
            {
                SqlCommand cmd = new SqlCommand(string.Format("EXECUTE [dbo].[pr_QK_GetOrderReport_Images_V5] @Doc_ID={0}, @filter={1}",
                    this.CurrentDocId,
                    searchParameter == null ? "NULL" : "'" + searchParameter + "'"), connection);

                connection.Open();
                cmd.CommandTimeout = 600; // 10 минут
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    documentsList.Rows.Add(
                                   reader[documentsList.IDColumn.Caption],
                                   reader[documentsList.DocDescColumn.Caption],
                                   reader[documentsList.cntCopyColumn.Caption],
                                   reader[documentsList.PersColumn.Caption],
                                   reader[documentsList.DocValueColumn.Caption],
                                   reader[documentsList.DataIDColumn.Caption],
                                   reader[documentsList.DocPageCountColumn.Caption],
                                   reader[documentsList.iSourceColumn.Caption],
                                   reader[documentsList.Item_IDColumn.Caption],
                                   null,
                                   reader[documentsList.DocTypeColumn.Caption]);
                }

                #region "Старая" реализация
                //int ptr = 0; // Указатель на индекс рекордсета
                //do
                //{
                //    while (reader.Read())
                //    {
                //        switch (ptr)
                //        { 
                //            case 0:
                //                documentsList.Rows.Add(
                //                    reader[documentsList.IDColumn.Caption],
                //                    reader[documentsList.DocDescColumn.Caption],
                //                    reader[documentsList.cntCopyColumn.Caption],
                //                    reader[documentsList.PersColumn.Caption],
                //                    reader[documentsList.DocValueColumn.Caption],
                //                    reader[documentsList.DataIDColumn.Caption]);
                //                break;
                //            case 1:
                //                documentsPictures.Rows.Add(
                //                    reader[documentsPictures.Img_IDColumn.Caption],
                //                    reader[documentsPictures.IDColumn.Caption],
                //                    reader[documentsPictures.BinaryDataColumn.Caption]);
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}
                //while (reader.NextResult() && ++ptr > 0);
                #endregion

                // ш/к для реестра
                var barCode = string.Format("QKWMS{0}", this.CurrentDocId);
                QualityRequestWindow.DocListBarcodePrepare(documentsList, barCode);

                documentsList.AcceptChanges();
                //documentsPictures.AcceptChanges();
                connection.Close();

                return sertDB;
            }
        }

        /// <summary>
        /// Для реестра печатаемых документов по заявке выполняем создание изображения штрих-кода
        /// </summary>
        private static void DocListBarcodePrepare(Data.Sert.QualityDocumentsListDataTable docList, string barCode)
        {
            if (docList.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(160 * 5, 60 * 5);
                barCodeCtrl.BarCodeHeight = 50 * 5;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10 * 5;
                barCodeCtrl.ShowFooter = false;
                barCodeCtrl.TopMargin = 2 * 5;
                barCodeCtrl.BarCode = barCode;
                byte[] barCodeBuffer = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCodeBuffer = ms.ToArray();
                }
                docList[0].Doc_Bar_Code_Image = barCodeBuffer;
            }
        }

        /// <summary>
        /// Список изображений для печати.
        /// </summary>
        private List<WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer> images = new List<WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer>();

        /// <summary>
        /// Список ошибок.
        /// </summary>
        private List<WMSOffice.Dialogs.Sert.SertPrintingThread.Error> errors = new List<WMSOffice.Dialogs.Sert.SertPrintingThread.Error>();

        /// <summary>
        /// Объект-заменитель изображения (для уменьшения размера выделяемой памяти на этапе загрузки всех изображений и печати контрольного листа).
        /// </summary>
        private Image ImageBodyReplacer = new Bitmap(16, 16);

        /// <summary>
        /// Загружает изображения регистрационного свидетельств
        /// </summary>
        /// <param name="docDetail"></param>
        /// <returns></returns>
        [Obsolete]
        private void GetImagesRegSertByItem(WMSOffice.Data.Quality.DocDetailsRow docDetail)
        {
            using (Data.SertTableAdapters.ItemRegCertImagesTableAdapter adapter = new Data.SertTableAdapters.ItemRegCertImagesTableAdapter())
            {
                Data.Sert.ItemRegCertImagesDataTable table = adapter.GetData(docDetail.Item_ID, null);
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (Data.Sert.ItemRegCertImagesRow itemImageRow in table.Rows)
                    {
                        // проверка, есть ли такое изображение
                        bool found = false;
                        foreach (WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer ic in images)
                            if (ic.ImageID == itemImageRow.ImageID && ic.CertType == WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.RegCert)
                                found = true;

                        if (!found)
                        {
                            Image img = null;
                            try
                            {
                                img = itemImageRow.IsImageBodyNull() ? null : WMSOffice.Dialogs.Sert.SertImageUtils.UnpackImageByTCompress(itemImageRow.ImageBody);
                            }
                            catch (Exception)
                            {
                                // UNDONE: записать в лог ошибку преобразования изображения
                            }

                            if (img != null)
                            {
                                img.Dispose();
                                img = ImageBodyReplacer; // для уменьшения объема требуемой памяти
                            }

                            images.Add(
                                new WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer(
                                    Dialogs.Sert.SertPrintingThread.CertType.RegCert,
                                    docDetail.Item_ID,
                                    string.Empty,
                                    docDetail.ItemName,
                                    docDetail.Manufacturer,
                                    itemImageRow.ImageID,
                                    img
                                    ));
                        }

                        // TODO Последний параметр подогнать под правильный тип
                        if (images[images.Count - 1].Image == null)
                            errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.ImageIsEmpty, null));
                    }
                }
                else
                {
                    // TODO Последний параметр подогнать под правильный тип
                    errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.ItemNotFound, null));
                }
            }
        }

        /// <summary>
        /// Загружает изображения, привязанные к товару (без привязок к сериям).
        /// </summary>
        /// <param name="docDetail">Данные "строки" заявки.</param>
        /// <returns>Признак, показывающий, была ли найдена информация об этом товаре.</returns>
        [Obsolete]
        private bool GetImagesByItem(WMSOffice.Data.Quality.DocDetailsRow docDetail)
        {
            bool result = false;
            using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
            {
                //adapter.SetConnectionString(WMSOffice.Dialogs.Sert.SertPrintSettings.GetSertDBConnectionString());
                object itemInfoExists = adapter.ItemInfoExists((int)docDetail.Item_ID);
                if (itemInfoExists != null && !itemInfoExists.Equals(DBNull.Value) && itemInfoExists.ToString() == "1")
                {
                    result = true;
                    using (Data.SertTableAdapters.ItemImagesTableAdapter itemImagesAdapter = new Data.SertTableAdapters.ItemImagesTableAdapter())
                    {
                        //itemImagesAdapter.Connection.ConnectionString = WMSOffice.Dialogs.Sert.SertPrintSettings.GetSertDBConnectionString();
                        Data.Sert.ItemImagesDataTable table = itemImagesAdapter.GetData(docDetail.Item_ID);
                        foreach (Data.Sert.ItemImagesRow itemImageRow in table.Rows)
                        {
                            // проверка, есть ли такое изображение
                            bool found = false;
                            foreach (WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer ic in images)
                                if (ic.ImageID == itemImageRow.ImageID && ic.CertType == WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.QualityCert)
                                    found = true;
                            if (!found)
                            {
                                Image img = null;
                                try
                                {
                                    img = itemImageRow.IsImageBodyNull() ? null : WMSOffice.Dialogs.Sert.SertImageUtils.UnpackImageByTCompress(itemImageRow.ImageBody);
                                }
                                catch (Exception)
                                {
                                    // UNDONE: записать в лог ошибку преобразования изображения
                                }

                                if (img != null)
                                {
                                    img.Dispose();
                                    img = ImageBodyReplacer; // для уменьшения объема требуемой памяти
                                }

                                images.Add(
                                    new WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer(
                                        Dialogs.Sert.SertPrintingThread.CertType.QualityCert,
                                        docDetail.Item_ID,
                                        string.Empty,
                                        docDetail.ItemName,
                                        docDetail.Manufacturer,
                                        itemImageRow.ImageID,
                                        img
                                        ));
                            }
                            // TODO Последний параметр подогнать под правильный тип
                            if (images[images.Count - 1].Image == null)
                                errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.ImageIsEmpty, null));
                        }
                    }
                }
                else
                {
                    result = false;
                    // TODO Последний параметр подогнать под правильный тип
                    errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.ItemNotFound, null));
                }
            }
            return result;
        }

        /// <summary>
        /// Загружает изображения, привязанные к товару и серии поставщика.
        /// </summary>
        /// <param name="docDetail">Данные "строки" заявки.</param>
        [Obsolete]
        private void GetImagesByItemAndVendorLot(WMSOffice.Data.Quality.DocDetailsRow docDetail)
        {
            //using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
            //{
            //    adapter.SetConnectionString(WMSOffice.Dialogs.Sert.SertPrintSettings.GetSertDBConnectionString());
            //    object serID = adapter.GetSerID(docDetail.Item_ID, docDetail.VendorLot);
            //    if (serID != null && !serID.Equals(DBNull.Value))
            //    {
            //        using (Data.SertTableAdapters.ItemSerieImagesTableAdapter itemSerieImagesAdapter = new Data.SertTableAdapters.ItemSerieImagesTableAdapter())
            //        {
            //            itemSerieImagesAdapter.Connection.ConnectionString = WMSOffice.Dialogs.Sert.SertPrintSettings.GetSertDBConnectionString();
            //            Data.Sert.ItemSerieImagesDataTable table = itemSerieImagesAdapter.GetData((int)serID);
            //            foreach (Data.Sert.ItemSerieImagesRow itemSerieImageRow in table.Rows)
            //            {
            //                // проверка, есть ли такое изображение
            //                bool found = false;
            //                foreach (WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer ic in images)
            //                    if (ic.ImageID == itemSerieImageRow.ImageID && ic.CertType == WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.QualityCert)
            //                        found = true;

            //                if (!found)
            //                {
            //                    Image img = null;
            //                    try
            //                    {
            //                        img = itemSerieImageRow.IsImageBodyNull() ? null : WMSOffice.Dialogs.Sert.SertImageUtils.UnpackImageByTCompress(itemSerieImageRow.ImageBody);
            //                    }
            //                    catch (Exception)
            //                    {
            //                        // UNDONE: записать в лог ошибку преобразования изображения
            //                    }

            //                    if (img != null)
            //                    {
            //                        img.Dispose();
            //                        img = ImageBodyReplacer; // для уменьшения объема требуемой памяти
            //                    }

            //                    images.Add(
            //                        new WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer(
            //                            Dialogs.Sert.SertPrintingThread.CertType.QualityCert,
            //                            docDetail.Item_ID,
            //                            docDetail.VendorLot,
            //                            docDetail.ItemName,
            //                            docDetail.Manufacturer,
            //                            itemSerieImageRow.ImageID,
            //                            img
            //                            ));

            //                    // TODO Последний параметр подогнать под правильный тип
            //                    if (images[images.Count - 1].Image == null)
            //                        errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.ImageIsEmpty, null));
            //                }
            //            }
            //            // TODO Последний параметр подогнать под правильный тип
            //            if (table.Rows.Count == 0)
            //            {
            //                errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.VendorLotHasNoImages, null));
            //            }
            //        }
            //    }
            //     else
            //    {
            //        adapter.SetConnectionString(Properties.Settings.Default.JDE_PROCConnectionString);
            //        // TODO Последний параметр подогнать под правильный тип
            //        errors.Add(new WMSOffice.Dialogs.Sert.SertPrintingThread.Error(WMSOffice.Dialogs.Sert.SertPrintingThread.ErrorTypes.VendorLotNotFound, null));
            //    }
            //}
        }

        #region ТЕКУЩЕЕ СОСТОЯНИЕ ОБЪЕКТОВ ПЕЧАТИ СЕРТИФИКАТОВ
        /// <summary>
        /// Текущий режим печати.
        /// </summary>
        private WMSOffice.Dialogs.Sert.SertPrintSettings.PrintModes CurrentPrintMode { get; set; }

        /// <summary>
        /// Текущий масштаб.
        /// </summary>
        private WMSOffice.Dialogs.Sert.SertPrintSettings.Scales CurrentScale { get; set; }

        /// <summary>
        /// Текущее количество страниц печатаемых сертификатов.
        /// </summary>
        private int CurrentTotalPagesCount { get; set; }

        /// <summary>
        /// Текущий номер страницы.
        /// </summary>
        private int CurrentPageNumber { get; set; }

        /// <summary>
        /// Текущий индекс изображения.
        /// </summary>
        private int CurrentImageIndex { get; set; }

        /// <summary>
        /// Текущий индекс изображения на текущей странице (используется при масштабах 1х2, 1х4).
        /// </summary>
        private int CurrentImageOnPageIndex { get; set; }

        /// <summary>
        /// Код текущего товара.
        /// </summary>
        private double CurrentItemCode { get; set; }

        /// <summary>
        /// Номер текущей серии товара.
        /// </summary>
        private string CurrentVendorLot { get; set; }

        /// <summary>
        /// Шрифт, используемый при выводе надписей над изображениями.
        /// </summary>
        private Font CurrentHeaderFont { get; set; }

        /// <summary>
        /// Шрифт, используемый при выводе надписей внизу страниц.
        /// </summary>
        private Font CurrentFooterFont { get; set; }
        #endregion

        /// <summary>
        /// Печатает изображения сертификатов.
        /// </summary>
        [Obsolete]
        private void PrintImages()
        {
            CurrentTotalPagesCount = GetTotalPagesCount();
            if (CurrentTotalPagesCount > 0)
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = "Документы по заявке " + this.CurrentDocId; // +"-" + taskRow.DOCO.ToString();
                pd.PrintController = new StandardPrintController();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                if (!WMSOffice.Dialogs.Sert.SertPrintSettings.UseDefaultPrinter)
                    pd.PrinterSettings.PrinterName = WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPrinterName;

                // двусторонняя печать
                if (pd.PrinterSettings.CanDuplex &&
                    (CurrentPrintMode == WMSOffice.Dialogs.Sert.SertPrintSettings.PrintModes.DoubleSidedContinuous ||
                     CurrentPrintMode == WMSOffice.Dialogs.Sert.SertPrintSettings.PrintModes.DoubleSidedNewPageItem ||
                     CurrentPrintMode == WMSOffice.Dialogs.Sert.SertPrintSettings.PrintModes.DoubleSidedNewPageSerie))
                {
                    if (CurrentScale == WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x2)
                        pd.PrinterSettings.Duplex = Duplex.Horizontal;
                    else
                        pd.PrinterSettings.Duplex = Duplex.Vertical;
                }
                // если масштаб - 2 изображения на странице, страницу нужно повернуть
                if (CurrentScale == WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x2)
                {
                    pd.DefaultPageSettings.Landscape = true;
                }

                // шрифты
                if (CurrentHeaderFont != null)
                    CurrentHeaderFont.Dispose();
                if (CurrentFooterFont != null)
                    CurrentFooterFont.Dispose();
                if (CurrentScale == WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x1)
                {
                    CurrentHeaderFont = new Font("Courier New", 9);
                    CurrentFooterFont = new Font("Courier New", 12);
                }
                else if (CurrentScale == WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x2)
                {
                    CurrentHeaderFont = new Font("Courier New", 7);
                    CurrentFooterFont = new Font("Courier New", 14);
                }
                else if (CurrentScale == WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x4)
                {
                    CurrentHeaderFont = new Font("Courier New", 6);
                    CurrentFooterFont = new Font("Courier New", 12);
                }

                // страницы
                CurrentPageNumber = 0;
                CurrentImageIndex = -1;
                if (MoveToNextImage())
                {
                    CurrentItemCode = images[CurrentImageIndex].ItemCode;
                    CurrentVendorLot = images[CurrentImageIndex].VendorLot;

                    while (CurrentPageNumber < CurrentTotalPagesCount)
                        pd.Print();
                }
            }
        }

        #region РАСЧЕТНЫЕ АЛГОРИТМЫ АНАЛИЗА КОЛИЧЕСТВА ПЕЧАТАЕМЫХ СТРАНИЦ
        /// <summary>
        /// Возвращает общее количество печатаемых страниц для текущего задания.
        /// </summary>
        /// <returns>Общее количество печатаемых страниц для текущего задания</returns>
        private int GetTotalPagesCount()
        {
            int result = 0;
            CurrentImageIndex = -1;
            CurrentImageOnPageIndex = -1;
            if (MoveToNextImage())
            {
                CurrentItemCode = images[CurrentImageIndex].ItemCode;
                CurrentVendorLot = images[CurrentImageIndex].VendorLot;
            }
            CurrentImageIndex = -1;
            while (MoveToNextImage())
            {
                if (NeedNextPage())
                {
                    ++result;
                    CurrentImageOnPageIndex = 0;
                }
                else
                {
                    ++CurrentImageOnPageIndex;
                }
                CurrentItemCode = images[CurrentImageIndex].ItemCode;
                CurrentVendorLot = images[CurrentImageIndex].VendorLot;
            }
            if (CurrentImageIndex >= 0)
            {
                ++result;
            }

            return result;
        }

        /// <summary>
        /// Переходит к следующему изображению и возвращает результат перехода.
        /// </summary>
        /// <returns>Результат перехода: если переход выполнен успешно (еще есть изображения) - true, иначе - false.</returns>
        private bool MoveToNextImage()
        {
            ++CurrentImageIndex;
            while (CurrentImageIndex < images.Count && images[CurrentImageIndex].Image == null)
                ++CurrentImageIndex;
            return CurrentImageIndex < images.Count;
        }

        /// <summary>
        /// Проверяет, нужен ли переход к следующей странице, учитывая текущие настройки печати.
        /// </summary>
        /// <returns>Если необходим переход на следующую страницу - true, иначе - false.</returns>
        private bool NeedNextPage()
        {
            bool result = false;

            if ((CurrentScale == WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x1 && CurrentImageOnPageIndex >= 0) ||
                (CurrentScale == WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x2 && CurrentImageOnPageIndex >= 1) ||
                (CurrentScale == WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x4 && CurrentImageOnPageIndex >= 3))
                result = true;

            if (CurrentImageIndex < images.Count)
            {
                if (CurrentPrintMode == WMSOffice.Dialogs.Sert.SertPrintSettings.PrintModes.DoubleSidedNewPageItem && images[CurrentImageIndex].ItemCode != CurrentItemCode)
                    result = true;

                if (CurrentPrintMode == WMSOffice.Dialogs.Sert.SertPrintSettings.PrintModes.DoubleSidedNewPageSerie &&
                    (images[CurrentImageIndex].ItemCode != CurrentItemCode || images[CurrentImageIndex].VendorLot != CurrentVendorLot))
                    result = true;
            }

            return result;
        }
        #endregion

        #region АЛГОРИТМЫ ПЕЧАТИ УЧИТЫВАЯ ЗАДАННОЕ МАСШТАБИРОВАНИЕ ДОКУМЕНТА
        /// <summary>
        /// Обрабатывает печать очередной страницы с изображениями сертификатов.
        /// </summary>
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.PageBounds);
            ++CurrentPageNumber;

            switch (CurrentScale)
            {
                #region Scale 1x1
                case WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x1:

                    DrawImageX1(e.Graphics, e.PageBounds, images[CurrentImageIndex]);

                    CurrentItemCode = images[CurrentImageIndex].ItemCode;
                    CurrentVendorLot = images[CurrentImageIndex].VendorLot;

                    if (MoveToNextImage())
                    {
                        if (!WMSOffice.Dialogs.Sert.SertPrintSettings.UseLimitOfPages ||
                            (WMSOffice.Dialogs.Sert.SertPrintSettings.UseLimitOfPages && CurrentPageNumber % WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPagesInBatchCount != 0))
                            e.HasMorePages = true;
                    }
                    break;
                #endregion

                #region Scale 1x2
                case WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x2:
                    for (CurrentImageOnPageIndex = 0; ; ++CurrentImageOnPageIndex)
                    {
                        DrawImageX2(e.Graphics, e.PageBounds, images[CurrentImageIndex], CurrentImageOnPageIndex);
                        CurrentItemCode = images[CurrentImageIndex].ItemCode;
                        CurrentVendorLot = images[CurrentImageIndex].VendorLot;
                        if (MoveToNextImage())
                        {
                            if (NeedNextPage())
                            {
                                if (!WMSOffice.Dialogs.Sert.SertPrintSettings.UseLimitOfPages ||
                                    (WMSOffice.Dialogs.Sert.SertPrintSettings.UseLimitOfPages && CurrentPageNumber % WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPagesInBatchCount != 0))
                                    e.HasMorePages = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                #endregion

                #region Scale 1x4
                case WMSOffice.Dialogs.Sert.SertPrintSettings.Scales.Scale1x4:
                    for (CurrentImageOnPageIndex = 0; ; ++CurrentImageOnPageIndex)
                    {
                        DrawImageX4(e.Graphics, e.PageBounds, images[CurrentImageIndex], CurrentImageOnPageIndex);
                        CurrentItemCode = images[CurrentImageIndex].ItemCode;
                        CurrentVendorLot = images[CurrentImageIndex].VendorLot;
                        if (MoveToNextImage())
                        {
                            if (NeedNextPage())
                            {
                                if (!WMSOffice.Dialogs.Sert.SertPrintSettings.UseLimitOfPages ||
                                    (WMSOffice.Dialogs.Sert.SertPrintSettings.UseLimitOfPages && CurrentPageNumber % WMSOffice.Dialogs.Sert.SertPrintSettings.CustomPagesInBatchCount != 0))
                                    e.HasMorePages = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                #endregion

                default:
                    break;
            }
        }


        /// <summary>
        /// Загружает и отрисовывает изображение сертификата в масштабе 1 картинка на странице.
        /// </summary>
        /// <param name="g">Ссылка на экземпляр класса Graphics.</param>
        /// <param name="bounds">Границы области печати.</param>
        /// <param name="ic">Ссылка на печатаемое изображение.</param>
        private void DrawImageX1(Graphics g, Rectangle bounds, WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer ic)
        {
            if (String.IsNullOrEmpty(ic.Header))
                g.DrawString(
                    string.Format(
                        "ImageID: {0}, Код товара: {1}, Серия: {2}\r\nНаим.: {3}, произв.: {4}",
                        ic.ImageID,
                        ic.ItemCode,
                        string.IsNullOrEmpty(ic.VendorLot) ? "-" : ic.VendorLot,
                        ic.ItemName,
                        ic.ManufacturerName),
                    CurrentHeaderFont,
                    Brushes.Black,
                    20,
                    15);
            else
                g.DrawString(ic.Header, CurrentHeaderFont, Brushes.Black, 20, 15);

            Image sertImage = null;
            if (ic.CertType == WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.BillOfExchange)
            {
                using (Data.SertTableAdapters.AccantumImagesTableAdapter adapter = new WMSOffice.Data.SertTableAdapters.AccantumImagesTableAdapter())
                    foreach (Data.Sert.AccantumImagesRow imageData in adapter.GetData(ic.ImageDataID))
                    {
                        using (MemoryStream ms = new MemoryStream(imageData.BinaryData))
                        {
                            Image rootImage = Image.FromStream(ms);
                            FrameDimension frameDimension = new FrameDimension(rootImage.FrameDimensionsList[0]);
                            int cntFrames = rootImage.GetFrameCount(frameDimension);
                            rootImage.SelectActiveFrame(frameDimension, ic.PageIndex);
                            sertImage = (Image)rootImage.Clone();
                        }
                        break;
                    }
            }
            else
            {
                sertImage = LoadReplacedImage(ic);
            }

            g.DrawImage(sertImage, new Rectangle(bounds.X + 20, bounds.Y + 60, bounds.Width - 40, bounds.Height - 130));
            sertImage.Dispose();

            string footer = string.Format(
                "Стр. {0} из {1} (заявка № {2})",
                CurrentPageNumber,
                CurrentTotalPagesCount,
                this.CurrentDocId);

            g.DrawString(
                footer,
                CurrentFooterFont,
                Brushes.Black,
                (bounds.Width - Convert.ToInt32(g.MeasureString(footer, CurrentFooterFont).Width)) / 2,
                bounds.Height - 70
                );
        }

        /// <summary>
        /// Отрисовывает изображение сертификата в масштабе 2 картинки на странице.
        /// </summary>
        /// <param name="g">Ссылка на экземпляр класса Graphics.</param>
        /// <param name="bounds">Границы области печати.</param>
        /// <param name="ic">Ссылка на печатаемое изображение.</param>
        /// <param name="placeIndex">Индекс расположения картинки: 0 - первая (слева), 1 - вторая (справа), причем, нижняя подпись (footer) выводится только для первой.</param>
        private void DrawImageX2(Graphics g, Rectangle bounds, WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer ic, int placeIndex)
        {
            if (placeIndex < 0 || placeIndex > 1)
                throw new ArgumentException("Некорректный индекс расположения картинки для масштаба 1х2.", "placeIndex");

            int xOffset = 60;
            if (placeIndex == 1)
                xOffset = (bounds.Width - 120) / 2;

            Image sertImage = LoadReplacedImage(ic);
            g.DrawImage(sertImage, new Rectangle(xOffset, bounds.Y + 60, (bounds.Width - 120) / 2, bounds.Height - 140));
            sertImage.Dispose();

            if (String.IsNullOrEmpty(ic.Header))
                g.DrawString(
                    string.Format(
                        "ImageID: {0}, Код товара: {1}, Серия: {2}\r\nНаименование: {3}\r\nПроизводитель: {4}",
                        ic.ImageID,
                        ic.ItemCode,
                        string.IsNullOrEmpty(ic.VendorLot) ? "-" : ic.VendorLot,
                        ic.ItemName,
                        ic.ManufacturerName),
                    CurrentHeaderFont,
                    Brushes.Black,
                    xOffset,
                    15);
            else
                g.DrawString(ic.Header, CurrentHeaderFont, Brushes.Black, xOffset, 15);

            string footer = string.Format(
                "Стр. {0} из {1} (заявка № {2})",
                CurrentPageNumber,
                CurrentTotalPagesCount,
                this.CurrentDocId);

            if (placeIndex == 0)
                g.DrawString(
                    footer,
                    CurrentFooterFont,
                    Brushes.Black,
                    (bounds.Width - Convert.ToInt32(g.MeasureString(footer, CurrentFooterFont).Width)) / 2,
                    bounds.Height - 70
                    );
        }

        /// <summary>
        /// Отрисовывает изображение сертификата в масштабе 4 картинки на странице.
        /// </summary>
        /// <param name="g">Ссылка на экземпляр класса Graphics.</param>
        /// <param name="bounds">Границы области печати.</param>
        /// <param name="ic">Ссылка на печатаемое изображение.</param>
        /// <param name="placeIndex">Индекс расположения картинки: 0 - первая (вверху слева), 1 - вторая (вверху справа), 2 - третья (внизу слева), 3 - четвертая (внизу справа), причем, нижняя подпись (footer) выводится только для первой.</param>
        private void DrawImageX4(Graphics g, Rectangle bounds, WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer ic, int placeIndex)
        {
            if (placeIndex < 0 || placeIndex > 3)
                throw new ArgumentException("Некорректный индекс расположения картинки для масштаба 1х4.", "placeIndex");

            int xOffset = 20;
            if (placeIndex == 1 || placeIndex == 3)
                xOffset = (bounds.Width - 40) / 2;
            int yOffset = 60;
            if (placeIndex == 2 || placeIndex == 3)
                yOffset = (bounds.Height - 160) / 2 + 100;

            Image sertImage = LoadReplacedImage(ic);
            g.DrawImage(sertImage, new Rectangle(xOffset, yOffset, (bounds.Width - 120) / 2, (bounds.Height - 160) / 2));
            sertImage.Dispose();

            if (String.IsNullOrEmpty(ic.Header))
                g.DrawString(
                    string.Format(
                        "ImageID: {0}, Код товара: {1}, Серия: {2}\r\nНаименование: {3}\r\nПроизводитель: {4}",
                        ic.ImageID,
                        ic.ItemCode,
                        string.IsNullOrEmpty(ic.VendorLot) ? "-" : ic.VendorLot,
                        ic.ItemName,
                        ic.ManufacturerName),
                    CurrentHeaderFont,
                    Brushes.Black,
                    xOffset,
                    yOffset - 40);
            else
                g.DrawString(ic.Header, CurrentHeaderFont, Brushes.Black, xOffset, yOffset - 40);

            string footer = string.Format(
                "Стр. {0} из {1} (заявка № {2})",
                CurrentPageNumber,
                CurrentTotalPagesCount,
                this.CurrentDocId);

            if (placeIndex == 0)
                g.DrawString(
                    footer,
                    CurrentFooterFont,
                    Brushes.Black,
                    (bounds.Width - Convert.ToInt32(g.MeasureString(footer, CurrentFooterFont).Width)) / 2,
                    bounds.Height - 60
                    );
        }
        #endregion

        /// <summary>
        /// Загружает изображение серитификата из базы данных для контейнера с подмененным изображением (в целях экономии объема выделяемой памяти).
        /// </summary>
        /// <param name="ic">Ссылка на контейнер с изображением.</param>
        /// <returns>Изображение сертификата в формате BMP.</returns>
        [Obsolete]
        private Image LoadReplacedImage(WMSOffice.Dialogs.Sert.SertPrintingThread.ImageContainer ic)
        {
            Image result = null;
            if (ic.Image == ImageBodyReplacer)
            {
                switch (ic.CertType)
                {
                    case WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.QualityCert:
                        using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
                            result = WMSOffice.Dialogs.Sert.SertImageUtils.UnpackImageByTCompress(adapter.GetImageByID(ic.ImageID));
                        break;

                    case WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.RegCert:
                        using (Data.SertTableAdapters.ItemRegCertImagesTableAdapter adapter = new Data.SertTableAdapters.ItemRegCertImagesTableAdapter())
                            result = WMSOffice.Dialogs.Sert.SertImageUtils.UnpackImageByTCompress(adapter.GetData((int)ic.ItemCode, ic.ImageID)[0].ImageBody);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                if (ic.CertType == WMSOffice.Dialogs.Sert.SertPrintingThread.CertType.BillOfExchange)
                {
                    result = ic.Image;
                }
            }
            return result;
        }
        #endregion


        public void StatementPrepare(WMSOffice.Data.Quality qualityDS, long statementID)
        {
            qualityDS.StatementReportHeader.Clear();

            using (Data.QualityTableAdapters.StatementReportHeaderTableAdapter qualityAdapter = new Data.QualityTableAdapters.StatementReportHeaderTableAdapter())
            {
                try
                {
                    qualityAdapter.Fill(qualityDS.StatementReportHeader, statementID);
                }
                catch { }
            }

            using (Data.QualityTableAdapters.StatementReportDetailTableAdapter qualityAdapter = new Data.QualityTableAdapters.StatementReportDetailTableAdapter())
            {
                try
                {
                    qualityAdapter.Fill(qualityDS.StatementReportDetail, statementID);
                }
                catch { }
            }
        }

        private void btnEditRegistrationLifetime_Click(object sender, EventArgs e)
        {
            var docDetailRow = this.SelectedLine as Data.Quality.DocDetailsRow;

            DateTime lifetimeDate = docDetailRow.IsRegEndDateNull() ? DateTime.Today : docDetailRow.RegEndDate;
            RegistrationLifetimeEditorForm form = new RegistrationLifetimeEditorForm() { LifetimeDate = lifetimeDate };

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    long docID = ((Data.Quality.DocsRow)SelectedDoc).Doc_ID;
                    Data.Quality.DocDetailsRow detail = ((Data.Quality.DocDetailsRow)SelectedLine);

                    using (Data.QualityTableAdapters.DocDetailsTableAdapter adapter = new DocDetailsTableAdapter())
                        adapter.UpdateSertLifetime(this.UserID, docID, detail.Line_ID, form.LifetimeDate);

                    this.RefreshLines();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Выборочная печать документов
        /// </summary>
        private void btnPrintSelectedDocs_Click(object sender, EventArgs e)
        {
            long docID = ((Data.Quality.DocsRow)SelectedDoc).Doc_ID;
            var dlgPrintItemsSelector = new PrintDocItemsSelector(docID) { UserID = this.UserID };
            if (dlgPrintItemsSelector.ShowDialog() == DialogResult.OK)
            {
                var parameter = new GeneralDocsCopiesCount() { SearchParameter = dlgPrintItemsSelector.SearchParameter };
                this.PrintDocPackages(parameter);
            }
        }

        /// <summary>
        /// Отображение всплывающей подсказки
        /// </summary>
        private void egvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var dgv = sender as DataGridView;

                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "StatusName")
                {
                    DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    var toolTip = (dgv.Rows[e.RowIndex].DataBoundItem as System.Data.DataRowView).Row["Printed_DSC"];
                    if (toolTip != null && toolTip != DBNull.Value)
                        cell.ToolTipText = toolTip.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// Сохранение размеров колонок при закрытии окна
        /// </summary>
        private void QualityRequestWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name, dgvLines);
            edgDocs.SaveExtraDataGridViewSettings(Name);
        }

        private void btnChoiceExpert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new ExpertCenterChoiceFrm { Owner = this };
                if (frm.ShowDialog() != DialogResult.OK || !frm.SelectedValue.HasValue)
                    return;

                var selectedValue = frm.SelectedValue;
                var adapter = new DocDetailsTableAdapter();
                adapter.SetExpert(SelectedDoc.Doc_ID, selectedValue);
                RefreshLines();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        string filterString = String.Empty;
        private void CheckExpired()
        {
            filterString = String.Empty;
            using (var adapter = new QK_GetDocs_WithoutConclusionTableAdapter())
            {
                var retData = adapter.GetData();
                int _count = 0;
                foreach (Quality.QK_GetDocs_WithoutConclusionRow row in retData.Rows)
                {
                    _count += row.CountRows;

                    filterString += String.IsNullOrEmpty(filterString) ? row.Doc_ID.ToString() : String.Format(", {0}", row.Doc_ID);
                }

                cbExpired.Text = String.Format("Протермінованих висновків: {0}", _count);

                if (!String.IsNullOrEmpty(filterString))
                {
                    filterString = String.Format("Doc_ID in ({0})", filterString);
                    if (cbExpired.Checked)
                        edgDocs.DataView.Data.DefaultView.RowFilter = filterString;
                }
            }
        }

        private void cbExpired_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExpired.Checked)
                edgDocs.DataView.Data.DefaultView.RowFilter = filterString;
            else
                edgDocs.DataView.Data.DefaultView.RowFilter = String.Empty;

            edgDocs.RecalculateSummary();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ExecuteCheckTasks();
        }

        private void ExecuteCheckTasks()
        {
            CheckExpired();
            CheckDocsWebSyncState();
        }

        private void CheckDocsWebSyncState()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.DocsWeb_SyncStateTableAdapter())
                    adapter.Fill(quality.DocsWeb_SyncState);

                if (quality.DocsWeb_SyncState.Count > 0)
                {
                    var stateRow = quality.DocsWeb_SyncState[0];
                    var totalConclusions = stateRow.IsConclsNull() ? 0 : stateRow.Concls;
                    var optimaConclusions = stateRow.IsOtpima_conclsNull() ? 0 : stateRow.Otpima_concls;
                    var lastDateConclusions = stateRow.IsLast_Concl_DTNull() ? DateTime.Today : stateRow.Last_Concl_DT;
                    var colorFlag = stateRow.IsColor_FlagNull() ? "red" : stateRow.Color_Flag.ToLower();

                    var sInfo = string.Format("\r\n✓ Разом: {0}\r\n✓ Оптіма: {1}\r\n\r\nДата і час: {2}", totalConclusions, optimaConclusions, lastDateConclusions.ToString("dd.MM.yyyy HH:mm"));

                    tip.ToolTipTitle = "Результат обробки висновків ДЛС";
                    tip.ToolTipIcon = ToolTipIcon.Info;
                    tip.IsBalloon = true;
                    tip.SetToolTip(pbDocsWebSyncState, sInfo);

                    var resourceName = string.Format("circle_{0}", colorFlag);
                    pbDocsWebSyncState.Image =(Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// Корректировка завода производителя
        /// </summary>
        private void btnEditManufacturer_Click(object sender, EventArgs e)
        {
            var manufacturerPlant = (this.SelectedLine as Data.Quality.DocDetailsRow).ManufacturerPlant;
            var form = new ManufacturerPlantEditorForm() { ManufacturerPlant = manufacturerPlant };

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    long docID = ((Data.Quality.DocsRow)SelectedDoc).Doc_ID;
                    Data.Quality.DocDetailsRow detail = ((Data.Quality.DocDetailsRow)SelectedLine);

                    using (Data.QualityTableAdapters.DocDetailsTableAdapter adapter = new DocDetailsTableAdapter())
                        adapter.UpdateManufacturerPlant(this.UserID, docID, detail.Line_ID, form.ManufacturerPlant);

                    this.RefreshLines();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

         /// <summary>
        /// Корректировка срока годности
        /// </summary>rfhn ,kfyi&
        private void btnEditExpDate_Click(object sender, EventArgs e)
        {
            var expDate = (this.SelectedLine as Data.Quality.DocDetailsRow).Exp_Date;
            var form = new ExpDateEditorForm() { ExpDate = expDate };

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    long docID = ((Data.Quality.DocsRow)SelectedDoc).Doc_ID;
                    Data.Quality.DocDetailsRow detail = ((Data.Quality.DocDetailsRow)SelectedLine);

                    using (Data.QualityTableAdapters.DocDetailsTableAdapter adapter = new DocDetailsTableAdapter())
                        adapter.UpdateExpDate(this.UserID, docID, detail.Line_ID, form.ExpDate.Date);

                    this.RefreshLines();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Корректировка GMP
        /// </summary>
        private void btnEditGMP_Click(object sender, EventArgs e)
        {
            long docID = ((Data.Quality.DocsRow)SelectedDoc).Doc_ID;
            Data.Quality.DocDetailsRow detail = ((Data.Quality.DocDetailsRow)SelectedLine);

            var itemID = (this.SelectedLine as Data.Quality.DocDetailsRow).Item_ID;
            var numberGMPSert = (this.SelectedLine as Data.Quality.DocDetailsRow).GMP_Sert;
            var form = new NumberGMPSertEditorForm(docID, detail.Line_ID, itemID, numberGMPSert);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Data.QualityTableAdapters.DocDetailsTableAdapter adapter = new DocDetailsTableAdapter())
                        adapter.UpdateGMPSertNumber(docID, detail.Line_ID, form.ID_GMPSert, this.UserID);

                    this.RefreshLines();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Корректировка страны завода производителя
        /// </summary>
        private void btnEditManufacturerCountry_Click(object sender, EventArgs e)
        {
            var manufacturerCountry = (this.SelectedLine as Data.Quality.DocDetailsRow).ManufacturerCountry;
            var form = new ManufacturerPlantCountryEditorForm() { ManufacturerCountry = manufacturerCountry };

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    long docID = ((Data.Quality.DocsRow)SelectedDoc).Doc_ID;
                    Data.Quality.DocDetailsRow detail = ((Data.Quality.DocDetailsRow)SelectedLine);

                    using (Data.QualityTableAdapters.DocDetailsTableAdapter adapter = new DocDetailsTableAdapter())
                        adapter.UpdateManufacturerCountry(this.UserID, docID, detail.Line_ID, form.ManufacturerCountry);

                    this.RefreshLines();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Передать заявку в инспекцию
        /// </summary>
        private void btnSendToInspection_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgScanDoc = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Label = "Отсканируйте реестр заявки, которую необходимо передать в инспекцию.",
                    Text = "Передача заявки в инспекцию",
                    Image = Properties.Resources.mail_ok,
                    ImageSizeMode = PictureBoxSizeMode.AutoSize
                };
                if (dlgScanDoc.ShowDialog() == DialogResult.OK)
                {
                    var docBarCode = dlgScanDoc.Barcode;

                    using (var adapter = new DocsTableAdapter())
                        adapter.SendDocToInspection(docBarCode, this.UserID);

                    RefreshDocs();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время передачи заявки в инспекцию: ", exc);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                edgDocs.ExportToExcel("Экспорт заявок ОК в Excel", "заявки ОК", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void sbMoveToNewDoc_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> lstLinesIDs = new List<int>();
                foreach (var line in this.SelectedLines)
                    if (line.Status_ID == Constants.QK_STATUS_DD_200)
                        lstLinesIDs.Add(line.Line_ID);

                if (lstLinesIDs.Count == 0)
                    throw new Exception(string.Format("Не обрано рядків(а) заяви на статусі {0}.", Constants.QK_STATUS_DD_200));

                if (MessageBox.Show(string.Format("Обрано {0} з {1} рядків(а)\nсеред виділених рядків заяви на статусі {2}.\n\nПродовжити створення заяви з обраними рядками?", lstLinesIDs.Count, this.SelectedLines.Count, Constants.QK_STATUS_DD_200), "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                lstLinesIDs.Sort();

                var sbLinesIDs = new StringBuilder();
                foreach (var lineID in lstLinesIDs)
                {
                    if (sbLinesIDs.Length > 0)
                        sbLinesIDs.AppendFormat(",{0}", lineID);
                    else
                        sbLinesIDs.AppendFormat("{0}", lineID);
                }

                var newDocID = (long?)null;
                using (var adapter = new Data.QualityTableAdapters.DocsTableAdapter())
                    adapter.CreateDocCopy(this.UserID, this.SelectedDoc.Doc_ID, sbLinesIDs.ToString(), ref newDocID);

                if (newDocID.HasValue)
                    this.RefreshDocs(newDocID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnMoveItemsToQuarantine_Click(object sender, EventArgs e)
        {
            this.MoveItemsToQuarantine();
        }

        private void MoveItemsToQuarantine()
        {
            try
            {
                var dlgQualityInpectionDetailsEdit = new QualityInpectionDetailsEditForm() { UserID = this.UserID };
                if (dlgQualityInpectionDetailsEdit.ShowDialog() != DialogResult.OK)
                    return;

                var inspectionID = dlgQualityInpectionDetailsEdit.InspectionID;
                var planReceiptDate = dlgQualityInpectionDetailsEdit.PlanReceiptDate;

                using (var adapter = new Data.QualityTableAdapters.DocsTableAdapter())
                    adapter.CreateMoveInRequest(this.UserID, this.SelectedDoc.Doc_ID, inspectionID, planReceiptDate);

                this.RefreshDocs(this.SelectedDoc.Doc_ID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnMoveItemsFromQuarantine_Click(object sender, EventArgs e)
        {
            this.MoveItemsFromQuarantine();
        }

        private void MoveItemsFromQuarantine()
        {
            try
            {
                MessageBoxManager.Yes = "&Підтвердити";
                MessageBoxManager.No = "&Скасувати";
                MessageBoxManager.Register();

                var msgResult = MessageBox.Show("Ви підтверджуєте створення запиту на\nпереміщення ЛЗ із зони карантину імпорту?", "Підтвердження дії", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                MessageBoxManager.Unregister();

                if (msgResult != DialogResult.Yes)
                    return;

                using (var adapter = new Data.QualityTableAdapters.DocsTableAdapter())
                    adapter.CreateMoveOutRequest(this.UserID, this.SelectedDoc.Doc_ID);

                this.RefreshDocs(this.SelectedDoc.Doc_ID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnShowAttachments_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    #region КЛАСС ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА ЗАЯВОК

    /// <summary>
    /// Представление для грида с заявками
    /// </summary>
    public class QualityRequestView : IDataView
    {
        /// <summary>
        /// Название свойства, которое должно выступать как идентификатор в таблице заявок
        /// </summary>
        public const string ID_PROPERTY_NAME = "Doc_ID";

        /// <summary>
        /// Название свойства, которое должно выступать как код статуса заявки
        /// </summary>
        public const string STATUS_ID_PROPERTY_NAME = "Status_ID";

        /// <summary>
        /// Название свойства, которое должно выступать как название статуса заявки
        /// </summary>
        public const string STATUS_NAME_PROPERTY_NAME = "StatusName";

        /// <summary>
        /// Название свойства, которое должно выступать как код статуса образца в заявке 
        /// </summary>
        public const string SAMPLE_STATUS_ID_PROPERTY_NAME = "SampleStatus_ID";

        /// <summary>
        /// Название свойства, которое должно выступать как название статуса образца в заявке 
        /// </summary>
        public const string SAMPLE_STATUS_NAME_PROPERTY_NAME = "SampleStatusName";

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
            var sc = pSearchParameters as QualityRequestSearchParameters;
            using (var adapter = new DocsTableAdapter())
            {
                adapter.SetTimeout(180);
                data = adapter.GetData(sc.DocID, sc.ItemID, sc.ItemNamePart, sc.VendorLot, sc.BatchID, sc.IncludeArchivedDocs, sc.DocCode, sc.PeriodFrom, sc.PeriodTo);
            }
        }

        /// <summary>
        /// Установка источника для грида с заявками
        /// </summary>
        /// <param name="pDataTable">Таблица с заявками</param>
        public void FillData(Data.Quality.DocsDataTable pDataTable)
        {
            data = pDataTable;
        }

        public QualityRequestView()
        {
            this.dataColumns.Add(new PatternColumn("№ заяви", ID_PROPERTY_NAME, new FilterCompareExpressionRule<Int64>(ID_PROPERTY_NAME), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дата заяви", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Затримка", "Has_Problems_Str", new FilterPatternExpressionRule("Has_Problems_Str")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Код постачальника", "Vendor_ID", new FilterCompareExpressionRule<Int64>("Vendor_ID")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Постачальник", "Vendor_Name", new FilterPatternExpressionRule("Vendor_Name")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("№ ВМД", "GTD_Num", new FilterPatternExpressionRule("GTD_Num")) { Width = 65 });
            this.dataColumns.Add(new PatternColumn("Дата ВМД", "GTD_Date", new FilterDateCompareExpressionRule("GTD_Date")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Рядків", "LinesCount", new FilterCompareExpressionRule<Int32>("LinesCount")) { Width = 60 });
            
            this.dataColumns.Add(new PatternColumn("Ст.", STATUS_ID_PROPERTY_NAME, new FilterCompareExpressionRule<Int32>(STATUS_ID_PROPERTY_NAME)) { Width = 35 });
            this.dataColumns.Add(new PatternColumn("Статус", STATUS_NAME_PROPERTY_NAME, new FilterPatternExpressionRule(STATUS_NAME_PROPERTY_NAME)) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Ст. зр.", SAMPLE_STATUS_ID_PROPERTY_NAME, new FilterCompareExpressionRule<Int32>(SAMPLE_STATUS_ID_PROPERTY_NAME)) { Width = 35 });
            this.dataColumns.Add(new PatternColumn("Статус зразка", SAMPLE_STATUS_NAME_PROPERTY_NAME, new FilterPatternExpressionRule(SAMPLE_STATUS_NAME_PROPERTY_NAME)) { Width = 200 });
            
            this.dataColumns.Add(new PatternColumn("На статусі з", "StatusDate", new FilterDateCompareExpressionRule("StatusDate")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Відп. пров. по работі з ДЛС", "LastUsers", new FilterPatternExpressionRule("LastUsers")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Відп. пров. по вхідному контролю", "User120", new FilterPatternExpressionRule("User120")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Кіл-ть", "Amount", new FilterCompareExpressionRule<Int32>("Amount")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Сума, грн", "Suma", new FilterCompareExpressionRule<Int32>("Suma")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Відповідальний МВЗ", "ResponsibleUser", new FilterPatternExpressionRule("ResponsibleUser")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("№ складального листа", "PickSlip", new FilterCompareExpressionRule<Int64>("PickSlip")) { Width = 85 });
            this.dataColumns.Add(new PatternColumn("Статус складального листа", "OrderStatus", new FilterCompareExpressionRule<Int32>("OrderStatus")) { Width = 85 });

            this.dataColumns.Add(new PatternColumn("№ батьків. заяви", "Related_Doc_ID", new FilterCompareExpressionRule<Int64>("Related_Doc_ID"), SummaryCalculationType.Count) { Width = 100 });
        }
    }

    public class DocCode
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    #endregion
}
