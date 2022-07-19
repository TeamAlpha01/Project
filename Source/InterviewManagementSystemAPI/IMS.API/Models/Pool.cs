using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Pool
    {
        
         public Pool()
        {
           
            //EmployeesUnderPool = new HashSet<Employee>();
            PoolMembers= new HashSet<PoolMembers>();
        }
        [Key]
        public int PoolId { get; set; }
        [Required]
        [StringLength(25)]
        public string ?PoolName { get; set; }

        public int DepartmentId { get; set; }
        public bool IsActive { get; set; } = true;

        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("Pools")]
        public Department ?department { get; set; }


        [InverseProperty("Pools")]
        public ICollection<PoolMembers> PoolMembers { get; set; }

        [InverseProperty("Pool")]
        public List<Drive>? DrivesUnderPool { get; set; }

        // [InverseProperty("Pool")] 
        // public ICollection<Employee> EmployeesUnderPool { get; set; }



    }
}