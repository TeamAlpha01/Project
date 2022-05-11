using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Role
    {
        [Key]
        public int RoleId{get; set;}
        [Required]
        [StringLength(35)]
        public string RoleName  { get; set; }

        public bool IsActive { get; set; } = true;
        
    }
}