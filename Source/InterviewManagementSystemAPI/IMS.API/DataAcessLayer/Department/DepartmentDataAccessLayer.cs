using Microsoft.EntityFrameworkCore;
using IMS.Models;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;
using System.Diagnostics;

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
        private IConfiguration _configuration;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool IsTracingEnabled;
        public DepartmentDataAccessLayer(ILogger<DepartmentDataAccessLayer> logger,InterviewManagementSystemDbContext dbContext,IConfiguration configuration)
        {
            _logger = logger;
            _db = dbContext;
            _configuration = configuration;
            IsTracingEnabled = GetIsTraceEnabledFromConfiguration();
        }
        /// <summary>
        /// This method will implement when Department service pass the object and it interact with Database.It validate the department name
        /// </summary>
        /// <param name="department">Department</param>
        /// <returns>Return True otherwise Return False when it throw DbUpdateException or OperationCanceledException or Exception</returns>
        public bool AddDepartmentToDatabase(Department department)
        {
            _stopwatch.Start();
            DepartmentValidation.IsDepartmentValid(department);
            bool departmentNameExists = _db.Departments!.Any(x => x.DepartmentName == department.DepartmentName && x.IsActive == true);
            if (departmentNameExists)
            {
                throw new ValidationException("Department already exist");
            }
            try
            {
                _db.Departments!.Add(department);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Department DAL : AddDepartmentToDatabase(Department department) : {exception.Message} : {exception.StackTrace}");
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Department DAL : AddDepartmentToDatabase(Department department) : {exception.Message} : {exception.StackTrace}");
                //LOG   "Opreation cancelled exception"
                return false;
            }

            catch (Exception exception)
            {
                _logger.LogError($"Department DAL : AddDepartmentToDatabase(Department department) : {exception.Message} : {exception.StackTrace}");
                //LOG   "unknown exception occured "
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Department DAL Time elapsed for  createDeaprtment(string departmentName) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role Id is not passed 
        */
        /// <summary>
        /// This method will implement when Department service pass the department Id and it interact with Database.It validate the department Id
        /// </summary>
        /// <param name="department">int</param>
        /// <returns>Return True otherwise Return False when it  throw DbUpdateException or OperationCanceledException or Exception</returns>
        public bool RemoveDepartmentFromDatabase(Department department)
        {
             _stopwatch.Start();
            DepartmentValidation.IsDepartmentIdValid(department.DepartmentId);

            bool isDeletedepartmentId = _db.Departments!.Any(x => x.DepartmentId == department.DepartmentId && x.IsActive == false);
            if (isDeletedepartmentId)
            {
                throw new ValidationException("Department already deleted");
            }
            if(hasActivePools(department.DepartmentId))
            {
                throw new ValidationException("Department contains active Pools.");
            }
            try
            {
                if (!_db.Departments!.Any(d=>d.DepartmentId==department.DepartmentId))
                    throw new ValidationException("No Department  is found with given Department Id");

                department.IsActive = false;
                _db.Departments!.Update(department);
                _db.SaveChanges();
                return true;

            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Department DAL : RemoveDepartmentFromDatabase(int departmentId) : {exception.Message} : {exception.StackTrace}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Department DAL : RemoveDepartmentFromDatabase(int departmentId) : {exception.Message} : {exception.StackTrace}");
               
                return false;
            }
            catch (ValidationException departmentNotFound)
            {
                throw departmentNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Department DAL : RemoveDepartmentFromDatabase(int departmentId) : {exception.Message} : {exception.StackTrace}");
               
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Department DAL Time elapsed for RemoveDepartmentFromDatabase(int departmentId)  :{_stopwatch.ElapsedMilliseconds}ms");
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
             _stopwatch.Start();
            try
            {
                return (from department in _db.Departments where department.IsActive == true select department).OrderBy(x => x.DepartmentName).ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Department DAL : GetDepartmentsFromDatabase() : {exception.Message} : {exception.StackTrace}");
                throw exception;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Department DAL : GetDepartmentsFromDatabase() : {exception.Message} : {exception.StackTrace}");
                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Department DAL : GetDepartmentsFromDatabase() : {exception.Message} : {exception.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Department DAL Time elapsed for  GetDepartmentsFromDatabase() :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        /// <summary>
        /// This method will implement when Department service pass the object and it interact with Database.It validate the department Id and project Name
        /// </summary>
        /// <param name="project">Project</param>
        /// <returns>Return True otherwise Return False when it  throw DbUpdateException or OperationCanceledException or Exception</returns>
        public bool AddProjectToDatabase(Project project)
        {
             _stopwatch.Start();
            var department = _db.Projects!.Find(project.DepartmentId);
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
                _logger.LogError($"Department DAL : AddProjectToDatabase(Project project) : {exception.Message} : {exception.StackTrace}");
             
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Department DAL : AddProjectToDatabase(Project project) : {exception.Message} : {exception.StackTrace}");
              
                return false;
            }
            catch (ValidationException projectnameAlreadyExists)
            {
                throw projectnameAlreadyExists;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Department DAl : AddProjectToDatabase(Project project) : {exception.Message} : {exception.StackTrace}");
                
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Department DAL Time elapsed for  AddProjectToDatabase(Project project) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Project Id is not passed 
        */
        /// <summary>
        /// This method will implement when Department service pass the project Id and it interact with Database.It validate the Project Id
        /// </summary>
        /// <param name="projectId">int</param>
        /// <returns>Return True otherwise Return False when it  throw DbUpdateException or OperationCanceledException or Exception</returns>
        public bool RemoveProjectFromDatabase(int projectId)
        {
             _stopwatch.Start();
            ProjectValidation.IsProjectValid(projectId);

            bool isProjectId = _db.Projects!.Any(x => x.ProjectId == projectId && x.IsActive == false);
            if (isProjectId)
            {
                throw new ValidationException("Project already deleted");
            }

            try
            {
                var project = _db.Projects!.Find(projectId);
                if (project == null)
                    throw new ValidationException("No Project is found with given Project Id");

                project.IsActive = false;
                _db.Projects.Update(project);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Department DAL : RemoveProjectFromDatabase(int projectId) : {exception.Message} : {exception.StackTrace}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Department DAL : RemoveProjectFromDatabase(int projectId) : {exception.Message} : {exception.StackTrace}");
                return false;
            }
            catch (ValidationException projectNotFound)
            {
                throw projectNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Department DAL : RemoveProjectFromDatabase(int projectId) : {exception.Message} : {exception.StackTrace}");
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Department DAL Time elapsed for  RemoveProjectFromDatabase(int projectId) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }
        /// <summary>
        /// This method will implement when Department service pass the department Id and it interact with Database.It validate the department Id.
        /// </summary>
        /// <returns>Return List otherwise it throw DbUpdateException or OperationCanceledException or Exception</returns>
        public List<Project> GetProjectsFromDatabase()
        {
             _stopwatch.Start();

            try
            {
                return(from project in _db.Projects!.Include(p=>p.department)where project.IsActive == true select project).OrderBy(x => x.ProjectName).ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Project DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Location DAL : GetLocationsFromDatabase() : {exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Department DAL Time elapsed for  GetProjectsFromDatabase() :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public void CheckDepartmentId(int departmentId)
        {
             _stopwatch.Start();
            if(!_db.Departments!.Any(x => x.DepartmentId == departmentId)) 
                throw new ValidationException("Department was not found");
         
        }
        public void CheckProjectId(int projectId)
        {
             _stopwatch.Start();
            if(!_db.Projects!.Any(x => x.ProjectId == projectId)) 
                throw new ValidationException("Project was not found");
          
        }
        public bool GetIsTraceEnabledFromConfiguration()
        {
            try
            {
                var IsTracingEnabled = _configuration["Tracing:IsEnabled"];
                return IsTracingEnabled != null ? Convert.ToBoolean(IsTracingEnabled) : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Department DAL", "GetIsTraceEnabledFromConfiguration()", exception);
                return false;
            
        }
    }
     private bool hasActivePools(int deparmentId)
        {
            _stopwatch.Start();
            try
            {
                if(_db.Pools!.Any(p=>p.DepartmentId==deparmentId&&p.IsActive==true))
                return true;


             return false;
            }
            catch(Exception hasActivePoolsException)
            {
                _logger.LogError($"department DAL : hasActivePoola(int departmentId) :{hasActivePoolsException.Message} : {hasActivePoolsException.StackTrace}");
                throw;
            }
              finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"department DAL Time elapsed for hasActiveDrives(int department)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
}
}