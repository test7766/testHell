using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Classes.ColdChain.Utils
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FileProviderUsageAttribute : Attribute
    {
        public IEnumerable<string> Extensions { get; private set; }

        public FileProviderUsageAttribute(params string[] pExtension)
        {
            Extensions = pExtension;
        }
    }
}
