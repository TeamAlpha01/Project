using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId{get; set;}
        [Required]
        [StringLength(25)]
        public string EmployeeName{get;set;}
        
        [InverseProperty("employees")]
        public PoolMembers poolMembers{get;set;}
    }
}