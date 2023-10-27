using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Класс-менеджер процесса погрузки термотовара в термобоксы
    /// </summary>
    public class ColdChainPackingTermoBoxesManager
    {
        public int UserID {get; set; } // Сессия пользователя
        public double PickSlipNumber { get; private set; } // Номер сборочного листа
        
        public ColdChainPackingTermoBoxesManager(double numPickSlip)
        {
            this.PickSlipNumber = numPickSlip;
        }

        /// <summary>
        /// Процедура выполнения погрузки всего товара в термобоксы 
        /// </summary>
        public void Execute()
        {
            string termoContainerBarCode = string.Empty; // ш/к
            while (true)
            {
                termoContainerBarCode = OpenTermoContainer(); // выбираем термоконтейнер

                // Если погрузка товара закончена, то завершаем процесс
                if (LoadItemsIntoTermoContainer(termoContainerBarCode))
                    break;
            }
        }

        /// <summary>
        /// Открытие термоконтейнера
        /// </summary>
        /// <returns>ш/к</returns>
        private string OpenTermoContainer()
        {
            ScanScenario.UserID = this.UserID;
            ScanBarCodeForm formHandler = new ScanBarCodeForm(ScanScenarioType.TermoBox) { DiscardCanceling = true };

            if (formHandler.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return formHandler.ResponseData[0].ToString().Trim(); // вернем ш/к термоконтейнера

            return string.Empty;
        }

        /// <summary>
        /// Погрузка последовательности товара в указанный термоконтейнер
        /// </summary>
        /// <param name="termoContainerBarCode">ш/к</param>
        /// <returns>Признак завершения погрузки </returns>
        private bool LoadItemsIntoTermoContainer(string termoContainerBarCode)
        {
            bool activateAbortOption = false; // признак активации ручного завершения погрузки

            while (true)
            {
                // Если погрузка товара в данный термобокс завершена, выходим на контроль завершения
                if (LoadItemToTermoContainer(termoContainerBarCode, activateAbortOption))
                    break;

                activateAbortOption = true; // после погрузки в термоконтейнер одного места активировать опцию завершения погрузки
            }

            // закрываем термоконтейнер и возвращаем признак продолжения работы
            return CloseTermoContainer(termoContainerBarCode);
        }

        /// <summary>
        /// Погрузка единицы товара в указанный термоконтейнер
        /// </summary>
        /// <param name="termoContainerBarCode">ш/к</param>
        /// <param name="activateAbortOption">признак активации ручного завершения погрузки</param>
        /// <returns>Признак завершения погрузки товара в данный термобокс</returns>
        private bool LoadItemToTermoContainer(string termoContainerBarCode, bool activateAbortOption)
        {
            ScanScenario.UserID = this.UserID;
            ScanBarCodeForm formHandler = new ScanBarCodeForm(ScanScenarioType.TermoBoxManyResidence)
            {
                DiscardCanceling = true,
                AbortOperationAccess = activateAbortOption,
                ScanOperationHeader = string.Format("Погрузка товара в термоконтейнер (ш/к {0})", termoContainerBarCode)
            };

            formHandler.RequestData = new object[] { termoContainerBarCode, this.PickSlipNumber }; // входящие параметры для сценария - это штрих-код термобокса, номер сборочного листа

            if (formHandler.ShowDialog() == DialogResult.OK)
                return Convert.ToBoolean(formHandler.ResponseData[0]); // true - завершена

            // Если погрузка была экстренно завершена - выходим
            if (formHandler.DialogResult == DialogResult.Abort)
                return true;

            return false;
        }

        /// <summary>
        /// Закрытие указанного термоконтейнера
        /// </summary>
        /// <param name="termoContainerBarCode">ш/к</param>
        /// <returns>Признак завершения погрузки всего товара</returns>
        private bool CloseTermoContainer(string termoContainerBarCode)
        {
            try
            {
                using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                    return Convert.ToBoolean(adapter.CheckColdItemsPackingEnding(this.PickSlipNumber, this.UserID));
            }
            catch
            {
               return false;
            }
        }
    }
}
