using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WMSOffice.Classes
{
    /// <summary>
    /// Статический класс, в котором находятся методы экспорта документов и таблиц в различные форматы
    /// </summary>
    public static class ExportHelper
    {
        /// <summary>
        /// Экспорт DataGridView с данными в CSV-файл
        /// </summary>
        /// <param name="pDgv">DataGridView с данными, который нужно экспортировать</param>
        /// <param name="pDialogTitle">Заголовок диалогового окна с выбором названия файла, в который будет произведен экспорт</param>
        /// <param name="pFileNamePart">Часть названия файла с экспортированными данными по умолчанию 
        /// (название файла формируется следующим образом: код+название, где код формируется из текущей даты/времени и является уникальным)</param>
        /// <param name="pOpenExcelWindow">True, если экспортированный файл нужно открыть в Excel, False если не нужно открывать</param>
        /// <returns>Пустая строка, если экспорт произведен успешно, либо сообщение об ошибке, если такая возникла</returns>
        public static string ExportDataGridViewToExcel(DataGridView pDgv, string pDialogTitle, string pFileNamePart, bool pOpenExcelWindow)
        {
            var dialog = CreateExportDialog(ExportType.CSV, pDialogTitle, pFileNamePart);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportDataGridView(dialog.FileName, pDgv);

                    if (pOpenExcelWindow)
                        Process.Start(dialog.FileName);
                }
                catch (Exception exc)
                {
                    return exc.Message;
                }
            }

            return String.Empty;
        }

        /// <summary>
        /// Создание диалога сохранения файла для выбора названия и местоположения файла с экспортированными данными
        /// </summary>
        /// <param name="pExportType">Тип файла с экспортированными данными</param>
        /// <param name="pDialogTitle">Заголовок диалога</param>
        /// <param name="pFileNamePart">Часть названия файла с экспортированными данными по умолчанию 
        /// (название файла формируется следующим образом: код+название, где код формируется из текущей даты/времени и является уникальным)</param>
        /// <returns>Диалог сохранения файла с экспортированными данными</returns>
        private static SaveFileDialog CreateExportDialog(ExportType pExportType, string pDialogTitle, string pFileNamePart)
        {
            DateTime now = DateTime.Now;

            pFileNamePart = pFileNamePart
                .Replace('\\', '_')
                .Replace('/', '_')
                .Replace(":", "_")
                .Replace("*", "_")
                .Replace("?", "_")
                .Replace("\"", "_")
                .Replace("<", "_")
                .Replace(">", "_")
                .Replace("|", "_");

            return new SaveFileDialog()
            {
                FileName = String.Format("{0}{1}{2}{3}{4}{5}-{6}", now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'), pFileNamePart),
                Title = pDialogTitle,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = GetDialogFilter(pExportType),
                FilterIndex = 0,
                AddExtension = true,
                DefaultExt = GetDialogDefaultExt(pExportType)
            };
        }

        /// <summary>
        /// Формирование нужного фильтра диалогового окна сохранения файла в зависимости от типа экспорта
        /// </summary>
        /// <param name="pExportType">Тип экспорта данных</param>
        /// <returns>Фильтр диалогового окна, заданный строкой</returns>
        private static string GetDialogFilter(ExportType pExportType)
        {
            switch (pExportType)
            {
                case ExportType.CSV:
                    return "Текстовый файл с разделителями (*.csv)|*.csv";
                case ExportType.PDF:
                    return "PDF файлы (*.pdf)|*.pdf";
                case ExportType.XLS:
                    return "Excel файл (*.xls, *.xlsx)|*.xls;*.xlsx";
                case ExportType.RTF:
                    return "Word файл (*.doc, *.docx)|*.doc;*.docx";
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Формирование нужного расширения диалогового окна сохранения файла в зависимости от типа экспорта
        /// </summary>
        /// <param name="pExportType">Тип экспорта данных</param>
        /// <returns>Расширение по умолчанию для диалогового окна сохранения файла</returns>
        private static string GetDialogDefaultExt(ExportType pExportType)
        {
            switch (pExportType)
            {
                case ExportType.CSV:
                    return "csv";
                case ExportType.PDF:
                    return "pdf";
                case ExportType.XLS:
                    return "xls";
                case ExportType.RTF:
                    return "doc";
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Экспорт DataGridView с данными в заданный файл
        /// </summary>
        /// <param name="pFilePath">Название файла, в который нужно экспортировать DataGridView с данными</param>
        /// <param name="pDgv">DataGridView с данными, который экспортируется</param>
        private static void ExportDataGridView(string pFilePath, DataGridView pDgv)
        {
            using (var sw = new StreamWriter(pFilePath, false, Encoding.Default))
            {
                var colIndexes = GetListOfColumnIndexes(pDgv);

                for (int i = 0; i < colIndexes.Count; i++)    // Запись заголовков колонок в файл
                {
                    sw.Write("\"" + pDgv.Columns[colIndexes[i]].HeaderText + "\"");
                    if (i < colIndexes.Count - 1)
                        sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
                sw.Write(sw.NewLine);

                foreach (DataGridViewRow row in pDgv.Rows)  // Запись строк в файл
                {
                    for (int i = 0; i < colIndexes.Count; i++)
                    {
                        if (row.Cells[colIndexes[i]].Value != null && !Convert.IsDBNull(row.Cells[colIndexes[i]].Value) &&
                            !String.IsNullOrEmpty(row.Cells[colIndexes[i]].Value.ToString()))
                            sw.Write("\"" + row.Cells[colIndexes[i]].Value.ToString() + "\"");
                        else
                            sw.Write("\" \"");

                        if (i < colIndexes.Count - 1)
                            sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                    }
                    sw.Write(sw.NewLine);
                }

                sw.Close();
            }
        }

        /// <summary>
        /// Получение списка индексов колонок DataGridView, отсортированного по их порядку отображения
        /// </summary>
        /// <param name="pDgv">DataGridView, в котором находятся сортируемые колонки</param>
        /// <returns>Список индексов колонок DataGridView, отсортированный по их порядку отображения</returns>
        private static List<int> GetListOfColumnIndexes(DataGridView pDgv)
        {
            var colIndexes = new List<int>();
            for (int i = 0; i < pDgv.Columns.Count; i++)
                if (pDgv.Columns[i].Visible)
                    colIndexes.Add(i);

            for (int i = 0; i < colIndexes.Count; i++)
                for (int j = i + 1; j < colIndexes.Count; j++)
                    if (pDgv.Columns[colIndexes[i]].DisplayIndex > pDgv.Columns[colIndexes[j]].DisplayIndex)
                    {
                        int tmp = colIndexes[i];
                        colIndexes[i] = colIndexes[j];
                        colIndexes[j] = tmp;
                    }

            return colIndexes;
        }

        /// <summary>
        /// Экспорт в память заданного Crystal-отчета в формате PDF либо Excel
        /// </summary>
        /// <param name="Crystal-отчет, который нужно экспортировать"></param>
        /// <param name="pFormatType">Формат файла (PDF либо Excel)</param>
        /// <returns>Файл в памяти</returns>
        public static byte[] ExportCrystalReportIntoBuffer(ReportClass pReport, ExportFormatType pFormatType)
        {
            byte[] retBuffer = null;
            using (MemoryStream ms = (MemoryStream)pReport.ExportToStream(ExportFormatType.PortableDocFormat))
                retBuffer = ms.ToArray();

            return retBuffer;
        }

        /// <summary>
        /// Экспорт заданного Crystal-отчета в PDF либо Excel-файл
        /// </summary>
        /// <param name="pReport">Crystal-отчет, который нужно экспортировать</param>
        /// <param name="pFormatType">Формат файла (PDF либо Excel)</param>
        /// <param name="pDialogTitle">Заголовок диалогового окна с выбором названия файла, в который будет произведен экспорт</param>
        /// <param name="pFileNamePart">Часть названия файла с экспортированными данными по умолчанию 
        /// (название файла формируется следующим образом: код+название, где код формируется из текущей даты/времени и является уникальным)</param>
        /// <param name="pOpenWindow">True, если экспортированный файл нужно открыть в соответствующей программе, False если не нужно открывать</param>
        /// <returns>Пустая строка, если экспорт произведен успешно, либо сообщение об ошибке, если такая возникла</returns>
        public static string ExportCrystalReport(ReportClass pReport, ExportFormatType pFormatType, string pDialogTitle, 
            string pFileNamePart, bool pOpenWindow)
        {
            pFileNamePart = pFileNamePart.Replace(':', '_').Replace('/', '_').Replace(@"\", "_");

            var dialog = CreateExportDialog(pFormatType == ExportFormatType.PortableDocFormat ? ExportType.PDF : pFormatType == ExportFormatType.Excel ? ExportType.XLS : ExportType.RTF,
                pDialogTitle, pFileNamePart);
            if (dialog.ShowDialog() == DialogResult.OK)
                return ExportCrystalReportToFile(pReport, pFormatType, dialog.FileName, pOpenWindow);

            return String.Empty;
        }

        /// <summary>
        /// Экспорт заданного Crystal-отчета в PDF либо Excel-файл
        /// </summary>
        /// <param name="pReport">Crystal-отчет, который нужно экспортировать</param>
        /// <param name="pFormatType">Формат файла (PDF либо Excel)</param>
        /// <param name="pFileName">Название файла</param>
        /// <param name="pOpenWindow">True, если экспортированный файл нужно открыть в соответствующей программе, False если не нужно открывать</param>
        /// <returns>Пустая строка, если экспорт произведен успешно, либо сообщение об ошибке, если такая возникла</returns>
        public static string ExportCrystalReportToFile(ReportClass pReport, ExportFormatType pFormatType,
            string pFileName, bool pOpenWindow)
        {
            try
            {
                pReport.ExportToDisk(pFormatType, pFileName);
                if (pOpenWindow)
                {
                    Thread.Sleep(500);
                    Process.Start(pFileName);
                }
                return String.Empty;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        /// <summary>
        /// Экспорт таблицы с данными в Excel
        /// </summary>
        /// <param name="pTable">Таблица с данными (DataTable)</param>
        /// <param name="pTitles">Массив, содержащий названия Excel-колонок с данными (важен порядок)</param>
        /// <param name="pColumnNames">Названия колонок в DataTable, из которых берутся данные (важен порядок)</param>
        /// <param name="pDialogTitle">Заголовок диалогового окна с выбором названия файла, в который будет произведен экспорт</param>
        /// <param name="pFileNamePart">Часть названия файла с экспортированными данными по умолчанию 
        /// (название файла формируется следующим образом: код+название, где код формируется из текущей даты/времени и является уникальным)</param>
        /// <param name="pOpenWindow">True, если экспортированный файл нужно открыть в соответствующей программе, False если не нужно открывать</param>
        /// <returns>Пустая строка, если экспорт произведен успешно, либо сообщение об ошибке, если такая возникла</returns>
        public static string ExportDataTableToExcel(DataTable pTable, string[] pTitles, string[] pColumnNames,
            string pDialogTitle, string pFileNamePart, bool pOpenWindow)
        {
            pFileNamePart = pFileNamePart.Replace(':', '_').Replace('/', '_').Replace(@"\", "_");

            var dialog = CreateExportDialog(ExportType.CSV, pDialogTitle, pFileNamePart);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UnSafeExportDataTableToFile(dialog.FileName, pTable, pTitles, pColumnNames);
                    Process.Start(dialog.FileName);
                }
                catch (Exception exc)
                {
                    return exc.Message;
                }
            }

            return String.Empty;
        }

        /// <summary>
        /// Экспорт данных из таблицы в заданный файл (без обработчиков событий)
        /// </summary>
        /// <param name="pFilePath">Файл, в который нужно экспортировать таблицу</param>
        /// <param name="pTable">Таблица с данными (DataTable)</param>
        /// <param name="pTitles">Массив, содержащий названия Excel-колонок с данными (важен порядок)</param>
        /// <param name="pColumnNames">Названия колонок в DataTable, из которых берутся данные (важен порядок)</param>
        private static void UnSafeExportDataTableToFile(string pFilePath, DataTable pTable, string[] pTitles, string[] pColumnNames)
        {
            if (pTitles == null || pColumnNames == null)
                throw new ApplicationException("Массив заголовков либо массив названий колонок равен NULL!");
            else if (pTitles.Length != pColumnNames.Length)
                throw new ApplicationException("Массив заголовков и массив названий колонок имеют разные размеры!");

            using (var sw = new StreamWriter(pFilePath, false, Encoding.Default))
            {
                for (int i = 0; i < pTitles.Length; i++)
                {
                    sw.Write("\"" + pTitles[i] + "\"");
                    sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
                sw.Write(sw.NewLine);

                for (int i = 0; i < pTable.Rows.Count; i++)
                {
                    for (int j = 0; j < pColumnNames.Length; j++)
                    {
                        try
                        {
                            var rowValue = pTable.Rows[i][pColumnNames[j]];
                            if (rowValue != null && rowValue != DBNull.Value)
                                sw.Write(FormatRowValue(rowValue));
                            else
                                sw.Write("\" \"");
                            sw.Write(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    sw.Write(sw.NewLine);
                }

                sw.Close();
            }
        }

        /// <summary>
        /// Форматирование значения в ячейке таблицы, чтобы оно имело презентабельный вид
        /// </summary>
        /// <param name="pValue">Значение</param>
        /// <returns>Форматированное значение</returns>
        private static string FormatRowValue(object pValue)
        {
            if (pValue.GetType() == typeof(DateTime))
            {
                DateTime val;
                DateTime.TryParse(pValue.ToString(), out val);
                return "\"" + (val.TimeOfDay.TotalMilliseconds == val.Date.TimeOfDay.TotalMilliseconds ? val.ToShortDateString() : val.ToString()) + "\"";
            }
            if (pValue.GetType() == typeof(String) && !String.IsNullOrEmpty(pValue.ToString()))
            {
                string val = pValue.ToString();
                if (val[0] == '0')
                    return "=\"" + val + "\"";
                else
                    return "\"" + val + "\"";
            }
            else
                return "\"" + pValue.ToString() + "\"";
        }

        /// Экспорт данных из таблицы в заданный файл
        /// </summary>
        /// <param name="pFilePath">Файл, в который нужно экспортировать таблицу</param>
        /// <param name="pTable">Таблица с данными (DataTable)</param>
        /// <param name="pTitles">Массив, содержащий названия Excel-колонок с данными (важен порядок)</param>
        /// <param name="pColumnNames">Названия колонок в DataTable, из которых берутся данные (важен порядок)</param>
        /// <returns>Пустая строка, если экспорт произведен успешно, либо сообщение об ошибке, если такая возникла</returns> 
        public static string ExportDataTableToExcelFile(string pFilePath, DataTable pTable, string[] pTitles, string[] pColumnNames)
        {
            try
            {
                UnSafeExportDataTableToFile(pFilePath, pTable, pTitles, pColumnNames);
                return String.Empty;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
    }

    /// <summary>
    /// Доступные типы экспорта
    /// </summary>
    public enum ExportType
    {
        /// <summary>
        /// Экспорт в CSV-файл (экспорт в Excel)
        /// </summary>
        CSV,

        /// <summary>
        /// Экспорт в PDF-файл
        /// </summary>
        PDF,

        /// <summary>
        /// Экспорт в XLS-файл (используется при экспорте в Excel Crystal-отчета)
        /// </summary>
        XLS,

        /// <summary>
        /// Экспорт в RTF-файл (используется при экспорте в Word Crystal-отчета)
        /// </summary>
        RTF
    }
}
