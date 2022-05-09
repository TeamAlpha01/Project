using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

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
            if(departmentId <=0) throw new ValidationException("department name cannot be Zero or less than zero");
        
        }
        public static void IsDepartmentValid(Department department)
        {
            if(department.DepartmentName==null) throw new ValidationException("department name cannot be null");
            //if(departmentName.Length<2 && departmentName.Length>15) throw new ValidationException("department name is in Invalid Length");
            if(!Regex.IsMatch(department.DepartmentName,@"^[a-zA-Z]{3,15}$")) throw new ValidationException("Department Name is invalid");
           
        }
    }
}