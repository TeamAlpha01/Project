using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Pool
    {
        [Key]
        public int PoolId { get; set; }
        [Required]
        [StringLength(25)]
        public string PoolName { get; set; }

        public int DepartmentId { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("DepartmentId")]
        [InverseProperty("Pools")]
        public Department department { get; set; }


        [InverseProperty("Pools")]
        public List<PoolMembers> PoolMembers { get; set; }

        [InverseProperty("Pool")]
        public List<Drive> DrivesUnderPool { get; set; }



    }
}