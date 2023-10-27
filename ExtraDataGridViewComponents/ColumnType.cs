using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Controls.ExtraDataGridViewComponents
{
    /// <summary>
    /// Тип отображения колонки в табличном представлении
    /// </summary>
    public enum ColumnType
    {
        /// <summary>
        /// Значения колонки отображаются обычным текстовым полем
        /// </summary>
        Text,

        /// <summary>
        /// Значения колонки отображаются флажком
        /// </summary>
        Logical,

        /// <summary>
        /// Значения колонки отображаются выпадающим списком
        /// </summary>
        List,

        /// <summary>
        /// Значения колонки отображаются картинкой
        /// </summary>
        Image,

        /// <summary>
        /// Значения колонки отображаются кнопкой
        /// </summary>
        Action
    }
}
