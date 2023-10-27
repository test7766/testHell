using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.WH.SD
{
    public partial class SalesDispatcherLinesForm : DialogForm
    {
        /// <summary>
        /// Представление
        /// </summary>
        private SalesDispatcherLinesView view = new SalesDispatcherLinesView();

        /// <summary>
        /// Критерий поиска
        /// </summary>
        private SalesDispatherLinesSearchParameters searchCriteria = new SalesDispatherLinesSearchParameters();

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        public SalesDispatcherLinesForm(long userID, string docType, long docNumber, long? pickSlip)
        {
            InitializeComponent();

            this.searchCriteria.UserID = userID;
            this.searchCriteria.DocType = docType;
            this.searchCriteria.DocNumber = docNumber;
            this.searchCriteria.PickSlip = pickSlip;

            dgvLines.AutoGenerateColumns = false;
            Config.LoadDataGridViewSettings(this.Name, dgvLines);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(760, 8);
            this.btnCancel.Location = new Point(840, 8);

            this.LoadLines();
        }

        #region ФОНОВАЯ ЗАГРУЗКА ПОЗИЦИЙ ДИСПЕТЧЕРА ПРОДАЖ

        private void LoadLines()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync(this.searchCriteria);
            waitProgressForm.ShowDialog();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.view.FillData(e.Argument as SalesDispatherLinesSearchParameters);
                e.Result = this.view;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            else
            {
                this.AdaptView(e.Result as SalesDispatcherLinesView);
            }

            waitProgressForm.CloseForce();
        }

        /// <summary>
        /// Адаптация представления к отображению
        /// </summary>
        /// <param name="view"></param>
        private void AdaptView(SalesDispatcherLinesView view)
        {
            var headerData = view.HeaderData.Rows[0];
            tbSHKCOO.Text = headerData["SHKCOO"].ToString();
            tbSHDCTO.Text = headerData["SHDCTO"].ToString();
            tbSHDOCO.Text = headerData["SHDOCO"].ToString();
            tbDebitor.Text = headerData["Debitor"].ToString();
            tbDebitorName.Text = headerData["DebitorName"].ToString();
            tbDelivery.Text = headerData["Delivery"].ToString();
            tbDeliveryName.Text = headerData["DeliveryName"].ToString();
            tbCity.Text = headerData["City"].ToString();
            tbAddress.Text = headerData["Address"].ToString();
            tbInstruction1.Text = headerData["Instruction 1"].ToString();
            tbInstruction2.Text = headerData["Instruction 2"].ToString();
            dtpOrderDate.Value = Convert.ToDateTime(headerData["Order Date"]);
            dtpDeliveryDate.Value = Convert.ToDateTime(headerData["Delivery Date"]);
            tbSalesCategory.Text = headerData["CategoryDesc"].ToString();
            tbSalesCategory.Tag = headerData["Category"].ToString();

            if (this.dgvLines.Columns.Count == 0)
            {
                string columnNamePattern = string.Empty;
                foreach (PatternColumn column in view.Columns)
                {
                    DataGridViewColumn gridColumn = new DataGridViewTextBoxColumn();

                    columnNamePattern = column.DataFieldName.Replace(" ", "").TrimStart('[').TrimEnd(']');
                    gridColumn.Name = dgvLines.Name + "_" + columnNamePattern;

                    gridColumn.DataPropertyName = column.DataFieldName;
                    gridColumn.HeaderText = column.Caption;
                    gridColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    if (column.UseDecimalNumbersAlignment)
                    {
                        gridColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        gridColumn.DefaultCellStyle.Format = "N2";
                    }

                    this.dgvLines.Columns.Add(gridColumn);
                }

                Config.LoadDataGridViewSettings(this.Name, dgvLines);
            }

            dgvLines.DataSource = view.Data;
        }

        #endregion

        private void SalesDispatcherLinesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, dgvLines);
        }

        #region ЭКСПОРТ В EXCEL ТОВАРОВ ИЗ ЗАКАЗА

        /// <summary>
        /// Экспорт в Excel списка товаров в заказе
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            var dialog = CreateExportToExcelDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportLinesToExcel(dialog.FileName, dgvLines);
                    Process.Start(dialog.FileName);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Во время экспорта в Excel возникла ошибка: " + exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Создает диалоговое окно с выбором названия и местоположения Excel-файла с товарами в заказе
        /// </summary>
        /// <returns>Диалоговое окно с выбором названия и местоположения Excel-файла с товарами в заказе</returns>
        private SaveFileDialog CreateExportToExcelDialog()
        {
            DateTime now = DateTime.Now;
            return new SaveFileDialog()
            {
                FileName = String.Format("{0}{1}{2}{3}{4}{5}-список товаров", now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0')),
                Title = "Экспорт товаров в заказе",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Текстовый файл с разделителями (*.csv)|*.csv",
                FilterIndex = 0,
                AddExtension = true,
                DefaultExt = "csv"
            };
        }
        /// <summary>
        /// Экспорт товаров с заказа в заданный CSV-файл
        /// </summary>
        /// <param name="pFilePath">Путь к CSV-файлу, куда нужно экспортировать товары</param>
        /// <param name="pDgv">DatagridView с данными, которые нужно экспортировать</param>
        private static void ExportLinesToExcel(string pFilePath, DataGridView pDgv)
        {
            using (var sw = new StreamWriter(pFilePath, false, Encoding.Default))
            {
                var colIndexes = GetListOfColumnIndexes(pDgv);

                for (int i = 0; i < colIndexes.Count; i++)    // Запись заголовков колонок в файл
                {
                    sw.Write("\"" + pDgv.Columns[colIndexes[i]].HeaderText + "\"");
                    if (i < colIndexes.Count - 1)
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
                sw.Write(sw.NewLine);

                foreach (DataGridViewRow row in pDgv.Rows)  // Запись строк в файл
                {
                    for (int i = 0; i < colIndexes.Count; i++)
                    {
                        if (row.Cells[colIndexes[i]].Value != null && !Convert.IsDBNull(row.Cells[colIndexes[i]].Value) &&
                            !String.IsNullOrEmpty(row.Cells[colIndexes[i]].Value.ToString()))
                            sw.Write("\"" + row.Cells[colIndexes[i]].Value.ToString() + "\"");
                        else
                            sw.Write("\" \"");

                        if (i < colIndexes.Count - 1)
                            sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                    }
                    sw.Write(sw.NewLine);
                }

                sw.Close();
            }
        }

        /// <summary>
        /// Получает список индексов столбцов заданного DataGridView, отсортированный по DisplayIndex
        /// </summary>
        /// <param name="pDgv">DataGridView, из которого нужно получить отсортированный список индексов</param>
        /// <returns>Список индексов заданного DataGridView, отсортированный по DisplayIndex</returns>
        private static List<int> GetListOfColumnIndexes(DataGridView pDgv)
        {
            var colIndexes = new List<int>();
            for (int i = 0; i < pDgv.Columns.Count; i++)
                if (pDgv.Columns[i].Visible)
                    colIndexes.Add(i);

            for (int i = 0; i < colIndexes.Count; i++)
                for (int j = i + 1; j < colIndexes.Count; j++)
                    if (pDgv.Columns[colIndexes[i]].DisplayIndex > pDgv.Columns[colIndexes[j]].DisplayIndex)
                    {
                        int tmp = colIndexes[i];
                        colIndexes[i] = colIndexes[j];
                        colIndexes[j] = tmp;
                    }

            return colIndexes;
        }

        #endregion

        private void btnChangeSalesCategory_Click(object sender, EventArgs e)
        {
            var userID = this.searchCriteria.UserID;
            var docNumber = this.searchCriteria.DocNumber;
            var docType = this.searchCriteria.DocType;

            var oldCategory = tbSalesCategory.Tag.ToString();
            var newCategory = (string)null;

            #region 1. Подготовка справочника категорий продаж
            string querySalesCategories = string.Format("EXEC [dbo].[pr_DP_GetSalesCategory_Replace] '{0}'", oldCategory);
            SqlDataAdapter adapter = new SqlDataAdapter(querySalesCategories, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            var dlgSelectSalesCategory = new WMSOffice.Dialogs.RichListForm();
            dlgSelectSalesCategory.Text = "Выберите категорию продаж";
            dlgSelectSalesCategory.AddColumn("CategoryDesc", "CategoryDesc", "Категория");
            dlgSelectSalesCategory.FilterVisible = false;
            dlgSelectSalesCategory.DataSource = dataSet.Tables[0];

            if (dlgSelectSalesCategory.ShowDialog() == DialogResult.OK)
            {
                var category = dlgSelectSalesCategory.SelectedRow as DataRow;
                newCategory = category["Category"].ToString();
            }
            #endregion

            #region 2. Изменение категории продаж
            if (newCategory != null)
            {
                string query = string.Format("EXEC [dbo].[pr_DP_UpdateSalesCategory] {0}, {1}, '{2}', '{3}', '{4}'", userID, docNumber, docType, oldCategory, newCategory);
                SqlCommand cmdChangeSalesCategory = new SqlCommand(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
                bool success = false; // признак успешного выполнения операции

                try
                {
                    cmdChangeSalesCategory.Connection.Open();
                    cmdChangeSalesCategory.ExecuteNonQuery();

                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmdChangeSalesCategory.Connection.Close();
                    LoadLines();
                }
            }
            #endregion
        }
    }

    public class SalesDispatcherLinesView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        /// <summary>
        /// Заголовок
        /// </summary>
        private DataTable headerData;
        public DataTable HeaderData { get { return this.headerData; } }

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
            var searchCriteria = searchParameters as SalesDispatherLinesSearchParameters;

            string query = string.Format("EXEC [dbo].[pr_DP_GetOrderDetail] {0}, '{1}', {2}, {3}",
                searchCriteria.UserID,
                searchCriteria.DocType,
                searchCriteria.DocNumber,
                searchCriteria.PickSlip.HasValue ? searchCriteria.PickSlip.Value.ToString() : "NULL");
            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.headerData = dataSet.Tables[0];
            this.data = dataSet.Tables[1];   
        }
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public SalesDispatcherLinesView()
        {
            this.dataColumns.Add(new PatternColumn("№ стр.", "LineID"));
            this.dataColumns.Add(new PatternColumn("Код товара", "Item_ID"));
            this.dataColumns.Add(new PatternColumn("Товар", "Item"));
            this.dataColumns.Add(new PatternColumn("Фикс. место", "FixLocation"));
            this.dataColumns.Add(new PatternColumn("№ сборочного", "PackList"));
            this.dataColumns.Add(new PatternColumn("Место", "Location"));
            this.dataColumns.Add(new PatternColumn("Партия", "Batch"));
            this.dataColumns.Add(new PatternColumn("Серия", "VendorLot"));
            this.dataColumns.Add(new PatternColumn("Кол-во", "Qt"));
            this.dataColumns.Add(new PatternColumn("КД ост.", "Control"));
            this.dataColumns.Add(new PatternColumn("ЕИ", "UOM"));
            this.dataColumns.Add(new PatternColumn("Цена", "Price") { UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Сумма", "Amount") { UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("След. статус", "NXTR"));
            this.dataColumns.Add(new PatternColumn("Посл. статус", "LTTR"));
            this.dataColumns.Add(new PatternColumn("Тип накл.", "InvoiceType"));
            this.dataColumns.Add(new PatternColumn("Накладная", "Invoice"));
            this.dataColumns.Add(new PatternColumn("Услов. оплаты", "PaymentTerm"));
            this.dataColumns.Add(new PatternColumn("Налог. зона", "TaxCode"));
            this.dataColumns.Add(new PatternColumn("Налог Y/N", "Tax"));
            this.dataColumns.Add(new PatternColumn("Налог. ставка", "Tax1"));
            this.dataColumns.Add(new PatternColumn("Номер зоны", "Zone"));
            this.dataColumns.Add(new PatternColumn("Код маршр.", "Route"));
            this.dataColumns.Add(new PatternColumn("Код ТП", "SalesManager"));
            this.dataColumns.Add(new PatternColumn("Тип стр.", "StringType"));
            this.dataColumns.Add(new PatternColumn("Автор", "Author"));
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class SalesDispatherLinesSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public string DocType { get; set; }
        public long DocNumber { get; set; }
        public long? PickSlip { get; set; }

        /// <summary>
        /// Признак использования для печати контрольного листа ВР
        /// </summary>
        public bool UseControlListBP { get; set; }
    }
}
