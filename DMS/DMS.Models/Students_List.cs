using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DMS.Models
{
    public class Students_List
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Is_Active { get; set; }
        public int BornDaysAfterJan12000 { get; set; }
        public string AssignedToRooms { get; set; }
    }
}
