using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMS.Validation
{
    public class ProjectValidation
    {
          public static bool IsProjectValid(int departmentId,string projectName)
        {
            if(departmentId <= 0)  throw new ValidationException("department name cannot be null");
            if(projectName==null) throw new ValidationException("project name cannot be null");
            //if(departmentName.Length<2 && departmentName.Length>15) throw new ValidationException("department name is in Invalid Length");
            if(!Regex.IsMatch(projectName,@"^[a-zA-Z]{3,15}$")) throw new ValidationException("Department name is invalid");
            return true;
        }
    }
}