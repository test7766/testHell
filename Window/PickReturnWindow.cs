using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WMSOffice.Dialogs.Containers;
using WMSOffice.Dialogs.PickControl;
using System.Windows.Forms.VisualStyles;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Reports;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Classes;
using WMSOffice.Dialogs;

namespace WMSOffice.Window
{
    public partial class PickReturnWindow : GeneralWindow
    {
        /// <summary>
        /// Признак, показывающий, можно ли закрыть документ в любой момент без сохранения.
        /// </summary>
        private bool AlwaysAllowClose { get; set; }

        /// <summary>
        /// Режим поштучного контроля товара
        /// </summary>
        private bool IsPickControlMode { get; set; }

        /// <summary>
        /// Список сотрудников, участвующих в процессе.
        /// </summary>
        private Data.WH.DocStatusEmployeesDataTable DocStatusEmployees { get; set; }

        private long? _RelatedDocID;
        
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="caption">Заголовок диалога.</param>
        /// <param name="alwaysAllowClose">Признак, показывающий, можно ли закрыть документ в любой момент без сохранения (рекомендуется false).</param>
        /// <param name="docStatusEmployees">Список сотрудников для определения виновных по конкретной строке документа
        /// (чтобы можно было открыть диалог "Определение виновников проблемы" - на кого повесить недостачу/НТВ/бой).
        /// Если данный параметр равен null, диалог будет недоступен и кнопки не будет видно.
        /// Доступность этой кнопки также определяется признаком AllowSaveFaults из общей информации о документе поштучного контроля.</param>
        public PickReturnWindow(string caption, bool alwaysAllowClose, bool isPickControlMode, Data.WH.DocStatusEmployeesDataTable docStatusEmployees)
        {
            InitializeComponent();

            this.Text = caption;
            this.UndoEnabled = false;
            this.AlwaysAllowClose = alwaysAllowClose;
            this.IsPickControlMode = isPickControlMode;
            this.DocStatusEmployees = docStatusEmployees;
            btnFaultEmployees.Enabled = btnFaultEmployees.Visible = (docStatusEmployees != null);
            btnSendToRefine.Visible = isPickControlMode && false;
            btnReworkDoc.Visible = isPickControlMode;

            lblDocType.Text = lblDocNumber.Text = lblDocDate.Text = lblNumber.Text = lblDelivery.Text = lblDeliveryDate.Text =
                lblContainer.Text = lblDepartment.Text = lblRegim.Text = tbBarcode.Text = "";
        }

        private void PickControlWindow_Load(object sender, EventArgs e)
        {
            // получаем информацию по номеру документа
            using (Data.PickControlTableAdapters.PickSlipInfoTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.PickSlipInfoTableAdapter())
            {
                try
                {
                    Data.PickControl.PickSlipInfoDataTable table = adapter.GetDataReturn(DocID);
                    if (table == null || table.Count != 1)
                        ShowError("Не найдена информация о документе!");
                    else
                    {
                        Data.PickControl.PickSlipInfoRow row = table[0];
                        _RelatedDocID = row.IsRelated_Doc_IDNull() ? (long?)null : row.Related_Doc_ID;
                        lblDocType.Text = row.IsDoc_typeNull() ? string.Empty : row.Doc_type;
                        lblDocNumber.Text = row.IsDoc_numberNull() ? string.Empty : row.Doc_number.ToString();
                        lblDocDate.Text = row.IsOrder_DateNull() ? string.Empty : row.Order_Date.ToShortDateString();
                        lblNumber.Text = row.IsPickSlipNull() ? string.Empty : row.PickSlip.ToString();
                        lblDelivery.Text = row.IsDeliveryNull() ? string.Empty : row.Delivery;
                        lblDeliveryDate.Text = row.IsDelivery_DateNull() ? string.Empty : row.Delivery_Date.ToShortDateString();
                        lblContainer.Text = row.IsConteiner_idNull() ? string.Empty : row.Conteiner_id;
                        lblDepartment.Text = row.IsOtdelNameNull() ? string.Empty : row.OtdelName;
                        lblRegim.Text = row.IsDelivery_ZoneNull() ? string.Empty : row.Delivery_Zone;
                        _allowChangeCount = row.AllowChangeCount;
                        btnFaultEmployees.Enabled = DocStatusEmployees != null && !row.IsAllowSaveFaultsNull() && row.AllowSaveFaults;
                        tbBarcode.Focus();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }

            btnSendToRefine.Enabled = false;

            RefreshLines();
        }

        private void RefreshLines()
        {
            docReturnRowsBindingSource.Filter = "";
            docReturnRowsBindingSource.Sort = "";
            docReturnRowsTableAdapter.Fill(pickControl.DocReturnRows, DocID);
        }

        private bool _allowChangeCount = false;
        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbBarcode.Text))
            {
                // разрешен ввод количества для товара, который был введен без штрих кода. Тогда по ENTER-у показываем это окно
                if (_allowChangeCount && UndoEnabled)
                {
                    SetCountForm form = new SetCountForm();
                    form.ItemID = _itemCode;
                    form.ItemName = _itemName;
                    form.Lotn = _vendorLot;
                    form.TotalCount = (int)((Data.PickControl.DocReturnRowsRow)((DataRowView)gvLines.Rows[0].DataBoundItem).Row).Doc_Qty - _count;
                    form.Count = _count;
                    form.InputCountEnabled = true; // РАЗРЕШАЕМ всегда вводить количество //(_scanType == "M");
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int cnt = form.Count;
                        if (cnt != _count)
                        {
                            _count = cnt - _count;
                            AddRow();
                        }
                        _count = cnt;
                    }
                }
            } else
                using (Data.PickControlTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.ItemsTableAdapter())
                {
                    try
                    {
                        Data.PickControl.ItemsDataTable table = adapter.GetDataReturn(DocID, tbBarcode.Text);
                        if (table == null || table.Count < 1) throw new Exception("Товар не найден! Воспользуйтесь поиском (Ctrl+F) для добавления товара без штрих кода.");
                        else if (table.Count == 1) {
                            // только один товар нашли! можем переходить к выбору серии
                            Data.PickControl.ItemsRow itemsRow = table[0];
                            _itemCode = (int)itemsRow.Item_ID;
                            _itemName = itemsRow.Item;
                            _itemUOM = itemsRow.UnitOfMeasure;
                            _count = (int)itemsRow.Qty;
                            _scanType = "B";
                            if (!itemsRow.IsVendor_LotNull() && !String.IsNullOrEmpty(itemsRow.Vendor_Lot))
                            {
                                // отсканировали уникальный штрих код ящика! Знаем даже серию!
                                _vendorLot = itemsRow.Vendor_Lot;
                                AddRow();
                            }
                            else
                            {
                                // отсканировали простой товар, идентифицировали, выбираем серию
                                ChooseSeries();
                            }
                        }
                        else {
                            // нашли несколько товаров, нужно выбрать наш
                            ChooseItems(table);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("REDFORM"))
                        {
                            FullScreenErrorForm errorForm = new FullScreenErrorForm(
                                String.Format("Товар {0}\n\rНЕ содержится\n\rв документе.\n\rОтложите товар в прозрачный ящик!\n\r(ведется видеонаблюдение)", ex.Message.Replace("REDFORM", "")),
                                "Товар возвращен в отдел.\n\rПРОДОЛЖИТЬ (Enter)", Color.Red);
                            errorForm.TimeOut = 2000;
                            errorForm.ShowDialog();
                            UndoEnabled = false;
                        } else ShowError(ex);
                    }
                }
            tbBarcode.Text = "";
        }

        // текущее значение товара
        int _itemCode = 0;
        string _itemName = "";
        string _itemUOM = "";
        int _count = 0;
        string _vendorLot = "";
        string _scanType = "X";

        /// <summary>
        /// Метод выбора товара (если количество позиций с одним штрих кодом более 1)
        /// </summary>
        private void ChooseItems(object dataTable)
        {
            if (dataTable != null && dataTable is DataTable && ((DataTable)dataTable).Rows.Count > 1)
            {
                RichListForm formItm = new RichListForm();
                //if (formItm == null)
                //{
                    #region column Item
                    DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                    colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colItem.DataPropertyName = "Item";
                    colItem.HeaderText = "Наименование";
                    colItem.Name = "colItem";
                    colItem.ReadOnly = true;
                    formItm.Columns.Add(colItem);
                    #endregion
                    #region column Manufacturer
                    DataGridViewTextBoxColumn colManuf = new DataGridViewTextBoxColumn();
                    colManuf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colManuf.DataPropertyName = "Manufacturer";
                    colManuf.HeaderText = "Производитель";
                    colManuf.Name = "colManuf";
                    colManuf.ReadOnly = true;
                    formItm.Columns.Add(colManuf);
                    #endregion

                    formItm.Text = "Выбор товара";
                    Data.PickControl.ItemsDataTable table = new WMSOffice.Data.PickControl.ItemsDataTable();
                    formItm.DataSource = table;
                    formItm.ColumnForFilters.Add("Item");
                    formItm.ColumnForFilters.Add("Manufacturer");
                    formItm.FilterVisible = false;
                    //formItems.FilterChanged += new EventHandler(formItems_FilterChanged);
                //}
                    formItm.DataSource = dataTable;

                if (formItm.ShowDialog() == DialogResult.OK)
                {
                    if (formItm.SelectedRow != null)
                    {
                        Data.PickControl.ItemsRow row = (Data.PickControl.ItemsRow)formItm.SelectedRow;

                        _itemCode = (int)row.Item_ID;
                        _itemName = row.Item;
                        _itemUOM = row.UnitOfMeasure;
                        _count = (int)row.Qty;
                        _scanType = "B";

                        ChooseSeries();
                    }
                    else UndoEnabled = false;
                }
                else UndoEnabled = false;
            }
        }


        /// <summary>
        /// Метод выбора серии (если серий больше 1)
        /// </summary>
        private void ChooseSeries()
        {
            // получаем серии
            using (Data.PickControlTableAdapters.VendorLotsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.VendorLotsTableAdapter())
            {
                try
                {
                    Data.PickControl.VendorLotsDataTable table = adapter.GetDataReturn(DocID, _itemCode, String.Empty);

                    if (table == null || table.Count < 1) throw new Exception("Серии не найдены! Это исключительная ситуация. Обратитесь в Группу сопровождения ПО.");
                    else if (table.Count == 1)
                    {
                        if (table[0].Vendor_Lot == "NOSER")
                        {
                            // контроль серий отключен
                            _vendorLot = table[0].Vendor_Lot;
                            AddRow();
                        } else 
                            // серию необходимо ввести руками
                            SetSeria();
                    }
                    //else if (table.Count == 2)
                    //{
                    //    // только одину серию, добавляем строку в документ
                    //    _vendorLot = table[0].Vendor_Lot;
                    //    AddRow();
                    //}
                    else
                    {
                        // есть несколько серий, предлагаем пользователю выбрать
                        ChooseSeries(table);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("YELLOWFORM"))
                    {
                        FullScreenErrorForm errorForm = new FullScreenErrorForm(
                            String.Format("Товар {0}\n\rНЕ содержится в документе.\n\rТовар был выбран из списка.\n\rИсправьте свой выбор (если ошиблись),\n\rиначе\n\rОтложите товар в прозрачный ящик!", ex.Message.Replace("YELLOWFORM", "")),
                            "ПРОДОЛЖИТЬ (Enter)", Color.Yellow);
                        errorForm.ShowDialog();
                        UndoEnabled = false;
                    } else
                        ShowError(ex);
                }
            }
        }

        RichListForm formSeries = null;
        private void ChooseSeries(object dataTable)
        {
            if (dataTable != null && dataTable is DataTable && ((DataTable)dataTable).Rows.Count > 1)
            {
                if (formSeries == null)
                {
                    formSeries = new RichListForm();
                    #region column Lotn
                    DataGridViewTextBoxColumn colLot = new DataGridViewTextBoxColumn();
                    colLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colLot.DataPropertyName = "Vendor_Lot";
                    colLot.HeaderText = "Серия";
                    colLot.Name = "colLot";
                    colLot.ReadOnly = true;
                    formSeries.Columns.Add(colLot);
                    #endregion
                    #region column Date
                    DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                    colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colDate.DataPropertyName = "Exp_Date";
                    colDate.HeaderText = "Срок годн.";
                    colDate.Name = "colDate";
                    colDate.ReadOnly = true;
                    formSeries.Columns.Add(colDate);
                    #endregion

                    //formSeries.FilterVisible = false;
                    formSeries.ColumnForFilters.Add("Vendor_Lot");
                    formSeries.FilterChangeLevel = 2;
                    formSeries.FilterChanged += new EventHandler(formSeries_FilterChanged);
                }
                formSeries.Text = "Выбор серии " + _itemName;
                //ListChoiceForm form = new ListChoiceForm(dataTable, "Vendor_Lot", "Vendor_Lot");
                //form.Text = "Выбор серии " + _itemName;
                //form.RememberChoiceVisible = false;
                formSeries.DataSource = dataTable;

                if (formSeries.ShowDialog() == DialogResult.OK)
                {
                    if (formSeries.SelectedRow != null)
                    {
                        Data.PickControl.VendorLotsRow row = (Data.PickControl.VendorLotsRow)formSeries.SelectedRow;
                        if (row.Vendor_Lot == "Ввести серию вручную...") SetSeria();
                        else
                        {
                            _vendorLot = row.Vendor_Lot;
                            AddRow();
                        }
                    }
                    else UndoEnabled = false;
                }
                else UndoEnabled = false;
            }
            else UndoEnabled = false;
        }

        private void formSeries_FilterChanged(object sender, EventArgs e)
        {
            using (Data.PickControlTableAdapters.VendorLotsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.VendorLotsTableAdapter())
            {
                try
                {
                    Data.PickControl.VendorLotsDataTable table = adapter.GetDataReturn(DocID, _itemCode, formSeries.Filter);
                    formSeries.DataSource = table;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void SetSeria()
        {
            SetVendorLotnForm form = new SetVendorLotnForm();
            form.Text = "Присвоение серии " + _itemName;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _vendorLot = form.Lotn;
                AddRow();
            }
            else
            {
                UndoEnabled = false;
            }
        }

        private void AddRow()
        {
            try
            {
                UndoEnabled = false;
                docReturnRowsTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalMilliseconds);
                docReturnRowsTableAdapter.Insert(DocID, _itemCode, _vendorLot, _itemUOM, _count); //, _scanType);
                UndoEnabled = true;
                RefreshLines();
                tbBarcode.Focus();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("YELLOWFORM"))
                {
                    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        String.Format("Товар {0}\n\rНЕ содержится в документе! Исправьте свой выбор.", ex.Message.Replace("YELLOWFORM", "")),
                        "ПРОДОЛЖИТЬ (Enter)", Color.Yellow);
                    errorForm.ShowDialog();
                    UndoEnabled = false;
                }
                else
                    ShowError(ex);
            }
        }

        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = miUndo.Enabled = value; }
        }

        RichListForm formItems = null;
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (formItems == null)
            {
                formItems = new RichListForm();
                #region column Item
                DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colItem.DataPropertyName = "Item";
                colItem.HeaderText = "Наименование";
                colItem.Name = "colItem";
                colItem.ReadOnly = true;
                formItems.Columns.Add(colItem);
                #endregion
                #region column Manufacturer
                DataGridViewTextBoxColumn colManuf = new DataGridViewTextBoxColumn();
                colManuf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colManuf.DataPropertyName = "Manufacturer";
                colManuf.HeaderText = "Производитель";
                colManuf.Name = "colManuf";
                colManuf.ReadOnly = true;
                formItems.Columns.Add(colManuf);
                #endregion

                formItems.Text = "Выбор товара";
                Data.PickControl.ItemsDataTable table = new WMSOffice.Data.PickControl.ItemsDataTable();
                formItems.DataSource = table;
                formItems.ColumnForFilters.Add("Item");
                formItems.ColumnForFilters.Add("Manufacturer");
                formItems.FilterChanged += new EventHandler(formItems_FilterChanged);
            }
            if (formItems.ShowDialog() == DialogResult.OK)
            {
                _itemCode = (int)((Data.PickControl.ItemsRow)formItems.SelectedRow).Item_ID;
                _itemName = ((Data.PickControl.ItemsRow)formItems.SelectedRow).Item;
                _itemUOM = ((Data.PickControl.ItemsRow)formItems.SelectedRow).UnitOfMeasure;
                _count = 1;
                _scanType = "M"; // ручной выбор товара
                // двигаемся дальше в сторону выбора серии
                ChooseSeries();
            }
            else
            {
                UndoEnabled = false;
            }
        }

        void formItems_FilterChanged(object sender, EventArgs e)
        {
            using (Data.PickControlTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.ItemsTableAdapter())
            {
                try
                {
                    Data.PickControl.ItemsDataTable table = adapter.GetDataAll(formItems.Filter);
                    formItems.DataSource = table;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (UndoEnabled)
            {
                _count = _count * -1;
                AddRow();
                UndoEnabled = false;
            }
        }

        private bool allowCloseWindow = false;
        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Control | Keys.Alt))
            {
                //btnUndoDoc_Click(sender, e);
            }
            else
            {
                // закрываем документ
                try
                {
                    var workMode = (int?)null;
                    docReturnRowsTableAdapter.CheckWorkMode(UserID, DocID, ref workMode);

                    var useNewVersion = (workMode ?? 0) == 2; // 1 - старая, 2 - новая
                    if (useNewVersion)
                    {
                        var dlgPickReturnCloseDocForm = new PickReturnCloseDocForm(DocID);

                        if (dlgPickReturnCloseDocForm.PrepareDocs())
                        {
                            if (dlgPickReturnCloseDocForm.ShowDialog() != DialogResult.OK)
                            {
                                throw new Exception("Вы отменили завершение задания поштучного контроля.");
                            }
                        }
                    }
                    else
                    {
                        var resultType = (string)null;
                        docReturnRowsTableAdapter.CheckCloseDoc(DocID, UserID, ref resultType);

                        var sscc = (string)null;

                        if ("SC".Equals(resultType, StringComparison.OrdinalIgnoreCase))
                        {
                            var dlgScanSSCC = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                            {
                                Label = "Отсканируйте SSCC\r\nдля завершения задания поштучного контроля",
                                Text = "Поштучный контроль",
                                Image = Properties.Resources.barcode
                            };

                            if (dlgScanSSCC.ShowDialog() == DialogResult.OK)
                                sscc = dlgScanSSCC.Barcode;
                            else
                                throw new Exception("Вы отменили завершение задания поштучного контроля.");
                        }

                        docReturnRowsTableAdapter.CloseDoc(DocID, sscc);
                    }

                    // закрываем окно
                    allowCloseWindow = true;
                    Close();
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.Message.Contains("REDFORM"))
                        {
                            FullScreenErrorForm errorForm = new FullScreenErrorForm(String.Format("{0}", ex.Message.Replace("REDFORM", "")), "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                            errorForm.TimeOut = 2000;
                            errorForm.ShowDialog();
                        }
                        else if (ex.Message.Contains("<SHORTAGE>"))
                        {
                            MessageBox.Show(ex.Message.Replace("<SHORTAGE>", string.Empty), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSendToRefine.Enabled = true;
                        }
                        else if (ex.Message.Contains("WHPACK#"))
                        {
                            // печать упаковочного листа
                            var regex = new System.Text.RegularExpressions.Regex(@"^#WHPACK#(?<location>.*)_(?<type>\w{2})_(?<ids>\S+)#(?<memo>\S*)#.*", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                            if (regex.IsMatch(ex.Message))
                            {
                                var match = regex.Match(ex.Message);

                                var location = match.Groups["location"].Value;
                                var docType = match.Groups["type"].Value;
                                var ids = match.Groups["ids"].Value;
                                var memoNumber = match.Groups["memo"].Value;

                                // печатаем один или несколько документов
                                foreach (var sDocID in ids.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    try
                                    {
                                        long docID;
                                        if (long.TryParse(sDocID, out docID))
                                            this.PrintPackList(docID, docType, location);
                                    }
                                    catch (Exception exl)
                                    {
                                        this.ShowError(exl);
                                    }
                                }

                                // печать служебной записки
                                if (!string.IsNullOrEmpty(memoNumber))
                                    this.PrintLogisticsComplaintsReport(memoNumber);

                                // закрываем окно
                                allowCloseWindow = true;
                                Close();
                            }
                            else
                            {
                                throw new Exception("№ упаковочного листа неопределен.");
                            }
                        }
                        else
                        {
                            ShowError(ex);
                        }
                    }
                    catch (Exception exg)
                    {
                        ShowError(exg);
                    }
                }
            }
        }

        private void PrintPackList(long docID, string docType, string locationID)
        {
            try
            {
                var receive = ApplyingOfReturnsWindow.PreparePackListReportSource(docID, docType, locationID);

                PackingListReport report = new PackingListReport();
                report.SetDataSource(receive);
                report.SetParameterValue("DocID", docID);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.Print();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "CI", 2, docID, docType, Convert.ToInt16(receive.DocLines.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void PrintLogisticsComplaintsReport(string memoNumber)
        {
            try
            {
                var complaints = new Data.Complaints();
                using (var adapter = new Data.ComplaintsTableAdapters.LogisticsComplaintsReportDataTableAdapter())
                    adapter.Fill(complaints.LogisticsComplaintsReportData, memoNumber);

                var report = new LogisticsComplaintsReport();
                report.SetDataSource((DataTable)complaints.LogisticsComplaintsReportData);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.Print();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "CI", 20, DocID, (string)null, Convert.ToInt16(complaints.LogisticsComplaintsReportData.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void PickControlWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AlwaysAllowClose && !allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения процедуры возврата товара. Пожалуйста, продолжайте работу.\n\rДля закрытия документа контроля воспользуйтесь командой \"Завершить возврат излишков\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else if (AlwaysAllowClose && !allowCloseWindow)
            {
                if (MessageBox.Show("Вы действительно хотите отменить поштучный контроль (провести его позже)?",
                    "Закрытие", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                {
                    try
                    {
                        docReturnRowsTableAdapter.CancelReturnControl(UserID, DocID);
                    }
                    catch (Exception ex)
                    {
                        ShowError("Во время отмены проведения поштучного контроля возникла следующая ошибка: " + Environment.NewLine + Environment.NewLine + ex.Message);
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            // разрисовка строк в таблице
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.PickControl.DocReturnRowsRow diffRow = (Data.PickControl.DocReturnRowsRow)((DataRowView)row.DataBoundItem).Row;

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

            if (gvLines.Rows.Count > 0)
                gvLines.Rows[0].Selected = true;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Определить виновников проблемы".
        /// </summary>
        private void btnFaultEmployees_Click(object sender, EventArgs e)
        {
            if (gvLines.SelectedRows.Count > 0)
            {
                Data.PickControl.DocReturnRowsRow selectedRow = (Data.PickControl.DocReturnRowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row;

                using (Dialogs.PickControl.ReturnFaultsForm form = new ReturnFaultsForm(DocID, selectedRow.Item_ID, selectedRow.Vendor_Lot, selectedRow.UnitOfMeasure, DocStatusEmployees))
                    form.ShowDialog();

                RefreshLines();
            }
            else
            {
                MessageBox.Show("Строка с товаром, по которому определяются виновные, не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отправить на доработку ТП
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendToRefine_Click(object sender, EventArgs e)
        {
            try
            {
                var comment = (string)null;

                using (EnterStringValueForm dlgEnterStringValue = new EnterStringValueForm("Комментарий", "Введите комментарий при отправке на доработку ТП:", string.Empty) { AllowEmptyValue = false })
                    if (dlgEnterStringValue.ShowDialog() == DialogResult.OK)
                        comment = dlgEnterStringValue.Value;

                if (!string.IsNullOrEmpty(comment))
                {
                    docReturnRowsTableAdapter.SendDocToRefine(DocID, _RelatedDocID, UserID, comment);

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
        /// Проблемный возврат «Экспедиция» (227
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReworkDoc_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgPickReturnSelectReworkReasons = new PickReturnSelectReworkReasonsForm();
                if (dlgPickReturnSelectReworkReasons.ShowDialog() == DialogResult.OK)
                {
                    using (var adapter = new Data.PickControlTableAdapters.DocReturnReworkReasonsTableAdapter())
                        adapter.Fill(pickControl.DocReturnReworkReasons);

                    docReturnRowsTableAdapter.ReworkDoc((int)DocID, UserID, dlgPickReturnSelectReworkReasons.Reason, dlgPickReturnSelectReworkReasons.ReasonID);

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
    }
}
