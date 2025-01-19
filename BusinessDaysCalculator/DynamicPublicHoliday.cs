using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessDaysCalculator
{
    public class DynamicPublicHoliday : BaseHoliday
    {
        public DynamicPublicHoliday(int year, int month, DayOfWeek dayOfWeek, int occurrence, bool carryForward = false, string name = "")
        {
            Year = year;
            Month = month;
            DayOfWeek = dayOfWeek;
            Occurrence = occurrence;
            CarryForward = carryForward;
            Name = name;
        }
        private DayOfWeek DayOfWeek { get; set; }
        private int Occurrence { get; set; }
        public override DateTime? Date => GetDynamicDate();

        private DateTime? GetDynamicDate()
        {
            var occourance = 0;
            var date = new DateTime(Year, Month, 1);

            for (int i = 0; i < DateTime.DaysInMonth(Year, Month);i++)
            {
                date = date.AddDays(1);
                if (DayOfWeek == date.DayOfWeek)
                {
                    occourance++;
                    if (occourance == Occurrence)
                    {
                        return date;
                    }
                }
            }
            return null;
        }
    }
}
