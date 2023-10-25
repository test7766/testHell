using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Classes.ColdChain.Utils
{
    public class DeserializationCompleteEventArgs : EventArgs
    {
        public object Data { get; private set; }
        public DeserializationCompleteEventArgs(object data)
        {
            Data = data;
        }
    }
}
