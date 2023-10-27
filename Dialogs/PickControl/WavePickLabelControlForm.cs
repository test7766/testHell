using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class WavePickLabelControlForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Идентификатор документа контроля
        /// </summary>
        public long PCDocID { get; set; }

        /// <summary>
        /// Идентификатор WL-документа
        /// </summary>
        public int? PCWLDocID { get; set; }

        private Dictionary<LabelAction, string> dicLabelActions = new Dictionary<LabelAction, string>();

        private LabelAction currentLabelAction;

        private bool allowCloseForm = false;

        private string lastBarcodeYL = null;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public WavePickLabelControlForm()
        {
            InitializeComponent();

            dicLabelActions[LabelAction.YL] = "Отсканируйте ЖЭ";
            dicLabelActions[LabelAction.WL] = "Отсканируйте БЭ";
            dicLabelActions[LabelAction.IL] = "Отсканируйте товар";
        }

        private void WavePickLabelControlForm_Load(object sender, EventArgs e)
        {
            if (this.PCWLDocID.HasValue)
            {
                this.ClearLines();
            }
            else if (!this.CreateDoc())
            {
                this.Close();
                return;
            }

            LoadData();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(1117, 8);
            this.btnCancel.Location = new Point(1207, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";
            this.FormClosing += new FormClosingEventHandler(WavePickLabelControlForm_FormClosing);

            this.ChangeLabelAction(LabelAction.YL);

            tbsLabelBarcode.TextChanged += new EventHandler(tbsLabelBarcode_TextChanged);
            tbsLabelBarcode.Focus();
               
        }

        void WavePickLabelControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel && !allowCloseForm)
            {
                MessageBox.Show("Необходимо проконтролировать привязку каждой пары этикеток.\r\nОкно закроется автоматически!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void ChangeLabelAction(LabelAction labelAction)
        {
            currentLabelAction = labelAction;
            lblAction.Text = dicLabelActions[currentLabelAction];
        }

        void tbsLabelBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbsLabelBarcode.Text))
            {
                try
                {
                    var barcode = tbsLabelBarcode.Text;
                    var needClose = (int?)null;
                    wavePickLabelDetailsTableAdapter.ScanLabel(this.PCDocID, this.PCWLDocID.Value, (int)currentLabelAction, barcode, this.UserID, lastBarcodeYL, ref needClose);

                    if (currentLabelAction == LabelAction.YL)
                        lastBarcodeYL = barcode;

                    if (needClose.HasValue && needClose.Value.Equals(1))
                    {
                        allowCloseForm = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else
                    {
                        LoadData();

                        if (currentLabelAction == LabelAction.YL)
                            this.ChangeLabelAction(LabelAction.WL);
                        else
                            if (currentLabelAction == LabelAction.WL)
                                this.ChangeLabelAction(LabelAction.IL);
                            else
                                if (currentLabelAction == LabelAction.IL)
                                    this.ChangeLabelAction(LabelAction.YL);
                    }
                }
                catch (Exception ex)
                {
                    var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(ex.Message, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.Red);
                    errorForm.TimeOut = 1000;
                    errorForm.ShowDialog();
                }
            }

            tbsLabelBarcode.Text = string.Empty;
            tbsLabelBarcode.Focus();
        }

        #endregion

        private bool CreateDoc()
        {
            try
            {
                var wlDocID = (int?)null;
                wavePickLabelDetailsTableAdapter.CreateDoc(this.PCDocID, ref wlDocID);

                if (wlDocID.HasValue)
                {
                    this.PCWLDocID = wlDocID.Value;
                    return true;
                }
                else
                    throw new Exception("Не удалось создать документ контроля привязки ЖЭ к БЭ.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ClearLines()
        {
            try
            {
                wavePickLabelDetailsTableAdapter.Fill(pickControl.WavePickLabelDetails, this.PCDocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                wavePickLabelDetailsTableAdapter.Fill(pickControl.WavePickLabelDetails, this.PCDocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                var detail = (row.DataBoundItem as DataRowView).Row as Data.PickControl.WavePickLabelDetailsRow;
                var color = detail.IscolorNull() ? Color.White : Color.FromName(detail.color);

                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = color;
                    row.Cells[c].Style.SelectionForeColor = color;
                }
            }
        }

        public enum LabelAction
        {
            /// <summary>
            /// ЖЭ
            /// </summary>
            YL = 1,

            /// <summary>
            /// БЭ
            /// </summary>
            WL = 2,

            /// <summary>
            /// Товар
            /// </summary>
            IL = 3
        }
    }
}
