using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.DP
{
    public class StateDates
    {
        public DateTime MonthDay { get; set; }
        public string DaysName { get; set; }

        public StateDates(DateTime monthDay, string daysName)
        {
            MonthDay = monthDay;
            DaysName = daysName;
        }

        public override string ToString()
        {
            return string.Format(" {0} | {1,-25} |", MonthDay.ToString("MM'-'dd"), DaysName);
        }
    }
}