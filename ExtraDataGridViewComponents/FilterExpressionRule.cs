using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WMSOffice.Controls.ExtraDataGridViewComponents
{
    public abstract class FilterExpressionRule
    {
        /// <summary>
        /// Поле для фильтрации
        /// </summary>
        public string DataField { get; protected set; }

        /// <summary>
        /// Значение для задания фильтра
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Получение выражения фильтрации
        /// </summary>
        public string GetFilterExpression(object value)
        {
            // Если фильтр не задан
            if (string.IsNullOrEmpty((value ?? string.Empty).ToString()))
            {
                this.Value = null;
                return null;
            }

            this.Value = value.ToString();

            // Если введенное значение - ПУСТОЕ, то фильтр настроим соотв. образом
            if (this.Value.ToUpper() == "ПУСТОЕ")
                return string.Format("[{0}] IS NULL", this.DataField);

            // Если введенное значение - НЕПУСТОЕ, то фильтр настроим соотв. образом
            if (this.Value.ToUpper() == "НЕПУСТОЕ")
                return string.Format("[{0}] IS NOT NULL", this.DataField);

            return this.GetFilterExpressionDetail(value);
        }

        protected abstract string GetFilterExpressionDetail(object value);

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        protected FilterExpressionRule()
        { 
        
        }

        public FilterExpressionRule(string dataField)
        {
            this.DataField = dataField;
        }
        #endregion
    }

    /// <summary>
    /// Отсутствующее правило фильтрации (null-объект)
    /// </summary>
    public class FilterEmptyExpressionRule : FilterExpressionRule
    {
        public FilterEmptyExpressionRule()
        {
            this.DataField = null;
            this.Value = null;
        }

        protected override string GetFilterExpressionDetail(object value)
        {
            return null;
        }
    }

    /// <summary>
    /// Правило фильтрации по шаблону (для строковых значений)
    /// </summary>
    public class FilterPatternExpressionRule : FilterExpressionRule
    {
        public FilterPatternExpressionRule(string dataField)
            : base(dataField)
        {

        }

        protected override string GetFilterExpressionDetail(object value)
        {
            //if (string.IsNullOrEmpty((value ?? string.Empty).ToString()))
            //{
            //    this.Value = null;
            //    return null;
            //}

            this.Value = value.ToString();

            var inverse_operator = this.Value[0] == '^' || this.Value[0] == '!' || this.Value[0] == '~';
            var compare_operator = inverse_operator && this.Value.Length > 1 ? "NOT LIKE" : "LIKE";
            var compare_value = inverse_operator && this.Value.Length > 1 ? this.Value.Remove(0, 1) : this.Value;

            // Применим фильтр типа "LIKE" явно
            if (compare_value[0] == '*' || (compare_value.Length > 1 && compare_value[compare_value.Length - 1] == '*'))
            {
                string pattern = compare_value;
                int idx_current = -1;
                while ((idx_current = pattern.IndexOf('*', idx_current + 1)) != -1)
                {
                    if (idx_current == 0)
                        pattern = string.Format("%{0}", pattern.Remove(0, 1));
                    if (idx_current == pattern.Length - 1)
                        pattern = string.Format("{0}%", pattern.Remove(pattern.Length - 1, 1));
                }

                return string.Format("[{0}] {1} '{2}'", this.DataField, compare_operator, pattern.Replace("*", ""));
            }
            // Применим фильтр типа "LIKE" неявно            
            else
            {
                return string.Format("[{0}] {1} '%{2}%'", this.DataField, compare_operator, compare_value);
            }
        }
    }

    /// <summary>
    /// Правило фильтрации с использованием операции сравнения
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FilterCompareExpressionRule<T> : FilterExpressionRule where T : struct
    {
        /// <summary>
        /// Операции сравнения для этого типа фильтра
        /// </summary>
        private string[] compareOperations = new string[] { "=", ">=", ">", "<>", "<=", "<" };

        private readonly string separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        private readonly string sql_separator = ".";

        public FilterCompareExpressionRule(string dataField)
            : base(dataField)
        {

        }

        protected override string GetFilterExpressionDetail(object value)
        {
            //if (string.IsNullOrEmpty((value ?? string.Empty).ToString()))
            //{
            //    this.Value = null;
            //    return null;
            //}

            this.Value = value.ToString();

            #region ПОИСК И ФОРМИРОВАНИЕ ОПЕРАЦИИ СРАВНЕНИЯ
            string compare_operation = string.Empty;
            string pattern_value = string.Empty;
            foreach (var operation in this.compareOperations)
            {
                if (this.Value.Length >= operation.Length && this.Value.Substring(0, operation.Length) == operation)
                {
                    compare_operation = operation;
                    pattern_value = this.Value.Substring(compare_operation.Length).Trim();
                    break;
                }
            }
            if (compare_operation == string.Empty)
            {
                compare_operation = "=";
                pattern_value = this.Value.Trim();
            }
            #endregion

            #region ПАРСИНГ ВВЕДЕННОГО ЗНАЧЕНИЯ
            if (typeof(T) == typeof(DateTime))
            { 
                DateTime result;
                if (!DateTime.TryParse(pattern_value, out result))
                    return null;

                //return string.Format("[{0}] {1} '{2}'", this.DataField, compare_operation, result);
                return string.Format("CONVERT(SUBSTRING(CONVERT([{0}], 'System.String'), 1, 10), 'System.DateTime') {1} '{2}'", this.DataField, compare_operation, result);
            }

            if (typeof(T) == typeof(Int16))
            {
                Int16 result;
                if (!Int16.TryParse(pattern_value, out result))
                    return null;

                return string.Format("[{0}] {1} {2}", this.DataField, compare_operation, result);
            }

            if (typeof(T) == typeof(Int32))
            {
                Int32 result;
                if (!Int32.TryParse(pattern_value, out result))
                    return null;

                return string.Format("[{0}] {1} {2}", this.DataField, compare_operation, result);
            }

            if (typeof(T) == typeof(Int64))
            {
                Int64 result;
                if (!Int64.TryParse(pattern_value, out result))
                    return null;

                return string.Format("[{0}] {1} {2}", this.DataField, compare_operation, result);
            }

            if (typeof(T) == typeof(Decimal))
            {
                pattern_value = pattern_value.Replace(".", separator).Replace(",", separator);

                Decimal result;
                if (!Decimal.TryParse(pattern_value, out result))
                    return null;

                var sResult = result.ToString().Replace(",", sql_separator);
                return string.Format("[{0}] {1} {2}", this.DataField, compare_operation, sResult);
            }

            if (typeof(T) == typeof(Double))
            {
                pattern_value = pattern_value.Replace(".", separator).Replace(",", separator);

                Double result;
                if (!Double.TryParse(pattern_value, out result))
                    return null;

                var sResult = result.ToString().Replace(",", sql_separator);
                return string.Format("[{0}] {1} {2}", this.DataField, compare_operation, sResult);
            }

            if (typeof(T) == typeof(Boolean))
            {
                Boolean result;
                if (!Boolean.TryParse(pattern_value, out result))
                {
                    var checkResult = (CheckState)Enum.Parse(typeof(CheckState), pattern_value);
                    if (checkResult == CheckState.Indeterminate)
                        return null;

                    result = checkResult == CheckState.Checked ? true : false;
                }

                return string.Format("[{0}] {1} '{2}'", this.DataField, compare_operation, result);
            }

            #endregion

            return null;
        }
    }

    /// <summary>
    /// Правило фильтрации с использованием операции сравнения для типа даты
    /// </summary>
    public class FilterDateCompareExpressionRule : FilterCompareExpressionRule<DateTime>
    {
        public FilterDateCompareExpressionRule(string dataField)
            : base(dataField)
        {

        }

        protected override string GetFilterExpressionDetail(object value)
        {
            return base.GetFilterExpressionDetail(value);
        }
    }

    /// <summary>
    /// Правило фильтрации с использованием операции сравнения для типа логический
    /// </summary>
    public class FilterBoolCompareExpressionRule : FilterCompareExpressionRule<Boolean>
    {
        public FilterBoolCompareExpressionRule(string dataField)
            : base(dataField)
        {

        }

        protected override string GetFilterExpressionDetail(object value)
        {
            return base.GetFilterExpressionDetail(value);
        }
    }


    /// <summary>
    /// Правило фильтрации по контексту поиска значений из словаря
    /// </summary>
    public class FilterValueReferenceExpressionRule : FilterExpressionRule
    {
        /// <summary>
        /// Запрос для формирования справочника
        /// </summary>
        public string ValueReferenceQuery { get; private set; }

        public FilterValueReferenceExpressionRule(string dataField, string query)
            : base(dataField)
        {
            this.ValueReferenceQuery = query;
        }

        protected override string GetFilterExpressionDetail(object value)
        {
            //if (string.IsNullOrEmpty((value ?? string.Empty).ToString()))
            //{
            //    this.Value = null;
            //    return null;
            //}

            this.Value = value.ToString();
            return string.Format("[{0}] = '{1}'", this.DataField, this.Value);
        }
    }
}
