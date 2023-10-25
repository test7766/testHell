using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Classes.VideoMonitoring
{
    public interface IItem
    {
        object ID { get; }
        string Name { get; }
    }
}
