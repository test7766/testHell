using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsAccountingControlCloseActsForm : Form
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }
        /// <summary>
        /// Отсканированный ш/к акта
        /// </summary>
        private string BarCode { get { return this.tbsScanActs.Text; } }
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsAccountingControlCloseActsForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.tbsScanActs.Focus();
            this.tbsScanActs.TextChanged += delegate(object sender, EventArgs ea) { this.CloseAct(); };
        }

        /// <summary>
        /// Прием актов
        /// </summary>
        private void CloseAct()
        {
            try
            {
                lblcloseActInfo.Text = string.Empty;

                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.ClosePalletsAct(this.UserID, this.BarCode);

                // Отображаем информацию о приеме акта
                lblcloseActInfo.Text = string.Format("Акт №{0} был принят.", Convert.ToInt32(this.BarCode.Replace("PAWMS", string.Empty)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.tbsScanActs.Text = string.Empty;
        }
    }
}
