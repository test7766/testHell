namespace WMSOffice.Dialogs.ColdChain
{
    partial class SearchWorkedEquipment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSensorBarCode = new System.Windows.Forms.TextBox();
            this.tbEquipmentBarCode = new System.Windows.Forms.TextBox();
            this.dtpRouteListDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRouteListNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDriverCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPickSlipNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDebtorName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbSearchBySensorsEquipment = new System.Windows.Forms.GroupBox();
            this.tbDocID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbSearchByRouteList = new System.Windows.Forms.GroupBox();
            this.tbDriverName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbSearchByPickSlipDebtor = new System.Windows.Forms.GroupBox();
            this.tbDebtorCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSearchInArchive = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            this.gbSearchBySensorsEquipment.SuspendLayout();
            this.gbSearchByRouteList.SuspendLayout();
            this.gbSearchByPickSlipDebtor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(655, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(745, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 398);
            this.pnlButtons.Size = new System.Drawing.Size(394, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // tbSensorBarCode
            // 
            this.tbSensorBarCode.Location = new System.Drawing.Point(117, 45);
            this.tbSensorBarCode.Name = "tbSensorBarCode";
            this.tbSensorBarCode.Size = new System.Drawing.Size(110, 20);
            this.tbSensorBarCode.TabIndex = 3;
            this.tbSensorBarCode.Tag = "";
            this.tbSensorBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            // 
            // tbEquipmentBarCode
            // 
            this.tbEquipmentBarCode.Location = new System.Drawing.Point(117, 17);
            this.tbEquipmentBarCode.Name = "tbEquipmentBarCode";
            this.tbEquipmentBarCode.Size = new System.Drawing.Size(110, 20);
            this.tbEquipmentBarCode.TabIndex = 1;
            this.tbEquipmentBarCode.Tag = "";
            this.tbEquipmentBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            // 
            // dtpRouteListDate
            // 
            this.dtpRouteListDate.Checked = false;
            this.dtpRouteListDate.CustomFormat = "dd.MM.yyyy";
            this.dtpRouteListDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRouteListDate.Location = new System.Drawing.Point(117, 43);
            this.dtpRouteListDate.Name = "dtpRouteListDate";
            this.dtpRouteListDate.ShowCheckBox = true;
            this.dtpRouteListDate.Size = new System.Drawing.Size(110, 20);
            this.dtpRouteListDate.TabIndex = 3;
            this.dtpRouteListDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата печати МЛ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Номер МЛ:";
            // 
            // tbRouteListNumber
            // 
            this.tbRouteListNumber.Location = new System.Drawing.Point(117, 17);
            this.tbRouteListNumber.Name = "tbRouteListNumber";
            this.tbRouteListNumber.Size = new System.Drawing.Size(110, 20);
            this.tbRouteListNumber.TabIndex = 1;
            this.tbRouteListNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ш/К датчика:";
            // 
            // tbDriverCode
            // 
            this.tbDriverCode.Location = new System.Drawing.Point(117, 77);
            this.tbDriverCode.Name = "tbDriverCode";
            this.tbDriverCode.Size = new System.Drawing.Size(110, 20);
            this.tbDriverCode.TabIndex = 5;
            this.tbDriverCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            this.tbDriverCode.Leave += new System.EventHandler(this.tbDriverCode_Leave);
            this.tbDriverCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOnlyNumbers_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Код водителя:";
            // 
            // tbPickSlipNumber
            // 
            this.tbPickSlipNumber.Location = new System.Drawing.Point(117, 17);
            this.tbPickSlipNumber.Name = "tbPickSlipNumber";
            this.tbPickSlipNumber.Size = new System.Drawing.Size(110, 20);
            this.tbPickSlipNumber.TabIndex = 1;
            this.tbPickSlipNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            this.tbPickSlipNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOnlyNumbers_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "№ сборочного:";
            // 
            // tbDebtorName
            // 
            this.tbDebtorName.Location = new System.Drawing.Point(117, 81);
            this.tbDebtorName.Name = "tbDebtorName";
            this.tbDebtorName.Size = new System.Drawing.Size(240, 20);
            this.tbDebtorName.TabIndex = 5;
            this.tbDebtorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            this.tbDebtorName.Leave += new System.EventHandler(this.tbDebtorName_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Наименование:";
            // 
            // gbSearchBySensorsEquipment
            // 
            this.gbSearchBySensorsEquipment.Controls.Add(this.tbDocID);
            this.gbSearchBySensorsEquipment.Controls.Add(this.label10);
            this.gbSearchBySensorsEquipment.Controls.Add(this.label7);
            this.gbSearchBySensorsEquipment.Controls.Add(this.tbEquipmentBarCode);
            this.gbSearchBySensorsEquipment.Controls.Add(this.tbSensorBarCode);
            this.gbSearchBySensorsEquipment.Controls.Add(this.label3);
            this.gbSearchBySensorsEquipment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbSearchBySensorsEquipment.Location = new System.Drawing.Point(12, 150);
            this.gbSearchBySensorsEquipment.Name = "gbSearchBySensorsEquipment";
            this.gbSearchBySensorsEquipment.Size = new System.Drawing.Size(370, 98);
            this.gbSearchBySensorsEquipment.TabIndex = 1;
            this.gbSearchBySensorsEquipment.TabStop = false;
            this.gbSearchBySensorsEquipment.Text = "по оборудованию / датчику / закреплению";
            // 
            // tbDocID
            // 
            this.tbDocID.Location = new System.Drawing.Point(117, 73);
            this.tbDocID.Name = "tbDocID";
            this.tbDocID.Size = new System.Drawing.Size(110, 20);
            this.tbDocID.TabIndex = 9;
            this.tbDocID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            this.tbDocID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOnlyNumbers_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(6, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "№ документа:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ш/К оборудования:";
            // 
            // gbSearchByRouteList
            // 
            this.gbSearchByRouteList.Controls.Add(this.tbDriverName);
            this.gbSearchByRouteList.Controls.Add(this.label9);
            this.gbSearchByRouteList.Controls.Add(this.label2);
            this.gbSearchByRouteList.Controls.Add(this.dtpRouteListDate);
            this.gbSearchByRouteList.Controls.Add(this.label1);
            this.gbSearchByRouteList.Controls.Add(this.tbRouteListNumber);
            this.gbSearchByRouteList.Controls.Add(this.tbDriverCode);
            this.gbSearchByRouteList.Controls.Add(this.label4);
            this.gbSearchByRouteList.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbSearchByRouteList.Location = new System.Drawing.Point(12, 12);
            this.gbSearchByRouteList.Name = "gbSearchByRouteList";
            this.gbSearchByRouteList.Size = new System.Drawing.Size(370, 130);
            this.gbSearchByRouteList.TabIndex = 0;
            this.gbSearchByRouteList.TabStop = false;
            this.gbSearchByRouteList.Text = "по маршрутному листу";
            // 
            // tbDriverName
            // 
            this.tbDriverName.Location = new System.Drawing.Point(117, 105);
            this.tbDriverName.Name = "tbDriverName";
            this.tbDriverName.Size = new System.Drawing.Size(240, 20);
            this.tbDriverName.TabIndex = 7;
            this.tbDriverName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            this.tbDriverName.Leave += new System.EventHandler(this.tbDriverName_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(6, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ф.И.О. водителя:";
            // 
            // gbSearchByPickSlipDebtor
            // 
            this.gbSearchByPickSlipDebtor.Controls.Add(this.tbDebtorCode);
            this.gbSearchByPickSlipDebtor.Controls.Add(this.label8);
            this.gbSearchByPickSlipDebtor.Controls.Add(this.tbPickSlipNumber);
            this.gbSearchByPickSlipDebtor.Controls.Add(this.label5);
            this.gbSearchByPickSlipDebtor.Controls.Add(this.tbDebtorName);
            this.gbSearchByPickSlipDebtor.Controls.Add(this.label6);
            this.gbSearchByPickSlipDebtor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbSearchByPickSlipDebtor.Location = new System.Drawing.Point(12, 256);
            this.gbSearchByPickSlipDebtor.Name = "gbSearchByPickSlipDebtor";
            this.gbSearchByPickSlipDebtor.Size = new System.Drawing.Size(370, 105);
            this.gbSearchByPickSlipDebtor.TabIndex = 2;
            this.gbSearchByPickSlipDebtor.TabStop = false;
            this.gbSearchByPickSlipDebtor.Text = "по сборочному / дебитору";
            // 
            // tbDebtorCode
            // 
            this.tbDebtorCode.Location = new System.Drawing.Point(117, 53);
            this.tbDebtorCode.Name = "tbDebtorCode";
            this.tbDebtorCode.Size = new System.Drawing.Size(110, 20);
            this.tbDebtorCode.TabIndex = 3;
            this.tbDebtorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            this.tbDebtorCode.Leave += new System.EventHandler(this.tbDebtorCode_Leave);
            this.tbDebtorCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOnlyNumbers_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(6, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Код дебитора:";
            // 
            // cbSearchInArchive
            // 
            this.cbSearchInArchive.AutoSize = true;
            this.cbSearchInArchive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSearchInArchive.Location = new System.Drawing.Point(12, 377);
            this.cbSearchInArchive.Name = "cbSearchInArchive";
            this.cbSearchInArchive.Size = new System.Drawing.Size(110, 17);
            this.cbSearchInArchive.TabIndex = 3;
            this.cbSearchInArchive.Text = "Искать в архиве";
            this.cbSearchInArchive.UseVisualStyleBackColor = true;
            this.cbSearchInArchive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            // 
            // SearchWorkedEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 441);
            this.Controls.Add(this.cbSearchInArchive);
            this.Controls.Add(this.gbSearchByPickSlipDebtor);
            this.Controls.Add(this.gbSearchByRouteList);
            this.Controls.Add(this.gbSearchBySensorsEquipment);
            this.Name = "SearchWorkedEquipment";
            this.Text = "Поиск закрепленного оборудования";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchWorkedEquipment_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.gbSearchBySensorsEquipment, 0);
            this.Controls.SetChildIndex(this.gbSearchByRouteList, 0);
            this.Controls.SetChildIndex(this.gbSearchByPickSlipDebtor, 0);
            this.Controls.SetChildIndex(this.cbSearchInArchive, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbSearchBySensorsEquipment.ResumeLayout(false);
            this.gbSearchBySensorsEquipment.PerformLayout();
            this.gbSearchByRouteList.ResumeLayout(false);
            this.gbSearchByRouteList.PerformLayout();
            this.gbSearchByPickSlipDebtor.ResumeLayout(false);
            this.gbSearchByPickSlipDebtor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSensorBarCode;
        private System.Windows.Forms.TextBox tbEquipmentBarCode;
        private System.Windows.Forms.DateTimePicker dtpRouteListDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRouteListNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDriverCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPickSlipNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDebtorName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbSearchBySensorsEquipment;
        private System.Windows.Forms.GroupBox gbSearchByRouteList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbSearchByPickSlipDebtor;
        private System.Windows.Forms.TextBox tbDebtorCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDriverName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbDocID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbSearchInArchive;
    }
}