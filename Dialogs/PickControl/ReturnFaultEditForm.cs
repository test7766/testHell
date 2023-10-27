using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    /// <summary>
    /// Диалог для изменения (добавления) виновного в проблеме (недостача, НТВ, бой) по определенной товарной строке при поштучном контроле.
    /// </summary>
    public partial class ReturnFaultEditForm : DialogForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="docStatusEmployees">Список сотрудников, участвующих в процессе.</param>
        /// <param name="faultTypeID">Идентификатор типа проблемы (при добавлении можно указать null).</param>
        /// <param name="faultEmployeeID">Код виновного сотрудника (при добавлении можно указать 0).</param>
        /// <param name="quantity">Количество товара (при добавлении можно указать 0).</param>
        /// <param name="openForEdit">Признак, показывающий, открыт ли диалог для изменения (в этом случае ключевые поля - сотрудник, тип проблемы - будут неактивны).</param>
        /// <param name="docID">Код документа</param>
        public ReturnFaultEditForm(Data.WH.DocStatusEmployeesDataTable docStatusEmployees, string faultTypeID, int faultEmployeeID, double quantity, bool openForEdit, long docID)
        {
            InitializeComponent();

            btnOK.DialogResult = DialogResult.None;

            cbFaultEmployee.DataSource = docStatusEmployees;
            returnFaultTypesTableAdapter.Fill(this.pickControl.ReturnFaultTypes, docID);

            if (faultTypeID != null)
                cbFaultType.SelectedValue = faultTypeID;

            if (faultEmployeeID != 0)
                cbFaultEmployee.SelectedValue = faultEmployeeID;

            if (quantity != 0)
                tbQuantity.Text = quantity.ToString();

            cbFaultType.Enabled = cbFaultEmployee.Enabled = !openForEdit;
        }

        /// <summary>
        /// Возвращает выбранный идентификатор типа проблемы.
        /// </summary>
        public string FaultTypeID
        {
            get { return (string)cbFaultType.SelectedValue; }
        }

        /// <summary>
        /// Возвращает код выбранного виновного сотрудника.
        /// </summary>
        public int FaultEmployeeID
        {
            get { return (int)cbFaultEmployee.SelectedValue; }
        }

        /// <summary>
        /// Возвращает введенное количество товара.
        /// </summary>
        public double Quantity
        {
            get
            {
                double result = 0;
                double.TryParse(tbQuantity.Text, out result);
                return result;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            double quantity = 0;
            if (!double.TryParse(tbQuantity.Text, out quantity) || quantity < 0)
            {
                MessageBox.Show("Количество товара задано некорректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
