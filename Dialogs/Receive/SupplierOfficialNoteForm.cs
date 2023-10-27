using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class SupplierOfficialNoteForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Код сессии
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Ид-р поставки
        /// </summary>
        public int ShipmentID { get; set; }

        /// <summary>
        /// № служебной записки
        /// </summary>
        public string OfficialNoteNumber { get { return this.tbOfficialNoteNumber.Text; } }
        #endregion

        public SupplierOfficialNoteForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.tbOfficialNoteNumber.Focus();
        }

        private void SupplierOfficialNoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.PalletsForSecureAccountingTableAdapter())
                    adapter.SetServiceNoteNumber(this.UserID, this.ShipmentID, this.OfficialNoteNumber);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
