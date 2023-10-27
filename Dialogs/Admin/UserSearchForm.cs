using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.DirectoryServices;
using WMSOffice.Admin.Database;
using WMSOffice.Data;
using WMSOffice.Data.AdminTableAdapters;

namespace WMSOffice.Dialogs.Admin
{
    public partial class UserSearchForm : Form
    {        

        public UserSearchForm(/*SearchResultCollection results,*/ string searchText)
        {
            InitializeComponent();

            tbSearchText.Text = searchText;

            DomainName = (string)Database.Actions.DomenName();
        }

        #region Properties

        public string UserID { get; set; }

        public string UserLogin { get; set; } 

        public string UserFIO { get; set; }

        public string UserDepartment { get; set; }

        private string DomainName { get; set; }

        #endregion 


        #region EventHandlers

        private void b_choose_Click(object sender, EventArgs e)
        {
            UserID = (string)dgv_users.SelectedRows[0].Cells[0].Value;
            UserFIO = (string)dgv_users.SelectedRows[0].Cells[1].Value;
            UserLogin = (string)dgv_users.SelectedRows[0].Cells[2].Value;
            UserDepartment = (string)dgv_users.SelectedRows[0].Cells[3].Value;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void b_сlose_Click(object sender, EventArgs e)
        {
            UserID = UserFIO = UserLogin = UserDepartment = null;
            this.Close();
        }
    
        private void bSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearchText.Text) && tbSearchText.Text.Length > 3)
            {
                Cursor currentCursor = Cursor.Current;
                this.Cursor = Cursors.WaitCursor;

                DirectorySearcher searcher = new DirectorySearcher();
                searcher.Filter = "(&(objectCategory=user)(cn=*" + tbSearchText.Text + "*))";
                searcher.PropertiesToLoad.Add("physicaldeliveryofficename");
                searcher.PropertiesToLoad.Add("cn");
                searcher.PropertiesToLoad.Add("samaccountname");
                searcher.PropertiesToLoad.Add("department");
                searcher.PropertiesToLoad.Add("title");
                searcher.PropertiesToLoad.Add("mail");
                searcher.PropertiesToLoad.Add("msexchhidefromaddresslists");

                DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");

                SearchResultCollection results = searcher.FindAll();

                dgv_users.Rows.Clear();

                foreach (SearchResult result in results)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgv_users);

                    int isUserOk = 0, id;

                    foreach (string PropertyName in result.Properties.PropertyNames)
                    {                        
                        foreach (Object key in result.GetDirectoryEntry().Properties[PropertyName])
                        {
                            try
                            {
                                switch (PropertyName.ToUpper())
                                {
                                    case "PHYSICALDELIVERYOFFICENAME":
                                        if (!int.TryParse(key.ToString(), out id))
                                        {
                                            isUserOk = -1;
                                            break;
                                        }
                                        row.Cells[0].Value = key.ToString();
                                        isUserOk = 1;
                                        break;
                                    case "CN":
                                        row.Cells[1].Value = key.ToString();
                                        break;
                                    case "SAMACCOUNTNAME":
                                        row.Cells[2].Value = DomainName + "\\" + key.ToString();
                                        break;
                                    case "DEPARTMENT":
                                        row.Cells[3].Value = key.ToString();
                                        break;
                                    case "TITLE":
                                        row.Cells[4].Value = key.ToString();
                                        break;
                                    case "MAIL":
                                        row.Cells[5].Value = key.ToString();
                                        break;
                                    case "MSEXCHHIDEFROMADDRESSLISTS":
                                        if ((bool)key)
                                            isUserOk = -2;
                                        break;
                                }
                            }
                            catch /*(Exception ex)*/ { /*MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);*/ }                                                        
                        }
                        if (isUserOk < 0)
                            break;
                    }
                    if (isUserOk == 1)
                        dgv_users.Rows.Add(row);
                }
                this.Cursor = currentCursor;
            }
            else
                MessageBox.Show("Необходимо ввести не менее четырех символов!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        private void dgv_users_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            b_choose_Click(this, EventArgs.Empty);
        }

        private void tbSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                bSearch_Click(this, EventArgs.Empty);
        }

        #endregion


    }
}
