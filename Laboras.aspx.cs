using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LD5.DP
{
    public partial class Laboras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if(File.Exists(Server.MapPath("App_Data/Results.txt")))
            {
                File.Delete(Server.MapPath("App_Data/Results.txt"));
            }
            if(File.Exists(Server.MapPath("App_Data/InitialData.txt")))
            {
                File.Delete(Server.MapPath("App_Data/InitialData.txt"));
            }

            // -------------------------------------------------------------------------------------------------------

            List<StateDates> stateDates = InOut.ReadStateDates(Server.MapPath("App_Data/StateDates/StateDates.txt"));

            // -------------------------------------------------------------------------------------------------------

            string[] fileReader = Directory.GetFiles(Server.MapPath("App_Data/"));
            List<Dates> dates = new List<Dates>();

            foreach (var reader in fileReader)
            {
                try
                {
                    List<Dates> tempDates = InOut.ReadDates(reader);
                    dates = dates.Concat(tempDates).ToList();
                }

                catch(Exception ex)
                {
                    Label3.Visible = true;
                    Label3.Text = ex.Message;
                }
            }

            // -------------------------------------------------------------------------------------------------------

            string initialData = Server.MapPath("App_Data/InitialData.txt");
            InOut.PrintDataToTxt(initialData, dates, stateDates);
            InOut.PrintDataToTable(Table1, stateDates, "Important days for country");
            InOut.PrintDataToTable2(Table2, dates, "Important events");

            // -------------------------------------------------------------------------------------------------------

            Session["stateDates"] = stateDates;
            Session["dates"] = dates;
            Session["Table1"] = Table1;
            Session["Table2"] = Table2;


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string resultsFile = Server.MapPath("App_Data/Results.txt");

            // -------------------------------------------------------------------------------------------------------

            List<StateDates> stateDates = (List<StateDates>)Session["stateDates"];
            List<Dates> dates = (List<Dates>)Session["dates"];

            if (Session["Table1"] != null)
            {
                Table temp = (Table)Session["Table1"];
                for (int i = 0; i < temp.Rows.Count;)
                {
                    Table1.Rows.Add(temp.Rows[i]);
                }
            }

            if (Session["Table2"] != null)
            {
                Table temp = (Table)Session["Table2"];
                for (int i = 0; i < temp.Rows.Count;)
                {
                    Table2.Rows.Add(temp.Rows[i]);
                }
            }

            // -------------------------------------------------------------------------------------------------------
            
            var exactlyDays = (from stateDate in stateDates
                               from date in dates
                               where (stateDate.MonthDay == date.MonthDay)
                               select new Results(date.Event, stateDate.DaysName, date.Year, date.MonthDay)).ToList();
            // This linq finds event dates that were organised on the same date as countrie's dates
            // -------------------------------------------------------------------------------------------------------

            var sort = exactlyDays.OrderBy(first => first.Years).ThenBy(second => second.MonthDay.Month);
            // This linq sorts by 2 keys

            // -------------------------------------------------------------------------------------------------------

            var temporary = stateDates.Select(onlyMonths => onlyMonths.MonthDay.Month).Distinct().ToList();
            // this linq removes duplicates
            int maximum = 0;
            int month = 0;

            foreach (var item in temporary)
            {
                int count = exactlyDays.Where(value => value.MonthDay.Month == item).Count();
                // this linq counts how many times same month was repeated
                if (count > maximum)
                {
                    maximum = count;
                    month = item;
                }
            }

            // -------------------------------------------------------------------------------------------------------

            InOut.PrintExactlyDaysToTxt(resultsFile, sort);
            InOut.PrintMostMonthToTxt(resultsFile, month);
            InOut.PrintExactlyDaysToTable(Table3, sort, "Important days and important events are on the same month and day");

            Label2.Visible = true;
            Label2.Text = String.Format("In {0} month have been organised most events", month);

        }
    }
}