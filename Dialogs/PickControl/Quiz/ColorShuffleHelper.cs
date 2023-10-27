using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WMSOffice.Dialogs.PickControl.Quiz
{
    public class ColorShuffleHelper
    {
        static List<Color> colors = new List<Color>();

        static ColorShuffleHelper()
        {
            colors.Add(Color.Green);
            colors.Add(Color.Blue);
            colors.Add(Color.Red);
            colors.Add(Color.Black);
        }

        public static Color GetColor(int idx)
        {
            return colors[idx % colors.Count];
        }
    }
}
