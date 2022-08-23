using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.DP
{
    public class Results
    {
        public string simpleDay { get; set; }
        public string importantDay { get; set; }
        public int Years { get; set; }
        public DateTime MonthDay { get; set; }

        public Results(string simpleDay, string importantDay, int years, DateTime monthday)
        {
            this.simpleDay = simpleDay;
            this.importantDay = importantDay;
            Years = years;
            this.MonthDay = monthday;
        }

        public override string ToString()
        {
            return string.Format("{0,-25} | {1,-25} | {2,-3} | {3} |", simpleDay, importantDay, Years, MonthDay.ToString("MM'-'dd"));
        }
    }
}