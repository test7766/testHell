using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Delivery;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Dialogs.ColdChain;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Globalization;
using System.Threading;

namespace WMSOffice.Window
{
    public partial class DeliveryPackingWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        private CultureInfo previousCultureInfo = null;

        #endregion

        public DeliveryPackingWindow()
        {
            InitializeComponent();

            var cultureInfo = (CultureInfo)(previousCultureInfo = Thread.CurrentThread.CurrentCulture).Clone();
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            Thread.CurrentThread.CurrentCulture = cultureInfo;

            UndoEnabled = false;
            RefreshHeader();
        }

        private void RefreshHeader()
        {
            if (delivery.BarcodeInfo.Count > 0)
            {
                Data.Delivery.BarcodeInfoRow info = delivery.BarcodeInfo[0];
                lblNumber.Text = info.PickSlip.ToString();
                lblDepartment.Text = info.OtdelName;
                lblDocNumber.Text = info.DocNumber.ToString();
                lblDocType.Text = info.DocType;
                lblRegim.Text = info.ZoneName;
                lblDeliveryDate.Text = info.DeliveryDate.ToShortDateString();
                lblRouteList.Text = info.Route_List_Number.ToString();
                lblCar.Text = info.Car_Number;
                lblPlaceWork.Text = info.PlaceWork.ToString();
                lblPlaceTotal.Text = info.PlaceTotal.ToString();
                lblPSNWork.Text = info.PSN_Work.ToString();
                lblPSNTotal.Text = info.PSN_Total.ToString();
                lblDelivery.Text = info.ClientName;
                lblAddress.Text = info.ClientAddress;
                lblPerron.Text = info.Peron_ID.ToString();
                lblTermobox.Text = (!info.IsTermoBox_IDNull() && !String.IsNullOrEmpty(info.TermoBox_ID)) ?
                    "Погрузить товар в контейнер №" + info.TermoBox_ID : String.Empty;
                tbBarcode.Text = String.Empty;
                UndoEnabled = lblPlaceWork.Text != lblPlaceTotal.Text;
                long.TryParse(lblPerron.Text, out currentPerronID);
                double.TryParse(lblNumber.Text, out currentPSN);
            }
            else
            {
                lblNumber.Text = lblDepartment.Text = lblDocNumber.Text = lblDocType.Text =
                    lblRegim.Text = lblDeliveryDate.Text = lblRouteList.Text = lblCar.Text =
                    lblPlaceWork.Text = lblPlaceTotal.Text = lblPSNWork.Text = lblPSNTotal.Text =
                    lblDelivery.Text = lblAddress.Text = lblPerron.Text = tbBarcode.Text = "";
            }
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
                try
                {
                    AddRow(tbBarcode.Text);
                    CheckTermoBoxSensor(); // выполняем проверку необходимости сохранять данные дата-логгера 
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            tbBarcode.Text = "";
        }

        private void AddRow(string barcode)
        {
            try
            {
                barcodeInfoBindingSource.Filter = string.Empty;
                barcodeInfoBindingSource.Sort = string.Empty;

                barcodeInfoTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                barcodeInfoTableAdapter.Fill(delivery.BarcodeInfo, UserID, barcode); // добавляем ящик в документ...

                // TODO тестовый сценарий для считывания показателей с дата-логгера
                // barcodeInfoTableAdapter.Fill(delivery.BarcodeInfo, (UserID = 256), (barcode = "1")); 
      
                RefreshHeader(); // обновляем информацию
                // upd 19.12.2012 RefreshLines(); // обновляем строки

            } catch (Exception ex)
            {
                if (ex.Message.Contains("REDFORM"))
                {
                    FullScreenErrorForm errorForm = new FullScreenErrorForm(
                        String.Format("{0}", ex.Message.Replace("REDFORM", "")),
                        "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                    errorForm.TimeOut = 2000;
                    errorForm.ShowDialog();
                }
                else
                    ShowError(ex);
            }
        }

        /// <summary>
        /// Сохранение данных дата-логгера
        /// </summary>
        private void CheckTermoBoxSensor()
        {
            // Если место из термобокса является последним
            if (delivery.BarcodeInfo.Count > 0 && delivery.BarcodeInfo[0].PSN_Last == 1)
                new Dialogs.ColdChain.DataLoggerSaveForm() 
                { 
                    UserID = this.UserID, 
                    DiscardCanceling = true,
                    EquipmentID = null,
                    StartTimeStamp = delivery.BarcodeInfo[0].Date_From,
                    EndTimeStamp = delivery.BarcodeInfo[0].Date_To
                }.ShowDialog();  
        }

        private long currentPerronID;
        private double currentPSN;

        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = miUndo.Enabled = value; }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblPerron.Text))
            {
                try
                {
                    if (MessageBox.Show(String.Format("Вы действительно хотите отменить комплектацию текущего сборочного: {0}.\n\rВсе места этого сборочного необходимо вернуть с перрона {1} на стол комплектации!", currentPSN, currentPerronID), "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var adapter = new Data.DeliveryTableAdapters.DocsTableAdapter())
                            adapter.CancelPSN(currentPerronID, currentPSN);
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
                    }
                    else
                        ShowError(ex);
                }
            }
            UndoEnabled = false;
            this.delivery.BarcodeInfo.Clear();
            RefreshHeader();
            // upd 19.12.2012 RefreshLines();
        }

        private void RefreshLines()
        {
            var loadWorker = new BackgroundWorker();

            var sp = new SessionIDSearchParameters();
            sp.SessionID = this.UserID;

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvLines.DataView.FillData(e.Argument as SessionIDSearchParameters);
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
                    this.xdgvLines.BindData(false);
                    this.xdgvLines.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync(sp);
            waitProgressForm.ShowDialog();
        }

        private void DeliveryPackingWindow_Load(object sender, EventArgs e)
        {
            this.xdgvLines.AllowSummary = false;
            this.xdgvLines.AllowRangeColumns = false;
            this.xdgvLines.SetSameStyleForAlternativeRows();

            this.xdgvLines.DataGrid.DefaultCellStyle.Font = new Font(this.xdgvLines.DataGrid.DefaultCellStyle.Font.FontFamily, 16.0f);
            this.xdgvLines.DataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(this.xdgvLines.DataGrid.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10.0f);
            this.xdgvLines.DataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.xdgvLines.FilterGrid.DefaultCellStyle = this.xdgvLines.DataGrid.DefaultCellStyle;
            this.xdgvLines.SummaryGrid.DefaultCellStyle = this.xdgvLines.DataGrid.DefaultCellStyle;

            this.xdgvLines.DataGrid.ContextMenuStrip = cmsOperations;

            this.xdgvLines.Init(new DeliveryPackingView(), true);
            this.xdgvLines.UserID = this.UserID;

            xdgvLines.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvLines_OnRowDoubleClick);
            xdgvLines.OnFilterChanged += new EventHandler(xdgvLines_OnFilterChanged);
            xdgvLines.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvLines_OnFormattingCell);
            this.xdgvLines.DataGrid.KeyDown += gvLines_KeyDown;
        }

        void xdgvLines_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDifference();
        }

        void xdgvLines_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvLines.RecalculateSummary();
        }

        void xdgvLines_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            RefreshLines();
            tbBarcode.Focus();
        }

        private void gvLines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ShowDifference();
            }
        }

        private void ShowDifference()
        {
            if (this.xdgvLines.SelectedItem == null)
                return;

            var docID = Convert.ToInt64(this.xdgvLines.SelectedItem["Doc_ID"]);
            var isLoad = this.xdgvLines.SelectedItem["IS_Load"].Equals(DBNull.Value) ? 0 : Convert.ToInt16(this.xdgvLines.SelectedItem["IS_Load"]);
            var perronID = Convert.ToInt32(this.xdgvLines.SelectedItem["Peron_ID"]);
            var color = this.xdgvLines.SelectedItem["Color"].ToString();

            // Если погрузка "холода" не завершена отображаем информативное окно и выходим
            if (isLoad == 0)
            {
                NotLoadedColdItems formCold = new NotLoadedColdItems();
                formCold.PerronID = perronID;
                formCold.PerronPackingDocID = docID;
                formCold.UserID = this.UserID;
                formCold.ShowDialog();
                return;
            }

            NeededPSNForm form = new NeededPSNForm();
            form.PerronID = perronID;
            form.PerronPackingDocID = docID;
            form.IsPackingStage = color.ToUpper() != "GREEN";
            form.UserID = this.UserID;
            form.ShowDialog();
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            RefreshLines();
        }

        private void DeliveryPackingWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = previousCultureInfo;
        }
    }

    /// <summary>
    /// Представление для грида с комплектацией маршрутов
    /// </summary>
    public class DeliveryPackingView : IDataView
    {
        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sp = pSearchParameters as SessionIDSearchParameters;
            using (var adapter = new Data.DeliveryTableAdapters.DocsTableAdapter())
            {
                adapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                data = adapter.GetData(sp.SessionID);
            }
        }

        public DeliveryPackingView()
        {
            this.dataColumns.Add(new PatternColumn("Перрон", "Peron_ID", new FilterCompareExpressionRule<Int32>("Peron_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("№ маршр. листа", "Route_List_Number", new FilterCompareExpressionRule<Int64>("Route_List_Number"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Гос. № авто", "Car_Number", new FilterPatternExpressionRule("Car_Number")));
            this.dataColumns.Add(new PatternColumn("Водитель", "driver_name", new FilterPatternExpressionRule("driver_name")));
            this.dataColumns.Add(new PatternColumn("Дата доставки", "DeliveryDate", new FilterDateCompareExpressionRule("DeliveryDate")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Режим", "ZonName", new FilterPatternExpressionRule("ZonName")));
            this.dataColumns.Add(new PatternColumn("Заказов", "Order_Total", new FilterCompareExpressionRule<Int32>("Order_Total"), SummaryCalculationType.Sum) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Обработано", "Order_Work", new FilterCompareExpressionRule<Int32>("Order_Work"), SummaryCalculationType.Sum) { Width = 120 });
        }
    } 
}
