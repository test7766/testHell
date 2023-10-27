using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно добавления нового замечания от ГЛС
    /// </summary>
    public partial class NewGlsRemarkForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Идентификатор заявки, по которой вносится замечание
        /// </summary>
        private readonly long docID;

        /// <summary>
        /// Идентификатор строки заявки, для которой вносится замечание либо null, если замечание вносится по строке
        /// (в этом случае нужно отметить флажками строки заявки, на которые устанавливается замечание)
        /// </summary>
        private readonly int? lineID;

        private readonly int parentRemarkTypeID;

        private readonly string parentDescription;

        private readonly string parentGlsExpert;

        private readonly bool resumeMode;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public NewGlsRemarkForm(long pSessionID, long pDocID, int? pLineID)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docID = pDocID;
            lineID = pLineID;

            if (pLineID.HasValue)
                SetDocLineMode();
        }

        public NewGlsRemarkForm(long pSessionID, long pDocID, int? pLineID, int pParentRemarkTypeID, string pParentDescription, string pParentGlsExpert)
            : this(pSessionID, pDocID, pLineID)
        {
            parentRemarkTypeID = pParentRemarkTypeID;
            parentDescription = pParentDescription;
            parentGlsExpert = pParentGlsExpert;

            SetDocLineMode();
            resumeMode = true;
        }

        /// <summary>
        /// Переключение контролов окна в режим установки замечания для одной строки заявки 
        /// (должен отсутствовать выбор строк для установки замечания)
        /// </summary>
        private void SetDocLineMode()
        {
            btnOK.Anchor = btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dgvDetails.Visible = lblDetails.Visible = false;
            btnOK.Location = new Point(483, 189);
            btnCancel.Location = new Point(564, 189);
            Size = new Size(662, 262);
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        /// <summary>
        /// Загрузка типов замечаний от ГЛС при загрузке окна
        /// </summary>
        private void NewGlsRemarkForm_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(LoadRemarkTypes()))
                Close();
            LoadGlsExperts();

            if (!lineID.HasValue && !resumeMode)
                LoadDetails();

            if (resumeMode)
            {
                tbxDescription.Text = parentDescription;
            }
        }

        /// <summary>
        /// Загрузка доступных типов замечаний от ГЛС
        /// </summary>
        /// <returns>Сообщение об ошибке либо пустая строка, если загрузка прошла успешно</returns>
        private string LoadRemarkTypes()
        {
            try
            {
                taQkGLSRemarkTypes.Fill(quality.QK_GLS_Remark_Types, sessionID);
                if (quality.QK_GLS_Remark_Types.Count == 0)
                    return "Нет ни одного доступного для выбора типа замечания от ГЛС. Дальнейшая работа с окном невозможна";
                else
                {
                    if (resumeMode)
                    {
                        bool found = false;
                        foreach (Data.Quality.QK_GLS_Remark_TypesRow row in quality.QK_GLS_Remark_Types)
                        {
                            if (row.remark_type_id == parentRemarkTypeID)
                            {
                                cmbRemarkType.SelectedValue = parentRemarkTypeID;
                                cmbRemarkType.Enabled = false;
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            cmbRemarkType.SelectedItem = null;
                    }

                    return String.Empty;
                }
            }
            catch (Exception exc)
            {
                return "Возникла ошибка во время загрузки допустимых типов замечаний от ГЛС. Дальнейшая работа с окном невозможна"
                    + Environment.NewLine + exc.Message;
            }
        }

        /// <summary>
        /// Загрузка доступных экспертов ГЛС в выпадающий список
        /// </summary>
        private void LoadGlsExperts()
        {
            try
            {
                taQkGetExperts.Fill(quality.QK_Get_Experts, sessionID, docID);
                bool found = false;
                foreach (Data.Quality.QK_Get_ExpertsRow row in quality.QK_Get_Experts)
                {
                    if (row.used_for_request)
                    {
                        cmbGlsExpert.SelectedValue = row.gls_expert;
                        found = true;
                        break;
                    }
                    else if (resumeMode)
                    {
                        if (!row.Isgls_expertNull() && row.gls_expert.ToUpper() == parentGlsExpert.ToUpper())
                        {
                            cmbGlsExpert.SelectedValue = parentGlsExpert;
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                    cmbGlsExpert.SelectedItem = null;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка экспертов ГЛС: ", exc);
            }
        }

        /// <summary>
        /// Загрузка строк заявки, на которые можно поставить замечание
        /// </summary>
        private void LoadDetails()
        {
            try
            {
                taQkDocsDetailForRemark.Fill(quality.QK_Docs_Detail_For_Remark, sessionID, docID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки строк заявки:", exc);
            }
        }

        /// <summary>
        /// Изменение описания замечания (критическое/некритическое) при изменении выбранного типа замечания в выпадающем списке
        /// </summary>
        private void cmbRemarkType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbRemarkType.SelectedItem == null)
                return;
            var type = (cmbRemarkType.SelectedItem as DataRowView).Row as Data.Quality.QK_GLS_Remark_TypesRow;
            lblCritical.Text = type.is_critical ? "Критичне" : "Некритичне";
        }

        #endregion

        #region ПРОВЕРКА ПРАВИЛЬНОСТИ ДАННЫХ И ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// Идентификатор выбранного в выпадающем списке типа замечания
        /// </summary>
        public int RemarkTypeID { get { return Convert.ToInt32(cmbRemarkType.SelectedValue); } }

        /// <summary>
        /// Описание замечания от ГЛС
        /// </summary>
        public string Description { get { return tbxDescription.Text; } }

        /// <summary>
        /// Эксперт ГЛС, который ведет заявку
        /// </summary>
        public string GlsExpert { get { return String.IsNullOrEmpty(cmbGlsExpert.Text) ? null : cmbGlsExpert.Text; } }

        /// <summary>
        /// Строки заявки, на которые распространяется замечание от ГЛС
        /// </summary>
        public Data.Quality.QK_Docs_Detail_For_RemarkRow[] CheckedRows
        {
            get
            {
                var result = new List<Data.Quality.QK_Docs_Detail_For_RemarkRow>();
                foreach (var row in quality.QK_Docs_Detail_For_Remark)
                    if ((row as Data.Quality.QK_Docs_Detail_For_RemarkRow)._checked)
                        result.Add(row as Data.Quality.QK_Docs_Detail_For_RemarkRow);
                return result.ToArray();
            }
        }

        /// <summary>
        /// Проверка данных и закрытие окна с положительным результатом
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка, корректны ли все введенные данные по замечанию от ГЛС
        /// </summary>
        /// <returns>True если все данные заданы правильно, False если есть ошибки</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;
            if (cmbRemarkType.SelectedItem == null)
                msg = "Нужно выбрать тип замечания от ГЛС!";
            else if (!resumeMode && !lineID.HasValue && CheckedRows.Length == 0)
                msg = "Нужно отметить хотя бы одну строку заявки!";

            if (String.IsNullOrEmpty(msg))
                return true;
            else
            {
                Logger.ShowErrorMessageBox(msg);
                return false;
            }
        }

        #endregion
    }
}
