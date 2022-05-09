using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Model
{
    public class Department
    {
        [Key]
        public int DeparmentId{get; set;}
        [Required]
        [StringLength(25)]
        public string DepartmentName  { get; set; }

        public bool IsActive { get; set; } = true;
        [InverseProperty("department")]
        public ICollection<Project>? Projects { get; set; }
    }
}