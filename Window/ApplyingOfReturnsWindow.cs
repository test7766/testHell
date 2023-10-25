using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Controls;
using WMSOffice.Dialogs;
using WMSOffice.Data;
using WMSOffice.Data.ComplaintsTableAdapters;
using WMSOffice.Reports;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Window
{
    public partial class ApplyingOfReturnsWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Окно ожидания, которое отображается при длительных операциях
        /// </summary>
        private SplashForm waitProgressForm = new SplashForm();

        /// <summary>
        /// Код полки
        /// </summary>
        private string _locationID = null;
        private string LocationID 
        {
            get 
            {
                if (_locationID == null)
                    throw new Exception("Отсутствует выбранная полка.");

                return _locationID;
            }
            set { _locationID = value; } 
        }

        /// <summary>
        /// Описание полки
        /// </summary>
        private string LocationDesc { get; set; }

        private Complaints.ReturnsDocLinesDataTable _tableCurrentStep = new Complaints.ReturnsDocLinesDataTable();
        private bool rememberSeria;
        private bool UndoEnabled
        {
            get { return sbUndo.Enabled; }
            set { sbUndo.Enabled = sbApply.Enabled = value; }
        }

        #endregion

        public ApplyingOfReturnsWindow()
        {
            InitializeComponent();
        }

        private void ApplyingOfReturnsWindow_Load(object sender, EventArgs e)
        {
            textBoxScaner.TextChanged += new EventHandler(textBoxScaner_TextChanged);
            rbIT.Checked = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            PrepareLocations();

            ClearWorkPanel();
            //RefreshDocLines();
        }

        /// <summary>
        /// Подготовка списка полок
        /// </summary>
        private void PrepareLocations()
        {
            // Добавление списка полок
            var cmbLocations = new ComboBox();
            cmbLocations.Size = new Size(200, cmbLocations.Height);
            //cmbLocations.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbLocations.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbLocations.DropDownStyle = ComboBoxStyle.DropDownList;

            #region ФОРМИРОВАНИЕ СПИСКА ПОЛОК

            var bsLocations = new BindingSource();
            bsLocations.DataMember = "ReturnsLocations";
            bsLocations.DataSource = new Data.ComplaintsExt();
            cmbLocations.DisplayMember = "Desc";
            cmbLocations.ValueMember = "Location";
            cmbLocations.DataSource = bsLocations;
            cmbLocations.Name = "cmbLocations";

            cmbLocations.SelectedValueChanged += delegate(object sender, EventArgs e)
            {
                this.LocationID = cmbLocations.SelectedValue == null ? (string)null : cmbLocations.SelectedValue.ToString();
                this.LocationDesc = cmbLocations.Text;

                RefreshDocLines();
            };

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    using (var adapter = new Data.ComplaintsExtTableAdapters.ReturnsLocationsTableAdapter())
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
                    this.ShowError(e.Result as Exception);
                else
                {
                    bsLocations.DataSource = e.Result;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка списка полок..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            #endregion

            tsMainMenu.Items.Add(new ToolStripControlHost(cmbLocations));

            // Добавление разделителя с отступом
            tsMainMenu.Items.Add(new ToolStripSeparator() { Margin = new Padding(3, 0, 0, 0) });
        }

        void textBoxScaner_TextChanged(object sender, EventArgs e)
        {
            if (rbWL.Checked)
                CheckBarcodeWL(textBoxScaner.Text);
            else
                CheckBarcode(textBoxScaner.Text, 0, 1);
        }

        private void rbBX_CheckedChanged(object sender, EventArgs e)
        {
            //btnAddItem.Enabled = rbIT.Checked; // видна всегда
            tbCount.Enabled = rbIT.Checked; 
        }

        private void rbWL_CheckedChanged(object sender, EventArgs e)
        {
            tbCount.Enabled = rbIT.Checked; 
            sbAddItemWithoutBarCode.Enabled = !rbWL.Checked;
            lblItemSeria.Enabled = !rbWL.Checked; 
        }

        private void lblItemSeria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChooseSeries();
        }

        private void sbApply_Click(object sender, EventArgs e)
        {
            SaveCurrentStep();
            ClearWorkPanel();
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
                    Complaints.ReturnsDocLinesRow row0 = _tableCurrentStep[0];
                    returnsDocLinesTableAdapter.InsertDetailRow(DocID, row0.Item_ID, (string)lblItemSeria.Tag,
                                                         row0.LocationFrom, row0.UnitOfMeasure, row0.ITinBX * int.Parse(tbCount.Text), row0.Barcode);
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
                returnsDocLinesTableAdapter.Fill(complaints.ReturnsDocLines, DocID, this.LocationID);
                // обновить информацию о заполнении палеты
                fillingRate.Value = (int)returnsDocLinesTableAdapter.GetPalletLimit(DocID);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
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

        private void sbUndo_Click(object sender, EventArgs e)
        {
            ClearWorkPanel();
        }

        private void sbAddItemWithoutBarCode_Click(object sender, EventArgs e)
        {
            AddItemWithoutBarCode();
        }

        /// <summary>
        /// Добавление товара без штрих-кода
        /// </summary>
        private void AddItemWithoutBarCode()
        {
            AddItemForm form = new AddItemForm() { LocationID = this.LocationID };
            if (form.ShowDialog() == DialogResult.OK)
            {
                CheckBarcode(String.Empty, form.ItemCode, form.Count);
            }
        }

        private void CheckBarcodeWL(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
                return;

            try
            {
                returnsDocLinesTableAdapter.CheckBarcodeWL(DocID, barcode, UserID, this.LocationID, "WL");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("WRONG_QUANTITY"))
                    ShowWLQuantityErrorMessage();
                else
                    ShowError(ex);
            }
            finally
            {
                RefreshDocLines();
            }
        }

        private void ShowWLQuantityErrorMessage()
        {
            try
            {
                var dlgShowErrors = new ApplyingOfWLReturnsShowErrorForm(DocID);
                dlgShowErrors.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
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
                {
                    // Адаптация выбора товара в случае двойственного ш/к
                    var itemRow = WMSOffice.Controls.SearchTextBoxSelector.VerifyItem(
                        "[dbo].[pr_CO_Get_ItmByBarCode]",
                        UserID,
                        string.Empty,
                        new List<ReferencedObject>(new ReferencedObject[] { 
                            new ReferencedObject { Key = "bc", Value = barcode }, 
                            new ReferencedObject { Key = "uom", Value = (rbBX.Checked) ? "BX" : "IT" } }),
                        AutoSelectItemSideMode.None);

                    if (itemRow != null)
                    {
                        itemID = Convert.ToInt32(itemRow["Item_ID"]);
                        _tableCurrentStep.Merge(returnsDocLinesTableAdapter.CheckBarcode(DocID, (rbBX.Checked) ? "BX" : "IT", barcode, UserID, this.LocationID, itemID));
                    }
                }
                else
                    _tableCurrentStep.Merge(returnsDocLinesTableAdapter.CheckBarcodeByItem(DocID, "IT", itemID, itemsCount, UserID, this.LocationID));

                if (_tableCurrentStep.Count == 0)
                    ShowError("Товар не найден!");
                else
                {
                    Complaints.ReturnsDocLinesRow row0 = _tableCurrentStep[0];
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
                        Complaints.ReturnsDocLinesRow rowFind = _tableCurrentStep.FindByItem_IDLot_Code(itemCode, itemSeria);
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
                else
                    ShowError(ex);

                ClearWorkPanel();
                //throw;
            }
            textBoxScaner.Text = "";
        }

        private void RecognizeBarcode()
        {
            RecognizeBarcodeForm form = new RecognizeBarcodeForm() { LocationID = this.LocationID };
            form.UserID = UserID;
            form.Barcode = textBoxScaner.Text;
            form.ItemUOM = (rbBX.Checked) ? "BX" : "IT";
            form.EnableItemsInBox = (rbBX.Checked);
            form.ShowDialog();
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
                    Complaints.ReturnsDocLinesRow row = (Complaints.ReturnsDocLinesRow)((DataRowView)form.SelectedItem).Row;
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

        private bool allowCloseWindow = false;
        private void sbCloseDoc_Click(object sender, EventArgs e)
        {
            if (complaints.ReturnsDocLines.Count == 0)
                MessageBox.Show("Невозможно закрыть документ, в котором нет строк.\n\rПеремещение пустых паллет недопустимо.", "Ошибка пользователя!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (MessageBox.Show("Закрыть документ?" + Environment.NewLine + "Документ будет сохранен, УПАКОВОЧНЫЙ ЛИСТ будет отправлен на печать, а текущее окно будет закрыто.", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // сохраним текущий шаг
                        sbApply_Click(sender, e);

                        // закрываем документ
                        CloseDocument();

                        // напечатаем упаковочный лист
                        PackingListReport report = new PackingListReport();
                        BarcodePrepare(complaints, DocID, DocType);

                        // TODO конвертировать в receive !!!!!!!!!!!!!!!


                        var receive = this.PrepareReportSource();
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
                        allowCloseWindow = true;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
        }

        /// <summary>
        /// Конвертация источника данных для отчета 
        /// </summary>
        /// <returns></returns>
        private Receive PrepareReportSource()
        {
            return PrepareReportSource(complaints);
        }

        private static Receive PrepareReportSource(Complaints complaints)
        {
            var receive = new Receive();
            foreach (Complaints.ReturnsDocsRow row in complaints.ReturnsDocs)
            {
                if (row.Bar_Code_IMG.Length > 0)
                {
                    var newRow = receive.Docs.NewDocsRow();

                    newRow.Bar_Code = row.IsBar_CodeNull() ? string.Empty : row.Bar_Code;
                    newRow.Bar_Code_IMG = row.IsBar_Code_IMGNull() ? null : row.Bar_Code_IMG;
                    newRow.Doc_Date = row.IsDoc_DateNull() ? DateTime.Now : row.Doc_Date;
                    newRow.Doc_ID = row.Doc_ID;
                    newRow.Doc_Type = row.Doc_Type;
                    newRow.Doc_Type_Name = row.IsDoc_Type_NameNull() ? string.Empty : row.Doc_Type_Name;
                    newRow.Location_To = row.IsLocation_ToNull() ? string.Empty : row.Location_To;
                    newRow.Module_ID = row.IsModule_IDNull() ? string.Empty : row.Module_ID;
                    newRow.Status_ID = row.Status_ID;
                    newRow.Status_Name = row.IsStatus_NameNull() ? string.Empty : row.Status_Name;

                    receive.Docs.AddDocsRow(newRow);

                    break;
                }
            }
            foreach (Complaints.ReturnsDocLinesRow row in complaints.ReturnsDocLines)
            {
                var newRow = receive.DocLines.NewDocLinesRow();

                newRow.Barcode = row.IsBarcodeNull() ? string.Empty : row.Barcode;
                newRow.BX_Qty = row.IsBX_QtyNull() ? 0 : row.BX_Qty;
                newRow.Color = row.IsColorNull() ? string.Empty : row.Color;
                newRow.IT_Qty = row.IsIT_QtyNull() ? 0 : row.IT_Qty;
                newRow.Item_ID = row.Item_ID;
                newRow.Item_Name = row.IsItem_NameNull() ? string.Empty : row.Item_Name;
                newRow.ITinBX = row.IsITinBXNull() ? 0 : row.ITinBX;
                newRow.LocationFrom = row.IsLocationFromNull() ? string.Empty : row.LocationFrom;
                newRow.Lot_Code = row.Lot_Code;
                newRow.Lot_Number = row.IsLot_NumberNull() ? string.Empty : row.Lot_Number;
                newRow.Manufacturer = row.IsManufacturerNull() ? string.Empty : row.Manufacturer;
                newRow.Qty = row.IsQtyNull() ? 0 : row.Qty;
                newRow.SnowFlake = row.IsSnowFlakeNull() ? string.Empty : row.SnowFlake;
                newRow.UnitOfMeasure = row.IsUnitOfMeasureNull() ? string.Empty : row.UnitOfMeasure;

                receive.DocLines.AddDocLinesRow(newRow);
            }

            return receive;
        }

        public static Receive PreparePackListReportSource(long docID, string docType, string locationID)
        {
            var complaints = new Data.Complaints();
            ApplyingOfReturnsWindow.BarcodePrepare(complaints, docID, docType);

            using (var adapter = new Data.ComplaintsTableAdapters.ReturnsDocLinesTableAdapter())
                adapter.Fill(complaints.ReturnsDocLines, docID, locationID);

            var receive = ApplyingOfReturnsWindow.PrepareReportSource(complaints);
            return receive;
        }

        public static void BarcodePrepare(Complaints receive, long docID, string docType)
        {
            using (ReturnsDocsTableAdapter adapter = new ReturnsDocsTableAdapter())
            {
                adapter.Fill(receive.ReturnsDocs, docID, docType);
                if (receive.ReturnsDocs.Count > 0)
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
                    barCodeCtrl.BarCode = receive.ReturnsDocs[0].Bar_Code; //"12345678PRWMS";
                    byte[] barCode = null;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        barCode = ms.ToArray();
                    }
                    receive.ReturnsDocs[0].Bar_Code_IMG = barCode;
                }
            }
        }

        private void CloseDocument()
        {
            using (ReturnsDocsTableAdapter adapter = new ReturnsDocsTableAdapter())
            {
                adapter.CloseDoc(DocID, UserID);
            }
        }

        private void sbUndoDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите закрыть документ перемещения с ошибкой?", "Отмена перемещения", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (ReturnsDocsTableAdapter adapter = new ReturnsDocsTableAdapter())
                    {
                        adapter.CancelDoc(DocID);
                    }

                    // закрываем окно
                    allowCloseWindow = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Отобразить остатки
        /// </summary>
        private void sbShowRemains_Click(object sender, EventArgs e)
        {
            try
            {
                ShowRemains();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Отображение остатков
        /// </summary>
        private void ShowRemains()
        {
            new RemainsOfReturns(this.LocationID, this.LocationDesc) { UserID = this.UserID }.ShowDialog();
        }

        private void ApplyingOfReturnsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения процедуры перемещения. Пожалуйста, продолжайте работу.\n\rДля закрытия документа перемещения воспользуйтесь командой \"Закрыть документ о перемещении товара\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }

            //if (_tableCurrentStep.Count > 0)
            //    if (MessageBox.Show("Сохранить последний результат сканирования?", "Закрытие документа", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        SaveCurrentStep();
        }

        private void gvDocLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            foreach (DataGridViewRow row in gvDocLines.Rows)
            {
                Data.Complaints.ReturnsDocLinesRow diffRow = (Data.Complaints.ReturnsDocLinesRow)((DataRowView)row.DataBoundItem).Row;

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

        private void tbCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void tbCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckBarcode(textBoxScaner.Text, 0, 1);
                textBoxScaner.Focus();
            }
        }

        /// <summary>
        /// Дублирование кнопок на панели инструментов кнопками на клавиатуре
        /// </summary>
        private void ApplyingOfReturnsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    AddItemWithoutBarCode();
                    break;
                case Keys.F6:
                    sbCloseDoc_Click(sender, e);
                    break;
                case Keys.F8:
                    sbUndoDoc_Click(sender, e);
                    break;
                case Keys.F7:
                    ShowRemains();
                    break;
            }
        }
    }
}
