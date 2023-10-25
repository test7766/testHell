using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Inventory;

namespace WMSOffice.Window
{
    /// <summary>
    /// Диалог для отображения списка инвентаризаций и действий с ними (создание новой, завершение старой, печать ведомостей)
    /// </summary>
    public partial class InventoryListWindow : GeneralWindow
    {
        /// <summary>
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        public InventoryListWindow()
        {
            InitializeComponent();

            btnRefresh_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Обновляет список инвентаризаций
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                iN_DocsTableAdapter.Fill(inventory.IN_Docs);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Открывает диалог для просмотра и управления списком счетных листов инвентаризации
        /// </summary>
        private void dgvInventories_DoubleClick(object sender, EventArgs e)
        {
            btnShowCountSheets_Click(sender, e);
        }

        /// <summary>
        /// Открывает диалог для просмотра и управления списком счетных листов инвентаризации
        /// </summary>
        private void btnShowCountSheets_Click(object sender, EventArgs e)
        {
            if (dgvInventories.SelectedRows.Count == 1)
            {
                var docID = dgvInventories.SelectedRows[0].Cells[docIDDataGridViewTextBoxColumn.Name].Value;
                using (CountSheetsByInventoryForm form = new CountSheetsByInventoryForm(UserID, (long)docID))
                {
                    form.ShowDialog();
                    btnRefresh_Click(this, EventArgs.Empty);
                }
            }
        }
    }
}
