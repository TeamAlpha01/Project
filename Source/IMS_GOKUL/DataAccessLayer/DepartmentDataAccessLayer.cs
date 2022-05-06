using Microsoft.EntityFrameworkCore;
using IMS.Model;
using System.ComponentModel.DataAnnotations;

namespace IMS.DataAccessLayer
{
    public class DepartmentDataAccessLayer : IDepartmentDataAccessLayer
    {
        private Departmentcontext _db = DataFactory.DbContextDataFactory.GetDepartmentContextObject();

        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role object is not passed 
        */

        //private readonly ILogger _logger = new ILogger<RoleDataAccessLayer>();        
         private ILogger _logger;
        public DepartmentDataAccessLayer(ILogger logger)
        {
            _logger = logger;
        }
        public bool AddDepartmentToDatabase(Department department)
        {
            if (department == null)
                throw new ArgumentNullException("Department is not provided");
            try
            {
                _db.Departments.Add(department);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role Id is not passed 
        */
        public bool RemoveDepartmentFromDatabase(int departmentId)
        {
            if (departmentId == 0)
                throw new ArgumentNullException("Department Id is not provided ");

            try
            {
                var department = _db.Departments.Find(departmentId);
                department.IsActive = false;
                _db.Departments.Update(department);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }

        }

        /*  
            Throws Exception when Exception occured in Database Connectivity
        */
        public List<Department> GetDepartmentsFromDatabase()
        {
            try
            {
                return _db.Departments.ToList();
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
        }

        public bool AddProjectToDatabase(Project project)
        {
            if (project == null)
                throw new ArgumentNullException("DepartmentId and ProjectName is not provided");
            try
            {
                _db.Projects.Add(project);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role Id is not passed 
        */
        public bool RemoveProjectFromDatabase(int projectId)
        {
            if (projectId <=0 )
                throw new ArgumentNullException("Project Id is not provided ");

            try
            {
                var project = _db.Projects.Find(projectId);
                project.IsActive = false;
                _db.Projects.Update(project);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }

        }

        /*  
            Throws Exception when Exception occured in Database Connectivity
        */
        public List<Project> GetProjectsFromDatabase(int departmentId)
        {
            try
            { 
                  var project1 = (from project in _db.Projects where project.DepartmentId == departmentId select project);
                   return project1.Count() != 0 ? project1.ToList() : throw new ValidationException("Department is not  found");
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
        }






    }
}