using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Location
    {
        public Location()
        {
            DrivesUnderLocation = new HashSet<Drive>();
        }
        [Key]
        public int LocationId { get; set; }
        [Required]
        [StringLength(15)]
        public string ? LocationName { get; set; }
        public bool IsActive { get; set; } = true;
        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


        [InverseProperty("Location")]
        public ICollection<Drive>? DrivesUnderLocation { get; set; }



    }
}