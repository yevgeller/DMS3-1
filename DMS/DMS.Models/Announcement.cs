using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Announcement
    {
        [Key]
        public int Announcement_Id { get; set; }
        [DataType(DataType.DateTime), Display(Name = "Created on")]
        public DateTime Created_On { get; set; }
        [ForeignKey("Person"), Display(Name = "Created by")]
        public int Created_By_Id { get; set; }
        public Person Created_By { get; set; }
        [Required, StringLength(2500)]
        public string Note { get; set; }

    }
}
