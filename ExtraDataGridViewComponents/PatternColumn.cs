using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace WMSOffice.Controls.ExtraDataGridViewComponents
{
    /// <summary>
    /// Колонка-шаблон для представления
    /// </summary>
    public class PatternColumn
    {
        /// <summary>
        /// Имя колонки
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Заголовок колонки
        /// </summary>
        public string Caption { get; private set; }

        /// <summary>
        /// Формат колонки
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Имя поля данных колонки
        /// </summary>
        public string DataFieldName { get; private set; } 

        /// <summary>
        /// Тип отображения колонки в табличном представлении (по умолчанию обычное текстовое поле)
        /// </summary>
        public ColumnType Type { get; private set; }

        /// <summary>
        /// Ширина колонки
        /// </summary>
        public int? Width { get; set; }

        public bool Hidden { get; set; }

        /// <summary>
        /// Использовать выравнивание для чисел типа "Decimal"
        /// </summary>
        public bool UseDecimalNumbersAlignment { get; set; }

        /// <summary>
        /// Использовать выравнивание для чисел типа "Int"
        /// </summary>
        public bool UseIntegerNumbersAlignment { get; set; }

        /// <summary>
        /// Наличие быстрого фильтра над колонкой
        /// </summary>
        public bool HasQuickFilter { get { return this.Filter.GetType() != typeof(FilterEmptyExpressionRule); } }

        /// <summary>
        /// Наличие контекста поиска значений для фильтра
        /// </summary>
        public bool HasQuickFilterValueReference { get { return this.Filter.GetType() == typeof(FilterValueReferenceExpressionRule); } }

        /// <summary>
        /// Наличие фильтра для даты
        /// </summary>
        public bool HasQuickFilterDateComparer { get { return this.Filter.GetType() == typeof(FilterDateCompareExpressionRule); } }

        /// <summary>
        /// Наличие фильтра для логического значения
        /// </summary>
        public bool HasQuickFilterBoolCompare { get { return this.Filter.GetType() == typeof(FilterBoolCompareExpressionRule); } }

        /// <summary>
        /// Возможность сортировки
        /// </summary>
        public bool AllowSort { get; set; }

        /// <summary>
        /// Признак закрепления колонки
        /// </summary>
        public bool IsFrozen { get; set; }

        /// <summary>
        /// Выражение для фильтрации
        /// </summary>
        public FilterExpressionRule Filter { get; private set; }

        /// <summary>
        /// Тип расчета итоговых значений под колонкой
        /// </summary>
        public SummaryCalculationType SummaryCalculationType { get; private set; }

        private bool _readOnly = true;
        public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }

        /// <summary>
        /// Получение выражения фильтрации
        /// </summary>
        /// <returns></returns>
        public string GetFilterExpression(object value)
        {
            return this.Filter.GetFilterExpression(value);
        }

        #region КОНСТРУКТОРЫ
        public PatternColumn(string caption, string dataFieldName)
            :this(caption, dataFieldName, new FilterEmptyExpressionRule())
        {

        }

        public PatternColumn(string caption, string dataFieldName, SummaryCalculationType summaryCalculationType)
            : this(caption, dataFieldName, ColumnType.Text, new FilterEmptyExpressionRule(), summaryCalculationType)
        {

        }

        public PatternColumn(string caption, string dataFieldName, FilterExpressionRule filterRule)
            : this(caption, dataFieldName, ColumnType.Text, filterRule, SummaryCalculationType.None)
        { 
        
        }

        public PatternColumn(string caption, string dataFieldName, FilterExpressionRule filterRule, SummaryCalculationType summaryCalculationType)
            : this(caption, dataFieldName, ColumnType.Text, filterRule, summaryCalculationType) 
        { 
        
        }

        public PatternColumn(string caption, string dataFieldName, ColumnType columnType,
            FilterExpressionRule filterRule, SummaryCalculationType summaryCalculationType)
        {
            this.Caption = caption;
            this.DataFieldName = dataFieldName;
            this.Type = columnType;
            this.Filter = filterRule;
            this.SummaryCalculationType = summaryCalculationType;

            this.AllowSort = true;
        }
        #endregion
    }

    /// <summary>
    /// Коллекция колонок для представления
    /// </summary>
    public class PatternColumnsCollection : CollectionBase
    {
        /// <summary>
        /// Добавение в коллекцию новой колонки в конец
        /// </summary>
        /// <param name="сolumn">новая колонка</param>
        public void Add(PatternColumn сolumn)
        {
            List.Add(сolumn);
        }

        /// <summary>
        /// Вставка колонки в коллекцию в указанную позицию
        /// </summary>
        /// <param name="index"></param>
        /// <param name="column"></param>
        public void Insert(int index, PatternColumn column)
        {
            List.Insert(index, column);
        }

        /// <summary>
        /// Удаление из коллекции колонки с указанным индексом
        /// </summary>
        /// <param name="index">индекс колонки для удаления</param>
        public void Remove(int index)
        {
            if (index > this.Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс находится за пределами диапазона.");
            }
            else
            {
                this.List.RemoveAt(index);
            }
        }

        /// <summary>
        /// Удаление из коллекции колонки с указанным идентификатором(именем)
        /// </summary>
        /// <param name="name">идентификатор(имя) колонки для удаления</param>
        public void Remove(string name)
        {
            List.Remove(this.FindColumnByName(name));
        }

        /// <summary>
        /// Получить колонку по указанному идентификатору(имени)
        /// </summary>
        /// <param name="name">идентификатор(имя) колонки</param>
        /// <returns></returns>
        private PatternColumn FindColumnByName(string name)
        {
            PatternColumn retColumn = null;
            foreach (PatternColumn column in this.List)
            {
                if (name.Equals(column.Name))
                {
                    retColumn = column;
                    break;
                }
            }
            return retColumn;
        }

        public PatternColumn this[int index]
        {
            get
            {
                int counter = 0;
                foreach (PatternColumn column in this.List)
                {
                    if (index == counter++)
                        return column;
                }
                throw new IndexOutOfRangeException("Индекс находится за пределами диапазона.");
            }
        }

    }

    /// <summary>
    /// Колонка-шаблон для представления изображения
    /// </summary>
    public class ImagePatternColumn : PatternColumn
    {
        /// <summary>
        /// Привязанное поле, служащее источником для анализа изображения
        /// </summary>
        public String LinkedDataFieldName
        {
            get { return this.DataFieldName; }
        }

        public ImagePatternColumn(string caption, string dataFieldName)
            : base(caption, dataFieldName)
        {

        }
    }

    /// <summary>
    /// Колонка-шаблон для представления выбора
    /// </summary>
    public class SelectorPatternColumn : PatternColumn
    {
        public SelectorPatternColumn(string caption, string dataFieldName)
            : base(caption, dataFieldName)
        {

        }

        public SelectorPatternColumn(string caption, string dataFieldName, SummaryCalculationType summaryCalculationType)
            : this(caption, dataFieldName, new FilterEmptyExpressionRule(), summaryCalculationType)
        {

        }

        public SelectorPatternColumn(string caption, string dataFieldName, FilterExpressionRule filterRule, SummaryCalculationType summaryCalculationType)
            : base(caption, dataFieldName, filterRule, summaryCalculationType)
        { 
        
        }
    }
}
