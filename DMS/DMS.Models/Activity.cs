using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Activity
    {
        [Key]
        public int Activity_Id { get; set; }

        [ForeignKey("Student"), Display(Name ="STudent")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Activity_Type"), Display(Name = "Activity Type")]
        public int Activity_Type_Id { get; set; }
        public Activity_Type Activity_Type { get; set; }
        [Display(Name = "Created On")]
        public DateTime Created_On { get; set; }
        [ForeignKey("Person"), Display(Name = "Created by")]
        public int Created_By_Id { get; set; }
        public Person Created_By { get; set; }
        [Required, StringLength(2500)]
        public string Note { get; set; }


    }
}
