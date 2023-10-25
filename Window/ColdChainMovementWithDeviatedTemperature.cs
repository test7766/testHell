using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.ColdChain;

namespace WMSOffice.Window
{
    public partial class ColdChainMovementWithDeviatedTemperature : GeneralWindow
    {
        private ColdChainMovementWithDeviatedTemperatureManager manager = null;

        /// <summary>
        /// Текущий акт перемещения
        /// </summary>
        private Data.ColdChain.MovementDeviatedItemsHeadersRow CurrentMovementActRow { get { return (this.movementDeviatedItemsHeadersBindingSource.CurrencyManager.Current as DataRowView).Row as Data.ColdChain.MovementDeviatedItemsHeadersRow; } }

        public ColdChainMovementWithDeviatedTemperature(ColdChainMovementWithDeviatedTemperatureManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            this.PreparePrintersList();
        }

        /// <summary>
        /// Сформировать список принтеров, выбрать принтер по умолчанию
        /// </summary>
        private void PreparePrintersList()
        {
            try
            {
                foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cmbPrinters.Items.Add(printerName);

                System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                cmbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SetInterfaceSettings();
            this.RefreshData();
        }

        private void ColdChainMovementWithDeviatedTemperature_Load(object sender, EventArgs e)
        {
            this.movementDeviatedItemsHeadersBindingSource.CurrentItemChanged += new EventHandler(movementDeviatedItemsHeadersBindingSource_CurrentItemChanged);
        }

        private void movementDeviatedItemsHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            this.movementDeviatedItemsDetailsBindingSource.DataSource = null;

            if (this.AreDataExists())
            {
                this.manager.CurrentMovementActID = this.CurrentMovementActRow.Movement_ID;
                this.RefreshMovementDetails();
            }

            this.SetInterfaceSettings();
        }

        /// <summary>
        /// Проверка на существование записей по перемещениям
        /// </summary>
        /// <returns></returns>
        private bool AreDataExists()
        {
            return this.movementDeviatedItemsHeadersBindingSource.CurrencyManager.Count > 0;
        }

        /// <summary>
        /// Доступность к элементам интерфейса
        /// </summary>
        private void SetInterfaceSettings()
        {
            sbPrintOrder.Enabled = this.AreDataExists();
        }

        /// <summary>
        /// Загрузка списка товаров по перемещению
        /// </summary>
        private void RefreshMovementDetails()
        {
            try
            {
                this.movementDeviatedItemsDetailsBindingSource.DataSource = this.movementDeviatedItemsDetailsTableAdapter.GetData(this.manager.CurrentMovementActID);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка момента загрузки деталей перемещения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }
         
        #region Фоновое обновление данных
        private void RefreshData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            this.movementDeviatedItemsHeadersBindingSource.DataSource = null;
            this.manager.WaitProcessForm.ActionText = "Идет обработка запроса...";
            loadWorker.RunWorkerAsync();
            this.manager.WaitProcessForm.ShowDialog();
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.movementDeviatedItemsHeadersTableAdapter.GetData(this.manager.UserID);
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
                this.coldChain.MovementDeviatedItemsHeaders.Clear();
            }
            else
                this.movementDeviatedItemsHeadersBindingSource.DataSource = e.Result;

            this.manager.WaitProcessForm.CloseForce();
        }
        #endregion

        private void sbPrintOrder_Click(object sender, EventArgs e)
        {
            BackgroundWorker printWorker = new BackgroundWorker();
            printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
            printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
            this.manager.WaitProcessForm.ActionText = "Идет печать акта на перемещение...";
            printWorker.RunWorkerAsync(cmbPrinters.SelectedItem.ToString());
            this.manager.WaitProcessForm.ShowDialog();

            this.RefreshData();
        }

        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.PrepareSourceForAct();
                this.PrintAct(e.Argument.ToString());
                this.ChangeMovementActStatus();
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        /// <summary>
        /// Подготовка данных для печати акта перемещения
        /// </summary>
        private void PrepareSourceForAct()
        {
            this.coldChain.Clear();

            using (Data.ColdChainTableAdapters.MovementDeviatedItemsReportDataTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.MovementDeviatedItemsReportDataTableAdapter())
                adapter.Fill(this.coldChain.MovementDeviatedItemsReportData, this.manager.CurrentMovementActID);

            // Сформируем изображение ш/к акта перемещения
            foreach (Data.ColdChain.MovementDeviatedItemsReportDataRow actRow in this.coldChain.MovementDeviatedItemsReportData.Rows)
               actRow.ActBarCodeLabel = Dialogs.Complaints.BarCodeGenerator.GetBarcodeCODE39(actRow.Movement_BarCode);
        }

        /// <summary>
        /// Печать акта на перемещение
        /// </summary>
        /// <param name="printerName"></param>
        private void PrintAct(string printerName)
        {
            using (WMSOffice.Reports.DeviatedTemperatureMovementOrderReport report = new WMSOffice.Reports.DeviatedTemperatureMovementOrderReport())
            {
                report.SetDataSource(this.coldChain);
                report.PrintOptions.PrinterName = printerName;
                report.PrintToPrinter(1, true, 1, 0);
            }
        }

        /// <summary>
        /// Перевод акта на следующий статус
        /// </summary>
        private void ChangeMovementActStatus()
        {
            using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                adapter.ChangeMovementActStatus(this.manager.CurrentMovementActID);
        }

        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);

            this.manager.WaitProcessForm.CloseForce();
        }

        private void sbCompleteOrder_Click(object sender, EventArgs e)
        {
            if (this.manager.CloseMovementAct())
                this.RefreshData();
        }
    }
}
