using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsChangeVendorReturnFlagForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ
        /// <summary>
        /// Признак создания данных
        /// </summary>
        public bool CreateData { get; set; }

        /// <summary>
        /// Признак удаления данных (добавление записи в архив)
        /// </summary>
        public bool DeleteData { get; set; }

        /// <summary>
        /// Признак активности
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Код поставщика
        /// </summary>
        public int? VendorID { get; private set; }
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsChangeVendorReturnFlagForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="vendorID"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="agreeNum"></param>
        /// <param name="agreeSubNum"></param>
        public void Initialize(int vendorID, DateTime dateFrom, DateTime dateTo, string agreeNum, string agreeSubNum, bool writeOffMode, bool isActive)
        {
            this.VendorID = vendorID;
            this.dtpFrom.Value = dateFrom;
            this.dtpTo.Value = dateTo;
            this.tbAgreeNum.Text = agreeNum;
            this.tbAgreeSubNum.Text = agreeSubNum;
            this.cbWriteOff.Checked = writeOffMode;
            this.IsActive = isActive;
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(320, 8);
            this.btnCancel.Location = new Point(410, 8);

            this.LoadVendors();

            if (!this.CreateData)
            {
                //this.pnlHeader.Enabled = false;

                cmbVendors.Enabled = false;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                tbAgreeNum.ReadOnly = true;
                tbAgreeSubNum.ReadOnly = true;
                cbWriteOff.Enabled = false;

                this.NavigateToSelectedVendor();
            }
        }

        /// <summary>
        /// Навигация к выбранному поставщику
        /// </summary>
        private void NavigateToSelectedVendor()
        {
            if (this.VendorID.HasValue)
                this.cmbVendors.SelectedValue = this.VendorID.Value;
        }

        /// <summary>
        /// Получение списка поставщиков
        /// </summary>
        private void LoadVendors()
        {
            try
            {
                this.vendorsForChangeReturnFlagTableAdapter.Fill(this.receive.VendorsForChangeReturnFlag, this.UserID, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PalletsChangeVendorReturnFlagForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.VendorID = Convert.ToInt32(this.cmbVendors.SelectedValue);
            
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <returns></returns>
        public bool SaveData()
        {
            try
            {
                if (!this.DeleteData && cmbVendors.SelectedValue == null)
                    throw new Exception("Поставщик не выбран.");

                // Валидация диапазона дат
                if (this.dtpFrom.Value > this.dtpTo.Value)
                    throw new Exception("Начальный период не должен превышать конечный!");

                this.vendorsForChangeReturnFlagTableAdapter.ChangeReturnFlagForVendor
                   (this.UserID, 
                    this.VendorID, 
                    this.dtpFrom.Value.Date, 
                    this.dtpTo.Value, 
                    this.tbAgreeNum.Text, 
                    this.tbAgreeSubNum.Text, 
                    this.IsActive,
                    cbWriteOff.Checked);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
