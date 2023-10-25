using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Classes.ReportProviders;
using WMSOffice.Classes.SearchParameters;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Quality;

namespace WMSOffice.Window
{

    /// <summary>
    /// Окно входного контроля партии
    /// </summary>
    public partial class QualityInputControlLotnWindow : GeneralWindow
    {
       // private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadData(null);
        }



        /// <summary>
        /// Параметры загрузки списка заказов
        /// </summary>
        private InputControlLotnOrdersSearchParamters searchParams;
        /// <summary>
        /// Класс-поставщик отчетов-анкет входного контроля партии
        /// </summary>
        private QualityInputControlReportProvider spReportProvider;

        /// Название таблицы анкет входного контроля партии в конфигурационном файле
        private string ConfigDetailsName { get { return String.Format("{0}_Details", Name); } }




        public QualityInputControlLotnWindow()
        {
            InitializeComponent();


            edgOrders.AllowSummary = false;
            edgOrders.UseMultiSelectMode = false;
            edgOrders.Init(new InputControlLotnView(), true);
            edgOrders.UserID = this.UserID;


            edgWorksheets.AllowSummary = false;
            edgWorksheets.UseMultiSelectMode = false;
            edgWorksheets.Init(new InputControlLotnWorksheetsView(), true);
            edgWorksheets.UserID = this.UserID;

            
          



            // активация постраничного просмотра
            edgOrders.CreatePageNavigator();



            //InitializeInputControlLotnGrid();                   //инициализация верхнего грида edgOrders
            //InitializeInputControlLotnWorksheetsGrid();         //инициализация нижнего грида edgWorksheets

            spReportProvider = new QualityInputControlReportProvider(UserID)
            {
                ControlType = InputControlTypes.LotnControl
            };



        }



        /// <summary>
        /// Загрузка заказов при загрузке окна
        /// </summary>
        private void QualityInputControlLotnWindow_Load(object sender, EventArgs e)
        {
            searchParams = new InputControlLotnOrdersSearchParamters { SessionID = UserID };
            searchSheetsParams = new InputControlLotnOrdersSearchParamters { SessionID = UserID };
            CustomOrdersCheckBoxesPanel();
            CustomSheetsCheckBoxesPanel();
            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);
            //RefreshDocs();
            //edgWorksheets.LoadExtraDataGridViewSettings(ConfigDetailsName);
            //   LoadData(null);





        }

        /// <summary>
        /// Отображение загруженных заказов в фильтруемом гриде
        /// </summary>
        /// <param name="pData">Таблица с заказами, которые нужно отобразить в гриде</param>
        private void RefreshDataViewBinding(Quality.AT_DocsDataTable pData)
        {
            try
            {
                long selDocID = -1;
                int rowIndex = edgOrders.FirstDisplayedScrollingRowIndex;
                if (IsDocSelected)
                    selDocID = CurrentDocId;

                (edgOrders.DataView as InputControlLotnView).FillData(pData);
                edgOrders.BindData(false);

                edgOrders.SelectRow(InputControlLotnView.ID_PROPERTY_NAME, selDocID.ToString());
                edgOrders.ScrollToRow(rowIndex);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время отображения заказов: ", exc);
            }
        }





        private void LoadData(long? orderID)
        {
            try
            {
                var bw = new BackgroundWorker();
                var splashForm = new Dialogs.SplashForm();
                var param = new InputControlLotnOrdersSearchParamters
                {
                    SessionID = this.UserID,
                    OrderID = orderID,
                    IncludeNew = searchParams.IncludeNew,
                    OrderIncludeInWork = searchParams.OrderIncludeInWork,
                    OrderIncludeAccepted = searchParams.OrderIncludeAccepted,
                    OrderIncludeNotAccepted = searchParams.IncludeNotAccepted,
                    OrderIncludeCertDataInput = searchParams.OrderIncludeCertDataInput,
                };
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.edgOrders.DataView.FillData(e.Argument as InputControlLotnOrdersSearchParamters);
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
                        this.edgOrders.BindData(false);
                        this.edgOrders.AllowSummary = true;
                    }
                    splashForm.CloseForce();
                };
                splashForm.ActionText = "Виконується оптримання списку вхідного контролю партій...";
                bw.RunWorkerAsync(param);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        //Refresh
        private void btnRefreshhOrder_Click(object sender, EventArgs e)
        {
          
        }







        private void SearchQuestionnaires()
        {

            var dlgSearchForm = new InputControlLotnSearchQuestionnaires(searchSheetsParams) { UserID = this.UserID };
            if (dlgSearchForm.ShowDialog() == DialogResult.OK)
            {
                chbStatusNew.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNew;
                chbStatusInWork.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusInWork;
                chbStatusAccepted.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusAccepted;
                chbStatusNotAccepted.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNotAccepted;

        //        this.LoadData(QualityShippingAuthorizationWorksheetSearchForm.SearchParameter);
            }
        }








        //Search

        private void btnOrderSearch_Click(object sender, EventArgs e)
        {
             var formEork = new InputControlLotnSearchForm(searchSheetsParams);

            //var form2 = new InputControlLotnSearchQuestionnaires(searchSheetsParams);








            var form = new InputControlLotnSearchQuestionnaires(searchSheetsParams);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                searchSheetsParams.OnlyActual = form.FilterOnlyActive;
                searchSheetsParams.ItemID = form.FilterItemID;
                searchSheetsParams.ItemName = form.ItemName;
                searchSheetsParams.VendorID = form.FilterVendorID;
                searchSheetsParams.VendorName = form.VendorName;
                searchSheetsParams.ManufacturerID = form.FilterManufacturerID;
                searchSheetsParams.ManufacturerName = form.ManufacturerName;
                searchParams.OrderID = form.FilterOrderID;

                searchSheetsParams.IncludeNew = form.FilterIncludeNew;
                searchSheetsParams.IncludeInWork = form.FilterIncludeInWork;
                searchSheetsParams.IncludeAccepted = form.FilterIncludeAccepted;
                searchSheetsParams.IncludeNotAccepted = form.FilterIncludeNotAccepted;
                searchSheetsParams.IncludeCertDataInput = form.FilterIncludeCertDataInput;

                searchSheetsParams.OrderIncludeNew = form.FilterOrderIncludeNew;
                searchSheetsParams.OrderIncludeInWork = form.FilterOrderIncludeInWork;
                searchSheetsParams.OrderIncludeAccepted = form.FilterOrderIncludeAccepted;
                searchSheetsParams.OrderIncludeNotAccepted = form.FilterOrderIncludeNotAccepted;
                searchSheetsParams.OrderIncludeCertDataInput = form.FilterOrderIncludeCertDataInput;

                searchSheetsParams.OrderDateFrom = form.FilterOrderDateFrom;
                searchSheetsParams.OrderDateTo = form.FilterOrderDateTo;
                searchSheetsParams.ProvisorID = form.FilterProvisorID;
                searchSheetsParams.DateFrom = form.FilterWorksheetDateFrom;
                searchSheetsParams.DateTo = form.FilterWorksheetDateTo;

                CustomSheetsCheckBoxesPanel();

                if (searchSheetsParams.OrderID.HasValue)
                {
                    RefreshDocs(searchParams.OrderID);

                    //edgOrders.ApplyFilter(InputControlLotnView.ID_PROPERTY_NAME, searchSheetsParams.OrderID.ToString());
                    //edgOrders.ActivateFilter();
                }
                else
                {
                    //CustomSheetsCheckBoxesPanel();
                    //if (!chbDetailsSearchMode.Checked)
                    //    chbDetailsSearchMode.Checked = true;

                    RefreshDetails();
                }
            }






            //var form = new InputControlLotnSearchForm(searchSheetsParams);
            //if (form.ShowDialog(this) == DialogResult.OK)
            //{
            //    searchSheetsParams.OnlyActual = form.FilterOnlyActive;
            //    searchSheetsParams.ItemID = form.FilterItemID;
            //    searchSheetsParams.ItemName = form.ItemName;
            //    searchSheetsParams.VendorID = form.FilterVendorID;
            //    searchSheetsParams.VendorName = form.VendorName;
            //    searchSheetsParams.ManufacturerID = form.FilterManufacturerID;
            //    searchSheetsParams.ManufacturerName = form.ManufacturerName;
            //    searchParams.OrderID = form.FilterOrderID;

            //    searchSheetsParams.IncludeNew = form.FilterIncludeNew;
            //    searchSheetsParams.IncludeInWork = form.FilterIncludeInWork;
            //    searchSheetsParams.IncludeAccepted = form.FilterIncludeAccepted;
            //    searchSheetsParams.IncludeNotAccepted = form.FilterIncludeNotAccepted;
            //    searchSheetsParams.IncludeCertDataInput = form.FilterIncludeCertDataInput;

            //    searchSheetsParams.OrderIncludeNew = form.FilterOrderIncludeNew;
            //    searchSheetsParams.OrderIncludeInWork = form.FilterOrderIncludeInWork;
            //    searchSheetsParams.OrderIncludeAccepted = form.FilterOrderIncludeAccepted;
            //    searchSheetsParams.OrderIncludeNotAccepted = form.FilterOrderIncludeNotAccepted;
            //    searchSheetsParams.OrderIncludeCertDataInput = form.FilterOrderIncludeCertDataInput;

            //    searchSheetsParams.OrderDateFrom = form.FilterOrderDateFrom;
            //    searchSheetsParams.OrderDateTo = form.FilterOrderDateTo;
            //    searchSheetsParams.ProvisorID = form.FilterProvisorID;
            //    searchSheetsParams.DateFrom = form.FilterWorksheetDateFrom;
            //    searchSheetsParams.DateTo = form.FilterWorksheetDateTo;

            //    CustomSheetsCheckBoxesPanel();

            //    if (searchSheetsParams.OrderID.HasValue)
            //    {
            //        RefreshDocs(searchParams.OrderID);

            //        //edgOrders.ApplyFilter(InputControlLotnView.ID_PROPERTY_NAME, searchSheetsParams.OrderID.ToString());
            //        //edgOrders.ActivateFilter();
            //    }
            //    else
            //    {
            //        //CustomSheetsCheckBoxesPanel();
            //        //if (!chbDetailsSearchMode.Checked)
            //        //    chbDetailsSearchMode.Checked = true;

            //        RefreshDetails();
            //    }
            //}





        }















        /// <summary>
        /// Инициализация фильтруемого грида с заказами
        /// </summary>
        private void InitializeInputControlLotnGrid()
        {
            var tttest = Name; //переменная для имени текущего control (control.Name)
            edgOrders.Init(new InputControlLotnView(), true);
            edgOrders.LoadExtraDataGridViewSettings(Name);
            edgOrders.UserID = UserID;
            edgOrders.AllowRangeColumns = true;
        }

        /// <summary>
        /// Инициализация фильтруемого грида с анкетами входного контроля партии
        /// </summary>
        private void InitializeInputControlLotnWorksheetsGrid()
        {
            edgWorksheets.Init(new InputControlLotnWorksheetsView(), true);
            edgWorksheets.LoadExtraDataGridViewSettings(ConfigDetailsName);
            edgWorksheets.UserID = UserID;
            edgWorksheets.AllowRangeColumns = true;

        }











        #region ТАБЛИЦА ЗАКАЗОВ

        /// <summary>
        /// True если в данный момент загружаются заказы, False в противном случае
        /// </summary>
        private bool isDocLoading;

        /// <summary>
        /// Идентификатор текущего выбранного заказа в таблице 
        /// Если в таблице не выбран ни один заказ, будет выдано исключение
        /// </summary>
        private int CurrentDocId
        {
            get { return Convert.ToInt32(edgOrders.SelectedItem[InputControlLotnView.ID_PROPERTY_NAME]); }
        }

        /// <summary>
        /// True если в таблице заказов выделена одна строка, False в противном случае
        /// </summary>
        private bool IsDocSelected { get { return edgOrders.SelectedItem != null; } }

        /// <summary>
        /// Заказ, выделенный в таблице, либо null, если не выделен ни один заказ
        /// </summary>
        public Quality.AT_DocsRow SelectedDoc { get { return edgOrders.SelectedItem as Quality.AT_DocsRow; } }




        /// <summary>
        /// Обновление записей в таблице заказов по клику на пункт меню "Обновить"
        /// </summary>
        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        /// <summary>
        /// Изменение выделенного заказа - обновление анкет партии и обновление доступности кнопок
        /// </summary>
        private void edgOrders_SelectionChanged(object sender, EventArgs e)
        {
           // CustomDocsControls();
            searchSheetsParams.OrderID = SelectedDoc == null ? null : (long?)SelectedDoc.order_id;
            if (!detailsSearchMode) 
            {
               // RefreshDetails();
                LoadDataedgWorksheets();
            }
               
        }

        /// <summary>
        /// Настройка доступности котролов, относящихся к таблице заказов
        /// </summary>
        private void CustomDocsControls()
        {
            edgOrders.Enabled = !isDocLoading;
            //    pbSplashControl.Visible = isDocLoading;

            miRefresh.Enabled = !isDocLoading;
            miCancelLoading.Enabled = isDocLoading;

            tsDocVersions.Enabled = edgWorksheets.Enabled = pnlStatusFilters.Enabled = !isDocLoading;
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void edgOrders_OnFilterChanged(object pSender, EventArgs pE)
        {
            edgOrders.RecalculateSummary();
        }

        private void RefreshDocs()
        {
            this.RefreshDocs(null);
        }

        /// <summary>
        /// Запуск асинхронной загрузки заказов
        /// </summary>
        private void RefreshDocs(long? orderID)
        {
            CancelWsLoading();

            //var param = SessionIDSearchParameters { SessionID = UserID};
            var param = new InputControlLotnOrdersSearchParamters
            {
                SessionID = UserID,
                OrderID = orderID,

                IncludeNew = searchParams.IncludeNew,
                OrderIncludeInWork = searchParams.OrderIncludeInWork,
                OrderIncludeAccepted = searchParams.OrderIncludeAccepted,
                OrderIncludeNotAccepted = searchParams.IncludeNotAccepted,
                OrderIncludeCertDataInput = searchParams.OrderIncludeCertDataInput,
            };

            isDocLoading = true;
            CustomDocsControls();
            bgwLoader = new BackgroundWorker();
            bgwLoader.DoWork += bgwLoader_DoWork;
            bgwLoader.RunWorkerCompleted += bgwLoader_RunWorkerCompleted;
            bgwLoader.RunWorkerAsync(param);
        }

        /// <summary>
        /// Асинхронная загрузка заказов
        /// </summary>
        private void bgwLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = e.Argument as InputControlLotnOrdersSearchParamters;

                using (var adapter = new AT_DocsTableAdapter())
                {
                    adapter.SetTimeout(300);
                    e.Result = adapter.GetData(param.SessionID, param.FilterByStatus, param.OrderID, null, null, null, null, null, null, null, null, null, null, null);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание загрузки заказов и их отображение в таблице
        /// </summary>
        private void bgwLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке заказов:", e.Result as Exception);
            else
                RefreshDataViewBinding(e.Result as Quality.AT_DocsDataTable);

            isDocLoading = false;
            CustomDocsControls();
        }



        /// <summary>
        /// Отмена текущей асинхронной загрузки заказов
        /// </summary>
        private void CancelLoading_Click(object sender, EventArgs e)
        {
            isDocLoading = false;
            bgwLoader.RunWorkerCompleted -= bgwLoader_RunWorkerCompleted;
            bgwLoader = null;
            CustomDocsControls();
        }

        /// <summary>
        /// Сохранение настроек таблиц при закрытии окна
        /// </summary>
        private void QualityInputControlLotnWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            edgOrders.SaveExtraDataGridViewSettings(Name);
            edgWorksheets.SaveExtraDataGridViewSettings(ConfigDetailsName);
        }

        /// <summary>
        /// Заполнение значений в чекбоксах под панелью инструментов текущими значениями фильтров
        /// </summary>
        private void CustomOrdersCheckBoxesPanel()
        {
            chbOrderNew.Checked = searchParams.IncludeNew;
            chbOrderInWork.Checked = searchParams.IncludeInWork;
            chbOrderAccepted.Checked = searchParams.IncludeAccepted;
            chbOrderNotAccepted.Checked = searchParams.IncludeNotAccepted;
            chbOrderCertDataInput.Checked = searchParams.IncludeCertDataInput;
        }

        /// <summary>
        /// Изменение фильтров по статусах заказов при переключении соответствующих флажков
        /// </summary>
        private void chbOrderStatus_CheckedChanged(object sender, EventArgs e)
        {
            searchParams.IncludeNew = chbOrderNew.Checked;
            searchParams.IncludeInWork = chbOrderInWork.Checked;
            searchParams.IncludeAccepted = chbOrderAccepted.Checked;
            searchParams.IncludeNotAccepted = chbOrderNotAccepted.Checked;
            searchParams.IncludeCertDataInput = chbOrderCertDataInput.Checked;
        }

        /// <summary>
        /// Разрисовка строк в таблице заказов
        /// </summary>
        private void edgOrders_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var dbRow = (row.DataBoundItem as DataRowView).Row as Quality.AT_DocsRow;
                var backColor = (dbRow.status_id == Constants.QK_IC_STATUS_ACCEPTED) ? Color.FromArgb(209, 255, 117) :
                    (dbRow.status_id == Constants.QK_IC_STATUS_NOT_ACCEPTED ? Color.FromArgb(255, 225, 225) : Color.White);
                for (int c = 0; c < row.Cells.Count; c++)
                    row.Cells[c].Style.BackColor = row.Cells[c].Style.SelectionForeColor = backColor;
            }
        }

        #endregion

        #region ТАБЛИЦА АНКЕТ ВХОДНОГО КОНТРОЛЯ ПАРТИИ

        /// <summary>
        /// True если в данный момент загружаются анкеты, False в противном случае
        /// </summary>
        private bool isDetailsLoading;



        /// <summary>
        /// Параметры загрузки списка анкет входного контроля по заказу
        /// </summary>
        private InputControlLotnOrdersSearchParamters searchSheetsParams;

        /// <summary>
        /// Анкета входного контроля партии, выделенная в таблице
        /// </summary>
        private Quality.AT_Doc_VersionsRow SelectedWorksheet
        {
            get
            {
                if (edgWorksheets.SelectedItems.Count == 0)
                    return null;
                else
                    return edgWorksheets.SelectedItem as Quality.AT_Doc_VersionsRow;
            }
        }







        /// <summary>
        /// True если при изменении флажков нужно изменять значения searchSheetParams, False в противном случае
        /// </summary>
        private bool needRefreshParams = true;



        /// <summary>
        /// Обновление анкет входного контроля партии по нажатию на кнопку "Обновить"
        /// </summary>
        private void btnRefreshDetails_Click(object sender, EventArgs e)
        {
        //    RefreshDetails();
        }

        /// <summary>
        /// Изменение режима работы таблицы анкет
        /// </summary>
        //private void chbDetailsSearchMode_CheckedChanged(object sender, EventArgs e)
        //{
        //    detailsSearchMode = chbDetailsSearchMode.Checked;
        //}

        /// <summary>
        /// Запуск асинхронной загрузки анкет входного контроля партии
        /// </summary>
        private void RefreshDetails()
        {
            CancelWsLoading();
            isDetailsLoading = true;
            CustomDetailsButtons();


            LoadDataedgWorksheets();

            //bgwWsLoader = new BackgroundWorker();
            //bgwWsLoader.DoWork += bgwWsLoader_DoWork;
            //bgwWsLoader.RunWorkerCompleted += bgwWsLoader_RunWorkerCompleted;
            //bgwWsLoader.RunWorkerAsync();

        }



        private void LoadDataedgWorksheets()
        {
            ToolStripComboBox tscb = new ToolStripComboBox();
         //   ToolStripControlHost
            try
            {
                var splashForm = new Dialogs.SplashForm();
                var DataWorkSheets = new InputControlLotnWorkSheetsSearchParamters()
                {
                    SessionID = searchSheetsParams.SessionID,
                    Order_id = searchSheetsParams.OrderID,
                    Statuses = searchSheetsParams.FilterByStatus,
                    _onlyActual = detailsSearchMode ? (bool?)searchSheetsParams.OnlyActual : null,
                    Item_id = detailsSearchMode ? searchSheetsParams.ItemID : null,
                    LotNumber = detailsSearchMode ? searchSheetsParams.LotNumber : null,
                    VendorID = detailsSearchMode ? searchSheetsParams.VendorID : null,
                    Manufacturer_id = detailsSearchMode ? searchSheetsParams.ManufacturerID : null,
                    Order_statuses = detailsSearchMode ? "1,2,3,4,5" : null,
                    Order_date_from = detailsSearchMode ? (searchSheetsParams.OrderDateFrom.HasValue ?
                        (DateTime?)searchSheetsParams.OrderDateFrom.Value.Date : null) : null,
                    Order_date_to = detailsSearchMode ? (searchSheetsParams.OrderDateTo.HasValue ?
                        (DateTime?)searchSheetsParams.OrderDateTo.Value.Date.AddDays(1).AddMinutes(-1) : null) : null,
                    ProvisorID = detailsSearchMode ? searchSheetsParams.ProvisorID : null,
                    DateFrom = detailsSearchMode ? (searchSheetsParams.DateFrom.HasValue ?
                        (DateTime?)searchSheetsParams.DateFrom.Value.Date : null) : null,
                    DateTo = detailsSearchMode ? (searchSheetsParams.DateTo.HasValue ?
                        (DateTime?)searchSheetsParams.DateTo.Value.Date.AddDays(1).AddMinutes(-1) : null) : null

                };


                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {

                        this.edgWorksheets.DataView.FillData(e.Argument as InputControlLotnWorkSheetsSearchParamters);










                        //using (var adapter = new AT_Doc_VersionsTableAdapter())
                        //{
                        //    adapter.SetTimeout(300);

                        //    e.Result = adapter.GetData(
                        //    searchSheetsParams.SessionID,
                        //    searchSheetsParams.OrderID,//detailsSearchMode ? null : searchSheetsParams.OrderID,
                        //    searchSheetsParams.FilterByStatus,
                        //    detailsSearchMode ? (bool?)searchSheetsParams.OnlyActual : null,
                        //    detailsSearchMode ? searchSheetsParams.ItemID : null,
                        //    detailsSearchMode ? searchSheetsParams.LotNumber : null,
                        //    detailsSearchMode ? searchSheetsParams.VendorID : null,
                        //    detailsSearchMode ? searchSheetsParams.ManufacturerID : null,

                        //    detailsSearchMode ? "1,2,3,4,5" : null,

                        //    detailsSearchMode ? (searchSheetsParams.OrderDateFrom.HasValue ?
                        //        (DateTime?)searchSheetsParams.OrderDateFrom.Value.Date : null) : null,
                        //    detailsSearchMode ? (searchSheetsParams.OrderDateTo.HasValue ?
                        //        (DateTime?)searchSheetsParams.OrderDateTo.Value.Date.AddDays(1).AddMinutes(-1) : null) : null,
                        //    detailsSearchMode ? searchSheetsParams.ProvisorID : null,
                        //    detailsSearchMode ? (searchSheetsParams.DateFrom.HasValue ?
                        //        (DateTime?)searchSheetsParams.DateFrom.Value.Date : null) : null,
                        //    detailsSearchMode ? (searchSheetsParams.DateTo.HasValue ?
                        //        (DateTime?)searchSheetsParams.DateTo.Value.Date.AddDays(1).AddMinutes(-1) : null) : null);


                        //    //   RefreshWsDataViewBinding(e.Result as Quality.AT_Doc_VersionsDataTable);
                        //}

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
                        this.edgWorksheets.BindData(false);


                        this.edgWorksheets.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

           //     splashForm.ActionText = "Выполняется получение списка анкет ...";
                bw.RunWorkerAsync(DataWorkSheets);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }


        }




















        /// True если включен режим поиска анкет, False если отображаются анкеты по выбранному заказу
        private bool detailsSearchMode;
        /// <summary>
        /// Асинхронная загрузка анкет входного контроля партии
        /// </summary>
        private void bgwWsLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var adapter = new AT_Doc_VersionsTableAdapter())
                {
                    adapter.SetTimeout(300);

                    e.Result = adapter.GetData(searchSheetsParams.SessionID,
                        searchSheetsParams.OrderID,//detailsSearchMode ? null : searchSheetsParams.OrderID,
                        searchSheetsParams.FilterByStatus,
                        detailsSearchMode ? (bool?)searchSheetsParams.OnlyActual : null,
                        detailsSearchMode ? searchSheetsParams.ItemID : null,
                        detailsSearchMode ? searchSheetsParams.LotNumber : null,
                        detailsSearchMode ? searchSheetsParams.VendorID : null,
                        detailsSearchMode ? searchSheetsParams.ManufacturerID : null,

                        detailsSearchMode ? "1,2,3,4,5" : null,

                        detailsSearchMode ? (searchSheetsParams.OrderDateFrom.HasValue ?
                            (DateTime?)searchSheetsParams.OrderDateFrom.Value.Date : null) : null,
                        detailsSearchMode ? (searchSheetsParams.OrderDateTo.HasValue ?
                            (DateTime?)searchSheetsParams.OrderDateTo.Value.Date.AddDays(1).AddMinutes(-1) : null) : null,
                        detailsSearchMode ? searchSheetsParams.ProvisorID : null,
                        detailsSearchMode ? (searchSheetsParams.DateFrom.HasValue ?
                            (DateTime?)searchSheetsParams.DateFrom.Value.Date : null) : null,
                        detailsSearchMode ? (searchSheetsParams.DateTo.HasValue ?
                            (DateTime?)searchSheetsParams.DateTo.Value.Date.AddDays(1).AddMinutes(-1) : null) : null);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание загрузки анкет и их отображение в таблице
        /// </summary>
        private void bgwWsLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке анкет:", e.Result as Exception);
            else
                RefreshWsDataViewBinding(e.Result as Quality.AT_Doc_VersionsDataTable);

            isDetailsLoading = false;
            CustomDetailsButtons();
        }




        /// <summary>
        /// Отображение загруженных анкет в фильтруемом гриде
        /// </summary>
        /// <param name="pData">Таблица с анкетами, которые нужно отобразить в гриде</param>
        private void RefreshWsDataViewBinding(Quality.AT_Doc_VersionsDataTable pData)
        {
            try
            {
                (edgWorksheets.DataView as InputControlLotnWorksheetsView).FillData(pData);
                edgWorksheets.BindData(false);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время отображения анкет: ", exc);
            }
        }

        /// <summary>
        /// Отмена текущей асинхронной загрузки анкет
        /// </summary>
        private void CancelWsLoading()
        {
            isDetailsLoading = false;
            if (bgwWsLoader != null)
                bgwWsLoader.RunWorkerCompleted -= bgwWsLoader_RunWorkerCompleted;
            bgwWsLoader = null;
            CustomDetailsButtons();
        }




        /// <summary>
        /// Заполнение значений в чекбоксах под панелью инструментов анкет входного контроля текущими значениями фильтров
        /// </summary>
        private void CustomSheetsCheckBoxesPanel()
        {
            needRefreshParams = false;
            chbSheetNew.Checked = searchSheetsParams.IncludeNew;
            chbSheetInWork.Checked = searchSheetsParams.IncludeInWork;
            chbSheetAccepted.Checked = searchSheetsParams.IncludeAccepted;
            chbSheetNotAccepted.Checked = searchSheetsParams.IncludeNotAccepted;
            chbSheetCertDataInput.Checked = searchSheetsParams.IncludeCertDataInput;
            needRefreshParams = true;
        }

        /// <summary>
        /// Изменение фильтров по статусах анкет при переключении соответствующих флажков
        /// </summary>
        private void chbSheetStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (needRefreshParams)
            {
                searchSheetsParams.IncludeNew = chbSheetNew.Checked;
                searchSheetsParams.IncludeInWork = chbSheetInWork.Checked;
                searchSheetsParams.IncludeAccepted = chbSheetAccepted.Checked;
                searchSheetsParams.IncludeNotAccepted = chbSheetNotAccepted.Checked;
                searchSheetsParams.IncludeCertDataInput = chbSheetCertDataInput.Checked;
            }
        }

        /// <summary>
        /// Настройка доступности кнопок на панели инструментов анкет входного контроля при изменении выбранной анкеты
        /// </summary>
        private void edgWorksheets_SelectionChanged(object sender, EventArgs e)
        {
            CustomDetailsButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели инструментов анкет входного контроля в зависимости от выбранных анкет
        /// </summary>
        private void CustomDetailsButtons()
        {
            edgWorksheets.Enabled = !isDetailsLoading && !isDocLoading;
            //  pbxWsSplashControl.Visible = isDetailsLoading;

            btnViewWorksheet.Visible = btnViewWorksheet.Enabled = btnPrintWorksheet.Enabled = btnPrintWorksheet.Visible =
                edgWorksheets.SelectedItems.Count > 0 && !isDetailsLoading && !isDocLoading;
            btnEditWorksheet.Enabled = btnEditWorksheet.Visible = tssAfterEdit.Visible = edgWorksheets.SelectedItems.Count == 1
                && !isDetailsLoading && !isDocLoading;
            btnExportToExcel.Visible = !isDocLoading && !isDetailsLoading;
        }

        /// <summary>
        /// Поиск анкет входного контроля партии
        /// </summary>
        private void btnSearchWorksheet_Click(object sender, EventArgs e)
        {
            var form = new InputControlLotnSearchForm(searchSheetsParams);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                searchSheetsParams.OnlyActual = form.FilterOnlyActive;
                searchSheetsParams.ItemID = form.FilterItemID;
                searchSheetsParams.ItemName = form.ItemName;
                searchSheetsParams.VendorID = form.FilterVendorID;
                searchSheetsParams.VendorName = form.VendorName;
                searchSheetsParams.ManufacturerID = form.FilterManufacturerID;
                searchSheetsParams.ManufacturerName = form.ManufacturerName;
                searchParams.OrderID = form.FilterOrderID;

                searchSheetsParams.IncludeNew = form.FilterIncludeNew;
                searchSheetsParams.IncludeInWork = form.FilterIncludeInWork;
                searchSheetsParams.IncludeAccepted = form.FilterIncludeAccepted;
                searchSheetsParams.IncludeNotAccepted = form.FilterIncludeNotAccepted;
                searchSheetsParams.IncludeCertDataInput = form.FilterIncludeCertDataInput;

                searchSheetsParams.OrderIncludeNew = form.FilterOrderIncludeNew;
                searchSheetsParams.OrderIncludeInWork = form.FilterOrderIncludeInWork;
                searchSheetsParams.OrderIncludeAccepted = form.FilterOrderIncludeAccepted;
                searchSheetsParams.OrderIncludeNotAccepted = form.FilterOrderIncludeNotAccepted;
                searchSheetsParams.OrderIncludeCertDataInput = form.FilterOrderIncludeCertDataInput;

                searchSheetsParams.OrderDateFrom = form.FilterOrderDateFrom;
                searchSheetsParams.OrderDateTo = form.FilterOrderDateTo;
                searchSheetsParams.ProvisorID = form.FilterProvisorID;
                searchSheetsParams.DateFrom = form.FilterWorksheetDateFrom;
                searchSheetsParams.DateTo = form.FilterWorksheetDateTo;

                CustomSheetsCheckBoxesPanel();

                if (searchSheetsParams.OrderID.HasValue)
                {
                    RefreshDocs(searchParams.OrderID);

                    //edgOrders.ApplyFilter(InputControlLotnView.ID_PROPERTY_NAME, searchSheetsParams.OrderID.ToString());
                    //edgOrders.ActivateFilter();
                }
                else
                {
                    //CustomSheetsCheckBoxesPanel();
                    //if (!chbDetailsSearchMode.Checked)
                    //    chbDetailsSearchMode.Checked = true;

                    RefreshDetails();
                }
            }
        }

        /// <summary>
        /// При изменении фильтра нужно пересчитать итоговые значения
        /// </summary>
        private void edgWorksheets_OnFilterChanged(object sender, EventArgs e)
        {
            edgWorksheets.RecalculateSummary();
        }

        /// <summary>
        /// Раскраска строк в таблице анкет в зависимости от статуса
        /// </summary>
        private void edgWorksheets_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var dbRow = (row.DataBoundItem as DataRowView).Row as Quality.AT_Doc_VersionsRow;
                var backColor = (dbRow.status_id == Constants.QK_IC_STATUS_ACCEPTED) ? Color.FromArgb(209, 255, 117) :
                    (dbRow.status_id == Constants.QK_IC_STATUS_NOT_ACCEPTED ? Color.FromArgb(255, 225, 225) : Color.White);
                for (int c = 0; c < row.Cells.Count; c++)
                    if (dgv.Columns[c].DataPropertyName == InputControlLotnWorksheetsView.IS_BLOCKED_PROPERTY_NAME && dbRow.is_blocked)
                        row.Cells[c].Style.BackColor = row.Cells[c].Style.SelectionBackColor = Color.Red;
                    else
                        row.Cells[c].Style.BackColor = row.Cells[c].Style.SelectionForeColor = backColor;
            }
        }

        /// <summary>
        /// Раскраска ПКУ-строк в синий цвет
        /// </summary>
        private void edgWorksheets_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgvrow = (sender as DataGridView).Rows[e.RowIndex] as DataGridViewRow;
            var dbrow = (dgvrow.DataBoundItem as DataRowView).Row as Quality.AT_Doc_VersionsRow;
            if (dbrow.is_pku)
            {
                e.CellStyle.BackColor = Color.FromArgb(100, 149, 237);
                e.CellStyle.SelectionForeColor = Color.Red;
            }
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ АНКЕТЫ

        /// <summary>
        /// Запуск окна редактирования анкеты входного контроля партии
        /// </summary>
        private void btnEditWorksheet_Click(object sender, EventArgs e)
        {
            EditWorksheet();
        }

        /// <summary>
        /// Запуск окна редактирования анкеты входного контроля партии
        /// </summary>
        private void EditWorksheet()
        {
            try
            {
                var sOrderID = SelectedWorksheet.order_id.ToString();
                var editForm = new EditInputControlLotnWorksheetForm(UserID, SelectedWorksheet, sOrderID, false); //SelectedDoc.order_id.ToString());
                editForm.ShowDialog();

                //if (editForm.ShowDialog(this) == DialogResult.OK)
                //{
                //    using (var adapter = new AT_Doc_Version_QuestionsTableAdapter())
                //        adapter.CreateNewVersion(UserID, SelectedWorksheet.doc_id, editForm.XmlAnswers);
                //}
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время сохранения результатов редактирования в БД: ", exc);
            }
        }

        /// <summary>
        /// Запуск окна редактирования анкеты по двойному клику на анкете
        /// </summary>
        private void edgWorksheets_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].DataPropertyName == InputControlLotnWorksheetsView.IS_BLOCKED_PROPERTY_NAME)
            {
                var dbRow = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Quality.AT_Doc_VersionsRow;
                if (dbRow != null && dbRow.is_blocked)
                {
                    var form = new LotnPrescriptionsForm(UserID, dbRow.item_id, dbRow.lot_number) { Owner = this };
                    form.ShowDialog();
                }
            }
            else
                EditWorksheet();
        }

        #endregion

        #region ПРОСМОТР, ПЕЧАТЬ И ЭКСПОРТ АНКЕТ ВХОДНОГО КОНТРОЛЯ ПАРТИИ


        /// <summary>
        /// Просмотр выбранной анкеты входного контроля партии
        /// </summary>
        private void btnViewWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ReportForm();
                form.ReportDocument = spReportProvider.GetReport(SelectedWorksheet);
                form.ShowDialog(this);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время просмотра анкеты входного контроля партии: ", exc);
            }
        }

        /// <summary>
        /// Печать анкеты входного контроля партии
        /// </summary>
        private void btnPrintWorksheet_Click(object sender, EventArgs e)
        {
            var printThread = new PrintDocsThread();
            printThread.ReportProvider = spReportProvider;
            var printParams = new PrintDocsParameters
            {
                PrinterName = cmbPrinters.SelectedItem.ToString(),
                Docs = new DataRow[] { SelectedWorksheet }
            };

            printThread.PrintDocumentsAsynch(printParams);
        }

        /// <summary>
        /// Экспорт таблицы анкет в EXCEL
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                edgWorksheets.ExportToExcel("Экспорт анкет", "worksheets", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время экспорта таблицы анкет входного контроля партии в Excel: ", exc);
            }
        }

        #endregion

     





    }

    #region КЛАСС ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА ЗАКАЗОВ НА ЗАКУПКУ

    /// <summary>
    /// Представление для грида с заказами на закупку
    /// </summary>
    public class InputControlLotnView : IDataView
    {
        /// <summary>
        /// Название свойства, которое должно выступать как идентификатор в таблице заказов на закупку
        /// </summary>
        public const string ID_PROPERTY_NAME = "order_id";

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

            var sc = pSearchParameters as InputControlLotnOrdersSearchParamters;
            using (var adapter = new AT_DocsTableAdapter())
            {
                adapter.SetTimeout(300);
                data = adapter.GetData(sc.SessionID, sc.FilterByStatus, sc.OrderID, null, null, null, null, null, null, null, null, null, null, null);
            }
        }

        /// <summary>
        /// Установка источника для грида с заказами
        /// </summary>
        /// <param name="pDataTable">Таблица с заказами на закупку</param>
        public void FillData(Quality.AT_DocsDataTable pDataTable)
        {
            data = pDataTable;
        }

        public InputControlLotnView()
        {
            this.dataColumns.Add(new PatternColumn("Номер ЗЗ", "order_id", new FilterCompareExpressionRule<Int64>("order_id"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дата приходования", "receipt_date", new FilterDateCompareExpressionRule("receipt_date")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Статус", "status", new FilterPatternExpressionRule("status")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Код поставщика", "vendor_id", new FilterCompareExpressionRule<Int64>("vendor_id")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Поставщик", "vendor", new FilterPatternExpressionRule("vendor")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("Всего партий", "lotn_count", new FilterCompareExpressionRule<Int32>("lotn_count")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Обработано партий", "lotn_processed", new FilterCompareExpressionRule<Int32>("lotn_processed")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Не обработано партий", "lotn_active", new FilterCompareExpressionRule<Int32>("lotn_active")) { Width = 80 });

            // [WMS-4777]
            this.dataColumns.Add(new PatternColumn("Филиал", "FilialName", new FilterPatternExpressionRule("FilialName")) { Width = 300 });
        }
    }

    #endregion



    #region КЛАСС ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА АНКЕТ ВХОДНОГО КОНТРОЛЯ ПАРТИИ

    /// <summary>
    /// Представление для грида с анкетами входного контроля партии
    /// </summary>
    public class InputControlLotnWorksheetsView : IDataView
    {
        /// <summary>
        /// Название свойства, которое должно выступать как идентификатор в таблице анкет входного контроля партии
        /// </summary>
        public const string ID_PROPERTY_NAME = "doc_id";

        /// <summary>
        /// Название свойства-индикатора наличия предписания на партию в анкете
        /// </summary>
        public const string IS_BLOCKED_PROPERTY_NAME = "is_blocked_str";

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
        //public void FillData(SearchParametersBase pSearchParameters)
        //{
        //    var sc = pSearchParameters as InputControlLotnWorkSheetsSearchParamters;
        //    using (var adapter = new AT_Doc_VersionsTableAdapter())
        //    {
        //        adapter.SetTimeout(300);
        //        data = adapter.GetData(sc.SessionID, null, sc.FilterByStatus, sc.OnlyActual, sc.Item_id, sc.LotNumber,
        //            sc.VendorID, sc.Manufacturer_id, sc.Order_statuses, sc.Order_date_from, sc.Order_date_to, sc.ProvisorID,
        //            sc.DateFrom, sc.DateTo);
        //    }
        //}
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as InputControlLotnWorkSheetsSearchParamters;
            using (var adapter = new AT_Doc_VersionsTableAdapter())
            {
                adapter.SetTimeout(300);
                data = adapter.GetData(sc.SessionID, sc.Order_id, sc.FilterByStatus, sc.OnlyActual, sc.Item_id, sc.LotNumber,
                    sc.VendorID, sc.Manufacturer_id, sc.Order_statuses, sc.Order_date_from, sc.Order_date_to, sc.ProvisorID,
                    sc.DateFrom, sc.DateTo);
            }
        }

        /// <summary>
        /// Установка источника для грида с анкетами входного контроля партии
        /// </summary>
        /// <param name="pDataTable">Таблица с анкетами входного контроля партии</param>
        public void FillData(Quality.AT_Doc_VersionsDataTable pDataTable)
        {
            data = pDataTable;
        }

        public InputControlLotnWorksheetsView()
        {
            this.dataColumns.Add(new PatternColumn("P", IS_BLOCKED_PROPERTY_NAME, new FilterPatternExpressionRule(IS_BLOCKED_PROPERTY_NAME)) { Width = 30 });
            this.dataColumns.Add(new PatternColumn("ПКУ", "is_pku_str", new FilterPatternExpressionRule("is_pku_str")) { Width = 35 });
            this.dataColumns.Add(new PatternColumn("Код статуса", "status_id", new FilterCompareExpressionRule<Int32>("status_id")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Статус", "status", new FilterPatternExpressionRule("status")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Код товара", "item_id", new FilterCompareExpressionRule<Int64>("item_id")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "item_name", new FilterPatternExpressionRule("item_name")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("Код поставщика", "vendor_id", new FilterCompareExpressionRule<Int64>("vendor_id")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Поставщик", "vendor", new FilterPatternExpressionRule("vendor")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("Производитель", "manufacturer", new FilterPatternExpressionRule("manufacturer")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("Форма хранения", "form", new FilterPatternExpressionRule("form")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Кол-во", "quantity", new FilterCompareExpressionRule<Int32>("quantity")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Серия", "vendor_lot", new FilterPatternExpressionRule("vendor_lot")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Срок годности", "expiration_date", new FilterPatternExpressionRule("expiration_date")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Партия", "lot_number", new FilterPatternExpressionRule("lot_number")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Блок", "block_id", new FilterPatternExpressionRule("block_id")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Номер сертификата", "cert_number", new FilterPatternExpressionRule("cert_number")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата сертификата", "cert_date", new FilterPatternExpressionRule("cert_date")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Регистрационный номер", "reg_number", new FilterPatternExpressionRule("reg_number")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата начала", "reg_date", new FilterPatternExpressionRule("reg_date")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата конца", "reg_end_date", new FilterPatternExpressionRule("reg_end_date")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Автор версии", "user_FIO", new FilterPatternExpressionRule("user_FIO")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Дата документа", "doc_date", new FilterDateCompareExpressionRule("doc_date")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дата версии", "version_date", new FilterDateCompareExpressionRule("version_date")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Номер документа", "doc_id", new FilterCompareExpressionRule<Int64>("doc_id"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Номер версии", "version_id", new FilterCompareExpressionRule<Int32>("version_id")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Ассорт. группа", "It_group", new FilterPatternExpressionRule("It_group")) { Width = 80 });
        }
    }

    #endregion
}
