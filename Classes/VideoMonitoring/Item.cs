using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Classes.VideoMonitoring
{
    public class Item : IItem
    {

        #region IItem Members

        public object ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        #endregion
    }
}
