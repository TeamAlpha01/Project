using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class LocationValidation
    {
        public static bool IsLocationValid(string locationName)
        {
            if(locationName==null) throw new ValidationException("Location name cannot be null");
            if(locationName.Length<6) throw new ValidationException("Location name is too short");
            if(!Regex.IsMatch(locationName,"^[a-zA-Z]$")) throw new ValidationException("Lcation name cannot contain symbols or numbers");
            return true;
        }
    }
}