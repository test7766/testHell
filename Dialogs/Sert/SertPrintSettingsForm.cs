using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// Диалог для изменения настроек печати сертификатов.
    /// </summary>
    public partial class SertPrintSettingsForm : Form
    {
        /// <summary>
        /// Идентификатор сессиии.
        /// </summary>
        private int userID;

        /// <summary>
        /// Деактивация таба истории
        /// </summary>
        public bool DisableHistory
        {
            set { gbCheckHistory.Visible = !value; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="userID">Идентификатор сессии.</param>
        public SertPrintSettingsForm(int userID)
        {
            InitializeComponent();

            this.userID = userID;
            UpdateControlsValues();
        }

        /// <summary>
        /// Обновляет состояние элементов управления согласно текущим настройкам
        /// </summary>
        private void UpdateControlsValues()
        {
            tbSertDBDataSource.Text = SertPrintSettings.SertDBDataSource;
            tbSertDBInitialCatalog.Text = SertPrintSettings.SertDBInitialCatalog;
            tbSertDBUserID.Text = SertPrintSettings.SertDBUserID;
            tbSertDBPassword.Text = SertPrintSettings.SertDBPassword;

            chkbUseDefaultPrinter.Checked = SertPrintSettings.UseDefaultPrinter;
            cbCustomPrinterName.Items.Clear();
            foreach (string p in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbCustomPrinterName.Items.Add(p);
            }
            if (cbCustomPrinterName.Items.IndexOf(SertPrintSettings.CustomPrinterName) == -1 &&
                (!string.IsNullOrEmpty(SertPrintSettings.CustomPrinterName) || cbCustomPrinterName.Items.Count == 0))
            {
                cbCustomPrinterName.Items.Add(SertPrintSettings.CustomPrinterName);
            }
            cbCustomPrinterName.SelectedItem = SertPrintSettings.CustomPrinterName;

            chkbIgnorePrintMode.Checked = SertPrintSettings.IgnorePrintMode;
            cbCustomPrintMode.SelectedIndex = (int)SertPrintSettings.CustomPrintMode;

            chkbIgnoreCheckHistory.Checked = SertPrintSettings.IgnoreCheckHistory;
            nudCustomNoPrintDaysCount.Value = SertPrintSettings.CustomNoPrintDaysCount;

            chkbIgnoreScale.Checked = SertPrintSettings.IgnoreScale;
            cbCustomScale.SelectedIndex = (int)SertPrintSettings.CustomScale;

            chkbUseLimitOfPages.Checked = SertPrintSettings.UseLimitOfPages;
            if (cbCustomPagesInBatch.Items.IndexOf(SertPrintSettings.CustomPagesInBatchCount.ToString()) == -1)
            {
                cbCustomPagesInBatch.Items.Add(SertPrintSettings.CustomPagesInBatchCount.ToString());
            }
            cbCustomPagesInBatch.SelectedItem = SertPrintSettings.CustomPagesInBatchCount.ToString();
        }

        /// <summary>
        /// Меняет доступность элементов управления при изменении состояния флажка.
        /// </summary>
        private void chkbUseDefaultPrinter_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomPrinterName.Enabled = cbCustomPrinterName.Enabled = !chkbUseDefaultPrinter.Checked;
        }

        /// <summary>
        /// Меняет доступность элементов управления при изменении состояния флажка.
        /// </summary>
        private void chkbIgnorePrintMode_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomPrintMode.Enabled = cbCustomPrintMode.Enabled = chkbIgnorePrintMode.Checked;
        }

        /// <summary>
        /// Меняет доступность элементов управления при изменении состояния флажка.
        /// </summary>
        private void chkbIgnoreCheckHistory_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomNoPrintDaysCount.Enabled = nudCustomNoPrintDaysCount.Enabled = chkbIgnoreCheckHistory.Checked;
        }

        /// <summary>
        /// Меняет доступность элементов управления при изменении состояния флажка.
        /// </summary>
        private void chkbIgnoreScale_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomScale.Enabled = cbCustomScale.Enabled = chkbIgnoreScale.Checked;
        }

        /// <summary>
        /// Меняет доступность элементов управления при изменении состояния флажка.
        /// </summary>
        private void chkbUseLimitOfPages_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomPagesInBatch.Enabled = cbCustomPagesInBatch.Enabled = chkbUseLimitOfPages.Checked;
        }

        /// <summary>
        /// Загружает настройки по умолчанию из базы данных.
        /// </summary>
        private void btnGetDefaultSettingsFromDB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите загрузить настройки из базы данных? Выполнение этого действия сбросит все текущие настройки!",
                "Предупреждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
            {
                string defaultSettings = null;
                try
                {
                    using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
                    {
                        defaultSettings = (string)adapter.GetDefaultSettings(userID);
                    }
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("При загрузке настроек по умолчанию из базы данных возникла следующая ошибка:" + Environment.NewLine +
                        ex1.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    SertPrintSettings.ParseXML(defaultSettings);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("При обработке загруженных настроек возникла следующая ошибка:" + Environment.NewLine +
                        ex2.Message + Environment.NewLine + "Часть настроек может отсутствовать.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                UpdateControlsValues();
            }
        }

        /// <summary>
        /// Тестирует подключение к базе сертификатов
        /// </summary>
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
                {
                    adapter.SetConnectionString(
                        (new System.Data.SqlClient.SqlConnectionStringBuilder()
                        {
                            DataSource = tbSertDBDataSource.Text,
                            InitialCatalog = tbSertDBInitialCatalog.Text,
                            UserID = tbSertDBUserID.Text,
                            Password = tbSertDBPassword.Text
                        }).ToString()
                        );
                    object result = adapter.TestSertClientConnection();
                    if (result == null || result.Equals(DBNull.Value) || result.ToString() != "1") // значение "1" - прописано в тестовом запросе
                        throw new Exception("Тестовый запрос не вернул ожидаемый результат (1).");
                    else
                        MessageBox.Show("Подключение прошло успешно.", "Результат теста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При тестировании подключения к базе сертификатов возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК", сохраняя настройки в базе данных.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            SertPrintSettings.SertDBDataSource = tbSertDBDataSource.Text;
            SertPrintSettings.SertDBInitialCatalog = tbSertDBInitialCatalog.Text;
            SertPrintSettings.SertDBUserID = tbSertDBUserID.Text;
            SertPrintSettings.SertDBPassword = tbSertDBPassword.Text;

            SertPrintSettings.UseDefaultPrinter = chkbUseDefaultPrinter.Checked;
            SertPrintSettings.CustomPrinterName = cbCustomPrinterName.SelectedItem == null ? string.Empty : cbCustomPrinterName.SelectedItem.ToString();

            SertPrintSettings.IgnorePrintMode = chkbIgnorePrintMode.Checked;
            SertPrintSettings.CustomPrintMode = (SertPrintSettings.PrintModes)cbCustomPrintMode.SelectedIndex;
            
            SertPrintSettings.IgnoreCheckHistory = chkbIgnoreCheckHistory.Checked;
            SertPrintSettings.CustomNoPrintDaysCount = (UInt16)nudCustomNoPrintDaysCount.Value;
            
            SertPrintSettings.IgnoreScale = chkbIgnoreScale.Checked;
            SertPrintSettings.CustomScale = (SertPrintSettings.Scales)cbCustomScale.SelectedIndex;

            SertPrintSettings.UseLimitOfPages = chkbUseLimitOfPages.Checked;
            SertPrintSettings.CustomPagesInBatchCount = Convert.ToUInt16(cbCustomPagesInBatch.SelectedItem == null ? "0" : cbCustomPagesInBatch.SelectedItem.ToString());

            try
            {
                using (Data.SertTableAdapters.QueriesTableAdapter adapter = new Data.SertTableAdapters.QueriesTableAdapter())
                {
                    adapter.UpdateSettings(Environment.MachineName, SertPrintSettings.GetXML());
                }
                Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("При сохранении настроек возникла следующая ошибка:" + Environment.NewLine +
                    ex1.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
