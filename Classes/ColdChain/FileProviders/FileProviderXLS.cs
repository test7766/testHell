using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Classes.ColdChain.Utils;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace WMSOffice.Classes.ColdChain.FileProviders
{
    [FileProviderUsage(".XLSX", ".XLS")]
    public class FileProviderXLS : FileProviderBase
    {
        public override bool PopulateBuffer(string filePath, out Buffer buffer)
        {
            try
            {
                buffer = null;

                if (!File.Exists(filePath))
                    throw new Exception("По указанному пути файл не найден.");

                var workBook = CreateWorkBook(filePath);
                var workSheet = workBook.GetSheetAt(0);

                if (workSheet != null)
                {
                    if (workSheet.LastRowNum > 0 || workSheet.GetRow(0) != null)
                    {
                        buffer = new Buffer();
                        for (int idxRow = 0; idxRow <= workSheet.LastRowNum; idxRow++)
                        {
                            var row = workSheet.GetRow(idxRow);
                            if (row != null)
                            {
                                var bufferRow = new BufferRow();

                                for (var idxCell = 0; idxCell <= row.LastCellNum; idxCell++)
                                {
                                    var cell = row.GetCell(idxCell);
                                    if (cell != null)
                                    {
                                        object value = null;
                                        switch (cell.CellType)
                                        {
                                            case NPOI.SS.UserModel.CellType.Numeric:
                                                value = cell.NumericCellValue;
                                                break;
                                            case NPOI.SS.UserModel.CellType.String:
                                                value = cell.StringCellValue;
                                                break;
                                            default:
                                                break;
                                        }

                                        bufferRow.Cells.Add(new BufferCell(value));
                                    }
                                }

                                buffer.Rows.Add(bufferRow);
                            }
                        }
                    }
                    else
                        throw new Exception("Страница Excel не содержит записей.");
                }
                else
                    throw new Exception("Книга Excel не содержит страниц.");

                return buffer != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IWorkbook CreateWorkBook(string filePath)
        {
            if (filePath.ToUpper().Contains(".XLSX"))
                return new XSSFWorkbook(File.OpenRead(filePath));
            else if (filePath.ToUpper().Contains(".XLS"))
                return new HSSFWorkbook(File.OpenRead(filePath));
            else
                return null;
        }
    }

}
