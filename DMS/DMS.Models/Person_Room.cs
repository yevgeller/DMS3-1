using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Person_Room
    {
        [Key]
        public int Person_Room_Id { get; set; }
        [ForeignKey("Person"), Display(Name = "Person")]
        public int Person_Id { get; set; }
        public Person Person { get; set; }
        [ForeignKey("Room"), Display(Name = "Room")]
        public int Room_Id { get; set; }
        public Room Room { get; set; }
    }
}
