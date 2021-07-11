using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Announcement_Addressee
    {
        [Key]
        public int Announcement_Addressee_Id { get; set; }
        [ForeignKey("Person")]
        public int Addressee_Id { get; set; }
        public Person Addressee { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Sent_On { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Acknowledged_On { get; set; }
    }
}
