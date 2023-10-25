using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;
using WMSOffice.Dialogs;

namespace WMSOffice.Window
{
    public partial class AWStructureManagementImportFromExcellWindow : DialogForm
    {
        public AWStructureManagementImportFromExcellWindow()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.box1;
            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            GetWarehouses();
        }

        private void AWStructureManagementImportFromExcellWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pickControl.AW_Warehouses' table. You can move, or remove it, as needed.
            this.aW_WarehousesTableAdapter.Fill(this.pickControl.AW_Warehouses);
        }

        private void GetWarehouses()
        {
            aW_WarehousesTableAdapter.Fill(pickControl.AW_Warehouses);
        }
        private void OpenFile(DataGridView dataGrid)
        {
            string filePath = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Файл excel(*.xls; *.xlsx)|*.xls; *.xlsx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
                else { return; }
            }
            DataTable dt = dt = ((dataGrid.DataSource as BindingSource).DataSource as WMSOffice.Data.PickControl).AW_Places_Stations_Links_Import;
            DataTable dt2 = ExcelHelper.ExcelToDataTableConverter(filePath);
            ExportDtToDataSourceSource(dt2, dt);
            dt2.Dispose();
        }
        private void ExportDtToDataSourceSource(DataTable fromDt, DataTable toDt)
        {
            string s = null;
            for (int i = 0; i < fromDt.Rows.Count; i++)
            {
                try
                {
                    toDt.ImportRow(fromDt.Rows[i]);
                }
                catch (Exception ex)
                {
                    s += ex.Message + Environment.NewLine;
                }
            }
            if (s != null)
            {
                MessageBox.Show(s);
            }
          
            fromDt.Dispose();
        }
        private DataTable GetPastedData()
        {
            DataTable dt2 = new DataTable();
            DataObject o = (DataObject)Clipboard.GetDataObject();
            DataTable dt = ((dataGridView1.DataSource as BindingSource).DataSource as WMSOffice.Data.PickControl).AW_Places_Stations_Links_Import;
            if (o.GetDataPresent(DataFormats.Text))
            {
                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                int j = 0;
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                    if (!columnsAdded)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                            dt2.Columns.Add(dt.Columns[i].ColumnName);
                        columnsAdded = true;
                        continue;
                    }
                    dt2.Rows.Add();
                    int myRowIndex = dt2.Rows.Count - 1;
                    DataRow myDataGridViewRow;

                    for (int i = 0; i < pastedRowCells.Length; i++)
                    {
                        myDataGridViewRow = dt2.Rows[j];
                        myDataGridViewRow[i] = pastedRowCells[i];
                    }
                    j++;
                }
            }
            return dt2;
        }

        private void OpenExcelFileButton_Click(object sender, EventArgs e)
        {
            OpenFile(dataGridView1);
        }

        private void ClearTableButton_Click(object sender, EventArgs e)
        {
            DataTable dt = ((dataGridView1.DataSource as BindingSource).DataSource as WMSOffice.Data.PickControl).AW_Places_Stations_Links_Import;
            dt.Rows.Clear();
        }

        private void CopyPasteButton_Click(object sender, EventArgs e)
        {
            DataTable pastedTable = GetPastedData();
            DataTable dt = ((dataGridView1.DataSource as BindingSource).DataSource as WMSOffice.Data.PickControl).AW_Places_Stations_Links_Import;
            ExportDtToDataSourceSource(pastedTable, dt);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Применено!");
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;
            int newWidth;
            foreach (DataRowView s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s.Row[senderComboBox.DisplayMember].ToString(), font).Width + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            DataRowView s = senderComboBox.SelectedValue as DataRowView;
            int selecteditemWidth = s != null ? (int)g.MeasureString(s.Row[senderComboBox.DisplayMember].ToString(), font).Width : 0;
            senderComboBox.Width = selecteditemWidth > 0 ? selecteditemWidth + 16 : senderComboBox.Width;
        }

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxDelete_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    public static class ExcelHelper
    {
        public static IWorkbook CreateWorkBook(string filePath)
        {
            return CreateWorkBook(filePath, File.OpenRead(filePath));
        }

        public static IWorkbook CreateWorkBook(string filePath, Stream stream)
        {
            if (filePath.ToUpper().EndsWith(".XLSX"))
                return new XSSFWorkbook(stream);
            else if (filePath.ToUpper().EndsWith(".XLS"))
                return new HSSFWorkbook(stream);
            else
                return null;
        }

        public static string GetCellAddress(int idxRow, int idxColumn)
        {
            return string.Format("{0}{1}", CellReference.ConvertNumToColString(idxColumn), idxRow + 1);
        }

        public static object GetValue(ISheet workSheet, int idxRow, int idxCell)
        {
            var row = workSheet.GetRow(idxRow);
            return GetValue(row, idxCell);
        }

        public static object GetValue(IRow row, int idxCell)
        {
            if (row != null)
            {
                var cell = row.GetCell(idxCell);
                return GetValue(cell);
            }
            return null;
        }

        public static object GetValue(ICell cell)
        {
            if (cell != null)
            {
                object value = null;
                switch (cell.CellType)
                {
                    case CellType.Numeric:
                        if (DateUtil.IsCellDateFormatted(cell))
                            value = cell.DateCellValue;
                        else
                            value = cell.NumericCellValue;
                        break;
                    case CellType.String:
                        value = cell.StringCellValue;
                        break;
                    default:
                        break;
                }
                return value;
            }
            return null;
        }

        public static DataTable ExcelToDataTableConverter(string fileName)
        {
            DataTable table = new DataTable();
            IWorkbook workBook;

            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                workBook = ExcelHelper.CreateWorkBook(fileName, file);
            }

            ISheet sheet = workBook.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int rowCount = sheet.LastRowNum + 1;
            for (int i = (sheet.FirstRowNum); i < rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        dataRow[j] = GetValue(row.GetCell(j));
                    }
                    else
                        dataRow[j] = DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            workBook = null;
            sheet = null;
            table.Rows.RemoveAt(0);
            return table;
        }

        public static void CopyPasteFromExcel(DataGridView dataGrid)
        {
            ExcelHelper.ClearTable(dataGrid);
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                int j = 0;
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGrid.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dataGrid.Rows.Add();
                    int myRowIndex = dataGrid.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dataGrid.Rows[j])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
                    }
                    j++;
                }
            }
        }

        [Obsolete]
        public static void ClearTable(DataGridView dataGrid)
        {
            dataGrid.DataSource = null;
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
        }

    }
}
