using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Classes.ReportProviders;
using WMSOffice.Controls;
using WMSOffice.Data;
using WMSOffice.Data.ComplaintsExtTableAdapters;
using WMSOffice.Data.ComplaintsTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Properties;
using WMSOffice.Reports;
using WMSOffice.Controls.Complaints;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using CrystalDecisions.Shared;
using WMSOffice.Dialogs.Quality;

namespace WMSOffice.Window
{
    /// <summary>
    /// Диалог для просмотра и управления списком текущих претензий.
    /// </summary>
    public partial class ComplaintsListWindow : GeneralWindow
    {
        #region ДОСТУПЫ НА КНОПКИ

        /// <summary>
        /// Доступность кнопки "Печать акта". Эта кнопка доступна не для всех типов претензий
        /// </summary>
        private bool CanPrintAct
        {
            get
            {
                return SelectedRow != null && cmbPrinters.SelectedItem != null && (
                    SelectedRow.Doc_Type == Constants.CO_DTFL_NTV ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_BOY ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_PERESORT ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_ITND ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_OVERAGE ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_BOXND ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_REG ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_MANUFACTURERND ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_DEFECT ||
                    SelectedRow.Doc_Type == Constants.CO_DFTL_DEMAND ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_EXPIRATION ||
                    SelectedRow.Doc_Type == Constants.CO_DTFL_VIRTUAL_REFUSE);
            }
        }

        #endregion


        /// <summary>
        /// Cтатус "ошибка при обработке претензии"
        /// </summary>
        private const string PROCESSING_ERRORS_STATE = "991";

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        /// <summary>
        /// Параметр для хранимой процедуры обновления данных: тип документа.
        /// </summary>
        private string FilterDocType { get; set; }
        /// <summary>
        /// Параметр для хранимой процедуры обновления данных: идентификатор статуса претензии для начала отображаемого диапазона.
        /// </summary>
        private string FilterStatusFrom { get; set; }
        /// <summary>
        /// Параметр для хранимой процедуры обновления данных: идентификатор статуса претензии для конца отображаемого диапазона.
        /// </summary>
        private string FilterStatusTo { get; set; }
        /// <summary>
        /// Параметр для хранимой процедуры обновления данных: признак, показывающий, нужно ли отображать только претензии, по которым пользователь должен поставить визу.
        /// </summary>
        private bool FilterOnlyRequiringVisa { get; set; }
        /// <summary>
        /// Параметр для хранимой процедуры обновления данных: идентификатор филиала (склада) для отображаемых претензий.
        /// </summary>
        private string FilterWarehouse { get; set; }

        /// <summary>
        /// Признак возможности просмотра журнала исключений
        /// </summary>
        private bool canAccessCheckExceptionsLog = false;

        /// <summary>
        /// Признак возможности просмотра документов выбранной претензии
        /// </summary>
        private bool canCheckExternalDocs = false;

        /// <summary>ur
        /// Возвращает текущую выделенную строку из таблицы со списком претензий.
        /// </summary>
        private Data.Complaints.CurrentDocsRow SelectedRow { get { return xdgvComplaints.SelectedItem as Data.Complaints.CurrentDocsRow; } }

        /// <summary>
        /// Столбец с информацией о связанных претензиях
        /// </summary>
        private DataGridViewImageColumn dgvcHasLink = null;

        /// <summary>
        /// Столбец с информацией о наличии товара с признаком холода
        /// </summary>
        private DataGridViewImageColumn dgvcHasCold = null;

        /// <summary>
        /// Столбец с информацией о наличии ошибок обработки
        /// </summary>
        private DataGridViewImageColumn dgvcHasProcessingErrors = null;

        /// <summary>
        /// Столбец с информацией о наличии вложенных файлов
        /// </summary>
        private DataGridViewImageColumn dgvcHasAttachedFiles = null;


        private static Bitmap AttachImage
        {
            get
            {
                Bitmap b = new Bitmap(16, 16);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(Properties.Resources.paperclip, 0, 0, 16, 16);
                g.Dispose();
                return b;
            }
        }

        private static Bitmap MergeStatusImage
        {
            get
            {
                Bitmap b = new Bitmap(16, 16);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(Properties.Resources.merging, 0, 0, 16, 16);
                g.Dispose();
                return b;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public ComplaintsListWindow()
        {
            InitializeComponent();
            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);

            // выключаем доступность кнопок со старта
            foreach (ToolStripItem c in toolStripDoc.Items)
                if (c is ToolStripButton && c != btnRefresh && c != btnSearch)
                    c.Enabled = c.Visible = false;

            btnExcel.Click += (s, e) => { btnExcel.ShowDropDown(); };

            Config.LoadDataGridViewSettings(this.Name, dgvDocRequestDetails);
            dgvDocRequestDetails.Columns["dgvcColdSignImage"].DisplayIndex = 0;
            dgvDocRequestDetails.Columns["manufacturerDataGridViewTextBoxColumn"].DisplayIndex = dgvDocRequestDetails.Columns.Count - 1;
        }

        /// <summary>
        /// Обновляет содержимое при первом показе окна.
        /// </summary>
        private void ComplaintsListWindow_Shown(object sender, EventArgs e)
        {
            if (this.Initialize())
            {
                dgvcColdSignImage.DefaultCellStyle.NullValue = null;

                docsFilter.Init(UserID);

                stagesInfo.OnNeedDocStageDetails += (s, ea) => { stagesInfo.RefreshInfoDetails(UserID, ea.StageID); };
                stagesInfo.OnNeedPreviousLevelStages += (s, ea) => { stagesInfo.RefreshInfo(UserID, SelectedRow == null ? (long?)null : SelectedRow.Doc_ID); };
                stagesInfo.OnAcceptComplaintFromStage += (s, ea) => { this.AcceptComplaint(ea.StageID); };

                taDocRequestDetails.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);

                btnRefresh_Click(this, EventArgs.Empty);
                CheckAccessToExceptionsLog();
                CanCheckExternalDocs();
                RefreshStagesAndButtons();
            }
            else
            {
                this.Close();
            }
        }

        #region ИНИЦИАЛИЗАЦИЯ ОБРАБОТЧИКОВ ФИЛЬТРУЕМОЙ ТАБЛИЦЫ

        public bool Initialize()
        {
            this.xdgvComplaints.UseMultiSelectMode = true;

            //this.xdgvComplaints.AllowFilter = false;
            this.xdgvComplaints.AllowSummary = false;
            this.xdgvComplaints.AllowRangeColumns = true;

            this.xdgvComplaints.Init(new ComplaintsView(), true);

            #region ИНИЦИАЛИЗАЦИЯ СТОЛБЦОВ-ИНДИКАТОРОВ

            foreach (DataGridViewColumn column in xdgvComplaints.DataGrid.Columns)
            {
                if ((column.Tag ?? string.Empty).Equals("HasLink"))
                    dgvcHasLink = column as DataGridViewImageColumn;

                if ((column.Tag ?? string.Empty).Equals("IsCold"))
                    dgvcHasCold = column as DataGridViewImageColumn;

                if ((column.Tag ?? string.Empty).Equals("HasProcessingErrors"))
                    dgvcHasProcessingErrors = column as DataGridViewImageColumn;

                if ((column.Tag ?? string.Empty).Equals("HasAttachedFiles"))
                    dgvcHasAttachedFiles = column as DataGridViewImageColumn;
            }

            if (dgvcHasLink == null)
            {
                this.ShowError("Отсутствует столбец с информацией о связанных претензиях.");
                return false;
            }

            if (dgvcHasCold == null)
            {
                this.ShowError("Отсутствует столбец с информацией о наличии товара с признаком холода.");
                return false;
            }

            if (dgvcHasProcessingErrors == null)
            {
                this.ShowError("Отсутствует столбец с информацией о наличии ошибок обработки.");
                return false;
            }

            if (dgvcHasAttachedFiles == null)
            {
                this.ShowError("Отсутствует столбец с информацией о наличии вложенных файлов.");
                return false;
            }

            #endregion

            this.xdgvComplaints.LoadExtraDataGridViewSettings(this.Name);

            dgvcHasLink.DisplayIndex = 0;
            dgvcHasProcessingErrors.DisplayIndex = 1;
            dgvcHasCold.DisplayIndex = 2;

            dgvcHasProcessingErrors.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;

            this.xdgvComplaints.UserID = this.UserID;

            this.xdgvComplaints.OnDataError += new DataGridViewDataErrorEventHandler(xdgvComplaints_OnDataError);
            this.xdgvComplaints.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvComplaints_OnRowDoubleClick);
            this.xdgvComplaints.OnRowSelectionChanged += new EventHandler(xdgvComplaints_OnRowSelectionChanged);
            this.xdgvComplaints.OnFilterChanged += new EventHandler(xdgvComplaints_OnFilterChanged);
            this.xdgvComplaints.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvComplaints_OnFormattingCell);
            this.xdgvComplaints.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvComplaints_OnDataBindingComplete);

            this.xdgvComplaints.ContextMenuStrip = cmsDocs;

            // активация постраничного просмотра
            this.xdgvComplaints.CreatePageNavigator();

            return true;
        }

        void xdgvComplaints_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvComplaints_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (this.SelectedRow != null && this.SelectedRow.Status_ID == PROCESSING_ERRORS_STATE)
            {
                ComplaintProcessingDataErrorsForm errorsForm = new ComplaintProcessingDataErrorsForm();
                errorsForm.UserID = this.UserID;
                errorsForm.DocID = this.SelectedRow.Doc_ID;
                errorsForm.ShowDialog();
            }
        }

        void xdgvComplaints_OnRowSelectionChanged(object sender, EventArgs e)
        {
            RefreshStagesAndButtons();

            Qty_driver.Visible = false;
            Qty_buch.Visible = false;

            itemIDDataGridViewTextBoxColumn.Visible = true;
            itemNameDataGridViewTextBoxColumn.Visible = true;
            vendorLotFactDataGridViewTextBoxColumn.Visible = true;
            LifeTime.Visible = true;
            unitOfMeasureDataGridViewTextBoxColumn.Visible = true;
            quantityDataGridViewTextBoxColumn.Visible = true;
            SumWithVAT.Visible = true;
            NN.Visible = true;

            relatedInvoiceTypeDataGridViewTextBoxColumn.Visible = false;

            Price.HeaderText = "Цена";

            PriceVAT.Visible = false;
            PriceVAT.HeaderText = "Цена НДС";
            
            PriceWithVAT.Visible = false;
            PriceWithVAT.HeaderText = "Цена с НДС";

            var hasDefaultLines = false;

            if (SelectedRow != null)
            {
                if (SelectedRow.Doc_Type.Equals(Constants.CO_DTWH_RET_ACT, StringComparison.InvariantCultureIgnoreCase))
                {
                    taDocRequestDetails.FillByTypeRA(complaints.DocRequestDetails, UserID, SelectedRow == null ? (long?)null : SelectedRow.Doc_ID);

                    Qty_driver.Visible = true;
                    Qty_buch.Visible = true;
                }
                else if (SelectedRow.Doc_Type.Equals(Constants.CO_DT_RESIGN_INVOICE, StringComparison.InvariantCultureIgnoreCase))
                {
                    taDocRequestDetails.FillByTypeRI(complaints.DocRequestDetails, UserID, SelectedRow == null ? (long?)null : SelectedRow.Doc_ID);

                    itemIDDataGridViewTextBoxColumn.Visible = false;
                    itemNameDataGridViewTextBoxColumn.Visible = false;
                    vendorLotFactDataGridViewTextBoxColumn.Visible = false;
                    LifeTime.Visible = false;
                    unitOfMeasureDataGridViewTextBoxColumn.Visible = false;
                    quantityDataGridViewTextBoxColumn.Visible = false;
                    SumWithVAT.Visible = false;
                    NN.Visible = false;

                    Price.HeaderText = "Сумма";

                    PriceVAT.HeaderText = "Сумма НДС";
                    PriceVAT.DisplayIndex = Tax.DisplayIndex + 1;
                    PriceVAT.Visible = true;

                    PriceWithVAT.DisplayIndex = PriceVAT.DisplayIndex + 1;
                    PriceWithVAT.HeaderText = "Сумма с НДС";
                    PriceWithVAT.Visible = true;

                    relatedInvoiceTypeDataGridViewTextBoxColumn.DisplayIndex = relatedInvoiceNumberDataGridViewTextBoxColumn.DisplayIndex - 1;
                    relatedInvoiceTypeDataGridViewTextBoxColumn.Visible = true;
                }
                else
                {
                    hasDefaultLines = true;
                }
            }
            else
            {
                hasDefaultLines = true;
            }

            if (hasDefaultLines)
            {
                taDocRequestDetails.Fill(complaints.DocRequestDetails, UserID, SelectedRow == null ? (long?)null : SelectedRow.Doc_ID);
            }
        }

        void xdgvComplaints_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvComplaints.RecalculateSummary();
            this.ChangeExportToExcelOptionState();
        }

        void ChangeExportToExcelOptionState()
        {
            btnExcel.Visible = btnExcel.Enabled = true;

            btnExportComplaintsToExcel.Enabled = miExportComplaintsToExcel.Enabled =
            btnExportComplaintsWithDetailsToExcel.Enabled = miExportComplaintsWithDetailsToExcel.Enabled = this.xdgvComplaints.HasRows;

            btnExportComplaintDetailsToExcel.Enabled = miExportComplaintDetailsToExcel.Enabled =
            btnExportCoDetailsForHandler.Enabled = miExportCoDetailsForHandler.Enabled = this.xdgvComplaints.SelectedItem != null;
        }

        void xdgvComplaints_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        void xdgvComplaints_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvComplaints.DataGrid.Rows)
            {
                var boundRow = (xdgvComplaints.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.Complaints.CurrentDocsRow;

                var hasBackColor = false;
                var backColor = Color.Empty;
                if (!boundRow.IsColorNull())
                {
                    hasBackColor = true;
                    backColor = Color.FromName(boundRow.Color);
                }

                var hasForeColor = false;
                var foreColor = Color.Empty;
                if (!boundRow.IsFont_ColorNull())
                {
                    hasForeColor = true;
                    foreColor = Color.FromName(boundRow.Font_Color);
                }

                var hasProcessingErrors = false;
                var processingErrorsValue = emptyIcon;
                if (boundRow.Status_ID == PROCESSING_ERRORS_STATE)
                {
                    hasProcessingErrors = true;
                    processingErrorsValue = Resources.Achtung;
                }

                var hasCold = false;
                object coldValue = emptyIcon;
                if (!boundRow.IsXLNull() && boundRow.XL == 1)
                {
                    hasCold = true;
                    coldValue = Resources.snowflakeB;
                }

                var hasLink = false;
                object linkValue = emptyIcon;
                if (!boundRow.IsisLinkedNull() && boundRow.isLinked == 1)
                {
                    hasLink = true;
                    linkValue = MergeStatusImage;
                }

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

                foreach (DataGridViewColumn column in xdgvComplaints.DataGrid.Columns)
                {
                    if (hasBackColor)
                    {
                        xdgvComplaints.DataGrid.Rows[row.Index].Cells[column.Index].Style.BackColor = backColor;
                        xdgvComplaints.DataGrid.Rows[row.Index].Cells[column.Index].Style.SelectionBackColor = !foreColor.Equals(Color.Black) ? Color.LightCyan : xdgvComplaints.DataGrid.Rows[row.Index].Cells[column.Index].Style.SelectionBackColor;
                    }

                    if (hasForeColor)
                    {
                        xdgvComplaints.DataGrid.Rows[row.Index].Cells[column.Index].Style.ForeColor = foreColor;
                        xdgvComplaints.DataGrid.Rows[row.Index].Cells[column.Index].Style.SelectionForeColor = foreColor.Equals(Color.Black) ? Color.White : foreColor;
                    }
                }

                if (hasLink)
                {
                    xdgvComplaints.DataGrid.Rows[row.Index].Cells[dgvcHasLink.Index].Value = linkValue;
                    dgvcHasLink.ToolTipText = "Есть связаные";
                }

                if (hasProcessingErrors)
                    xdgvComplaints.DataGrid.Rows[row.Index].Cells[dgvcHasProcessingErrors.Index].Value = processingErrorsValue;

                if (hasCold)
                    xdgvComplaints.DataGrid.Rows[row.Index].Cells[dgvcHasCold.Index].Value = coldValue;

                if (hasAttachedFiles)
                    xdgvComplaints.DataGrid.Rows[row.Index].Cells[dgvcHasAttachedFiles.Index].Value = attachedFilesValue;
            }
        }

        #endregion

        private void CheckAccessToExceptionsLog()
        {
            try
            {
                var access = (int?)null;

                using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                    adapter.CanIgnoreCheckDoc(UserID, ref access);

                this.canAccessCheckExceptionsLog = Convert.ToBoolean(access ?? 0);
            }
            catch
            { 
            
            }
        }

        private void CanCheckExternalDocs()
        {
            try
            {
                var access = (int?)null;

                using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                    adapter.CanCheckExternalDocs(UserID, ref access);

                this.canCheckExternalDocs= Convert.ToBoolean(access ?? 0);
            }
            catch (Exception)
            {
               
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                btnRefresh_Click(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Обрабатывает закрытие окна.
        /// </summary>
        private void ComplaintsListWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.xdgvComplaints.SaveExtraDataGridViewSettings(this.Name);
            Config.SaveDataGridViewSettings(this.Name, dgvDocRequestDetails);
        }

        /// <summary>
        /// Обрабатывает событие изменения пользователем настроек фильтрации.
        /// </summary>
        private void docsFilter_FilterChanged(object sender, DocsFilter.FilterChangedEventArgs e)
        {
            FilterDocType = e.LimitDocType ? e.DocType : null;
            FilterStatusFrom = e.LimitDocStatus ? e.StatusFrom : null;
            FilterStatusTo = e.LimitDocStatus ? e.StatusTo : null;
            FilterOnlyRequiringVisa = e.OnlyRequiringVisa;
            FilterWarehouse = e.LimitWarehouse ? e.Warehouse : null;

            // в связи с увеличением количества претензий данные начали грузиться все дольше и дольше. отключено.
            // btnRefresh_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);
        /// <summary>
        /// Обновляет сумму по строкам претензии после их загрузки.
        /// </summary>
        private void dgvDocRequestDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double sum = 0;
            double sumVAT = 0;
            double sumWithVAT = 0;

            foreach (Data.Complaints.DocRequestDetailsRow row in complaints.DocRequestDetails.Rows)
            {
                if (!row.IsQuantityNull() && !row.IsPriceNull())
                    sum += row.Quantity * row.Price;

                if (!row.IsQuantityNull() && !row.IsPriceVATNull())
                    sumVAT += row.Quantity * row.PriceVAT;

                if (!row.IsQuantityNull() && !row.IsPriceWithVATNull())
                    sumWithVAT += row.Quantity * row.PriceWithVAT;
            }

            foreach (DataGridViewRow row in dgvDocRequestDetails.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.DocRequestDetailsRow;

                #region РАСЧЕТ СУММЫ С НДС ПОПОЗИЦИОННО

                double sumWithVatInRow = 0;
                if (!dataRow.IsQuantityNull() && !dataRow.IsPriceWithVATNull())
                    sumWithVatInRow += dataRow.Quantity * dataRow.PriceWithVAT;

                row.Cells[SumWithVAT.Name].Value = sumWithVatInRow;

                #endregion

                //if (dataRow.XL == 1)
                //{
                //    row.Cells["dgvcColdSignImage"].Value = Properties.Resources.snowflakeB;
                //    row.Cells["dgvcColdSignImage"].ToolTipText = "Признак холода";
                //}
                //else
                //{
                //    row.Cells["dgvcColdSignImage"].Value = emptyIcon;
                //}

                if (dataRow.IsXL_typeNull() || string.IsNullOrEmpty(dataRow.XL_type))
                {
                    row.Cells["dgvcColdSignImage"].Value = emptyIcon;
                }
                else
                {
                    if (dataRow.XL_type == "R")
                    {
                        row.Cells["dgvcColdSignImage"].Value = Properties.Resources.snowflakeR;
                        row.Cells["dgvcColdSignImage"].ToolTipText = "Признак холода 2-8";
                    }
                    else if (dataRow.XL_type == "B")
                    {
                        row.Cells["dgvcColdSignImage"].Value = Properties.Resources.snowflakeB;
                        row.Cells["dgvcColdSignImage"].ToolTipText = "Признак холода 8-15";
                    }
                }

                if (!dataRow.IsisLinkedNull() && dataRow.isLinked == 1)
                {
                    row.Cells[clmIsLinkedDetail.Index].Value = MergeStatusImage;
                    clmIsLinkedDetail.Visible = true;
                    clmIsLinkedDetail.DisplayIndex = 0;
                }
                else
                    row.Cells[clmIsLinkedDetail.Index].Value = emptyIcon;

                if (!dataRow.IsimgRegisterTemperatureNull())
                {
                    row.Cells[clmHasAttach.Index].Value = AttachImage;
                    row.Cells[clmHasAttach.Index].ToolTipText = "Cкан.копия журнала регистрации условий температурного режима";
                    clmHasAttach.Visible = true;
                    clmHasAttach.DisplayIndex = 0;
                }
                else
                    row.Cells[clmHasAttach.Index].Value = emptyIcon;
            }


            lblSum.Text = sum.ToString("N2");
            lblSumVAT.Text = sumVAT.ToString("N2");
            lblSumWithVAT.Text = sumWithVAT.ToString("N2");
        }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии формировать протокол расследований
        /// </summary>
        private bool canPrintInvestigationReport = false;

        /// <summary>
        /// Обновляет данные об этапах обработки выбранной претензии и меняет доступность кнопок.
        /// </summary>
        private void RefreshStagesAndButtons()
        {
            stagesInfo.RefreshInfo(UserID, SelectedRow == null ? (long?)null : SelectedRow.Doc_ID);

            btnShowAttachments.Enabled = btnShowAttachments.Visible = stagesInfo.CanSeeAttachments;
            btnShowAnalysisInfo.Enabled = btnShowAnalysisInfo.Visible = stagesInfo.CanAnalyze;
            btnEnterTakingRemainsResults.Enabled = btnEnterTakingRemainsResults.Visible = stagesInfo.CanEnterTakingRemainsResults;
           

            int statusId = int.MaxValue;
            var canMerge = SelectedRow == null ? false : int.TryParse(SelectedRow.Status_ID, out statusId) ? statusId <= 270 : false;
            btnMerge.Enabled = btnMerge.Visible = (SelectedRow == null ? false : SelectedRow.Doc_Type.ToUpper() == "EX" && canMerge);

            btnEdit.Enabled = btnEdit.Visible = SelectedRow == null ? false : int.TryParse(SelectedRow.Status_ID, out statusId) ? statusId <= 220 && (stagesInfo.CanEdit || stagesInfo.CanChangeLocation) : false;

            btnPrintAcceptanceCert.Enabled = btnPrintAcceptanceCert.Visible = stagesInfo.CanPrintAcceptanceCert;
            btnConfirmDefects.Enabled = btnConfirmDefects.Visible = stagesInfo.CanConfirmDefects;
            btnChangeCommonFaultEmployee.Enabled = btnChangeCommonFaultEmployee.Visible = stagesInfo.CanChangeCommonFaultEmployee;
            btnSetShortageOnDriver.Enabled = btnSetShortageOnDriver.Visible = stagesInfo.CanSetShortageOnDriver;
            btnAcceptComplaint.Enabled = btnAcceptComplaint.Visible = stagesInfo.CanAccept;
            btnDeclineComplaint.Enabled = btnDeclineComplaint.Visible = stagesInfo.CanDecline;
            btnExtendComplaint.Enabled = btnExtendComplaint.Visible = stagesInfo.CanChangeExpirationDate;
            btnComment.Enabled = btnComment.Visible = stagesInfo.CanComment;
            btnRequestSample.Enabled = btnRequestSample.Visible = stagesInfo.CanRequestSample;
            btnDeclineByFactory.Enabled = btnDeclineByFactory.Visible = stagesInfo.CanDeclineByFactory;
            btnSetClientLetterSent.Enabled = btnSetClientLetterSent.Visible = stagesInfo.CanSetClientLetterSent;
            btnRestoreDeclinedComplaint.Enabled = btnRestoreDeclinedComplaint.Visible = stagesInfo.CanRestoreDeclined;
            btnPrintListPlacement.Enabled = btnPrintListPlacement.Visible = CheckIfCanPrintListPlacement();
            btnLineSightOfComplaint.Enabled = btnLineSightOfComplaint.Visible = stagesInfo.CanLineSight;

            this.ChangeExportToExcelOptionState();

            btnClearPreviousVisa.Enabled = btnClearPreviousVisa.Visible = stagesInfo.CanClearPreviousVisa;

            // Претензионная работа с филиалами
            btnCameraNumber.Enabled = btnCameraNumber.Visible = stagesInfo.CanEnterCameraInfo;
            btnPrintAct.Enabled = btnPrintAct.Visible = CanPrintAct;
            cmbPrinters.Enabled = cmbPrinters.Visible = CanPrintAct;

            btnOpenCheckExceptionsLog.Enabled = btnOpenCheckExceptionsLog.Visible = SelectedRow != null && this.canAccessCheckExceptionsLog;

            canPrintInvestigationReport = stagesInfo.CanPrintInvestigationReport;

            btnCheckExternalDocs.Enabled = btnCheckExternalDocs.Visible = SelectedRow != null && this.canCheckExternalDocs;
            btnSetRevision.Enabled = btnSetRevision.Visible = stagesInfo.CanSetRevision;

            var sSetRevision = "Исправить";
            if (SelectedRow != null)
            {
                if (SelectedRow.Status_ID.Equals("110"))
                {
                    if (stagesInfo.CheckCanClientRework())
                        sSetRevision = "Клиенту\nна доработку";
                    else if (stagesInfo.CheckCanShipmentWithoutPromo())
                        sSetRevision = "Отгрузка\nбез промо";
                }
                //else if (SelectedRow.Status_ID.Equals("227"))
                //    sSetRevision = "Исправить";
            }
            btnSetRevision.Text = sSetRevision;

            btnAssignTask.Enabled = btnAssignTask.Visible = stagesInfo.CanAssignTask;
            btnStartTask.Enabled = btnStartTask.Visible = stagesInfo.CanStartTask;
            btnDelayTask.Enabled = btnDelayTask.Visible = stagesInfo.CanDelayTask;
            btnCloseTask.Enabled = btnCloseTask.Visible = stagesInfo.CanCloseTask;

            btnCreateVendorAct.Enabled = btnCreateVendorAct.Visible = stagesInfo.CanCreateVendorAct;
            btnSendVendorAct.Enabled = btnSendVendorAct.Visible = stagesInfo.CanSendVendorAct;

            btnCreateLogisticsComplaintsReport.Enabled = btnCreateLogisticsComplaintsReport.Visible = stagesInfo.CanPrintLogisticsComplaintsReport;

            btnShowRecallNotification.Enabled = btnShowRecallNotification.Visible = stagesInfo.CanShowRecallNotification;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Обновить список претензий".
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BackgroundWorker loadCurrentComplaintsWorker = new BackgroundWorker();
            loadCurrentComplaintsWorker.DoWork += new DoWorkEventHandler(loadCurrentComplaintsWorker_DoWork);
            loadCurrentComplaintsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadComplaintsWorker_RunWorkerCompleted);

            splashForm.ActionText = "Обновление списка претензий...";
            loadCurrentComplaintsWorker.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Загружает в фоне список претензий, используя параметры, переданные в аргументе.
        /// </summary>
        private void loadCurrentComplaintsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var searchCriteria = new ComplaintsSearchParameters() { SearchMode = ComplaintsSearchMode.Simple };
                searchCriteria.SessionID = UserID;
                searchCriteria.DocType = FilterDocType;
                searchCriteria.StatusFrom = FilterStatusFrom;
                searchCriteria.StatusTo = FilterStatusTo;
                searchCriteria.OnlyRequiringVisa = FilterOnlyRequiringVisa;
                searchCriteria.Warehouse = FilterWarehouse;

                this.xdgvComplaints.DataView.FillData(searchCriteria);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск претензий".
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (Dialogs.Complaints.SearchComplaintOptionsForm searchForm = new Dialogs.Complaints.SearchComplaintOptionsForm(UserID, null))
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    BackgroundWorker loadComplaintsWorker = new BackgroundWorker();
                    loadComplaintsWorker.DoWork += new DoWorkEventHandler(loadComplaintsWorker_DoWork);
                    loadComplaintsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadComplaintsWorker_RunWorkerCompleted);

                    splashForm.ActionText = "Поиск претензий...";
                    loadComplaintsWorker.RunWorkerAsync(searchForm);
                    splashForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Загружает в фоне список претензий, используя параметры, переданные в аргументе.
        /// </summary>
        private void loadComplaintsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dialogs.Complaints.SearchComplaintOptionsForm searchForm = (Dialogs.Complaints.SearchComplaintOptionsForm)e.Argument;

            try
            {
                var searchCriteria = new ComplaintsSearchParameters() { SearchMode = ComplaintsSearchMode.Extended };
                searchCriteria.SessionID = UserID;
                searchCriteria.DocID = searchForm.DocID;
                searchCriteria.DocType = searchForm.DocType;
                searchCriteria.ManagerID = searchForm.ManagerID;
                searchCriteria.DebtorID = searchForm.DebtorID;
                searchCriteria.CreatorID = searchForm.CreatorID;
                searchCriteria.FaultEmployeeID = searchForm.FaultEmployeeID;
                searchCriteria.DateFrom = searchForm.DateFrom;
                searchCriteria.DateTo = searchForm.DateTo;
                searchCriteria.ItemID = searchForm.ItemId;
                searchCriteria.ItemName = searchForm.ItemName;
                searchCriteria.LinkedOrderID = searchForm.LinkedOrderID;
                searchCriteria.LinkedInvoiceID = searchForm.LinkedInvoiceID;

                this.xdgvComplaints.DataView.FillData(searchCriteria);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает окончание загрузки в фоне списка претензий.
        /// </summary>
        private void loadComplaintsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
            }
            else
            {
                this.xdgvComplaints.BindData(false);

                //this.xdgvComplaints.AllowFilter = true;
                this.xdgvComplaints.AllowSummary = true;
            }

            splashForm.CloseForce();
        }

        /// <summary>
        /// Выделяет строку в таблице и делает её первой отображаемой (например, после обновления данных).
        /// </summary>
        /// <param name="firstDocID">Идентификатор претензии.</param>
        private void RestoreSelection(long docID)
        {
            xdgvComplaints.SelectRow("Doc_ID", docID.ToString());
            xdgvComplaints.ScrollToSelectedRow();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Прикрепленные файлы".
        /// </summary>
        private void btnShowAttachments_Click(object sender, EventArgs e)
        {
            if (SelectedRow != null)
            {
                using (Dialogs.Complaints.ComplaintAttachmentsForm form = new ComplaintAttachmentsForm(UserID, SelectedRow.First_Doc_ID))
                {
                    form.ShowDialog();
                    RefreshStagesAndButtons();
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Анализ".
        /// </summary>
        private void btnShowAnalysisInfo_Click(object sender, EventArgs e)
        {
            bool needRefresh = false;

            if (SelectedRow != null)
            {
                try
                {
                    Form form = null;

                    //if (SelectedRow.Doc_Type == Constants.CO_DTWH_NTV)
                    //    form = new ComplaintInnerDocAnalysisForm(SelectedRow, UserID, stagesInfo.CanAddTakingRemainsRequest, stagesInfo.CanRequestAttachment);
                    //    //form = new ComplaintWarehouseAnalysisForm(SelectedRow, UserID, stagesInfo.CanAddTakingRemainsRequest, stagesInfo.CanRequestAttachment);
                    //else if (SelectedRow.Doc_Type == Constants.CO_DTWH_DEFECT)
                    //    form = new ComplaintSupplierDefectAnalysisForm(SelectedRow, UserID, stagesInfo.CanAddTakingRemainsRequest, stagesInfo.CanRequestAttachment, stagesInfo.CanAccept);
                    //    //form = new ComplaintWarehouseAnalysisForm(SelectedRow, UserID, stagesInfo.CanAddTakingRemainsRequest, stagesInfo.CanRequestAttachment);

                    if (SelectedRow.Doc_Type == Constants.CO_DTWH_NTV ||
                        SelectedRow.Doc_Type == Constants.CO_DTWH_DEFECT ||
                        SelectedRow.Doc_Type == Constants.CO_DTWH_MANUFACTURERND ||
                        SelectedRow.Doc_Type == Constants.CO_DTWH_ITND ||
                        SelectedRow.Doc_Type == Constants.CO_DTWH_LABEL_ERROR ||
                        SelectedRow.Doc_Type == Constants.CO_DTWH_OVERAGE ||
                        SelectedRow.Doc_Type == Constants.CO_DTWH_ROUTE_SHORTAGE ||
                        SelectedRow.Doc_Type == Constants.CO_DTWH_BOY ||
                        SelectedRow.Doc_Type == Constants.CO_DTWH_CANCEL_REFUSE)
                        form = new ComplaintWarehouseAnalysisForm(SelectedRow, UserID, stagesInfo.CanAddTakingRemainsRequest, stagesInfo.CanRequestAttachment, stagesInfo.CanPrintMedicalRegister);
                    else
                        if (SelectedRow.Doc_Type == Constants.CO_DTPL_PF ||
                            SelectedRow.Doc_Type == Constants.CO_DTPL_PX)
                            form = new ComplaintPalletAnalysisForm(SelectedRow, UserID, stagesInfo.CanAddTakingRemainsRequest, stagesInfo.CanRequestAttachment, stagesInfo.CanPrintMedicalRegister);
                        else
                            form = new ComplaintAnalysisForm(SelectedRow, UserID, stagesInfo.CanAddTakingRemainsRequest, stagesInfo.CanRequestAttachment, stagesInfo.CanPrintMedicalRegister);

                    if (form != null)
                        form.ShowDialog(this);

                    //// Получаем признак необходимости обновления списка претензий (для внутр. заводского брака)
                    //if (form is ComplaintSupplierDefectAnalysisForm)
                    //    needRefresh = (form as ComplaintSupplierDefectAnalysisForm).NeedRefresh;

                    // Получаем признак необходимости обновления списка претензий (для внутрискладских документов)
                    if (form is ComplaintWarehouseAnalysisForm)
                        needRefresh = (form as ComplaintWarehouseAnalysisForm).NeedRefresh;

                    // Получаем признак необходимости обновления списка претензий (для основных документов)
                    if (form is ComplaintAnalysisForm)
                        needRefresh = (form as ComplaintAnalysisForm).NeedRefresh;

                    if (needRefresh)
                    {
                        long docID = SelectedRow.Doc_ID;

                        btnRefresh_Click(this, EventArgs.Empty);
                        RestoreSelection(docID);
                    }

                    RefreshStagesAndButtons();
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Ввести результаты снятия остатков".
        /// </summary>
        private void btnEnterTakingRemainsResults_Click(object sender, EventArgs e)
        {
            if (SelectedRow != null)
            {
                try
                {
                    using (Dialogs.Complaints.EnterTakingRemainsResultsForm form = new Dialogs.Complaints.EnterTakingRemainsResultsForm(SelectedRow, UserID))
                        form.ShowDialog();
                    RefreshStagesAndButtons();
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Корректировать претензию".
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedRow != null)
            {
                //if (SelectedRow.Status_ID != ComplaintsConstants.ComplaintStatusAccepting)
                //{
                //    ShowError("Претензия не находится на статусе 110!");
                //}
                //else
                {
                    try
                    {
                        long docID = SelectedRow.Doc_ID;
                        using (var form = new EditComplaintForm(UserID, SelectedRow, stagesInfo.CanEdit, stagesInfo.CanChangeLocation))
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                btnRefresh_Click(this, EventArgs.Empty);
                                RestoreSelection(docID);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Ввести код виновного сотрудника".
        /// </summary>
        private void btnChangeCommonFaultEmployee_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {

                using (Dialogs.Complaints.EnterFaultEmployeeForm form = new Dialogs.Complaints.EnterFaultEmployeeForm(
                    UserID,
                    selectedRow.IsCommon_Fault_Employee_IDNull() ? 0 : selectedRow.Common_Fault_Employee_ID, selectedRow.Doc_Type, selectedRow.IsDoc_SubtypeNull() ? (string)null : selectedRow.Doc_Subtype, selectedRow.Warehouse_ID, selectedRow.Doc_ID))
                {
                    if (!IsComplaintInterbranch(selectedRow))
                        form.IsDepartmentChoiceEnabled = IsDepartmentChoiceEnabled;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (Data.ComplaintsTableAdapters.QueriesTableAdapter adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
                                adapter.ChangeCommonFaultEmployeeID(UserID, selectedRow.Doc_ID, 
                                    form.FaultEmployeeID.HasValue ? form.FaultEmployeeID.Value : (int?)null,
                                    form.FaultDepartmentID.HasValue ? form.FaultDepartmentID.Value : (int?)null);

                            selectedRow.Common_Fault_Employee_ID = form.FaultEmployeeID.HasValue ? form.FaultEmployeeID.Value : form.FaultDepartmentID.HasValue ? form.FaultDepartmentID.Value : 0;
                            var strPart = form.FaultEmployeeID.HasValue ? "(код " : "(отдел ";
                            selectedRow.Common_Fault_Employee_Name = strPart + selectedRow.Common_Fault_Employee_ID.ToString() + ")";

                            RefreshStagesAndButtons();
                        }
                        catch (Exception exc)
                        {
                            Logger.ShowErrorMessageBox("Не удалось задать виновного: ", exc);
                        }
                    }
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        private bool IsDepartmentChoiceEnabled
        {
            get
            {
                return SelectedRow != null && ComplaintsListWindow.CheckIfDepartmentChoiceEnabled(SelectedRow.Doc_Type);
            }
        }

        public static bool CheckIfDepartmentChoiceEnabled(string docType)
        {
            return ( docType == Constants.CO_DTFL_NTV ||
                     docType == Constants.CO_DTFL_BOY ||
                     docType == Constants.CO_DTFL_ITND ||
                     docType == Constants.CO_DTFL_BOXND ||
                     docType == Constants.CO_DTFL_MANUFACTURERND ||
                     docType == Constants.CO_DTWH_RET_BOY ||
                     docType == Constants.CO_DTPL_PF ||
                     docType == Constants.CO_DTPL_PX ||
                     docType == Constants.CO_DT_W_BOY ||
                     docType == Constants.CO_DT_NTV ||
                     docType == Constants.CO_DTWH_NTV ||
                     docType == Constants.CO_DTWH_NTV_KIUP ||
                     docType == Constants.CO_WEB_NTV ||
                     docType == Constants.CO_DT_OVERAGE ||
                     docType == Constants.CO_DT_BOY);
        }
            

        /// <summary>
        /// Проверка, является ли претензия "межскладской"
        /// </summary>
        /// <param name="pRow">Претензия</param>
        /// <returns>True, если имеет место претензионная работа с филиалами, False в противном случае</returns>
        private bool IsComplaintInterbranch(Complaints.CurrentDocsRow pRow)
        {
            return /*pRow.Doc_Type == "FF" ||*/ pRow.Doc_Type == "BF" || pRow.Doc_Type == "E1" || pRow.Doc_Type == "R1";
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Принять".
        /// </summary>
        private void btnAcceptComplaint_Click(object sender, EventArgs e)
        {
            this.AcceptComplaint();
        }

        private void AcceptComplaint()
        {
            this.AcceptComplaint((long?)null);
        }

        private void AcceptComplaint(long? stageID)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                long docID = selectedRow.Doc_ID;
                try
                {
                    //// Получение прав на игнорирование исключений при проверке претензии
                    //var ignoreDocExceptionsSign = (int?)null;
                    //var canIgnoreDocExceptions = false;

                    //using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                    //    adapter.CanIgnoreCheckDoc(UserID, ref ignoreDocExceptionsSign);

                    //canIgnoreDocExceptions = ignoreDocExceptionsSign.HasValue ? Convert.ToBoolean(ignoreDocExceptionsSign.Value) : false;
                    var canIgnoreDocExceptions = false;

                    using (Data.ComplaintsTableAdapters.CheckDocTableAdapter checkAdapter = new Data.ComplaintsTableAdapters.CheckDocTableAdapter())
                    {
                        checkAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                        Data.Complaints.CheckDocDataTable checkTable = checkAdapter.GetData(selectedRow.Doc_ID, UserID);

                        bool processCheckResults = false;
                        foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                        {
                            if (checkRow.IsWarning || checkRow.IsError)
                            {
                                processCheckResults = true;
                                break;
                            }
                        }

                        bool allWarningsAccepted = true; // признак, показывающий, что пользователь согласился со всеми предупреждениями

                        if (processCheckResults)
                        {
                            ComplaintCheckErrorsForm dlgComplaintCheckErrorsForm = null;

                            //  Игнорирование проверок при создании претензии
                            if (canIgnoreDocExceptions && (dlgComplaintCheckErrorsForm = new ComplaintCheckErrorsForm(checkTable)).ShowDialog() == DialogResult.OK)
                            {
                                using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                    //adapter.IgnoreDocExceptions(UserID, docID, dlgComplaintCheckErrorsForm.Comment);
                                    adapter.ChangeDocExceptionsStatus(UserID, docID, "110", dlgComplaintCheckErrorsForm.Comment, (long?)null);

                                allWarningsAccepted = true;
                            }
                            else
                            {
                                using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                    adapter.ChangeDocExceptionsStatus(UserID, docID, "198", (string)null, (long?)null);

                                foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                {
                                    if (checkRow.IsError)
                                        throw new OperationCanceledException(checkRow.MessageText);
                                }

                                foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                {
                                    if (checkRow.IsWarning && MessageBox.Show(checkRow.MessageText + Environment.NewLine + Environment.NewLine + "Вы хотите продолжить принятие претензии?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                                    {
                                        allWarningsAccepted = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (allWarningsAccepted)
                        {
                            var reasonID = (int?)null;
                            var reason = (string)null;
                            var canAccept = false;

                            if (stagesInfo.CanAcceptRework)
                            {
                                using (var dlgSelectReworkReasons = new SelectReworkReasonsForm { DocID = docID, StageID = stageID, UserID = this.UserID, Title = "Укажите причину принятия претензии" })
                                    if (dlgSelectReworkReasons.ShowDialog() == DialogResult.OK)
                                    {
                                        reasonID = dlgSelectReworkReasons.ReasonID;
                                        reason = dlgSelectReworkReasons.Reason;
                                        canAccept = true;
                                    }
                            }
                            else
                            {
                                using (EnterStringValueForm dlgEnterStringValue = new EnterStringValueForm("Комментарий", "Введите комментарий к принимаемой претензии:", string.Empty) { AllowEmptyValue = true })
                                    if (dlgEnterStringValue.ShowDialog() == DialogResult.OK)
                                    {
                                        reasonID = (int?)null;
                                        reason = dlgEnterStringValue.Value;
                                        canAccept = true;
                                    }
                            }

                            if (canAccept)
                            {
                                if (CheckComplaint(docID))
                                {
                                    if (stagesInfo.NeedAttachments)
                                    {
                                        if (MessageBox.Show("Чи є в наявності наступні документи?\n\n - Акт відбору зразків\n - Рахунок по заяві", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                        {
                                            // открыть форму вложений и проверять в цикле добавление нужных документов
                                        }
                                        else
                                        { 
                                        
                                        }
                                    }

                                    taCurrentDocs.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                                    taCurrentDocs.ChangeDocStage(UserID, docID, ComplaintsConstants.StageResultAccepted, reason, reasonID, stageID);
                                }

                                //btnRefresh_Click(this, EventArgs.Empty);
                                xdgvComplaints.DataGrid.Rows.Remove(xdgvComplaints.DataGrid.SelectedRows[0]);
                                RestoreSelection(docID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Во время принятия претензии (DocID = " + docID.ToString() + ") возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }


        /// <summary>
        /// Проверка, можно ли визировать претензию
        /// </summary>
        /// <param name="pDocId">Идентификатор проверяемой претензии</param>
        /// <returns>True, если претензию можно визировать, False если нельзя</returns>
        private bool CheckComplaint(long pDocId)
        {
            try
            {
                taCurrentDocs.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                taCurrentDocs.Check_Complaints(pDocId, UserID);
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Нельзя визировать претензию: " + Environment.NewLine + exc.Message, "Визирование претензии",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Отклонить".
        /// </summary>
        private void btnDeclineComplaint_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                long docID = selectedRow.Doc_ID;
                var stateID = selectedRow.Status_ID;

                try
                {
                    var reasonID = (int?)null;
                    var reason = (string)null;
                    var canDecline = false;

                    //if (stateID.Equals("226")) // отклонение претензии на 226-м статусе
                    if (stagesInfo.CanDeclineRework)
                    {
                        using (var dlgSelectReworkReasons = new SelectReworkReasonsForm { DocID = docID, UserID = this.UserID, Title = "Укажите причину отклонения претензии" })
                            if (dlgSelectReworkReasons.ShowDialog() == DialogResult.OK)
                            {
                                reasonID = dlgSelectReworkReasons.ReasonID;
                                reason = dlgSelectReworkReasons.Reason;
                                canDecline = true;
                            }
                    }
                    else
                    {
                        using (EnterStringValueForm dlgEnterStringValue = new EnterStringValueForm("Комментарий", "Введите комментарий к отклоняемой претензии:", string.Empty))
                            if (dlgEnterStringValue.ShowDialog() == DialogResult.OK)
                            {
                                reasonID = (int?)null;
                                reason = dlgEnterStringValue.Value;
                                canDecline = true;
                            }
                    }

                    if (canDecline)
                    {
                        if (CheckComplaint(docID))
                        {
                            taCurrentDocs.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                            taCurrentDocs.ChangeDocStage(UserID, docID, ComplaintsConstants.StageResultDeclined, reason, reasonID, (long?)null);
                        }

                        //btnRefresh_Click(this, EventArgs.Empty);
                        xdgvComplaints.DataGrid.Rows.Remove(xdgvComplaints.DataGrid.SelectedRows[0]);
                        RestoreSelection(docID);
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Во время отклонения выбранной претензии (DocID = " + docID.ToString() +
                        ") возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Продлить".
        /// </summary>
        private void btnExtendComplaint_Click(object sender, EventArgs e)
        {
               Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
               if (selectedRow != null)
               {
                   long docID = selectedRow.Doc_ID;
                   try
                   {
                       taCurrentDocs.ChangeVisaExpirationDate(UserID, docID);

                       btnRefresh_Click(this, EventArgs.Empty);
                       RestoreSelection(docID);
                   }
                   catch (Exception ex)
                   {
                       ShowError("Во время продления визы по выбранной претензии (DocID = " + docID.ToString() +
                       ") возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                   }
               }
               else
               {
                   ShowError("Претензия не выбрана!");
               }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Отклонить предыдущую визу".
        /// </summary>
        private void btnClearPreviousVisa_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                long docID = selectedRow.Doc_ID;
                try
                {
                    using (EnterStringValueForm form = new EnterStringValueForm("Комментарий", "Введите комментарий к предыдущей отклоняемой визе по претензии:", string.Empty))
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            taCurrentDocs.ClearPreviousVisa(UserID, docID, form.Value);

                            btnRefresh_Click(this, EventArgs.Empty);
                            RestoreSelection(docID);
                        }
                }
                catch (Exception ex)
                {
                    ShowError("Во время отклонения предыдущей визы по выбранной претензии (DocID = " + docID.ToString() +
                        ") возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Примечание" (сохранить примечание и отложить визу).
        /// </summary>
        private void btnComment_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                long docID = selectedRow.Doc_ID;
                try
                {
                    //// Получение прав на игнорирование исключений при проверке претензии
                    //var ignoreDocExceptionsSign = (int?)null;
                    //var canIgnoreDocExceptions = false;

                    //using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                    //    adapter.CanIgnoreCheckDoc(UserID, ref ignoreDocExceptionsSign);

                    //canIgnoreDocExceptions = ignoreDocExceptionsSign.HasValue ? Convert.ToBoolean(ignoreDocExceptionsSign.Value) : false;
                    var canIgnoreDocExceptions = false;

                    using (Data.ComplaintsTableAdapters.CheckDocTableAdapter checkAdapter = new Data.ComplaintsTableAdapters.CheckDocTableAdapter())
                    {
                        Data.Complaints.CheckDocDataTable checkTable = checkAdapter.GetData(selectedRow.Doc_ID, UserID);

                        bool processCheckResults = false;
                        foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                        {
                            if (checkRow.IsWarning || checkRow.IsError)
                            {
                                processCheckResults = true;
                                break;
                            }
                        }

                        bool allWarningsAccepted = true; // признак, показывающий, что пользователь согласился со всеми предупреждениями

                        if (processCheckResults)
                        {
                            ComplaintCheckErrorsForm dlgComplaintCheckErrorsForm = null;

                            //  Игнорирование проверок при создании претензии
                            if (canIgnoreDocExceptions && (dlgComplaintCheckErrorsForm = new ComplaintCheckErrorsForm(checkTable)).ShowDialog() == DialogResult.OK)
                            {
                                using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                    //adapter.IgnoreDocExceptions(UserID, docID, dlgComplaintCheckErrorsForm.Comment);
                                    adapter.ChangeDocExceptionsStatus(UserID, docID, "110", dlgComplaintCheckErrorsForm.Comment, (long?)null);

                                allWarningsAccepted = true;
                            }
                            else
                            {
                                using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                    adapter.ChangeDocExceptionsStatus(UserID, docID, "198", (string)null, (long?)null);

                                foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                {
                                    if (checkRow.IsError)
                                        throw new OperationCanceledException(checkRow.MessageText);
                                }

                                foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                {
                                    if (checkRow.IsWarning && MessageBox.Show(checkRow.MessageText + Environment.NewLine + Environment.NewLine +
                                            "Вы хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                                    {
                                        allWarningsAccepted = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (allWarningsAccepted)
                        {
                            using (EnterStringValueForm form = new EnterStringValueForm("Комментарий", "Введите комментарий к отложенной визе:", string.Empty))
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    taCurrentDocs.ChangeDocStage(UserID, selectedRow.Doc_ID, ComplaintsConstants.StageResultDelayed, form.Value, (int?)null, (long?)null);

                                    RefreshStagesAndButtons();
                                }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Во время изменения визы по претензии возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Доставка опытного образца".
        /// </summary>
        private void btnRequestSample_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                if (MessageBox.Show("Вы действительно хотите запросить доставку опытных образцов по выбранной претензии?",
                    "Подтверждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long docID = selectedRow.Doc_ID;
                    try
                    {
                        using (Data.ComplaintsTableAdapters.QueriesTableAdapter adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
                        {
                            adapter.AddSampleRequest(UserID, docID);
                            taCurrentDocs.ChangeDocStatus(UserID, docID, ComplaintsConstants.ComplaintStatusSamplesDelivery, ComplaintsConstants.ComplaintStatusAccepting);

                            btnRefresh_Click(this, EventArgs.Empty);
                            RestoreSelection(docID);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Во время создания запроса на доставку опытных образцов по выбранной претензии (DocID = " + docID.ToString() +
                            " ) возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                    }
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Отклонено заводом".
        /// </summary>
        private void btnDeclineByFactory_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                long docID = selectedRow.Doc_ID;
                try
                {
                    //// Получение прав на игнорирование исключений при проверке претензии
                    //var ignoreDocExceptionsSign = (int?)null;
                    //var canIgnoreDocExceptions = false;

                    //using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                    //    adapter.CanIgnoreCheckDoc(UserID, ref ignoreDocExceptionsSign);

                    //canIgnoreDocExceptions = ignoreDocExceptionsSign.HasValue ? Convert.ToBoolean(ignoreDocExceptionsSign.Value) : false;
                    var canIgnoreDocExceptions = false;

                    using (Data.ComplaintsTableAdapters.CheckDocTableAdapter checkAdapter = new Data.ComplaintsTableAdapters.CheckDocTableAdapter())
                    {
                        Data.Complaints.CheckDocDataTable checkTable = checkAdapter.GetData(selectedRow.Doc_ID, UserID);

                        bool processCheckResults = false;
                        foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                        {
                            if (checkRow.IsWarning || checkRow.IsError)
                            {
                                processCheckResults = true;
                                break;
                            }
                        }

                        bool allWarningsAccepted = true; // признак, показывающий, что пользователь согласился со всеми предупреждениями

                        if (processCheckResults)
                        {
                            ComplaintCheckErrorsForm dlgComplaintCheckErrorsForm = null;

                            //  Игнорирование проверок при создании претензии
                            if (canIgnoreDocExceptions && (dlgComplaintCheckErrorsForm = new ComplaintCheckErrorsForm(checkTable)).ShowDialog() == DialogResult.OK)
                            {
                                using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                    //adapter.IgnoreDocExceptions(UserID, docID, dlgComplaintCheckErrorsForm.Comment);
                                    adapter.ChangeDocExceptionsStatus(UserID, docID, "110", dlgComplaintCheckErrorsForm.Comment, (long?)null);

                                allWarningsAccepted = true;
                            }
                            else
                            {
                                using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                    adapter.ChangeDocExceptionsStatus(UserID, docID, "198", (string)null, (long?)null);

                                foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                {
                                    if (checkRow.IsError)
                                        throw new OperationCanceledException(checkRow.MessageText);
                                }

                                foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                {
                                    if (checkRow.IsWarning && MessageBox.Show(checkRow.MessageText + Environment.NewLine + Environment.NewLine +
                                            "Вы хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                                    {
                                        allWarningsAccepted = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (allWarningsAccepted)
                        {
                            using (EnterStringValueForm form = new EnterStringValueForm("Комментарий", "Введите комментарий к визе \"завод отклонил\":", string.Empty))
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    taCurrentDocs.ChangeDocStage(UserID, selectedRow.Doc_ID, ComplaintsConstants.StageResultDeclinedByFactory, form.Value, (int?)null, (long?)null);

                                    RefreshStagesAndButtons();
                                }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Во время отклонения претензии возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Письмо клиенту отправлено".
        /// </summary>
        private void btnSetClientLetterSent_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                if (MessageBox.Show("Вы действительно хотите установить претензии признак \"Письмо клиенту отправлено\"?",
                    "Подтверждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (Data.ComplaintsTableAdapters.QueriesTableAdapter adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
                    {
                        adapter.SetClientLetterSent(UserID, selectedRow.Doc_ID);
                        selectedRow.Client_Letter_Sent = true;
                    }
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Восстановить отклоненную претензию".
        /// </summary>
        private void btnRestoreDeclinedComplaint_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                if (MessageBox.Show("Вы действительно хотите восстановить отклоненную претензию?", "Подтверждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long docID = selectedRow.Doc_ID;
                    try
                    {
                        //// Получение прав на игнорирование исключений при проверке претензии
                        //var ignoreDocExceptionsSign = (int?)null;
                        //var canIgnoreDocExceptions = false;

                        //using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                        //    adapter.CanIgnoreCheckDoc(UserID, ref ignoreDocExceptionsSign);

                        //canIgnoreDocExceptions = ignoreDocExceptionsSign.HasValue ? Convert.ToBoolean(ignoreDocExceptionsSign.Value) : false;
                        var canIgnoreDocExceptions = false;

                        using (Data.ComplaintsTableAdapters.CheckDocTableAdapter checkAdapter = new Data.ComplaintsTableAdapters.CheckDocTableAdapter())
                        {
                            Data.Complaints.CheckDocDataTable checkTable = checkAdapter.GetData(selectedRow.Doc_ID, UserID);

                            bool processCheckResults = false;
                            foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                            {
                                if (checkRow.IsWarning || checkRow.IsError)
                                {
                                    processCheckResults = true;
                                    break;
                                }
                            }

                            bool allWarningsAccepted = true; // признак, показывающий, что пользователь согласился со всеми предупреждениями

                            if (processCheckResults)
                            {
                                ComplaintCheckErrorsForm dlgComplaintCheckErrorsForm = null;

                                //  Игнорирование проверок при создании претензии
                                if (canIgnoreDocExceptions && (dlgComplaintCheckErrorsForm = new ComplaintCheckErrorsForm(checkTable)).ShowDialog() == DialogResult.OK)
                                {
                                    using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                        //adapter.IgnoreDocExceptions(UserID, docID, dlgComplaintCheckErrorsForm.Comment);
                                        adapter.ChangeDocExceptionsStatus(UserID, docID, "110", dlgComplaintCheckErrorsForm.Comment, (long?)null);

                                    allWarningsAccepted = true;
                                }
                                else
                                {
                                    using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                        adapter.ChangeDocExceptionsStatus(UserID, docID, "198", (string)null, (long?)null);

                                    foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                    {
                                        if (checkRow.IsError)
                                            throw new OperationCanceledException(checkRow.MessageText);
                                    }

                                    foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                    {
                                        if (checkRow.IsWarning && MessageBox.Show(checkRow.MessageText + Environment.NewLine + Environment.NewLine +
                                                "Вы хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                                        {
                                            allWarningsAccepted = false;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (allWarningsAccepted)
                            {
                                using (EnterStringValueForm form = new EnterStringValueForm("Комментарий", "Введите комментарий к восстанавливаемой претензии:", string.Empty))
                                    if (form.ShowDialog() == DialogResult.OK)
                                    {
                                        taCurrentDocs.RestoreDeclinedDoc(UserID, selectedRow.Doc_ID, form.Value);
                                        RefreshStagesAndButtons();
                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Во время восстановления выбранной претензии (DocID = " + docID.ToString() + ") возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                    }
                }
            }
            else
            {
                ShowError("Претензия не выбрана!");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Печать листов размещения".
        /// </summary>
        private void btnPrintListPlacement_Click(object sender, EventArgs e)
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                long docID = selectedRow.Doc_ID;
                try
                {
                    using (Data.ComplaintsTableAdapters.ReportListPlacementTableAdapter tableAdapter = new Data.ComplaintsTableAdapters.ReportListPlacementTableAdapter())
                    {
                        Data.Complaints.ReportListPlacementDataTable table = tableAdapter.GetData(docID);
                        using (Reports.ComplaintListPlacement report = new WMSOffice.Reports.ComplaintListPlacement())
                        {
                            report.SetDataSource((System.Data.DataTable)table);
                            //report.PrintOptions.PrinterName = (string)cbPrinters.SelectedItem;
                            using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                            {
                                form.ReportDocument = report;
                                form.ShowDialog();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Во время печати листов размещения претензии (DocID = " + docID.ToString() +
                        ") возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
        }

        /// <summary>
        /// Запуск формы построчного визирования для выбранной претензии
        /// </summary>
        private void btnLineSightOfComplaint_Click(object sender, EventArgs e)
        {
            // Чтобы открыть окно построчного визирования для претензии, нужно сначала выбрать эту претензию
            if (SelectedRow == null)
            {
                ShowError("Претензия не выбрана!");
                return;
            }

            // Если же выбрана какая-нибудь претензия, то для нее можно открыть окно построчного визирования
            ShowLineSightWindowForCurrentComplaint();
        }

        /// <summary>
        /// Для выбранной претензии в списке открывает окно построчного визирования
        /// </summary>
        private void ShowLineSightWindowForCurrentComplaint()
        {
            try
            {
                using (LineSightComplaintForm form = new LineSightComplaintForm(SelectedRow, UserID))
                    form.ShowDialog();
                RefreshStagesAndButtons();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Проверка можно ли произвести печать листов размещения.
        /// </summary>
        private bool CheckIfCanPrintListPlacement()
        {
            Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                long docID = selectedRow.Doc_ID;
                try
                {
                    using (Data.ComplaintsTableAdapters.QueriesTableAdapter adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
                    {
                        //object ooo = adapter.CheckIfCanPrintListPlacement(UserID, docID);
                        return (bool)adapter.CheckIfCanPrintListPlacement(UserID, docID);
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }

            return false;
        }

        /// <summary>
        /// Закрашивает в красный цвет строку претензии, если в ней количество товара нулевое
        /// </summary>
        private void dgvDocRequestDetails_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvDocRequestDetails.Rows[e.RowIndex].Cells["quantityDataGridViewTextBoxColumn"].Value.ToString() == "0")
                dgvDocRequestDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        }

        /// <summary>
        /// Выводим форму с историей визирования по строке
        /// </summary>
        private void dgvDocRequestDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (SelectedRow.Doc_Type.Equals(Constants.CO_DT_RESIGN_INVOICE, StringComparison.InvariantCultureIgnoreCase) ||
                    SelectedRow.Doc_Type.Equals(Constants.CO_DTWH_RET_ACT, StringComparison.InvariantCultureIgnoreCase))
                    return;

                var itemHistoryForm = new ComplaintItemHistoryForm(SelectedRow.Doc_ID, UserID, Convert.ToInt64(dgvDocRequestDetails.Rows[e.RowIndex].Cells["detailIDDataGridViewTextBoxColumn"].Value), stagesInfo.CanChangeFactLotn);
                itemHistoryForm.IsUserOKVisible = SelectedRow.Doc_Type.Equals(Constants.CO_DT_REFUSE) && SelectedRow.Doc_Subtype.Equals("OK");
                if (itemHistoryForm.ShowDialog() == DialogResult.OK)
                    xdgvComplaints_OnRowSelectionChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #region ЭКСПОРТ В EXCEL

        /// <summary>
        /// Экспорт в Excel данных по претензиям
        /// </summary>
        private void btnExportComplaintsToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xdgvComplaints.ExportToExcel("Экспорт списка претензий", "список претензий", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Экспорт в Excel претензий по дебитору
        /// </summary>
        private void btnExportComplaintsForDebitor_Click(object sender, EventArgs e)
        {
            var window = new ComplaintsForDebitorsForm(UserID);
            if (window.ShowDialog(this) != DialogResult.OK)
                return;

            var complaints = GetComplaintsByDebitor(window.DebtorID, window.DateFrom, window.DateTo, window.OnlyOpened);
            if (complaints == null)
                return;

            var message = ExportHelper.ExportDataTableToExcel(complaints,
                new string[] { "№ претензии", "Название претензии", "Создана", "Код дебитора", "Наименование клиента", 
                "Название товара", "Серия", "Кол-во", "Цена", "Сумма", "№ накладной", "Дата накладной", "Кем создана", "Адрес клиента" },
                new string[] { "Doc_Number", "Doc_Type", "Date_Created", "Debitor_ID", "Debitor", "Item_Name", "Vendor_Lot", "Quantity",
                    "Cost", "Amount_UAH", "Invoice_Number", "InvoiceDate", "Employee_Name", "Source_Address" },
                "Экспорт претензий по дебитору", String.Format("список претензий по дебитору {0} за период с {1} по {2}",
                window.DebtorID, window.DateFrom.ToShortDateString(), window.DateTo.ToShortDateString()), true);
            if (!String.IsNullOrEmpty(message))
                Logger.ShowErrorMessageBox(String.Format("Во время экспорта в Excel возникла ошибка:\n{0}", message));
        }

        /// <summary>
        /// Получение таблицы с претензиями по заданному дебитору за заданный период
        /// </summary>
        /// <param name="pDebitorID">Идентификатор дебитора</param>
        /// <param name="pDateFrom">Начало периода</param>
        /// <param name="pDateTo">Конец периода</param>
        /// <param name="pOnlyOpened">True, если нужно загрузить только открытые претензии, False если нужно загрузить
        /// все претензии по дебитору за период</param>
        /// <returns>Таблица с претензиями по заданному дебитору за заданный период</returns>
        private Complaints.CurrentDocs_byDebitorDataTable GetComplaintsByDebitor(int pDebitorID, DateTime pDateFrom, DateTime pDateTo, bool pOnlyOpened)
        {
            try
            {
                using (var adapter = new CurrentDocs_byDebitorTableAdapter())
                    return adapter.GetData(UserID, pDebitorID, pDateFrom, pDateTo, pOnlyOpened);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список претензий по дебитору за период: ", exc);
                return null;
            }
        }

        /// <summary>
        /// Экспорт в Excel позиций претензии
        /// </summary>
        private void btnExportCoDetailsForHandler_Click(object sender, EventArgs e)
        {
            var details = GetComplaintDetailsForHandler(UserID, SelectedRow.Doc_ID);
            if (details == null)
                return;

            var message = ExportHelper.ExportDataTableToExcel(details,
                new string[] { "Код дебитора", "Код ТТ", "Код ТТ факт", "Номер накладной", "Дата накладной", "Код товара", "Наименование товара", "Серия", "Количество", "Цена без НДС", "Сумма без НДС", "Сумма с НДС", "НДС" },
                    new string[] { "Debitor_ID", "Delivery_ID", "Fact_Delivery_ID", "Invoice_Number", "Invoice_Date", "Item_ID", "Item_Name", "Vendor_Lot", "Quantity", "Price_Without_NDS", "Sum_Without_NDS", "Sum_With_NDS", "Tax_Rate" },
                "Экспорт позиций претензии", String.Format("Позиции претензии №{0}", SelectedRow.First_Doc_ID), true);
            if (!String.IsNullOrEmpty(message))
                Logger.ShowErrorMessageBox(String.Format("Во время экспорта в Excel возникла ошибка:\n{0}", message));
        }

        /// <summary>
        /// Получение таблицы со строками претензии в таком формате, который можно будет потом загрузить в обработчик автосоздания претензии
        /// </summary>
        /// <param name="pSessionID">Код сессии пользователя</param>
        /// <param name="pDocID"></param>
        /// <returns>Таблица со строками претензии в формате, допустимом для автообработчика</returns>
        private static Complaints.CO_Get_Complaint_Rows_For_HandlerDataTable GetComplaintDetailsForHandler(long pSessionID, long pDocID)
        {
            try
            {
                using (var adapter = new CO_Get_Complaint_Rows_For_HandlerTableAdapter())
                    return adapter.GetData(pSessionID, pDocID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить строки претензии: ", exc);
                return null;
            }
        }

        #endregion

        #region ЭКСПОРТ В EXCEL ИСТОРИИ ВИЗИРОВАНИЯ ПОЗИЦИЙ ПРЕТЕНЗИИ

        /// <summary>
        /// Экспорт в Excel истории визирования позиций претензии
        /// </summary>
        private void btnExportComplaintDetailsToExcel_Click(object sender, EventArgs e)
        {
            var dialog = CreateExportDetailsToExcelDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportComplaintDetailsToExcel(dialog.FileName, complaints.DocRequestDetails);
                    Process.Start(dialog.FileName);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Во время экспорта истории визирования позиций претензии в Excel возникла ошибка: " + exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Создает диалоговое окно с выбором названия и местоположения Excel-файла с историей визирования позиций претензии
        /// </summary>
        /// <returns>Диалоговое окно с выбором названия и местоположения Excel-файла с историей визирования позиций претензии</returns>
        private SaveFileDialog CreateExportDetailsToExcelDialog()
        {
            DateTime now = DateTime.Now;
            return new SaveFileDialog()
            {
                FileName = String.Format("{0}{1}{2}{3}{4}{5}-история визирования позиций претензии", now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0')),
                Title = "Экспорт истории визирования претензии",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Текстовый файл с разделителями (*.csv)|*.csv",
                FilterIndex = 0,
                AddExtension = true,
                DefaultExt = "csv"
            };
        }

        /// <summary>
        /// Экспорт истории визирования позиций претензии в заданный CSV-файл
        /// </summary>
        /// <param name="pFilePath">Путь к CSV-файлу, куда нужно экспортировать историю визирования позиций претензии</param>
        /// <param name="pDetailsTable">DatagridView с позициями претензии, которые нужно экспортировать</param>
        private void ExportComplaintDetailsToExcel(string pFilePath, Complaints.DocRequestDetailsDataTable pDetailsTable)
        {
            using (var sw = new StreamWriter(pFilePath, false, Encoding.Default))
            {
                // Запишем заголовки
                sw.Write("\"Код\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write("\"Название товара\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write("\"Серия\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write("\"Группа пользователей\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write("\"Результат\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write("\"Комментарий\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write("\"Дата просрочки\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write("\"Сотрудники\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write("\"Дата изменения\"");
                sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                sw.Write(sw.NewLine);

                // Запись строк в файл
                foreach (Complaints.DocRequestDetailsRow row in pDetailsTable.Rows)
                {
                    // Получаем историю визирования претензии
                    Complaints.StagesDetailsHistoryCurrentItemDataTable table;
                    using (var adapter = new StagesDetailsHistoryCurrentItemTableAdapter())
                        table = adapter.GetData(UserID, row.Doc_ID, row.Detail_ID);
                    foreach (Complaints.StagesDetailsHistoryCurrentItemRow itemRow in table)
                    {
                        sw.Write(row.IsItem_IDNull() ? String.Empty : row.Item_ID.ToString());
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(row.IsItem_NameNull() ? String.Empty : row.Item_Name);
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(row.IsVendor_Lot_FactNull() ? String.Empty : row.Vendor_Lot_Fact);
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(itemRow.IsGroup_NameNull() ? String.Empty : itemRow.Group_Name);
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(itemRow.IsStage_Result_IDNull() ? String.Empty : GetResultNameByStageResultId(itemRow.Stage_Result_ID));
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(itemRow.IsCommentNull() ? String.Empty : itemRow.Comment);
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(itemRow.IsExpiration_DateNull() ? String.Empty : itemRow.Expiration_Date.ToShortDateString());
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(itemRow.IsUsers_UpdatedNull() ? String.Empty : itemRow.Users_Updated);
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(itemRow.IsDate_UpdatedNull() ? String.Empty : itemRow.Date_Updated.ToShortDateString());
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        sw.Write(sw.NewLine);
                    }
                }

                sw.Close();
            }
        }

        /// <summary>
        /// Выражает текстом результат визирования
        /// </summary>
        /// <param name="pStageResultId">Идентификатор результата визирования</param>
        /// <returns>Строка-результат визирования</returns>
        private static string GetResultNameByStageResultId(long pStageResultId)
        {
            if (pStageResultId == 2 || pStageResultId == 4)
                return "Отрицательная виза";
            if (pStageResultId == 1 || pStageResultId == 5)
                return "Положительная виза";
            if (pStageResultId == 8)
                return "Нужна виза";

            return "Результат этапа не определен";
        }

        #endregion

        private void Merge_Click(object sender, EventArgs e)
        {
            using (var frm = new ComplaintMergeForm(UserID) { CurrentRow = SelectedRow, Owner = this, FilterWarehouse = FilterWarehouse })
            {
                frm.ShowDialog();

                if (!xdgvComplaints.HasRows)
                    return;

                xdgvComplaints.DataGrid.Rows[xdgvComplaints.DataGrid.SelectedRows[0].Index].Cells[dgvcHasLink.Index].Value = emptyIcon;

                taDocRequestDetails.Fill(complaints.DocRequestDetails, UserID, SelectedRow == null ? (long?)null : SelectedRow.Doc_ID);

                foreach (DataGridViewRow row in dgvDocRequestDetails.Rows)
                {
                    var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.DocRequestDetailsRow;

                    if (!dataRow.IsisLinkedNull() && dataRow.isLinked == 1)
                    {
                        xdgvComplaints.DataGrid.Rows[xdgvComplaints.DataGrid.SelectedRows[0].Index].Cells[dgvcHasLink.Index].Value = MergeStatusImage;
                        return;
                    }
                }
            }
        }

        private void dgvDocRequestDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != clmHasAttach.Index)
                return;

            var row = (dgvDocRequestDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.DocRequestDetailsRow;
            if (row == null)
                return;
            using (ComplaintAttachmentForm frm = new ComplaintAttachmentForm
                (row.IsimgRegisterTemperatureNull() ? null : row.imgRegisterTemperature) { Owner = this, ReadOnly = true })
            {
                if (frm.ShowDialog() == DialogResult.Cancel)
                    return;
            }
        }

        //WMS-2615 Реализовать возможность перепечатки актов приема-передачи товара по отклоненной претензии
        private void btnPrintAcceptanceCert_Click(object sender, EventArgs e)
        {
            if (SelectedRow == null)
                return;

            try
            {
                using (AcceptanceCertTableAdapter dta = new AcceptanceCertTableAdapter())
                {
                    ComplaintsExt.AcceptanceCertDataTable retData = dta.GetData(SelectedRow.Doc_ID);
                    if (retData != null && retData.Rows.Count > 0)
                        using (AcceptanceCertificateReport report = new AcceptanceCertificateReport())
                        {
                            byte[] barCode = null;

                            foreach (ComplaintsExt.AcceptanceCertRow row in retData.Rows)
                            {
                                if (barCode == null)
                                {
                                    BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                                    barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Medium;
                                    barCodeCtrl.BarCodeHeight = 110;
                                    barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 30, FontStyle.Bold);
                                    barCodeCtrl.ShowFooter = true;
                                    barCodeCtrl.BarCode = row.BarCode;
                                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                                    {
                                        barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                                        barCode = ms.ToArray();
                                    }
                                }
                                row.BarCode_Image = barCode;
                            }
                            report.SetDataSource((DataTable)retData);
                            using (ReportForm form = new ReportForm() { ReportDocument = report })
                                form.ShowDialog();
                        }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Ошибка печати акта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmDefects_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Сформировать запрос на подтверждение заводского брака?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                    adapter.ConfirmDefects(this.UserID, SelectedRow.Doc_ID);

                RefreshStagesAndButtons();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #region ПРЕТЕНЗИОННАЯ РАБОТА С ФИЛИАЛАМИ

        /// <summary>
        /// Задание номера камеры, под которой проводился поштучный контроль товара и даты/времени обнаружения проблемы
        /// </summary>
        private void btnCameraNumber_Click(object sender, EventArgs e)
        {
            var window = new CameraNumberAndDateFrom(UserID, SelectedRow.Doc_ID);
            window.ShowDialog(this);
        }

        /// <summary>
        /// Печать акта по претензии (на филиальные претензии создаются соответствующие акты)
        /// </summary>
        private void btnPrintAct_Click(object sender, EventArgs e)
        {
            var prd = new PrintDocsThread();
            prd.ReportProvider = new ComplaintsActReportProvider(UserID, ComplaintActsReportProviderMode.ByComplaint);
            var parameters = new PrintDocsParameters
            {
                PrinterName = cmbPrinters.SelectedItem.ToString(),
                Docs = new DataRow[1] { SelectedRow }
            };
            prd.PrintDocumentsAsynch(parameters);
        }

        #endregion

        private void btnSetShortageOnDriver_Click(object sender, EventArgs e)
        {
             Data.Complaints.CurrentDocsRow selectedRow = SelectedRow;
             if (selectedRow != null)
             {
                 var selector = new GuiltyEmployeesSelectionControl()
                 {
                     SessionID = this.UserID,
                     DocID = selectedRow.Doc_ID,
                     DocType = selectedRow.Doc_Type,
                     DepartmentID = 340, // отдел "Экспедиция"
                     CallMode = 0
                 };

                 var dlgSelector = new DialogForm();
                 dlgSelector.Height = 250;
                 dlgSelector.Width = 320;
                 dlgSelector.Text = "Выбор виновного сотрудника";
                 dlgSelector.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                 dlgSelector.StartPosition = FormStartPosition.CenterScreen;
                 dlgSelector.Controls.Add(selector);

                 selector.Left = 0;
                 selector.Width = dlgSelector.OptionsPanel.Width;
                 selector.Top = 0;
                 selector.Height = dlgSelector.OptionsPanel.Top;
                 selector.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

                 selector.Initialize();
                 selector.Value = selectedRow.IsCommon_Fault_Employee_IDNull() || selectedRow.Common_Fault_Employee_ID == 0 ? (object)DBNull.Value : selectedRow.Common_Fault_Employee_ID;

                 dlgSelector.BeginShown += delegate(object s, EventArgs ea)
                 {
                     if (selector.AutoSelect)
                     {
                         dlgSelector.DialogResult = DialogResult.OK;
                         dlgSelector.Close();
                     }
                     else
                     {
                         selector.Focus();
                     }
                 };

                 dlgSelector.FormClosing += delegate(object s, FormClosingEventArgs ea)
                 {
                     if (dlgSelector.DialogResult == DialogResult.OK)
                     {
                         var lst = selector.Value.Equals(DBNull.Value) ? string.Empty : selector.Value.ToString();
                         if (lst.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
                         {
                             MessageBox.Show("Выбрать можно только одного сотрудника!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                             ea.Cancel = true;
                         }
                     }
                 };

                 if (dlgSelector.ShowDialog() == DialogResult.OK)
                 {
                     try
                     {
                         var employeeID = (selector.Value.Equals(DBNull.Value) ? (int?)null : Convert.ToInt32(selector.Value)) ?? 0;
                         if (!employeeID.Equals(0))
                         {
                             using (Data.ComplaintsTableAdapters.QueriesTableAdapter adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
                                 adapter.ChangeCommonFaultEmployeeID(UserID, selectedRow.Doc_ID, employeeID, (int?)null);

                             if (selector.AutoSelect)
                             {
                                 var employeeName = selector.GetEmployeeName(employeeID);
                                 MessageBox.Show(string.Format("Недостача была автоматически списана на водителя\r\n({0}) {1}.", employeeID, employeeName), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                             }

                             selectedRow.Common_Fault_Employee_ID = employeeID;
                             selectedRow.Common_Fault_Employee_Name = string.Format("(код {0})", employeeID);

                             RefreshStagesAndButtons();
                         }
                     }
                     catch (Exception exc)
                     {
                         Logger.ShowErrorMessageBox("Не удалось задать виновного водителя: ", exc);
                     }
                 }
             }
        }

        private void btnOpenCheckExceptionsLog_Click(object sender, EventArgs e)
        {
            long docID = SelectedRow.Doc_ID;

            var dlgCheckExceptionsLog = new WMSOffice.Dialogs.Complaints.ComplaintsCheckErrorsLogForm(docID) { UserID = this.UserID };
            if (dlgCheckExceptionsLog.ShowDialog(this) == DialogResult.OK)
                RefreshStagesAndButtons();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Документы".
        /// </summary>
        private void btnCheckExternalDocs_Click(object sender, EventArgs e)
        {
            using (var dlgComplaintsExternalDocs = new ComplaintsExternalDocsShowForm(SelectedRow.Doc_ID) { UserID = this.UserID })
                dlgComplaintsExternalDocs.ShowDialog(this);
        }

        private void btnSetRevision_Click(object sender, EventArgs e)
        {
            try
            {
                var comment = (string)null;
                if (SelectedRow.Status_ID.Equals("110") || SelectedRow.Status_ID.Equals("227"))
                {
                    var sAction = "исправления";
                    if (SelectedRow.Status_ID.Equals("110"))
                    {
                        if (stagesInfo.CheckCanClientRework())
                            sAction = "доработки";
                        else if (stagesInfo.CheckCanShipmentWithoutPromo())
                            sAction = "отгрузки без промо";
                    }
                    //else if (SelectedRow.Status_ID.Equals("227"))
                    //    sAction = "исправления";

                    using (EnterStringValueForm dlgEnterStringValue = new EnterStringValueForm("Комментарий", string.Format("Введите комментарий к претензии для {0}:", sAction), string.Empty) { AllowEmptyValue = false })
                        if (dlgEnterStringValue.ShowDialog() == DialogResult.OK)
                            comment = dlgEnterStringValue.Value;
                        else
                            return;
                }

                var message = (string)null;
                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                    adapter.SetRevision(SelectedRow.Doc_ID, this.UserID, ref message, comment);

                message = message ?? "Передайте документ в бухгалтерию.";
                MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 

                RefreshStagesAndButtons();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #region ОБРАБОТКА ЗАДАНИЙ

        private void btnAssignTask_Click(object sender, EventArgs e)
        {
            try
            {
                var docID = this.SelectedRow.Doc_ID;
                Data.Complaints.EmployeesToAssignTaskDataTable employees = null;
                using (var adapter = new Data.ComplaintsTableAdapters.EmployeesToAssignTaskTableAdapter())
                    employees = adapter.GetData(this.UserID, docID);

                if (employees != null && employees.Rows.Count > 0)
                {
                    var findEmployeeID = (int?)null;

                    var retSelect = employees.Select(string.Format("{0} = 1", employees.SelectedColumn.Caption), string.Empty);
                    if (retSelect.Length > 0)
                    {
                        var findEmployee = retSelect[0] as Data.Complaints.EmployeesToAssignTaskRow;
                        findEmployee.Color = Color.LightGreen.Name;

                        findEmployeeID = findEmployee.Employee_ID;
                    }

                    var dlgSelectEmployee = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectEmployee.Text = string.Format("Выберите сотрудника ответственного за выполнение задания по претензии № {0}", docID);
                    dlgSelectEmployee.AddColumn("Employee_ID", "Employee_ID", "Код");
                    dlgSelectEmployee.AddColumn("Employee_Name", "Employee_Name", "ФИО сотрудника");
                    dlgSelectEmployee.AddColumn("Claims", "Claims", "Заданий");
                    dlgSelectEmployee.AddColumn("Claims_Opened", "Claims_Opened", "Открытых");
                    dlgSelectEmployee.AddColumn("Claims_on_Hold", "Claims_on_Hold", "Отложенных");
                    dlgSelectEmployee.FilterVisible = false;
                    dlgSelectEmployee.ShowGridViewItemsWithoutSelection = true;
                    dlgSelectEmployee.DataSource = employees;

                    dlgSelectEmployee.Shown += (s, ea) => dlgSelectEmployee.Size = new Size(900, 600);
                    dlgSelectEmployee.StartPosition = FormStartPosition.CenterParent;

                    if (findEmployeeID.HasValue)
                    {
                        dlgSelectEmployee.SelectedValue = findEmployeeID.Value;
                        dlgSelectEmployee.ValueField = "Employee_ID";
                    }

                    if (dlgSelectEmployee.ShowDialog(this) == DialogResult.OK)
                    {
                        var selectedEmployee = dlgSelectEmployee.SelectedRow as Data.Complaints.EmployeesToAssignTaskRow;
                        if (selectedEmployee.Employee_ID != findEmployeeID && MessageBox.Show(string.Format("Вы действительтно хотите назначить задание в работу \r\nпо претензии № {0} сотруднику \r\n\r\n{1} ({2})?", docID, selectedEmployee.Employee_Name, selectedEmployee.Employee_ID), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            using (var adapter = new Data.ComplaintsTableAdapters.EmployeesToAssignTaskTableAdapter())
                                adapter.AssignTask(this.UserID, docID, selectedEmployee.Employee_ID);

                            // TODO отключена по требованию пользователей
                            //
                            //btnRefresh_Click(this, EventArgs.Empty);
                            //RestoreSelection(docID);

                            RefreshStagesAndButtons();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
        
        private void btnStartTask_Click(object sender, EventArgs e)
        {
            try
            {
                var docID = this.SelectedRow.Doc_ID;
                if (MessageBox.Show(string.Format("Вы действительтно хотите взять задание в работу \r\nпо претензии № {0}?", docID), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (var adapter = new Data.ComplaintsTableAdapters.EmployeesToAssignTaskTableAdapter())
                        adapter.AssignTask(this.UserID, docID, (int?)null);

                    btnRefresh_Click(this, EventArgs.Empty);
                    RestoreSelection(docID);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnDelayTask_Click(object sender, EventArgs e)
        {
            try
            {
                var docID = this.SelectedRow.Doc_ID;
                var dlgEnterStringValue = new EnterStringValueForm(string.Format("Претензия № {0}", docID), "Введите комментарий\r\nк отсрочке задания", string.Empty) { AllowEmptyValue = false };
                if (dlgEnterStringValue.ShowDialog() == DialogResult.OK)
                {
                    using (var adapter = new Data.ComplaintsTableAdapters.EmployeesToAssignTaskTableAdapter())
                        adapter.DelayTask(this.UserID, docID, dlgEnterStringValue.Value);

                    btnRefresh_Click(this, EventArgs.Empty);
                    RestoreSelection(docID);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCloseTask_Click(object sender, EventArgs e)
        {
            try
            {
                var docID = this.SelectedRow.Doc_ID;
                if (MessageBox.Show(string.Format("Вы действительтно хотите закрыть задание \r\nпо претензии № {0}?", docID), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (var adapter = new Data.ComplaintsTableAdapters.EmployeesToAssignTaskTableAdapter())
                        adapter.CloseTask(this.UserID, docID);

                    btnRefresh_Click(this, EventArgs.Empty);
                    RestoreSelection(docID);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion

        private void btnCreateVendorAct_Click(object sender, EventArgs e)
        {
            try
            {
                using (var report = new ComplaintVendorDiscrepancyActReport())
                {
                    var ds = new Data.Complaints();

                    using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_HeaderTableAdapter())
                        adapter.Fill(ds.CO_Create_ActDiscrepancy_Header, UserID, SelectedRow.First_Doc_ID);

                    using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_DetailsTableAdapter())
                        adapter.Fill(ds.CO_Create_ActDiscrepancy_Details, UserID, SelectedRow.First_Doc_ID);

                    using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_CommissionTableAdapter())
                        adapter.Fill(ds.CO_Create_ActDiscrepancy_Commission, UserID, SelectedRow.First_Doc_ID);

                    this.PrepareBarcode(ds);

                    report.SetDataSource(ds);

                    var actNumber = ds.CO_Create_ActDiscrepancy_Header[0].Act_no;
                    
                    string message = ExportHelper.ExportCrystalReport(report, ExportFormatType.PortableDocFormat, "Экспорт акта поставщику",
                        "акт №" + actNumber, true);

                    if (!String.IsNullOrEmpty(message))
                        Logger.ShowErrorMessageBox("Во время экспорта возникла ошибка: " + Environment.NewLine + message);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void PrepareBarcode(Data.Complaints data)
        {
            if (data.CO_Create_ActDiscrepancy_Header.Count > 0)
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
                barCodeCtrl.BarCode = data.CO_Create_ActDiscrepancy_Header[0].BarCode;

                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }

                data.CO_Create_ActDiscrepancy_Header[0].BarCodeBin = barCode;
            }
        }

        private void btnSendVendorAct_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedRow != null)
                {
                    using (Dialogs.Complaints.ComplaintAttachmentsForm form = new ComplaintAttachmentsForm(UserID, SelectedRow.First_Doc_ID) { UseSelectionMode = true })
                    {
                        List<Data.Complaints.DocAttachmentsRow> attachments = null;
                        if (form.ShowDialog() == DialogResult.OK)
                            attachments = new List<Complaints.DocAttachmentsRow>(form.SelectedAttachments);

                        if (attachments != null)
                        {
                            using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Letter_PropertiesTableAdapter())
                                adapter.Fill(complaints.CO_Vendor_Letter_Properties, SelectedRow.First_Doc_ID, UserID);

                            if (complaints.CO_Vendor_Letter_Properties == null || complaints.CO_Vendor_Letter_Properties.Count == 0)
                                throw new Exception("Не удалось подготовить документ outlook с актом поставщику.");

                            var doc = complaints.CO_Vendor_Letter_Properties[0];
                            CreateVendorOutlookDocument(doc, attachments);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private Microsoft.Office.Interop.Outlook.MailItem oMsg = null;

        /// <summary>
        /// Автоматическое создание документа в Outlook
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="attachments"></param>
        private void CreateVendorOutlookDocument(Data.Complaints.CO_Vendor_Letter_PropertiesRow doc, List<Data.Complaints.DocAttachmentsRow> attachments)
        {
            try
            {
                oMsg = null;

                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //oMsg.Attachments.Add(registryDoc.FilePath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, new FileInfo(registryDoc.FilePath).Name);

                var subject = doc.IsSubjectNull() ? string.Format("Акт поставщику по претензии № {0}", this.SelectedRow.First_Doc_ID) : doc.Subject;
                oMsg.Subject = subject.Substring(0, Math.Min(subject.Length, 255));

                foreach (var item in attachments)
                {
                    var tmpPath_ = Path.GetTempFileName();
                    var filePath = string.Format("{0}.{1}", tmpPath_, item.File_Name);
                    File.Move(tmpPath_, filePath);
                    File.WriteAllBytes(filePath, item.File_Data);

                    oMsg.Attachments.Add(filePath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, item.File_Name);
                }

                var tmpPath = Path.GetTempFileName();
                var logoPath = string.Format("{0}.png", tmpPath);
                File.Move(tmpPath, logoPath);
                File.WriteAllBytes(logoPath, (byte[])new ImageConverter().ConvertTo(Properties.Resources.logo, typeof(byte[])));
                var logo = oMsg.Attachments.Add(logoPath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olEmbeddeditem, null, "");
                logo.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E", logoPath);

                var body = doc.TableHtml;
                oMsg.HTMLBody = string.Format(body, logoPath);
                oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;

                var to = doc.IsRecipientNull() ? (string)null : doc.Recipient;
                if (!string.IsNullOrEmpty(to))
                    oMsg.To = to;

                var cc = doc.IsCopyRecipientsNull() ? (string)null : doc.CopyRecipients;
                if (!string.IsNullOrEmpty(cc))
                    oMsg.CC = cc;

                var bcc = doc.IsBlindCopyRecipientsNull() ? (string)null : doc.BlindCopyRecipients;
                if (!string.IsNullOrEmpty(bcc))
                    oMsg.BCC = bcc;

                oMsg.Recipients.ResolveAll();

                oMsg.Display(false);

                _isSend = false;

                ((Microsoft.Office.Interop.Outlook.ItemEvents_10_Event)oMsg).Send += new Microsoft.Office.Interop.Outlook.ItemEvents_10_SendEventHandler(ThisAddIn_Send);
                ((Microsoft.Office.Interop.Outlook.ItemEvents_10_Event)oMsg).Close += new Microsoft.Office.Interop.Outlook.ItemEvents_10_CloseEventHandler(ThisAddIn_Close);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Произошла ошибка во время формирования документа outlook акта поставщику: {0}", ex.Message));
            }
        }

        bool _isSend = false;
        void ThisAddIn_Send(ref bool Cancel)
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_HeaderTableAdapter())
                    adapter.UpdateAct(UserID, SelectedRow.First_Doc_ID);

                _isSend = true;
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время отправки акта поставщику произошла ошибка: ", ex);
            }
        }

        void ThisAddIn_Close(ref bool Cancel)
        {
            try
            {
                if (_isSend)
                {
                    MessageBox.Show("Отправка акта поставщику завершена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThreadSafeDelegate(() => { RefreshStagesAndButtons(); });
                }
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время отправки акта поставщику произошла ошибка: ", ex);
            }
        }

        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }

        private void btnExportComplaintsWithDetailsToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var sbDocs = new StringBuilder();
                var dtDocs = xdgvComplaints.DataView.Data.DefaultView.ToTable(true, "First_Doc_ID");
                var cntDocs = dtDocs.Rows.Count;

                foreach (DataRow doc in dtDocs.Rows)
                {
                    if (sbDocs.Length > 0)
                        sbDocs.AppendFormat(",{0}", doc["First_Doc_ID"]);
                    else
                        sbDocs.AppendFormat("{0}", doc["First_Doc_ID"]);
                }

                var csvDocs = sbDocs.ToString();
                var docs = GetComplaintDocsWithDetails(UserID, csvDocs);
                if (docs == null)
                    return;

                var message = ExportHelper.ExportDataTableToExcel(docs,
                    new string[] { "Код", "Код связан.", "Тип", "Подтип", "Название типа", "Название подтипа", "Статус", "Название статуса", "Дата просрочки", 
                    "Создана", "Кем создана", "Виновный сотрудник", "Виновный отдел", "Код склада", 
                    "Склад", "ИНН", "Код дебитора", "Наименование клиента", "Код ТТ", "Адрес клиента", 
                    "Менеджер", "Оператор", "Обновлена", "Кем обновлена", "Дата закрытия", "Код отпр.", "Наименование отправителя", "Группа византов", 
                    "Номер накладной", "Тип накладной", "Дата накладной", "Номер заказа", "Тип заказа", 
                    "Код товара", "Наименование товара", "Партия", "Серия", "К-во", "Цена без НДС", "Сумма без НДС", "Ставка НДС", "Сумма с НДС" },
                    new string[] { "First_Doc_ID", "Linked_Doc_ID", "Doc_Type", "Doc_Subtype", "Doc_type_Name", "Doc_Subtype_Name", "Status_ID", "Status_Name", "Expired_date", 
                    "Date_Created", "Users_Created", "Common_Fault_Employee_Name", "Common_Fault_Department_Name", "Warehouse_ID", 
                    "Warehouse_Name", "INN", "Source_Address_Base_Code", "Source_Address_name", "Source_Address_Code", "Source_Address", 
                    "ManagerName", "Operator_Name", "Date_Updated", "Users_Updated", "Close_Date", "Dest_Address_Code", "Dest_Address_Name", "Group_Name", 
                    "Related_Invoice_Number", "Related_Invoice_Type", "InvoiceDate", "Related_Order_Number", "Related_Order_Type", 
                    "Item_ID", "Item_Name", "Lot_Number", "Vendor_Lot", "Qty", "Price", "Amount", "RateTax", "NDSAmout" },
                    "Экспорт перечня претензий со строками", String.Format("Перечень претензий ({0}) со строками", cntDocs), true);

                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox(String.Format("Во время экспорта в Excel возникла ошибка:\n{0}", message));
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Получение таблицы перечня документов претензии со строками 
        /// </summary>
        /// <param name="pSessionID">Код сессии пользователя</param>
        /// <param name="pcsvDocs"></param>
        /// <returns>Таблица перечня документов претензий со строками</returns>
        private static Complaints.CO_Docs_With_Details_ExportDataTable GetComplaintDocsWithDetails(long pSessionID, string pcsvDocs)
        {
            try
            {
                using (var adapter = new CO_Docs_With_Details_ExportTableAdapter())
                    return adapter.GetData(pSessionID, pcsvDocs);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить претензии со строками: ", exc);
                return null;
            }
        }

        private void btnCreateLogisticsComplaintsReport_Click(object sender, EventArgs e)
        {
            try
            {
                var orderNumber = stagesInfo.MemoNumber;
                using (var adapter = new Data.ComplaintsTableAdapters.LogisticsComplaintsReportDataTableAdapter())
                    adapter.Fill(complaints.LogisticsComplaintsReportData, orderNumber);

                var report = new LogisticsComplaintsReport();
                report.SetDataSource((DataTable)complaints.LogisticsComplaintsReportData);
                
                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "CL", 20, SelectedRow.First_Doc_ID, (string)null, Convert.ToInt16(complaints.LogisticsComplaintsReportData.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnShowRecallNotification_Click(object sender, EventArgs e)
        {
            this.ShowRecallNotification();
        }

        private void ShowRecallNotification()
        {
            try
            {
                var canChangeNotificationInfo = false;
                var docID = stagesInfo.RecallNotificationDocID ?? 0;
                using (var dlg = new QualityGLSActRecallSetParametersForm(docID) { UserID = this.UserID, IsReadOnly = !canChangeNotificationInfo })
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        RefreshStagesAndButtons();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для списка претензий
    /// </summary>
    public class ComplaintsView : IDataView
    {
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

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as ComplaintsSearchParameters;

            var searchMode = searchCriteria.SearchMode;

            var sessionID = searchCriteria.SessionID;
            var docID = searchCriteria.DocID;
            var docType = searchCriteria.DocType;
            var managerID = searchCriteria.ManagerID;
            var debtorID = searchCriteria.DebtorID;
            var statusFrom = searchCriteria.StatusFrom;
            var statusTo = searchCriteria.StatusTo;
            var onlyRequiringVisa = searchCriteria.OnlyRequiringVisa;
            var warehouse = searchCriteria.Warehouse;
            var creatorID = searchCriteria.CreatorID;
            var faultEmployeeID = searchCriteria.FaultEmployeeID;
            var dateFrom = searchCriteria.DateFrom;
            var dateTo = searchCriteria.DateTo;
            var itemID = searchCriteria.ItemID;
            var itemName = searchCriteria.ItemName;
            var linkedOrderID = searchCriteria.LinkedOrderID;
            var linkedInvoiceID = searchCriteria.LinkedInvoiceID;

            using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                switch (searchMode)
                {
                    case ComplaintsSearchMode.Extended:
                        data = adapter.SearchDocs(sessionID, docID, docType, managerID, debtorID, creatorID, dateFrom, dateTo, itemName, linkedOrderID, itemID, faultEmployeeID, linkedInvoiceID);
                        break;
                    case ComplaintsSearchMode.Simple:
                    default:
                        data = adapter.GetData(sessionID, docType, statusFrom, statusTo, onlyRequiringVisa, warehouse);
                        break;
                }
            }
        }

        #endregion

        public ComplaintsView()
        {
            //this.dataColumns.Add(new PatternColumn("Код", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID"), SummaryCalculationType.Count) { Width = 100 });

            this.dataColumns.Add(new ImagePatternColumn("", "HasProcessingErrors") { Width = 23 });
            this.dataColumns.Add(new ImagePatternColumn("", "HasLink") { Width = 23 });
            this.dataColumns.Add(new ImagePatternColumn("Холод", "IsCold") { Width = 26 });

            this.dataColumns.Add(new PatternColumn("Код", "First_Doc_ID", new FilterCompareExpressionRule<Int64>("First_Doc_ID"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Код связан.", "Linked_Doc_ID", new FilterCompareExpressionRule<Int64>("Linked_Doc_ID"), SummaryCalculationType.Count) { Width = 60 });

            this.dataColumns.Add(new PatternColumn("Тип", "Doc_Type", new FilterPatternExpressionRule("Doc_Type"), SummaryCalculationType.Count) { Width = 35 });
            this.dataColumns.Add(new PatternColumn("Назв. типа", "Doc_Type_Name", new FilterPatternExpressionRule("Doc_Type_Name")) { Width = 110 });

            this.dataColumns.Add(new ImagePatternColumn("П. ф.", "HasAttachedFiles") { Width = 22 });
            this.dataColumns.Add(new PatternColumn("Статус", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Назв. статуса", "Status_Name", new FilterPatternExpressionRule("Status_Name")) { Width = 180 });

            this.dataColumns.Add(new PatternColumn("Дата просрочки", "expired_date", new FilterDateCompareExpressionRule("expired_date")) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Создана", "Date_Created", new FilterDateCompareExpressionRule("Date_Created")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Кем создана", "Users_Created", new FilterPatternExpressionRule("Users_Created")) { Width = 140 });
            this.dataColumns.Add(new PatternColumn("Виновный сотрудник", "Common_Fault_Employee_Name", new FilterPatternExpressionRule("Common_Fault_Employee_Name")) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Виновный отдел", "Common_Fault_Department_Name", new FilterPatternExpressionRule("Common_Fault_Department_Name")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Виновный фикт. отдел", "fict_department", new FilterPatternExpressionRule("fict_department")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Код дост.", "Source_Address_Code", new FilterCompareExpressionRule<Int32>("Source_Address_Code"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("ИНН", "INN", new FilterPatternExpressionRule("INN")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Код баз. деб.", "Source_Address_Base_Code", new FilterCompareExpressionRule<Int32>("Source_Address_Base_Code"), SummaryCalculationType.Count) { Width = 75 });
            this.dataColumns.Add(new PatternColumn("Наименование клиента", "Source_Address_Name", new FilterPatternExpressionRule("Source_Address_Name")) { Width = 140 });
            this.dataColumns.Add(new PatternColumn("Адрес клиента", "Source_Address", new FilterPatternExpressionRule("Source_Address")) { Width = 140 });

            this.dataColumns.Add(new PatternColumn("Сумма претензии с НДС", "Amount", new FilterCompareExpressionRule<Decimal>("Amount"), SummaryCalculationType.Sum) { Width = 180, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Заказы", "OrdersList", new FilterPatternExpressionRule("OrdersList")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("№ накладных", "InvoicesList", new FilterPatternExpressionRule("InvoicesList")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Контактное лицо", "Contact_Name", new FilterPatternExpressionRule("Contact_Name")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Письмо отправлено", "Client_Letter_Sent", ColumnType.Logical, new FilterEmptyExpressionRule(), SummaryCalculationType.None) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Филиал", "Warehouse_Name", new FilterPatternExpressionRule("Warehouse_Name"), SummaryCalculationType.Count) { Width = 140 });
            
            this.dataColumns.Add(new PatternColumn("Получено от клиента", "Date_ReceivedFromClient", new FilterDateCompareExpressionRule("Date_ReceivedFromClient")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Прогн. решения", "Date_ForecastSolution", new FilterDateCompareExpressionRule("Date_ForecastSolution")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Обновлена", "Date_Updated", new FilterDateCompareExpressionRule("Date_Updated")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Кем обновлена", "Users_Updated", new FilterPatternExpressionRule("Users_Updated")) { Width = 140 });

            this.dataColumns.Add(new PatternColumn("Усл. опл.", "Conditions", new FilterPatternExpressionRule("Conditions"), SummaryCalculationType.Count) { Width = 50 });

            this.dataColumns.Add(new PatternColumn("Дата закрытия", "CloseDocDate", new FilterDateCompareExpressionRule("CloseDocDate")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Статус задания", "TaskState", new FilterPatternExpressionRule("TaskState")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Код отпр.", "Dest_Address_Code", new FilterCompareExpressionRule<Int32>("Dest_Address_Code"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Наименование отправителя", "Dest_Address_Name", new FilterPatternExpressionRule("Dest_Address_Name")) { Width = 140 });

            this.dataColumns.Add(new PatternColumn("Менеджер", "Manager_Name", new FilterPatternExpressionRule("Manager_Name")) { Width = 140 });
            this.dataColumns.Add(new PatternColumn("Оператор", "Operator_Name", new FilterPatternExpressionRule("Operator_Name")) { Width = 140 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ComplaintsSearchParameters : SessionIDSearchParameters
    {
        public ComplaintsSearchMode SearchMode { get; set; }


        public long? DocID { get; set; }

        public string DocType { get; set; }

        public int? ManagerID { get; set; }

        public int? DebtorID { get; set; }       

        public string StatusFrom { get; set; }

        public string StatusTo { get; set; }

        public bool? OnlyRequiringVisa { get; set; }

        public string Warehouse { get; set; }

        public int? CreatorID { get; set; }

        public int? FaultEmployeeID { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? ItemID { get; set; }

        public string ItemName { get; set; }

        public double? LinkedOrderID { get; set; }

        public double? LinkedInvoiceID { get; set; }


        public ComplaintsSearchParameters()
        {
            this.DocType = (string)null;
            this.StatusFrom = (string)null;
            this.StatusTo = (string)null;
            this.Warehouse = (string)null;
            this.ItemName = (string)null;
        }
    }

    /// <summary>
    /// Режимы поиска
    /// </summary>
    public enum ComplaintsSearchMode
    {
        /// <summary>
        /// Простой
        /// </summary>
        Simple = 1,

        /// <summary>
        /// Расширенный
        /// </summary>
        Extended = 2
    }
}
