using System;
using CrystalDecisions.CrystalReports.Engine;

using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Classes.ReportProviders
{
    /// <summary>
    /// Класс для построения отчета - акта приема-передачи образцов по заявке отдела качества
    /// </summary>
    public class QualityAcceptanceActReportProvider : IReportProvider
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// True если нужно печатать акты для Оптимы, False если для ГЛС
        /// </summary>
        private readonly bool forOptima;

        public QualityAcceptanceActReportProvider(long pSessionID, bool pForOptima)
        {
            sessionID = pSessionID;
            forOptima = pForOptima;
        }

        /// <summary>
        /// Формирование акта приема-передачи образцов по заявке ОК
        /// </summary>
        /// <param name="pParam">Заявка ОК</param>
        /// <returns>Отчет - акт приема-передачи образцов по заявке</returns>
        public ReportClass GetReport(object pParam)
        {
            var report = new QualityAcceptanceActReport();
            var data = GetDataForReport(pParam as Quality.DocsRow);
            report.SetDataSource(data);
            return report;
        }

        /// <summary>
        /// Получение данных для акта приема-передачи образцов
        /// </summary>
        /// <param name="pDetail">Заявка ОК</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Quality GetDataForReport(Quality.DocsRow pDoc)
        {
            var ds = new Quality();
            using (var adapter = new QK_Acceptance_Report_HeaderTableAdapter())
                adapter.Fill(ds.QK_Acceptance_Report_Header, sessionID, pDoc.Doc_ID, forOptima);

            if (ds.QK_Acceptance_Report_Header.Count == 0)
                throw new InvalidOperationException("Процедура получения данных для акта приема-передачи не вернула данные!");

            using (var adapter = new QK_Acceptance_Report_DetailsTableAdapter())
                adapter.Fill(ds.QK_Acceptance_Report_Details, sessionID, pDoc.Doc_ID);

            return ds;
        }
    }
}
