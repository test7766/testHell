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
    public partial class BunchReWeighingForm : DialogForm
    {
        public int? ItemQuantityInBunch { get; set; }

        public string BunchWeightFlag { get; set; }

        public double? BunchWeight { get; set; }

        public BunchReWeighingForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(77, 8);
            this.btnCancel.Location = new Point(167, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            lblItemQuantityInBunchValue.Text = ((object)this.ItemQuantityInBunch ?? "-").ToString();

            foreach (RadioButton rbBunchMadeType in gbBunchMadeType.Controls)
                if (rbBunchMadeType.Tag.Equals(this.BunchWeightFlag))
                {
                    rbBunchMadeType.Checked = true;
                    rbBunchMadeType.Focus();
                }
        }

        private void rbBunchMadeType_CheckedChanged(object sender, EventArgs e)
        {
            var rbBunchMadeType = sender as RadioButton;
            this.BunchWeightFlag = (string)rbBunchMadeType.Tag;

            this.btnOK.Focus();
        }

        private void BunchReWeighingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SetWeight();
        }

        private bool SetWeight()
        {
            try
            {
                if (string.IsNullOrEmpty(this.BunchWeightFlag.Trim('0')))
                    throw new Exception("Не выбран тип склейки.");

                #region ОПРЕДЕЛЕНИЕ ТИПА ВЕСОВ

                var typeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                var minRatio = 0.5M;

                var dlgSelectWeightType = new WMSOffice.Dialogs.RichListForm();
                dlgSelectWeightType.Text = "Выберите тип весов";
                dlgSelectWeightType.AddColumn("TypeID", "TypeID", "Код");
                dlgSelectWeightType.AddColumn("TypeName", "TypeName", "Наименование");
                dlgSelectWeightType.FilterChangeLevel = 0;
                dlgSelectWeightType.FilterVisible = false;

                var table = new Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesDataTable();
                Optima.Devices.Data.DigitalWeigher.DataManager.DW_TypesTableAdapter.Fill(table);
                dlgSelectWeightType.DataSource = table;

                if (dlgSelectWeightType.ShowDialog() != DialogResult.OK)
                    throw new Exception("Взвешивание прервано.");

                typeID = (dlgSelectWeightType.SelectedRow as Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesRow).TypeID;
                minRatio = (dlgSelectWeightType.SelectedRow as Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesRow).MinRatio;

                #endregion

                var weightProvider = new ObtainWeightProvider() { AbortTimeout = 10000, WeightTypeID = typeID, MinRatio = minRatio };
                weightProvider.OnComplete += delegate(object snd, EventArgs ea)
                {
                    try
                    {
                        if (weightProvider.WeightObtained)
                        {
                            var sCurrentWeight = weightProvider.Value;
                            double currentWeight;

                            if (!double.TryParse(sCurrentWeight, out currentWeight))
                                throw new Exception("Вес склейки задан некорректно.");

                            // Преобразование кг в г (для статических весов (временно!!!))
                            if (typeID == (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static)
                            {
                                currentWeight *= 1000;
                                sCurrentWeight = currentWeight.ToString();
                            }

                            this.BunchWeight = currentWeight;
                        }
                        else
                        {
                            if (weightProvider.Error != null)
                                throw new Exception(weightProvider.Error.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                };

                // Запускаем фоновый поток
                weightProvider.Run();

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
