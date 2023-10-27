using System;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Data.WHTableAdapters;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Окно создания/редактирования акта скидки
    /// </summary>
    public partial class ActDiscountEditForm : Form
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

        public ActDiscountEditForm(long pSessionId)
        {
            InitializeComponent();
            sessionID = pSessionId;
        }

        public ActDiscountEditForm(long pSessionId, WMSOffice.Data.WH.AS_Get_DocsRow pActForEditing)
            : this(pSessionId)
        {
            Text = String.Format("Редактирования акта скидки №{0}", pActForEditing.Doc_ID);
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
            }
        }

        /// <summary>
        /// Загрузка типов документа
        /// </summary>
        private void LoadDocTypes()
        {
            try
            {
                taAsDocTypes.Fill(wH.AS_Doc_Types);

                // исключим тип АС "по товару"
                for (var i = 0; i < wH.AS_Doc_Types.Rows.Count; i++)
                {
                    var docType = (Data.WH.AS_Doc_TypesRow)wH.AS_Doc_Types.Rows[i];
                    if (docType.Doc_Type.Equals("PRC"))
                        wH.AS_Doc_Types.Rows.Remove(docType);
                }

                wH.AS_Doc_Types.AcceptChanges();
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
                            adapter.AddAct(sessionID, dtpDateFrom.Value, Convert.ToInt32(cmbDebitors.SelectedValue),
                                Convert.ToDecimal(tbxSum.Text), cmbDocTypes.SelectedValue.ToString(), tbxDescription.Text);  
                        else
                            adapter.EditAct(sessionID, editingRow.Doc_ID, dtpDateFrom.Value, Convert.ToInt32(cmbDebitors.SelectedValue),
                               Convert.ToDecimal(tbxSum.Text), cmbDocTypes.SelectedValue.ToString(), tbxDescription.Text);

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
                MessageBox.Show("Должен быть выбран дебитор для акта скидки!", "Неверные данные",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Проверка даты - только текущий месяц
            if (dtpDateFrom.Value.Month != DateTime.Now.Month)
            {
                MessageBox.Show("Дата должна быть в текущем месяце!", "Неверные данные",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка вводимой суммы
            if (String.IsNullOrEmpty(tbxSum.Text))
            {
                MessageBox.Show("Должна быть задана сумма для акта скидки!", "Неверные данные",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                decimal discount;
                if (!Decimal.TryParse(tbxSum.Text, out discount) && !Decimal.TryParse(tbxSum.Text.Replace('.', ','), out discount) &&
                    !Decimal.TryParse(tbxSum.Text.Replace(',', '.'), out discount))
                {
                    MessageBox.Show("Сумма для акта скидки задана некорректно!", "Неверные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (discount <= 0)
                {
                    MessageBox.Show("Сумма для акта скидки должна быть больше нуля!", "Неверные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
