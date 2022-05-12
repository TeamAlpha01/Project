using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMS.Models
{
    public class Drive
    {
        public Drive()
        {
            DriveResponses = new HashSet<EmployeeDriveResponse>();
            DriveSoltResponse = new HashSet<EmployeeAvailability>();
        }
        [Key]
        public int DriveId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int DepartmentId { get; set; }
        public int PoolId { get; set; }
        public int ModeId { get; set; }
        public int LocationId { get; set; }
        public bool? IsScheduled { get; set; } = false;
        public bool? IsCancelled { get; set; } = false;
        public string? CancelReason { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public double SlotTiming { get; set; }

        

        [ForeignKey("AddedBy")]
        [InverseProperty("AddedEmployeeDrives")]
        public virtual Employee? AddedEmployee { get; set; }

        [ForeignKey("UpdatedBy")]
        [InverseProperty("UpdatedEmployeeDrives")]
        public virtual Employee? UpdatedEmployee { get; set; }

        [InverseProperty("Drive")]
        public ICollection<EmployeeDriveResponse>? DriveResponses { get; set; }

        [InverseProperty("Drive")]
        public ICollection<EmployeeAvailability>? DriveSoltResponse { get; set; }


        [ForeignKey("LocationId")]
        [InverseProperty("DrivesUnderLocation")]
        public virtual Location? Location { get; set; }

        [ForeignKey("PoolId")]
        [InverseProperty("DrivesUnderPool")]
        public virtual Pool? Pool { get; set; }
        
        [ForeignKey("DepartmentId")]
        [InverseProperty("DrivesUnderDepartment")]
        public virtual Department? Department { get; set; }

    }
}