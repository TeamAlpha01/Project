using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public class DepartmentValidation
    {
         public static void IsDepartmentValid(string departmentName)
        {
            if(departmentName==null) throw new ValidationException("Department name cannot be null");
           
           if(!Regex.IsMatch(departmentName , @"^[a-zA-Z]{3,15}$")) 
                throw new ValidationException("Department name must be alphabets and of length 3 to 15");

           
        }
        public static void IsDepartmentValid(Department department)
        {
            if(department==null) throw new ValidationException("Department object cannot be null");
           if(!Regex.IsMatch(department.DepartmentName,@"[a-zA-Z ]{3,15}")) throw new ValidationException("Department Name must be alphabets and of lenght of 3 to 15.");
           
        }
        
         public static void IsDepartmentIdValid(int deparmentId)
         {
             if(deparmentId<=0) throw new ValidationException("Department Id cannot be zero or less than zero");
         }
    }
}