using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Data;
using WMSOffice.Data.ReceiveTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Reports;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Window
{
    public partial class ReceiveWindow : GeneralWindow
    {
        private readonly int useCurrentLotNumber = 0;

        public ReceiveWindow()
        {
            InitializeComponent();

            // Инициализация фильтра для интерфейса печати ш/к на заводской ящик
            List<FilterItem> filter = new List<FilterItem>();
            filter.Add(new FilterItem("ProblemItemCriteria", "-"));
            PrintLotnBarcodeForm.FilterStorage.Initialize(filter);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            // отменить последнее действие
            ClearWorkPanel();
            //fillingRate.Value += 3;
        }

        private void ClearWorkPanel()
        {
            _tableCurrentStep.Clear();
            lblItemCode.Text = lblItemName.Text = "";
            lblItemSeria.Tag = "";
            lblItemSeria.Text = "(пусто)";
            lblManufacturer.Text = tbCount.Text = lblItemEI.Text = lblItemsInBox.Text = lblCountBox.Text = lblCountItems.Text = lblCountTotal.Text = "";
            UndoEnabled = false;
        }

        //private string CurrentStep_LotCode { get; set; }
        //private int CurrentStep_ItemCode { get; set; }
        //private int CurrentStep_Count { get; set; }

        private Receive.DocLinesDataTable _tableCurrentStep = new Receive.DocLinesDataTable();
        private bool rememberSeria;
        private void textBoxScaner_TextChanged(object sender, EventArgs e)
        {
            CheckBarcode(textBoxScaner.Text, 0, 1);
        }

        private void CheckBarcode(string barcode, int itemID, int itemsCount)
        {
            // сканирование
            try
            {
                // организация продолжения сканирования товара уже выбранной серии
                int itemCode = 0;
                string itemSeria = "";
                string itemSeriaName = "";
                if (rememberSeria)
                {
                    itemCode = (String.IsNullOrEmpty(lblItemCode.Text)) ? 0 : int.Parse(lblItemCode.Text);
                    itemSeria = (string)lblItemSeria.Tag;
                    itemSeriaName = lblItemSeria.Text;
                }
                // сохранение предыдущего результата
                SaveCurrentStep();
                // сканирование
                _tableCurrentStep.Clear();
                if (!String.IsNullOrEmpty(barcode))
                    _tableCurrentStep.Merge(docLinesTableAdapter.CheckBarcode(DocID, (rbBX.Checked) ? "BX" : "IT", textBoxScaner.Text, UserID, useCurrentLotNumber));
                else
                    _tableCurrentStep.Merge(docLinesTableAdapter.CheckBarcodeByItem(DocID, "IT", itemID, itemsCount, UserID));
                if (_tableCurrentStep.Count == 0)
                    ShowError("Товар не найден!");
                else
                {
                    Receive.DocLinesRow row0 = _tableCurrentStep[0];
                    row0.Barcode = barcode;
                    lblItemCode.Text = row0.Item_ID.ToString();
                    lblItemName.Text = (row0.IsItem_NameNull()) ? "" : row0.Item_Name;
                    lblManufacturer.Text = (row0.IsManufacturerNull()) ? "" : row0.Manufacturer;
                    tbCount.Text = itemsCount.ToString();
                    lblItemEI.Text = (row0.IsUnitOfMeasureNull()) ? "" : row0.UnitOfMeasure;
                    lblItemsInBox.Text = (row0.IsITinBXNull()) ? "" : row0.ITinBX.ToString();
                    lblCountBox.Text = (row0.IsBX_QtyNull()) ? "" : row0.BX_Qty.ToString();
                    lblCountItems.Text = (row0.IsIT_QtyNull()) ? "" : row0.IT_Qty.ToString();
                    lblCountTotal.Text = (row0.IsQtyNull()) ? "" : row0.Qty.ToString();

                    if (rememberSeria && itemCode == row0.Item_ID && _tableCurrentStep.FindByItem_IDLot_Code(itemCode, itemSeria) != null)
                    {
                        Receive.DocLinesRow rowFind = _tableCurrentStep.FindByItem_IDLot_Code(itemCode, itemSeria);
                        lblItemSeria.Tag = itemSeria;
                        lblItemSeria.Text = itemSeriaName;
                        lblCountBox.Text = (rowFind.IsBX_QtyNull()) ? "" : rowFind.BX_Qty.ToString();
                        lblCountItems.Text = (rowFind.IsIT_QtyNull()) ? "" : rowFind.IT_Qty.ToString();
                        lblCountTotal.Text = (rowFind.IsQtyNull()) ? "" : rowFind.Qty.ToString();
                    }
                    else
                    {
                        lblItemSeria.Tag = (_tableCurrentStep.Count > 1) ? "" : row0.Lot_Code;
                        lblItemSeria.Text = (_tableCurrentStep.Count > 1)
                                                ? "(выбор)"
                                                : (row0.IsLot_NumberNull()) ? "(пусто)" : row0.Lot_Number;
                        ChooseSeries();
                    }
                    UndoEnabled = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNKNOWN_BARCODE"))
                    RecognizeBarcode();
                else if (ex.Message.Contains("DOUBLE_BARCODE") && NeedCheckBossID())
                    CheckBossID();
                else
                    ShowError(ex);

                ClearWorkPanel();
                //throw;
            }
            textBoxScaner.Text = "";
        }

        private void RecognizeBarcode()
        {
            RecognizeBarcodeForm form = new RecognizeBarcodeForm();
            form.UserID = UserID;
            form.Barcode = textBoxScaner.Text;
            form.ItemUOM = (rbBX.Checked) ? "BX" : "IT";
            form.EnableItemsInBox = (rbBX.Checked);
            form.ShowDialog();
        }

        private bool NeedCheckBossID()
        {
            try
            {
                var needCheck = (bool?)null;
                docLinesTableAdapter.NeedCheckBossID(this.DocID, this.DocType, ref needCheck);

                return Convert.ToBoolean(needCheck ?? false);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return false;
            }
        }

        private void CheckBossID()
        {
            // Обеспечим повторные действия на случай возникновения сбоев
            while (true)
            {
                try
                {
                    var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте бэйдж руководителя\r\nдля возобновления приемки товара",
                        Text = "ЖЭ была отсканирована ранее",
                        Image = Properties.Resources.role,
                        //OnlyNumbersInBarcode = true
                        UseScanModeOnly = true
                    };

                    if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                        continue;

                    var bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                    var canAccess = (bool?)null;
                    docLinesTableAdapter.CheckBossID(this.UserID, bossID, textBoxScaner.Text, ref canAccess);

                    if ((canAccess ?? false) == false)
                    {
                        MessageBox.Show("Пользователь не имеет полномочий\r\nдля возобновления приемки товара.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = btnApply.Enabled = value; }
        }

        /// <summary>
        /// Метод выбора серии (если серий больше 1)
        /// </summary>
        private void ChooseSeries()
        {
            if (_tableCurrentStep.Count > 1)
            {
                ListChoiceForm form = new ListChoiceForm(_tableCurrentStep, "Lot_Number", "Lot_Code");
                form.Text = "Выбор серии";
                if (!String.IsNullOrEmpty((string)lblItemSeria.Tag))
                    form.Value = lblItemSeria.Tag;
                form.ShowDialog();
                if (form.SelectedItem != null)
                {
                    Receive.DocLinesRow row = (Receive.DocLinesRow)((DataRowView)form.SelectedItem).Row;
                    lblItemSeria.Tag = row.Lot_Code;
                    lblItemSeria.Text = (row.IsLot_NumberNull()) ? "(пусто)" : row.Lot_Number;
                    lblCountBox.Text = (row.IsBX_QtyNull()) ? "" : row.BX_Qty.ToString();
                    lblCountItems.Text = (row.IsIT_QtyNull()) ? "" : row.IT_Qty.ToString();
                    lblCountTotal.Text = (row.IsQtyNull()) ? "" : row.Qty.ToString();
                }
                rememberSeria = form.RememberChoice;
            }
            textBoxScaner.Focus();
        }

        /// <summary>
        /// Обработчик события -- пользователь хочет изменить серию
        /// </summary>
        private void lblItemSeria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChooseSeries();
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
                    Receive.DocLinesRow row0 = _tableCurrentStep[0];
                    docLinesTableAdapter.InsertDetailRow(DocID, row0.Item_ID, (string) lblItemSeria.Tag,
                                                         row0.LocationFrom, row0.UnitOfMeasure, row0.ITinBX * int.Parse(tbCount.Text), row0.Barcode,
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

        /// <summary>
        /// Обновить информацию о документе
        /// </summary>
        private void RefreshDocLines()
        {
            try
            {
                // обновить информацию о строках документа
                docLinesTableAdapter.Fill(receive.DocLines, DocID, DocType);
                // обновить информацию о заполнении палеты
                fillingRate.Value = (int)docLinesTableAdapter.GetPalletLimit(DocID);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ReceiveWindow_Load(object sender, EventArgs e)
        {
            rbBX.Checked = rbBX.Enabled = (DocType == "PR");
            rbIT.Checked = rbIT.Enabled = btnAddItem.Enabled = (DocType == "OK");
            ClearWorkPanel();
            RefreshDocLines();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (this.DocType == "PR")
                CheckPallet();
        }

        private void CheckPallet()
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
                        this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
                this.Close();
            }
        }

        private PrintLotnBarcodeForm printLabelForm;
        private void btnPrintEtic_Click(object sender, EventArgs e)
        {
            //if (printLabelForm == null)
            //    printLabelForm = new PrintLotnBarcodeForm();

            printLabelForm = new PrintLotnBarcodeForm();
            printLabelForm.Owner = this;
            printLabelForm.UserID = UserID;
            printLabelForm.Location = "DOCK";
            printLabelForm.ReceiptMode = LotnReceiptMode.PrintYL;
            printLabelForm.ShowDialog();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveCurrentStep();
            ClearWorkPanel();
        }

        private void ReceiveWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_tableCurrentStep.Count > 0)
                if (MessageBox.Show("Сохранить последний результат сканирования?", "Закрытие документа", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveCurrentStep();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItemForm form = new AddItemForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CheckBarcode(String.Empty, form.ItemCode, form.Count);
            }
        }

        public static void BarcodePrepare(Receive receive, long docID, string docType)
        {
            using (DocsTableAdapter adapter = new DocsTableAdapter())
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
                }
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            if (receive.DocLines.Count == 0)
                MessageBox.Show("Невозможно закрыть документ, в которм нет строк.\n\rПеремещение пустых паллет недопустимо.", "Ошибка пользователя!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (MessageBox.Show("Закрыть документ?" + Environment.NewLine + "Документ будет сохранен, УПАКОВОЧНЫЙ ЛИСТ будет отправлен на печать, а текущее окно будет закрыто.", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // сохраним текущий шаг
                        btnApply_Click(sender, e);

                        // закрываем документ
                        CloseDocument();

                        // напечатаем упаковочный лист
                        PackingListReport report = new PackingListReport();
                        BarcodePrepare(receive, DocID, DocType);
                        SetUserFIO(receive, UserID);

                        report.SetDataSource(receive);
                        report.SetParameterValue("DocID", DocID);

                        ReportForm form = new ReportForm();
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

        /// <summary>
        /// Задание фамилии сотрудника, который печатает пак-лист
        /// </summary>
        /// <param name="pReceive">DataSet с данными</param>
        /// <param name="pSessionID">Идентификатор пользователя</param>
        public static void SetUserFIO(Receive pReceive, long pSessionID)
        {
            try
            {
                var adapter = new UsersTableAdapter();
                var table = adapter.GetData(pSessionID);
                if (table.Rows.Count > 0)
                    foreach (Receive.DocsRow row in pReceive.Docs)
                        row.UserFIO = "Сотрудник: " + table[0].Employee;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(exc.ToString());
                //Logger.ShowErrorMessageBox("Не удалось получить фамилию сотрудника!", exc);
            }
        }

        private void CloseDocument()
        {
            using (DocsTableAdapter adapter = new DocsTableAdapter())
            {
                adapter.CloseDoc(DocID, UserID);
            }
        }

        private void rbBX_CheckedChanged(object sender, EventArgs e)
        {
            //btnAddItem.Enabled = (rbIT.Checked); // видна всегда
            //tbCount.Enabled = (rbIT.Checked); // никогда не вводим количество
        }

        private void miPrintEtic_Click(object sender, EventArgs e)
        {
            btnPrintEtic_Click(sender, e);
        }

        private void gvDocLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            foreach (DataGridViewRow row in gvDocLines.Rows)
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
    }
}
