using IMS.Models;
using IMS.Validations;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
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
            
            Throws ArgumentNullException when Location Name is not passed to this service method
        */
        public bool CreateLocation(string locationName)
        {
            LocationValidation.IsLocationNameValid(locationName);
               

            try
            {
                _location.LocationName = locationName;
                return _locationDataAccessLayer.AddLocationToDatabase(_location) ? true : false; // LOG Error in DAL;
            }
             catch (ArgumentException exception)
            {
                _logger.LogInformation($"Location service : CreateLocation(string  locationName) : {exception.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location service : CreateLocation(string locationName) : {exception.Message}");
                return false;
            }
         
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Location Id is not passed to this service method
        */

        public bool RemoveLocation(int locationId)
        {
              LocationValidation.IsLocationIdValid(locationId);

            try
            {
                return _locationDataAccessLayer.RemoveLocationFromDatabase(locationId) ? true :false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
            _logger.LogInformation($"Location service : RemoveLocation(int locationId) : {exception.Message}");
              return false;
            }
             catch (ValidationException locationNotFound)
            {
                throw locationNotFound;
            }

            
            catch (Exception exception)
            {
                _logger.LogInformation($"Location service : RemoveLocation(int locationId) : {exception.Message}");
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching location
        */
        public IEnumerable<Location> ViewLocations()
        {
            try
            {
                IEnumerable<Location> locations = new List<Location>();
                return locations = from location in _locationDataAccessLayer.GetLocationsFromDatabase() where location.IsActive == true select location;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location service: {exception.Message}");
                throw new Exception();
              
            }
          
        }

    }
}