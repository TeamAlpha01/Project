using IMS.Models;

namespace IMS.Service{
    public interface IDepartmentService 
    {
        public  bool CreateDepartment(Department department);
        public bool RemoveDepartment(Department department);
        public IEnumerable<Department> ViewDepartments();
         public  bool CreateProject(int departmentId,string projectName);
        public bool RemoveProject(int projectId);
        public Object ViewProjects();

    }
}