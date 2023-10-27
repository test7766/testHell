using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    /// <summary>
    /// Диалог для просмотра и редактирования списка виновных в проблеме (недостача, НТВ, бой) по определенной товарной строке при поштучном контроле.
    /// </summary>
    public partial class ReturnFaultsForm : Form
    {
        /// <summary>
        /// Идентификатор документа возврата.
        /// </summary>
        private long DocID { get; set; }

        /// <summary>
        /// Код товара.
        /// </summary>
        private int ItemID { get; set; }

        /// <summary>
        /// Серия товара.
        /// </summary>
        private string VendorLot { get; set; }

        /// <summary>
        /// Единицы измерения.
        /// </summary>
        private string UnitOfMeasure { get; set; }

        /// <summary>
        /// Список сотрудников.
        /// </summary>
        private Data.WH.DocStatusEmployeesDataTable DocStatusEmployees { get; set; }
        
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="docID">Идентификатор документа возврата.</param>
        /// <param name="itemID">Код товара.</param>
        /// <param name="vendorLot">Серия товара.</param>
        /// <param name="unitOfMeasure">Единицы измерения.</param>
        /// <param name="docStatusEmployees">Список сотрудников.</param>
        public ReturnFaultsForm(long docID, int itemID, string vendorLot, string unitOfMeasure, Data.WH.DocStatusEmployeesDataTable docStatusEmployees)
        {
            InitializeComponent();

            this.DocID = docID;
            this.ItemID = itemID;
            this.VendorLot = vendorLot;
            this.UnitOfMeasure = unitOfMeasure;
            this.DocStatusEmployees = docStatusEmployees;

            RefreshData();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Добавить виновного сотрудника".
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (Dialogs.PickControl.ReturnFaultEditForm form = new ReturnFaultEditForm(DocStatusEmployees, null, 0, 0, false, DocID))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        returnFaultsTableAdapter.AddUpdateRow(DocID, ItemID, VendorLot, UnitOfMeasure, form.FaultTypeID, form.FaultEmployeeID, form.Quantity);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("При добавлении виновного сотрудника возникла следующая ошибка:" + Environment.NewLine + ex.Message,
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            RefreshData();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Изменить выбранную строку".
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReturnFaults.SelectedRows.Count > 0)
            {
                Data.PickControl.ReturnFaultsRow selectedRow = (Data.PickControl.ReturnFaultsRow)((DataRowView)dgvReturnFaults.SelectedRows[0].DataBoundItem).Row;

                using (Dialogs.PickControl.ReturnFaultEditForm form = new ReturnFaultEditForm(DocStatusEmployees, selectedRow.Fault_Type_ID, selectedRow.Fault_Employee_ID, selectedRow.Quantity, true, DocID))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            returnFaultsTableAdapter.AddUpdateRow(DocID, ItemID, VendorLot, UnitOfMeasure, form.FaultTypeID, form.FaultEmployeeID, form.Quantity);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("При изменении выбранной строки возникла следующая ошибка:" + Environment.NewLine + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                RefreshData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Закрыть диалог".
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обновляет данные в таблице.
        /// </summary>
        private void RefreshData()
        {
            returnFaultsTableAdapter.Fill(pickControl.ReturnFaults, DocID, ItemID, VendorLot, UnitOfMeasure);
        }
    }
}
