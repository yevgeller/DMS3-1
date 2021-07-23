using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    [DebuggerDisplay("{Person_Type_Id}-{Name}")]
    public class Person_Type
    {
        //Parent, teacher, admin, Teacher Assisstant, Other
        [Key]
        public int Person_Type_Id { get; set; }
        [Required, StringLength(50), Display(Name="Person Type name")]
        public string Name { get; set; }
    }
}
