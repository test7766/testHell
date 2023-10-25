using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;

namespace WMSOffice.Dialogs.Quality
{
    public partial class InputControlDeliveryWorksheetTermoDetailsEditForm : DialogForm
    {
        private readonly TermoDetailsPackage tmPackage = null;

        private readonly bool _readOnlyMode = false; 

        private readonly string dateCellCustomFormat = "dd.MM.yyyy HH:mm";

        private readonly bool _shippingAuthorizationMode;

        public InputControlDeliveryWorksheetTermoDetailsEditForm()
        {
            InitializeComponent();
        }

        public InputControlDeliveryWorksheetTermoDetailsEditForm(TermoDetailsPackage tm_package, bool readOnlyMode)
            : this()
        {
            tmPackage = tm_package;
            _readOnlyMode = readOnlyMode;
        }

        public InputControlDeliveryWorksheetTermoDetailsEditForm(TermoDetailsPackage tm_package, bool readOnlyMode, bool shippingAuthorizationMode)
            : this(tm_package, readOnlyMode)
        {
            _shippingAuthorizationMode = shippingAuthorizationMode;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(965, 8); // 565
            this.btnCancel.Location = new Point(1055, 8); // 655

            this.Text = string.Format("{0}, [{1}]", this.Text, tmPackage.TermoModeFlag);
            cbSensorsAreAbsent.Checked = tmPackage.SensorsAreAbsent;

            if (_readOnlyMode)
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";

                dgvItems.ReadOnly = true;
                dgvItems.AllowUserToAddRows = false;
                dgvItems.AllowUserToDeleteRows = false;

                clEquipmentType.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                cbSensorsAreAbsent.Enabled = false;
            }

            if (_shippingAuthorizationMode)
            {
                this.clT_Fact.HeaderText = "t отгрузки, °C";
                this.clT_Min.Visible = false;
                this.clT_Max.Visible = false;
            }
        }

        private void EditInputControlDeliveryWorksheetTermoDetailsForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            try
            {
                aP_Equipment_TypesTableAdapter.Fill(quality.AP_Equipment_Types, this.UserID, (string)null);

                var blankEquipmentTypesRow = quality.AP_Equipment_Types.NewAP_Equipment_TypesRow();
                blankEquipmentTypesRow.ID = 0;
                blankEquipmentTypesRow.TypeDesc = "(отсутствует)";
                quality.AP_Equipment_Types.Rows.InsertAt(blankEquipmentTypesRow, 0);

                // Подготовка источника показаний логгера
                quality.AP_Version_Termo_Detail.Merge(tmPackage.Cache);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить показания датчика?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void dgvItems_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[clTermo_mode.Index].Value = tmPackage.TermoModeFlag;
            e.Row.Cells[clDate.Index].Value = DateTime.Now;
            e.Row.Cells[clEquipmentType.Index].Value = 0;
        }

        private void cbSensorsAreAbsent_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSensorsAreAbsent.Checked)
            {
                if (dgvItems.Rows.Count > 0 && !dgvItems.Rows[0].IsNewRow)
                {
                    cbSensorsAreAbsent.Checked = false;
                    MessageBox.Show("Сперва удалите все температурные показания.", "Внимание",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    dgvItems.AllowUserToAddRows = false;
                    dgvItems.AllowUserToDeleteRows = false;
                }
            }
            else
            {
                dgvItems.AllowUserToAddRows = true;
                dgvItems.AllowUserToDeleteRows = true;
            }

            dgvItems.ReadOnly = cbSensorsAreAbsent.Checked;
        }

        private void dgvItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void EditInputControlDeliveryWorksheetTermoDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveCache();
        }

        private bool SaveCache()
        {
            try
            {
                if (!cbSensorsAreAbsent.Checked && dgvItems.Rows.Count == 1 && dgvItems.Rows[0].IsNewRow)
                    throw new Exception("Внесите температурные показания\nлибо активируйте признак \"Нет датчиков\".");

                // Проверка валидности заполнения показаний температурного режима
                var checkFlag = TermoDetailsPackage.CheckTermoDetails(cbSensorsAreAbsent.Checked, quality.AP_Version_Termo_Detail, tmPackage.MinTreshold, tmPackage.MaxTreshold);

                if (!checkFlag)
                {
                    //1. Для режимов 2-8, 8-15 вызываем подтверждение
                    if (tmPackage.TermoMode != TermoMode.TM1525)
                    {
                        if (MessageBox.Show("Показания некоторых датчиков выходят за пределы допустимого интервала. Вы подтверждаете внесенные данные?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            return false;
                    }
                    else
                    {
                        // 2. Для режима 15-25 вводим причину
                        var dlgInputControlDeliveryWorksheetTermoDetailsWarningReasons = new InputControlDeliveryWorksheetTermoDetailsWarningReasonsForm() { UserID = this.UserID };
                        if (dlgInputControlDeliveryWorksheetTermoDetailsWarningReasons.ShowDialog() != DialogResult.OK)
                            return false;

                        var reasonID = dlgInputControlDeliveryWorksheetTermoDetailsWarningReasons.ReasonID;
                        var reasonName = dlgInputControlDeliveryWorksheetTermoDetailsWarningReasons.ReasonName;
                        var note = dlgInputControlDeliveryWorksheetTermoDetailsWarningReasons.Note;

                        foreach (DataGridViewRow row in dgvItems.Rows)
                        {
                            if (row.DataBoundItem == null)
                                continue;

                            var item = (row.DataBoundItem as DataRowView).Row as Data.Quality.AP_Version_Termo_DetailRow;
                            var success = item.IsIsValidNull() ? true : item.IsValid;

                            if (success)
                            {
                                item.SetReasonIDNull();
                                item.SetNoteNull();
                            }
                            else
                            {
                                item.ReasonID = reasonID;
                                item.Note = note;
                            }
                        }

                        tmPackage.Reason.ReasonID = reasonID;
                        tmPackage.Reason.ReasonName = reasonName;
                        tmPackage.Reason.Note = note;
                    }
                }
                
                //if (!checkFlag && MessageBox.Show("Показания некоторых датчиков выходят за пределы допустимого интервала. Вы подтверждаете внесенные данные?", "Внимание",  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                //    return false;

                // Сохранение в кэш валидных данных
                tmPackage.SensorsAreAbsent = cbSensorsAreAbsent.Checked;

                tmPackage.Cache.Clear();
                tmPackage.Cache.Merge(quality.AP_Version_Termo_Detail);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvItems.BeginEdit(false);
        }

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewDatePickerEditingControl)
            {
                var editor = e.Control as DataGridViewDatePickerEditingControl;
                editor.ApplyCustomFormat(dateCellCustomFormat);
            }
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (dgvItems.Rows[e.RowIndex].DataBoundItem == null)
                return;

            var item = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.AP_Version_Termo_DetailRow;

            var success = item.IsIsValidNull() ? true : item.IsValid;

            Color color = success ? SystemColors.Window : Color.Khaki;

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;

            if (dgvItems.Columns[e.ColumnIndex] == clDate)
            {
                var dtpCell = dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewDatePickerCell;
                dtpCell.UseCustomFormat = true;
                dtpCell.Style.Format = e.CellStyle.Format = dateCellCustomFormat;
            }
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (dgvItems.Columns[e.ColumnIndex] == clT_Fact
                || dgvItems.Columns[e.ColumnIndex] == clT_Min
                || dgvItems.Columns[e.ColumnIndex] == clT_Max)
            { 
                var item = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.AP_Version_Termo_DetailRow;
                
                var success = TermoDetailsPackage.CheckTermoDetail(item, tmPackage.MinTreshold, tmPackage.MaxTreshold);

                item.IsValid = success;
                
                this.Invalidate();
            }
        }
    }

    public class TermoDetailsPackage
    {
        public bool SensorsAreAbsent { get; set; }

        public Data.Quality.AP_Version_Termo_DetailDataTable Cache { get; set; }

        public TermoMode TermoMode { get; set; }
        public string TermoModeFlag { get; set; }

        public decimal MinTreshold { get; set; }
        public decimal MaxTreshold { get; set; }

        public TermoDetailsPackageReason Reason { get; set; }

        public TermoDetailsPackage()
        {
            Cache = new WMSOffice.Data.Quality.AP_Version_Termo_DetailDataTable();
            Reason = new TermoDetailsPackageReason();
        }

        public static TermoDetailsPackage Create(TermoMode termoMode)
        {
            switch (termoMode)
            { 
                case TermoMode.TM28:
                    return new TermoDetailsPackage { TermoMode = termoMode, TermoModeFlag = "2-8", MinTreshold = 2.0M, MaxTreshold = 8.0M };
                case TermoMode.TM815:
                    return new TermoDetailsPackage { TermoMode = termoMode, TermoModeFlag = "8-15", MinTreshold = 8.0M, MaxTreshold = 15.0M };
                case TermoMode.TM1525:
                    return new TermoDetailsPackage { TermoMode = termoMode, TermoModeFlag = "15-25", MinTreshold = 15.0M, MaxTreshold = 25.0M };
                default:
                    return null;
            }
        }

        public bool CheckTermoDetails()
        {
            return TermoDetailsPackage.CheckTermoDetails(this.SensorsAreAbsent, this.Cache, this.MinTreshold, this.MaxTreshold);
        }

        public static bool CheckTermoDetails(bool sensorsAreAbsent, Data.Quality.AP_Version_Termo_DetailDataTable cache, decimal minTreshold, decimal maxTreshold)
        {
            if (sensorsAreAbsent)
                return false;

            foreach (Data.Quality.AP_Version_Termo_DetailRow item in cache.Rows)
            {
                var success = TermoDetailsPackage.CheckTermoDetail(item, minTreshold, maxTreshold);
                if (!success)
                    return false;

                #region OBSOLETE
                //if (item.RowState == DataRowState.Deleted)
                //    continue;

                //var tfact = item.IsT_FactNull() ? (decimal?)null : item.T_Fact;
                //var tmin = item.IsT_MinNull() ? (decimal?)null : item.T_Min;
                //var tmax = item.IsT_MaxNull() ? (decimal?)null : item.T_Max;

                //if (!(tfact.HasValue))
                //    return false;

                //var checkedTemperatures = new List<decimal>(new[] { tfact.Value });

                //if (tmin.HasValue)
                //    checkedTemperatures.Add(tmin.Value);

                //if (tmax.HasValue)
                //    checkedTemperatures.Add(tmax.Value);

                //foreach (var tmp in checkedTemperatures)
                //    if (!(minTreshold <= tmp && tmp <= maxTreshold))
                //        return false;
                #endregion
            }

            return true;
        }

        public static bool CheckTermoDetail(Data.Quality.AP_Version_Termo_DetailRow item, decimal minTreshold, decimal maxTreshold)
        {
            if (item.RowState == DataRowState.Deleted)
                return true;

            var tfact = item.IsT_FactNull() ? (decimal?)null : item.T_Fact;
            var tmin = item.IsT_MinNull() ? (decimal?)null : item.T_Min;
            var tmax = item.IsT_MaxNull() ? (decimal?)null : item.T_Max;

            if (!(tfact.HasValue))
                return false;

            var checkedTemperatures = new List<decimal>(new[] { tfact.Value });

            if (tmin.HasValue)
                checkedTemperatures.Add(tmin.Value);

            if (tmax.HasValue)
                checkedTemperatures.Add(tmax.Value);

            foreach (var tmp in checkedTemperatures)
                if (!(minTreshold <= tmp && tmp <= maxTreshold))
                    return false;

            return true;
        }


        public class TermoDetailsPackageReason
        {
            public int ReasonID { get; set; }
            public string ReasonName { get; set; }
            public string Note { get; set; }

            public bool HasReason { get { return this.ReasonID > 0; } }
        }
    }

    public enum TermoMode : int
    {
        /// <summary>
        /// 2-8, °C (questionID = 22)
        /// </summary>
        TM28 = 22,

        /// <summary>
        /// 8-15, °C (questionID = 23)
        /// </summary>
        TM815 = 23,

        /// <summary>
        /// 15-25, °C (questionID = 24)
        /// </summary>
        TM1525 = 24
    }
}
