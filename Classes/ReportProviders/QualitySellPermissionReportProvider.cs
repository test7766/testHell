using System;
using CrystalDecisions.CrystalReports.Engine;

using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Classes.ReportProviders
{
    /// <summary>
    /// Класс для построения отчета - разрешения на реализацию ЛС
    /// </summary>
    public class QualitySellPermissionReportProvider : IReportProvider
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        public QualitySellPermissionReportProvider(long pSessionID)
        {
            sessionID = pSessionID;
        }

        /// <summary>
        /// Формирование отчета разрешения на реализацию ЛС по строке заявки ОК
        /// </summary>
        /// <param name="pParam">Строка заявки ОК</param>
        /// <returns>Отчет - разрешение на реализацию ЛС для заданной строки заявки</returns>
        public ReportClass GetReport(object pParam)
        {
            var report = new QualitySellPermissionReport();
            var data = GetDataForReport(pParam as Quality.DocDetailsRow);
            report.SetDataSource(data);
            return report;
        }

        /// <summary>
        /// Получение данных для разрешения на реализацию
        /// </summary>
        /// <param name="pDetail">Строка заявки ОК</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Quality GetDataForReport(Quality.DocDetailsRow pDetail)
        {
            var ds = new Quality();
            using (var adapter = new QK_Get_Sell_Permission_ReportTableAdapter())
                adapter.Fill(ds.QK_Get_Sell_Permission_Report, sessionID, pDetail.Doc_ID, pDetail.Line_ID);

            if (ds.QK_Get_Sell_Permission_Report.Count == 0)
                throw new InvalidOperationException("Процедура получения данных для формы разрешения на реализацию не вернула данные!");
            
            return ds;
        }
    }
}
