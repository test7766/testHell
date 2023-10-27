using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Элемент управления для выбора причины корректировки
    /// </summary>
    public partial class ChooseReasonControl : BaseControl
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ChooseReasonControl()
        {
            InitializeComponent();
            Reasons = new List<CorrectionReason>();
            NotSetDefaultReason = true;
        }

        /// <summary>
        /// Список причин корректировки
        /// </summary>
        public List<CorrectionReason> Reasons { get; set; }

        /// <summary>
        /// Признак "Не устанавливать причину по умолчанию"
        /// </summary>
        public bool NotSetDefaultReason { get; set; }

        /// <summary>
        /// Делегат для обработки события смены причины корректировки
        /// </summary>
        /// <param name="newReason">Новая выбранная причина корректировки</param>
        public delegate void ReasonChangedEventHandler(CorrectionReason newReason);
        
        /// <summary>
        /// Событие смены причины корректировки
        /// </summary>
        public event ReasonChangedEventHandler ReasonChanged;

        /// <summary>
        /// Обработчик события загрузки элемента управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoseReasonControl_Load(object sender, EventArgs e)
        {
            cbReasons.DataSource = Reasons;
            if (NotSetDefaultReason)
            {
                cbReasons.SelectedIndex = -1;
                NotSetDefaultReason = false;
            }
        }

        /// <summary>
        /// Обработчик события смены причины корректировки в выпадающем списке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbReasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReasonChanged != null && !NotSetDefaultReason)
            {
                CorrectionReason reason = null;
                if (cbReasons.SelectedIndex >= 0)
                    reason = (CorrectionReason) cbReasons.SelectedItem;
                ReasonChanged(reason);
            }
        }
    }
}
