using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DMS.Models
{
    public class RoomGeneralInfo_List
    {
        [Key]
        public int Room_Id { get; set; }
        public string Room_Description { get; set; }
        public bool Room_Is_Active { get; set; }
        public int Room_MaxCapacity { get; set; }
        public string Room_Name { get; set; }
        public int Youngest_Student_Id { get; set; }
        public string Youngest_Student_Name { get; set; }
        public int Youngest_Student_DaysOld { get; set; }
        public int Oldest_Student_Id { get; set; }
        public string Oldest_Student_Name { get; set; }
        public int Oldest_Student_DaysOld { get; set; }
        public int AvgStudentAgeInDays { get; set; }
        public int TeachersInRoom { get; set; }
        public int TAsInRoom { get; set; }
        public int StudentsInRoom { get; set; }
        public int StudentsOutOfAgeBracket { get; set; }
    }
}
