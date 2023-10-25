using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Window
{
    public partial class TransitDeliveryWindow : GeneralWindow
    {
        private Data.Delivery.DT_RET_TCM_Order_HeaderRow SelectedOrder { get { return xdgvOrders.SelectedItem as Data.Delivery.DT_RET_TCM_Order_HeaderRow; } }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public TransitDeliveryWindow()
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
            #region ИНИЦИАЛИЗАЦИЯ ФИЛЬТРА ДАТЫ ДОКУМЕНТА

            tsMain.Items.Insert(0, new ToolStripControlHost(pnlDocDateFilter));

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ФИЛЬТРА НОМЕРА ДОКУМЕНТА

            tsMain.Items.Insert(1, new ToolStripControlHost(pnlDocNumberFilter));

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ФИЛЬТРА СТАТУСА ДОКУМЕНТА

            tsMain.Items.Insert(2, new ToolStripControlHost(pnlDocStatusFilter));

            stbDocStatusFrom.ValueReferenceQuery = "[dbo].[pr_DT_Get_Statuses_List]";
            stbDocStatusFrom.UserID = this.UserID;
            stbDocStatusFrom.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
            //stbDocStatusFrom.SetFirstValueByDefault();
            stbDocStatusFrom.SetValueByDefault("90");

            stbDocStatusTo.ValueReferenceQuery = "[dbo].[pr_DT_Get_Statuses_List]";
            stbDocStatusTo.UserID = this.UserID;
            stbDocStatusTo.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
            //stbDocStatusTo.SetLastValueByDefault();
            stbDocStatusTo.SetValueByDefault("140");

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ПРЕДСТАВЛЕНИЯ ДОКУМЕНТОВ

            xdgvOrders.AllowSummary = false;
            xdgvOrders.UseMultiSelectMode = false;

            xdgvOrders.SetSameStyleForAlternativeRows();

            xdgvOrders.Init(new TransitDeliveryDocsView(), true);

            xdgvOrders.UserID = this.UserID;

            xdgvOrders.OnDataError += new DataGridViewDataErrorEventHandler(xdgvOrders_OnDataError);
            xdgvOrders.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvOrders_OnFormattingCell);
            xdgvOrders.OnFilterChanged += new EventHandler(xdgvOrders_OnFilterChanged);
            xdgvOrders.OnRowSelectionChanged += new EventHandler(xdgvOrders_OnRowSelectionChanged);

            #endregion

            // активация постраничного просмотра
            xdgvOrders.CreatePageNavigator();

            this.SetOperationAccess();

            this.LoadData();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox tbDescription = null;

            if (control == stbDocStatusFrom)
                tbDescription = tbDocStatusFrom;
            else if (control == stbDocStatusTo)
                tbDescription = tbDocStatusTo;

            if (tbDescription != null)
            {
                tbDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                tbDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                {
                    control.Value = e.Value;

                    //if (!string.IsNullOrEmpty(e.Value))
                    //    this.LoadData();
                }
            }
        }

        void xdgvOrders_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvOrders_OnFilterChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
            xdgvOrders.RecalculateSummary();
        }

        void xdgvOrders_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                var grid = sender as DataGridView;

                var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;
                var color = Color.FromName(boundRow["Color"].ToString());

                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
            }
            catch
            {

            }
        }

        void xdgvOrders_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
            this.LoadDetails();
        }

        private void LoadDetails()
        {
            try
            {
                var orderID = this.SelectedOrder != null ? this.SelectedOrder.Order_ID : (long?)null;
                var boxUID = this.SelectedOrder != null ? !this.SelectedOrder.IsBar_CodeNull() ? this.SelectedOrder.Bar_Code : (Guid?)null : (Guid?)null;

                using (var adapter = new Data.DeliveryTableAdapters.DT_RET_TCM_Order_DetailsTableAdapter())
                    adapter.Fill(delivery.DT_RET_TCM_Order_Details, this.UserID, orderID, boxUID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.LoadData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetOperationAccess()
        {
            try
            {
                var isEnabled = this.SelectedOrder != null;

                btnPrintEtic.Enabled = isEnabled;

                var isRepeatDeliveryEnabled = isEnabled && !this.SelectedOrder.IsIsRepeatDeliveryNull() && this.SelectedOrder.IsRepeatDelivery;
                btnRepeatDelivery.Enabled = isRepeatDeliveryEnabled;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            try
            {
                var searchParams = new TransitDeliveryDocsSearchParameters() { SessionID = this.UserID };

                if (dtpDocDateFrom.Checked && dtpDocDateTo.Checked && dtpDocDateFrom.Value.Date > dtpDocDateTo.Value.Date)
                    throw new Exception("Начальный период не должен превышать конечный.");
                else
                {
                    if (dtpDocDateFrom.Checked)
                        searchParams.DocDateFrom = dtpDocDateFrom.Value.Date;

                    if (dtpDocDateTo.Checked)
                        searchParams.DocDateTo = dtpDocDateTo.Value.Date;
                }

               
                if (!string.IsNullOrEmpty(tbDocNumber.Text))
                {
                    long docNumber;
                    if (!long.TryParse(tbDocNumber.Text, out docNumber))
                        throw new Exception("Номер док-та должен быть числом.");
                    else
                        searchParams.DocNumber = docNumber;
                }

                if (!string.IsNullOrEmpty(stbDocStatusFrom.Value))
                {
                    int statusFrom;
                    if (!int.TryParse(stbDocStatusFrom.Value, out statusFrom))
                        throw new Exception("Начальный статус док-та должен быть числом.");
                    else
                        searchParams.DocStatusFrom = statusFrom.ToString();
                }

                if (!string.IsNullOrEmpty(stbDocStatusTo.Value))
                {
                    int statusTo;
                    if (!int.TryParse(stbDocStatusTo.Value, out statusTo))
                        throw new Exception("Конечный статус док-та должен быть числом.");
                    else
                        searchParams.DocStatusTo = statusTo.ToString();
                }

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvOrders.DataView.FillData(e.Argument as TransitDeliveryDocsSearchParameters);
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

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvOrders.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение заказов..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPrintEtic_Click(object sender, EventArgs e)
        {
            this.PrintEtic();
        }

        private void PrintEtic()
        {
            try
            {
                var dlgPrinterSelector = new SearchTextBoxSelector("[dbo].[pr_DT_RET_TCM_Get_Printer]", new List<ReferencedObject>());
                dlgPrinterSelector.UserID = UserID;

                if (dlgPrinterSelector.ShowDialog() != DialogResult.OK)
                    return;

                var printer = dlgPrinterSelector.SelectedItem;
                var printerAlias = printer["Printer_Alias"].ToString();

                var order = xdgvOrders.SelectedItem as Data.Delivery.DT_RET_TCM_Order_HeaderRow;
                var orderID = order.Order_ID;

                var boxUID = order.IsBar_CodeNull() ? (Guid?)null : order.Bar_Code;

                using (var adapter = new Data.DeliveryTableAdapters.DT_RET_TCM_Order_HeaderTableAdapter())
                    adapter.PrintOrderEtic(this.UserID, orderID, boxUID, printerAlias);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.Export();
        }

        private void Export()
        {
            try
            {
                xdgvOrders.ExportToExcel("Экспорт заказов", "Заказы по транзитной доставке", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnRepeatDelivery_Click(object sender, EventArgs e)
        {
            this.RepeatDelivery();
        }

        private void RepeatDelivery()
        {
            try
            {
                var orderID = SelectedOrder.Order_ID;

                using (var form = new EnterStringValueForm("Подтверждение необходимости повторной доставки", "Укажите причину повторной доставки:", string.Empty) { AllowEmptyValue = false, Width = 370 })
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        using (var adapter = new Data.DeliveryTableAdapters.DT_RET_TCM_Order_HeaderTableAdapter())
                            adapter.RepeatOrderDelivery(this.UserID, orderID, form.Value);

                        MessageBox.Show("Повторная доставка подтверждена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для документов по транзитной доставке
    /// </summary>
    public class TransitDeliveryDocsView : IDataView
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
            var searchCriteria = searchParameters as TransitDeliveryDocsSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var docDateFrom = searchCriteria.DocDateFrom;
            var docDateTo = searchCriteria.DocDateTo;
            var docNumber = searchCriteria.DocNumber;
            var docStatusFrom = searchCriteria.DocStatusFrom;
            var docStatusTo = searchCriteria.DocStatusTo;

            using (var adapter = new Data.DeliveryTableAdapters.DT_RET_TCM_Order_HeaderTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, docNumber, docDateFrom, docDateTo, docStatusFrom, docStatusTo);
            }
        }

        #endregion

        public TransitDeliveryDocsView()
        {
            this.dataColumns.Add(new PatternColumn("№ заказа", "Order_ID", new FilterCompareExpressionRule<Int64>("Order_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Дата заказа", "Order_Date", new FilterDateCompareExpressionRule("Order_Date")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Склад отправителя", "Sender_WH_ID", new FilterPatternExpressionRule("Sender_WH_ID"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дебитор отправителя", "Sender_Debtor", new FilterPatternExpressionRule("Sender_Debtor"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Адрес отправителя", "Sender_Address", new FilterPatternExpressionRule("Sender_Address"), SummaryCalculationType.Count) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Маршрут отправителя", "Sender_Route", new FilterPatternExpressionRule("Sender_Route"), SummaryCalculationType.Count) { Width = 80 });

            this.dataColumns.Add(new PatternColumn("Склад получателя", "Receiver_WH_ID", new FilterPatternExpressionRule("Receiver_WH_ID"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дебитор получателя", "Receiver_Debtor", new FilterPatternExpressionRule("Receiver_Debtor"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Адрес получателя", "Receiver_Address", new FilterPatternExpressionRule("Receiver_Address"), SummaryCalculationType.Count) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Маршрут получателя", "Receiver_Route", new FilterPatternExpressionRule("Receiver_Route"), SummaryCalculationType.Count) { Width = 80 });

            this.dataColumns.Add(new PatternColumn("№ задания", "Route_Task", new FilterPatternExpressionRule("Route_Task"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Статус заказа", "Status_Name", new FilterPatternExpressionRule("Status_Name"), SummaryCalculationType.Count) { Width = 250 });

            //this.dataColumns.Add(new PatternColumn("№ МЛ заб.", "Route_From", new FilterPatternExpressionRule("Route_From"), SummaryCalculationType.Count) { Width = 100 });
            //this.dataColumns.Add(new PatternColumn("№ МЛ дост.", "Route_To", new FilterPatternExpressionRule("Route_To"), SummaryCalculationType.Count) { Width = 100 });
           
            this.dataColumns.Add(new PatternColumn("№ ТТН заб.", "TTN_From", new FilterPatternExpressionRule("TTN_From"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("№ ТТН дост.", "TTN_To", new FilterPatternExpressionRule("TTN_To"), SummaryCalculationType.Count) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("№ акта", "Act_1C", new FilterPatternExpressionRule("Act_1C"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата акта", "DateAct_1C", new FilterDateCompareExpressionRule("DateAct_1C"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата счета", "DateInvoice", new FilterDateCompareExpressionRule("DateInvoice"), SummaryCalculationType.Count) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Статус оплаты", "Payment_State", new FilterPatternExpressionRule("Payment_State"), SummaryCalculationType.Count) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Дата оплаты план", "PaymentDate_Plan", new FilterDateCompareExpressionRule("PaymentDate_Plan"), SummaryCalculationType.Count) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Дата оплаты факт", "PaymentDate_Actual", new FilterDateCompareExpressionRule("PaymentDate_Actual"), SummaryCalculationType.Count) { Width = 130 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class TransitDeliveryDocsSearchParameters : SessionIDSearchParameters
    {
        public DateTime? DocDateFrom { get; set; }
        public DateTime? DocDateTo { get; set; }
        public long? DocNumber { get; set; }
        public string DocStatusFrom { get; set; }
        public string DocStatusTo { get; set; }

        public TransitDeliveryDocsSearchParameters()
        {
            this.DocStatusFrom = (string)null;
            this.DocStatusTo = (string)null;
        }
    }
}
