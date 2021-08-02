using DMS.Utils;
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
            return BornDaysAfterJan12000.ToAgeString();
        }
    }
}
