using System.ComponentModel.DataAnnotations;
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
        
    }
}