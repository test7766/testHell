using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Controls.ExtraDataGridViewComponents
{
    /// <summary>
    /// Тип вычисления итоговых значений
    /// </summary>
    public enum SummaryCalculationType
    {
        /// <summary>
        /// Итог отсутствует
        /// </summary>
        None,

        /// <summary>
        /// Итог расчитывается как сумма значений
        /// </summary>
        Sum,

        /// <summary>
        /// Итог расчитывается как суммарное количество однородных записей
        /// </summary>
        Count,

        /// <summary>
        /// Итог расчитывается как общее количество записей
        /// </summary>
        TotalRecords,

        /// <summary>
        /// Итог расчитывается по клиентскому сценарию
        /// </summary>
        Custom
    }
}
