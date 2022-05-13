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
            var fromTime = DateTime.Parse(employeeAvailability.FromTime).TimeOfDay;
            var toTime = DateTime.Parse(employeeAvailability.ToTime).TimeOfDay;
            if(fromTime>=toTime)
            {
                Console.Write("sadaasd");
            }
        }

        public static void IsAvailabilityIdValid(int employeeAvailabilityId)
        {
            if(employeeAvailabilityId<=0) throw new ValidationException($"Ivalid EmployeeAvailabilityId : {employeeAvailabilityId}");
        }
    }
}