using IMS.Models;
using IMS.Validations;
using IMS.DataAccessLayer;
using System.Linq;
namespace IMS.Services
{
    public class LocationService : ILocationServices
    {
        private ILocationDataAccessLayer _locationDataAccessLayer;
        private Location _location = DataFactory.LocationDataFactory.GetLocationObject();
        private readonly ILogger _logger;
        public LocationService(ILogger logger)
        {
            _logger = logger;
            _locationDataAccessLayer = DataFactory.LocationDataFactory.GetLocationDataAccessLayerObject(_logger);
        }
        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Name is not passed to this service method
        */
        public bool CreateLocation(string locationName)
        {
            if (!LocationValidation.IsLocationValid(locationName))
                throw new ValidationException("Role Name is not valid");

            try
            {
                _location.LocationName = locationName;
                return _locationDataAccessLayer.AddLocationToDatabase(_location) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Id is not passed to this service method
        */

        public bool RemoveLocation(int locationId)
        {
            if (locationId == 0)
                throw new ArgumentNullException("Location Id is not provided");

            try
            {
                return _locationDataAccessLayer.RemoveLocationFromDatabase(locationId) ? true :false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        public IEnumerable<Location> ViewLocations()
        {
            try
            {
                IEnumerable<Location> locations = new List<Location>();
                return locations = from location in _locationDataAccessLayer.GetLocationsFromDatabase() where location.IsActive == true select location;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching roles"
                throw new Exception();
            }
        }

    }
}