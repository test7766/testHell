using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Диалог для определения счетного листа (сканирование штрих-кода) для проведения инвентаризации
    /// </summary>
    public partial class ScanCountSheetForm : DialogForm
    {
        #region Properties

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long UserID { get; set; }

        /// <summary>
        /// Идентификатор документа (счетного листа)
        /// </summary>
        public long DocID { get; private set; }

        /// <summary>
        /// Тип документа ("CS" - счетный лист)
        /// </summary>
        public string DocType { get; private set; }

        /// <summary>
        /// Наименование типа документа
        /// </summary>
        public string DocTypeName { get; private set; }

        /// <summary>
        /// Статус документа (счетного листа)
        /// </summary>
        public string DocStatusID { get; private set; }

        /// <summary>
        /// Наименование статуса документа (счетного листа)
        /// </summary>
        public string DocStatusName { get; private set; }

        /// <summary>
        /// Дата документа (дата создания счетного листа)
        /// </summary>
        public DateTime DocDate { get; private set; }

        /// <summary>
        /// Дата родительского документа (идентификатор инвентаризации)
        /// </summary>
        public long RelatedDocID { get; private set; }

        /// <summary>
        /// Идентификатор пересчета
        /// </summary>
        public int RecalcID { get; private set; }

        /// <summary>
        /// Создание пустографки для инвентаризации филиалов
        /// </summary>
        public bool IsInventoryFilial { get; set; }

        #endregion


        /// <summary>
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        /// <param name="userID">Идентификатор сессии пользователя</param>
        public ScanCountSheetForm(long userID)
        {
            InitializeComponent();

            base.ButtonOKEnabled = false;
            UserID = userID;
            tbScanner.TextChanged += new EventHandler(tbScanner_TextChanged);
            tbScanner.Focus();
        }

        public string HandControlType { get; set; }

        /// <summary>
        /// Обрабатывает ввод нового штрих-кода
        /// </summary>
        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            // проверка правильности штрих-кода счетного листа, можно ли его брать в работу этому сотруднику?
            try
            {
                if (String.IsNullOrEmpty(HandControlType))
                    using (Data.InventoryTableAdapters.IN_CS_HeaderTableAdapter adapter = new Data.InventoryTableAdapters.IN_CS_HeaderTableAdapter())
                    {
                        // проверка. Если есть ошибки, будет сгенерирована исключительная ситуация с описанием
                        Data.Inventory.IN_CS_HeaderDataTable table = adapter.GetData(0, tbScanner.Text, UserID);
                        if (table.Rows.Count == 1)
                        {
                            Data.Inventory.IN_CS_HeaderRow row = (Data.Inventory.IN_CS_HeaderRow)table.Rows[0];
                            DocID = row.Doc_ID;
                            DocType = row.Doc_Type;
                            DocTypeName = row.Doc_Type_Name;
                            DocStatusID = row.Status_ID;
                            DocStatusName = row.Status_Name;
                            DocDate = row.Doc_Date;
                            RelatedDocID = row.Related_Doc_ID;
                            RecalcID = row.RecalcDoc_ID;

                            // если все хорошо, закрываем окно
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Процедура проверки штрих-кода не вернула данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                else if (IsInventoryFilial)
                    using (var adapter = new WMSOffice.Data.InventoryTableAdapters.FI_OpenCalcSheetTableAdapter())
                    {
                        // проверка. Если есть ошибки, будет сгенерирована исключительная ситуация с описанием
                        var table = adapter.GetData(UserID, tbScanner.Text, HandControlType);
                        if (table.Rows.Count == 1)
                        {
                            var row = table.Rows[0] as Data.Inventory.FI_OpenCalcSheetRow;
                            DocID = row.Doc_ID;
                            DocType = row.Doc_Type;
                            DocTypeName = row.Doc_Type_Name;
                            DocStatusID = row.Status_ID;
                            DocStatusName = row.Status_Name;
                            DocDate = row.Doc_Date;
                            RelatedDocID = row.Related_Doc_ID;
                            RecalcID = row.RecalcDoc_ID;

                            if ((DocType == InventoryControlWindow_NEW.INVENTORY_DOC_TYPE || DocType == InventoryControlWindow_IK.INVENTORY_DOC_TYPE) && !row.Allow)
                                MessageBox.Show("У Вас в работе находится другой счетный лист, и он автоматически будет переоткрыт.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            // если все хорошо, закрываем окно
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Процедура проверки штрих-кода не вернула данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                else
                    using (Data.InventoryTableAdapters.IV_CS_OpenTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.IV_CS_OpenTableAdapter())
                    {
                        // проверка. Если есть ошибки, будет сгенерирована исключительная ситуация с описанием
                        Data.Inventory.IV_CS_OpenDataTable table = adapter.GetData(UserID, tbScanner.Text, HandControlType);
                        if (table.Rows.Count == 1)
                        {
                            Data.Inventory.IV_CS_OpenRow row = (Data.Inventory.IV_CS_OpenRow)table.Rows[0];
                            DocID = row.Doc_ID;
                            DocType = row.Doc_Type; 
                            DocTypeName = row.Doc_Type_Name;
                            DocStatusID = row.Status_ID;
                            DocStatusName = row.Status_Name;
                            DocDate = row.Doc_Date;
                            RelatedDocID = row.Related_Doc_ID;
                            RecalcID = row.RecalcDoc_ID;

                            if ((DocType == InventoryControlWindow_NEW.INVENTORY_DOC_TYPE || DocType == InventoryControlWindow_IK.INVENTORY_DOC_TYPE) && !row.Allow)
                                MessageBox.Show("У Вас в работе находится другой счетный лист, и он автоматически будет переоткрыт.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            // если все хорошо, закрываем окно
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Процедура проверки штрих-кода не вернула данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbScanner.Focus();
                tbScanner.SelectAll();
            }
            
        }
    }
}
