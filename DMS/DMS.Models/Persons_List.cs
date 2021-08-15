using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace DMS.Models
{
    [Table("Persons_List")]
    [DebuggerDisplay("{Person_Id}-{Name}-{Person_Type_Name}-{Person_Qualifier}")]
    public class Persons_List
    {
        [Key]
        public int Person_Id { get; set; }
        public string Name { get; set; }
        public bool Is_Active { get; set; }
        public int Person_Type_Id { get; set; }
        public string Person_Type_Name { get; set; }
        public string TeacherRooms { get; set; }
        public int TeacherRoomsCount { get; set; }
        public string GuardianToStudents { get; set; }
        public int GuardianToStudentsCount { get; set; }
        public string Person_Qualifier { get; set; }
    }
}
