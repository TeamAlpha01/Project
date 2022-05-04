using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Location
    {
        [Key]
        public int LocationId{get; set;}
        [Required]
        [StringLength(25)]
        public string LocationName{get;set;}
        public bool IsActive { get; set; } = true;
        

        
    }
}