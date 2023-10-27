using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class PlatzkartPickDirectionForm : RoundedForm
    {
        public int IndentHorizontal { get; set; }
        
        public int IndentVertical { get; set; }

        public PlatzkartBoxDirection Direction { get; set; }

        public Color EmptyColor { get; set; }
        
        public Image Image { get; set; }

        public string Value { get; set; }

        private bool showValue = true;


        public PlatzkartPickDirectionForm()
        {
            InitializeComponent();
        }

        public static PlatzkartPickDirectionForm Create(PlatzkartBoxDirection direction, string value, Form owner, int indentHorizontal, int indentVertical)
        {
            var form = (PlatzkartPickDirectionForm)null;

            switch (direction)
            {
                case PlatzkartBoxDirection.L:
                    form = new PlatzkartPickDirectionForm() { Width = 340, Height = 340, IndentHorizontal = indentHorizontal, IndentVertical = indentVertical, Direction = direction, EmptyColor = Color.FromArgb(118, 194, 175), Image = Properties.Resources.arrow_left_256, Value = value };
                    break;
                case PlatzkartBoxDirection.R:
                    form = new PlatzkartPickDirectionForm() { Width = 340, Height = 340, IndentHorizontal = indentHorizontal, IndentVertical = indentVertical, Direction = direction, EmptyColor = Color.FromArgb(118, 194, 175), Image = Properties.Resources.arrow_right_256, Value = value };
                    break;
                default:
                    break;
            }

            if (form == null)
                throw new NotImplementedException();
            else
            {
                //form.Load += (s, ea) => { form.RecalcLocation(s); };
                //owner.SizeChanged += (s, ea) => { form.RecalcLocation(s); };
                //owner.LocationChanged += (s, ea) => { form.RecalcLocation(s); };

                form.Load += form.OnRecalcLocation;
                owner.LocationChanged += form.OnRecalcLocation;
                owner.SizeChanged += form.OnRecalcLocation;

                form.Owner = owner;

                form.Show(/*owner*/);
                owner.Focus();

                return form;
            }
        }

        private void OnRecalcLocation(object sender, EventArgs e)
        {
            this.RecalcLocation(sender);
        }

        public void RecalcLocation(object sender)
        {
            try
            {
                if (!this.Visible || this.Disposing || this.IsDisposed || this.Owner == null)
                {
                    (sender as Form).LocationChanged -= this.OnRecalcLocation;
                    (sender as Form).SizeChanged -= this.OnRecalcLocation;
                    return;
                }

                //var owner = sender as Form;
                var owner = this.Owner.WindowState == FormWindowState.Maximized && this.Owner.MdiParent != null ? this.Owner.MdiParent : this.Owner;

                switch (this.Direction)
                {
                    case PlatzkartBoxDirection.L:
                        this.Location = new Point(owner.Left + this.IndentHorizontal, owner.Bottom - this.Height - this.IndentVertical);
                        break;
                    case PlatzkartBoxDirection.R:
                        this.Location = new Point(owner.Right - this.Width - this.IndentHorizontal, owner.Bottom - this.Height - this.IndentVertical);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { 
            
            }
        }

        [Obsolete("test")]
        public static List<PlatzkartBox> CreatePlatzkartBoxes()
        {
            try
            {
                var platzkartBoxes = new List<PlatzkartBox>();

                //var s = "#PLATZKART#<Boxes><Box Number=\"1\" Direction=\"L\" Value=\"2\"/><Box Number=\"2\" Direction=\"R\" Value=\"1\"/></Boxes>#";
                var s = "#PLATZKART#<Boxes><Box Number=\"1\" Direction=\"R\" Value=\"2\"/></Boxes>#";

                var rgx = new System.Text.RegularExpressions.Regex(@"^#PLATZKART#(?<xml>.+)#$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                if (rgx.IsMatch(s))
                {
                    var m = rgx.Match(s);
                    var xml = m.Groups["xml"].Value;

                    var xDoc = new System.Xml.XmlDocument();

                    using (var sr = new System.IO.StringReader(xml))
                        xDoc.Load(sr);

                    var xDocRoot = xDoc.DocumentElement;
                    
                    foreach (System.Xml.XmlNode node in xDocRoot.SelectNodes("//Boxes//Box"))
                    {
                        var pb = new PlatzkartBox();

                        foreach (var pi in pb.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
                        {
                            var attr = node.Attributes[pi.Name];
                            if (attr != null)
                                pi.SetValue(pb, Convert.ChangeType(attr.Value, pi.PropertyType), pi.GetIndexParameters());
                        }

                        platzkartBoxes.Add(pb);
                    }
                }

                return platzkartBoxes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class PlatzkartBox
        {
            private PlatzkartPickDirectionForm _marker = null;

            public int Number { get; set; }
            public string Direction { get; set; }
            public string Value { get; set; }

            public PlatzkartBoxDirection PlatzkartBoxDirection
            {
                get { return (PlatzkartBoxDirection)Enum.Parse(typeof(PlatzkartBoxDirection), this.Direction); }
            }

            public void ChangeMarker(PlatzkartPickDirectionForm marker)
            {
                _marker = marker;
            }

            public void ClearMarker()
            {
                try
                {
                    if (_marker != null && _marker.Visible)
                    {
                        //_marker.Hide();
                        _marker.Close();
                        _marker.Dispose();
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _marker = null;
                }
            }
        }

        public class PlatzkartBoxesList : List<PlatzkartBox>
        {
            public new void Clear()
            {
                foreach (var item in this)
                    item.ClearMarker();

                base.Clear();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            timer.Interval = 1000;
            timer.Enabled = true;
        }

        private void PlatzkartPickDirectionForm_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.Clear(this.EmptyColor);
                g.DrawImage(this.Image, new Point(0, 0));

                var text = this.Value;
                var font = new Font("Microsoft Sans Serif", 75.0f, FontStyle.Bold);
                var rect = g.MeasureString(text, font);
                g.DrawString(text, font, showValue ? Brushes.Magenta : Brushes.Violet, this.Width / 2 - rect.Width / 2, this.Height / 2 - rect.Height / 2 + 10);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            showValue = !showValue;
            this.Invalidate();
        }

        private void PlatzkartPickDirectionForm_MouseClick(object sender, MouseEventArgs e)
        {
            //this.Close();
        }

        public enum PlatzkartBoxDirection
        {
            /// <summary>
            /// Слева
            /// </summary>
            L,

            /// <summary>
            /// Справа
            /// </summary>
            R
        }
    }
}
