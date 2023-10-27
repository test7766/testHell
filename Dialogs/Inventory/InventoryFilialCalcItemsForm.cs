using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Timers;
using System.Transactions;
using System.Windows.Forms;

using WMSOffice.Controls;
using WMSOffice.Data.InventoryTableAdapters;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Classes;
using System.Threading;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryFilialCalcItemsForm : Form
    {
        private static readonly string calcFormItems = "form_items";
        private static readonly string calcFormLocns = "form_locns";

        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Сессия пользователя
        /// </summary>
        public int sessionID;

        /// <summary>
        /// Идентификатор инвентаризации
        /// </summary>
        public int docID;

        /// <summary>
        /// Номер пересчета
        /// </summary>
        public int calcID;

        /// <summary>
        /// Признак режима "закрытие инвентаризации"
        /// </summary>
        private bool closeInventory;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private SplashForm splashForm = new SplashForm();

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryFilialCalcItemsForm(int pSessionID, int pDocID, int pCalcID, bool pCloseInventory, string calcForm)
        {
            InitializeComponent();

            sessionID = pSessionID;
            docID = pDocID;
            calcID = pCalcID;
            closeInventory = pCloseInventory;
            Text = pCloseInventory ? "Закрытие инвентаризации " + docID :
                String.Format("Товар для {0}-го пересчета инвентаризации № {1}", calcID, docID);
            btnCreateCalc.Visible = !closeInventory; 
            btnCloseInventory.Visible = closeInventory;

            if (calcForm.Equals(calcFormItems))
            {
                tpFormLocns.Parent = null;
                //tcCalcForms.TabPages.Remove(tpFormLocns);

                pnlTop.Visible = pCalcID == 4;
                filterTimer.Elapsed += filterTimer_Elapsed;
                CustomColumnsVisibility();
                if (pCalcID == 4)
                    CustomCheckHeader();
            }
            else if (calcForm.Equals(calcFormLocns))
            {
                tpFormItems.Parent = null;
                //tcCalcForms.TabPages.Remove(tpFormItems);

                if (closeInventory)
                    tsFormLocns.Visible = false;
            }
        }

        /// <summary>
        /// Настройка видимости колонок в зависимости от пересчета
        /// (к примеру, если первый пересчет - то результаты его еще не видны и т.д.)
        /// </summary>
        private void CustomColumnsVisibility()
        {
            Checked.Visible = calcID == 4 || closeInventory;
            Checked.ReadOnly = closeInventory;
            quantityFact1.Visible = calcID > 1 || closeInventory;
            quantityFact2.Visible = calcID > 2 || closeInventory;
            quantityFact3.Visible = calcID > 3 || closeInventory;
            QuantityFact4.Visible = closeInventory;
        }

        /// <summary>
        /// Настройка заголовка для CheckBox-колонки таблицы проверок тоже в виде CheckBox-а
        /// </summary>
        private void CustomCheckHeader()
        {
            //var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            //checkHeaderCell.OnCheckBoxClicked += checkHeaderCell_OnCheckBoxClicked;
            //checkHeaderCell.Value = String.Empty;
            //Checked.HeaderCell = checkHeaderCell;

            dgvItems.CurrentCellDirtyStateChanged += new EventHandler(dgvInvoiceLines_CurrentCellDirtyStateChanged);

            dgvItems.Columns[Checked.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvItems.Columns[Checked.Index].HeaderCell).CheckBoxClicked += new EventHandler<WMSOffice.Dialogs.Complaints.DataGridViewCheckBoxHeaderCellEventArgs>(InventoryFilialCalcItemsForm_CheckBoxClicked);
        }

        void InventoryFilialCalcItemsForm_CheckBoxClicked(object sender, WMSOffice.Dialogs.Complaints.DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
                ((row.DataBoundItem as DataRowView).Row as Data.Inventory.FI_ItemsForCalcRow).IsChecked = e.IsChecked;

            dgvItems.RefreshEdit();
        }

        private void dgvInvoiceLines_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentCell is DataGridViewCheckBoxCell)
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        ///// <summary>
        ///// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки
        ///// </summary>
        ///// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        //public void checkHeaderCell_OnCheckBoxClicked(bool pState)
        //{
        //    //foreach (DataGridViewRow row in dgvItems.Rows)
        //    //    (row.Cells["Checked"] as DataGridViewCheckBoxCell).Value = pState;

        //    foreach (DataGridViewRow row in dgvItems.Rows)
        //        ((row.DataBoundItem as DataRowView).Row as Data.Inventory.FI_ItemsForCalcRow).IsChecked = pState;

        //    dgvItems.RefreshEdit();
        //    //bsFiItemsForCalc.ResetBindings(false);
        //}

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Config.LoadDataGridViewSettings(this.Name, dgvItems);
        }

        /// <summary>
        /// Загрузка списка всех товаров при загрузке формы
        /// </summary>
        private void CalcItemsForm_Load(object sender, EventArgs e)
        {
            if (tcCalcForms.SelectedTab == tpFormItems)
                RefreshItems();
            else if (tcCalcForms.SelectedTab == tpFormLocns)
                RefreshDiff();
        }

        #region ФОНОВОЕ ОБНОВЛЕНИЕ СПИСКА ТОВАРА ДЛЯ ТОВАРНОЙ ИНВЕНТАРИЗАЦИИ
        /// <summary>
        /// Обновление списка товаров для пересчета
        /// </summary>
        private void RefreshItems()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += refreshWorker_DoWork;
            worker.RunWorkerCompleted += refreshWorker_RunWorkerCompleted;
            inventory.FI_ItemsForCalc.Clear();
            bsFiItemsForCalc.DataSource = null;

            splashForm.ActionText = "Получение списка товара...";
            worker.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Фоновое обновление списка товаров
        /// </summary>
        void refreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                taFiItemsForCalc.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                taFiItemsForCalc.Fill(inventory.FI_ItemsForCalc, sessionID, docID, calcID);
                //e.Result = taFiItemsForCalc.GetData(sessionID, docID, calcID);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Обработка окончания фонового обновления данных
        /// </summary>
        void refreshWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Ошибка при загрузке товаров для инвентаризации:", e.Result as Exception);
            //else
            //{
            //    inventory.FI_ItemsForCalc.Merge(e.Result as Data.Inventory.FI_ItemsForCalcDataTable);
            //    bsFiItemsForCalc.DataSource = e.Result;
            //}

            bsFiItemsForCalc.DataSource = inventory.FI_ItemsForCalc;
            splashForm.CloseForce();
        }
        #endregion

        #region ФОНОВОЕ ОБНОВЛЕНИЕ СПИСКА ТОВАРА ДЛЯ МЕСТОВОЙ ИНВЕНТАРИЗАЦИИ

        private void btnRefreshLocns_Click(object sender, EventArgs e)
        {
            this.RefreshLocns();
        }

        /// <summary>
        /// Обновление списка товаров для пересчета
        /// </summary>
        private void RefreshLocns()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += refreshCalcWorker_DoWork;
            worker.RunWorkerCompleted += refreshCalcWorker_RunWorkerCompleted;
            inventory.pr_FI1_Calcs4_Shape_Get_CalcData.Clear();
            prFI1Calcs4ShapeGetCalcDataBindingSource.DataSource = null;

            splashForm.ActionText = "Получение списка товара...";
            worker.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Фоновое обновление списка товаров
        /// </summary>
        void refreshCalcWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                pr_FI1_Calcs4_Shape_Get_CalcDataTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                pr_FI1_Calcs4_Shape_Get_CalcDataTableAdapter.Fill(inventory.pr_FI1_Calcs4_Shape_Get_CalcData, sessionID, docID);
                //e.Result = pr_FI1_Calcs4_Shape_Get_CalcDataTableAdapter.GetData(sessionID, docID);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Обработка окончания фонового обновления данных
        /// </summary>
        void refreshCalcWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Ошибка при загрузке товаров для инвентаризации:", e.Result as Exception);
            //else
            //{
            //    inventory.pr_FI1_Calcs4_Shape_Get_CalcData.Merge(e.Result as Data.Inventory.pr_FI1_Calcs4_Shape_Get_CalcData);
            //    prFI1Calcs4ShapeGetCalcDataBindingSource.DataSource = e.Result;
            //}

            prFI1Calcs4ShapeGetCalcDataBindingSource.DataSource = inventory.pr_FI1_Calcs4_Shape_Get_CalcData;
            splashForm.CloseForce();
        }
        #endregion

        #endregion

        #region СОЗДАНИЕ НОВОГО ПЕРЕСЧЕТА

        /// <summary>
        /// Создание нового пересчета
        /// </summary>
        private void btnCreateCalc_Click(object sender, EventArgs e)
        {
            if (calcID == 4 && !CheckIsAnyItemSelected())
                MessageBox.Show("Для создания пересчета нужно выбрать хотя бы один товар!", "Создание пересчета",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var worker = new BackgroundWorker();
                worker.DoWork += createCalcWorker_DoWork;
                worker.RunWorkerCompleted += createCalcWorker_RunWorkerCompleted;
                splashForm.ActionText = "Создание нового пересчета...";
                worker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
        }

        /// <summary>
        /// Проверка, выбран ли хоть один товар (имеет смысл только если создается четвертый - дополнительный пересчет)
        /// </summary>
        /// <returns>True, если выбран хоть один товар в таблице, False если не выбран</returns>
        private bool CheckIsAnyItemSelected()
        {
            if (tcCalcForms.SelectedTab == tpFormLocns)
                return true;

            foreach (WMSOffice.Data.Inventory.FI_ItemsForCalcRow row in inventory.FI_ItemsForCalc.Rows)
                //if (row.QuantityCalc4)
                if (row.IsChecked)
                    return true;

            return false;
        }

        /// <summary>
        /// Создание пересчета и автоматическое создание счетных листов
        /// </summary>
        private void createCalcWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var scope = new TransactionScope())
                {

                    taFiItemsForCalc.SetTimeout((int)TimeSpan.FromMinutes(30).TotalSeconds);
                    int lcalcId = Convert.ToInt32(taFiItemsForCalc.CreateCalc(sessionID, docID, calcID == 4));

                    if (lcalcId == 4)
                        foreach (WMSOffice.Data.Inventory.FI_ItemsForCalcRow row in inventory.FI_ItemsForCalc.Rows)
                            //if (row.QuantityCalc4)
                            if (row.IsChecked)
                                taFiItemsForCalc.AddItemForCalc(docID, lcalcId, row.Item_ID);

                    taFiItemsForCalc.CsAutoCreate(sessionID, docID, lcalcId);
                    scope.Complete();
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Обработка окончания фонового обновления данных
        /// </summary>
        private void createCalcWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка при создании пересчета: ", e.Result as Exception);

            splashForm.CloseForce();
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region ЗАКРЫТИЕ ИНВЕНТАРИЗАЦИИ

        /// <summary>
        /// Закрытие инвентаризации
        /// </summary>
        private void btnCloseInventory_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += closeInvWorker_DoWork;
            worker.RunWorkerCompleted += closeInvWorker_RunWorkerCompleted;
            splashForm.ActionText = "Сохранение результатов инвентаризации...";
            worker.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Выполнение закрытия инвентаризации в фоновом потоке
        /// </summary>
        private void closeInvWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                taFiItemsForCalc.SetTimeout(180);
                taFiItemsForCalc.CloseInventory(sessionID, docID);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Обработка окончания закрытия инвентаризации
        /// </summary>
        private void closeInvWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Ошибка при закрытии инвентаризации: ", e.Result as Exception);

            splashForm.CloseForce();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ТОВАРОВ

        /// <summary>
        /// Строка фильтра по кодам товара (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string codeStr;

        /// <summary>
        /// Строка фильтра по наименованию товара (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string itemStr;

        /// <summary>
        /// Строка фильтра по производителю (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string manufacturerStr;

        /// <summary>
        /// Строка фильтра по минимальной себестоимости (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string basePriceFromStr;

        /// <summary>
        /// Строка фильтра по максимальной себестоимости (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string basePriceToStr;

        /// <summary>
        /// Признак, который показывает, какой RadioButton отмечен
        /// </summary>
        private bool? withInequality;

        /// <summary>
        /// Заведомо истинное выражение - основа фильтра (далее к этой основе будут добавляться условия)
        /// </summary>
        private string BaseFilter { get { return "1 = 1"; } }

        /// <summary>
        /// Фильтр по коду товара
        /// </summary>
        private string FilterPartCode
        {
            get
            {
                if (String.IsNullOrEmpty(codeStr))
                    return String.Empty;
                else
                {
                    int code;
                    if (Int32.TryParse(codeStr, out code))
                        return String.Format(" AND [Item_ID] = {0}", codeStr);
                    else return String.Empty;
                }
            }
        }

        /// <summary>
        /// Фильтр по названию товара
        /// </summary>
        private string FilterPartItem
        {
            get
            {
                if (String.IsNullOrEmpty(itemStr))
                    return String.Empty;
                else
                    return String.Format(" AND [Item] LIKE '%{0}%'", itemStr);
            }
        }

        /// <summary>
        /// Фильтр по производителю
        /// </summary>
        private string FilterPartManufacturer
        {
            get
            {
                if (String.IsNullOrEmpty(manufacturerStr))
                    return String.Empty;
                else
                    return String.Format(" AND [Manufacturer] LIKE '%{0}%'", manufacturerStr);
            }
        }

        /// <summary>
        /// Фильтр по признаку расхождений
        /// </summary>
        private string FilterPartWithInequalities
        {
            get
            {
                if (withInequality == null)
                    return String.Empty;

                string rightPart = withInequality == true ? " <> 0" : " = 0";
                return String.Format(" AND [DIFF_Amount_2] IS NULL AND [DIFF_Amount_1] {0} OR [DIFF_Amount_3] IS NULL AND [DIFF_Amount_2] {0} OR " +
                    "[DIFF_Amount_3] IS NOT NULL AND [DIFF_Amount_3] {0}", rightPart);
            }
        }

        /// <summary>
        /// Фильтр по минимуму себестоимости
        /// </summary>
        private string FilterPartBasePriceFrom
        {
            get
            {
                decimal? val;
                if (GetDecimalFromString(basePriceFromStr, out val))
                    return String.Format(" AND [QuantityPlanAmount] >= {0}", val.ToString().Replace(",", "."));
                else
                    return String.Empty;
            }
        }

        /// <summary>
        /// Фильтр по максимуму себестоимости
        /// </summary>
        private string FilterPartBasePriceTo
        {
            get
            {
                decimal? val;
                if (GetDecimalFromString(basePriceToStr, out val))
                    return String.Format(" AND [QuantityPlanAmount] <= {0}", val.ToString().Replace(",", "."));
                else
                    return String.Empty;
            }
        }

        /// <summary>
        /// Составной фильтр, который будет применяться к таблице товаров
        /// </summary>
        private string CompleteFilter
        {
            get
            {
                return BaseFilter + FilterPartCode + FilterPartItem + FilterPartManufacturer + FilterPartWithInequalities +
                    FilterPartBasePriceFrom + FilterPartBasePriceTo;
            }
        }

        /// <summary>
        /// Попытка получения числа типа decimal из строки
        /// </summary>
        /// <param name="pStr">Строка, из которой нужно получить число</param>
        /// <param name="pVal">OUT-параметр - полученное число</param>
        /// <returns>True, если парсинг прошел успешно, False если переданная строка не является корректной</returns>
        private static bool GetDecimalFromString(string pStr, out decimal? pVal)
        {
            decimal dec;
            if (String.IsNullOrEmpty(pStr))
            {
                pVal = null;
                return false;
            }

            if (Decimal.TryParse(pStr, out dec))
            {
                pVal = dec;
                return true;
            }
            else if (Decimal.TryParse(pStr.Replace('.', ','), out dec))
            {
                pVal = dec;
                return true;
            }
            else if (Decimal.TryParse(pStr.Replace(',', '.'), out dec))
            {
                pVal = dec;
                return true;
            }
            else
            {
                pVal = null;
                return false;
            }
        }

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        /// <summary>
        /// Таймер, который отвечает за то, чтобы фильтрация проихсодила не сразу после изменения
        /// фильтра, а спустя некоторое время
        /// </summary>
        private System.Timers.Timer filterTimer = new System.Timers.Timer(1000);

        /// <summary>
        /// Начало фильтрации по нажатию на кнопку Enter
        /// </summary>
        private void tbxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                codeStr = tbxCode.Text;
                itemStr = tbxItem.Text;
                manufacturerStr = tbxManufacturer.Text;
                basePriceFromStr = tbxMinBasePrice.Text;
                basePriceToStr = tbxMaxBasePrice.Text;
                withInequality = rbtWithInequality.Checked ? (bool?)true : (rbtWithoutInequalities.Checked ? (bool?)false : null);

                filterTimer.Stop();
                RefreshFilters();
            }
        }

        /// <summary>
        /// Обновление записей в таблице
        /// </summary>
        private void RefreshFilters()
        {
            try
            {
                bsFiItemsForCalc.Filter = CompleteFilter;
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
        }

        /// <summary>
        /// Если прошло достаточно времени с момента последнего редактирования фильтра, запускается фильтрация
        /// </summary>
        private void filterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            filterTimer.Stop();
            dgvItems.Invoke(new Method(RefreshFilters));
        }

        /// <summary>
        /// При изменении фильтра запускаем таймер ожидания, чтобы по прошествию некоторого времени обновить фильтры
        /// </summary>
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            codeStr = tbxCode.Text;
            itemStr = tbxItem.Text;
            manufacturerStr = tbxManufacturer.Text;
            basePriceFromStr = tbxMinBasePrice.Text;
            basePriceToStr = tbxMaxBasePrice.Text;

            filterTimer.Stop();
            filterTimer.Start();
        }

        /// <summary>
        /// При изменении строки фильтра по расхождениям, обновляем фильтр
        /// </summary>
        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            withInequality = rbtWithInequality.Checked ? (bool?)true : (rbtWithoutInequalities.Checked ? (bool?)false : null);
            filterTimer.Stop();
            RefreshFilters();
        }

        #endregion

        private void InventoryFilialCalcItemsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, dgvItems);
        }

        #region МЕСТОВАЯ ИНВЕНТАРИЗАЦИЯ

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var retData = new Data.Inventory.pr_FI1_Calcs4_Shape_Get_Report_CalcDataTable();
                using (var adapter = new Data.InventoryTableAdapters.pr_FI1_Calcs4_Shape_Get_Report_CalcTableAdapter())
                    retData = adapter.GetData(sessionID, docID);

                if (retData.Count == 0)
                    throw new Exception("Отсутствуют данные для экспорта.");

                var headers = new List<string>();
                var fields = new List<string>();
                foreach (DataColumn column in retData.Columns)
                {
                    headers.Add(column.Caption);
                    fields.Add(column.ColumnName);
                }

                var message = ExportHelper.ExportDataTableToExcel(retData, headers.ToArray(), fields.ToArray(), "Экспорт списка товара в пересчете", string.Format("Список товара в {0}-м пересчете по инвентаризации № {1}", calcID, docID), true);
                if (!string.IsNullOrEmpty(message))
                    throw new Exception(message);
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Ошибка при экспорте списка товара в пересчете:", ex);
            }
        }

        private void RefreshDiff()
        {
            try
            {
                using (var adapter = new Data.InventoryTableAdapters.pr_FI1_Calcs4_Shape_Get_DiffCostTableAdapter())
                {
                    var retDiff = adapter.GetData(sessionID, docID);
                    var diff = retDiff.Count > 0 ? retDiff[0].Diff_Cost : 0.00;

                    ThreadSafeDelegate(() =>
                    {
                        tbDiff.Text = string.Format("{0:f2}", diff);
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Ошибка при загрузке суммы расхождений:", ex);
            }
        }

        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }

        private void tbDiff_Leave(object sender, EventArgs e)
        {
            var sDiff = tbDiff.Text
                   .Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                   .Replace(",", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            double diff;
            if (double.TryParse(sDiff, out diff))
                tbDiff.Text = string.Format("{0:f2}", diff);
        }

        private void btnSaveDiff_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbDiff.Text))
                    return;

                var sDiff = tbDiff.Text
                    .Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    .Replace(",", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                double diff;
                if (!double.TryParse(sDiff, out diff))
                    throw new Exception("Сумма расхождений должна быть числом.");

                using (var adapter = new Data.InventoryTableAdapters.pr_FI1_Calcs4_Shape_Get_DiffCostTableAdapter())
                    adapter.Edit(sessionID, docID, diff);
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Ошибка при сохранении суммы расхождений:", ex);
                tbDiff.Focus();
                tbDiff.SelectAll();
            }
        }

        #endregion
    }
}
