using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    /// <summary>
    /// Диалог для отображения недостающих строк из сборочного
    /// </summary>
    public partial class IBPSDifferenceForm : DialogForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        /// <param name="pickSlipNumber">Номер сборочного листа</param>
        /// <param name="docID">Идентификатор документа</param>
        public IBPSDifferenceForm(long pickSlipNumber, long docID)
        {
            InitializeComponent();

            lblCaption.Text = string.Format(lblCaption.Text, pickSlipNumber);

            using (Data.InterbranchTableAdapters.PSDifferenceTableAdapter adapter = new Data.InterbranchTableAdapters.PSDifferenceTableAdapter())
            {
                dgvDifferences.DataSource = adapter.GetData(docID);
            }
        }
    }
}
