using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;
using WMSOffice.Reports;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;

using WMSOffice.Data.ReceiveTableAdapters;
using WMSOffice.Dialogs.Quality;
using System.Text.RegularExpressions;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PrintLotnBarcodeForm : Form
    {
        public event EventHandler<AssignSSCCArgs> OnAssignSSCC;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        public string Location { get; set; }

        public LotnReceiptMode ReceiptMode { get; set; }

        public long? DocID { get; set; }

        /// <summary>
        /// Язык ввода установленный заранее (старое значение)
        /// </summary>
        private InputLanguage OldInputLanguage = InputLanguage.CurrentInputLanguage;

        /// <summary>
        /// Статический экземпляр для запоминания компонент фильтрации
        /// </summary>
        public static readonly FilterStorage FilterStorage = new FilterStorage();

        public PrintLotnBarcodeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверка доступа к информации о ящиках
        /// </summary>
        /// <returns></returns>
        private bool CheckAccessBoxInfo()
        {
            try
            {
                var accessFlag = (int?)null;
                lotnBoxesInfoTableAdapter.CheckBoxInfoAccess(this.UserID, ref accessFlag);
                return accessFlag.HasValue && accessFlag.Value.Equals(1);
            }
            catch 
            {
                return false;
            }
        }

        public int UserID { get; set; }

        private void PrintLotnBarcodeForm_Load(object sender, EventArgs e)
        {
            this.xdgvResult.AllowSummary = false;
            this.xdgvResult.AllowRangeColumns = true;
            this.xdgvResult.UseMultiSelectMode = true;

            var access = this.CheckAccessBoxInfo();
            this.xdgvResult.Init(new PrintLotnBarcodeView(access), true);
            this.xdgvResult.LoadExtraDataGridViewSettings(this.Name);

            PreparePrintersList();
            this.xdgvResult.UserID = this.UserID;

            #region АНАЛИЗ ДОСТУПА К ОПЕРАЦИЯМ С Ж/Э

            bool? canAccessToExtraOptions = null;

            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.CreatedYLTableAdapter())
                    adapter.CanDeleteCreatedYL(this.UserID, ref canAccessToExtraOptions);

                canAccessToExtraOptions = (canAccessToExtraOptions ?? false) && this.Location.Equals("DOCK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                canAccessToExtraOptions = false;
            }

            tsShowPrintedYellowLabels.Visible = (bool)canAccessToExtraOptions;
            sbShowPrintedYellowLabels.Visible = (bool)canAccessToExtraOptions;

            #endregion

            // Адаптация отображения секции итогов
            //if (this.ReceiptMode != LotnReceiptMode.Preview)
                scMain.Panel2Collapsed = true;

            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            switch (this.ReceiptMode)
            {
                case LotnReceiptMode.AssignSSCC:
                    this.Text = "Резервирование ш/к \nна заводской ящик";
                    sbPrintBoxBarCode.Text = "Резервирование ш/к \nна заводской ящик";
                    break;
                case LotnReceiptMode.Preview:
                    this.Text = "Строки приходования";
                    toolStripSearch.Visible = false;
                    break;
                default:
                    break;
            }

            xdgvResult.OnDataError += new DataGridViewDataErrorEventHandler(xdgvResult_OnDataError);
            xdgvResult.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvResult_OnRowDoubleClick);
            xdgvResult.OnRowSelectionChanged += new EventHandler(xdgvResult_OnRowSelectionChanged);
            xdgvResult.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvResult_OnFormattingCell);
            xdgvResult.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvResult_OnDataBindingComplete);
            xdgvResult.OnFilterChanged += new EventHandler(xdgvResult_OnFilterChanged);

            sbIsProblemItemDetected.Enabled = false;
            sbPrintBoxBarCode.Enabled = false;
            sbPrint.Enabled = false;

            sbShowPrintedYellowLabels.Enabled = false;

            this.xdgvResult.ApplyFilter(PrintLotnBarcodeForm.FilterStorage);
            this.RefreshData();
            this.xdgvResult.ActivateFilter();
        }

        void xdgvResult_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvResult.RecalculateSummary();
        }

        /// <summary>
        /// Сформировать список принтеров, выбрать принтер по умолчанию
        /// </summary>
        private void PreparePrintersList()
        {
            try
            {
                foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cmbPrinters.Items.Add(printerName);

                System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                cmbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                this.RefreshData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GoPrint()
        {
            if (ReceiptMode == LotnReceiptMode.Preview)
                return;

            try
            {
                var isIncomeControlPassed = Convert.ToBoolean(xdgvResult.SelectedItem["IsIncomeControlPassed"]);
                var isMeasurementInputCompleted = xdgvResult.SelectedItem["OBVX_Completed"].ToString().Trim() == "1";

                try
                {
                    if (!(isIncomeControlPassed = isIncomeControlPassed || this.ExecuteIncomeControl(xdgvResult.SelectedItem)))
                        throw new Exception("Входной контроль партии не был пройден.\r\nПечать ш/к на заводской ящик невозможна.");

                    if (!(isMeasurementInputCompleted = isMeasurementInputCompleted || this.ExecuteMeasurementInput(xdgvResult.SelectedItem)))
                        throw new Exception("Обмер ОБВХ не выполнен.\r\nПечать ш/к на заводской ящик невозможна.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                bool allowPrint = isIncomeControlPassed && isMeasurementInputCompleted;

                if (allowPrint)
                {
                    Data.Receive.Lotn_For_PrintRow rowSelected = new Data.Receive.Lotn_For_PrintDataTable().NewLotn_For_PrintRow();
                    rowSelected.Item_ID = Convert.ToInt32(xdgvResult.SelectedItem["Item_ID"]);
                    rowSelected.Item = xdgvResult.SelectedItem["Item"].ToString();
                    rowSelected.Lot_Number = xdgvResult.SelectedItem["Lot_Number"].ToString();
                    rowSelected.Vendor_Lot = xdgvResult.SelectedItem["Vendor_Lot"].ToString();
                    rowSelected.Manufacturer = xdgvResult.SelectedItem["Manufacturer"].ToString();
                    rowSelected.ITinBX = Convert.ToDouble(xdgvResult.SelectedItem["ITinBx"]);
                    rowSelected.Location = xdgvResult.SelectedItem["Location"].ToString();
                    rowSelected.DOCK_Qty_IT = Convert.ToInt32(xdgvResult.SelectedItem["DOCK_Qty_IT"]);

                    this.GoPrint(rowSelected);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выполнение обмера ОБВХ
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool ExecuteMeasurementInput(DataRow row)
        {
            try
            {
                MessageBox.Show("Необходимо выполнить обмер ОБВХ.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                #region ВЫПОЛНЕНИЕ ОБМЕРА ОБВХ

                var form = new MeasurementForm();
                form.UserID = UserID;
                form.ItemID = Convert.ToInt32(row["Item_ID"]);
                form.ItemName = row["Item"].ToString();
                form.BatchNumber = row["Lot_Number"].ToString();

                if (form.ShowDialog() != DialogResult.OK)
                    throw new Exception("Обмер ОБВХ был Вами отменен.");

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Прохождение входного контроля партии
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool ExecuteIncomeControl(DataRow row)
        {
            try
            {
                MessageBox.Show("Необходимо пройти входной контроль партии.\r\nПригласите ответственного сотрудника.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                #region ПОЛУЧЕНИЕ АНКЕТЫ ВХОДНОГО КОНТРОЛЯ ПАРТИИ

                var itemID = Convert.ToInt32(row["Item_ID"]);
                var lotNumber = row["Lot_Number"].ToString();
                var onlyActive = true;
                var statuses = "1,2,3,4,5";

                Data.Quality.AT_Doc_VersionsDataTable worksheets = null;

                var bw = new BackgroundWorker();
                bw.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        using (var adapter = new Data.QualityTableAdapters.AT_Doc_VersionsTableAdapter())
                        {
                            adapter.SetTimeout(300);
                            e.Result = adapter.GetData(this.UserID, (long?)null, statuses, onlyActive, itemID, lotNumber, (long?)null, (long?)null, (string)null, (DateTime?)null, (DateTime?)null, (long?)null, (DateTime?)null, (DateTime?)null);
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        worksheets = e.Result as Data.Quality.AT_Doc_VersionsDataTable;

                    waitProcessForm.CloseForce();
                };

                waitProcessForm.ActionText = "Выполняется поиск анкеты входного контроля партии..";
                bw.RunWorkerAsync();
                waitProcessForm.ShowDialog();

                if (worksheets == null || worksheets.Rows.Count == 0)
                    throw new Exception("Анкета входного контроля партии не найдена.");

                var worksheet = worksheets[0]; // получаем анкету входного контроля партии

                #endregion

                #region СМЕНА ПОЛЬЗОВАТЕЛЯ НА ДРУГОГО ОТВЕТСТВЕННОГО ЗА ПРОВЕДЕНИЕ ВХОДНОГО КОНТРОЛЯ (ПРОВИЗОР)

                var allowIncomeControlPassage = false;

                var changeUserForm = new ChangeUserForm() { CreateTempSession = true };
                if (changeUserForm.ShowDialog() != DialogResult.OK)
                    throw new Exception("Невозможно провести входной контроль партии\r\nбез участия ответственного сотрудника.");

                var resourcesBySessionDataTable = new Data.AccessTableAdapters.ResourcesBySessionTableAdapter().GetData(changeUserForm.UserID);
                foreach (Data.Access.ResourcesBySessionRow item in resourcesBySessionDataTable)
                {
                    if ((item.Module_ID == "QUALITY") && (item.Doc_Type_ID == "AT"))
                    {
                        allowIncomeControlPassage = true;
                        break;
                    }
                }

                if (!allowIncomeControlPassage)
                    throw new Exception("Ваших полномочий недостаточно\r\nдля проведения входного контроля партии.");

                #endregion

                #region ПРОВЕДЕНИЕ ВХОДНОГО КОНТРОЛЯ

                var sIncomeControlOrderID = worksheet.order_id.ToString();
                var incomeControlUserID = changeUserForm.UserID;
                var worksheetEditForm = new EditInputControlLotnWorksheetForm(incomeControlUserID, worksheet, sIncomeControlOrderID, true);
                if (worksheetEditForm.ShowDialog() != DialogResult.OK)
                    throw new Exception("Входной контроль партии был Вами отменен.");

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void GoPrint(Data.Receive.Lotn_For_PrintRow row)
        {
                // upd 18.02.2011
                // проверим, можно ли печатать желтую этикетку на ящик
                try
                {
                    //Data.Receive.Lotn_For_PrintRow row = ((Data.Receive.Lotn_For_PrintRow)((DataRowView)gvLotn.SelectedRows[0].DataBoundItem).Row);

                    // throw new Exception("[NEWDOC]83025");
                    
                    // выполняем проверку
                    lotn_For_PrintTableAdapter.CheckLotNumberSample((int)row.Item_ID, row.Lot_Number, UserID);

                    // показываем окно печати этикеток, как прежде
                    PrintBoxLabelForm form = new PrintBoxLabelForm();
                    form.UserID = UserID;
                    form.DocID = DocID;
                    form.Lotn = row.Lot_Number;
                    form.ItemID = (int)row.Item_ID;
                    form.ItemName = row.Item;
                    form.Seria = row.Vendor_Lot;
                    form.Manufacturer = row.IsManufacturerNull() ? string.Empty : row.Manufacturer;
                    //form.ItemsInBox = (int)row.ITinBX;
                    form.SupplyQuantity = (int)row.DOCK_Qty_IT;
                    form.LocationID = row.IsLocationNull() ? string.Empty : row.Location;
                    form.SourceItem = row;
                    form.ReceiptMode = this.ReceiptMode;
                    //form.ReceiptMode = this.IsSampleSelectMode ? LotnReceiptMode.PrintYL : this.ReceiptMode;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (ReceiptMode == LotnReceiptMode.AssignSSCC)
                        {
                            if (this.OnAssignSSCC != null)
                                this.OnAssignSSCC(this, new AssignSSCCArgs()
                                {
                                    ItemID = form.ItemID,
                                    ItemName = form.ItemName,
                                    VendorLot = form.Seria,
                                    BatchID = form.Lotn,
                                    ManufacturerName = form.Manufacturer,
                                    ItemsInBoxCount = form.ItemsInBoxCount,
                                    UnitOfMeasure = "BX",
                                    LabelsCount = form.LabelsCount
                                });
                        }

                        // печатаем новые штрих коды (задание формируем в самой форме)
                        // и закрываем текущее окно
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    // нельзя печатать этикетку! по причине...
                    if (ex.Message.Contains(NeedSampleErrMsg))  // Нужно отобрать образец по этому товару
                    {
                        if (MessageBox.Show("По этому товару не отобраны образцы! Отобрать образец по этому товару?", "Отбор образцов",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            long? samplingDocID = null;
                            double? samplingQuantity = null;

                            #region ПОЛУЧЕНИЕ КОЛИЧЕСТВ ОБРАЗЦОВ ДЛЯ ОТБОРА

                            try
                            {
                                lotn_For_PrintTableAdapter.AdaptLotNumberSampleQuantity(this.UserID, (int)row.Item_ID, row.Lot_Number, ref samplingDocID, ref samplingQuantity);
                                samplingQuantity = samplingQuantity ?? 1;
                            }
                            catch { }

                            #endregion

                            //int? samplingDocID = ParseDocID(ex);
                            if (samplingDocID.HasValue)
                            {
                                this.IsSampleSelectMode = true;

                                Sample(row, samplingDocID.Value, samplingQuantity.Value);   // Отбираем образец
                                GoPrint(row);

                                this.IsSampleSelectMode = false;
                            }
                            else
                            {
                                MessageBox.Show("Не удалось определить номер документа отбора образцов!", "Отбор образцов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (ex.Message.Contains("[OPENDOC]"))
                    {
                        // документ отбора образцов уже находится в работе
                        MessageBox.Show(String.Format("Сейчас сотрудниками:\n- {0} \nведется отбор образцов. \n\nДо завершения процедуры отбора образцов товар принимать нельзя. Пожалуйста, подождите, или выполните приемку товара из другого заказа на закупку!", ex.Message.Replace("[OPENDOC]", "")),
                            "Документ в работе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (ex.Message.Contains("[OPENWODOC]"))
                    {
                        // образцы не перемещены в отдел качества
                        MessageBox.Show(String.Format("Сейчас сотрудниками:\n- {0} \nпроизводится перемещение образцов. \n\nДо завершения процедуры перемещения образцов товар принимать нельзя. Пожалуйста, подождите, или выполните приемку товара из другого заказа на закупку!", ex.Message.Replace("[OPENWODOC]", "")),
                            "Документ в работе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // другая ошибка
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        /// <summary>
        /// Режим отбора образцов
        /// </summary>
        private bool IsSampleSelectMode = false;

        /// <summary>
        /// Сообщение об ошибке печати этикетки, если нужно отобрать образцы 
        /// (строка используется во многих местах и лучше сделать ее константой)
        /// </summary>
        private const string NeedSampleErrMsg = "[NEEDSAMPLE]";

        /// <summary>
        /// Получение идентификатора документа отбора образцов из ошибки, полученной при попытке распечатать этикетку на заводской ящик
        /// </summary>
        /// <param name="pExc">Ошибка, полученная при попытке распечатать этикетку на заводской ящик</param>
        /// <returns>Идентификатор документа отбора образцов либо NULL, если не удалось получить документ</returns>
        [Obsolete]
        private static int? ParseDocID(Exception pExc)
        {
            string docIDStr = pExc.Message.Remove(0, NeedSampleErrMsg.Length);
            int docID;
            if (!Int32.TryParse(docIDStr, out docID))
            {
                MessageBox.Show("Не удалось определить номер документа отбора образцов!", "Отбор образцов",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return docID;
        }

        /// <summary>
        /// Отбор образца
        /// </summary>
        /// <param name="pRow">Строка товара, по которой нужно отобрать образцы</param>
        /// <param name="pSampleDocId">Идентификатор документа на отбор образцов</param>
        /// <param name="pSampleDocId">Количество образцов для отбора</param>
        private void Sample(Data.Receive.Lotn_For_PrintRow pRow, long pSampleDocId, double pSampleQuantity)
        {
            var samplingWindow = new SamplingForm((int)pRow.Item_ID, pRow.Item, pSampleDocId, pSampleQuantity, UserID);
            samplingWindow.ReceiptMode = this.ReceiptMode;
            if (samplingWindow.ShowDialog(this) == DialogResult.OK)
                try
                {
                    var useCurrentLotNumber = this.ReceiptMode == LotnReceiptMode.AssignSSCC ? 1 : 0;
                    using (var adapter = new DocLinesTableAdapter())
                        adapter.InsertDetailRow(pSampleDocId, samplingWindow.SelectedItemID, pRow.Lot_Number, pRow.Location, "IT", pSampleQuantity,
                            samplingWindow.ItemBarcode, samplingWindow.BasketBarcode, (int)pRow.Item_ID, UserID, useCurrentLotNumber, samplingWindow.SampleBarcode);
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Ошибка при отборе образца!", exc);
                }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        #region ФОНОВОЕ ОБНОВЛЕНИЕ СПИСКА ЗАКАЗОВ
        private void RefreshData()
        {
            this.xdgvResult.Focus();

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);

            var parameters = new PrintLotnBarcodeSearchParameters();
            parameters.UserID = this.UserID;
            parameters.Mode = this.Location;

            this.waitProcessForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync(parameters);
            this.waitProcessForm.ShowDialog();

            // Обновление итогов по АВС-категориям товара, текущей ящичной норме, которые числятся на остатке
            if (this.ReceiptMode == LotnReceiptMode.Preview)
                RefreshTotals();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.xdgvResult.DataView.FillData(e.Argument as PrintLotnBarcodeSearchParameters);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                this.xdgvResult.BindData(false);

            this.xdgvResult.AllowSummary = true;

            this.waitProcessForm.CloseForce();
        }
        #endregion

        private class PrinterParameters
        {
            public String PrinterName { get; set; }
            public Data.Receive.Lotn_For_PrintDataTable Table { get; set; }
        }

        /// <summary>
        /// Обновление итогов по АВС-категориям товара, текущей ящичной норме, которые числятся на остатке
        /// </summary>
        private void RefreshTotals()
        {
            var loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    using (var adapter = new Data.ReceiveTableAdapters.LotnBoxesInfoTableAdapter())
                        e.Result = adapter.GetData(this.UserID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    lotnBoxesInfoBindingSource.DataSource = e.Result;

                this.waitProcessForm.CloseForce();
            };

            lotnBoxesInfoBindingSource.DataSource = null;
            this.waitProcessForm.ActionText = "Выполняется загрузка итоговых данных..";
            loadWorker.RunWorkerAsync();
            this.waitProcessForm.ShowDialog();
        }

        #region ФОНОВАЯ ПЕЧАТЬ СПИСКА ЗАКАЗОВ
        private void sbPrint_Click(object sender, EventArgs e)
        {
            //Data.Receive.Lotn_For_PrintDataTable printTable = new WMSOffice.Data.Receive.Lotn_For_PrintDataTable();
            //foreach (Data.Receive.Lotn_For_PrintRow item in this.receive.Lotn_For_Print.Select(this.lotnForPrintBindingSource.Filter ?? string.Empty, string.Empty))
            //   printTable.Rows.Add(item.ItemArray);

            Data.Receive.Lotn_For_PrintDataTable printTable = this.GetPrintSource();

            //if (printTable.Rows.Count == 0)
            //{
            //    MessageBox.Show("Отсутствуют записи для печати", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            // Печать реестра по фильтру
            BackgroundWorker printWorker = new BackgroundWorker();
            printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
            printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Выполняется печать...";
            printWorker.RunWorkerAsync(new PrinterParameters() { PrinterName = cmbPrinters.SelectedItem.ToString(), Table = printTable });
            waitProcessForm.ShowDialog();
        }

        /// <summary>
        /// Подготовка печати перечня заказов
        /// </summary>
        /// <returns></returns>
        private Data.Receive.Lotn_For_PrintDataTable GetPrintSource()
        {
            Data.Receive.Lotn_For_PrintDataTable printTable = new WMSOffice.Data.Receive.Lotn_For_PrintDataTable();
            Data.Receive.Lotn_For_PrintRow insertedRow = null;
            foreach (DataGridViewRow gridRow in this.xdgvResult.DataGrid.Rows)
            {
                var dataRow = (gridRow.DataBoundItem as DataRowView).Row;

                insertedRow = printTable.NewLotn_For_PrintRow();
                insertedRow.DOCK_Qty_IT = Convert.ToDouble(dataRow["DOCK_Qty_IT"]);
                insertedRow.ITinBX = Convert.ToDouble(dataRow["ITinBX"]);
                insertedRow.DOCK_Qty_BX = Convert.ToDouble(dataRow["DOCK_Qty_BX"]);
                insertedRow.Item_ID = Convert.ToDouble(dataRow["Item_ID"]);
                insertedRow.Item = dataRow["Item"].ToString();
                insertedRow.Manufacturer = dataRow["Manufacturer"].ToString();
                insertedRow.Vendor_Lot = dataRow["Vendor_Lot"].ToString();
                insertedRow.Lot_Number = dataRow["Lot_Number"].ToString();
                insertedRow.Exp_Date = Convert.ToDateTime(dataRow["Exp_Date"]);
                insertedRow.Dcto = dataRow["Dcto"].ToString();
                insertedRow.Doco = Convert.ToDouble(dataRow["Doco"]);

                printTable.AddLotn_For_PrintRow(insertedRow);
            }
            return printTable;
        }

        void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrinterParameters parameters = e.Argument as PrinterParameters;
                string printerName = parameters.PrinterName;

                LotnListReport report = new LotnListReport();
                report.SetDataSource((DataTable)parameters.Table);
                report.PrintOptions.PrinterName = printerName;
                report.PrintToPrinter(1, true, 1, 0);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            { }

            waitProcessForm.CloseForce();
        }
        #endregion


        void xdgvResult_OnRowSelectionChanged(object sender, EventArgs e)
        {
            bool isEnabled = xdgvResult.SelectedItem != null;
            sbIsProblemItemDetected.Enabled = isEnabled && this.xdgvResult.SelectedItem["ProblemItemCriteria"].ToString() == "-";
            sbPrintBoxBarCode.Enabled = isEnabled && this.xdgvResult.SelectedItem["IsBoxSuitable"].ToString() != "N";
            sbPrint.Enabled = this.xdgvResult.DataGrid.RowCount > 0;

            sbShowPrintedYellowLabels.Enabled = isEnabled;
        }

        void xdgvResult_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvResult_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvResult.SelectedItem != null)
            {
                if (sbPrintBoxBarCode.Enabled)
                    this.GoPrint();
            }
        }

        private void sbIsProblemItemDetected_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = this.xdgvResult.SelectedItem;
            Data.ProxyBusinessObjects.ProblemItemRow parameter = new Data.ProxyBusinessObjects.ProblemItemDataTable().NewProblemItemRow();
            parameter.ItemID = Convert.ToInt32(selectedRow["Item_ID"]);
            parameter.ItemName = selectedRow["Item"].ToString();
            parameter.VendorLot = selectedRow["Vendor_Lot"].ToString();
            parameter.LotNumber = selectedRow["Lot_Number"].ToString();
            parameter.Location = selectedRow["Location"].ToString();
            parameter.TotalQuantity = Convert.ToDecimal(selectedRow["DOCK_Qty_IT"]);
            parameter.ProblemQuantity = 0;
            parameter.ProblemCategoryID = -1; // по умолчанию категория не указана

            var dialog = new ProblemItemEditorForm();
            dialog.UserID = this.UserID;
            dialog.SourceItem = parameter;

            if (dialog.ShowDialog() == DialogResult.OK)
                this.RefreshData();
        }

        private void sbPrintBoxBarCode_Click(object sender, EventArgs e)
        {
            this.GoPrint();
            //this.RefreshData();
        }

        void xdgvResult_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.xdgvResult.DataGrid.Rows)
            {
                var boundRow = (this.xdgvResult.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row;

                foreach (DataGridViewColumn column in this.xdgvResult.DataGrid.Columns)
                {
                    #region ПОДСТАНОВКА ИКОНОК ПО ХОЛОДОВОМУ ТОВАРУ
                    if (column is DataGridViewImageColumn)
                    {
                        if (column.Tag != null)
                        {
                            string linkedFieldName = column.Tag.ToString();
                            if (linkedFieldName == "Temperature")
                            {
                                string temperatureSign = boundRow[linkedFieldName].ToString();

                                #region ИНДИКАЦИЯ НАРКОЗА
                                if (boundRow.Table.Columns.Contains("IsNarkoz"))
                                {
                                    if (!boundRow["IsNarkoz"].Equals(DBNull.Value) && boundRow["IsNarkoz"].ToString().Equals("1"))
                                        temperatureSign = "N";
                                }
                                #endregion

                                if (temperatureSign.Equals("N"))
                                    this.xdgvResult.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.narkoz;
                                else if (temperatureSign == "B")
                                    this.xdgvResult.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.snowflakeB;
                                else if (temperatureSign == "R")
                                    this.xdgvResult.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.snowflakeR;
                                else if (temperatureSign == "P")
                                    this.xdgvResult.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.precursor;
                                else
                                    this.xdgvResult.DataGrid.Rows[row.Index].Cells[column.Index].Value = emptyIcon;
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        //private Bitmap imgNarkoz = null;
        //private Bitmap ImageNarkoz
        //{
        //    get
        //    {
        //        if (imgNarkoz == null)
        //            imgNarkoz = CreateImageFromText("H", 16, 16, "Arial Black", 12.0f, FontStyle.Bold, Color.Empty, Color.Red);

        //        return imgNarkoz;
        //    }
        //}

        [Obsolete("Не используется")]
        public static Bitmap CreateImageFromText(string txt, int width, int height, string fontName, float fontSize, FontStyle fontStyle, Color bgColor, Color fgColor)
        {

            Bitmap bmp = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {

                Font font = new Font(fontName, fontSize, fontStyle);
                graphics.FillRectangle(new SolidBrush(bgColor), 0, 0, bmp.Width, bmp.Height);
                graphics.DrawString(txt, font, new SolidBrush(fgColor), 0, 0);
                graphics.Flush();
                font.Dispose();
                graphics.Dispose();


            }
            return bmp;
        }

        void xdgvResult_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var grid = sender as DataGridView;

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ НАЛИЧИЯ ПРОБЛЕМНОГО ТОВАРА ДЛЯ ПОЛЯ "КОЛ-ВО"
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "DOCK_Qty_IT")
            {
                foreach (DataGridViewColumn column in grid.Columns)
                    if (column.DataPropertyName == "ProblemItemCriteria")
                    {
                        var linkedValue = grid.Rows[e.RowIndex].Cells[column.Index].Value;
                        if (linkedValue != null && linkedValue.ToString() != "-")
                        {
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.SelectionForeColor = Color.Red;
                            return;
                        }
                    }
            }
            #endregion

            #region СТИЛЬ ИЗМЕРЕНИЙ ЯЩИКОВ
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "DOCK_Qty_Bx" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "ItemTrail")
            {
                var value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == null || Convert.ToDecimal(value) == 0)
                {
                    e.Value = "-";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    return;
                }
            }
            #endregion

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ОТСУТСТВИЯ ЯЩИЧНОЙ НОРМЫ ДЛЯ ПОЛЯ "В ЯЩИКЕ"
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "ITinBx")
            {
                foreach (DataGridViewColumn column in grid.Columns)
                    if (column.DataPropertyName == "IsBoxSuitable")
                    {
                        var linkedValue = grid.Rows[e.RowIndex].Cells[column.Index].Value;
                        if (linkedValue != null && linkedValue.ToString() == "N")
                        {
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.SelectionForeColor = Color.Red;
                            return;
                        }
                    }
            }
            #endregion

            #region СТИЛЬ ПРОСРОЧКИ НОРМАТИВА
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "ProcessDelay")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                var value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                TimeSpan tsProcessDelay = TimeSpan.Zero;

                bool hasErrors = false;
                if (value == null)
                    hasErrors = true;

                if (!hasErrors)
                {
                    string sValue = value.ToString();
                    bool hasMinus = sValue.Contains("-");
                    string[] sParts = sValue.Split(':');
                    if (sParts.Length != 2)
                        hasErrors = true;

                    if (!hasErrors)
                    {
                        int totalHours;
                        int minutes;

                        if (!Int32.TryParse(sParts[0], out totalHours))
                            hasErrors = true;
                        if (!Int32.TryParse(sParts[1], out minutes))
                            hasErrors = true;

                        if (!hasErrors)
                        {
                            sValue = string.Format("{0}{1}.{2}:{3}", hasMinus ? "-" : string.Empty, totalHours / 24, Math.Abs(totalHours % 24), minutes);
                            if (!TimeSpan.TryParse(sValue, out tsProcessDelay))
                                hasErrors = true;
                        }
                    }
                }

                // Ошибка парсинга либо Норматив просрочен - цвет "красный"
                if (hasErrors || tsProcessDelay.TotalMinutes > 0)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 225, 225);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(255, 225, 225);
                    e.CellStyle.SelectionForeColor = Color.Black;
                    return;
                }

                // До истечения норматива остался 1 рабочий час - цвет "желтый"
                if (tsProcessDelay.TotalMinutes <= 0 && tsProcessDelay.TotalMinutes > -60)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(255, 255, 153);
                    e.CellStyle.SelectionForeColor = Color.Black;
                    return;
                }

                // До истечения норматива остался более чем 1 рабочий час - цвет "зеленый"
                if (tsProcessDelay.TotalMinutes <= -60)
                {
                    e.CellStyle.BackColor = Color.FromArgb(209, 255, 117);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(209, 255, 117);
                    e.CellStyle.SelectionForeColor = Color.Black;
                    return;
                }
            }
            #endregion

            #region СТИЛЬ УСТАНОВЛЕННЫХ ПРИОИРИТЕТОВ ПРИЕМКИ
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "PriorityNum")
            {
                var value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value != null)
                {
                    if (value.Equals(1))
                    {
                        // красный
                        e.CellStyle.BackColor = Color.FromArgb(255, 225, 225);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(255, 225, 225);
                        e.CellStyle.SelectionForeColor = Color.Black;
                        return;
                    }
                    else if (value.Equals(2))
                    {
                        // желтый
                        e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(255, 255, 153);
                        e.CellStyle.SelectionForeColor = Color.Black;
                        return;
                    }
                    else
                    {
                        // зеленый
                        e.CellStyle.BackColor = Color.FromArgb(209, 255, 117);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(209, 255, 117);
                        e.CellStyle.SelectionForeColor = Color.Black;
                        return;
                    }
                }
            }

            #endregion

            #region СТИЛЬ ЯЩИЧНОЙ НОРМЫ
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "IsBoxSuitable")
            {
                var value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (value != null && value.ToString() == "N")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    return;
                }
            }
            #endregion

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ОТСУТСТВИЯ ПРОБЛЕМНОГО ТОВАРА
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "ProblemItemCriteria")
            {
                var value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (value != null && value.ToString() == "-")
                {
                    e.Value = "-";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    return;
                }
            }
            #endregion

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ПРОХОЖДЕНИЯ ВХОДНОГО КОНТРОЛЯ
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "Lot_Number")
            {
                var dr = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;

                if (dr.Table.Columns.Contains("Lotn_Color"))
                {
                    var color = Color.Empty;
                    var sColor = dr["Lotn_Color"].ToString();

                    var rgbPattern = @"^(?<RPart>\d{1,3});(?<GPart>\d{1,3});(?<BPart>\d{1,3})$";
                    var regex = new Regex(rgbPattern, RegexOptions.IgnoreCase);
                    if (regex.IsMatch(sColor))
                    {
                        var match = regex.Match(sColor);
                        var RPart = Convert.ToInt32(match.Groups["RPart"].Value);
                        var GPart = Convert.ToInt32(match.Groups["GPart"].Value);
                        var BPart = Convert.ToInt32(match.Groups["BPart"].Value);

                        color = Color.FromArgb(RPart, GPart, BPart);
                    }
                    else
                    {
                        color = Color.FromName(sColor);
                    }
                    
                    if (color != Color.White)
                    {
                        e.CellStyle.BackColor = color;
                        e.CellStyle.SelectionBackColor = color;
                        e.CellStyle.SelectionForeColor = Color.Black;
                    }
                }
            }
            #endregion
        }

        private void PrintLotnBarcodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.xdgvResult.SaveExtraDataGridViewSettings(this.Name);
            this.SaveFilter();

            InputLanguage.CurrentInputLanguage = this.OldInputLanguage;
        }

        /// <summary>
        /// Сохранение фильтра
        /// </summary>
        private void SaveFilter()
        {
            PrintLotnBarcodeForm.FilterStorage.Clear();
            foreach (var filterItem in this.xdgvResult.GetFilterStorage())
                PrintLotnBarcodeForm.FilterStorage.Add(filterItem);
        }

        private void sbShowPrintedYellowLabels_Click(object sender, EventArgs e)
        {
            var itemID = Convert.ToInt32(xdgvResult.SelectedItem["Item_ID"]);
            var lotNumber = xdgvResult.SelectedItem["Lot_Number"].ToString();

            using (var form = new PrintedYellowLabelsForm() { ItemID = itemID, LotNumber = lotNumber })
                form.ShowDialog();
        }
    }

    public class PrintLotnBarcodeView : IDataView
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
            var searchCriteria = searchParameters as PrintLotnBarcodeSearchParameters;

            string query = string.Format("EXEC [dbo].[pr_WH_Get_Lotn_For_Print] '{0}', {1}",
                searchCriteria.Mode,
                searchCriteria.UserID);

            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.data = dataSet.Tables[0];
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PrintLotnBarcodeView(bool accessBoxInfo)
        {
            this.dataColumns.Add(new PatternColumn("Кол-во, шт.", "DOCK_Qty_IT", new FilterCompareExpressionRule<Decimal>("DOCK_Qty_IT"), SummaryCalculationType.Sum) { Width = 60, UseIntegerNumbersAlignment = true });

            if (accessBoxInfo)
            {
                this.dataColumns.Add(new PatternColumn("В ящике, шт.", "ITinBx", new FilterCompareExpressionRule<Decimal>("ITinBx")) { Width = 60, UseIntegerNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Ящиков", "DOCK_Qty_Bx", new FilterCompareExpressionRule<Decimal>("DOCK_Qty_Bx"), SummaryCalculationType.Sum) { Width = 60, UseIntegerNumbersAlignment = true });
            }

            this.dataColumns.Add(new PatternColumn("Дроби, шт.", "ItemTrail", new FilterCompareExpressionRule<Decimal>("ItemTrail"), SummaryCalculationType.Sum) { Width = 60, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("Код", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count) { Width = 45 });
            this.dataColumns.Add(new PatternColumn("Наименование", "Item", new FilterPatternExpressionRule("Item")) { Width = 230 });
            this.dataColumns.Add(new PatternColumn("Поставщик", "VendorName", new FilterPatternExpressionRule("VendorName"), SummaryCalculationType.Count) { Width = 250 });
            
            this.dataColumns.Add(new PatternColumn("Серия", "Vendor_Lot", new FilterPatternExpressionRule("Vendor_Lot")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Партия", "Lot_Number", new FilterPatternExpressionRule("Lot_Number"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Место", "Location", new FilterPatternExpressionRule("Location")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Срок годности", "Exp_Date", new FilterDateCompareExpressionRule("Exp_Date")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Дата прихода", "BringOnChargeDate", new FilterCompareExpressionRule<DateTime>("BringOnChargeDate")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Отдел", "Department", new FilterPatternExpressionRule("Department"), SummaryCalculationType.Count) { Width = 60 });

            this.dataColumns.Add(new ImagePatternColumn("Темп.", "Temperature") { Width = 40 });

            this.dataColumns.Add(new PatternColumn("Просрочка, раб.час.", "ProcessDelay", new FilterPatternExpressionRule("ProcessDelay")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Приоритет приемки", "PriorityNum", new FilterCompareExpressionRule<Int32>("PriorityNum")) { Width = 70, UseIntegerNumbersAlignment = true });
            //this.dataColumns.Add(new PatternColumn("Ящич. норма", "IsBoxSuitable", new FilterPatternExpressionRule("IsBoxSuitable")) { Width = 45 });
            this.dataColumns.Add(new PatternColumn("Проблемный товар", "ProblemItemCriteria", new FilterPatternExpressionRule("ProblemItemCriteria")) { Width = 85 });
            this.dataColumns.Add(new PatternColumn("Тип заказа", "Dcto", new FilterPatternExpressionRule("Dcto")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Номер заказа", "Doco", new FilterCompareExpressionRule<Int64>("Doco"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Производитель", "Manufacturer", new FilterPatternExpressionRule("Manufacturer")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("Кол-во для визуал. контроля, шт.", "Qty_IT_visual_control", new FilterCompareExpressionRule<Decimal>("Qty_IT_visual_control"), SummaryCalculationType.Sum) { Width = 130, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("НП", "NP", new FilterPatternExpressionRule("NP"), SummaryCalculationType.Count) { Width = 40 });
        }
        #endregion
    }

    public class PrintLotnBarcodeSearchParameters : SearchParametersBase
    {
        public Int64 UserID { get; set; }
        public string Mode { get; set; }
    }

    /// <summary>
    /// Режим приемки партии товара
    /// </summary>
    public enum LotnReceiptMode
    {
        /// <summary>
        /// Печать ЖЭ
        /// </summary>
        PrintYL = 0,
        /// <summary>
        /// Присвоение SSCC
        /// </summary>
        AssignSSCC = 1,
        /// <summary>
        /// Режим просмотра
        /// </summary>
        Preview = -1
    }

    public class AssignSSCCArgs : EventArgs
    {
        public int? ItemID { get; set; }
        public string ItemName { get; set; }
        public string VendorLot { get; set; }
        public string BatchID { get; set; }
        public string ManufacturerName { get; set; }
        public int? LabelsCount { get; set; }
        public int? ProcessedLabelsCount { get; set; }
        public string UnitOfMeasure { get; set; }
        public double? ItemsInBoxCount { get; set; }
    }
}
