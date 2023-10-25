using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Threading;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Controls.Receive.Measurement;

namespace WMSOffice.Window
{
    public partial class ReWeightPalletPacksWindow : GeneralWindow
    {
        public bool Terminate { get; private set; }

        public string PackListBarCode { get; private set; }

        public string SSCCBarCode { get; private set; }

        public Data.WH.PWC_CheckRoomRow WHDocHeader { get; private set; }

        public long PalletWeighingDocID { get; private set; }

        public long MainDocID { get; private set; }

        public long PackListWeighingDocID { get; private set; }

        private ReWeightDocBase packListWeighingDoc = null;

        public ReWeightPalletPacksWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
        }

        private void Initialize()
        {
            // для теста
            //this.PackListBarCode = "1659153PRWMS";

            if (!this.CreateDocument())
            {
                allowCloseWindow = true;
                this.Terminate = true;
                this.Close();
                return;
            }

            stbItemID.ValueReferenceQuery = "[dbo].[pr_Reweight_Get_Item_List]";
            stbItemID.UserID = this.UserID;
            stbItemID.OnVerifyValue += this.OnVerifyValue;
            stbItemID.Enter += new EventHandler(stbItemID_Enter);

            tbsItemBarcode.TextChanged += new EventHandler(tbsItemBarcode_TextChanged);

            ReloadDocItems();
        }

        private bool CreateDocument()
        {
            try
            {
                pnlContent.Visible = false;

                var checkPackListResult = this.CheckPackList();
                if (!checkPackListResult)
                    return false;

                dgvDocHeader.Rows[0].Selected = false;
                pnlSearch.Visible = false;
                scDocItems.Visible = false;
                pnlContent.Visible = true;

                var assignSSCCResult = this.AssignSSCC();
                if (!assignSSCCResult)
                    return false;

                var reweightEmptyPalletResult = this.ReweightEmptyPallet();
                if (!reweightEmptyPalletResult)
                    return false;

                var createMainDocumentResult = this.CreateMainDocument();
                if (!createMainDocumentResult)
                    return false;

                var createPackListWeighingDocumentResult = this.CreatePackListWeighingDocument();
                if (!createPackListWeighingDocumentResult)
                    return false;

                var attachPackListWeighingToMainDocumentResult = this.AttachPackListWeighingToMainDocument();
                if (!attachPackListWeighingToMainDocumentResult)
                    return false;

                pnlSearch.Visible = true;
                scDocItems.Visible = true;

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private bool CheckPackList()
        {
            var packListBarCode = string.Empty;
            while (true)
            {
                try
                {
                    var dlgScanPackList = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте пак-лист,\r\nсодержащий товар для ПВК.",
                        Text = "Инициализация ПВК",
                        Image = Properties.Resources.pallet,
                        ImageSizeMode = PictureBoxSizeMode.StretchImage,
                        Barcode = packListBarCode
                    };
                    if (dlgScanPackList.ShowDialog() == DialogResult.OK)
                    {
                        packListBarCode = dlgScanPackList.Barcode;
                        using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                            adapter.FillHeader(wH.PWC_CheckRoom, this.UserID, packListBarCode);

                        if (wH.PWC_CheckRoom.Rows.Count == 0)
                            throw new Exception("Информация по пак-листу не найдена.");

                        pWCCheckRoomBindingSource.DataSource = wH.PWC_CheckRoom;
                        this.PackListBarCode = packListBarCode;
                        this.WHDocHeader = wH.PWC_CheckRoom[0];
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        private bool AssignSSCC()
        {
            var ssccBarCode = string.Empty;
            while (true)
            {
                try
                {
                    var dlgScanSSCC = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте SSCC, которая будет использована для привязки\r\nк процессу ПВК.",
                        Text = "Привязка SSCC к ПВК",
                        Image = Properties.Resources.barcode,
                        //ImageSizeMode = PictureBoxSizeMode.StretchImage
                        Barcode = ssccBarCode
                    };
                    if (dlgScanSSCC.ShowDialog() == DialogResult.OK)
                    {
                        var whDocID = this.WHDocHeader.WH_doc_id;
                        var palletWeighingDocID = (long?)null;

                        ssccBarCode = dlgScanSSCC.Barcode;
                        using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                            adapter.AssignSSCC(ssccBarCode, whDocID, this.UserID, ref palletWeighingDocID);

                        if (!palletWeighingDocID.HasValue)
                            throw new Exception("Документ взвешивания пустой паллеты не был создан.");

                        this.SSCCBarCode = ssccBarCode;
                        this.PalletWeighingDocID = palletWeighingDocID.Value;
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        private bool ReweightEmptyPallet()
        {
            var wPallet = (double?)null;
            var reweightPalletResult = this.ReweightPallet(ObtainDefferedWeightTaskProvider.TaskMode.Start, "Для запуска взвешивания пустой паллеты\r\nотсканируйте ш/к весов.", "Взвешивание пуcтой паллеты", out wPallet);

            if (reweightPalletResult)
                WHDocHeader.Palet_weight_empty_new = wPallet.Value;

            return reweightPalletResult;
        }

        private bool ReweightFullPallet()
        {
            var wPallet = (double?)null;
            var reweightPalletResult = this.ReweightPallet(ObtainDefferedWeightTaskProvider.TaskMode.Finish, "Для запуска взвешивания полной паллеты\r\nотсканируйте ш/к весов.", "Взвешивание полной паллеты", out wPallet);

            //if (reweightPalletResult)
            //    WHDocHeader.Palet_weight_full_fact = wPallet.Value;

            return reweightPalletResult;
        }

        private bool ReweightPallet(ObtainDefferedWeightTaskProvider.TaskMode mode, string label, string text, out double? wPallet)
        {
            wPallet = (double?)null;
            var weightsBarCode = string.Empty;
            while (true)
            {
                try
                {
                    var dlgScanWeights = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = label,
                        Text = text,
                        Image = Properties.Resources.pallet_weights,
                        ImageSizeMode = PictureBoxSizeMode.StretchImage,
                        DiscardCanceling = mode == ObtainDefferedWeightTaskProvider.TaskMode.Finish,
                        Barcode = weightsBarCode
                    };
                    if (dlgScanWeights.ShowDialog() == DialogResult.OK)
                    {
                        var palletWeighingDocID = this.PalletWeighingDocID;
                        var dwsDocID = (long?)null;
                        var weight = (double?)null;
 
                        // создаем задание взвешивания
                        weightsBarCode = dlgScanWeights.Barcode;
                        using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                            adapter.CreateWeighingTask(palletWeighingDocID, weightsBarCode, this.UserID, ref dwsDocID);

                        if (!dwsDocID.HasValue)
                            throw new Exception("Задание взвешивания не было создано.");

                        var wProvider = new ObtainDefferedWeightTaskProvider()
                        {
                            DWSDocID = dwsDocID.Value,
                            PalletWeighingDocID = palletWeighingDocID,
                            UserID = this.UserID,
                        };
                        wProvider.Run();

                        var undoWeighingTask = false;
                        if (wProvider.Error != null)
                            undoWeighingTask = true;
                        else
                        {
                            switch (wProvider.Mode)
                            {
                                case ObtainDefferedWeightTaskProvider.TaskMode.Start:
                                case ObtainDefferedWeightTaskProvider.TaskMode.Finish:
                                    MessageBoxManager.Yes = "&Принять";
                                    MessageBoxManager.No = "&Повторить";
                                    MessageBoxManager.Register();
                                    var msgResult = MessageBox.Show(string.Format("Получен вес: {0} кг\r\n{1}", wProvider.ResultValue, wProvider.ResultMessage), "Результат взвешивания", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                                    MessageBoxManager.Unregister();
                                    if (msgResult == DialogResult.Yes)
                                    {
                                        // сохраняем результат текущего задания взвешивания
                                        this.SavePalletWeighingTaskResult(dwsDocID.Value, palletWeighingDocID);

                                        wPallet = wProvider.ResultValue;
                                        return true;
                                    }
                                    else
                                        undoWeighingTask = true;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (undoWeighingTask)
                        {
                            // отменям текущее задание взвешивания
                            using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                                adapter.UndoWeighingTask(dwsDocID, palletWeighingDocID, this.UserID);

                            if (wProvider.Error != null)
                                throw new Exception(wProvider.Error.Message);
                        }
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        private void SavePalletWeighingTaskResult(long dwsDocID, long palletWeighingDocID)
        {
            // сохраняем результат текущего задания взвешивания
            using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                adapter.SaveWeighingTaskResult(dwsDocID, palletWeighingDocID, this.UserID);

            var mode = ObtainDefferedWeightTaskProvider.TaskMode.None;
            var _isChecked = false;
            var message = (string)null;
            var value = (double?)null;
            ObtainDefferedWeightTaskProvider.CheckWeight(dwsDocID, palletWeighingDocID, this.UserID, out _isChecked, out mode, out message, out value);
            if (_isChecked)
            {
                MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool CreateMainDocument()
        {
            try
            {
                // создание главного документа
                var warehouseID = this.WHDocHeader.Warehouse_id;
                var palletWeighingDocID = this.PalletWeighingDocID;
                var packListBarCode = this.PackListBarCode;
                var mainDocID = (long?)null;
                using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                    adapter.CreateMainTask(this.UserID, "CR", warehouseID, palletWeighingDocID, packListBarCode, ref mainDocID);

                if (!mainDocID.HasValue)
                    throw new Exception("Документ ПВК не был создан.");

                this.MainDocID = mainDocID.Value;
                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private bool CreatePackListWeighingDocument()
        {
            try
            {
                // создание документа взвешивания ЖЭ
                var packListBarCode = this.PackListBarCode;
                var plwDocID = (long?)null;

                packListWeighingDoc = new ReWeightDocBy7PWC();
                packListWeighingDoc.CreateDoc(packListBarCode, this.UserID, "RW", ref plwDocID);

                if (!plwDocID.HasValue)
                    throw new Exception("Документ взвешивания ЖЭ не был создан.");

                this.PackListWeighingDocID = plwDocID.Value;
                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private bool AttachPackListWeighingToMainDocument()
        {
            try
            {
                var mainDocID = this.MainDocID;
                var plwDocID = this.PackListWeighingDocID;
                using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                    adapter.AttachItemsWeighingTask(mainDocID, this.UserID, plwDocID);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        void stbItemID_Enter(object sender, EventArgs e)
        {
            stbItemID.ApplyAdditionalParameter(tbsItemBarcode.Name, tbsItemBarcode.Text);
        }

        private void OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;

            if (e.Success)
                control.Value = e.Value;

            if (control == stbItemID)
            {
                if (e.Success)
                {
                    //lblItemIDValue.Text = string.IsNullOrEmpty(e.Value) ? "-" : e.Value;
                    lblItemNameValue.Text = string.IsNullOrEmpty(e.Value) ? string.Empty : (string.IsNullOrEmpty(e.Description) ? "-" : e.Description);
                    lblItemNameValue.ForeColor = SystemColors.ControlText;

                    if (!string.IsNullOrEmpty(e.Value))
                    {
                        var itemID = -1;

                        try
                        {
                            // получение кода товара
                            itemID = Convert.ToInt32(e.Value);

                            // очистка предыдущих результатов
                            // (настроена по умолчанию в CheckItem)

                            // проверка наличия товара
                            packListWeighingDoc.CheckItem(itemID);

                            // инициализация работы с товаром
                            var gridRow = this.FindDocItemGridRow(itemID);
                            this.SelectItem(gridRow);

                            // взвешивание ЖЭ
                            this.ObtainBoxWeight(gridRow);

                            //// сохранение изменений
                            //docItem.UpdateItem();
                        }
                        catch (Exception ex)
                        {
                            this.ShowError(ex);
                        }
                        finally
                        {
                            stbItemID.Value = string.Empty;
                            tbsItemBarcode.Text = string.Empty;
                            tbsItemBarcode.Focus();
                        }
                    }
                }
                else
                {
                    lblItemNameValue.Text = "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                    lblItemNameValue.ForeColor = Color.Red;

                    this.ShowError("Товар не найден в справочнике.");

                    stbItemID.Value = string.Empty;
                    tbsItemBarcode.Focus();
                    tbsItemBarcode.SelectAll();
                }
            }
        }

        private void ObtainBoxWeight(DataGridViewRow gridRow)
        {
            var measurementItem = this.GetSelectedMeasurementItem(gridRow);

            var dlgObtainBoxWeightForm = new ObtainBoxWeightForm(measurementItem) { WeightDoc = packListWeighingDoc };
            dlgObtainBoxWeightForm.OnStageProcessingCompleted += (s, e) => 
            {
                this.ReloadDocItemsWeighingLog();
            };
            if (dlgObtainBoxWeightForm.ShowDialog() == DialogResult.OK)
            {
                // перечитка списка товара
                this.ReloadDocItems();

                // навигация на только что обработанный товар
                var gridRow_ = this.FindDocItemGridRow(measurementItem.ItemID.Value);
                this.SelectItem(gridRow_);

                // завершающий этап
                this.CheckCloseDoc(true);
            }
            else
            {
                this.ReloadDocItemsWeighingLog();
            }
        }

        private void CloseMainDocument()
        {
            try
            {
                var mainDocID = this.MainDocID;
                using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                    adapter.UpdateMainTaskStatus(mainDocID, this.UserID, (string)null, (int?)null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Поиск строки с товаром в таблице
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        private DataGridViewRow FindDocItemGridRow(int itemID)
        {
            DataGridViewRow findGridRow = null;
            foreach (DataGridViewRow dgvr in dgvDocItems.Rows)
            {
                var rowItemID = Convert.ToInt32(((dgvr.DataBoundItem as DataRowView).Row as Data.PickControl.ReWeighingDocItemsRow).Itm_Id);
                if (rowItemID == itemID)
                {
                    findGridRow = dgvr;
                    break;
                }
            }

            return findGridRow;

        }

        /// <summary>
        /// Позиционирование выбранной строки
        /// </summary>
        /// <param name="gridRow"></param>
        private void NavigateToCurrentGridRow(DataGridViewRow gridRow)
        {
            gridRow.Selected = true;
            dgvDocItems.FirstDisplayedScrollingRowIndex = gridRow.Index;
        }

        /// <summary>
        /// Выбор позиции в документе
        /// </summary>
        /// <param name="gridRow"></param>
        private void SelectItem(DataGridViewRow gridRow)
        {
            // позиционирование
            this.NavigateToCurrentGridRow(gridRow);
        }

        private MeasurementItem GetSelectedMeasurementItem(DataGridViewRow gridRow)
        {
            var drDocItem = (gridRow.DataBoundItem as DataRowView).Row as Data.PickControl.ReWeighingDocItemsRow;
            var itemID = Convert.ToInt32(drDocItem.Itm_Id);
            var itemName = drDocItem.Itm_Name;
            var manufacturer = drDocItem.Manuf;
            var supplier = drDocItem.Vendor;

            // получение ОБВХ товара
            var itemMeasurement = new MeasurementItem();
            itemMeasurement.ItemID = itemID;
            itemMeasurement.ItemName = itemName;
            itemMeasurement.ManufacturerName = manufacturer;
            itemMeasurement.SupplierName = supplier;
            itemMeasurement.LoadData();

            return itemMeasurement;
        }

        void tbsItemBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbsItemBarcode.Text))
            {
                stbItemID.ApplyAdditionalParameter(tbsItemBarcode.Name, tbsItemBarcode.Text);
                stbItemID.VerifyValue(true, AutoSelectItemSideMode.None);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadDocItems();
        }

        private void ReloadDocItems()
        {
            try
            {
                reWeighingDocItemsBindingSource.DataSource = null;
                pickControl.ReWeighingDocItems.Clear();
                pickControl.ReWeighingDocItems.Merge(packListWeighingDoc.GetItems());
                reWeighingDocItemsBindingSource.DataSource = pickControl.ReWeighingDocItems;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            this.CheckCloseDoc(false);
        }

        private void CheckCloseDoc(bool ignoreCheck)
        {
            try
            {
                // возможность закрытия документа
                var canCloseDoc = packListWeighingDoc.CanCloseDoc();

                // документ можно закрыть
                if (canCloseDoc || (!ignoreCheck && MessageBox.Show("Не по всем товарам проводилась актуализация веса.\r\nВсе равно закрыть?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                {
                    // закрытие документа
                    if (canCloseDoc)
                        packListWeighingDoc.CloseDoc();
                    // аннулирование документа
                    else
                        packListWeighingDoc.CancelDoc();

                    // взвешивание полной паллеты
                    var reweightFullPalletResult = this.ReweightFullPallet();
                    if (!reweightFullPalletResult)
                        return;

                    // закрытие главного документа 
                    this.CloseMainDocument();

                    // нормальное завершение работы с документом
                    this.CloseDoc();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void CloseDoc()
        {
            try
            {
                MessageBox.Show("Документ был успешно закрыт.", "Закрытие документа", MessageBoxButtons.OK, MessageBoxIcon.Information);

                allowCloseWindow = true;
                this.Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private bool allowCloseWindow = false;
        private void ReWeightPalletPacksWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения\r\nпроцедуры контроля. Пожалуйста, продолжайте работу.\r\nДля закрытия документа контроля воспользуйтесь командой \"Закрыть документ\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }

            if (Control.ModifierKeys == Keys.Control)
                this.Terminate = true;
        }

        private void dgvDocHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

        private void dgvDocItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var boundRow = (dgvDocItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.ReWeighingDocItemsRow;
            var flag = boundRow.IsFlag_ColorNull() ? 0 : boundRow.Flag_Color;
            var color = flag == 1 ? Color.LightGray : SystemColors.Window;

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }

        private void dgvDocItems_SelectionChanged(object sender, EventArgs e)
        {
            this.ReloadDocItemsWeighingLog();
        }

        private void ReloadDocItemsWeighingLog()
        {
            try
            {
                var itemID = Convert.ToInt32(this.dgvDocItems.SelectedRows.Count == 0 ? -1 : ((this.dgvDocItems.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.ReWeighingDocItemsRow).Itm_Id);
                reWeighingDocItemStepsBindingSource.DataSource = null;
                pickControl.ReWeighingDocItemSteps.Clear();
                pickControl.ReWeighingDocItemSteps.Merge(packListWeighingDoc.GetItemSteps(itemID));
                reWeighingDocItemStepsBindingSource.DataSource = pickControl.ReWeighingDocItemSteps;

                if (dgvDocItemsWeighingLog.Rows.Count > 0)
                    dgvDocItemsWeighingLog.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Задание получения результата отложенного взвешивания с периодической проверкой
    /// </summary>
    public class ObtainDefferedWeightTaskProvider
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Таймер опроса завершения задания
        /// </summary>
        private readonly System.Threading.Timer _checkTimer = null;

        /// <summary>
        /// Признак завершения проверки опроса завершения задания
        /// </summary>
        private bool isChecked = false;

        /// <summary>
        /// Время ожидания до следующей проверки опроса завершения задания
        /// </summary>
        public int CheckTimeout { get; private set; }

        /// <summary>
        /// Событие допуска к прекращению проверки опроса завершения задания
        /// </summary>
        private readonly ManualResetEvent _sync = null;

        /// <summary>
        /// Таймер прерывания процесса
        /// </summary>
        private readonly System.Threading.Timer _abortTimer = null;

        /// <summary>
        /// Признак прерывания процесса
        /// </summary>
        private bool isAborted = false;

        /// <summary>
        /// Время ожидания до прерывания процесса
        /// </summary>
        public int AbortTimeout { get; private set; }

        public TaskMode Mode { get; private set; }
        public string ResultMessage { get; private set; }
        public double? ResultValue { get; private set; }
        public Exception Error { get; private set; }
       
        public long DWSDocID { get; set; }
        public long PalletWeighingDocID { get; set; }
        public int UserID { get; set; }

        public ObtainDefferedWeightTaskProvider()
        {
            _checkTimer = new System.Threading.Timer(new TimerCallback(Check), this, Timeout.Infinite, Timeout.Infinite);
            this.CheckTimeout = (int)TimeSpan.FromSeconds(2).TotalMilliseconds;

            _abortTimer = new System.Threading.Timer(new TimerCallback(Abort), this, Timeout.Infinite, Timeout.Infinite);
            this.AbortTimeout = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;

            _sync = new ManualResetEvent(false);
        }

        private void Abort(object target)
        {
            try
            {
                isAborted = true;
                _abortTimer.Change(Timeout.Infinite, Timeout.Infinite);

                isChecked = false;
                _checkTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _sync.Set();
            }
        }

        private void Check(object target)
        {
            try
            {
                _checkTimer.Change(Timeout.Infinite, Timeout.Infinite);

                var dwsDocID = this.DWSDocID;
                var palletWeighingDocID = this.PalletWeighingDocID;
                var userID = this.UserID;

                //using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                //    adapter.GetWeighingTaskResult(dwsDocID, palletWeighingDocID, userID);

                var mode = TaskMode.None;
                var _isChecked = false;
                var message = (string)null;
                var value = (double?)null;
                ObtainDefferedWeightTaskProvider.CheckWeight(dwsDocID, palletWeighingDocID, userID, out _isChecked, out mode, out message, out value);
                if (_isChecked)
                {
                    this.Mode = mode;
                    this.ResultMessage = message;
                    this.ResultValue = value;
                    isChecked = _isChecked;
                }
            }
            catch (Exception ex)
            {
                this.Error = ex;
                Abort(this);

                //if (ex.Message.StartsWith("#PWR"))
                //{
                //    var regex = new System.Text.RegularExpressions.Regex(@"^#PWR(?<tm>[SF]{1})#(?<w>[\d.,.]+)#(?<m>.+)#.*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                //    if (regex.IsMatch(ex.Message))
                //    {
                //        var match = regex.Match(ex.Message);
                //        this.Mode = match.Groups["tm"].Value.Equals("S", StringComparison.OrdinalIgnoreCase) ? TaskMode.Start : TaskMode.Finish;
                //        this.ResultMessage = match.Groups["m"].Value;
                //        this.ResultValue = Convert.ToDouble(match.Groups["w"].Value
                //            .Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                //            .Replace(",", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                //        isChecked = true;
                //    }
                //}
                //else
                //{
                //    this.Error = ex;
                //    Abort(this);
                //}
            }
            finally
            {
                if (isChecked || isAborted)
                {
                    _abortTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    _sync.Set();
                }
                else
                    _checkTimer.Change(CheckTimeout, Timeout.Infinite);
            }
        }

        public static void CheckWeight(long dwsDocID, long palletWeighingDocID, int userID, out bool isChecked, out TaskMode mode, out string message, out double? value)
        {
            mode = TaskMode.None;
            isChecked = false;
            message = (string)null;
            value = (double?)null;

            try
            {
                using (var adapter = new Data.WHTableAdapters.PWC_CheckRoomTableAdapter())
                    adapter.GetWeighingTaskResult(dwsDocID, palletWeighingDocID, userID);
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("#PWR"))
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^#PWR(?<tm>[SF]{1})#(?<w>[\d.,.]+)#(?<m>.+)#.*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                    {
                        var match = regex.Match(ex.Message);
                        mode = match.Groups["tm"].Value.Equals("S", StringComparison.OrdinalIgnoreCase) ? TaskMode.Start : TaskMode.Finish;
                        message = match.Groups["m"].Value;
                        value = Convert.ToDouble(match.Groups["w"].Value
                            .Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                            .Replace(",", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        isChecked = true;
                    }
                }
                else
                {
                    throw ex;
                }
            }
        }

        private void Initialize()
        {
            isChecked = false;
            isAborted = false;

            ResultMessage = null;
            ResultValue = (double?)null;
            Error = null;
        }

        public void Run()
        {
            try
            {
                Initialize();

                var loadWoker = new BackgroundWorker();
                loadWoker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        _sync.Reset();

                        _abortTimer.Change(AbortTimeout, Timeout.Infinite);
                        _checkTimer.Change(CheckTimeout, Timeout.Infinite);

                        _sync.WaitOne();

                        if (isAborted && this.Error == null)
                            throw new Exception("Операция не выполнилась за отведенное ей время.");
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWoker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        this.Error = e.Result as Exception;
                   
                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение данных с сервиса взвешивания..";
                loadWoker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public enum TaskMode
        { 
            /// <summary>
            /// Не определен
            /// </summary>
            None,

            /// <summary>
            /// Старт
            /// </summary>
            Start,

            /// <summary>
            /// Финиш
            /// </summary>
            Finish
        }
    }

    public class ReWeightDocBy7PWC : ReWeightDocBase
    {
        public override int ItemsQuantity { get { return 1; } }

        public override string Message
        {
            get
            {
                if (Complete)
                    return string.Format("Взвешивание завершено. Отсканируйте новый товар.");
                else if (StageNumber == 1)
                    return string.Format("Оставьте на весах {0} ящ. с товаром. Шаг {1} из {2}.", ItemsQuantity, StageNumber, StagesCount);
                else if (StageNumber > 1)
                    return string.Format("Вес получен. Оставьте на весах {0} ящ. с товаром. Шаг {1} из {2}.", ItemsQuantity, StageNumber, StagesCount);

                return string.Empty;
            }
        }

        public override void CancelDoc()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_PWC_CancelDoc(this.DocID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void CreateDoc(string barcode, int employeeID, string docType, ref long? docID)
        {
            using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                adapter.RW7_PWC_CreateDoc(barcode, employeeID, docType, ref docID);

            this.DocID = docID ?? -1;
        }

        public override void CreateDocForItem(long itemID, int employeeID, string docType, ref long? docID)
        {
            using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                adapter.RW7_BX_CreateDocForItem(itemID, employeeID, docType, ref docID);

            this.DocID = docID ?? -1;
        }

        public override WMSOffice.Data.PickControl.ReWeighingDocItemsDataTable GetItems()
        {
            using (var adapter = new Data.PickControlTableAdapters.ReWeighingDocItemsTableAdapter())
                return adapter.GetData7PWC(this.DocID);
        }

        public override WMSOffice.Data.PickControl.ReWeighingDocItemStepsDataTable GetItemSteps(int itemID)
        {
            using (var adapter = new Data.PickControlTableAdapters.ReWeighingDocItemStepsTableAdapter())
                return adapter.GetData7PWC(this.DocID, this.LineID, itemID);
        }

        public override void CheckItem(int itemID)
        {
            this.CheckItem(itemID, false);
        }

        private void CheckItem(int itemID, bool ignoreErrors)
        {
            try
            {
                var lineID = (int?)null;
                var stageCount = (int?)null;

                var ignoreErrorsFlag = Convert.ToInt32(ignoreErrors);

                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_PWC_CheckItem(this.DocID, itemID, ignoreErrorsFlag, ref lineID, ref stageCount);

                ClearItem();

                this.LineID = lineID ?? -1;
                this.StagesCount = stageCount ?? 1;

                this.StageNumber = 1;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                var throwException = false;

                if (errorMessage.Contains("#"))
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Action>\w+)#(?<Message>.+)#$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(errorMessage))
                    {
                        var match = regex.Match(ex.Message);
                        var action = match.Groups["Action"].Value;
                        var message = match.Groups["Message"].Value;

                        if (action.Equals("CAN_REWEIGHT"))
                        {
                            if (MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                this.CheckItem(itemID, true);
                            else
                            {
                                errorMessage = message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
                                throwException = true;
                            }
                        }
                    }
                    else
                        throwException = true;
                }
                else
                    throwException = true;

                if (throwException)
                    throw new Exception(errorMessage);
            }
        }

        public override void CheckItemBarcode(string barcode)
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_PWC_CheckItemBarcode(this.DocID, this.LineID, barcode);

                this.LineBarcode = barcode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SaveResult(double weight)
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_PWC_SaveItemWeight(this.DocID, this.LineID, this.StageNumber, weight, this.LineBarcode);

                this.PreviousWeight = this.Weight;
                this.Weight = weight;

                RaiseSubmitWeight();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void ClearResult()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_PWC_ClearItemWeight(this.DocID, this.LineID);

                RaiseUndoWeight();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool CanCloseDoc()
        {
            try
            {
                var canCloseFlag = (int?)null;

                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_PWC_CanCloseDoc(this.DocID, this.LineID, this.StageNumber, ref canCloseFlag);

                return Convert.ToBoolean(canCloseFlag ?? 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void CountDocDiff()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_PWC_CountDocDiff(this.DocID, this.LineID, this.InstructionFlag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void CloseDoc()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_PWC_CloseDoc(this.DocID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void GetFinalWeight(out double? finalWeight, out string finalWeightFlag)
        {
            finalWeight = (double?)null;
            finalWeightFlag = (string)null;

            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_BX_GetFinalWeight(this.DocID, this.LineID, ref finalWeight, ref finalWeightFlag);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void GetUnitX3Weight(out double? unitX3Weight)
        {
            unitX3Weight = (double?)null;

            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_BX_GetUnitX3Weight(this.DocID, this.LineID, ref unitX3Weight);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void GetInsrtuctionFlag(out int? instructionFlag)
        {
            instructionFlag = (int?)null;

            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_BX_GetInstructionFlag(this.DocID, this.LineID, ref instructionFlag);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
