using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        /// <summary>
        /// Возвращает признак, показывающий, "отмечен" ли флажок в ячейке-заголовке.
        /// </summary>
        public bool IsChecked { get; private set; }

        public DataGridViewCheckBoxHeaderCellEventArgs(bool isChecked)
        {
            this.IsChecked = isChecked;
        }
    }
    
    /// <summary>
    /// Реализует ячейку-заголовок для DataGridView, содержащую флажок для быстрого изменения состояния всех флажков в столбце.
    /// </summary>
    public class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState = System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;

        public System.Windows.Forms.VisualStyles.CheckBoxState CheckBoxState
        {
            get { return _cbState; }
            set
            {
                _cbState = value; 
                
                if (CheckBoxClicked != null)
                {
                    CheckBoxClicked(this, new DataGridViewCheckBoxHeaderCellEventArgs(_checked));
                    this.DataGridView.InvalidateCell(this);
                }
            }
        }

        /// <summary>
        /// Возникает при клике по флажку.
        /// </summary>
        public event EventHandler<DataGridViewCheckBoxHeaderCellEventArgs> CheckBoxClicked;

        /// <summary>
        /// Возможность редактирования
        /// </summary>
        private bool allowEdit = true;

        /// <summary>
        /// Инициализирует новый экземляр класса DatagridViewCheckBoxHeaderCell (ячейка-заголовок для DataGridView, содержащая флажок для быстрого изменения состояния всех флажков в столбце).
        /// </summary>
        public DatagridViewCheckBoxHeaderCell()
            : this(true)
        {
        }

        public DatagridViewCheckBoxHeaderCell(bool pAllowEdit)
        {
            allowEdit = pAllowEdit; 
        }

        public void ChangeEditState(bool pAllowEdit)
        {
            if (!(allowEdit = pAllowEdit))
                _checked = false;

            this.DataGridView.InvalidateCell(this);
        }

        public void ChangeCheckState(bool isChecked)
        {
            _checked = isChecked;
            this.DataGridView.InvalidateCell(this);
        }

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds,
            int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds,
                rowIndex, dataGridViewElementState, value, string.Empty, errorText,
                cellStyle, advancedBorderStyle, paintParts);
            
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics, System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X + (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y + (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = allowEdit ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.CheckedDisabled;
            else
                _cbState = allowEdit ? System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedDisabled;
            
            CheckBoxRenderer.DrawCheckBox(graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <= checkBoxLocation.X + checkBoxSize.Width
                && p.Y >= checkBoxLocation.Y && p.Y <= checkBoxLocation.Y + checkBoxSize.Height)
            {
                if (allowEdit)
                {
                    _checked = !_checked;
                    if (CheckBoxClicked != null)
                    {
                        CheckBoxClicked(this, new DataGridViewCheckBoxHeaderCellEventArgs(_checked));
                        this.DataGridView.InvalidateCell(this);
                    }
                }
            }
            base.OnMouseClick(e);
        }
    }
}
