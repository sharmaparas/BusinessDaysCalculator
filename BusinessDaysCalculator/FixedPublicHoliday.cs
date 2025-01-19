using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessDaysCalculator
{
    public class FixedPublicHoliday: BaseHoliday
    {
        public FixedPublicHoliday(int year, int month, int day, bool carryForward = false, string name = "")
        {
            Year = year; 
            Month = month;
            Day = day;
            CarryForward = carryForward;
            Name = name;
        }
        private int Day { get; set; }
        public override DateTime? Date => CarryForward ? AdjustForWeekend(new DateTime(Year, Month, Day)) : new DateTime(Year, Month, Day);

        private DateTime AdjustForWeekend(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    date = date.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    date = date.AddDays(2);
                    break;
                default:
                    break;
            }
            return date;
        }
    }
}
