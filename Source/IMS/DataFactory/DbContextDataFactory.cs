using IMS.DataAccessLayer;
namespace IMS.DataFactory{
    public static class DbContextDataFactory{
        public static LocationContext GetIMSDbContextObject()
        {
            return new LocationContext();
        }
    }
}