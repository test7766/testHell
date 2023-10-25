﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.PrintNakl;
using CrystalDecisions.Shared;

namespace WMSOffice.Window.Protocols
{
    public partial class WHSalesProtocolsWindow : GeneralWindow
    {
        private const int MAX_ALLOWED_TIMEOUT = 600;
        private readonly Color PRINTED_COLOR = Color.Green;

        #region ПОЛЯ
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        #endregion

        #region СВОЙСТВА

        /// <summary>
        /// Возвращает одну выделенную строку из списка реестров.
        /// </summary>
        private Data.PrintNakl.SalesRegistriesHeadersRow SelectedRow
        {
            get
            {
                if (dgvSalesRegisrties.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.PrintNakl.SalesRegistriesHeadersRow)((DataRowView)dgvSalesRegisrties.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Возвращает выделенные строки в списке реестров реализации 
        /// </summary>
        private IList<Data.PrintNakl.SalesRegistriesHeadersRow> SelectedRows
        {
            get
            {
                List<Data.PrintNakl.SalesRegistriesHeadersRow> result = new List<Data.PrintNakl.SalesRegistriesHeadersRow>();
                foreach (DataGridViewRow r in dgvSalesRegisrties.Rows)
                    if (r.Selected)
                        result.Add((Data.PrintNakl.SalesRegistriesHeadersRow)((DataRowView)r.DataBoundItem).Row);

                return result;
            }
        }
        #endregion

        #region ИНИЦИАЛИЗАЦИЯ
        public WHSalesProtocolsWindow()
        {
            InitializeComponent();
            PreparePrintersList();
        }

        /// <summary>
        /// Сформировать список принтеров, выбрать принтер по умолчанию
        /// </summary>
        private void PreparePrintersList()
        {
            try
            {
                foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cbPrinters.Items.Add(printerName);

                System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                cbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void WHSalesRegistriesWindow_Shown(object sender, EventArgs e)
        {
            this.FindProtocols();
        }

        #endregion

        #region Запуск фонового обновления реестров
        /// <summary>
        /// Обновления списка реестров реализации
        /// </summary>
        private void RefreshProtocols()
        {
            BackgroundWorker loadDocsWorker = new BackgroundWorker();
            loadDocsWorker.DoWork += new DoWorkEventHandler(loadDocsWorker_DoWork);
            loadDocsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadDocsWorker_RunWorkerCompleted);

            this.salesRegistriesHeadersBindingSource.DataSource = null;
            splashForm.ActionText = "Загрузка списка...";
            loadDocsWorker.RunWorkerAsync(null);
            splashForm.ShowDialog();
        }

        private void loadDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (Data.PrintNaklTableAdapters.SalesRegistriesHeadersTableAdapter adapter = new WMSOffice.Data.PrintNaklTableAdapters.SalesRegistriesHeadersTableAdapter())
                {
                    adapter.SetTimeout(MAX_ALLOWED_TIMEOUT);
                    e.Result = adapter.GetData(this.UserID, SaleProtocolSearchForm.LastStartDate, SaleProtocolSearchForm.LastEndDate, SaleProtocolSearchForm.ItemId, SaleProtocolSearchForm.VendorLot, SaleProtocolSearchForm.LotNumber, SaleProtocolSearchForm.OrderNumber);
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void loadDocsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
                this.printNakl.SalesRegistriesHeaders.Clear();
            }
            else
                this.salesRegistriesHeadersBindingSource.DataSource = e.Result;

            splashForm.CloseForce();
        }
        #endregion

        private void sbFindProtocols_Click(object sender, EventArgs e)
        {
            this.FindProtocols();
        }

        /// <summary>
        /// Поиск реестров реализации по диапазону дат
        /// </summary>
        private void FindProtocols()
        {
            var findForm = new SaleProtocolSearchForm();
            if (findForm.ShowDialog() == DialogResult.OK)
                this.RefreshProtocols();
        }

        private void sbRefreshProtocols_Click(object sender, EventArgs e)
        {
            this.RefreshProtocols();
        }

        #region Запуск фоновой подготовки просмотра реестра реализации
        private void sbPreviewRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesRegisrties.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                PreviewWorkerParameters parameters = new PreviewWorkerParameters() { PreviewRegister = this.SelectedRow };
                BackgroundWorker previewDocsWorker = new BackgroundWorker();
                previewDocsWorker.DoWork += new DoWorkEventHandler(previewDocsWorker_DoWork);
                previewDocsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(previewDocsWorker_RunWorkerCompleted);

                splashForm.ActionText = "Подготовка просмотра протокола...";
                previewDocsWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void previewDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PreviewWorkerParameters p = e.Argument as PreviewWorkerParameters;
                using (var report = this.GetReport(p.PreviewRegister))
                {
                    using (WMSOffice.Dialogs.ReportForm reportForm = new WMSOffice.Dialogs.ReportForm())
                    {
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog();
                    }
                }
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void previewDocsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError(e.Result as Exception);

            splashForm.CloseForce();
        }
        #endregion

        #region Запуск фоновой печать реестров реализации
        private void sbPrintRegistries_Click(object sender, EventArgs e)
        {
            if (dgvSalesRegisrties.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                PrintWorkerParameters parameters = new PrintWorkerParameters() { PrinterName = (string)cbPrinters.SelectedItem };
                foreach (Data.PrintNakl.SalesRegistriesHeadersRow printedRegistry in this.SelectedRows)
                    parameters.PrintedRegistries.Add(printedRegistry);

                BackgroundWorker printDocsWorker = new BackgroundWorker();
                printDocsWorker.DoWork += new DoWorkEventHandler(printDocsWorker_DoWork);
                printDocsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printDocsWorker_RunWorkerCompleted);

                splashForm.ActionText = "Подготовка печати протокола...";
                printDocsWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();

                this.ColorProtocolsByState();
                this.dgvSalesRegisrties.ClearSelection();
            }
        }

        private void printDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintWorkerParameters p = e.Argument as PrintWorkerParameters;
                foreach (Data.PrintNakl.SalesRegistriesHeadersRow printedRegistry in p.PrintedRegistries)
                {
                    using (var report = this.GetReport(printedRegistry))
                    {
                        report.PrintOptions.PrinterName = p.PrinterName;
                        report.PrintOptions.PrinterDuplex = PrinterDuplex.Horizontal;
                        report.PrintToPrinter(1, true, 1, 0);
                    }

                    // Обновим статус напечатанного реестра, если он был готов к печати
                    if (printedRegistry.RegistryStateID == 0)
                        this.UpdateRegistryStatus(printedRegistry);

                    printedRegistry.RegistryStateColor = PRINTED_COLOR.Name;
                }
            }
            catch (Exception err)
            {
                e.Result = err;
            }
        }

        /// <summary>
        /// Получение отчета с привязанными параметрами ии источником данных
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private Reports.PNSaleProtocol GetReport(Data.PrintNakl.SalesRegistriesHeadersRow parameter)
        {
            var report = new WMSOffice.Reports.PNSaleProtocol();

            using (Data.PrintNaklTableAdapters.SalesRegistryDetailsTableAdapter adapter = new WMSOffice.Data.PrintNaklTableAdapters.SalesRegistryDetailsTableAdapter())
            {
                adapter.SetTimeout(MAX_ALLOWED_TIMEOUT);
                report.SetDataSource(adapter.GetData(parameter.RegistryDate, parameter.RegistryDeliveryZoneID, parameter.BranchID, SaleProtocolSearchForm.ItemId, SaleProtocolSearchForm.VendorLot, SaleProtocolSearchForm.LotNumber, SaleProtocolSearchForm.OrderNumber) as DataTable);
            }

            report.SetParameterValue("branch", parameter.Branch);
            report.SetParameterValue("delivery_zone", parameter.RegistryDeliveryZoneID);
            report.SetParameterValue("registry_date", parameter.RegistryDate);
            report.SetParameterValue("protocol_number", parameter.RegistryNumber.ToString("n0"));

            return report;
        }

        /// <summary>
        /// Обновление статуса реестра
        /// </summary>
        /// <param name="registry"></param>
        private void UpdateRegistryStatus(Data.PrintNakl.SalesRegistriesHeadersRow registry)
        {
            return;
            using (Data.PrintNaklTableAdapters.SalesRegistriesHeadersTableAdapter adapter = new WMSOffice.Data.PrintNaklTableAdapters.SalesRegistriesHeadersTableAdapter())
                adapter.UpdateSaleRegistryPrintStatus(this.UserID, registry.RegistryDate, registry.RegistryDeliveryZoneID, registry.BranchID);

            registry.RegistryStateID = 1;
            registry.RegistryStateName = "Напечатан";
        }

        private void printDocsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError(e.Result as Exception);

            splashForm.CloseForce();
        }
        #endregion

        private void dgvSalesProtocols_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.ColorProtocolsByState();
        }

        /// <summary>
        /// Раскраска строк из списка реестров согласно статусов
        /// </summary>
        private void ColorProtocolsByState()
        {
            foreach (DataGridViewRow row in dgvSalesRegisrties.Rows)
            {
                Data.PrintNakl.SalesRegistriesHeadersRow itemRow = (Data.PrintNakl.SalesRegistriesHeadersRow)((DataRowView)row.DataBoundItem).Row;

                // Простая разрисовка строки
                string colorName = itemRow.IsRegistryStateColorNull() ? "white" : itemRow.RegistryStateColor.ToLower();
                Color backColor = Color.FromName(colorName);
                this.ColorRegistryByState(row, backColor);
            }
        }

        private void ColorRegistryByState(DataGridViewRow row, Color backColor)
        {
            for (int c = 0; c < row.Cells.Count; c++)
            {
                row.Cells[c].Style.BackColor = backColor;
                row.Cells[c].Style.SelectionForeColor = backColor;
            }
        }

        /// <summary>
        /// Служебный класс, содержащий параметры печати реестров реализации
        /// </summary>
        private class PrintWorkerParameters
        {
            public string PrinterName { get; set; }
            public List<Data.PrintNakl.SalesRegistriesHeadersRow> PrintedRegistries { get; private set; }

            public PrintWorkerParameters()
            {
                this.PrintedRegistries = new List<Data.PrintNakl.SalesRegistriesHeadersRow>();
            }
        }

        /// <summary>
        /// Служебный класс, содержащий параметры просмотра реестров реализации
        /// </summary>
        private class PreviewWorkerParameters
        {
            /// <summary>
            /// Строка реестра, которая подоежит просмотру
            /// </summary>
            public Data.PrintNakl.SalesRegistriesHeadersRow PreviewRegister { get; set; }
        }

    }
}
