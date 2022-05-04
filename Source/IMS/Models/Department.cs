using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId{get; set;}
        [Required]
        [StringLength(25)]
        public string DepartmentName{get;set;}
        public bool IsActive { get; set; } = true;
         [InverseProperty("department")]
        public List<Pool> Pools{get;set; }
        

        
    }
}