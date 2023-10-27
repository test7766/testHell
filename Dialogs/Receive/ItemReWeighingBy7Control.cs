using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Receive
{
    public partial class ItemReWeighingBy7Control : UserControl, IItemReWeighingControl
    {
        private ReWeightDocBase reWeightDoc = null;

        public bool NeedComplete { get; private set; }
        public bool Complete { get; private set; }

        public event EventHandler OnStageProcessingCompleted;
        private void RaiseStageProcessingCompleted()
        {
            if (OnStageProcessingCompleted != null)
                OnStageProcessingCompleted(this, EventArgs.Empty);
        }

        public event EventHandler OnItemProcessingCompleted;
        private void RaiseItemProcessingCompleted()
        {
            if (OnItemProcessingCompleted != null)
                OnItemProcessingCompleted(this, EventArgs.Empty);
        }

        public ItemReWeighingBy7Control()
        {
            InitializeComponent();
        }

        public long? CreateDoc(ReWeightDocBase doc)
        {
            this.NeedComplete = false;
            this.Complete = false;

            this.ClearProperties();


            reWeightDoc = doc;

            reWeightDoc.OnSubmitWeight -= new EventHandler(stage_OnSubmitWeight);
            reWeightDoc.OnSubmitWeight += new EventHandler(stage_OnSubmitWeight);

            return doc.DocID;
        }

        public long? CreateDoc(string barcode, int employeeID, string docType)
        {
            return this.CreateDoc(barcode, employeeID, docType, ReWeighingProcessDocUnit.Item);
        }

        public long? CreateDoc(string barcode, int employeeID, string docType, ReWeighingProcessDocUnit docUnit)
        {
            this.NeedComplete = false;
            this.Complete = false;

            this.ClearProperties();


            reWeightDoc = docUnit.Equals(ReWeighingProcessDocUnit.Box) ? (ReWeightDocBase)new ReWeightDocBy7PWC() : (ReWeightDocBase)new ReWeightDocBy7();

            var docID = (long?)null;
            reWeightDoc.CreateDoc(barcode, employeeID, docType, ref docID);

            reWeightDoc.OnSubmitWeight -= new EventHandler(stage_OnSubmitWeight);
            reWeightDoc.OnSubmitWeight += new EventHandler(stage_OnSubmitWeight);

            return docID;
        }

        public long? CreateDocForItem(long itemID, int employeeID, string docType)
        {
            this.NeedComplete = false;
            this.Complete = false;

            this.ClearProperties();


            reWeightDoc = new ReWeightDocBy7();

            var docID = (long?)null;
            reWeightDoc.CreateDocForItem(itemID, employeeID, docType, ref docID);

            reWeightDoc.OnSubmitWeight -= new EventHandler(stage_OnSubmitWeight);
            reWeightDoc.OnSubmitWeight += new EventHandler(stage_OnSubmitWeight);

            return docID;
        }

        public Data.PickControl.ReWeighingDocItemsDataTable GetItems()
        {
            return reWeightDoc.GetItems();
        }

        public void CheckItemID(int itemID)
        {
            reWeightDoc.CheckItem(itemID);

            this.ClearProperties();
            lblMessage.Text = reWeightDoc.Message;
        }

        public void CheckItemBarcode(string barcode)
        {
            reWeightDoc.CheckItemBarcode(barcode);
        }

        void stage_OnSubmitWeight(object sender, EventArgs e)
        {
            var t = this.GetType();
            FieldInfo fi = null;
            Label lbl = null;

            var stageNumber = reWeightDoc.StageNumber;

            // Вес на текущем этапе
            fi = this.GetType().GetField(string.Format("lblWeight_No_{0}_Value", stageNumber), BindingFlags.Instance | BindingFlags.NonPublic);
            lbl = fi.GetValue(this) as Label;
            lbl.Text = reWeightDoc.Weight.ToString();
           
            reWeightDoc.NextStage();
            lblMessage.Text = reWeightDoc.Message;

            this.NeedComplete = reWeightDoc.Complete;
            RaiseStageProcessingCompleted();

            // Вес на последнем этапе
            if (reWeightDoc.Complete)
            {
                RaiseItemProcessingCompleted();
            }
        }

        /// <summary>
        /// Сохранение этапа взвешивания
        /// </summary>
        /// <param name="weight"></param>
        public void SetWeight(double weight)
        {
            try
            {
                // для теста
                //weight = reWeightDoc.StageNumber == 1 ? 60.1 : reWeightDoc.StageNumber == 2 ? 39.9 : 20.1;

                 //Перенес расчет в метод документа взвешивания
                //reWeightDoc.PreviousWeight = weight;
                //reWeightDoc.Weight = weight;

                reWeightDoc.SaveResult(weight);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        public void ClearWeight()
        {
            reWeightDoc.ClearResult();
        }

        /// <summary>
        /// Установка признака инструкции
        /// </summary>
        /// <param name="instructionFlag"></param>
        public void SetInstructionFlag(int? instructionFlag)
        {
            reWeightDoc.SetInstructionFlag(instructionFlag);
        }

        private void ClearProperties()
        {
            lblWeight_No_1_Value.Text =
            lblWeight_No_2_Value.Text =
            lblWeight_No_3_Value.Text =
            lblWeight_No_4_Value.Text =
            lblWeight_No_5_Value.Text =
            lblWeight_No_6_Value.Text =
            lblWeight_No_7_Value.Text = "-";

            lblMessage.Text = string.Empty;
        }

        /// <summary>
        /// Фиксация завершения взвешивания позиции документа
        /// </summary>
        /// <returns></returns>
        public bool SaveItemFinishProcess(bool useDeferredSave)
        {
            while (true)
            {
                try
                {
                    // Анализ несмещенности итогового веса
                    reWeightDoc.CountDocDiff();

                    // Анализ завершения работы с документом
                    var needMoreItems = !reWeightDoc.CanCloseDoc();

                    if (!needMoreItems && !useDeferredSave)
                    {
                        reWeightDoc.CloseDoc();
                        this.Complete = true;
                    }

                    return needMoreItems;
                }
                catch (Exception ex)
                {
                    var msbResult = MessageBox.Show("Во время сохранения расчетного веса произошла ошибка.\r\nПовторить сохранение или прервать текущее задание?", "Внимание", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    if (msbResult == DialogResult.Retry || msbResult == DialogResult.Ignore)
                        continue;
                    else
                        return false;
                }
            }
        }

        /// <summary>
        /// Попытка отмены документа
        /// </summary>
        /// <returns></returns>
        public bool TryCancelDoc()
        {
            try
            {
                if (!this.Complete)
                    reWeightDoc.CancelDoc();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Получение конечного веса
        /// </summary>
        /// <param name="finalWeight"></param>
        /// <param name="finalWeightFlag"></param>
        public void GetFinalWeight(out double? finalWeight, out string finalWeightFlag)
        {
            finalWeight = (double?)null;
            finalWeightFlag = (string)null;

            try
            {
                reWeightDoc.GetFinalWeight(out finalWeight, out finalWeightFlag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Вес 3-х упаковок в отдельности (на 1-й итерации)
        /// </summary>
        /// <param name="unitX3Weight"></param>
        public void GetUnitX3Weight(out double? unitX3Weight)
        {
            unitX3Weight = (double?)null;

            try
            {
                reWeightDoc.GetUnitX3Weight(out unitX3Weight);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение признака наличия инструкции
        /// </summary>
        /// <param name="instructionFlag"></param>
        public void GetInsrtuctionFlag(out int? instructionFlag)
        {
            instructionFlag = (int?)null;

            try
            {
                reWeightDoc.GetInsrtuctionFlag(out instructionFlag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class ReWeightDocBy7 : ReWeightDocBase
    {
        public override int ItemsQuantity { get { return 1; } }

        public override string Message
        {
            get 
            {
                if (Complete)
                    return string.Format("Взвешивание завершено. Отсканируйте новый товар.");
                else if (StageNumber == 1)
                    return string.Format("Оставьте на весах {0} шт. товара. Шаг {1} из {2}.", ItemsQuantity, StageNumber, StagesCount);
                else if (StageNumber > 1)
                    return string.Format("Вес получен. Оставьте на весах {0} шт. товара. Шаг {1} из {2}.", ItemsQuantity, StageNumber, StagesCount);

                return string.Empty;
            }
        }

        public override void CreateDoc(string barcode, int employeeID, string docType, ref long? docID)
        {
            using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                adapter.RW7_CreateDoc(barcode, employeeID, docType, ref docID);

            this.DocID = docID ?? -1;
        }

        public override void CreateDocForItem(long itemID, int employeeID, string docType, ref long? docID)
        {
            using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                adapter.RW7_CreateDocForItem(itemID, employeeID, docType, ref docID);

            this.DocID = docID ?? -1;
        }

        public override Data.PickControl.ReWeighingDocItemsDataTable GetItems()
        {
            using (var adapter = new Data.PickControlTableAdapters.ReWeighingDocItemsTableAdapter())
                return adapter.GetData7(this.DocID);
        }

        public override WMSOffice.Data.PickControl.ReWeighingDocItemStepsDataTable GetItemSteps(int itemID)
        {
            return null;
        }

        public override void CheckItem(int itemID)
        {
            this.CheckItem(itemID, false);
        }

        private void CheckItem(int itemID, bool ignoreErrors)
        {
            try
            {
                var lineID = (int?)null;
                var stageCount = (int?)null;

                var ignoreErrorsFlag = Convert.ToInt32(ignoreErrors);

                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_CheckItem(this.DocID, itemID, ignoreErrorsFlag, ref lineID, ref stageCount);

                ClearItem();

                this.LineID = lineID ?? -1;
                this.StagesCount = stageCount ?? 1;

                this.StageNumber = 1;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                var throwException = false;

                if (errorMessage.Contains("#"))
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Action>\w+)#(?<Message>.+)#$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(errorMessage))
                    {
                        var match = regex.Match(ex.Message);
                        var action = match.Groups["Action"].Value;
                        var message = match.Groups["Message"].Value;

                        if (action.Equals("CAN_REWEIGHT"))
                        {
                            if (MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                this.CheckItem(itemID, true);
                            else
                            {
                                errorMessage = message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
                                throwException = true;
                            }
                        }
                    }
                    else
                        throwException = true;
                }
                else
                    throwException = true;

                if (throwException)
                    throw new Exception(errorMessage);
            }
        }

        public override void CheckItemBarcode(string barcode)
        {
            
        }

        public override void SaveResult(double weight)
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_SaveItemWeight(this.DocID, this.LineID, this.StageNumber, weight);

                this.PreviousWeight = this.Weight;
                this.Weight = weight;

                RaiseSubmitWeight();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void ClearResult()
        {
            
        }

        /// <summary>
        /// Анализ закрытия документа (есть ли невзвешенные позиции)
        /// </summary>
        /// <returns></returns>
        public override bool CanCloseDoc()
        {
            try
            {
                var canCloseFlag = (int?)null;

                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_CanCloseDoc(this.DocID, this.LineID, this.StageNumber, ref canCloseFlag);

                return Convert.ToBoolean(canCloseFlag ?? 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Анализ несмещенности итогового веса
        /// </summary>
        public override void CountDocDiff()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_CountDocDiff(this.DocID, this.LineID, this.InstructionFlag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Фиксация документа
        /// </summary>
        public override void CloseDoc()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_CloseDoc(this.DocID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Отмена документа
        /// </summary>
        public override void CancelDoc()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_CancelDoc(this.DocID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void GetFinalWeight(out double? finalWeight, out string finalWeightFlag)
        {
            finalWeight = (double?)null;
            finalWeightFlag = (string)null;

            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_GetFinalWeight(this.DocID, this.LineID, ref finalWeight, ref finalWeightFlag);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void GetUnitX3Weight(out double? unitX3Weight)
        {
            unitX3Weight = (double?)null;

            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_GetUnitX3Weight(this.DocID, this.LineID, ref unitX3Weight);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Получение признака наличия инструкции
        /// </summary>
        /// <param name="instructionFlag"></param>
        public override void GetInsrtuctionFlag(out int? instructionFlag)
        {
            instructionFlag = (int?)null;

            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW7_GetInstructionFlag(this.DocID, this.LineID, ref instructionFlag);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
