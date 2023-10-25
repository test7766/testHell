using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Reports;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class ExtendedReceiveWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        private readonly int useCurrentLotNumber = 1;

        private Data.Receive.DocLinesDataTable _tableCurrentStep = new Data.Receive.DocLinesDataTable();

        [Obsolete("В этом свойстве нет необходимости")]
        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = btnApply.Enabled = value; }
        }

        #endregion

        #region КОНСТРУКТРЫ И ИНИЦИАЛИЗАЦИЯ

        public ExtendedReceiveWindow()
        {
            InitializeComponent();

            // Инициализация фильтра для интерфейса печати ш/к на заводской ящик
            List<FilterItem> filter = new List<FilterItem>();
            filter.Add(new FilterItem("ProblemItemCriteria", "-"));
            PrintLotnBarcodeForm.FilterStorage.Initialize(filter);

            textBoxScaner.UseScanModeOnly = true;
            textBoxScaner.TextChanged += textBoxScaner_TextChanged;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (this.DocType == "PR")
                if (!this.CheckPallet())
                    return;

            InitializeCurrentDocParameters();
            RefreshDocLines();

            textBoxScaner.Focus();
        }

        private bool CheckPallet()
        {
            try
            {
                bool needSetPalletHeight = false;
                int palletDefaultHeight = 0;
                using (var adapter = new Data.ReceiveTableAdapters.GetPalletDefaultParametersTableAdapter())
                    foreach (Data.Receive.GetPalletDefaultParametersRow row in adapter.GetData(this.UserID, this.DocID))
                    {
                        needSetPalletHeight = row.IsNeedHeightNull() ? needSetPalletHeight : row.NeedHeight;
                        palletDefaultHeight = row.IsHeightDefaultNull() ? palletDefaultHeight : row.HeightDefault;
                    }

                if (needSetPalletHeight)
                {
                    var dlgSetPalletHeight = new SetPalletHeightForm(this.DocID, palletDefaultHeight);
                    if (dlgSetPalletHeight.ShowDialog() != DialogResult.OK)
                    {
                        this.Close();
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
                this.Close();
                return false;
            }
        }

        private void ClearWorkPanel()
        {
            _tableCurrentStep.Clear();

            lblItemIDValue.Text = string.Empty;
            lblItemNameValue.Text = string.Empty;
            lblVendorLotValue.Text = string.Empty;
            lblBatchIDValue.Text = string.Empty;
            lblManufacturerNameValue.Text = string.Empty;
            lblCountValue.Text = string.Empty;
            lblUnitOfMeasureValue.Text = string.Empty;
            lblItemsInBoxValue.Text = string.Empty;
            lblBoxesCountValue.Text = string.Empty;
            lblItemsCountValue.Text = string.Empty;
            lblTotalCountValue.Text = string.Empty;

            this.UndoEnabled = false;
        }

        #endregion

        private void textBoxScaner_TextChanged(object sender, EventArgs e)
        {
            CheckBarcode(textBoxScaner.Text, 0, 1);
        }

        private string lastBarcode = string.Empty;
        private void CheckBarcode(string barcode, int itemID, int itemsCount)
        {
            if (string.IsNullOrEmpty(barcode))
                return;

            // сканирование
            try
            {
                // сканирование
                _tableCurrentStep.Clear();
                _tableCurrentStep.Merge(docLinesTableAdapter.CheckBarcode(DocID, "BX", barcode, UserID, useCurrentLotNumber));

                if (_tableCurrentStep.Count == 0)
                    throw new Exception("Нельзя ставить на приход текущую партию.\r\nОтмените ее и выберите другую!");

                Data.Receive.DocLinesRow assignedBarcodeInfo = _tableCurrentStep[0];
                assignedBarcodeInfo.Barcode = barcode;
                lastBarcode = barcode;

                // сохранение текущего результата
                SaveCurrentStep();

                // обновим параметры приемки (в частности кол-во обработанных SSCC)
                InitializeCurrentDocParameters();
            }
            catch (Exception ex)
            {
                ShowError(ex, true);
            }

            textBoxScaner.Text = string.Empty;
        }

        /// <summary>
        /// Обновить информацию о документе
        /// </summary>
        private void RefreshDocLines()
        {
            try
            {
                // обновить информацию о строках документа
                docLinesTableAdapter.Fill(receive.DocLines, DocID, DocType);
                RefreshScannedBarcodes();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Обновить информацию о сканируемых штрих-кодах
        /// </summary>
        private void RefreshScannedBarcodes()
        {
            scannedBarcodesTableAdapter.Fill(receive.ScannedBarcodes, DocID);

            if (dgvBarcodes.Rows.Count > 0)
            {
                var rowFound = false;

                if (!string.IsNullOrEmpty(lastBarcode))
                {
                    foreach (DataGridViewRow dgr in dgvBarcodes.Rows)
                    {
                        var dr = (dgr.DataBoundItem as DataRowView).Row as Data.Receive.ScannedBarcodesRow;
                        if (!dr.IsBar_CodeNull() && dr.Bar_Code.ToUpper().Trim() == lastBarcode.ToUpper().Trim())
                        {
                            dgr.Selected = true;
                            dgvBarcodes.FirstDisplayedScrollingRowIndex = dgr.Index;
                            rowFound = true;
                            break;
                        }
                    }
                }

                if (!rowFound)
                    dgvBarcodes.Rows[0].Selected = false;
            }
        }

        /// <summary>
        /// Сохранение последнего шага сканирования
        /// </summary>
        private void SaveCurrentStep()
        {
            try
            {
                // сохранить текущую позицию
                if (_tableCurrentStep.Count > 0)
                {
                    var assignedBarcodeInfo = _tableCurrentStep[0];
                    docLinesTableAdapter.InsertDetailRow(DocID, assignedBarcodeInfo.Item_ID, lblBatchIDValue.Text,
                                                         assignedBarcodeInfo.LocationFrom, assignedBarcodeInfo.UnitOfMeasure, assignedBarcodeInfo.ITinBX * 1, assignedBarcodeInfo.Barcode,
                                                         null, null, UserID, useCurrentLotNumber, null);

                    // обновить информацию
                    RefreshDocLines();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        [Obsolete("В этом действии нет необходимости")]
        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveCurrentStep();
            ClearWorkPanel();
        }

        [Obsolete("В этом действии нет необходимости")]
        private void btnUndo_Click(object sender, EventArgs e)
        {
            // отменить последнее действие
            ClearWorkPanel();
        }

        #region РЕЗЕРВИРОВАНИЕ Ш/К

        private void btnSetBoxBarcode_Click(object sender, EventArgs e)
        {
            var printLabelForm = new PrintLotnBarcodeForm();
            //printLabelForm.OnAssignSSCC += BeginAssignSSCC;
            printLabelForm.Owner = this;
            printLabelForm.UserID = UserID;
            printLabelForm.DocID = DocID;
            printLabelForm.Location = "DOCK";
            printLabelForm.ReceiptMode = LotnReceiptMode.AssignSSCC;

            if (printLabelForm.ShowDialog() == DialogResult.OK)
                InitializeCurrentDocParameters();
        }

        /// <summary>
        /// Подготовка к началу присвоения SSCC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginAssignSSCC(object sender, AssignSSCCArgs e)
        {
            ClearWorkPanel();

            lblItemIDValue.Text = e.ItemID.ToString();
            lblItemNameValue.Text = e.ItemName;
            lblVendorLotValue.Text = e.VendorLot;
            lblBatchIDValue.Text = e.BatchID;
            lblManufacturerNameValue.Text = e.ManufacturerName;
            lblCountValue.Text = e.LabelsCount.ToString();
            lblUnitOfMeasureValue.Text = e.UnitOfMeasure;
            lblItemsInBoxValue.Text = e.ItemsInBoxCount.ToString();
            lblBoxesCountValue.Text = e.ProcessedLabelsCount.ToString();
            lblTotalCountValue.Text = e.ProcessedLabelsCount.ToString();

            this.ChangeReceiptState();

            textBoxScaner.Focus();
        }

        /// <summary>
        /// Получение текущих параметров приемки
        /// </summary>
        private void InitializeCurrentDocParameters()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.DocCurrentParametersTableAdapter())
                    adapter.Fill(this.receive.DocCurrentParameters, this.UserID, this.DocID);

                if (this.receive.DocCurrentParameters.Rows.Count == 0)
                    throw new Exception("Отсутствуют текущие параметры документа приемки");

                var dsDocParams = this.receive.DocCurrentParameters[0];

                this.BeginAssignSSCC(this, new AssignSSCCArgs()
                {
                    ItemID = dsDocParams.IsCurrent_Item_idNull() ? (int?)null : dsDocParams.Current_Item_id,
                    ItemName = dsDocParams.IsItem_nameNull() ? string.Empty : dsDocParams.Item_name,
                    VendorLot = dsDocParams.IsVendor_lotNull() ? string.Empty : dsDocParams.Vendor_lot,
                    BatchID = dsDocParams.IsCurrent_Lot_NumberNull() ? string.Empty : dsDocParams.Current_Lot_Number,
                    ManufacturerName = dsDocParams.IsManufacturer_nameNull() ? string.Empty : dsDocParams.Manufacturer_name,
                    ItemsInBoxCount = dsDocParams.IsCurrent_Box_CapacityNull() ? (double?)null : dsDocParams.Current_Box_Capacity,
                    UnitOfMeasure = dsDocParams.IsUOMNull() ? string.Empty : dsDocParams.UOM,
                    LabelsCount = dsDocParams.IsCurrent_Box_CountNull() ? (int?)null : dsDocParams.Current_Box_Count,
                    ProcessedLabelsCount = dsDocParams.IsCurrent_Total_Box_CountNull() ? (int?)null : dsDocParams.Current_Total_Box_Count
                });
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Изменить статус приемки 
        /// </summary>
        private void ChangeReceiptState()
        {
            var allowChangeReceiptLotn = true;

            try
            {
                var cntPlanBoxes = 0;
                var cntFactBoxes = 0;

                int.TryParse(lblCountValue.Text, out cntPlanBoxes);
                int.TryParse(lblBoxesCountValue.Text, out cntFactBoxes);

                allowChangeReceiptLotn = cntFactBoxes >= cntPlanBoxes;
            }
            catch { }

            btnSetBoxBarcode.Enabled = allowChangeReceiptLotn;
            btnUndoLotReceipt.Enabled = !allowChangeReceiptLotn;
        }

        #endregion

        private void btnUndoLotReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.DocCurrentParametersTableAdapter())
                    adapter.ClearCurrentParameters(this.UserID, this.DocID);

                this.ClearWorkPanel();
                this.ChangeReceiptState();

                this.RefreshDocLines();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #region ЗАКРЫТИЕ ДОКУМЕНТА ПРИЕМКИ

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            if (receive.DocLines.Count == 0)
                MessageBox.Show("Невозможно закрыть документ, в котором нет строк.\n\rПеремещение пустых паллет недопустимо.", "Ошибка пользователя!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (MessageBox.Show("Закрыть документ?" + Environment.NewLine + "Документ будет сохранен, УПАКОВОЧНЫЙ ЛИСТ будет отправлен на печать, а текущее окно будет закрыто.", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // закрываем документ
                        CloseDocument();

                        // напечатаем упаковочный лист
                        PackingListReport report = new PackingListReport();
                        BarcodePrepare(receive, DocID, DocType);
                        SetUserFIO(receive, UserID);

                        report.SetDataSource(receive);
                        report.SetParameterValue("DocID", DocID);

                        var form = new WMSOffice.Dialogs.ReportForm();
                        form.ReportDocument = report;
                        form.Print();
                        //form.ShowDialog();

                        // переводим статус
                        //if (form.IsPrinted)
                        //    CloseDocument();

                        if (DocType == "OK")
                            MessageBox.Show("Переместите (с помощью ТСД) образцы с упаковочным листом в отдел качества.",
                                "Следующее действие...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // закрываем окно
                        Close();
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
        }

        private void CloseDocument()
        {
            using (var adapter = new Data.ReceiveTableAdapters.DocsTableAdapter())
            {
                adapter.CloseDoc(DocID, UserID);
            }
        }

        public static void BarcodePrepare(Data.Receive receive, long docID, string docType)
        {
            using (var adapter = new Data.ReceiveTableAdapters.DocsTableAdapter())
            {
                adapter.Fill(receive.Docs, docID, docType);
                if (receive.Docs.Count > 0)
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
                    barCodeCtrl.BarCode = receive.Docs[0].Bar_Code; //"12345678PRWMS";
                    byte[] barCode = null;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        barCode = ms.ToArray();
                    }
                    receive.Docs[0].Bar_Code_IMG = barCode;

                    System.IO.File.WriteAllBytes(@"c:\tmp\123.bmp", barCode);
                }
            }
        }

        /// <summary>
        /// Задание фамилии сотрудника, который печатает пак-лист
        /// </summary>
        /// <param name="pReceive">DataSet с данными</param>
        /// <param name="pSessionID">Идентификатор пользователя</param>
        public static void SetUserFIO(Data.Receive pReceive, long pSessionID)
        {
            try
            {
                var adapter = new Data.ReceiveTableAdapters.UsersTableAdapter();
                var table = adapter.GetData(pSessionID);
                if (table.Rows.Count > 0)
                    foreach (Data.Receive.DocsRow row in pReceive.Docs)
                        row.UserFIO = "Сотрудник: " + table[0].Employee;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(exc.ToString());
                //Logger.ShowErrorMessageBox("Не удалось получить фамилию сотрудника!", exc);
            }
        }

        #endregion

        private void dgvDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                Data.Receive.DocLinesRow diffRow = (Data.Receive.DocLinesRow)((DataRowView)row.DataBoundItem).Row;

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

        private void dgvBarcodes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var row = (dgvBarcodes.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.ScannedBarcodesRow;
            var scanResult = row.IsScanResultNull() ? 0 : row.ScanResult;
            var color = scanResult == 1 ? Color.FromArgb(209, 255, 117) : Color.FromArgb(255, 225, 225);

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }
    }
}
