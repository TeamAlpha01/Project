using IMS.Models;
using Microsoft.EntityFrameworkCore;
namespace IMS.DataAccessLayer
{
    public class LocationDataAccessLayer:ILocationDataAccessLayer
    {
       private LocationContext _db = DataFactory.DbContextDataFactory.GetIMSDbContextObject();  
        public bool AddLocationToDatabase(Location location)
        {
            if (location == null)
                throw new ArgumentNullException("Location can't be null");
            try
            {
                _db.Locations.Add(location);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }
         public bool RemoveLocationFromDatabase(int locationId)
        {
            if (locationId == 0)
                throw new ArgumentNullException("Location Id is not provided ");

            try
            {
                var location = _db.Locations.Find(locationId);
                location.IsActive = false;
                _db.Locations.Update(location);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }

        }
         public List<Location> GetLocationsFromDatabase()
        {
            try
            {
                return _db.Locations.ToList();
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
        }


        
    }
}