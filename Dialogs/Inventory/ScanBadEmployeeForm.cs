using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class ScanBadEmployeeForm : Form
    {
        /// <summary>
        /// Код док-та
        /// </summary>
        public long DocID { get; set; }

        public ScanBadEmployeeForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.tbScanner.Focus();
        }

        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private int _employeeID = 0;
        public int EmployeeID
        {
            get { return _employeeID; }
        }

        private void ScanBadEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (DialogResult == DialogResult.OK)
            e.Cancel = !TryClose();
        }

        private bool TryClose()
        {
            try
            {
                int code = 0;
                if (!int.TryParse(tbScanner.Text, out code))
                    throw new ArgumentException("Неправильный формат штрих-кода!");

                // Проверка правильности ш/к сотрудника
                using (Data.AccessTableAdapters.UserInfoTableAdapter adapter = new WMSOffice.Data.AccessTableAdapters.UserInfoTableAdapter())
                {
                    Data.Access.UserInfoDataTable tblInfo = adapter.GetData(int.Parse(tbScanner.Text));
                    if (tblInfo != null && tblInfo.Count > 0)
                        _employeeID = code;
                    else
                        throw new Exception("Сотрудник не найден!");
                }
                // Сотрудник идентифицирован - попытка зарегистрировать его по документу
                using (Data.InventoryTableAdapters.IV_CS_HeaderTableAdapter adapter = new Data.InventoryTableAdapters.IV_CS_HeaderTableAdapter())
                    adapter.RegisterBadEmployee(this.DocID, (int?)null, this.EmployeeID);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbScanner.Focus();
                tbScanner.SelectAll();
                return false;
            }
        }
    }
}
