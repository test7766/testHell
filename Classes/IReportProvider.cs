using CrystalDecisions.CrystalReports.Engine;

namespace WMSOffice.Classes
{
    /// <summary>
    /// Интерфейс, который должны реализовывать классы-поставщики отчетов
    /// </summary>
    public interface IReportProvider
    {
        /// <summary>
        /// Получение отчета или документа по некоторому параметру
        /// </summary>
        /// <param name="pParam">Параметр, по которому будет получен отчет</param>
        /// <returns>Сформированный Crystal-отчет</returns>
        ReportClass GetReport(object pParam);
    }
}
