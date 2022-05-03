using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IDriveDataAccessLayer
    {

        public bool AddDriveToDatabase(Drive drive);
        public bool CancelDriveFromDatabase(int driveId,int tacId,string Reason);
        public List<Drive> GetActiveDrives();
    }
}