using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Diagnostics;
using System.Transactions;
using System.Security.Principal;


namespace WMSOffice.Dialogs.Admin
{
    public partial class UpgradeControlAdminForm : Form
    {
        /// <summary>
        /// Имя пользователя вошедшего в систему
        /// </summary>
        private readonly string userName = WindowsIdentity.GetCurrent().Name;

        public UpgradeControlAdminForm()
        {
            InitializeComponent();
        }

        private void UpgradeControlAdminForm_Load(object sender, EventArgs e)
        { 
            try
            {
                this.upgradeVersionsTableAdapter.Fill(this.admin.UpgradeVersions);

                if (dgvVersions.Rows.Count > 0)
                {
                    var idxLastRow = dgvVersions.Rows.Count - 1;
                    dgvVersions.Rows[idxLastRow].Selected = true;
                    dgvVersions.FirstDisplayedScrollingRowIndex = idxLastRow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVersions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVersions.Rows[e.RowIndex].DataBoundItem == null)
                return;

            var version = (dgvVersions.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Admin.UpgradeVersionsRow;

            if (version.IsAllow_EditNull() || !version.Allow_Edit)
            {
                e.CellStyle.BackColor = Color.LightGray;
                e.CellStyle.SelectionForeColor = Color.LightGray;
            }
            else
            {
                e.CellStyle.BackColor = SystemColors.Window;
                e.CellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void dgvVersions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bool tryOpenVersionEditor = false;
            bool tryOpenDescriptionEditor = false;

            if ((tryOpenVersionEditor = (dgvVersions.Columns[dgvVersions.CurrentCell.ColumnIndex].DataPropertyName == admin.UpgradeVersions.Version_NumberColumn.Caption)) ||
               (tryOpenDescriptionEditor = (dgvVersions.Columns[dgvVersions.CurrentCell.ColumnIndex].DataPropertyName == admin.UpgradeVersions.Version_DescriptionColumn.Caption)))
            {
                if (!dgvVersions.CurrentCell.OwningRow.IsNewRow)
                {
                    var row = (dgvVersions.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.Admin.UpgradeVersionsRow;

                    switch (row.RowState)
                    {
                        case DataRowState.Modified:
                        case DataRowState.Unchanged:
                            if (tryOpenVersionEditor || (tryOpenDescriptionEditor && (row.IsAllow_EditNull() || !row.Allow_Edit)))
                            {
                                dgvVersions.EndEdit(DataGridViewDataErrorContexts.Commit);
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }

                if (e.Control is ButtonCellEditorControl)
                {
                    var editor = e.Control as ButtonCellEditorControl;
                    editor.OnAction -= new EventHandler(editor_OnAction);
                    editor.OnAction += new EventHandler(editor_OnAction);
                }
            }
        }

        void editor_OnAction(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Application.StartupPath;
                ofd.DefaultExt = "exe";
                ofd.Filter = string.Format("EXE-файл {0}|{0}.{1}", Application.ProductName, ofd.DefaultExt);
                ofd.Title = "Выберите файл необходимой версии";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(ofd.FileName);
                    var version = versionInfo.ProductVersion;

                    if (CheckVersion(version))
                    {
                        (dgvVersions.EditingControl as ButtonCellEditorControl).Value = version;
                        dgvVersions.EndEdit(DataGridViewDataErrorContexts.Commit);

                        dgvVersions.CurrentCell = dgvVersions.CurrentRow.Cells[versionDescriptionDataGridViewTextBoxColumn.Name];
                        dgvVersions.BeginEdit(true);
                    }
                }
            }
        }

        /// <summary>
        /// Проверка загружаемой версии на корректность
        /// </summary>
        /// <param name="version">Загружаемая версия</param>
        /// <returns></returns>
        private bool CheckVersion(string version)
        {
            try
            {
                var checkedVersionInfo = new Version(version);
                
                foreach (DataGridViewRow row in dgvVersions.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    if (row == dgvVersions.CurrentCell.OwningRow)
                        continue;

                    var versionRow = (row.DataBoundItem as DataRowView).Row as Data.Admin.UpgradeVersionsRow;

                    if (versionRow.Version_Number.Trim() == version.Trim())
                        throw new Exception(string.Format("Загружаемая версия {0} исполняемого файла\r\nприложения {1} уже зарегистрирована в системе.", version, Application.ProductName));

                    var currentVersionInfo = new Version(versionRow.Version_Number);
                    if (checkedVersionInfo < currentVersionInfo)
                        throw new Exception(string.Format("Загружаемая версия {0} исполняемого файла\r\nприложения {1} не может быть ниже зарегистрируемых.", version, Application.ProductName));
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvVersions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dgvVersions.Columns[versionNumberDataGridViewTextBoxColumn.Name].Index ||
               e.ColumnIndex == dgvVersions.Columns[versionDescriptionDataGridViewTextBoxColumn.Name].Index)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) == context)
                    {
                        if (e.Exception.GetType() == typeof(NoNullAllowedException))
                        {
                            MessageBox.Show(string.Format("Ни одно из полей \"{0}\", \"{1}\" не должно быть пустым.", 
                                dgvVersions.Columns[versionNumberDataGridViewTextBoxColumn.Name].HeaderText, 
                                dgvVersions.Columns[versionDescriptionDataGridViewTextBoxColumn.Name].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void UpgradeControlAdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                e.Cancel = !SaveChanges();
        }

        private bool SaveChanges()
        {
            var tranOptions = new TransactionOptions();
            tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            using (var scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
            {
                try
                {
                    foreach (Data.Admin.UpgradeVersionsRow row in admin.UpgradeVersions.Rows)
                    {
                        var versionID = row.IsVersion_IDNull() ? (int?)null : row.Version_ID;
                        var versionNumber = row.Version_Number.Substring(0, Math.Min(row.Version_Number.Length, 50));
                        var versionDescription = row.Version_Description.Substring(0, Math.Min(row.Version_Description.Length, 255));
                        var userUpdated = userName;
                        var dateUpdated = DateTime.Now;

                        switch (row.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                this.upgradeVersionsTableAdapter.EditUpgradeVersion(versionID, versionNumber, versionDescription, userUpdated, dateUpdated);
                                break;
                            default:
                                break;
                        }
                    }

                    admin.UpgradeVersions.AcceptChanges();
                    scope.Complete();
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
}
