using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class RkCloseDateEditorForm : DialogForm
    {
        /// <summary>
        /// Дата закрытия РК
        /// </summary>
        public DateTime RkCloseDate
        {
            get { return dtpRkCloseDate.Value; }
            set { dtpRkCloseDate.Value = value; }
        }

        public RkCloseDateEditorForm()
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
