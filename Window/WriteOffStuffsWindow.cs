using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Xml;

using WMSOffice.Classes;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Dialogs.Quality;
using WMSOffice.Dialogs.WH;
using WMSOffice.Reports;
using WMSOffice.Window.WriteOff;
using WMSOffice.Data.WFTableAdapters;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using WMSOffice.Data.AccessTableAdapters;
using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно для работы с макетами списания
    /// </summary>
    public partial class WriteOffStuffsWindow : GeneralWindow
    {
        const string STR_OutFilePath = @"\\dl2\fs";

        /// <summary>
        /// Столбец с информацией о наличии вложенных файлов
        /// </summary>
        private DataGridViewImageColumn dgvcHasAttachedFiles = null;

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        private CheckBox cbOnlyActive = null;

        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Название таблицы с макетами списания в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocsTableName { get { return String.Format("{0}_Header", Name); } }

        /// <summary>
        /// Название таблицы с товарами в макете списания в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocDetailsTableName { get { return String.Format("{0}_Details", Name); } }

        /// <summary>
        /// Коллекция макетов списания, выделенных в таблице, либо коллекция пуста если ничего не выделено
        /// </summary>
        private IEnumerable<WH.WF_GetDocsRow> SelectedDocs
        {
            get
            {
                return
                    dgvDocs.SelectedItems.ConvertAll(new Converter<DataRow, WH.WF_GetDocsRow>(x => x as WH.WF_GetDocsRow));
            }
        }

        /// <summary>
        /// Коллекция идентификаторов макетов списания, выделенных в таблице (коллекция пуста если ничего не выделено)
        /// </summary>
        private List<long> SelectedDocIds
        {
            get
            {
                var ids = new List<long>();
                foreach (var doc in SelectedDocs)
                    ids.Add(doc.Doc_ID);
                return ids;
            }
        }

        /// <summary>
        /// Выбранный макет списания в таблице либо null, если таблица пустая или в ней ничего не выбрано.
        /// Если в таблице выделено несколько макетов, то возвращается первый из них
        /// </summary>
        private WH.WF_GetDocsRow SelectedDoc { get { return dgvDocs.SelectedItem as WH.WF_GetDocsRow; } }

        /// <summary>
        /// True, если в таблице выделен хотя бы один макет и если несколько, то все они имеют одинаковый статус
        /// False, если таблица пуста либо в таблице не выделено ни одного макета, либо выделено несколько макетов с разными статусами
        /// </summary>
        private bool IsDocSelected
        {
            get
            {
                if (dgvDocs.SelectedItem == null)
                    return false;
                int status = SelectedDoc.Status_ID;
                foreach (var doc in SelectedDocs)
                    if (doc.Status_ID != status)
                        return false;
                return true;
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public WriteOffStuffsWindow()
        {
            InitializeComponent();

            InitializeFilters();
            InitializeWriteOffStuffsGrid();
            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);
            Config.LoadDataGridViewSettings(ConfigDocDetailsTableName, dgvDetails);
        }

        private void InitializeFilters()
        {
            cbOnlyActive = new CheckBox() { Text = "Только актуальные", ForeColor = Color.Blue, CheckAlign = ContentAlignment.MiddleRight, Checked = true };
            cbOnlyActive.CheckedChanged += (s, e) => { RefreshDataViewBinding(); };
            tsFilter.Items.Add(new ToolStripControlHost(cbOnlyActive)); // { Width = 210 });
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с макетами списания при создании окна
        /// </summary>
        private void InitializeWriteOffStuffsGrid()
        {
            dgvDocs.Init(new WriteOffStuffsView(), true);
            dgvDocs.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvDocs.UserID = UserID;
            dgvDocs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDocs.AllowRangeColumns = true;
            dgvDocs.UseMultiSelectMode = true;

            #region ИНИЦИАЛИЗАЦИЯ СТОЛБЦОВ-ИНДИКАТОРОВ

            foreach (DataGridViewColumn column in dgvDocs.DataGrid.Columns)
            {
                if ((column.Tag ?? string.Empty).Equals("HasAttachedFiles"))
                    dgvcHasAttachedFiles = column as DataGridViewImageColumn;
            }

            if (dgvcHasAttachedFiles == null)
            {
                this.ShowError("Отсутствует столбец с информацией о наличии вложенных файлов.");
                return;
            }

            #endregion

            dgvDocs.OnFilterChanged += dgvDocs_OnFilterChanged;
            dgvDocs.OnRowSelectionChanged += dgvDocs_OnRowSelectionChanged;
            dgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(dgvDocs_OnFormattingCell);
            dgvDocs.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvDocs_OnDataBindingComplete);

            // активация постраничного просмотра
            dgvDocs.CreatePageNavigator();

            // инициализация доступных операций
            CustomMainButtons();
            CustomButtons();
        }

        #region ПРАВА ДОСТУПА НА КНОПКИ

        /// <summary>
        /// Признак, показывающий, может ли пользователь выполнять отгрузку на поставщика
        /// </summary>
        private bool canShipToVendor;

        /// <summary>
        /// Признак, показывающий, может ли пользователь создавать макеты списания
        /// </summary>
        private bool canCreateWFDoc;

        /// <summary>
        /// Признак, показывающий, может ли пользователь выполнять экспорт заявок на уничтожение
        /// </summary>
        private bool canPrintDestructionRequests;

        /// <summary>
        /// Признак, показывающий, может ли пользователь создавать счета
        /// </summary>
        private bool canCreateInvoice;

        /// <summary>
        /// Признак, показывающий, может ли пользователь печатать документы списания
        /// </summary>
        private bool canPrintWFDocs;

        /// <summary>
        /// Признак, показывающий, может ли пользователь печатать сборочный лист
        /// </summary>
        private bool canPrintSL;

        /// <summary>
        /// Признак, показывающий, может ли пользователь выполнять экспорт конс. расчета поставщика
        /// </summary>
        private bool canExportVendorCalc;

        /// <summary>
        /// Признак, показывающий, может ли пользователь выполнять корректировку макетов списания
        /// </summary>
        private bool canEditWFDoc;

        /// <summary>
        /// Загрузка прав пользователей
        /// </summary>
        private void LoadUserAccesses()
        {
            try
            {
                using (var adapter = new WF_AccessTableAdapter())
                {
                    var table = adapter.GetData(UserID);
                    canShipToVendor = GetAccess(table, "ShipToVendor");
                    canCreateWFDoc = GetAccess(table, "CanCreateWFDoc");
                    canPrintDestructionRequests = GetAccess(table, "CanPrintDestructionRequests");
                    canCreateInvoice = GetAccess(table, "CanCreateInvoice");
                    canPrintWFDocs = GetAccess(table, "CanPrintWFDocs");
                    canPrintSL = GetAccess(table, "CanPrintSL");
                    canExportVendorCalc = GetAccess(table, "CanExportVendorCalc");
                    canEditWFDoc = GetAccess(table, "CanEditWFDoc");
                }
            }
            catch (Exception exc)
            {
                ShowError("Не удалось загрузить роли пользователя для макетов списания: " + Environment.NewLine + exc.Message);
            }
        }

        /// <summary>
        /// Получение значение права доступа по его ключу
        /// </summary>
        /// <param name="pAccesses">Таблица с правами доступа</param>
        /// <param name="pKey">Ключ, которых характеризирует получаемое право доступа</param>
        /// <returns>True, если пользователь имеет право доступа, False если не имеет</returns>
        private static bool GetAccess(WH.WF_AccessDataTable pAccesses, string pKey)
        {
            foreach (WH.WF_AccessRow row in pAccesses)
                if (row.Entity_Key == pKey)
                    return row.Entity_Value;

            return false;
        }
        #endregion

        /// <summary>
        /// Форматирование данных в табличном представлении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            #region ОТОБРАЖЕНИЕ 4 ЗНАКА ПОСЛЕ ЗАПЯТОЙ ДЛЯ ИТОГОВОЙ СУММЫ / ИТОГОВОЙ СУММЫ В БАЗОВЫХ

            if (dgvDocs.DataGrid.Columns[e.ColumnIndex].DataPropertyName == wH.WF_GetDocs.Amount_UAHColumn.Caption ||
                dgvDocs.DataGrid.Columns[e.ColumnIndex].DataPropertyName == wH.WF_GetDocs.BaseAmountColumn.Caption)
            {
                e.CellStyle.Format = "N4";
            }

            #endregion
        }

        void dgvDocs_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDocs.DataGrid.Rows)
            {
                var boundRow = (dgvDocs.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.WH.WF_GetDocsRow;

                var hasAttachedFiles = false;
                object attachedFilesValue = emptyIcon;
                switch (boundRow.AttachedFiles)
                {
                    case 0:
                        attachedFilesValue = Properties.Resources.close;
                        hasAttachedFiles = true;
                        break;
                    case 1:
                        attachedFilesValue = Properties.Resources.paperclip1;
                        hasAttachedFiles = true;
                        break;
                    case 2:
                        attachedFilesValue = Properties.Resources.paperclip2;
                        hasAttachedFiles = true;
                        break;
                    case 3:
                        attachedFilesValue = Properties.Resources.paperclip3;
                        hasAttachedFiles = true;
                        break;
                    default:
                        attachedFilesValue = Properties.Resources.paperclipN;
                        hasAttachedFiles = true;
                        break;
                }

                if (hasAttachedFiles)
                    dgvDocs.DataGrid.Rows[row.Index].Cells[dgvcHasAttachedFiles.Index].Value = attachedFilesValue;
            }
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void dgvDocs_OnFilterChanged(object pSender, EventArgs pE)
        {
            btnExportConsCalc.Visible = canExportVendorCalc && dgvDocs.SelectedItems.Count > 0;
            dgvDocs.RecalculateSummary();
        }

        /// <summary>
        /// Обновление доступности кнопок при изменении выбранного макета списания
        /// </summary>
        private void dgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            CustomMainButtons();

            RefreshDetails();
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности главных кнопок на панели управления в зависимости от выбранного макета
        /// </summary>
        private void CustomMainButtons()
        {
            var fullAccess = SelectedDoc != null && SelectedDoc.FullAccess;

            cmiSimpleAct.Enabled = cmiExportDocs.Enabled = false;
            btnShowAttachments.Visible = btnCalc.Visible = btnExportConsCalc.Visible = btnAccept.Visible = btnCalcExport.Visible = btnAddDoc.Visible = btnPrintDocs.Visible = cmbPrinters.Visible = tssAfterPrint.Visible = btnDestructionRequest.Visible = btnInvoice.Visible = btnArchive.Visible = false;

            if (SelectedDoc != null)
            {
                btnShowAttachments.Visible = !SelectedDoc.IsAttachedFilesNull() && SelectedDoc.AttachedFiles > 0;

                cmiSimpleAct.Text = SelectedDoc.IsIS_Separate_ActNull() || SelectedDoc.IS_Separate_Act == 0 ? "Формирования акта отдельным документом" : "Снять формирования акта отдельным документом";
                cmiSimpleAct.Enabled = fullAccess && canEditWFDoc && SelectedDoc.Status_ID != 8;
                cmiExportDocs.Enabled = dgvDocs.HasRows;

                btnCalc.Visible = fullAccess && canShipToVendor && (SelectedDoc.Doc_TypeID.ToUpper() == "SM" || SelectedDoc.Doc_TypeID.ToUpper() == "SP") && (SelectedDoc.Status_ID == 110 || SelectedDoc.Status_ID == 115 || SelectedDoc.Status_ID == 120 || SelectedDoc.Status_ID == 122 || SelectedDoc.Status_ID == 125 || SelectedDoc.Status_ID == 126);

                btnExportConsCalc.Visible = fullAccess && canExportVendorCalc && dgvDocs.SelectedItems.Count > 0;

                btnAccept.Visible =
                    fullAccess && canEditWFDoc &&
                    (
                        // Логвина 
                        ((SelectedDoc.Doc_TypeID.ToUpper() == "SM" || SelectedDoc.Doc_TypeID.ToUpper() == "SP") && (SelectedDoc.Status_ID == 110 || SelectedDoc.Status_ID == 115 || SelectedDoc.Status_ID == 120 || SelectedDoc.Status_ID == 122)) || 
                        
                        // Астапеева/Лазоренко
                        (/*SelectedDoc.Status_ID == 128 &&*/ SelectedDoc.Accept128)
                    );

                btnCalcExport.Visible = fullAccess && canExportVendorCalc && AllowCalcExport && SelectedDoc != null && SelectedDoc.Doc_TypeID.ToUpper() == "SM" && SelectedDoc.Status_ID >= 110;

                btnAddDoc.Visible = fullAccess && canCreateWFDoc;
                btnPrintDocs.Visible = fullAccess && canPrintWFDocs;
                btnInvoice.Visible = fullAccess && canCreateInvoice;
                btnDestructionRequest.Visible = fullAccess && canPrintDestructionRequests;

                cmbPrinters.Visible = tssAfterPrint.Visible = fullAccess && canPrintSL;
                btnArchive.Visible = fullAccess;
            }
        }

        /// <summary>
        /// Настройка доступности кнопок на панели управления в зависимости от выбранного макета
        /// </summary>
        private void CustomButtons()
        {
            var fullAccess = SelectedDoc != null && SelectedDoc.FullAccess;

            btnSave.Visible = fullAccess && canEditWFDoc && IsDocSelected && (SelectedDoc.Status_ID == 100 || SelectedDoc.Status_ID == 9) && dgvDetails.Rows.Count > 0; // запрещаем переводить дальше пустые документы
            tssAfterSave.Visible = btnSave.Visible;
            btnEditDoc.Visible = fullAccess && canEditWFDoc && SelectedDocIds.Count == 1 && (SelectedDoc.Status_ID == 100 || SelectedDoc.Status_ID == 110 || SelectedDoc.Status_ID == 120 || SelectedDoc.Status_ID == 9);
            btnDelete.Visible = fullAccess && canEditWFDoc && IsDocSelected && SelectedDoc.Status_ID == 100;
            btnHoldDoc.Visible = fullAccess && canEditWFDoc && false;
            btnPrintPackList.Visible = fullAccess && canPrintSL && IsDocSelected && SelectedDoc.Status_ID >= 3;
            miCreateRequestDestruction.Enabled = fullAccess && canPrintDestructionRequests && IsDocSelected;
            tssAfterHold.Visible = btnHoldDoc.Visible;
            btnCalcExport.Visible = fullAccess && canExportVendorCalc && AllowCalcExport && SelectedDoc != null && SelectedDoc.Status_ID >= 110;
            
            SetDocSplitAccesss();
        }

        /// <summary>
        /// Обновление данных в таблице деталей документа списания
        /// </summary>
        private void RefreshDetails()
        {
            try
            {
                if (SelectedDoc == null)
                    wH.WF_GetDocs_Detail.Clear();
                else
                    taWfGetDocs_Detail.Fill(wH.WF_GetDocs_Detail, UserID, SelectedDoc.Doc_ID);

            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время загрузки товаров в макете списания:", exc);
            }
        }

        /// <summary>
        /// Загрузка макетов списания при загрузке окна
        /// </summary>
        private void WriteOffStuffsWindow_Load(object sender, EventArgs e)
        {
            this.wF_StatusesTableAdapter.Fill(this.wF.WF_Statuses);
            this.LoadUserAccesses();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e); 
            this.RefreshDocs();
        }

        private void RefreshDocs()
        {
            RefreshDocs(SelectedDocIds);
        }

        /// <summary>
        /// Обновление данных в таблице макетов списания с сохранением выделения и прокрутки
        /// </summary>
        private void RefreshDocs(List<long> selectedDocIds)
        {
            _allowCalcExport = null;

            dgvDocs.SaveExtraDataGridViewSettings(ConfigDocsTableName);

            RefreshDataViewBinding();

            dgvDocs.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvDocs.UnselectAllRows();

            var isSelected = false;
            foreach (var id in selectedDocIds)
            {
                dgvDocs.SelectRow("Doc_ID", id.ToString());
                isSelected = true;
            }

            if (!isSelected)
                dgvDocs.SelectRow(0);

            dgvDocs.ScrollToSelectedRow();
            CustomButtons();
        }

        /// <summary>
        /// Загрузка макетов списания в фильтруемый грид из БД
        /// </summary>
        private void RefreshDataViewBinding()
        {
            try
            {
                var loadWorker = new BackgroundWorker();

                var sp = new WriteOffStuffsViewSearchParameters();
                sp.SessionID = this.UserID;
                sp.OnlyActive = cbOnlyActive.Checked;

                loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        this.dgvDocs.DataView.FillData(e.Argument as WriteOffStuffsViewSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };

                loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.dgvDocs.BindData(false);
                        this.dgvDocs.AllowSummary = true;
                    }

                    waitProgressForm.CloseForce();
                };

                waitProgressForm.ActionText = "Выполняется загрузка данных..";
                loadWorker.RunWorkerAsync(sp);
                waitProgressForm.ShowDialog();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список макетов списания: ", exc);
            }
        }

        /// <summary>
        /// Обновление списка макетов списания при нажатии на кнопку "Обновить"
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                RefreshDocs();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region СОХРАНЕНИЕ НАСТРОЕК ПРИ ВЫХОДЕ ИЗ ОКНА

        /// <summary>
        /// Сохранение настроек грида при закрытии окна
        /// </summary>
        private void WriteOffStuffsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDocs.SaveExtraDataGridViewSettings(ConfigDocsTableName);
            Config.SaveDataGridViewSettings(ConfigDocDetailsTableName, dgvDetails);
        }

        #endregion

        #region ОПЕРАЦИИ С МАКЕТАМИ СПИСАНИЯ

        /// <summary>
        /// Отправка шаблона в обработку по нажатию на соответствующую кнопку
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Отправить все выделенные документы в обработку?", "Отправка в обработку",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                using (var adapter = new WF_GetDocsTableAdapter())
                    foreach (var id in SelectedDocIds)
                        adapter.SaveTemplate(UserID, id);

                RefreshDocs();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при отправке шаблонов в обработку", exc);
            }
        }

        /// <summary>
        /// Добавление/редактирование макета списания
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editMode = sender == btnEditDoc;

            var dialog = editMode
                ? new CreateWriteOffStuffForm(UserID, SelectedDoc)
                : new CreateWriteOffStuffForm(UserID);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (editMode && SelectedDoc.Status_ID == 110)
                {
                    using (var adapter = new CompensationDetailsTableAdapter())
                        adapter.CompensationCalc((int?)SelectedDoc.Doc_ID, null);
                }

                RefreshDocs(new List<long> { dialog.DocID });
            }
        }

        /// <summary>
        /// Провести макет списания
        /// </summary>
        private void btnHoldDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы точно хотите провести документ в JD?", "Списание", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                var form = new SetDateForm { DateTypeString = "Дата документа: ", Width = 250 };
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    taWfGetDocs.GetDocToJD(SelectedDoc.Doc_ID, SelectedDoc.JDE_Doc_Type, form.SelectedDate);
                    RefreshDocs();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время проводки макета списания", exc);
            }
        }

        /// <summary>
        /// Удаление макета списания
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить выбранные макеты?", "Удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                foreach (var doc in SelectedDocs)
                    taWfGetDocs.DeleteDoc(UserID, doc.Doc_ID);
                RefreshDocs();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время удаления макета списания!", exc);
            }
        }

        #endregion

        #region ОКНО ПЕЧАТИ ДОКУМЕНТОВ СПИСАНИЯ

        /// <summary>
        /// Запуск окна печати документов по нажатию на соответствующую кнопку
        /// </summary>
        private void btnPrintDocs_Click(object sender, EventArgs e)
        {
            var form = new PrintWriteOffActsForm(UserID);
            form.ShowDialog();
        }

        #endregion

        #region ПЕЧАТЬ СБОРОЧНЫХ ДЛЯ ДОКУМЕНТОВ

        /// <summary>
        /// Запуск печати сборочных для документов списания
        /// </summary>
        private void btnPrintPackList_Click(object sender, EventArgs e)
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;

            var parameters = new PrinterWorkerParameters() { PrinterName = (string)cmbPrinters.SelectedItem };
            parameters.DocsToPrint.AddRange(SelectedDocs);
            printWorker.RunWorkerAsync(parameters);
        }

        /// <summary>
        /// Печатает в фоне сборочные листы по документам списания
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = (PrinterWorkerParameters)e.Argument;
                foreach (var doc in param.DocsToPrint)
                {
                    FillPackingListReport((int)doc.Doc_ID);
                    using (var report = new WriteOffActPackingListReport())
                    {
                        report.PrintOptions.PrinterName = param.PrinterName;
                        report.SetDataSource(wH);
                        report.PrintToPrinter(1, true, 1, 0);

                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(UserID, "WF", 2, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(wH.WF_GetPSN_Detail.Count), param.PrinterName, 1);
                    }
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Обработка окончания печати сборочных листов в фоне
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError((e.Result as Exception).Message);
        }

        /// <summary>
        /// Заполнение данных для отображения печатной формы сборочного листа по документу списания
        /// </summary>
        /// <param name="pDocID">Идентификатор документа списания</param>
        private void FillPackingListReport(int pDocID)
        {
            wH.WF_GetPSN_Header.Clear();
            wH.WF_GetPSN_Detail.Clear();

            using (var adapter = new WF_GetPSN_HeaderTableAdapter())
                adapter.Fill(wH.WF_GetPSN_Header, UserID, pDocID);

            if (wH.WF_GetPSN_Header.Count == 0)
                throw new Exception("Не удалось загрузить заголовок сборочного!");
            wH.WF_GetPSN_Header[0].Bar_Code_IMG =
                BarCodeGenerator.GetBarcodeCODE39(wH.WF_GetPSN_Header[0].Bar_Code.Trim());

            using (var adapter = new WF_GetPSN_DetailTableAdapter())
                adapter.Fill(wH.WF_GetPSN_Detail, UserID, pDocID);
        }

        #endregion

        #region КЛАСС ПАРАМЕТРОВ ПЕЧАТИ

        /// <summary>
        /// Класс, содержащий параметры для печати сборочных
        /// </summary>
        private class PrinterWorkerParameters
        {

            /// <summary>
            /// Список документов списания, сборочные для которых нужно напечатать
            /// </summary>
            public List<WH.WF_GetDocsRow> DocsToPrint = new List<WH.WF_GetDocsRow>();

            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }
        }

        #endregion

        #region ФОРМИРОВАНИЕ ЗАЯВКИ НА УНИЧТОЖЕНИЕ

        /// <summary>
        /// Запуск окна экспорта заявок в PDF
        /// </summary>
        private void btnDestructionRequest_Click(object sender, EventArgs e)
        {
            var window = new WhExportDestructionRequestsForm(UserID);
            window.ShowDialog(this);
        }

        #endregion

        #region СОЗДАНИЕ НОВОГО МАКЕТА ИЗ НЕСКОЛЬКИХ СТРОК

        /// <summary>
        /// Настройка доступности кнопок, связанных со строками макета, в зависимости от выбранных строк в таблице
        /// </summary>
        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            SetDocSplitAccesss();
            tssAfterPrint.Visible = btnPrintPackList.Visible; // || btnSplit.Visible;
        }

        private void SetDocSplitAccesss()
        {
            var fullAccess = SelectedDoc != null && SelectedDoc.FullAccess;

            btnSplit.Visible = btnSplit.Enabled = miSplit.Enabled = fullAccess && canEditWFDoc && SelectedDocIds.Count == 1 && dgvDetails.SelectedRows.Count > 0
                   && (SelectedDoc.Status_ID == 100 || SelectedDoc.Status_ID == 110 || SelectedDoc.Status_ID == 115
                   || SelectedDoc.Status_ID == 120 || SelectedDoc.Status_ID == 122);
        }

        /// <summary>
        /// Создание нового макета из выделенных строк
        /// </summary>
        private void Split_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы точно хотите создать новый макет из выделенных строк?", "Подтверждение действия",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    taWfGetDocs.CopyDoc(UserID, SelectedDoc.Doc_ID, CreateXml());
                RefreshDocs();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время создания нового макета из выделенных строк: ", exc);
                RefreshDocs();
            }
        }

        /// <summary>
        /// Формирование XML-структуры код товара/код строки из выделенных строк макета
        /// </summary>
        /// <returns>XML-структура код товара/код строки из выделенных строк макета</returns>
        private string CreateXml()
        {
            var doc = new XmlDocument();
            var root = (XmlElement)doc.AppendChild(doc.CreateElement("Root"));
            foreach (DataGridViewRow dgvrow in dgvDetails.SelectedRows)
            {
                var xmlrow = (XmlElement)root.AppendChild(doc.CreateElement("Row"));
                var dbrow = (dgvrow.DataBoundItem as DataRowView).Row as WH.WF_GetDocs_DetailRow;
                xmlrow.SetAttribute("doc_id", SelectedDoc.Doc_ID.ToString());
                xmlrow.SetAttribute("line_id", dbrow.Line_ID.ToString());
            }

            return root.InnerXml;
        }

        #endregion

        #region ЭКСПОРТ ЗАЯВКИ НА УНИЧТОЖЕНИЕ ПО МАКЕТУ

        private bool? _allowCalcExport;
        /// <summary>
        /// Проверка возможности експорта расчета
        /// </summary>
        private bool AllowCalcExport
        {
            get
            {
                if (!_allowCalcExport.HasValue)
                {
                    using (var adapter = new LimitedEntityElementsTableAdapter())
                    {
                        var dt = adapter.WFAllowCalcExport(UserID);
                        foreach (WMSOffice.Data.Access.LimitedEntityElementsRow item in dt.Rows)
                            if (item.Entity_Key == "AllowExport")
                            {
                                _allowCalcExport = true;
                                break;
                            }
                    }
                }

                return _allowCalcExport ?? false;
            }

        }

        /// <summary>
        /// Экспортирование заявки на уничтожение для выбранного в таблице макета списания
        /// </summary>
        private void miCreateRequestDestruction_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = GetRequestFileName();
                if (String.IsNullOrEmpty(fileName))
                    return;

                using (var adapter = new WF_GetDestructionInformationTableAdapter())
                {
                    adapter.SetTimeout(600);
                    adapter.FillByDoc(wH.WF_GetDestructionInformation, SelectedDoc.Doc_ID);
                    string[] headers = new string[] { "Код товара", "Наименование товара", "Основное вещество", "номер гос. рег.",
                            "ед.\nизм.", "кол-во на\nскладе", "Серия", "Срок\nгодности", "Причина уничтожения", "Производитель", 
                            "Страна\nпроисхождения", "Вес на\nскладе, кг", "Фармгруппа", "Название фармгруппы", "кол-во в\nящике",
                            "Дата последнего\nпоступления", "№ макета\nсписания", "№ акта ОМУ" };
                    string[] columnNames = new string[] { "Item_ID", "Item_Name", "Basic_Substance", "Registration_Number",
                            "UOM", "Quantity", "Vendor_Lot", "Expiration_Date", "Cause_Destruction", "Manufacturer", 
                            "Origin_Country", "Weight", "Farm_Group", "Farm_Group_Name", "Qty_In_Box",
                            "Last_Receipt_Date", "Act_ID", "OMU_Act_ID" };
                    AddTotalWeightValue(wH.WF_GetDestructionInformation);
                    string message = ExportHelper.ExportDataTableToExcelFile(fileName, wH.WF_GetDestructionInformation, headers, columnNames);
                    if (!String.IsNullOrEmpty(message))
                        throw new ApplicationException(message);
                }

                MessageBox.Show("Заявка на уничтожение была успешно экспортирована!", "Экспорт заявок",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Произошла ошибка во время экспорта заявки на уничтожение: ", exc);
            }
        }

        /// <summary>
        /// Отображение пользователю окна "Сохранение файла" для выбора наименования файла с экспортированными данными
        /// </summary>
        /// <returns>Полное название файла, в который нужно экспортировать заявку на уничтожение</returns>
        private static string GetRequestFileName()
        {
            var dlg = new SaveFileDialog()
            {
                Title = "Экспорт заявки на уничтожение в Excel",
                AddExtension = true,
                DefaultExt = "csv",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Текстовый файл с разделителями (*.csv)|*.csv",
                FilterIndex = 0
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                return dlg.FileName;
            else
                return String.Empty;
        }

        /// <summary>
        /// Добавляет строку с общим весом к данным по заявке на уничтожение
        /// </summary>
        /// <param name="pTable">Таблица с данными по заявке на уничтожение, куда нужно добавить строку с общим весом</param>
        private static void AddTotalWeightValue(Data.WH.WF_GetDestructionInformationDataTable pTable)
        {
            double totalWeight = 0;
            foreach (Data.WH.WF_GetDestructionInformationRow row in pTable)
                totalWeight += row.Weight;
            var newRow = pTable.NewWF_GetDestructionInformationRow();
            newRow.Origin_Country = "Общий вес, кг:";
            newRow.Weight = totalWeight;
            //newRow.SetAct_IDNull();
            pTable.AddWF_GetDestructionInformationRow(newRow);
        }

        #endregion

        private void cmiSimpleAct_Click(object sender, EventArgs e)
        {
            if (SelectedDoc == null)
                return;
            using (var taWfGetDocsDetail = new WMSOffice.Data.WHTableAdapters.WF_GetDocs_DetailTableAdapter())
            {
                var sd = SelectedDoc;
                sd.IS_Separate_Act = (sd.IsIS_Separate_ActNull() || sd.IS_Separate_Act == 0 ? 1 : 0);
                taWfGetDocsDetail.CreateDocs(UserID, sd.Warehouse_ID, sd.Doc_TypeID, sd.JDE_Doc_Type, sd.Desc, sd.Approver_ID, sd.Doc_ID, sd.IsInventory_IDNull() ? (int?)null : sd.Inventory_ID, null, sd.DocDate, sd.IS_Separate_Act, sd.IsIS_Foreign_CurrencyNull() ? 0 :sd.IS_Foreign_Currency, (bool?)null, (int?)null, sd.IsIsNotBalanceNull() ? false : sd.IsNotBalance, sd.IsAct_CommentNull() ? (string)null : sd.Act_Comment);
                cmiSimpleAct.Text = SelectedDoc.IsIS_Separate_ActNull() || SelectedDoc.IS_Separate_Act == 0 ? "Формирования акта отдельным документом" : "Снять формирования акта отдельным документом";
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            var wnd = new CardCalculationWindow(UserID, SelectedDoc);
            wnd.ShowDialog();
        }

        private void btnExportConsCalc_Click(object sender, EventArgs e)
        {
            try
            {
                var sbConsDocs = new StringBuilder();

                foreach (var doc in this.SelectedDocs)
                {
                    if ((doc.Doc_TypeID.ToUpper() == "SM" || SelectedDoc.Doc_TypeID.ToUpper() == "SP") && (doc.Status_ID == 110 || doc.Status_ID == 115 || doc.Status_ID == 120 || doc.Status_ID == 122 || doc.Status_ID == 125 || doc.Status_ID == 126))
                    {
                        if (sbConsDocs.Length == 0)
                            sbConsDocs.AppendFormat("{0}", doc.Doc_ID);
                        else
                            sbConsDocs.AppendFormat(",{0}", doc.Doc_ID);
                    }
                }

                var sConsDocs = sbConsDocs.ToString();
                if (string.IsNullOrEmpty(sConsDocs))
                    throw new Exception("Среди выбранных макетов отсутствуют подходящие.");

                var consWorker = new BackgroundWorker();
                consWorker.DoWork += (s, ea) =>
                {
                    try
                    {
                        ea.Result = WMSOffice.Window.WriteOff.CardCalculationWindow.CardCalculationView.GetDataCons(sConsDocs);
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };
                consWorker.RunWorkerCompleted += (s, ea) =>
                {
                    waitProgressForm.CloseForce();

                    if (ea.Result is Exception)
                        this.ShowError(ea.Result as Exception);
                    else
                    {
                        var data = ea.Result as DataTable;

                        var dialogTitle = String.Format("Экспорт конс. расчета компенсации");
                        var fileNamePart = String.Format("Конс. расчет компенсации");

                        DateTime now = DateTime.Now;
                        var dialog = new SaveFileDialog()
                        {
                            FileName = String.Format("{0}{1}{2}{3}{4}{5}-{6}", now.Year.ToString(),
                                now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                                now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'), fileNamePart),
                            Title = dialogTitle,
                            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                            Filter = "Excel файл (*.xlsx)|*.xlsx",
                            FilterIndex = 0,
                            AddExtension = true,
                            DefaultExt = "xlsx"
                        };
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            var fileName = dialog.FileName;
                            CardCalculationWindow.CreateFile(fileName, false, data, true);

                            Process.Start(fileName);
                        }
                    }
                };

                waitProgressForm.ActionText = "Выполняется конс. расчет поставщика..";
                consWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string fileName = String.Empty;
            try
            {
                if (MessageBox.Show("Утвердить выбранный документ?", "Утвердить...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var docId = (int)SelectedDoc.Doc_ID;

                // Выбор типа списания
                if (/*SelectedDoc.Status_ID == 128 &&*/ SelectedDoc.Accept128)
                {
                    #region ВЫБОР ТИПА СПИСАНИЯ

                    var jdeDocType = SelectedDoc.JDE_Doc_Type;

                    var jdeDocTypes = new Data.WH.WF_GetJDEDocTypesDataTable();
                    using (var adapter = new WF_GetJDEDocTypesTableAdapter())
                        adapter.Fill(jdeDocTypes, this.UserID);

                    if (jdeDocTypes != null && jdeDocTypes.Rows.Count > 0)
                    {
                        var dlgSelectDocType = new WMSOffice.Dialogs.RichListForm();
                        dlgSelectDocType.Text = "Выберите тип списания";
                        dlgSelectDocType.AddColumn("DocType", "DocType", "Тип");
                        dlgSelectDocType.AddColumn("Desc", "Desc", "Описание");
                        dlgSelectDocType.ValueField = "DocType";
                        dlgSelectDocType.FilterVisible = false;
                        dlgSelectDocType.DataSource = jdeDocTypes;
                        dlgSelectDocType.SelectedValue = jdeDocType;

                        if (dlgSelectDocType.ShowDialog() == DialogResult.OK)
                        {
                            jdeDocType = (dlgSelectDocType.SelectedRow as Data.WH.WF_GetJDEDocTypesRow).DocType;
                            using (var adapter = new WF_GetJDEDocTypesTableAdapter())
                                adapter.ChangeJDEDocType(docId, jdeDocType, this.UserID);

                            SelectedDoc.Status_ID = 300; // SelectedDoc.Doc_TypeID.ToUpper() == "SP" ? 140 : 130;
                            SelectedDoc.JDE_Doc_Type = jdeDocType;

                            MessageBox.Show("Документ утвержден.", "Утвердить...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    #endregion

                    return;
                }
                
                DataTable exportData;
                using (var adapter = new CompensationDetailsTableAdapter())
                    exportData = adapter.GetData(docId);

                if (exportData.Rows.Count == 0)
                    return;

                var row = exportData.Rows[0] as WMSOffice.Data.WF.CompensationDetailsRow;
                if (row == null)
                    return;

                fileName = String.Format("Расчет компенсации_{1}_{2}({0}).xlsx", SelectedDoc.Doc_ID, row.Поставщик.Trim(), row.ABAN8);
                fileName = fileName.Replace(@"\", "_").Replace(@"/", "_").Replace(@":", "_").Replace('"', '_');

                string outFile = Path.Combine(STR_OutFilePath, fileName);
                CardCalculationWindow.CreateFile(outFile, true, exportData, false);
                using (var adapter = new CompensationDetailsTableAdapter())
                    adapter.SaveFilePath(SelectedDoc.Doc_ID, outFile);

                int status_Id = 130;
                if (SelectedDoc.Doc_TypeID.ToUpper() == "SP")
                    status_Id = 140;

                using (var adapter = new CompensationDetailsTableAdapter())
                    adapter.ChangeStatus(SelectedDoc.Doc_ID, status_Id);

                SelectedDoc.Status_ID = status_Id;

                MessageBox.Show("Документ утвержден.", "Утвердить...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(String.Format("{1} - {0}", ex.Message, fileName), "Утвердить...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowState_Click(object sender, EventArgs e)
        {
            dgvStatus.Visible = !dgvStatus.Visible;
            if (!dgvStatus.Visible)
                btnShowState.Text = "Статус документа";
            else
                btnShowState.Text = "Скрыть статусы";
        }

        [Obsolete("Дублирование метода CardCalculationWindow.CreateFile")]
        private void CreateFile(string fileName, bool toDirectum, DataTable exportData)
        {
            MemoryStream stream = new MemoryStream(Properties.Resources.WF_CalcTemp);

            XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
            var sheet = templateWorkbook.GetSheet("Лист1");

            int rowNum = 1;

            foreach (WF.CompensationDetailsRow item in exportData.Rows)
            {
                try
                {
                    IRow row = sheet.CreateRow(rowNum);
                    row.CreateCell(0).SetCellValue(item.___акта_несоответствия);
                    row.CreateCell(1).SetCellValue(item.Производитель);
                    row.CreateCell(2).SetCellValue(item.Тип_компенсации);
                    row.CreateCell(3).SetCellValue(item.Дата_расчета_компенсации.ToString("dd.MM.yyyy"));
                    row.CreateCell(4).SetCellValue(item.Код_товара);
                    row.CreateCell(5).SetCellValue(item.Название_товара);
                    row.CreateCell(6).SetCellValue(item.Серия);
                    row.CreateCell(7).SetCellValue(item.Партия);
                    row.CreateCell(8).SetCellValue(item.Срок_годности.ToString("dd.MM.yyyy"));
                    row.CreateCell(9).SetCellValue(item._Номер_инвойса_накладной);
                    row.CreateCell(10).SetCellValue(item._Дата_инвойса_накладной.ToString("dd.MM.yyyy"));

                    if (toDirectum)
                        row.CreateCell(11).SetCellValue(item.Количество);
                    else
                        row.CreateCell(11).SetCellValue(item.Количество_расчета);

                    row.CreateCell(12).SetCellValue(item.Валюта);
                    row.CreateCell(13).SetCellValue((double)item.Цена_брутто);
                    row.CreateCell(14).SetCellValue(item._Вес_1_уп__кг);
                    row.CreateCell(15).SetCellValue(item.Курс_НБУ);
                    row.CreateCell(16).SetCellValue((double)item._Скидка___);
                    row.CreateCell(17).SetCellValue((double)item._Пошлина___);
                    row.CreateCell(18).SetCellValue(item._НДС___);
                    row.CreateCell(19).SetCellValue((double)item._НР___);
                    row.CreateCell(20).SetCellValue((double)item._Стоимость_уничтожения_грн__1_кг);


                    row.CreateCell(21).SetCellValue((double)item._ВУ___);
                    row.CreateCell(22).SetCellValue((double)item._НПП___);

                    if (toDirectum)
                        row.CreateCell(23).SetCellValue(item.ИТОГО);
                    else
                        row.CreateCell(23).SetCellValue(item.ИТОГО_Расчета);

                    rowNum++;
                }
                catch (Exception)
                {

                }
            }

            IRow rowSum = sheet.CreateRow(rowNum);
            var font = templateWorkbook.CreateFont();
            font.Boldweight = 2;
            //style1.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Pink.Index;
            //style1.FillPattern = FillPattern.SolidForeground; 

            ICell cell = rowSum.CreateCell(23);
            cell.SetCellFormula(String.Format("SUM(X2:X{0})", rowNum));
            cell.CellStyle.SetFont(font);

            for (int i = 0; i < 24; i++)
                sheet.AutoSizeColumn(i);

            FileStream file = new FileStream(fileName, FileMode.Create);
            templateWorkbook.Write(file);

            file.Close();
            file.Dispose();

            stream.Close();
            stream.Dispose();

        }

        private void btnCalcExport_Click(object sender, EventArgs e)
        {
            try
            {
                var docId = (int)SelectedDoc.Doc_ID;
                DataTable exportData;
                using (var adapter = new CompensationDetailsTableAdapter())
                    exportData = adapter.GetData(docId);

                if (exportData.Rows.Count == 0)
                    return;

                var row = exportData.Rows[0] as WMSOffice.Data.WF.CompensationDetailsRow;
                if (row == null)
                    return;

                string fileName = String.Format("Расчет компенсации_{1}_{2}({0}).xlsx", SelectedDoc.Doc_ID, row.Поставщик.Trim(), row.ABAN8);

                fileName = fileName.Replace(@"\", "_").Replace(@"/", "_").Replace(@":", "_");

                var dlg = new SaveFileDialog() { FileName = fileName, Filter = "Книга Excel|*.xlsx" };
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                CardCalculationWindow.CreateFile(dlg.FileName, true, exportData, false);

                if (MessageBox.Show(String.Format("Экспорт завершен успешно.{0}Открыть сохраненный файл расчета?", Environment.NewLine), "Экспорт...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;

                System.Diagnostics.Process.Start(dlg.FileName);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Ошибка экспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            var frm = new AccountDisposalForm(UserID) { Owner = this, ShowInTaskbar = false, StartPosition = FormStartPosition.CenterParent };
            frm.ShowDialog();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            var frm = new RequestViewForm(UserID) { Owner = this, ShowInTaskbar = false, StartPosition = FormStartPosition.CenterParent };
            frm.ShowDialog();
        }

        private void cmiExportDocs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт реестра макетов списания";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-реестр макетов списания",
                    now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'),
                    now.Day.ToString().PadLeft(2, '0'),
                    now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'),
                    now.Second.ToString().PadLeft(2, '0')
                    );

                dlgSelectFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSelectFile.Filter = "Текстовый файл с разделителями (*.csv)|*.csv";//;*.csv|Все файлы (*.*)|*.*";
                dlgSelectFile.FilterIndex = 0;
                dlgSelectFile.AddExtension = true;
                dlgSelectFile.DefaultExt = "csv";
                if (dlgSelectFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.dgvDocs.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }
            }
        }

        private void btnShowAttachments_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new ComplaintAttachmentsForm(UserID, SelectedDoc.Doc_ID, false, false, true))
                {
                    form.ShowDialog(this);
                    //RefreshDocs();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    #region КЛАССЫ ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА С МАКЕТАМИ

    /// <summary>
    /// Представление для грида с макетами списания
    /// </summary>
    public class WriteOffStuffsView : IDataView
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
            try
            {
                var sc = pSearchParameters as WriteOffStuffsViewSearchParameters;
                using (var adapter = new WF_GetDocsTableAdapter())
                    data = adapter.GetData(sc.SessionID, null, sc.OnlyActive);
            }
            catch
            {
                data = new WH.WF_GetDocsDataTable();
            }
        }

        public WriteOffStuffsView()
        {
            this.dataColumns.Add(new PatternColumn("№ документа", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("№ Акта", "Act_Number", new FilterPatternExpressionRule("Act_Number"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Тип документа", "Doc_Type", new FilterPatternExpressionRule("Doc_Type"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Дата документа", "DocDate", new FilterDateCompareExpressionRule("DocDate"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Склад", "Warehouse", new FilterPatternExpressionRule("Warehouse"), SummaryCalculationType.Count));
            this.dataColumns.Add(new ImagePatternColumn("П. ф.", "HasAttachedFiles") { Width = 22 });
            this.dataColumns.Add(new PatternColumn("Пользователь", "User", new FilterPatternExpressionRule("User"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Статус", "StatusName", new FilterPatternExpressionRule("StatusName"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("№ в JD", "JDE_Doc", new FilterPatternExpressionRule("JDE_Doc"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Тип JD", "JDE_Doc_Type", new FilterPatternExpressionRule("JDE_Doc_Type"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Итог. сумма", "Amount_UAH", new FilterCompareExpressionRule<Decimal>("Amount_UAH"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Итог. сумма в базовых", "BaseAmount", new FilterCompareExpressionRule<Decimal>("BaseAmount"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Описание", "Desc", new FilterPatternExpressionRule("Desc"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Инвентаризация", "Inventory_ID", new FilterPatternExpressionRule("Inventory_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("ЗУ экспортирована", "request_printed", new FilterPatternExpressionRule("request_printed"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("В иностранной валюте", "IS_Foreign_Currency", ColumnType.Logical, new FilterEmptyExpressionRule(), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("№ Заявки на уничтожение", "Desctruction_number", new FilterCompareExpressionRule<Int32>("Desctruction_number"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Валюта", "CurrencyId", new FilterPatternExpressionRule("CurrencyId"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Списание на забаланс", "IsNotBalance", ColumnType.Logical, new FilterEmptyExpressionRule(), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Тип компенсации", "CompType", new FilterPatternExpressionRule("CompType"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Акт несоответствия", "Act_Comment", new FilterPatternExpressionRule("Act_Comment")));
            this.dataColumns.Add(new PatternColumn("Пост.", "VendorID", new FilterCompareExpressionRule<Int32>("VendorID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Поставщик", "VendorName", new FilterPatternExpressionRule("VendorName")));
            this.dataColumns.Add(new PatternColumn("Автор макета", "User_Created", new FilterPatternExpressionRule("User_Created")));
            this.dataColumns.Add(new PatternColumn("Тип списания", "AutoTypeName", new FilterPatternExpressionRule("AutoTypeName"), SummaryCalculationType.Count));
        }
    }

    public class WriteOffStuffsViewSearchParameters : SessionIDSearchParameters
    {
        public bool? OnlyActive { get; set; }
    }

    #endregion
}
