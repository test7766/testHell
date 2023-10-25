using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class InterbranchReceiveViewWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Столбец с информацией о наличии вложенных файлов
        /// </summary>
        private DataGridViewImageColumn dgvcHasPhoto = null;

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        ///// <summary>
        ///// Установленный режим работы (оправитель-получатель) 
        ///// </summary>
        //public InterbranchReceiptUserWorkMode WorkMode { get; set; }

        //private static bool IsTestVersion { get { return true; } } // MainForm.IsTestVersion; } }

        #endregion

        public InterbranchReceiveViewWindow()
        {
            InitializeComponent();
        }

        private void InterbranchReceiveViewWindow_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
        }

        private void Initialize()
        {
            this.xdgvRouteLists.AllowSummary = false;
            this.xdgvRouteLists.AllowRangeColumns = false;
            this.xdgvRouteLists.SetSameStyleForAlternativeRows();
            this.xdgvRouteLists.SetCellStyles(gvLines.RowTemplate.DefaultCellStyle, gvLines.ColumnHeadersDefaultCellStyle);

            this.xdgvRouteLists.FilterGrid.DefaultCellStyle = this.xdgvRouteLists.DataGrid.DefaultCellStyle;
            this.xdgvRouteLists.SummaryGrid.DefaultCellStyle = this.xdgvRouteLists.DataGrid.DefaultCellStyle;

            xdgvRouteLists.OnDataError += new DataGridViewDataErrorEventHandler(xdgvRouteLists_OnDataError);
            xdgvRouteLists.OnRowSelectionChanged += new EventHandler(xdgvRouteLists_OnRowSelectionChanged);
            xdgvRouteLists.OnFilterChanged += new EventHandler(xdgvRouteLists_OnFilterChanged);
            xdgvRouteLists.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvRouteLists_OnDataBindingComplete);
            xdgvRouteLists.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvRouteLists_OnFormattingCell);

            this.xdgvRouteLists.Init(new InterbreanchAllReceiptsCarsView(), true);
            this.xdgvRouteLists.UserID = this.UserID;

            #region ИНИЦИАЛИЗАЦИЯ СТОЛБЦОВ-ИНДИКАТОРОВ

            foreach (DataGridViewColumn column in xdgvRouteLists.DataGrid.Columns)
            {
                if ((column.Tag ?? string.Empty).Equals("HasPhoto"))
                    dgvcHasPhoto = column as DataGridViewImageColumn;
            }

            if (dgvcHasPhoto == null)
            {
                this.ShowError("Отсутствует столбец с информацией о наличии закрепленных фото.");
                return;
            }

            #endregion

            // активация постраничного просмотра
            xdgvRouteLists.CreatePageNavigator();



            this.xdgvDocs.AllowSummary = false;
            this.xdgvDocs.AllowRangeColumns = false;
            this.xdgvDocs.SetSameStyleForAlternativeRows();
            this.xdgvDocs.SetCellStyles(gvLines.RowTemplate.DefaultCellStyle, gvLines.ColumnHeadersDefaultCellStyle);

            this.xdgvDocs.FilterGrid.DefaultCellStyle = this.xdgvDocs.DataGrid.DefaultCellStyle;
            this.xdgvDocs.SummaryGrid.DefaultCellStyle = this.xdgvDocs.DataGrid.DefaultCellStyle;

            this.xdgvDocs.Init(new ReceiptsDocsView(), true);
            this.xdgvDocs.UserID = this.UserID;

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            //SetWorkMode();
            ChangeOperationsState();




            this.ChangeLinesColumnsVisibility(false);

            btnReceiptRouteDoc.Visible = false;

            //if (!InterbranchReceiveViewWindow.IsTestVersion)
            //{
            //    tsRouteListOperationsSeparator.Visible = false;
            //    btnReceiptRouteDoc.Visible = false;
            //    btnShowRouteDocPhotos.Visible = false;
            //    scMainLayout.Panel1Collapsed = true;
            //}

            //if (this.WorkMode == InterbranchReceiptUserWorkMode.Sender)
            //    this.DocTitle.Text = string.Format("{0} [Режим отправки]", this.DocTitle.Text);

            RefreshRouteDocs();
        }

        void xdgvRouteLists_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvRouteLists_OnRowSelectionChanged(object sender, EventArgs e)
        {
            ChangeOperationsState();
            this.xdgvDocs.ClearFilter();

            if (xdgvRouteLists.SelectedItems.Count > 0)
            {
                //var routeDoc = (dgvRouteLists.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Interbranch.PhotoDocsRow;
                //var state = routeDoc.Isstatus_idNull() ? string.Empty : routeDoc.status_id;

                //if (this.WorkMode == InterbranchReceiptUserWorkMode.Sender || (this.WorkMode == InterbranchReceiptUserWorkMode.Receiver && state == Constants.IB_IR_PHOTO_DOC_PREVIEWED))
                //    RefreshDocs();

                RefreshDocs();
            }
            else
            {
                this.xdgvDocs.ClearItems();
            }
        }

        void xdgvRouteLists_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvRouteLists.RecalculateSummary();
        }

        void xdgvRouteLists_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvRouteLists.DataGrid.Rows)
            {
                var boundRow = (xdgvRouteLists.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.Interbranch.IB_IR_AllReceipts_CarsRow;

                if (!boundRow.IsHasPhotoNull() && boundRow.HasPhoto)
                    xdgvRouteLists.DataGrid.Rows[row.Index].Cells[dgvcHasPhoto.Index].Value = Properties.Resources.accept_16;
            }
        }

        void xdgvRouteLists_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            //var routeDoc = (dgvRouteLists.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Interbranch.PhotoDocsRow;
            //var state = routeDoc.Isstatus_idNull() ? string.Empty : routeDoc.status_id;
            //if (this.WorkMode == InterbranchReceiptUserWorkMode.Receiver && state.Equals(Constants.IB_IR_PHOTO_DOC_APPROVED))
            //{
            //    if (dgvRouteLists.Columns[e.ColumnIndex].DataPropertyName == this.interbranch.PhotoDocs.Route_List_NumberColumn.Caption ||
            //        dgvRouteLists.Columns[e.ColumnIndex].DataPropertyName == this.interbranch.PhotoDocs.Car_NameColumn.Caption ||
            //        dgvRouteLists.Columns[e.ColumnIndex].DataPropertyName == this.interbranch.PhotoDocs.Car_NumberColumn.Caption ||
            //        dgvRouteLists.Columns[e.ColumnIndex].DataPropertyName == this.interbranch.PhotoDocs.Trailer_NumberColumn.Caption ||
            //        dgvRouteLists.Columns[e.ColumnIndex].DataPropertyName == this.interbranch.PhotoDocs.Driver_NameColumn.Caption)
            //        e.Value = string.Empty;

            //    if (dgvRouteLists.Columns[e.ColumnIndex].DataPropertyName == this.interbranch.PhotoDocs.Is_Hired_CarColumn.Caption)
            //        e.Value = false;
            //}
        }



        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            ChangeOperationsState();
            RefreshLines();
        }

        private void ChangeOperationsState()
        {
            var isRouteDocSelected = xdgvRouteLists.SelectedItems.Count > 0;
            var isDocSelected = xdgvDocs.SelectedItem != null;

            btnReceiptRouteDoc.Enabled = false; // this.WorkMode == InterbranchReceiptUserWorkMode.Receiver;
            btnShowRouteDocPhotos.Enabled = isRouteDocSelected;
            btnReceipt.Enabled = isDocSelected; // && this.WorkMode == InterbranchReceiptUserWorkMode.Receiver;

            btnExportToExcel.Enabled = xdgvDocs.HasRows;
        }

        ///// <summary>
        ///// Установка режима работы с интерфейсом (отправитель-получатель)
        ///// </summary>
        //private void SetWorkMode()
        //{
        //    try
        //    {
        //        this.WorkMode = InterbranchReceiptUserWorkMode.Receiver;

        //        var result = (int?)null;
        //        photoDocsTableAdapter.CheckSenderMode(this.UserID, ref result);

        //        if (result.HasValue && result.Value == 1)
        //            this.WorkMode = InterbranchReceiptUserWorkMode.Sender;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvDocs.RecalculateSummary();
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                var grid = sender as DataGridView;

                var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;
                var color = Color.FromName(boundRow["Color"].ToString());

                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
            }
            catch
            {

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //if (InterbranchReceiveViewWindow.IsTestVersion)
                RefreshRouteDocs();
            //else
            //    RefreshDocs();
        }

        private void RefreshRouteDocs()
        {
            try
            {
                //var statusFrom = this.WorkMode == InterbranchReceiptUserWorkMode.Sender ? Constants.IB_IR_PHOTO_DOC_CREATED : Constants.IB_IR_PHOTO_DOC_APPROVED;
                //var statusTo = this.WorkMode == InterbranchReceiptUserWorkMode.Sender ? Constants.IB_IR_PHOTO_DOC_CLOSED : Constants.IB_IR_PHOTO_DOC_PREVIEWED;
                //photoDocsTableAdapter.Fill(interbranch.PhotoDocs, this.UserID, statusFrom, statusTo, (long?)null);

                //iB_IR_AllReceipts_CarsTableAdapter.Fill(interbranch.IB_IR_AllReceipts_Cars, this.UserID);
                var searchParams = new InterbreanchAllReceiptsCarsSearchParameters() { SessionID = this.UserID };

                var loadWorker = new BackgroundWorker();

                var waitProgressForm = new WMSOffice.Dialogs.SplashForm();

                loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        this.xdgvRouteLists.DataView.FillData(e.Argument as InterbreanchAllReceiptsCarsSearchParameters);
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
                        this.xdgvRouteLists.BindData(false);
                        this.xdgvRouteLists.AllowSummary = true;
                    }

                    waitProgressForm.CloseForce();
                };

                waitProgressForm.ActionText = "Выполняется загрузка данных..";
                loadWorker.RunWorkerAsync(searchParams);
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void RefreshDocs()
        {
            // Запоминаем номер выбранного документа
            var docID = xdgvDocs.SelectedItem == null ? (long?)null : Convert.ToInt64(xdgvDocs.SelectedItem["Doc_Num"]);

            var routeListNumber = (string)null;
            var deliveryID = (int?)null;

            //if (InterbranchReceiveViewWindow.IsTestVersion)
            //{
            //    var routeDoc = (dgvRouteLists.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Interbranch.PhotoDocsRow;
            //    routeListNumber = routeDoc.IsRoute_List_NumberNull() ? (string)null : routeDoc.Route_List_Number;
            //}

            var routeDoc = xdgvRouteLists.SelectedItems[0] as Data.Interbranch.IB_IR_AllReceipts_CarsRow;
            routeListNumber = routeDoc.IsRoute_List_NumberNull() ? (string)null : routeDoc.Route_List_Number;
            deliveryID = routeDoc.IsshshanNull() ? (int?)null : Convert.ToInt32(routeDoc.shshan);

            var loadWorker = new BackgroundWorker();

            var sp = new ReceiptsSearchParameters();
            sp.SessionID = this.UserID;
            sp.RouteListNumber = routeListNumber;
            sp.DeliveryID = deliveryID;

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvDocs.DataView.FillData(e.Argument as ReceiptsSearchParameters);
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
                    this.xdgvDocs.BindData(false);
                    this.xdgvDocs.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync(sp);
            waitProgressForm.ShowDialog();

            // Навигация к выбранному документу
            if (docID.HasValue)
            {
                this.xdgvDocs.SelectRow("Doc_Num", docID.ToString());
                this.xdgvDocs.ScrollToSelectedRow();
            }
        }

        private void RefreshLines()
        {
            try
            { 
                this.ChangeLinesColumnsVisibility(false);

                // заполнение адаптера с данными о деталях документа
                var docID = xdgvDocs.SelectedItem == null ? (long?)null : Convert.ToInt64(xdgvDocs.SelectedItem["Doc_Num"]);
                receiptsAllDetailsTableAdapter.Fill(interbranch.ReceiptsAllDetails, docID);

                var showAdditionalInfo = xdgvDocs.SelectedItem == null ? false : Convert.ToBoolean(xdgvDocs.SelectedItem["ShowAdditionalInfo"]);
                this.ChangeLinesColumnsVisibility(showAdditionalInfo);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ChangeLinesColumnsVisibility(bool isVisible)
        {
            itemNameDataGridViewTextBoxColumn.Visible = isVisible;
            manufacturerDataGridViewTextBoxColumn.Visible = isVisible;
            unitOfMeasureDataGridViewTextBoxColumn.Visible = isVisible;
            vendorLotDataGridViewTextBoxColumn.Visible = isVisible;
            actIDDataGridViewTextBoxColumn.Visible = isVisible;
            actTypeDataGridViewTextBoxColumn.Visible = isVisible;
            qtyDataGridViewTextBoxColumn.Visible = isVisible;
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            // разрисовка строк в таблице
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.Interbranch.ReceiptsAllDetailsRow diffRow = (Data.Interbranch.ReceiptsAllDetailsRow)((DataRowView)row.DataBoundItem).Row;

                // простая разрисовка строк
                Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                      ? Color.White
                                      : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }

                // отображение иконок термо-режима
                if (diffRow.IsSnowFlakeNull()) row.Cells[colSnowflake.DisplayIndex].Value = emptyBitmap;
                else row.Cells[colSnowflake.DisplayIndex].Value = (diffRow.SnowFlake == "R")
                    ? Properties.Resources.snowflakeR
                    : (diffRow.SnowFlake == "B")
                        ? Properties.Resources.snowflakeB
                        : emptyBitmap;
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (xdgvDocs.SelectedItem == null)
                    throw new Exception("Не выбрана накладная.");
                else
                {
                    var docID = Convert.ToInt64(xdgvDocs.SelectedItem["Doc_Num"]);
                    receiptsAllTableAdapter.SetReceiptReadyFlag(docID);

                    RefreshDocs();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        [Obsolete]
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            receiptsAllBindingSource.Filter = String.Format("convert(Nakl_Num,'System.String') like '%{0}%'", tbSearch.Text);
            tbSearch.BackColor = (String.IsNullOrEmpty(tbSearch.Text)) ? SystemColors.Window : SystemColors.Info;
        }

        [Obsolete]
        private void btnReceiptRouteDoc_Click(object sender, EventArgs e)
        {
            //while (true)
            //{
            //    try
            //    {
            //        var routeListBarcode = string.Empty;
            //        var dlgRouteListScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
            //        {
            //            Label = "Отсканируйте маршрутный лист,\r\nкоторый необходимо принять",
            //            Text = "Подтверждение приезда на филиал",
            //            Image = Properties.Resources.delivery
            //        };

            //        if (dlgRouteListScanner.ShowDialog() == DialogResult.OK)
            //            routeListBarcode = dlgRouteListScanner.Barcode;
            //        else
            //            break;

            //        var docID = (long?)null;
            //        using (var adapter = new Data.InterbranchTableAdapters.PhotoDocsTableAdapter())
            //            adapter.ConfirmRouteListNumber(this.UserID, routeListBarcode, ref docID);

            //        if (!docID.HasValue)
            //            throw new Exception("Документ фототчета не был создан.");

            //        var dlgReceiptImages = new WMSOffice.Dialogs.InterBranch.ReceiptImagesForm();
            //        dlgReceiptImages.UserID = this.UserID;
            //        dlgReceiptImages.WorkMode = this.WorkMode;
            //        dlgReceiptImages.RouteListBarCode = routeListBarcode;
            //        dlgReceiptImages.DocID = docID.Value;

            //        if (dlgReceiptImages.ShowDialog() == DialogResult.OK)
            //        {
            //            MessageBox.Show("Приезд на филиал подтвержден", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //break;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void btnShowRouteDocPhotos_Click(object sender, EventArgs e)
        {
            var receipt = xdgvRouteLists.SelectedItems[0] as Data.Interbranch.IB_IR_AllReceipts_CarsRow;

            var carID = receipt.IsCarIDNull() ? (long?)null : receipt.CarID; //187;
            var volumeID = receipt.IsVolumeIDNull() ? (int?)null : receipt.VolumeID;
            var routeListNumber = receipt.IsRoute_List_NumberNull() ? (long?)null : Convert.ToInt64(receipt.Route_List_Number);
            var routeInformation = receipt.IsCar_NumNull() ? (string)null : receipt.Car_Num;
            var factPallets = receipt.IsFactPalletsNull() ? (int?)null : receipt.FactPallets;
            var lockBar = receipt.IsLockBarNull() ? (string)null : receipt.LockBar;
            var comment = receipt.IsCommentNull() ? (string)null : receipt.Comment;

            var frmDeliveryTransportManageCarPhotos = new WMSOffice.Dialogs.InterBranch.DeliveryTransportManageCarPhotosForm() { IsReadOnly = true, UserID = this.UserID, CarID = carID, VolumeID = volumeID, RouteNumber = routeListNumber, RouteInformation = routeInformation, FactPallets = factPallets, LockBar = lockBar, Comment = comment };
            if (frmDeliveryTransportManageCarPhotos.ShowDialog() == DialogResult.OK)
            { 
            
            }

            //var routeDoc = (dgvRouteLists.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Interbranch.PhotoDocsRow;
            //var docID = routeDoc.doc_id;
            //var routeListBarcode = string.Format("RL{0}", routeDoc.IsRoute_List_NumberNull() ? (string)null : routeDoc.Route_List_Number);

            //var dlgReceiptImages = new WMSOffice.Dialogs.InterBranch.ReceiptImagesForm();
            //dlgReceiptImages.UserID = this.UserID;
            //dlgReceiptImages.WorkMode = this.WorkMode;
            //dlgReceiptImages.RouteListBarCode = routeListBarcode;
            //dlgReceiptImages.DocID = docID;

            //dlgReceiptImages.ShowDialog();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xdgvDocs.ExportToExcel("Экспорт накладных МС в Excel", "Накладные МС", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время экспорта накладных МС в Excel возникла ошибка:", exc);
            }
        }
    }

    /// <summary>
    /// Представление для грида с документами приемки
    /// </summary>
    public class ReceiptsDocsView : IDataView
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
            var sp = pSearchParameters as ReceiptsSearchParameters;
            using (var adapter = new Data.InterbranchTableAdapters.ReceiptsAllTableAdapter())
            {
                adapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                data = adapter.GetData(sp.SessionID, sp.RouteListNumber, sp.DeliveryID);
            }
        }

        public ReceiptsDocsView()
        {
            this.dataColumns.Add(new PatternColumn("Филиал", "FilialName", new FilterPatternExpressionRule("FilialName")));
            this.dataColumns.Add(new PatternColumn("Дата", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("№ пак. листа", "Doc_Num", new FilterCompareExpressionRule<Int64>("Doc_Num"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("№ накладной", "Nakl_Num", new FilterCompareExpressionRule<Int64>("Nakl_Num"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Авто", "Car_Num", new FilterPatternExpressionRule("Car_Num")));
            this.dataColumns.Add(new PatternColumn("Мест", "Places", new FilterCompareExpressionRule<Int32>("Places"), SummaryCalculationType.Sum) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Обработано", "WorkPlaces", new FilterCompareExpressionRule<Int32>("WorkPlaces"), SummaryCalculationType.Sum) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Зав.", "ZvodFlag", new FilterPatternExpressionRule("ZvodFlag")));
            this.dataColumns.Add(new PatternColumn("Прих.", "ReceipFlag", new FilterPatternExpressionRule("ReceipFlag")));
        }
    }
    /// <summary>
    /// Класс параметров поиска для приемки на филиале
    /// 
    public class ReceiptsSearchParameters : SessionIDSearchParameters
    {
        public string RouteListNumber { get; set; }
        public int? DeliveryID { get; set; }
    }

    /// <summary>
    /// Представление для машин поставок
    /// </summary>
    public class InterbreanchAllReceiptsCarsView : IDataView
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
            var searchCriteria = searchParameters as InterbreanchAllReceiptsCarsSearchParameters;

            var sessionID = searchCriteria.SessionID;

            using (var adapter = new Data.InterbranchTableAdapters.IB_IR_AllReceipts_CarsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID);
            }
        }

        #endregion

        public InterbreanchAllReceiptsCarsView()
        {
            this.dataColumns.Add(new PatternColumn("Филиал", "FilialName", new FilterPatternExpressionRule("FilialName"), SummaryCalculationType.Count) { Width = 450 });
            this.dataColumns.Add(new PatternColumn("Дата", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date"), SummaryCalculationType.Count));

            this.dataColumns.Add(new PatternColumn("Номер машины", "Car_Num", new FilterPatternExpressionRule("Car_Num")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("№ М/Л", "Route_List_Number", new FilterPatternExpressionRule("Route_List_Number"), SummaryCalculationType.Count));

            this.dataColumns.Add(new ImagePatternColumn("", "HasPhoto") { Width = 22 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class InterbreanchAllReceiptsCarsSearchParameters : SessionIDSearchParameters
    {
        
    }

    /// <summary>
    /// Режим работы пользователя в интерфейсе приемки на филиале
    /// </summary>
    public enum InterbranchReceiptUserWorkMode
    {
        /// <summary>
        /// Отправитель
        /// </summary>
        Sender = 0,

        /// <summary>
        /// Получатель
        /// </summary>
        Receiver
    }
}
