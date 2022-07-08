using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;
using IMS.Validations;

namespace IMS.Validations
{
    public static class EmployeeAvailabilityValidation
    {
        public static void IsAvailabilityValid(EmployeeAvailability employeeAvailability)
        {
            EmployeeValidation.IsEmployeeIdValid(employeeAvailability.EmployeeId);
            DriveValidation.IsDriveIdValid(employeeAvailability.DriveId);
            //Default Values Setting
            employeeAvailability.From = DateTime.Parse(employeeAvailability.FromTime);
            employeeAvailability.To = DateTime.Parse(employeeAvailability.ToTime);
            employeeAvailability.IsInterviewCancelled=false;
            employeeAvailability.IsInterviewScheduled=false;
        }

        public static void IsAvailabilityIdValid(int employeeAvailabilityId)
        {
            if (employeeAvailabilityId <= 0) throw new ValidationException($"Ivalid EmployeeAvailabilityId : {employeeAvailabilityId}");
        }
    }
}