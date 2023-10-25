using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Data;
using WMSOffice.Data.WFTableAdapters;
using WMSOffice.Classes;

namespace WMSOffice.Window.WriteOff
{
    public partial class RequestViewForm : Form
    {
        public long UserID { get; set; }

        public RequestViewForm(long userId)
        {
            InitializeComponent();
            UserID = userId;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PrepareGridViews();

            dgvDocs.DataView.FillData(null);
            dgvDocs.BindData(false);
           
        }

        private void PrepareGridViews()
        {
            dgvDocs.Init(new RequestsView(), true);
            //dgvDocs.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvDocs.UserID = UserID;
            dgvDocs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDocs.AllowRangeColumns = true;
            dgvDocs.UseMultiSelectMode = true;

            dgvMakets.Init(new MaketsView(), true);
            //dgvMakets.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvMakets.UserID = UserID;
            dgvMakets.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvMakets.AllowRangeColumns = true;
            dgvMakets.UseMultiSelectMode = true;

            dgvDocs.OnFilterChanged += new EventHandler(dgvDocs_OnFilterChanged);
            dgvDocs.OnRowSelectionChanged += new EventHandler(dgvDocs_OnRowSelectionChanged);
        }

        void dgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                statusLabel.Text = String.Empty;

                var row = dgvDocs.SelectedItem as WF.WF_ArchRequestsRow;
                if (row == null)
                    return;

                statusLabel.Text = String.Format("{0} - {1}", row.RequestNumber, row.Description);
                var sp = new RowSearchParameter() { Row = row };
                dgvMakets.DataView.FillData(sp);
                dgvMakets.BindData(false);
            }
            catch (Exception)
            {

            }


        }

        void dgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            dgvDocs.RecalculateSummary();
        }

        #region КЛАССЫ ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА С МАКЕТАМИ

        /// <summary>
        /// Представление для грида с макетами списания
        /// </summary>
        private class MaketsView : IDataView
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
                try
                {
                    var sc = pSearchParameters as RowSearchParameter;
                    using (var adapter = new WF_DocsByRequestTableAdapter())
                        data = adapter.GetData(sc.Row.RequestNumber);
                }
                catch
                {
                    data = new WF.WF_DocsByRequestDataTable();
                }
            }

            public MaketsView()
            {
                this.dataColumns.Add(new PatternColumn("№ документа", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("№ Акта", "Act_Number", new FilterPatternExpressionRule("Act_Number"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Тип документа", "Doc_Type", new FilterPatternExpressionRule("Doc_Type"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Вид документа компенсации", "DocType", new FilterPatternExpressionRule("DocType"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Дата документа", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Склад", "Warehouse_ID", new FilterPatternExpressionRule("Warehouse_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Пользователь", "User_FIO", new FilterPatternExpressionRule("User_FIO"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Статус", "StatusName", new FilterPatternExpressionRule("StatusName"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Ид документа в Directum", "DirectumId", new FilterPatternExpressionRule("DirectumId"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Списанная сумма по компенсации", "CompensationAmount", new FilterPatternExpressionRule("CompensationAmount"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Валюта документа компенсации", "Currency", new FilterPatternExpressionRule("Currency"), SummaryCalculationType.Count));

                this.dataColumns.Add(new PatternColumn("Итог. Сумма (валюта)", "Amount_UAH", new FilterCompareExpressionRule<Decimal>("Amount_UAH"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Себестоимость (грн.)", "Cost", new FilterCompareExpressionRule<Decimal>("Cost"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Итог. сумма в базовых (грн.)", "BaseAmount", new FilterCompareExpressionRule<Decimal>("BaseAmount"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true });
                
                //this.dataColumns.Add(new PatternColumn("Описание", "Desc", new FilterPatternExpressionRule("Desc"), SummaryCalculationType.Count));
                //this.dataColumns.Add(new PatternColumn("Инвентаризация", "Inventory_ID", new FilterPatternExpressionRule("Inventory_ID"), SummaryCalculationType.Count));
                //this.dataColumns.Add(new PatternColumn("ЗУ экспортирована", "request_printed", new FilterPatternExpressionRule("request_printed"), SummaryCalculationType.Count));
            }
        }

        private class RowSearchParameter : SearchParametersBase
        {
            public WF.WF_ArchRequestsRow Row { get; set; }
        }

        #endregion

        #region КЛАССЫ ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА С ЗАЯВКАМИ

        /// <summary>
        /// Представление для грида с макетами списания
        /// </summary>
        private class RequestsView : IDataView
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
                try
                {
                    using (var adapter = new WF_ArchRequestsTableAdapter())
                        data = adapter.GetData();
                }
                catch
                {
                    data = new WF.WF_ArchRequestsDataTable();
                }
            }

            public RequestsView()
            {
                this.dataColumns.Add(new PatternColumn("№ заявки", "RequestNumber", new FilterCompareExpressionRule<Int64>("RequestNumber"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Описание заявки", "Description", new FilterPatternExpressionRule("Description"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Дата заявки", "CreateDate", new FilterDateCompareExpressionRule("CreateDate"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Вес", "Weight", new FilterDateCompareExpressionRule("Weight"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Format = "N4" });
                this.dataColumns.Add(new PatternColumn("№ Акта", "ActNumber", new FilterPatternExpressionRule("ActNumber"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Тип акта", "RequestType", new FilterPatternExpressionRule("RequestType"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("№ счета", "InvoiceNumber", new FilterPatternExpressionRule("InvoiceNumber"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Дата счета", "InvoiceDate", new FilterPatternExpressionRule("InvoiceDate"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Сумма", "InvoiceAmount", new FilterCompareExpressionRule<Int32>("InvoiceAmount"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Format = "N2" });
            }
        }

        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog() { DefaultExt = "csv", FileName = "Список заявок", Filter = "Excel|*.csv" };
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string[] headers = new string[] { "№ заявки", "Описание заявки", "Дата заявки", "Вес",
                            "№ Акта", "Тип акта", "№ счета", "Дата счета", "Сумма" };
                string[] columnNames = new string[] { "RequestNumber", "Description", "CreateDate", "Weight",
                            "ActNumber", "RequestType", "InvoiceNumber", "InvoiceDate", "InvoiceAmount" };

                string message = ExportHelper.ExportDataTableToExcelFile(dlg.FileName,
                            dgvDocs.DataView.Data, headers, columnNames);
                if (!String.IsNullOrEmpty(message))
                    throw new ApplicationException(message);

                MessageBox.Show("Заявки на уничтожение экспортированы.", "Экспорт заявок",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Произошла ошибка во время экспорта в PDF заявок на уничтожение: ", ex);
            }
        }
    }
}
