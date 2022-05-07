using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IMS.Models
{
    public class EmployeeAvailability
    {
        public int EmployeeAvailabilityId { get; set; }
        public int  DriveId { get; set; }
        public int  EmployeeId { get; set; }        
        public DateTime InterviewDate { get; set; }
        // public TimeSpan FromTime { get; set; }
        // public TimeSpan ToTime { get; set; }
        public bool IsInterviewScheduled { get; set; }
        public bool IsInterviewCancelled { get; set; }
        public string? CancellationReason { get; set; }
        public string? Comments { get; set; }

        [ForeignKey("DriveId")]
        [InverseProperty("DriveSoltResponse")]
  
        public Drive? Drive { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("EmployeeSlotResponses")]
        public Employee? Employee { get; set; }
        
    }
}