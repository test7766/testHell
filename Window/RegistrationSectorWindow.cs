using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Window
{
    public partial class RegistrationSectorWindow : GeneralWindow
    {
        public RegistrationSectorWindow()
        {
            InitializeComponent();
        }
        
        private void RegistrationSectorWindow_Load(object sender, EventArgs e)
        {
            // список секторов загружаем один раз
            this.sectorsTableAdapter.Fill(this.pickControl.Sectors, UserID);
            lbSectors.SelectedIndex = -1;
            lbSectors.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshRegistrations();
        }

        private void RefreshRegistrations()
        {
            this.Cursor = Cursors.WaitCursor;

            this.registrationsBindingSource.Sort = "";
            int employeeCategory = this.GetEmployeeCategory();
            int sectorID = (int)lbSectors.SelectedValue;
            this.registrationsTableAdapter.Fill(this.pickControl.Registrations, dateTimeFilter.Value, UserID, sectorID, employeeCategory);
            textBoxScaner.Focus();

            this.Cursor = Cursors.Default;
        }

        private void textBoxScaner_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxScaner.Text))
            {
                lbSectors.Focus();
            }
            else
                try
                {
                    int employee = 0;
                    if (!String.IsNullOrEmpty(textBoxScaner.Text) && int.TryParse(textBoxScaner.Text, out employee))
                    {
                        dateTimeFilter.Value = DateTime.Now;
                        int employeeCategory = this.GetEmployeeCategory();
                        this.registrationsTableAdapter.Insert((int)lbSectors.SelectedValue, employee, employeeCategory);
                        RefreshRegistrations();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            textBoxScaner.Text = "";
        }

        private void lbSectors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBoxScaner.Focus();
            }
        }

        private void lbSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSectors.SelectedValue == null)
                return;

            RefreshRegistrations();
        }

        private int GetEmployeeCategory()
        {
            if (rbPickers.Checked)
                return 0;

            if (rbStowers.Checked)
                return 1;

            return -1;
        }

        private void rbEmployeeCategory_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                RefreshRegistrations();
        }
    }
}
