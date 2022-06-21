using IMS.Models;
using IMS.DataAccessLayer;
using IMS.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS.Service
{
    public class DepartmentService : IDepartmentService
    {

        private IDepartmentDataAccessLayer _departmentDataAccessLayer;
        private ILogger _logger;

        public DepartmentService(ILogger<DepartmentService> logger, IDepartmentDataAccessLayer departmentDataAccessLayer)
        {
            _logger = logger;
            _departmentDataAccessLayer = departmentDataAccessLayer;//DataFactory.DepartmentDataFactory.GetDepartmentDataAccessLayerObject(logger);
        }




        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Name is not passed to this service method
        */
        /// <summary>
        /// This Method will implement when Department controller pass the parameter to this method and it validate the department name and pass the object to the DAL
        /// </summary>
        /// <param name="departmentName">string</param>
        /// <returns>Return true or false otherwise throw exception when exception occur in DAL</returns>
        public bool CreateDepartment(string departmentName)
        {
            DepartmentValidation.IsDepartmentValid(departmentName);

            try
            {
                Department _department = DataFactory.DepartmentDataFactory.GetDepartmentObject();
                _department.DepartmentName = departmentName;
                return _departmentDataAccessLayer.AddDepartmentToDatabase(_department) ? true : false; // LOG Error in DAL;
            }
            catch (ValidationException departmentExist)
            {
                _logger.LogInformation($"Department Service : CreateDepartment(string departmentName) : {departmentExist.Message} : {departmentExist.StackTrace}");
                throw departmentExist;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department Service : CreateDepartment(string departmentName) : {exception.Message} : {exception.StackTrace}");

                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Id is not passed to this service method
        */
        /// <summary>
        /// This Method will implement when Department controller pass the parameter to this method and it validate the department ID and pass the departmentID to the DAL
        /// </summary>
        /// <param name="departmentId">int</param>
        /// <returns>Return true or false otherwise throw exception when exception occur in DAL</returns>
        public bool RemoveDepartment(int departmentId)
        {
            DepartmentValidation.IsDepartmentIdValid(departmentId);

            try
            {
                return _departmentDataAccessLayer.RemoveDepartmentFromDatabase(departmentId) ? true : false; // LOG Error in DAL;
            }
            catch (ValidationException departmentNotFound)
            {
                _logger.LogInformation($"Location service : RemoveLocation(int locationId) : {departmentNotFound.Message}");
                throw departmentNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department Service : RemoveDepartment(departmentId) : {exception.Message} : {exception.StackTrace}");

                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        /// <summary>
        /// This Method will implement when Department controller pass the request to this method .It Shift the control to the DAL
        /// </summary>
        /// <returns>Return list otherwise throw exception when exception occur in DAL</returns>
        public IEnumerable<Department> ViewDepartments()
        {
            try
            {
                IEnumerable<Department> departments = new List<Department>();
                return departments = from department in _departmentDataAccessLayer.GetDepartmentsFromDatabase() where department.IsActive == true select department;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department Service : ViewDepartments() : {exception.Message} : {exception.StackTrace}");

                //Log "Exception occured in DAL while fetching roles"
                throw exception;
            }
        }
        /// <summary>
        /// This Method will implement when Project controller pass the parameter to this method and it validate the  department ID and project name and pass the object to the DAL
        /// </summary>
        /// <param name="departmentId">int</param>
        /// <param name="projectName">string</param>
        /// <returns>Return true or false otherwise throw exception when exception occur in DAL</returns>
        public bool CreateProject(int departmentId, string projectName)
        {
            ProjectValidation.IsProjectValid(departmentId, projectName);


            try
            {
                Project _project = DataFactory.DepartmentDataFactory.GetProjectObject();
                _project.ProjectName = projectName;
                _project.DepartmentId = departmentId;
                return _departmentDataAccessLayer.AddProjectToDatabase(_project) ? true : false; // LOG Error in DAL;
            }
            catch (ValidationException projectnameAlreadyExists)
            {
                _logger.LogInformation($"Department Service : CreateProject(int deparmentId,string projectId) : {projectnameAlreadyExists.Message} : {projectnameAlreadyExists.StackTrace}");
                throw projectnameAlreadyExists;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department Service : CreateProject(int deparmentId,string projectId) : {exception.Message} : {exception.StackTrace}");

                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Project Id is not passed to this service method
        */
        /// <summary>
        /// This Method will implement when project controller pass the parameter to this method and it validate the project Id and pass the projectId to the DAL
        /// </summary>
        /// <param name="projectId">int</param>
        /// <returns>Return true or false otherwise throw exception when exception occur in DAL</returns>
        public bool RemoveProject(int projectId)
        {
            ProjectValidation.IsProjectValid(projectId);

            try
            {
                return _departmentDataAccessLayer.RemoveProjectFromDatabase(projectId) ? true : false; // LOG Error in DAL;
            }
            catch (ValidationException projectNotFound)
            {
                _logger.LogInformation($"Department Service : RemoveDepartment(int projectId) : {projectNotFound.Message} : {projectNotFound.StackTrace}");
                throw projectNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department Service : RemoveProject(int projectId) : {exception.Message} : {exception.StackTrace}");

                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        /// <summary>
        /// This Method will implement when Project controller pass the request to this method  and it shift the control  to the DAL

        /// </summary>
        /// <param name="departmentId">int</param>
        /// <returns>Return list otherwise throw exception when exception occur in DAL</returns>
        public Object ViewProjects()
        {
            try
            {
                return (from project in _departmentDataAccessLayer.GetProjectsFromDatabase() where project.IsActive == true select project).
                Select(
                    project => new
                    {
                        projectId = project.ProjectId,
                        projectName = project.ProjectName,
                        departmentName =project.department.DepartmentName
                    }
                );
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department Service : ViewProjects(int departmentId) : {exception.Message} : {exception.StackTrace}");

                //Log "Exception occured in DAL while fetching roles"
                throw exception;
            }
        }

    }






}