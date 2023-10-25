using System;

using CrystalDecisions.CrystalReports.Engine;

using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Classes.ReportProviders
{
    /// <summary>
    /// Класс для формирования отчета - расширенного реестра ЛС от поставщика
    /// </summary>
    public class QualityExtendedRegisterReportProvider :IReportProvider
    {
        /// <summary>
        /// Вид отчета, генерируемый методом GetReport
        /// </summary>
        public QualitySellPermissionRegistryMode Mode { get; set; }

        /// <summary>
        /// Получение печатной формы реестра ЛС от поставщика (для экспорта в Excel) по заголовку отчета
        /// </summary>
        /// <param name="pParam">Заголовок реестра</param>
        /// <returns>Печатная форма реестра</returns>
        public ReportClass GetReport(object pParam)
        {
            var report = Mode == QualitySellPermissionRegistryMode.QualityVendorExtendedRegister ?
                (ReportClass)(new QualityExtendedVendorRegisterReport()) : 
                (ReportClass)(new QualitySellPermissionVendorRegisterReport());
            var ds = GetDataForReport(pParam as Quality.MedicinesRegistryRow);
            report.SetDataSource(ds);
            return report;
        }

        /// <summary>
        /// Получение данных для печатной формы расширенного реестра ЛС от поставщика (с 16-ю колонками)
        /// </summary>
        /// <param name="pHeaderRow">Строка - заголовок отчета</param>
        /// <returns>Датасет с данными для формирования акта</returns>
        private Quality GetDataForReport(Quality.MedicinesRegistryRow pHeaderRow)
        {
            var ds = new Quality();
            ds.MedicinesRegistry.ImportRow(pHeaderRow);
            using (var adapter = new MedicinesRegistryDetailsTableAdapter())
                adapter.Fill(ds.MedicinesRegistryDetails, pHeaderRow.company_id, pHeaderRow.optima_order_id, 
                    pHeaderRow.optima_order_type, pHeaderRow.optima_invoice_id,
                    pHeaderRow.IsFilter_ItemIDNull() ? null : (int?)pHeaderRow.Filter_ItemID,
                    pHeaderRow.IsFilter_VendorLotNull() ? null : pHeaderRow.Filter_VendorLot,
                    Mode == QualitySellPermissionRegistryMode.SellPermissionRegister, null);

            if (Mode == QualitySellPermissionRegistryMode.QualityVendorExtendedRegister)
                RemoveEmptyStrings(ds);

            return ds;
        }

        /// <summary>
        /// Замена пустых строк на дефисы
        /// (чтобы Crystal не экспортировал пустые строки, которые в Excel будут "Пустыми ячейками")
        /// </summary>
        /// <param name="pDs">DataSet с таблицей строк реестра</param>
        private void RemoveEmptyStrings(Quality pDs)
        {
            string fillSign = "-";
            foreach (Quality.MedicinesRegistryDetailsRow row in pDs.MedicinesRegistryDetails)
            {
                if (row.Isvendor_control_rezultNull() || String.IsNullOrEmpty(row.vendor_control_rezult))
                    row.vendor_control_rezult = fillSign;
                if (row.IsOutConcl_Doc_NumberNull() || String.IsNullOrEmpty(row.OutConcl_Doc_Number))
                    row.OutConcl_Doc_Number = fillSign;
                if (row.IsOutConcl_Doc_DateNull() || String.IsNullOrEmpty(row.OutConcl_Doc_Date))
                    row.OutConcl_Doc_Date = fillSign;
                if (row.IsConcl_Type_NameNull() || String.IsNullOrEmpty(row.Concl_Type_Name))
                    row.Concl_Type_Name = fillSign;
                if (row.IsSign_DateNull() || String.IsNullOrEmpty(row.Sign_Date))
                    row.Sign_Date = fillSign;
                if (row.IsResponsible_SP_PersonNull() || String.IsNullOrEmpty(row.Responsible_SP_Person))
                    row.Responsible_SP_Person = fillSign;
            }
        }
    }

    /// <summary>
    /// Виды отчетов, которые могу генерироваться классом QualityExtendedRegisterReportProvider
    /// </summary>
    public enum QualitySellPermissionRegistryMode
    {
        /// <summary>
        /// Реестр Разрешений на реализацию серии
        /// </summary>
        SellPermissionRegister,

        /// <summary>
        /// Расширенный реестр ЛС от поставщика
        /// </summary>
        QualityVendorExtendedRegister
    }
}
