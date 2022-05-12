using IMS.Models;

namespace IMS.Service{
    public interface IDepartmentService 
    {
        public  bool CreateDepartment(string departmentName);
        public bool RemoveDepartment(int departmentId);
        public IEnumerable<Department> ViewDepartments();
         public  bool CreateProject(int departmentId,string projectName);
        public bool RemoveProject(int projectId);
        public IEnumerable<Project> ViewProjects();

    }
}