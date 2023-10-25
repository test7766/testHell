using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace WMSOffice.Classes
{
    public static class DateTimeHelper
    {
        public static string[] AbbreviatedDayNames { get; private set; }

        static DateTimeHelper()
        {
            AbbreviatedDayNames = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.AbbreviatedDayNames;
        }

        public static DateTime StartOfWeek(DateTime self, DayOfWeek startOfWeek)
        {
            var diff = (7 + (self.DayOfWeek - startOfWeek)) % 7;
            return self.AddDays(-1 * diff);
        }

        public static DateTime EndOfWeek(DateTime self, DayOfWeek startOfWeek)
        {
            return StartOfWeek(self, startOfWeek).AddDays(6);
        }

        public static IEnumerable<DateTime> GetWeekDays(DateTime self)
        {
            var periodFrom = StartOfWeek(self, DayOfWeek.Monday);
            var periodTo = EndOfWeek(self, DayOfWeek.Monday);

            var days = (periodTo - periodFrom).Days + 1;

            var periods = new List<DateTime>();
            for (int i = 0; i < days; i++)
                periods.Add(periodFrom.AddDays(i));

            return periods;
        }

        public static string GetAbbreviatedDayName(DateTime self)
        {
            return AbbreviatedDayNames[(int)self.DayOfWeek];
        }
    }
}
