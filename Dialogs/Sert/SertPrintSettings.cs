using System;
using System.Collections.Generic;
using System.Text;

//using System.Xml.Linq;
using System.Xml;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// Содержит набор настроек печати сертификатов и методы для их сериализации и десериализации.
    /// </summary>
    public static class SertPrintSettings
    {
        #region Properties

        /// <summary>
        /// Название SQL-сервера.
        /// </summary>
        public static string SertDBDataSource { get; set; }
        /// <summary>
        /// Название базы (SertClient).
        /// </summary>
        public static string SertDBInitialCatalog { get; set; }
        /// <summary>
        /// Логин пользователя SQL-сервера.
        /// </summary>
        public static string SertDBUserID { get; set; }
        /// <summary>
        /// Пароль пользователя SQL-сервера.
        /// </summary>
        public static string SertDBPassword { get; set; }

        /// <summary>
        /// Возвращает признак, показывающий, есть ли настройки подключения к базе сертификатов
        /// </summary>
        public static bool HasSertDBSettings
        {
            get
            {
                return !string.IsNullOrEmpty(SertDBDataSource) &&
                    !string.IsNullOrEmpty(SertDBInitialCatalog) &&
                    !string.IsNullOrEmpty(SertDBUserID) &&
                    !string.IsNullOrEmpty(SertDBPassword);
            }
        }

        /// <summary>
        /// Признак, показывающий, нужно ли использовать принтер "по умолчанию".
        /// </summary>
        public static bool UseDefaultPrinter { get; set; }
        /// <summary>
        /// Название (путь) принтера, выбранного вручную.
        /// </summary>
        public static string CustomPrinterName { get; set; }
        /// <summary>
        /// Признак, показывающий, нужно ли игнорировать режим печати, заданный в задании.
        /// </summary>
        public static bool IgnorePrintMode { get; set; }
        /// <summary>
        /// Режим печати, выбранный вручную.
        /// </summary>
        public static PrintModes CustomPrintMode { get; set; }
        /// <summary>
        /// Признак, показывающий, нужно ли игнорировать проверку истории (количество дней с момента последней печати сертификата) в задании.
        /// </summary>
        public static bool IgnoreCheckHistory { get; set; }
        /// <summary>
        /// Количество дней с момента последней печати сертификата, установленное вручную.
        /// </summary>
        public static UInt16 CustomNoPrintDaysCount { get; set; }
        /// <summary>
        /// Признак, показывающий, нужно ли игнорировать масштаб вывода в задании.
        /// </summary>
        public static bool IgnoreScale { get; set; }
        /// <summary>
        /// Масштаб вывода сертификатов на странице, выбранный вручную.
        /// </summary>
        public static Scales CustomScale { get; set; }
        /// <summary>
        /// Признак, показывающий, нужно ли ограничивать максимальное количество страниц в одном печатаемом документе
        /// </summary>
        public static bool UseLimitOfPages { get; set; }
        /// <summary>
        /// Максимальное количество страниц в одном печатаемом документе
        /// </summary>
        public static UInt16 CustomPagesInBatchCount { get; set; }

        #endregion


        #region Static constructor

        /// <summary>
        /// Статический конструктор, вызываемый при первом обращении к классу.
        /// </summary>
        static SertPrintSettings()
        {
            Clear();
        }

        /// <summary>
        /// Очищает (сбрасывает) настройки.
        /// </summary>
        private static void Clear()
        {
            SertDBDataSource = string.Empty;
            SertDBInitialCatalog = string.Empty;
            SertDBUserID = string.Empty;
            SertDBPassword = string.Empty;

            UseDefaultPrinter = true;
            CustomPrinterName = string.Empty;
            IgnorePrintMode = false;
            CustomPrintMode = PrintModes.SingleSided;
            IgnoreCheckHistory = false;
            CustomNoPrintDaysCount = 365;
            IgnoreScale = false;
            CustomScale = Scales.Scale1x2;
            UseLimitOfPages = true;
            CustomPagesInBatchCount = 200;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Возвращает строку подключения к базе с изображениями сертификатов (SertClient).
        /// </summary>
        /// <returns>Строка подключения к базе с изображениями сертификатов.</returns>
        [Obsolete("Подключение к БД SertClient больше не используется")]
        public static string GetSertDBConnectionString()
        {
            return (new System.Data.SqlClient.SqlConnectionStringBuilder() { DataSource = SertDBDataSource, InitialCatalog = SertDBInitialCatalog, UserID = SertDBUserID, Password = SertDBPassword }).ToString();
        }

        /// <summary>
        /// Генерирует XML, содержащий настройки печати сертификатов.
        /// </summary>
        /// <returns>XML, содержащий настройки печати сертификатов.</returns>
        public static string GetXML()
        {
            StringBuilder result = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(result);
            writer.WriteStartDocument();
            writer.WriteStartElement("SertPrintSettings");
            writer.WriteAttributeString("Version", "1");

            writer.WriteStartElement("SertDB");
            writer.WriteAttributeString("SertDBDataSource", SertDBDataSource);
            writer.WriteAttributeString("SertDBInitialCatalog", SertDBInitialCatalog);
            writer.WriteAttributeString("SertDBUserID", SertDBUserID);
            writer.WriteAttributeString("SertDBPassword", SertDBPassword);
            writer.WriteEndElement();

            writer.WriteStartElement("Printer");
            writer.WriteAttributeString("UseDefaultPrinter", UseDefaultPrinter ? "1" : "0");
            writer.WriteAttributeString("CustomPrinterName", CustomPrinterName);
            writer.WriteEndElement();

            writer.WriteStartElement("PrintMode");
            writer.WriteAttributeString("IgnorePrintMode", IgnorePrintMode ? "1" : "0");
            writer.WriteAttributeString("CustomPrintMode", ((int)CustomPrintMode).ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("CheckHistory");
            writer.WriteAttributeString("IgnoreCheckHistory", IgnoreCheckHistory ? "1" : "0");
            writer.WriteAttributeString("CustomNoPrintDaysCount", CustomNoPrintDaysCount.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Scale");
            writer.WriteAttributeString("IgnoreScale", IgnoreScale ? "1" : "0");
            writer.WriteAttributeString("CustomScale", ((int)CustomScale).ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("LimitOfPages");
            writer.WriteAttributeString("UseLimitOfPages", UseLimitOfPages ? "1" : "0");
            writer.WriteAttributeString("CustomPagesInBatchCount", CustomPagesInBatchCount.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            return result.ToString();

            // под .NET 2.0 нету Linq2Xml :(
            /*XElement result = new XElement("SertPrintSettings",
                new XAttribute("Version", "1"),
                new XElement("SertDB",
                    new XAttribute("SertDBDataSource", SertDBDataSource),
                    new XAttribute("SertDBInitialCatalog", SertDBInitialCatalog),
                    new XAttribute("SertDBUserID", SertDBUserID),
                    new XAttribute("SertDBPassword", SertDBPassword)
                    ),
                new XElement("Printer",
                    new XAttribute("UseDefaultPrinter", UseDefaultPrinter ? "1" : "0"),
                    new XAttribute("CustomPrinterName", CustomPrinterName)
                    ),
                new XElement("PrintMode",
                    new XAttribute("IgnorePrintMode", IgnorePrintMode ? "1" : "0"),
                    new XAttribute("CustomPrintMode", (int)CustomPrintMode)
                    ),
                new XElement("CheckHistory",
                    new XAttribute("IgnoreCheckHistory", IgnoreCheckHistory ? "1" : "0"),
                    new XAttribute("CustomNoPrintDaysCount", CustomNoPrintDaysCount)
                    ),
                new XElement("Scale",
                    new XAttribute("IgnoreScale", IgnoreScale ? "1" : "0"),
                    new XAttribute("CustomScale", (int)CustomScale)
                    )
            );
            return result.ToString();*/
        }

        /// <summary>
        /// Разбирает XML, содержащий настройки печати сертификатов. Перед разбором выполняется сброс настроек, во время парсинга могут порождаться исключения.
        /// </summary>
        /// <param name="xmlSettings">XML, содержащий настройки печати сертификатов.</param>
        public static void ParseXML(string xmlSettings)
        {
            Clear();

            System.IO.StringReader sr = new System.IO.StringReader(xmlSettings);
            XmlReader reader = XmlReader.Create(sr);
            reader.Read();
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "SertPrintSettings")
            {
                if (reader.GetAttribute("Version") == "1")
                {
                    if (reader.ReadToDescendant("SertDB"))
                    {
                        SertDBDataSource = GetSertAttributeValue(reader, "SertDBDataSource");
                        SertDBInitialCatalog = GetSertAttributeValue(reader, "SertDBInitialCatalog");
                        SertDBUserID = GetSertAttributeValue(reader, "SertDBUserID");
                        SertDBPassword = GetSertAttributeValue(reader, "SertDBPassword");
                    }
                    else
                    {
                        throw new Exception("Во время разбора XML с настройками не найден узел SertDB.");
                    }

                    if (reader.Read() && reader.Name == "Printer")
                    {
                        UseDefaultPrinter = GetSertAttributeValue(reader, "UseDefaultPrinter") == "1" ? true : false;
                        CustomPrinterName = GetSertAttributeValue(reader, "CustomPrinterName");
                    }
                    else
                    {
                        throw new Exception("Во время разбора XML с настройками не найден узел Printer.");
                    }

                    if (reader.Read() && reader.Name == "PrintMode")
                    {
                        IgnorePrintMode = GetSertAttributeValue(reader, "IgnorePrintMode") == "1" ? true : false;
                        CustomPrintMode = (PrintModes)Convert.ToInt32(GetSertAttributeValue(reader, "CustomPrintMode"));
                    }
                    else
                    {
                        throw new Exception("Во время разбора XML с настройками не найден узел PrintMode.");
                    }

                    if (reader.Read() && reader.Name == "CheckHistory")
                    {
                        IgnoreCheckHistory = GetSertAttributeValue(reader, "IgnoreCheckHistory") == "1" ? true : false;
                        CustomNoPrintDaysCount = Convert.ToUInt16(GetSertAttributeValue(reader, "CustomNoPrintDaysCount"));
                    }
                    else
                    {
                        throw new Exception("Во время разбора XML с настройками не найден узел CheckHistory.");
                    }

                    if (reader.Read() && reader.Name == "Scale")
                    {
                        IgnoreScale = GetSertAttributeValue(reader, "IgnoreScale") == "1" ? true : false;
                        CustomScale = (Scales)Convert.ToInt32(GetSertAttributeValue(reader, "CustomScale"));
                    }
                    else
                    {
                        throw new Exception("Во время разбора XML с настройками не найден узел Scale.");
                    }

                    if (reader.Read() && reader.Name == "LimitOfPages")
                    {
                        UseLimitOfPages = GetSertAttributeValue(reader, "UseLimitOfPages") == "1" ? true : false;
                        CustomPagesInBatchCount = Convert.ToUInt16(GetSertAttributeValue(reader, "CustomPagesInBatchCount"));
                    }
                    else
                    {
                        throw new Exception("Во время разбора XML с настройками не найден узел LimitOfPages.");
                    }
                }
                else
                {
                    throw new Exception("Во время разбора XML с настройками не указана поддерживаемая версия.");
                }
            }
            else
            {
                throw new Exception("Во время разбора XML с настройками не найден корневой узел.");
            }

            reader.Close();
            sr.Dispose();

            // под .NET 2.0 нету Linq2Xml :(
            /*XElement settings = XElement.Parse(xmlSettings);
            if (settings.Name != "SertPrintSettings")
                throw new Exception("Во время разбора XML с настройками не найден корневой узел.");
            if (settings.Attribute("Version") == null || settings.Attribute("Version").Value != "1")
                throw new Exception("Во время разбора XML с настройками не указана поддерживаемая версия.");
            
            XElement sertDB = settings.Element("SertDB");
            if (sertDB == null)
            {
                throw new Exception("Во время разбора XML с настройками не найден узел SertDB.");
            }
            else
            {
                SertDBDataSource = sertDB.GetSertAttributeValue("SertDBDataSource");
                SertDBInitialCatalog = sertDB.GetSertAttributeValue("SertDBInitialCatalog");
                SertDBUserID = sertDB.GetSertAttributeValue("SertDBUserID");
                SertDBPassword = sertDB.GetSertAttributeValue("SertDBPassword");
            }

            XElement printer = settings.Element("Printer");
            if (printer == null)
            {
                throw new Exception("Во время разбора XML с настройками не найден узел Printer.");
            }
            else
            {
                UseDefaultPrinter = printer.GetSertAttributeValue("UseDefaultPrinter") == "1" ? true : false;
                CustomPrinterName = printer.GetSertAttributeValue("CustomPrinterName");
            }

            XElement printMode = settings.Element("PrintMode");
            if (printMode == null)
            {
                throw new Exception("Во время разбора XML с настройками не найден узел PrintMode.");
            }
            else
            {
                IgnorePrintMode = printMode.GetSertAttributeValue("IgnorePrintMode") == "1" ? true : false;
                CustomPrintMode = (PrintModes)Convert.ToInt32(printMode.GetSertAttributeValue("CustomPrintMode"));
            }

            XElement checkHistory = settings.Element("CheckHistory");
            if (checkHistory == null)
            {
                throw new Exception("Во время разбора XML с настройками не найден узел CheckHistory.");
            }
            else
            {
                IgnoreCheckHistory = checkHistory.GetSertAttributeValue("IgnoreCheckHistory") == "1" ? true : false;
                CustomNoPrintDaysCount = Convert.ToUInt16(checkHistory.GetSertAttributeValue("CustomNoPrintDaysCount"));
            }

            XElement scale = settings.Element("Scale");
            if (scale == null)
            {
                throw new Exception("Во время разбора XML с настройками не найден узел Scale.");
            }
            else
            {
                IgnoreScale = scale.GetSertAttributeValue("IgnoreScale") == "1" ? true : false;
                CustomScale = (Scales)Convert.ToInt32(scale.GetSertAttributeValue("CustomScale"));
            }*/
        }

        /// <summary>
        /// Извлекает значение атрибута xml-элемента из XmlReader'а, порождая исключение, если такой атрибут не найден.
        /// </summary>
        /// <param name="reader">Текущий XmlReader.</param>
        /// <param name="attributeName">Название атрибута, хранящего нужное значение настроек печати сертификатов.</param>
        /// <returns>Значение атрибута.</returns>
        private static string GetSertAttributeValue(XmlReader reader, string attributeName)
        {
            if (reader.GetAttribute(attributeName) != null)
                return reader.GetAttribute(attributeName);
            else
                throw new Exception("Во время разбора XML с настройками не найден атрибут " + attributeName + ".");
        }

        /*/// <summary>
        /// Извлекает значение атрибута из указанного XML-элемента, порождая исключение, если такой атрибут не найден.
        /// </summary>
        /// <param name="element">Текущий XElement.</param>
        /// <param name="attributeName">Название атрибута, хранящего нужное значение настроек печати сертификатов.</param>
        /// <returns>Значение атрибута.</returns>
        private static string GetSertAttributeValue(this XElement element, string attributeName)
        {
            XAttribute attr = element.Attribute(attributeName);
            if (attr == null)
                throw new Exception("Во время разбора XML с настройками не найден атрибут " + attributeName + ".");
            else
                return attr.Value;
        }*/

        #endregion


        #region Enums: PrintModes, Scales

        /// <summary>
        /// Содержит варианты режимов печати.
        /// </summary>
        public enum PrintModes
        {
            /// <summary>
            /// Односторонняя
            /// </summary>
            SingleSided = 0,
            /// <summary>
            /// Двусторонняя: новая серия - новый лист.
            /// </summary>
            DoubleSidedNewPageSerie = 1,
            /// <summary>
            /// Двусторонняя: новый товар - новый лист.
            /// </summary>
            DoubleSidedNewPageItem = 2,
            /// <summary>
            /// Двусторонняя: сплошной поток.
            /// </summary>
            DoubleSidedContinuous = 3,
        }

        /// <summary>
        /// Содержит вырианты масштабов вывода.
        /// </summary>
        public enum Scales
        {
            /// <summary>
            /// 1х1: одно изображение на странице.
            /// </summary>
            Scale1x1 = 0,
            /// <summary>
            /// 1х2: два изображения на странице.
            /// </summary>
            Scale1x2 = 1,
            /// <summary>
            /// 1х4: четыре изображения на странице.
            /// </summary>
            Scale1x4 = 2,
        }

        #endregion
    }
}
