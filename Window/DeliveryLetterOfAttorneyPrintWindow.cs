using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Reports;
using WMSOffice.Classes;
using WMSOffice.Dialogs.Delivery;

namespace WMSOffice.Window
{
    public partial class DeliveryLetterOfAttorneyPrintWindow : GeneralWindow
    {
        #region КОНСТАНТЫ

        /// <summary>
        /// Статус доверенности "Напечатана"
        /// </summary>
        private const string STATUS_PRINTED = "199";

        #endregion

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        #endregion

        public DeliveryLetterOfAttorneyPrintWindow()
        {
            InitializeComponent();
        }

        private void DeliveryLetterOfAttorneyPrintWindow_Load(object sender, EventArgs e)
        {
            Config.LoadDataGridViewSettings(this.Name, dgvDocs);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);
            ReloadData(true);
        }

        private void sbFind_Click(object sender, EventArgs e)
        {
            var dlgDeliveryLetterOfAttorneySearchForm = new DeliveryLetterOfAttorneySearchForm();
            if (dlgDeliveryLetterOfAttorneySearchForm.ShowDialog() == DialogResult.OK)
                ReloadData(false);
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            ReloadData(true);
        }

        private void ReloadData(bool reloadAll)
        {
            if (reloadAll)
            {
                DeliveryLetterOfAttorneySearchForm.SearchContext.ComplaintNumber = (long?)null;
                DeliveryLetterOfAttorneySearchForm.SearchContext.Date = (DateTime?)null;
            }

            var bw = new BackgroundWorker();
            
            bw.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = letterOfAttorneyDocsTableAdapter.GetData(this.UserID, DeliveryLetterOfAttorneySearchForm.SearchContext.ComplaintNumber, DeliveryLetterOfAttorneySearchForm.SearchContext.Date);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            bw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    ShowError(e.Result as Exception);
                else
                    delivery.LetterOfAttorneyDocs.Merge(e.Result as DataTable);

                waitProgressForm.CloseForce();
            };

            delivery.LetterOfAttorneyDocs.Clear();
            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            bw.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        private void sbPrint_Click(object sender, EventArgs e)
        {
            if (PrintDocs())
                ReloadData(DeliveryLetterOfAttorneySearchForm.SearchContext.SearchAll);
        }

        private bool PrintDocs()
        {
            if (dgvDocs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите документы для печати.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Запрос на ввод номера доверенности
            var dlgGenNumber = new DeliveryLetterOfAttorneyInitNumberForm();
            if (dlgGenNumber.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Печать доверенностей прервана.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            var genDocNumber = dlgGenNumber.InitNumber;

            MessageBox.Show("Поместите в лоток для бумаги заверенные доверенности\r\nв необходимом количестве.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            bool success = false;

            var docs = new List<LetterOfAttorneyPrintParameter>();
            foreach (DataGridViewRow gr in dgvDocs.SelectedRows)
            {
                var dr = (gr.DataBoundItem as DataRowView).Row as Data.Delivery.LetterOfAttorneyDocsRow;
                docs.Add(new LetterOfAttorneyPrintParameter() { DocID = dr.Doc_id, DocNumber = genDocNumber++, PrinterName = (string)cmbPrinters.SelectedItem });
            }

            var bw = new BackgroundWorker();

            bw.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    foreach (var doc in docs)
                    {
                        // Получение данных для печати
                        //
                        // Реквизиты компании
                        using (var adapter = new Data.DeliveryTableAdapters.CompanyConstantsTableAdapter())
                            adapter.Fill(delivery.CompanyConstants, "UA", (DateTime?)null);

                        // Содержимое печати
                        using (var adapter = new Data.DeliveryTableAdapters.LetterOfAttorneyDocsDetailsTableAdapter())
                            adapter.Fill(delivery.LetterOfAttorneyDocsDetails, this.UserID, doc.DocID);

                        // Установка номера доверенности для печати
                        foreach (Data.Delivery.LetterOfAttorneyDocsDetailsRow row in delivery.LetterOfAttorneyDocsDetails.Rows)
                            row.Doc_Number = doc.DocNumber;

                        // Печать доверенности
                        //
                        var report = new DeliveryLetterOfAttorneyReport();
                        report.SetDataSource(delivery);
                        report.PrintOptions.PrinterName = doc.PrinterName;
                        report.PrintToPrinter(1, false, 1, 0);

                        // Визирование печати доверенности
                        //
                        letterOfAttorneyDocsTableAdapter.ChangeDocStatus(this.UserID, doc.DocID, (string)null, STATUS_PRINTED);
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            bw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    ShowError(e.Result as Exception);
                else
                    success = true;

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется печать доверенностей..";
            bw.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            return success;
        }

        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var row = (dgvDocs.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Delivery.LetterOfAttorneyDocsRow;

            if (row.Status_id.Equals(STATUS_PRINTED))
            {
                dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
                dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.LightGray;
            }
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            sbSetDriver.Enabled = dgvDocs.SelectedRows.Count > 0 && ((dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Delivery.LetterOfAttorneyDocsRow).Status_id.Equals(STATUS_PRINTED);
        }

        private void sbSetDriver_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение списка водителей
                using (var adapter = new Data.DeliveryTableAdapters.DriversTableAdapter())
                    adapter.Fill(delivery.Drivers, this.UserID);

                var dlgSelectDriver = new WMSOffice.Dialogs.RichListForm();
                dlgSelectDriver.Text = "Выберите водителя";
                dlgSelectDriver.AddColumn("Employee_ID", "Employee_ID", "Код");
                dlgSelectDriver.AddColumn("Employee_Name", "Employee_Name", "Ф.И.О. сотрудника");
                dlgSelectDriver.ColumnForFilters = new List<string>(new string[] { "Employee_Name" });
                dlgSelectDriver.FilterChangeLevel = 0;

                delivery.Drivers.DefaultView.RowFilter = string.Empty;
                dlgSelectDriver.DataSource = delivery.Drivers;

                if (dlgSelectDriver.ShowDialog() != DialogResult.OK)
                    return;
                
                var driver = dlgSelectDriver.SelectedRow as Data.Delivery.DriversRow;
                var row = ((dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Delivery.LetterOfAttorneyDocsRow);

                // Закрепление водителя
                letterOfAttorneyDocsTableAdapter.SetDriver(this.UserID, row.Doc_id, Convert.ToInt32(driver.Employee_ID));

                // После закрепления водителя обновим документ источника (без перечитки всего источника)
                row.Driver_id = driver.Employee_ID;
                row.Driver_Name = driver.Employee_Name;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void DeliveryLetterOfAttorneyPrintWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, dgvDocs);
        }

        private class LetterOfAttorneyPrintParameter
        {
            public long DocID { get; set; }
            public int DocNumber { get; set; }
            public string PrinterName { get; set; }
        }
    }
}
