using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.DP
{
    public class Dates
    {
        public int Year { get; set; }
        public DateTime MonthDay { get; set; }
        public string Event { get; set; }

        public Dates(int year, DateTime monthDay, string @event)
        {
            Year = year;
            MonthDay = monthDay;
            Event = @event;
        }

        public override string ToString()
        {
            return string.Format(" {0} | {1} | {2,-25} |", Year, MonthDay.ToString("MM'-'dd"), Event);
        }
    }
}