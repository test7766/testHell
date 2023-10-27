using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data.SqlClient;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Класс управляет преобразованием данных формата файла дата-логгера к формату структуры WMS
    /// </summary>
    public static class DataLoggerHelper
    {      
        public static int UserID { get; set; }
        public static int? EquipmentID { get; set; }

        private static bool IsTestVersion { get { return MainForm.IsTestVersion; } }

        private static Exception occuredThreadError;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private static SplashForm splashForm = new SplashForm(); 

        /// <summary>
        /// Преобразование данных файла дата-логгера в структуру WMS 
        /// </summary>
        /// <param name="dataLoggerPath">Путь к файлу</param>
        public static void AdaptLoggerFileData(string dataLoggerPath, DateTime startTimeStamp, DateTime endTimeStamp, long? docID, string sensorSerailNumber)
        {
            if (dataLoggerPath == string.Empty)
                throw new Exception("Путь к файлу не должен быть пустым.");

            occuredThreadError = null;

            var tdlp = new TransferDataLoggerParameters() 
            {
                DataLoggerPath = dataLoggerPath,
                StartTimeStamp = startTimeStamp,
                EndTimeStamp = endTimeStamp,
                DocID = docID,
                SensorSerialNumber = sensorSerailNumber
            };

            BackgroundWorker transformDataWorker = new BackgroundWorker(); // поток для выполнения фоновой операции преобразования данных и сохранения
            transformDataWorker.DoWork += new DoWorkEventHandler(transformDataWorker_DoWork);
            transformDataWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(transformDataWorker_RunWorkerCompleted);

            splashForm.ActionText = "Выполняется обработка данных показателей дата-логгера...";
            transformDataWorker.RunWorkerAsync(tdlp); 
            splashForm.ShowDialog();

            // Если была обнаружена ошибка выбросим ее на уровень выше
            if (occuredThreadError != null)
                throw occuredThreadError;
        }

        private static void transformDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var tdlp = e.Argument as TransferDataLoggerParameters;

                string dataLoggerPath = tdlp.DataLoggerPath; // путь к файлу
                var startTimeStamp = tdlp.StartTimeStamp; // период "с"
                var endTimeStamp = tdlp.EndTimeStamp; // период "по"
                var docID = tdlp.DocID; // № док-та закрепления
                var sensorSerialNumber = tdlp.SensorSerialNumber; // S/N датчика

                //if (IsTestVersion)
                //{
                var sb = new WMSOffice.Classes.ColdChain.SerializerBridge()
                {
                    SessionID = UserID,
                    SensorSerialNumber = sensorSerialNumber
                };

                sb.OnDeserializationComplete += delegate(object s, WMSOffice.Classes.ColdChain.Utils.DeserializationCompleteEventArgs ea)
                {
                    var dtLoggerFileData = ea.Data as WMSOffice.Data.ColdChain.LoggerDataTransferDataTable;
                    var algorithm = dtLoggerFileData[0].Algorithm;

                    #region ФИЛЬТРАЦИЯ ПОКАЗАНИЙ ПО ВРЕМЕНИ
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
                    #endregion

                    #region СОХРАНЕНИЕ ПОКАЗАНИЙ В БУФЕРНУЮ ТАБЛИЦУ
                    var dtLoggerData = (WMSOffice.Data.ColdChain.LoggerDataTransferDataTable)null;
                    using (var adapter = new Data.ColdChainTableAdapters.LoggerDataTransferTableAdapter())
                    {
                        adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                        dtLoggerData = adapter.GetData(algorithm, UserID);

                        // Обновление данных логгера (выполним слияние для возможной модификации показателей логгера)
                        dtLoggerData.Merge(dtLoggerFileData as System.Data.DataTable);

                        adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                        adapter.Update(dtLoggerData);
                    }
                    #endregion

                    #region ФИКСАЦИЯ СОХРАНЕННЫХ ПОКАЗАНИЙ
                    // Утвердить изменения показателей дата-логгера и сохранить
                    using (var adapter = new Data.ColdChainTableAdapters.QueriesTableAdapter())
                    {
                        adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                        adapter.CommitDataLoggerChanges(UserID, EquipmentID, docID, string.IsNullOrEmpty(sensorSerialNumber) ? (string)null : sensorSerialNumber, docID.HasValue ? startTimeStamp : (DateTime?)null, docID.HasValue ? endTimeStamp : (DateTime?)null);
                    }
                    #endregion
                };

                sb.Deserialize(dataLoggerPath);
                //}
                //else
                //{
                //    #region OBSOLETE (ПОДХОД ПАРСИНГА УСТАРЕЛ, ВМЕСТО НЕГО ИСПОЛЬЗУЕТСЯ ДЕСЕРИАЛИЗАЦИЯ)
                //    LoggerFormatConverter loggerFormatConverter = null; // базовый класс преобразователя форматов файла

                //    if ((loggerFormatConverter = CreateFormatConverter(dataLoggerPath)) != null)
                //        loggerFormatConverter.TransformLoggerFileData(dataLoggerPath, startTimeStamp, endTimeStamp, docID, string.IsNullOrEmpty(sensorSerialNumber) ? (string)null : sensorSerialNumber);
                //    else
                //        throw new NotImplementedException("Обработка указанного формата не реализована.");
                //    #endregion
                //}
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private static void transformDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                occuredThreadError = e.Result as Exception;

            splashForm.CloseForce();
        }

        /// <summary>
        /// Фабричный метод, создающий обьект по определенному формату преобразования
        /// </summary>
        /// <param name="dataLoggerPath"></param>
        /// <returns></returns>
        [Obsolete]
        private static LoggerFormatConverter CreateFormatConverter(string dataLoggerPath)
        {
            if (dataLoggerPath.ToUpper().Contains(".OPH"))
                return new OldLoggerFormatConverter() { UserID = UserID, EquipmentID = EquipmentID };

            if (dataLoggerPath.ToUpper().Contains(".CSV"))
                return new NewLoggerFormatConverter() { UserID = UserID, EquipmentID = EquipmentID };

            return null;
        }

        private class TransferDataLoggerParameters
        {
            public string DataLoggerPath { get; set; }
            public DateTime StartTimeStamp { get; set; }
            public DateTime EndTimeStamp { get; set; }
            public long? DocID { get; set; }
            public string SensorSerialNumber { get; set; }
        }
    }
}
