using System.Data;

namespace WMSOffice.Classes
{
    /// <summary>
    /// Параметры печати для передачи фоновому потоку печати документов
    /// </summary>
    public class PrintDocsParameters
    {
        /// <summary>
        /// Название принтера, на котором нужно произвести печать
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// Список документов, которые нужно напечатать
        /// </summary>
        public DataRow[] Docs { get; set; }
    }
}
