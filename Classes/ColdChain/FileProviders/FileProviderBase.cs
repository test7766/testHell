using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Classes.ColdChain.FileProviders
{
    public abstract class FileProviderBase
    {
        public abstract bool PopulateBuffer(string filePath, out Buffer buffer);
    }
}
