using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryCheckDetailDialog : Form
    {
        public InventoryCheckDetailDialog()
        {
            InitializeComponent();
        }

        private object _dateSource;
        public object DataSource
        {
            get { return _dateSource; }
            set
            {
                if (_dateSource == value)
                    return;
                _dateSource = value;

                dgView.DataSource = _dateSource;
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog() { Filter = "Файл Excel|*.csv", FileName = Text, DefaultExt = "csv" })
                if (dlg.ShowDialog() == DialogResult.OK)
                    ExportToExcel(dlg.FileName);
        }

        public void ExportToExcel(string fileName)
        {
            try
            {
                using (var sw = new StreamWriter(fileName, false, Encoding.Default))
                {

                    string listSeparator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                    foreach (DataGridViewColumn column in dgView.Columns)
                    {
                        sw.Write(String.Format("\"{0}\"", column.HeaderText));
                        if (column.Index == dgView.ColumnCount - 1)
                            continue;
                        sw.Write(listSeparator);
                    }

                    sw.Write(sw.NewLine);

                    foreach (DataGridViewRow row in dgView.Rows)
                    {
                        foreach (DataGridViewColumn column in dgView.Columns)
                        {
                            if (!Convert.IsDBNull(row.Cells[column.Index].Value) && !string.IsNullOrEmpty(row.Cells[column.Index].Value.ToString()))
                                sw.Write(String.Format("\"{0}\"", row.Cells[column.Index].Value.ToString().Trim()));
                            else
                                sw.Write("\" \"");
                            if (column.Index == dgView.ColumnCount - 1)
                                continue;
                            sw.Write(listSeparator);
                        }

                        sw.Write(sw.NewLine);
                    }
                    sw.Flush();
                    sw.Close();
                }

                if (MessageBox.Show("Экспорт завершен.\n\rОткрыть созданный файл?",
                        "Экспорт",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information) == DialogResult.Yes)
                    Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                e.Value = Convert.ChangeType(e.Value.ToString().Trim(), e.Value.GetType());
            }
            catch (Exception) { }
        }
    }
}
