using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErrorHandlerDialog
{
    public partial class ComplexRowErrorsDialog : Form
    {
        private List<Error> ds;

        public string ErrorCaption { set { this.Text = value; } }
        public string ErrorDescription { set { this.lblErrorWindowDescription.Text = value; } }

        public List<Error> ErrorDataSource
        {
            set { this.ds = value; }
        }

        public ComplexRowErrorsDialog()
        {
            InitializeComponent();
            this.ErrorCaption = string.Empty;
            this.ErrorDescription = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbErrors.DataSource = ds;            
        }

        private void lbErrors_SelectedValueChanged(object sender, EventArgs e)
        {
            lbErrorsDesriptions.DataSource = (lbErrors.SelectedItem as Error).ErrorItems;
        }

        private void lbErrors_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbErrors.Items.Count == 0)
                return;

            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            var selectedForeColor = SystemColors.Highlight;

            Error item = lbErrors.Items[e.Index] as Error;
            var unselectedForeColor = item.Critical ? Color.Red : Color.Yellow;
            var foreColor = selected ? selectedForeColor : unselectedForeColor;

            // Заливка фона
            e.DrawBackground();

            // Раскраска текущей строки в необходимый цвет
            using (SolidBrush sb = new SolidBrush(foreColor))
                e.Graphics.FillRectangle(sb, e.Bounds);

            // Раскраска текста текущей строки
            using (SolidBrush sb = new SolidBrush(Color.Black))
                e.Graphics.DrawString(item.Number, e.Font, sb, e.Bounds, StringFormat.GenericDefault);

            // Для текущей выделенной выделенной строки формируем метку с требуемым цветом
            if (selected)
            {
                int indent = 5;
                int rectSize = e.Bounds.Height - 2 * indent;
                int rectLocX = e.Bounds.Right - e.Bounds.Height + indent;
                int rectLocY = e.Bounds.Top + indent;

                e.Graphics.FillRectangle(new SolidBrush(unselectedForeColor), new Rectangle(rectLocX, rectLocY, rectSize, rectSize));
            }

            // Заливка выделенной строки
            e.DrawFocusRectangle();
        }

        private void lbErrorsDesriptions_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbErrorsDesriptions.Items.Count == 0)
                return;

            ErrorItemDescription item = lbErrorsDesriptions.Items[e.Index] as ErrorItemDescription;

            e.DrawBackground();

            using (SolidBrush sb = new SolidBrush(SystemColors.Window))
                e.Graphics.FillRectangle(sb, e.Bounds);

            using (SolidBrush sb = new SolidBrush(Color.Red))
                e.Graphics.DrawString(item.Description, e.Font, sb, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }
    }

    public class Error
    {
        public string Number { get; set; }
        public bool Critical { get; set; }
        public List<ErrorItemDescription> ErrorItems { get; set; }

        public Error()
        {
            ErrorItems = new List<ErrorItemDescription>();
        }
    }

    public class ErrorItemDescription
    {
       public string Description {get; set;}
       public String FieldName { get; set; }
    }

    public class ComplexRowException : Exception
    {
        public List<Error> Errors { get; private set; }
        public ComplexRowException(List<Error> errors)
        {
            this.Errors = errors;
        }
    }
}
