using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class TemperatureSensorRegistrationForm : DialogForm
    {
        public TemperatureSensorRegistrationForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        private void TemperatureSensorRegistrationForm_Load(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        /// <summary>
        /// Обновление справочников данных
        /// </summary>
        private void RefreshData()
        {
            this.RefreshSensorsTypes();
            this.RefreshBranches();
            this.RefreshSensorsModes();
        }

        /// <summary>
        /// Обновление справочника типов датчиков
        /// </summary>
        private void RefreshSensorsTypes()
        {
            try
            {
                this.sensorTypesTableAdapter.Fill(this.coldChain.SensorTypes);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления справочника типов датчиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление справочника режимов датчиков
        /// </summary>
        private void RefreshSensorsModes()
        {
            try
            {
                this.sensorModesTableAdapter.Fill(this.coldChain.SensorModes);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления справочника режимов датчиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление справочника филиалов
        /// </summary>
        private void RefreshBranches()
        {
            try
            {
                this.branchesTableAdapter.Fill(this.coldChain.Branches);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления справочника филиалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tbSensorNumber.Focus();

            btnOK.Location = new Point(174, 8);
            btnCancel.Location = new Point(264, 8);
        }

        void tbSensorNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar); // Каждый символ сделаем большим
        }

        private void tbSensorNumber_KeyDown(object sender, KeyEventArgs e)
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

        private void TemperatureSensorRegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateOperation();
        }

        private bool ValidateOperation()
        {
            try
            {
                if (tbSensorNumber.Text.Trim() == string.Empty)
                    throw new Exception("S/N датчика не может быть пустым.");

                if (!dtpVerificationDate.Checked)
                    throw new Exception("Дата поверки датчика должна быть указана.");
                
                using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                    adapter.AddTemperatureSensor(tbSensorNumber.Text.Trim(), 
                                                 this.UserID, 
                                                 Convert.ToByte(cmbSensorType.SelectedValue), 
                                                 cmbBranches.SelectedValue.ToString(),
                                                 dtpVerificationDate.Value.Date,
                                                 Convert.ToByte(cmbSensorMode.SelectedValue));

                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Недопустимая операция", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSensorNumber.Focus();
                tbSensorNumber.SelectAll();
                this.DialogResult = DialogResult.None;
                return false;
            }
        }
    }
}
