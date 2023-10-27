using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Класс сохранения данных файла дата-логгера
    /// </summary>
    public partial class DataLoggerSaveForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        private bool sensorModeMissed;

        /// <summary>
        /// № документа закрепления
        /// </summary>
        public long? DocID { get; set; }

        /// <summary>
        /// S/N датчика
        /// </summary>
        public string SensorSerialNumber { get; set; }

        /// <summary>
        /// Признак проверки температурного режима
        /// </summary>
        public bool ValidateSensorMode { get; set; }

        /// <summary>
        /// Идентификатор сессии пользователя (DataLoggerSaveForm)
        /// </summary>
        /// 
        public new int UserID
        {
            get { return DataLoggerHelper.UserID; }
            set { DataLoggerHelper.UserID = value; }
        }

        /// <summary>
        /// Ид-р оборудования
        /// </summary>
        public int? EquipmentID
        {
            get { return DataLoggerHelper.EquipmentID; }
            set { DataLoggerHelper.EquipmentID = value; }
        }

        /// <summary>
        /// "Дата с"
        /// </summary>
        public DateTime StartTimeStamp
        {
            get { return this.dtStartTimeStamp.Value; }
            set { this.dtStartTimeStamp.Value = value; }
        }

        /// <summary>
        /// "Дата по"
        /// </summary>
        public DateTime EndTimeStamp
        {
            get { return this.dtEndTimeStamp.Value; }
            set { this.dtEndTimeStamp.Value = value; }
        }

        /// <summary>
        /// Режим t° датчика
        /// </summary>
        public string SensorModeName
        {
            get { return this.tbSensorModeName.Text; }
            set { this.tbSensorModeName.Text = value; }
        }

        /// <summary>
        /// Возвращает путь к выбранному пользователем прикрепляемому файлу.
        /// </summary>
        public string FilePath { get { return tbDataLoggerPath.Text; } }

        /// <summary>
        /// Каталог логгеров, который выбран по умолчанию для снятия показаний
        /// </summary>
        public static string InitialDataLoggerDirectory { get; private set; }

        #endregion

        public DataLoggerSaveForm()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.None;
            openFileDialog.InitialDirectory = InitialDataLoggerDirectory;
        }

        static DataLoggerSaveForm()
        {
            InitialDataLoggerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        /// <summary>
        /// Настройка дизайна интерфейса
        /// </summary>
        private void SetInterfaceSettings()
        {
            // настройка размещения элементов управления
            this.btnOK.Location = new Point(428, 8);
            this.btnCancel.Location = new Point(518, 8);

            // дизайн интерфейса без проверки температурного режима
            if (!this.ValidateSensorMode)
            {
                gbSensorMode.Visible = false;
                this.gbTimeStampInfo.Top -= gbSensorMode.Height;
                this.pbSensor.Top -= gbSensorMode.Height;
                base.pnlButtons.Top -= gbSensorMode.Height;
                this.Height -= gbSensorMode.Height;
            }
            else
            {
                // дизайн интерфейса с проверкой температурного режима в случае его отстутствия
                if (string.IsNullOrEmpty(SensorModeName))
                {
                    sensorModeMissed = true;
                    SensorModeName = "отсутствует";
                    tbSensorModeName.ForeColor = Color.Red;
                }
            }

            tbDataLoggerPath.Focus();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetInterfaceSettings();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.InitialDirectory = InitialDataLoggerDirectory;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbDataLoggerPath.Text = openFileDialog.FileName;
                    InitialDataLoggerDirectory = System.IO.Path.GetDirectoryName(tbDataLoggerPath.Text);
                }

                SetFilePathFocus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время открытия файла \"" + openFileDialog.FileName + "\" возникла следующая ошибка:" + Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFilePathFocus()
        {
            tbDataLoggerPath.Focus();
            tbDataLoggerPath.SelectAll();
        }

        private void tbDataLoggerPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyOperation(DialogResult.OK);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.Cancel);
        }

        /// <summary>
        /// Выполнить запрашиваемую операцию согласно ожидаемого результата - статуса диалогового окна
        /// </summary>
        /// <param name="agreedResult"></param>
        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
            this.Close();
        }

        private void DataLoggerSaveForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                MessageBox.Show(this, "Данные были успешно сохранены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataLoggerSaveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !SaveLoggerData();
        }

        private bool SaveLoggerData()
        {
            try
            {
                if (sensorModeMissed)
                    throw new Exception("Не задан температурный режим.");

                DataLoggerHelper.AdaptLoggerFileData(tbDataLoggerPath.Text.Trim(), StartTimeStamp, EndTimeStamp, DocID, SensorSerialNumber);
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.InnerException != null ? err.InnerException.Message : err.Message, "Ошибка сохранения данных логгера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                SetFilePathFocus();
                return false;
            }
        }
    }
}
