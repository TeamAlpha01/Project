using IMS.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;
using System.Diagnostics;
namespace IMS.DataAccessLayer
{
    public class LocationDataAccessLayer : ILocationDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db;
        private ILogger _logger;
        private IConfiguration _configuration;
        private readonly Stopwatch _stopwatch = new Stopwatch();
         private bool IsTracingEnabled;
       

        public LocationDataAccessLayer(ILogger<ILocationDataAccessLayer> logger,InterviewManagementSystemDbContext dbContext,IConfiguration configuration)
        {
            _logger = logger;
            _db = dbContext;
            _configuration = configuration;
            IsTracingEnabled = GetIsTraceEnabledFromConfiguration();
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control to Location DAL. 
        /// Location DAL Perform the interaction with Database and Respond to the Add Location to Database request. 
        /// </summary>
        /// <param name="location">Object</param>
        /// <returns> Returns False when Exception occured in Database Connectivity.
        /// Throws ArgumentNullException when Role object is not passed </returns>       


        public bool AddLocationToDatabase(Location location)
        {
            _stopwatch.Start();
            LocationValidation.IsLocationValid(location);
            try
            {
                bool locationnameAlreadyExists = _db.Locations!.Any(x => x.LocationName == location.LocationName && x.IsActive == true);
                if (!locationnameAlreadyExists)
                {
                    _db.Locations!.Add(location);
                    _db.SaveChanges();
                    return true;
                }
                else
                    throw new ValidationException("Location Name already exists");
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Location DAL : AddLocationToDatabase(Location location) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Location DAL : AddLocationToDatabase(Location location) : {exception.Message}");
                return false;
            }
            catch (ValidationException locationnameAlreadyExists)
            {
                throw locationnameAlreadyExists;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Location DAL : AddLocationToDatabase(Location location)) : {exception.Message}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Location DAL Time elapsed for AddLocationToDatabase(Location location)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control to Location DAL. 
        /// Location DAL Perform the interaction with Database and Respond to the Remove Location From Database request. 
        /// </summary>
        /// <param name="locationId">int</param>
        /// <returns>Returns False when Exception occured in Database Connectivity.
        /// Throws Argument Null Exception when Location ID is null</returns>

        public bool RemoveLocationFromDatabase(int locationId)
        {
            _stopwatch.Start();
            LocationValidation.IsLocationIdValid(locationId);
            bool isLoactiontId = _db.Locations!.Any(x => x.LocationId == locationId && x.IsActive == false);
            if (isLoactiontId)
            {
                throw new ValidationException("Location already deleted");
            }

            try
            {
                var location = _db.Locations!.Find(locationId);
                if (location == null)
                    throw new ValidationException("No location is found with given Location Id");

                location.IsActive = false;
                _db.Locations.Update(location);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Location DAL : RemoveLocationFromDatabase(int locationId) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Location DAL : RemoveLocationFromDatabase(int locationId) : {exception.Message}");
                return false;
            }
            catch (ValidationException locationNotFound)
            {
                throw locationNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Location DAL : RemoveLocationFromDatabase(int locationId) : {exception.Message}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Location DAL Time elapsed for  RemoveLocationFromDatabase(int locationId) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control to Location DAL to View all Locations. 
        /// Location DAL Perform the interaction with Database and Respond to the view all Locations request.
        /// </summary>
        /// <returns>Returns a list of Location.
        /// Catches exceptions if any problems in interacting with Database</returns>
        public List<Location> GetLocationsFromDatabase()
        {
            _stopwatch.Start();
            try
            {
                return (from location in _db.Locations where location.IsActive == true select location).ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Location DAL Time elapsed for  GetLocationsFromDatabase() :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

      public bool GetIsTraceEnabledFromConfiguration()
        {
            try
            {
                var IsTracingEnabled = _configuration["Tracing:IsEnabled"];
                return IsTracingEnabled != null ? Convert.ToBoolean(IsTracingEnabled) : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location DAL", "GetIsTraceEnabledFromConfiguration()", exception);
                return false;
            
        }

    }
}
    }
