using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WMSOffice.Controls;
using WMSOffice.Controls.Custom;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Window
{
    public partial class EDocRegistryWindow : GeneralWindow
    {
        private readonly Regex rgxReceiptMessagePattern = new Regex(@"^.*Дата документа: \d{2}\.\d{2}\.\d{4}(?<rcpr>.*)$", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private int? selectedDocID = (int?)null;

        //public Data.PrintNakl.EN_DocsRow SelectedDoc { get { return xdgvDocs.SelectedItem == null ? null : xdgvDocs.SelectedItem as Data.PrintNakl.EN_DocsRow; } }
        public Data.PrintNakl.EN_DocStatesRow SelectedDocState { get { return dgvDocDetail.SelectedRows.Count == 0 ? null : (dgvDocDetail.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PrintNakl.EN_DocStatesRow; } }

        public EDocRegistryView SelectedDataView { get { return xdgvDocs.DataView as EDocRegistryView; } }
        public EDocRegistryViewRow SelectedItem { get { return this.SelectedDataView.ConvertRow(xdgvDocs.SelectedItem); } }

        public bool CanCancelDoc { get; private set; }
        public bool CanResendDoc { get; private set; }
        public bool CanPrintDocPack { get; private set; }
        public bool CanAcceptDoc { get; private set; }
        public bool CanDeclineDoc { get; private set; }
        public bool CanCheckDocState { get; private set; }
        public bool CanSignWaybill { get; private set; }
        public bool CanCreateWaybillAct { get; private set; }

        /// <summary>
        /// Режим работы с интерфейсом 
        /// </summary>
        public string WorkModeKey { get; set; }
        public string WorkModeValue { get; set; }

        /// <summary>
        /// Режим работы с реестром EN 
        /// </summary>
        public bool EN_WorkMode { get { return this.WorkModeKey.Equals("EN", StringComparison.OrdinalIgnoreCase); } }

        public EDocRegistryWindow()
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
                var workModes = new Data.PrintNakl.EN_WorkModesDataTable();
                using (var adapter = new Data.PrintNaklTableAdapters.EN_WorkModesTableAdapter())
                    adapter.Fill(workModes, this.UserID);

                if (workModes.Rows.Count == 0)
                    throw new Exception("У Вас нет доступа к интерфейсу работы с реестром электронных документов.");

                if (workModes.Rows.Count == 1)
                {
                    this.WorkModeKey = workModes[0].Entity_Key;
                    this.WorkModeValue = workModes[0].Entity_Value;
                    return true;
                }
                else
                {
                    var dlgSelectWorkMode = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectWorkMode.Text = "Выберите режим работы";
                    dlgSelectWorkMode.AddColumn("Entity_Value", "Entity_Value", "Режим работы");
                    dlgSelectWorkMode.FilterChangeLevel = 0;
                    dlgSelectWorkMode.FilterVisible = false;

                    dlgSelectWorkMode.DataSource = workModes;

                    if (dlgSelectWorkMode.ShowDialog() != DialogResult.OK)
                        return false;

                    var workMode = dlgSelectWorkMode.SelectedRow as Data.PrintNakl.EN_WorkModesRow;
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

            this.ShowExtraSearchParameters(false);
            if (!this.EN_WorkMode)
            {
                lblDebtor.Text = "Контрагент:";
                cbUseExtraSearch.Enabled = false;
            }

            stbEDocType.ValueReferenceQuery = "[dbo].[pr_EN_WMS_Get_Doc_Types_Dic]";
            stbEDocType.UserID = this.UserID;
            stbEDocType.ApplyAdditionalParameter(this.WorkModeKey);
            stbEDocType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);


            stbDebtor.ValueReferenceQuery = "[dbo].[pr_EN_WMS_Get_Doc_Debtors_Dic]";
            stbDebtor.UserID = this.UserID;
            stbDebtor.ApplyAdditionalParameter(this.WorkModeKey);
            stbDebtor.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);


            stbEDocStateFrom.ValueReferenceQuery = "[dbo].[pr_EN_WMS_Get_Doc_States_Dic]";
            stbEDocStateFrom.UserID = this.UserID;
            stbEDocStateFrom.ApplyAdditionalParameter(this.WorkModeKey);
            stbEDocStateFrom.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
            stbEDocStateFrom.SetFirstValueByDefault();


            stbEDocStateTo.ValueReferenceQuery = "[dbo].[pr_EN_WMS_Get_Doc_States_Dic]";
            stbEDocStateTo.UserID = this.UserID;
            stbEDocStateTo.ApplyAdditionalParameter(this.WorkModeKey);
            stbEDocStateTo.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
            if (this.EN_WorkMode)
                stbEDocStateTo.SetValueByDefault(((int)ENDocRegistryView.ENDocState.CancellationRequested).ToString());
            else
                stbEDocStateTo.SetValueByDefault(((int)EDDocRegistryView.EDDocState.SendDocResultReceiptIncludePDF).ToString());


            stbDocType.ValueReferenceQuery = "[dbo].[pr_EN_WMS_Get_DCT_Dic]";
            stbDocType.AddReference(stbEDocType, "Value");
            stbDocType.UserID = this.UserID;
            stbDocType.ApplyAdditionalParameter(this.WorkModeKey);
            stbDocType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);


            var today = DateTime.Today.Date;
            dtpPeriodFrom.Value = today.AddMonths(-1);
            dtpPeriodTo.Value = today.AddMonths(1);


            xdgvDocs.AllowSummary = false;
            xdgvDocs.AllowRangeColumns = true;

            xdgvDocs.Init(EDocRegistryView.Create(this.EN_WorkMode), true);
            //xdgvDocs.Init(new EDocRegistryView(this.EN_WorkMode), true);
            xdgvDocs.LoadExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, this.SelectedDataView.GetType().Name));
            xdgvDocs.UserID = this.UserID;

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocs.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvDocs_OnDataBindingComplete);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);

            xdgvDocs.SetSameStyleForAlternativeRows();

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            this.CheckOperationsAccess();

            this.SetOperationAccess(true);
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbEDocType)
                lblDescription = tbEDocType;
            else if (control == stbDebtor)
                lblDescription = tbDebtor;
            else if (control == stbEDocStateFrom)
                lblDescription = tbEDocStateFrom;
            else if (control == stbEDocStateTo)
                lblDescription = tbEDocStateTo;
            else if (control == stbDocType)
                lblDescription = tbDocType;

            if (lblDescription != null)
            {
                // Сбрасываем значение типа документа при смене типа е-документа
                if (control == stbEDocType)
                    if (e.Success)
                        stbDocType.SetValueByDefault(string.Empty);

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

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
            this.ReloadSelectedDocStates();
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvDocs.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        private void CheckOperationsAccess()
        {
            try
            {
                var canCancelDoc = (bool?)null;
                var canResendDoc = (bool?)null;
                var canPrintDocPack = (bool?)null;
                var canApproveDoc = (bool?)null;
                var canDeclineDoc = (bool?)null;
                var canCheckDocState = (bool?)null;
                var canSignWaybill = (bool?)null;
                var canCreateWaybillAct = (bool?)null;

                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocsTableAdapter())
                    adapter.CheckDocOperationsAccess(this.UserID, ref canCancelDoc, ref canResendDoc, ref canPrintDocPack, ref canApproveDoc, ref canDeclineDoc, ref canCheckDocState, ref canSignWaybill, ref canCreateWaybillAct);

                if (this.EN_WorkMode)
                {
                    this.CanCheckDocState = canCheckDocState ?? false;
                    this.CanCancelDoc = canCancelDoc ?? false;
                    this.CanResendDoc = canResendDoc ?? false;
                }
                else
                {
                    this.CanCancelDoc = canCancelDoc ?? false;
                }

                if (this.EN_WorkMode)
                {
                    this.CanPrintDocPack = canPrintDocPack ?? false;
                }

                if (!EN_WorkMode)
                {
                    this.CanAcceptDoc = canApproveDoc ?? false;
                    this.CanDeclineDoc = canDeclineDoc ?? false;
                }

                if (EN_WorkMode)
                {
                    this.CanCreateWaybillAct = canCreateWaybillAct ?? false;
                }
                else
                {
                    this.CanSignWaybill = canSignWaybill ?? false;
                    this.CanCreateWaybillAct = canCreateWaybillAct ?? false;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            var doc = this.SelectedItem;

            if (wholeViewAccess)
            {
                btnPreview.Enabled = xdgvDocs.HasRows && doc.IsPreviewEnabled;
                btnExportToPDF.Enabled = xdgvDocs.HasRows && doc.IsExportToPDFEnabled;
                btnExportToDisk.Enabled = xdgvDocs.HasRows && doc.IsExportToDiskEnabled;

                #region
                btnCheckState.Visible = this.CanCheckDocState;
                btnCheckState.Enabled = xdgvDocs.HasRows && this.CanCheckDocState && doc.IsCheckStateEnabled;

                btnCancel.Visible = this.CanCancelDoc;
                btnCancel.Enabled = xdgvDocs.HasRows && this.CanCancelDoc && doc.IsCancelEnabled;

                btnResend.Visible = this.CanResendDoc;
                btnResend.Enabled = xdgvDocs.HasRows && this.CanResendDoc && doc.IsResendEnabled;

                tssOutgoingDocumentActions.Visible = btnCancel.Visible || btnResend.Visible;
                #endregion

                #region
                btnAccept.Visible = this.CanAcceptDoc;
                btnAccept.Enabled = xdgvDocs.HasRows && this.CanAcceptDoc && doc.IsAcceptEnabled;

                btnDecline.Visible = this.CanDeclineDoc;
                btnDecline.Enabled = xdgvDocs.HasRows && this.CanDeclineDoc && doc.IsDeclineEnabled;

                tssIncomeDocumentActions.Visible = btnAccept.Visible || btnDecline.Visible;
                #endregion

                #region
                btnSignWaybill.Visible = this.CanSignWaybill;
                btnSignWaybill.Enabled = xdgvDocs.HasRows && this.CanSignWaybill && doc.IsSignWaybillEnabled;

                btnCreateWaybillAct.Visible = this.CanCreateWaybillAct;
                btnCreateWaybillAct.Enabled = xdgvDocs.HasRows && this.CanCreateWaybillAct && doc.IsCreateWaybillActEnabled;

                tssWaybillActions.Visible = btnSignWaybill.Visible || btnCreateWaybillAct.Visible;
                #endregion

                btnExportArchive.Visible = tssExportArchive.Visible = this.CanPrintDocPack;
                btnExportArchive.Enabled = xdgvDocs.HasRows /*&& xdgvDocs.HasFilter*/ && this.CanPrintDocPack;

                btnExportRegistryToExcel.Enabled = xdgvDocs.HasRows;
            }
            else
            {
                btnPreview.Enabled = doc.IsPreviewEnabled;
                btnExportToPDF.Enabled = doc.IsExportToPDFEnabled;
                btnExportToDisk.Enabled = doc.IsExportToDiskEnabled;

                #region
                btnCheckState.Visible = this.CanCheckDocState;
                btnCheckState.Enabled = this.CanCheckDocState && doc.IsCheckStateEnabled;

                btnCancel.Visible = this.CanCancelDoc;
                btnCancel.Enabled = this.CanCancelDoc && doc.IsCancelEnabled;

                btnResend.Visible = this.CanResendDoc;
                btnResend.Enabled = this.CanResendDoc && doc.IsResendEnabled;

                tssOutgoingDocumentActions.Visible = btnCancel.Visible || btnResend.Visible;
                #endregion

                #region
                btnAccept.Visible = this.CanAcceptDoc;
                btnAccept.Enabled = this.CanAcceptDoc && doc.IsAcceptEnabled;

                btnDecline.Visible = this.CanDeclineDoc;
                btnDecline.Enabled = this.CanDeclineDoc && doc.IsDeclineEnabled;

                tssIncomeDocumentActions.Visible = btnAccept.Visible || btnDecline.Visible;
                #endregion

                #region
                btnSignWaybill.Visible = this.CanSignWaybill;
                btnSignWaybill.Enabled = this.CanSignWaybill && doc.IsSignWaybillEnabled;

                btnCreateWaybillAct.Visible = this.CanCreateWaybillAct;
                btnCreateWaybillAct.Enabled = this.CanCreateWaybillAct && doc.IsCreateWaybillActEnabled;

                tssWaybillActions.Visible = btnSignWaybill.Visible || btnCreateWaybillAct.Visible;
                #endregion

                btnExportArchive.Visible = tssExportArchive.Visible = this.CanPrintDocPack;
                btnExportArchive.Enabled = xdgvDocs.HasRows /*&& xdgvDocs.HasFilter*/ && this.CanPrintDocPack;

                btnExportRegistryToExcel.Enabled = xdgvDocs.HasRows;
            }
        }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        void xdgvDocs_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvDocs.DataGrid.Rows)
            {
                var boundRow = (xdgvDocs.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row;

                foreach (DataGridViewColumn column in xdgvDocs.DataGrid.Columns)
                {
                    #region ПОДСТАНОВКА ИКОНОК ПО НАЛИЧИЮ ВЛОЖЕНИЙ

                    if (column is DataGridViewImageColumn)
                    {
                        if (column.Tag != null)
                        {
                            string linkedFieldName = column.Tag.ToString();
                            if (linkedFieldName == "Has_Attachment")
                            {
                                //var stateID = Convert.ToByte(boundRow["State_ID"]);
                                //var hasAttachment = stateID >= 120;

                                var hasAttachment = boundRow.Table.Columns.Contains("Has_Attachment") && Convert.ToBoolean(boundRow["Has_Attachment"]);

                                if (hasAttachment)
                                {
                                    var hasArchiveAttachment = boundRow.Table.Columns.Contains("Export_DTTM") && !boundRow["Export_DTTM"].Equals(DBNull.Value);

                                    if (hasArchiveAttachment)
                                        xdgvDocs.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.pin_yellow; 
                                    else
                                        xdgvDocs.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.pin_red;
                                }
                                else
                                    xdgvDocs.DataGrid.Rows[row.Index].Cells[column.Index].Value = emptyIcon;
                            }
                        }
                    }

                    #endregion
                }
            }

            // Восстанавливаем фокус
            if (selectedDocID.HasValue)
            {
                xdgvDocs.SelectRow("Doc_ID", selectedDocID.ToString());
                xdgvDocs.ScrollToSelectedRow();
            }
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (xdgvDocs.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ СТАТУСОВ

            var color = Color.Empty;

            var stateID = Convert.ToByte(boundRow["State_ID"]);
            var docAmount = Convert.ToDecimal(boundRow["DocAmountWithVAT"]);

            stateID = docAmount.Equals(0.00M) ? (byte)ENDocRegistryView.ENDocState.Canceled : stateID; // переопределим статус индикации для нулевой суммы

            if ((color = this.SelectedDataView.GetDocBackColorByDocRow(boundRow)) != Color.Empty)
            {
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
            }

            #endregion

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ОШИБКИ

            var hasError = boundRow.Table.Columns.Contains("Error_msg") && boundRow["Error_msg"] != DBNull.Value;
            if (hasError)
            {
                color = Color.Red;

                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;

                color = Color.Yellow;
                e.CellStyle.SelectionBackColor = color;
            }

            #endregion
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.ReloadDocs();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            this.ReloadDocs();
        }

        /// <summary>
        /// Загрузка документов с применением фильтра
        /// </summary>
        private void ReloadDocs()
        {
            try
            {
                #region НАСТРОЙКА ПАРАМЕТРОВ ПОИСКА

                var searchParams = new EDocRegistrySearchParameters() { SessionID = this.UserID };

                if (!string.IsNullOrEmpty(stbEDocType.Value))
                {
                    searchParams.EDocType = stbEDocType.Value;
                }

                if (!string.IsNullOrEmpty(stbDebtor.Value))
                {
                    int debtorID;
                    if (!int.TryParse(stbDebtor.Value, out debtorID))
                        throw new Exception("Код дебитора должен быть числом.");
                    else
                        searchParams.DebtorID = debtorID;
                }

                if (!string.IsNullOrEmpty(stbEDocStateFrom.Value))
                {
                    byte stateFromID;
                    if (!byte.TryParse(stbEDocStateFrom.Value, out stateFromID))
                        throw new Exception("Код статуса с должен быть числом.");
                    else
                        searchParams.EDocStateFromID = stateFromID;
                }

                if (!string.IsNullOrEmpty(stbEDocStateTo.Value))
                {
                    byte stateToID;
                    if (!byte.TryParse(stbEDocStateTo.Value, out stateToID))
                        throw new Exception("Код статуса по должен быть числом.");
                    else
                        searchParams.EDocStateToID = stateToID;
                }

                if (dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                    throw new Exception("Начальный период не должен превышать конечный.");
                else
                {
                    searchParams.PeriodFrom = dtpPeriodFrom.Value.Date;
                    searchParams.PeriodTo = dtpPeriodTo.Value.Date;
                }

                var useExtraSearch = cbUseExtraSearch.Checked;
                searchParams.UseExtraSearch = useExtraSearch;

                if (useExtraSearch)
                {
                    if (string.IsNullOrEmpty(stbDocType.Value))
                        throw new Exception("Тип документа должен быть указан.");
                    else
                        searchParams.DocType = stbDocType.Value;

                    if (string.IsNullOrEmpty(tbDocNumber.Text))
                        throw new Exception("№ документа должен быть указан.");
                    else
                    {
                        int docNumber;
                        if (!int.TryParse(tbDocNumber.Text, out docNumber))
                            throw new Exception("№ документа должен быть числом.");
                        else
                            searchParams.DocNumber = docNumber;
                    }
                }

                #endregion

                // Запоминаем фокус
                selectedDocID = this.SelectedItem.DocID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.SelectedDataView.FillData(e.Argument as EDocRegistrySearchParameters);
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

                splashForm.ActionText = "Выполняется получение реестра электронных документов..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Загрузка статусов текущего документа
        /// </summary>
        private void ReloadSelectedDocStates()
        {
            try
            {
                var doc = this.SelectedItem;

                var docID = doc.DocID; 

                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocStatesTableAdapter())
                    adapter.Fill(printNakl.EN_DocStates, this.UserID, docID, this.WorkModeKey);

                // Автоматически выбираем последний (текущий) статус
                if (dgvDocDetail.Rows.Count > 0)
                {
                    dgvDocDetail.Rows[dgvDocDetail.Rows.Count - 1].Selected = true;
                    dgvDocDetail.FirstDisplayedScrollingRowIndex = dgvDocDetail.Rows[dgvDocDetail.Rows.Count - 1].Index;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Preview();
        }

        /// <summary>
        /// Просмотр документа
        /// </summary>
        private void Preview()
        {
            try
            {
                var doc = this.SelectedItem;

                var eDocID = doc.DocID;

                byte[] docBinary = null;

                var docDependentImages = new Data.PrintNakl.EN_Doc_Dependent_ImagesDataTable();
                using (var adapter = new Data.PrintNaklTableAdapters.EN_Doc_Dependent_ImagesTableAdapter())
                    adapter.Fill(docDependentImages, eDocID, this.WorkModeKey);

                var ivcDocument = new WMSOffice.Controls.Custom.ImageViewerControl();
                ivcDocument.CurrentItem = null;

                foreach (Data.PrintNakl.EN_Doc_Dependent_ImagesRow docImageInfo in docDependentImages.Rows)
                {
                    try
                    {
                        docBinary = docImageInfo.Converted_bin;
                        if (docBinary == null)
                            continue;

                        // Выгружаем бинарный PDF во временный файл
                        var tmpFileName = Path.GetTempFileName();
                        File.WriteAllBytes(tmpFileName, docBinary);

                        ivcDocument.Items.Add(new ImageProxy(tmpFileName, ".PDF") { Properties = docImageInfo });
                        ivcDocument.Items[ivcDocument.Items.Count - 1].LoadImage();
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }

                if (ivcDocument.Items.Count == 0)
                    throw new Exception("Отсутствует документ для экспорта.");

                ivcDocument.CurrentItem = ivcDocument.Items.Count > 0 ? ivcDocument.Items[0] : new WMSOffice.Controls.Custom.ImageProxy(Properties.Resources.absentimage);
                var properties = ivcDocument.CurrentItem.Properties as Data.PrintNakl.EN_Doc_Dependent_ImagesRow;
                var fileName = string.Format("{0}-{1} ({2}).PDF", properties.Doc_Type, properties.DOC, properties.DCT);

                #region КОНТЕЙНЕР ДЛЯ КОМПОНЕНТА ПРЕДВАРИТЕЛЬНОГО ПРОСМОТРА

                var dlgPreviewDocument = new Form()
                {
                    Text = string.Format("Просмотр документа {0}", fileName),
                    FormBorderStyle = FormBorderStyle.Sizable
                };
                dlgPreviewDocument.SizeChanged += (s, e) =>
                {
                    if (ivcDocument.AutoZoomActivated)
                        ivcDocument.ChangeZoom();
                };

                ivcDocument.PreviewCurrentItem += (s, e) =>
                {
                    properties = ivcDocument.CurrentItem.Properties as Data.PrintNakl.EN_Doc_Dependent_ImagesRow;
                    fileName = string.Format("{0}-{1} ({2}).PDF", properties.Doc_Type, properties.DOC, properties.DCT);
                    dlgPreviewDocument.Text = string.Format("Просмотр документа {0}", fileName);
                };

                dlgPreviewDocument.Controls.Add(ivcDocument);
                ivcDocument.Dock = DockStyle.Fill;

                var pnlFooter = new Panel();
                pnlFooter.Height = 43;
                dlgPreviewDocument.Controls.Add(pnlFooter);
                pnlFooter.Dock = DockStyle.Bottom;

                var btnClose = new Button()
                {
                    Text = "Закрыть",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(dlgPreviewDocument.Width - 75 - 25, 8),
                    Width = 75,
                    Anchor = AnchorStyles.Right | AnchorStyles.Bottom
                };
                pnlFooter.Controls.Add(btnClose);

                dlgPreviewDocument.CancelButton = btnClose;
                dlgPreviewDocument.WindowState = FormWindowState.Maximized;
                dlgPreviewDocument.ShowDialog(this);

                #endregion

                #region ОСВОБОЖДЕНИЕ ВРЕМЕННЫХ РЕСУРСОВ
                foreach (var item in ivcDocument.Items)
                {
                    try
                    {
                        var tmpFileName = item.FullName;
                        if (File.Exists(tmpFileName))
                            File.Delete(tmpFileName);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            this.ExportToPDF();
        }

        /// <summary>
        /// Экспорт документа в PDF
        /// </summary>
        private void ExportToPDF()
        {
            try
            {
                var doc = this.SelectedItem;

                var eDocID = doc.DocID;

                byte[] docBinary = null;

                var docDependentImages = new Data.PrintNakl.EN_Doc_Dependent_ImagesDataTable();
                using (var adapter = new Data.PrintNaklTableAdapters.EN_Doc_Dependent_ImagesTableAdapter())
                    adapter.Fill(docDependentImages, eDocID, this.WorkModeKey);

                var lstDocImagesInfo = new List<Data.PrintNakl.EN_Doc_Dependent_ImagesRow>();
                foreach (Data.PrintNakl.EN_Doc_Dependent_ImagesRow docImageInfo in docDependentImages.Rows)
                {
                    try
                    {
                        docBinary = docImageInfo.Converted_bin;
                        if (docBinary == null)
                            continue;

                        lstDocImagesInfo.Add(docImageInfo);
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }

                if (lstDocImagesInfo.Count == 0)
                    throw new Exception("Отсутствует документ для экспорта.");

                foreach (Data.PrintNakl.EN_Doc_Dependent_ImagesRow docImageInfo in lstDocImagesInfo)
                {
                    try
                    {
                        var eDocType = docImageInfo.Doc_Type;

                        var docID = docImageInfo.DOC;
                        var docType = docImageInfo.DCT;

                        docBinary = docImageInfo.Converted_bin;
                        var fileName = string.Format("{0}-{1} ({2})", eDocType, docID, docType);

                        using (var dlgSaveToPDF = new SaveFileDialog())
                        {
                            dlgSaveToPDF.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            dlgSaveToPDF.Title = "Экспорт документа";
                            dlgSaveToPDF.Filter = "Документ PDF|*.PDF";
                            dlgSaveToPDF.FileName = fileName;

                            if (dlgSaveToPDF.ShowDialog(this) == DialogResult.OK)
                            {
                                fileName = dlgSaveToPDF.FileName;
                                File.WriteAllBytes(fileName, docBinary);

                                Thread.Sleep(500);
                                Process.Start(dlgSaveToPDF.FileName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExportToDisk_Click(object sender, EventArgs e)
        {
            this.ExportToDisk();
        }

        /// <summary>
        /// Экспорт пакета документов с ЭЦП
        /// </summary>
        private void ExportToDisk()
        {
            try
            {
                var doc = this.SelectedItem;

                var eDocID = doc.DocID;

                var attributes = new Data.PrintNakl.EN_DocAttributesDataTable();
                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocAttributesTableAdapter())
                    adapter.Fill(attributes, this.UserID, eDocID, this.WorkModeKey);

                if (attributes.Count == 0)
                    throw new Exception("Отсутствует пакет документов для экспорта.");

                var attribute = attributes[0];

                var medocFileName = attribute.Doc_Code;
                var medocBody = attribute.MedocBody;

                var receiptFileName = attribute.Receipt_Code;
                var receiptBody = attribute.Receipt_Body;

                var docName = doc.FileName;

                var docFileName = string.Format("{0}.pdf", docName);
                var docBinary = attribute.Doc_Binary;

                var registryFileName = "Пакет документов.txt";
                var sbRegistry = new StringBuilder();
                var cntRegistry = 0;

                using (var dlgSelectFolder = new FolderBrowserDialog())
                {
                    //dlgSelectFolder.RootFolder = System.Environment.SpecialFolder.MyDocuments;
                    dlgSelectFolder.Description = "Экспорт пакета документов";
                    dlgSelectFolder.ShowNewFolderButton = false;

                    if (dlgSelectFolder.ShowDialog() == DialogResult.OK)
                    {
                        var rootFolder = dlgSelectFolder.SelectedPath;
                        var folderName = Path.Combine(rootFolder, docName);

                        #region ПОДГОТОВКА ПАПКИ ДЛЯ ЭКСПОРТА

                        if (!Directory.Exists(folderName))
                            Directory.CreateDirectory(folderName);
                        else
                        {
                            foreach (var fileName in Directory.GetFiles(folderName))
                            {
                                try
                                {
                                    File.Delete(fileName);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }

                        #endregion

                        #region MedocBody
                        sbRegistry.AppendFormat("{0}. MedocBody - документ подписанный обеими сторонами - файл {1}\r\n", ++cntRegistry, medocFileName);
                        medocFileName = Path.Combine(folderName, medocFileName);

                        var medocBodyBase64 = Convert.ToBase64String(medocBody);
                        File.WriteAllText(medocFileName, medocBodyBase64);
                        #endregion

                        #region MedocKvt

                        if (receiptBody.Length > 0)
                        {
                            sbRegistry.AppendFormat("{0}. MedocKvt - квитанция о подтверждении документа - файл {1}\r\n", ++cntRegistry, receiptFileName);
                            receiptFileName = Path.Combine(folderName, receiptFileName);

                            var receiptBodyBase64 = Convert.ToBase64String(receiptBody);
                            File.WriteAllText(receiptFileName, receiptBodyBase64);
                        }
                        #endregion

                        #region PDF
                        sbRegistry.AppendFormat("{0}. PDF - визуализация подписанного документа - файл {1}\r\n", ++cntRegistry, docFileName);
                        docFileName = Path.Combine(folderName, docFileName);
                        File.WriteAllBytes(docFileName, docBinary);
                        #endregion

                        #region Registry
                        registryFileName = Path.Combine(folderName, registryFileName);
                        File.WriteAllText(registryFileName, sbRegistry.ToString());
                        #endregion

                        Thread.Sleep(500);
                        Process.Start(folderName);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvDocDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var lstImages = new List<Image>();

            foreach (DataGridViewRow row in dgvDocDetail.Rows)
            {
                var docState = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.EN_DocStatesRow;

                lstImages.Clear();

                foreach (DataGridViewColumn column in xdgvDocs.DataGrid.Columns)
                {
                    if (column is DataGridViewImageColumn)
                    {
                        #region ПОДСТАНОВКА ИКОНКИ НАЛИЧИЯ КВИТАНЦИИ

                        var haveReceipt = docState.IsHaveReceiptNull() ? false : docState.HaveReceipt;

                        if (haveReceipt)
                            lstImages.Add(Properties.Resources.accept_16);

                        #endregion

                        #region ПОДСТАНОВКА ИКОНКИ НАЛИЧИЯ PDF
                        
                        var havePDF = docState.IsHavePDFNull() ? false : docState.HavePDF;

                        if (havePDF)
                            lstImages.Add(Properties.Resources.pin_red);

                        #endregion

                        if (lstImages.Count > 0)
                            row.Cells[column.Index].Value = this.GetMergedImage(lstImages);
                        else
                            row.Cells[column.Index].Value = emptyIcon;
                    }
                }
            }
        }

        private Image GetMergedImage(List<Image> images)
        {
            System.Drawing.Bitmap finalImage = null;

            try
            {
                var width = 0;
                var height = 0;

                var margin = 3;

                foreach (var img in images)
                {
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(img);

                    width += bitmap.Width;
                    height = bitmap.Height > height ? bitmap.Height : height;
                }

                width += margin * images.Count - 1;

                finalImage = new System.Drawing.Bitmap(width, height);
                using (System.Drawing.Graphics canvas = System.Drawing.Graphics.FromImage(finalImage))
                {
                    canvas.Clear(System.Drawing.Color.Transparent);
                    canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    int offset = 0;
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        canvas.DrawImage(image, new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width + margin;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                return emptyIcon;
            }
        }

        private void dgvDocDetail_SelectionChanged(object sender, EventArgs e)
        {
            this.ReloadCurrentDocStateReceipt();
        }

        /// <summary>
        /// Загрузка квитанции по статусу текущего документа
        /// </summary>
        private void ReloadCurrentDocStateReceipt()
        {
            try
            {
                var docID = this.SelectedItem.DocID;
                var stateID = this.SelectedDocState == null ? (byte?)null : this.SelectedDocState.State_ID;
                var haveReceipt = this.SelectedDocState == null ? false : (this.SelectedDocState.IsHaveReceiptNull() ? false : this.SelectedDocState.HaveReceipt);
                
                var receipt = (string)null;
                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocStatesTableAdapter())
                    adapter.GetDocStateReceipt(docID, stateID, ref receipt, this.WorkModeKey);

                receipt = receipt ?? string.Empty;
                rtbReceipt.Clear();

                rtbReceipt.Text = receipt; // rtbReceipt.SelectedText = receipt; -> TODO Убрано звуковое сопровождение

                if (rgxReceiptMessagePattern.IsMatch(receipt))
                {
                    var match = rgxReceiptMessagePattern.Match(receipt);
                    var receiptResult = match.Groups["rcpr"].Value;

                    receipt = receipt.Replace(receiptResult, string.Empty);
                    rtbReceipt.Clear();
                    rtbReceipt.SelectedText = receipt;

                    Font font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
                    rtbReceipt.SelectionFont = font;
                    rtbReceipt.SelectionColor = this.SelectedDataView.GetReceiptResultForeColorByDocStateRow(this.SelectedDocState);
                    rtbReceipt.SelectedText = receiptResult;
                }

                rtbReceipt.BackColor = haveReceipt ? this.SelectedDataView.GetDocBackColorByDocStateRow(this.SelectedDocState) : SystemColors.Control;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void cbUseExtraSearch_CheckedChanged(object sender, EventArgs e)
        {
            ShowExtraSearchParameters(cbUseExtraSearch.Checked);
        }

        private void lblUseExtraSearch_Click(object sender, EventArgs e)
        {
            if (cbUseExtraSearch.Enabled)
                cbUseExtraSearch.Checked = !cbUseExtraSearch.Checked;
        }

        private void ShowExtraSearchParameters(bool visible)
        {
            if (pnlExtraSearch.Visible == visible)
                return;

            pnlExtraSearch.Visible = visible;

            if (visible)
            {
                pnlSearch.Height += pnlExtraSearch.Height;
                this.SelectNextControl(cbUseExtraSearch, true, true, true, false);
            }
            else
            {
                pnlSearch.Height -= pnlExtraSearch.Height;
            }

            // Очищаем дополнительные параметры поиска
            stbDocType.SetValueByDefault(string.Empty);
            tbDocNumber.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        /// <summary>
        /// Отозвать документ
        /// </summary>
        private void Cancel()
        {
            try
            {
                if (!EN_WorkMode)
                {
                    MessageBox.Show("Функционал находится на этапе разработки.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var doc = this.SelectedItem;

                var eDocID = doc.DocID;
                var stateID = doc.StateID;
                var isSended = this.EN_WorkMode && (ENDocRegistryView.ENDocState)stateID == ENDocRegistryView.ENDocState.Sent;

                var cancelMessage = isSended 
                    ? "Выбранный документ будет аннулирован,\r\nпосле чего сразу станет доступна печать оригинала." 
                    : "Выбранный документ будут аннулирован сразу\r\nпосле подписания клиентом акта аннулирования.";

                if (MessageBox.Show(string.Format("{0}\r\n\r\nПродолжить?", cancelMessage), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;

                var needComplaint = false;

                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocsTableAdapter())
                    adapter.CreateCancellationDoc(eDocID, this.UserID, this.WorkModeKey, needComplaint);

                this.ReloadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExportRegistryToExcel_Click(object sender, EventArgs e)
        {
            this.ExportRegistryToExcel();
        }

        private void ExportRegistryToExcel()
        {
            try
            {
                xdgvDocs.ExportToExcel("Экспорт реестра ЭД в Excel", string.Format("реестр ЭД ({0})", this.EN_WorkMode ? "исходящие" : "входящие"), true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnResend_Click(object sender, EventArgs e)
        {
            this.ResendDoc();
        }

        /// <summary>
        /// Повторная отправка документа
        /// </summary>
        private void ResendDoc()
        {
            try
            {
                if (MessageBox.Show("Вы действительно решили отправить повторно\r\nвыбранный документ?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;

                var doc = this.SelectedItem;

                var eDocID = doc.DocID;

                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocsTableAdapter())
                    adapter.ResendDoc(this.UserID, eDocID, this.WorkModeKey);

                this.ReloadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void EDocRegistryWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.SelectedDataView != null)
                xdgvDocs.SaveExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, this.SelectedDataView.GetType().Name));
        }

        private void btnExportArchive_Click(object sender, EventArgs e)
        {
            this.ExportArchive();
        }

        /// <summary>
        /// Экспорт архива документов
        /// </summary>
        private void ExportArchive()
        {
            var success = false;

            try
            {
                var docsToExport = this.SelectedDataView.Data.DefaultView.ToTable().Select("[State_ID] IN (190, 199) AND [Doc_Type] NOT IN ('ANU')", "Doc_ID");
                if (docsToExport.Length > 0)
                {
                    var docsLimit = 1000;
                    var message = docsToExport.Length > docsLimit
                        ? string.Format("Необходимые документы найдены в количестве {0} шт.\r\nРазрешен экспорт не более {1} документов за раз.\r\n\r\nНачать экспорт архива первых {1} документов?", docsToExport.Length, docsLimit)
                        : string.Format("Необходимые документы найдены в количестве {0} шт.\r\nНачать экспорт архива документов?", docsToExport.Length);

                    if (MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        #region ИСПОЛЬЗОВАНИЕ КОМПОНЕНТА ДЛЯ МУЛЬТИВЫБОРА ЭКСПОРТИРУЕМЫХ ДОКУМЕНТОВ

                        var dtDocsToExport = this.SelectedDataView.Data.Clone();
                        foreach (var docToExport in docsToExport)
                        {
                            dtDocsToExport.ImportRow(docToExport);
                            if (dtDocsToExport.Rows.Count > docsLimit - 1)
                                break;
                        }
                        dtDocsToExport.DefaultView.Sort = "Doc_ID";

                        var viewExport = new WMSOffice.Window.ENDocRegistryView(dtDocsToExport, true);
                        var dlgSelector = new WMSOffice.Controls.ExtraDataGridViewRowsSelector(viewExport) { NeedCreatePageNavigator = true, SettingsName = "EDocRegistryWindow_ENDocRegistryView", KeyName = "Doc_ID" };
                        if (dlgSelector.ShowDialog(this) != DialogResult.OK)
                            return;

                        docsToExport = dlgSelector.SelectedRows;

                        #endregion

                        using (var dlgSelectFolder = new FolderBrowserDialog())
                        {
                            //dlgSelectFolder.RootFolder = System.Environment.SpecialFolder.MyDocuments;
                            dlgSelectFolder.Description = "Экспорт архива документов";
                            dlgSelectFolder.ShowNewFolderButton = true;

                            if (dlgSelectFolder.ShowDialog() == DialogResult.OK)
                            {
                                var rootFolder = dlgSelectFolder.SelectedPath;
                                var archiveEventDate = DateTime.Now.ToString("yyyyMMdd-HHmm");
                                var folderName = Path.Combine(rootFolder, archiveEventDate);

                                #region ПОДГОТОВКА ПАПКИ ДЛЯ ЭКСПОРТА

                                if (!Directory.Exists(folderName))
                                    Directory.CreateDirectory(folderName);

                                #endregion

                                var cntDocs = Math.Min(docsToExport.Length, docsLimit);

                                var exportWorker = new BackgroundWorker();
                                exportWorker.DoWork += (s, e) =>
                                {
                                    try
                                    {
                                        for (int idxDoc = 0; idxDoc < cntDocs; idxDoc++)
                                        {
                                            try
                                            {
                                                var eDocID = Convert.ToInt32(docsToExport[idxDoc]["Doc_ID"]);

                                                var attributes = new Data.PrintNakl.EN_DocAttributesDataTable();
                                                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocAttributesTableAdapter())
                                                    adapter.Fill(attributes, this.UserID, eDocID, this.WorkModeKey);

                                                if (attributes.Count == 0)
                                                    throw new Exception("Отсутствует документ для экспорта.");

                                                var attribute = attributes[0];

                                                var docBinary = attribute.Doc_Binary;
                                                var docFileName = attribute.File_Name;

                                                docFileName = Path.Combine(folderName, docFileName);
                                                File.WriteAllBytes(docFileName, docBinary);

                                                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocsTableAdapter())
                                                    adapter.CompleteDocExport(this.UserID, eDocID);

                                                var cntCompletedDocs = idxDoc + 1;
                                                this.ThreadSafeDelegate(() =>
                                                {
                                                    splashForm.ActionText = string.Format("Выполняется экспорт архива..\r\nОбработано документов: {0} из {1}.", cntCompletedDocs, cntDocs);
                                                });
                                            }
                                            catch (Exception ex)
                                            {
                                                throw ex;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        e.Result = ex;
                                    }
                                };
                                exportWorker.RunWorkerCompleted += (s, e) =>
                                {
                                    splashForm.CloseForce();

                                    if (e.Result is Exception)
                                        this.ShowError(e.Result as Exception);
                                    else
                                    {
                                        Thread.Sleep(500);
                                        Process.Start(folderName);

                                        success = true;
                                    }
                                };

                                splashForm.ActionText = string.Format("Выполняется экспорт архива..");
                                exportWorker.RunWorkerAsync();
                                splashForm.ShowDialog();
                            }
                        }
                    }
                }
                else
                    throw new Exception("Отсутствуют необходимые документы для экспорта архива.");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                if (success)
                    this.ReloadDocs();
            }
        }

        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.AcceptDoc();
        }

        private void AcceptDoc()
        {
            try
            {
                var doc = this.SelectedItem;

                var eDocID = doc.DocID;

                using (var adapter = new Data.PrintNaklTableAdapters.ED_DocsTableAdapter())
                    adapter.AcceptDoc(this.UserID, eDocID);

                this.ReloadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            this.DeclineDoc();       
        }

        private void DeclineDoc()
        {
            try
            {
                if (MessageBox.Show("Вы действительно решили отклонить\r\nвыбранный документ?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;

                var form = new EnterStringValueForm("Отклонение документа", "Укажите причину отклонения выбранного документа:", string.Empty) { AllowEmptyValue = false };
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var reason = form.Value;

                    var doc = this.SelectedItem;

                    var eDocID = doc.DocID;

                    using (var adapter = new Data.PrintNaklTableAdapters.ED_DocsTableAdapter())
                        adapter.DeclineDoc(this.UserID, eDocID, reason);

                    this.ReloadDocs();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnChangeView_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;

            this.WindowState = FormWindowState.Minimized;
            this.Close();
        }

        private void btnCheckState_Click(object sender, EventArgs e)
        {
            this.CheckDocState();
        }

        private void CheckDocState()
        {
            try
            {
                var doc = this.SelectedItem;

                var eDocID = doc.DocID;

                using (var adapter = new Data.PrintNaklTableAdapters.EN_DocsTableAdapter())
                    adapter.CheckDoc(this.UserID, eDocID);

                foreach (DataGridViewColumn column in xdgvDocs.DataGrid.Columns)
                {
                    xdgvDocs.DataGrid.Rows[xdgvDocs.DataGrid.CurrentRow.Index].Cells[column.Index].Style.ForeColor = Color.DarkGreen;
                    xdgvDocs.DataGrid.Rows[xdgvDocs.DataGrid.CurrentRow.Index].Cells[column.Index].Style.SelectionBackColor = Color.DarkGreen;
                }

                //this.ReloadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnSignWaybill_Click(object sender, EventArgs e)
        {
            this.SignWaybill();
        }

        private void SignWaybill()
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCreateWaybillAct_Click(object sender, EventArgs e)
        {
            this.CreateWaybillAct();
        }

        private void CreateWaybillAct()
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

    /// <summary>
    /// Представление для реестра электронных документов
    /// </summary>
    public abstract class EDocRegistryView : IDataView
    {
        public bool EN_WorkMode { get; set; }

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        protected PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        protected DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        public abstract void FillData(SearchParametersBase searchParameters);
        protected abstract void Initialize(bool shortView);

        public abstract EDocRegistryViewRow ConvertRow(DataRow row);

        public abstract Color GetDocBackColorByDocRow(DataRow row);

        public abstract Color GetDocBackColorByDocStateRow(Data.PrintNakl.EN_DocStatesRow row);

        public abstract Color GetReceiptResultForeColorByDocStateRow(Data.PrintNakl.EN_DocStatesRow row);

        public static EDocRegistryView Create(bool en_WorkMode)
        {
            switch (en_WorkMode)
            {
                case true:
                    return new ENDocRegistryView();
                case false:
                    return new EDDocRegistryView();
                default:
                    throw new Exception("Невозможно создать представление для указанного сценария.");
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public EDocRegistryView()
        {
            this.Initialize(false);
        }

        public EDocRegistryView(bool shortView)
        {
            this.Initialize(shortView);
        }
        #endregion
    }

    public abstract class EDocRegistryView<T> : EDocRegistryView
        where T : DataRow
    {
        public EDocRegistryView()
            : this(false)
        {

        }

        public EDocRegistryView(bool shortView)
            : base(shortView)
        {

        }

        public override EDocRegistryViewRow ConvertRow(DataRow row)
        {
            return row != null ? this.ConvertViewRow((T)row) : EDocRegistryViewEmptyRow.Instance;
        }
        protected abstract EDocRegistryViewRow ConvertViewRow(T row);


        public override Color GetDocBackColorByDocRow(DataRow row)
        {
            return row != null ? this.GetDocBackColorByDocRow((T)row) : Color.Empty;
        }
        protected abstract Color GetDocBackColorByDocRow(T row);

        protected abstract Color GetDocBackColorByDocState(byte? stateID, bool? result);

        public override Color GetDocBackColorByDocStateRow(WMSOffice.Data.PrintNakl.EN_DocStatesRow row)
        {
            var stateID = Convert.ToByte(row.State_ID);
            var result = row.IsResultNull() ? (bool?)null : row.Result;

            return this.GetDocBackColorByDocState(stateID, result);
        }
    }

    public class ENDocRegistryView : EDocRegistryView<Data.PrintNakl.EN_DocsRow>
    {
        public ENDocRegistryView()
            : this(false)
        {

        }

        public ENDocRegistryView(bool shortView)
            : base(shortView)
        {

        }

        public ENDocRegistryView(DataTable importedData, bool addSelector)
        {
            data = importedData.Clone();

            if (addSelector)
                data.Columns.Add(new DataColumn("IsChecked", typeof(bool)) { DefaultValue = true });

            data.Merge(importedData, true);
        }

        public ENDocRegistryView(DataTable importedData)
            : this(importedData, false)
        {

        }

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public override void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as EDocRegistrySearchParameters;

            var sessionID = searchCriteria.SessionID;
            var periodFrom = searchCriteria.PeriodFrom;
            var periodTo = searchCriteria.PeriodTo;
            var debtorID = searchCriteria.DebtorID;
            var docNumber = searchCriteria.DocNumber;
            var docType = searchCriteria.DocType;
            var eDocStateFromID = searchCriteria.EDocStateFromID;
            var eDocStateToID = searchCriteria.EDocStateToID;
            var eDocType = searchCriteria.EDocType;

            using (var adapter = new Data.PrintNaklTableAdapters.EN_DocsTableAdapter())
                this.data = adapter.GetData(sessionID, periodFrom, periodTo, debtorID, docNumber, docType, eDocStateFromID, eDocStateToID, eDocType);
        }

        protected override void Initialize(bool shortView)
        {
            if (shortView)
            {

            }
            else
            {
                this.dataColumns.Add(new ImagePatternColumn("Влож.", "Has_Attachment") { Width = 40 });

                this.dataColumns.Add(new PatternColumn("ID е-док.", "Doc_ID", new FilterCompareExpressionRule<Int32>("Doc_ID"), SummaryCalculationType.Count) { Width = 40 });
                this.dataColumns.Add(new PatternColumn("Тип е-док.", "Doc_Type", new FilterPatternExpressionRule("Doc_Type")) { Width = 40 });
                this.dataColumns.Add(new PatternColumn("Описание типа е-док.", "Doc_Type_Name", new FilterPatternExpressionRule("Doc_Type_Name")) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Статус", "State_ID", new FilterCompareExpressionRule<Int32>("State_ID"), SummaryCalculationType.Count) { Width = 50 });
                this.dataColumns.Add(new PatternColumn("Описание статуса", "State_Descr", new FilterPatternExpressionRule("State_Descr")) { Width = 150 });

                this.dataColumns.Add(new PatternColumn("Филиал", "MCU", new FilterPatternExpressionRule("MCU"), SummaryCalculationType.Count) { Width = 55 });
                this.dataColumns.Add(new PatternColumn("Номер док.", "DOC", new FilterCompareExpressionRule<Int32>("DOC")) { Width = 70 });
                this.dataColumns.Add(new PatternColumn("Тип док.", "DCT", new FilterPatternExpressionRule("DCT")) { Width = 40 });
                this.dataColumns.Add(new PatternColumn("Дата док.", "IVD", new FilterDateCompareExpressionRule("IVD")) { Width = 70 });

                this.dataColumns.Add(new PatternColumn("Код ТТ", "SHAN", new FilterCompareExpressionRule<Int32>("SHAN"), SummaryCalculationType.Count) { Width = 50 });
                this.dataColumns.Add(new PatternColumn("Код дебитора", "AN8", new FilterCompareExpressionRule<Int32>("AN8"), SummaryCalculationType.Count) { Width = 60 });
                this.dataColumns.Add(new PatternColumn("ОКПО дебитора", "OKPO", new FilterPatternExpressionRule("OKPO")) { Width = 70 });
                this.dataColumns.Add(new PatternColumn("Наименование дебитора", "Debtor_Name", new FilterPatternExpressionRule("Debtor_Name")) { Width = 310 });

                this.dataColumns.Add(new PatternColumn("Наименование дебитора связки", "Sub_Name", new FilterPatternExpressionRule("Sub_Name")) { Width = 310 });

                this.dataColumns.Add(new PatternColumn("Документ создан", "Created_DTTM", new FilterDateCompareExpressionRule("Created_DTTM")) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("Запрос отправлен", "Sent_DTTM", new FilterDateCompareExpressionRule("Sent_DTTM")) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("Документ доставлен", "Delivered_DTTM", new FilterDateCompareExpressionRule("Delivered_DTTM")) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("Ответ получен", "Received_DTTM", new FilterDateCompareExpressionRule("Received_DTTM")) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Описание ошибки", "Error_msg", new FilterPatternExpressionRule("Error_msg"), SummaryCalculationType.Count) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Сумма с НДС", "DocAmountWithVAT", new FilterCompareExpressionRule<Decimal>("DocAmountWithVAT"), SummaryCalculationType.Sum) { Width = 80, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Сумма НДС", "DocAmountVAT", new FilterCompareExpressionRule<Decimal>("DocAmountVAT"), SummaryCalculationType.Sum) { Width = 80, UseDecimalNumbersAlignment = true });

                this.dataColumns.Add(new PatternColumn("Дата экспорта", "Export_DTTM", new FilterDateCompareExpressionRule("Export_DTTM")) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Менеджер", "TP_Name", new FilterPatternExpressionRule("TP_Name"), SummaryCalculationType.Count) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Наименование файла", "Doc_Code", new FilterPatternExpressionRule("Doc_Code")) { Width = 1 });
            }
        }

        protected override EDocRegistryViewRow ConvertViewRow(WMSOffice.Data.PrintNakl.EN_DocsRow row)
        {
            return new ENDocRegistryViewRow(row);
        }

        protected override Color GetDocBackColorByDocRow(WMSOffice.Data.PrintNakl.EN_DocsRow row)
        {
            var stateID = Convert.ToByte(row.State_ID);
            var result = (bool?)null;

            return this.GetDocBackColorByDocState(stateID, result);
        }

        protected override Color GetDocBackColorByDocState(byte? stateID, bool? result)
        {
            Color color = Color.Empty;

            var state = stateID == null ? ENDocState.None : (ENDocState)stateID;
            switch (state)
            {
                case ENDocState.Delivered: // Доставлен
                    color = Color.LightBlue;
                    return color;
                case ENDocState.Accepted: // Подтвержден дебитором
                    color = Color.LightGreen;
                    return color;
                case ENDocState.Declined: // Отклонен дебитором
                case ENDocState.CancellationRequested: // Запрошено аннулирование
                case ENDocState.Canceled: // Аннулирован
                    color = Color.LightPink;
                    return color;
                case ENDocState.HeaderPrepared: // Залит заголовок
                case ENDocState.DetailsPrepared: // Залиты строки
                    color = SystemColors.Window;
                    return color;
                case ENDocState.ReadyToSend: // Готов к отправке
                case ENDocState.Queued: // Взят в работу
                case ENDocState.Sent: // Отправлен
                    color = Color.Khaki;
                    return color;
                case ENDocState.Closed: // Закрыт
                    color = Color.LightGray;
                    return color;
                default:
                    return color;
            }
        }

        public override Color GetReceiptResultForeColorByDocStateRow(WMSOffice.Data.PrintNakl.EN_DocStatesRow row)
        {
            Color color = Color.Black;

            var stateID = Convert.ToByte(row.State_ID);
            var state = (ENDocState)stateID;
            switch (state)
            {
                case ENDocState.Accepted: // Подтвержден дебитором
                    color = Color.Green;
                    return color;
                case ENDocState.Declined: // Отклонен дебитором
                    color = Color.Red;
                    return color;
                default:
                    return color;
            }
        }

        /// <summary>
        /// Статус электронного документа EN
        /// </summary>
        public enum ENDocState
        {
            /// <summary>
            /// Статус отсутствует
            /// </summary>
            None = -1,

            /// <summary>
            /// Залит заголовок
            /// </summary>
            HeaderPrepared = 10,

            /// <summary>
            /// Залиты строки
            /// </summary>
            DetailsPrepared = 20,

            /// <summary>
            /// Готов к отправке
            /// </summary>
            ReadyToSend = 100,

            /// <summary>
            /// Взят в работу
            /// </summary>
            Queued = 110,

            /// <summary>
            /// Отправлен
            /// </summary>
            Sent = 120,

            /// <summary>
            /// Доставлен
            /// </summary>
            Delivered = 130,

            /// <summary>
            /// Отклонен дебитором
            /// </summary>
            Declined = 185,

            /// <summary>
            /// Подтвержден дебитором
            /// </summary>
            Accepted = 190,

            /// <summary>
            /// Запрошено аннулирование
            /// </summary>
            CancellationRequested = 195,

            /// <summary>
            /// Аннулирован
            /// </summary>
            Canceled = 198,

            /// <summary>
            /// Закрыт
            /// </summary>
            Closed = 199
        }
    }

    public class EDDocRegistryView : EDocRegistryView<Data.PrintNakl.ED_DocsRow>
    {
        public EDDocRegistryView()
            : this(false)
        {

        }

        public EDDocRegistryView(bool shortView)
            : base(shortView)
        {

        }

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public override void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as EDocRegistrySearchParameters;

            var sessionID = searchCriteria.SessionID;
            var periodFrom = searchCriteria.PeriodFrom;
            var periodTo = searchCriteria.PeriodTo;
            var debtorID = searchCriteria.DebtorID;
            var docNumber = searchCriteria.DocNumber;
            var docType = searchCriteria.DocType;
            var eDocStateFromID = searchCriteria.EDocStateFromID;
            var eDocStateToID = searchCriteria.EDocStateToID;
            var eDocType = searchCriteria.EDocType;

            using (var adapter = new Data.PrintNaklTableAdapters.ED_DocsTableAdapter())
                this.data = adapter.GetData(sessionID, periodFrom, periodTo, debtorID, docNumber, docType, eDocStateFromID, eDocStateToID, eDocType);
        }

        protected override void Initialize(bool shortView)
        {
            if (shortView)
            {
                this.dataColumns.Add(new ImagePatternColumn("Влож.", "Has_Attachment") { Width = 40 });

                this.dataColumns.Add(new PatternColumn("Номер док.", "Doc_Num", new FilterPatternExpressionRule("Doc_Num")) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("Дата док.", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date")) { Width = 90 });

                this.dataColumns.Add(new PatternColumn("Код контраг.", "AN8", new FilterCompareExpressionRule<Int32>("AN8"), SummaryCalculationType.Count) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("ОКПО контраг.", "OKPO", new FilterPatternExpressionRule("OKPO")) { Width = 110 });
                this.dataColumns.Add(new PatternColumn("Наименование контрагента", "Debtor_Name", new FilterPatternExpressionRule("Debtor_Name")) { Width = 280 });
            }
            else
            {
                this.dataColumns.Add(new ImagePatternColumn("Влож.", "Has_Attachment") { Width = 40 });

                this.dataColumns.Add(new PatternColumn("ID е-док.", "Doc_ID", new FilterCompareExpressionRule<Int32>("Doc_ID"), SummaryCalculationType.Count) { Width = 40 });
                this.dataColumns.Add(new PatternColumn("Шаблон е-док.", "CharCode", new FilterPatternExpressionRule("CharCode")) { Width = 80 });
                this.dataColumns.Add(new PatternColumn("Тип е-док.", "Doc_GP_Descr", new FilterPatternExpressionRule("Doc_GP_Descr")) { Width = 80 });
                this.dataColumns.Add(new PatternColumn("Описание типа е-док.", "Doc_Name", new FilterPatternExpressionRule("Doc_Name")) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Статус", "State_ID", new FilterCompareExpressionRule<Int32>("State_ID"), SummaryCalculationType.Count) { Width = 50 });
                this.dataColumns.Add(new PatternColumn("Описание статуса", "State_Descr", new FilterPatternExpressionRule("State_Descr")) { Width = 250 });

                this.dataColumns.Add(new PatternColumn("Филиал", "MCU", new FilterPatternExpressionRule("MCU"), SummaryCalculationType.Count) { Width = 55 });

                this.dataColumns.Add(new PatternColumn("Номер заказа", "Order_No", new FilterCompareExpressionRule<Int32>("Order_No")) { Width = 80 });

                this.dataColumns.Add(new PatternColumn("Номер док.", "Doc_Num", new FilterPatternExpressionRule("Doc_Num")) { Width = 80 });
                this.dataColumns.Add(new PatternColumn("Дата док.", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date")) { Width = 70 });

                this.dataColumns.Add(new PatternColumn("Код контраг.", "AN8", new FilterCompareExpressionRule<Int32>("AN8"), SummaryCalculationType.Count) { Width = 60 });
                this.dataColumns.Add(new PatternColumn("ОКПО контраг.", "OKPO", new FilterPatternExpressionRule("OKPO")) { Width = 70 });
                this.dataColumns.Add(new PatternColumn("Наименование контрагента", "Debtor_Name", new FilterPatternExpressionRule("Debtor_Name")) { Width = 310 });

                this.dataColumns.Add(new PatternColumn("Документ создан", "Created_DTTM", new FilterDateCompareExpressionRule("Created_DTTM")) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("Документ принят", "Parsed_DTTM", new FilterDateCompareExpressionRule("Parsed_DTTM")) { Width = 100 });
                this.dataColumns.Add(new PatternColumn("Документ обработан", "Ans_DTTM", new FilterDateCompareExpressionRule("Ans_DTTM")) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Примечание", "Comment", new FilterPatternExpressionRule("Comment")) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Описание ошибки", "Error_msg", new FilterPatternExpressionRule("Error_msg"), SummaryCalculationType.Count) { Width = 200 });

                this.dataColumns.Add(new PatternColumn("Сумма с НДС", "DocAmountWithVAT", new FilterCompareExpressionRule<Decimal>("DocAmountWithVAT"), SummaryCalculationType.Sum) { Width = 80, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Сумма НДС", "DocAmountVAT", new FilterCompareExpressionRule<Decimal>("DocAmountVAT"), SummaryCalculationType.Sum) { Width = 80, UseDecimalNumbersAlignment = true });

                this.dataColumns.Add(new PatternColumn("Результат обработки", "Final_Result", new FilterPatternExpressionRule("Final_Result")) { Width = 100 });

                this.dataColumns.Add(new PatternColumn("Наименование файла", "Doc_Code", new FilterPatternExpressionRule("Doc_Code")) { Width = 1 });
            }
        }

        protected override EDocRegistryViewRow ConvertViewRow(WMSOffice.Data.PrintNakl.ED_DocsRow row)
        {
            return new EDDocRegistryViewRow(row);
        }

        protected override Color GetDocBackColorByDocRow(WMSOffice.Data.PrintNakl.ED_DocsRow row)
        {
            var stateID = Convert.ToByte(row.State_ID);
            var result = row.IsResultNull() ? (bool?)null : row.Result;

            return this.GetDocBackColorByDocState(stateID, result);
        }

        protected override Color GetDocBackColorByDocState(byte? stateID, bool? result)
        {
            Color color = Color.Empty;

            var state = stateID == null ? EDDocState.None : (EDDocState)stateID;
            switch (state)
            {
                case EDDocState.SendToDirectum: // Отправлен в Директум
                case EDDocState.SendToDirectumRepeat: // Отправлен в Директум (повторно)

                case EDDocState.CreateDirectumDoc: // Создан документ в Директум
                case EDDocState.ProcessingDocumentByReceivingDepartment: // В обработке (ПО)
                case EDDocState.ReceiveDirectumResult: // Получен результат с Директум
                    color = Color.LightBlue;
                    return color;
                case EDDocState.SendDocResultReceipt: // Отправлен результат рассмотрения
                case EDDocState.SendDocResultReceiptIncludePDF: // Отправлен результат рассмотрения (+pdf)
                    color = result ?? true ? Color.LightGreen : Color.LightPink;
                    return color;
                case EDDocState.SendToDirectumError: // Не удалось создать документ в Директум
                //case ENDocState.CancellationRequested: // Запрошено аннулирование
                case EDDocState.Canceled: // Аннулирован
                    color = Color.LightPink;
                    return color;
                case EDDocState.NotProcessed: // Не обработан
                case EDDocState.NotProcessedIncludePDF: // Не обработан (+pdf)
                    color = SystemColors.Window;
                    return color;
                case EDDocState.ReadyToProcess: // Готов к обработке
                case EDDocState.Processed: // Обработан
                case EDDocState.SendReceivedReceipt: // Отправлен ответ о получении
                case EDDocState.ReceiptResponseIncludePDF: // Отправлен ответ о получении (+pdf)
                    color = Color.Khaki;
                    return color;
                case EDDocState.Closed: // Результат рассмотрения доставлен клиенту
                    color = Color.LightGray;
                    return color;
                default:
                    return color;
            }
        }

        public override Color GetReceiptResultForeColorByDocStateRow(WMSOffice.Data.PrintNakl.EN_DocStatesRow row)
        {
            Color color = Color.Black;

            var stateID = Convert.ToByte(row.State_ID);
            var state = (EDDocState)stateID;
            var result = row.IsResultNull() ? (bool?)null : row.Result;
            switch (state)
            {
                case EDDocState.SendDocResultReceipt: // Подтвержден дебитором
                    color = result ?? true ? Color.Green : Color.Red;
                    return color;
                default:
                    return color;
            }
        }

        /// <summary>
        /// Статус электронного документа Ed
        /// </summary>
        public enum EDDocState
        {
            /// <summary>
            /// Статус отсутствует
            /// </summary>
            None = -1,

            /// <summary>
            /// Не обработан
            /// </summary>
            NotProcessed = 0,

            /// <summary>
            /// Не обработан (+pdf)
            /// </summary>
            NotProcessedIncludePDF = 5,

            /// <summary>
            /// Готов к обработке
            /// </summary>
            ReadyToProcess = 10,

            /// <summary>
            /// Обработан
            /// </summary>
            Processed = 30,

            /// <summary>
            /// Отправлен ответ о получении
            /// </summary>
            SendReceivedReceipt = 40,

            /// <summary>
            /// Отправлен ответ о получении (+pdf)
            /// </summary>
            ReceiptResponseIncludePDF = 45,

            /// <summary>
            /// Отправлен в Директум
            /// </summary>
            SendToDirectum = 50,

            /// <summary>
            /// Не удалось создать документ в Директум
            /// </summary>
            SendToDirectumError = 51,

            /// <summary>
            /// Отправлен в Директум (повторно)
            /// </summary>
            SendToDirectumRepeat = 52,

            /// <summary>
            /// Создан документ в Директум
            /// </summary>
            CreateDirectumDoc = 55,

            /// <summary>
            /// В обработке (ПО)
            /// </summary>
            ProcessingDocumentByReceivingDepartment = 60,

            /// <summary>
            /// Получен результат с Директум
            /// </summary>
            ReceiveDirectumResult = 70,

            /// <summary>
            /// Отправлен результат рассмотрения
            /// </summary>
            SendDocResultReceipt = 80,

            /// <summary>
            /// Отправлен результат рассмотрения (+pdf)
            /// </summary>
            SendDocResultReceiptIncludePDF = 85,

            /// <summary>
            /// Документ аннулирован
            /// </summary>
            Canceled = 98,

            /// <summary>
            /// Результат рассмотрения доставлен клиенту
            /// </summary>
            Closed = 99
        }
    }

    public abstract class EDocRegistryViewRow
    {
        public abstract bool IsEnabled { get; }
        public abstract bool HasAttachment { get; }

        public abstract bool IsPreviewEnabled { get; }
        public abstract bool IsExportToPDFEnabled { get; }
        public abstract bool IsExportToDiskEnabled { get; }

        public abstract bool IsCheckStateEnabled { get; }
        public abstract bool IsCancelEnabled { get; }
        public abstract bool IsResendEnabled { get; }

        public abstract bool IsAcceptEnabled { get; }
        public abstract bool IsDeclineEnabled { get; }

        public abstract bool IsSignWaybillEnabled { get; }
        public abstract bool IsCreateWaybillActEnabled { get; }

        public abstract int? DocID { get; }

        public abstract int? StateID { get; }

        public abstract string FileName { get; }

        public abstract string DocNum { get; }
        public abstract DateTime? DocDate { get; }
    }

    public class EDocRegistryViewEmptyRow : EDocRegistryViewRow
    {
        #region Singleton

        private static object syncRoot = new object();

        private static EDocRegistryViewEmptyRow instance = null;
        public static EDocRegistryViewEmptyRow Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new EDocRegistryViewEmptyRow();

                    return instance;
                }
            }
        }

        protected EDocRegistryViewEmptyRow()
        {

        }

        #endregion

        public override bool IsEnabled { get { return false; } }
        public override bool HasAttachment { get { return false; } }
        public override bool IsPreviewEnabled { get { return false; } }
        public override bool IsExportToPDFEnabled { get { return false; } }
        public override bool IsExportToDiskEnabled { get { return false; } }
        public override bool IsCheckStateEnabled { get { return false; } }
        public override bool IsCancelEnabled { get { return false; } }
        public override bool IsResendEnabled { get { return false; } }
        public override bool IsAcceptEnabled { get { return false; } }
        public override bool IsDeclineEnabled { get { return false; } }
        public override bool IsSignWaybillEnabled { get { return false; } }
        public override bool IsCreateWaybillActEnabled { get { return false; } }

        public override int? DocID { get { return (int?)null; } }

        public override int? StateID { get { return (int?)null; } }

        public override string FileName { get { return (string)null; } }

        public override string DocNum { get { return (string)null; } }
        public override DateTime? DocDate { get { return (DateTime?)null; } }
    }

    public abstract class EDocRegistryViewRow<T> : EDocRegistryViewRow
        where T : DataRow
    {
        protected readonly T _row = null;

        public override bool IsEnabled { get { return _row != null; } }

        protected abstract bool IsAlreadySended { get; }
        protected abstract bool IsSended { get; }
        protected abstract bool IsAccepted { get; }
        protected abstract bool IsReadyForResend { get; }
        protected abstract bool IsReadyForCheckState { get; }

        protected abstract bool IsReadyForAccept { get; }
        protected abstract bool IsReadyForDecline { get; }

        protected abstract bool IsReadyForSignWaybill { get; }
        protected abstract bool IsReadyForCreateWaybillAct { get; }

        public override bool IsPreviewEnabled { get { return this.HasAttachment; } } // && this.IsAlreadySended;
        public override bool IsExportToPDFEnabled { get { return this.HasAttachment; } } // && this.IsAlreadySended;
        public override bool IsExportToDiskEnabled { get { return this.HasAttachment && this.IsAccepted; } } // && this.IsAlreadySended;

        public override bool IsCheckStateEnabled { get { return IsReadyForCheckState; } }
        public override bool IsCancelEnabled { get { return (this.IsAccepted || this.IsSended); } }
        public override bool IsResendEnabled { get { return this.IsReadyForResend; } }

        public override bool IsAcceptEnabled { get { return this.IsReadyForAccept; } }
        public override bool IsDeclineEnabled { get { return this.IsReadyForDecline; } }

        public override bool IsSignWaybillEnabled { get { return this.IsReadyForSignWaybill; } }
        public override bool IsCreateWaybillActEnabled { get { return this.IsReadyForCreateWaybillAct; } }

        protected abstract string DocType { get; }
        protected abstract int? InnerDocID { get; }
        protected abstract string InnerDocType { get; }

        public EDocRegistryViewRow(T row)
        {
            _row = row;
        }
    }

    public class ENDocRegistryViewRow : EDocRegistryViewRow<Data.PrintNakl.EN_DocsRow>
    {
        protected override bool IsAlreadySended { get { return _row.State_ID >= (byte)ENDocRegistryView.ENDocState.Sent; } }
        protected override bool IsSended { get { return ((ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Sent || (ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Delivered); } }
        protected override bool IsAccepted { get { return this.IsAlreadySended && ((ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Accepted || (ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Closed); } }
        protected override bool IsReadyForResend { get { return ((ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Queued || (ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Sent || (ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Delivered || (ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Declined); } }
        protected override bool IsReadyForCheckState { get { return ((ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Sent || (ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Delivered); } }

        protected override bool IsReadyForAccept { get { return false; } }
        protected override bool IsReadyForDecline { get { return false; } }

        protected override bool IsReadyForSignWaybill { get { return false; } }
        protected override bool IsReadyForCreateWaybillAct { get { return false; } }

        public override bool HasAttachment { get { return _row.Has_Attachment; } }

        public override int? DocID { get { return _row.Doc_ID; } }

        protected override string DocType { get { return _row.Doc_Type; } }
        protected override int? InnerDocID { get { return _row.DOC; } }
        protected override string InnerDocType { get { return _row.DCT; } }

        public override int? StateID { get { return _row.State_ID; } }

        public override string FileName { get { return string.Format("{0}-{1} ({2})", this.DocType, this.InnerDocID, this.InnerDocType); } }

        public override string DocNum { get { return _row.DOC.ToString(); } }
        public override DateTime? DocDate { get { return _row.IVD; } }

        public ENDocRegistryViewRow(Data.PrintNakl.EN_DocsRow row)
            : base(row)
        {

        }
    }

    public class EDDocRegistryViewRow : EDocRegistryViewRow<Data.PrintNakl.ED_DocsRow>
    {
        public bool IsPurchaseOrder { get { return _row.Doc_GP == 3; } }

        protected override bool IsAlreadySended { get { return false; } }
        protected override bool IsSended { get { return false; } }
        protected override bool IsAccepted { get { return (((EDDocRegistryView.EDDocState)_row.State_ID == EDDocRegistryView.EDDocState.SendDocResultReceiptIncludePDF || (EDDocRegistryView.EDDocState)_row.State_ID == EDDocRegistryView.EDDocState.Closed) && _row.Result); } }  //(_row.IsResultNull() ? (bool?)null : _row.Result ?? false == true)); } } //this.IsAlreadySended && ((ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Accepted || (ENDocRegistryView.ENDocState)_row.State_ID == ENDocRegistryView.ENDocState.Closed); } }
        protected override bool IsReadyForResend { get { return false; } }
        protected override bool IsReadyForCheckState { get { return false; } }

        protected override bool IsReadyForAccept { get { return ((EDDocRegistryView.EDDocState)_row.State_ID == EDDocRegistryView.EDDocState.ReceiptResponseIncludePDF && this.IsPurchaseOrder); } }
        protected override bool IsReadyForDecline { get { return (((EDDocRegistryView.EDDocState)_row.State_ID == EDDocRegistryView.EDDocState.ReceiptResponseIncludePDF || (EDDocRegistryView.EDDocState)_row.State_ID == EDDocRegistryView.EDDocState.ProcessingDocumentByReceivingDepartment) && this.IsPurchaseOrder); } }

        protected override bool IsReadyForSignWaybill { get { return false; } }
        protected override bool IsReadyForCreateWaybillAct { get { return false; } }

        public override bool HasAttachment { get { return _row.Has_Attachment; } }

        public override int? DocID { get { return (int)_row.Doc_ID; } }

        protected override string DocType { get { return _row.CharCode; } }
        protected override int? InnerDocID { get { return (int)_row.Doc_ID; } }
        protected override string InnerDocType { get { return _row.Doc_GP.ToString(); } }

        public override int? StateID { get { return _row.State_ID; } }

        public override string FileName { get { return string.Format("{0}-{1} ({2})", this.DocType, this.InnerDocID, this.InnerDocType); } }

        public override string DocNum { get { return _row.IsDoc_NumNull() ? (string)null : _row.Doc_Num; } }
        public override DateTime? DocDate { get { return _row.IsDoc_DateNull() ? (DateTime?)null : _row.Doc_Date; } }

        public EDDocRegistryViewRow(Data.PrintNakl.ED_DocsRow row)
            : base(row)
        {

        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class EDocRegistrySearchParameters : SessionIDSearchParameters
    {
        public string EDocType { get; set; }
        public byte? EDocStateFromID { get; set; }
        public byte? EDocStateToID { get; set; }
        public int? DebtorID { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }

        public bool UseExtraSearch { get; set; }

        public int? DocNumber { get; set; }
        public string DocType { get; set; }
    }
}
