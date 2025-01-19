using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDaysCalculator
{
    public class BaseHoliday
    {
        public string? Name { get; set; }
        protected bool CarryForward { get; set; }
        protected int Year { get; set; }
        protected int Month { get; set; }
        public virtual DateTime? Date { get; }
    }
}
