using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class ColdEquipmentRegistrationForm : DialogForm
    {
        private const int CUSTOM_MEASUREMENTS_TYPE_ID = -1; // фиктивный идентификатор для задания пользовательского размера

        public ColdEquipmentRegistrationForm()
        {
            InitializeComponent();
        }

        private void ColdEquipmentRegistrationForm_Load(object sender, EventArgs e)
        {            
            RefreshData();
            this.DialogResult = DialogResult.None;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tbEquipmentName.Focus();
            AdaptMeasurementsEditor(false);

            btnOK.Location = new Point(207, 8);
            btnCancel.Location = new Point(297, 8);
        }

        /// <summary>
        /// Обновление справочников данных 
        /// </summary>
        private void RefreshData()
        {
            RefreshEquipmentTypes();
            RefreshBranches();
            RefreshMeasurements();
        }

        /// <summary>
        /// Обновление справочника типов оборудования
        /// </summary>
        private void RefreshEquipmentTypes()
        {
            this.coldChain.EquipmentTypes.Merge(ColdChainEquipmentManager.EquipmentTypes);
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

        /// <summary>
        /// Обновление справочника размеров оборудования
        /// </summary>
        private void RefreshMeasurements()
        {
            try
            {
                this.equipmentMeasurementsTableAdapter.Fill(this.coldChain.EquipmentMeasurements);
                AddCustomMeasurements();
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка размеров холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        /// <summary>
        /// Включение режима добавления пользовательских размеров в список доступных размеров для выбора 
        /// </summary>
        private void AddCustomMeasurements()
        {
            var customMeasurement = this.coldChain.EquipmentMeasurements.NewEquipmentMeasurementsRow();
            customMeasurement.Measurement_ID = CUSTOM_MEASUREMENTS_TYPE_ID;
            customMeasurement.Measurements = "Введите размер";
            customMeasurement.Height = 0;
            customMeasurement.Width = 0;
            customMeasurement.Depth = 0;
            this.coldChain.EquipmentMeasurements.AddEquipmentMeasurementsRow(customMeasurement);
        }

        private void cbMeasurements_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdaptMeasurementsEditor(IsCustomMeasurementsEditModeSelected());
        }

        /// <summary>
        /// Возвращает признак выбора режима пользовательского определения размеров
        /// </summary>
        /// <returns></returns>
        private bool IsCustomMeasurementsEditModeSelected()
        {
            return Convert.ToInt16(cbMeasurements.SelectedValue) == CUSTOM_MEASUREMENTS_TYPE_ID;
        }

        /// <summary>
        /// Настройка доступности на интерфейсе пользовательского редактирования размеров в зависимости от установленного режима
        /// </summary>
        /// <param name="showEditor"></param>
        private void AdaptMeasurementsEditor(bool showEditor)
        {
            pnlMeasurements.Enabled = showEditor;
            tbHeight.Focus();
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

        private void ColdEquipmentRegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateOperation();
        }

        /// <summary>
        /// Метод валидации конечного действия пользователя связанного с этой формой
        /// </summary>
        /// <returns></returns>
        private bool ValidateOperation()
        {
            try
            {
                if (tbSerialNumber.Text.Trim() == string.Empty)
                    throw new Exception("S/N холодильного оборудования не может быть пустым.");

                using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                {
                    // Если выбран режим добавления пользовательских размеров -- создаем новый размер
                    if (IsCustomMeasurementsEditModeSelected())
                    {
                        var customMeasurements = (((DataRowView)(equipmentMeasurementsBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.EquipmentMeasurementsRow);
                        object newMeasurementID = adapter.AddMeasurements(customMeasurements.Height, customMeasurements.Width, customMeasurements.Depth, this.UserID);
                        MessageBox.Show(this, "Новый размер оборудования был успешно добавлен.\n\nТеперь Вы можете его использовать выбрав из списка допустимых размеров.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Обновим справочник размеров и установим фокус на только что добавленный размер
                        RefreshMeasurements();
                        cbMeasurements.SelectedValue = newMeasurementID;

                        // Возвращаем "ложь", чтобы форма не закрылась.
                        return false;
                    }
                    // иначе выбран режим выбора существующих размеров -- создаем новое оборудование
                    else
                        adapter.AddColdEquipment(Convert.ToInt32(cbEquipmentTypes.SelectedValue),
                                                 tbEquipmentName.Text.Trim(),
                                                 Convert.ToInt16(cbMeasurements.SelectedValue),
                                                 this.UserID,
                                                 cbBranches.SelectedValue.ToString(),
                                                 tbDepartmentNotation.Enabled ? tbDepartmentNotation.Text.Trim() : string.Empty,
                                                 tbSerialNumber.Text.Trim());
                }

                return true;
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Недопустимая операция", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbEquipmentName.Focus();
                tbEquipmentName.SelectAll();
                this.DialogResult = DialogResult.None;
                return false;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Недопустимая операция", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSerialNumber.Focus();
                tbSerialNumber.SelectAll();
                return false;
            }
        }

        private void tbMeasurementItem_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbMeasurementsItem = sender as TextBox;
            tbMeasurementsItem.Text = tbMeasurementsItem.Text.Trim();

            if (tbMeasurementsItem.Text == string.Empty)
                tbMeasurementsItem.Text = "0";

            e.Cancel = false;
        }

        private void tbMeasurementItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void tbHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbWidth.Focus();
        }

        private void tbWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbDepth.Focus();
        }

        private void tbDepth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbHeight.Focus();
        }
    }
}
