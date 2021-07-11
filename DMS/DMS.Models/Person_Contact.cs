using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Person_Contact
    {
        [Key]
        public int Person_Contact_Id { get; set; }
        [ForeignKey("Person")]
        public int Person_Id { get; set; }
        public Person Person { get; set; }
        [ForeignKey("Contact")]
        public int Contact_Id { get; set; }
        public Contact Contact { get; set; }
    }
}
