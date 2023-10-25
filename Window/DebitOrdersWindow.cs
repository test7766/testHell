using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;
using WMSOffice.Dialogs.WH;
using WMSOffice.Classes;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Reports;

namespace WMSOffice.Window
{
    public partial class DebitOrdersWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Data.WH.PurchaseOrdersForDebitRow SelectedOrder { 
            get { return xdgvOrders.SelectedItem as Data.WH.PurchaseOrdersForDebitRow; } }

        private int? selectedOrderID = (int?)null;
        private string selectedOrderType = (string)null;

        public DebitOrdersWindow()
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
            #region ИНИЦИАЛИЗАЦИЯ ПРИНТЕРОВ

            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);

            #endregion

            this.ShowExtraSearchParameters(false);

            stbVendor.ValueReferenceQuery = "[dbo].[pr_DG_Get_Vendors_List]";
            stbVendor.UserID = this.UserID;
            stbVendor.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbStatusFrom.ValueReferenceQuery = "[dbo].[pr_DG_Get_Statuses_List]";
            stbStatusFrom.UserID = this.UserID;
            stbStatusFrom.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbStatusFrom.SetFirstValueByDefault();

            stbStatusTo.ValueReferenceQuery = "[dbo].[pr_DG_Get_Statuses_List]";
            stbStatusTo.UserID = this.UserID;
            stbStatusTo.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbStatusTo.SetValueByDefault("260");

            stbOrderType.ValueReferenceQuery = "[dbo].[pr_DG_Get_Purch_Order_Types_List]";
            stbOrderType.UserID = this.UserID;
            stbOrderType.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbItem.ValueReferenceQuery = "[dbo].[pr_DG_Get_Items_List]";
            stbItem.ApplyAdditionalParameter("ITM_NAME", string.Empty);
            stbItem.UserID = this.UserID;
            stbItem.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbBatch.ValueReferenceQuery = "[dbo].[pr_DG_Get_Batches_List]";
            stbBatch.ApplyAdditionalParameter("itemID", string.Empty);
            stbBatch.UserID = this.UserID;
            stbBatch.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            xdgvOrders.AllowSummary = false;
            xdgvOrders.AllowRangeColumns = true;

            xdgvOrders.UseMultiSelectMode = false;

            xdgvOrders.Init(new DebitOrdersView(), true);
            xdgvOrders.LoadExtraDataGridViewSettings(this.Name);

            xdgvOrders.UserID = this.UserID;

            xdgvOrders.OnDataError += new DataGridViewDataErrorEventHandler(xdgvOrders_OnDataError);
            xdgvOrders.OnRowSelectionChanged += new EventHandler(xdgvOrders_OnRowSelectionChanged);
            xdgvOrders.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvOrders_OnRowDoubleClick);
            xdgvOrders.OnFilterChanged += new EventHandler(xdgvOrders_OnFilterChanged);
            xdgvOrders.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvOrders_OnDataBindingComplete);
            xdgvOrders.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvOrders_OnFormattingCell);

            // активация постраничного просмотра
            xdgvOrders.CreatePageNavigator();

            SetOperationAccess();

            LoadOrders();
        }

        void stbVendor_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbVendor)
                lblDescription = tbVendor;
            else if (control == stbStatusFrom)
                lblDescription = tbStatusFrom;
            else if (control == stbStatusTo)
                lblDescription = tbStatusTo;
            else if (control == stbOrderType)
                lblDescription = tbOrderType;
            else if (control == stbItem)
                lblDescription = tbItem;
            else if (control == stbBatch)
                lblDescription = tbBatch;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (control == stbItem)
                {
                    stbBatch.ApplyAdditionalParameter("itemID", e.Value);
                }

                // Настройка сброса зависимой сущности при смене независимой (при смене товара сбрасывается партия)
                //// TODO реализовать автоматически через Binding
                if (control == stbItem)
                {
                    stbBatch.SetValueByDefault(string.Empty);
                }

                // Зачистка "быстрого" фильтра товара
                if (control == stbItem)
                {
                    if (e.Success && string.IsNullOrEmpty(e.Value))
                        tbQFilterItem.Clear();
                }

                if (e.Success)
                {
                    control.Value = e.Value;

                    //if (!string.IsNullOrEmpty(e.Value))
                    //    this.LoadOrders();
                }
            }

            //if (lblDescription != null)
            //{
            //    try
            //    {
            //        if (!e.Success)
            //            throw new Exception("Значение не найдено!");

            //        if (control == stbItem)
            //        {
            //            stbBatch.ApplyAdditionalParameter("itemID", e.Value);
            //        }

            //        //// Настройка сброса зависимой сущности при смене независимой (при смене товара сбрасывается партия)
            //        //// TODO реализовать автоматически через Binding
            //        if (control == stbItem)
            //        {
            //            stbBatch.SetValueByDefault(string.Empty);
            //        }

            //        lblDescription.Text = e.Success ? e.Description : string.Empty;
            //        lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

            //        if (e.Success)
            //            control.Value = e.Value;
            //        //else
            //        //    control.Value = string.Empty;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        control.SetValueByDefault(string.Empty);
            //        control.Focus();
            //    }
            //}
        }

        void xdgvOrders_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvOrders_OnRowSelectionChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
        }

        void xdgvOrders_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DebitOrder();
        }

        private void DebitOrder()
        {
            try
            {
                if (!btnDebitOrder.Enabled)
                    return;

                var dlgDebitOrder = new DebitOrderForm(this.SelectedOrder) { UserID = this.UserID };
                if (dlgDebitOrder.ShowDialog() == DialogResult.OK)
                    this.LoadOrders();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        void xdgvOrders_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            xdgvOrders.RecalculateSummary();
        }

        void xdgvOrders_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Восстанавливаем фокус
            if (selectedOrderID.HasValue && !string.IsNullOrEmpty(selectedOrderType))
            {
                xdgvOrders.SelectRow("OrderNumber", selectedOrderID.ToString(), "OrderType", selectedOrderType);
                xdgvOrders.ScrollToSelectedRow();
            }
        }

        void xdgvOrders_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var doc = (xdgvOrders.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrdersForDebitRow;
           
            var inProcess = doc.IsInProcessNull() ? false : doc.InProcess;
            //var color = inProcess ? Color.LightGray : SystemColors.Window;

            var color = doc.IsColorNull() ? SystemColors.Window : Color.FromName(doc.Color);

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                LoadOrders();
                return true;
            }

            if (keyData == (Keys.F3))
            {
                DebitOrder();
                return true;
            }

            if (keyData == (Keys.F7))
            {
                ChangeOrderCurrency();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                ReprintAcceptanceCertificate();
                return true;
            }

            if (keyData == (Keys.Control | Keys.O))
            {
                PreviewAcceptanceCertificate();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Z))
            {
                ReverseOrder();
                return true;
            }

            if (keyData == (Keys.F9))
            {
                ApproveShipment();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                var searchParams = new DebitOrdersViewSearchParameters() { SessionID = this.UserID };

                if (!string.IsNullOrEmpty(stbVendor.Value))
                {
                    int vendorID;
                    if (!int.TryParse(stbVendor.Value, out vendorID))
                        throw new Exception("Код поставщика должен быть числом.");
                    else
                        searchParams.VendorID = vendorID;
                }

                if (!string.IsNullOrEmpty(stbStatusFrom.Value))
                {
                    int statusFrom;
                    if (!int.TryParse(stbStatusFrom.Value, out statusFrom))
                        throw new Exception("Код статуса с должен быть числом.");
                    else
                        searchParams.StatusFrom = statusFrom;
                }

                if (!string.IsNullOrEmpty(stbStatusTo.Value))
                {
                    int statusTo;
                    if (!int.TryParse(stbStatusTo.Value, out statusTo))
                        throw new Exception("Код статуса по должен быть числом.");
                    else
                        searchParams.StatusTo = statusTo;
                }

                if (!string.IsNullOrEmpty(stbOrderType.Value))
                    searchParams.OrderType = stbOrderType.Value;

                if (!string.IsNullOrEmpty(tbOrderNumber.Text))
                {
                    int orderNumber;
                    if (!int.TryParse(tbOrderNumber.Text, out orderNumber))
                        throw new Exception("№ заказа должен быть числом.");
                    else
                        searchParams.OrderNumber = orderNumber;
                }

                if (dtpOrderDate.Checked)
                {
                    searchParams.OrderDate = dtpOrderDate.Value.Date;
                }

                if (!string.IsNullOrEmpty(stbItem.Value))
                {
                    int itemID;
                    if (!int.TryParse(stbItem.Value, out itemID))
                        throw new Exception("Код товара должен быть числом.");
                    else
                        searchParams.ItemID = itemID;
                }

                if (!string.IsNullOrEmpty(stbBatch.Value))
                    searchParams.BatchID = stbBatch.Value;
                else
                    if (!string.IsNullOrEmpty(stbItem.Value))
                        throw new Exception("Не указана партия.");

                // Необходимая проверка при поиске в архиве
                var archiveStatus = 999;
                if ((archiveStatus.Equals(searchParams.StatusFrom) || archiveStatus.Equals(searchParams.StatusTo)) && !searchParams.OrderNumber.HasValue && !searchParams.OrderDate.HasValue && !searchParams.ItemID.HasValue && string.IsNullOrEmpty(searchParams.BatchID))
                    throw new Exception("При поиске в архиве необходимо указать\nлибо № либо дату заказа либо товар с партией.");

                // Запоминаем фокус
                selectedOrderID = this.SelectedOrder == null ? 0 : SelectedOrder.OrderNumber;
                selectedOrderType = this.SelectedOrder == null ? "" : SelectedOrder.OrderType;


                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvOrders.DataView.FillData(e.Argument as DebitOrdersViewSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvOrders.BindData(false);

                        //this.xdgvOrders.AllowFilter = true;
                        this.xdgvOrders.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение\nсписка заказов..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void SetOperationAccess()
        {
            var isEnabled = this.SelectedOrder != null;

            btnDebitOrder.Enabled = isEnabled;
            btnChangeOrderCurrency.Enabled = isEnabled && this.SelectedOrder.OrderType.Equals("90") && this.SelectedOrder.Status.Equals("235");
            btnReprintAcceptanceCertificate.Enabled = isEnabled && this.SelectedOrder.Status.Equals("999");
            btnPreviewAcceptanceCertificate.Enabled = isEnabled && this.SelectedOrder.Status.Equals("999");
            btnReverseOrder.Enabled = isEnabled && this.SelectedOrder.Status.Equals("999");
            btnApproveShipment.Enabled = isEnabled && !this.SelectedOrder.IsShipmentIDNull() && this.SelectedOrder.Status.Equals("248");
        }

        private void btnDebitOrder_Click(object sender, EventArgs e)
        {
            this.DebitOrder();
        }

        private void cbUseExtraSearch_CheckedChanged(object sender, EventArgs e)
        {
            ShowExtraSearchParameters(cbUseExtraSearch.Checked);
        }

        private void lblUseExtraSearch_Click(object sender, EventArgs e)
        {
            if (cbUseExtraSearch.Enabled)
                cbUseExtraSearch.Checked = !cbUseExtraSearch.Checked;
        }

        private void ShowExtraSearchParameters(bool visible)
        {
            if (pnlExtraSearch.Visible == visible)
                return;

            pnlExtraSearch.Visible = visible;

            if (visible)
            {
                pnlSearch.Height += pnlExtraSearch.Height;
                this.SelectNextControl(cbUseExtraSearch, true, true, true, false);
            }
            else
            {
                pnlSearch.Height -= pnlExtraSearch.Height;
            }

            // Очищаем дополнительные параметры поиска
            stbOrderType.SetValueByDefault(string.Empty);
            tbOrderNumber.Clear();
            dtpOrderDate.Value = DateTime.Today;
            dtpOrderDate.Checked = false;
            stbItem.SetValueByDefault(string.Empty);
            stbBatch.SetValueByDefault(string.Empty);
        }

        private void DebitOrdersWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                xdgvOrders.SaveExtraDataGridViewSettings(this.Name);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnChangeOrderCurrency_Click(object sender, EventArgs e)
        {
            this.ChangeOrderCurrency();
        }

        private void ChangeOrderCurrency()
        {
            try
            {
                if (!btnChangeOrderCurrency.Enabled)
                    return;

                var dlgChangeOrderCurrency = new ChangeOrderCurrencyForm(this.SelectedOrder) { UserID = this.UserID };
                if (dlgChangeOrderCurrency.ShowDialog() == DialogResult.OK)
                    this.LoadOrders();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnReprintAcceptanceCertificate_Click(object sender, EventArgs e)
        {
            this.ReprintAcceptanceCertificate();
        }

        private void ReprintAcceptanceCertificate()
        {
            try
            {
                if (!btnReprintAcceptanceCertificate.Enabled)
                    return;

                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.ReprintDoc(this.UserID, this.SelectedOrder.OrderNumber, this.SelectedOrder.OrderType, cmbPrinters.Text);

                MessageBox.Show("Создано задание повторной печати акта.", "Повторная печать акта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPreviewAcceptanceCertificate_Click(object sender, EventArgs e)
        {
            this.PreviewAcceptanceCertificate();   
        }

        private void PreviewAcceptanceCertificate()
        {
            try
            {
                if (!btnPreviewAcceptanceCertificate.Enabled)
                    return;

                var docID = Convert.ToInt64(this.SelectedOrder.OrderNumber);
                var docType = this.SelectedOrder.OrderType;

                var data = new Data.WH();

                this.SertDocPrepare(data, docID, docType);

                // напечатаем акт приемки
                using (var report = this.CreateSertReport())
                {
                    report.SetDataSource(data);

                    using (var form = new WMSOffice.Dialogs.ReportForm() { Text = "Приходная накладная" })
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "DG", 30, docID, docType, Convert.ToInt16(data.PurchaseOrderForDebit_Cert_DocRows.Count), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private ReportClass CreateSertReport()
        {
            var report = new PurchaseOrderForDebitAcceptanceCertificateReport();
            return report;
        }

        private void SertDocPrepare(Data.WH data, long docID, string docType)
        {
            using (var adapter = new Data.WHTableAdapters.PurchaseOrderForDebit_Cert_DocHeaderTableAdapter())
                adapter.Fill(data.PurchaseOrderForDebit_Cert_DocHeader, docID, docType);

            using (var adapter = new Data.WHTableAdapters.PurchaseOrderForDebit_Cert_DocRowsTableAdapter())
                adapter.Fill(data.PurchaseOrderForDebit_Cert_DocRows, docID, docType);

            //PrepareBarcode(data);
            PrepareQR(data);
        }

        /// <summary>
        /// Подготовка ш/к документа
        /// </summary>
        /// <param name="data"></param>
        private void PrepareBarcode(Data.WH data)
        {
            if (data.PurchaseOrderForDebit_Cert_DocHeader.Count > 0)
            {
                foreach (Data.WH.PurchaseOrderForDebit_Cert_DocHeaderRow header in data.PurchaseOrderForDebit_Cert_DocHeader.Rows)
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
                    barCodeCtrl.BarCode = header.InvoiceBar;

                    byte[] barCode = null;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        barCode = ms.ToArray();
                    }

                    header.InvoiceBarBin = barCode;
                }
            }
        }

        /// <summary>
        /// Подготовка QR документа
        /// </summary>
        /// <param name="data"></param>
        private void PrepareQR(Data.WH data)
        {
            if (data.PurchaseOrderForDebit_Cert_DocHeader.Count > 0)
            {
                foreach (Data.WH.PurchaseOrderForDebit_Cert_DocHeaderRow header in data.PurchaseOrderForDebit_Cert_DocHeader.Rows)
                {
                    // создание изображения QR-кода
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
#if qrcoder
                    var qrImage = QRCoder.QRCodeHelper.GetQRCode(header.InvoiceBar, 4, Color.Black, Color.White, QRCoder.QRCodeGenerator.ECCLevel.H, true, true, QRCoder.QRCodeGenerator.EciMode.Utf8, 1, null, 0, 0, true);
#else
                        Zen.Barcode.CodeQrBarcodeDraw qrDrawTool = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                        var qrImage = qrDrawTool.Draw(header.InvoiceBar, 100, 2);
#endif

                        qrImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                        header.InvoiceBarBin = ms.ToArray();
                    }
                }
            }
        }

        private void btnReverseOrder_Click(object sender, EventArgs e)
        {
            this.ReverseOrder();
        }

        private void ReverseOrder()
        {
            try
            {
                if (!btnReverseOrder.Enabled)
                    return;

                var canReverse = (bool?)null;
                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.CheckReverseAccess(this.UserID, this.SelectedOrder.OrderNumber, this.SelectedOrder.OrderType, ref canReverse);

                if (!(canReverse ?? false))
                    throw new Exception("Невозможно сторнировать заказ.");

                var dlgDebitOrder = new ReverseOrderForm(this.SelectedOrder) { UserID = this.UserID };
                if (dlgDebitOrder.ShowDialog() == DialogResult.OK)
                    this.LoadOrders();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnApproveShipment_Click(object sender, EventArgs e)
        {
            this.ApproveShipment();
        }

        private void ApproveShipment()
        {
            try
            {
                if (!btnApproveShipment.Enabled)
                    return;

                var dlgApproveOrderShipment = new ApproveOrderShipmentForm(this.SelectedOrder) { UserID = this.UserID };
                if (dlgApproveOrderShipment.ShowDialog() == DialogResult.OK)
                    this.LoadOrders();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void tbQFilterItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbQFilterItem_Leave(sender, EventArgs.Empty);
        }

        private void tbQFilterItem_Leave(object sender, EventArgs e)
        {
            stbItem.ApplyAdditionalParameter("ITM_NAME", tbQFilterItem.Text);
            if (!string.IsNullOrEmpty(tbQFilterItem.Text.Trim()) && tbQFilterItem.Text.Trim().Length >= 3)
                stbItem.VerifyValue(true, AutoSelectItemSideMode.None);
        }
    }

    /// <summary>
    /// Представление для заказов на DOCK
    /// </summary>
    public class DebitOrdersView : IDataView
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
            var searchCriteria = searchParameters as DebitOrdersViewSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var vendorID = searchCriteria.VendorID;
            var statusFrom = searchCriteria.StatusFrom;
            var statusTo= searchCriteria.StatusTo;
            var orderType = searchCriteria.OrderType;
            var orderNumber = searchCriteria.OrderNumber;
            var orderDate = searchCriteria.OrderDate;
            var itemID = searchCriteria.ItemID;
            var batchID = searchCriteria.BatchID;

            using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, vendorID, statusFrom, statusTo, orderType, orderNumber, orderDate, itemID, batchID);
            }
        }

        #endregion

        public DebitOrdersView()
        {
            this.dataColumns.Add(new PatternColumn("№ заказа", "OrderNumber", new FilterCompareExpressionRule<Int32>("OrderNumber"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Тип заказа", "OrderType", new FilterPatternExpressionRule("OrderType"), SummaryCalculationType.Count) { Width = 70 });

            this.dataColumns.Add(new PatternColumn("Код пост.", "SuplierCod", new FilterCompareExpressionRule<Int32>("SuplierCod"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Наименование поставщика", "Suplier", new FilterPatternExpressionRule("Suplier")) { Width = 300 });

            this.dataColumns.Add(new PatternColumn("Статус", "Status", new FilterCompareExpressionRule<Int32>("Status"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Название статуса", "StatusName", new FilterPatternExpressionRule("StatusName")) { Width = 300 });

            this.dataColumns.Add(new PatternColumn("Блок", "Hold", new FilterPatternExpressionRule("Hold"), SummaryCalculationType.Count) { Width = 50 });

            this.dataColumns.Add(new PatternColumn("Усл. опл.", "PaymentTerm", new FilterPatternExpressionRule("PaymentTerm"), SummaryCalculationType.Count) { Width = 40 });
            this.dataColumns.Add(new PatternColumn("Валюта", "CurrencyCode", new FilterPatternExpressionRule("CurrencyCode"), SummaryCalculationType.Count) { Width = 50 });

            this.dataColumns.Add(new PatternColumn("Сумма в гривне", "AmountUAH", new FilterCompareExpressionRule<Decimal>("AmountUAH"), SummaryCalculationType.Sum) { Width = 120, UseDecimalNumbersAlignment = true, Format = "N4" });

            this.dataColumns.Add(new PatternColumn("№ счет-фактуры", "InvoiceNumber", new FilterPatternExpressionRule("InvoiceNumber")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Дата счет-фактуры", "InvoiceDate", new FilterPatternExpressionRule("InvoiceDate")) { Width = 90 });

            this.dataColumns.Add(new PatternColumn("Код получ.", "ShipTo", new FilterCompareExpressionRule<Int32>("ShipTo"), SummaryCalculationType.Count) { Width = 50 });

            this.dataColumns.Add(new PatternColumn("Сумма в валюте", "ForeignAmount", new FilterCompareExpressionRule<Decimal>("ForeignAmount"), SummaryCalculationType.Sum) { Width = 120, UseDecimalNumbersAlignment = true, Format = "N4" });

            this.dataColumns.Add(new PatternColumn("Дата заказа", "OrderDate", new FilterDateCompareExpressionRule("OrderDate"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Дата доставки", "DeliveryDate", new FilterDateCompareExpressionRule("DeliveryDate"), SummaryCalculationType.Count) { Width = 90 });

            this.dataColumns.Add(new PatternColumn("Курс валюты", "ExchangeRate", new FilterCompareExpressionRule<Double>("ExchangeRate"), SummaryCalculationType.None) { Width = 100, UseDecimalNumbersAlignment = true, Format = "N4" });

            this.dataColumns.Add(new PatternColumn("№ поставки", "ShipmentID", new FilterCompareExpressionRule<Int64>("ShipmentID"), SummaryCalculationType.Count) { Width = 70 });

            this.dataColumns.Add(new PatternColumn("НП", "NP", new FilterPatternExpressionRule("NP"), SummaryCalculationType.Count) { Width = 40 });
            this.dataColumns.Add(new PatternColumn("ТТН\nНовой Почты", "NP_Number", new FilterPatternExpressionRule("NP_Number")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("ЭДО", "EDI", new FilterPatternExpressionRule("EDI"), SummaryCalculationType.Count) { Width = 40 });

            this.dataColumns.Add(new PatternColumn("Дата прихода", "ReceiptDate", new FilterDateCompareExpressionRule("ReceiptDate"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Оприходовано кем", "ReceiptUser", new FilterPatternExpressionRule("ReceiptUser")) { Width = 200 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class DebitOrdersViewSearchParameters : SessionIDSearchParameters
    {
        public int? VendorID { get; set; }
        public int? StatusFrom { get; set; }
        public int? StatusTo { get; set; }
        public string OrderType { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ItemID { get; set; }
        public string BatchID { get; set; }
    }
}
