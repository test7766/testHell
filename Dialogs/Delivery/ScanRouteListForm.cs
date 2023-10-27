using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class ScanRouteListForm : DialogForm
    {
        public ScanRouteListForm()
        {
            InitializeComponent();
            base.ButtonOKEnabled = false;
        }

        public int UserID { get; set; }
        public string RouteListBarcode { get { return tbScanner.Text; } }
        public string DocType { get; set; }

        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            // проверка правильности кода сборочного, можно ли его брать в работу этому сотруднику?
            using (Data.DeliveryTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.DeliveryTableAdapters.QueriesTableAdapter())
            {
                try
                {
                    // проверка. Если есть ошибки, будет сгенерирована исключительная ситуация с описанием
                    //if (DocType == "PC")
                    //    adapter.CheckPickSlip(tbScanner.Text, UserID, DocType);
                    //else if (DocType == "ET")
                    //    adapter.CheckEtic(tbScanner.Text, UserID);
                    //else if (DocType == "RE")
                    //    adapter.CheckReturn(tbScanner.Text, UserID);
                    //else
                        adapter.CheckRouteList(UserID, tbScanner.Text, DocType);
                    // если все хорошо, закрываем окно, возвращаем значение ШК сборочного
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbScanner.Focus();
                    tbScanner.SelectAll();
                    //DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
