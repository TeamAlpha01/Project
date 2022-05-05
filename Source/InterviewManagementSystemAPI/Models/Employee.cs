using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Models
{
    public class Employee
    {
        public Employee()
        {
            AddedEmployeeDrives = new HashSet<Drive>();
            UpdatedEmployeeDrives = new HashSet<Drive>();
            EmployeeDriveResponses = new HashSet<EmployeeDriveResponse>();
            EmployeeSlotResponses = new HashSet<EmployeeAvailability>();
        }
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [InverseProperty("AddedEmployee")]
        public ICollection<Drive>? AddedEmployeeDrives { get; set; }

        [InverseProperty("UpdatedEmployee")]
        public ICollection<Drive>? UpdatedEmployeeDrives { get; set; }

        [InverseProperty("Employee")]
        public ICollection<EmployeeDriveResponse>? EmployeeDriveResponses { get; set; }

        [InverseProperty("Employee")]
        public ICollection<EmployeeAvailability>? EmployeeSlotResponses { get; set; }
        [InverseProperty("Employees")]
        public PoolMembers PoolMembers{get;set;}
    }
}