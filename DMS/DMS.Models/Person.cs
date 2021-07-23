using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    [DebuggerDisplay("{ForDisplay()}")]
    public class Person
    {
        [Key]
        public int Person_Id { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "User Name may not be longer than 250 characters")]
        public string Name { get; set; }
        [Display(Name = "Active?")]
        public bool Is_Active { get; set; }
        [ForeignKey("Person_Type"), Display(Name = "Person Type")]
        public int Person_Type_Id { get; set; }
        public Person_Type Person_Type { get; set; }
        public string Password { get; set; }
        public virtual string ForDisplay()
        {
            return $"{Person_Id}-{Name}";
        }
    }
}