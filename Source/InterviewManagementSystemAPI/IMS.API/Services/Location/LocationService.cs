using IMS.Models;
using IMS.Validations;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace IMS.Service
{
    public class LocationService : ILocationServices
    {
        private ILocationDataAccessLayer _locationDataAccessLayer;
        
        private readonly ILogger _logger;
        public LocationService(ILogger<LocationService> logger,ILocationDataAccessLayer dataAccessLayer)
        {
            _logger = logger;
            _locationDataAccessLayer = dataAccessLayer;//DataFactory.LocationDataFactory.GetLocationDataAccessLayerObject(_logger);
        }
        
        /// <summary>
        /// This method will be implemented when Location Controller Passes the Location Name to the service Layer. And controll Shifts to Location DAL.
        /// </summary>
        /// <param name="locationName">String</param>
        /// <returns> Returns False when Exception occured in Data Access Layer. 
        /// Throws ArgumentNullException when Role Name is not passed to this service method</returns>
        public bool CreateLocation(string locationName)

        {
            LocationValidation.IsLocationNameValid(locationName);

            try
            {
                Location _location = DataFactory.LocationDataFactory.GetLocationObject();
                _location.LocationName = locationName;
                return _locationDataAccessLayer.AddLocationToDatabase(_location) ? true : false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
                _logger.LogError($"Location service : CreateLocation(string  locationName) : {exception.Message}");
                return false;
            }
            catch (ValidationException locationnameAlreadyExists)
            {
             _logger.LogError($"Location service : CreateLocation(string  locationName) : {locationnameAlreadyExists.Message}");
              throw locationnameAlreadyExists;
            }

            catch (Exception exception)
            {
                _logger.LogError($"Location service : CreateLocation(string locationName) : {exception.Message}");
                return false;
            }

        }

        /// <summary>
        /// This method will be implemented when Location Controller Passes the Location ID to the service Layer. And controll Shifts to Location DAL.
        /// </summary>
        /// <param name="locationId">int</param>
        /// <returns>Returns False when Exception occured in Data Access Layer.
        /// Throws ArgumentNullException when Role Id is not passed to this service method</returns>

        public bool RemoveLocation(int locationId)
        {
            LocationValidation.IsLocationIdValid(locationId);

            try
            {
                return _locationDataAccessLayer.RemoveLocationFromDatabase(locationId) ? true : false; // LOG Error in DAL;
            }
           catch (ArgumentException exception)
            {
                _logger.LogError($"Location service : RemoveLocation(int locationId) : {exception.Message}");
                return false;
            }
            catch (ValidationException locationNotFound)
            {
                _logger.LogError($"Location service : RemoveLocation(int locationId) : {locationNotFound.Message}");
                throw locationNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Location service : RemoveLocation(int locationId) :{exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// This method will be implemented when "View all Location" - Request raise . And control Shifts to Location DAL.
        /// </summary>
        /// <returns>Returns List of locations otherwise Throws Exception when Exception occured in DAL while fetching roles</returns>
        public IEnumerable<Location> ViewLocations()
        {
            try
            {
                IEnumerable<Location> locations = new List<Location>();
                return locations = _locationDataAccessLayer.GetLocationsFromDatabase() ;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Location service:ViewLocations(): {exception.Message}");
                throw new Exception();
            }

        }

    }
}