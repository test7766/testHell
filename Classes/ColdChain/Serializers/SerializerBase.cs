using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Data.ColdChainTableAdapters;

namespace WMSOffice.Classes.ColdChain.Serializers
{
    public abstract class SerializerBase
    {
        public abstract bool TryDeserialize(Buffer buffer);
        public abstract bool Deserialize(Buffer buffer);

        public long SessionID { get; set; }

        public string SensorSerialNumber { get; set; }

        /// <summary>
        /// Таблица для хранения данных логгера, полученных из файла
        /// </summary>
        public WMSOffice.Data.ColdChain.LoggerDataTransferDataTable Data { get; protected set; }

        public short Algorithm { get; protected set; }
        public long UserID { get; set; }

        protected void Initialize()
        {
            // Выполним выгрузку данных из БД и подготовим правильную структуру
            using (LoggerDataTransferTableAdapter adapter = new LoggerDataTransferTableAdapter())
            {
                Data = adapter.GetData(this.Algorithm, this.UserID);
                Data.Clear();
            }
        }
    }
}
