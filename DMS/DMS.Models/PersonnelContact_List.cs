using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DMS.Models
{
    [Table("PersonnelContact_List")]
    public class PersonnelContact_List
    {
        [Key]
        public int Contact_Id { get; set; }
        public int Contact_Type_Id { get; set; }
        public string Contact_Type_Name { get; set; }
        public string Value { get; set; }
        public int Person_Id { get; set; }
        public string Person_Name { get; set; }
        public int Person_Type_Id { get; set; }
        public string Person_Type_Name { get; set; }
        public bool Is_Active { get; set; }
    }
}
