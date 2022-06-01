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

            //if(!Regex.IsMatch(drive.Name,"^[a-zA-Z0-9]+\\s[a-zA-Z][{2,20}$")) throw new ValidationException("drive name cannot contain symbols or numbers");

            if (drive.FromDate.Date < System.DateTime.Now.Date.AddDays(7)) throw new ValidationException($"From date must be greater than {System.DateTime.Now.Date.AddDays(6).ToShortDateString()}");

            if (drive.FromDate.Date >= System.DateTime.Now.Date.AddMonths(1)) throw new ValidationException($"From date must be smaller than {System.DateTime.Now.Date.AddMonths(1).ToShortDateString()}");
            
            if (drive.ToDate.Date < drive.FromDate.Date) throw new ValidationException("To date must be greater than from date");

            if ((drive.ToDate.Date - drive.FromDate.Date ).Days > 7 ) throw new ValidationException($"The Drive period must be within Seven(7) Days");

            //Setting Default values
            drive.IsScheduled = false;
            drive.IsCancelled = false;
            drive.AddedOn = DateTime.Now;
            drive.UpdatedOn = DateTime.Now;
            drive.CancelReason = null;

        }
        public static void IsCancelDriveValid(int driveId, int tacId, string reason)
        {
            IsDriveIdValid(driveId);
            IsEmployeeIdValid(tacId);   
            if(String.IsNullOrEmpty(reason)) throw new ValidationException("reason cannot be empty");
            if(reason.Length<=5) throw new ValidationException($"{reason} : This reason is too short");
            if(String.IsNullOrWhiteSpace(reason)) throw new ValidationException("reason cannot contain only whitespaces");
            if(!Regex.IsMatch(reason,"[a-zA-Z0-9]")) throw new ValidationException($"{reason} : reason cannot contain only symbols");
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