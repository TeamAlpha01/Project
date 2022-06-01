using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;
using IMS.Validations;

namespace IMS.Validations
{
    public static class EmployeeResponseValidation
    {
        public static void IsResponseValid(EmployeeDriveResponse response)
        {
            EmployeeValidation.IsEmployeeIdValid(response.EmployeeId);
            DriveValidation.IsDriveIdValid(response.DriveId);
            IsResponseTypeValid(response.ResponseType);

        }
        public static void IsResponseTypeValid(int responseType)
        {
            if (responseType > 3 || responseType < 1) throw new ValidationException($"Invalid Response Type : {responseType}");
        }
    }
}