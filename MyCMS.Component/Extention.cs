using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kendo.Mvc.UI
{
    public static class KendoExtention
    {
        public static string GetPersianCalendar(this DateTime helper, string format = "yyyy/mm/dd")
        {

            if (helper.Year < 1000) helper = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();

            string result = format.ToLower();

            result = result.Replace("yyyy", pc.GetYear(helper).ToString());

            result = result.Replace("mm", pc.GetMonth(helper).ToString());

            result = result.Replace("dd", pc.GetDayOfMonth(helper).ToString());

            return result;
        }

        public static DateTime GetEnglishCalendar(this string helper)
        {
            string pattern = @"(?>((?>13|14)\d\d)|(\d\d))\/(0?[1-9]|1[012])\/([12][0-9]|3[01]|0?[1-9])";
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(helper, pattern))
                {
                          
                    System.Text.RegularExpressions.Regex d = new System.Text.RegularExpressions.Regex(pattern);



                    int year = int.Parse(d.Match(helper).Groups[1].Value);

                    int month = int.Parse(d.Match(helper).Groups[3].Value);

                    int day = int.Parse(d.Match(helper).Groups[4].Value);

                    if (year > 1500)
                        return new DateTime(year, month, day, 0, 0, 0, 0);
                    
                    PersianCalendar result = new PersianCalendar();

                    return result.ToDateTime(year, month, day, 0, 0, 0, 0);
                }

            }
            catch (Exception)
            {

            }
            return Convert.ToDateTime(helper);
        }
    }

}