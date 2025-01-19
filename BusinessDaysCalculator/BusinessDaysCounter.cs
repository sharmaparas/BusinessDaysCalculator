using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDaysCalculator
{
    public class BusinessDaysCounter
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            int result = 0;
            if (secondDate <= firstDate)
            {
                return 0;
            }
            else
            {
                var totalNumberOfDays = secondDate.Subtract(firstDate).Days - 1; // Exclude start and end days
                int fullWeeks = totalNumberOfDays / 7;
                result = fullWeeks * 5;

                var remainingDays = totalNumberOfDays % 7;
                for (int i = 0; i < remainingDays; i++)
                {
                    var currentDay = firstDate.AddDays(1);
                    if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime>
        publicHolidays)
        {
            int result = 0;
            if (secondDate <= firstDate)
            {
                return result;
            }
            var totalWeekdays = WeekdaysBetweenTwoDates(firstDate, secondDate);
            int holidayCount = 0;
            if (publicHolidays != null)
            {
                holidayCount = publicHolidays
                 .Where(x => x > firstDate && x < secondDate)
                 .Count(x => x.DayOfWeek >= DayOfWeek.Monday && x.DayOfWeek <= DayOfWeek.Friday);
            }

            return totalWeekdays - holidayCount;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<BaseHoliday> publicHolidays)
        {
            if (secondDate <= firstDate)
            {
                return 0;
            }

            int totalWeekdays = WeekdaysBetweenTwoDates(firstDate, secondDate);
            int holidayCount = 0;

            if (publicHolidays != null)
            {
                holidayCount = publicHolidays.Count(x =>
                    x.Date > firstDate &&
                    x.Date < secondDate &&
                    (x.Date.HasValue && x.Date.Value.DayOfWeek >= DayOfWeek.Monday) &&
                    (x.Date.HasValue && x.Date.Value.DayOfWeek <= DayOfWeek.Friday));
            }
            return totalWeekdays - holidayCount;
        }

    }
}
