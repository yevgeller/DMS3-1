using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Student_Room
    {
        [Key]
        public int Student_Room_Id { get; set; }
        [ForeignKey("Student"), Display(Name = "Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Room"), Display(Name = "Room")]
        public int Room_Id { get; set; }
        public Room Room { get; set; }
    }
}
