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
        public int Id { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "User Name may not be longer than 250 characters")]
        public string Name { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime BirthDate { get; set; }
        public bool Is_Active { get; set; }
        [ForeignKey("Person_Type")]
        public int Person_Type_Id { get; set; }
        public Person_Type Person_Type {get;set;}
        public virtual string ForDisplay()
        {
            return $"{Id}-{Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            Person p = obj as Person;

            if (p == null) return false;

            return Id == p.Id && Name == p.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}