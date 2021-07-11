using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Models
{
    public class Age_Bracket
    {
        [Key]
        public int Age_Bracket_Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
