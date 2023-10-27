using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Содержит идентификаторы типов документов и статусы претензий.
    /// </summary>
    public class ComplaintsConstants
    {
        /// <summary>
        /// Режимы определения идентификатора документа по штрих-коду.
        /// </summary>
        public enum BarCodeRecognizeMode
        {
            /// <summary>
            /// Поштучный контроль - штрих-коды актов аннулирования, служебных записок, актов приема-передачи.
            /// </summary>
            ItemsControl = 1,
            /// <summary>
            /// Закрытие претензии - штрих-коды служебных записок, актов приема-передачи.
            /// </summary>
            FinishProcessing = 2,
        }

        #region Complaint Doc Types

        /// <summary>
        /// Тип документа-претензии "Недостача" (DF).
        /// </summary>
        public const string ComplaintDocTypeDeficiency = "DF";

        /// <summary>
        /// Тип документа-претензии "Излишек" (EX).
        /// </summary>
        public const string ComplaintDocTypeExcess = "EX";

        /// <summary>
        /// Тип документа-претензии "Пересорт" (RG).
        /// </summary>
        public const string ComplaintDocTypeRegrade = "RG";

        /// <summary>
        /// Тип документа-претензии "Нетоварный вид" (FR).
        /// </summary>
        public const string ComplaintDocTypeFreak = "FR";

        /// <summary>
        /// Тип документа-претензии "Бой" (BR).
        /// </summary>
        public const string ComplaintDocTypeBreak = "BR";

        /// <summary>
        /// Тип документа-претензии "Заводской брак" (FL).
        /// </summary>
        public const string ComplaintDocTypeFactoryFlaw = "FL";

        /// <summary>
        /// Тип документа-претензии "Аннулирование" (CN).
        /// </summary>
        public const string ComplaintDocTypeCancellation = "CN";
        
        /// <summary>
        /// Тип документа-претензии "Возврат" (NR).
        /// </summary>
        public const string ComplaintDocTypeNormalRefuse = "NR";

        /// <summary>
        /// Тип документа-претензии "Виртуальный возврат" (VR).
        /// </summary>
        public const string ComplaintDocTypeVirtualRefuse = "VR";

        /// <summary>
        /// Тип документа-претензии "Предписание" (OR).
        /// </summary>
        public const string ComplaintDocTypeQualityOrder = "OR";

        /// <summary>
        /// Тип документа-претензии "Переподписание РН" (RI).
        /// </summary>
        public const string ComplaintDocTypeResignInvoice = "RI";

        #endregion


        #region Complaint Doc Stage Results

        /// <summary>
        /// Результат выполнения этапа обработки претензии "Положительная виза".
        /// </summary>
        public const int StageResultAccepted = 1;
        /// <summary>
        /// Результат выполнения этапа обработки претензии "Отрицательная виза".
        /// </summary>
        public const int StageResultDeclined = 2;
        /// <summary>
        /// Результат выполнения этапа обработки претензии "Виза отложена".
        /// </summary>
        public const int StageResultDelayed = 3;
        /// <summary>
        /// Результат выполнения этапа обработки претензии "Завод отклонил".
        /// </summary>
        public const int StageResultDeclinedByFactory = 4;
        /// <summary>
        /// Результат выполнения этапа обработки претензии "Готово".
        /// </summary>
        public const int StageResultComplete = 5;

        #endregion


        #region Complaint Statuses

        /// <summary>
        /// Статус "Претензия создана" (100).
        /// </summary>
        public const string ComplaintStatusJustCreated = "100";

        /// <summary>
        /// Статус "Претензия откорректирована" (101).
        /// </summary>
        public const string ComplaintStatusJustEdited = "101";

        /// <summary>
        /// Статус "Ожидание подтверждения ОМУ" (105).
        /// </summary>
        public const string ComplaintStatusWaitAccepting = "105";

        /// <summary>
        /// Статус "Ожидание установки виз" (110).
        /// </summary>
        public const string ComplaintStatusAccepting = "110";
        
        /// <summary>
        /// Статус "Поездка за опытными образцами" (120).
        /// </summary>
        public const string ComplaintStatusSamplesDelivery = "120";

        /// <summary>
        /// Статус "Пошт. контроль опытн. обр. (1)" (130).
        /// </summary>
        public const string ComplaintStatusSamplesControl1 = "130";

        /// <summary>
        /// Статус "Пошт. контроль опытн. обр. (2)" (140).
        /// </summary>
        public const string ComplaintStatusSamplesControl2 = "140";

        /// <summary>
        /// Статус "Автообработка (претензия принята)" (200).
        /// </summary>
        public const string ComplaintStatusAutoProcessAccepted = "200";
        
        /// <summary>
        /// Статус "Печать актов аннулирования" (210).
        /// </summary>
        public const string ComplaintStatusPrintCancAct = "210";

        /// <summary>
        /// Статус "Поездка по служебной записке" (220).
        /// </summary>
        public const string ComplaintStatusDelivery = "220";

        /// <summary>
        /// Статус "Поштучный контроль товара (1)" (230).
        /// </summary>
        public const string ComplaintStatusItemsControl1 = "230";

        /// <summary>
        /// Статус "Определение виновного лица" (240).
        /// </summary>
        public const string ComplaintStatusChangeFaultEmployee = "240";

        /// <summary>
        /// Статус "Поштучный контроль товара (2)" (250).
        /// </summary>
        public const string ComplaintStatusItemsControl2 = "250";

        /// <summary>
        /// Статус "Автообработка (подтверждение возвратов JD)" (255).
        /// </summary>
        public const string ComplaintStatusAutoAcceptJDReturn = "255";

        /// <summary>
        /// Статус "Печать расчет-корректировок" (260).
        /// </summary>
        public const string ComplaintStatusCalculationsPrint = "260";

        /// <summary>
        /// Статус "Подтверждение подписания расчет-корректировок" (270).
        /// </summary>
        public const string ComplaintStatusCalculationsApproval = "270";

        /// <summary>
        /// Статус "Закрытие принятой претензии" (280).
        /// </summary>
        public const string ComplaintStatusClosingAccepted = "280";

        /// <summary>
        /// Статус "Поштр. контр. оп. обр. (отмена) (1)" (310).
        /// </summary>
        public const string ComplaintStatusSamplesReturnControl1 = "310";

        /// <summary>
        /// Статус "Поездка для возврата опытных образцов" (320).
        /// </summary>
        public const string ComplaintStatusSamplesReturnDelivery = "320";

        /// <summary>
        /// Статус "Закрытие отмененной претензии" (330).
        /// </summary>
        public const string ComplaintStatusClosingDeclined = "330";

        /// <summary>
        /// Статус "Приходование консолидированных МС" (955).
        /// </summary>
        public const string ComplaintStatusConsolidatedInterbranchAccepted = "955";

        /// <summary>
        /// Статус "Автообработка (закрытие претензии)" (960).
        /// </summary>
        public const string ComplaintStatusAutoClosingAccepted = "960";

        /// <summary>
        /// Статус "Претензия закрыта" (970).
        /// </summary>
        public const string ComplaintStatusClosedAccepted = "970";

        /// <summary>
        /// Статус "Автообработка (отмена претензии)" (980).
        /// </summary>
        public const string ComplaintStatusAutoClosingDeclined = "980";

        /// <summary>
        /// Статус "Претензия отклонена" (990).
        /// </summary>
        public const string ComplaintStatusClosedDeclined = "990";

        /// <summary>
        /// Статус "Ошибка при автообработке" (998).
        /// </summary>
        public const string ComplaintStatusAutoProcessingError = "998";

        /// <summary>
        /// Статус "Претензия была откорректирована" (999).
        /// </summary>
        public const string ComplaintStatusEdited = "999";

        #endregion

        /// <summary>
        /// Статус документа WMS "Документ в работе" (120).
        /// </summary>
        public const string WhDocStatusInWork = "120";
    }
}
