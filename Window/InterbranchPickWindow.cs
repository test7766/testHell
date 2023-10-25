using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Reports;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class InterbranchPickWindow : GeneralWindow
    {
        public InterbranchPickWindow()
        {
            InitializeComponent();
            lblBranch.Text = lblDate.Text = lblPlaces.Text = "";
        }

        private void InterbranchPickWindow_Load(object sender, EventArgs e)
        {
            RefreshHeader();
            //colNoItem.Visible = IsRepeatControl;
            RefreshLines();
        }

        private void RefreshHeader()
        {
            // получаем информацию по номеру документа
            using (Data.InterbranchTableAdapters.IBInfoTableAdapter adapter = new WMSOffice.Data.InterbranchTableAdapters.IBInfoTableAdapter())
            {
                try
                {
                    Data.Interbranch.IBInfoDataTable table = adapter.GetData(DocID);
                    if (table == null || table.Count != 1)
                        ShowError("Не найдена информация о документе!");
                    else
                    {
                        Data.Interbranch.IBInfoRow row = table[0];
                        lblBranch.Text = (row.IsShipTo_NameNull()) ? "" : row.ShipTo_Name;
                        lblDate.Text = row.Doc_Date.ToShortDateString();
                        lblPlaces.Text = (row.IsPlacesNull()) ? "0" : row.Places.ToString();
                        lblPSNumber.Text = row.IsPickSlipOpenNull() ? "-" : row.PickSlipOpen;
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
            docRowsBindingSource.Filter = "";
            docRowsBindingSource.Sort = "";
            docRowsTableAdapter.Fill(interbranch.DocRows, DocID);
            //if (gvLines.Rows.Count > 0)
            //    gvLines.Rows[0].Selected = true;
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
                    try
                    {
                        AddRow(tbBarcode.Text, null);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("DOUBLE_FILIAL"))
                        {
                            ChooseBranches();
                        }
                        else if (ex.Message.Contains("OPENPS"))
                        {
                            // новое от 13.08.2010 -- результат следует отобразить на отдельной форме
                            long pickSlipNumber = 0;
                            if (long.TryParse(ex.Message.Replace("OPENPS", ""), out pickSlipNumber))
                            {
                                ShowInterbranchPSDifference(pickSlipNumber);
                            }
                            else ShowError("Предыдущий сборочный не был закрыт, но попытка получить его номер закончилась ошибкой!\n\rОбратитесь в Группу Сопровождения ПО.");
                        }
                        else if (ex.Message.Contains("REDFORM"))
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

        private void AddRow(string barcode, int? shipToID)
        {
            UndoEnabled = false;
            docRowsTableAdapter.AddRow(DocID, barcode, shipToID);
            _barcode = barcode;
            UndoEnabled = true;
            RefreshHeader();
            RefreshLines();
        }

        RichListForm formBranches = null;
        private void ChooseBranches()
        {
            // получение списка филиалов по штрих-коду заводского ящика
            using (Data.InterbranchTableAdapters.BoxFilialsTableAdapter adapter = new WMSOffice.Data.InterbranchTableAdapters.BoxFilialsTableAdapter())
            {
                Data.Interbranch.BoxFilialsDataTable dataTable = adapter.GetData(tbBarcode.Text);
                if (dataTable != null && dataTable is DataTable && ((DataTable)dataTable).Rows.Count > 0)
                {
                    if (formBranches == null)
                    {
                        formBranches = new RichListForm();
                        #region column ShipTo
                        DataGridViewTextBoxColumn colShipTo = new DataGridViewTextBoxColumn();
                        colShipTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                        colShipTo.DataPropertyName = "ShipTo_Name";
                        colShipTo.HeaderText = "Филиал-получатель";
                        colShipTo.Name = "colShipTo";
                        colShipTo.ReadOnly = true;
                        formBranches.Columns.Add(colShipTo);
                        #endregion
                        #region column Qty
                        DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
                        colQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                        colQty.DataPropertyName = "Qty";
                        colQty.HeaderText = "Кол-во";
                        colQty.Name = "colQty";
                        colQty.ReadOnly = true;
                        formBranches.Columns.Add(colQty);
                        #endregion

                        formBranches.FilterVisible = false;
                    }
                    formBranches.Text = "Выбор филиала";
                    formBranches.DataSource = dataTable;

                    if (formBranches.ShowDialog() == DialogResult.OK)
                    {
                        if (formBranches.SelectedRow != null)
                        {
                            Data.Interbranch.BoxFilialsRow row = (Data.Interbranch.BoxFilialsRow)formBranches.SelectedRow;
                            AddRow(tbBarcode.Text, (!row.IsShipTo_IDNull()) ? (int?)row.ShipTo_ID : null);
                        }
                        else UndoEnabled = false;
                    }
                    else UndoEnabled = false;
                }
                else UndoEnabled = false;
            }
        }

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
                    docRowsTableAdapter.CancelLine(DocID, _barcode);
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

        private PrintLotnBarcodeForm printLabelForm;
        private void btnPrintEtic_Click(object sender, EventArgs e)
        {   
            if (printLabelForm == null)
                printLabelForm = new PrintLotnBarcodeForm();
            printLabelForm.UserID = UserID;
            printLabelForm.Location = "IB";
            printLabelForm.ReceiptMode = LotnReceiptMode.PrintYL;
            printLabelForm.ShowDialog();
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            bool ignoreOpenPSN = false;
            bool reply = true;
            if (MessageBox.Show("Закрыть документ?" + Environment.NewLine + "Документ будет закрыт, УПАКОВОЧНЫЙ ЛИСТ будет отправлен на печать (принтер по умолчанию), а текущее окно будет закрыто.", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                while (reply)
                {
                    reply = false;
                    try
                    {
                        // закрытие документа
                        docRowsTableAdapter.CloseDoc(DocID, ignoreOpenPSN);

                        //using (Data.InterbranchTableAdapters.PackingTableAdapter packingAdapter = new WMSOffice.Data.InterbranchTableAdapters.PackingTableAdapter())
                        //{
                        //    packingAdapter.Fill(interbranch.Packing, DocID);
                        DocsPrepare(interbranch.Packing, DocID);

                        if (interbranch.Packing.Count != 1)
                            throw new Exception("Не удалось получить данные для Упаковочного листа.");

                        // напечатаем упаковочный лист
                        InterbranchPackReport report = new InterbranchPackReport();

                        BarcodePrepare(interbranch.Packing);

                        report.SetDataSource((DataTable) interbranch.Packing);
                        //report.SetParameterValue("DocID", DocID);

                        ReportForm form = new ReportForm();
                        form.ReportDocument = report;
                        form.Print();
                        // form.ShowDialog();

                        // переводим статус
                        if (form.IsPrinted)
                        {
                            //CloseDocument();

                            // закрываем окно
                            allowCloseWindow = true;
                            Close();
                        }
                        //}
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("OPENPS"))
                        {
                            // новое от 13.08.2010 -- результат следует отобразить на отдельной форме
                            long pickSlipNumber = 0;
                            if (long.TryParse(ex.Message.Replace("OPENPS", ""), out pickSlipNumber))
                            {
                                ShowInterbranchPSDifference(pickSlipNumber);
                            }
                            else
                                ShowError(
                                    "Предыдущий сборочный не был закрыт, но попытка получить его номер закончилась ошибкой!\n\rОбратитесь в Группу Сопровождения ПО.");
                            
                            if (!ignoreOpenPSN)
                                if (MessageBox.Show("Предыдущий сборочный не был закрыт!"+Environment.NewLine+"Желаете все-таки закрыть документ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                                    == System.Windows.Forms.DialogResult.Yes)
                                {
                                    ignoreOpenPSN = true;
                                    reply = true;
                                }
                        }
                        else if (ex.Message.Contains("REDFORM"))
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
        }

        public static void DocsPrepare(WMSOffice.Data.Interbranch.PackingDataTable packing, long docID)
        {
            packing.Clear();

            using (Data.InterbranchTableAdapters.PackingTableAdapter packingAdapter = new WMSOffice.Data.InterbranchTableAdapters.PackingTableAdapter())
            {
                packingAdapter.Fill(packing, docID);
            }
        }

        public static void BarcodePrepare(WMSOffice.Data.Interbranch.PackingDataTable packing)
        {
        //    using (DocsTableAdapter adapter = new DocsTableAdapter())
        //    {
        //        adapter.Fill(receive.Docs, docID);
                if (packing.Count > 0)
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
                    barCodeCtrl.BarCode = packing[0].Bar_Code; //"12345678PRWMS";
                    byte[] barCode = null;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        barCode = ms.ToArray();
                    }
                    packing[0].Bar_Code_IMG = barCode;
                }
        //    }
        }

        private bool allowCloseWindow = false;
        private void InterbranchPickWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения комплектации паллеты межсклада. Пожалуйста, продолжайте работу.\n\rДля закрытия документа комплектации воспользуйтесь командой \"Завершить комплектацию межсклада\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshLines();
        }

        /// <summary>
        /// Показывает диалог с недостающими строками из сборочного
        /// </summary>
        /// <param name="pickSlipNumber">Номер сборочного листа</param>
        private void ShowInterbranchPSDifference(long pickSlipNumber)
        {
            using (Dialogs.PickControl.IBPSDifferenceForm form = new IBPSDifferenceForm(pickSlipNumber, DocID))
                form.ShowDialog();
        }

    }
}
