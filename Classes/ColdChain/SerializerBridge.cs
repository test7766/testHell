using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Classes.ColdChain.FileProviders;
using WMSOffice.Classes.ColdChain.Serializers;
using WMSOffice.Classes.ColdChain.Utils;

namespace WMSOffice.Classes.ColdChain
{
    public class SerializerBridge
    {
        private readonly Dictionary<FileProviderBase, List<SerializerBase>> fileProviderSerializerMappers = null;

        public long SessionID { get; set; }

        public string SensorSerialNumber { get; set; }

        public event EventHandler<DeserializationCompleteEventArgs> OnDeserializationComplete;

        public SerializerBridge()
        {
            fileProviderSerializerMappers = new Dictionary<FileProviderBase, List<SerializerBase>>();

            fileProviderSerializerMappers.Add(new FileProviderOPH(), new List<SerializerBase>(new SerializerBase[] { new SerializerOPH() }));
            fileProviderSerializerMappers.Add(new FileProviderCSV(), new List<SerializerBase>(new SerializerBase[] { new SerializerMicroLite() }));
            fileProviderSerializerMappers.Add(new FileProviderXLS(), new List<SerializerBase>(new SerializerBase[] { new SerializerTermoTester(), new SerializerTermoTesterUSB(), new SerializerEliTech() }));
        }

        public void Deserialize(string filePath)
        {
            FileProviderBase suitedFileProvider = null;
            #region ПОДБОР ПОДХОДЯЩЕГО ПОСТАВЩИКА ДАННЫХ ПО РАСШИРЕНИЮ ФАЙЛА
            foreach (var kvp in fileProviderSerializerMappers)
            {
                var fileProvider = kvp.Key;

                //var extension = (string)null;
                //FileProviderUsageAttribute fpua = null;
                IEnumerable<string> extensions = null;
                foreach (FileProviderUsageAttribute attr in fileProvider.GetType().GetCustomAttributes(typeof(FileProviderUsageAttribute), true))
                {
                    //extension = attr.Extensions;
                    //fpua = attr;
                    extensions = attr.Extensions;
                    break;
                }

                if (extensions != null)
                {
                    foreach (var extension in extensions)
                    {
                        if (filePath.ToUpper().Contains(extension))
                        {
                            suitedFileProvider = fileProvider;
                            break;
                        }
                    }
                }

                //if (extension != null && filePath.ToUpper().Contains(extension))
                //{
                //    suitedFileProvider = fileProvider;
                //    break;
                //}
            }
            #endregion

            if (suitedFileProvider != null)
            {
                Buffer buffer = null;
                if (suitedFileProvider.PopulateBuffer(filePath, out buffer))
                {
                    SerializerBase suitedSerializer = null;
                    #region ПОДБОР ПОДХОДЯЩЕГО ПАРСЕРА ДАННЫХ ПРЕДСТАВЛЕННЫХ В ОПРЕДЕЛЕННОМ ФОРМАТЕ
                    foreach (var serializer in fileProviderSerializerMappers[suitedFileProvider])
                    {
                        if (serializer.TryDeserialize(buffer))
                        {
                            suitedSerializer = serializer;
                            break;
                        }
                    }
                    #endregion

                    if (suitedSerializer != null)
                    {
                        // Парсим и импортируем данные в систему из буфера
                        suitedSerializer.SessionID = this.SessionID;
                        suitedSerializer.SensorSerialNumber = this.SensorSerialNumber;

                        if (suitedSerializer.Deserialize(buffer))
                        {
                            // Если мы получили данные, то сгенерируем событие для пост-обработки
                            if (OnDeserializationComplete != null)
                                OnDeserializationComplete(this, new DeserializationCompleteEventArgs(suitedSerializer.Data));
                        }
                    }
                    else
                        throw new Exception("Ошибка в формате данных файла.");
                }
                else
                    throw new Exception("Ошибка чтения данных с файла.");
            }
            else
                throw new Exception("Обработка указанного формата не реализована.");
        }
    }
}
