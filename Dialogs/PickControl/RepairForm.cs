using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class RepairForm : DialogForm
    {
        public RepairForm()
        {
            InitializeComponent();
        }

        public long DocID { get; set; }
        public int LineID { get; set; }
        public string Instruction
        {
            get { return tbInstruction.Text; }
            set { tbInstruction.Text = value.Replace("<br>", Environment.NewLine); }
        }

        private int UserID { get; set; }

        public bool ControlerFault { get { return chbControl.Checked; } }
        public bool PickerFault { get { return chbPick.Checked; } }
        public bool OperatorFault { get { return chbOperator.Checked; } }

        /*public int? ControlerID
        {
            get
            {
                return (!chbControl.Checked) ? null : (int?)UserID;
            }
        }
        public int? PickerID
        { get { return (!chbControl.Checked) ? null : (int?)((int)((double)cbPicker.SelectedValue)); } }
        */
        private void RepairForm_Load(object sender, EventArgs e)
        {
            /*try
            {
                users_By_DocTableAdapter.Fill(pickControl.Users_By_Doc, DocID);
                if (pickControl.Users_By_Doc.Count == 1)
                {
                    UserID = (int)pickControl.Users_By_Doc[0].Employee_ID;
                    lblDocUser.Text = pickControl.Users_By_Doc[0].Employee_Name;
                }
                else throw new Exception("ОШИБКА! Не обнаружен пользователь, контролировавший документ.");

                users_By_DocTableAdapter.FillPickers(pickControl.Users_By_Doc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void RepairForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                // проверка возможности закрыть окно "успешно"
                if (!chbControl.Checked && !chbPick.Checked && !chbOperator.Checked)
                {
                    MessageBox.Show("Для исправления ошибки контроля/сборки нужно указать виновного!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                } /*else
                    if (chbPick.Checked && cbPicker.SelectedValue == null)
                    {
                        MessageBox.Show("Нужно указать ФИО виновного сборщика!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }*/
                    else { 
                        // все выполнено, позволяем закрыть окно OK
                    }
            }
        }

        private void tbInstruction_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.NumPad1:
                    chbControl.Checked = !chbControl.Checked;
                    break;
                case Keys.NumPad2:
                    chbPick.Checked = !chbPick.Checked;
                    break;
                case Keys.NumPad3:
                    chbOperator.Checked = !chbOperator.Checked;
                    break;
            }
        }

        private void RepairForm_Shown(object sender, EventArgs e)
        {
            tbInstruction.DeselectAll();
        }


    }
}
