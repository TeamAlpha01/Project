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