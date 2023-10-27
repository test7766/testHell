using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WMSOffice.Controls.ExtraDataGridViewComponents
{
    public interface IDataView
    {
        /// <summary>
        /// Коллекция колонок
        /// </summary>
        PatternColumnsCollection Columns { get; }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        DataTable Data { get; }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        void FillData(SearchParametersBase searchParameters);
    }
}
