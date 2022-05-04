using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class EmployeeDriveResponse
    {
        [Key]
        public int ResponseId { get; set; }
        public int DriveId { get; set; }
        public int EmployeeId { get; set; }
        public int ResponseType { get; set; }

        [ForeignKey("DriveId")]
        [InverseProperty("DriveResponses")]
        public Drive? Drive { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("EmployeeResonses")]
        public Employee? Employee { get; set; }

    }
}