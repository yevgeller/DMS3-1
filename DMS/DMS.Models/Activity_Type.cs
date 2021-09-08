using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    [DebuggerDisplay("{Activity_Type_Id}/{Name}/{SortOrder}")]
    [Display (Name ="Student or Classroom activity type name")]
    public class Activity_Type
    {
        [Key]
        public int Activity_Type_Id { get; set; }
        [Display(Name="Student or Classroom activity type Name")]
        [Required, StringLength(250)]
        public string Name { get; set; }
        [Required, Display(Name = "Sort Order"), Range(1, 1000)]
        public int SortOrder { get; set; }
        [Display(Name="Grouping, used to keep similar activities together"), MaxLength(250)]
        public string GroupingString { get; set; }

    }
}
