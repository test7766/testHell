using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Редактор [...]
    /// </summary>
    public partial class EllipsisGridCellEditorControl : UserControl, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private int rowIndex;
        private bool valueChanged = false;

        public event EventHandler ShowSelector
        {
            add 
            { 
                this.btnShowSelector.Click += value;
                this.NeedShowSelector += value;
            }
            remove 
            { 
                this.btnShowSelector.Click -= value;
                this.NeedShowSelector -= value;
            }
        }

        public event EventHandler NeedShowSelector;

        public event EventHandler OnSelectorOpening;

        public event EventHandler DeleteRowInside;

        public event EventHandler InsertNewLine;

        public event EventHandler PasteData;

        protected virtual void OnPasteData()
        {
            EventHandler handler = PasteData;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected TextBox TextEditor { get { return this.tbValue; } }

        /// <summary>
        /// Значение из элемента ввода
        /// </summary>
        public String Value
        {
            get { return this.TextEditor.Text.Trim() == String.Empty ? null : this.TextEditor.Text; }
            set
            {
                tbValue.Text = value;
                this.PreviousValue = value;
            }
        }

        /// <summary>
        /// Предыдущее значение редактора ввода (для минимизации кол-ва проверок соответствия элементам справочника)
        /// </summary>
        protected String PreviousValue = null;

        public event EventHandler OnVerifyValue;


        public EllipsisGridCellEditorControl()
        {
            InitializeComponent();
            Load += new EventHandler(EllipsisGridCellEditorControl_Load);
            tbValue.TextChanged += new EventHandler(tbValue_TextChanged);
            tbValue.KeyDown += new KeyEventHandler(tbValue_KeyDown);
            tbValue.Leave += new EventHandler(tbValue_Leave);
            tbValue.MouseLeave +=new EventHandler(tbValue_MouseLeave);
            tbValue.KeyUp += new KeyEventHandler(tbValue_KeyUp);

            new ToolTip().SetToolTip(btnShowSelector, "Выбрать из справочника");
        }

        void tbValue_Leave(object sender, EventArgs e)
        {
            VerifyValue();
        }

        private void tbValue_MouseLeave(object sender, EventArgs e)
        {
            VerifyValue();
        }

        void tbValue_KeyUp(object sender, KeyEventArgs e)
        {
            //Вставка текста  в контрол с момощью Ctrl+V
            //TextBox t = (TextBox)sender;
            //if (e.KeyData == (Keys.V | Keys.Control))
            //{
            //    t.Paste();
            //    e.Handled = true;
            //}
        }

        void tbValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                VerifyValue();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.PageUp)
                if (OnSelectorOpening != null)
                    OnSelectorOpening(this, EventArgs.Empty);
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
                if (DeleteRowInside != null)
                    DeleteRowInside(this, EventArgs.Empty);
            if (e.KeyCode == Keys.Insert)
                if (InsertNewLine != null)
                    InsertNewLine(this, EventArgs.Empty);
            if (e.KeyCode == Keys.F2)
                OnNeedShowSelector();
        }

        private void btnShowSelector_Enter(object sender, EventArgs e)
        {
            if (this.OnSelectorOpening != null)
                this.OnSelectorOpening(this, EventArgs.Empty);
        }

        /// <summary>
        /// Возникновение события необходимости отображения выпадающего справочника
        /// </summary>
        protected void OnNeedShowSelector()
        {
            if (this.NeedShowSelector != null)
                this.NeedShowSelector(this, EventArgs.Empty);
        }

        private void VerifyValue()
        {
            string value = this.Value == null ? null : this.Value.Trim('\r', '\n');
            if (value == this.PreviousValue)
                return;

            this.PreviousValue = value;

            if (this.OnVerifyValue != null)
                this.OnVerifyValue(this, EventArgs.Empty);
        }

        void EllipsisGridCellEditorControl_Load(object sender, EventArgs e)
        {
            tbValue.Focus();
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            this.valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

        #region Реализация интерфейса IDataGridViewEditingControl
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public DataGridView EditingControlDataGridView
        {
            get { return this.dataGridView; }
            set { this.dataGridView = value; }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                if (tbValue.Text.Trim() == string.Empty)
                    return string.Empty;//DBNull.Value;

                return this.tbValue.Text;
            }
            set
            {
                if (value is String)
                    this.tbValue.Text = value.ToString();
            }
        }

        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return this.valueChanged; }
            set { this.valueChanged = value; }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return false;
            }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // Никаких действий не делаем
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }
        #endregion
    }

    /// <summary>
    /// Ячейка для редактора [...]
    /// </summary>
    public class EllipsisEditorCell : DataGridViewTextBoxCell
    {
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            EllipsisGridCellEditorControl cellEditor = this.DataGridView.EditingControl as EllipsisGridCellEditorControl;
            cellEditor.EditingControlFormattedValue = (this.Value != System.DBNull.Value && this.Value != null) ? this.Value.ToString() : string.Empty;
        }


        public override Type EditType
        {
            get { return typeof(EllipsisGridCellEditorControl); }
        }

        public override Type ValueType
        {
            get { return typeof(string); }
        }

        public override object DefaultNewRowValue
        {
            get { return string.Empty; }
        }
    }

    /// <summary>
    /// Колонка для редактора [...]
    /// </summary>
    public class DataGridViewEllipsisEditColumn : DataGridViewColumn
    {
        public DataGridViewEllipsisEditColumn()
            : base(new EllipsisEditorCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(EllipsisEditorCell)))
                    throw new InvalidCastException("Must be a CustomEditorCell");

                base.CellTemplate = value;
            }
        }
    }
}
