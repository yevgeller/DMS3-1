using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DMS.Models
{
    public class Students_OutOfRoomAgeBracket_List
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_Name { get; set; }
        public DateTime Student_Birthdate { get; set; }
        public bool Student_AgeWithinRoomRange { get; set; }
        public int Student_AgeInDays { get; set; }
        public int Room_Bracket_MinDays { get; set; }
        public int Room_Bracket_MaxDays { get; set; }
        public string Room_Name { get; set; }
        public string Age_Bracket_Name { get; set; }
        public int Student_Age_DaysOver { get; set; }
        public int Student_Age_DaysUnder { get; set; }
        public int Room_Id { get; set; }
        public int Age_Bracket_Id { get; set; }
    }
}
