using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WMSOffice.Data.ColdChainTableAdapters;
using System.Data.SqlClient;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Базовый класс-преобразователь форматов структуры данных дата-логгера в структуру WMS 
    /// </summary>
    [Obsolete]
    public abstract class LoggerFormatConverter
    {
        private readonly char[] arReplaceSourceChars = new char[] { ',' };

        public int UserID { get; set; } // сессия пользователя
        public int? EquipmentID { get; set; } // ид-р оборудования

        protected int algorithm; // тип алгоритма для обработки логгера 
        protected char fileDataSeparator; // символ-разделитель
        protected List<string> loggerDataList = null; // список содержимого файла

        protected WMSOffice.Data.ColdChain.LoggerDataTransferDataTable dtLoggerFileData = null; // таблица для хранения данных логгера, полученных из файла
        protected WMSOffice.Data.ColdChain.LoggerDataTransferDataTable dtLoggerData = null; // таблица для хранений данных логгера в БД

        /// <summary>
        /// Валидация структуры файла дата-логгера
        /// </summary>
        /// <returns></returns>
        protected abstract bool ValidateLoggerFileDataSchema();

        /// <summary>
        /// Преобразование данных файла дата-логгера в правильную структуру WMS
        /// </summary>
        protected abstract void AddLoggerFileDataToTargetTable();

        protected LoggerFormatConverter()
        {
            loggerDataList = new List<string>();
        }

        /// <summary>
        /// Разбиение строки данных по символу-разделителю и возврат
        /// </summary>
        /// <param name="row">Строка данных</param>
        /// <returns></returns>
        protected string[] GetLoggerRowElements(string row)
        {
            var processedRow = row;

            foreach (var replaceSourceChar in arReplaceSourceChars)
                processedRow = row.Replace(replaceSourceChar, fileDataSeparator).TrimStart(fileDataSeparator);

            return processedRow.Split(new char[] { fileDataSeparator });
        }

        /// <summary>
        /// Считывание показателей данных-логгера с файла и адаптация с данными в БД
        /// </summary>
        /// <param name="dataLoggerPath">Путь к файлу дата-логгера</param>
        public void TransformLoggerFileData(string dataLoggerPath, DateTime startTimeStamp, DateTime endTimeStamp, long? docID, string sensorSerialNumber)
        {
            try
            {
                // Загрузим содержимое файла в список
                PopulateLoggerDataList(dataLoggerPath);

                using (LoggerDataTransferTableAdapter adapter = new LoggerDataTransferTableAdapter())
                {
                    // Выполним выгрузку данных из БД и подготовим правильную структуру
                    dtLoggerData = adapter.GetData((short)this.algorithm, this.UserID);
                    dtLoggerFileData = (dtLoggerData.Clone() as WMSOffice.Data.ColdChain.LoggerDataTransferDataTable);


                    // Валидация соответствия схемы файла схеме таблицы БД
                    if (!ValidateLoggerFileDataSchema())
                        throw new Exception("Структура данных файла отлична от правильной.");

                    // Запись данных из файла логгера в таблицу
                    AddLoggerFileDataToTargetTable();

                    try
                    {
                        dtLoggerFileData.DefaultView.RowFilter = string.Format("{0} >= '{1}' AND {0} <= '{2}'", dtLoggerFileData.DateTimeColumn.Caption, startTimeStamp, endTimeStamp);
                    }
                    catch
                    {
                        dtLoggerFileData.DefaultView.RowFilter = null;
                    }

                    var dtFilteredLoggerFileData = dtLoggerFileData.DefaultView.ToTable();

                    dtLoggerFileData.Rows.Clear();
                    dtLoggerFileData.Merge(dtFilteredLoggerFileData);

                    // Обновление данных логгера (выполним слияние для возможной модификации показателей логгера)
                    dtLoggerData.Merge(dtLoggerFileData as System.Data.DataTable);
                    adapter.Update(dtLoggerData);
                }

                // Утвердить изменения показателей дата-логгера и сохранить (ид-р оборудования имеет необязательное значение)
                using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                    adapter.CommitDataLoggerChanges(UserID, EquipmentID, docID, string.IsNullOrEmpty(sensorSerialNumber) ? (string)null : sensorSerialNumber, (DateTime?)null, (DateTime?)null);
            }
            //catch (SqlException error)
            //{
            //    throw error;
            //}
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (loggerDataList != null)
                    loggerDataList.Clear();

                if (dtLoggerData != null)
                    dtLoggerData.Clear();

                if (dtLoggerFileData != null)
                    dtLoggerFileData.Clear();
            }
        }

        /// <summary>
        /// Считывание данных файла логгера в список
        /// </summary>
        /// <param name="dataLoggerPath">Путь к файлу</param>
        private void PopulateLoggerDataList(string dataLoggerPath)
        {
            if (!File.Exists(dataLoggerPath))
                throw new Exception("По указанному пути файл не найден.");

            using (StreamReader srLoggerDataReader = new StreamReader(File.OpenRead(dataLoggerPath)))
            {
                while (!srLoggerDataReader.EndOfStream)
                    loggerDataList.Add(srLoggerDataReader.ReadLine().Trim(fileDataSeparator));

                srLoggerDataReader.Close();
            }
        }
    }

    /// <summary>
    /// Класс-преобразователь старого формата (*.OPH) структуры данных дата-логгера в структуру WMS 
    /// </summary>
    [Obsolete]
    public class OldLoggerFormatConverter : LoggerFormatConverter
    {
        public OldLoggerFormatConverter()
            : base()
        {
            fileDataSeparator = '\t';
            algorithm = 1;
        }

        protected override bool ValidateLoggerFileDataSchema()
        {
            int ADDITIONAL_FIELDS_COUNT = 3; // Колонки для Наименования, Сессии пользователя и Алгоритма обработки данных логгера

            // Количество столбцов в схемах не совпадают
            if (GetLoggerRowElements(loggerDataList[1]).Length + ADDITIONAL_FIELDS_COUNT != dtLoggerData.Columns.Count)
                return false;

            // Поле "Name" данных логгера содержится в первой строке файла
            if (!dtLoggerData.Columns.Contains(GetLoggerRowElements(loggerDataList[0])[0]))
                return false;

            // Основные колонки логгера размещены во 2-й строке файла
            foreach (string columnName in GetLoggerRowElements(loggerDataList[1]))
                if (!dtLoggerData.Columns.Contains(columnName))
                    return false;

            return true;
        }

        protected override void AddLoggerFileDataToTargetTable()
        {
            // Запись данных из файла логгера в таблицу (данные хранятся в файле начиная с 3-й строки)
            for (int i = 2; i < loggerDataList.Count; i++)
            {
                int columnPos = 0;
                object[] rowData = new object[dtLoggerFileData.Columns.Count];

                rowData[columnPos++] = UserID; // Значение сессии пользователя
                rowData[columnPos++] = GetLoggerRowElements(loggerDataList[0])[1]; // Значение поля "Name"

                foreach (string dataRowCell in GetLoggerRowElements(loggerDataList[i]))
                    rowData[columnPos++] = string.IsNullOrEmpty(dataRowCell) ? (object)DBNull.Value : dataRowCell;

                columnPos = 7; // позиция колонки [алгоритм]
                rowData[columnPos] = algorithm; // алгоритм обработки данных логгера

                dtLoggerFileData.LoadDataRow(rowData, false);
            }
        }
    }

    /// <summary>
    /// Класс-преобразователь нового формата (*.CSV) структуры данных дата-логгера в структуру WMS 
    /// </summary>
    [Obsolete]
    public class NewLoggerFormatConverter : LoggerFormatConverter
    {
        public NewLoggerFormatConverter()
            : base()
        {
            fileDataSeparator = ';';
            algorithm = 2;
        }

        protected override bool ValidateLoggerFileDataSchema()
        {
            // Поле "Name" данных логгера содержится в первой строке файла
            if (!GetLoggerRowElements(loggerDataList[0])[0].Contains("S/N"))
                return false;

            return true;
        }

        protected override void AddLoggerFileDataToTargetTable()
        {
            int loggerDegree = 1; // Порядковый номер текущего показания датчика температуры

            // Запись данных из файла логгера в таблицу (данные хранятся в файле начиная с 4-й строки)
            for (int i = 3; i < loggerDataList.Count; i++)
            {
                try
                {
                    int columnPos = 0;
                    object[] rowData = new object[dtLoggerFileData.Columns.Count];

                    rowData[columnPos++] = UserID; // Значение сессии пользователя
                    rowData[columnPos++] = GetLoggerRowElements(loggerDataList[0])[1]; // Значение поля "S/N" - ID дата логгера
                    rowData[columnPos++] = loggerDegree++; // порядковый номер показаний датчика температуры

                    string[] loggerDegreeValues = GetLoggerRowElements(loggerDataList[i]);
                    rowData[columnPos++] = DateTime.Parse(loggerDegreeValues[0]).Add(TimeSpan.Parse(loggerDegreeValues[1])); // обьединяем дату и время в одно поле

                    string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    rowData[columnPos++] = loggerDegreeValues[2].Equals(string.Empty)
                                                ? DBNull.Value
                                                : (object)Convert.ToDouble(loggerDegreeValues[2].ToString().Replace(".", decimalSeparator).Replace(",", decimalSeparator)); // показатель температуры

                    rowData[columnPos++] = DBNull.Value; // значение ch2 (не используеться в этой версии алгоритма)
                    rowData[columnPos++] = DBNull.Value; // значение ch3 (не используеться в этой версии алгоритма)

                    columnPos = 7; // позиция колонки [алгоритм]
                    rowData[columnPos] = algorithm; // алгоритм обработки данных логгера

                    dtLoggerFileData.LoadDataRow(rowData, false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

}
