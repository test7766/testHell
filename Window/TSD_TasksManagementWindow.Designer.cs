namespace WMSOffice.Window
{
    partial class TSD_TasksManagementWindow
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
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssMainOptions = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.tssExportOptions = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateTask = new System.Windows.Forms.ToolStripButton();
            this.sbAssignTask = new System.Windows.Forms.ToolStripButton();
            this.sbCancelTask = new System.Windows.Forms.ToolStripButton();
            this.sbDeleteTask = new System.Windows.Forms.ToolStripButton();
            this.tssCheckPrinters = new System.Windows.Forms.ToolStripSeparator();
            this.sbCheckPrinters = new System.Windows.Forms.ToolStripButton();
            this.tssCheckAltLiftTasks = new System.Windows.Forms.ToolStripSeparator();
            this.sbCheckAltLiftTasks = new System.Windows.Forms.ToolStripButton();
            this.xdgvTasks = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.toolStripDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.tssMainOptions,
            this.btnExportToExcel,
            this.tssExportOptions,
            this.btnCreateTask,
            this.sbAssignTask,
            this.sbCancelTask,
            this.sbDeleteTask,
            this.tssCheckPrinters,
            this.sbCheckPrinters,
            this.tssCheckAltLiftTasks,
            this.sbCheckAltLiftTasks});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1134, 55);
            this.toolStripDoc.TabIndex = 1;
            this.toolStripDoc.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(109, 52);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // tssMainOptions
            // 
            this.tssMainOptions.Name = "tssMainOptions";
            this.tssMainOptions.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(110, 52);
            this.btnExportToExcel.Text = "Экспорт в\nExcel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // tssExportOptions
            // 
            this.tssExportOptions.Name = "tssExportOptions";
            this.tssExportOptions.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Image = global::WMSOffice.Properties.Resources.document_plain_new;
            this.btnCreateTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(102, 52);
            this.btnCreateTask.Text = "Создать\nзадание";
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // sbAssignTask
            // 
            this.sbAssignTask.Image = global::WMSOffice.Properties.Resources.assign;
            this.sbAssignTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAssignTask.Name = "sbAssignTask";
            this.sbAssignTask.Size = new System.Drawing.Size(113, 52);
            this.sbAssignTask.Text = "Назначить\nзадание";
            this.sbAssignTask.Click += new System.EventHandler(this.sbAssignTask_Click);
            // 
            // sbCancelTask
            // 
            this.sbCancelTask.Image = global::WMSOffice.Properties.Resources.undo43;
            this.sbCancelTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCancelTask.Name = "sbCancelTask";
            this.sbCancelTask.Size = new System.Drawing.Size(109, 52);
            this.sbCancelTask.Text = "Отменить\nзадание";
            this.sbCancelTask.Click += new System.EventHandler(this.sbCancelTask_Click);
            // 
            // sbDeleteTask
            // 
            this.sbDeleteTask.Image = global::WMSOffice.Properties.Resources.Delete;
            this.sbDeleteTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbDeleteTask.Name = "sbDeleteTask";
            this.sbDeleteTask.Size = new System.Drawing.Size(103, 52);
            this.sbDeleteTask.Text = "Удалить\nзадание";
            this.sbDeleteTask.Click += new System.EventHandler(this.sbDeleteTask_Click);
            // 
            // tssCheckPrinters
            // 
            this.tssCheckPrinters.Name = "tssCheckPrinters";
            this.tssCheckPrinters.Size = new System.Drawing.Size(6, 55);
            // 
            // sbCheckPrinters
            // 
            this.sbCheckPrinters.Image = global::WMSOffice.Properties.Resources.assign;
            this.sbCheckPrinters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCheckPrinters.Name = "sbCheckPrinters";
            this.sbCheckPrinters.Size = new System.Drawing.Size(175, 52);
            this.sbCheckPrinters.Text = "Проверка\nактивности принтеров\nна контроле \"волны\"";
            this.sbCheckPrinters.Click += new System.EventHandler(this.sbCheckPrinters_Click);
            // 
            // tssCheckAltLiftTasks
            // 
            this.tssCheckAltLiftTasks.Name = "tssCheckAltLiftTasks";
            this.tssCheckAltLiftTasks.Size = new System.Drawing.Size(6, 55);
            this.tssCheckAltLiftTasks.Visible = false;
            // 
            // sbCheckAltLiftTasks
            // 
            this.sbCheckAltLiftTasks.Image = global::WMSOffice.Properties.Resources.assign;
            this.sbCheckAltLiftTasks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCheckAltLiftTasks.Name = "sbCheckAltLiftTasks";
            this.sbCheckAltLiftTasks.Size = new System.Drawing.Size(159, 52);
            this.sbCheckAltLiftTasks.Text = "Проверка\nальтернативного\nлифтового задания";
            this.sbCheckAltLiftTasks.Visible = false;
            this.sbCheckAltLiftTasks.Click += new System.EventHandler(this.sbCheckAltLiftTasks_Click);
            // 
            // xdgvTasks
            // 
            this.xdgvTasks.AllowSort = true;
            this.xdgvTasks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvTasks.LargeAmountOfData = false;
            this.xdgvTasks.Location = new System.Drawing.Point(0, 95);
            this.xdgvTasks.Name = "xdgvTasks";
            this.xdgvTasks.RowHeadersVisible = false;
            this.xdgvTasks.Size = new System.Drawing.Size(1134, 370);
            this.xdgvTasks.TabIndex = 2;
            this.xdgvTasks.UserID = ((long)(0));
            // 
            // TSD_TasksManagementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 465);
            this.Controls.Add(this.xdgvTasks);
            this.Controls.Add(this.toolStripDoc);
            this.Name = "TSD_TasksManagementWindow";
            this.Text = "Управление заданиями ТСД";
            this.Load += new System.EventHandler(this.TSD_TasksManagementWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TSD_TasksManagementWindow_FormClosing);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.xdgvTasks, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvTasks;
        private System.Windows.Forms.ToolStripSeparator tssMainOptions;
        private System.Windows.Forms.ToolStripButton sbAssignTask;
        private System.Windows.Forms.ToolStripButton sbCancelTask;
        private System.Windows.Forms.ToolStripButton sbDeleteTask;
        private System.Windows.Forms.ToolStripSeparator tssCheckPrinters;
        private System.Windows.Forms.ToolStripButton sbCheckPrinters;
        private System.Windows.Forms.ToolStripButton btnCreateTask;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripSeparator tssExportOptions;
        private System.Windows.Forms.ToolStripButton sbCheckAltLiftTasks;
        private System.Windows.Forms.ToolStripSeparator tssCheckAltLiftTasks;
    }
}