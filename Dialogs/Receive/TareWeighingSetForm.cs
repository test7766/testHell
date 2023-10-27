using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.Receive
{
    public partial class TareWeighingSetForm : DialogForm
    {
        private readonly ObtainWeightProvider weightProvider = new ObtainWeightProvider() { AbortTimeout = 10000 };

        public Data.ItemsMeasurement.ContainersRow CurrentContainer { get; private set; }

        public TareWeighingSetForm()
        {
            InitializeComponent();
            weightProvider.OnComplete += new EventHandler(weightProvider_OnComplete);       
        }

        void weightProvider_OnComplete(object sender, EventArgs e)
        {
            try
            {
                if (weightProvider.WeightObtained)
                {
                    tbBoxWeight.Text = weightProvider.Value;
                    this.DialogResult = DialogResult.OK;
                    //this.Close();
                }
                else
                {
                    if (weightProvider.Error != null)
                        throw new Exception(weightProvider.Error.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(173, 8);
            this.btnCancel.Location = new Point(263, 8);

            btnObtainWeight.Enabled = false;
            tbBoxBarCode.TextChanged += new EventHandler(tbBoxBarCode_TextChanged);
        }

        void tbBoxBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btnObtainWeight.Enabled = false;

                if (TryScanBox(tbBoxBarCode.Text))
                {
                    btnObtainWeight.Enabled = true;
                    btnObtainWeight.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //tbBoxBarCode.Text = string.Empty;
                tbBoxBarCode.Focus();
                tbBoxBarCode.SelectAll();
            }
        }

        private bool TryScanBox(string boxBarcode)
        {
            try
            {
                var containers = new Data.ItemsMeasurement.ContainersDataTable();

                using (var adapter = new Data.ItemsMeasurementTableAdapters.ContainersTableAdapter())
                    adapter.Fill(containers, this.UserID, boxBarcode);

                if (containers.Rows.Count > 0)
                {
                    CurrentContainer = containers[0];
                    var boxWeight = CurrentContainer.IsIOUB01Null() ? 0.0F : CurrentContainer.IOUB01;

                    // Обработка случая когда ящик был ранее взвешен
                    if (CurrentContainer.HasWeight)
                    {
                        if (MessageBox.Show(string.Format("Ящик был ранее взвешен.\nПолученный вес равен {0}.\nВы желаете его перевзвесить?", boxWeight), "Повторное взвешивание ящика", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        {
                            CurrentContainer = null;

                            tbBoxBarCode.Text = string.Empty;
                            tbBoxBarCode.Focus();

                            return false;
                        }
                    }

                    tbBoxType.Text = CurrentContainer.container_type;
                    tbBoxName.Text = CurrentContainer.Container_name;
                    tbWarehouseID.Text = CurrentContainer.IOMCU;
                    tbItemID.Text = Convert.ToInt32(CurrentContainer.IOITM).ToString();
                    tbLotNumber.Text = CurrentContainer.IOLOTN;

                    tbBoxWeight.Text = boxWeight != 0.0F ? boxWeight.ToString() : string.Empty;

                    //// Запускаем фоновый поток
                    //weightProvider.Run();

                    return true;
                }
                else
                {
                    CurrentContainer = null;

                    tbBoxType.Clear();
                    tbBoxName.Clear();
                    tbWarehouseID.Clear();
                    tbItemID.Clear();
                    tbLotNumber.Clear();
                    tbBoxWeight.Clear();

                    throw new Exception("По указанному Ш/К ящик не найден.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnObtainWeight_Click(object sender, EventArgs e)
        {
            try
            {
                // Запускаем фоновый поток
                weightProvider.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnObtainWeight.Focus();
            }
        }

        private void TareWeighingSetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (CurrentContainer == null)
                    throw new Exception("Для измерения веса сперва необходимо отсканировать Ш/К ящика.");

                double currentWeight;
                if (string.IsNullOrEmpty(tbBoxWeight.Text))
                    throw new Exception("Для сохранения веса сперва необходимо взвесить ящик.");

                if (!double.TryParse(tbBoxWeight.Text, out currentWeight))
                    throw new Exception("Вес ящика задан некорректно.");

                if (currentWeight <= 0.0F)
                    throw new Exception("Для сохранения веса сперва необходимо взвесить ящик.");

                using (var adapter = new Data.ItemsMeasurementTableAdapters.ContainersTableAdapter())
                    adapter.UpdateContainerWeight(
                        UserID,
                        CurrentContainer.container_id,
                        CurrentContainer.IOMCU,
                        Convert.ToInt32(CurrentContainer.IOITM),
                        CurrentContainer.IOLOTN,
                        currentWeight);

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
