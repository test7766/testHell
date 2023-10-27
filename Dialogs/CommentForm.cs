using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs
{
    /// <summary>
    /// Окно для ввода либо отображения комментария
    /// </summary>
    public partial class CommentForm : Form
    {
        /// <summary>
        /// Текст, который отображается как приглашение к вводу комментария
        /// </summary>
        public string CommentLabel
        {
            get { return lblComment.Text; }
            set { lblComment.Text = value; }
        }

        /// <summary>
        /// Введенный/отображенный комментарий
        /// </summary>
        public string Comment 
        { 
            get { return tbxComment.Text; }
            set { tbxComment.Text = value; }
        }

        /// <summary>
        /// True если нужно запретить сохранять пустой комментарий
        /// False - если можно сохранять пустой комментарий
        /// </summary>
        public bool CheckForEmptyValue { get; set; }

        public CommentForm(bool pOnlyForDisplay)
        {
            InitializeComponent();
            if (pOnlyForDisplay)
                EnableOnlyDisplayingMode();
            tbxComment.Focus();
        }

        /// <summary>
        /// Включение режима только для отображения
        /// </summary>
        private void EnableOnlyDisplayingMode()
        {
            btnSave.Visible = btnCancel.Visible = lblComment.Visible = false;
            tbxComment.ReadOnly = true;
            tbxComment.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// При загрузке ставим фокус на поле комментария
        /// </summary>
        private void CommentForm_Load(object sender, EventArgs e)
        {
            tbxComment.Focus();
        }

        /// <summary>
        /// Закрываем окно с положительным результатом
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckForEmptyValue && String.IsNullOrEmpty(Comment))
            {
                Logger.ShowErrorMessageBox("Нужно обязательно ввести текст!");
                return;
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
