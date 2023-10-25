using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Classes.ColdChain.Utils;
using System.IO;

namespace WMSOffice.Classes.ColdChain.FileProviders
{
    [FileProviderUsage(".OPH")]
    public class FileProviderOPH : FileProviderBase
    {
        private const char fileDataSeparator = '\t';

        public override bool PopulateBuffer(string filePath, out Buffer buffer)
        {
            try
            {
                buffer = null;

                if (!File.Exists(filePath))
                    throw new Exception("По указанному пути файл не найден.");

                using (StreamReader srLoggerDataReader = new StreamReader(filePath))
                {
                    if (!srLoggerDataReader.EndOfStream)
                    {
                        buffer = new Buffer();
                        while (!srLoggerDataReader.EndOfStream)
                        {
                            var cells = srLoggerDataReader.ReadLine().Split(new char[] { fileDataSeparator }, StringSplitOptions.RemoveEmptyEntries);
                            if (cells.Length > 0)
                                buffer.Rows.Add(new BufferRow(cells));
                        }

                        srLoggerDataReader.Close();
                    }
                    else
                        throw new Exception("Файл не содержит записей.");
                }

                return buffer != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
