using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

using CrystalDecisions.Shared;

using WMSOffice.Classes;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.ComplaintsTableAdapters;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Reports;
using WMSOffice.Dialogs;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно модуля возвратов поставщикам
    /// </summary>
    public partial class VendorReturnsWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Идентификатор выбранной накладной (в случае, если выбрано несколько строк, возвращается идентификатор первой из них).
        /// Если таблица пустая либо в ней не выбрана ни одна накладная, будет сгенерировано исключение
        /// </summary>
        private int SelectedDocId { get { return Convert.ToInt32(dgvInvoices.SelectedItem["Doc_ID"]); } }

        /// <summary>
        /// True, если в таблице накладных выделена хотя бы одна накладная и если несколько, то все они имеют одинаковый статус
        /// False, если таблица пуста либо в таблице не выделено ни одной накладной, либо выделено несколько накладных с разными статусами
        /// </summary>
        private bool IsDocSelected
        {
            get
            {
                if (dgvInvoices.SelectedItem == null)
                    return false;
                string status = SelectedDoc.Status_ID;
                foreach (var doc in SelectedDocs)
                    if (doc.Status_ID != status)
                        return false;
                return true;
            }
        }

        /// <summary>
        /// Признак тестовой версии
        /// </summary>
        private static bool IsTestVersion { get { return MainForm.IsTestVersion; } }

        /// <summary>
        /// Выбранная накладная в таблице с накладными либо null, если таблица пустая или в ней не выбрано ни одну накладную.
        /// Если в таблице выделено несколько накладных, то возвращается первая из них
        /// </summary>
        private Complaints.VR_DocsRow SelectedDoc { get { return dgvInvoices.SelectedItem as Complaints.VR_DocsRow; } }

        /// <summary>
        /// Коллекция идентификаторов накладных, выделенных в таблице. Если не выделена ни одна накладная, то коллекция пуста
        /// </summary>
        private IEnumerable<long> SelectedDocIds
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
        /// Коллекция накладных, выделенных в таблице. Если не выделена ни одна накладная, то коллекция пуста
        /// </summary>
        private IEnumerable<Complaints.VR_DocsRow> SelectedDocs
        {
            get
            {
                return
                    dgvInvoices.SelectedItems.ConvertAll(new Converter<DataRow, Complaints.VR_DocsRow>(x => x as Complaints.VR_DocsRow));
            }
        }

        /// <summary>
        /// Название таблицы с накладными в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocsTableName { get { return String.Format("{0}_Header", Name); } }

        /// <summary>
        /// Название таблицы с товарами в накладной в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocDetailsTableName { get { return String.Format("{0}_Details", Name); } }

        /// <summary>
        /// БД адаптер для работы с накладными
        /// </summary>
        private VR_DocsTableAdapter docsAdapter = new VR_DocsTableAdapter();

        /// <summary>
        /// Столбец с информацией о наличии вложенных файлов
        /// </summary>
        private DataGridViewImageColumn dgvcHasAttachedFiles = null;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ ОКНА

        public VendorReturnsWindow()
        {
            InitializeComponent();

            InitializePrinters();
            InitializeVendorReturnsGrid();
        }

        /// <summary>
        /// Загрузка данных в таблицы при загрузке окна
        /// </summary>
        private void VendorReturnsWindow_Load(object sender, EventArgs e)
        {
            LoadUserAccesses();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            RefreshDocs();
            Config.LoadDataGridViewSettings(ConfigDocDetailsTableName, dgvInvoiceLines);
        }

        /// <summary>
        /// Инициализация принтеров
        /// </summary>
        private void InitializePrinters()
        {
            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с накладными при создании окна
        /// </summary>
        private void InitializeVendorReturnsGrid()
        {
            dgvInvoices.Init(new VendorReturnsView(), true);

            #region ИНИЦИАЛИЗАЦИЯ "РАБОЧИХ" СТОЛБЦОВ

            foreach (DataGridViewColumn column in dgvInvoices.DataGrid.Columns)
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

            dgvInvoices.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvInvoices.UserID = UserID;
            dgvInvoices.SetCellStyles(dgvInvoiceLines.RowTemplate.DefaultCellStyle, dgvInvoiceLines.ColumnHeadersDefaultCellStyle);
            dgvInvoices.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvInvoices.AllowRangeColumns = true;
            dgvInvoices.UseMultiSelectMode = true;

            dgvInvoices.OnFilterChanged += dgvInvoices_OnFilterChanged;
            dgvInvoices.OnRowSelectionChanged += dgvInvoices_OnRowSelectionChanged;
            dgvInvoices.OnRowDoubleClick += new DataGridViewCellEventHandler(dgvInvoices_OnRowDoubleClick);
            dgvInvoices.OnCellContentClick += new DataGridViewCellEventHandler(dgvInvoices_OnCellContentClick);
            dgvInvoices.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvInvoices_OnDataBindingComplete);

            // активация постраничного просмотра
            dgvInvoices.CreatePageNavigator();
        }

        /// <summary>
        /// Обновление данных в таблице накладных с сохранением выделения и прокрутки
        /// </summary>
        private void RefreshDocs()
        {
            dgvInvoices.SaveExtraDataGridViewSettings(ConfigDocsTableName);
            var selectedDocIds = SelectedDocIds;

            var searchCriteria = new VendorReturnsSearchParameters() { SessionID = UserID };
            RefreshDataViewBinding(searchCriteria);

            dgvInvoices.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvInvoices.UnselectAllRows();

            bool isSelected = false;
            foreach (var id in selectedDocIds)
            {
                dgvInvoices.SelectRow("Doc_ID", id.ToString());
                isSelected = true;
            }
            if (!isSelected)
                dgvInvoices.SelectRow(0);

            dgvInvoices.ScrollToSelectedRow();
            CustomButtons();
        }

        /// <summary>
        /// Загрузка накладных в фильтруемый грид из БД
        /// </summary>
        private void RefreshDataViewBinding(VendorReturnsSearchParameters searchCriteria)
        {
            try
            {
                BackgroundWorker loadWorker = new BackgroundWorker();

                loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        dgvInvoices.DataView.FillData(e.Argument as VendorReturnsSearchParameters);
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
                        dgvInvoices.BindData(false);
                        dgvInvoices.AllowSummary = true;
                    }

                    this.waitProgressForm.CloseForce();
                };

                loadWorker.RunWorkerAsync(searchCriteria);

                this.waitProgressForm.ActionText = "Выполняется загрузка данных..";
                this.waitProgressForm.ShowDialog();
            }
            catch (Exception exc)
            {
                ShowError("Не удалось загрузить список накладных: " + Environment.NewLine + exc.Message);
            }
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void dgvInvoices_OnFilterChanged(object pSender, EventArgs pE)
        {
            dgvInvoices.RecalculateSummary();
        }

        void dgvInvoices_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (!IsTestVersion)
            //    return;

            var dr = dgvInvoices.SelectedItem;
            if (dr != null)
            {
                var statusID = dr["Status_ID"].ToString();
                var docTypeID = dr["Doc_Type"].ToString();

                if (docTypeID == "VR" && statusID == "215")
                {
                    var docID = Convert.ToInt32(dr["Doc_ID"]);
                    var supplierName = dr["Vendor"].ToString().Trim();

                    var dlgInvoiceEditor = new VendorReturnsInvoiceEditForm(docID, supplierName) { UserID = this.UserID };
                    if (dlgInvoiceEditor.ShowDialog() == DialogResult.OK)
                        RefreshDocs();
                }
            }
        }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        void dgvInvoices_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvInvoices.DataGrid.Rows)
            {
                var boundRow = (dgvInvoices.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.Complaints.VR_DocsRow;

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
                    dgvInvoices.DataGrid.Rows[row.Index].Cells[dgvcHasAttachedFiles.Index].Value = attachedFilesValue;
            }
        }

        /// <summary>
        /// Обновление списка накладных при нажатии на кнопку "Обновить"
        /// </summary>
        private void tbRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        /// <summary>
        /// Обновление списка товаров по выбранной накладной
        /// </summary>
        private void dgvInvoices_OnRowSelectionChanged(object sender, EventArgs e)
        {
            RefreshDetails();
        }

        /// <summary>
        /// Перезагрузка товаров в накладной
        /// </summary>
        private void RefreshDetails()
        {
            try
            {
                complaints.VR_DocDetails.Clear();
                if (dgvInvoices.SelectedItems.Count == 1)
                {
                    taVR_DocDetails.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    taVR_DocDetails.Fill(complaints.VR_DocDetails, UserID, SelectedDocId);
                }
                
                CustomButtons();
            }
            catch (Exception exc)
            {
                ShowError("Не удалось загрузить товары в накладной: " + Environment.NewLine + exc.Message);
            }
        }

        /// <summary>
        /// Настройка доступности кнопок на панели управления в зависимости от выбранной накладной
        /// </summary>
        private void CustomButtons()
        {
            btnShowAttachments.Visible = btnShowAttachments.Enabled = dgvInvoices.SelectedItems.Count == 1 && canShowAttachments;
            toolStripSeparator5.Visible = btnShowAttachments.Visible;

            btnAddInvoice.Visible = btnAddInvoice.Enabled = canCreateInvoice;
            btnEditInvoice.Visible = btnEditInvoice.Enabled = dgvInvoices.SelectedItems.Count == 1 && canEditInvoice;
            btnPrintDoc.Visible = btnPrintDoc.Enabled = dgvInvoices.SelectedItems.Count == 1;
            btnCreateVendorAct.Visible = btnCreateVendorAct.Enabled = dgvInvoices.SelectedItems.Count == 1 && !SelectedDoc.IsHasComplainsNull() && SelectedDoc.HasComplains;
            btnToWarehouse.Visible = btnToWarehouse.Enabled = IsDocSelected && SelectedDoc.Status_ID == "100" && canToWarehouse;
            btnPrintPackingList.Visible = btnPrintPackingList.Enabled = IsDocSelected && SelectedDoc.Status_ID == "120" && canPackingList;
            btnPrintInvoice.Visible = btnPrintInvoice.Enabled = IsDocSelected && (SelectedDoc.Status_ID == "145" || SelectedDoc.Status_ID == "150" || SelectedDoc.Status_ID == "217") && canPrintInvoice;

            #region [WMS-4353]

            btnShipping.Visible = btnShipping.Enabled = dgvInvoices.SelectedItems.Count == 1 && SelectedDoc.Status_ID == "155" && canShipping;

            //btnShipping.Enabled = btnShipping.Visible = false;

            //btnShipReturns.Visible = btnShipReturns.Enabled = dgvInvoices.SelectedItems.Count == 1 &&
            //    SelectedDoc.Status_ID == "155" && canShipping;

            btnShipReturns.Visible = btnShipReturns.Enabled = false;

            #endregion

            btnRK.Visible = btnRK.Enabled = IsDocSelected && (SelectedDoc.Status_ID == "170" || SelectedDoc.Status_ID == "160" || SelectedDoc.Status_ID == "219") && canRK;
            btnCorrection.Visible = btnCorrection.Enabled = dgvInvoices.SelectedItems.Count == 1 && SelectedDoc.Status_ID == "160" && canCorrection;
            btnDeleteInvoice.Visible = btnDeleteInvoice.Enabled = dgvInvoices.SelectedItems.Count == 1 && canDeleteInvoice && Convert.ToInt32(SelectedDoc.Status_ID) < 180;
            btnCreateVendorComplaint.Visible = btnCreateVendorComplaint.Enabled = dgvInvoices.SelectedItems.Count == 1 && SelectedDoc.Status_ID == "160" && canCreateVendorComplaint;
            btnReprintPaketDocs.Enabled = btnReprintPaketDocs.Visible = IsDocSelected && Convert.ToInt32(SelectedDoc.Status_ID) >= 155 && canPrintInvoice;
            btnReprintPackingList.Enabled = btnReprintPackingList.Visible = IsDocSelected && canPackingList && Convert.ToInt32(SelectedDoc.Status_ID) >= 130 && Convert.ToInt32(SelectedDoc.Status_ID) < 150;

            btnAcceptReturns.Visible = btnAcceptReturns.Enabled = IsTestVersion && canAcceptReturns;

            sprToStatuses.Visible = btnToWarehouse.Visible || btnShipping.Visible || btnRK.Visible || btnShipReturns.Visible || btnAcceptReturns.Visible;

            sprToAnnulirovanie.Visible = btnPrintInvoice.Visible || btnReprintPaketDocs.Visible || btnPrintPackingList.Visible || btnReprintPackingList.Visible;
            toolStripSeparator4.Visible = btnDeleteInvoice.Visible || btnCreateVendorComplaint.Visible;

            btnCorrectPickedReturns.Visible = btnCorrectPickedReturns.Enabled = canCorrectPickedReturns && dgvInvoices.SelectedItems.Count == 1 && Convert.ToInt32(SelectedDoc.Status_ID) == 153;

            btnCreateVatCorrection.Visible = btnCreateVatCorrection.Enabled = canCreateVatCorrection;

            btnCloseVirtualReturn.Visible = btnCloseVirtualReturn.Enabled = IsDocSelected && SelectedDoc.Status_ID == "100" && SelectedDoc.IsReturnFlialNull() && canCloseVirtualReturn;

            miOriginalReceived.Enabled = SelectedDoc != null;
        }

        #endregion

        #region ПРАВА ДОСТУПА НА КНОПКИ

        /// <summary>
        /// Признак, показывающий, может ли пользователь создавать накладную
        /// </summary>
        private bool canCreateInvoice;

        /// <summary>
        /// Признак, показывающий, может ли пользователь редактировать накладную
        /// </summary>
        private bool canEditInvoice;

        /// <summary>
        /// Признак, показывающий, может ли пользователь отправлять накладную в работу на склад
        /// </summary>
        private bool canToWarehouse;

        /// <summary>
        /// Признак, показывающий, может ли пользоватль печатать чистовик накладной
        /// </summary>
        private bool canPrintInvoice;

        /// <summary>
        /// Признак, показывающий, может ли пользователь печатать сборочный лист
        /// </summary>
        private bool canPackingList;

        /// <summary>
        /// Признак, показывающий, может ли пользователь заполнять данные об отправке возврата
        /// </summary>
        private bool canShipping;

        /// <summary>
        /// Признак, показывающий, может ли пользователь указывать факт прибытия расчет-корректировок
        /// </summary>
        private bool canRK;

        /// <summary>
        /// Признак, показывающий, может ли пользователь корректировать возвратную накладную
        /// </summary>
        private bool canCorrection;

        /// <summary>
        /// Признак, показывающий, может ли пользователь аннулировать накладную
        /// </summary>
        private bool canDeleteInvoice;

        /// <summary>
        /// Признак, показывающий, может ли пользователь принимать возврат
        /// </summary>
        private bool canAcceptReturns;

        /// <summary>
        /// Признак, показывающий, может ли пользователь корректировать собранный возврат
        /// </summary>
        private bool canCorrectPickedReturns;

        /// <summary>
        /// Признак, показывающий, может ли пользователь просматривать вложения
        /// </summary>
        private bool canShowAttachments;

        /// <summary>
        /// Признак, показывающий, может ли пользователь создавать акт корректировки НДС
        /// </summary>
        private bool canCreateVatCorrection;

        /// <summary>
        /// Признак, показывающий, может ли пользователь создавать претензию от поставщика
        /// </summary>
        private bool canCreateVendorComplaint;

        /// <summary>
        /// Признак, показывающий, может ли пользователь закрывать виртуальный возврат
        /// </summary>
        private bool canCloseVirtualReturn;


        /// <summary>
        /// Загрузка прав пользователей
        /// </summary>
        private void LoadUserAccesses()
        {
            try
            {
                using (var adapter = new VR_AccessTableAdapter())
                {
                    var table = adapter.GetData(UserID);
                    canCreateInvoice = GetAccess(table, "canCreate");
                    canEditInvoice = GetAccess(table, "canEdit");
                    canToWarehouse = GetAccess(table, "canToWarehouse");
                    canPrintInvoice = GetAccess(table, "canPrintInvoice");
                    canPackingList = GetAccess(table, "canPackingList");
                    canShipping = GetAccess(table, "canShipping");
                    canRK = GetAccess(table, "canRK");
                    canCorrection = GetAccess(table, "canCorrection");
                    canDeleteInvoice = GetAccess(table, "canDeleteInvoice");
                    canAcceptReturns = GetAccess(table, "canAcceptReturns");
                    canCorrectPickedReturns = GetAccess(table, "canCorrectPickedReturns");
                    canShowAttachments = GetAccess(table, "canShowAttachments");
                    canCreateVatCorrection = GetAccess(table, "canCreateNDSRk");
                    canCreateVendorComplaint = GetAccess(table, "canCreateVendorCO");
                    canCloseVirtualReturn = GetAccess(table, "canCloseVirtualReturn");
                }
            }
            catch (Exception exc)
            {
                ShowError("Не удалось загрузить роли пользователя для модуля возвратов поставщику: " + Environment.NewLine + exc.Message);
            }
        }

        /// <summary>
        /// Получение значение права доступа по его ключу
        /// </summary>
        /// <param name="pAccesses">Таблица с правами доступа</param>
        /// <param name="pKey">Ключ, которых характеризирует получаемое право доступа</param>
        /// <returns>True, если пользователь имеет право доступа, False если не имеет</returns>
        private static bool GetAccess(Complaints.VR_AccessDataTable pAccesses, string pKey)
        {
            foreach (Complaints.VR_AccessRow row in pAccesses)
                if (row.Entity_Key == pKey)
                    return row.Entity_Value;

            return false;
        }

        #endregion

        #region СОЗДАНИЕ, РЕДАКТИРОВАНИЕ И КОРРЕКТИРОВКА НАКЛАДНОЙ

        /// <summary>
        /// Создание новой накладной
        /// </summary>
        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            var window = new NewReturnInvoiceForm(UserID);
            window.Owner = this;
            window.ShowDialog();
            string docID = window.DocId.ToString();
            RefreshDocs();
            dgvInvoices.UnselectAllRows();

            bool isSelected = false;
            dgvInvoices.SelectRow("Doc_ID", docID);
            isSelected = true;

            if (!isSelected)
                dgvInvoices.SelectRow(0);

            dgvInvoices.ScrollToSelectedRow();
        }

        /// <summary>
        /// Редактирование накладной
        /// </summary>
        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            var window = new NewReturnInvoiceForm(UserID, SelectedDocId, SelectedDoc.Vendor_ID, SelectedDoc.ExpectedDate,
                SelectedDoc.ShippingID, false, SelectedDoc.Round, SelectedDoc.Doc_Type) { Owner = this };
            window.ShowDialog();
            RefreshDocs();
        }

        /// <summary>
        /// Корректировка накладной
        /// </summary>
        private void btnCorrection_Click(object sender, EventArgs e)
        {
            var window = new NewReturnInvoiceForm(UserID, SelectedDocId, SelectedDoc.Vendor_ID, SelectedDoc.ExpectedDate,
                SelectedDoc.ShippingID, true, SelectedDoc.Round, SelectedDoc.Doc_Type) { Owner = this };
            window.ShowDialog();
            ChangeStatus("170");
        }

        #endregion

        #region ПЕРЕХОД НАКЛАДНОЙ ПО СТАТУСАМ

        private void ChangeStatus(string pNewStatus)
        {
            ChangeStatus(pNewStatus, (DateTime?)null);
        }

        /// <summary>
        /// Продвижение выделенных накладных по статусу
        /// </summary>
        /// <param name="pNewStatus">Статус, на который нужно перевести все выделенные в таблице накладные</param>
        private void ChangeStatus(string pNewStatus, DateTime? rkCloseDate)
        {
            foreach (var id in SelectedDocIds)
                try
                {
                    docsAdapter.ChangeStatus(UserID, id, pNewStatus, null, null, null, rkCloseDate);
                    RefreshDocs();
                }
                catch (Exception exc)
                {
                    ShowError(String.Format("Возникла ошибка во время продвижения накладной ID = {0} по статусам: ", id) +
                        Environment.NewLine + exc.Message);
                }
        }

        /// <summary>
        /// Передача выбранных накладных в работу на склад
        /// </summary>
        private void btnToWarehouse_Click(object sender, EventArgs e)
        {
            if (SelectedDoc.Doc_Type.Equals("NR")) // обычный
                ChangeStatus("120");
            else if (SelectedDoc.Doc_Type.Equals("VR")) // виртуальный
                ChangeStatus("210");
            else if (SelectedDoc.Doc_Type.Equals("ZF")) // недовложение
                ChangeStatus("150");
        }

        /// <summary>
        /// Сохранение данных о машине, на которой уехал возврат
        /// </summary>
        [Obsolete]
        private void btnShipping_Click(object sender, EventArgs e)
        {
            var window = new ShippingReturnToCarForm() { Owner = this, CheckDataBeforeSave = false };
            window.ShowDialog();
            if (window.DialogResult == DialogResult.OK)
            {
                SetShippingData(null, null, DateTime.Now, "160");

                // [WMS-4330]
                try
                {
                    var carNumber = window.CarNumber.Substring(0, Math.Min(window.CarNumber.Length, 20));
                    var driverName = window.DriverName.Substring(0, Math.Min(window.DriverName.Length, 50));
                    var shippingDate = window.ShippingDate.Date;
                    docsAdapter.SaveDriverInfo(SelectedDocId, carNumber, driverName, shippingDate);

                    RefreshDocs();
                }
                catch (Exception ex)
                {
                    ShowError("Возникла ошибка во время сохранения данных об отгрузке товара: " + Environment.NewLine + ex.Message);
                }
            }
        }

        /// <summary>
        /// Отгрузка возврата поставщику
        /// </summary>
        private void btnShipReturns_Click(object sender, EventArgs e)
        {
            var window = new ShippingReturnToCarForm() { Owner = this, CheckDataBeforeSave = true };
            window.ShowDialog();
            if (window.DialogResult == DialogResult.OK)
            {
                SetShippingData(null, null, DateTime.Now, "158");

                // [WMS-4330]
                try
                {
                    var carNumber = window.CarNumber.Substring(0, Math.Min(window.CarNumber.Length, 20));
                    var driverName = window.DriverName.Substring(0, Math.Min(window.DriverName.Length, 50));
                    var shippingDate = window.ShippingDate.Date;
                    docsAdapter.SaveDriverInfo(SelectedDocId, carNumber, driverName, shippingDate);

                    RefreshDocs();
                }
                catch (Exception ex)
                {
                    ShowError("Возникла ошибка во время сохранения данных об отгрузке товара: " + Environment.NewLine + ex.Message);
                }
            }
        }

        /// <summary>
        /// Сохранение данных по отгрузке возврата поставщику
        /// </summary>
        /// <param name="pCarNumber">Номер автомобиля, на котором уехал возврат</param>
        /// <param name="pDriverName">ФИО водителя, который забрал накладную</param>
        /// <param name="pShippingDate">Дата отгрузки</param>
        /// <param name="pNewStatus">Новый статус</param>
        private void SetShippingData(string pCarNumber, string pDriverName, DateTime pShippingDate, string pNewStatus)
        {
            try
            {
                docsAdapter.ChangeStatus(UserID, SelectedDocId, pNewStatus, pCarNumber, pDriverName, pShippingDate, null);
            }
            catch (Exception exc)
            {
                ShowError("Возникла ошибка во время сохранения данных об отгрузке товара: " + Environment.NewLine + exc.Message);
            }
        }

        /// <summary>
        /// Указание прибытия рассчет-корректировок для выделенных накладных
        /// После перевода на этот статус накладные попадают в JD для обработки финансовых показателей
        /// </summary>
        private void btnRK_Click(object sender, EventArgs e)
        {
            try
            {
                var sourceStatus = SelectedDoc.Status_ID;
                var targetStatus = sourceStatus == "219" ? "190" : "180";

                var dlgRkCloseDateEditorForm = new RkCloseDateEditorForm { UserID = this.UserID };
                if (dlgRkCloseDateEditorForm.ShowDialog() == DialogResult.OK)
                    ChangeStatus(targetStatus, dlgRkCloseDateEditorForm.RkCloseDate.Date);
            }
            catch (Exception exc)
            {
                ShowError("Возникла ошибка во время сохранения данных о прибытии рассчет-корректировок: " + Environment.NewLine + exc.Message);
            }
        }

        #endregion

        #region ПЕЧАТЬ СБОРОЧНОГО ЛИСТА

        /// <summary>
        /// Печать сборочных листов для выбранных накладных
        /// </summary>
        private void btnPrintPackingList_Click(object sender, EventArgs e)
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
            var parameters = new PrinterWorkerParameters() { PrinterName = cmbPrinters.Text, PrintDocType = PrintDocsType.PackingList };
            parameters.DocsToPrint.AddRange(SelectedDocs);
            printWorker.RunWorkerAsync(parameters);
        }

        /// <summary>
        /// Подготовка данных для печати сборочного листа по электронной возвратной накладной
        /// </summary>
        /// <param name="pDoc">Документ, по которому получаем данные</param>
        /// <returns>DataSet з заполненными таблицами для сборочного листа</returns>
        public Complaints PreparePackingListData(Complaints.VR_DocsRow pDoc)
        {
            try
            {
                var dataSet = new Complaints();
                using (var adapter = new VR_GetPSN_HeaderTableAdapter())
                    adapter.Fill(dataSet.VR_GetPSN_Header, UserID, (int)pDoc.Doc_ID);
                CreateBarCode(dataSet.VR_GetPSN_Header.Rows[0] as Complaints.VR_GetPSN_HeaderRow);

                using (var adapter = new VR_GetPSN_DetailTableAdapter())
                    adapter.Fill(dataSet.VR_GetPSN_Detail, UserID, (int)pDoc.Doc_ID);
                return dataSet;
            }
            catch (Exception exc)
            {
                ShowError("Возникла ошибка при подготовке данных для печати сборочного: " + Environment.NewLine + exc.Message);
                return null;
            }
        }

        /// <summary>
        /// Создание штрих-кода в виде байтового массива по текстовому представлению штрих кода
        /// </summary>
        /// <param name="pHeaderRow">Строка в БД, содержащая данные о заголовке сборочного листа</param>
        private static void CreateBarCode(Complaints.VR_GetPSN_HeaderRow pHeaderRow)
        {
            var barCodeCtrl = new BarCodeCtrl();
            barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
            barCodeCtrl.Size = new Size(720, 200);
            barCodeCtrl.BarCodeHeight = 140;
            barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 24, FontStyle.Bold);
            barCodeCtrl.HeaderText = String.Empty;
            barCodeCtrl.LeftMargin = 10;
            barCodeCtrl.ShowFooter = true;
            barCodeCtrl.TopMargin = 20;
            barCodeCtrl.BarCode = pHeaderRow.Bar_Code;
            byte[] barCode = null;
            using (var ms = new MemoryStream())
            {
                barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                barCode = ms.ToArray();
            }
            pHeaderRow.Bar_Code_IMG = barCode;
        }

        /// <summary>
        /// Создание сборочного листа
        /// </summary>
        /// <param name="pDs">Источник данных для сборочного листа</param>
        /// <returns>Готовый сборочный лист (Crystal Report)</returns>
        private ComplaintVendorReturnPackingListReport CreatePackingListReport(Complaints pDs)
        {
            if (pDs.VR_GetPSN_Header.Rows.Count < 1)
                throw new ArgumentException("Не удалось загрузить заголовок отчета!");
            else if (pDs.VR_GetPSN_Detail.Rows.Count < 1)
                throw new ArgumentException("Отчет не содержит ни одной строки!");
            var report = new ComplaintVendorReturnPackingListReport();
            report.SetDataSource(pDs);
            return report;
        }

        /// <summary>
        /// Повторная печать сборочного листа
        /// </summary>
        private void btnReprintPackingList_Click(object sender, EventArgs e)
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
            var parameters = new PrinterWorkerParameters()
            {
                PrinterName = cmbPrinters.Text,
                PrintDocType = PrintDocsType.PackingList,
                IsReprint = true
            };
            parameters.DocsToPrint.AddRange(SelectedDocs);
            printWorker.RunWorkerAsync(parameters);
        }

        #endregion

        #region ПЕЧАТЬ НАКЛАДНЫХ

        /// <summary>
        /// Печать накладных
        /// </summary>
        private void btnPrintInvoices_Click(object sender, EventArgs e)
        {
            int? shippingID = null;
            if (!ApplyTargetShippingID(ref shippingID))
                return;

            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
            var parameters = new PrinterWorkerParameters()
            {
                PrinterName = cmbPrinters.Text,
                PrintDocType = PrintDocsType.Invoice,
                ShippingID = shippingID
            };
            parameters.DocsToPrint.AddRange(SelectedDocs);
            printWorker.RunWorkerAsync(parameters);
        }

        private bool ApplyTargetShippingID(ref int? shippingID)
        {
            try
            {
                if (!IsTestVersion)
                    return true;

                using (var adapter = new Data.ComplaintsTableAdapters.VR_GetShippingListTableAdapter())
                    adapter.Fill(complaints.VR_GetShippingList, UserID);

                var dlgSelectTargetShipping = new WMSOffice.Dialogs.RichListForm();
                dlgSelectTargetShipping.Text = "Выберите склад отгрузки";
                dlgSelectTargetShipping.AddColumn("Warehouse_DSC", "Warehouse_DSC", "Склад");
                dlgSelectTargetShipping.ColumnForFilters = new List<string>(new string[] { "Warehouse_DSC" });
                dlgSelectTargetShipping.FilterChangeLevel = 0;

                complaints.VR_GetShippingList.DefaultView.RowFilter = string.Empty;
                dlgSelectTargetShipping.DataSource = complaints.VR_GetShippingList;

                if (dlgSelectTargetShipping.ShowDialog() != DialogResult.OK)
                    return false;

                var targetShipping = dlgSelectTargetShipping.SelectedRow as Data.Complaints.VR_GetShippingListRow;
                shippingID = targetShipping.IsWarehouse_IDNull() ? (int?)null : (int)targetShipping.Warehouse_ID;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Повторная печать накладных
        /// </summary>
        private void btnReprintPaketDocs_Click(object sender, EventArgs e)
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
            var parameters = new PrinterWorkerParameters()
            {
                PrinterName = cmbPrinters.Text,
                PrintDocType = PrintDocsType.Invoice,
                IsReprint = true
            };
            parameters.DocsToPrint.AddRange(SelectedDocs);
            printWorker.RunWorkerAsync(parameters);
        }

        /// <summary>
        /// Печатает в фоне документы
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = (PrinterWorkerParameters)e.Argument;
                Complaints ds = null;
                var needPrintWatermark = false;
                foreach (var doc in param.DocsToPrint)
                    if (param.PrintDocType == PrintDocsType.Invoice) // Печать 4-х экземпляров накладной
                    {
                        // Печать возвратной накладной
                        ds = PrepareDataForInvoicesPrint(doc);

                        needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "VR", 25, Convert.ToInt64(doc.Doc_ID), (string)null);

                        using (var report = new ComplaintVendorReturnInvoiceReport())
                        {
                            report.SetDataSource(ds);
                            report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);
                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.PrintToPrinter(4, true, 1, 0);

                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "VR", 25, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.VR_GetNakl_Detail.Count), param.PrinterName, 4);
                        }

                        // Печать гарантийного письма
                        ds = PrepareDataForWarrantyLetterPrint(doc);

                        needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "VR", 26, Convert.ToInt64(doc.Doc_ID), (string)null);

                        using (var report = new ComplaintVendorReturnWarrantyLetterReport())
                        {
                            report.SetDataSource(ds);
                            report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);
                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.PrintToPrinter(1, true, 1, 0);

                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "VR", 26, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.VR_WarrantyLetter.Count), param.PrinterName, 1);
                        }
                    }
                    else    // Печать сборочного
                    {
                        ds = PreparePackingListData(doc);
                        using (var report = new ComplaintVendorReturnPackingListReport())
                        {
                            report.SetDataSource(ds);
                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.PrintToPrinter(1, true, 1, 0);

                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "VR", 2, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.VR_GetPSN_Detail.Count), param.PrinterName, 1);
                        }
                    }
                e.Result = param;
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Подготовка данных для печати накладной
        /// </summary>
        /// <param name="pDoc">Документ, по которому получаем данные</param>
        /// <returns>DataSet з заполненными таблицами для печати накладной</returns>
        private Complaints PrepareDataForInvoicesPrint(Complaints.VR_DocsRow pDoc)
        {
            try
            {
                var ds = new Complaints();
                using (var adapter = new VR_GetNakl_HeaderTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Fill(ds.VR_GetNakl_Header, UserID, (int)pDoc.Doc_ID);
                }

                using (var adapter = new VR_GetNakl_DetailTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Fill(ds.VR_GetNakl_Detail, UserID, (int)pDoc.Doc_ID);
                }

                using (var adapter = new CompanyConstantsTableAdapter())
                    adapter.FillVR(ds.CompanyConstants);
                    //adapter.Fill(ds.CompanyConstants, "UA", pDoc.IsDoc_DateNull() ? DateTime.Today : pDoc.Doc_Date);


                if (ds.VR_GetNakl_Header != null && ds.VR_GetNakl_Header.Count > 0)
                    PrepareReturnedInvoiceBarcode(ds.VR_GetNakl_Header);

                return ds;
            }
            catch (Exception exc)
            {
                ShowError("Не удалось получить данные для электронной возвратной накладной: " + Environment.NewLine + exc.Message);
                return null;
            }
        }

        /// <summary>
        /// Статический метод добавляет штрих-код по тексту
        /// </summary>
        /// <param name="putList"></param>
        private static void PrepareReturnedInvoiceBarcode(Data.Complaints.VR_GetNakl_HeaderDataTable naklHeader)
        {
            if (naklHeader.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(1000, 200); // 720
                barCodeCtrl.BarCodeHeight = 140;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 24, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10;
                barCodeCtrl.ShowFooter = true;
                barCodeCtrl.TopMargin = 20;
                barCodeCtrl.BarCode = naklHeader[0].Bar_Code;
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                naklHeader[0].Bar_Code_Bin = barCode;
            }
        }


        /// <summary>
        /// Подготовка данных для печати гарантийного письма
        /// </summary>
        /// <param name="pDoc">Документ, по которому получаем данные</param>
        /// <returns>DataSet з заполненными таблицами для печати накладной</returns>
        private Complaints PrepareDataForWarrantyLetterPrint(Complaints.VR_DocsRow pDoc)
        {
            try
            {
                var ds = new Complaints();
                using (var adapter = new Data.ComplaintsTableAdapters.VR_WarrantyLetterTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Fill(ds.VR_WarrantyLetter, (int)pDoc.Doc_ID);
                }

                using (var adapter = new Data.ComplaintsTableAdapters.CompanyConstantsTableAdapter())
                    adapter.Fill(ds.CompanyConstants, "UA", pDoc.IsDoc_DateNull() ? DateTime.Today : pDoc.Doc_Date);

                return ds;
            }
            catch (Exception exc)
            {
                ShowError("Не удалось получить данные для гарантийного письма: " + Environment.NewLine + exc.Message);
                return null;
            }
        }


        /// <summary>
        /// Обработка окончания печати документов
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError((e.Result as Exception).Message);
            else
            {
                var param = e.Result as PrinterWorkerParameters;
                if (!param.IsReprint)
                {
                    foreach (var doc in param.DocsToPrint)
                    {
                        try
                        {
                            var success = true;

                            // Создание заданий (в тестовой версии)
                            if (IsTestVersion)
                                success = CreateTasks(param);

                            if (success)
                                ChangeStatus(param);
                        }
                        catch (Exception ex)
                        {
                            ShowError(ex);
                        }
                    }

                    RefreshDocs();
                }
            }
        }

        private bool CreateTasks(PrinterWorkerParameters param)
        {
            try
            {
                switch (param.PrintDocType)
                {
                    case PrintDocsType.PackingList:

                        #region СОЗДАНИЕ ЗАДАНИЯ ПЕРЕПАКОВКИ

                        using (var adapter = new VR_DocsTableAdapter())
                            adapter.CreateRepackTasks(UserID, SelectedDocId);

                        #endregion

                        break;
                    case PrintDocsType.Invoice:

                        #region 1. СМЕНА СКЛАДА ОТГРУЗКИ

                        using (var adapter = new VR_DocsTableAdapter())
                            adapter.ChangeDocShippingID(UserID, SelectedDocId, param.ShippingID);

                        #endregion

                        #region 2. СОЗДАНИЕ М/С ЗАКАЗА ПО ДОКУМЕНТУ ВОЗВРАТА

                        // Для отгрузки на ЦС заказ не создаем
                        if (param.ShippingID.Equals(17000) || param.ShippingID.Equals(17001))
                            break;

                        var errorCode = (int?)null;
                        var errorMessage = (string)null;
                        var direction = "РАС";

                        using (var adapter = new VR_DocsTableAdapter())
                            adapter.CreateInterbranchOrder(SelectedDocId, direction, ref errorCode, ref errorMessage);

                        if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                            throw new Exception(errorMessage);

                        #endregion

                        break;
                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowError("Возникла ошибка во время создания задания: " + Environment.NewLine + ex.Message);
                return false;
            }
        }

        private bool ChangeStatus(PrinterWorkerParameters param)
        {
            try
            {
                var sourceStatus = SelectedDoc.Status_ID;
                var targetStatus = string.Empty;

                switch (param.PrintDocType)
                {
                    case PrintDocsType.PackingList:
                        targetStatus = IsTestVersion ? "125" : "130";
                        break;
                    case PrintDocsType.Invoice:
                        targetStatus = sourceStatus == "217" ? "219" /*220*/ : "155";  // [UPD 17.08.2017]
                        break;
                    default:
                        break;
                }

                using (var adapter = new VR_DocsTableAdapter())
                    adapter.ChangeStatus(UserID, SelectedDocId, targetStatus, null, null, null, null);

                return true;
            }
            catch (Exception ex)
            {
                ShowError("Возникла ошибка во время продвижения накладной по статусам: " + Environment.NewLine + ex.Message);
                return false;
            }
        }

        #endregion

        #region КЛАСС ПАРАМЕТРОВ ПЕЧАТИ

        /// <summary>
        /// Класс, содержащий параметры для печати сборочного, черновика и чистовика ЭВН
        /// </summary>
        private class PrinterWorkerParameters
        {

            /// <summary>
            /// Список ЭВН, для которых печатаются документы
            /// </summary>
            public List<Complaints.VR_DocsRow> DocsToPrint { get { return docsToPrint; } }

            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }

            /// <summary>
            /// Тип печати 
            /// </summary>
            public PrintDocsType PrintDocType { get; set; }

            /// <summary>
            /// Признак, показывающий, является ли печать повторной
            /// </summary>
            public bool IsReprint { get; set; }

            /// <summary>
            /// Склад отгрузки
            /// </summary>
            public int? ShippingID { get; set; }

            /// <summary>
            /// Список ЭВН, для которых печатаются документы
            /// </summary>
            private List<Complaints.VR_DocsRow> docsToPrint = new List<Complaints.VR_DocsRow>();
        }

        /// <summary>
        /// Тип печати 
        /// </summary>
        private enum PrintDocsType
        {
            /// <summary>
            /// Печать пакета накладных
            /// </summary>
            Invoice,

            /// <summary>
            /// Печать сборочного листа
            /// </summary>
            PackingList
        }

        #endregion

        #region ПЕЧАТЬ НАКЛАДНОЙ

        /// <summary>
        /// Печать выбранной накладной
        /// </summary>
        private void btnPrintDoc_Click(object sender, EventArgs e)
        {
            using (var report = new ComplaintVendorReturnInvoiceReport())
            {
                var ds = PrepareDataForInvoicesPrint(SelectedDoc);

                if (ds == null)
                    return;

                var needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "VR", 25, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null);
                report.SetDataSource(ds);
                report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);

                ReportForm form = new ReportForm() { Text = string.Format("Накладная № {0}", SelectedDoc.Doc_ID) };
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "VR", 25, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.VR_GetNakl_Detail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }


                //string message = ExportHelper.ExportCrystalReport(report, ExportFormatType.PortableDocFormat, "Экспорт возвратной накладной",
                //    "накладная №" + SelectedDoc.Doc_ID, true);
                //if (!String.IsNullOrEmpty(message))
                //    Logger.ShowErrorMessageBox("Во время экспорта в PDF возникла ошибка: " + Environment.NewLine + message);
            }
        }

        #endregion

        #region АННУЛИРОВАНИЕ НАКЛАДНОЙ

        /// <summary>
        /// Запуск аннулирования накладной при нажатии на соответствующую кнопку
        /// </summary>
        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите аннулировать эту накладную? Будет снят жесткий резерв со всех " +
                "товаров с этой накладной!", "Аннулирование накладной", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                DeleteDoc();
        }

        /// <summary>
        /// Собственно, аннулирование накладной в БД
        /// </summary>
        private void DeleteDoc()
        {
            try
            {
                docsAdapter.DeleteDoc(UserID, SelectedDocId);
                MessageBox.Show("Накладная успешно аннулирована.", "Аннулирование накладной", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                ShowError("Не удалось аннулировать накладную: " + Environment.NewLine + exc.Message);
            }
            finally
            {
                RefreshDocs();
            }
        }

        #endregion

        #region УСТАНОВКА ПРИЗНАКА "ПОЛУЧЕН ОРИГИНАЛ"

        void dgvInvoices_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInvoices.DataGrid.Columns[e.ColumnIndex].DataPropertyName == "HaveOriginal")
                this.ChangeOriginalReceived();
        }

        private void miOriginalReceived_Click(object sender, EventArgs e)
        {
            this.ChangeOriginalReceived();
        }

        private void ChangeOriginalReceived()
        {
            try
            {
                if (!IsDocSelected)
                    return;

                var isChecked = SelectedDoc.IsHaveOriginalNull() ? false : SelectedDoc.HaveOriginal;
                var targetFlag = !isChecked;

                foreach (var doc in SelectedDocs)
                {
                    var docID = doc.Doc_ID;

                    using (var adapter = new Data.ComplaintsTableAdapters.VR_DocsTableAdapter())
                        adapter.ChangeOriginalReceivedFlag(docID, targetFlag, UserID);

                    doc.HaveOriginal = targetFlag;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время изменения признака \"Оригинал получен\" возникла ошибка:", exc);
            }
        }

        #endregion

        #region СОХРАНЕНИЕ НАСТРОЕК ПРИ ЗАКРЫТИИ ОКНА

        /// <summary>
        /// При закрытии окна настройки гридов сохраняются в конфигурационном файле
        /// </summary>
        private void VendorReturnsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(ConfigDocDetailsTableName, dgvInvoiceLines);
            dgvInvoices.SaveExtraDataGridViewSettings(ConfigDocsTableName);
        }

        #endregion

        #region ЭКСПОРТ В EXCEL

        /// <summary>
        /// Экспорт в Excel товаров в накладной
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string message = ExportHelper.ExportDataGridViewToExcel(dgvInvoiceLines, "Экспорт товаров в накладной",
                "товары в накладной №" + SelectedDocId, true);
            if (!String.IsNullOrEmpty(message))
                Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
        }

        /// <summary>
        /// Экспорт накладных в Excel
        /// </summary>
        private void btnExportDocsToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                dgvInvoices.ExportToExcel("Экспорт накладных", "список накладных", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: ", exc);
            }
        }

        #endregion

        private void btnAcceptReturns_Click(object sender, EventArgs e)
        {
            try
            {
                var invoiceBarCode = string.Empty;
                var errorCode = (int?)null;
                var errorMessage = (string)null;

                var dlgInvoiceScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Label = "Отсканируйте м/с накладную,\r\nвозврат по которой необходимо принять",
                    Text = "Прием возврата",
                    Image = Properties.Resources.barcode
                };

                if (dlgInvoiceScanner.ShowDialog() == DialogResult.OK)
                    invoiceBarCode = dlgInvoiceScanner.Barcode;

                // Определить возможность принять накладную на филиале
                using (var adapter = new Data.ComplaintsTableAdapters.VR_DocsTableAdapter())
                    adapter.CanConfirmInvoice(this.UserID, invoiceBarCode);

                // Принять накладную на филиале
                using (var adapter = new Data.ComplaintsTableAdapters.VR_DocsTableAdapter())
                    adapter.ConfirmBranchOrder(this.UserID, invoiceBarCode, ref errorCode, ref errorMessage);

                if (errorCode.HasValue || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #region ПОИСК В АРХИВЕ

        private void btnSearchArchiveDocs_Click(object sender, EventArgs e)
        {
            var frmVendorReturnsSearchDocs = new VendorReturnsSearchDocsForm { UserID = this.UserID };
            if (frmVendorReturnsSearchDocs.ShowDialog(this) == DialogResult.OK)
                SearchArchiveDocs(frmVendorReturnsSearchDocs.SearchCriteria);
        }

        /// <summary>
        /// Поиск архивных данных в таблице накладных с сохранением выделения и прокрутки
        /// </summary>
        /// <param name="searchCriteria">Критерий поиска</param>
        private void SearchArchiveDocs(VendorReturnsSearchParameters searchCriteria)
        {
            dgvInvoices.SaveExtraDataGridViewSettings(ConfigDocsTableName);
            var selectedDocIds = SelectedDocIds;

            RefreshDataViewBinding(searchCriteria);

            dgvInvoices.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvInvoices.UnselectAllRows();

            var isSelected = false;
            foreach (var id in selectedDocIds)
            {
                dgvInvoices.SelectRow("Doc_ID", id.ToString());
                isSelected = true;
            }

            if (!isSelected)
                dgvInvoices.SelectRow(0);

            dgvInvoices.ScrollToSelectedRow();
            CustomButtons();
        }

        #endregion

        private void btnCorrectPickedReturns_Click(object sender, EventArgs e)
        {
            var docID = SelectedDoc.Doc_ID;
            new WMSOffice.Dialogs.Complaints.CorrectPickedReturnsForm(docID) { UserID = this.UserID }.ShowDialog();
        }

        private void btnShowAttachments_Click(object sender, EventArgs e)
        {
            if (SelectedDoc != null)
            {
                using (Dialogs.Complaints.ComplaintAttachmentsForm form = new ComplaintAttachmentsForm(UserID, SelectedDoc.Doc_ID, true, false, false))
                {
                    form.ShowDialog();
                    RefreshDocs();
                }
            }
        }

        private void btnCreateVatCorrection_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedDoc != null)
                {
                    using (var form = new VendorReturnsVatCorrectionForm() { UserID = this.UserID })
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                            RefreshDocs();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #region ОТКАЗ ПОСТАВЩИКА ОТ ВОЗВРАТА

        private void btnCreateVendorComplaint_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Внимание!\n\nПо данному документу будет создана ПРЕТЕНЗИЯ,\nа сам документ будет АННУЛИРОВАН либо\nВОЗВРАЩЁН в один из предыдущих статусов.\n\nПродолжить?", "Отказ поставщика от возврата", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                docsAdapter.CreateVendorComplaint(UserID, SelectedDocId);
                RefreshDocs();
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
                Data.Complaints.VR_Vendor_Act_ListRow selectedAct = null;

                var ds = new Data.Complaints();

                using (var adapter = new Data.ComplaintsTableAdapters.VR_Vendor_Act_ListTableAdapter())
                    adapter.Fill(ds.VR_Vendor_Act_List, UserID, SelectedDocId);

                if (ds.VR_Vendor_Act_List.Count == 1)
                {
                    selectedAct = ds.VR_Vendor_Act_List[0];
                }
                else
                {
                    var dlgSelectAct = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectAct.Text = "Выберите акт расхождений";
                    dlgSelectAct.AddColumn("Act_Header", "Act_Header", "Акт расхождений");
                    dlgSelectAct.FilterVisible = false;
                    dlgSelectAct.DataSource = ds.VR_Vendor_Act_List;

                    if (dlgSelectAct.ShowDialog() == DialogResult.OK)
                        selectedAct = dlgSelectAct.SelectedRow as Data.Complaints.VR_Vendor_Act_ListRow;
                }

                if (selectedAct == null)
                    return;

                using (var report = new ComplaintVendorDiscrepancyActReport())
                {
                    using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_HeaderTableAdapter())
                        adapter.Fill(ds.CO_Create_ActDiscrepancy_Header, UserID, selectedAct.CO_Doc_ID);

                    using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_DetailsTableAdapter())
                        adapter.Fill(ds.CO_Create_ActDiscrepancy_Details, UserID, selectedAct.CO_Doc_ID);

                    using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_CommissionTableAdapter())
                        adapter.Fill(ds.CO_Create_ActDiscrepancy_Commission, UserID, selectedAct.CO_Doc_ID);

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

        private void btnCloseVirtualReturn_Click(object sender, EventArgs e)
        {
            try
            {
                var targetStatus = "160";

                 using (var adapter = new VR_DocsTableAdapter())
                    adapter.ChangeStatus(UserID, SelectedDocId, targetStatus, null, null, null, null);

                 RefreshDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для грида с электронными возвратными накладными поставщику
    /// </summary>
    public class VendorReturnsView : IDataView
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
            var sc = pSearchParameters as VendorReturnsSearchParameters;
            using (var adapter = new VR_DocsTableAdapter())
                data = adapter.GetData(sc.SessionID, sc.DocID, sc.VendorID, sc.PeriodFrom, sc.PeriodTo, sc.StatusID, sc.UserDocs);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public VendorReturnsView()
        {
            this.dataColumns.Add(new PatternColumn("№ накладной", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Дата накладной", "ExpectedDate", new FilterDateCompareExpressionRule("ExpectedDate"), SummaryCalculationType.Count));
            this.dataColumns.Add(new ImagePatternColumn("П. ф.", "HasAttachedFiles") { Width = 22 });
            this.dataColumns.Add(new PatternColumn("Пользователь", "User", new FilterPatternExpressionRule("User"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Дата создания", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("НДС/не НДС накладная", "IS_VAT", new FilterPatternExpressionRule("IS_VAT"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Поставщик", "Vendor", new FilterPatternExpressionRule("Vendor"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Плательщик/не плательщик НДС", "VAT_Payer", new FilterPatternExpressionRule("VAT_Payer"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Статус", "StatusName", new FilterPatternExpressionRule("StatusName"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Номер в JDE", "JDE_Doc", new FilterPatternExpressionRule("JDE_Doc"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Итог. сумма", "Amount_UAH", new FilterCompareExpressionRule<Int64>("Amount_UAH"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Format = "N4" });
            this.dataColumns.Add(new PatternColumn("Тип возврата", "Doc_Type_Name", new FilterPatternExpressionRule("Doc_Type_Name"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("МОЗ", "MOZ", new FilterPatternExpressionRule("MOZ"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Планировщик", "Planner", new FilterPatternExpressionRule("Planner"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Дата возврата", "PlanReturnDate", new FilterDateCompareExpressionRule("PlanReturnDate"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Филиал возврата", "ReturnFlial", new FilterCompareExpressionRule<Int32>("ReturnFlial"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Тип доставки", "ReturnMethod", new FilterPatternExpressionRule("ReturnMethod"), SummaryCalculationType.Count));

            this.dataColumns.Add(new PatternColumn("Ориг. получ.", "HaveOriginal", ColumnType.Logical, new FilterEmptyExpressionRule(), SummaryCalculationType.None) { Width = 40 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка накладных
    /// </summary>
    public class VendorReturnsSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }

        public long? DocID { get; set; }
        public int? VendorID { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string StatusID { get; set; }
        public int? UserDocs { get; set; }

        public VendorReturnsSearchParameters()
        {
            StatusID = (string)null;
        }
    }
}
