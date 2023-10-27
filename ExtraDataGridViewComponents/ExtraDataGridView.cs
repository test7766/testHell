using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls.ExtraPopupDateEditor;
using System.Diagnostics;
using WMSOffice.Controls.DataGridViewPageNavigatorComponents;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Controls.ExtraDataGridViewComponents
{
    public partial class ExtraDataGridView : UserControl
    {
        private const int FILTER_HEIGHT = 25;

        /// <summary>
        /// Сессия пользователя
        /// </summary>
        public Int64 UserID { get; set; }

        /// <summary>
        /// Представление данных
        /// </summary>
        private IDataView dataView;
        public IDataView DataView { get { return this.dataView; } }

        /// <summary>
        /// Компонент постраничного просмотра данных
        /// </summary>
        private DataGridViewPageNavigator dgvPageNavigator = null;

        public bool HasPageNavigator { get { return dgvPageNavigator != null; } }

        /// <summary>
        /// Возвращает основной грид
        /// </summary>
        public readonly DataGridView DataGrid = null;

        /// <summary>
        /// Возвращает грид фильтрации
        /// </summary>
        public readonly DataGridView FilterGrid = null;

        /// <summary>
        /// Возвращает грид итогов
        /// </summary>
        public readonly DataGridView SummaryGrid = null;

        /// <summary>
        /// Выделенная строка
        /// </summary>
        public DataRow SelectedItem
        {
            get { return dgvMain.SelectedRows.Count != 0 ? (dgvMain.SelectedRows[0].DataBoundItem as DataRowView).Row : null; }
        }

        /// <summary>
        /// Выделенные строки
        /// </summary>
        public List<DataRow> SelectedItems
        {
            get
            {
                List<DataRow> lstRows = new List<DataRow>();
                foreach (DataGridViewRow row in dgvMain.SelectedRows)
                    lstRows.Add((row.DataBoundItem as DataRowView).Row);

                return lstRows;
            }
        }

        /// <summary>
        /// Признак наличия отображения итогов
        /// </summary>
        public bool AllowSummary
        {
            set { dgvSummary.Visible = value; }
        }

        /// <summary>
        /// Признак наличия отображения фильтра
        /// </summary>
        public bool AllowFilter
        {
            set { dgvFilter.Visible = value; }
        }

        /// <summary>
        /// Признак возможности переставлять колонки
        /// </summary>
        public bool AllowRangeColumns
        {
            set { dgvMain.AllowUserToOrderColumns = value; }
        }

        /// <summary>
        /// Возможность сортировки
        /// </summary>
        public bool AllowSort { get; set; }

        /// <summary>
        /// Активация режима множественной выборки строк
        /// </summary>
        public bool UseMultiSelectMode
        {
            set { dgvMain.MultiSelect = value; }
        }

        /// <summary>
        /// Признак наличия записей в отфильтрованном представлении
        /// </summary>
        public bool HasRows
        {
            get { return this.dataView.Data != null && this.dataView.Data.DefaultView.Count > 0; }
        }

        /// <summary>
        /// Тип границ между ячейками
        /// </summary>
        public DataGridViewCellBorderStyle CellBorderStyle
        {
            get { return dgvMain.CellBorderStyle; }
            set { dgvMain.CellBorderStyle = value; }
        }

        /// <summary>
        /// True если в таблице планируется отображать большие объемы информации (тысячи/десятки тысяч строк),
        /// False если в таблице будет отображаться немного строк
        /// </summary>
        private bool largeAmountOfData;

        /// <summary>
        /// True если в таблице планируется отображать большие объемы информации (тысячи/десятки тысяч строк),
        /// False если в таблице будет отображаться немного строк
        /// </summary>
        public bool LargeAmountOfData
        {
            get { return largeAmountOfData; }
            set
            {
                dgvMain.RowHeadersWidthSizeMode = value ? DataGridViewRowHeadersWidthSizeMode.EnableResizing :
                    DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                dgvMain.RowHeadersVisible = !value;
                largeAmountOfData = value;
            }
        }

        /// <summary>
        /// True, если нужно отображать заголовки строк, False если не нужно
        /// </summary>
        public bool RowHeadersVisible
        {
            get { return dgvMain.RowHeadersVisible; }
            set { dgvMain.RowHeadersVisible = false; }
        }

        /// <summary>
        /// Номер первой отображаемой строки, учитывая прокрутку
        /// </summary>
        public int FirstDisplayedScrollingRowIndex { get { return dgvMain.FirstDisplayedScrollingRowIndex; } }

        /// <summary>
        /// True если сортировка в гриде запрещена, False если разрешена
        /// </summary>
        public bool IsSortingDisabled { get; private set; }

        /// <summary>
        /// Запрет сортировки в гриде
        /// </summary>
        public void DisableSorting()
        {
            foreach (DataGridViewColumn column in dgvMain.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            IsSortingDisabled = true;
        }

        #region СОБЫТИЯ
        /// <summary>
        /// Двойной клик на строке
        /// </summary>
        public event DataGridViewCellEventHandler OnRowDoubleClick
        {
            add { dgvMain.CellDoubleClick += value; }
            remove { dgvMain.CellDoubleClick -= value; }
        }

        /// <summary>
        /// Клик по ячейке
        /// </summary>
        public event DataGridViewCellEventHandler OnCellContentClick
        {
            add { dgvMain.CellContentClick += value; }
            remove { dgvMain.CellContentClick -= value; }
        }

        /// <summary>
        /// Смена фокуса строки
        /// </summary>
        public event EventHandler OnRowSelectionChanged
        {
            add { dgvMain.SelectionChanged += value; }
            remove { dgvMain.SelectionChanged -= value; }
        }

        /// <summary>
        /// Форматирование ячейки
        /// </summary>
        public event DataGridViewCellFormattingEventHandler OnFormattingCell
        {
            add { dgvMain.CellFormatting += value; }
            remove { dgvMain.CellFormatting -= value; }
        }

        /// <summary>
        /// Завершение пивязки к источнику данных
        /// </summary>
        public event DataGridViewBindingCompleteEventHandler OnDataBindingComplete
        {
            add { dgvMain.DataBindingComplete += value; }
            remove { dgvMain.DataBindingComplete -= value; }
        }

        /// <summary>
        /// Обработка ошибок
        /// </summary>
        public event DataGridViewDataErrorEventHandler OnDataError
        {
            add { dgvMain.DataError += value; }
            remove { dgvMain.DataError -= value; }
        }

        /// <summary>
        /// Изменение фильтра
        /// </summary>
        public event EventHandler OnFilterChanged;

        /// <summary>
        /// Деактивация компонента фильтрации
        /// </summary>
        public event KeyEventHandler OnFilterLeave
        {
            add { dgvFilter.KeyDown += value; }
            remove { dgvFilter.KeyDown -= value; }
        }

        /// <summary>
        /// Выбор значения из справочника
        /// </summary>
        public event KeyEventHandler OnRowSelected
        {
            add { dgvMain.KeyDown += value; }
            remove { dgvMain.KeyDown -= value; }
        }

        public event MouseEventHandler OnMouseDown
        {
            add { dgvMain.MouseDown += value; }
            remove { dgvMain.MouseDown -= value; }
        }

        public event MouseEventHandler OnMouseMove
        {
            add { dgvMain.MouseMove += value; }
            remove { dgvMain.MouseMove -= value; }
        }

        /// <summary>
        /// Расчет итогов по правилу заданному пользователем
        /// </summary>
        public event EventHandler<СustomSummaryCalculationEventArgs> OnCustomSummaryCalculation;

        /// <summary>
        /// Выбор / Отмена выбора всех строк одновременно
        /// </summary>
        public event EventHandler<DataGridViewCheckBoxHeaderCellEventArgs> OnMultiRowsSelectionChanged;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public ExtraDataGridView()
        {
            InitializeComponent();

            this.AllowSort = true;

            dgvMain.AutoGenerateColumns = false;
            dgvFilter.AutoGenerateColumns = false;
            dgvSummary.AutoGenerateColumns = false;

            this.DataGrid = this.dgvMain;
            this.FilterGrid = this.dgvFilter;
            this.SummaryGrid = this.dgvSummary;

            miClearFilter.Image = Properties.Resources.filter_remove;

            //dgvFilter.DataError += new DataGridViewDataErrorEventHandler(dgvFilter_DataError);
        }

        //void dgvFilter_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    e.ThrowException = false;
        //    e.Cancel = true;
        //}

        public void Init(IDataView dataView, bool createSchema)
        {
            if (createSchema)
                this.Clear();

            this.dataView = dataView;

            if (createSchema)
            {
                this.CreateColumns(this.dataView.Columns);

                dgvFilter.Rows.Add(1);
                dgvFilter.Rows[0].Height = FILTER_HEIGHT;

                dgvSummary.Rows.Add(1);
            }

            if (IsSortingDisabled)
                DisableSorting();

            if (this.HasPageNavigator)
                dgvPageNavigator.ClearSort();
        }

        #endregion

        /// <summary>
        /// Создание основной колонки отображения
        /// </summary>
        /// <param name="columnType">Тип колонки</param>
        /// <returns></returns>
        private DataGridViewColumn CreateGeneralDataColumn(PatternColumn patternColumn)
        {
            DataGridViewColumn column;

            if (patternColumn is ImagePatternColumn)
            {
                column = new DataGridViewImageColumn();
                column.DefaultCellStyle.NullValue = null;
                return column;
            }

            if (patternColumn is SelectorPatternColumn)
            {
                column = new DataGridViewCheckBoxColumn();
                column.HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
                ((DatagridViewCheckBoxHeaderCell)column.HeaderCell).CheckBoxClicked += (s, e) =>
                {
                    if (OnMultiRowsSelectionChanged != null)
                        OnMultiRowsSelectionChanged(column, new DataGridViewCheckBoxHeaderCellEventArgs(e.IsChecked));
                };

                return column;
            }

            switch (patternColumn.Type)
            {
                case ColumnType.Text:
                    column = new DataGridViewTextBoxColumn();
                    break;
                case ColumnType.Logical:
                    column = new DataGridViewCheckBoxColumn();
                    break;
                case ColumnType.List:
                    column = new DataGridViewComboBoxColumn();
                    break;
                case ColumnType.Image:
                    column = new DataGridViewImageColumn();
                    break;
                case ColumnType.Action:
                    column = new DataGridViewButtonColumn();
                    break;
                default:
                    column = new DataGridViewTextBoxColumn();
                    break;
            }
            return column;
        }

        /// <summary>
        /// Создание колонки для фильтра
        /// </summary>
        /// <param name="patternColumn"></param>
        /// <returns></returns>
        private DataGridViewColumn CreateFilterColumn(PatternColumn patternColumn)
        {
            if (patternColumn.HasQuickFilter)
            {
                DataGridViewColumn column = null;
                if (patternColumn.HasQuickFilterValueReference)
                    column = new DataGridSearchTextBoxColumn();
                else if (patternColumn.HasQuickFilterDateComparer)
                    column = new ExtraPopupDateEditorColumn();
                else if (patternColumn.HasQuickFilterBoolCompare)
                    column = new DataGridViewCheckBoxColumn() { ThreeState = true };
                else
                    column = new DataGridViewTextBoxColumn();

                return column;
            }
            else
            {
                //DataGridViewImageColumn column = new DataGridViewImageColumn();
                //column.Image = WMSOffice.Properties.Resources.cancel;
                //return column;

                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.ReadOnly = true;
                column.DefaultCellStyle.BackColor = SystemColors.ScrollBar;
                column.DefaultCellStyle.SelectionBackColor = SystemColors.ScrollBar;
                return column;
            }
        }

        private void dgvFilter_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFilter.CurrentCell is DataGridViewCheckBoxCell)
                dgvFilter.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        /// Очистка отображения табличного представления
        /// </summary>
        public void Clear()
        {
            dgvFilter.EndEdit();
            dgvFilter.Columns.Clear();
            dgvFilter.Rows.Clear();

            dgvMain.EndEdit();
            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();

            dgvSummary.EndEdit();
            dgvSummary.Columns.Clear();
            dgvSummary.Rows.Clear();

            this.dataView = null;
        }

        /// <summary>
        /// Привязка данных
        /// </summary>
        public void BindData(bool needToRecreateSchema)
        {
            this.BindData(needToRecreateSchema, null);
        }

        public void BindData(bool needToRecreateSchema, FilterStorage activeFilter)
        {
            this.AdaptData(this.dataView.Data, needToRecreateSchema, activeFilter);
        }

        /// <summary>
        /// Адаптация данных
        /// </summary>
        /// <param name="source"></param>
        private void AdaptData(DataTable source, bool needToRecreateSchema)
        {
            this.AdaptData(source, needToRecreateSchema, null);
        }

        private void AdaptData(DataTable source, bool needToRecreateSchema, FilterStorage activeFilter)
        {
            if (needToRecreateSchema)
                this.Init(this.dataView, true);

            //if (this.HasPageNavigator)
            //    dgvPageNavigator.DataSource = source;
            //else
            //    this.dgvMain.DataSource = source;

            if (activeFilter != null)
                this.ApplyFilter(activeFilter);

            if (!this.HasPageNavigator)
                this.dgvMain.DataSource = source;

            this.ApplyFilter();
            this.RecalculateSummary();
        }

        /// <summary>
        /// Вернуть фокус на главное отображение
        /// </summary>
        public void NavigateToData()
        {
            this.dgvMain.Focus();
        }

        /// <summary>
        /// Создание колонок для отображения представления
        /// </summary>
        /// <param name="columns"></param>
        private void CreateColumns(PatternColumnsCollection columns)
        {
            string columnNamePattern = string.Empty;
            foreach (PatternColumn column in columns)
            {
                columnNamePattern = column.DataFieldName.Replace(" ", "").TrimStart('[').TrimEnd(']');

                #region ФОРМИРОВАНИЕ КОЛОНОК ОСНОВНОГО ГРИДА
                DataGridViewColumn columnMainGrid = this.CreateGeneralDataColumn(column);
                columnMainGrid.Name = "dgvMain_" + columnNamePattern; //column.Name;

                if (column is ImagePatternColumn)
                    columnMainGrid.Tag = (column as ImagePatternColumn).LinkedDataFieldName;
                else
                    columnMainGrid.DataPropertyName = column.DataFieldName;

                columnMainGrid.HeaderText = column.Caption;

                if (column.UseDecimalNumbersAlignment)
                {
                    columnMainGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    columnMainGrid.DefaultCellStyle.Format = string.IsNullOrEmpty(column.Format) ? "N2" : column.Format;
                }

                if (column.UseIntegerNumbersAlignment)
                {
                    columnMainGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    columnMainGrid.DefaultCellStyle.Format = "N0";
                }

                if (column.Width == null)
                    columnMainGrid.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                else
                    columnMainGrid.Width = column.Width.Value;

                columnMainGrid.ReadOnly = column.ReadOnly;

                if (column is SelectorPatternColumn)
                    columnMainGrid.Frozen = true;

                if (!column.AllowSort || !this.AllowSort)
                    columnMainGrid.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (column.Hidden)
                    columnMainGrid.Visible = false;

                if (column.IsFrozen)
                    columnMainGrid.Frozen = true;

                dgvMain.Columns.Add(columnMainGrid);

                #endregion

                #region ФОРМИРОВАНИЕ КОЛОНОК ГРИДА ФИЛЬТРАЦИИ
                DataGridViewColumn columnFilterGrid = this.CreateFilterColumn(column);
                columnFilterGrid.DataPropertyName = column.DataFieldName;
                columnFilterGrid.Width = columnMainGrid.Width;
                columnFilterGrid.Name = "dgvFilter_" + columnNamePattern;

                if (column is SelectorPatternColumn)
                    columnFilterGrid.Frozen = true;

                if (column.Hidden)
                    columnFilterGrid.Visible = false;

                if (column.IsFrozen)
                    columnFilterGrid.Frozen = true;

                dgvFilter.Columns.Add(columnFilterGrid);
                #endregion

                #region ФОРМИРОВАНИЕ КОЛОНОК ГРИДА-СУММАТОРА
                DataGridViewColumn columnSummaryGrid = new DataGridViewTextBoxColumn();
                columnSummaryGrid.DataPropertyName = column.DataFieldName;
                columnSummaryGrid.Width = columnMainGrid.Width;
                columnSummaryGrid.Name = "dgvSummary_" + columnNamePattern;

                if (column.UseDecimalNumbersAlignment)
                {
                    columnSummaryGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    columnSummaryGrid.DefaultCellStyle.Format = string.IsNullOrEmpty(column.Format) ? "N2" : column.Format;
                }

                if (column.UseIntegerNumbersAlignment)
                {
                    columnSummaryGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    columnSummaryGrid.DefaultCellStyle.Format = "N0";
                }

                if (column is SelectorPatternColumn)
                    columnSummaryGrid.Frozen = true;

                if (column.Hidden)
                    columnSummaryGrid.Visible = false;

                if (column.IsFrozen)
                    columnSummaryGrid.Frozen = true;

                dgvSummary.Columns.Add(columnSummaryGrid);
                #endregion
            }
        }

        #region СИНХРОНИЗАЦИЯ ПРОКРУТКИ И РАЗМЕРОВ КОЛОНОК ОСНОВОГО ОТОБРАЖЕНИЯ ПРЕДСТАВЛЕНИЯ И СЛУЖЕБНЫХ (ФИЛЬТРЫ, ИТОГИ)
        private void dgvMain_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvFilter.HorizontalScrollingOffset = e.NewValue;
                    dgvFilter.Refresh();

                    dgvSummary.HorizontalScrollingOffset = e.NewValue;
                    dgvSummary.Refresh();
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvFilter_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvMain.HorizontalScrollingOffset = e.NewValue;
                    dgvMain.Refresh();
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvSummary_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvMain.HorizontalScrollingOffset = e.NewValue;
                    dgvMain.Refresh();
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvMain_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (dgvFilter.Columns.Count > e.Column.Index)
            {
                dgvFilter.Columns[e.Column.Index].Width = e.Column.Width;
                //dgvFilter.Refresh();

                dgvSummary.Columns[e.Column.Index].Width = e.Column.Width;
                //dgvSummary.Refresh();
            }
        }
        #endregion

        #region ПРИМЕНЕНИЕ ФИЛЬТРАЦИИ

        /// <summary>
        /// Структура фильтров, заданных на свойствах таблицы
        /// </summary>
        private readonly Dictionary<string, string> propertyFilters = new Dictionary<string, string>();

        /// <summary>
        /// Признак установленного фильтра
        /// </summary>
        public bool HasFilter
        {
            get { return !string.IsNullOrEmpty(this.dataView.Data.DefaultView.RowFilter); }
        }

        /// <summary>
        /// Структура фильтров, заданных на свойствах таблицы
        /// </summary>
        public Dictionary<string, string> PropertyFilters { get { return propertyFilters; } }

        private void dgvFilter_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is SearchTextBoxCellEditorControl)
            {
                var control = e.Control as SearchTextBoxCellEditorControl;
                control.ValueReferenceQuery = (this.dataView.Columns[dgvFilter.CurrentCell.OwningColumn.Index].Filter as FilterValueReferenceExpressionRule).ValueReferenceQuery;
                control.UserID = this.UserID;

                control.OnVerifyValue -= new VerifyValueHandler(control_OnVerifyValue);
                control.OnVerifyValue += new VerifyValueHandler(control_OnVerifyValue);
            }
        }

        void control_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            if (e.Success)
                (sender as SearchTextBoxCellEditorControl).Value = e.Value;
        }

        private void dgvFilter_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!lockFilter)
                this.ApplyFilter();
        }

        /// <summary>
        /// Получить выражение фильтрации
        /// </summary>
        /// <returns></returns>
        private String GetFilterExpression()
        {
            propertyFilters.Clear();

            String filter;
            StringBuilder sbFilterExpression = new StringBuilder();

            int i = 0;
            foreach (PatternColumn column in this.dataView.Columns)
            {
                string filterStr = column.GetFilterExpression(this.dgvFilter.Rows[0].Cells[i].Value);
                if (column.HasQuickFilter && (filter = filterStr) != null)
                    sbFilterExpression.AppendFormat("{0} Σ ", filter);

                i++;

                string val = GetRightPartOfTheFilter(column, filterStr);
                if (!String.IsNullOrEmpty(val))
                    propertyFilters.Add(column.DataFieldName, val);
            }

            filter = sbFilterExpression.Length > 0 ? sbFilterExpression.ToString().Trim().TrimEnd('Σ').Replace("Σ", "AND") : string.Empty;
            return filter;
        }

        /// <summary>
        /// Получение правой части фильтра в виде:
        /// Если фильтр по подстроке, то %строка%
        /// Если фильтр по числу/дате и введен NULL, то null
        /// Если фильтр по числу/дате и операция: =значение, >значение и т.д.
        /// </summary>
        /// <param name="pCol">Колонка, которая фильтруется</param>
        /// <param name="pFilterExp">Строка фильтра</param>
        /// <returns>Правая часть фильтра (этот метод сделан для того, чтобы получать текущие значения фильтров из грида)</returns>
        private string GetRightPartOfTheFilter(PatternColumn pCol, string pFilterExp)
        {
            if (String.IsNullOrEmpty(pFilterExp))
                return null;

            var filterWithoutField = String.Empty;
            if (pCol.Filter is FilterEmptyExpressionRule)
                return null;
            else if (pCol.Filter is FilterPatternExpressionRule)
            {
                filterWithoutField = pFilterExp.Replace("[" + pCol.DataFieldName + "] LIKE '", String.Empty); // Убираем левую часть фильтра
                return filterWithoutField.Substring(0, filterWithoutField.Length - 1);  // Убираем последний апостроф
            }
            else // Это значит, что фильтр по дате либо числу
            {
                filterWithoutField = pFilterExp.Replace("[" + pCol.DataFieldName + "] ", String.Empty); // Убираем левую часть фильтра
                var oper = filterWithoutField.Substring(0, 2);
                switch (oper)
                {
                    case "= ":
                    case "> ":
                    case "< ":
                        filterWithoutField = filterWithoutField.Substring(2);
                        if (pCol.Filter is FilterDateCompareExpressionRule)
                            filterWithoutField = filterWithoutField.Substring(1, filterWithoutField.Length - 2);
                        return oper[0].ToString() + filterWithoutField;
                    case "<>":
                        filterWithoutField = filterWithoutField.Substring(3);
                        if (pCol.Filter is FilterDateCompareExpressionRule)
                            filterWithoutField = filterWithoutField.Substring(1, filterWithoutField.Length - 2);
                        return oper.Substring(0, 2) + filterWithoutField;
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Вернуть фокус на фильтр
        /// </summary>
        public void NavigateToFilter()
        {
            this.dgvFilter.Focus();
            //this.dgvFilter.BeginEdit(true);
        }

        /// <summary>
        /// Задействовать фильтр
        /// </summary>
        private void ApplyFilter()
        {
            try
            {
                if (this.dataView.Data != null)
                {
                    string filterExp = GetFilterExpression();
                    this.dataView.Data.DefaultView.RowFilter = filterExp;

                    if (this.HasPageNavigator)
                    {
                        var dtFilteredData = this.dataView.Data.Clone();
                        dtFilteredData.Merge(this.dataView.Data.DefaultView.ToTable());

                        dtFilteredData.DefaultView.RowFilter = this.dataView.Data.DefaultView.RowFilter;
                        dtFilteredData.DefaultView.Sort = this.dataView.Data.DefaultView.Sort;

                        dgvPageNavigator.DataSource = dtFilteredData;
                    }
                }
            }
            catch
            {

            }

            if (this.OnFilterChanged != null)
                this.OnFilterChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Установка фильтра
        /// </summary>
        /// <param name="filterStorage"></param>
        public void ApplyFilter(FilterStorage filterStorage)
        {
            foreach (var filterItem in filterStorage)
                this.ApplyFilter(filterItem.DataFieldName, filterItem.Value);
        }

        /// <summary>
        /// Установка фильтра
        /// </summary>
        /// <param name="dataFieldName">Поле данных</param>
        /// <param name="filterValue">Значение фильтра</param>
        public void ApplyFilter(string dataFieldName, string filterValue)
        {
            foreach (DataGridViewColumn column in this.dgvFilter.Columns)
            {
                if (column.DataPropertyName == dataFieldName)
                    this.dgvFilter.Rows[0].Cells[column.Name].Value = filterValue;
            }
        }

        /// <summary>
        /// Возвращает фильтр для запоминания
        /// </summary>
        /// <returns></returns>
        public FilterStorage GetFilterStorage()
        {
            var storage = new FilterStorage();
            foreach (DataGridViewColumn column in this.dgvFilter.Columns)
                if (!column.ReadOnly)
                {
                    var value = this.dgvFilter.Rows[0].Cells[column.Index].Value;
                    if (value != null)
                        storage.Add(new FilterItem(column.DataPropertyName, value.ToString()));
                }

            return storage;
        }

        /// <summary>
        /// Активация фильтра
        /// </summary>
        public void ActivateFilter()
        {
            this.ApplyFilter();
        }

        private void miClearFilter_Click(object sender, EventArgs e)
        {
            if (!lockFilter)
                this.ClearFilter();
        }

        /// <summary>
        /// Блокировка фильтра (оптимизация производительности)
        /// </summary>
        private bool lockFilter = false;

        /// <summary>
        /// Очистка фильтра
        /// </summary>
        public void ClearFilter()
        {
            lockFilter = true;

            foreach (DataGridViewCell cell in this.dgvFilter.Rows[0].Cells)
                if (cell.Visible)
                    cell.Value = cell is DataGridViewCheckBoxCell ? (object)CheckState.Indeterminate : (object)string.Empty;

            lockFilter = false;

            this.ApplyFilter();
            this.RecalculateSummary();
        }

        /// <summary>
        /// Очистка коллекции строк
        /// </summary>
        public void ClearItems()
        {
            this.dgvMain.DataSource = null;

            if (this.HasPageNavigator)
                dgvPageNavigator.DataSource = null;
        }

        private void dgvFilter_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgvFilter.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                this.dgvFilter.CurrentCell = this.dgvFilter.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.dgvFilter.BeginEdit(true);
            }
        }
        #endregion

        /// <summary>
        /// Пересчет итоговых значений
        /// </summary>
        public void RecalculateSummary()
        {
            if (this.DataView.Data == null)
                return;

            int i = 0;
            string filterExpression = this.GetFilterExpression();
            System.Data.DataView view = null;
            System.Data.DataRow[] rows = null;
            try
            {
                view = new System.Data.DataView(this.dataView.Data, filterExpression, "", DataViewRowState.CurrentRows);
                rows = this.dataView.Data.Select(filterExpression, "");
            }
            catch
            {
                filterExpression = "";
                view = new System.Data.DataView(this.dataView.Data, filterExpression, "", DataViewRowState.CurrentRows);
                rows = this.dataView.Data.Select(filterExpression, "");
            }

            foreach (PatternColumn column in this.dataView.Columns)
            {
                view.RowFilter = filterExpression;

                switch (column.SummaryCalculationType)
                {
                    case SummaryCalculationType.Count:
                        decimal count = 0;
                        view.RowFilter = string.Format("{0} [{1}] IS NOT NULL", string.IsNullOrEmpty(filterExpression) ? "" : filterExpression + " AND ", column.DataFieldName);

                        //count = view.ToTable(true, column.DataFieldName).Rows.Count; // не рационально

                        var dicUniqueValues = new Dictionary<object, object>();
                        var rowsWithValue = view.Table.Select(view.RowFilter);
                        foreach (var row in rowsWithValue)
                        {
                            var value = row[column.DataFieldName];
                            dicUniqueValues[value] = value;
                        }
                        count = dicUniqueValues.Count;

                        this.dgvSummary.Rows[0].Cells[i].Value = count;
                        break;
                    case SummaryCalculationType.Sum:
                        decimal sum = 0;
                        foreach (DataRow row in rows)
                            if (row[column.DataFieldName] != DBNull.Value)
                                sum += Convert.ToDecimal(row[column.DataFieldName]);
                        this.dgvSummary.Rows[0].Cells[i].Value = sum;
                        break;
                    case SummaryCalculationType.TotalRecords:
                        this.dgvSummary.Rows[0].Cells[i].Value = rows.Length;
                        break;
                    case SummaryCalculationType.Custom:
                        var fullTableRows = view.Table.Select(view.RowFilter);
                        var truncatedTableRows = view.ToTable(true, column.DataFieldName).Select();

                        if (OnCustomSummaryCalculation != null)
                            OnCustomSummaryCalculation(this, new СustomSummaryCalculationEventArgs(this.dgvSummary.Rows[0].Cells[i], column, fullTableRows, truncatedTableRows));
                        break;
                    case SummaryCalculationType.None:
                    default:
                        break;
                }

                i++;
            }
        }

        /// <summary>
        /// Подстройка размещения колонок дополнительных гридов при изменении их размещения в основном соответственно
        /// </summary>
        private void dgvMain_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //if (e.Column.Index < this.dgvFilter.Columns.Count)
            this.dgvFilter.Columns[e.Column.Index].DisplayIndex = e.Column.DisplayIndex;
            //if (e.Column.Index < this.dgvSummary.Columns.Count)
            this.dgvSummary.Columns[e.Column.Index].DisplayIndex = e.Column.DisplayIndex;
        }

        /// <summary>
        /// Загрузка пользовательских настроек основоного грида
        /// </summary>
        /// <param name="ownerName"></param>
        public void LoadExtraDataGridViewSettings(string ownerName)
        {
            try
            {
                Config.LoadDataGridViewSettings(ownerName, this.dgvMain);
            }
            catch { }
        }

        /// <summary>
        /// Сохранение пользовательских настроек основоного грида
        /// </summary>
        /// <param name="ownerName"></param>
        public void SaveExtraDataGridViewSettings(string ownerName)
        {
            Config.SaveDataGridViewSettings(ownerName, this.dgvMain);
        }


        /// <summary>
        /// Экспорт таблицы в Excel-файл, перед этим указав имя файла
        /// </summary>
        /// <param name="pDialogTitle">Название диалогового окна с выбором файла, в который произвести экспорт</param>
        /// <param name="pFileNamePart">Часть названия файла с экспортированными данными по умолчанию 
        /// <param name="pOpenExportedDoc">True, если нужно после экспорта открыть окно с экспортированным документом, 
        public void ExportToExcel(string pDialogTitle, string pFileNamePart, bool pOpenExportedDoc)
        {
            this.ExportToExcel(pDialogTitle, pFileNamePart, pOpenExportedDoc, null);
        }

        /// <summary>
        /// Экспорт таблицы в Excel-файл, перед этим указав имя файла
        /// </summary>
        /// <param name="pDialogTitle">Название диалогового окна с выбором файла, в который произвести экспорт</param>
        /// <param name="pFileNamePart">Часть названия файла с экспортированными данными по умолчанию 
        /// <param name="pOpenExportedDoc">True, если нужно после экспорта открыть окно с экспортированным документом, 
        /// <param name="ignorableColumns">Исключаемые с экспорта колонки 
        /// False в противном случае</param>
        /// (название файла формируется следующим образом: код+название, где код формируется из текущей даты/времени и является уникальным)</param>
        public void ExportToExcel(string pDialogTitle, string pFileNamePart, bool pOpenExportedDoc, List<string> ignorableColumns)
        {
            DateTime now = DateTime.Now;
            var dialog = new SaveFileDialog()
            {
                FileName = String.Format("{0}{1}{2}{3}{4}{5}-{6}", now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'), pFileNamePart),
                Title = pDialogTitle,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Текстовый файл с разделителями (*.csv)|*.csv",
                FilterIndex = 0,
                AddExtension = true,
                DefaultExt = "csv"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dialog.FileName, ignorableColumns);
                if (pOpenExportedDoc)
                    Process.Start(dialog.FileName);
            }
        }

        /// <summary>
        /// Экспорт текущего представления в Excel-файл
        /// </summary>
        /// <param name="filePath"></param>
        public void ExportToExcel(string filePath)
        {
            this.ExportToExcel(filePath, null);
        }

        /// <summary>
        /// Экспорт текущего представления в Excel-файл
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ignorableColumns"></param>
        public void ExportToExcel(string filePath, List<string> ignorableColumns)
        {
            using (var sw = new System.IO.StreamWriter(filePath, false, Encoding.Default))
            {
                List<string> lstColumnNames = new List<string>();
                foreach (DataGridViewColumn column in this.dgvMain.Columns)
                    if (column.Visible && !(column is DataGridViewImageColumn) && (ignorableColumns != null && !ignorableColumns.Contains(column.DataPropertyName)))
                        lstColumnNames.Add(column.Name);

                // создание отсортированного по DisplayIndex списка столбцов
                for (int i = 0; i < lstColumnNames.Count; i++)
                    for (int j = i + 1; j < lstColumnNames.Count; j++)
                        if (this.dgvMain.Columns[lstColumnNames[i]].DisplayIndex > this.dgvMain.Columns[lstColumnNames[j]].DisplayIndex)
                        {
                            string tmp = lstColumnNames[i];
                            lstColumnNames[i] = lstColumnNames[j];
                            lstColumnNames[j] = tmp;
                        }

                // заголовки
                for (int i = 0; i < lstColumnNames.Count; i++)
                {
                    sw.Write("\"" + dgvMain.Columns[lstColumnNames[i]].HeaderText.Replace(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator, string.Empty).Replace("\"", "'") + "\"");

                    if (i < lstColumnNames.Count - 1)
                        sw.Write(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }

                sw.Write(sw.NewLine);

                // строки с данными
                if (this.HasPageNavigator)
                {
                    var dtFilteredData = this.dataView.Data.DefaultView.ToTable();

                    foreach (DataRow row in dtFilteredData.Rows)
                    {
                        for (int i = 0; i < lstColumnNames.Count; i++)
                        {
                            try
                            {
                                var dataPropertyName = dgvMain.Columns[lstColumnNames[i]].DataPropertyName;
                                if (!Convert.IsDBNull(row[dataPropertyName]) && row[dataPropertyName] != null && !string.IsNullOrEmpty(row[dataPropertyName].ToString()))
                                    sw.Write("\"" + row[dataPropertyName].ToString().Replace(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator, string.Empty).Replace("\"", "'") + "\"");
                                else
                                    sw.Write("\" \"");

                                if (i < lstColumnNames.Count - 1)
                                    sw.Write(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }

                        sw.Write(sw.NewLine);
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in this.dgvMain.Rows)
                    {
                        for (int i = 0; i < lstColumnNames.Count; i++)
                        {
                            try
                            {
                                if (!Convert.IsDBNull(row.Cells[lstColumnNames[i]].Value) && row.Cells[lstColumnNames[i]].Value != null && !string.IsNullOrEmpty(row.Cells[lstColumnNames[i]].Value.ToString()))
                                    sw.Write("\"" + row.Cells[lstColumnNames[i]].Value.ToString().Replace(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator, string.Empty).Replace("\"", "'") + "\"");
                                else
                                    sw.Write("\" \"");

                                if (i < lstColumnNames.Count - 1)
                                    sw.Write(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }

                        sw.Write(sw.NewLine);
                    }
                }

                sw.Close();
            }
        }

        /// <summary>
        /// Установка точно такого же стиля для альтернативных строк как и для основных
        /// </summary>
        public void SetSameStyleForAlternativeRows()
        {
            this.dgvMain.AlternatingRowsDefaultCellStyle.BackColor = this.dgvMain.RowsDefaultCellStyle.BackColor;
        }

        /// <summary>
        /// Выделение в гриде строки с заданным значением индекса
        /// </summary>
        /// <param name="index"></param>
        public void SelectRow(int index)
        {
            if (dgvMain.Rows.Count > index)
                dgvMain.Rows[index].Selected = true;
        }

        /// <summary>
        /// Выделение в гриде строки с заданным значением заданного свойства
        /// </summary>
        /// <param name="pPropertyName">Название свойства, по которому будет производится поиск строки для выделения</param>
        /// <param name="pValue">Значение свойства, если у строки такое значение, то она будет выделена</param>
        public bool SelectRow(string pPropertyName, string pValue)
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
                if ((row.DataBoundItem as DataRowView).Row[pPropertyName].ToString() == pValue)
                {
                    row.Selected = true;
                    return true;
                }

            return false;
        }

        /// <summary>
        /// Выделение в гриде строки с заданными значениями заданного свойства
        /// </summary>
        /// <param name="pProperty1Name">Название первого свойства</param>
        /// <param name="pValue1">Значение первого свойства</param>
        /// <param name="pProperty1Name">Название второго свойства</param>
        /// <param name="pValue1">Значение второго свойства</param>
        public void SelectRow(string pProperty1Name, string pValue1, string pProperty2Name, string pValue2)
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
                if ((row.DataBoundItem as DataRowView).Row[pProperty1Name].ToString() == pValue1 &&
                    (row.DataBoundItem as DataRowView).Row[pProperty2Name].ToString() == pValue2)
                {
                    row.Selected = true;
                    break;
                }
        }

        /// <summary>
        /// Снимает выделение со всех выделенных строк в таблице
        /// </summary>
        public void UnselectAllRows()
        {
            dgvMain.ClearSelection();
        }

        /// <summary>
        /// Скроллинг грида к заданной строке
        /// </summary>
        /// <param name="pRowIndex">Индекс строки, к которой нужно "прокрутить" грид</param>
        public void ScrollToRow(int pRowIndex)
        {
            if (dgvMain.RowCount > pRowIndex && pRowIndex >= 0)
                dgvMain.FirstDisplayedScrollingRowIndex = pRowIndex;
        }

        /// <summary>
        /// Скроллинг грида к выделенной строке
        /// </summary>
        public void ScrollToSelectedRow()
        {
            if (dgvMain.SelectedRows.Count > 0)
                dgvMain.FirstDisplayedScrollingRowIndex = dgvMain.SelectedRows[0].Index;
        }

        /// <summary>
        /// Установка стилей для ячеек грида
        /// </summary>
        /// <param name="pCellStyle">Стиль для ячеек грида</param>
        /// <param name="pHeaderStyle">Стиль для заголовка грида</param>
        public void SetCellStyles(DataGridViewCellStyle pCellStyle, DataGridViewCellStyle pHeaderStyle)
        {
            dgvMain.DefaultCellStyle = pCellStyle;
            dgvMain.ColumnHeadersDefaultCellStyle = pHeaderStyle;
        }

        #region ПОСТРАНИЧНЫЙ ПРОСМОТР СОДЕРЖИМОГО

        /// <summary>
        /// Создание постраничного просмотра данных 
        /// </summary>
        public void CreatePageNavigator()
        {
            dgvPageNavigator = new DataGridViewPageNavigator(dgvMain);
            dgvPageNavigator.OnSortData += new EventHandler<SortDataEventArgs>(dgvPageNavigator_OnSortData);
            dgvPageNavigator.Dock = DockStyle.Top;

            this.pnlDataViewNavigator.Controls.Clear();
            this.pnlDataViewNavigator.Controls.Add(dgvPageNavigator);
            this.pnlDataViewNavigator.Height = dgvPageNavigator.Height;
        }

        void dgvPageNavigator_OnSortData(object sender, SortDataEventArgs e)
        {
            if (this.dataView.Data != null)
                this.dataView.Data.DefaultView.Sort = e.Sort;
        }

        #endregion

        public bool ChangeRowPropertyValue(string pKeyName, object pKeyValue, string pPropertyName, object pPropertyValue)
        {
            var success = false;

            if (this.dataView.Data == null)
                return success;

            var arFindData = this.dataView.Data.Select(string.Format("{0} = {1}", pKeyName, pKeyValue));

            if (arFindData.Length == 0)
                return success;

            arFindData[0][pPropertyName] = pPropertyValue;
            success = true;

            if (this.HasPageNavigator)
                success = success && dgvPageNavigator.ChangeRowPropertyValue(pKeyName, pKeyValue, pPropertyName, pPropertyValue);

            return success;
        }

        public bool ChangeMultipleRowsPropertyValue(string pPropertyName, object pPropertyValue)
        {
            var success = false;

             if (this.dataView.Data == null)
                return success;

             var arFindData = this.dataView.Data.Select(this.dataView.Data.DefaultView.RowFilter);

             if (arFindData.Length == 0)
                 return success;

             foreach (DataRow findDataRow in arFindData)
                 findDataRow[pPropertyName] = pPropertyValue;

             success = true;

            if (this.HasPageNavigator)
                success = success && dgvPageNavigator.ChangeMultipleRowsPropertyValue(pPropertyName, pPropertyValue);

            return success;
        }
    }

    /// <summary>
    /// Структура для хранения информации о значении фильтра
    /// </summary>
    public class FilterItem
    {
        public string DataFieldName { get; set; }
        public string Value { get; set; }

        public FilterItem(string dataField, string value)
        {
            this.DataFieldName = dataField;
            this.Value = value;
        }
    }

    /// <summary>
    /// Класс, запоминающий последний установленный фильтр
    /// </summary>
    public class FilterStorage : List<FilterItem>
    {
        public FilterStorage()
        {

        }

        public FilterStorage(List<FilterItem> filterItems)
            : this()
        {
            this.Initialize(filterItems);
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="filterItems">Значения инициализации</param>
        public void Initialize(List<FilterItem> filterItems)
        {
            this.Clear();
            foreach (var item in filterItems)
                this.Add(item);
        }
    }

    public class СustomSummaryCalculationEventArgs : EventArgs
    {
        public DataGridViewCell TargetCell { get; private set; }
        public PatternColumn PatternСolumn { get; set; }
        public IEnumerable<DataRow> FilteredFullDataRows { get; private set; }
        public IEnumerable<DataRow> FilteredTruncatedDataRows { get; private set; }

        public СustomSummaryCalculationEventArgs(DataGridViewCell targetCell, PatternColumn patternСolumn, IEnumerable<DataRow> filteredFullDataRows, IEnumerable<DataRow> filteredTruncatedDataRows)
        {
            this.TargetCell = targetCell;
            this.PatternСolumn = patternСolumn;
            this.FilteredFullDataRows = filteredFullDataRows;
            this.FilteredTruncatedDataRows = filteredTruncatedDataRows; 
        }
    }
}
