using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;
using IMS.Validations;

namespace IMS.Validation
{
    public static class EmployeeResponseValidation
    {
        public static void IsResponseValid(EmployeeDriveResponse response)
        {
            EmployeeValidation.IsEmployeeIdValid(response.EmployeeId);
            DriveValidation.IsDriveIdValid(response.DriveId);
            if(response.ResponseType>3 || response.ResponseType<1) throw new ValidationException($"Invalid Response Type : {response.ResponseType}");
        }
    }
}