using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IDriveDataAccessLayer
    {

        public bool AddDriveToDatabase(Drive drive);
        public bool CancelDriveFromDatabase(int driveId,int tacId,string Reason);
        public List<Drive> GetDrivesByStatus(bool status);
        public Drive ViewDrive(int driveId);
    }
}