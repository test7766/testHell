using System;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Data.ColdChainTableAdapters;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Окно для выдачи/возврата термобоксов сотрудникам
    /// </summary>
    public partial class TermoboxDriverBarCodeEnteringForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// True если закрепление термобокса за сотрудником, False если возврат термобокса от сотрудника
        /// </summary>
        private readonly bool link;

        /// <summary>
        /// Штрих-код отсканированного термобокса
        /// </summary>
        public string termboxBarcode;

        /// <summary>
        /// Штрих-код отсканированного датчика
        /// </summary>
        public string sensorBarcode;

        /// <summary>
        /// Штрих-код сотрудника
        /// </summary>
        public string employeeBarcode;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public TermoboxDriverBarCodeEnteringForm(long pSessionID, bool pLink)
        {
            InitializeComponent();
            sessionID = pSessionID;
            link = pLink;
            EnableScanTermoboxControls();
        }

        /// <summary>
        /// Пока не был отсканирован или выбран термобокс, сенсор и сотрудника выбирать не можем
        /// </summary>
        private void EnableScanTermoboxControls()
        {
            lblTermobox.Enabled = tbsTermobox.Enabled = true;
            lblSensor.Enabled = tbsSensor.Enabled = lblEmployee.Enabled = tbsEmployee.Enabled = false;
            if (!link)
            {
                Size = new Size(515, 243);
                lblSensor.Enabled = tbsSensor.Enabled = lblEmployee.Visible = tbsEmployee.Visible = false;
                Text = "Возврат термобокса";
            }

            tbsTermobox.SelectAll();
            tbsTermobox.Focus();
        }

        /// <summary>
        /// После того, как термобокс был выбран/отсканирован, нужно сделать недоступным повторный 
        /// выбор термобокса и переключиться на скан сенсора
        /// </summary>
        private void EnableScanSensorControls()
        {
            lblTermobox.Enabled = tbsTermobox.Enabled = lblEmployee.Enabled = tbsEmployee.Enabled = false;
            lblSensor.Enabled = tbsSensor.Enabled = true;
            tbsSensor.Focus();
        }

        /// <summary>
        /// После того, как термобокс был выбран/отсканирован, нужно сделать недоступным повторный 
        /// выбор термобокса и переключиться на скан сотрудника
        /// </summary>
        private void EnableScanEmployeeControls()
        {
            lblTermobox.Enabled = tbsTermobox.Enabled = lblSensor.Enabled = tbsSensor.Enabled = false;
            lblEmployee.Enabled = tbsEmployee.Enabled = true;
            tbsEmployee.Focus();
        }

        #endregion

        #region СКАНИРОВАНИЕ ТЕРМОБОКСА, СЕНСОРА И СОТРУДНИКА

        /// <summary>
        /// Сканирование термобокса - переход на сканирование сенсора
        /// </summary>
        private void tbsTermobox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbsTermobox.Text))
                EnableScanSensorControls();
        }

        /// <summary>
        /// Сканирование сенсора - переход на сканирование сотрудника
        /// </summary>
        private void tbsSensor_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbsSensor.Text))
                if (link)
                    EnableScanEmployeeControls();
                else
                    FinishTyping();
        }

        /// <summary>
        /// Сканирование штрих-кода сотрудника
        /// </summary>
        private void tbsEmployee_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbsEmployee.Text))
                FinishTyping();
        }

        /// <summary>
        /// Завершение сканирования и вызов процедуры
        /// </summary>
        private void FinishTyping()
        {
            try
            {
                using (var adapter = new TD_get_termobox_drivers_historyTableAdapter())
                    adapter.SetTermoboxBinding(sessionID, link ? (int?)Convert.ToInt32(tbsEmployee.Text) : null,
                        tbsTermobox.Text, tbsSensor.Text);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время изменения закрепления: ", exc);
                EnableScanTermoboxControls();
            }
        }

        #endregion
    }
}
