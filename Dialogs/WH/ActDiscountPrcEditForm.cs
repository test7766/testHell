using System;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Data.WHTableAdapters;
using System.Drawing;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Окно создания/редактирования акта скидки
    /// </summary>
    public partial class ActDiscountPrcEditForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Редактируемый акт скидки (если режим добавления нового акта скидки, то эта переменная равна null)
        /// </summary>
        private WMSOffice.Data.WH.AS_Get_DocsRow editingRow;

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ ФОРМЫ

        public ActDiscountPrcEditForm(long pSessionId)
        {
            InitializeComponent();
            sessionID = pSessionId;
        }

        public ActDiscountPrcEditForm(long pSessionId, WMSOffice.Data.WH.AS_Get_DocsRow pActForEditing)
            : this(pSessionId)
        {
            Text = String.Format("Редактирование акта скидки по товару №{0}", pActForEditing.Doc_ID);
            editingRow = pActForEditing;            
        }

        /// <summary>
        /// Загрузка данных в выпадающий список дебиторов
        /// </summary>
        private void ActDiscountEditForm_Load(object sender, EventArgs e)
        {
            LoadDocTypes();
            LoadDebtorList();
            
            if (editingRow != null)
            {
                this.FetchActPrcParams();

                tbxSum.Text = editingRow.Amount_Gross.ToString();
                tbxDescription.Text = editingRow.Description == null ? String.Empty : editingRow.Description;
                dtpDateFrom.Value = editingRow.Doc_Date;
                foreach (var item in cmbDebitors.Items)
                    if (((item as DataRowView).Row as WMSOffice.Data.WH.AS_Get_DebtorListRow).Debtor_ID == editingRow.Debtor_ID)
                    {
                        cmbDebitors.SelectedItem = item;
                        break;
                    }

                foreach (var item in cmbDocTypes.Items)
                    if (((item as DataRowView).Row as WMSOffice.Data.WH.AS_Doc_TypesRow).Doc_Type == editingRow.Doc_Type)
                    {
                        cmbDocTypes.SelectedItem = item;
                        break;
                    }

                cmbDebitors.Enabled = false;
                cmbDocTypes.Enabled = false;

                tbxItems.ReadOnly = true; 
                tbxItems.BackColor = SystemColors.Window;
                tbxItems.ForeColor = Color.Gray;
                
                tbxInvoices.ReadOnly = true; 
                tbxInvoices.BackColor = SystemColors.Window;
                tbxInvoices.ForeColor = Color.Gray;
                
                tbxPercent.ReadOnly = true; 
                tbxPercent.BackColor = SystemColors.Window;
                tbxPercent.ForeColor = Color.Gray;
                
                tbxSum.ReadOnly = true; 
                tbxSum.BackColor = SystemColors.Window;
                tbxSum.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Извлечение параметров акта
        /// </summary>
        private void FetchActPrcParams()
        {
            var sInvoices = (string)null;
            var sItems = (string)null;
            var percent = (double?)null;

            try
            {
                using (var adapter = new AS_Get_DocsTableAdapter())
                    adapter.FetchActPrcParams(editingRow.Doc_ID, ref sInvoices, ref sItems, ref percent);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Во время загрузки параметров документа возникла ошибка, дальнейшее редактирование акта скидки невозможно!" +
                   Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            tbxInvoices.Text = sInvoices ?? string.Empty;
            tbxItems.Text = sItems ?? string.Empty;
            tbxPercent.Text = (percent ?? 0.0).ToString("f2");
        }

        /// <summary>
        /// Загрузка типов документа
        /// </summary>
        private void LoadDocTypes()
        {
            try
            {
                taAsDocTypes.Fill(wH.AS_Doc_Types);

                // оставим только тип АС "по товару"
                for (var i = 0; i < wH.AS_Doc_Types.Rows.Count; i++)
                {
                    var docType = (Data.WH.AS_Doc_TypesRow)wH.AS_Doc_Types.Rows[i];
                    if (docType.Doc_Type.Equals("PRC"))
                    {
                        var items = docType.ItemArray;

                        wH.AS_Doc_Types.Rows.Clear();
                        wH.AS_Doc_Types.LoadDataRow(items, true);
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Во время загрузки типов документа возникла ошибка, дальнейшее редактирование акта скидки невозможно!" + 
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Загрузка списка дебиторов
        /// </summary>
        private void LoadDebtorList()
        {
            try
            {
                taAsGetDebtorList.Fill(wH.AS_Get_DebtorList, null);
                cmbDebitors_SelectedIndexChanged(cmbDebitors, EventArgs.Empty);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Во время загрузки списка дебиторов возникла ошибка, дальнейшее редактирование акта скидки невозможно!" +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Отображение филиала при изменении выбранного дебитора
        /// </summary>
        private void cmbDebitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDebitors.SelectedItem == null)
                return;

            tbxFilial.Text = ((cmbDebitors.SelectedItem as DataRowView).Row as WMSOffice.Data.WH.AS_Get_DebtorListRow).Business_Unit;
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ

        /// <summary>
        /// Попытка сохранения результатов редактирования
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
                try
                {
                    using (var adapter = new AS_Get_DocsTableAdapter())
                        if (editingRow == null)
                            adapter.AddActPrc(sessionID, Convert.ToInt32(cmbDebitors.SelectedValue),
                                tbxInvoices.Text, tbxItems.Text, Convert.ToDouble(tbxPercent.Text),
                                Convert.ToDecimal(tbxSum.Text), tbxDescription.Text,
                                dtpDateFrom.Value, cmbDocTypes.SelectedValue.ToString());
                        else
                            adapter.EditActPrc(sessionID, editingRow.Doc_ID, dtpDateFrom.Value, tbxDescription.Text);
                    
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка при сохранении акта скидки в БД: " + Environment.NewLine + exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True, если все данные введены правильно, False в противном случае</returns>
        private bool ValidateData()
        {
            // Проверяем, выбран ли дебитор
            if (cmbDebitors.SelectedItem == null)
            {
                MessageBox.Show("Должен быть выбран дебитор для акта скидки!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Проверка даты - только текущий месяц
            if (dtpDateFrom.Value.Month != DateTime.Now.Month)
            {
                MessageBox.Show("Дата должна быть в текущем месяце!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка на допустимую длину строки в списке товаров
            if (tbxItems.Text.Length > 1000)
            {
                MessageBox.Show("Длина строки в списке товаров должна быть не больше 1000!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка на допустимую длину строки в списке инвойсов
            if (tbxInvoices.Text.Length > 1000)
            {
                MessageBox.Show("Длина строки в списке инвойсов должна быть не больше 1000!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка на допустимую длину строки в описании
            if (tbxDescription.Text.Length > 255)
            {
                MessageBox.Show("Длина строки в описании должна быть не больше 255!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка вводимого процента
            if (String.IsNullOrEmpty(tbxPercent.Text))
            {
                MessageBox.Show("Должен быть задан процент для акта скидки!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                double percent;
                if (!Double.TryParse(tbxPercent.Text, out percent) && !Double.TryParse(tbxPercent.Text.Replace('.', ','), out percent) &&
                    !Double.TryParse(tbxPercent.Text.Replace(',', '.'), out percent))
                {
                    MessageBox.Show("Процент для акта скидки задан некорректно!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (percent < 1.0)
                {
                    MessageBox.Show("Процент для акта скидки должен быть\r\nне меньше единицы!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Проверка вводимой суммы
            if (String.IsNullOrEmpty(tbxSum.Text))
            {
                MessageBox.Show("Должна быть задана сумма для акта скидки!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                decimal discount;
                if (!Decimal.TryParse(tbxSum.Text, out discount) && !Decimal.TryParse(tbxSum.Text.Replace('.', ','), out discount) &&
                    !Decimal.TryParse(tbxSum.Text.Replace(',', '.'), out discount))
                {
                    MessageBox.Show("Сумма для акта скидки задана некорректно!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (discount <= 0)
                {
                    MessageBox.Show("Сумма для акта скидки должна быть больше нуля!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
