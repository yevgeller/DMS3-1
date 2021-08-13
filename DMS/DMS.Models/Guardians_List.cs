using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DMS.Models
{
    [Table("Guardians_List")]
    public class Guardians_List
    {
        [Key]
        public int Person_Id { get; set; }
        public string Name { get; set; }
        public bool Is_Active { get; set; }
        public int Person_Type_Id { get; set; }
        public string AssignedStudents { get; set; }
    }
}
