using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using System.Web.UI.WebControls;

namespace LD5.DP
{
    public static class InOut
    {
        /// <summary>
        /// Read event's dates
        /// </summary>
        /// <param name="fileName">current file name</param>
        /// <returns>list of dates</returns>
        public static List<Dates> ReadDates (string fileName)
        {
            using(StreamReader reader = new StreamReader(fileName))
            {
                List<Dates> dates = new List<Dates>();

                string line;

                int year = Convert.ToInt32(reader.ReadLine());
                
                while((line = reader.ReadLine()) != null)
                {
                    string[] value = line.Split(';');

                    if(value.Length > 2)
                    {
                        throw new Exception("Per didelis kiekis duomenų!");
                    }

                    DateTime monthDay = Convert.ToDateTime(value[0], CultureInfo.InvariantCulture);
                    string @event = value[1];


                    Dates date = new Dates(year, monthDay, @event);
                    
                    dates.Add(date);
                }
                return dates;
            }
        }
        /// <summary>
        /// Reads dates who are important for country
        /// </summary>
        /// <param name="fileName">current file name</param>
        /// <returns>list of important dates for country</returns>
        public static List<StateDates> ReadStateDates (string fileName)
        {
            using(StreamReader reader = new StreamReader(fileName))
            {
                List<StateDates> statedates = new List<StateDates>();

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] value = line.Split(';');

                     DateTime monthDay = Convert.ToDateTime(value[0], CultureInfo.InvariantCulture);
                     string dayName = value[1];

                     StateDates stateDates = new StateDates(monthDay, dayName);
                     statedates.Add(stateDates);
                }
                return statedates;
            }
        }
        /// <summary>
        /// Prints initial data to txt
        /// </summary>
        /// <param name="fileName">current file name</param>
        /// <param name="dates">list of event's dates</param>
        /// <param name="statedates">list of important dates for country</param>
        public static void PrintDataToTxt(string fileName, List<Dates> dates, List<StateDates> statedates)
        {
            using(StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine("Important days for country: ");
                writer.WriteLine(new string('-', 75));
                foreach(StateDates sdate in statedates)
                {
                    writer.WriteLine(sdate.ToString());
                }
                writer.WriteLine(new string('-', 75));
                writer.WriteLine();
                writer.WriteLine("Important events: ");
                writer.WriteLine(new string('-', 75));

                foreach (Dates date in dates)
                {
                    writer.WriteLine(date.ToString());
                }
                writer.WriteLine(new string('-', 75));
            }
        }

        public static void PrintExactlyDaysToTxt(string fileName, IOrderedEnumerable<Results> exactlyDays)
        {
            using(StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine("Important days and important events are on the same month and day");
                writer.WriteLine(new string('-', 75));
                writer.WriteLine();
                foreach (Results results in exactlyDays)
                {
                    writer.WriteLine(results.ToString());
                }
                writer.WriteLine(new string('-', 75));
            }
        }

        public static void PrintMostMonthToTxt(string fileName, int month)
        {
            using(StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine("In {0} month have been organised most events", month);
            }
        }

        public static void PrintDataToTable(Table table1, List<StateDates> statedates, string header)
        {
            TableRow headerRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = header;
            cell.ColumnSpan = 2;
            headerRow.Cells.Add(cell);
            table1.Rows.Add(headerRow);

            foreach(StateDates sdate in statedates)
            {
                TableRow sdateRows = new TableRow();

                TableCell monthDay = new TableCell(); monthDay.Text = sdate.MonthDay.ToString("MM'-'dd"); sdateRows.Cells.Add(monthDay);
                TableCell daysName = new TableCell(); daysName.Text = sdate.DaysName; sdateRows.Cells.Add(daysName);

                table1.Rows.Add(sdateRows);
            }        
        }

        public static void PrintDataToTable2(Table table2, List<Dates> dates, string header)
        {
            TableRow headerRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = header;
            cell.ColumnSpan = 3;
            headerRow.Cells.Add(cell);
            table2.Rows.Add(headerRow);

            foreach (Dates date in dates)
            {
                TableRow dateRows = new TableRow();

                TableCell year = new TableCell(); year.Text = date.Year.ToString(); dateRows.Cells.Add(year);
                TableCell monthDay = new TableCell(); monthDay.Text = date.MonthDay.ToString("MM'-'dd"); dateRows.Cells.Add(monthDay);
                TableCell Event = new TableCell(); Event.Text = date.Event; dateRows.Cells.Add(Event);

                table2.Rows.Add(dateRows);
            }
        }

        public static void PrintExactlyDaysToTable(Table table3, IOrderedEnumerable<Results> exactlyDays, string header)
        {
            TableRow headerRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = header;
            cell.ColumnSpan = 4;
            headerRow.Cells.Add(cell);
            table3.Rows.Add(headerRow);

            foreach(Results results in exactlyDays)
            {
                TableRow resultsRow = new TableRow();

                TableCell simpleDay = new TableCell(); simpleDay.Text = results.simpleDay; resultsRow.Cells.Add(simpleDay);
                TableCell importantDay = new TableCell(); importantDay.Text = results.importantDay; resultsRow.Cells.Add(importantDay);
                TableCell years = new TableCell(); years.Text = results.Years.ToString(); resultsRow.Cells.Add(years);
                TableCell monthDay = new TableCell(); monthDay.Text = results.MonthDay.ToString("MM'-'dd"); resultsRow.Cells.Add(monthDay);

                table3.Rows.Add(resultsRow);

            }
        }
    }
}