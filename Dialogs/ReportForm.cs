using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace WMSOffice.Dialogs
{
    public partial class ReportForm : Form
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Возможность печати документа
        /// </summary>
        public bool CanPrint
        {
            get { return crystalReportViewer1.ShowPrintButton; }
            set { crystalReportViewer1.ShowPrintButton = value; }
        }

        /// <summary>
        /// Возможность экспорта документа
        /// </summary>
        public bool CanExport
        {
            get { return crystalReportViewer1.ShowExportButton; }
            set { crystalReportViewer1.ShowExportButton = value; }
        }

        public object ReportDocument
        {
            set { crystalReportViewer1.ReportSource = value; }
        }

        private bool _isPrinted;
        public bool IsPrinted
        {
            get { return _isPrinted; }
        }

        private int _copies;
        public int Copies
        {
            get { return _copies; }
        }

        private string _printerName;
        public string PrinterName
        {
            get { return _printerName; }
        }

        #endregion

        public ReportForm()
        {
            InitializeComponent();
            
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
        }

        private void Initialize()
        {
            if (this.CanPrint)
            {
                foreach (Control ctr in crystalReportViewer1.Controls)
                {
                    if (ctr is ToolStrip)
                    {
                        var toolStrip = ctr as ToolStrip;

                        for (int i = 0; i < toolStrip.Items.Count; i++)
                        {
                            var itm = toolStrip.Items[i];
                            if (itm is ToolStripButton && itm.ToolTipText.Contains("Print"))
                            {
                                var btnOldPrint = itm as ToolStripButton;
                                btnOldPrint.Visible = false;

                                var btnNewPrint = new ToolStripButton { ToolTipText = btnOldPrint.ToolTipText, Image = btnOldPrint.Image, ImageScaling = btnOldPrint.ImageScaling };
                                btnNewPrint.Click += (s, e) => 
                                {
                                    var pd = new PrintDialog() 
                                    { 
                                        UseEXDialog = true, 
                                        //AllowCurrentPage = true,
                                        AllowSomePages = true 
                                    };

                                    pd.PrinterSettings.DefaultPageSettings.Landscape = ((ReportClass)crystalReportViewer1.ReportSource).PrintOptions.PaperOrientation == CrystalDecisions.Shared.PaperOrientation.Landscape;

                                    if (pd.ShowDialog(this) == DialogResult.OK)
                                    {
                                        this.Print(pd.PrinterSettings, pd.PrinterSettings.Copies);
                                        this.Close();
                                    }
                                };

                                toolStrip.Items.Insert(btnOldPrint.Owner.Items.IndexOf(btnOldPrint), btnNewPrint);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void Print()
        {
            Print(1);
        }

        public void Print(int nCopies)
        {
            PrintDocument document = new PrintDocument();
            document.PrinterSettings.DefaultPageSettings.Landscape = ((ReportClass)crystalReportViewer1.ReportSource).PrintOptions.PaperOrientation == CrystalDecisions.Shared.PaperOrientation.Landscape;
            Print(document.PrinterSettings, nCopies);
        }

        private void Print(PrinterSettings printer, int nCopies)
        {
            ReportClass report = (ReportClass) crystalReportViewer1.ReportSource;
            report.PrintOptions.PrinterName = printer.PrinterName;

            if (printer.CanDuplex)
            {
                switch (printer.Duplex)
                {
                    case Duplex.Default:
                        report.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;
                        break;
                    case Duplex.Horizontal:
                        report.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Horizontal;
                        break;
                    case Duplex.Simplex:
                        report.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Simplex;
                        break;
                    case Duplex.Vertical:
                        report.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Vertical;
                        break;
                    default:
                        break;
                }
            }

            if (printer.DefaultPageSettings.Landscape)
                report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            else
                report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

            report.PrintToPrinter(nCopies, printer.Collate, printer.FromPage, printer.ToPage);

            _isPrinted = true;
            _copies = nCopies;
            _printerName = printer.PrinterName;
        }
    }
}
