using IMS.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;
namespace IMS.DataAccessLayer
{
    public class LocationDataAccessLayer:ILocationDataAccessLayer
    {
       private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger _logger;

        public LocationDataAccessLayer(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control to Location DAL. 
        /// Location DAL Perform the interaction with Database and Respond to the Add Location to Database request. 
        /// </summary>
        /// <param name="Location">Object</param>
        /// <returns> Returns False when Exception occured in Database Connectivity.
        /// Throws ArgumentNullException when Role object is not passed </returns>       


        public bool AddLocationToDatabase(Location location)
        {
            LocationValidation.IsLocationValid(location);
            try
            {
                _db.Locations.Add(location);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Location DAL : AddLocationToDatabase(Location location) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Location DAL : AddLocationToDatabase(Location location) : {exception.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location DAL : AddLocationToDatabase(Location location)) : {exception.Message}");
                return false;
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
            LocationValidation.IsLocationIdValid(locationId);
           
            try
            {
                var location = _db.Locations.Find(locationId);
                if (location == null) 
                    throw new ValidationException("No location is found with given Location Id");
               
                location.IsActive = false;
                _db.Locations.Update(location);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Location DAL : RemoveLocationFromDatabase(int locationId) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Location DAL : RemoveLocationFromDatabase(int locationId) : {exception.Message}");
                return false;
            }
            catch (ValidationException locationNotFound)
            {
                throw locationNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location DAL : RemoveLocationFromDatabase(int locationId) : {exception.Message}");
                return false;
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
            try
            {
                return _db.Locations.ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new Exception();
            }
        }


        
    }
}