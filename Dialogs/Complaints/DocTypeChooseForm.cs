using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Позволяет выбрать один из доступных пользователю типов претензий для создания новой претензии.
    /// </summary>
    public partial class DocTypeChooseForm : DialogForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="sessionID">Идентификатор сессии пользователя.</param>
        public DocTypeChooseForm(long sessionID)
        {
            InitializeComponent();

            availableDocsTypesTableAdapter.Fill(complaints.AvailableDocsTypes, sessionID, true, null);
        }

        /// <summary>
        /// Возвращает идентификатор выбранного типа претензии.
        /// </summary>
        public string SelectedDocTypeID { get { return complaints.AvailableDocsTypes[cbDocTypes.SelectedIndex].Doc_Type; } }
        /// <summary>
        /// Возвращает название выбранного типа претензии.
        /// </summary>
        public string SelectedDocTypeName { get { return complaints.AvailableDocsTypes[cbDocTypes.SelectedIndex].Doc_Type_Name; } }

        /// <summary>
        /// Обрабатывает момент первого отображения диалога.
        /// </summary>
        private void DocTypeChooseForm_Shown(object sender, EventArgs e)
        {
            this.btnOK.Location = new Point(85, 8);
            this.btnCancel.Location = new Point(166, 8);


            if (complaints.AvailableDocsTypes.Count == 0)
            {
                MessageBox.Show("У вас нет ни одного доступного типа претензии для создания новой претензии. Обратитесь в Группу сопровождения ПО.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
