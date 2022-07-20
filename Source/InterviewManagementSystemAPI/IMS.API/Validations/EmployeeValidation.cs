using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class EmployeeValidation
    {
        public static void IsEmployeeValid(Employee employee)
        {
            if (employee == null) throw new ValidationException("Employee object cannot be null");

            if (String.IsNullOrEmpty(employee.Name)) throw new ValidationException("Employee name cannot be null");

            else if(!Regex.IsMatch(employee.Name,@"^(?!.*([ ])\1)(?!.*([A-Za-z])\2{2})\w[a-zA-Z\s]*$")) throw new ValidationException("Employee name must contain only alphabets and length of the name should be 3 to 30 char");
            //@"^[A-Z][a-zA-Z]{3,30}$"
            
            if (String.IsNullOrEmpty(employee.EmployeeAceNumber)) throw new ValidationException("EmployeeACEnumber cannot be null");
            
            // else if (employee.EmployeeAceNumber.Length != 7 || employee.EmployeeAceNumber.Length != 8) throw new ValidationException("ACE number must be 7 or 8 characters");

            else if (employee.EmployeeAceNumber == "ACE0000" || employee.EmployeeAceNumber=="ACE00000") throw new ValidationException("Invalid ACE number");

            else if (!Regex.IsMatch(employee.EmployeeAceNumber,@"^ACE[0-9]{4,5}$")) throw new ValidationException("Invalid ACE number");

            if (String.IsNullOrEmpty(employee.EmailId)) throw new ValidationException("EmailId cannot be null");

            else if (!Regex.IsMatch(employee.EmailId,@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")) throw new ValidationException ("Please enter valid email Id");

            if (String.IsNullOrEmpty(employee.Password)) throw new ValidationException("Password cannot be null"); 

            else if (!Regex.IsMatch(employee.Password,@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")) throw new ValidationException ("Password must be between 8 and 15 characters and atleast contain one uppercase letter, one lowercase letter, one digit and one special character.");            

        }
        public static void IsEmployeeIdValid(int employeeId)
        {
            if(employeeId <= 0)  throw new ValidationException("Employee Id cannot be negative characters and null");
        }

        public static void IsDepartmentValid(int DepartmentId)
        {
            if (DepartmentId <= 0) throw new ValidationException("Department with the given Id is Not found");
        }
        public static void IsValidCredentials(string employeeMail,string password)
        {
            if (String.IsNullOrEmpty(employeeMail)) throw new ValidationException("EmailId cannot be null");

            else if (!Regex.IsMatch(employeeMail,@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")) throw new ValidationException ("Enter a valid email");


        }
    }
}                                                        
