using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IMS.Models;

namespace IMS.Validations
{
    public class ProjectValidation
    {
          public static void IsProjectValid(int departmentId,string projectName)
        {
            if(departmentId <= 0)  throw new ValidationException("Department Id cannot be null or negative");
            if(projectName==null) throw new ValidationException("project name cannot be null");
            if (String.IsNullOrEmpty(projectName)) throw new ValidationException("Project Name cannot be Empty or Null");
            if(projectName.Length<=2) throw new ValidationException("Project Name is too short.It cannot be less than or equql to two");
            if(!Regex.IsMatch(@projectName,@"^(?!.*([ ])\1)(?!.*([A-Za-z])\2{2})\w[a-zA-Z\s]*$")) throw new ValidationException("Project Name must contain only alphabets and of lenght 3 to 25");
            
        }
        public static void IsProjectValid(int projectId)
        {
          if(projectId <=0) throw new ValidationException("Project Id Should not be Zero or Less than Zero");
        }
        public static void IsProjectValid(Project project)
         {
            if(project== null) throw new ValidationException("Project Object cannot be null");
            if(project.DepartmentId <= 0)  throw new ValidationException("Department Id cannot be null or negative");
            if(project.ProjectName==null) throw new ValidationException("Project name cannot be null");
      
            if(!Regex.IsMatch(project.ProjectName,@"^[a-zA-Z ]{3,25}$")) throw new ValidationException("Project Name must contain only alphabets and of lenght 3 to 25");
           
         }
    }
}