using System;

using CrystalDecisions.CrystalReports.Engine;

using WMSOffice.Data;
using WMSOffice.Data.ComplaintsTableAdapters;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Reports;

namespace WMSOffice.Classes.ReportProviders
{
    /// <summary>
    /// Поставщик отчета актов по претензиям
    /// </summary>
    public class ComplaintsActReportProvider : IReportProvider
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Режим работы поставщика отчетов
        /// </summary>
        private readonly ComplaintActsReportProviderMode mode;

        #endregion

        #region МЕТОДЫ, ОБЩИЕ ДЛЯ ВСЕХ РЕЖИМОВ РАБОТЫ

        public ComplaintsActReportProvider(long pSessionID, ComplaintActsReportProviderMode pMode)
        {
            sessionID = pSessionID;
            mode = pMode;
        }

        /// <summary>
        /// Формирование печатной формы акта по претензии
        /// </summary>
        /// <param name="pParam">Претензия, для которой нужно достать акт</param>
        /// <returns>Сформированный акт по претензии</returns>
        public ReportClass GetReport(object pParam)
        {
            var report = mode == ComplaintActsReportProviderMode.ByComplaint 
                            ? GetReportByComplaint(pParam) 
                            : mode == ComplaintActsReportProviderMode.ByAct
                                ? GetReportByAct(pParam)
                                : GetReportByDocument(pParam);

            var ds = mode == ComplaintActsReportProviderMode.ByComplaint 
                        ? GetDataForReportByComplaint(pParam)
                        : mode == ComplaintActsReportProviderMode.ByAct
                            ? GetDataForReportByAct(pParam)
                            : GetDataForReportByDocument(pParam);

            report.SetDataSource(ds);
            return report;
        }

        #endregion

        #region МЕТОДЫ ДЛЯ РЕЖИМА ПРЕТЕНЗИЙ

        /// <summary>
        /// Определение типа акта по типу документа-претензии
        /// </summary>
        /// <param name="pComplaint">Документ-претензия, по которому нужно напечатать акт</param>
        /// <returns>Пустой отчет определенного типа (какого именно - зависит от претензии). 
        /// В дальнейшем этот отчет будет наполняться данными</returns>
        private static ReportClass GetReportByComplaint(object pComplaint)
        {
            var complaint = pComplaint as Complaints.CurrentDocsRow;
            switch (complaint.Doc_Type)
            {
                case Constants.CO_DTFL_NTV:
                case Constants.CO_DTFL_BOY:
                    return new ComplaintSingleAmountActReport();
                case Constants.CO_DTFL_PERESORT:
                    return new ComplaintPeresortActReport();
                case Constants.CO_DTFL_ITND:
                case Constants.CO_DTFL_OVERAGE:
                case Constants.CO_DTFL_BOXND:
                case Constants.CO_DTFL_MANUFACTURERND:
                case Constants.CO_DTFL_DEFECT:
                    return new ComplaintFewAmountsActReport();
                case Constants.CO_DTFL_REG:
                case Constants.CO_DFTL_DEMAND:
                case Constants.CO_DTFL_EXPIRATION:
                case Constants.CO_DTFL_VIRTUAL_REFUSE:
                    return new ComplaintTransmitReceiveActReport();
                default:    // В принципе, такого быть не должно
                    return null;
            }
        }

        /// <summary>
        /// Получение данных для акта претензии
        /// </summary>
        /// <param name="pEntity">Претензия, по которой нужно получить данные</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Complaints GetDataForReportByComplaint(object pEntity)
        {
            var complaint = pEntity as Complaints.CurrentDocsRow;
            var ds = new Complaints();
            using (var adapter = new CO_Report_ComplaintIB_Act_HeaderTableAdapter())
                adapter.Fill(ds.CO_Report_ComplaintIB_Act_Header, sessionID, complaint.Doc_ID, null);

            if (ds.CO_Report_ComplaintIB_Act_Header.Count == 0)
                throw new InvalidOperationException("Процедура получения заголовка" +
                    " [dbo].[pr_CO_Report_ComplaintIB_Act_Header] не вернула данные!");
            ds.CO_Report_ComplaintIB_Act_Header[0].Bar_Code_IMG = BarcodeGenerator.GetBarcodeCODE39(
                ds.CO_Report_ComplaintIB_Act_Header[0].Bar_Code);
            ds.CO_Report_ComplaintIB_Act_Header[0].DiffAmountColumnHeader = GetDiffAmountColumnNameByComplaintType(complaint.Doc_Type);

            using (var adapter = new CO_Report_ComplaintIB_Act_DetailTableAdapter())
                adapter.Fill(ds.CO_Report_ComplaintIB_Act_Detail, sessionID, complaint.Doc_ID);
            return ds;
        }

        /// <summary>
        /// Формирование заголовка колонки с количеством проблемного товара (излишки, недостача и т.д.) 
        /// в зависимости от типа претензии
        /// </summary>
        /// <param name="pComplaintType">Тип претензии</param>
        /// <returns>Заголовок колонки с количеством проблемного товара</returns>
        private string GetDiffAmountColumnNameByComplaintType(string pComplaintType)
        {
            switch (pComplaintType)
            {
                case Constants.CO_DTFL_BOY:
                    return "Кол-во боя";
                case Constants.CO_DTFL_NTV:
                    return "Кол-во НТВ";
                case Constants.CO_DTFL_REG:
                case Constants.CO_DFTL_DEMAND:
                case Constants.CO_DTFL_EXPIRATION:
                case Constants.CO_DTFL_VIRTUAL_REFUSE:
                    return "Кол-во товара";
                case Constants.CO_DTFL_ITND:
                case Constants.CO_DTFL_MANUFACTURERND:
                case Constants.CO_DTFL_BOXND:
                    return "Кол-во недост.";
                case Constants.CO_DTFL_OVERAGE:
                    return "Кол-во изл.";
                case Constants.CO_DTFL_DEFECT:
                    return "Кол-во брака";
                default:    // В принципе, такого быть не должно
                    return String.Empty;
            }
        }

        #endregion

        #region МЕТОДЫ ДЛЯ РЕЖИМА АКТОВ

        /// <summary>
        /// Определение типа отчета по межскладскому акту
        /// </summary>
        /// <param name="pAct">Межскладской акт</param>
        /// <returns>Пустой отчет определенного типа (какого именно - зависит от акта). 
        /// В дальнейшем этот отчет будет наполняться данными</returns>
        private static ReportClass GetReportByAct(object pAct)
        {
            var act = pAct as Interbranch.IB_IB_ActsRow;
            switch (act.Act_Type)
            {
                case Constants.IB_ACT_NTV:
                case Constants.IB_ACT_BOY:
                    return new ComplaintSingleAmountActReport();
                case Constants.IB_ACT_PERESORT:
                    return new ComplaintPeresortActReport();
                case Constants.IB_ACT_ITND:
                case Constants.IB_ACT_OVERAGE:
                case Constants.IB_ACT_BOXND:
                case Constants.IB_ACT_MANUFACTURERND:
                case Constants.IB_ACT_DEFECT:
                    return new ComplaintFewAmountsActReport();
                case Constants.IB_ACT_REG:
                    return new ComplaintTransmitReceiveActReport();
                default:    // В принципе, такого быть не должно
                    return null;
            }
        }

        /// <summary>
        /// Получение данных для акта
        /// </summary>
        /// <param name="pEntity">Акт, по которому нужно получить данные</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Complaints GetDataForReportByAct(object pEntity)
        {
            var act = pEntity as Interbranch.IB_IB_ActsRow;
            var ds = new Complaints();
            using (var adapter = new CO_Report_ComplaintIB_Act_HeaderTableAdapter())
                adapter.FillByAct(ds.CO_Report_ComplaintIB_Act_Header, act.Act_ID);

            if (ds.CO_Report_ComplaintIB_Act_Header.Count == 0)
                throw new InvalidOperationException("Процедура получения заголовка" +
                    " [dbo].[pr_IB_IB_Get_Act_Header_v2] не вернула данные!");
            ds.CO_Report_ComplaintIB_Act_Header[0].Bar_Code_IMG = BarcodeGenerator.GetBarcodeCODE39(
                ds.CO_Report_ComplaintIB_Act_Header[0].Bar_Code);
            ds.CO_Report_ComplaintIB_Act_Header[0].DiffAmountColumnHeader = GetDiffAmountColumnNameByActType(act.Act_Type);

            using (var adapter = new CO_Report_ComplaintIB_Act_DetailTableAdapter())
                adapter.FillByAct(ds.CO_Report_ComplaintIB_Act_Detail, act.Act_ID);
            return ds;
        }

        /// <summary>
        /// Формирование заголовка колонки с количеством проблемного товара (излишки, недостача и т.д.) 
        /// в зависимости от типа акта
        /// </summary>
        /// <param name="pComplaintType">Тип межскладского акта</param>
        /// <returns>Заголовок колонки с количеством проблемного товара</returns>
        private string GetDiffAmountColumnNameByActType(string pActType)
        {
            switch (pActType)
            {
                case Constants.IB_ACT_BOY:
                    return "Кол-во боя";
                case Constants.IB_ACT_NTV:
                    return "Кол-во НТВ";
                case Constants.IB_ACT_REG:
                    return "Кол-во товара";
                case Constants.IB_ACT_ITND:
                case Constants.IB_ACT_MANUFACTURERND:
                case Constants.IB_ACT_BOXND:
                    return "Кол-во недост.";
                case Constants.IB_ACT_OVERAGE:
                    return "Кол-во изл.";
                case Constants.IB_ACT_DEFECT:
                    return "Кол-во брака";
                default:    // В принципе, такого быть не должно
                    return String.Empty;
            }
        }

        #endregion

        #region МЕТОДЫ ДЛЯ РЕЖИМА ДОКУМЕНТОВ

        /// <summary>
        /// Определение типа акта по типу документа
        /// </summary>
        /// <param name="pDocument">Документ, по которому нужно напечатать акт</param>
        /// <returns>Пустой отчет определенного типа (какого именно - зависит от документа). 
        /// В дальнейшем этот отчет будет наполняться данными</returns>
        private static ReportClass GetReportByDocument(object pDocument)
        {
            var document = pDocument as DocRequisites;

            // Возвращаем акт НТВ
            return new ComplaintSingleAmountActReport();

            #region ПОКА АНАЛИЗ НЕ ТРЕБУЕТСЯ (ЗАКОММЕНТИРОВАНО)

            //switch (document.DCTO)
            //{
            //    case "":
            //        return new ComplaintSingleAmountActReport();
            //    default:    // В принципе, такого быть не должно
            //        return null;
            //}

            #endregion
        }

        /// <summary>
        /// Получение данных для документа
        /// </summary>
        /// <param name="pEntity">Документ, по которому нужно получить данные</param>
        /// <returns>Датасет с данными для формирования документа</returns>
        private Complaints GetDataForReportByDocument(object pEntity)
        {
            var document = pEntity as DocRequisites;
            var ds = new Complaints();
            using (var adapter = new CO_Report_ComplaintIB_Act_HeaderTableAdapter())
                adapter.FillByDocument(ds.CO_Report_ComplaintIB_Act_Header, sessionID, document.KCOO, document.DCTO, (int)document.DOCO);

            if (ds.CO_Report_ComplaintIB_Act_Header.Count == 0)
                throw new InvalidOperationException("Процедура получения заголовка" +
                    " [dbo].[pr_IL_GetActMSOrder_header] не вернула данные!");
            ds.CO_Report_ComplaintIB_Act_Header[0].Bar_Code_IMG = BarcodeGenerator.GetBarcodeCODE39(
                ds.CO_Report_ComplaintIB_Act_Header[0].Bar_Code);
            ds.CO_Report_ComplaintIB_Act_Header[0].DiffAmountColumnHeader = GetDiffAmountColumnNameByDocumentType(document.DCTO);

            using (var adapter = new CO_Report_ComplaintIB_Act_DetailTableAdapter())
                adapter.FillByDocument(ds.CO_Report_ComplaintIB_Act_Detail, sessionID, document.KCOO, document.DCTO, (int)document.DOCO);
            return ds;
        }

        /// <summary>
        /// Формирование заголовка колонки с количеством проблемного товара (излишки, недостача и т.д.) 
        /// в зависимости от типа документа
        /// </summary>
        /// <param name="pDocumentType">Тип документа</param>
        /// <returns>Заголовок колонки с количеством проблемного товара</returns>
        private string GetDiffAmountColumnNameByDocumentType(string pDocumentType)
        {
            return "Кол-во НТВ";

            #region ПОКА АНАЛИЗ НЕ ТРЕБУЕТСЯ (ЗАКОММЕНТИРОВАНО)

            //switch (pDocumentType)
            //{
            //    case "":
            //        return "Кол-во НТВ";
            //    default:    // В принципе, такого быть не должно
            //        return String.Empty;
            //}

            #endregion
        }

        #endregion
    }

    #region ПЕРЕЧИСЛЕНИЕ ДЛЯ РЕЖИМОВ РАБОТЫ ПОСТАВЩИКА АКТОВ

    /// <summary>
    /// Режимы работы поставщика актов
    /// </summary>
    public enum ComplaintActsReportProviderMode
    {
        /// <summary>
        /// Режим, при котором метод GetReport интерпретирует полученный параметр как претензию
        /// </summary>
        ByComplaint,

        /// <summary>
        /// Режим, при котором метод GetReport интерпретирует полученный параметр как акт
        /// </summary>
        ByAct,

        /// <summary>
        /// Режим, при котором метод GetReport интерпретирует полученный параметр как документ
        /// </summary>
        ByDocument
    }

    /// <summary>
    /// Реквизиты документа
    /// </summary>
    public class DocRequisites
    {
        public string KCOO { get; set; }
        public string DCTO { get; set; }
        public long DOCO { get; set; }
    }

    #endregion
}
