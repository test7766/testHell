using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Dialogs.ColdChain
{
    public enum ScanScenarioType
    {
        TermoBox,
        TermoBag,
        RouteList,
        WithoutCheck,
        TermoBoxManyResidence,
        CloseMovementAct
    }

    public class ScanScenario
    {
        #region Свойства
        public static int UserID { get; set; }
        public string ScenarioAction { get; private set; }
        public string ScenarioDescription { get; private set; }
        public ScanScenarioExecutor ScenarioExecutor { get; private set; }
        #endregion

        /// <summary>
        /// Константа пользовательского наименования сценариев
        /// </summary>
        private static readonly string USER_DEFINITION_SCENARIO_NAME = string.Empty;
        /// <summary>
        /// Словарь сценариев
        /// </summary>
        private Dictionary<ScanScenarioType, ScanScenario> ScanScenarioList;

        /// <summary>
        /// Индексатор сценариев
        /// </summary>
        /// <param name="type">Тип сценария</param>
        /// <returns>Сценарий</returns>
        public ScanScenario this[ScanScenarioType type]
        {
            get { return ScanScenarioList[type]; }
        }

        public ScanScenario()
        {
            ScanScenarioList = new Dictionary<ScanScenarioType, ScanScenario>(Enum.GetValues(typeof(ScanScenarioType)).Length);
            ScanScenarioList[ScanScenarioType.TermoBox] = new ScanScenario(new TermoBoxScanExecutor(), "Погрузка товара в термоконтейнер", "Отсканируйте штрих-код термоконтейнера, в который будет положен проконтролированый товар.");
            ScanScenarioList[ScanScenarioType.TermoBag] = new ScanScenario(new TermoBagScanExecutor(), "Погрузка товара в термосумку", "Отсканируйте штрих-код \nтермосумки.");
            ScanScenarioList[ScanScenarioType.RouteList] = new ScanScenario(new RouteListScanExecutor(), "Погрузка товара в термосумку", "Отсканируйте штрих-код черновика маршрутного листа.");
            ScanScenarioList[ScanScenarioType.WithoutCheck] = new ScanScenario(new WithoutCheckScanExecutor(), USER_DEFINITION_SCENARIO_NAME, USER_DEFINITION_SCENARIO_NAME);
            ScanScenarioList[ScanScenarioType.TermoBoxManyResidence] = new ScanScenario(new TermoBoxManyResidenceScanExecutor(), USER_DEFINITION_SCENARIO_NAME, "Отсканируйте штрих-код белой этикетки товара.");
            ScanScenarioList[ScanScenarioType.CloseMovementAct] = new ScanScenario(new CloseMovementActScanExecutor(), "Закрытие акта перемещения товара в карантин", "Отсканируйте штрих-код акта перемещения товара в карантин.");
        }

        public ScanScenario(ScanScenarioExecutor scenarioExecutor, string scenarioAction, string scenarioDescription)
        {
            ScenarioExecutor = scenarioExecutor;
            ScenarioAction = scenarioAction;
            ScenarioDescription = scenarioDescription;
        }

        public object[] Execute(string scannerText)
        {
            return Execute(scannerText, null);
        }

        public object[] Execute(string scannerText, object[] InData)
        {
            return this.ScenarioExecutor.Execute(scannerText, InData);
        }
    }

    public abstract class ScanScenarioExecutor
    {
        public abstract object[] Execute(string scannerText, object[] InData);
    }

    public class RouteListScanExecutor : ScanScenarioExecutor
    {
        public override object[] Execute(string scannerText, object[] InData)
        {
            using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                return new object[] { adapter.CheckRouteList(scannerText, ScanScenario.UserID)};
        }
    }

    public class TermoBoxScanExecutor : ScanScenarioExecutor
    {
        public override object[] Execute(string scannerText, object[] InData)
        {
            using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                adapter.ChooseEquipmentByBarCode(scannerText, ScanScenario.UserID);

            return new object[] { scannerText };
        }
    }

    public class TermoBagScanExecutor : ScanScenarioExecutor
    {
        public override object[] Execute(string scannerText, params object[] InData)
        {
            using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                adapter.CheckTermoBag(scannerText, ScanScenario.UserID);

            return new object[] { scannerText };
        }
    }

    public class WithoutCheckScanExecutor : ScanScenarioExecutor
    {
        public override object[] Execute(string scannerText, params object[] InData)
        {
            return new object[] { scannerText };
        }
    }

    public class TermoBoxManyResidenceScanExecutor : ScanScenarioExecutor
    {
        public override object[] Execute(string scannerText, params object[] InData)
        {
            string termoBoxBarCode = InData[0].ToString(); // получаем штрих-код термобокса (несвалидированый)
            double numPickSlip = Convert.ToDouble(InData[1]); // получаем номер сборочного листа    
            string eticBarCode = scannerText; // получаем штрих-код белой этикетки (несвалидированый)

            using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                return new object[] { adapter.LoadItemToTermoBoxInCaseOfManyResidence(termoBoxBarCode, eticBarCode, numPickSlip, ScanScenario.UserID) };
        }
    }

    public class CloseMovementActScanExecutor : ScanScenarioExecutor
    {
        public override object[] Execute(string scannerText, object[] InData)
        {
            using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                adapter.CloseMovementAct(scannerText);

            return new object[] { null };
        }
    }
}
