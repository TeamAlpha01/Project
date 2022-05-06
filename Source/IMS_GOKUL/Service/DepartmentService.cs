using IMS.Model;
using IMS.DataAccessLayer;
using IMS.Validation;

namespace IMS.Service
{
    public class DepartmentService : IDepartmentService
    {

        private IDepartmentDataAccessLayer _departmentDataAccessLayer ;
         private ILogger _logger;

        public DepartmentService(ILogger logger)
        {
            _logger = logger;
         _departmentDataAccessLayer = DataFactory.DepartmentDataFactory.GetDepartmentDataAccessLayerObject(logger);
        }

         
        private Department _department = DataFactory.DepartmentDataFactory.GetDepartmentObject();
       private Project _project = DataFactory.DepartmentDataFactory.GetProjectObject();

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Name is not passed to this service method
        */
        public bool CreateDepartment(string departmentName)
        {
            DepartmentValidation.IsDepartmentValid(departmentName);

            try
            {
                _department.DepartmentName = departmentName;
                return _departmentDataAccessLayer.AddDepartmentToDatabase(_department) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Id is not passed to this service method
        */

        public bool RemoveDepartment(int departmentId)
        {
            if (departmentId == 0)
                throw new ArgumentNullException("Department Id is not provided");

            try
            {
                return _departmentDataAccessLayer.RemoveDepartmentFromDatabase(departmentId) ? true :false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        public IEnumerable<Department> ViewDepartments()
        {
            try
            {
                IEnumerable<Department> departments = new List<Department>();
                return departments = from department in _departmentDataAccessLayer.GetDepartmentsFromDatabase() where department.IsActive == true select department;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching roles"
                throw new Exception();
            }
        }
         public bool CreateProject(int departmentId,string projectName)
        {
            if (!ProjectValidation.IsProjectValid(departmentId,projectName))
            
                throw new ArgumentNullException("DepartmentId or Project Name  is not provided");

            try
            {
                _project.ProjectName = projectName;
                _project.DepartmentId= departmentId;
                return _departmentDataAccessLayer.AddProjectToDatabase(_project) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Project Id is not passed to this service method
        */

        public bool RemoveProject(int projectId)
        {
            if (projectId <= 0)
                throw new ArgumentNullException("project Id is not provided");

            try
            {
                return _departmentDataAccessLayer.RemoveProjectFromDatabase(projectId) ? true :false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        public IEnumerable<Project> ViewProjects(int departmentId)
        {
            try
            {
                IEnumerable<Project> projects = new List<Project>();
                return projects = from project in _departmentDataAccessLayer.GetProjectsFromDatabase(departmentId) where project.IsActive == true select project;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching roles"
                throw new Exception();
            }
        }

    }






}