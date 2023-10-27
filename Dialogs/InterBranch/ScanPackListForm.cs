using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class ScanPackListForm : DialogForm
    {
        public ScanPackListForm()
        {
            InitializeComponent();
            base.ButtonOKEnabled = false;
        }

        public int UserID { get; set; }
        public string PackListBarcode { get { return tbScanner.Text; } }
        public string DocType { get; set; }

        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            // проверка правильности кода сборочного, можно ли его брать в работу этому сотруднику?
            using (Data.InterbranchTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.InterbranchTableAdapters.QueriesTableAdapter())
            {
                try
                {
                    adapter.CheckPackList(tbScanner.Text, UserID, DocType);
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
