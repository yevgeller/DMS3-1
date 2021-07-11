using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Person_Type
    {
        //Parent, teacher, admin, Teacher Assisstant, Other
        [Key]
        public int Person_Type_Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
