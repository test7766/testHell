using System.Collections.Generic;
using System.Windows.Forms;

namespace WMSOffice.Classes
{
    /// <summary>
    /// Статический класс, который содержит методы для выполнения различных действий с DataGridView
    /// </summary>
    public static class DataGridViewHelper
    {
        /// <summary>
        /// Установка ширин колонок для заданного с автоопределяемыми значениями
        /// (При этом автоопределяются только те колонки, для которых значение AutoSizeMode = NotSet,
        /// также после автоопределения ширин выключается режим None для AutoSizeColumnsMode всего грида)
        /// </summary>
        /// <param name="pDgv">DataGridView, для которого нужно настроить колонки</param>
        public static void AutoSetColumnWidths(DataGridView pDgv)
        {
            var colWidths = new Dictionary<DataGridViewColumn, int>();

            // Автоопределение ширины колонок
            pDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewColumn col in pDgv.Columns)
                if (col.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
                    colWidths.Add(col, col.Width);

            // Установка определенных значений ширинам, и разрешение редактировать ширину колонок
            foreach (DataGridViewColumn col in pDgv.Columns)
                if (col.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
                    col.Width = colWidths[col];
            pDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }
    }
}
