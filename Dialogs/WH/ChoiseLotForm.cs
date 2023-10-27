using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.WH
{
    public partial class ChoiseLotForm : DialogForm
    {
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();
        public Data.WH.LotsRow SelectedItem
        {
            get
            {
                if (dgvLots.SelectedItems.Count == 0)
                    return null;
                else
                    return (Data.WH.LotsRow)dgvLots.SelectedItems[0];
            }
        }

        /// <summary>
        /// Свалидированное значение
        /// </summary>
        public Data.WH.LotsRow VerifiedItem { get; private set; }


        /// <summary>
        /// № документа
        /// </summary>
        public long? DocID { get; set; }

        /// <summary>
        /// Код товара
        /// </summary>
        public int ItemID { get; set; }

        public string WarehouseID_To { get; set; }

        public ChoiseLotForm()
        {
            InitializeComponent();
            try
            {
                var ds = new ChoiseLotView();
                ds.FillData(new ChoiseLotSearchParameters());
                dgvLots.Init(ds, true);

                Config.LoadDataGridViewSettings("ChoiseLotForm", dgvLots.DataGrid);
                this.SetDefaultGeneralColumnsLayout();
            }
            catch (Exception ex)
            {
                
            }

            
            this.ApplyOperation(DialogResult.None);
        }

        /// <summary>
        /// Установка расположения основных колонок по умолчанию
        /// </summary>
        private void SetDefaultGeneralColumnsLayout()
        {
            foreach (DataGridViewColumn column in this.dgvLots.DataGrid.Columns)
                if (column.DataPropertyName == "LotNumber")
                {
                    column.DisplayIndex = 0;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvLots.DataGrid.Columns)
                if (column.DataPropertyName == "VendorLot")
                {
                    column.DisplayIndex = 1;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvLots.DataGrid.Columns)
                if (column.DataPropertyName == "ExpDate")
                {
                    column.DisplayIndex = 2;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvLots.DataGrid.Columns)
                if (column.DataPropertyName == "Location")
                {
                    column.DisplayIndex = 3;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvLots.DataGrid.Columns)
                if (column.DataPropertyName == "Quantity")
                {
                    column.DisplayIndex = 4;
                    break;
                }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            this.Search();
        }

        private void Search()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            //this.lotsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Обработка запроса...";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.lotsTableAdapter.GetData(this.UserID, this.DocID, this.ItemID, null, WarehouseID_To);
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).ToString(), "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.wH.Lots.Clear();
            }
            else
            {
                var gv = dgvLots.DataView as ChoiseLotView;
                if (gv == null)
                    return;

                gv.FillData(e.Result as DataTable);
                dgvLots.BindData(false);
                //this.lotsBindingSource.DataSource = e.Result;
            }

            waitProcessForm.CloseForce();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
        }

        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
        }

        private void dgvLots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                this.ApplyOperation(DialogResult.OK);
        }

        private void ChoiseLotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = !ValidateOperation();
            }

            try
            {
                Config.SaveDataGridViewSettings("ChoiseLotForm", dgvLots.DataGrid);
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidateOperation()
        {
            if (this.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана партия из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Валидация введенного значения
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool VerifyValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            string lotNumber = value;

            BackgroundWorker verifyWorker = new BackgroundWorker();
            verifyWorker.DoWork += new DoWorkEventHandler(verifyWorker_DoWork);
            verifyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(verifyWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Валидация на соответствие справочнику..";
            verifyWorker.RunWorkerAsync(lotNumber);
            waitProcessForm.ShowDialog();

            return this.VerifiedItem != null;
        }

        void verifyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string lotNumber = e.Argument.ToString();
                var table = this.lotsTableAdapter.GetData(this.UserID, this.DocID, this.ItemID, lotNumber, WarehouseID_To);
                if (table.Rows.Count != 0)
                {
                    var abc = table[0].ItemArray;
                    this.VerifiedItem = table[0];
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void verifyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            waitProcessForm.CloseForce();
        }


        #region КЛАССЫ ДЛЯ РЕАЛИЗАЦИИ ФИЛЬТРУЕМОГО ГРИДА С МАКЕТАМИ СПИСАНИЯ

        /// <summary>
        /// Представление для грида с остатками на непродажных складах
        /// </summary>
        public class ChoiseLotView : IDataView
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
                var par = pSearchParameters as ChoiseLotSearchParameters;
                if (par == null)
                    return;

                FillData(par.Doc_ID);
            }

            /// <summary>
            /// Пересчитать
            /// </summary>
            /// <param name="doc_ID">Документ</param>
            public void CompensationCalc(long doc_ID)
            {

            }

            /// <summary>
            /// Наполнение источника данных с внешнего источника
            /// </summary>
            /// <param name="pTable">Внешний источник</param>
            public void FillData(DataTable pTable)
            {
                data = pTable;
            }

            /// <summary>
            /// Наполнение источника данных с внешнего источника
            /// </summary>
            /// <param name="pTable">Внешний источник</param>
            public void FillData(long Doc_ID)
            {
                //var docId = (int)Doc_ID;
                //using (var adapter = new CompensationDetailsTableAdapter())
                //    data = adapter.GetData(docId);
            }

            public ChoiseLotView()
            {
                this.dataColumns.Add(new PatternColumn("Место", "Location", new FilterPatternExpressionRule("Location")));
                this.dataColumns.Add(new PatternColumn("Партия", "LotNumber", new FilterPatternExpressionRule("LotNumber")));
                this.dataColumns.Add(new PatternColumn("Серия", "VendorLot", new FilterPatternExpressionRule("VendorLot")));
                this.dataColumns.Add(new PatternColumn("Кол-во", "Quantity") { UseDecimalNumbersAlignment = true } );
                this.dataColumns.Add(new PatternColumn("Срок годности", "ExpDate", new FilterPatternExpressionRule("ExpDate")));
                this.dataColumns.Add(new PatternColumn("Код блок. партии", "LotStatusCode", new FilterPatternExpressionRule("LotStatusCode")));
                this.dataColumns.Add(new PatternColumn("SSCC", "SSCC", new FilterPatternExpressionRule("SSCC")));
                this.dataColumns.Add(new PatternColumn("Блокировка партии", "LotStatus", new FilterPatternExpressionRule("LotStatus")));
                this.dataColumns.Add(new PatternColumn("Класс ГК", "GLCategory", new FilterPatternExpressionRule("GLCategory")));
                //this.dataColumns.Add(new PatternColumn("Ответств. лицо", "IC_Location", new FilterPatternExpressionRule("IC_Location")));
                this.dataColumns.Add(new PatternColumn("Ед. изм.", "UnitOfMeasure"));
                this.dataColumns.Add(new PatternColumn("Себестоимость, грн.", "CostPrice") { UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Базовая цена, грн.", "BasePrice") { UseDecimalNumbersAlignment = true, Format = "N4" });
                this.dataColumns.Add(new PatternColumn("Кол-во зарезервировано", "QuantityCommit") { UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Кол-во доступно", "QuantityFree") { UseDecimalNumbersAlignment = true });
            }
        }

        /// <summary>
        /// Параметры получения списка макетов списания
        /// </summary>
        public class ChoiseLotSearchParameters : SearchParametersBase
        {
            /// <summary>
            /// Идентификатор сессии пользователя
            /// </summary>
            public long SessionID { get; set; }

            /// <summary>
            /// Идентификатор документа
            /// </summary>
            public long Doc_ID { get; set; }


            /// <summary>
            /// Фильтры, которые вводятся в заголовках таблицы
            /// </summary>
            public CreateWriteOffStuffForm.RemainsFilter RemainsFilter { get; set; }
        }

        #endregion
    }
}
