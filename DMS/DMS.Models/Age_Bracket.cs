using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    [Display (Name = "Age Bracket")]
    public class Age_Bracket
    {
        [Key]
        public int Age_Bracket_Id { get; set; }
        [StringLength(50), Display(Name = "Bracket Name")]
        public string Name { get; set; }
        [Required, Range(1, 3650), Display(Name = "Minimum age in Days", Prompt = "Minimum age of a child expressed in days. Used for reports.")]
        public int MinDays { get; set; }
        [Required, Range(1, 3650), Display(Name = "Maximum age in Days", Prompt = "Maximum age of a child expressed in days. Used for reports and to determine agin out students.")]
        public int MaxDays { get; set; }
    }
}
