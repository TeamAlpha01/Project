using IMS.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;
namespace IMS.DataAccessLayer
{
    public class LocationDataAccessLayer:ILocationDataAccessLayer
    {
       private LocationContext _db = DataFactory.DbContextDataFactory.GetIMSDbContextObject();  
        private ILogger _logger;

        public LocationDataAccessLayer(ILogger logger)
        {
            _logger = logger;
        }

        public bool AddLocationToDatabase(Location location)
        {
             if (location == null)
                throw new ArgumentNullException("Location object is not provided to DAL");
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
         public bool RemoveLocationFromDatabase(int locationId)
        {
             if (locationId <= 0)
                throw new ArgumentNullException("Location object is not provided to DAL");
           
            try
            {
                var location = _db.Locations.Find(locationId);
                location.IsActive = false;
                _db.Locations.Update(location);
                _db.SaveChanges();
                return true;
            }
             catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Location DAL : RemoveLocationFromDatabase( int locationId) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Location DAL : RemoveLocationFromDatabase(int locationId ) : {exception.Message}");
                return false;
            }
            catch (ValidationException locationNotFound)
            {
                throw locationNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location DAL : RemoveLocationFromDatabase(int locationId )) : {exception.Message}");
                return false;
            }
         

        }
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