namespace WMSOffice.Window
{
    partial class AWStructureManagementWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.btnReloadData = new System.Windows.Forms.ToolStripButton();
            this.btnSaveData = new System.Windows.Forms.ToolStripButton();
            this.tcAWEditorsHost = new System.Windows.Forms.TabControl();
            this.tpSectorsEditorHost = new System.Windows.Forms.TabPage();
            this.awSectorsEditControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWSectorsEditControl();
            this.tpCellsEditorHost = new System.Windows.Forms.TabPage();
            this.awCellsEditControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWCellsEditControl();
            this.tpStationsEditorHost = new System.Windows.Forms.TabPage();
            this.awStationsEditControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWStationsEditControl();
            this.tpCellsOnStationsEditorHost = new System.Windows.Forms.TabPage();
            this.awCellsOnStationsEditControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWCellsOnStationsEditControl();
            this.tpProcessesEditorHost = new System.Windows.Forms.TabPage();
            this.awProcessesEditControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWProcessesEditControl();
            this.tpProcessesInStationsEditorHost = new System.Windows.Forms.TabPage();
            this.awProcessesInStationsEditControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWProcessesInStationsEditControl();
            this.tbPlaceStationImport = new System.Windows.Forms.TabPage();
            this.awPlaceStationImportControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWPlaceStationImportControl();
            this.tbStationProcessImport = new System.Windows.Forms.TabPage();
            this.awStationProcessImportControl2 = new WMSOffice.Controls.PickControl.AWStructure.AWStationProcessImportControl();
            this.awStationProcessImportControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWStationProcessImportControl();
            this.tbProcessStationSettingsImport = new System.Windows.Forms.TabPage();
            this.tbProcessWarehousesSettingsImport = new System.Windows.Forms.TabPage();
            this.awProcessWarehousesSettingsImportControl2 = new WMSOffice.Controls.PickControl.AWStructure.AWProcessWarehousesSettingsImportControl();
            this.awProcessWarehousesSettingsImportControl1 = new WMSOffice.Controls.PickControl.AWStructure.AWProcessWarehousesSettingsImportControl();
            this.awProcessWarehousesSettingsImportControl3 = new WMSOffice.Controls.PickControl.AWStructure.AWProcessWarehousesSettingsImportControl();
            this.tsMainMenu.SuspendLayout();
            this.tcAWEditorsHost.SuspendLayout();
            this.tpSectorsEditorHost.SuspendLayout();
            this.tpCellsEditorHost.SuspendLayout();
            this.tpStationsEditorHost.SuspendLayout();
            this.tpCellsOnStationsEditorHost.SuspendLayout();
            this.tpProcessesEditorHost.SuspendLayout();
            this.tpProcessesInStationsEditorHost.SuspendLayout();
            this.tbPlaceStationImport.SuspendLayout();
            this.tbStationProcessImport.SuspendLayout();
            this.tbProcessStationSettingsImport.SuspendLayout();
            this.tbProcessWarehousesSettingsImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadData,
            this.btnSaveData});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(897, 39);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // btnReloadData
            // 
            this.btnReloadData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnReloadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(97, 36);
            this.btnReloadData.Text = "Обновить";
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Image = global::WMSOffice.Properties.Resources.save;
            this.btnSaveData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(102, 36);
            this.btnSaveData.Text = "Сохранить";
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // tcAWEditorsHost
            // 
            this.tcAWEditorsHost.Controls.Add(this.tpSectorsEditorHost);
            this.tcAWEditorsHost.Controls.Add(this.tpCellsEditorHost);
            this.tcAWEditorsHost.Controls.Add(this.tpStationsEditorHost);
            this.tcAWEditorsHost.Controls.Add(this.tpCellsOnStationsEditorHost);
            this.tcAWEditorsHost.Controls.Add(this.tpProcessesEditorHost);
            this.tcAWEditorsHost.Controls.Add(this.tpProcessesInStationsEditorHost);
            this.tcAWEditorsHost.Controls.Add(this.tbPlaceStationImport);
            this.tcAWEditorsHost.Controls.Add(this.tbStationProcessImport);
            this.tcAWEditorsHost.Controls.Add(this.tbProcessStationSettingsImport);
            this.tcAWEditorsHost.Controls.Add(this.tbProcessWarehousesSettingsImport);
            this.tcAWEditorsHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAWEditorsHost.Location = new System.Drawing.Point(0, 79);
            this.tcAWEditorsHost.Name = "tcAWEditorsHost";
            this.tcAWEditorsHost.SelectedIndex = 0;
            this.tcAWEditorsHost.Size = new System.Drawing.Size(897, 510);
            this.tcAWEditorsHost.TabIndex = 2;
            this.tcAWEditorsHost.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcAWEditorsHost_DrawItem);
            this.tcAWEditorsHost.SelectedIndexChanged += new System.EventHandler(this.tcAWEditorsHost_SelectedIndexChanged);
            // 
            // tpSectorsEditorHost
            // 
            this.tpSectorsEditorHost.Controls.Add(this.awSectorsEditControl1);
            this.tpSectorsEditorHost.Location = new System.Drawing.Point(4, 22);
            this.tpSectorsEditorHost.Name = "tpSectorsEditorHost";
            this.tpSectorsEditorHost.Padding = new System.Windows.Forms.Padding(3);
            this.tpSectorsEditorHost.Size = new System.Drawing.Size(889, 484);
            this.tpSectorsEditorHost.TabIndex = 0;
            this.tpSectorsEditorHost.Text = "Сектора";
            this.tpSectorsEditorHost.UseVisualStyleBackColor = true;
            // 
            // awSectorsEditControl1
            // 
            this.awSectorsEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awSectorsEditControl1.Initializers = null;
            this.awSectorsEditControl1.Location = new System.Drawing.Point(3, 3);
            this.awSectorsEditControl1.Name = "awSectorsEditControl1";
            this.awSectorsEditControl1.Size = new System.Drawing.Size(883, 478);
            this.awSectorsEditControl1.TabIndex = 0;
            // 
            // tpCellsEditorHost
            // 
            this.tpCellsEditorHost.Controls.Add(this.awCellsEditControl1);
            this.tpCellsEditorHost.Location = new System.Drawing.Point(4, 22);
            this.tpCellsEditorHost.Name = "tpCellsEditorHost";
            this.tpCellsEditorHost.Padding = new System.Windows.Forms.Padding(3);
            this.tpCellsEditorHost.Size = new System.Drawing.Size(889, 484);
            this.tpCellsEditorHost.TabIndex = 1;
            this.tpCellsEditorHost.Text = "Полки";
            this.tpCellsEditorHost.UseVisualStyleBackColor = true;
            // 
            // awCellsEditControl1
            // 
            this.awCellsEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awCellsEditControl1.Initializers = null;
            this.awCellsEditControl1.Location = new System.Drawing.Point(3, 3);
            this.awCellsEditControl1.Name = "awCellsEditControl1";
            this.awCellsEditControl1.Size = new System.Drawing.Size(883, 478);
            this.awCellsEditControl1.TabIndex = 0;
            // 
            // tpStationsEditorHost
            // 
            this.tpStationsEditorHost.Controls.Add(this.awStationsEditControl1);
            this.tpStationsEditorHost.Location = new System.Drawing.Point(4, 22);
            this.tpStationsEditorHost.Name = "tpStationsEditorHost";
            this.tpStationsEditorHost.Padding = new System.Windows.Forms.Padding(3);
            this.tpStationsEditorHost.Size = new System.Drawing.Size(889, 484);
            this.tpStationsEditorHost.TabIndex = 2;
            this.tpStationsEditorHost.Text = "Станции";
            this.tpStationsEditorHost.UseVisualStyleBackColor = true;
            // 
            // awStationsEditControl1
            // 
            this.awStationsEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awStationsEditControl1.Initializers = null;
            this.awStationsEditControl1.Location = new System.Drawing.Point(3, 3);
            this.awStationsEditControl1.Name = "awStationsEditControl1";
            this.awStationsEditControl1.Size = new System.Drawing.Size(883, 478);
            this.awStationsEditControl1.TabIndex = 0;
            // 
            // tpCellsOnStationsEditorHost
            // 
            this.tpCellsOnStationsEditorHost.Controls.Add(this.awCellsOnStationsEditControl1);
            this.tpCellsOnStationsEditorHost.Location = new System.Drawing.Point(4, 22);
            this.tpCellsOnStationsEditorHost.Name = "tpCellsOnStationsEditorHost";
            this.tpCellsOnStationsEditorHost.Padding = new System.Windows.Forms.Padding(3);
            this.tpCellsOnStationsEditorHost.Size = new System.Drawing.Size(889, 484);
            this.tpCellsOnStationsEditorHost.TabIndex = 3;
            this.tpCellsOnStationsEditorHost.Text = "Полки на станциях";
            this.tpCellsOnStationsEditorHost.UseVisualStyleBackColor = true;
            // 
            // awCellsOnStationsEditControl1
            // 
            this.awCellsOnStationsEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awCellsOnStationsEditControl1.Initializers = null;
            this.awCellsOnStationsEditControl1.Location = new System.Drawing.Point(3, 3);
            this.awCellsOnStationsEditControl1.Name = "awCellsOnStationsEditControl1";
            this.awCellsOnStationsEditControl1.Size = new System.Drawing.Size(883, 478);
            this.awCellsOnStationsEditControl1.TabIndex = 0;
            // 
            // tpProcessesEditorHost
            // 
            this.tpProcessesEditorHost.Controls.Add(this.awProcessesEditControl1);
            this.tpProcessesEditorHost.Location = new System.Drawing.Point(4, 22);
            this.tpProcessesEditorHost.Name = "tpProcessesEditorHost";
            this.tpProcessesEditorHost.Padding = new System.Windows.Forms.Padding(3);
            this.tpProcessesEditorHost.Size = new System.Drawing.Size(889, 484);
            this.tpProcessesEditorHost.TabIndex = 4;
            this.tpProcessesEditorHost.Text = "Процессы";
            this.tpProcessesEditorHost.UseVisualStyleBackColor = true;
            // 
            // awProcessesEditControl1
            // 
            this.awProcessesEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awProcessesEditControl1.Initializers = null;
            this.awProcessesEditControl1.Location = new System.Drawing.Point(3, 3);
            this.awProcessesEditControl1.Name = "awProcessesEditControl1";
            this.awProcessesEditControl1.Size = new System.Drawing.Size(883, 478);
            this.awProcessesEditControl1.TabIndex = 0;
            // 
            // tpProcessesInStationsEditorHost
            // 
            this.tpProcessesInStationsEditorHost.Controls.Add(this.awProcessesInStationsEditControl1);
            this.tpProcessesInStationsEditorHost.Location = new System.Drawing.Point(4, 22);
            this.tpProcessesInStationsEditorHost.Name = "tpProcessesInStationsEditorHost";
            this.tpProcessesInStationsEditorHost.Size = new System.Drawing.Size(889, 484);
            this.tpProcessesInStationsEditorHost.TabIndex = 5;
            this.tpProcessesInStationsEditorHost.Text = "Процессы в станциях";
            this.tpProcessesInStationsEditorHost.UseVisualStyleBackColor = true;
            // 
            // awProcessesInStationsEditControl1
            // 
            this.awProcessesInStationsEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awProcessesInStationsEditControl1.Initializers = null;
            this.awProcessesInStationsEditControl1.Location = new System.Drawing.Point(0, 0);
            this.awProcessesInStationsEditControl1.Name = "awProcessesInStationsEditControl1";
            this.awProcessesInStationsEditControl1.Size = new System.Drawing.Size(889, 484);
            this.awProcessesInStationsEditControl1.TabIndex = 0;
            // 
            // tbPlaceStationImport
            // 
            this.tbPlaceStationImport.Controls.Add(this.awPlaceStationImportControl1);
            this.tbPlaceStationImport.Location = new System.Drawing.Point(4, 22);
            this.tbPlaceStationImport.Name = "tbPlaceStationImport";
            this.tbPlaceStationImport.Padding = new System.Windows.Forms.Padding(3);
            this.tbPlaceStationImport.Size = new System.Drawing.Size(889, 484);
            this.tbPlaceStationImport.TabIndex = 6;
            this.tbPlaceStationImport.Text = "Место-станция";
            this.tbPlaceStationImport.UseVisualStyleBackColor = true;
            // 
            // awPlaceStationImportControl1
            // 
            this.awPlaceStationImportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awPlaceStationImportControl1.Initializers = null;
            this.awPlaceStationImportControl1.Location = new System.Drawing.Point(3, 3);
            this.awPlaceStationImportControl1.Name = "awPlaceStationImportControl1";
            this.awPlaceStationImportControl1.Size = new System.Drawing.Size(883, 478);
            this.awPlaceStationImportControl1.TabIndex = 0;
            // 
            // tbStationProcessImport
            // 
            this.tbStationProcessImport.Controls.Add(this.awStationProcessImportControl2);
            this.tbStationProcessImport.Controls.Add(this.awStationProcessImportControl1);
            this.tbStationProcessImport.Location = new System.Drawing.Point(4, 22);
            this.tbStationProcessImport.Name = "tbStationProcessImport";
            this.tbStationProcessImport.Padding = new System.Windows.Forms.Padding(3);
            this.tbStationProcessImport.Size = new System.Drawing.Size(889, 484);
            this.tbStationProcessImport.TabIndex = 7;
            this.tbStationProcessImport.Text = "Станция-процесс";
            this.tbStationProcessImport.UseVisualStyleBackColor = true;
            // 
            // awStationProcessImportControl2
            // 
            this.awStationProcessImportControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awStationProcessImportControl2.Initializers = null;
            this.awStationProcessImportControl2.Location = new System.Drawing.Point(3, 3);
            this.awStationProcessImportControl2.Name = "awStationProcessImportControl2";
            this.awStationProcessImportControl2.Size = new System.Drawing.Size(883, 478);
            this.awStationProcessImportControl2.TabIndex = 1;
            // 
            // awStationProcessImportControl1
            // 
            this.awStationProcessImportControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.awStationProcessImportControl1.Initializers = null;
            this.awStationProcessImportControl1.Location = new System.Drawing.Point(3, 3);
            this.awStationProcessImportControl1.Name = "awStationProcessImportControl1";
            this.awStationProcessImportControl1.Size = new System.Drawing.Size(0, 0);
            this.awStationProcessImportControl1.TabIndex = 0;
            // 
            // tbProcessStationSettingsImport
            // 
            this.tbProcessStationSettingsImport.Controls.Add(this.awProcessWarehousesSettingsImportControl3);
            this.tbProcessStationSettingsImport.Location = new System.Drawing.Point(4, 22);
            this.tbProcessStationSettingsImport.Name = "tbProcessStationSettingsImport";
            this.tbProcessStationSettingsImport.Padding = new System.Windows.Forms.Padding(3);
            this.tbProcessStationSettingsImport.Size = new System.Drawing.Size(889, 484);
            this.tbProcessStationSettingsImport.TabIndex = 8;
            this.tbProcessStationSettingsImport.Text = "Настройки станция-процесс";
            this.tbProcessStationSettingsImport.UseVisualStyleBackColor = true;
            // 
            // tbProcessWarehousesSettingsImport
            // 
            this.tbProcessWarehousesSettingsImport.Controls.Add(this.awProcessWarehousesSettingsImportControl2);
            this.tbProcessWarehousesSettingsImport.Controls.Add(this.awProcessWarehousesSettingsImportControl1);
            this.tbProcessWarehousesSettingsImport.Location = new System.Drawing.Point(4, 22);
            this.tbProcessWarehousesSettingsImport.Name = "tbProcessWarehousesSettingsImport";
            this.tbProcessWarehousesSettingsImport.Padding = new System.Windows.Forms.Padding(3);
            this.tbProcessWarehousesSettingsImport.Size = new System.Drawing.Size(889, 484);
            this.tbProcessWarehousesSettingsImport.TabIndex = 9;
            this.tbProcessWarehousesSettingsImport.Text = "Процесс-склад";
            this.tbProcessWarehousesSettingsImport.UseVisualStyleBackColor = true;
            // 
            // awProcessWarehousesSettingsImportControl2
            // 
            this.awProcessWarehousesSettingsImportControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awProcessWarehousesSettingsImportControl2.Initializers = null;
            this.awProcessWarehousesSettingsImportControl2.Location = new System.Drawing.Point(3, 3);
            this.awProcessWarehousesSettingsImportControl2.Name = "awProcessWarehousesSettingsImportControl2";
            this.awProcessWarehousesSettingsImportControl2.Size = new System.Drawing.Size(883, 478);
            this.awProcessWarehousesSettingsImportControl2.TabIndex = 1;
            // 
            // awProcessWarehousesSettingsImportControl1
            // 
            this.awProcessWarehousesSettingsImportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awProcessWarehousesSettingsImportControl1.Initializers = null;
            this.awProcessWarehousesSettingsImportControl1.Location = new System.Drawing.Point(3, 3);
            this.awProcessWarehousesSettingsImportControl1.Name = "awProcessWarehousesSettingsImportControl1";
            this.awProcessWarehousesSettingsImportControl1.Size = new System.Drawing.Size(883, 478);
            this.awProcessWarehousesSettingsImportControl1.TabIndex = 0;
            // 
            // awProcessWarehousesSettingsImportControl3
            // 
            this.awProcessWarehousesSettingsImportControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.awProcessWarehousesSettingsImportControl3.Initializers = null;
            this.awProcessWarehousesSettingsImportControl3.Location = new System.Drawing.Point(3, 3);
            this.awProcessWarehousesSettingsImportControl3.Name = "awProcessWarehousesSettingsImportControl3";
            this.awProcessWarehousesSettingsImportControl3.Size = new System.Drawing.Size(883, 478);
            this.awProcessWarehousesSettingsImportControl3.TabIndex = 0;
            // 
            // AWStructureManagementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 589);
            this.Controls.Add(this.tcAWEditorsHost);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "AWStructureManagementWindow";
            this.Text = "AWStructureManagementWindow";
            this.Load += new System.EventHandler(this.AWStructureManagementWindow_Load);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.tcAWEditorsHost, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.tcAWEditorsHost.ResumeLayout(false);
            this.tpSectorsEditorHost.ResumeLayout(false);
            this.tpCellsEditorHost.ResumeLayout(false);
            this.tpStationsEditorHost.ResumeLayout(false);
            this.tpCellsOnStationsEditorHost.ResumeLayout(false);
            this.tpProcessesEditorHost.ResumeLayout(false);
            this.tpProcessesInStationsEditorHost.ResumeLayout(false);
            this.tbPlaceStationImport.ResumeLayout(false);
            this.tbStationProcessImport.ResumeLayout(false);
            this.tbProcessStationSettingsImport.ResumeLayout(false);
            this.tbProcessWarehousesSettingsImport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton btnReloadData;
        private System.Windows.Forms.TabControl tcAWEditorsHost;
        private System.Windows.Forms.TabPage tpSectorsEditorHost;
        private System.Windows.Forms.TabPage tpCellsEditorHost;
        private System.Windows.Forms.TabPage tpStationsEditorHost;
        private WMSOffice.Controls.PickControl.AWStructure.AWSectorsEditControl awSectorsEditControl1;
        private WMSOffice.Controls.PickControl.AWStructure.AWCellsEditControl awCellsEditControl1;
        private System.Windows.Forms.ToolStripButton btnSaveData;
        private WMSOffice.Controls.PickControl.AWStructure.AWStationsEditControl awStationsEditControl1;
        private System.Windows.Forms.TabPage tpCellsOnStationsEditorHost;
        private WMSOffice.Controls.PickControl.AWStructure.AWCellsOnStationsEditControl awCellsOnStationsEditControl1;
        private System.Windows.Forms.TabPage tpProcessesEditorHost;
        private WMSOffice.Controls.PickControl.AWStructure.AWProcessesEditControl awProcessesEditControl1;
        private System.Windows.Forms.TabPage tpProcessesInStationsEditorHost;
        private WMSOffice.Controls.PickControl.AWStructure.AWProcessesInStationsEditControl awProcessesInStationsEditControl1;
        private System.Windows.Forms.TabPage tbPlaceStationImport;
        private WMSOffice.Controls.PickControl.AWStructure.AWPlaceStationImportControl awPlaceStationImportControl1;
        private System.Windows.Forms.TabPage tbStationProcessImport;
        private WMSOffice.Controls.PickControl.AWStructure.AWStationProcessImportControl awStationProcessImportControl1;
        private System.Windows.Forms.TabPage tbProcessStationSettingsImport;
        private System.Windows.Forms.TabPage tbProcessWarehousesSettingsImport;
        private WMSOffice.Controls.PickControl.AWStructure.AWProcessWarehousesSettingsImportControl awProcessWarehousesSettingsImportControl1;
        private WMSOffice.Controls.PickControl.AWStructure.AWStationProcessImportControl awStationProcessImportControl2;
        private WMSOffice.Controls.PickControl.AWStructure.AWProcessWarehousesSettingsImportControl awProcessWarehousesSettingsImportControl2;
        private WMSOffice.Controls.PickControl.AWStructure.AWProcessWarehousesSettingsImportControl awProcessWarehousesSettingsImportControl3;
    }
}