using System;

using CrystalDecisions.CrystalReports.Engine;

using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Classes.ReportProviders
{
    /// <summary>
    /// Класс для построения анкет входного контроля партии и поставки
    /// </summary>
    public class QualityInputControlReportProvider : IReportProvider
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Тип входного контроля (поставки или партии)
        /// </summary>
        public InputControlTypes ControlType { get; set; }

        public QualityInputControlReportProvider(long pSessionID)
        {
            sessionID = pSessionID;
            ControlType = InputControlTypes.DeliveryControl;
        }

        /// <summary>
        /// Формирование анкеты входного контроля
        /// </summary>
        /// <param name="pParam">Строка таблицы анкет входного контроля (AP_Doc)</param>
        /// <returns>Отчет - разрешение на реализацию ЛС для заданной строки заявки</returns>
        public ReportClass GetReport(object pParam)
        {
            var report = ControlType == InputControlTypes.ShippingAuthorizationControl 
                ? (ReportClass)(new QualityShippingAuthorizationWorksheetReport()) 
                : ControlType == InputControlTypes.BranchControl
                    ? (ReportClass)(new QualityInputControlBranchWorksheetReport()) 
                    : ControlType == InputControlTypes.DeliveryControl 
                        ? (ReportClass)(new QualityInputControlDeliveryWorksheetReportEx()) 
                        : (ReportClass)(new QualityInputControlLotnWorksheetReport());

            var data = ControlType == InputControlTypes.ShippingAuthorizationControl 
                ? GetDataForShippingAuthorizationControl(pParam as Quality.QK_SA_WorksheetsRow)
                : ControlType == InputControlTypes.BranchControl
                    ? GetDataForInputBranchControl(pParam as Quality.QK_CB_WorksheetsRow)
                    : ControlType == InputControlTypes.DeliveryControl
                        ? GetDataForDeliveryControl(pParam as Quality.AP_DocsRow)
                        : GetDataForLotnControl(pParam as Quality.AT_Doc_VersionsRow);

            report.SetDataSource(data);
            return report;
        }

        /// <summary>
        /// Получение данных для анкеты входного контроля поставки
        /// </summary>
        /// <param name="pRow">Строка таблицы анкет входного контроля (AP_Doc)</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Quality GetDataForDeliveryControl(Quality.AP_DocsRow pRow)
        {
            var ds = new Quality();

            using (var adapter = new AP_Get_Worksheet_Report_HeaderTableAdapter())
                adapter.Fill(ds.AP_Get_Worksheet_Report_Header, sessionID, pRow.doc_id, pRow.version_id);

            if (ds.AP_Get_Worksheet_Report_Header.Count == 0)
                throw new InvalidOperationException("Процедура получения данных для анкеты входного контроля поставки не вернула данные!");

#if not_grouped_questions
            using (var adapter = new AP_Get_Worksheet_Report_Details1TableAdapter())
                adapter.Fill(ds.AP_Get_Worksheet_Report_Details1, sessionID, pRow.doc_id, 
                    Constants.QK_IC_TYPEID_DELIVERY_STATE, pRow.version_id);

            using (var adapter = new AP_Get_Worksheet_Report_Details2TableAdapter())
                adapter.Fill(ds.AP_Get_Worksheet_Report_Details2, sessionID, pRow.doc_id,
                    Constants.QK_IC_TYPEID_DELIVERY_DOCS, pRow.version_id);
#else
            using (var adapter = new AP_Get_Worksheet_Report_DetailsTableAdapter())
                adapter.Fill(ds.AP_Get_Worksheet_Report_Details, sessionID, pRow.doc_id,
                    null, pRow.version_id);
#endif

            using (var adapter = new AP_Get_Worksheet_Report_Termo_DetailsTableAdapter())
                adapter.Fill(ds.AP_Get_Worksheet_Report_Termo_Details, sessionID, pRow.doc_id, pRow.version_id);

            return ds;
        }

        /// <summary>
        /// Получение данных для анкеты входного контроля партии
        /// </summary>
        /// <param name="pRow">Строка таблицы анкет входного контроля (AT_Doc)</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Quality GetDataForLotnControl(Quality.AT_Doc_VersionsRow pRow)
        {
            var ds = new Quality();
            using (var adapter = new AT_Get_Worksheet_Report_HeaderTableAdapter())
                adapter.Fill(ds.AT_Get_Worksheet_Report_Header, sessionID, pRow.doc_id);

            if (ds.AT_Get_Worksheet_Report_Header.Count == 0)
                throw new InvalidOperationException("Процедура получения данных для анкеты входного контроля партии не вернула данные!");

            using (var adapter = new AT_Get_Worksheet_Report_DetailsTableAdapter())
                adapter.Fill(ds.AT_Get_Worksheet_Report_Details, sessionID, pRow.doc_id);

            return ds;
        }

        /// <summary>
        /// Получение данных для анкеты разрешений на отгрузку
        /// </summary>
        /// <param name="pRow">Строка таблицы анкет разрешений на отгрузку (QK_SA_WorksheetsRow)</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Quality GetDataForShippingAuthorizationControl(Quality.QK_SA_WorksheetsRow pRow)
        {
            var ds = new Quality();
            using (var adapter = new QK_SA_Worksheet_Report_HeaderTableAdapter())
                adapter.Fill(ds.QK_SA_Worksheet_Report_Header, sessionID, pRow.worksheet_number, pRow.version_number);

            if (ds.QK_SA_Worksheet_Report_Header.Count == 0)
                throw new InvalidOperationException("Процедура получения данных для анкеты разрешений на отгрузку не вернула данные!");

            using (var adapter = new QK_SA_Worksheet_Report_DetailsTableAdapter())
                adapter.Fill(ds.QK_SA_Worksheet_Report_Details, sessionID, pRow.worksheet_number, pRow.version_number);

            return ds;
        }

        /// <summary>
        /// Получение данных для анкеты входного контроля Межсклад
        /// </summary>
        /// <param name="pRow">Строка таблицы анкет входного контроля Межсклад (QK_CB_WorksheetsRow)</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Quality GetDataForInputBranchControl(Quality.QK_CB_WorksheetsRow pRow)
        {
            var ds = new Quality();
            using (var adapter = new QK_CB_Worksheet_Report_HeaderTableAdapter())
                adapter.Fill(ds.QK_CB_Worksheet_Report_Header, sessionID, pRow.worksheet_number, pRow.version_number);

            if (ds.QK_CB_Worksheet_Report_Header.Count == 0)
                throw new InvalidOperationException("Процедура получения данных для анкеты входного контроля Межсклад не вернула данные!");

            using (var adapter = new QK_CB_Worksheet_Report_DetailsTableAdapter())
                adapter.Fill(ds.QK_CB_Worksheet_Report_Details, sessionID, pRow.worksheet_number, pRow.version_number);

            return ds;
        }
    }

    /// <summary>
    /// Типы анкет входного контроля
    /// </summary>
    public enum InputControlTypes
    {
        /// <summary>
        /// Входной контроль поставки
        /// </summary>
        DeliveryControl,

        /// <summary>
        /// Входной контроль партии
        /// </summary>
        LotnControl,

        /// <summary>
        /// Разрешение на отгрузку
        /// </summary>
        ShippingAuthorizationControl,

        /// <summary>
        /// Входной контроль Межсклад
        /// </summary>
        BranchControl
    }
}
