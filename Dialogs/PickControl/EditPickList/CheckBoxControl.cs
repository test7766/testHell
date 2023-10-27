using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    public partial class CheckBoxControl : BaseControl
    {
        public CheckBoxControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Название "флага"
        /// </summary>
        public string SelectLabel
        {
            get { return chbSelect.Text; }
            set { chbSelect.Text = value; }
        }

        /// <summary>
        /// Признак установленного "флага"
        /// </summary>
        public bool IsSelected
        {
            get { return chbSelect.Checked; }
            set { chbSelect.Checked = value; }
        }

        /// <summary>
        /// Обработчик изменения значения "флага"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSelect_CheckedChanged(object sender, EventArgs e)
        {
            OnValueChanged("Select", IsSelected);
        }

    }
}
