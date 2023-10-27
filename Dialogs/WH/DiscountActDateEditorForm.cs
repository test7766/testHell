using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class DiscountActDateEditorForm : DialogForm
    {
        /// <summary>
        /// Дата акта
        /// </summary>
        public DateTime ActDate
        {
            get { return dtActDate.Value; }
            set { dtActDate.Value = value; }
        }

        public DiscountActDateEditorForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(50, 8);
            btnCancel.Location = new Point(140, 8);
        }
    }
}
