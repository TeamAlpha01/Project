using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class LocationValidation
    {
        public static void IsLocationValid(Location location)
        {
            if(location==null) throw new ValidationException("Location object cannot be null");
           
           
        }

        public static void IsLocationNameValid(string locationName)
        {
        if(locationName==null) throw new ValidationException("Location name cannot be null");
        if (String.IsNullOrEmpty(locationName)) throw new ValidationException("Location Name cannot be null");
         
        if(!Regex.IsMatch(locationName , @"^[A-Za-z]{3,30}$")) 
            throw new ValidationException("Location Name must contain only alphabets and length of the name should be 3 to 30 char");
           
        }
        public static void IsLocationIdValid(int locationId)
        {
             if(locationId<=0) throw new ValidationException("Location id cannot be negative or null");

        }
        
    }
}

