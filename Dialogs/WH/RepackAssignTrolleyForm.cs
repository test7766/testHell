using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackAssignTrolleyForm : Form
    {
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// Стол перепаковки
        /// </summary>
        public string LOCN { get; set; }

        /// <summary>
        /// Ш/К тележки
        /// </summary>
        public string TrolleyBarCode { get; private set; }

        public RepackAssignTrolleyForm()
        {
            InitializeComponent();
        }

        private void RepackCloseTrolleyForm_Load(object sender, EventArgs e)
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

        private void RepackCloseTrolleyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                e.Cancel = !AssignTrolley();
        }

        /// <summary>
        /// Регистрация на столе перепаковки
        /// </summary>
        /// <returns></returns>
        private bool AssignTrolley()
        {
            try
            {
                int? errorCode = null;
                string errorMessage = null;

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.RepackAssignTrolley(UserID, WarehouseID, LOCN, tbScanner.Text, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);

                this.TrolleyBarCode = tbScanner.Text;

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
