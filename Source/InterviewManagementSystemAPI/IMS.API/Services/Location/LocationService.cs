using IMS.Models;
using IMS.Validations;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Diagnostics;
namespace IMS.Service
{
    public class LocationService : ILocationServices
    {
        private ILocationDataAccessLayer _locationDataAccessLayer;
        
        private readonly ILogger _logger;
        
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool IsTracingEnabled;
        public LocationService(ILogger<LocationService> logger,ILocationDataAccessLayer dataAccessLayer)
        {
            _logger = logger;
            _locationDataAccessLayer = dataAccessLayer;//DataFactory.LocationDataFactory.GetLocationDataAccessLayerObject(_logger);
            IsTracingEnabled = _locationDataAccessLayer.GetIsTraceEnabledFromConfiguration();    
        }
        
        /// <summary>
        /// This method will be implemented when Location Controller Passes the Location Name to the service Layer. And controll Shifts to Location DAL.
        /// </summary>
        /// <param name="location">String</param>
        /// <returns> Returns False when Exception occured in Data Access Layer. 
        /// Throws ArgumentNullException when Role Name is not passed to this service method</returns>
        public bool CreateLocation(Location location)

        {
            _stopwatch.Start();
            LocationValidation.IsLocationNameValid(location.LocationName!);

            try
            {
                location.AddedOn=System.DateTime.Now;
                location.UpdatedOn=null;
                return _locationDataAccessLayer.AddLocationToDatabase(location) ? true : false; // LOG Error in DAL;
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
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Location Service Time elapsed for  CreateLocation(string locationName) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        /// <summary>
        /// This method will be implemented when Location Controller Passes the Location ID to the service Layer. And controll Shifts to Location DAL.
        /// </summary>
        /// <param name="location">int</param>
        /// <returns>Returns False when Exception occured in Data Access Layer.
        /// Throws ArgumentNullException when Role Id is not passed to this service method</returns>

        public bool RemoveLocation(Location location)
        {
            _stopwatch.Start();
            LocationValidation.IsLocationIdValid(location.LocationId);

            try
            {
                location.AddedOn=null;
                location.UpdatedOn=System.DateTime.Now;
                return _locationDataAccessLayer.RemoveLocationFromDatabase(location.LocationId) ? true : false; // LOG Error in DAL;
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
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Location Service Time elapsed for  RemoveLocation(int locationId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        /// <summary>
        /// This method will be implemented when "View all Location" - Request raise . And control Shifts to Location DAL.
        /// </summary>
        /// <returns>Returns List of locations otherwise Throws Exception when Exception occured in DAL while fetching roles</returns>
        public IEnumerable<Location> ViewLocations()
        {
            _stopwatch.Start();
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
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Location Service Time elapsed for  ViewLocations() :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

    }
}