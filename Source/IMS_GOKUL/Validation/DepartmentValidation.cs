using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMS.Validation
{
    public class DepartmentValidation
    {
         public static void IsDepartmentValid(string departmentName)
        {
            if(departmentName==null) throw new ValidationException("department name cannot be null");
            //if(departmentName.Length<2 && departmentName.Length>15) throw new ValidationException("department name is in Invalid Length");
            if(!Regex.IsMatch(departmentName,@"^[a-zA-Z]{3,15}$")) throw new ValidationException("Department Name is invalid");
           
        }
         public static void IsDepartmentValid(int departmentId)
        {
            if(departmentName <=0) throw new ValidationException("department name cannot be Zero or less than zero");
           
           
        }
    }
}