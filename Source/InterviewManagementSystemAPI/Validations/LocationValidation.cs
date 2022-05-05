using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class LocationValidation
    {
        public static void IsLocationValid(Location location)
        {
            if(location==null) throw new ArgumentNullException("Location  cannot be null");
           
           
        }

        public static void IsLocationNameValid(string locationName)
        {
            if(locationName==null) throw new ValidationException("Location name cannot be null");
            if(locationName.Length<6) throw new ValidationException("Location name is too short");
            //if(!Regex.IsMatch(locationName,"^[a-zA-Z]$")) throw new ValidationException("Lcation name cannot contain symbols or numbers");
           
        }
        public static void IsLocationIdValid(int locationId)
        {
             if(locationId<=0) throw new ValidationException("Location id cannot be null");

        }
        
    }
}
//Darshana
