using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class DriveValidation
    {
        public static void IsdriveValid(Drive drive,IConfiguration configuration)
        {
            int minimumFromDate = Convert.ToInt32(configuration.GetSection("DriveSettings").GetSection("MinimumFromDate").Value); 
            int maximumFromDate = Convert.ToInt32(configuration.GetSection("DriveSettings").GetSection("MaximumFromDate").Value); 
            int drivePeriod = Convert.ToInt32(configuration.GetSection("DriveSettings").GetSection("DrivePeriod").Value); 

            if (string.IsNullOrWhiteSpace(drive.Name)) throw new ValidationException("Drive name cannot be null");

            if (drive.Name!.Length <= 3) throw new ValidationException("Drive name is too short");

            if (drive.Name!.Length >= 25) throw new ValidationException("Drive name is too long");

            if(!Regex.IsMatch(drive.Name,"[A-Za-z.0-9\\s]*")) throw new ValidationException("Drive name cannot contain symbols.");

            if (drive.FromDate.Date < System.DateTime.Now.Date.AddDays(minimumFromDate)) throw new ValidationException($"From date must be greater than {System.DateTime.Now.Date.AddDays(minimumFromDate-1).ToShortDateString()}");

            if (drive.FromDate.Date >= System.DateTime.Now.Date.AddDays(maximumFromDate)) throw new ValidationException($"From date must be smaller than {System.DateTime.Now.Date.AddDays(maximumFromDate+1).ToShortDateString()}");
            
            if (drive.ToDate.Date < drive.FromDate.Date) throw new ValidationException("To date must be greater than from date");

            if ((drive.ToDate.Date - drive.FromDate.Date ).Days > drivePeriod ) throw new ValidationException($"The Drive period must be within {drivePeriod} Days");

            setDefaultValues(drive);
        }
        private static void setDefaultValues(Drive drive)
        {
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
            if(String.IsNullOrEmpty(reason)) throw new ValidationException("Reason cannot be empty");
            if(reason.Length<=5) throw new ValidationException($"{reason} : This reason is too short");
            if(reason.Length>250) throw new ValidationException($"{reason} : This reason is too long");
            if(String.IsNullOrWhiteSpace(reason)) throw new ValidationException("Reason cannot contain only whitespaces");
            if(!Regex.IsMatch(reason,"[a-zA-Z0-9]")) throw new ValidationException($"{reason} : Reason cannot contain only symbols");

        }
        public static void IsDriveIdValid(int driveId)
        {
            if (driveId <= 0) throw new ValidationException("Drive id is invalid");
        }
        public static void IsEmployeeIdValid(int employeeId)
        {
            if (employeeId <= 0) throw new ValidationException("TAC id is invalid");
        }

    }
}