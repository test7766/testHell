using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// Предоставляет методы и свойства для печати сертификатов по отдельному заказу (заданию) в отдельном потоке.
    /// </summary>
    public class SertPrintingThread
    {
        /// <summary>
        /// Период между запросами новых заданий автоматической печати.
        /// </summary>
        public const int AutoPrintTimeout = 10 * 1000;

        /// <summary>
        /// Объект-заменитель изображения (для уменьшения размера выделяемой памяти на этапе загрузки всех изображений и печати контрольного листа).
        /// </summary>
        private Image ImageBodyReplacer = new Bitmap(16, 16);

        #region Fields

        /// <summary>
        /// Данные "заголовка" задачи.
        /// </summary>
        private Data.Sert.TasksRow taskRow;

        /// <summary>
        /// Признак необходимости печатать водяные знаки
        /// </summary>
        private bool needPrintWatermark = false;

        /// <summary>
        /// Данные "строк" задачи.
        /// </summary>
        private Data.Sert.TaskDetailsDataTable taskDetails;

        /// <summary>
        /// Список строк заказа (задачи), для которых сертификаты уже были напечатаны ранее.
        /// </summary>
        private Dictionary<Data.Sert.TaskDetailsRow, string> alreadyPrintedRows;

        /// <summary>
        /// Список изображений для печати.
        /// </summary>
        private List<ImageContainer> images;

        /// <summary>
        /// Список ошибок.
        /// </summary>
        private List<Error> errors;

        /// <summary>
        /// Таймер, запускающий новые потоки.
        /// </summary>
        private static System.Threading.Timer timer;

        /// <summary>
        /// Ссылка на текущий поток печати сертификатов.
        /// </summary>
        private static SertPrintingThread currentPrintingThread;

        #endregion


        #region Constructor

        /// <summary>
        /// Инициализирует новый экземпляр класса SertPrintingThread.
        /// </summary>
        public SertPrintingThread()
        {
            this.alreadyPrintedRows = new Dictionary<Data.Sert.TaskDetailsRow, string>();
            this.images = new List<ImageContainer>();
            this.errors = new List<Error>();
            ContinueAutoPrint = false;
            TaskState = SertPrintTaskStates.None;
        }

        static SertPrintingThread()
        {
            SertPrintingThreadWorkerParameter = new SertPrintingThreadParameter();
        }

        #endregion


        #region Public properties

        /// <summary>
        /// Ссылка на текущий поток печати сертификатов.
        /// </summary>
        public static SertPrintingThread CurrentPrintingThread { get { return currentPrintingThread; } }

        /// <summary>
        /// Признак, показывающий, запущена ли автоматическая обработка заданий.
        /// </summary>
        public static bool AutoPrintStarted { get { return CurrentPrintingThread != null && CurrentPrintingThread.ContinueAutoPrint && timer != null; } }

        /// <summary>
        /// Идентификатор сессии пользователя.
        /// </summary>
        public static int UserID { get; set; }

        /// <summary>
        /// Внешний параметр рабочего потока
        /// </summary>
        public static SertPrintingThreadParameter SertPrintingThreadWorkerParameter { get; set; }

        /// <summary>
        /// Текущее состояние задачи.
        /// </summary>
        public SertPrintTaskStates TaskState { get; private set; }

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Идентификатор текущей задачи.
        /// </summary>
        public long TaskID { get { return taskRow == null ? 0 : taskRow.TaskID; } }

        /// <summary>
        /// Номер текущего документа.
        /// </summary>
        public string DocNumber
        {
            get
            {
                return taskRow == null
                    ? "-"
                    : string.Format("{0}-{1}",
                        !taskRow.IsDCTONull() ? taskRow.DCTO : (!taskRow.IsDCTNull() ? taskRow.DCT : string.Empty),
                        !taskRow.IsDOCONull() ? taskRow.DOCO.ToString() : (!taskRow.IsDOCNull() ? taskRow.DOC.ToString() : string.Empty));
            }
        }

        /// <summary>
        /// Тип документа
        /// </summary>
        public DocKind DocKind
        {
            get
            {
                if (!taskRow.IsDCTONull() && !taskRow.IsDOCONull())
                    return DocKind.Order;
                if (!taskRow.IsDCTNull() && !taskRow.IsDOCNull())
                    return DocKind.Invoice;
                return DocKind.Unknown;
            }
        }

        /// <summary>
        /// Код и наименование клиента в текущей задаче.
        /// </summary>
        public string CustomerCodeAndName { get { return taskRow == null ? "-" : "(" + taskRow.CustomerCode.ToString() + ") " + taskRow.CustomerName; } }

        public class SertPrintingThreadParameter
        {
            /// <summary>
            /// Признак печати сертификатов по заданиям, содержащих вакцину 
            /// </summary>
            public bool PrintOnlyVaccinesTasks { get; set; }
        }

        #endregion


        #region Private properties

        /// <summary>
        /// Признак, показывающий, нужно ли продолжать автоматическую обработку задач.
        /// </summary>
        private bool ContinueAutoPrint { get; set; }

        /// <summary>
        /// Текущий режим печати.
        /// </summary>
        private SertPrintSettings.PrintModes CurrentPrintMode { get; set; }

        /// <summary>
        /// Текущий масштаб.
        /// </summary>
        private SertPrintSettings.Scales CurrentScale { get; set; }

        /// <summary>
        /// Текущее количество страниц печатаемых сертификатов.
        /// </summary>
        private int CurrentTotalPagesCount { get; set; }

        /// <summary>
        /// Текущий номер страницы.
        /// </summary>
        private int CurrentPageNumber { get; set; }

        /// <summary>
        /// Текущий индекс изображения.
        /// </summary>
        private int CurrentImageIndex { get; set; }

        /// <summary>
        /// Текущий индекс изображения на текущей странице (используется при масштабах 1х2, 1х4).
        /// </summary>
        private int CurrentImageOnPageIndex { get; set; }

        /// <summary>
        /// Код текущего товара.
        /// </summary>
        private double CurrentItemCode { get; set; }

        /// <summary>
        /// Номер текущей серии товара.
        /// </summary>
        private string CurrentVendorLot { get; set; }

        /// <summary>
        /// Шрифт, используемый при выводе надписей над изображениями.
        /// </summary>
        private Font CurrentHeaderFont { get; set; }

        /// <summary>
        /// Шрифт, используемый при выводе надписей внизу страниц.
        /// </summary>
        private Font CurrentFooterFont { get; set; }

        #endregion


        #region Start & stop auto print

        /// <summary>
        /// Запускает автоматическую обработку заданий. Первое задание начнет выполняться через секунду.
        /// </summary>
        public static void StartAutoPrint()
        {
            if (timer == null && (CurrentPrintingThread == null || CurrentPrintingThread.TaskState != SertPrintTaskStates.Processing))
            {
                currentPrintingThread = new SertPrintingThread();
                currentPrintingThread.ContinueAutoPrint = true;
                timer = new System.Threading.Timer(new System.Threading.TimerCallback(currentPrintingThread.RunAuto), null, 1 * 1000, System.Threading.Timeout.Infinite);
            }
        }

        /// <summary>
        /// Останавливает автоматическую обработку заданий. Метод будет выполняться до тех пор, пока идет обработка текущего задания.
        /// </summary>
        public static void StopAutoPrint()
        {
            if (AutoPrintStarted)
            {
                CurrentPrintingThread.ContinueAutoPrint = false;
                timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                timer.Dispose();
                timer = null;
                // CrystalReports, как я понял, при формировании отчета иногда что-то 
                // выполняет в основном потоке, что приводит к бесконечному ожиданию
                int sleepCounter = 0;
                while (CurrentPrintingThread.TaskState == SertPrintTaskStates.Processing && sleepCounter < 20)
                {
                    ++sleepCounter;
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        /// <summary>
        /// Печатает сертификаты для указанной задачи и, если задача не из архива, устанавливает для неё признак "обработано".
        /// </summary>
        /// <param name="taskRow">Данные о задаче (заголовок).</param>
        /// <param name="taskFromArchive">Признак, показывающий, загружена ли задача из архива (уже была обработана).</param>
        public void Run(Data.Sert.TasksRow taskRow, bool taskFromArchive)
        {
            TaskState = SertPrintTaskStates.Processing;
            ClearAll();
            this.taskRow = taskRow;
            if (taskRow == null)
            {
                throw new ArgumentException("Не задана строка задания.", "taskRow");
            }
            using (Data.SertTableAdapters.TaskDetailsTableAdapter adapter = new Data.SertTableAdapters.TaskDetailsTableAdapter())
            {
                taskDetails = adapter.GetData(taskRow.TaskID);
            }

            SetCurrentPrintSettings(taskRow);
            if (!taskFromArchive)
                CheckAlreadyPrintedRows();
            GetImages();
            PrintControlList();
            PrintImages();
            if (!taskFromArchive)
                UpdateAlreadyPrintHistory();
            SaveErrors();

            using (Data.SertTableAdapters.TasksTableAdapter adapter = new Data.SertTableAdapters.TasksTableAdapter())
            {
                adapter.ChangeTaskState(UserID, TaskID, true, false, null);
                ClearAll();
            }
            TaskState = SertPrintTaskStates.Successful;
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Загружает из базы данных одну еще невыполненную задачу и запускает её обработку, после чего заново инициализирует таймер, если не установлен признак остановки.
        /// </summary>
        private void RunAuto(object o)
        {
            TaskState = SertPrintTaskStates.Processing;
            try
            {
                using (Data.SertTableAdapters.TasksTableAdapter adapter = new Data.SertTableAdapters.TasksTableAdapter())
                {
                    lock (SertPrintingThreadWorkerParameter)
                    {
                        Data.Sert.TasksDataTable table = adapter.GetNotProcessedTask(UserID, SertPrintingThreadWorkerParameter.PrintOnlyVaccinesTasks);
                        if (table.Rows.Count > 0)
                        {
                            Run((Data.Sert.TasksRow)table.Rows[0], false);
                        }
                        else
                        {
                            TaskState = SertPrintTaskStates.TasksNotFound;
                        }
                    }
                }
                if (ContinueAutoPrint)
                {
                    timer.Change(AutoPrintTimeout, System.Threading.Timeout.Infinite);
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\log.txt", DateTime.Now.ToString() + " TaskID: " + TaskID + ", Error: " + ex.ToString() + Environment.NewLine);
                ErrorMessage = ex.Message;
                ContinueAutoPrint = false;
                timer.Dispose();
                timer = null;
                System.Threading.Thread.Sleep(10 * 1000); // пауза необходима из-за возможных проблем с сетью, когда записать ошибку в базу невозможно
                try
                {
                    using (Data.SertTableAdapters.TasksTableAdapter adapter = new Data.SertTableAdapters.TasksTableAdapter())
                    {
                        adapter.ChangeTaskState(UserID, TaskID, false, true, ex.ToString());
                    }
                }
                catch (Exception ex2)
                {
                    System.Threading.Thread.Sleep(60 * 1000); // пауза необходима из-за возможных проблем с сетью, когда записать ошибку в базу невозможно.
                    try
                    {
                        using (Data.SertTableAdapters.TasksTableAdapter adapter = new Data.SertTableAdapters.TasksTableAdapter())
                        {
                            adapter.ChangeTaskState(UserID, TaskID, false, true, "2nd error: " + ex2.Message + ", 1st error: " + ex.ToString());
                        }
                    }
                    catch { }
                }
                TaskState = SertPrintTaskStates.Error;
            }
        }

        /// <summary>
        /// Устанавливает текущие настройки печати, используя указанные в задании данные и общие настройки.
        /// </summary>
        private void SetCurrentPrintSettings(Data.Sert.TasksRow taskRow)
        {
            // Признак заказов с типом "10"
            bool is_DCTO_10 = (!taskRow.IsDCTONull() && taskRow.DCTO == "10") || (!taskRow.IsDCTNull() && taskRow.DCT == "V0");

            CurrentPrintMode = SertPrintSettings.IgnorePrintMode ? SertPrintSettings.CustomPrintMode : (SertPrintSettings.PrintModes)taskRow.PrintModeIndex;
            CurrentScale = is_DCTO_10 ? SertPrintSettings.Scales.Scale1x1 : SertPrintSettings.IgnoreScale ? SertPrintSettings.CustomScale : (SertPrintSettings.Scales)taskRow.ScaleIndex;

            needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(UserID, "SP", 22, Convert.ToInt64(taskRow.TaskID), (string)null);
        }

        /// <summary>
        /// Проверяет список строк задачи, выделяя строки, для которых сертификаты уже были напечатаны ранее.
        /// </summary>
        private void CheckAlreadyPrintedRows()
        {
            // значения "000" (в JD), "0" (дней в параметрах) = "не проверять историю".
            if ((SertPrintSettings.IgnoreCheckHistory ? SertPrintSettings.CustomNoPrintDaysCount : taskRow.NoPrintDaysCount) == 0)
                return;

            using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
            {
                //adapter.SetConnectionString(SertPrintSettings.GetSertDBConnectionString());
                foreach (Data.Sert.TaskDetailsRow row in taskDetails.Rows)
                {
                    object alreadyPrinted = adapter.GetAlreadyPrinted(
                        (int)row.ItemCode,
                        row.VendorLot,
                        (int)taskRow.CustomerCode,
                        SertPrintSettings.IgnoreCheckHistory ? SertPrintSettings.CustomNoPrintDaysCount : taskRow.NoPrintDaysCount);
                    if (alreadyPrinted != null)
                        alreadyPrintedRows.Add(row, alreadyPrinted.ToString());
                }
            }
        }

        /// <summary>
        /// Загружает изображения по товарам и по сериям товаров.
        /// </summary>
        private void GetImages()
        {
            //var cnt = 4;
            foreach (Data.Sert.TaskDetailsRow row in taskDetails.Rows)
            {
                if (alreadyPrintedRows.ContainsKey(row))
                    continue;

                if (GetImagesByItem(row))
                    GetImagesByItemAndVendorLot(row);

                //if (--cnt == 0)
                //    break;
            }
        }

        /// <summary>
        /// Загружает изображения, привязанные к товару (без привязок к сериям).
        /// </summary>
        /// <param name="taskDetailsRow">Данные "строки" задачи.</param>
        /// <returns>Признак, показывающий, была ли найдена информация об этом товаре.</returns>
        private bool GetImagesByItem(Data.Sert.TaskDetailsRow taskDetailsRow)
        {
            bool result = false;
            using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
            {
                //adapter.SetConnectionString(SertPrintSettings.GetSertDBConnectionString());
                object itemInfoExists = adapter.ItemInfoExists((int)taskDetailsRow.ItemCode);
                if (itemInfoExists != null && !itemInfoExists.Equals(DBNull.Value) && itemInfoExists.ToString() == "1")
                {
                    result = true;
                    using (Data.SertTableAdapters.ItemImagesTableAdapter itemImagesAdapter = new Data.SertTableAdapters.ItemImagesTableAdapter())
                    {
                        //itemImagesAdapter.Connection.ConnectionString = SertPrintSettings.GetSertDBConnectionString();
                        Data.Sert.ItemImagesDataTable table = itemImagesAdapter.GetData((int)taskDetailsRow.ItemCode);
                        foreach (Data.Sert.ItemImagesRow itemImageRow in table.Rows)
                        {
                            // проверка, есть ли такое изображение
                            bool found = false;
                            foreach (ImageContainer ic in images)
                                if (ic.ImageID == itemImageRow.ImageID)
                                    found = true;
                            if (!found)
                            {
                                Image img = null;
                                var imgPages = new List<byte[]>();
                                var extension = itemImageRow.IsImageExtNull() ? string.Empty : itemImageRow.ImageExt;
                                try
                                {
                                    //img = itemImageRow.IsImageBodyNull() ? null : SertImageUtils.UnpackImageByTCompress(itemImageRow.ImageBody);

                                    if (!itemImageRow.IsImageBodyNull())
                                    {
                                        //using (var ms = new MemoryStream(itemImageRow.ImageBody))
                                        //    img = Image.FromStream(ms);

                                        //imgPages = this.GetImagesFromBytes(itemImageRow.ImageBody, extension);
                                        imgPages = ImageUtils.ExtractImageLayersFromDataBufferEx(itemImageRow.ImageBody, extension);
                                    }
                                }
                                catch (Exception)
                                {
                                    // UNDONE: записать в лог ошибку преобразования изображения
                                }

                                //if (img != null)
                                //{
                                //    img.Dispose();
                                //    img = ImageBodyReplacer; // для уменьшения объема требуемой памяти
                                //}


                                foreach (var imgPage in imgPages)
                                {
                                    try
                                    {
                                        img = Image.FromStream(new MemoryStream(imgPage));
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(string.Format("Ошибка при получении изображения:\nВозможно ипользуется недопустимый формат.\nItemName={0}; ItemCode={1}; extension={2};", taskDetailsRow.ItemName, (int)taskDetailsRow.ItemCode, extension), ex);
                                    }

                                    //this.PrepareImage(ref img, extension);
                                    ImageUtils.PrepareLightweightImage(ref img, extension, ImageBodyReplacer);

                                    images.Add(
                                        new ImageContainer(
                                            Dialogs.Sert.SertPrintingThread.CertType.QualityCert,
                                            taskDetailsRow.ItemCode,
                                            taskDetailsRow.VendorLot,
                                            taskDetailsRow.ItemName,
                                            taskDetailsRow.ManufacturerName,
                                            itemImageRow.ImageID,
                                            img
                                            ) { ImageBuffer = imgPage });
                                }
                            }
                            if (images.Count > 0 && images[images.Count - 1].Image == null)
                                errors.Add(new Error(ErrorTypes.ImageIsEmpty, taskDetailsRow));
                        }
                    }
                }
                else
                {
                    result = false;
                    errors.Add(new Error(ErrorTypes.ItemNotFound, taskDetailsRow));
                }
            }
            return result;
        }

        /// <summary>
        /// Загружает изображения, привязанные к товару и серии поставщика.
        /// </summary>
        /// <param name="taskDetailsRow">Данные "строки" задачи.</param>
        private void GetImagesByItemAndVendorLot(Data.Sert.TaskDetailsRow taskDetailsRow)
        {
            //if ((int)taskDetailsRow.ItemCode == 9304 && taskDetailsRow.VendorLot == "2116096B")
            //{
            //    errors.Add(new Error(ErrorTypes.ImageIsEmpty, taskDetailsRow));
            //    return;
            //}

            var series = new Data.Sert.SeriesIDDataTable();
            using (var adapter = new Data.SertTableAdapters.SeriesIDTableAdapter())
                adapter.Fill(series, (int)taskDetailsRow.ItemCode, taskDetailsRow.VendorLot);

            if (series == null && series.Rows.Count == 0)
            {
                errors.Add(new Error(ErrorTypes.VendorLotNotFound, taskDetailsRow));
                return;
            }

            using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
            {
                //adapter.SetConnectionString(SertPrintSettings.GetSertDBConnectionString());
                //object serID = adapter.GetSerID((int)taskDetailsRow.ItemCode, taskDetailsRow.VendorLot);
                //if (serID != null && !serID.Equals(DBNull.Value))
                //{
                using (Data.SertTableAdapters.ItemSerieImagesTableAdapter itemSerieImagesAdapter = new Data.SertTableAdapters.ItemSerieImagesTableAdapter())
                {
                    //itemSerieImagesAdapter.Connection.ConnectionString = SertPrintSettings.GetSertDBConnectionString();

                    foreach (Data.Sert.SeriesIDRow rSerie in series.Rows)
                    {

                        Data.Sert.ItemSerieImagesDataTable table = itemSerieImagesAdapter.GetData((int)rSerie.SerID);
                        foreach (Data.Sert.ItemSerieImagesRow itemSerieImageRow in table.Rows)
                        {
                            // проверка, есть ли такое изображение
                            bool found = false;
                            foreach (ImageContainer ic in images)
                                if (ic.ImageID == itemSerieImageRow.ImageID)
                                    found = true;
                            if (!found)
                            {
                                Image img = null;
                                var imgPages = new List<byte[]>();
                                var extension = itemSerieImageRow.IsImageExtNull() ? string.Empty : itemSerieImageRow.ImageExt;
                                try
                                {
                                    //img = itemSerieImageRow.IsImageBodyNull() ? null : SertImageUtils.UnpackImageByTCompress(itemSerieImageRow.ImageBody);

                                    if (!itemSerieImageRow.IsImageBodyNull())
                                    {
                                        //    using (var ms = new MemoryStream(itemSerieImageRow.ImageBody))
                                        //        img = Image.FromStream(ms);

                                        //imgPages = this.GetImagesFromBytes(itemSerieImageRow.ImageBody, extension);
                                        imgPages = ImageUtils.ExtractImageLayersFromDataBufferEx(itemSerieImageRow.ImageBody, extension);
                                    }
                                }
                                catch (Exception)
                                {
                                    // UNDONE: записать в лог ошибку преобразования изображения
                                }

                                //if (img != null)
                                //{
                                //    img.Dispose();
                                //    img = ImageBodyReplacer; // для уменьшения объема требуемой памяти
                                //}

                                foreach (var imgPage in imgPages)
                                {
                                    try
                                    {
                                        img = Image.FromStream(new MemoryStream(imgPage));
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(string.Format("Ошибка при получении изображения:\nВозможно ипользуется недопустимый формат.\nItemName={0}; ItemCode={1}; VendorLot={2}; SerID={3}; extension={4};", taskDetailsRow.ItemName, (int)taskDetailsRow.ItemCode, taskDetailsRow.VendorLot, (int)rSerie.SerID, extension), ex);
                                    }

                                    //this.PrepareImage(ref img, extension);
                                    ImageUtils.PrepareLightweightImage(ref img, extension, ImageBodyReplacer);

                                    images.Add(
                                        new ImageContainer(
                                            Dialogs.Sert.SertPrintingThread.CertType.QualityCert,
                                            taskDetailsRow.ItemCode,
                                            taskDetailsRow.VendorLot,
                                            taskDetailsRow.ItemName,
                                            taskDetailsRow.ManufacturerName,
                                            itemSerieImageRow.ImageID,
                                            img
                                            ) { ImageBuffer = imgPage });
                                }


                                if (images.Count > 0 && images[images.Count - 1].Image == null)
                                    errors.Add(new Error(ErrorTypes.ImageIsEmpty, taskDetailsRow));
                            }
                        }
                        if (table.Rows.Count == 0)
                        {
                            errors.Add(new Error(ErrorTypes.VendorLotHasNoImages, taskDetailsRow));
                        }
                    }
                }
                //}
                //else
                //{
                //    adapter.SetConnectionString(Properties.Settings.Default.JDE_PROCConnectionString);
                //    errors.Add(new Error(ErrorTypes.VendorLotNotFound, taskDetailsRow));
                //}
            }
        }

        /// <summary>
        /// Печатает контрольный лист, содержащий информацию о сертификатах по текущему заказу (задаче).
        /// </summary>
        private void PrintControlList()
        {
            StringBuilder sb = new StringBuilder();

            #region МЕТАДАННЫЕ СЕКЦИИ ОТПРАВКИ

            bool deliveryMetadataSectionExists = false; // Признак существования метаданных секции отправки (МЛ/перрон)

            // вставка информации о номере МЛ
            if (!taskRow.IsRouteNumberNull())
            {
                sb.AppendLine(string.Format("Маршрутный лист № {0}", taskRow.RouteNumber));
                deliveryMetadataSectionExists = true;
            }

            // вставка информации о номере перрона
            if (!taskRow.IsPerronNumberNull())
            {
                sb.AppendLine(string.Format("Перрон № {0}", taskRow.PerronNumber));
                deliveryMetadataSectionExists = true;
            }

            if (deliveryMetadataSectionExists)
                sb.AppendLine("".PadRight(70, '-'));

            #endregion

            sb.AppendLine("Получатель: (" + taskRow.CustomerCode.ToString() + ") " + taskRow.CustomerName + " [" + taskRow.Rout + "]");

            var docKind = DocKind == DocKind.Order ? "Заказ" : DocKind == DocKind.Invoice ? "Накладная" : "Неизвестный документ";
            sb.AppendLine(docKind + " № " + DocNumber + " от " + taskRow.OrderDate.ToShortDateString() + " [" + taskRow.DeliveryInstructions + "]");
            //sb.AppendLine("Заказ № " + taskRow.DCTO + "-" + taskRow.DOCO + " от " + taskRow.OrderDate.ToShortDateString() + " [" + taskRow.DeliveryInstructions + "]");

            sb.AppendLine("Адрес: " + taskRow.CustomerAddress);
            sb.AppendLine("".PadRight(70, '-'));
            sb.AppendLine("Изображений к печати:".PadRight(50, '.') + images.Count);
            if (GetErrorsCount(ErrorTypes.ItemNotFound) > 0)
                sb.AppendLine("Необходима проверка товаров:".PadRight(50, '.') + GetErrorsCount(ErrorTypes.ItemNotFound).ToString());
            if (GetErrorsCount(ErrorTypes.VendorLotNotFound) > 0)
                sb.AppendLine("Необходима проверка серий:".PadRight(50, '.') + GetErrorsCount(ErrorTypes.VendorLotNotFound).ToString());
            if (GetErrorsCount(ErrorTypes.VendorLotHasNoImages) > 0)
                sb.AppendLine("Необходима проверка сертификатов по серии:".PadRight(50, '.') + GetErrorsCount(ErrorTypes.VendorLotHasNoImages).ToString());
            if (GetErrorsCount(ErrorTypes.ImageIsEmpty) > 0)
                sb.AppendLine("Необходима проверка пустых изображений:".PadRight(50, '.') + GetErrorsCount(ErrorTypes.ImageIsEmpty).ToString());

            sb.AppendLine();
            int notNullImagesCount = 0;
            foreach (ImageContainer ic in images)
                if (ic.Image != null)
                    ++notNullImagesCount;
            sb.AppendLine("Выдано на печать:".PadRight(50, '.') + notNullImagesCount.ToString());
            int maxVendorLotLen = GetMaxVendorLotLength() + 2;
            sb.AppendLine("".PadRight(70, '-'));
            sb.AppendLine("К-во".PadRight(5) + "Код".PadRight(7) + "Серия".PadRight(maxVendorLotLen) + "Название, производитель");
            sb.AppendLine("".PadRight(70, '-'));
            double previousItemCode = -1;
            string previousVendorLot = null;
            foreach (ImageContainer ic in images)
            {
                if (ic.Image != null && (ic.ItemCode != previousItemCode || ic.VendorLot != previousVendorLot))
                {
                    int imagesByCodeAndLotCount = 0;
                    foreach (ImageContainer ic2 in images)
                        if (ic2.ItemCode == ic.ItemCode && ic2.VendorLot == ic.VendorLot)
                            ++imagesByCodeAndLotCount;
                    sb.AppendLine(" " + imagesByCodeAndLotCount.ToString().PadRight(4) +
                        ic.ItemCode.ToString().PadRight(7) + ic.VendorLot.PadRight(maxVendorLotLen) + ic.ItemName + " [" + ic.ManufacturerName + "]");
                    previousItemCode = ic.ItemCode;
                    previousVendorLot = ic.VendorLot;
                }
            }

            if (alreadyPrintedRows.Keys.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine("В предыдущих заказах:".PadRight(50, '.') + alreadyPrintedRows.Count.ToString());
                sb.AppendLine("".PadRight(70, '-'));
                sb.AppendLine("№ заказа, дата".PadRight(24) + "Код".PadRight(7) + "Серия".PadRight(maxVendorLotLen) + "Название, производитель");
                sb.AppendLine("".PadRight(70, '-'));
                foreach (Data.Sert.TaskDetailsRow row in alreadyPrintedRows.Keys)
                {
                    sb.AppendLine(alreadyPrintedRows[row].PadRight(24) + row.ItemCode.ToString().PadRight(7) +
                        row.VendorLot.PadRight(maxVendorLotLen) + GetItemNameAndManufacturer(row));
                }
            }

            if (GetErrorsCount(ErrorTypes.ItemNotFound) > 0)
            {
                sb.AppendLine();
                sb.AppendLine("Проверьте наличие товаров в базе сертификатов:".PadRight(50, '.') + GetErrorsCount(ErrorTypes.ItemNotFound).ToString());
                sb.AppendLine("".PadRight(70, '-'));
                sb.AppendLine("Код".PadRight(7) + "Название, производитель");
                sb.AppendLine("".PadRight(70, '-'));
                foreach (Error e in errors)
                    if (e.ErrorType == ErrorTypes.ItemNotFound)
                        sb.AppendLine(e.DetailsRow.ItemCode.ToString().PadRight(7) + GetItemNameAndManufacturer(e.DetailsRow));
            }

            if (GetErrorsCount(ErrorTypes.VendorLotNotFound) > 0)
            {
                sb.AppendLine();
                sb.AppendLine("Проверьте наличие серий товара в базе сертификатов:".PadRight(50, '.') + GetErrorsCount(ErrorTypes.VendorLotNotFound).ToString());
                sb.AppendLine("".PadRight(70, '-'));
                sb.AppendLine("Код".PadRight(7) + "Серия".PadRight(maxVendorLotLen) + "Название, производитель");
                sb.AppendLine("".PadRight(70, '-'));
                foreach (Error e in errors)
                    if (e.ErrorType == ErrorTypes.VendorLotNotFound)
                        sb.AppendLine(e.DetailsRow.ItemCode.ToString().PadRight(7) + e.DetailsRow.VendorLot.PadRight(maxVendorLotLen) + GetItemNameAndManufacturer(e.DetailsRow));
            }

            if (GetErrorsCount(ErrorTypes.VendorLotHasNoImages) > 0)
            {
                sb.AppendLine();
                sb.AppendLine("Проверьте наличие сертификатов для серий в базе сертификатов:".PadRight(50, '.') + GetErrorsCount(ErrorTypes.VendorLotHasNoImages).ToString());
                sb.AppendLine("".PadRight(70, '-'));
                sb.AppendLine("Код".PadRight(7) + "Серия".PadRight(maxVendorLotLen) + "Название, производитель");
                sb.AppendLine("".PadRight(70, '-'));
                foreach (Error e in errors)
                    if (e.ErrorType == ErrorTypes.VendorLotHasNoImages)
                        sb.AppendLine(e.DetailsRow.ItemCode.ToString().PadRight(7) + e.DetailsRow.VendorLot.PadRight(maxVendorLotLen) + GetItemNameAndManufacturer(e.DetailsRow));
            }

            if (GetErrorsCount(ErrorTypes.ImageIsEmpty) > 0)
            {
                sb.AppendLine();
                sb.AppendLine("Проверьте пустые изображения в базе сертификатов:".PadRight(50, '.') + GetErrorsCount(ErrorTypes.ImageIsEmpty).ToString());
                sb.AppendLine("".PadRight(70, '-'));
                sb.AppendLine("Код".PadRight(7) + "Серия".PadRight(maxVendorLotLen) + "Название, производитель");
                sb.AppendLine("".PadRight(70, '-'));
                foreach (Error e in errors)
                    if (e.ErrorType == ErrorTypes.ImageIsEmpty)
                        sb.AppendLine(e.DetailsRow.ItemCode.ToString().PadRight(7) + e.DetailsRow.VendorLot.PadRight(maxVendorLotLen) + GetItemNameAndManufacturer(e.DetailsRow));
            }

            using (Reports.SertPrintControlList report = new WMSOffice.Reports.SertPrintControlList())
            {
                report.SetParameterValue("@text", sb.ToString());
                report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);
                if (!SertPrintSettings.UseDefaultPrinter)
                    report.PrintOptions.PrinterName = SertPrintSettings.CustomPrinterName;
                report.PrintToPrinter(1, false, 1, -1);
            }
        }

        /// <summary>
        /// Возвращает количество ошибок определенного типа.
        /// </summary>
        /// <param name="errorType">Тип ошибки.</param>
        /// <returns>Количество ошибок определенного типа.</returns>
        private int GetErrorsCount(ErrorTypes errorType)
        {
            int result = 0;
            foreach (Error e in errors)
                if (e.ErrorType == errorType)
                    ++result;
            return result;
        }

        /// <summary>
        /// Возвращает максимальную длину строки серии поставщика во всех списках текущего задания.
        /// </summary>
        /// <returns>Максимальная длина строки серии поставщика во всех списках текущего задания.</returns>
        private int GetMaxVendorLotLength()
        {
            int result = 5;
            foreach (Data.Sert.TaskDetailsRow r in taskDetails.Rows)
                if (r.VendorLot.Length > result)
                    result = r.VendorLot.Length;
            return result;
        }

        /// <summary>
        /// Возвращает наименование товара и наименование производителя одной строкой.
        /// </summary>
        /// <param name="row">Текущая строка задания.</param>
        /// <returns>Наименование товара плюс наименование производителя.</returns>
        private string GetItemNameAndManufacturer(Data.Sert.TaskDetailsRow row)
        {
            return row.ItemName + " [" + row.ManufacturerName + "]";
        }

        /// <summary>
        /// Печатает изображения сертификатов.
        /// </summary>
        private void PrintImages()
        {
            CurrentTotalPagesCount = GetTotalPagesCount();
            if (CurrentTotalPagesCount > 0)
            {
                PrintDocument pd = new PrintDocument();

                var docKind = DocKind == DocKind.Order ? "заказу" : DocKind == DocKind.Invoice ? "накладной" : "неизвестному документу";
                pd.DocumentName = "Сертификаты по " + docKind + " № " + DocNumber;
                //pd.DocumentName = "Сертификаты по заказу " + taskRow.DCTO + "-" + taskRow.DOCO.ToString();

                pd.PrintController = new StandardPrintController();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                if (!SertPrintSettings.UseDefaultPrinter)
                    pd.PrinterSettings.PrinterName = SertPrintSettings.CustomPrinterName;

                // двусторонняя печать
                if (pd.PrinterSettings.CanDuplex &&
                    (CurrentPrintMode == SertPrintSettings.PrintModes.DoubleSidedContinuous || CurrentPrintMode == SertPrintSettings.PrintModes.DoubleSidedNewPageItem || CurrentPrintMode == SertPrintSettings.PrintModes.DoubleSidedNewPageSerie))
                {
                    if (CurrentScale == SertPrintSettings.Scales.Scale1x2)
                        pd.PrinterSettings.Duplex = Duplex.Horizontal;
                    else
                        pd.PrinterSettings.Duplex = Duplex.Vertical;
                }
                // если масштаб - 2 изображения на странице, страницу нужно повернуть
                if (CurrentScale == SertPrintSettings.Scales.Scale1x2)
                {
                    pd.DefaultPageSettings.Landscape = true;
                }

                // шрифты
                if (CurrentHeaderFont != null)
                    CurrentHeaderFont.Dispose();
                if (CurrentFooterFont != null)
                    CurrentFooterFont.Dispose();
                if (CurrentScale == SertPrintSettings.Scales.Scale1x1)
                {
                    CurrentHeaderFont = new Font("Courier New", 9);
                    CurrentFooterFont = new Font("Courier New", 12);
                }
                else if (CurrentScale == SertPrintSettings.Scales.Scale1x2)
                {
                    CurrentHeaderFont = new Font("Courier New", 7);
                    CurrentFooterFont = new Font("Courier New", 14);
                }
                else if (CurrentScale == SertPrintSettings.Scales.Scale1x4)
                {
                    CurrentHeaderFont = new Font("Courier New", 6);
                    CurrentFooterFont = new Font("Courier New", 12);
                }

                // страницы
                CurrentPageNumber = 0;
                CurrentImageIndex = -1;
                if (MoveToNextImage())
                {
                    CurrentItemCode = images[CurrentImageIndex].ItemCode;
                    CurrentVendorLot = images[CurrentImageIndex].VendorLot;

                    while (CurrentPageNumber < CurrentTotalPagesCount)
                        pd.Print();
                }
            }
        }

        /// <summary>
        /// Возвращает общее количество печатаемых страниц для текущего задания.
        /// </summary>
        /// <returns>Общее количество печатаемых страниц для текущего задания</returns>
        private int GetTotalPagesCount()
        {
            int result = 0;
            CurrentImageIndex = -1;
            CurrentImageOnPageIndex = -1;
            if (MoveToNextImage())
            {
                CurrentItemCode = images[CurrentImageIndex].ItemCode;
                CurrentVendorLot = images[CurrentImageIndex].VendorLot;
            }
            CurrentImageIndex = -1;
            while (MoveToNextImage())
            {
                if (NeedNextPage())
                {
                    ++result;
                    CurrentImageOnPageIndex = 0;
                }
                else
                {
                    ++CurrentImageOnPageIndex;
                }
                CurrentItemCode = images[CurrentImageIndex].ItemCode;
                CurrentVendorLot = images[CurrentImageIndex].VendorLot;
            }
            if (CurrentImageIndex >= 0)
            {
                ++result;
            }

            return result;
        }

        /// <summary>
        /// Обрабатывает печать очередной страницы с изображениями сертификатов.
        /// </summary>
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.PageBounds);
            ++CurrentPageNumber;

            if (CurrentScale == SertPrintSettings.Scales.Scale1x1)
            {
                DrawImageX1(e.Graphics, e.PageBounds, images[CurrentImageIndex]);
                CurrentItemCode = images[CurrentImageIndex].ItemCode;
                CurrentVendorLot = images[CurrentImageIndex].VendorLot;
                if (MoveToNextImage())
                {
                    if (!SertPrintSettings.UseLimitOfPages || (SertPrintSettings.UseLimitOfPages && CurrentPageNumber % SertPrintSettings.CustomPagesInBatchCount != 0))
                        e.HasMorePages = true;
                }
            }
            else if (CurrentScale == SertPrintSettings.Scales.Scale1x2)
            {
                for (CurrentImageOnPageIndex = 0; ; ++CurrentImageOnPageIndex)
                {
                    DrawImageX2(e.Graphics, e.PageBounds, images[CurrentImageIndex], CurrentImageOnPageIndex);
                    CurrentItemCode = images[CurrentImageIndex].ItemCode;
                    CurrentVendorLot = images[CurrentImageIndex].VendorLot;
                    if (MoveToNextImage())
                    {
                        if (NeedNextPage())
                        {
                            if (!SertPrintSettings.UseLimitOfPages || (SertPrintSettings.UseLimitOfPages && CurrentPageNumber % SertPrintSettings.CustomPagesInBatchCount != 0))
                                e.HasMorePages = true;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (CurrentScale == SertPrintSettings.Scales.Scale1x4)
            {
                for (CurrentImageOnPageIndex = 0; ; ++CurrentImageOnPageIndex)
                {
                    DrawImageX4(e.Graphics, e.PageBounds, images[CurrentImageIndex], CurrentImageOnPageIndex);
                    CurrentItemCode = images[CurrentImageIndex].ItemCode;
                    CurrentVendorLot = images[CurrentImageIndex].VendorLot;
                    if (MoveToNextImage())
                    {
                        if (NeedNextPage())
                        {
                            if (!SertPrintSettings.UseLimitOfPages || (SertPrintSettings.UseLimitOfPages && CurrentPageNumber % SertPrintSettings.CustomPagesInBatchCount != 0))
                                e.HasMorePages = true;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Переходит к следующему изображению и возвращает результат перехода.
        /// </summary>
        /// <returns>Результат перехода: если переход выполнен успешно (еще есть изображения) - true, иначе - false.</returns>
        private bool MoveToNextImage()
        {
            ++CurrentImageIndex;
            while (CurrentImageIndex < images.Count && images[CurrentImageIndex].Image == null)
                ++CurrentImageIndex;
            return CurrentImageIndex < images.Count;
        }

        /// <summary>
        /// Проверяет, нужен ли переход к следующей странице, учитывая текущие настройки печати.
        /// </summary>
        /// <returns>Если необходим переход на следующую страницу - true, иначе - false.</returns>
        private bool NeedNextPage()
        {
            bool result = false;

            if ((CurrentScale == SertPrintSettings.Scales.Scale1x1 && CurrentImageOnPageIndex >= 0) ||
                (CurrentScale == SertPrintSettings.Scales.Scale1x2 && CurrentImageOnPageIndex >= 1) ||
                (CurrentScale == SertPrintSettings.Scales.Scale1x4 && CurrentImageOnPageIndex >= 3))
                result = true;

            if (CurrentImageIndex < images.Count)
            {
                if (CurrentPrintMode == SertPrintSettings.PrintModes.DoubleSidedNewPageItem && images[CurrentImageIndex].ItemCode != CurrentItemCode)
                    result = true;

                if (CurrentPrintMode == SertPrintSettings.PrintModes.DoubleSidedNewPageSerie &&
                    (images[CurrentImageIndex].ItemCode != CurrentItemCode || images[CurrentImageIndex].VendorLot != CurrentVendorLot))
                    result = true;
            }

            return result;
        }

        /// <summary>
        /// Загружает изображение серитификата из базы данных для контейнера с подмененным изображением (в целях экономии объема выделяемой памяти).
        /// </summary>
        /// <param name="ic">Ссылка на контейнер с изображением.</param>
        /// <returns>Изображение сертификата в формате BMP.</returns>
        private Bitmap LoadReplacedImage(ImageContainer ic)
        {
            Bitmap result = null;
            if (ic.Image == ImageBodyReplacer)
            {
                using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
                {
                    var imageBytes = adapter.GetImageByID(ic.ImageID);
                    if (imageBytes != null)
                    {
                        using (var ms = new MemoryStream(imageBytes))
                            result = new Bitmap(Image.FromStream(ms));
                    }
                }
                //result = SertImageUtils.UnpackImageByTCompress(adapter.GetImageByID(ic.ImageID));
            }
            return result;
        }

        /// <summary>
        /// Загружает и отрисовывает изображение сертификата в масштабе 1 картинка на странице.
        /// </summary>
        /// <param name="g">Ссылка на экземпляр класса Graphics.</param>
        /// <param name="bounds">Границы области печати.</param>
        /// <param name="ic">Ссылка на печатаемое изображение.</param>
        private void DrawImageX1(Graphics g, Rectangle bounds, ImageContainer ic)
        {
            g.DrawString(
                string.Format(
                    "ImageID: {0}, Код товара: {1}, Серия: {2}\r\nНаим.: {3}, произв.: {4}",
                    ic.ImageID,
                    ic.ItemCode,
                    string.IsNullOrEmpty(ic.VendorLot) ? "-" : ic.VendorLot,
                    ic.ItemName,
                    ic.ManufacturerName),
                CurrentHeaderFont,
                Brushes.Black,
                20,
                15);

            Bitmap sertImage = ic.ImageBuffer == null ? LoadReplacedImage(ic) : new Bitmap(new MemoryStream(ic.ImageBuffer));
            if (sertImage != null)
            {
                g.DrawImage(sertImage, new Rectangle(bounds.X + 20, bounds.Y + 60, bounds.Width - 40, bounds.Height - 130));
                sertImage.Dispose();
            }

            var docKind = DocKind == DocKind.Order ? "заказ" : DocKind == DocKind.Invoice ? "накладная" : "неизвестный документ";
            string footer = string.Format(
                "Стр. {0} из {1} ({2} № {3}, {4})",
                CurrentPageNumber,
                CurrentTotalPagesCount,
                docKind,
                DocNumber,
                taskRow.CustomerName);

            g.DrawString(
                footer,
                CurrentFooterFont,
                Brushes.Black,
                (bounds.Width - Convert.ToInt32(g.MeasureString(footer, CurrentFooterFont).Width)) / 2,
                bounds.Height - 70
                );

            // наложение печати Оптимы
            if (needPrintWatermark)
                g.DrawImage(Properties.Resources.watermark_optima, new Rectangle(bounds.X + 20 + bounds.Width - 100 - 150, bounds.Y + 20 + bounds.Height - 100 - 150, 150, 150));
        }

        /// <summary>
        /// Отрисовывает изображение сертификата в масштабе 2 картинки на странице.
        /// </summary>
        /// <param name="g">Ссылка на экземпляр класса Graphics.</param>
        /// <param name="bounds">Границы области печати.</param>
        /// <param name="ic">Ссылка на печатаемое изображение.</param>
        /// <param name="placeIndex">Индекс расположения картинки: 0 - первая (слева), 1 - вторая (справа), причем, нижняя подпись (footer) выводится только для первой.</param>
        private void DrawImageX2(Graphics g, Rectangle bounds, ImageContainer ic, int placeIndex)
        {
            if (placeIndex < 0 || placeIndex > 1)
                throw new ArgumentException("Некорректный индекс расположения картинки для масштаба 1х2.", "placeIndex");

            int xOffset = 60;
            var width = (bounds.Width - xOffset - 120) / 2;
            if (placeIndex == 1)
            {
                //xOffset = (bounds.Width - 120) / 2;
                xOffset += (width);
            }

            Bitmap sertImage = ic.ImageBuffer == null ? LoadReplacedImage(ic) : new Bitmap(new MemoryStream(ic.ImageBuffer));
            if (sertImage != null)
            {
                //g.DrawImage(sertImage, new Rectangle(xOffset, bounds.Y + 60, (bounds.Width - 120) / 2, bounds.Height - 140));
                g.DrawImage(sertImage, new Rectangle(xOffset, bounds.Y + 60, width, bounds.Height - 140));
                sertImage.Dispose();
            }

            g.DrawString(
                string.Format(
                    "ImageID: {0}, Код товара: {1}, Серия: {2}\r\nНаименование: {3}\r\nПроизводитель: {4}",
                    ic.ImageID,
                    ic.ItemCode,
                    string.IsNullOrEmpty(ic.VendorLot) ? "-" : ic.VendorLot,
                    ic.ItemName,
                    ic.ManufacturerName),
                CurrentHeaderFont,
                Brushes.Black,
                xOffset,
                15);

            var docKind = DocKind == DocKind.Order ? "заказ" : DocKind == DocKind.Invoice ? "накладная" : "неизвестный документ";
            string footer = string.Format(
                "Стр. {0} из {1} ({2} № {3}, {4})",
                CurrentPageNumber,
                CurrentTotalPagesCount,
                docKind,
                DocNumber,
                taskRow.CustomerName);

            if (placeIndex == 0)
                g.DrawString(
                    footer,
                    CurrentFooterFont,
                    Brushes.Black,
                    (bounds.Width - Convert.ToInt32(g.MeasureString(footer, CurrentFooterFont).Width)) / 2,
                    bounds.Height - 70
                    );

            // наложение печати Оптимы
            if (needPrintWatermark)
                g.DrawImage(Properties.Resources.watermark_optima, new Rectangle(xOffset + width * (2 - placeIndex) - 150 + 50, bounds.Height - 150 - 100, 150, 150));
        }

        /// <summary>
        /// Отрисовывает изображение сертификата в масштабе 4 картинки на странице.
        /// </summary>
        /// <param name="g">Ссылка на экземпляр класса Graphics.</param>
        /// <param name="bounds">Границы области печати.</param>
        /// <param name="ic">Ссылка на печатаемое изображение.</param>
        /// <param name="placeIndex">Индекс расположения картинки: 0 - первая (вверху слева), 1 - вторая (вверху справа), 2 - третья (внизу слева), 3 - четвертая (внизу справа), причем, нижняя подпись (footer) выводится только для первой.</param>
        private void DrawImageX4(Graphics g, Rectangle bounds, ImageContainer ic, int placeIndex)
        {
            if (placeIndex < 0 || placeIndex > 3)
                throw new ArgumentException("Некорректный индекс расположения картинки для масштаба 1х4.", "placeIndex");

            int xOffset = 20;
            if (placeIndex == 1 || placeIndex == 3)
                xOffset = (bounds.Width - 40) / 2;
            int yOffset = 60;
            if (placeIndex == 2 || placeIndex == 3)
                yOffset = (bounds.Height - 160) / 2 + 100;

            Bitmap sertImage = ic.ImageBuffer == null ? LoadReplacedImage(ic) : new Bitmap(new MemoryStream(ic.ImageBuffer));
            if (sertImage != null)
            {
                g.DrawImage(sertImage, new Rectangle(xOffset, yOffset, (bounds.Width - 120) / 2, (bounds.Height - 160) / 2));
                sertImage.Dispose();
            }

            g.DrawString(
                string.Format(
                    "ImageID: {0}, Код товара: {1}, Серия: {2}\r\nНаименование: {3}\r\nПроизводитель: {4}",
                    ic.ImageID,
                    ic.ItemCode,
                    string.IsNullOrEmpty(ic.VendorLot) ? "-" : ic.VendorLot,
                    ic.ItemName,
                    ic.ManufacturerName),
                CurrentHeaderFont,
                Brushes.Black,
                xOffset,
                yOffset - 40);

            var docKind = DocKind == DocKind.Order ? "заказ" : DocKind == DocKind.Invoice ? "накладная" : "неизвестный документ";
            string footer = string.Format(
                "Стр. {0} из {1} ({2} № {3}, {4})",
                CurrentPageNumber,
                CurrentTotalPagesCount,
                docKind,
                DocNumber,
                taskRow.CustomerName);

            if (placeIndex == 0)
                g.DrawString(
                    footer,
                    CurrentFooterFont,
                    Brushes.Black,
                    (bounds.Width - Convert.ToInt32(g.MeasureString(footer, CurrentFooterFont).Width)) / 2,
                    bounds.Height - 60
                    );

            // наложение печати Оптимы
            if (needPrintWatermark)
                g.DrawImage(Properties.Resources.watermark_optima, new Rectangle(20 + bounds.Width - 60 - 150, 60 + bounds.Height - 160 - 150, 150, 150));
        }

        /// <summary>
        /// Добавляет или обновляет данные о напечатанных сертификатах для клиента. Исключения при выполнении метода игнорируются.
        /// </summary>
        private void UpdateAlreadyPrintHistory()
        {
            try
            {
                using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
                {
                    //adapter.SetConnectionString(SertPrintSettings.GetSertDBConnectionString());
                    foreach (ImageContainer ic in images)
                    {
                        if (ic.Image != null && !string.IsNullOrEmpty(ic.VendorLot))
                        {
                            adapter.UpdateAlreadyPrinted((int)ic.ItemCode, ic.VendorLot, (int)taskRow.CustomerCode, DocNumber, taskRow.OrderDate.ToShortDateString());
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Сохраняет в базе данных ошибки, связанные с наличием изображений сертификатов. Исключения при выполнении метода игнорируются.
        /// </summary>
        private void SaveErrors()
        {
            try
            {
                using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
                {
                    foreach (Error e in errors)
                    {
                        adapter.AddError((int)e.ErrorType, e.DetailsRow.ItemCode, e.DetailsRow.VendorLot, e.DetailsRow.TaskID, e.DetailsRow.TaskDetailID);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Очищает данные последнего распечатанного заказа (выполненной задачи).
        /// </summary>
        private void ClearAll()
        {
            alreadyPrintedRows.Clear();
            errors.Clear();
            images.Clear();
            if (taskRow != null)
            {
                System.Data.DataTable dt = taskRow.Table;
                taskRow = null;
                dt.Dispose();
            }
            if (taskDetails != null)
            {
                taskDetails.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// Типы сертификата
        /// </summary>
        public enum CertType
        {
            /// <summary>
            /// Ргистрационное свидетельство
            /// </summary>
            RegCert = 0,

            /// <summary>
            /// Сертификат качества
            /// </summary>
            QualityCert = 1,

            /// <summary>
            /// Таможенная декларация
            /// </summary>
            BillOfExchange = 2
        }


        #region Class ImageContainer

        /// <summary>
        /// Содержит свойства одного изображения для печати.
        /// </summary>
        public class ImageContainer
        {
            /// <summary>
            /// Тип сертификата
            /// </summary>
            public CertType CertType { get; private set; }

            /// <summary>
            /// Код товара.
            /// </summary>
            public double ItemCode { get; private set; }
            /// <summary>
            /// Серия товара.
            /// </summary>
            public string VendorLot { get; private set; }
            /// <summary>
            /// Наименование товара.
            /// </summary>
            public string ItemName { get; private set; }
            /// <summary>
            /// Наименование производителя товара.
            /// </summary>
            public string ManufacturerName { get; private set; }
            /// <summary>
            /// Идентификатор изображения.
            /// </summary>
            public int ImageID { get; private set; }

            private Image _image;
            /// <summary>
            /// Изображение сертификата.
            /// </summary>
            public Image Image
            {
                get { return _image; }
                private set 
                { 
                    _image = value;

                    //_image.Save(String.Format(@"d:\{0}.tiff", Guid.NewGuid()));

                    //ImageConverter imgCon = new ImageConverter();
                    //ImageBuffer = (byte[])imgCon.ConvertTo(_image, typeof(byte[]));
                }
            }

            public byte[] ImageBuffer { get; set; }

            public string Header { get; set; }

            public int PageIndex { get; set; }

            public int ImageDataID { get; set; }

            /// <summary>
            /// Инициализирует новый экземпляр класса ImageContainer.
            /// </summary>
            /// <param name="itemCode">Код товара.</param>
            /// <param name="vendorLot">Серия товара.</param>
            /// <param name="itemName">Наименование товара.</param>
            /// <param name="manufactuterName">Наименование производителя товара.</param>
            /// <param name="imageID">Идентификатор изображения.</param>
            /// <param name="image">Изображение сертификата.</param>
            public ImageContainer(CertType certType, double itemCode, string vendorLot, string itemName, string manufactuterName, int imageID, Image image)
            {
                this.CertType = certType;
                this.ItemCode = itemCode;
                this.VendorLot = vendorLot;
                this.ItemName = itemName;
                this.ManufacturerName = manufactuterName;
                this.ImageID = imageID;
                this.Image = image;
            }
        }

        #endregion


        #region Enum ErrorTypes

        /// <summary>
        /// Содержит варианты типов ошибок.
        /// </summary>
        public enum ErrorTypes
        {
            /// <summary>
            /// Товар не найден.
            /// </summary>
            ItemNotFound = 1,
            /// <summary>
            /// Серия не найдена.
            /// </summary>
            VendorLotNotFound = 2,
            /// <summary>
            /// Серия не имеет сертификатов.
            /// </summary>
            VendorLotHasNoImages = 3,
            /// <summary>
            /// Пустое изображение.
            /// </summary>
            ImageIsEmpty = 4,
        }

        #endregion


        #region Class Error

        /// <summary>
        /// Содержит информацию об ошибке.
        /// </summary>
        public class Error
        {
            /// <summary>
            /// Тип ошибки.
            /// </summary>
            public ErrorTypes ErrorType { get; private set; }
            /// <summary>
            /// Строка заказа (задачи).
            /// </summary>
            public Data.Sert.TaskDetailsRow DetailsRow { get; private set; }

            /// <summary>
            /// Инициализирует новый экземпляр класса Error.
            /// </summary>
            /// <param name="errorType">Тип ошибки.</param>
            /// <param name="detailsRow">Строка заказа (задачи).</param>
            public Error(ErrorTypes errorType, Data.Sert.TaskDetailsRow detailsRow)
            {
                this.ErrorType = errorType;
                this.DetailsRow = detailsRow;
            }
        }

        #endregion
    }

    #region Enum SertPrintTaskStates

    /// <summary>
    /// Содержит варианты результатов выполнения задачи по печати сертификатов.
    /// </summary>
    public enum SertPrintTaskStates
    {
        /// <summary>
        /// Обработка задачи не была запущена.
        /// </summary>
        None = 0,
        /// <summary>
        /// Новые (не обработанные) задачи не найдены.
        /// </summary>
        TasksNotFound = 1,
        /// <summary>
        /// Задача выполняется.
        /// </summary>
        Processing = 2,
        /// <summary>
        /// Задача успешно обработана.
        /// </summary>
        Successful = 3,
        /// <summary>
        /// Обработка задачи была прервана в связи с критической ошибкой.
        /// </summary>
        Error = 4,
    }

    #endregion

    #region ТИП ДОКУМЕНТА

    public enum DocKind
    {
        /// <summary>
        /// Неизвестный
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Заказ
        /// </summary>
        Order = 0,

        /// <summary>
        /// Накладная
        /// </summary>
        Invoice = 1
    }

    #endregion
}
