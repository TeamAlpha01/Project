using System.ComponentModel.DataAnnotations;
namespace IMS.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId{get; set;}
        public int ProjectId  { get; set; }
        public string EmployeeAceNumber  { get; set; }
        public string EmployeeName  { get; set; }
        public int DepartmentId  { get; set; }
        public int RoleId  { get; set; }
        public string EmailId  { get; set; }
        public string Password  { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsAdminAccepted {get;set;} = false;
        public bool IsAdminResponded {get;set;} = false;

    }
}