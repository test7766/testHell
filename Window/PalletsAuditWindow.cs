using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Reports;
using System.Diagnostics;
using WMSOffice.Dialogs.Receive;

namespace WMSOffice.Window
{
    public partial class PalletsAuditWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Окно ожидания, которое отображается при длительных операциях
        /// </summary>
        private SplashForm waitProgressForm = new SplashForm();

        /// <summary>
        /// Кнопка списания
        /// </summary>
        private ToolStripButton sbWriteOff = null;

        /// <summary>
        /// Рассматриваемый период
        /// </summary>
        public DateTime? Period { get; private set; }

        /// <summary>
        /// Ид-р поставщика
        /// </summary>
        public int SupplierID { get; private set; }

        /// <summary>
        /// Название поставщика
        /// </summary>
        public string SupplierName { get; private set; }

        #endregion

        public PalletsAuditWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
        }

        private void Initialize()
        {
            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, "Задолженность и история возвратов");

            // Добавление надписи "за период"
            var slFilter = new ToolStripLabel();
            slFilter.Text = "за   период   ";
            tsMainMenu.Items.Add(slFilter);

            // Добавление фильтра для выбора периода
            var dtPeriodFilter = new DateTimePicker();
            dtPeriodFilter.Width = 120;
            dtPeriodFilter.Format = DateTimePickerFormat.Custom;
            dtPeriodFilter.CustomFormat = "dd / MM / yyyy";
            dtPeriodFilter.ValueChanged += delegate(object sender, EventArgs e)
            {
                this.Period = dtPeriodFilter.Value.Date;
            };

            dtPeriodFilter.Value = DateTime.Today.Date;
            tsMainMenu.Items.Add(new ToolStripControlHost(dtPeriodFilter));

            // Добавление разделителя
            tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));
            tsMainMenu.Items.Add(new ToolStripSeparator());
            tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));

            // Добавление надписи "Поставщик"
            var slSupplier = new ToolStripLabel();
            slSupplier.Text = "Поставщик:";//.PadLeft(30, ' ');
            //slSupplier.TextAlign = ContentAlignment.MiddleRight;
            slSupplier.Image = Properties.Resources.find;
            tsMainMenu.Items.Add(slSupplier);

            // Добавление списка поставщиков
            var cmbSupplier = new ComboBox();
            cmbSupplier.Size = new Size(400, cmbSupplier.Height);
            cmbSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            #region Формирование списка поставщиков
            var bsVendors = new BindingSource();
            bsVendors.DataMember = "VendorsForPallets";
            bsVendors.DataSource = new Data.Receive();
            cmbSupplier.DisplayMember = "Vendor";
            cmbSupplier.ValueMember = "Vendor_ID";
            cmbSupplier.DataSource = bsVendors;

            cmbSupplier.SelectedValueChanged += delegate(object sender, EventArgs e)
            {
                this.SupplierID = Convert.ToInt32(cmbSupplier.SelectedValue);
                this.SupplierName = ((cmbSupplier.SelectedItem as DataRowView).Row as Data.Receive.VendorsForPalletsRow).Vendor.Split('(')[0].Trim();

                // Определение возможности проводить списание
                bool canWriteOff = ((cmbSupplier.SelectedItem as DataRowView).Row as Data.Receive.VendorsForPalletsRow).WriteOffAccess;
                if (sbWriteOff != null)
                    sbWriteOff.Enabled = canWriteOff;

                this.LoadData();
            };

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    using (var adapter = new Data.ReceiveTableAdapters.VendorsForPalletsTableAdapter())
                        e.Result = adapter.GetData(this.UserID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                {
                    bsVendors.DataSource = e.Result;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка списка поставщиков..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
            #endregion
            tsMainMenu.Items.Add(new ToolStripControlHost(cmbSupplier));

            // Добавление разделителя
            tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));
            tsMainMenu.Items.Add(new ToolStripSeparator());
            tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));

            // Добавление опции экпорта
            var sbExport = new ToolStripButton("Экспорт истории\nвозврата паллет", Properties.Resources.Excel, this.ExportData);
            tsMainMenu.Items.Add(sbExport);

            // Добавление разделителя
            tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));
            tsMainMenu.Items.Add(new ToolStripSeparator());
            tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));

            // Добавление опции изменения признака возвратности
            var sbChangeReturnflag = new ToolStripButton("Изменить признак\nвозвратности по\nпоставщику", Properties.Resources.edit_document, this.ChangeReturnFlag);
            tsMainMenu.Items.Add(sbChangeReturnflag);

            // Добавление разделителя
            tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));
            tsMainMenu.Items.Add(new ToolStripSeparator());
            tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));

            // Добавление опции списания
            sbWriteOff = new ToolStripButton("Списание", Properties.Resources.assign, this.WriteOff);
            sbWriteOff.Enabled = false;
            tsMainMenu.Items.Add(sbWriteOff);

            this.CustomizeGrid();
            cmbSupplier.Focus();
        }

        /// <summary>
        /// Определение уровня доступа к редактированию данных
        /// </summary>
        private void CustomizeGrid()
        {
            try
            {
                Data.Receive.AccessPalletsForSecureAccountingRow accessRow = null;
                using (var adapter = new Data.ReceiveTableAdapters.AccessPalletsForSecureAccountingTableAdapter())
                    accessRow = adapter.GetData(this.UserID)[0];

                this.dgvData.ReadOnly = !accessRow.Access;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = this.palletsOfVendorForSecureAccountingTableAdapter.GetData(this.UserID, this.SupplierID, this.Period);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                    this.palletsOfVendorForSecureAccountingBindingSource.DataSource = e.Result;

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        /// <summary>
        /// Экпорт в Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportData(object sender, EventArgs e)
        {
            var dataSource = new Data.Receive();
            #region Формирование источника данных для отчета
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.PalletsReturnAccountingHistoryTableAdapter())
                    adapter.Fill(dataSource.PalletsReturnAccountingHistory, this.UserID, this.SupplierID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return;
            }
            #endregion

            #region Построение отчета и экспорт в Excel
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт истории возвратов";
                dlgSelectFile.FileName = string.Format("История возвратов поставщику № {0}", this.SupplierID);
                dlgSelectFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSelectFile.Filter = "Excel файл (*.xls, *.xlsx)|*.xls;*.xlsx";
                dlgSelectFile.FilterIndex = 0;
                dlgSelectFile.AddExtension = true;
                //dlgSelectFile.DefaultExt = "csv";
                if (dlgSelectFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var report = new PalletsReturnAccountingHistoryReport();
                        report.SetDataSource(dataSource);
                        report.SetParameterValue("SupplierName", this.SupplierName);
                        report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Изменение признака возвратности по поставщику
        /// </summary>
        private void ChangeReturnFlag(object sender, EventArgs e)
        {
            var dlgChangeReturnFlag = new PalletsChangeVendorReturnFlagWindow() { UserID = this.UserID, StartPosition = FormStartPosition.CenterScreen, MaximizeBox = false, MinimizeBox = false, Owner = this };
            dlgChangeReturnFlag.InitDocument(this.DocName, 0, this.DocType, DateTime.Now, null, null);

            dlgChangeReturnFlag.ShowDialog();
        }

        /// <summary>
        /// Списание
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteOff(object sender, EventArgs e)
        {
            var dlgWriteOff = new PalletsWriteOffAccountingForm() { UserID = this.UserID, VendorID = this.SupplierID, Owner = this };
            dlgWriteOff.ShowDialog();
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                var row = (dgvData.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.PalletsOfVendorForSecureAccountingRow;
                this.palletsOfVendorForSecureAccountingTableAdapter.CorrectPallets(this.UserID, this.SupplierID, this.Period, row.Type_ID, row.StartDebt);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }

            this.LoadData();
        }
    }
}
