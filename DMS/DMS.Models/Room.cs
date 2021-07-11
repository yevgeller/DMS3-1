using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace DMS.Models
{
    [DebuggerDisplay("${ForDisplay()}")]
    public class Room
    {
        [Key]
        public int Room_Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Max Capacity must be a number between 1 and 20")]
        public int MaxCapacity { get; set; }
        [ForeignKey("Age_Bracket")]
        public int Age_Bracket_Id { get; set; }
        public Age_Bracket Age_Bracket { get; set; }
        public bool Is_Active { get; set; }
        public string Description { get; set; }
        public string ForDisplay()
        {
            return $"{Room_Id}-{Name}-{MaxCapacity}-{Description}";
        }
    }
}