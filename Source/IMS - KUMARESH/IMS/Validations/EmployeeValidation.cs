using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Model;

namespace IMS.Validations
{
    public static class EmployeeValidation
    {
        public static void IsEmployeeValid(Employee employee)
        {
            if (employee == null) throw new ValidationException("Employee object cannot be null");

            if (String.IsNullOrEmpty(employee.EmployeeName)) throw new ValidationException("Employee Name cannot be null");
            
            else if(!Regex.IsMatch(employee.EmployeeName,@"^[a-zA-Z]{3,30}$")) throw new ValidationException("Employee Name must contain only alphabets and lenght of the name should be 3 to 30 char");

            if (String.IsNullOrEmpty(employee.EmployeeAceNumber)) throw new ValidationException("EmployeeACEnumber cannot be null");
            
            else if (employee.EmployeeAceNumber.Length != 7) throw new ValidationException("Enter correct ACE number");

            else if (!Regex.IsMatch(employee.EmployeeAceNumber,@"^[ACE1234]$")) throw new ValidationException("1st 3 char of EmployeeAceNumber must contain ACE OR ace");

            // else if (!Regex.IsMatch(employee.EmployeeAceNumber.Substring(3,employee.EmployeeAceNumber.Length),@"^[0-9]$")) throw new ValidationException("last 4 char of EmployeeAceNumber cannot contain symbols or Alphabets");

            if (String.IsNullOrEmpty(employee.EmailId)) throw new ValidationException("EmailId cannot be null");

            if (String.IsNullOrEmpty(employee.Password)) throw new ValidationException("Password cannot be null");      

            // if (!Regex.IsMatch(employee.EmailId,@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")) throw new ValidationException ("Email Wrong Please enter valid email");
        }
    }
}                                                        
