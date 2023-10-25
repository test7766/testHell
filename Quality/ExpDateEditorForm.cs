using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ExpDateEditorForm : DialogForm
    {
        /// <summary>
        /// Срок годности
        /// </summary>
        public DateTime ExpDate
        {
            get { return dtExpDate.Value; }
            set { dtExpDate.Value = value; }
        }

        public ExpDateEditorForm()
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
