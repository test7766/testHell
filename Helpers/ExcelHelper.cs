using System;
using System.Collections.Generic;
using System.Text;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WMSOffice.Helpers
{
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
                        dataRow[j] = row.GetCell(j).ToString();
                    }
                }
                table.Rows.Add(dataRow);
            }
            workBook = null;
            sheet = null;
            table.Rows.RemoveAt(0);
            return table;
        }

        public static void ClearTable(DataGridView dataGrid)
        {
            dataGrid.DataSource = null;
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
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

        public static DataTable GetPastedData(DataGridView dtSource)
        {
            DataTable dt2 = new DataTable();
            DataObject o = (DataObject)Clipboard.GetDataObject();
            DataTable dt = ((dtSource.DataSource as BindingSource).DataSource as WMSOffice.Data.PickControl).AW_Places_Stations_Links_Import;
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

        public static void ExportDtToDataSource(DataTable fromDt, DataTable toDt)
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
        public static void OpenFile(DataTable dt)
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
            DataTable dt2 = ExcelHelper.ExcelToDataTableConverter(filePath);
            ExcelHelper.ExportDtToDataSource(dt2, dt);
            dt2.Dispose();
        }
    }
}
