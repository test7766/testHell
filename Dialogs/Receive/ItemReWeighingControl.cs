using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WMSOffice.Dialogs.Receive
{
    public enum ReWeighingProcessType
    {
        /// <summary>
        /// 3-х кратное
        /// </summary>
        ReWeighingBy3 = 3,

        /// <summary>
        /// 7-ми кратное
        /// </summary>
        ReWeighingBy7 = 7
    }

    public enum ReWeighingProcessDocUnit
    {
        /// <summary>
        /// По умолчанию
        /// </summary>
        Default,
        
        /// <summary>
        /// Упаковка
        /// </summary>
        Item,

        /// <summary>
        /// Ящик
        /// </summary>
        Box,

    }

    /// <summary>
    /// Построитель компонента взвешивания
    /// </summary>
    public static class ReWeighingProcessBuilder
    {
        /// <summary>
        /// Алгоритм взвешивания по умолчанию
        /// </summary>
        public static ReWeighingProcessType DefaultReWeighingProcessType { get { return ReWeighingProcessType.ReWeighingBy7; } }

        public static IItemReWeighingControl CreateUI(ReWeighingProcessType reWeighingProcessType)
        {
            switch (reWeighingProcessType)
            { 
                case ReWeighingProcessType.ReWeighingBy7:
                    return new ItemReWeighingBy7Control();
                case ReWeighingProcessType.ReWeighingBy3:
                default:
                    return new ItemReWeighingControl();
            }
        }
    }

    public interface IItemReWeighingControl
    {
        bool NeedComplete { get; }
        bool Complete { get; }

        event EventHandler OnStageProcessingCompleted;
        event EventHandler OnItemProcessingCompleted;

        long? CreateDoc(ReWeightDocBase doc);
        long? CreateDoc(string barcode, int employeeID, string docType);
        long? CreateDoc(string barcode, int employeeID, string docType, ReWeighingProcessDocUnit docUnit);
        long? CreateDocForItem(long itemID, int employeeID, string docType);
        Data.PickControl.ReWeighingDocItemsDataTable GetItems();
        void CheckItemID(int itemID);
        void CheckItemBarcode(string barcode);
        void SetWeight(double weight);
        void ClearWeight();
        void SetInstructionFlag(int? instructionFlag);
        bool SaveItemFinishProcess(bool useDeferredSave);
        bool TryCancelDoc();

        void GetFinalWeight(out double? finalWeight, out string finalWeightFlag);
        void GetUnitX3Weight(out double? unitX3Weight);
        void GetInsrtuctionFlag(out int? instructionFlag);
    }

    public partial class ItemReWeighingControl : UserControl, IItemReWeighingControl
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

        public ItemReWeighingControl()
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

            reWeightDoc = new ReWeightDoc();

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

            reWeightDoc = new ReWeightDoc();

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

            var itemsCount = reWeightDoc.ItemsQuantity;

            // Вес на текущем этапе
            fi = this.GetType().GetField(string.Format("lblWeight_x_{0}_Value", itemsCount), BindingFlags.Instance | BindingFlags.NonPublic);
            lbl = fi.GetValue(this) as Label;
            lbl.Text = reWeightDoc.Weight.ToString();

            // Расчетный вес одной упаковки на текущем этапе
            if (reWeightDoc.StageNumber > 1)
            {
                fi = this.GetType().GetField(string.Format("lblWeight_1_of_{0}_Value", itemsCount + 1), BindingFlags.Instance | BindingFlags.NonPublic);
                lbl = fi.GetValue(this) as Label;
                lbl.Text = reWeightDoc.ApproximateWeight.ToString();
            }
           
            reWeightDoc.NextStage();
            lblMessage.Text = reWeightDoc.Message;

            this.NeedComplete = reWeightDoc.Complete;
            RaiseStageProcessingCompleted();

            // Вес на последнем этапе
            if (reWeightDoc.Complete)
            {
                fi = this.GetType().GetField(string.Format("lblWeight_1_of_{0}_Value", 1), BindingFlags.Instance | BindingFlags.NonPublic);
                lbl = fi.GetValue(this) as Label;
                lbl.Text = reWeightDoc.Weight.ToString();

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
            lblWeight_x_3_Value.Text =
            lblWeight_x_2_Value.Text =
            lblWeight_x_1_Value.Text =

            lblWeight_1_of_3_Value.Text =
            lblWeight_1_of_2_Value.Text =
            lblWeight_1_of_1_Value.Text = "-";

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


    public interface IReWeightDoc
    {
        void CancelDoc();
        void CreateDoc(string pickSlipBar, int employeeID, string docType, ref long? docID);
        void CreateDocForItem(long itemID, int employeeID, string docType, ref long? docID);
        Data.PickControl.ReWeighingDocItemsDataTable GetItems();
        void CheckItem(int itemID);
        void CheckItemBarcode(string barcode);
        void SaveResult(double weight);
        void ClearResult();
        bool CanCloseDoc();
        void CountDocDiff();
        void CloseDoc();

        // Для ОБВХ
        void GetFinalWeight(out double? finalWeight, out string finalWeightFlag);
        void GetUnitX3Weight(out double? unitX3Weight);
        void GetInsrtuctionFlag(out int? instructionFlag);
    }

    public abstract class ReWeightDocBase : IReWeightDoc, ICloneable
    {
        public long DocID { get; protected set; }
        public int LineID { get; protected set; }

        public string LineBarcode { get; set; }

        public int StagesCount { get; set; }
        public int StageNumber { get; set; }

        public double Weight { get; set; }
        public double PreviousWeight { get; set; }
        public double ApproximateWeight { get { return PreviousWeight - Weight; } }

        public int? InstructionFlag { get; set; }

        public bool Complete { get; set; }

        public abstract int ItemsQuantity { get; }

        public abstract string Message { get; }

        public abstract void CancelDoc();
        public abstract void CreateDoc(string pickSlipBar, int employeeID, string docType, ref long? docID);
        public abstract void CreateDocForItem(long itemID, int employeeID, string docType, ref long? docID);
        public abstract Data.PickControl.ReWeighingDocItemsDataTable GetItems();
        public abstract Data.PickControl.ReWeighingDocItemStepsDataTable GetItemSteps(int itemID);
        public abstract void CheckItem(int itemID);
        public abstract void CheckItemBarcode(string barcode);
        public abstract void SaveResult(double weight);
        public abstract void ClearResult();
        public abstract bool CanCloseDoc();
        public abstract void CountDocDiff();
        public abstract void CloseDoc();

        public abstract void GetFinalWeight(out double? finalWeight, out string finalWeightFlag);
        public abstract void GetUnitX3Weight(out double? unitX3Weight);
        public abstract void GetInsrtuctionFlag(out int? instructionFlag);

        public event EventHandler OnSubmitWeight;
        protected void RaiseSubmitWeight()
        {
            if (OnSubmitWeight != null)
                OnSubmitWeight(this, EventArgs.Empty);
        }

        public event EventHandler OnUndoWeight;
        protected void RaiseUndoWeight()
        {
            if (OnUndoWeight != null)
                OnUndoWeight(this, EventArgs.Empty);
        }

        public void NextStage()
        {
            if (!(Complete = (StageNumber == StagesCount)))
                StageNumber++;
        }

        protected void ClearItem()
        {
            LineID = -1;

            StageNumber = 0;
            StagesCount = 0;

            Weight = 0.0;
            PreviousWeight = 0.0;

            InstructionFlag = (int?)null;

            Complete = false;
        }

        /// <summary>
        /// Установка признака инструкции
        /// </summary>
        /// <param name="instructionFlag"></param>
        public void SetInstructionFlag(int? instructionFlag)
        {
            this.InstructionFlag = instructionFlag;
        }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

    public class ReWeightDoc : ReWeightDocBase
    {
        public override int ItemsQuantity { get { return StagesCount - StageNumber + 1; } }

        public override string Message
        {
            get 
            {
                if (Complete)
                    return string.Format("Взвешивание завершено. Отсканируйте новый товар.");
                else if (StageNumber == 1)
                    return string.Format("Оставьте на весах {0} шт. товара.", ItemsQuantity);
                else if (StageNumber > 1)
                    return string.Format("Вес получен. Оставьте на весах {0} шт. товара.", ItemsQuantity);

                return string.Empty;
            }
        }

        public override void CreateDoc(string pickSlipBar, int employeeID, string docType, ref long? docID)
        {
            using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                adapter.RW_CreateDoc(pickSlipBar, employeeID, docType, ref docID);

            this.DocID = docID ?? -1;
        }

        public override void CreateDocForItem(long itemID, int employeeID, string docType, ref long? docID)
        {
            using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                adapter.RW_CreateDocForItem(itemID, employeeID, docType, ref docID);

            this.DocID = docID ?? -1;
        }

        public override Data.PickControl.ReWeighingDocItemsDataTable GetItems()
        {
            using (var adapter = new Data.PickControlTableAdapters.ReWeighingDocItemsTableAdapter())
                return adapter.GetData(this.DocID);
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
                    adapter.RW_CheckItem(this.DocID, itemID, ignoreErrorsFlag, ref lineID, ref stageCount);

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
            //// TODO для тестирования
            //weight *= ItemsQuantity;

            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.RW_SaveItemWeight(this.DocID, this.LineID, this.StageNumber, weight);

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
                    adapter.RW_CanCloseDoc(this.DocID, this.LineID, this.StageNumber, ref canCloseFlag);

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
                    adapter.RW_CountDocDiff(this.DocID, this.LineID, this.InstructionFlag);
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
                    adapter.RW_CloseDoc(this.DocID);
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
                    adapter.RW_CancelDoc(this.DocID);
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
                    adapter.RW_GetFinalWeight(this.DocID, this.LineID, ref finalWeight, ref finalWeightFlag);
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
                    adapter.RW_GetUnitX3Weight(this.DocID, this.LineID, ref unitX3Weight);
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
                    adapter.RW_GetInstructionFlag(this.DocID, this.LineID, ref instructionFlag);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
