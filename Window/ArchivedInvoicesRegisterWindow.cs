using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Diagnostics;
using WMSOffice.Dialogs.Docs;
using CrystalDecisions.CrystalReports.Engine;

namespace WMSOffice.Window
{
    public partial class ArchivedInvoicesRegisterWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Режим работы с интерфейсом
        /// </summary>
        public string WorkModeKey { get; private set; }
        public string WorkModeValue { get; private set; }

        public ArchiveInvoicesRegisterWorkMode WorkMode { get; private set; }

        public Data.WH.RG_Register_HeadersRow SelectedRegister { get { return xdgvRegistry.SelectedItem as Data.WH.RG_Register_HeadersRow; } }

        public ArchivedInvoicesRegisterWindow()
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
                var rg_WorkModes = new Data.WH.RG_Work_ModesDataTable();
                using (var adapter = new Data.WHTableAdapters.RG_Work_ModesTableAdapter())
                    adapter.Fill(rg_WorkModes, this.UserID);

                if (rg_WorkModes.Rows.Count == 0)
                    throw new Exception("У Вас відсутній доступ до інтерфейсу роботи с реестром документів.");

                if (rg_WorkModes.Rows.Count == 1)
                {
                    this.WorkModeKey = rg_WorkModes[0].Entity_Key;
                    this.WorkModeValue = rg_WorkModes[0].Entity_Value;
                    return true;
                }
                else
                {
                    var dlgSelectWorkMode = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectWorkMode.Text = "Оберіть режим роботи";
                    dlgSelectWorkMode.AddColumn("Entity_Value", "Entity_Value", "Режим роботи");
                    dlgSelectWorkMode.FilterChangeLevel = 0;
                    dlgSelectWorkMode.FilterVisible = false;

                    dlgSelectWorkMode.DataSource = rg_WorkModes;

                    dlgSelectWorkMode.Shown += (s, e) => 
                    {
                        dlgSelectWorkMode.Width = 600;
                    };

                    if (dlgSelectWorkMode.ShowDialog() != DialogResult.OK)
                        return false;

                    var workMode = dlgSelectWorkMode.SelectedRow as Data.WH.RG_Work_ModesRow;
                    this.WorkModeKey = workMode.Entity_Key;
                    this.WorkModeValue = workMode.Entity_Value;

                    switch (this.WorkModeKey)
                    {
                        case "ArchiveRegister":
                            this.WorkMode = ArchiveInvoicesRegisterWorkMode.Current;
                            break;
                        case "ArchiveOldRegister":
                            this.WorkMode = ArchiveInvoicesRegisterWorkMode.Obsolete;
                            break;
                        default:
                            break;
                    }

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
            pnlMainContent.Visible = false;

            if (!this.SelectWorkMode())
            {
                this.Close();
                return;
            }

            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, this.WorkModeValue);
            tsMain.Visible = true;
            pnlMainContent.Visible = true;

            stbDocType.ValueReferenceQuery = "[dbo].[pr_RG_Get_Register_Types_List]";
            stbDocType.UserID = this.UserID;
            stbDocType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbDebtorFrom.ValueReferenceQuery = "[dbo].[pr_RG_Get_Debtors_List]";
            stbDebtorFrom.UserID = this.UserID;
            stbDebtorFrom.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbDebtorTo.ValueReferenceQuery = "[dbo].[pr_RG_Get_Debtors_List]";
            stbDebtorTo.UserID = this.UserID;
            stbDebtorTo.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbStatusFrom.ValueReferenceQuery = "[dbo].[pr_RG_Get_Statuses_List]";
            stbStatusFrom.UserID = this.UserID;
            stbStatusFrom.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbStatusTo.ValueReferenceQuery = "[dbo].[pr_RG_Get_Statuses_List]";
            stbStatusTo.UserID = this.UserID;
            stbStatusTo.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbInvoiceType.ValueReferenceQuery = "[dbo].[pr_RG_Get_Doc_Types_List]";
            stbInvoiceType.UserID = this.UserID;
            stbInvoiceType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            var today = DateTime.Today;
            dtpPeriodFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpPeriodTo.Value = today;

            xdgvRegistry.AllowSummary = false;

            xdgvRegistry.Init(new ArchiveInvoicesRegisterView(this.WorkMode), true);
            xdgvRegistry.UserID = this.UserID;

            xdgvRegistry.OnDataError += new DataGridViewDataErrorEventHandler(xdgvRegistry_OnDataError);
            xdgvRegistry.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvRegistry_OnRowDoubleClick);
            xdgvRegistry.OnRowSelectionChanged += new EventHandler(xdgvRegistry_OnRowSelectionChanged);
            xdgvRegistry.OnFilterChanged += new EventHandler(xdgvRegistry_OnFilterChanged);
            xdgvRegistry.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvRegistry_OnFormattingCell);

            // активация постраничного просмотра
            xdgvRegistry.CreatePageNavigator();

            this.SetOperationAccess(true);

            stbDocType.Focus();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbDocType)
                lblDescription = tbDocType;
            else if (control == stbDebtorFrom)
                lblDescription = tbDebtorFrom;
            else if (control == stbDebtorTo)
                lblDescription = tbDebtorTo;
            else if (control == stbStatusFrom)
                lblDescription = tbStatusFrom;
            else if (control == stbStatusTo)
                lblDescription = tbStatusTo;
            else if (control == stbInvoiceType)
                lblDescription = tbInvoiceType;

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

        void xdgvRegistry_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvRegistry_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvRegistry.SelectedItem != null && this.WorkMode == ArchiveInvoicesRegisterWorkMode.Current)
                this.ShowRegistryDetails();
        }

        private void ShowRegistryDetails()
        {
            try
            {
                var registry = xdgvRegistry.SelectedItem as Data.WH.RG_Register_HeadersRow;

                var dlgArchivedInvoicesRegisterDetails = new ArchivedInvoicesRegisterDetailsForm() { UserID = this.UserID, RegisterID = registry.RegisterID };
                if (dlgArchivedInvoicesRegisterDetails.ShowDialog() == DialogResult.OK)
                { 
                
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        void xdgvRegistry_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            btnCreateRegister.Visible = this.WorkMode == ArchiveInvoicesRegisterWorkMode.Obsolete;

            if (wholeViewAccess)
            {
                bool hasRows = xdgvRegistry.HasRows;
                bool isEnabled = hasRows && this.SelectedRegister != null;

                ssbPreviewRegister.Enabled = isEnabled;
                btnPrintRegisterBarcode.Enabled = isEnabled;
            }
            else
            {
                bool hasRows = xdgvRegistry.HasRows;
                bool isEnabled = this.SelectedRegister != null;

                ssbPreviewRegister.Enabled = isEnabled;
                btnPrintRegisterBarcode.Enabled = isEnabled;
            }
        }

        void xdgvRegistry_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvRegistry.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        void xdgvRegistry_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
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

        private void ReloadData()
        {
            try
            {
                var searchParams = new ArchiveInvoicesRegisterSearchParameters() { SessionID = this.UserID };

                if (!string.IsNullOrEmpty(stbDocType.Value))
                {
                    int registerType;
                    if (!int.TryParse(stbDocType.Value, out registerType))
                        throw new Exception("Тип документа повинен бути числом.");
                    else
                        searchParams.RegisterType = registerType;
                }

                if (!string.IsNullOrEmpty(stbDebtorFrom.Value))
                {
                    int debtorFrom;
                    if (!int.TryParse(stbDebtorFrom.Value, out debtorFrom))
                        throw new Exception("Дебітор з повинен бути числом.");
                    else
                        searchParams.DebtorFrom = debtorFrom;
                }

                if (!string.IsNullOrEmpty(stbDebtorTo.Value))
                {
                    int debtorTo;
                    if (!int.TryParse(stbDebtorTo.Value, out debtorTo))
                        throw new Exception("Дебітор по повинен бути числом.");
                    else
                        searchParams.DebtorTo = debtorTo;
                }

                if (!string.IsNullOrEmpty(stbStatusFrom.Value))
                {
                    int statusFrom;
                    if (!int.TryParse(stbStatusFrom.Value, out statusFrom))
                        throw new Exception("Статус з повинен бути числом.");
                    else
                        searchParams.StatusFrom = statusFrom;
                }

                if (!string.IsNullOrEmpty(stbStatusTo.Value))
                {
                    int statusTo;
                    if (!int.TryParse(stbStatusTo.Value, out statusTo))
                        throw new Exception("Статус по повинен бути числом.");
                    else
                        searchParams.StatusTo = statusTo;
                }


                var periodFrom = dtpPeriodFrom.Checked ? dtpPeriodFrom.Value.Date : (DateTime?)null;
                var periodTo = dtpPeriodTo.Checked ? dtpPeriodTo.Value.Date : (DateTime?)null;
                if (periodFrom.HasValue && periodTo.HasValue && periodFrom > periodTo)
                    throw new Exception("Початковий період не повинен перевищувати\nкінцевий.");

                searchParams.PeriodFrom = periodFrom;
                searchParams.PeriodTo = periodTo;

                if (!string.IsNullOrEmpty(tbInvoiceNumber.Text))
                {
                    if (string.IsNullOrEmpty(stbInvoiceType.Value))
                        throw new Exception("Тип накладної повинен бути вказаний.");
                    else
                        searchParams.InvoiceType = stbInvoiceType.Value;

                    if (!string.IsNullOrEmpty(tbInvoiceNumber.Text))
                    {
                        long invoiceNumber;
                        if (!long.TryParse(tbInvoiceNumber.Text, out invoiceNumber))
                            throw new Exception("№ накладної повинен бути числом.");
                        else
                            searchParams.InvoiceNumber = invoiceNumber;
                    }
                }

                if (!string.IsNullOrEmpty(tbBarCode.Text))
                    searchParams.BarCode = tbBarCode.Text;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvRegistry.DataView.FillData(e.Argument as ArchiveInvoicesRegisterSearchParameters);
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
                        this.xdgvRegistry.BindData(false);

                        //this.xdgvRegistry.AllowFilter = true;
                        this.xdgvRegistry.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Виконується завантаження реєстру..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Експорт реєстра архівних документів";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-реєстр архівних документів",
                    now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'),
                    now.Day.ToString().PadLeft(2, '0'),
                    now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'),
                    now.Second.ToString().PadLeft(2, '0')
                    );

                dlgSelectFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSelectFile.Filter = "Текстовий файл с роздільником (*.csv)|*.csv";//;*.csv|Все файлы (*.*)|*.*";
                dlgSelectFile.FilterIndex = 0;
                dlgSelectFile.AddExtension = true;
                dlgSelectFile.DefaultExt = "csv";
                if (dlgSelectFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.xdgvRegistry.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }
            }
        }

        private void btnChangeWorkMode_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;

            this.WindowState = FormWindowState.Minimized;
            this.Close();
        }

        private void btnPrintBoxEtic_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgArchiveInvoicesRegisterPrintBoxEtic = new ArchiveInvoicesRegisterPrintBoxEticForm() { UserID = this.UserID };
                if (dlgArchiveInvoicesRegisterPrintBoxEtic.ShowDialog() == DialogResult.OK)
                {
                    using (var adapter = new Data.WHTableAdapters.RG_BoxEticsTableAdapter())
                        adapter.Create(this.UserID, dlgArchiveInvoicesRegisterPrintBoxEtic.Count);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnShowBoxEticsStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgArchiveInvoicesRegisterBoxEticsShowStatistics = new ArchiveInvoicesRegisterBoxEticsShowStatisticsForm() { UserID = this.UserID };
                if (dlgArchiveInvoicesRegisterBoxEticsShowStatistics.ShowDialog() == DialogResult.OK)
                { 
                
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPrintRegisterBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                var barcode = this.SelectedRegister.RegisterID.ToString();
                var printerName = (string)null; 

                using (var adapter = new Data.WHTableAdapters.RG_Register_HeadersTableAdapter())
                    adapter.PrintEtic(this.UserID, barcode, printerName);

                MessageBox.Show("Етикетка була відправлена на друк.", "Друк ШК реєстру", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void tbBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(tbBarCode.Text))
                this.ReloadData();
        }

        private void ssbPreviewRegister_ButtonClick(object sender, EventArgs e)
        {
            ssbPreviewRegister.ShowDropDown();
        }

        private void ssbiPreviewRegister_Click(object sender, EventArgs e)
        {
            this.PreviewRegister();
        }

        private void ssbiPreviewRegisterHeader_Click(object sender, EventArgs e)
        {
            this.PreviewRegister(false);
        }

        private void PreviewRegister()
        {
            this.PreviewRegister(true);
        }

        private void PreviewRegister(bool includeDetails)
        {
            try
            {
                ReportClass report = null;
                var registerID = this.SelectedRegister.RegisterID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, ea) =>
                {
                    try
                    {
                        var wH = new Data.WH();

                        using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_HeadersTableAdapter())
                            adapter.Fill(wH.AI_RegisterDocs_Headers, this.UserID, registerID);

                        if (includeDetails)
                        {
                            using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_DetailsTableAdapter())
                                adapter.Fill(wH.AI_RegisterDocs_Details, this.UserID, registerID);
                        }
                        else
                        {
                            wH.AI_RegisterDocs_Headers.LoadDataRow(wH.AI_RegisterDocs_Headers[0].ItemArray, true);
                            wH.AI_RegisterDocs_Headers[1].Number = 2;
                        }

                        report = includeDetails ? (ReportClass)new WMSOffice.Reports.ArchiveInvoiceRegisterReport() : new WMSOffice.Reports.ArchiveInvoiceRegisterHeaderReport();
                        report.SetDataSource(wH);
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, ea) =>
                {
                    try
                    {
                        splashForm.CloseForce();

                        if (ea.Result is Exception)
                            throw (ea.Result as Exception);

                        using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                        {
                            form.Text = string.Format("Реєстр архівних документів № {0}", registerID);

                            form.ReportDocument = report;
                            form.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                };

                splashForm.ActionText = "Виконується побудова реєстру..";
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCreateRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgArchivedInvoicesRegisterCreate = new ArchivedInvoicesRegisterCreateForm() { UserID = this.UserID };
                if (dlgArchivedInvoicesRegisterCreate.ShowDialog() == DialogResult.OK)
                {
                    var createParams = dlgArchivedInvoicesRegisterCreate.CreateParameters;


                    stbDocType.SetValueByDefault(createParams.RegisterType.Value.ToString());

                    stbDebtorFrom.SetValueByDefault(createParams.DebtorFrom.Value.ToString());
                    stbDebtorTo.SetValueByDefault(createParams.DebtorTo.Value.ToString());

                    stbStatusFrom.SetValueByDefault(string.Empty);
                    stbStatusTo.SetValueByDefault(string.Empty);

                    dtpPeriodFrom.Value = createParams.PeriodFrom.Value;
                    dtpPeriodFrom.Checked = true;

                    dtpPeriodTo.Value = createParams.PeriodTo.Value;
                    dtpPeriodTo.Checked = true;

                    stbInvoiceType.SetValueByDefault(string.Empty);
                    tbInvoiceNumber.Text = string.Empty;
                    tbBarCode.Text = string.Empty;


                    var registryID = (long?)null;
                    using (var adapter = new Data.WHTableAdapters.RG_Register_HeadersTableAdapter())
                        adapter.CreateRegister(
                            this.UserID,
                            Convert.ToInt32(this.WorkMode), 
                            createParams.RegisterType, 
                            createParams.DebtorFrom, 
                            createParams.DebtorTo, 
                            createParams.PeriodFrom, 
                            createParams.PeriodTo, 
                            ref registryID);

                    xdgvRegistry.ApplyFilter("RegisterID", registryID.ToString());

                    MessageBox.Show(string.Format("Створено реєстр № {0}.", registryID), "Створення реєстру завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.ReloadData();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCreateUtilizationSettings_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgArchivedInvoicesRegisterUtilization = new ArchivedInvoicesRegisterUtilizationForm() { UserID = this.UserID };
                if (dlgArchivedInvoicesRegisterUtilization.ShowDialog() == DialogResult.OK)
                { 
                
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    public enum ArchiveInvoicesRegisterWorkMode
    {
        /// <summary>
        /// Текущий реестр
        /// </summary>
        Current = 1,

        /// <summary>
        /// Устаревший реестр
        /// </summary>
        Obsolete = 2
    }

    /// <summary>
    /// Представление для реестра архивных накладных
    /// </summary>
    public class ArchiveInvoicesRegisterView : IDataView
    {
        public ArchiveInvoicesRegisterWorkMode WorkMode { get; set; }

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
            var searchCriteria = searchParameters as ArchiveInvoicesRegisterSearchParameters;

            switch (this.WorkMode)
            {
                case ArchiveInvoicesRegisterWorkMode.Current:
                case ArchiveInvoicesRegisterWorkMode.Obsolete:
                using (var adapter = new Data.WHTableAdapters.RG_Register_HeadersTableAdapter())
                {
                    adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                    this.data = adapter.GetData(
                        searchCriteria.SessionID,
                        Convert.ToInt32(this.WorkMode),
                        searchCriteria.RegisterType,
                        searchCriteria.DebtorFrom,
                        searchCriteria.DebtorTo,
                        searchCriteria.StatusFrom,
                        searchCriteria.StatusTo,
                        searchCriteria.PeriodFrom,
                        searchCriteria.PeriodTo,
                        searchCriteria.InvoiceNumber,
                        searchCriteria.InvoiceType,
                        searchCriteria.BarCode);
                }
                break;

                default:
                break;
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public ArchiveInvoicesRegisterView(ArchiveInvoicesRegisterWorkMode workMode)
        {
            switch (this.WorkMode = workMode)
            {
                case ArchiveInvoicesRegisterWorkMode.Current:
                case ArchiveInvoicesRegisterWorkMode.Obsolete:

                    this.dataColumns.Add(new PatternColumn("№ реєстру", "RegisterID", new FilterCompareExpressionRule<Int64>("RegisterID"), SummaryCalculationType.TotalRecords) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Дата реєстру", "RegisterDate", new FilterDateCompareExpressionRule("RegisterDate")) { Width = 110 });
                    this.dataColumns.Add(new PatternColumn("Тип реєстру", "TypeDesc", new FilterPatternExpressionRule("TypeDesc")) { Width = 100 });

                    this.dataColumns.Add(new PatternColumn("Філіал", "Filial", new FilterPatternExpressionRule("Filial"), SummaryCalculationType.Count) { Width = 150 });

                    this.dataColumns.Add(new PatternColumn("Період з", "Period_From", new FilterDateCompareExpressionRule("Period_From")) { Width = 90 });
                    this.dataColumns.Add(new PatternColumn("Період по", "Period_To", new FilterDateCompareExpressionRule("Period_To")) { Width = 90 });

                    this.dataColumns.Add(new PatternColumn("Дебітор з", "Debtor_From", new FilterCompareExpressionRule<Int32>("Debtor_From"), SummaryCalculationType.Count) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Дебітор по", "Debtor_To", new FilterCompareExpressionRule<Int32>("Debtor_To"), SummaryCalculationType.Count) { Width = 100 });

                    this.dataColumns.Add(new PatternColumn("Код статусу", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Назва статусу", "Status_Name", new FilterPatternExpressionRule("Status_Name")) { Width = 150 });

                    break;

                default:
                    break;
            }
        #endregion
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ArchiveInvoicesRegisterSearchParameters : SessionIDSearchParameters
    {
        public int? RegisterType { get; set; }
        public int? DebtorFrom { get; set; }
        public int? DebtorTo { get; set; }
        public int? StatusFrom { get; set; }
        public int? StatusTo { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string InvoiceType { get; set; }
        public long? InvoiceNumber { get; set; }
        public string BarCode { get; set; }

        public ArchiveInvoicesRegisterSearchParameters()
        {
            this.InvoiceType = (string)null;
            this.BarCode = (string)null;
        }
    }
}
