using System;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Controls;
using WMSOffice.Properties;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class LineSightComplaintForm : Form
    {
        #region АТРИБУТЫ

        /// <summary>
        /// Общие данные по претензии
        /// </summary>
        private Data.Complaints.CurrentDocsRow DocRow { get; set; }

        /// <summary>
        /// Идентификатор текущей сессии пользователя
        /// </summary>
        private long SessionID { get; set; } 

        #endregion

        #region СВОЙСТВА
        
        /// <summary>
        /// Идентификатор претензии
        /// </summary>
        long DocId { get { return DocRow.Doc_ID; } }


        #endregion

        #region КОНСТРУКТОРЫ

        public LineSightComplaintForm()
        {
            InitializeComponent();
            CustomCheckHeader();
            tlsbtnAcceptComplaint.Image = imlIcons.Images[0];
            tlsbtnAcceptComplaintEx.Image = imlIcons.Images[0];
        }

        /// <summary>
        /// Настройка заголовка для CheckBox-колонки тоже в виде CheckBox-а
        /// </summary>
        private void CustomCheckHeader()
        {
            DataGridViewHeaderCheckBoxCell checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += new CheckBoxClickedHandler(checkHeaderCell_OnCheckBoxClicked);
            checkHeaderCell.Value = "";
            dgvComplaintDetails.Columns[0].HeaderCell = checkHeaderCell;
        }

        /// <summary>
        /// Конструктор
        /// <param name="pDocRow">Общие данные по претензии</param>
        /// <param name="pSessionID">Идентификатор текущей сессии пользователя</param>
        public LineSightComplaintForm(Data.Complaints.CurrentDocsRow pDocRow, long pSessionID)
            : this()
        {
            // Нельзя работать с претензией, если мы не можем ее определить
            if (pDocRow == null)
                throw new ArgumentNullException("docRow");

            DocRow = pDocRow;
            SessionID = pSessionID;

            // Заполняем заголовок претензии
            InitComplaintHeader();

            // Заполняем таблицу строками претензии
            RefreshDetailsGrid();

            if (DocRow.Doc_Type.ToLower() == "n3")
            {
                tlsbtnAcceptComplaint.Text = "Принять возврат";
                tlsbtnAcceptComplaintEx.Visible = true;
            }
        }

        /// <summary>
        /// Инициализация заголовка формы (заполнение заголовка формы общими данными по претензии)
        /// </summary>
        private void InitComplaintHeader()
        {
            // В дизайнере меткам были присвоены "наочные значения", но для исключения появления неверных данных, делаем метки пустыми
            lblDocID.Text = lblDocType.Text = lblDocStatus.Text = lblContactName.Text = txbComment.Text = String.Empty;

            // Собственно, заполняем заголовок
            lblDocID.Text = DocRow.Doc_ID.ToString();

            if (!DocRow.IsLinked_Doc_IDNull() && DocRow.Linked_Doc_ID > 0)
            {
                lblLinkedComplaintInfo.Visible = true;
                lblLinkedComplaintInfo.Text = "* СВЯЗЬ С № " + DocRow.Linked_Doc_ID.ToString();
            }

            lblDocStatus.Text = "(" + DocRow.Status_ID + ") " + DocRow.Status_Name;
            lblDocType.Text = "(" + DocRow.Doc_Type + ") " + DocRow.Doc_Type_Name;
            lblSource.Text = String.Format("({0}) {1} {2}", DocRow.Source_Address_Code, DocRow.Source_Address_Name, DocRow.Source_Address);
            
            if (DocRow.Doc_Type.Equals(ComplaintsConstants.ComplaintDocTypeVirtualRefuse, StringComparison.InvariantCultureIgnoreCase))
            {
                lblDestCaption.Visible = lblDest.Visible = true;
                lblDest.Text = String.Format("({0}) {1}", DocRow.Dest_Address_Code, DocRow.Dest_Address_Name);
            }
            
            lblContactName.Text = DocRow.IsContact_NameNull() ? "-" : DocRow.Contact_Name;
            txbComment.Text = DocRow.IsCommentNull() ? "-" : DocRow.Comment;
        }

        /// <summary>
        /// Обновление из базы таблицы со строками претензии
        /// </summary>
        private void RefreshDetailsGrid()
        {
            dtsComplaints.StagesDetails.Clear();
            tbaStagesDetails.Fill(dtsComplaints.StagesDetails, DocRow.Doc_ID, SessionID);

            // Сбрасываем флажок заголовка CheckBox-колонки в False
            (dgvComplaintDetails.Columns[0].HeaderCell as DataGridViewHeaderCheckBoxCell).Select(false);
        }

        #endregion

        #region ЗАГРУЗКА ДАННЫХ ИСТОРИИ

        /// <summary>
        /// Для первой строки претензии (она по умолчанию выбранная) выводим историю визирования
        /// </summary>
        private void LineSightComplaintForm_Shown(object sender, EventArgs e)
        {
            // Если в гриде нет ни одной записи, то выходим из формы\
            if (dgvComplaintDetails.Rows.Count == 0)
            {
                MessageBox.Show("Нет товаров, доступных для визирования!", "Выход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            RefreshHistoryGrid();
        }

        /// <summary>
        /// Обновление истории визирования (при выборе другого товара из списка товаров в претензии)
        /// </summary>
        private void RefreshHistoryGrid()
        {
            long detailId = Convert.ToInt64(dgvComplaintDetails.SelectedRows[0].Cells["dgvtbcDetailsDetailId"].Value);
            dtsComplaints.StagesDetailsHistory.Clear();
            tbaStagesDetailsHistory.Fill(dtsComplaints.StagesDetailsHistory, SessionID,DocId, detailId);

            // В зависимости от статуса устанавливаем пиктограмму и резолюцию для записи в истории
            foreach (DataGridViewRow row in dgvHistory.Rows)
                if (row.Cells["dgvtbcHistoryStageResultId"].Value == DBNull.Value)  // Виза не проставлена
                {
                    row.Cells["dgvimcHistoryPicture"].Value = Resources.yellow_triangle;
                    row.Cells["dgvtbcHistoryStagePeriod"].Value = "Нужна виза для строки";
                }
                else if (row.Cells["dgvtbcHistoryStageResultId"].Value.ToString() == "1" 
                    || row.Cells["dgvtbcHistoryStageResultId"].Value.ToString() == "9" 
                    || row.Cells["dgvtbcHistoryStageResultId"].Value.ToString() == "10")   // Виза положительная
                {
                    row.Cells["dgvimcHistoryPicture"].Value = Resources.ok;
                    row.Cells["dgvtbcHistoryStagePeriod"].Value = "Виза положительная";
                }
                else        // Виза отрицательная
                {
                    row.Cells["dgvimcHistoryPicture"].Value = Resources.close;
                    row.Cells["dgvtbcHistoryStagePeriod"].Value = "Виза отрицательная";
                }
        }

        #endregion

        #region УПРАВЛЕНИЕ ВНЕШНИМ ВИДОМ И ПОВЕДЕНИЕМ ТАБЛИЦ (СО СТРОКАМИ ВИЗИРОВАНИЯ И ИСТОРИЕЙ)

        /// <summary>
        /// Отображает историю визирования по выбранному товару
        /// </summary>
        private void dgvComplaintDetails_SelectionChanged(object sender, EventArgs e)
        {
            // Если выбранных строк нет, то выбираем первую строку
            if (dgvComplaintDetails.SelectedRows.Count == 0)
                return;

            dgvComplaintDetails.DefaultCellStyle.SelectionBackColor =
                Color.FromName(dgvComplaintDetails.SelectedRows[0].Cells["dgvtbcDetailsColor"].Value.ToString());

            // Обновляем историю
            RefreshHistoryGrid();
        }

        /// <summary>
        /// "Выключение" возможности выделения ячеек в таблице с историей визирования
        /// </summary>
        private void dgwHistory_SelectionChanged(object sender, EventArgs e)
        {
            // Выбранных строк нет
            if (dgvHistory.SelectedCells.Count == 0)
                return;

            dgvHistory.SelectedCells[0].Selected = false;
        }

        /// <summary>
        /// Разрисовка строк (в зависимости от состояния визы в строке)
        /// </summary>
        private void dgvComplaintDetails_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvComplaintDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                Color.FromName(dgvComplaintDetails.Rows[e.RowIndex].Cells["dgvtbcDetailsColor"].Value.ToString());
        }

        /// <summary>
        /// Вместо выделения цветом, выделяем строки как в Excel, обводя черным прямоугольником
        /// </summary>
        private void dgvComplaintDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex == dgvComplaintDetails.SelectedRows[0].Index)
                e.Graphics.DrawRectangle(new Pen(Color.Black, 3),
                    new Rectangle(e.RowBounds.X + 1, e.RowBounds.Y, e.RowBounds.Width - 3, e.RowBounds.Height - 3));
        }

        /// <summary>
        /// Чтобы при скроллинге не было багов отрисовки выделенной строки
        /// </summary>
        private void dgvComplaintDetails_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgvComplaintDetails.SelectedRows.Count > 0)
                dgvComplaintDetails.InvalidateRow(dgvComplaintDetails.SelectedRows[0].Index);
        }

        #endregion

        #region СОХРАНЕНИЕ РЕЗУЛЬТАТОВ ВИЗИРОВАНИЯ В БАЗУ

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void checkHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow detailsRow in dgvComplaintDetails.Rows)
                (detailsRow.Cells[0] as DataGridViewCheckBoxCell).Value = pState;

            dgvComplaintDetails.RefreshEdit();
        }

        /// <summary>
        /// Сохранение результата визирования "Виза положительная" по всем строкам в транзакции
        /// </summary>
        private void btnAcceptComplaint_Click(object sender, EventArgs e)
        {
            // Проверим валидность комментария
            if (!IsCommentSatisfactory(true))
                return;

            try
            {
                int pAccessComplaint = 1;
                if(DocRow.Doc_Type.ToLower() == "n3")
                    pAccessComplaint = 9;

                SaveComplaintItemsResolution(pAccessComplaint);
                RefreshGrids();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сохранение результата визирования "Виза положительная" по всем строкам в транзакции
        /// </summary>
        private void btnAcceptComplaintEx_Click(object sender, EventArgs e)
        {
            // Проверим валидность комментария
            if (!IsCommentSatisfactory(true))
                return;

            try
            {
                SaveComplaintItemsResolution(10);
                RefreshGrids();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        /// <summary>
        /// Сохранение результата визирования "Виза отрицательная" по всем строкам в транзакции
        /// </summary>
        private void btnDeclineComplaint_Click(object sender, EventArgs e)
        {
            // Проверим валидность комментария
            if (!IsCommentSatisfactory(false))
                return;

            try
            {
                SaveComplaintItemsResolution(false);
                RefreshGrids();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Сохраняет результат визирования для всех выделенных строк в таблице товаров
        /// </summary>
        /// <param name="pAccessComplaint">True, если виза положительная, False если отрицательная</param>
        private void SaveComplaintItemsResolution(bool pAccessComplaint)
        {
            // Сохраняем результат визирования для всех выделенных строк
            dgvComplaintDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow detailRow in dgvComplaintDetails.Rows)
                if (Convert.ToBoolean(detailRow.Cells[0].Value) == true)
                    tbaStagesDetails.SaveComplaintItemResolution(
                        Convert.ToInt64(detailRow.Cells["dgvtbcDetailsDetailId"].Value),
                        pAccessComplaint ? 1 : 2,
                        Convert.ToDouble(detailRow.Cells["dgvtbcDetailsQuantity"].Value),
                        txbCommentSightLines.Text,
                        SessionID
                        );
        }

        /// <summary>
        /// Сохраняет результат визирования для всех выделенных строк в таблице товаров
        /// </summary>
        /// <param name="pStageResultId">1, если виза положительная, 2 если отрицательная, 9 Положительная виза (Возврат),10 Положительная виза (Компенсация)</param>
        private void SaveComplaintItemsResolution(int pStageResultId)
        {
            // Сохраняем результат визирования для всех выделенных строк
            dgvComplaintDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow detailRow in dgvComplaintDetails.Rows)
                if (Convert.ToBoolean(detailRow.Cells[0].Value) == true)
                    tbaStagesDetails.SaveComplaintItemResolution(
                        Convert.ToInt64(detailRow.Cells["dgvtbcDetailsDetailId"].Value),
                        pStageResultId,
                        Convert.ToDouble(detailRow.Cells["dgvtbcDetailsQuantity"].Value),
                        txbCommentSightLines.Text,
                        SessionID
                        );
        }

        /// <summary>
        /// Метод проверяет валидность комментария к визе
        /// </summary>
        /// <param name="pAcceptComplaint">True, если виза положительная, False если отрицательная</param>
        /// <returns>True, если комментарий валидный, можно сохранять результат визирования, False - комментарий надо править</returns>
        private bool IsCommentSatisfactory(bool pAcceptComplaint)
        {
            // Комментарий нужен как при отрицательной, так и при положительной визе
            if (!pAcceptComplaint && txbCommentSightLines.Text.Length == 0)
            {
                MessageBox.Show("Обязательно нужен комментарий к визе!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Ставим ограничение на длину комментарий в 500 символов
            if (txbCommentSightLines.Text.Length >= 500)
            {
                MessageBox.Show("Слишком длинный комментарий!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsCorrectComment(txbCommentSightLines.Text))
            {
                MessageBox.Show("Комментарий не содержит адекватный текст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Все нормально, комментарий прошел проверку
            return true;
        }

        /// <summary>
        /// Проверка, содержит ли комментарий полную чушь, либо в нем все-таки есть буквы
        /// </summary>
        /// <param name="pComment">Комментарий, который нужно проверить</param>
        /// <returns>True, если в комментарии есть не менее двух букв, False в противном случае</returns>
        private static bool IsCorrectComment(string pComment)
        {
            int count = 0;
            foreach (char c in pComment)
                if ((c >= 'a' && c <= 'z') ||
                    (c >= 'A' && c <= 'Z') ||
                    (c >= 'а' && c <= 'я') ||
                    (c >= 'А' && c <= 'Я'))
                    count++;

            return count >= 2;
        }

        /// <summary>
        /// Загружает заново строки претензии и историю после сохранения результата визирования, а также очищает поле комментария
        /// </summary>
        private void RefreshGrids()
        {
            // Обновляем цвет строк визирования (запоминая номер выделенной строки)
            int selectedIndex = dgvComplaintDetails.SelectedRows[0].Index;
            RefreshDetailsGrid();
            dgvComplaintDetails.Rows[selectedIndex].Selected = true;

            // Обновляем таблицу с историей визирования и обнуляем поле комментария
            RefreshHistoryGrid();
            txbCommentSightLines.Text = "";
        }

        /// <summary>
        /// Вызов процедуры закрытия построчного визирования при закрытии диалога
        /// </summary>
        private void LineSightComplaintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tbaStagesDetails.SaveComplaintTotalResolution(SessionID, DocRow.Doc_ID);
        }

        #endregion         

    }
}
