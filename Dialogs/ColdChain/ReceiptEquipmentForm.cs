using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class ReceiptEquipmentForm : DialogForm
    {
        private bool autoCommit = false;

        public int ReceiptDocID { get; private set; }

        public string RouteListBarcode { get; set; }

        public ReceiptEquipmentForm()
        {
            InitializeComponent();
        }

        public ReceiptEquipmentForm(int receiptDocID)
            : this()
        {
            ReceiptDocID = receiptDocID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(620, 8);
            btnCancel.Location = new Point(710, 8);

            this.Text = string.Format("{0} (Ш/К МЛ: {1})", this.Text, this.RouteListBarcode);

            tbsEquipment.TextChanged += new EventHandler(tbsEquipment_TextChanged);
            ReloadEquipment();
        }

        void tbsEquipment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbsEquipment.Text))
                    return;

                var equipmentBarCode = tbsEquipment.Text;
                fullEquipmentByRouteListTableAdapter.CheckEquipment(equipmentBarCode, ReceiptDocID);

                ReloadEquipment();

                if (autoCommit = CheckEquipmentReceiptDone())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    tbsEquipment.Text = string.Empty;
                    tbsEquipment.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsEquipment.Text = string.Empty;
                tbsEquipment.Focus();
            }
        }

        private void ReloadEquipment()
        {
            try
            {
                fullEquipmentByRouteListBindingSource.DataSource = null;
                coldChain.FullEquipmentByRouteList.Clear();

                var equipment = fullEquipmentByRouteListTableAdapter.GetData(ReceiptDocID);

                coldChain.FullEquipmentByRouteList.Merge(equipment);
                fullEquipmentByRouteListBindingSource.DataSource = equipment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvEquipment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvEquipment.Rows)
            {
                var boundRow = (row.DataBoundItem as DataRowView).Row as Data.ColdChain.FullEquipmentByRouteListRow;
                var color = (boundRow.IsCOLORNull() || boundRow.COLOR.ToLower() == "white") ? Color.White : Color.FromName(boundRow.COLOR);

                for (int idxCell = 0; idxCell < row.Cells.Count; idxCell++)
                {
                    row.Cells[idxCell].Style.BackColor = color;
                    row.Cells[idxCell].Style.SelectionForeColor = color;
                }
            }
        }

        private void ReceiptEquipmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var equipmentReceiptCommit = false;
                var equipmentReceiptCancel = false;

                if (DialogResult == DialogResult.OK)
                {
                    var equipmentReceiptDone = autoCommit || CheckEquipmentReceiptDone();

                    if (equipmentReceiptDone)
                        equipmentReceiptCommit = true;
                    else
                    {
                        if (MessageBox.Show("Вы желаете подтвердить недостачу?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            equipmentReceiptCommit = true;
                        else
                            e.Cancel = true;
                    }
                }
                else
                    equipmentReceiptCancel = true;

                if (equipmentReceiptCommit)
                {
                    CommitEquipmentReceipt();
                    return;
                }

                if (equipmentReceiptCancel)
                {
                    CancelEquipmentReceipt();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsEquipment.Text = string.Empty;
                tbsEquipment.Focus();

                e.Cancel = true;
            }
        }

        private bool CheckEquipmentReceiptDone()
        {
            try
            {
                if (coldChain.FullEquipmentByRouteList.Rows.Count == 0)
                    throw new Exception("Отсутствует информация о закрепленном термооборудовании.");

                foreach (Data.ColdChain.FullEquipmentByRouteListRow row in coldChain.FullEquipmentByRouteList.Rows)
                    if (row.Код_статуса_строки != "120") // "120" - оборудование сдано
                        return false;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CommitEquipmentReceipt()
        {
            fullEquipmentByRouteListTableAdapter.CommitReceipt(ReceiptDocID);
        }

        private void CancelEquipmentReceipt()
        {
            fullEquipmentByRouteListTableAdapter.CancelReceipt(ReceiptDocID);
        }
    }
}
