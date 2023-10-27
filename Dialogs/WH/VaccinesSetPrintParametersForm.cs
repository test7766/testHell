using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;
using WMSOffice.Controls;
using WMSOffice.Reports;

namespace WMSOffice.Dialogs.WH
{
    public partial class VaccinesSetPrintParametersForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private readonly VaccinesDefaultPrintParameters defaultParameters = null;

        public new long UserID { get; set; }

        private string warehouseName = null;
        private string responsiblePersonName = null;
        private string responsiblePersonPost = null;
        private string itemName = null;
        private string vendorLot = null;
        private string manufacturerName = null;
        private string manufacturerCountryName = null;

        public VaccinesSetPrintParametersForm()
        {
            InitializeComponent();
        }

        public VaccinesSetPrintParametersForm(VaccinesDefaultPrintParameters pDefaultParameters)
            : this()
        {
            this.UserID = (defaultParameters = pDefaultParameters).UserID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(801, 8);
            this.btnCancel.Location = new Point(891, 8);

            this.btnOK.Text = "Отчет";
            this.btnCancel.Text = "Закрыть";
        }

        private void Initialize()
        {
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_JV_Get_Available_Warehouses]";
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbWarehouse.AddIgnorableColumn("Person_ID");
            stbWarehouse.AddIgnorableColumn("Warehouse_UDesc");

            stbVaccine.ValueReferenceQuery = "[dbo].[pr_JV_Get_Vaccine_List]";
            stbVaccine.UserID = this.UserID;
            stbVaccine.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbVaccine.AddIgnorableColumn("Item_Name_Ukr");
            stbVaccine.AddIgnorableColumn("ManufacturerName_Ukr");
            stbVaccine.AddIgnorableColumn("CountryOrigin_Ukr");

            stbVendorLot.ValueReferenceQuery = "[dbo].[pr_JV_Get_Vendor_Lots_For_Vaccine]";
            stbVendorLot.UserID = this.UserID;
            stbVendorLot.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbVendorLot.ApplyAdditionalParameter("Item_Code", string.Empty);

            stbStatusFrom.ValueReferenceQuery = "[dbo].[pr_JV_Get_Vaccine_Status_List]";
            stbStatusFrom.UserID = this.UserID;
            stbStatusFrom.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbStatusTo.ValueReferenceQuery = "[dbo].[pr_JV_Get_Vaccine_Status_List]";
            stbStatusTo.UserID = this.UserID;
            stbStatusTo.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbResponsible.ValueReferenceQuery = "[dbo].[pr_JV_Get_Responsible_Persons_List]";
            stbResponsible.UserID = this.UserID;
            stbResponsible.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbResponsible.AddIgnorableColumn("User_FIO_Ukr");
            stbResponsible.AddIgnorableColumn("Staff_Name_Ukr");


            // инициализация значения по умолчанию параметрами
            if (!string.IsNullOrEmpty(defaultParameters.WarehouseID))
                stbWarehouse.SetValueByDefault(defaultParameters.WarehouseID);

            if (!string.IsNullOrEmpty(defaultParameters.ItemID))
                stbVaccine.SetValueByDefault(defaultParameters.ItemID);

            if (!string.IsNullOrEmpty(defaultParameters.StatusFrom))
                stbStatusFrom.SetValueByDefault(defaultParameters.StatusFrom);
            else
                stbStatusFrom.SetValueByDefault("100");

            if (!string.IsNullOrEmpty(defaultParameters.StatusTo))
                stbStatusTo.SetValueByDefault(defaultParameters.StatusTo);
            else
                stbStatusTo.SetValueByDefault("200");

            if (defaultParameters.PeriodFrom.HasValue)
                dtpPeriodFrom.Value = defaultParameters.PeriodFrom.Value;
            else
                dtpPeriodFrom.Value = DateTimeHelper.StartOfWeek(DateTime.Today, DayOfWeek.Monday).AddDays(-7);

            if (defaultParameters.PeriodTo.HasValue)
                dtpPeriodTo.Value = defaultParameters.PeriodTo.Value;
            else
                dtpPeriodTo.Value = DateTimeHelper.EndOfWeek(DateTime.Today, DayOfWeek.Monday).AddDays(-7);

            if (!string.IsNullOrEmpty(defaultParameters.ResponsiblePersonID))
                stbResponsible.SetValueByDefault(defaultParameters.ResponsiblePersonID);
        }

        void stbVendor_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = tbWarehouse;
            else if (control == stbVaccine)
                lblDescription = tbVaccine;
            else if (control == stbVendorLot)
                lblDescription = tbVendorLot;
            else if (control == stbStatusFrom)
                lblDescription = tbStatusFrom;
            else if (control == stbStatusTo)
                lblDescription = tbStatusTo;
            else if (control == stbResponsible)
                lblDescription = tbResponsible;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;

                
                if (control == stbWarehouse)
                {
                    warehouseName = (string)null;
                    stbResponsible.SetValueByDefault(string.Empty);

                    if (e.Success && !string.IsNullOrEmpty(e.Value))
                    {
                        warehouseName = e.OwnedRow["Warehouse_UDesc"].ToString();

                        // Инициализация ответственного
                        if (!e.OwnedRow["Person_ID"].Equals(DBNull.Value))
                        {
                            var personID = Convert.ToInt32(e.OwnedRow["Person_ID"]);
                            stbResponsible.SetValueByDefault(personID.ToString());
                        }
                    }
                }

                if (control == stbResponsible)
                {
                    responsiblePersonName = (string)null;
                    responsiblePersonPost = (string)null;

                    if (e.Success && !string.IsNullOrEmpty(e.Value))
                    {
                        responsiblePersonName = e.OwnedRow["User_FIO_Ukr"].ToString();
                        responsiblePersonPost = e.OwnedRow["Staff_Name_Ukr"].ToString();
                    }
                }

                if (control == stbVaccine)
                {
                    itemName = (string)null;
                    manufacturerName = (string)null;
                    manufacturerCountryName = (string)null;

                    stbVendorLot.SetValueByDefault(string.Empty);
                    stbVendorLot.ApplyAdditionalParameter("Item_Code", string.Empty);

                    if (e.Success && !string.IsNullOrEmpty(e.Value))
                    {
                        itemName = e.OwnedRow["Item_Name_Ukr"].ToString();
                        manufacturerName = e.OwnedRow["ManufacturerName_Ukr"].ToString();
                        manufacturerCountryName = e.OwnedRow["CountryOrigin_Ukr"].ToString();

                        // Инициализация серии
                        var itemID = e.Value;
                        stbVendorLot.ApplyAdditionalParameter("Item_Code", itemID);
                    }
                }

                if (control == stbVendorLot)
                {
                    vendorLot = (string)null;

                    if (e.Success && !string.IsNullOrEmpty(e.Value))
                    {
                        vendorLot = e.Value;
                    }
                }
            }
        }

        private Data.WH RefreshReportData()
        {
            try
            {
                var sessionID = this.UserID;

                var warehouseID = (string)null;
                if (string.IsNullOrEmpty(stbWarehouse.Value))
                    throw new Exception("Не указано подразделение.");
                else
                    warehouseID = stbWarehouse.Value;

                var itemID = (int?)null;
                if (string.IsNullOrEmpty(stbVaccine.Value))
                    throw new Exception("Не указана вакцина.");
                else
                {
                    int itemIDParsed;
                    if (!int.TryParse(stbVaccine.Value, out itemIDParsed))
                        throw new Exception("Код вакцины должен быть числом.");
                    else
                        itemID = itemIDParsed;
                }

                var vendorLot = (string)null;
                if (!string.IsNullOrEmpty(stbVendorLot.Value))
                    vendorLot = stbVendorLot.Value;

                var periodFrom = dtpPeriodFrom.Value.Date;
                var periodTo = dtpPeriodTo.Value.Date;
                if (periodFrom > periodTo)
                    throw new Exception("Начальный период не должен превышать конечный.");

                var statusFrom = (int?)null;
                if (!string.IsNullOrEmpty(stbStatusFrom.Value))
                {
                    int statusFromParsed;
                    if (!int.TryParse(stbStatusFrom.Value, out statusFromParsed))
                        throw new Exception("Код начального статуса должен быть числом.");
                    else
                        statusFrom = statusFromParsed;
                }

                var statusTo = (int?)null;
                if (!string.IsNullOrEmpty(stbStatusTo.Value))
                {
                    int statusToParsed;
                    if (!int.TryParse(stbStatusTo.Value, out statusToParsed))
                        throw new Exception("Код конечного статуса должен быть числом.");
                    else
                        statusTo = statusToParsed;
                }

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = jV_VaccineJournalTableAdapter.GetDataReport(sessionID, warehouseID, itemID, periodFrom, periodTo, statusFrom, statusTo, vendorLot);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        throw (e.Result as Exception);
                    else
                        wH.JV_VaccineJournal.Merge(e.Result as Data.WH.JV_VaccineJournalDataTable);
                };

                wH.JV_VaccineJournal.Clear();

                loadWorker.RunWorkerAsync();

                splashForm.ActionText = "Выполняется получение\nжурнала вакцин..";
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wH;
        }

        private void VaccinesSetPrintParametersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.PrepareReport();
        }

        private bool PrepareReport()
        {
            try
            {
                var reportData = this.RefreshReportData();

                using (var report = new VaccinesJournalReport())
                {
                    report.SetDataSource(reportData);
                    report.SetParameterValue("WarehouseName", warehouseName ?? string.Empty);
                    report.SetParameterValue("ResponsiblePersonName", responsiblePersonName ?? string.Empty);
                    report.SetParameterValue("ResponsiblePersonPost", responsiblePersonPost ?? string.Empty);
                    report.SetParameterValue("ItemName", itemName ?? string.Empty);
                    report.SetParameterValue("VendorLot", vendorLot ?? string.Empty);
                    report.SetParameterValue("ManufacturerName", manufacturerName ?? string.Empty);
                    report.SetParameterValue("ManufacturerCountryName", manufacturerCountryName ?? string.Empty);

                    var form = new ReportForm();
                    form.ReportDocument = report;
                    form.ShowDialog();
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    public class VaccinesDefaultPrintParameters
    {
        public long UserID { get; set; }
        public string WarehouseID { get; set; }
        public string ItemID { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string StatusFrom { get; set; }
        public string StatusTo { get; set; }
        public string ResponsiblePersonID { get; set; }
    }
}
