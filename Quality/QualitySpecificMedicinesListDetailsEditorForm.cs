using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    [Obsolete("Редактор нац. перечня не используется в текущей версии")]
    public partial class QualitySpecificMedicinesListDetailsEditorForm : DialogForm
    {
        private readonly Data.Quality.NL_ListRow _doc = null;

        private bool docChanged = false;

        public QualitySpecificMedicinesListDetailsEditorForm()
        {
            InitializeComponent();
        }

        public QualitySpecificMedicinesListDetailsEditorForm(Data.Quality.NL_ListRow doc)
            : this()
        {
            if (doc == null)
            {
                var row = quality.NL_List.NewNL_ListRow();
                row.PerelikID = string.Empty;
                quality.NL_List.AddNL_ListRow(row);
            }
            else
            {
                quality.NL_List.LoadDataRow(doc.ItemArray, true);
            }

            _doc = quality.NL_List[0];
        }

        private void QualitySpecificMedicinesListDetailsEditorForm_Load(object sender, EventArgs e)
        {
            this.LoadDetails();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(642, 8);
            this.btnCancel.Location = new Point(732, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            if (_doc.RowState == DataRowState.Added)
            {
                var today = DateTime.Today;

                _doc.DateFrom = today;
                _doc.DateTo = today;

                _doc.GosRegFlag = true;
            }
            else
            {
                tbCode.ReadOnly = true;
                tbCode.BackColor = SystemColors.Info;
            }

            tbCode.TextChanged += (s, e) => { docChanged = true; };
            tbName.TextChanged += (s, e) => { docChanged = true; };
            dtpPeriodFrom.ValueChanged += (s, e) => { docChanged = true; dtpPeriodTo.Value = dtpPeriodFrom.Value; };
            dtpPeriodTo.ValueChanged += (s, e) => { docChanged = true; };
            cbGosReg.CheckStateChanged += (s, e) => { docChanged = true; };

            tbCode.Focus();
        }

        private void LoadDetails()
        {
            try
            {
                var perelikID = _doc.IsPerelikIDNull() ? (string)null : _doc.PerelikID;

                using (var adapter = new Data.QualityTableAdapters.NL_ListDetailsTableAdapter())
                     adapter.Fill(quality.NL_ListDetails, perelikID);

                if (dgvDetails.Rows.Count > 0)
                    dgvDetails.Rows[0].Selected = false;

                dgvDetails.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QualitySpecificMedicinesListDetailsEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var success = this.ModifyDoc();
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ModifyDoc()
        {
            try
            {
                if (_doc.IsPerelikIDNull() || string.IsNullOrEmpty(_doc.PerelikID))
                    throw new Exception("Код нац. перечня должен быть указан.");

                if (_doc.IsPerelikNameNull() || string.IsNullOrEmpty(_doc.PerelikName))
                    throw new Exception("Наименование нац. перечня должно быть указано.");

                var perelikID = _doc.PerelikID;
                var perelikName = _doc.PerelikName;
                var periodFrom = dtpPeriodFrom.Value.Date;
                var periodTo = dtpPeriodTo.Value.Date;
                var gosReg = cbGosReg.Checked;

                switch (_doc.RowState)
                {
                    case DataRowState.Added:
                        if (docChanged)
                        {
                            using (var adapter = new Data.QualityTableAdapters.NL_ListTableAdapter())
                                adapter.Add(perelikID, perelikName, periodFrom, periodTo, this.UserID, gosReg);
                        }
                        break;
                    case DataRowState.Modified:
                    default:
                        if (docChanged)
                        {
                            using (var adapter = new Data.QualityTableAdapters.NL_ListTableAdapter())
                                adapter.Edit(perelikID, perelikName, periodFrom, periodTo, this.UserID, gosReg);
                        }
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ModifyDocDetails()
        {
            try
            {
                foreach (Data.Quality.NL_ListDetailsRow row in quality.NL_ListDetails.Rows)
                {
                    var perelikID = (string)null;
                    var detailID = (int?)null;

                    var orderNumber = (string)null;
                    var orderDescription = (string)null;
                    var orderDateFrom = (DateTime?)null;

                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            perelikID = row.PerelikID;
                            detailID = -1;
                            orderDescription = row.Description;

                            using (var adapter = new Data.QualityTableAdapters.NL_ListDetailsTableAdapter())
                                adapter.Add(perelikID, orderDescription, orderDateFrom, orderNumber, this.UserID, ref detailID);
                            row.DetailID = detailID.Value;
                            break;
                        case DataRowState.Modified:
                            perelikID = row.PerelikID;
                            detailID = row.DetailID;
                            orderDescription = row.Description;

                            using (var adapter = new Data.QualityTableAdapters.NL_ListDetailsTableAdapter())
                                adapter.Edit(perelikID, detailID, orderDescription, orderDateFrom, orderNumber, this.UserID);
                            break;
                        case DataRowState.Deleted:
                            perelikID = (string)row[quality.NL_ListDetails.PerelikIDColumn, DataRowVersion.Original];
                            detailID = (int)row[quality.NL_ListDetails.DetailIDColumn, DataRowVersion.Original];

                            using (var adapter = new Data.QualityTableAdapters.NL_ListDetailsTableAdapter())
                                adapter.Remove(perelikID, detailID);
                            break;
                        default:
                            break;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvDetails_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[clPerelikID.Index].Value = _doc.PerelikID;
            e.Row.Cells[clDetailID.Index].Value = -1;
        }

        private void dgvDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetails.BeginEdit(false);
        }

        private void dgvDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить указанную позицию нац. перечня?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void dgvDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if (e.ColumnIndex == dgvDetails.Columns[clDescription.Name].Index)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) == context)
                    {
                        if (e.Exception.GetType() == typeof(NoNullAllowedException))
                        {
                            MessageBox.Show(string.Format("Поле \"{0}\" не должно быть пустым.", dgvDetails.Columns[clDescription.Name].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void dgvDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvDetails.Rows)
            {
                var cell = dgvr.Cells[clSelector.Index] as DataGridViewButtonCell;
                cell.Value = "...";
                cell.ToolTipText = "Привязка медикаментов";
                dgvr.Tag = "...";
            }
        }

        private void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clSelector.Index)
            {
                var drv = dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null)
                {
                    MessageBox.Show("Для продолжения внесите информацию\nв описание позиции нац. перечня.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var row = drv.Row as Data.Quality.NL_ListDetailsRow;
                var perelikID = row.PerelikID;
                var detailID = row.DetailID;

                if (detailID == -1)
                { 
                    // сохранить позицию
                }

                var dlgQualitySpecificMedicinesListItemsEditor = new QualitySpecificMedicinesListItemsEditorForm(perelikID, row) { UserID = this.UserID };
                dlgQualitySpecificMedicinesListItemsEditor.ShowDialog(this);
            }
        }

        private void dgvDetails_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetails.Columns[clDescription.Name].Index)
            { 
            
            }
        }
    }
}
