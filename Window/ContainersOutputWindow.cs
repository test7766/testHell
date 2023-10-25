using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Data.ContainersTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Reports;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class ContainersOutputWindow : GeneralWindow
    {
        public ContainersOutputWindow()
        {
            InitializeComponent();
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

        private void btnPrintEtic_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            string message = (this.DocType == "TO" || this.DocType == "T2")
                                 ? "Закрыть документ?" + Environment.NewLine + "Документ будет закрыт, АКТ ПЕРЕДАЧИ ТАРЫ будет отправлен на печать (принтер по умолчанию), а текущее окно будет закрыто."
                                 : (this.DocType == "T1")
                                    ? "Закрыть документ?"
                                    : ((lblNeedCount.Text == lblCurrentCount.Text) 
                                        ? "Закрыть документ?" 
                                        : "Закрыть документ?" + Environment.NewLine + "Принятое количество тары не совпадает с ожидаемым возвратом. При закрытии документа разница будет возвращена на филиал!");
            
            if (MessageBox.Show(message, "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (this.DocType != "TO" && this.DocType != "T2")
                    {
                        docRowsTableAdapter.CloseDoc(DocID);
                        Close();
                    }
                    else
                        using (Data.ContainersTableAdapters.ActRowsTableAdapter actAdapter = new ActRowsTableAdapter())
                        {
                            Containers.ActRowsDataTable table = actAdapter.GetData(DocID);

                            if (table.Count < 1)
                                throw new Exception("Не удалось получить данные для Акта.");

                            // напечатаем акт приема/передачи
                            ContainersOutputReport report = new ContainersOutputReport();

                            //BarcodePrepare(interbranch.Packing);

                            report.SetDataSource((DataTable)table);

                            ReportForm form = new ReportForm();
                            form.ReportDocument = report;
                            form.Print();
                            // form.ShowDialog();

                            // переводим статус
                            if (form.IsPrinted)
                            {
                                docRowsTableAdapter.CloseDoc(DocID);

                                // Печать акта приема-передачи холодового оборудования
                                if (this.DocType == "T1")
                                    this.PrintColdEquipmentIssuanceReceiptAct();

                                // закрываем окно
                                //allowCloseWindow = true;
                                Close();
                            }
                        }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void PrintColdEquipmentIssuanceReceiptAct()
        {
            try
            {
                using (var adapter = new Data.ContainersTableAdapters.ColdEquipmentIssuanceReceiptActTableAdapter())
                    adapter.Fill(containers.ColdEquipmentIssuanceReceiptAct, this.DocID);

                if (containers.ColdEquipmentIssuanceReceiptAct.Rows.Count > 0)
                {
                    foreach (Data.Containers.ColdEquipmentIssuanceReceiptActRow row in containers.ColdEquipmentIssuanceReceiptAct)
                    {
                        #region ПОЛУЧЕНИЕ ИЗОБРАЖЕНИЯ Ш/К
                        BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                        barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                        barCodeCtrl.Size = new Size(274 * 5, 108 * 5);
                        barCodeCtrl.BarCodeHeight = 50 * 5;
                        barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                        barCodeCtrl.HeaderText = "";
                        barCodeCtrl.LeftMargin = 10 * 5;
                        barCodeCtrl.ShowFooter = true;
                        barCodeCtrl.TopMargin = 20 * 5;
                        barCodeCtrl.BarCode = row.Bar_Code;
                        byte[] barCode = null;
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            barCode = ms.ToArray();
                        }
                        row.Bar_Code_Buffer = barCode;
                        #endregion
                    }

                    var report = new Reports.ColdEquipmentIssuanceReceiptActReport();
                    report.SetDataSource(containers);
                    report.PrintToPrinter(1, false, 1, 0);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = miUndo.Enabled = value; }
        }


        private void RefreshHeader()
        {
            // получаем информацию по номеру документа
            using (Data.ContainersTableAdapters.LimitContainerTableAdapter adapter = new WMSOffice.Data.ContainersTableAdapters.LimitContainerTableAdapter())
            {
                try
                {
                    Data.Containers.LimitContainerDataTable table = adapter.GetData(DocID);
                    if (table == null || table.Count != 1)
                        ShowError("Не найдена информация о документе!");
                    else
                    {
                        Data.Containers.LimitContainerRow row = table[0];
                        lblDepartment.Text = (!row.IsDepartmentNameNull())
                                                 ? row.DepartmentName
                                                 : (row.IsFilial_NameNull()) ? "" : row.Filial_Name;
                        lblNeedCount.Text = String.Format("{0} / {1} / {2}",
                                                          row.IsNeedCountContA1Null() ? 0 : row.NeedCountContA1,
                                                          row.IsNeedCountContA2Null() ? 0 : row.NeedCountContA2,
                                                          row.IsNeedCountContA3Null() ? 0 : row.NeedCountContA3);
                        lblCurrentCount.Text = String.Format("{0} / {1} / {2}",
                                                          row.IsCurrCountContA1Null() ? 0 : row.CurrCountContA1,
                                                          row.IsCurrCountContA2Null() ? 0 : row.CurrCountContA2,
                                                          row.IsCurrCountContA3Null() ? 0 : row.CurrCountContA3);

                        if (this.DocType == "T1" || this.DocType == "T2")
                        {
                            label9.Visible = false;
                            lblNeedCount.Visible = false;
                            lblCurrentCount.Text = string.Empty;
                        }

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
            docRowsTableAdapter.Fill(containers.DocRows, DocID);
            if (gvLines.Rows.Count > 0)
                gvLines.Rows[0].Selected = true;

            if (this.DocType == "T1" || this.DocType == "T2")
            {
                lblCurrentCount.Text = string.Format("{0}", gvLines.Rows.Count);
            }
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
                using (Data.ContainersTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.ContainersTableAdapters.ItemsTableAdapter())
                {
                    try
                    {
                        Data.Containers.ItemsDataTable table = adapter.GetData(DocID, UserID, tbBarcode.Text);
                        if (table == null || table.Count < 1)
                            throw new Exception(
                                "Товар не найден!");
                        else if (table.Count == 1)
                        {
                            // только один товар нашли! можем переходить к выбору серии
                            Data.Containers.ItemsRow itemsRow = table[0];

                            AddRow(tbBarcode.Text);
                            //tbBarcode.Focus();

                            //_itemCode = (int) itemsRow.Item_ID;
                            //_itemName = itemsRow.Item;
                            //_itemUOM = itemsRow.UnitOfMeasure;
                            //_count = (int) itemsRow.Qty;
                            //_scanType = "B";
                            //if (!itemsRow.IsVendor_LotNull() && !String.IsNullOrEmpty(itemsRow.Vendor_Lot))
                            //{
                            //    // отсканировали уникальный штрих код ящика! Знаем даже серию!
                            //    _vendorLot = itemsRow.Vendor_Lot;
                            //    AddRow();
                            //}
                            //else
                            //{
                            //    // отсканировали простой товар, идентифицировали, выбираем серию
                            //    ChooseSeries();
                            //}
                        }
                        else
                        {
                            // нашли несколько товаров, нужно выбрать наш
                            // ChooseItems(table);
                            throw new ArgumentException("Штрих-код пластиковой тары должен быть уникальным!");
                        }
                    }
                    catch (Exception ex)
                    {
                        //if (ex.Message.Contains("REDFORM"))
                        //{
                        //    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        //        String.Format(
                        //            "Товар {0}\n\rНЕ содержится\n\rв сборочном листе.\n\rВерните товар в отдел!",
                        //            ex.Message.Replace("REDFORM", "")),
                        //        "Товар возвращен в отдел.\n\rПРОДОЛЖИТЬ (Enter)", Color.Red);
                        //    errorForm.ShowDialog();
                        //}
                        //else 
                        ShowError(ex);
                    }
                }
            tbBarcode.Text = "";
        }

        private void AddRow(string barcode)
        {
            UndoEnabled = false;
            docRowsTableAdapter.AddRow(DocID, barcode);
            _barcode = barcode;
            UndoEnabled = true;
            RefreshHeader();
            RefreshLines();
        }

        private void ContainersOutputWindow_Load(object sender, EventArgs e)
        {
            if (this.DocType == "T1" || this.DocType == "T2" || this.DocType == "TO")
            {
                Warehouse_id.Visible = true;
                Reason_Description.Visible = true;
            }

            RefreshHeader();
            RefreshLines();
        }

        private void gvLines_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (this.DocType != "T2" && this.DocType != "TO")
            {
                e.Cancel = true;
                return;
            }

            var docRow = (e.Row.DataBoundItem as DataRowView).Row as Data.Containers.DocRowsRow;
            var barCode = docRow.Lot_Code;
            if (MessageBox.Show(string.Format("Вы уверены что хотите удалить позицию {0}?", barCode), "Удаление позиции", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                docRowsTableAdapter.CancelLine(DocID, barCode);
                UndoEnabled = false;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void gvLines_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RefreshHeader();
            RefreshLines();

            tbBarcode.Focus();
        }
    }
}
