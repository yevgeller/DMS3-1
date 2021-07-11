using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Contact
    {
        [Key]
        public int Contact_Id { get; set; }
        public string Value { get; set; }
        public string Password { get; set; }
        [ForeignKey("Contact_Type")]
        public int Contact_Type_Id { get; set; }
        public Contact_Type Contact_Type { get; set; }
    }
}
