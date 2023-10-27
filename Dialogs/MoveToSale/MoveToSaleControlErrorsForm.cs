using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.MoveToSale
{
    public partial class MoveToSaleControlErrorsForm : DialogForm
    {
        private readonly Data.MoveToSale.ControlErrorsDataTable _errors = null;

        private readonly string _LM_LocationID = null;

        private readonly long _docID;

        public MoveToSaleControlErrorsForm()
        {
            InitializeComponent();
        }

        public MoveToSaleControlErrorsForm(long pDocID, string pLM_LocationID, Data.MoveToSale.ControlErrorsDataTable pErrors)
            : this()
        {
            _docID = pDocID;
            _LM_LocationID = pLM_LocationID;
            _errors = pErrors;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(820, 8);
            this.btnCancel.Location = new Point(910, 8);

            controlErrorsBindingSource.DataSource = _errors;
        }

        private void MoveToSaleControlErrorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !FixErrors();
        }

        private bool FixErrors()
        {
            try
            {
                var departmentName = (string)null;

                using (var adapter = new Data.MoveToSaleTableAdapters.QueriesTableAdapter())
                    adapter.GetDepartmentName(_LM_LocationID, ref departmentName);

                var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Label = string.Format("Отсканируйте бэйдж ответственного сотрудника из отдела {0}", departmentName),
                    Text = "Контроль перемещения товара",
                    Image = Properties.Resources.role,
                    //OnlyNumbersInBarcode = true,
                    UseScanModeOnly = true
                };

                if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                    return false;

                var bossID = Convert.ToInt32(dlgBossScanner.Barcode);
                var result = (int?)null;

                using (var adapter = new Data.MoveToSaleTableAdapters.QueriesTableAdapter())
                    adapter.CanConfirmShortageTransfer(_LM_LocationID, bossID, ref result);

                bool canAccess = false;
                if (result.HasValue && Convert.ToBoolean(result.Value) == true)
                    canAccess = true;

                if (canAccess)
                {
                    // Автокоррекция расхождений
                    foreach (Data.MoveToSale.ControlErrorsRow error in _errors.Rows)
                    {
                        // Автокоррекция излишка не требуется
                        if (error.ErrorTypeCode.Trim() == "SP")
                            continue;

                        using (var adapter = new Data.MoveToSaleTableAdapters.QueriesTableAdapter())
                            adapter.ChangeRowProblemLocation(_docID, error.Item_ID, error.Lot_Number, _LM_LocationID);
                    }

                    return true;
                }
                else
                    throw new Exception("У данного сотрудника отсутствуют все необходимые права!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
