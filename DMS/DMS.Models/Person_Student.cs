using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Person_Student
    {
        [Key]
        public int Person_Student_Id { get; set; }
        [ForeignKey("Person")]
        public int Person_Id { get; set; }
        public Person Person { get; set; }
        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }
    }
}
