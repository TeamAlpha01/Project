using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewManagementSystemAPI.Models
{
    public class Employee
    {
        public Employee()
        {
            AddedEmployeeDrives = new HashSet<Drive>();
            UpdatedEmployeeDrives = new HashSet<Drive>();
        }
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [InverseProperty("AddedEmployee")]
        public ICollection<Drive>? AddedEmployeeDrives { get; set; }

        [InverseProperty("UpdatedEmployee")]
        public ICollection<Drive>? UpdatedEmployeeDrives { get; set; }
    }
}