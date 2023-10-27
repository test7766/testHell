using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs
{
    public partial class RichListForm : DialogForm
    {
        public RichListForm()
        {
            InitializeComponent();
            gvSelect.AutoGenerateColumns = false;
            ColumnForFilters = new List<string>();
            FilterChangeLevel = 3;
            RussianCulture = true;
            AllowSearchByEmptyFilter = false;
        }

        #region filter

        /// <summary>
        /// Установка недоступности фильтра
        /// </summary>
        public bool DisableFilter
        {
            set
            {
                tbFilter.ReadOnly = value;
                if (value)
                {
                    pnlFilter.Visible = false;
                    gvSelect.Top = pnlFilter.Top;
                    gvSelect.Height += pnlFilter.Height;
                }
            }
        }

        /// <summary>
        /// Признак поиска по пустому фильтру (по умолчанию)
        /// </summary>
        public bool AllowSearchByEmptyFilter { get; set; }

        public string Filter
        {
            get { return tbFilter.Text; }
            set { tbFilter.Text = value; }
        }

        public bool FilterVisible
        {
            get { return pnlFilter.Visible; }
            set { pnlFilter.Visible = value; }
        }

        //public void FocusFilter()
        //{
        //    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
        //    tbFilter.SelectAll();
        //    tbFilter.Focus();
        //}

        //public DialogResult ShowDialog(bool focusFilter)
        //{
        //    this.ShowDialog();
        //}

        public int FilterChangeLevel { get; set; }

        /// <summary>
        /// Список названий колонок, по которым возможен поиск/фильтр
        /// </summary>
        public List<string> ColumnForFilters { get; set; }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (tbFilter.Text.Length >= FilterChangeLevel || 
                // режим поиска по пустому фильтру
                (AllowSearchByEmptyFilter && tbFilter.Text.Length == 0))
                if (FilterChanged != null)
                    // позволяем в родительском окне сделать запрос для получения отфильтрованных данных
                    FilterChanged(this, e);
                else
                {
                    // позволяем фильтровать данные в списке по нескольким колонкам
                    string rowFilter = "";
                    foreach (string column in ColumnForFilters)
                    {
                        if (!String.IsNullOrEmpty(rowFilter)) rowFilter += " OR ";
                        rowFilter += column + " like '%" + tbFilter.Text.Replace("%", "_") + "%'";
                    }
                        
                    if (gvSelect.DataSource is DataTable)
                        ((DataTable)gvSelect.DataSource).DefaultView.RowFilter = rowFilter;
                }
        }

        public event EventHandler FilterChanged;

        #endregion

        #region list

        public object DataSource
        {
            get { return gvSelect.DataSource; }
            set { gvSelect.DataSource = value; }
        }

        /// <summary>
        /// Свойство, для доступа к колонкам списка выбора
        /// </summary>
        public DataGridViewColumnCollection Columns
        {
            get { return gvSelect.Columns; }
        }

        public string ValueField { get; set; }

        public object SelectedValue { get; set; }

        /// <summary>
        /// Возвращаем текущее положение (выделенную строку)
        /// </summary>
        public object SelectedRow 
        { 
            get {
                if (gvSelect.SelectedRows.Count != 1)
                    return null;
                else
                    return ((DataRowView)gvSelect.SelectedRows[0].DataBoundItem).Row;
            }
            //set { 
            //    foreach (DataGridViewRow row in gvSelect.Rows)
            //        if (((DataRowView)row.DataBoundItem)[ValueField].Equals(value))
            //        {
            //            row.Selected = true;
            //            break;
            //        }
            //} 
        }

        /// <summary>
        /// Признак отображения справочника без выбранного элемента
        /// </summary>
        public bool ShowGridViewItemsWithoutSelection { get; set; }


        #endregion

        /// <summary>
        /// Установить режим отображения словаря как представление данных (без возможности выбора)
        /// </summary>
        public void SetDictionaryViewMode()
        {
            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";
        }

        private void RichListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (gvSelect.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Не выбрана ни одна строка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Свойство, которое определяет переключать ли по-умолчанию на русскую локализацию (удобно для поиска)
        /// </summary>
        public bool RussianCulture { get; set; }

        /// <summary>
        /// Обработчик события отображения формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichListForm_Shown(object sender, EventArgs e)
        {
            // устанавливаем русскую локализацию для поиска
            if (RussianCulture)
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
            else 
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));

            btnOK.Location = new Point(350, 8);
            btnCancel.Location = new Point(440, 8);

            // отображаем фильтр
            if (FilterVisible)
            {
                tbFilter.Focus();
                tbFilter.SelectAll();
            }
            else gvSelect.Focus();
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                gvSelect.Focus();
            }
        }

        private void gvSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            DialogResult = DialogResult.OK;
            Close(); 
        }

        private void gvSelect_KeyDown(object sender, KeyEventArgs e)
        {
            // запрещаем вводить любой текст, находясь в списке выбора
            // это защита от случайного выбора позиции путем следующего сканирования
            if (
                (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
               )
                MessageBox.Show("Запрещено вводить любой текст в список выбора!\n\rВозможно, Вы случайно отсканировали штрих-код?!", "Запрет ввода", MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Exclamation);
            else 
            //if (e.KeyData == Keys.Left)
            //{
            //    tbFilter.Focus();
            //} else 
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DialogResult = DialogResult.OK;
                Close();                
            } //else if (e.KeyData == Keys.Down || e.KeyData == Keys.Up || e.KeyData == Keys.Left || e.KeyData == Keys.Right || e.KeyData == Keys.
            
        }

        private void gvSelect_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //{
            //    DialogResult = DialogResult.OK;
            //    Close();                
            //}
        }

        /// <summary>
        /// Добавление колонки с заданными параметрами
        /// </summary>
        /// <param name="pName">Имя новой колонки</param>
        /// <param name="pDataPropertyName">Название свойства в таблице, к которому биндится колонка</param>
        /// <param name="pHeaderText">Отображаемый заголовок колонки</param>
        public void AddColumn(string pName, string pDataPropertyName, string pHeaderText)
        {
            Columns.Add(new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DataPropertyName = pDataPropertyName,
                HeaderText = pHeaderText,
                Name = pName,
                ReadOnly = true
            });
        }

        private void gvSelect_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.ShowGridViewItemsWithoutSelection)
            {
                gvSelect.RowHeadersVisible = false;
                if (gvSelect.Rows.Count > 0)
                    gvSelect.Rows[0].Selected = false;
            }

            if (gvSelect.DataSource != null && gvSelect.DataSource is DataTable)
            {
                // Разрисовка строк в таблице
                foreach (DataGridViewRow row in gvSelect.Rows)
                {
                    DataRow dr = (row.DataBoundItem as DataRowView).Row;

                    if (ValueField != null && dr[ValueField].Equals(SelectedValue))
                        row.Selected = true;

                    // Простая разрисовка строк
                    if (dr.Table.Columns.Contains("Color"))
                    {
                        Color backColor = (dr["Color"] == DBNull.Value ||
                                           string.IsNullOrEmpty(dr["Color"].ToString()) ||
                                           dr["Color"].ToString().ToLower() == "white")
                                              ? Color.White
                                              : Color.FromName(dr["Color"].ToString());

                        for (int c = 0; c < row.Cells.Count; c++)
                        {
                            row.Cells[c].Style.BackColor = backColor;
                            row.Cells[c].Style.SelectionForeColor = backColor;
                        }
                    }
                }
            }
                
        }
    }
}
