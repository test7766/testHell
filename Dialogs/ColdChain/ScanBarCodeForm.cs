using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class ScanBarCodeForm : DialogForm
    {
        /// <summary>
        /// Тип сценария работы с холодильным оборудованием
        /// </summary>
        public ScanScenarioType ScenarioType { get; set; }

        /// <summary>
        /// Класс сценариев работы с холодильным оборудованием
        /// </summary>
        private static ScanScenario scanScenario = new ScanScenario();

        /// <summary>
        /// Заголовок операции сканирования
        /// </summary>
        public string ScanOperationHeader
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        /// <summary>
        /// Входящие данные процесса сканирования
        /// </summary>
        public object[] RequestData { get; set; }

        /// <summary>
        /// Данные результата завершения процесса обработки сканирования
        /// </summary>
        public object[] ResponseData { get; private set; }

        /// <summary>
        /// Признак принудительного завершения операции сканирования
        /// </summary>
        public bool AbortOperationAccess { get; set; }
        
        /// <summary>
        /// Описание операции сканирования
        /// </summary>
        public string ScanOperationDescription
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        public ScanBarCodeForm(ScanScenarioType scenarioType)
        {
            InitializeComponent();
      
            this.DialogResult = DialogResult.None;      
            this.tbScanner.TextChanged += new System.EventHandler(this.tbScanner_TextChanged);

            // Типизация выбранного сценария
            this.ScenarioType = scenarioType;
            SetInterfaceSettings();
        }

        private void SetInterfaceSettings()
        {
            this.Text = scanScenario[ScenarioType].ScenarioAction;
            lblDescription.Text = scanScenario[ScenarioType].ScenarioDescription;

            // настройка размещения элементов управления
            this.btnOK.Location = new Point(195, 8);
            this.btnCancel.Location = new Point(285, 8);

            this.AbortOperationAccess = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnAbort.Visible = this.AbortOperationAccess;
            tbScanner.Focus();
        }

        void tbScanner_TextChanged(object sender, System.EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.Abort);
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

        private void ScanTermoBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateBarCode();
        }

        /// <summary>
        /// Проверка отсканированного штрих-кода на достоверность и пригодность выполнения операции, ассоциируемой с ним
        /// </summary>
        /// <returns></returns>
        private bool ValidateBarCode()
        {
            try
            {
                this.ResponseData = scanScenario[this.ScenarioType].Execute(tbScanner.Text, this.RequestData);
                return true;
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Недопустимая операция", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbScanner.Focus();
                tbScanner.SelectAll();
                this.DialogResult = DialogResult.None;
                return false;
            }
        }
    }
}
