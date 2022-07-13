using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Models
{
    [NotMapped]
    public class User
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}