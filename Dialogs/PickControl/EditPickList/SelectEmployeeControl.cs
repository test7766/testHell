using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.PickControlTableAdapters;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Элемент управления для выбора сотрудника
    /// </summary>
    public partial class SelectEmployeeControl : BaseControl
    {
        #region конструктор

        public SelectEmployeeControl()
        {
            InitializeComponent();
        }

        #endregion

        #region свойства

        /// <summary>
        /// Описание выбираемого сотрудника
        /// </summary>
        public string EmployeeLabel { get { return lblEmployee.Text; } set { lblEmployee.Text = value; } }

        /// <summary>
        /// Является ли выбор сотрудника обязательным полем
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Код сотрудника
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Employee { get; set; }

        #endregion

        private void tbEmployee_TextChanged(object sender, EventArgs e)
        {
            int quantity = 0;
            if (int.TryParse(tbEmployee.Text, out quantity))
            {
                // правильное значение
                if (quantity >= 0)
                {
                    SetQuantityStyle(false, "");
                }
                else
                    SetQuantityStyle(true, "Значение кода сотрудника больше 0.");
            }
            else
                SetQuantityStyle(true, "Неправильный формат числа.");
        }

        private void tbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EmployeeID = 0;
                Employee = "";
                int eid = 0;
                if (int.TryParse(tbEmployee.Text, out eid))
                {
                    // правильное значение
                    if (eid >= 0)
                    {
                        using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                        {
                            var res = adapter.CP_GetEmployeeByID(eid);
                            if (res != null)
                            {
                                EmployeeID = eid;
                                Employee = (string) res;
                            }
                        }
                    }
                }
                OnValueChanged("Employee", EmployeeID);
                RefreshForm();
            }
        }

        /// <summary>
        /// Метод установки стиля поля ввода кода при возникновении ошибок
        /// </summary>
        /// <param name="error"></param>
        /// <param name="text"></param>
        private void SetQuantityStyle(bool error, string text)
        {
            if (error)
            {
                // ошибка ввода количества
                tbEmployee.BackColor = Color.Tomato;
                lblEmployeeResult.ForeColor = Color.Red;
                lblEmployeeResult.Text = text;
                EmployeeID = 0;
            }

            if (!error || !tbEmployee.Enabled)
            {
                // нет ошибки, либо не активный элемент управления
                tbEmployee.BackColor = (tbEmployee.ReadOnly) ? SystemColors.Control : SystemColors.Window;
                lblEmployeeResult.ForeColor = SystemColors.ControlText;
                lblEmployeeResult.Text = Employee;
            }
        }

        private void SelectEmployeeControl_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        public override void RefreshForm()
        {
            if (EmployeeID > 0)
            {
                tbEmployee.Text = EmployeeID.ToString();
                SetQuantityStyle(false, "");
            }
            else if (IsRequired) SetQuantityStyle(true, "Обязательное поле!");
        }
    }
}
