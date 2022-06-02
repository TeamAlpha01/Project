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
         
        if(!Regex.IsMatch(locationName , @"^[a-zA-Z]{3,15}$")) 
            throw new ValidationException("Location Name must be alphabets and of lenght of 3 to 15.");
           
        }
        public static void IsLocationIdValid(int locationId)
        {
             if(locationId<=0) throw new ValidationException("Location id cannot be negative or null");

        }
        
    }
}

