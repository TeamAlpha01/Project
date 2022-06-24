using Microsoft.EntityFrameworkCore;
using IMS.Models;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;

namespace IMS.DataAccessLayer
{
    public class DepartmentDataAccessLayer : IDepartmentDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db;// = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();

        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role object is not passed 
        */

        //private readonly ILogger _logger = new ILogger<RoleDataAccessLayer>();        
        private ILogger _logger;
        public DepartmentDataAccessLayer(ILogger<DepartmentDataAccessLayer> logger,InterviewManagementSystemDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }
        /// <summary>
        /// This method will implement when Department service pass the object and it interact with Database.It validate the department name
        /// </summary>
        /// <param name="department">Department</param>
        /// <returns>Return True otherwise Return False when it throw DbUpdateException or OperationCanceledException or Exception</returns>
        public bool AddDepartmentToDatabase(Department department)
        {
            DepartmentValidation.IsDepartmentValid(department);
            bool departmentNameExists = _db.Departments.Any(x => x.DepartmentName == department.DepartmentName && x.IsActive == true);
            if (departmentNameExists)
            {
                throw new ValidationException("Department already exist");
            }
            try
            {
                _db.Departments.Add(department);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Department DAL : AddDepartmentToDatabase(Department department) : {exception.Message} : {exception.StackTrace}");
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Department DAL : AddDepartmentToDatabase(Department department) : {exception.Message} : {exception.StackTrace}");
                //LOG   "Opreation cancelled exception"
                return false;
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"Department DAL : AddDepartmentToDatabase(Department department) : {exception.Message} : {exception.StackTrace}");
                //LOG   "unknown exception occured "
                return false;
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role Id is not passed 
        */
        /// <summary>
        /// This method will implement when Department service pass the department Id and it interact with Database.It validate the department Id
        /// </summary>
        /// <param name="departmentId">int</param>
        /// <returns>Return True otherwise Return False when it  throw DbUpdateException or OperationCanceledException or Exception</returns>
        public bool RemoveDepartmentFromDatabase(int departmentId)
        {
            DepartmentValidation.IsDepartmentIdValid(departmentId);

            bool isDeletedepartmentId = _db.Departments.Any(x => x.DepartmentId == departmentId && x.IsActive == false);
            if (isDeletedepartmentId)
            {
                throw new ValidationException("Department already deleted");
            }
            try
            {
                var department = _db.Departments.Find(departmentId);
                if (department == null)
                    throw new ValidationException("No Department  is found with given Department Id");

                department.IsActive = false;
                _db.Departments.Update(department);
                _db.SaveChanges();
                return true;

            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Department DAL : RemoveDepartmentFromDatabase(int departmentId) : {exception.Message} : {exception.StackTrace}");
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Department DAL : RemoveDepartmentFromDatabase(int departmentId) : {exception.Message} : {exception.StackTrace}");
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (ValidationException departmentNotFound)
            {
                throw departmentNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department DAL : RemoveDepartmentFromDatabase(int departmentId) : {exception.Message} : {exception.StackTrace}");
                //LOG   "unknown exception occured "
                return false;
            }

        }

        /*  
            Throws Exception when Exception occured in Database Connectivity
        */
        /// <summary>
        /// This method will implement when Department service pass the request and it interact with Database.
        /// </summary>
        /// <returns>Return List. otherwise throw DbUpdateException or OperationCanceledException or Exception</returns>
        public List<Department> GetDepartmentsFromDatabase()
        {
            try
            {
                return _db.Departments.ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Department DAL : GetDepartmentsFromDatabase() : {exception.Message} : {exception.StackTrace}");

                //LOG   "DB Update Exception Occured"
                throw exception;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Department DAL : GetDepartmentsFromDatabase() : {exception.Message} : {exception.StackTrace}");
                //LOG   "Opreation cancelled exception"
                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department DAL : GetDepartmentsFromDatabase() : {exception.Message} : {exception.StackTrace}");
                //LOG   "unknown exception occured "
                throw exception;
            }
        }
        /// <summary>
        /// This method will implement when Department service pass the object and it interact with Database.It validate the department Id and project Name
        /// </summary>
        /// <param name="project">Project</param>
        /// <returns>Return True otherwise Return False when it  throw DbUpdateException or OperationCanceledException or Exception</returns>
        public bool AddProjectToDatabase(Project project)
        {
            var department = _db.Projects.Find(project.DepartmentId);
            if (department == null)
                throw new ValidationException("No department Id found with given department id");

            try
            {

                bool projectnameAlreadyExists = _db.Projects.Any(x => x.ProjectName == project.ProjectName && x.IsActive == true && x.DepartmentId==project.DepartmentId);
                if (!projectnameAlreadyExists)
                {
                    _db.Projects.Add(project);
                    _db.SaveChanges();
                    return true;
                }
                else
                    throw new ValidationException("Project Name already exists");

            }

            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Department DAL : AddProjectToDatabase(Project project) : {exception.Message} : {exception.StackTrace}");
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Department DAL : AddProjectToDatabase(Project project) : {exception.Message} : {exception.StackTrace}");
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (ValidationException projectnameAlreadyExists)
            {
                throw projectnameAlreadyExists;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department DAl : AddProjectToDatabase(Project project) : {exception.Message} : {exception.StackTrace}");
                //LOG   "unknown exception occured "
                return false;
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role Id is not passed 
        */
        /// <summary>
        /// This method will implement when Department service pass the project Id and it interact with Database.It validate the Project Id
        /// </summary>
        /// <param name="projectId">int</param>
        /// <returns>Return True otherwise Return False when it  throw DbUpdateException or OperationCanceledException or Exception</returns>
        public bool RemoveProjectFromDatabase(int projectId)
        {
            ProjectValidation.IsProjectValid(projectId);

            bool isProjectId = _db.Projects.Any(x => x.ProjectId == projectId && x.IsActive == false);
            if (isProjectId)
            {
                throw new ValidationException("Project already deleted");
            }

            try
            {
                var project = _db.Projects.Find(projectId);
                if (project == null)
                    throw new ValidationException("No Project is found with given Project Id");

                project.IsActive = false;
                _db.Projects.Update(project);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Department DAL : RemoveProjectFromDatabase(int projectId) : {exception.Message} : {exception.StackTrace}");

                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Department DAL : RemoveProjectFromDatabase(int projectId) : {exception.Message} : {exception.StackTrace}");

                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (ValidationException projectNotFound)
            {
                throw projectNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department DAL : RemoveProjectFromDatabase(int projectId) : {exception.Message} : {exception.StackTrace}");

                //LOG   "unknown exception occured "
                return false;
            }

        }

        /*  
            Throws Exception when Exception occured in Database Connectivity
        */
        /// <summary>
        /// This method will implement when Department service pass the department Id and it interact with Database.It validate the department Id.
        /// </summary>
        /// <param name="departmentId">int</param>
        /// <returns>Return List otherwise it throw DbUpdateException or OperationCanceledException or Exception</returns>
        public List<Project> GetProjectsFromDatabase()
        {

            try
            {
                return _db.Projects.Include(p=>p.department).ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Project DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new Exception();
            }
        }

        public void CheckDepartmentId(int departmentId)
        {
            if(!_db.Departments.Any(x => x.DepartmentId == departmentId)) 
                throw new ValidationException("Department was not found");
            
        }
        public void CheckProjectId(int projectId)
        {
            if(!_db.Projects.Any(x => x.ProjectId == projectId)) 
                throw new ValidationException("Project was not found");
            
        }
    }
}