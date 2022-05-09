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

            else if(!Regex.IsMatch(employee.EmployeeName,@"^[A-Z][a-zA-Z]{3,30}$")) throw new ValidationException("Employee Name must contain only alphabets and length of the name should be 3 to 30 char");

            if (String.IsNullOrEmpty(employee.EmployeeAceNumber)) throw new ValidationException("EmployeeACEnumber cannot be null");
            
            else if (employee.EmployeeAceNumber.Length != 7) throw new ValidationException("ACE number must be 7 characters");

            else if (employee.EmployeeAceNumber == "ACE0000") throw new ValidationException("Invalid ACE number");

            else if (!Regex.IsMatch(employee.EmployeeAceNumber,@"^ACE[0-9]{4}$")) throw new ValidationException("Invalid ACE number");

            if (String.IsNullOrEmpty(employee.EmailId)) throw new ValidationException("EmailId cannot be null");

            else if (!Regex.IsMatch(employee.EmailId,@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")) throw new ValidationException ("Email Wrong Please enter valid email");

            if (String.IsNullOrEmpty(employee.Password)) throw new ValidationException("Password cannot be null"); 

            else if (!Regex.IsMatch(employee.Password,@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")) throw new ValidationException ("Password must be between 8 and 15 characters and atleast contain one uppercase letter, one lowercase letter, one digit and one special character.");            

        }
        public static void IsEmployeeIdValid(int employeeId)
        {
            if(employeeId <= 0)  throw new ValidationException("Employee Id cannot be negative characters and null");
        }
    }
}                                                        
