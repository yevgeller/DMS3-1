using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Contact_Type
    {
        [Key]
        public int Contact_Type_Id { get; set; }
        [Required, StringLength(50), Display(Name="Contact Type name")]
        public string Name { get; set; }
    }
}
