/*using System.Text.RegularExpressions;
using IMS.Models;
using IMS.DataAccessLayer;
namespace IMS.Services{
    public bool ValidateLocationName(string locationName)
    {
    /* bool locationAlreadyExists = _db.Locations.Any(x => x.locationName == Location.LocationName);
        if(locationAlreadyExists)
        {
            throw new ResponseStatusException("Location already exists");
        }
    
        if(locationName==null)
        {
               throw new ArgumentNullException("Location Name is not provided");
        }
        try
        {
        string validateloctionname="[A-Za-z]{6,25}";
        Regex Islocationvalid=new Regex(validateloctionname);
        return Islocationvalid.IsMatch(locationName) ? true : false;
        }
        catch(Exception)
        {
            return false;

        }
    }

}
*/