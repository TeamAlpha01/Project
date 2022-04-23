using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Source.Models
{
    public class Role : IRole
    {
        [Key]
        public int RoleId{get; set;}
        [Required]
        [StringLength(25)]
        public string RoleName  { get; set; }
        
        public bool IsActive { get; set; }
        
    }
}