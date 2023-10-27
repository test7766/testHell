using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class ScanEmployeeForm : DialogForm
    {
        /// <summary>
        /// Установка режима непосредственного сканирования
        /// </summary>
        public bool UseScanModeOnly
        {
            get { return tbScanner.UseScanModeOnly; }
            set { tbScanner.UseScanModeOnly = value; }
        }

        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        public ScanEmployeeForm()
        {
            InitializeComponent();
            base.ButtonOKEnabled = false;
        }

        //public int UserID { get; set; }
        //public string PickSlipBarcode { get { return tbScanner.Text; } }
        //public string DocType { get; set; }

        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            // проверка правильности кода сборочного, можно ли его брать в работу этому сотруднику?
            using (Data.AccessTableAdapters.UserInfoTableAdapter adapter = new WMSOffice.Data.AccessTableAdapters.UserInfoTableAdapter())
            {
                try
                {
                    int code = 0;
                    if (!int.TryParse(tbScanner.Text, out code))
                        throw new ArgumentException("Неправильный формат штрих-кода!");

                    Data.Access.UserInfoDataTable tblInfo = adapter.GetData(int.Parse(tbScanner.Text));
                    if (tblInfo != null && tblInfo.Count > 0)
                    {
                        var employee = tblInfo[0];

                        _employeeID = code;
                        this.EmployeeName = employee.IsUserNameNull() ? (string)null : employee.UserName;

                        // если все хорошо, закрываем окно, возвращаем значение ШК сборочного
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else throw new ArgumentNullException("Сотрудник не найден!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbScanner.Focus();
                    tbScanner.SelectAll();
                }
            }
        }

        private int _employeeID = 0;
        public int EmployeeID
        {
            get { return _employeeID; }
        }

        public string EmployeeName { get; private set; }
    }
}
