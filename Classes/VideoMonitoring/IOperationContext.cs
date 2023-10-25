using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Classes.VideoMonitoring
{
    public interface IOperationContext
    {
        object OperationID { get; }

        string OperationName { get; }

        int UserID { get; }

        string IP { get; }

        int Port { get; }

        List<IItem> Items { get; }

        void LoadItems();

        List<Event> Events { get; }

        void LoadEvents();
    }
}
