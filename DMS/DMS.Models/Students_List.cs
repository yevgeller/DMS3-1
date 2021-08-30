using DMS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DMS.Models
{
    [Table("Students_List")]
    public class Students_List
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Is_Active { get; set; }
        public int DaysOld { get; set; }
        public int BornDaysAfterJan12000 { get; set; }
        public string AssignedToRooms { get; set; }
        public string AssignedToParents { get; set; }
        public int AssignedGuardianCount { get; set; }
        public string Age()
        {
            return DaysOld.ToAgeString();
        }
    }
}
