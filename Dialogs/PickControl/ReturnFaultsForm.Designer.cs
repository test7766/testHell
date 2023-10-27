namespace WMSOffice.Dialogs.PickControl
{
    partial class ReturnFaultsForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReturnFaults = new System.Windows.Forms.DataGridView();
            this.faultTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faultEmployeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faultEmployeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnFaultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miAccept = new System.Windows.Forms.ToolStripMenuItem();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.returnFaultsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.ReturnFaultsTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnFaults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnFaultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.toolStripDoc.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReturnFaults
            // 
            this.dgvReturnFaults.AllowUserToAddRows = false;
            this.dgvReturnFaults.AllowUserToDeleteRows = false;
            this.dgvReturnFaults.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvReturnFaults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReturnFaults.AutoGenerateColumns = false;
            this.dgvReturnFaults.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturnFaults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReturnFaults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnFaults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.faultTypeIDDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.faultEmployeeIDDataGridViewTextBoxColumn,
            this.faultEmployeeNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvReturnFaults.DataSource = this.returnFaultsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReturnFaults.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReturnFaults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReturnFaults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReturnFaults.Location = new System.Drawing.Point(0, 55);
            this.dgvReturnFaults.MultiSelect = false;
            this.dgvReturnFaults.Name = "dgvReturnFaults";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturnFaults.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReturnFaults.RowHeadersVisible = false;
            this.dgvReturnFaults.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvReturnFaults.RowTemplate.Height = 21;
            this.dgvReturnFaults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReturnFaults.ShowEditingIcon = false;
            this.dgvReturnFaults.Size = new System.Drawing.Size(684, 257);
            this.dgvReturnFaults.TabIndex = 9;
            // 
            // faultTypeIDDataGridViewTextBoxColumn
            // 
            this.faultTypeIDDataGridViewTextBoxColumn.DataPropertyName = "Fault_Type_ID";
            this.faultTypeIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.faultTypeIDDataGridViewTextBoxColumn.Name = "faultTypeIDDataGridViewTextBoxColumn";
            this.faultTypeIDDataGridViewTextBoxColumn.Width = 45;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Описание проблемы";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // faultEmployeeIDDataGridViewTextBoxColumn
            // 
            this.faultEmployeeIDDataGridViewTextBoxColumn.DataPropertyName = "Fault_Employee_ID";
            this.faultEmployeeIDDataGridViewTextBoxColumn.HeaderText = "Код сотр.";
            this.faultEmployeeIDDataGridViewTextBoxColumn.Name = "faultEmployeeIDDataGridViewTextBoxColumn";
            this.faultEmployeeIDDataGridViewTextBoxColumn.Width = 65;
            // 
            // faultEmployeeNameDataGridViewTextBoxColumn
            // 
            this.faultEmployeeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.faultEmployeeNameDataGridViewTextBoxColumn.DataPropertyName = "Fault_Employee_Name";
            this.faultEmployeeNameDataGridViewTextBoxColumn.HeaderText = "ФИО сотрудника";
            this.faultEmployeeNameDataGridViewTextBoxColumn.Name = "faultEmployeeNameDataGridViewTextBoxColumn";
            this.faultEmployeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "К-во товара";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 70;
            // 
            // returnFaultsBindingSource
            // 
            this.returnFaultsBindingSource.DataMember = "ReturnFaults";
            this.returnFaultsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnClose});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(684, 55);
            this.toolStripDoc.TabIndex = 8;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::WMSOffice.Properties.Resources.F2;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(169, 52);
            this.btnAdd.Text = "Добавить\nпроблемный\nтовар";
            this.btnAdd.ToolTipText = "Добавить проблемный товар";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::WMSOffice.Properties.Resources.F4;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(127, 52);
            this.btnEdit.Text = "Изменить\nвыбранную\nстроку";
            this.btnEdit.ToolTipText = "Изменить выбранную строку";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::WMSOffice.Properties.Resources.F8;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 52);
            this.btnClose.Text = "Закрыть\n\r диалог";
            this.btnClose.ToolTipText = "Закрыть диалог";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAdd,
            this.miAccept,
            this.miClose});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(274, 70);
            // 
            // miAdd
            // 
            this.miAdd.Name = "miAdd";
            this.miAdd.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miAdd.Size = new System.Drawing.Size(273, 22);
            this.miAdd.Text = "Добавить виновного сотрудника";
            this.miAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // miAccept
            // 
            this.miAccept.Name = "miAccept";
            this.miAccept.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.miAccept.Size = new System.Drawing.Size(273, 22);
            this.miAccept.Text = "Изменить выбранную строку";
            this.miAccept.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.miClose.Size = new System.Drawing.Size(273, 22);
            this.miClose.Text = "Закрыть диалог";
            this.miClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // returnFaultsTableAdapter
            // 
            this.returnFaultsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Fault_Type_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.HeaderText = "Описание проблемы";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Fault_Employee_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Код сотр.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Fault_Employee_Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "ФИО сотрудника";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn5.HeaderText = "К-во товара";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // ReturnFaultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 312);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.dgvReturnFaults);
            this.Controls.Add(this.toolStripDoc);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name = "ReturnFaultsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Виновные в проблеме";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnFaults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnFaultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReturnFaults;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem miAdd;
        private System.Windows.Forms.ToolStripMenuItem miAccept;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.BindingSource returnFaultsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.ReturnFaultsTableAdapter returnFaultsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn faultTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faultEmployeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faultEmployeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}