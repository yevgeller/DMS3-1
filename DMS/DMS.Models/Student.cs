using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    [DebuggerDisplay("{Student_Id}/{Name}/{Birthdate.ToShortDateString()}")]
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Birth date")]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Active?")]
        public bool Is_Active { get; set; }

        public int BornDaysAfterJan12000 { get; set; }
        public string Age()
        {
            if (this.Birthdate == null)
                return "N/A";

            if (DateTime.Now < this.Birthdate)
                return "N/A";

            string result = string.Empty;
            int years =  (DateTime.Now - this.Birthdate).Days / 365;
            int months = DateTime.Now.Month - this.Birthdate.Month;
            if (months < 0) months += 12;

            int days = 0;
            if(DateTime.Now.Day > this.Birthdate.Day)
            {
                days = DateTime.Now.Day - this.Birthdate.Day;
            }

            List<string> results = new List<string>();

            if (years > 0)
                results.Add(years.ToString() + " year" + (years > 1 ? "s" : ""));

            if (months > 0)
                results.Add(months.ToString() + " month" + (months > 1 ? "s" : ""));

            if(days > 0)
                results.Add(days.ToString() + " day" + (days > 1 ? "s" : ""));

            return String.Join(", ", results) + " old";
        }
    }
}
