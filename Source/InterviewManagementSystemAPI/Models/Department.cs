using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Models
{
    public class Department
    {
        public Department()
        {
            Pools = new HashSet<Pool>();
            Projects = new HashSet<Project>();
        }
        [Key]
        public int DepartmentId{get; set;}
        [Required]
        [StringLength(25)]
        public string DepartmentName{get;set;}
        public bool IsActive { get; set; } = true;

        [InverseProperty("department")]
        public ICollection<Pool> Pools{get;set; }

        [InverseProperty("department")]
        public ICollection<Project>? Projects { get; set; }
        [InverseProperty("Department")]
        public ICollection<Employee> EmployeesUnderDepartment{get;set;}

        
    }
}

///Temproary Model