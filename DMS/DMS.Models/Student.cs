using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Student
    { 
        [Key]
        public int Student_Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public bool Is_Active { get; set; }
    }
}
