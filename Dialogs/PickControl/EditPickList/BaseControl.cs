using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    public partial class BaseControl : UserControl
    {
        public BaseControl()
        {
            InitializeComponent();
        }

        public virtual void RefreshForm() { }

        public delegate void ValueChangedEventHandler(string field, object value);

        public event ValueChangedEventHandler ValueChanged;

        protected void OnValueChanged(string field, object value)
        {
            ValueChangedEventHandler handler = ValueChanged;
            if (handler != null) handler(field, value);
        }
    }
}
