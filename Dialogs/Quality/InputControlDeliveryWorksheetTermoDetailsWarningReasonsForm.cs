using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class InputControlDeliveryWorksheetTermoDetailsWarningReasonsForm : DialogForm
    {
        private const int USER_INPUT_NOTE_REASON_ID = 2;

        public int ReasonID { get; set; }
        public string ReasonName { get; set; }
        public string Note { get; set; }

        public InputControlDeliveryWorksheetTermoDetailsWarningReasonsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(173, 8);
            this.btnCancel.Location = new Point(263, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            try
            {
                aP_Temperature_ReasonsTableAdapter.Fill(quality.AP_Temperature_Reasons, this.UserID, (string)null); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InputControlDeliveryWorksheetTermoDetailsWarningReasonsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (cmbReasons.SelectedValue == null)
                    throw new Exception("Не обрано причину.");

                var reason = (cmbReasons.SelectedItem as DataRowView).Row as Data.Quality.AP_Temperature_ReasonsRow;
                
                if (reason.ID == USER_INPUT_NOTE_REASON_ID && string.IsNullOrEmpty(tbNote.Text))
                    throw new Exception("Не вказано коментар.");

                this.ReasonID = reason.ID;
                this.ReasonName = reason.IsTemperatureReasonsNull() ? string.Empty : reason.TemperatureReasons;
                
                this.Note = tbNote.Text;
                //this.Note = reason.ID == USER_INPUT_NOTE_REASON_ID ? tbNote.Text : (string)null;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void cmbReasons_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReasons.SelectedValue == null)
                return;

            var reason = (cmbReasons.SelectedItem as DataRowView).Row as Data.Quality.AP_Temperature_ReasonsRow;

            tbNote.Text = reason.IsTemperatureReasonsDescNull() ? string.Empty : reason.TemperatureReasonsDesc;

            if (reason.ID == USER_INPUT_NOTE_REASON_ID)
            {
                tbNote.ReadOnly = false;
                tbNote.BackColor = SystemColors.Window;
                tbNote.Focus();
            }
            else
            {
                tbNote.ReadOnly = true;
                tbNote.BackColor = SystemColors.Window;
            }
        }
    }
}
