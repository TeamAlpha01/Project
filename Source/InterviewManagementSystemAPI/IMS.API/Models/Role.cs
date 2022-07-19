using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Role
    {
        
         public Role()
        {
           
            EmployeesUnderRole = new HashSet<Employee>();
        }
        [Key]
        public int RoleId{get; set;}
        [Required]
        [StringLength(100)]
        public string ?RoleName  { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsManagement{get;set;}=false;
        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [InverseProperty("Role")] 
        public ICollection<Employee> EmployeesUnderRole { get; set; }
        
        
    }
}