using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class DriveValidation
    {
        public static void IsdriveValid(Drive drive)
        {
            if (drive == null) throw new ValidationException("drive object cannot be null");

            if (drive.Name.Length <= 2) throw new ValidationException("drive name is too short");

            if(!Regex.IsMatch(drive.Name,"^[a-zA-Z0-9]+\\s[a-zA-Z][{2,20}$")) throw new ValidationException("drive name cannot contain symbols or numbers");

            if (drive.FromDate.Date < System.DateTime.Now.Date.AddDays(5)) throw new ValidationException($"From date must be greater than {System.DateTime.Now.Date.AddDays(5).Date}");

            if (drive.ToDate.Date < drive.FromDate.Date) throw new ValidationException("To date must be greater than from date");
            
        }
        public static void IsCancelDriveValid(int driveId, int tacId, string reason)
        {
            IsDriveIdValid(driveId);
            IsEmployeeIdValid(tacId);
            if (reason == null) throw new ValidationException("Reason cannot be null");
        }
        public static void IsDriveIdValid(int driveId)
        {
            if (driveId <= 0) throw new ValidationException("drive id is invalid");
        }
        public static void IsEmployeeIdValid(int employeeId)
        {
            if (employeeId <= 0) throw new ValidationException("TAC id is invalid");
        }

    }
}