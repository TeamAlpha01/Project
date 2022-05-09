using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IMS.Model;

namespace IMS.Validation
{
    public class ProjectValidation
    {
          public static void IsProjectValid(int departmentId,string projectName)
        {
            if(departmentId <= 0)  throw new ValidationException("department name cannot be null");
            if(projectName==null) throw new ValidationException("project name cannot be null");
            //if(departmentName.Length<2 && departmentName.Length>15) throw new ValidationException("department name is in Invalid Length");
            if(!Regex.IsMatch(projectName,@"^[a-zA-Z]{3,15}$")) throw new ValidationException("Department name is invalid");
            
        }
        public static void IsProjectValid(int projectId)
        {
          if(projectId <=0) throw new ValidationException("Project Id Should not be Zero or Less than Zero");
        }
        public static void IsProjectValid(Project project)
         {
            if(project.DepartmentId <= 0)  throw new ValidationException("department Id cannot be Zero or Less than Zero");
            if(project.ProjectName==null) throw new ValidationException("project name cannot be null");
            //if(departmentName.Length<2 && departmentName.Length>15) throw new ValidationException("department name is in Invalid Length");
            if(!Regex.IsMatch(project.ProjectName,@"^[a-zA-Z]{3,15}$")) throw new ValidationException("Project name is invalid");
           
         }
    }
}