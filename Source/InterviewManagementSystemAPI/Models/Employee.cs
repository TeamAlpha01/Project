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
        public int EmployeeId{get; set;}
        public string EmployeeAceNumber  { get; set; }
        public string Name  { get; set; }
        public int DepartmentId  { get; set; }
        public int RoleId  { get; set; }
        public int ProjectId  { get; set; }
        public string EmailId  { get; set; }
        public string Password  { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsAdminAccepted {get;set;} = false;
        public bool IsAdminResponded {get;set;} = false;


        [InverseProperty("AddedEmployee")]
        public ICollection<Drive>? AddedEmployeeDrives { get; set; }

        [InverseProperty("UpdatedEmployee")]
        public ICollection<Drive>? UpdatedEmployeeDrives { get; set; }

        [InverseProperty("Employee")]
        public ICollection<EmployeeDriveResponse>? EmployeeDriveResponses { get; set; }

        [InverseProperty("Employee")]
        public ICollection<EmployeeAvailability>? EmployeeSlotResponses { get; set; }
        // [InverseProperty("Employees")]
        // public PoolMembers PoolMembers{get;set;}
    }
}