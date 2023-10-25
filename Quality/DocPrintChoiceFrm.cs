using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class DocPrintChoiceFrm : Form
    {
        public DocPrintChoiceFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Запрос
        /// </summary>
        public int? RequestCount { get { return checkBox1.Checked ? (int?)numericUpDown1.Value : null; } }

        /// <summary>
        /// Ведомость
        /// </summary>
        public int? StatementCount { get { return checkBox2.Checked ? (int?)numericUpDown2.Value : null; } }

        /// <summary>
        /// Сертификат
        /// </summary>
        public int? SertCount { get { return checkBox3.Checked ? (int?)numericUpDown3.Value : null; } }

        /// <summary>
        /// Оригинал сертификата
        /// </summary>
        public int? OrigSertCount { get { return checkBox4.Checked ? (int?)numericUpDown4.Value : null; } }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            numericUpDown1.DataBindings.Add("Enabled", checkBox1, "Checked");
            numericUpDown2.DataBindings.Add("Enabled", checkBox2, "Checked");
            numericUpDown3.DataBindings.Add("Enabled", checkBox3, "Checked");
            numericUpDown4.DataBindings.Add("Enabled", checkBox4, "Checked");
        }
    }
}
