using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Docs;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;
using System.Reflection;
using System.Diagnostics;

namespace WMSOffice.Window
{
    public partial class ArchiveInvoiceWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Проверка доступа к режиму подтверждения принятых документов
        /// </summary>
        public bool CanAcceptReceivedDocs { get; set; }

        /// <summary>
        /// Проверка доступа к функционалу перевода в бумажный вид
        /// </summary>
        public bool CanSetPaperForm { get; set; }

        /// <summary>
        /// Режим работы с интерфейсом
        /// </summary>
        public string WorkModeKey { get; set; }
        public string WorkModeValue { get; set; }

        /// <summary>
        /// Режим работы закрытия оборотной тары
        /// </summary>
        public bool CloseTareInvoiceWorkMode { get { return this.WorkModeKey.ToUpper().Contains("TARE"); } }

        public ArchiveInvoiceWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
        }

        /// <summary>
        /// Выбор режима работы
        /// </summary>
        /// <returns></returns>
        private bool SelectWorkMode()
        {
            try
            {
                var ai_WorkModes = new Data.WH.AI_WorkModesDataTable();
                using (var adapter = new Data.WHTableAdapters.AI_WorkModesTableAdapter())
                    adapter.Fill(ai_WorkModes, this.UserID);

                if (ai_WorkModes.Rows.Count == 0)
                    throw new Exception("У Вас нет доступа к интерфейсу работы с архивариусом.");

                if (ai_WorkModes.Rows.Count == 1)
                {
                    this.WorkModeKey = ai_WorkModes[0].Entity_Key;
                    this.WorkModeValue = ai_WorkModes[0].Entity_Value;
                    return true;
                }
                else
                {
                    var dlgSelectWorkMode = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectWorkMode.Text = "Выберите режим работы";
                    dlgSelectWorkMode.AddColumn("Entity_Value", "Entity_Value", "Режим работы");
                    dlgSelectWorkMode.FilterChangeLevel = 0;
                    dlgSelectWorkMode.FilterVisible = false;

                    dlgSelectWorkMode.DataSource = ai_WorkModes;

                    if (dlgSelectWorkMode.ShowDialog() != DialogResult.OK)
                        return false;

                    var workMode = dlgSelectWorkMode.SelectedRow as Data.WH.AI_WorkModesRow;
                    this.WorkModeKey = workMode.Entity_Key;
                    this.WorkModeValue = workMode.Entity_Value;
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void Initialize()
        {
            tsMain.Visible = false;
            pnlContent.Visible = false;

            if (!this.SelectWorkMode())
            {
                this.Close();
                return;
            }

            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, this.WorkModeValue);
            tsMain.Visible = true;
            pnlContent.Visible = true;

            this.ShowArchiveSearchParameters(false);

            this.CheckAccessAcceptReceivedDocsMode();

            this.CheckAccessSetPaperForm();
            btnSetPaperForm.Visible = tssSetPaperform.Visible = this.CanSetPaperForm; 

            if (this.CloseTareInvoiceWorkMode)
            {
                tssSetPaperform.Visible = false;
                btnSetReceiptDate.Visible = false;

                cbArchiveMode.Enabled = false;
            }

            stbWarehouse.ValueReferenceQuery = this.CloseTareInvoiceWorkMode ? "[dbo].[pr_AI_RET_Get_MCU_List]" : "[dbo].[pr_AI_Get_MCU_List]";
            stbWarehouse.ApplyAdditionalParameter("CanSelectAllWarehouses", true);
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbWarehouse.SetFirstValueByDefault();

            stbDebtor.ValueReferenceQuery = this.CloseTareInvoiceWorkMode ? "[dbo].[pr_AI_RET_Get_Debtors_List]" : "[dbo].[pr_AI_Get_Debtors_List]";
            stbDebtor.UserID = this.UserID;
            stbDebtor.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbDocTypeFrom.ValueReferenceQuery = this.CloseTareInvoiceWorkMode ? "[dbo].[pr_AI_RET_Get_Doc_Types_List]" : "[dbo].[pr_AI_Get_Doc_Types_List]";
            stbDocTypeFrom.UserID = this.UserID;
            stbDocTypeFrom.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbDocTypeFrom.SetFirstValueByDefault();

            stbDocTypeTo.ValueReferenceQuery = this.CloseTareInvoiceWorkMode ? "[dbo].[pr_AI_RET_Get_Doc_Types_List]" : "[dbo].[pr_AI_Get_Doc_Types_List]";
            stbDocTypeTo.UserID = this.UserID;
            stbDocTypeTo.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbDocTypeTo.SetLastValueByDefault();

            stbDocType.ValueReferenceQuery = this.CloseTareInvoiceWorkMode ? "[dbo].[pr_AI_RET_Get_Doc_Types_List]" : "[dbo].[pr_AI_Get_Doc_Types_List]";
            stbDocType.UserID = this.UserID;
            stbDocType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            foreach (AdvancedSearchModes mode in Enum.GetValues(typeof(AdvancedSearchModes)))
            {
                var key = mode;
                var value = this.GetEnumDescription(mode);

                if (this.CloseTareInvoiceWorkMode && key != AdvancedSearchModes.ProcessedInvoices)
                    continue;
                
                chbAdvancedSearchModes.Items.Add(new CCBoxItem(value, (long)key), false);
            }

            xdgvDocs.AllowSummary = false;

            xdgvDocs.Init(new ArchiveInvoicesView(this.CloseTareInvoiceWorkMode), true);
            xdgvDocs.UserID = this.UserID;

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvDocs_OnRowDoubleClick);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            this.SetOperationAccess(true);

            stbWarehouse.Focus();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = tbWarehouseName;
            else if (control == stbDebtor)
                lblDescription = tbDebtorName;
            else if (control == stbDocTypeFrom)
                lblDescription = tbDocTypeFromName;
            else if (control == stbDocTypeTo)
                lblDescription = tbDocTypeToName;
            else if (control == stbDocType)
                lblDescription = tbDocTypeName;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvDocs.SelectedItem != null)
                this.ArchiveInvoiceManual();
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            if (wholeViewAccess)
            {
                bool hasRows = xdgvDocs.HasRows;
                bool isEnabled = hasRows && xdgvDocs.SelectedItem != null;

                bool isArchiveEnabled = isEnabled;

                bool isRevertEnabled = isEnabled;
                isRevertEnabled = isRevertEnabled && Convert.ToInt32(xdgvDocs.SelectedItem["archive_mode"] == DBNull.Value ? 0 : xdgvDocs.SelectedItem["archive_mode"]) == 0;
                isRevertEnabled = isRevertEnabled && (xdgvDocs.SelectedItem["ED_State"] == DBNull.Value ? Convert.ToInt32(xdgvDocs.SelectedItem["ready"] == DBNull.Value ? 0 : xdgvDocs.SelectedItem["ready"]) == 1 : Convert.ToInt32(xdgvDocs.SelectedItem["show_processed_lines"] == DBNull.Value ? 0 : xdgvDocs.SelectedItem["show_processed_lines"]) == 1);

                bool isSetPaperFormEnabled = hasRows;
                isSetPaperFormEnabled = isSetPaperFormEnabled && this.CanSetPaperForm; 

                bool isSetReceiptDateEnabled = hasRows;
                isSetReceiptDateEnabled = isSetReceiptDateEnabled && this.CanAcceptReceivedDocs;

                bool isExportEnabled = hasRows;

                btnArchiveInvoiceManual.Enabled = isArchiveEnabled;
                btnRevert.Enabled = isRevertEnabled;
                btnSetPaperForm.Enabled = isSetPaperFormEnabled;
                btnSetReceiptDate.Enabled = isSetReceiptDateEnabled;
                btnExport.Enabled = isExportEnabled;
            }
            else
            {
                bool hasRows = xdgvDocs.HasRows;
                bool isEnabled = xdgvDocs.SelectedItem != null;

                bool isArchiveEnabled = isEnabled;

                bool isRevertEnabled = isEnabled;
                isRevertEnabled = isRevertEnabled && Convert.ToInt32(xdgvDocs.SelectedItem["archive_mode"] == DBNull.Value ? 0 : xdgvDocs.SelectedItem["archive_mode"]) == 0;
                isRevertEnabled = isRevertEnabled && (xdgvDocs.SelectedItem["ED_State"] == DBNull.Value ? Convert.ToInt32(xdgvDocs.SelectedItem["ready"] == DBNull.Value ? 0 : xdgvDocs.SelectedItem["ready"]) == 1 : Convert.ToInt32(xdgvDocs.SelectedItem["show_processed_lines"] == DBNull.Value ? 0 : xdgvDocs.SelectedItem["show_processed_lines"]) == 1);

                bool isSetPaperFormEnabled = hasRows;
                isSetPaperFormEnabled = isSetPaperFormEnabled && this.CanSetPaperForm; 

                bool isSetReceiptDateEnabled = hasRows;
                isSetReceiptDateEnabled = isSetReceiptDateEnabled && this.CanAcceptReceivedDocs;

                bool isExportEnabled = hasRows;

                btnArchiveInvoiceManual.Enabled = isArchiveEnabled;
                btnRevert.Enabled = isRevertEnabled;
                btnSetPaperForm.Enabled = isSetPaperFormEnabled;
                btnSetReceiptDate.Enabled = isSetReceiptDateEnabled;
                btnExport.Enabled = isExportEnabled;
            }
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvDocs.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (!this.CloseTareInvoiceWorkMode)
            {
                var boundRow = (xdgvDocs.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

                #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ЭЛЕКТРОННЫХ РН

                var hasEDoc = !string.IsNullOrEmpty(boundRow["ED_State"].ToString());
                if (hasEDoc)
                {
                    var color = Color.Khaki;
                    e.CellStyle.BackColor = color;
                    e.CellStyle.SelectionForeColor = color;
                    //e.CellStyle.SelectionBackColor = color;
                }

                #endregion
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.ReloadData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new ArchiveInvoicesSearchParameters() { SessionID = this.UserID };

                if (string.IsNullOrEmpty(stbWarehouse.Value))
                    throw new Exception("Код склада должен быть указан.");
                else
                    searchParams.WarehouseID = stbWarehouse.Value;

                if (!string.IsNullOrEmpty(stbDebtor.Value))
                {
                    int debtorID;
                    if (!int.TryParse(stbDebtor.Value, out debtorID))
                        throw new Exception("Код дебитора должен быть числом.");
                    else
                        searchParams.DebtorID = debtorID;
                }

                var dateFrom = dtpDateFrom.Value.Date;
                var dateTo = dtpDateTo.Value.Date;
                if (dateFrom > dateTo)
                    throw new Exception("Дата начала периода не должна превышать\nдату конца периода.");

                searchParams.DateFrom = dateFrom;
                searchParams.DateTo = dateTo;

                if (string.IsNullOrEmpty(stbDocTypeFrom.Value))
                    throw new Exception("Тип документа \"с\" должен быть указан.");
                else
                    searchParams.DocTypeFromID = stbDocTypeFrom.Value;

                if (string.IsNullOrEmpty(stbDocTypeTo.Value))
                    throw new Exception("Тип документа \"по\" должен быть указан.");
                else
                    searchParams.DocTypeToID = stbDocTypeTo.Value;

                foreach (CCBoxItem item in chbAdvancedSearchModes.CheckedItems)
                {
                    var mode = (AdvancedSearchModes)item.Value;

                    switch (mode)
                    {
                        case AdvancedSearchModes.CanceledInvoices:
                            searchParams.CanceledInvoices = true;
                            break;
                        case AdvancedSearchModes.ProcessedInvoices:
                            searchParams.ProcessedInvoices = true;
                            break;
                        case AdvancedSearchModes.NotReturnedInvoices:
                            searchParams.NotReturnedInvoices = true;
                            break;
                        //case AdvancedSearchModes.InvoicesWithoutReceiptDate:
                        //    searchParams.InvoicesWithoutReceiptDate = true;
                        //    break;
                        case AdvancedSearchModes.NotClosedInvoices:
                            searchParams.NotClosedInvoices = true;
                            break;
                        default:
                            break;
                    }
                }

                var archiveMode = cbArchiveMode.Checked;
                searchParams.ArchiveMode = archiveMode;

                if (archiveMode)
                {
                    if (string.IsNullOrEmpty(stbDocType.Value))
                        throw new Exception("Тип документа должен быть указан.");
                    else
                        searchParams.ArchiveDocTypeID = stbDocType.Value;

                    if (!string.IsNullOrEmpty(tbDocNumber.Text))
                    {
                        long parsedDocNumber;
                        if (!long.TryParse(tbDocNumber.Text, out parsedDocNumber))
                            throw new Exception("№ документа должен быть числом.");
                        else
                            searchParams.ArchiveDocNumber = parsedDocNumber;
                    }
                }

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvDocs.DataView.FillData(e.Argument as ArchiveInvoicesSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvDocs.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvDocs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение документов архивариуса..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Определение доступа к режиму подтверждения принятых документов
        /// </summary>
        /// <returns></returns>
        private bool CheckAccessAcceptReceivedDocsMode()
        {
            try
            {
                var access = (int?)null;

                using (var adapter = new Data.WHTableAdapters.AI_DocsTableAdapter())
                    adapter.CheckAccessMode(this.UserID, ref access);

                return (this.CanAcceptReceivedDocs = Convert.ToBoolean(access ?? 0));
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        /// <summary>
        /// Определение доступа к функционалу перевода в бумажный вид
        /// </summary>
        /// <returns></returns>
        private bool CheckAccessSetPaperForm()
        {
            try
            {
                var access = (int?)null;

                using (var adapter = new Data.WHTableAdapters.AI_DocsTableAdapter())
                    adapter.CheckAccessSetPaperForm(this.UserID, ref access);

                return (this.CanSetPaperForm = Convert.ToBoolean(access ?? 0));
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void btnArchiveInvoice_Click(object sender, EventArgs e)
        {
            this.ArchiveInvoice();
        }

        public void ArchiveInvoice()
        {
            var invoiceArchiveDate = DateTime.Now;

            if (this.CloseTareInvoiceWorkMode)
            {
                var dlgArchiveReturnedTareInvoice = new ArchiveReturnedTareInvoiceForm() { UserID = this.UserID, InvoiceArchiveDate = invoiceArchiveDate };
                dlgArchiveReturnedTareInvoice.ShowDialog(this);
            }
            else
            {
                var canAcceptReceivedDocs = this.CanAcceptReceivedDocs; //this.CheckAccessAcceptReceivedDocsMode();
                var dlgArchiveInvoice = new ArchiveInvoiceForm() { UserID = this.UserID, InvoiceArchiveDate = invoiceArchiveDate, CanAcceptReceivedDocs = canAcceptReceivedDocs };
                dlgArchiveInvoice.ShowDialog(this);
            }
        }

        private void btnArchiveInvoiceManual_Click(object sender, EventArgs e)
        {
            this.ArchiveInvoiceManual();
        }

        public void ArchiveInvoiceManual()
        {
            var invoiceArchiveDate = DateTime.Now;

            var docType = xdgvDocs.SelectedItem["doc_type"].ToString();
            var docNumber = Convert.ToInt32(xdgvDocs.SelectedItem["doc"]);

            if (this.CloseTareInvoiceWorkMode)
            {
                var dlgArchiveReturnedTareInvoice = new ArchiveReturnedTareInvoiceForm(docType, docNumber) { UserID = this.UserID, InvoiceArchiveDate = invoiceArchiveDate };
                dlgArchiveReturnedTareInvoice.ShowDialog(this);
            }
            else
            {
                var canAcceptReceivedDocs = this.CanAcceptReceivedDocs; //this.CheckAccessAcceptReceivedDocsMode();
                var dlgArchiveInvoice = new ArchiveInvoiceForm(docType, docNumber) { UserID = this.UserID, InvoiceArchiveDate = invoiceArchiveDate, CanAcceptReceivedDocs = canAcceptReceivedDocs };
                dlgArchiveInvoice.ShowDialog(this);
            }
        }

        public string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            this.RevertInvoice();
        }

        private void RevertInvoice()
        {
            try
            {
                var docType = xdgvDocs.SelectedItem["doc_type"].ToString();
                var docNumber = Convert.ToInt32(xdgvDocs.SelectedItem["doc"]);

                using (var adapter = new Data.WHTableAdapters.AI_DocsTableAdapter())
                    adapter.Revert(docType, docNumber, this.UserID);

                xdgvDocs.SelectedItem["ready"] = 0;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void cbArchiveMode_CheckedChanged(object sender, EventArgs e)
        {
            ShowArchiveSearchParameters(cbArchiveMode.Checked);
        }

        private void ShowArchiveSearchParameters(bool visible)
        {
            if (pnlArchiveModeSearchParameters.Visible == visible)
                return;

            pnlArchiveModeSearchParameters.Visible = visible;

            if (visible)
            {
                pnlSearchParameters.Height += pnlArchiveModeSearchParameters.Height;
                this.SelectNextControl(cbArchiveMode, true, true, true, false);
            }
            else
            {
                pnlSearchParameters.Height -= pnlArchiveModeSearchParameters.Height;
            }

            // Очищаем дополнительные параметры поиска
            stbDocType.SetValueByDefault(string.Empty);
            tbDocNumber.Clear();
        }

        private void lblArchiveMode_Click(object sender, EventArgs e)
        {
            if (cbArchiveMode.Enabled)
                cbArchiveMode.Checked = !cbArchiveMode.Checked;
        }

        private void btnSetReceiptDate_Click(object sender, EventArgs e)
        {
            var dlgArchiveInvoiceSetReceiptDate = new ArchiveInvoiceSetReceiptDateForm() { UserID = this.UserID };

            var dataView = xdgvDocs.DataView.Data.DefaultView;
            var dataSource = new Data.WH.AI_DocsDataTable();

            dataSource.Merge(dataView.ToTable());
            dlgArchiveInvoiceSetReceiptDate.PrepareDataSource(dataSource);

            dlgArchiveInvoiceSetReceiptDate.ShowDialog(this);

            if (dlgArchiveInvoiceSetReceiptDate.DataSaved)
                this.ReloadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт накладных";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-реестр накладных",
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
                        this.xdgvDocs.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }
            }
        }

        private void btnChangeView_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            
            this.WindowState = FormWindowState.Minimized;
            this.Close();
        }

        private void btnSetPaperForm_Click(object sender, EventArgs e)
        {
            this.SetPaperForm();
        }

        private void SetPaperForm()
        {
            try
            {
                var docNumber = Convert.ToInt32(xdgvDocs.SelectedItem["doc"]);
                var docType = xdgvDocs.SelectedItem["doc_type"].ToString();

                using (var adapter = new Data.WHTableAdapters.AI_DocsTableAdapter())
                    adapter.SetPaperForm(docNumber, docType, this.UserID);

                this.ReloadData();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    public enum AdvancedSearchModes
    {
        /// <summary>
        /// Отмененные накладные
        /// </summary>
        [Description("Отмененные накладные")]
        CanceledInvoices = 0,

        /// <summary>
        /// Обработанные накладные
        /// </summary>
        [Description("Обработанные накладные")]
        ProcessedInvoices = 1,

        /// <summary>
        /// Невернувшиеся накладные
        /// </summary>
        [Description("Невернувшиеся накладные")]
        NotReturnedInvoices = 2,

        ///// <summary>
        ///// Дата поступления отсутствует
        ///// </summary>
        //[Description("Дата поступления отсутствует")]
        //InvoicesWithoutReceiptDate = 3,

        /// <summary>
        /// Незакрытые накладные
        /// </summary>
        [Description("Незакрытые накладные")]
        NotClosedInvoices = 4
    }

    /// <summary>
    /// Представление для доверенностей
    /// </summary>
    public class ArchiveInvoicesView : IDataView
    {
        public bool CloseTareInvoiceWorkMode { get; set; }

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as ArchiveInvoicesSearchParameters;

            if (this.CloseTareInvoiceWorkMode)
            {
                using (var adapter = new Data.WHTableAdapters.AI_Ret_DocsTableAdapter())
                {
                    adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                    this.data = adapter.GetData(
                        searchCriteria.SessionID,
                        searchCriteria.WarehouseID,
                        searchCriteria.DateFrom,
                        searchCriteria.DateTo,
                        searchCriteria.DocTypeFromID,
                        searchCriteria.DocTypeToID,
                        Convert.ToInt32(searchCriteria.ProcessedInvoices),
                        searchCriteria.DebtorID);
                }
            }
            else
            {
                using (var adapter = new Data.WHTableAdapters.AI_DocsTableAdapter())
                {
                    adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                    this.data = adapter.GetData(
                        searchCriteria.SessionID,
                        searchCriteria.WarehouseID,
                        searchCriteria.DateFrom,
                        searchCriteria.DateTo,
                        searchCriteria.DocTypeFromID,
                        searchCriteria.DocTypeToID,
                        Convert.ToInt32(searchCriteria.CanceledInvoices),
                        Convert.ToInt32(searchCriteria.ProcessedInvoices),
                        Convert.ToInt32(searchCriteria.NotReturnedInvoices),
                        Convert.ToInt32(searchCriteria.ArchiveMode),
                        searchCriteria.ArchiveDocNumber,
                        searchCriteria.ArchiveDocTypeID,
                        Convert.ToInt32(searchCriteria.NotClosedInvoices),
                        searchCriteria.DebtorID);
                }
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public ArchiveInvoicesView(bool closeTareInvoiceWorkMode)
        {
            this.CloseTareInvoiceWorkMode = closeTareInvoiceWorkMode;

            if (this.CloseTareInvoiceWorkMode)
            {
                this.dataColumns.Add(new PatternColumn("Компания", "company", new FilterPatternExpressionRule("company")) { Width = 70 });
                this.dataColumns.Add(new PatternColumn("№ накладной", "doc", new FilterCompareExpressionRule<Int32>("doc"), SummaryCalculationType.TotalRecords) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("Тип накладной", "doc_type", new FilterPatternExpressionRule("doc_type")) { Width = 70 });

                this.dataColumns.Add(new PatternColumn("№ МЛ", "route_number", new FilterCompareExpressionRule<Int32>("route_number"), SummaryCalculationType.Count) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Код", "adress_number", new FilterCompareExpressionRule<Int32>("adress_number"), SummaryCalculationType.Count) { Width = 50 });
                this.dataColumns.Add(new PatternColumn("Наименование дебитора", "alpha_name", new FilterPatternExpressionRule("alpha_name")) { Width = 300 });
                this.dataColumns.Add(new PatternColumn("Город", "city", new FilterPatternExpressionRule("city")) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Дата накладной", "invoice_date", new FilterDateCompareExpressionRule("invoice_date")) { Width = 90 });

                this.dataColumns.Add(new PatternColumn("Принята", "is_received", new FilterCompareExpressionRule<Int32>("is_received")) { Width = 80 });
                this.dataColumns.Add(new PatternColumn("Сумма по накладной", "summ_fact", new FilterCompareExpressionRule<Decimal>("summ_fact"), SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });

                this.dataColumns.Add(new PatternColumn("Менеджер", "manager", new FilterPatternExpressionRule("manager")) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Дата и время принятия", "archive_event_date", new FilterDateCompareExpressionRule("archive_event_date")) { Width = 150 });

                this.dataColumns.Add(new PatternColumn("Статус", "status_info", new FilterPatternExpressionRule("status_info")) { Width = 150 });
                this.dataColumns.Add(new PatternColumn("Информация", "doc_info", new FilterPatternExpressionRule("doc_info")) { Width = 200 });
            }
            else
            {
                this.dataColumns.Add(new PatternColumn("Компания", "company", new FilterPatternExpressionRule("company")) { Width = 70 });
                this.dataColumns.Add(new PatternColumn("№ накладной", "doc", new FilterCompareExpressionRule<Int32>("doc"), SummaryCalculationType.TotalRecords) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("Тип накладной", "doc_type", new FilterPatternExpressionRule("doc_type")) { Width = 70 });

                this.dataColumns.Add(new PatternColumn("№ заказа", "doco", new FilterPatternExpressionRule("doco")) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Код", "adress_number", new FilterCompareExpressionRule<Int32>("adress_number"), SummaryCalculationType.Count) { Width = 50 });
                this.dataColumns.Add(new PatternColumn("Наименование дебитора", "alpha_name", new FilterPatternExpressionRule("alpha_name")) { Width = 300 });
                this.dataColumns.Add(new PatternColumn("Город", "city", new FilterPatternExpressionRule("city")) { Width = 200 });

                //this.dataColumns.Add(new PatternColumn("Склад", "business_unit", new FilterPatternExpressionRule("business_unit")) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Дата накладной", "invoice_date", new FilterDateCompareExpressionRule("invoice_date")) { Width = 90 });

                this.dataColumns.Add(new PatternColumn("Дата приемки клиентом", "date_from_client", new FilterDateCompareExpressionRule("date_from_client")) { Width = 90 });
                this.dataColumns.Add(new PatternColumn("Дата поступления из филиала", "date_from_filial", new FilterDateCompareExpressionRule("date_from_filial")) { Width = 90 });

                this.dataColumns.Add(new PatternColumn("Готов к разноске", "ready_descr", new FilterPatternExpressionRule("ready_descr")) { Width = 80 });
                this.dataColumns.Add(new PatternColumn("Сумма по накладной", "summ_fact", new FilterCompareExpressionRule<Decimal>("summ_fact"), SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Сумма НДС", "nds_amount", new FilterCompareExpressionRule<Decimal>("nds_amount"), SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });

                this.dataColumns.Add(new PatternColumn("Менеджер", "manager", new FilterPatternExpressionRule("manager")) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Описание статуса е-док.", "ED_State", new FilterPatternExpressionRule("ED_State")) { Width = 120 });
               
                this.dataColumns.Add(new PatternColumn("№ ТТН", "Route_list_number", new FilterPatternExpressionRule("Route_list_number")) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Экспедитор", "Drivers", new FilterPatternExpressionRule("Drivers")) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("№ претензии", "CO_Doc_ID", new FilterCompareExpressionRule<Int64>("CO_Doc_ID"), SummaryCalculationType.Count) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Наименование дебитора связки", "Main_debtor", new FilterPatternExpressionRule("Main_debtor")) { Width = 300 });
            }
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ArchiveInvoicesSearchParameters : SessionIDSearchParameters
    {
        public string WarehouseID { get; set; }
        public int? DebtorID { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string DocTypeFromID { get; set; }
        public string DocTypeToID { get; set; }
        public bool? CanceledInvoices { get; set; }
        public bool? ProcessedInvoices { get; set; }
        public bool? NotReturnedInvoices { get; set; }
        //public bool? InvoicesWithoutReceiptDate { get; set; }
        public bool? NotClosedInvoices { get; set; }
        public bool? ArchiveMode { get; set; }
        public string ArchiveDocTypeID { get; set; }
        public long? ArchiveDocNumber { get; set; }
       
        public ArchiveInvoicesSearchParameters()
        {
            this.WarehouseID = (string)null;
            this.DocTypeFromID = (string)null;
            this.DocTypeToID = (string)null;
            this.ArchiveDocTypeID = (string)null;
        }
    }
}
