using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Data.InterbranchTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Reports;
using WMSOffice.Controls;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class InterbranchReceiveWindow : GeneralWindow
    {
        /// <summary>
        /// Признак сокрытия "белых" строк 
        /// </summary>
        private readonly bool hideWhiteRows = true;

        public InterbranchReceiveWindow()
        {
            InitializeComponent();
            lblBranch.Text = lblDate.Text = lblPlaces.Text = lblPSNumber.Text = "";
        }

        private void InterbranchPickWindow_Load(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshLines();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!this.SelectTare())
            {
                allowCloseWindow = true;
                this.Close();
            }
        }

        private bool SelectTare()
        {
            try
            {
                var canSetPalletType = (bool?)null;

                // Анализ необходимости ввода типа тары
                using (var palletCheckTypeAdapter = new Data.InterbranchTableAdapters.PalletTypesTableAdapter())
                    palletCheckTypeAdapter.CheckCanSetPalletType(this.DocID, ref canSetPalletType);

                // Ввод типа тары обязателен
                if (canSetPalletType.HasValue && canSetPalletType.Value == true)
                {
                    int? palletTypeID = 0; // тип тары
                    bool tareSelected = false; // признак выбора тары

                    Data.Interbranch.PalletTypesDataTable palletTypes = null;
                    using (var palletTypeAdapter = new Data.InterbranchTableAdapters.PalletTypesTableAdapter())
                        palletTypes = palletTypeAdapter.GetData(UserID);

                    if (palletTypes != null && palletTypes.Rows.Count > 0)
                    {
                        do
                        {
                            var dlgSelectPalletType = new WMSOffice.Dialogs.RichListForm();
                            dlgSelectPalletType.Text = "Выберите тип паллеты";
                            dlgSelectPalletType.AddColumn("Type_Desc", "Type_Desc", "Тип паллеты");
                            //dlgSelectPalletType.ColumnForFilters = new List<string>(new string[] { "Type_Desc" });
                            dlgSelectPalletType.DisableFilter = true;
                            dlgSelectPalletType.FilterChangeLevel = 0;
                            dlgSelectPalletType.DataSource = palletTypes;

                            if (dlgSelectPalletType.ShowDialog() == DialogResult.OK)
                            {
                                palletTypeID = Convert.ToInt32((dlgSelectPalletType.SelectedRow as Data.Interbranch.PalletTypesRow).Type_ID);
                            }
                            else
                            {
                                throw new Exception("Тип паллеты не был выбран.\r\nРабота с документом контроля Вами была прервана.");
                            }

                            var errorCode = (int?)null;
                            var errorMessage = (string)null;

                            // Проверка типа тары для документа
                            using (var palletTypeAdapter = new Data.InterbranchTableAdapters.PalletTypesTableAdapter())
                                palletTypeAdapter.CheckPalletTypeForDoc(UserID, this.DocID, palletTypeID, ref errorCode, ref errorMessage);

                            if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                            {
                                if (MessageBox.Show(errorMessage, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    // Тип тары указан неверно, но с согласием пользователя 
                                    tareSelected = true;
                                    break;
                                }
                            }
                            else
                            {
                                // Тип тары указан верно
                                tareSelected = true;
                                break;
                            }

                        } while (true);

                        if (tareSelected)
                        {
                            // Установка типа тары для документа
                            using (var palletTypeAdapter = new Data.InterbranchTableAdapters.PalletTypesTableAdapter())
                                palletTypeAdapter.SetPalletTypeForDoc(UserID, this.DocID, palletTypeID);
                        }
                    }
                    //else
                    //{
                    //    throw new Exception("Процедура не вернула список типов тары.");
                    //}
                }

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private bool _allowSplitPallet = false;
        private bool AllowSplitPallet
        {
            get { return _allowSplitPallet; }
            set { 
                _allowSplitPallet = value;
                btnClosePallet.Visible = miClosePallet.Visible = pnlInfo.Visible = _allowSplitPallet;
            }
        }

        private bool ShowNeedQuantity
        {
            set { needQtyDataGridViewTextBoxColumn.Visible = value; }
        }

        private bool _undoEnabledByDoc; // возможность отмены последнего действия по документу

        private void RefreshHeader()
        {
            // получаем информацию по номеру документа
            using (Data.InterbranchTableAdapters.ReceiveInfoTableAdapter adapter = new Data.InterbranchTableAdapters.ReceiveInfoTableAdapter())
            {
                try
                {
                    Data.Interbranch.ReceiveInfoDataTable table = adapter.GetData(DocID);
                    if (table == null || table.Count != 1)
                        ShowError("Не найдена информация о документе!");
                    else
                    {
                        Data.Interbranch.ReceiveInfoRow row = table[0];
                        lblBranch.Text = (row.IsShipTo_NameNull()) ? "" : row.ShipTo_Name;
                        lblDate.Text = row.Doc_Date.ToShortDateString();
                        lblPlaces.Text = (row.IsPlacesNull()) ? "0" : row.Places.ToString();
                        lblPSNumber.Text = (row.IsNaklNumberNull()) ? "-" : row.NaklNumber.ToString();
                        AllowSplitPallet = (row.IsAutoPutawayFlagNull()) ? false : row.AutoPutawayFlag;
                        ShowNeedQuantity = (row.IsShow_Need_QtyNull()) ? false : row.Show_Need_Qty;
                        _undoEnabledByDoc = (row.IsUndoEnabledNull()) ? false : row.UndoEnabled;
                        tbBarcode.Focus();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void RefreshLines()
        {
            receiveDocRowsBindingSource.Filter = "";
            receiveDocRowsBindingSource.Sort = "";

            var hideWhiteRowsFlag = hideWhiteRows ? 1 : 0;
            receiveDocRowsTableAdapter.Fill(interbranch.ReceiveDocRows, DocID, hideWhiteRowsFlag);
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
                try
                {
                    AddRow(tbBarcode.Text);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("REDFORM"))
                    {
                        FullScreenErrorForm errorForm = new FullScreenErrorForm(
                            String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                            "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                        errorForm.TimeOut = 2000;
                        errorForm.ShowDialog();
                        UndoEnabled = false;
                    }
                    else
                        ShowError(ex);
                }
            tbBarcode.Text = "";
        }

        /// <summary>
        /// Метод добавления строки/строк по штрих-коду
        /// </summary>
        /// <param name="barcode"></param>
        private void AddRow(string barcode)
        {
            UndoEnabled = false;

            try
            {
                // добавление строки
                using (Data.InterbranchTableAdapters.ReceiveDocRowsAddTableAdapter adapter = new ReceiveDocRowsAddTableAdapter())
                {
                    // добавляем строку в документ контроля содержимого транспортной паллеты,
                    // обратно ожидаем получить текстовую подсказку, куда поставить отсканированное
                    Interbranch.ReceiveDocRowsAddDataTable table = adapter.GetData(DocID, barcode);

                    if (table != null && table.Count > 0)
                    {
                        // добавили строку, получили сообщение
                        lblInfo.Text = table[0].Message;

                        // если получили идентификатор листа размещения - печатаем его!
                        if (!table[0].IsMoveTask_IDNull())
                            PrintMoveTaskList(table[0].MoveTask_ID);
                    }
                    else lblInfo.Text = "";
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                try
                {
                    if (isBarCodeAcquiringFromTerminalEnabled)
                    {
                        using (var adapter = new Data.InterbranchTableAdapters.ReceiveDocBarCodeEmulationTableAdapter())
                            adapter.CompleteBarCodeEmulationTask(this.DocID, barcode);

                        tbBarcode.ScannerListener.Start();
                    }

                    // сохраняем текущий штрих-код
                    _barcode = barcode;
                    UndoEnabled = true && _undoEnabledByDoc;
                    // обновляем данные на форме
                    RefreshHeader();
                    RefreshLines();
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Метод печати листа размещения по его идентификатору
        /// </summary>
        /// <param name="moveTaskID"></param>
        private void PrintMoveTaskList(int moveTaskID)
        {
            try
            {
                // создадим таблицу для данных отчета
                WMove.WM_PutListDataTable putList = new WMove.WM_PutListDataTable();

                // получим данные отчета, штрих-код создан
                MovePutListPrepare(putList, moveTaskID);

                // напечатаем лист размещения
                WMovePutListReport report = new WMovePutListReport();
                report.SetDataSource((DataTable)putList);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.Print(); 
                //form.ShowDialog();

                if (form.IsPrinted)
                {
                    MessageBox.Show("Лист размещения был успешно отправлен на печать.", "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "IR", 1, Convert.ToInt64(moveTaskID), (string)null, Convert.ToInt16(putList.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #region print move task

        /// <summary>
        /// Статический метод получает данные, необходимые для печати листа размещения по идентификатору
        /// </summary>
        /// <param name="putList"></param>
        /// <param name="putListID"></param>
        public static void MovePutListPrepare(WMSOffice.Data.WMove.WM_PutListDataTable putList, long putListID)
        {
            putList.Clear();

            using (Data.WMoveTableAdapters.WM_PutListTableAdapter adapter = new WMSOffice.Data.WMoveTableAdapters.WM_PutListTableAdapter())
            {
                adapter.Fill(putList, putListID);

                if (putList != null && putList.Count > 0)
                    MovePutListBarcodePrepare(putList);
            }
        }

        /// <summary>
        /// Статический метод добавляет штрих-код по тексту
        /// </summary>
        /// <param name="putList"></param>
        private static void MovePutListBarcodePrepare(WMSOffice.Data.WMove.WM_PutListDataTable putList)
        {
            if (putList.Count > 0)
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
                barCodeCtrl.BarCode = putList[0].Bar_Code;
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                putList[0].Bar_Code_IMG = barCode;
            }
        }

        #endregion

        /// <summary>
        /// Разрешить отмену последнего действия
        /// </summary>
        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = miUndo.Enabled = value; }
        }

        private string _barcode;
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (UndoEnabled && !String.IsNullOrEmpty(_barcode))
            {
                try
                {
                    receiveDocRowsTableAdapter.Delete(DocID, _barcode);
                    UndoEnabled = false;
                    RefreshHeader();
                    RefreshLines();
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Закрытие документа контроля транспортной паллеты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            bool ignoreOpenPallet = false;
            try
            {
                // можно ли закрывать документ контроля по паллете?
                int docIsFull = (int)receiveDocRowsTableAdapter.CheckDocIsFull(DocID);
                if (docIsFull != 1)
                    ignoreOpenPallet = (MessageBox.Show("Содержимое документа контроля отличается от ожидаемого содержимого паллеты. Вы уверены, что хотите закрыть документ контроля?\n\r\n\rЕсли Вы ответите \"Да\" (\"Yes\"), на разницу между накладной и документом будут сформированы акты излишков/недостач.", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes);

                // закрываем документ контроля
                if (docIsFull == 1 || ignoreOpenPallet)
                {
                    // непосредственно перед закрытием пытаемся закрыть паллету размещения товара
                    if (AllowSplitPallet)
                        btnClosePallet_Click(sender, e);

                    // закрытие документа
                    receiveDocRowsTableAdapter.CloseDoc(DocID);

                    // печать всех актов излишка/недостач
                    if (ignoreOpenPallet)
                    {
                        // признак, что акт был удачно напечатан
                        bool isPrinted = false;

                        // список актов по документу контроля
                        using (ActsTableAdapter adapter = new ActsTableAdapter())
                        {
                            Interbranch.ActsDataTable table = adapter.GetData(DocID);
                            if (table != null && table.Count > 0)
                            {
                                // надеемся, что акт будет напечатан
                                isPrinted = true;

                                foreach (Interbranch.ActsRow row in table)
                                {
                                    // наполнение акта данными
                                    interbranch.Acts.Clear();
                                    interbranch.Acts.ImportRow(row);
                                    ActPrepare(interbranch.ActDetails, row.Act_ID);

                                    // напечатаем акты излишков/недостач
                                    InterbranchActByPackingReport report = new InterbranchActByPackingReport();

                                    BarcodePrepare(interbranch.Acts);

                                    report.SetDataSource((DataSet)interbranch);

                                    ReportForm form = new ReportForm();
                                    form.ReportDocument = report;
                                    form.Print();

                                    // узнаем, был ли напечатан акт
                                    isPrinted = isPrinted && form.IsPrinted;
                                }
                            }
                            else
                            {
                                // не смогли успешно напечатать все акты
                                isPrinted = false;
                                // исключительная ситуация
                                throw new Exception("Не удалось получить данные для печати Актов.");
                            }
                        }

                        if (isPrinted)
                        {
                            // закрываем окно
                            allowCloseWindow = true;
                            Close();
                        }
                    }
                    else 
                        if (docIsFull == 1)
                        {
                            // закрываем окно без печати документов
                            allowCloseWindow = true;
                            Close();
                        }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REDFORM"))
                {
                    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                        "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                    errorForm.TimeOut = 2000;
                    errorForm.ShowDialog();
                    UndoEnabled = false;
                }
                else
                    ShowError(ex);
            }
        }

        public static void ActPrepare(WMSOffice.Data.Interbranch.ActDetailsDataTable actDetails, long actID)
        {
            actDetails.Clear();

            using (Data.InterbranchTableAdapters.ActDetailsTableAdapter packingAdapter = new Data.InterbranchTableAdapters.ActDetailsTableAdapter())
            {
                packingAdapter.Fill(actDetails, actID);
            }
        }

        public static void BarcodePrepare(WMSOffice.Data.Interbranch.ActsDataTable acts)
        {
                if (acts.Count > 0)
                {
                    // создание штрих-кода
                    BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                    barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                    barCodeCtrl.Size = new Size(274 * 5, 108 * 5);
                    barCodeCtrl.BarCodeHeight = 50 * 5;
                    barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                    barCodeCtrl.HeaderText = "";
                    barCodeCtrl.LeftMargin = 10 * 5;
                    barCodeCtrl.ShowFooter = true;
                    barCodeCtrl.TopMargin = 20 * 5;
                    barCodeCtrl.BarCode = acts[0].Bar_Code;
                    byte[] barCode = null;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        barCode = ms.ToArray();
                    }
                    acts[0].Bar_Code_IMG = barCode;
                }
        }

        private bool allowCloseWindow = false;
        private void InterbranchPickWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
                {
                    MessageBox.Show("Нельзя закрыть окно документа до завершения контроля паллеты межсклада. Пожалуйста, продолжайте работу.\n\rДля закрытия документа комплектации воспользуйтесь командой \"Завершить контроль транспортной паллеты\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    return;
                }

                if (isBarCodeAcquiringFromTerminalEnabled)
                    tbBarcode.ScannerListener.Stop();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshLines();
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            // разрисовка строк в таблице
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.Interbranch.ReceiveDocRowsRow diffRow = (Data.Interbranch.ReceiveDocRowsRow)((DataRowView)row.DataBoundItem).Row;

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

        /// <summary>
        /// Метод закрытия паллеты на размещение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClosePallet_Click(object sender, EventArgs e)
        {
            // запрещаем отменять строку (возврата нет, товар попал в печатную форму размещения)
            UndoEnabled = false;

            try
            {
                // добавление строки
                using (Data.InterbranchTableAdapters.ReceivePlacementPalletCloseTableAdapter adapter = new ReceivePlacementPalletCloseTableAdapter())
                {
                    // закрытие паллеты на размещение, т.е. создание задания на размещение
                    Interbranch.ReceivePlacementPalletCloseDataTable table = adapter.GetData(UserID, DocID);

                    // печатаем лист размещения на созданную паллету размещения заводских ящиков
                    if (table != null && table.Count > 0)
                        PrintMoveTaskList((int)table[0].Doc_ID);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        bool isBarCodeAcquiringFromTerminalEnabled = false;
        private void btnEnableAcquireBarCodeFromTerminal_Click(object sender, EventArgs e)
        {
            tbBarcode.Text = "";

            isBarCodeAcquiringFromTerminalEnabled = !isBarCodeAcquiringFromTerminalEnabled;
            btnEnableAcquireBarCodeFromTerminal.BackColor = isBarCodeAcquiringFromTerminalEnabled ? Color.LightSkyBlue : SystemColors.Control;

            tbBarcode.ScannerListener = isBarCodeAcquiringFromTerminalEnabled ? new InerbranchReceiveScannerListener(DocID) : null;
            
            if (isBarCodeAcquiringFromTerminalEnabled)
                tbBarcode.ScannerListener.Start();

            tbBarcode.Focus();
        }

        private class InerbranchReceiveScannerListener : ScannerListenerBase
        {
            public InerbranchReceiveScannerListener(long docID)
                : base(docID)
            {

            }

            protected override bool Execute()
            {
                try
                {
                    var retData = new Data.Interbranch.ReceiveDocBarCodeEmulationDataTable();
                    using (var adapter = new Data.InterbranchTableAdapters.ReceiveDocBarCodeEmulationTableAdapter())
                        adapter.Fill(retData, _docID);

                    if (retData != null && retData.Count > 0)
                    {
                        var barCode = retData[0].BAR_Code;
                        RaiseAquireBarCode(barCode);

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
