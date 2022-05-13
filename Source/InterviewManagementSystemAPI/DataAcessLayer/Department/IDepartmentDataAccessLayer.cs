using IMS.Models;
namespace IMS.DataAccessLayer{
    public interface IDepartmentDataAccessLayer{
        public bool AddDepartmentToDatabase(Department department);
         public bool RemoveDepartmentFromDatabase(int departmentId);
         public List<Department> GetDepartmentsFromDatabase();
          public bool AddProjectToDatabase(Project project);
         public bool RemoveProjectFromDatabase(int projectId);
         public List<Project> GetProjectsFromDatabase();
         public void CheckDepartmentId(int departmentId);
          
    }
}