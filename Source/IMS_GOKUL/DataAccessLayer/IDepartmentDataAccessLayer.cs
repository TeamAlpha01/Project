using IMS.Model;
namespace IMS.DataAccessLayer{
    public interface IDepartmentDataAccessLayer{
        public bool AddDepartmentToDatabase(Department department);
         public bool RemoveDepartmentFromDatabase(int departmentId);
         public List<Department> GetDepartmentsFromDatabase();
    }
}