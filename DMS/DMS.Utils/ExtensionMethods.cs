using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Utils
{
    public static class ExtensionMethods
    {
        public static string ConvertNumberOfDaysToAge(this int ageInDays)
        {
            int years, months, days;
            List<string> resultParts = new List<string>();

            years = ageInDays / 365;
            if(years > 0) resultParts.Add(years.ToString() + " year" + (years > 1 ? "s": ""));
            
            months = (ageInDays - years * 365) / 30;
            if (months > 0) resultParts.Add(months.ToString() + " month" + (months > 1 ? "s" : ""));

            days = ageInDays - years * 365 - months * 30;
            if (days > 0) resultParts.Add(days.ToString() + " days");

            return string.Join(",", resultParts);
        }

        public static string ToAgeString(this int daysOld)
        {
            DateTime today = DateTime.Today;

            DateTime dob = DateTime.Today.AddDays(daysOld * -1);

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;

            List<string> resultParts = new List<string>();

            if (years > 0) resultParts.Add(years.ToString() + " year" + (years > 1 ? "s" : ""));
            if (months > 0) resultParts.Add(months.ToString() + " month" + (months > 1 ? "s" : ""));
            if (days > 0) resultParts.Add(days.ToString() + " days");

            return string.Join(", ", resultParts);
        }

        public static string ToAgeString(this DateTime dob)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                                 years, (years == 1) ? "" : "s",
                                 months, (months == 1) ? "" : "s",
                                 days, (days == 1) ? "" : "s");
        }
    }
}
