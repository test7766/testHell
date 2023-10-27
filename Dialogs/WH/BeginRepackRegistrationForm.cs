using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class BeginRepackRegistrationForm : Form
    {
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Стол перепаковки
        /// </summary>
        public string LOCN { get; private set; }

        /// <summary>
        /// Код станции
        /// </summary>
        public string StationID { get; private set; }

        public BeginRepackRegistrationForm()
        {
            InitializeComponent();
        }

        private void BeginRepackRegistrationForm_Load(object sender, EventArgs e)
        {
            tbScanner.TextChanged += new EventHandler(tbScanner_TextChanged);
        }

        void tbScanner_TextChanged(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BeginRepackRegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                e.Cancel = !Register();
        }

        /// <summary>
        /// Регистрация на столе перепаковки
        /// </summary>
        /// <returns></returns>
        private bool Register()
        {
            try
            {
                int? errorCode = null;
                string errorMessage = null;
                string locn = null;

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.BeginRepackRegistration(UserID, tbScanner.Text, ref locn, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);

                StationID = tbScanner.Text;
                LOCN = locn;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbScanner.Focus();
                tbScanner.SelectAll();
                return false;
            }
        } 
    }
}
