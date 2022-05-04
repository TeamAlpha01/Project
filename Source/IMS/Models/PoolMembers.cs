using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class PoolMembers
    {
        [Key]
        public int PoolMembersId{get; set;}
      
        public int EmployeeId{get;set;}
        
        public int PoolId{get;set;}

        public bool IsActive { get; set; } = true;

        [ForeignKey("PoolId")]
        [InverseProperty("poolMembers")]
        public Pool pools{get;set;}
        [ForeignKey("EmployeeId")]
        [InverseProperty("poolMembers")]
        public Employee employees{get;set;}
      
        
    }
}