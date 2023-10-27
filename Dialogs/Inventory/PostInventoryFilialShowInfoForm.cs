using System;
using System.Windows.Forms;

using WMSOffice.Classes;
using System.Data;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Окно для просмотра информации по взаимозачетам и приходованиям
    /// </summary>
    public partial class PostInventoryFilialShowInfoForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Инвентаризационный документ, по которому просматривается информация
        /// </summary>
        private readonly Data.Inventory.FP_Get_Correction_DocumentsRow docRow;

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly int sessionID;

        /// <summary>
        /// Название для таблицы в конфиг файле
        /// </summary>
        private string CorrectionTableConfigName { get { return String.Format("{0}_Correction", Name); } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public PostInventoryFilialShowInfoForm(int pSessionID, Data.Inventory.FP_Get_Correction_DocumentsRow pDoc)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docRow = pDoc;
            if (pDoc.CorrectionType == "CO")
            {
                Text = "Оприходованные излишки";
                //clDeFt.Visible = false;
            }

            if (pDoc.CorrectionType == "CN")
                Text = "Пересорт";
        }

        /// <summary>
        /// Загрузка данных при загрузке окна
        /// </summary>
        private void PostInventoryFilialShowInfoForm_Load(object sender, EventArgs e)
        {
            LoadCorrections();
            Config.LoadDataGridViewSettings(CorrectionTableConfigName, dgvCorrection);
        }

        /// <summary>
        /// Загрузка взаимозачетов
        /// </summary>
        private void LoadCorrections()
        {
            try
            {
                taFpGetCorrectionDetails.Fill(inventory.FP_Get_Correction_Details, sessionID, docRow.___документа);
                SetRowColor();
            }
            catch (Exception exc)
            {
                string str = docRow.CorrectionType == "CO" ? "Ошибка при загрузке оприходованных излишков!" :
                    "Ошибка при загрузке проведенных взаимозачетов!";
                Logger.ShowErrorMessageBox(str, exc);
            }
        }

        private void SetRowColor()
        {
            try
            {
                foreach (DataGridViewRow gridRow in dgvCorrection.Rows)
                {
                    gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;

                    var row = (gridRow.DataBoundItem as DataRowView).Row as WMSOffice.Data.Inventory.FP_Get_Correction_DetailsRow;
                    if (row == null || row._Кол_во >= 0)
                        continue;

                    gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region ЭКСПОРТ В EXCEL И СОХРАНЕНИЕ НАСТРОЕК

        /// <summary>
        /// Экспорт отображенного грида в Excel
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportHelper.ExportDataGridViewToExcel(dgvCorrection,
                    docRow.CorrectionType == "CO" ? "Экспорт оприходованных излишков" : "Экспорт результатов взаимозачета",
                    docRow.CorrectionType == "CO" ? "приходование" : "взаимозачет", true); 
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время экспорта в Excel!", exc);
            }
        }

        /// <summary>
        /// Сохранение настроек при выходе из окна
        /// </summary>
        private void PostInventoryFilialShowInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(CorrectionTableConfigName, dgvCorrection);
        }

        #endregion


        private void dgvCorrection_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            
        }

        private void dgvCorrection_Sorted(object sender, EventArgs e)
        {
            SetRowColor();
        }
    }
}
