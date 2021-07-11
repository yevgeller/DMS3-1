using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    [Display (Name ="Student or Classroom activity type name")]
    public class Activity_Type
    {
        [Key]
        public int Activity_Type_Id { get; set; }
        [Display(Name="Student or Classroom activity type Name")]
        [Required, StringLength(250)]
        public string Name { get; set; }
    }
}
