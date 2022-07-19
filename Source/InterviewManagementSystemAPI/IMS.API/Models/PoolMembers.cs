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
        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey("PoolId")]
        [InverseProperty("PoolMembers")]
        public Pool?Pools{get;set;}
        [ForeignKey("EmployeeId")]
        [InverseProperty("PoolMembers")]
        public Employee?Employees{get;set;}
      
        
    }
}